$currentFile = Get-Location
$currentDirectory = (get-item $currentFile).Parent.FullName
$startupProject = $currentDirectory + '..\..\Web\Web.csproj'
$migrationName = Read-Host -Prompt 'Please write migration name: '
dotnet ef migrations add $migrationName  --startup-project $startupProject --context HshDbContext