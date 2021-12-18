
For example, Alice creates a personal account:


~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N
</div>
~~~~

The account profile created is:

~~~~
{
  "ProfileUser":{
    "ProfileSignature":{
      "Udf":"MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"a-XpzoqJCy3i629qjJwfxu1Gm-jzkvRcj_P5OxRN1s6nZ
  MK7soGdBtzQzPrO4yAZBdLpxQvFvJoA"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MAWW-D3T6-T5C5-P7SQ-QDYF-JGD7-KHHU",
    "EscrowEncryption":{
      "Udf":"MDMH-G44U-4Z35-MIVY-IUFH-SCV6-34GY",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"Qo5p4-yAYHseLt_0K9R1nD6g3DkN8R1uP3UnH_t2KiBdY
  39ZZlTEagG_sHrj9OLt6Zgd3FG5498A"}}},
    "AccountEncryption":{
      "Udf":"MDNM-PZRG-WN5F-2GW4-QSH6-XEY2-BEHC",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"jyJ-UwyaQ8N7eiUHUVso45ngdnZZEli0tWHRa9AwmN-VT
  GVhkUoqhfu6xJskNpYXC85xqOCN4DwA"}}},
    "AdministratorSignature":{
      "Udf":"MAA2-GNB4-REVD-FWKI-Q5L7-7DIS-IJPS",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"Ks5BkGHanP4ldxxR4B6dJev-QpLYDwMWbnHLgvs12wdzQ
  2BlKRI_WvXbZZXahqXQi3RG1heTmIgA"}}},
    "AccountAuthentication":{
      "Udf":"MDIP-UPQV-4H7X-IARV-X45D-G5RP-MUKG",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"JvUnzk6bJ5lQqbIYWgnDJBwfbIDlM7_czsJfqTM7XzIFn
  3y7weOZ426haW7gdYxLd7yi3uSr5HWA"}}},
    "AccountSignature":{
      "Udf":"MDO2-SNPT-H5ZY-U5HK-BPC5-MVGF-WHT4",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"2oUQxok3agfubDGAo0d5Zgq7gg3FBqfLlxCuZplbr5yS3
  Ft8AnRV57DMeCzNtKTSVVgV4anq0wQA"}}}}}
~~~~

