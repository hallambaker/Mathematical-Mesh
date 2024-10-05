
For example, Alice creates a personal account:


~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
</div>
~~~~

The account profile created is:

~~~~
{
  "ProfileUser":{
    "CommonSignature":{
      "Udf":"MBN3-5FRI-PP6T-TUDK-EQVQ-6YG2-QQKP",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"ctEH6XFs_jYg7Uu8gmQyTkM7pKNLxNHnuh4GjH7iVK765
  YGXsSpavf58enP5F8NdkknB080eBYqA"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MBQH-INKI-FD4A-QLNG-CSXQ-CB7I-UESI",
    "EscrowEncryption":{
      "Udf":"MBDS-BG2D-PNUM-A3JX-VNDJ-J4EO-3HQC",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"f1VigW90ihMu3qY419lFp2VRCWi4Li3shHdqXjTEyWWcb
  8YzDvA8uON-Jns1MrauQbs1I6uRGB-A"}}},
    "AdministratorSignature":{
      "Udf":"MAOW-5PUN-MGDW-NTP4-42BU-XE63-JKHS",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"Q_2pVCUnxPYad0y8lBWNjp82zQjQB3Hpxhn_k1fcPbYAJ
  F7pc7_a9vvl6CRzanI26SO0mk_FEIEA"}}},
    "CommonEncryption":{
      "Udf":"MB54-OEEK-JZSG-TRLU-HPIR-SABF-T35O",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"tDHNPXI-VP44WlR-LhNYV1PiLXJM1OEq0m53yjjGPRpX2
  wEN8unTbGhYCu08feBrTlxLKtwYlDoA"}}},
    "CommonAuthentication":{
      "Udf":"MCOS-VDOR-E7AU-PVOU-CGEV-QO6Y-JR3R",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"g0md81a7oSXzO7L-TTfr5DBs4lva5xdTgMT5k2T_Ge0EI
  lbatye8f7cclA2gb7m75XAN4sSFcn8A"}}},
    "RootUdfs":["YLBm62Xo8qOQrRNeZjuBQc00XklWJp_2FEsKyCm7ZJ-vTwCyK
  BYS_XhHt765abeFAcXbgY69wlcDR0LXwRpeNTY"
      ]}}
~~~~

