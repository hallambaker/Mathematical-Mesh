
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NCM5-RFA7-MCBH-UTRQ-2DPH-RIUN-DZEE",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MDRC-MK3S-7RYC-JEHG-CAWE-2N7E-JKWS",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MANZ-CZCQ-BZU4-FT5Q-ELDK-SPNE-S7SN",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ001LVJGQTctTU
  NCSC1VVFJRLTJEUEgtUklVTi1EWkVFIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTEyLTE5VDE5OjIxOjEyWiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-12-19T19:21:12Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOQ001LVJGQTctTUNCSC1VVFJRLTJEUEgtUklVTi1EWkVFIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~

