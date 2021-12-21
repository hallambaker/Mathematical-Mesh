
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
              "PayloadDigest":"BrwAX6x0aHUC2gx8mAeyapL9EzINsakQNW
  5OSLzQl_vDgz50GfV_PKiE_jQRNFxaVftYHfYBrA8H4-7EtsAoYQ",
              "enc":"A256CBC",
              "dig":"S512",
              "Salt":"pE7_b0Ls-fd1KcR6p36v0w",
              "recipients":[{
                  "kid":"MCHC-HLZ5-DO7Z-7LQS-G4RD-JHBN-DMKP",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"xMWT8Ajfc98gdaBv88IOJ0ue6EaOsLaAj
  Qdm-80cdr4kjLspIMSpB9RXgidrb8c7VyqJ8XKbMxCA"}},
                  "wmk":"nRjKUd0LIXCneF_8bK67Fac3GLO7WVIxMHeRy7sZ
  _L_BBaVu9lHKKA"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIiwKICAiRmlyc3QiOiAxLAogI
  CJQcmV2aW91cyI6IDF9",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":716},
              "Received":"2021-12-21T13:28:09Z"},
            "ThZQrIr6QSDSeFTZpYH5m75k5GnWVuo3GuqWid2E2eP9Y5n-rPlE
  pPYcsNC9RQieQg1YEsUe_4fgJu71R5B2PWej31M-Hr87b4U4NrY_IffCjvh3DhZMc
  aHmpm9ceKFMKv7T1ovWhWlpoQR-j7YfOkWs2ha15tcCSraufC_UzP4",
            {}
            ]
          ]}
      ]}}
~~~~


Future: The current implementation of the download operation is limited by the
capabilities of the HTTP binding of the RUD transport. A future binding allowing 
operations that consist of a single request followed by a sequence of responses 
will allow much greater flexibility.

