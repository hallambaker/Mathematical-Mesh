
For example, when Alice reads the connection request from the device in the architecture 
examples, a completion message is added to Alice's inbound spool so that the device is not 
activated a second time by mistake:

~~~~
{
  "MessagePin":{
    "MessageId":"AA4D-3P26-SJ4N-PB2H-TJCN-LXHL-B4QT",
    "Account":"alice@example.com",
    "Expires":"2021-01-10T23:03:51Z",
    "Automatic":true,
    "SaltedPin":"ABH6-Q2EL-HTEM-WO3J-TSX5-AXCT-4LNR",
    "Action":"Device"}}
~~~~

The details of the presentation and verification of the PIN code
are further described in the section below.

