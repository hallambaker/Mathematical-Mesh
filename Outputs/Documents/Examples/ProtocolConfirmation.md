
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "Text":"start",
    "MessageId":"NDQ7-UANN-QSPT-CRYP-B4YY-4PNG-N2Z7",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "Request":[{
        "EnvelopeId":"MA67-3RLI-BFGR-X64H-SNKH-GI2S-PQ4R",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORFE3LVVBTk4tUV
  NQVC1DUllQLUI0WVktNFBORy1OMlo3IiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDI0LTEwLTA0VDAxOjA0OjM0WiJ9",
        "SequenceInfo":{
          "Index":7,
          "TreePosition":6209},
        "Received":"2024-10-04T01:04:34Z",
        "signatures":[{
            "alg":"ED448",
            "kid":"MCQ6-O35U-PUNH-Y65B-HNRW-YCP2-U35V",
            "signature":"aVJmnEFqPRqGzATsgtBNnTYkYok9CV731jZGtmyk
  qU0AqlAbkr5rt7KiwE-duIn4ijsB_xQ9K0EAWRj2kJQ3HQWCONxrsbO1Uilnha_ZJ
  ojJjqbwsC7SpfdNRD8wn_DAokJHS9CdXzsxPfd5OH5_JD0A"}
          ],
        "PayloadDigest":"4xuev8YTup_R6DXmNxotr4ksCXByR_A-5xPto05T
  XmCF1R1q9AjbFdOi0p_524YzGKzz6Zs1HOpYqRTLZabnuw",
        "dig":"S512"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIlRleHQiOiAic3
  RhcnQiLAogICAgIk1lc3NhZ2VJZCI6ICJORFE3LVVBTk4tUVNQVC1DUllQLUI0WVk
  tNFBORy1OMlo3IiwKICAgICJTZW5kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIs
  CiAgICAiUmVjaXBpZW50IjogImFsaWNlQGV4YW1wbGUuY29tIn19",
      {}
      ],
    "Accept":true,
    "MessageId":"MAB6-RYAQ-MHZJ-25S7-34ZY-JRFR-OI6P",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com"}}
~~~~

