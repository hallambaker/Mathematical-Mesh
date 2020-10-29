
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
        "EnvelopeID": "MC2U-ROCY-PK5J-5BO4-FPNT-3LAJ-KFG2",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQzJVLVJPQ1ktUEs1Si0
  1Qk80LUZQTlQtM0xBSi1LRkcyIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiA
  gIkNyZWF0ZWQiOiAiMjAyMC0xMC0yOFQyMzowMTozMloifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9
  maWxlU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DMlUtUk9DWS1QSzVKL
  TVCTzQtRlBOVC0zTEFKLUtGRzIiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI
  6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiO
  iAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ1dlNscVhlSnJ1QWttZ3p
  wYkZWWWhEMEpCSU1qRFdhSTc1cl9zM3lneHQ2bFRNNEI5THFLCiAgZm5abkRSY
  UxHUHFUZTZtQk4tMnNsanVBIn19fSwKICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI
  6IHsKICAgICAgIlVkZiI6ICJNQlA1LTRCVVktUTRSNC00R1g0LUlBVEEtR0YzN
  y1LSjNIIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgI
  CAgICAgIlB1YmxpYyI6ICJZR0owdmRGdVl2cTg0X0s4X3kwMU1tWVgyVW5mZGt
  RVUNEY0VhYXdvRGgzOE9vSjF1eVE3CiAgc1RHWWtJNW16Q3lHMGo1RUxsbWM4L
  UtBIn19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MC2U-ROCY-PK5J-5BO4-FPNT-3LAJ-KFG2",
            "signature": "gauXDCjg7tL6BE3egpu03BeDZtFX4WLr4Qx9kxG_Ok1Vp6gFJ
  FEBAt-0XC6roJGfu_zwMXvNteAAFND80f4PZw60IibQn1T4vcDPlME4dmxXbHL
  qAZhKw6glYJ8Haul6Qc6HaPw3z6x4nnLSOvHTKQ4A"}],
        "PayloadDigest": "Rupun9FEu87Y71G8g0C1DHE4N7-SgaRvASVdHjNDTq7zF
  c_c6t_877z0V1h82oZII17l8fBnRuZ2kG7QW5KOeQ"}],
    "EnvelopedProfileHost": [{
        "EnvelopeID": "MBXP-6XN6-TJG3-YGOY-NWFW-TNSQ-BDVF",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQlhQLTZYTjYtVEpHMy1
  ZR09ZLU5XRlctVE5TUS1CRFZGIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Uhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0xMC0yOFQyMzowMTozMloifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CWFAtNlhONi1USkczLVlHT
  1ktTldGVy1UTlNRLUJEVkYiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJTYVFlRUZ1WTJHcWRvc2tFSE0
  ybER4bGxrNHN0NDcwUE1IcFRISFlzLTBwX3ZJVmhOMER3CiAgai1uQkpyN1RwS
  2NGbHVDQklaVDFhQ1FBIn19fSwKICAgICJLZXlBdXRoZW50aWNhdGlvbiI6IHs
  KICAgICAgIlVkZiI6ICJNQVBQLTZMTTYtM1FCWS1FWElJLUpXNkMtVjdTRy1BT
  FlIIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymx
  pY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJ1WHJiblYyZ19KRWZCam5zLVZvSW5LUmtPMHVCUDdySUZ
  PVzFJWjhodTNwTWNLSEhtT0NmCiAgS3dYRWlEYW1ZUDlhenFMNHhaQWZOZmNBI
  n19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MBXP-6XN6-TJG3-YGOY-NWFW-TNSQ-BDVF",
            "signature": "FsM24kfeLnnm6f-g8ZzbPCEcWgAk3ts_xIiHp29_H2ABaYPxq
  Lnd8JJ9FlLrftHvFSBMCa6rYXEAvPJJXCWnXiTMExStdVVtO-hYyV9zRMNGV2t
  ROZLPMVe9vEM1si0IIIs8INuT_lAIGKEx6PYjsCAA"}],
        "PayloadDigest": "wbVpnWUtZdCckN0VC46hILShGD1SmJ8IUtIggtMEYJlE4
  5F_GCas54MmyyEE46GsvH8PdeyuKcH97D7UjHM3LQ"}]}}
~~~~

