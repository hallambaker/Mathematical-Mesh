# ToDo

## Merge Post with Update


[Have renames Post to PostOld to identify issues.]


1) Check all the envelopes meet the catalog/spool security policy and size constraint. 

2) lock all the required catalogs (probably lock the account)

3) Check that all the updates are consistent with the state of the catalog

4) Perform all the updates

5) Append all the messages to the relevant spools

6) Release all the locks.


## Need structure to specify security policy for stores

Encrypted under this key
Signed under that key

Routine to check that a store is consistent with the security policy



## Define Rights Structure

A Rights structure specifies a set of keys that a device is to be granted.

<dt>Genesis Rights

<dd>Device has the genesis seed for the account and can grant any other privs.


<dt>SuperAdmin Rights

<dd>Device has 





## Enable the grant of admin privs to another device

The admin keys for each device should be unique

The devices need to be able to sign a master profile

So threshold share the signature keys for the Mesh/Account and put one share on the device and the other as a capability 

## Deleting stuff from catalogs isn't really there yet


## Implement Mail unit tests

[Need to implement the glue logic]

## Implement SSH unit tests



## Think through the escrow/recovery scheme

Has to be AFTER the applications are defined.

* All escrow entries are recorded as device entries encrypted under the Mesh profile encryption key

## Recover Mesh master signature/decryption capability

* Present 2/3 shares
* Get Mesh master key

Can sign account profiles
Can sign device profiles
Can grant admin privs to a device

Can recover escrow records for all accounts

## Recover Account master signature capability

From the escrow record in the device catalog using Mesh master decrypt key

Is used to transfer account to a different service.



