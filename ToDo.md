# Errors

Unit tests !!!!

## SSH 

Public key not written out to file as it should be


## Passwords

PS C:\Users\alice\Mesh> meshman password add "example.com" "therealalice" "password"
PS C:\Users\alice\Mesh> meshman password list
CatalogedCredential

Need to properly describe the password data

## Device list

PS C:\Users\alice\Mesh> meshman device list
PS C:\Users\alice\Mesh>
Doesn't


## Delete device

PS C:\Users\alice\Mesh> meshman device delete  MDY5-5VVH-77LO-LL6H-BZ7C-UBOD-GXWM
PS C:\Users\alice\Mesh> meshman account pin /threshold

- No context in Mesh Host at all.


# Group add 

PS C:\Users\alice\Mesh> meshman dare encode foo.txt bobfoo.dare /encrypt bob@example.com
PS C:\Users\alice\Mesh> meshman group create groupw@example.com
Account=groupw@example.com
UDF=MCOX-4VYV-EH5Y-623F-FJET-PTOW-QXL7
PS C:\Users\alice\Mesh> meshman dare encode foo.txt wfoo.dare /encrypt groupw@example.com
PS C:\Users\alice\Mesh> meshman dare decode wfoo.dare
Application: No decryption key is available
PS C:\Users\alice\Mesh> meshman group add groupw@example.com alice@example.com
Application: Object reference not set to an instance of an object.
PS C:\Users\alice\Mesh> meshman group add groupw@example.com bob@example.com
Application: Object reference not set to an instance of an object.


# Triaged functionality

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

## Command line help

Do not show flag on sub command

Only dump the top level groups

Give detailed info on groups /commands
meshman help message
meshman help message pending