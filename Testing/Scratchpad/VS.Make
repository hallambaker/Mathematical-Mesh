
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
    Goedel.IO.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.Dare.dll\
    Goedel.Cryptography.Windows.dll\
    Goedel.Cryptography.dll\
    Goedel.Mesh.Platform.Windows.dll\
    Goedel.Mesh.dll\
    Goedel.Protocol.dll\
    Goedel.Test.dll\
    Goedel.Mesh.Portal.Client.dll\
    Goedel.Mesh.Portal.Server.dll\
    Goedel.Mesh.Portal.dll\
    Goedel.Protocol.Test.dll\
    Test.Common.dll\
    Test.Cryptography.Algorithms.dll\
    Test.Goedel.ASN.dll\
    Test.Goedel.Cryptography.Container.dll\
    Test.Goedel.Cryptography.DH.dll\
    Test.Goedel.Cryptography.Jose.dll\
    Test.Goedel.Cryptography.KeyFile.dll\
    Test.Goedel.Cryptography.Linux.dll\
    Test.Goedel.Cryptography.Windows.dll\
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


prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Scratchpad.exe $(LinkFiles) 

