
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
        "EnvelopeID":"MA22-BV5A-QPW3-JZH2-UEYF-A2TP-HSV4",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJRCI6ICJNQTIyLUJWNUEtUV
  BXMy1KWkgyLVVFWUYtQTJUUC1IU1Y0IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMC0xMS0xMVQxNjo1MzoyMFoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1BMjItQlY1QS1RUFczLUpaSDItVUVZRi1BMlR
  QLUhTVjQiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICI1dHpVeWZhRDhoOXpjTkh0ejdUZEp3UUFudjlLWi12Smk0SU
  1TSWkxZnpIWEtpbTl0RmxCCiAgZVc5UkZ0SHFlYmtDbGxrS1RTZ3Vrd3NBIn19fSw
  KICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQUpNLTU2
  T0ItSEdGTS00SE9PLTNRSE8tVkpKRi1DSVNUIiwKICAgICAgIlB1YmxpY1BhcmFtZ
  XRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3
  J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJnZ3lNLUxiWlV6RUlMQ3g
  4ZDlDWDRURE5jZm9XeVZMMUtmUHplczdKVTFyM2ZDVGNnSVotCiAgN3dCQkQ1aHBY
  QkZfN0FjMnRhd08tWVdBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MA22-BV5A-QPW3-JZH2-UEYF-A2TP-HSV4",
            "signature":"Znb9LWfwG1r7mCGnrAUDA3TPBRM2QR8TnlN9CgDL
  Ue2wQYVyZJ7C9RrbDzCEh7XgwaO1OeYVObsAKp8Pji22dRuB25v1koQJnEdHKG-jN
  JrHDAyl0njyaGw65xg-OkehcdB9ZdtzLwKgo3_35jp8cisA"}
          ],
        "PayloadDigest":"AIgHiIeD0iFOiVaKger2AFnmmw7RRCdl06TKIrBP
  zQ-b3mJ59NgMLeCMFduh-5MEgis3rP9HgWopcTDA6ySwbg"}
      ],
    "EnvelopedProfileHost":[{
        "EnvelopeID":"MAP6-OD7Q-64OL-45DD-M7LS-EP6Q-ZS65",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJRCI6ICJNQVA2LU9EN1EtNj
  RPTC00NURELU03TFMtRVA2US1aUzY1IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMC0xMS0xMVQxNjo1MzoyMFoifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1BUDYtT0Q3US02NE9MLTQ1REQtTTdMUy1FUDZRLVp
  TNjUiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJ4OUdtRE44eC03RC1tdzZBTUNYZTNwc005cXBjVnk5V0k5Wll4b3
  BqWTRZazBFWFdYQ0RKCiAgdlpjZkRtUnZ2YjhzWGdQaEYzOF84dlVBIn19fSwKICA
  gICJLZXlBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNRFdILTNVSUEt
  UFQzSC1DQU5TLVg0QkotQVFQQS1ZTlRIIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlc
  nMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ij
  ogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ6QU0zLWdPd2pVWWZBb1puTkl
  IUFpTVUcyY1ViWUZ1RXZmSnptLVpMY2Z6RmsxRVBkUDJfCiAgaEwtSXJmeGZnLTN4
  MVhQNjdTbElsd2FBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAP6-OD7Q-64OL-45DD-M7LS-EP6Q-ZS65",
            "signature":"as_p1SS3iWBbDPpUa1pwvA6bg_Zmp_qzdu5MTNZm
  g9FKgD1ZPxrBjoBLZCDQDfZKHlavj0veSPkAb4FgfFdygG5-CpJijORV9dEYZuWJD
  EuHUBEXMSzH_SBOmOG6TGd2gIuOXBtWSN_kGwTvGNFyRwwA"}
          ],
        "PayloadDigest":"-x_9CShUqRoQRKizVc7J4TBA9QkOjfn_4ewCloEB
  YeitXIJZBhpG9N8z5PLhj28_3c6SnQb9jPvv7YPhNmGDVg"}
      ]}}
~~~~


