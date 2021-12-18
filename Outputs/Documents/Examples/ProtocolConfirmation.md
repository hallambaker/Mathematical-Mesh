
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NDLR-BUDO-M7WU-JBTA-W4G2-AAOU-4NJB",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MATH-MOWW-BSXS-NM2E-EP7K-QWJ2-YNG5",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MCLR-4G7H-RKAE-TSVS-2YFY-QLC5-DBDY",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORExSLUJVRE8tTT
  dXVS1KQlRBLVc0RzItQUFPVS00TkpCIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTEyLTE4VDAxOjU3OjE4WiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-12-18T01:57:18Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJORExSLUJVRE8tTTdXVS1KQlRBLVc0RzItQUFPVS00TkpCIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~

