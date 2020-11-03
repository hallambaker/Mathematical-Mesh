
The request payload:


~~~~
{
  "HelloRequest":{}}
~~~~


The response payload:


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
        "EnvelopeID":"MDQO-R66J-MVEO-BDL6-V6T7-FPII-U42Q",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJRCI6ICJNRFFPLVI2NkotTV
  ZFTy1CREw2LVY2VDctRlBJSS1VNDJRIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMC0xMS0wM1QwMTo1MDozN1oifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1EUU8tUjY2Si1NVkVPLUJETDYtVjZUNy1GUEl
  JLVU0MlEiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICIzZVVVMzFZODhVZ2NCaFFsbHhzanZ3NkFObWUtSEw1WExsSH
  Fqc3FuR3pnM3JRTG1SQXFrCiAgUWh1TnJyUnY1N08xcjN4ZTEtd3NWa21BIn19fSw
  KICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNRDRDLUNL
  RUItUjZQRy1JS0o1LTJUWkgtRlJFNS1RQVNNIiwKICAgICAgIlB1YmxpY1BhcmFtZ
  XRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3
  J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJlU0QzZVU4bEN3a0NxaXl
  1Zi1rSmdBR3ZjNFJ2NGV5UXJiTm40OW1GNGZLWEhHaGU3NE9KCiAgYnppYUxiTUVL
  c1kxVXB1aEx5TXhnNWdBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDQO-R66J-MVEO-BDL6-V6T7-FPII-U42Q",
            "signature":"La5_t0nlm5sC_sbR4nU-PQoQKGfI20ZjcweZmhJ1
  _RsGoKYb1LwxD_H1jq2g7rkre0DnGNMwIYaAU4_z9n8WwMfDF9v2BpSYryZJG6yLR
  3ge8ROPkWz3hm_XIWJGZMK16CJ_IxyWhU3K8xtABBC8TBUA"}
          ],
        "PayloadDigest":"jt9hWT9i8QAbGu2hunJPTUIWeGec-08pXDRsTexm
  csDPGi1kVVSk7evW9dlgCxlEOiVnGZ47raCZ7XPwvvW4JQ"}
      ],
    "EnvelopedProfileHost":[{
        "EnvelopeID":"MBLN-DZWC-CJOO-KJ25-NAO4-C3RL-36UJ",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJRCI6ICJNQkxOLURaV0MtQ0
  pPTy1LSjI1LU5BTzQtQzNSTC0zNlVKIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMC0xMS0wM1QwMTo1MDozN1oifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1CTE4tRFpXQy1DSk9PLUtKMjUtTkFPNC1DM1JMLTM
  2VUoiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJKX1VlQUVGX3haX2pOdzhZUDVwOWRsQ0VmQTAxdjR0WFQxRXZqcH
  lnLXM5eldpY2NnbVdNCiAgVVNPQnFTVTRabnNrSUZTUlRNOHgwY0dBIn19fSwKICA
  gICJLZXlBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ1lVLU9KVlQt
  N0tIMi1KT0kzLVk0NlYtN1dXMi1PRlJZIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlc
  nMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ij
  ogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJrem9WWVZES1RsSzV2ZWdPdW1
  Db1BFRUY0d1Niamp5bW5xVndOUVF6VkJsdmYyd3E3OVhsCiAgdEc3NEs4Ulh3VnVT
  c2lxMVUzcE8xNWFBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBLN-DZWC-CJOO-KJ25-NAO4-C3RL-36UJ",
            "signature":"AX7SUlQHWpPxOFAuVGw7Ltybcomg_V_ov7_9pQY_
  QvGjOWYLhXbU61r9updzE9EU41Vqp9dKkWuAcYmdh-x2yfMSglieuoji8KM3q1I4s
  _A37N5jdfDdwFaMEjGXcc4KpEOyhfYA-PA6OST42N2VsBcA"}
          ],
        "PayloadDigest":"oVnS42cH-KvYmlr6v8uI47kPv42NhF3v2tcKlToA
  NJBxkMmPgeWwBXH9T9kx3Kz7GWDk-SmSVWgJteqtzJ7zAA"}
      ]}}
~~~~


