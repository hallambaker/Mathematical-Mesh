# Errors


## Delete device


This problem appears to be the result of a lock being acquired and not released when the
context request fails.

It is probable that any request failure inside the service will cause the same result.

Need to add trace statements around the lock acquisition/release.





PS C:\Users\alice\Mesh> meshman device delete  MDY5-5VVH-77LO-LL6H-BZ7C-UBOD-GXWM
PS C:\Users\alice\Mesh> meshman account pin /threshold
[hanging]


The service is hanging after the deleted device attempts to connect.
The deleted device gets the clean refusal
The device attempting authorized action hangs

Restarting the service solves the issue.

Appears that when the device attempts an action that is refused, the service stops processing connections.


- No context in Mesh Host at all.


# Triaged functionality

## Why are closed messages still appearing???

* device connection requests are removed
* NOT Confirmation, Cotact or Group


## Can't use device pending any more???

 meshman device pending

## Change device authorization

meshman device auth /web


## Recover account

PS C:\Users\alice\Mesh> meshman account escrow 3 2
Share: SAQP-6FL6-YMSM-6OPD-RCKY-RX4C-MQFB-RB7N-HSM4-LXYK-KHVZ-UXS3-YFOB-3WOG-CYKA
Share: SAQT-MKP2-2T73-BO3R-T5HT-VQ4H-TIE3-ZDCM-CXZZ-TON5-MB2U-HIVO-ZJER-GPPB-ZI2A
Share: SARG-2PTW-43NJ-EPH7-WYEO-ZJ4M-2AEW-BEFK-55GW-3FDQ-N37O-ZZYB-2M3A-RIP5-P2AQ

PS C:\Users\alice3> meshman account recover SAQP-6FL6-YMSM-6OPD-RCKY-RX4C-MQFB-RB7N-HSM4-LXYK-KHVZ-UXS3-YFOB-3WOG-CYKA  SARG-2PTW-43NJ-E
PH7-WYEO-ZJ4M-2AEW-BEFK-55GW-3FDQ-N37O-ZZYB-2M3A-RIP5-P2AQ /account=alice@example.com


Is failing because there is no service operation to rebind the account.

## Send Multiple Responses to Confirmation Request...


PS C:\Users\alice\Mesh> meshman message accept NDEL-DNNE-Q57Z-NAFD-SUZ3-YESG-BMKQ
PS C:\Users\alice\Mesh> meshman message reject NDEL-DNNE-Q57Z-NAFD-SUZ3-YESG-BMKQ


PS C:\Users\bob> meshman account sync
Intern EnvelopeID MAVX-Z2LX-ZUGU-J6OY-O5OB-DN5M-HDHZ, Message MDXT-2GOZ-7WND-LD3C-763B-2PA7-YDPD Status Open
Intern EnvelopeID MAVX-Z2LX-ZUGU-J6OY-O5OB-DN5M-HDHZ, Message MDXT-2GOZ-7WND-LD3C-763B-2PA7-YDPD Status Open
[Hanging]



# Cosmetic

## Enter local device name into cataloged device entry




## Command line help

Give detailed info on groups /commands
meshman help message
meshman help message pending


## Command line
Always allow parameters to be specified as options (cf positional arguments in c#)



## Poor error messages

PS C:\Users\hallam\Work\mmm> meshman account create me@example.com
Application: One or more errors occurred. (No connection could be made because the target machine actively refused it. (voodoo.example.com:15099))


## crappy feedback on serviceadmin create...
PS C:\Users\hallam\Mesh> serviceadmin create example.com /host=host1.example.com /ip=192.168.1.21:15099 /admin=admin@example.com
Created Service System.Collections.Generic.List`1[System.String]
  Service MA3B-YM64-7YNG-6KZZ-UECR-KFYL-XEOW
  Host MDCD-4CIG-TCIT-GBDB-AJ5P-HV3M-QZIJ