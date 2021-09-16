>>>> Unfinished ProtocolMessageCompletion



After using the PIN code to authenticate connection of a device in the previous 
example, the corresponding MessagePin is marked as having been used by appending 
a completion message to the Local spool.

~~~~
{
  "MessageComplete":{
    "MessageId":"NAUH-7TRM-HFFO-ZKPI-67Y5-FBN2-4NC4",
    "References":[{
        "MessageId":"AAKU-OCUD-R4I3-NU32-WDXX-FKWU-CMFZ",
        "ResponseId":"MAWB-SA72-OAQ7-7JYW-4FJT-YEGB-5N2O",
        "Relationship":"Closed"}
      ]}}
~~~~

