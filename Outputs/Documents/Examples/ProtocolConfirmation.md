
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NA4W-P4SA-YCM2-VPZO-NGVS-MKNS-S7VM",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MCY6-QQ4D-HNVB-WJ27-IQ5R-T6VH-2TCP",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MDVV-ESFG-IXKT-BAV4-M3U6-LS6B-ZQPV",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQTRXLVA0U0EtWU
  NNMi1WUFpPLU5HVlMtTUtOUy1TN1ZNIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTA5LTE3VDEzOjA4OjQyWiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-09-17T13:08:42Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOQTRXLVA0U0EtWUNNMi1WUFpPLU5HVlMtTUtOUy1TN1ZNIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~



