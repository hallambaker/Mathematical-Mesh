
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NCOX-ITA4-CTSX-4DFO-SART-TSLC-354Z",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQG-ZKB5-KVJL-4LOX-3H4P-JJDE-424H",
    "ServiceAuthenticate":"ADZF-XWOD-ZH7K-LMRN-5UTR-3GCL-UNRX",
    "DeviceAuthenticate":"ABTD-5M7V-2QT7-4E76-I6VO-IA5Y-3NQ5"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MBNJ-NL3R-CCP4-57H3-PY3X-NLH5-MZV4",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ09YLUlUQTQtQ1
  RTWC00REZPLVNBUlQtVFNMQy0zNTRaIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMTItMTlUMTk6MjE6MjRaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5DT1
  gtSVRBNC1DVFNYLTRERk8tU0FSVC1UU0xDLTM1NFoiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUctWktCNS1LVkpMLTRMT
  1gtM0g0UC1KSkRFLTQyNEgiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  RaRi1YV09ELVpIN0stTE1STi01VVRSLTNHQ0wtVU5SWCIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFCVEQtNU03Vi0yUVQ3LTRFNzYtSTZWTy1JQTVZLTNOUTUi
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAOO-H5MB-HWN6-4CSS-SJF3-6RDL-KD2M",
            "signature":"0wQI3VBmywZaMDligeObVXg7KUtc1yeYWGsHVyWn
  Xk1A-m7FJXaMZurxgmdbqd3k9gVmNy-HLLEAYZ1O2RijYp7Y9DQKcitXxehGQtWoz
  NfzhFtSqV1lVTScIoLv0a0iEyeHHz-nrab4ONGAIEEuoCwA"}
          ],
        "PayloadDigest":"6SLWJ6pnM1-PhGPNxTFlOXRuE3WnH-upYxTptX5s
  GO1WGil4PgYjp01FR7S2Bps08vfZfzdju-twLoi7bAT0sA"}
      ]}}
~~~~


The publication is found and the claim is accepted, the publication  is returned
in the response.


~~~~
{
  "ClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "CatalogedPublication":{
      "Id":"EBQG-ZKB5-KVJL-4LOX-3H4P-JJDE-424H",
      "Authenticator":"EBP2-XGRF-FFKU-WUFJ-RUSP-U6JP-C6HK-UXBC-M6YK
-7G4W-2JHL-FL4Z-PZFJ-C",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQC-G2IT-LUFM-UUNA-266J-MAYV-PXX7",
          "Salt":"S8wNLXB1-zy4peaXHuue3w",
          "recipients":[{
              "kid":"EBQG-ZKB5-KVJL-4LOX-3H4P-JJDE-424H",
              "wmk":"8cELZdPn4BSa6yH-y8wnEqPeFbrhhg1TyTYz5jaO4ENj
  ziveCjfyIQ"}
            ]},
        "xifEZn3AifQCuJq9WylQXy6Afdz852x0sou-aaD7NQBabbVsnWYg0tJi
  cchuwyO_6jx6C5Tv8k6_YV4m2Kb9uYKSYosOakT28hAWtg_FeThM80qIWlWpg4SGK
  vQqI32hXi6OySaXOJzl_i71S1iCznRIr_oAR1qJmFQQQxOTC2lNbUQ6IN5LT5acYZ
  XclCvOHofug_EDhA_ZWngvTor71UPbYQvDsuEjP6jMNBNnT6xC99KXquBHx2uhG0O
  -fP_eKjKcRGYdgzZj_LldeILX1hvPmf5X9PYZf1xZZCyZUITFKatV9TAW8s9R_gtV
  7Erca-dDbVSfex2amf_BJ10745ZOV-cKVrIKaqmLIlTy_DawCpE65fFkgiN-JPudN
  7Oak1IU31YqvyCPrGrBNjfMEjxpqeP0vFoLZm4mpxWbc4Fxcsj2Kl42vd0TwUAgNF
  lreaG8FpmlBtN4n_Z4CqzGQWLJURTA9sbC4fhz2haaUKAOm0OZAzRN62x33puOvOM
  AScs6XU81NZiTlCAU7oXM7VyiaJna1K6QPBiNPDQUJpFhibDCUtfD8EZieBJPDFpJ
  pXHdavBbIA8UVrYpe1c1mZD91Z-R-p-69WqTzTUNIuRGm3mqyTKKa1VW4m9jnLW_d
  56YcXXW4Ayw1MSFWZ1FZjsItsLawBFp6afkCdwWTmT-iZ3lT2KecZINylDgeqFRcG
  XYoJYnNtk4zyJUBnZSd0EZHMRpn-v7dm9Vll2pnAyR21D2lo7e0w9hLAi19XWl_RR
  pNZFhuzVeGbJfZi6FXrzsP_12PNeK5qXJF33SRfVcd-2vCKj8__Hk_wb2yOMGa8ND
  gaMSuTUhiQXk5zNu_9coJOvVGU38LNZgJBZvttI8JcR0Tc3TJ6UaNRLpO-wiQhio0
  OLwpXUihp0wv-gkNkCl6Q4iwi6EXOettTcj3CqRPRohFDOHezof9wOWAwFgSIoECj
  pnCBZSxaWgW3eAPaKutSofrvVzheS-ZV0vabB6avV4pZmVDiC1iHFBtTauNXd5AFg
  lGvG5TS5Apnr8shG0rw5n1ICin3nufPtt9_gnYma_8syOykJgQpVVTpUFlFf_KMHu
  v-zRj2dZMMUKMp_tFPSi4rN-QSo8FdfL_GInt6SC_RgL1r2Vo7-U8WCduHYqg9V2o
  GMniNaKzcfy2TrG9DzVL-7ptKZpMIEomhbd1XX38Vryw1GaCJEfRix8xp8PGedAjR
  27SDPy3SrB8PthHY6MDVsjYx1HKgAqb90WDxUGl3CG952imgF6cP0nFA_nVbg3qKr
  rCAV5fyzEzM8P4aq7NwG_wVhwGK3HYJrkE9TLQO-Amy29iHbHRr4xeQBpfaKMvs-N
  S83vifuZ5a-T2RLj5XI7TuReTR-ZtNULEPrlySw_GTuRKGIN-WAgVZZgVNi9wpsbi
  pOLkCdpKQ6es1IBRnqpIu-w5m55LFu_eUzmVf-dE3_RzUh82duNeGYqO5fNb1X_ty
  EWAm87oGjCQIKlgD5h5k-3AVa3vFBFT9oiCzlum_FwtwlHi4brlGTZg_Z0S4FAB6T
  XV3X2I2gbQ4T15BsAcHTuDWooi_b_UPaYTX2fWmiElWOWhfmdgKk3JCTMuErNHaL5
  y6Bs1p4ShgZz54-H5BnZzlxSmIZheyviAwR6m9a9w--3noRfpVUZCx9ENHZCQLugU
  iSYYBfznijlZIcCc8jo8IlDcdz2GuPzBPS8RV4VVIagjXg13g4Zb-iHEK6XEo9t0T
  5RYrd_5cP8PbmnBdkWKN6jCWhiGyb70qHkvBXGS8D8reLyR-DM7xg4lGPUuqJ3s10
  BgoUPWplSF2N9zlPdNoBVEHPRQgEGgTKfYeeJPherknYP829aWAWoP2udkCfEuF_q
  FJyWnWjdridewLF-itcu3qzC7Qh5UNKaRfg0NLKsiOEvLNm2CS6bhBc2FOifwQ7zy
  gxX8QTAD5xH3SXpjBGfvOiaMxCQ3AWCudTQyJQDkM6CHmJYkG383nWKu2jnbKY6NJ
  JZGO2vNcmt-u-t6pI8_xFiR5sqXubZQuvWWCDZ5ZHX4_7_1LOOE9aULv-g4FSN0_6
  0rCBR2MR4ATXqriltw-9Buqs_r6lWlmP2M4_D8POwPUb_8YkCHH4d5yKYQbgjxD9O
  dyUtlZSnNJmiWQKYQRSPirNplYw2pdf_O8WFEdjpO8GzVAbdGQ0Pj8arjDhR4_TfH
  EHo0L2aWeY3a1sEcu1Us2NRL5-4wAwKKt_B4I1v_cyZdSImoBR9cIW4hec5u_ZYxn
  jWg6HdWIt1NErH7UU2eHHzc9BhMXp2dg5jaebFrbTX0SUxGCHeLvW-J8uUdzgq5SF
  uN2IuC0ZM0wFT-tFDlh7oZfysUh0t7kNNuManX6qo4AnU4kfYXBL6H2YVUW-kjB10
  SnizLWVG0wuhfbNSs-h30Z2ea4ecr-J0Yd1nncWyoQdr8DGOWbccTj9PfKyXGPQZh
  8ExAM8nIRm06-u2iJJDrQdEqo-SRu2cPS5PoHo4HU0_CZ5Lpszhay2N_UE4GwavR9
  qyypVAuV4EqrEXrHJpg7C8RPYn8dmY162-ZqTNvl3hrqtZbgdPSLK_o4YKS_a55x3
  rA_rrv8FLnzz2b3odpp5lOW1mSOkFMTVxhMluaRxv_W1XIPTtUUZ3XIj-etJuJumB
  m7RQIGapLkrn6wPT47twtdFMCOBlRC-LFMcUiEolhVBxqm-ZGFATHLNhEXly0S9o2
  uZu5IZoJquov235F9Hmnz8dIMVznM32f9gMc1WNy1hOSHfxr3bZEL4bItn9Rtrwrq
  x87E64ZJzyL_iz-aLMOo7BV4wbFoaGAM6Wzlyjdnxopq3lT79f6zEQRpNDeWQo5sH
  wAPCCvot6dbBgOLBJvmsb3eo38jYhOqkQ1Oxm4mNDqar-1gvIbEyJd4Z3YNuuNawb
  nKfi_XwvLsvPreFH9wkyidk2fGKitm1bo_udGoGW7v6HVohYIuohMuvanzxTIF4EZ
  ZfKp3OErJl-xTXA-zYDMHn6V5Q1ztvK6FVAThxvbhwejqvHtg"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

