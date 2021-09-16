
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NAB7-ZDLN-ZHMR-VOCR-MCBV-ZELE-7RZD",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MCNA-DD5N-R4OJ-TXY7-JKHI-SUHY-NJ7D",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MD7M-K4BX-IKCM-Y2X4-H4SP-4AYS-I2TQ",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQUI3LVpETE4tWk
  hNUi1WT0NSLU1DQlYtWkVMRS03UlpEIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTA5LTE2VDE4OjEyOjM4WiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-09-16T18:12:38Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOQUI3LVpETE4tWkhNUi1WT0NSLU1DQlYtWkVMRS03UlpEIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~



