
The previous status operation has reported that a new envelope has been added to
the credential store. The device requests this data from the service:


~~~~
{
  "DownloadRequest":{
    "Select":[{
        "Container":"MMM_Credential",
        "IndexMin":3,
        "IndexMax":4}
      ]}}
~~~~


The response contains the requested envelope:


~~~~
{
  "DownloadResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "Updates":[{
        "Container":"MMM_Credential",
        "Envelopes":[[{
              "PayloadDigest":"2ynRDfby6QimqjU6zfqOIm01piIzOCmc6i
  CoZUte8T3cBnxaiTnNQs8sUIYyjqQjganGMJwiDx1a97_PpsJ8pw",
              "enc":"A256CBC",
              "dig":"S512",
              "Salt":"cwC8-mYNX6hS1KLwBnsx0w",
              "recipients":[{
                  "kid":"MAEB-BSY4-54WA-W2YA-PSLD-3XP4-MQBB",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"Utn-HSpgVjds72JezzH0qToidbkaozLXv
  LwGRosVRNVgSGjMwkDYAXWkyIdHfGsDKd1Xo1NbSLmA"}},
                  "wmk":"W3tet1huHF_xbDH-D-Lcz2c6svMzeH9bC9zOkbxO
  vNhnfGLN44d1ow"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIiwKICAiRmlyc3QiOiAxLAogI
  CJQcmV2aW91cyI6IDF9",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":716},
              "Received":"2021-09-21T00:58:40Z"},
            "guoK3Rikj2lgJzhwh6v8YA-X52JXluShSkgv9IfSKh9hay_6YKfK
  S1CSx8QEiy_Q50HQMJfMjl3_7b4nxSwV79OsAH7pLSFe59C6VdIqNV7oBekgizFVj
  FRO8dEZU_kxq0JjCFiPQ8YwH_EiSd8-yWGq2TXc_XG2yTeDPP3M-6U",
            {}
            ]
          ]}
      ]}}
~~~~


Future: The current implementation of the download operation is limited by the
capabilities of the HTTP binding of the RUD transport. A future binding allowing 
operations that consist of a single request followed by a sequence of responses 
will allow much greater flexibility.

