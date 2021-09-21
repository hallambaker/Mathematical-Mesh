

The request payload:


~~~~
{
  "BindRequest":{
    "AccountAddress":"groupw@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MCHX-THLV-3AII-AJT7-LT6W-TQTK-TIMX",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ0hYLVRITFYtM0
  FJSS1BSlQ3LUxUNlctVFFUSy1USU1YIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUdyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMjFUMDA6NTg6NTFaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZmlsZVNpZ25hdHVyZS
  I6IHsKICAgICAgIlVkZiI6ICJNQ0hYLVRITFYtM0FJSS1BSlQ3LUxUNlctVFFUSy1
  USU1YIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymxp
  Y0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgI
  CJQdWJsaWMiOiAiME5LX3NQRlF2VmJGeHZLdFpGQVR3M2w5VzNIOVFPR3g4X1FWcU
  htcl9BeXVMcktnX0JtawogIEpCUGJzWGZCVk1sNVQ4SUZZRVFuNjMwQSJ9fX0sCiA
  gICAiQWNjb3VudEFkZHJlc3MiOiAiZ3JvdXB3QGV4YW1wbGUuY29tIiwKICAgICJB
  Y2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQzMyLTI0UjYtWUc0M
  y1HQUg1LU8zS0otWVRFNC0zT0NTIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOi
  B7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg
  0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJySWRUYnYxU3NSLS1JUFlTeVVxbmow
  SlkxRU1Lb05MQS1MTTdOSEtmZ0tjV2lFblhmak41CiAgME1ISXpFOFk3NHhvYjIzT
  3RnZWpmUjJBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogIC
  AgICAiVWRmIjogIk1BSzYtVjVBSC02MlpOLTU2UTYtQ0FQVS1LVzRBLUc0TFQiLAo
  gICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNE
  SCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJfWkV5Q0U3eU9MWmF6d1NYcm0yUU5uM2l4YXZNUGZuUWlCM1NadFdYQWh0a2
  RpYUpUSXNnCiAgUkt6bWZoMER5a0o5eFpTa0xPMk5uc0VBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCHX-THLV-3AII-AJT7-LT6W-TQTK-TIMX",
            "signature":"7wdpW6mot91xcahdQArhNpQs6V4R_LufROJ_WN0h
  hVvBEhLfO8Rc-HnLiF_fQ32Ye6iYSzecLuoApYv0BgfzAUBAbIB5mTLK2upZbMVfn
  BCm_6ZlpL2Y6HvikRVIsedLDJHNywhO5zmefzuxBZJ1VzEA"}
          ],
        "PayloadDigest":"xm47eLVfg4xHV1pCcwETasVKxzBqlj5kz4OYwD8R
  Re_tFgUdW4PqAwzxCv2ZnjmVnoOYRhhUsA50sP7imHpuTg"}
      ]}}
~~~~


The response payload:


~~~~
{
  "BindResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


