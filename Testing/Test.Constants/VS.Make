
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
    Goedel.Utilities.dll\
    Goedel.Mesh.Platform.Windows.dll\
    Goedel.Mesh.dll\
    Goedel.Protocol.dll\
    Goedel.Test.dll\
    Goedel.Mesh.Portal.Client.dll\
    Goedel.Mesh.Portal.Server.dll\
    Goedel.Mesh.Portal.dll

ToolTargets = \
	Exceptions.cs
Exceptions.cs : Exceptions.exceptional 
	exceptional Exceptions.exceptional  /cs  Exceptions.cs



prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Test.Common.dll

