
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
    Goedel.IO.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.Dare.dll\
    Goedel.Cryptography.WindowsFramework.dll\
    Goedel.Cryptography.dll\
    Goedel.Mesh.Platform.Windows.dll\
    Goedel.Mesh.dll\
    Goedel.Protocol.dll\
    Goedel.Test.dll\
    Goedel.Mesh.Portal.Client.dll\
    Goedel.Mesh.Portal.Server.dll\
    Goedel.Mesh.Portal.dll\
    Goedel.ASN.Test.dll\
    Goedel.Catalog.Test.dll\
    Goedel.Cryptography.Algorithms.Test.dll\
    Goedel.Cryptography.Dare.Test.dll\
    Goedel.Cryptography.DH.Test.dll\
    Goedel.Cryptography.KeyFile.Test.dll\
    Goedel.Cryptography.Windows.Test.dll\
    Goedel.Protocol.Test.dll\
    Test.Common.dll\
    Goedel.Cryptography.Jose.Test.dll\
    Test.Goedel.Cryptography.Linux.dll\
    Test.Goedel.Cryptography.dll\
    Test.Goedel.Discovery.dll\
    Test.Goedel.Mesh.Mail.dll\
    Test.Goedel.Mesh.Profile.dll\
    Test.Goedel.Mesh.Proxy.dll\
    Test.Goedel.Mesh.Recrypt.dll\
    Test.Goedel.Mesh.Services.dll\
    Test.Goedel.Mesh.Shell.dll\
    Test.Goedel.Mesh.SSH.dll

ToolTargets = 


prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Scratchpad.exe $(LinkFiles) 

