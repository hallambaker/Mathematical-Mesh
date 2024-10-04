
Alice adds an entry to her bookmark catalog. Before the bookmark can be 
added, the device synchronizes to the service. The synchronization process
begins with a request for the status of all the stores associated with the 
account that it has access rights for:


~~~~
{
  "DownloadRequest":{
    "MaxResults":-1,
    "DeviceUDF":"MBQB-RX7H-5QIR-V7MS-AN4W-JW7A-UXYV",
    "CatalogedDeviceDigest":"MCEG-3RY5-K5PZ-Z72O-PPLO-CXJ7-G3",
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
              "Salt":"2wEUFlRp1XXSftpZNQ5v5A",
              "recipients":[{
                  "kid":"MCQT-WUWB-P2AX-NDIF-TFVU-DNW4-K4CO",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"k-av48-wyuCodxBBgVsybr4aLVwXocEoA
  I3WPG6pkv7ynfP3kGgA0wthyaXVJuQ8Ixc8uxG5mSaA"}},
                  "wmk":"xLFD-VKg1pzswPT4cVs3Pxj65RBiOqB_CJ7p6lDX
  0Rq2S65rNeu2jg"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIn0",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":1137},
              "Received":"2024-10-04T01:04:29Z",
              "PayloadDigest":"a7KuWKxHefybAnDx8Z85XwiI6X3eb-pIg7
  2lnKx942PYBS-V_IcLf4p9t_b_ODkqRSa1eimqNsa5iPJ7r5NDpQ",
              "ApexDigest":"HFoyOkB_EiHYNlxJyUBC8OM5fL4PSpAFpVT_Z
  C6a6SECrRGpip0ycKr3GKhD9t8tN2vtViPMM-MWnUKlX92_fw",
              "dig":"S512"},
            "hgkq7gIhdJaBbFm9BZwdOFK1T8J1liBXHgpTmYb43Ol0XnN6MwWs
  hPJ58BrISoEdQ5l_0Hjq4DJHr_gleb1RoND14u40JSVNCSBM6Eye6UlxDcmFnMb5Z
  STzhfrCrhQ0revfJFka6DMtDYtDx-Y_qGYsJhxkv6W_nFXvw8tKL8o",
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

