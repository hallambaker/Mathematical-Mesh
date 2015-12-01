setlocal
cd %~dp0

ProtoGen MeshProtocol.Protocol /md ../Documentation/MeshProtocol.md /cs MeshProtocol.cs 

exit /b 0