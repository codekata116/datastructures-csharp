@echo off

cd ..
.\packages\NAnt.Portable.0.92\NAnt.exe all

start _testoutput\index.htm

pause
