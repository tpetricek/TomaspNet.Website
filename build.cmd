@echo off
cls

.paket\paket.bootstrapper.exe
if errorlevel 1 (
  exit /b %errorlevel%
)

.paket\paket.exe restore
if errorlevel 1 (
  exit /b %errorlevel%
)

cd source\blog\packages\2015
..\..\..\..\.paket\paket.exe restore
if errorlevel 1 (
  exit /b %errorlevel%
)
cd ..\..\..\..\

packages\FAKE\tools\FAKE.exe build.fsx %*
