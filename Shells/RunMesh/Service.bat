setlocal
cd %~dp0
cd ..\Documentation

rfctool mathematical-mesh-protocols.docx /md /txt /xml /html

exit /b 0