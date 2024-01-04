$pathToAppSettings = "$PSScriptRoot\..\Web\appsettings.json"
$pathToChasingEmailSettings = "$PSScriptRoot\..\ChasingEmailsJob\appsettings.json"
$pathToInvoiceGenerationSettings = "$PSScriptRoot\..\InvoiceGenerationJob\appsettings.json"
$pathToKeepAwakeJsReporting = "$PSScriptRoot\..\KeepAwakeJsReportingJob\appsettings.json"
$pathToDailyTasksSettings = "$PSScriptRoot\..\DailyTasksEmailsJob\appsettings.json"
$pathToCloseDealNotificationSettings = "$PSScriptRoot\..\CloseDealNotificationsJob\appsettings.json"
$pathToDailyExpectedClosingDateSettings = "$PSScriptRoot\..\DailyExpectedClosingDateJob\appsettings.json"
$pathToWeeklyAnalystReportSettings = "$PSScriptRoot\..\WeeklyAnalystReportJob\appsettings.json"
$pathToDailyTasksCreationSettings = "$PSScriptRoot\..\DailyTasksCreationJob\appsettings.json"
$pathToEventParticipationSettings = "$PSScriptRoot\..\EventParticipationJob\appsettings.json"

$ConnectionString = 'Server=pcsinvoicing.database.windows.net; Database=pcsprod; User Id=pcsadmin; password=123*789adminPcs#$59147'
$JsReportUrl = "https://pcsreporting.azurewebsites.net"
$JsReportUser = "pcsadmin"
$JsReportPassword = "pcsadminpr0dpA55w0rd"
$EmailCCRecipients = "invoicing@pcsmarket.org"
$ApiSecret = "-54u#%q!T]L8U(^jZI#OR{5YC2lY*8(c0C?Dl2^pqZY*8(8Ib6Fg648_0g2Q2$"
$ApiUsername = "PCSPortal"
$ApiPassword = "S9TUhDG7Qbz"
$blobStorage = "DefaultEndpointsProtocol=https;AccountName=pcsstoragestaging;AccountKey=J0BM8/oR7BZNGTdsY3eo7BasJmRCQt4EeH60RS8u1XgDrAvCpMfLgNW6QNjD52ZZjmd+IuW+FryUHMwRmP2QyA==;EndpointSuffix=core.windows.net"
$blobStorageEuContainer = "pcseuprod"
$blobStorageUkContainer = "pcsukprod"

function Tranform{
    param(
        [string]$path,
        [bool]$isWeb
    )

    $appsettings = Get-Content $path -Raw | ConvertFrom-Json

    $appsettings.ConnectionStrings.PcsDatabase = $ConnectionString

    if($isWeb){
        $appsettings.JsReportingService.Url = $JsReportUrl
        $appsettings.JsReportingService.User = $JsReportUser
        $appsettings.JsReportingService.Password = $JsReportPassword
		
		$appsettings.AppSettings.EmailCCRecipients = $EmailCCRecipients
		$appsettings.AppSettings.Secret = $ApiSecret
		$appsettings.AppSettings.Username = $ApiUsername
		$appsettings.AppSettings.Password = $ApiPassword

        $appsettings.AppSettings.BlobStorageConfig.EuContainer = $blobStorageEuContainer
        $appsettings.AppSettings.BlobStorageConfig.UkContainer = $blobStorageUkContainer

        $appsettings.ConnectionStrings.BlobStorage = $blobStorage
    }
	
	
    $result = ConvertTo-Json $appsettings -Depth 20
    $transformed = [System.Text.RegularExpressions.Regex]::Unescape($result)
    Set-Content $path $transformed
}

Tranform -path $pathToAppSettings -isWeb $true
Tranform -path $pathToChasingEmailSettings -isWeb $false
Tranform -path $pathToInvoiceGenerationSettings -isWeb $false
Tranform -path $pathToDailyTasksSettings -isWeb $false
Tranform -path $pathToCloseDealNotificationSettings -isWeb $false
Tranform -path $pathToDailyExpectedClosingDateSettings -isWeb $false
Tranform -path $pathToWeeklyAnalystReportSettings -isWeb $false
Tranform -path $pathToDailyTasksCreationSettings -isWeb $false
Tranform -path $pathToEventParticipationSettings -isWeb $false

# Transforming only url
$appsettings = Get-Content $pathToKeepAwakeJsReporting -Raw | ConvertFrom-Json
$appsettings.Url = $JsReportUrl
$result = ConvertTo-Json $appsettings -Depth 20
$transformed = [System.Text.RegularExpressions.Regex]::Unescape($result)
Set-Content $pathToKeepAwakeJsReporting $transformed