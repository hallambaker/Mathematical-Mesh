

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
<cmd>Alice> meshman account connect mcd://maker@example.com/EBH3-DT6M-G2WA-EF7E-DA42-DN55-7E /web
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
UDF=MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
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
<cmd>Alice> meshman account delete MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
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
<rsp>Share: SAQN-VODM-D7P3-UFD7-BKS3-GNS5-KRBR-OUDN-TLPT-ISTY-ABVQ-BSJW-H5R5-UDAM-67CA
Share: SAQ6-236V-ZWQV-VMO5-DSEV-NEGC-BKFX-CHRW-UONP-UB5G-ZMM6-JKIS-XVE5-5SD5-HM7A
Share: SARA-AJZ7-PNRP-WTZ3-FZWP-T2ZG-YDJ4-V277-VRLL-7RGV-SXEM-RCHP-HMX6-HBHN-P2FQ
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
   Service UDF = MBQD-ETXU-HZRW-A26O-WDTR-K7GI-X6JD
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
<rsp>PIN=ADE7-U5DR-2YNJ-XKVX-4RUE-SVL5-5I
 (Expires=2024-10-15T13:10:56Z)
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
<cmd>Alice> meshman account purge MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
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
<cmd>Alice2> meshman account recover SAQN-VODM-D7P3-UFD7-BKS3-GNS5-KRBR-OUDN-TLPT-ISTY-ABVQ-BSJW-H5R5-UDAM-67CA SARA-AJZ7-PNRP-WTZ3-FZWP-T2ZG-YDJ4-V277-VRLL-7RGV-SXEM-RCHP-HMX6-HBHN-P2FQ /verify
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
   [Access] 3  GYZY-FCUD-JN6L-XPDN-5W6O-SWD7-26VP-E46V-7K3I-UGP7-KSZU-YA2J-AOG6-5MIS-X7P3-Y7QK-J6YE-YDIX-DUKZ-DAPC-2DCR-OEST-SY76-XQPK-VEYY-BGA
   [Credential] 3  GINL-R6EY-IKU2-BE5R-VMCP-7RVX-XPEJ-HCMC-D3P5-IA2U-XFZJ-LPWC-JOZM-M44P-GWFX-5HXL-NZR5-FCET-YKEC-H7HF-YUP7-PCRR-NNAF-AIKG-IEHM-UQA
   [Device] 3  BQ75-ELJ6-YRYC-2FVT-NODU-APAK-56HI-3N6U-EYSE-DNKT-Q5QE-XHEQ-MZRK-IY22-DNGU-2SPS-D66C-ZF25-PMHW-3A53-3NFC-ROA4-RAWP-ND6A-LVRB-TYA
   [Contact] 3  I7JD-7MQC-GCCK-LNNW-UVGH-AQHX-4CGB-P67Y-S6CR-XBOO-NL7T-ERQ4-UZY6-GYRS-FAYZ-AXBT-SUCR-Z45S-ADV5-NEOR-NJ3A-2ZFA-2AFC-77QW-J3EV-EVQ
   [Application] 1  N7SM-VHVO-IUFD-DNWP-VXVP-YKQG-T3TP-PVIC-PMUT-YTZ7-B4VZ-OFTI-RDPD-2WAV-7N5Z-WG4V-P6QP-G2ZG-2HLB-R4DE-DLJC-2FX5-EEFJ-37QN-5N6Y-U6Q
   [Publication] 1  N7DS-JLBH-3AIU-UWHX-4UE4-5UKB-YBSP-KZMW-UQVR-527V-DQHV-3XDP-TPGW-FNN4-3FSN-5NE4-XSHL-K23B-BART-2TID-4DYS-73LU-URZE-E3N3-FQY3-3SQ
   [Bookmark] 1  FHRO-MAOE-ACCW-PZHU-7JGK-SAED-FSFR-FGBT-AHZV-AYTZ-7MY6-3E6C-3MHY-NU3N-4AW2-7H37-FK2F-MNHJ-IELG-TBSY-2ESN-YMDN-MSRG-LPX2-MO77-46I
   [Task] 1  J33X-TDKM-HQVO-5F6G-FXOX-64UO-LYMS-XSD5-OBOD-4A7J-DPW4-PRZN-6HNT-A6YW-XDHK-SUGM-EY6M-4ZI2-PGNS-5R5T-HWDT-BRJX-TPRP-ZA5X-KNQI-RHA
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







