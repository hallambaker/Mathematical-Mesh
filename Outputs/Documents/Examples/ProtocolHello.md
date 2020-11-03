
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
        "EnvelopeID":"MBNM-5PJO-IGRJ-UZKD-Q3JR-PYDT-CSST",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJRCI6ICJNQk5NLTVQSk8tSU
  dSSi1VWktELVEzSlItUFlEVC1DU1NUIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMC0xMS0wMlQyMDozMjo0OFoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1CTk0tNVBKTy1JR1JKLVVaS0QtUTNKUi1QWUR
  ULUNTU1QiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJ4X0VQbzFzUks3N0YybFJNLTh2Zmh0LTgyQ1g4UlB1ZGFJMU
  5DY3daNFZPMTd3WlpqUll6CiAgX3ZSZnFHYlE4NTMwRVU2ZWpKcjJZUUFBIn19fSw
  KICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQlFELVlR
  VjMtR1JLVS1CRVI1LUs3TzUtQlZEVy1UTk5GIiwKICAgICAgIlB1YmxpY1BhcmFtZ
  XRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3
  J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJjSXZBZW51WGtXM3NmeTV
  EM1FsbnItM2ZDVTJyZFdWX2JSSmJRNnIydVVyY1B2RUlaaWdMCiAgS1ZCOUEzcTlq
  Mjcybm1NQVA4eUtsX0tBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBNM-5PJO-IGRJ-UZKD-Q3JR-PYDT-CSST",
            "signature":"DAd73GaQ2B48pbkms5RuBEnbrC1770oblWTjZhk0
  LSHO-kD0Cnr5Nfuoe_1pyJsHneZKUy1a-_oAPfUOJlqQbyuBuD9nVNxFSur7NjWLQ
  EUPrGMUg5s5slK8t6P3zGzncDcosvyjR2QZCeurT2AjbA4A"}
          ],
        "PayloadDigest":"BhHcJ0v5srIFD8lCqgEQYZnC7D0-daPHeN7Afjpv
  19D5Fb2yi0nhZbC3id0Vqe1QKwsjNWaHDs0Z4vNCF1iL8g"}
      ],
    "EnvelopedProfileHost":[{
        "EnvelopeID":"MBHD-DKFH-T3YE-QMZ5-2TVE-7V3H-TNN5",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJRCI6ICJNQkhELURLRkgtVD
  NZRS1RTVo1LTJUVkUtN1YzSC1UTk41IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMC0xMS0wMlQyMDozMjo0OFoifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1CSEQtREtGSC1UM1lFLVFNWjUtMlRWRS03VjNILVR
  OTjUiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJCc2pKUUVqb09fZHJtQkdUSUlZSUZCeHNEUFNibnU3ODRMUjJzSF
  9TTFpFTHd6TWs4aENGCiAgNC10WElVNFVCMHhheW45TnNvUkRQZ0lBIn19fSwKICA
  gICJLZXlBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ0tELUdBRk0t
  VldOWi1ZN1U2LUlJN08tNkxQUS1GNkZGIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlc
  nMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ij
  ogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJjVUdMdFZlYjFUcjQ2c0NJZl9
  4S3BOWUVES1FLT3UyNGFQN0hxeWdmZXUtdEMzOHBPVG52CiAgUnNhRjB2X2xmaGs1
  Mjhvc2dfVVFlTG9BIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBHD-DKFH-T3YE-QMZ5-2TVE-7V3H-TNN5",
            "signature":"AuQU0ijdD3uQ-2g7X1jOqqE8YElAkc9WrWRV1IIw
  vIVFx4o0jN3JM-1FfEG8j2Fgh--dd1wbNW6AADbQsFDsyKzlS8-F5VSW-ZmpC5Tzj
  QzLrjrFkHsX3iftT1yCPiOgtub2gUzTRkG1F_Y4PBCG9w4A"}
          ],
        "PayloadDigest":"OBAjwxVLfN2biYvEufJO8vTN6k34ZTuwF71zExPK
  qtBpDyg5qUHfEWYPKNqzAgYmFikpN2pAmA8p7QrwNdRIxA"}
      ]}}
~~~~



