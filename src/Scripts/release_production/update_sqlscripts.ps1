$sqlScriptFolderPath = "$PSScriptRoot\..\sqlscripts"
$connectionString = 'Server=pcsinvoicing.database.windows.net; Database=pcsprod; User Id=pcsadmin; password=123*789adminPcs#$59147'
$query = 'SELECT Value FROM SqlScripts'

$sqlConnection = New-Object System.Data.SqlClient.SqlConnection($connectionString)
$sqlConnection.Open()

$sqlCommand = $sqlConnection.CreateCommand()
$sqlCommand.CommandText = $query

$sqlScriptName = $sqlCommand.ExecuteScalar() + ".sql"

$foundFile = Get-ChildItem -Path $sqlScriptFolderPath -Filter $sqlScriptName -File | Select-Object -First 1

if ($foundFile -ne $null) {
    $scriptsCreatedAfter = Get-ChildItem -Path $sqlScriptFolderPath -File | Where-Object { $_.CreationTime -gt $foundFile.CreationTime }
    
    if($scriptsCreatedAfter -ne $null){
        foreach($file in $scriptsCreatedAfter){
            $scriptPath = $file.DirectoryName + "\"+ $file.Name
            $sqlScript = Get-Content $scriptPath  -Raw
            $sqlCommand1 = $sqlConnection.CreateCommand()
            $sqlCommand1.CommandText = $sqlScript
            $sqlCommand1.ExecuteNonQuery()
        }
    }
    

   
}

$sqlConnection.Close()
