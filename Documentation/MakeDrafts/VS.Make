
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
    Goedel.Cryptography.Dare.dll\
    Goedel.Cryptography.Jose.dll\
    Goedel.Cryptography.KeyFile.dll\
    Goedel.Cryptography.Standard.dll\
    Goedel.Cryptography.Windows.dll\
    Goedel.Cryptography.dll\
    Goedel.Mesh.Platform.Windows.dll\
    Goedel.Mesh.dll\
    Goedel.Persistence.dll\
    Goedel.Protocol.Debug.dll\
    Goedel.Protocol.Exchange.Server.dll\
    Goedel.Protocol.Exchange.dll\
    Goedel.Protocol.dll\
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
	MakeExamplesApplications.cs\
	MakeExamplesContainer.cs\
	MakeExamplesDeveloper.cs\
	MakeExamplesKeyExchange.cs\
	MakeExamplesReference.cs

MakeExamplesApplications.cs : MakeExamplesApplications.script 
	gscript MakeExamplesApplications.script  MakeExamplesApplications.cs

MakeExamplesContainer.cs : MakeExamplesContainer.script 
	gscript MakeExamplesContainer.script  MakeExamplesContainer.cs

MakeExamplesDeveloper.cs : MakeExamplesDeveloper.script 
	gscript MakeExamplesDeveloper.script  MakeExamplesDeveloper.cs

MakeExamplesKeyExchange.cs : MakeExamplesKeyExchange.script 
	gscript MakeExamplesKeyExchange.script  MakeExamplesKeyExchange.cs

MakeExamplesReference.cs : MakeExamplesReference.script 
	gscript MakeExamplesReference.script  MakeExamplesReference.cs


prebuildRecurse : 
	cd ..\..\Libraries\MeshMan && nmake /c /f VS.make prebuild 
	cd ..\..\Libraries\MeshApps && nmake /c /f VS.make prebuild 


postbuildRecurse :
	cd ..\..\Libraries\MeshMan && nmake /c /f VS.make postbuild 
	cd ..\..\Libraries\MeshApps && nmake /c /f VS.make postbuild 


prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget MakeDrafts.exe $(LinkFiles) 

