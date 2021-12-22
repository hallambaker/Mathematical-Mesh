
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
        "EnvelopeId":"MCLV-U6YX-P3TO-X3VD-LIXM-V7ID-ZV7H",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ0xWLVU2WVgtUD
  NUTy1YM1ZELUxJWE0tVjdJRC1aVjdIIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMS0xMi0yMlQwMToxMjo1NFoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1DTFYtVTZZWC1QM1RPLVgzVkQtTElYTS1WN0l
  ELVpWN0giLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJfU25ZcF9lRjY0dUZDSEFxSkJRRlMxSkg1ZHlDUGNkZUNMcF
  l4R1lCQkQyLU5kSE05NENqCiAgODlFbWE5VlV1NTJ4c1h1bDlGV2V4M3FBIn19fSw
  KICAgICJTZXJ2aWNlQXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTURU
  US1BVjJKLVBYVkstSTQ1RS1ISDdYLUdTTzItMlhHRyIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgIC
  AgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiY1E3TnI3d1ByaHl
  GS3F4WFNFbnVoZktyaDJjN1haMHJONHVWVWQ2azRMVlJ3dVVoSGdKbwogIHpvM3kt
  LVVzLXhVcUNnNlVqY3Q3OG8wQSJ9fX0sCiAgICAiU2VydmljZUVuY3J5cHRpb24iO
  iB7CiAgICAgICJVZGYiOiAiTURIUy1RWVdBLUdXSUQtTFo3NC01TUVFLUVBS1YtUE
  RJMyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWN
  LZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAiaVpqVHBsbXVuVnpaQ19ZLTJJVzk5ZGUtbGhidm5CLS1WUmFZOFV3U
  2Z1TUlCblc4YnZETwogIG9aeVpVYTRWN0FGZ2YwNUJEdHR2VTA2QSJ9fX0sCiAgIC
  AiU2VydmljZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNREFILTdFT1ItSFF
  PSy1NSkVLLVBUQlgtM0NVRy1KSzZFIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiQzU1RU16WlRsRlFWdDdlanNGbW
  xqekRLRTJ4Wk1LaUdLa0xrUkVpM0d0NHRoMTNveVlhNgogIFdmT2ppOHFKWGNLaXd
  MZEtISVM5cl9TQSJ9fX19fQ",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCLV-U6YX-P3TO-X3VD-LIXM-V7ID-ZV7H",
            "signature":"2jg8z0TkxRUeOgRwTL5caT9whhw1HFRieyzWb4C6
  wjVaie8n6jmfov7fq908szZt2X-8BL3ewjKAApU8ynjggqvzIErnisvZ9Mlwti7IF
  aA9hBnoDYOxN8rbQLr-iEc9R3WwiJbLirAMmertHEZg7jMA"}
          ],
        "PayloadDigest":"cxpMZQdP9QpATO85Okx8iPyGdHn9WD6WFWASIB-7
  izbDOt8tpYBnk64aHrtr_hp0qu8dYIj5FXMejR3WS15S4Q"}
      ]}}
~~~~




