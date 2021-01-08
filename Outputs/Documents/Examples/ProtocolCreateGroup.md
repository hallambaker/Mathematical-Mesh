
The request payload:


~~~~
{
  "BindRequest":{
    "AccountAddress":"groupw@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeID":"MAPU-EOYF-3IHO-3BVP-YUPN-FLP2-W45I",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQVBVLUVPWUYtM0
  lITy0zQlZQLVlVUE4tRkxQMi1XNDVJIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUdyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDEtMDhUMDE6MTA6MzdaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZmlsZVNpZ25hdHVyZS
  I6IHsKICAgICAgIlVkZiI6ICJNQVBVLUVPWUYtM0lITy0zQlZQLVlVUE4tRkxQMi1
  XNDVJIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymxp
  Y0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgI
  CJQdWJsaWMiOiAielBMWjVEOHFLQkNpcXNhRXZ0a0ZQNEdTZnNWdWpkUDBobk5EMG
  ZWcEhNTDl0dW5tRmxSZAogIDJkQVF5M3ZkMDVkbHFDZUtuanFOa25LQSJ9fX0sCiA
  gICAiQWNjb3VudEFkZHJlc3MiOiAiZ3JvdXB3QGV4YW1wbGUuY29tIiwKICAgICJB
  Y2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQkROLVVQM08tSFVJT
  y00NUlZLTdZNVktWE1PTi1JNkVSIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOi
  B7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg
  0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ6NnhmbzFpZGppUmw5VUU0SkFKWmlz
  dnlVOGxnWDlhWE9CanNkM0VkZFJRVkN4UWY5ZnFJCiAgdWxONFpfa1BCTGU0dUZMV
  3F1RmYyTFlBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogIC
  AgICAiVWRmIjogIk1EUkktVFM0Qy1ITUdXLVpQWU8tUDJSTi1aTjRULVJVWUoiLAo
  gICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNE
  SCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJRZ3VzZ254NHRUbkhLUmpXT0x0NTdoMTh5eVhLd1RMRXE2M2w1VDBXUEdGWV
  gwc2pSeGxYCiAgdHlNR19Pdm5iYmhlRFZQSWkxaHBxTGFBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAPU-EOYF-3IHO-3BVP-YUPN-FLP2-W45I",
            "signature":"RQB1UuULlYNrO4_hElZmfp8XeX54riobCVt2Z72l
  8xYelADkdTyqAFkoa4vfzEADJAcwOe5-eSkAKOGcpVhE7phraSnolm9ZC-jF7vd_a
  uS9yWRjJxjJCf4NzuIm6OE-c6swmj02dGtdKjy7np3kEgYA"}
          ],
        "PayloadDigest":"VX7d4kjFhTjKC1USMfhLRq1QXmBRBXDHToHm-1od
  3Rm8HK4LFmmwa9HiLnvtqSBq6ySaXaA0IiQ61IgKHH01kw"}
      ]}}
~~~~


The response payload:


~~~~
{
  "BindResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


