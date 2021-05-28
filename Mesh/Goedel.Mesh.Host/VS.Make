
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
    Goedel.Command.dll\
    Goedel.Protocol.Presentation.dll\
    Goedel.Protocol.Service.dll\
    Goedel.Protocol.dll\
    Goedel.Mesh.Client.dll\
    Goedel.Mesh.Management.dll\
    Goedel.Mesh.Server.dll\
    Goedel.Mesh.dll

ToolTargets = \
	Exceptions.cs\
	meshhost.cs\
	Results.cs
Exceptions.cs : Exceptions.exceptional 
	exceptional Exceptions.exceptional  /cs  Exceptions.cs

meshhost.cs : meshhost.command 
	commandparse meshhost.command  /cs  meshhost.cs

Results.cs : Results.protogen 
	protogen Results.protogen  /cs  Results.cs



prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)
	version version.version AssemblyVersion.cs
	

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Mesh.Host.dll

