
Alice requests creation of the account alice@example.com. The request payload is:


~~~~
{
  "BindRequest":{
    "AccountAddress":"alice@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MDMG-5KJT-SFQQ-EE3U-GZAK-CEGV-5GR2",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRE1HLTVLSlQtU0
  ZRUS1FRTNVLUdaQUstQ0VHVi01R1IyIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMS0xMi0wOVQxNjo0NTo1N1oifQ"},
      "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1ETUctNUtKVC1TRlFRLUVFM1UtR1pBSy1DRUdWLTV
  HUjIiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJxZGJ6TUFuN1lwYkxqTEVHaHphN0Y0Z1dnNzFfVmFReEdsZGZLZl
  pBRzlFSU1vcXpfNC1OCiAgWWRWRDVGTGJlVVgwbzhQUDVNclNUbGFBIn19fSwKICA
  gICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2Vy
  dmljZVVkZiI6ICJNQjdCLUpTN1ktSVVZVy1US1BMLVk1TkwtSlJQQi1MVFNWIiwKI
  CAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1EMlAtQlhMWC
  1KNDRFLUdPSE8tN1dQMy1CQTVYLTJEN0QiLAogICAgICAiUHVibGljUGFyYW1ldGV
  ycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYi
  OiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIlZCNzYtcmhpUzRsWWVDWWhfQ
  jhfbDFGY0J1OGRfcDd6WVJKZkM5bWZqQ2dhMm5LUzZZQmQKICB1a2JTbnM2YXgtTz
  I0Zm5RNVdrRUpkYUEifX19LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogICA
  gICAiVWRmIjogIk1ESjYtNkkzNi1PQ05ELVgyMjQtRFNEMy1MTURVLTM3WjQiLAog
  ICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNES
  CI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIj
  ogIjM0TGxkemI5clBRZXFHNVZ6YkhKU2tSOF82Z19IbFk1U2Utc0M5ajdQNUJLMk5
  xME5wUU4KICBQcnF2SlQ3QjMwbVA3QndxQjl3QW92NkEifX19LAogICAgIkFkbWlu
  aXN0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTUJRSy0zVTVJLVNHS
  0YtVDNHSC1NVENELUwzMzUtSURRSSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIj
  ogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJ
  FZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIi10TVNLX3VndGkzSV9Qc3ZZR0xR
  UXBNUzhfR0YyTGVjUHZNV1k3UV9TVjh2QkZfZEhxdm4KICBUU1hYTVZQSG9tUW5iR
  zUzRDVRYkVWQ0EifX19LAogICAgIkFjY291bnRBdXRoZW50aWNhdGlvbiI6IHsKIC
  AgICAgIlVkZiI6ICJNQ0VSLTVXNEUtM1IzQS1YWlpULVM2S04tQU9WRi1HSjVOIiw
  KICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVD
  REgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJ6MVEwNlh6OXdCQVJkVWpGWVR1d0lqUVlNUTJYVnpjRkcxWkxGM080TGRDVG
  5ZVnVDYlpHCiAgQW16YkdYSnhGSEE1WGY2anRSSTRQNm9BIn19fSwKICAgICJBY2N
  vdW50U2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CWVQtNktCUi0zR0Y3LUUz
  Q1MtSFRZVi02M1JVLUxVU0ciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKI
  CAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0ND
  giLAogICAgICAgICAgIlB1YmxpYyI6ICJ4cjFEWk5uLW4ybjA0UmM3QndlODJseHk
  wVk1Kb0JDbi1XVlhLVWxuVHRaSVZIRTZmM1FfCiAgYnJyQnhreFFHX1ZWcEVKNV9u
  RTR4eU9BIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDMG-5KJT-SFQQ-EE3U-GZAK-CEGV-5GR2",
            "signature":"Yzes8MOreJ6tV30tn3pmk-v0-7_ovbOJ_QNWBTJr
  MOtkiRZY5muNy3AM8gKWaz9C4ZP9gjcDbXIAhLUuQZxZE62f47N_MrTXjrfl32kgS
  gvLhUcGD1-DGniivMMaWiNPmWvHwCjx9egFJAydGdB_1zkA"}
          ],
        "PayloadDigest":"Vo_KrkSpR7lGIG1LO_Vml6xvyoNIYj3RMUJsP0Ik
  ELelk_wdzin2ko6Ka2Aykg08GhaWR_NVeg86OxJUxdbdGg"}
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
  sCiAgIkNyZWF0ZWQiOiAiMjAyMS0xMi0wOVQxNjo0NTo1N1oifQ"},
      "ewogICJBY2NvdW50SG9zdEFzc2lnbm1lbnQiOiB7CiAgICAiQWNjb3VudE
  FkZGVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiQWNjZXNzRW5jcnlwdCI
  6IHsKICAgICAgIlVkZiI6ICJNQUxRLVFIREgtVEtNRy1MUDVSLUdZU0stR0lQNi1C
  R0hCIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIl
  B1YmxpYyI6ICJFUHg3bHVCMHVvVHVsd0h1QmNRMV81bDB3dXZLLWNUb1JodzkwaGo
  2Uy1HWld1TjNzT1BmCiAgRnJ5MWNqYS1kNkRCZjEzUzNBUWpSMFlBIn19fX19"
      ]}}
~~~~


It is likely that a future revisions of the specification will specify the host(s) to 
which future account service operations are to be directed. This would allow the
account management operations to be separated from the account maintenance operations
without requiring the traditional tiered architecture in which every interaction with 
a service is first routed to a host that cannot perform the required action so that
it can be directed to the host that can.


