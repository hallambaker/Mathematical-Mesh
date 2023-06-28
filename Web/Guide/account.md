<title>account
# Using the account Command Set

The 'account' command set groups commands relating to account creation, maintenance and 
connection to the service.

## Contacting a Mesh Service.

The 'hello' command is used to test connection to a Mesh service. This allows connectivity
to the service to be tested before attempting other operations.

Connectivity may be tested by specifying an account or just a DNS service name:


~~~~
<div="terminal">
<cmd>Alice> meshman account hello alice@example.com
<rsp>MeshService 3.0
   Service UDF = MD3E-FN6W-3G45-YQ43-QXYR-CU4X-RKG5
</div>
~~~~


## Creating a Mesh Account

A Mesh account is created using the 'create' command. 

The user specifies the initial account address to be used (alice@example.com). Use of this address
is of course dependent on authorization by the Mesh Service Provider (example.com)
and is likely to require authentication and possibly payment. 

[Future Feature: Create token] Presentation of payment proof

The account create command should support the presentation
of some form of one time use token to allow binding of a Web interaction providing payment
details to the request to bind the account to a service.



~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
</div>
~~~~

The command returns the value of Alice's Mesh Account fingerprint . 
This value is used as a unique identifier that is cryptographically bound to the signature key used
to authenticate the account profile.

When creating an account, creation of an escrow recovery keyset as described later, is highly recommended.

## Account description 

A device may be connected to multiple accounts at the same time. The 'list' command
returns a list of the accounts to which the device is connected and the 'get'
command returns information about a particular account.

[Future Feature: ListGet] List/get not currently implemented. 



~~~~
<div="terminal">
<cmd>Alice> meshman account list
<cmd>Alice> meshman account get
</div>
~~~~


## Synchronizing an account with a service

The 'account status' command returns the status of the account on the device without attempting
synchronization. 


~~~~
<div="terminal">
<cmd>Alice2> meshman account status
<rsp>   [Inbound] 3  
   [Outbound] 1  YL4T-YX43-2MOU-SVL5-73OI-66J2-PRYG-UXYO-OY6A-76ZI-VZ
ZU-JOJB-PDBK-OGKR-MAOY-2FJP-R2C4-7PZL-EIYK-OSGR-S6MD-UAIE-NZUY-LFCC-K
NMC-4DA
   [Local] 2  
   [Access] 3  2DWW-D6SI-3HLV-DK6Y-FC3O-OZ5L-37VP-UE5U-O7R3-TRLR-6QYM
-B4WF-Q262-ETPQ-K5HH-647G-G7XL-4DMC-2Z3D-YD3L-ZYV3-VONT-PCMW-DGRE-AXV
G-6II
   [Credential] 3  GW5M-Y7YK-6OKQ-RY6I-65YJ-VBKT-S62U-XMN6-U3TN-NQ4P-
A6HV-CHDV-5CD4-TNKK-XV3M-667V-5OAJ-5S3C-VRGY-SKBB-V3MT-MSN7-UMR2-7LZW
-S7D7-MOI
   [Device] 3  63R5-66LZ-GKSZ-ZQGH-USLU-LNK2-VGVI-QQSD-SZ4P-OU2L-3TRO
-XZ47-3BBV-CQPZ-INSK-EUPA-G5MD-DATD-Y7X2-2LK2-OLWQ-ZLED-FCGN-UNW2-4NC
B-QVI
   [Contact] 3  G62G-CHTE-Z5ZK-F6JW-6ND4-LQEG-XAKQ-LWNZ-IKKM-T6RE-XWL
6-36PT-53U5-3AOT-TA4Q-77TX-ZUFY-5GFQ-PNCM-XCCC-QUYU-MHRY-J7OZ-AAYW-55
QJ-6RQ
   [Application] 1  PGCJ-3PBG-OYRV-RYRY-UVL4-WBWW-52SR-H5XP-5E47-TQY6
-6QCE-CBZI-UEJ5-C4EO-OAMI-O3ND-OJJK-LC35-I63J-3THE-PERP-33TN-2XD6-4DM
H-2J6M-SLQ
   [Publication] 1  VEYP-O75S-HANF-UFIB-5SWH-YBAD-7XVH-DCSE-NOHD-Y6HT
-WSO5-GWUJ-5A6B-5DXV-JJSK-QV6A-QXFO-I6ZG-Z6YT-J72P-OHX3-TN4P-35RC-QWC
N-YVRJ-J2I
   [Bookmark] 1  CHMI-26B4-4GHD-CYAV-EO3G-IGET-42WA-GCBP-CS4X-FKLI-2B
D7-JB5I-5JUA-PXDV-DLFR-PFGB-XTKU-BCZY-F3CI-TQUQ-TV5D-K3T7-YRIK-P5SD-7
OFE-UJI
   [Task] 1  MEGV-UURI-YT4J-OWT5-2O26-VU3K-OBLZ-NDEG-XLR7-URFN-LDVZ-H
SMP-PD5A-5YLA-57O3-WYY5-4IPU-T4F4-TH6F-LNRV-UB6T-2T4R-NAOS-TK2U-QPAD-
SII
</div>
~~~~


The sync command is used to synchronize the account to the service. 

[Future Feature: AutoSync] The tool should sync before each operation requiring it. Currently, the tool requires
synchronization to be requested manually before each command. This should be performed 
automatically with an option to suppress.


~~~~
<div="terminal">
<cmd>Alice2> meshman account sync
</div>
~~~~

Synchronization will fail if a device has been removed from the account or not yet connected.




## Escrow and Recovery

The Mesh uses strong cryptography to protect the confidentiality and integrity of data. If
the private keys used to secure a Mesh account are lost, all data stored under the account 
is lost and cannot be recovered.

Creation of at least one key escrow set is highly recommended.



To create a set of recovery shares, the escrow command is used specifying the number of 
shares to create and the number of shares required for recovery:


~~~~
<div="terminal">
<cmd>Alice> meshman account escrow
<rsp>Share: SAQK-7F3L-IRHQ-IFYI-T63W-V6NA-TDZO-GCIT-RMEE-SC5P-2MB5-CF5P-FG
PR-IYCC-JJMQ
Share: SAQZ-OLOU-FUHQ-V624-U2KC-43V2-RHX2-WOLY-4VLM-4YDL-LKPE-56WU-DO
WU-NHHB-7SDQ
Share: SARH-5RB5-CXHR-DX5Q-VVYP-DY6U-PLWH-G2O6-H6SV-HNJG-4I4M-ZXPZ-BW
5X-RWMB-V22Q
</div>
~~~~

The recovery command is used to recover access to the account from another device if the
original administration device is lost or compromized.


~~~~
<div="terminal">
<cmd>Alice2> meshman account recover /verify
<rsp>ERROR - No account specified
</div>
~~~~


After verifying that the account can be recovered on another device, the primary secret 
may be purged from the administration device using the 'purge' command. This command is
of course irrevocable.


~~~~
<div="terminal">
<cmd>Alice> meshman account purge MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
<rsp>ERROR - An unknown error occurred
</div>
~~~~


## Account import/export

[Future Feature: Import/Export] ? These features are not currently implemented.

The export command causes the entire account profile to be written to an archive.
This may be used to create a backup copy of the account for archiving purposes
or to facilitate provisioning the account to a new machine.



~~~~
<div="terminal">
<cmd>Alice> meshman account export
<rsp>ERROR
</div>
~~~~

The import command causes the account profile to be read back from the archive.


~~~~
<div="terminal">
<cmd>Alice> meshman account import
<rsp>ERROR
</div>
~~~~

## Device connection commands

The 'pin' command is used to create a PIN code to provide an out-of-band pre-authentication 
code for use in device connection. This command is only available to an administration device.

The authorizations to be granted to the device may be specified during PIN creation. This
allows the device connection process to be completed without additional user interaction. But
the connection can still only complete when an administration device creates the necessary 
credentials.


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=AAKI-IIAD-GQ3H-JUY3-SXZN-PENW-PQ
 (Expires=2023-06-29T17:00:45Z)
</div>
~~~~

The 'connect' command is used to connect a device to the account by means of a 
connection URI. This is usually used to connect devices by means of a QR code 
printed on the device itself.


~~~~
<div="terminal">
<cmd>Alice> meshman account connect ^
    mcu://maker@example.com/ECHI-CYLR-Y22Q-6OME-OAWV-WIQD-YM /web
</div>
~~~~

The connecting device will only receive notice of the connection request if it
has some form of network connectivity allowing it to discover that the connection
request is pending.


