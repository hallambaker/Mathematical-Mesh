=File Naming Conventions etc.

This is a template for building a new PROTOGEN application. The solution 
uses two sets of project files:

: Libraries
:: for ease of debugging and recognizing the fact that many of the 
libraries are in development, these are linked as projects in the 
parent directory.

: Project files
:: The projects that are specific to this protocol

==Library files




==Project files

:Goedel.Recrypt
:: Protocol definition and common facilities

:Goedel.Recrypt.Client
:: Client specific methods

:Goedel.Recrypt.Server
:: Server dispatch

:recrypt Shell
:: Command line Shell

:ServerRecrypt
:: Server


===recrypt Shell

namespace Goedel.Recrypt.Shell

:recrypt.Command
::Defines the commands for the shell tool

:Dispatch.cs
::The methods that are called when the shell command is used

:Utilities.cs
::General utilities, some should go into a general library, probably goedel.debug

===ServerRecrypt




