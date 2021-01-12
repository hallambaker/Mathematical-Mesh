
The console generates a confirmation request message:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NBQW-47EI-Q2NL-N7UY-BUSA-47RX-AWVG",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns a ResponseConfirmation confirmation
containing both the request and the response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MDJE-DO7A-RBM7-3HSM-7VQA-XX65-HGO2",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MBSA-WCDX-YHZX-7DLU-H3X3-QJHA-XTV2",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQlFXLTQ3RUktUT
  JOTC1ON1VZLUJVU0EtNDdSWC1BV1ZHIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTAxLTEyVDE4OjQyOjE2WiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6222},
        "Received":"2021-01-12T18:42:16Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOQlFXLTQ3RUktUTJOTC1ON1VZLUJVU0EtNDdSWC1BV1ZHIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~

