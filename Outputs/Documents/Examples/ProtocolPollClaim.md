
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQG-ZKB5-KVJL-4LOX-3H4P-JJDE-424H",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"6SLWJ6pnM1-PhGPNxTFlOXRuE3WnH-upYxTptX5s
  GO1WGil4PgYjp01FR7S2Bps08vfZfzdju-twLoi7bAT0sA",
        "EnvelopeId":"MDEQ-3D47-HIBW-6572-KUNP-HOHK-5UMW",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MAOO-H5MB-HWN6-4CSS-SJF3-6RDL-KD2M",
            "signature":"0wQI3VBmywZaMDligeObVXg7KUtc1yeYWGsHVyWn
  Xk1A-m7FJXaMZurxgmdbqd3k9gVmNy-HLLEAYZ1O2RijYp7Y9DQKcitXxehGQtWoz
  NfzhFtSqV1lVTScIoLv0a0iEyeHHz-nrab4ONGAIEEuoCwA"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ09YLUlUQTQtQ1
  RTWC00REZPLVNBUlQtVFNMQy0zNTRaIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMTItMTlUMTk6MjE6MjRaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2021-12-19T19:21:24Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5DT1
  gtSVRBNC1DVFNYLTRERk8tU0FSVC1UU0xDLTM1NFoiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUctWktCNS1LVkpMLTRMT
  1gtM0g0UC1KSkRFLTQyNEgiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  RaRi1YV09ELVpIN0stTE1STi01VVRSLTNHQ0wtVU5SWCIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFCVEQtNU03Vi0yUVQ3LTRFNzYtSTZWTy1JQTVZLTNOUTUi
  fX0",
      {}
      ]}}
~~~~


