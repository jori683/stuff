date1 = date 
pth = replace(wscript.scriptfullname,wscript.scriptname,"")
fn = pth & "notes." & year(date1) & right("0" & month(date1),2) & right("0" & day(date1),2) & ".txt"
set fso = createobject("Scripting.FileSystemObject")
if not fso.fileexists(fn) then
	fso.createtextfile fn, false
end if
set objshell = createobject("shell.application")
objshell.shellexecute fn, "", "", "open", 1