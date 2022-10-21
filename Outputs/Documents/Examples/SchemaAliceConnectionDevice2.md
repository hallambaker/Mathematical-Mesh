
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
      "Udf":"MA56-V5KL-YMCF-GI3D-PI2F-4OWT-73K6",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"297PWEg-l0jLJzknMVhNY9OGAZZNYHc_leI4Nq72_XRQa
  8LZSajlhJBKOtEjVGyUITQRLj0aYO8A"}}},
    "Encryption":{
      "Udf":"MA6D-RU2J-LL73-LAW6-7JO6-IFCU-WRNI",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"D-HnzU7WQrAjSfiQYLRxSiIK-PBqBHXKSR-1oX1CO5Gb6
  1L31-IV13stjhnXipqeNmuYfpovg0EA"}}},
    "ProfileUdf":"MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA",
    "Authentication":{
      "Udf":"MBYN-SC4W-IU4X-LIVF-PSC6-6ADO-ZJOF",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"e1nZiuxVRE20PCUKSfqC-ee5yRis7TaKZrlwmEI9RpacG
  f0vc7n3i8l7D_BaryByAUmpFyfKUs0A"}}}}}
~~~~

The ConnectionService assertion is used to authenticate the device to the 
Mesh service. In order to allow the assertion to fit in a single packet, it
is important that this assertion be as small as possible. Only the 
Authentication key is specified.

The corresponding ConnectionService assertion is:

~~~~
{
  "ConnectionService":{
    "ProfileUdf":"MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA",
    "Authentication":{
      "Udf":"MBYN-SC4W-IU4X-LIVF-PSC6-6ADO-ZJOF",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"e1nZiuxVRE20PCUKSfqC-ee5yRis7TaKZrlwmEI9RpacG
  f0vc7n3i8l7D_BaryByAUmpFyfKUs0A"}}}}}
~~~~

