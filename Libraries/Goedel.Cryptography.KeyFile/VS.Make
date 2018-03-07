
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
    Goedel.FSR.dll\
    Goedel.IO.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.Standard.dll\
    Goedel.Cryptography.dll

ToolTargets = \
	Exceptions.cs\
	HostsReader.cs\
	KeyReader.cs

Exceptions.cs : Exceptions.Exceptional 
	exceptional Exceptions.Exceptional  /cs  Exceptions.cs

HostsReader.cs : HostsReader.fsm 
	fsrgen HostsReader.fsm  /cs  HostsReader.cs

KeyReader.cs : KeyReader.fsm 
	fsrgen KeyReader.fsm  /cs  KeyReader.cs


prebuildRecurse : 


postbuildRecurse :


prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Cryptography.KeyFile.dll

