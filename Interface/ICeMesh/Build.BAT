@echo off
rem
rem Register.bat
rem
echo on
cl /LD MESH.cpp REGISTRY.CPP GUIDs.cpp UUID.lib Ole32.lib Advapi32.lib MESH.def
regsvr32 -s MESH.dll