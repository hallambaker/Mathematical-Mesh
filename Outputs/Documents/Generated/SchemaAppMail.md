

##Mail Application Profile Objects

Profiles that describe mail user agent configuration

###Structure: MailProfile

<dl>
<dt>Inherits:  ApplicationProfile
</dl>

Public profile describes mail receipt policy. Private describes
Sending policy

<dl>
<dt>EncryptionPGP: PublicKey (Optional)
<dd>The current OpenPGP encryption key
<dt>EncryptionSMIME: PublicKey (Optional)
<dd>The current S/MIME encryption key
</dl>
###Structure: MailDevicePublic

Contains public device description

<dl>
<dt>Inherits:  ApplicationDevicePublic
</dl>

[No fields]

###Structure: MailProfilePrivate

<dl>
<dt>Inherits:  ApplicationProfilePrivate
</dl>

Describes a mail account configuration

Private profile contains connection settings for the inbound and
outbound mail server(s) and cryptographic private keys. Public
profile may contain security policy information for the sender.

<dl>
<dt>EmailAddress: String (Optional)
<dd>The RFC822 Email address. [e.g. "alice@example.com"]
<dt>ReplyToAddress: String (Optional)
<dd>The RFC822 Reply toEmail address. [e.g. "alice@example.com"]
<dd>When set, allows a sender to tell the receiver that replies to
this account should be directed to this address.
<dt>DisplayName: String (Optional)
<dd>The Display Name. [e.g. "Alice Example"]
<dt>AccountName: String (Optional)
<dd>The Account Name for display to the app user [e.g. "Work Account"]
<dt>Inbound: Connection [0..Many]
<dd>The Inbound Mail Connection(s). This is typically IMAP4 or POP3
<dd>If multiple connections are specified, the order in the sequence
indicates the preference order.
<dt>Outbound: Connection [0..Many]
<dd>The Outbound Mail Connection(s). This is typically SMTP/SUBMIT
<dd>If multiple connections are specified, the order in the sequence
indicates the preference order.
<dt>Sign: PublicKey [0..Many]
<dd>The public keypair(s) for signing and decrypting email.
<dd>If multiple public keys are specified, the order indicates preference.
<dt>Encrypt: PublicKey [0..Many]
<dd>The public keypairs for encrypting and decrypting email.
<dd>If multiple public keys are specified, the order indicates preference.	
</dl>
###Structure: MailDevicePrivate

Private data specific to the device

<dl>
<dt>Inherits:  ApplicationDevicePrivate
</dl>

[No fields]

