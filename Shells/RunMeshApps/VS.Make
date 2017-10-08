
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
    Goedel.Command.dll\
    Goedel.Cryptography.Framework.dll\
    Goedel.Cryptography.Jose.dll\
    Goedel.Cryptography.KeyFile.dll\
    PHB Framework Library.dll\
    Goedel.Cryptography.Windows.dll\
    Goedel.Cryptography.dll\
    Goedel.FSR.dll\
    Goedel.IO.dll\
    Goedel.Protocol.Debug.dll\
    Goedel.Protocol.dll\
    Goedel.Registry.dll\
    Goedel.Test.dll\
    Goedel.Utilities.dll\
    Goedel.Mesh.Client.dll\
    Goedel.Mesh.Platform.Linux.dll\
    Goedel.Mesh.Platform.Windows.dll\
    Goedel.Mesh.Platform.dll\
    Goedel.Mesh.Server.dll\
    Goedel.Mesh.dll\
    Goedel.Account.Client.dll\
    Goedel.Account.Server.dll\
    Goedel.Account.dll\
    Goedel.Confirm.Client.dll\
    Goedel.Confirm.Server.dll\
    Goedel.Confirm.dll\
    Goedel.Recrypt.Client.dll\
    Goedel.Recrypt.Server.dll\
    Goedel.Recrypt.dll\
    CombinedClient.dll

prebuild : 
    echo "Do Prebuild"

postbuild : 
	powershell publishtarget RunMeshApps.exe $(LinkFiles) 


