

The account profile specifies the online and offline signature keys used to maintain the
profile and the encryption key to be used by the account.

~~~~
{
  "ProfileUser":{
    "ProfileSignature":{
      "Udf":"MCAP-Q4KN-WUUZ-PAAK-AB6K-5JVV-AKRD",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"BKWzxdJZGtaUcv-H6tDgpt9-lZ5s84SjsTKnMpqIZCY9t2a
  00HPN1_r_rrua8aIshqBoKN3hUwcA"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MAC2-XY6M-MEV2-QFIM-43XQ-5M3B-NZSE",
    "AccountEncryption":{
      "Udf":"MBRX-NLXZ-KETC-U4P5-6V3F-K54Z-TWEA",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"jrlfdLfurS0dZNsjvq4BjPqnSzqRM8uSFFyqNI-SwhvwFMx
  6-0l86g9IrpsZUeOBLcIRWeUflB6A"}}},
    "AdministratorSignature":{
      "Udf":"MCAP-Q4KN-WUUZ-PAAK-AB6K-5JVV-AKRD",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"BKWzxdJZGtaUcv-H6tDgpt9-lZ5s84SjsTKnMpqIZCY9t2a
  00HPN1_r_rrua8aIshqBoKN3hUwcA"}}},
    "AccountAuthentication":{
      "Udf":"MAJ5-B3P7-P3BZ-URXS-Y44W-X2JA-SOMM",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"_HmC3ec0QxUv8-YXZN3NIjrNBK5FUQ5DsDKPlO0UgfdQgsf
  O20RTMo49x1Key8Oi65wsE2WKJwuA"}}},
    "AccountSignature":{
      "Udf":"MBKV-CEFR-UTO2-W36K-M5AK-UXPK-CWNC",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"Bk1IcORYC15_dkwG5sWYDWwMVV0M_8cCVn8JSHWkahU4Vyq
  38F2p84PcBdVcgLLPHYXKnmq_JY-A"}}}}}
~~~~

Each device connected to the account requires an activation record. This specifies the 
key contribtions added to the manufacturer device profile keys:

~~~~
{
  "ActivationDevice":{
    "ActivationKey":"ZAAQ-G5LM-HVPL-QAXJ-YGZA-WC44-ZI6J-PUCU-N7KW-6RQ2-5ERX-AH6Z-SWY7-N3BM",
    "AccountUdf":"MDBM-S4YO-CEAO-POM5-EGOS-INZO-P24W"}}
~~~~

The resulting key set is specified in the device connection:

~~~~
$$$$ Empty $$$$
~~~~

All the above plus the ProfileDevice are combined to form the CatalogedDevice entry:

~~~~
$$$$ Empty $$$$
~~~~


