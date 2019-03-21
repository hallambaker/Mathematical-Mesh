
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
    Goedel.ASN.dll\
    Goedel.Command.dll\
    Goedel.Discovery.dll\
    Goedel.FSR.dll\
    Goedel.IO.dll\
    Goedel.Registry.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.Core.dll\
    Goedel.Cryptography.Dare.dll\
    Goedel.Cryptography.Jose.dll\
    Goedel.Cryptography.KeyFile.dll\
    Goedel.Cryptography.dll\
    Goedel.Protocol.Debug.dll\
    Goedel.Protocol.dll\
    Goedel.Test.Core.dll\
    Goedel.Test.dll\
    Goedel.Mesh.Protocol.Client.dll\
    Goedel.Mesh.Protocol.Server.dll\
    Goedel.Mesh.dll\
    Goedel.Mesh.Test.dll

ToolTargets = \
	Old\MakeExamplesAdvanced.cs\
	Old\MakeExamplesProfile.cs\
	Old\MakeExamplesPortal.cs\
	Old\MakeExamplesCatalog.cs\
	MakeExamples-2-UDF.cs\
	Old\MakeExamplesMessage.cs\
	MakeExamples-3-Dare.cs\
	MakeExamples-4-schema.cs\
	MakeExamples-5-protocol.cs\
	Old\MakeExamplesDeveloper.cs\
	Old\MakeExamplesMessaging.cs\
	Old\MakeExamplesMessage.cs
Old\MakeExamplesAdvanced.cs : Old\MakeExamplesAdvanced.script 
	gscript Old\MakeExamplesAdvanced.script  Old\MakeExamplesAdvanced.cs

Old\MakeExamplesProfile.cs : Old\MakeExamplesProfile.script 
	gscript Old\MakeExamplesProfile.script  Old\MakeExamplesProfile.cs

Old\MakeExamplesPortal.cs : Old\MakeExamplesPortal.script 
	gscript Old\MakeExamplesPortal.script  Old\MakeExamplesPortal.cs

Old\MakeExamplesCatalog.cs : Old\MakeExamplesCatalog.script 
	gscript Old\MakeExamplesCatalog.script  Old\MakeExamplesCatalog.cs

MakeExamples-2-UDF.cs : MakeExamples-2-UDF.script 
	gscript MakeExamples-2-UDF.script  MakeExamples-2-UDF.cs

Old\MakeExamplesMessage.cs : Old\MakeExamplesMessage.script 
	gscript Old\MakeExamplesMessage.script  Old\MakeExamplesMessage.cs

MakeExamples-3-Dare.cs : MakeExamples-3-Dare.script 
	gscript MakeExamples-3-Dare.script  MakeExamples-3-Dare.cs

MakeExamples-4-schema.cs : MakeExamples-4-schema.script 
	gscript MakeExamples-4-schema.script  MakeExamples-4-schema.cs

MakeExamples-5-protocol.cs : MakeExamples-5-protocol.script 
	gscript MakeExamples-5-protocol.script  MakeExamples-5-protocol.cs

Old\MakeExamplesDeveloper.cs : Old\MakeExamplesDeveloper.script 
	gscript Old\MakeExamplesDeveloper.script  Old\MakeExamplesDeveloper.cs

Old\MakeExamplesMessaging.cs : Old\MakeExamplesMessaging.script 
	gscript Old\MakeExamplesMessaging.script  Old\MakeExamplesMessaging.cs

Old\MakeExamplesMessage.cs : Old\MakeExamplesMessage.script 
	gscript Old\MakeExamplesMessage.script  Old\MakeExamplesMessage.cs



prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget MakeDrafts.exe $(LinkFiles) 

