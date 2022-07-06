$webPath = "C:\inetpub\wwwroot\"
$acl = Get-Acl $webPath
$ar = New-Object System.Security.AccessControl.FileSystemAccessRule("Everyone", "FullControl", "ContainerInherit,ObjectInherit", "None", "Allow")
$acl.SetAccessRule($ar)
Set-Acl $webPath $acl
