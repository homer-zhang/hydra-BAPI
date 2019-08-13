@echo off
REM ------------------------------------------------------------
REM hysys.bat Wechseln des Systems
REM ------------------------------------------------------------
REM $Log: hysys.bat $
REM Revision 1.1  2002/08/05 08:34:50  nas
REM Initial revision
REM ------------------------------------------------------------
if "%1" == "" goto error
goto start

:error
echo usage: hysys.bat system
goto end

:start
setlocal enabledelayedexpansion
set parm=%2
if "!parm!" == "" goto sys
goto run

:sys
hycmd.exe -S%1 cmd.exe /K hycmdsh.bat
goto end

:run
set hysystem=%1
set HYDRADIR=D:\hydra
set PATH=%HYDRADIR%;%PATH%

hymw.exe -u9999 -c!parm!
REM hymw.exe -u9999 -d -c!parm!
REM echo %2
REM Pause

goto end

:end
