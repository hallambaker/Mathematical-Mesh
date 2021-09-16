>>>> Unfinished ProtocolCreateGroup


The request payload:


~~~~
{
  "BindRequest":{
    "AccountAddress":"groupw@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MCGW-XSJV-OSH5-Q5BZ-EV4Q-YDN6-TRNL",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ0dXLVhTSlYtT1
  NINS1RNUJaLUVWNFEtWURONi1UUk5MIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUdyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTZUMTg6MTI6MzlaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZmlsZVNpZ25hdHVyZS
  I6IHsKICAgICAgIlVkZiI6ICJNQ0dXLVhTSlYtT1NINS1RNUJaLUVWNFEtWURONi1
  UUk5MIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymxp
  Y0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgI
  CJQdWJsaWMiOiAibFE4dkxOblN0dXJjbkx2amFjQkUtQkNmV05HQnpDZnVqN3hKcX
  hiNUxibGsyNndpR2RaSwogIGo0aXdyWkNLb2lELTVjMTRQbHJya0xZQSJ9fX0sCiA
  gICAiQWNjb3VudEFkZHJlc3MiOiAiZ3JvdXB3QGV4YW1wbGUuY29tIiwKICAgICJB
  Y2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNRE1FLVUyQVktVVdYQ
  i1CNTVWLUJCUlotV0RJMy1WS1FIIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOi
  B7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg
  0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ5MFZuRWx1Q0N5MTNZaTZMYlJvMjNI
  YVo4VGRYa2YtOFhQd1RweEZhbWJMS2JaNXNSekZ5CiAgRmEyTTBmOTByZmk4X0Y0Q
  242NUtOWGNBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogIC
  AgICAiVWRmIjogIk1CRTItUzQ1RS1LWjMzLTZSNzQtNllCRC1UVllXLUhKQkwiLAo
  gICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNE
  SCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICI4WFpSaV9vOVRlVW9CYUFzY2Rrd1I4dlN6VGd6UGg1S3BYbUR5UThzOHBNWl
  d1MHF3WVQzCiAgdWhFSU5jbU5SV0NpQ1pNeFRvSVRpallBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCGW-XSJV-OSH5-Q5BZ-EV4Q-YDN6-TRNL",
            "signature":"x656_F_AofPWDIhB_t7FVotN70qCDDqOvuzpUbLF
  glWxBtAYVihmsTHtKm47cgDhUWTvwkfcM14AA-7pQIDbJP-45X5sfBpEI9wdqOJvz
  sBuD4lEq0trD4JtVz-8P7UtwjrJ8kqLrk9fgjcxgjq2wzEA"}
          ],
        "PayloadDigest":"cFBY1xlsgi5BJBMkdznQW9cUrkaU2FSnlV3gyV_c
  qljacpHNryIgIq5LeMKp7h7HCzsggxW_blNwnk4obAhESg"}
      ]}}
~~~~


The response payload:


~~~~
{
  "BindResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


