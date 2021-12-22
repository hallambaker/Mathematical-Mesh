
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NCC4-SNFM-4GA5-JJHN-AE2L-TRN3-P7U5",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQJ-DQL4-6E2J-BBSS-4UGU-4IKV-YYQS",
    "ServiceAuthenticate":"AD5Q-T72M-LU6E-WWXA-3NMT-H26C-OND6",
    "DeviceAuthenticate":"ABW6-UPKZ-XTH7-DX2B-BOIQ-466Z-MWKQ"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MC6E-ELTE-77EP-WH4S-3SGO-CAQM-Y5HB",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ0M0LVNORk0tNE
  dBNS1KSkhOLUFFMkwtVFJOMy1QN1U1IiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMTItMjJUMDE6MTM6MjVaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5DQz
  QtU05GTS00R0E1LUpKSE4tQUUyTC1UUk4zLVA3VTUiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUotRFFMNC02RTJKLUJCU
  1MtNFVHVS00SUtWLVlZUVMiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  Q1US1UNzJNLUxVNkUtV1dYQS0zTk1ULUgyNkMtT05ENiIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFCVzYtVVBLWi1YVEg3LURYMkItQk9JUS00NjZaLU1XS1Ei
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MD5U-ZIWM-OOMW-O5N3-F7SJ-VF4G-I35O",
            "signature":"LJ27wRMocc53-H0wGllOpXcjw0lKGcyJT4P_PqtP
  iTOldGs9sZpa7PsBx7-hpUsHewc1bHiBbpgAefe1BzDhjYDwHtPNCRahkJmhaYiM2
  GHZM7XlYguBPXxyDHN9wHKYwbveStz6Zq_my3CR4seASiMA"}
          ],
        "PayloadDigest":"nagzOQlY-KxAriRZPASovkM06G42Ts4t-o1uNeOx
  6nJuLZ0h49C8J8vbgSQTh3bqygYzL8sWb3NZWrRuozolpA"}
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
      "Id":"EBQJ-DQL4-6E2J-BBSS-4UGU-4IKV-YYQS",
      "Authenticator":"EDO4-OT4O-ROLE-QOEO-C45T-DWJ6-RZZJ-2P7U-DQWM
-4NPP-BH5K-RITX-4QMT-U",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQD-MGRY-PYLY-A5OY-3PJM-CQZ2-SN7X",
          "Salt":"QXRcSk7ipKcQT8QwbUgfiw",
          "recipients":[{
              "kid":"EBQJ-DQL4-6E2J-BBSS-4UGU-4IKV-YYQS",
              "wmk":"9SLNY4ZmmbHi4u_AeK6aIxyvsF356Bc7p_QM503Pgq9u
  krPKyEvjPg"}
            ]},
        "NUFJHJxPSEhq2BS1BU_NcPovY6ZENX1myx-CMCx5f0ZS5DhRcAxK2dxE
  xIBwIvg5O79O_1uR8BK0tRjSVmYMoSLOI4ahrnzD5CZhq7Ee_cmeoxctjfEeXRdpH
  DlcWUvj6ZA0qp5q75b89roGMkAoqrzy00-k2jWiYYHYf0FTx9NNb0sfOESqYHkd6V
  S7QkFW-4OGVn67Y7gNkCFthkQ4ZlqlTwCWXrSAE36XK1iNA1dKbguNDUa8TpyX7uu
  BjP7epQSzz67SDUZ3TzmwxCvWJo7pTS2AG31I7UzMKhXcaKCtyEGIgEmmMPgizSK3
  WwtJncs6L2qj7WG6lcfKFMPv-Q5t2i34DrD8ZL1hw0gGLFD_wcFfkRlbYM9monWQf
  wqVbl9PiuvYxifB4P-QE6d8lV0mLpz-orXfON2U2CtDueqcdntuKm3p4q0Lxuj2lH
  B1dw7sszwHfSPNNfzoybQZ5sH0XN5dFzAs2WoK4yTjNBVUkE9EDSoyFTWjLzXTKZ-
  wwndiwvnA6gGDXfRDq9E2RSWBMfKYKfUEJvgS0zUKfPEe1hIJZO-6fOC8SnSsAPb3
  DfIp34nZK61jDBcc_pmLUkPeSkxyVLFFzMcB4bG2yKzL9SLX9Y-wO1udWV6ZMRkQm
  CVlHWYt5oIMxuBl_3mssXGu6zebouc6_tyJuFMrTpbATTQwJ6NpR4rnklcoce9_QH
  msZjWqhwaMgGjBHcIDshYIOJDo3pKCAwEaidVVd2Ei5k2x8rFIwGju_FvCs2LmYnD
  Q2jEJ9sVT9b5ZpIMSbggUsu9RNi5eLxoVw4S71goiPlMliuP5eGVTIDtcVHZdds6f
  LsdBuKPTWl38lnhd29lzeoQQtHCEAxKljJfiQWtBZcy2zmuiTdSfEupSWGf3dBos8
  JFeGo_byp1n_ucynRDaaOhtaR4cX6fQVmO1E2p1iykFFfeXH-pL-VEydwEcsKwPxi
  OMTNHsOvMQU6WL4Y2154I3rQAtgiSxtr_WWpxybhKOBGQ3EbTN54DX-j9--wDqaLG
  Y5fuvv_XoiOS-Dzl7BR7NCOxfQPtkYS-H3HLave5tgT2jzU8dbFqtz_LBRFE4nAfy
  EiqszeXql0bkrubTTJ3391F_TNj0jXGmAzy7mUB3b0ZolVh4JhhJb5H74YuK2z3pn
  ywvzM12_MbNLR2TnC9DLxoWYo0Hh3btNT4vrQQfWux6Nsu-uC_vHzibNLdsJ8122z
  FYUjFC3860-0EvSweo7i8dkSIRdABLJr-iC6WvjSMEdPnMvnm3l9wKeomRlwKsQhe
  wZ7l1rAQnpKTkyZp9tTsUectl1Pog7lwKdDAiymoKXZjiBSdapzvk9uDW6cypoKDc
  masC6j_Syywprpu834vYJLNnBv7q09iwbkxF2AnQP_Ts9zp1HKS9PlBwdttZdcIPz
  hpj5bfhLJ6N3abjxPTJntW0nPWZptga9sJSqjzqkNNsMpOE5YZftzdrO5cmU2Si6j
  OSswV3DtDcgQsOlmmnQr2aScyWhl97_h7_oLutKN5zVOZvUb_yKJ9QYi-MY970Pbf
  wI8RenGtdX4Ob0engZ9qKLN1Qg9jBddVnGdVC_5pMuZpvO3ZFEGi2V7V2TNGarQk7
  0lga1WRBKBWaX6eS7g2ATV_iOBwvXKkZUeTnjJc3PNXjpjaGjLDKjYcyelLfU9wpb
  4c1FRgFhDNG6KwT2J02meu3y7DbkXP1HB1POAxEVlZOPPOom9QxM8FJEsVTg2VN85
  Rb_AM3YfMvH4_6A8ExFq6IirjeXOJTbjUkt-vz65I40sD_131dCzaUQnQ8B5QOHh_
  uMleI_YzOexCkaBZNTSwvUhHhF-YEMwkMFbejoHDh8uCNTs5Ne6gT4tI3pCbjbRT_
  HF4jI3kJfzKlyVV9C3YoZAb0Vn9_cr12BkXQBF7XKer7pc28Jc-bDUnJA10RplXre
  Rc5KfQ2iZ854_m-sQiarIVf0gfRl2sZQawNOxIHz9DYpdmvDSC-HxKqlVzMFj4W2G
  0uvEOjcNVjkZxTfxOTKDErN3oeOJeUefUpKv5ADZDknptaj-2C_2xsrJouKWbbzye
  1fCthJqsUqJR7iOcGmI62YhJC_AWQuMXc8N5lyqwGeOdMR9aX6MAvaOK-oOhp0vwq
  7z9MzNXP07EjFTXBQl6nBVusPUc5Z4NVKXmndi-eQ-6C_GzmaBYwv89QLf9Mm7bJC
  I6HuFQEzOl1DbksrWgtdArWIhepMEpTk_XldgVV2yvne2lUoTgnhsrGRlMOi4bNpp
  ABKlopq0PQ4qL8JpLCdiFheGOgT8an2OtCXghw-bozclzWrstgQ-MrSxjF-RZ_AJL
  eZHLm7zo8AGusHF5eixB1GaX6o3MbnT8ZWpcnWQ0T1mOCY-toe1W91Xv2vkr_FjGE
  CBRy4_wrqM6Xngp_CtZDzjXvWUR6-rJTB3sfxhA-04P9Rq4JOOlTukapBEH5oKyyq
  FRDOR7dlQPgOXjSjEgNjkKh0iasIKrcRSm9mCAUeS72Af-FA6Clx5kws8Zwc_cw2U
  Hz5eUrJ1qQfEebnCN6fjSRjHc0Mw-6HIpJfA0gQN-jzC8vyzNKSZlJ6txtROKKP-Y
  O9lG6tooMe0bDki1-QMSQe8h7zAqz0PBtA5sf-cSYCKVGOjOgaOw9E9cF7NRpbYRk
  hs8IPCAIk4sdwn26iYi8gm9H29GBJ62m54ZHv_-rYYaWxcY364mC3tycPjt5BbGb4
  vrtim5mRjOKsU1nzd7-nmjFVDyd5M3-CIGqyfxPBqVeS2II1ZOz-lwNCEY7BHC8Ws
  ye9rs_6qj1gu9ev9jNwDJ65A1eBCukMsENvZBMDKmW9D6xaKguZf7Up-XH1_9DwzC
  PzEgJTTtWGQXK1AkMbY55dnxE7f_0gPSKbjj8OCXrvkYHMHqE0aFsF78l8SuLbH8z
  Br2pXD_2yFn338wFFw2qv611cvdUf0_u1VDyPwQKHD51-FoxKbDx0ahyjoE9ACSzZ
  ihLCgBbgwuApRsOAl6eFzPHuv8XvKtw6UV_rcCp4ybfjjKtzQ"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

