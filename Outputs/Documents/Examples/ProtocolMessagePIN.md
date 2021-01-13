
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool:

~~~~
{
  "MessagePin":{
    "MessageId":"AAAU-6HVM-7AA6-TNEG-PFUS-IXZ3-BMYL",
    "Account":"alice@example.com",
    "Expires":"2021-01-14T16:38:30Z",
    "Automatic":true,
    "SaltedPin":"AANT-HAQW-KDUY-GUMW-YFY2-YWB5-23YC",
    "Action":"Device"}}
~~~~

This pin value is used to authenticate the connection request from the device:

~~~~
{
  "RequestConnection":{
    "MessageId":"NBPS-TE2K-5BQZ-3HWA-PJNU-WYOX-DAMW",
    "AuthenticatedData":[{
        "EnvelopeId":"MCNR-5XZX-CCZC-XTMJ-RYP2-PACV-HCBM",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ05SLTVYWlgtQ0
  NaQy1YVE1KLVJZUDItUEFDVi1IQ0JNIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTAxLTEzVDE2OjM4OjMwWiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUNOUi01WFpYLUNDWkMtWFRNSi1SWVAyLVBBQ1Y
  tSENCTSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogInRpdWhzU3Y3dnRaaGZBSGRNUjlUNncyMzg3bG9CZF9lMFhpel
  9xaDNNQUlwZ2QyVW9FdzQKICBqYzFuaXJhY3NERUJjS0xYRGJpOXVxeUEifX19LAo
  gICAgIkJhc2VFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1EWUUtQ09CUy1K
  UDVDLTI3UEYtSkEzVS1DNk5WLUdKSEMiLAogICAgICAiUHVibGljUGFyYW1ldGVyc
  yI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOi
  AiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIm1DQy00eHVLVHFBSGhudF9pZ2p
  ERjBPemg3RFo1dUNVcjE4Z0NtZ0hCS0dqNDVaTEhod0kKICBKaEJCVG1LQmt6b3dr
  NV93dEo3MU4wcUEifX19LAogICAgIkJhc2VBdXRoZW50aWNhdGlvbiI6IHsKICAgI
  CAgIlVkZiI6ICJNQ05LLTMzSE4tREVJUC1aTVQ0LTJBWDctQ1dUUi01TVk0IiwKIC
  AgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREg
  iOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6
  ICJBUHVuM01nN0xoMEpia3hkNC1teWNKY3NfZWpMQ2F0YXkyR3NpSFJGS09uRnMxd
  1dXNmZzCiAgUm9Ib3ctcks4SjVkdmlDZjFnYlFUQUlBIn19fSwKICAgICJCYXNlU2
  lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1ENkQtMlJRUi1SSU1WLUw3RzMtNDZ
  QSy03Q1o0LTdCVE0iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAg
  ICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogI
  CAgICAgICAgIlB1YmxpYyI6ICJCSHRuN3d3Wk1xZGFlVFc2M0M0blJWdDhKSHV5d2
  Z5aFdzd0sxYUp1WTJMWEEzbnpxdFBYCiAgMFkwWEpzbzNhTXFqajVJRHdQVG1CZzJ
  BIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCNR-5XZX-CCZC-XTMJ-RYP2-PACV-HCBM",
            "signature":"NznNSRNVFWr5gUmYxqWMmRBZFBGM-AhdfrXgtEoP
  NoPNm8-5-rSl3b1RzCSycA6iXIoeOFkXibCAKGo3O1nVzV1Wy5qFu34pVXUH4oxuH
  3ac957_UgTtGjypbRa10xqPEnlFWbfrMVCiluHa4Jyd1REA"}
          ],
        "PayloadDigest":"jUV5RGz2PDyvbgrOndJlcBEpR1YV53I5bpEJKKny
  z-xC1BImrlcI3x7m0UCEFx_anC-tjsrl3CqbxKjCN8gPcQ"}
      ],
    "ClientNonce":"quIpPcxl_KgkWw-XMAQeAQ",
    "PinId":"AAAU-6HVM-7AA6-TNEG-PFUS-IXZ3-BMYL",
    "PinWitness":"5zFBoTGleXwSgJc68gRNB5zKuoJtWrlaP9fZYTYUpm26AGQ
  DYgLAScoVVq6OoNs-9YNQlCUduoa9yDtbVj-dKg",
    "AccountAddress":"alice@example.com"}}
~~~~

The administration device can now use the PIN Identifier to retreive the 
MessagePIN from the Local spool and use it to verify the request.

