
The request payload:


~~~~
{
  "BindAccount": {
    "AccountAddress": "groupw@example.com",
    "EnvelopedProfileAccount": [{
        "EnvelopeID": "MA2L-3RJT-HGWJ-KIAD-MX7G-2EUI-PX4R",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQTJMLTNSSlQtSEdXSi1
  LSUFELU1YN0ctMkVVSS1QWDRSIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Udyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjAtMTEtMDJUMTQ6Mjc6MTJaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZml
  sZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQTJMLTNSSlQtSEdXSi1LS
  UFELU1YN0ctMkVVSS1QWDRSIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB
  7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiNHBmNWRvQms4REZ5b24yX29
  lQ3hzSVVVSm9fbThiQXhiTXJELTk1S09YWTVDeGxlbjQ5cwogIExLczMtZTNBN
  EZiQS10OFl5NTdLX1prQSJ9fX0sCiAgICAiQWNjb3VudEFkZHJlc3MiOiAiZ3J
  vdXB3QGV4YW1wbGUuY29tIiwKICAgICJBY2NvdW50RW5jcnlwdGlvbiI6IHsKI
  CAgICAgIlVkZiI6ICJNQ05YLVNaVEctN0pMNy1EV1NNLUhNVVEtN1JZUy1MVzZ
  ZIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJ3ZnZBdGdoYVp3MndzaWhGLUQySlF1dzMtWnZKRm40bzFsc
  0RTNVFCd2hNQ0ZKeFItTTFSCiAgMFRmWmtTdzJYalpXWndzdFoxaTBmaXdBIn1
  9fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogICAgICAiVWRmI
  jogIk1BMkwtM1JKVC1IR1dKLUtJQUQtTVg3Ry0yRVVJLVBYNFIiLAogICAgICA
  iUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6I
  HsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI
  6ICI0cGY1ZG9CazhERnlvbjJfb2VDeHNJVVVKb19tOGJBeGJNckQtOTVLT1hZN
  UN4bGVuNDlzCiAgTEtzMy1lM0E0RmJBLXQ4WXk1N0tfWmtBIn19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MA2L-3RJT-HGWJ-KIAD-MX7G-2EUI-PX4R",
            "signature": "c_3schtbmvjll2ZEQkk_Clr-4YiDESMPUnJgSg1H5nBr587_e
  ErbiKr7x1SyPg5E6nEWrMUuJVuA9XsIffRqube5-J9DPI8wy4MNE84wvR41irt
  wX2CoY-iKfaDJ2A0ytCc7CEfheSbS5lYRwIkO3T0A"}],
        "PayloadDigest": "cHS0ON5VpM0vCe0AsI_wWx4w1QIWoqkrTCZABRys1q7po
  1fAEk3TMwt3Y9ZUjo_Ga4YZ4m19w0F7wgy4VL2eYw"}]}}
~~~~

The response payload:


~~~~
{
  "BindResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully"}}
~~~~

