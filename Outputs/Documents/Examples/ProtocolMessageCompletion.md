>>>> Unfinished ProtocolMessageCompletion



After using the PIN code to authenticate connection of a device in the previous 
example, the corresponding MessagePin is marked as having been used by appending 
a completion message to the Local spool.

~~~~
{
  "MessageComplete":{
    "MessageId":"NCYG-PTUQ-KHNR-FNFP-BO6P-AIP7-XQY2",
    "References":[{
        "MessageId":"ABTC-BSSG-W6MM-FTDF-DDTE-OQKD-GXL4",
        "ResponseId":"MAZZ-XSRE-5AD6-JA7N-S26F-SRBZ-MINI",
        "Relationship":"Closed"}
      ]}}
~~~~

