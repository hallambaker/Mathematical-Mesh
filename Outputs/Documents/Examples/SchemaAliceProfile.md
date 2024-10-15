
For example, Alice creates a personal account:


~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
</div>
~~~~

The account profile created is:

~~~~
{
  "ProfileUser":{
    "CommonSignature":{
      "Udf":"MDNT-WT3G-346G-4I5T-YV7F-LTQX-PSNT",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"IMyMo7fEy2vHp8syQ0VU4XivpJEhgQQSX3j8mva4HC_T0
  5UnhQYqVZyuvIQEVo2dyMCRm60Q3E0A"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MBQD-ETXU-HZRW-A26O-WDTR-K7GI-X6JD",
    "EscrowEncryption":{
      "Udf":"MCKD-3MR6-P2TE-M6U4-4LIO-ZTRG-DZVS",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"1vNUAAp3rszIphG8EsfoaO5Y6sZCn0Hc8zCgdQivYpJAc
  DtmkSsCeI2gmDTCK6SrS1UgPtuYmTwA"}}},
    "AdministratorSignature":{
      "Udf":"MD2L-6M7C-Z3Z3-Q3AL-JFYI-ZIUC-BKUR",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"bHoKb0c12F7cibM_3gZcJXMzOOX4snHgPVwOfRYk6ARJO
  sGPemsd2Bm0WfmAkRYO3EQ6fj8_NzSA"}}},
    "CommonEncryption":{
      "Udf":"MAYF-D7LJ-5IMP-EUCG-HSGH-7LSR-AAPZ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"c7oorJ808sc9d40KXDhIHgCTFz39MK3JjO0Q7K_ufDEGD
  KiwVKhd3oPQ44PEqGjwkpp7OfbcBbSA"}}},
    "CommonAuthentication":{
      "Udf":"MAFT-SINA-SFXI-PBDY-WRHE-NXYL-DXVT",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"XcgEz9y2cqsx4ZebGERTjrN-xzN83D-pcx0651x-WUCqY
  NrsnzTH40CpoMxuN-FnpT5m_b0MyuKA"}}},
    "RootUdfs":["YBJR3jR2PljdYk5qxbWdHY0rTYEaFAkHY3MmsR8zvN1Dr33Rn
  LUL3ThrG9DMWBZ3P-8ZyGzyKaQYweco2ZUtcKw"
      ]}}
~~~~

