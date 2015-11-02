echo Make script file
SETLOCAL

cd %~dp0


gschema3 Configure.gdl /cs Configure.cs /lazy
exit /b 0
