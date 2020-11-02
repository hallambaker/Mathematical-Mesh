
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
        "EnvelopeID":"MC33-WJWJ-I43A-NKBK-G2U5-BYEX-N3FF",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJRCI6ICJNQzMzLVdKV0otSTQz
  QS1OS0JLLUcyVTUtQllFWC1OM0ZGIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyMC0xMS0wMlQxNzo0MTozMVoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJl
  IjogewogICAgICAiVWRmIjogIk1DMzMtV0pXSi1JNDNBLU5LQkstRzJVNS1CWUVYL
  U4zRkYiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibG
  ljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJpVFQwMl9NYmNkYkFndEtDVlZLTkdjby1EWXpsZnU4ZVJHS0dp
  Uk9RaGw5RWhlVmxBNEU0CiAgQTQwZWhHbXB4eEpxSV8tS01rZlphSm1BIn19fSwKI
  CAgICJTZXJ2aWNlRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQkJPLVdHSV
  EtS1RRWS1JQ1FOLTdGU1gtWU9TRy1ENlk1IiwKICAgICAgIlB1YmxpY1BhcmFtZXR
  lcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2
  IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJnbmNxSjZxV1pZa3d3cElPO
  HVpS1dZbEVOcmFSSFRERmtmVlJwM0hHUFNRcnIzZnZvblQ3CiAgcXlUTkFIb2ZudW
  t1UHJ4QlJwZHM1N2NBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MC33-WJWJ-I43A-NKBK-G2U5-BYEX-N3FF",
            "signature":"kFZ2XkGfZNy8TB2T_00mxvA6_JAn5-IdQvnjDPUu7o
  0pClb2E81AEGL-XOnpLbZzeW0PE7T9bpcArHVQXgEyfw5EL_CdYq-EFO887QOeLvs
  qqhV6avsNdEYZeurIb1rjyknp8099eZXtTLg7DTMSXj0A"}
          ],
        "PayloadDigest":"og05O4YE6JX9hWZGPTNAzp8d0XC5f8OopPY9SOCVp-
  thLjTdhwMLKyfZrF7twvB9tbe20t82IVYy3NjpVR06wQ"}
      ],
    "EnvelopedProfileHost":[{
        "EnvelopeID":"MDJK-IDLW-LLI2-W6HD-I6L5-CDSD-3ZDY",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJRCI6ICJNREpLLUlETFctTExJ
  Mi1XNkhELUk2TDUtQ0RTRC0zWkRZIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Uhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNyZW
  F0ZWQiOiAiMjAyMC0xMS0wMlQxNzo0MTozMVoifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIjog
  ewogICAgICAiVWRmIjogIk1ESkstSURMVy1MTEkyLVc2SEQtSTZMNS1DRFNELTNaR
  FkiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2
  V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB
  1YmxpYyI6ICJoLXI3ZkdHMGpiVGtTRWlybktYR0lHTGtUTnNrUkswczYyejRuc1hJ
  NWtYXzAyMEs0cGRlCiAgckZRSXk3NktuVS0ydVpaUFNWcHd0WjZBIn19fSwKICAgI
  CJLZXlBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQk9YLTRERkEtVV
  g1TC1JTkRPLTVIQk8tQTRPNS1CRTNNIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnM
  iOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ijog
  Ilg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJzbzNLRnJLMjF2U1ZBVkZfVXNmb
  C1Lc2RtR3E2LTZudHVEWEhYTTBVM2JGdWlESDhTZjBhCiAgNHk5N181Q3YtcGJqNk
  5FSFZrc3QyeEVBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDJK-IDLW-LLI2-W6HD-I6L5-CDSD-3ZDY",
            "signature":"Cy7q1kvz_p7Za1hkTScHABlzSRWakAjWcNmr8Ck5eX
  ILQvXRKx4mK_UPG0qAOwKGl3STqiYFZ2WAgyvXQeCd0IjqTOEDDFQjktk4cbu27S6
  bl5qFLR7Q3M6c3pTGiYG0m4gEl4VshMFd37QrAZKuSzUA"}
          ],
        "PayloadDigest":"G3Cixcg3-7dTirgDfidEuffWAnQ5S9a6uz_oMyS6FT
  PkL3YhRHVIPIqR0qzSsbEqIVYpNtg5scLOXi3WhbN6Zg"}
      ]}}
~~~~


