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
   Service UDF = MBYH-BJ3I-EUWL-7QAI-NGIE-TPC6-X4KU
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
UDF=MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
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
   [MMM_Access] 3  V6JB-VDEV-RDKR-QU26-3VR5-X453-4UST-HJQV-BSQ7-M32L-
E7HO-MQWW-FYO3-IODK-MQWP-WATQ-EEL2-NN3U-7UCU-6MV6-B7CB-HORS-B3OE-XZNM
-HJN2-MJY
   [MMM_Credential] 3  A6IB-GU3Y-HYXT-4IUA-RHJ4-YVVS-6AR2-VPVF-GHQN-T
CMK-AVQ5-HZZU-VM3G-W2OV-OW3B-YCMC-ULOC-HDIQ-OP45-INQQ-UEFD-N2V7-ZLUG-
XIXF-MIHB-P5I
   [MMM_Device] 3  VIHB-S77U-DZWD-CJ2H-REHT-T47H-IEEI-3GCI-K3IG-2NIX-
Y2EU-PTPT-4YTM-UUXS-TQRG-VUIU-MTJU-IMQN-3LCE-2KEW-PIOS-UABP-IWV5-ODGE
-R7JW-2VI
   [MMM_Contact] 2  XK43-WSMU-NZJW-VVQ5-RM7H-VDCZ-FYH5-MI4B-5TQI-BITU
-G67U-JT4G-BP75-UAGQ-B7YO-FAAT-DZA3-X5EN-7D7P-WU2Y-PLOJ-SEFE-GDPF-FU5
L-XZ76-ULY
   [MMM_Application] 1  TZMN-KIP3-X4L2-SRYN-ESMJ-7R2Y-O2IT-6QGA-MCZW-
FAKI-7YWC-HIJ4-XUYD-IE4V-7B6J-MR2L-YTK4-YJKI-CC7O-5LOF-LUXR-OAOR-46UD
-Z3ZW-PWEH-FOI
   [MMM_Publication] 1  LYJY-I6DN-OBUP-OPAZ-CUS5-IER7-OQ5A-UQTV-4RUS-
6SOP-L2K5-J3BZ-OGSP-2WKC-6VNW-MFH3-H27Q-WEG2-PXHM-S7JM-C565-MA57-VWWF
-OJRQ-C2XE-Q6Q
   [MMM_Bookmark] 1  K3WK-ZPGG-RXN7-NWK6-WJXE-H2AY-UXYI-OKG7-UAZ3-LZK
E-CISD-JNR7-PQO3-TBXO-4HG5-BFRR-NRQM-A4V6-3SSU-2MLB-IL4I-6I3B-RAM4-MY
QO-QH2V-NSI
   [MMM_Task] 1  UW4M-SC5T-N4QJ-IBPG-I62W-5E52-43V5-G624-54LJ-XK75-OK
4H-LXF2-2XJC-ODFY-N2KU-ISKT-24CL-CJZJ-GK3W-JRKO-5M3R-G5EL-4RDE-NLSR-F
5YA-WFA
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
<rsp>Share: SAQE-JRDL-32AC-GBJK-6WC5-IUEO-5VGH-5LHC-F6GO-7R4S-UAMS-IDDQ-LX
HD-GHKE-GTPQ
Share: SAQ4-DB6V-V4E3-DTCA-OTCE-K56Z-JQ4L-66NG-QDFF-SGJ4-47QM-RQT4-ST
36-UX6R-IPIQ
Share: SARD-4SZ7-P6JU-BE2V-6QBL-NHZD-VMSQ-ARTK-2ID4-E2XH-F6UG-26EI-ZQ
Q2-DIS6-KKLA
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
<cmd>Alice> meshman account purge MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
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
<rsp>PIN=AAIT-WXRD-BVB7-3BBT-D6JS-44GE-B4
 (Expires=2022-10-19T12:48:11Z)
</div>
~~~~

The 'connect' command is used to connect a device to the account by means of a 
connection URI. This is usually used to connect devices by means of a QR code 
printed on the device itself.


~~~~
<div="terminal">
<cmd>Alice> meshman account connect ^
    mcu://maker@example.com/ED6B-KIW3-TSCC-P4LM-4D3I-IAPD-LE /web
</div>
~~~~

The connecting device will only receive notice of the connection request if it
has some form of network connectivity allowing it to discover that the connection
request is pending.


