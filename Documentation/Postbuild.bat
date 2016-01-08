setlocal
cd %~dp0

echo Convert documents to TXT, XML and HTML formats

echo architecture
rfctool O:\Documents\IETF\mathematical-mesh-architecture.docx ^
	/html Publish\mathematical-mesh-architecture.html ^
	/xml Publish\mathematical-mesh-architecture.xml ^
	/txt Publish\mathematical-mesh-architecture.txt

echo implementation
rfctool O:\Documents\IETF\mathematical-mesh-implementation.docx ^
	/html Publish\mathematical-mesh-implementation.html ^
	/xml Publish\mathematical-mesh-implementation.xml ^
	/txt Publish\mathematical-mesh-implementation.txt

echo profiles
rfctool O:\Documents\IETF\mathematical-mesh-profiles.docx ^
	/html Publish\mathematical-mesh-profiles.html ^
	/xml Publish\mathematical-mesh-profiles.xml ^
	/txt Publish\mathematical-mesh-profiles.txt

echo portal protocol
rfctool O:\Documents\IETF\mathematical-mesh-protocol-csp.docx ^
	/html Publish\mathematical-mesh-protocol-csp.html ^
	/xml Publish\mathematical-mesh-protocol-csp.xml ^
	/txt Publish\mathematical-mesh-protocol-csp.txt

echo udf
rfctool O:\Documents\IETF\hallambaker-udf.docx ^
	/html Publish\hallambaker-udf.html ^
	/xml Publish\hallambaker-udf.xml ^
	/txt Publish\hallambaker-udf.txt

exit /b 0