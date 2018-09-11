
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
    Goedel.FSR.dll\
    Goedel.Registry.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.Dare.dll\
    Goedel.Cryptography.dll\
    Goedel.Mesh.Platform.Windows.dll\
    Goedel.Mesh.Shell.dll\
    Goedel.Mesh.dll\
    Goedel.Persistence.dll\
    Goedel.Protocol.dll\
    Goedel.Async.Client.dll\
    Goedel.Async.dll\
    Goedel.Catalog.Client.dll\
    Goedel.Catalog.dll\
    Goedel.Mesh.Portal.Client.dll\
    Goedel.Mesh.Portal.dll\
    Goedel.Recrypt.Client.dll\
    Goedel.Recrypt.dll

ToolTargets = \
	OpenDareShell.cs
OpenDareShell.cs : OpenDareShell.Shell 
	commandparse OpenDareShell.Shell  /cs  OpenDareShell.cs



prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget OpenDare.exe $(LinkFiles) 

