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
   Service UDF = MBQI-PMGC-6W73-XR4A-XZY7-Z3KB-RYQ5
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
UDF=MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
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
   [Access] 3  FH4J-VHPC-5IIK-SDZE-HUZ2-WUSB-VSXW-HZIX-LGPL-VH2X-YFK3
-OSEP-BSRY-JABH-DHTT-KMZD-YARH-YGQA-QH4H-4S3J-UW5Q-KZE3-PFGK-X4TC-OU6
J-EWI
   [Credential] 3  SUJA-BB2Q-XRFF-UUQP-X6S4-YPMX-B5PW-A2TW-27NF-LS7Q-
PA6D-FJJT-MUZ3-RRPH-SL4C-MBUF-MNDA-XBE2-NQXV-IWP6-D3WJ-K7UC-Y6LM-SEF5
-E5CS-26A
   [Device] 3  NUSX-TY3X-GJVV-J6ZU-JUXC-ZWS7-GNAV-SNEC-IJQ4-XIJC-KRYA
-VD23-HL5R-BRY4-TNCA-BDTW-JNJU-ZTKS-6YVP-D3IN-V3VC-BMFL-QD72-JN2M-43Y
S-7HQ
   [Contact] 3  2KK3-3HKP-IXIX-XRFY-J7PL-PMEX-ULS6-RM6L-NOXV-4GTC-3XT
S-6VOW-3NDS-VHYM-JKGV-GQD7-K7KS-XJ3M-U3TZ-4U4F-ZBNM-63UR-MZRW-RWVC-WU
JY-LTY
   [Application] 1  7YHV-6BXZ-VIAW-OSR6-O4T7-LDB4-DX7H-KEB2-OZWO-7EZE
-3TPM-SRXT-BW7C-TTUG-OGSI-YDK4-QB24-2KKD-S3V4-GOCK-BGMC-VVAW-5EP2-PLC
L-V5HB-ADI
   [Publication] 1  GDAI-5ANF-XZH2-6G54-6MM2-26MP-UCIL-MVON-T77R-KTAV
-YF56-7VZE-FS3M-FAAI-B5KN-VJ7O-ZUP3-DZJD-6ALD-HGT6-CT6A-RPVU-7D7B-NNQ
B-63E5-AZY
   [Bookmark] 1  BKAO-PNCD-SAAB-UCFX-DUAS-XYDH-DWIU-BKMU-F62F-WTXW-W6
3J-BZEO-RZQD-FDQ5-JHYU-RE5A-ZX35-XTSO-ZGN2-RP5L-NJJE-7L32-ISPS-R3DS-4
3UQ-MHQ
   [Task] 1  NW2U-NDVN-XTUA-MDAJ-PXN4-7PGQ-RFGZ-F42I-EGPB-XZKP-P7XC-T
TVK-E5GJ-LSCM-2D4I-CELW-UA26-5X7B-BLPG-VKHZ-OEGL-BU3K-OEEA-HNUN-LO2P-
LGQ
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
<rsp>Share: SAQM-DUCY-M75I-OMAL-UXXV-UJII-OQFD-IIAU-WAYW-TPML-2F3Y-QMMI-DI
XP-J43Z-UJTA
Share: SAQ3-XH5N-6ZR2-J36D-ZQIN-XOIM-5Q6X-X6FD-LDOX-QXHI-SFSV-UEAZ-7V
UJ-S52B-U46Q
Share: SARL-K3YD-QTGM-FL33-6IZF-2TIR-MRYM-HUJS-AGEY-N7CF-KFJS-X3VL-4C
RD-36YJ-VQKA
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
<cmd>Alice> meshman account purge MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
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
<rsp>PIN=ADPP-WZ47-R74B-4IJV-G7QF-KLLQ-N4
 (Expires=2024-10-05T01:04:39Z)
</div>
~~~~

The 'connect' command is used to connect a device to the account by means of a 
connection URI. This is usually used to connect devices by means of a QR code 
printed on the device itself.


~~~~
<div="terminal">
<cmd>Alice> meshman account connect ^
    mcd://maker@example.com/EA5X-HFHU-RL5B-SRQQ-AWST-OZNY-UE /web
</div>
~~~~

The connecting device will only receive notice of the connection request if it
has some form of network connectivity allowing it to discover that the connection
request is pending.


