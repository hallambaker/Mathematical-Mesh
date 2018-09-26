
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
    Microsoft.VisualStudio.TestPlatform.TestFramework.dll\
    Microsoft.VisualStudio.TestPlatform.TestFramework.Extensions.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.Dare.dll\
    Goedel.Cryptography.Jose.dll\
    Goedel.Cryptography.Standard.dll\
    Goedel.Cryptography.WindowsFramework.dll\
    Goedel.Cryptography.dll\
    Goedel.Mesh.ShellOld.dll\
    Goedel.Protocol.dll\
    Goedel.Test.dll

ToolTargets = 


prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Catalog.Test.dll

