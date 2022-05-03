
The request payload specifies the data to be appended to the stores.


~~~~
{
  "TransactRequest":{
    "Updates":[{
        "Container":"MMM_Bookmark",
        "Envelopes":[[{
              "PayloadDigest":"P47V2OClDAPAUG_PcRZFuTGsaYuYtLMSuA
  bUF6sSjyE9TUDZ_WqoDXNucXMhz_e9RdIKwpbK7PWWAzKPcv0M1g",
              "TreeDigest":"VQ1o-pAgym3qdDDNaRr6qMPYi3EVx5If9IBgi
  YzatEkqBGkKLMxeQ5MEnhltC3zOlPbxIih3Qc73HXCZ6Hxvqw",
              "dig":"S512",
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ01QLVdP
  QzUtRkxQVC1YV0lJLTU2RFctNVhMQi1VQ0tUIiwKICAiRXZlbnQiOiAiTmV3In0",
              "SequenceInfo":{
                "Index":1,
                "TreePosition":0}},
            "ewogICJDYXRhbG9nZWRCb29rbWFyayI6IHsKICAgICJVaWQiOiAi
  TkNNUC1XT0M1LUZMUFQtWFdJSS01NkRXLTVYTEItVUNLVCIsCiAgICAiVXJpIjogI
  lNpdGVzLjIiLAogICAgIlRpdGxlIjogImh0dHA6Ly93d3cuZXhhbXBsZS5uZXQifX
  0"
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




