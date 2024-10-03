
The request payload specifies the data to be appended to the stores.


~~~~
{
  "TransactRequest":{
    "Updates":[{
        "Envelopes":[[{
              "enc":"A256CBC",
              "kid":"EBQB-WYQP-GWDI-T2Q3-66VP-JJQ7-7L7K",
              "Salt":"ijNbSgfvELtbySodfORglQ",
              "recipients":[{
                  "kid":"MAJH-FKEY-HIK3-7URL-AIQX-PWS5-BY5X",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"4oIMAnDSNGrkj2G61mgaak7eloQfR2p99
  bJ9VV-fb0QAExql-9b8R4BH9ihSmo3eQ7sVaOM_oyYA"}},
                  "wmk":"zZ70hhQV5rOcf2reNCZNNgzPYhIrQ9whUD0veSu3
  8clRUghdr6A_CQ"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQkNBLURX
  MkMtQUtEQi1VUUdTLUhZVjYtQUxBNy1aTTdSIiwKICAiRXZlbnQiOiAiTmV3In0",
              "SequenceInfo":{
                "Index":1,
                "TreePosition":0},
              "PayloadDigest":"wt2pdvewuKGHOkoympamqO7W9OYyZQFMd6
  S_ItrISivsQ-UtLrhstBNGsg4-W08oxIjlEwm_vsMnYOQfZ0YCmg",
              "ApexDigest":"hy8teweU9UBp6wcByNKsRb_WeqPWHtL4l0lmZ
  mDHf2HVAZvBtwZywK33BfTia8e2RZAH6Mchye2FTDOUxkj1Xg",
              "dig":"S512"},
            "VL2wibuanX6vGinEYrZbojWPi5113yN-lLxkENvP_C_0Q7XcF_5y
  JZRe8RhTB30B1iGujq-CwizgO8ZRZjfGj9CMUJNkT9A51Yy555FxQ6Ldpr5ol4dHb
  GWge_oj8RV1v0l3m1SmjEUtxRpEG_CIqiW7BvY9whkxJitoN_1Uv4TFig02xYsrNO
  KS23e2n9rn"
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




