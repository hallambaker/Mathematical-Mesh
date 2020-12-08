
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
    Goedel.ASN.dll\
    Goedel.Command.dll\
    Goedel.IO.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.Container.dll\
    Goedel.Cryptography.Jose.dll\
    Goedel.Cryptography.Windows.dll\
    Goedel.Cryptography.dll\
    Goedel.Protocol.dll\
    Goedel.Recrypt.Client.dll\
    Goedel.Recrypt.dll

ToolTargets = 


prebuildRecurse : 
	cd ..\Libraries\ContainerMan && nmake /c /f VS.make prebuild 


postbuildRecurse :
	cd ..\Libraries\ContainerMan && nmake /c /f VS.make postbuild 


prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget ContainerMan.exe $(LinkFiles) 

