# General pack and publishing tool
#
# The tool is designed to be called from Visual Studio using the Post Build event command:
#
#      powershell publishtarget "$(TargetPath)"
#
# Most projects have a .exe or .dll as the target type but this does not work for
# the VISIX and Nuget packaging tools where the Visual Studio build type is .dll 
# but the actual target type is .vsix
#
# To fix this, use the /vsix qualifier
#
#      powershell publishtarget "$(TargetPath)" /vsix
#
# Note that to run, you need to set permissions in powershell 
#
#  set-executionpolicy unrestricted -scope localmachine -force
#
# To make things hard, there are two powershell instances on the system and you have to
# hit the right one, 32 or 64 bit. And the one in SysWOW64 is the 32 bit and the one in
# system32 is the 64 bit. And on top of that you have to get the right one and the right
# one changes depending on which Windows you are running.

if ($args.Length -eq 0) {exit }

$framework = "net40"
$NETcommand = @("ilmerge")
$NETparams = @("/v4")

$toolpath = $env:toolpath + "\"
$toollibrarypath = $env:toolpath + "\Library\"

$buildtype = (Get-Item $pwd).Name
$repository = (Get-Item $pwd).Parent.Parent.Parent.Parent.FullName
if (!(Test-Path ( $repository + "\Distribution\"))) {
    $repository = (Get-Item $pwd).Parent.Parent.Parent.FullName
    }

$distribution =  $repository + "\Distribution\"
$release = $distribution + $buildtype

Write-Host "Build Type " $buildtype

$releaselib = $release + "\lib\" + $framework + "\"
$releasebin = $release + "\bin\"
$releasevsix = $release + "\vsix\"


if(!(Test-Path -Path $releaselib )){
    New-Item -ItemType directory -Path $releaselib
    }
if(!(Test-Path -Path $releasebin )){
    New-Item -ItemType directory -Path $releasebin
    }
if(!(Test-Path -Path $releasevsix )){
    New-Item -ItemType directory -Path $releasevsix
    }


$target = $args[0];
$extension = [System.IO.Path]::GetExtension($target)
$targetdirectory = [System.IO.Path]::GetDirectoryName($target)
$targetfile = [System.IO.Path]::GetFileNameWithoutExtension($target)
$targetname = [System.IO.Path]::GetFileName($target)

$targetfilepath = $targetdirectory + "\" + $targetfile

$count = 0;
$libargs = @()
# assume anything that starts with / is a flag
foreach ($arg in $args) {
    #Write-Host "Arg " $count "=" $arg 
    if ($arg -eq "/vsix") {
        $extension = ".vsix"
        }
    elseif ($arg -eq "/zip") {
        $extension = ".zip"
        }
    elseif ($Count -ge 1) {
        $libargs += $arg
        # Write-Host "Arg " +$arg
        }
    $Count ++;
    }

Write-Host "Package and publish " $target


if ($extension -eq ".dll") {

    # Make a copy for local use
    copy $target $toollibrarypath

    # add to the nuget package
    copy $target $releaselib

    }


if ($extension -eq ".vsix") {
    

    $targetfile2 = $targetfilepath +".vsix"
    #Write-Host $targetfile2


    if ($buildtype -eq "Release") {

        copy $targetfile2 $releasevsix

        [xml]$manifest = Get-Content "..\..\source.extension.vsixmanifest"
        $version = $manifest.PackageManifest.MetaData.Identity.Version

        Write-Host "Create tarball for version " $version



        # load in the zip file tools
        Add-Type -assembly "system.io.compression.filesystem"

        $source = $release
        $destination = $distribution + $targetfile + "_" + $version + ".zip"

        Write-Host "Archive " $source "->" $destination
        if(Test-path $destination) {Remove-item $destination}

        [io.compression.zipfile]::CreateFromDirectory($source, $destination) 
        }
    else {
        Write-Host "Not release version, don't create .zip"
        }
    }


if ($extension -eq ".zip") {
    
    if ($buildtype -eq "Release") {

        [xml]$manifest = Get-Content "..\..\Version.xml"
        $version = $manifest.id.Version

        Write-Host "Create tarball for version " $version

        # load in the zip file tools
        Add-Type -assembly "system.io.compression.filesystem"

        $source = $release
        $destination = $distribution + $targetfile + "_" + $version + ".zip"

        Write-Host "Archive " $source "->" $destination
        if(Test-path $destination) {Remove-item $destination}

        [io.compression.zipfile]::CreateFromDirectory($source, $destination) 
        }
    else {
        Write-Host "Not release version, don't create .zip"
        }
    }

if ($extension -eq ".exe") {
    
    $meregetarget =  $toolpath + $targetname
    #Write-Host $nugettarget


    $netcommand = @("ilmerge")

    $netparams = @("/v4")
    $netparams += ("$target")
    $netparams += ("/out:$meregetarget")

    foreach ($arg in $libargs) {
        $netparams += $arg
        }
  
    $NETparams += ("/lib:C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6")
    $netparams += "/closed"
    $netparams += "/internalize"

    #Write-Host "Using /closed"
    Write-Host  $netcommand $netparams

    & $netcommand $netparams 

    # Make a copy to nuget 
    copy $meregetarget $releasebin 


    }
