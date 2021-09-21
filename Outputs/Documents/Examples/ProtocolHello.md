
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
        "EnvelopeId":"MA4B-4QON-NA4J-JMDY-NVKM-F3FI-5CS5",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQTRCLTRRT04tTk
  E0Si1KTURZLU5WS00tRjNGSS01Q1M1IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMS0wOS0yMVQwMDo1NTo0MloifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1BNEItNFFPTi1OQTRKLUpNRFktTlZLTS1GM0Z
  JLTVDUzUiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICI3M2Q2Ty1ibFE3d0EtWkdibUp1OTdUSE9xcFROTGF2WkYxcE
  VvYVBJSUZrVzlrLVZQellCCiAgRHpLNUdXV2FMN2VxWjRPMGxady1VX2VBIn19fSw
  KICAgICJTZXJ2aWNlQXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTUNI
  VS1EWk9BLUxTN1UtUk9FQy1GSUZQLUVQV0gtSldPVyIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgIC
  AgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiaURULXZwdXNZRDF
  6cWdod1dwa2FVMDR5SjFRaEtrbzZ2SVFnMXNiN3pmWXIxWFoxZ2xqWAogIGRzZ0w4
  OXZISU1rZnhkXzRfdkk4WVRDQSJ9fX0sCiAgICAiU2VydmljZUVuY3J5cHRpb24iO
  iB7CiAgICAgICJVZGYiOiAiTUJCRC1SNEtBLVNSV1ItQ1lBSy1ER1BWLTY1TlQtM0
  VIQiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWN
  LZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAidmNGUHg0UFFxYkI4VnVCOUR6QzF6U0FZcS1EbWs0R3pHSnoxMHNib
  nhPQ2xwTEN0M1ZSWAogIGlJRnRmVkNhdW01V29IU1NFRDdFblJvQSJ9fX0sCiAgIC
  AiU2VydmljZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQ1ZOLVdTRlYtQ05
  FTS1ITU9GLUZFN1AtSkg0Si1YWjIyIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiQlBDY3NDM29JMEFYS211bGFGbl
  pSUDhoQll3VnNSSzBOTUhibWJuQ0FycTcwV2tIeVVwRgogIGxQb2RMd3lNd2t1ejR
  tWTg0ekV0SWEwQSJ9fX19fQ",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MA4B-4QON-NA4J-JMDY-NVKM-F3FI-5CS5",
            "signature":"5OwqBv4xRso6jp6gck56SYItu5vIWkrTQaHzqPQp
  fCIa-eGEN5qSsy-40tWGHd_98wqQkqpntJEA4T4g7Z0Bt3o9KKeE97U7nee7no8S_
  XNXh9pDnnyWCl_l4gxGi7gsgxBaEk_Rorf-FKPfogSOIR0A"}
          ],
        "PayloadDigest":"BzKXCBSIwEP17_eZjErEkuOVj3oGUH9QCg2DXPwd
  vzmB-L_UNhnas8lF8oH9FnoBGQDyG6Q6mw_EYWegUH0oaA"}
      ]}}
~~~~




