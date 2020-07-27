

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
<rsp>Device Profile UDF=MB25-BJYV-2I3W-JHRQ-Z4KF-BPMC-BYUG
Personal Profile UDF=MBU4-C4AJ-TGTO-AETP-LQDC-R3L6-VMX7
</div>
~~~~

Specifying the /json option returns a result of type ResultCreatePersonal:

~~~~
<div="terminal">
<cmd>Alice> mesh create /json
<rsp>{
  "ResultCreatePersonal": {
    "Success": true,
    "DeviceUDF": "MB25-BJYV-2I3W-JHRQ-Z4KF-BPMC-BYUG",
    "CatalogedDevice": {
      "UDF": "MB25-BJYV-2I3W-JHRQ-Z4KF-BPMC-BYUG",
      "EnvelopedProfileMesh": [{
          "dig": "SHA2"},
        "ewogICJQcm9maWxlTWVzaCI6IHsKICAgICJLZXlPZmZsaW5lU2lnbmF
  0dXJlIjogewogICAgICAiVURGIjogIk1CVTQtQzRBSi1UR1RPLUFFVFAtTFFEQ
  y1SM0w2LVZNWDciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgIlB1YmxpYyI6ICJkbjZTNWE4NGJpUDI5elFsVHNGcTJpdHM
  1OGk5WXJFalFOM1N6bVNCc1YzN0tsdkpGY2Z0CiAgSGoxZjN0b3l3M1BlTUdPR
  0VBYzhkVFVBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3sKICA
  gICAgICAiVURGIjogIk1ETjItQVhBSi0zVTYzLTZJVFEtSjJENS1DWUg1LUhNS
  lQiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogI
  CAgICAgICAgICAiUHVibGljIjogIi1iT3djSkYyZnB2ZjU4eUFkNmxJTnExZGY
  yQkVYRDYyd3BZNmdRRXpyUG5zU3RIZEFKNG4KICBiUXFPek8tbzFwc0YwUkRXd
  URhQXZua0EifX19XSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgICAiVUR
  GIjogIk1CU0MtSFVDUS1MNjQ0LTQyQ1QtVFlRNy1TUE5MLTc3NUsiLAogICAgI
  CAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI
  6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljI
  jogIm4xRm5VdWZHaDdaOHJad2FPNEJFRWt0S3h1ajRlUHFSNFJxcnl3VTU1bVQ
  wZk5BckJ1LXMKICA2eWpKS1puUFRoSHpGci12N2pVX3U0b0EifX19fX0",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MBU4-C4AJ-TGTO-AETP-LQDC-R3L6-VMX7",
              "signature": "ekJ21H4Em51VHkZuw-wLLxw_Zr0SQgaCoWSJ_1V8i5tkbPpmb
  0VN1dqqahtqgr9wRi3wJHXDxFoAUov5ZRbL8h_XlXOWVcGJnG6Kg-hvzv0bjOZ
  _YnyBomcRpGvWwCIGBI4atrijPefpFJlhmeDOzxsA"}],
          "PayloadDigest": "637FkhvB-AOIsnaaMBZd1Lz3mjjwfQPsMHBXN0eGaLGd1
  BmpTL9Weg55OqHUiQzWbbrBH14TVbFlpMQ8iQhntw"}],
      "DeviceUDF": "MCXI-75JG-RVBH-NK5X-IUWM-G2BE-JML6",
      "EnvelopedProfileDevice": [{
          "dig": "SHA2"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUNYSS03NUpHLVJWQkgtTks1WC1JV
  VdNLUcyQkUtSk1MNiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogIm1zM3QyX0hhX0JWdG15TjZOSFpjS2p
  CZDhWM1pYXzAzV0lmT3RVN0xfUlFXdnZCOXhoVWMKICBkcHVMU09VamN6QlVSa
  1ZHa2VlblVxUUEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUFVSS1HU0VXLTJNVFYtVURESi1HRkpELVI0TDQtRUVRWiIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiME5YR1Btdk5KbnBpSE90Q0FGM254Rk1nWWd6TExrYUZYN1dfcDBhWlg
  1TUtBQThEajROZAogIGxWLS0wN0dHZXRiZ3lIV0phdUU5Mno4QSJ9fX0sCiAgI
  CAiS2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUJDUS1VQkd
  OLVJHMjUtVk9MUy00WFhBLTdBR1gtNkdSTyIsCiAgICAgICJQdWJsaWNQYXJhb
  WV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICA
  gImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiLUNKWDhVTF9MV
  1B0cEp0ZlJjQzY4Q0Q4UVBBQWNuU0E2UXN6X1pGQXFRNGtzNmRsaDlmUgogIEl
  lOHptNmdXR3lZLWxNUUw4cGlFZU1BQSJ9fX19fQ",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MCXI-75JG-RVBH-NK5X-IUWM-G2BE-JML6",
              "signature": "-HIhd-VdU55-qAKSZQzDu9MfqXVyCfGzqsg5DFWF8AKIAZXDd
  D2-aEIINKRwJHSzk6CcHDQv6RKAn8ZKwhLik1zhEpqMm5gqZTZUa5dwc2NFq1w
  kVcHdajk3tiMX9nPx_CDTR0F9_0tj8FxwrHDUmAkA"}],
          "PayloadDigest": "A_93dp5yHtl3PsUcRCIMVkpkXJHjDiBlB67PfAWSJDKKg
  wqCvt_2mFen2GN7nWk5kf7IZdn4p96Xd8XPJdBfTw"}],
      "EnvelopedConnectionDevice": [{
          "dig": "SHA2"},
        "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQjI1LUJKWVYtMkkzVy1KSFJRLVo0S0YtQ
  lBNQy1CWVVHIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAia2tNSEdWRGt4eVd2WWdsclZ4Y2Vnd2VSaml
  QSVgtWVZlbFRHSklxMzJoUDR0Y213OUd2XwogIFFfM1d4M2FZVWp3U3hZc1g3e
  HBCWWF5QSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI
  6ICJNRDM3LTRKTTctUFMzUi1EQ01LLUNCMlQtRVBDWi1KQk9TIiwKICAgICAgI
  lB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB
  7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6I
  CJqbF9vM3o1bWdLS2VjOXNEeTE0Q29HT0ViRW9ZUi10OUhWVzNMVXNvRWxtZXg
  3S2k3SEJiCiAgbU96cFhTNDVqR29aNmQ1elBTSzJ1aUtBIn19fSwKICAgICJLZ
  XlBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVERiI6ICJNRFhCLUROVjYtM1U
  1WC0yQzZaLTZNUFctTzdVVC1RUjQ2IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlc
  nMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J
  2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJuZGU5MHU1VUtpTXNVL
  V9jQl85UE15NjI0Rjd3anlNalFidGw3Y3R0ZU13ZDFoNUt3Mkp1CiAgV3FCUlQ
  1bUdmUU51SW9BUEZTaEdZeE9BIn19fX19",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MDN2-AXAJ-3U63-6ITQ-J2D5-CYH5-HMJT",
              "signature": "dclC_CQotlUEDeBvqBXV09o68cOppLcPzBHJOE90wCDHHObbH
  9tg_qrb4b5pMmU6sDx3hqb5Z04Axg6mZ1GRu76DzbhIbjUU3NGXFMyoNUbgDSo
  59v2W9ghfShufqJzoSM-FL8-G7L7eJu9P9MFMeQcA"}],
          "PayloadDigest": "ENLl5Rpn5LopEKRw5QxXDEUv-CCvKyt-Cr8FFHkqGxwq5
  7Qx2V4dK2USJ50uUIOC8CJXEalZyPa3gsJIay9Ppw"}],
      "EnvelopedActivationDevice": [{
          "enc": "A256CBC",
          "dig": "SHA2",
          "kid": "EBQP-GPDK-ZMCV-RGLN-2C7T-RKQO-ARAZ",
          "Salt": "AAs_R7YWRwtnnMS1VD9pyA",
          "recipients": [{
              "kid": "MAUI-GSEW-2MTV-UDDJ-GFJD-R4L4-EEQZ",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "X448",
                  "Public": "K03Pe1Bt20EnEV2YvzN1OkIykxhPjBYBQh5HpGPRWemOQRUlo90a
  H8d3BCaksLLhmmXkE8wVN6qA"}},
              "wmk": "YCVNpOd4is25nw_I9lbOw3i5eySgYwWmLlGe9fYcevVHYDOoi-cO_A"}]},
        "Ncfc-c-3rCS2ekMrvBfceRM_Dy7kqTOZq0KTDS28Wm3twcO8Hw0-OV4
  HZWHSH8bbFvXto7LlYG6hYCxFwqYgKKj_mNl7QsYvtigVXl4t2mL8nYg-x6DND
  ElcoX86tnnhf8nL1DaY4cocCMhby9UbUJ_3h_mEzQpGjAhgiYRct8XXpJFRFIf
  fkwwDZfOb6COiuljgUFHogicq03q4lqjoOPmFDGK3RfWqAC-Wyk0R86-BDy-Q0
  QV1VNWqZ7tBXeckw7JHuMD2NNAb6K87m0wM0VMByT9sIgKva42FZ05D9_rX3uh
  UEBNKTfau1fZ6_ZfDyvfUepQgykYG5v3unkMrK_Mo77T9cKKsgJZBntwgGfQMP
  _yMZP8pekWsZnNjc4Hmz6F57Me1I14XyBDKiTFiemIC9Hpe8jBCvgaVL94Gxnw
  hVDmX1ojFNs9_mD8m-WYj2YlXolqghMAhEmvZNuAnZ2riqTC-uT7SP8t3Y6cvu
  lZQCJyUQT7aOK0379sGly2XY4b1ZR-k5yUfdVvqRfECuW3u10UPQt6-PsODzMY
  o2ulqxgbgOadcEm6340tsaYu-jshmVnsiOordF0av_S79uaqYeKmcax-kB9CqZ
  bFrvBVVMK9NW8hPXgmDPn7JB_80-6IegkZQd1bwGXD1XYWAbamokXE6sbOzYbY
  apLfmWozz1Vo0cwEFV0pC1acwsmoigekTPsi-BiGQKSQBYWrpjBWM3GuGj1GUF
  5sGUDwuhoqi_ha2SVCkw8HKp8PIrsXV-Wit-_OULIvxH17q3udVbubUPbSWwo0
  6E4wi8PDgovjskeOC0xMOMcGheVGys6kGSZ8OJiC05vVBinyJQHtHO9RRICytt
  GUYc6fWD33srGZUPIxolc5XJ9Nb8uL7SUNr_Oc_7ykuNrPAeiLg5bfQMjKNmDL
  P4Ak3YOa9rrQgPnrA0695vEqBPrup-uHGsTAVVBJZNx7r7OhiXBMnnGgeriRM5
  xt0wsiju1JzSC62z8xfyOgVR-csBNRMzhdQ19P2aq69defd96do-MZQV6fVTfQ
  ioBnKIxmZSfnwN-09bjol4OdYP_Z1HUSyPEQrMUrLoklxTmEOeTwSwXCDhGNDQ
  _1t1fzfwP0jfRR94hPeTd7YaEPu9LKp4tCQ2t0nPUjD_pKlxtL8b6FJvvIU6ig
  QxJtFeE1pp7DTBjNsvp0_JaHaI3n8VQFk57_ZPMCmMvJ01UfIdrpov9pgcvHNq
  FXgqN5nvUNWnLRyMYiIJuDh5i-sdTz_dmpu6R4O2i0UnJoEKz1vRWCSB6_f74J
  8_saNNnME_qHSgKXJy5AjNqD9CEZx8PQaBE5ILN7VvCUZdz8Qp16fS3s6FBv9s
  16dJtCbjAcyOjfGTjyREhnjAWJpdvBPVOBBu16mklhwi8O1nUXeWQ_SSYNhrr7
  kF7tHJnUodqJVkGUB4n4hY-TFwS-iNzmLLFyoIH0ChUiAn9oLt-JpITYJ7D6Y0
  iYb2id8L3vFf30clRLG3WW4hc0GVRsAIF8WRxSuP9Eaux3vGSHukp8oNsGLBka
  9apV0xVQKxlzJxtdtOu6N5ewZ2aNlRDFNxOAHkJiOgSyp_4KQ1C6t2SovBtALd
  Jec3smC-TtLHcDFMpn6oleAd-3V6r2CATGlOG3YcIFkVguDsjOW_quPG2qM64j
  Qn0on6OU5dPRw0WbwW6OGg-kLlNBGPJb8EmbhKu6GEMVr4bkVkgWGeyk5VozVR
  KcaNVKjDjG0zJHGT3uSGbb0lmaD79l1WMn6hnqLRa1FhbmFCXoOiY1bxvDXkkU
  ikQ0U3--6xDQj4VuISK5ByzKKia9Fm3yOEFBmAhmdauKG6dvvjO9URr5aNuNAU
  ICbiaBdYjMQABNGCjiRhMgSZ_Q3h1Q74Lfj0WF4pGCJl5oY1kuVoDBF2ben1C2
  umsRPbuhtRcFYjxzzzS2FWQbDk1fWwvOg96XFR0vJjxeI4wH0Mh2mt83ee72Tp
  iDl46x5DxezwuD9wQIdGFTzT2dO6NH6_6SthYs3LvfmNyRhVu5GA64rXRAPhXZ
  IiSZED8VJrEEQc-zEZQHfiLPcfJS7rzEVhzHK-sqTe7aMAsUfg3AQZVmGhTmKw
  8SvFUvFw9dZXkYmmBQwLVW6coDpBDA5PRUz7bxJwTfQc2Rwh_6cSpL_jtUFDPq
  SoujpZ1M-GAICsHUJAVg2-UaIagNZ5hqFlITWDK9pL0rd5UYYfXptpD79T7tzX
  vz0GM-fudekX0SShNACdS7EY6VOywX-c7F6FS_gvbI15I4tpAstkBk1aGi-iBN
  aAKH6ZUk_1_JLETxiHSHrG3-OaWTV3NIySUTWxA",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MDN2-AXAJ-3U63-6ITQ-J2D5-CYH5-HMJT",
              "signature": "P8KN9cMyivAK3BuB6xzdfvcP-Q-icYWThnnxV2w3GtJjm6nwr
  d1egaxLZN2FCIBWhnNuRJuzVnWA3XQbG-kz66628_031vP_RwhJfLofYXArW5U
  4n0YsA9DKPhlMhVvaLurq8TA_TXWLFeEjtX0sKRkA",
              "witness": "z9LeERTTwBuySORTW1z8FclnVONJQUbnUhE3XuMOzLI"}],
          "PayloadDigest": "quwdss3NAxi_lj5ZndDPjbjpUHhbz6-gdU2Oxsese2X2z
  EtDN9QaZzE-S6FRKubawE8hTzubZ1SYmO0QLlOaog"}],
      "Accounts": [{
          "AccountUDF": "MDWA-A3BV-DQ6V-F3MA-L3RW-GITX-JAPX",
          "EnvelopedProfileAccount": [{
              "dig": "SHA2"},
            "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1EV0EtQTNCVi1EUTZWLUYzTUEtT
  DNSVy1HSVRYLUpBUFgiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICI1aXhsSk5lWUhwVWRac0xrUlB1ZFZ
  neVBGODRFamJzZEVUM0VWcmRVNGdsZ3ZEMlBMWVlwCiAgY0tmWnNBZ1c4Uy1HR
  VVnZUtzRHdiZVFBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1ETzctQjNZNi1KWENPLUpQQUktUjI1RC02S1RCL
  VAzTU4iLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogIlBadVUzVEVkQnFuaHlhTzVfM2hwWl9
  OVW9BaFBicjJqZjhJdW5fSGk4RG5BZmoyREtteWEKICBBX2U5WkNFUGQ2Zkd0O
  Tl1cHdZakR2RUEifX19XSwKICAgICJNZXNoUHJvZmlsZVVERiI6ICJNQlU0LUM
  0QUotVEdUTy1BRVRQLUxRREMtUjNMNi1WTVg3IiwKICAgICJLZXlFbmNyeXB0a
  W9uIjogewogICAgICAiVURGIjogIk1DVTUtUkxVNi1MRlVXLTdEUlEtTTNRNC1
  NN0pDLUdUWkwiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiA
  gICAgICAgICAiUHVibGljIjogIjBjU2xmM2hCZWNiZmNiOEsza0hiOTViSTlUe
  Wt0NFRTVUI3YkFVU2dzX3IzVzJWNEkwOEsKICBPMUJrUVRxaHdTRTBZVnJUelJ
  oUmpyNkEifX19LAogICAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiV
  URGIjogIk1CWkItQzQyQi1CVTNELU0ySlotWU9LVS1aRFlWLU9TN00iLAogICA
  gICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNES
  CI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGl
  jIjogIk41NU5tempYMDRZRzhsMWs1cVcwQjg5OExPdE04SXFiS29mVC1yTGNNM
  jdQV0RSbTBRX3EKICBZV2ZPWkdTemh6c3pCZ1Y4aTJtSVpaYUEifX19fX0",
            {
              "signatures": [{
                  "alg": "SHA2",
                  "kid": "MDWA-A3BV-DQ6V-F3MA-L3RW-GITX-JAPX",
                  "signature": "wd--3iKDZIt5caJ-W2HDQEHnntz27WOYf4FDYkqDOPVQ8erVB
  0rY6jgp1OcLbwDrzWhs4jH-z--AdffLLsA6hy8STRWB0DoDsBVprjMBYwu1eEd
  dsVXCUKTIehy30y1BqMo1pHPJ0KpYdZqtoyLUZyYA"}],
              "PayloadDigest": "-m2SuZxlWYgflc5R2sxEon3uodZ6fJkIQ0DS-KtnPAK5g
  txqtXQvOGQmsWf6RNrSOohDw8QZfWSwwvOMf_9RZA"}],
          "EnvelopedConnectionAccount": [{
              "dig": "SHA2"},
            "ewogICJDb25uZWN0aW9uQWNjb3VudCI6IHsKICAgICJLZXlTaWduYXR
  1cmUiOiB7CiAgICAgICJVREYiOiAiTURCWi1USlY1LVFOSlUtU0VaNS1PS1I1L
  UpMQkUtNEVZRCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICA
  gICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsC
  iAgICAgICAgICAiUHVibGljIjogImxpX3hIdzRiVmxDVzN6TkhVQTJlYVBJSE5
  FZmt5MjhsZS1mdTBOOWY2VldOaXhabVRjR3YKICB1WHBRYmNfRjZ6eHRPQl92b
  EZBMUdva0EifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJVREY
  iOiAiTURYRC02WEdPLVREUk4tVkZNNi1TTTNRLUQyRE0tUTVFMyIsCiAgICAgI
  CJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjo
  gewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAiNXdhYk9qMkN0UzlOMGVTRjd2M25QY0VZQVl6LUV3eE5xd3BncjdieHlXajN
  DMUl1ZExaUQogIFlmS1Zod1djc1k0QVZiRE9pV0tEanRhQSJ9fX0sCiAgICAiS
  2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUREQy1SUDVILVl
  QQjctUktJNS1EVEdYLU5ZM1QtQzRTTiIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImN
  ydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiYWNPT0ZxcW5YNWFyO
  U84WU5aMjVRSlB3clBIYjNMNFhXZjZVTzVyYUpFSlkweHhRcGp4agogIFJGX0t
  EQ1J5ajU2dlBkNUhSd2hlekY2QSJ9fX19fQ",
            {
              "signatures": [{
                  "alg": "SHA2",
                  "kid": "MDO7-B3Y6-JXCO-JPAI-R25D-6KTB-P3MN",
                  "signature": "ExlTqa3EfBvc1kTMENe3cuBOr_vLRS9Zojxy6ECnrUHJUjzYf
  YRtNxJxC1P2yINv27DmcemaOc2ASaf_lcYghpgsobEt9rEukJbOCYFxHRiCemV
  iFG0Rt7yaULNL_EP8u7DR2r-epRPzBLq1p8NAxgAA"}],
              "PayloadDigest": "AmH_ihj4Ws2uaagCbxDUdBZDoM9rQ6OFz8wmCtilVIFU7
  aEf9anV1D9hn18R-uP9ufZJv4bD9cWuqgtceS2s-A"}],
          "EnvelopedActivationAccount": [{
              "enc": "A256CBC",
              "dig": "SHA2",
              "kid": "EBQF-CT5P-IVA3-WMFN-QFPA-E5BG-T5OK",
              "Salt": "OofkRtmmjHgZeU0pIYGN8g",
              "recipients": [{
                  "kid": "MAUI-GSEW-2MTV-UDDJ-GFJD-R4L4-EEQZ",
                  "epk": {
                    "PublicKeyECDH": {
                      "crv": "X448",
                      "Public": "sh4dMXMG4wpVTEQpiENVh8T-sv2BOAhTnLMbbYKW-vZ5sflAYQ4s
  8anp_lofu2BBIvzoJ_dKSTwA"}},
                  "wmk": "9T7YIfAxqDHeN0QvoehUMU4Bo9UiZy4CpabxuS8o0yefzZZ2HW4F1Q"}]},
            "Rik41wNYxdiaoHrjnLi8Ln3buPL-oF-nx5pefyZSv8vVu_kIylaQpYY
  degfFEFIOArUf1UjO5Ha8wP75E0NGzc22CFXnJTShLoJShq08MIui5RAnMbCdw
  EA4T1Nb445PEwfONcKnMwZefi19jkAxF_aMRnNVhroKO3AG-iXdwGelVBstweJ
  ehv8AdwVcCnqIKUGzSXVWYmQPesuoPgnNr5D-d_sUK4sGGgjW2kCNlEv7P078_
  -nDnNh5AjR8NViyv_y7s9qzRBsHCkwrGS2dm1mG9TAXEuclveLGN0kMEs8Q9Kw
  YVbJVq9lZ4ewGqIxeE3_4iW_gFsISN2BL6flAkKZ6kOMnmgpazE5FxTGKc0mjJ
  DyqPHVevpBMDfPPe5RMJvKdT2-RQg1WJSRSTaJLA8gFyMRDkXWmKgPHV001Ijb
  5XqNMkh5xUVoya-2fwbP-NRt7nsfqOnEwSLdiq6nXqzvIGU0qbuELMAbiqCfQb
  gzvD2SuN2Jl1jvh3kCFNZuiXxcG9frHos0KDQ0HXP4WvlZG6SymeANfbTXTaQf
  DqxS8m6Ez7ytYApdFjxkGR-tpi-rEnI9YfaWm6nb2iWRiqAoUpwSRbqTVl4tKK
  nMulrc9xopSrmbZrVKQkeaBoxiCefVTx-ANwhIxiPzYEkP484nU69_2nAI4Ap_
  e5_Eq2w1_r1GY1lhPTGek44MmJL2Z6_S0rzCCNci6JfaWMiKdoZ9aLLcV8Y3_p
  8txQT_Ba45xtJRPcuL7MQLxQa2C7ni_zZheMCBYG1-YAjbzIey0aKBTEEsA7yX
  Jhbgc4zX5rGgiLmwueuOK83qq4q2cmx9hK_-rrHEBfAJk8b5wONgXMsJo_UN39
  0SnX_-7383DNnpaQIoH-DyLQ2WfxwzQQNWNmtWIPdGfw__RrorDUhGQx9H4DCg
  BwMICzzrbE5YJG1L4FCd2NuUCVGPLCczBRKJdDb5nu2Q5PjEP6w5aPyDjhfW9O
  Djtc5Y03XhRie10lUL4qgvgu_S_r96eT1CwXXMLrX8SLfRHPtG-cjeHClzbgoX
  ljDCtWZMR79fGQTOaFYs3-OfOserMJN503PNtyfifkClpF6XNGsKnrMTCv_la9
  0v3_YgyEAZUmP5zT93mKKauYetS1BU2CrePTOFRuxSob8z_ukv2XDxSfqbvTp7
  gGE2af9dAa20ZLrl8FgwZD9CIifokqP-HxCRLiApCDmigVzFWOHn_Tg_7DMaxp
  luesPgHAb7y6ipizhL3GDb4_U6ScjhdfTAg9XZnG6V716Gf6EUMP-GVwvdB6lb
  CkiOGUbj6DbreGnKUa0SE68Z1uUFJGL0VGCwCjQANoZb_FwY6dpijp97irc0t1
  skNeJ6fIDyPRyvstiUyn3y6Z82dmBn1Ww5A6k9Zvmk33S334i-h88OU5Kn4ZMR
  W7rSdB4UsXNnLjr7UMHaUO-tw9Bo_6Qw2eGgtFJpoSuET298-Bdc4JhPbj0Gnb
  XCHI-jCWE7Zg_wmrWWvLjqvZVTGc5-n5Z0UAUjezZ36gTe7AFt0Ui01AnnUTh9
  RBPv6SNucqD5RA_y9eaa4TDB15AfM8EN4ULmPmChluG8-jBV7jH4s1phkHLoAj
  stpC2JJ-9NrJ7yvfVviix0627ULguc48mlmi9SaxC-_sJVfMxjUj56Uw5MmgoQ
  h_914q8SHUGOrkAyYzQKRVsSAvPoChnIBHnBUvCsVAoaUPCynm-wKmRtqDXkCZ
  W_KUoEGxGXE14v1S6e7Om_Hp191gtFXFFuxg34J8mnLsromVpp5kIfuXWLVOa9
  zAjbH1TxEPsBjG5yRzREcn4S6wVnSyBQO-dnyV8pJf6bQc_Lj4zt0y9w308gEp
  Jl4wBNfHoaYjUgq_ZNvQYOBdrluyjOkIlXtKRZ-dyYc44xD0EkC0v70nDTfHmV
  wsjoqT3uvQTCvH0iSgdHHLBCIkkcRw0QxXdMQADj7wtcMl50nG6iJV9WE5wkwr
  PpSc5xs7B0WZSDwEV1VioZGYYjZ5rcjgyvVZTJliYW4bKqpI_1WBMoIfAGa37D
  VAZuxCPlWyu0pEtZ_kqcfwBf9rnhRnyuQsmqDWZFzyr1G3kO1DTCLmTVSqO0Jj
  pBL8QkVKybxPaM42ZR6DsxLoK3QYp7de_772ZkveIRMM23-WPbg7-tV590x_kb
  7QY0rCosbhd7oJ1_acHiFzJ2ybGhlq72AbxbWJGnhS2Zlelsfn5aukPqTbGws3
  7VZYXgZQjZ8t2b64cXRIk2xFDBbI-oHMlv79yj9hMx9xPjwcprHw-C0CR5VbeZ
  ngJnVPhVu8gRSaRf5O97QSZTogsGxrjHbU5M8ocyFRRlG868oKEwWNRaxh7FfX
  I7cx7-o8f2GbrluLXShjbT3I6m8VevXNZZhymfu9O4PBkzB05N4e0B4HEqbAZA
  1-OUhuQQGcX8zwSYmZzw1rNGua1UWcupkAd3JfNLnHZ8mAzN4VQBWtSIC7pzY4
  WF-3l4PV98HWaSeQAHpJAwCUm0v209Z0lpZK5RsVU7WVf369fawg8ZtDYyy-GD
  _Qq5s0tWIVPqoIzW_TIw6cA0OzbGK-1A6LfmcNHaagijLa77A_EXBFfoyT-6s1
  wYO7gHWzsbAM26Y1osiOFT752Z2nB_LWBMUnbAFX5iaRCz5IeJ0Eeo7EvtGWCy
  0Ocu6cOxr8ZwTWLRYHByOLa5Ic38yXGHD58UwVyf6Jc_GkM12z9QlLgoo4jf24
  jPr7lXWjCWszkiOcgtySzRuLC5CBKwHNi7Sn-_41txNLq3oaAmR6P4SqXjskA9
  W-9TlRq0-l7NLAbcPS0aX53m-zyXH1jh8TPCt9ScOsoh8cXG2XXBNPnE9C3sHl
  IgjMuQMhnMJ0Rm2wonOO6SZCwyE2TIJtLS8djQ9E-L5i5wfRx0d3VFSTLs1u4r
  -YC9I5pKnJTjujh2evbKkVd3eoIApqbyMFvEpezNKFM8sO8DTy5KXxu-usfav9
  IenYUO-Yk1Eiavy0lHTBlSwlwracniIKF-JSOKx",
            {
              "signatures": [{
                  "alg": "SHA2",
                  "kid": "MDO7-B3Y6-JXCO-JPAI-R25D-6KTB-P3MN",
                  "signature": "vWWqD7EM0h7YISaBtUAKU38YIo-qwxn5xvF_-r6uw-oMS5t7y
  N7AxWOUMjZhhz0mqlOm02wHTvcAJOv9YpoAg3WU57Mn4S9thTPs8qEodjJJAe_
  0qcrq3qZ_I8cqj80UOb2TklBVKg2IbAsFh94qpDwA",
                  "witness": "JQT5iQszCMYIqCVIfAFhY53C6LZnuafBWepJPox1CzA"}],
              "PayloadDigest": "JKbdNrw-cGpajEQbJV9OUWLFVaOSB_attlfrRWpImc2QI
  UMPJhWp_IQlut8oc1bFiaEjJVGBydY8yzKXPnO_aw"}]}]},
    "MeshUDF": "MBU4-C4AJ-TGTO-AETP-LQDC-R3L6-VMX7",
    "ProfileMesh": {
      "KeyOfflineSignature": {
        "UDF": "MBU4-C4AJ-TGTO-AETP-LQDC-R3L6-VMX7",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "dn6S5a84biP29zQlTsFq2its58i9YrEjQN3SzmSBsV37KlvJFcft
  Hj1f3toyw3PeMGOGEAc8dTUA"}}},
      "KeysOnlineSignature": [{
          "UDF": "MDN2-AXAJ-3U63-6ITQ-J2D5-CYH5-HMJT",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "-bOwcJF2fpvf58yAd6lINq1df2BEXD62wpY6gQEzrPnsStHdAJ4n
  bQqOzO-o1psF0RDWuDaAvnkA"}}}],
      "KeyEncryption": {
        "UDF": "MBSC-HUCQ-L644-42CT-TYQ7-SPNL-775K",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "X448",
            "Public": "n1FnUufGh7Z8rZwaO4BEEktKxuj4ePqR4RqrywU55mT0fNArBu-s
  6yjJKZnPThHzFr-v7jU_u4oA"}}}}}}
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

**Missing Example***

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

**Missing Example***

