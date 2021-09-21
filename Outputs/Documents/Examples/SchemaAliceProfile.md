
For example, Alice creates a personal account:


~~~~
<div="terminal">
<cmd>Alice> account create alice@example.com
<rsp>Account=alice@example.com
UDF=MCST-2JUP-UNOG-O4A3-Q6KS-O2V5-HSQL
</div>
~~~~

The account profile created is:

~~~~
{
  "ProfileUser":{
    "ProfileSignature":{
      "Udf":"MCST-2JUP-UNOG-O4A3-Q6KS-O2V5-HSQL",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"TiJPMzwx3OX4lajBYuHEAd2lv-hcH5oFzBuVOwo41spDe
  lQV7rPH4_lR2RGu0fGX947zDz9ApcAA"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MBWG-VSSP-FSJ7-TM2X-J4JL-H645-SCVV",
    "AccountEncryption":{
      "Udf":"MAEB-BSY4-54WA-W2YA-PSLD-3XP4-MQBB",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"Cib_b-EuOYvLr6Je3Qdfyl9NnCbJB9VF3FF5JjNOyAGir
  CJlbA-FAqbSf7-UWyR2L7ZIudeEjdWA"}}},
    "AdministratorSignature":{
      "Udf":"MDVH-VVYH-FUXI-AAV2-PR3N-SUXW-YGDN",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"nDoAJlalX-hr-Z4kk991p_JL6ErMUyNe1CeMNs_3pokXg
  IsAfqH07AhIiocg-Gs6sKBsnJ7Gck4A"}}},
    "AccountAuthentication":{
      "Udf":"MCYL-KYWH-BFIU-6LWH-EBTV-CACG-GAPQ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"eWrCkGQUu7W2y9ttR3Jw_BiJ9R0t6qyev06sNNo2MEEFE
  Jc1TU3AsraEVN9vQpUe9bby4AcMrNqA"}}},
    "AccountSignature":{
      "Udf":"MAW4-D63J-XCVZ-KV3A-NOCU-R363-BRK6",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"GK4UYqYj5jjWJZBD9VwxzIaNHpyg_F8ihdgNaM6MQjjvE
  KCtNoj_RdeIMkezb_XXv2X55Y_kCYsA"}}}}}
~~~~

