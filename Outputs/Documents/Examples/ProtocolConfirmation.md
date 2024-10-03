
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "Text":"start",
    "MessageId":"NC75-ZYCL-N3BL-FVYI-TFSW-FFJV-DZHW",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "Request":[{
        "EnvelopeId":"MDOD-KSMY-EZZE-TTOD-EHJB-JESO-A56I",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQzc1LVpZQ0wtTj
  NCTC1GVllJLVRGU1ctRkZKVi1EWkhXIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDI0LTEwLTAzVDE0OjU3OjA3WiJ9",
        "SequenceInfo":{
          "Index":7,
          "TreePosition":6209},
        "Received":"2024-10-03T14:57:07Z",
        "signatures":[{
            "alg":"ED448",
            "kid":"MDZB-PS54-WJES-ILJW-BCYW-FAE2-BUBS",
            "signature":"2HoAMBgTDEcUpsZfrKwhFviDMe0tUqQCrJNcSaMp
  SRMeS0xnnfE1DVcVMCNQ10qy_nGPSF36_vOAP6rfYqhVhKNFBDe_xRyG7jeFhujBW
  Hd1vJ8z7AXqq329wjMBHv4J67BhXBMAaH-afNN6Mfp12AQA"}
          ],
        "PayloadDigest":"1aT56ZrHwTX9fGMH9dskak74a30YFXzGWbOEfmPS
  VJsTRn9wa9Po5TsOBEf0piakhhoP6eIjd9dLdyNx5uHL5Q",
        "dig":"S512"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIlRleHQiOiAic3
  RhcnQiLAogICAgIk1lc3NhZ2VJZCI6ICJOQzc1LVpZQ0wtTjNCTC1GVllJLVRGU1c
  tRkZKVi1EWkhXIiwKICAgICJTZW5kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIs
  CiAgICAiUmVjaXBpZW50IjogImFsaWNlQGV4YW1wbGUuY29tIn19",
      {}
      ],
    "Accept":true,
    "MessageId":"MCF4-6SUJ-F74P-IUAC-PNAW-RL3C-5IIS",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com"}}
~~~~

