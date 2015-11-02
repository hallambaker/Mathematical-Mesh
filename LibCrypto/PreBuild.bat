SETLOCAL
@echo "Current Directory %cd%"
@echo "Batch file is in %~dp0"

cd %~dp0

ASN2Shell PKIX.asn2 /cs PKIX.cs

exit /b 0


