
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"ND6A-CEXE-CXZU-ECGN-FELV-6GWO-LH64",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MASB-GM6Z-YQTX-HUHG-DVZT-N3CF-5XQX",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MDV7-4MW6-EJCI-64VG-T4SE-JXSL-YUH4",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORDZBLUNFWEUtQ1
  haVS1FQ0dOLUZFTFYtNkdXTy1MSDY0IiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTA5LTE2VDEzOjUzOjI0WiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-09-16T13:53:24Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJORDZBLUNFWEUtQ1haVS1FQ0dOLUZFTFYtNkdXTy1MSDY0IiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~



