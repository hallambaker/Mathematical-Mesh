# meshman Reference Manual

<dl>
<dt><a href="account.md">account</a>
<dd>Account creation and management commands.
<dt><a href="bookmark.md">bookmark</a>
<dd>Manage bookmark catalogs connected to an account
<dt><a href="calendar.md">calendar</a>
<dd>Manage calendar catalogs connected to an account
<dt><a href="contact.md">contact</a>
<dd>Manage contact catalogs connected to an account
<dt><a href="container.md">container</a>
<dd>DARE container commands
<dt><a href="dare.md">dare</a>
<dd>DARE Message encryption and decryption commands
<dt><a href="device.md">device</a>
<dd>Device management commands.
<dt><a href="group.md">group</a>
<dd>Group management commands
<dt><a href="hash.md">hash</a>
<dd>Content Digest and Message Authentication Code operations on files
<dt><a href="key.md">key</a>
<dd>Key operations.
<dt><a href="mail.md">mail</a>
<dd>Manage mail profiles connected to a personal profile
<dt><a href="mesh.md">mesh</a>
<dd>Commands for creating and managing a personal Mesh
<dt><a href="message.md">message</a>
<dd>Contact and confirmation message options
<dt><a href="network.md">network</a>
<dd>Manage network profile settings
<dt><a href="password.md">password</a>
<dd>Manage password catalogs connected to an account
<dt><a href="ssh.md">ssh</a>
<dd>Manage SSH profiles connected to a personal profile
</dl>

# Command format

The command processor supports use of either UNIX or Windows syntax regardless
of the platform on which it is run. This allows scripts written on Unix to be
used on Windows and vice versa while allowing users to use the syntax they are 
accustomed to use on a particular machine.


# Common options

All commands (other than `help` and `about`) support the use of the 'verbose', 
'report' and 'json' options.

*'/json' 

The '/json' flag takes precedence over the /verbose and /report options which
are ignored if '/json' is specified.

Specifying the /json flag causes the command output to be presented in JSON
format.

*'/verbose' 

The '/verbose' flag takes precedence over the /report option which is ignored if
'/verbose' is specified.

*'/report' '/noreport'* 

The /report flag is set by default. If /noreport is specified, the command is
executed without any output being made to the console.

