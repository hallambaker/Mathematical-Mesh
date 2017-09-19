setlocal
cd %~dp0

echo Delete old copies of intermediate and output files.


del Generated /q
del Publish /q

echo Create reference material from protocol definition files

protogen ..\Goedel.Confirm\SchemaConfirm.Protocol /md Generated\SchemaConfirm.md

echo Generate documents.

rfctool O:\Documents\IETF\hallambaker_confirmation.docx ^
	/html Publish\hallambaker_confirmation.html ^
	/txt Publish\hallambaker_confirmation.txt ^
	/xml Publish\hallambaker_confirmation.xml

exit /b 0