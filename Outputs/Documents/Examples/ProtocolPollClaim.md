
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQO-YJMT-UGHT-OVEQ-NJGE-KUMT-VBWH",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"5XlnnypiWKWksAVpLj0qnHH4V59I_whujxS9gGew
  ut_qIjixK39qKvE15oEUvJ_i-oYCi0uwteI0VDlQ-ZGJAg",
        "EnvelopeId":"MDPA-DPWE-FCHT-C7WF-S5PD-CH5P-UFZU",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MC6B-Q2VW-SC2M-4357-CUXC-2MY4-USPV",
            "signature":"Q3Jpz0MB0p8HQF88oQrfS4w7hvdnUEdWFsBaXohi
  mm0if8XPiDUFs_kZmIymCHWhjj591YOVva2AFfyMCh5GNkOHTILifJ11_pd4hdVn5
  1ENVTuMKuPXzMyXPDisQ4Qjp5mN_0HEEBs4WmehtEnvPhsA"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQkkyLVNFT1ctUV
  FJUC1ST0pLLURYWjUtRk1SVS1DQjZaIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMTItMjFUMTM6Mjg6MzZaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2021-12-21T13:28:36Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5CST
  ItU0VPVy1RUUlQLVJPSkstRFhaNS1GTVJVLUNCNloiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUU8tWUpNVC1VR0hULU9WR
  VEtTkpHRS1LVU1ULVZCV0giLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  RWQy1JWFFZLUdWTUYtRFFSNS1YQ1hYLVFVSTQtSDdVUCIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFDSE8tVE00SS1DMkFBLUVWMlItSlJFTS1XSkhZLTQzMkki
  fX0",
      {}
      ]}}
~~~~


