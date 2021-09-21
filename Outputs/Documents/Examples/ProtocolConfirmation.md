
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NDHX-5YUA-2EG6-MBOH-CFA3-7ZZS-G7SI",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MARN-UKW4-BU7W-OCCW-Z23O-TYLX-GC36",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MBSA-DAEF-DJP6-PYDV-RYVK-QNEF-BY32",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOREhYLTVZVUEtMk
  VHNi1NQk9ILUNGQTMtN1paUy1HN1NJIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTA5LTIxVDAwOjU2OjAxWiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-09-21T00:56:01Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOREhYLTVZVUEtMkVHNi1NQk9ILUNGQTMtN1paUy1HN1NJIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~

