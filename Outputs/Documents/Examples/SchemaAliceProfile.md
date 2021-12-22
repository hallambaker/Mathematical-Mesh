
For example, Alice creates a personal account:


~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
</div>
~~~~

The account profile created is:

~~~~
{
  "ProfileUser":{
    "ProfileSignature":{
      "Udf":"MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"rJRBtdrH6kkJb5OCDIkbDtbYHaJ5intSHa2YgMyr-2jOr
  u3UFyyvJBwxra1x1nfdxDT7DunXsEGA"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MCLV-U6YX-P3TO-X3VD-LIXM-V7ID-ZV7H",
    "EscrowEncryption":{
      "Udf":"MCN2-GKRQ-L46G-Z4AD-FTLW-DBF3-TX5X",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"n6lVbvXgKpwCN6Rc0oLnsYmqaBTbqQJa4EktInGnueRWp
  BbAMXdQdK9ErT3FhESqxQynIumclJyA"}}},
    "AccountEncryption":{
      "Udf":"MDRQ-KSVX-EF4Z-REJR-NSE2-5LNW-DDHY",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"D6RxRGSmXJUtRB_tVQ9nr9yNeEaJZQFxOyKYxVlwKcjfH
  AVEwtrUyWBbrwQ3XAdYZIK2-T1p4uKA"}}},
    "AdministratorSignature":{
      "Udf":"MDPM-KCJX-R3IH-7W5I-5XB4-LTOZ-T7OL",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"DcU2VCDpvJnSEe0bJowcw0WDlIlZPrLu-LzSrdgwQdl9U
  P6xb4i0PoghRLRpPgLjgq44kIJs37gA"}}},
    "AccountAuthentication":{
      "Udf":"MBEA-E6VS-5R7B-VA5C-UOLV-GVFJ-YVS3",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"HloBLUDLQKI_Cr5oRSiuiAn3JzAKwHGyoPRsoilN6EM3z
  8nAjol_rpllJKTpYL-nDKmdap2A1f4A"}}},
    "AccountSignature":{
      "Udf":"MD5U-ZIWM-OOMW-O5N3-F7SJ-VF4G-I35O",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"D789mNH9dH-oRQcgycKD8MEDn2VMR3TLprVyBeBQTV2X3
  9A1NpBXsN18YhFVXxkPAFzGx8x7OkSA"}}}}}
~~~~

