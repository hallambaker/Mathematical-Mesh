
The request payload only specifies that is is a request for the service description:


~~~~
{
  "HelloRequest":{}}
~~~~


The response payload describes the service and the host providing that service:


~~~~
{
  "MeshHelloResponse":{
    "EnvelopedProfileService":[{
        "EnvelopeId":"MBQP-EWUT-UYX2-Q3GS-HB4O-3VBQ-IKP2",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFQLUVXVVQtVV
  lYMi1RM0dTLUhCNE8tM1ZCUS1JS1AyIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyNC0xMC0wM1QxNDo1Njo1OVoifQ",
        "dig":"S512"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJTZXJ2aWNlQXV0aGVudG
  ljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTUNURC1aVlU3LVJOMzQtV0xBNy1CMlF
  NLUtMR0stNVFNUyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAg
  ICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgI
  CAgICAgICJQdWJsaWMiOiAiRFV3UFJ1aTJST1I2X2RHSFlSbTNWdk1sQWVlSmYtNk
  NCeFhwbTliZ2gxakRTS1J2cXNRZQogIG05VEdlQUJWOHlQajdpWUxHWEtFakZ3QSJ
  9fX0sCiAgICAiU2VydmljZUVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUNT
  Vi0zQllNLTRTSVgtVlZKMy1BUTdILUZaR00tRDZCVCIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgIC
  AgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiLXBpM0E1X093U3J
  OeGNwaTJ5eEx0S2J4Y2tzYkExNDhBQXBHbUNwdWY2UndCcGl3S2dLagogIEs5Q29U
  VkV1dDdqM18xWHliUzJiYXZVQSJ9fX0sCiAgICAiU2VydmljZVNpZ25hdHVyZSI6I
  HsKICAgICAgIlVkZiI6ICJNQ0lBLU1OSEQtWllSUS00NlU0LVNLUTItQUdBRS1KNV
  dJIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0t
  leUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAiUUpianBNZVpiX3RlYkNId1AwNzNHSzA3a1d5Y2lTeDBzVTctMzI1V
  EJIVE9waDQ4OF82SgogIEMyZHZMcFlnVE1sdkZNcm9PWFc4bFFxQSJ9fX0sCiAgIC
  AiUm9vdFVkZnMiOiBbIllJaGlJN2ZtMXkxSU55OEp1MzFUaEpHTkMxNmRuTFdmdlA
  xSnM3U2xaR0NENUVEaE1sCiAgbmM5YWVUS3lhX2VtNFFWbFNxY05Gb0tUNUhXaWFY
  VkVQYWpRIl19fQ",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MCEG-EI5X-43LS-2SBX-F4E3-W7KT-QSIY",
            "SignatureKey":{
              "PublicKeyECDH":{
                "crv":"Ed448",
                "Public":"cQpsPo2qIfIdm6aGCmD4TAxMtePk0Y9Omz3rnvz
  BCcWhlQdjp70-Em-dlwwKo6BVWy0PQASMbDkA"}},
            "signature":"cYz91lAO5W-0Oe1fkhXG0x5NvmRmduH1jWkahwmM
  gjzoSiSFxbWY682HiKhelhmbxPQ9FHXauPAAmRjgFK-CyAm6OFTJfujViyEgmUL9T
  TfQ6D3N2klyv5_k3s7HxHp8TsG4RfRDDDezvrCj6hxzOCEA"}
          ],
        "PayloadDigest":"D_rL-4MgTubVp4aP27AKuDG2elqIYIcntnsoIKF2
  QqypjqB6uJQ3I1RjmhZem744foaUtfd3rvKOYuavNipxGw"}
      ],
    "Version":{
      "Major":3,
      "Minor":0,
      "Encodings":[{
          "ID":["application/json"
            ]}
        ]},
    "Status":201}}
~~~~




