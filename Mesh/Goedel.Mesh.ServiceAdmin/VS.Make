
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
    Goedel.Cryptography.Dare.dll\
    Goedel.Cryptography.dll\
    Goedel.Protocol.Presentation.dll\
    Goedel.Protocol.dll\
    Goedel.Registry.dll\
    Goedel.Utilities.dll\
    Goedel.Mesh.dll

ToolTargets = \
	DnsConfig.cs\
	Exceptions.cs\
	ServiceProtocol.cs
DnsConfig.cs : DnsConfig.script 
	gscript DnsConfig.script  DnsConfig.cs

Exceptions.cs : Exceptions.exceptional 
	exceptional Exceptions.exceptional  /cs  Exceptions.cs

ServiceProtocol.cs : ServiceProtocol.Protocol 
	protogen ServiceProtocol.Protocol  /cs  ServiceProtocol.cs



prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)
	version version.version AssemblyVersion.cs
	

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Mesh.ServiceAdmin.dll

