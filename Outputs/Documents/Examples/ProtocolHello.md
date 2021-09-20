
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
        "EnvelopeId":"MCZ3-M2PS-SFXP-4L6X-RKGP-MKJA-R5WK",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ1ozLU0yUFMtU0
  ZYUC00TDZYLVJLR1AtTUtKQS1SNVdLIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMS0wOS0yMFQxODoxNToxOVoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1DWjMtTTJQUy1TRlhQLTRMNlgtUktHUC1NS0p
  BLVI1V0siLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJWdkNVaGVxWG9NUm5wVzBrYjFaRVNlcE43cHhJZlcxMzh3VX
  loelFmY2hqQl9lVEpCMVVkCiAgV25XMVNraHk4UHYzMlp5VnE0WXdFbkVBIn19fSw
  KICAgICJTZXJ2aWNlQXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTUI2
  NC1GN0dMLTU1RFktRDVOVi1HSkxULVdUNTctRFc2ViIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgIC
  AgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiZjJ5ZHpJcW9HWkt
  3MEZaMG1YZ0pvcXBka3BMQ3RRVncteXdUbjJSYnh3Z0kxbUEwbGJCUgogIDU1MkFE
  cGlKajJSek5KYnRJQWVzVU1ZQSJ9fX0sCiAgICAiU2VydmljZUVuY3J5cHRpb24iO
  iB7CiAgICAgICJVZGYiOiAiTUNIMy0zSEpTLUE2UVAtUlJKNS1IT1JCLTNZVEItSj
  RXVSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWN
  LZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAiekc3d0VWcl95b2UxZWRIc084TjBTZHpldTFZM3phbkkzRU9rWVNCc
  WpXcU1KQmtYSHY1XwogIHBTa1BnT1VaaEViZjNoYV8yZmMzU080QSJ9fX0sCiAgIC
  AiU2VydmljZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQlVULUlQQlotUlp
  ESS1CTVNTLVZUTFMtTDVHUy1OMlBDIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiVDdDX2xfOURhRnZRNzNGUjk4dS
  1HdGRGVWMxdWQ1bFd6WXhZNS11TkZhQVFjUGtUdmJKUwogIHlqVGVYWXVWQzRWMFV
  jelNPbjlPbEpxQSJ9fX19fQ",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCZ3-M2PS-SFXP-4L6X-RKGP-MKJA-R5WK",
            "signature":"35JI1R3uB5lt3qDkIyD5JPNTRtaa4Jzyu5EMW5uk
  Z1seFoi6ph3h4qWb9aXEm_fJo-gERJTCEsKA2fa5WbP35NPF8bH6NCvVfWs-cdlCB
  PpJcw9btz1DEU3LjDsZinva--qe9j1JHV_aUQg9YuYMKy8A"}
          ],
        "PayloadDigest":"Ort3czll0X2Onn-pKQs2e8o9H0sekQO45Cgzv9io
  mG1MwNCptdzZOz-RVS8RX7T0kDjfejmC9cu_-56VxBmTSg"}
      ]}}
~~~~




