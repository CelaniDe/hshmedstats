$currentFile = Get-Location
$currentDirectory = (get-item $currentFile).Parent.FullName
$startupProject = $currentDirectory + '..\..\Web\Web.csproj'
dotnet ef migrations remove --startup-project $startupProject