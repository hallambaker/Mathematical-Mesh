
For example, Alice creates a personal account:


~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT
</div>
~~~~

The account profile created is:

~~~~
{
  "ProfileUser":{
    "ProfileSignature":{
      "Udf":"MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"rPxQ0AnkSaiXiW2XguDFXem_Tntomt1fSuC6ThOPFGP5D
  TTh2zTqPDB2Rfcv_5YaS-lS9YSMG0aA"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MCAO-XTIB-YRN5-OZY7-PQY2-V677-UTBG",
    "EscrowEncryption":{
      "Udf":"MAOD-GQDE-6QAO-52MB-N3IX-M3PN-QHCF",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"kYMS88IAlzeF3KxZ-nVKL6I0vPrx_Q4eIRDTy-YQr04pC
  kPOsogIGQI6Svj3TLK_7_0kzOe0SwqA"}}},
    "AccountEncryption":{
      "Udf":"MB3Y-65NW-JLNN-IFIC-SYTO-5WY3-SCR3",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"2zDg0gmKl9MsMUygI1IA6poAJ2H24LW_AR6KMR2EgkLLr
  ko0QBkp8U8i7W6jB-rmT7ZmzY4K3QIA"}}},
    "AdministratorSignature":{
      "Udf":"MAYL-7BB5-DHIL-TXL7-AZW3-HRZC-JSY2",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"o0d9REsQKWW3z9GAeOypxZPSjmeT77ogJAsOeDhcpnZbi
  8Yb0ISvGYa3Vlhe28glGiRt38JoXxqA"}}},
    "AccountAuthentication":{
      "Udf":"MBCB-SML5-UM65-4MGJ-KKSY-ZGST-7OPZ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"7R-MMZJYgOE9YANa_HzHcwBDxJMWttIdpcnc9iycOtRs7
  yUkgHFth3He1qx0pAJACnaLiW1gh7QA"}}},
    "AccountSignature":{
      "Udf":"MBSR-GKG7-UE3F-S3NL-AADL-VGQV-CGUV",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"gR40-Zjo8WX45eJWfihA5htn1Qmdm0hNCylO63GvmIOK9
  Cat8PudGItFl_wbyZ5jWIUxfukpGuKA"}}}}}
~~~~

