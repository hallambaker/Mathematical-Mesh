setlocal
cd %~dp0

echo Delete old copies of intermediate and output files.

del Examples /q
del Generated /q
del Publish /q

echo Generate new examples.

ExampleGenerator Examples/Examples.md Examples/ExamplesWeb.md

exit /b 0