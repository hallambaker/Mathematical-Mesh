
The request payload:


~~~~
{
  "BindRequest":{
    "AccountAddress":"groupw@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeID":"MDHE-QK2C-RQXN-5CJQ-QROJ-SDQA-XW26",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJRCI6ICJNREhFLVFLMkMtUlFY
  Ti01Q0pRLVFST0otU0RRQS1YVzI2IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Udyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcm
  VhdGVkIjogIjIwMjAtMTEtMDJUMTc6NDE6MzdaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZmlsZVNpZ25hdHVyZSI6
  IHsKICAgICAgIlVkZiI6ICJNREhFLVFLMkMtUlFYTi01Q0pRLVFST0otU0RRQS1YV
  zI2IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0
  tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJ
  QdWJsaWMiOiAiVVpXTDhDb1N3OHZoeW11QWtyNUNlWXBPTFpyNkJSVHpPSUg1dWZN
  cjBnb3h6UEFwcW9PagogIEFhejBrSWx4SjRfdUtQNWJCeElwejlLQSJ9fX0sCiAgI
  CAiQWNjb3VudEFkZHJlc3MiOiAiZ3JvdXB3QGV4YW1wbGUuY29tIiwKICAgICJBY2
  NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ01DLTZHNU8tNklITi1
  IR05GLVdLR0MtRlJGTi1RQlEzIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7
  CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICJwYklwVVNVaGlTTlFzSkVhenZiWlVpWX
  lPRnl5eHUxb1l2cVE3MEZJcm1fRy1SOW5uSUc0CiAgd0NlVjRVTThsaHpRbnVrUVh
  ya2h2R2NBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogICAg
  ICAiVWRmIjogIk1ESEUtUUsyQy1SUVhOLTVDSlEtUVJPSi1TRFFBLVhXMjYiLAogI
  CAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESC
  I6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI
  6ICJVWldMOENvU3c4dmh5bXVBa3I1Q2VZcE9MWnI2QlJUek9JSDV1Zk1yMGdveHpQ
  QXBxb09qCiAgQWF6MGtJbHhKNF91S1A1YkJ4SXB6OUtBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDHE-QK2C-RQXN-5CJQ-QROJ-SDQA-XW26",
            "signature":"qp6CXsgAnElmlT1Gqmaqkij1t3VVjWBt034LtAaCcY
  GWc4xqxBOvSn2mrsXWRLH7ZkvzlOwKZc0A7KAORyZ3tFJc0KA6KqkqVTdr2R5VZ9x
  DKVgnu_bQbfzO6Vk0jrCkBetV7rXTFnvAVfcgXc7G4BMA"}
          ],
        "PayloadDigest":"plq9bhHRRSJDjoBM-A0stSibGswCs_oD3LV1uOYn3l
  pEm2Qa8Ehhrlji-382fepcXWkaTLvWFJg700espozplg"}
      ]}}
~~~~


The response payload:


~~~~
{
  "BindResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


