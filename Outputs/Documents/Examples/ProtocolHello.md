
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
        "EnvelopeId":"MD36-Q4SC-S4YZ-KPRP-7W4P-SNR7-QMD2",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRDM2LVE0U0MtUz
  RZWi1LUFJQLTdXNFAtU05SNy1RTUQyIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMS0xMC0yNVQxNTo0ODo0M1oifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1EMzYtUTRTQy1TNFlaLUtQUlAtN1c0UC1TTlI
  3LVFNRDIiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJHdWFlT0hOMXE5WDdkMW5PZEJIYTFFdUNSUkY3ZTlCZ0Y4b3
  VwdXJDZGpjT1BreUZBTFhRCiAgQWd4c1BKU1FNNWVnQVZQRGtHbWhyNjZBIn19fSw
  KICAgICJTZXJ2aWNlQXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJH
  Wi03U1NULTRIWUstRkxNTS03TjVMLVdWQU0tUDNYNyIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgIC
  AgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiZW5tcE1WcElONVl
  fQ1N0SGZYU21aa1ZueGdYSjZwYkoxQUZuZjNaUVZza19XZG1GaERDagogIGpsbW4y
  bEcyWHZyNURFWUlpR0pObUs2QSJ9fX0sCiAgICAiU2VydmljZUVuY3J5cHRpb24iO
  iB7CiAgICAgICJVZGYiOiAiTUJCUi1LTEw0LVlSRlgtSzYzRS0yRENULTZVR1EtWj
  VKQyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWN
  LZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAiVzJxaWw2Z1lKcmZOajV6R2pOMGd6U0VCRWd1N2tUaGZrR1NhR0Z5L
  UlBVDYzbktBLU12eQogIE5HSElvRTFsanpUaG4zcHpIblBOeVd1QSJ9fX0sCiAgIC
  AiU2VydmljZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQUdYLUMzTU4tREh
  OVC1ZVVNJLVpZUEgtVlE1Vy1DNVNXIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAieXFGOVdhQzlHendYUkxKOFFEVT
  RLX0w2UENzVnY1bzVUeHF5SWxHdEFCREgtSXB5RUtzZAogIHl2QWZaWndZRGsxalF
  Nb29HZEMxaVVPQSJ9fX19fQ",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MD36-Q4SC-S4YZ-KPRP-7W4P-SNR7-QMD2",
            "signature":"M_zW4QfJQFlkOgwxMukD4rrJCSy4O42zNbSmUQV-
  -5IUedZeFq3t81SVe_8rpVa43oPKn75yyXkAq2vL86MdD2EW6_5c0qk6_TjetFNA2
  W6nMpJrgSVqfAGSov1VpDST98tz8mZPULoXw7uGCuSHcSoA"}
          ],
        "PayloadDigest":"jmeKG0k9DNNN6eJYg_LN13Gh2SwGociO76OVJ6Q5
  kG9XCOgTVEO_YXG1DZWSszhG6qXfEUU5QV8WiQXqFsEU9Q"}
      ]}}
~~~~




