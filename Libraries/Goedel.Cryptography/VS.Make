
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
    Goedel.ASN.dll\
    Goedel.Cryptography.Identifiers.dll\
    Goedel.Cryptography.Nist.dll\
    Goedel.IO.dll\
    Goedel.Utilities.dll

ToolTargets = \
	PKIX\PKIX.cs
PKIX\PKIX.cs : PKIX\PKIX.asn2 
	asn2 PKIX\PKIX.asn2  /cs  PKIX\PKIX.cs



prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)
	

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Cryptography.dll

