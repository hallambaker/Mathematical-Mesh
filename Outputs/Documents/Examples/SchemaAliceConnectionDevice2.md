
The ConnectionDevice assertion is used by the device to authenticate it to other 
devices connected to the account. This connection assertion specifies the
Encryption, Authentication, and Signature keys the device is to use in the context of
the account and the list of roles that have been authorized for the device..

~~~~
{
  "ConnectionDevice":{
    "Authentication":{
      "Udf":"MCEE-JWYU-IONE-6V2L-NR7N-AK22-FWHF",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"SOwxFYbbXxS7N2D67MN5OmNTJvLvCUgPGxWpF0Pww52hk
  fs2QFC3VgqlQDPBIxU2ZCHkKGtc-fUA"}}},
    "Roles":["message",
      "web"
      ],
    "Signature":{
      "Udf":"MCVP-YNUZ-WZ6D-7HYV-C5GL-OLPW-Y2LS",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"YdEsIKaIB55qNxPC3338d5GDyIqsHKipE968FwX5xM0ay
  wR5FyY7z39RpYGszISJ3uHradJ_kkgA"}}},
    "Encryption":{
      "Udf":"MBAQ-EITT-JJ72-SVTQ-4674-D5D4-FGS4",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"dNGO1OfCZgNQb5VikCHQCOY5T51Lbf9-cZTI8jaMm66NH
  F5nXB8SZ6ODRlsWDAxc5o-1sesxVbKA"}}}}}
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
      "Udf":"MCEE-JWYU-IONE-6V2L-NR7N-AK22-FWHF",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"SOwxFYbbXxS7N2D67MN5OmNTJvLvCUgPGxWpF0Pww52hk
  fs2QFC3VgqlQDPBIxU2ZCHkKGtc-fUA"}}}}}
~~~~

