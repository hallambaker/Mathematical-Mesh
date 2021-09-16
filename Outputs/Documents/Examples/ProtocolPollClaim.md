
>>>> Unfinished ProtocolClaim



The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQE-U4SE-LQ3J-GARM-V7YL-K4EX-6AZG",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"CUPOJ8XwYGJ-2a1fn11WaBlNvDhzJ6M-cs6UMuzz
  OidM-aw5XA63Og6oG1lyt-D9caqbb4VTFqDZxdlWGPri3Q",
        "EnvelopeId":"MAJ6-DLC2-RXK4-BWGT-U4BI-LQUE-TD3I",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MCEO-7AAO-CBE7-72WU-ULJT-7GZX-FEZB",
            "signature":"2hkU28A2YPz936ULoRfI_OC1KyEPVenCyc3scNEY
  acg3rXRPMhL9ZPUSdLx-n0QvYfhaAfWmcYsAcc0Yh-ipL2zuX9HcdEShetRcmkSzZ
  S9_mswT63EiwZAj1CwwZH2DWvaWnioQIeCciM4JuLHFoD0A"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQjYzLVNXMlctUF
  g3NS1WU0ZQLTdEVFotSERBMy1HTUZOIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTZUMTM6NTM6NTRaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2021-09-16T13:53:54Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5CNj
  MtU1cyVy1QWDc1LVZTRlAtN0RUWi1IREEzLUdNRk4iLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUUtVTRTRS1MUTNKLUdBU
  k0tVjdZTC1LNEVYLTZBWkciLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  E3TC00SEZPLUozUFItUE5GUC1VWENELTZSUVgtS0I1UyIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFCVVUtMklVQi1UNjNMLUFTTzQtRVNJWi1FSks2LVNISVUi
  fX0",
      {}
      ]}}
~~~~


