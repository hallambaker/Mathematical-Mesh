
# Supplemental Makefile for Visual Studios Projects
#
# Visual Studio is responsible for managing rules for production of
# code but does not provide support for pre and post build actions.
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
	SchemaCatalogApps.cs\
	SchemaMesh.cs

Exceptions.cs : Exceptions.Exceptional 
	exceptional Exceptions.Exceptional  /cs  Exceptions.cs

Portal.cs : Portal.Protocol 
	protogen Portal.Protocol  /cs  Portal.cs

SchemaAppMail.cs : SchemaAppMail.protocol 
	protogen SchemaAppMail.protocol  /cs  SchemaAppMail.cs

SchemaAppSSH.cs : SchemaAppSSH.protocol 
	protogen SchemaAppSSH.protocol  /cs  SchemaAppSSH.cs

SchemaCatalogApps.cs : SchemaCatalogApps.protocol 
	protogen SchemaCatalogApps.protocol  /cs  SchemaCatalogApps.cs

SchemaMesh.cs : SchemaMesh.protocol 
	protogen SchemaMesh.protocol  /cs  SchemaMesh.cs


prebuildRecurse : 


postbuildRecurse :


prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Mesh.dll

