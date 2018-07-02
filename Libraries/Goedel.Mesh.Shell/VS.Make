
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
    Goedel.Async.Client.dll\
    Goedel.Catalog.Client.dll\
    Goedel.Mesh.Portal.Client.dll\
    Goedel.Utilities.dll\
    Goedel.Mesh.dll\
    Goedel.Protocol.dll

ToolTargets = \
	Exceptions.cs\
	Results.cs

Exceptions.cs : Exceptions.Exceptional 
	exceptional Exceptions.Exceptional  /cs  Exceptions.cs

Results.cs : Results.protogen 
	protogen Results.protogen  /cs  Results.cs


prebuildRecurse : 


postbuildRecurse :


prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Mesh.Shell.dll

