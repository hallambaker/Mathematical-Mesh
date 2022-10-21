
The request payload specifies the data to be appended to the stores.


~~~~
{
  "TransactRequest":{
    "Updates":[{
        "Envelopes":[[{
              "dig":"S512",
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQkNFLU9M
  TFMtRkZVRC01S0FXLUxYU08tNlNPVC1NV0tOIiwKICAiRXZlbnQiOiAiTmV3In0",
              "SequenceInfo":{
                "Index":1,
                "TreePosition":0},
              "PayloadDigest":"AUNDpV9PHUjG6OU9x1ZWfdBCHdy1y8XyVz
  WoW62krM3aNP2uujQdnpmIIozfhK5x70-coCWoAwoRc9K08cKs0w",
              "TreeDigest":"a7XTK7vdmA45v9PQf0fEbW7Mx-E7cQPAX2JX0
  Bwp_OkzUubItYdTFRY_pkydvEwtdZRUz8K8_EpCSCkLZWj8Bg"},
            "ewogICJDYXRhbG9nZWRCb29rbWFyayI6IHsKICAgICJVcmkiOiAi
  U2l0ZXMuMiIsCiAgICAiVGl0bGUiOiAiaHR0cDovL3d3dy5leGFtcGxlLm5ldCIsC
  iAgICAiVWlkIjogIk5CQ0UtT0xMUy1GRlVELTVLQVctTFhTTy02U09ULU1XS04ifX
  0"
            ]
          ],
        "Container":"MMM_Bookmark"}
      ]}}
~~~~


The response reports successful completion:


~~~~
{
  "TransactResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~




