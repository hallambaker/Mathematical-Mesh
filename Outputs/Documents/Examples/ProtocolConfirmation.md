
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NCMC-GNG4-64SP-OIG5-OM54-B2WF-QNCK",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MBWM-RFGS-JBIB-G5IN-T53Z-FRWW-LYJM",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MCDO-HQ5K-5DD2-KXRC-K2PV-7HNS-7DUM",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ01DLUdORzQtNj
  RTUC1PSUc1LU9NNTQtQjJXRi1RTkNLIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTA5LTE2VDE4OjMyOjQ5WiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-09-16T18:32:49Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOQ01DLUdORzQtNjRTUC1PSUc1LU9NNTQtQjJXRi1RTkNLIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~



