
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NC24-HHSV-M2LH-FLCK-S3FO-M6QE-YITY",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQO-RY7U-EGFH-6FNE-CBGP-74YV-7VPR",
    "ServiceAuthenticate":"ABNW-BQUH-LP63-NR3M-APFG-C25D-WSRZ",
    "DeviceAuthenticate":"AB4W-GT52-ZWU7-JU3X-RZD7-RTDU-ZABC"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MBZ4-H2QV-ZDYK-OASK-Z2J5-SKX3-FOCZ",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQzI0LUhIU1YtTT
  JMSC1GTENLLVMzRk8tTTZRRS1ZSVRZIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMTItMjBUMTQ6MDA6MzZaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5DMj
  QtSEhTVi1NMkxILUZMQ0stUzNGTy1NNlFFLVlJVFkiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUU8tUlk3VS1FR0ZILTZGT
  kUtQ0JHUC03NFlWLTdWUFIiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  JOVy1CUVVILUxQNjMtTlIzTS1BUEZHLUMyNUQtV1NSWiIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFCNFctR1Q1Mi1aV1U3LUpVM1gtUlpENy1SVERVLVpBQkMi
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCED-PMVZ-L4BE-WLJZ-2P4K-QINM-EHM2",
            "signature":"LzKgKDYJLN6QaiTcHO5YjhweaXT0ApmsKK5xth4O
  xH_dWeu2F3zUoSlV7xHKCG3FFeSMht_OawUAyag_AZRFdIUQI0dOe60ZZCaLs3rqn
  lC4y73PS24urOkbSK1z78OztdnHz8z_WwRvBqKmst9xGjkA"}
          ],
        "PayloadDigest":"F42C0hSoAhYKcavxXJTGGP-lf3GDzx_2iJ9n1yl1
  Qb2X-bYoDfciBO2UywTRvGFoBnztHmPfePjJalIA1JmtMA"}
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
      "Id":"EBQO-RY7U-EGFH-6FNE-CBGP-74YV-7VPR",
      "Authenticator":"ED7G-CZOY-OVN4-6JIZ-EHSI-LJR2-RBQF-O7W3-GS53
-I2GP-EYLD-QQBB-V5DL-S",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQF-ZFLH-4P6E-FWJK-TOP2-N4FO-HJQZ",
          "Salt":"S3qCN1HIz6eWqVj0-IkBJA",
          "recipients":[{
              "kid":"EBQO-RY7U-EGFH-6FNE-CBGP-74YV-7VPR",
              "wmk":"srYduKMRGza7sPNgbi4uVA8ROz8Boo0lXIt6SYKtdAaB
  TTsd1IXgZA"}
            ]},
        "U5u0U_hf1Qxbn2hmkQmlHnnGbbOX1RvwVM9Hb81jJtREMrrygAbOJqn8
  mwxxP8W-1PORPWDUV2ofWDdwPtr6uDiGUvF7fvhz2MrTNYwQIBp6VLnEmyxmovriF
  JPbp1hXJIlAjnjspXsR21DNPS-_P4_uweB6E0VSIL0DW81PC3hlIJssw8tdd2VP7w
  l5OUT8N_Gbhy6xaDwXesimTzAKanJ0j8Pd3_F4sb9a__YoCVVVtXnNauJvE42tcdq
  W5RtjK09TLf-zgRhd15FJQSfaEWTINPPXZjp3Hnf_pgx_PtE7Mwm43WFmniROB-Tz
  -sdEzPe9Vk91ap2b9Lzm4pl-dNQn1QozNwr5uAB_vIB2mW962hFVNFf7qBfaGDiVu
  dCTLrV8dmHJzwcSUu0kepdbxFIgOQjjoI0R19lfnY0dNCTaYtqOBnPo8Fy8-R24HL
  2vOfKFMED8Va-0zf9wOlAcRbGziCEnJALCCjKRCxZPl2KqJzKXBeatFGEerB9FZXc
  4f07p6nNe8cahb8VsKFEPOjHZY_6sWkdREDce68Xy4vYGwANqbphnv5Dh-WpKgYUC
  4t_VDU0rwCOi-zbvMeX4rwpUGhJvQde6AiIWIgl2ZQgYH7JtWqkKcZtbcMt6d7jhI
  YyZgBFWRaTmuENyNwjv8ncJgK1X8rW_FP0sNxpLPvl4-wq-Ev_i_kD2xPzyTrbCyf
  zjKwNoubdP03T_6HDQBZvx1-wPUhoCqtD9RZ6RKBDsrLeF4zWNWC9NM4vhpGP-Nfz
  yVKmRc2SwjtGDhFSlf7_Ah_v5l879xlSEtJde-c-3NZXFvwsokGvp0cRRdbYp1kvY
  F0oPiOMjlD_-28CMjMRerJEYJzqFVXC89Ogj4j3RfMTwbHwmzVcE_azVHtZF-Rurn
  Zpw036foO5gFMTh18oaTNJcTk1etb74LWguKwM1cq9cvPepRBZMFRyU_yEhwgm0aW
  G1u4PoBdL45RJ8Q-u5yjDnDmvANz3Q46gEZVx078CTMKSOq-C8ShdNTj-UFqVmq9T
  BzuXfZE0XKJLQnXCKCztIY3-Cy0kd1IptqhQX-_hRmmsVv5aAahpCjcbB0xUV4TFJ
  Q4zx36u4Kg1coOIicAWJdhqhsmvyP5cvwlj_Ba_xyzLasr8heLkANzdyu8dzYZKzS
  MTeJoStWsp-lU91pYwnMtCtUWF1FvjhVO1QBoVmLlWJiRhd1SO9d_Y0494m1kBGxx
  bQ_p9XhbekPp5XI8LaW0PsKkSg6ysZktvIu5-17jd0PSzGF2ZBLo9w5eFQwm_RLEa
  XNILfHiL-0czQ8xySsQ4Lzni9NDRmBnpu6gjbHJRIF6hXZhCWHMhQlvSG5JYvdNJG
  P-N65dMvSfu01bOQ4Mt7lbvxVq_KipFfNkZCxy4TNszXieYtzZ12fve_hauLRjMGO
  lygvwYurkMn-HXujLRVeAdGVaCzqdNblS0_qJkUPYavq9DRQqEz0dof71IGRG7c3n
  1KPyd1zDf63_kOScvNd7sz4bH5OluEM2ivCSc_Rz7C3QjKubjNr4aZXEJOsE0-Qwg
  GTvMavyty9zFgL4vC4AjxZ89FarfPLyq1rwE8dyUEDyrPQ0gONoC1DBzIy5ksPMRe
  uunRfGojH1Si4OuwHkq261NpODbORvhUdH3IIoXjzUM-fMIULIClVQwwu2t7RPsYF
  H-yEsaU_mJOQRjy5UogRWc-Isox4GxKPYMtkbuY1u2hoxLJqqsKGL5k3KyofT6wVy
  tfan0iroblrx0iMcraWuBzikWas6LIh36014PxQA-DfJnQZSh6816YqZLJ3n5aFi0
  6GeDNuqNReLyxSgAqYVJDfUoFAovMsO-iH32ghwoANbW-qFqr7P9xmMfTsfvJBaG_
  fwf38jqYNyekgzlvL6-fh_x5HFoahz_IFFX8QYPrQH5Uuz_ny2HwJCWqvGzHXAx4J
  1vIxxhfzGgt6vwwcHQVYb9R4aO5jt_sfsBSTIJM7VbQm89h6NavS3dnoSNJz7yjxE
  xRodgZODs1MgU2D1ZvW_AnVUYTwORaUwJ0nlFH08Oh3M8Eow4EkueDcB4zwDIGw4R
  Vuh9MYxzXPf56cGbQssbUQQam0HhW8EdnGr3ZlGGvJQsDvrz6rgK_uQAQ-gDS4Vxj
  K2EDaK1u-nbLddhCXoxn6R_88JjNXgr4DaAd3z3tWS08IARRog1PJpFr94MufpWrc
  HsG3BW9f6qacgMaUIW2Fc9qaktuUVj4R5Ad2mdirnouXdrDcJA3tjYb_oF3CDgpc_
  _UwcbxjSwkOxTvhzpvm7vRr5xsxPq5x4DGTWo1229I2FcEBI2sm-vw0UY3HZo7wzd
  Bv9R0RNTy-tWHvBMSTj4_R0_Y5FTYTUHJSXKTzzYY25dUddQpl15FqtplxsZbaWVj
  cEV6cB-Jd8v5voQl-xSe0RNNBH2kCrCtFrrNvZsbdcGxANcvr7wrSiUQzuTJGR_Xq
  HGgxbC9CQr6RpqyWiWs5iTBMXps23CjBDRzHPzIhLYkg9k7vq3cV6CfjYvXGe48bH
  l0qT_GBQ_sURcIFlX897F8neWdhcDLAWoQlUPg09v40_fWtgc8kI_KPsZsSF0zJM_
  RKQeA444yZwCXV6IdlojHnRSFiE6Qa1EEL3gZ_u0hcViUEQ9TlVlqZwzZK_VIsakS
  8VwOn2Q0jXuepwwYb-9B09n6JQwj2PfBSTA55gGN-D34Y65JeROwPtpm5NiK02r0y
  g7AYEdq9zzGW0RWBOmmy9ycTrmo9KzDhdlqOhjv90Bf71lhc_5DI7-fyCdWptGnCA
  SepIhA2rHxWQLy8nG-9pgGSaIFD30zkYbPeMuTlyA7QSx5l-1E-c17qjDRQVr1FB6
  aQwGapSqYFp64EvVGC3ivNLe63Z2SimznNy5yQ7mrG6tWdk0Lq3AUOYH6pZqnGGH9
  4TMW8Ex4C_JtV1q7wfSTPQUnqXTW6-0qZDx-XT_-28MkSS_w8HwQoIV8KpTzzyhon
  dZARIp1f4x3rkDxh8Z1MNnum65zXg4gLcyICISKGgTC1XJ7pg"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

