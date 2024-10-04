
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
        "EnvelopeId":"MBQB-N254-VJTL-CHYH-YJTY-5H62-RHYG",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFCLU4yNTQtVk
  pUTC1DSFlILVlKVFktNUg2Mi1SSFlHIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyNC0xMC0wNFQxMzoxMzowMVoifQ",
        "dig":"S512"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJTZXJ2aWNlQXV0aGVudG
  ljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTURJNC1PU1lKLU42NDctWEI3Ty1JSVY
  zLUhDQ0stSVBGNSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAg
  ICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgI
  CAgICAgICJQdWJsaWMiOiAiZ1JRdjNvNzZOVGprek9hU1JVbXN3dGlTOU9OSEZOOV
  VvNl9LeW16MFVUR1duZ0lsVXhDZQogIHQwQV9tTmg1TUZ1d3FNWGhlMTlYaUJLQSJ
  9fX0sCiAgICAiU2VydmljZUVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUFQ
  Ri1GTFIyLUZWWVMtS0tXSC1YSlFLLU41WEotWEZYQSIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgIC
  AgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiUjIxU3l6WHRqdm5
  aN0JOMmpBeTg1ZXFJc0pxeWdHdkpIb0hMWFMwMHRyd2JWRkpMQVlIRwogIEJWdE1E
  Rkc1WndHU3ZaR2l3Slc4SDctQSJ9fX0sCiAgICAiU2VydmljZVNpZ25hdHVyZSI6I
  HsKICAgICAgIlVkZiI6ICJNQ0VRLVRSRVAtTjdaSy1RQ1RYLUtLRUctQlQ0NC02Rz
  ZNIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0t
  leUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAidGVBby1vOVJQb0swOFNlT2RubG0yYUhIck5JZmJVY21qYzkwQ1pwa
  G1uNGNYQmdNMTBPUAogIFBkOFE2MTVqWlB3NzZmUF96UVI4cTJ5QSJ9fX0sCiAgIC
  AiUm9vdFVkZnMiOiBbIllMaWlTVUdEVnNuU05LWkM3dEVOREVGSm50SEtUbTBvWkx
  KQ1JUdTAxU2FZVTlvZHUzCiAgN0FMVXdOOHJTdmNRN09DMjlIc21QUkpqc1NRaHNr
  VXZIYTF1TSJdfX0",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MC4K-ESKB-QNLM-TURU-UZBO-5UIN-BRAU",
            "SignatureKey":{
              "PublicKeyECDH":{
                "crv":"Ed448",
                "Public":"oCwHW7lf0WuXCkCVLGc1VVY1TZDqNtyLKp1MrnI
  Gd3ViPg6Y-1_SPmMN_lbziFUsam_m2-C4Q-oA"}},
            "signature":"1r_Ex4lgbCkgrGMs6sWgw1ibQfgLOa52fqlWzKzg
  ELsJPU1BShnczIMmLrcfpmib4rpj48NIKJ6Aq1I_0tQRejGLFmXuno-LzqH0yNSkG
  Fn0sSPKJ5vibVcPBAsK6K_bHJVrIcWtSJ_bqbx3tg_Z5hkA"}
          ],
        "PayloadDigest":"PLZ-Fkklmz3jg_-KTRB4t0zgs5gRPmTHmdXDzxOI
  u8UprZwQkm7ulABMTa7kRnFE7_LiBvjcM55ggh4XgVAShQ"}
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




