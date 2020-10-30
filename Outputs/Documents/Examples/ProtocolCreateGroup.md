
The request payload:


~~~~
{
  "BindAccount": {
    "AccountAddress": "groupw@example.com",
    "EnvelopedProfileAccount": [{
        "EnvelopeID": "MBLV-H6QA-GY7P-X2GQ-Y6OD-SZR6-VIYG",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQkxWLUg2UUEtR1k3UC1
  YMkdRLVk2T0QtU1pSNi1WSVlHIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Udyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjAtMTAtMzBUMTQ6NDg6MTJaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZml
  sZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQkxWLUg2UUEtR1k3UC1YM
  kdRLVk2T0QtU1pSNi1WSVlHIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB
  7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiaEhwSG9vRTNSeHdtTlpzT19
  hTFJ4MHFLdWtoRTdQSFQyUTVtRXNqVEZGTHAyamNnckZYcwogIG44SnRZZ0dJN
  VZYWkR0OHpsR2JCeElPQSJ9fX0sCiAgICAiQWNjb3VudEFkZHJlc3MiOiAiZ3J
  vdXB3QGV4YW1wbGUuY29tIiwKICAgICJBY2NvdW50RW5jcnlwdGlvbiI6IHsKI
  CAgICAgIlVkZiI6ICJNQ0tDLVZXWFgtS0pWVi00R002LVo0RE0tU0pFNC00VDV
  KIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJVVDIxZVdpVlNxUFBPOFhNNE5GTGtIZ294M29INnNHbmJFR
  WRMdzhnZkV3TFdycm1pUUpfCiAgbXFjOHpUQ0FTX1BoS3VnUXVtNTIwYjBBIn1
  9fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogICAgICAiVWRmI
  jogIk1CTFYtSDZRQS1HWTdQLVgyR1EtWTZPRC1TWlI2LVZJWUciLAogICAgICA
  iUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6I
  HsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI
  6ICJoSHBIb29FM1J4d21OWnNPX2FMUngwcUt1a2hFN1BIVDJRNW1Fc2pURkZMc
  DJqY2dyRlhzCiAgbjhKdFlnR0k1VlhaRHQ4emxHYkJ4SU9BIn19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MBLV-H6QA-GY7P-X2GQ-Y6OD-SZR6-VIYG",
            "signature": "hRcK4xgX_Mxydvopcinr3UEPCumLgdywGts3DA7O6Z9dtmFLv
  oOSuXYo07ldmZT87RzisgC8hFkAstXiEBbivsYuHknCsdNpPCHsdSda52LB5E0
  Rz-M5f9F7Lw3li8v6hSTMWg90cjp1t4NLubAqQzwA"}],
        "PayloadDigest": "LYd5gEKPZQW_pNuWJ5BGAczlgkBPFyJvpuNKO0Oi-WASh
  n9PU2c0BeQf2t2eqoH_HKB8H0siv1wTZgB0j9_yAA"}]}}
~~~~

The response payload:


~~~~
{
  "BindResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully"}}
~~~~

