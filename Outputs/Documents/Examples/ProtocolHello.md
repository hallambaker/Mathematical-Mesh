
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
        "EnvelopeId":"MBYH-BJ3I-EUWL-7QAI-NGIE-TPC6-X4KU",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQllILUJKM0ktRV
  VXTC03UUFJLU5HSUUtVFBDNi1YNEtVIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMi0xMC0xOFQxMjo0MzoyNloifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJTZXJ2aWNlQXV0aGVudG
  ljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTUI2Sy1EV05YLURZSTctU04yRy1IRVM
  yLUhWQ1MtTE9INCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAg
  ICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgI
  CAgICAgICJQdWJsaWMiOiAiZnNNZDlJRnNXcm5MUHJqVzQ3UlZoelJ6cXRzcFNCT3
  IxS2J6eXNrUkZodXVJd1hnSl94TAogIDlDb2c5b0RTOXBQem45a3o4cTRSc1FNQSJ
  9fX0sCiAgICAiU2VydmljZUVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJR
  QS1MSktBLVk3QVgtNVVaTC1IR1ZMLUNKRUEtNEVJNiIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgIC
  AgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiNnFtS3VOZjVPa1V
  LR2ZzdFpLczJIUmItT0U4SGg4RFFfNzR5SW9ZTTVNdGhaeVhrZno3dQogIC1TTTFx
  cHBOWHhDb3dRSXVZZ0dKX0hrQSJ9fX0sCiAgICAiU2VydmljZVNpZ25hdHVyZSI6I
  HsKICAgICAgIlVkZiI6ICJNQ0RWLVZOREgtR1VRVi03RkVaLUdHWEotWkw3WS1UTj
  JMIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0t
  leUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAiaFVoUnJHSDN1Zjc5UzZta3BqTERHbVU1ZEJGbGthZU0taE9fOVRnR
  zFyNDdmYUtUOG5nVQogIFJMOGRKYVo0QWMwTmZmbksxenJlYklhQSJ9fX0sCiAgIC
  AiUHJvZmlsZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQllILUJKM0ktRVV
  XTC03UUFJLU5HSUUtVFBDNi1YNEtVIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiR1gwUlJvQkNNY3A0NEYwWTlXen
  VZdHY3VWpMRm5ReU41NE9QZk96dURhTU00Y3dQS0x5QQogIDBCYnBHcVM4MXhHcFZ
  CTzg4bkZDck15QSJ9fX19fQ",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBYH-BJ3I-EUWL-7QAI-NGIE-TPC6-X4KU",
            "signature":"v68tamuXYkB5EQarVw791WZmN8IbeEt-GQq58TqX
  tMUlT7ETcYTQ-CmY4-ecysTLSKFxGRunevaA7rCej9jY-M0XkTz-xob9i_YMbIb-f
  CwdNYxmTPhun7IgvRxu0vyHXnE2HuLixlJNtoFXz-CbMyAA"}
          ],
        "PayloadDigest":"qmQy7M6DuCzRmEz2eeWpW0EuJTxd-qdX7ixMBwcC
  dpKlIPNN-fehLh5pLZKDAMueeRv1DQgoLeg7xyb-RSTetQ"}
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




