
After using the PIN code to authenticate connection of a device in the previous 
example, the corresponding MessagePin is marked as having been used by appending 
a completion message to the Local spool.

~~~~
{
  "MessageComplete":{
    "MessageId":"NCKM-B7D2-LDEI-I54Z-EMNK-MHPX-KCOJ",
    "References":[{
        "MessageId":"ABBQ-7RHN-DZ2H-53DR-2N6Q-44RF-DS4W",
        "ResponseId":"MBBH-3P4B-C4K5-LVUR-D2AS-IHPO-ETVC",
        "Relationship":"Closed"}
      ]}}
~~~~

