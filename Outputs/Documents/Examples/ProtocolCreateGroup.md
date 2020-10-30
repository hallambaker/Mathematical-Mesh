
The request payload:


~~~~
{
  "BindAccount": {
    "AccountAddress": "groupw@example.com",
    "EnvelopedProfileAccount": [{
        "EnvelopeID": "MBLI-ZO44-2DID-LRT5-6YS4-SHWK-S6N4",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQkxJLVpPNDQtMkRJRC1
  MUlQ1LTZZUzQtU0hXSy1TNk40IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Udyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjAtMTAtMjlUMjI6NTU6NTBaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZml
  sZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQkxJLVpPNDQtMkRJRC1MU
  lQ1LTZZUzQtU0hXSy1TNk40IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB
  7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAieGNqQ3hIRkNQcXhsWHNUSnM
  ycURaLVNzOVA2TFpfemxySFdmQlBtampTdnUtRkdVSzdtZgogIEFBaTBveGtFZ
  Hhuc0I2V3diMGhjeXNjQSJ9fX0sCiAgICAiQWNjb3VudEFkZHJlc3MiOiAiZ3J
  vdXB3QGV4YW1wbGUuY29tIiwKICAgICJBY2NvdW50RW5jcnlwdGlvbiI6IHsKI
  CAgICAgIlVkZiI6ICJNQlVSLUc1S1gtN1RaMy1QWk5KLVdPSEktVFZKQS1FNFR
  BIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJ5VjVQX3dJTklwVkNURTl4Sm1JNkI5MnpySmxlZ2ZvR0Nxb
  zRiNjJseDZMSHFGZGQtVHdKCiAgMVR4NV9seGVkM09FYzlrRHVnUDVzSC1BIn1
  9fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogICAgICAiVWRmI
  jogIk1CTEktWk80NC0yRElELUxSVDUtNllTNC1TSFdLLVM2TjQiLAogICAgICA
  iUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6I
  HsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI
  6ICJ4Y2pDeEhGQ1BxeGxYc1RKczJxRFotU3M5UDZMWl96bHJIV2ZCUG1qalN2d
  S1GR1VLN21mCiAgQUFpMG94a0VkeG5zQjZXd2IwaGN5c2NBIn19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MBLI-ZO44-2DID-LRT5-6YS4-SHWK-S6N4",
            "signature": "AVml6YHMF_hh7_g1q6_In0F3nmGzaxw-8tOjEEjjsil69RPDv
  udFg6V6n3nul9p8MMRvj2sTmGSA-RqUxMlgJWtqnJ7ploPGCwLvaf7nqvAsW-d
  kZMRJbHQTJO6sWtm7P2o9RnSShHwKhnnyNUh-TBYA"}],
        "PayloadDigest": "IfTbtOsM_YrK_k8fgrmy4UMN2Fp5ql2M01e39DOIFEWdB
  u2T7odtQS-63WGhHTHjeu5lGFoBLjQWw1vQ7THwtg"}]}}
~~~~

The response payload:


~~~~
{
  "BindResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully"}}
~~~~

