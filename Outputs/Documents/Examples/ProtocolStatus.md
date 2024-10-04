
Alice adds an entry to her bookmark catalog. Before the bookmark can be 
added, the device synchronizes to the service. The synchronization process
begins with a request for the status of all the stores associated with the 
account that it has access rights for:


~~~~
{
  "DownloadRequest":{
    "MaxResults":-1,
    "DeviceUDF":"MBQD-67IL-PJTR-EYFE-2ZGV-QLZF-QC6W",
    "CatalogedDeviceDigest":"MASA-JKGB-7LXO-J4YI-G2XT-4X72-AL",
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
              "Salt":"tmxJX_gY9Mnc_x_JcUFv7A",
              "recipients":[{
                  "kid":"MCKT-IUCN-5IS2-X3HQ-L2MK-KWJ4-VNOU",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"QjkM8sgeSm8TI1-9lYSo5pqywmuzdWB26
  bKVgyq6trHLL-z4jsedAewkDC9eFSlWDMRluBLePgAA"}},
                  "wmk":"ux1AhfLJ5bQs6atd7wFEPybsI2oP3CqWRiPcMP8L
  Yd-GGw1MqFm1zg"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIn0",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":1137},
              "Received":"2024-10-04T13:13:03Z",
              "PayloadDigest":"-D1Wnv8yTEGwL97PO-PBk5TDUsnZ-aZ4OQ
  NKtAIrBfui7_AYV4M4fE3paHqjF_ItkSgJL0xQn1_DAKVjxCDiMQ",
              "ApexDigest":"ixp0DHVs_QCaT785ByDCfDB2nAkmm0rPozDOt
  sQ0tAzCM77riVuGKU0hmUs2sAby_m-1wDgK6bWOJRnMH1uOug",
              "dig":"S512"},
            "OLRbBawaflLG0bze1wknQeFcek9FyxVeEJTe2WoccHmv9vM2VxIy
  Ki5b54YqLDNevDd8ljnuixB98JXkQgoiMjDb-9NZLGVZlLElmpQJp8kAIe0gMAMx6
  Og-kXTcmkajUar6tax-YeLERQntnQdvLjLbf1HUUA_PpY64OWP5m0k",
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

