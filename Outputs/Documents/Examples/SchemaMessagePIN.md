
For example, when Alice reads the connection request from the device in the architecture 
examples, a completion message is added to Alice's inbound spool so that the device is not 
activated a second time by mistake:

~~~~
{
  "MessagePin":{
    "MessageId":"ACOQ-3BOU-7GKJ-B3NI-WRIO-GYYB-7GVH",
    "Account":"alice@example.com",
    "Expires":"2021-01-12T17:13:18Z",
    "Automatic":true,
    "SaltedPin":"AATY-GTQC-5K65-M7XM-LUUD-SL5K-JLCR",
    "Action":"Device"}}
~~~~

The details of the presentation and verification of the PIN code
are further described in the section below.

