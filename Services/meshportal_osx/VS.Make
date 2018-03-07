
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
    Goedel.Discovery.dll\
    Goedel.FSR.dll\
    Goedel.IO.dll\
    Goedel.Registry.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.Jose.dll\
    Goedel.Cryptography.Standard.dll\
    Goedel.Cryptography.dll\
    Goedel.Mesh.dll\
    Goedel.Persistence.dll\
    Goedel.Protocol.dll\
    Goedel.Mesh.Portal.Client.dll\
    Goedel.Mesh.Portal.Server.dll\
    Goedel.Mesh.Portal.dll

ToolTargets = 


prebuildRecurse : 
	cd ..\meshportal && nmake /c /f VS.make prebuild 


postbuildRecurse :
	cd ..\meshportal && nmake /c /f VS.make postbuild 


prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget meshportal.exe $(LinkFiles) 

