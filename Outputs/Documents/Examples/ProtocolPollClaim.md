
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQG-E423-3WIK-OA7H-O5V6-ROPV-M34H",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"3ZP5OvFXvo3PbBujm3sXpOMTgvMSKMQ7S_PwjvH3
  h_MUO2w4lrnwE4Q3wubK0cE8C6Nzza4x8Z5LGF4LjGzAXg",
        "EnvelopeId":"MDTU-Q2WQ-JMWV-BYUF-M65M-RUDX-Z2QT",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MAW4-D63J-XCVZ-KV3A-NOCU-R363-BRK6",
            "signature":"OQt5CCgRkP0AYEa4Cr28nVo49Mfb6etXQoth3vgZ
  ZuicV4Q6HBhtGVe3kS_YhgEvBh3BEI3oBt4A84fW3TBLfUaw8keoE_4OHgh2FSaCY
  2-JF--Sy_7rsF7ylB_0Uk3Wn1ndS9hx3nfF0A-fdtuo3h8A"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQU5OLTJOT1ctWE
  VTWS1EWEVWLUM2UEUtWE5DNC1aN0pYIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMjFUMDA6NTg6NTlaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2021-09-21T00:58:59Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5BTk
  4tMk5PVy1YRVNZLURYRVYtQzZQRS1YTkM0LVo3SlgiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUctRTQyMy0zV0lLLU9BN
  0gtTzVWNi1ST1BWLU0zNEgiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  FJNy1RVDZWLUlKRFAtWUxBNi1DTUZGLUxGSjItTlg3RyIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFBS1QtU0pRUC1WT0w0LTdRUVEtVklXQS1OWDVWLUdMTUsi
  fX0",
      {}
      ]}}
~~~~


