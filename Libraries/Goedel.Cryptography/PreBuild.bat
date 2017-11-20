SETLOCAL
@echo "Current Directory %cd%"
@echo "Batch file is in %~dp0"

cd %~dp0

exceptional exceptions.exceptional /cs

cd PKIX
asn2 PKIX.asn2 /cs
cd ..

exit /b 0