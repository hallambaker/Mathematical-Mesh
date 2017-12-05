
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
    Goedel.ASN.dll\
    Goedel.Command.dll\
    Goedel.Cryptography.Container.dll\
    Goedel.Cryptography.Jose.dll\
    Goedel.Cryptography.Windows.dll\
    Goedel.Cryptography.dll\
    Goedel.Discovery.dll\
    Goedel.FSR.dll\
    Goedel.Protocol.dll\
    Goedel.Utilities.dll\
    Goedel.Registry.dll\
    Goedel.Cryptography.Framework.dll\
    Goedel.Cryptography.KeyFile.dll\
    Goedel.IO.dll\
    Goedel.Test.dll\
    Test.Goedel.Cryptography.Container.dll

prebuild : 
    echo "Do Prebuild"

postbuild : 
	powershell publishtarget AAAConsole.exe $(LinkFiles) 


