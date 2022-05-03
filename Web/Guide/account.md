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
   Service UDF = MD3P-ALTL-T6I4-U6ER-O4ZD-5AP5-J6SO
</div>
~~~~


## Creating a Mesh Account

A Mesh account is created using the 'create' command. 

The user specifies the initial account address to be used (alice@example.com). Use of this address
is of course dependent on authorization by the Mesh Service Provider (example.com)
and is likely to require authentication and possibly payment. 

The account create command should support the presentation
of some form of one time use token to allow binding of a Web interaction providing payment
details to the request to bind the account to a service.



~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
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
<rsp>   [MMM_Inbound] 3  
   [MMM_Outbound] 1  CRA7-FW4G-HJYL-GKDU-GXLB-67LE-KXGZ-VXJX-MGGX-H2F
A-UHUS-YBXW-EW5Q-5VME-E4TI-SZVD-AXAG-A6DE-HBTD-JEQN-4OWK-GU4N-3M2J-WJ
7Y-B4GW-Y5Q
   [MMM_Local] 2  
   [MMM_Access] 3  X67X-TO5Y-SCBO-AXDA-YOZJ-GFCJ-IFCF-QNWS-QH2F-U3CS-
XWDY-LMQA-6NFC-A6EX-25GE-7IJO-BYKU-YM3U-FCE6-JARQ-YHZG-LG3G-J4WP-3AVN
-U64S-JWY
   [MMM_Credential] 3  5PI5-GXXV-UWWM-Z4G4-SS62-CHJF-TFA4-TAY7-O4B7-3
QE6-YYVP-RBYY-OPAD-HBIQ-63PZ-VDD2-N4YD-B7KV-WOMS-RX47-DBYU-SGOZ-MRLP-
WQIM-F7TI-VYQ
   [MMM_Device] 3  KMN7-LMFM-EEZC-AD23-2C5F-AXH4-PWXK-DRWF-JBNA-3FPB-
E7GX-UJR3-4OOU-PAXJ-F42Z-7NVU-U4FQ-GBI3-2YPR-LL2Q-TSKT-X2PJ-K2QQ-XY2Z
-JJY3-BNI
   [MMM_Contact] 2  COLT-F2D7-OZCW-CFYB-Q3GJ-TOLZ-AOPX-JLFA-IRGQ-O53A
-LEAM-XMBW-6K56-2H6C-FE3Y-PMCQ-B4FC-XEXN-7WKY-X3OU-7EQL-ZJUS-E5FX-S33
5-UZ2G-U3Y
   [MMM_Application] 1  I6DK-OFK2-K52W-KIJ3-6RTC-BPBS-32C6-THCL-VITZ-
QPFE-KNA2-GNGA-IWK4-MNXM-CNPZ-EMK7-NV2G-LALZ-BOX4-36C7-KDUU-HCJW-XT4Z
-7C22-2PZB-UMI
   [MMM_Publication] 1  GSLA-4QWH-5XUB-VUC5-A442-SRMC-WB4A-BBKP-XOP4-
WLSA-4ZTV-NTTF-NELI-2TAG-GQ4G-JW62-XARV-T2CK-QH7U-L74B-E35V-HVUE-46KD
-MZ66-MNTA-2VA
   [MMM_Bookmark] 1  LH75-RPP3-RKKC-BKMY-7I7B-LCQP-LTGE-IX67-TARW-YZP
K-6UG7-2NEW-6AKF-KID4-WK7M-CAPT-UTUI-NDCC-KYLW-HUK3-Z3R3-BTV3-D6M7-EG
XA-KRT7-H7A
   [MMM_Task] 1  XASR-QDD5-UNRI-PFH7-ND3C-AJD2-AH4G-ZRSW-QUUF-FZGF-WX
QT-SOYH-U5DX-P4E2-AER7-ZWQL-G77N-UD2A-ZO4T-ECRH-RFMF-ALI5-HMZ3-KUF4-K
ANV-K7I
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
<rsp>Share: SAQC-YE5R-BE3C-37IF-AG43-SGNT-3NLP-VURL-YWEH-FTBE-J755-IN6F-ZP
XR-N6O5-3AVQ
Share: SAQZ-AJS7-NJMO-B6S3-4J6U-AHPD-TL5C-HEPS-523G-VBSK-FUDG-X3IR-5S
2X-UGBI-YWIA
Share: SARP-IOIN-ZN5Z-H55S-YNAM-OIQT-LKOU-YUN2-C7SG-EQDQ-BIIQ-HIS6-BV
55-2NTT-WL2Q
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
<cmd>Alice> meshman account purge MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
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
<rsp>PIN=ADKW-K2ZB-PPZM-ECG4-P3NQ-UN4K-XI
 (Expires=2022-05-04T16:47:51Z)
</div>
~~~~

The 'connect' command is used to connect a device to the account by means of a 
connection URI. This is usually used to connect devices by means of a QR code 
printed on the device itself.


~~~~
<div="terminal">
<cmd>Alice> meshman account connect ^
    mcu://maker@example.com/EDRL-4MZP-3OUD-OZBS-SPZN-7OSO-OM /web
</div>
~~~~

The connecting device will only receive notice of the connection request if it
has some form of network connectivity allowing it to discover that the connection
request is pending.


