@echo off
cd /d %~dp0

set compilerPath="C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe"
set references=lib\System.Data.SQLite.dll
set outputName=Babyfoot.exe

@REM debug -> display the line that contains an exception otherwise it won't
@REM /r means required
csc /debug /out:%outputName% /r:System.Data.SQLite.dll connection\*.cs model\*cs window\*cs *.cs

echo Compilation complete.
%outputName%
pause