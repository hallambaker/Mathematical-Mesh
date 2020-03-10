
setlocal
cd %~dp0
set Root=../../..
set DocSource=O:\Documents\Mesh

cd Generated 

protogen %Root%/Protocols/Confirm/Goedel.Confirm/SchemaConfirm.protocol /md
protogen %Root%/Protocols/Account/Goedel.Account/SchemaAccount.protocol /md
protogen %Root%/Protocols/Recrypt/Goedel.Recrypt/SchemaRecrypt.protocol /md

cd ..\Publish
copy ..\bib.xml .
copy ..\xml2rfc.css .
copy ..\favicon.png .

rfctool ../ToDo.md /txt /xml /html  /cache=bib.xml
rfctool %DocSource%/hallambaker-mesh-account.docx /auto  /cache=bib.xml
rfctool %DocSource%/hallambaker-mesh-confirm.docx /auto  /cache=bib.xml
rfctool %DocSource%/hallambaker-mesh-recrypt.docx /auto  /cache=bib.xml

