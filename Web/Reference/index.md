# meshman Reference Manual

<dl>
<dt><a href="account.html">account</a>
<dd>Account creation and management commands.
<dt><a href="bookmark.html">bookmark</a>
<dd>Manage bookmark catalogs connected to an account
<dt><a href="calendar.html">calendar</a>
<dd>Manage calendar catalogs connected to an account
<dt><a href="contact.html">contact</a>
<dd>Manage contact catalogs connected to an account
<dt><a href="dare.html">dare</a>
<dd>DARE Message encryption and decryption commands
<dt><a href="device.html">device</a>
<dd>Device management commands.
<dt><a href="group.html">group</a>
<dd>Group management commands
<dt><a href="hash.html">hash</a>
<dd>Content Digest and Message Authentication Code operations on files
<dt><a href="key.html">key</a>
<dd>Key operations.
<dt><a href="mail.html">mail</a>
<dd>Manage mail profiles connected to a personal profile
<dt><a href="message.html">message</a>
<dd>Contact and confirmation message options
<dt><a href="network.html">network</a>
<dd>Manage network profile settings
<dt><a href="password.html">password</a>
<dd>Manage password catalogs connected to an account
<dt><a href="ssh.html">ssh</a>
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


In addition commands which require use of a Mesh account offer the 
'account', 'local', 'sync' and 'auto' options as follows:

* '/account'


* '/local'

* '/sync'

* '/auto'

