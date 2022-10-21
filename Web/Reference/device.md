

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
<cmd>Alice> meshman device accept 7QI7-PLXA-DZB2-XCQK-NGHH-DRXM-FIRV /message /web
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
<rsp>   Device UDF = MALQ-6D3Y-ERRF-TIFW-36LR-6GJK-4OZI
   Account = alice@example.com
   Account UDF = MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
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
<cmd>Alice4> meshman device install ED6B-KIW3-TSCC-P4LM-4D3I-IAPD-LE.medk
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
<cmd>Alice5> meshman device join mcu://alice@example.com/ABQ3-UAY6-S63P-ORJF-3CFL-GLNF-SY
<rsp>   Device UDF = MAVB-4V4O-JT7P-3BBT-VFK2-DRK4-BYOU
   Witness value = Y6SY-FOMH-6IJG-JHXQ-KB6E-7HDB-RYMK
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
  Base UDF MDNC-XN2Z-LSPT-S4BS-CS73-BMYP-XPA7
  Mesh UDF 
Encrypted: MCCF-J5M6-B6PO-2GKN-M2ES-E2CQ-DRCG
  Profile User
    Signed by: MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
      KeyOfflineSignature: MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA 
      AccountAddress : alice@example.com 
      KeyEncryption:       MC7V-XVMJ-73OL-YWGL-5MIK-ROXQ-GL3Y 
  Profile Device
    Signed by: MDNC-XN2Z-LSPT-S4BS-CS73-BMYP-XPA7
      ProfileSignature: MDNC-XN2Z-LSPT-S4BS-CS73-BMYP-XPA7 
      KeySignature:        MCFV-WLBT-SWYG-Q6CM-XKUQ-VAMS-L2HC 
      KeyEncryption:       MD2W-TY6E-UJZ4-HFE5-OZEF-W2OL-RHC7 
      KeyAuthentication:   MD6Q-A7XT-VEHN-NA23-6W4C-RCI3-IIIX 
  Connection Device
    Signed by: MBFM-XW2H-CBLT-AMNQ-ZWVZ-USGI-KOGI
      KeyAuthentication:   MBPX-J5VL-TRSF-ETQ7-WHOK-UODK-3CAM 

ContextDevice Local: -
  Base UDF MBYN-Q2AT-73EJ-2RO5-FZG3-CMIE-3YFA
  Mesh UDF 
Encrypted: MA6D-RU2J-LL73-LAW6-7JO6-IFCU-WRNI
  Profile User
    Signed by: MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
      KeyOfflineSignature: MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA 
      AccountAddress : alice@example.com 
      KeyEncryption:       MC7V-XVMJ-73OL-YWGL-5MIK-ROXQ-GL3Y 
  Profile Device
    Signed by: MBYN-Q2AT-73EJ-2RO5-FZG3-CMIE-3YFA
      ProfileSignature: MBYN-Q2AT-73EJ-2RO5-FZG3-CMIE-3YFA 
      KeySignature:        MAW3-J5NK-BZ7B-EBTD-UHUL-HB6L-ZNS2 
      KeyEncryption:       MA45-T6UD-ZGTI-CT4A-6ZVK-5QFN-CV4E 
      KeyAuthentication:   MCIB-UBQQ-RFSJ-HSYP-3KHU-7FFP-26ZS 
  Connection Device
    Signed by: MBFM-XW2H-CBLT-AMNQ-ZWVZ-USGI-KOGI
      KeyAuthentication:   MBYN-SC4W-IU4X-LIVF-PSC6-6ADO-ZJOF 

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
<rsp>MessageID: 7QI7-PLXA-DZB2-XCQK-NGHH-DRXM-FIRV
        Connection Request::
        MessageID: 7QI7-PLXA-DZB2-XCQK-NGHH-DRXM-FIRV
        To:  From: 
        Device:  MBYN-Q2AT-73EJ-2RO5-FZG3-CMIE-3YFA
        Witness: 7QI7-PLXA-DZB2-XCQK-NGHH-DRXM-FIRV
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
<rsp>Device UDF: MALQ-6D3Y-ERRF-TIFW-36LR-6GJK-4OZI
File: ED6B-KIW3-TSCC-P4LM-4D3I-IAPD-LE.medk
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
<rsp>   Device UDF = MBYN-Q2AT-73EJ-2RO5-FZG3-CMIE-3YFA
   Witness value = 7QI7-PLXA-DZB2-XCQK-NGHH-DRXM-FIRV
</div>
~~~~




