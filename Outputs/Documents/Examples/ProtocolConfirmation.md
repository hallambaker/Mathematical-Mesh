
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NBLG-QNFG-5NRO-K2PT-JIBB-4AVX-X2L6",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MDKO-2LBI-LVRI-6F7K-FSQC-NYLV-E76L",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MAHP-YGCF-WQAV-CSRH-Y6GA-AAP3-VKLY",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQkxHLVFORkctNU
  5STy1LMlBULUpJQkItNEFWWC1YMkw2IiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTA4LTA1VDE2OjM3OjM4WiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-08-05T16:37:38Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOQkxHLVFORkctNU5STy1LMlBULUpJQkItNEFWWC1YMkw2IiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~



