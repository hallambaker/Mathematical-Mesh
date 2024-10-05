
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
      "Udf":"MAK7-H4MW-KDKC-ODMO-CNMJ-OWFX-423M",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"Q-6Mu5NbAA8PvxTgY1svGVi3wxOXqizSwfWYYuN1wKzFZ
  B8960KltXRrWxZtboB_Ln4vUbUACdkA"}}},
    "Encryption":{
      "Udf":"MBJP-LVFC-3QCA-MYXF-JNDH-XRYD-AHOL",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"sy_EODIlXmJeKPc07Ev5fxsErLXQQ-ZOqHufiBs7LBD-z
  sBE34b0ot6rYIB4kuVDcDW9C149p6IA"}}},
    "ProfileUdf":"MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ",
    "Authentication":{
      "Udf":"MBHZ-TYG5-5ZX2-DR7Y-TVOI-5WO6-K3VP",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"_w6N1f3j0mpTBYtQQF3wnY3d3jsVYISOd5SR8lgfAAfMt
  5jVXBY6oadNfeJVK1exmi1Z_q9e8cCA"}}}}}
~~~~

The ConnectionService assertion is used to authenticate the device to the 
Mesh service. In order to allow the assertion to fit in a single packet, it
is important that this assertion be as small as possible. Only the 
Authentication key is specified.

The corresponding ConnectionService assertion is:

~~~~
{
  "ConnectionService":{
    "ProfileUdf":"MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ",
    "Authentication":{
      "Udf":"MBHZ-TYG5-5ZX2-DR7Y-TVOI-5WO6-K3VP",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"_w6N1f3j0mpTBYtQQF3wnY3d3jsVYISOd5SR8lgfAAfMt
  5jVXBY6oadNfeJVK1exmi1Z_q9e8cCA"}}}}}
~~~~

