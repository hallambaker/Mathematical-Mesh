
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
    Goedel.Protocol.dll

ToolTargets = \
	CalendarSchema.cs\
	ContactSchema.cs\
	Exceptions.cs\
	ContactConstants.cs
CalendarSchema.cs : CalendarSchema.Protocol 
	protogen CalendarSchema.Protocol  /cs  CalendarSchema.cs

ContactSchema.cs : ContactSchema.Protocol 
#	protogen ContactSchema.Protocol  /cs  ContactSchema.cs

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

