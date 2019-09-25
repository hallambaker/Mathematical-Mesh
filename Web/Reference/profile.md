

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
Device Profile UDF=MA2C-HETK-HOFV-UTKE-LPDJ-TA73-OO2Q
Personal Profile UDF=MAMM-XWMN-ZTWV-F32Q-LCDS-7TDM-VH2Y
````

Specifying the /json option returns a result of type ResultCreatePersonal:

````
Alice> mesh create /json
{
  "ResultCreatePersonal": {
    "Success": true,
    "DeviceUDF": "MA2C-HETK-HOFV-UTKE-LPDJ-TA73-OO2Q",
    "CatalogedDevice": {
      "UDF": "MA2C-HETK-HOFV-UTKE-LPDJ-TA73-OO2Q",
      "DeviceUDF": "MCGA-7GHZ-SXUZ-6355-KAMH-4PI3-JCET",
      "EnvelopedProfileDevice": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUNHQS03R0haLVNYVVotNjM1NS1LQ
  U1ILTRQSTMtSkNFVCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogImR5dUQtTk1NRTAyNGZRcElaSXZjaDZ
  oQXZLVnpTaFdoYU9Oall1Rm9JVk5nbnlEYldUbTEKICBEN2NkRm1iRm5pWE1EM
  HFoamlHTjJ1OEEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUNVNS1STkVULUNaS0MtUFNJRi03UENULTI3TVYtWTJMUiIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVib
  GljIjogIjN3eEQ1UU5ZRGROWE1aOHo3Sm03OGI2MWNFRlF4QUs4Q3ZzWWtfZGx
  rQ2d6Mkk0UE04RloKICBHUU94S3NMbWhKTXBqalFPNlZCTk1aV0EifX19LAogI
  CAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1CWkItUkR
  RVi1IR0tJLUpSN0YtSUtWWi1BMkZILU5WQlEiLAogICAgICAiUHVibGljUGFyY
  W1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ4dUN3R2MyW
  kRmazRtekpIZVJTaU8yMnpXRHl1TTBiUlVueHdSMW1sNmhCTHI3OGNsYlo4CiA
  gb2kyZ2dnSUgtNjdJdzg5bGNqT01QUTBBIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MCGA-7GHZ-SXUZ-6355-KAMH-4PI3-JCET",
              "signature": "wmg-MyR1-rvFND1umr75QepRS4Y_2ZB8fCyIUyYS4N-aeNQhX
  GKQLYjasovztHlNTjeNAwy8Q-AAsMpFhba__0YFlgpXM76sMob1V9Y696jvW5j
  N7dW8jQ7e9R_lSgeBDIxjDGViQV_eW37PIOnoTh8A"}],
          "PayloadDigest": "H8jBC05ZiEJ_X3l4FezEqUIlTlgifyrIPAJ5ScpUMNRl7
  2yt-LUT4D4dikcJlMttIkKXwTOGBPecote3YgXjpw"}],
      "EnvelopedConnectionDevice": [{
          "dig": "S512"},
        "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQTJDLUhFVEstSE9GVi1VVEtFLUxQREotV
  EE3My1PTzJRIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiaVQwWFlNVS0xTnBnbnNkbFNnYzhHSWw4eDB
  WY3VHTkQtTXMtV0FYRkVNQVpZbFBaWnZNVAogIGNVZUZCNlEwYXlEeDdYQmJjR
  1JmVUdvQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI
  6ICJNQzNDLVNJTDQtR1lFMi1TVTVHLUFSTzctSE9HUy1GS1U1IiwKICAgICAgI
  lB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB
  7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAibkQtVDYyUGNBNkx6b0hoTnVfX3MxZEkya2hLVmtjVkpPQkdnM3hpdnpEcXp
  6QU1hd0syRgogIFpwODV0R1RfN1RxeDRGd1BCaWRuTDAyQSJ9fX0sCiAgICAiS
  2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUFOUi1DVzJELUM
  0VkgtNjZCTS1EVldLLUNYUUktTE5CVSIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImN
  ydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogInBuWWVPSlR5MldIM
  WhkeV9QOVZZVFM1OFFGM2pTVVBqMFNOTmtXcnBFSFBaUVhnT3FMSmkKICA2TS0
  yY0tueEdBWlNrMGJKcm04T1BRS0EifX19fX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MCWC-ODYG-EWXX-6CLE-ZJIC-FZJM-MD6Q",
              "signature": "N9hktw9_NzK754PPxg-wUUQ5Zjlebmv-7XcMlBpvGSioUAUh1
  P3kPv2xe00xzU3p2XzPv5vC6rMAwOvajxj0LdFeXNuK_lhCcJ2B1jKUVnA63i7
  ba2-oCpM6yADODRYrcumwZF-q3WtHeJxcpovK1AoA"}],
          "PayloadDigest": "a9cVmN0UMezzK5kHBXnro1D5STcz7G55HOSAcZfYACI_Q
  Rh-fRZJezNI8a0bgaPrthblaeXDCsapWl0nQfNt_Q"}],
      "EnvelopedActivationDevice": [{
          "enc": "none",
          "Salt": "o_ZagJ_OwomNePSDKuXCFA",
          "recipients": [{
              "kid": "MCU5-RNET-CZKC-PSIF-7PCT-27MV-Y2LR",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "AJawEm31f1OiDW0lEDwHZt0LD3kyTB0uL3g9RvEsrGBUh0As7hGv
  E2W7cTY1IqhKgk8PEn3bV3WA"}},
              "wmk": "pqampqampqY"},
            {
              "kid": "MBFT-ZR5F-BRQC-HJPO-OA5P-W3AN-CWCK",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "PqGVTyfbIJtAXXgelZ9Y71hGEuwXInxTRrQkcg5agJUBdMycc_hP
  X788i8KkDClcvVUPqOsLOTKA"}},
              "wmk": "pqampqampqY"}],
          "ContentMetaData": "ewogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tIn0"},
        "ewogICJBY3RpdmF0aW9uRGV2aWNlIjogewogICAgIkt
  leVNpZ25hdHVyZSI6IHsKICAgICAgIlVERiI6ICJNQTJDLUhFVEstSE9GVi1VV
  EtFLUxQREotVEE3My1PTzJRIiwKICAgICAgIkJhc2VVREYiOiAiTUNHQS03R0h
  aLVNYVVotNjM1NS1LQU1ILTRQSTMtSkNFVCIsCiAgICAgICJPdmVybGF5Ijoge
  wogICAgICAgICJQcml2YXRlS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiA
  iRWQ0NDgiLAogICAgICAgICAgIlByaXZhdGUiOiAiMFpfX3c0dklGOGZBYVNtX
  0dvSGRpNWhadnlDb25YMlA4bTFwc3RTUHBGaFpPYndiYmRlCiAgRTczMXp5NTE
  wN1FSWHByMnZZYTdCemtBIn19fSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogI
  CAgICAiVURGIjogIk1DM0MtU0lMNC1HWUUyLVNVNUctQVJPNy1IT0dTLUZLVTU
  iLAogICAgICAiQmFzZVVERiI6ICJNQ1U1LVJORVQtQ1pLQy1QU0lGLTdQQ1QtM
  jdNVi1ZMkxSIiwKICAgICAgIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGV
  LZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHJpdmF0ZSI6ICJCUVJEc0daaHE4NnM5YjZEbk94cDdzNkZMdVNfeU1CNHZ
  yYU9UUjhkR2pTTEdZeS1fSnQKICBKMU90UUR5YzR2MGthR21aQk9VSmI1b2Mif
  X19LAogICAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1
  BTlItQ1cyRC1DNFZILTY2Qk0tRFZXSy1DWFFJLUxOQlUiLAogICAgICAiQmFzZ
  VVERiI6ICJNQlpCLVJEUVYtSEdLSS1KUjdGLUlLVlotQTJGSC1OVkJRIiwKICA
  gICAgIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjogewogI
  CAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0ZSI6ICI
  4aFRKZnViWlZDbWNocFN2YjJYbVJ1WU5rMk5QQ2hxQTVmQWtBYW1GaWJXM2ctc
  Xg0emYKICB0eGFhQWc5WlRHeDlZVzVGZ1JTX0trRUkifX19fX0"],
      "Accounts": [{
          "AccountUDF": "MDUI-WXFA-FDNM-7524-G6MK-6EGS-CBX2",
          "EnvelopedProfileAccount": [{
              "dig": "S512"},
            "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1EVUktV1hGQS1GRE5NLTc1MjQtR
  zZNSy02RUdTLUNCWDIiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICJMcjY0a1F2bDlJZXpxbTAtNG1aT1Z
  Gank4OFZ5MWhTdUNpRWpPaEptdjExTkJJX0xZY2lICiAgTlc2LWhPY1RFTEdMU
  kp6MnNIYkw5REdBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1BRVgtTTNUNS00UU1YLVZFSTQtRU9EVy1RMjJNL
  UtTT1UiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogIjl6SXVwMHRkZWF3TjZaQjUyanRVbHZ
  CcWtXZS11S0FmTWpDLU5fVlFqNEJuYkhIamxtcXQKICA3TkZZWkhZS0tvbDZMb
  Hp1RkU1MVJmTUEifX19XSwKICAgICJNZXNoUHJvZmlsZVVERiI6ICJNQU1NLVh
  XTU4tWlRXVi1GMzJRLUxDRFMtN1RETS1WSDJZIiwKICAgICJLZXlFbmNyeXB0a
  W9uIjogewogICAgICAiVURGIjogIk1CWjItRVlDTC00N0VYLVhPVEstSVBBVi0
  ySTNRLVc3QlciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAo
  gICAgICAgICAgIlB1YmxpYyI6ICJtcUFXc0tyZGttSGJ5emQxWGQ1T1NBM0o5R
  EsxdUxEcUdHaGQxYUp3ZHg5TmpkTzhmNmR0CiAgT0N3bE5wVzh2MUZHQzVWZVZ
  nMXdfU0lBIn19fX19",
            {
              "signatures": [{
                  "alg": "S512",
                  "kid": "MDUI-WXFA-FDNM-7524-G6MK-6EGS-CBX2",
                  "signature": "KzfsYuJ83Mdp8apghUFR7dsFp-OQGhW4bhf_w-js-8ORMxJQl
  3HDGzXOT5oRumoDQtu9bAYEKbaAfJ4En3f4uTZT-bk_-Sgv5Ty0_z-fys557te
  A_9lU9FInoyFPmmKajaQivOYXcd2w17CaRs8dmjwA"}],
              "PayloadDigest": "D8Z2oWrt8sTFJZv6ZfqRbIPJb3v-_vi7ohkFlY-Wfq5AG
  -RxkZR7VMEwMwEL6J1_BuvbzBTMnSV_hY6F1ZQLnQ"}],
          "EnvelopedConnectionAccount": [{
              "dig": "S512"},
            "ewogICJDb25uZWN0aW9uQWNjb3VudCI6IHsKICAgICJTdWJqZWN0VUR
  GIjogIk1ESEMtM05JVS1YVk9LLUM3V1AtSEVOTi1LTTVMLU9NNFAiLAogICAgI
  kF1dGhvcml0eVVERiI6ICJNRFVJLVdYRkEtRkROTS03NTI0LUc2TUstNkVHUy1
  DQlgyIiwKICAgICJLZXlTaWduYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTURIQ
  y0zTklVLVhWT0stQzdXUC1IRU5OLUtNNUwtT000UCIsCiAgICAgICJQdWJsaWN
  QYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgI
  CAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogInVXTmZ
  0ZlU0QTZJaEIzaFJMQXVoVC10cFp2MmRZZWJDVkdjcXN0VFU0TWZYTFd0YmNvd
  W0KICBSS0ZWU2wwNEdSU0V6SkdPWWxVVFpLb0EifX19LAogICAgIktleUF1dGh
  lbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1CUUEtMk9HVC01UklYLVNNM
  kwtTUNUSC1ZRU9ELUEyUFgiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJEZFVaZS00LVhDbk1Ob1VHTWp
  ZYXlfR3FvUU1GeHN2emxFaHlQY3ZaQTh1am50eVVWc0JmCiAgOUdTc2NIdUUyN
  DhBU2htRHh6dWpyak9BIn19fX19",
            {
              "signatures": [{
                  "alg": "S512",
                  "kid": "MAEX-M3T5-4QMX-VEI4-EODW-Q22M-KSOU",
                  "signature": "J5CW6ucixqOZpncH6_vSh0Bu3-4cNDF4N19ghriKZAoXZJHLN
  RSJWZLFeJSD6SECS5c6PxAzhpUAt7o9PjbTXZmcuLiry27bV2y6juoVejfPCAO
  W4FKAFD3II-pBwMvRS6iLXonlmCMimaIQseJXUDwA"}],
              "PayloadDigest": "T0irzicmXSwATarzKQVD7KYu8JSrQbbsSDv9OVvl1ylRM
  yOWpfg_7v9NWlQnOPr-mFTfMVT_4eDC31psiHUpIg"}],
          "EnvelopedActivationAccount": [{
              "dig": "S512"},
            "ewogICJBY3RpdmF0aW9uQWNjb3VudCI6IHsKICAgICJBY2NvdW50VUR
  GIjogIk1EVUktV1hGQS1GRE5NLTc1MjQtRzZNSy02RUdTLUNCWDIiLAogICAgI
  ktleUVuY3J5cHRpb24iOiB7CiAgICAgICJVREYiOiAiTUFaTS02WDVOLUZMNlc
  tT0xWQi1VM0dFLTJWUTMtT1dYWSIsCiAgICAgICJCYXNlVURGIjogIk1DVTUtU
  k5FVC1DWktDLVBTSUYtN1BDVC0yN01WLVkyTFIiLAogICAgICAiT3ZlcmxheSI
  6IHsKICAgICAgICAiUHJpdmF0ZUtleUVDREgiOiB7CiAgICAgICAgICAiY3J2I
  jogIkVkNDQ4IiwKICAgICAgICAgICJQcml2YXRlIjogIjA2NXdSMXljeV9iZ2Z
  XRjRvM3hFcTFNOGZOZEM1V0F6MU43d2tmT3VYbGQwa19OWjRJMAogIFczUkljO
  UR5VUJpNVRWNlZWR3RFU1Y0WSJ9fX0sCiAgICAiS2V5QXV0aGVudGljYXRpb24
  iOiB7CiAgICAgICJVREYiOiAiTUJRQS0yT0dULTVSSVgtU00yTC1NQ1RILVlFT
  0QtQTJQWCIsCiAgICAgICJCYXNlVURGIjogIk1CWkItUkRRVi1IR0tJLUpSN0Y
  tSUtWWi1BMkZILU5WQlEiLAogICAgICAiT3ZlcmxheSI6IHsKICAgICAgICAiU
  HJpdmF0ZUtleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICA
  gICAgICAgICJQcml2YXRlIjogIlZFSVhnNlc1aHlINnFlVE5LcU1hX2RsYmsyR
  m5CVDZxWVhpWl9PNWJGV0JjeVotNkZPdAogIDFWd2dBT2VWdHI2ajI4S3VGUHN
  3WGkySSJ9fX0sCiAgICAiS2V5U2lnbmF0dXJlIjogewogICAgICAiVURGIjogI
  k1ESEMtM05JVS1YVk9LLUM3V1AtSEVOTi1LTTVMLU9NNFAiLAogICAgICAiQmF
  zZVVERiI6ICJNQ0dBLTdHSFotU1hVWi02MzU1LUtBTUgtNFBJMy1KQ0VUIiwKI
  CAgICAgIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjogewo
  gICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0ZSI6I
  CItQ2JlSFZ2UXBTMkZ5Zl9BMWhibzdXMXljRl9BcjhqZjVmYXF0eTRmd2lUaFB
  qMmIyY3MKICB1QXhQdklVWEhDZEh6QUZ0cXhFZ1p0eTgifX19fX0",
            {
              "signatures": [{
                  "alg": "S512",
                  "kid": "MAEX-M3T5-4QMX-VEI4-EODW-Q22M-KSOU",
                  "signature": "XGSRqHOsutMvzPJ_ZiadO6KrLcbrOoZd42Y0t5wkJ2mTUeZJn
  Pek5Th-G00mQcSug8CX0EGUT9wAuBDIgZZLU9L0fmkp3AIoj_oygi8BDqlPYIA
  ecS9nqof125JCYkkUAx03BgfhJd8WW0_NAWQR5x4A"}],
              "PayloadDigest": "4T_xuSd3cUmcAamY_zcJZJ_LNO14bpvqnChutoT6oQkmp
  m-5v3YZ_VL3ad5-t0kB1NfOBV36gyhxYPlFvtqRhQ"}]}]},
    "MeshUDF": "MAMM-XWMN-ZTWV-F32Q-LCDS-7TDM-VH2Y",
    "ProfileMesh": {
      "KeyOfflineSignature": {
        "UDF": "MAMM-XWMN-ZTWV-F32Q-LCDS-7TDM-VH2Y",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "zFsk3Ox3fjBQqok4KgVi3cpwMaZqKoRPTH5xLgXN6KiZHyaRqVOS
  m4O3x21ph5zCzGY2A5y2HrIA"}}},
      "KeysOnlineSignature": [{
          "UDF": "MCWC-ODYG-EWXX-6CLE-ZJIC-FZJM-MD6Q",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "yO4HL97oWU4tQWZRujgMX6CLf70eCHNq6T0eYncJ4CEzTg3jj930
  AfJRx9KToj5ub8m-qR683A6A"}}}],
      "KeyEncryption": {
        "UDF": "MBFT-ZR5F-BRQC-HJPO-OA5P-W3AN-CWCK",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "fBoBs8cR08OdqzXthDZZQ09L6CK3yxg-E0J_XtL-DzxDB_WAa7HD
  Rht0LTjhS--ZkOKYlb_fucgA"}}}}}}
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

