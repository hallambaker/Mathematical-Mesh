<#

NB: Due to the fuckwits on the Powershell team being brainless, running this requires the following
command to be run in powershell:

set-executionpolicy unrestricted -scope localmachine -force

And not just any powershell, there is a 32 bit version and a 64 bit version and they are different

Requiring every script be signed is a great idea. The first step to enabling that is to make it easy
to sign scripts and add yourself to the permissions list.
C:\Windows\SysWOW64\WindowsPowerShell\v1.0


You also need to install the ilmerge tool from Microsoft Research
http://research.microsoft.com/en-us/people/mbarnett/ilmerge.aspx


Build tool for Microsoft and Mono versions of .NET code.

The Windows version uses the ilmerge tool from Microsoft research to build a 
standalone executable. I am told this is possible for Mono but have not got
the necessary tool yet.

Tool is invoked using powershell as follows:

powershell PackAll.ps1 <distribution> <targetpath> <main> <dll>*

<distribution>   Distribution set name, e.g. MyTarball
<targetpath>     $(TargetPath), e.g. C:\users\fred\code\project\bin\debug\project.exe
<source>         Source code of main calling executable
<dll>*           List of dlls to add to the target

Example

powershell PackAll OmniDiscovery $(TargetPath) $(ProjectDir)\Main.cs Goedel.Registry.dll DomainerLibrary.dll


Old:

powershell Merger $(TargetFileName) "$(TargetPath)" Goedel.Registry.dll Goedel.Schema3.dll
powershell PackMono gschema3  $(SolutionDir)\Commands.cs Goedel.Registry.dll Goedel.Schema3.dll

New:

powershell PackAll Goedel "$(TargetName)" "$(TargetPath)" $(SolutionDir)Commands.cs Goedel.Registry.dll Goedel.Schema3.dll

#>

<# Commands to run to generate the .net versions of the code #>

$NETcommand = @("ilmerge")
$NETparams = @("/v4")




Write-Host "Num Args:" $args.Length;

if ($args.Length -lt 3) {
    Write-Host "Not enough arguments";
    exit 1
    }

<#  Pull in the main arguments #>

$project  = $args[0]
$targetpath = $args[1]
$main  = $args[2]

<#  Compute the target path:  #>

$targetexe = split-path "$targetpath" -leaf
$target = [System.IO.Path]::GetFileNameWithoutExtension("$targetexe")

<# Add the remaining arguments to the array libargs #>

$libargs = @()
foreach ($arg in $args) {
  Write-Host "Arg: $arg";
  if ($Count -gt 2) {
    $libargs += $arg
    }
  $Count ++;
  }

<# Configure various paths #>

$path = (get-location)
$binpath = $env:GOEDELTARBALL + "\$project\MonoTools\bin"
$librarypath = $env:GOEDELTARBALL + "\$project\MonoTools\lib\" + $target 

$netbinpath = $env:GOEDELTARBALL + "\$project\NetTools"
$netlibrarypath = $env:GOEDELTARBALL + "\$project\NetTools\Library"

$toolpath = $env:toolpath + "\"
$toollibrarypath = $env:toolpath + "\Library\"

write-host "ToolPath: $toolpath"
write-host "LibraryPath: $librarypath"


write-host "Working: $path"
write-host "BinPath: $binpath"
write-host "LibraryPath: $librarypath"
write-host "Target: $out"

write-host "Delete old directory if it exists"

Remove-Item "$librarypath" -recurse
New-Item "$librarypath" -type directory -force
New-Item "$binpath" -type directory -force
New-Item "$netbinpath" -type directory -force
New-Item "$netlibrarypath" -type directory -force

$shcommand = "#!/bin/bash`npushd `$(dirname `"`${0}`") > /dev/null`ncd ../`nbasedir=`$(pwd -L)`npopd > /dev/null`ntarget=`"`${basedir}/lib/$target/$target.exe`""
$shcommand = "$shcommand`nmono --runtime=v4.0 `"`${target}`" `"`$@`""

write-host "$shcommand"
New-Item "$binpath\$target" -type file -force
Add-Content "$binpath\$target" $shcommand


$batcommand = "setlocal
cd %~dp0
mono --runtime=v4.0 ..\lib\mgschema3\mgschema3.exe %*"

write-host "$batcommand"
New-Item "$binpath\$target.bat" -type file -force
Add-Content "$binpath\$target.bat" "$batcommand"


foreach ($lib in $libargs) {
    write-Host "move $lib"
    Copy-Item "$lib" "$librarypath"
    Copy-Item "$lib" "$netlibrarypath"
    }

write-host "Target $target from $main"

$command = "mcs"
$out = "-out:" + $librarypath + "\" + $target + ".exe"
$libs = "-r:"

$count = 0;
foreach ($arg in $libargs) {
  Write-Host "Arg: $arg";
  if ($Count -gt 0) {
    $libs += ","
    }
  $libs += $arg
  $Count ++;
  }

$params = @("$out" , "$main ", "$libs")


$netcommand = @("ilmerge")
$netparams = @("/v4")
$NETparams += ("/lib:C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5")
$netparams += ("/out:$toolpath$targetexe")
$netparams += ("$targetpath")

Write-Host  $command $params

foreach ($arg in  $params) {
  Write-Host "Param: $arg";
  }


<# & $command $params  #>

$count = 0;
foreach ($arg in $args) {
  Write-Host "Arg: $arg";
  if ($Count -gt 2) {
    $netparams += ($toollibrarypath + $arg)
    }
  $Count ++;
  }
  

$netparams += "/closed"

Write-Host "Using /closed"
Write-Host  $netcommand $netparams

& $netcommand $netparams 
Copy-Item  "$toolpath$targetexe"   "$netbinpath\$targetexe"

exit 0