
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NBW3-QGBQ-U26Q-ECMH-3BAD-BYI5-7J4J",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MABU-Y3OX-IZRP-XCUQ-C5NY-POKX-HXVT",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MAVA-YC46-S4IK-DNG4-ZNW7-J6RT-ANGC",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQlczLVFHQlEtVT
  I2US1FQ01ILTNCQUQtQllJNS03SjRKIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTEyLTE5VDAyOjE1OjU4WiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-12-19T02:15:58Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOQlczLVFHQlEtVTI2US1FQ01ILTNCQUQtQllJNS03SjRKIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~

