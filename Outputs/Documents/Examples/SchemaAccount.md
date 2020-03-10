
The account profile specifies the online and offline signature keys used to maintain the
profile and the encryption key to be used by the account.

~~~~
{
  "ProfileAccount":{
    "KeyOfflineSignature":{
      "UDF":"MBAL-44YZ-X4GX-USBL-JAMU-AW32-SLBQ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"-RCUxnQIbCoHgNRVQO5LIDDUPCror2q-OLh1FNS3AVyBrwO
  3BedNc7nXrNCMrOTaf1MFe0ZMGqYA"}}},
    "KeysOnlineSignature":[{
        "UDF":"MADE-J3SE-LOAM-7F64-SJZK-BONE-DRPC",
        "PublicParameters":{
          "PublicKeyECDH":{
            "crv":"Ed448",
            "Public":"woAm5_XiUkEt06kUikTuxbvB7OuMasIN49S364bJjsJ6Y
  S3gvC3Qxx3qAFAaXFN84fci2YNvIiyA"}}}
      ],
    "ServiceIDs":["alice@example.com"
      ],
    "MeshProfileUDF":"MDKD-XTUR-GFP4-QD52-STNB-Q7GS-MEWW",
    "KeyEncryption":{
      "UDF":"MBLR-JASW-IDOQ-DVHQ-QF2N-YPYU-ER46",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"ugz98gp4_s8ntbCo0vZq_ZIeObWnR5mif4brZ9KaW9wKQac
  KD_-eCqGARh8CgK0MQkAjiuWlo6wA"}}}}}
~~~~

Each device using the account requires an activation record:

~~~~
{
  "ActivationAccount":{
    "AccountUDF":"MBAL-44YZ-X4GX-USBL-JAMU-AW32-SLBQ",
    "KeyEncryption":{
      "UDF":"MADT-PLZ5-ALNB-J6TB-KNXB-DDHW-RGCQ",
      "BaseUDF":"MAH7-OPP6-AQ2T-DNUR-TP53-G44K-O6IQ",
      "Overlay":{
        "PrivateKeyECDH":{
          "crv":"Ed448",
          "Private":"BzL6hi_YBuOYH9owIoCJK5--TwY819Xjw0sPmAIIQhAuEB
  3Wu0zRdqR-cWuWqpVjjPsCK8oTrrU"}}},
    "KeyAuthentication":{
      "UDF":"MB7V-YK4C-N2ZO-7RRH-CFP5-BQBU-XCWG",
      "BaseUDF":"MAFD-XLJC-JZI5-WFTH-MLCE-SJCZ-LDHF",
      "Overlay":{
        "PrivateKeyECDH":{
          "crv":"Ed448",
          "Private":"0nyl4GdTsHWGOXjfELcGzBaIglu2fJMgYxnnLv_br6pyFS
  9Xd_GxFvDisjfpz0zYZYB9U7Qmyzs"}}},
    "KeySignature":{
      "UDF":"MBVN-67EX-MPEE-CDVB-DKG4-74VF-FMWY",
      "BaseUDF":"MBEB-2PHZ-ETBR-YULL-H2E6-KP4L-YIJ2",
      "Overlay":{
        "PrivateKeyECDH":{
          "crv":"Ed448",
          "Private":"nRSQgjAvXB05s2Z4DmRGsrFKjxPl_lwq_B6IxHhUoAUYCw
  Msrvv2G5eT47i6EwB6ENedNjOl0BA"}}}}}
~~~~

