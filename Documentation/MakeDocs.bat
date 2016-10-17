setlocal
cd %~dp0

echo Convert documents to TXT, XML and HTML formats

echo Web App
rfctool O:\Documents\Mesh\hallambaker-mesh-app-web.docx ^
	/html Publish\hallambaker-mesh-app-web.html ^
	/xml Publish\hallambaker-mesh-app-web.xml ^
	/txt Publish\hallambaker-mesh-app-web.txt

echo Platform
rfctool O:\Documents\Mesh\hallambaker-mesh-platform.docx ^
	/html Publish\hallambaker-mesh-platform.html ^
	/xml Publish\hallambaker-mesh-platform.xml ^
	/txt Publish\hallambaker-mesh-platform.txt

echo architecture
rfctool O:\Documents\Mesh\hallambaker-mesh-architecture.docx ^
	/html Publish\hallambaker-mesh-architecture.html ^
	/xml Publish\hallambaker-mesh-architecture.xml ^
	/txt Publish\hallambaker-mesh-architecture.txt

echo developer
rfctool O:\Documents\Mesh\hallambaker-mesh-developer.docx ^
	/html Publish\hallambaker-mesh-developer.html ^
	/xml Publish\hallambaker-mesh-developer.xml ^
	/txt Publish\hallambaker-mesh-developer.txt

echo reference
rfctool O:\Documents\Mesh\hallambaker-mesh-reference.docx ^
	/html Publish\hallambaker-mesh-reference.html ^
	/xml Publish\hallambaker-mesh-reference.xml ^
	/txt Publish\hallambaker-mesh-reference.txt

echo udf
rfctool O:\Documents\Mesh\hallambaker-udf.docx ^
	/html Publish\hallambaker-udf.html ^
	/xml Publish\hallambaker-udf.xml ^
	/txt Publish\hallambaker-udf.txt

echo json web service
rfctool O:\Documents\Mesh\hallambaker-json-web-service.docx ^
	/html Publish\hallambaker-json-web-service.html ^
	/xml Publish\hallambaker-json-web-service.xml ^
	/txt Publish\hallambaker-json-web-service.txt

echo ssh
rfctool O:\Documents\Mesh\hallambaker-mesh-app-ssh.docx ^
	/html Publish\hallambaker-mesh-app-ssh.html ^
	/xml Publish\hallambaker-mesh-app-ssh.xml ^
	/txt Publish\hallambaker-mesh-app-ssh.txt

exit /b 0