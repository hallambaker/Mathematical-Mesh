
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
        "EnvelopeId":"MBQI-PMGC-6W73-XR4A-XZY7-Z3KB-RYQ5",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFJLVBNR0MtNl
  c3My1YUjRBLVhaWTctWjNLQi1SWVE1IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyNC0xMC0wNFQwMTowNDoyNloifQ",
        "dig":"S512"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJTZXJ2aWNlQXV0aGVudG
  ljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTUNWRS1OMlVBLVpCWjQtTlo2My02V0Z
  XLTNOMzctS1EySiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAg
  ICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgI
  CAgICAgICJQdWJsaWMiOiAiY0w1Z2hVS3FPRGpDR05MUnFwNFVSam9lRktWNDZ4X2
  ZhcE9vRnJremdFRE9LUjF4NHgxMgogIE5SN1JySUR3OVF2QVRGZ3dkRTVjX0dZQSJ
  9fX0sCiAgICAiU2VydmljZUVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUNL
  Ti0zRE1YLTZLTzYtMzJLSC1IMkZaLTZUREQtVURaViIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgIC
  AgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiM2dJVS1ySHF3Snp
  ma193MFNCTDB6QVdGeDZGU3dvR3BBNlcwTnFsTmNoOEJfQVdoV3JVZwogIDZOX3lw
  aWIxWVFPeWlxR2pWeXV6MGhTQSJ9fX0sCiAgICAiU2VydmljZVNpZ25hdHVyZSI6I
  HsKICAgICAgIlVkZiI6ICJNQUNJLU9aSVYtS1lKUi1PRzY1LTNLU1ktWDZYWS1ZSD
  Q2IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0t
  leUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAiVTZhcW9wZWtscnNzNVRXUDNpODdkSGxvekhqMmpHeHJ0MUpNMng0a
  TVKRDhOTHptVkNRaAogIHVkNHFiOHU1REp0dmtZQ09valgyTE04QSJ9fX0sCiAgIC
  AiUm9vdFVkZnMiOiBbIllMMHZ2MkQtT1p0N3ctQXZzdUFPcVNjZWdrZ0NIaDk3b21
  hbEU0cGpoamNraVMtZFZXCiAgd3I1STI4U1Z0WXlRUHVJNmJmOS1kTlFXd0VNOHly
  UTJzdjZBIl19fQ",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MC6S-7P3A-7Y4Z-W66D-4AX3-FYAO-VETR",
            "SignatureKey":{
              "PublicKeyECDH":{
                "crv":"Ed448",
                "Public":"M0uhnXE73z0By9TtwOVVjuRbBRpjc_CWa4QZUH4
  I7pCijz0xDJc_xt1gY6nOUzACooGJ8LdA3vQA"}},
            "signature":"T5dT9Tkfs5IRkub_n8kDW-YlPmfYd96cZqfN2ho-
  tefzJVOgUvpkM5ELcZrfGliK1ObPggbxSseA2yLsZeTxlMJ3jDqw3t-eJkinqBqGE
  2Lf8Q4rHKH1QgP_dK3n-4eYVqC_0jYjs7dmgUut0D0hwREA"}
          ],
        "PayloadDigest":"CzaTQonTxm_SEDDGfoorBkLxCR9ZE4KIhexGLOLb
  kkYTHVAJJTP4-oH9pJ9oa-MHwupVvAIT66a5LYuFNSA45Q"}
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




