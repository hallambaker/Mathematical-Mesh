# ToDo


## Need to get grants of capabilities to devices sorted.






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



