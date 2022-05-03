
The ConnectionDevice assertion is used by the device to authenticate it to other 
devices connected to the account. This connection assertion specifies the
Encryption, Authentication, and Signature keys the device is to use in the context of
the account and the list of roles that have been authorized for the device..

~~~~
{
  "ConnectionDevice":{
    "Authentication":{
      "Udf":"MD75-RPX5-5NK4-FHKK-2PSE-DWSY-WU6Y",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"W28GpEdJVvrelRzN2hCyOI3lg5yK2nkzsQyyq4YzfuN3U
  wCPWc73iuehOe5u1XeJKU9Y4MiI5UGA"}}},
    "ProfileUdf":"MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V",
    "Roles":["message",
      "web"
      ],
    "Signature":{
      "Udf":"MBLJ-ADU3-FC24-MNUN-QVH2-7PRQ-XXQA",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"YJF91CS0ZhNQkzdmyfL_Eg5oSRjNXyd1cyKHsKXfGTYwc
  KfS1FpEolLTL0B67NOkzPAeKo-7aOwA"}}},
    "Encryption":{
      "Udf":"MAST-EV3R-CLXM-LVOO-L3FH-QHJ7-WATP",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"BCNPHKNfgzlzwVjqv1u9uHkyshl6qJUZgj_bDwwLki5L1
  u88TCB6Kr1sIcxqdihoCEUMqGuWsL4A"}}}}}
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
      "Udf":"MD75-RPX5-5NK4-FHKK-2PSE-DWSY-WU6Y",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"W28GpEdJVvrelRzN2hCyOI3lg5yK2nkzsQyyq4YzfuN3U
  wCPWc73iuehOe5u1XeJKU9Y4MiI5UGA"}}},
    "ProfileUdf":"MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V"}}
~~~~

