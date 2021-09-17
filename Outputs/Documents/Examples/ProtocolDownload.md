
The previous status operation has reported that a new envelope has been added to
one of the stores. The device requests this data from the service:


~~~~
{
  "DownloadRequest":{
    "Select":[{
        "Container":"MMM_Credential",
        "IndexMin":3,
        "IndexMax":4}
      ]}}
~~~~


The response contains the requested data:


~~~~
{
  "DownloadResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "Updates":[{
        "Container":"MMM_Credential",
        "Envelopes":[[{
              "PayloadDigest":"gMsJUQ90xoQ4_R_f_jwHNtk_XmIcj7MLNz
  kwW97ucddqIjwv9se12xgSUsktA3xSEPaI7spgkhrr1bYxInWhOQ",
              "enc":"A256CBC",
              "dig":"S512",
              "Salt":"sfpZPZAnWAHDo1T8ZvAZtQ",
              "recipients":[{
                  "kid":"MA27-7XVW-GDJL-SY6H-6HZW-EKMC-TFD3",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"8pHdD6vQW22vGQTot9Fil--_bFooaGCjT
  XjNqiA6i7ArTUWew170PicBnBc0_F2rHKlH9Mb-07YA"}},
                  "wmk":"6tRKY5XxiFmduGCiJHKWFht8QPvP6xLnGd5Noa6x
  wlKnpd76DMd7lA"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIiwKICAiRmlyc3QiOiAxLAogI
  CJQcmV2aW91cyI6IDF9",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":716},
              "Received":"2021-09-17T13:08:31Z"},
            "5VKuChSrjsIgQUObGlQX8mKLROs8T3NaGc639dCGJ8Z4YLkRhswP
  o2leuHnGThHzS2Da_hPcOeJGks9Z9IUSCx-KcfErSAyk1uvoli5nyT5i9rBCdj0x-
  fYPEIeUg9yFIAiDlqjLoVPhW0ZlB6Q5wfQ0LCDt7wykCPw1MvQWo7c",
            {}
            ]
          ]}
      ]}}
~~~~


