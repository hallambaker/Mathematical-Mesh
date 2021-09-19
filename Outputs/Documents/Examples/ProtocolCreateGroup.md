

The request payload:


~~~~
{
  "BindRequest":{
    "AccountAddress":"groupw@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MBCK-XPJE-36GT-LPBN-BMTH-TTTQ-WTEA",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQkNLLVhQSkUtMz
  ZHVC1MUEJOLUJNVEgtVFRUUS1XVEVBIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUdyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTlUMTc6NTI6NDBaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZmlsZVNpZ25hdHVyZS
  I6IHsKICAgICAgIlVkZiI6ICJNQkNLLVhQSkUtMzZHVC1MUEJOLUJNVEgtVFRUUS1
  XVEVBIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymxp
  Y0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgI
  CJQdWJsaWMiOiAiQWQtRWNkMGtQU2ZOXzU4bWhnZ29nbVB5VVFtWEdQeFI0V3RuQj
  JCdS1OZ2tkNGNzal9NYgogIGxyNmFWYXY1U1VhOWdvZk9VMUhweV9DQSJ9fX0sCiA
  gICAiQWNjb3VudEFkZHJlc3MiOiAiZ3JvdXB3QGV4YW1wbGUuY29tIiwKICAgICJB
  Y2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ1g3LUs2TUktNFAyV
  y1VVlRBLUJNVUQtSDdOUC00UTRMIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOi
  B7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg
  0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJvU21LcVlDOTRkbWNmTjNqcnBiWVA4
  akp6SHFTZm5WS0lxMEllb3FZSlA4VlNqSklEMGlECiAgVzZRVUNMUHExSjZxSmRlb
  WtuSXpiNkFBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogIC
  AgICAiVWRmIjogIk1DQ0otT0ZVTC1RNTRWLUpYTkktS0hYUy1UVDRQLVU1UjQiLAo
  gICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNE
  SCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJuUXhtdGVQYnpETW9FQ1ZZRTFDOGpteVBJZ3F1MG82cjVrYnhSblpXcmVJeF
  lyczF1UmthCiAgZWwxYUJmTkZCQW9KbTZ0WkdMQ3RLRklBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBCK-XPJE-36GT-LPBN-BMTH-TTTQ-WTEA",
            "signature":"4btrjziIoaLodbsQwS2t4F1ikd4ph22Tae5voI7a
  _dHthc8EvsrBd8ElinjdgmsR1iBq_UcBqcAA4O2LFWkwlbquoG_IIGUaS7b5xxA2V
  r89LxsMgPeJhjDSBmXrnq-iD8Dev9VBh9gkFaAKF1cqnCwA"}
          ],
        "PayloadDigest":"RXrX8G5Q_k_M1ON0Foa511Mx1Rns89iS5bmkM6Gx
  yrL44nxVOddLSu6E2igSnXjJo-pUIdOczwJ6t0-wQEWIjw"}
      ]}}
~~~~


The response payload:


~~~~
{
  "BindResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


