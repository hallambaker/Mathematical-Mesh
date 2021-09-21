
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
        "EnvelopeId":"MBWG-VSSP-FSJ7-TM2X-J4JL-H645-SCVV",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQldHLVZTU1AtRl
  NKNy1UTTJYLUo0SkwtSDY0NS1TQ1ZWIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMS0wOS0yMVQwMDo1ODozMloifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1CV0ctVlNTUC1GU0o3LVRNMlgtSjRKTC1INjQ
  1LVNDVlYiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJWQnRCVkhGaGx6U3RoajNoQTdKTG1YN1FIZGs5M2g2MUJ4b3
  ludWg3cUxJUnJNdGt3Q0dsCiAgcXdHZWo2OXZnZHM4VVhlR1ZFMTNlWTBBIn19fSw
  KICAgICJTZXJ2aWNlQXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJa
  Mi03TkNLLVlMSVEtTktJUi1MSllMLUhNNFQtSEhKUyIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgIC
  AgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiMmdzQ0NJU2NrLVd
  SY2JOT25xektkdzk4b0xUb3U3eENPS1NLdTJmV0RDdTFGSHJPNTVRQgogIFRxNllY
  Z1BpZkRjM19Nb2NsTnR5RkRJQSJ9fX0sCiAgICAiU2VydmljZUVuY3J5cHRpb24iO
  iB7CiAgICAgICJVZGYiOiAiTUE3Ti1YRjRPLVNRNlQtRVI3Ry01SUk3LUxSTUotRF
  oySSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWN
  LZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAienAtSDdmcE4wdllIV1hkeFRCNXQ0ekM5LUg3Q3FXV3IxRWhxNUlFd
  0M0TURNT2dTb0ZSTQogIEZPbUtoMHc2QkZXSUFfaEotSWROWGcyQSJ9fX0sCiAgIC
  AiU2VydmljZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQ0pWLVhBSVYtQ1I
  1UC1VRUI3LVVXMlQtVFdSWS1aU0dDIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiRHhUYng0bnZ2Y0czX3lXcmN5bm
  E3WVV4QTNIQklzeTlKaU1RQTJHRi1DTnFUeTRVOThiNQogIEZ0RWdMVU9MOWNELWZ
  2d1hVUXVMNW84QSJ9fX19fQ",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBWG-VSSP-FSJ7-TM2X-J4JL-H645-SCVV",
            "signature":"TcS-wV0HH1jCY8qAomsWVEq78fj_lKlpNBxzjg7J
  0IM3_MkPXtHfxYKaqxzAWjLZ9piWZ7gaS6CACjK24gQFNUEkeJR0EMNHHO1779MG5
  qNvCEv2IRkojAJIYeu8hFaiuU28MH1YXtMWBfAN9TSlmxYA"}
          ],
        "PayloadDigest":"8SBjpZmTJk-XCgmllHGoabDYtHD5IK36VGPbDvil
  XLEzxhA1YOKd2AQoAuUXZiElY9_HBa_3p3VXwrEkv1w19Q"}
      ]}}
~~~~




