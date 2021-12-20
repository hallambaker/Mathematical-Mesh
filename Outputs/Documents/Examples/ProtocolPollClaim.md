
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQO-RY7U-EGFH-6FNE-CBGP-74YV-7VPR",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"F42C0hSoAhYKcavxXJTGGP-lf3GDzx_2iJ9n1yl1
  Qb2X-bYoDfciBO2UywTRvGFoBnztHmPfePjJalIA1JmtMA",
        "EnvelopeId":"MCOC-DETX-OQEZ-TEHV-J33E-5O4R-JYAC",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MCED-PMVZ-L4BE-WLJZ-2P4K-QINM-EHM2",
            "signature":"LzKgKDYJLN6QaiTcHO5YjhweaXT0ApmsKK5xth4O
  xH_dWeu2F3zUoSlV7xHKCG3FFeSMht_OawUAyag_AZRFdIUQI0dOe60ZZCaLs3rqn
  lC4y73PS24urOkbSK1z78OztdnHz8z_WwRvBqKmst9xGjkA"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQzI0LUhIU1YtTT
  JMSC1GTENLLVMzRk8tTTZRRS1ZSVRZIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMTItMjBUMTQ6MDA6MzZaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2021-12-20T14:00:36Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5DMj
  QtSEhTVi1NMkxILUZMQ0stUzNGTy1NNlFFLVlJVFkiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUU8tUlk3VS1FR0ZILTZGT
  kUtQ0JHUC03NFlWLTdWUFIiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  JOVy1CUVVILUxQNjMtTlIzTS1BUEZHLUMyNUQtV1NSWiIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFCNFctR1Q1Mi1aV1U3LUpVM1gtUlpENy1SVERVLVpBQkMi
  fX0",
      {}
      ]}}
~~~~


