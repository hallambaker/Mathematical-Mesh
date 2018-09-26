
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
    Goedel.Discovery.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.Jose.dll\
    Goedel.Cryptography.dll\
    Goedel.MeshOld.dll\
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

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Recrypt.dll

