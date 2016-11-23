
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
    Goedel.Cryptography.dll\
    Goedel.Cryptography.Framework.dll\
    Goedel.IO.dll\
    Goedel.Platform.dll\
    Goedel.Platform.Framework.dll\
    Goedel.Protocol.dll\
    Goedel.Protocol.Debug.dll\
    Goedel.Protocol.Framework.dll\
    Goedel.Utilities.dll\
    Goedel.Mesh.Client.dll\
    Goedel.Mesh.Server.dll\
    Goedel.Mesh.dll\
    Goedel.Persistence.dll

prebuild : 
    echo "Do Prebuild"

postbuild : 
	powershell publishtarget InternetDrafts.exe $(LinkFiles) 


