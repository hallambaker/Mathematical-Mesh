
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
              "PayloadDigest":"scKJJY0e2llHKRImyYAHL98MSo62-eVSTz
  8JkFFaicCDM1Nskxm5JW1WIUy4XhKdhYTYagTRFxNTsbABRAOT7w",
              "enc":"A256CBC",
              "dig":"S512",
              "Salt":"28sn1l7vROY1rqAjTNaxzg",
              "recipients":[{
                  "kid":"MC7F-DLCK-JI67-VFL7-BOHX-T62Q-KCVG",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"lGsU2MtoCW3h7kBLBfm4eN9xXqVSVbR_9
  Es_47TEqVo2HYkeSOlkFE1hPNCz98yD-xFx_9omFj4A"}},
                  "wmk":"tyvbkB9eXzVAFqYyTn12vOcC18vtSIlIfmPR6hpS
  LPoAORyeVaD2rg"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIiwKICAiRmlyc3QiOiAxLAogI
  CJQcmV2aW91cyI6IDF9",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":716},
              "Received":"2021-10-25T15:48:48Z"},
            "GnC2lneENSTxMbQ6W91xcsDRs1Ap9P5PRn7MHvCQ1hEMWiGWw91t
  r5llzPtdeZz1-FxF5Cc49FrdanP8dtWZVNMTg4yQMf5bbaRzte4CzUrKihFYdJ3SK
  GAm2EC317muijVLb29kqnkJkmdLUJu41yYZ4OLRe1rM_xR1t0VlkaE",
            {}
            ]
          ]}
      ]}}
~~~~


Future: The current implementation of the download operation is limited by the
capabilities of the HTTP binding of the RUD transport. A future binding allowing 
operations that consist of a single request followed by a sequence of responses 
will allow much greater flexibility.

