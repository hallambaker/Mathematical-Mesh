
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

LinkFiles = 

ToolTargets = \
	Exceptions.cs\
	meshman.cs\
	SchemaResults.cs

Exceptions.cs : Exceptions.Exceptional 
	exceptional Exceptions.Exceptional  /cs  Exceptions.cs

meshman.cs : meshman.command 
	commandparse meshman.command  /cs  meshman.cs

SchemaResults.cs : SchemaResults.protocol 
	protogen SchemaResults.protocol  /cs  SchemaResults.cs


prebuildRecurse : 


postbuildRecurse :


prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget MeshMan.dll

