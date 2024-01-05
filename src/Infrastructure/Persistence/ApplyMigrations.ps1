$startupProject =  "$PSScriptRoot\..\..\Web\Web.csproj"
dotnet ef database update --startup-project $startupProject --context HshDbContext