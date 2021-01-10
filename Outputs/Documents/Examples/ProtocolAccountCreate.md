
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
        "EnvelopeID":"MBHC-IRM5-UYHG-WASI-HJDN-BSFA-BNNE",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQkhDLUlSTTUtVV
  lIRy1XQVNJLUhKRE4tQlNGQS1CTk5FIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMS0wMS0wOVQyMzowMzozN1oifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1CSEMtSVJNNS1VWUhHLVdBU0ktSEpETi1CU0Z
  BLUJOTkUiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJ0UXV2UlhUVlhXN25WbGpaZnJndUZjOUlCRFlCbHc3eWdRNW
  ZWaDZwNkstVENZMEhfZUZECiAgV0xoNTVHMDBqbWVwRF9jYlRGUHltVkNBIn19fSw
  KICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNRDJNLVBZ
  UlktU0hOQi0yREM3LUtUQ0MtTkI0Vy1RWVQ2IiwKICAgICAgIlB1YmxpY1BhcmFtZ
  XRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3
  J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJVOTAyVzhPeFkwbm5SVU1
  heUtBYU9ybUtRVE13UERoR21DVy1Hd2Y1QTlWTkw0WWRMWTZCCiAgX1JQYjVCN2Zk
  blFPMFd3U0xLNzk5cDRBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBHC-IRM5-UYHG-WASI-HJDN-BSFA-BNNE",
            "signature":"9uySq_9hpbBPJjYxvTwVwpyL-tiieQN6O6fllHua
  cAXpPj4Hy3nJEvsU1vk623jH1Pah2priOf6AL4UNo8-KaDPFZ-DaxdOk9mTtpBZ19
  lZLvtlrMG12lucm-A_XQ7pWm_pyMYd6OdDWdLjmLMas3CIA"}
          ],
        "PayloadDigest":"XDlFzVLcoPKq97GHdu4cdVFV-FU4cmOOlPS4EUA_
  T63OKMYBU36OwOk4Nu6m3ex1OT7ANMy9odogvHZLbbK-nA"}
      ],
    "EnvelopedProfileHost":[{
        "EnvelopeID":"MAC5-IZEP-XUST-JYCG-7PW6-HVPX-QRYG",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQUM1LUlaRVAtWF
  VTVC1KWUNHLTdQVzYtSFZQWC1RUllHIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMS0wMS0wOVQyMzowMzozN1oifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1BQzUtSVpFUC1YVVNULUpZQ0ctN1BXNi1IVlBYLVF
  SWUciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJmMkJuTDA2aHFKdDVGekcxZC0xTTdiVmVDSFFqNHVqSzhQeXpKTW
  1uV1pnT1B4VWlMaDN6CiAgVlNuLTZFSmczbHozeUVVSDczWW53UjBBIn19fSwKICA
  gICJLZXlBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQlczLVNMSEst
  Q1E0SS1YU1dNLVE1WjctWlJHNC1USldBIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlc
  nMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ij
  ogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJIR3VmNVBKMF9aRl8ybkhCUmR
  TTE9Pamx6d1hGN1ozRU5TeWdXLXFiTEhQZVBLM0FEUzA0CiAgX3N0c1VZekF3cU1q
  bDdZUUo1T2tWSmVBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAC5-IZEP-XUST-JYCG-7PW6-HVPX-QRYG",
            "signature":"XnbyRE8w0JOxqp6TqK9wbvG6FL0fBthEeFAmbAq1
  rEz8oMLElBYq6TV_KIBnm1WAaerpNMUOu3mAB1xvEI8Jez7UgqWoPWCa6agA20Yz1
  7GF7_7-ogpkMp6-wHzoMs5pjSekTZaSCLS90BnXk4jMMzUA"}
          ],
        "PayloadDigest":"ti-G_IoLk0XJ_spD9guqj7CTrRvTHlCrkFdTvP3_
  SSkTtEgU5tzXqPJEl-PmKpRYHH6QKxwfr84ZReBTaHVkjA"}
      ]}}
~~~~


