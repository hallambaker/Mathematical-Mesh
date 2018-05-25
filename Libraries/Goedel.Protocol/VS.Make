
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
    Goedel.Discovery.dll\
    Goedel.FSR.dll\
    Goedel.IO.dll\
    Goedel.Utilities.dll

ToolTargets = \
	Exceptions.cs\
	JSONTokenizer.cs\
	MessageBase.cs

Exceptions.cs : Exceptions.exceptional 
	exceptional Exceptions.exceptional  /cs  Exceptions.cs

JSONTokenizer.cs : JSONTokenizer.fsm 
	fsrgen JSONTokenizer.fsm  /cs  JSONTokenizer.cs

MessageBase.cs : MessageBase.protocol 
	protogen MessageBase.protocol  /cs  MessageBase.cs


prebuildRecurse : 


postbuildRecurse :


prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Protocol.dll

