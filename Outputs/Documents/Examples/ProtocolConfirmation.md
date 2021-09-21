
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NBQB-3S4U-QIJU-A2YB-HDPL-SGGM-CPKY",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MD7Q-AVXU-6XC7-WXCS-MWYD-IJ55-BUFB",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MBIH-NNZB-MCZA-LWIW-4S3A-HOE5-IAUE",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQlFCLTNTNFUtUU
  lKVS1BMllCLUhEUEwtU0dHTS1DUEtZIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTA5LTIxVDAwOjU4OjUwWiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-09-21T00:58:50Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOQlFCLTNTNFUtUUlKVS1BMllCLUhEUEwtU0dHTS1DUEtZIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~

