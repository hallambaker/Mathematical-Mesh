
### Phase 1

The manufacturer preconfigures the device


~~~~
<div="terminal">
<cmd>Maker> meshman device preconfig
<rsp>Device UDF: MALQ-6D3Y-ERRF-TIFW-36LR-6GJK-4OZI
File: ED6B-KIW3-TSCC-P4LM-4D3I-IAPD-LE.medk
</div>
~~~~

This results in the creation of a primary secret which is used to compute a ProfileDevice
and corresponding connection records signed by the manufacturer's administrator key.

The data is combined to create a DevicePreconfiguration record that is provisioned to
the firmware of the device being preconfigured.

~~~~
{
  "DevicePreconfigurationPrivate":{
    "EnvelopedConnectionDevice":[{
        "dig":"S512",
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjItMTAtMThUMTI6NDg6MTdaIn0"},
      "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIlNpZ25hdHVyZSI6IH
  sKICAgICAgIlVkZiI6ICJNQkZPLVdNN0stSTdDNy1ZUVNVLUNJVVotSlFFUC1USDR
  RIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQd
  WJsaWMiOiAiWXcwcnhJMWZZTlpnRFA1ZGwtTkRPZ05GVF9TLVVaUGpLYTBvWWJvRE
  xUakpRTXFWVWFJOQogIGYzMFRDS29FX2NEcUd4ck11VUlYUTRvQSJ9fX0sCiAgICA
  iRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQjYzLU1BR04tRVNOVy1OR0tI
  LUZQWFotSVNHTC1PTE9XIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgI
  CAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLA
  ogICAgICAgICAgIlB1YmxpYyI6ICJfNjZDY1VSdThYTlFXT3hXZm5fTVdkRVVXMmx
  paVRXVUtNeHVla3R1ZWoxOEltbnlXb1NJCiAgNkp6UGMwVWpYZWRKZUhnNm5IazhO
  bUtBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ
  jYzLU1BR04tRVNOVy1OR0tILUZQWFotSVNHTC1PTE9XIiwKICAgICAgIlB1YmxpY1
  BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICA
  gICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJfNjZDY1VSdThY
  TlFXT3hXZm5fTVdkRVVXMmxpaVRXVUtNeHVla3R1ZWoxOEltbnlXb1NJCiAgNkp6U
  GMwVWpYZWRKZUhnNm5IazhObUtBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCBJ-UITH-2BQD-PX3A-SR3Z-S4UV-BNWK",
            "signature":"TpL0FOcO64HC2B13c-uQrBqlZtXFzPxvsznY9sb_
  sKosFnrjmlhBQNR55A58DgxRiinXtHTnOqqAZAHcnDVcdgnAQV9qY9znPNzsDVmjN
  3EmXr9R1fNtJU_vhLzJKk6jQc1Wp5GCygtwSQNRsaTjFjQA"}
          ],
        "PayloadDigest":"eajU4hdXOEvO8gdTYhwG33txVBGqZFp2PyD4WtE5
  mCRi2ZZ5w0K5r6HciY6zlqas4-6-dxb5XMAQ3S3gcYJtNg"}
      ],
    "EnvelopedConnectionService":[{
        "dig":"S512",
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICA
  iQ3JlYXRlZCI6ICIyMDIyLTEwLTE4VDEyOjQ4OjE3WiJ9"},
      "ewogICJDb25uZWN0aW9uU2VydmljZSI6IHsKICAgICJBdXRoZW50aWNhdG
  lvbiI6IHsKICAgICAgIlVkZiI6ICJNQjYzLU1BR04tRVNOVy1OR0tILUZQWFotSVN
  HTC1PTE9XIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1
  YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJfNjZDY1VSdThYTlFXT3hXZm5fTVdkRVVXMmxpaVRXVUtNeH
  Vla3R1ZWoxOEltbnlXb1NJCiAgNkp6UGMwVWpYZWRKZUhnNm5IazhObUtBIn19fX1
  9",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCBJ-UITH-2BQD-PX3A-SR3Z-S4UV-BNWK",
            "signature":"nsQ8vwj0eO4OgnmHKe1IDjmB_yW9vJFl7eXWVVcI
  Q5aHBGEUiVtqHbcnED3VNWZDwUYb3KavpuSAcdy8rgGRQVXtrDbT59EQupuwx2sKA
  Nx4ifkwM4z1_FmJdv4QJxGM0Zoh0Qcx5omEGnLxJCyjPAEA"}
          ],
        "PayloadDigest":"v7-o_VKzsUxg2rb3_mg9MTRA8-_9C-0ZJLv2SzZn
  0j2FIGl28RV4TXpDPieXTXBnHAtjrJePIxWM_tQKEHmz9g"}
      ],
    "PrivateKey":{
      "PrivateKeyUDF":{
        "PrivateValue":"ZAAQ-BVPA-BOCZ-6SIX-ZZP3-GP3R-ETLG-BBKB-2YD
M-WPNI-5RXJ-CVG2-4G5Z-GUCM",
        "KeyType":"MeshProfileDevice"}},
    "ConnectUri":"mcu://maker@example.com/ED6B-KIW3-TSCC-P4LM-4D3I-
IAPD-LE",
    "EnvelopedProfileDevice":[{
        "EnvelopeId":"MALQ-6D3Y-ERRF-TIFW-36LR-6GJK-4OZI",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQUxRLTZEM1ktRV
  JSRi1USUZXLTM2TFItNkdKSy00T1pJIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIyLTEwLTE4VDEyOjQ4OjE3WiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIkVuY3J5cHRpb24iOiB7Ci
  AgICAgICJVZGYiOiAiTUI2My1NQUdOLUVTTlctTkdLSC1GUFhaLUlTR0wtT0xPVyI
  sCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlF
  Q0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiXzY2Q2NVUnU4WE5RV094V2ZuX01XZEVVVzJsaWlUV1VLTXh1ZWt0dWVqMT
  hJbW55V29TSQogIDZKelBjMFVqWGVkSmVIZzZuSGs4Tm1LQSJ9fX0sCiAgICAiU2l
  nbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CRk8tV003Sy1JN0M3LVlRU1UtQ0lV
  Wi1KUUVQLVRINFEiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogIC
  AgICAgICAgIlB1YmxpYyI6ICJZdzByeEkxZllOWmdEUDVkbC1ORE9nTkZUX1MtVVp
  QakthMG9ZYm9ETFRqSlFNcVZVYUk5CiAgZjMwVENLb0VfY0RxR3hyTXVVSVhRNG9B
  In19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQUNEL
  TNSSUItRjJMTy1HTFhKLVJJT1MtNzJaVC1FVVA0IiwKICAgICAgIlB1YmxpY1Bhcm
  FtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICA
  iY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJHNXQ0OEVHYnJTbWU5
  YWMxSGhseHFzaUYyemVRN2pmcV8tZkI1a0wxam1ac0NxN1ZmS2VKCiAgNjM3eHVwb
  ENjOFlFMEp2V2R6RFlCR0tBIn19fSwKICAgICJQcm9maWxlU2lnbmF0dXJlIjogew
  ogICAgICAiVWRmIjogIk1BTFEtNkQzWS1FUlJGLVRJRlctMzZMUi02R0pLLTRPWkk
  iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5
  RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICIxVUp6VzBBc1hMbkd4UjhqVGozUzM3VUtIQVRSdmlLWnpvUXJwWEZ6eS
  0tdUctaGwyUUlvCiAgaWRZck1kYm1zZ1MzWlNCSkRpSXRsQTRBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MALQ-6D3Y-ERRF-TIFW-36LR-6GJK-4OZI",
            "signature":"nM9Y8MDljAp7Bms8jCNdgpZqpC-Q7uVBH6EfiNf7
  dH4zAJ8g3ee24DDpWGGkaIUYTjixCqyH_8uAxNLMwWhRGzmipnwEUy20UmrjMBjqI
  hu2TshN1yrC5VtftF-AK5JEg0dnJsZuIuT4bro50ON7OAMA"}
          ],
        "PayloadDigest":"jLTOUGaU-Y26uQ6Xczvc-ycCrD-4vfT3Ud0RLH35
  b2hm1dvcF2Iy-F4A9Jx8u3OPSjkQ1WePfCDfw4hUzQUcHQ"}
      ]}}
~~~~

An EARL is created specifying the means by which an administration device can acquire the
information required to complete a connection to the device:

~~~~
QR = {Connect.ConnectEARL}
~~~~

The preconfigured ProfileDevice is encrypted under the encryption key and published to
the location key derived from the EARL.


### Phase 2 & 3

The administration device scans the QR code and obtains the Device Description using
the Claim operation as shown in section $$$$. The administration device creates the 
ActivationDevice and CatalogedDevice records and populates the service as before.


~~~~
<div="terminal">
<cmd>Alice> meshman account connect ^
    mcu://maker@example.com/ED6B-KIW3-TSCC-P4LM-4D3I-IAPD-LE /web
</div>
~~~~

### Phase 4

The device polls the publication service until a claim message is returned.


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MALQ-6D3Y-ERRF-TIFW-36LR-6GJK-4OZI
   Account = alice@example.com
   Account UDF = MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
</div>
~~~~

### Phase 5

Having been advised that an account has published a claim to bind to it, the device
posts a connection Complete request to the specified account and completes the
connection process as before.

