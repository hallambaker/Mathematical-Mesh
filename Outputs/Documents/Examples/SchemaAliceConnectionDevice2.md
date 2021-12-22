
The ConnectionDevice assertion is used by the device to authenticate it to other 
devices connected to the account. This connection assertion specifies the
Encryption, Authentication, and Signature keys the device is to use in the context of
the account and the list of roles that have been authorized for the device..

~~~~
{
  "ConnectionDevice":{
    "Authentication":{
      "Udf":"MCQX-REQO-6RZJ-64QZ-DO3G-4PTA-VWUK",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"gvb0B1W5k8p0XLI_BSfszl6r2QSoWn_X80oq08fHWKx27
  01u1-uCGkHUAH8YP_KWTkyNBmk2RPkA"}}},
    "Roles":["message",
      "web"
      ],
    "Signature":{
      "Udf":"MA7O-B6MX-VB2Y-4PUY-PWNU-W4OC-EHGM",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"G2-JiXpp_GAjPYF53yT3ZT7kH-n-ge9JCUjN_Y8JDo6pf
  thtcvPDKeBqpNHmlqmwJGmCWTY70hWA"}}},
    "Encryption":{
      "Udf":"MAJX-UKLP-4O4F-FH5H-4K4E-ZMGZ-OYD4",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"KwoazZwGy6N1LkWrM0ZrjaBXYTKTkuVdWr9rHdVBCOyYx
  sbOWsY3MR-luLIr6mbiMB7dCqBNBswA"}}}}}
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
      "Udf":"MCQX-REQO-6RZJ-64QZ-DO3G-4PTA-VWUK",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"gvb0B1W5k8p0XLI_BSfszl6r2QSoWn_X80oq08fHWKx27
  01u1-uCGkHUAH8YP_KWTkyNBmk2RPkA"}}}}}
~~~~

