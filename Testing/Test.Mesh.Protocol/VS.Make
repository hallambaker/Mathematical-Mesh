
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
    Goedel.Utilities.dll\
    Goedel.Cryptography.Core.dll\
    Goedel.Cryptography.dll\
    Goedel.Test.Core.dll\
    Goedel.Test.dll\
    Goedel.Mesh.Client.dll\
    Goedel.Mesh.Core.dll\
    Goedel.Mesh.Server.dll\
    Goedel.Mesh.dll\
    Goedel.Presence.Server.dll\
    Goedel.Presence.dll\
    Goedel.Repository.Server.dll\
    Goedel.Repository.dll\
    Goedel.Mesh.Test.dll

ToolTargets = 


prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)
	

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Mesh.Protocol.Test-xunit.dll

