
The request payload:


~~~~
{
  "Hello": {}}
~~~~

The response payload:


~~~~
{
  "MeshHelloResponse": {
    "Status": 201,
    "Version": {
      "Major": 3,
      "Minor": 0,
      "Encodings": [{
          "ID": ["application/json"]}]},
    "EnvelopedProfileService": [{
        "EnvelopeID": "MAXC-GP2U-X7GV-76YY-472F-G2SQ-XYTV",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQVhDLUdQMlUtWDdHVi0
  3NllZLTQ3MkYtRzJTUS1YWVRWIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiA
  gIkNyZWF0ZWQiOiAiMjAyMC0xMC0zMVQwMTo0NToxNVoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9
  maWxlU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1BWEMtR1AyVS1YN0dWL
  Tc2WVktNDcyRi1HMlNRLVhZVFYiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI
  6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiO
  iAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJuVTBZaDBIa0ZkaFlsdXl
  ZODBfMU8zYWY2eERXV2pBRTU1WW0zSEI1VmhOdDNxY3VVR1dnCiAgWm9SeDJCb
  m9CWHdZb2lwQVM5T3BWRXVBIn19fSwKICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI
  6IHsKICAgICAgIlVkZiI6ICJNREIzLUNSUkotWEdBUC0yVjdULUVWN1otUk5CN
  i1LSkxaIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgI
  CAgICAgIlB1YmxpYyI6ICJNYVlsVGNmM19lMXA3SmN1ajB2a1pRcHlJUkp1Z2Q
  xLW05VE81c2x6OTdXUkNfUWc5WlZJCiAgRngwSjBwQ0N1QVotbDBCQXAydElqL
  WdBIn19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MAXC-GP2U-X7GV-76YY-472F-G2SQ-XYTV",
            "signature": "olr4mtEHxbj1NPwS1dKQW96a3KIOldVEO6SaQWIc7hJpZ8h2o
  kPTLeVQJBvtapDhjGa4dqZ1HWCAjddNUmC6dnXXSsJLlD96WR15FsFEIL3gu0d
  dDwY9HEk8YnvFtor0ejFle1UQdoXPUdXt6FBHTC4A"}],
        "PayloadDigest": "y8BRih9mUlTrX7ilT4g_j7Mdp4QwnQivUlJlOFj6-0_ee
  BivFhIDIPEXhQnN4pBgOJG9mxllnclLCPHiImqlKA"}],
    "EnvelopedProfileHost": [{
        "EnvelopeID": "MCN3-RO44-C5L3-J6EF-IBTF-3NQE-XI3I",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQ04zLVJPNDQtQzVMMy1
  KNkVGLUlCVEYtM05RRS1YSTNJIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Uhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0xMC0zMVQwMTo0NToxNVoifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DTjMtUk80NC1DNUwzLUo2R
  UYtSUJURi0zTlFFLVhJM0kiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJLQzFNSUdGS0NjTjJUaVZ6UTN
  oQjkyVlV3cm9LTllxb01vQXh0VFFFb1RKYlVfVDRBZHdICiAgcVkzUVZ5eGVZc
  UVmWGR4MUdFYzNIRWdBIn19fSwKICAgICJLZXlBdXRoZW50aWNhdGlvbiI6IHs
  KICAgICAgIlVkZiI6ICJNQzVKLUxOSE0tS1c1Ry1XNVkyLUFSN0QtNjIyMi1BQ
  UdZIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymx
  pY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJ1QkVHR19adkZRSEJNNHJXWjcyZFFlRExoTDRTRGQ3eXV
  UVW02cklWLUFzMWE3SWZjR0x2CiAgTkNnbkRpQzBsV1kzaXVYSDhuRFczTEtBI
  n19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MCN3-RO44-C5L3-J6EF-IBTF-3NQE-XI3I",
            "signature": "UJ1GIB_Lx5RbFHBi9RQZKM6lcoEbKutJQR1MCVNx1q75rbq92
  Dddy_rQGUGT-E5EXnpc10m14UQAdNmq0uZRLnZ5WKpVaHz-py6ZUY98Osj-lrX
  cjB6tTQTGnpLz6nkbaHQXIbtBTMa-8_FVfb2xcQIA"}],
        "PayloadDigest": "1AQ0dzcerCxGJjjImaU2fcIeQkmz2MhXBTnd6us1rjzNY
  3BDRscjqSl504zoJ70FX69P0Xuv5djc1NiI5nK0lA"}]}}
~~~~

