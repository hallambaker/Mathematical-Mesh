
After using the PIN code to authenticate connection of a device in the previous 
example, the corresponding MessagePin is marked as having been used by appending 
a completion message to the Local spool.


~~~~
{
  "MessageComplete":{
    "MessageId":"NCCS-4234-KMHU-FU46-HYED-ZCL5-WGHX",
    "References":[{
        "MessageId":"ADJI-4VCD-MVVG-NUXG-QOH6-O5TJ-LO3G",
        "ResponseId":"MDSE-WBAJ-7OCH-JGKV-CB6D-J5C2-UD7R",
        "Relationship":"Closed"}
      ]}}
~~~~

