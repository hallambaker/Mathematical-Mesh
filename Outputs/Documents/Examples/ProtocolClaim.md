>>>> Unfinished ProtocolClaim




A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NB63-SW2W-PX75-VSFP-7DTZ-HDA3-GMFN",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQE-U4SE-LQ3J-GARM-V7YL-K4EX-6AZG",
    "ServiceAuthenticate":"AA7L-4HFO-J3PR-PNFP-UXCD-6RQX-KB5S",
    "DeviceAuthenticate":"ABUU-2IUB-T63L-ASO4-ESIZ-EJK6-SHIU"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MD4V-BRBS-FKWY-S5MD-R63Y-LFWP-7YMN",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQjYzLVNXMlctUF
  g3NS1WU0ZQLTdEVFotSERBMy1HTUZOIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTZUMTM6NTM6NTRaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5CNj
  MtU1cyVy1QWDc1LVZTRlAtN0RUWi1IREEzLUdNRk4iLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUUtVTRTRS1MUTNKLUdBU
  k0tVjdZTC1LNEVYLTZBWkciLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  E3TC00SEZPLUozUFItUE5GUC1VWENELTZSUVgtS0I1UyIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFCVVUtMklVQi1UNjNMLUFTTzQtRVNJWi1FSks2LVNISVUi
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCEO-7AAO-CBE7-72WU-ULJT-7GZX-FEZB",
            "signature":"2hkU28A2YPz936ULoRfI_OC1KyEPVenCyc3scNEY
  acg3rXRPMhL9ZPUSdLx-n0QvYfhaAfWmcYsAcc0Yh-ipL2zuX9HcdEShetRcmkSzZ
  S9_mswT63EiwZAj1CwwZH2DWvaWnioQIeCciM4JuLHFoD0A"}
          ],
        "PayloadDigest":"CUPOJ8XwYGJ-2a1fn11WaBlNvDhzJ6M-cs6UMuzz
  OidM-aw5XA63Og6oG1lyt-D9caqbb4VTFqDZxdlWGPri3Q"}
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
      "Id":"EBQE-U4SE-LQ3J-GARM-V7YL-K4EX-6AZG",
      "Authenticator":"ECF3-3ZPL-22IU-ZQPQ-YPJE-6WQM-DQPC-AZ4L-DL62
-XKMW-KZYS-ICE2-BTQ3-G",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQJ-IY7K-MUEB-RKX2-GOEY-M35P-JHA5",
          "Salt":"VO1KrllnWgHcWtuNQmIWEg",
          "recipients":[{
              "kid":"EBQE-U4SE-LQ3J-GARM-V7YL-K4EX-6AZG",
              "wmk":"QJPDQbFiOOP2U7F3gVB38odUhETcFIvrqv6X4iVfZP18
  C2Fd4hQAXg"}
            ]},
        "iaGX8SBce7Ljjbmy7Sbbg_rOg-3teixHd7AhgaEM-FbnjpM9bVvnHz4m
  0uvUJTh2txfwpfn1zCtznAm2Dt_LEBbOIvqiASvT0E3iFMIPX2wix3-lx6EtfQNp6
  DAQjydHG9tqY0vVigLZhr9j8fNLzU0xz4uQ8OqBgkow9oSk9TxfC0XJKP4hIFuC_o
  o1GmjlKIc7weX7HAJa257jsOtVrS23til4P3yRTOYO6Dz6jwoS0nRblLoIy17fzIt
  9X94LRgF7fejHj2a5DBqTgATGPc3QqpS2DXKWacyDgRjePjlhOOQPZVRcgQe4AQFL
  CCRDVsy1EwCyDE21Ry22ddUNuptqg2Alkspc8TXP54MI8R0ZMX3WGdMBBzkrR1qXD
  XmZpnt1BE2vEMMvgZf6vkItbMMZjSA0FKMV52sl1oYJo6zUkOg8FZT1p8y88motSd
  vq3osAslgrdrEq-nQTzSUTEGp-h8GmUv0nyhj6oTWUvzLnPpXf7fXkYFtKGcGTxlG
  sSFkkD7sCUGTZB-Rcdig6AOjuDqGbbgSvoQ7oMEz-q_DM0WBLb7sb-XzI47_Nqt27
  IWln8ERzYOnxsdoftannd_wVxZBYP2TfjlbJUjr-oKaCaj6CGd4uEQQgiTkO52nnH
  4EDck2Xx-Lu7hA-nRUiJiNIz_P13N7eCGnn4WrZW3tTjsgy229oCeyFo8p3g5M1yL
  FPQZsY5Z_-dF2wFmakLVwc5Mgv1FLgiPHPPCG9v4VmCINypyOT6SwQVqOMFaERelt
  BvFUnQPxOtmwSz_UDTAP76lUf_XdotBsEm5zdciJ-Nx-gH7HmFgfWD35j_GhdWP3J
  a-fID9UfHQpLBD-H3UEFdlDvU2oN8CjknNsvg-WsfAecNsJIfEFKqKHLJlfqapPJU
  fYHnTmbwwO70ZBEiA2RSqZ5d51KN7pLjsrlcLDkq0lvSW2ov01-m7VclLMkUf0YMU
  pDq1DU52GTIjvfPwrYLT1FAwqB0V6SFEWjIpaboecjAMWYA_MhCclMQbldTKEJ0PU
  prOrpkTQxoaepxBlSsN3VTmooElSbBXq2fbLU9q6p7d8VJTw74vMrXLsTKLfTfuIa
  5W7P21Px6mu0--Ltvii0ogbG73OKojVrwtfdRPLmmBqcF_isSzXVUisKovTRiWfJv
  KJGM4MDzEe9qZLVd5UZkFD9LiKQu18ESsGr-13a3M4v4-DVbetnLIspPEqVef7uR6
  6nQaKxjDPrOh-9blXgqsE9WR0e7s_COCuv1qhGIjPUI3LadRAdz_MnGFKfFsixvbp
  R5sOWiR9TtUXcZY-03jxR70I9rz9nNj9mfWYIiGRldmOLhD_SbJp6rTwQ4C1os_fy
  SMozLufBrFnHPNlCn6Uva9OtoVmZXeA_Bdn9d8u_M6YpahzDZmJjl9OtkP5tTOwD7
  2HmWrnBeHNdYqefFLS08EHDmMgSgWbkTbuuC_S4ci0TFyGJj32XbScXgBoZ1P-x57
  SCdDOuhibtgBWQPd1lGh8oMYKUKQn6DAxTlR2mdOWZynumEHpnFw7smPPJRg56vye
  xuQRx48f3bOcTHjZYnDtOYzUazcPrm5g_gYYat9WWvCzKTaqOe0HmjbeCqpuLsQKL
  qbdvoWSi-6-yAt-kvsqxZYQAWKKCe__dvM9CjHNVP8M0TQWbpdciPd9cwwwEsvYcV
  7dkGheRbG2EebOidCvSlMo2xJGcrCEsm-AJu1RfhnZBYvbzApzfDuhjqoDC0ianS0
  FbeZ66HbNmd-bW7DVhWJwHmygSEWfaPUT-msMNt1aApeXAfhBYdItrX92ptoMzQkx
  gb4cRlyUV6xL2yWA1d28yKa1LzVPvqadd4llTbupe5cYioa69x13ckK29f94DBlWT
  5-4VIP9UWnO8GxxcqBxKymrqFtZ2Ts24w-Xj0DD3CG_LqBS7Tf6YdKkFAinGFRjKj
  mxvK3p6wIth4aSNm1ObXo4gjjWw1skPGXcHHwXi33GI5VO22Qaca3Osz26SNDABlO
  5tm3-pwcNy5m-3lBv5YmEV2k6ch6cloh404qWxSzO406Y0BA0CvLOhKL_vUR4gZ1p
  HFT4CBuzKxmoFwiqHNtDqOLcG5J06w2GfopoVw8Poiv5P2s_0903Mwn6V1e4GohSf
  nSaOWM1dZI88SEWFG7H3VwF4lJIWDT0CoIWIBDpTKZ_lO7WaQJK3FFQfLCxacKz4o
  iIh6hIQXt9F-RVDi7-I0EkVax1XZ45xkAZRO7gbl21N-1lp_RXW8xZQo8HY3U-DFB
  wZNv754NGOUGX0m9rbG8W8jo_JUKGAkMxoSRYV1c9KhEmy_hEcpHBDVhBZWbTsaPB
  SRQawN2P6UFa5tm8KK2AEY09-6lozJQVVoJwi8nQcX5fS871iYF_WHUKMlqRAympM
  F71kj_A1DVOlMaWYYRCWMUWCKj2tvmCEA1ZFxvkX1ux6LiSTyjC_0rJtvn_QuktRY
  I7DGLPwm2cBbUFsS7Rs7mG09_WHKV72glY6Dmky6Sv5l7cP-4s0undXo8lICC9-9T
  AtrirOeDHQCYzxCHxSRa_L0dkToRKpoytliesa9dbH96AZt8tXQTDDxMUrDTWXtrn
  BRqjnHOW70ssEXbBt7Itc6DU9oPiWxiDlZlC1F073hIvhG4YYWV7r50LmP5WvHRWP
  Ms4SGck_w3mLLOQy9BnzlOLWCDFm6chuQ0PMEPNllGbI1cfYEe_lSMadineUIIhBa
  ioGyH8uDbWR88dF5pwzdSueZA5XpeMdiGuSEzkJqqB1HTNgxxMf4vE0qkAoi4RwBx
  B7XFdr-c4XmYXH90OeIeOEobBJaO383il3Qc1CanTeWU2ATTrTkPEQnVVlgBB3lVN
  hE5k0OnGVAtgpts9v25Y78wTiIzmA7TsxS2Uijn1lLt_088fn36rDLKzJW77PDG9o
  e6jRYjoYcIlzIXTJF_aZCyLzaBCt9nrg5xkNZ-YV4-10t1ElN3ua2ew-wVb7msKtY
  PIPEpDZ4ejNYgwoIIlBpqLsQYMCPM8NvuV7GfUQ2N3iLUMPCQ"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

