
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
              "PayloadDigest":"-cAL5yhwZoAgsX6RwjoaSllkO5PeewJnBN
  qXGgisPSF6jXfgygrbh8KFOi9MDtUwfw3y0BtCOgRXrkEKXDGzVQ",
              "enc":"A256CBC",
              "dig":"S512",
              "Salt":"0FiauCi3pnAuAmA4B8jAXA",
              "recipients":[{
                  "kid":"MD5O-RLNT-3CUX-UCMN-CQBY-F7ZW-OKDD",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"3b4PznrDhShr5Q2AZKroOIn7DmKu1Du89
  Cq3SDnoJ516ZuRprClX66EqS-pT19NuoRRje9flEf0A"}},
                  "wmk":"dba-lDOD8dkVKBL1zt1nTuQnha5FrkkjS3ZdIPpB
  sV5JYP4PUHWI4A"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIiwKICAiRmlyc3QiOiAxLAogI
  CJQcmV2aW91cyI6IDF9",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":716},
              "Received":"2021-12-22T01:12:59Z"},
            "aJ4tzLvW76rqV04T8sXC8hqmXT3zjz-u9cYL1fU1EJTo7CtUoF3U
  nieBZzNS35793YUptBA8UcNqcPpcRKeUjS7vUcMgJP6fuu-61y0_zI9fy6d61ET3_
  W4DtxDaGCAY1DEnNcROX83DkArDSpCFRVoyqqlB5YxvKsLKj3Rp9jE",
            {}
            ]
          ]}
      ]}}
~~~~


Future: The current implementation of the download operation is limited by the
capabilities of the HTTP binding of the RUD transport. A future binding allowing 
operations that consist of a single request followed by a sequence of responses 
will allow much greater flexibility.

