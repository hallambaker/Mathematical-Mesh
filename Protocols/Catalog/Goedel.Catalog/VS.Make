
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
    Goedel.Cryptography.Dare.dll\
    Goedel.Cryptography.dll\
    Goedel.Mesh.dll\
    Goedel.Persistence.dll

ToolTargets = \
	SchemaCatalog.cs\
	SchemaCatalogData.cs

SchemaCatalog.cs : SchemaCatalog.protocol 
	protogen SchemaCatalog.protocol  /cs  SchemaCatalog.cs

SchemaCatalogData.cs : SchemaCatalogData.protocol 
	protogen SchemaCatalogData.protocol  /cs  SchemaCatalogData.cs


prebuildRecurse : 


postbuildRecurse :


prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Catalog.dll

