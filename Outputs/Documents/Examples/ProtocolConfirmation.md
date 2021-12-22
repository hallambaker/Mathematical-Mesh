
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NCQL-ONQW-YLJE-NZ5P-2ENL-K5YY-3I4K",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MCCD-FYHQ-JHAC-KCJZ-22PW-E3W2-E6WH",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MDTI-Q7TA-QT6J-OHML-O6AA-VXPH-Z3QL",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ1FMLU9OUVctWU
  xKRS1OWjVQLTJFTkwtSzVZWS0zSTRLIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTEyLTIyVDAxOjEzOjE0WiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-12-22T01:13:14Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOQ1FMLU9OUVctWUxKRS1OWjVQLTJFTkwtSzVZWS0zSTRLIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~

