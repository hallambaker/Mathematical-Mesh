
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
        "EnvelopeID":"MDRT-45J4-LNQO-CJVN-ZYSF-YFNO-VXHG",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRFJULTQ1SjQtTE
  5RTy1DSlZOLVpZU0YtWUZOTy1WWEhHIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMS0wMS0wOFQwMToxMDoyM1oifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1EUlQtNDVKNC1MTlFPLUNKVk4tWllTRi1ZRk5
  PLVZYSEciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJBZEJLQlhEQlZic1B0UDE3Y1hSYmRBU2VpTnYtamhRY2hEeG
  kzdmFHMjMzMUgtaW9oT0lzCiAgUjZTVWt4eWVOR3pVbXE5N2I5bkRPVmNBIn19fSw
  KICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ09CLTVO
  M0UtSlNMWS02SUY1LVdMTlotT0JGRC1XWEdGIiwKICAgICAgIlB1YmxpY1BhcmFtZ
  XRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3
  J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJmS0lJNVpVUDE1TTlyUDh
  fc3B2a0k4WnZHT25LQzc4bG9LdHh1WjBkVmFUSmJVbHFuVTVUCiAgVC01dGRfcFFS
  RVN0WWZRNkRHMDAwd0lBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDRT-45J4-LNQO-CJVN-ZYSF-YFNO-VXHG",
            "signature":"sjgC3UxlM5ccgPowdvNUH-hK2etCXkOdwqPPq_p-
  pXLNJfoILTzAjwhbZ3O40fovo1h3MllzQRgAhgjm_poVnyhPEgLp9OYE766Qr5v1j
  PYbX1do0O6MOMrXHl4-WyGNg1DDEYrqEPdMt1-Xd1vb5TwA"}
          ],
        "PayloadDigest":"zYs6A3FTLVrrxF05bHWUrfOGWeNZgxMb4Dxb5eSz
  BkNyTN4bvQb1lG6kR2lSIm1Cb85tIgK654SR3sxN7tXcxA"}
      ],
    "EnvelopedProfileHost":[{
        "EnvelopeID":"MCN2-UT2Z-LICW-2YNY-WCVY-HF2P-H46F",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ04yLVVUMlotTE
  lDVy0yWU5ZLVdDVlktSEYyUC1INDZGIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMS0wMS0wOFQwMToxMDoyM1oifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1DTjItVVQyWi1MSUNXLTJZTlktV0NWWS1IRjJQLUg
  0NkYiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJ6YXp1TkNZbEQ1eDQ1VmRNQUtwdTRDZ2RmcU4tRlZnRzBGRHdVbz
  VwREtkWk1fZV8yTG5ICiAgeFhsN1VsSFJVazljSFBfZFRFWlRZNk9BIn19fSwKICA
  gICJLZXlBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQkhBLUdLNlQt
  VFREVC1SS0YyLUQ2M1UtUUtVTS1EWllDIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlc
  nMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ij
  ogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJjREN5WGl5VmtJQ0U5MmpUWHF
  4el9IT3JCSHU4WFlpdTRfWFJWZkN3M0g2ZFRLUEI5dVFXCiAgT05NVU9pVU5jbjVv
  MzBCWVZrQm8yYU9BIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCN2-UT2Z-LICW-2YNY-WCVY-HF2P-H46F",
            "signature":"z_JKSV9o_V_lSu1-rufrNMRQALZS7uGCProeTrmK
  mb5QtaKgL91A5FW4vCIVr8IyliiFIg5fFGKAxkB64tmgWvwfdTlEdRay2IO7iPPlJ
  iE_E_rNQZZKPnPzDhcXhqL_G8ODe5Z4r97B5uXe6_TTmxcA"}
          ],
        "PayloadDigest":"DSE02iNvm4exZewwNzZzqRj7B3sOxYJ5G7bckwoJ
  LnMKOELXIe6_T3KqKuf9HrN3baVo8hYB_gPCByQ7evAo2A"}
      ]}}
~~~~



