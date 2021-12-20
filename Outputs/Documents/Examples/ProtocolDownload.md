
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
              "PayloadDigest":"TRNQI1k53G-cWe2pUATfKZj56udpD1NrjR
  xhtaJbRTl0bXUoa5_nS1FGYgCY9UUEy4uRBdb0cT42ypYHd3XLmQ",
              "enc":"A256CBC",
              "dig":"S512",
              "Salt":"QgiPs6lDBJlnriUq0dUFpg",
              "recipients":[{
                  "kid":"MDY4-Q5ON-3RQE-ZAAD-5RGL-42V7-JD2X",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"edvuyFjOj1UrpWVnj-DE6graRexekw9Jh
  K0pHq_QO6F9Yygn-tsUoUXZC6GyqYo-XomE8HY1G4sA"}},
                  "wmk":"vr17VuPuBtFllGWnf2yZQsrHRA4FseGsv3yfs1XI
  G4n8IBosEp8JXg"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIiwKICAiRmlyc3QiOiAxLAogI
  CJQcmV2aW91cyI6IDF9",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":716},
              "Received":"2021-12-19T19:21:02Z"},
            "Rrglsi3vI3AWma29IqQi8TU6aWqHMcSQCyyJ9FGzgOUMlVW6JWRo
  rOfoBLosg0YY52bD2bgbWrOpoLb2-o0L8FOsdDOm2YXXoI0qz9_zwRRUcZycDBi65
  RX9oRrowcnATBsaopY3Us0lRSmy3f-AuNjp4r-BmZA0vK-2Hv6gPiY",
            {}
            ]
          ]}
      ]}}
~~~~


Future: The current implementation of the download operation is limited by the
capabilities of the HTTP binding of the RUD transport. A future binding allowing 
operations that consist of a single request followed by a sequence of responses 
will allow much greater flexibility.

