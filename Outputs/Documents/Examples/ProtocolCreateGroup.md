

The request payload:


~~~~
{
  "BindRequest":{
    "AccountAddress":"groupw@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MDB6-RZZL-YWTA-RD54-XVG7-MAW2-VG5H",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNREI2LVJaWkwtWV
  dUQS1SRDU0LVhWRzctTUFXMi1WRzVIIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUdyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTdUMTM6MDg6NDRaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZmlsZVNpZ25hdHVyZS
  I6IHsKICAgICAgIlVkZiI6ICJNREI2LVJaWkwtWVdUQS1SRDU0LVhWRzctTUFXMi1
  WRzVIIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymxp
  Y0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgI
  CJQdWJsaWMiOiAiLUFUeFZlWi02WGtPczV1MDhLV1RKXzlsSWkwc0VMODdHYXJxdH
  ZUOHVvdGhFWG82ZUVrUwogIGkxLVZESFZaTGpPNkNzZ1dzUW1rVjNtQSJ9fX0sCiA
  gICAiQWNjb3VudEFkZHJlc3MiOiAiZ3JvdXB3QGV4YW1wbGUuY29tIiwKICAgICJB
  Y2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQjczLVlVR1gtR1JJS
  S1CWkEzLUpTSUktMjZGUC1LS0tTIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOi
  B7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg
  0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJtS3VTcnFwRlgzazJ2QXJ2Z0dzTUM0
  LWZJV3lNYlBKMEVRdTEwb0JNaTFIODBFZDJQSG1qCiAgN2xCNUplWUEtaGswX1djV
  DhnS2hwOG9BIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogIC
  AgICAiVWRmIjogIk1DVEQtV0NQVC1TQk9ZLUFHVlEtUEpTUS1FNTQ2LTdPMjYiLAo
  gICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNE
  SCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJ3N1VpeWRCR1QteEtWVzhXSmFEYzFxa0o0VWFqcDVud3hEOXpxekVoS19tSm
  1YX215NFZoCiAgSm1tUXFTRVlVMzIwRTF5cjk3WHpvTFFBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDB6-RZZL-YWTA-RD54-XVG7-MAW2-VG5H",
            "signature":"F33ktO6nZFhqxulNA97z9dCVqlFwiNTsuM4-R8yB
  ixHnMVaTo8ksK8WopdP26lLUTlV9T-vnJyuACBRGicWNCEL1OGQnP5_fkhAQixcfz
  pn2uKH_TtLKU4Hvr_K_lJRcepT78bGriI9iuQWG9dV9sTUA"}
          ],
        "PayloadDigest":"zgxk6UXgAnL9DZgEFcS4DjkYswxN1zjRa_HkWhg4
  -vJqXAI3dNFAMghFahuiz2OD9ks08J2g9GE5_CSenV7iYQ"}
      ]}}
~~~~


The response payload:


~~~~
{
  "BindResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


