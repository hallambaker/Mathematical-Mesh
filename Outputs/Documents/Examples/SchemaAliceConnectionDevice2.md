
The ConnectionDevice assertion is used by the device to authenticate it to other 
devices connected to the account. This connection assertion specifies the
Encryption, Authentication, and Signature keys the device is to use in the context of
the account and the list of roles that have been authorized for the device..

~~~~
{
  "ConnectionDevice":{
    "Authentication":{
      "Udf":"MBNB-OU2G-NLQU-FOIB-ZHEB-WQQP-W2IU",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"L4nladXNX0hQO2YpoPfEiKwE--eHLkU6EpsHmZCSt6C9A
  vUm6b_pXIgWUawgD8lybKdLIrXXJEMA"}}},
    "Roles":["message",
      "web"
      ],
    "Signature":{
      "Udf":"MBPC-6PL6-XMMN-JV66-4ALP-52SU-XSU7",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"u6_7sDuUi5Bzykwp1MMmBtvgT8QLSVEQrZclf89GPdC5Q
  G0H8rJtphNZFkE_ITpzKPj-ty9hWTOA"}}},
    "Encryption":{
      "Udf":"MA6H-H3OR-VMFQ-EF5C-GF6L-FRHW-YB7Z",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"Tn9Z1-GMa3gDSUGDuGIvojZ2Ape6y5NHQbkmRZ_WhAux7
  bMQAXOzDPmnhih40zznvpfB7dyoqQUA"}}}}}
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
      "Udf":"MBNB-OU2G-NLQU-FOIB-ZHEB-WQQP-W2IU",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"L4nladXNX0hQO2YpoPfEiKwE--eHLkU6EpsHmZCSt6C9A
  vUm6b_pXIgWUawgD8lybKdLIrXXJEMA"}}}}}
~~~~

