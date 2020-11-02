
For example, when Alice reads the connection request from the device in the architecture 
examples, a completion message is added to Alice's inbound spool so that the device is not 
activated a second time by mistake:

~~~~
{
  "MessagePin":{
    "MessageId":"ADR7-ZHQ3-BPFA-LBAO-ISFS-IMEY-UMFW",
    "Account":"alice@example.com",
    "Expires":"2020-11-03T14:27:13Z",
    "Automatic":true,
    "SaltedPin":"ABXL-XUVM-3GLT-VVQQ-KN5F-WYQK-INLB",
    "Action":"Device"}}
~~~~

The details of the presentation and verification of the PIN code
are further described in the section below.

