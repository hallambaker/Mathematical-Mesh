>>>> Unfinished ProtocolCreateGroup


The request payload:


~~~~
{
  "BindRequest":{
    "AccountAddress":"groupw@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MDBM-W35C-MP2T-626C-SD4X-4LNN-ZDWX",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNREJNLVczNUMtTV
  AyVC02MjZDLVNENFgtNExOTi1aRFdYIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUdyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTZUMTg6MzI6NTFaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZmlsZVNpZ25hdHVyZS
  I6IHsKICAgICAgIlVkZiI6ICJNREJNLVczNUMtTVAyVC02MjZDLVNENFgtNExOTi1
  aRFdYIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymxp
  Y0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgI
  CJQdWJsaWMiOiAieTZsNFVZQnNTWDRXLUN6Q1I4STlVYmJkSjVrb2hPYXdXQUgyS3
  ZwQU9LY1VhMmwtVmJ2aQogIFhBWUdia3FCR3pHYnpab3pnR1RBdVk0QSJ9fX0sCiA
  gICAiQWNjb3VudEFkZHJlc3MiOiAiZ3JvdXB3QGV4YW1wbGUuY29tIiwKICAgICJB
  Y2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQzI3LUhXRFItR0NCV
  i1VUTdJLUJYMlItUjZKTS1MMjdWIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOi
  B7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg
  0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJITVlaUkthMldZNG5sek5hUm9yclFF
  SUpGaW9scG9uNFZFQ0Z3TVlUWTNzSTZiemFGQnhwCiAgUzd1SjB3dDJpaVgtX2tsR
  WJxZVFRSDhBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogIC
  AgICAiVWRmIjogIk1ENVMtS1lBNi1CR05ZLVFBNlctUzRCNS1ZQVlDLVlNNFAiLAo
  gICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNE
  SCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJtUEFHb1ZEdUtoa1NObGNXdjU5NDF5TGwxOGU5ajBMQXlROG5vbjdTa0JFbX
  k3UGh5ekJ4CiAgRllzSkExNjlVVmdjN1JsN0t3QzRiMTRBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDBM-W35C-MP2T-626C-SD4X-4LNN-ZDWX",
            "signature":"qnCy1x6_sZg7xp4A7j1FEEbkxTJGFHxo3ZHZpmfa
  l0kLNvlhYzVDIJsOq8CQ2qRZWnhrNlKRLCoAXqi5A_hi-J0E1tKX9NnlkMsOApHA4
  dwNOATOvsELkBQc4WQ-1KR6U1gAIK7BAQtYDflUvrh1QCUA"}
          ],
        "PayloadDigest":"HV5-xcXwYqvilt9ZgssZXX4naeo2atSr84eh196h
  EXJ3qDYbVTVL12VujIKahYRo7zje6kNfiBblVpYJ6rtAhw"}
      ]}}
~~~~


The response payload:


~~~~
{
  "BindResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


