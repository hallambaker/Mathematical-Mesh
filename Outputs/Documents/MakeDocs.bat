setlocal
cd %~dp0
set Root=../../..
set DocSource=../Word

::Set DocSource=C:\Users\hallam\OneDrive\Documents

echo Generate schemas etc.
cd Generated 


constant %Root%/Libraries/Goedel.Cryptography/UDFConstants.constant /md
constant %Root%/Mesh/Goedel.Mesh/MeshConstants.constant /md


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
rfctool %DocSource%\hallambaker-mesh-8-cryptography.docx /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-9-security.docx /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-10-trust.docx /auto /cache=bib.xml
:: Presence is 11
:: Repository is 12

:: Additional documents

rfctool %DocSource%\hallambaker-jsonbcd.docx /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-web-service-discovery.docx /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-threshold.docx /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-developer.docx /auto /cache=bib.xml
rfctool %DocSource%\hallambaker-mesh-platform.docx /auto /cache=bib.xml


exit /b 0
