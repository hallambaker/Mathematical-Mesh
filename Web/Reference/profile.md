

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
Device Profile UDF=MAXU-2AAG-6EJJ-R434-NFW2-JGYW-JSL7
Personal Profile UDF=MA2T-CF6T-DM54-P2UQ-RMYE-SB7W-M3KB
````

Specifying the /json option returns a result of type ResultCreatePersonal:

````
Alice> mesh create /json
{
  "ResultCreatePersonal": {
    "Success": true,
    "DeviceUDF": "MAXU-2AAG-6EJJ-R434-NFW2-JGYW-JSL7",
    "CatalogedDevice": {
      "UDF": "MAXU-2AAG-6EJJ-R434-NFW2-JGYW-JSL7",
      "DeviceUDF": "MBEU-GYQT-4DSJ-P7XX-7YLZ-FLIG-2GAV",
      "EnvelopedProfileDevice": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUJFVS1HWVFULTREU0otUDdYWC03W
  UxaLUZMSUctMkdBViIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogInJtQXBVaXRXaWxqd3FLQVhUUmxXOUd
  TV2hNV2VaOU9IMGFvYmc3bTFnX0xoQXZITDJpZkwKICBvandTcXpDU0tvZDlnZ
  m1hc0Jjb09CdUEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUFPRi1XRzRILUk1RkctUjdMWS1NWTJGLVQ0V0stS0pKQSIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVib
  GljIjogIkp1WFU5eDdQZTJ6ZTNZODFONVA5T2V2NWw1OVJtaDFGLUxYOXA2LU5
  fclk1UlhLZjgwbHMKICA0OExud1owemhxb3lwREEyb1NJcHBwT0EifX19LAogI
  CAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1BVUktRUU
  1Ui1YSVc0LVlMR1EtNlFXUi1SN0tSLUVaTVkiLAogICAgICAiUHVibGljUGFyY
  W1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJLUzVvbEhJQ
  Xp4MHJERnNHSWRCbUJYcVFRUWdFRTUxUU5MVUxYa2VWYnZUUS03TS02dWNzCiA
  gZ2otczkxOVJTbDBMN2JMYWFxMGhrR3dBIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MBEU-GYQT-4DSJ-P7XX-7YLZ-FLIG-2GAV",
              "signature": "BDMsqv3PaomXIJ0daMzRz_iAPEVriQs0GdCxipLtPcS1cI5uA
  7c-jon9qw_1xSqvetEK_h7r-sYAwQBWnRCfG8sCmif-JmSdu02wNsbSMCijFKo
  RC3devcNs1zA_yWpEGtQ2Th5vZJ0Ad9LajVdxQDEA"}],
          "PayloadDigest": "Ike_4l6fqC7UIfPNzKrcVpt-9wMJ_HLDmzUIBFgRMclNu
  8rmlRfAw4xRSfS9ofZAR2AnhbgaYz5NHdaicAFdug"}],
      "EnvelopedConnectionDevice": [{
          "dig": "S512"},
        "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQVhVLTJBQUctNkVKSi1SNDM0LU5GVzItS
  kdZVy1KU0w3IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiOG9LMS1VVWZfR3pzNWY3MDBROU9PckxzUWR
  uRVZDSlJGOE1FN2VqVmxna2lVQ2NTU3ptOQogIDF5YnA4QnM2cDNFenQ5TVF3Y
  nQ4T2UwQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI
  6ICJNQldFLUY1SFMtSUpONC02RktHLVFHR1otNUJXRC1JTjJFIiwKICAgICAgI
  lB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB
  7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAiWFBrSnlVbzhrQjBJUUJiRFA4NWNRZklfY2JfNnluZ1VkZFdLTzVuWHBjSzl
  VcDQxWGpzagogIFE3dDl3LTN4Uk5WWVh5ZmU3XzlYbEtBQSJ9fX0sCiAgICAiS
  2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUE1Vi1MV0tFLVN
  GM1ctSFBDQy1DVUFGLU5JSDMtUFBDViIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImN
  ydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIlRqWTRVYUhwMS1lU
  2duYWYtdDQ1QjB3TzF0QzczWEdZMkVEdnBnLXAyOHo3S2FQZF9BUjEKICBnNS0
  0ZDJCRmpydWVLdWRyZnJXRlJtR0EifX19fX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MCME-YH64-OJRB-JUA7-SYNP-NFU2-JSME",
              "signature": "30CBLEFX0LQ2vb3XoUrNC6RebkHbd6AwIICXchVhi7CcEaAOC
  y_23WWb2t_CqEt2-FXqsFUrb9SAofjK0GjG4lg9RqsczJK4qRWax4Ck20vIZLt
  wzxi2vHKnGdhlJfqTfFSpEPGW4ARbbyfzswPzvS0A"}],
          "PayloadDigest": "IsIbmQc5heAF0jEHKGc4885WFK_UHuhysq0a-ihFeQrel
  f_8hsLBSL2aw3bBsA-RLMm254VGFb9csR35SSkXpg"}],
      "EnvelopedActivationDevice": [{
          "enc": "A256CBC",
          "Salt": "mEFn5xQeWWYawS5XiHTEAg",
          "recipients": [{
              "kid": "MAOF-WG4H-I5FG-R7LY-MY2F-T4WK-KJJA",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "OYMQOCwJ2RW-si4TvcoUmaJR0AOWbRYf3o4N_G5O3LebXstdxRNm
  TJfREiWuRaWzLPdmjdD-3IWA"}},
              "wmk": "6pl5tBa_Bx1w90kJouvZXGHxj9w3E21vfxiAv-WcEUk2XKoTKM-kvw"},
            {
              "kid": "MDX5-I3I3-QBZI-UYKJ-6PXR-LFRF-UUHU",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "eJZiNZ3QUxPGw_zZW161Nt6cXJnQRSmILFVVzV79NoBHFRF-Mk3h
  z3bgHW4F1xiYYcLmHD5zDLuA"}},
              "wmk": "BiIr6uki8BiSPLoCImxl1E_Gem4DlmpJGPsTImG5uA-eOIsaMqR7PA"}],
          "ContentMetaData": "ewogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tIn0"},
        "fENLLTPNtw4TSd0VSksZVkpVUPkZfY5NdAqm_edQmoa
  MBSGM7r5AdoVP5flrdRNYQK4GLVV1oCcFYaljjcpYDo_9lt4xzk2RWPNSeCfzB
  b396jGypSwVzv0N3VeBKN7C4pcg1oHW6qqmFLon3uIJoGTyZAqihMFja80AP-u
  HTYnw7kqbAz_yc2xBZVGB0DbKDPtzYVX_Do3B_Jn4jibSDpfCIhh8EyflJjLac
  -6VdBKU0tM_KtvH4t8aGxGNyjwkyesabpyy8s8ApML8V1Dbi3ELbPqgdPCgH1n
  _EEYtsUshkjTleqAALSUwmrwFNkFKCFGSIxeZyVcP0j4keCElmz-C6mT4dUHqB
  j6ZuiDnkTFHTDAOAuSBOghertMfJ7H0bcScrhAiUicmNcWy7VIyTW9LemRwdH0
  M7kBWGKUk_sobDah6tkweC_L49VNokWwzqVqptcp6I1oEhcqDQ3GlDg6HtxQ5G
  BsjjaNoc1jMlvIaxQTAWL8FKzR4w-KfuaI6X2lw0BfTbem-eNC_6DKG6spkwgY
  NEAAtkWPiKTh_Bw4_qb9WzW4pvS4qCZ1rfxZ_rCzYZp-3YnY8PhCLeE0Ck7t7A
  jfvs4Uyuq8fOdN1b9LGZPe6PBTPYacp7QVrRYHe0Iw9fYGeg1W7lIKsiRpcamv
  id7v0XnZTYN_F63Z1ijx7sMRFeK2Qmc61sbsfT9bbcNAdXyvoVmJMgbSfl-WPD
  5iQY57U-wMy6fXuGWYR4IOKe3-mI1naUa9Utfu_1Ap32uuoaPlseozNnS0FqP9
  OYjCbeAvHhEgYlY_a_utAMrAIkKg7KuqIagzlOtel8MWd-9O4_-F-A6t78Ag-J
  UYFU9b9bw-q6CU62PJfAm-hx4FLxwF7HJnlHUiE22WgKYXyRKOFhFviXSawOlT
  amGzsSTeQYca9VicS-JDnfVj6b9oHMgsPbM5VMDY-GhsOvH0foIe-NzDSfS7HY
  QGIULvIMDPhxdbxzBKczpafp4I5d204Q9hh1Hxn8L-nBsY8c5HV0YVCzt6W0F_
  5ydp3JkphxMhnfhz0IR49zq1QfnogcYEjq1h2yjEoFog3vQYixO2rrTDZrHb1p
  KqFUOWeLOExIh9HwZZhZqNl7zWfUx1wC_s7pJGPDg4HCEZhpdKb08RXAwcs_Eq
  UOSXh5cIT5GaDkdcpgOIpa6y5YorLYbWhFQuQYrzd0gtj0J1eilaxDwRZiXKmD
  74Nu9AwmKuZX6D6SAc4IuffKSgbxdiQRtFkadhx-U33LBWCmFJPr2NrQ_bO"],
      "Accounts": [{
          "AccountUDF": "MCTZ-PNEQ-E63J-YCB3-LXRG-RGUW-LG37",
          "EnvelopedProfileAccount": [{
              "dig": "S512"},
            "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1DVFotUE5FUS1FNjNKLVlDQjMtT
  FhSRy1SR1VXLUxHMzciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICJyUndkVUpzOU4tVFBuc21fdThXcDI
  xcW42REpFWDdXY1lmYUoyRkVyeUpHNGZQaXNOdnFECiAgOEZwMmt5UVlpbTFaa
  S1CbWZGRmcwN3VBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1DVkQtQ1E1SS1aM0xFLTU3U0stTTNXTy1QREFSL
  VhCNUQiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogIkYtSk82YjZLbGJIQ0k3bGZkcXRZMzR
  wQXM0UTVQZFQwYTdHdFlQRm1XT1UtUHJET2FzYk0KICBRdmNqdEtUMkJ0YjlIU
  DV3Q2Mtam1QT0EifX19XSwKICAgICJNZXNoUHJvZmlsZVVERiI6ICJNQTJULUN
  GNlQtRE01NC1QMlVRLVJNWUUtU0I3Vy1NM0tCIiwKICAgICJLZXlFbmNyeXB0a
  W9uIjogewogICAgICAiVURGIjogIk1BM0ctUE9KSi00RlpQLTJNWkwtNVJYSi1
  WRVRFLVQ1UUoiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAo
  gICAgICAgICAgIlB1YmxpYyI6ICJvbERGWTg1SjlheDV3RUI5R2pMZnQ2TWRGS
  lJCbWE0OWNHZWVWbGlpeEdUTkpPSUxNRFRsCiAgZ25DaV8zTWotYm9qQkZQenp
  DUjZsX2NBIn19fX19",
            {
              "signatures": [{
                  "alg": "S512",
                  "kid": "MCTZ-PNEQ-E63J-YCB3-LXRG-RGUW-LG37",
                  "signature": "MvAvSO-naeVrd6elDHavDOdSFPjLl56vwjqaXLRgMnx4xqbuF
  W_-J1EIOxB8wFvqHbkdoEnDLJiAYPQ6UmLS3duCdpPAR5O5OrgihN8x_eXZTON
  Aw3Dhk98t8ATCzYNiA9QXLJ4PEPN0XTqlc9SOuQ8A"}],
              "PayloadDigest": "GPXOdtXI6c6tsR9K22cZLnRiQVxQ9eKRncd-qyoAwivzp
  RIelExzr1e6KNCQyrVAYOECGaJoArSReNbq8h6kdw"}],
          "EnvelopedConnectionAccount": [{
              "dig": "S512"},
            "ewogICJDb25uZWN0aW9uQWNjb3VudCI6IHsKICAgICJTdWJqZWN0VUR
  GIjogIk1BUlUtVVZMVS1IRlNHLU00TE0tWlNBVy03NlRVLVRWWE0iLAogICAgI
  kF1dGhvcml0eVVERiI6ICJNQ1RaLVBORVEtRTYzSi1ZQ0IzLUxYUkctUkdVVy1
  MRzM3IiwKICAgICJLZXlTaWduYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUFSV
  S1VVkxVLUhGU0ctTTRMTS1aU0FXLTc2VFUtVFZYTSIsCiAgICAgICJQdWJsaWN
  QYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgI
  CAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIkJLRmR
  TYnE5VnNHMnZiWGRRYktEWFZLOXptSTZHeF91NnVNbk1QbVdXYUxZTmFTcHJPb
  jAKICBpTDZDQldoeXR0NnRMc0R2RHoyc19ZMkEifX19LAogICAgIktleUF1dGh
  lbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1BS0wtMlBIRS1VTFVELUxQT
  jUtT0JQQS1ZNlFYLVo1WlEiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJXRnljTDl1dzRPb1RKRUZLSkR
  5QU9TRmJjTHpLMER2dE56Vm9xak1YTlVEa3lpT19aTks2CiAgRGZWVzVpWFlpT
  HdBMWhYYTNxYndTUnlBIn19fX19",
            {
              "signatures": [{
                  "alg": "S512",
                  "kid": "MCVD-CQ5I-Z3LE-57SK-M3WO-PDAR-XB5D",
                  "signature": "M1dgfsM_dqc0wGEAZPfp13lojsE8qKCK5zCyzU4MLOz8HQrly
  IXZFt-soCbrBAdTkS37u8rwR-IAyG8Yfo22OxCyUe8o1PixKVBW974q2Qc5fkn
  FnJ_Ym77kmTbdMZwTKkBuqCvECe_52GeQrFHTWi8A"}],
              "PayloadDigest": "hR-jENaVNvvgLI6FLcHVbVDapRH3604TSvEFRwRsbdftk
  CXuckCoUizYyHIeWUD0LepYVqXAFej2fNYINv9zhw"}],
          "EnvelopedActivationAccount": [{
              "dig": "S512"},
            "ewogICJBY3RpdmF0aW9uQWNjb3VudCI6IHsKICAgICJBY2NvdW50VUR
  GIjogIk1DVFotUE5FUS1FNjNKLVlDQjMtTFhSRy1SR1VXLUxHMzciLAogICAgI
  ktleUVuY3J5cHRpb24iOiB7CiAgICAgICJVREYiOiAiTURBRS02UlVaLUhYQ0I
  tNUlXSC1OUk5YLTI1V0QtR0JESSIsCiAgICAgICJCYXNlVURGIjogIk1BT0YtV
  0c0SC1JNUZHLVI3TFktTVkyRi1UNFdLLUtKSkEiLAogICAgICAiT3ZlcmxheSI
  6IHsKICAgICAgICAiUHJpdmF0ZUtleUVDREgiOiB7CiAgICAgICAgICAiY3J2I
  jogIkVkNDQ4IiwKICAgICAgICAgICJQcml2YXRlIjogImw3Z01GWjl2VmlybmN
  KdHlGbXcwWk9ubUp0SEtmM3FPWEhELXd6OFpKNUpVaGMwQ0QxRAogIEt6UzZIe
  GZPckhsdE1WeHhLQndUNS1XVSJ9fX0sCiAgICAiS2V5QXV0aGVudGljYXRpb24
  iOiB7CiAgICAgICJVREYiOiAiTUFLTC0yUEhFLVVMVUQtTFBONS1PQlBBLVk2U
  VgtWjVaUSIsCiAgICAgICJCYXNlVURGIjogIk1BVUktRUU1Ui1YSVc0LVlMR1E
  tNlFXUi1SN0tSLUVaTVkiLAogICAgICAiT3ZlcmxheSI6IHsKICAgICAgICAiU
  HJpdmF0ZUtleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICA
  gICAgICAgICJQcml2YXRlIjogIm5lZEVDTGoxWjNTcmVLY0Noc0h2YjgxdmJwT
  Wlaam9VbXBKNDVOb18yT3pDdzNUWEJJSQogIDh3NER4ZGF1UzhrLVlORHlleVl
  Lc0h3cyJ9fX0sCiAgICAiS2V5U2lnbmF0dXJlIjogewogICAgICAiVURGIjogI
  k1BUlUtVVZMVS1IRlNHLU00TE0tWlNBVy03NlRVLVRWWE0iLAogICAgICAiQmF
  zZVVERiI6ICJNQkVVLUdZUVQtNERTSi1QN1hYLTdZTFotRkxJRy0yR0FWIiwKI
  CAgICAgIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjogewo
  gICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0ZSI6I
  CItay1PU3ZXTS16WTE0UG1vNUZZZ014X3hjMVFKMl9sS0szVGJMandaWVdFeWh
  Nd3VYZ24KICB6Qm9ZMVcxVmJnSnNWZUNnTVNMdDlhRWcifX19fX0",
            {
              "signatures": [{
                  "alg": "S512",
                  "kid": "MCVD-CQ5I-Z3LE-57SK-M3WO-PDAR-XB5D",
                  "signature": "sQ2YuQPNe7M_aLSBPLlBgOb2_eXnHfXVGlxEnuDFIiNUMvipN
  020MKofqvgsAE4HN8s6qVMLNpIAJejfIWrLC6cQ7jbVXtcUxBf4-CA4h_ZT3Mu
  QEn72PAl-kzVadIlDl2kapn_Rc4rW0avOc0EaXAwA"}],
              "PayloadDigest": "O9Cotww4N5BuP9H8M-0BORNUizVthZhvux-xwLHo9Kcqo
  7WRpTks3OYTIhiKG10H2BJ1rUgfIH01DILUh1Q5ww"}]}]},
    "MeshUDF": "MA2T-CF6T-DM54-P2UQ-RMYE-SB7W-M3KB",
    "ProfileMesh": {
      "KeyOfflineSignature": {
        "UDF": "MA2T-CF6T-DM54-P2UQ-RMYE-SB7W-M3KB",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "Bodr-blPuWcvYNL8qY9EVPj68-EDzgAWfoAKzn7W_3Jie-j38ISs
  clq_LubgjyUP-dOmqHAZNJ4A"}}},
      "KeysOnlineSignature": [{
          "UDF": "MCME-YH64-OJRB-JUA7-SYNP-NFU2-JSME",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "kZkRTxMOpiVPEnPUzK5jZqDmftpdKbYKtyorSEHGZ8WKl3sVFW4V
  b_iAdvaNxp5X971ju_Jr6jwA"}}}],
      "KeyEncryption": {
        "UDF": "MDX5-I3I3-QBZI-UYKJ-6PXR-LFRF-UUHU",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "xnp8TtYePWMv5rS57OqA00h11k-fx3tfi-KXsGS2zkxhTi5ReQkM
  SVhvLoRrvkaWsRn-0fdGsLSA"}}}}}}
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

