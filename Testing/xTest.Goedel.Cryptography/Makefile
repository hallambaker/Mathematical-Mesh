#
# Makefile for Visual Studio Project Test.Goedel.Cryptography
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
     TestECDH.cs\
     TestDH.cs\
     TestMath.cs\
     TestCurve.cs\
     TestSHA.cs\
     TestAES.cs\
     TestWrap.cs\
     TestDerrive.cs\
     TestHMAC.cs\
     Base.cs\
     Properties/AssemblyInfo.cs

LinkFiles = \
    $(TARGETBIN)/Goedel.Cryptography.Jose.dll\
    $(TARGETBIN)/Goedel.Cryptography.dll\
    $(TARGETBIN)/Goedel.FSR.dll\
    $(TARGETBIN)/Goedel.Utilities.dll\
    $(TARGETBIN)/Goedel.Test.dll\
    $(TARGETBIN)/Goedel.Cryptography.Framework.dll

LinkFilesComma = $(TARGETBIN)/Goedel.Cryptography.Jose.dll,$(TARGETBIN)/Goedel.Cryptography.dll,$(TARGETBIN)/Goedel.FSR.dll,$(TARGETBIN)/Goedel.Utilities.dll,$(TARGETBIN)/Goedel.Test.dll,$(TARGETBIN)/Goedel.Cryptography.Framework.dll,System.Numerics,Microsoft.VisualStudio.QualityTools.UnitTestFramework,Microsoft.VisualStudio.QualityTools.UnitTestFramework


NugetFiles = 
NugetFilesComa = 

# A) Main target packaged

$(TARGETBIN)/Test.Goedel.Cryptography.dll :| $(LIBRARYBIN)
$(TARGETBIN)/Test.Goedel.Cryptography.dll :| $(TARGETBIN)

$(TARGETBIN)/Test.Goedel.Cryptography.dll :  $(SourceFiles) $(LinkFiles) $(NugetFiles)
! $(CSHARPDLL) /out:$@  $(SourceFiles) -reference:$(LinkFilesComma) 
! cp $(TARGETBIN)/Test.Goedel.Cryptography.dll $(LIBRARYBIN)/Test.Goedel.Cryptography.dll


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

../../Libraries/Goedel.Cryptography.Jose/$(TARGETBIN)/Goedel.Cryptography.Jose.dll : recursive
! $(MAKE) -C ../../Libraries/Goedel.Cryptography.Jose

../../Libraries/Goedel.Cryptography/$(TARGETBIN)/Goedel.Cryptography.dll : recursive
! $(MAKE) -C ../../Libraries/Goedel.Cryptography

../../Libraries/Goedel.FSR/$(TARGETBIN)/Goedel.FSR.dll : recursive
! $(MAKE) -C ../../Libraries/Goedel.FSR

../../Libraries/Goedel.Utilities/$(TARGETBIN)/Goedel.Utilities.dll : recursive
! $(MAKE) -C ../../Libraries/Goedel.Utilities

../../Libraries/Goedel.Test/$(TARGETBIN)/Goedel.Test.dll : recursive
! $(MAKE) -C ../../Libraries/Goedel.Test

../../Libraries/Goedel.Cryptography.Framework/$(TARGETBIN)/Goedel.Cryptography.Framework.dll : recursive
! $(MAKE) -C ../../Libraries/Goedel.Cryptography.Framework

endif

$(TARGETBIN)/Goedel.Cryptography.Jose.dll :| $(TARGETBIN)
$(TARGETBIN)/Goedel.Cryptography.Jose.dll : ../../Libraries/Goedel.Cryptography.Jose/$(TARGETBIN)/Goedel.Cryptography.Jose.dll
!  cp ../../Libraries/Goedel.Cryptography.Jose/$(TARGETBIN)/Goedel.Cryptography.Jose.dll $(TARGETBIN)/Goedel.Cryptography.Jose.dll

$(TARGETBIN)/Goedel.Cryptography.dll :| $(TARGETBIN)
$(TARGETBIN)/Goedel.Cryptography.dll : ../../Libraries/Goedel.Cryptography/$(TARGETBIN)/Goedel.Cryptography.dll
!  cp ../../Libraries/Goedel.Cryptography/$(TARGETBIN)/Goedel.Cryptography.dll $(TARGETBIN)/Goedel.Cryptography.dll

$(TARGETBIN)/Goedel.FSR.dll :| $(TARGETBIN)
$(TARGETBIN)/Goedel.FSR.dll : ../../Libraries/Goedel.FSR/$(TARGETBIN)/Goedel.FSR.dll
!  cp ../../Libraries/Goedel.FSR/$(TARGETBIN)/Goedel.FSR.dll $(TARGETBIN)/Goedel.FSR.dll

$(TARGETBIN)/Goedel.Utilities.dll :| $(TARGETBIN)
$(TARGETBIN)/Goedel.Utilities.dll : ../../Libraries/Goedel.Utilities/$(TARGETBIN)/Goedel.Utilities.dll
!  cp ../../Libraries/Goedel.Utilities/$(TARGETBIN)/Goedel.Utilities.dll $(TARGETBIN)/Goedel.Utilities.dll

$(TARGETBIN)/Goedel.Test.dll :| $(TARGETBIN)
$(TARGETBIN)/Goedel.Test.dll : ../../Libraries/Goedel.Test/$(TARGETBIN)/Goedel.Test.dll
!  cp ../../Libraries/Goedel.Test/$(TARGETBIN)/Goedel.Test.dll $(TARGETBIN)/Goedel.Test.dll

$(TARGETBIN)/Goedel.Cryptography.Framework.dll :| $(TARGETBIN)
$(TARGETBIN)/Goedel.Cryptography.Framework.dll : ../../Libraries/Goedel.Cryptography.Framework/$(TARGETBIN)/Goedel.Cryptography.Framework.dll
!  cp ../../Libraries/Goedel.Cryptography.Framework/$(TARGETBIN)/Goedel.Cryptography.Framework.dll $(TARGETBIN)/Goedel.Cryptography.Framework.dll


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


install : $(INSTALL_DATA)/Test.Goedel.Cryptography.dll

$(INSTALL_DATA)/Test.Goedel.Cryptography.dll :| $(INSTALL_DATA)
$(INSTALL_DATA)/Test.Goedel.Cryptography.dll : $(TARGETBIN)/Test.Goedel.Cryptography.dll
! cp $^ $@ 




# To Do List
#
# 1) Redo install target
#    Create a wrapper script and library 
# 2) Create a Debian target
# 3) Create a RPM target
# 4) Create a nuget target


