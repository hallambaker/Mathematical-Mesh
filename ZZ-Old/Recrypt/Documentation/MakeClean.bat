setlocal
cd %~dp0

echo Delete old copies of intermediate and output files.

del Examples /q
del Generated /q
del Publish /q

echo Create reference material from protocol definition files

protogen ..\Goedel.Recrypt\RecryptProtocol.Protocol /md Generated\Recrypt.md

exit /b 0