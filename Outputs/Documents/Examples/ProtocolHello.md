
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
        "EnvelopeId":"MA5M-3UW6-LHDG-TDOF-GFPC-LCLU-XY2B",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQTVNLTNVVzYtTE
  hERy1URE9GLUdGUEMtTENMVS1YWTJCIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMS0wMS0xMVQxNzoxMjo1NFoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1BNU0tM1VXNi1MSERHLVRET0YtR0ZQQy1MQ0x
  VLVhZMkIiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJiNFg3N2ZHbnBOY0d1MXRpUGo4a1VwWHd6QXhhWUtJQjUxXz
  JvUzZEdWtaUXNqNWVSS1RUCiAgbEl4czVtaTRrWTlkeUtoR2FfekJwU0NBIn19fSw
  KICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNRDZLLUlE
  N1QtUlFJVy1NN0tSLUo1SkgtRzRYSC1BSkxFIiwKICAgICAgIlB1YmxpY1BhcmFtZ
  XRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3
  J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJhYktmLXI4di1xR2hrTjd
  HcDdKSHBqNk5GOVJNaUE5ZVd0WWpIdTlHQm5wMmZTemhiSVVjCiAgeEhNN1hXSEtu
  TFlLai1tUTR3c09ZVC1BIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MA5M-3UW6-LHDG-TDOF-GFPC-LCLU-XY2B",
            "signature":"SIL_TI2rcUf5RpnQnslK-7wrwDhNxJqcNCRVJlHA
  -RPb931qZI7h6ZRM3oFyOP7OUsuUN314NP6A8N_x2RD86EUw53TM3XoouorMh6XXD
  9xJzadCqtHE5Bn4urYk9Cga-XOWTCN29Ob8wGdQu5el6T8A"}
          ],
        "PayloadDigest":"CUyFNBMgB82Z70-pq3nsfiMHLDB7a7BW44DgoqaW
  0xmWXY6IWnapphnvyNeknVIh_ZQjqEdn6Lrxfxw4D05OSA"}
      ],
    "EnvelopedProfileHost":[{
        "EnvelopeId":"MD4D-I2XA-PLGO-FQYL-7I4V-H3V3-RGOD",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRDRELUkyWEEtUE
  xHTy1GUVlMLTdJNFYtSDNWMy1SR09EIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMS0wMS0xMVQxNzoxMjo1NFoifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1ENEQtSTJYQS1QTEdPLUZRWUwtN0k0Vi1IM1YzLVJ
  HT0QiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICI0cnVkeThsTTlhd2ZjRkpYRVgxbk9sY18wY3NDdXNfSy1qeFZpRG
  p1eU1BV2dzRWwxYWJUCiAgSFQtWndkSzJLc21vZzJfMldoVkJzZjJBIn19fSwKICA
  gICJLZXlBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ0MyLUhCWEkt
  RzVWSS1GVVhJLVdLNEktQ1RKNS01NUZWIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlc
  nMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ij
  ogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJFXzlXZTNoUVU2dkk3bVhsbVk
  4Y1E0NVl6Sno2akl2RHN5TkZ1VS1YVEtVZHhqY0xFSE82CiAgTDBpM2htQ3RaZlZt
  TWExbWZGV2xtOGFBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MD4D-I2XA-PLGO-FQYL-7I4V-H3V3-RGOD",
            "signature":"PuSdYA6iU9eF60nhcWc8EF9vV4ctEPcdpV_NI7Ny
  GOAAKHxyTrZcpojPvofsH8yHNbUgVoF7nC6AoWAh6GasEpvyhse2lGxn6Z3JagfBj
  Y83UyqwPCJMZWvck1D_CjM9uO72zFekIxA5hes6eY-K8wwA"}
          ],
        "PayloadDigest":"aJ-LoEXI5rydXpeN4wC0c-G9ImeAvWId0elgueIO
  FOOPJi3Z4Xc9cm5ivy03fxA9W3IdTN5ai6O7Rv7Tzz2lpA"}
      ]}}
~~~~



