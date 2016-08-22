setlocal
cd %~dp0

echo Delete old copies of intermediate and output files.

del Examples /q
del Generated /q
del Publish /q

echo Create reference material from protocol definition files

protogen ..\Goedel.Mesh.Server\MeshProtocol.Protocol /md Generated\MeshProtocol.md
protogen ..\Goedel.Mesh\SchemaMesh.Protocol /md Generated\MeshSchema.md
protogen ..\Goedel.Mesh\Portal.Protocol /md Generated\Portal.md

exit /b 0