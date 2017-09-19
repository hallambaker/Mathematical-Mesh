setlocal
cd %~dp0

echo Delete old copies of intermediate and output files.


del Generated /q
del Publish /q

echo Create reference material from protocol definition files

protogen ..\Goedel.Recrypt\SchemaRecryptAdmin.Protocol /md Generated\SchemaRecryptAdmin.md

echo Generate documents.

rfctool O:\Documents\IETF\hallambaker_recrypt.docx ^
	/html Publish\hallambaker_recrypt.html ^
	/txt Publish\hallambaker_recrypt.txt ^
	/xml Publish\hallambaker_recrypt.xml

exit /b 0