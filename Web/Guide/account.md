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
   Service UDF = MBQD-ETXU-HZRW-A26O-WDTR-K7GI-X6JD
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
UDF=MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
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
   [Access] 3  GYZY-FCUD-JN6L-XPDN-5W6O-SWD7-26VP-E46V-7K3I-UGP7-KSZU
-YA2J-AOG6-5MIS-X7P3-Y7QK-J6YE-YDIX-DUKZ-DAPC-2DCR-OEST-SY76-XQPK-VEY
Y-BGA
   [Credential] 3  GINL-R6EY-IKU2-BE5R-VMCP-7RVX-XPEJ-HCMC-D3P5-IA2U-
XFZJ-LPWC-JOZM-M44P-GWFX-5HXL-NZR5-FCET-YKEC-H7HF-YUP7-PCRR-NNAF-AIKG
-IEHM-UQA
   [Device] 3  BQ75-ELJ6-YRYC-2FVT-NODU-APAK-56HI-3N6U-EYSE-DNKT-Q5QE
-XHEQ-MZRK-IY22-DNGU-2SPS-D66C-ZF25-PMHW-3A53-3NFC-ROA4-RAWP-ND6A-LVR
B-TYA
   [Contact] 3  I7JD-7MQC-GCCK-LNNW-UVGH-AQHX-4CGB-P67Y-S6CR-XBOO-NL7
T-ERQ4-UZY6-GYRS-FAYZ-AXBT-SUCR-Z45S-ADV5-NEOR-NJ3A-2ZFA-2AFC-77QW-J3
EV-EVQ
   [Application] 1  N7SM-VHVO-IUFD-DNWP-VXVP-YKQG-T3TP-PVIC-PMUT-YTZ7
-B4VZ-OFTI-RDPD-2WAV-7N5Z-WG4V-P6QP-G2ZG-2HLB-R4DE-DLJC-2FX5-EEFJ-37Q
N-5N6Y-U6Q
   [Publication] 1  N7DS-JLBH-3AIU-UWHX-4UE4-5UKB-YBSP-KZMW-UQVR-527V
-DQHV-3XDP-TPGW-FNN4-3FSN-5NE4-XSHL-K23B-BART-2TID-4DYS-73LU-URZE-E3N
3-FQY3-3SQ
   [Bookmark] 1  FHRO-MAOE-ACCW-PZHU-7JGK-SAED-FSFR-FGBT-AHZV-AYTZ-7M
Y6-3E6C-3MHY-NU3N-4AW2-7H37-FK2F-MNHJ-IELG-TBSY-2ESN-YMDN-MSRG-LPX2-M
O77-46I
   [Task] 1  J33X-TDKM-HQVO-5F6G-FXOX-64UO-LYMS-XSD5-OBOD-4A7J-DPW4-P
RZN-6HNT-A6YW-XDHK-SUGM-EY6M-4ZI2-PGNS-5R5T-HWDT-BRJX-TPRP-ZA5X-KNQI-
RHA
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
<rsp>Share: SAQN-VODM-D7P3-UFD7-BKS3-GNS5-KRBR-OUDN-TLPT-ISTY-ABVQ-BSJW-H5
R5-UDAM-67CA
Share: SAQ6-236V-ZWQV-VMO5-DSEV-NEGC-BKFX-CHRW-UONP-UB5G-ZMM6-JKIS-XV
E5-5SD5-HM7A
Share: SARA-AJZ7-PNRP-WTZ3-FZWP-T2ZG-YDJ4-V277-VRLL-7RGV-SXEM-RCHP-HM
X6-HBHN-P2FQ
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
<cmd>Alice> meshman account purge MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
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
<rsp>PIN=ADE7-U5DR-2YNJ-XKVX-4RUE-SVL5-5I
 (Expires=2024-10-15T13:10:56Z)
</div>
~~~~

The 'connect' command is used to connect a device to the account by means of a 
connection URI. This is usually used to connect devices by means of a QR code 
printed on the device itself.


~~~~
<div="terminal">
<cmd>Alice> meshman account connect ^
    mcd://maker@example.com/EBH3-DT6M-G2WA-EF7E-DA42-DN55-7E /web
</div>
~~~~

The connecting device will only receive notice of the connection request if it
has some form of network connectivity allowing it to discover that the connection
request is pending.


