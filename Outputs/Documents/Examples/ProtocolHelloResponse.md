
[Note, this is showing the payload, not the binding as is intended because the current code 
doesn't implement it as intended yet]


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
        "EnvelopeID": "MAC2-XY6M-MEV2-QFIM-43XQ-5M3B-NZSE",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQUMyLVhZNk0tTUVWMi1
  RRklNLTQzWFEtNU0zQi1OWlNFIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiA
  gIkNyZWF0ZWQiOiAiMjAyMC0xMC0yM1QxNToxODo1MFoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9
  maWxlU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1BQzItWFk2TS1NRVYyL
  VFGSU0tNDNYUS01TTNCLU5aU0UiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI
  6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiO
  iAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJsRDlHV2FfcGthSlVZdnE
  2eVh6dkQ0QjVDemRHdUlyMUVsaEVZb29JRngxTmNrRkhQSENCCiAgYUQtR0FmV
  nRNMzBOa0xGcmxKOHlJd3lBIn19fSwKICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI
  6IHsKICAgICAgIlVkZiI6ICJNQVVDLTJCWEktM1RCWS1KSTVTLUNTVUItQVlLQ
  S1YTEpXIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgI
  CAgICAgIlB1YmxpYyI6ICJEbmtQOTIyQXFNMUNoTDB3dllYRThfRWJ4MWY3S3p
  fMVZVZjRLOU9sdm85TlNZRTVWeDNPCiAgRHRHVGdoZlpMVVVJWWdUcmZCemlQb
  mtBIn19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MAC2-XY6M-MEV2-QFIM-43XQ-5M3B-NZSE",
            "signature": "PIw5vNBEjdz2nvKRZAaS94ybVav4UigBj-3DC8bxmJCl6DNYf
  xPoHmaHyEVa8HXldfzbE3db-nCA2xtFNH4MzKTeiCHNHbCjqpSj3mP-F_3BzTN
  3xMVFssfJQm31r-apkOBp7_RhC741GGd0ALdgqhIA"}],
        "PayloadDigest": "YaoJ_dhwHQr42DPxgu_NbliMHf9U6BF_bcKIDRYtWZeMk
  X39qyTGm_tKMo6A1QNdcaMSLKjQfslaTzGTGtT5rQ"}],
    "EnvelopedProfileHost": [{
        "EnvelopeID": "MDPW-XI3O-2MLR-PY3P-4XHC-4INW-6AW4",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNRFBXLVhJM08tMk1MUi1
  QWTNQLTRYSEMtNElOVy02QVc0IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Uhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0xMC0yM1QxNToxODo1MFoifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1EUFctWEkzTy0yTUxSLVBZM
  1AtNFhIQy00SU5XLTZBVzQiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJjQnBRbHVoREZnUVlRdkxZZEt
  zUHVaMERqSU9IbURqM0FCem5HMktRc3R0clZWemtYd3cxCiAgSGZZcEp5UERVc
  mFuRDlLN0luaEZDeC1BIn19fSwKICAgICJLZXlBdXRoZW50aWNhdGlvbiI6IHs
  KICAgICAgIlVkZiI6ICJNRFpJLU9WQVYtV0NYSS1XUzdWLVNUVUEtNURVWi1CW
  UxSIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymx
  pY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICIzLVBvRGtaYWpuV1k0am9rREF3am5sSkV5ZjZMUWpfelR
  0bWluX0lwZTNqRW82b1BRUWxnCiAgM0FFdEhFUXJtZzlmRXQzSV8xQUxYa29BI
  n19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MDPW-XI3O-2MLR-PY3P-4XHC-4INW-6AW4",
            "signature": "Wmawa__VRC0lvrhsql_ESAJHQKM4Yk7DprGrADCikEsLRctIS
  e9Ufb9JXjBgmKYm0WYM_c7mczqAuy9du_wOMU3gfck6INJ2Oki3xIJ3QY7R7tA
  _6m1Sy8-jJcujzvTmN8xDfUhpVzINP8zZhv4G5TcA"}],
        "PayloadDigest": "jq_8Ej1Gar9Y3JLSTe6sbrAr53ukWPpahjzU5c-ZbssiA
  1mB0lvDukW6OcdTbm_LCZkLWctwXHcdIDJ8Wh-w_w"}]}}
~~~~


