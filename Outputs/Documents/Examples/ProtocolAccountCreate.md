
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
        "EnvelopeID":"MAMA-6HCZ-IANI-HRDY-BC42-PE7A-KQFH",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJRCI6ICJNQU1BLTZIQ1otSU
  FOSS1IUkRZLUJDNDItUEU3QS1LUUZIIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMC0xMS0xM1QxNDoyNTozNloifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1BTUEtNkhDWi1JQU5JLUhSRFktQkM0Mi1QRTd
  BLUtRRkgiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJocWkyajQ1eGZyd3JYZmt6TWpIekV6Sm9BVzh1SjBqRnhMVW
  hKelRpeHl4Z0N6T0ZqX2paCiAgc0JGT2hYVWxPb3E2amF4WkRwdmVpZmtBIn19fSw
  KICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNRDJILU9V
  NFEtSVcySC1FUlNHLUhYTEYtRVBXWS1IT1lPIiwKICAgICAgIlB1YmxpY1BhcmFtZ
  XRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3
  J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJfS3QxUVQ4WVJ1RWxkaWM
  2Umk1WFluZnFxOHdYY3RZcUVzT1UzMXN3OXB4OXVjWXNhb2VICiAgODhCRi0wQTU4
  WW9rMDF4ZGpzRS16djZBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAMA-6HCZ-IANI-HRDY-BC42-PE7A-KQFH",
            "signature":"o911Xd-mmZToOjTMxRUll8qwwnGcm6hJSkr3yAE_
  yf8AzWwwwlMEOJ_c8ov5FByP4fxzZcUdygOAaehSNZvIpWFpKWSPysMJqKQrNcmZc
  dT1Ja_uVmlc3Luc5Q3mI83VoSZXfy_UPuZVLXkOH6kYrAAA"}
          ],
        "PayloadDigest":"qr9HePtMD6z06mZ8FIeJ2tsH26V42lCkhkxKo7F3
  WMb7aMiPMUGMikYq2pupJgYFamcaG8uQhjDxKVXHqGWEvw"}
      ],
    "EnvelopedProfileHost":[{
        "EnvelopeID":"MBGN-C64X-5PGM-IVQN-7HV3-5FIN-KIJV",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJRCI6ICJNQkdOLUM2NFgtNV
  BHTS1JVlFOLTdIVjMtNUZJTi1LSUpWIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMC0xMS0xM1QxNDoyNTozNloifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1CR04tQzY0WC01UEdNLUlWUU4tN0hWMy01RklOLUt
  JSlYiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJKQWRyTzQ5LTdtTmpXaTZRQmVWSFBxdkoxTFNMZVRGQXoxMUtrUV
  FwdWJaYTZDa0xEemVzCiAgQ2xLRW5FVDBWUVkyc2sxWWJCWkY3ejRBIn19fSwKICA
  gICJLZXlBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQUZKLTJOS0Mt
  QzVLUi1JU0ZVLU1ST1EtTDNUNi02UERDIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlc
  nMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ij
  ogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJIUzZGekpTc1Fkb2NUWDZLeUJ
  EN1VOa2ZVTURKQm5sNFA3ampab0w4Z0VfMHNKd0dwS0NiCiAgbWxwLUk5N0hRM0wz
  bkZQejJObi0yRTBBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBGN-C64X-5PGM-IVQN-7HV3-5FIN-KIJV",
            "signature":"vfF7cs8bv4i-OzKwic_RcaLGJ2Fn_Y7lEnioqSrE
  cyWxd-TY_5A1BJHz5fmmMxNBvGQn95YIRRqAfnUErnhXLQem9VEBIlaWFyL86iM43
  jShls06z_spfSh_vwQ1gqaP1F8TJ4Y9B3gJDMoUgLTARDkA"}
          ],
        "PayloadDigest":"80JArM8SfjAoWk9Csi1Ww68Szi49DyRDmILL-1MR
  VKwBQA9XPXD2B2DHpiUWwzu01_jAX4o-TtQk8zT3hv1dHQ"}
      ]}}
~~~~


