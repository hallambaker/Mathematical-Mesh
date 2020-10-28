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
Missing example 1
~~~~

The client attempts to obtain the network configuration for the inbound and
outbound mail services using [SRV auto 
configuration](https://tools.ietf.org/html/draft-daboo-srv-email-02).

Alternatively, the configuration may be given explicitly using the form 
\<domain\>:\<port\>:


~~~~
Missing example 2
~~~~

The mail profile only contains the network configuration information. Access 
credentials for the inbound and outbound mail services must be configured in the
email application(s) from which they are used or in the Mesh credential manager.

Account profiles may be updated to change the network configuration using the
`mail add` command:


~~~~
Missing example 3
~~~~

Specifying no values causes the SRV auto configuration configuration data to be 
used replacing the values previously set.

## Creating an OpenPGP Key Set

An OpenPGP public key pair for encryption and authentication may be added to the
profile when it is created or as a later update using the `/openpgp` option:


~~~~
Missing example 4
~~~~

The private key may be extracted from the profile in a variety of interchange
formats to allow installation in a key service:


~~~~
Missing example 5
~~~~

The public key may be exported likewise:


~~~~
Missing example 6
~~~~

## Creating an S/MIME Key Set

An S/MIME public key pair for encryption and authentication may be added to the
profile when it is created or as a later update using the `/smime` option:


~~~~
Missing example 7
~~~~

By default, a self signed certificate is created.

The `mail smime validate`  causes a certificate request to be sent to the
specified Certificate Authority service via ACME:


~~~~
Missing example 8
~~~~

Responding to the validation challenge requires an access credential for the 
inbound email service to be specified.

The private key may be extracted from the profile in a variety of interchange
formats to allow installation in a key service:


~~~~
Missing example 9
~~~~

The public key may be exported likewise:


~~~~
Missing example 10
~~~~

