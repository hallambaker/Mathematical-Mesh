
The request payload:


~~~~
{
  "BindRequest":{
    "AccountAddress":"groupw@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MBBW-H57T-72XD-MMIE-VFF4-3RMD-WARE",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQkJXLUg1N1QtNz
  JYRC1NTUlFLVZGRjQtM1JNRC1XQVJFIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUdyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTZUMTE6NDY6NDZaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZmlsZVNpZ25hdHVyZS
  I6IHsKICAgICAgIlVkZiI6ICJNQkJXLUg1N1QtNzJYRC1NTUlFLVZGRjQtM1JNRC1
  XQVJFIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymxp
  Y0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgI
  CJQdWJsaWMiOiAiS2FjQmsyNTIyLTh5V3dpN2VSR0tGTEVQSWNFemx0Y2k4VDg1S2
  ZYWDk3ZWUzLWF1VklXRQogIGlyb1JoRkF3eXBVWGZqVVZQX3NUUmQtQSJ9fX0sCiA
  gICAiQWNjb3VudEFkZHJlc3MiOiAiZ3JvdXB3QGV4YW1wbGUuY29tIiwKICAgICJB
  Y2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQVAyLTREWVQtTlpBV
  y1JTEJJLUU1UEItR1haWi1VNEw2IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOi
  B7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg
  0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJmZU1KLUh4ZWsxS3QxbHJONkNlY051
  WTFiSUgwRnFoalBfYU5qYWdRTWdjRmNyUVV2QUV1CiAgMHMzQnVkOG9DemROcDhhZ
  jFIeGJvby1BIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogIC
  AgICAiVWRmIjogIk1BREEtVDZWRi1aTEZNLTRSTlktWEo1UC1WUUJWLVpLUFoiLAo
  gICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNE
  SCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJGcXp6SWdGTWV6akJlYS1UZE85YkNtUWtHMlg1UjFLUnB6VTlOUmZOMmZkcE
  JKOHROS09ECiAgeF9uc1hkVnhBNkp1VnJ0Mkt3c3ppRVNBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBBW-H57T-72XD-MMIE-VFF4-3RMD-WARE",
            "signature":"EgZcVZ-CJA4OILHsiqOXjADgA_cvDvLsP09t03Ks
  _HyBBSmVjJh4ApGtj1amsNYtQ2C2PrIPim8AczRePAA-omQ8eOVjiYV73jS52I1XK
  EQxSweMPoZbPsKzsmKlpGhhlKPHpTrlaYFQeV0tFUg9yg4A"}
          ],
        "PayloadDigest":"-srY8gTcyt4w92Rpw7DS_i45o54U2eUzO4C7HaE-
  JdOfgbkgomwRCbeyv_TIP51A-PXa-d6bbSzq_gJIUgUadA"}
      ]}}
~~~~


The response payload:


~~~~
{
  "BindResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


