
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQG-BJ6S-I2CP-QN45-AW7N-TYDI-ELOL",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "EnvelopedMessage":[{
        "EnvelopeId":"MCMN-LXWO-3I66-TGKZ-AC2K-UN7I-27HA",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ1NULUdIRkwtVj
  NBWS1YUUxBLU9XMkotVFhMNC1GVldIIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjQtMTAtMDNUMTQ6NTc6MTVaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2024-10-03T14:57:15Z",
        "signatures":[{
            "alg":"ED448",
            "kid":"MDSC-FB3G-FEPA-PXO3-MFLY-W5LR-WOBU",
            "signature":"RAzOknqZjiSFxI6sEPnrlPGAyH2tTwubV130YeGQ
  M3reHzeanS0tF5OEo_wegzm68sweXNAOcrWAmSCvUV2uwa4G1U6PGOl0dMMGqQV-p
  NJCpJ3oFsNTna1vcT4QltY15Ulgg9sI9rtEswKYT3LACRMA"}
          ],
        "PayloadDigest":"Jrdavuyp_J-l14_gKvK5nJungb2pvr5xG_ss44cH
  tpOJLw8pL7mWhE2cDc8DjMbeReGcnCilHJICxJbitoLhSQ",
        "dig":"S512"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiUHVibGljYXRpb25JZCI6IC
  JFQlFHLUJKNlMtSTJDUC1RTjQ1LUFXN04tVFlESS1FTE9MIiwKICAgICJTZXJ2aWN
  lQXV0aGVudGljYXRlIjogIkFDUFEtQlhCWS1KT1JSLUJRMk8tRjdSQy1CT0U1LUg2
  QkUiLAogICAgIkRldmljZUF1dGhlbnRpY2F0ZSI6ICJBREdSLVg3VUstT1JRUS1VS
  DZHLVc1UFEtQzZPTS0yS0NXIiwKICAgICJNZXNzYWdlSWQiOiAiTkNTVC1HSEZMLV
  YzQVktWFFMQS1PVzJKLVRYTDQtRlZXSCIsCiAgICAiU2VuZGVyIjogImFsaWNlQGV
  4YW1wbGUuY29tIiwKICAgICJSZWNpcGllbnQiOiAibWFrZXJAZXhhbXBsZS5jb20i
  fX0",
      {}
      ],
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


