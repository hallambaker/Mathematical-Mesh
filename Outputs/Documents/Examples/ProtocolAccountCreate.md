
Alice requests creation of the account alice@example.com. The request payload is:


~~~~
{
  "BindRequest":{
    "AccountAddress":"alice@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQjRBLVhPTFItMl
  NYUi0ySEdBLUc2NUMtT0lFSS1SNTNIIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMS0xMi0xOVQxOToyMDo1N1oifQ"},
      "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1CNEEtWE9MUi0yU1hSLTJIR0EtRzY1Qy1PSUVJLVI
  1M0giLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJFMVl2Nkx0eGt6dUxnMDBHc3VSU3FwekxRaFdoV0ZLSWdFTzV4cW
  ljZnFtUWdjaC0wY2VLCiAgaTAxcVM4eFNUYWowcVh0U1lLMjlFR21BIn19fSwKICA
  gICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2Vy
  dmljZVVkZiI6ICJNQ01QLUxPVTUtNENCRC1WRE9XLTJGQ0YtQ0NDUS1HRVNGIiwKI
  CAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1CUVgtUkJMTy
  1ZUlhELUhLUU0tVkdVSy1VMzdaLTVUNkIiLAogICAgICAiUHVibGljUGFyYW1ldGV
  ycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYi
  OiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIk1BNkFHQTJMUFRoM0k0bVNYW
  jFiWW5WWnkzYmNmMVN0MGMyMURXUFgxNHc3Znc2QUZQMXMKICBHY2hlU0lwQV9mZT
  J0ODE2R2ZPMkxoeUEifX19LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogICA
  gICAiVWRmIjogIk1EUlEtRDRUNi1aWEwyLUJWQlUtVjNURy1SQjVBLUVSTUEiLAog
  ICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNES
  CI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIj
  ogIjRteHF2cy1ick51bW93STBJYXpremFmMHk2cjVPSWtsOG5jRmp6S3J0akpsWEI
  tSEYyd1EKICBNbXVXMjkwZjZUNTNXM3Q4S2lvYUE2cUEifX19LAogICAgIkFkbWlu
  aXN0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTURPSy1aMkxTLTZBT
  zYtWlU1Vi1GRVVHLVFYUEotSVI0SyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIj
  ogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJ
  FZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIm80aGlVbnVwODF4VkpHTVRpS21k
  TlBIejZHLWdSTlBZbFEtQ3psbHE2ZFlVUERiVGU2TEMKICBtLTZLLVJXQU85M21Wd
  UNvcGQtVjNhMkEifX19LAogICAgIkFjY291bnRBdXRoZW50aWNhdGlvbiI6IHsKIC
  AgICAgIlVkZiI6ICJNQ05XLUg3WE0tRFlYVC1YS0JZLUJDVjItSTI0Ri1BR04zIiw
  KICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVD
  REgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJSWHh1Q25LbVBucTc2bVpfTjN1Z2ptR3JNLVF1X2RLVEpIMGp2ZDkyQUNYRV
  ZMd0hwZFhhCiAgRUJId3dHbHVhMWNOa0xPYVktakcxdkFBIn19fSwKICAgICJBY2N
  vdW50U2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1BT08tSDVNQi1IV042LTRD
  U1MtU0pGMy02UkRMLUtEMk0iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKI
  CAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0ND
  giLAogICAgICAgICAgIlB1YmxpYyI6ICJFaGJqM3N0QXlvV3F5MkZZZWtsNnFlOFA
  0T1QtNlp3LXBxQmQ4WjBGV3NNRXhMZTJ6Q0ZOCiAgS1kyNDlxZWNCcldteXdrbW0x
  YUlORjJBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H",
            "signature":"ETG9ctLfHFUVeM1haWrNoBu02rJiSArwfABcckL3
  pyKSOYqDUBu9gdS4LBoHxiUuvaK5Ocp6UWoAW_w7AYTzwRGDMM2mfkBzd7_eaXFaH
  zQsDe3hSMbnmy5SfdoEEz9U5A21sbj1dpbd65gSI4OrWw0A"}
          ],
        "PayloadDigest":"hy8dTWi8kXEFMZEz-Jq2SqIpcng0JxX64u7M6-x9
  4DtJaS8R6bR_nW49OP_N5IUYHk1ee80JHN0GlQFELwfBCQ"}
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
  sCiAgIkNyZWF0ZWQiOiAiMjAyMS0xMi0xOVQxOToyMDo1N1oifQ"},
      "ewogICJBY2NvdW50SG9zdEFzc2lnbm1lbnQiOiB7CiAgICAiQWNjb3VudE
  FkZGVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiQWNjZXNzRW5jcnlwdCI
  6IHsKICAgICAgIlVkZiI6ICJNQzNBLUs0UDctWjRCWS1YNzVaLUk3RE8tUU5aSS1T
  NFROIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIl
  B1YmxpYyI6ICJOUlR3UklZQXdab1VWX2h1a0lfSl92VzQzMWhpMDRLVGdKVHphYjV
  NUDNGTGZFN1dmQ29sCiAgQmF5LXAzRm9WVDV0cloza3YzS2RHM3FBIn19fX19"
      ]}}
~~~~


It is likely that a future revisions of the specification will specify the host(s) to 
which future account service operations are to be directed. This would allow the
account management operations to be separated from the account maintenance operations
without requiring the traditional tiered architecture in which every interaction with 
a service is first routed to a host that cannot perform the required action so that
it can be directed to the host that can.


