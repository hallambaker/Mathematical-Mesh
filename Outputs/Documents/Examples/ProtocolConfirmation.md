
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NC5O-E23U-BF3F-VDVE-O3GU-WJB7-OWBW",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MCJC-ULB5-OTT6-HR23-H4BG-KNKG-GHQZ",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MCNH-IVIE-CUBG-ZRTX-TRVT-N2Q5-SP3U",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQzVPLUUyM1UtQk
  YzRi1WRFZFLU8zR1UtV0pCNy1PV0JXIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTA5LTE5VDE3OjUyOjM4WiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-09-19T17:52:38Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOQzVPLUUyM1UtQkYzRi1WRFZFLU8zR1UtV0pCNy1PV0JXIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~

