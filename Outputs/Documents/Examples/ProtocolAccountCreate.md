
Alice requests creation of the account alice@example.com. The request payload is:


~~~~
{
  "BindRequest":{
    "AccountAddress":"alice@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRFJSLTVXNzItM1
  JKTy1WWkIzLVZVVlEtSU9FQy02VU5BIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMi0xMC0xOFQxMjo0MzoyOFoifQ"},
      "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJDb21tb25TaWduYXR1cmUiOi
  B7CiAgICAgICJVZGYiOiAiTUNERy1UUzdULVVQREQtVjY2Ny1PWFNYLVFKNUctRlF
  SWiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNL
  ZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiU
  HVibGljIjogImhBZTdpaUNZbm51MGpyVFNhdTVXdWNPNzRNajBaQTlEY1N6VFd5ck
  5RVXg3dDVuSnNsZkIKICB6VjBqYnpaWWprb29HalFsYnZJclVUR0EifX19LAogICA
  gIkFjY291bnRBZGRyZXNzIjogImFsaWNlQGV4YW1wbGUuY29tIiwKICAgICJTZXJ2
  aWNlVWRmIjogIk1CWUgtQkozSS1FVVdMLTdRQUktTkdJRS1UUEM2LVg0S1UiLAogI
  CAgIkVzY3Jvd0VuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJNVC1LSkpXLU
  ZVN1UtSFJNUi1LNE9JLU9LTVktWENZTyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJ
  zIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6
  ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiak1XbTJvRGpvQWdJZ053SkV3e
  Gk2MkZvRnhrN002R0VMX1FUcGZySmhvd2k2eUFJOTFHVAogIDh4X3pFVG9NYnVheD
  A5VkpDRU9QWnphQSJ9fX0sCiAgICAiQWRtaW5pc3RyYXRvclNpZ25hdHVyZSI6IHs
  KICAgICAgIlVkZiI6ICJNQkZNLVhXMkgtQ0JMVC1BTU5RLVpXVlotVVNHSS1LT0dJ
  IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tle
  UVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdW
  JsaWMiOiAid0loNFhfcnpEMzQ2OFRFWnhLdGZWd0xSdHRlRFBZUEpqeWFUUUMwckl
  5bzFOazZQTnNkUQogIHZNa0FPNzZBejlCR19aTGxVNE50T2tnQSJ9fX0sCiAgICAi
  Q29tbW9uRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQzdWLVhWTUotNzNPT
  C1ZV0dMLTVNSUstUk9YUS1HTDNZIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOi
  B7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg
  0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJjbERrUVQ0bDBxV3E4eFJ4SlNsNmp0
  eV9NdXFsWTM5ZE1jOUhheFEwSWk5Nk00aThFVWVRCiAgeW9VT1pRM2IxYjQwVFc3e
  UtBb3U5SHlBIn19fSwKICAgICJDb21tb25BdXRoZW50aWNhdGlvbiI6IHsKICAgIC
  AgIlVkZiI6ICJNQVgzLUU2V1AtQk1JUy1JWFBJLU1ZUFItTTU2Qy1PSVUzIiwKICA
  gICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgi
  OiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6I
  CJwamdjdmlIRU9yYW4yWmFMa2E5ZmVnbmFqN3V0OU5Sd2NTNUZHWmlGODBvSmUzRn
  pVeHZzCiAgeE1xdXRJNFpxNW5zbVAwbDhEa1FPUUlBIn19fSwKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1EUlItNVc3Mi0zUkpPLVZaQjMt
  VlVWUS1JT0VDLTZVTkEiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgI
  CAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLA
  ogICAgICAgICAgIlB1YmxpYyI6ICI4MXN3cG0wNVQ5b2x5cWJNSE8wZGFEVFdSMmk
  tUEtGaEhtQnRHdjVwTkowNmg2a0tFNk5VCiAgMGJDTHY2U3k3cGJuc3dXbUZzekt0
  U3FBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA",
            "signature":"UNtyhJFuwLPmj8uuSw6Ts61ACoOkEoLF63rSbHT3
  5bDRuS8VFhnkyNX2mQ4SIGHuBPPSURZB84kAGRhq0MRAR32jbTJr4We3LSy_PdeGh
  5hVaGbRMUhX2V40SVzy7SxLcGYW8iXqXq9PVYL3S315fBIA"}
          ],
        "PayloadDigest":"6P0GfqW3b_kYhYrWG0e0oXy0uENOr_YxxcU3CgLa
  NO3tLeTmWkUCGtlZUMvEptTtN-Ysu4KqmXr7OmphX03qow"}
      ],
    "EnvelopedCallsignBinding":[[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDYWxsc2ln
  bkJpbmRpbmciLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgI
  kNyZWF0ZWQiOiAiMjAyMi0xMC0xOFQxMjo0MzoyOFoifQ"},
        "ewogICJDYWxsc2lnbkJpbmRpbmciOiB7CiAgICAiQ2Fub25pY2FsIjog
  ImFsaWNlQGV4YW1wbGUuY29tIiwKICAgICJEaXNwbGF5IjogImFsaWNlQGV4YW1wb
  GUuY29tIiwKICAgICJQcm9maWxlVWRmIjogIk1EUlItNVc3Mi0zUkpPLVZaQjMtVl
  VWUS1JT0VDLTZVTkEiLAogICAgIlNlcnZpY2VzIjogW3sKICAgICAgICAiUHJlZml
  4IjogIm1tbSJ9XX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBFM-XW2H-CBLT-AMNQ-ZWVZ-USGI-KOGI",
              "signature":"1nhNTeeHxyCIaTmJEuEfJXFwolbrrPsWw5Nj2P
  GB142vjiY7_hllV0vCHyX8zC__gW8cVpZO5RaABaGMXFs_AHCON8PgmlStX2IPYr_
  XoPMuFRRd_kXUCKC9bC7YDJO-QZvIzZycDwK-VPONN1sQYy4A"}
            ],
          "PayloadDigest":"BkoFDvWIFUl4wcJ2KsrqOOatQ_5RT0YeSdPclh
  UfDrc7asCIbUlJatERjnTvknrO8ZB-URjyRDPJHaZED96DGQ"}
        ]
      ]}}
~~~~


The response payload currently reports the success or failure of the bind operation:


~~~~
{
  "BindResponse":{
    "EnvelopedAccountHostAssignment":[{
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY2NvdW50SG
  9zdEFzc2lnbm1lbnQiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCI
  sCiAgIkNyZWF0ZWQiOiAiMjAyMi0xMC0xOFQxMjo0MzoyOFoifQ"},
      "ewogICJBY2NvdW50SG9zdEFzc2lnbm1lbnQiOiB7CiAgICAiQWNjb3VudE
  FkZGVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiQWNjZXNzRW5jcnlwdCI
  6IHsKICAgICAgIlVkZiI6ICJNQTZRLTRLTEctWVQ3TC1ZVjJOLURTNFQtSFAyRy1a
  M0g2IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIl
  B1YmxpYyI6ICIwa0dIeVRGYkVtdzRvMFN6QndsbEtDZDlNOHBNV2o5LXBRV1h4Z09
  IaUppTUtVOXlqMVhNCiAgekZLQ2lRVUtqUi1FZC1MX25XUXVaZGNBIn19fX19"
      ],
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


It is likely that a future revisions of the specification will specify the host(s) to 
which future account service operations are to be directed. This would allow the
account management operations to be separated from the account maintenance operations
without requiring the traditional tiered architecture in which every interaction with 
a service is first routed to a host that cannot perform the required action so that
it can be directed to the host that can.


