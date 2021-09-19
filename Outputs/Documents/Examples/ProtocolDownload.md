
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
              "PayloadDigest":"_qmriwKhCfoU7A49Z4Z0ME8puMor9misqY
  yPg7szLqKCgH__QMurv303Z9EUEtrlioBJs4eq8n5lDc9Ni8NvpA",
              "enc":"A256CBC",
              "dig":"S512",
              "Salt":"5m_uTwwoOmqBLCFbE9ctpA",
              "recipients":[{
                  "kid":"MAMD-XHP5-FHFG-OUWO-3PSS-CPEN-PG7L",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"i4WB21gn0-dchx67Zc24uQ79NTXdS_O19
  _r06CpfkJJ--55369y1c66us7I3rFZrYZuYukBNDGCA"}},
                  "wmk":"GCrZyppwzlAnLximDWqrTZuDqB922nY-8mvHTeLe
  K2ROkbjiOrdeHw"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIiwKICAiRmlyc3QiOiAxLAogI
  CJQcmV2aW91cyI6IDF9",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":716},
              "Received":"2021-09-19T17:52:29Z"},
            "KyYy6VzQQMU79qoyADABN26Ja1vks6W6hrtJGZ8UVossTVELi0Xt
  HNHOnA5EKGI3MiUmgDjldgG5RL3gEZq21jetpQQkDDmZn40zOzjf9-vmsyS08KxYI
  zJVm45dJWwFnc0jkvmKuWqxm-49QMhvnvlwrIg1vwQieJvrGDaMBxs",
            {}
            ]
          ]}
      ]}}
~~~~


Future: The current implementation of the download operation is limited by the
capabilities of the HTTP binding of the RUD transport. A future binding allowing 
operations that consist of a single request followed by a sequence of responses 
will allow much greater flexibility.

