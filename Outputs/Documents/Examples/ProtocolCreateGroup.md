>>>> Unfinished ProtocolCreateGroup


The request payload:


~~~~
{
  "BindRequest":{
    "AccountAddress":"groupw@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MBXW-V753-AF3M-JZQR-AMZF-ZYHX-SDLU",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlhXLVY3NTMtQU
  YzTS1KWlFSLUFNWkYtWllIWC1TRExVIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUdyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTZUMTM6NTM6MjZaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZmlsZVNpZ25hdHVyZS
  I6IHsKICAgICAgIlVkZiI6ICJNQlhXLVY3NTMtQUYzTS1KWlFSLUFNWkYtWllIWC1
  TRExVIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymxp
  Y0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgI
  CJQdWJsaWMiOiAiUG5Kbk4yajUxT3cyQUxIZGFUR2htMkNHUEdJa01QeGw5MGdXQz
  N2ZVZjd3YzVktCLWZPZgogIHotbWtCMWZEaHlvRldGM2JkTDh3NGpnQSJ9fX0sCiA
  gICAiQWNjb3VudEFkZHJlc3MiOiAiZ3JvdXB3QGV4YW1wbGUuY29tIiwKICAgICJB
  Y2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ1U2LVhKSFAtNk5OM
  y1PRkhDLVdDNUgtRjdRRS1GVzRUIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOi
  B7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg
  0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJlWWtXZU0xekZVQlFxaXZURWpDLVc4
  QXg3eDNYaWJqTFlESG02Q0Z6ZkxSQWlveDBSenJqCiAgRnBJZUlSTnBVbWVDM202V
  3NmS2VHNnlBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogIC
  AgICAiVWRmIjogIk1BVkMtTFVBWi1PTUtGLVBYRUItMkRKUC1IN1NaLTJKRTQiLAo
  gICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNE
  SCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJsVzN3amRUYXdZOFVxR19qbUpCTEE4d2RUQ3R2WVBvTS1pc3A0V29pTUtpTX
  YwU1habFEyCiAgZlNPOURyUkZpei14QVdQN3JOR2stLVFBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBXW-V753-AF3M-JZQR-AMZF-ZYHX-SDLU",
            "signature":"HwLJwEX1MMRBgmrPNflitffrMThEd95ifQD-OruP
  SXDQMDL8RK2B7VObtAeio2DQ1I6I8nLEqkgAMWnM3JurOWbTXwoGMnxvIQQtZKieB
  Wp9uIDHw-FC2NXVPlm9rqUa2RHISgRjTB2T2FzEeEdhpT0A"}
          ],
        "PayloadDigest":"l1NE7oVsliRMTaSURjvxOKDobhWeFSQaiJZMapU5
  WY2uRPwoYZKcc5DiJxhWFi5gQC0QXiBwDxCJ8KuMnbTuvQ"}
      ]}}
~~~~


The response payload:


~~~~
{
  "BindResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


