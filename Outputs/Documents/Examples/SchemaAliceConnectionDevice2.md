
The ConnectionDevice assertion is used by the device to authenticate it to other 
devices connected to the account. This connection assertion specifies the
Encryption, Authentication, and Signature keys the device is to use in the context of
the account and the list of roles that have been authorized for the device..

~~~~
{
  "ConnectionDevice":{
    "Authentication":{
      "Udf":"MBM7-N7XJ-YI3A-UGJ7-N27J-RUKJ-4KMI",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"EN-t_fF5XNjdkgXTw55uVZkX7qhVEgh9O6mTH7-qtEw8M
  xCMM3MKV8m4OvjyCxPvmumJsU438zeA"}}},
    "Roles":["message",
      "web"
      ],
    "Signature":{
      "Udf":"MAJ2-GYTM-UPW3-K2KH-LSKM-JPR5-DZST",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"1q1QfrswM9YjS3ww6QJJbIqLRWGmYt6tEJ7grm_T6DRJx
  2pFCmm8LWuyaN3TMbADKLKPnnVoX3YA"}}},
    "Encryption":{
      "Udf":"MD2I-73C6-DRGO-EUNM-2FLU-NHHA-G6WR",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"D1svFzl5eZssBGWJ2oEmQRiPxfZ6re_utUVW0XCU1p0qO
  sRegE49ztqEDoXcCGI2XdxnV3hI5hGA"}}}}}
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
      "Udf":"MBM7-N7XJ-YI3A-UGJ7-N27J-RUKJ-4KMI",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"EN-t_fF5XNjdkgXTw55uVZkX7qhVEgh9O6mTH7-qtEw8M
  xCMM3MKV8m4OvjyCxPvmumJsU438zeA"}}}}}
~~~~

