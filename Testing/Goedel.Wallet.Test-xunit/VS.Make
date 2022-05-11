
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
    Goedel.Utilities.dll\
    Goedel.Cryptography.Core.dll\
    Goedel.Test.Core.dll\
    Goedel.Test.dll\
    Goedel.Mesh.Core.dll\
    Goedel.Mesh.Shell.ServiceAdmin.dll\
    Goedel.Mesh.Shell.dll\
    Goedel.Mesh.dll\
    Goedel.Mesh.Test.dll

ToolTargets = 


prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)
	

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Wallet.Test-xunit.dll

