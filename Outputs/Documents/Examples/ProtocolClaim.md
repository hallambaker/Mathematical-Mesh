
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NDZ4-LGXM-W7JI-6NRH-I2AS-UPUB-QUBL",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQB-KJVT-BYND-4GE2-U65R-FZFH-4C7O",
    "ServiceAuthenticate":"AAX2-PAY7-QBP6-MIF4-Q6CP-RGQ3-XYT7",
    "DeviceAuthenticate":"ADZR-C42E-OSGG-5APY-RUWT-WAAL-6IDW"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MAGR-RKJ6-YTCG-VLPD-K4ZD-6R3M-TTZH",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORFo0LUxHWE0tVz
  dKSS02TlJILUkyQVMtVVBVQi1RVUJMIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjItMDUtMDNUMTY6NDc6NTdaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5EWj
  QtTEdYTS1XN0pJLTZOUkgtSTJBUy1VUFVCLVFVQkwiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUItS0pWVC1CWU5ELTRHR
  TItVTY1Ui1GWkZILTRDN08iLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  FYMi1QQVk3LVFCUDYtTUlGNC1RNkNQLVJHUTMtWFlUNyIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFEWlItQzQyRS1PU0dHLTVBUFktUlVXVC1XQUFMLTZJRFci
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDWZ-36RF-622V-XT6X-O6KB-3S5J-4JE3",
            "signature":"IcU7z-AssGRaQXnR6p9Dx1hwrZBLmZutUe3jgHnX
  53-HTX1cQeQp8QYDHB-GxpOGVsS91LXNMQmA8keb0exzT8xdnOX6J1I7mXcG12nvs
  i6fUDkXOcc6Yl8OXw6UpoiK75I1f8Gu1UDj6x-Zado4TTEA"}
          ],
        "PayloadDigest":"5rbP0ACwMxu-M8RKeXElgiEFeiCMtvhmaUfryItH
  dvjWhzOrpcTiTjE8yjyFEOZ_jBQS6fXec9IYSDnmdA-gIQ"}
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
      "Id":"EBQB-KJVT-BYND-4GE2-U65R-FZFH-4C7O",
      "Authenticator":"EDMR-XKST-PS2I-LZO4-OIAK-KJWW-EEHT-ZNPP-6VSF
-KM27-FEFX-LXH2-2S46-C",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQK-HYJK-KVFG-4HRB-A4ZG-U42V-B2NI",
          "Salt":"UIVoiLmDP-jNUFdco_Jqfg",
          "recipients":[{
              "kid":"EBQB-KJVT-BYND-4GE2-U65R-FZFH-4C7O",
              "wmk":"Rp5jUNgjdattEDYaln71xu2LCXuHQs7H1KvZpHSodStg
  k_9T9_u4vg"}
            ]},
        "XaCp3aoasktbWuatoM0taMvTz8PSMR7V-fW-zET-KwYbuHVQWzCq4NKu
  uUpJlh2IgjKLVRpLzMdOmBCw4Zl-Bde9HvQucajXi7scUXYKCOMwXP_tTUTmW_Yu7
  R70MIxTctjjbxYmL-AIdqTJbsD-jV1aTQwjRAmcTIq8NRGOtramo20pTMm8HqtcIa
  b3b7Qul-WXmr_fHOGOd3kZydz7Pr4oS9TTg2dXosLdq5f9NKHf_7tlllvu-F86iFv
  E4DLOe_HUpkZDyrLf17qcDcPNxFV3fZQlQLIspht4R1XyaZt3FrsBaR11STdN66-j
  6PHNVsa96h_AQN2KtjtsV17NRUqH2I3U8BNYQ1f31h2q7B_oX1yKYRvDn6-Uu0xAB
  E5ICjn1zX6ZAH6Kf_MSZSO98vholt9KI5ZIVXKnU0xyNYqKsmbtT5AyGXYSIJgKLy
  V4OcIJhBv-T7uo70wtMTZqozB30i9vfL9jlUcT1mpvFRrP82kJj1PNvYCprOLYjgG
  dqrDqAD_OmSyfqu-EuBgBsWJ7aGlsaxVDh4mKpnsmZOVMxfJdGfXwxl49Ga-TMNxz
  z_e1hY2opR_2cqp_KcCre6B4zI0kjTFEhtxMNzoXO1xooOf4OMDY_X5g0MyfuHoyX
  ACh9W7M3cxHqymm-DnjCCQ_yPCpKRDV4mwDSTWWw8OPHwnxC3JNPWWvBdXLQaJd-l
  JjzzYqO76ctido0WaGooyr-2KyxWXyaVlSt2tm2z8wGVF8GR5LQSVvuYp887n8W3c
  hSlQ8ezzL3gtqLjuCU4Ne-FIuxNiGhoHxTkYd4eukiRMzRAOZuAL79F8YESXATXvc
  LNFamylGAJMGMdndYCMc7TpcWUiiYi9bXD7ok9Nu4SX0lhmlNgT_104iTZrBoAIPe
  IESwJsOYfHqQchcm5jniyj08LArqWKF1WNuiwyTO8zizoLM5ki8BMcxDeMTgf6nUw
  Htc-Cy71meHn2Qzkc5ViMLeeTSqSjnOfLItdh06SykM0yKZT7Ys6P9PzF00S4flho
  jvKlMqp_u89WoT-8LJhXy1uHrs2XpMfURL0PZMuxiZ4WKoR_CN2ysjjWfHAcLdjcD
  IMcqnfY_xr3bGU-VKReS7lCu_0eOSlH7YQ2FiFLgfbcI16AC7a7l4vSaMq2vNs75h
  ini8P0_x3xOclSxwejb8RYR2AJkS6yhtEB1PinoYBnAlu9AwL0EpzhICgfi4qvioc
  njBO5NIT7gxE_-rKskdhEy39IDnuNn9ieM3c4QpTQSWKo5CtvkQrjvmmnoI-V_5mp
  NWjx7Eyt4B-XhwV1DlAfC1VqrIlZboX__4MECZGBN1junsZ5D2mUBIoq0ZKisw_EJ
  q9vU_zRhoI2oAwTjGOd7Qbjmkg5uGVQ93fY5QH2K_mMJgqXER9RwjnVFjeCCNsYIW
  Jc5nvotxALStI2pQMEq-cOayK0IpYRZRgWqa3CmAv9c1cJ7V6PpIuHGvLoMUW0vVc
  QcVwsfJYVHC-Udqi5mggoKQ3u6ecFUW1spQ7zTe15oEiNO2-i4pgdZ3MkjYOVrcOf
  RbClvcjC5yuPB4UoIa5q0FTYMRXNSzSJQ5AejqSCPpr9FZvQjAYTIIaY5iTpvsOGf
  w9uHkiOhQrszZROiRbXNmrFTjt2mcsuumUXBWt3AZsMjkyoRF2oyExKvFJ1nu2xV6
  wdu2ygme232JXkxHs3Tkaxv7N2YNdZ95_MBO6YYv-2WpuY963OhPzuCb_sNxebLnY
  uE9f-VgztH4KTpCXMmOIaReyKLqblkREnXUHrBVmsopK33w6XmkmBUtdMDF-ab0wv
  vK2g11BTVPRv_HBTTxVFuwxyh9qXq0vm-axhUlGSb3KUUFZZ72A-lCNYw5rmCWOXQ
  Zagb-TnTP7RZKlynquBamGY1ZqUWIbo6i9itt3h1NJdXesre7BtPOaX-uX9cF-RA4
  zVEXvDffUWlIE8_hbhoapf2RHQ1XFBTgm7MABNNdihI7_itvEoLURc4jjVHgK8yu_
  O_XcHfylXrZWNsc2zTv-bMflYF7uYA7tQUcN0O--tHbB9fBTbKozb8BowEmffEBDL
  SDJWwdHC2UhR8b6MgvgplD6qyhZDTZ67yVdgAS5FA1tWBN8eN4Dpt1TFd42jXn6iw
  CWkjej-Trn8dMzxhB7rXg6RduEEFiKvnt0HXzutVphY0n9cUqA_wP5gQJGK_HUkDr
  pTVw80JxsJb8I1GHdDncvoJSdfi6aq8e8PIMHHpPRoMS8k8rpSz4vZP25JskUtzIx
  qoR7fJVaVn_QrfpQNEPYoVkJNjk-SagKTeZ98NyHomNSLrFMeoSEGgUByeQtuBhJT
  LuVHnPlcA_6-4Qeg3J4LoPG2o7yWodEHFLHHHD_j2K7f5xgkzzMKV9hgpPunj-Xj6
  TvI4cuO0IvahNUu2Y-I4taOjf2Vfd-VNq6BU8Vc7jQ5P50ru67_vNUDk5RL1kNwvy
  R900M7wDis6YKOeoEgumdamaxp1JOKEcheiUJ7JTdQF05caoZsu-YB7Xd59JbVP3N
  igQ3Ns9NjerfEkzB4C5DT-tC1DXllIlCylxdZyKyQgJjeQishyKulvwXVxxCKmhDi
  qzAUOeHUbe8REig-JKF4y842BWr_WqsHrAH9Zwz0--xo8K42dI3KiO9WHscL7y457
  ZTBNAvsgfOgI8kEJjNcq00yY30X5H1m6-E82taAIQ9-9inpB4JS-8yFu5wgfRYzQm
  psmg-Zekay-GSGiVFj8LJhMbnnMwNrx70uTpw_fJfZjAUMgmXy8IN0kv4F3i5cs_2
  v5P-bOIuboI5hvHC47JoCmw-Sep3Cd2iOftzWr2YCYqceJYMlfoWhNRWGVOs86L9D
  XW2pvkBAUruyg_ZvloWeeVLN5DN8FsRnEYmHShbgrbAkFiSlh-LUEzjcfzN7RxBfv
  O-lH-zhXhzCR7yNLBhvvtjWDhihx1kjWdiWLKwBsl8FwXTxkhVm-U27tsCozCR4PX
  NpFBFC6kH9glT1Z0ggoJ2VgvfF8_ejc2MHwjQbxDrRzldjjUg"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

