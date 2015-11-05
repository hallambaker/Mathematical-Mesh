SETLOCAL
@echo "Current Directory %cd%"
@echo "Batch file is in %~dp0"

cd %~dp0

CommandParse ServerCommands.cmd /cs ServerCommands.cs /nocatch

exit /b 0


