<title>mail
# Using the mail Command Set

The `mail` command set contains commands used to manage Internet mail 
application profiles and to create and manage credentials for the 
OpenPGP and S/MIME security enhancements for Internet mail.

The current commands represent a draft designed to demonstrate key management
functions that are related to Mesh functionality. Of course a full feature key manager
would also create and submit CSRs for S/MIME, upload key blobs to OpenPGP
key servers, support key rotation, etc. etc.


Multiple mail profiles may be connected to a single Mesh profile to
allow access to multiple accounts.

## Creating a mail profile

A mail application profile is added to a Mesh profile using the 
`mail add` command:


~~~~
<div="terminal">
<cmd>Alice> meshman mail add alice@example.net /inbound ^
    pop://alice@pop3.example.net /outbound ^
    submit://alice@submit.example.net /Web
<rsp>Account:         alice@example.net
Inbound Server:  pop://alice@pop3.example.net
Outbound Server: submit://alice@submit.example.net
S/Mime Sign:     MDWH-RON2-QOI3-UFH4-MIJX-LZRU-F43D
S/Mime Encrypt:  MDCH-HIM4-XMQB-Q7EY-PRMM-DLGW-CKG4
OpenPGP Sign:    MDA6-IXNL-FOQC-HX7V-NCBC-MNOG-CK23
OpenPGP Encrypt: MCBZ-75RE-UM7Q-VR2J-L732-AZZZ-BLFZ
</div>
~~~~

The client attempts to obtain the network configuration for the inbound and
outbound mail services using [SRV auto 
configuration](https://tools.ietf.org/html/draft-daboo-srv-email-02).

Alternatively, the configuration may be given explicitly using the form 
\<domain\>:\<port\>:


~~~~
<div="terminal">
<cmd>Alice> meshman mail import mail_config.json
<rsp>[CatalogedApplicationMail]

</div>
~~~~

The mail profile only contains the network configuration information. Access 
credentials for the inbound and outbound mail services must be configured in the
email application(s) from which they are used or in the Mesh credential manager.

Account profiles may be updated to change the network configuration using the
`mail add` command:


~~~~
<div="terminal">
<cmd>Alice> meshman mail add alice@example.net /inbound ^
    imap://alice@imap.example.net /outbound ^
    submit://alice@submit.example.net /Web 
<rsp>Account:         alice@example.net
Inbound Server:  imap://alice@imap.example.net
Outbound Server: submit://alice@submit.example.net
S/Mime Sign:     MCCJ-IANC-HEWS-7XZI-OR72-ZFC4-SCQL
S/Mime Encrypt:  MDO5-36TO-HN5V-6SZ5-MD5B-63BZ-737K
OpenPGP Sign:    MAII-NUGV-FX7P-IAQ2-UXZ3-CP3J-6MKN
OpenPGP Encrypt: MB74-LYO7-NBVD-EZ3E-7ADE-AR4N-2AY7
</div>
~~~~

Specifying no values causes the SRV auto configuration configuration data to be 
used replacing the values previously set.

## Creating an OpenPGP Key Set

S/MIME and OpenPGP keys are created automatically whenever a mail profile is 
created.

The private key may be extracted from the profile in a variety of interchange
formats to allow installation in an application:


~~~~
<div="terminal">
<cmd>Alice> meshman mail openpgp sign alice@example.net ^
    /file=alice1_opgp_sign.pem
</div>
~~~~

The public key may be exported likewise:


~~~~
<div="terminal">
<cmd>Alice> meshman mail openpgp sign alice@example.net ^
    /file=alice1_opgp_sign.pem
</div>
~~~~

## Creating an S/MIME Key Set



The private key may be extracted from the profile in a variety of interchange
formats to allow installation in a key service:


~~~~
<div="terminal">
<cmd>Alice> meshman mail smime sign alice@example.net  ^
    /file=alice1_smime_sign.pem
</div>
~~~~

The public key may be exported likewise:


~~~~
<div="terminal">
<cmd>Alice> meshman mail smime sign alice@example.net  ^
    /file=alice1_smime_sign.pem
</div>
~~~~

Various key formats are supported for export of public and private keys allowing
their use in a wide variety of applications.


