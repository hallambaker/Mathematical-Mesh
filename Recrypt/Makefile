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

# Project : Goedel.Recrypt.dll
# Item :  Goedel.Recrypt
# Output :     Goedel.Recrypt/$(TARGETBIN)/Goedel.Recrypt.dll

all : Goedel.Recrypt/$(TARGETBIN)/Goedel.Recrypt.dll


Goedel.Recrypt/$(TARGETBIN)/Goedel.Recrypt.dll : always
! echo "" >&2
! echo "*** Directory Goedel.Recrypt" >&2
! make NORECURSE=true -C Goedel.Recrypt

# Project : Goedel.Recrypt.Client.dll
# Item :  Goedel.Recrypt.Client
# Output :     Goedel.Recrypt.Client/$(TARGETBIN)/Goedel.Recrypt.Client.dll

all : Goedel.Recrypt.Client/$(TARGETBIN)/Goedel.Recrypt.Client.dll

Goedel.Recrypt.Client/$(TARGETBIN)/Goedel.Recrypt.Client.dll : Goedel.Recrypt/$(TARGETBIN)/Goedel.Recrypt.dll


Goedel.Recrypt.Client/$(TARGETBIN)/Goedel.Recrypt.Client.dll : always
! echo "" >&2
! echo "*** Directory Goedel.Recrypt.Client" >&2
! make NORECURSE=true -C Goedel.Recrypt.Client

# Project : Goedel.Recrypt.Server.dll
# Item :  Goedel.Recrypt.Server
# Output :     Goedel.Recrypt.Server/$(TARGETBIN)/Goedel.Recrypt.Server.dll

all : Goedel.Recrypt.Server/$(TARGETBIN)/Goedel.Recrypt.Server.dll

Goedel.Recrypt.Server/$(TARGETBIN)/Goedel.Recrypt.Server.dll : Goedel.Recrypt/$(TARGETBIN)/Goedel.Recrypt.dll


Goedel.Recrypt.Server/$(TARGETBIN)/Goedel.Recrypt.Server.dll : always
! echo "" >&2
! echo "*** Directory Goedel.Recrypt.Server" >&2
! make NORECURSE=true -C Goedel.Recrypt.Server

# Project : Goedel.Recrypt.Shell.Server.exe
# Item :  Goedel.Recrypt.Shell.Server
# Output :     Goedel.Recrypt.Shell.Server/$(TARGETEXE)/Goedel.Recrypt.Shell.Server.exe

all : Goedel.Recrypt.Shell.Server/$(TARGETBIN)/Goedel.Recrypt.Shell.Server.exe

Goedel.Recrypt.Shell.Server/$(TARGETBIN)/Goedel.Recrypt.Shell.Server.exe : Goedel.Recrypt.Server/$(TARGETBIN)/Goedel.Recrypt.Server.dll

Goedel.Recrypt.Shell.Server/$(TARGETBIN)/Goedel.Recrypt.Shell.Server.exe : Goedel.Recrypt/$(TARGETBIN)/Goedel.Recrypt.dll


Goedel.Recrypt.Shell.Server/$(TARGETBIN)/Goedel.Recrypt.Shell.Server.exe : always
! echo "" >&2
! echo "*** Directory Goedel.Recrypt.Shell.Server" >&2
! make NORECURSE=true -C Goedel.Recrypt.Shell.Server

# Project : Goedel.Recrypt.Documentation.exe
# Item :  Goedel.Recrypt.Documentation
# Output :     Goedel.Recrypt.Documentation/$(TARGETEXE)/Goedel.Recrypt.Documentation.exe

all : Goedel.Recrypt.Documentation/$(TARGETBIN)/Goedel.Recrypt.Documentation.exe

Goedel.Recrypt.Documentation/$(TARGETBIN)/Goedel.Recrypt.Documentation.exe : Goedel.Recrypt.Client/$(TARGETBIN)/Goedel.Recrypt.Client.dll

Goedel.Recrypt.Documentation/$(TARGETBIN)/Goedel.Recrypt.Documentation.exe : Goedel.Recrypt.Server/$(TARGETBIN)/Goedel.Recrypt.Server.dll

Goedel.Recrypt.Documentation/$(TARGETBIN)/Goedel.Recrypt.Documentation.exe : Goedel.Recrypt/$(TARGETBIN)/Goedel.Recrypt.dll


Goedel.Recrypt.Documentation/$(TARGETBIN)/Goedel.Recrypt.Documentation.exe : always
! echo "" >&2
! echo "*** Directory Goedel.Recrypt.Documentation" >&2
! make NORECURSE=true -C Goedel.Recrypt.Documentation

# Project : Goedel.Shell.Recrypt.exe
# Item :  Goedel.Recrypt.Shell.Client
# Output :     Goedel.Recrypt.Shell.Client/$(TARGETEXE)/Goedel.Shell.Recrypt.exe

all : Goedel.Recrypt.Shell.Client/$(TARGETBIN)/Goedel.Shell.Recrypt.exe

Goedel.Recrypt.Shell.Client/$(TARGETBIN)/Goedel.Shell.Recrypt.exe : Goedel.Recrypt.Client/$(TARGETBIN)/Goedel.Recrypt.Client.dll

Goedel.Recrypt.Shell.Client/$(TARGETBIN)/Goedel.Shell.Recrypt.exe : Goedel.Recrypt/$(TARGETBIN)/Goedel.Recrypt.dll


Goedel.Recrypt.Shell.Client/$(TARGETBIN)/Goedel.Shell.Recrypt.exe : always
! echo "" >&2
! echo "*** Directory Goedel.Recrypt.Shell.Client" >&2
! make NORECURSE=true -C Goedel.Recrypt.Shell.Client



# clean all projects
clean :
! make clean NORECURSE=true -C Goedel.Recrypt
! make clean NORECURSE=true -C Goedel.Recrypt.Client
! make clean NORECURSE=true -C Goedel.Recrypt.Server
! make clean NORECURSE=true -C Goedel.Recrypt.Shell.Server
! make clean NORECURSE=true -C Goedel.Recrypt.Documentation
! make clean NORECURSE=true -C Goedel.Recrypt.Shell.Client

# publish all projects
publish : all
! make publish NORECURSE=true -C Goedel.Recrypt
! make publish NORECURSE=true -C Goedel.Recrypt.Client
! make publish NORECURSE=true -C Goedel.Recrypt.Server
! make publish NORECURSE=true -C Goedel.Recrypt.Shell.Server
! make publish NORECURSE=true -C Goedel.Recrypt.Documentation
! make publish NORECURSE=true -C Goedel.Recrypt.Shell.Client

# install all projects
install : all
! make install NORECURSE=true -C Goedel.Recrypt
! make install NORECURSE=true -C Goedel.Recrypt.Client
! make install NORECURSE=true -C Goedel.Recrypt.Server
! make install NORECURSE=true -C Goedel.Recrypt.Shell.Server
! make install NORECURSE=true -C Goedel.Recrypt.Documentation
! make install NORECURSE=true -C Goedel.Recrypt.Shell.Client

