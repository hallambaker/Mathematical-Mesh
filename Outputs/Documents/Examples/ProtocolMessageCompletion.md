>>>> Unfinished ProtocolMessageCompletion



After using the PIN code to authenticate connection of a device in the previous 
example, the corresponding MessagePin is marked as having been used by appending 
a completion message to the Local spool.

~~~~
{
  "MessageComplete":{
    "MessageId":"NAWW-634V-NJ4F-TULE-O2PH-TDOW-MZF5",
    "References":[{
        "MessageId":"ACRP-ZONR-F3S5-JHFV-I5LK-QBDO-3PJT",
        "ResponseId":"MD66-RSEY-3BOY-6FPY-5FX2-VTOX-WIDR",
        "Relationship":"Closed"}
      ]}}
~~~~

