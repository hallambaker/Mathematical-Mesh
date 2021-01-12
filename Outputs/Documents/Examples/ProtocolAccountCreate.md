
The request payload:


~~~~
{
  "HelloRequest":{}}
~~~~


The response payload:


~~~~
{
  "MeshHelloResponse":{
    "Status":201,
    "Version":{
      "Major":3,
      "Minor":0,
      "Encodings":[{
          "ID":["application/json"
            ]}
        ]},
    "EnvelopedProfileService":[{
        "EnvelopeId":"MDQO-BPWJ-7HTA-QLPW-4UN2-M5EZ-Q5WE",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRFFPLUJQV0otN0
  hUQS1RTFBXLTRVTjItTTVFWi1RNVdFIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMS0wMS0xMlQxODo0MjowNFoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1EUU8tQlBXSi03SFRBLVFMUFctNFVOMi1NNUV
  aLVE1V0UiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJ3V2QycE9oOUZPNlVYMk5ORlBxVDMzclE1bEZkLUpFZFdrOV
  l5MFhrOWp4TXN5NktvSGdxCiAgLWNjQThCdl9vb1NwbENyLVBKTzhtZmNBIn19fSw
  KICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ0ZTLURV
  SDctREo0VS1ZQVVHLUE3MkMtV1VQNi1FWDVHIiwKICAgICAgIlB1YmxpY1BhcmFtZ
  XRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3
  J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJKdlBzMGY2RnNqMi1qa1B
  3OVc1V1g5d2s0NGtPNkNYVTJlaDZ0X1BVMjdVRkVEZkhGdmZPCiAgM1pOWkI5QkdQ
  d2pWalJJMmt3XzFGd01BIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDQO-BPWJ-7HTA-QLPW-4UN2-M5EZ-Q5WE",
            "signature":"jkPC0PaTLfw3b8fI1ftlfD4ZJlzMnLrl5nnBz9Ad
  3bC9_IganoCJ59W3f51sOQxvUHRc-jRyxV2AEhkBBC3uG9yQ1yxqIC9uR3aNeca5v
  CDlW19sU5QmsE0V1o-LM_hEMROGrPXCTSHbv6Sybsu4pCYA"}
          ],
        "PayloadDigest":"NAQ11d-RsS4_SR8uYDk4_4Xl3ZCjMtVnKh1j6YOU
  l5_-BPRW2Czaj0Z9jzeRYjrGOQxmpifJtpk746QzsLEM1g"}
      ],
    "EnvelopedProfileHost":[{
        "EnvelopeId":"MBCD-YAOD-UX7G-2GJI-VCUS-DXSG-SYIS",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQkNELVlBT0QtVV
  g3Ry0yR0pJLVZDVVMtRFhTRy1TWUlTIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMS0wMS0xMlQxODo0MjowNFoifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1CQ0QtWUFPRC1VWDdHLTJHSkktVkNVUy1EWFNHLVN
  ZSVMiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJ4dFE5dUw2akhUWW16RGxhQmE5VnJOaXBMNFhWYjFQNy1nbUdWUj
  U0QXBlWDNWQTRieXpmCiAgbGwyanplaWU2dWlXWEFFcWpEOFVleGlBIn19fSwKICA
  gICJLZXlBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNRFhOLUdKSVot
  MkJYUi1RTElCLUlPVEUtWFIyTC1HSVJZIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlc
  nMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ij
  ogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJZb21sVHBmbHQxaTgxZ2wydEh
  zT3NYRUZqNTlBZW9yQkN5XzhDYUpZWnFZSXJ2SGJ3LVZECiAgZ21SeURyNG0weC1U
  dTFoUmZSeS0zbDRBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBCD-YAOD-UX7G-2GJI-VCUS-DXSG-SYIS",
            "signature":"E8Jcts5UQeR4LKk4xELyiMM7vqmO4PEKVux4Gkoj
  tpOtdjARPq3WQWNf6mqgbbSXyBnvgaFjP0qAAkbnFzNAgvunOCl-uevhBQFkjzZ1b
  2f6dAW-LKS41Q8R00xL6jVBEnsAIcyG09K83eh_XdSXtxwA"}
          ],
        "PayloadDigest":"7xl8ipXJTWN2FQlap4v6moErGk_XJYYGqO-xU56h
  qNJAz19bYvfGur6deQ1wSm1KCzcl1tABxvOxHF63DJ_A_A"}
      ]}}
~~~~


