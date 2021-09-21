

The request payload:


~~~~
{
  "BindRequest":{
    "AccountAddress":"groupw@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MAHW-ARE4-O5T3-S5LV-ZX24-N5MN-27XJ",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQUhXLUFSRTQtTz
  VUMy1TNUxWLVpYMjQtTjVNTi0yN1hKIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUdyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMjFUMDA6NTY6MDJaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZmlsZVNpZ25hdHVyZS
  I6IHsKICAgICAgIlVkZiI6ICJNQUhXLUFSRTQtTzVUMy1TNUxWLVpYMjQtTjVNTi0
  yN1hKIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymxp
  Y0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgI
  CJQdWJsaWMiOiAiZVNZQU5nZXNBYzlacGF1dVNfMXZzb2N3WExkc21QZmcxb3pkOH
  VzMDdxQ3N4bzVZdTRIZAogIFhIVlpGaDVSdXBpa2JUd2xqVzBLUG1XQSJ9fX0sCiA
  gICAiQWNjb3VudEFkZHJlc3MiOiAiZ3JvdXB3QGV4YW1wbGUuY29tIiwKICAgICJB
  Y2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQVBaLTVDMlotMkFJW
  C1NQ09CLTdOQ0stTFNIRS1UREVCIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOi
  B7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg
  0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJXcDY3RW1OXzhGSFNKUHJqMzlYcnlT
  OXpWWEVxeE5MeU1FaVptRkVTcGs0QU9KZVRIZUdNCiAgdGdyYlgxbTdQY1lOWXFKT
  FVjeUkxUTRBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogIC
  AgICAiVWRmIjogIk1BWEgtN002Ny1FWVJJLVJZUVctUUNOTS1LV0RVLUpWV0QiLAo
  gICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNE
  SCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJ0V3RlOEpvaV9zb21xTVNTNV9ZZEJNM3lIZzJWTHFMNkZRWHE1X3pfeWd5am
  xjUHM0WUktCiAgTDg2b0lqbDNtY0pLc2xnaF9PRlMtTEdBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAHW-ARE4-O5T3-S5LV-ZX24-N5MN-27XJ",
            "signature":"35AE1SQKyBYTa21Ab4j8OG_zM3uDWPFPgMrjp-hk
  4qM4Go_SkInMYeaRB8qeuR6P1Nh4HJ7HIKWAi3PpUBJJlGqFuqsts3JEv3qhBEMag
  Lm_thLj5sImYrs8IfCCFnzlV1PT6Kw7OLaaTb425X1b3iYA"}
          ],
        "PayloadDigest":"bMhvQ1oL2Adczf_1CWkwzbUGv2PWo820BfK60FhE
  u86vFHgiAXWgEso1NyR56lmrymzcsoAPbqAmRHVllgObpQ"}
      ]}}
~~~~


The response payload:


~~~~
{
  "BindResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


