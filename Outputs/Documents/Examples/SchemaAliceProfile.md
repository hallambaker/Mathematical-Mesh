
For example, Alice creates a personal account:


~~~~
<div="terminal">
<cmd>Alice> account create alice@example.com
<rsp>Account=alice@example.com
UDF=MANR-I5NN-5ZQH-APAD-4XOK-HR3F-L2FR
</div>
~~~~

The account profile created is:

~~~~
{
  "ProfileUser":{
    "ProfileSignature":{
      "Udf":"MANR-I5NN-5ZQH-APAD-4XOK-HR3F-L2FR",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"cIOVTmK43WbgthnwRFGsOzSr6_1kbzy_OTdHxo_orLFDT
  37eT3dNt75b60bkRt3TKI309iHVeq8A"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MA4B-4QON-NA4J-JMDY-NVKM-F3FI-5CS5",
    "AccountEncryption":{
      "Udf":"MBYR-USCY-MGJA-AKRQ-JIQM-UXC6-R5IL",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"13dzUsLeJRRMb9IT2OD8pqxluaLRPoRcWTJp6TV0BcCst
  jrqBE6QRJf4T9gnd5ZH_zXZXM3BQf2A"}}},
    "AdministratorSignature":{
      "Udf":"MD4H-7SMM-AR24-SMJH-URAS-AS67-WRI3",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"eN2dxeqwp3sZ2Dziwmy3mCOVDIF3G7FYjyVAbe6Xx2kbo
  yqdO4vMbzu3H3P0IQeJ6H4qlyheHKiA"}}},
    "AccountAuthentication":{
      "Udf":"MCQD-WRKU-UCS2-AFEY-NU5H-QFPK-DE2Y",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"-w64o4SfcmNQzYHvwumELa5rs_GT4oZC1wEaVA4AHuUuA
  lquXBT38HDDA5Wh_jUrxgcfl3tkGLyA"}}},
    "AccountSignature":{
      "Udf":"MBRB-NDTB-27WO-3QAI-WWR7-7LWX-B2TC",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"k66zJ_gzEuyimz8HcIHRspq9Y69uFF820gYYbMEc1aUXk
  NsJ5woAutJbIrGXORoHwzaQEaMLIYmA"}}}}}
~~~~

