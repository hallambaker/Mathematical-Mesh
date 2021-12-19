
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
        "EnvelopeId":"MCAO-XTIB-YRN5-OZY7-PQY2-V677-UTBG",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ0FPLVhUSUItWV
  JONS1PWlk3LVBRWTItVjY3Ny1VVEJHIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMS0xMi0xOVQwMjoxNTo0NFoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1DQU8tWFRJQi1ZUk41LU9aWTctUFFZMi1WNjc
  3LVVUQkciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJjRVlrSUg4VXl3V0hEaGYwcHhZOFIzMlBIdjNHcXpOeU9YUF
  pLbTZkZDFveFJEcmtaRGh2CiAgVENCbTZfd3ZXNmNwcDhfTUZSd1o3dGdBIn19fSw
  KICAgICJTZXJ2aWNlQXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJL
  VC1CSVVZLUdaVTctRldQUi1ZM05RLVdYQ1UtSkUyVyIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgIC
  AgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAic2pYRWktNzBWS1V
  uejA4VGZSNlJNdTBrTFlDUU9LbGQ4NFVZZnFqaGVNc0dhbmR3ZnVSbwogIGRubXp3
  T09ZYTVteWNiWUZrM3h0VHYtQSJ9fX0sCiAgICAiU2VydmljZUVuY3J5cHRpb24iO
  iB7CiAgICAgICJVZGYiOiAiTUFPRi1WMjNPLUgzQVgtRDdTVC1SQ0FVLVJVQTctNT
  ZESCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWN
  LZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAiUHYyenNiM29SZ2hpODlhV2V1VHpJd2dYdWFCcU5MV19DdV91QUdTQ
  UFVVExUUGlPMW9kcQogIG9UaUtranRDUXEyM2NETXZUVVFqcUM0QSJ9fX0sCiAgIC
  AiU2VydmljZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQjJZLU9JU0stNU1
  JNS1ETkFWLUJMTzUtNFFVSC1aNTQzIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiOUpMRnNSQ0xCT1dkM1NIdDY5Wj
  YtVm5PUXhvNkdnY1VsRzQzU3NXNHMxNXgtZ2hWTWlZUwogIFNkZmtsQXVxR3JTaHk
  4X3RuV1kwOFNjQSJ9fX19fQ",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCAO-XTIB-YRN5-OZY7-PQY2-V677-UTBG",
            "signature":"ZEh8Rakvj74bnWApTMv1YV-2YuJSnS0zRhQh9hpz
  YXsIhylvrk32J8ylUizCzwWTchq1YPmmvzwAqqaUIPnukcJc9xERBXFkEURhALdx-
  bdcGCcbU6xhYl-oSIFcB_t9Z9fs0e6gwqvE3X61Ezlv3yIA"}
          ],
        "PayloadDigest":"kAGdVz2XRQd6x0UenQ_6MlEhIIzNfEs-kqzLIdsl
  4IAXeRKJ8qYb6IKMne_sawVVGGqSFAEhTouqDFP1rF8jKg"}
      ]}}
~~~~




