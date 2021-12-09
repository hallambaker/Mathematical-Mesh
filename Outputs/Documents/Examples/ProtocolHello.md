
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
        "EnvelopeId":"MB7B-JS7Y-IUYW-TKPL-Y5NL-JRPB-LTSV",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQjdCLUpTN1ktSV
  VZVy1US1BMLVk1TkwtSlJQQi1MVFNWIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMS0xMi0wOVQxNjo0NTo1NVoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1CN0ItSlM3WS1JVVlXLVRLUEwtWTVOTC1KUlB
  CLUxUU1YiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJEbXdnTGZVOXFQQzhrLXBBTVdRaU02UVdIeXpWVEgySjdRej
  ZXd3B2b1QyUVB3OTJkQVR0CiAgU2l1WUZQcVQ3UXpjaHBnZFFNWUZOMjRBIn19fSw
  KICAgICJTZXJ2aWNlQXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTUI2
  US1MUlBNLVhYUUotS0w2Sy1LSDZOLVpFUjYtTkIyRCIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgIC
  AgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiZ1JpR05PQzNUckZ
  KdnFwcm9QWFZnWGVpblZ3LWR6X244Vmo3T1dvWmNQWUNvdDVPMEZtQQogIDN1Tzh5
  c0NqdU1EbUZJbUV6QnVTRTNRQSJ9fX0sCiAgICAiU2VydmljZUVuY3J5cHRpb24iO
  iB7CiAgICAgICJVZGYiOiAiTUFMUS1RSERILVRLTUctTFA1Ui1HWVNLLUdJUDYtQk
  dIQiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWN
  LZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAiRVB4N2x1QjB1b1R1bHdIdUJjUTFfNWwwd3V2Sy1jVG9SaHc5MGhqN
  lMtR1pXdU4zc09QZgogIEZyeTFjamEtZDZEQmYxM1MzQVFqUjBZQSJ9fX0sCiAgIC
  AiU2VydmljZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQkU3LUZRTEstS0x
  LTS1NUEszLVlVNE0tR1ZPSy1LSzJZIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiblRFc3V4MThISHRUczRMVE5mcU
  gzWld2TmcwM2stbHR0RDZCVE1WUWZmdWx2amFYZUUxQgogIFdEa3ljVXk0clc5WUp
  ZdFRaZUU4RWRLQSJ9fX19fQ",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MB7B-JS7Y-IUYW-TKPL-Y5NL-JRPB-LTSV",
            "signature":"Wn6YJYikPCpVZl0kHNJ13FL9aTvuaySXQSnY7J0n
  Kt6UaJHHDJCOzUaBun3WlZLjw3Zv8Yv_G6CAQWvcPLeDY-YlQB1PwT3WJsB99Nstv
  qCbKp6O_-Sn5ZDzGRK5q4WWMSVkKx8rg4Pk5OeeqV7Tcx0A"}
          ],
        "PayloadDigest":"DQIUcXISKjbUWPxusx9E9f0PnuosWSelObWUn7Xg
  90I2fbzzZsK9OcHf1Zo-PdA1UB6RG3qACn0a9y1kWyEb6g"}
      ]}}
~~~~




