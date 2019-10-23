

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
Device Profile UDF=MAGM-3MHR-ATTA-EKIR-2AED-4FKB-RFO5
Personal Profile UDF=MDMD-6XEI-KFBS-OOCE-UJ4X-PM5J-YUC4
````

Specifying the /json option returns a result of type ResultCreatePersonal:

````
Alice> mesh create /json
{
  "ResultCreatePersonal": {
    "Success": true,
    "DeviceUDF": "MAGM-3MHR-ATTA-EKIR-2AED-4FKB-RFO5",
    "CatalogedDevice": {
      "UDF": "MAGM-3MHR-ATTA-EKIR-2AED-4FKB-RFO5",
      "DeviceUDF": "MCVY-6TCQ-V4NM-VDMH-SO3E-2XHU-CAKZ",
      "EnvelopedProfileDevice": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUNWWS02VENRLVY0Tk0tVkRNSC1TT
  zNFLTJYSFUtQ0FLWiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogIlFPZ3dkc3J3bnRyaVNvd3BsdmdhOGs
  zbXA0UE1PaFE5aVNQbTFtOXFXRTdRYjkzRDhyZkwKICBkX216VlpYNXRtUXpTU
  jhQWkhkdkd5SUEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUNWVy1DQkU3LUpPWEMtQjVWVy0yQ0NMLVk0NkgtUENHWSIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVib
  GljIjogInpXci1NZWlQTlV5UTJmejF0WE5DVTh4elhZMXdHNzlVSDB1RnhESlZ
  NTnBEYklLTFg0cEMKICBUUGVJR0JiSHA3a09KU3p2MGt1N280MEEifX19LAogI
  CAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1BWUgtU1p
  HRi1CRU5FLTczNFUtUFBEUS02N1Y2LVRZREgiLAogICAgICAiUHVibGljUGFyY
  W1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJvN1VDRmgyR
  UVVWklwYTIzT005VG12Q3psY1hOdExOOG4zVGVXaEUtWWFKMENMNDRZWjlwCiA
  gV1JhSnFiV3dhWDZPaGctajlPc3NuNW9BIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MCVY-6TCQ-V4NM-VDMH-SO3E-2XHU-CAKZ",
              "signature": "EKOyVzqfcjf6djGyo9Mbblm_QgJwXE9ePUaogXFM54CeGjA15
  6aVIa0XV4c9NBpvwjLsTuYzuv8AZHFnXWUB8Z2w4z0yzhfnlfQcRa9gVTQqkdg
  QH37oKSjAJzHonEWy18z1f0iTGLUoY9LxOareijwA"}],
          "PayloadDigest": "hgdzSKmXA6PlKzJ2fdwDZBYp8UKZZBna1bc0URbh-1EvY
  ILWl6SoXX8OfBTLb1SHmSNz1yXv4iVb1PN6lphRvQ"}],
      "EnvelopedConnectionDevice": [{
          "dig": "S512"},
        "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQUdNLTNNSFItQVRUQS1FS0lSLTJBRUQtN
  EZLQi1SRk81IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiQ2tlZk5CV2tqS0g2Mm5NLVlLcUwwTUx2OFR
  JVGZ2NDVfME4wMnJEWEtrRlMzRnItZ3E1RAogIC1zRHdpdlBiV25wZ25rQ1c3d
  1V4dTBtQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI
  6ICJNQ0tDLU9LVFktNUQ2Mi1RM0FOLU1OQU4tUFdHVy1ETlNRIiwKICAgICAgI
  lB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB
  7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAiWmtBZERtdmFBeGdaMnNpM2FUTVpCNUh6cVJLRllkai0xNW1SU01NT0s2eXk
  yQVBRbXRJRwogIDVVcG55bkZneWQ0LVpKalV2b0YyeWJrQSJ9fX0sCiAgICAiS
  2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUNQTi1ORUVBLVp
  PQ0YtMkpSTi1ZM0NKLTRVUVEtSkdKNSIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImN
  ydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIlBGaHRkUUstSklnZ
  1JMZHlsX0cxQmVqUThSRWtkMWx6TTRnbk9VeVBDc0hQX0l0TTV4LUQKICA1Ynh
  JMTRJTVFCbG05ZjhhX3kwNnBoTUEifX19fX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MDZS-5M7B-FB2N-PUWW-WUSZ-2TFF-VN6L",
              "signature": "v2Gs_b_dqUGzQ4uKgYviluxHHvY81ertawhL3ROwY3EFEPYVC
  E1knUIt-YE5jpiu72Gtxv0eswmAjgcxk4Ygh5iun6-WiwsOEIor0tSpDVok5rH
  -sA78mp7b__OgYTZtVsRym5XIpFFmQf1ZMZjhQCUA"}],
          "PayloadDigest": "dFPZFhLFWsm29OvzXg38uhMzjRfgr7wGr6L486mcUalxV
  7peV4Spr6fk7-deGNbHt3TVzujakEkgBrXtSM0Lmg"}],
      "EnvelopedActivationDevice": [{
          "enc": "none",
          "Salt": "BadVMJeLaxNwanDBtlYjkA",
          "recipients": [{
              "kid": "MCVW-CBE7-JOXC-B5VW-2CCL-Y46H-PCGY",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "K6vAd1oM7Ie7isaId_WWOAufttoUGZe6ZU9wrJkLeEmNc4hbKr2s
  m9ChHMPUO3exjHdFWHnankCA"}},
              "wmk": "pqampqampqY"},
            {
              "kid": "MCBO-MNRT-QFAQ-AXUN-YWI4-JWDC-GT4B",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "sR-GChlVUnNx53ang5yvIsEu__h7cuYb_c9uxEN5wk_JO8RtIb2r
  z5wnytI4qTsVc3IK9hg5VKqA"}},
              "wmk": "pqampqampqY"}],
          "ContentMetaData": "ewogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tIn0"},
        "ewogICJBY3RpdmF0aW9uRGV2aWNlIjogewogICAgIkt
  leVNpZ25hdHVyZSI6IHsKICAgICAgIlVERiI6ICJNQUdNLTNNSFItQVRUQS1FS
  0lSLTJBRUQtNEZLQi1SRk81IiwKICAgICAgIkJhc2VVREYiOiAiTUNWWS02VEN
  RLVY0Tk0tVkRNSC1TTzNFLTJYSFUtQ0FLWiIsCiAgICAgICJPdmVybGF5Ijoge
  wogICAgICAgICJQcml2YXRlS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiA
  iRWQ0NDgiLAogICAgICAgICAgIlByaXZhdGUiOiAiRHFGSTNlQ0psZVo3anZuX
  zZiRF9ZYXl5aUZobVU1VkZWV291N21zLW5LWnV3TEJDWFFWCiAgU0RWcFkzNGl
  ELXBRM3pEM0FNZjZTWEdZIn19fSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogI
  CAgICAiVURGIjogIk1DS0MtT0tUWS01RDYyLVEzQU4tTU5BTi1QV0dXLUROU1E
  iLAogICAgICAiQmFzZVVERiI6ICJNQ1ZXLUNCRTctSk9YQy1CNVZXLTJDQ0wtW
  TQ2SC1QQ0dZIiwKICAgICAgIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGV
  LZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHJpdmF0ZSI6ICJWUVF2LW5QWnVuRFRxOExCVkNXOHZ4MzFWV05vQ1pxU2d
  rQUZ4LVlzckF3RjJOUGxodGYKICBuNWNXM0owaVVNaHVaQTZxZWNHbXQzZkEif
  X19LAogICAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1
  DUE4tTkVFQS1aT0NGLTJKUk4tWTNDSi00VVFRLUpHSjUiLAogICAgICAiQmFzZ
  VVERiI6ICJNQVlILVNaR0YtQkVORS03MzRVLVBQRFEtNjdWNi1UWURIIiwKICA
  gICAgIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjogewogI
  CAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0ZSI6ICJ
  fd3lvMFd5dE0zT2dNZnd1SGFoeF9ETVdZdlIxam90dkkzR1BFc1k1TURMTGo2e
  ERoeVkKICBnTnZMemI0SnJFUmJYQlJpVmxXVjRQQU0ifX19fX0"],
      "Accounts": [{
          "AccountUDF": "MBHZ-ZV5X-LVQZ-G5QC-MH2E-H767-75JA",
          "EnvelopedProfileAccount": [{
              "dig": "S512"},
            "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1CSFotWlY1WC1MVlFaLUc1UUMtT
  UgyRS1INzY3LTc1SkEiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICJDTzh3TlM1enY4bEJRUmJCWGxveng
  0SVRLT25CMjJCa2xGcU9Bak5qTHlvNTdpSnh6a2dTCiAgTlE1amRhamZ6dC01U
  zJ4RVNXeEN4bWNBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1DRlItS0pRUS0zTExZLUlPRVQtTkpOUC1RV1lZL
  UtIUzQiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogIkwwWUdFekg2QU5iVjVWRkJ2SndmT2Z
  xa3h5bldoc09NdUs0MEUxSVZ1cXRFWnBid2tkbGsKICA2MkxKZlhReXpjN3NyQ
  zljajFNcUl1T0EifX19XSwKICAgICJNZXNoUHJvZmlsZVVERiI6ICJNRE1ELTZ
  YRUktS0ZCUy1PT0NFLVVKNFgtUE01Si1ZVUM0IiwKICAgICJLZXlFbmNyeXB0a
  W9uIjogewogICAgICAiVURGIjogIk1BQkMtSFRCSi1JMlhYLTJFTlctM0xTSC1
  BWTZKLTVGREoiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAo
  gICAgICAgICAgIlB1YmxpYyI6ICJmRE8wQzVfT21vZ09lNERvclVZdC1Tc05fc
  EVGMGFBbmNBOVJSUDdoNlpveGNNQS1IVm5xCiAgTV9SUkEtZHhxMlZkZ3VHYjM
  1Y1FpZ0NBIn19fX19",
            {
              "signatures": [{
                  "alg": "S512",
                  "kid": "MBHZ-ZV5X-LVQZ-G5QC-MH2E-H767-75JA",
                  "signature": "b7gQVJa-w00W8FoipQWLtcefjcwLTO8bJ7UBFhSlya3jYkPZn
  uF5IAyvkVYJ6FzOT171cEzJQwGAvofILhBuxgSL1fXn5EiE8uyEJaO_voCdFUP
  t4fIHJJBSVD8w4ALZ7Xp5PLdhU8wRUVLBFc07ChIA"}],
              "PayloadDigest": "EEcJuQYyJKKlvMfHeKJxmF1-cbju8eLYDGKHL3PRI30ke
  0EvLMYJ8bBL5czXk79_xkewzaJ4RkRI3QewZAwe5w"}],
          "EnvelopedConnectionAccount": [{
              "dig": "S512"},
            "ewogICJDb25uZWN0aW9uQWNjb3VudCI6IHsKICAgICJTdWJqZWN0VUR
  GIjogIk1DVUktSk1BMi1CNk5SLUdTUzYtWlNJUS1OSEE1LUdSSU4iLAogICAgI
  kF1dGhvcml0eVVERiI6ICJNQkhaLVpWNVgtTFZRWi1HNVFDLU1IMkUtSDc2Ny0
  3NUpBIiwKICAgICJLZXlTaWduYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUNVS
  S1KTUEyLUI2TlItR1NTNi1aU0lRLU5IQTUtR1JJTiIsCiAgICAgICJQdWJsaWN
  QYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgI
  CAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIkJqdkk
  0Vzc3XzlrVjhkWElwb1lsNHpoVTJ1LS1IWnhqM3JheHRManZqQ0NsNU5QMnNDQ
  TgKICB5eWRDU2E1b0hXZWFKaEh4bWtEWXBxWUEifX19LAogICAgIktleUF1dGh
  lbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1BRE8tTkZXVS1JR1pYLUZGS
  VEtVUxHSC1VMzNDLUlRM1AiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJGUDFneXFtRWI4dDBqQ0JqeF9
  hdkdBd2xCaWplN2pBSnFkejBNRXRJb0hBTXhTOExnTHZCCiAgMFdiSkFOSXlGa
  WJ1MkFTVDhFZjdnQWNBIn19fX19",
            {
              "signatures": [{
                  "alg": "S512",
                  "kid": "MCFR-KJQQ-3LLY-IOET-NJNP-QWYY-KHS4",
                  "signature": "31oFJnTpmybxo2tQnYdqFLVYIuweItbCeZYsAAcWxjSiynMOS
  YmyKmi2ObmXR-gFHwWR5vaLfZcAab3lSvmO9Er2qMkAsnNQIAVGnFmA6NODt-e
  xpQBKR7w-eHPup-8WjzvYX0_3Sv6Wv_YoObD5EBQA"}],
              "PayloadDigest": "dg54PkJtE3IODloUjqnxuo4_f_UCMWWMaeN2AtCbVoWfB
  CAr1RsLtHZMzDoDWLaVeupmc7tu75O63WxfEwXinQ"}],
          "EnvelopedActivationAccount": [{
              "dig": "S512"},
            "ewogICJBY3RpdmF0aW9uQWNjb3VudCI6IHsKICAgICJBY2NvdW50VUR
  GIjogIk1CSFotWlY1WC1MVlFaLUc1UUMtTUgyRS1INzY3LTc1SkEiLAogICAgI
  ktleUVuY3J5cHRpb24iOiB7CiAgICAgICJVREYiOiAiTUJQNy02VlFPLUhORUI
  tMzNVRi1ZQzRQLU1RUk4tVVJVSiIsCiAgICAgICJCYXNlVURGIjogIk1DVlctQ
  0JFNy1KT1hDLUI1VlctMkNDTC1ZNDZILVBDR1kiLAogICAgICAiT3ZlcmxheSI
  6IHsKICAgICAgICAiUHJpdmF0ZUtleUVDREgiOiB7CiAgICAgICAgICAiY3J2I
  jogIkVkNDQ4IiwKICAgICAgICAgICJQcml2YXRlIjogInVIMnloMHhsVVBtOXZ
  SVmlvM0R4Q0hoVGNhUXpuYjQwS1FSay00UF96UmJDaHFOQ2VneAogIFVOUWhTY
  0dMUUExOHVCYXFnc2U1SFFuTSJ9fX0sCiAgICAiS2V5QXV0aGVudGljYXRpb24
  iOiB7CiAgICAgICJVREYiOiAiTUFETy1ORldVLUlHWlgtRkZJUS1VTEdILVUzM
  0MtSVEzUCIsCiAgICAgICJCYXNlVURGIjogIk1BWUgtU1pHRi1CRU5FLTczNFU
  tUFBEUS02N1Y2LVRZREgiLAogICAgICAiT3ZlcmxheSI6IHsKICAgICAgICAiU
  HJpdmF0ZUtleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICA
  gICAgICAgICJQcml2YXRlIjogImNmcTJOdnUtN29zT2FEY0RBc2trVHJtWVRDU
  mFUVU5DN1pqX0l3TXE2a3BINlhWbHNOaAogIG1JOG1rNzItOUNCSmZKVHlmTi1
  ub2F1ZyJ9fX0sCiAgICAiS2V5U2lnbmF0dXJlIjogewogICAgICAiVURGIjogI
  k1DVUktSk1BMi1CNk5SLUdTUzYtWlNJUS1OSEE1LUdSSU4iLAogICAgICAiQmF
  zZVVERiI6ICJNQ1ZZLTZUQ1EtVjROTS1WRE1ILVNPM0UtMlhIVS1DQUtaIiwKI
  CAgICAgIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjogewo
  gICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0ZSI6I
  CIycnpoYUg1dXQxelJaajBNQkg3VUQtSDEyYzZ1aXAxdk40X3Qxdy1nMUNiOEp
  6V2d0dEsKICBVSDdIb1RJVTRnSHJydVdXTmdIQXhwM2cifX19fX0",
            {
              "signatures": [{
                  "alg": "S512",
                  "kid": "MCFR-KJQQ-3LLY-IOET-NJNP-QWYY-KHS4",
                  "signature": "m_xiISUI4Vnd1-e69drHC8K4LplQknTIQbshtMtxxZl8rnVmy
  C78CjJjzqLGPE0Y7-4htAmwvdoAZTWOMJIn4V9C2HApQXUxS1t_D1piPimDlXq
  TMMzNyBv09ItCPYqTM2NPeyPiENhO_TcliAoI6wAA"}],
              "PayloadDigest": "1MXx92jcGCfrBHVdg4KeVFIwBJcCA4AxY8av8cfXKhQ9T
  JSZTM3Y8xxghgo6O8Bwjubo7zMndSo0fdhxQ5PFrg"}]}]},
    "MeshUDF": "MDMD-6XEI-KFBS-OOCE-UJ4X-PM5J-YUC4",
    "ProfileMesh": {
      "KeyOfflineSignature": {
        "UDF": "MDMD-6XEI-KFBS-OOCE-UJ4X-PM5J-YUC4",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "F3Bg_oRG1t91V0pMhjWE8Y1yUg1fuYPmh_A_7ztq21tFBCGLYIxn
  yW2aW7gstlzX9u9qiQjRl3WA"}}},
      "KeysOnlineSignature": [{
          "UDF": "MDZS-5M7B-FB2N-PUWW-WUSZ-2TFF-VN6L",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "sZx3nK_E2pDXR141AKwBX78su26XLKDHQnqqAOB4L3BxmZQUgJt2
  49HNdSh99kSsDlHUu42HFy8A"}}}],
      "KeyEncryption": {
        "UDF": "MCBO-MNRT-QFAQ-AXUN-YWI4-JWDC-GT4B",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "LvOXqXo3PnJ77UX0ro-cmfkqgt7ue71TwondXgrmNglH0G7tn09R
  BBbk5li7UdqpSy_29Jx1_NMA"}}}}}}
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

