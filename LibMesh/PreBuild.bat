setlocal
cd %~dp0

ProtoGen MeshSchema.Protocol /md ../Documentation/MeshSchema.md /cs MeshSchema.cs 
ProtoGen Portal.Protocol /md ../Documentation/PortalProtocol.md /cs PortalProtocol.cs 
exit /b 0