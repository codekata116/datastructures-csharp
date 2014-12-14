@echo off

cd ..
.\packages\NAnt.Portable.0.92\NAnt.exe test

start _testoutput\index.htm

pause
