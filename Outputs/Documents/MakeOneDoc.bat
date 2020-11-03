setlocal
cd %~dp0
set Root=../../..
set DocSource=../Word



echo Generate schemas etc.
cd Generated 

QRCoderConsole -i="..\Examples\UDFDigestEARL-raw.md" -f=svg -o=UDFDigestEARLRAW.svg
QRCoderConsole -i="..\Examples\UDFDigestEARL-raw.md" -f=png -o=UDFDigestEARLRAW.png

cd ..\Publish
echo Convert documents to TXT, XML and HTML formats

copy ..\xml2rfc.css .
copy ..\xml2rfc.js .
copy ..\bib.xml .
copy ..\favicon.png .
rfctool %DocSource%\hallambaker-mesh-3-dare.docx /auto /cache=bib.xml
exit /b 0

