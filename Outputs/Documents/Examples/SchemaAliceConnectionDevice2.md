
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
      "Udf":"MBPI-BITH-EPYS-3FYE-E35S-NDB3-VTP4",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"Y46EhbDyrvyXR2rxUE3tdjUjBHow3KIVzJ6K0PxrZDFPE
  Qkrna4Q_LG9g3LBwAn9BkyFFszknh0A"}}},
    "Encryption":{
      "Udf":"MCBL-DEQY-N5WP-FY2B-SGYT-6PH3-LTZV",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"tfB8Ulcsp7A8OuymEMZtCe45ktAJGvnFeATg9n-QB81dU
  Zsxc3IGA0Gh7khkNhLBfvd3KH-a95OA"}}},
    "ProfileUdf":"MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36",
    "Authentication":{
      "Udf":"MB7K-AWT2-34F5-TVCT-BV2K-VMRH-JKVS",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"5zHjLDHVNHALaDaO0YyASwifAmiNGTtJG-LrCsA5Oyx6i
  UVJ4Xu4WUAN_smNBRg8k85_qaMkHuYA"}}}}}
~~~~

The ConnectionService assertion is used to authenticate the device to the 
Mesh service. In order to allow the assertion to fit in a single packet, it
is important that this assertion be as small as possible. Only the 
Authentication key is specified.

The corresponding ConnectionService assertion is:

~~~~
{
  "ConnectionService":{
    "ProfileUdf":"MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36",
    "Authentication":{
      "Udf":"MB7K-AWT2-34F5-TVCT-BV2K-VMRH-JKVS",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"5zHjLDHVNHALaDaO0YyASwifAmiNGTtJG-LrCsA5Oyx6i
  UVJ4Xu4WUAN_smNBRg8k85_qaMkHuYA"}}}}}
~~~~

