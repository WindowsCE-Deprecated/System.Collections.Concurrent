@echo off

set SolutionDir=%~dp0
set SolutionName=ConcurrentCollections
set Project=System.Collections.Concurrent
set ProjectDotNet=src\%Project%.WindowsCE

REM Cleanup output directory
rmdir /s/q "%SolutionDir%Output" 2> nul
mkdir "%SolutionDir%Output"

CALL %SolutionDir%tools\build-dotnet.bat %SolutionDir% %ProjectDotNet% net35-cf || EXIT /B 1
CALL %SolutionDir%tools\build-dotnet.bat %SolutionDir% %ProjectDotNet% net35-client || EXIT /B 1

REM CALL %SolutionDir%tools\sign-resources.cmd %Project% true %Project%.WindowsCE || EXIT /B 1

echo build complete.
echo.
EXIT /B %ERRORLEVEL%
