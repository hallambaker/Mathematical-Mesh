

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
<cmd>Alice> meshman device accept IFC5-FUKU-3JVW-JZME-5DP2-XQEX-SV7B /message /web
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
<rsp>   Device UDF = MBQI-JNHL-6QU5-BMOC-PX4M-P2PV-NYDM
   Account = alice@example.com
   Account UDF = MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
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
<rsp></div>
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
<cmd>Alice4> meshman device install EDZW-33F5-EL2X-SWIB-LKM3-J5PP-FM.medk
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
<cmd>Alice5> meshman device join mcd://alice@example.com/ABXA-OPP3-GHXO-SHKI-ZBFX-MWN5-O4
<rsp>   Device UDF = MBQD-THF4-QEOJ-FZJ4-6HZE-SGJT-NJ7K
   Witness value = XUFB-NAUM-HTI6-7KBJ-LSTU-D6VK-7MCN
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
  Base UDF MBQO-BATX-GU7O-GMTN-CXCI-JWKT-VIMN
  Mesh UDF 
Encrypted: MDTR-774C-4Q2X-AFER-NEVZ-WTUG-W7SX
  Profile User
    Signed by: MDD2-JKDP-6SBB-KIML-47CQ-QCOJ-4W5F
      KeyOfflineSignature: MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3 
      AccountAddress : alice@example.com 
      KeyEncryption:       MDSO-NJIQ-HUNW-UWRS-WPOE-BBO3-NDWN 
  Profile Device
    Signed by: MADH-ZREB-4C6F-OO6F-LV2G-QL5P-ATSL
      ProfileUDF:          MBQO-BATX-GU7O-GMTN-CXCI-JWKT-VIMN 
      KeySignature:        MBKG-GPIY-5SAA-TVIR-RUAB-EJAE-TNXZ 
      KeyEncryption:       MCCN-625E-XVZI-OLRZ-JTCM-XQAG-4F4M 
      KeyAuthentication:   MAER-QIII-OG55-HVFY-LSIK-VJ3I-OC5C 
  Connection Device
    Signed by: MBLM-W4XU-5LMK-3REN-25WP-GWFU-EKTV
      KeyAuthentication:   MAUI-OIG7-BIAF-O7KD-FPL3-RX55-X4WZ 

ContextDevice Local: -
  Base UDF MBQP-MYOA-LTSP-B5GX-A7HP-ZFJ5-4VQ6
  Mesh UDF 
Encrypted: MATK-HNZD-J3L3-FJP2-XY3S-ETCA-V46Q
  Profile User
    Signed by: MDD2-JKDP-6SBB-KIML-47CQ-QCOJ-4W5F
      KeyOfflineSignature: MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3 
      AccountAddress : alice@example.com 
      KeyEncryption:       MDSO-NJIQ-HUNW-UWRS-WPOE-BBO3-NDWN 
  Profile Device
    Signed by: MCX4-LPSP-JJRF-FKTZ-SVG7-I7HS-KPUA
      ProfileUDF:          MBQP-MYOA-LTSP-B5GX-A7HP-ZFJ5-4VQ6 
      KeySignature:        MBYL-PWIV-L54F-7XK6-FDRE-N7BP-ZKFZ 
      KeyEncryption:       MCO6-RDDJ-ODGA-LDXX-LAED-F4U4-BMG6 
      KeyAuthentication:   MB2X-XJRH-ERZY-HDQW-RWZV-RHSP-A7IU 
  Connection Device
    Signed by: MBLM-W4XU-5LMK-3REN-25WP-GWFU-EKTV
      KeyAuthentication:   MAH3-YBVX-PYRE-XOEN-B3DR-3O5H-Z4OJ 

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
<rsp>MessageID: IFC5-FUKU-3JVW-JZME-5DP2-XQEX-SV7B
        Connection Request::
        MessageID: IFC5-FUKU-3JVW-JZME-5DP2-XQEX-SV7B
        To:  From: 
        Device:  MBQP-MYOA-LTSP-B5GX-A7HP-ZFJ5-4VQ6
        Witness: IFC5-FUKU-3JVW-JZME-5DP2-XQEX-SV7B
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
<rsp>Device UDF: MBQI-JNHL-6QU5-BMOC-PX4M-P2PV-NYDM
File: EDZW-33F5-EL2X-SWIB-LKM3-J5PP-FM.medk
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
<rsp>   Device UDF = MBQP-MYOA-LTSP-B5GX-A7HP-ZFJ5-4VQ6
   Witness value = IFC5-FUKU-3JVW-JZME-5DP2-XQEX-SV7B
</div>
~~~~




