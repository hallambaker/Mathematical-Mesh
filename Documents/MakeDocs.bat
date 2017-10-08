setlocal
cd %~dp0

echo Generate schemas etc.
cd Generated 

protogen ../../Mesh/Goedel.Mesh/SchemaMesh.protocol /md
protogen ../../Mesh/Goedel.Mesh/SchemaAppMail.protocol /md
protogen ../../Mesh/Goedel.Mesh/SchemaAppSSH.protocol /md
protogen ../../Mesh/Goedel.Mesh/SchemaCatalogApps.protocol /md
protogen ../../Mesh/Goedel.Mesh.Platform/Serialization.protocol /md
protogen ../../Mesh/Goedel.Mesh.Server/MeshProtocol.protocol /md


cd ..\Publish
echo Convert documents to TXT, XML and HTML formats

copy ..\xml2rfc.css .
copy ..\xml2rfc.js .
copy ..\bib.xml .
copy ..\favicon.png .

rfctool O:\Documents\Mesh\hallambaker-container.docx /auto /cache=bib.xml
rfctool O:\Documents\Mesh\hallambaker-sin.docx /auto /cache=bib.xml
rfctool O:\Documents\Mesh\hallambaker-jsonbcd.docx /auto /cache=bib.xml
rfctool O:\Documents\Mesh\hallambaker-udf.docx /auto /cache=bib.xml
rfctool O:\Documents\Mesh\hallambaker-json-web-service.docx  /auto /cache=bib.xml
rfctool O:\Documents\Mesh\hallambaker-mesh-applications.docx  /auto /cache=bib.xml
rfctool O:\Documents\Mesh\hallambaker-mesh-platform.docx  /auto /cache=bib.xml
rfctool O:\Documents\Mesh\hallambaker-mesh-architecture.docx  /auto /cache=bib.xml
rfctool O:\Documents\Mesh\hallambaker-mesh-developer.docx  /auto /cache=bib.xml
rfctool O:\Documents\Mesh\hallambaker-mesh-reference.docx  /auto /cache=bib.xml

exit /b 0

