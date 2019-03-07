
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
    Goedel.IO.dll\
    Goedel.Utilities.dll\
    Goedel.Cryptography.Jose.dll\
    Goedel.Protocol.dll

ToolTargets = \
	ContainerEntry.cs\
	DareSchema.cs\
	Exceptions.cs
ContainerEntry.cs : ContainerEntry.pschema 
	protogen ContainerEntry.pschema  /cs  ContainerEntry.cs

DareSchema.cs : DareSchema.Protocol 
	protogen DareSchema.Protocol  /cs  DareSchema.cs

Exceptions.cs : Exceptions.exceptional 
	exceptional Exceptions.exceptional  /cs  Exceptions.cs



prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Cryptography.Dare.dll

