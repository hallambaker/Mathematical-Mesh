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
   Service UDF = MBQB-N254-VJTL-CHYH-YJTY-5H62-RHYG
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
UDF=MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA
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
   [Access] 3  P4J2-7XV5-RRYH-BSRI-QNOT-KDK5-6YV7-QI4G-P664-2ZBF-YKRX
-HKV3-P6KR-LP46-TNOE-F4AR-MN2R-ZTCX-ZZHL-FBYH-2UUU-XCYW-JWAQ-5OSC-WPF
U-ZPY
   [Credential] 3  PYF6-335M-J4IU-RUMY-LQZI-C4Z4-ARBN-Z7UX-VQYT-2D7K-
2N6I-LE73-PMBX-BTYC-EUGJ-ICBQ-WOB4-BZWM-OMXP-4M2J-XDCO-GNJH-CYNB-EHAF
-HFM5-CTQ
   [Device] 3  BYI4-4JIQ-6EA6-FZNX-7GSL-PDYV-6I35-LL7N-SBSF-PWGK-YTTJ
-ERTL-Z3KQ-X35B-NBYS-OHIX-6C4P-AOWM-3HRL-ZI6I-PTQH-5O6Y-PJKP-IFDB-6RW
F-KZA
   [Contact] 3  5VFJ-EJVP-POSE-NQL4-WUO4-QDVY-GO3B-A33M-TQEM-2IOJ-RJC
O-KEMU-TEV4-WUI7-HVUD-KWB4-RYH7-3NSC-FJYT-XRHI-HOHV-UL5T-U5ZG-XZNL-DL
HV-MOA
   [Application] 1  2AJO-XNOM-KE6A-JKIQ-LEBX-BAHK-KDWW-MPMM-2Z5C-YKEW
-FJGJ-KRCE-YSXC-2E44-VEXG-ANX2-7H26-KBY6-BI77-EJTN-RBRE-ZFLB-ISSZ-V4B
J-NUUC-V7A
   [Publication] 1  NIPH-YOJF-IKC3-FGVR-V7T6-WMZD-C4D2-UXED-M3KK-AVD7
-K37J-WHO2-KFRS-XMFT-W524-PYGB-FTWY-JGA6-HYI6-E7U4-3CNR-6XZ3-EL5N-3YY
F-744R-SEI
   [Bookmark] 1  K3W6-2LJU-EBMW-OMEE-2UNO-PHOQ-JK4P-RHZV-DB2A-XE3M-GJ
Y6-CW2S-6WGV-4JYC-FLDC-LGOW-2FHX-LTWY-MUVO-BUBB-GJFX-FVMU-UAQH-L7PV-D
W5L-YLQ
   [Task] 1  AMQ2-CDWT-6R3T-QQWF-ETEJ-FKSA-TIFG-H3LV-KU32-EPFV-7IMO-B
IDM-E6VF-H2OG-7QFL-BWXF-VZYS-4PYL-UBBP-CS3I-CQYN-LLGT-4T5S-NIH6-SLLO-
ECA
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
<rsp>Share: SAQF-CY6G-TKYG-SUGB-7ZUE-SCOT-2K5N-UQFQ-ALNG-6WQL-7MWL-KQGS-VG
DF-XVSH-K2SA
Share: SAQ5-VRUK-IJRB-KVOK-LNLU-SR7H-QJ6L-G2A4-5QMC-ATKI-MCPW-5NUI-6J
5W-UXMJ-RWZQ
Share: SARG-IKKN-5IJ4-CWWS-XBDE-TBP3-GI7I-ZD4J-2VK5-CQEE-YYJC-QLB7-HN
YH-RZGL-YSKQ
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
<cmd>Alice> meshman account purge MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA
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
<rsp>PIN=AC23-KHLF-VHYV-MQXF-3PM2-WZRM-TU
 (Expires=2024-10-05T13:13:13Z)
</div>
~~~~

The 'connect' command is used to connect a device to the account by means of a 
connection URI. This is usually used to connect devices by means of a QR code 
printed on the device itself.


~~~~
<div="terminal">
<cmd>Alice> meshman account connect ^
    mcd://maker@example.com/EACX-H62H-KJOX-E6DY-OA7A-R7ZC-PE /web
</div>
~~~~

The connecting device will only receive notice of the connection request if it
has some form of network connectivity allowing it to discover that the connection
request is pending.


