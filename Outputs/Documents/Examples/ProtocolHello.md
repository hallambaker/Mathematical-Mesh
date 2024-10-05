
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
        "EnvelopeId":"MBQH-INKI-FD4A-QLNG-CSXQ-CB7I-UESI",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFILUlOS0ktRk
  Q0QS1RTE5HLUNTWFEtQ0I3SS1VRVNJIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyNC0xMC0wNVQwMDo0ODo1OVoifQ",
        "dig":"S512"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJTZXJ2aWNlQXV0aGVudG
  ljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTUFSNy1GNVJCLVhDMkwtQlhGTS1UTlB
  SLVBUVVctU0FNQyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAg
  ICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgI
  CAgICAgICJQdWJsaWMiOiAiTXBaRXh5d0N4dzhfcEN5d0tsVWtaNGRMNWZsdU1tbk
  1XU2NsZW9ZR1F2OEg2VzhNN2pRagogIHdDQjdET1E0enpMUXNxZnBjUWZSYUpLQSJ
  9fX0sCiAgICAiU2VydmljZUVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUNX
  Si1ESFZMLVFKVEstVkJNSi1UU0tELUhLVEotR1RINSIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgIC
  AgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiLTBTcmM2ZnpHakt
  nUUZGUUlnU3FqVHYyRUdGUW5oWWdwOW5tSEhxMUF3UHNrNEdqaDQ4QQogIFJmcnRB
  NjVjNUpPTElXb1FsY1h5aEpRQSJ9fX0sCiAgICAiU2VydmljZVNpZ25hdHVyZSI6I
  HsKICAgICAgIlVkZiI6ICJNQzdTLTYyUEotTlpVSC1JNVZaLTJGSFMtS0NCVi1UWT
  dPIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0t
  leUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAidmtNbzVtVTluYmYyTUloQWtocVdxNDRBdlU5ZU9uZXlXLTNURmxLc
  zV0OGNRcXNOSHNMNgogIHFndWFZRUYwVHRvdE12YWhxSFgxbnJhQSJ9fX0sCiAgIC
  AiUm9vdFVkZnMiOiBbIllBUU9hcXpHODlOLVlBOFBzSTg3clllZmhlOGR1MTA2cEY
  0d3FWREhLQTJwUU9VSi00CiAgSW4zUEZNN1J3ZzhKN3gzV2ZwcklzVlVLc0NyX0hf
  c2M5b0VUSSJdfX0",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MACA-42VM-Y3Z5-G7TA-B4H3-BDZ3-VWDZ",
            "SignatureKey":{
              "PublicKeyECDH":{
                "crv":"Ed448",
                "Public":"ZIKmkmUFldDll2CCuiSwZcySkw9G5xRLERvpQD9
  gY_xEdXx9_4BUJG-gfKX7HiwQy7XzlUsYikMA"}},
            "signature":"UWIpODozuyPpVJ8aQLBz_-_cEm-eTPlEfvbGbQAt
  DNqs_g5xZr1GUkx82081YvzqVlHTFkI0xmyAtz044maFck0rYIN1rqhpwM3catNEF
  vuPiSqogU5OQ0MmWE1a8zJ3XkrCK72zXkN3InlTlZ7PWCsA"}
          ],
        "PayloadDigest":"6JL3oJdb26EZtRQ3v6NFxgzgJ-xHKovzwrtGXqN5
  gxFCiqOovNley3ZeQeceZ_tJz3wVeRth73v_Wexuh3GycQ"}
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




