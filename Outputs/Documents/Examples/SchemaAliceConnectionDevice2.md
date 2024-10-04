
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
      "Udf":"MCS2-2VTH-7FGF-2ETJ-PJQZ-PKPO-3NZC",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"ZugWLydgBgLa087iFRwA19w9iC3VCxym8L6AceP-FFqii
  zFUkyONCeryM-erdSZy-W7GPtQFDkuA"}}},
    "Encryption":{
      "Udf":"MCUM-EI7S-VLIJ-ALQO-SPSK-VM5P-R6MA",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"vzBo5i9gRd3Vj3b-JCsCTUjjwUKe8knUii680EnNpkuB8
  ODc_lVzA6qJPo5JA--SoMXbVAtY-8oA"}}},
    "ProfileUdf":"MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA",
    "Authentication":{
      "Udf":"MBO5-BV4J-OXHA-RA27-3CAW-4WNR-XOYW",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"p2oXCigHVLc_CJDsyeBcRWSmF6DirEXrApIjEaJXJ58Gs
  1DfGTD2nMLDsSlxPzlZOhxAuq4v1AsA"}}}}}
~~~~

The ConnectionService assertion is used to authenticate the device to the 
Mesh service. In order to allow the assertion to fit in a single packet, it
is important that this assertion be as small as possible. Only the 
Authentication key is specified.

The corresponding ConnectionService assertion is:

~~~~
{
  "ConnectionService":{
    "ProfileUdf":"MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA",
    "Authentication":{
      "Udf":"MBO5-BV4J-OXHA-RA27-3CAW-4WNR-XOYW",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"p2oXCigHVLc_CJDsyeBcRWSmF6DirEXrApIjEaJXJ58Gs
  1DfGTD2nMLDsSlxPzlZOhxAuq4v1AsA"}}}}}
~~~~

