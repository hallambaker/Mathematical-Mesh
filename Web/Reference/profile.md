

# mesh

````
mesh    Commands for creating and managing a personal Mesh
    create   Create new personal profile
    escrow   Create a set of key escrow shares
    export   Export the specified profile data to the specified file
    get   Describe the specified profile
    import   Import the specified profile data to the specified file
    list   List all profiles on the local machine
    recover   Recover escrowed profile
````

# mesh create

````
create   Create new personal profile
    /account   New account
    /service   New service
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /new   Force creation of new device profile
    /dudf   Device profile fingerprint
    /did   Device identifier
    /dd   Device description
    /alg   List of algorithm specifiers
````

The `profile create` command creates a new Mesh master profile and 
(optionally) registers it with a Mesh service.

By default, the default device profile of the current account is registered as an
administrator device of the newly created profile. If no default device exists, a 
new device profile is created. The `/new` option may be used to force a new device
profile to be created.

The `/did` and `/dd` options specify an identifier and description for the device if
a new profile is created. Otherwise, platform defaults are used.

Cryptographic algorithms to be used for the signature and encryption algorithms 
may be specified using the `/alg` option.


````
Alice> mesh create
Device Profile UDF=MAYU-SLRH-VTBR-V26K-JGH2-VDVU-CS2T
Personal Profile UDF=MAZM-EQPB-Y6BY-B3W4-6QZS-CJES-QLTR
````

Specifying the /json option returns a result of type ResultCreatePersonal:

````
Alice> mesh create /json
{
  "ResultCreatePersonal": {
    "Success": true,
    "DeviceUDF": "MAYU-SLRH-VTBR-V26K-JGH2-VDVU-CS2T",
    "CatalogedDevice": {
      "UDF": "MAYU-SLRH-VTBR-V26K-JGH2-VDVU-CS2T",
      "DeviceUDF": "MDZW-SCAQ-IJEY-QUWH-G3HN-P3SV-HFCL",
      "EnvelopedProfileDevice": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTURaVy1TQ0FRLUlKRVktUVVXSC1HM
  0hOLVAzU1YtSEZDTCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogIm1VbUVPSzlKblRrMjdqbVJOUlhON1g
  0TG5VbmlQWVh1YmJ1dTdQM1dPTXVMSUVpX1VZeUUKICByem9JVmxOTmZlNEpCM
  klJekhJWHVOSUEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUQ2My1SWlc3LVBGUjYtNllJQy1RSDY3LUlRTDQtRVM1UiIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVib
  GljIjogIklrOER1VFpqc3lYSHlyRG0yd2NDbi10Mjk2ZnhBS29rYlhYdzlkOU1
  Xd2dEWTZlOC1tYUcKICBVQl9ydXFqRk1aNUdNNldqdUF6cmJOUUEifX19LAogI
  CAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1BTkktVk9
  ITi1RTEVJLVBST0EtQlBOQS1CQlQzLVg2TU8iLAogICAgICAiUHVibGljUGFyY
  W1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJqQURfT2E1c
  zNzWVIzcWlxaGhHNkhqSUdIZzZqM2V1RFNXdzFWVHdSalM3RkVFamE4RnoyCiA
  gam1QcWs4SHVoV3ZGbEl2WnFPNXY5R2tBIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MDZW-SCAQ-IJEY-QUWH-G3HN-P3SV-HFCL",
              "signature": "bDJrepE5Du_lM9lABOgtz4JAKaggo9jaME5rEvAqgP1IrLS8L
  9ch9Lw5oyQBHC55Vj96kICjhciAI7o-htZkkTFDRvi_TJP_7Khwk79iHFO0JlY
  OpjLNiZ_eNNFAGe07frcQvenaMijdYnAP1OJOFjcA"}],
          "PayloadDigest": "hbZkn4CvPkgAB-z7ED1cF6wc0S5DYOeR6Rfm8nX-SdKBM
  2G3IRou_7sC02tB4eaCANbMRArXm17EmmWwGzPE8g"}],
      "EnvelopedConnectionDevice": [{
          "dig": "S512"},
        "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQVlVLVNMUkgtVlRCUi1WMjZLLUpHSDItV
  kRWVS1DUzJUIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiRFR5bmc1NExoQ2NIaU9PRVhxTFdsMVpaanl
  maDNrUWc4enNvNjRUdEV3UG9rd1d4bWZRNQogIEk5NHQwOVdRRF8zVHdreDRzY
  0tYVW1ZQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI
  6ICJNQUFMLURBR0gtTDM3RS1EQ0dKLVkyWUItRjNHVC1NQVNSIiwKICAgICAgI
  lB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB
  7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAieWg3czZOWms3RlR6VnpsRFB5TS0zWTJRbUNhNV9wN3Q3M0Y0M3B4NEo0N3l
  YRnJ4U0Q4MQogIEFHRUl1UjdrUXRFbmlpbEdxVjlwWDl1QSJ9fX0sCiAgICAiS
  2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUNSVi00N1lZLUx
  UMk4tRjNZUS1YNUU1LUU3RlctRkpZNyIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImN
  ydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIi1ZRXhHTmtydUNBM
  XFDNlpqcUNwSUl6N1VKbm1FVl9NX3Rlekp1bjQ5SkJDemxfOXlyQjMKICBhVmR
  uRjNGREVqS1IzN3JKLUg2cXA0MEEifX19fX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MCAD-O4YS-FOK7-TJSI-UPOT-EX6T-XHS5",
              "signature": "dY4HMdzYbSZhGBQjwuoWQ1LgXNphvcPjPanr1MhIIT2JyTd_T
  v_cb-vsgWdx1ZksarwGGQ38yJAAVANEhXHviH2jNd7DifLFLz4pUQz6yOfUYWv
  UbVXsr9IW2-yAbq6bDsEJTMKdMM21dYEPw25LOwMA"}],
          "PayloadDigest": "03022GlVMw__EQlhv4kowWYylsOZ9ZoA-VnkdaqGITbmL
  mcqpKLusBrD6OEXiCCQBYmJdLvmsEIGG3a4mQRi3g"}],
      "EnvelopedActivationDevice": [{
          "enc": "none",
          "Salt": "oiaLPZHSpF22a-TJU2iNKQ",
          "recipients": [{
              "kid": "MD63-RZW7-PFR6-6YIC-QH67-IQL4-ES5R",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "vuvNhShovuLomeZM1MyoIImNUSLTGKJUZq6RsCClX3ooiSuikg-H
  rZC-j1nwjo4t6VGB-BCNPNgA"}},
              "wmk": "pqampqampqY"},
            {
              "kid": "MALM-LPA7-36CN-KCYR-TZQT-Y2FF-QNOR",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "tM9oKJYjmcyEOTfAK0yapDIYkqHwYt7E5t6lEo6u-6gS1UvJQJ7P
  F5GsDMrb5d0Awr4d_boaCzwA"}},
              "wmk": "pqampqampqY"}],
          "ContentMetaData": "ewogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tIn0"},
        "ewogICJBY3RpdmF0aW9uRGV2aWNlIjogewogICAgIkt
  leVNpZ25hdHVyZSI6IHsKICAgICAgIlVERiI6ICJNQVlVLVNMUkgtVlRCUi1WM
  jZLLUpHSDItVkRWVS1DUzJUIiwKICAgICAgIkJhc2VVREYiOiAiTURaVy1TQ0F
  RLUlKRVktUVVXSC1HM0hOLVAzU1YtSEZDTCIsCiAgICAgICJPdmVybGF5Ijoge
  wogICAgICAgICJQcml2YXRlS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiA
  iRWQ0NDgiLAogICAgICAgICAgIlByaXZhdGUiOiAiRDRxNjEtWVdEc0dvRDdTS
  ms1UDFHZUVoRThHakh4RjVPU1dQdl9DOHh5a0FYZnplVEZaCiAgTEtiemc2ZDJ
  CT2FNOVRoUnE2bVJTY0R3In19fSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogI
  CAgICAiVURGIjogIk1BQUwtREFHSC1MMzdFLURDR0otWTJZQi1GM0dULU1BU1I
  iLAogICAgICAiQmFzZVVERiI6ICJNRDYzLVJaVzctUEZSNi02WUlDLVFINjctS
  VFMNC1FUzVSIiwKICAgICAgIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGV
  LZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHJpdmF0ZSI6ICJ5YlhSUUtMU3JjbUVEODEzQTlnZUt5eTN1SGczbDdqc3V
  JbHR5OGs1OWRsRFpRNmxLeTMKICBGWUx0NmQteVp4dmhnbTlBb1BNUlpXV1Uif
  X19LAogICAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1
  DUlYtNDdZWS1MVDJOLUYzWVEtWDVFNS1FN0ZXLUZKWTciLAogICAgICAiQmFzZ
  VVERiI6ICJNQU5JLVZPSE4tUUxFSS1QUk9BLUJQTkEtQkJUMy1YNk1PIiwKICA
  gICAgIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjogewogI
  CAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0ZSI6ICJ
  LYk56a2hNRXhxRG1RY2c5TVJ5YzBXcUJ4T0k2U19DdHRwekFvT0N0bk8zelpzc
  GdPYW4KICBSLUx4VmlyUndQbS1fLTdxVGlOMmstelEifX19fX0"],
      "Accounts": [{
          "AccountUDF": "MDX7-4DMY-6FKX-NZ2X-VIKD-GL4W-W5PO",
          "EnvelopedProfileAccount": [{
              "dig": "S512"},
            "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1EWDctNERNWS02RktYLU5aMlgtV
  klLRC1HTDRXLVc1UE8iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ1VXRkMzN4b0FyX293bXNRZm5YVGp
  pdUtsWTBvcHZfaFphdF9TU2d5N2c2a3g5Yl90cHdmCiAgcFZpNVAtTEV4eXlne
  jhRVElxOVJmUTBBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1DNkQtRUZXSy03Q0tTLVNWSzQtUk9IVi01MlhBL
  UtQRkUiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogInlVR0I5bjhHclZadW4ycnZuUEdKdmU
  3T3JDejI4enlsakVDbjlycU1hVkk3VV9BNlQ3bHcKICBWUVcxcmc3UTFkVVZTa
  Hl5MFIySXVOb0EifX19XSwKICAgICJNZXNoUHJvZmlsZVVERiI6ICJNQVpNLUV
  RUEItWTZCWS1CM1c0LTZRWlMtQ0pFUy1RTFRSIiwKICAgICJLZXlFbmNyeXB0a
  W9uIjogewogICAgICAiVURGIjogIk1DQ1otWldXUi1MUFVZLUdVRUstRUJNNi1
  TWUtQLUtKSEEiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAo
  gICAgICAgICAgIlB1YmxpYyI6ICJuRzJKMEtIUnhDc2ZiTG9iUlFvYlhmZ2dRV
  mVQRVYxb3dFZGt2OUd0V2loZ0FUdzdGc3NSCiAgQ3pQRzZxX2hRNGE3eHotTVN
  MakYzU2dBIn19fX19",
            {
              "signatures": [{
                  "alg": "S512",
                  "kid": "MDX7-4DMY-6FKX-NZ2X-VIKD-GL4W-W5PO",
                  "signature": "JzATk7tSErQrtxsXf_zjFIL3exe0Xo4p_MaAa29A7l4XAfwff
  PoDzHbXeSGyuIY2-ATnNjnN2jUAmZEIN2eormmex41SS_FUS6iCLikM1KCLEjg
  ET0wT6d6RNGfRguG3kVJWtf7P30WwMtmWGeKQPyEA"}],
              "PayloadDigest": "PeAhvDkZnc2-h4AF-KEQG0ftowISMnfBmbSzuxXSJR04c
  dWgrOJ-uIV2eIGlivP4CDJExj9UW5oRuUZRTApMtQ"}],
          "EnvelopedConnectionAccount": [{
              "dig": "S512"},
            "ewogICJDb25uZWN0aW9uQWNjb3VudCI6IHsKICAgICJTdWJqZWN0VUR
  GIjogIk1EWEYtM0ZOTS1CWE5JLTUySE0tM0tVSS1HNk8zLUg0WUoiLAogICAgI
  kF1dGhvcml0eVVERiI6ICJNRFg3LTRETVktNkZLWC1OWjJYLVZJS0QtR0w0Vy1
  XNVBPIiwKICAgICJLZXlTaWduYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTURYR
  i0zRk5NLUJYTkktNTJITS0zS1VJLUc2TzMtSDRZSiIsCiAgICAgICJQdWJsaWN
  QYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgI
  CAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogInM0Vjd
  sU0tpLXRYWTFfcDhNWjRjYWJTZkVDZllkUTVlSUgwV3NId2xxckZyNzl1REhkR
  DAKICBKLTFUZksyNGN6cnFvbXdNbGlsV2pvc0EifX19LAogICAgIktleUF1dGh
  lbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1DTUUtSlJQWC00VzZTLUU2W
  EUtQUNXSi1ZR0xOLVhWQkYiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICI0eV9lT21zWmw3T19sWDUxeGx
  YSGFPZ1F4cmRrLS1oSnF0d3lxRTlfUzhLTWxlb293Z0VqCiAgaFg5bThyRVhPe
  kQ2M1BxYVJSUmZKY2NBIn19fX19",
            {
              "signatures": [{
                  "alg": "S512",
                  "kid": "MC6D-EFWK-7CKS-SVK4-ROHV-52XA-KPFE",
                  "signature": "Rv7-YhjSvQqg_e2epx1zydZ837E4QZKyn316A27ye2HFcBZ8A
  86rwhJv5trZLohQ93kHXAh8W0gAWXHucFHShUCiHrDGsVBW1LyOMst0h-cCt_N
  wI7F-W0ZgSLvss1ZLzehiDu8_HV6IuKwzYSf-QBAA"}],
              "PayloadDigest": "pHVp94ZPNPy83wAXoJxg3BUlGF8mMvZ_rEIIjwVZ2HoU7
  6ilXQrfoJCwhFCH82sek31LIPwPSLIXLAhRq8Uw4w"}],
          "EnvelopedActivationAccount": [{
              "dig": "S512"},
            "ewogICJBY3RpdmF0aW9uQWNjb3VudCI6IHsKICAgICJBY2NvdW50VUR
  GIjogIk1EWDctNERNWS02RktYLU5aMlgtVklLRC1HTDRXLVc1UE8iLAogICAgI
  ktleUVuY3J5cHRpb24iOiB7CiAgICAgICJVREYiOiAiTUE1Ni1OTUdDLUZXVkw
  tNTJHQi1GQVlNLUc1M1gtUk83RyIsCiAgICAgICJCYXNlVURGIjogIk1ENjMtU
  lpXNy1QRlI2LTZZSUMtUUg2Ny1JUUw0LUVTNVIiLAogICAgICAiT3ZlcmxheSI
  6IHsKICAgICAgICAiUHJpdmF0ZUtleUVDREgiOiB7CiAgICAgICAgICAiY3J2I
  jogIkVkNDQ4IiwKICAgICAgICAgICJQcml2YXRlIjogImZlaXhhUDBrYVFuRkE
  xaUZ2SHBMaGpySDhUUWZFYktLbXpzY05IV3dHdWdMdlpud1huZgogIEdqVUl3a
  nF2VURUZnBmSGwzdzNSZ1d1USJ9fX0sCiAgICAiS2V5QXV0aGVudGljYXRpb24
  iOiB7CiAgICAgICJVREYiOiAiTUNNRS1KUlBYLTRXNlMtRTZYRS1BQ1dKLVlHT
  E4tWFZCRiIsCiAgICAgICJCYXNlVURGIjogIk1BTkktVk9ITi1RTEVJLVBST0E
  tQlBOQS1CQlQzLVg2TU8iLAogICAgICAiT3ZlcmxheSI6IHsKICAgICAgICAiU
  HJpdmF0ZUtleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICA
  gICAgICAgICJQcml2YXRlIjogImNnaDRKUW4zbDVkdnlkYnRkbG01ZkFsdVZhc
  0pPaWRHUGF1TEhxYzQzVUN5V0dMWGhVcQogIERyUmRuVllzX0NDbEdNcnNBZC1
  QQ1ZLOCJ9fX0sCiAgICAiS2V5U2lnbmF0dXJlIjogewogICAgICAiVURGIjogI
  k1EWEYtM0ZOTS1CWE5JLTUySE0tM0tVSS1HNk8zLUg0WUoiLAogICAgICAiQmF
  zZVVERiI6ICJNRFpXLVNDQVEtSUpFWS1RVVdILUczSE4tUDNTVi1IRkNMIiwKI
  CAgICAgIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjogewo
  gICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0ZSI6I
  CI5MTBSaDNLU0tkXzFwRXAzWDB3QUoyZXpJQjBGVTg4V0p4UzhmZjZIYVJlR1Z
  HZEpyYU0KICBhSU94UEd6QW5aYkFCMGV2OE1SR1JIYmsifX19fX0",
            {
              "signatures": [{
                  "alg": "S512",
                  "kid": "MC6D-EFWK-7CKS-SVK4-ROHV-52XA-KPFE",
                  "signature": "ux8XxqBwy0Aeu55eHaQtw_kbD5FBL3OEsQS0RuGw76WUjr9T1
  -FkA-XtiLNLGPqhPG_o9pmBZEKAqmFqcS83f6c2FqA-Oc3HmjKx-L2b7H6oGeS
  2jhcRafDAEaarmUXgxr6ibd29ZRuX4-KWTRNJ3hYA"}],
              "PayloadDigest": "96G6Cq9QovMAFx3li3wHZU9ODzoIMOyXRWhPzanUbz1ku
  Hl_3EA_yEPXCJCFAutZZu2mbDDh2niK37eMgDvfKw"}]}]},
    "MeshUDF": "MAZM-EQPB-Y6BY-B3W4-6QZS-CJES-QLTR",
    "ProfileMesh": {
      "KeyOfflineSignature": {
        "UDF": "MAZM-EQPB-Y6BY-B3W4-6QZS-CJES-QLTR",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "_lZjJj2d-31wu-nKuaeYJ2RWMJk3zzeZ1z1Al2w5s0EWKYQS3P8N
  sWJXeMWXJGtyzWJ84DHjx5wA"}}},
      "KeysOnlineSignature": [{
          "UDF": "MCAD-O4YS-FOK7-TJSI-UPOT-EX6T-XHS5",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "-oovpc3ItaaP9p2dYs7jqo3Rr0BJya875muPS8qVHsZihYmO8Rt9
  xR00iUb7_Aq1TC1Ws2MxoIoA"}}}],
      "KeyEncryption": {
        "UDF": "MALM-LPA7-36CN-KCYR-TZQT-Y2FF-QNOR",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "bPQcTMpUKMRxYS2jzdF3Sa6hPZqxSNbXXvkGW5Z0Ulfy-1FAtNGi
  RWGDA_cNF4b_WM1Z88FPevKA"}}}}}}
````


# mesh escrow

````
escrow   Create a set of key escrow shares
       <Unspecified>
    /alg   List of algorithm specifiers
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /quorum   <Unspecified>
    /shares   <Unspecified>
````

The `profile escrow` command 


````
Alice> mesh escrow
ERROR - The cryptographic provider does not permit export of the private key parameters
````

Specifying the /json option returns a result of type Result:

````
Alice> mesh escrow /json
{
  "Result": {
    "Success": false,
    "Reason": "The cryptographic provider does not permit export of the private key parameters"}}
````

# mesh export

````
export   Export the specified profile data to the specified file
       <Unspecified>
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile export` command 


````
Alice> mesh export profile.dare
````

Specifying the /json option returns a result of type ResultMachine:

````
Alice> mesh export profile.dare /json
{
  "ResultMachine": {
    "Success": true,
    "CatalogedMachines": []}}
````

# mesh get

````
get   Describe the specified profile
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile get` command 


````
Alice> mesh get
````

Specifying the /json option returns a result of type ResultMachine:

````
Alice> mesh get /json
{
  "ResultMachine": {
    "Success": true,
    "CatalogedMachines": []}}
````




# mesh import

````
import   Import the specified profile data to the specified file
       <Unspecified>
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile import` command 


````
Alice4> mesh import profile.dare
````

Specifying the /json option returns a result of type ResultFile:

````
Alice4> mesh import profile.dare /json
{
  "ResultFile": {
    "Success": true}}
````

# mesh list

````
list   List all profiles on the local machine
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /mudf   Master profile fingerprint
````

The `profile list` command 


````
Alice> mesh list
````

Specifying the /json option returns a result of type ResultMachine:

````
Alice> mesh list /json
{
  "ResultMachine": {
    "Success": true,
    "CatalogedMachines": []}}
````


# mesh recover

````
recover   Recover escrowed profile
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /file   <Unspecified>
    /verify   <Unspecified>
````

The `profile recover` command 


````
Alice> mesh recover $TBS $TBS /verify
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
Alice> mesh recover $TBS $TBS /verify /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

