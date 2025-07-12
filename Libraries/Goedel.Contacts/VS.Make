
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
    Goedel.Cryptography.dll\
    Goedel.Discovery.dll\
    Goedel.IO.dll\
    Goedel.Utilities.dll\
    Goedel.Protocol.dll

ToolTargets = \
	JmapBase.cs\
	CalendarSchema.cs\
	DeviceSchema.cs\
	ContactSchema.cs\
	Exceptions.cs\
	ContactConstants.cs
JmapBase.cs : JmapBase.Protocol 
	protogen JmapBase.Protocol  /cs  JmapBase.cs

CalendarSchema.cs : CalendarSchema.Protocol 
	protogen CalendarSchema.Protocol  /cs  CalendarSchema.cs

DeviceSchema.cs : DeviceSchema.Protocol 
	protogen DeviceSchema.Protocol  /cs  DeviceSchema.cs

ContactSchema.cs : ContactSchema.Protocol 
	protogen ContactSchema.Protocol  /cs  ContactSchema.cs

Exceptions.cs : Exceptions.exceptional 
	exceptional Exceptions.exceptional  /cs  Exceptions.cs

ContactConstants.cs : ContactConstants.constant 
	constant ContactConstants.constant  /cs  ContactConstants.cs



prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)
	

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget Goedel.Contacts.dll

