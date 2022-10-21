setlocal
cd %~dp0
set Root=../../..
set DocSource=../Word

::Set DocSource=C:\Users\hallam\OneDrive\Documents

echo Generate schemas etc.
cd Generated 

protogen ../../../Mesh/Goedel.Mesh/SchemaMesh.protocol  /md  SchemaMesh.md
protogen ../../../Mesh/Goedel.Mesh/ProtocolSchema.protocol  /md  ProtocolSchema.md
protogen ../../../Mesh/Goedel.Mesh.Client/HostSchema.protocol  /md  HostSchema.md
protogen ../../../Mesh/Goedel.Mesh.Server/MasterCatalog.protocol  /md  MasterCatalog.md
protogen ../../../Everything/Goedel.Mesh.Everything/EverythingFeed.protocol  /md  EverythingFeed.md
protogen ../../../Callsign/Goedel.Callsign/CallsignLog.protocol  /md  CallsignLog.md
protogen ../../../Callsign/Goedel.Callsign.Registry/CallsignRegistry.protocol  /md  CallsignRegistry.md
protogen ../../../Callsign/Goedel.Callsign.Resolver/CallsignResolver.protocol  /md  CallsignResolver.md
protogen ../../../Carnet/Goedel.Carnet/Carnet.protocol  /md  Carnet.md
protogen ../../../Libraries/Goedel.Cryptography.Dare/DareSchema.protocol  /md  DareSchema.md
protogen ../../../Libraries/Goedel.Cryptography.Jose/JoseSchema.protocol  /md  JoseSchema.md
protogen ../../../Mesh/Goedel.Mesh.Management/StatusSchema.protocol  /md  StatusSchema.md
protogen ../../../Mesh/Goedel.Mesh.Presence/PresenceSchema.protocol  /md  PresenceSchema.md

constant %Root%/Libraries/Goedel.Cryptography/UDFConstants.constant /md
constant %Root%/Mesh/Goedel.Mesh/MeshConstants.constant /md


QRCoderConsole -i="..\Examples\ArchitectureConnectEARL-raw.md" -f=svg -o=UDFConnectEARLRAW.svg -s=7
QRCoderConsole -i="..\Examples\ArchitectureConnectEARL-raw.md" -f=png -o=UDFConnectEARLRAW.png

QRCoderConsole -i="..\Examples\UDFDigestEARL-raw.md" -f=svg -o=UDFDigestEARLRAW.svg -s=7
QRCoderConsole -i="..\Examples\UDFDigestEARL-raw.md" -f=png -o=UDFDigestEARLRAW.png

cd ..\Publish
echo Convert documents to TXT, XML and HTML formats

copy ..\xml2rfc.css .
copy ..\xml2rfc.js .
copy ..\bib.xml .
copy ..\favicon.png .

rfctool %DocSource%\hallambaker-mesh-1-architecture.docx  /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-2-udf.docx  /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-3-dare.docx /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-4-schema.docx /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-5-protocol.docx  /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-6-rud.docx  /auto /cache=bib.xml
:: Callsign is 7
rfctool %DocSource%\hallambaker-mesh-7-callsign.docx /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-8-cryptography.docx /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-9-notarization.docx /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-10-everything.docx  /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-11-presence.docx /auto /cache=bib.xml



:: Presence is 11
:: Repository is 12

:: Additional documents

rfctool %DocSource%\hallambaker-jsonbcd.docx /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-web-service-discovery.docx /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-threshold.docx /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-developer.docx /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-platform.docx /auto /cache=bib.xml


exit /b 0
