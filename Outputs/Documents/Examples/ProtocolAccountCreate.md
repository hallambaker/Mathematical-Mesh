
Alice requests creation of the account alice@example.com. The request payload is:


~~~~
{
  "BindRequest":{
    "AccountAddress":"alice@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MDKO-KEIN-OCN2-C6UB-VS2K-TNA4-WXVJ",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNREtPLUtFSU4tT0
  NOMi1DNlVCLVZTMkstVE5BNC1XWFZKIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMS0xMi0yMFQxNDowMDowNFoifQ"},
      "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1ES08tS0VJTi1PQ04yLUM2VUItVlMySy1UTkE0LVd
  YVkoiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJpTXpib3FwM0FwRlpoYmRpeXY5UVdvZGpsMzQycUM5RTFNOGF5OX
  ViNHkzVE15bDQ5RDBUCiAgdV9NNEV4T1JpNXZudWxQU0N5NE4wTS1BIn19fSwKICA
  gICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2Vy
  dmljZVVkZiI6ICJNQ0NPLVpLWE0tVlZZVC1VN1NELU9IQVYtVVlKWi1EQ1NBIiwKI
  CAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1BT0ktWkg1Ny
  1ESVVILUtYVjUtU0JNWi1PWVlMLVdIQzIiLAogICAgICAiUHVibGljUGFyYW1ldGV
  ycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYi
  OiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIm1pUTc5OUN0aXpvbmFSQXRhS
  3N4Z3VreXY0UjlXaU1YQ05nTjllY0FYd0VDYXYtYkxUcTEKICBQZVlZbGliY2p4Sl
  B5NjdyUExicmdVMEEifX19LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogICA
  gICAiVWRmIjogIk1DR1MtVDZQUi1ZUUJOLUtaSTYtTFVRTy1YSVZJLU9TRkoiLAog
  ICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNES
  CI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIj
  ogImNsYm5ReXFTU3A1U1NQVS1YaW42ZGpwZUR5Vzk4aEpxY3VQSEwya1hXcThYZ2t
  BV0xRSTgKICBtWV9PckZTb0tTdFAtVzd2NGwxNmpVc0EifX19LAogICAgIkFkbWlu
  aXN0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTUFNUi1US01RLTJBN
  zctV1VHNS1DSEJCLURSMlItNzdGVCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIj
  ogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJ
  FZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogInNEN2treVdyeUVvRkkzLVZzeHdz
  RkJTNk9TcXhVTTJOY2JzVS1paldkQ3cwc0MtS3BrLXUKICBhUk02S2hNYW0yX3pme
  U5Ja3UtTUpmVUEifX19LAogICAgIkFjY291bnRBdXRoZW50aWNhdGlvbiI6IHsKIC
  AgICAgIlVkZiI6ICJNQlpOLU9PRVItSklXQy1DM0ZNLVVPN0ktQ1UzNS1RSkxPIiw
  KICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVD
  REgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJlS3JsWVJBMTdpVVdoWVNpeHVmNmk1VmRVTXgtcGFpbVVYb3ZsdnpkM1hCQV
  Z6QjJWYk1DCiAgV0NjSEtwa2c3SUtxYlJRSTRGSVZnV1VBIn19fSwKICAgICJBY2N
  vdW50U2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DRUQtUE1WWi1MNEJFLVdM
  SlotMlA0Sy1RSU5NLUVITTIiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKI
  CAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0ND
  giLAogICAgICAgICAgIlB1YmxpYyI6ICJBRjV1NlpGUERzc3plRTI4S2dVcG9UamR
  ndmVHWHJnTkJ2Y0JKSlpmWS15VFZLT2syTE5uCiAgb20wSi0tRXRRSFZNRHFVaWtw
  VGdPaHVBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDKO-KEIN-OCN2-C6UB-VS2K-TNA4-WXVJ",
            "signature":"cvqYlMVwIALwWn52zUGtYKtYjwaaEyuSWJQVM31s
  bhHV5afIvlDAZKMQVf9mwMMXby5KJ1jsaL0AWT7HejMuaoNzXX9jkFR9aFKXgEN6g
  jwX3C_4EW32y7E7xHA7uym0mQcrt4wuxXZ5susRIJOJcwsA"}
          ],
        "PayloadDigest":"IXngV7F7UWfa_FxaAEh_EtlDBtSG2b8FkifmDfP-
  avur88kUHdLw3jnfftch10GxeNGkw6cjTCI9ZEqMcxhR6Q"}
      ]}}
~~~~


The response payload currently reports the success or failure of the bind operation:


~~~~
{
  "BindResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedAccountHostAssignment":[{
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY2NvdW50SG
  9zdEFzc2lnbm1lbnQiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCI
  sCiAgIkNyZWF0ZWQiOiAiMjAyMS0xMi0yMFQxNDowMDowNVoifQ"},
      "ewogICJBY2NvdW50SG9zdEFzc2lnbm1lbnQiOiB7CiAgICAiQWNjb3VudE
  FkZGVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiQWNjZXNzRW5jcnlwdCI
  6IHsKICAgICAgIlVkZiI6ICJNQkVDLU4yVlgtN1BJSS1ZQlFGLTJLUEotMjRUMy1M
  UUJTIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIl
  B1YmxpYyI6ICJ5VERrSnFtN1dkaXdpUzVlR0RUUjVBdTdwWTlUSWlSYWVRYTZBWEZ
  MNkNBOXpMZkxuYkU1CiAgME9Cbml4bnZiVVBQOGR0QTBXWThqdENBIn19fX19"
      ]}}
~~~~


It is likely that a future revisions of the specification will specify the host(s) to 
which future account service operations are to be directed. This would allow the
account management operations to be separated from the account maintenance operations
without requiring the traditional tiered architecture in which every interaction with 
a service is first routed to a host that cannot perform the required action so that
it can be directed to the host that can.


