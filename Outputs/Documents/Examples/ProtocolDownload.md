
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
    "Updates":[{
        "Envelopes":[[{
              "enc":"A256CBC",
              "dig":"S512",
              "Salt":"9G8s-0EiAgsU9KfVUcNhmg",
              "recipients":[{
                  "kid":"MD3C-QNUT-ZU52-7ZYI-KKLE-634C-FX46",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"hnlO_tCx1jlYE7whov_zahfrvFiVv9FxS
  lBtr3ujmPBYkc6h8qfMDV1oRWOGbt8giT03J0g37S-A"}},
                  "wmk":"zBUGL2OKIECJ120IqN1kQicryZXen5qsZWA7yLZK
  tzQfLyimnOkVjw"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIiwKICAiRmlyc3QiOiAxLAogI
  CJQcmV2aW91cyI6IDF9",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":825},
              "Received":"2022-10-18T12:43:49Z",
              "PayloadDigest":"isMr-j-qxmeh4Jl4M4fFHLMcHNGC0rhRMf
  C_fBgP9KLiY7eIwtZmJ9zRDT-LsqD6qTuWgKDDOr5EIdr3F4dYBg",
              "TreeDigest":"aNMogtuGtBohOUNSCfPXDNONUz5BQ86TNDOfE
  _HZ5zi2Bw_FWQik3E1qWyXFi-GuWipin-bJuFPJ2JPu-mIj4w"},
            "i5YiMuM69xy42g6FbOBjc3P-lfIRpsR4FBXKhvu6_OsZxZHSqHTY
  GUYuommb9YdpCvZbxrm1W7_mNiBQPMdFWP69r6J3WCT1qYRboEvVSTI3nz8G-RO4G
  UlxuYzMZUtMZ4x4EZxpLmbGseS4U7VYe-aqJg6RA-Qjgnijp50y0wQ",
            {}
            ]
          ],
        "Container":"MMM_Credential"}
      ],
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


Future: The current implementation of the download operation is limited by the
capabilities of the HTTP binding of the RUD transport. A future binding allowing 
operations that consist of a single request followed by a sequence of responses 
will allow much greater flexibility.

