
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NAFH-QPYP-5OAV-WXPX-RCKO-KIKS-RYJG",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MBQO-USUV-X27A-CFLD-RXKE-LZMD-GT7T",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MACN-R7IW-JPYU-XLMI-6KPN-5I3W-3WB4",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQUZILVFQWVAtNU
  9BVi1XWFBYLVJDS08tS0lLUy1SWUpHIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTA5LTIwVDE4OjE2OjE0WiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-09-20T18:16:15Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOQUZILVFQWVAtNU9BVi1XWFBYLVJDS08tS0lLUy1SWUpHIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~

