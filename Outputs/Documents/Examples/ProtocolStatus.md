
Alice adds an entry to her bookmark catalog. Before the bookmark can be 
added, the device synchronizes to the service. The synchronization process
begins with a request for the status of all the stores associated with the 
account that it has access rights for:


~~~~
{
  "DownloadRequest":{
    "MaxResults":-1,
    "DeviceUDF":"MBQC-IDY4-CZUY-G67R-2TLC-2C5Z-DQRB",
    "CatalogedDeviceDigest":"MBXN-57D7-STWR-WBHP-5L37-3S2P-5F",
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
              "Salt":"SwpTMU2OKqu4K3_NzUTokQ",
              "recipients":[{
                  "kid":"MAWD-5NLI-OAAG-LQE2-NHXH-3MSG-NJM4",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"ylFzWIe1xkMzSJiSdPXkBb8a6yKyeG4h6
  bwRH2o1JQ7HEKbei_yrksdEKFhqMFeVQmH1U3by_dWA"}},
                  "wmk":"Y9V4Qb_oEx9baj_IdkQR97el-ksTn2emsrejgfQ4
  jEcjmlDwtyHeXw"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIn0",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":1137},
              "Received":"2024-10-05T00:49:02Z",
              "PayloadDigest":"E-LEzBAud3EpDy6vy8pGwGTnl57-sdn8x0
  MISjh2l05ypBYNMeS_3I1ipCbFqwVgFqV_hpZbh-IvGHabVxanjw",
              "ApexDigest":"HrxczxxB2vojHce-7ZRWLn4qdunrmBCCrHU2M
  j4vCr9xwveSiWnLtbkaJ2Wzbc85Lamgqbhn5YVaEjSpcjxTpQ",
              "dig":"S512"},
            "KKeyUxAkUm3FcM9dO8Rh6mjsbejtihDbFDU9H_xfR8P76hntVbBc
  4oR_1yISlaCBCroA2tE6_osHUlJnIfYJcUQE3_U0Aq-xd05yD-O_bQcAPuTdRaDnL
  GbuIWMS98Bne_5fRS6sxUB0zw6AkSW7hWa8M4mvmhT8Pte1Q2SJxf0",
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

