
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQJ-DQL4-6E2J-BBSS-4UGU-4IKV-YYQS",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"nagzOQlY-KxAriRZPASovkM06G42Ts4t-o1uNeOx
  6nJuLZ0h49C8J8vbgSQTh3bqygYzL8sWb3NZWrRuozolpA",
        "EnvelopeId":"MAZ6-DRIR-4YUY-6OQ6-CBP5-6U53-ZS6Y",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MD5U-ZIWM-OOMW-O5N3-F7SJ-VF4G-I35O",
            "signature":"LJ27wRMocc53-H0wGllOpXcjw0lKGcyJT4P_PqtP
  iTOldGs9sZpa7PsBx7-hpUsHewc1bHiBbpgAefe1BzDhjYDwHtPNCRahkJmhaYiM2
  GHZM7XlYguBPXxyDHN9wHKYwbveStz6Zq_my3CR4seASiMA"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ0M0LVNORk0tNE
  dBNS1KSkhOLUFFMkwtVFJOMy1QN1U1IiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMTItMjJUMDE6MTM6MjVaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2021-12-22T01:13:25Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5DQz
  QtU05GTS00R0E1LUpKSE4tQUUyTC1UUk4zLVA3VTUiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUotRFFMNC02RTJKLUJCU
  1MtNFVHVS00SUtWLVlZUVMiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  Q1US1UNzJNLUxVNkUtV1dYQS0zTk1ULUgyNkMtT05ENiIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFCVzYtVVBLWi1YVEg3LURYMkItQk9JUS00NjZaLU1XS1Ei
  fX0",
      {}
      ]}}
~~~~


