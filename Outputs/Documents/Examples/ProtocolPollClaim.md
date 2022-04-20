
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQL-I4TF-ITF3-X4I3-QCHK-WK32-347R",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"B8c5TfDXr1GK6CgI8aFEXBWT35NCMN70f3HHreRr
  C5o5dGw04VA8YmUrW4tnSpYdVOBap0tSSQwGV8HnYVkd2w",
        "EnvelopeId":"MDLZ-5ED3-2Z6P-XJXW-THGA-Q37Z-F6VL",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MAMP-BX4G-AKK2-YHPA-IXJV-Z2KV-UXBW",
            "signature":"Fk2oDmBaKXmkf7vnvLHDNH8M6LRYHC1lD6VaypH6
  rgc0_uftuhH12Uitq0fgWMFNbvAyTaSdchKAPizuQisjvI_K5G6VOr8HnTft65UIW
  sFZjsj6vQjVb8j3oa5gCJPFQzbyn9khoO6irBTXGbfIJgAA"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQUZELVpJQjYtVk
  xaRC1RTzRPLTZDNU4tWUlJNS1WTEpKIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjItMDQtMjBUMTY6MTc6NTdaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2022-04-20T16:17:57Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5BRk
  QtWklCNi1WTFpELVFPNE8tNkM1Ti1ZSUk1LVZMSkoiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUwtSTRURi1JVEYzLVg0S
  TMtUUNISy1XSzMyLTM0N1IiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  RLSi1XNE5ZLVpSTEItUFVTQy0zT1NJLVVBREUtU0NKVyIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFEU0ItSjZZQy1CNVI2LVZKSUEtR1VMRy1MWklQLUFFVU8i
  fX0",
      {}
      ]}}
~~~~


