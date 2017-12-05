
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
    Goedel.Cryptography.Jose.dll\
    Goedel.Cryptography.KeyFile.dll\
    Goedel.Cryptography.dll\
    Goedel.Discovery.dll\
    Goedel.FSR.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.Windows.dll\
    Goedel.Cryptography.Framework.dll\
    Goedel.IO.dll\
    Goedel.Protocol.dll\
    Goedel.Test.dll

prebuild : 
    echo "Do Prebuild"

postbuild : 
	powershell publishtarget Test.Goedel.Cryptography.Jose.dll


