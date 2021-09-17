
>>>> Unfinished ProtocolClaim



The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQP-LJ5U-LV2Z-2A3U-MUCB-5LEI-NVFP",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"-7CrSm3HJm7c3S2vwhI3kYcnBqvq1h7MU38xj7pH
  1rtWmkP4qcvxqsXy7BRhMo0ww6bw08WNU83vDu3oWXK6Ww",
        "EnvelopeId":"MD3P-4M24-X7FD-D22M-JGNZ-45UR-3FFN",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MAWM-77KH-5JB5-ZKBD-BKZX-BM37-SFMF",
            "signature":"UOqQ5vh4UnGG4sO52wSMTa70IRubasfnVZxl61_s
  EjIhgSD0Xy0X4P-uV7_k8pKW5sX4b6PbzokAjOP7aNCuDSCOEBbp7NtNcamb_WywH
  5mb42fcPCeP1CkL3WGLze68m7wRZndjuUd1qeRJy_9nfQAA"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQzNILUlDQVctRk
  NZWS02WVZWLURHSEMtT05LWS1XQkJTIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTdUMTM6MDg6NTJaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2021-09-17T13:08:52Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5DM0
  gtSUNBVy1GQ1lZLTZZVlYtREdIQy1PTktZLVdCQlMiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUVAtTEo1VS1MVjJaLTJBM
  1UtTVVDQi01TEVJLU5WRlAiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  NVQi1JSVUyLUkzUUQtQktJUy03TU42LVlIWlItRTY3SCIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFCQkotNUFURC1TRTRZLUZVTkYtNjNXRy1ZU0hULTY3QzUi
  fX0",
      {}
      ]}}
~~~~


