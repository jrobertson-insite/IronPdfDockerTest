# IronPdfDockerTest

IronPDF issues in Windows ServerCore based docker images.

Replication steps:
* clone repo
* setup docker to build/run Windows containers
* docker build -t ironpdftest .
* docker run --rm -p 8010:80 --name=ironpdftest ironpdftest
* Go to browser, hit 127.0.0.1:8010
* In another terminal
  * docker exec -it ironpdftest powershell
  * cat c:\temp\Default.log

Results:
* ASP.net exception
```
Error while deploying Chrome dependencies.

To learn how to solve this issue please read https://iron.helpscoutdocs.com/article/166-error-while-deploying-chrome-dependencies  [Issue Code IRONPDF-CHROME-DEPLOYMENT-ERROR]
```
* IronPDF Logs @ c:\temp\Default.log
```
[2022-07-06 09:48:56] ---------- Windows v10.0.17763.0 (C:\temp\Default.log) ----------
[2022-07-06 09:48:56] Using base deployment directory of [Installation.CustomDeploymentDirectory] 'C:\inetpub\wwwroot\bin'
[2022-07-06 09:48:56] Attempting deployment for 'Chrome' v2022.5.0.5590 using 'C:\inetpub\wwwroot\bin\runtimes\win-x64\native'
[2022-07-06 09:48:56] Successfully located 'IronInterop' at 'C:\inetpub\wwwroot\bin\runtimes\win-x64\native'
[2022-07-06 09:48:56] Determining deployment commands for platform 'Windows' v10.0.17763.0
[2022-07-06 09:48:56] Using deployment instructions for 'default' v
[2022-07-06 09:48:56] Attempting to load Windows library 'C:\inetpub\wwwroot\bin\runtimes\win-x64\native\chrome_elf.dll'
[2022-07-06 09:48:56] Successfully loaded chrome_elf from the file: C:\inetpub\wwwroot\bin\runtimes\win-x64\native\chrome_elf.dll
[2022-07-06 09:48:56] Attempting to load Windows library 'C:\inetpub\wwwroot\bin\runtimes\win-x64\native\libcef.dll'
[2022-07-06 09:48:57] Attempting to load Windows library 'C:\inetpub\wwwroot\bin\runtimes\win-x64\native\libcef.dll'
[2022-07-06 09:48:57] Invalid deployment 'C:\inetpub\wwwroot\bin\runtimes\win-x64\native'
[2022-07-06 09:48:57] System.Exception: Error while loading 'C:\inetpub\wwwroot\bin\runtimes\win-x64\native\libcef.dll' (126):
   at NativeLibraryLoader.LibraryLoader.LoadNativeLibrary(String name, PathResolver pathResolver)
   at NativeLibraryLoader.NativeLibrary..ctor(String name, LibraryLoader loader, PathResolver pathResolver)
   at .(String , String )
   at IronPdf.Deployment.ChromeDeployment.LoadAssemblies(String path)
   at IronPdf.Deployment.SmartDeploymentBase.Deploy()
[2022-07-06 09:48:57] Attempting deployment for 'Chrome' v2022.5.0.5590 using 'C:\inetpub\wwwroot\bin\runtimes\win-x64\native'
[2022-07-06 09:48:57] Successfully located 'IronInterop' at 'C:\inetpub\wwwroot\bin\runtimes\win-x64\native'
[2022-07-06 09:48:57] Determining deployment commands for platform 'Windows' v10.0.17763.0
[2022-07-06 09:48:57] Using deployment instructions for 'default' v
[2022-07-06 09:48:57] Attempting to load Windows library 'C:\inetpub\wwwroot\bin\runtimes\win-x64\native\chrome_elf.dll'
[2022-07-06 09:48:57] Successfully loaded chrome_elf from the file: C:\inetpub\wwwroot\bin\runtimes\win-x64\native\chrome_elf.dll
[2022-07-06 09:48:57] Attempting to load Windows library 'C:\inetpub\wwwroot\bin\runtimes\win-x64\native\libcef.dll'
[2022-07-06 09:48:57] Attempting to load Windows library 'C:\inetpub\wwwroot\bin\runtimes\win-x64\native\libcef.dll'
[2022-07-06 09:48:57] Invalid deployment 'C:\inetpub\wwwroot\bin\runtimes\win-x64\native'
[2022-07-06 09:48:57] System.Exception: Error while loading 'C:\inetpub\wwwroot\bin\runtimes\win-x64\native\libcef.dll' (126):
   at NativeLibraryLoader.LibraryLoader.LoadNativeLibrary(String name, PathResolver pathResolver)
   at NativeLibraryLoader.NativeLibrary..ctor(String name, LibraryLoader loader, PathResolver pathResolver)
   at .(String , String )
   at IronPdf.Deployment.ChromeDeployment.LoadAssemblies(String path)
   at IronPdf.Deployment.SmartDeploymentBase.Deploy()
[2022-07-06 09:48:57] Attempting deployment for 'Chrome' v2022.5.0.5590 using 'C:\inetpub\wwwroot\bin'
[2022-07-06 09:48:57] Failed to locate 'IronInterop' at 'C:\inetpub\wwwroot\bin'
[2022-07-06 09:48:57] Attempting deployment for 'Chrome' v2022.5.0.5590 using 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Temporary ASP.NET Files\root\e22c2559\92c7e946\assembly\dl3\c2a146b3\008f9426_ba5dd801'
[2022-07-06 09:48:57] Failed to locate 'IronInterop' at 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Temporary ASP.NET Files\root\e22c2559\92c7e946\assembly\dl3\c2a146b3\008f9426_ba5dd801'
[2022-07-06 09:48:57] Attempting deployment for 'Chrome' v2022.5.0.5590 using 'NuGet packages (IronPdf.Native.Chrome.Windows(2022.5.5590)) with folder 'C:\inetpub\wwwroot\bin''
[2022-07-06 09:48:57] Attempting NuGet package 'IronPdf.Native.Chrome' deployment using 'IronPdf.Native.Chrome.Windows(2022.5.5590)'
[2022-07-06 09:48:57] Downloading NuGet package from 'https://www.nuget.org/api/v2/package/IronPdf.Native.Chrome.Windows/2022.5.5590'
```
