
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
              "PayloadDigest":"l4niCi9e29QsI5MDtkR4n0M4tw9CUX0Hiz
  uIlWAiKODiXXun3cToxrqblc52SN4kT_n3Uk6JcliJle4pW1lrSw",
              "enc":"A256CBC",
              "dig":"S512",
              "Salt":"i4cDdBcvG2JSpFaJTwuShw",
              "recipients":[{
                  "kid":"MB4N-HBTR-HOGS-VS4S-S4RI-G7PU-BDAO",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"qI_BooPqFn5PO74U2ei-KCNGDvJsbUQsb
  FYvEdunlmKbPQ8Vv0TUiyGvprKXRF3u17wrG_tnZs2A"}},
                  "wmk":"Ms7W6pSx3_a6T-cJAb-0uggX5_rHJ-p1_lZ_i2_W
  XbP48F55FfkXcA"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIiwKICAiRmlyc3QiOiAxLAogI
  CJQcmV2aW91cyI6IDF9",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":716},
              "Received":"2021-12-19T02:15:49Z"},
            "AextRSzFBtLzjT0eK1GUwfGIV2FMC8aitUwLitQ98zfrZNWUbk3h
  nHI6V601VorRRpSB4s-6-oR68JQgUG21Gg9n2GH3QKOBkzTlerhJDib_oxBB8sYQZ
  A6C5k9WCf8Rnvi_-zLpb165PI3BguRDjPSV_GcE5G98UCQo-BWDibY",
            {}
            ]
          ]}
      ]}}
~~~~


Future: The current implementation of the download operation is limited by the
capabilities of the HTTP binding of the RUD transport. A future binding allowing 
operations that consist of a single request followed by a sequence of responses 
will allow much greater flexibility.

