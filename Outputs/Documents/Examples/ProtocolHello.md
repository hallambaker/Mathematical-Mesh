
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
        "EnvelopeId":"MBQD-ETXU-HZRW-A26O-WDTR-K7GI-X6JD",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFELUVUWFUtSF
  pSVy1BMjZPLVdEVFItSzdHSS1YNkpEIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyNC0xMC0xNFQxMzoxMDo0NFoifQ",
        "dig":"S512"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJTZXJ2aWNlQXV0aGVudG
  ljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTURZSS1JMkJILUhNTDMtSDZZSy1HTll
  XLUpKWEYtTlZESCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAg
  ICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgI
  CAgICAgICJQdWJsaWMiOiAiZ0g2UU15WXg1cWZPUmFOTnZzWnlSODNCTTBhbkVqLV
  ZxQ29MLTZrX0JoZEZZUThRcHJvNQogIDhwMGhyVFJNVExacnJCZFdwanRQS2l1QSJ
  9fX0sCiAgICAiU2VydmljZUVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUE0
  TC1VRTVBLUU0VkctVUdSSy1UVlQyLTNMSEctWTdOViIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgIC
  AgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiS1BybjZhUHRSSEd
  MYkkyYUVIeklfZHRQRGdhR01TU0x4a0RfZFdzVEJZVkUxS2ZUM2tBTwogIHFSMjlQ
  ODJDLU5ydFphcG53eFpmRlRnQSJ9fX0sCiAgICAiU2VydmljZVNpZ25hdHVyZSI6I
  HsKICAgICAgIlVkZiI6ICJNQzZMLVQ1UDYtVVpDUS1SUkQ3LVZNSk0tRTJLUS1BWk
  hFIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0t
  leUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAieTVhN1hYZG9mX0F6aTh1ZVRkZFNJWng5ZkZnRDdaZlhCVDktTjZlN
  XFlQl9wUXRudXJ5bAogIFJOeGUydzVIckNWOXNZejJqcjN1NFhxQSJ9fX0sCiAgIC
  AiUm9vdFVkZnMiOiBbIllCTGtrWFZRYmRxZWE4MVFWSWtwcHAwRE9CdHRKRmNvVEk
  3VVZld3JldU1CQUozejZuCiAgTW1mMzFGYjRoRnktT0pqWVdoOTVFMHNwTlV2UGpN
  anczTm9wQSJdfX0",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MAJO-JELV-KBW5-VHTL-ZVIF-JCJJ-U2OQ",
            "SignatureKey":{
              "PublicKeyECDH":{
                "crv":"Ed448",
                "Public":"HrzNjtG9zQoqxzKGX1fa5ewkB0g6P7HQfinZuUC
  Y_q4Ke778BqDQPwE8kpSgU7aulAUJIk8Ue-kA"}},
            "signature":"u2U3pzAR-p3SyPylngueVqwseBYnkzJ0cXSsmT5j
  yKqMNKLb6EIhA4Q_m9W4qaj5MfpkFwwI6kQA6Kh59w0zmMrPPfTgPE3mxCJ5qLj4S
  hkMMubJwSb_L4Ef8rqKSZ9vGHdEuTImoU1rFnQAHeorqzsA"}
          ],
        "PayloadDigest":"GpwjTMrI_kI51EPsErCiiBEe3XJXntbI2Xkd4uX-
  sW6Ix81ljSbMDnALW0hua0peCyMOVvBV2iyZb3cRnQh6mA"}
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




