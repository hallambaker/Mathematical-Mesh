
For example, when Alice reads the connection request from the device in the architecture 
examples, a completion message is added to Alice's inbound spool so that the device is not 
activated a second time by mistake:

~~~~
{
  "MessagePin":{
    "MessageId":"AASR-ULYD-AOG2-45LY-75Q2-7NAH-SV7F",
    "Account":"alice@example.com",
    "Expires":"2021-01-09T01:10:39Z",
    "Automatic":true,
    "SaltedPin":"AA3Z-HSRM-SUXL-OW3D-AQPN-AXGH-HGNG",
    "Action":"Device"}}
~~~~

The details of the presentation and verification of the PIN code
are further described in the section below.

