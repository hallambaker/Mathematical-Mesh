
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQB-RDUZ-TWGC-H3AD-ZGID-HBMY-FKSF",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "EnvelopedMessage":[{
        "EnvelopeId":"MB5I-FTIV-J5IP-SE6L-CCSG-LIQN-235U",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQVNNLVVGNFUtNz
  IzTi1ZUldTLUhXWkItNUJCQi1WTjVBIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjQtMTAtMDRUMDE6MDQ6NDJaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2024-10-04T01:04:42Z",
        "signatures":[{
            "alg":"ED448",
            "kid":"MBJB-QS7J-ACZ2-FVMP-ELSA-EWGT-X4YW",
            "signature":"EdxiI4m_F6waudyOU7Aij0cIoIP8PxXRM2CDR8ft
  WII1AMqtdA8f0y5YU-wrlGry8lIh4ROBR2oApgX9q4bM_6x4L3zyO_JwbYTSqDVcN
  GCUJEeanlrI5apH0-FzWmLS1kbEFtDKGmrpRs13zTj2PS8A"}
          ],
        "PayloadDigest":"XpZP9bhsbvCMEK0B8gNwzoaLw3D6Xke6LBXPBxkD
  NodwXAF3JA_bsp41t81EAWdpHvSMn9GlmH_ISP7O-Cmc0g",
        "dig":"S512"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiUHVibGljYXRpb25JZCI6IC
  JFQlFCLVJEVVotVFdHQy1IM0FELVpHSUQtSEJNWS1GS1NGIiwKICAgICJTZXJ2aWN
  lQXV0aGVudGljYXRlIjogIkFBU0otNzRBRy1MQUpILUdNTUwtRUxOVS1EUjZNLVFa
  WUMiLAogICAgIkRldmljZUF1dGhlbnRpY2F0ZSI6ICJBRDM2LVRDMlQtNjNWSy1TW
  lNFLVFUU1QtT0hOSi0yRkZHIiwKICAgICJNZXNzYWdlSWQiOiAiTkFTTS1VRjRVLT
  cyM04tWVJXUy1IV1pCLTVCQkItVk41QSIsCiAgICAiU2VuZGVyIjogImFsaWNlQGV
  4YW1wbGUuY29tIiwKICAgICJSZWNpcGllbnQiOiAibWFrZXJAZXhhbXBsZS5jb20i
  fX0",
      {}
      ],
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


