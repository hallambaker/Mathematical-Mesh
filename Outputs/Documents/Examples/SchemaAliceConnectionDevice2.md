
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
      "Udf":"MA72-GAIH-AETH-DMWS-6WMP-TX4P-4DSR",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"JT9yarZYOkJlcW43IopCv6oS4Ode9JCgzOTys9xRvtDRE
  Ajywqk70JbSzBucJL9u3egYKCOdUo4A"}}},
    "Encryption":{
      "Udf":"MARU-OXNG-MA6F-7LZQ-R75I-2DSO-7RHN",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"sa2gDOJ6fqmAYsT2FM96o01XjIfMF_DsCzSrGAtQp0YA8
  gsF8_GGYTl3xr1wJcYXkdT0pdUkNEoA"}}},
    "ProfileUdf":"MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2",
    "Authentication":{
      "Udf":"MBGO-55A4-MBVM-L2G7-4T5B-NILX-AODX",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"UnCaMwkkjEbs7jHvvKvzlLYCdnOjIIRRSn_xEx-0_OEge
  LLH2bsK2PqYr7tIsjmJGi84ry7FDB-A"}}}}}
~~~~

The ConnectionService assertion is used to authenticate the device to the 
Mesh service. In order to allow the assertion to fit in a single packet, it
is important that this assertion be as small as possible. Only the 
Authentication key is specified.

The corresponding ConnectionService assertion is:

~~~~
{
  "ConnectionService":{
    "ProfileUdf":"MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2",
    "Authentication":{
      "Udf":"MBGO-55A4-MBVM-L2G7-4T5B-NILX-AODX",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"UnCaMwkkjEbs7jHvvKvzlLYCdnOjIIRRSn_xEx-0_OEge
  LLH2bsK2PqYr7tIsjmJGi84ry7FDB-A"}}}}}
~~~~

