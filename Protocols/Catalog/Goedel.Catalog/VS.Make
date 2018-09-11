
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

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Catalog.dll

