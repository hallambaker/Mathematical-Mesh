
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NDAD-KLJY-C5JO-JGXL-VUWG-Y6PP-PSFJ",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MCT4-SVZ2-BL5Y-DR5B-TF4S-WIGH-CJTM",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MDVA-HSIH-UJBT-PEVO-GZNQ-JF3O-YHTM",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOREFELUtMSlktQz
  VKTy1KR1hMLVZVV0ctWTZQUC1QU0ZKIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIxLTEwLTI1VDE1OjQ4OjU3WiJ9",
        "SequenceInfo":{
          "Index":4,
          "TreePosition":6201},
        "Received":"2021-10-25T15:48:57Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOREFELUtMSlktQzVKTy1KR1hMLVZVV0ctWTZQUC1QU0ZKIiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~

