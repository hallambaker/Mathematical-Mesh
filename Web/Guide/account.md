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
   Service UDF = MBQP-EWUT-UYX2-Q3GS-HB4O-3VBQ-IKP2
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
UDF=MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
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
   [Access] 3  FTV2-6EUH-K3F4-DSSC-WH3Z-ZGYL-AOHK-ESMZ-7QOW-BQBH-SUNH
-DZ5J-C744-BTCH-D6E5-2E6P-37ST-OEDD-2FVB-IQ5C-THNQ-A3CG-W3EB-Y4JF-ISB
N-ICQ
   [Credential] 3  FRTC-3OGB-FRNK-E7NU-NGQK-5VKD-WKWA-X566-MBUX-HMA5-
BRLN-IPPY-BJ4H-B5E7-PMOJ-KLT4-F3RX-LAPW-LN7U-DZPN-KRUX-VMGI-CAEF-2KRC
-QNFA-NDA
   [Device] 3  PWOO-Z54D-YSCE-7EXY-QZ7D-TVEM-KZTV-OFMJ-LXBK-F73B-POLL
-KICP-MKYH-23U5-TJEP-CTNZ-Z6PT-IYKC-5K7F-5KTD-XNSE-QK7F-WJIG-ANUQ-UVN
O-25A
   [Contact] 3  DUVI-ORBY-WHO3-2F25-M3V2-ORQZ-P2PM-3VY3-DGG5-B2FC-4U4
5-X3JM-ETKY-CY6C-32DO-J36K-5PQK-DYE7-KQ6O-SCU7-MODY-YWY2-SCTN-E3F7-KZ
VO-T2I
   [Application] 1  2TWO-W44H-3QRC-3GXQ-G4PV-HVOF-BYHS-FPKD-L6TB-DJ6B
-XL5X-YTZX-3SJM-SJIX-YLK2-TCUA-EJJK-56OX-4P2Q-T3FU-OUX6-LHZA-EU5S-X4Z
4-TM7C-7FA
   [Publication] 1  NK27-4H5T-YW5P-LMLR-IIDH-GRXC-K6TG-C6GE-A25J-GFOZ
-ISOC-LJR6-3U7Z-ITCD-UBDY-BPOM-NJSJ-SC7B-KOJQ-YYPX-RSIX-UR4T-3XYH-4CR
X-KHHF-LMY
   [Bookmark] 1  QRFZ-PNO6-IZHI-VJQS-OMHK-R2UN-NXOX-KKRP-P4AD-PNDO-X5
AA-ZTG3-RFFA-4V5Z-7WYV-4TO4-6R3O-IDVD-RC5R-QLII-57I6-VTQR-JCIN-VBDS-Y
QEN-E2I
   [Task] 1  IBXI-Q4M2-NU3B-UFIE-L6BI-FZT4-NBL3-SLEF-CD62-ZJXL-63Q6-Q
GLV-YLH3-YY3K-C4B6-MFZN-MH2A-DB5T-CL7D-3E3U-IA4N-HP2G-752X-AZUS-LJWW-
NUI
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
<rsp>Share: SAQK-C23Z-ARHV-56TW-5S2T-KGIJ-YXWT-EIQY-DJAL-PQYW-4IWJ-C3RG-YZ
SL-R7KL-S6PA
Share: SAQX-VVPP-363K-WN2L-O7SQ-ZSOR-SU4S-IRFS-F6RF-QG2A-W4GQ-JRPE-HO
3K-WUIA-CVXA
Share: SARF-IQDG-XMO7-O5BA-AMKO-I6UZ-MSCR-MZ2M-IUB7-Q43K-RPWX-QHNB-WE
EJ-3JFU-SM7A
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
<cmd>Alice> meshman account purge MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
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
<rsp>PIN=AASP-5A76-VKQO-CZZF-SQ6R-DQUU-2A
 (Expires=2024-10-04T14:57:13Z)
</div>
~~~~

The 'connect' command is used to connect a device to the account by means of a 
connection URI. This is usually used to connect devices by means of a QR code 
printed on the device itself.


~~~~
<div="terminal">
<cmd>Alice> meshman account connect ^
    mcd://maker@example.com/EDZW-33F5-EL2X-SWIB-LKM3-J5PP-FM /web
</div>
~~~~

The connecting device will only receive notice of the connection request if it
has some form of network connectivity allowing it to discover that the connection
request is pending.


