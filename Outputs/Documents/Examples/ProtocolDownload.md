
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
              "PayloadDigest":"ViOel6XEERd8vS3cNPnNkXk14rcjfxhBrf
  tQ8FycWhL0MCUaHVA9jKTRT7xWKzUbPklrANlpZl4y7j8erUnpdQ",
              "TreeDigest":"plYLtIgRdVJB82LEKiUn3rs9guARA9bnSf6eG
  OmmR5Wuj5uIEYhnL2q2v29mOD8SUZdYeL6f5CDLciY0onNHnw",
              "enc":"A256CBC",
              "dig":"S512",
              "Salt":"GMsUn6jn1sXUinpjWN0n2Q",
              "recipients":[{
                  "kid":"MA67-4U5O-PTDZ-WX4D-PDFU-F7RD-3A5O",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"HkhGCfROdc42ZybuyXddvfhPY2iNJCTAU
  9zZO0ho8k7uV9Br8oBhasuYhsEdWGoh_w9oclPnWWIA"}},
                  "wmk":"ZwwmmwI-YSDEjCFjpcZeOo6_GYIDCVfYMPitwsHL
  Dq5ZQqi5xL9P8Q"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIiwKICAiRmlyc3QiOiAxLAogI
  CJQcmV2aW91cyI6IDF9",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":825},
              "Received":"2022-05-03T16:47:09Z"},
            "WUD_7MrlZuD3MCvUbaf_BpzNvShS6WJonZjyWYfOJSMiy9nh8Sav
  wkUc41OMnnBLyLXXZEtojbPhQasAt2pRCQaURCcm8gwfp1SF9TY0j0De-JJKRIYgS
  e9fAXhWF4Ytt7DGW4FK1aJFMLGGoY4p4fwrIglr7HRLnzXb8nGI9k4",
            {}
            ]
          ]}
      ]}}
~~~~


Future: The current implementation of the download operation is limited by the
capabilities of the HTTP binding of the RUD transport. A future binding allowing 
operations that consist of a single request followed by a sequence of responses 
will allow much greater flexibility.

