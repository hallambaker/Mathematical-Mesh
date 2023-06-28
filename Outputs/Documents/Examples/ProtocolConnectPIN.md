
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=AAKI-IIAD-GQ3H-JUY3-SXZN-PENW-PQ
 (Expires=2023-06-29T17:00:45Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcu://alice@example.com/AAKI-IIAD-GQ3H-JUY3-SXZN-PENW-PQ
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AAKI-IIAD-GQ3H-JUY3-SXZN-PENW-PQ
<rsp>   Device UDF = MBXV-SIBF-4XEW-4EVE-7URW-F6VT-NTX3
   Witness value = GSJR-OHU5-HHXO-KURY-ST4B-HVBA-7PV5
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "AccountAddress":"alice@example.com",
    "AuthenticatedData":[{
        "EnvelopeId":"MBXV-SIBF-4XEW-4EVE-7URW-F6VT-NTX3",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlhWLVNJQkYtNF
  hFVy00RVZFLTdVUlctRjZWVC1OVFgzIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIzLTA2LTI4VDE3OjAwOjQ1WiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIkVuY3J5cHRpb24iOiB7Ci
  AgICAgICJVZGYiOiAiTUJYVS03QUo1LUpQS08tR0pXTi1LREVBLVhHR1ItQ0ZJWSI
  sCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlF
  Q0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiVjFNaHZFWlhzMlk5bzMtd1hWMm1kT3AycVkyMGxWZ21NQzVyRTgxRTNDRW
  hDU1pSX0h0eQogIDZLN1RMLXcxd3EtY1h1Y09uZUY2MURrQSJ9fX0sCiAgICAiU2l
  nbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DNlItU0ZEQS1PWVRKLUdLNkstRklW
  Ti1PTjVHLUkzUEUiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogIC
  AgICAgICAgIlB1YmxpYyI6ICJNNUUtek1GaDRVOTBlaEtVc2JkMmlDWVprUGdFUnF
  lTk8wUm40UlRMZXpsWS1fRWNjVGxFCiAgNUNpbzNycnJrU2xYc2pybmV6Z25HSllB
  In19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ0xLL
  VpUTFQtUkFDNi1OTkpFLTUzSUQtVjQySC1KU0lBIiwKICAgICAgIlB1YmxpY1Bhcm
  FtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICA
  iY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJDb1VqdENFVEdLWGpP
  d2htRkw0UU9zZlVBNEpZeXI0RFpBTXowV0R1bEU2aGJXMVF2N3dBCiAgR0FYVFBwN
  0s0dG9VZ0YwSGVuT3BZWTZBIn19fSwKICAgICJQcm9maWxlU2lnbmF0dXJlIjogew
  ogICAgICAiVWRmIjogIk1CWFYtU0lCRi00WEVXLTRFVkUtN1VSVy1GNlZULU5UWDM
  iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5
  RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJiRVpmVTdLRENRRnFhQjN3Mll0SWItX3M5elNhUTBOXy1FQ1dselcyaW
  0xZkJLcTBvY1hSCiAgSGtHOFJGOWd6Q29pZzd1TExKYUsyVUVBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBXV-SIBF-4XEW-4EVE-7URW-F6VT-NTX3",
            "signature":"VQYBbRl6xm-Tzo-uGkOd53RKQrn1KE6so5IEhmwB
  OQg49uJtfjaJYZTxC1OfQ3z1u2COGayDIRAAvFkA4vO7JFpk6IOQ1tRbwHau-QZr0
  0ey9zzjj8cWnjanozfSXM1b7T08DL7UGO4dDqGaGqF5DxgA"}
          ],
        "PayloadDigest":"bGq-cj9J7OHsfvhk0hXsOwtP6C6lYOl0Qf8ZfetK
  7FBbMJYQY5woLCFoXXm91Rg6cQgOIuS-WWncODSrTlrOUg"}
      ],
    "ClientNonce":"T6yDJkuH59dB0w2WPLp2vA",
    "PinId":"AAGD-BQIW-ZKOT-UAIT-U4EJ-XSKW-AWMK",
    "PinWitness":"OgylccDOqR9SRRoG7QqYAQoyp7gjc8Em50QPqdjs17bq7pS
  9Omy66EY3wicHryKNq6dRkmjpkRNYMxfADriyJg",
    "MessageId":"NCO5-AV7A-DZYY-A5JD-GGWI-KH3Y-OJND"}}
~~~~

The service receives the conenct request and authenticates the message under the
device key. The service cannot authenticate the message under the PIN code because
that is not know to the service as the service cannot decrypt the local spool.

Having authenticated the connect request, the service generates a random nonce value.
The random nonce together with the device and account profiles are used to calculate
the witness value.

The AcknowledgeConnection message is created by the service:

~~~~
{
  "AcknowledgeConnection":{
    "EnvelopedRequestConnection":[{
        "EnvelopeId":"MBDW-KFHR-OR66-U6CR-CCEV-N4DD-MXXQ",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ081LUFWN0EtRF
  pZWS1BNUpELUdHV0ktS0gzWS1PSk5EIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyMy0wNi0yOFQxNzowMDo0NVoifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJBY2NvdW50QWRkcm
  VzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiQXV0aGVudGljYXRlZERhdGE
  iOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1CWFYtU0lCRi00WEVXLTRFVkUt
  N1VSVy1GNlZULU5UWDMiLAogICAgICAgICJkaWciOiAiUzUxMiIsCiAgICAgICAgI
  kNvbnRlbnRNZXRhRGF0YSI6ICJld29nSUNKVmJtbHhkV1ZKWkNJNklDSk5RbGhXTF
  ZOSlFrWXRORmhGVnkwCiAgMFJWWkZMVGRWVWxjdFJqWldWQzFPVkZneklpd0tJQ0F
  pVFdWemMyRm5aVlI1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxkbWxqWlNJc0NpQWdJ
  bU4wZVNJNklDSmhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV04wSWl3S0lDQQogI
  GlRM0psWVhSbFpDSTZJQ0l5TURJekxUQTJMVEk0VkRFM09qQXdPalExV2lKOSJ9LA
  ogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWtWdVk
  zSgogIDVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVSllWUzAzUVVv
  MUxVcFFTMDh0UjBwWFRpMUxSCiAgRVZCTFZoSFIxSXRRMFpKV1NJc0NpQWdJQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0
  pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE
  0SQogIGl3S0lDQWdJQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlWakZOYUhaRldsaHpN
  bGs1YnpNdGQxaFdNbTFrVDNBCiAgeWNWa3lNR3hXWjIxTlF6VnlSVGd4UlRORFJXa
  ERVMXBTWDBoMGVRb2dJRFpMTjFSTUxYY3hkM0V0WTFoMVkKICAwOXVaVVkyTVVScl
  FTSjlmWDBzQ2lBZ0lDQWlVMmxuYm1GMGRYSmxJam9nZXdvZ0lDQWdJQ0FpVldSbUl
  qbwogIGdJazFETmxJdFUwWkVRUzFQV1ZSS0xVZExOa3N0UmtsV1RpMVBUalZITFVr
  elVFVWlMQW9nSUNBZ0lDQWlVCiAgSFZpYkdsalVHRnlZVzFsZEdWeWN5STZJSHNLS
  UNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHMKICBLSUNBZ0lDQWdJQ0
  FnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk
  2SQogIENKTk5VVXRlazFHYURSVk9UQmxhRXRWYzJKa01tbERXVnByVUdkRlVuRmxU
  azh3VW00MFVsUk1aWHBzV1MxCiAgZlJXTmpWR3hGQ2lBZ05VTnBiek55Y25KclUye
  FljMnB5Ym1WNloyNUhTbGxCSW4xOWZTd0tJQ0FnSUNKQmQKICBYUm9aVzUwYVdOaG
  RHbHZiaUk2SUhzS0lDQWdJQ0FnSWxWa1ppSTZJQ0pOUTB4TExWcFVURlF0VWtGRE5
  pMQogIE9Ua3BGTFRVelNVUXRWalF5U0MxS1UwbEJJaXdLSUNBZ0lDQWdJbEIxWW14
  cFkxQmhjbUZ0WlhSbGNuTWlPCiAgaUI3Q2lBZ0lDQWdJQ0FnSWxCMVlteHBZMHRsZ
  VVWRFJFZ2lPaUI3Q2lBZ0lDQWdJQ0FnSUNBaVkzSjJJam8KICBnSWxnME5EZ2lMQW
  9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKRGIxVnFkRU5GVkVkTFdHcFBkMmh
  0UgogIGt3MFVVOXpabFZCTkVwWmVYSTBSRnBCVFhvd1YwUjFiRVUyYUdKWE1WRjJO
  M2RCQ2lBZ1IwRllWRkJ3TjBzCiAgMGRHOVZaMFl3U0dWdVQzQlpXVFpCSW4xOWZTd
  0tJQ0FnSUNKUWNtOW1hV3hsVTJsbmJtRjBkWEpsSWpvZ2UKICB3b2dJQ0FnSUNBaV
  ZXUm1Jam9nSWsxQ1dGWXRVMGxDUmkwMFdFVlhMVFJGVmtVdE4xVlNWeTFHTmxaVUx
  VNQogIFVXRE1pTEFvZ0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhz
  S0lDQWdJQ0FnSUNBaVVIVmliCiAgR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnS
  UNBZ0lDSmpjbllpT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0EKICBnSUNBZ0lsQjFZbX
  hwWXlJNklDSmlSVnBtVlRkTFJFTlJSbkZoUWpOM01sbDBTV0l0WDNNNWVsTmhVVEJ
  PWAogIHkxRlExZHNlbGN5YVcweFprSkxjVEJ2WTFoU0NpQWdTR3RIT0ZKR09XZDZR
  MjlwWnpkMVRFeEtZVXN5VlVWCiAgQkluMTlmWDE5IiwKICAgICAgewogICAgICAgI
  CJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6ICJTNTEyIiwKICAgIC
  AgICAgICAgImtpZCI6ICJNQlhWLVNJQkYtNFhFVy00RVZFLTdVUlctRjZWVC1OVFg
  zIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJWUVlCYlJsNnhtLVR6by11R2tP
  ZDUzUktRcm4xS0U2c281SUVobXdCT1FnNDl1SnRmCiAgamFKWVpUeEMxT2ZRM3oxd
  TJDT0dheURJUkFBdkZrQTR2TzdKRnBrNklPUTF0UmJ3SGF1LVFacjAwZXk5enoKIC
  BqajhjV25qYW5vemZTWE0xYjdUMDhETDdVR080ZERxR2FHcUY1RHhnQSJ9XSwKICA
  gICAgICAiUGF5bG9hZERpZ2VzdCI6ICJiR3EtY2o5SjdPSHNmdmhrMGhYc093dFA2
  QzZsWU9sMFFmOFpmZXRLN0ZCYk0KICBKWVFZNXdvTENGb1hYbTkxUmc2Y1FnT0l1U
  y1XV25jT0RTclRsck9VZyJ9XSwKICAgICJDbGllbnROb25jZSI6ICJUNnlESmt1SD
  U5ZEIwdzJXUExwMnZBIiwKICAgICJQaW5JZCI6ICJBQUdELUJRSVctWktPVC1VQUl
  ULVU0RUotWFNLVy1BV01LIiwKICAgICJQaW5XaXRuZXNzIjogIk9neWxjY0RPcVI5
  U1JSb0c3UXFZQVFveXA3Z2pjOEVtNTBRUHFkanMxN2JxN3BTOQogIE9teTY2RVkzd
  2ljSHJ5S05xNmRSa21qcGtSTllNeGZBRHJpeUpnIiwKICAgICJNZXNzYWdlSWQiOi
  AiTkNPNS1BVjdBLURaWVktQTVKRC1HR1dJLUtIM1ktT0pORCJ9fQ"
      ],
    "ServerNonce":"RwIahgJVCIL2S6si9w6JPA",
    "Witness":"GSJR-OHU5-HHXO-KURY-ST4B-HVBA-7PV5",
    "MessageId":"GSJR-OHU5-HHXO-KURY-ST4B-HVBA-7PV5"}}
~~~~

The AcknowledgeConnection message is appended to the Inbound spool of the account
to which connection was requested so that the user can approve the request. The
ConnectResponse message is returned to the device containing the AcknowledgeConnection 
message and the profile of the account.

The device generates the witness value, verifies it against the value provided by the server
and presents it to the user as seen in the console example above.

### Phase 3:

The user synchronizes their pending messages:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: GSJR-OHU5-HHXO-KURY-ST4B-HVBA-7PV5
        Connection Request::
        MessageID: GSJR-OHU5-HHXO-KURY-ST4B-HVBA-7PV5
        To:  From: 
        Device:  MBXV-SIBF-4XEW-4EVE-7URW-F6VT-NTX3
        Witness: GSJR-OHU5-HHXO-KURY-ST4B-HVBA-7PV5
MessageID: NCUD-3ROZ-X7UK-MMRA-CTYI-YHOE-UJCM
MessageID: NDTU-IIPR-L5SK-L6CZ-JJGF-XA6L-565H
        Confirmation Request::
        MessageID: NDTU-IIPR-L5SK-L6CZ-JJGF-XA6L-565H
        To: alice@example.com From: console@example.com
        Text: start
MessageID: ND4Y-TGCW-2QO3-KIQM-N3AN-DMIO-2CFT
MessageID: NCVI-FDFU-ZYPN-5274-YBHY-V6WI-FTEJ
MessageID: NA7V-2XT2-2ZJO-IDUY-GK6W-CTVX-HDDM
<cmd>Alice> meshman account sync /auto
</div>
~~~~

The administration device determines that the device connection request is authenticated
by a PIN code. The PIN code is retrieved and the message authenticated. This is shown in
the PIN registration interation example in section $$$ above.

Bug: This command is currently showing superflous pending messages due to the failure to
clear messages processed in earlier examples.

The Cataloged device record is created from the public key values corresponding to the
combination of the public keys in the device profile and those defined by the activation.

This is returned to the onboarding device by wrapping it in a RespondConnection message
posted to the local spool of the account.

~~~~
{
  "RespondConnection":{
    "Result":"Accept",
    "CatalogedDevice":{
      "DeviceUdf":"MBXV-SIBF-4XEW-4EVE-7URW-F6VT-NTX3",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQjNULVdJUFot
  SlJDVy1RWkZNLVNDUUwtT1ZWTy1BSE8yIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyMy0wNi0yOFQxNzowMDoxNVoifQ"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJDb21tb25TaWduYXR1cmUi
  OiB7CiAgICAgICJVZGYiOiAiTURFMi1NS01JLTc3M1AtR0ozRi1ZWUFJLVVWQ0stT
  01LUyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaW
  NLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICA
  iUHVibGljIjogImpSOXVyUGJvc2xvU1J1NThsa0tHOU80TDVCTnpxYkVzM29xOEl6
  d0xxVTJReUdSazhrV0QKICBvazZPT3doWU9jUmdYZW90X2VWT0FHbUEifX19LAogI
  CAgIkFjY291bnRBZGRyZXNzIjogImFsaWNlQGV4YW1wbGUuY29tIiwKICAgICJTZX
  J2aWNlVWRmIjogIk1EM0UtRk42Vy0zRzQ1LVlRNDMtUVhZUi1DVTRYLVJLRzUiLAo
  gICAgIkVzY3Jvd0VuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJTSy0yWTZH
  LURLNlAtVDZUVS1PU0xELUdDRlctTVBIRyIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydi
  I6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiUjVXMFRZVXljRU1oR3V4R3V
  Da0JUTVlCMU1nS1owMzZ5MDUyWExWYk1zanhnZzlpREQteQogIFZZVk5lX3lVQ204
  UUd0cFN0XzhFYjNjQSJ9fX0sCiAgICAiQWRtaW5pc3RyYXRvclNpZ25hdHVyZSI6I
  HsKICAgICAgIlVkZiI6ICJNQkw1LUpTTjMtVjU2US00VUxZLUdZN1gtR00zVi1LVl
  BaIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0t
  leUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAiWmM1bjlxNDgyRTVSdUhzSjRlZFdzcjc1YXh3elIzbVdibTVUNWxmb
  kJUUklBaWNhR1BvZwogIGJxYTU0eVNBN3NXamg0OTB4cnZyRXlhQSJ9fX0sCiAgIC
  AiQ29tbW9uRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQlVGLVA3UzItV0Z
  FRi1EM01MLU9LQ0MtWFlPVC02U0xEIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  lg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICI4U2hGY21OejVCVzluR09idTdfdF
  VaRDVobTVhblM3VGFyNTNSWERjZzVheWlQcGI3TDh6CiAgVkMxbGpqSmVBdS1oazl
  UVU51eVhFN3NBIn19fSwKICAgICJDb21tb25BdXRoZW50aWNhdGlvbiI6IHsKICAg
  ICAgIlVkZiI6ICJNRFlRLUpRQjItM0VPQy1ONFpELUZCSkUtSDNJWS1XTTZWIiwKI
  CAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDRE
  giOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI
  6ICIyelBsMTBxbnpwR0hfMWlkREZhVk15RXltRWY2Wm1oTXR6cG1sR2ZaSFoyc2lG
  QzBTSEk0CiAgd2FtZ2hzWVMzaEZMX3FYNm1PLVNRUXVBIn19fSwKICAgICJQcm9ma
  WxlU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CM1QtV0lQWi1KUkNXLVFaRk
  0tU0NRTC1PVlZPLUFITzIiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgi
  LAogICAgICAgICAgIlB1YmxpYyI6ICJvcjJYLXJQMHRhVFg2NkZ4WTY4UlI0UjdHZ
  mczcjYtTUljMzNRZUVnVTF3S2lfSFZLeWlCCiAgbktEWFpFZXhZdEVDMlpIN0NOcV
  VDMlFBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2",
              "signature":"lhicUvvDwdI2cJGDmMDmEYhZIDOp0be5IjblZG
  n0Uycnu3odE_h5jGOY3W58RlXBr_NHUwHfAbGAHcigqzKxUJGrM9MKXzgYF5JUx7u
  HSN4qXpAcBPHHnU1qLepITOsRMoT92a3KmLGskrt9O2PlgBQA"}
            ],
          "PayloadDigest":"hg5Z9SBDuRlEje8R3-0KZFBNHW738w1k0ZvF-n
  NJKZ4acEZKjmAwOzx3cbf6HXJoWy3eLs4BqYdhXQWkftir1g"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MBXV-SIBF-4XEW-4EVE-7URW-F6VT-NTX3",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlhWLVNJQkYt
  NFhFVy00RVZFLTdVUlctRjZWVC1OVFgzIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDIzLTA2LTI4VDE3OjAwOjQ1WiJ9"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIkVuY3J5cHRpb24iOiB7
  CiAgICAgICJVZGYiOiAiTUJYVS03QUo1LUpQS08tR0pXTi1LREVBLVhHR1ItQ0ZJW
  SIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZX
  lFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJ
  saWMiOiAiVjFNaHZFWlhzMlk5bzMtd1hWMm1kT3AycVkyMGxWZ21NQzVyRTgxRTND
  RWhDU1pSX0h0eQogIDZLN1RMLXcxd3EtY1h1Y09uZUY2MURrQSJ9fX0sCiAgICAiU
  2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DNlItU0ZEQS1PWVRKLUdLNkstRk
  lWTi1PTjVHLUkzUEUiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAog
  ICAgICAgICAgIlB1YmxpYyI6ICJNNUUtek1GaDRVOTBlaEtVc2JkMmlDWVprUGdFU
  nFlTk8wUm40UlRMZXpsWS1fRWNjVGxFCiAgNUNpbzNycnJrU2xYc2pybmV6Z25HSl
  lBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ0x
  LLVpUTFQtUkFDNi1OTkpFLTUzSUQtVjQySC1KU0lBIiwKICAgICAgIlB1YmxpY1Bh
  cmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgI
  CAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJDb1VqdENFVEdLWG
  pPd2htRkw0UU9zZlVBNEpZeXI0RFpBTXowV0R1bEU2aGJXMVF2N3dBCiAgR0FYVFB
  wN0s0dG9VZ0YwSGVuT3BZWTZBIn19fSwKICAgICJQcm9maWxlU2lnbmF0dXJlIjog
  ewogICAgICAiVWRmIjogIk1CWFYtU0lCRi00WEVXLTRFVkUtN1VSVy1GNlZULU5UW
  DMiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2
  V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB
  1YmxpYyI6ICJiRVpmVTdLRENRRnFhQjN3Mll0SWItX3M5elNhUTBOXy1FQ1dselcy
  aW0xZkJLcTBvY1hSCiAgSGtHOFJGOWd6Q29pZzd1TExKYUsyVUVBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBXV-SIBF-4XEW-4EVE-7URW-F6VT-NTX3",
              "signature":"VQYBbRl6xm-Tzo-uGkOd53RKQrn1KE6so5IEhm
  wBOQg49uJtfjaJYZTxC1OfQ3z1u2COGayDIRAAvFkA4vO7JFpk6IOQ1tRbwHau-QZ
  r00ey9zzjj8cWnjanozfSXM1b7T08DL7UGO4dDqGaGqF5DxgA"}
            ],
          "PayloadDigest":"bGq-cj9J7OHsfvhk0hXsOwtP6C6lYOl0Qf8Zfe
  tK7FBbMJYQY5woLCFoXXm91Rg6cQgOIuS-WWncODSrTlrOUg"}
        ],
      "EnvelopedConnectionService":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIzLTA2LTI4VDE3OjAwOjQ2WiJ9"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tApQcm9maWxlVWRmgCJNQjNULVdJ
  UFotSlJDVy1RWkZNLVNDUUwtT1ZWTy1BSE8ytA5BdXRoZW50aWNhdGlvbnu0A1VkZ
  oAiTUFWWC1RQlZGLTc0QjYtNVJQVy1HQ0JULUtQSEEtVkFSUbQQUHVibGljUGFyYW
  1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1YmxpY4g52UMykXg
  c2-SQVAF79AVp6DFrvFHKGSqmR6EupOG5JnaxPthlEvTvBi-8Y-yKQo13dnSXyVdq
  uTwAfX19fX0",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBL5-JSN3-V56Q-4ULY-GY7X-GM3V-KVPZ",
              "signature":"sSKVaJqQ-yMmJHluDeFYbl8RT0IadGzoB0mxYv
  ikFuGs3xd9LfbR3GI3bDE2-DNKxo0hXT_5iVcAySO8qq_5uaDYXgsWnLL1QOVnbuY
  W8mENaDw4aRwY8nuNIEd95ucEbKvlWQeO05vTM6AV4PeKfBIA"}
            ],
          "PayloadDigest":"vhymfJDU2ZqYtw9rC5C9dcXzW68bJrKzcOpop8
  ygUAul12Os9Dfpfvv_xR_rSVnAMhH10u3aLHXkEj1clP-gUA"}
        ],
      "EnvelopedConnectionDevice":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjMtMDYtMjhUMTc6MDA6NDZaIn0"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0BVJvbGVzW4AJdGhyZXNob2xkXbQJ
  U2lnbmF0dXJle7QDVWRmgCJNQ1NPLTdGVkstU1pTSi1CTEw2LVRTTzUtQTREWC1JR
  k1QtBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0ND
  i0BlB1YmxpY4g58pFP2Fd_qdovy4r8tqjjJSmUFuFDOd_eh8eOUsF4K4Y-XZqXOC7
  BttzYX0GKbKgijBgMHrSonv-AfX19tApFbmNyeXB0aW9ue7QDVWRmgCJNQ0RVLUZZ
  RFgtQzdJSC1SU0JKLTdMNlAtSks0SC1BRlJNtBBQdWJsaWNQYXJhbWV0ZXJze7QNU
  HVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibGljiDmj9dvET9-f4VhqVuUNF6
  aS4nIWX2IJ_zQfhFKf1UcOxgU8lR___499Sd-srS9nrNgAPpuKLgONooB9fX20ClB
  yb2ZpbGVVZGaAIk1CM1QtV0lQWi1KUkNXLVFaRk0tU0NRTC1PVlZPLUFITzK0DkF1
  dGhlbnRpY2F0aW9ue7QDVWRmgCJNQVZYLVFCVkYtNzRCNi01UlBXLUdDQlQtS1BIQ
  S1WQVJRtBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWD
  Q0OLQGUHVibGljiDnZQzKReBzb5JBUAXv0BWnoMWu8UcoZKqZHoS6k4bkmdrE-2GU
  S9O8GL7xj7IpCjXd2dJfJV2q5PAB9fX19fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBL5-JSN3-V56Q-4ULY-GY7X-GM3V-KVPZ",
              "signature":"ncUxQN2mKCjTCyHeL80j1ttmy3dleAx2yGYcSH
  u-KbWkqsid1ZxTg214aOrWA2YyyTpDasqwE_AA_8cPBvj9VjlUgdSH0yaizh0WvGr
  5CFZXPEezy_gfJab6Y5K68FjnHhTWVUKmaga7UnE3FsL2CygA"}
            ],
          "PayloadDigest":"Ow9JNgrmdo3OZFx1LxqTjxLjIepfu5peU7BTct
  ZGzdMurIZP-X8TFWUkKZp3gvPGkFyoCWzQOrzv9nBI3xNrWA"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQC-7EXZ-KHTZ-BUN4-HJNY-GGBL-BH6C",
          "Salt":"w-xiHxJZ_OSnoBidH8UwVA",
          "recipients":[{
              "kid":"MBXU-7AJ5-JPKO-GJWN-KDEA-XGGR-CFIY",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"dxdYbnkaiWM92pICS36poJKKrHA0Khno8qLmp
  Mh5r25Lfof5YU310h7OAmJUsMD7fFcyfqXKh16A"}},
              "wmk":"yRB0xSyG8_2Y98gN5nAVWnVLRqJpYSqGKZJws2_jsOYY
  _zd71H0Fqw"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIzLTA2LTI4VDE3OjAwOjQ2WiJ9"},
        "qCwfeQfw4zXOePD3NRWYx1Q1y0cTo8ryFAOmh_w0JRUO-Q6HQ5QnydRz
  UC3Uq9FRTrY7z6V3kU6fl2wpV6IG6blCySNeeZ7Fn5iLp5XoKWAOzbQhdmVAfqnSC
  9pl0BtN-uzmcivhL7MHNDa2gfvaHJQyuwGXLNsn0WSr8Ga4XJDBE_POvNK_Vr1EPk
  _AzX16zf7vxIMbzeV02Cek0tl_9_gtM5GeQrddbOBGyujxz2fORwk75kPiom0VqW5
  c2Dzo",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBL5-JSN3-V56Q-4ULY-GY7X-GM3V-KVPZ",
              "signature":"6c9x4UBciFTukZWwh0wBAFHHONa5rgZyn4IS8-
  TaOx9-VaE7Le0w_erIcde9QjlEqpCFqKcaBi8AS8HADe-1LzCg0n9x_zhKMjsFG_V
  _t_QnIhrtiLhKciwH-Q8vJx35PFe2LiOUYDFloY8LhxGtmhgA",
              "witness":"02VTHn5ewZpWlyTFGFhKB7QnjTHXtZUIZtBu5uEe
  olc"}
            ],
          "PayloadDigest":"AHh2P-CxhQnkBd2a0D5guRGZ45kyyuLp3ZTiFf
  QY2aIxuWm-U5m4yc_MXKSNk_q_9U-E0JDZYH97hMa07G2oGg"}
        ],
      "EnvelopedActivationCommon":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQD-J2HQ-VXSV-BYDM-MRRW-YMAW-X6BX",
          "Salt":"TmnO7mgp6xKPeviXcKDVRQ",
          "recipients":[{
              "kid":"MCDU-FYDX-C7IH-RSBJ-7L6P-JK4H-AFRM",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"F4tzMXhlfstTKdx07WClobClWW_aqwlw9p0D5
  PGxwBkYtQIzBk0D0KZo046KzjDEVQ-SMgzP-zmA"}},
              "wmk":"2pR7kt1Jv-mOT_5AJGIDZgrQ-Lo-4hq_tBVz3fwlH6FR
  vrGhKhsRjw"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQ29tbW9uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjMtMDYtMjhUMTc6MDA6NDZaIn0"},
        "-Ni7bIEgPjQAwz_d3F-dvedMkJMt7AqHlhpY-AQTdQF8Hw-lTkvc0ksg
  Ys5hKgs8cLS_MEo9LNUu1yJ9VZ4Z-c0GOLDJf4QFuahV6TQBH2YAEZKB6IazIvKsL
  v9ClA2_-uFy80Om5r5KMy9SzamcC48x8ucmoxU1S23nej8Gl2_wG-h55WaVoLDGB_
  zpXitIYdcsDxWZw5ASAONRpXiBhOSSSjC1VhRp2u3yjLEr5rkj2qO7tAB11kKHW49
  teutQoR-B9E0yJVdEx14j5uk5a6_WSYpUFuUEMtcuxyDKSbhZFsU1Uc8Wqd9O8ZIy
  fhkbedUqoxkdHmgEE4KsraxPEKKIsqqGc1YbVHqSK9r7mdaChqnOkF5DuBKMdyiws
  F9HXivIa1V0fTp9-fkVveT6GncA2mcSjOctCvweaKgwy7gAGDJg4a4wkTByI0aQK5
  niiJV1_zWEguFjhiGkocffSftheV_5Is4fUj1Wokj26PbesK-sbvsNfIS7N7dY9OS
  wdojbnxspxv-2NzG7fChwWOHEpiRGsPMBFd4MgkuWudD7XAC6aIpb8FiLErXc5qkT
  KYaafb4IwkgikiQNNFShE940zziU66JLmNHhzy9jakbTCK0Z9sNGhQc8oqdXLY1_6
  jsOsaq7AYguGHD_7KA6WvMF70Iha7H2O0p_rEvIfNtOhSHqcWa4Uxyba80IWMo8ze
  YKCI8VlFvkdZ_jIPcf3tvuGyVKucEQF9_bNHtOEGCjX63p02nJHhAzjD4AC8YG2cR
  AduoZkWfsfwMVnnmk4hTRv2ZSscLAPAaSmAelGKdqBw5ZoJD6R8ImUQpGZNAEGv4e
  PiY4TM6mAuxC-d-gK07RBX9F67UHN-LnjUKDTLXl70iZ3BpN45yiiaXnmPMgKNwMM
  Y1sJACsep7RKeOgISDyykQ8UqpTkxxHNuct43t5NCveZqV2bGgJtwgzxyCuI2xF26
  RxaKZP3TFaq4VzwDZ4hbH9smLJnSQ8cetiLg5BTYsNkvtY3L5WLdBzE7RuVDz5Hum
  aVK1JdfwKNAQ3Jusc8YbTZqrIv2ZffyMayj0woasL63f3udwGjqVi8nWLuyE6n29m
  41E_06nSR4J6usXsAlYQK1yf5HGhLMarraJvQ9FEdZ4JPRg6nSgQZvpQ446y3SlKy
  fUpkntiixu48yxotWneQuGIWlujJ0t95_PYmWmjTk-lV88-QVse6nX7GGnYpNbVSE
  LEa2Wp3pOfFfi_ACk1qTeUNdsxaGYiv5UtP3gTU_kK9XKSEHhTRCz5TMbA_5FBCjd
  2MXnwyQlIpxoSw6wo5kIPPau-LKVJChS5pwI-hW7wcuNsPeUvTbFKOVE3XM_xanJw
  uwYk-I0A2SQqb2LnHZeu2D0LRtoJQpbLwvhGkI8UXFqp6zYpt1OaPU3OND5yOCCCX
  Qg0AHzunCym0S9GbySMB7Pwh2V5RJ4mljGFF5g0lKe8-_E9W3_Nnmb-8UboPL34Vd
  dntsEzqfmzXyqdoS4YCY_A1ZLSYD58u_61v5h3gvlZERjEyhU4-GF-fVMBPlSyAy8
  AACAqbukxJ-Y252yeDm2-VK0j05eOmULG4RqYcH0tSmBihoEQxAXY-vhLUi0oBrig
  3YqwvAwDNWJRPqd2c8xcx65H3NgMLwEPsBjAmzhQ_WyOIf44gdfisxeEaoJ2S0gb0
  VboaTdNNJSnNcnBYfpI0DzW605jwGvj7NrV3c4oozYrfVyMoWnBLTod_qzrhmwPli
  F4eYv593xgmRP-IFBMI2ysaPcrI87s9UNv9oa-Wlz8M1pOJwCctuCi5XhQaabSgVs
  bjVS29eKQ05Ad5hliU1AW1-QSsFTyO9SWrAZrJGPCgnro-maWoUPrVMyKKnQQk1ie
  KErCBcZTWIdSefaoxedOwldmsM6kTa1wygfXbfS3gt8yRsTc0EgCwrNsUdUEI6kVi
  pWgfTq1dzkrmiAIU_B02yhtEb1HNgATwYAFp--PSbko1wuTrFwPFMfDVsajQDPAzT
  HD4w-AzR3PwPY0x_p8tKQKGPTSYz3oVfB92Cyh1hRWKyLccwG3yjbnSTmSdfFM6bq
  IyM3yYex0AdMUXXZuaNfS-m1bekpWplQYuAQXfGpUvKqAQz2YswFaS9wGeVm4diUh
  tpm9750ID9-gwYAUl7L-AcGNLfQkviUBGBwXw-0FpX_JcjOcAa4BoR6PloyY6BYNg
  xDb6B0klfStdqyETAAFa2BCB4TIFtGSyBBil--wWfYh128T2Ah_5MhbCFDZ4mGBZM
  osyo53DMLUjlRAajq4FKY8Sa5l6BXyrnUedqt737A_XPfM5GRtwfShlZtsMsEdlJ9
  BVCki3JZZVycl0rxcrhAuwsuhntwWq13BqTzuE22nmXTJ1TWCg38ByWSsEwmaatn-
  adiImpxfWzZj89h6EdeAn_fTdVY9zGOrIWO6WlT_-wUyQEgQ3usrhq99KbJfUrgnQ
  UopzHrHi90Ctw0xCED2oByG9neKTPzEcepRnE-ZBnaWxms1tqEUOn9dU0XMOmYXnn
  3ocUyDgJBtutpkX_f2mqhuIGg4jXHNL1cF6XEBRDFdO7QehYXqQDaMrzvqVtzNaKK
  6CU6j0K2KUdufUNDjOKZ7cUfuHKOMqyWrrmKEEhTb9p4OSj5OdP1K9UcjY3kSU-bL
  kTyT3daZsil_MbttKVVys3mBUVGJ49ivr86H1A-viU468--x4OVlIlv9BlUXJA34U
  x4XoxnFQo74vvebhAvMvED5Natsi9jmh16xZarhXFChk23HJ1PB7rkpnV7ePk-44k
  AOU6yYHwbKk0NJKn193pkKV0TfNmFTnFFlkcLzGVnakKBx33TbgRWDbqGUqFpyFfr
  fVQSEOQsPLzoa3FOutRcowr_oo90YYg9pr82jcQv3dbyixjAK_CzB1d_Yx6bPpZbG
  JvHs5mIDW6iBrWw5M3Fi_K7GOj8IMZ715HhEylAah_BzlPk7HDIgPy4WlPMTaiggm
  gUP6ElnkGzPfAw5gAQFIw-Bh9IOz-miaG1_T-6ECcMcFwFr0x0kqntpyzgCbItWZ2
  -zZ2orZJa0GjUH5Hv1YHL_jJkxGRHntEYZV8BHdNH4yaHmJTmqNIv55XsJtZsLl7R
  BKDL71fCCa4pMkQAU0m36CVvTy82Ft9u1ZOgBCYcbmETUwpcItkQXL-7dutdoqAx2
  AqMpn2uR1NaFxUsXRlO1ZiF_RFbf9_90zfV_v-UeYUWMWrx5jAamYv5paUPiC8SeZ
  XUTBI15N06IJAh6SqvDecCbRXFySuVnSikKOWae1DrOO04a07UnTlE6zcR0u_Ptt4
  2QIZj1KpRhLSHB06SnLp11Fy_8y_1M6JpinZE90yh8Eid0eVol1sBI6NQH-UoGeuD
  jNgVHbLfhYaL6kYdWGHAHIZiUA1RD2QfFYotmqe09Zt5xAAlkCgI0mVfPKMAd0VE1
  s69x7fhsdLKyMrgXw1hmX6sHXJrdwj4EmPSdXZBnjzPU6pE53dCflgMQzsfQI-xyM
  q6FMbXSY9sh1U4ZfL0Xs78s7zm4ZjgjtLAFn-T0a09BsfkaknCVDeNTJiH26mpoMa
  Ma6bHVUkRfoiSfG4LKdqFyWhYqZ1Z7nW_K1U6ZePim26OTYCeVu13jYPuz1xszQsq
  DV7BSyS4aV12TUeRT5RxihHPPDktqUVUk_au7aNrUPKKbDcMssByik00EfxmmFoIT
  cB5nVjeoayRH8P1M3iLf4TbdoeBgAQKbDWZBjXiiQvfxUHplrvdYTJEgfF_Fg8gWV
  VMn_Voo8TAfbb5V5EmbuKRppVzHG8fIQoK8xGTZFDjbzkf_IVlg4kPJpFe2duXrWy
  DPLscELZwl4R2nd1oNl0qp9RMwkZKor58w_osQzgNs3h6POmbM596L0byFCuPkWjf
  tJkuvOziDDPBzAnOs3KRNLUZEVBMV71c4qtxUXE8VCk0Z3IsRrolZb0WPiiYcfk7j
  TUkNJG9gwme3Pm6JrjGi8Ak_K2hYy8T2Y1FhCdnIp_6UmHCUQ_X8pGepGCplLGOB0
  ljPbOr1w84YP4_LdQfIApK_y3nUH_O4iB57bDWmfhpnPYWdeytIgtL7wip0lnUMAG
  6UmpO9sHjQ2hXdPuGQA87Uy0xd9-uWoeHwRiqfUBcnyTchlq9mSiFQk6XlWiwma6r
  co8xyVlHgz2IXvYUGSEU8tBL4JDj5CwONi9xKEw1QqSS6Ta2KwmzjRhuldybw_XhT
  p6cQYPzOczcunw27bIyyqXqi3YyDwgDW_CEu8DIeGD-6PCTuIsvG0wQG0h9Ry_86g
  sAr2k9EIowEVLW9VOmqC8tYZM5BgfEqnmohBGzpPjgY-BmzLI4KsPAm19otLhJpCx
  0UBxVWwjMyHftgdKmj7LS1pdHfu85jtWop4dwhKFh2rZmpNdvmmtnJFdl0kJP_LrW
  l8LSaYU-jjjptgTYIsRHZ2IzLrzM8_jvm4OZ4a4x7kxtnwYXxyQgLkAqVsRLVKArZ
  3LVsIItXF9C0tZEHsmi-eZiVxgf4UqbTlRszJztlmWUNsNyq8S5yKUgY1yohm_lm5
  YRmiyQTAuLTc-88XnmT8hi8li0k2NbnkokNNoRMLEOnPH9AIcChbHqjU9DFxL46Sd
  wTr7ajb1bfqtR4yHKW6SOiuRIn4wBKw3sr34mKfnuMdN2lX9jX_z-Y4sG3jBP9DMZ
  mH95CSAmYehn1dtmnPhxMv6EKrEJkD9DJxPdO-8KMQ-c3L5Rk2m8RlXV3MTpK60bt
  aXuQDqJDWBuq3WUF4MHyxck3MpjJ7PRGwuuqSg7CvzIcEla-3llVyCO6I1DbTEhHg
  v_2sy2C06Kg2ZQtSOCGkkmYfFpS_To7_VqGlcvqyae0WZKpJ_EF6de1pY6geBABN-
  ogqfj-yL2EVCwMc07noJIvAGzIJa0Q4JJw0hwigxzxiALigYaOoVDWIcDhxa-gIKX
  K23caq-7r0Nww5FNbfyifWmySF4Ny92CpxsgPVThAbfV8qWZRutcqLkKiKZ221bvn
  FQqqcaJaAbmpAe5O6Vwl2ScSS1VdUfPzK8j8n8Zqu3bcOIQbsrX1sMv-A0cg3YnBK
  NenJTaJKonVREYylsoEcCmO3fAmkbtZfPI1bq4zD7ZC6Fb7OScBWMxXdqZA9yUUq-
  rJYZIsyvoolYHwGV7LU_HUMso5bGJfaIB0DSddYUt8u1Ul8sJKGiiz-BxZDluPEhv
  okxCN_fXRDOIvllygV01LoEazKeyTVioq41UXNgi5ZshjQplN3RJU1hQcYOiBCKG6
  sBMFTqz-0L92jLtDHOzvbAoOpSsHlJkkwxbsu3BFeBqNfn0UqmSgK32-q0PYck9my
  yYH57xx0tqirf4iba1yXICA4NEAdWoyuYI_OLDSgZhJD4x_1Lk1cyafmN57CO0YTy
  LLkt8lDQ60cjvfG_BzKlK4Yg5XRqnMlo7eeo6OPv3FYg7xR2OXC8ka0aDblfLR3TE
  XK9FoQCH7dT4lHui9Fer3TGxsjUO3kntQwxyyOmHVRy8VFK65KIE3pXm8aKShkzYl
  UelYlgh3rivF_FGCCrisaqlgEamjJSiwdTVkKALsqSP_i_S3kZaR_OOnPn-tUOxBB
  ZJ9NPyBaYhf5kD2HZmB_AIZe6fL_b23lGgOHe6AaUsElFx7FUtyL6aDOeJOQDfV3A
  x3RhYrAsrfQWzc0lXKCyvnE8CJ7ZafQAuJuyXgPzKPIuakHEVv2ExpN8Nxib3dwIX
  qAyd_vJ8nqbZ4MLzINQu2R9ptSgZs1fPqd1nugN-5laJ0CodcjVn-CZeGga-XPyBx
  eVVcqY9YP4E-hSPd-26Nq3jGoIlJgQtRO4su7t6Tc91Jyy5FyoCH8T4DjiQAmvo3X
  BdvhiaUWW_bSVRagcNsAO0Z9WwHTo3ri_1vipL8JuoxDSWwh9_4OBYlcYNlxfFj9l
  fJu2C9hhrg8k0MPzPitT1jcYW0RQAieFMwCtXJdoVe1ZNCum-0oPiEGuB_x0l25AW
  3x_xRkyi7vHWgXMIGx_02T4mbeJ8TzyGHlwpoeJKNV4k7yDmdUqbkZQ_NY-NR1jo1
  B05t1Z35VS0GXq24w-2QrXJd6XlUJaGH84Fx78pX_qZrA6qWxunGQ1JpeFaJ8HeoC
  QGE7AWNOAOv7n-w63ASfCD762Xg6dJ9OKDkYse8NjLb4WdD6wvAXuHNL1bouMIdQL
  _03lY49GJueCM6ZiES3_FI3Rl-8VWvZCVqvtEwwAjYovbttat2GoabEcU9VGLEt42
  mL80xb598e40xNwOuoMTCvFMEdv5Sz0j4KyhdI0AeDwI5Bc58_kJFodJ_VHXgbtui
  SqhXcv_u0Z6NDpb19CsGTEJFHM-4BmerJ5tIU-IQIhFxaJf6taD0Mqlf_i7YSsykl
  9aEequY5HxuLGYh96-LeXaDD66JBJnUtNL4vKCYqcN8_zy7wJAt51guplOPHOdeat
  hmtd68bx-79oMkZnoT_D0teHeXcHv-qbkSoj0Xc7pWOghA_NYY5h0_1kSIzFcT_B-
  AC4qV9cDfyXYnYbCBcMWE279FWm1qNRl0g3w7PPjFASIdERkqXZwvDzsX92JlNR6V
  VKZN5ttf945YnRM7QFQSMYIdhWRnnIUQQ8uTRkKZscrpCRsNR1nYj09z6M5ncTKuv
  _kt2vBFMKK8hOSZbBlKhwx3YOXyspJkgwyuAz1AlSysfU3yRLzK_d7PNqIT0pCpPE
  GysPNKdDCUzl6vegx11eku1XZC-4_M_FVTMhO8ciqgGqfvSE10hgD4WykM_IYB8iu
  -L64RLSARz301G5WuLz_p4HdzL0SvZ_mmXquYf189R54EXb0mcgYVm_XcFdQBbMaK
  4IuetN-pLcO6JO0Sjk2KaPrZEtmJwVxPYN0UUzGXcSP7DpDkRvWrF7fNVypikhw7u
  1xVbKbVvBjpjVyyBjk2VjwkYdN0l3qskKH6Z4OE6qeBU1WLb0fzASdr2abVCXPY-F
  c964LvKiungIczW3DtsS9JVp91YCWjlp6seWhF4uaqmyuoREtSUHezE1Jt74ABkRR
  s8CN5BxriuS-Yq3O2XXDWRmuxHseqlaG9tLqHQXhvqZYeJHl9KdUcZq53RY0b1rwt
  A-fMJs1QGVaLBJPPHsc7g3blevBSuEAci9qw-2Hq37Gb1R77JkAI8ieeW6h7qE33z
  RbILOTpNfKH6UNkvmSpwDtfAPzRyrTuifJcEggNRPdAXR8SwznKcVtlN7dfg1yY4W
  aAO0pCmV8BPTldVuyuImk1vVULy37PIXSlvt5oveA7-c5Xb2blQpMGH2JCrb-a5S2
  Y58TLrMrtsmkvdxyuUshNlkr2qOqSkgIsbwOQoVPE6x-1RndLVZEiZqlYF_XhM7V_
  pusxm_iHbyCzyhdfi1t7u6T5-fCXcrkKyjdQvwC8II0SRFcPAnIP2_QRrmzWRypoE
  L36dfqWNRY6KoireoIZ6D2ozwXZhEVh-xyJ6DjW9lkOUHxAmpQcn1krvGjaevNjAn
  OCtIxmex4zT1VqHYDk7D0SWzsIl3rDN5TEp141zr_-dgDG_XMUhSzFiRg46FoqhBY
  yD9KrDMxmSIoQQMDhVfEnSe9-dp3k5W1w_V3a3QeurDm5tEoy0-gL_jkkj_fQL2py
  cwKvVUSeVPln5iJ2sFoSbtcsk7BBY_5BdU-aLXDmGxRPulI8OBQd34-uaz8VCmWo2
  mmNLuuPuu-7hlMcVIeW49-4Ido2bfkaA3DFQAG_dSCDvbB4rWm17E_-bs8Q8RPziA
  8-MKfplPO--p7HkcJI-cscOBDaygtw6AonKxriBwm0y1NpFlbr9QGBAR6IIBkss8R
  ROdy_QcRV0T99FPtiTbUlncNKMNH0znnB56jgUZDsF0qLZ-dbnutbA2DyNTUJJB_l
  fXBlXVTcotzE2ifzPdTw9yylT7ByxeYIueEN3x5GG8lDcdozfkU5ZaG71RmqtBK3F
  GuvBZUbs7le3FQn4rwS2xlZvzGKwZkVTme0qBNLs0czpbgU9FFMIRoWT8_sl9ezYi
  2ptxclHNWX-0CWoumq7Y_NYnEgUMIsIeHFn9s2DIbT8vUsOGnoBTgw14X1vrAUOv9
  AHnfwu-fTq0LnFwuSZo9VCfCnmMswV49OO2jWBFdMQ2BOpHRqPZKIOa-BnZL0vErW
  IlY_WQlvp8qi0uSg4-0wncfgm2WGb7Q-78f04gBsOwmGdrtXe5kww5yiLGeXntAep
  hNUGSC2AxtrtnT45QkC01ovduw8AW4E_UB7y9vPRm2gJoDAJovcOL4F5b_pJiAVqN
  VpobWEhOxzQ93ZvU33YFP4X4W9WwGHHDvNvBgSA4XuStNg6rbUCCTLKiv-JqV3Vnj
  0PcLUbDyY_GpF7LTXz9LIX--y-UMJxAfiLmrb8s7SbNgf6OkZtOeYitDQd9OyT9xM
  RdaUenSwVUfgHBj80cyc65H26J4IrJnvigMgmyMnU1T_ZE7Q76qUOnqALXrlt5wtg
  64E4txSyuNPX_vILH36duyXq_9TGJSiduCNMlaijq3bE8E7F_SoidyM6bep7sLYgm
  uNryg2Fa59wRxsHojSptaVI9MyPAL71n-uqsooJILjHzNm4Z1qQY9pCtO4vAAXFft
  u8bsgBlAWFiPe0rGgRqTf0TaNE6TroUuvp7MOStPnBJrN-kdaNu-v1LfWMkQJg5BE
  TKUgck62CDUy70fHDfKfkrF7Xw",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBL5-JSN3-V56Q-4ULY-GY7X-GM3V-KVPZ",
              "signature":"qxPr1aJDCkaAnD5_j41aMXmQeqQQtk0h3mnZG9
  kc2YLkC2ahX_Oge1dBW-WH7waQ4fGOt8G8auMACNt7m38A5OCxOnCbo9XRrUMSpwc
  uD5tuaAJkZCKkh7TbjcreckIcy1cDLheVsgacYsQKxCaZEwMA",
              "witness":"QQQrqg4a5Y3piY70Mg-K9o6tojViA-xSVXqv2gdV
  -r0"}
            ],
          "PayloadDigest":"njF6X87ZqBPxVDQb527JK1cr3rPAyMgUCUk6Qx
  pfGBPo1BFeuDLS5ZDsVbFVGx1EiL2Q2Eu1vHuJ9bc6meFzHQ"}
        ],
      "ApplicationEntries":[{
          "ApplicationEntrySsh":{
            "EnvelopedActivation":[{
                "enc":"A256CBC",
                "kid":"EBQC-JSUS-ARTD-I7L6-KTPV-TZQG-P46Y",
                "Salt":"1ZSrwDiQwawYDnDD7lRzVQ",
                "recipients":[{
                    "kid":"MCDU-FYDX-C7IH-RSBJ-7L6P-JK4H-AFRM",
                    "epk":{
                      "PublicKeyECDH":{
                        "crv":"X448",
                        "Public":"nwajSJCeuM0S0RGBctttS73ZxN_r0tF
  GYp6a-gGf-gUFXMYkVjGOAuHHJLFObS5PB67xuqAhis2A"}},
                    "wmk":"L8JVTz314UgAd7L15URGrq2yp0XFG5kthI43ZO
  j9fdJN9PP1P3sgTw"}
                  ],
                "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3
  RpdmF0aW9uQXBwbGljYXRpb25Tc2giLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1
  tL29iamVjdCIsCiAgIkNyZWF0ZWQiOiAiMjAyMy0wNi0yOFQxNzowMDo0NloifQ"},
              "W0H2Y_PEBun55pYf8nO39p-1yMjg0auMVMfMH1-7vp0Py-DWrP
  sLMwhebTMSxVv6h2rk-qHr2b5gyfoS8t5ygKcj2dwRupvMoB-JIW0b097-qwCZqWx
  HPHES7sxZcCpLNi7pB-DUmII5GmBDcaO0P3zYQyd4jIB_8jTE91gLz8rKX0sBxxyz
  rFCmmc0-mGEevY1MvHMlQgHY-XO8SWPzhgyFiP7FOhr6VmfnvQ2de2icEYZAGjD_G
  6SC_IlQhcKB3MYgqAGPBO4gs7K7xWp7Kt0O-20AbTDwCogYQCLLMPM4vEL-qaVi1u
  GudieuJy40tzwihyQipCOaqtSNb7g99n8Ng17WeKYeNsLw5-DQVw--fL2nzlWXp7X
  7bg7gjli1duXVSX3HRNB--uuqzosl76rKMefWpqvtnQkMTY2DkuHRex-zrqAEUjt_
  B1vT12EFNUN8MuBq1Ag2aeUxBP89O910qFRRxpmpdx6YQfn69BoH0IWaBjn19TIrQ
  iEWAJyIG4gRsnWeEl_sArhfJblc-V8WMrYojFr7Mlgr5s3xivg0Byk3jzOUEkEaLH
  LTYUl0zp4AFtPWICaXK9ICBAC0XsSsMBWM4Vw5g17HRFw_CBfjcFm_zpXczbWjobR
  c2A5CJ7uUDoT4CnPcKMy3KoKNXbfi1R4lnPdXXM92z5ja7bUkfAZZBiOlIU-7ugLP
  ExkpPbjAZQuFfsW2HYnyEgAdQfzsBz8MlwYiN8GZEiFflbJOzggmCrMz0_YIGxUWl
  4pvs_vpxTEVqMq5negEUrsGNBMSlEeP7xJLv31iwQJjd3-zheJEUv7UnTsAnCaJqB
  cET2MvM09kVE7eyaLql9RXfpr-9o188xN696jx6bDp6AainJLsmfDcvdwEeYMDyfL
  0AAxaWge4IiV3UIzGWnjv6kb0i0mOq67lFIlFKoBoM2fsODvo_FxnAoVrH-_l_Syq
  4j5Xj_YdZs06FRJnQGIBAaVv6jL47EIR5jp7fBJt6OM0QB9FL0UfxrZvZ8VVZvTyV
  PO6aFXLCXdPI5ZsbIm7IVralPGbhAa0tywv8jYM1zRIblz0yHGdzHotRfuNfnbUcG
  MoBwPwj54xIlJU-FBHEhNoD3qPYLT0KT0Y2t4WbgRoI12df9vo3DlPFdmyA9mYT0s
  d8FJR5_D1iGk9swqYE6eBc1wt02A1_Azqp4z1Qd0cD5J9_K-S5BfOfwFB-1DcwfLe
  jf5mAKfTAk7qN2R_ytSb3GhOzVUWpybQSh7DWRiwrwxA5X-3UlasrUKrPrPYt2PkC
  sPm_DqC7-a5GBJpf8koUR4B58skbzrlgqYMYzPBHaCnPe0mbeNfRmYtkm5fS_AvdW
  QoQPniEKQGge8eJxm3vu0xjfBroAiSghtvvrDSEii2SLIYVzN_ZI0EgMVVV5J4_vi
  pKlVFBwlByYvDSLpn0B_RCbjOp79gXwKNWYZ9kElnWWbloP62P6B8oj8TKLgcnabZ
  -zLlO9G7JRc-DO8HGRLewKFdRbpElVfzTH3RKdc4imgCmQLSTEn1Te7ZlKI-wGbk-
  U60UI3s_crt9zuycckygiHvz-YoHaV2gcGKi3p8HqNG_qPNj3wqZaz7pWob1Xd0K1
  wzReJivpzddDS9xWg7tQFxy-wS0fyvtSzB2tpZ9mvLLhrO3ZoRd805Fs4gvy3ZL9g
  8siU3Y6Jx88ho6TYTfvjCaANSXV9vwEJiaP4_mv7deas1XXzhIZiVVZqACSqwKdGY
  HUXP7zG7TTtn8aV-6o-3QYg6IvzVWTdikuTN-csQZufCZQIJkr_9WmAHj_zewIS75
  3Rl6KfKVrFd_42pFSsCIVNB_qW0B8DbNUOlrEIJMapqEv74lOmJZcSQFK_xfDTkId
  0bGUQd1nD5jlIcJWpPxoSMVfzhPCmx8ZsIebTt_fcKSXpmNiKSNoWPspacD354k50
  AC97g5ISqYrViWLhMwNFh0gxfRyjjxtHbPqT0-HlIuCG-WMSEqJnnOdFwOARb-Fwq
  1teBqkicBH8-8SjvziVGJ8oU0xLIo6jjKO5uolofNUvYcfXRBaCUnb4KblZi8El0P
  JKJwih8I8mg9bGjEzcjP2IFxJmWnIRn8OJWW3TlaKv8-Xjr8hLlwWk_9WDdVbFp9a
  W8MO4SOaa-3w6Yg7buzlOw1Q-6i-cE6OJjtSal1bIQUsVei2pTz0KVp3sE8tDPWNB
  3q5khmDiXZa0Ju5QL8h_TlQoof7ZbwKK-HycLim-O6cJ1AD0m5rYfLOblJZ7JEnUK
  0jh1WjTmGb6r4pUb-WllRF_ACWtuo3gnX_A0_q-RwfPzI-DxuNzxwcm23xrUF5h2n
  s_eojTVeTJSZqmvTVcyKZ8iZ4hAaaw1BpzXt0bIMisJXnCi26_5nQM0YuodsXXTny
  -yLyHQaJ2TL6L9i7GLodmhJsjYEUq_y170jPAWygTFe09NT4Px2b3SMsotyTb6cwZ
  AUu7uPLrC2GxwZXAtGnAMm_Da1kWLYLAjiNMY46EzKob9C4ONK1E1BTY0m6gRYI5e
  J0gk96jDymmdeMZcnMG5DXh--uiCIZXJqekGaS_JPmbZG24ylT8kqHCiwdl0LxC71
  Nk4ky3ypG9cQyOkMfl6N4L_OLZdh61mQpUzW8kJErrwKYCEbbDyAwgBnEpyfy25ts
  CSZUhXKQovvUg8XwiO3snh7UnvdJf7naOTxoMOn05kz1-XrN3KhtRuWpJJ9IGiS9y
  SYCOBClVGJCeIGtq4g457TtKPrqoyhx_RoyRmHtKM3E27Yg9dGcd437qEN5mJzojR
  v4_eXYUVwr_nE9w4gb8AQOFTZ__3BvapI2-5-i_AVwuKOYr5ZEtwf3zTRExgB53Wy
  J0EGf5u46s76TcgDMSCjQP53rdAspYy0B5g1kMLu6fWMs-xpRmjqnxQ3dgMvlv6WM
  mOzQC0eWdcvD_LkdTQkmjgzQWdNJsik3wjlUMRzo3WKTU0h0_pm9GyAJaSHvshiql
  bZk6xAXmB4ASITvm4E1KF3RAQCfe6JQ9oz3f3t1_8fgC9gXcq18Vfn1HJGbTVcxLu
  59t0g68k8JJcqIPg19d94qopz38xV1yQcOIjfmBYVpfeMkrC4VG1RbvQDi6oj7iEJ
  w9vyva-WEfL4k0hIARO4wQke0zM0W7lBN3CzJfmTRxwJ3TNCkUgh-ORZTjflVGGOq
  gHtt6IapSjnAB1hqLHGlPwRpN8MEQBnXgGbGc5Gm9-aKwa1kdWCXjs8fxg-mXOd4X
  YFH-O5RYrAb09G7eecAQWaY7ps8pASU3Wx0Afz9F3mLZlA3m4Hq_D0ZztZKvxpYtl
  YBmp4mEva2m_AWDNbaIBsY73lyDQ"
              ],
            "Identifier":"MAOY-3KTL-BIW6-BS7V-EANA-AZTL-5Q2Y"}}
        ]},
    "MessageId":"MAQQ-DQZI-2WLP-3E5Y-IMGT-PLIE-MJ2S"}}
~~~~

### Phase 4

The device periodically polls for completion of the connection request using the
Complete transaction.

To provide a final check on the process, the command line tool presents the UDF of 
the account profile to which the device has connected if successful:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MBXV-SIBF-4XEW-4EVE-7URW-F6VT-NTX3
   Account = alice@example.com
   Account UDF = MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
<cmd>Alice3> meshman account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MAQQ-DQZI-2WLP-3E5Y-IMGT-PLIE-MJ2S"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

