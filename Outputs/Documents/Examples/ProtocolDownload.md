
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
              "PayloadDigest":"K-UFpj3lM68Ss-giQEGphiY2nzQwZ0wJKm
  SXBxmucLZ0g_XxlvJdTGbINJKbOeFC-GWK-pfE0bfOKc21SBreFA",
              "enc":"A256CBC",
              "dig":"S512",
              "Salt":"uTljzronr-lB-Y_CjrjIKw",
              "recipients":[{
                  "kid":"MCOD-RDWV-XCRC-MPYT-2NIA-P6HQ-6D33",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"rfy-yru7zPGHSRTTPTduLiBo7psygt4gE
  3Pik7fkwE4j37ffyuFdKKe0Fjjt-R7AnI66DLkwf4IA"}},
                  "wmk":"CHukJoCWi74lLhQRludAx_VxkRi1DE8slhoAeKl8
  kERNV296VYJlUw"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIiwKICAiRmlyc3QiOiAxLAogI
  CJQcmV2aW91cyI6IDF9",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":716},
              "Received":"2021-09-18T18:46:41Z"},
            "fN6dBWBwGSXTn6u8KGj79DkXjApF0j4J8sZmYedqQy4fXOwinOUS
  6A5Rn6Lzp76VzpALmSNLqdNI091GSfcIt06Wm7wExMAbDR1HXI3gDpkC_8A9QvLJu
  8yHWJcfiJuRupbOLabSNqdBqkrNLxWDAxVt3vyXFTonzO-E7Y20leQ",
            {}
            ]
          ]}
      ]}}
~~~~


Future: The current implementation of the download operation is limited by the
capabilities of the HTTP binding of the RUD transport. A future binding allowing 
operations that consist of a single request followed by a sequence of responses 
will allow much greater flexibility.

