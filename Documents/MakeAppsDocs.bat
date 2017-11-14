
setlocal
cd %~dp0

cd Generated 

protogen ../../Confirm/Goedel.Confirm/SchemaConfirm.protocol /md
protogen ../../Account/Goedel.Account/SchemaAccount.protocol /md
protogen ../../Recrypt/Goedel.Recrypt/SchemaRecrypt.protocol /md

cd ..\Publish
copy ..\bib.xml .
copy ..\xml2rfc.css .
copy ..\favicon.png .

rfctool ../ToDo.md /txt /xml /html  /cache=bib.xml
rfctool O:/Documents/Mesh/hallambaker-mesh-account.docx /auto  /cache=bib.xml
rfctool O:/Documents/Mesh/hallambaker-mesh-confirm.docx /auto  /cache=bib.xml
rfctool O:/Documents/Mesh/hallambaker-mesh-recrypt.docx /auto  /cache=bib.xml

