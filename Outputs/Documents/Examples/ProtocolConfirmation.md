
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NCPO-3N4E-UOMN-TIPQ-UWCJ-MSUB-345F",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MBUB-AIUZ-NWQU-UYDM-CBWB-CKCV-IAKS",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MDSV-QO4B-LMKN-ZGFY-ZFQ4-VTWS-RZGD",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ1BPLTNONEUtVU
  9NTi1USVBRLVVXQ0otTVNVQi0zNDVGIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTA0LTA5VDE4OjEzOjExWiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-04-09T18:13:11Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOQ1BPLTNONEUtVU9NTi1USVBRLVVXQ0otTVNVQi0zNDVGIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~



