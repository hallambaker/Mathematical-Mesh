
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
    Goedel.Utilities.dll

ToolTargets = \
	Exceptions.cs\
	PKIX\PKIX.cs

Exceptions.cs : Exceptions.exceptional 
	exceptional Exceptions.exceptional  /cs  Exceptions.cs

PKIX\PKIX.cs : PKIX\PKIX.asn2 
	asn2 PKIX\PKIX.asn2  /cs  PKIX\PKIX.cs


prebuildRecurse : 


postbuildRecurse :


prebuild : prebuildRecurse $(ToolTargets)

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Cryptography.dll

