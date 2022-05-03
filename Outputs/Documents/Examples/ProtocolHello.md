
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
        "EnvelopeId":"MD3P-ALTL-T6I4-U6ER-O4ZD-5AP5-J6SO",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRDNQLUFMVEwtVD
  ZJNC1VNkVSLU80WkQtNUFQNS1KNlNPIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMi0wNS0wM1QxNjo0Njo1NFoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1EM1AtQUxUTC1UNkk0LVU2RVItTzRaRC01QVA
  1LUo2U08iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJxQmdyb0QwRWhhMGlid3lMVXl2ODlwTGVSTTlqSXZkb1U0cz
  Q5cm96NlVwTWtyZmRkbzNLCiAgaFQ0MjNRVzNfNEpEbEhnQzZpYm5LakdBIn19fSw
  KICAgICJTZXJ2aWNlQXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJG
  WC1BUE1WLVpTU1QtTVkzNS1aTEtULTVRTkgtMjYyMyIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgIC
  AgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiMlo2YWlZU1JfUHZ
  VWEpvNFZyZ1ZjenNBVC1nLUt0N2NiMnpkTm0xdkF0a1pXb1dldHFTQQogIGJqczVZ
  a2ZPc2hPa1NjdUJaMXN4djBvQSJ9fX0sCiAgICAiU2VydmljZUVuY3J5cHRpb24iO
  iB7CiAgICAgICJVZGYiOiAiTUNWUS1NTlIzLTVGUVYtUExaUC1VWlcyLTRORVEtTz
  VQMiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWN
  LZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAiOU9VU0pEQVJPREVXaDVzWTBici1mRnRhV3VoQnM5NVZEdjRYN0dpa
  ExlZ2YwSENHQlZVTgogIGtQQzJYekR2eGZ0QTFESWZLeU5Ya3hVQSJ9fX0sCiAgIC
  AiU2VydmljZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNRFBILVg0QUwtVkU
  zWi1FUTNGLUpRSEYtR1lEVy1JQ1hGIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAidTdPSkNaSUVMVEgyMHZJZ0tQSD
  JyVV9ubmlocEpQaktqY0VuYlFRSVpBekFGY0xfU3ZqcQogIFBneDF6QUVwX1ZXYUl
  VR3Zqd3ZHWW1NQSJ9fX19fQ",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MD3P-ALTL-T6I4-U6ER-O4ZD-5AP5-J6SO",
            "signature":"vONJ_oKcxKzZw11S-eigtn6WhE8EGNLIBYdwT1k5
  txCNVlrx2ddEiJFY7RWg9SHa1jCWlP5veNIAOpNaZ6WmWrym6YEu0pJOBLgUsfoFU
  vlTDUsZTLMdlT2UvPAOld-f8hygn-ERhcuFyrwdJrYpmT8A"}
          ],
        "PayloadDigest":"9RBSd7OvF384gUIPcaLZOtdXFFyvO5BGzIAxaZGG
  fdOCPlwIxCLy1F3rJJlBz71zYw_jFOQ08HCwUUfjLr4dRw"}
      ]}}
~~~~




