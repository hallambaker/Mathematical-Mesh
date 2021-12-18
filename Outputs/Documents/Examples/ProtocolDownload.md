
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
              "PayloadDigest":"8_yga72XOTSmNEXY-0Mc32pdg8x1Wplb1b
  TptLks13GaNSPAAYCcVx1Ze6EQZoZycY2n17exkh85IfYTpap40g",
              "enc":"A256CBC",
              "dig":"S512",
              "Salt":"DJ6lIsq7e3tMVyFu4E8ZPg",
              "recipients":[{
                  "kid":"MDF6-C24X-IQCB-YNPQ-EATW-2KKU-MNNS",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"bSf2EEWWt_Zhekzo34pgQaUNZoj0ZjrOF
  gmAg7Yn6RGuPfuGb4LMIULp4NxbvJ5A_jbe0Me0D1eA"}},
                  "wmk":"ARkNN-OtKWMjMM-VEwxmA2rufELUp7hgGb_aQOUu
  jIOQYCCzhJGWHQ"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIiwKICAiRmlyc3QiOiAxLAogI
  CJQcmV2aW91cyI6IDF9",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":716},
              "Received":"2021-12-18T01:57:07Z"},
            "x4759XBSz1hP6XxMRsn_MBSx-07kB40zREZillD-LeLVdRLAvtVW
  JQO2ys9ClXZ-GYPbH1kJIM4ud3GUOhi3XW7mIimo_I__JPKV5sK0IBKt1GIo9iabT
  fBCVzcsgTd87MvTKP_RpJ7cDfkjEEjEB_zecrNQs7otNsPCghtEpqE",
            {}
            ]
          ]}
      ]}}
~~~~


Future: The current implementation of the download operation is limited by the
capabilities of the HTTP binding of the RUD transport. A future binding allowing 
operations that consist of a single request followed by a sequence of responses 
will allow much greater flexibility.

