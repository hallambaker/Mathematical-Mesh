
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NANN-2NOW-XESY-DXEV-C6PE-XNC4-Z7JX",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQG-E423-3WIK-OA7H-O5V6-ROPV-M34H",
    "ServiceAuthenticate":"AAI7-QT6V-IJDP-YLA6-CMFF-LFJ2-NX7G",
    "DeviceAuthenticate":"AAKT-SJQP-VOL4-7QQQ-VIWA-NX5V-GLMK"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MBS5-ZEZD-7U5E-A6KG-J2MP-4YTF-TPGH",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQU5OLTJOT1ctWE
  VTWS1EWEVWLUM2UEUtWE5DNC1aN0pYIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMjFUMDA6NTg6NTlaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5BTk
  4tMk5PVy1YRVNZLURYRVYtQzZQRS1YTkM0LVo3SlgiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUctRTQyMy0zV0lLLU9BN
  0gtTzVWNi1ST1BWLU0zNEgiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  FJNy1RVDZWLUlKRFAtWUxBNi1DTUZGLUxGSjItTlg3RyIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFBS1QtU0pRUC1WT0w0LTdRUVEtVklXQS1OWDVWLUdMTUsi
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAW4-D63J-XCVZ-KV3A-NOCU-R363-BRK6",
            "signature":"OQt5CCgRkP0AYEa4Cr28nVo49Mfb6etXQoth3vgZ
  ZuicV4Q6HBhtGVe3kS_YhgEvBh3BEI3oBt4A84fW3TBLfUaw8keoE_4OHgh2FSaCY
  2-JF--Sy_7rsF7ylB_0Uk3Wn1ndS9hx3nfF0A-fdtuo3h8A"}
          ],
        "PayloadDigest":"3ZP5OvFXvo3PbBujm3sXpOMTgvMSKMQ7S_PwjvH3
  h_MUO2w4lrnwE4Q3wubK0cE8C6Nzza4x8Z5LGF4LjGzAXg"}
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
      "Id":"EBQG-E423-3WIK-OA7H-O5V6-ROPV-M34H",
      "Authenticator":"EAKA-TJQ4-E5XB-3SIS-VHKZ-33J4-2LSV-GVW2-4VSP
-E2RE-SXUI-RG6F-JKS2-O",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQG-GC2V-V6T5-DDW5-YILA-RVCN-5ZZT",
          "Salt":"ggN7MbcY5b1xx2BKKObBzw",
          "recipients":[{
              "kid":"EBQG-E423-3WIK-OA7H-O5V6-ROPV-M34H",
              "wmk":"2rXXKvgeczOwaaYkbs1L93HMJq8yHCDSDoMzoHdiJ5vw
  cmBw1e071A"}
            ]},
        "KpgYr1RJ2L_bEhnu565_Hry_3jDUfiON_UxndPDe5XcbKukYpxzyGNKH
  PKqGvkuz-Yu77Wy96TPHmD8bUMcGbfgIzKpWoo6SVbhvi174967vs9YOVhfuKdy7t
  LGCeXgZ5XOAPIjcTx0ggZs00YyQJDA6B0LorPe8oa-HB9fBF8oSl0iTG9JWygH3gg
  bvXOx0XYNawwGPSKEZEhi1wchzWyDGo9LKu4WTT7xqzgN453hJ6lqCFextx_W_Gi2
  ymTRmB41MIKI4CSb5SHkKMgvSABMIDC9jCRYanOKFYzHKo-zVs5sOnZYuc1DE-xv3
  FxgzMNwdNFb2V9JCHJQk977cgZ_vZfmCx-lg6OthJN8RRXPkGkZNG07_BvHoPUr39
  jvdLDdqWjJu9WgiFKw75TA36LXeA77sixEfTC6clgVdXw3_gej4n-bDcY9JfX3HEv
  3jjyCEDkzB-AUeooB2zdRe5Ysn3Vz10MTKx0tE7cUz16cVyEHxBrOEor0xDF7cZ9H
  Ew7QKr-7HrxptL8QI03U81YeOb464c6hORwDO-XtdxdnKnfmXEXpgf-4CZ2eUPal4
  Fv62sL8lmvFYDGk1DpeNYUQpmXPtBuk4H-gv_evFjZB5dZ3mzqQ_phFErpIPKs6U4
  436Ecapoe1RXOGfBWs7wZncb2AnZfL9RXN20Q_e3EZ8ER2ej8W4zXLRnWYvHmGaQZ
  WPhXGGmpuNhI1nZsBuQ20jfuJsfri856zi7C4n4ohq8H8zFzRsf946cPJYVEAhOKa
  nQrVsJUR2DrdKNgM8rJ28xM5xq5TBO37ZTvcrLutVIuLzvhHBfkMWljxbBOEYPL-I
  CiacCHb5y-rTRXhVgDtfMZttaRHI9UzfRw62-OpqM-VdOdsrmiVtBp8QZ6BkxxOZr
  BvtUbOBRTSi5As4Y8Rb35wAbK0LZrcmuseWwt6rMeFbxLvwnnBLSPorYMuvVzeHs9
  Hgzwto5gACMJYv6QkhZ4_Od_gfTm6XX8YNzxn7Kcxdp1NQTANleIxPZxV2niiWhVd
  0ppIJZmPqLs9vCFQ6e4DVmZSWXaFBlZXUPn3ZEegcicN_7ibksVQoIgHkoXSdh3Xm
  e2s5BszrkznG6CPRgW74qTe9muMgIRK2-IoBYR_fL5dGF38dTgB0Jg01qNruZAnIP
  ch15rpYaWVLD6RtncGbUWUyMTJBdQ9TWw0ZA6_fs-0u9VJrDBMukQr9mk2rV_Tkbt
  Fg4Fi-16gYuAiehBSwRM2NKz89RMsSlMGLAmQSq9k5w0O5HSAbIZUjIDmsEwh1Quu
  zttDT2jlZvgqgMEmwhHuYEFWyfUPuVEj2CK4SaJfF8-DsHI_LMCk5rOpntw65PLKM
  cSjiZNli3JsnoQMlUL88EEW4COz57nGr9PBQwiY6b4f8t3JaXKXpSY5Hkj_E-nQXv
  jFcy4QKhIBSh0v29xODVBKf99jtiS5doChZmNMb3t0SjjArog_BEbJAR1nRy6aXgJ
  816806s6aHtv7VVfHXeBTLEvqiirPk1GQ3fG6PECFUW6xf7Gu0_drS0r3lT9cfSlS
  5OKmVs5x6pWVMeBy9NDR4X-v1LssIgzrF4EVYa6KWbD6RC3hcuNdfgSSNYbgBuivz
  ymd-7XqSw5nRwvR7F6_rQCseTB15mwJSZJPyWl6suApm_CS5S10ouac3Ea6YtlzNH
  hWdTPuefOAp_E2WFzucjun94pbTJ3Bl1FUk_yn_t3TZglBCZxsNY8iLhtLw0OPcdY
  nAEGVWVTT6LRjpxBTJzbnCu6dXWxBqrMK6IFcn7DsUbThzVfvXBefpUKFALeVqu8l
  v_HVenvbSGZPs2cEXFh5QODb9V2IquDNkEMzXPzxoAaUUrYMNjo39aSEOA9DKrP3g
  253X9kK043VcEMKc-fcHKILfICHQfByxZTl3OreyKXWkvaeQZ_DqXKrCRbeALQH_r
  F-hXt2WkcnKFXYwtN_VOsbUJ-A2nsDF0l3uolmt-KByM6JND4MS8Dd_REbOi2GzNA
  I14cJGQmaP9AZUBP3Gk4ntTU-AWIH6xXnb_Wt1JzYq8vc290KpGWNyMdmu1qzbqCs
  CGM9xVfvNzNVutfpe8vnLenEnvRwsrJRwF9QhD-3Gpyz4jysXGB3SG7ZbU9S7WHcu
  x542dMdi00O1AgFs069jksttOlm_WcZusBO3wGCkLLhTdvZBmzoHiq8m-7sMt8OZX
  TNAzlDxjVh6639-7p5I8dISoY99MVscLCvwNFV3vfLD7Uv8IC9LlFhpORUPQKaAQy
  jNpm1lJy8BeY7OhpFwCbtenkX1fKH98V2ip7NdZjKrXs9wiZYBy3gtLgpih5gC-Db
  SYK7aKlCV5o0dSDi0gkScSIYCHPb1U8kRi4lDsvPJXh4Fd3LSmP-e8GMPbQHNNZzY
  Vg_qpvbc5nqxlcUgaf5iQWiIMUFh1qM6G55IFGcmQkPtU6Mr-W7MPOLCU9z4gZrs7
  bc5eP3cDv3aEKd8v8hpZpm1LSdt7PEwYShqsoRhNzyAldAk7fM_QO9BunqqlzIGXP
  nOz0z8hXbofQn6mWiCVf1udwYdFRSj8sTHIqKZZQLx14rKXcZQilX5-UG8U_RrNaF
  2PrpHNY-PdpLt_JZt-ZjvKIHe6P1pspQBivWo0-uYiYNuEiq5Mtl1DCj75NK8boll
  POkDOKJZp7n4ywqTNLiNYtRFVIAFv3aIdCWjoVaK9Gbr-7HXYSJxJA9aGOtYBhQZV
  xtvYRB87Gq0Tdfh1rqbbDU5jf7MZEks8O8YKnf1arCh77QSqYSx9KQC5Fta-00mkl
  8-WW26mxr699mCb87QFtkK-yJ4vb4KfeWBwZQ-2k9qMQe-xcji7m4sBci88GCsJs9
  EkdNeGMl07lT-hQHuOxFRsvJFmmllxEf096XKa9xE_F3vUTrJWwCpQPu_-wnmmjz4
  G_3qfzXm2qOQm41moznoR_6MgbZPbIyS61MUsDh4pSspkdnZF9-lpTII5UWu93YyG
  lSj2B0wbJntUKAFD36iJhVOTo27C8ptcLovZpp4ce94HAkcAQ"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

