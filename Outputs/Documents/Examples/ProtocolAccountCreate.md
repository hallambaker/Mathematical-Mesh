
Alice requests creation of the account alice@example.com. The request payload is:


~~~~
{
  "BindRequest":{
    "AccountAddress":"alice@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQU1RLUVURUEtSk
  JMMy02VUtFLUxSTlQtREdDMy1PSURGIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMi0wNC0yMFQxNjoxNzoxN1oifQ"},
      "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1BTVEtRVRFQS1KQkwzLTZVS0UtTFJOVC1ER0MzLU9
  JREYiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJuaTg1UWphTTh3VTV2Um9LbXdueEQwRjljNFNLMzAzTWswR2FkNV
  dsSjhoZ0JpWVd3OW9OCiAgem1pMzJzdzhYQW1lcjZVTTBTb1RjMjRBIn19fSwKICA
  gICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2Vy
  dmljZVVkZiI6ICJNRFNLLUVVSFMtUVhHRC1MS09GLUFWQzctVjJSSC1MVjZaIiwKI
  CAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1CWlAtV1pBWi
  1CNktRLU1ZWVAtSDdLRC1WVkJBLTdUNlUiLAogICAgICAiUHVibGljUGFyYW1ldGV
  ycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYi
  OiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogInRSODVSQ3FXdjgtWDVCazBOV
  TRFVmxqUUZKNTg1Rk5FM1p3eVd6WFNWdEpIaXgwRlo3aloKICBRN3hnOXV1cnc4S0
  9LbDVNMFVXN0xMT0EifX19LAogICAgIkFkbWluaXN0cmF0b3JTaWduYXR1cmUiOiB
  7CiAgICAgICJVZGYiOiAiTUJEVi1YWE5ILTJSVUItUkJNWi01Tkc3LUwzQ0QtM1RI
  ViIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZ
  XlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUH
  VibGljIjogIkhVd040UlZoR2N6RmxPbTJiRGNldnZWWXlkNmdqZHEzM1FxVjhVcTM
  5ZEdhc1J6UW45X1AKICBWZ0NCUklfOE1qaXZlclRLZGFhRUkzMkEifX19LAogICAg
  IkNvbW1vbkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTURQUi1GSlZXLUdLN
  VotMkxKQS1MTVlWLVhTQ0gtSEUyQyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIj
  ogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJ
  YNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiNTVqVWttcW4zZ3dHMGIySHpEVnUz
  SGxmNXNPNkdnVmxqX3ZhWUZ3QUVrc0RjTXkzd3l2VQogIHd0OW9qa2VVS1Q2MzA0R
  HdmcmgtVXc4QSJ9fX0sCiAgICAiQ29tbW9uQXV0aGVudGljYXRpb24iOiB7CiAgIC
  AgICJVZGYiOiAiTUJWSS1FV0xPLUVJN0otT1ZBSy1HR1pILTZZSFctWkpTVSIsCiA
  gICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RI
  IjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAiZlRVM1RlQjEtN0s4U1pwbzR0UXhaUHBKQWItX2QzTklkSmhsa3hXYWlab2dKUk
  VLOWFkUAogIGY5S25zNW1xcjExVVRUb0lNaHpmZEphQSJ9fX0sCiAgICAiQ29tbW9
  uU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1BTVAtQlg0Ry1BS0syLVlIUEEt
  SVhKVi1aMktWLVVYQlciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgI
  CAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLA
  ogICAgICAgICAgIlB1YmxpYyI6ICJZNi1EMkRiYktsYVZYdkc1WlF3ZUxkNV9rUDF
  FQ0FDUjQwYkRtcGctWTRLczkyRk5lLXV5CiAgc1dVck1fTG1RS09JUGpqcjVMOE5P
  QkVBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF",
            "signature":"FOqGS7sd-l-iXeW0NnWOIUbmJxw0SLBHk_F4VYya
  8AIu23JVKebgbH-MtSAK_-0FVuXyWcRUdT8AsHeGljsGe7Y9tN4q_NT8tIASs9ZsZ
  a4HXUyAB3vOzMuSO6wi5bHehc-zWhkEPZhvdiBMcizkODYA"}
          ],
        "PayloadDigest":"pbnx3FGeWuZWOrANRD5vo3UYnkZRpHGmpLwSWVJn
  sNZ4SFe4qVn-hfNrZ557hnJhp4aD7EN2p6B7IVNMmuK_9w"}
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
  sCiAgIkNyZWF0ZWQiOiAiMjAyMi0wNC0yMFQxNjoxNzoxN1oifQ"},
      "ewogICJBY2NvdW50SG9zdEFzc2lnbm1lbnQiOiB7CiAgICAiQWNjb3VudE
  FkZGVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiQWNjZXNzRW5jcnlwdCI
  6IHsKICAgICAgIlVkZiI6ICJNQUpZLTY1S1AtQzY3RS1MRlhQLVEzWEktWkhaRi1H
  TkhWIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIl
  B1YmxpYyI6ICJIVWVvTEJvWUpqOWVZeDlQd1VMem5NRThvVHQ3R1JyeThBNWhmUTk
  1OUw1UjdQeUlaMEZYCiAgaFNRVk12cVF4aUJtRzlpeGdiNkpMSDRBIn19fX19"
      ]}}
~~~~


It is likely that a future revisions of the specification will specify the host(s) to 
which future account service operations are to be directed. This would allow the
account management operations to be separated from the account maintenance operations
without requiring the traditional tiered architecture in which every interaction with 
a service is first routed to a host that cannot perform the required action so that
it can be directed to the host that can.


