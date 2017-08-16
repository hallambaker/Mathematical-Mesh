setlocal
cd %~dp0


echo Generate schemas etc.
cd Generated 

protogen ../../Goedel.Mesh/SchemaConfirm.protocol /md
protogen ../../Goedel.Mesh/SchemaMail.protocol /md
protogen ../../Goedel.Mesh/SchemaMesh.protocol /md
protogen ../../Goedel.Mesh/SchemaNetwork.protocol /md
protogen ../../Goedel.Mesh/SchemaPassword.protocol /md
protogen ../../Goedel.Mesh/SchemaSSH.protocol /md
protogen ../../Goedel.Mesh/SchemaRecrypt.protocol /md
protogen ../../Goedel.Mesh.Platform/Serialization.protocol /md
protogen ../../Goedel.Mesh.Server/MeshProtocol.protocol /md

echo Convert documents to TXT, XML and HTML formats
cd ..\Publish

echo sin
rfctool O:\Documents\Mesh\hallambaker-sin.docx /html /xml /txt


echo jsonbcd
rfctool O:\Documents\IETF\hallambaker-jsonbcd.docx /html /xml /txt

echo udf
rfctool O:\Documents\Mesh\hallambaker-udf.docx /html /xml /txt

echo Web App
rfctool O:\Documents\Mesh\hallambaker-mesh-app-web.docx /html /xml /txt

echo Platform
rfctool O:\Documents\Mesh\hallambaker-mesh-platform.docx /html /xml /txt

echo architecture
rfctool O:\Documents\Mesh\hallambaker-mesh-architecture.docx /html /xml /txt

echo developer
rfctool O:\Documents\Mesh\hallambaker-mesh-developer.docx /html /xml /txt

echo reference
rfctool O:\Documents\Mesh\hallambaker-mesh-reference.docx /html /xml /txt

echo JSON Web Service 
rfctool O:\Documents\Mesh\hallambaker-json-web-service.docx /html /xml /txt

exit /b 0