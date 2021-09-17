
>>>> Unfinished ProtocolClaim



The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQD-PLUZ-H4AM-JCPY-X6G3-MGJL-YR5G",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"OCx9mZqjpsDSJ_-CepsTlNlLwQHFnvxlCEmlu8Kh
  qXuCDbKf6vYU7pknml0y-WS-UYn3a_z_Y-mCvLOjdla0SA",
        "EnvelopeId":"MBKH-52P5-CTUG-LFXZ-VOAK-2OEI-NZM6",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MBXG-VVRY-O32J-UCO7-V5HO-VG4S-SBNU",
            "signature":"HSsDPntePMFk2Lo5hWmn7jwKtEl_3s3EkhaEBPlX
  HyQnBMKXKOmLkMIpilyUNaNSiVxRZyw7ZkGAoOqg0-3HFFSYAIRs0hhK1X0GH4xlq
  4UwJ05K8dc8x4GsjxDZbIdEJIhuuuBZYaVc6SYonNjP-AQA"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORFNBLUJOVjctMk
  taQy1DTlVMLVlOQlItQkhaRC1PQ0ZKIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTZUMjM6NDg6MzBaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2021-09-16T23:48:30Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5EU0
  EtQk5WNy0yS1pDLUNOVUwtWU5CUi1CSFpELU9DRkoiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUQtUExVWi1INEFNLUpDU
  FktWDZHMy1NR0pMLVlSNUciLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  FPRy1KRVdCLVZQQzMtRFIyVi0zWVpELVEyVU0tQTVYNSIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFDVUItVzJPQS1YRFJPLVRISjQtNE5VUS03VFJFLVM0Vloi
  fX0",
      {}
      ]}}
~~~~


