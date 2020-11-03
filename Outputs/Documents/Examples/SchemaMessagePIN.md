
For example, when Alice reads the connection request from the device in the architecture 
examples, a completion message is added to Alice's inbound spool so that the device is not 
activated a second time by mistake:

~~~~
{
  "MessagePin":{
    "MessageId":"AA5N-TRQI-OF6D-RB2X-XKZM-YQEM-SZZ5",
    "Account":"alice@example.com",
    "Expires":"2020-11-03T20:32:55Z",
    "Automatic":true,
    "SaltedPin":"ADL5-TPIU-V6DO-P2JF-MUYZ-42UE-P5C4",
    "Action":"Device"}}
~~~~

The details of the presentation and verification of the PIN code
are further described in the section below.

