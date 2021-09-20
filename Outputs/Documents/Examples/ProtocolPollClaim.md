
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQI-T2FU-LP4G-KIFQ-PMYI-V6XH-PZLB",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"QeCfPNqPnIgnkZqOk5ocOCmmJUNa5Zj1DqhPE5OS
  giY_01726xlWNvmn10PwOwdQsuQpgyRxASzsi5z5yRMcwA",
        "EnvelopeId":"MADV-CBSP-N4SR-6JQD-7ONP-P5EP-TZ47",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MCUM-SQ35-ZJUQ-TMTK-HB4X-57QQ-YK2Z",
            "signature":"WmjtRkJpq6QiqLNxY_ljzSrAUO-BzxDqK9yT-HB0
  gN1TdLw93Jsj2vkIHsdQOMmVbullSyjK66OAodsKV-DEPP2EUPHA7_iNu6HwHoOaa
  SJvtUhBaiYirIe8_-ufIpfZfRxZbQdrU7uIsD78Fw8JhBcA"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ1FCLVE1TDItQU
  ZCSC1OQjdFLUZFSTctM1FGRS1aT05TIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMjBUMTg6MTY6MzlaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2021-09-20T18:16:40Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5DUU
  ItUTVMMi1BRkJILU5CN0UtRkVJNy0zUUZFLVpPTlMiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUktVDJGVS1MUDRHLUtJR
  lEtUE1ZSS1WNlhILVBaTEIiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  NLWC1EVFlLLVRNVkQtVDdRNS1GREs2LUlKUjItREhORiIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFEWkctVFZHRS1EUFFQLTRRNFgtRUJENy1QVVNRLUpUVE8i
  fX0",
      {}
      ]}}
~~~~


