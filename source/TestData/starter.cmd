@echo off
pushd %~dp0
  echo "%CD%\bin\Relase\TestData.exe" %1
  "%CD%\bin\Relase\TestData.exe" %1
popd
pause
