
For example, Alice creates a personal account:


~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
</div>
~~~~

The account profile created is:

~~~~
{
  "ProfileUser":{
    "CommonSignature":{
      "Udf":"MBJB-QS7J-ACZ2-FVMP-ELSA-EWGT-X4YW",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"ewQwW7v1QTuGwYn3od0PB3nX6QCpI4s-OIqx20-RRiuFo
  o7zJNTf2Ek3v555yu0MRLvPv6nVMq8A"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MBQI-PMGC-6W73-XR4A-XZY7-Z3KB-RYQ5",
    "EscrowEncryption":{
      "Udf":"MCR4-WN62-VAJ5-US2G-XVGJ-22RT-TYIQ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"00Qa42DJkuQgZFY-8MRXR-qbELFgyHThumKJAgo9wU47u
  -q3OQwnhxtmEhApXZ9vF0sROgQynHEA"}}},
    "AdministratorSignature":{
      "Udf":"MBJV-4SW6-OHDS-EWDH-S5TT-2EU2-IFNZ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"edNWV9cDO4LP_Gvz6Me02oE5gYOfAkNqVw-hsOtxmf0Pq
  TsiNU5rWGqWlHUku36g7FKS4UCl-KcA"}}},
    "CommonEncryption":{
      "Udf":"MDRA-PU42-MQON-2CUT-OO6N-IQUC-HFNA",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"-kEu0TYsGRe0nSwl5I5JP9_tbsXWb4ezF6heRieo9FfPU
  usn6jTzUjwb_hWBRvVgci3XeRJvzACA"}}},
    "CommonAuthentication":{
      "Udf":"MA6H-CQSC-IPDZ-VFH4-ZC3F-C4KL-YLJE",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"h1zxvXNz1Gm2dvKtbAG6jcDyxvyp6-P-kcaaTwYNDUEwr
  0Yh8hdS048e2gpA8s-2vLQp7BckDFAA"}}},
    "RootUdfs":["YGF2fVdzERoPaARjkE9O3n0GQ1u8daFCSRrjhSa7su3SHIMYt
  gFoQSOpeDSdBpQL9X_GBblVDi_SS99lzuGdqw"
      ]}}
~~~~

