
The request payload:


~~~~
{
  "Hello": {}}
~~~~

The response payload:


~~~~
{
  "MeshHelloResponse": {
    "Status": 201,
    "Version": {
      "Major": 3,
      "Minor": 0,
      "Encodings": [{
          "ID": ["application/json"]}]},
    "EnvelopedProfileService": [{
        "EnvelopeID": "MAN7-GQ3M-ALG7-3YGM-AJEF-2W5U-LBDJ",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQU43LUdRM00tQUxHNy0
  zWUdNLUFKRUYtMlc1VS1MQkRKIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiA
  gIkNyZWF0ZWQiOiAiMjAyMC0xMC0yOVQyMjo1NToyNloifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9
  maWxlU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1BTjctR1EzTS1BTEc3L
  TNZR00tQUpFRi0yVzVVLUxCREoiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI
  6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiO
  iAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ2UHhKWVktTUxfalRMc3Z
  jQUoxQTlBVHpzZU1DWGFUazNUQ3dRMnZuRkJYUUJpQ09hYWVoCiAgTXk5VkZhc
  FE5bjJJNEZ4TDAzM1pyaHNBIn19fSwKICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI
  6IHsKICAgICAgIlVkZiI6ICJNQlFVLVdBVUItSUxXWC03U0pSLUhFNTYtREVUU
  C1IWVdSIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgI
  CAgICAgIlB1YmxpYyI6ICJ0V2QyalEtU01jX3NRS1BQdWlwemxYSTBXM3JtdUl
  JeGNpQjBWbF9tX3BiYWtTeVk2ZkhyCiAgZEs3VnpPUG9hWEtKOEJETVdLUllRX
  3VBIn19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MAN7-GQ3M-ALG7-3YGM-AJEF-2W5U-LBDJ",
            "signature": "sg6VHM8I1LfVi2Aj1fwhoeTY6IpVVfNbRiFTxZc8t0co6rsms
  Kl4RloH4Br5ZT-vihulI1zz-CKAuYspDbotxizsuBtGszz9Fu_5cuZKd6DCH3e
  D272SFgyU5GhK7ftnVzh1qW0W5zvG2NOPKHy8wTMA"}],
        "PayloadDigest": "-yym-4CmT2dQiOONKPnub1rdmI7BB8LJITLwK1X1412iP
  oDjyl7li3LbNBq1Nf6TxxLUZUoMmr8ufwD7Qnsh0g"}],
    "EnvelopedProfileHost": [{
        "EnvelopeID": "MDZ6-BDEP-62IE-MLRL-MYFP-XCIB-M2LM",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNRFo2LUJERVAtNjJJRS1
  NTFJMLU1ZRlAtWENJQi1NMkxNIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Uhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0xMC0yOVQyMjo1NToyNloifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1EWjYtQkRFUC02MklFLU1MU
  kwtTVlGUC1YQ0lCLU0yTE0iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJhNUpyWG15MTJGYVBjRTlFN1Q
  zZ2pxVWFDSkdRX2ZUaFY3cFpiQy1VU19VMEpsNWl2Y1dHCiAgQnVtczU5V21Md
  HRlOW9RUmIyb2Zxd3NBIn19fSwKICAgICJLZXlBdXRoZW50aWNhdGlvbiI6IHs
  KICAgICAgIlVkZiI6ICJNQzdTLTNUMkQtN0xaVy1OTFo1LVNRTDUtSTdFRS03T
  zJYIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymx
  pY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJtcHNLN2NVYVVpTHpRSjdwcnZGN0FoZTdmb2FUYldkbDN
  HZV81MWNOWkpiYzVuM0V0MnlMCiAgLTl2bWhGWDdVdVdiZURMNmpnLWxCcy1BI
  n19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MDZ6-BDEP-62IE-MLRL-MYFP-XCIB-M2LM",
            "signature": "8yZ0nIDkptW-P7Oyx-qhRX75hc-tT0SrQjShIyOeKw1qaaDdA
  GTbrwS6pmwTmJWDQ-Cub54LiY4AA-nBkwFssQEobUHaAp5_egx5Q-5yf_xKTSS
  KuEu-BJwG0lsFUUoJfHH5jfOrUa_jncwrbPwpTSYA"}],
        "PayloadDigest": "VxXzAkH3PP7k6rtvU9Kri_hL4cDK-a7AvJBdizBm0sWDk
  iX2zgah9tKEIuc-qwmECX33cvSQwWqR83nr-lua4g"}]}}
~~~~

