

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
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
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



~~~~
<div="terminal">
<cmd>Alice> meshman mail add alice@example.net /inbound pop://alice@pop3.example.net /outbound submit://alice@submit.example.net
<rsp>Account:         alice@example.net
Inbound Server:  pop://alice@pop3.example.net
Outbound Server: submit://alice@submit.example.net
S/Mime Sign:     MCAA-UPQE-S6FN-MM3P-QLR7-ZW22-U6XI
S/Mime Encrypt:  MC4F-CU7O-YNUY-IW7D-NG3F-PIW7-BVYI
OpenPGP Sign:    MBWA-PARP-XY7A-DNRW-OLYT-4ZVJ-UERT
OpenPGP Encrypt: MAV5-4VFZ-4RUE-U2NX-WAWS-3V3I-EJG2
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
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~



~~~~
<div="terminal">
<cmd>Alice> meshman mail get alice@example.net
<rsp>ERROR - TBS
</div>
~~~~



# mail import

~~~~
<div="helptext">
<over>
import   Import account information
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~



~~~~
<div="terminal">
<cmd>Alice> meshman mail import 
<rsp>ERROR - TBS
</div>
~~~~



# mail list

~~~~
<div="helptext">
<over>
list   List mail account information
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~



~~~~
<div="terminal">
<cmd>Alice> meshman mail list
<rsp>Account:         alice@example.net
Inbound Server:  pop://alice@pop3.example.net
Outbound Server: submit://alice@submit.example.net
S/Mime Sign:     MCAA-UPQE-S6FN-MM3P-QLR7-ZW22-U6XI
S/Mime Encrypt:  MC4F-CU7O-YNUY-IW7D-NG3F-PIW7-BVYI
OpenPGP Sign:    MBWA-PARP-XY7A-DNRW-OLYT-4ZVJ-UERT
OpenPGP Encrypt: MAV5-4VFZ-4RUE-U2NX-WAWS-3V3I-EJG2
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


~~~~
<div="terminal">
<cmd>Alice> meshman mail smime encrypt alice@example.net  /file=alice1_smime_encrypt.pem
<rsp></div>
~~~~




