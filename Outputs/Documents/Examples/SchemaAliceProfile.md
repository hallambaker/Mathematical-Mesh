
For example, Alice creates a personal account:


~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
</div>
~~~~

The account profile created is:

~~~~
{
  "ProfileUser":{
    "ProfileSignature":{
      "Udf":"MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"s850J-SQJH6YrNaP-TlHIHdg3VRTIuPH4wrFVuqvCcWpu
  1c6OQ3OOUSrodYIvO_lByy-1-rp11SA"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MBO3-YYGV-RKLJ-4JFD-OQD5-BEJS-4GYO",
    "EscrowEncryption":{
      "Udf":"MAKZ-32RA-T6ZB-6EKF-D3BD-WIHR-UE3Y",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"cJClGGEPa9ViwY6CPYRG6vPvM_v7-xDz3KDRtBdbVpxXZ
  lv4OlZMqofU1kPGCA8OXmQWueQtPy-A"}}},
    "AccountEncryption":{
      "Udf":"MCX2-6Y4I-HVHM-JV5L-2DUX-OIAY-ZFLU",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"JzMsYE7RJaoYZLNAX0X8dF1POxlHA4NYZ5wdPQIMRG3Rx
  uC6p_eSVWoCNj1__Vxh4ONRpraQHu8A"}}},
    "AdministratorSignature":{
      "Udf":"MCQA-HNKE-3TZL-KZ4A-7UVT-MXZV-S6TM",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"96EAGBSbI9Vc_1-dgNXFU60UxZi_yBtwGyU3a57xN_qj6
  yMaToHfqBNEpdVXBjDTl1uxHcYyB4wA"}}},
    "AccountAuthentication":{
      "Udf":"MBZQ-XJ7K-Y4NV-5IGT-FF3A-AIJ3-YXG2",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"XJn42BWLChTXzJlCtxpOFBJNsv_y3jcMFGUbuRxT0UdeI
  JbYX84k7X8Xc4thCe88xafQ9jdd8COA"}}},
    "AccountSignature":{
      "Udf":"MC6B-Q2VW-SC2M-4357-CUXC-2MY4-USPV",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"-WkLMkDYN2HrbKTXngllJVgLgOudAoXuMPgQWDtYIg2iS
  yE-JYd2T4D-2lCz_IIntzRDmUDWhAoA"}}}}}
~~~~

