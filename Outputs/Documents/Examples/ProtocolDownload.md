
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
              "PayloadDigest":"b4k_RdNdpxWj7JL3O4YDxcbHa1YuO-5m0X
  CMt7RCdfQq2SVsDyvappVqomUpQ76_xhnapV-eMpofRfPWVdu5tw",
              "enc":"A256CBC",
              "dig":"S512",
              "Salt":"miPFtDQ8C2MM18wazGmMpg",
              "recipients":[{
                  "kid":"MBGD-Z2LR-5KHE-RBRG-4IGI-Q4CG-Z4IS",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"tKdS2GJhGX6sW_UnvtlFbFtzokoewueIw
  06dcxzROcKewJTdjtRznPzfMjjVO23TOPfSJjdprv8A"}},
                  "wmk":"y1sHoGlLqlpxVh_2lduaLI5S0a6Qf_Ql4zD94Lg7
  u2EUiVJyMQ_g5w"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIiwKICAiRmlyc3QiOiAxLAogI
  CJQcmV2aW91cyI6IDF9",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":716},
              "Received":"2021-12-20T14:00:13Z"},
            "qsNcitXEY9yZAu6wIs8lZJZ8k0S0VTMJjlf8FzfCAhhyCs1_R1Xu
  Qvnvb_YWz4jwSt17mDkhfmvNxj8R6ZiJbLxbc_CiDmOh60SlBEyPNRymJciW6Kg1g
  116Wy4iSXVNytP0NVe04l24_Ptwtzb2_tBv7LlFY2GSHOSOoGHuMdg",
            {}
            ]
          ]}
      ]}}
~~~~


Future: The current implementation of the download operation is limited by the
capabilities of the HTTP binding of the RUD transport. A future binding allowing 
operations that consist of a single request followed by a sequence of responses 
will allow much greater flexibility.

