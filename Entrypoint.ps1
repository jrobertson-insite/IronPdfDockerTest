& "$PSScriptRoot\SetPermissions.ps1"
$appLogPath = "C:\inetpub\wwwroot\App_Log"
if (-Not (Test-Path $appLogPath)) {
    New-Item -Type Directory $appLogPath
}

C:\ServiceMonitor.exe w3svc
