

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
<cmd>Alice> meshman device accept Z3PE-JMM5-G3XQ-CB3Q-LNX4-2YY6-Q74Y /message /web
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
<rsp>   Device UDF = MBAI-IMKY-GI2T-D472-4VP5-SKRF-ZXYW
   Account = alice@example.com
   Account UDF = MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
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
<rsp>ERROR - Value cannot be null. (Parameter 'key')
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
<cmd>Alice4> meshman device install ECHI-CYLR-Y22Q-6OME-OAWV-WIQD-YM.medk
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
<cmd>Alice5> meshman device join mcu://alice@example.com/ADHN-QSL4-LX54-57PC-4M6I-3B4Q-4E
<rsp>   Device UDF = MB4X-7ZVI-L45S-33KI-6OSQ-IINM-EJVL
   Witness value = WMTF-WPPB-R3IS-WBBK-EULC-SWVX-ZTQE
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
  Base UDF MDLS-GEJJ-XMUN-IK7Q-N2A2-G2RM-VC7F
  Mesh UDF 
Encrypted: MBVB-YEXV-GLU4-HJEM-JM3W-TVR2-4JFW
  Profile User
    Signed by: MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
      KeyOfflineSignature: MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2 
      AccountAddress : alice@example.com 
      KeyEncryption:       MBUF-P7S2-WFEF-D3ML-OKCC-XYOT-6SLD 
  Profile Device
    Signed by: MDLS-GEJJ-XMUN-IK7Q-N2A2-G2RM-VC7F
      ProfileSignature: MDLS-GEJJ-XMUN-IK7Q-N2A2-G2RM-VC7F 
      KeySignature:        MAWC-HMJX-R2XL-ZK57-4EZV-VEKK-6CEW 
      KeyEncryption:       MBL2-DF7V-CGG4-OBYD-534B-I2CK-TW5F 
      KeyAuthentication:   MDJA-Y34W-IVHF-344H-7KCI-RSHR-FQBI 
  Connection Device
    Signed by: MBL5-JSN3-V56Q-4ULY-GY7X-GM3V-KVPZ
      KeyAuthentication:   MDTR-OHHZ-ZTKT-VBZC-YX23-F2N5-YBMZ 

ContextDevice Local: -
  Base UDF MBYI-QYCM-JXEY-OJ5D-4OW2-RPIR-SHUM
  Mesh UDF 
Encrypted: MARU-OXNG-MA6F-7LZQ-R75I-2DSO-7RHN
  Profile User
    Signed by: MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
      KeyOfflineSignature: MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2 
      AccountAddress : alice@example.com 
      KeyEncryption:       MBUF-P7S2-WFEF-D3ML-OKCC-XYOT-6SLD 
  Profile Device
    Signed by: MBYI-QYCM-JXEY-OJ5D-4OW2-RPIR-SHUM
      ProfileSignature: MBYI-QYCM-JXEY-OJ5D-4OW2-RPIR-SHUM 
      KeySignature:        MCGI-AARY-CKX6-OTD6-XLON-JIZK-HGE5 
      KeyEncryption:       MCFX-IUBA-KOCW-3FUS-23Z5-NR5U-YOLN 
      KeyAuthentication:   MCRL-42BN-TYVI-BDGP-K2NJ-OGNI-QEA3 
  Connection Device
    Signed by: MBL5-JSN3-V56Q-4ULY-GY7X-GM3V-KVPZ
      KeyAuthentication:   MBGO-55A4-MBVM-L2G7-4T5B-NILX-AODX 

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
<rsp>MessageID: Z3PE-JMM5-G3XQ-CB3Q-LNX4-2YY6-Q74Y
        Connection Request::
        MessageID: Z3PE-JMM5-G3XQ-CB3Q-LNX4-2YY6-Q74Y
        To:  From: 
        Device:  MBYI-QYCM-JXEY-OJ5D-4OW2-RPIR-SHUM
        Witness: Z3PE-JMM5-G3XQ-CB3Q-LNX4-2YY6-Q74Y
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
<rsp>Device UDF: MBAI-IMKY-GI2T-D472-4VP5-SKRF-ZXYW
File: ECHI-CYLR-Y22Q-6OME-OAWV-WIQD-YM.medk
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
<rsp>   Device UDF = MBYI-QYCM-JXEY-OJ5D-4OW2-RPIR-SHUM
   Witness value = Z3PE-JMM5-G3XQ-CB3Q-LNX4-2YY6-Q74Y
</div>
~~~~




