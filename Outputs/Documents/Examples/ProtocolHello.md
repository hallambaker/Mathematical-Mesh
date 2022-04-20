
The request payload only specifies that is is a request for the service description:


~~~~
{
  "HelloRequest":{}}
~~~~


The response payload describes the service and the host providing that service:


~~~~
{
  "MeshHelloResponse":{
    "Status":201,
    "Version":{
      "Major":3,
      "Minor":0,
      "Encodings":[{
          "ID":["application/json"
            ]}
        ]},
    "EnvelopedProfileService":[{
        "EnvelopeId":"MDSK-EUHS-QXGD-LKOF-AVC7-V2RH-LV6Z",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRFNLLUVVSFMtUV
  hHRC1MS09GLUFWQzctVjJSSC1MVjZaIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMi0wNC0yMFQxNjoxNzoxNVoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1EU0stRVVIUy1RWEdELUxLT0YtQVZDNy1WMlJ
  ILUxWNloiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJVdVdEOHF4ZGVxazZweVdrb3o2M3FCcEpQQ2NaT2ItaHlTWV
  FiX0x4NWZHZllPb1U0Z0I3CiAgVjZWYXVBZkctdUlCREJNcWcxUW1jR1FBIn19fSw
  KICAgICJTZXJ2aWNlQXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTURB
  TC1aSTVOLTRVS1otSDZWTC1GMjVLLVBITkYtWlVWQSIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgIC
  AgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiZDNibl8tcUVWd0J
  NNjlaOTNLYWJuM01xU25jOUdRRGxGVDJfUmN4NXRWUm1lYl9iank3MQogIHZTUlNr
  M1pQMDREajJjVUJNNEFnci1vQSJ9fX0sCiAgICAiU2VydmljZUVuY3J5cHRpb24iO
  iB7CiAgICAgICJVZGYiOiAiTUE0Sy1FVkNLLTM2T1otVUhTUS1TSExLLTM2TjMtWV
  c3TCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWN
  LZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAiUF9vd1dHdDd3ZHR1dmNzR0NQZlFvOHVGNUNGWEcyUlB3Y1RCbEtac
  XgwVklmOWhwTWRleQogIHVBalJNRmVFNV8zblJtMHl3TDZ0a1VRQSJ9fX0sCiAgIC
  AiU2VydmljZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQUMzLVlKU1UtNDJ
  GMy1CQjRMLVQ0N0gtVkY2TS00SVhNIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiX3BUMGNtdzY2dWFRYmQwUWhFMT
  V5VXRtMVVEc2RvWjF6THRHcnFObkRmVGJoUThxVXFEbAogIHBQRzRmc3pJRmE5dml
  LWUU5MENCQTJFQSJ9fX19fQ",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDSK-EUHS-QXGD-LKOF-AVC7-V2RH-LV6Z",
            "signature":"aDhxhPphK2d1smZFTyaCfa-7l0LOty4A0ngIfur5
  gbKwsEozM5iTCZHV0HDZIqqnZ0THTzMpcd6AEwBm6SfRfClq1GjA6Eg_nzJkOWKVI
  v2m0ZWE5RnaIUclvg4lfn7t8NTbof2eryIv9qhR0_uyOgoA"}
          ],
        "PayloadDigest":"LJuCRu0W-vSJP0S2lHpEiW_aKliIb3wsYCpXOB5H
  x8nKOmFzeanUHVWNflPTxwFeoECpDf_-uQ5kI8-61oE_Xw"}
      ]}}
~~~~




