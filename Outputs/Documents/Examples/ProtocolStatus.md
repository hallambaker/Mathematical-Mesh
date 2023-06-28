
Alice adds an entry to her bookmark catalog. Before the bookmark can be 
added, the device synchronizes to the service. The synchronization process
begins with a request for the status of all the stores associated with the 
account that it has access rights for:


~~~~
{
  "DownloadRequest":{
    "MaxResults":-1,
    "DeviceUDF":"MBYI-QYCM-JXEY-OJ5D-4OW2-RPIR-SHUM",
    "CatalogedDeviceDigest":"MC55-7MYF-ENK3-L6N2-GTXT-WG45-WN",
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
              "dig":"S512",
              "Salt":"irmN6peoQ3obHMmNW164ow",
              "recipients":[{
                  "kid":"MD5W-K3CL-LJ5Q-YVXA-CMFG-5SPX-TUXV",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"c1wBMbDx_9Rd82IfuWaPqvf-rDhV5QShZ
  DZE7gEqT6ciyPARKXVSYKjGiRqiGT2PMyi8UY_tkc2A"}},
                  "wmk":"jezjPjJU-Djfm_bZitHdInmOPTg1iIQrx7CseX5Z
  -E6gv9w37BchXg"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIn0",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":1137},
              "Received":"2023-06-28T17:00:19Z",
              "PayloadDigest":"hAJqF3IoraQqNHLcHZMsf_c1IcrD_xDOnJ
  0gN9QBcSoRk8QhcfsKzi9L6J7kGzjhHprDCxyYgCE88DZUYC7CnA",
              "TreeDigest":"ZdG_UR3YUbPxX1e28NR6S26yAwkmsLKmwSkcH
  12bWUrEH9A54K_PX9VdKZODQQ5yy0nBtvubUAJefbjgexLeFw"},
            "UC8cIjRLdmfLxW4pQ7-dAl1nKucTTs29pTSCQM6_v3H0d4jL8lzn
  tinoJGl6PgkOEiyPYc6a7ioi_RnEpFlH1dtoZ7Ra6VE_Y0co944cx3f05CZdZc9Zz
  P6k7d4XpShqnJq7rMvTZDMOHsiWr7VnulMz9_mU4g_uAz94qwvACdA",
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

