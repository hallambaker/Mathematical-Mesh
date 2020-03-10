<title>To Do List: Mathematical Mesh
<abbrev>MMM To Do

<series>draft-hallambaker-mesh-todo
	<status>informational
	<stream>independent
<ipr>trust200902
<author>Phillip Hallam-Baker
    <surname>Hallam-Baker
    <initials>P. M.
    <firstname>Phillip
    <organization>Comodo Group Inc.
    <email>philliph@comodo.com


<h1>Mesh/Account


<h1>Mesh/Recrypt

<ul>
<li>fix bug in DH encrypt. Does not emit the recipient info
<li>Get the recryption entry for recipient
<li>calculate recryption info
<li>Decrypt file.
</ul>

<h1>Mesh/SSH

<ul>
<li>Pull SSH profile and create auth hosts entry
<li>Emit keys in SSH format to .ssh directory
</ul>

<h1>Mesh/Mail

<ul>
<li>Emit the private key as a P12 encrypted under a temporary key for that device.
<li>S/MIME enable Outlook
<it>S/MIME enable new Windows Mail
</ul>


<h1>Documentation (RFCTool)

<ul>
<li>Fix the bug which causes blank lines to be emitted due to multiple blank lines between segments.
<li>Get rid of the idiot disappearing table of contents, make a dropdown
<li>Embed the javascript as well
<li>Fix Author/Authors bug and the double display of the name
<li>Get internal references to work, label figures, tables, sections, enable reference to them
<li>write a documentation card
<li>Fix bug causing a crash if section heading levels are missed.
</ul>


<h1>Protogen

<ul>
<li>Enable marking classes as abstract
<li>Clean up the Transaction definitions
</ul>


<h2>Future

<ul>
<li>Register for a cert at Comodo free S/MIME
<li>OpenPGP support (possibly via script)
</ul>


<h1>Mesh/Address

This is a new application to replace Mesh/Web. This will consist of

<dl>
<dt>Contacts

<dd>The user's contact directory. Includes slots for contact using proprietary 
protocols (Signal, messenger, etc.)

<dt>Bookmarks

<dd>The user's Web bookmarks. Includes entry for strong addresses and make use of 
letterhead attributes.

<dt>Credentials

<dd>Username password combinations. 
</dl>

It should be possible to extract a password into a shell variable and then use it to
access some remote network resource.

The command for doing this in a DOS shell is awesomely awful:

~~~~
FOR /F "tokens=*" %i in ('contact pass get myremote.com') ^
    do SET PASSWORD=%i
sftp myremote.com /pass=PASSWORD ...
set PASSWORD=
~~~~

Powershell is sane:

~~~~
$toolout = (contact pass get myremote.com) | Out-string
~~~~

Bash is also sane:

~~~~
toolout = $(contact pass get myremote.com) 
~~~~


