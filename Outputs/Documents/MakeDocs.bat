setlocal
cd %~dp0
set Root=../../..
set DocSource=../Word
set DocSource=O:\Documents\Mesh

echo Generate schemas etc.
cd Generated 

protogen %Root%/Libraries/Goedel.Cryptography.Dare/DareSchema.protocol /md
protogen %Root%/Libraries/Goedel.Cryptography.Dare/ContainerEntry.pschema /md
protogen %Root%/Mesh/Goedel.Mesh/SchemaMesh.protocol /md
protogen %Root%/Mesh/Goedel.Mesh/ProtocolSchema.protocol /md
protogen %Root%/Mesh/Goedel.Mesh.Services/ServiceSchema.protocol /md
protogen %Root%/Mesh/Goedel.Mesh.Presence/PresenceSchema.protocol /md

QRCoderConsole -i="..\Examples\UDFDigestEARL-raw.md" -f=svg -o=UDFDigestEARLRAW.svg
QRCoderConsole -i="..\Examples\UDFDigestEARL-raw.md" -f=png -o=UDFDigestEARLRAW.png

cd ..\Publish
echo Convert documents to TXT, XML and HTML formats

copy ..\xml2rfc.css .
copy ..\xml2rfc.js .
copy ..\bib.xml .
copy ..\favicon.png .

rfctool %DocSource%\hallambaker-threshold.docx  /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-threshold-signature.docx  /auto /cache=bib.xml

rfctool %DocSource%\hallambaker-mesh-1-architecture.docx  /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-2-udf.docx /auto /cache=bib.xml

rfctool %DocSource%\hallambaker-mesh-3-dare.docx /auto /cache=bib.xml

rfctool %DocSource%\hallambaker-mesh-4-schema.docx  /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-5-protocol.docx  /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-6-trust.docx  /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-7-security.docx  /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-8-cryptography.docx  /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-9-constrained.docx  /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-10-quantum.docx  /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-11-services.docx  /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-12-presence.docx  /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-13-ceremony.docx  /auto /cache=bib.xml


rfctool %DocSource%\hallambaker-jsonbcd.docx /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-developer.docx  /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-platform.docx  /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-web-service-discovery.docx /auto /cache=bib.xml

exit /b 0

