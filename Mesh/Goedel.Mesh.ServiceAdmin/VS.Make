
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
    Goedel.Protocol.dll\
    Goedel.Mesh.dll

ToolTargets = \
	Exceptions.cs\
	ServiceSchema - Copy.cs\
	ServiceSchema.cs
Exceptions.cs : Exceptions.exceptional 
	exceptional Exceptions.exceptional  /cs  Exceptions.cs

ServiceSchema - Copy.cs : ServiceSchema - Copy.Protocol 
	protogen ServiceSchema - Copy.Protocol  /cs  ServiceSchema - Copy.cs

ServiceSchema.cs : ServiceSchema.Protocol 
	protogen ServiceSchema.Protocol  /cs  ServiceSchema.cs



prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)
	version version.version AssemblyVersion.cs
	

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Mesh.ServiceAdmin.dll

