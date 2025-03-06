
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
    Goedel.Test.Core.dll\
    Goedel.Utilities.dll\
    Goedel.Test.dll\
    Goedel.Cryptography.dll\
    Goedel.Mesh.Test.dll\
    Test.Anything.dll\
    Test.ASN1.dll\
    Test.Common.dll\
    Test.Cryptography.Dare.dll\
    Test.Cryptography.Jose.dll\
    Test.Cryptography.Keyfile.dll\
    Test.Cryptography.Nist.dll\
    Test.Cryptography.Oauth.dll\
    Test.Cryptography.Udf.dll\
    Test.Cryptography.dll\
    Test.Discovery.dll\
    Test.MakeSiteDocs.dll\
    Test.Mesh.Presence.dll\
    Test.Mesh.Protocol.dll\
    Test.Mesh.Shell.dll\
    Test.Mesh.Store.dll\
    Test.NotaryCallsign.dll\
    Test.Protocol.dll\
    Test.Thing.dll\
    Test.Utilities.dll

ToolTargets = 


prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)
	

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Scratchpad.exe $(LinkFiles) 

