
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
    Goedel.Discovery.dll\
    Goedel.IO.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.Jose.dll\
    Goedel.Cryptography.dll\
    Goedel.Protocol.dll\
    Goedel.Test.dll\
    Goedel.Mesh.dll\
    Goedel.ASN1.Test-xunit.dll\
    Goedel.Cryptography.Dare.Test-xunit.dll\
    Goedel.Cryptography.Jose.Test-xunit.dll\
    Goedel.Cryptography.Keyfile.Test-xunit.dll\
    Goedel.Cryptography.Test-xunit.dll\
    Goedel.Discovery.Test-xunit.dll\
    Goedel.Mesh.Protocol.Test-xunit.dll\
    Goedel.Mesh.Shell.Test-xunit.dll\
    Goedel.Mesh.Store.Test-xunit.dll\
    Goedel.Protocol.Test-xunit.dll\
    Goedel.Utilities.Test-xunit.dll\
    Test.Common.dll\
    Test.MakeSiteDocs.dll

ToolTargets = 


prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)
	

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Scratchpad.exe $(LinkFiles) 

