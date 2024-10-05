

# device

~~~~
<div="helptext">
<over>
device    Device management commands.
    accept   Accept a pending connection
    auth   Authorize device to use application
    complete   Complete a pending request
    delete   Remove device from device catalog
    install   Connect by means of a connection URI from an administration device.
    join   Connect by means of a connection URI from an administration device.
    list   List devices in the device catalog
    pending   Get list of pending connection requests
    preconfig   Generate new device profile and publish as an EARL
    reject   Reject a pending connection
    request   Connect to an existing profile registered at a portal
<over>
</div>
~~~~

# device accept

~~~~
<div="helptext">
<over>
accept   Accept a pending connection
       Fingerprint of connection to accept
       Device identifier
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
<over>
</div>
~~~~

The `device accept` command accepts the specified connection request.

The command must specify the connection identifier of the request 
being accepted. The connection identifier may be abbreviated provided that
this uniquely identifies the connection being accepted and that at least 
four characters are given.

The `/id` option may be used to specify a friendly name for the device.

The authorizations to be granted to the device may be specified using
the same syntax as for the `device auth` command with the default authorization
being that all authorizations are denied.


~~~~
<div="terminal">
<cmd>Alice> meshman device accept WSUK-ELAN-TR7B-AYXK-MO6C-WPWZ-CLJN /message /web
<rsp></div>
~~~~



# device auth

~~~~
<div="helptext">
<over>
auth   Authorize device to use application
       Device identifier
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
<over>
</div>
~~~~

The `device auth` command changes the set of authorizations given to the
specified device, adding or removing authorizations according to the 
flags specified on the command line.

The parameter specifies the device being configured by means of either
the UDF of the device profile or the device identifier.

The `/id` option may be used to specify a friendly name for the device.

Specifying the `/all` option causes the device to be granted all the 
available device authorizations except for those explicitly denied 
by means of a negative authorization grant (e.g. `/nobookmark`).

Specifying the `/noall` option causes the device to be granted no 
available device authorizations except for those explicitly granted 
by means of a positive authorization grant (e.g. `/bookmark`).

If neither the `/all` option or the `/noall` option is specified, the 
device authorizations remain unchanged except where explicitly 
granted or denied.

The following authorizations may be granted or denied:

* `bookmark`: Authorize response to confirmation requests
* `calendar`: Authorize access to calendar catalog
* `contact`: Authorize access to contacts catalog
* `confirm`: Authorize response to confirmation requests
* `mail`: Authorize access to configure SMTP mail services.
* `network`: Authorize access to the network catalog
* `password`: Authorize access to password catalog
* `ssh`: Authorize use of SSH


~~~~
<div="terminal">
<cmd>Alice> meshman device auth Alice5 /all
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~



# device complete

~~~~
<div="helptext">
<over>
complete   Complete a pending request
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

The `device complete` command attempts to connect by means of a preconfigured
device profile by polling the manufacturer service.


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MBQF-KCLE-D7QI-5DMJ-M4CE-CS3H-Z53R
   Account = alice@example.com
   Account UDF = MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
</div>
~~~~



# device delete

~~~~
<div="helptext">
<over>
delete   Remove device from device catalog
       Device identifier
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

The `device delete` command removes the specified device from the catalog.

The parameter specifies the device being configured by means of either
the UDF of the device profile or the device identifier.


~~~~
<div="terminal">
<cmd>Alice> meshman device delete
<rsp>ERROR - One or more errors occurred. (Value cannot be null. (Parameter 'key'))
</div>
~~~~



# device install

~~~~
<div="helptext">
<over>
install   Connect by means of a connection URI from an administration device.
       The device profile
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


~~~~
<div="terminal">
<cmd>Alice4> meshman device install EC2K-TADU-3ZHN-BPBC-TZY6-EAKJ-SM.medk
<rsp></div>
~~~~



# device join

~~~~
<div="helptext">
<over>
join   Connect by means of a connection URI from an administration device.
       The device location URI
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

The `device join` command attempts to connect a device to a personal profile
by means of a URI supplied by an administration device.


~~~~
<div="terminal">
<cmd>Alice5> meshman device join mcd://alice@example.com/ABMC-2GCP-MLEY-NUKJ-T4SE-GOEY-DI
<rsp>   Device UDF = MBQD-GLW5-UWZF-33EF-ADZN-G7FM-YPMY
   Witness value = LDUW-ZIG2-ABJE-KRZD-SEPD-A624-LBNH
</div>
~~~~



# device list

~~~~
<div="helptext">
<over>
list   List devices in the device catalog
       Recryption group name in user@example.com format
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

The `device list` command lists the device profiles in the device catalog.


~~~~
<div="terminal">
<cmd>Alice> meshman device list
<rsp>ContextDevice Local: -
  Base UDF MBQF-YQKD-WHOG-DW7W-M3TY-L3ZH-NYQY
  Mesh UDF 
Encrypted: MD2Q-S3EX-AUSX-7NIM-M6ER-K5DY-O5RU
  Profile User
    Signed by: MCYG-N23F-5DZK-HEFN-CNPG-MO4B-IHGT
      KeyOfflineSignature: MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ 
      AccountAddress : alice@example.com 
      KeyEncryption:       MB54-OEEK-JZSG-TRLU-HPIR-SABF-T35O 
  Profile Device
    Signed by: MDH6-WLKO-NLJG-IB2E-ADKW-Y3MP-U6MO
      ProfileUDF:          MBQF-YQKD-WHOG-DW7W-M3TY-L3ZH-NYQY 
      KeySignature:        MBXL-LS6K-I3A2-5SVY-CAC7-SXZ7-US57 
      KeyEncryption:       MCBB-M7O3-CAME-DTAL-GNUB-IADA-BHUX 
      KeyAuthentication:   MBAO-C3HO-FRF3-4RT2-JNDS-RX73-FPLU 
  Connection Device
    Signed by: MAOW-5PUN-MGDW-NTP4-42BU-XE63-JKHS
      KeyAuthentication:   MDEI-XJXK-WDPK-LJA4-RXKZ-AHZI-ASGL 

ContextDevice Local: -
  Base UDF MBQC-IDY4-CZUY-G67R-2TLC-2C5Z-DQRB
  Mesh UDF 
Encrypted: MBJP-LVFC-3QCA-MYXF-JNDH-XRYD-AHOL
  Profile User
    Signed by: MCYG-N23F-5DZK-HEFN-CNPG-MO4B-IHGT
      KeyOfflineSignature: MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ 
      AccountAddress : alice@example.com 
      KeyEncryption:       MB54-OEEK-JZSG-TRLU-HPIR-SABF-T35O 
  Profile Device
    Signed by: MDOG-NDYF-DFJ4-D47A-NYXR-JXR2-FD7F
      ProfileUDF:          MBQC-IDY4-CZUY-G67R-2TLC-2C5Z-DQRB 
      KeySignature:        MAO4-ST3F-DYFM-SBPU-SJXR-SQK4-4SD4 
      KeyEncryption:       MDXH-OU3E-BSXS-RV5M-RRW5-TL22-F5LV 
      KeyAuthentication:   MDLF-R6QH-UDWS-2HDN-EX4Q-6KBA-F55U 
  Connection Device
    Signed by: MAOW-5PUN-MGDW-NTP4-42BU-XE63-JKHS
      KeyAuthentication:   MBHZ-TYG5-5ZX2-DR7Y-TVOI-5WO6-K3VP 

</div>
~~~~



# device pending

~~~~
<div="helptext">
<over>
pending   Get list of pending connection requests
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

The `device pending` command lists the pending device connection requests in
the inbound message spool.


~~~~
<div="terminal">
<cmd>Alice> meshman device pending
<rsp>MessageID: WSUK-ELAN-TR7B-AYXK-MO6C-WPWZ-CLJN
        Connection Request::
        MessageID: WSUK-ELAN-TR7B-AYXK-MO6C-WPWZ-CLJN
        To:  From: 
        Device:  MBQC-IDY4-CZUY-G67R-2TLC-2C5Z-DQRB
        Witness: WSUK-ELAN-TR7B-AYXK-MO6C-WPWZ-CLJN
</div>
~~~~



# device preconfig

~~~~
<div="helptext">
<over>
preconfig   Generate new device profile and publish as an EARL
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /length   Length of PIN to generate in characters
<over>
</div>
~~~~


~~~~
<div="terminal">
<cmd>Maker> meshman device preconfig
<rsp>Device UDF: MBQF-KCLE-D7QI-5DMJ-M4CE-CS3H-Z53R
File: EC2K-TADU-3ZHN-BPBC-TZY6-EAKJ-SM.medk
</div>
~~~~




# device reject

~~~~
<div="helptext">
<over>
reject   Reject a pending connection
       Fingerprint of connection to reject
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

The `device reject` command rejects the specified connection request.

The command must specify the connection identifier of the request 
being accepted. The connection identifier may be abbreviated provided that
this uniquely identifies the connection being accepted and that at least 
four characters are given.


~~~~
Missing example 4
~~~~

# device request

~~~~
<div="helptext">
<over>
request   Connect to an existing profile registered at a portal
       The Mesh Service Account
    /pin   One time use authenticator
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /new   Force creation of new device profile
    /dudf   Device profile fingerprint
    /did   Device identifier
    /dd   Device description
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
<over>
</div>
~~~~

The `device request \<account\>` command requests connection of a device to a mesh profile.

The \<account\> parameter specifies the account for which the connection request is
made.

If the account holder has generated an authentication code, this is specified by means of 
the `/pin` option.




~~~~
<div="terminal">
<cmd>Alice2> meshman device request alice@example.com
<rsp>   Device UDF = MBQC-IDY4-CZUY-G67R-2TLC-2C5Z-DQRB
   Witness value = WSUK-ELAN-TR7B-AYXK-MO6C-WPWZ-CLJN
</div>
~~~~




