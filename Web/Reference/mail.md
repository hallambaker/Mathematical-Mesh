

# mail

~~~~
<div="helptext">
<over>
mail    Manage mail profiles connected to a personal profile
    openpgp<Unspecified>
    smime<Unspecified>
    add   Add a mail application profile to a personal profile
    list   List mail account information
    update   Update an existing mail application profile
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
# mail update

~~~~
<div="helptext">
<over>
update   Update an existing mail application profile
       Mail account to update
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
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


