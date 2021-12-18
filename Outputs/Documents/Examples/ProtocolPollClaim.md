
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQO-M2NS-6AV4-BEC4-CBZM-DH7X-VTAO",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"VsR2nTKVewXHnM--nNKni2QArz6zOI-1xpWfIj5p
  EolqlSILJ1Bdtqtv8I-GVVyvoNfQbknsloT_M52jrz6iWA",
        "EnvelopeId":"MA6J-V5XE-YHSM-7DQM-TQWT-M2DH-GT4R",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MDO2-SNPT-H5ZY-U5HK-BPC5-MVGF-WHT4",
            "signature":"j-PmlnPB11PQbDWp2OBkls8yYp7fp_cv8WZ4SSGq
  56pT7XvKL25c8miXkIlftLn4d3AEb4UYqfCADK39gJtqG1ou_dEN10kyrrQwwG8nB
  pVShMnKtbyvpeJzJN05004tPADQbh4YnBRVLvzsKdxgDwMA"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQTdBLVdTMk4tTk
  ZWRC1KR0M1LUVUREQtSk9OSC1CV1QyIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMTItMThUMDE6NTc6MjlaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2021-12-18T01:57:29Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5BN0
  EtV1MyTi1ORlZELUpHQzUtRVRERC1KT05ILUJXVDIiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUU8tTTJOUy02QVY0LUJFQ
  zQtQ0JaTS1ESDdYLVZUQU8iLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  RXQy0zWk5WLVQyWEMtTlk1WS0yVVFJLU4yRDMtWlhKUSIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFCUTYtRzMyWC0zT0xYLVlaTzQtUFRYTS01RVlLLUhFWkUi
  fX0",
      {}
      ]}}
~~~~


