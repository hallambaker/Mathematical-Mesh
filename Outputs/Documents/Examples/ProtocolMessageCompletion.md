
After using the PIN code to authenticate connection of a device in the previous 
example, the corresponding MessagePin is marked as having been used by appending 
a completion message to the Local spool.

~~~~
{
  "MessageComplete":{
    "MessageId":"NBEX-JZW2-2VZY-HMMD-2MSF-WVMG-3HPO",
    "References":[{
        "MessageId":"AB6H-76PI-2QPS-ER5S-HILC-JCNU-7F4H",
        "ResponseId":"MCQ2-G76S-ZKKX-GFV6-HWHH-B5N7-H6OQ",
        "Relationship":"Closed"}
      ]}}
~~~~

