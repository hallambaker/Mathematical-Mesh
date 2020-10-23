

The account profile specifies the online and offline signature keys used to maintain the
profile and the encryption key to be used by the account.

~~~~
{
  "ProfileUser":{
    "ProfileSignature":{
      "Udf":"MDUR-4AKJ-GEI7-7NXU-HZMM-C2N3-34S5",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"UQ7CJMaG5HGRpZiO6TnaeztTOISMVLo7A3MQNuXVUC6XPlO
  o1nIw3jDWMJgzs41y-hlXCy11bL2A"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MCQN-XSQB-BFSH-DUIO-75QR-OO6H-VQDU",
    "AccountEncryption":{
      "Udf":"MADQ-3NW6-SHXF-L6X6-NI2O-CF7A-X5Y7",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"074FM_JEfFlHPtMSdYtrWuvJ6-2E5-LmCaucL1rivit3173
  nc96nSMNv1xIOog0SZp15ba8apOIA"}}},
    "AdministratorSignature":{
      "Udf":"MDUR-4AKJ-GEI7-7NXU-HZMM-C2N3-34S5",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"UQ7CJMaG5HGRpZiO6TnaeztTOISMVLo7A3MQNuXVUC6XPlO
  o1nIw3jDWMJgzs41y-hlXCy11bL2A"}}},
    "AccountAuthentication":{
      "Udf":"MC5O-LURE-5J5U-SANY-LBHI-RPQN-6675",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"Av1aQAIrvbO73VhoniH-ImPZfNA6xiOOHwZ1XDxD2CAPdJs
  gDVuv7NwINTDB_g6XlMaNq0eS9RsA"}}},
    "AccountSignature":{
      "Udf":"MBGN-XQJ6-UJNE-5HVX-6RCA-CPNL-UE4E",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"uR1--x4L5hLJMyKVkCsS01gq1SdtbLraMbSsiCQGQSLSaRL
  yg0HzNggQHSjVAAHhyi09CT49JosA"}}}}}
~~~~

Each device connected to the account requires an activation record. This specifies the 
key contribtions added to the manufacturer device profile keys:

~~~~
{
  "ActivationDevice":{
    "ActivationKey":"ZAAQ-HZYF-DUTD-GLBD-SL63-CLCU-2EPM-YWRB-WAHG-ZJNX-TXWK-7MAR-PJ5U-WPV5",
    "AccountUdf":"MBCL-G5JV-3LSL-2PK5-CCOQ-KWTN-MWAF"}}
~~~~

The resulting key set is specified in the device connection:

~~~~
$$$$ Empty $$$$
~~~~

All the above plus the ProfileDevice are combined to form the CatalogedDevice entry:

~~~~
$$$$ Empty $$$$
~~~~


