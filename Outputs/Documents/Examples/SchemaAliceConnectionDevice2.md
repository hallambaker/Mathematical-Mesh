
The ConnectionDevice assertion is used by the device to authenticate it to other 
devices connected to the account. This connection assertion specifies the
Encryption, Authentication, and Signature keys the device is to use in the context of
the account and the list of roles that have been authorized for the device..

~~~~
{
  "ConnectionDevice":{
    "Authentication":{
      "Udf":"MDGT-XIVV-VMOC-36XQ-5H34-E27N-5YVX",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"g1wRYZZcBEsjPBAsgDsikr6ZFNMwvxO3OPD8-wQE0Kf1l
  imtk44miVdgGQADD0QCxl_iEaNJ6FEA"}}},
    "Roles":["message",
      "web"
      ],
    "Signature":{
      "Udf":"MDKV-OXAT-RFKS-TAH3-7FD2-XI4S-53M4",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"U_XAmmpdHBBwMdPwr6MZlghfNVS0pIOuXXc850PdRqfyi
  sGwqiyH2Mn41mA8my-A8i4Bfzvd-X0A"}}},
    "Encryption":{
      "Udf":"MDTP-I5SG-QXU6-KZ23-LN7T-YETH-N3AQ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"Ze4Cau5fcY0EpWtbed-nHsV0jvIEKvSGlJzlUzqdjr9VV
  RJK0HDVOrFpiLT7TcdYvOw5rElz3f4A"}}}}}
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
      "Udf":"MDGT-XIVV-VMOC-36XQ-5H34-E27N-5YVX",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"g1wRYZZcBEsjPBAsgDsikr6ZFNMwvxO3OPD8-wQE0Kf1l
  imtk44miVdgGQADD0QCxl_iEaNJ6FEA"}}}}}
~~~~

