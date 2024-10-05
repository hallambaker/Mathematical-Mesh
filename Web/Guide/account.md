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
   Service UDF = MBQH-INKI-FD4A-QLNG-CSXQ-CB7I-UESI
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
UDF=MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
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
   [Access] 3  DE4E-KHDQ-NIAS-IIJP-RGFD-V52Y-P62J-UM2C-DRTR-BZY5-AOL3
-VTY2-EISR-EGPV-MA3C-6LHD-NERQ-LKAA-OH2U-VIFY-DMM5-RFX2-6GXL-PDNM-XTG
L-6NY
   [Credential] 3  5FWG-JP2O-KTNN-GJTR-D44Y-EIUE-MMRL-EYXM-4DKT-HOWX-
SZIZ-5PRV-SA76-527D-2YAQ-XWZT-UPXW-7GOA-I42F-4GUY-MTIO-VFVW-2MCW-LFJG
-5HMH-MZQ
   [Device] 3  KPWR-XFKF-SQNY-LQPK-ZR26-NDWX-V75Y-6LEE-E62E-2I6V-O3O6
-B4RU-VXTU-I6SY-LXWH-BOXL-MYVB-VEPV-B2QQ-HXCF-N3ZL-4ZQ7-IP6Q-LZAU-WSR
4-25A
   [Contact] 3  RTHF-IPU3-B4GZ-XMMT-5STA-4E4B-UKLY-Z3UK-XLP4-JCJQ-C6Q
4-FDEE-ATEA-7CGW-4C42-NMNC-VST7-6YGK-S6L3-6SFZ-55XU-I7BQ-KGRA-BQEM-KE
IQ-XXQ
   [Application] 1  R4TM-YOZT-OJVW-FLOQ-QCNY-7GOQ-RIZ2-FIWC-ONIT-PZD6
-6PTY-DD5J-54SG-OKVO-GYEK-2QZM-3V7J-LKOI-GC23-JT76-CLIV-LNZV-RXM7-UUW
H-UT2U-EIY
   [Publication] 1  CMHY-LT5A-SPGE-DVUX-BFMH-KD6J-YM62-ZGSU-UCVA-HOUW
-UZBO-7RIJ-KRWP-O4D5-7PBX-QHKN-4UKB-BMFG-W4KL-KZCK-CKWM-7MOT-A3KV-AXC
E-3NNX-6ZI
   [Bookmark] 1  DKGC-SB5P-YVKR-4B35-T75E-IOVH-MOYS-EYGF-DFIS-BV5L-TS
DA-FWM3-E4FK-TGBM-SKBM-ZJAP-FIDA-BIQW-BZXH-2U2N-VMMH-EBGF-23C4-OZXD-A
JWO-QMI
   [Task] 1  JID4-ZKJJ-OEHX-ZICV-K346-O62P-W5TJ-L2ZU-DECZ-MNBQ-QIP6-5
TF5-63BF-LIUA-54TP-LIV6-UGQZ-AAZG-4U25-MH4Z-AVWY-JDYV-OV6S-EVIN-2Q65-
WYY
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
<rsp>Share: SAQK-CMVM-SDD6-CBVS-PTLL-KD3W-TXOY-AJMB-ISTJ-NBJG-ED57-7EQW-ZI
O7-TNH7-UX7Q
Share: SAQX-UZCW-GOZB-VWCM-5PT3-PDQR-BYKX-32Q5-Z6BH-SN3V-UOEV-NIJ5-PP
BU-LOZH-S2AA
Share: SARF-HFP7-22OF-JKPH-LL4L-UDFL-PZGX-XLV2-LJPF-X2OF-EYLK-3MDE-FV
UJ-DQKP-Q4AQ
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
<cmd>Alice> meshman account purge MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
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
<rsp>PIN=AA34-4UB6-2FPH-KPT6-JNTU-PNWR-MU
 (Expires=2024-10-06T00:49:11Z)
</div>
~~~~

The 'connect' command is used to connect a device to the account by means of a 
connection URI. This is usually used to connect devices by means of a QR code 
printed on the device itself.


~~~~
<div="terminal">
<cmd>Alice> meshman account connect ^
    mcd://maker@example.com/EC2K-TADU-3ZHN-BPBC-TZY6-EAKJ-SM /web
</div>
~~~~

The connecting device will only receive notice of the connection request if it
has some form of network connectivity allowing it to discover that the connection
request is pending.


