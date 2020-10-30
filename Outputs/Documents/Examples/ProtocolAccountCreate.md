
The request payload:


~~~~
{
  "Hello": {}}
~~~~

The response payload:


~~~~
{
  "MeshHelloResponse": {
    "Status": 201,
    "Version": {
      "Major": 3,
      "Minor": 0,
      "Encodings": [{
          "ID": ["application/json"]}]},
    "EnvelopedProfileService": [{
        "EnvelopeID": "MBN5-RZSF-RHST-3I2A-75SF-ALMR-IBQN",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQk41LVJaU0YtUkhTVC0
  zSTJBLTc1U0YtQUxNUi1JQlFOIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiA
  gIkNyZWF0ZWQiOiAiMjAyMC0xMC0zMFQxNDo0ODowNVoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9
  maWxlU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CTjUtUlpTRi1SSFNUL
  TNJMkEtNzVTRi1BTE1SLUlCUU4iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI
  6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiO
  iAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJjRGw3d3Y3d1cwZTk3Mlh
  jdVBUOUJOZVIwdnlyMkpiYm1Bc0J0RGlTSkJHbGZTLUZhbHZVCiAgNk9LeXdVT
  3Vpa2xJRWh1d0t3YTBHU1dBIn19fSwKICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI
  6IHsKICAgICAgIlVkZiI6ICJNQkNSLVg0UVAtVEFERS02Q09JLU5aRkItQUhBW
  S02UEJSIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgI
  CAgICAgIlB1YmxpYyI6ICJLSjVzMFUyMWFRUmVDR2I0d3E0cUxOQ2hsS0xLOVV
  WT09TNEJIcWZEeU5vWmpfM0tJQjZKCiAgT3pEeXNheE83MnlpZmJfYlF1ckRvT
  0FBIn19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MBN5-RZSF-RHST-3I2A-75SF-ALMR-IBQN",
            "signature": "PJH5flAs3j6Sbp1Mu_1AqpVVMohdkdSOAqdDw3wRx7eUvgG8A
  SbakQIFBYacJVSgvE7p_Y170cgAWxyE6QeIvvRiBGVArt2TJi2Y2th62cRgnGv
  rF51o75itFCKoxgWUyuzRNMs1zozVwBYs5dXhny8A"}],
        "PayloadDigest": "n-tKBMjjZcxAT06S5qclRpdlUl5shbUWBsUks_MexS90u
  wzWh0pM3XzRfT1T7C7SSIwHap6lUs74mZj5ViTaqA"}],
    "EnvelopedProfileHost": [{
        "EnvelopeID": "MCF2-WHYW-XAMM-VBHM-OR6H-MS6A-EK6C",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQ0YyLVdIWVctWEFNTS1
  WQkhNLU9SNkgtTVM2QS1FSzZDIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Uhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0xMC0zMFQxNDo0ODowNVoifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DRjItV0hZVy1YQU1NLVZCS
  E0tT1I2SC1NUzZBLUVLNkMiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJVZEMyd2RKMkw1bE56dXJPbFl
  5SEU5LWFtMHlrWXFtZzY4QnotMXdqb0VmendKSW5HSHNGCiAgamJJdnk2U19vN
  XNlc28yTVhQRnRDRVVBIn19fSwKICAgICJLZXlBdXRoZW50aWNhdGlvbiI6IHs
  KICAgICAgIlVkZiI6ICJNRDVBLTZMRkctVVlVNy1ETVZULVpZSkstUktFMi0yU
  lBEIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymx
  pY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJjcjJsNUhFNWVEcThUOVo3c2psbTdFc2RXRVBlclJMMmR
  4a1FvVmU4ekFReUVDc1NvSS1qCiAgRDNGenc0UUdwM1psUFRxN1EwTkRmYzJBI
  n19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MCF2-WHYW-XAMM-VBHM-OR6H-MS6A-EK6C",
            "signature": "hHIAmvxQ_9ppVr-DiFqS7r6Q3vc-DH--Aw5AEAlGBd0h9jVTy
  5blBwMNZrESciqluoXdrz76eTGA_TgTMdfwUEuQGQghzt0cKnH--_Z5GsiF2SH
  HTkBdeqgykQs9EkY2ts32bWl6hDRH_YW0e2oPARYA"}],
        "PayloadDigest": "hy-yWkOfNeMEBOpP2QxSwju5llhHWhP70LxR5lhFsEIw5
  JQgpZd47UG-nhvug9-4CqZK4qCTWWrStgUE3L7MRw"}]}}
~~~~

