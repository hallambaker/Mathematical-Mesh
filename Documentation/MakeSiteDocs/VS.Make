
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
    Goedel.Cryptography.Ticket.dll\
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
	Apps\UserGuideApps.cs\
	Apps\UserGuideCatalog.cs\
	Apps\UserGuideConfirm.cs\
	Apps\UserGuideMail.cs\
	Apps\UserGuideRecrypt.cs\
	Apps\UserGuideSSH.cs\
	Exceptions.cs\
	Main.cs\
	Mesh\UserGuideConnecting.cs\
	Mesh\UserGuideCreate.cs\
	Mesh\UserGuideDisaster.cs\
	Mesh\UserGuideMesh.cs\
	Mesh\UserGuideQuickStart.cs\
	Mesh\UserGuideServer.cs\
	Platform\UserGuideDocker.cs\
	Platform\UserGuideLinux.cs\
	Platform\UserGuideOSX.cs\
	Platform\UserGuidePlatform.cs\
	Platform\UserGuideWindows.cs\
	ToDo.cs\
	ExampleSession.cs\
	UserGuide.cs

Apps\UserGuideApps.cs : Apps\UserGuideApps.script 
	gscript Apps\UserGuideApps.script  Apps\UserGuideApps.cs

Apps\UserGuideCatalog.cs : Apps\UserGuideCatalog.script 
	gscript Apps\UserGuideCatalog.script  Apps\UserGuideCatalog.cs

Apps\UserGuideConfirm.cs : Apps\UserGuideConfirm.script 
	gscript Apps\UserGuideConfirm.script  Apps\UserGuideConfirm.cs

Apps\UserGuideMail.cs : Apps\UserGuideMail.script 
	gscript Apps\UserGuideMail.script  Apps\UserGuideMail.cs

Apps\UserGuideRecrypt.cs : Apps\UserGuideRecrypt.script 
	gscript Apps\UserGuideRecrypt.script  Apps\UserGuideRecrypt.cs

Apps\UserGuideSSH.cs : Apps\UserGuideSSH.script 
	gscript Apps\UserGuideSSH.script  Apps\UserGuideSSH.cs

Exceptions.cs : Exceptions.exceptional 
	exceptional Exceptions.exceptional  /cs  Exceptions.cs

Main.cs : Main.command 
	commandparse Main.command  /cs  Main.cs

Mesh\UserGuideConnecting.cs : Mesh\UserGuideConnecting.script 
	gscript Mesh\UserGuideConnecting.script  Mesh\UserGuideConnecting.cs

Mesh\UserGuideCreate.cs : Mesh\UserGuideCreate.script 
	gscript Mesh\UserGuideCreate.script  Mesh\UserGuideCreate.cs

Mesh\UserGuideDisaster.cs : Mesh\UserGuideDisaster.script 
	gscript Mesh\UserGuideDisaster.script  Mesh\UserGuideDisaster.cs

Mesh\UserGuideMesh.cs : Mesh\UserGuideMesh.script 
	gscript Mesh\UserGuideMesh.script  Mesh\UserGuideMesh.cs

Mesh\UserGuideQuickStart.cs : Mesh\UserGuideQuickStart.script 
	gscript Mesh\UserGuideQuickStart.script  Mesh\UserGuideQuickStart.cs

Mesh\UserGuideServer.cs : Mesh\UserGuideServer.script 
	gscript Mesh\UserGuideServer.script  Mesh\UserGuideServer.cs

Platform\UserGuideDocker.cs : Platform\UserGuideDocker.script 
	gscript Platform\UserGuideDocker.script  Platform\UserGuideDocker.cs

Platform\UserGuideLinux.cs : Platform\UserGuideLinux.script 
	gscript Platform\UserGuideLinux.script  Platform\UserGuideLinux.cs

Platform\UserGuideOSX.cs : Platform\UserGuideOSX.script 
	gscript Platform\UserGuideOSX.script  Platform\UserGuideOSX.cs

Platform\UserGuidePlatform.cs : Platform\UserGuidePlatform.script 
	gscript Platform\UserGuidePlatform.script  Platform\UserGuidePlatform.cs

Platform\UserGuideWindows.cs : Platform\UserGuideWindows.script 
	gscript Platform\UserGuideWindows.script  Platform\UserGuideWindows.cs

ToDo.cs : ToDo.script 
	gscript ToDo.script  ToDo.cs

ExampleSession.cs : ExampleSession.script 
	gscript ExampleSession.script  ExampleSession.cs

UserGuide.cs : UserGuide.script 
	gscript UserGuide.script  UserGuide.cs


prebuildRecurse : 
	cd ..\..\Libraries\MeshApps && nmake /c /f VS.make prebuild 
	cd ..\..\Libraries\MeshMan && nmake /c /f VS.make prebuild 


postbuildRecurse :
	cd ..\..\Libraries\MeshApps && nmake /c /f VS.make postbuild 
	cd ..\..\Libraries\MeshMan && nmake /c /f VS.make postbuild 


prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget MakeSiteDocs.exe $(LinkFiles) 

