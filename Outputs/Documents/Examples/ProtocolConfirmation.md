
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "Text":"start",
    "MessageId":"NAZG-5KBV-D32X-O24L-XTYS-26GV-FC6Z",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "Request":[{
        "EnvelopeId":"MCDS-ZYU5-TXDG-FAHW-BAVA-VFRM-XOXD",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQVpHLTVLQlYtRD
  MyWC1PMjRMLVhUWVMtMjZHVi1GQzZaIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDI0LTEwLTE0VDEzOjEwOjUyWiJ9",
        "SequenceInfo":{
          "Index":7,
          "TreePosition":6211},
        "Received":"2024-10-14T13:10:52Z",
        "signatures":[{
            "alg":"ED448",
            "kid":"MDMO-SHNV-SDLR-GGIH-W2MA-QTNA-OQUG",
            "signature":"4oOI79pmsbJKxPfdZZgm0h60ZN9Ec5dSXtyBtLHk
  4tKfxRMy-s4JlBO1SZ4xsRzkPkjh_bozL2IAiil1f6F8Kva5UMDMwOs1E363x5zfs
  4ttnMz9KjHD_LSNiG5S7iwMh4XF6-GB-s-ge1a7Cf4TqjwA"}
          ],
        "PayloadDigest":"5oqE8QWpLfTmxhs4GpDS6_Od2dd8PcdDMfI9bgoN
  NrYNnZaNwOI_oloD2i2k65_ENqyBTdM8TLlkc-TtywwwqQ",
        "dig":"S512"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIlRleHQiOiAic3
  RhcnQiLAogICAgIk1lc3NhZ2VJZCI6ICJOQVpHLTVLQlYtRDMyWC1PMjRMLVhUWVM
  tMjZHVi1GQzZaIiwKICAgICJTZW5kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIs
  CiAgICAiUmVjaXBpZW50IjogImFsaWNlQGV4YW1wbGUuY29tIn19",
      {}
      ],
    "Accept":true,
    "MessageId":"MDRR-IKIO-BXGJ-Y2QA-ZLJI-YDA2-HC4I",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com"}}
~~~~

