
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQD-UFH5-2RXL-KFEY-UJ24-AF2Q-DCF7",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"iyyHcVpAGs3HkHBOKxQf9deVtMIHXhuR7MIc-CPi
  ZBeAAmc4ce7jMLYm1hJREmk1-3dmQXVelT7xXBUE2q3bpw",
        "EnvelopeId":"MDOD-CPDP-YNQW-IAAZ-YQZU-WLYB-ROAM",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MCSR-FPUF-3O3S-SMH4-E2EQ-NQOD-HJLL",
            "signature":"C7rmB5eVvLpjzk4i-s3NSZIkeK6SOHRemnzxPkC2
  V2R6Sj9NG85zvOtJj5GabbxNt-lOrv_fEWiAIq_0xIN7bL6bqIJoRI9sVknaM1vxK
  oDmqrlH6CH841jZMj9QQKr0EJdNGkre-w9hckYJw-sfvBoA"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORFpCLVhaRlgtMl
  JWTC1EMjYyLUFDVFEtTUFRNi1PQ0dEIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTZUMTE6NDc6MDBaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2021-09-16T11:47:00Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5EWk
  ItWFpGWC0yUlZMLUQyNjItQUNUUS1NQVE2LU9DR0QiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUQtVUZINS0yUlhMLUtGR
  VktVUoyNC1BRjJRLURDRjciLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  NEMi1XSVZZLVFYUVMtTFQyRi1BQVlOLU5URTMtVkdHMyIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFBTUUtUU5ETS1NTEdMLVI0TFMtS1ZGMy1FUUxYLTRUM00i
  fX0",
      {}
      ]}}
~~~~


