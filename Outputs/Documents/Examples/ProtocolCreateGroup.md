
The request payload:


~~~~
{
  "TransactRequest":{
    "Updates":[{
        "Container":"MMM_Member",
        "Envelopes":[[{
              "dig":"S512",
              "policy":{
                "enc":"none",
                "dig":"none",
                "Sealed":true},
              "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24v
  bW1tLWNhdGFsb2cifQ",
              "SequenceInfo":{
                "DataEncoding":"JSON",
                "ContainerType":"Merkle",
                "Index":0}},
            "",
            {
              "PayloadDigest":"z4PhNX7vuL3xVChQ1m2AB9Yg5AULVxXcg_
  SpIdNs6c5H0NE8XYXysP-DGNKHfuwvY7kxvUdBeoGlODJ6-SfaPg",
              "TreeDigest":"FEHy24Y6cLModDXWH31kVc2a3TdhjXPooKHpL
  Ab2JbsO1YQnJolmowXAYHhkOGY0kg3jrKNTjds0myf4Dw1sdg"}
            ]
          ]},
      {
        "Container":"MMM_Access",
        "Envelopes":[[{
              "dig":"S512",
              "policy":{
                "enc":"none",
                "dig":"none",
                "Sealed":true},
              "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24v
  bW1tLWNhdGFsb2cifQ",
              "SequenceInfo":{
                "DataEncoding":"JSON",
                "ContainerType":"Merkle",
                "Index":0}},
            "",
            {
              "PayloadDigest":"z4PhNX7vuL3xVChQ1m2AB9Yg5AULVxXcg_
  SpIdNs6c5H0NE8XYXysP-DGNKHfuwvY7kxvUdBeoGlODJ6-SfaPg",
              "TreeDigest":"FEHy24Y6cLModDXWH31kVc2a3TdhjXPooKHpL
  Ab2JbsO1YQnJolmowXAYHhkOGY0kg3jrKNTjds0myf4Dw1sdg"}
            ]
          ]},
      {
        "Container":"MMM_Publication",
        "Envelopes":[[{
              "dig":"S512",
              "policy":{
                "enc":"none",
                "dig":"none",
                "Sealed":true},
              "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24v
  bW1tLWNhdGFsb2cifQ",
              "SequenceInfo":{
                "DataEncoding":"JSON",
                "ContainerType":"Merkle",
                "Index":0}},
            "",
            {
              "PayloadDigest":"z4PhNX7vuL3xVChQ1m2AB9Yg5AULVxXcg_
  SpIdNs6c5H0NE8XYXysP-DGNKHfuwvY7kxvUdBeoGlODJ6-SfaPg",
              "TreeDigest":"FEHy24Y6cLModDXWH31kVc2a3TdhjXPooKHpL
  Ab2JbsO1YQnJolmowXAYHhkOGY0kg3jrKNTjds0myf4Dw1sdg"}
            ]
          ]}
      ]}}
~~~~


The response payload:


~~~~
{
  "TransactResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


