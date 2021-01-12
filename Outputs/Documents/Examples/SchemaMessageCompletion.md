
Having processed a message, a completion message is added to the spool so that other devices 
can see that it has been read.

For example, when Alice's administration device uses the PIN registered above to 
authenticate a device connection request, a completion message is added to Alice's 
inbound spool so that the PIN cannot be reused to authenticate a second device:

~~~~
{
  "MessageComplete":{
    "MessageId":"NDO7-B57B-HQG2-SMVO-IFYZ-OEUI-FAWI",
    "References":[{
        "MessageId":"ABM5-DVCA-KOAF-YPHM-PFWG-LNBI-MLGP",
        "ResponseId":"MC4K-66A3-WYGU-RJW5-G7OP-RVUY-NKBD",
        "Relationship":"Closed"}
      ]}}
~~~~



