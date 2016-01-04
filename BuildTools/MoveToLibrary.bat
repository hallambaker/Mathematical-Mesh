@echo off
SETLOCAL
@echo "Current Directory %cd%"
@echo "Batch file is in %~dp0"

copy %1 %~dp0\Library

exit /b 0



