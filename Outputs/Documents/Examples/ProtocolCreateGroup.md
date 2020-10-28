
The request payload:


~~~~
{
  "BindAccount": {
    "AccountAddress": "groupw@example.com",
    "EnvelopedProfileAccount": [{
        "EnvelopeID": "MC4U-BX5B-3MNS-NWQZ-6MHR-5QK3-XNFE",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQzRVLUJYNUItM01OUy1
  OV1FaLTZNSFItNVFLMy1YTkZFIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Udyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjAtMTAtMjhUMTU6NTg6MTdaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZml
  sZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQzRVLUJYNUItM01OUy1OV
  1FaLTZNSFItNVFLMy1YTkZFIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB
  7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiNXJWVnlLMzZJcFlqU1NUVTZ
  wSUhSV1kycVJjYzVURWdIbDltVWlwZGl6S3pkUFRGRXJFeQogIEFEM2lYcVFfc
  EJIbExvMllXd3dHRUVrQSJ9fX0sCiAgICAiQWNjb3VudEFkZHJlc3MiOiAiZ3J
  vdXB3QGV4YW1wbGUuY29tIiwKICAgICJBY2NvdW50RW5jcnlwdGlvbiI6IHsKI
  CAgICAgIlVkZiI6ICJNQlpKLVNQR0QtU0NaRC1ISlgzLVlEWkotVFJYTC1PQlV
  XIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJycDlmWElNN0dLLVZBTWFYXy05OE9OenNVWGNRTExjN29Zb
  1lkaVNJQ0xTVVZvWXVLUnk2CiAgbmJHV2Q0RjNqRGF4bHVsa05NQllzYmFBIn1
  9fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogICAgICAiVWRmI
  jogIk1DNFUtQlg1Qi0zTU5TLU5XUVotNk1IUi01UUszLVhORkUiLAogICAgICA
  iUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6I
  HsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI
  6ICI1clZWeUszNklwWWpTU1RVNnBJSFJXWTJxUmNjNVRFZ0hsOW1VaXBkaXpLe
  mRQVEZFckV5CiAgQUQzaVhxUV9wQkhsTG8yWVd3d0dFRWtBIn19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MC4U-BX5B-3MNS-NWQZ-6MHR-5QK3-XNFE",
            "signature": "Q2b6bBq8DSN_sY9gz7MDLHGVEKfVTchInRE5XkVhWC1pkPE9x
  nu-5s2vQiC38rMqbRTsRTPE4AGArjRjjWufWhwwAJs-tupAkwZgdEjiNzms8gL
  6hrKotcr2L0FE3EUOFSpSI4FqbOr5QaBuucX5aggA"}],
        "PayloadDigest": "yE2TBXm-GuK2hknbZ9F8YeYqDhmoze6a19DiyqPMloh8V
  aUKgMidJyeLZ08RaRg7kP2Jrl2YWQLbb5fQFwSgyQ"}]}}
~~~~

The response payload:


~~~~
{
  "BindResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully"}}
~~~~

