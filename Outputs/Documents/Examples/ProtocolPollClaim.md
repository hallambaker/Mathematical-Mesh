
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQC-OKCE-7PPE-SQ4J-IY6Q-XGHA-OD4J",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "EnvelopedMessage":[{
        "EnvelopeId":"MAFW-3V3U-3EQO-GEQ4-RPIJ-NPIG-OZLR",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQTJBLU9ZMkktT1
  pHTS1RMkZQLVJJMkMtQkkyVi1JMkNFIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjMtMDYtMjhUMTc6MDA6NTBaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2023-06-28T17:00:50Z",
        "signatures":[{
            "alg":"S512",
            "kid":"MDE2-MKMI-773P-GJ3F-YYAI-UVCK-OMKS",
            "signature":"AVvfeF9kk8VekNI1EIi0qISa7yRvOWccRXxqf2YJ
  zEotsx4ARBhGJ5GGI3KCWyy1Ejq1ZLxW2xMAcypvT6OxKRhscsvdphabQRSJdztgc
  9SYCxbU5q8N4jQ-CwMlYLQssQVi6AiKU0pOh9DzPeUiKREA"}
          ],
        "PayloadDigest":"A-z5xIvCyoCCIcWvFZGshgLRFxI6SHPXgRdYidy0
  CHfIQSh0gShhJQPm0IWemu7IdFr10Q65Qj231ngp78TK7w"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiUHVibGljYXRpb25JZCI6IC
  JFQlFDLU9LQ0UtN1BQRS1TUTRKLUlZNlEtWEdIQS1PRDRKIiwKICAgICJTZXJ2aWN
  lQXV0aGVudGljYXRlIjogIkFESVItUVcyWS1ZRURULUFYQUMtTE9XVy1NSEsyLVZS
  T0MiLAogICAgIkRldmljZUF1dGhlbnRpY2F0ZSI6ICJBRDROLTJFTlgtQTQyUS1QT
  k9ULUdWQlMtRERZRC03U1FEIiwKICAgICJNZXNzYWdlSWQiOiAiTkEyQS1PWTJJLU
  9aR00tUTJGUC1SSTJDLUJJMlYtSTJDRSIsCiAgICAiU2VuZGVyIjogImFsaWNlQGV
  4YW1wbGUuY29tIiwKICAgICJSZWNpcGllbnQiOiAibWFrZXJAZXhhbXBsZS5jb20i
  fX0",
      {}
      ],
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


