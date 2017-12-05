
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
    Goedel.Utilities.dll\
    Goedel.Mesh.dll\
    Goedel.Protocol.dll\
    Goedel.Mesh.Portal.Client.dll

ToolTargets = \
	ExceptionsConfirm.cs\
	SchemaConfirm.cs\
	SchemaConfirmProfile.cs

ExceptionsConfirm.cs : ExceptionsConfirm.Exceptional 
	exceptional ExceptionsConfirm.Exceptional  ExceptionsConfirm.cs

SchemaConfirm.cs : SchemaConfirm.protocol 
	protogen SchemaConfirm.protocol  SchemaConfirm.cs

SchemaConfirmProfile.cs : SchemaConfirmProfile.protocol 
	protogen SchemaConfirmProfile.protocol  SchemaConfirmProfile.cs


prebuildRecurse : 


postbuildRecurse :


prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Confirm.dll

