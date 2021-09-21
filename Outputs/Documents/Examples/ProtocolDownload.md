
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
              "PayloadDigest":"geWmizdTD1WxP8M8enXbrltI_4R6daQeP3
  63_KUXF-SyB1Lb-RpsmPOtB2UZZCpLIlsiRm0hXvS9EvQFFxRoBg",
              "enc":"A256CBC",
              "dig":"S512",
              "Salt":"yNJavH7J9jYVHVwakOBC0A",
              "recipients":[{
                  "kid":"MC73-BTKN-7UXP-UEUS-L4AR-LS3X-7XSX",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"0N6uO76osmiK7TJ9wNik74zhFsXHFS5Wv
  l7OIwJ4N9AZUH9aQ0o8QWilPztxmuGrpmTtHrKXQeoA"}},
                  "wmk":"Up8ltTn5auDPoKx0AeeG6SJ4E09DruLm4WwFIJ5F
  xon86wHKmQpIUw"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIiwKICAiRmlyc3QiOiAxLAogI
  CJQcmV2aW91cyI6IDF9",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":716},
              "Received":"2021-09-21T00:47:37Z"},
            "lWJHptUqDmwLn2w7f4h8OjpSbbYYMIlCqd2W3AMMBiGPjbxULgHe
  SyTi81dWVFBo4Ktua9GDjKA8a1p9x7J4dhqXdSmb2HDAXRonH3r8nIcB_oYO751tp
  H-Ohso88u42w7k-Iyo9DTrj2RmQCri7iEZYb12ePFQmEJlzFdRdFFQ",
            {}
            ]
          ]}
      ]}}
~~~~


Future: The current implementation of the download operation is limited by the
capabilities of the HTTP binding of the RUD transport. A future binding allowing 
operations that consist of a single request followed by a sequence of responses 
will allow much greater flexibility.

