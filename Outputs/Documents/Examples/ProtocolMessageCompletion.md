
After using the PIN code to authenticate connection of a device in the previous 
example, the corresponding MessagePin is marked as having been used by appending 
a completion message to the Local spool.

~~~~
{
  "MessageComplete":{
    "MessageId":"ND7I-HHYX-MWLF-CZTS-TRKT-GEHA-D4DY",
    "References":[{
        "MessageId":"AAVE-RXUN-6AYB-FMU3-3BZA-VFVP-SARG",
        "ResponseId":"MCTW-TOSU-FRSX-2UWI-BHL6-DLHC-BF4L",
        "Relationship":"Closed"}
      ]}}
~~~~

