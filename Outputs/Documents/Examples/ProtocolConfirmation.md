
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NDW5-TTEF-B4JG-BZQN-FNPA-CQRM-3AEE",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MASC-XJTW-W6W3-SCZM-M27S-APLS-I46I",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MB5O-RPD7-T7WG-7W4R-NBDV-L4OM-GSEN",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORFc1LVRURUYtQj
  RKRy1CWlFOLUZOUEEtQ1FSTS0zQUVFIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTEyLTA5VDE2OjQ2OjEwWiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-12-09T16:46:10Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJORFc1LVRURUYtQjRKRy1CWlFOLUZOUEEtQ1FSTS0zQUVFIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~

