
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
    Goedel.Discovery.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.Jose.dll\
    Goedel.Cryptography.dll\
    Goedel.Mesh.dll\
    Goedel.Protocol.dll\
    Goedel.Mesh.Portal.Client.dll\
    Goedel.Mesh.Portal.dll

ToolTargets = \
	ExceptionsRecrypt.cs\
	SchemaRecrypt.cs\
	SchemaRecryptProfile.cs

ExceptionsRecrypt.cs : ExceptionsRecrypt.Exceptional 
	exceptional ExceptionsRecrypt.Exceptional  /cs  ExceptionsRecrypt.cs

SchemaRecrypt.cs : SchemaRecrypt.protocol 
	protogen SchemaRecrypt.protocol  /cs  SchemaRecrypt.cs

SchemaRecryptProfile.cs : SchemaRecryptProfile.protocol 
	protogen SchemaRecryptProfile.protocol  /cs  SchemaRecryptProfile.cs


prebuildRecurse : 


postbuildRecurse :


prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Recrypt.dll

