
The request payload:


~~~~
{
  "BindRequest":{
    "AccountAddress":"groupw@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeID":"MAET-H3F3-ICQY-SCRL-6DYR-CTKD-FIDH",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJRCI6ICJNQUVULUgzRjMtSU
  NRWS1TQ1JMLTZEWVItQ1RLRC1GSURIIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUdyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjAtMTEtMDlUMTY6MDg6MTlaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZmlsZVNpZ25hdHVyZS
  I6IHsKICAgICAgIlVkZiI6ICJNQUVULUgzRjMtSUNRWS1TQ1JMLTZEWVItQ1RLRC1
  GSURIIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymxp
  Y0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgI
  CJQdWJsaWMiOiAiN2Z5eXFISVdoZTJZSHRPdXpIUEtMa1R3OVhzMVlvWHlLOE5HRH
  lGSHVBMnpXcFJTY29MaAogIEN0LVVKbGNtQWEydDlKVnlwTnRDNVZRQSJ9fX0sCiA
  gICAiQWNjb3VudEFkZHJlc3MiOiAiZ3JvdXB3QGV4YW1wbGUuY29tIiwKICAgICJB
  Y2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQUNJLUdZSkktRkFQT
  i1WTVJELUVJVzItT1hDRy01TU1SIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOi
  B7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg
  0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJfbUxRYkI4MkkwanV6UzFfOG4za0ly
  eUw0WkZwSlVPcmZDczlGTnBqZlg3ODczRGE5ckNFCiAgbEYzamFERHBOOFRrTGp0T
  mx3b1FDWG9BIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogIC
  AgICAiVWRmIjogIk1BRVQtSDNGMy1JQ1FZLVNDUkwtNkRZUi1DVEtELUZJREgiLAo
  gICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNE
  SCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICI3Znl5cUhJV2hlMllIdE91ekhQS0xrVHc5WHMxWW9YeUs4TkdEeUZIdUEyel
  dwUlNjb0xoCiAgQ3QtVUpsY21BYTJ0OUpWeXBOdEM1VlFBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAET-H3F3-ICQY-SCRL-6DYR-CTKD-FIDH",
            "signature":"mtXziRnupqk1kL5Yz3fligjuyuc0sREuUeKk5cD5
  m5YmQr-FGqOHZM6-v2xPIYq2iQ6yilYxPkIAbrJpyEUTu-ero9a0OKVf33w7kS7RE
  HOruUmcOO856R7xu0TwXilip5dGSnVUnvkZQUSBGrVV8iQA"}
          ],
        "PayloadDigest":"OsKhu65W7D-YpVGjlzetoVxoMWcHs7Su3MRSaPZ4
  sSXzMlulReWcgst_Ut5WnZrmF-TNfb5zI-kzpXHnLbf0Eg"}
      ]}}
~~~~


The response payload:


~~~~
{
  "BindResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


