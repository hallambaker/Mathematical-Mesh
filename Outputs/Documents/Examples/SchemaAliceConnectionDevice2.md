
The ConnectionDevice assertion is used by the device to authenticate it to other 
devices connected to the account. This connection assertion specifies the
Encryption, Authentication, and Signature keys the device is to use in the context of
the account and the list of roles that have been authorized for the device..

~~~~
{
  "ConnectionDevice":{
    "Authentication":{
      "Udf":"MAPZ-YYBK-BIZQ-UQTQ-WYR3-KFYR-ENAZ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"h31nrvAFXgxf6Ok1mfY-q6EPsb3nu-G7y809J4t2pS3a4
  cTbvB9IPCGCON4Kv2HWdAgLYWuWpisA"}}},
    "Roles":["message",
      "web"
      ],
    "Signature":{
      "Udf":"MDIO-K2BS-IVIL-QV35-62AC-IECT-EW4S",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"deXhGkM190pgKDSttQwVEOCEpJHG5vrwc8d0KFZTNp-Wi
  2DZCOPZZ2tKbu_Lx7sByFkHsCypqwIA"}}},
    "Encryption":{
      "Udf":"MAJI-OQPK-2MYE-PCF6-6JM4-H6GR-64AU",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"whWyO2aZGW88n-sHYmdsy3q8dnCr6u7v5SXV8P-I_mxw_
  xwgtTcublPB5bamixiqY8Ca95gOKcGA"}}}}}
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
      "Udf":"MAPZ-YYBK-BIZQ-UQTQ-WYR3-KFYR-ENAZ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"h31nrvAFXgxf6Ok1mfY-q6EPsb3nu-G7y809J4t2pS3a4
  cTbvB9IPCGCON4Kv2HWdAgLYWuWpisA"}}}}}
~~~~

