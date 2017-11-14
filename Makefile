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
# Item :  Shells/AdminDumpLog
# Output :     Shells/AdminDumpLog/$(TARGETEXE)/DumpLog.exe

all : Shells/AdminDumpLog/$(TARGETBIN)/DumpLog.exe

Shells/AdminDumpLog/$(TARGETBIN)/DumpLog.exe : Shells/AdminDumpLog/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Command.dll

Shells/AdminDumpLog/$(TARGETBIN)/DumpLog.exe : Shells/AdminDumpLog/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.IO.dll

Shells/AdminDumpLog/$(TARGETBIN)/DumpLog.exe : Shells/AdminDumpLog/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Persistence.dll

Shells/AdminDumpLog/$(TARGETBIN)/DumpLog.exe : Shells/AdminDumpLog/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Shells/AdminDumpLog/$(TARGETBIN)/DumpLog.exe : Shells/AdminDumpLog/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Shells/AdminDumpLog/$(TARGETBIN)/DumpLog.exe : Shells/AdminDumpLog/../../Mesh/$(TARGETBIN)/Goedel.Mesh.dll


Shells/AdminDumpLog/$(TARGETBIN)/DumpLog.exe : always
! echo "" >&2
! echo "*** Directory Shells/AdminDumpLog" >&2
! make NORECURSE=true -C Shells/AdminDumpLog

# Project : Goedel.Mesh.dll
# Item :  Mesh/Goedel.Mesh
# Output :     Mesh/Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll

all : Mesh/Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll

Mesh/Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll : Mesh/Goedel.Mesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.ASN.dll

Mesh/Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll : Mesh/Goedel.Mesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Framework.dll

Mesh/Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll : Mesh/Goedel.Mesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Jose.dll

Mesh/Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll : Mesh/Goedel.Mesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.KeyFile.dll

Mesh/Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll : Mesh/Goedel.Mesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Mesh/Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll : Mesh/Goedel.Mesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.IO.dll

Mesh/Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll : Mesh/Goedel.Mesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Persistence.dll

Mesh/Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll : Mesh/Goedel.Mesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Mesh/Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll : Mesh/Goedel.Mesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Registry.dll

Mesh/Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll : Mesh/Goedel.Mesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll


Mesh/Goedel.Mesh/$(TARGETBIN)/Goedel.Mesh.dll : always
! echo "" >&2
! echo "*** Directory Mesh/Goedel.Mesh" >&2
! make NORECURSE=true -C Mesh/Goedel.Mesh

# Project : Goedel.Mesh.Server.dll
# Item :  Mesh/Goedel.Mesh.Server
# Output :     Mesh/Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll

all : Mesh/Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll

Mesh/Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll : Mesh/Goedel.Mesh.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Jose.dll

Mesh/Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll : Mesh/Goedel.Mesh.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Mesh/Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll : Mesh/Goedel.Mesh.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.IO.dll

Mesh/Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll : Mesh/Goedel.Mesh.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Persistence.dll

Mesh/Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll : Mesh/Goedel.Mesh.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Mesh/Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll : Mesh/Goedel.Mesh.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Mesh/Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll : Mesh/Goedel.Mesh.Server/../$(TARGETBIN)/Goedel.Mesh.dll


Mesh/Goedel.Mesh.Server/$(TARGETBIN)/Goedel.Mesh.Server.dll : always
! echo "" >&2
! echo "*** Directory Mesh/Goedel.Mesh.Server" >&2
! make NORECURSE=true -C Mesh/Goedel.Mesh.Server

# Project : RunMesh.exe
# Item :  Shells/RunMesh
# Output :     Shells/RunMesh/$(TARGETEXE)/RunMesh.exe

all : Shells/RunMesh/$(TARGETBIN)/RunMesh.exe

Shells/RunMesh/$(TARGETBIN)/RunMesh.exe : Shells/RunMesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Command.dll

Shells/RunMesh/$(TARGETBIN)/RunMesh.exe : Shells/RunMesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Jose.dll

Shells/RunMesh/$(TARGETBIN)/RunMesh.exe : Shells/RunMesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Windows.dll

Shells/RunMesh/$(TARGETBIN)/RunMesh.exe : Shells/RunMesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Shells/RunMesh/$(TARGETBIN)/RunMesh.exe : Shells/RunMesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.IO.dll

Shells/RunMesh/$(TARGETBIN)/RunMesh.exe : Shells/RunMesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Persistence.dll

Shells/RunMesh/$(TARGETBIN)/RunMesh.exe : Shells/RunMesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Shells/RunMesh/$(TARGETBIN)/RunMesh.exe : Shells/RunMesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Shells/RunMesh/$(TARGETBIN)/RunMesh.exe : Shells/RunMesh/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll

Shells/RunMesh/$(TARGETBIN)/RunMesh.exe : Shells/RunMesh/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.dll

Shells/RunMesh/$(TARGETBIN)/RunMesh.exe : Shells/RunMesh/../$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll

Shells/RunMesh/$(TARGETBIN)/RunMesh.exe : Shells/RunMesh/../../Mesh/$(TARGETBIN)/Goedel.Mesh.dll

Shells/RunMesh/$(TARGETBIN)/RunMesh.exe : Shells/RunMesh/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Server.dll

Shells/RunMesh/$(TARGETBIN)/RunMesh.exe : Shells/RunMesh/../../Testing/$(TARGETBIN)/Test.Constants.dll


Shells/RunMesh/$(TARGETBIN)/RunMesh.exe : always
! echo "" >&2
! echo "*** Directory Shells/RunMesh" >&2
! make NORECURSE=true -C Shells/RunMesh

# Project : ServerMesh.exe
# Item :  Shells/ServerMesh
# Output :     Shells/ServerMesh/$(TARGETEXE)/ServerMesh.exe

all : Shells/ServerMesh/$(TARGETBIN)/ServerMesh.exe

Shells/ServerMesh/$(TARGETBIN)/ServerMesh.exe : Shells/ServerMesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Command.dll

Shells/ServerMesh/$(TARGETBIN)/ServerMesh.exe : Shells/ServerMesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Shells/ServerMesh/$(TARGETBIN)/ServerMesh.exe : Shells/ServerMesh/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Shells/ServerMesh/$(TARGETBIN)/ServerMesh.exe : Shells/ServerMesh/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll

Shells/ServerMesh/$(TARGETBIN)/ServerMesh.exe : Shells/ServerMesh/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.dll

Shells/ServerMesh/$(TARGETBIN)/ServerMesh.exe : Shells/ServerMesh/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Server.dll

Shells/ServerMesh/$(TARGETBIN)/ServerMesh.exe : Shells/ServerMesh/../../Mesh/$(TARGETBIN)/Goedel.Mesh.dll


Shells/ServerMesh/$(TARGETBIN)/ServerMesh.exe : always
! echo "" >&2
! echo "*** Directory Shells/ServerMesh" >&2
! make NORECURSE=true -C Shells/ServerMesh

# Project : Goedel.Mesh.Client.dll
# Item :  Mesh/Goedel.Mesh.Client
# Output :     Mesh/Goedel.Mesh.Client/$(TARGETBIN)/Goedel.Mesh.Client.dll

all : Mesh/Goedel.Mesh.Client/$(TARGETBIN)/Goedel.Mesh.Client.dll

Mesh/Goedel.Mesh.Client/$(TARGETBIN)/Goedel.Mesh.Client.dll : Mesh/Goedel.Mesh.Client/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Mesh/Goedel.Mesh.Client/$(TARGETBIN)/Goedel.Mesh.Client.dll : Mesh/Goedel.Mesh.Client/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll


Mesh/Goedel.Mesh.Client/$(TARGETBIN)/Goedel.Mesh.Client.dll : always
! echo "" >&2
! echo "*** Directory Mesh/Goedel.Mesh.Client" >&2
! make NORECURSE=true -C Mesh/Goedel.Mesh.Client

# Project : Goedel.Mesh.Platform.Windows.dll
# Item :  Mesh/Goedel.Mesh.Platform.Windows
# Output :     Mesh/Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll

all : Mesh/Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll

Mesh/Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll : Mesh/Goedel.Mesh.Platform.Windows/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Windows.dll

Mesh/Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll : Mesh/Goedel.Mesh.Platform.Windows/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Mesh/Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll : Mesh/Goedel.Mesh.Platform.Windows/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Discovery.dll

Mesh/Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll : Mesh/Goedel.Mesh.Platform.Windows/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.IO.dll

Mesh/Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll : Mesh/Goedel.Mesh.Platform.Windows/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Mesh/Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll : Mesh/Goedel.Mesh.Platform.Windows/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Mesh/Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll : Mesh/Goedel.Mesh.Platform.Windows/../$(TARGETBIN)/Goedel.Mesh.Client.dll

Mesh/Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll : Mesh/Goedel.Mesh.Platform.Windows/../$(TARGETBIN)/Goedel.Mesh.Platform.dll

Mesh/Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll : Mesh/Goedel.Mesh.Platform.Windows/../$(TARGETBIN)/Goedel.Mesh.Server.dll

Mesh/Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll : Mesh/Goedel.Mesh.Platform.Windows/../$(TARGETBIN)/Goedel.Mesh.dll


Mesh/Goedel.Mesh.Platform.Windows/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll : always
! echo "" >&2
! echo "*** Directory Mesh/Goedel.Mesh.Platform.Windows" >&2
! make NORECURSE=true -C Mesh/Goedel.Mesh.Platform.Windows

# Project : InternetDrafts.exe
# Item :  Documentation/MakeExamples
# Output :     Documentation/MakeExamples/$(TARGETEXE)/InternetDrafts.exe

all : Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe

Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe : Documentation/MakeExamples/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Command.dll

Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe : Documentation/MakeExamples/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Container.dll

Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe : Documentation/MakeExamples/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Jose.dll

Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe : Documentation/MakeExamples/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Windows.dll

Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe : Documentation/MakeExamples/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe : Documentation/MakeExamples/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.FSR.dll

Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe : Documentation/MakeExamples/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.IO.dll

Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe : Documentation/MakeExamples/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.Debug.dll

Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe : Documentation/MakeExamples/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.Exchange.Server.dll

Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe : Documentation/MakeExamples/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.Exchange.dll

Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe : Documentation/MakeExamples/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe : Documentation/MakeExamples/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Registry.dll

Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe : Documentation/MakeExamples/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe : Documentation/MakeExamples/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Client.dll

Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe : Documentation/MakeExamples/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll

Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe : Documentation/MakeExamples/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.dll

Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe : Documentation/MakeExamples/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Server.dll

Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe : Documentation/MakeExamples/../../Shells/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll

Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe : Documentation/MakeExamples/../../Mesh/$(TARGETBIN)/Goedel.Mesh.dll


Documentation/MakeExamples/$(TARGETBIN)/InternetDrafts.exe : always
! echo "" >&2
! echo "*** Directory Documentation/MakeExamples" >&2
! make NORECURSE=true -C Documentation/MakeExamples

# Project : Goedel.Mesh.Shell.MeshMan.dll
# Item :  Shells/Goedel.Mesh.Shell.MeshMan
# Output :     Shells/Goedel.Mesh.Shell.MeshMan/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll

all : Shells/Goedel.Mesh.Shell.MeshMan/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll

Shells/Goedel.Mesh.Shell.MeshMan/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll : Shells/Goedel.Mesh.Shell.MeshMan/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Command.dll

Shells/Goedel.Mesh.Shell.MeshMan/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll : Shells/Goedel.Mesh.Shell.MeshMan/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Jose.dll

Shells/Goedel.Mesh.Shell.MeshMan/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll : Shells/Goedel.Mesh.Shell.MeshMan/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.KeyFile.dll

Shells/Goedel.Mesh.Shell.MeshMan/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll : Shells/Goedel.Mesh.Shell.MeshMan/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Shells/Goedel.Mesh.Shell.MeshMan/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll : Shells/Goedel.Mesh.Shell.MeshMan/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.FSR.dll

Shells/Goedel.Mesh.Shell.MeshMan/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll : Shells/Goedel.Mesh.Shell.MeshMan/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.IO.dll

Shells/Goedel.Mesh.Shell.MeshMan/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll : Shells/Goedel.Mesh.Shell.MeshMan/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Shells/Goedel.Mesh.Shell.MeshMan/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll : Shells/Goedel.Mesh.Shell.MeshMan/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Shells/Goedel.Mesh.Shell.MeshMan/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll : Shells/Goedel.Mesh.Shell.MeshMan/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Client.dll

Shells/Goedel.Mesh.Shell.MeshMan/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll : Shells/Goedel.Mesh.Shell.MeshMan/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll

Shells/Goedel.Mesh.Shell.MeshMan/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll : Shells/Goedel.Mesh.Shell.MeshMan/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.dll

Shells/Goedel.Mesh.Shell.MeshMan/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll : Shells/Goedel.Mesh.Shell.MeshMan/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Server.dll

Shells/Goedel.Mesh.Shell.MeshMan/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll : Shells/Goedel.Mesh.Shell.MeshMan/../../Mesh/$(TARGETBIN)/Goedel.Mesh.dll


Shells/Goedel.Mesh.Shell.MeshMan/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll : always
! echo "" >&2
! echo "*** Directory Shells/Goedel.Mesh.Shell.MeshMan" >&2
! make NORECURSE=true -C Shells/Goedel.Mesh.Shell.MeshMan

# Project : Goedel.Mesh.Platform.dll
# Item :  Mesh/Goedel.Mesh.Platform
# Output :     Mesh/Goedel.Mesh.Platform/$(TARGETBIN)/Goedel.Mesh.Platform.dll

all : Mesh/Goedel.Mesh.Platform/$(TARGETBIN)/Goedel.Mesh.Platform.dll

Mesh/Goedel.Mesh.Platform/$(TARGETBIN)/Goedel.Mesh.Platform.dll : Mesh/Goedel.Mesh.Platform/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Jose.dll

Mesh/Goedel.Mesh.Platform/$(TARGETBIN)/Goedel.Mesh.Platform.dll : Mesh/Goedel.Mesh.Platform/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Mesh/Goedel.Mesh.Platform/$(TARGETBIN)/Goedel.Mesh.Platform.dll : Mesh/Goedel.Mesh.Platform/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.IO.dll

Mesh/Goedel.Mesh.Platform/$(TARGETBIN)/Goedel.Mesh.Platform.dll : Mesh/Goedel.Mesh.Platform/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Mesh/Goedel.Mesh.Platform/$(TARGETBIN)/Goedel.Mesh.Platform.dll : Mesh/Goedel.Mesh.Platform/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Mesh/Goedel.Mesh.Platform/$(TARGETBIN)/Goedel.Mesh.Platform.dll : Mesh/Goedel.Mesh.Platform/../$(TARGETBIN)/Goedel.Mesh.Client.dll

Mesh/Goedel.Mesh.Platform/$(TARGETBIN)/Goedel.Mesh.Platform.dll : Mesh/Goedel.Mesh.Platform/../$(TARGETBIN)/Goedel.Mesh.Server.dll

Mesh/Goedel.Mesh.Platform/$(TARGETBIN)/Goedel.Mesh.Platform.dll : Mesh/Goedel.Mesh.Platform/../$(TARGETBIN)/Goedel.Mesh.dll


Mesh/Goedel.Mesh.Platform/$(TARGETBIN)/Goedel.Mesh.Platform.dll : always
! echo "" >&2
! echo "*** Directory Mesh/Goedel.Mesh.Platform" >&2
! make NORECURSE=true -C Mesh/Goedel.Mesh.Platform

# Project : meshman_windows.exe
# Item :  Shells/meshman_windows
# Output :     Shells/meshman_windows/$(TARGETEXE)/meshman_windows.exe

all : Shells/meshman_windows/$(TARGETBIN)/meshman_windows.exe

Shells/meshman_windows/$(TARGETBIN)/meshman_windows.exe : Shells/meshman_windows/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Command.dll

Shells/meshman_windows/$(TARGETBIN)/meshman_windows.exe : Shells/meshman_windows/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Windows.dll

Shells/meshman_windows/$(TARGETBIN)/meshman_windows.exe : Shells/meshman_windows/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Shells/meshman_windows/$(TARGETBIN)/meshman_windows.exe : Shells/meshman_windows/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Discovery.dll

Shells/meshman_windows/$(TARGETBIN)/meshman_windows.exe : Shells/meshman_windows/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Shells/meshman_windows/$(TARGETBIN)/meshman_windows.exe : Shells/meshman_windows/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Shells/meshman_windows/$(TARGETBIN)/meshman_windows.exe : Shells/meshman_windows/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Client.dll

Shells/meshman_windows/$(TARGETBIN)/meshman_windows.exe : Shells/meshman_windows/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll

Shells/meshman_windows/$(TARGETBIN)/meshman_windows.exe : Shells/meshman_windows/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.dll

Shells/meshman_windows/$(TARGETBIN)/meshman_windows.exe : Shells/meshman_windows/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Server.dll

Shells/meshman_windows/$(TARGETBIN)/meshman_windows.exe : Shells/meshman_windows/../$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll

Shells/meshman_windows/$(TARGETBIN)/meshman_windows.exe : Shells/meshman_windows/../../Mesh/$(TARGETBIN)/Goedel.Mesh.dll


Shells/meshman_windows/$(TARGETBIN)/meshman_windows.exe : always
! echo "" >&2
! echo "*** Directory Shells/meshman_windows" >&2
! make NORECURSE=true -C Shells/meshman_windows

# Project : meshman_linux.exe
# Item :  Shells/meshman_linux
# Output :     Shells/meshman_linux/$(TARGETEXE)/meshman_linux.exe

all : Shells/meshman_linux/$(TARGETBIN)/meshman_linux.exe

Shells/meshman_linux/$(TARGETBIN)/meshman_linux.exe : Shells/meshman_linux/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Command.dll

Shells/meshman_linux/$(TARGETBIN)/meshman_linux.exe : Shells/meshman_linux/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Discovery.dll

Shells/meshman_linux/$(TARGETBIN)/meshman_linux.exe : Shells/meshman_linux/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Shells/meshman_linux/$(TARGETBIN)/meshman_linux.exe : Shells/meshman_linux/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Client.dll

Shells/meshman_linux/$(TARGETBIN)/meshman_linux.exe : Shells/meshman_linux/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll

Shells/meshman_linux/$(TARGETBIN)/meshman_linux.exe : Shells/meshman_linux/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.dll

Shells/meshman_linux/$(TARGETBIN)/meshman_linux.exe : Shells/meshman_linux/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Server.dll

Shells/meshman_linux/$(TARGETBIN)/meshman_linux.exe : Shells/meshman_linux/../$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll

Shells/meshman_linux/$(TARGETBIN)/meshman_linux.exe : Shells/meshman_linux/../../Mesh/$(TARGETBIN)/Goedel.Mesh.dll


Shells/meshman_linux/$(TARGETBIN)/meshman_linux.exe : always
! echo "" >&2
! echo "*** Directory Shells/meshman_linux" >&2
! make NORECURSE=true -C Shells/meshman_linux

# Project : meshman_osx.exe
# Item :  Shells/meshman_osx
# Output :     Shells/meshman_osx/$(TARGETEXE)/meshman_osx.exe

all : Shells/meshman_osx/$(TARGETBIN)/meshman_osx.exe

Shells/meshman_osx/$(TARGETBIN)/meshman_osx.exe : Shells/meshman_osx/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Command.dll

Shells/meshman_osx/$(TARGETBIN)/meshman_osx.exe : Shells/meshman_osx/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Discovery.dll

Shells/meshman_osx/$(TARGETBIN)/meshman_osx.exe : Shells/meshman_osx/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Shells/meshman_osx/$(TARGETBIN)/meshman_osx.exe : Shells/meshman_osx/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Shells/meshman_osx/$(TARGETBIN)/meshman_osx.exe : Shells/meshman_osx/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Client.dll

Shells/meshman_osx/$(TARGETBIN)/meshman_osx.exe : Shells/meshman_osx/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll

Shells/meshman_osx/$(TARGETBIN)/meshman_osx.exe : Shells/meshman_osx/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.dll

Shells/meshman_osx/$(TARGETBIN)/meshman_osx.exe : Shells/meshman_osx/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Server.dll

Shells/meshman_osx/$(TARGETBIN)/meshman_osx.exe : Shells/meshman_osx/../$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll

Shells/meshman_osx/$(TARGETBIN)/meshman_osx.exe : Shells/meshman_osx/../../Mesh/$(TARGETBIN)/Goedel.Mesh.dll


Shells/meshman_osx/$(TARGETBIN)/meshman_osx.exe : always
! echo "" >&2
! echo "*** Directory Shells/meshman_osx" >&2
! make NORECURSE=true -C Shells/meshman_osx

# Project : Test.Goedel.Mesh.dll
# Item :  Testing/Test.Goedel.Mesh.Profile
# Output :     Testing/Test.Goedel.Mesh.Profile/$(TARGETBIN)/Test.Goedel.Mesh.dll

all : Testing/Test.Goedel.Mesh.Profile/$(TARGETBIN)/Test.Goedel.Mesh.dll

Testing/Test.Goedel.Mesh.Profile/$(TARGETBIN)/Test.Goedel.Mesh.dll : Testing/Test.Goedel.Mesh.Profile/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll

Testing/Test.Goedel.Mesh.Profile/$(TARGETBIN)/Test.Goedel.Mesh.dll : Testing/Test.Goedel.Mesh.Profile/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.dll

Testing/Test.Goedel.Mesh.Profile/$(TARGETBIN)/Test.Goedel.Mesh.dll : Testing/Test.Goedel.Mesh.Profile/../../Mesh/$(TARGETBIN)/Goedel.Mesh.dll


Testing/Test.Goedel.Mesh.Profile/$(TARGETBIN)/Test.Goedel.Mesh.dll : always
! echo "" >&2
! echo "*** Directory Testing/Test.Goedel.Mesh.Profile" >&2
! make NORECURSE=true -C Testing/Test.Goedel.Mesh.Profile

# Project : Test.Goedel.Mesh.dll
# Item :  Testing/Test.Goedel.Mesh.Recrypt
# Output :     Testing/Test.Goedel.Mesh.Recrypt/$(TARGETBIN)/Test.Goedel.Mesh.dll

all : Testing/Test.Goedel.Mesh.Recrypt/$(TARGETBIN)/Test.Goedel.Mesh.dll


Testing/Test.Goedel.Mesh.Recrypt/$(TARGETBIN)/Test.Goedel.Mesh.dll : always
! echo "" >&2
! echo "*** Directory Testing/Test.Goedel.Mesh.Recrypt" >&2
! make NORECURSE=true -C Testing/Test.Goedel.Mesh.Recrypt

# Project : Test.Goedel.Mesh.dll
# Item :  Testing/Test.Goedel.Mesh.Web
# Output :     Testing/Test.Goedel.Mesh.Web/$(TARGETBIN)/Test.Goedel.Mesh.dll

all : Testing/Test.Goedel.Mesh.Web/$(TARGETBIN)/Test.Goedel.Mesh.dll


Testing/Test.Goedel.Mesh.Web/$(TARGETBIN)/Test.Goedel.Mesh.dll : always
! echo "" >&2
! echo "*** Directory Testing/Test.Goedel.Mesh.Web" >&2
! make NORECURSE=true -C Testing/Test.Goedel.Mesh.Web

# Project : Test.Goedel.Mesh.dll
# Item :  Testing/Test.Goedel.Mesh.Confirm
# Output :     Testing/Test.Goedel.Mesh.Confirm/$(TARGETBIN)/Test.Goedel.Mesh.dll

all : Testing/Test.Goedel.Mesh.Confirm/$(TARGETBIN)/Test.Goedel.Mesh.dll

Testing/Test.Goedel.Mesh.Confirm/$(TARGETBIN)/Test.Goedel.Mesh.dll : Testing/Test.Goedel.Mesh.Confirm/../../Mesh/$(TARGETBIN)/Goedel.Mesh.dll


Testing/Test.Goedel.Mesh.Confirm/$(TARGETBIN)/Test.Goedel.Mesh.dll : always
! echo "" >&2
! echo "*** Directory Testing/Test.Goedel.Mesh.Confirm" >&2
! make NORECURSE=true -C Testing/Test.Goedel.Mesh.Confirm

# Project : Test.Goedel.Mesh.dll
# Item :  Testing/Test.Goedel.Mesh.Services
# Output :     Testing/Test.Goedel.Mesh.Services/$(TARGETBIN)/Test.Goedel.Mesh.dll

all : Testing/Test.Goedel.Mesh.Services/$(TARGETBIN)/Test.Goedel.Mesh.dll

Testing/Test.Goedel.Mesh.Services/$(TARGETBIN)/Test.Goedel.Mesh.dll : Testing/Test.Goedel.Mesh.Services/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Client.dll

Testing/Test.Goedel.Mesh.Services/$(TARGETBIN)/Test.Goedel.Mesh.dll : Testing/Test.Goedel.Mesh.Services/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll

Testing/Test.Goedel.Mesh.Services/$(TARGETBIN)/Test.Goedel.Mesh.dll : Testing/Test.Goedel.Mesh.Services/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.dll

Testing/Test.Goedel.Mesh.Services/$(TARGETBIN)/Test.Goedel.Mesh.dll : Testing/Test.Goedel.Mesh.Services/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Server.dll

Testing/Test.Goedel.Mesh.Services/$(TARGETBIN)/Test.Goedel.Mesh.dll : Testing/Test.Goedel.Mesh.Services/../../Mesh/$(TARGETBIN)/Goedel.Mesh.dll

Testing/Test.Goedel.Mesh.Services/$(TARGETBIN)/Test.Goedel.Mesh.dll : Testing/Test.Goedel.Mesh.Services/../$(TARGETBIN)/Test.Constants.dll


Testing/Test.Goedel.Mesh.Services/$(TARGETBIN)/Test.Goedel.Mesh.dll : always
! echo "" >&2
! echo "*** Directory Testing/Test.Goedel.Mesh.Services" >&2
! make NORECURSE=true -C Testing/Test.Goedel.Mesh.Services

# Project : Test.Constants.dll
# Item :  Testing/Test.Constants
# Output :     Testing/Test.Constants/$(TARGETBIN)/Test.Constants.dll

all : Testing/Test.Constants/$(TARGETBIN)/Test.Constants.dll

Testing/Test.Constants/$(TARGETBIN)/Test.Constants.dll : Testing/Test.Constants/../../Mesh/$(TARGETBIN)/Goedel.Mesh.dll


Testing/Test.Constants/$(TARGETBIN)/Test.Constants.dll : always
! echo "" >&2
! echo "*** Directory Testing/Test.Constants" >&2
! make NORECURSE=true -C Testing/Test.Constants

# Project : Test.Goedel.Mesh.dll
# Item :  Testing/Test.Goedel.Mesh.Shell
# Output :     Testing/Test.Goedel.Mesh.Shell/$(TARGETBIN)/Test.Goedel.Mesh.dll

all : Testing/Test.Goedel.Mesh.Shell/$(TARGETBIN)/Test.Goedel.Mesh.dll

Testing/Test.Goedel.Mesh.Shell/$(TARGETBIN)/Test.Goedel.Mesh.dll : Testing/Test.Goedel.Mesh.Shell/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Discovery.dll

Testing/Test.Goedel.Mesh.Shell/$(TARGETBIN)/Test.Goedel.Mesh.dll : Testing/Test.Goedel.Mesh.Shell/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Client.dll

Testing/Test.Goedel.Mesh.Shell/$(TARGETBIN)/Test.Goedel.Mesh.dll : Testing/Test.Goedel.Mesh.Shell/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll

Testing/Test.Goedel.Mesh.Shell/$(TARGETBIN)/Test.Goedel.Mesh.dll : Testing/Test.Goedel.Mesh.Shell/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.dll

Testing/Test.Goedel.Mesh.Shell/$(TARGETBIN)/Test.Goedel.Mesh.dll : Testing/Test.Goedel.Mesh.Shell/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Server.dll

Testing/Test.Goedel.Mesh.Shell/$(TARGETBIN)/Test.Goedel.Mesh.dll : Testing/Test.Goedel.Mesh.Shell/../../Shells/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll

Testing/Test.Goedel.Mesh.Shell/$(TARGETBIN)/Test.Goedel.Mesh.dll : Testing/Test.Goedel.Mesh.Shell/../../Mesh/$(TARGETBIN)/Goedel.Mesh.dll

Testing/Test.Goedel.Mesh.Shell/$(TARGETBIN)/Test.Goedel.Mesh.dll : Testing/Test.Goedel.Mesh.Shell/../$(TARGETBIN)/Test.Constants.dll


Testing/Test.Goedel.Mesh.Shell/$(TARGETBIN)/Test.Goedel.Mesh.dll : always
! echo "" >&2
! echo "*** Directory Testing/Test.Goedel.Mesh.Shell" >&2
! make NORECURSE=true -C Testing/Test.Goedel.Mesh.Shell

# Project : Goedel.Account.dll
# Item :  Account/Goedel.Account
# Output :     Account/Goedel.Account/$(TARGETBIN)/Goedel.Account.dll

all : Account/Goedel.Account/$(TARGETBIN)/Goedel.Account.dll

Account/Goedel.Account/$(TARGETBIN)/Goedel.Account.dll : Account/Goedel.Account/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Jose.dll

Account/Goedel.Account/$(TARGETBIN)/Goedel.Account.dll : Account/Goedel.Account/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Account/Goedel.Account/$(TARGETBIN)/Goedel.Account.dll : Account/Goedel.Account/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Account/Goedel.Account/$(TARGETBIN)/Goedel.Account.dll : Account/Goedel.Account/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Account/Goedel.Account/$(TARGETBIN)/Goedel.Account.dll : Account/Goedel.Account/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.dll

Account/Goedel.Account/$(TARGETBIN)/Goedel.Account.dll : Account/Goedel.Account/../../Mesh/$(TARGETBIN)/Goedel.Mesh.dll


Account/Goedel.Account/$(TARGETBIN)/Goedel.Account.dll : always
! echo "" >&2
! echo "*** Directory Account/Goedel.Account" >&2
! make NORECURSE=true -C Account/Goedel.Account

# Project : Goedel.Account.Client.dll
# Item :  Account/Goedel.Account.Client
# Output :     Account/Goedel.Account.Client/$(TARGETBIN)/Goedel.Account.Client.dll

all : Account/Goedel.Account.Client/$(TARGETBIN)/Goedel.Account.Client.dll

Account/Goedel.Account.Client/$(TARGETBIN)/Goedel.Account.Client.dll : Account/Goedel.Account.Client/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Account/Goedel.Account.Client/$(TARGETBIN)/Goedel.Account.Client.dll : Account/Goedel.Account.Client/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Account/Goedel.Account.Client/$(TARGETBIN)/Goedel.Account.Client.dll : Account/Goedel.Account.Client/../$(TARGETBIN)/Goedel.Account.dll


Account/Goedel.Account.Client/$(TARGETBIN)/Goedel.Account.Client.dll : always
! echo "" >&2
! echo "*** Directory Account/Goedel.Account.Client" >&2
! make NORECURSE=true -C Account/Goedel.Account.Client

# Project : Goedel.Account.Server.dll
# Item :  Account/Goedel.Account.Server
# Output :     Account/Goedel.Account.Server/$(TARGETBIN)/Goedel.Account.Server.dll

all : Account/Goedel.Account.Server/$(TARGETBIN)/Goedel.Account.Server.dll

Account/Goedel.Account.Server/$(TARGETBIN)/Goedel.Account.Server.dll : Account/Goedel.Account.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Jose.dll

Account/Goedel.Account.Server/$(TARGETBIN)/Goedel.Account.Server.dll : Account/Goedel.Account.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Account/Goedel.Account.Server/$(TARGETBIN)/Goedel.Account.Server.dll : Account/Goedel.Account.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Persistence.dll

Account/Goedel.Account.Server/$(TARGETBIN)/Goedel.Account.Server.dll : Account/Goedel.Account.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Account/Goedel.Account.Server/$(TARGETBIN)/Goedel.Account.Server.dll : Account/Goedel.Account.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Account/Goedel.Account.Server/$(TARGETBIN)/Goedel.Account.Server.dll : Account/Goedel.Account.Server/../$(TARGETBIN)/Goedel.Account.dll


Account/Goedel.Account.Server/$(TARGETBIN)/Goedel.Account.Server.dll : always
! echo "" >&2
! echo "*** Directory Account/Goedel.Account.Server" >&2
! make NORECURSE=true -C Account/Goedel.Account.Server

# Project : Goedel.Confirm.dll
# Item :  Confirm/Goedel.Confirm
# Output :     Confirm/Goedel.Confirm/$(TARGETBIN)/Goedel.Confirm.dll

all : Confirm/Goedel.Confirm/$(TARGETBIN)/Goedel.Confirm.dll

Confirm/Goedel.Confirm/$(TARGETBIN)/Goedel.Confirm.dll : Confirm/Goedel.Confirm/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Jose.dll

Confirm/Goedel.Confirm/$(TARGETBIN)/Goedel.Confirm.dll : Confirm/Goedel.Confirm/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Confirm/Goedel.Confirm/$(TARGETBIN)/Goedel.Confirm.dll : Confirm/Goedel.Confirm/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Confirm/Goedel.Confirm/$(TARGETBIN)/Goedel.Confirm.dll : Confirm/Goedel.Confirm/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Confirm/Goedel.Confirm/$(TARGETBIN)/Goedel.Confirm.dll : Confirm/Goedel.Confirm/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.dll

Confirm/Goedel.Confirm/$(TARGETBIN)/Goedel.Confirm.dll : Confirm/Goedel.Confirm/../../Mesh/$(TARGETBIN)/Goedel.Mesh.dll


Confirm/Goedel.Confirm/$(TARGETBIN)/Goedel.Confirm.dll : always
! echo "" >&2
! echo "*** Directory Confirm/Goedel.Confirm" >&2
! make NORECURSE=true -C Confirm/Goedel.Confirm

# Project : Goedel.Confirm.Client.dll
# Item :  Confirm/Goedel.Confirm.Client
# Output :     Confirm/Goedel.Confirm.Client/$(TARGETBIN)/Goedel.Confirm.Client.dll

all : Confirm/Goedel.Confirm.Client/$(TARGETBIN)/Goedel.Confirm.Client.dll

Confirm/Goedel.Confirm.Client/$(TARGETBIN)/Goedel.Confirm.Client.dll : Confirm/Goedel.Confirm.Client/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Confirm/Goedel.Confirm.Client/$(TARGETBIN)/Goedel.Confirm.Client.dll : Confirm/Goedel.Confirm.Client/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Confirm/Goedel.Confirm.Client/$(TARGETBIN)/Goedel.Confirm.Client.dll : Confirm/Goedel.Confirm.Client/../$(TARGETBIN)/Goedel.Confirm.dll


Confirm/Goedel.Confirm.Client/$(TARGETBIN)/Goedel.Confirm.Client.dll : always
! echo "" >&2
! echo "*** Directory Confirm/Goedel.Confirm.Client" >&2
! make NORECURSE=true -C Confirm/Goedel.Confirm.Client

# Project : Goedel.Confirm.Server.dll
# Item :  Confirm/Goedel.Confirm.Server
# Output :     Confirm/Goedel.Confirm.Server/$(TARGETBIN)/Goedel.Confirm.Server.dll

all : Confirm/Goedel.Confirm.Server/$(TARGETBIN)/Goedel.Confirm.Server.dll

Confirm/Goedel.Confirm.Server/$(TARGETBIN)/Goedel.Confirm.Server.dll : Confirm/Goedel.Confirm.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Jose.dll

Confirm/Goedel.Confirm.Server/$(TARGETBIN)/Goedel.Confirm.Server.dll : Confirm/Goedel.Confirm.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Confirm/Goedel.Confirm.Server/$(TARGETBIN)/Goedel.Confirm.Server.dll : Confirm/Goedel.Confirm.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Persistence.dll

Confirm/Goedel.Confirm.Server/$(TARGETBIN)/Goedel.Confirm.Server.dll : Confirm/Goedel.Confirm.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Confirm/Goedel.Confirm.Server/$(TARGETBIN)/Goedel.Confirm.Server.dll : Confirm/Goedel.Confirm.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Confirm/Goedel.Confirm.Server/$(TARGETBIN)/Goedel.Confirm.Server.dll : Confirm/Goedel.Confirm.Server/../$(TARGETBIN)/Goedel.Confirm.dll


Confirm/Goedel.Confirm.Server/$(TARGETBIN)/Goedel.Confirm.Server.dll : always
! echo "" >&2
! echo "*** Directory Confirm/Goedel.Confirm.Server" >&2
! make NORECURSE=true -C Confirm/Goedel.Confirm.Server

# Project : Goedel.Confirm.Shell.Server.exe
# Item :  Confirm/Goedel.Confirm.Shell.Server
# Output :     Confirm/Goedel.Confirm.Shell.Server/$(TARGETEXE)/Goedel.Confirm.Shell.Server.exe

all : Confirm/Goedel.Confirm.Shell.Server/$(TARGETBIN)/Goedel.Confirm.Shell.Server.exe

Confirm/Goedel.Confirm.Shell.Server/$(TARGETBIN)/Goedel.Confirm.Shell.Server.exe : Confirm/Goedel.Confirm.Shell.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Command.dll

Confirm/Goedel.Confirm.Shell.Server/$(TARGETBIN)/Goedel.Confirm.Shell.Server.exe : Confirm/Goedel.Confirm.Shell.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Confirm/Goedel.Confirm.Shell.Server/$(TARGETBIN)/Goedel.Confirm.Shell.Server.exe : Confirm/Goedel.Confirm.Shell.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Confirm/Goedel.Confirm.Shell.Server/$(TARGETBIN)/Goedel.Confirm.Shell.Server.exe : Confirm/Goedel.Confirm.Shell.Server/../$(TARGETBIN)/Goedel.Confirm.Server.dll

Confirm/Goedel.Confirm.Shell.Server/$(TARGETBIN)/Goedel.Confirm.Shell.Server.exe : Confirm/Goedel.Confirm.Shell.Server/../$(TARGETBIN)/Goedel.Confirm.dll


Confirm/Goedel.Confirm.Shell.Server/$(TARGETBIN)/Goedel.Confirm.Shell.Server.exe : always
! echo "" >&2
! echo "*** Directory Confirm/Goedel.Confirm.Shell.Server" >&2
! make NORECURSE=true -C Confirm/Goedel.Confirm.Shell.Server

# Project : Test.Confirm.dll
# Item :  Confirm/Test.Confirm
# Output :     Confirm/Test.Confirm/$(TARGETBIN)/Test.Confirm.dll

all : Confirm/Test.Confirm/$(TARGETBIN)/Test.Confirm.dll

Confirm/Test.Confirm/$(TARGETBIN)/Test.Confirm.dll : Confirm/Test.Confirm/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Jose.dll

Confirm/Test.Confirm/$(TARGETBIN)/Test.Confirm.dll : Confirm/Test.Confirm/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Confirm/Test.Confirm/$(TARGETBIN)/Test.Confirm.dll : Confirm/Test.Confirm/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Confirm/Test.Confirm/$(TARGETBIN)/Test.Confirm.dll : Confirm/Test.Confirm/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Confirm/Test.Confirm/$(TARGETBIN)/Test.Confirm.dll : Confirm/Test.Confirm/../$(TARGETBIN)/Goedel.Confirm.Client.dll

Confirm/Test.Confirm/$(TARGETBIN)/Test.Confirm.dll : Confirm/Test.Confirm/../$(TARGETBIN)/Goedel.Confirm.Server.dll

Confirm/Test.Confirm/$(TARGETBIN)/Test.Confirm.dll : Confirm/Test.Confirm/../$(TARGETBIN)/Goedel.Confirm.dll


Confirm/Test.Confirm/$(TARGETBIN)/Test.Confirm.dll : always
! echo "" >&2
! echo "*** Directory Confirm/Test.Confirm" >&2
! make NORECURSE=true -C Confirm/Test.Confirm

# Project : Goedel.Recrypt.dll
# Item :  Recrypt/Goedel.Recrypt
# Output :     Recrypt/Goedel.Recrypt/$(TARGETBIN)/Goedel.Recrypt.dll

all : Recrypt/Goedel.Recrypt/$(TARGETBIN)/Goedel.Recrypt.dll

Recrypt/Goedel.Recrypt/$(TARGETBIN)/Goedel.Recrypt.dll : Recrypt/Goedel.Recrypt/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Jose.dll

Recrypt/Goedel.Recrypt/$(TARGETBIN)/Goedel.Recrypt.dll : Recrypt/Goedel.Recrypt/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Recrypt/Goedel.Recrypt/$(TARGETBIN)/Goedel.Recrypt.dll : Recrypt/Goedel.Recrypt/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Recrypt/Goedel.Recrypt/$(TARGETBIN)/Goedel.Recrypt.dll : Recrypt/Goedel.Recrypt/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Recrypt/Goedel.Recrypt/$(TARGETBIN)/Goedel.Recrypt.dll : Recrypt/Goedel.Recrypt/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.dll

Recrypt/Goedel.Recrypt/$(TARGETBIN)/Goedel.Recrypt.dll : Recrypt/Goedel.Recrypt/../../Mesh/$(TARGETBIN)/Goedel.Mesh.dll


Recrypt/Goedel.Recrypt/$(TARGETBIN)/Goedel.Recrypt.dll : always
! echo "" >&2
! echo "*** Directory Recrypt/Goedel.Recrypt" >&2
! make NORECURSE=true -C Recrypt/Goedel.Recrypt

# Project : Goedel.Recrypt.Client.dll
# Item :  Recrypt/Goedel.Recrypt.Client
# Output :     Recrypt/Goedel.Recrypt.Client/$(TARGETBIN)/Goedel.Recrypt.Client.dll

all : Recrypt/Goedel.Recrypt.Client/$(TARGETBIN)/Goedel.Recrypt.Client.dll

Recrypt/Goedel.Recrypt.Client/$(TARGETBIN)/Goedel.Recrypt.Client.dll : Recrypt/Goedel.Recrypt.Client/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Jose.dll

Recrypt/Goedel.Recrypt.Client/$(TARGETBIN)/Goedel.Recrypt.Client.dll : Recrypt/Goedel.Recrypt.Client/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Recrypt/Goedel.Recrypt.Client/$(TARGETBIN)/Goedel.Recrypt.Client.dll : Recrypt/Goedel.Recrypt.Client/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Recrypt/Goedel.Recrypt.Client/$(TARGETBIN)/Goedel.Recrypt.Client.dll : Recrypt/Goedel.Recrypt.Client/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Recrypt/Goedel.Recrypt.Client/$(TARGETBIN)/Goedel.Recrypt.Client.dll : Recrypt/Goedel.Recrypt.Client/../../Mesh/$(TARGETBIN)/Goedel.Mesh.dll

Recrypt/Goedel.Recrypt.Client/$(TARGETBIN)/Goedel.Recrypt.Client.dll : Recrypt/Goedel.Recrypt.Client/../$(TARGETBIN)/Goedel.Recrypt.dll


Recrypt/Goedel.Recrypt.Client/$(TARGETBIN)/Goedel.Recrypt.Client.dll : always
! echo "" >&2
! echo "*** Directory Recrypt/Goedel.Recrypt.Client" >&2
! make NORECURSE=true -C Recrypt/Goedel.Recrypt.Client

# Project : Goedel.Recrypt.Server.dll
# Item :  Recrypt/Goedel.Recrypt.Server
# Output :     Recrypt/Goedel.Recrypt.Server/$(TARGETBIN)/Goedel.Recrypt.Server.dll

all : Recrypt/Goedel.Recrypt.Server/$(TARGETBIN)/Goedel.Recrypt.Server.dll

Recrypt/Goedel.Recrypt.Server/$(TARGETBIN)/Goedel.Recrypt.Server.dll : Recrypt/Goedel.Recrypt.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Jose.dll

Recrypt/Goedel.Recrypt.Server/$(TARGETBIN)/Goedel.Recrypt.Server.dll : Recrypt/Goedel.Recrypt.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Recrypt/Goedel.Recrypt.Server/$(TARGETBIN)/Goedel.Recrypt.Server.dll : Recrypt/Goedel.Recrypt.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Persistence.dll

Recrypt/Goedel.Recrypt.Server/$(TARGETBIN)/Goedel.Recrypt.Server.dll : Recrypt/Goedel.Recrypt.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Recrypt/Goedel.Recrypt.Server/$(TARGETBIN)/Goedel.Recrypt.Server.dll : Recrypt/Goedel.Recrypt.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Recrypt/Goedel.Recrypt.Server/$(TARGETBIN)/Goedel.Recrypt.Server.dll : Recrypt/Goedel.Recrypt.Server/../$(TARGETBIN)/Goedel.Recrypt.dll


Recrypt/Goedel.Recrypt.Server/$(TARGETBIN)/Goedel.Recrypt.Server.dll : always
! echo "" >&2
! echo "*** Directory Recrypt/Goedel.Recrypt.Server" >&2
! make NORECURSE=true -C Recrypt/Goedel.Recrypt.Server

# Project : Goedel.Shell.Recrypt.exe
# Item :  Recrypt/Goedel.Recrypt.Shell.Client
# Output :     Recrypt/Goedel.Recrypt.Shell.Client/$(TARGETEXE)/Goedel.Shell.Recrypt.exe

all : Recrypt/Goedel.Recrypt.Shell.Client/$(TARGETBIN)/Goedel.Shell.Recrypt.exe

Recrypt/Goedel.Recrypt.Shell.Client/$(TARGETBIN)/Goedel.Shell.Recrypt.exe : Recrypt/Goedel.Recrypt.Shell.Client/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Command.dll

Recrypt/Goedel.Recrypt.Shell.Client/$(TARGETBIN)/Goedel.Shell.Recrypt.exe : Recrypt/Goedel.Recrypt.Shell.Client/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Recrypt/Goedel.Recrypt.Shell.Client/$(TARGETBIN)/Goedel.Shell.Recrypt.exe : Recrypt/Goedel.Recrypt.Shell.Client/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Recrypt/Goedel.Recrypt.Shell.Client/$(TARGETBIN)/Goedel.Shell.Recrypt.exe : Recrypt/Goedel.Recrypt.Shell.Client/../$(TARGETBIN)/Goedel.Recrypt.dll


Recrypt/Goedel.Recrypt.Shell.Client/$(TARGETBIN)/Goedel.Shell.Recrypt.exe : always
! echo "" >&2
! echo "*** Directory Recrypt/Goedel.Recrypt.Shell.Client" >&2
! make NORECURSE=true -C Recrypt/Goedel.Recrypt.Shell.Client

# Project : Goedel.Recrypt.Shell.Server.exe
# Item :  Recrypt/Goedel.Recrypt.Shell.Server
# Output :     Recrypt/Goedel.Recrypt.Shell.Server/$(TARGETEXE)/Goedel.Recrypt.Shell.Server.exe

all : Recrypt/Goedel.Recrypt.Shell.Server/$(TARGETBIN)/Goedel.Recrypt.Shell.Server.exe

Recrypt/Goedel.Recrypt.Shell.Server/$(TARGETBIN)/Goedel.Recrypt.Shell.Server.exe : Recrypt/Goedel.Recrypt.Shell.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Command.dll

Recrypt/Goedel.Recrypt.Shell.Server/$(TARGETBIN)/Goedel.Recrypt.Shell.Server.exe : Recrypt/Goedel.Recrypt.Shell.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Discovery.dll

Recrypt/Goedel.Recrypt.Shell.Server/$(TARGETBIN)/Goedel.Recrypt.Shell.Server.exe : Recrypt/Goedel.Recrypt.Shell.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Recrypt/Goedel.Recrypt.Shell.Server/$(TARGETBIN)/Goedel.Recrypt.Shell.Server.exe : Recrypt/Goedel.Recrypt.Shell.Server/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Recrypt/Goedel.Recrypt.Shell.Server/$(TARGETBIN)/Goedel.Recrypt.Shell.Server.exe : Recrypt/Goedel.Recrypt.Shell.Server/../$(TARGETBIN)/Goedel.Recrypt.Server.dll

Recrypt/Goedel.Recrypt.Shell.Server/$(TARGETBIN)/Goedel.Recrypt.Shell.Server.exe : Recrypt/Goedel.Recrypt.Shell.Server/../$(TARGETBIN)/Goedel.Recrypt.dll


Recrypt/Goedel.Recrypt.Shell.Server/$(TARGETBIN)/Goedel.Recrypt.Shell.Server.exe : always
! echo "" >&2
! echo "*** Directory Recrypt/Goedel.Recrypt.Shell.Server" >&2
! make NORECURSE=true -C Recrypt/Goedel.Recrypt.Shell.Server

# Project : Test.Recrypt.dll
# Item :  Recrypt/Test.Recrypt
# Output :     Recrypt/Test.Recrypt/$(TARGETBIN)/Test.Recrypt.dll

all : Recrypt/Test.Recrypt/$(TARGETBIN)/Test.Recrypt.dll

Recrypt/Test.Recrypt/$(TARGETBIN)/Test.Recrypt.dll : Recrypt/Test.Recrypt/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Jose.dll

Recrypt/Test.Recrypt/$(TARGETBIN)/Test.Recrypt.dll : Recrypt/Test.Recrypt/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Recrypt/Test.Recrypt/$(TARGETBIN)/Test.Recrypt.dll : Recrypt/Test.Recrypt/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Recrypt/Test.Recrypt/$(TARGETBIN)/Test.Recrypt.dll : Recrypt/Test.Recrypt/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Recrypt/Test.Recrypt/$(TARGETBIN)/Test.Recrypt.dll : Recrypt/Test.Recrypt/../$(TARGETBIN)/Goedel.Recrypt.Client.dll

Recrypt/Test.Recrypt/$(TARGETBIN)/Test.Recrypt.dll : Recrypt/Test.Recrypt/../$(TARGETBIN)/Goedel.Recrypt.Server.dll

Recrypt/Test.Recrypt/$(TARGETBIN)/Test.Recrypt.dll : Recrypt/Test.Recrypt/../$(TARGETBIN)/Goedel.Recrypt.dll


Recrypt/Test.Recrypt/$(TARGETBIN)/Test.Recrypt.dll : always
! echo "" >&2
! echo "*** Directory Recrypt/Test.Recrypt" >&2
! make NORECURSE=true -C Recrypt/Test.Recrypt

# Project : RunMeshApps.exe
# Item :  Shells/RunMeshApps
# Output :     Shells/RunMeshApps/$(TARGETEXE)/RunMeshApps.exe

all : Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Command.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Windows.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Discovery.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.IO.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Persistence.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.Debug.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Registry.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Client.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.Linux.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Server.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../Mesh/$(TARGETBIN)/Goedel.Mesh.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../Account/$(TARGETBIN)/Goedel.Account.Client.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../Account/$(TARGETBIN)/Goedel.Account.Server.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../Account/$(TARGETBIN)/Goedel.Account.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../Confirm/$(TARGETBIN)/Goedel.Confirm.Client.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../Confirm/$(TARGETBIN)/Goedel.Confirm.Server.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../Confirm/$(TARGETBIN)/Goedel.Confirm.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../Recrypt/$(TARGETBIN)/Goedel.Recrypt.Client.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../Recrypt/$(TARGETBIN)/Goedel.Recrypt.Server.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../../Recrypt/$(TARGETBIN)/Goedel.Recrypt.dll

Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : Shells/RunMeshApps/../$(TARGETBIN)/Goedel.Combined.Shell.Client.dll


Shells/RunMeshApps/$(TARGETBIN)/RunMeshApps.exe : always
! echo "" >&2
! echo "*** Directory Shells/RunMeshApps" >&2
! make NORECURSE=true -C Shells/RunMeshApps

# Project : Goedel.Mesh.Platform.Linux.dll
# Item :  Mesh/Goedel.Mesh.Platform.Linux
# Output :     Mesh/Goedel.Mesh.Platform.Linux/$(TARGETBIN)/Goedel.Mesh.Platform.Linux.dll

all : Mesh/Goedel.Mesh.Platform.Linux/$(TARGETBIN)/Goedel.Mesh.Platform.Linux.dll

Mesh/Goedel.Mesh.Platform.Linux/$(TARGETBIN)/Goedel.Mesh.Platform.Linux.dll : Mesh/Goedel.Mesh.Platform.Linux/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Jose.dll

Mesh/Goedel.Mesh.Platform.Linux/$(TARGETBIN)/Goedel.Mesh.Platform.Linux.dll : Mesh/Goedel.Mesh.Platform.Linux/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Linux.dll

Mesh/Goedel.Mesh.Platform.Linux/$(TARGETBIN)/Goedel.Mesh.Platform.Linux.dll : Mesh/Goedel.Mesh.Platform.Linux/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Mesh/Goedel.Mesh.Platform.Linux/$(TARGETBIN)/Goedel.Mesh.Platform.Linux.dll : Mesh/Goedel.Mesh.Platform.Linux/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Discovery.dll

Mesh/Goedel.Mesh.Platform.Linux/$(TARGETBIN)/Goedel.Mesh.Platform.Linux.dll : Mesh/Goedel.Mesh.Platform.Linux/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Mesh/Goedel.Mesh.Platform.Linux/$(TARGETBIN)/Goedel.Mesh.Platform.Linux.dll : Mesh/Goedel.Mesh.Platform.Linux/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Mesh/Goedel.Mesh.Platform.Linux/$(TARGETBIN)/Goedel.Mesh.Platform.Linux.dll : Mesh/Goedel.Mesh.Platform.Linux/../$(TARGETBIN)/Goedel.Mesh.Client.dll

Mesh/Goedel.Mesh.Platform.Linux/$(TARGETBIN)/Goedel.Mesh.Platform.Linux.dll : Mesh/Goedel.Mesh.Platform.Linux/../$(TARGETBIN)/Goedel.Mesh.Platform.dll

Mesh/Goedel.Mesh.Platform.Linux/$(TARGETBIN)/Goedel.Mesh.Platform.Linux.dll : Mesh/Goedel.Mesh.Platform.Linux/../$(TARGETBIN)/Goedel.Mesh.Server.dll

Mesh/Goedel.Mesh.Platform.Linux/$(TARGETBIN)/Goedel.Mesh.Platform.Linux.dll : Mesh/Goedel.Mesh.Platform.Linux/../$(TARGETBIN)/Goedel.Mesh.dll


Mesh/Goedel.Mesh.Platform.Linux/$(TARGETBIN)/Goedel.Mesh.Platform.Linux.dll : always
! echo "" >&2
! echo "*** Directory Mesh/Goedel.Mesh.Platform.Linux" >&2
! make NORECURSE=true -C Mesh/Goedel.Mesh.Platform.Linux

# Project : Goedel.Combined.Shell.Client.dll
# Item :  Shells/CombinedClient
# Output :     Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll

all : Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll

Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll : Shells/CombinedClient/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Command.dll

Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll : Shells/CombinedClient/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Jose.dll

Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll : Shells/CombinedClient/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll : Shells/CombinedClient/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.FSR.dll

Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll : Shells/CombinedClient/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.IO.dll

Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll : Shells/CombinedClient/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll : Shells/CombinedClient/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll : Shells/CombinedClient/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Client.dll

Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll : Shells/CombinedClient/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll

Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll : Shells/CombinedClient/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.dll

Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll : Shells/CombinedClient/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Server.dll

Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll : Shells/CombinedClient/../../Mesh/$(TARGETBIN)/Goedel.Mesh.dll

Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll : Shells/CombinedClient/../../Account/$(TARGETBIN)/Goedel.Account.Client.dll

Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll : Shells/CombinedClient/../../Account/$(TARGETBIN)/Goedel.Account.dll

Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll : Shells/CombinedClient/../../Confirm/$(TARGETBIN)/Goedel.Confirm.Client.dll

Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll : Shells/CombinedClient/../../Confirm/$(TARGETBIN)/Goedel.Confirm.dll

Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll : Shells/CombinedClient/../../Recrypt/$(TARGETBIN)/Goedel.Recrypt.Client.dll

Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll : Shells/CombinedClient/../../Recrypt/$(TARGETBIN)/Goedel.Recrypt.dll


Shells/CombinedClient/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll : always
! echo "" >&2
! echo "*** Directory Shells/CombinedClient" >&2
! make NORECURSE=true -C Shells/CombinedClient

# Project : ContentProject.dll
# Item :  Documentation/MMMLibraries/ContentProject
# Output :     Documentation/MMMLibraries/ContentProject/$(TARGETBIN)/ContentProject.dll

all : Documentation/MMMLibraries/ContentProject/$(TARGETBIN)/ContentProject.dll


Documentation/MMMLibraries/ContentProject/$(TARGETBIN)/ContentProject.dll : always
! echo "" >&2
! echo "*** Directory Documentation/MMMLibraries/ContentProject" >&2
! make NORECURSE=true -C Documentation/MMMLibraries/ContentProject

# Project : Goedel.ASN.dll
# Item :  ../buildtools/Libraries/Goedel.ASN
# Output :     ../buildtools/Libraries/Goedel.ASN/$(TARGETBIN)/Goedel.ASN.dll

all : ../buildtools/Libraries/Goedel.ASN/$(TARGETBIN)/Goedel.ASN.dll

../buildtools/Libraries/Goedel.ASN/$(TARGETBIN)/Goedel.ASN.dll : ../buildtools/Libraries/Goedel.ASN/../$(TARGETBIN)/Goedel.Utilities.dll


../buildtools/Libraries/Goedel.ASN/$(TARGETBIN)/Goedel.ASN.dll : always
! echo "" >&2
! echo "*** Directory ../buildtools/Libraries/Goedel.ASN" >&2
! make NORECURSE=true -C ../buildtools/Libraries/Goedel.ASN

# Project : Goedel.Command.dll
# Item :  ../buildtools/Libraries/Goedel.Command
# Output :     ../buildtools/Libraries/Goedel.Command/$(TARGETBIN)/Goedel.Command.dll

all : ../buildtools/Libraries/Goedel.Command/$(TARGETBIN)/Goedel.Command.dll

../buildtools/Libraries/Goedel.Command/$(TARGETBIN)/Goedel.Command.dll : ../buildtools/Libraries/Goedel.Command/../$(TARGETBIN)/Goedel.FSR.dll

../buildtools/Libraries/Goedel.Command/$(TARGETBIN)/Goedel.Command.dll : ../buildtools/Libraries/Goedel.Command/../$(TARGETBIN)/Goedel.Registry.dll

../buildtools/Libraries/Goedel.Command/$(TARGETBIN)/Goedel.Command.dll : ../buildtools/Libraries/Goedel.Command/../$(TARGETBIN)/Goedel.Utilities.dll


../buildtools/Libraries/Goedel.Command/$(TARGETBIN)/Goedel.Command.dll : always
! echo "" >&2
! echo "*** Directory ../buildtools/Libraries/Goedel.Command" >&2
! make NORECURSE=true -C ../buildtools/Libraries/Goedel.Command

# Project : Goedel.Cryptography.dll
# Item :  ../buildtools/Libraries/Goedel.Cryptography
# Output :     ../buildtools/Libraries/Goedel.Cryptography/$(TARGETBIN)/Goedel.Cryptography.dll

all : ../buildtools/Libraries/Goedel.Cryptography/$(TARGETBIN)/Goedel.Cryptography.dll

../buildtools/Libraries/Goedel.Cryptography/$(TARGETBIN)/Goedel.Cryptography.dll : ../buildtools/Libraries/Goedel.Cryptography/../$(TARGETBIN)/Goedel.ASN.dll

../buildtools/Libraries/Goedel.Cryptography/$(TARGETBIN)/Goedel.Cryptography.dll : ../buildtools/Libraries/Goedel.Cryptography/../$(TARGETBIN)/Goedel.Utilities.dll


../buildtools/Libraries/Goedel.Cryptography/$(TARGETBIN)/Goedel.Cryptography.dll : always
! echo "" >&2
! echo "*** Directory ../buildtools/Libraries/Goedel.Cryptography" >&2
! make NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography

# Project : Goedel.Cryptography.Container.dll
# Item :  ../buildtools/Libraries/Goedel.Cryptography.Container
# Output :     ../buildtools/Libraries/Goedel.Cryptography.Container/$(TARGETBIN)/Goedel.Cryptography.Container.dll

all : ../buildtools/Libraries/Goedel.Cryptography.Container/$(TARGETBIN)/Goedel.Cryptography.Container.dll

../buildtools/Libraries/Goedel.Cryptography.Container/$(TARGETBIN)/Goedel.Cryptography.Container.dll : ../buildtools/Libraries/Goedel.Cryptography.Container/../$(TARGETBIN)/Goedel.Cryptography.Jose.dll

../buildtools/Libraries/Goedel.Cryptography.Container/$(TARGETBIN)/Goedel.Cryptography.Container.dll : ../buildtools/Libraries/Goedel.Cryptography.Container/../$(TARGETBIN)/Goedel.Cryptography.dll

../buildtools/Libraries/Goedel.Cryptography.Container/$(TARGETBIN)/Goedel.Cryptography.Container.dll : ../buildtools/Libraries/Goedel.Cryptography.Container/../$(TARGETBIN)/Goedel.Protocol.dll

../buildtools/Libraries/Goedel.Cryptography.Container/$(TARGETBIN)/Goedel.Cryptography.Container.dll : ../buildtools/Libraries/Goedel.Cryptography.Container/../$(TARGETBIN)/Goedel.Utilities.dll

../buildtools/Libraries/Goedel.Cryptography.Container/$(TARGETBIN)/Goedel.Cryptography.Container.dll : ../buildtools/Libraries/Goedel.Cryptography.Container/../$(TARGETBIN)/Goedel.IO.dll


../buildtools/Libraries/Goedel.Cryptography.Container/$(TARGETBIN)/Goedel.Cryptography.Container.dll : always
! echo "" >&2
! echo "*** Directory ../buildtools/Libraries/Goedel.Cryptography.Container" >&2
! make NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.Container

# Project : Goedel.Cryptography.Framework.dll
# Item :  ../buildtools/Libraries/Goedel.Cryptography.Framework
# Output :     ../buildtools/Libraries/Goedel.Cryptography.Framework/$(TARGETBIN)/Goedel.Cryptography.Framework.dll

all : ../buildtools/Libraries/Goedel.Cryptography.Framework/$(TARGETBIN)/Goedel.Cryptography.Framework.dll

../buildtools/Libraries/Goedel.Cryptography.Framework/$(TARGETBIN)/Goedel.Cryptography.Framework.dll : ../buildtools/Libraries/Goedel.Cryptography.Framework/../$(TARGETBIN)/Goedel.ASN.dll

../buildtools/Libraries/Goedel.Cryptography.Framework/$(TARGETBIN)/Goedel.Cryptography.Framework.dll : ../buildtools/Libraries/Goedel.Cryptography.Framework/../$(TARGETBIN)/Goedel.Cryptography.dll

../buildtools/Libraries/Goedel.Cryptography.Framework/$(TARGETBIN)/Goedel.Cryptography.Framework.dll : ../buildtools/Libraries/Goedel.Cryptography.Framework/../$(TARGETBIN)/Goedel.Utilities.dll


../buildtools/Libraries/Goedel.Cryptography.Framework/$(TARGETBIN)/Goedel.Cryptography.Framework.dll : always
! echo "" >&2
! echo "*** Directory ../buildtools/Libraries/Goedel.Cryptography.Framework" >&2
! make NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.Framework

# Project : Goedel.Cryptography.Jose.dll
# Item :  ../buildtools/Libraries/Goedel.Cryptography.Jose
# Output :     ../buildtools/Libraries/Goedel.Cryptography.Jose/$(TARGETBIN)/Goedel.Cryptography.Jose.dll

all : ../buildtools/Libraries/Goedel.Cryptography.Jose/$(TARGETBIN)/Goedel.Cryptography.Jose.dll

../buildtools/Libraries/Goedel.Cryptography.Jose/$(TARGETBIN)/Goedel.Cryptography.Jose.dll : ../buildtools/Libraries/Goedel.Cryptography.Jose/../$(TARGETBIN)/Goedel.ASN.dll

../buildtools/Libraries/Goedel.Cryptography.Jose/$(TARGETBIN)/Goedel.Cryptography.Jose.dll : ../buildtools/Libraries/Goedel.Cryptography.Jose/../$(TARGETBIN)/Goedel.Cryptography.dll

../buildtools/Libraries/Goedel.Cryptography.Jose/$(TARGETBIN)/Goedel.Cryptography.Jose.dll : ../buildtools/Libraries/Goedel.Cryptography.Jose/../$(TARGETBIN)/Goedel.Protocol.dll

../buildtools/Libraries/Goedel.Cryptography.Jose/$(TARGETBIN)/Goedel.Cryptography.Jose.dll : ../buildtools/Libraries/Goedel.Cryptography.Jose/../$(TARGETBIN)/Goedel.Utilities.dll


../buildtools/Libraries/Goedel.Cryptography.Jose/$(TARGETBIN)/Goedel.Cryptography.Jose.dll : always
! echo "" >&2
! echo "*** Directory ../buildtools/Libraries/Goedel.Cryptography.Jose" >&2
! make NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.Jose

# Project : Goedel.Cryptography.KeyFile.dll
# Item :  ../buildtools/Libraries/Goedel.Cryptography.KeyFile
# Output :     ../buildtools/Libraries/Goedel.Cryptography.KeyFile/$(TARGETBIN)/Goedel.Cryptography.KeyFile.dll

all : ../buildtools/Libraries/Goedel.Cryptography.KeyFile/$(TARGETBIN)/Goedel.Cryptography.KeyFile.dll

../buildtools/Libraries/Goedel.Cryptography.KeyFile/$(TARGETBIN)/Goedel.Cryptography.KeyFile.dll : ../buildtools/Libraries/Goedel.Cryptography.KeyFile/../$(TARGETBIN)/Goedel.ASN.dll

../buildtools/Libraries/Goedel.Cryptography.KeyFile/$(TARGETBIN)/Goedel.Cryptography.KeyFile.dll : ../buildtools/Libraries/Goedel.Cryptography.KeyFile/../$(TARGETBIN)/Goedel.Cryptography.dll

../buildtools/Libraries/Goedel.Cryptography.KeyFile/$(TARGETBIN)/Goedel.Cryptography.KeyFile.dll : ../buildtools/Libraries/Goedel.Cryptography.KeyFile/../$(TARGETBIN)/Goedel.FSR.dll

../buildtools/Libraries/Goedel.Cryptography.KeyFile/$(TARGETBIN)/Goedel.Cryptography.KeyFile.dll : ../buildtools/Libraries/Goedel.Cryptography.KeyFile/../$(TARGETBIN)/Goedel.Utilities.dll

../buildtools/Libraries/Goedel.Cryptography.KeyFile/$(TARGETBIN)/Goedel.Cryptography.KeyFile.dll : ../buildtools/Libraries/Goedel.Cryptography.KeyFile/../$(TARGETBIN)/Goedel.Cryptography.Framework.dll

../buildtools/Libraries/Goedel.Cryptography.KeyFile/$(TARGETBIN)/Goedel.Cryptography.KeyFile.dll : ../buildtools/Libraries/Goedel.Cryptography.KeyFile/../$(TARGETBIN)/Goedel.IO.dll


../buildtools/Libraries/Goedel.Cryptography.KeyFile/$(TARGETBIN)/Goedel.Cryptography.KeyFile.dll : always
! echo "" >&2
! echo "*** Directory ../buildtools/Libraries/Goedel.Cryptography.KeyFile" >&2
! make NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.KeyFile

# Project : Goedel.Cryptography.Linux.dll
# Item :  ../buildtools/Libraries/Goedel.Cryptography.Linux
# Output :     ../buildtools/Libraries/Goedel.Cryptography.Linux/$(TARGETBIN)/Goedel.Cryptography.Linux.dll

all : ../buildtools/Libraries/Goedel.Cryptography.Linux/$(TARGETBIN)/Goedel.Cryptography.Linux.dll

../buildtools/Libraries/Goedel.Cryptography.Linux/$(TARGETBIN)/Goedel.Cryptography.Linux.dll : ../buildtools/Libraries/Goedel.Cryptography.Linux/../$(TARGETBIN)/Goedel.Cryptography.Jose.dll

../buildtools/Libraries/Goedel.Cryptography.Linux/$(TARGETBIN)/Goedel.Cryptography.Linux.dll : ../buildtools/Libraries/Goedel.Cryptography.Linux/../$(TARGETBIN)/Goedel.Cryptography.dll

../buildtools/Libraries/Goedel.Cryptography.Linux/$(TARGETBIN)/Goedel.Cryptography.Linux.dll : ../buildtools/Libraries/Goedel.Cryptography.Linux/../$(TARGETBIN)/Goedel.Discovery.dll

../buildtools/Libraries/Goedel.Cryptography.Linux/$(TARGETBIN)/Goedel.Cryptography.Linux.dll : ../buildtools/Libraries/Goedel.Cryptography.Linux/../$(TARGETBIN)/Goedel.Protocol.dll

../buildtools/Libraries/Goedel.Cryptography.Linux/$(TARGETBIN)/Goedel.Cryptography.Linux.dll : ../buildtools/Libraries/Goedel.Cryptography.Linux/../$(TARGETBIN)/Goedel.Utilities.dll

../buildtools/Libraries/Goedel.Cryptography.Linux/$(TARGETBIN)/Goedel.Cryptography.Linux.dll : ../buildtools/Libraries/Goedel.Cryptography.Linux/../$(TARGETBIN)/Goedel.Cryptography.Framework.dll

../buildtools/Libraries/Goedel.Cryptography.Linux/$(TARGETBIN)/Goedel.Cryptography.Linux.dll : ../buildtools/Libraries/Goedel.Cryptography.Linux/../$(TARGETBIN)/Goedel.Cryptography.KeyFile.dll

../buildtools/Libraries/Goedel.Cryptography.Linux/$(TARGETBIN)/Goedel.Cryptography.Linux.dll : ../buildtools/Libraries/Goedel.Cryptography.Linux/../$(TARGETBIN)/Goedel.IO.dll


../buildtools/Libraries/Goedel.Cryptography.Linux/$(TARGETBIN)/Goedel.Cryptography.Linux.dll : always
! echo "" >&2
! echo "*** Directory ../buildtools/Libraries/Goedel.Cryptography.Linux" >&2
! make NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.Linux

# Project : Goedel.Cryptography.Windows.dll
# Item :  ../buildtools/Libraries/Goedel.Cryptography.Windows
# Output :     ../buildtools/Libraries/Goedel.Cryptography.Windows/$(TARGETBIN)/Goedel.Cryptography.Windows.dll

all : ../buildtools/Libraries/Goedel.Cryptography.Windows/$(TARGETBIN)/Goedel.Cryptography.Windows.dll

../buildtools/Libraries/Goedel.Cryptography.Windows/$(TARGETBIN)/Goedel.Cryptography.Windows.dll : ../buildtools/Libraries/Goedel.Cryptography.Windows/../$(TARGETBIN)/Goedel.Cryptography.Jose.dll

../buildtools/Libraries/Goedel.Cryptography.Windows/$(TARGETBIN)/Goedel.Cryptography.Windows.dll : ../buildtools/Libraries/Goedel.Cryptography.Windows/../$(TARGETBIN)/Goedel.Cryptography.dll

../buildtools/Libraries/Goedel.Cryptography.Windows/$(TARGETBIN)/Goedel.Cryptography.Windows.dll : ../buildtools/Libraries/Goedel.Cryptography.Windows/../$(TARGETBIN)/Goedel.Protocol.dll

../buildtools/Libraries/Goedel.Cryptography.Windows/$(TARGETBIN)/Goedel.Cryptography.Windows.dll : ../buildtools/Libraries/Goedel.Cryptography.Windows/../$(TARGETBIN)/Goedel.Utilities.dll

../buildtools/Libraries/Goedel.Cryptography.Windows/$(TARGETBIN)/Goedel.Cryptography.Windows.dll : ../buildtools/Libraries/Goedel.Cryptography.Windows/../$(TARGETBIN)/Goedel.Cryptography.Framework.dll

../buildtools/Libraries/Goedel.Cryptography.Windows/$(TARGETBIN)/Goedel.Cryptography.Windows.dll : ../buildtools/Libraries/Goedel.Cryptography.Windows/../$(TARGETBIN)/Goedel.IO.dll


../buildtools/Libraries/Goedel.Cryptography.Windows/$(TARGETBIN)/Goedel.Cryptography.Windows.dll : always
! echo "" >&2
! echo "*** Directory ../buildtools/Libraries/Goedel.Cryptography.Windows" >&2
! make NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.Windows

# Project : Goedel.Discovery.dll
# Item :  ../buildtools/Libraries/Goedel.Discovery
# Output :     ../buildtools/Libraries/Goedel.Discovery/$(TARGETBIN)/Goedel.Discovery.dll

all : ../buildtools/Libraries/Goedel.Discovery/$(TARGETBIN)/Goedel.Discovery.dll

../buildtools/Libraries/Goedel.Discovery/$(TARGETBIN)/Goedel.Discovery.dll : ../buildtools/Libraries/Goedel.Discovery/../$(TARGETBIN)/Goedel.Utilities.dll


../buildtools/Libraries/Goedel.Discovery/$(TARGETBIN)/Goedel.Discovery.dll : always
! echo "" >&2
! echo "*** Directory ../buildtools/Libraries/Goedel.Discovery" >&2
! make NORECURSE=true -C ../buildtools/Libraries/Goedel.Discovery

# Project : Goedel.FSR.dll
# Item :  ../buildtools/Libraries/Goedel.FSR
# Output :     ../buildtools/Libraries/Goedel.FSR/$(TARGETBIN)/Goedel.FSR.dll

all : ../buildtools/Libraries/Goedel.FSR/$(TARGETBIN)/Goedel.FSR.dll

../buildtools/Libraries/Goedel.FSR/$(TARGETBIN)/Goedel.FSR.dll : ../buildtools/Libraries/Goedel.FSR/../$(TARGETBIN)/Goedel.Utilities.dll


../buildtools/Libraries/Goedel.FSR/$(TARGETBIN)/Goedel.FSR.dll : always
! echo "" >&2
! echo "*** Directory ../buildtools/Libraries/Goedel.FSR" >&2
! make NORECURSE=true -C ../buildtools/Libraries/Goedel.FSR

# Project : Goedel.IO.dll
# Item :  ../buildtools/Libraries/Goedel.IO
# Output :     ../buildtools/Libraries/Goedel.IO/$(TARGETBIN)/Goedel.IO.dll

all : ../buildtools/Libraries/Goedel.IO/$(TARGETBIN)/Goedel.IO.dll


../buildtools/Libraries/Goedel.IO/$(TARGETBIN)/Goedel.IO.dll : always
! echo "" >&2
! echo "*** Directory ../buildtools/Libraries/Goedel.IO" >&2
! make NORECURSE=true -C ../buildtools/Libraries/Goedel.IO

# Project : Goedel.Protocol.dll
# Item :  ../buildtools/Libraries/Goedel.Protocol
# Output :     ../buildtools/Libraries/Goedel.Protocol/$(TARGETBIN)/Goedel.Protocol.dll

all : ../buildtools/Libraries/Goedel.Protocol/$(TARGETBIN)/Goedel.Protocol.dll

../buildtools/Libraries/Goedel.Protocol/$(TARGETBIN)/Goedel.Protocol.dll : ../buildtools/Libraries/Goedel.Protocol/../$(TARGETBIN)/Goedel.Discovery.dll

../buildtools/Libraries/Goedel.Protocol/$(TARGETBIN)/Goedel.Protocol.dll : ../buildtools/Libraries/Goedel.Protocol/../$(TARGETBIN)/Goedel.Utilities.dll


../buildtools/Libraries/Goedel.Protocol/$(TARGETBIN)/Goedel.Protocol.dll : always
! echo "" >&2
! echo "*** Directory ../buildtools/Libraries/Goedel.Protocol" >&2
! make NORECURSE=true -C ../buildtools/Libraries/Goedel.Protocol

# Project : Goedel.Protocol.Debug.dll
# Item :  ../buildtools/Libraries/Goedel.Protocol.Debug
# Output :     ../buildtools/Libraries/Goedel.Protocol.Debug/$(TARGETBIN)/Goedel.Protocol.Debug.dll

all : ../buildtools/Libraries/Goedel.Protocol.Debug/$(TARGETBIN)/Goedel.Protocol.Debug.dll

../buildtools/Libraries/Goedel.Protocol.Debug/$(TARGETBIN)/Goedel.Protocol.Debug.dll : ../buildtools/Libraries/Goedel.Protocol.Debug/../$(TARGETBIN)/Goedel.Protocol.dll

../buildtools/Libraries/Goedel.Protocol.Debug/$(TARGETBIN)/Goedel.Protocol.Debug.dll : ../buildtools/Libraries/Goedel.Protocol.Debug/../$(TARGETBIN)/Goedel.Utilities.dll


../buildtools/Libraries/Goedel.Protocol.Debug/$(TARGETBIN)/Goedel.Protocol.Debug.dll : always
! echo "" >&2
! echo "*** Directory ../buildtools/Libraries/Goedel.Protocol.Debug" >&2
! make NORECURSE=true -C ../buildtools/Libraries/Goedel.Protocol.Debug

# Project : Goedel.Protocol.Exchange.dll
# Item :  ../buildtools/Libraries/Goedel.Protocol.Exchange
# Output :     ../buildtools/Libraries/Goedel.Protocol.Exchange/$(TARGETBIN)/Goedel.Protocol.Exchange.dll

all : ../buildtools/Libraries/Goedel.Protocol.Exchange/$(TARGETBIN)/Goedel.Protocol.Exchange.dll

../buildtools/Libraries/Goedel.Protocol.Exchange/$(TARGETBIN)/Goedel.Protocol.Exchange.dll : ../buildtools/Libraries/Goedel.Protocol.Exchange/../$(TARGETBIN)/Goedel.Cryptography.Jose.dll

../buildtools/Libraries/Goedel.Protocol.Exchange/$(TARGETBIN)/Goedel.Protocol.Exchange.dll : ../buildtools/Libraries/Goedel.Protocol.Exchange/../$(TARGETBIN)/Goedel.Cryptography.dll

../buildtools/Libraries/Goedel.Protocol.Exchange/$(TARGETBIN)/Goedel.Protocol.Exchange.dll : ../buildtools/Libraries/Goedel.Protocol.Exchange/../$(TARGETBIN)/Goedel.Protocol.dll

../buildtools/Libraries/Goedel.Protocol.Exchange/$(TARGETBIN)/Goedel.Protocol.Exchange.dll : ../buildtools/Libraries/Goedel.Protocol.Exchange/../$(TARGETBIN)/Goedel.Utilities.dll


../buildtools/Libraries/Goedel.Protocol.Exchange/$(TARGETBIN)/Goedel.Protocol.Exchange.dll : always
! echo "" >&2
! echo "*** Directory ../buildtools/Libraries/Goedel.Protocol.Exchange" >&2
! make NORECURSE=true -C ../buildtools/Libraries/Goedel.Protocol.Exchange

# Project : Goedel.Registry.dll
# Item :  ../buildtools/Libraries/Goedel.Registry
# Output :     ../buildtools/Libraries/Goedel.Registry/$(TARGETBIN)/Goedel.Registry.dll

all : ../buildtools/Libraries/Goedel.Registry/$(TARGETBIN)/Goedel.Registry.dll

../buildtools/Libraries/Goedel.Registry/$(TARGETBIN)/Goedel.Registry.dll : ../buildtools/Libraries/Goedel.Registry/../$(TARGETBIN)/Goedel.FSR.dll

../buildtools/Libraries/Goedel.Registry/$(TARGETBIN)/Goedel.Registry.dll : ../buildtools/Libraries/Goedel.Registry/../$(TARGETBIN)/Goedel.Utilities.dll


../buildtools/Libraries/Goedel.Registry/$(TARGETBIN)/Goedel.Registry.dll : always
! echo "" >&2
! echo "*** Directory ../buildtools/Libraries/Goedel.Registry" >&2
! make NORECURSE=true -C ../buildtools/Libraries/Goedel.Registry

# Project : Goedel.Utilities.dll
# Item :  ../buildtools/Libraries/Goedel.Utilities
# Output :     ../buildtools/Libraries/Goedel.Utilities/$(TARGETBIN)/Goedel.Utilities.dll

all : ../buildtools/Libraries/Goedel.Utilities/$(TARGETBIN)/Goedel.Utilities.dll


../buildtools/Libraries/Goedel.Utilities/$(TARGETBIN)/Goedel.Utilities.dll : always
! echo "" >&2
! echo "*** Directory ../buildtools/Libraries/Goedel.Utilities" >&2
! make NORECURSE=true -C ../buildtools/Libraries/Goedel.Utilities

# Project : Goedel.Test.dll
# Item :  ../buildtools/Libraries/Goedel.Test
# Output :     ../buildtools/Libraries/Goedel.Test/$(TARGETBIN)/Goedel.Test.dll

all : ../buildtools/Libraries/Goedel.Test/$(TARGETBIN)/Goedel.Test.dll

../buildtools/Libraries/Goedel.Test/$(TARGETBIN)/Goedel.Test.dll : ../buildtools/Libraries/Goedel.Test/../$(TARGETBIN)/Goedel.Cryptography.Windows.dll

../buildtools/Libraries/Goedel.Test/$(TARGETBIN)/Goedel.Test.dll : ../buildtools/Libraries/Goedel.Test/../$(TARGETBIN)/Goedel.Cryptography.dll

../buildtools/Libraries/Goedel.Test/$(TARGETBIN)/Goedel.Test.dll : ../buildtools/Libraries/Goedel.Test/../$(TARGETBIN)/Goedel.Discovery.dll

../buildtools/Libraries/Goedel.Test/$(TARGETBIN)/Goedel.Test.dll : ../buildtools/Libraries/Goedel.Test/../$(TARGETBIN)/Goedel.Utilities.dll

../buildtools/Libraries/Goedel.Test/$(TARGETBIN)/Goedel.Test.dll : ../buildtools/Libraries/Goedel.Test/../$(TARGETBIN)/Goedel.Cryptography.Framework.dll

../buildtools/Libraries/Goedel.Test/$(TARGETBIN)/Goedel.Test.dll : ../buildtools/Libraries/Goedel.Test/../$(TARGETBIN)/Goedel.IO.dll


../buildtools/Libraries/Goedel.Test/$(TARGETBIN)/Goedel.Test.dll : always
! echo "" >&2
! echo "*** Directory ../buildtools/Libraries/Goedel.Test" >&2
! make NORECURSE=true -C ../buildtools/Libraries/Goedel.Test

# Project : Goedel.Protocol.Exchange.Server.dll
# Item :  ../buildtools/Libraries/Goedel.Protocol.Exchange.Server
# Output :     ../buildtools/Libraries/Goedel.Protocol.Exchange.Server/$(TARGETBIN)/Goedel.Protocol.Exchange.Server.dll

all : ../buildtools/Libraries/Goedel.Protocol.Exchange.Server/$(TARGETBIN)/Goedel.Protocol.Exchange.Server.dll

../buildtools/Libraries/Goedel.Protocol.Exchange.Server/$(TARGETBIN)/Goedel.Protocol.Exchange.Server.dll : ../buildtools/Libraries/Goedel.Protocol.Exchange.Server/../$(TARGETBIN)/Goedel.Cryptography.Jose.dll

../buildtools/Libraries/Goedel.Protocol.Exchange.Server/$(TARGETBIN)/Goedel.Protocol.Exchange.Server.dll : ../buildtools/Libraries/Goedel.Protocol.Exchange.Server/../$(TARGETBIN)/Goedel.Cryptography.dll

../buildtools/Libraries/Goedel.Protocol.Exchange.Server/$(TARGETBIN)/Goedel.Protocol.Exchange.Server.dll : ../buildtools/Libraries/Goedel.Protocol.Exchange.Server/../$(TARGETBIN)/Goedel.Protocol.dll

../buildtools/Libraries/Goedel.Protocol.Exchange.Server/$(TARGETBIN)/Goedel.Protocol.Exchange.Server.dll : ../buildtools/Libraries/Goedel.Protocol.Exchange.Server/../$(TARGETBIN)/Goedel.Utilities.dll

../buildtools/Libraries/Goedel.Protocol.Exchange.Server/$(TARGETBIN)/Goedel.Protocol.Exchange.Server.dll : ../buildtools/Libraries/Goedel.Protocol.Exchange.Server/../$(TARGETBIN)/Goedel.Protocol.Exchange.dll


../buildtools/Libraries/Goedel.Protocol.Exchange.Server/$(TARGETBIN)/Goedel.Protocol.Exchange.Server.dll : always
! echo "" >&2
! echo "*** Directory ../buildtools/Libraries/Goedel.Protocol.Exchange.Server" >&2
! make NORECURSE=true -C ../buildtools/Libraries/Goedel.Protocol.Exchange.Server

# Project : Goedel.Persistence.dll
# Item :  ../buildtools/Libraries/Goedel.Persistence
# Output :     ../buildtools/Libraries/Goedel.Persistence/$(TARGETBIN)/Goedel.Persistence.dll

all : ../buildtools/Libraries/Goedel.Persistence/$(TARGETBIN)/Goedel.Persistence.dll

../buildtools/Libraries/Goedel.Persistence/$(TARGETBIN)/Goedel.Persistence.dll : ../buildtools/Libraries/Goedel.Persistence/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

../buildtools/Libraries/Goedel.Persistence/$(TARGETBIN)/Goedel.Persistence.dll : ../buildtools/Libraries/Goedel.Persistence/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll


../buildtools/Libraries/Goedel.Persistence/$(TARGETBIN)/Goedel.Persistence.dll : always
! echo "" >&2
! echo "*** Directory ../buildtools/Libraries/Goedel.Persistence" >&2
! make NORECURSE=true -C ../buildtools/Libraries/Goedel.Persistence

# Project : MakeSiteDocs.exe
# Item :  Documentation/MakeSiteDocs
# Output :     Documentation/MakeSiteDocs/$(TARGETEXE)/MakeSiteDocs.exe

all : Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.ASN.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Command.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Container.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Framework.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Jose.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.KeyFile.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.Windows.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Cryptography.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Discovery.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.FSR.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.IO.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.Debug.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.Exchange.Server.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.Exchange.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Protocol.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Registry.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../../buildtools/Libraries/$(TARGETBIN)/Goedel.Utilities.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../Account/$(TARGETBIN)/Goedel.Account.Client.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../Account/$(TARGETBIN)/Goedel.Account.Server.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../Account/$(TARGETBIN)/Goedel.Account.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../Confirm/$(TARGETBIN)/Goedel.Confirm.Client.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../Confirm/$(TARGETBIN)/Goedel.Confirm.Server.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../Confirm/$(TARGETBIN)/Goedel.Confirm.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Client.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.Windows.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Platform.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../Mesh/$(TARGETBIN)/Goedel.Mesh.Server.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../Mesh/$(TARGETBIN)/Goedel.Mesh.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../Recrypt/$(TARGETBIN)/Goedel.Recrypt.Client.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../Recrypt/$(TARGETBIN)/Goedel.Recrypt.Server.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../Recrypt/$(TARGETBIN)/Goedel.Recrypt.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../Shells/$(TARGETBIN)/Goedel.Combined.Shell.Client.dll

Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : Documentation/MakeSiteDocs/../../Shells/$(TARGETBIN)/Goedel.Mesh.Shell.MeshMan.dll


Documentation/MakeSiteDocs/$(TARGETBIN)/MakeSiteDocs.exe : always
! echo "" >&2
! echo "*** Directory Documentation/MakeSiteDocs" >&2
! make NORECURSE=true -C Documentation/MakeSiteDocs



# clean all projects
clean :
! make clean NORECURSE=true -C Shells/AdminDumpLog
! make clean NORECURSE=true -C Mesh/Goedel.Mesh
! make clean NORECURSE=true -C Mesh/Goedel.Mesh.Server
! make clean NORECURSE=true -C Shells/RunMesh
! make clean NORECURSE=true -C Shells/ServerMesh
! make clean NORECURSE=true -C Mesh/Goedel.Mesh.Client
! make clean NORECURSE=true -C Mesh/Goedel.Mesh.Platform.Windows
! make clean NORECURSE=true -C Documentation/MakeExamples
! make clean NORECURSE=true -C Shells/Goedel.Mesh.Shell.MeshMan
! make clean NORECURSE=true -C Mesh/Goedel.Mesh.Platform
! make clean NORECURSE=true -C Shells/meshman_windows
! make clean NORECURSE=true -C Shells/meshman_linux
! make clean NORECURSE=true -C Shells/meshman_osx
! make clean NORECURSE=true -C Testing/Test.Goedel.Mesh.Profile
! make clean NORECURSE=true -C Testing/Test.Goedel.Mesh.Recrypt
! make clean NORECURSE=true -C Testing/Test.Goedel.Mesh.Web
! make clean NORECURSE=true -C Testing/Test.Goedel.Mesh.Confirm
! make clean NORECURSE=true -C Testing/Test.Goedel.Mesh.Services
! make clean NORECURSE=true -C Testing/Test.Constants
! make clean NORECURSE=true -C Testing/Test.Goedel.Mesh.Shell
! make clean NORECURSE=true -C Account/Goedel.Account
! make clean NORECURSE=true -C Account/Goedel.Account.Client
! make clean NORECURSE=true -C Account/Goedel.Account.Server
! make clean NORECURSE=true -C Confirm/Goedel.Confirm
! make clean NORECURSE=true -C Confirm/Goedel.Confirm.Client
! make clean NORECURSE=true -C Confirm/Goedel.Confirm.Server
! make clean NORECURSE=true -C Confirm/Goedel.Confirm.Shell.Server
! make clean NORECURSE=true -C Confirm/Test.Confirm
! make clean NORECURSE=true -C Recrypt/Goedel.Recrypt
! make clean NORECURSE=true -C Recrypt/Goedel.Recrypt.Client
! make clean NORECURSE=true -C Recrypt/Goedel.Recrypt.Server
! make clean NORECURSE=true -C Recrypt/Goedel.Recrypt.Shell.Client
! make clean NORECURSE=true -C Recrypt/Goedel.Recrypt.Shell.Server
! make clean NORECURSE=true -C Recrypt/Test.Recrypt
! make clean NORECURSE=true -C Shells/RunMeshApps
! make clean NORECURSE=true -C Mesh/Goedel.Mesh.Platform.Linux
! make clean NORECURSE=true -C Shells/CombinedClient
! make clean NORECURSE=true -C Documentation/MMMLibraries/ContentProject
! make clean NORECURSE=true -C ../buildtools/Libraries/Goedel.ASN
! make clean NORECURSE=true -C ../buildtools/Libraries/Goedel.Command
! make clean NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography
! make clean NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.Container
! make clean NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.Framework
! make clean NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.Jose
! make clean NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.KeyFile
! make clean NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.Linux
! make clean NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.Windows
! make clean NORECURSE=true -C ../buildtools/Libraries/Goedel.Discovery
! make clean NORECURSE=true -C ../buildtools/Libraries/Goedel.FSR
! make clean NORECURSE=true -C ../buildtools/Libraries/Goedel.IO
! make clean NORECURSE=true -C ../buildtools/Libraries/Goedel.Protocol
! make clean NORECURSE=true -C ../buildtools/Libraries/Goedel.Protocol.Debug
! make clean NORECURSE=true -C ../buildtools/Libraries/Goedel.Protocol.Exchange
! make clean NORECURSE=true -C ../buildtools/Libraries/Goedel.Registry
! make clean NORECURSE=true -C ../buildtools/Libraries/Goedel.Utilities
! make clean NORECURSE=true -C ../buildtools/Libraries/Goedel.Test
! make clean NORECURSE=true -C ../buildtools/Libraries/Goedel.Protocol.Exchange.Server
! make clean NORECURSE=true -C ../buildtools/Libraries/Goedel.Persistence
! make clean NORECURSE=true -C Documentation/MakeSiteDocs

# publish all projects
publish : all
! make publish NORECURSE=true -C Shells/AdminDumpLog
! make publish NORECURSE=true -C Mesh/Goedel.Mesh
! make publish NORECURSE=true -C Mesh/Goedel.Mesh.Server
! make publish NORECURSE=true -C Shells/RunMesh
! make publish NORECURSE=true -C Shells/ServerMesh
! make publish NORECURSE=true -C Mesh/Goedel.Mesh.Client
! make publish NORECURSE=true -C Mesh/Goedel.Mesh.Platform.Windows
! make publish NORECURSE=true -C Documentation/MakeExamples
! make publish NORECURSE=true -C Shells/Goedel.Mesh.Shell.MeshMan
! make publish NORECURSE=true -C Mesh/Goedel.Mesh.Platform
! make publish NORECURSE=true -C Shells/meshman_windows
! make publish NORECURSE=true -C Shells/meshman_linux
! make publish NORECURSE=true -C Shells/meshman_osx
! make publish NORECURSE=true -C Testing/Test.Goedel.Mesh.Profile
! make publish NORECURSE=true -C Testing/Test.Goedel.Mesh.Recrypt
! make publish NORECURSE=true -C Testing/Test.Goedel.Mesh.Web
! make publish NORECURSE=true -C Testing/Test.Goedel.Mesh.Confirm
! make publish NORECURSE=true -C Testing/Test.Goedel.Mesh.Services
! make publish NORECURSE=true -C Testing/Test.Constants
! make publish NORECURSE=true -C Testing/Test.Goedel.Mesh.Shell
! make publish NORECURSE=true -C Account/Goedel.Account
! make publish NORECURSE=true -C Account/Goedel.Account.Client
! make publish NORECURSE=true -C Account/Goedel.Account.Server
! make publish NORECURSE=true -C Confirm/Goedel.Confirm
! make publish NORECURSE=true -C Confirm/Goedel.Confirm.Client
! make publish NORECURSE=true -C Confirm/Goedel.Confirm.Server
! make publish NORECURSE=true -C Confirm/Goedel.Confirm.Shell.Server
! make publish NORECURSE=true -C Confirm/Test.Confirm
! make publish NORECURSE=true -C Recrypt/Goedel.Recrypt
! make publish NORECURSE=true -C Recrypt/Goedel.Recrypt.Client
! make publish NORECURSE=true -C Recrypt/Goedel.Recrypt.Server
! make publish NORECURSE=true -C Recrypt/Goedel.Recrypt.Shell.Client
! make publish NORECURSE=true -C Recrypt/Goedel.Recrypt.Shell.Server
! make publish NORECURSE=true -C Recrypt/Test.Recrypt
! make publish NORECURSE=true -C Shells/RunMeshApps
! make publish NORECURSE=true -C Mesh/Goedel.Mesh.Platform.Linux
! make publish NORECURSE=true -C Shells/CombinedClient
! make publish NORECURSE=true -C Documentation/MMMLibraries/ContentProject
! make publish NORECURSE=true -C ../buildtools/Libraries/Goedel.ASN
! make publish NORECURSE=true -C ../buildtools/Libraries/Goedel.Command
! make publish NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography
! make publish NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.Container
! make publish NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.Framework
! make publish NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.Jose
! make publish NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.KeyFile
! make publish NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.Linux
! make publish NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.Windows
! make publish NORECURSE=true -C ../buildtools/Libraries/Goedel.Discovery
! make publish NORECURSE=true -C ../buildtools/Libraries/Goedel.FSR
! make publish NORECURSE=true -C ../buildtools/Libraries/Goedel.IO
! make publish NORECURSE=true -C ../buildtools/Libraries/Goedel.Protocol
! make publish NORECURSE=true -C ../buildtools/Libraries/Goedel.Protocol.Debug
! make publish NORECURSE=true -C ../buildtools/Libraries/Goedel.Protocol.Exchange
! make publish NORECURSE=true -C ../buildtools/Libraries/Goedel.Registry
! make publish NORECURSE=true -C ../buildtools/Libraries/Goedel.Utilities
! make publish NORECURSE=true -C ../buildtools/Libraries/Goedel.Test
! make publish NORECURSE=true -C ../buildtools/Libraries/Goedel.Protocol.Exchange.Server
! make publish NORECURSE=true -C ../buildtools/Libraries/Goedel.Persistence
! make publish NORECURSE=true -C Documentation/MakeSiteDocs

# install all projects
install : all
! make install NORECURSE=true -C Shells/AdminDumpLog
! make install NORECURSE=true -C Mesh/Goedel.Mesh
! make install NORECURSE=true -C Mesh/Goedel.Mesh.Server
! make install NORECURSE=true -C Shells/RunMesh
! make install NORECURSE=true -C Shells/ServerMesh
! make install NORECURSE=true -C Mesh/Goedel.Mesh.Client
! make install NORECURSE=true -C Mesh/Goedel.Mesh.Platform.Windows
! make install NORECURSE=true -C Documentation/MakeExamples
! make install NORECURSE=true -C Shells/Goedel.Mesh.Shell.MeshMan
! make install NORECURSE=true -C Mesh/Goedel.Mesh.Platform
! make install NORECURSE=true -C Shells/meshman_windows
! make install NORECURSE=true -C Shells/meshman_linux
! make install NORECURSE=true -C Shells/meshman_osx
! make install NORECURSE=true -C Testing/Test.Goedel.Mesh.Profile
! make install NORECURSE=true -C Testing/Test.Goedel.Mesh.Recrypt
! make install NORECURSE=true -C Testing/Test.Goedel.Mesh.Web
! make install NORECURSE=true -C Testing/Test.Goedel.Mesh.Confirm
! make install NORECURSE=true -C Testing/Test.Goedel.Mesh.Services
! make install NORECURSE=true -C Testing/Test.Constants
! make install NORECURSE=true -C Testing/Test.Goedel.Mesh.Shell
! make install NORECURSE=true -C Account/Goedel.Account
! make install NORECURSE=true -C Account/Goedel.Account.Client
! make install NORECURSE=true -C Account/Goedel.Account.Server
! make install NORECURSE=true -C Confirm/Goedel.Confirm
! make install NORECURSE=true -C Confirm/Goedel.Confirm.Client
! make install NORECURSE=true -C Confirm/Goedel.Confirm.Server
! make install NORECURSE=true -C Confirm/Goedel.Confirm.Shell.Server
! make install NORECURSE=true -C Confirm/Test.Confirm
! make install NORECURSE=true -C Recrypt/Goedel.Recrypt
! make install NORECURSE=true -C Recrypt/Goedel.Recrypt.Client
! make install NORECURSE=true -C Recrypt/Goedel.Recrypt.Server
! make install NORECURSE=true -C Recrypt/Goedel.Recrypt.Shell.Client
! make install NORECURSE=true -C Recrypt/Goedel.Recrypt.Shell.Server
! make install NORECURSE=true -C Recrypt/Test.Recrypt
! make install NORECURSE=true -C Shells/RunMeshApps
! make install NORECURSE=true -C Mesh/Goedel.Mesh.Platform.Linux
! make install NORECURSE=true -C Shells/CombinedClient
! make install NORECURSE=true -C Documentation/MMMLibraries/ContentProject
! make install NORECURSE=true -C ../buildtools/Libraries/Goedel.ASN
! make install NORECURSE=true -C ../buildtools/Libraries/Goedel.Command
! make install NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography
! make install NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.Container
! make install NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.Framework
! make install NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.Jose
! make install NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.KeyFile
! make install NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.Linux
! make install NORECURSE=true -C ../buildtools/Libraries/Goedel.Cryptography.Windows
! make install NORECURSE=true -C ../buildtools/Libraries/Goedel.Discovery
! make install NORECURSE=true -C ../buildtools/Libraries/Goedel.FSR
! make install NORECURSE=true -C ../buildtools/Libraries/Goedel.IO
! make install NORECURSE=true -C ../buildtools/Libraries/Goedel.Protocol
! make install NORECURSE=true -C ../buildtools/Libraries/Goedel.Protocol.Debug
! make install NORECURSE=true -C ../buildtools/Libraries/Goedel.Protocol.Exchange
! make install NORECURSE=true -C ../buildtools/Libraries/Goedel.Registry
! make install NORECURSE=true -C ../buildtools/Libraries/Goedel.Utilities
! make install NORECURSE=true -C ../buildtools/Libraries/Goedel.Test
! make install NORECURSE=true -C ../buildtools/Libraries/Goedel.Protocol.Exchange.Server
! make install NORECURSE=true -C ../buildtools/Libraries/Goedel.Persistence
! make install NORECURSE=true -C Documentation/MakeSiteDocs

