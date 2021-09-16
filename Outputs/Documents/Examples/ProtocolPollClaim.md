
>>>> Unfinished ProtocolClaim



The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQG-3JXE-WNLS-KULA-67M5-2UWD-DE4N",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"O038PA1wfJPmQ28VHRX8cPCj6JBpVSpFc9olybvc
  2DtwJrBM3EJJBEziEMgDD6xHOxo-e5I2ZmMLRtnITnJ9IQ",
        "EnvelopeId":"MC43-QK77-6DPW-PMPE-A3RX-ZQGL-7NKW",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MCQP-OYN3-STXV-QUWF-P3MT-3FXI-ZATO",
            "signature":"YAYRdn4MXAQ6ORKBq0OgXlqtxVR-kgxk6xLugvn3
  PgRPWEVWMRNNAt2gS3dBfOxpejM3FiAgJ88ApQcTXVuoovadfxqFXPu4_rv51BMy-
  E2r6wUVZR26Qb6o2yVjGb5C8FjpAu1g4B7sg1YLLj0-zjcA"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQklSLVhNQkstNF
  RPQS1RREJPLVhFWTQtRjJJRS1QVkpDIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTZUMTg6MTI6NDdaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2021-09-16T18:12:47Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5CSV
  ItWE1CSy00VE9BLVFEQk8tWEVZNC1GMklFLVBWSkMiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUctM0pYRS1XTkxTLUtVT
  EEtNjdNNS0yVVdELURFNE4iLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  FCUS1XQlZNLTYyVkYtN0RMSi1KTVNPLVhaQTctVlVMTiIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFESjMtNjNNVy1BS1JBLUVZMjMtUExZSy1BVVVXLUFGNloi
  fX0",
      {}
      ]}}
~~~~


