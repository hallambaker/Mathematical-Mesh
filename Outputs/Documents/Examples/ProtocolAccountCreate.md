
Alice requests creation of the account alice@example.com. The request payload is:


~~~~
{
  "BindRequest":{
    "AccountAddress":"alice@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MB5I-R24M-QXJT-KDBF-XFOA-DGC3-U3AA",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQjVJLVIyNE0tUV
  hKVC1LREJGLVhGT0EtREdDMy1VM0FBIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMS0xMC0yNVQxNTo0ODo0NFoifQ"},
      "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1CNUktUjI0TS1RWEpULUtEQkYtWEZPQS1ER0MzLVU
  zQUEiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICIwUS1aNWVESHR3V1ZZZGtmeVZUOVIzNi1yMGhPMWZVSFdwbUkybW
  RJc2k4MXNkanlzZ3NBCiAgZmRLb0hacEtJWnRLa01YU29Pa0ZycE9BIn19fSwKICA
  gICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2Vy
  dmljZVVkZiI6ICJNRDM2LVE0U0MtUzRZWi1LUFJQLTdXNFAtU05SNy1RTUQyIiwKI
  CAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1CRk8tQVhRSC
  1WRUpJLUo0N0otVzNaRy0zWlBBLTdGSFMiLAogICAgICAiUHVibGljUGFyYW1ldGV
  ycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYi
  OiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIkdDaHlORnVIYjZfQm1vZ3FFQ
  zNfUjBhWGFlbW1EbGFER3lZWWRsMkZTQXc0RW5LakM4QXEKICBHbHB5N3NRYWNSVm
  o0LVFiUUpzel9Qa0EifX19LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogICA
  gICAiVWRmIjogIk1CVUgtRlk0NS1EVk5GLVhNUVYtU1FDNC1MVExJLUs1QVYiLAog
  ICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNES
  CI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIj
  ogIldTZGxEOFNMWFdDRkhoSUhqQ3dRSEI3YjRZbTc0a3BNLVhWWm5GS1dZWVlwSGd
  Cbi1KSUgKICAzYVBhSHpkNjBNSDNuMWV2Vk5Vc1RiQ0EifX19LAogICAgIkFkbWlu
  aXN0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTUNCTy1aSzRGLVFGW
  U0tNjNUSy1UQTJDLUxIUVktN1FXNSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIj
  ogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJ
  FZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIktaUHktTzUtckRYTFRUbzlja2lN
  UjVtbE9qa3VyTUxSQlpXNVprVUpKOTdkOEhSdFRBQmQKICBMbjY2aU9mRUtDUTBza
  V9sOE83NVZVUUEifX19LAogICAgIkFjY291bnRBdXRoZW50aWNhdGlvbiI6IHsKIC
  AgICAgIlVkZiI6ICJNQUhDLVFIM0QtVkxLQy1VVEZCLVVFRlItTTVWVi1UV0FIIiw
  KICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVD
  REgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJFbVNiaHFramdqWUFHUl9pTkh6R2lfU1JCNnZHbEtxZklzQ3lRdnhsVmY3OU
  5zU0VFaG15CiAgUEhxN3pKMUFJbDFlYWlkYVMycjI2M2tBIn19fSwKICAgICJBY2N
  vdW50U2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CVVgtWUk1Vy1OVEFILVVK
  TjItNEZGQy00UEFZLU5JNzMiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKI
  CAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0ND
  giLAogICAgICAgICAgIlB1YmxpYyI6ICJGZnZFcE11Y3dCb3hBT1NfLTB0WlVhenZ
  lNUo3SUJYb1hwakxYVFBEdW9Edk51ZGtzUl8xCiAgUkVmZ2g5SGI0YklwYlpqbF84
  bC1SaUdBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MB5I-R24M-QXJT-KDBF-XFOA-DGC3-U3AA",
            "signature":"Z935mSJZSJRi1kXTEsD-Q9AAkAu3IuD_-QJXHa8W
  Vr2xMXcA-23dcvYx9duavojUCUVkKvl1W8iAsxPtl2n0HoAKUATgpSQmW1X28In4R
  Z9e60BCW7kFIqbADT4jF0fBOVI7bf15uh3coVtpXAtHehAA"}
          ],
        "PayloadDigest":"0_av1I9T_vQ-6biLixf0vQ-_JLiUttOyYnb5fPbq
  u5l3agCn0lgRFl8uGdSgmzVqzUSIxQl36g-SDrhwApbyEw"}
      ]}}
~~~~


The response payload currently reports the success or failure of the bind operation:


~~~~
{
  "BindResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedAccountHostAssignment":[{
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY2NvdW50SG
  9zdEFzc2lnbm1lbnQiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCI
  sCiAgIkNyZWF0ZWQiOiAiMjAyMS0xMC0yNVQxNTo0ODo0NFoifQ"},
      "ewogICJBY2NvdW50SG9zdEFzc2lnbm1lbnQiOiB7CiAgICAiQWNjb3VudE
  FkZGVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiQWNjZXNzRW5jcnlwdCI
  6IHsKICAgICAgIlVkZiI6ICJNQkJSLUtMTDQtWVJGWC1LNjNFLTJEQ1QtNlVHUS1a
  NUpDIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIl
  B1YmxpYyI6ICJXMnFpbDZnWUpyZk5qNXpHak4wZ3pTRUJFZ3U3a1RoZmtHU2FHRnk
  tSUFUNjNuS0EtTXZ5CiAgTkdISW9FMWxqelRobjNwekhuUE55V3VBIn19fX19"
      ]}}
~~~~


It is likely that a future revisions of the specification will specify the host(s) to 
which future account service operations are to be directed. This would allow the
account management operations to be separated from the account maintenance operations
without requiring the traditional tiered architecture in which every interaction with 
a service is first routed to a host that cannot perform the required action so that
it can be directed to the host that can.


