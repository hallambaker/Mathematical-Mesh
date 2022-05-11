
# Supplemental Makefile for Visual Studios Projects
#
# Visual Studio runs tools for most projects but not for shared projects.
# 
# Prebuild items supported:
#   [None currently]
# 
# PostBuild items supported:
#   * Copy library to locations on disk
#   * Build ilMerge executables
#   * Postprocess VSIX projects
#   * Copy executables


.PHONY : all always clean install publish prebuild prebuildRecurse postbuild postbuildRecurse

MSBuildThisFileDirectory = 

LinkFiles = \
    Goedel.Cryptography.KeyFile.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.Dare.dll\
    Goedel.Cryptography.dll\
    Goedel.Protocol.Presentation.dll

ToolTargets = \
	Exceptions.cs\
	ProtocolSchema.cs\
	MeshConstants.cs\
	SchemaMesh.cs
Exceptions.cs : Exceptions.exceptional 
	exceptional Exceptions.exceptional  /cs  Exceptions.cs

ProtocolSchema.cs : ProtocolSchema.Protocol 
	protogen ProtocolSchema.Protocol  /cs  ProtocolSchema.cs

MeshConstants.cs : MeshConstants.Constant 
	constant MeshConstants.Constant  /cs  MeshConstants.cs

SchemaMesh.cs : SchemaMesh.protocol 
	protogen SchemaMesh.protocol  /cs  SchemaMesh.cs



prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)
	

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Mesh.dll

