
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NDJX-VDBF-7LTL-EJ3L-BVQE-H7GG-6P2E",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MASC-PMET-3ZWF-W554-NKJV-7YLN-NLYK",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MBSL-BNHU-3RQN-L6VA-FTKE-5WPV-UC3H",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOREpYLVZEQkYtN0
  xUTC1FSjNMLUJWUUUtSDdHRy02UDJFIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTA5LTE2VDExOjQ2OjQ1WiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-09-16T11:46:45Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOREpYLVZEQkYtN0xUTC1FSjNMLUJWUUUtSDdHRy02UDJFIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~



