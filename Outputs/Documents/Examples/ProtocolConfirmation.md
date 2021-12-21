
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NDSA-RD52-JIV2-RVRU-BY4U-3SAN-HZWQ",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MBCG-IK56-CZ3R-SHDG-ARCZ-5CMX-LMSW",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MBCR-K34K-52QD-LFR4-2NUR-LAB5-4U5R",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORFNBLVJENTItSk
  lWMi1SVlJVLUJZNFUtM1NBTi1IWldRIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTEyLTIxVDEzOjI4OjI2WiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-12-21T13:28:26Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJORFNBLVJENTItSklWMi1SVlJVLUJZNFUtM1NBTi1IWldRIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~

