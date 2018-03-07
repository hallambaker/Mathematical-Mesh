
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

LinkFiles = 

ToolTargets = 


prebuildRecurse : 
	cd ..\..\Goedel.Command && nmake /c /f VS.make prebuild 
	cd ..\..\Goedel.FSR && nmake /c /f VS.make prebuild 
	cd ..\..\Goedel.Registry && nmake /c /f VS.make prebuild 
	cd ..\..\Goedel.Utilities && nmake /c /f VS.make prebuild 
	cd ..\..\Goedel.Discovery && nmake /c /f VS.make prebuild 


postbuildRecurse :
	cd ..\..\Goedel.Command && nmake /c /f VS.make postbuild 
	cd ..\..\Goedel.FSR && nmake /c /f VS.make postbuild 
	cd ..\..\Goedel.Registry && nmake /c /f VS.make postbuild 
	cd ..\..\Goedel.Utilities && nmake /c /f VS.make postbuild 
	cd ..\..\Goedel.Discovery && nmake /c /f VS.make postbuild 


prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Tool.Shell.dll

