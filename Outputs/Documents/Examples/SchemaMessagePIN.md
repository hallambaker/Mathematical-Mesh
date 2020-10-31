
For example, when Alice reads the connection request from the device in the architecture 
examples, a completion message is added to Alice's inbound spool so that the device is not 
activated a second time by mistake:

~~~~
{
  "MessagePin":{
    "MessageId":"ADXG-6TAX-DUMF-SRYL-C6V7-S2UW-FYXJ",
    "Account":"alice@example.com",
    "Expires":"2020-11-01T01:45:23Z",
    "Automatic":true,
    "SaltedPin":"ABVT-4TZ6-KSVG-UTA2-55LI-SAHH-UEF7",
    "Action":"Device"}}
~~~~

The details of the presentation and verification of the PIN code
are further described in the section below.

