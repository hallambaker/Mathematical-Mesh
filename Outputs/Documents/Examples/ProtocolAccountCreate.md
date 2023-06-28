
Alice requests creation of the account alice@example.com. The request payload is:


~~~~
{
  "BindRequest":{
    "AccountAddress":"alice@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQjNULVdJUFotSl
  JDVy1RWkZNLVNDUUwtT1ZWTy1BSE8yIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMy0wNi0yOFQxNzowMDoxNVoifQ"},
      "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJDb21tb25TaWduYXR1cmUiOi
  B7CiAgICAgICJVZGYiOiAiTURFMi1NS01JLTc3M1AtR0ozRi1ZWUFJLVVWQ0stT01
  LUyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNL
  ZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiU
  HVibGljIjogImpSOXVyUGJvc2xvU1J1NThsa0tHOU80TDVCTnpxYkVzM29xOEl6d0
  xxVTJReUdSazhrV0QKICBvazZPT3doWU9jUmdYZW90X2VWT0FHbUEifX19LAogICA
  gIkFjY291bnRBZGRyZXNzIjogImFsaWNlQGV4YW1wbGUuY29tIiwKICAgICJTZXJ2
  aWNlVWRmIjogIk1EM0UtRk42Vy0zRzQ1LVlRNDMtUVhZUi1DVTRYLVJLRzUiLAogI
  CAgIkVzY3Jvd0VuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJTSy0yWTZHLU
  RLNlAtVDZUVS1PU0xELUdDRlctTVBIRyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJ
  zIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6
  ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiUjVXMFRZVXljRU1oR3V4R3VDa
  0JUTVlCMU1nS1owMzZ5MDUyWExWYk1zanhnZzlpREQteQogIFZZVk5lX3lVQ204UU
  d0cFN0XzhFYjNjQSJ9fX0sCiAgICAiQWRtaW5pc3RyYXRvclNpZ25hdHVyZSI6IHs
  KICAgICAgIlVkZiI6ICJNQkw1LUpTTjMtVjU2US00VUxZLUdZN1gtR00zVi1LVlBa
  IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tle
  UVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdW
  JsaWMiOiAiWmM1bjlxNDgyRTVSdUhzSjRlZFdzcjc1YXh3elIzbVdibTVUNWxmbkJ
  UUklBaWNhR1BvZwogIGJxYTU0eVNBN3NXamg0OTB4cnZyRXlhQSJ9fX0sCiAgICAi
  Q29tbW9uRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQlVGLVA3UzItV0ZFR
  i1EM01MLU9LQ0MtWFlPVC02U0xEIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOi
  B7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg
  0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICI4U2hGY21OejVCVzluR09idTdfdFVa
  RDVobTVhblM3VGFyNTNSWERjZzVheWlQcGI3TDh6CiAgVkMxbGpqSmVBdS1oazlUV
  U51eVhFN3NBIn19fSwKICAgICJDb21tb25BdXRoZW50aWNhdGlvbiI6IHsKICAgIC
  AgIlVkZiI6ICJNRFlRLUpRQjItM0VPQy1ONFpELUZCSkUtSDNJWS1XTTZWIiwKICA
  gICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgi
  OiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6I
  CIyelBsMTBxbnpwR0hfMWlkREZhVk15RXltRWY2Wm1oTXR6cG1sR2ZaSFoyc2lGQz
  BTSEk0CiAgd2FtZ2hzWVMzaEZMX3FYNm1PLVNRUXVBIn19fSwKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CM1QtV0lQWi1KUkNXLVFaRk0t
  U0NRTC1PVlZPLUFITzIiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgI
  CAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLA
  ogICAgICAgICAgIlB1YmxpYyI6ICJvcjJYLXJQMHRhVFg2NkZ4WTY4UlI0UjdHZmc
  zcjYtTUljMzNRZUVnVTF3S2lfSFZLeWlCCiAgbktEWFpFZXhZdEVDMlpIN0NOcVVD
  MlFBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2",
            "signature":"lhicUvvDwdI2cJGDmMDmEYhZIDOp0be5IjblZGn0
  Uycnu3odE_h5jGOY3W58RlXBr_NHUwHfAbGAHcigqzKxUJGrM9MKXzgYF5JUx7uHS
  N4qXpAcBPHHnU1qLepITOsRMoT92a3KmLGskrt9O2PlgBQA"}
          ],
        "PayloadDigest":"hg5Z9SBDuRlEje8R3-0KZFBNHW738w1k0ZvF-nNJ
  KZ4acEZKjmAwOzx3cbf6HXJoWy3eLs4BqYdhXQWkftir1g"}
      ],
    "EnvelopedCallsignBinding":[[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDYWxsc2ln
  bkJpbmRpbmciLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgI
  kNyZWF0ZWQiOiAiMjAyMy0wNi0yOFQxNzowMDoxNVoifQ"},
        "ewogICJDYWxsc2lnbkJpbmRpbmciOiB7CiAgICAiQ2Fub25pY2FsIjog
  ImFsaWNlQGV4YW1wbGUuY29tIiwKICAgICJEaXNwbGF5IjogImFsaWNlQGV4YW1wb
  GUuY29tIiwKICAgICJQcm9maWxlVWRmIjogIk1CM1QtV0lQWi1KUkNXLVFaRk0tU0
  NRTC1PVlZPLUFITzIiLAogICAgIlNlcnZpY2VzIjogW3sKICAgICAgICAiUHJlZml
  4IjogIm1tbSJ9XX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBL5-JSN3-V56Q-4ULY-GY7X-GM3V-KVPZ",
              "signature":"1uBDFGIPMzRcaScJBzyIOECcYtYffBLWM78uv9
  gUiMbLtE_Jg46YyNU5cpStxqNQBKWcKSBEaACAHlNh9eHhL154JZBXuwSw2I0Cac5
  VhS-oHkQragtf3I8Eybdx3FmjW_1ZhBQfp8BJbU05xJY8qyAA"}
            ],
          "PayloadDigest":"PWNW2k-pPnUQGwz5cUiPJbU8bYBcHSBWkbwLO6
  fLqsIP_vEdl3vWpibWyt9ZZF_rM3F5T3DhGXJHM0tsALPKfg"}
        ]
      ]}}
~~~~


The response payload currently reports the success or failure of the bind operation:


~~~~
{
  "BindResponse":{
    "EnvelopedAccountHostAssignment":[{
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY2NvdW50SG
  9zdEFzc2lnbm1lbnQiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCI
  sCiAgIkNyZWF0ZWQiOiAiMjAyMy0wNi0yOFQxNzowMDoxNVoifQ"},
      "ewogICJBY2NvdW50SG9zdEFzc2lnbm1lbnQiOiB7CiAgICAiQWNjb3VudE
  FkZGVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiQWNjZXNzRW5jcnlwdCI
  6IHsKICAgICAgIlVkZiI6ICJNQkpBLVNJR0QtRlVOQi1QQVI3LUVCUEItV0FQRy1I
  SERGIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIl
  B1YmxpYyI6ICJPUzZsU2lIeThMaVo4Y2tnYlVLcUk4Z0UyaWRjTWFDNFVxaXcyYUF
  FYmphcVRQbWlCUjhxCiAgMFpmdDYyNkRJLVEzXy1UUWthUXZUcXlBIn19fX19"
      ],
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


It is likely that a future revisions of the specification will specify the host(s) to 
which future account service operations are to be directed. This would allow the
account management operations to be separated from the account maintenance operations
without requiring the traditional tiered architecture in which every interaction with 
a service is first routed to a host that cannot perform the required action so that
it can be directed to the host that can.


