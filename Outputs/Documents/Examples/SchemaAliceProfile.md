
For example, Alice creates a personal account:


~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
</div>
~~~~

The account profile created is:

~~~~
{
  "ProfileUser":{
    "CommonSignature":{
      "Udf":"MDSC-FB3G-FEPA-PXO3-MFLY-W5LR-WOBU",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"pa6ypHQ5iY5a2wVA4nvQrnIs9Pd4zyojdkh3uiqK3UZHn
  tj5ABjhhh4hUoovYNsw39K8_3VdaSsA"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MBQP-EWUT-UYX2-Q3GS-HB4O-3VBQ-IKP2",
    "EscrowEncryption":{
      "Udf":"MBMK-5ZGZ-Q67P-EZ4I-5WBI-LX74-MAYO",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"Er1iGrG6bUK2l9RHYBx7D5J2YLvbbbeO8Ufyx48Grmsu8
  B046z0numrby-6C8iPRrkW0_iZvkakA"}}},
    "AdministratorSignature":{
      "Udf":"MBLM-W4XU-5LMK-3REN-25WP-GWFU-EKTV",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"9w6NcrhR-H4xdgCMU79Vn5Lopr254Unif2O_YgqY0xBIf
  uHC9OZIS_vbkgsC2dfYnSNwG0X8FukA"}}},
    "CommonEncryption":{
      "Udf":"MDSO-NJIQ-HUNW-UWRS-WPOE-BBO3-NDWN",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"b5UE5RWmL-zCvswqDEk6K4gTTrD1k1oipAEeB9yPduihE
  7by0CkYw2CNU4UzY3dSJfrtfsT_NYyA"}}},
    "CommonAuthentication":{
      "Udf":"MCLL-ZBZW-QK2N-XDHX-VT74-FBTC-N5U2",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"HKqeAzjalCkzHFOly5MKYUUyrF3dDZTl8Y2gW2Op0uKMI
  1O5ThctnCRg7EaYBcL-QusEsLN6JauA"}}},
    "RootUdfs":["YMekqG_0ghUhi-fFCAnJ5bpRTHAalVt1nr1YSLtZ4RTGa9fNL
  kGfGT1ZyD6xdBFgwKMWC6brtyjDKyfzFHYsvw"
      ]}}
~~~~

