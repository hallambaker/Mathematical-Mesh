
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQB-KJVT-BYND-4GE2-U65R-FZFH-4C7O",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"5rbP0ACwMxu-M8RKeXElgiEFeiCMtvhmaUfryItH
  dvjWhzOrpcTiTjE8yjyFEOZ_jBQS6fXec9IYSDnmdA-gIQ",
        "EnvelopeId":"MC4E-5C44-IEHC-EEKA-KPSY-YGMQ-54HQ",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MDWZ-36RF-622V-XT6X-O6KB-3S5J-4JE3",
            "signature":"IcU7z-AssGRaQXnR6p9Dx1hwrZBLmZutUe3jgHnX
  53-HTX1cQeQp8QYDHB-GxpOGVsS91LXNMQmA8keb0exzT8xdnOX6J1I7mXcG12nvs
  i6fUDkXOcc6Yl8OXw6UpoiK75I1f8Gu1UDj6x-Zado4TTEA"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORFo0LUxHWE0tVz
  dKSS02TlJILUkyQVMtVVBVQi1RVUJMIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjItMDUtMDNUMTY6NDc6NTdaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2022-05-03T16:47:58Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5EWj
  QtTEdYTS1XN0pJLTZOUkgtSTJBUy1VUFVCLVFVQkwiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUItS0pWVC1CWU5ELTRHR
  TItVTY1Ui1GWkZILTRDN08iLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  FYMi1QQVk3LVFCUDYtTUlGNC1RNkNQLVJHUTMtWFlUNyIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFEWlItQzQyRS1PU0dHLTVBUFktUlVXVC1XQUFMLTZJRFci
  fX0",
      {}
      ]}}
~~~~


