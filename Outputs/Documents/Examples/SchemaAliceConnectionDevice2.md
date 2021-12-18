
The ConnectionDevice assertion is used by the device to authenticate it to other 
devices connected to the account. This connection assertion specifies the
Encryption, Authentication, and Signature keys the device is to use in the context of
the account and the list of roles that have been authorized for the device..

~~~~
{
  "ConnectionDevice":{
    "Authentication":{
      "Udf":"MBDF-BAS6-CTAD-LUUM-S2Q4-XZPC-7YHT",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"31X-2c79SG2-5gUP_t95Vg762xy8XMfuAzfE2a6egVDeM
  Jn47G0A8Q4f8mrkBmZCZReLoj-RT6yA"}}},
    "Roles":["message",
      "web"
      ],
    "Signature":{
      "Udf":"MDRU-FQ5M-RUVD-UKLH-TMS3-CZF4-IGJX",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"vDRooUWUXinpjrUbcca1mOMFc9ELzE7EdWLlU_z20uaIP
  MxZeEl-897gPmCGh2yCoobOJwuHv-4A"}}},
    "Encryption":{
      "Udf":"MDPS-NWSE-HNRW-65MY-EQ2E-27VZ-WPKN",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"CkNznVpOEOwFq1yxSxqOkCjuTNcn_plGmPFTjZwOxlzLs
  bd_od7Vr3X-BUUNGHqSx4OHZ9SukcOA"}}}}}
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
      "Udf":"MBDF-BAS6-CTAD-LUUM-S2Q4-XZPC-7YHT",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"31X-2c79SG2-5gUP_t95Vg762xy8XMfuAzfE2a6egVDeM
  Jn47G0A8Q4f8mrkBmZCZReLoj-RT6yA"}}}}}
~~~~

