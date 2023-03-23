
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
    Goedel.Cryptography.Jose.dll\
    Goedel.Protocol.dll\
    Goedel.Utilities.dll\
    Goedel.Mesh.Client.dll\
    Goedel.Mesh.dll

ToolTargets = \
	CallsignResolver.cs\
	Exceptions.cs\
	CallsignLog.cs\
	CallsignConstants.cs

Exceptions.cs : Exceptions.exceptional 
	exceptional Exceptions.exceptional  /cs  Exceptions.cs

CallsignLog.cs : CallsignLog.protocol 
	protogen CallsignLog.protocol  /cs  CallsignLog.cs

CallsignConstants.cs : CallsignConstants.constant 
	constant CallsignConstants.constant  /cs  CallsignConstants.cs

CallsignResolver.cs : CallsignResolver.protocol 
	protogen CallsignResolver.protocol  /cs  CallsignResolver.cs

prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)
	

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Callsign.dll

