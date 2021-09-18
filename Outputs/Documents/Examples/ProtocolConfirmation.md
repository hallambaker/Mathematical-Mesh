
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NC5F-OQN2-OLFI-HL4E-LRUR-QCA5-KOHC",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MBMY-UJIJ-3PBK-CRMC-RG6E-FS77-AUZ6",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MBPW-Y67R-DCNB-2AI3-7JL6-F4ND-KNA6",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQzVGLU9RTjItT0
  xGSS1ITDRFLUxSVVItUUNBNS1LT0hDIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTA5LTE4VDE4OjQ2OjUzWiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-09-18T18:46:53Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOQzVGLU9RTjItT0xGSS1ITDRFLUxSVVItUUNBNS1LT0hDIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~

