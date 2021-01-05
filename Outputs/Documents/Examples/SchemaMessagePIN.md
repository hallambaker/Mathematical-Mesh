
For example, when Alice reads the connection request from the device in the architecture 
examples, a completion message is added to Alice's inbound spool so that the device is not 
activated a second time by mistake:

~~~~
{
  "MessagePin":{
    "MessageId":"ADDC-J2WR-ZF6Y-YQON-GTQG-AJT4-IRAY",
    "Account":"alice@example.com",
    "Expires":"2021-01-05T13:39:43Z",
    "Automatic":true,
    "SaltedPin":"ADNA-OP2O-6FUH-UIBI-4PNS-ODFC-ZS5H",
    "Action":"Device"}}
~~~~

The details of the presentation and verification of the PIN code
are further described in the section below.

