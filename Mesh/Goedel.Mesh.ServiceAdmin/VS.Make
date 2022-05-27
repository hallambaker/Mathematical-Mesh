
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
    Goedel.Callsign.Registry.dll\
    Goedel.Callsign.Resolver.dll\
    Goedel.Callsign.dll\
    Goedel.Carnet.Server.dll\
    Goedel.Carnet.dll\
    Goedel.Cryptography.Dare.dll\
    Goedel.Cryptography.dll\
    Goedel.Protocol.GenericHost.dll\
    Goedel.Protocol.Presentation.dll\
    Goedel.Protocol.Service.dll\
    Goedel.Protocol.dll\
    Goedel.Registry.dll\
    Goedel.Utilities.dll\
    Goedel.Presence.Server.dll\
    Goedel.Presence.dll\
    Goedel.Repository.Server.dll\
    Goedel.Repository.dll\
    Goedel.Mesh.Server.dll\
    Goedel.Mesh.dll

ToolTargets = \
	DnsConfig.cs\
	Exceptions.cs
DnsConfig.cs : DnsConfig.script 
	gscript DnsConfig.script  DnsConfig.cs

Exceptions.cs : Exceptions.exceptional 
	exceptional Exceptions.exceptional  /cs  Exceptions.cs



prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)
	

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Mesh.ServiceAdmin.dll

