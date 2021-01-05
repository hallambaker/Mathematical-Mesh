
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
        "EnvelopeID":"MDOX-XBQ6-B6PF-EP5W-7WEE-FCCI-IRK2",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRE9YLVhCUTYtQj
  ZQRi1FUDVXLTdXRUUtRkNDSS1JUksyIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMS0wMS0wNFQxMzozOTozMVoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1ET1gtWEJRNi1CNlBGLUVQNVctN1dFRS1GQ0N
  JLUlSSzIiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICIwRXdBcmc2Z1JFRkZRZjQ2a3RESjNxRHZ6TXd6VWVYSVIzcj
  VkaGZlWXhlN1JuaHptN0czCiAgQlkwUlR4Wm1WQm5LNHB6al9wY2hneXNBIn19fSw
  KICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQlJRLVJM
  SkstNVJTQS1FSlZTLVhEVUstQzNWVC01SlZLIiwKICAgICAgIlB1YmxpY1BhcmFtZ
  XRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3
  J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJyRXlBcGJfN01Fc1d6QzZ
  SV2RRa3JGc3JUbDlNZXJzU0FjRGlwMkd5LUxRckVyZ3pjVDJDCiAgUXQzWHdhakRm
  M2lWLVVMVldFa2JEQ1VBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDOX-XBQ6-B6PF-EP5W-7WEE-FCCI-IRK2",
            "signature":"5rxI2BS3sJWC-AMMIMBBew1dCpCm_dGmoMMAXfvE
  yRMCWjNpER-egthJS4i3BlHHFSIRZDxysciAqzm2MptCtYuCZKJJi28QO9Wbt2P07
  3fDP0EMaV1mS5rXOoSH8kT9UW7_abWXzCOeozj0_6ZoxAwA"}
          ],
        "PayloadDigest":"UtMv6Gh7-avQXZuoq4pZNlCysHSuGD-QVW3haKUb
  bVQ9s7ZkwnwsK5Gq-9HSlfB-Wseipqgs7chgvwtkcWmM1A"}
      ],
    "EnvelopedProfileHost":[{
        "EnvelopeID":"MA6U-DJER-IDOL-ZUYH-DMQ3-35V7-YPAQ",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQTZVLURKRVItSU
  RPTC1aVVlILURNUTMtMzVWNy1ZUEFRIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMS0wMS0wNFQxMzozOTozMVoifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1BNlUtREpFUi1JRE9MLVpVWUgtRE1RMy0zNVY3LVl
  QQVEiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJhaVlqZlFfSjA1RERTWTBNcjNSTkpXcU5KeUtZRUNIdVR6TXNHcW
  RxUUZXbGRBT0RkMVpCCiAgZllsaERXbno3ZWxCb25USEdqX2VRbWVBIn19fSwKICA
  gICJLZXlBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQzZaLVFEUzIt
  RE5aTi1HQ0xYLU9QQU4tRldKNy0yNzQ1IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlc
  nMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ij
  ogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICIwbFQ0NGRuS0ZzVzluSU5ZN2F
  KbUk2S3p2NW5tTVlyNlcwS09FWUpTTDY2ZUVnRS1iVHczCiAgOEtYQkx1MDJfLWpL
  SGFVQUMyeHRFZ3dBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MA6U-DJER-IDOL-ZUYH-DMQ3-35V7-YPAQ",
            "signature":"pDxYMfssvTzbe3Lif7RQYZlt2k9EEwzUkxkbaFRM
  UxBXwd61mbdJpVre-lQgeTuB9Ya7ZVgUlUkAxGsPNkmpX6S1uBGA9a-4Ktl6cKMjw
  4sQF2qPcWdO0l4o0HPx7hXM-Erbg5BBDpIJT1BWeZVxkhEA"}
          ],
        "PayloadDigest":"7Muoz3fs_aYf64IBDEjL97Daj6Av0Gm73XhhDI1J
  qfxqSARTju-DO_Q0n-uzr4zHtrXmV818HYgdNS18SuQLpw"}
      ]}}
~~~~


