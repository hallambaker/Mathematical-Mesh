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

# Project : Goedel.Confirm.dll
# Item :  Goedel.Confirm
# Output :     Goedel.Confirm/$(TARGETBIN)/Goedel.Confirm.dll

all : Goedel.Confirm/$(TARGETBIN)/Goedel.Confirm.dll


Goedel.Confirm/$(TARGETBIN)/Goedel.Confirm.dll : always
! echo "" >&2
! echo "*** Directory Goedel.Confirm" >&2
! make NORECURSE=true -C Goedel.Confirm

# Project : Goedel.Confirm.Client.dll
# Item :  Goedel.Confirm.Client
# Output :     Goedel.Confirm.Client/$(TARGETBIN)/Goedel.Confirm.Client.dll

all : Goedel.Confirm.Client/$(TARGETBIN)/Goedel.Confirm.Client.dll

Goedel.Confirm.Client/$(TARGETBIN)/Goedel.Confirm.Client.dll : Goedel.Confirm/$(TARGETBIN)/Goedel.Confirm.dll


Goedel.Confirm.Client/$(TARGETBIN)/Goedel.Confirm.Client.dll : always
! echo "" >&2
! echo "*** Directory Goedel.Confirm.Client" >&2
! make NORECURSE=true -C Goedel.Confirm.Client

# Project : Goedel.Confirm.Server.dll
# Item :  Goedel.Confirm.Server
# Output :     Goedel.Confirm.Server/$(TARGETBIN)/Goedel.Confirm.Server.dll

all : Goedel.Confirm.Server/$(TARGETBIN)/Goedel.Confirm.Server.dll

Goedel.Confirm.Server/$(TARGETBIN)/Goedel.Confirm.Server.dll : Goedel.Confirm/$(TARGETBIN)/Goedel.Confirm.dll


Goedel.Confirm.Server/$(TARGETBIN)/Goedel.Confirm.Server.dll : always
! echo "" >&2
! echo "*** Directory Goedel.Confirm.Server" >&2
! make NORECURSE=true -C Goedel.Confirm.Server

# Project : Goedel.Confirm.Shell.Server.exe
# Item :  Goedel.Confirm.Shell.Server
# Output :     Goedel.Confirm.Shell.Server/$(TARGETEXE)/Goedel.Confirm.Shell.Server.exe

all : Goedel.Confirm.Shell.Server/$(TARGETBIN)/Goedel.Confirm.Shell.Server.exe

Goedel.Confirm.Shell.Server/$(TARGETBIN)/Goedel.Confirm.Shell.Server.exe : Goedel.Confirm.Server/$(TARGETBIN)/Goedel.Confirm.Server.dll

Goedel.Confirm.Shell.Server/$(TARGETBIN)/Goedel.Confirm.Shell.Server.exe : Goedel.Confirm/$(TARGETBIN)/Goedel.Confirm.dll


Goedel.Confirm.Shell.Server/$(TARGETBIN)/Goedel.Confirm.Shell.Server.exe : always
! echo "" >&2
! echo "*** Directory Goedel.Confirm.Shell.Server" >&2
! make NORECURSE=true -C Goedel.Confirm.Shell.Server

# Project : Goedel.Confirm.Documentation.exe
# Item :  Goedel.Confirm.Documentation
# Output :     Goedel.Confirm.Documentation/$(TARGETEXE)/Goedel.Confirm.Documentation.exe

all : Goedel.Confirm.Documentation/$(TARGETBIN)/Goedel.Confirm.Documentation.exe

Goedel.Confirm.Documentation/$(TARGETBIN)/Goedel.Confirm.Documentation.exe : Goedel.Confirm.Client/$(TARGETBIN)/Goedel.Confirm.Client.dll

Goedel.Confirm.Documentation/$(TARGETBIN)/Goedel.Confirm.Documentation.exe : Goedel.Confirm.Server/$(TARGETBIN)/Goedel.Confirm.Server.dll

Goedel.Confirm.Documentation/$(TARGETBIN)/Goedel.Confirm.Documentation.exe : Goedel.Confirm/$(TARGETBIN)/Goedel.Confirm.dll


Goedel.Confirm.Documentation/$(TARGETBIN)/Goedel.Confirm.Documentation.exe : always
! echo "" >&2
! echo "*** Directory Goedel.Confirm.Documentation" >&2
! make NORECURSE=true -C Goedel.Confirm.Documentation

# Project : confirmclient.exe
# Item :  Goedel.Confirm.Shell.Client
# Output :     Goedel.Confirm.Shell.Client/$(TARGETEXE)/confirmclient.exe

all : Goedel.Confirm.Shell.Client/$(TARGETBIN)/confirmclient.exe

Goedel.Confirm.Shell.Client/$(TARGETBIN)/confirmclient.exe : Goedel.Confirm.Client/$(TARGETBIN)/Goedel.Confirm.Client.dll

Goedel.Confirm.Shell.Client/$(TARGETBIN)/confirmclient.exe : Goedel.Confirm/$(TARGETBIN)/Goedel.Confirm.dll


Goedel.Confirm.Shell.Client/$(TARGETBIN)/confirmclient.exe : always
! echo "" >&2
! echo "*** Directory Goedel.Confirm.Shell.Client" >&2
! make NORECURSE=true -C Goedel.Confirm.Shell.Client

# Project : Test.Confirm.dll
# Item :  Test.Confirm
# Output :     Test.Confirm/$(TARGETBIN)/Test.Confirm.dll

all : Test.Confirm/$(TARGETBIN)/Test.Confirm.dll

Test.Confirm/$(TARGETBIN)/Test.Confirm.dll : Goedel.Confirm.Client/$(TARGETBIN)/Goedel.Confirm.Client.dll

Test.Confirm/$(TARGETBIN)/Test.Confirm.dll : Goedel.Confirm.Server/$(TARGETBIN)/Goedel.Confirm.Server.dll

Test.Confirm/$(TARGETBIN)/Test.Confirm.dll : Goedel.Confirm/$(TARGETBIN)/Goedel.Confirm.dll


Test.Confirm/$(TARGETBIN)/Test.Confirm.dll : always
! echo "" >&2
! echo "*** Directory Test.Confirm" >&2
! make NORECURSE=true -C Test.Confirm



# clean all projects
clean :
! make clean NORECURSE=true -C Goedel.Confirm
! make clean NORECURSE=true -C Goedel.Confirm.Client
! make clean NORECURSE=true -C Goedel.Confirm.Server
! make clean NORECURSE=true -C Goedel.Confirm.Shell.Server
! make clean NORECURSE=true -C Goedel.Confirm.Documentation
! make clean NORECURSE=true -C Goedel.Confirm.Shell.Client
! make clean NORECURSE=true -C Test.Confirm

# publish all projects
publish : all
! make publish NORECURSE=true -C Goedel.Confirm
! make publish NORECURSE=true -C Goedel.Confirm.Client
! make publish NORECURSE=true -C Goedel.Confirm.Server
! make publish NORECURSE=true -C Goedel.Confirm.Shell.Server
! make publish NORECURSE=true -C Goedel.Confirm.Documentation
! make publish NORECURSE=true -C Goedel.Confirm.Shell.Client
! make publish NORECURSE=true -C Test.Confirm

# install all projects
install : all
! make install NORECURSE=true -C Goedel.Confirm
! make install NORECURSE=true -C Goedel.Confirm.Client
! make install NORECURSE=true -C Goedel.Confirm.Server
! make install NORECURSE=true -C Goedel.Confirm.Shell.Server
! make install NORECURSE=true -C Goedel.Confirm.Documentation
! make install NORECURSE=true -C Goedel.Confirm.Shell.Client
! make install NORECURSE=true -C Test.Confirm

