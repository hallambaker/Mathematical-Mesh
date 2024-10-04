
For example, Alice creates a personal account:


~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA
</div>
~~~~

The account profile created is:

~~~~
{
  "ProfileUser":{
    "CommonSignature":{
      "Udf":"MBAE-EXHC-DOEX-EMF4-VXOT-G32T-ZKXU",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"pb78yKbCuNl2K4WD8RDl9GxMtuLdxxjurAmaMnvJzFAgU
  fI3JZj68Q73M6K6Ehi6mLOPGLusRLAA"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MBQB-N254-VJTL-CHYH-YJTY-5H62-RHYG",
    "EscrowEncryption":{
      "Udf":"MDK5-GQ6X-6CEQ-7OL6-YEGY-SAQW-774P",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"yU_krLe7nc4KwQSNTAkKYr4MLEHfiung_knhn7ujIwVtZ
  lg1daZzOehNtZ14QJ8Owd8jai1Mr5WA"}}},
    "AdministratorSignature":{
      "Udf":"MD5M-A4YJ-AMPV-YTOS-3GVV-62RQ-HW4V",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"PizD__Cns8LSoibGrN6LnNrKg7bshtR4po9_evPcGq9mp
  _1DDf8101mB7bJCrExC1iz60V1vx0mA"}}},
    "CommonEncryption":{
      "Udf":"MANS-YZVU-VA6V-CCK6-PCQR-E2QD-5F6P",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"qzOeN8GZx61IvW0RDYp4oeMUtw3vzGsxJXgManAfOLtoB
  xUrgB2Q9GJoXy9-Tv2oEqmPagi0_W0A"}}},
    "CommonAuthentication":{
      "Udf":"MDRU-KSKF-UNP2-BKXE-XFDS-B6AJ-FBDA",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"-UyTp6TrS4vnrKH4ixeXkyrr9pLCThmIodDRs5UHu4TRj
  EVfyJmFtUbr8dLdWs8f2_vt6vFLJaOA"}}},
    "RootUdfs":["YM5fma4C0z0in1cD09uvOw18dxAM-HwdJdqMR4VJ2QGtFkiTO
  LPUq4_nRS1kjUrHrbXhe9tjVQW17TwZxwJgED4"
      ]}}
~~~~

