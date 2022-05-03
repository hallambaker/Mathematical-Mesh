

# account

~~~~
<div="helptext">
<over>
account    Account creation and management commands.
    connect   Connect by means of a connection uri
    create   Create new account profile
    delete   Delete an account profile
    escrow   Create a set of key escrow shares
    export   Export the specified profile data to the specified file
    get   Describe the specified profile
    hello   Connect to the service(s) a profile is connected to and report status.
    import   Import the specified profile data to the specified file
    info   Report the public keys of the specified account
    list   List all profiles on the local machine
    pin   Get a pin value to pre-authorize a connection
    purge   Purge the Mesh recovery key from this device
    recover   Recover escrowed profile
    status   Return the status of the account catalogs and spools
    sync   Synchronize local copies of Mesh profiles with the server
<over>
</div>
~~~~

The 'account' command set groups commands relating to account creation, maintenance and 
connection to the service.

The '/local', '/verbose', '/report' and '/json' options are supported by every command
in the set.

The '/account' option may be used to specify the Mesh account on which the device is 
to be performed. If unspecified, the default account is used.

# account connect

~~~~
<div="helptext">
<over>
connect   Connect by means of a connection uri
       The device location URI
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
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

The `account connect` command is used to initiate the process of device connection by means
of an account connection URI such as a URI encoded in a QR code on the device housing.

The request must specify the connection URI as the first (and only) parameter.

The '/account' option may be used to specify the Mesh account to which the device is 
connected. If unspecified, the default account is used.

The '/local' option may be used to specify a local name for the device.

The '/auth' option may be used to specify authorizations to be granted to the device by
name. Alternatively the flags '/admin', '/root', '/message', '/web', '/threshold', etc. 
may be used to specify the most commonly used authorizations.


~~~~
<div="terminal">
<cmd>Alice> meshman account connect mcu://maker@example.com/EDRL-4MZP-3OUD-OZBS-SPZN-7OSO-OM /web
<rsp></div>
~~~~



# account create

~~~~
<div="helptext">
<over>
create   Create new account profile
       New account
    /localname   Account friendly name
    /new   Force creation of new device profile
    /dudf   Device profile fingerprint
    /did   Device identifier
    /dd   Device description
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /alg   List of algorithm specifiers
<over>
</div>
~~~~

The `account create` command is used to create accounts.

The command takes a single parameter, the make of the account to be created. This is always
specified in RFC822 style even if it is intended to bind the account to a callsign.

The '/localname' parameter may be used to specify a local (friendly) name for the account.

If the device has an existing device profile provisioned, this will be reused unless
the '/new' option is used to force creation of a new profile. The '/did' and 'dd'
options may be used to specify a name and description for the device. If not specified,
a default name will be used.


~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
</div>
~~~~




# account delete

~~~~
<div="helptext">
<over>
delete   Delete an account profile
       Fingerprint of the account to be removed from this device
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `account delete` command is used to delete an account from the service and local machine
once completed, the command cannot be undone unless the service provides a recovery capability.

The principle use for the current implementation is to test use of the escrow and recovery
functions and it is not particularly recommended for any other purpose. To avoid accidental
use, the UDF of the device profile must be specified.


~~~~
<div="terminal">
<cmd>Alice> meshman account delete MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
<rsp>Device Profile UDF=
</div>
~~~~




# account escrow

~~~~
<div="helptext">
<over>
escrow   Create a set of key escrow shares
    /alg   List of algorithm specifiers
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /quorum   <Unspecified>
    /shares   <Unspecified>
<over>
</div>
~~~~

The `account escrow` command is used to create a set of key recovery shares for the account
primary secret from which the escrow and signature keys are derrived.

The options 'shares' and 'quorum' are used to specify the number of shares to be created
(e.g. 5) and the threshold number of shares required to perform recovery (e.g. 3).


~~~~
<div="terminal">
<cmd>Alice> meshman account escrow
<rsp>Share: SAQC-YE5R-BE3C-37IF-AG43-SGNT-3NLP-VURL-YWEH-FTBE-J755-IN6F-ZPXR-N6O5-3AVQ
Share: SAQZ-AJS7-NJMO-B6S3-4J6U-AHPD-TL5C-HEPS-523G-VBSK-FUDG-X3IR-5S2X-UGBI-YWIA
Share: SARP-IOIN-ZN5Z-H55S-YNAM-OIQT-LKOU-YUN2-C7SG-EQDQ-BIIQ-HIS6-BV55-2NTT-WL2Q
</div>
~~~~




# account export

~~~~
<div="helptext">
<over>
export   Export the specified profile data to the specified file
       Name of the file to which the archive is to be written.
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

The `account export` command is used to export all data except for private keys associated with 
the account to a DARE archive.


~~~~
<div="terminal">
<cmd>Alice> meshman account import
<rsp>ERROR
</div>
~~~~



# account get

~~~~
<div="helptext">
<over>
get   Describe the specified profile
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

The `account get` command returns a description of the account. This includes the 
account UDF fingerprint, the current service binding and the date of the most recent 
synchronization operation.


~~~~
<div="terminal">
<cmd>Alice> meshman account get
<rsp></div>
~~~~




# account hello

~~~~
<div="helptext">
<over>
hello   Connect to the service(s) a profile is connected to and report status.
       Account
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
<over>
</div>
~~~~

The `account hello` command attempts to contact a Mesh service and reports the
service configuration if successful.


~~~~
<div="terminal">
<cmd>Alice> meshman account hello alice@example.com
<rsp>MeshService 3.0
   Service UDF = MD3P-ALTL-T6I4-U6ER-O4ZD-5AP5-J6SO
</div>
~~~~



# account import

~~~~
<div="helptext">
<over>
import   Import the specified profile data to the specified file
       Name of the file file which the archive is to be read.
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

The `account import` command imports Mesh account data from a DARE archive such as 
an archive created by the 'account export' command.


~~~~
<div="terminal">
<cmd>Alice> meshman account import
<rsp>ERROR
</div>
~~~~




# account list

~~~~
<div="helptext">
<over>
list   List all profiles on the local machine
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
<over>
</div>
~~~~

The `account list` command lists all the Mesh accounts the current device is connected 
to.


~~~~
<div="terminal">
<cmd>Alice> meshman account list
<rsp></div>
~~~~




# account pin

~~~~
<div="helptext">
<over>
pin   Get a pin value to pre-authorize a connection
    /length   Length of PIN to generate in characters
    /expire   Expiry time in days (1d), hours (1, 1h) or minutes (10m).
    /uri   Return a dynamic connection URI
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
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

The `account pin` command generates and registers a new PIN code that may be used
to authenticate a device connection request.

The `/length` option specifies the length of the generated PIN in (significant)
characters.

The '/expire' option specifies an expiry time for the request as an integer 
followed by the letter m, h or d for minutes, hours and days respectively.

The remaining options allow the authorization(s) of the device to be specified so
that the connection can be completed without additional user interaction.



~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=ADKW-K2ZB-PPZM-ECG4-P3NQ-UN4K-XI
 (Expires=2022-05-04T16:47:51Z)
</div>
~~~~




# account purge

~~~~
<div="helptext">
<over>
purge   Purge the Mesh recovery key from this device
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

The `account purge` command eliminates deleted objects and messages from the catalogs
and spools stored on the current device. The Purge command does not cause data to be
deleted from the service.


~~~~
<div="terminal">
<cmd>Alice> meshman account purge MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
<rsp>ERROR - An unknown error occurred
</div>
~~~~




# account recover

~~~~
<div="helptext">
<over>
recover   Recover escrowed profile
       Recovery share
       Recovery share
       Recovery share
       Recovery share
       Recovery share
       Recovery share
       Recovery share
       Recovery share
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /file   File containing the recovery key blob
    /verify   Check that the shares are valid for recovery without performing recovery.
<over>
</div>
~~~~

The `account recover` command reassembles the account primary secret from a set of
recovery shares.


~~~~
<div="terminal">
<cmd>Alice2> meshman account recover SAQC-YE5R-BE3C-37IF-AG43-SGNT-3NLP-VURL-YWEH-FTBE-J755-IN6F-ZPXR-N6O5-3AVQ SARP-IOIN-ZN5Z-H55S-YNAM-OIQT-LKOU-YUN2-C7SG-EQDQ-BIIQ-HIS6-BV55-2NTT-WL2Q /verify
<rsp>ERROR - No account specified
</div>
~~~~




# account status

~~~~
<div="helptext">
<over>
status   Return the status of the account catalogs and spools
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

The `account status` command returns the current status of the account catalogs and spools 
without attempting to synchronize with the service.


~~~~
<div="terminal">
<cmd>Alice2> meshman account status
<rsp>   [MMM_Inbound] 3  
   [MMM_Outbound] 1  CRA7-FW4G-HJYL-GKDU-GXLB-67LE-KXGZ-VXJX-MGGX-H2FA-UHUS-YBXW-EW5Q-5VME-E4TI-SZVD-AXAG-A6DE-HBTD-JEQN-4OWK-GU4N-3M2J-WJ7Y-B4GW-Y5Q
   [MMM_Local] 2  
   [MMM_Access] 3  X67X-TO5Y-SCBO-AXDA-YOZJ-GFCJ-IFCF-QNWS-QH2F-U3CS-XWDY-LMQA-6NFC-A6EX-25GE-7IJO-BYKU-YM3U-FCE6-JARQ-YHZG-LG3G-J4WP-3AVN-U64S-JWY
   [MMM_Credential] 3  5PI5-GXXV-UWWM-Z4G4-SS62-CHJF-TFA4-TAY7-O4B7-3QE6-YYVP-RBYY-OPAD-HBIQ-63PZ-VDD2-N4YD-B7KV-WOMS-RX47-DBYU-SGOZ-MRLP-WQIM-F7TI-VYQ
   [MMM_Device] 3  KMN7-LMFM-EEZC-AD23-2C5F-AXH4-PWXK-DRWF-JBNA-3FPB-E7GX-UJR3-4OOU-PAXJ-F42Z-7NVU-U4FQ-GBI3-2YPR-LL2Q-TSKT-X2PJ-K2QQ-XY2Z-JJY3-BNI
   [MMM_Contact] 2  COLT-F2D7-OZCW-CFYB-Q3GJ-TOLZ-AOPX-JLFA-IRGQ-O53A-LEAM-XMBW-6K56-2H6C-FE3Y-PMCQ-B4FC-XEXN-7WKY-X3OU-7EQL-ZJUS-E5FX-S335-UZ2G-U3Y
   [MMM_Application] 1  I6DK-OFK2-K52W-KIJ3-6RTC-BPBS-32C6-THCL-VITZ-QPFE-KNA2-GNGA-IWK4-MNXM-CNPZ-EMK7-NV2G-LALZ-BOX4-36C7-KDUU-HCJW-XT4Z-7C22-2PZB-UMI
   [MMM_Publication] 1  GSLA-4QWH-5XUB-VUC5-A442-SRMC-WB4A-BBKP-XOP4-WLSA-4ZTV-NTTF-NELI-2TAG-GQ4G-JW62-XARV-T2CK-QH7U-L74B-E35V-HVUE-46KD-MZ66-MNTA-2VA
   [MMM_Bookmark] 1  LH75-RPP3-RKKC-BKMY-7I7B-LCQP-LTGE-IX67-TARW-YZPK-6UG7-2NEW-6AKF-KID4-WK7M-CAPT-UTUI-NDCC-KYLW-HUK3-Z3R3-BTV3-D6M7-EGXA-KRT7-H7A
   [MMM_Task] 1  XASR-QDD5-UNRI-PFH7-ND3C-AJD2-AH4G-ZRSW-QUUF-FZGF-WXQT-SOYH-U5DX-P4E2-AER7-ZWQL-G77N-UD2A-ZO4T-ECRH-RFMF-ALI5-HMZ3-KUF4-KANV-K7I
</div>
~~~~





# account sync

~~~~
<div="helptext">
<over>
sync   Synchronize local copies of Mesh profiles with the server
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

The `account sync` command attempts to synchronize the account catalogs and spools with
the service and reports on the status of each.

If the '/auto' flag is set, pre-authorized device connection and contact exchange requests
in inbound messages will be performed automatically without further user interaction.


~~~~
<div="terminal">
<cmd>Alice2> meshman account sync
<rsp></div>
~~~~







