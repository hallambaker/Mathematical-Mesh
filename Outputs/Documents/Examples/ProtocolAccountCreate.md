
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
        "EnvelopeID":"MBCI-T4V7-AIB4-GMH3-4C6R-KD5P-ICO3",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJRCI6ICJNQkNJLVQ0VjctQU
  lCNC1HTUgzLTRDNlItS0Q1UC1JQ08zIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMC0xMS0wOVQxNjowODoxMVoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1CQ0ktVDRWNy1BSUI0LUdNSDMtNEM2Ui1LRDV
  QLUlDTzMiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJObWNfeHNFTzJldEdycDNHUXZTZUNibUdpWTQ1aWcyUDVPMU
  tFV1VjLWJQUGhXSDBfZWN2CiAgNEtiRlNGcDc5MHg0NXZBNmlCd1hOaUNBIn19fSw
  KICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ1RELURU
  Uk4tNUJDTS1JNVI2LUdMS1AtQzRRQS1HVFg0IiwKICAgICAgIlB1YmxpY1BhcmFtZ
  XRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3
  J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICI1MDg3eUZWVzFmX2NRc0t
  sdEFpRkdQbGZhazB4a3VnanRiZG1ZRHJ0d0R2X3dtcTFoNzRlCiAgOHdVTWlycTJS
  UGk1Y0JuLXExWDROR29BIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBCI-T4V7-AIB4-GMH3-4C6R-KD5P-ICO3",
            "signature":"M1AMghiUaF-KB0kTlmD4Ry4pSQBd1lBTi5cYYTQ6
  llulQsEI5F0XLauMDbcG2murYrTFbFxoL3aA9dTasKvRoZZTlKqIJQdUqsNHGIrXB
  osUriRjtli3AqnFVdHs8zTG5Xxo2k2BBLj4o5hp_oLkODUA"}
          ],
        "PayloadDigest":"HUsm_fWuogdI40o_IUYHtI2HyrmL6_i7yr7Yp-HX
  rltn8NSy6mdK-5_CWjx7a_dPnNYE_uxw0lgcIQoMHWaylA"}
      ],
    "EnvelopedProfileHost":[{
        "EnvelopeID":"MCJX-7R7E-LN7P-ZHG4-GDPK-RPTC-IH3U",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJRCI6ICJNQ0pYLTdSN0UtTE
  43UC1aSEc0LUdEUEstUlBUQy1JSDNVIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMC0xMS0wOVQxNjowODoxMVoifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1DSlgtN1I3RS1MTjdQLVpIRzQtR0RQSy1SUFRDLUl
  IM1UiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJFbGF0YXVaNS1JU2gxLWtKUUFtQzhIREJ3ZklhSmplTDZSYWthSj
  FNWEYzU1YyYWdNTEhyCiAgNHg5Nm81Z3YycFN1dE9vRWp4YjVCSjBBIn19fSwKICA
  gICJLZXlBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQzRRLVRTSzIt
  N1JOWi1JUUZZLVoyVDQtRko0QS1IM0tDIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlc
  nMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ij
  ogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJrNDN4NU9Nb3RWZm1hNHJXN1V
  ZRTg2TEx5VW5TLUVDZVhLRkJONDZhc096RExQekJ2Y0lPCiAgNURibW1tQmhBbGRD
  MV9iZHo5MVNvZDRBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCJX-7R7E-LN7P-ZHG4-GDPK-RPTC-IH3U",
            "signature":"hRTBi-xyPFKNmJWJ4gVd_whox-p_1s9bC4KWhasJ
  8QA8q84lhKIu0OY98yUhlIWxEVyQagVXlC8AAH-qOt5rVzXBPiRuKQ7_yuFOU-sNv
  CLHgXLj3btUC1aqdDwx7CwzvyUsePaknOXWB-nf2LijjBcA"}
          ],
        "PayloadDigest":"HPzScCHV0iR09nkqlohXcmBi4er5uruJreyqhLzl
  qV2ru4oooFvfPAe5sY7uMSY78uEfMisqkLtAnjbJqXOl9A"}
      ]}}
~~~~


