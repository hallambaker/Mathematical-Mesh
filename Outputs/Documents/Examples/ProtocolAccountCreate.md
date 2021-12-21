
Alice requests creation of the account alice@example.com. The request payload is:


~~~~
{
  "BindRequest":{
    "AccountAddress":"alice@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRExXLTNVSzQtSU
  ZXTi1RVjNDLUxVQVAtMkpYQi1WWVhNIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMS0xMi0yMVQxMzoyODowM1oifQ"},
      "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1ETFctM1VLNC1JRldOLVFWM0MtTFVBUC0ySlhCLVZ
  ZWE0iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJzODUwSi1TUUpINllyTmFQLVRsSElIZGczVlJUSXVQSDR3ckZWdX
  F2Q2NXcHUxYzZPUTNPCiAgT1VTcm9kWUl2T19sQnl5LTEtcnAxMVNBIn19fSwKICA
  gICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2Vy
  dmljZVVkZiI6ICJNQk8zLVlZR1YtUktMSi00SkZELU9RRDUtQkVKUy00R1lPIiwKI
  CAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1BS1otMzJSQS
  1UNlpCLTZFS0YtRDNCRC1XSUhSLVVFM1kiLAogICAgICAiUHVibGljUGFyYW1ldGV
  ycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYi
  OiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogImNKQ2xHR0VQYTlWaXdZNkNQW
  VJHNnZQdk1fdjcteER6M0tEUnRCZGJWcHhYWmx2NE9sWk0KICBxb2ZVMWtQR0NBOE
  9YbVFXdWVRdFB5LUEifX19LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogICA
  gICAiVWRmIjogIk1DWDItNlk0SS1IVkhNLUpWNUwtMkRVWC1PSUFZLVpGTFUiLAog
  ICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNES
  CI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIj
  ogIkp6TXNZRTdSSmFvWVpMTkFYMFg4ZEYxUE94bEhBNE5ZWjV3ZFBRSU1SRzNSeHV
  DNnBfZVMKICBWV29DTmoxX19WeGg0T05ScHJhUUh1OEEifX19LAogICAgIkFkbWlu
  aXN0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTUNRQS1ITktFLTNUW
  kwtS1o0QS03VVZULU1YWlYtUzZUTSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIj
  ogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJ
  FZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIjk2RUFHQlNiSTlWY18xLWRnTlhG
  VTYwVXhaaV95QnR3R3lVM2E1N3hOX3FqNnlNYVRvSGYKICBxQk5FcGRWWEJqRFRsM
  XV4SGNZeUI0d0EifX19LAogICAgIkFjY291bnRBdXRoZW50aWNhdGlvbiI6IHsKIC
  AgICAgIlVkZiI6ICJNQlpRLVhKN0stWTROVi01SUdULUZGM0EtQUlKMy1ZWEcyIiw
  KICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVD
  REgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJYSm40MkJXTENoVFh6SmxDdHhwT0ZCSk5zdl95M2pjTUZHVWJ1UnhUMFVkZU
  lKYllYODRrCiAgN1g4WGM0dGhDZTg4eGFmUTlqZGQ4Q09BIn19fSwKICAgICJBY2N
  vdW50U2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DNkItUTJWVy1TQzJNLTQz
  NTctQ1VYQy0yTVk0LVVTUFYiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKI
  CAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0ND
  giLAogICAgICAgICAgIlB1YmxpYyI6ICItV2tMTWtEWU4ySHJiS1RYbmdsbEpWZ0x
  nT3VkQW9YdU1QZ1FXRHRZSWcyaVN5RS1KWWQyCiAgVDRELTJsQ3pfSUludHpSRG1V
  RFdoQW9BIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM",
            "signature":"dD4_0cp11gPLnr5BZaM-jICzJC3AjXQvcvVyTD__
  54nYZRkCoH69TpqV4evAa_LxQo9uaAXoeUWABlCuc73jKlTTAKRnviA0YHMOw0-BD
  rKyr_anb2gJn3jCzblGQpx1NkSCjyrTP6FoJbOh6kgqeDsA"}
          ],
        "PayloadDigest":"s7AqhY6q9pCshiJWX285PgQO7pCcA4HeRCD-K4ig
  sXRnEvKjAEZMnMlT24fvG2Q9NvD5K5JaeT3ce31CRbsmOg"}
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
  sCiAgIkNyZWF0ZWQiOiAiMjAyMS0xMi0yMVQxMzoyODowM1oifQ"},
      "ewogICJBY2NvdW50SG9zdEFzc2lnbm1lbnQiOiB7CiAgICAiQWNjb3VudE
  FkZGVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiQWNjZXNzRW5jcnlwdCI
  6IHsKICAgICAgIlVkZiI6ICJNQ0dVLVJNQVEtSVpOTy1NWEIzLVBIQzMtQlRISy1S
  N1RPIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIl
  B1YmxpYyI6ICJ4SVlaeUdLVXk5WEdSdWlQVHdKQm9FVDBTV29GSkxFOFprc0hJNVl
  UajJQRTltQldiRV96CiAgMmhJN3h4d3FCVzRRYTdRcnJMeC1CcWlBIn19fX19"
      ]}}
~~~~


It is likely that a future revisions of the specification will specify the host(s) to 
which future account service operations are to be directed. This would allow the
account management operations to be separated from the account maintenance operations
without requiring the traditional tiered architecture in which every interaction with 
a service is first routed to a host that cannot perform the required action so that
it can be directed to the host that can.


