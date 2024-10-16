

# mail

~~~~
<div="helptext">
<over>
mail    Manage mail profiles connected to a personal profile
    openpgpCommands for managing PGP entries
    smimeCommands for managing S/MIME entries
    add   Add a mail application profile to a personal profile
    delete   Delete mail account information
    get   Lookup mail entry
    import   Import account information
    list   List mail account information
<over>
</div>
~~~~

# mail add

~~~~
<div="helptext">
<over>
add   Add a mail application profile to a personal profile
       Mail account to create profile from
    /auth   (De)Authorize the specified function on the device
    /root   Device as super administration device
    /admin   Device as administration device
    /message   Authorize rights for Mesh messaging
    /web   Authorize rights for Mesh messaging and Web.
    /device   Device restrictive access
    /threshold   Authorize threshold rights for Mesh messaging and Web.
    /ssh   Authorize rights for specified SSH account
    /email   Authorize rights for specified smtp email account
    /member   Authorize member rights for specified Mesh group
    /group   Authorize group administrator rights for specified Mesh group
    /null   Do not authorize any device rights at all (cannot be used with any rights grant))
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /openpgp   Create encryption and signature keys for OpenPGP
    /smime   Create encryption and signature keys for S/MIME
    /configuration   Configuration file describing network settings
    /ca   Certificate Authority to request certificate from
    /inbound   inbound service configuration
    /outbound   outbound service configuration
    /alg   List of algorithm specifiers
<over>
</div>
~~~~

The mail add command adds a mail entry to the application catalog using parameters
specified on the command line.


~~~~
<div="terminal">
<cmd>Alice> meshman mail add alice@example.net /inbound pop://alice@pop3.example.net /outbound submit://alice@submit.example.net /Web
<rsp>Account:         alice@example.net
Inbound Server:  pop://alice@pop3.example.net
Outbound Server: submit://alice@submit.example.net
S/Mime Sign:     MD43-FUHU-L3NP-BZSY-4U6U-BRMM-JNPV
S/Mime Encrypt:  MASH-GWIR-UTEP-KKA6-SPBN-SYEP-DUBR
OpenPGP Sign:    MCBD-NHTV-UKKB-B5KY-7Y24-52JI-5P5Z
OpenPGP Encrypt: MCBB-E4NJ-LXCB-QV3K-UH3M-FLS6-U2FU
</div>
~~~~



# mail get

~~~~
<div="helptext">
<over>
get   Lookup mail entry
       The mail account address
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The mail get command reports the specified mail configuration data.


~~~~
<div="terminal">
<cmd>Alice> meshman mail get alice@example.net
<rsp>[CatalogedApplicationMail]

</div>
~~~~



# mail import

~~~~
<div="helptext">
<over>
import   Import account information
       File containing the contact entry to add
    /id   Unique entry identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The mail add command adds a mail entry to the application catalog using parameters
specified in a configuration file.


~~~~
<div="terminal">
<cmd>Alice> meshman mail import mail_config.json
<rsp>[CatalogedApplicationMail]

</div>
~~~~



# mail list

~~~~
<div="helptext">
<over>
list   List mail account information
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The mail list command lists all the mail configurations in the applications catalog.


~~~~
<div="terminal">
<cmd>Alice> meshman mail list
<rsp>Account:         alice@example.net
Inbound Server:  imap://alice@imap.example.net
Outbound Server: submit://alice@submit.example.net
S/Mime Sign:     MDOE-FY7L-PCQ6-QLJV-DNPW-2RSC-3QTJ
S/Mime Encrypt:  MBP2-NIPK-ZXUZ-Z7R3-D3TI-3XBM-GUS2
OpenPGP Sign:    MDYG-ND6W-FF3U-X5RY-WB7W-JCSK-CE3E
OpenPGP Encrypt: MBOO-PWKJ-QOAF-NIDI-HZBU-JUC3-6MMN
</div>
~~~~




# mail sign

~~~~
<div="helptext">
<over>
sign   Extract the signature key for the specified account
       Mail account to update
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /format   File format
    /file   Output file
    /password   Password to encrypt private key
    /private   <Unspecified>
<over>
</div>
~~~~

The mail openpgp sign command returns the OpenPGP signature key in a variety of
formats.


~~~~
<div="terminal">
<cmd>Alice> meshman mail openpgp sign alice@example.net /file=alice1_opgp_sign.pem
<rsp></div>
~~~~



# mail encrypt

~~~~
<div="helptext">
<over>
encrypt   Extract the public key/certificate for the specified account
       Mail account identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /format   File format
    /file   Output file
    /password   Password to encrypt private key
    /private   <Unspecified>
<over>
</div>
~~~~

The mail openpgp sign command returns the OpenPGP encrypt key in a variety of
formats.


~~~~
<div="terminal">
<cmd>Alice> meshman mail openpgp sign alice@example.net /file=alice1_smime_encrypt.pem
<rsp></div>
~~~~



# mail sign

~~~~
<div="helptext">
<over>
sign   Extract the signature key for the specified account
       Mail account to update
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /format   File format
    /file   Output file
    /password   Password to encrypt private key
    /private   <Unspecified>
<over>
</div>
~~~~

The mail openpgp sign command returns the S/MIME signature key in a variety of
formats.


~~~~
<div="terminal">
<cmd>Alice> meshman mail smime sign alice@example.net  /file=alice1_smime_sign.pem
<rsp></div>
~~~~



# mail encrypt

~~~~
<div="helptext">
<over>
encrypt   Extract the public key/certificate for the specified account
       Mail account identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /format   File format
    /file   Output file
    /password   Password to encrypt private key
    /private   <Unspecified>
<over>
</div>
~~~~

The mail openpgp sign command returns the S/MIME encrypt key in a variety of
formats.


~~~~
<div="terminal">
<cmd>Alice> meshman mail smime encrypt alice@example.net  /file=alice1_smime_encrypt.pem
<rsp></div>
~~~~




