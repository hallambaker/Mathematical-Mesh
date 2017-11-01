
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

LinkFiles = \
    Microsoft.VisualStudio.TestPlatform.TestFramework.dll\
    Microsoft.VisualStudio.TestPlatform.TestFramework.Extensions.dll\
    Goedel.Cryptography.Jose.dll\
    Goedel.Cryptography.dll\
    Goedel.Protocol.dll\
    Goedel.Utilities.dll\
    Goedel.Confirm.Client.dll\
    Goedel.Confirm.Server.dll\
    Goedel.Confirm.dll

prebuild : 
    echo "Do Prebuild"

postbuild : 
	powershell publishtarget Test.Confirm.dll


