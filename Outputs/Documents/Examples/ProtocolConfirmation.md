
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NDI6-772L-UUBU-RIFV-S5GM-3B3J-4LFV",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MCMX-6JO6-PCIQ-MVHU-2YW5-D4GM-QE35",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MCKT-ZJE6-OZQU-NYUU-H3T7-WESB-RTUW",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOREk2LTc3MkwtVV
  VCVS1SSUZWLVM1R00tM0IzSi00TEZWIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTEyLTIwVDE0OjAwOjI1WiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-12-20T14:00:25Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOREk2LTc3MkwtVVVCVS1SSUZWLVM1R00tM0IzSi00TEZWIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~

