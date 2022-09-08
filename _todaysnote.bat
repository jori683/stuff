echo off

set datestr=%date%
set datestr=%datestr:/=%

Set _yyyy=%datestr:~4,4%
Set _mm=%datestr:~2,2%
Set _dd=%datestr:~0,2%

set datestr=%_yyyy%%_mm%%_dd%


echo ¬ >> "%~dp0notes.%datestr%.TXT"

start notepad.exe %~dp0notes.%datestr%.TXT