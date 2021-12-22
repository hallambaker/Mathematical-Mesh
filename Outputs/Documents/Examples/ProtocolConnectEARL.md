
### Phase 1

The manufacturer preconfigures the device


~~~~
<div="terminal">
<cmd>Maker> meshman device preconfig
<rsp>Device UDF: MBFG-FGPL-RW44-SBP6-VSFX-J445-ANV6
File: EBFD-WARU-YCA7-WY6M-GYIP-IXWG-HQ.medk
</div>
~~~~

This results in the creation of a primary secret which is used to compute a ProfileDevice
and corresponding connection records signed by the manufacturer's administrator key.

The data is combined to create a DevicePreconfiguration record that is provisioned to
the firmware of the device being preconfigured.

~~~~
{
  "DevicePreconfigurationPrivate":{
    "EnvelopedProfileDevice":[{
        "EnvelopeId":"MBFG-FGPL-RW44-SBP6-VSFX-J445-ANV6",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQkZHLUZHUEwtUl
  c0NC1TQlA2LVZTRlgtSjQ0NS1BTlY2IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTEyLTIyVDAxOjEzOjI0WiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUJGRy1GR1BMLVJXNDQtU0JQNi1WU0ZYLUo0NDU
  tQU5WNiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIjBOb1VIN2MtX3laOTZBSHFhSHVtVVlMVjhxMmFmajJ1cVJMX2
  NNQkF1TUhUakJMZGE5YUYKICBNWlh2Njkzczl2WmdiYWtPUmIyclVFZUEifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUFPRy1NVEtZLUxWSUQt
  Nlo3Wi1MVkpFLUpRR1ctN1ZNMiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAicldscGp0MjVveklEYTZsZzRJdlhrc0h
  fTDhNdktoVjVKWkpOdjJpTWZhQjRuSDR3RW94RgogIFlta3BVVlVUeUlmR3owR0ct
  TjZLOThBQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1EU
  EEtUTdZRC1SVEVNLUJQUTQtWkNaNy00UVNFLUJOWDUiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICI5Y3pHUWxTTGNG
  RE1RRmJ6SGxTUmRhTktna2V3eElwamJ1T0FmLWN0Wk1ia3VwRWZIN3JSCiAgNGpHW
  TZvZkw5amVrR3EzdWd6SmtvbmdBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQjNKLVlaSUotUDI1Ti1FRkRELVBZQUktTEJVQS1CVEt
  JIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJhTFgxWm1mZVdvZXg2MDk5dzVpWW9Xd0VDMEhabURLNmlBOGowTXNYN0
  lqWEpFWXdXTGpoCiAgWkVWLXZnNW5qS1FRYVI1M1hzM1JqaDJBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBFG-FGPL-RW44-SBP6-VSFX-J445-ANV6",
            "signature":"9q9-UlQcgOJJruN9_NvpCe9GZ8b3JazOOE1I87uh
  5B6bjH2wHrc3pklqUZJepouoNkZXl0-ggmEAJkwGbGRZcb8wZz84nm0u-QdXeqMVF
  7nTC4zT6gTQ4PwvMrb0DsA5Jgz63vzrirZk3PGMC0-LliIA"}
          ],
        "PayloadDigest":"i-yEMBFiwj095J7zxw-olQJNxSqdbazF5yEiiVnL
  TW0l1W1KVhbiL55aGWu5AQIYDmp4wSywY-kOy30C3evqYg"}
      ],
    "EnvelopedConnectionDevice":[{
        "dig":"S512",
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjEtMTItMjJUMDE6MTM6MjRaIn0"},
      "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIkF1dGhlbnRpY2F0aW
  9uIjogewogICAgICAiVWRmIjogIk1BT0ctTVRLWS1MVklELTZaN1otTFZKRS1KUUd
  XLTdWTTIiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogInJXbHBqdDI1b3pJRGE2bGc0SXZYa3NIX0w4TXZLaFY1SlpKTn
  YyaU1mYUI0bkg0d0VveEYKICBZbWtwVVZVVHlJZkd6MEdHLU42Szk4QUEifX19LAo
  gICAgIlNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNRFBBLVE3WUQtUlRFTS1C
  UFE0LVpDWjctNFFTRS1CTlg1IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7C
  iAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiOWN6R1FsU0xjRkRNUUZiekhsU1JkYU5
  LZ2tld3hJcGpidU9BZi1jdFpNYmt1cEVmSDdyUgogIDRqR1k2b2ZMOWpla0dxM3Vn
  ekprb25nQSJ9fX0sCiAgICAiRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ
  U9HLU1US1ktTFZJRC02WjdaLUxWSkUtSlFHVy03Vk0yIiwKICAgICAgIlB1YmxpY1
  BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICA
  gICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJyV2xwanQyNW96
  SURhNmxnNEl2WGtzSF9MOE12S2hWNUpaSk52MmlNZmFCNG5INHdFb3hGCiAgWW1rc
  FVWVVR5SWZHejBHRy1ONks5OEFBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAGO-W7S6-KBOX-NZIB-ZDUY-YA2Y-B6IZ",
            "signature":"B0bsgVUp1J6ZxpKO_T8gXZZ1mdSF02SWeBa68EQ-
  Eb6ybZ3cPCmEDrMabLaJ3XE1-sjY1Q6nNAuAPJ9ZMqCUeet6XDf7jb_5t0ouN6M2U
  zwqWk1HLbPXQDmf-pCulGj-lXClteuXDdfFT0mrcokeYTEA"}
          ],
        "PayloadDigest":"bYnMmikCtdwHjvAbyu-QZf9cKlk4HQQz_iREuv_E
  alT02d-Si-AS54n3GvR5r9mWklwXSvN-5imHBSmtzN6xYg"}
      ],
    "EnvelopedConnectionService":[{
        "dig":"S512",
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICA
  iQ3JlYXRlZCI6ICIyMDIxLTEyLTIyVDAxOjEzOjI0WiJ9"},
      "ewogICJDb25uZWN0aW9uU2VydmljZSI6IHsKICAgICJBdXRoZW50aWNhdG
  lvbiI6IHsKICAgICAgIlVkZiI6ICJNQU9HLU1US1ktTFZJRC02WjdaLUxWSkUtSlF
  HVy03Vk0yIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1
  YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJyV2xwanQyNW96SURhNmxnNEl2WGtzSF9MOE12S2hWNUpaSk
  52MmlNZmFCNG5INHdFb3hGCiAgWW1rcFVWVVR5SWZHejBHRy1ONks5OEFBIn19fX1
  9",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAGO-W7S6-KBOX-NZIB-ZDUY-YA2Y-B6IZ",
            "signature":"rTUtKGKqukIvJYDPmSbDXnIv8ucUQUa146TR6byf
  ES2tES_0RCQ7tW5YPe1yZdUkKVoeOxv5GuwAsYTcIy03Rk8H9zGT0_dSqhp-G81ek
  F2K59jtknDF3ClF1gU9RjvAKs5qtBxAgj9TUuvyymJbgAIA"}
          ],
        "PayloadDigest":"o2RVBHUD5GyZth8XgFZ-3GolT7LSk-q09cRBn_QB
  t7-2AWfYmQyihxVobRQ44h7gG2sBqpaSV4CeHkw5Aorkhg"}
      ],
    "PrivateKey":{
      "PrivateKeyUDF":{
        "PrivateValue":"ZAAQ-BMCG-PYJM-SICO-I7W6-4DCR-6TAA-UWN3-FZ4
D-A6JK-GUJN-NXI2-QE4G-K26L",
        "KeyType":"MeshProfileDevice"}},
    "ConnectUri":"mcu://maker@example.com/EBFD-WARU-YCA7-WY6M-GYIP-
IXWG-HQ"}}
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
    mcu://maker@example.com/EBFD-WARU-YCA7-WY6M-GYIP-IXWG-HQ /web
</div>
~~~~

### Phase 4

The device polls the publication service until a claim message is returned.


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MBFG-FGPL-RW44-SBP6-VSFX-J445-ANV6
   Account = alice@example.com
   Account UDF = MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
</div>
~~~~

### Phase 5

Having been advised that an account has published a claim to bind to it, the device
posts a connection Complete request to the specified account and completes the
connection process as before.

