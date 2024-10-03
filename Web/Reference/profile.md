

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
<cmd>Alice> meshman account connect mcd://maker@example.com/EDZW-33F5-EL2X-SWIB-LKM3-J5PP-FM /web
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
UDF=MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
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
<cmd>Alice> meshman account delete MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
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
<rsp>Share: SAQK-C23Z-ARHV-56TW-5S2T-KGIJ-YXWT-EIQY-DJAL-PQYW-4IWJ-C3RG-YZSL-R7KL-S6PA
Share: SAQX-VVPP-363K-WN2L-O7SQ-ZSOR-SU4S-IRFS-F6RF-QG2A-W4GQ-JRPE-HO3K-WUIA-CVXA
Share: SARF-IQDG-XMO7-O5BA-AMKO-I6UZ-MSCR-MZ2M-IUB7-Q43K-RPWX-QHNB-WEEJ-3JFU-SM7A
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
   Service UDF = MBQP-EWUT-UYX2-Q3GS-HB4O-3VBQ-IKP2
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
<rsp>PIN=AASP-5A76-VKQO-CZZF-SQ6R-DQUU-2A
 (Expires=2024-10-04T14:57:13Z)
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
<cmd>Alice> meshman account purge MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
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
<cmd>Alice2> meshman account recover SAQK-C23Z-ARHV-56TW-5S2T-KGIJ-YXWT-EIQY-DJAL-PQYW-4IWJ-C3RG-YZSL-R7KL-S6PA SARF-IQDG-XMO7-O5BA-AMKO-I6UZ-MSCR-MZ2M-IUB7-Q43K-RPWX-QHNB-WEEJ-3JFU-SM7A /verify
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
   [Access] 3  FTV2-6EUH-K3F4-DSSC-WH3Z-ZGYL-AOHK-ESMZ-7QOW-BQBH-SUNH-DZ5J-C744-BTCH-D6E5-2E6P-37ST-OEDD-2FVB-IQ5C-THNQ-A3CG-W3EB-Y4JF-ISBN-ICQ
   [Credential] 3  FRTC-3OGB-FRNK-E7NU-NGQK-5VKD-WKWA-X566-MBUX-HMA5-BRLN-IPPY-BJ4H-B5E7-PMOJ-KLT4-F3RX-LAPW-LN7U-DZPN-KRUX-VMGI-CAEF-2KRC-QNFA-NDA
   [Device] 3  PWOO-Z54D-YSCE-7EXY-QZ7D-TVEM-KZTV-OFMJ-LXBK-F73B-POLL-KICP-MKYH-23U5-TJEP-CTNZ-Z6PT-IYKC-5K7F-5KTD-XNSE-QK7F-WJIG-ANUQ-UVNO-25A
   [Contact] 3  DUVI-ORBY-WHO3-2F25-M3V2-ORQZ-P2PM-3VY3-DGG5-B2FC-4U45-X3JM-ETKY-CY6C-32DO-J36K-5PQK-DYE7-KQ6O-SCU7-MODY-YWY2-SCTN-E3F7-KZVO-T2I
   [Application] 1  2TWO-W44H-3QRC-3GXQ-G4PV-HVOF-BYHS-FPKD-L6TB-DJ6B-XL5X-YTZX-3SJM-SJIX-YLK2-TCUA-EJJK-56OX-4P2Q-T3FU-OUX6-LHZA-EU5S-X4Z4-TM7C-7FA
   [Publication] 1  NK27-4H5T-YW5P-LMLR-IIDH-GRXC-K6TG-C6GE-A25J-GFOZ-ISOC-LJR6-3U7Z-ITCD-UBDY-BPOM-NJSJ-SC7B-KOJQ-YYPX-RSIX-UR4T-3XYH-4CRX-KHHF-LMY
   [Bookmark] 1  QRFZ-PNO6-IZHI-VJQS-OMHK-R2UN-NXOX-KKRP-P4AD-PNDO-X5AA-ZTG3-RFFA-4V5Z-7WYV-4TO4-6R3O-IDVD-RC5R-QLII-57I6-VTQR-JCIN-VBDS-YQEN-E2I
   [Task] 1  IBXI-Q4M2-NU3B-UFIE-L6BI-FZT4-NBL3-SLEF-CD62-ZJXL-63Q6-QGLV-YLH3-YY3K-C4B6-MFZN-MH2A-DB5T-CL7D-3E3U-IA4N-HP2G-752X-AZUS-LJWW-NUI
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







