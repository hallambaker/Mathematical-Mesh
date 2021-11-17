
The ConnectionDevice assertion is used by the device to authenticate it to other 
devices connected to the account. This connection assertion specifies the
Encryption, Authentication, and Signature keys the device is to use in the context of
the account and the list of roles that have been authorized for the device..

~~~~
{
  "ConnectionDevice":{
    "Authentication":{
      "Udf":"MB7N-QSGX-3QKH-5L5E-CTPA-H5EK-LVYU",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"OIVR98unWGKRIeuasqphMZq9hTRVfJcXPHN_q-UPrn2k8
  CV85Kid06zomEoHNdAcpcCcVP3EJwwA"}}},
    "Roles":["message",
      "web"
      ],
    "Signature":{
      "Udf":"MAMU-5DAC-RMRU-J5VH-ONY6-DMML-BJVS",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"lM0UNrzn3msgwDYs6XqE_qL9eeB-mEbgg60JlsJOeL5N4
  DBcqOuQtPimcqMlFPSdxOHrn9jYBG2A"}}},
    "Encryption":{
      "Udf":"MDH6-43JJ-WGIS-VDSE-A3HA-HM6S-3TCP",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"3hhKkF4KsSDyhcxo_slEZaN__aogdH2t2pZcTg4kTyNGu
  2400-Bh7hJhT4YaB56Px3wdofX9CByA"}}}}}
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
      "Udf":"MB7N-QSGX-3QKH-5L5E-CTPA-H5EK-LVYU",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"OIVR98unWGKRIeuasqphMZq9hTRVfJcXPHN_q-UPrn2k8
  CV85Kid06zomEoHNdAcpcCcVP3EJwwA"}}}}}
~~~~

