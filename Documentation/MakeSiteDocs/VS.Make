
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
    Goedel.Cryptography.dll\
    Goedel.Protocol.Debug.dll\
    Goedel.Protocol.dll\
    Goedel.Test.Core.dll\
    Goedel.Test.dll\
    Goedel.Mesh.Core.dll\
    Goedel.Mesh.Protocol.Client.dll\
    Goedel.Mesh.Protocol.Server.dll\
    Goedel.Mesh.Shell.dll\
    Goedel.Mesh.dll\
    Goedel.Mesh.Test.dll

ToolTargets = \
	Apps\UserGuideApps.cs\
	Apps\UserGuideCatalog.cs\
	Apps\UserGuideConfirm.cs\
	Apps\UserGuideMail.cs\
	Apps\UserGuideRecrypt.cs\
	Apps\UserGuideSSH.cs\
	Exceptions.cs\
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
	Web\ToDo.cs\
	Web\ExampleSession.cs\
	Web\CommandsetKey.cs\
	Web\UserGuide.cs
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

Web\ToDo.cs : Web\ToDo.script 
	gscript Web\ToDo.script  Web\ToDo.cs

Web\ExampleSession.cs : Web\ExampleSession.script 
	gscript Web\ExampleSession.script  Web\ExampleSession.cs

Web\CommandsetKey.cs : Web\CommandsetKey.script 
	gscript Web\CommandsetKey.script  Web\CommandsetKey.cs

Web\UserGuide.cs : Web\UserGuide.script 
	gscript Web\UserGuide.script  Web\UserGuide.cs



prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget MakeSiteDocs.exe $(LinkFiles) 

