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
   Service UDF = MCLV-U6YX-P3TO-X3VD-LIXM-V7ID-ZV7H
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
UDF=MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
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
   [MMM_Access] 3  
   [MMM_Credential] 3  
   [MMM_Device] 3  
   [MMM_Contact] 2  
   [MMM_Application] 1  
   [MMM_Publication] 1  
   [MMM_Bookmark] 1  
   [MMM_Task] 1  
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
<rsp>Share: SAQM-LBD6-ELSN-MCDY-V3KC-UBE3-FUN6-ZIXA-U2HY-UAQ6-TUO3-TACH-42
5X-BFL7-PRRQ
Share: SAQ4-GB72-CU7G-AMJP-XWZ6-CLNO-B3SM-NSWN-IWXO-FDO3-F42F-L4IP-YY
22-O75A-EKXQ
Share: SARM-BC3W-A6L6-UWPG-ZSJZ-QVWA-6CW2-B4VZ-4THD-WGMX-YFFP-EYOX-UW
X5-42OA-ZD5Q
</div>
~~~~

The recovery command is used to recover access to the account from another device if the
original administration device is lost or compromized.


~~~~
<div="terminal">
<cmd>Alice2> meshman account recover /verify
<rsp>ERROR - The feature has not been implemented
</div>
~~~~


After verifying that the account can be recovered on another device, the primary secret 
may be purged from the administration device using the 'purge' command. This command is
of course irrevocable.


~~~~
<div="terminal">
<cmd>Alice> meshman account purge MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
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
<rsp>PIN=AAGV-IFMG-7JH7-VLYL-3PEB-PU4S-4E
 (Expires=2021-12-23T01:13:18Z)
</div>
~~~~

The 'connect' command is used to connect a device to the account by means of a 
connection URI. This is usually used to connect devices by means of a QR code 
printed on the device itself.


~~~~
<div="terminal">
<cmd>Alice> meshman account connect ^
    mcu://maker@example.com/EBFD-WARU-YCA7-WY6M-GYIP-IXWG-HQ /web
</div>
~~~~

The connecting device will only receive notice of the connection request if it
has some form of network connectivity allowing it to discover that the connection
request is pending.


