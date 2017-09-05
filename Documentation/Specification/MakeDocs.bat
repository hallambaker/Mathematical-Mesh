setlocal
cd %~dp0


echo Generate schemas etc.
cd Generated 

protogen ../../../Goedel.Mesh/SchemaMail.protocol /md
protogen ../../../Goedel.Mesh/SchemaMesh.protocol /md
protogen ../../../Goedel.Mesh/SchemaNetwork.protocol /md
protogen ../../../Goedel.Mesh/SchemaWeb.protocol /md
protogen ../../../Goedel.Mesh/SchemaSSH.protocol /md
protogen ../../../Goedel.Mesh.Platform/Serialization.protocol /md
protogen ../../../Goedel.Mesh.Server/MeshProtocol.protocol /md


cd ..\Publish
echo Convert documents to TXT, XML and HTML formats

copy ..\xml2rfc.css .
copy ..\bib.xml .
"
echo sin
rfctool O:\Documents\Mesh\hallambaker-sin.docx /html /xml /txt /cache=bib.xml

echo sin
rfctool O:\Documents\Mesh\hallambaker-jsonbcd.docx /html /xml /txt /cache=bib.xml

echo udf
rfctool O:\Documents\Mesh\hallambaker-udf.docx /html /xml /txt /cache=bib.xml

echo json web service
rfctool O:\Documents\Mesh\hallambaker-json-web-service.docx  /html /xml /txt /cache=bib.xml



echo Web App
rfctool O:\Documents\Mesh\hallambaker-mesh-app-web.docx  /html /xml /txt /cache=bib.xml

echo ssh
rfctool O:\Documents\Mesh\hallambaker-mesh-app-ssh.docx  /html /xml /txt /cache=bib.xml



echo Platform
rfctool O:\Documents\Mesh\hallambaker-mesh-platform.docx  /html /xml /txt /cache=bib.xml

echo architecture
rfctool O:\Documents\Mesh\hallambaker-mesh-architecture.docx  /html /xml /txt /cache=bib.xml

echo developer
rfctool O:\Documents\Mesh\hallambaker-mesh-developer.docx  /html /xml /txt /cache=bib.xml

echo reference
rfctool O:\Documents\Mesh\hallambaker-mesh-reference.docx  /html /xml /txt /cache=bib.xml



exit /b 0

