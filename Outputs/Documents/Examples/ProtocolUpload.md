
The request payload specifies the data to be appended to the stores.


~~~~
{
  "TransactRequest":{
    "Updates":[{
        "Envelopes":[[{
              "enc":"A256CBC",
              "kid":"EBQE-RAUI-E4FW-E7AM-NHYA-D37S-H75K",
              "Salt":"nKm9-ppD3fQ5-WnCdR3LaQ",
              "recipients":[{
                  "kid":"MCYC-OLUF-YF5U-VRE7-D5WY-NF7Z-UJVJ",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"Jp8bhBoyUD4NqDhUjk-6OVVb8Ma5oQBMj
  5vzW3XJiM-v4amdvjbPwS7aPXsOk_ppmra9rPZCa7CA"}},
                  "wmk":"nGqe9SoDWC1J3uHbT6Rd6GGtt5A49JTEAD_C1W91
  eWwTU-6l2FrYLA"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQUhULUlQ
  TkMtM1YzTi1aSUdFLTc2Q1gtTTNPWS1IU1pKIiwKICAiRXZlbnQiOiAiTmV3In0",
              "SequenceInfo":{
                "Index":1,
                "TreePosition":0},
              "PayloadDigest":"0c--vSsSvAXZIABuixvQhX1GcDCPfSf-ck
  W0mSPcdSX1yBmu11EuEr34a5-nK1fFwTWA96uD5Izy91i1b-aUeg",
              "ApexDigest":"wLUjdiAjBY-fS0Q3fIHiCfpyU-ecQrXqI0iAN
  I0QElN18XxTvYrrnLdEuBXoAzXZ5WXedXPYiwUcbIIZMoLFhA",
              "dig":"S512"},
            "sqtAdD9s8YGbqo7qkq8PUphwVVb5ZGh1og1EFEsFtqS1fHLjNifu
  WUSAXl9-TQK3IVq62j48Yfz6hNupfM9XJlSAt2v5sw6miehbELgvpV5HTECBeHBPG
  u_NEgnQRYDY-TamjkEYW94mAhUJel73vOzUfReMR7yQJ9u_lcbqVBX1ZiwgVEm853
  afZ8doOH5Z"
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




