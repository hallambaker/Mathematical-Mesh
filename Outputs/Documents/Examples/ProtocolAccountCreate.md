
Alice requests creation of the account alice@example.com. The request payload is:


~~~~
{
  "BindRequest":{
    "AccountAddress":"alice@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQVJQLUhINkItRD
  JKVy1XTFE2LVJXUFEtMlNMUy1BSTJWIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMi0wNS0wM1QxNjo0Njo1NloifQ"},
      "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1BUlAtSEg2Qi1EMkpXLVdMUTYtUldQUS0yU0xTLUF
  JMlYiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJTakJJalhIUEZmUFc1cFZxby1LcXVUNHFDUkpPTDgyeU5iRGY5eE
  ZhYmkwdnVuUDNYR2ZmCiAgVjgtczhXSlVlX0gzV0NYOWJMSVc1enVBIn19fSwKICA
  gICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2Vy
  dmljZVVkZiI6ICJNRDNQLUFMVEwtVDZJNC1VNkVSLU80WkQtNUFQNS1KNlNPIiwKI
  CAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1BTkQtQktRMy
  1YWEdZLUFZVFMtTDdWWC1PT0hXLUhUN1AiLAogICAgICAiUHVibGljUGFyYW1ldGV
  ycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYi
  OiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIllCZENzS19TeUI1cGdBa0pve
  GxLam1zWFM5Ylp0eU1TMVJWSlZFVExYUjFGN1dwMzBMODUKICBVODREWDdMZnNHUE
  tTM1lWOHRIX0ZkcUEifX19LAogICAgIkFkbWluaXN0cmF0b3JTaWduYXR1cmUiOiB
  7CiAgICAgICJVZGYiOiAiTUFKNS1IUUFGLVhYR0stVzZCVy1FR0gzLUVMTkgtRVE3
  SSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZ
  XlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUH
  VibGljIjogIldtRGxvSjdZQUw3RmVEWUlwalhXNWNGNXBKMnh3WVhEMnM3X1lCc0p
  yeXMxNUtlZFA0QzUKICB5NTh1TjBuM3VmYzB1T3l4NnZ0UnFvY0EifX19LAogICAg
  IkNvbW1vbkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUFTTC01QjcyLTNLM
  0ItUEtRUi1NR0hQLUw1UVAtTVZPQSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIj
  ogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJ
  YNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAieXg3XzcyYzd0T0NSR1JtS1FRYTlq
  YTJ2OUhaRW5LdEZIb3dGekZlaEhKckhLelJyd3lhVgogIGYzV3Z1ZFpFNHh5Njgwd
  FJJb0Y3dTRhQSJ9fX0sCiAgICAiQ29tbW9uQXV0aGVudGljYXRpb24iOiB7CiAgIC
  AgICJVZGYiOiAiTUE3Ni1ESzRDLURaRkctQ0FWUC1ZQ1RVLVg2TzUtWlU1TSIsCiA
  gICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RI
  IjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAiNTRTVWE4aWV1M0hFTlFwc2l1Z29KdGZBTHFCVUN4X0pjUE9ZSmFnWUdac0NBVk
  U5anU3NQogIDR6OFlXMkd6eWEtc1YtaGRhVWxTWHJNQSJ9fX0sCiAgICAiQ29tbW9
  uU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1EV1otMzZSRi02MjJWLVhUNlgt
  TzZLQi0zUzVKLTRKRTMiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgI
  CAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLA
  ogICAgICAgICAgIlB1YmxpYyI6ICJ4cnVBbnNoeWJSenhEaHctTWsydDBiUTQzYmt
  FajEzY0pGNnR3S2IzeC1qV3h1T2ZNb1JMCiAgLXhxcWh4NXA2WkdTLXc4SHROSXlK
  MTRBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V",
            "signature":"UZ3H_08-Gwwmbwdtw1SEc2L53FI6hOA_PrEdvYpj
  0veDQ6OjpTErbdMqD83kS2vQ3_9MEqkqQ5oAYOGkSlRGr-zEKIKaenLIDYHdV4C4R
  1IfDgQz4Ug42KXv2bO3i77IF6k-DRu9oOY1JPAkz3TRrRgA"}
          ],
        "PayloadDigest":"CM5-3VBGfeD3-hhKiiq8acCykvbJBFoGMPkdbkLi
  w4vuc-W4RlPOK_yLXDgCFLaVFkdSrKVXr7lpnWSYqgDDjw"}
      ],
    "EnvelopedCallsignBinding":[[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDYWxsc2ln
  bkJpbmRpbmciLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgI
  kNyZWF0ZWQiOiAiMjAyMi0wNS0wM1QxNjo0Njo1N1oifQ"},
        "ewogICJDYWxsc2lnbkJpbmRpbmciOiB7CiAgICAiQ2Fub25pY2FsIjog
  ImFsaWNlQGV4YW1wbGUuY29tIiwKICAgICJEaXNwbGF5IjogImFsaWNlQGV4YW1wb
  GUuY29tIiwKICAgICJQcm9maWxlVWRmIjogIk1BUlAtSEg2Qi1EMkpXLVdMUTYtUl
  dQUS0yU0xTLUFJMlYiLAogICAgIlNlcnZpY2VzIjogW3sKICAgICAgICAiUHJlZml
  4IjogIm1tbSJ9XX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAJ5-HQAF-XXGK-W6BW-EGH3-ELNH-EQ7I",
              "signature":"Xaq3AhRQwacWpbVP9L0B6KZnE_ZvKWymDc6fCb
  U0mhmtgd00VETBAtCSaIwg99SmvNbpiXtpq2UAPFa2Z-mL4iXUxqKtcgX0uBLw838
  O1BTAQ54EVZM25YiDYCVi_G0V-zjb3GfLHd93E-8Cs638-BgA"}
            ],
          "PayloadDigest":"0Seww5KYf4EbYsVKhgiEcABiKUcWbM1tc07oks
  aoI5QLfbSEk0CvIkuAjxgMLkErJKvJjP4fnULUw4tEjkxLjw"}
        ]
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
  sCiAgIkNyZWF0ZWQiOiAiMjAyMi0wNS0wM1QxNjo0Njo1N1oifQ"},
      "ewogICJBY2NvdW50SG9zdEFzc2lnbm1lbnQiOiB7CiAgICAiQWNjb3VudE
  FkZGVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiQWNjZXNzRW5jcnlwdCI
  6IHsKICAgICAgIlVkZiI6ICJNQzZYLVBaTDItNUFGTi03M0xHLUtWMlktVTNVWS1W
  N0xEIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIl
  B1YmxpYyI6ICJNMC1mdlJXVHJacXo0UHhFU0V3NTBiMk40eThPNlFwUlh1RDAxekt
  NbWlkZktGVHJ0cklRCiAgcmVsd1JUQ2dTTFMxU0tpUWpqbHBvN0dBIn19fX19"
      ]}}
~~~~


It is likely that a future revisions of the specification will specify the host(s) to 
which future account service operations are to be directed. This would allow the
account management operations to be separated from the account maintenance operations
without requiring the traditional tiered architecture in which every interaction with 
a service is first routed to a host that cannot perform the required action so that
it can be directed to the host that can.


