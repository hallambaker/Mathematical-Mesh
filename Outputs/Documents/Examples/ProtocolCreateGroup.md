
The request payload:


~~~~
{
  "BindRequest":{
    "AccountAddress":"groupw@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeID":"MDWY-5UIV-YL3F-56X4-2Z2J-2TAS-ZTPK",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRFdZLTVVSVYtWU
  wzRi01Nlg0LTJaMkotMlRBUy1aVFBLIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUdyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDEtMDRUMTM6Mzk6NDFaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZmlsZVNpZ25hdHVyZS
  I6IHsKICAgICAgIlVkZiI6ICJNRFdZLTVVSVYtWUwzRi01Nlg0LTJaMkotMlRBUy1
  aVFBLIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymxp
  Y0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgI
  CJQdWJsaWMiOiAiZndQejNIWGtKMG9yNGFkVHZNMXFOaXRINHJIUXpJQ0I2MEs2Xz
  RkenZzUVdkdlBmVGtCLQogIFl1b251RUJBNC1nMWdEMk5VTkdFd2pXQSJ9fX0sCiA
  gICAiQWNjb3VudEFkZHJlc3MiOiAiZ3JvdXB3QGV4YW1wbGUuY29tIiwKICAgICJB
  Y2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQUYzLUZRMkItVkNJS
  i1LNjZCLUpDRkstSFRNQS1aQlpIIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOi
  B7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg
  0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJOSXZDcGt2M0U2VV83Q0tBQmhtUlZP
  VVhEZzM5OUtSa3RtemJvcllsbEZhQlZEbDJ4V2ZQCiAgZkRLdjl3YjVYWkVZU2stT
  nB0M1VrS09BIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogIC
  AgICAiVWRmIjogIk1CSFgtR0VZRi1PUzRGLUVVT1QtUFFCRy1ZR1pSLTI2NkkiLAo
  gICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNE
  SCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICI2aXhwR1RpcTRVVE9SMFhFZmNDeTQ2QUdXWFhId0s2M0RSdm9EUXhVdGtrMF
  NKRWJlWTBWCiAgVHlXSXNQOGtEbnNfOGxpWHpMZ2hLaFVBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDWY-5UIV-YL3F-56X4-2Z2J-2TAS-ZTPK",
            "signature":"xpawPGlL3vbFaxGLofClhPLdaTTBRv5h18SnX52L
  J5wsAszDWee81LfKAO4wPs66d7MPGlQf5wkAae0t5C37uq3_X1QfEa5-yff9B7Iup
  pDjW2ITKRTiGGE2eJ5SidQGByMTpMQZTTV583VvPQ3jIikA"}
          ],
        "PayloadDigest":"ybMfNAGNPR39ljihkQRZbsS6SALHb45vyRSQRJu4
  oOio6tEWYMuni-zcSzh5oxKzQhuCkgKVO7EfxM5dUli8kA"}
      ]}}
~~~~


The response payload:


~~~~
{
  "BindResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


