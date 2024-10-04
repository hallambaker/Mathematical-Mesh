
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQF-ZJAA-XPOK-V4KA-5QXN-WP6F-PT7C",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "EnvelopedMessage":[{
        "EnvelopeId":"MAVH-I4MS-XFOH-VTT7-3AYU-J3YO-XQMS",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORE9HLTJDUUwtST
  NUSy1DV1lQLVFNSlMtWkNTRy1XSFVHIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjQtMTAtMDRUMTM6MTM6MTVaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2024-10-04T13:13:15Z",
        "signatures":[{
            "alg":"ED448",
            "kid":"MBAE-EXHC-DOEX-EMF4-VXOT-G32T-ZKXU",
            "signature":"8OEzUyz8x67dCBOnRs_WDaTwRBFWyhNPaBKJiTVh
  -Gci_HYXmZHXYYlgRPo1rE-8v-Bt97meVH2At-UNrUnvweciDNxVHVcdS0fuWRc2l
  qTO0Luf35sUfYZCp00B0wpDEUqnSbVltEhvT13ZOQ_44ycA"}
          ],
        "PayloadDigest":"4MMdD-oU3kaVP1PU9oNGRXDYeShs4Pa2Xk6E8p6c
  f2S-UQxuDyQ-DqY1K0fPr2fe9imQcOVftDwPKkUjrlXUnA",
        "dig":"S512"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiUHVibGljYXRpb25JZCI6IC
  JFQlFGLVpKQUEtWFBPSy1WNEtBLTVRWE4tV1A2Ri1QVDdDIiwKICAgICJTZXJ2aWN
  lQXV0aGVudGljYXRlIjogIkFCREYtUkI1Ui1NNTNQLUJHM1ItUVNWVy1RRUJWLUJB
  NjMiLAogICAgIkRldmljZUF1dGhlbnRpY2F0ZSI6ICJBQkxCLVlDQ1YtQzJXQS0yS
  DU3LURBR1ItQVNQTC01TTZLIiwKICAgICJNZXNzYWdlSWQiOiAiTkRPRy0yQ1FMLU
  kzVEstQ1dZUC1RTUpTLVpDU0ctV0hVRyIsCiAgICAiU2VuZGVyIjogImFsaWNlQGV
  4YW1wbGUuY29tIiwKICAgICJSZWNpcGllbnQiOiAibWFrZXJAZXhhbXBsZS5jb20i
  fX0",
      {}
      ],
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


