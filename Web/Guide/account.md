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
   Service UDF = MDSK-EUHS-QXGD-LKOF-AVC7-V2RH-LV6Z
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
UDF=MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF
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
   [MMM_Access] 3  NH7Z-SCK6-HQVW-U2PQ-H47W-XO3W-M2F6-TD2E-MDJ4-3SKV-
B5CU-VG2S-VMY7-AAYE-QMJP-5EHO-U53V-BEBD-44LQ-PAG7-H25C-Y4KE-Z23D-J7WM
-BWOB-SIA
   [MMM_Credential] 3  KPQY-SFFW-D43M-HCHT-MKEP-RC4N-HMJD-DGGD-UP7A-T
4MV-T5DS-NPSP-XLDC-26P2-6YHL-QKPL-MAW4-ADPL-GUEK-27CQ-ZSDX-6EYR-OO45-
OEMY-Z37F-L6A
   [MMM_Device] 3  AHYT-DBWV-XLQT-E342-SW6S-5ODZ-XH7S-GUIR-NMKT-OOWY-
KYQH-35JX-ED5D-AOOZ-O4OV-4YA5-RRDA-PY7O-OKLJ-ZI53-5DAC-CKSG-HKPD-7F2T
-GDSD-GFY
   [MMM_Contact] 2  KUQN-JMY2-CAQI-GLSI-WTKY-DYIO-3ECO-SGYH-TBVH-E7HK
-ODVX-KQYP-TNAI-GX4J-R5KP-77CR-MAWV-TWN2-DTE2-TPIO-Z6NV-22MA-GUME-RU4
F-55QK-Q7Q
   [MMM_Application] 1  AVRH-X7EG-Y7XP-ODRD-4CI7-VANJ-VCC5-2QZ6-OSWP-
NZQ2-YZXT-UIXV-O2RJ-55SV-SASS-Q6NU-UES4-7VGA-IEKP-IEDO-Y3JE-HGO2-MCVI
-R77S-DGIA-3XA
   [MMM_Publication] 1  YQYF-DVGC-2IM3-GHEB-PVTI-ZTET-7FYQ-VAJV-Y3ZD-
6L7C-SNQT-T4PE-MU5H-7RPZ-W6QE-LL5Z-2SRN-DU56-XWVO-VKL7-4LBL-DRJE-H5YM
-KZND-PTKO-CAA
   [MMM_Bookmark] 1  XSTJ-KPPR-NBV6-OP4H-IXZM-ROMN-4RLP-KC2J-UALI-QC5
D-ZUXW-72VO-4K6T-CFKM-OAEJ-42Q2-UONW-3LCL-YSXR-V373-CJT4-6ESX-YMOF-GU
2W-S6YF-FXY
   [MMM_Task] 1  HHP3-XLII-AT54-L7QO-XVUC-ACBE-Q3RK-NZGT-DTZZ-ISB2-OF
FZ-JGNK-WJGD-FXZD-TCQW-Z2FN-P6NF-F55V-VSR6-NHAQ-UZWA-QQ2S-CHCB-VD7Q-K
D72-IJI
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
<rsp>Share: SAQO-MD74-FOOI-VYSU-4IKS-IW6Q-WSPK-HB4C-L5S4-WOVL-KFL6-QQAW-X6
FF-FIP5-O5FA
Share: SAQQ-IHXW-BPO5-IYZY-LT4R-F53O-G3KW-IS64-6IKT-XQQD-OYHJ-XCTA-76
H6-RAQQ-7ZKA
Share: SARC-ELPP-5QPR-3ZA3-27OQ-DEYL-XEGC-KEBX-QTCK-YSK3-TLCU-5VFL-H6
KX-4YRE-QWFQ
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
<cmd>Alice> meshman account purge MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF
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
<rsp>PIN=ADFR-TEQU-3HJD-IRND-P4TS-CRBD-NI
 (Expires=2022-04-21T16:17:50Z)
</div>
~~~~

The 'connect' command is used to connect a device to the account by means of a 
connection URI. This is usually used to connect devices by means of a QR code 
printed on the device itself.


~~~~
<div="terminal">
<cmd>Alice> meshman account connect ^
    mcu://maker@example.com/EBKG-ED3O-HBHK-ZQGS-EX4H-X22S-X4 /web
</div>
~~~~

The connecting device will only receive notice of the connection request if it
has some form of network connectivity allowing it to discover that the connection
request is pending.


