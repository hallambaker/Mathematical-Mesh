
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
    Goedel.Command.Json.dll\
    Goedel.Command.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.Dare.dll\
    Goedel.Cryptography.dll\
    Goedel.Protocol.dll\
    Goedel.Mesh.Client.dll\
    Goedel.Mesh.dll

ToolTargets = \
	Exceptions.cs\
	meshman.cs\
	Results.cs
Exceptions.cs : Exceptions.Exceptional 
	exceptional Exceptions.Exceptional  /cs  Exceptions.cs

meshman.cs : meshman.command 
	commandparse meshman.command  /cs  meshman.cs

Results.cs : Results.protogen 
	protogen Results.protogen  /cs  Results.cs



prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)
	version version.version AssemblyVersion.cs
	

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Mesh.Shell.dll

