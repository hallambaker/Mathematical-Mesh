
For example, Alice creates a personal account:


~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MDKO-KEIN-OCN2-C6UB-VS2K-TNA4-WXVJ
</div>
~~~~

The account profile created is:

~~~~
{
  "ProfileUser":{
    "ProfileSignature":{
      "Udf":"MDKO-KEIN-OCN2-C6UB-VS2K-TNA4-WXVJ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"iMzboqp3ApFZhbdiyv9QWodjl342qC9E1M8ay9ub4y3TM
  yl49D0Tu_M4ExORi5vnulPSCy4N0M-A"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MCCO-ZKXM-VVYT-U7SD-OHAV-UYJZ-DCSA",
    "EscrowEncryption":{
      "Udf":"MAOI-ZH57-DIUH-KXV5-SBMZ-OYYL-WHC2",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"miQ799CtizonaRAtaKsxgukyv4R9WiMXCNgN9ecAXwECa
  v-bLTq1PeYYlibcjxJPy67rPLbrgU0A"}}},
    "AccountEncryption":{
      "Udf":"MCGS-T6PR-YQBN-KZI6-LUQO-XIVI-OSFJ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"clbnQyqSSp5SSPU-Xin6djpeDyW98hJqcuPHL2kXWq8Xg
  kAWLQI8mY_OrFSoKStP-W7v4l16jUsA"}}},
    "AdministratorSignature":{
      "Udf":"MAMR-TKMQ-2A77-WUG5-CHBB-DR2R-77FT",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"sD7kkyWryEoFI3-VsxwsFBS6OSqxUM2NcbsU-ijWdCw0s
  C-Kpk-uaRM6KhMam2_zfyNIku-MJfUA"}}},
    "AccountAuthentication":{
      "Udf":"MBZN-OOER-JIWC-C3FM-UO7I-CU35-QJLO",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"eKrlYRA17iUWhYSixuf6i5VdUMx-paimUXovlvzd3XBAV
  zB2VbMCWCcHKpkg7IKqbRQI4FIVgWUA"}}},
    "AccountSignature":{
      "Udf":"MCED-PMVZ-L4BE-WLJZ-2P4K-QINM-EHM2",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"AF5u6ZFPDsszeE28KgUpoTjdgveGXrgNBvcBJJZfY-yTV
  KOk2LNnom0J--EtQHVMDqUikpTgOhuA"}}}}}
~~~~

