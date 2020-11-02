
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
        "EnvelopeID": "MCJL-BAAS-E44C-IX64-6WHA-VN6T-DJWD",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQ0pMLUJBQVMtRTQ0Qy1
  JWDY0LTZXSEEtVk42VC1ESldEIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiA
  gIkNyZWF0ZWQiOiAiMjAyMC0xMS0wMlQxNDoyNzowNVoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9
  maWxlU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DSkwtQkFBUy1FNDRDL
  UlYNjQtNldIQS1WTjZULURKV0QiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI
  6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiO
  iAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJlSEtKZ2NVR3IwNUg4M2l
  0WWJqN184M2RGWXoxNl9NN0lMQ2hhNE9aVURIYU5mc3VpV0haCiAgc0E3MnZYX
  y1RU1pWYl9WeWFPaWJfQi1BIn19fSwKICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI
  6IHsKICAgICAgIlVkZiI6ICJNQ1RaLUdNWlktMzI1Ri1XV0lBLTM3N1AtT0lIU
  S1FQUtFIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgI
  CAgICAgIlB1YmxpYyI6ICJqQ1FJZEk1Vm5BRTl4T2NBcVpRQ3ZWWTZKSmM0SWd
  HeG1nRlBGUnVkM0RVYi1xQTBRZWJJCiAgRVhVX0oxaHFNQm5mUlh1WnVoX256d
  TJBIn19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MCJL-BAAS-E44C-IX64-6WHA-VN6T-DJWD",
            "signature": "nExk6nrE7zZrW5ugQRUTPUvqm-b2yQCT_FqxxxSYiJXEFl7-P
  4hFiDy9513tD464UNJhqGDxfO6AIyO5pI6r6ZLPMW_UmSyraqC74okonq2ZMx_
  fgQLMM7X1dZqsfQGAdlrf-8e5k1_k9menU2NZTTQA"}],
        "PayloadDigest": "0r2Pahv9Uz8fqRUIEibCT9OmS6eLmUF2lya4BmgUY6aJV
  5CoCowg3RemBWkrukqY7FFET7i7mRNVlflFRtpYeQ"}],
    "EnvelopedProfileHost": [{
        "EnvelopeID": "MCIZ-FSY2-CDCS-RMB2-UOFO-BHT6-YFJW",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQ0laLUZTWTItQ0RDUy1
  STUIyLVVPRk8tQkhUNi1ZRkpXIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Uhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0xMS0wMlQxNDoyNzowNVoifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DSVotRlNZMi1DRENTLVJNQ
  jItVU9GTy1CSFQ2LVlGSlciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICI1bEsyNHkxcHBrOUNydnMzUkl
  uSXVxWmNfUVBCbEtSRWhFaENWZ21uMFVfNnd3NWwtZHZyCiAgZkJqV0FtcWlEU
  0F4MGdzZGlqY1hCeFNBIn19fSwKICAgICJLZXlBdXRoZW50aWNhdGlvbiI6IHs
  KICAgICAgIlVkZiI6ICJNRE5PLUZZWDQtMjZBTS00N0dELVFNWEYtQzRQUy1QM
  1FLIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymx
  pY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJpUDJZazBGRWVmLUxDV08wUTVLYktmVWZFbE9qZ2tNUHd
  NdEVpa2p4ZUhid0xRQUQ5WEpvCiAgNTdJd1U2WDlYeUtTNUNsT0lyMzVjcVVBI
  n19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MCIZ-FSY2-CDCS-RMB2-UOFO-BHT6-YFJW",
            "signature": "PcgHj_uv0wrvna-OUzENHYKySQ_ajiKxq-AW1DuMry0KFULiH
  Fl_692yFl7137e5gWzOOr-G-BgASbqd2fToE74Tcx1lGHRhzsnfmPf3qsof62y
  NxC25RVVV7iKlKfHTtU6BbN16M-5ReFLURUDb2T4A"}],
        "PayloadDigest": "B7Ummxixy6xp9r1vNl0LqbHKwTLoTReqYiYeJneCzrFvU
  zYKa0r2ppuEGhaoTB0f33rnc3uIiqXUHRwm4dQHkQ"}]}}
~~~~

