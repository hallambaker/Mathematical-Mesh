setlocal
cd %~dp0

ProtoGen MeshProtocol.Protocol /html ../Documentation/MeshProtocol.html /cs MeshProtocol.cs 

exit /b 0