setlocal
cd %~dp0

echo Delete old copies of intermediate and output files.

del Examples /q
del Generated /q
del Publish /q


exit /b 0