
The ConnectionDevice assertion is used by the device to authenticate it to other 
devices connected to the account. This connection assertion specifies the
Encryption, Authentication, and Signature keys the device is to use in the context of
the account and the list of roles that have been authorized for the device..

~~~~
{
  "ConnectionDevice":{
    "Authentication":{
      "Udf":"MAVT-XX2Y-B6D2-7SJ3-VVTW-MQ6C-S2MU",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"yrFrem_3XKqaQAvnlTxaZ2msYD-dBceF8NOssaE7BS5bh
  BD_ViasKtPXFncsZ-4LdAjpHE2bWKIA"}}},
    "Roles":["message",
      "web"
      ],
    "Signature":{
      "Udf":"MCJE-YAQI-I4OU-EXTX-CQ5W-IORV-HKH4",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"ayCD-NfNvsgHfxy4lyDEysG8PD36zgLq1AZmh86_R4qY2
  IpzPiymPiunbLL-pRZy8pPKDiwHPG0A"}}},
    "Encryption":{
      "Udf":"MDCW-SXW2-ROVU-4R3G-E5R3-2JGI-YBPF",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"Un-_awwiGjXgaO99A66zrVJwUi1nUaYAuftP4HTmsnZg_
  fhq3Z0rcja-z-er-BbJ9MHAqf3TxfyA"}}}}}
~~~~

The ConnectionService assertion is used to authenticate the device to the 
Mesh service. In order to allow the assertion to fit in a single packet, it
is important that this assertion be as small as possible. Only the 
Authentication key is specified.

The corresponding ConnectionService assertion is:

~~~~
{
  "ConnectionService":{
    "Authentication":{
      "Udf":"MAVT-XX2Y-B6D2-7SJ3-VVTW-MQ6C-S2MU",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"yrFrem_3XKqaQAvnlTxaZ2msYD-dBceF8NOssaE7BS5bh
  BD_ViasKtPXFncsZ-4LdAjpHE2bWKIA"}}}}}
~~~~

