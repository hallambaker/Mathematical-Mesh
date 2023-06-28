

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
<cmd>Alice> meshman account connect mcu://maker@example.com/ECHI-CYLR-Y22Q-6OME-OAWV-WIQD-YM /web
<rsp></div>
~~~~



# account create

~~~~
<div="helptext">
<over>
create   Create new account profile
       New account
    /localname   Account friendly name
    /payment   Optional payment token
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
UDF=MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
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
<cmd>Alice> meshman account delete MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
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
<rsp>Share: SAQK-7F3L-IRHQ-IFYI-T63W-V6NA-TDZO-GCIT-RMEE-SC5P-2MB5-CF5P-FGPR-IYCC-JJMQ
Share: SAQZ-OLOU-FUHQ-V624-U2KC-43V2-RHX2-WOLY-4VLM-4YDL-LKPE-56WU-DOWU-NHHB-7SDQ
Share: SARH-5RB5-CXHR-DX5Q-VVYP-DY6U-PLWH-G2O6-H6SV-HNJG-4I4M-ZXPZ-BW5X-RWMB-V22Q
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
   Service UDF = MD3E-FN6W-3G45-YQ43-QXYR-CU4X-RKG5
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
<rsp>PIN=AAKI-IIAD-GQ3H-JUY3-SXZN-PENW-PQ
 (Expires=2023-06-29T17:00:45Z)
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
<cmd>Alice> meshman account purge MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
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
<cmd>Alice2> meshman account recover SAQK-7F3L-IRHQ-IFYI-T63W-V6NA-TDZO-GCIT-RMEE-SC5P-2MB5-CF5P-FGPR-IYCC-JJMQ SARH-5RB5-CXHR-DX5Q-VVYP-DY6U-PLWH-G2O6-H6SV-HNJG-4I4M-ZXPZ-BW5X-RWMB-V22Q /verify
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
<rsp>   [Inbound] 3  
   [Outbound] 1  YL4T-YX43-2MOU-SVL5-73OI-66J2-PRYG-UXYO-OY6A-76ZI-VZZU-JOJB-PDBK-OGKR-MAOY-2FJP-R2C4-7PZL-EIYK-OSGR-S6MD-UAIE-NZUY-LFCC-KNMC-4DA
   [Local] 2  
   [Access] 3  2DWW-D6SI-3HLV-DK6Y-FC3O-OZ5L-37VP-UE5U-O7R3-TRLR-6QYM-B4WF-Q262-ETPQ-K5HH-647G-G7XL-4DMC-2Z3D-YD3L-ZYV3-VONT-PCMW-DGRE-AXVG-6II
   [Credential] 3  GW5M-Y7YK-6OKQ-RY6I-65YJ-VBKT-S62U-XMN6-U3TN-NQ4P-A6HV-CHDV-5CD4-TNKK-XV3M-667V-5OAJ-5S3C-VRGY-SKBB-V3MT-MSN7-UMR2-7LZW-S7D7-MOI
   [Device] 3  63R5-66LZ-GKSZ-ZQGH-USLU-LNK2-VGVI-QQSD-SZ4P-OU2L-3TRO-XZ47-3BBV-CQPZ-INSK-EUPA-G5MD-DATD-Y7X2-2LK2-OLWQ-ZLED-FCGN-UNW2-4NCB-QVI
   [Contact] 3  G62G-CHTE-Z5ZK-F6JW-6ND4-LQEG-XAKQ-LWNZ-IKKM-T6RE-XWL6-36PT-53U5-3AOT-TA4Q-77TX-ZUFY-5GFQ-PNCM-XCCC-QUYU-MHRY-J7OZ-AAYW-55QJ-6RQ
   [Application] 1  PGCJ-3PBG-OYRV-RYRY-UVL4-WBWW-52SR-H5XP-5E47-TQY6-6QCE-CBZI-UEJ5-C4EO-OAMI-O3ND-OJJK-LC35-I63J-3THE-PERP-33TN-2XD6-4DMH-2J6M-SLQ
   [Publication] 1  VEYP-O75S-HANF-UFIB-5SWH-YBAD-7XVH-DCSE-NOHD-Y6HT-WSO5-GWUJ-5A6B-5DXV-JJSK-QV6A-QXFO-I6ZG-Z6YT-J72P-OHX3-TN4P-35RC-QWCN-YVRJ-J2I
   [Bookmark] 1  CHMI-26B4-4GHD-CYAV-EO3G-IGET-42WA-GCBP-CS4X-FKLI-2BD7-JB5I-5JUA-PXDV-DLFR-PFGB-XTKU-BCZY-F3CI-TQUQ-TV5D-K3T7-YRIK-P5SD-7OFE-UJI
   [Task] 1  MEGV-UURI-YT4J-OWT5-2O26-VU3K-OBLZ-NDEG-XLR7-URFN-LDVZ-HSMP-PD5A-5YLA-57O3-WYY5-4IPU-T4F4-TH6F-LNRV-UB6T-2T4R-NAOS-TK2U-QPAD-SII
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







