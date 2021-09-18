
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQD-KWTL-MLDJ-XVQ2-ZADS-O3JW-RBRX",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"ceTQbNwwgRfscCOLbFDPPQVT20F8EbqpqHlCxuMN
  CVMZ47cfi4NYgW_jyw1-stw7fZn4hF2GImyICZRbKU60Yw",
        "EnvelopeId":"MBPE-JORV-JYL2-V5B7-HI7T-RZK3-GG23",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MD4R-NGWY-UUD5-2PZJ-IPQT-664X-FF24",
            "signature":"sauuJTXevrJ2mpUbV4HHBPoYwnE78erMNmprRJTb
  SAvrnVD1PGPRg1RkvGi9WexvntlkWnuOUaMAy5Xz_zFWhFW7qsuM8PECM4o7UupBM
  9N_339dOQSucdUr6RE62IQudBSUcRwSP7AAr1QxNsWoBgwA"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQjVHLUVQNDItTT
  I1Uy01WjRWLUY1RTItVEtHRi1RSlpTIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMThUMTg6NDc6MDNaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2021-09-18T18:47:03Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5CNU
  ctRVA0Mi1NMjVTLTVaNFYtRjVFMi1US0dGLVFKWlMiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUQtS1dUTC1NTERKLVhWU
  TItWkFEUy1PM0pXLVJCUlgiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  E1Sy1RMkFDLUpMVlQtRk83Mi1ZUUI3LVE3WlEtSkMySiIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFESlotQ1FZWi1OTzdZLTZIWUUtTjNYNS03UFdFLVYyRVQi
  fX0",
      {}
      ]}}
~~~~


