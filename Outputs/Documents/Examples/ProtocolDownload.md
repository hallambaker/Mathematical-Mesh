
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
              "PayloadDigest":"sy1ssbIvs3DVwUObsWIpbtGquWaoEYtCqY
  1smobL0T5ydXU29v8ixwUGCDO_pWxh3rWS5yXbOK4rhufAQfMq7w",
              "enc":"A256CBC",
              "dig":"S512",
              "Salt":"YnQw4J41v4oCWz8krGmFNQ",
              "recipients":[{
                  "kid":"MDQY-J72A-VPAO-WDOD-GYY7-4ZZ5-PLVL",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"_dHVp-Pmr9wgX8Br8zwPEyTT4puZ-N2Z2
  cRql0WuuTAXm8Antqfg0dHit2iy5tD9C_ji4FcuoPcA"}},
                  "wmk":"Il9yeV5COdhTo6ULAbHU084HB3qPqVIgyHIexstl
  Dk7H1gWixmkj9A"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIiwKICAiRmlyc3QiOiAxLAogI
  CJQcmV2aW91cyI6IDF9",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":716},
              "Received":"2021-09-20T18:15:28Z"},
            "TprbdZruvdRXXzOAP_SAxvADHwrULXW_XrLtrvd_vvrbRAeXXmus
  fRrL8sIZod3f4uXNZPUbwDAiiJTeT1z0vKzoMYNsJ7gkgbdBx5wvKS_APbzHnfBAd
  qdKZJDPZCf9NIWrjPs7uaMxCmHajt2o2jgNbbmE17Ewua_YX1hsxHY",
            {}
            ]
          ]}
      ]}}
~~~~


Future: The current implementation of the download operation is limited by the
capabilities of the HTTP binding of the RUD transport. A future binding allowing 
operations that consist of a single request followed by a sequence of responses 
will allow much greater flexibility.

