
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
    Goedel.IO.dll\
    Goedel.Utilities.dll\
    Goedel.MeshOld.dll\
    Goedel.Protocol.dll

ToolTargets = \
	ExceptionsAccount.cs\
	SchemaAccount.cs
ExceptionsAccount.cs : ExceptionsAccount.Exceptional 
	exceptional ExceptionsAccount.Exceptional  /cs  ExceptionsAccount.cs

SchemaAccount.cs : SchemaAccount.protocol 
	protogen SchemaAccount.protocol  /cs  SchemaAccount.cs



prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Account.dll

