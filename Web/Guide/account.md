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
   Service UDF = MCAO-XTIB-YRN5-OZY7-PQY2-V677-UTBG
</div>
~~~~


## Creating a Mesh Account

A Mesh account is created using the 'create' command. 

The user specifies the initial account address to be used (alice@example.com). Use of this address
is of course dependent on authorization by the Mesh Service Provider (example.com)
and is likely to require authentication and possibly payment. 

of some form of one time use token to allow binding of a Web interaction providing payment
details to the request to bind the account to a service.



~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT
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

[Future Feature: ListGet] List/get not currently implemented. 



~~~~
Missing example 6
~~~~


## Synchronizing an account with a service

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

The 'account status' command returns the same information as 'account sync' without attempting
synchronization. 


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
<rsp>Share: SAQF-PZER-T2XO-6OIJ-CXPY-DEAG-IL3C-ICGC-KM4H-SAHW-F4WO-MWZT-EF
67-LUCU-PVFA
Share: SAQ6-PSBA-J6OA-KZAA-KYVI-K4WQ-ECF6-EXSZ-OT4H-YN6B-2ENC-6U6T-OV
HT-3BPB-BWUA
Share: SARH-PK5P-ACER-XDXX-SZ2Y-SVMZ-7YQ2-BM7Q-S24H-63UN-OMDX-QTDT-ZE
QI-KO3N-TXMQ
</div>
~~~~

The recovery command is used to recover access to the account from another device if the
original administration device is lost or compromized.


~~~~
Missing example 7
~~~~


After verifying that the account can be recovered on another device, the primary secret 
may be purged from the administration device using the 'purge' command. This command is
of course irrevocable.


~~~~
Missing example 8
~~~~


## Account import/export

[Future Feature: Import/Export] ? These features are not currently implemented.

The export command causes the entire account profile to be written to an archive.
This may be used to create a backup copy of the account for archiving purposes
or to facilitate provisioning the account to a new machine.


~~~~
Missing example 9
~~~~

The import command causes the account profile to be read back from the archive.


~~~~
Missing example 10
~~~~

## Device connection commands

The 'pin' command is used to create a PIN code to provide an out-of-band pre-authentication 
code for use in device connection. This command is only available to an administration device.

The authorizations to be granted to the device may be specified during PIN creation. This
allows the device connection process to be completed without additional user interaction. But
the connection can still only complete when an administration device creates the necessary 
credentials.


~~~~
Missing example 11
~~~~

[Future Example: DeviceConnect] ? 

The 'connect' command is used to connect a device to the account by means of a 
connection URI. This is usually used to connect devices by means of a QR code 
printed on the device itself.


~~~~
<div="terminal">
<cmd>Alice> meshman account connect ^
    mcu://maker@example.com/EC7U-PEKJ-TG45-LVJY-QBWT-ERB6-UQ /web
</div>
~~~~

The connecting device will only receive notice of the connection request if it
has some form of network connectivity allowing it to discover that the connection
request is pending.


