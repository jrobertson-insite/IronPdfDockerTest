# docker tag: registry.cloud.insitehq.net/commerce-windows/build-base
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8-windowsservercore-ltsc2019 as build

WORKDIR /app

COPY IronPdfDockerTest.sln IronPdfDockerTest.csproj packages.config ./
RUN nuget restore IronPdfDockerTest.sln

COPY . ./
RUN msbuild IronPdfDockerTest.sln /p:Configuration=Release

# docker tag registry.cloud.insitehq.net/commerce-windows/runtime-base
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019 as runtime

ENV chocolateyUseWindowsCompression 'false'
RUN ["powershell", "-Command", "[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12; [Net.ServicePointManager]::SecurityProtocol; iwr https://chocolatey.org/install.ps1 -UseBasicParsing | iex"]
RUN choco feature enable -n allowGlobalConfirmation; choco feature disable -n=showDownloadProgress
RUN #choco install vcredist140; choco install openssh

WORKDIR C:/LogMonitor
COPY ./LogMonitor/. ./

WORKDIR /inetpub/wwwroot
COPY --from=build /app/. ./

ENTRYPOINT C:/LogMonitor/LogMonitor.exe powershell -File Entrypoint.ps1
