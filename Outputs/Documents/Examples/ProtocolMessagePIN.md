
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool:

~~~~
{
  "MessagePin":{
    "MessageId":"AD6E-S7OC-XTQK-6IQY-PCE2-FEOB-C7U5",
    "Account":"alice@example.com",
    "Expires":"2021-09-18T13:08:46Z",
    "Automatic":true,
    "SaltedPin":"ABQX-3YEF-U6BP-OZNP-5YEY-TMND-EEXP",
    "Action":"Device",
    "Roles":["threshold"
      ]}}
~~~~

This pin value is used to authenticate the connection request from the device:

~~~~
{
  "RequestConnection":{
    "MessageId":"NC3L-3XL6-HQ2Y-HLNU-X46H-VRQE-QNHA",
    "AuthenticatedData":[{
        "EnvelopeId":"MAM5-JIA7-DSS2-HXXB-63TD-RDS5-U4XN",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQU01LUpJQTctRF
  NTMi1IWFhCLTYzVEQtUkRTNS1VNFhOIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTA5LTE3VDEzOjA4OjQ2WiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUFNNS1KSUE3LURTUzItSFhYQi02M1RELVJEUzU
  tVTRYTiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIjZEM294Ymk0NXVTNzBzdmszLVM2OG04Tk51UFRwWWxLc0pJWG
  F4ZnBMY2k5elFCZi1RWEUKICBCVWFJaXVac1FrTl9OM25tOWJTSWZPd0EifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUQyTi1aVFQ1LUo1WkYt
  UlRTSC1BTUU3LUpSR1UtWkdIWiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiLVNoUC1iN3dRQWlUMHRNMDE2RHc5THJ
  5UFNjUEJ3MzdsQ08tNVhKT2U2QVlBeG1rUVBNSgogIGhtMndmdC1EMEZBMjBlSHM3
  REFzbEV3QSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CV
  DMtRllCNC1RQU1WLUNEUjYtQk5SVC1SQVM2LUtGUzYiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJBcFl4VnRPUUx5
  ZWxQOGdjNktCa2dvVW5Vc2o2U2ZhS3N3enFYc3hpX24yUEQtU0YxQnZECiAgaFVFT
  kJJUjRKUG95TmJpUkhhb0ZiVnFBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQVcyLVBOMkctQVcyTi1RVEhYLVhRRVItTVFJMi0yT1R
  HIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJsa2dOUG5mRlBQX1ZUUXBVOVd4Z0tHLS02MVkyRHZHalNxV2JrVUZlcn
  RQLVJQdUhhY3dJCiAgLTQtRFVURGloM3RvUTYzVWpoWXJQQktBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAM5-JIA7-DSS2-HXXB-63TD-RDS5-U4XN",
            "signature":"PoS2SUPDoGZeKM4zwjnNDU1urHo9BfqQqhJwI3xq
  iAKHMoMCxSBJ-KMargksozYVZa5QcZG8jwYA8_xdALjfxl0E9E8Stc4Gaj6Xkve3x
  7LL21ArYtIErmrzCAdLQ1k6uriQkVLBaKDc9wgSE3jGbCwA"}
          ],
        "PayloadDigest":"jxm4u-0-npWeM28aPqrTEb3dvyc4tDpmjdDOXCHJ
  93lbXQvBABp2_h-SAOGCAXiziOEMvL8D3wby3PahqtwhMg"}
      ],
    "ClientNonce":"EtEkf05wmuqD6W1iYs56uA",
    "PinId":"AD6E-S7OC-XTQK-6IQY-PCE2-FEOB-C7U5",
    "PinWitness":"ReJ2OMUCTZwGU_M0BoJZ1cTiO2jcxtVbGgPGChVXdHV99BS
  9vc0gKqidCElSPkOPsZm27awQ79nOMrlSc7ftNg",
    "AccountAddress":"alice@example.com"}}
~~~~

The administration device can now use the PIN Identifier to retreive the 
MessagePIN from the Local spool and use it to verify the request.

