
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
    Goedel.ASN.dll\
    Goedel.IO.dll\
    Goedel.Registry.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.Jose.dll\
    Goedel.Cryptography.KeyFile.dll\
    Goedel.Cryptography.Standard.dll\
    Goedel.Cryptography.dll\
    Goedel.Persistence.dll\
    Goedel.Protocol.dll

ToolTargets = \
	Exceptions.cs\
	Portal.cs\
	SchemaAppMail.cs\
	SchemaAppSSH.cs\
	SchemaMesh.cs
Exceptions.cs : Exceptions.Exceptional 
	exceptional Exceptions.Exceptional  /cs  Exceptions.cs

Portal.cs : Portal.Protocol 
	protogen Portal.Protocol  /cs  Portal.cs

SchemaAppMail.cs : SchemaAppMail.protocol 
	protogen SchemaAppMail.protocol  /cs  SchemaAppMail.cs

SchemaAppSSH.cs : SchemaAppSSH.protocol 
	protogen SchemaAppSSH.protocol  /cs  SchemaAppSSH.cs

SchemaMesh.cs : SchemaMesh.protocol 
	protogen SchemaMesh.protocol  /cs  SchemaMesh.cs



prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Mesh.dll

