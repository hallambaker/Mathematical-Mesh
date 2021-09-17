
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NAXE-WSLA-JWEX-RTRT-HZM4-M4KP-TOBO",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MAZQ-G772-RPNK-76AS-37TP-FFCL-ELFW",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MCAE-HX7J-53J3-VZSQ-6GGA-GARH-YV5Z",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQVhFLVdTTEEtSl
  dFWC1SVFJULUhaTTQtTTRLUC1UT0JPIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTA5LTE2VDIzOjQ4OjE1WiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-09-16T23:48:15Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOQVhFLVdTTEEtSldFWC1SVFJULUhaTTQtTTRLUC1UT0JPIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~



