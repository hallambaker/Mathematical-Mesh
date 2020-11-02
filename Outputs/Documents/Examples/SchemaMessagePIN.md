
For example, when Alice reads the connection request from the device in the architecture 
examples, a completion message is added to Alice's inbound spool so that the device is not 
activated a second time by mistake:

~~~~
{
  "MessagePin":{
    "MessageId":"ADL6-WU4C-QQPP-XQKR-IFLJ-GVS4-DGW3",
    "Account":"alice@example.com",
    "Expires":"2020-11-03T17:41:37Z",
    "Automatic":true,
    "SaltedPin":"AAEF-6MYB-TTAO-4OQG-APVQ-XNCI-NFRZ",
    "Action":"Device"}}
~~~~

The details of the presentation and verification of the PIN code
are further described in the section below.

