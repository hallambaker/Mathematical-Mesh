To set up visual studio you need:

1) Install the PHB Build Tools 

The following directory contains the VSIX package:
\buildtools\Distribution\Release\vsix

There is an Installer for the build tools:
\buildtools\Distribution\Installer.msi


2) Put the scripts from \buildtools\Distribution\Scripts at a location 
searched by your command path

PublishTarget.ps1

3) Configure the environment variable TOOLPATH to point to a directory where you want
the consolidated executables to be copied and a subdirectory Library

$TOOLPATH = C:\users\hallam\Tools

C:\users\hallam\Tools
C:\users\hallam\Tools\Library





