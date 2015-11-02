setlocal
cd %~dp0

ProtoGen Schema.Protocol /html ../Documentation/Schema.html /cs Schema.cs 

exit /b 0