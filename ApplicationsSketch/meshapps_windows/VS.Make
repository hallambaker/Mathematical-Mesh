
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
    Goedel.Command.dll\
    Goedel.Utilities.dll\
    Goedel.Mesh.Platform.Windows.dll\
    Goedel.Mesh.dll\
    Goedel.Account.Client.dll\
    Goedel.Account.dll\
    Goedel.Confirm.Client.dll\
    Goedel.Confirm.dll\
    Goedel.Mesh.Portal.Client.dll\
    Goedel.Mesh.Portal.dll\
    Goedel.Recrypt.Client.dll\
    Goedel.Recrypt.dll

ToolTargets = 


prebuildRecurse : 
	cd ..\..\Libraries\MeshApps && nmake /c /f VS.make prebuild 


postbuildRecurse :
	cd ..\..\Libraries\MeshApps && nmake /c /f VS.make postbuild 

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget meshapp.exe $(LinkFiles) 

