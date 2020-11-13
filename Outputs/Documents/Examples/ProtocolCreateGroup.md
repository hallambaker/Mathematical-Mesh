
The request payload:


~~~~
{
  "BindRequest":{
    "AccountAddress":"groupw@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeID":"MBBH-34WP-QB3W-PGS2-BW2L-YK2C-47SK",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJRCI6ICJNQkJILTM0V1AtUU
  IzVy1QR1MyLUJXMkwtWUsyQy00N1NLIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUdyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjAtMTEtMTNUMTQ6MjU6NDVaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZmlsZVNpZ25hdHVyZS
  I6IHsKICAgICAgIlVkZiI6ICJNQkJILTM0V1AtUUIzVy1QR1MyLUJXMkwtWUsyQy0
  0N1NLIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymxp
  Y0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgI
  CJQdWJsaWMiOiAiS2FXVHh2Z1Iwbm9RejBMVjhCdEhWQnlod0dRWk5XNXFqN0NPOW
  stcno2U0hzUzhzd25BUgogIEkwZGJzeG1GY29XTXlKRGFBanhVZmg0QSJ9fX0sCiA
  gICAiQWNjb3VudEFkZHJlc3MiOiAiZ3JvdXB3QGV4YW1wbGUuY29tIiwKICAgICJB
  Y2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ1VZLVBEWlgtUk1aU
  C1VVUpRLVhKNUQtUDVTMy1XVlJBIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOi
  B7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg
  0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJZRVZFaWdfX3I3N3lXWVNYZHdBdGJ0
  VHRILWdxWDVwRTZJNTZ3T1hzeEhjbFEzcUFCbEVYCiAgMzJESWZMU25oeWkzamU3c
  FFUeXNmUXlBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogIC
  AgICAiVWRmIjogIk1CQkgtMzRXUC1RQjNXLVBHUzItQlcyTC1ZSzJDLTQ3U0siLAo
  gICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNE
  SCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJLYVdUeHZnUjBub1F6MExWOEJ0SFZCeWh3R1FaTlc1cWo3Q085ay1yejZTSH
  NTOHN3bkFSCiAgSTBkYnN4bUZjb1dNeUpEYUFqeFVmaDRBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBBH-34WP-QB3W-PGS2-BW2L-YK2C-47SK",
            "signature":"DRobKUABN8jlxB9Cpgd640GYHzZn12TQNvfilfIf
  mWJadcxm0NEXHvtivRkY2edaU3yCpzXVrT-AUjgmu7N-3ike4xEcKlua6Ib1xh7or
  6oJLeY_SVSZXXX2emYFT58fb2cQZW1gBWBPr2v1gMp7XxMA"}
          ],
        "PayloadDigest":"NgA4zf1wxe8nPi0C2JQEKP7jyC9m3Y4UKXK0a-zp
  Cmuf9b964k6SPGIJCJBoF3-1ipVpGbCxOdkAPu55yNPVXg"}
      ]}}
~~~~


The response payload:


~~~~
{
  "BindResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


