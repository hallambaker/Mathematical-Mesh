
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
    Goedel.Mesh.Portal.Client.dll\
    Goedel.Mesh.Portal.Server.dll\
    Goedel.Mesh.Portal.dll\
    Goedel.Discovery.dll\
    Goedel.IO.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.WindowsFramework.dll\
    Goedel.Cryptography.dll\
    Goedel.MeshOld.dll\
    Goedel.Protocol.dll

ToolTargets = \
	LiveMail.cs
LiveMail.cs : LiveMail.RegistrySchema 
	registryconfig LiveMail.RegistrySchema  LiveMail.cs



prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Mesh.Platform.Windows.dll

