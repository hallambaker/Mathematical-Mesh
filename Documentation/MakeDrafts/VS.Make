
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
    Goedel.Cryptography.Dare.dll\
    Goedel.Cryptography.Jose.dll\
    Goedel.Cryptography.KeyFile.dll\
    Goedel.Cryptography.Standard.dll\
    Goedel.Cryptography.WindowsFramework.dll\
    Goedel.Cryptography.dll\
    Goedel.Protocol.Debug.dll\
    Goedel.Protocol.dll\
    Goedel.Test.dll\
    Goedel.Mesh.Protocol.Client.dll\
    Goedel.Mesh.Protocol.Server.dll\
    Goedel.Mesh.Protocol.dll\
    Goedel.Mesh.dll

ToolTargets = \
	MakeExamplesAdvanced.cs\
	MakeExamplesProfile.cs\
	MakeExamplesPortal.cs\
	Old\MakeExamplesCatalog.cs\
	MakeExamplesUDF.cs\
	MakeExamplesContainer.cs\
	MakeExamplesDeveloper.cs\
	MakeExamplesMessaging.cs
MakeExamplesAdvanced.cs : MakeExamplesAdvanced.script 
	gscript MakeExamplesAdvanced.script  MakeExamplesAdvanced.cs

MakeExamplesProfile.cs : MakeExamplesProfile.script 
	gscript MakeExamplesProfile.script  MakeExamplesProfile.cs

MakeExamplesPortal.cs : MakeExamplesPortal.script 
	gscript MakeExamplesPortal.script  MakeExamplesPortal.cs

Old\MakeExamplesCatalog.cs : Old\MakeExamplesCatalog.script 
	gscript Old\MakeExamplesCatalog.script  Old\MakeExamplesCatalog.cs

MakeExamplesUDF.cs : MakeExamplesUDF.script 
	gscript MakeExamplesUDF.script  MakeExamplesUDF.cs

MakeExamplesContainer.cs : MakeExamplesContainer.script 
	gscript MakeExamplesContainer.script  MakeExamplesContainer.cs

MakeExamplesDeveloper.cs : MakeExamplesDeveloper.script 
	gscript MakeExamplesDeveloper.script  MakeExamplesDeveloper.cs

MakeExamplesMessaging.cs : MakeExamplesMessaging.script 
	gscript MakeExamplesMessaging.script  MakeExamplesMessaging.cs



prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget MakeDrafts.exe $(LinkFiles) 

