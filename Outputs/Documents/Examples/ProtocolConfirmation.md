
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "Text":"start",
    "MessageId":"NBGK-6BGU-5C5H-4WUR-OGDF-NZTH-ZLCW",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "Request":[{
        "EnvelopeId":"MBFM-RPD5-MYYX-UK3M-2SCV-GUYR-J446",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQkdLLTZCR1UtNU
  M1SC00V1VSLU9HREYtTlpUSC1aTENXIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIyLTEwLTE4VDEyOjQ0OjA1WiJ9",
        "SequenceInfo":{
          "Index":7,
          "TreePosition":6201},
        "Received":"2022-10-18T12:44:05Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIlRleHQiOiAic3
  RhcnQiLAogICAgIk1lc3NhZ2VJZCI6ICJOQkdLLTZCR1UtNUM1SC00V1VSLU9HREY
  tTlpUSC1aTENXIiwKICAgICJTZW5kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIs
  CiAgICAiUmVjaXBpZW50IjogImFsaWNlQGV4YW1wbGUuY29tIn19",
      {}
      ],
    "Accept":true,
    "MessageId":"MA6X-RZBB-RBT7-EWC2-ZPDV-ZUJI-3BRE",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com"}}
~~~~

