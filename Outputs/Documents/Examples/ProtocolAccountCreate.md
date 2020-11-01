
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
        "EnvelopeID": "MDEJ-JG5I-7KGQ-UV5L-ZAJT-EC4B-A3OT",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNREVKLUpHNUktN0tHUS1
  VVjVMLVpBSlQtRUM0Qi1BM09UIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiA
  gIkNyZWF0ZWQiOiAiMjAyMC0xMS0wMVQxNTo0Mzo0NVoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9
  maWxlU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1ERUotSkc1SS03S0dRL
  VVWNUwtWkFKVC1FQzRCLUEzT1QiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI
  6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiO
  iAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJWejBqOTd3TVZ5VWJiLU9
  TUDIwTUU2clBFeTR3MkRTV1R6UFlCNV9JN1NOQ0VvSXgyZXNVCiAgcmNpdVZPR
  05NR3g5NW1UcENwWDJDN3FBIn19fSwKICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI
  6IHsKICAgICAgIlVkZiI6ICJNQUhXLVFFTzQtM0lONi1ETEJQLTJGUjMtNFgzV
  S1PVVg3IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgI
  CAgICAgIlB1YmxpYyI6ICJ2US14aklRbFhkYS0tQjVEb2lMTEtrbmxUcndqNV9
  6VE5WTks3ckR0OWV3QlgyQXkxdnhRCiAgRlhxZWJGa2FWcFZ0RG00RXJwZFRKV
  2VBIn19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MDEJ-JG5I-7KGQ-UV5L-ZAJT-EC4B-A3OT",
            "signature": "4Z-8akDlfC8zKzWOrnGs6kvv7g3bMHFfkM5v43qI31p9TPDR8
  i3lJQX2Dhc7UVQ9Z9NcCmYoZdyA9_qOC_qv5DAIP_ZueML9CoKFMbBlu_Yskvv
  T9nndwWlwpBxgHzXj5OWf4SRf4r6zUyvFlRjeOzkA"}],
        "PayloadDigest": "-O7r_l5kpCdSpSc-lB19EeeR7xIYBcvoFVlXe1uY33CJi
  HOT_kaFkQywIZIbPIbjtFN4Wy2RRXW5tQZy5T3Vqw"}],
    "EnvelopedProfileHost": [{
        "EnvelopeID": "MCEA-RIKV-5AIQ-AU4I-ZBIX-3B27-HTE4",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQ0VBLVJJS1YtNUFJUS1
  BVTRJLVpCSVgtM0IyNy1IVEU0IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Uhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0xMS0wMVQxNTo0Mzo0NVoifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DRUEtUklLVi01QUlRLUFVN
  EktWkJJWC0zQjI3LUhURTQiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJNS0xZRmdlbXEyWGxwOG9faFB
  DVnBvV1htVG9uY3pMazhrR0ZhWHQtNGM3aEtYLTFCQm5GCiAgbjRCWHJuY1E3T
  0hHNTZjVGt5aWRlM21BIn19fSwKICAgICJLZXlBdXRoZW50aWNhdGlvbiI6IHs
  KICAgICAgIlVkZiI6ICJNREJXLVFTMlctMk5MTi1RREVSLUtRRk8tRU5LMy1SQ
  VlFIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymx
  pY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJUT0lZNUdCR2xDTU53dXBCNjNyOWQ4Yzh4bDdYazNNbHN
  PMjdnLXNhdjJ5UDRGUkJnbWhLCiAgajdmUmVsYXhFQ1RGbnpsc1RzWjlCNm9BI
  n19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MCEA-RIKV-5AIQ-AU4I-ZBIX-3B27-HTE4",
            "signature": "bVfvH8UkSYywSxPoojWHn_oAdQM9C6bt-KqJtHrOu_wRPRRDt
  x0G46QqaJ5Fj9YFUoAcZxxYh5oAvxctJUCm2ZS7XWAN8EtcWMJwuSLRYkxmNNo
  YZe8HHDDT0GuWXcbmMFD5grPKSdmT1Mog7fm0BR8A"}],
        "PayloadDigest": "NTuBDWdUPo1ZfcMLiokk998WCQZCoFRDR_9HFuBuElCAS
  OOAnXkkaQ5ghpbFgaWypp6UuKM7FEb5-7rgavvTIg"}]}}
~~~~

