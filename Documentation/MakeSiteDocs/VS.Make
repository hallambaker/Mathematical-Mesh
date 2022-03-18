
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
    Goedel.IO.dll\
    Goedel.Registry.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.Core.dll\
    Goedel.Cryptography.dll\
    Goedel.Debug.dll\
    Goedel.Protocol.Debug.dll\
    Goedel.Protocol.dll\
    Goedel.Test.Core.dll\
    Goedel.Test.dll\
    Goedel.Mesh.Core.dll\
    Goedel.Mesh.Client.dll\
    Goedel.Mesh.Server.dll\
    Goedel.Mesh.Shell.dll\
    Goedel.Mesh.dll\
    Goedel.Mesh.Test.dll

ToolTargets = \
	Exceptions.cs\
	IDs\MakeExamples-1-architecture.cs\
	IDs\MakeExamples-2-UDF.cs\
	IDs\MakeExamples-3-Dare.cs\
	IDs\MakeExamples-4-Schema.cs\
	IDs\MakeExamples-6-Presentation.cs\
	IDs\MakeExamples-5-Protocol.cs\
	IDs\MakeExamples-8-Cryptography.cs\
	Web\CommandsetKey.cs\
	Web\ToDo.cs\
	Web\UserGuide.cs\
	Web\CommandsetAccount.cs\
	Web\CommandsetMail.cs\
	Web\CommandsetSSH.cs\
	Web\CommandsetPassword.cs\
	Web\CommandsetContact.cs\
	Web\CommandsetBookmark.cs\
	Web\CommandsetCalendar.cs\
	Web\CommandsetNetwork.cs\
	Web\CommandsetMessage.cs\
	Web\CommandsetKey.cs\
	Web\CommandsetKey.cs\
	Web\CommandsetGroup.cs\
	Web\CommandsetDare.cs\
	Web\CommandsetHash.cs\
	Web\CommandsetDevice.cs
Exceptions.cs : Exceptions.exceptional 
	exceptional Exceptions.exceptional  /cs  Exceptions.cs

IDs\MakeExamples-1-architecture.cs : IDs\MakeExamples-1-architecture.script 
	gscript IDs\MakeExamples-1-architecture.script  IDs\MakeExamples-1-architecture.cs

IDs\MakeExamples-2-UDF.cs : IDs\MakeExamples-2-UDF.script 
	gscript IDs\MakeExamples-2-UDF.script  IDs\MakeExamples-2-UDF.cs

IDs\MakeExamples-3-Dare.cs : IDs\MakeExamples-3-Dare.script 
	gscript IDs\MakeExamples-3-Dare.script  IDs\MakeExamples-3-Dare.cs

IDs\MakeExamples-4-Schema.cs : IDs\MakeExamples-4-Schema.script 
	gscript IDs\MakeExamples-4-Schema.script  IDs\MakeExamples-4-Schema.cs

IDs\MakeExamples-6-Presentation.cs : IDs\MakeExamples-6-Presentation.script 
	gscript IDs\MakeExamples-6-Presentation.script  IDs\MakeExamples-6-Presentation.cs

IDs\MakeExamples-5-Protocol.cs : IDs\MakeExamples-5-Protocol.script 
	gscript IDs\MakeExamples-5-Protocol.script  IDs\MakeExamples-5-Protocol.cs

IDs\MakeExamples-8-Cryptography.cs : IDs\MakeExamples-8-Cryptography.script 
	gscript IDs\MakeExamples-8-Cryptography.script  IDs\MakeExamples-8-Cryptography.cs

Web\CommandsetKey.cs : Web\CommandsetKey.script 
	gscript Web\CommandsetKey.script  Web\CommandsetKey.cs

Web\ToDo.cs : Web\ToDo.script 
	gscript Web\ToDo.script  Web\ToDo.cs

Web\UserGuide.cs : Web\UserGuide.script 
	gscript Web\UserGuide.script  Web\UserGuide.cs

Web\CommandsetAccount.cs : Web\CommandsetAccount.script 
	gscript Web\CommandsetAccount.script  Web\CommandsetAccount.cs

Web\CommandsetMail.cs : Web\CommandsetMail.script 
	gscript Web\CommandsetMail.script  Web\CommandsetMail.cs

Web\CommandsetSSH.cs : Web\CommandsetSSH.script 
	gscript Web\CommandsetSSH.script  Web\CommandsetSSH.cs

Web\CommandsetPassword.cs : Web\CommandsetPassword.script 
	gscript Web\CommandsetPassword.script  Web\CommandsetPassword.cs

Web\CommandsetContact.cs : Web\CommandsetContact.script 
	gscript Web\CommandsetContact.script  Web\CommandsetContact.cs

Web\CommandsetBookmark.cs : Web\CommandsetBookmark.script 
	gscript Web\CommandsetBookmark.script  Web\CommandsetBookmark.cs

Web\CommandsetCalendar.cs : Web\CommandsetCalendar.script 
	gscript Web\CommandsetCalendar.script  Web\CommandsetCalendar.cs

Web\CommandsetNetwork.cs : Web\CommandsetNetwork.script 
	gscript Web\CommandsetNetwork.script  Web\CommandsetNetwork.cs

Web\CommandsetMessage.cs : Web\CommandsetMessage.script 
	gscript Web\CommandsetMessage.script  Web\CommandsetMessage.cs

Web\CommandsetKey.cs : Web\CommandsetKey.script 
	gscript Web\CommandsetKey.script  Web\CommandsetKey.cs

Web\CommandsetKey.cs : Web\CommandsetKey.script 
	gscript Web\CommandsetKey.script  Web\CommandsetKey.cs

Web\CommandsetGroup.cs : Web\CommandsetGroup.script 
	gscript Web\CommandsetGroup.script  Web\CommandsetGroup.cs

Web\CommandsetDare.cs : Web\CommandsetDare.script 
	gscript Web\CommandsetDare.script  Web\CommandsetDare.cs

Web\CommandsetHash.cs : Web\CommandsetHash.script 
	gscript Web\CommandsetHash.script  Web\CommandsetHash.cs

Web\CommandsetDevice.cs : Web\CommandsetDevice.script 
	gscript Web\CommandsetDevice.script  Web\CommandsetDevice.cs



prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)
	

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget MakeSiteDocs.exe $(LinkFiles) 

