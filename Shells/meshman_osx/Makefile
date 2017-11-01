#
# Makefile for Visual Studio Project meshman_osx
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

SourceFiles = \
     Main.cs\
     Properties/AssemblyInfo.cs

LinkFiles = \
    $(TARGETBIN)/Goedel.Command.dll\
    $(TARGETBIN)/Goedel.Discovery.dll\
    $(TARGETBIN)/Goedel.Protocol.dll\
    $(TARGETBIN)/Goedel.Utilities.dll\
    $(TARGETBIN)/Goedel.Mesh.Client.dll\
    $(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll\
    $(TARGETBIN)/Goedel.Mesh.Platform.dll\
    $(TARGETBIN)/Goedel.Mesh.Server.dll\
    $(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll\
    $(TARGETBIN)/Goedel.Mesh.dll

LinkFilesComma = $(TARGETBIN)/Goedel.Command.dll,$(TARGETBIN)/Goedel.Discovery.dll,$(TARGETBIN)/Goedel.Protocol.dll,$(TARGETBIN)/Goedel.Utilities.dll,$(TARGETBIN)/Goedel.Mesh.Client.dll,$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll,$(TARGETBIN)/Goedel.Mesh.Platform.dll,$(TARGETBIN)/Goedel.Mesh.Server.dll,$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll,$(TARGETBIN)/Goedel.Mesh.dll


NugetFiles = 
NugetFilesComa = 

# A) Main target packaged
$(TARGETEXE)/meshman_osx :| $(TARGETEXE)
$(TARGETEXE)/meshman_osx : $(TARGETBIN)/meshman_osx.exe 
! $(BUNDLE) $@ $^ $(LinkFiles)  $(NugetFiles)

# B) Main target executable
$(TARGETBIN)/meshman_osx.exe :| $(TARGETBIN)
$(TARGETBIN)/meshman_osx.exe : $(SourceFiles) $(LinkFiles) $(NugetFiles)
! $(CSHARPEXE) /out:$@  $(SourceFiles) -reference:$(LinkFilesComma) 


# Directories etc.

$(INSTALL_PROGRAM) :
! mkdir -p $(INSTALL_PROGRAM) 

$(INSTALL_DATA) :
! mkdir -p $(INSTALL_DATA) 

$(TARGETBIN) :
! mkdir -p $(TARGETBIN) 

$(TARGETEXE) :
! mkdir -p $(TARGETEXE) 

$(LIBRARYBIN) :
! mkdir -p $(LIBRARYBIN)

# Generated code

ifdef PHB_BUILD


endif

.PHONY : clean install publish debian rpm


# Referenced projects
#

# Recursive make targets, do not execute if the variable NORECURSE is defined
ifndef NORECURSE

../../../buildtools/Libraries/Goedel.Command/$(TARGETBIN)/Goedel.Command.dll : recursive
! $(MAKE) -C ../../../buildtools/Libraries/Goedel.Command

../../../buildtools/Libraries/Goedel.Discovery/$(TARGETBIN)/Goedel.Discovery.dll : recursive
! $(MAKE) -C ../../../buildtools/Libraries/Goedel.Discovery

../../../buildtools/Libraries/Goedel.Protocol/$(TARGETBIN)/Goedel.Protocol.dll : recursive
! $(MAKE) -C ../../../buildtools/Libraries/Goedel.Protocol

../../../buildtools/Libraries/Goedel.Utilities/$(TARGETBIN)/Goedel.Utilities.dll : recursive
! $(MAKE) -C ../../../buildtools/Libraries/Goedel.Utilities

../../Mesh/Goedel.Mesh.Client/$(TARGETBIN)/Goedel.Mesh.Client.dll : recursive
! $(MAKE) -C ../../Mesh/Goedel.Mesh.Client

../../Mesh/Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll : recursive
! $(MAKE) -C ../../Mesh/Goedel.Mesh.Platform.Windows

../../Mesh/Goedel.Mesh.Platform/$(TARGETBIN)/Goedel.Mesh.Platform.dll : recursive
! $(MAKE) -C ../../Mesh/Goedel.Mesh.Platform

../../Mesh/Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll : recursive
! $(MAKE) -C ../../Mesh/Goedel.Mesh.Server

../Goedel.Mesh.Shell.MeshMan/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll : recursive
! $(MAKE) -C ../Goedel.Mesh.Shell.MeshMan

../../Mesh/Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll : recursive
! $(MAKE) -C ../../Mesh/Goedel.Mesh

endif

$(TARGETBIN)/Goedel.Command.dll :| $(TARGETBIN)
$(TARGETBIN)/Goedel.Command.dll : ../../../buildtools/Libraries/Goedel.Command/$(TARGETBIN)/Goedel.Command.dll
!  cp ../../../buildtools/Libraries/Goedel.Command/$(TARGETBIN)/Goedel.Command.dll $(TARGETBIN)/Goedel.Command.dll

$(TARGETBIN)/Goedel.Discovery.dll :| $(TARGETBIN)
$(TARGETBIN)/Goedel.Discovery.dll : ../../../buildtools/Libraries/Goedel.Discovery/$(TARGETBIN)/Goedel.Discovery.dll
!  cp ../../../buildtools/Libraries/Goedel.Discovery/$(TARGETBIN)/Goedel.Discovery.dll $(TARGETBIN)/Goedel.Discovery.dll

$(TARGETBIN)/Goedel.Protocol.dll :| $(TARGETBIN)
$(TARGETBIN)/Goedel.Protocol.dll : ../../../buildtools/Libraries/Goedel.Protocol/$(TARGETBIN)/Goedel.Protocol.dll
!  cp ../../../buildtools/Libraries/Goedel.Protocol/$(TARGETBIN)/Goedel.Protocol.dll $(TARGETBIN)/Goedel.Protocol.dll

$(TARGETBIN)/Goedel.Utilities.dll :| $(TARGETBIN)
$(TARGETBIN)/Goedel.Utilities.dll : ../../../buildtools/Libraries/Goedel.Utilities/$(TARGETBIN)/Goedel.Utilities.dll
!  cp ../../../buildtools/Libraries/Goedel.Utilities/$(TARGETBIN)/Goedel.Utilities.dll $(TARGETBIN)/Goedel.Utilities.dll

$(TARGETBIN)/Goedel.Mesh.Client.dll :| $(TARGETBIN)
$(TARGETBIN)/Goedel.Mesh.Client.dll : ../../Mesh/Goedel.Mesh.Client/$(TARGETBIN)/Goedel.Mesh.Client.dll
!  cp ../../Mesh/Goedel.Mesh.Client/$(TARGETBIN)/Goedel.Mesh.Client.dll $(TARGETBIN)/Goedel.Mesh.Client.dll

$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll :| $(TARGETBIN)
$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll : ../../Mesh/Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll
!  cp ../../Mesh/Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll $(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll

$(TARGETBIN)/Goedel.Mesh.Platform.dll :| $(TARGETBIN)
$(TARGETBIN)/Goedel.Mesh.Platform.dll : ../../Mesh/Goedel.Mesh.Platform/$(TARGETBIN)/Goedel.Mesh.Platform.dll
!  cp ../../Mesh/Goedel.Mesh.Platform/$(TARGETBIN)/Goedel.Mesh.Platform.dll $(TARGETBIN)/Goedel.Mesh.Platform.dll

$(TARGETBIN)/Goedel.Mesh.Server.dll :| $(TARGETBIN)
$(TARGETBIN)/Goedel.Mesh.Server.dll : ../../Mesh/Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll
!  cp ../../Mesh/Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll $(TARGETBIN)/Goedel.Mesh.Server.dll

$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll :| $(TARGETBIN)
$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll : ../Goedel.Mesh.Shell.MeshMan/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll
!  cp ../Goedel.Mesh.Shell.MeshMan/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll $(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll

$(TARGETBIN)/Goedel.Mesh.dll :| $(TARGETBIN)
$(TARGETBIN)/Goedel.Mesh.dll : ../../Mesh/Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll
!  cp ../../Mesh/Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll $(TARGETBIN)/Goedel.Mesh.dll


# Referenced Libraries
#


# Clean up
#
# At the moment we only delete the currently indicated target. This allows a 
# developer to do a make clean / make when a problem with a corrupted intermediate
# file is suspected.

clean : 
! rm -f $(TARGETBIN)/*
! rm -f $(TARGETEXE)/*

# Install
#
# Install files to a tools directory. Default is ~/.local/bin


install : $(INSTALL_PROGRAM)/meshman_osx 

$(INSTALL_PROGRAM)/meshman_osx  :| $(INSTALL_PROGRAM)
$(INSTALL_PROGRAM)/meshman_osx  : $(TARGETEXE)/meshman_osx 
! cp $^ $@ 




# To Do List
#
# 1) Redo install target
#    Create a wrapper script and library 
# 2) Create a Debian target
# 3) Create a RPM target
# 4) Create a nuget target


