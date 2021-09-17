
The request payload specifies the data to be appended to the stores.


~~~~
{
  "TransactRequest":{
    "Updates":[{
        "Container":"MMM_Bookmark",
        "Envelopes":[[{
              "dig":"S512",
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJTaXRlcy4y
  IiwKICAiRXZlbnQiOiAiTmV3In0",
              "SequenceInfo":{
                "Index":1,
                "TreePosition":0}},
            "ewogICJDYXRhbG9nZWRCb29rbWFyayI6IHsKICAgICJVcmkiOiAi
  aHR0cDovL3d3dy5leGFtcGxlLm5ldCIsCiAgICAiVGl0bGUiOiAic2l0ZTIiLAogI
  CAgIlBhdGgiOiAiU2l0ZXMuMiJ9fQ",
            {
              "PayloadDigest":"gtpamSravs9YkD3Wi6-rIFqFOINwLFj8Q2
  eGpMjmbyP-_TRCgRs9Hqpo3bJPhoRSgUmfIUsQTDNeiT414W56eA",
              "TreeDigest":"TpXg14cDEx_-1Qe-h1qiryihslO0MrUCLW0L7
  wvq-YLCEWZfAIrp9FmBwNE0se8UN1nFY4h1aqXbN3yBuKfg9w"}
            ]
          ]}
      ]}}
~~~~


The response reports successful completion:


~~~~
{
  "TransactResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


