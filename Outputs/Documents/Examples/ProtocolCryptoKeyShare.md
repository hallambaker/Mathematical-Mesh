The request payload:


~~~~
{
  "Transact": {
    "Accounts": ["bob@example.com"],
    "Outbound": [[{
          "EnvelopeID": "MDCL-CT66-COC7-PFCE-XILV-D3S2-5OPG",
          "enc": "A256CBC",
          "kid": "EBQL-CYMI-VYZS-CARR-W5MG-ZC5E-L764",
          "Salt": "_efIPSOGAkXg9sbzn8UdfA",
          "recipients": [{
              "kid": "MAXL-53J2-BM2V-6OR5-B5ZS-BDSN-XLR7",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "X448",
                  "Public": "LkPJAo1XsVTmYjEq2KltWYzKay0A1j7qaKa7rP-_wRQHg9xg2tTv
  efMB-OxrdcBa9ASgjcoHxDwA"}},
              "wmk": "i-3_YNtxXGKtWi8kKafCB3rcD_p2M5oU2gxGcXwV_b5lFmrToHByqQ"}],
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJOQkVBLUozS0ItNlM1Ui1
  aSUI2LTdVTlEtREw3Ri1HTkM1IiwKICAiTWVzc2FnZVR5cGUiOiAiR3JvdXBJb
  nZpdGF0aW9uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAo
  gICJDcmVhdGVkIjogIjIwMjAtMTAtMjlUMjI6NTU6NTBaIn0"},
        "fMXPw3PGUzXb4nYMkZW877MWnzK7hDL5KvYZ8UfqPKa
  DPDTAII5pFo8AML5WyhSR-94Gk3I5lN0dAQSdgmp_iGEarzpAt7-KC_gDR8DdE
  WexoII8A53cxu5dVE33tCC3migB7zk-k5tytKDU7fuTSJFctJRxLKQew0HqwUT
  wCXGtlQyuOq4V4Som0oEy7oDIsTrWVndOKFNFPHm3sKwhiO1rhJw4bjBHfCsmi
  0xO7x-8gwuUvmmtRrbkjsPDNFJJFHuHidwFPlmXVltJlPKN4QyLP2fXEhegToI
  Mkne55xBrIc_BlvS5kEkt6bxNXDBcV30XbLFDftnrUwxVhsNhITZzUG38ZPiYn
  DtyzNhby1qb1zpLvQWlygasRmJHi2cA1bNl53VdzDH5NtxWCeCrCI8Jz_BfvdB
  HFZ6_E2EcqiqMppAkzbFuf3KVOY5VvUPJHb7mtB69kgIrccDnziGpLBJGCwa7L
  Isv3rp4UutirhiVPTtISu-9vdLzDQVnv6Lgc7Wxhg3UfbFBBoJdua_nCcEab02
  R15iC1GNX99G4Y4mpgWHV1pNiweOiT9uOvi6KVcKY6TGzbEbYeYSluaWpLlfjY
  BR3YlgV-DeVJAUmuGWAIedTCvvlqpAj7Ylarqhkk9OkiQ39DQr5NGVTwcT4IqL
  gahzLmqQPODMqTTu_h61_tGMdcGQyXiTEEEotw2-PTaSts-WGMsA2uPVPtsqp7
  Ry_o1hhkviRz0uoQ0jI84O6WVj0TI-X5Sf7tngZqJAIcnkFOKXBrdz54zFdEHW
  ajcqAs5-rbCmJMm0jNay49BrN6SuyH5XO3m8w-wB3DOwznEvK-VCzKdmBacmxr
  GWITwL7goA1EBO5hpu7HhPI1E9mms9VkTyhalIuQMXWx1QSY_2USsDAIU1EMVG
  8EO9mdu5oHj_3c_Y6jmr0u9860lDAczoDrwidjpxhtO5Rv3HbFA_uzfwnyJmld
  PFH0WhMy5RYwcPlPZVOyJYJwC6N-6XB_jIJN5U9Q4b5z4H1UyNitqJBV2a5bxD
  CkSouwTcqRQEA4FRJlOnfiR8dQfydvYPVdD1vJ2_CijKO9OFSG2fsGFiRtKdsL
  hoy4yIi4Apk6osX-CjDk6z4yPrttZi1Pk0EEg1aUCG-Q1BFC30c9OlfqGoSbZ9
  Rphhusl_2wZBuOtKUiKFLEiFTWfCQmXkThKek877qGeUwfM7MXzz9FnQHX9I8c
  EaKZlCButcfg5R_0khHuEkCFADX_Ln0Bg-t69BmyZd9QviL8aC5FCrm_ucFFO1
  -vD3ueByP_cX8hxzNJDeTCCd8Wd23I9BBTQQtRmCv1jCq0nf9XG_T268lD_HDs
  RrxejR6rLatvX36aoncvclbMiXamnedf561DxGmqAABsyPVvLeal48DIXpUHMi
  hmLfuo3f3RzXHuuoxo7isflSH6dEAv79Fo34FUtm85WbXL3Smv9kYo5MjYGAGF
  F50dX3SHx_GUR9ySg1acK2X6fAKEiai7yoRrFW8FUemag3l8S-KB1Naru8Ej4M
  LLHtK6TmGOs4No612KhYZUVfEOMKBLYveFg9sQ2SkU2AdsbcfLHIX3lkIHfiR6
  nHFuL9fVkDorU0yMNmizAB0mvotWwPyOKykzBImxwDm9kto4g6YBKJdqWZl-UW
  Acsk3igYkmyRLJCboYzQa7hR0lMiOmXBLTyYc6HsC7pOjlqBBzEAj9HagC-pgW
  pNq1Fo-YOH_bupfH5-Ht9rjvR-P1sBPZcy4VqrTqAub1daUkItXROp-lwGXteX
  8mWRLzYNIPYRELDvjbmBws6qTGddSdV3Lh9lq1xqw5gY7LxedzSSAG_4k7A4IF
  bW1gDtxC3yTy3BAG-ICVKhpJEk4J1j0sgUKBY_8l3rPau126S9fb5pJmNcC6Qn
  XSiEzxcM_khmiMLP9Qfwk6SF4ViTIIvMt61RPq70YukcL0jx1BEXK3N1F4Rusq
  PdJ1VtEpm04UfLv5HlplNB3fhI_sORok616hTj_YQ5YVU_a8C6K5s0MAheoAu5
  daAYjzbwPj9oSVwiGM23gs8AySvOE7DEkmc2rKoz-GLJA3i2scCXO9rxTzaV63
  xv3ovvHLDmSPhMdClkD1il1JNHwFYrF9XjVQEVCJtHNB9PJm-rKGv6P2XaaSzs
  hu8iulLoWE3pbI3_7ZG47nJ2eylAKnQwWkJ5FjNVzCjdmTW3xxQ3nl2P1kpj5D
  GUqUhaKqHUn3Fmca2rox1xlONMKHcChTQRG1PalLbnR_BUs1zHHdXv_ae1zlF3
  DbAWnHFd29Gqjv19ZxiJAQeysq1wgv4-JsDvPWWT93B6RsOfs6pk9Z33d6suav
  HnBSEbDEUjgCZvE6LhzSyo5BBL7AbF9l1ODAJ7tLR_jEYDASJGz6BZUSsjCT6A
  VU44zCxQnRFLDOTaVnYNKSNGB3Di6yVR5idQW53sX32SFSGoTgSDPn-O-r5v1q
  dL6kquQ54x6XlvH_G9nXeT8hK2FU7Yw68ZoPvMBuAo23kBU1q5zPwkNZYz0TvA
  dnZZdG1Y6IQ0bYNpQqTs9NkQnUpXetKs21Y32Fu6CY9aPtNMcj-RPYbFQbUrgh
  -X_TsMMc7Ag8jF11pI4qsiurQ6Gq5DdD6B8KEqTrojwNl5Fi7HinCeXYMK3URM
  9NeuP--H5SMaceHOXVHujdhUHktuwX4y80lvjIbPw7Lex_l7w2mQke01ZcDErX
  rGdJIFCx2I46aO6ZaD_SW63wsmSUIONdUuTB6p0AfVK3qsBaQ06UfhXGdjiznL
  ZP5L7efPunJqxc9Me38BGL6nNwy5lpDEhnUeDRfkAuLIgA-4ulkqK5wiJevNfL
  UeJTCFXwp1UoHpfOJ8i6GeCu1Ntu_rG6ONygKusmSHpAEinnQYXEfDDeUgXFIB
  QJJvwkxGZ_0y1trnTswWq4Y8H9BPLEOSc9U2a71CIqPYTta0A6Zw9q2I3yKU9j
  AgH8cZAqWENtOxdPPxjZqqrLkiRwXf7UnLbagYkWQqy2YFoZCArYKMyoMSaLO7
  dAYIbKe5XZGLmS1eg0nT10qBCLc4WMZSMG6j_9LckdOqc8MPFwIMQb_UiXufhE
  EZi0jTueKxs2a_QG26IvmShcnslz9quyOJhl5g4VIfzHPT1wS5zRBK3KyZ1wg7
  c_n98QW4yMb-GA-TE97pNV2omKROgM417KrPx2KmWXcbOkbIclC4SiklW2w-rt
  hp0er9CGdmJex5Mp_qlXiDY_Y9sX7FrGtPBpd-NhM3vout8o3Kr1quL50H23Kg
  ArUQYMGhwHxVwJWXPzi8jjbGn-VjX8bxruYUItK-OSp38iDNYiVngGNygybtZC
  dux3YNUX4_UfBx_alm2oFiHzC5DjpMgvEWJz1P9cT4-lN_1kc-zdGHkvVU6dGe
  xTV0QhvgeTEwXa579DgocBvg9MY4FjEWN8ZvY_Vz5ssnvm335zMVe9m-AWt8P9
  5MEOYmiMIU6ZUeNTcijVvmoga9q3KncAtBqypp0EsrgYG9_RHp6g39NJLd4nVT
  syoyL0n5KIqNAllle7swPudmpLASyYnkE9bQzQi8HUGB6xvExgfJVMT-aTPHGV
  BvW062WIn9Ej_4d5BzDzkB62K7LEgh6SNtP0F2Q9eXtYzof8q8GcMZIPMZQBTO
  -FNAoDYbfBvBN-XL1DW5RBCFiC32f0l6QjwwIxrOknrctWeMkzPMJsYwhu2syC
  vfkyujRiYnxIox373kZPxsPKbIqn12IOgJmsCNzvbtNHva8bAGcWgU4MV_7iwH
  6TY8iW4XnW2mCZ1OSmO5FAhTWFHBWRSO2zNtXHGSumZ6DcPG0JoAHKsE6kNPLb
  j2Yc_z2F3N_Wx1bfi-VxCwIMGOFrYcf4GBsz7KmBBGypGPeQpxuvrzJu3RgEer
  V39dqbykPY5YhUdfgbss4OG2QCyA9bJXvd2K69j5CbEj2p4dKHSbrWgNYiA-II
  ZyrLqPLywX5nL33gCifGu8Q7hMQici_jx-SVF6Atrr0k0HphaaFqxNEVF_t8vW
  GSPI3icXGhsQ1ouI1vDoRdTOMpIv9H1p6Ng-zn-yzpHLhxGZrXmTMBmZmZGkPY
  aAZ_VxWSYwmhL84dPoZJqr8NTewkgdLWTzS26gf1vH1d-y7EF_8GmYLSPhakEj
  ikr-MTi46IT0NkkWZxZQ7tMvYygqa65h9uNqjj1kt9B62Zwnupwm4sWiVmIuuB
  Lx9JT5OAy3sWDdiA6QznbLpRwUtvZVZFBUdfiedsmOwN8qLBmd0ZONVMiI19Cj
  y6kipOwZhYE_NSaDHT__dcj62e5nay8T8uSARihsnQq54A8uAuQ"]]}}
~~~~

The response payload:


~~~~
{
  "TransactResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully"}}
~~~~
