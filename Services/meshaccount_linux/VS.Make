
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
    Goedel.Discovery.dll\
    Goedel.FSR.dll\
    Goedel.IO.dll\
    Goedel.Registry.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.Linux.dll\
    Goedel.Cryptography.Standard.dll\
    Goedel.Cryptography.dll\
    Goedel.Mesh.dll\
    Goedel.Persistence.dll\
    Goedel.Protocol.dll\
    Goedel.Account.Server.dll\
    Goedel.Account.dll\
    Goedel.Confirm.Server.dll\
    Goedel.Confirm.dll\
    Goedel.Mesh.Portal.Client.dll\
    Goedel.Mesh.Portal.dll\
    Goedel.Recrypt.Server.dll\
    Goedel.Recrypt.dll

ToolTargets = 


prebuildRecurse : 
	cd ..\meshaccount && nmake /c /f VS.make prebuild 


postbuildRecurse :
	cd ..\meshaccount && nmake /c /f VS.make postbuild 

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget meshaccount.exe $(LinkFiles) 

