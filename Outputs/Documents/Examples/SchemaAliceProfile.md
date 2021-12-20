
For example, Alice creates a personal account:


~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H
</div>
~~~~

The account profile created is:

~~~~
{
  "ProfileUser":{
    "ProfileSignature":{
      "Udf":"MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"E1Yv6LtxkzuLg00GsuRSqpzLQhWhWFKIgEO5xqicfqmQg
  ch-0ceKi01qS8xSTaj0qXtSYK29EGmA"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MCMP-LOU5-4CBD-VDOW-2FCF-CCCQ-GESF",
    "EscrowEncryption":{
      "Udf":"MBQX-RBLO-YRXD-HKQM-VGUK-U37Z-5T6B",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"MA6AGA2LPTh3I4mSXZ1bYnVZy3bcf1St0c21DWPX14w7f
  w6AFP1sGcheSIpA_fe2t816GfO2LhyA"}}},
    "AccountEncryption":{
      "Udf":"MDRQ-D4T6-ZXL2-BVBU-V3TG-RB5A-ERMA",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"4mxqvs-brNumowI0Iazkzaf0y6r5OIkl8ncFjzKrtjJlX
  B-HF2wQMmuW290f6T53W3t8KioaA6qA"}}},
    "AdministratorSignature":{
      "Udf":"MDOK-Z2LS-6AO6-ZU5V-FEUG-QXPJ-IR4K",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"o4hiUnup81xVJGMTiKmdNPHz6G-gRNPYlQ-Czllq6dYUP
  DbTe6LCm-6K-RWAO93mVuCopd-V3a2A"}}},
    "AccountAuthentication":{
      "Udf":"MCNW-H7XM-DYXT-XKBY-BCV2-I24F-AGN3",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"RXxuCnKmPnq76mZ_N3ugjmGrM-Qu_dKTJH0jvd92ACXEV
  LwHpdXaEBHwwGlua1cNkLOaY-jG1vAA"}}},
    "AccountSignature":{
      "Udf":"MAOO-H5MB-HWN6-4CSS-SJF3-6RDL-KD2M",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"Ehbj3stAyoWqy2FYekl6qe8P4OT-6Zw-pqBd8Z0FWsMEx
  Le2zCFNKY249qecBrWmywkmm1aINF2A"}}}}}
~~~~

