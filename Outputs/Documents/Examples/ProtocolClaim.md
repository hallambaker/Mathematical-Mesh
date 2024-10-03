
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "PublicationId":"EBQG-BJ6S-I2CP-QN45-AW7N-TYDI-ELOL",
    "ServiceAuthenticate":"ACPQ-BXBY-JORR-BQ2O-F7RC-BOE5-H6BE",
    "DeviceAuthenticate":"ADGR-X7UK-ORQQ-UH6G-W5PQ-C6OM-2KCW",
    "MessageId":"NCST-GHFL-V3AY-XQLA-OW2J-TXL4-FVWH",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MCA6-EK5S-B36N-7LAS-L2GF-V6LL-53QJ",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ1NULUdIRkwtVj
  NBWS1YUUxBLU9XMkotVFhMNC1GVldIIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjQtMTAtMDNUMTQ6NTc6MTVaIn0",
        "dig":"S512"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiUHVibGljYXRpb25JZCI6IC
  JFQlFHLUJKNlMtSTJDUC1RTjQ1LUFXN04tVFlESS1FTE9MIiwKICAgICJTZXJ2aWN
  lQXV0aGVudGljYXRlIjogIkFDUFEtQlhCWS1KT1JSLUJRMk8tRjdSQy1CT0U1LUg2
  QkUiLAogICAgIkRldmljZUF1dGhlbnRpY2F0ZSI6ICJBREdSLVg3VUstT1JRUS1VS
  DZHLVc1UFEtQzZPTS0yS0NXIiwKICAgICJNZXNzYWdlSWQiOiAiTkNTVC1HSEZMLV
  YzQVktWFFMQS1PVzJKLVRYTDQtRlZXSCIsCiAgICAiU2VuZGVyIjogImFsaWNlQGV
  4YW1wbGUuY29tIiwKICAgICJSZWNpcGllbnQiOiAibWFrZXJAZXhhbXBsZS5jb20i
  fX0",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MDSC-FB3G-FEPA-PXO3-MFLY-W5LR-WOBU",
            "signature":"RAzOknqZjiSFxI6sEPnrlPGAyH2tTwubV130YeGQ
  M3reHzeanS0tF5OEo_wegzm68sweXNAOcrWAmSCvUV2uwa4G1U6PGOl0dMMGqQV-p
  NJCpJ3oFsNTna1vcT4QltY15Ulgg9sI9rtEswKYT3LACRMA"}
          ],
        "PayloadDigest":"Jrdavuyp_J-l14_gKvK5nJungb2pvr5xG_ss44cH
  tpOJLw8pL7mWhE2cDc8DjMbeReGcnCilHJICxJbitoLhSQ"}
      ]}}
~~~~


The publication is found and the claim is accepted, the publication  is returned
in the response.


~~~~
{
  "ClaimResponse":{
    "CatalogedPublication":{
      "Id":"EBQG-BJ6S-I2CP-QN45-AW7N-TYDI-ELOL",
      "Authenticator":"EAAK-HJ32-DLCD-2I3E-WOMA-SK5R-P2ZH-BDBC-22ZW
-53XK-INIE-O5UG-4IX2-A",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQO-LB7W-2C4O-SMDQ-DUA2-NYTB-X3YH",
          "Salt":"AFllHT2LMn7f5J_GPgh_zQ",
          "recipients":[{
              "kid":"EBQG-BJ6S-I2CP-QN45-AW7N-TYDI-ELOL",
              "wmk":"L2Vx6c6hOq5Ce5F_XIXy-JgFId5eDp8fiTD4-6CTFuvs
  qAYqama4Qg"}
            ]},
        "j6-uN6NmJnAgYQaIpQJuAQQDEanQVt5wZ8UAKh5X5xqDynR7Q21sOct6
  SfMa_XxSZA2yNmQeTT_3XTIvjp1RGiTpehYr_l0I5UYX3trQXwkjHfFTIdJwRQpQO
  skPxrCCRND5K-EhrBiuZR1-wYXlWQOEm6mv2cG1BmX7g_3NGYrRTFpevPjhM7oZky
  ZgsKeSllOHLIOm4oPN6yMqc-nks8YjHDNlImZbbkaDeilMI5Eb5l3buvRo6YHs6pW
  Ii-YMMGbMLOcb0qtwTkKj1Toy6S6UqHIBkLzwoSuf8bTjBlzpZQ5Fzy0o2tT_0dhl
  nn-Y-4KI8c4FANaN7WTgdLHtVu6UmcxIxSJqunEDePSBym9qF5mGGjElr7rhl-DUk
  sZhk8zEhJmh9tJoOA5Tv7Y4_psebZwdJiNXw0iTqUyyQXmeN3zX5CEn-Gbe88ANst
  dyCHOKwtplZKWOULOocXFRmPN9DIFzBtJsM5Dj8wnY5yQH7c_g768FEf4AotpY0Nd
  rr0o_bJzj78PyDRl0g0DikGQzRltibXniORmUC0IzKwZT0zc6zj034Q8_j1Jc4elG
  ygwBbPHsP9tuXGSqvhbHmDBGbGK1Eq10jxo95dQd81Ho-9rcMzGRSOFmV1XO4Ipvu
  _CPDwTRzHVwVkgUWytbsFAHMLlslN8lJah3daBpADJHKC4W8Huni4Z88bUucga66L
  hDATmUPOcM8r7HdMz5ijIuh-CTe91Evbhk0rP2osAaaW9o3tEq8UpXShFK3nPR3pf
  oUdGxttQ4puNRS8s18inOwrQeme9tnkmYkbwpMs8YdS6urce7j8RayR60qxLw4q64
  wMTbsSSkzCMFfPtj3C3jowNf6G0ceDWqdUNevLKxaXPFPNoWnpr830qCvTq8vOnUn
  9v2eVk5ngLO9Q2pZJJAd2gjnUc2R17X1yKxIcF49z9B2WIxkKPDFTmBSShMvLAWNH
  ZXlMNZZmkK7cuOnxyUwUdZU0MbpV-TNx9iY31kQqErORM9a1TDT926tUujDHw4WKv
  9fkgyte4MFCLpasagrNGH8_9jIFOqcVo-0KM9SeUGXRIWcsAGi7KKrmALoGKOavts
  Q7yFHvP_DBKaHcPbZmyVcwf16ZQYrY3CBim-2qsWKGEMtFUKTF6v5yQFxcSUvqCBX
  LBN6sghypN0l207mV93Ss7fSUSXVKb5p_OH0wPCXm3Wl8x2Q6KOd9LAT6oP5muzLH
  KhFltgM-AQamxF8ioYpcT6LT6CF-trt5fUkVJaE0cC7UUG6OuNz-tK-HIOxncey3o
  RU5nc5uqXy6v-RyiSMqq4l1I-6OBQc3n6IaV5XBvQ1pCt9YwEWw0ZAAL1RmzL1vVu
  kkPftnrkhoSdtIPBvXDNCG4zadfZFd89f_nIdE_xMqiEJbQoNGvIiONpbWFR5gLE8
  ozE_25rwAuiKM5At6lvnFnaMLGteHbLkXguDOvdROK68mpI_WBtm1ZPKGaHozYltY
  dWHypfQVm8feEHBZNBb-6jA7sNMDN8_CsuOJ78wyHWMuIIX6KAFf5GnlukdkJaHZU
  Fmh9cv0a2EdVxuUdM3WffXiRr1M8nsDdg4M1NLdsGLafx6DOs9gObdmAYrkJQ2eNf
  88xBESQ1w03h83-n29vBVovYX0e-TUKsVdy8CIctSgLKZWShTodPHJEKTIrGlnjgM
  BMREBbPHRc9ogzNuIzSVJvPw4NaSLujGG67G-B_4GLd-phVQKMw4VGyQVkElSZzYR
  TGZROT1KH0rkBsCKsvLKn1lEsBRsfYAvbsijtj9e6NyiuFrsEByGFALmUvCfZjj1k
  9V7RRdGCelL76ELw8wfdAZfWRrO58KLg0cXUcHVQlN0bFDXEnvQh1hJMyKgmOrQHd
  WKmgEO53GavqQO_3iNVT02AUhyYxYt9YumC4YkkVSpNBIGgLmEJQXPdRs9Gbtmcq_
  bnjFt7GjR2XsRPyRnoXaodlnnrOZVD0ppvfGMWo1Sq6gZlvD4q609m8hw6OeZ91Tt
  ByVEe9seytM-j63cTFttyfA9-7Ou88J4jmdtOlkwIPSB2-JdjAzhHuKPyeXJ9M6ho
  SNq3Haz9gZQPFgkn0HX5KeTq9PwlqTxkl2QGwHx_U1FLWoa6hEdNHlCO1A2XFM4T2
  suwuBQ0AkMm6_sN4DYf5vqoYIIWj9eKN_M06O0SOvbvl0NkLmvtHwM7eTKpnUjqvN
  9BHU9LUHBeKLWBjXUu7q5H_KHaMhvlxq6QNrh073HEMG2ZbX9KmnmRxGl5UxwbC26
  2hiehnDDMO05NXuNy3kbU6xxuz2N30X82wBN65ooYMWD4hRcYBiFHy3TJdhQ9QGlP
  htp8742DEHEF5tYU0WcJl6amXroI3SmtVort-quoCA_dWThhDjNJgWSzUxoRPnqrK
  DrQSsNjF2g_aFK0KXTZOA1B5bvEeobyzMfBG23i3ike9jk3YqVFGwtwAK4HLKRrVH
  O-BqsvAEAxqL_Sd-v6m8G1tSTNLEM3PMHrXRuwXjhT4aCSzG86naJ3B6xqC7l9aTP
  xMvh2W1QQhfDDD3nV_3TVqFRCqM3_k3tGKnSz17tTGLEk2NVnuNSaC9rlJOO1Tyn6
  N8C5HKK-eMq4LNvxaet5l217RF-rhKwDLLwY_FadNFN8a0Oq0etORsTMzeC3NMr7q
  EEOamK9u8AUttUR7LNo3fwA26b6PtgTvA64uqgdQfbgPjk6RcRQRfEznLwCsrasiy
  JdlWUEDsljaFOpetQxFe6NvCMmA3qTF1rm2t-0xwZ0H1HXoB-V-vmqOoef4Qq1XOR
  45M8jPE8f8339cjJQo6zZG3cFbdr6t-Nk9eZy_6iABgzeJREBIPp4Kd5CbzLztRdb
  xkQvE5jrh3aZQi6QdoFCQNuB_YIs9MVrFw8fBtseHVewDD0Xo63N0dHqY-SX6z0hr
  JQkIuLMiv3WSKtZmqgLcSn_Z8RA7k_m7dKzbDw3tuyu3VqdYK0LqrEfq-GgRtop-n
  eOXUmPGD9SSgUC5w5vhjPhUyk1r"
        ]},
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

