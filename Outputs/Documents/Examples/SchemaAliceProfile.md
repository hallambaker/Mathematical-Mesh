
For example, Alice creates a personal account:


~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
</div>
~~~~

The account profile created is:

~~~~
{
  "ProfileUser":{
    "CommonSignature":{
      "Udf":"MCDG-TS7T-UPDD-V667-OXSX-QJ5G-FQRZ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"hAe7iiCYnnu0jrTSau5WucO74Mj0ZA9DcSzTWyrNQUx7t
  5nJslfBzV0jbzZYjkooGjQlbvIrUTGA"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MBYH-BJ3I-EUWL-7QAI-NGIE-TPC6-X4KU",
    "EscrowEncryption":{
      "Udf":"MBMT-KJJW-FU7U-HRMR-K4OI-OKMY-XCYO",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"jMWm2oDjoAgIgNwJEwxi62FoFxk7M6GEL_QTpfrJhowi6
  yAI91GT8x_zEToMbuax09VJCEOPZzaA"}}},
    "AdministratorSignature":{
      "Udf":"MBFM-XW2H-CBLT-AMNQ-ZWVZ-USGI-KOGI",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"wIh4X_rzD3468TEZxKtfVwLRtteDPYPJjyaTQC0rIyo1N
  k6PNsdQvMkAO76Az9BG_ZLlU4NtOkgA"}}},
    "CommonEncryption":{
      "Udf":"MC7V-XVMJ-73OL-YWGL-5MIK-ROXQ-GL3Y",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"clDkQT4l0qWq8xRxJSl6jty_MuqlY39dMc9HaxQ0Ii96M
  4i8EUeQyoUOZQ3b1b40TW7yKAou9HyA"}}},
    "CommonAuthentication":{
      "Udf":"MAX3-E6WP-BMIS-IXPI-MYPR-M56C-OIU3",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"pjgcviHEOran2ZaLka9fegnaj7ut9NRwcS5FGZiF80oJe
  3FzUxvsxMqutI4Zq5nsmP0l8DkQOQIA"}}},
    "ProfileSignature":{
      "Udf":"MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"81swpm05T9olyqbMHO0daDTWR2i-PKFhHmBtGv5pNJ06h
  6kKE6NU0bCLv6Sy7pbnswWmFszKtSqA"}}}}}
~~~~

