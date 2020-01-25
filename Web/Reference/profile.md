

# mesh

~~~~
<div="helptext">
<over>
mesh    Commands for creating and managing a personal Mesh
    create   Create new personal profile
    escrow   Create a set of key escrow shares
    export   Export the specified profile data to the specified file
    get   Describe the specified profile
    import   Import the specified profile data to the specified file
    list   List all profiles on the local machine
    recover   Recover escrowed profile
<over>
</div>
~~~~

# mesh create

~~~~
<div="helptext">
<over>
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
<over>
</div>
~~~~

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


~~~~
<div="terminal">
<cmd>Alice> mesh create
<rsp>Device Profile UDF=MAKJ-PBFP-LU5T-5Z34-YITA-PHYT-F5QS
Personal Profile UDF=MDKD-XTUR-GFP4-QD52-STNB-Q7GS-MEWW
</div>
~~~~

Specifying the /json option returns a result of type ResultCreatePersonal:

~~~~
<div="terminal">
<cmd>Alice> mesh create /json
<rsp>{
  "ResultCreatePersonal": {
    "Success": true,
    "DeviceUDF": "MAKJ-PBFP-LU5T-5Z34-YITA-PHYT-F5QS",
    "CatalogedDevice": {
      "UDF": "MAKJ-PBFP-LU5T-5Z34-YITA-PHYT-F5QS",
      "DeviceUDF": "MBEB-2PHZ-ETBR-YULL-H2E6-KP4L-YIJ2",
      "EnvelopedProfileDevice": [{
          "dig": "SHA2"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUJFQi0yUEhaLUVUQlItWVVMTC1IM
  kU2LUtQNEwtWUlKMiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogIklZcHdtQWV5MUR4UlBKSVZaMGc3Szl
  RMXd5NGZtamxOMHBiTjVCRlZWRXMwcThRNzVDVmUKICBVdFZCd1hpQlJTSU45N
  ms2ZHdTdzFxZUEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUFINy1PUFA2LUFRMlQtRE5VUi1UUDUzLUc0NEstTzZJUSIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVib
  GljIjogIjZ4bUdGcUhHM1BJV0I2TUxMYWppVWdUUnRXVUQ3VldvcWhPc2l4R1l
  PT1dzaHRISWVhLVIKICAwSzF6LS0ycGpyNTk3UWoyOHhuT2IwR0EifX19LAogI
  CAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1BRkQtWEx
  KQy1KWkk1LVdGVEgtTUxDRS1TSkNaLUxESEYiLAogICAgICAiUHVibGljUGFyY
  W1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJsRkJtYnhPN
  0ljS2FvVTFXNHVlQW1PLThYMlFaVHhjYkRWSmFfV1lLdTFaQlA4bl9SZVN0CiA
  gRUt1cUNzMS1maVhiS0pJUnRQbTB0MFlBIn19fX19",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MBEB-2PHZ-ETBR-YULL-H2E6-KP4L-YIJ2",
              "signature": "w6ykmAYWn6SrdneYLkgQLN4Xufo0TIsy5NRFK-NntcNhCEtNp
  BjntIsMDgv1YXiPlHWf7Un28GQAyDWRGFdMI-RDSaqWvPI_LlGqPB9RDX1flR2
  BpouB1Bvvt7s3XDFUYB6bcPEuJCKJ7THXigldWRQA"}],
          "PayloadDigest": "ug9ue2NJG-me-LbWjrkRFWFVNU67R0ygmIXjHL8RYgs7a
  diQu9ekpRl5rc_TOzmnbgoMxENuvs-5DFs_bTkEsQ"}],
      "EnvelopedConnectionDevice": [{
          "dig": "SHA2"},
        "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQUtKLVBCRlAtTFU1VC01WjM0LVlJVEEtU
  EhZVC1GNVFTIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiMklKOGNQaWxhUGVCZFFrb0g3a0FtNXd0bEV
  qdzNEYzA4bHBWSVNwRVplZE15TmtMRWJGRwogIGtaLVFxRU9uc0g5dmxHazIxZ
  0dqSkFRQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI
  6ICJNQktNLTRISkMtR0pDRS1QQUQ3LU02VlctSzRSQi1WRlhCIiwKICAgICAgI
  lB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB
  7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAiRFNtTUxXZnpVZE1oYXh6NVpTVk9pWHU5Uk9wSnBVZ1VxVnRsM25UcnUwWHJ
  fZFF1cmRmLQogIHdIT1lQNmx5NXhBVGVJeksteXZPS0dLQSJ9fX0sCiAgICAiS
  2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUNBTS02NVlKLTJ
  SWEEtMjIyRi00UDdNLVRGVU0tNVA0RyIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImN
  ydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIk1hZ2V0UjFFS0xWO
  ENfRXRveFg1UkR3VzJ4bndLVml5czNmbGhSc1Y0WXF4OTY0eUVpbEsKICByNUc
  5Y2hKUS1PY21mbnQ2dS1SVFlKQ0EifX19fX0",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MA6A-5JEA-7PRN-HHG6-GCLR-CYHS-DRAI",
              "signature": "DbOVSLVyeuCgRioE5f0xQW3ER85uTUx4mZM-KOqc5DusQ7f6O
  IR2DKuvyxuWvbMjIZ6waGgWBB-ApzwlGl-s38rihDm-oK6PuY3NTgmneNh_bOm
  aMtQ3pXjIUnbXsSt61AgCGqlaIGEPd1zYwX9O_TEA"}],
          "PayloadDigest": "2fkk4Pe5Z326E-scRyWRvxKwrrLjS_zn3VzkBJ5Qfio7a
  dyPwcxG5dfkedzBRAkoU1RJbJleW20nXa9DKnI9hQ"}],
      "EnvelopedActivationDevice": [{
          "enc": "A256CBC",
          "Salt": "E2Fx1RtPAqew0cGEIjL0jg",
          "recipients": [{
              "kid": "MAH7-OPP6-AQ2T-DNUR-TP53-G44K-O6IQ",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "bouwOuZ6rTokR0IuNl7SoqODaD4q1uJmuoCWV-BciZfZ_z5o6_Fc
  BvMpPbD6WZv_F91IIk4C2YwA"}},
              "wmk": "S8Y6xwriOkI-E_j0ZTJbihzrMxmogMeqNRifL_iDT203UwT5edjJhw"},
            {
              "kid": "MDKD-XTUR-GFP4-QD52-STNB-Q7GS-MEWW",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "JZWmuk0_BXdbQID0geVzqALfBwIZncchHQUu8V32xHAn4pn5TK-Q
  OVJxV4UHq1Wm2Q0gzNiEH8SA"}},
              "wmk": "Di1HGwgj3oBku4-MK4WcbTUMqtCV7xo2nRk2RBrXNde9ANm0WKnK1w"}],
          "ContentMetaData": "ewogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tIn0"},
        "HvY8NL8y6olbTNT8JOZrWJj0SyeX2HDwubcLSe496od
  Qayjg28XaRSDVJEfHs1gMvy1YdEMp4zLWtdOlmooNpkoJMorsAHFO2aYfMOh9A
  dgMG9ytwGjRMQwbw-md2DE7L07QJF3QbYjlNZZORnENm-HPYBcY6pHzFg-7jiF
  BeH_u9Zq3h-npPR8e5CvYmpb-9KNCHf8aPTGtTbmnCeW4k9zpZlrkguBY9ULFs
  cRhD0BkP4G5hdQQmD5T--bOtHiBVUl3lcwRZswaWj2ACGnlkE-g5TOrITqzOrY
  Uaez_rgabPK31Thni1zSLohu5EynKtxx161i_i46nT8KkxaMw07RWr6HKKnEhS
  2Dw8OCvLVRgfr-3WwyLpG7Dx-JcEYV893jc__i1ulS-2tvNDi0H8AZmwPqtBqc
  xBx0qTTOJ3GciahpX0YRbQuGhEBKLNGEcWIYVVnFxCkrpVE1mrC2Ue89dcoMPw
  Y4CH2KpzvjuxvYL317FyYdQvmLwuoKPuT-hnJQCi8Cx8pWuMJmfUu4o6xvVamN
  CD_GqYzDwDneTUjkRHFsBrzy_-QF-ZlHk3S5-lG85cMkRE6izf_nL0ntezxdh8
  ZBxdl_WWA1McATS0zfuI5SyOKPrz61QGwosHxmKDS70aPVZdfDGx1_p68Ja0c1
  dduI8D0I2fYV-hYhGwWTwLb61d2h8yZUUK1QKf4SVED_WsEPum6elr3xWfBnpp
  8eCVGk7-NFm9M7yl5UqJJxlVdCJRODebOwO6NP-2nRJWTy34U_9Vxzp87MZVC9
  XWlOOTlTr5nJ9xBdgjFVj1BCagQUZTB8BuWmDtw2mIgrl0PxIykJe1uDL3dR-N
  jEQ8WMXTVME1e6kNIqEctrXDWpk8tnwB91Of54A0jSXvuuWsUxe3WgoUl0RPQG
  ZcZ86sDmHzf3t6NZEFRc4gJfQpLYgT9zh_qlaPWeGM07ujpUS_q80fXrUZlvrR
  xC2IHUTHlnR2geJaaUObnq9EnzSFdoOzyOo97ZyS7i9s08QVHtF3OJCf6UY3IO
  8KwAtRBl8g8MEUwaJBVxi11vAKBBcfXlpAjchNPqJqqyDljXiuZmmd2mJIElKy
  mxnUH0taN81ogsJDhfhEmrJIfNPawuOn_XvurzGooCv7ow-PdJLLlAxEfC8Q7P
  KFGRGi4wJ4GHg-MOqNOXZ4U2PSQw3aYEmnbeZmd0sUHT0-4ccbdTJcXvTqNMLi
  -6Yv1fs34P157T9aps__PMgxqMgWWaHnMM4RGfmUyZqo-d9WXeTH9MW75sU"],
      "Accounts": [{
          "AccountUDF": "MBAL-44YZ-X4GX-USBL-JAMU-AW32-SLBQ",
          "EnvelopedProfileAccount": [{
              "dig": "SHA2"},
            "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1CQUwtNDRZWi1YNEdYLVVTQkwtS
  kFNVS1BVzMyLVNMQlEiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICItUkNVeG5RSWJDb0hnTlJWUU81TEl
  ERFVQQ3JvcjJxLU9MaDFGTlMzQVZ5QnJ3TzNCZWROCiAgYzduWHJOQ01yT1RhZ
  jFNRmUwWk1HcVlBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1BREUtSjNTRS1MT0FNLTdGNjQtU0paSy1CT05FL
  URSUEMiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogIndvQW01X1hpVWtFdDA2a1Vpa1R1eGJ
  2QjdPdU1hc0lONDlTMzY0Ykpqc0o2WVMzZ3ZDM1EKICB4eDNxQUZBYVhGTjg0Z
  mNpMllOdklpeUEifX19XSwKICAgICJNZXNoUHJvZmlsZVVERiI6ICJNREtELVh
  UVVItR0ZQNC1RRDUyLVNUTkItUTdHUy1NRVdXIiwKICAgICJLZXlFbmNyeXB0a
  W9uIjogewogICAgICAiVURGIjogIk1CTFItSkFTVy1JRE9RLURWSFEtUUYyTi1
  ZUFlVLUVSNDYiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAo
  gICAgICAgICAgIlB1YmxpYyI6ICJ1Z3o5OGdwNF9zOG50YkNvMHZacV9aSWVPY
  lduUjVtaWY0YnJaOUthVzl3S1FhY0tEXy1lCiAgQ3FHQVJoOENnSzBNUWtBaml
  1V2xvNndBIn19fX19",
            {
              "signatures": [{
                  "alg": "SHA2",
                  "kid": "MBAL-44YZ-X4GX-USBL-JAMU-AW32-SLBQ",
                  "signature": "sSlwdmtj-BRf8Lv8Wzi6ALsEF2CH1-6WOfCNBjrCBDQGgNRxF
  f7C8ywjIiDqxyBlZOKwpKdSVrAAs-Iz65_hoffQUNEtOEYfE6csa_2zzzDD8il
  VmFJssOtFs3KtLAIXNRDvkqcXDZrQv9wf8j5kCQEA"}],
              "PayloadDigest": "z-_eNAB-xLtKhsvzSWZJXNAiVRftMkWMqfWlpuR1QrIBb
  4REU14WhnuaMal_4p1U4ZCsQsj5NCBXCigIAeKUsA"}],
          "EnvelopedConnectionAccount": [{
              "dig": "SHA2"},
            "ewogICJDb25uZWN0aW9uQWNjb3VudCI6IHsKICAgICJTdWJqZWN0VUR
  GIjogIk1CVk4tNjdFWC1NUEVFLUNEVkItREtHNC03NFZGLUZNV1kiLAogICAgI
  kF1dGhvcml0eVVERiI6ICJNQkFMLTQ0WVotWDRHWC1VU0JMLUpBTVUtQVczMi1
  TTEJRIiwKICAgICJLZXlTaWduYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUJWT
  i02N0VYLU1QRUUtQ0RWQi1ES0c0LTc0VkYtRk1XWSIsCiAgICAgICJQdWJsaWN
  QYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgI
  CAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIjZvTmJ
  UWjlCdjNvalhXdHVkNnVVLVF3c3VfWEcySHg2U2xTUVFRWE9sN3A1My1ybkZEc
  UUKICB4ZkxQTXgta0s4NG5RWE54b2M5TUdid0EifX19LAogICAgIktleUF1dGh
  lbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1CN1YtWUs0Qy1OMlpPLTdSU
  kgtQ0ZQNS1CUUJVLVhDV0ciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICI4dDBPU2xFcWVJeENLQ0o2TEd
  MWXlwUVZ5VG9LNEVSQmYyVDBpX3B5T3I1Ri1Mamh4bUlMCiAgaWFOT1ZiSnp0b
  k5MLVdYckdLOWtVd29BIn19fX19",
            {
              "signatures": [{
                  "alg": "SHA2",
                  "kid": "MADE-J3SE-LOAM-7F64-SJZK-BONE-DRPC",
                  "signature": "c4OL9DQikEc55OioPsdruarBhQy5QnMtuJgaQP3uP5I5Pu-C9
  rnGl6HbnjkBRVNdg3c3NTVVjwUAbxE0mmFoV7ytgyfRKPfcGz3e9cIyKKbkQWT
  a8F79CQU4gyMC6pq_jGdws2hp6EXu92fY3dYEAzkA"}],
              "PayloadDigest": "OzZAcriUJVbUW1Trz23OQbur4lqFMePQbE2nPavTx799_
  Bztt722maU3y7zxCSVc_4dPGtEq22igpyQMeRqfGw"}],
          "EnvelopedActivationAccount": [{
              "dig": "SHA2"},
            "ewogICJBY3RpdmF0aW9uQWNjb3VudCI6IHsKICAgICJBY2NvdW50VUR
  GIjogIk1CQUwtNDRZWi1YNEdYLVVTQkwtSkFNVS1BVzMyLVNMQlEiLAogICAgI
  ktleUVuY3J5cHRpb24iOiB7CiAgICAgICJVREYiOiAiTUFEVC1QTFo1LUFMTkI
  tSjZUQi1LTlhCLURESFctUkdDUSIsCiAgICAgICJCYXNlVURGIjogIk1BSDctT
  1BQNi1BUTJULUROVVItVFA1My1HNDRLLU82SVEiLAogICAgICAiT3ZlcmxheSI
  6IHsKICAgICAgICAiUHJpdmF0ZUtleUVDREgiOiB7CiAgICAgICAgICAiY3J2I
  jogIkVkNDQ4IiwKICAgICAgICAgICJQcml2YXRlIjogIkJ6TDZoaV9ZQnVPWUg
  5b3dJb0NKSzUtLVR3WTgxOVhqdzBzUG1BSUlRaEF1RUIzV3UwegogIFJkcVItY
  1d1V3FwVmpqUHNDSzhvVHJyVSJ9fX0sCiAgICAiS2V5QXV0aGVudGljYXRpb24
  iOiB7CiAgICAgICJVREYiOiAiTUI3Vi1ZSzRDLU4yWk8tN1JSSC1DRlA1LUJRQ
  lUtWENXRyIsCiAgICAgICJCYXNlVURGIjogIk1BRkQtWExKQy1KWkk1LVdGVEg
  tTUxDRS1TSkNaLUxESEYiLAogICAgICAiT3ZlcmxheSI6IHsKICAgICAgICAiU
  HJpdmF0ZUtleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICA
  gICAgICAgICJQcml2YXRlIjogIjBueWw0R2RUc0hXR09YamZFTGNHekJhSWdsd
  TJmSk1nWXhubkx2X2JyNnB5RlM5WGRfRwogIHhGdkRpc2pmcHowellaWUI5VTd
  RbXl6cyJ9fX0sCiAgICAiS2V5U2lnbmF0dXJlIjogewogICAgICAiVURGIjogI
  k1CVk4tNjdFWC1NUEVFLUNEVkItREtHNC03NFZGLUZNV1kiLAogICAgICAiQmF
  zZVVERiI6ICJNQkVCLTJQSFotRVRCUi1ZVUxMLUgyRTYtS1A0TC1ZSUoyIiwKI
  CAgICAgIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjogewo
  gICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0ZSI6I
  CJuUlNRZ2pBdlhCMDVzMlo0RG1SR3NyRktqeFBsX2x3cV9CNkl4SGhVb0FVWUN
  3TXNydnYKICAyRzVlVDQ3aTZFd0I2RU5lZE5qT2wwQkEifX19fX0",
            {
              "signatures": [{
                  "alg": "SHA2",
                  "kid": "MADE-J3SE-LOAM-7F64-SJZK-BONE-DRPC",
                  "signature": "yf6Jhz3x7CSBILxis8eo1Y05kmFy9pR20NKHTZH1h6F0ITCjz
  mdBwQkZcRkA4INwQXlIM_xXJsSAvfpMC4H8wpgZoFSKLciFgyH0KPl6RtcxP6H
  zr1O1RdHt6Js-tVY7x-SxyJcHNPvvVEgnd1mznAoA"}],
              "PayloadDigest": "rV3H2ooDZXwrlxoMwohiLKgj8fAsejM1xxGWvkrQFEGy8
  vgbkQxkALm6X1zH3t7fCRvJDCJ1t5hzvc0a-J-7IA"}]}]},
    "MeshUDF": "MDKD-XTUR-GFP4-QD52-STNB-Q7GS-MEWW",
    "ProfileMesh": {
      "KeyOfflineSignature": {
        "UDF": "MDKD-XTUR-GFP4-QD52-STNB-Q7GS-MEWW",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "Y-EY9R4_-mGHvHUEJ48lYtrUb3pE96VifxJehF6dZQNZRc07EGoW
  Idkf7j1z-0o6eDC-X-rBbVCA"}}},
      "KeysOnlineSignature": [{
          "UDF": "MA6A-5JEA-7PRN-HHG6-GCLR-CYHS-DRAI",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "RdXl0xBxHTtrzZz4oG4CIYW7tgTS-p4VxVvRld-y0AZsgEA5-r-i
  ndlSUSeXc7ZLaGFyLiwSr0qA"}}}],
      "KeyEncryption": {
        "UDF": "MDKD-XTUR-GFP4-QD52-STNB-Q7GS-MEWW",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "Y-EY9R4_-mGHvHUEJ48lYtrUb3pE96VifxJehF6dZQNZRc07EGoW
  Idkf7j1z-0o6eDC-X-rBbVCA"}}}}}}
</div>
~~~~



# mesh escrow

~~~~
<div="helptext">
<over>
escrow   Create a set of key escrow shares
       <Unspecified>
    /alg   List of algorithm specifiers
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /quorum   <Unspecified>
    /shares   <Unspecified>
<over>
</div>
~~~~

The `profile escrow` command 


~~~~
<div="terminal">
<cmd>Alice> mesh escrow
<rsp>Share: SAQE-Y4MW-BH55-ZL57-4XFP-PQVZ-VLHT-U7C3-X2BA-ZOCW-75EE-KZZM-3KSQ-E47T-O26A-I
Share: SAQZ-QGZL-CPK4-DXZN-EOWK-2AAO-DS76-6JV2-ZXUB-YSVJ-TJKK-ONXT-CDVB-S633-ZANC-M
Share: SARO-HRGA-DWX2-ODU2-MGHG-EPLC-R2YK-HUIZ-3VHC-XXH4-GVQQ-SBVZ-I4XT-BAYE-DF4E-Q
</div>
~~~~

Specifying the /json option returns a result of type ResultEscrow:

~~~~
<div="terminal">
<cmd>Alice> mesh escrow /json
<rsp>{
  "ResultEscrow": {
    "Success": true,
    "Shares": ["SAQE-Y4MW-BH55-ZL57-4XFP-PQVZ-VLHT-U7C3-X2BA-ZOCW-75EE-KZZM-3KSQ-E47T-O26A-I",
      "SAQZ-QGZL-CPK4-DXZN-EOWK-2AAO-DS76-6JV2-ZXUB-YSVJ-TJKK-ONXT-CDVB-S633-ZANC-M",
      "SARO-HRGA-DWX2-ODU2-MGHG-EPLC-R2YK-HUIZ-3VHC-XXH4-GVQQ-SBVZ-I4XT-BAYE-DF4E-Q"]}}
</div>
~~~~


# mesh export

~~~~
<div="helptext">
<over>
export   Export the specified profile data to the specified file
       <Unspecified>
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `profile export` command 


~~~~
<div="terminal">
<cmd>Alice> mesh export profile.dare
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultMachine:

~~~~
<div="terminal">
<cmd>Alice> mesh export profile.dare /json
<rsp>{
  "ResultMachine": {
    "Success": true,
    "CatalogedMachines": []}}
</div>
~~~~


# mesh get

~~~~
<div="helptext">
<over>
get   Describe the specified profile
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `profile get` command 


~~~~
<div="terminal">
<cmd>Alice> mesh get
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultMachine:

~~~~
<div="terminal">
<cmd>Alice> mesh get /json
<rsp>{
  "ResultMachine": {
    "Success": true,
    "CatalogedMachines": []}}
</div>
~~~~





# mesh import

~~~~
<div="helptext">
<over>
import   Import the specified profile data to the specified file
       <Unspecified>
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `profile import` command 


~~~~
<div="terminal">
<cmd>Alice4> mesh import profile.dare
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultFile:

~~~~
<div="terminal">
<cmd>Alice4> mesh import profile.dare /json
<rsp>{
  "ResultFile": {
    "Success": true}}
</div>
~~~~


# mesh list

~~~~
<div="helptext">
<over>
list   List all profiles on the local machine
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /mudf   Master profile fingerprint
<over>
</div>
~~~~

The `profile list` command 


~~~~
<div="terminal">
<cmd>Alice> mesh list
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultMachine:

~~~~
<div="terminal">
<cmd>Alice> mesh list /json
<rsp>{
  "ResultMachine": {
    "Success": true,
    "CatalogedMachines": []}}
</div>
~~~~



# mesh recover

~~~~
<div="helptext">
<over>
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
<over>
</div>
~~~~

The `profile recover` command 


~~~~
<div="terminal">
<cmd>Alice> mesh recover $SAQE-Y4MW-BH55-ZL57-4XFP-PQVZ-VLHT-U7C3-X2BA-ZOCW-75EE-KZZM-3KSQ-E47T-O26A-I $SARO-HRGA-DWX2-ODU2-MGHG-EPLC-R2YK-HUIZ-3VHC-XXH4-GVQQ-SBVZ-I4XT-BAYE-DF4E-Q /verify
<rsp>Device Profile UDF=MAZC-3DVD-LIWY-A6UV-XGWR-GSBA-62YB
Personal Profile UDF=MDKD-XTUR-GFP4-QD52-STNB-Q7GS-MEWW
</div>
~~~~

Specifying the /json option returns a result of type ResultRecover:

~~~~
<div="terminal">
<cmd>Alice> mesh recover $SAQE-Y4MW-BH55-ZL57-4XFP-PQVZ-VLHT-U7C3-X2BA-ZOCW-75EE-KZZM-3KSQ-E47T-O26A-I $SARO-HRGA-DWX2-ODU2-MGHG-EPLC-R2YK-HUIZ-3VHC-XXH4-GVQQ-SBVZ-I4XT-BAYE-DF4E-Q /verify /json
<rsp>{
  "ResultRecover": {
    "Success": true,
    "DeviceUDF": "MAZC-3DVD-LIWY-A6UV-XGWR-GSBA-62YB",
    "CatalogedDevice": {
      "UDF": "MAZC-3DVD-LIWY-A6UV-XGWR-GSBA-62YB",
      "DeviceUDF": "MCMC-BYCS-XOCV-A4CH-5WY3-VJB6-NYIF",
      "EnvelopedProfileDevice": [{
          "dig": "SHA2"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUNNQy1CWUNTLVhPQ1YtQTRDSC01V
  1kzLVZKQjYtTllJRiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogImFOWTRiUEd3UnowaXg5QllRSmtPdlp
  sVmtLb0wxVWpJYjcyMWpjcEVqYUZJSS1oY3RGNFEKICBwbmpKb2JoWWNjODhFT
  1AtQ2x5b1lJR0EifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUNSTS01WU5ULTRFVkctNDU3Ri1RVEhTLTdESTUtWDdEMiIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVib
  GljIjogIlJHaTh6c2tKQ01VbVp3b1FUZkk5ejZpWlU3LUg0cDV4LXdrOUNJNXI
  2UHlGNlZraFVKS0kKICAzX2pWMWt0VjJ5TS1WbzJnTnhMYWJNU0EifX19LAogI
  CAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1DWVEtTUl
  LNC1US1MzLVk3WEYtSklYSS1PWVRYLUo1UlEiLAogICAgICAiUHVibGljUGFyY
  W1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICIzeGd3eFJ1V
  W9DRkd5bnY4VTMwT1BucW56eG1vTE01cXRzLUlEWnNPTktweVlvTXljN3YtCiA
  gM2R4VlRMNG1uaDdnUUhscDRzWC0xYjJBIn19fX19",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MCMC-BYCS-XOCV-A4CH-5WY3-VJB6-NYIF",
              "signature": "dutoRIJHrgKpKJw0PirX45IoKivxcsIsffyx70CJyAkf5gnez
  -mhKcUDUipR-ixMbLVz5EKBVD0ALulgYEl_GWHZmrZ93D_YudobvfsGFyfgBtP
  RImfZUUhyKfV6S_8TNHS6o_0mTgt-5RLdMre68A8A"}],
          "PayloadDigest": "x5bKb8ljnHh4tdswCsgF0vH6gPooIfprO0e1z4mfPIMmv
  UBr_J5fuspJoNWl_AmZ3lwLYlc_8T1drRRlXIK0ZQ"}],
      "EnvelopedConnectionDevice": [{
          "dig": "SHA2"},
        "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQVpDLTNEVkQtTElXWS1BNlVWLVhHV1ItR
  1NCQS02MllCIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiN0h5SW1hQ0ZyWVFjdlJ1OUM0Tnp4di11M1V
  ZQWVfcWN3QlctNjJybTVYeGlTZVpBVktidgogIE95N1VmOWZTRm9iMG1XSkVSV
  nVqdFZPQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI
  6ICJNQ0kzLTRVTEstNjdWUy1UVEhJLTNLTzMtWFVRTC1TV1JRIiwKICAgICAgI
  lB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB
  7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAiX0RYNENmSjNUR3k0aGhVZ2hGanRtOVI0MHhwX2NjN0t5S2tZR19KTFBEMEh
  3ZTFNSkNiOAogIGhZNm51UTE2MlEzU3c4TXJTTFZ4M3dHQSJ9fX0sCiAgICAiS
  2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUFTVS1PU1lTLUR
  UR04tTU8zSi1NWVhGLU9KR0ktNUIyTCIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImN
  ydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIkk3T1FQbkY5OWdzU
  W5HYWY5Z05aYUh2Q2NOb09HS0sxS1F2Uy1tNkR4ZWJJY3FRRHc0LUsKICBjcmx
  vdXdLbzNabjg4T0sxeFhUd0JwR0EifX19fX0",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MDXX-ISMS-XN7Q-7PZP-4KW6-HI7B-TSUC",
              "signature": "R7I5510UGY611cPI4Hh9h60wfQy_ctSoGproC7agiRsTN7Zuh
  cxAKp6_-Syfl6MLMA5a6ynS_34AzZbGDVT1V8EadqdocjbjSDtVjFUCicGTKD7
  Khs6vmaBe0fBqOlxepfUSWi66b6ETRqRLU7TZrhsA"}],
          "PayloadDigest": "gK8w-k2XY_MOQxwmsDsJyFJhHxQKY_OCGHdGK_ATY_r3F
  RNDHwsrrm-slZVCooAhj81cXoWkY8qOCnHfE-kAuw"}],
      "EnvelopedActivationDevice": [{
          "enc": "A256CBC",
          "Salt": "N0M8ZBSJjL467RhtZBA9xA",
          "recipients": [{
              "kid": "MCRM-5YNT-4EVG-457F-QTHS-7DI5-X7D2",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "dNjPTAdii1UZP7ALTswvLZM7zzO2JLtXFGSzDsEc6jiiHjuVXKlD
  64WwRROZSK4x0YnTm3VdHUGA"}},
              "wmk": "xPLTB8_X9fPFzkrd9ZJ1cUzEhYtFf805-4zBPxWHZc36OAcr48hSAA"},
            {
              "kid": "MDKD-XTUR-GFP4-QD52-STNB-Q7GS-MEWW",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "2MeamoqbTFHdWRzu6x7znMleJ_iabMZ1DE2XgdEAPyedHJmYwITW
  fDZ7vvvhmTtSAGWRLSYUq9sA"}},
              "wmk": "wzlio3yqLcENODLvdVj3vwbgIzy1FzQntSkt8OuuPy9yG9baVHCOXg"}],
          "ContentMetaData": "ewogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tIn0"},
        "cITYOd_JrYznPF85DGpz5fD2B1QLKl_jCIOf1Hx_reV
  OAQhMPm6MU2SDmqa4x6oJ_Yu0jFuXCELQK81EAPHwpAc6Wfdo8PEc-quEDG8nE
  824PqZEXisS9-9Kf79vSt64Nr0MFVMG0jZLUNuPRcVu4ASVKpomHHVH2lfD3sl
  0YpgLvTD1703anGHRaOvHLLaUxtnx-ziW1XdL3EmWFXHKqhCtoiZORqhZ6nOe1
  cxnvrqGdLn3Ej_XisMngEUM6ppu2cFwKiL4VwPaFOmiODLGsrsNCbntbl2KmAP
  0aMK5GZsSclP0No2SqhBVdIBgJPbbzxHGWiJS4fz_algMomrNySd8WcYU-Hk_4
  q8KkQgA5cEt48UhMYOkmCLoK5fTmXmDrM_SK1jT0tvuqLDpSuaH6kCTk6l_tL2
  EnIMj1Wc6IuqJnaS_pkfVPRdIMq9wOMVCkvRbYi25wEKe1XUjkg-aTcvRKr471
  Q_P5Nf7oQRytIn-dZVlc9_wROE_Vkj9qLiFP6XyphNPVYUCE4NM7evgAKDfVg-
  a1pfM9N6b3_QyEp31kDKxLiCQqe5nJtmLBDqjAFF6ldfgJ36sAO7HAX3bjs7c4
  PCZ6JQaQHAXH0QT54NmPCJU694C3Tto7v2v8a4wJ1RPyUHmGGzMu_g6D2HejR-
  -A5lo6hiA4W0crrF_TjQqc4NCvhqXH1mEATUr56Mvz9N8GJm8q0b3GVMk5QFD8
  B4sOf8B_t0OzQUD5TLS8oBCnKo9KnntRrvcN4_vBttY6-OGutYjKQR2uDmlFU7
  edn7RnRIK3ntuvT758ImP8uTclX68-Amz3LndaxJGiu-GOgnzt56J3c1I34UCa
  7wj4E41XIXFZgC7YkLT4YHJEGtTW4kiAg9gD--wy9w8tQfc8btfLv6YnlpPqZH
  RN8FsH98GLm31fwBZ9af0eduRocdGxtl9ayd4fPsFPnSVC1cm-QXLEz8hsS7pS
  dcjSllKZyjNh8tiyagn8YGSkpftElUhepYTj2HoXnkJIxe3rZuXE6xGKNSOnkx
  5UALpaffFdCBAYM4it3pY1SfjVb9oBfhlQVbUf7iZmChreVSV-VqgsCZZ3N9z_
  TYk2E0PadZhEny1OqhGGXDlqIQsx0hpWMpX4SrkqLc4KHnOdeWx-ypYKJLgShX
  8L_2kYzOOk92vEHL0UmNI4dR1w8mPpBrAFPdPI7iMzMPSrW-_bLtC6Zy52TfCS
  yFBHMpnoknCRN8RmBEiX3t2xa-XqoQ3JOgzjQ0p5oBEthOjHhRZjHKwbNXo"]},
    "MeshUDF": "MDKD-XTUR-GFP4-QD52-STNB-Q7GS-MEWW",
    "ProfileMesh": {
      "KeyOfflineSignature": {
        "UDF": "MDKD-XTUR-GFP4-QD52-STNB-Q7GS-MEWW",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "Y-EY9R4_-mGHvHUEJ48lYtrUb3pE96VifxJehF6dZQNZRc07EGoW
  Idkf7j1z-0o6eDC-X-rBbVCA"}}},
      "KeysOnlineSignature": [{
          "UDF": "MDXX-ISMS-XN7Q-7PZP-4KW6-HI7B-TSUC",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "sPrwNklVPX2YCeQ7NJul-6rGQniR-f9IPMq88huAX4jm4smAShd7
  2pb0pjR7S2AN03MEmTlmpCMA"}}}],
      "KeyEncryption": {
        "UDF": "MDKD-XTUR-GFP4-QD52-STNB-Q7GS-MEWW",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "Y-EY9R4_-mGHvHUEJ48lYtrUb3pE96VifxJehF6dZQNZRc07EGoW
  Idkf7j1z-0o6eDC-X-rBbVCA"}}}}}}
</div>
~~~~


