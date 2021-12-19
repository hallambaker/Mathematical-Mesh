
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQL-ZUO7-WENT-VXQ6-CDUT-OZLB-KWJO",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"KL4lvGXiJosyeFLvDTxd_P3Ijx9TH9m-NeXhOt63
  RTJyyMhFXNvt2KQE4OmMPRJz9sNGbTJ52lqHztl2TO_yZQ",
        "EnvelopeId":"MAUL-PVO6-HFUL-QOK4-N3WS-E2MP-FFCP",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MBSR-GKG7-UE3F-S3NL-AADL-VGQV-CGUV",
            "signature":"AD_38nOxoSgWOgj6t1BQCYC6eu_FcAVFnA4jmKqT
  wH8LOkLKA2_xcNc1ucQvqzSw4g7_KOKWlCmACsLYDa4E8pKMHk0QCnOnzqe4Dp0wb
  zyZ6VHubp-iuoHCUnOVLOfap07chfzUsHrd4Xc654RDDgUA"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQk1ULUQ1RDctTk
  5QSS1NU0ZTLUpVWkUtUk9XVC1DUEdUIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMTItMTlUMDI6MTY6MTBaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2021-12-19T02:16:10Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5CTV
  QtRDVENy1OTlBJLU1TRlMtSlVaRS1ST1dULUNQR1QiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUwtWlVPNy1XRU5ULVZYU
  TYtQ0RVVC1PWkxCLUtXSk8iLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  RIUC02STNOLVhXNEotWU1ZNC1ZSUNXLUhVUDItUU5GRCIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFDQlgtQTcyUC1XVFhRLUpET0YtSExMNS1aN00yLUFUUEsi
  fX0",
      {}
      ]}}
~~~~


