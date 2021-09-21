
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQA-YMC5-YUXV-ZHIP-N7QF-XMC5-EUM2",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"5HiTFnMRkUle8WMYTPI_I-CrnHk-UplT1oejzpB-
  lWtAJEVrLBZco3JG0STHmrQMYSi-B2En2AijvEljfLvzXg",
        "EnvelopeId":"MDJD-PERL-HMRE-Y66P-4JXN-HMWQ-ROVZ",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MBRB-NDTB-27WO-3QAI-WWR7-7LWX-B2TC",
            "signature":"33hfejyBXIXMBm9kXbiG5t07e6d8mcKs9c_iKBxA
  2xO2leOGo00rOEHMdls8HOBSKLPsTlA4McGAZQ6Som9tzi9M0hDcy8t8yPZ_G92DF
  LphyQHT_wgc9fMA5lofeFmxImk4aGXlqpuu9wJydPBIvwYA"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQjJMLUNBWjMtWE
  8yUS1VVk9RLTNWUzUtVzNGRi1RWkpMIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMjFUMDA6NTY6MTBaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2021-09-21T00:56:10Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5CMk
  wtQ0FaMy1YTzJRLVVWT1EtM1ZTNS1XM0ZGLVFaSkwiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUEtWU1DNS1ZVVhWLVpIS
  VAtTjdRRi1YTUM1LUVVTTIiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  FRTi1FUDRHLVNGT1ItTlBVTS1JWlBSLUZSNEotVFBWRSIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFDNVItRDJENi01UlBFLUJZUE8tNkxZNC1FMjRMLVhVWUQi
  fX0",
      {}
      ]}}
~~~~


