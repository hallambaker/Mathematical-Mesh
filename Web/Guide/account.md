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
   Service UDF = MAWW-D3T6-T5C5-P7SQ-QDYF-JGD7-KHHU
</div>
~~~~


## Creating a Mesh Account

A Mesh account is created using the 'create' command. 

The user specifies the initial account address to be used (alice@example.com). Use of this address
is of course dependent on authorization by the Mesh Service Provider (example.com)
and is likely to require authentication and possibly payment. 


~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N
</div>
~~~~

The command returns the value of Alice's Mesh Account fingerprint . 
This value is used as a unique identifier that is cryptographically bound to the signature key used
to authenticate the account profile.

When creating an account, creation of an escrow recovery keyset is highly recommended.

## Account description 

A device may be connected to multiple accounts at the same time. The 'list' command
returns a list of the accounts to which the device is connected and the 'get'
command returns information about a particular account.

[Future Feature: ListGet]

 These are not currently implemented.



~~~~
Missing example 1
~~~~


## Synchronizing an account with a service

The sync command is used to synchronize the account to the service. 

[Future Feature: AutoSync]

 Currently, the tool requires
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
<rsp>Share: SAQO-T6ME-QKJ4-QQZW-MLYG-O7EO-LOYT-MHVP-N65F-MUII-WL6D-4H6I-5Z
S3-5TX3-42UA
Share: SAQQ-X4QG-INU4-FWLG-MOQY-VGP6-TWZT-JN47-H26J-AOA3-E65C-DLLW-J3
SW-ZICZ-I7BA
Share: SARC-32UI-AQ73-234W-MRJK-3N3O-362T-GUEP-BW7M-UHZN-TR4A-KOZD-V5
SR-U4NW-VEEQ
</div>
~~~~

The recovery command is used to recover access to the account from another device if the
original administration device is lost or compromized.


~~~~
Missing example 2
~~~~


After verifying that the account can be recovered on another device, the primary secret 
may be purged from the administration device using the 'purge' command. This command is
of course irrevocable.


~~~~
Missing example 3
~~~~


## Account import/export

[Future Feature: Import/Export]

 These features are not currently implemented.

It should be possible to transfer accounts between devices without going through a service.


## Device connection commands

The 'pin' command is used to create a PIN code to provide an out-of-band pre-authentication 
code for use in device connection. This command is only available to an administration device.

The authorizations to be granted to the device may be specified during PIN creation. This
allows the device connection process to be completed without additional user interaction. But
the connection can still only complete when an administration device creates the necessary 
credentials.


~~~~
Missing example 4
~~~~

[Future Example: DeviceConnect]

 

The 'publish' and 'connect' commands are used to 


~~~~
<div="terminal">
<cmd>Alice> meshman account connect ^
    mcu://maker@example.com/EDIW-AY5A-RCNT-KNG3-3MBV-WVLT-24 /web
</div>
~~~~







