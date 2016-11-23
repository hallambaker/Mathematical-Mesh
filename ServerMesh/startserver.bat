setlocal
cd %~dp0
cd ..\Documentation

servermesh /start prismproof.org host1.prismproof.org /nomulti

exit /b 0