# The objective

Build the solution for the complete set of 9 supported platforms with a single command.

This should preferably be executable from a shell script so that a single instruction
can be used to build, package and publish on all platforms.


# The problems

1) There is no 'publish all' option in Visual Studio. Which is just wierd. It
should not be necessary to futz about with scripts at all

2) Customizing the code for different platforms requires different support 
libraries. For the purpose of debugging the publish bug, the project is using
a configuration limited to win-x64 for net5.0-windows.

3) Running publish from the command line causes the wrong build configfuration
to be used and the files to be written to a different location 


The publication file publish-win-x64.pubxml is:

~~~~
<?xml version="1.0" encoding="utf-8"?>
<!--
https://go.microsoft.com/fwlink/?LinkID=208121. 
-->
<Project ToolsVersion="4.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <Configuration>Release</Configuration>
    <Platform>x64</Platform>
    <PublishDir>..\..\Outputs\win-x64</PublishDir>
    <PublishProtocol>FileSystem</PublishProtocol>
    <TargetFramework>net5.0-windows</TargetFramework>
    <RuntimeIdentifier>win-x64</RuntimeIdentifier>
    <SelfContained>true</SelfContained>
    <PublishSingleFile>True</PublishSingleFile>
    <PublishReadyToRun>True</PublishReadyToRun>
    <PublishTrimmed>True</PublishTrimmed>
  </PropertyGroup>
</Project>
~~~~

When the Publish command is used from within Visual Studio, it correctly builds
the three applications and copies them to:

C:\Users\hallam\Work\mmm\Outputs\win-x64

When msbuild is used from the command line:

~~~~
PS C:\Users\hallam\Work\mmm> msbuild mmm.sln /p:PublishProfile=publish-win-x64
~~~~

The files are instead written to:

"C:\Users\hallam\Work\mmm\Applications\serviceadmin\bin\Debug\net5.0-windows\win-x64\serviceadmin.exe"




