
The ConnectionDevice assertion is used by the device to authenticate it to other 
devices connected to the account. This connection assertion specifies the
Encryption, Authentication, and Signature keys the device is to use in the context of
the account and the list of roles that have been authorized for the device..

~~~~
{
  "ConnectionDevice":{
    "Roles":["message",
      "web"
      ],
    "Signature":{
      "Udf":"MBVX-WNGI-ZZFE-VDOK-WZMR-2VRX-U2SA",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"LJcLo_7fdILcsUsWkDgdrpgjnpzEQB2gyfqFs-ZlfLJDX
  -UEn6o0sRqjnnZKVxw0Hm3SuhKB-aqA"}}},
    "Encryption":{
      "Udf":"MATK-HNZD-J3L3-FJP2-XY3S-ETCA-V46Q",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"cA-eUfXiTOcOmCyVbLBwNdNvLacVBaKtcaxKULdyyYOrr
  z8Ruwr7ART66fqZ9tQ4eqTtQ1eQeVMA"}}},
    "ProfileUdf":"MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3",
    "Authentication":{
      "Udf":"MAH3-YBVX-PYRE-XOEN-B3DR-3O5H-Z4OJ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"R4J4VdlENkenoGpZ6WYyH96o5D1NP0vgWp9bl8KOHFDuI
  myt8g-Gdj4LjgGPGIorVM49KaX-1cYA"}}}}}
~~~~

The ConnectionService assertion is used to authenticate the device to the 
Mesh service. In order to allow the assertion to fit in a single packet, it
is important that this assertion be as small as possible. Only the 
Authentication key is specified.

The corresponding ConnectionService assertion is:

~~~~
{
  "ConnectionService":{
    "ProfileUdf":"MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3",
    "Authentication":{
      "Udf":"MAH3-YBVX-PYRE-XOEN-B3DR-3O5H-Z4OJ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"R4J4VdlENkenoGpZ6WYyH96o5D1NP0vgWp9bl8KOHFDuI
  myt8g-Gdj4LjgGPGIorVM49KaX-1cYA"}}}}}
~~~~

