
Alice requests creation of the account alice@example.com. The request payload is:


~~~~
{
  "BindRequest":{
    "AccountAddress":"alice@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ0YyLVdZN0EtWU
  hMUi1XMk4zLTRHWEYtNFBVTy1aTzdOIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMS0xMi0xOFQwMTo1NzowM1oifQ"},
      "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1DRjItV1k3QS1ZSExSLVcyTjMtNEdYRi00UFVPLVp
  PN04iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJhLVhwem9xSkN5M2k2Mjlxakp3Znh1MUdtLWp6a3ZSY2pfUDVPeF
  JOMXM2blpNSzdzb0dkCiAgQnR6UXpQck80eUFaQmRMcHhRdkZ2Sm9BIn19fSwKICA
  gICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2Vy
  dmljZVVkZiI6ICJNQVdXLUQzVDYtVDVDNS1QN1NRLVFEWUYtSkdENy1LSEhVIiwKI
  CAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1ETUgtRzQ0VS
  00WjM1LU1JVlktSVVGSC1TQ1Y2LTM0R1kiLAogICAgICAiUHVibGljUGFyYW1ldGV
  ycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYi
  OiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIlFvNXA0LXlBWUhzZUx0XzBLO
  VIxbkQ2ZzNEa044UjF1UDNVbkhfdDJLaUJkWTM5WlpsVEUKICBhZ0dfc0hyajlPTH
  Q2WmdkM0ZHNTQ5OEEifX19LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogICA
  gICAiVWRmIjogIk1ETk0tUFpSRy1XTjVGLTJHVzQtUVNINi1YRVkyLUJFSEMiLAog
  ICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNES
  CI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIj
  ogImp5Si1Vd3lhUThON2VpVUhVVnNvNDVuZ2RuWlpFbGkwdFdIUmE5QXdtTi1WVEd
  WaGtVb3EKICBoZnU2eEpza05wWVhDODV4cU9DTjREd0EifX19LAogICAgIkFkbWlu
  aXN0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTUFBMi1HTkI0LVJFV
  kQtRldLSS1RNUw3LTdESVMtSUpQUyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIj
  ogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJ
  FZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIktzNUJrR0hhblA0bGR4eFI0QjZk
  SmV2LVFwTFlEd01XYm5ITGd2czEyd2R6UTJCbEtSSV8KICBXdlhiWlpYYWhxWFFpM
  1JHMWhlVG1JZ0EifX19LAogICAgIkFjY291bnRBdXRoZW50aWNhdGlvbiI6IHsKIC
  AgICAgIlVkZiI6ICJNRElQLVVQUVYtNEg3WC1JQVJWLVg0NUQtRzVSUC1NVUtHIiw
  KICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVD
  REgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJKdlVuems2Yko1bFFxYklZV2duREpCd2ZiSURsTTdfY3pzSmZxVE03WHpJRm
  4zeTd3ZU9aCiAgNDI2aGFXN2dkWXhMZDd5aTN1U3I1SFdBIn19fSwKICAgICJBY2N
  vdW50U2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1ETzItU05QVC1INVpZLVU1
  SEstQlBDNS1NVkdGLVdIVDQiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKI
  CAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0ND
  giLAogICAgICAgICAgIlB1YmxpYyI6ICIyb1VReG9rM2FnZnViREdBbzBkNVpncTd
  nZzNGQnFmTGx4Q3VacGxicjV5UzNGdDhBblJWCiAgNTdETWVDek50S1RTVlZnVjRh
  bnEwd1FBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N",
            "signature":"_aICFGYCm-j7vQxb3pSuluFLw7mV-xHAT7MunyoR
  j4nrMPcLiSnXsrgJEPf5nKqStCXCtWnaigiAeOCJQDgdjN8l3V5ES75xMokUCmXBH
  Sd_GeVpwBMfrj8TW13in_AG0RXfEsDoomPncQm_33U28DUA"}
          ],
        "PayloadDigest":"ZAIkZVpaK57pD_WVl5s0sflP4vxt1AIIIO1g3bND
  ejldQ55TKy979S1_KAdEZzpZAEMDdo16brvW8Z2mqSphkQ"}
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
  sCiAgIkNyZWF0ZWQiOiAiMjAyMS0xMi0xOFQwMTo1NzowM1oifQ"},
      "ewogICJBY2NvdW50SG9zdEFzc2lnbm1lbnQiOiB7CiAgICAiQWNjb3VudE
  FkZGVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiQWNjZXNzRW5jcnlwdCI
  6IHsKICAgICAgIlVkZiI6ICJNRDNMLUVZSEQtNVIzMy1MUlNDLUU2M0ktVEhWNy1G
  MkRQIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIl
  B1YmxpYyI6ICItRHZvbk1yb2NXNU1MMHNNVlcwVW5zLXhpUUFxa1NkS0lMamUxenZ
  4V1ZCalE0c3o5eVJkCiAgb1BHTWFncGR2dkw1Wm55dHFqZHBObGdBIn19fX19"
      ]}}
~~~~


It is likely that a future revisions of the specification will specify the host(s) to 
which future account service operations are to be directed. This would allow the
account management operations to be separated from the account maintenance operations
without requiring the traditional tiered architecture in which every interaction with 
a service is first routed to a host that cannot perform the required action so that
it can be directed to the host that can.


