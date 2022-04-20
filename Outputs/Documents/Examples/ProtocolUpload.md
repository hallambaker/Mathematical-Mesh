
The request payload specifies the data to be appended to the stores.


~~~~
{
  "TransactRequest":{
    "Updates":[{
        "Container":"MMM_Bookmark",
        "Envelopes":[[{
              "PayloadDigest":"nLPqGhIpOzHAKROd7NqK6i2E-_cbliqw9u
  U5RS7LRV7-u2LtLvXjjl3zA0U4SkoiK7lQJxcywO3gS5189D3wnQ",
              "TreeDigest":"-SDCQM4HDOThmLenmg1392iskvEeEDdhactIU
  1D7cc9m25-4LH1eY-qyLo1nijRPL5AtULixbyUOlnpPM9FEZg",
              "dig":"S512",
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQVZVLVJI
  RFEtTjdFTC1HUU5CLTdVNzUtQzRUSi0zREtPIiwKICAiRXZlbnQiOiAiTmV3In0",
              "SequenceInfo":{
                "Index":1,
                "TreePosition":0}},
            "ewogICJDYXRhbG9nZWRCb29rbWFyayI6IHsKICAgICJVaWQiOiAi
  TkFWVS1SSERRLU43RUwtR1FOQi03VTc1LUM0VEotM0RLTyIsCiAgICAiVXJpIjogI
  lNpdGVzLjIiLAogICAgIlRpdGxlIjogImh0dHA6Ly93d3cuZXhhbXBsZS5uZXQifX
  0"
            ]
          ]}
      ]}}
~~~~


The response reports successful completion:


~~~~
{
  "TransactResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~




