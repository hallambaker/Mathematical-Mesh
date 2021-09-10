
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NBEC-S26E-KFLR-WMRH-67RO-XEQI-3EGC",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MADI-KSCW-HBSV-UVSX-GYDY-3XZP-CCQP",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MD7A-HE2G-YPVC-HPKG-RTSV-M5Z6-7ZWX",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQkVDLVMyNkUtS0
  ZMUi1XTVJILTY3Uk8tWEVRSS0zRUdDIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTA5LTEwVDE3OjIyOjEwWiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-09-10T17:22:10Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOQkVDLVMyNkUtS0ZMUi1XTVJILTY3Uk8tWEVRSS0zRUdDIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~



