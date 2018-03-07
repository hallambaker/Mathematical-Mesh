
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

ToolTargets = \
	CommandLex.cs\
	CommandSplit.cs\
	Exceptions.cs

CommandLex.cs : CommandLex.fsm 
	fsrgen CommandLex.fsm  /cs  CommandLex.cs

CommandSplit.cs : CommandSplit.fsm 
	fsrgen CommandSplit.fsm  /cs  CommandSplit.cs

Exceptions.cs : Exceptions.exceptional 
	exceptional Exceptions.exceptional  /cs  Exceptions.cs


prebuildRecurse : 


postbuildRecurse :


prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Command.dll

