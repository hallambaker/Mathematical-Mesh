>>>> Unfinished ProtocolClaim




A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NDSA-BNV7-2KZC-CNUL-YNBR-BHZD-OCFJ",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQD-PLUZ-H4AM-JCPY-X6G3-MGJL-YR5G",
    "ServiceAuthenticate":"AAOG-JEWB-VPC3-DR2V-3YZD-Q2UM-A5X5",
    "DeviceAuthenticate":"ACUB-W2OA-XDRO-THJ4-4NUQ-7TRE-S4VZ"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MAD7-RNJU-LVLS-3EKC-LNTD-WIQR-A3VX",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORFNBLUJOVjctMk
  taQy1DTlVMLVlOQlItQkhaRC1PQ0ZKIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTZUMjM6NDg6MzBaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5EU0
  EtQk5WNy0yS1pDLUNOVUwtWU5CUi1CSFpELU9DRkoiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUQtUExVWi1INEFNLUpDU
  FktWDZHMy1NR0pMLVlSNUciLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  FPRy1KRVdCLVZQQzMtRFIyVi0zWVpELVEyVU0tQTVYNSIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFDVUItVzJPQS1YRFJPLVRISjQtNE5VUS03VFJFLVM0Vloi
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBXG-VVRY-O32J-UCO7-V5HO-VG4S-SBNU",
            "signature":"HSsDPntePMFk2Lo5hWmn7jwKtEl_3s3EkhaEBPlX
  HyQnBMKXKOmLkMIpilyUNaNSiVxRZyw7ZkGAoOqg0-3HFFSYAIRs0hhK1X0GH4xlq
  4UwJ05K8dc8x4GsjxDZbIdEJIhuuuBZYaVc6SYonNjP-AQA"}
          ],
        "PayloadDigest":"OCx9mZqjpsDSJ_-CepsTlNlLwQHFnvxlCEmlu8Kh
  qXuCDbKf6vYU7pknml0y-WS-UYn3a_z_Y-mCvLOjdla0SA"}
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
      "Id":"EBQD-PLUZ-H4AM-JCPY-X6G3-MGJL-YR5G",
      "Authenticator":"EDY3-MOAA-INK3-PSQK-FYY7-67XK-2OKG-D4ED-5FL7
-PQVL-5TZS-XJ6L-PJ5K-4",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQF-MW5C-C2WX-ZM3J-I2NJ-46N4-Q5EN",
          "Salt":"9j1K1_3xye0tb-kcMvy1Rg",
          "recipients":[{
              "kid":"EBQD-PLUZ-H4AM-JCPY-X6G3-MGJL-YR5G",
              "wmk":"-n1aAn9sRc3ENv3fqIRA0NAKp2USdDdVqYcJRZfCvZXv
  OPo933iPxQ"}
            ]},
        "D4CiqvQIPQkCHgrrYyX9f9w0X8mMSphXon0EPxbdp8YFyNnUiDrKkDnG
  XuhKd6cfAyUvQYX6cpb8H0ddZ5SzwH8raWTzrtARlB-gI7uAiYV5ENNKs7y8SSgvM
  srQUi8CaXbw7sQ_c9oGPSxy1zf-P4Cy5p1UQ2abqfWVSw5D8VJWP6iyCRugIzYMJS
  TYMWvr6mUZmpMHG1S3d_XBf_5R4hG_B0umLknZgMrfHNobG5gmNDrK21daRv77h9t
  CyuKtC4fQJFiWh_BHBfkaxsmAABEqHujcoapGZGpSps7GmBaxlRs6juYdOWpZiLjE
  k06K-aEXjaj840iNbxN4ykNS5OCenFC1JcPJgt3-yzriob7t4O4W9I55eRZIm5C_I
  vrj9CtDHfc5hYNmNolQ0j04ktWZff1w6ukdKUjTfAeocWOS5ncGkfPCt1bS3wMyZu
  qaHJmUef0y2SFXOkNEPximZEZsbNqry_k7NISpXBKiZe3GTXioM2nxYqWO27zIhAg
  UZTw0XwBZONV-QOE3_7Pk9zYksaZyfRXD4_u5BozM2IKSpWA7WyuzLRVJPKhznTH0
  _ssS9UiSdR7JbX1JYuMaZ3K9eaIpy6xDNztORyKnYXvcQ4ePzQ8sRR9Kx54r3FU81
  oKxMfn0M6Qdc7mokZ78uqsmPgZfKsMpb4b2K3bk5CZ8vIJcJ2gB2vNIYlpRHAliC8
  Yw73zcTxu0cqGAL-JZKTM91RyrChassqVJSI9y6QwY7_Ct7UUtCZrs9mzIwgeyMtA
  kRi-AS6s5sRand8VbTKpGe4Ez3TUUj0hR-paN06MpN1OaueNaOJTFNRsunuKj1KpL
  BjwpwRsSNsoZxjno86zD7vBaYLr41yDHB1DVmWIXFN2BUlfhxpEaK-Sq0Stnok-l0
  -QXsFTMe1Oqn4UJBHL8-nWCeOM-Z67qJj7KrtnMG54ExFHdGBbVqhypWkmb6l6Anq
  079JjU9LPTAAAM_q6W3AHLxqObGuVIffixzwUcWNOvurptW01jK7XHmvAdCqUHs0h
  JVU-aXpNKNuf8aegPxsWOXH1QDn_Q26zx_-DvEZeCyYQmKkRqJk4KuKDB3UsOmil0
  G5dbPx-Wdq9D0M76MsQUgpfuf5wGhBsKdCErKgeGkYAJc5g8h02xi5FhqTaym59Th
  w184_K5eoHgz280WyiLkJytx4_2XVHWYErjyMuYjjQozgvdBoZsgxjvZ8QhaMbKaM
  lx74_avY_XCIXnyrbD7sUOakd8bIAoylomySod5H73Kl-w9G94N7h7s5tgo5veA8k
  -V-0eZ4btbiCrzcXZWCzzufLB5GffOWwHMgqM0wfc0NUkoKmzc8lZc7-j92FumD6c
  fqxIMvHxcxI3wHMFQogLOcivk5_QcePpoxKE-wI1dAKXtU3H3zQ8Qi22l4dWfj_m3
  bhHPZIP0T2TpaxWgr0j8rluctcaGtWTxzI7QsHwD9gjuUlkkxaRWyLNfwBYKBW-rt
  Gp3wbW9lVoFXYIJNkFrUpDc0DvD8friBbs4oyF32ihtg0KKjWItGOOw8dk6eQkZqe
  q9PgBdkiv5CDwyR2AZptYgTki4aAuyjAdqhlx0rp_CTfMI-039Bk_qxtQ3e0JycMv
  zGkUMdRTa2cpyTDzlQuPJ1rmIJbT0l1GwkVCLkwzewnG6xe7Wsi-0a10ZUh2l43fY
  zjGljTFZTV8Py_VPeqCWvSf5fBKGGeVwIwbyo94EW-FT_7g_8YDsfBK9pTx4JmjY8
  yChgFATQVcNzFLDGM8m9joe4FYH24-QfGDuEh5--0my_r9m3nSDgvXZq40DnMCDLX
  X75Zu4s88QLgxUnWUw2citrCrYuL-TeITWTdJoMnN6ec3IHBuUMiBT6txoUXVKjmb
  NSTUZvhomVOz-NjxhSOl0Hib5ItUoa8oCurfbnPXQF4G9RldzXw9iQw0X6Sicdifd
  HxL1R5xRmPPswCw-WiFB2-K99WEgAh82YZNNnyGqf9UVasAbpwrikd7oxiixZWPR2
  mVB_ibCcoPAF7_ITfcjlikZuKxZ6lC9C6b6x_pflRbaRIfV0D-PvbQmncrrh44Bbr
  IeKHgcC1wvOdnf2JFBvTBueMlY64DmrqDHyIzAy6OYPjBS9orSjcsy_2DbtcA9bxN
  yhhaf1jVewHNXAVs7ksYq_9wZT57hlSjOHVW8BTVe5qumGO5El5yte-D2l8vuAFsc
  PHiLNDSsaF3-3b91yOD6QmtppkGYoGXgLYiYTc8QNRlmTAFRNDa9D5eAQaATP8ExC
  1KZrVgZNAFFUqpcqOrPFGrYGIOI7c4Sj1uUvrFyMhpyAzvhC8T0Uf_5fgJwg9nr9X
  tRe4O7EmCoGTOjIhlCD74a_Jam4EmJoTipFUgK3oUDlglcVxFE0xSr4nyA63I-6G4
  NmfLZHKOMBIFwR5ADiX3ZczAoT_mWes19MZnsNpX2lchu9EbolsWSNB6ADXROH4MD
  yjlKjlsj9jQHm_RsQ-myq-husrjsomI4Zk2ASAZ4W4ABgiX-aoN_Uufd7BX0ukh6V
  Zfq39sZfHN4TpxFVHDMbLO7vfOVSW9lb0Ej9w3FPZy0XK5L-lZGzSYuZB1CuKc9oQ
  Ac8HCGkssmcJDukd05F_61ctc2p3hajlp3adaaRLkXtsaCFxMxApRnohvSpRUJnaN
  7Cnulwp31CieZ4dDXFCNefy0v1m4t5uyvNBgllDPh05NoHnxKeiwSlSIxxumac8bn
  wA7aLqSmyymlx8XZZ6Rb9adqgcBqj7pBhhEqchOtNSVha7lj8MOZXlSpW3SJVKs09
  zbSm7-PddIWC5J7SLZiPQToWTSZgJ__KiwAdWBnF6nWCtaRDEzcGEVJbNWT12YcLL
  IFqSN2Fj_c8P1RKpxzZIuRQuYNcnSSmtNN4qn0ETwy4feCh-sHKM0ca_KFxStKH8Y
  J7BVI62bPY5fuXiRdaVC-dpeuP7IGCKhUM38yMA5qvO0aPM9cG3KDO53UgSujJLV2
  o631YCsJ44E1LZIpx9oYlHXnHrlIvDmExsCApuwo9pZq6swHQ"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

