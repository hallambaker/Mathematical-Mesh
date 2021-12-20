
The ConnectionDevice assertion is used by the device to authenticate it to other 
devices connected to the account. This connection assertion specifies the
Encryption, Authentication, and Signature keys the device is to use in the context of
the account and the list of roles that have been authorized for the device..

~~~~
{
  "ConnectionDevice":{
    "Authentication":{
      "Udf":"MARC-D26I-BHKO-XBOP-R7FZ-ARUJ-J7M6",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"SvY7sRN3j4fCIQowpMSbdhQC4K8jrpnKxrLjkgQ1C7qA-
  _50kdPyJvjTaNtHGwwmRncPkh1f0uYA"}}},
    "Roles":["message",
      "web"
      ],
    "Signature":{
      "Udf":"MALC-O7CI-BOFN-WF64-JA4O-G2N5-TR52",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"GK4RxNTPXK6OHqWOemjjL45hK8hu5LHzYJlJocm91CXNq
  YPYMjhnb_PO4pqb5aML5pMKlYM6k42A"}}},
    "Encryption":{
      "Udf":"MAMO-D7BL-QXIA-KRT6-AH5N-SLWA-YVPG",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"cIcyQ2zsyI7ckEqD0cLSQl16bttUw_HV1otCUgITKxqbK
  VkRzGSl9xTaBpupOQYO1eqa7ZYEHIQA"}}}}}
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
      "Udf":"MARC-D26I-BHKO-XBOP-R7FZ-ARUJ-J7M6",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"SvY7sRN3j4fCIQowpMSbdhQC4K8jrpnKxrLjkgQ1C7qA-
  _50kdPyJvjTaNtHGwwmRncPkh1f0uYA"}}}}}
~~~~

