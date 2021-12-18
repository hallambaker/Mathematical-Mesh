
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NA7A-WS2N-NFVD-JGC5-ETDD-JONH-BWT2",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQO-M2NS-6AV4-BEC4-CBZM-DH7X-VTAO",
    "ServiceAuthenticate":"ADWC-3ZNV-T2XC-NY5Y-2UQI-N2D3-ZXJQ",
    "DeviceAuthenticate":"ABQ6-G32X-3OLX-YZO4-PTXM-5EYK-HEZE"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MBAB-Z2NL-PMRQ-W3EO-SHSN-6WNX-KC5Z",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQTdBLVdTMk4tTk
  ZWRC1KR0M1LUVUREQtSk9OSC1CV1QyIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMTItMThUMDE6NTc6MjlaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5BN0
  EtV1MyTi1ORlZELUpHQzUtRVRERC1KT05ILUJXVDIiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUU8tTTJOUy02QVY0LUJFQ
  zQtQ0JaTS1ESDdYLVZUQU8iLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  RXQy0zWk5WLVQyWEMtTlk1WS0yVVFJLU4yRDMtWlhKUSIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFCUTYtRzMyWC0zT0xYLVlaTzQtUFRYTS01RVlLLUhFWkUi
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDO2-SNPT-H5ZY-U5HK-BPC5-MVGF-WHT4",
            "signature":"j-PmlnPB11PQbDWp2OBkls8yYp7fp_cv8WZ4SSGq
  56pT7XvKL25c8miXkIlftLn4d3AEb4UYqfCADK39gJtqG1ou_dEN10kyrrQwwG8nB
  pVShMnKtbyvpeJzJN05004tPADQbh4YnBRVLvzsKdxgDwMA"}
          ],
        "PayloadDigest":"VsR2nTKVewXHnM--nNKni2QArz6zOI-1xpWfIj5p
  EolqlSILJ1Bdtqtv8I-GVVyvoNfQbknsloT_M52jrz6iWA"}
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
      "Id":"EBQO-M2NS-6AV4-BEC4-CBZM-DH7X-VTAO",
      "Authenticator":"EALX-B7QN-VOAD-ALXV-FTC3-AJKB-2BY2-ZPZD-P44E
-AFFT-PC4J-LR6O-GKKS-Y",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQA-WCKI-IBVV-6TNS-4OAT-WTFG-UBPE",
          "Salt":"jfMSsc0kDbbcqLOXIoK1EA",
          "recipients":[{
              "kid":"EBQO-M2NS-6AV4-BEC4-CBZM-DH7X-VTAO",
              "wmk":"KOkv0Ovzdy1wMEAwcF-c-m1Swb3NCtKVREfAFTVA51zi
  QegUE9iyLg"}
            ]},
        "N1NeVlyKZ-2I6dz_g2rD2A9Xm-YkVDCgLthxlXUGZPyOGLUL2r-3j0NR
  hbQqNpd30AMK3BqmqjJHW8mmqPVDWiJrzvl_jK5c1PGc5LTOD_Y-JqTeNnOrzwFWq
  2x9h7OXoJjzBbzQ_EtUanULKgNr774w0LS3Wzl-ORbfYPMjuKB9SY_UliB1CKe5NE
  1cBIvvONMITq5JIi2oyhL1N-iRLTCwwn5_fbQ_KJakxu2gfoyOa2IOakV-V71Ike8
  xTAFyhc-eK9vXlF6NXM5x5SRCYfj7RGpDUrsEA4uF6kcguhwv6MoTdR8VHeH_Ajk9
  V4FFRPi2txJOPV-Xh8xE_gPW8RaETSgodS9nzx4JIYqMHoZyR1b_OZ283nNWSTP0Y
  YSS4B13D_qb_d4wrCOeXeuH6Ka0zx51DBfrKzqP7D1Zfit6fQmiD8di6QroxUZT7-
  KYp5XcBKLb8lB3ATnBwYUrUaPmGDWv2x6yIPm584TxVtiWBjTLCr8a0hIhToj8AJB
  xtia_r4ie-IId6XBQd-8xmw6XUdHrB-nS5yrB4nrkqJbhPmQB1RWOymgF0prKcQDP
  1-WC_bpA16YHciXdIIrZ8aUJxr_fwY78O6vkr3Q4BNGMva4p_GzIprXkvNXQFehwb
  cTfX0gyYtl3J8cRzq03L1CvPZZ0h0XZgDYEGSDjzXv9PFxgtaF0_v7j6qYJsIzkLU
  T2jITYuHnk5jJobFnAtX7vW3x0oXgxB8PRkXKh8ZCrWvISMJoMAGejs9yIbz3ffRE
  wDkiwzWxQ25-dRgWTo_yoUHXQrq1zSOGxNqKzGFZFmUApxe-pGgeD3GG_6fPtkpGZ
  PfpfU1dNWb5QC9W1SDgzBXn3VhNPzyJ0q0YUIFjHajR4o_lpdYHXZhK74hLTTVCaR
  UQmHneiLvCIGX8XAcWm1jkJIKzdV2wS1sN3_CNwbZ68vfHafD0iWo9RS_7-uQQDf3
  Yf8nXxiSmG-FWdTSTCu2AKM1ILd8it3fMCXWnBJ9y5N9-r6bzA7qA5np0-CVuVFGj
  80f5phWCvfDlDaXHYcMEIjOby04J38KjJ29OKMzZqVhYo-sd9Y4GDgoYFigvzwPbu
  uBJvmKZC_18VhcuiALHv7qZcqf5jZvUU41RC2xjciO3F9Vw42VMhlhPPAhQbB8eU4
  JFqdg7Y4dZJn_JTwBFuskSwEKt-kxajDEcQyp0L3xy51Ls-6_687KGGjZHFZTHpuA
  pAeU3IieuU_KieA3lKH5OzYPPgkgWjG_noXZE4mGzNjd2f2sgtcrTxEDKLRpDXrcE
  MyIDQho_vwp7rHEVZb2wrZDeDw9Dy0GMrBvuQSXuQEvffjuYwk5mrU9BQ9fr28VPW
  X6jWXjAblWd4xI53tIe8xnkS84YqOurT4A2l36OKOJshTQvaaphnGl3aYmGb1E0AT
  4GHGeVSIB8e1kJW2lP74hCyZrb3Xyy4h7xsdepzTJYzTevRR4rj1QDWzIjDd2XfCO
  WZJBmOFEQ9U09IrL4icGwGA_WBw-N9G06bWbpX0qSzEbxlccvknOIQPh2-fL8Lub-
  WI_hogr2x1JM-33tTRL8qNBaLEupJe2KLKqeiYZS_g7aLXv1LHrco94vJ7jtqbGyb
  8R-kcKzGzpT9KdgJW7aUaWVQkOLZKqiht5wKcKwGBtU2c-uBYnyXdAPuZYzAb0Wpf
  AHPIv19222zE7KOfKHHnuw_oO1CRAU2ZRCRp50tc3ojoE7EP05Ol_WTUTNZUZdaiG
  tgJOwQNrAsOzJSzUyx6RgKQQ0ZG9auvSeB0R0li6PAdS_JlhQwo8wp-wVWv5cUbk9
  poYOBHJmIBHPxFfL0K1bYHZsBZVIJsqMK-xEQeT2xKlqy9PorlMICzsw0539d6bft
  SHoPXVZVohrMUf2phwtUSfXEcTtYLjC_rCdpBS_oyKa9g9Pv1xd2R9vjnK46BbdBz
  7Jdj5kxlyGNftmR1jbmBUJfvpjOEfDiAV0bjEZZ_Hwvl_VtXCDuPw6BHhm5gvgKSn
  L0bHpZVAwI2WaFQuFTY7equ13kDr9PvNMmVFydfe93Ooa0G6U91Lc3_PDx_ohJ2dZ
  Yr5BXt1lVIlH3qW5qoKaf48wmZgDScrU0gfEhg5XuYji9oHiu12bEdvk_fm-RCTgJ
  -n-Kbp_cUGBXvpe7RH0c5r0ZDgSmZiXyiTogfsTIODjYdwYzaJWiH9WUlXPe8RZKY
  wzHEtQlGJZ9yPlQsa57qcoYpqXUS3MnwSP0Ph-wQs_stS7wTAJ6pui4C-N72CE6zd
  xqYbsltL7Hjz7t7t3h0WZoDlZfBaulv0yeGE-ZuDv6TBcEA6nC6bl6WqJS77XXsXk
  oNr2v6GCaCBRvP6O_48K67STH6ZQYKQ5LLaEe-SEdZoceine0F6Nfn15HLPMKUol5
  gxUh1xksRQe-3owXBRue84Ndbs6VbT3cwnE1Z1mM-LaZYfWhPa-a1CHqsmeUJzI9e
  d1tm0sg0Jxo4nikKAqCcnFLmnKSHu3rTSMri4rxrg5iD2WSLwVDDyAMpQgyyJc-av
  dWz92gkC9LFYNi9w2hEhTVTsHcf-ieefaG6CY3E44qWuY8rfPI7L2Vx-BSBtrDxSu
  8tpR3qOHsIiw_7KDJu7aINNgj_h2_wIxlqgcZW5ZmBoUUvdZsH29metiLmhOyjzBk
  9OQoEBfA3Ewe9I30d79MAvbC0FhsMPdWf0my-Utm4tdaH0Am2irltkImrtDv3SOVP
  SxL_IuJ85JuLzsiAqYMrnrokExVLYPYcH0ZJZim0GyiRSo3mbqYXq28LOlhbmdhBk
  -9J5BUDt6eSLZl3158CNs_EJD8YeSMdm_3Lv7m0NHM-4i8DjtMhcXP5eMT0Pta1hA
  OelBktCAwjH58WyiQeYgKvpzOqHN-sXQgLJ6jHOF2b404Ql6v8UUghSQ8YsiCUpOM
  GcD6vyE3-kpvsqmQodG8VJvBJzNV3Tap3SkKGJwWv6kakZt0hXQgeHICPdq181vCG
  z7XXo-ylfvD7vQVxdB4p_54eZHJ5JC_ybloo0Vyi1o6v3O_RQ"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

