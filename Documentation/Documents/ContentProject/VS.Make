
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
    Microsoft.Bcl.AsyncInterfaces.dll\
    Microsoft.Extensions.Configuration.dll\
    Microsoft.Extensions.Configuration.Abstractions.dll\
    Microsoft.Extensions.Configuration.Binder.dll\
    Microsoft.Extensions.Configuration.CommandLine.dll\
    Microsoft.Extensions.Configuration.EnvironmentVariables.dll\
    Microsoft.Extensions.Configuration.FileExtensions.dll\
    Microsoft.Extensions.Configuration.Json.dll\
    Microsoft.Extensions.DependencyInjection.dll\
    Microsoft.Extensions.DependencyInjection.Abstractions.dll\
    Microsoft.Extensions.FileProviders.Abstractions.dll\
    Microsoft.Extensions.FileProviders.Physical.dll\
    Microsoft.Extensions.FileSystemGlobbing.dll\
    Microsoft.Extensions.Hosting.Abstractions.dll\
    Microsoft.Extensions.Logging.dll\
    Microsoft.Extensions.Logging.Abstractions.dll\
    Microsoft.Extensions.Logging.Configuration.dll\
    Microsoft.Extensions.Logging.Console.dll\
    Microsoft.Extensions.Logging.Debug.dll\
    Microsoft.Extensions.Logging.EventLog.dll\
    Microsoft.Extensions.Logging.EventSource.dll\
    Microsoft.Extensions.Options.dll\
    Microsoft.Extensions.Options.ConfigurationExtensions.dll\
    Microsoft.Extensions.Primitives.dll\
    System.Buffers.dll\
    System.Diagnostics.DiagnosticSource.dll\
    System.Memory.dll\
    System.Numerics.Vectors.dll\
    System.Runtime.CompilerServices.Unsafe.dll\
    System.Runtime.InteropServices.RuntimeInformation.dll\
    System.Security.Cryptography.Algorithms.dll\
    System.Security.Cryptography.Primitives.dll\
    System.Text.Encodings.Web.dll\
    System.Text.Json.dll\
    System.Threading.Tasks.Extensions.dll\
    System.ValueTuple.dll

ToolTargets = \
	Applications.aml\
	Applications\Account.aml\
	Applications\Credential.aml\
	Applications\Confirm.aml\
	Applications\Catalog.aml\
	Applications\Mail.aml\
	Applications\Recrypt.aml\
	Applications\SSH.aml\
	Platforms.aml\
	Meshifying.aml\
	Platforms\Linux.aml\
	Platforms\OSX.aml\
	Platforms\Windows.aml\
	Profiles.aml\
	Services.aml\
	ToDo.aml\
	Welcome.aml
Applications.aml : Applications.md 
	rfctool Applications.md  Applications.aml

Applications\Account.aml : Applications\Account.md 
	rfctool Applications\Account.md  Applications\Account.aml

Applications\Credential.aml : Applications\Credential.md 
	rfctool Applications\Credential.md  Applications\Credential.aml

Applications\Confirm.aml : Applications\Confirm.md 
	rfctool Applications\Confirm.md  Applications\Confirm.aml

Applications\Catalog.aml : Applications\Catalog.md 
	rfctool Applications\Catalog.md  Applications\Catalog.aml

Applications\Mail.aml : Applications\Mail.md 
	rfctool Applications\Mail.md  Applications\Mail.aml

Applications\Recrypt.aml : Applications\Recrypt.md 
	rfctool Applications\Recrypt.md  Applications\Recrypt.aml

Applications\SSH.aml : Applications\SSH.md 
	rfctool Applications\SSH.md  Applications\SSH.aml

Platforms.aml : Platforms.md 
	rfctool Platforms.md  Platforms.aml

Meshifying.aml : Meshifying.md 
	rfctool Meshifying.md  Meshifying.aml

Platforms\Linux.aml : Platforms\Linux.md 
	rfctool Platforms\Linux.md  Platforms\Linux.aml

Platforms\OSX.aml : Platforms\OSX.md 
	rfctool Platforms\OSX.md  Platforms\OSX.aml

Platforms\Windows.aml : Platforms\Windows.md 
	rfctool Platforms\Windows.md  Platforms\Windows.aml

Profiles.aml : Profiles.md 
	rfctool Profiles.md  Profiles.aml

Services.aml : Services.md 
	rfctool Services.md  Services.aml

ToDo.aml : ToDo.md 
	rfctool ToDo.md  ToDo.aml

Welcome.aml : Welcome.md 
	rfctool Welcome.md  Welcome.aml



prebuildRecurse : 


postbuildRecurse :

# Non shared project, nothing to do
prebuild : prebuildRecurse $(ToolTargets)
	version version.version AssemblyVersion.cs
	

postbuild : postbuildRecurse


postbuildwindows : 
	powershell publishtarget ContentProject.dll

