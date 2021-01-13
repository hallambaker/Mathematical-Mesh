
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NCHB-PAFY-23JU-UWSK-Q4NK-LEKY-MFZX",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MBX5-PSU2-MPUA-IRVR-WIJL-CS4Q-5YUS",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MCDL-YDFD-GEC4-MJZO-FONM-AC2D-HNM7",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ0hCLVBBRlktMj
  NKVS1VV1NLLVE0TkstTEVLWS1NRlpYIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTAxLTEzVDE2OjM4OjI3WiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6222},
        "Received":"2021-01-13T16:38:27Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOQ0hCLVBBRlktMjNKVS1VV1NLLVE0TkstTEVLWS1NRlpYIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~



