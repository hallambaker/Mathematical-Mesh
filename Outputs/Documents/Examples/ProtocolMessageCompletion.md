
After using the PIN code to authenticate connection of a device in the previous 
example, the corresponding MessagePin is marked as having been used by appending 
a completion message to the Local spool.


~~~~
{
  "MessageComplete":{
    "MessageId":"NCGB-6PXA-YG6T-GSC3-37HF-5QG2-SC43",
    "References":[{
        "MessageId":"AAPO-PUCK-AIYZ-FSOX-OBI5-YZZB-RVT2",
        "ResponseId":"MDT3-TM62-G3XO-ESYO-WQZX-IR2B-YNHW",
        "Relationship":"Closed"}
      ]}}
~~~~

