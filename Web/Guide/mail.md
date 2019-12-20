<title>mail
# Using the mail Command Set

The `mail` command set contains commands used to manage Internet mail 
application profiles and to create and manage credentials for the 
OpenPGP and S/MIME security enhancements for Internet mail.

Multiple mail profiles may be connected to a single Mesh profile to
allow access to multiple accounts.

## Creating a mail profile

A mail application profile is added to a Mesh profile using the 
`mail add` command:


~~~~
<div="terminal">
<cmd>Alice> mail add alice@example.com
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

The client attempts to obtain the network configuration for the inbound and
outbound mail services using [SRV auto 
configuration](https://tools.ietf.org/html/draft-daboo-srv-email-02).

Alternatively, the configuration may be given explicitly using the form 
\<domain\>:\<port\>:


~~~~
<div="terminal">
<cmd>Alice> mail add alice@example.net /inbound=imap4:imap.example.net:993 /outbound=smtp:submit.example.net:587
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

The mail profile only contains the network configuration information. Access 
credentials for the inbound and outbound mail services must be configured in the
email application(s) from which they are used or in the Mesh credential manager.

Account profiles may be updated to change the network configuration using the
`mail add` command:


~~~~
<div="terminal">
<cmd>Alice> mail update alice@example.net
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Specifying no values causes the SRV auto configuration configuration data to be 
used replacing the values previously set.

## Creating an OpenPGP Key Set

An OpenPGP public key pair for encryption and authentication may be added to the
profile when it is created or as a later update using the `/openpgp` option:


~~~~
<div="terminal">
<cmd>Alice> mail update  alice@example.com /openpgp
<rsp>ERROR - The option  is not known.
</div>
~~~~

The private key may be extracted from the profile in a variety of interchange
formats to allow installation in a key service:


~~~~
<div="terminal">
<cmd>Alice> mail openpgp private alice@example.com pgp.private
<rsp></div>
~~~~

The public key may be exported likewise:


~~~~
<div="terminal">
<cmd>Alice> mail openpgp public alice@example.com pgp.public
<rsp></div>
~~~~

## Creating an S/MIME Key Set

An S/MIME public key pair for encryption and authentication may be added to the
profile when it is created or as a later update using the `/smime` option:


~~~~
<div="terminal">
<cmd>Alice> mail alice@example.com /smime
<rsp>ERROR - The command  is not known.
</div>
~~~~

By default, a self signed certificate is created.

The `mail smime validate`  causes a certificate request to be sent to the
specified Certificate Authority service via ACME:


~~~~
<div="terminal">
<cmd>Alice> mail alice@example.com /ca=ca.example.net
<rsp>ERROR - The command  is not known.
</div>
~~~~

Responding to the validation challenge requires an access credential for the 
inbound email service to be specified.

The private key may be extracted from the profile in a variety of interchange
formats to allow installation in a key service:


~~~~
<div="terminal">
<cmd>Alice> mail smime private alice@example.com smime.private
<rsp></div>
~~~~

The public key may be exported likewise:


~~~~
<div="terminal">
<cmd>Alice> mail smime public alice@example.com smime.public
<rsp></div>
~~~~

