
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NB2L-CAZ3-XO2Q-UVOQ-3VS5-W3FF-QZJL",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQA-YMC5-YUXV-ZHIP-N7QF-XMC5-EUM2",
    "ServiceAuthenticate":"AAQN-EP4G-SFOR-NPUM-IZPR-FR4J-TPVE",
    "DeviceAuthenticate":"AC5R-D2D6-5RPE-BYPO-6LY4-E24L-XUYD"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MBSA-JBQK-WK45-REXT-ZUPA-SXCH-WAJ4",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQjJMLUNBWjMtWE
  8yUS1VVk9RLTNWUzUtVzNGRi1RWkpMIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMjFUMDA6NTY6MTBaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5CMk
  wtQ0FaMy1YTzJRLVVWT1EtM1ZTNS1XM0ZGLVFaSkwiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUEtWU1DNS1ZVVhWLVpIS
  VAtTjdRRi1YTUM1LUVVTTIiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  FRTi1FUDRHLVNGT1ItTlBVTS1JWlBSLUZSNEotVFBWRSIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFDNVItRDJENi01UlBFLUJZUE8tNkxZNC1FMjRMLVhVWUQi
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBRB-NDTB-27WO-3QAI-WWR7-7LWX-B2TC",
            "signature":"33hfejyBXIXMBm9kXbiG5t07e6d8mcKs9c_iKBxA
  2xO2leOGo00rOEHMdls8HOBSKLPsTlA4McGAZQ6Som9tzi9M0hDcy8t8yPZ_G92DF
  LphyQHT_wgc9fMA5lofeFmxImk4aGXlqpuu9wJydPBIvwYA"}
          ],
        "PayloadDigest":"5HiTFnMRkUle8WMYTPI_I-CrnHk-UplT1oejzpB-
  lWtAJEVrLBZco3JG0STHmrQMYSi-B2En2AijvEljfLvzXg"}
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
      "Id":"EBQA-YMC5-YUXV-ZHIP-N7QF-XMC5-EUM2",
      "Authenticator":"EDIP-S4KX-OFFR-BPNT-QCSU-663S-5QAY-IQCS-SWHX
-6YZD-X262-J4O4-2MFS-I",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQD-7LAC-6WGG-QMG5-Q556-LOZE-3KH6",
          "Salt":"NOEskM6bBde2AzGO947tYA",
          "recipients":[{
              "kid":"EBQA-YMC5-YUXV-ZHIP-N7QF-XMC5-EUM2",
              "wmk":"ZxaEuU6wK6_SC7-VhRVwrPYGgDewS7YglsIyBc3ZAtDi
  DRO-jp3SIQ"}
            ]},
        "-oT1BQXrWHDwxZGGGI2alwi3IdO5x41Ap4oTdt1CqwBh8x2lyoKhTGXU
  6WlYXFqvojMx5I4dwrQRkJ0dQNN9_EMsCjt1wol5jvRPrd6QG0sIHoKhcpC5ac6dV
  NPpA5IzgiEWt50NzOJoHIF-5LX3WTsxtK-Y33N8TuTPiDSJMVJ7ccgFQKxJ0MI7g_
  B8znIwxMurBoqkE1GK6LFctLMOpw3R74iKKxnz8i3B_0ijsu7XdDae2d7u6lEHUq8
  cGBTnnarZUEE1Bvj8It6-GGyUaigfALV5V8hgdKY-MJMdtjLAiBXkb3D7a7IRptEW
  JjFkDd-YoxWDOG8XaEtClQGRZJFYHWQIa5OSrhapP1yCjVaHxbrWXZkU1leZWaHwR
  rAgknmxU0I8HINu1ZpMCpK6uBQYSiBNm7vqFMwz5ThfEYJWeM3uQq5GQk3ztilGa_
  WVenfW-tldGuxQdzQaDSPQs-B63wc-7a8oVaTzmyW-g_N9HptH-qtnq2TFTSibwYv
  EaZKknuPXhuvBzqAkXHxJgHqSi4Y2PbTldcXzBBFGx4Aogk9_K7td0r0bnQm4EG71
  q4XqcDBl0vBw2TePyv_vzQWmAM2KQyInFmf6VQJoyRYdahct4iXeD93vLNqXIfu17
  EZOlFQnk8v4HYTMCAFWdGfJXrZXHUjo5sN_9tk7nRhFSUnt5DjoZWuvyKm3baHWJ7
  h95RJsz-rTm5CELofmfzDJYWtExv24KQ33-Asd-xy_7Qa-ff_xcS--oYZgsw4YwhW
  gi0XBDNHmkZrV2oXvtK6yQNXkNIyJF0MH4rtEBUK8OD6myBuk0C_hRwRjgBo-CAIi
  i3rqNBRvNaEBkHHRDhklduefkoCxdnbLbcBoenGOiXIgM2207Pe158FB2PGUH4HvK
  SmIN-1D_q35cbxpnCKfIiLyQrBWljPL_Cdi0hIRTkBRqb0W_0ornss3ly8xxVUpOr
  8AO1b8g6L3rBpTfoKEsfUKT3k_aOQrHQTeycCuWdfW98hg0kyIjXF00tTpYt2dpbY
  tvvPqZbjsoyrEteMrD-OO2-so3eGBnrlTW9ThMjQTlpy_ZaPgF2-_j1k9CitDqyL3
  P9YUXTe3jTLOI31glEoxU2rjgsyX4iCiYZi4_5eAfzdgnedAPQQqgr2YyutCpZs08
  yQCWSpkjZc4fMf-VH0E4fhhGRcodqLso90HMR1iIESoSTcm_Pk8rY3cZc8KBg8zfj
  WUyqP60JUNTZo8abUVGA_dgCr9BnZtTEaFhhzFM1oc82rpNVHFSxCeCIvu2u3G67H
  qnpoYl0h9PrJmunE6ZncY-_RVxS0TDfptzP1q4GTLIj5Rtpf6XsnTNwBUSGByxJHE
  _BYtbiWBzjzTfceZKYIuyhr9a12vViMAG2HjLbKA_1VLjlUzldWRi1DgpYxjFt3Sa
  twhPpUNQI_5jWGaOWZNrnrV9JuxohdKPkTXiZqV18zgK2mk2ZpHO9su84JmtaVgNx
  hsAF2RDDL4ZRZKKePtqM2txa6GLD3pVRzsBFx-90NGdXuhxKDPx5TFeC2ILAIZTt8
  3hv-ejcMYFTdKSU9_CES8l7OSQxPWiCmpheKiJqREK1OqRk7x9fh1j-9ChWZCjwCQ
  XPxQDg6zOQvXr1sOHUWRf09eFpxXhQPk1gY8B7_01rQIorDr_i2KJOMX1dnILM1La
  4IYelsMg3woIYrzPfkKzQBhokeV5EybPfgWDF2TiPBETznohcYjjXj9kfeijgBVGG
  q7kLZtiUPPWArEK0mdz8ZY5rg5su09T7KfmXUCNulXoX3ONe_Z5-GpSkfUuBvZbDZ
  dnjAFP9X8Zfv9CG5J4cP-Se15N4tj1-3sYUBXAvlQfMVJB9rekL2S0Q6piBlHoQcV
  hBqrjzwZh7Ztq5itrSKFDIu4RfYs-icV_IIov6UXhRmEaEfzqvRmSSE3FJTFV1QzN
  RzxESBJ1ViSXkcnhtfADR-iRPM_ovTNyPLylOFjWx3LuVQ1qojiRYXyPAtClVeXKf
  GRzzkMJQFQQWJVRXWiMKnDjZMprVxVofiUxPMeEEqmmmQK1RSVIpU0p0G73fO2fis
  MFKWy1Iqh1ZZf_6NfpmV8REr-QS9lsgbgdIC6Z6Uami2e1va4sCo-hPqKPKIbx_cj
  hfh4eY4VP-1bVfwMcGnI-tOoPZGD8ST36yJKZIXpDQWNFzT4XeV6EdPBGqxjpYWvG
  nweTZ0qgPCwyJ3Ledc6tRpD_QsR-zTDl6vdKSeJ7B0XW903TOWH_2c8VUtPIxs0CU
  VHRGU6nDo3Zut2-uFmBv7j6llgs6MjNXnJ9Z2eUESnIt-_e1Q4mIvzkBYLhRsZ8kY
  5_jPY6v9j1J6d9jD2z_igMVs30sJgdMSSc927swsA579vrwUA_TYLSjjSiADptn_J
  -KBdrL9cP2xiEnImOUe3A-_30lGd6YO5G8wTWb7N8X8xQxuYaHqDfniF5lQJ0tQLZ
  _-mkgJg8BiMJedohjE5VYzX0X0klgYSjLUZRfVd_PfXrg5UA0OOAvCnhGkKk_ULXA
  9Tw690rZXxNpf3l3FSamAcNqvnKB-H6xOCHtxYAJJvC1QbPOsMYgISd4Sk0ewiQOh
  K5GZ7MH_g4jeT9QFO_TK7b8QTrH249qYZSy2dCm1nChvJK7_JX2Ttwyj91ncUqrZ6
  mYEW1hj0yJab5MuFND4EP0bpNlXeAHdjfJ2pkaJ2StOZ0_60bwPf2yH5gKGsURbZ0
  zIBVtG7VeFVbUPHqfqtfZ8FBK3bb7cy-GH7gWHHTjC7xt2zwRMpRJC9SlfW91sq3J
  SZCbo1uolcvMtq-Ztg8tNCtWdsXxtoFYlJ4UMW06S-blCWrJ9VZVSu08L2npiofos
  5HhyiGx5hjKHwuI-5hLaDofJ2ghIIq07MtresgH-Luk5tBT-YoDrMxP-Hi_rfZETk
  b-g6qho-hgW9h-ewkDa1Nf1ZHcOeJsYPurQYnrqi4VxudPK7XbsQYIciEMe3ngHcF
  PJ6lJd5FKCCWiOk62BvcTxEVCJhNXInmpSS3kApGm8_Waqeqw"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

