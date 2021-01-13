
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQA-UU6A-52ZG-L2KJ-2NZY-GZOP-KQ6B",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"pmdjNV2iacjFv2I_5rPfwbCHRV2G2xAaVvW1hb84
  J1-oN4WiTf8GkSuEwM0hk__qH7qk19nroBGJYEszOe-CsQ",
        "EnvelopeId":"MDRR-M6ZK-YCM4-CIZB-PT7L-K5NX-2MOS",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MCVM-VUHL-UTSB-SV5M-VRD5-P5XF-QAEV",
            "signature":"kN-cd4dUkTGT6gjm3MVnuRPCHWYtGmqi2IbhaBmb
  agc3D6hmJgNTbGApAuVofNkPqc_jBhSpU-WA5NoDvH-e8dn0lUsMLxLUyFvs8VSns
  PwFvdpMzymp4woMdNQV-7QofoqU7DBAMljBJrLSiG8mdR4A"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQUI1LVlKUEktUF
  RRTS1MRENKLTczWUItWVJNSi1FSlRaIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDEtMTNUMTY6Mzg6NDVaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2021-01-13T16:38:45Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5BQj
  UtWUpQSS1QVFFNLUxEQ0otNzNZQi1ZUk1KLUVKVFoiLAogICAgIlNlbmRlciI6ICJ
  tYWtlckBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUEtVVU2QS01MlpHLUwyS
  0otMk5aWS1HWk9QLUtRNkIiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  JETS1CSDZLLTJKM0YtUzVQVS1HM09BLTZVRE0tUzVDVyIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFCT0EtNFBLTC03QTVDLUVXM1ItN05OUy1FT1M0LVhYNUMi
  fX0",
      {}
      ]}}
~~~~


