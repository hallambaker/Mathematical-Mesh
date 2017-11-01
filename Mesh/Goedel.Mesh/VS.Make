
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
    Goedel.Cryptography.Framework.dll\
    Goedel.Cryptography.Jose.dll\
    Goedel.Cryptography.KeyFile.dll\
    Goedel.Cryptography.dll\
    Goedel.IO.dll\
    Goedel.Persistence.dll\
    Goedel.Protocol.dll\
    Goedel.Registry.dll\
    Goedel.Utilities.dll

prebuild : 
    echo "Do Prebuild"

postbuild : 
	powershell publishtarget Goedel.Mesh.dll


