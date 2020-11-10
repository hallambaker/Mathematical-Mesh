
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
        "EnvelopeID":"MBWN-FLOH-XNE7-XSHJ-S3GT-E4BI-UCIE",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJRCI6ICJNQldOLUZMT0gtWE
  5FNy1YU0hKLVMzR1QtRTRCSS1VQ0lFIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMC0xMS0xMFQwMDo1NjoyOVoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1CV04tRkxPSC1YTkU3LVhTSEotUzNHVC1FNEJ
  JLVVDSUUiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJYS2ZBcXctTkFHSmFKeUk3dUNEalp0Z0R0bWh0VW84TGJBen
  ZUdEF3ZWdfaG95Q1lkNUd0CiAgU0huWS1kZ0RjT0JUVDU4U0ZTMWFEQnNBIn19fSw
  KICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ1M1LUJY
  UkMtNVRQNS02RTdCLUJIVEctUFlKUi1SUE5OIiwKICAgICAgIlB1YmxpY1BhcmFtZ
  XRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3
  J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJwSFB0Y21tRnNrVmljWHp
  CcE9kc0k0OTFDREllY2stQXY4UDRLTVFBXzlwZFJhR3lxRnRQCiAgTVJaTUo0bGRL
  UERyYjlFMGNiY08yamdBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBWN-FLOH-XNE7-XSHJ-S3GT-E4BI-UCIE",
            "signature":"5t1SY4umAkupj6BopqrquVAyppn6tbeBM1OssnAl
  3N5irjzBuVjIhNZJteeS_-_8P5u4mxmJGVGAYuQ8p2uy6kZ6s-CteLZvIcN-Zo8UE
  a3Lg6uo5gzEFqMsWBeXIXTcc8Onktd8_sU7QBJivQFdORYA"}
          ],
        "PayloadDigest":"cioyQzcOV4MObSJQhEHEdyNUWJ2qc02fajeKSuKT
  BkG9oXOYPk1hsALH7hx7fmnCYzB3OKzRYFB8a0D0xap4zg"}
      ],
    "EnvelopedProfileHost":[{
        "EnvelopeID":"MDEU-5P7Q-FC7K-EV3I-WFJS-6CI2-7BDI",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJRCI6ICJNREVVLTVQN1EtRk
  M3Sy1FVjNJLVdGSlMtNkNJMi03QkRJIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMC0xMS0xMFQwMDo1NjoyOVoifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1ERVUtNVA3US1GQzdLLUVWM0ktV0ZKUy02Q0kyLTd
  CREkiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJxUDVjcUMta01uYU1rV2NDU05hQXN0TmR6OHA3am9yNlItNVh2Zl
  EzWlVOVkhETXplTFhFCiAgM0hnQlNhSG9tMFJxQXVIcm9HTEotbkVBIn19fSwKICA
  gICJLZXlBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ1VSLVRUT08t
  TlNJRC1NTkxFLTNMTEwtRkJBMy1YU1NUIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlc
  nMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ij
  ogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJnUFBOUVpldFhrYlNFcDRpb3N
  OWUVxQnhGR3Y3ZjFTN0Z3ZHR2MEt3SzdiaTlnZUt3cTNNCiAgTHo5ZHZsR1JYZ2dV
  UnR3SUt4LTNfYzBBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDEU-5P7Q-FC7K-EV3I-WFJS-6CI2-7BDI",
            "signature":"lFMghJZ21f_XWixaoGcaS_bkxrbbiFu3RWJHAggI
  BkCcCC_cAQ_vqdtQYaMuATPYc31CbNtRypWA84BJcLQkJuApeYFEsPsaSuk2BoizW
  00Ptd-MPFfJBJTiQrQJDBAHoB3AzfJhwLulrc6z25ZLVD0A"}
          ],
        "PayloadDigest":"t-RKvtV-RppN-t5QR3oVf0Ukqr_miWwxLYTB9ko2
  xDWMBS6dQ8U6jYAdwJtYiV5KWKStL1CGNZSMM6uf_f7pMw"}
      ]}}
~~~~



