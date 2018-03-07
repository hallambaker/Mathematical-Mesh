
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
    Goedel.Utilities.dll\
    Goedel.Cryptography.Container.dll\
    Goedel.Cryptography.Jose.dll\
    Goedel.Cryptography.dll\
    Goedel.Mesh.Platform.Windows.dll\
    Goedel.Mesh.dll\
    Goedel.Persistence.dll\
    Goedel.Test.dll\
    Goedel.Account.Client.dll\
    Goedel.Account.Server.dll\
    Goedel.Account.dll\
    Goedel.Recrypt.Client.dll\
    Goedel.Recrypt.Server.dll\
    Goedel.Recrypt.dll\
    Test.Common.dll

ToolTargets = 


prebuildRecurse : 


postbuildRecurse :


prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Test.Goedel.Mesh.Services.dll

