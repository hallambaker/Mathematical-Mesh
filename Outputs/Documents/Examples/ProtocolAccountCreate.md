
Alice requests creation of the account alice@example.com. The request payload is:


~~~~
{
  "BindRequest":{
    "AccountAddress":"alice@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNREtTLUxMTDUtV1
  BESi1VS0UyLTRQUE0tWTY2Vi0yTElKIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMS0xMi0yMlQwMToxMjo1NVoifQ"},
      "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1ES1MtTExMNS1XUERKLVVLRTItNFBQTS1ZNjZWLTJ
  MSUoiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJySlJCdGRySDZra0piNU9DRElrYkR0YllIYUo1aW50U0hhMllnTX
  lyLTJqT3J1M1VGeXl2CiAgSkJ3eHJhMXgxbmZkeERUN0R1blhzRUdBIn19fSwKICA
  gICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2Vy
  dmljZVVkZiI6ICJNQ0xWLVU2WVgtUDNUTy1YM1ZELUxJWE0tVjdJRC1aVjdIIiwKI
  CAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1DTjItR0tSUS
  1MNDZHLVo0QUQtRlRMVy1EQkYzLVRYNVgiLAogICAgICAiUHVibGljUGFyYW1ldGV
  ycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYi
  OiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIm42bFZidlhnS3B3Q042UmMwb
  0xuc1ltcWFCVGJxUUphNEVrdEluR251ZVJXcEJiQU1YZFEKICBkSzlFclQzRmhFU3
  F4UXluSXVtY2xKeUEifX19LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogICA
  gICAiVWRmIjogIk1EUlEtS1NWWC1FRjRaLVJFSlItTlNFMi01TE5XLURESFkiLAog
  ICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNES
  CI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIj
  ogIkQ2UnhSR1NtWEpVdFJCX3RWUTlucjl5TmVFYUpaUUZ4T3lLWXhWbHdLY2pmSEF
  WRXd0clUKICB5V0JicndRM1hBZFlaSUsyLVQxcDR1S0EifX19LAogICAgIkFkbWlu
  aXN0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTURQTS1LQ0pYLVIzS
  UgtN1c1SS01WEI0LUxUT1otVDdPTCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIj
  ogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJ
  FZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIkRjVTJWQ0RwdkpuU0VlMGJKb3dj
  dzBXRGxJbFpQckx1LUx6U3JkZ3dRZGw5VVA2eGI0aTAKICBQb2doUkxScFBnTGpnc
  TQ0a0lKczM3Z0EifX19LAogICAgIkFjY291bnRBdXRoZW50aWNhdGlvbiI6IHsKIC
  AgICAgIlVkZiI6ICJNQkVBLUU2VlMtNVI3Qi1WQTVDLVVPTFYtR1ZGSi1ZVlMzIiw
  KICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVD
  REgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJIbG9CTFVETFFLSV9DcjVvUlNpdWlBbjNKekFLd0hHeW9QUnNvaWxONkVNM3
  o4bkFqb2xfCiAgcnBsbEpLVHBZTC1uREttZGFwMkExZjRBIn19fSwKICAgICJBY2N
  vdW50U2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1ENVUtWklXTS1PT01XLU81
  TjMtRjdTSi1WRjRHLUkzNU8iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKI
  CAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0ND
  giLAogICAgICAgICAgIlB1YmxpYyI6ICJENzg5bU5IOWRILW9SUWNneWNLRDhNRUR
  uMlZNUjNUTHByVnlCZUJRVFYyWDM5QTFOcEJYCiAgc04xOFloRlZYeGtQQUZ6R3g4
  eDdPa1NBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ",
            "signature":"80E32_6-lW0SXpGExg6tpA97MHYdxU7QALZ5-zL8
  IjljNrwaRqt_xd3tEczRwRxGILdUg2Qjlg0AQtDR9KeG_qYuFnpGIKGTKxbhpC1xk
  XNVSvuvkycNduKHPVmNtrMYZYooN6M1vvgitEKi-sd_2xoA"}
          ],
        "PayloadDigest":"4BGB5zcU6mIX0c3LNVO8hLRGVemVEzfb2bp2C6oW
  GYY16l34MrjQqW3ubG7Gh5Hk8zo4KgREBhA_Af82Si6Cug"}
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
  sCiAgIkNyZWF0ZWQiOiAiMjAyMS0xMi0yMlQwMToxMjo1NVoifQ"},
      "ewogICJBY2NvdW50SG9zdEFzc2lnbm1lbnQiOiB7CiAgICAiQWNjb3VudE
  FkZGVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiQWNjZXNzRW5jcnlwdCI
  6IHsKICAgICAgIlVkZiI6ICJNREhTLVFZV0EtR1dJRC1MWjc0LTVNRUUtRUFLVi1Q
  REkzIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIl
  B1YmxpYyI6ICJpWmpUcGxtdW5WelpDX1ktMklXOTlkZS1saGJ2bkItLVZSYVk4VXd
  TZnVNSUJuVzhidkRPCiAgb1p5WlVhNFY3QUZnZjA1QkR0dHZVMDZBIn19fX19"
      ]}}
~~~~


It is likely that a future revisions of the specification will specify the host(s) to 
which future account service operations are to be directed. This would allow the
account management operations to be separated from the account maintenance operations
without requiring the traditional tiered architecture in which every interaction with 
a service is first routed to a host that cannot perform the required action so that
it can be directed to the host that can.


