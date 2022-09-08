echo off

set tmpFile=c:\temp\tempx.txt

set /p prevDays=Enter Number of Days previous:
set /a daysDefault=1
IF "%prevDays%" EQU "" SET /a prevDays=%daysDefault%
IF "%prevDays%" EQU "0" SET /a prevDays=%daysDefault%
set /a prevDays=%prevDays%



set datestr=%date%
set datestr=%datestr:/=%
Set _yyyy=%datestr:~4,4%
Set _mm=%datestr:~2,2%
Set _dd=%datestr:~0,2%

SET _dd_A=%_dd:~0,1%
set PRFX=1
if "%_dd_A%" EQU "0" ( Set PRFX=0 )

if "%_dd_A%" EQU "0" ( Set _dd=%_dd:~1,1% )

set /a _dd=%_dd%
Set /a _dd=%_dd%-%prevDays%

SET dayStr=00

SET RTRN=1
GOTO CALCdayStr
:CALCdayStr_END_1

set mthStr=%_mm%

set datestr=%_yyyy%%mthStr%%dayStr%

set /a loopCount=0
:CHECKAGAIN
if not exist "%~dp0notes.%datestr%.TXT" GOTO SUBSTRCTDAY
if exist "%~dp0notes.%datestr%.TXT" ( start notepad.exe %~dp0notes.%datestr%.TXT )

EXIT

:SUBSTRCTDAY
set /a _dd=%_dd%-1

SET RTRN=2
GOTO CALCdayStr
:CALCdayStr_END_2
				
set lgthChk=%dayStr%
CALL :CHECKLNGTH
set dayStr=%lgthChk%
				
if %_mm% leq 0 (
				set /a _mm=12
				set /a _yyyy=%_yyyy%-1
				)

set mthStr=%_mm%
set lgthChk=%mthStr%
CALL :CHECKLNGTH
set mthStr=%lgthChk%


set datestr=%_yyyy%%mthStr%%dayStr%
echo datestr;%datestr%

if %loopCount% GEQ 60 exit

set /a loopCount=%loopCount%+1
GOTO CHECKAGAIN


:CHECKLNGTH
echo "%lgthChk%">%tmpFile%
FOR %%? IN (%tmpFile%) DO ( SET /A strLen=%%~z? - 2 )
if exist %tmpFile% del /q %tmpFile%				
if %strLen% LSS 4 (set lgthChk=0%lgthChk%)
GOTO:EOF


:CALCdayStr
if %_dd% LEQ 0 (
				set /a _dd=31
				set /a _mm=%_mm%-1
				)

if %_dd% GEQ -10 ( set PRFX=1 )
set dayStr=%_dd%
if "%PRFX%" EQU "0" ( set dayStr=%PRFX%%_dd% )
IF %RTRN% EQU 1 ( GOTO CALCdayStr_END_1 )
IF %RTRN% EQU 2 ( GOTO CALCdayStr_END_2 )