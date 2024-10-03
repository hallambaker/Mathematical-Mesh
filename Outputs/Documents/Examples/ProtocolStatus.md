
Alice adds an entry to her bookmark catalog. Before the bookmark can be 
added, the device synchronizes to the service. The synchronization process
begins with a request for the status of all the stores associated with the 
account that it has access rights for:


~~~~
{
  "DownloadRequest":{
    "MaxResults":-1,
    "DeviceUDF":"MBQP-MYOA-LTSP-B5GX-A7HP-ZFJ5-4VQ6",
    "CatalogedDeviceDigest":"MDLQ-JTEG-3A6E-MWEM-CRQO-3JHE-MK",
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
              "Salt":"J_Nk5H3kNtXgBb1vkGxQJw",
              "recipients":[{
                  "kid":"MD2Q-UIKU-BK4T-457Y-UWSM-LE3D-6P4T",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"wcZaaaYez9GzF5DliSy-xLjpdaJn8MmVj
  3nxFs5Fpbva5-FsikBBwyIk0I5s2pXSEGun3k6TlVSA"}},
                  "wmk":"AZ-f-QBFwwKsj1j4xxQ4c94RG-rIb62q_FVawNcl
  igOBvxVDw2nrdQ"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICI6ZnRwLmV4
  YW1wbGUuY29tIiwKICAiRXZlbnQiOiAiVXBkYXRlIn0",
              "SequenceInfo":{
                "Index":3,
                "TreePosition":1137},
              "Received":"2024-10-03T14:57:02Z",
              "PayloadDigest":"x002-YWfJ8Uw2av0qbQfhzr7cCcLqF88-R
  WAMZzobppmuEvNYGNPPMQAYZ9XiSqLKgA-NMwPhFUiXt9D_2XbZA",
              "ApexDigest":"djYmW9N3fLqEnUaRHBpaedC9HNwZhG3_rs5AW
  Hh0Qpn1PhoBnPh-h_ZT7nw2sOXVTzUgf3EAxd40N4Li2PT5PA",
              "dig":"S512"},
            "qVG1kzZJLAtf88rWQB3aF-EjuXpoRdVUjRqH44JXbpA3wlbUcOwu
  BKzGFvOMYiXWteQRBP4XE28mYFsxutFkZfsDDxmL-XC2qQImiW-x4xFirZv2uyCmG
  O7k0asPPfBZ0L8BmPicZtgeCOeIv9Fbo6WIg3xVRI1nO8H-L4EqTA8",
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

