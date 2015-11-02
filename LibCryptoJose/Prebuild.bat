SETLOCAL
@echo "Current Directory %cd%"
@echo "Batch file is in %~dp0"

cd %~dp0

ProtoGen JoseSchema.Protocol /xml JoseSchema.xml /cs JoseSchema.cs  /lazy


exit /b 0


