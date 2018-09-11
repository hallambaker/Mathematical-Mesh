
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
    Goedel.Mesh.Platform.Windows.dll\
    Goedel.Mesh.dll\
    Goedel.Persistence.dll\
    Goedel.Protocol.Debug.dll\
    Goedel.Protocol.Exchange.Server.dll\
    Goedel.Protocol.Exchange.dll\
    Goedel.Protocol.dll\
    Goedel.Test.dll\
    Goedel.Account.Client.dll\
    Goedel.Account.Server.dll\
    Goedel.Account.dll\
    Goedel.Confirm.Client.dll\
    Goedel.Confirm.Server.dll\
    Goedel.Confirm.dll\
    Goedel.Mesh.Portal.Client.dll\
    Goedel.Mesh.Portal.Server.dll\
    Goedel.Mesh.Portal.dll\
    Goedel.Recrypt.Client.dll\
    Goedel.Recrypt.Server.dll\
    Goedel.Recrypt.dll

ToolTargets = \
	Old\MakeExamplesApplications.cs\
	MakeExamplesAdvanced.cs\
	MakeExamplesProfile.cs\
	MakeExamplesPortal.cs\
	MakeExamplesCatalog.cs\
	Old\MakeExamplesReferenceOLD.cs\
	MakeExamplesUDF.cs\
	Old\MakeExamplesMessage.cs\
	MakeExamplesContainer.cs\
	MakeExamplesDeveloper.cs\
	Old\MakeExamplesKeyExchange.cs\
	MakeExamplesMessaging.cs
Old\MakeExamplesApplications.cs : Old\MakeExamplesApplications.script 
	gscript Old\MakeExamplesApplications.script  Old\MakeExamplesApplications.cs

MakeExamplesAdvanced.cs : MakeExamplesAdvanced.script 
	gscript MakeExamplesAdvanced.script  MakeExamplesAdvanced.cs

MakeExamplesProfile.cs : MakeExamplesProfile.script 
	gscript MakeExamplesProfile.script  MakeExamplesProfile.cs

MakeExamplesPortal.cs : MakeExamplesPortal.script 
	gscript MakeExamplesPortal.script  MakeExamplesPortal.cs

MakeExamplesCatalog.cs : MakeExamplesCatalog.script 
	gscript MakeExamplesCatalog.script  MakeExamplesCatalog.cs

Old\MakeExamplesReferenceOLD.cs : Old\MakeExamplesReferenceOLD.script 
	gscript Old\MakeExamplesReferenceOLD.script  Old\MakeExamplesReferenceOLD.cs

MakeExamplesUDF.cs : MakeExamplesUDF.script 
	gscript MakeExamplesUDF.script  MakeExamplesUDF.cs

Old\MakeExamplesMessage.cs : Old\MakeExamplesMessage.script 
	gscript Old\MakeExamplesMessage.script  Old\MakeExamplesMessage.cs

MakeExamplesContainer.cs : MakeExamplesContainer.script 
	gscript MakeExamplesContainer.script  MakeExamplesContainer.cs

MakeExamplesDeveloper.cs : MakeExamplesDeveloper.script 
	gscript MakeExamplesDeveloper.script  MakeExamplesDeveloper.cs

Old\MakeExamplesKeyExchange.cs : Old\MakeExamplesKeyExchange.script 
	gscript Old\MakeExamplesKeyExchange.script  Old\MakeExamplesKeyExchange.cs

MakeExamplesMessaging.cs : MakeExamplesMessaging.script 
	gscript MakeExamplesMessaging.script  MakeExamplesMessaging.cs



prebuildRecurse : 
	cd ..\..\Libraries\MeshMan && nmake /c /f VS.make prebuild 
	cd ..\..\Libraries\MeshApps && nmake /c /f VS.make prebuild 


postbuildRecurse :
	cd ..\..\Libraries\MeshMan && nmake /c /f VS.make postbuild 
	cd ..\..\Libraries\MeshApps && nmake /c /f VS.make postbuild 

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget MakeDrafts.exe $(LinkFiles) 

