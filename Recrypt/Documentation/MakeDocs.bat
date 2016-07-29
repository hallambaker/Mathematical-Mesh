setlocal
cd %~dp0

echo Convert documents to TXT, XML and HTML formats

echo Web App
rfctool O:\Documents\Mesh\hallambaker-meshrecrypt.docx ^
	/html Publish\hallambaker-meshrecrypt.html ^
	/xml Publish\hallambaker-meshrecrypt.xml ^
	/txt Publish\hallambaker-meshrecrypt.txt


exit /b 0