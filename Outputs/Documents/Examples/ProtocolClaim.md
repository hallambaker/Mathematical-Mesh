
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "PublicationId":"EBQF-CQHK-FZHO-KK55-J42P-G62V-M32S",
    "ServiceAuthenticate":"ADIO-W7RZ-5IFD-WTIO-2JSX-IMYF-XNDR",
    "DeviceAuthenticate":"ADT5-GX4A-YY7K-HOCL-76GZ-SPPR-4NAL",
    "MessageId":"NALR-BNTX-GVEM-MAGY-BUZ3-OKOR-SXFS",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MD5U-GGX2-E23P-G75A-ZEP5-GVMK-LYXG",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQUxSLUJOVFgtR1
  ZFTS1NQUdZLUJVWjMtT0tPUi1TWEZTIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjQtMTAtMDVUMDA6NDk6MTNaIn0",
        "dig":"S512"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiUHVibGljYXRpb25JZCI6IC
  JFQlFGLUNRSEstRlpITy1LSzU1LUo0MlAtRzYyVi1NMzJTIiwKICAgICJTZXJ2aWN
  lQXV0aGVudGljYXRlIjogIkFESU8tVzdSWi01SUZELVdUSU8tMkpTWC1JTVlGLVhO
  RFIiLAogICAgIkRldmljZUF1dGhlbnRpY2F0ZSI6ICJBRFQ1LUdYNEEtWVk3Sy1IT
  0NMLTc2R1otU1BQUi00TkFMIiwKICAgICJNZXNzYWdlSWQiOiAiTkFMUi1CTlRYLU
  dWRU0tTUFHWS1CVVozLU9LT1ItU1hGUyIsCiAgICAiU2VuZGVyIjogImFsaWNlQGV
  4YW1wbGUuY29tIiwKICAgICJSZWNpcGllbnQiOiAibWFrZXJAZXhhbXBsZS5jb20i
  fX0",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MBN3-5FRI-PP6T-TUDK-EQVQ-6YG2-QQKP",
            "signature":"jEC0FWNvb6z_b9f8RKyS39efgch6dtogC4NgwD3F
  _stRSQhhqkjyMX-DHRIq_G-aft6fe2k1NQuAUkSsvcsa_cgWS3s9aBnWK-V9QPIAp
  -nZww-d7PdxRdDqPMo6fiQTQtAwPYc9YLVqPR92Mv4kNDIA"}
          ],
        "PayloadDigest":"MkcNFOTkKS2jGGhNMZM06Sc428NVzpkxZWhBfVGd
  5RfX3wFWQjTg7dfliz4Wo5QD3leiHwpcx2Dc8GFQYwyx3g"}
      ]}}
~~~~


The publication is found and the claim is accepted, the publication  is returned
in the response.


~~~~
{
  "ClaimResponse":{
    "CatalogedPublication":{
      "Id":"EBQF-CQHK-FZHO-KK55-J42P-G62V-M32S",
      "Authenticator":"EDGX-CTPR-DZAY-F3NN-PGAF-QUMW-F7IR-OTP5-DF7T
-ZNK5-7PWV-D34R-CGEV-G",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQL-7JNT-IL5M-B7CU-WI2A-DX5D-UAW6",
          "Salt":"GN_LHXUfHAt54W0d1_biEA",
          "recipients":[{
              "kid":"EBQF-CQHK-FZHO-KK55-J42P-G62V-M32S",
              "wmk":"5-IreuFoQhfQgHhuYerQgaDlUjZmVKIA2x62OGzg7Zid
  aZ6yXNGEDQ"}
            ]},
        "vd09uEQsmWF76L2crgmBNoQnnBtuxGuuiWQ7DrNW-WwdVGB3THdgv3dH
  17-sICTnh0haOIvuY65MZD2KIe_Ythrk7_-Cz2KiLrlaWlIZCH7g9JD-z66xxe4Ex
  t8sOBpQSqsoqM004ieN29mI70F43s96fdSRRQpyJAgfE8dqrlxkcwOyjso0ragAFA
  O7JWR1HZ2TSBe-7zt7Cvdgp_JYW76w_AP0Ox2BY9QeENUjpXonIwacn2UeCD9XYtT
  RBISVI7Bom0BNNCXLDYWkwtFOzaJSRpQ0Pzlwh-bKbriILpnoMDaQ6O3SMdiYyafM
  Apb5DGSy8M2SAfaARW0z3oUuIHBz6r1tjCoOjgdBFd2MLtjhFG6IpqyEq4dv8DHAN
  RNj9ON260UDsjOFCbA8fiBmMU0LfJsFbO_eGayjERtd3eox326Rl6XsVjHCOTcvkv
  Ou2SEkDyhpVJ6GU90Yptz5WymOMlviV83J6mKeSFGAzUsFEg3B1M36an9NOy7sq0I
  p1H-QQF3SrkydivO11qUrrLYLC5rMSJCW-QKPtjx30azci-gH3EDIq71z_l-3wrga
  peAMouOSkONvPT3pVqceXZT176Ay5_P51GG-4wcn2wxyq8vrO_XI83qkRD5JugtRt
  QHMzaa4BVPzzirdqmiGXqwA-R3XD23KXXhlO_Lj-nIgfs8CDsCkoqJ1_1HgRCyxYs
  phUi11R_9wRy94bPI-wvdAjTN1YrjehV41b94vkFvrsLP9Nb-texgMjLvqLD62RyA
  eMmC5cdOnm95NUU6yVrWhkNN0xVRIloXF3NKkg1oz-AZcTyfrv967VZHWkw-0uJ53
  kYTMRfGrirlcnBTcHOdwFTsH_9ug0V90OfSJvamejEGXkxRYx-Of3MDmcKTTCS3Tp
  O-PU30k3YFDxsZ5QftbgC4HYW7Bc51frMH8JIUxC44orW4qT3E-YFk1VZkNqq5j0L
  4T0DXBsvAb7Tn8uMxB33uzSsMG7us-Ujb9suz1AjJ_pl5H9XII_z8lkaKTsp_x4Z7
  NtEzZInCytRDhpaB8TxRQWHjJ0NmN5SF3pTIVKIt_vRsvD0A-leR-ix3a4s43P9Ap
  18d2s_C_aSJ_Yxhq6-WPvvWjS9S6w0uQd-_Cf-7Y7OO6WBSTjUDnBu1V5aLrUpI5L
  SYVJxQbH3J0oXXkF52y7gzryD-uiSMDj7iLnm6rewf96mLgGGa7KAL5Of4IGaYI-m
  zIL1NS9z3hUF3VLPT0CEFbcgq069uIgvVHo799obuKt0XwTzEgr_VXmHWqALxYRCr
  lc4LCuZyjYeCXBZ6JPFYpzWE9H9bKc6XPO9T3udAkLHh9OC6ULsrPg3rKgzJEsX-0
  eqXNQaxAzMl4GlI1RLQqltBYlG9eOZhL5pOuT0W1sZe3UURmVa9G-u1KadXVyKbwU
  E1OfhirGWQfViFd6PkCdkgz7FkRdjxA13AANLuC7uSepe5bnSFFq5IFdiOFYdyGen
  8xLZYHzyQSPb_BnVDxKzPu1JKehI-9cG0YmI39HGTtIB3QKUq29O7EAC2Yzkb09Mf
  VYwQHis1dhUww7izmg1gC8Kg4l7ssKo_3OPS_-r-2zgJ0Al-iwPhfu1p6wFa40tWj
  DDMbX8Pll4wcdw5vjURqfKrQPZm6ziHOjcf3jumKD5g1NfqzfCtH8HprxAy8MIXqi
  xnQe7dMFEGj0zXG68RwtXchrNr3OGoaq2DWCjtVLRATpWR1AUqMCGXd7Zi8DAd6lM
  0hUHIoXPcpSFKX4eGvFe4yQfJlDIlxXr7ji3W_gr37wP3pmqxhm834AfClrld7WP4
  UQQSNrCQbeP48H4Vuv1H3AjZtLMqTa86pNG6OjzjG1AZfQp-PCjIK59azGLvpqGUW
  MhYMReADGvoyU78somex5WayYrMvb53D2Jwwj_wxUQouuAgLIINeGlKVA0SdInE5P
  gNsq2rJOHfj5xtGlpz63w1VZvnqYADC2CfoiZUrXNoPQEVcij1EGCEYnXt5H2HsF-
  -dieSb7-BBDBXKSvsbylLJrrEA-LtCCRe7SGRBWJQnV0Y4dc7116bSQHnxJu_ixjF
  yXmj2x0S3LRp3awUwWC811rJza3QFq3hRd0mLUO_JbyO9JZe48ZgRPUqGmViFuUna
  VyU38bJolMD_4ZGaOpkOMz8r4rpGEmJsJzTrh1aqCvnsfCqCSbYEug46exz-CgwrI
  n3SSb2s_UFmifCq6rbadWD91knyHNaIcjKFILCq0lBghzLL0s6uEvsgBAn6qmiLrv
  XR-5-Uvn6DZz3yJmxS-E1Iq8JB08SuC7BZxQT6V-RhfAcp8YMRIApEbVOPW1ZFHXA
  gkO_a_5YIlmcQOYLtknIUsQuGJu8p8eMlDQA8FeC7etnSr9d70D0I2t4sIyogB65N
  BKcvO1NKFYzF15CUhXv28C3g6A_XAuFRnwJgAgkn9uN5eJChQFUB9qkaOkZPywKPu
  shE_gSDi2-KaTp0MvJszvrwRZANoCScyBOSU0h1y7NhjI1-A1tehivg-6o9-4EeoC
  hmHEw6p83UDd4m2d_VY1WS4eTWuAW0tdOnSc9imGTL_v6aiwhIv3ROwd46mtiQZuK
  ZhFV7-tZ3zm6Ls6AAvQ7Bx1kVZMuiVjkEJ_g5xCHuE2dWK-wMjBZAQetpq0RiEG7N
  NdkHqcds1evkP3dLyp1kvEkakemBvpSyGnCcJL97vnFd6Z8Tf1wt6B4orPjlsOD7V
  LwMmnlGiV_cwMYHcibNvQwpTPLozpvWbXHfyWHeKK0Nef9VSZDgVtg4c0ziD3YZeB
  50vzp0R2ft-BrjZFfiOvQOPtzmOqgC2fJXiVnGjWmyq-z5Gql3238e0AFpGQflIfZ
  Uby0-R2y5CbQ7eMHh7KYwBVghlR_uUhftrdywA2w13FnsAy3nnjykyVKt5DQtLETr
  8pRIxu4KcxgPtU9QnhZOFlWrEKHnl2O2CMRZtDPI9hHEJoCrCgoihkwyjKPk5LmXp
  FpagY_oGp9_ch5JL3iqSPqR9bvb"
        ]},
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

