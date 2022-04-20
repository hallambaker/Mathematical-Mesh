
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NDBB-CHFG-OWNI-2WWK-RJI2-KMF7-6AW7",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MBO5-GGWR-XOSQ-M6AO-WRP7-CJWT-V6LN",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MAWU-5FMM-ZN6O-FXE5-TVC4-LO6I-RJ4D",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOREJCLUNIRkctT1
  dOSS0yV1dLLVJKSTItS01GNy02QVc3IiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIyLTA0LTIwVDE2OjE3OjM5WiJ9",
        "SequenceInfo":{
          "Index":7,
          "TreePosition":6201},
        "Received":"2022-04-20T16:17:39Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOREJCLUNIRkctT1dOSS0yV1dLLVJKSTItS01GNy02QVc3IiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~

