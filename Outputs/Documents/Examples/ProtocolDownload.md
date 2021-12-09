
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
              "PayloadDigest":"Ije0WIOFZYAHVOW23XUPZGZyUaOuP4VK3h
  W9TuR9weBR1SLrKZxu6-YVIXYIjUhgrwzwx4TnOGP5AYZBs5fcyA",
              "enc":"A256CBC",
              "dig":"S512",
              "Salt":"2DZNm9_YHBi6cZANavQNfw",
              "recipients":[{
                  "kid":"MCUC-XBXN-TCW6-SIO7-XX2H-5YOQ-72XQ",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"H2IR7xKSuddWNLSew5RkKg6ZPeeGJYhCv
  tn3u9UGAIAk22x8yZ-FGFadFpo6h-pJ37p2Kq3MXPyA"}},
                  "wmk":"VqYHyKnAXLYKgtusMTZ0XuWLNMQodzDBkoVRhZu1
  Pi_geZZAhrKXJg"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIiwKICAiRmlyc3QiOiAxLAogI
  CJQcmV2aW91cyI6IDF9",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":716},
              "Received":"2021-12-09T16:46:01Z"},
            "VBbdBSxBgcHSJ3qwOZJRSlNBtnI64GAtcHgd_smbBgAwsg31NZKs
  uh37RfIocrir1YVExjcwsrou1EOjP-UNdqDVgPNdX8L2UqBq5ibShRUntcfeA_Sn9
  GYFX50X_b0NMOviQAWKScOtz-gGr-1UgZhuk46KLPZgfhXiQR24Wss",
            {}
            ]
          ]}
      ]}}
~~~~


Future: The current implementation of the download operation is limited by the
capabilities of the HTTP binding of the RUD transport. A future binding allowing 
operations that consist of a single request followed by a sequence of responses 
will allow much greater flexibility.

