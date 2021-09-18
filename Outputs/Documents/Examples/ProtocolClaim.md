
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NB5G-EP42-M25S-5Z4V-F5E2-TKGF-QJZS",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQD-KWTL-MLDJ-XVQ2-ZADS-O3JW-RBRX",
    "ServiceAuthenticate":"AA5K-Q2AC-JLVT-FO72-YQB7-Q7ZQ-JC2J",
    "DeviceAuthenticate":"ADJZ-CQYZ-NO7Y-6HYE-N3X5-7PWE-V2ET"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MA2Z-CBQS-AXE4-JVCQ-VHV5-FNAS-SZF4",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQjVHLUVQNDItTT
  I1Uy01WjRWLUY1RTItVEtHRi1RSlpTIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMThUMTg6NDc6MDNaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5CNU
  ctRVA0Mi1NMjVTLTVaNFYtRjVFMi1US0dGLVFKWlMiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUQtS1dUTC1NTERKLVhWU
  TItWkFEUy1PM0pXLVJCUlgiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  E1Sy1RMkFDLUpMVlQtRk83Mi1ZUUI3LVE3WlEtSkMySiIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFESlotQ1FZWi1OTzdZLTZIWUUtTjNYNS03UFdFLVYyRVQi
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MD4R-NGWY-UUD5-2PZJ-IPQT-664X-FF24",
            "signature":"sauuJTXevrJ2mpUbV4HHBPoYwnE78erMNmprRJTb
  SAvrnVD1PGPRg1RkvGi9WexvntlkWnuOUaMAy5Xz_zFWhFW7qsuM8PECM4o7UupBM
  9N_339dOQSucdUr6RE62IQudBSUcRwSP7AAr1QxNsWoBgwA"}
          ],
        "PayloadDigest":"ceTQbNwwgRfscCOLbFDPPQVT20F8EbqpqHlCxuMN
  CVMZ47cfi4NYgW_jyw1-stw7fZn4hF2GImyICZRbKU60Yw"}
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
      "Id":"EBQD-KWTL-MLDJ-XVQ2-ZADS-O3JW-RBRX",
      "Authenticator":"EBKU-6PZB-SPD3-LUHJ-QOPC-TFRW-JBUB-NRZZ-XU6W
-SM23-G6BN-Y77C-ASRX-S",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQI-RZAB-KLWB-XK3X-WLH4-YARV-V3XF",
          "Salt":"UcYaBuezrZpJyy_O89_hdA",
          "recipients":[{
              "kid":"EBQD-KWTL-MLDJ-XVQ2-ZADS-O3JW-RBRX",
              "wmk":"cytzDz4c_0ybjFIyjI9geDQ520viSzoBo0JDXfZffZUj
  158KN-CREA"}
            ]},
        "7BJhUii8_o97MGiug6w23jMPRuvZh0XRrGPyFhkYlaWtyC1oBwJdKJLu
  a0OkJCTEvCIrdVJO-jNJ0mZ00O5xNwmDeQGVJXUJnnM6BKGb_TxR7xVM6j-1ChJLm
  9xmbSWwFLWuzXEkeLm7CyTPFnSiheuGXJt9jXV624BUqBnMzI8Yn2RBH065uG62_P
  VnxH1W_aR7fzPHKpZJcUnBFun79XiUEqHeDCak59lAxMI-SvM9LLlcq394FLZJYg4
  8S-t-uYg1mu_Hx7v8GLqDxamGLsGI-Y5vh0yJGo4le6I4PGZ0s_Ygone4c96H5Ify
  6Lo71F39ZD93eYtpfIeBCHxPABcVr9ZLJcIAzP2374tnzHtkxqKbOIbY6lvNpN3-l
  jqsa82G9r-jY6VSxPXNFROCNgY0sjtiYYv44FkxGM_tWq7znECx15qBl7jbxrq3k-
  Xx89hlc79683KrZ1Athk3OGLeKtGV4kPGEoe0B7T1pHct0B-VoA1EU_PW3CQlCI7M
  wBSIlKAQUtXWJgYlRltwZd0G3VJUIt6hAPM1Gd4HDX0pTvPj0xMNL6X0UleaCHXBb
  EDXuUhhNE1Uy5pxxegrP6bgc9yd4_TytBqEmu4dQrykbIeNjlycWzZWrmgXa-CgyB
  KdlyISWKO1aeDp0n5BKMrzQbhXPVDGSvUROtHRrR8R4UvRWy2CnSiFGKOg1t7iapU
  V4_PoG1e3dR_EKZSwnJn8NF34j2hNDJSIIvaOsYDlDxMZldAg2-IDlzMsCgrOMNiW
  6v8WxthHzH1BDQeggVat84MGJIg_yUFsBb4ph6tzFuuEn9FS6zHjTTHgjs-2nbuu9
  5kELqSCnRoICS7F3J9YT_jvD4rm8UAMU4jTJfYJsxPVy2NUSHnkWOLDxDGu-UNCrY
  apdCHFUBlM1C2OMm5G87TmTFhqW60G5Kxem00lwOnbJ_KmUuuHGxyIm3sBx0z7PVp
  moTNixwC8P7c5sxuGKWwjx-U4m1Cn-J8Dfir7aM97j1Vprq_SIYbRDnN4iZXQ8CjU
  8FVBwmeuM4sRY4XrkGV5Ul7gC7eoXIPTuEUuQ-1l5q1J3EXpF4AadNnlBSLrOL3Ae
  yYlZ7fUr_ARzAsEBhX7iHRuITobAS15r8RUlzmv6l-qWQC9KfEPG9EoC4R7D1ycA-
  94tiAVLr0zf-1a62hSJn2fHJaaW1PrtBZOCyinIVvdb0Hr7_ygCaAdxZlKFk_Lm_Z
  ijrbvDJ8XlVP1fHsUBjvOsadH-TbnBwiMd-ZbqRoG2Ni4BcJOPksTgTjcgdSHYiad
  VeusvrWwTsrCmBslIBJAwfcHaPQ20sGYbAb2d-axUfLBDXkvY0EsPoD3MUtDoAdyW
  HxMk7NyFMR49klfTcHK6en6RVMddUtutBMz7aRmMbOb2I5cyO9Pz6ZTzfHTCbycPI
  KFm_QS3jXMubPgSYpd4CzJeIdCWOYd__tN_-5xlWDZUCzSQJpemrtUqBGuN99-f2Y
  TbwHGw50WbsDPa-pTobAIeg2U128hAQDFOFNvfW9tEgjQ-4jxUsHzNTIv6V-6e9F6
  oQxTVHu7WWI_mzQfd6DTru33BleDcSyNqCl91tspOmzqVSjXtn0Xt_KEkc8_Q8O0z
  e99NLfoPSOWa6GwkrsK1vPUyJfY1Cdm7-wSdUOxNDACjR0EzXpcOXqRoxZuv38xnM
  qsKJfzZSXrImvlvRvcdQ_g8jmG7zGSQxoz2Jus4oq1xEKVcALadHAvs4hGtuMyCpH
  fQssOgU4VqoZxuEzvWmh4yBGOFFG0ZYyWnz2bcGOhOSlTWr4nvHO-TYcliH7KfsH-
  bj5-0yLrodG07yGfRXOBF031HyTaN9z2Zp4Tpjp5H_pd0p_CxHXTNnVqYxFICZcu1
  J3qjhuJCG7D6gdO0yRH7LqhfSorf8RelrJp6tGxcMXp8VYDuCNf9b9P_d67vL_cEF
  ZTXwxG14NG8Fja3isLhvZf2faf-9QWeuN0dKSYgL691vGZvIH9Bl_EwfWWOLKOmH0
  YFSMjP3uBLfmrNxmvIosWCzYYb7tAoH8GaPh2fO_KwSL2oYRclzKisTckWUJxtqBN
  Q954FtGxljBCvpinaJFmi_HKoElC2QRqfCkwNNYMEiY-VcQJlzK44r7gq_44m5Fo7
  38FG5EGBe7DaBByLNlJcPtk1Zne4wGJ8wx-ktMLi2AybSzIgN9buTvlBrFseNeELS
  ssziFZHYlZ4PuqNiHhbXlIbMjZ7JTK9sBdarGSY5zX_NZUu8eGzwkIqu9a0OmAm-X
  1D0xH5ARvqtyX7WuzFY9SA1s-Jph9vlX7x6dSF0c7L69R5JS-d35yUVQEQS-1yg40
  rsy-gU_pO4dJAKYKSjLIDIPceX6Ym5YiRiMmyS5_E4cl8uU0AVzX90IQCxQAr1T4a
  cbBzEzrhxK4Hn6Dl4BmrwusQezoLTWdzJ-nWtwnHzMDc5mPXkxFaH_7eTPYtgXh_z
  139HflYI6U64ebadCX0LTl0wjlQPyT1GYN2CpeqLgz3YEHi0KZkmbv4lZtnoT2g5P
  8P3yQjkLQfEELRyiM54GO5hwkzjoTq-p6nuwcWiy0bPtVcOhddVR-wkKP08-ee8hW
  aQnT5YpipMJ38D7-Fk686NNucWdzFE9zh6acl6xC1i-KY8q5e_tvcXlfFqtUBzOko
  pCTFqH-8cS5W-yxdB-m6DfarW_TcZ8su3TaEdJaXqw5IFQlXMUICiq7FXYhMZem9d
  eDndwO_lPBb6Ret4x8CnMPczI16LTPvsIlKg9CiU8-JCI0KvKyvS4vDkq-1kH56LE
  c6nmU8yoPtdKgOY8xfHbeefeX3_pxKSBtJJcZHSITLoODXRhaoVrbE-BLia3l21eY
  WVJif28mDjAtJNC39HWD8KvKxHL952q_tuFPlJLIRqzfUVNK188k1uUY_EDQLWzwE
  6yn8jKlERlBru-teR90fXZViyKhTjDoI_gaUAeLysEExjA99hA31pyWHSTmktiaSS
  X54tLzZgZX2ZqhlcCN2NVF_k4CcH4bdLZkEjHh6vSc8ZCZwcQ"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

