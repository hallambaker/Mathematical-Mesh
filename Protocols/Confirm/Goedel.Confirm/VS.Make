
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
    Goedel.Utilities.dll\
    Goedel.Mesh.dll\
    Goedel.Protocol.dll\
    Goedel.Mesh.Portal.Client.dll\
    Goedel.Mesh.Portal.Server.dll\
    Goedel.Mesh.Portal.dll

ToolTargets = \
	ExceptionsConfirm.cs\
	SchemaConfirm.cs\
	SchemaConfirmProfile.cs
ExceptionsConfirm.cs : ExceptionsConfirm.Exceptional 
	exceptional ExceptionsConfirm.Exceptional  /cs  ExceptionsConfirm.cs

SchemaConfirm.cs : SchemaConfirm.protocol 
	protogen SchemaConfirm.protocol  /cs  SchemaConfirm.cs

SchemaConfirmProfile.cs : SchemaConfirmProfile.protocol 
	protogen SchemaConfirmProfile.protocol  /cs  SchemaConfirmProfile.cs



prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Confirm.dll

