
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
        "EnvelopeId":"MCCO-ZKXM-VVYT-U7SD-OHAV-UYJZ-DCSA",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ0NPLVpLWE0tVl
  ZZVC1VN1NELU9IQVYtVVlKWi1EQ1NBIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMS0xMi0yMFQxNDowMDowMloifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1DQ08tWktYTS1WVllULVU3U0QtT0hBVi1VWUp
  aLURDU0EiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJDaHh3ZjRxZms5Y3liVVg2Nm5CdFpzcFZrQUtkdEFYREtaeD
  h3eHhseWpVUGNhNjM5b3FyCiAgRl90LXBKcFNyamtnQmtIYk1DNEZOcFVBIn19fSw
  KICAgICJTZXJ2aWNlQXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTUQ3
  SC1WWEFNLTZWUTQtVUw1Ry1CUlFHLTJVVlUtTlM2WiIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgIC
  AgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAibUJlRmhodWMwV2V
  hTkFQYlJ5VVpINEdkLVZrd2VmNmNyanBjSlF5aXljOVdsandZWGk2SAogIFBpUzlU
  TkxYUEtXNmxuTWNoeGg1aWRzQSJ9fX0sCiAgICAiU2VydmljZUVuY3J5cHRpb24iO
  iB7CiAgICAgICJVZGYiOiAiTUJFQy1OMlZYLTdQSUktWUJRRi0yS1BKLTI0VDMtTF
  FCUyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWN
  LZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAieVREa0pxbTdXZGl3aVM1ZUdEVFI1QXU3cFk5VElpUmFlUWE2QVhGT
  DZDQTl6TGZMbmJFNQogIDBPQm5peG52YlVQUDhkdEEwV1k4anRDQSJ9fX0sCiAgIC
  AiU2VydmljZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQUpYLTI2QUotM1l
  VTy1NNkdVLUFXQ1EtNFVXRC1LU1A0IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiaDVPNEsxU2dpM3ljMGxGSmI4bF
  dNb0RLX2gxY3JBTURaaWtUZDctTjg3S095WGZTVzVnXwogIF83a1ZDWnZERk9OTEo
  zNXlITDhhRE11QSJ9fX19fQ",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCCO-ZKXM-VVYT-U7SD-OHAV-UYJZ-DCSA",
            "signature":"-xojn79n-vTDK86Rt_eSybLV14l3SMzjq3fbp9RV
  0dXzkiJGTO0bKrVOamuiQVhyTgM8dM4lPAIAb-rMzjihdqEVjWvq3_MLc_ZhsOPtc
  z_UXMPyU1xSs9TH4AtUeBr811_UMtA_KETZ4YKWirvOigMA"}
          ],
        "PayloadDigest":"MPy17RJiXTehYlfsyYEacVvZjJlxTdpKSg36hoyg
  5fGiFaGyvZ48N6u_kSZi5isJ0q85DlexciYh_sY4IjmzOg"}
      ]}}
~~~~




