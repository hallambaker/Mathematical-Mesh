setlocal
cd %~dp0
cd ..\Documentation

servermesh /start mathmesh.com host1.mathmesh.com /nomulti

exit /b 0