
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "MessageId":"NAJ7-2JAE-5VND-GLM3-YYHF-FQX2-TCF7",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com",
    "Text":"start"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "MessageId":"MCYE-BSU4-GBBY-O5J4-CCVD-ZHYF-VKGH",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com",
    "Request":[{
        "EnvelopeId":"MD5E-FTHA-N7K2-HEBG-S5U6-3CKT-NIRE",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQUo3LTJKQUUtNV
  ZORC1HTE0zLVlZSEYtRlFYMi1UQ0Y3IiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIyLTA1LTAzVDE2OjQ3OjIzWiJ9",
        "SequenceInfo":{
          "Index":7,
          "TreePosition":6201},
        "Received":"2022-05-03T16:47:23Z"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIk1lc3NhZ2VJZC
  I6ICJOQUo3LTJKQUUtNVZORC1HTE0zLVlZSEYtRlFYMi1UQ0Y3IiwKICAgICJTZW5
  kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogImFs
  aWNlQGV4YW1wbGUuY29tIiwKICAgICJUZXh0IjogInN0YXJ0In19",
      {}
      ],
    "Accept":true}}
~~~~

