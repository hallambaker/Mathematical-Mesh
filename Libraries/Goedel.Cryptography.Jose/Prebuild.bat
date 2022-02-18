SETLOCAL
@echo "Current Directory %cd%"
@echo "Batch file is in %~dp0"

cd %~dp0

exceptional exceptions.exceptional /cs

protogen JoseSchema.protocol /cs

exit /b 0