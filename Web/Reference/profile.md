

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
<rsp>Device Profile UDF=MBPL-MIIT-KOHN-FC6P-6V5Y-ZQ4R-3NKY
Personal Profile UDF=MCSC-2POG-PH7T-ODJX-HOCA-B4XY-AFSK
</div>
~~~~

Specifying the /json option returns a result of type ResultCreatePersonal:

~~~~
<div="terminal">
<cmd>Alice> mesh create /json
<rsp>{
  "ResultCreatePersonal": {
    "Success": true,
    "DeviceUDF": "MBPL-MIIT-KOHN-FC6P-6V5Y-ZQ4R-3NKY",
    "CatalogedDevice": {
      "UDF": "MBPL-MIIT-KOHN-FC6P-6V5Y-ZQ4R-3NKY",
      "DeviceUDF": "MCYS-TOQJ-CDAX-EDU7-6EZ3-OLPG-KMLG",
      "EnvelopedProfileDevice": [{
          "dig": "SHA2"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUNZUy1UT1FKLUNEQVgtRURVNy02R
  VozLU9MUEctS01MRyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogIm01NExfakVObURkd0U5dkZlRFpnQnV
  KSGJWM0hUWnhXcjZFcC10VmRRaHVkY3B3MjVyT0IKICB2cDZsNU9oS2JOVWZvS
  1JXRktUUzkzcUEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUNaUC1BTU5PLUpIV1ktWlEyMi1OM1pQLVYyS1ctNTJKRSIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVib
  GljIjogIlctRTFYbU9nanplNG96cmhra2Z0NW5WX1pjcjkwRW45dlQ2V3N3QmU
  zVkJDcnhXUktHSTQKICA4VWQ5RVdTRGxKZkVxUVdSYmhNeVpwMEEifX19LAogI
  CAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1EWU8tWEF
  ISi1SWFQ2LVlPNEotWDdXVi1MM0lXLTVORVAiLAogICAgICAiUHVibGljUGFyY
  W1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJPbEpNczlfR
  GNtN1h1Rnp2YnlwSTVXQzN4TExnUE9qb2hzZzVka3FBNjFnQ2ZzRjlKNHN5CiA
  gcWNabk9GckFzay1wRldGRG0wREVTb0FBIn19fX19",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MCYS-TOQJ-CDAX-EDU7-6EZ3-OLPG-KMLG",
              "signature": "9uexE_-IFBMWisUSR9xLXgJskkYDoYnbXVONBUR0NVP5vC5_N
  2-m4uXUkpN1ClBKcDPhQmX0tk0AjY-xZhrTpdB9GjQmiBSyCGsl5I0VBAhy9og
  TegiNXyYznYw6cukAHrcRH7_h2dFsv2_WFT8OWTEA"}],
          "PayloadDigest": "Eo6k0vBBU9dfLJA0MTEt87qdGpzCMJi4PEFOxE9w5a2Aa
  C3izRZYoobWz0fJ5vjwLEfte-_ggv9wKc8GcITekw"}],
      "EnvelopedConnectionDevice": [{
          "dig": "SHA2"},
        "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQlBMLU1JSVQtS09ITi1GQzZQLTZWNVktW
  lE0Ui0zTktZIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiRC1nNXZpbHNCalpfNkJLUkc5TzNjbDMwSXJ
  OM2hDR056Vk9fQzZZVDVPa09rVkNJTzQ3RgogIFJobzl4ZG9KOHpDY0g5MzhXb
  FREQkxlQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI
  6ICJNQkxZLUtOUUctWVQ2Vi1FTkxKLUtNSVQtTVJZVC1ZT0hRIiwKICAgICAgI
  lB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB
  7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAiYUVlM3UyNGd3TWgteWdZMEhxalZiQnh6RkVZSnlQVmhCX2gxLU1hM0Zfbno
  2QWV2QTBmUwogIE1hSktwckEtcXYtSnBIU3NNQ2JBNzRpQSJ9fX0sCiAgICAiS
  2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTURWVi1RSkU3LVV
  ZUjQtMjRUUS1KSzU0LVFEVFUtQlpGMyIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImN
  ydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogImtWX09Eckx1NGpXZ
  FQwaEppYm5FY3Vqanh1LUU0b2ZSbEk3bzJleXkzZVNiR2FBRUVTMEsKICBZdjV
  OOEJhYXdtV1A2N2F0aEJaWkRqZUEifX19fX0",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MDI7-LMMT-LTJE-6C5Z-AFZN-6OXW-YLW3",
              "signature": "R51-7cQTb4f2nK69t77YamP7ny0i9TOw0CdXl0X3dpvgSiZ2I
  1OWbxncJqqkOpj7AW5e7uiOBumAc0j3tiWXSwKIQZAtoUsGvcYFY2Yq11KOHC9
  kMS4ea2Hcu0IMd8tpoIglnJC38ajl_pFBCbrJVAAA"}],
          "PayloadDigest": "Td9sSenLRJHoZ0YtbwztmpadlzOv2AVb9JtOCgnuiXX1x
  wkuJ5KYAAlOoSusI6pyT1iM6TtYYh0hpCSEooizgg"}],
      "EnvelopedActivationDevice": [{
          "enc": "A256CBC",
          "Salt": "Wv42VzJRlBdLKIqwODqHYg",
          "recipients": [{
              "kid": "MCZP-AMNO-JHWY-ZQ22-N3ZP-V2KW-52JE",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "80ofnf812P3naGy_KG6a1IUAdQKcZ9fF5TKZ8q8yRZsWn870qm1Q
  KgXYxOz82RpWKEqGHGdWEYcA"}},
              "wmk": "_-0e3rNNbEIvH8zjSe1tBz84FEg71dzdhHJnfQvbteecigqMsZaFZA"},
            {
              "kid": "MATS-37J5-26DG-MYUR-7BMU-PPJJ-UUO4",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "Y64tNqhJuEREoAm3pFqXSQqBdbmN7qPhmnKKmwOWhVnVxVvBuRFj
  AwM6HuVpgLa53kK3Ucl7uCsA"}},
              "wmk": "G3nEbaXRHIgdaXcx-DyKXuOA1QXKG-coa4q3urbu6L4bti4cuI5_og"}],
          "ContentMetaData": "ewogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tIn0"},
        "xq7fBwbgcYBrqZgcleQhT92CfS5uLMEO2xAbhr2c4cl
  U0i6tX67Z-sx5opqdMrSDHGuaDUShWce9JhSwBomvs_8un_0V9vhqwV5gSP_fT
  svSU2nnCBT0ziEk19B5z57AsGwAWL9lTa9kX3M6AfF92UIog4vZGTHrJ_m1yLJ
  c_etVBAeL4GF_M9_LSZ4zjfeZZGSwOBwQKGSWGqCfEdWRec0OZ_q4WUg3Fh6Ny
  rdG8kaUwkF3EYgfBhN2OyLQ7oHybuQs-J2w_m_ev79C-o0eUYz8TJQTLeYpQb3
  cFmXkD71BLqBn0nWBp4BeR73UMWooNv1OkyHw9HXmreaDeCOeWWqZsfNqE47xv
  NX1DWbwlxBYMJLqoz3y_XUSTaQFJqa1suX_c7ZhtbXDVEWyDFBOayf64r68LDb
  AI-1yVEpcBF8h9XwBvZnGXyC5iUzFGCL0WYMlH1oC8JU8rG3kp12pDhaGR0V8O
  HJ6C_AL1mk2Wm39XqZFOTjIy7KJM69EN-U4MNx-ph8Pil78inOTcfUCNffepP5
  XGbeNO0pse1Og35eiGnZFLf9yRB_iZtQwJmMsEZ0psW8qXp7vnYd2Qk5vwAmiz
  YqRZ7oViTVotGHHgvNRTliuJgmTGHRlYYUxlsH3lUxDv5UHJzSBKiXK5g4a3Vf
  5I10qaFLi2V0Gh3P-MkEXyvrcRGZVkix8K6mLYIVzZuesklhJ28M-WlattxnV4
  Kdjd_0Q85HZLoKlsJryf7VUDBzfrtpoCKH19r2BWBLCC-HlsTxNN0CArNk_Lt7
  FXxuAuKnB0jAPOmZhjbP2W13gP6B3IsTZQon9EGgEEWLwThyGZmh3DwTQscUUc
  0tz5Gu5KywANKqXpjbhrPS-vRPogByOLAa2u_gzeCuSq6RqTva0-dCgbgFMkqZ
  ic25BqO9BpmTmnLKTOumhGhKA2r2aNfhMeQp12wpH3zLfNsYHwTUwQj--KJCRg
  RlYt6lVBs-9U8BEgcWI_bThDod3d-CNuU7A0IveifojNeUScA9UniJPjympL1P
  Q953B46-nb8Y7LodudjuEbbmJxcTzlg6Rao66oMo0rGDeEyxb0RaYPQ41gKqAi
  1MMbBc80flGgxdlN4nGPYXtyQBCZQJ0Rlk-1nWujdf6LoCBg_-dpteR54N9o_M
  c-aNsPi_FpdSVrGweQp6HpoQuwpXOncHyMG257iCxZN0Fev-nviLkXn8JA_iJ7
  2vvJzHZMHJ33XOhFlbvwDIN5g4Drn448i0t9u_G5n--3kN9nt916fUFM6tq"],
      "Accounts": [{
          "AccountUDF": "MC23-X3CT-EUNB-DR3M-QIBI-W2IJ-ATEP",
          "EnvelopedProfileAccount": [{
              "dig": "SHA2"},
            "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1DMjMtWDNDVC1FVU5CLURSM00tU
  UlCSS1XMklKLUFURVAiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICI5dXBQMWlhazMwX0pyRzFwZVl3aGt
  UMDBEcHc4SjBqd0dRQTBuZWhuQlZQdU9hRzloNlNzCiAgRmUwRGV6MmIzYVFwb
  GRBR1VLb1VCZENBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1DUlItSkZMWi1UMkpILUlOR0QtU0JZRi1OTzZYL
  TU1Uk4iLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogIkZfTUpmMHc4ZFVIaVBZeTk3WEtRbXB
  mRlZMbk5uZHNqUUg1cDFjM3ozSGxucVRhMmE3YkUKICBVQ09veGE0SEFpc2Y5Q
  nFueEpFZE9tZ0EifX19XSwKICAgICJNZXNoUHJvZmlsZVVERiI6ICJNQ1NDLTJ
  QT0ctUEg3VC1PREpYLUhPQ0EtQjRYWS1BRlNLIiwKICAgICJLZXlFbmNyeXB0a
  W9uIjogewogICAgICAiVURGIjogIk1CV1ktSUlLWS1WT0I1LUJYSVAtRElYWC1
  SNFRILVpJRjIiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAo
  gICAgICAgICAgIlB1YmxpYyI6ICJzd3BlNkg1eWlVNHZKb3Rib1hiRnd3SUVwX
  2xYTy1rYm05emo5UE9GTEx3ZnFlNkJVTXN1CiAgOUZCQ0w2R0hwOTN3Y21MTTI
  3dEdSbjRBIn19fX19",
            {
              "signatures": [{
                  "alg": "SHA2",
                  "kid": "MC23-X3CT-EUNB-DR3M-QIBI-W2IJ-ATEP",
                  "signature": "xBUh419PqcBn2XAGToSaPRxDiUJSEABsZubx-zOaEqZsotZce
  YNIj6h2axaL0ZsJAwO3vPNCgCOAbX6LLqeJk4qheJ5FLmZ53_T66gDPqaTIE0N
  hFp8ulQuDE0aAvU0eH7vPV1HhqUMaQMc-lZGPQCUA"}],
              "PayloadDigest": "aXMNPb2KrzIznCZVP28IrDLCOsVirh1Oy_VRZcsqX0Y3J
  MuCTXOJ8BpIMc_bjer2T8a4m0e5SzYoRe4S-gXP6w"}],
          "EnvelopedConnectionAccount": [{
              "dig": "SHA2"},
            "ewogICJDb25uZWN0aW9uQWNjb3VudCI6IHsKICAgICJTdWJqZWN0VUR
  GIjogIk1DWkwtTVFPQS1YTFlVLVJMUFctVlJSSC02VUZELUtESUUiLAogICAgI
  kF1dGhvcml0eVVERiI6ICJNQzIzLVgzQ1QtRVVOQi1EUjNNLVFJQkktVzJJSi1
  BVEVQIiwKICAgICJLZXlTaWduYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUNaT
  C1NUU9BLVhMWVUtUkxQVy1WUlJILTZVRkQtS0RJRSIsCiAgICAgICJQdWJsaWN
  QYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgI
  CAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogImFDdnl
  mT2d1YVlBRm5XeTlfNXJYdy1rY0U0NWtNWGsyWGRtMkt0VWVWSjhnVkpTakQwZ
  HIKICBMUzZpQ3J4SFBWdUlhb0lGNW84UWhnVUEifX19LAogICAgIktleUF1dGh
  lbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1DTDQtS1JCNC1QTVROLTNDT
  EktVVBGWi1NVjJaLTZUVUciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJpR0Y0X19vRk9PWVotVm5QZHF
  oQlZ4bEVpTEF4UllQRnNRLVlxclVJdTVlbXlFcjRXUlBMCiAgLTl6M2VMMmQ5S
  XgwSm9raUI3RUYyRm9BIn19fX19",
            {
              "signatures": [{
                  "alg": "SHA2",
                  "kid": "MCRR-JFLZ-T2JH-INGD-SBYF-NO6X-55RN",
                  "signature": "DXZyUQa06ki6HuDtd7ooofkLlX6_d341Gq0YD83sLOVFcKwP-
  C12JWOBRcp_iVdd_tlx94nkrqWAH9ZI6__XrfavdqFWbrkl9kLCQi5mpisnx9z
  xOTZ_0a_kE7KAnjl7SoSV5G7Z9MqlWhZ1OVCmyR0A"}],
              "PayloadDigest": "eKZx9Y5JQGXuaXE1o1BfwSqeDRX0h4VYUWZZIT_wFfh39
  1cZxAp3x5GSiex1vMw4oy_I1oKLC7QdKxthACTz2Q"}],
          "EnvelopedActivationAccount": [{
              "dig": "SHA2"},
            "ewogICJBY3RpdmF0aW9uQWNjb3VudCI6IHsKICAgICJBY2NvdW50VUR
  GIjogIk1DMjMtWDNDVC1FVU5CLURSM00tUUlCSS1XMklKLUFURVAiLAogICAgI
  ktleUVuY3J5cHRpb24iOiB7CiAgICAgICJVREYiOiAiTUNDQS00WTM3LU5SR0w
  tQkVKUy1ENDdaLTRQSVotVlNDTiIsCiAgICAgICJCYXNlVURGIjogIk1DWlAtQ
  U1OTy1KSFdZLVpRMjItTjNaUC1WMktXLTUySkUiLAogICAgICAiT3ZlcmxheSI
  6IHsKICAgICAgICAiUHJpdmF0ZUtleUVDREgiOiB7CiAgICAgICAgICAiY3J2I
  jogIkVkNDQ4IiwKICAgICAgICAgICJQcml2YXRlIjogIkozX0cyYkxmcjhkRkR
  aSDRnYjNQc0dwVTE0T0VjMmJib3YtdDFJOTR4WDJaQmVOWGN6TQogIFFDdGVYW
  DNsNnNrQm1TejA0S2VKd2phVSJ9fX0sCiAgICAiS2V5QXV0aGVudGljYXRpb24
  iOiB7CiAgICAgICJVREYiOiAiTUNMNC1LUkI0LVBNVE4tM0NMSS1VUEZaLU1WM
  lotNlRVRyIsCiAgICAgICJCYXNlVURGIjogIk1EWU8tWEFISi1SWFQ2LVlPNEo
  tWDdXVi1MM0lXLTVORVAiLAogICAgICAiT3ZlcmxheSI6IHsKICAgICAgICAiU
  HJpdmF0ZUtleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICA
  gICAgICAgICJQcml2YXRlIjogIk9OUE5BMlVuSXNEYnljcGl4YXkzZ3JGenh5T
  241dmk4bTNnV1lxUGFsVG9YRHljUlQ2UwogIFRNNXZETjZXR0M3VC1ncDNhbnZ
  WT3VGayJ9fX0sCiAgICAiS2V5U2lnbmF0dXJlIjogewogICAgICAiVURGIjogI
  k1DWkwtTVFPQS1YTFlVLVJMUFctVlJSSC02VUZELUtESUUiLAogICAgICAiQmF
  zZVVERiI6ICJNQ1lTLVRPUUotQ0RBWC1FRFU3LTZFWjMtT0xQRy1LTUxHIiwKI
  CAgICAgIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjogewo
  gICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0ZSI6I
  CJPZ0pSOEJZWXpKTGNqRVJrVzVYY2x0OUsyWUhhaHVVZzROQkRKWHNjVWtLQTR
  IWVYzN0wKICByWE1nbDVpNmVHZTh5SG9TWVcwRlRWcFkifX19fX0",
            {
              "signatures": [{
                  "alg": "SHA2",
                  "kid": "MCRR-JFLZ-T2JH-INGD-SBYF-NO6X-55RN",
                  "signature": "DG3O45F_0CUD9TEOKgkLtRK1BZDqWey5JO3Kt6foye8lvR13l
  6P6UnieF9jDNO0WQY-yPI4LjyuAVNSZWi97IF4M--zrduv7ZpjCthksLnlQvH-
  oYIfGb-dZfAOza6B7zvgU6IbxPWWWCo4zQOj6qBkA"}],
              "PayloadDigest": "4pwNPnQPWuciKHFFtXv7zXN7MN4bEsRJ78KmRG8F3cR5p
  K32CcQ-aI5-qF2yL_gL8hJuU6S04mPpZEpE_acOWg"}]}]},
    "MeshUDF": "MCSC-2POG-PH7T-ODJX-HOCA-B4XY-AFSK",
    "ProfileMesh": {
      "KeyOfflineSignature": {
        "UDF": "MCSC-2POG-PH7T-ODJX-HOCA-B4XY-AFSK",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "AqOm-eLsUPySPkemMvVIJctXUSTa6EC5c_w0kLHZCh4xLlFow4SJ
  zsDj2xSX5ofUl1XcuCBj9qaA"}}},
      "KeysOnlineSignature": [{
          "UDF": "MDI7-LMMT-LTJE-6C5Z-AFZN-6OXW-YLW3",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "tQhM2lUiBnKgk9PASigebdZH18nDC4qFSZIJgmwTPYrpdAKsSnuZ
  PH7UPu3AtYjFF8aGMyyF8UuA"}}}],
      "KeyEncryption": {
        "UDF": "MATS-37J5-26DG-MYUR-7BMU-PPJJ-UUO4",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "SUJNzpDLHT9dxOyYdzfuhPL0mkR1tw-JTjuIVgU7X-bFqi2z66ef
  Qv1cwSeVL-oZn2COpIHN-lKA"}}}}}}
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
<rsp>ERROR - The cryptographic provider does not permit export of the private key parameters
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> mesh escrow /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The cryptographic provider does not permit export of the private key parameters"}}
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
<cmd>Alice> mesh recover $TBS $TBS /verify
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> mesh recover $TBS $TBS /verify /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
</div>
~~~~


