
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
    Goedel.IO.dll\
    Goedel.Persistence.dll\
    Goedel.Protocol.dll\
    Goedel.Utilities.dll\
    Goedel.Mesh.dll

prebuild : 
    echo "Do Prebuild"

postbuild : 
	powershell publishtarget DumpLog.exe $(LinkFiles) 


