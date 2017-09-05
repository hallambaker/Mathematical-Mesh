

#Mail Application Profile Objects

###Structure: MailProfile

* Inherits: ApplicationProfile

Public profile describes mail receipt policy. Private describes
Sending policy


<dl><dt>EncryptionPGP: 
<dd>PublicKey (Optional)


The current OpenPGP encryption key

<dl><dt>EncryptionSMIME: 
<dd>PublicKey (Optional)


The current S/MIME encryption key

###Structure: MailProfilePrivate

* Inherits: ApplicationProfilePrivate

Describes a mail account configuration

Private profile contains connection settings for the inbound and
outbound mail server(s) and cryptographic private keys. Public
profile may contain security policy information for the sender.


<dl><dt>EmailAddress: 
<dd>String (Optional)


The RFC822 Email address. [e.g. "alice@example.com"]

<dl><dt>ReplyToAddress: 
<dd>String (Optional)


The RFC822 Reply toEmail address. [e.g. "alice@example.com"]


When set, allows a sender to tell the receiver that replies to
this account should be directed to this address.

<dl><dt>DisplayName: 
<dd>String (Optional)


The Display Name. [e.g. "Alice Example"]

<dl><dt>AccountName: 
<dd>String (Optional)


The Account Name for display to the app user [e.g. "Work Account"]

<dl><dt>Inbound: 
<dd>Connection [0..Many]


The Inbound Mail Connection(s). This is typically IMAP4 or POP3


If multiple connections are specified, the order in the sequence
indicates the preference order.

<dl><dt>Outbound: 
<dd>Connection [0..Many]


The Outbound Mail Connection(s). This is typically SMTP/SUBMIT


If multiple connections are specified, the order in the sequence
indicates the preference order.

<dl><dt>Sign: 
<dd>PublicKey [0..Many]


The public keypair(s) for signing and decrypting email.


If multiple public keys are specified, the order indicates preference.

<dl><dt>Encrypt: 
<dd>PublicKey [0..Many]


The public keypairs for encrypting and decrypting email.


If multiple public keys are specified, the order indicates preference.	

