
Alice adds an entry to her bookmark catalog. Before the bookmark can be 
added, the device synchronizes to the service. The synchronization process
begins with a request for the status of all the stores associated with the 
account that it has access rights for:


~~~~
{
  "DownloadRequest":{
    "MaxResults":-1,
    "DeviceUDF":"MBQO-4TTM-QOTS-MKEG-XQTU-XNFM-WUWM",
    "CatalogedDeviceDigest":"MC2F-2ZAT-4BRE-QDDE-HBQQ-3H7O-PB",
    "Select":[{
        "Store":"Credential",
        "IndexMin":3},
      {
        "Store":"Contact",
        "IndexMin":3},
      {
        "Store":"Task",
        "IndexMin":1},
      {
        "Store":"Bookmark",
        "IndexMin":1},
      {
        "Store":"Network",
        "IndexMin":1},
      {
        "Store":"Application",
        "IndexMin":1},
      {
        "Store":"Device",
        "IndexMin":3},
      {
        "Store":"Access",
        "IndexMin":3},
      {
        "Store":"Document",
        "IndexMin":1},
      {
        "Store":"Publication",
        "IndexMin":1},
      {
        "Store":"Inbound",
        "IndexMin":3},
      {
        "Store":"Outbound",
        "IndexMin":1},
      {
        "Store":"Local",
        "IndexMin":2}
      ]}}
~~~~


If the account has a very large number of stores, the device might only 
ask for the status of specific stores of interest.

The response specifies the status of each store specifying the index and
Merkle tree apex digest values for each:


~~~~
{
  "DownloadResponse":{
    "Updates":[{
        "Envelopes":[[{
              "enc":"A256CBC",
              "Salt":"fYUwUF5YTfAeOgSewpXy_A",
              "recipients":[{
                  "kid":"MDFG-UKLG-VUPZ-XAY3-BDMH-FI35-RW3Y",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"iwbMN5lNb1LLgLYYTt-1xchZIOKm_Xt8x
  229dTEuZaDGfo0V1VLU19rYyWqPAif3wzWkzyFR7UmA"}},
                  "wmk":"0skSKfeeG4EaXByENg1R4wuXgNrWJ8nFkjpND1Wf
  sGntFaADEp-knw"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIn0",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":1137},
              "Received":"2024-10-14T13:10:46Z",
              "PayloadDigest":"M5x4gqPlFJCU1hAeHkcwuahGWSKDj7sIkn
  _nkD6QtVAmWj5sjPJqsHAbaS7wIa868nZesxO9xHg3H2qs3aAZPQ",
              "ApexDigest":"NcSyijJ8HTa7RoYotCszOoMrNtSjGMx7DhkNd
  nrIvkJzyUwVU-UmbZBHhhfJ_sb7bZ34aSVbSjh8smDsEoPLSA",
              "dig":"S512"},
            "Yu50_fuQ4RhYOlOjCENjKFmKjcWcnb08of_ZaW5Kg1KovLyN5bsa
  x3TH9EKsQ50AuJ_bp6xXlhYY0arhBudTm4G7oPc8TYRdCMw4-bs4iGGu8zFoXCAex
  6eC9_LJbyTw20DmFIzCt6Jdpos2oQZ6GyT-x8PCxImuOzToiP6x2O4",
            {}
            ]
          ],
        "Store":"Credential"},
      {
        "Envelopes":[
          ],
        "Store":"Contact"},
      {
        "Envelopes":[
          ],
        "Store":"Task"},
      {
        "Envelopes":[
          ],
        "Store":"Bookmark"},
      {
        "Envelopes":[
          ],
        "Store":"Network"},
      {
        "Envelopes":[
          ],
        "Store":"Application"},
      {
        "Envelopes":[
          ],
        "Store":"Device"},
      {
        "Envelopes":[
          ],
        "Store":"Access"},
      {
        "Envelopes":[
          ],
        "Store":"Document"},
      {
        "Envelopes":[
          ],
        "Store":"Publication"},
      {
        "Envelopes":[
          ],
        "Store":"Inbound"},
      {
        "Envelopes":[
          ],
        "Store":"Outbound"},
      {
        "Envelopes":[
          ],
        "Store":"Local"}
      ],
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


Bug: The current version of the reference code is only returning the digest 
values for the outbound store.

