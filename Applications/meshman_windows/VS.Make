
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
    Goedel.Command.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.Windows.dll\
    Goedel.Mesh.Platform.Windows.dll\
    Goedel.Mesh.dll\
    Goedel.Mesh.Portal.Client.dll\
    Goedel.Mesh.Portal.dll

ToolTargets = 


prebuildRecurse : 
	cd ..\..\Libraries\MeshMan && nmake /c /f VS.make prebuild 


postbuildRecurse :
	cd ..\..\Libraries\MeshMan && nmake /c /f VS.make postbuild 


prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget meshman.exe $(LinkFiles) 

