
# Using the `profile` Command Set

The `profile` command set contains commands used to create and manage
Mesh profiles.


## Contacting a Mesh Service

The `profile hello` command contacts a Mesh service and returns
a description of the service parameters.


````
>profile hello alice@example.com
OK
````

If a Mesh account is specified, the tool attempts to connect to a Mesh service
at the associated domain. It is not necessary for the account to be registered
at the service when the request is made.

## Creating a profile

To begin using the Mesh, it is necessary for the user to create a Mesh profile.
This includes the steps of:

* Create a Master profile.

* Create a device profile.

* Create a Mesh profile and make the current device an administrator.

* Register the Mesh profile with a Mesh service.

The `profile create` command performs all four of these functions.


````
>profile create  alice@example.com
OK
Device Profile UDF=MDEH-FIHJ-BZCK-3UUB-EO2B-GUPM-64NV
````


## Synchronizing a profile

The `profile ` command is used to synchronize the catalogs and 
spools associated with a Mesh profile:


````
>profile sync
OK
````

Synchronization is also performed automatically before every command requiring 
interaction with the Mesh service.

## Listing profiles installed on a machine

The `profile list` command lists all the profiles available on the 
machine:


````
>profile list
OK
````

The `profile dump` command provides a more detailed description of 
a profile:


````
>profile get /mesh=alice@example.com
ERROR - The feature has not been implemented
````

## Escrowing Profile Master Keys

The more reliance that a user puts on a cryptographic infrastructure, the more 
serious the consequences of the loss of the encryption and authentication keys.
As the recent episode of 'ransomware' attacks demonstrates, for most users, the
very worst security compromise that could affect them is the loss of the
pictures of their children when they were five years old.

The `profile ` command escrows the signature and encryption keys
of the user's master profile and returns a set of recovery shares. 


````
>profile escrow
Share: SAQD-DNVA-EA7F-2WHR-MKCA-R2IG-MB66-W
Share: SAQR-4DRO-OWRX-5HXU-EGSZ-7ZON-3MFT-2
Share: SARA-UZN4-ZMEJ-7ZHW-4DDT-NYUV-KWMI-6
Written to MDHO-WHH7-4RZC-DU6S-5FLA-6CIW-EJK6.escrow
````

By default, three recovery shares are created such that two shares are required to
recover the master keys.

Recovery of the master keys is performed by the `profile recover`
command.


````
>profile recover $SAQD-DNVA-EA7F-2WHR-MKCA-R2IG-MB66-W $SARA-UZN4-ZMEJ-7ZHW-4DDT-NYUV-KWMI-6 /verify
ERROR - Object reference not set to an instance of an object.
````

The `/verify` flag causes the tool to check that the keys can be correctly recovered
without actually installing on the machine.

## Changing the Mesh Service

The `profile ` command allows a profile to be registered at a different
Mesh Service:


````
>profile register alice@example.net
ERROR - The feature has not been implemented
````

Although the Mesh protocols are designed to allow a Mesh profile to be registered with
multiple services, this use is not currently implemented in the Mesh reference code.

## Direct profile management

A Mesh profile may be exported as a file using the `profile ` command:


````
>profile export profile.dare
ERROR - The feature has not been implemented
````

The `profile ` profile can then be used to import the file on another 
machine:


````
>profile import profile.dare
ERROR - The feature has not been implemented
````

