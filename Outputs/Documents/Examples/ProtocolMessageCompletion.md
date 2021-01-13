
After using the PIN code to authenticate connection of a device in the previous 
example, the corresponding MessagePin is marked as having been used by appending 
a completion message to the Local spool.

~~~~
{
  "MessageComplete":{
    "MessageId":"NCAI-WEPR-GYOU-BSFM-5U3V-ASJN-RHPC",
    "References":[{
        "MessageId":"AAAU-6HVM-7AA6-TNEG-PFUS-IXZ3-BMYL",
        "ResponseId":"MADI-J7SC-HSPL-UREO-Z5NC-CWK6-KZIB",
        "Relationship":"Closed"}
      ]}}
~~~~

