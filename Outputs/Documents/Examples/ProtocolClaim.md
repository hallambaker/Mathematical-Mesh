
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "PublicationId":"EBQF-ZJAA-XPOK-V4KA-5QXN-WP6F-PT7C",
    "ServiceAuthenticate":"ABDF-RB5R-M53P-BG3R-QSVW-QEBV-BA63",
    "DeviceAuthenticate":"ABLB-YCCV-C2WA-2H57-DAGR-ASPL-5M6K",
    "MessageId":"NDOG-2CQL-I3TK-CWYP-QMJS-ZCSG-WHUG",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MCYO-LNXB-2TP6-5NQZ-OYY3-73XC-B66U",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORE9HLTJDUUwtST
  NUSy1DV1lQLVFNSlMtWkNTRy1XSFVHIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjQtMTAtMDRUMTM6MTM6MTVaIn0",
        "dig":"S512"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiUHVibGljYXRpb25JZCI6IC
  JFQlFGLVpKQUEtWFBPSy1WNEtBLTVRWE4tV1A2Ri1QVDdDIiwKICAgICJTZXJ2aWN
  lQXV0aGVudGljYXRlIjogIkFCREYtUkI1Ui1NNTNQLUJHM1ItUVNWVy1RRUJWLUJB
  NjMiLAogICAgIkRldmljZUF1dGhlbnRpY2F0ZSI6ICJBQkxCLVlDQ1YtQzJXQS0yS
  DU3LURBR1ItQVNQTC01TTZLIiwKICAgICJNZXNzYWdlSWQiOiAiTkRPRy0yQ1FMLU
  kzVEstQ1dZUC1RTUpTLVpDU0ctV0hVRyIsCiAgICAiU2VuZGVyIjogImFsaWNlQGV
  4YW1wbGUuY29tIiwKICAgICJSZWNpcGllbnQiOiAibWFrZXJAZXhhbXBsZS5jb20i
  fX0",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MBAE-EXHC-DOEX-EMF4-VXOT-G32T-ZKXU",
            "signature":"8OEzUyz8x67dCBOnRs_WDaTwRBFWyhNPaBKJiTVh
  -Gci_HYXmZHXYYlgRPo1rE-8v-Bt97meVH2At-UNrUnvweciDNxVHVcdS0fuWRc2l
  qTO0Luf35sUfYZCp00B0wpDEUqnSbVltEhvT13ZOQ_44ycA"}
          ],
        "PayloadDigest":"4MMdD-oU3kaVP1PU9oNGRXDYeShs4Pa2Xk6E8p6c
  f2S-UQxuDyQ-DqY1K0fPr2fe9imQcOVftDwPKkUjrlXUnA"}
      ]}}
~~~~


The publication is found and the claim is accepted, the publication  is returned
in the response.


~~~~
{
  "ClaimResponse":{
    "CatalogedPublication":{
      "Id":"EBQF-ZJAA-XPOK-V4KA-5QXN-WP6F-PT7C",
      "Authenticator":"EC27-5MVW-2GRL-Y4NT-2E3W-A6GH-VJQT-QAEO-PT6H
-G6GB-MHUY-3TWF-LDCL-G",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQL-44BO-OBZM-J7EG-354M-G534-C7HS",
          "Salt":"0mPl0lnvEbYikKNNqeHFjQ",
          "recipients":[{
              "kid":"EBQF-ZJAA-XPOK-V4KA-5QXN-WP6F-PT7C",
              "wmk":"mBeThijVHxvXVU2wn3EO__EwtVUeL7SEc5R-5bcAQURG
  Z3yif5nP6Q"}
            ]},
        "ivDEVMjfCO-wlOcY1qBK8JgH31POb4z8qZ7Vxg1LkpwTnRZ8KDOMMQs0
  m-hSqpQ7ABwjsMcIrF6fxMbw7DEHlIe8kFTMdLbsBbwHgb83ldt5WHetMD0XBZLzt
  OLkUl0xwJik-ineCRDse1THeyqt_4tkc0fLeAVxD0QL8sEQ7GtqYDFj4a0foZiJ7U
  F5HXQh8dDriqQg6gXZptt1os5V0Rnvc6KdiWsCClToeS53ICmW3g8HP41SJB1xW1k
  QNkk0DPfwLfaQy4cKkH4o_E5Wobd_gkbSWHxNwY9HArVYnIqqv22y-okzFcMxw3hV
  v0weqNnJiIh7_TdaX_Ibrhh3y0LLfmNPi7q8IfOfBbkB8ffPydeI05Y18tc7Vtyeh
  QzoteNI6Du69XlHI2qyCOuClIGo0dOv9x8yZzWo4MPUAIfvP_3herkAJy9il7C1WM
  quU9YedrQ3fA3NpC3o_gOqn5Dv0UhwcvRTdC2f9RAFkPu16GwIcYnP_ooN04Hrab8
  5OCiAXBkHAqyen1Z6XfTQszQ7M5vDoskfXHluXG6AaDXtcv2bguePwXKTR912dj7T
  i_kf1NyQf5HZTdTCAOmAl0Xb5i2rKdoSE1xXCkmtOW-j0acdDZWn0uOPaYtHx5UNg
  BkTrCoXkxqu47rg2fVU18BMZDTi-GO7aSPMpkzVMPWnZr2boy1ySnLKflAYL5QqUW
  PWDPUtfV5OaQZCBuiMvMxLaJafvBO0tgJQZXFte0PW43j68ri5ir1FePyIWYmAHIS
  SAKhmrwX02nZnOyUA_aq7hehJUifyB5MgVjXm3CC66ijU4XcekXUcq0mr62SgOIYo
  b11OtUXqlpFxq1NfaqUorqmQWsjjXXJvWzw-gHnJhuOw6l5J673Q1i_ZmhT9pNc5r
  Kuk3-2cF1M9_UtQFDKYm-FvofaWv4IoqZ1FSmusrq8YukaDupIX6WWNNbMFluGsaI
  eT1ZOwsvfIizC2k4HcOaj_4vVuW5tLlEcB6pZaSHOEbSkWZOP2f9v1bWSUU7Poppn
  1elVqDdQTf2mnnVZuCyzYioZzdEdX8oXCyYbuBu5sRraCrJ8b3X9nDzBowbcPOa2J
  tG32GDb3WgYL6mbVBzmlIwgEPwphieG_rSkLYt7bu_Sb1mdLihY76PqMQze2LbvY7
  RyDp0AWoVP744vgjysr-O6oVX1YHfMJ3E4NvHsi3jWILVgWzNiFacKmV9rjXFkCq_
  TP86uQ4fN8OfrptMHAOCHVeGg0r1Habd4aflyS6WHHJj7ywgcaq8rwXtirE_7KMkF
  pukykM8Pe_xXi48I4qd-LoHPG8496HDyzSuHfqxFVnP6q1gaHSiC20P_uV2VnhlvA
  IdoG2qGCXnML9QPLAT1YjAt3ZyNcD6SzgSP_cqn5G73SbnAkjrnZfR4osKoy6SE8s
  8ZeRNk6cQS8X-i167cbSfyQnfQW7Eqzm3R2556RU2Ix-YMqciB6YSprOfV0JogIjl
  xTc4Z3Tx6JsLt2rS9tOY1J3P8rKohQZWH1F9uXMTD58htUJSPFWFERVdUnGj4xd4E
  LDEpOG1OTxXSyCHf7va0woDLVb79WUuunxucRcZN-bPBxSc-a6rBVMREKbjNr3VAW
  ad1Rm21pLsjwyWkurc5Qy8q69VHH3wuwTOzUcHjU8GGRbB0o4jRWlBERvP_gLRFtX
  8kuz0G1Q80g4C_UCYdiU6TX5EwpJxXaRs79fmDKiym-VR5XpcX62W9QXQtP9oaWZL
  vgfP3pR5DEc1ii_1mXdBs3Dt4TLoxf-jOVgLgk_3vDwYUm8eEeLUCTqWZYNpshS2g
  2N8BKvaIDHN_EU2okkBgUNQAQOXGNW5nY3ksEieK6yTCTIoquGAEQ-UsXBrk9XzJw
  jUVFMIRcanrnGWfq2ZK2nfpVudK7RpqbY8fpzal_0pRiFDbfHLc5QNp7J_3ZK4Dt6
  VmgxdmV0yqM6R4rGfhc4xy97xDorPkfQ8T-14iPDtdfyHX2UfiPh2Pd03N8epvCKK
  FoxGfCkvMhbjxGPwqNt53wyewVWr8QQhVVs7yud1RnPigVtBASqjsqP6OODP0GlmK
  2C5syz80ql42vd04K4nnLx3HHn57Y7OHkQtdyrOuhp3wFLNlTRtTQuxzur9dt_rMp
  rl9mXUMpTo3UySBqzJjxCnN1XDewd__9H78NHcwqnewORZcSmAnC_caK2dz0iWBFg
  1k0Asjs8uXwjWcDl9Nlu3CwBf7jaR5a4UgKbf8__ZHomSEs5Ysz0ciMAk-h-0GTrV
  SKLvq8sGs6tDpC8Ds-y51EdUeA4H5uicekvvaOCjJ8tFTy8XsCJZ4GWALlfXCRwQ7
  PpgkcrIxxM7eb7uBfwvOXIgSMyjuswQe954v_qyTP4UavUCYEhNFNu1SkRRudL_vL
  0VTgi-g8z8pp0qyC5L1dNWP2PDpnRBzNMa4ilpHZcsxlcAqOXSi8FutWg4JdeXwzY
  tOYYGjK5qQuTiMO6EqcxwvxZoGpz01ToSmrhh6H_JOJbBXQbPItOnTzOQdUWP9CZS
  kfpe_GIp-QTeqXtFDzhLd91j5xSI4DsxM55AF7K2uQFE9LK-bgM0KjPY9eji6H9tn
  J7leLFnSDCDZkM-M7fgu7QJKuI8hpSGsduHg8M-9wWuLVQF5bK6Jrz09S3nsIOBLo
  yUFuCC9iS612-OAJhZ5wzElVdMw_jBIESxJVjXZpfeLy-7MdFGwjEr5k3EsjdwjyC
  NTjdp4w39aaxbEoObw-eVAvAuE0oG-mPrB3gG3c5l3CenV8Fl4cTeaUZWxMjY3GF7
  hPnTafMdCjGW10Vm9jZnbjUIvApGDWUKdfQZ-ClfWxv_ENjpZ4G9vCBEDVCLvDJhn
  Jz8zR9ZaCcA2sMB9j4-1kegzoaNrt3E1tC5Zjb8DWPSobMvC4nDu39Ns09fT03Xdw
  RS_TUPN97QWUhWLbq-Ko8qpDpxIc2I8tqYFGQ3No1VNab5vlxhXgTwroATRpBUcbm
  bzuVhcixX-UVcClmFPFIyQRGXpH"
        ]},
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

