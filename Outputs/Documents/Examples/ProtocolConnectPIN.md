
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=ADKW-K2ZB-PPZM-ECG4-P3NQ-UN4K-XI
 (Expires=2022-05-04T16:47:51Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcu://alice@example.com/ADKW-K2ZB-PPZM-ECG4-P3NQ-UN4K-XI
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    ADKW-K2ZB-PPZM-ECG4-P3NQ-UN4K-XI
<rsp>   Device UDF = MAWL-JZU3-BV3H-JBT4-KPLE-OU4A-UNSY
   Witness value = YDLF-TRCY-GPUF-HGY3-7NRH-IIIG-DTGX
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "MessageId":"NDTL-GUGD-IBJR-4ENF-M4E3-7YJY-OCLR",
    "AuthenticatedData":[{
        "EnvelopeId":"MAWL-JZU3-BV3H-JBT4-KPLE-OU4A-UNSY",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQVdMLUpaVTMtQl
  YzSC1KQlQ0LUtQTEUtT1U0QS1VTlNZIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIyLTA1LTAzVDE2OjQ3OjUxWiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUFXTC1KWlUzLUJWM0gtSkJUNC1LUExFLU9VNEE
  tVU5TWSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIk9rYTY2RlpqMW4tRHJxMFZhcGNrM3AyMWI4ZTdGTHhSTkY2VD
  VnZjFuaG1ZU3N1YjJpdi0KICB5ek8zOFFYd2ZKVmNuSS1ETWwtMUpITUEifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUFQTC02N1FBLTVZWDMt
  WklURy1LRUc1LU1ENEUtQ081RyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiVkRHNWJGUTN4TVN3R01MWDN3dTlSQlc
  tTWFhS0dRNXZnUVd2aTNMNlpxRjhwLXA5LU12ZAogIHlxSHl4TmFqN2pKbDcyN010
  cDE0THRhQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DR
  TUtRFhRQS1PV0RRLUM1RkwtQU1EUS1SWFNCLU9LV0oiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ3a2VSWUlyYW9V
  bktWWmlhQlU5QU9qVHhKXzRZVHBnd1NfOG85V3ZkYTYzcXVJdGYxZjVhCiAgWWtiZ
  GFnYUs1OGdPTFlLc3gyM0EzMElBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQ0szLTNIUVMtWklPQS1EQjVILURJWkctUVZDUy02S1V
  IIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJGcjVPWkdfYlkzM0FLd0xTeFg5UGJxalNzdkQyMFl6aFE3bGx1RjhfaG
  12MDlUbU51UFJHCiAgS3NZaV9fMkgwV2xZMjBtMWNzRDhvTDhBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAWL-JZU3-BV3H-JBT4-KPLE-OU4A-UNSY",
            "signature":"uQZhXm18RTy1-x1-KKq4jZ1J2H9MbteHoaEoVe0e
  MtgYQVZmgc2JPHaWA58IITf2O1p_ewbtXMqA44AX95FcNUHPcbrwTF-KWTgF1ERKv
  h3o4TpI0oCn_TNIpTmPPmEUJc09zFVHPdubcEB1ewkhfCgA"}
          ],
        "PayloadDigest":"owxkrybmoxY5RI4okLHahlmgDBUTxf3ZFA90S9O9
  tVNoX4Th2DBW6yEDZKVvQIBPlu03COoT0x-bWUPfpQN6bg"}
      ],
    "ClientNonce":"Hul_uM9-BJdhPzYjhNMa3Q",
    "PinId":"AALG-XLJN-YZC3-2PZ5-LJK4-2TWB-7TST",
    "PinWitness":"EaqYtqTJJRqdmxyskiuB9_y9qPNGWnRnglnfctD89gcsc6Q
  8eTVPk8_RPKowRc-4ebgcY48gpTdhrENWiWLQ8g",
    "AccountAddress":"alice@example.com"}}
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
    "MessageId":"YDLF-TRCY-GPUF-HGY3-7NRH-IIIG-DTGX",
    "EnvelopedRequestConnection":[{
        "EnvelopeId":"MAC2-EOFV-EAVW-LCJQ-NO2I-UWJ4-IJCV",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORFRMLUdVR0QtSU
  JKUi00RU5GLU00RTMtN1lKWS1PQ0xSIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyMi0wNS0wM1QxNjo0Nzo1MVoifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJNZXNzYWdlSWQiOi
  AiTkRUTC1HVUdELUlCSlItNEVORi1NNEUzLTdZSlktT0NMUiIsCiAgICAiQXV0aGV
  udGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1BV0wtSlpV
  My1CVjNILUpCVDQtS1BMRS1PVTRBLVVOU1kiLAogICAgICAgICJkaWciOiAiUzUxM
  iIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI6ICJld29nSUNKVmJtbHhkV1ZKWk
  NJNklDSk5RVmRNTFVwYVZUTXRRbFl6U0MxCiAgS1FsUTBMVXRRVEVVdFQxVTBRUzF
  WVGxOWklpd0tJQ0FpVFdWemMyRm5aVlI1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxk
  bWxqWlNJc0NpQWdJbU4wZVNJNklDSmhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV
  04wSWl3S0lDQQogIGlRM0psWVhSbFpDSTZJQ0l5TURJeUxUQTFMVEF6VkRFMk9qUT
  NPalV4V2lKOSJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V
  3b2dJQ0FnSWxCeWIyWgogIHBiR1ZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNK
  VlpHWWlPaUFpVFVGWFRDMUtXbFV6TFVKV00wZ3RTCiAga0pVTkMxTFVFeEZMVTlWT
  kVFdFZVNVRXU0lzQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KIC
  BnZXdvZ0lDQWdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0F
  nSUNBZ0ltTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmli
  R2xqSWpvZ0lrOXJZVFkyUmxwcU1XNHRSSEp4TUZaCiAgaGNHTnJNM0F5TVdJNFpUZ
  EdUSGhTVGtZMlZEVm5aakZ1YUcxWlUzTjFZakpwZGkwS0lDQjVlazh6T0ZGWWQKIC
  AyWktWbU51U1MxRVRXd3RNVXBJVFVFaWZYMTlMQW9nSUNBZ0lrVnVZM0o1Y0hScGI
  yNGlPaUI3Q2lBZ0lDQQogIGdJQ0pWWkdZaU9pQWlUVUZRVEMwMk4xRkJMVFZaV0RN
  dFdrbFVSeTFMUlVjMUxVMUVORVV0UTA4MVJ5SXNDCiAgaUFnSUNBZ0lDSlFkV0pzY
  VdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGwKIC
  BGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0F
  nSUNBZ0lDQWdJQ0pRZAogIFdKc2FXTWlPaUFpVmtSSE5XSkdVVE40VFZOM1IwMU1X
  RE4zZFRsU1FsY3RUV0ZoUzBkUk5YWm5VVmQyYVROCiAgTU5scHhSamh3TFhBNUxVM
  TJaQW9nSUhseFNIbDRUbUZxTjJwS2JEY3lOMDEwY0RFMFRIUmhRU0o5Zlgwc0MKIC
  BpQWdJQ0FpVTJsbmJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxRFJ
  UVXRSRmhSUVMxUFYwUgogIFJMVU0xUmt3dFFVMUVVUzFTV0ZOQ0xVOUxWMG9pTEFv
  Z0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljCiAgeUk2SUhzS0lDQWdJQ0FnS
  UNBaVVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjblkKIC
  BpT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSjNhMlZ
  TV1VseVlXOVZia3RXVwogIG1saFFsVTVRVTlxVkhoS1h6UlpWSEJuZDFOZk9HODVW
  M1prWVRZemNYVkpkR1l4WmpWaENpQWdXV3RpWkdGCiAgbllVczFPR2RQVEZsTGMzZ
  3lNMEV6TUVsQkluMTlmU3dLSUNBZ0lDSkJkWFJvWlc1MGFXTmhkR2x2YmlJNkkKIC
  BIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlEwc3pMVE5JVVZNdFdrbFBRUzFFUWpWSUx
  VUkpXa2N0VVZaRFV5MAogIDJTMVZJSWl3S0lDQWdJQ0FnSWxCMVlteHBZMUJoY21G
  dFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZCiAgbXhwWTB0bGVVVkRSRWdpT
  2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0lsZzBORGdpTEFvZ0lDQWdJQ0EKIC
  BnSUNBZ0lsQjFZbXhwWXlJNklDSkdjalZQV2tkZllsa3pNMEZMZDB4VGVGZzVVR0p
  4YWxOemRrUXlNRmw2YQogIEZFM2JHeDFSamhmYUcxMk1EbFViVTUxVUZKSENpQWdT
  M05aYVY5Zk1rZ3dWMnhaTWpCdE1XTnpSRGh2VERoCiAgQkluMTlmWDE5IiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6IC
  JTNTEyIiwKICAgICAgICAgICAgImtpZCI6ICJNQVdMLUpaVTMtQlYzSC1KQlQ0LUt
  QTEUtT1U0QS1VTlNZIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJ1UVpoWG0x
  OFJUeTEteDEtS0txNGpaMUoySDlNYnRlSG9hRW9WZTBlTXRnWVFWWm1nCiAgYzJKU
  EhhV0E1OElJVGYyTzFwX2V3YnRYTXFBNDRBWDk1RmNOVUhQY2Jyd1RGLUtXVGdGMU
  VSS3ZoM280VHAKICBJMG9Dbl9UTklwVG1QUG1FVUpjMDl6RlZIUGR1YmNFQjFld2t
  oZkNnQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJvd3hrcnlibW94WTVS
  STRva0xIYWhsbWdEQlVUeGYzWkZBOTBTOU85dFZOb1gKICA0VGgyREJXNnlFRFpLV
  nZRSUJQbHUwM0NPb1QweC1iV1VQZnBRTjZiZyJ9XSwKICAgICJDbGllbnROb25jZS
  I6ICJIdWxfdU05LUJKZGhQellqaE5NYTNRIiwKICAgICJQaW5JZCI6ICJBQUxHLVh
  MSk4tWVpDMy0yUFo1LUxKSzQtMlRXQi03VFNUIiwKICAgICJQaW5XaXRuZXNzIjog
  IkVhcVl0cVRKSlJxZG14eXNraXVCOV95OXFQTkdXblJuZ2xuZmN0RDg5Z2NzYzZRO
  AogIGVUVlBrOF9SUEtvd1JjLTRlYmdjWTQ4Z3BUZGhyRU5XaVdMUThnIiwKICAgIC
  JBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"
      ],
    "ServerNonce":"uhfLuPaHr4uQijxTuVIFrA",
    "Witness":"YDLF-TRCY-GPUF-HGY3-7NRH-IIIG-DTGX"}}
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
<rsp>MessageID: YDLF-TRCY-GPUF-HGY3-7NRH-IIIG-DTGX
        Connection Request::
        MessageID: YDLF-TRCY-GPUF-HGY3-7NRH-IIIG-DTGX
        To:  From: 
        Device:  MAWL-JZU3-BV3H-JBT4-KPLE-OU4A-UNSY
        Witness: YDLF-TRCY-GPUF-HGY3-7NRH-IIIG-DTGX
MessageID: NAJ7-2JAE-5VND-GLM3-YYHF-FQX2-TCF7
        Confirmation Request::
        MessageID: NAJ7-2JAE-5VND-GLM3-YYHF-FQX2-TCF7
        To: alice@example.com From: console@example.com
        Text: start
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
    "MessageId":"MBVK-ZODF-LLR2-AHO6-FWDB-NVNJ-GXIC",
    "Result":"Accept",
    "CatalogedDevice":{
      "DeviceUdf":"MAWL-JZU3-BV3H-JBT4-KPLE-OU4A-UNSY",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQVJQLUhINkIt
  RDJKVy1XTFE2LVJXUFEtMlNMUy1BSTJWIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyMi0wNS0wM1QxNjo0Njo1NloifQ"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJl
  IjogewogICAgICAiVWRmIjogIk1BUlAtSEg2Qi1EMkpXLVdMUTYtUldQUS0yU0xTL
  UFJMlYiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibG
  ljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJTakJJalhIUEZmUFc1cFZxby1LcXVUNHFDUkpPTDgyeU5iRGY5
  eEZhYmkwdnVuUDNYR2ZmCiAgVjgtczhXSlVlX0gzV0NYOWJMSVc1enVBIn19fSwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2
  VydmljZVVkZiI6ICJNRDNQLUFMVEwtVDZJNC1VNkVSLU80WkQtNUFQNS1KNlNPIiw
  KICAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1BTkQtQktR
  My1YWEdZLUFZVFMtTDdWWC1PT0hXLUhUN1AiLAogICAgICAiUHVibGljUGFyYW1ld
  GVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcn
  YiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIllCZENzS19TeUI1cGdBa0p
  veGxLam1zWFM5Ylp0eU1TMVJWSlZFVExYUjFGN1dwMzBMODUKICBVODREWDdMZnNH
  UEtTM1lWOHRIX0ZkcUEifX19LAogICAgIkFkbWluaXN0cmF0b3JTaWduYXR1cmUiO
  iB7CiAgICAgICJVZGYiOiAiTUFKNS1IUUFGLVhYR0stVzZCVy1FR0gzLUVMTkgtRV
  E3SSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWN
  LZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAi
  UHVibGljIjogIldtRGxvSjdZQUw3RmVEWUlwalhXNWNGNXBKMnh3WVhEMnM3X1lCc
  0pyeXMxNUtlZFA0QzUKICB5NTh1TjBuM3VmYzB1T3l4NnZ0UnFvY0EifX19LAogIC
  AgIkNvbW1vbkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUFTTC01QjcyLTN
  LM0ItUEtRUi1NR0hQLUw1UVAtTVZPQSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJz
  IjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6I
  CJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAieXg3XzcyYzd0T0NSR1JtS1FRYT
  lqYTJ2OUhaRW5LdEZIb3dGekZlaEhKckhLelJyd3lhVgogIGYzV3Z1ZFpFNHh5Njg
  wdFJJb0Y3dTRhQSJ9fX0sCiAgICAiQ29tbW9uQXV0aGVudGljYXRpb24iOiB7CiAg
  ICAgICJVZGYiOiAiTUE3Ni1ESzRDLURaRkctQ0FWUC1ZQ1RVLVg2TzUtWlU1TSIsC
  iAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0
  RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWM
  iOiAiNTRTVWE4aWV1M0hFTlFwc2l1Z29KdGZBTHFCVUN4X0pjUE9ZSmFnWUdac0NB
  VkU5anU3NQogIDR6OFlXMkd6eWEtc1YtaGRhVWxTWHJNQSJ9fX0sCiAgICAiQ29tb
  W9uU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1EV1otMzZSRi02MjJWLVhUNl
  gtTzZLQi0zUzVKLTRKRTMiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgi
  LAogICAgICAgICAgIlB1YmxpYyI6ICJ4cnVBbnNoeWJSenhEaHctTWsydDBiUTQzY
  mtFajEzY0pGNnR3S2IzeC1qV3h1T2ZNb1JMCiAgLXhxcWh4NXA2WkdTLXc4SHROSX
  lKMTRBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V",
              "signature":"UZ3H_08-Gwwmbwdtw1SEc2L53FI6hOA_PrEdvY
  pj0veDQ6OjpTErbdMqD83kS2vQ3_9MEqkqQ5oAYOGkSlRGr-zEKIKaenLIDYHdV4C
  4R1IfDgQz4Ug42KXv2bO3i77IF6k-DRu9oOY1JPAkz3TRrRgA"}
            ],
          "PayloadDigest":"CM5-3VBGfeD3-hhKiiq8acCykvbJBFoGMPkdbk
  Liw4vuc-W4RlPOK_yLXDgCFLaVFkdSrKVXr7lpnWSYqgDDjw"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MAWL-JZU3-BV3H-JBT4-KPLE-OU4A-UNSY",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQVdMLUpaVTMt
  QlYzSC1KQlQ0LUtQTEUtT1U0QS1VTlNZIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDIyLTA1LTAzVDE2OjQ3OjUxWiJ9"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1
  cmUiOiB7CiAgICAgICJVZGYiOiAiTUFXTC1KWlUzLUJWM0gtSkJUNC1LUExFLU9VN
  EEtVU5TWSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdW
  JsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICA
  gICAiUHVibGljIjogIk9rYTY2RlpqMW4tRHJxMFZhcGNrM3AyMWI4ZTdGTHhSTkY2
  VDVnZjFuaG1ZU3N1YjJpdi0KICB5ek8zOFFYd2ZKVmNuSS1ETWwtMUpITUEifX19L
  AogICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUFQTC02N1FBLTVZWD
  MtWklURy1LRUc1LU1ENEUtQ081RyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjo
  gewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJY
  NDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiVkRHNWJGUTN4TVN3R01MWDN3dTlSQ
  lctTWFhS0dRNXZnUVd2aTNMNlpxRjhwLXA5LU12ZAogIHlxSHl4TmFqN2pKbDcyN0
  10cDE0THRhQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1
  DRTUtRFhRQS1PV0RRLUM1RkwtQU1EUS1SWFNCLU9LV0oiLAogICAgICAiUHVibGlj
  UGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgI
  CAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ3a2VSWUlyYW
  9VbktWWmlhQlU5QU9qVHhKXzRZVHBnd1NfOG85V3ZkYTYzcXVJdGYxZjVhCiAgWWt
  iZGFnYUs1OGdPTFlLc3gyM0EzMElBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6
  IHsKICAgICAgIlVkZiI6ICJNQ0szLTNIUVMtWklPQS1EQjVILURJWkctUVZDUy02S
  1VIIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0
  tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB
  1YmxpYyI6ICJGcjVPWkdfYlkzM0FLd0xTeFg5UGJxalNzdkQyMFl6aFE3bGx1Rjhf
  aG12MDlUbU51UFJHCiAgS3NZaV9fMkgwV2xZMjBtMWNzRDhvTDhBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAWL-JZU3-BV3H-JBT4-KPLE-OU4A-UNSY",
              "signature":"uQZhXm18RTy1-x1-KKq4jZ1J2H9MbteHoaEoVe
  0eMtgYQVZmgc2JPHaWA58IITf2O1p_ewbtXMqA44AX95FcNUHPcbrwTF-KWTgF1ER
  Kvh3o4TpI0oCn_TNIpTmPPmEUJc09zFVHPdubcEB1ewkhfCgA"}
            ],
          "PayloadDigest":"owxkrybmoxY5RI4okLHahlmgDBUTxf3ZFA90S9
  O9tVNoX4Th2DBW6yEDZKVvQIBPlu03COoT0x-bWUPfpQN6bg"}
        ],
      "EnvelopedConnectionService":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIyLTA1LTAzVDE2OjQ3OjUyWiJ9"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tA5BdXRoZW50aWNhdGlvbnu0A1Vk
  ZoAiTUE3Si1BU09VLUtPNTYtNjJGQS1JNEdFLUNJSDUtVlJSUbQQUHVibGljUGFyY
  W1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1YmxpY4g5bTiWtZ
  GFKKHpeFq5qtt59yZz45OcyAEYOxCL3pViLR4ATcX5FId1KoeRBG4edVa6ew0-jAd
  Cf0uAfX19tApQcm9maWxlVWRmgCJNQVJQLUhINkItRDJKVy1XTFE2LVJXUFEtMlNM
  Uy1BSTJWfX0",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAJ5-HQAF-XXGK-W6BW-EGH3-ELNH-EQ7I",
              "signature":"E2JhpL2lF9pMp-gCCNqgsi8fCdpwFLqM7vJupU
  kCwRb_jMgZyGafhUbfVQCZip0iy0mnhXL3XIqAw8R3EMCZugK4dIPO3QE8bRJOWhl
  pZZF-SGf6uq775RwgRNd1d40jVaDbRB8ifR2xC8Ne_u8_QiUA"}
            ],
          "PayloadDigest":"RqPIKOGrSqpPVqiEOcPvj4J2yCd85O1lo1xqzu
  wcmyE9XD1bsBx0i9bP8Mw2fEHeWevKLEgyXPBXHcYeYoE5PA"}
        ],
      "EnvelopedConnectionDevice":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjItMDUtMDNUMTY6NDc6NTJaIn0"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0DkF1dGhlbnRpY2F0aW9ue7QDVWRm
  gCJNQTdKLUFTT1UtS081Ni02MkZBLUk0R0UtQ0lINS1WUlJRtBBQdWJsaWNQYXJhb
  WV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibGljiDltOJa1kY
  Uooel4Wrmq23n3JnPjk5zIARg7EIvelWItHgBNxfkUh3Uqh5EEbh51Vrp7DT6MB0J
  _S4B9fX20ClByb2ZpbGVVZGaAIk1BUlAtSEg2Qi1EMkpXLVdMUTYtUldQUS0yU0xT
  LUFJMla0BVJvbGVzW4AJdGhyZXNob2xkXbQJU2lnbmF0dXJle7QDVWRmgCJNQkhCL
  UUzUFItNk5XRC1FT0JYLUJHMkgtTVRZTy1EN1hFtBBQdWJsaWNQYXJhbWV0ZXJze7
  QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0NDi0BlB1YmxpY4g5saBI0w4DVxptifp
  QksAK31jcJ17Kn3Kj-yLZwkQdHspusSO7Gs-mYvPrv5iDpXpTkzLUHomDe1KAfX19
  tApFbmNyeXB0aW9ue7QDVWRmgCJNQ0hTLUNWV0ItNFdZWi03SkRVLU5UNFYtSUhTT
  i1DQVc3tBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWD
  Q0OLQGUHVibGljiDnhz9uo72nCdLlWebdMvVFJkaKGXO50RuGb3p9YmE5m4pon1ee
  srQxCWzEGRsKvD9avCnDmYWNGj4B9fX19fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAJ5-HQAF-XXGK-W6BW-EGH3-ELNH-EQ7I",
              "signature":"fdVcQAWJJ2VQ1d4yjYMe-K0zfeNSj3D-FlKY9I
  3deMYx_0cB3Q9sVe6LSMwEP0wvEwUT1HRRZroA6VrgQKojR4Akr_UDoQpNh5mj4GJ
  YsTpp6MJW9-cjMDZ6_wA2ClsdCt5UJ2HuRkC0xuN2sdVvxwoA"}
            ],
          "PayloadDigest":"WJlae4r4TdzIs6Lp4GhqnINm8YXWLYEMuyIgIo
  qBrE0G368pX_33KcRC-xlzFN4imbU_0ELEOooebHmGSY4ypw"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQI-OXIU-IYLO-SOJT-NAEI-5KBW-YVYZ",
          "Salt":"StZL8SAWKXvMLCToRnZTig",
          "recipients":[{
              "kid":"MAPL-67QA-5YX3-ZITG-KEG5-MD4E-CO5G",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"ByUW3hEZYf5GCBzLHrYqguqr1gh5Y8_nb0nBH
  Um_3xQMxcdBDMYVLdkE39z6TwRqlGjdkoSHb0YA"}},
              "wmk":"qgBKOszKtQ3cwjuV1ZGdifdaWqMcSOpVz5JhGZFLbsp4
  15b4OVApgg"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIyLTA1LTAzVDE2OjQ3OjUyWiJ9"},
        "sPROIWNeMehtRJtesdv3xn1OTwa8CWmWFYtZX1QoUMXpt6NYo0scgH9i
  pAgAn4Y0LUZHapyw1f75_xHlejS3kerv4qmVaEU9gQKCyN4AUHNg8VtL45Fe_g2DR
  mkZgu_UvSeGANn6RS32biQSYW8LdRAzBl3dtvEqA2aBK-t8A27HAJBDadkeVfenUJ
  hnDpj1c6teZ0g3pUGQK-0ZtqECE9KF5EXoka2XebNNtWLPNkg0VXf_QL_ALkB77th
  fwDoq",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAJ5-HQAF-XXGK-W6BW-EGH3-ELNH-EQ7I",
              "signature":"bUbKPKnuepMAbbbveWNjiI4YslC7YLert-bOBR
  rtW8-x4WkeJyXZQbitQ1XOtSI5ech96EIzGicAzte1-XFgy6tMmsIZEot2AvoPytI
  W1J-ZrASIG_AKT8lNRWGMQnBhq87lRrsNQ564zi-uB3ODvBwA",
              "witness":"C-vlMPF7orQi7HVcEMGk8iQkn3BD8t-0gaee-iJI
  M9Y"}
            ],
          "PayloadDigest":"JbD_4cjb1VKj4gWwq_cnKD7LaZUwIAlwWbV9gi
  gL_4XKxcwXeI9TMhTPFi1YOEx73UmfK4Ooec72b281nYRaYw"}
        ],
      "EnvelopedActivationCommon":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQE-GVKP-CI6A-PGCB-U5YT-GB6E-SH4Z",
          "Salt":"0G2CYgDYclaiNlk5Nw3-8g",
          "recipients":[{
              "kid":"MCHS-CVWB-4WYZ-7JDU-NT4V-IHSN-CAW7",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"bdKmqv0Aum6b7HIbiK_luoWPxHdbclUM3nBdQ
  I9nbBSueXZZr0b6w9wNccr-Zt_mQ7DXKTvsUMuA"}},
              "wmk":"_PUVcrgcOeJpJHKoxGPAsZsXwnLao1DFOSSCCTtxVhBE
  OSfK35BMLg"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQ29tbW9uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjItMDUtMDNUMTY6NDc6NTJaIn0"},
        "DRdGxdFPKl7dpBgGkwe98KpUdeRdjdfohN5vRkPHNi6irtE_KkDi-xkS
  5AsS0hVNyIWZg-vnPHBWhB850rZ_WwUdO5kvufVjuI8fDYLlcO7y0NIX1Dqqc03u4
  MZCgmSBxhu7PxTEzHvmhAquipiIZNj538O0PVYSyDnqFW0ib9JCJQdqk2G6m4vfqy
  TrCpuVV8QtfmCL3H_mqHZwoUYWznfVf1pjwIppB6Oa_lKSGu6imfLNuxGaHpxzASb
  HLYiAzZON0LQvYwzz8WEAEOYwCLumGS8g0cNiGv7ww_DPPztHdIN9Rtvb1JE67zxg
  PPrcfdhMPc0ZYrV4YFwDmFoJ_zgqSL6n-SAOOFT1k-rzN6-dYr0rLpHQ2z-fCpg64
  15Fehp_I6oJx9815BULUMhQlGTXfaeS2v9odOx92-N0CjWkfADm1ROt6Cqu-JUiIv
  GP2mbOo-QOyhRQ2CbqCyRyk-vuE9iP1Av7ikZWT4-xvNsn4oudSX7Or9cDPyTCbnr
  buMVhF6-2qUALrsVtfYpa-IisLY7TxtanFY2njRo3EnXcVW2-rPLp4kEa34EUs9mM
  umBqAZUtHblDVIiulK0ABPP3bk1B7UgFhom9MzAtTa1feJtz6nWhTZRXP3VgPE8T-
  VJC95-Yt-zV5LBQjAyPV5G8SG3dDmvqvasXsvAwnobkvSlXsPNLeupPAkHy_YB6be
  XGu0579QyIm5TdLuoIW2pHj0ocPjEXZe6qTiI3dlsY81ljL9W_7bibl3vM10BDsNq
  JaQJKHbziUuJXU0RD5Uut6-oUWC-zRxdmagl2xxGyE_ydRqFIo_5-RM6aWiLIGauT
  iG1oEIhEE8xqqw1h3lRmfnL4H90EsXLvqdcmS21_zcHlGL-QN9TtQX1HHWccSE_we
  J1LLhjK-Egx_QFTNJrwieJuwjxEOC4KDymXA3z4yLSG-OFfhikd_TD9uQ4PEq4Clh
  yw_1Qqd6tYdzYccR7x5IwHAQenje8TWZKqyIhAvNUZ8_hunxFX0JrrimUVyhZaDUM
  3-hJwwnYgvEq2_uNoWg_zVc6GEz9fJ7M5a431Xmscpj_JSWZwIuixCNn8nq3ydIlg
  CwIb55Gz7mHOz2s9dEIDET1THu-ZeQi-HKVkoXrhB25nu9FQnIVPxxvrCvR-vmxln
  ZXOJM9beRoS9N0RKLl9Ex4aPcVs3AQpNhsJHPdsIiM4QdGnZlgpIwaaW8xNjp5JMq
  Tv5PBNoZqu8l_go1cWM94QAvHwJJlVAvBHta-detDL9sgDFMW0UNG0erXXfx16f5F
  J0XQ0qwppUv6Rged9PrAy5rDGWLyt9rVbcFNhgVkfW7Gdr2Sqr2mSeCHg4KX-R9k7
  JQPh_iswKuGfG8B4pZ9YOCbLLx-h-8P4Gs71O4jW5kLvdqVA5qqb3v7jgsfgO6jqm
  8nJhsWxi-Z_k_d03XoLx6fy25IxjSQzksDEw2bUlPk0McX2JrnTX9vtvzxEqcnJS8
  OanlAadmHuMGopOiW0YwwsMNTvcI4Fq6GQ_DpvoSmp86v-smiYHSXZ5b3pT0wXpFT
  xWiuunF97uugNYSq7AfVcL8aYB6fPHI6_UGNEsOV2FyLtZIj5pBpG80GvXs9ShVMC
  2t2buhXgDhfO0o6O0heI1KBIURAM6GgMnG7ApCpyv6jevfWVFbCay6hjBl57BYhjI
  2f9sT3Pr6fiJhJgu8Mzxns-l7Cy7u8hodIgsDjd75kDZ6TAn3AZyovCyO5MO1Pjsi
  DFxam5Db84qFU8S9omh1xeYohLsPkyZ9-cFKSCMpbKRM7wHK3klJu4ZwabzsbGFV5
  _vaQBej4n95cq1rKwH7qfOZZ1eflMdKPT50fQMhQMJ1vEMLl5sq73ruXl_SFFAzzv
  jsKrZRZ-sthESKgTV_OInjxYfdV4kIn-p4GWF2M_b8kixj010cvZJpZFpja_8jVLO
  xbtFt2hCmDFVol-nGlwdymYxwz2QWXdIhmKL7Qpih2Ktw6eimX6qSf_ph791y5LBk
  pp6YHZmAI4TS091KzLN1g1IOBTF4JjELSsndRUT7mqFrwulHtMGcqEDdPbhkAbxy9
  OHtJJhP9XS4y_OqkZVDEg-8E5DmxHbjTTuOkgNvgjMmDV7dVUjdF2hKeGE8kzjLox
  cXXDBUqXDZc9RwBOAuptKD8MCYh0XuGW6KyNy_AAEUsQ7xagUVtaIAM37idLwshwt
  5KiUriEmxe3b-uNM4M9V2MSV5SAjz81vISqulLpql3n9V62wUtGAz6Vph8LFJduqy
  PDBDVAZfqGCgZd6KAX_ygy0t1tXmoDu7Rf6RpDKuWnweqAGajuQY6NxIzGrmaHRaG
  Zk0rcJrdaGPUsFaxxVqPvdWbaLoTuFTzBA4n_QEc7oG3sYu8jYp52QS0lUsz9Ky0b
  3vQjtdlkG-1MZ-gjXaL01mFf3hMSNTtFMnYYkUmijEXqsOsWMzwbY8U1fOzIcEdnK
  aQkk3OxLUgw2eHh0MMd177Wkx3se6G-KMfkR8uNTKs9pt_Q1XQiHZ16gBtJWTRx3V
  LuvKqXSXsERklyfFmEXCg6BEsZGZ2qg8_YcJIcBQHn0zzgz3AyFD3_XqW98EQ2O_i
  dZ-fwJs2zG1S3AcIiPaGCUGzUD9NIdcNjhtjShgYLRCqapwh-5PYSrjbC53n7NM8i
  Igakf5M2WKOMThthOmlfMhyl-7ZxcVPIG1fRtVug8_2oovrSKqIdqd1WyvNjBOdXh
  12dJBuAvL5xkkHYz5N-hHLfxuckm5obeNlkK19NReBLudiXCSunHlhPI0nFyQHJ2F
  IUqbFhoiI2IXS8XILcAjzJGXrM6G7wq1PAJh0oYgbyMxUPUTFq2qFQNqu-CMhGIPl
  Geg8rnoYclP81IFjeHwLkot4J1lMNrHu0ktPEqWqmWX8p0Tg5WTwVKDkWA6qktuwf
  nWHvQUrww2pdYqFeoKQc9PxlngykJh-pIYwvaAqE3gc91o1D5x3qi7aOfIwBdxRO7
  l-43t93wQzTvX9qPMDGP0t6-N31Sw1X-B5pv7MEuKgroXMVAyMYGbVmIsbc7rj73S
  HUjdavuUIMpLuiMYJ-V_152rdbWEX7W7hp4Yt4K6YPgftylLhCHDkZF73-BqiJPXR
  H90uzachLFn1oE-rhSaOvM-MHbvbWe4JU_7gSuC9ZpMRUCGXX8JgF6m0g5YCXcqOf
  w79_CbpIz6WCS_9fPTwNSDhr5egCra_n-Qb_KwJQWfwV2i2Qd07Vgg0aeFszu8Slz
  l1zlXI9RdtbTNB1p1HFrBlXturWqRuN4IBKfEqT7yLyOwWDqkMgtOsSxJRltUNzJF
  fEXSTt5FAA_DSUVTqPo5eK22vw7bHZNY-dKqWZaD2GzHFfdowFZRienOjZ-MfGyf4
  GpKNs-kn95aM6Z1dWBWL3eBo0ZX3rJCNEl6L8sj0UB8IcvRvMaHTS9lkeVJQrGVHo
  wsz_ZhvWx835-qdOCVBPYGbLVYSWnMsP8rCgnNYqKAaRkOeGuRNCD2A6sMmFE0qTI
  KPY_A1wyvvEQ-WxVK8WvQfWtJ1KHDi-gNAXvo1bnOqtxVzQNH63Wx_ZfooSeT6Eo6
  AzP2rlN2IIgPEBPPqseF-rVYq8-Rh0rBlmc0HdoxGKBaNtTnufcYgbDwkqlSMtHEd
  j1_No9mZCtKvVDsE1H5din6yT2o-QuNzq3x_vNZrHA25HuCziYj-XT-VHVlh9pXQg
  6c5jjPbKoJIIzV87XPirbKLMNtEKgO9XYV3gigPq3nuk-5txzGbz6NQmJFEenhEqA
  eeCXEXuPUERF_fzF130CMrkAvz-z35Xwg65C2mvjuIcSCJ3TJtdJWSABijAPyrcKQ
  SkNL9O6w10gx8uLUJw2dcKzZGLDrGVQ5yGH4zkcOzXhPlGmNZF-BDZqGDZlJzPO4l
  JGwvnToRs-BmZtQ2AYWCJUmCud9tknUUXmwzFcLg9B6B_i9evTbMbCh2ETSyuBsMb
  o0Y4XtabqxrUc8LtaXAxbXgIlJYDNQPW2KVnZED_dZdh5C-xleCZiBKWyy8BxTUWp
  5bariNUhQnkNChBF7s6ml92J3FqfZ9fnmFyFyPcJ9UJsL6oZdYNgv9YEdhLbcBUx0
  uvE0PUZqP_Rzs1FfNU7ekeEU6ae-SN2O433ejowHNvfYSFyUQtMEcdB5T6qmlrHQt
  W3mD4D8QJ34kV-hz_MB4OowhEo6q08muUCFkIRPG5o0jISaRZAabJum5znMBqidN9
  O4tUfMKFp-kLZfV1tkO5nW6ve2jqnAXgNlkrGrS9kRRbqIJqCteuAldrFa-Ege4oO
  ECoxulMxt7KsxePK3lSkdTwkVZtFgs1LrqlGw3gaDCMeSoLJo7mVReYO3DRNNlgo8
  ecM9anlU-UsRaj93tJKZKA6ZpZfnqLh70_3qKC5SKOqL6DWsXcEJhadh76mWKiGnY
  gry0Eqtkt7zSjyM-qITN41crnC8dSZUg866yLTe9YlZK4UHgSJw8P_rvnHm7XwQVW
  HSuFbrCUM0-heC5xUQPEg3kJzBZ9Opf5OeJjUsS6wuI63s0F6cyOpBrYRF89wQKIn
  6PEARaex2JMwYYNN9CsCQlxNdLDhjYalR0HbUI2-5rOMdHnPGg1vYy_8h4mGnCAi4
  luPXFKj7bA81rnY5VQslAa4xgmI9HVFV8HLCacr40g2zgz8ttlTAO4iy3l_O0BWoY
  CXhA7fIuoTWb2ycGfqPvBoiHGKIUeio0imw6_kgKTaMDUS8IhEHVWcE_eGXjS-ImT
  BzCWv1tOfVxmfW7UImSf5gRKD-TKcng1OzLy2_n3e-08NksP3F1eb5b8olTKWu9H4
  VzJ-hoJKGvhsjWH1LmNsdkCMeMq99JoqJ9D2Ovfjr0f_CgIJuWu1ZIDR_GHY4zrdR
  oVUpZXcWicDqCYae5nU42Bt5tXWp04puPZcIBnshe8X2SfI01gH8LuPi389e1rPWm
  NbL8Lc3sKbbTAzQc9dYY6nQUsNLfN30OpPSnarQcpTeTgSeg-55161f7tus2IjpDs
  xeMaFIPVfw-rxuhJSEUmtf4TpQFAjRpyAX2R5p6M8l2kNEoO6fEMu-SjouOQwQnZh
  GnqwKy8cs_E3QUxvwWK4xWa7-IdMYqT5OEQCmp7UK65yUoxGHjVMu6VPs3-dyKTTE
  O-rpgGpksqiccgA9QedYC6O7dR84DTPfOkaQtMU9aw-2UDrFcLnCkBW-YVq7lFxNj
  XF4Ki9dTvdCUMxZAQcawTyCWlPQGjthddn4q1w8F2WTYlYLXn5q1gkxgFomGpa3Hs
  NX2fGyJH7-uKVDXsfBMqjOUjdTG2W5TI1lwvZGqxld6W00MpneOQ7J7FAO5moTzFh
  AkmnCgNZjH0FapxYNW0O-JJ6XHKToczPCBdaLLirmVeG5neyxIQWAyNjr8OKQaHrE
  WGywEyTA99YgFqdUdKf2NQb3zNznJ7E3w1ocrSYG785imWrtrZ-SZhalbu5GYmVVx
  JdIk4WrvEiRCNX8kooKYf3EYTbUw8jr-jRjn22-2X5xu4hJ2XPhu9wPPPflElhMWv
  ZsKOtbEJc6hM37H7_GJb1hmzTRyxpXBKopcnqeecWwnV7MWWg2aSfYxUrPPlXyRo2
  WKc1RGfG2elOmDD7T2OeOMHJyFpKJKmHNqZMR_GRXUdHRqAkwFOjNm_klLE4D7-fv
  anSOGbpJqvJ9sdx2grPe5DiihJHzT3ydceKIbKGyRgpHDVjzJ3aZgJuI8iCv1kgHt
  lppAHiMbNHDJRSsBsy6wk4bWevukfmGoLCRp186gSisvI1NNisfRclfGe0OA5vbcl
  EvSwUC3jQu6AJ_j-QFTIrgdSbHF-nE4auFZ5Y5IGNSSKzY3gG1sunuZInldENINao
  qiWc9ST0eWFlzeCIfP_rfhU1EoK5SBK_hmHGk7yiQusqOZUCUnZdvH5T5Rrjg66NO
  fhGg-xp-uv9VroQUT3uFOPIaLOItx8gLUsuI5NYswWoRVKNVgTuHQteqsj2jWU0BI
  k8GanZEOyHcZbMZMCIIAXOFFqKXzsppj32Io_c82NH2yH-kAnsY_KJfZ_Ce4Xnxnv
  eQL-ea-l6-gDq-sKPr1g-jTDUMVi7-8G2plkXUK0zTYrcNDJD88hYcwucAFcoLtf9
  Rx-0HBdHKvlfPb_IycPOJLQjiW3LAmOFsQALOohARDLhuiedehq_Y3WF9qI-w0exi
  6ikT1Yhsg2Z20ZBpeQPBmLABDx_jIZwIgIgQnaZL-2QqjUss3g9dqIbiWAbmdwBT2
  9Qxq8oihkOl7Mr-WtsO8cGUGD9iaxgpG_wGNuZB8VERA-vEOeab2ACdXckeuyq9uR
  2U1Qae1I0-U774zwScGC_5bisIdlLqB9gmzKKIZlicAkBbgaylRvcw4L_ctCMQGUO
  RkKBp2Vw4zkIZNmPmahw-3Ui0Iuq0bbOzVhB05XG1hm7DGWZRCGmI924FcgR4GO-M
  qaOb2A_EN0C05I0vfvm6CbLPJOHGoOM70wNg2RduHK5PUETa0iaSRs6oA4S6_8wRK
  Af7dgjYszw-O85xmpVdDCxNOOnKqvFZKw2-wUEVBE_DecgmzJz5fCbhG6J2XkUsK5
  lqbcjJA_PYBP-b2qO3fSlHJRevRuokbsBA431ONFDCZWRI7PBiel4-h02wQ1IcNZB
  ICfputNC0u51dT2gQWkEgsOaekILmKZg02784MQqS3B1ndfErDCtqaD445id8Vv-o
  x2UNGrnxWjHOAaEetAnghwMiNzk8lmA4D4WIdeSlZMqy2rtJhPVRE6t7iJd6mUdYX
  KIcncwi2s9EVYozHORIRskqSFSmn-r4ojm-JwWrFn6fwm73d7Il4zKx74ayui7AQv
  8SRGdGXLD7uc4O0gYXkbG79nzIMXRJkewGJvKY4DBEnL_FP73Tn5u4jb_IsFk41Xl
  VY_EktfRlVtPM6w2B-m8GPPL_r_ZdR6orlzE2tZ8561ZIgSTsRcSjfG5fxePSGkTk
  Zdq8GBEEvzNzNxvg6kMrUH073TgaNdSbnVvQ7TxT2xecSbHB9yJvrAECjW_GkPX8q
  8lVYyfMJ17LhxGUQ_8WIkEfRhxTFQF4AJcqtny0mYRB9F3OCvsXgfEJQ2g7vDr46k
  kvxgk3t_7ezX8hh2JIT4j3dSP9A1vvjSmpf6EiDLnyYNKqBR1Z_ZLxSe_NWf12kPG
  NtXJItJexpZlFJO02wRk0suxAj9eFBT7vkb5vOfHX6JHtyddFQbc4JEYURjS9z2mY
  qwbjEQ3-RXDvFwRz0LxBsnVA29cKjzpCiP0FzpY856Y8HAnLcya08BMCHQNO4geyU
  Onl3BxDlSWeHjRzf_7TfG_DBzP3fgIHiblyaSd1fOX1_jrbQSh3kCtMOnMfzhlp-h
  EJeoI-CB9EBG0LgK7-H2QpWLppW63Q2fUVTaavsuyRT3pG7O1BNjVZLINppfvfCDi
  DrNLRCZzjAMbJRwDxcZKWVQkFWevcwhOJdKbjqd7QpaTpmGSJIonRzMNxpDiuwqFL
  ZInQo7rRN2WQ_sAHQNSgW0JHQivr4cmEqtLj281XR1tBjTbgBY_DqHRzPZMaQiwFn
  FuzXzOwnlneF9duEw-pwhWMM3Mf1psu3dcvc52yvt8TionZ-vu0hEACm8_zqIh8HQ
  ejx77XXHfMvEgShKevrjSLL0CU32VIWaapugsFEux7Zgci9hm0eLmFgP48JGWoR9h
  P_K5b_CcYYTGq5YBQ6ZOhzFuX8zaxQSF_VA9CCtICnsDpY3tTgMlSFOf7HDeNJoTb
  K-3VTSBYPRXHtOF7hZhl2JvMxHuj1zTrh_tCKW-DYCW5CZAmPOugZZn4vbHGaZCAr
  4sNgkeKysXWPVXwVjRYjd3mU763ay58kIQJ1J5s_pzwzQ0T1q-D6_GHcRYVT10G8q
  -j_BOcSa3kpCNeaGqWfeSH2MRr9v7Oy3_MFAbO0jHSopfL3GawnCbg7JuIs0Q8v9A
  F863o7_YkvAo1mWWyttoMbYBuJh4sP-qnUQo9AlizDBPELdjKfoOxT1d_jlYic4Y3
  l-3XzRs5dZOMnk81oSS-hvBMDc1ZXwDTiEZxnW0Z2ATj7wnxsXR11Ft-LiO7rIQdX
  m-f7ock89VkV9kHCbWc0OGU0cQkKjif7QIeZJd8UbcVJGcF6gnTjbpxYpaTTd7MTn
  rHaW4b-GEx-6nW39IrHG3jEd-Q8cJGfBPsOwQdWiHo_GKDRrAZ5LFKm45UN-lBF_p
  sccJlwmb3KnwYJekH_QQZefmo7EtF-9EIhOKr8ftXrJJ6A7afQp2_SKOyDe_PG-9v
  2gRMN9jH9jEqI3U_YJUL6V_VbogxRUauyORvlU8yfRoZ5cCmfads_KmfLFJweRoa6
  VlMEBpbgBt7jbOlSjKwyJBhdJTxcu-lPymJWEUJSl4ZlxyaXvnVdgd1e-YcWw3IES
  XFKGsjV9N8Gb_8BoOzB2lUqvLoiPlHrip7_bPcChCUJpW60HsiPeFLxzAMpnjF86U
  i_9w1u4q6h3LEvUVZN0dfC-YO25ibDhXcwqQ4vEQqKq17J1p1FXhJzjkBXA-Qss4J
  jgKwRVMayk-HPO42TAZW9Xqv-xdXDe3glxWInkLEfFS4EXMzNs0Uhqm5ruf7S90-n
  ript3yL72UXXD7GGrE_rTcBwW0w",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAJ5-HQAF-XXGK-W6BW-EGH3-ELNH-EQ7I",
              "signature":"57Q1mmxqyXPHSR1B2gNTLZGI9N8Or87ocE5k0g
  VdACLl4EJOfhWXtDm3nsaghYMuS0hW385nSqsAV_RlMywFaDtRrm6AxVN8BFM3l74
  oM5Kpyz9fZ1nW2oieVtewx61_ATbTPl5RxRgnBVatgWzeLD4A",
              "witness":"KbI27C4fuz2EY6fePrbZuOzx_FJR3pS4TZ6bR1m9
  N7w"}
            ],
          "PayloadDigest":"Feo74r1M3hVZJW5JV6sIO-eZDUC5u4yB8LgknI
  _jV7acjtZpLY5CtrAhsIk2S-syXQ6blcz7QNHlPuw_3xc3SA"}
        ],
      "ApplicationEntries":[{
          "ApplicationEntrySsh":{
            "Identifier":"MDV7-NN5K-SHF5-T3XS-EL5J-WXEO-YJPJ",
            "EnvelopedActivation":[{
                "enc":"A256CBC",
                "kid":"EBQI-YU3S-JOPJ-VHNT-BQJE-AVU3-GRVT",
                "Salt":"Auaiz5jzG20dmqooyV99EA",
                "recipients":[{
                    "kid":"MCHS-CVWB-4WYZ-7JDU-NT4V-IHSN-CAW7",
                    "epk":{
                      "PublicKeyECDH":{
                        "crv":"X448",
                        "Public":"rlr1-f9hPs8DPAPcFbH3Yht_VcB-iix
  XGj2fDc2iaU2Q8dZT4MDo21VZskL6HUzmRteQ-HRLkNeA"}},
                    "wmk":"N8lq1Ec6E5rYRHdnS-TAeoRXMp4IrVWKxZrdTv
  wkPbgJ-E2enLFwJQ"}
                  ],
                "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3
  RpdmF0aW9uQXBwbGljYXRpb25Tc2giLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1
  tL29iamVjdCIsCiAgIkNyZWF0ZWQiOiAiMjAyMi0wNS0wM1QxNjo0Nzo1MloifQ"},
              "TUxjIjKUIkM0sUN1E-1a-Q_LUxFSWwfXb_5lt3KuoGd1vrLqA1
  NP6t-xTHb9PzhvFQCyA3jjybeXx1PVFKe9fFTWqLJaLfF2oN1Hi1LSC_i5sVh3CJm
  t19YKJN-EfrG1vn1fwblwctsxlrLt428dPkjgQuVejWN34NpY5rM2co4OnWsU8iID
  Q3Lf6HWQOy9Wg_06XLyZbW-CVhjLiUjbbxiS1yHkyhTdyTakbhCHlQHduBL8UtwLH
  rgeNUllEC6ZZv7XWgVRQsrsDxFosiq21nboycZEoSysv2vbbGXjnUdSGauiS0iNrW
  Qbi7tNl2SSxfGeYJmICSz4xOKFPIclIIFHH9DgPGqXXeA46jyKT8XP2Mb4PlR4BzD
  8LCNqShXwYRy0W-F70zCRtxrev5xH7pWbCJfP9dIdx6QfglcmQQ9XTkLQiJF0DBMx
  8act1hES0Mji8MU3eb0fI5CNhW2_G_XzbFzDQqI_YLjfQZmz5UcYwp0KU0bUrs5wN
  GJxC2RcJO7lYBY-26evShdA7zcA9qDvI2z16GRD0AtAZY04z44sJuQYR7g5ddyar9
  pQhGtOPiebIly3Xpz4HwAC06LXdnhzUSPpJx9aqoSRLSKHSG4RighozLEkcVxrFds
  1Boc0l2cNzjdCoDvx-_26ENW_BtWZSDqrJIUeX3e-Kfi5UHmSe18ez8RvztpzwQeH
  yJvDGNv06-pxPY8pISu9X7ntB8Q6w7cjd1gve25fJ08lhjHN2HtT5Z5v8CGaVK0GT
  DNLzNu1fYomFQfNEkR-_GEnf1Z4qH6_Xie75Mr-2c4UuXP60VMifWOjOYNF5d1-MM
  RgtpMqCftC0_MvkepfjX6IAnROyIbLpjb7JUievhjXvHKoaO5FmEc2LKxtpCEYn-l
  Sl9axAjXhXm9DtqeIdXoU3tZZRha_BwO9T96kd2IEdpjwe6h8lbLAlTFMZJc7oGQU
  22ZKQQUZXo3s1yZwNjPfdDBlixe_fZGzfO0n3XqAZfA5Tl8lM2S7njeI8YFXMfKdZ
  tQc_QmJ63Eb2pNsKAygYfEYJYqs2GL3USuB1eI2LRcYveHpxuxntk4f8j__o8XDrg
  aCcYbr9QexFqjUSynjtFqDmT26YvQ71BvWoPg-gVge7DjTmkA7qh3jVH9YbB24VUd
  HcrYT8T-R1zaIyg1QgxY0GSG9AWXiCYd992hyK3kfrYSlfdcUUTPCF_joPiJvYWmy
  tc9nVZZxLJcYpAW1tho_jHKbxYxGDsbliqZK2g9TtX79PfNGDLOAXnx8Dat0M4bky
  XpMqvUA2vgqfSVjE2Cjt2wsC0I_AmlYTNwP2WGd5gZNPH5tKm741W3Tjq-GPOWf-F
  qIHUxdaK8o8isO5uD7iKPpqZDuJX7fuUIS49vEUcmw-l6aLIRdYCNQHaxyobRJ1UN
  4Uy8vUkrq6opHX07e-osufFcNc8YbL1360OcSO3eF585iJfEe4iHac9eSthM5B7ys
  82nWt-WgHkCOWo-0CgK3t4i0jP6DqsngZuioWoNsFW3015JfVTjT3IRhiHv6gVmL-
  r8G3HNE_eJcRPi-9dB6MBajrJWz2zL4-ZS7b8vEJLSdIVlGk2vwyYQqRZsvPUCXXH
  IzojzcwL0zVEmqTuvKypPxG-FQr-vgSS9CmQEuCPq_SCCCgiG37SVT18WNj6jmGkw
  yqmyzSHsJ0P1UZ6OcLsfwW8-EDkUzQKtr0bZVE18ZsDGjjlvswe9um6NgyJPGJz_i
  IIt-Sk-6s1-MQBUBuFfGKGiPWoCWgSP9_zDot3Ry-NFIbOi6rZDIMHH36sJT6PHn1
  6UWnXaFEcJf4BRQCxAXvA-2pDSkyPQF_YavLQF6h-j4NVIAg7ITWo7d7wtibE4tEs
  g-2eKvc8DdskNJw1CeQxcKDvmpzTv560EBdigfr6NTxqUHigRGo-oAyjDH3lcpj2r
  7r0t2IaCGDQ_W1W8TGfxKWC_HZe1Mk_b9H6oWsnG1CHURl_zGIIYBtLtvueaJ_QR-
  1QIZDNKgU7rOo-TkPnijZexXS5YqVh0Z-NRMeOlPTqlxgghs-EAMVlzH3r7DQXn08
  e0RqcOe7bP73pb9OiANkz0AjT7EF3OX39cfJCKVS6YpiIcfTGN03Mkair1lsp8jFU
  877OtAha70oeyAld7FKHNYpOhxrF5tkFCsQ_GbIJ6N11H0T2N66OMPdFwIttswvZS
  vjV6A_U9yGG0MNULy4OUrvmly34GMD9RQ7EoseLis355QHJlkn8aGyNFCAr0Vh9Zc
  4DKEGlve5EARAGZrmZ4uEFtS2uRB44gdwUoqP3pWmp8nIElI_L5Uo6Vhrt6J5So44
  mb2L4FxtISe3Pm5lDIIG-2wknpLYRKywNCnq3kUDnl09Kcq2-3Ev5rkhIyntnCcSw
  uiGeKE0rh2xQBgsJ1FzsSfoBxiKiCMyAtwgSRSSuEoPQBqcUBrbsj5SEagZFNWZ3c
  i7IXECByqselL1Dbt9fWczW_LUHCC9hWPbdUYmArQe_LWy7Y4Lz-b6CQN0A2HDQoO
  wq1bRo5cnRsjpr8zVl-Io_NaLNdhU2SdNt3pd-h6daon-BB8WEUm9Um1otX1-2iW6
  9EsmT24fcnFyAYmqwFhy4qWl8pFcsvvCfrPY1Tw-uWYko_4ZwMdH2h2qmmOHCIc7V
  jPOFKYJRE3iRLoLc2MmoiE3j34NhK7ylLuErpSwUt8vwAtGwFzVNmZU_WC0ctJp8-
  bqBzFsNDClxHp-NHqdTYSsMHuyoHe-3I09COkPJCKddNw-M8CT7EE5qgL6q4kIlKI
  14qsly2FBijzH4U7WA5hjwf-gr22XNkq1WIUKfoByrsgH9xgqAVR5wdANljHrt1aO
  -ff1Owisk5nyh0HjtB0v_CbpzwaX5u5n-2b-qpLmFN0YYQDnCPXvZ-VHrp1Uf2Ei7
  j_YMOL4O_7EaoAd76d3oZvPuJ0CjIOYK6HxlR1cUHAvTHGHTejtHzMtbZaScC-jrE
  8X0sO9XwxQ0XOd7_jJtUuEWJ6-mCfySqdPXQXFZj99vlJXKPxEw3ZhDjwsSHGD8hy
  KKeMnNZk_W41h74vafS-YseZfiY4bJNnG6KGxZQawU7MRGqxANy2WQmSS7JiGQ8j0
  uizPkn4srVIGWmCtPAJ5cLk0XLgPrkoOY6JC_aZifhQvEpwO-YsJBXwPgRFm8VuDe
  qxCFPPrGU2QjNPIVgBU8jNKFKeIQdFx6CIz-UJ3d8JWeRdvWeJT_QCR0hIeHbgiaR
  RO6585tMGABpDR5jOa6ibqExKOnqjSjGq1uaGqvKl8cKDSSTN7xlFYrLNmip-0OFP
  f6usFaHx_Az5HVWC3TqZwPWjvEOW"
              ]}}
        ]}}}
~~~~

### Phase 4

The device periodically polls for completion of the connection request using the
Complete transaction.

To provide a final check on the process, the command line tool presents the UDF of 
the account profile to which the device has connected if successful:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MAWL-JZU3-BV3H-JBT4-KPLE-OU4A-UNSY
   Account = alice@example.com
   Account UDF = MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
<cmd>Alice3> meshman account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MBVK-ZODF-LLR2-AHO6-FWDB-NVNJ-GXIC"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

