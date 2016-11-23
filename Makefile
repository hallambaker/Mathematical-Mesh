#
# Makefile for Visual Studio Solution ..
#
# This file is generated automatically from the Visual Studio Project
# File. If you make changes to this file and do not update the project
# file, changes will be lost when the file is regenerated.

# NB: This process will fail if any of the paths have spaces in them
# While it is possible to work around the lack of support for spaces in 
# file paths in gmake, it is not possible to do this reliably in the tools
# that it invokes to build the system. Rather than do half a job, it seems
# safest to simply reject the corner case


# The following targets are defined (well planned)
#
# make 			Compile for the current platform
# make cross		Compile for all platforms
# make install		Compile and install
# make clean		Delete all target and intermediate files

# The following build flags are supported
#
# make mode= release | debug			Build release or debug version
# make arch= this | all | <x>			Bundle for the current platform, all platforms
#										or the specified platform

# Define the default target directories (referenced projects must all follow same scheme)
#
# By default, we arrange the mono targets as follows:
#
# <Source>					The source code directory
# <Source>/mono/			Equivalent to VS bin directory
# <Source>/mono/Debug		Equivalent to VS bin/Debug directory
# <Source>/mono/Release	Equivalent to VS bin/Debug directory
#
# If the target is an executable, the following directories are also created:
#
# <Source>/This			The bundled executable for the platform the code was compiled on
# <Source>/<Arch1>			The bundled executable for the platform <Arch1>	
#
# If the install target is selected, the bundles will be installed in
#
# ~/Tools/This				The bundled executable for platform the code is built on
# ~/Tools/<Arch1>			The bundled executable for this platform <Arch1>	

export TARGETROOT		?= mono
export MODE				?= Release
export ARCH				?= This
export Packages			?= $(HOME)/Packages
export PackagesPath		?= /lib/net40
export Libraries		?= $(HOME)/Libraries
export LibrariesPath	?= /Mono


export TARGETBIN	= $(TARGETROOT)/$(MODE)
export TARGETEXE	= $(TARGETROOT)/$(ARCH)
export LIBRARYBIN	= $(Libraries)$(LibrariesPath)

export DESTDIR		?= $(HOME)/.local
export bindir		?= /bin
export libdir		?= /lib
export INSTALL_PROGRAM	?= $(DESTDIR)$(bindir)
export INSTALL_DATA		?= $(DESTDIR)$(libdir)

# Define the default compilers, linkers, packagers, etc.
export CSHARPDLL	?=  mcs /target:library
export CSHARPEXE	?=  mcs /target:exe
export BUNDLE		?=  mkbundle --deps --static -o 



# The following tools are used in the goedel build system itself:
export Custom_RFC2TXT		?= rfctool /in
export Custom_RFC2TXT_FLAG	?= /txt
export Custom_RFC2XML		?= rfctool /in
export Custom_RFC2XML_FLAG	?= /xml
export Custom_RFC2MD		?= rfctool /in
export Custom_RFC2MD_FLAG	?= /md
export Custom_RFC2HTML		?= rfctool /in
export Custom_RFC2HTML_FLAG	?= /html
export Custom_CommandCS		?= commandparse /in
export Custom_CommandCS_FLAG	?= /cs
export Custom_FSRCS		?= fsrgen /in
export Custom_FSRCS_FLAG	?= /cs
export Custom_Exceptional		?= exceptional /in
export Custom_Exceptional_FLAG	?= /cs
export Custom_GScript		?= gscript /in
export Custom_GScript_FLAG	?= /cs
export Custom_Goedel3		?= goedel3 /in
export Custom_Goedel3_FLAG	?= /cs
export Custom_ASN2CS		?= asn2 /in
export Custom_ASN2CS_FLAG	?= /cs
export Custom_DomainerCS		?= domainer /in
export Custom_DomainerCS_FLAG	?= /cs
export Custom_RegistryCS		?= registryconfig /in
export Custom_RegistryCS_FLAG	?= /cs
export Custom_VSIXBuild		?= vsixbuild /in
export Custom_VSIXBuild_FLAG	?= /cs
export Custom_ProtoGen		?= protogen /in
export Custom_ProtoGen_FLAG	?= /cs
export Custom_TrojanGTK		?= trojan /gtk
export Custom_TrojanGTK_FLAG	?= /cs

# Use the specified character as the prefix character. Note this may not 
# be supported on versions of make other than gmake.
.RECIPEPREFIX = ! 

# The main target

.PHONY : all always clean install publish cross

# Need to identify the target directory using UnixPath()
# This file in directory 

# Project : DumpLog.exe
# Item :  AdminDumpLog
# Output :     AdminDumpLog/$(TARGETEXE)/DumpLog.exe

all : AdminDumpLog/$(TARGETBIN)/DumpLog.exe

AdminDumpLog/$(TARGETBIN)/DumpLog.exe : Goedel.Persistence/$(TARGETBIN)/Goedel.Persistence.dll

AdminDumpLog/$(TARGETBIN)/DumpLog.exe : Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll


AdminDumpLog/$(TARGETBIN)/DumpLog.exe : always
! echo "" >&2
! echo "*** Directory AdminDumpLog" >&2
! make NORECURSE=true -C AdminDumpLog

# Project : Goedel.Persistence.dll
# Item :  Goedel.Persistence
# Output :     Goedel.Persistence/$(TARGETBIN)/Goedel.Persistence.dll

all : Goedel.Persistence/$(TARGETBIN)/Goedel.Persistence.dll


Goedel.Persistence/$(TARGETBIN)/Goedel.Persistence.dll : always
! echo "" >&2
! echo "*** Directory Goedel.Persistence" >&2
! make NORECURSE=true -C Goedel.Persistence

# Project : Goedel.Mesh.dll
# Item :  Goedel.Mesh
# Output :     Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll

all : Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll

Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll : Goedel.Persistence/$(TARGETBIN)/Goedel.Persistence.dll


Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll : always
! echo "" >&2
! echo "*** Directory Goedel.Mesh" >&2
! make NORECURSE=true -C Goedel.Mesh

# Project : Goedel.Mesh.Server.dll
# Item :  Goedel.Mesh.Server
# Output :     Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll

all : Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll

Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll : Goedel.Persistence/$(TARGETBIN)/Goedel.Persistence.dll

Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll : Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll


Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll : always
! echo "" >&2
! echo "*** Directory Goedel.Mesh.Server" >&2
! make NORECURSE=true -C Goedel.Mesh.Server

# Project : RunMesh.exe
# Item :  RunMesh
# Output :     RunMesh/$(TARGETEXE)/RunMesh.exe

all : RunMesh/$(TARGETBIN)/RunMesh.exe

RunMesh/$(TARGETBIN)/RunMesh.exe : Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll

RunMesh/$(TARGETBIN)/RunMesh.exe : Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll

RunMesh/$(TARGETBIN)/RunMesh.exe : Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll

RunMesh/$(TARGETBIN)/RunMesh.exe : Goedel.Persistence/$(TARGETBIN)/Goedel.Persistence.dll


RunMesh/$(TARGETBIN)/RunMesh.exe : always
! echo "" >&2
! echo "*** Directory RunMesh" >&2
! make NORECURSE=true -C RunMesh

# Project : ServerMesh.exe
# Item :  ServerMesh
# Output :     ServerMesh/$(TARGETEXE)/ServerMesh.exe

all : ServerMesh/$(TARGETBIN)/ServerMesh.exe

ServerMesh/$(TARGETBIN)/ServerMesh.exe : Goedel.Persistence/$(TARGETBIN)/Goedel.Persistence.dll

ServerMesh/$(TARGETBIN)/ServerMesh.exe : Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll

ServerMesh/$(TARGETBIN)/ServerMesh.exe : Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll


ServerMesh/$(TARGETBIN)/ServerMesh.exe : always
! echo "" >&2
! echo "*** Directory ServerMesh" >&2
! make NORECURSE=true -C ServerMesh

# Project : Goedel.Mesh.Client.dll
# Item :  Goedel.Mesh.Client
# Output :     Goedel.Mesh.Client/$(TARGETBIN)/Goedel.Mesh.Client.dll

all : Goedel.Mesh.Client/$(TARGETBIN)/Goedel.Mesh.Client.dll


Goedel.Mesh.Client/$(TARGETBIN)/Goedel.Mesh.Client.dll : always
! echo "" >&2
! echo "*** Directory Goedel.Mesh.Client" >&2
! make NORECURSE=true -C Goedel.Mesh.Client

# Project : Goedel.Platform.Windows.dll
# Item :  Goedel.Platform.Windows
# Output :     Goedel.Platform.Windows/$(TARGETBIN)/Goedel.Platform.Windows.dll

all : Goedel.Platform.Windows/$(TARGETBIN)/Goedel.Platform.Windows.dll


Goedel.Platform.Windows/$(TARGETBIN)/Goedel.Platform.Windows.dll : always
! echo "" >&2
! echo "*** Directory Goedel.Platform.Windows" >&2
! make NORECURSE=true -C Goedel.Platform.Windows

# Project : Goedel.Mesh.Platform.Windows.dll
# Item :  Goedel.Mesh.Platform.Windows
# Output :     Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll

all : Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll

Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll : Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll

Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll : Goedel.Platform.Windows/$(TARGETBIN)/Goedel.Platform.Windows.dll


Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll : always
! echo "" >&2
! echo "*** Directory Goedel.Mesh.Platform.Windows" >&2
! make NORECURSE=true -C Goedel.Mesh.Platform.Windows

# Project : meshman.exe
# Item :  meshman
# Output :     meshman/$(TARGETEXE)/meshman.exe

all : meshman/$(TARGETBIN)/meshman.exe

meshman/$(TARGETBIN)/meshman.exe : Goedel.Mesh.Client/$(TARGETBIN)/Goedel.Mesh.Client.dll

meshman/$(TARGETBIN)/meshman.exe : Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll

meshman/$(TARGETBIN)/meshman.exe : Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll

meshman/$(TARGETBIN)/meshman.exe : Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll

meshman/$(TARGETBIN)/meshman.exe : Goedel.Persistence/$(TARGETBIN)/Goedel.Persistence.dll


meshman/$(TARGETBIN)/meshman.exe : always
! echo "" >&2
! echo "*** Directory meshman" >&2
! make NORECURSE=true -C meshman

# Project : InternetDrafts.exe
# Item :  Documentation/Specification
# Output :     Documentation/Specification/$(TARGETEXE)/InternetDrafts.exe

all : Documentation/Specification/$(TARGETBIN)/InternetDrafts.exe

Documentation/Specification/$(TARGETBIN)/InternetDrafts.exe : Goedel.Mesh.Client/$(TARGETBIN)/Goedel.Mesh.Client.dll

Documentation/Specification/$(TARGETBIN)/InternetDrafts.exe : Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll

Documentation/Specification/$(TARGETBIN)/InternetDrafts.exe : Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll

Documentation/Specification/$(TARGETBIN)/InternetDrafts.exe : Goedel.Persistence/$(TARGETBIN)/Goedel.Persistence.dll


Documentation/Specification/$(TARGETBIN)/InternetDrafts.exe : always
! echo "" >&2
! echo "*** Directory Documentation/Specification" >&2
! make NORECURSE=true -C Documentation/Specification



# clean all projects
clean :
! make clean NORECURSE=true -C AdminDumpLog
! make clean NORECURSE=true -C Goedel.Persistence
! make clean NORECURSE=true -C Goedel.Mesh
! make clean NORECURSE=true -C Goedel.Mesh.Server
! make clean NORECURSE=true -C RunMesh
! make clean NORECURSE=true -C ServerMesh
! make clean NORECURSE=true -C Goedel.Mesh.Client
! make clean NORECURSE=true -C Goedel.Platform.Windows
! make clean NORECURSE=true -C Goedel.Mesh.Platform.Windows
! make clean NORECURSE=true -C meshman
! make clean NORECURSE=true -C Documentation/Specification

# publish all projects
publish : all
! make publish NORECURSE=true -C AdminDumpLog
! make publish NORECURSE=true -C Goedel.Persistence
! make publish NORECURSE=true -C Goedel.Mesh
! make publish NORECURSE=true -C Goedel.Mesh.Server
! make publish NORECURSE=true -C RunMesh
! make publish NORECURSE=true -C ServerMesh
! make publish NORECURSE=true -C Goedel.Mesh.Client
! make publish NORECURSE=true -C Goedel.Platform.Windows
! make publish NORECURSE=true -C Goedel.Mesh.Platform.Windows
! make publish NORECURSE=true -C meshman
! make publish NORECURSE=true -C Documentation/Specification

# install all projects
install : all
! make install NORECURSE=true -C AdminDumpLog
! make install NORECURSE=true -C Goedel.Persistence
! make install NORECURSE=true -C Goedel.Mesh
! make install NORECURSE=true -C Goedel.Mesh.Server
! make install NORECURSE=true -C RunMesh
! make install NORECURSE=true -C ServerMesh
! make install NORECURSE=true -C Goedel.Mesh.Client
! make install NORECURSE=true -C Goedel.Platform.Windows
! make install NORECURSE=true -C Goedel.Mesh.Platform.Windows
! make install NORECURSE=true -C meshman
! make install NORECURSE=true -C Documentation/Specification

