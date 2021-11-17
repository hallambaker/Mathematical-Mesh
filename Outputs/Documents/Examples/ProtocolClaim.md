
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NCWK-7ON4-VB2S-3JOX-6QYI-EE5V-QIHM",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQK-LU3P-VJLT-ZPG7-B667-L53L-MBEN",
    "ServiceAuthenticate":"ADQX-SBRA-6ACX-ZGGB-IU3L-2TZS-TIKZ",
    "DeviceAuthenticate":"ADNB-SNE2-GEL5-GQQS-JBUB-TY32-JGCC"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MAKC-IPPQ-POEQ-P2EL-N2FV-OLED-GPIH",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ1dLLTdPTjQtVk
  IyUy0zSk9YLTZRWUktRUU1Vi1RSUhNIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMTAtMjVUMTU6NDk6MDhaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5DV0
  stN09ONC1WQjJTLTNKT1gtNlFZSS1FRTVWLVFJSE0iLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUstTFUzUC1WSkxULVpQR
  zctQjY2Ny1MNTNMLU1CRU4iLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  RRWC1TQlJBLTZBQ1gtWkdHQi1JVTNMLTJUWlMtVElLWiIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFETkItU05FMi1HRUw1LUdRUVMtSkJVQi1UWTMyLUpHQ0Mi
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBUX-YI5W-NTAH-UJN2-4FFC-4PAY-NI73",
            "signature":"fxh1PHK56aMoB9Qkbx3Kcv4UrPQkfGRCd9LwW4Un
  3EcR_EqxpWaxZjcXFqdX6d4j9lEStBR2QxKAE_GCYpaXVOLOAVTbb4pwaV9fLDo8r
  FtlKfnFFoBZMslOfqcKsJrAnc4AQsT2H5nu6xZ0dq927jYA"}
          ],
        "PayloadDigest":"wMSgIvLpoj69Rw_P_YJ7yXYvo18eCvgU3Hd8DgJ_
  07Jv0nqIkC4sZMGFGW6Ntl_3PVwk7bAj51GVrPwqzZ12sg"}
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
      "Id":"EBQK-LU3P-VJLT-ZPG7-B667-L53L-MBEN",
      "Authenticator":"EAYS-MGDB-YH2G-DWVI-TTWV-4Z6P-UVLM-FENY-Z7MP
-7ZYV-35EA-6GQK-CHBN-K",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQA-ZKEC-3A4N-DSSH-TQMT-6GON-M6G3",
          "Salt":"9PKNerq6mIRxK2feTIUJ9g",
          "recipients":[{
              "kid":"EBQK-LU3P-VJLT-ZPG7-B667-L53L-MBEN",
              "wmk":"W-lDFznmpNx2ZcN6_eWCG0ja0VHFV25k5TVdBMMYbAPc
  ZGPZvLjlww"}
            ]},
        "I01c378amieTGSky6lqXoT8infXsu_EwVamZ6Lp3Q_Ent97vfxdOY8m1
  g_eUVW7ui1Ede6raopIeC7ZWHdZOlfHDV7agFF6-X_5CmpIDCTl10ouL-PIVkXJik
  2FB2KOQGwVqMHPrPu6HpeK4mIro0OpJmGJksPiBezVxEq0NGzDw8nbANsxr9tSdsO
  4sJuApk7IJUZGZ1mSaOdqUF8byioqACRFXDie0-ox23XItR7IOwZf--HUIHnPEtnv
  _cxEwCKdAiYus1x3n3WdAxZc9_rqAY-FgXic0qZetde6uHOapnUeCTdnHS3-x84DG
  1XaBqthhHMhlwFz0CqftYsB85EjorNKIjw_mwqMmX2QnVSVkhLKW9NdA3w5_mzfd_
  nJk0SisY97xeuIsl6-imXTM8LEdyQpuiilK7R5qr7ZaYFya9SCje6UiOmbL8dVqjF
  zvDTMQRQ2qnYJKAGDI_Z7P8ehqHkpRB2ZDF-5WQh3JnvnYyW5GTJwNgg1ig2iW2pS
  QqIXd-Oe_DCLITFgq8ncfM7mEhaXcJUQe01Fj_c4a3oOlhfmv2ts3iK9dieba65Kd
  LOWaHaU2P0TivQQImMg-3WhCWfU4MbpQlQ_3yEZ51QPGVeUIV0bj3kc1QbaBAlJaB
  ch0_E54A9TRWz2xmakyjrEuvSi5aPVd_s-U8DrSDR_YqXSedhMwSBdGqcW7nybFMK
  gOxomDZyHnEbNYvwN43vHFDuOyvQWs_dRRe97ylx27VTcAw7AhAt2s3rMZeBwJYfS
  rJptABHFEeXPE52g6oSuzrHrG3P_ryAalSh9YuoKEYV4UXG8_9B4d8sOD8s5O3j04
  -7Ix1LhqIrSDVYBmn8l6l4nJzSs9_9sbBWtAUIozPNL8LqhbDd1-qOGNjNyt9sQqV
  QX76qD8HB6EtdrrZsoBewmwohlLIatHJH_909ANUD7tFJONkcyQAXaU64B-j9Z6rF
  4vh-9UxYlbbHrOhi9C0kpbnsAsAUzltg8_IvnH8JSTZI4J13WYWkYTx4BUjggX8cV
  ekob4ZZupdcfS0UnNjKNqGDjQ8IJqrMWfqLllnnBQWpSxsRoRp-ernxQ_Ax8pnWtG
  oMXA8yc0WwAr4_S_YQQ0TVxA5KRdQZqF-NC7NX8tacAS8CdPfJwPhjebhDgKwJv0P
  ccyjqJ8HFtV9YsHxfQQjyxYyA4QT8bvgI4JtJsa_YQ5Zw92tyhb-SwKHNiwnhVrz3
  _z6vQPfPdQJUfMtz6GC13eihC19_0vM3IPATyJcenZnQz3rLOm-cFseviCxoLgN5a
  LZGCrvlWrwtfN5-evHZF66guRy2fF3BSM4eUi71r2ehU0kYJ8vIjx6NVWzjL-Q2zX
  1WHL_bJOaLp0yHV6_2jOTBnaj6QT69Dp0ikXwEEtVzpxVUKLHbmpje2EXXIzNVlFn
  MM65KPT4OzxyKONsq32-xxIi5sxS-woyXxtDv8atRbbE0KPLtLfgianqok9rx2WuN
  JpjjpGcIwKk8O_1MqFotKIlhVPwCPza688bi4lESyruslT917HfyVyqfKrDyTjAMK
  mYAGkVaa3ASVudNyhJP8rQWwwc_qxruMMQrCe51JvKh7FwsIL14dT6HFnaNcLXSDE
  LU7u0_jcViwpu-EysogSeXJ0Z31yG34ve0G_h3K5dN_hk_6PgfK-Soe1dhReVrOb1
  JWM3oUmKUv0Kx-XYvsWB_KiuJWRqKePmIhWo9_uZaybh21PoJ75Ct5b3Qk9u49RKf
  _x17YE11VQBMdgsV7TS2Qpw0olk4yNg_J9ZjTu1d9UBjabTG0FqdYkeEscDPyIoIq
  7DreogM3Y650nqLSpdvJRnueJI5r1a_J9UAVzmk2TAr33fA1VlgmpHptd_tl5i2KV
  TvMWkL1wmSncGcX-krfCQAIH9ZBmjyVwgurfR9Q6UwuDJYKiRgLLE14ZJmz9hn_j8
  ki253lZaYCEYR5F7-nqQpj9lVrYzb476McYISLHzl2SDQkC7vkVo0OZWcsWBjrcWF
  MK9LPJMLu8EO6TCf_7rRwZ6SmoDOupGVCWikGuAczW7lvCtKty-r_oC1YNGeOxyqG
  9lTij6EzXDdGS7CHRRolDtYnB6LDLdY8hYQ1cncW3A5g6RHrafChrEihem_0NLplw
  2yPofZGIzhj_gMcHx7Sg_ExP_0cS32hU1LYX-Hcc0dK8bWQll4a7xsU8dHt8TNbLA
  5VuP_bPAv95fTFQvW_Lj6-GGyh7gH2bO5QffpusKAddsisiIdGvjr-hNVF99EjsJF
  FetvlCP1CFipmCuxo8WgXiayK-_b32Rvav_BxZ4YIcZGRsrH5oI6JywKyg3O9TAwz
  f7853NMhqsvnmLyhGC6Ezs7tQ__WgYqNcfJfo0YG8y78nMvDN2np_pDLw7NRGFhJj
  FrVjtdsj7E2gCorPC52JdKJ9jUrQCYpSglZU06CGTRQHnQvMk-H2ftQ4AFVEBJrjO
  6527KYwSylkZGMV2WBsrDsYu70Rs1SqI6e-u8pL_VdYPALWvD7SRVPCb90YoPX8lh
  gZR0BeCp_kNN6C30B9P9yWRR4JdTsG-LcWtK6iCs_igIOCjfelbsUBXTs7nxI0m1P
  mzlvPzkN3Acwrxa6HUEA_tOLulovb7i04IeDb8nKZgiO2Dyohi4aWoyFY2ExsQmgF
  qQLExsWPbYJiZEc5BM3idhRDzvjnON7aPkvqq568y-e3d3OsRXV9uKikFJghh89j5
  HHZ3HhTeIHAQAfDKVx7vPUls_5-mleI2v_ZkSag3vXRb23XLfI3x33l_ZxW9MC7YX
  _kdJgEqQiJu64AvYWKiA-Fd8uEQMfaUpHamNDlO4GFQ8uLWJ7cKkuDbbbiOfiT5z-
  77DQAMUiIjJ3mQ_kmileeTNb_qu2jEdJGzx-JQagB7ZIZxn0wZpBSCthhG0uXsERa
  XMFamXWLYZtWdWyUSL6AUzcgRf0RRmcvk7yvH-T3dGiIJn4TXOnDp0DBW-MByTeHv
  Wrk5k24lpPq07QI6WCdj4b2qSsY0L_eW6zbI9f7Aq8868WMxQ"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

