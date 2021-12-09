
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQG-PIN7-QL6B-TJOP-UPV2-O4OA-RM2U",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"DvkJj7SyTc7CgsWiXT2Tt1A-xkn9c0a397Ebswe1
  RYUXnlwr9NgwsLFIajMAi3MCVqlbSAovw37tZgSp-FpWpw",
        "EnvelopeId":"MB67-UVQX-J6CR-P4XX-PSGH-U7CP-ANCE",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MBYT-6KBR-3GF7-E3CS-HTYV-63RU-LUSG",
            "signature":"lFbww93VPOD07Cvq5fcDyatFecuc66s6_kEwVGo3
  P8cQUV2y6Uxab6uDJlAomYp-qOd2m1_0B1WARzwNeJiyfaCeAlslHDSTGAYQ_I7F9
  A5Eliy2lr3xMGjvAD1ahZqqCcXKGF2TK6s9vNANp_PLtg0A"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ0g0LUdSWE4tTU
  1ERS1VRFk2LUZRRFgtQUxLQy1NNVdIIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMTItMDlUMTY6NDY6MjJaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2021-12-09T16:46:22Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5DSD
  QtR1JYTi1NTURFLVVEWTYtRlFEWC1BTEtDLU01V0giLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUctUElONy1RTDZCLVRKT
  1AtVVBWMi1PNE9BLVJNMlUiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  QzTS1YTVJQLUdTTUwtQjdJWS1UUFVVLTdQTjctTU1YUCIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFES1ItUE1XUy01WkNMLU5RTDItN0xCNi1LUjVBLTVISlYi
  fX0",
      {}
      ]}}
~~~~


