
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
    Goedel.Cryptography.dll\
    Goedel.Protocol.dll

ToolTargets = \
	DareSchema.cs\
	Exceptions.cs\
	JoseSchema.cs

DareSchema.cs : DareSchema.Protocol 
	protogen DareSchema.Protocol  /cs  DareSchema.cs

Exceptions.cs : Exceptions.exceptional 
	exceptional Exceptions.exceptional  /cs  Exceptions.cs

JoseSchema.cs : JoseSchema.Protocol 
	protogen JoseSchema.Protocol  /cs  JoseSchema.cs


prebuildRecurse : 


postbuildRecurse :


prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Cryptography.Jose.dll

