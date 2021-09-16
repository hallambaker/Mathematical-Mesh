
>>>> Unfinished ProtocolClaim



The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQO-LKVP-2NAA-YX3N-OWC4-2QKF-GPCK",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"06N-CogBU-PWMvmr2JbTVO0RyXxR3l8n73O7ADm0
  m8S0LJNLzQ6dP0AdWwzTecc63ydaVWSvlakfTac8oc7B4Q",
        "EnvelopeId":"MATD-N2XC-PCBT-K4SI-UUMD-MR4U-6BPX",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MAJ2-4LS7-7CU4-7QAD-RG2G-NURX-PGL2",
            "signature":"ko9O3mvQ13-zhiYRUsdaM-mYsrVOVQcGillwAaaq
  _EcG4WQQJ7Q3qo0IowoOWsEu4vCqTIalo38AorzKLYB7PPKJnoB1Cl2Y_3zS_NrCq
  YecxujnOG_wHPMnjv0AG7j3CPUCP_k7U5MNhL7J8EkZCAUA"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQllSLVhYTlItSE
  RVVi1LSVpGLVY0VFQtWUdKSS1BSlJLIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTZUMTg6MzI6NTlaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2021-09-16T18:32:59Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5CWV
  ItWFhOUi1IRFVWLUtJWkYtVjRUVC1ZR0pJLUFKUksiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUU8tTEtWUC0yTkFBLVlYM
  04tT1dDNC0yUUtGLUdQQ0siLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  RHSC03V0Q3LVZWR1gtUVlaWS1QSkFCLVNCNDUtN0RYSiIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFENlktTUg1Ri1QVlpPLURaQ0QtU0U1RC1JWDU1LUlENVAi
  fX0",
      {}
      ]}}
~~~~


