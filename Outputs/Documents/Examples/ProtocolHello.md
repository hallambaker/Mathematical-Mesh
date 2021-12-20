
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
        "EnvelopeId":"MCMP-LOU5-4CBD-VDOW-2FCF-CCCQ-GESF",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ01QLUxPVTUtNE
  NCRC1WRE9XLTJGQ0YtQ0NDUS1HRVNGIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMS0xMi0xOVQxOToyMDo1NVoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1DTVAtTE9VNS00Q0JELVZET1ctMkZDRi1DQ0N
  RLUdFU0YiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJVNzVyLVN3bEJsU2lyVHlxUGJhZVZwWGVrT3k0WlJsSl80RV
  hKeVR5VWhaNWVnZlFKSDYxCiAgbmlWUDJfaGJMczMwLTlfTXl5SU5lNG9BIn19fSw
  KICAgICJTZXJ2aWNlQXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTURD
  Si1YR01NLVoySkwtTjZRWi1HMjRXLUVVUEotTDJVSCIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgIC
  AgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAibWZZSUN6YlZXeC0
  3SW9UNzRDTWpNc0VzV2IzUy1hRVNzcFU0NXNZWkdKNlhuWWRJM3VITQogIHdJZHNv
  c19IQi1VbzNUemNWNmI2N3NPQSJ9fX0sCiAgICAiU2VydmljZUVuY3J5cHRpb24iO
  iB7CiAgICAgICJVZGYiOiAiTUMzQS1LNFA3LVo0QlktWDc1Wi1JN0RPLVFOWkktUz
  RUTiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWN
  LZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAiTlJUd1JJWUF3Wm9VVl9odWtJX0pfdlc0MzFoaTA0S1RnSlR6YWI1T
  VAzRkxmRTdXZkNvbAogIEJheS1wM0ZvVlQ1dHJaM2t2M0tkRzNxQSJ9fX0sCiAgIC
  AiU2VydmljZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNRElKLU9VMjctUFN
  WQy1aRUFZLVJGUTUtNFNXNy1IWVBTIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiTmdHcTRiU2NqLUk3UzVmMmpxZE
  Y5QVJLQ042dHMwNzVfVlRkTnhuVXRQQ3RNOFZaWF9jbQogIGg0RUZGRWtNNWtINnI
  yTEk0Mi1zOHktQSJ9fX19fQ",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCMP-LOU5-4CBD-VDOW-2FCF-CCCQ-GESF",
            "signature":"YlylasIr-U5PiXhc_SswUeMtDvlb9SVEO9VTiMde
  ZLZ9lPJKRYXQgwM5FEPQ3bkbOAFeCgU6ASKAHoGkZVd9B4CfZZaj-vnbig5s2swCx
  Ut_avk7lMPxDdAwCu_RWsP-4jlcHp-o5k8zCi_9BRCzcTkA"}
          ],
        "PayloadDigest":"b_PJgSwYicDSZp-9Q97jrAqAqKgIF7kfYIH1AOPR
  _jxEo-7xTdb2rrmizcQGq4W1OmCq7_tRJbVBRqtndE4dnw"}
      ]}}
~~~~




