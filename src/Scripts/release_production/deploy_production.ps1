Write-Warning "Starting production release to azure"

$date = Get-Date
$backupName = "pcs_production_"+$date.ToShortDateString()+".bacpac"
$backupPath = "D:\Development\Backups\PCS\" + $backupName

$branch = Read-Host "Which branch to deploy:"

git switch $branch

git pull

Write-Warning "Running tests"
dotnet test ..\..\PCS.sln

Read-Host "BACKUP DB WILL BE EXPORTED. PRESS ENTER TO CONTINUE..."
# Will be used for automated backup
& 'C:\Program Files\sqlpackage\sqlpackage.exe' /a:export /tf:$backupPath /scs:'Data Source=pcsinvoicing.database.windows.net;Initial Catalog=pcsprod;User Id=pcsadmin;Password=123*789adminPcs#$59147;'

Read-Host "CHECK IF BACKUP IS GOOD. PRESS ENTER TO CONTINUE"

function Get-PasswordFromPublishProfile{
    param([string]$publishProfilePath)
     $publishProfile = Get-Content -Path $publishProfilePath
     $userPwdExist = $publishProfile -match 'userPWD="\w+"'
     if($userPwdExist){
        $password = $matches[0].Replace('userPWD="','')
        $password = $password.Replace('"','')
        return $password
    }
    return ""
}


$msbuildPath = "C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe"
$result = Test-Path $msbuildPath
if(-Not $result){
	$msbuildPath = "C:\Program Files (x86)\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe"
	$result = Test-Path $msbuildPath
	if(-Not $result){
		Write-Error "Missing MSBuild in C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\"
		exit
	}
}

# Transform to production
Write-Warning "Transforming connection strings to production..."
Invoke-Expression -Command "$PSScriptRoot\..\production_transform.ps1"

# Run the Database update
$res = Read-Host "Please check that all migrations are done. Do you want to apply migrations to the database? (Y/N)"
if($res.ToLower() -eq "y"){
    Write-Warning "Applying migrations..."
    Invoke-Expression -Command "$PSScriptRoot\..\..\Infrastructure\Persistence\ApplyMigrations.ps1"
    Write-Warning "Finished database update"
}
$res = ""

$res = Read-Host "Do you want to start custom sql script running (Y/N)"
if($res.ToLower() -eq "y"){
	$scriptPath = "$PSScriptRoot\update_sqlscripts.ps1"
	& $scriptPath
}

# Publish the app with web jobs
$res = Read-Host "Do you want to start the deployment of the Web client to azure? (Y/N)"
if($res.ToLower() -eq "y"){
    Write-Warning "Deploying web client and web jobs to production..."
    $password = Get-PasswordFromPublishProfile -publishProfilePath "$PSScriptRoot\pcsmarket.PublishSettings"
    if($password -ne ""){
        & $msbuildPath "$PSScriptRoot\..\..\PCS.sln" /p:DeployOnBuild=true /p:PublishProfile="pcsmarket - Web Deploy" /p:Configuration=Release /p:Password=$password  
    }
    Write-Warning "Finished app deployment to production"
}

$res = ""

git checkout .