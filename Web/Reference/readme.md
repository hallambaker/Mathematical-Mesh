# meshman Reference Manual

<dl>
<dt>[`key`](key.md)</dt>
<dd>Generate secrets and nonces. Split a secret into shares and recover secret from shares</dd>
<dt>[`hash`](hash.md)</dt>
<dd>Perform Content Digest and Message Authentication Code operations on the contents of a file</dd>
<dt>[`dare`](dare.md)</dt>
<dd>Encode and decode DARE messages</dd>
<dt>[`container`](container.md)</dt>
<dd>Encode and decode DARE containers</dd>
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

