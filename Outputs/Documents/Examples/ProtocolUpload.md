
The request payload specifies the data to be appended to the stores.


~~~~
{
  "TransactRequest":{
    "Updates":[{
        "Envelopes":[[{
              "enc":"A256CBC",
              "kid":"EBQH-FCIB-JKQT-746V-FE2I-IEEI-GMEC",
              "Salt":"WsdkI2icQX-czV4twcrQSQ",
              "recipients":[{
                  "kid":"MDZV-J4CB-QLA5-K6GU-GGP2-OAXS-3FB6",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"nNKy3ud25ZOHhOpIoCREUMru72r9RPny4
  8Tg_yw7JELHYek0nEgUiVgYJiVUweGMmPL0HC-KdY4A"}},
                  "wmk":"LLtDyCCrKdEbVEzohPLP2Q_ZxMLz9qv2dXLBiaB2
  XVkFHt-Jxa9rgw"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQUNMLTVM
  WFktS1hGNC00MzJCLVhDWkEtV1RGNC1RUDVRIiwKICAiRXZlbnQiOiAiTmV3In0",
              "SequenceInfo":{
                "Index":1,
                "TreePosition":0},
              "PayloadDigest":"jus6Cpy4Fk_4HN2oW7xhkBSv6Ah-cAImeN
  rmBbcQy4heAkyzHiOouwUNiy1ek-eh68q2zgEwaqWAxVUutj9sMQ",
              "ApexDigest":"rY8d41_tcAvacoZ7x5NI2GmM9R33bPgWN_uTc
  VuKD6cuj6aTFqwdY2nCSRiyE6Pw_lpUIdiDEWz6XmdQh33Z3A",
              "dig":"S512"},
            "lzE4p_C7tj1-0YCg1J__UUvK-WqDtWDCOvsm4MN0y95R8-XpbgEi
  888BlNOnp6d1pvNNKHtxtNzO9_yOMKTAur3B6a1nag1-x35DddfV-8Ho9DjSAoMGh
  NWZ6I336ggTSHMOWLJXbqxBYCUrnBHMZn7ZWADU0IoqzE4VXsODflmYQihY2sPQMO
  iiHM07WD_r"
            ]
          ],
        "Store":"Bookmark"}
      ]}}
~~~~


The response reports successful completion:


~~~~
{
  "TransactResponse":{
    "Bitmask":"AAEAAA",
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~




