
For example, Alice creates a personal account:


~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
</div>
~~~~

The account profile created is:

~~~~
{
  "ProfileUser":{
    "CommonSignature":{
      "Udf":"MDE2-MKMI-773P-GJ3F-YYAI-UVCK-OMKS",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"jR9urPbosloSRu58lkKG9O4L5BNzqbEs3oq8IzwLqU2Qy
  GRk8kWDok6OOwhYOcRgXeot_eVOAGmA"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MD3E-FN6W-3G45-YQ43-QXYR-CU4X-RKG5",
    "EscrowEncryption":{
      "Udf":"MBSK-2Y6G-DK6P-T6TU-OSLD-GCFW-MPHG",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"R5W0TYUycEMhGuxGuCkBTMYB1MgKZ036y052XLVbMsjxg
  g9iDD-yVYVNe_yUCm8QGtpSt_8Eb3cA"}}},
    "AdministratorSignature":{
      "Udf":"MBL5-JSN3-V56Q-4ULY-GY7X-GM3V-KVPZ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"Zc5n9q482E5RuHsJ4edWsr75axwzR3mWbm5T5lfnBTRIA
  icaGPogbqa54ySA7sWjh490xrvrEyaA"}}},
    "CommonEncryption":{
      "Udf":"MBUF-P7S2-WFEF-D3ML-OKCC-XYOT-6SLD",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"8ShFcmNz5BW9nGObu7_tUZD5hm5anS7Tar53RXDcg5ayi
  Ppb7L8zVC1ljjJeAu-hk9TUNuyXE7sA"}}},
    "CommonAuthentication":{
      "Udf":"MDYQ-JQB2-3EOC-N4ZD-FBJE-H3IY-WM6V",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"2zPl10qnzpGH_1idDFaVMyEymEf6ZmhMtzpmlGfZHZ2si
  FC0SHI4wamghsYS3hFL_qX6mO-SQQuA"}}},
    "ProfileSignature":{
      "Udf":"MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"or2X-rP0taTX66FxY68RR4R7Gfg3r6-MIc33QeEgU1wKi
  _HVKyiBnKDXZEexYtEC2ZH7CNqUC2QA"}}}}}
~~~~

