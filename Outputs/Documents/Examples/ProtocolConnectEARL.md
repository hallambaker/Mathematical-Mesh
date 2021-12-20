
### Phase 1

The manufacturer preconfigures the device


~~~~
<div="terminal">
<cmd>Maker> meshman device preconfig
<rsp>Device UDF: MB43-ZZ44-PWCH-SJME-GZBJ-HZKC-TZUT
File: EAVO-F5LN-W5EH-LUDH-NWHC-FM27-EY.medk
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
        "EnvelopeId":"MB43-ZZ44-PWCH-SJME-GZBJ-HZKC-TZUT",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQjQzLVpaNDQtUF
  dDSC1TSk1FLUdaQkotSFpLQy1UWlVUIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTEyLTE5VDE5OjIxOjIzWiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUI0My1aWjQ0LVBXQ0gtU0pNRS1HWkJKLUhaS0M
  tVFpVVCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIlZfckI2dmNyMjAwMGtKeUpVeFRTZHg2SVNrXzRlQUQyQWpZVF
  V4UFBqb1NKazFyanJzX2EKICA4czQyUTY5cmJiV2d6dXV3QnVicVRVQ0EifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUNSNS1GSERELUJOV1kt
  TjRWNC1USlAzLTVZWkYtQkVPSSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiYXlpQVhvREVOMldhRFFhVnZYRXpSRkR
  JMmRtUkttSUlnRVVwYUFOeVREbFd4MmFRTDRkSAogIGZLSmpBTkFoQmxMR3RVdnlf
  TkNCeWowQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1BR
  FQtQkpBMy01S1FJLUE3QUUtRk5PVy1RRDRXLUtBMk4iLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJxV1lkbGNkbmhR
  bVhWbWJXdUM0Rm5OWWlHQU1pV25EYmNCWVJLR1NiRE9sTFB1cEhsc0pYCiAgMVZYa
  1lfY1JoeV91VWx5QlZ1Rk94RDZBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQkhILVRWV1ktSVhZTy03S1laLUw0M1UtRUQ0NS1TTE0
  zIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJ2TXdEbXpCRXltQ3pEdlNxQlFDaFFvLVZqZE9scms4bTBfeEJhZ1pPaD
  VTTnJtX0lDWlo4CiAgR3dQWWFGOGdJekNQTDUtMlRFYVdSRS1BIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MB43-ZZ44-PWCH-SJME-GZBJ-HZKC-TZUT",
            "signature":"JyW5uKpEyDq5DeVB4wnX2VOQxDWnZG9yiZmgeq27
  9e28UTiShQ_ljAmIyAeEOwvvHyrR7E8XM_CAhvW5_DhEL9HHRpfs483aflkX8l_hR
  BC9nCBXiARoAuZuirGOl9NkkDb6-TFHbxbHVVxB_IRpER8A"}
          ],
        "PayloadDigest":"KVhkVjStPd91L7Cz0915qFxLIuYh-HUKobQJLdhe
  0s1oEFvMIfetBvSOJOBKod07-bhh6OSbsFse74n0d-vrEQ"}
      ],
    "EnvelopedConnectionDevice":[{
        "dig":"S512",
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjEtMTItMTlUMTk6MjE6MjNaIn0"},
      "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIkF1dGhlbnRpY2F0aW
  9uIjogewogICAgICAiVWRmIjogIk1DUjUtRkhERC1CTldZLU40VjQtVEpQMy01WVp
  GLUJFT0kiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogImF5aUFYb0RFTjJXYURRYVZ2WEV6UkZESTJkbVJLbUlJZ0VVcG
  FBTnlURGxXeDJhUUw0ZEgKICBmS0pqQU5BaEJsTEd0VXZ5X05DQnlqMEEifX19LAo
  gICAgIlNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQURULUJKQTMtNUtRSS1B
  N0FFLUZOT1ctUUQ0Vy1LQTJOIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7C
  iAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAicVdZZGxjZG5oUW1YVm1iV3VDNEZuTll
  pR0FNaVduRGJjQllSS0dTYkRPbExQdXBIbHNKWAogIDFWWGtZX2NSaHlfdVVseUJW
  dUZPeEQ2QSJ9fX0sCiAgICAiRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ
  1I1LUZIREQtQk5XWS1ONFY0LVRKUDMtNVlaRi1CRU9JIiwKICAgICAgIlB1YmxpY1
  BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICA
  gICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJheWlBWG9ERU4y
  V2FEUWFWdlhFelJGREkyZG1SS21JSWdFVXBhQU55VERsV3gyYVFMNGRICiAgZktKa
  kFOQWhCbExHdFV2eV9OQ0J5ajBBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDKA-DHFH-ZWT2-VM4A-PDLP-5KVV-MCA5",
            "signature":"cA6Mv4NHaCRWu8x5j7MUsMd0e-8Y35MFJ_TBKDyS
  YAEvrXaIBdUHjWP4E42c1fi8oQ-ZZRvHrBKApmBhuJD8MFpJZV_zkPaHuYYaLw0-u
  qI1wO6j-B0Jpnm5Im55xOuhzCvbfVCh1ybxwrhqNYXVzjoA"}
          ],
        "PayloadDigest":"sDFLqbVlAKlzhKxCgiJv-0ThpZc3Xs1Tm2K5W2w4
  cZeLskGDjB8X5hr-dA2aCaVrv8ZA3InHgGXjOyoDGbaEZA"}
      ],
    "EnvelopedConnectionService":[{
        "dig":"S512",
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICA
  iQ3JlYXRlZCI6ICIyMDIxLTEyLTE5VDE5OjIxOjIzWiJ9"},
      "ewogICJDb25uZWN0aW9uU2VydmljZSI6IHsKICAgICJBdXRoZW50aWNhdG
  lvbiI6IHsKICAgICAgIlVkZiI6ICJNQ1I1LUZIREQtQk5XWS1ONFY0LVRKUDMtNVl
  aRi1CRU9JIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1
  YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJheWlBWG9ERU4yV2FEUWFWdlhFelJGREkyZG1SS21JSWdFVX
  BhQU55VERsV3gyYVFMNGRICiAgZktKakFOQWhCbExHdFV2eV9OQ0J5ajBBIn19fX1
  9",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDKA-DHFH-ZWT2-VM4A-PDLP-5KVV-MCA5",
            "signature":"VibnNDuA8mCP1xYh-6zhquqs7GZf1fpnvH4dIwGz
  _bb4OPSZ87wCqHVPuTn0B--Kau0f2gx2OqWAbCZ41Dfzs-3Pb3vTzynPHnlIkjG5b
  eO9yossOOHw0A3STIDaYda74dypFvsOaDDnAMJzs5z4bhgA"}
          ],
        "PayloadDigest":"GxhFaKJLyANhZKPh8bQjIyZIeu2Hlhd8uMasKpNi
  ZawQJxvey-OcYm9G7q0qcSgTASLVq_uBuvoQy7H12c2BkQ"}
      ],
    "PrivateKey":{
      "PrivateKeyUDF":{
        "PrivateValue":"ZAAQ-BNDJ-N2UU-M22C-ZFEN-PQVH-IWOW-633A-HCN
4-A2SJ-3ETI-D6QU-T4XJ-B2IF",
        "KeyType":"MeshProfileDevice"}},
    "ConnectUri":"mcu://maker@example.com/EAVO-F5LN-W5EH-LUDH-NWHC-
FM27-EY"}}
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
    mcu://maker@example.com/EAVO-F5LN-W5EH-LUDH-NWHC-FM27-EY /web
</div>
~~~~

### Phase 4

The device polls the publication service until a claim message is returned.


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MB43-ZZ44-PWCH-SJME-GZBJ-HZKC-TZUT
   Account = alice@example.com
   Account UDF = MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H
</div>
~~~~

### Phase 5

Having been advised that an account has published a claim to bind to it, the device
posts a connection Complete request to the specified account and completes the
connection process as before.

