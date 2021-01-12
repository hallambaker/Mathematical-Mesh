
For example, when Alice reads the connection request from the device in the architecture 
examples, a completion message is added to Alice's inbound spool so that the device is not 
activated a second time by mistake:

~~~~
{
  "MessagePin":{
    "MessageId":"ABM5-DVCA-KOAF-YPHM-PFWG-LNBI-MLGP",
    "Account":"alice@example.com",
    "Expires":"2021-01-13T18:42:18Z",
    "Automatic":true,
    "SaltedPin":"AASJ-7OXP-TMIO-63ZC-Z7IE-PGIR-TPXX",
    "Action":"Device"}}
~~~~

The details of the presentation and verification of the PIN code
are further described in the section below.

