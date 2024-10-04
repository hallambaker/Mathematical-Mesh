
The request payload specifies the data to be appended to the stores.


~~~~
{
  "TransactRequest":{
    "Updates":[{
        "Envelopes":[[{
              "enc":"A256CBC",
              "kid":"EBQA-J55X-C5MH-KWFU-GQ7J-7VIX-GZTP",
              "Salt":"4729bfPJHzQ-o7V8kvKsmQ",
              "recipients":[{
                  "kid":"MB4Y-LRCQ-VRLU-KDLF-R47E-NISD-HKHH",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"WuKmcT96dcBVaAqGVbbEgmdxMbi0K0IQj
  swEsKy__I-C-YyblWoCY-OGv1lsmbZAEusVl5TC5o6A"}},
                  "wmk":"89nxvw3wZXeI-ps7RExTNxPmqJdG1cOjmKNpYGaH
  Nhs-a-rqGooGmQ"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQlhBLUk3
  UDctSVNTSi1aWkFFLTJPQjMtWjZRUy1aWUJIIiwKICAiRXZlbnQiOiAiTmV3In0",
              "SequenceInfo":{
                "Index":1,
                "TreePosition":0},
              "PayloadDigest":"DWcEHLfrJKnA6bbnITu2ATU7qK8GgC5fc3
  iqjMK96pyyt11ELvhvbUsjdcNP_uZ-WUXoE2oQ9pv42jknND2Kjg",
              "ApexDigest":"bOtsAEebrVT7DNjTiR9xaVNyoa8OG41PZGcTs
  xfMljKnQ6E2sh4HYvhnxmAQndBpOy-B8d__lNi1sJAFIsu7Xw",
              "dig":"S512"},
            "2Mc5t-rFEReJ6rlb8VKZ8dNoiUopet9FeqjGdb4Lo74_Pm4EiuEd
  KOIPhZyf7TaVb6woGdr8FjEGj2shr2cKy1jCqtbTp_Ppf4q3GD9qHABawATYEcqVb
  537VVzUNNE1otyiOGm-rgvBuhOgiAifUtX7yrAHfJq77Vl1n52RG_eRceq_jBBuoG
  MrfBN4fKS4"
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




