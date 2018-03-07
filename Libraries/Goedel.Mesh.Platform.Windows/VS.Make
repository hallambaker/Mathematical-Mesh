
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
    Goedel.Mesh.Portal.Client.dll\
    Goedel.Mesh.Portal.Server.dll\
    Goedel.Mesh.Portal.dll\
    Goedel.Discovery.dll\
    Goedel.IO.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.Windows.dll\
    Goedel.Cryptography.dll\
    Goedel.Mesh.dll\
    Goedel.Protocol.dll

ToolTargets = \
	LiveMail.cs

LiveMail.cs : LiveMail.RegistrySchema 
	registryconfig LiveMail.RegistrySchema  LiveMail.cs


prebuildRecurse : 


postbuildRecurse :


prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Mesh.Platform.Windows.dll

