
For example, Alice creates a personal account:


~~~~
<div="terminal">
<cmd>Alice> account create alice@example.com
<rsp>Account=alice@example.com
UDF=MB5I-R24M-QXJT-KDBF-XFOA-DGC3-U3AA
</div>
~~~~

The account profile created is:

~~~~
{
  "ProfileUser":{
    "ProfileSignature":{
      "Udf":"MB5I-R24M-QXJT-KDBF-XFOA-DGC3-U3AA",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"0Q-Z5eDHtwWVYdkfyVT9R36-r0hO1fUHWpmI2mdIsi81s
  djysgsAfdKoHZpKIZtKkMXSoOkFrpOA"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MD36-Q4SC-S4YZ-KPRP-7W4P-SNR7-QMD2",
    "EscrowEncryption":{
      "Udf":"MBFO-AXQH-VEJI-J47J-W3ZG-3ZPA-7FHS",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"GChyNFuHb6_BmogqEC3_R0aXaemmDlaDGyYYdl2FSAw4E
  nKjC8AqGlpy7sQacRVj4-QbQJsz_PkA"}}},
    "AccountEncryption":{
      "Udf":"MBUH-FY45-DVNF-XMQV-SQC4-LTLI-K5AV",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"WSdlD8SLXWCFHhIHjCwQHB7b4Ym74kpM-XVZnFKWYYYpH
  gBn-JIH3aPaHzd60MH3n1evVNUsTbCA"}}},
    "AdministratorSignature":{
      "Udf":"MCBO-ZK4F-QFYM-63TK-TA2C-LHQY-7QW5",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"KZPy-O5-rDXLTTo9ckiMR5mlOjkurMLRBZW5ZkUJJ97d8
  HRtTABdLn66iOfEKCQ0si_l8O75VUQA"}}},
    "AccountAuthentication":{
      "Udf":"MAHC-QH3D-VLKC-UTFB-UEFR-M5VV-TWAH",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"EmSbhqkjgjYAGR_iNHzGi_SRB6vGlKqfIsCyQvxlVf79N
  sSEEhmyPHq7zJ1AIl1eaidaS2r263kA"}}},
    "AccountSignature":{
      "Udf":"MBUX-YI5W-NTAH-UJN2-4FFC-4PAY-NI73",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"FfvEpMucwBoxAOS_-0tZUazve5J7IBXoXpjLXTPDuoDvN
  udksR_1REfgh9Hb4bIpbZjl_8l-RiGA"}}}}}
~~~~

