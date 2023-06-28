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
S/Mime Sign:     MC2K-ALZ3-YH6B-XRVT-REXZ-4THZ-2SCC
S/Mime Encrypt:  MCPI-DJZ2-K2JG-VTMD-UI7O-RCZH-RVP6
OpenPGP Sign:    MA3K-B7DH-KOON-J56T-NLP2-7BOS-PYO7
OpenPGP Encrypt: MBBQ-6DVG-VD6C-ITGR-6FOI-EU7C-XSL7
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
S/Mime Sign:     MAE2-33FZ-R2AP-BN5O-YAO4-VGQD-YTIZ
S/Mime Encrypt:  MANV-7HIN-RGQG-VOJF-IYQI-ORA4-ZDVA
OpenPGP Sign:    MDGI-YJTT-N3G5-VQRV-V6HH-XNKA-5DG4
OpenPGP Encrypt: MC2E-4BAB-AVZC-B6QY-UJZR-P73B-V26M
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


