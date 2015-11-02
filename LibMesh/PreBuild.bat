setlocal
cd %~dp0

ProtoGen MeshSchema.Protocol /html ../Documentation/MeshSchema.html /cs MeshSchema.cs 
ProtoGen Portal.Protocol /html ../Documentation/PortalProtocol.html /cs PortalProtocol.cs 
exit /b 0