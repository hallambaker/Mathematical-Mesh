
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> account pin /threshold
<rsp>PIN=ADCA-JUQP-AWFS-SDGL-6EUP-DCK6-HY
 (Expires=2021-09-22T00:58:53Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcu://alice@example.com/ADCA-JUQP-AWFS-SDGL-6EUP-DCK6-HY
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin ^
    ADCA-JUQP-AWFS-SDGL-6EUP-DCK6-HY
<rsp>   Device UDF = MATO-OK36-H76J-GLYM-QRPL-FXSV-CR32
   Witness value = IOJY-DGBZ-AEXG-IATI-6MQO-5U5W-QTWJ
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "MessageId":"ND4N-KELY-LPBU-Y75C-TWQF-PZNS-GCBJ",
    "AuthenticatedData":[{
        "EnvelopeId":"MATO-OK36-H76J-GLYM-QRPL-FXSV-CR32",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQVRPLU9LMzYtSD
  c2Si1HTFlNLVFSUEwtRlhTVi1DUjMyIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTA5LTIxVDAwOjU4OjUzWiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUFUTy1PSzM2LUg3NkotR0xZTS1RUlBMLUZYU1Y
  tQ1IzMiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogImdrTWE3WjhNaFJFbTA5YmxDaGxsMG52bFRDWTFBczRZSzFUWX
  JmUUo0U24ydW9TM29KbmQKICB6RmVfOVROYmxSS0ZxTkJYRXdoTHpjNEEifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTURUWC1GUUhaLTROVDUt
  V1pTSi1PTUlJLTVESEotSElYUSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiQk9lemNJeWxvTjl0SVR4aWZ0S1dDdGU
  1UUNzOU5VSG55RWEwVFFsTVJZM194X0cya3hKVgogIDRoSExpbG9TTnRiVmFQbGU4
  ekd6M0FRQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DR
  FYtNEhHRi00VVlVLUs1V1UtMllBUC0zTkJRLVkyVDUiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJCbVVQUXpSZmRq
  ZFhmVkFCRU5uZW9jaHNHM2dyeTJfampsSk0wS0JyYXlQV1dRaVhjYlF4CiAgbUtWb
  09aMU1RX1NxXzduelc5T2ZscFNBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQkNZLUZGTk8tVk1GRi00NEg3LVlXWU8tTTZVRC1USFd
  UIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICIxaUlIN1ozUi1tSXpxejkyQUs4OGNWVHpzU2Q3LThBeVMxVkRIZjhlZ0
  thSkUwekY1SDF0CiAgMlV3aGktdTRlVFhrZ2QyaldhaVVuWlFBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MATO-OK36-H76J-GLYM-QRPL-FXSV-CR32",
            "signature":"H1iBaJ1fYiP6oaUFp5pBAWZAyNNJhNLggFzR47JL
  RhkMOA81EvmnPoIzT-IXdQnJFktyq0Ctti4A9-fdonpzMAFf5fBj_kAfZqHga84Bp
  GvrP9aBuDboY6xdK6pUORYAzSEosVlnwn50X-QmBTOfhRIA"}
          ],
        "PayloadDigest":"mE8ORK1ar67XZ4OcNrioKJXlJ_sWadyHTY51teww
  tn4_px1vHL5pKd0DBg4oTpHNq-oln5tniB_1GbQW0GqVuw"}
      ],
    "ClientNonce":"Ex-4Ga3svWWnbh94NIlncg",
    "PinId":"AAVE-RXUN-6AYB-FMU3-3BZA-VFVP-SARG",
    "PinWitness":"GQTjbySNcOZrrW5GeMIegWMpFzpFPyq4ByXbBzB1CFJEXL5
  G-ycdb6qtYCeL64p73rQQZUmdC1zT5UrYWKpEEQ",
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
    "MessageId":"IOJY-DGBZ-AEXG-IATI-6MQO-5U5W-QTWJ",
    "EnvelopedRequestConnection":[{
        "EnvelopeId":"MD4O-25DD-5GR7-ONJW-XHI6-VK7C-LXDR",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORDROLUtFTFktTF
  BCVS1ZNzVDLVRXUUYtUFpOUy1HQ0JKIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyMS0wOS0yMVQwMDo1ODo1M1oifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJNZXNzYWdlSWQiOi
  AiTkQ0Ti1LRUxZLUxQQlUtWTc1Qy1UV1FGLVBaTlMtR0NCSiIsCiAgICAiQXV0aGV
  udGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1BVE8tT0sz
  Ni1INzZKLUdMWU0tUVJQTC1GWFNWLUNSMzIiLAogICAgICAgICJkaWciOiAiUzUxM
  iIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI6ICJld29nSUNKVmJtbHhkV1ZKWk
  NJNklDSk5RVlJQTFU5TE16WXRTRGMyU2kxCiAgSFRGbE5MVkZTVUV3dFJsaFRWaTF
  EVWpNeUlpd0tJQ0FpVFdWemMyRm5aVlI1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxk
  bWxqWlNJc0NpQWdJbU4wZVNJNklDSmhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV
  04wSWl3S0lDQQogIGlRM0psWVhSbFpDSTZJQ0l5TURJeExUQTVMVEl4VkRBd09qVT
  RPalV6V2lKOSJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V
  3b2dJQ0FnSWxCeWIyWgogIHBiR1ZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNK
  VlpHWWlPaUFpVFVGVVR5MVBTek0yTFVnM05rb3RSCiAgMHhaVFMxUlVsQk1MVVpZV
  TFZdFExSXpNaUlzQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KIC
  BnZXdvZ0lDQWdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0F
  nSUNBZ0ltTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmli
  R2xqSWpvZ0ltZHJUV0UzV2poTmFGSkZiVEE1WW14CiAgRGFHeHNNRzUyYkZSRFdUR
  kJjelJaU3pGVVdYSm1VVW8wVTI0eWRXOVRNMjlLYm1RS0lDQjZSbVZmT1ZST1kKIC
  BteFNTMFp4VGtKWVJYZG9USHBqTkVFaWZYMTlMQW9nSUNBZ0lrVnVZM0o1Y0hScGI
  yNGlPaUI3Q2lBZ0lDQQogIGdJQ0pWWkdZaU9pQWlUVVJVV0MxR1VVaGFMVFJPVkRV
  dFYxcFRTaTFQVFVsSkxUVkVTRW90U0VsWVVTSXNDCiAgaUFnSUNBZ0lDSlFkV0pzY
  VdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGwKIC
  BGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0F
  nSUNBZ0lDQWdJQ0pRZAogIFdKc2FXTWlPaUFpUWs5bGVtTkplV3h2VGpsMFNWUjRh
  V1owUzFkRGRHVTFVVU56T1U1VlNHNTVSV0V3VkZGCiAgc1RWSlpNMTk0WDBjeWEza
  EtWZ29nSURSb1NFeHBiRzlUVG5SaVZtRlFiR1U0ZWtkNk0wRlJRU0o5Zlgwc0MKIC
  BpQWdJQ0FpVTJsbmJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxRFJ
  GWXRORWhIUmkwMFZWbAogIFZMVXMxVjFVdE1sbEJVQzB6VGtKUkxWa3lWRFVpTEFv
  Z0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljCiAgeUk2SUhzS0lDQWdJQ0FnS
  UNBaVVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjblkKIC
  BpT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSkNiVlZ
  RVVhwU1ptUnFaRmhtVgogIGtGQ1JVNXVaVzlqYUhOSE0yZHllVEpmYW1wc1NrMHdT
  MEp5WVhsUVYxZFJhVmhqWWxGNENpQWdiVXRXYjA5CiAgYU1VMVJYMU54WHpkdWVsY
  zVUMlpzY0ZOQkluMTlmU3dLSUNBZ0lDSkJkWFJvWlc1MGFXTmhkR2x2YmlJNkkKIC
  BIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlFrTlpMVVpHVGs4dFZrMUdSaTAwTkVnM0x
  WbFhXVTh0VFRaVlJDMQogIFVTRmRVSWl3S0lDQWdJQ0FnSWxCMVlteHBZMUJoY21G
  dFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZCiAgbXhwWTB0bGVVVkRSRWdpT
  2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0lsZzBORGdpTEFvZ0lDQWdJQ0EKIC
  BnSUNBZ0lsQjFZbXhwWXlJNklDSXhhVWxJTjFvelVpMXRTWHB4ZWpreVFVczRPR05
  XVkhwelUyUTNMVGhCZQogIFZNeFZrUklaamhsWjB0aFNrVXdla1kxU0RGMENpQWdN
  bFYzYUdrdGRUUmxWRmhyWjJReWFsZGhhVlZ1V2xGCiAgQkluMTlmWDE5IiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6IC
  JTNTEyIiwKICAgICAgICAgICAgImtpZCI6ICJNQVRPLU9LMzYtSDc2Si1HTFlNLVF
  SUEwtRlhTVi1DUjMyIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJIMWlCYUox
  ZllpUDZvYVVGcDVwQkFXWkF5Tk5KaE5MZ2dGelI0N0pMUmhrTU9BODFFCiAgdm1uU
  G9JelQtSVhkUW5KRmt0eXEwQ3R0aTRBOS1mZG9ucHpNQUZmNWZCal9rQWZacUhnYT
  g0QnBHdnJQOWEKICBCdURib1k2eGRLNnBVT1JZQXpTRW9zVmxud241MFgtUW1CVE9
  maFJJQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJtRThPUksxYXI2N1ha
  NE9jTnJpb0tKWGxKX3NXYWR5SFRZNTF0ZXd3dG40X3AKICB4MXZITDVwS2QwREJnN
  G9UcEhOcS1vbG41dG5pQl8xR2JRVzBHcVZ1dyJ9XSwKICAgICJDbGllbnROb25jZS
  I6ICJFeC00R2Ezc3ZXV25iaDk0TklsbmNnIiwKICAgICJQaW5JZCI6ICJBQVZFLVJ
  YVU4tNkFZQi1GTVUzLTNCWkEtVkZWUC1TQVJHIiwKICAgICJQaW5XaXRuZXNzIjog
  IkdRVGpieVNOY09acnJXNUdlTUllZ1dNcEZ6cEZQeXE0QnlYYkJ6QjFDRkpFWEw1R
  wogIC15Y2RiNnF0WUNlTDY0cDczclFRWlVtZEMxelQ1VXJZV0twRUVRIiwKICAgIC
  JBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"
      ],
    "ServerNonce":"q3cMAkcBxS1AAeAZK4HmIQ",
    "Witness":"IOJY-DGBZ-AEXG-IATI-6MQO-5U5W-QTWJ"}}
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
<cmd>Alice> message pending
<rsp>MessageID: IOJY-DGBZ-AEXG-IATI-6MQO-5U5W-QTWJ
        Connection Request::
        MessageID: IOJY-DGBZ-AEXG-IATI-6MQO-5U5W-QTWJ
        To:  From: 
        Device:  MATO-OK36-H76J-GLYM-QRPL-FXSV-CR32
        Witness: IOJY-DGBZ-AEXG-IATI-6MQO-5U5W-QTWJ
MessageID: NB2L-5YB3-24H6-YGRB-PX34-MUPC-FVSW
        Group invitation::
        MessageID: NB2L-5YB3-24H6-YGRB-PX34-MUPC-FVSW
        To: alice@example.com From: alice@example.com
MessageID: NBQB-3S4U-QIJU-A2YB-HDPL-SGGM-CPKY
        Confirmation Request::
        MessageID: NBQB-3S4U-QIJU-A2YB-HDPL-SGGM-CPKY
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NCKJ-A26T-F457-ZDUM-KCLY-DI3W-LICQ
        Contact Request::
        MessageID: NCKJ-A26T-F457-ZDUM-KCLY-DI3W-LICQ
        To: alice@example.com From: bob@example.com
        PIN: ADVA-25BJ-2FZG-LMV3-IUVO-QRF4-JHXA
<cmd>Alice> account sync /auto
<rsp>ERROR - An attempt was made to create an object with an existing obje
ct identifier
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
    "MessageId":"MCTW-TOSU-FRSX-2UWI-BHL6-DLHC-BF4L",
    "Result":"Accept",
    "CatalogedDevice":{
      "DeviceUdf":"MATO-OK36-H76J-GLYM-QRPL-FXSV-CR32",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MCST-2JUP-UNOG-O4A3-Q6KS-O2V5-HSQL",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ1NULTJKVVAt
  VU5PRy1PNEEzLVE2S1MtTzJWNS1IU1FMIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyMS0wOS0yMVQwMDo1ODozNFoifQ"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJl
  IjogewogICAgICAiVWRmIjogIk1DU1QtMkpVUC1VTk9HLU80QTMtUTZLUy1PMlY1L
  UhTUUwiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibG
  ljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJUaUpQTXp3eDNPWDRsYWpCWXVIRUFkMmx2LWhjSDVvRnpCdVZP
  d280MXNwRGVsUVY3clBICiAgNF9sUjJSR3UwZkdYOTQ3ekR6OUFwY0FBIn19fSwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2
  VydmljZVVkZiI6ICJNQldHLVZTU1AtRlNKNy1UTTJYLUo0SkwtSDY0NS1TQ1ZWIiw
  KICAgICJBY2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQUVCLUJT
  WTQtNTRXQS1XMllBLVBTTEQtM1hQNC1NUUJCIiwKICAgICAgIlB1YmxpY1BhcmFtZ
  XRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3
  J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJDaWJfYi1FdU9ZdkxyNkp
  lM1FkZnlsOU5uQ2JKQjlWRjNGRjVKak5PeUFHaXJDSmxiQS1GCiAgQXFiU2Y3LVVX
  eVIyTDdaSXVkZUVqZFdBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlI
  jogewogICAgICAiVWRmIjogIk1EVkgtVlZZSC1GVVhJLUFBVjItUFIzTi1TVVhXLV
  lHRE4iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGl
  jS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAg
  IlB1YmxpYyI6ICJuRG9BSmxhbFgtaHItWjRrazk5MXBfSkw2RXJNVXlOZTFDZU1Oc
  18zcG9rWGdJc0FmcUgwCiAgN0FoSWlvY2ctR3M2c0tCc25KN0djazRBIn19fSwKIC
  AgICJBY2NvdW50QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTUNZTC1
  LWVdILUJGSVUtNkxXSC1FQlRWLUNBQ0ctR0FQUSIsCiAgICAgICJQdWJsaWNQYXJh
  bWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgI
  mNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiZVdyQ2tHUVV1N1cyeT
  l0dFIzSndfQmlKOVIwdDZxeWV2MDZzTk5vMk1FRUZFSmMxVFUzQQogIHNyYUVWTjl
  2UXBVZTliYnk0QWNNck5xQSJ9fX0sCiAgICAiQWNjb3VudFNpZ25hdHVyZSI6IHsK
  ICAgICAgIlVkZiI6ICJNQVc0LUQ2M0otWENWWi1LVjNBLU5PQ1UtUjM2My1CUks2I
  iwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleU
  VDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJ
  saWMiOiAiR0s0VVlxWWo1ampXSlpCRDlWd3h6SWFOSHB5Z19GOGloZGdOYU02TVFq
  anZFS0N0Tm9qXwogIFJkZUlNa2V6Yl9YWHYyWDU1WV9rQ1lzQSJ9fX19fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCST-2JUP-UNOG-O4A3-Q6KS-O2V5-HSQL",
              "signature":"kAM6N_4ADROtzROlAA1vkz_Gshp3WtW94esT7Z
  IxmOSIHVKnsYcYB4li382cOaQtiGCcCPuKdzCAtIf036qmjX1yKvDXqqt_fxBqzLl
  -6S-ycR5f-_HTTj0bw_PauzJWbHqYeoMlc69ZpfrigCB5PC0A"}
            ],
          "PayloadDigest":"J4EVoDnkcpM4OTqdiY62CBUnjuYN5FEmPM1nUA
  uKNXLlR5OIHt1xvlf32x0LPgF1BLc6BxjbWLgL7E76qosIaQ"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MATO-OK36-H76J-GLYM-QRPL-FXSV-CR32",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQVRPLU9LMzYt
  SDc2Si1HTFlNLVFSUEwtRlhTVi1DUjMyIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDIxLTA5LTIxVDAwOjU4OjUzWiJ9"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1
  cmUiOiB7CiAgICAgICJVZGYiOiAiTUFUTy1PSzM2LUg3NkotR0xZTS1RUlBMLUZYU
  1YtQ1IzMiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdW
  JsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICA
  gICAiUHVibGljIjogImdrTWE3WjhNaFJFbTA5YmxDaGxsMG52bFRDWTFBczRZSzFU
  WXJmUUo0U24ydW9TM29KbmQKICB6RmVfOVROYmxSS0ZxTkJYRXdoTHpjNEEifX19L
  AogICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTURUWC1GUUhaLTROVD
  UtV1pTSi1PTUlJLTVESEotSElYUSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjo
  gewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJY
  NDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiQk9lemNJeWxvTjl0SVR4aWZ0S1dDd
  GU1UUNzOU5VSG55RWEwVFFsTVJZM194X0cya3hKVgogIDRoSExpbG9TTnRiVmFQbG
  U4ekd6M0FRQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1
  DRFYtNEhHRi00VVlVLUs1V1UtMllBUC0zTkJRLVkyVDUiLAogICAgICAiUHVibGlj
  UGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgI
  CAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJCbVVQUXpSZm
  RqZFhmVkFCRU5uZW9jaHNHM2dyeTJfampsSk0wS0JyYXlQV1dRaVhjYlF4CiAgbUt
  Wb09aMU1RX1NxXzduelc5T2ZscFNBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6
  IHsKICAgICAgIlVkZiI6ICJNQkNZLUZGTk8tVk1GRi00NEg3LVlXWU8tTTZVRC1US
  FdUIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0
  tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB
  1YmxpYyI6ICIxaUlIN1ozUi1tSXpxejkyQUs4OGNWVHpzU2Q3LThBeVMxVkRIZjhl
  Z0thSkUwekY1SDF0CiAgMlV3aGktdTRlVFhrZ2QyaldhaVVuWlFBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MATO-OK36-H76J-GLYM-QRPL-FXSV-CR32",
              "signature":"H1iBaJ1fYiP6oaUFp5pBAWZAyNNJhNLggFzR47
  JLRhkMOA81EvmnPoIzT-IXdQnJFktyq0Ctti4A9-fdonpzMAFf5fBj_kAfZqHga84
  BpGvrP9aBuDboY6xdK6pUORYAzSEosVlnwn50X-QmBTOfhRIA"}
            ],
          "PayloadDigest":"mE8ORK1ar67XZ4OcNrioKJXlJ_sWadyHTY51te
  wwtn4_px1vHL5pKd0DBg4oTpHNq-oln5tniB_1GbQW0GqVuw"}
        ],
      "EnvelopedConnectionAddress":[{
          "dig":"S512"},
        "e7QRQ29ubmVjdGlvbkFkZHJlc3N7tA5BdXRoZW50aWNhdGlvbnu0EFB1
  YmxpY1BhcmFtZXRlcnN7tA1QdWJsaWNLZXlFQ0RIe7QDY3J2gARYNDQ4tAZQdWJsa
  WOIOb-y2eWTXEESWtHKmFtjFJjY-To_j5zs3rmch70t1sMo3nMYyduFxARif2qV9J
  FgjS5yTVqKI6o8AH19fbQHQWNjb3VudIARYWxpY2VAZXhhbXBsZS5jb219fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDVH-VVYH-FUXI-AAV2-PR3N-SUXW-YGDN",
              "signature":"SAc0jxOn9C5RTGom4uLkaLobJiquYxJHLTcZCs
  vx4F6kojVecYz_UtyqSZY-PPYGBxYcrpT2PKaAECvfWcu_q3eOabaciu9FYZEGI72
  BSSWwuBxQB_SguiBWO2JoOaYhVB_hERwjxSVkMfczr--WuxoA"}
            ]}
        ],
      "EnvelopedConnectionService":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTA5LTIxVDAwOjU4OjU0WiJ9"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tA5BdXRoZW50aWNhdGlvbnu0A1Vk
  ZoAiTUFWVi1aTE9KLUxWUE8tRlZKUC1SSU40LUs0SUQtU0hGQbQQUHVibGljUGFyY
  W1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1YmxpY4g5v7LZ5Z
  NcQRJa0cqYW2MUmNj5Oj-PnOzeuZyHvS3WwyjecxjJ24XEBGJ_apX0kWCNLnJNWoo
  jqjwAfX19fX0",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDVH-VVYH-FUXI-AAV2-PR3N-SUXW-YGDN",
              "signature":"aAt65ivoEM0QASp3SvzIlRcuFKOxG6CNi6UNzF
  ap1LwTmfuOKSAyO2IwCqp8r89yUvT67kHeIHoA0_vwedwsevIvd-gJVTvPr_F0s-w
  y-ungSmWOZ_sfNcOZTPoj9kez1c2kKizvfyfXde-xju-nbxMA"}
            ],
          "PayloadDigest":"-z5X_t-rZTE3a-kNsEw1C_3EtG4-FWXQOR8T_q
  w-NmcN2f8xe0adjeShryvFDBbR6fBVPl0Myfc2EFsHgkpHFA"}
        ],
      "EnvelopedConnectionDevice":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMDktMjFUMDA6NTg6NTRaIn0"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0DkF1dGhlbnRpY2F0aW9ue7QDVWRm
  gCJNQVZWLVpMT0otTFZQTy1GVkpQLVJJTjQtSzRJRC1TSEZBtBBQdWJsaWNQYXJhb
  WV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibGljiDm_stnlk1
  xBElrRyphbYxSY2Pk6P4-c7N65nIe9LdbDKN5zGMnbhcQEYn9qlfSRYI0uck1aiiO
  qPAB9fX20BVJvbGVzW4AJdGhyZXNob2xkXbQJU2lnbmF0dXJle7QDVWRmgCJNQktT
  LVlJVkMtR1pCTC1FSk9NLVpWSU0tWFdZTy1QRDI2tBBQdWJsaWNQYXJhbWV0ZXJze
  7QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0NDi0BlB1YmxpY4g5EkmoDjxdpHJaOT
  ciSNY6JGtP1b9ZU3YjZ4RpbOTa4bmKr-QJFKEWAG6bTCAr7EY3br13kFdIZLaAfX1
  9tApFbmNyeXB0aW9ue7QDVWRmgCJNRDQ2LTVHU0ktQ05BNC1IWDVQLU4yNVctRExD
  Ui1KTUpVtBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEW
  DQ0OLQGUHVibGljiDkl-IrgAI0mtoF5UHucMgIwYc9mNn9a_r95dPWqghus4PD7Ct
  VEELmIvIa-bKnMh3yFqP8M_7mME4B9fX19fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDVH-VVYH-FUXI-AAV2-PR3N-SUXW-YGDN",
              "signature":"YjRCWFvPxL8CcEBj_zvUEVOGjPe1Qe3dZIJUGi
  JkpXgfVJlKgs0EU5Y2owuqULVUxcI6aCxHCFWAqra7OgGn-iB3qx2YFvfCvbOs-xN
  o4BcqBlrqPOCGXqp6OwnnreMyl6403knckAdY7md52GZjtysA"}
            ],
          "PayloadDigest":"CCuKigDU94YpRVLjJ4A5Png7ZV1IWXwBarRYSI
  Xa3EzzzGbE6-ARcpQf9ZJhWWrUOHSiI_V4QrxcF4oJ_M1Xdg"}
        ],
      "EnvelopedActivationDevice":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQC-TLDB-KJG2-G3RL-AF6O-SECR-XKX3",
          "Salt":"QDPPRv_NcONiZkzkf-q44A",
          "recipients":[{
              "kid":"MDTX-FQHZ-4NT5-WZSJ-OMII-5DHJ-HIXQ",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"trHZqzgIb0i884tojIP3IyIaBT4GJv9nopvC5
  RvIOy7Po6Bn5O4kNlxQxR90vzyyjlxc9a2gMoKA"}},
              "wmk":"RZwHkAsNodin2LSDRanaTcllZ0rFz7U2KnTMlZFktUik
  jB_vRTWLcA"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMDktMjFUMDA6NTg6NTRaIn0"},
        "QhxGolMp0VGHc8Y0Saq3v85CSLs1U-_197SkobQqd2uQJBYgkqGCrK5d
  b173Vkvwi6JhBo3vLJvSZSI39SAb_In_X7upbGwwyUSlLzXT5IdJLbMSwJ_yfmUzu
  VhI8TDR5F0SookTWNrCJYU_LN6-GFJqLZhNNwbSYlYEbRwxrGpgw_QJjhWaWOtUFa
  SwOSco6rAQaXcHS3go22xYrBEA29BtlG9nyxNBi32he0Pzf7OACzZSiA2VrBbldi5
  p45j7",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDVH-VVYH-FUXI-AAV2-PR3N-SUXW-YGDN",
              "signature":"h2tmLep27HJF3t3Ql1OhCQpR_6LuEc68tfV2T6
  _7poGYqDgRemyqMG1P9PxMIWC8nWHggN6o952ANG2HDNf-l_n4CGClefRU60GLirV
  4q8wawYsUdSVqIq3rutN8IVW9q6cpjTlqPUVsNwCBaHXUtSAA",
              "witness":"QVsvTv97k7Kh4NRZyd-rusAHQxxerAAeYqu4A0y-
  RPg"}
            ],
          "PayloadDigest":"azj4xiGxt0i23VDf7ooT-XqJnUp9vevf8sB7Ic
  TtvORlrzItpgZl1jfnSDJoU6g66B2QkjyevSnMYGsRyXuJRA"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQJ-ERBY-GIYM-B36V-CWE5-3APY-ADPF",
          "Salt":"dXquJmQGgO1a80kaIlCQMA",
          "recipients":[{
              "kid":"MD46-5GSI-CNA4-HX5P-N25W-DLCR-JMJU",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"F5aaO2NRaX-I13Z0nFlmfgX3DEfMiLvGUmIR1
  Yt9qyMVddbHWq57j22dWQZUpv6rWRJpHKqW-c8A"}},
              "wmk":"CeSSAHFI-n3dVHqqnFjjupJyhFU3XbIJqX2I37Ey-v9h
  j-DkVkcpjQ"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTA5LTIxVDAwOjU4OjU0WiJ9"},
        "ihDlxmJjFBSt1Vmusl4fUNA4JvqZIxyxt8o4qGCXVbDZsaJRSHDIWqAN
  u3scDRMH8je7FRCQT8ZUsOb2dJa38oscRFVNEtBndKPMLNG3fQbguE-EjwItkLjXS
  Ab7F6_m-C-B-B80YkU_TDDGrA6A-aALv4bNqs4eSk1-Z2Tg69QjykuzUKsuYOmDl_
  N6A2eeA0JnpMJLe_JcWmDqdhtTBI75QvrDd-LleV8EHFtxzZzrjZ-ucx0SwCeM_su
  CwVLeBzyjSZk-aKIxSNMwBB2gO8MjBNh_bb6aYaF24We-3an710sLVaIEJ_oIRzfW
  GZKXJU7cTQkEzJBEAwHiRI3xezhP5HvtLG3Wdd3n8rs5Ph4oDb9aAY8E2Z7xtUrZ1
  hdGuaRQ8z7iFCicJB_Z0Zup8NCWSsto4UbvmZZcABynI3YdB6IbKy33nebqaTwXpl
  ikWZXQ_MpdI6n51wN3_pJP5jgc94fHGse_Xpo_xbnnotN73l7oaWedaUPoSwNrAlP
  nrJloo8oQNeZM4-BoZbPesCYL1j4OumCUi44udT3QVz7hw7UMUBC56XSuiepnljO6
  spB8L0-7auzyOZHEKC3jorvC1gIjCu0AE3ltm0l0Fr3j1fN1BMhFCV3Cg_KldODBC
  p7tVUhqy80zJhekpmsm4vnabdkRvxeTV8ysYX_HoXf5yuu8Uuk0lXK8JcO-aaYIEw
  ckKRmOTg9DWi1tIe1obvIaaqnZsW_mGpmS9ttMKUF5vNcomm-2oQiYYBqbmUidPG6
  ZSpEArzD0g5BMCWSk3s8CIX2L8IlxJmdVvF39pE3DIRFDf-AxeGsr4jtp8vEJZNRD
  S6y4L7cop64EbIhVq5KjImjfoWfgtSmS7cTymgLfV1ighIXHJHrPWlj6mrOJFHjOq
  svxTvjafaqRal2ulHQsjoaWeUfuStwPznVBlJ5lK1ir4m2UY3O9VhSOF0aL_8yHeC
  MbStOHQWqi-nhR6YJa4q1t01Jfre6GTCYbBpmHHLm3Jlz7P97yEJ6FPJoFUw04ySO
  rsK37h-1VC1uwPRb7HdFAgoASZGpRjXeJFi8SzqkWrfOoQ40wA_8hLT6iEusiCkYb
  RT-JX0aheYh2nE73QxKBPU7B2cNyoU3C1umPZJzSv7uKB1tp5fLhLDC_s3ua0xEcF
  0d1WzSM0REkUaEAC968IDzkOrtFEmV5bCOJf3Ko6bdgfytXgZRhM3FXnXIyrAX2ja
  NE0Qj0CoraXjLFxlfmS5fQdHlfHC3Cr4aQt-h_vC-TRt8xsjZ_YKqDE525ib-tvr6
  NNjBqDJFWoU-UPSHLbkktOPmUw3ejppmVT8Px4NfQyZw-wjX41I7wOfnS54mIaUKb
  bPxOhCV92r7socn8-IxZNSKUGKzIvJXxgZXUZ34NpXy-VOaJKGKCo250SCwknmCtD
  Skm9E5Z45LCc7xa0SwJqau_SXN_i0vW2i8dJrtAY0t6-LF57uEzMUm7mafoyVmOxH
  D49z6B7XW42QOc2oEMsIkFRy9os5OFRcCAul3B9Uc6MFxEDGPBLWOgULljjWdlhuu
  5UIMbXK9m2R20wF9sRyOzJIdAI__vilNYP-Kz-qh6YaW5xM3f2NXBD0ZY3OFTzut2
  VxZgV1755FDOEQpycku9jiKwR9DGBZlrPpeGOsw0Reons-23tcRh_cUlZgEhq_UvU
  E-nTg4CdE4_k5zXcSXiIM41oeDHlRTpxQLu_LlDvKhUgw79BhaGTCzhRKMxM4xOEh
  HYv0dffhFQC1E5vdQRvMZW-bdi-wFXhssWBK6vNgkSa5TCS0wUgap7wb4yW5NVLi6
  CpZVSkFlndkyIXCwvsKCcfSIpEYHiY0rK-Ndayug22DpPSo6cu93iougEbz6TUdb7
  Nr-_FB5XnXTDJGg7SlZ4wDLgazm9Beyet-8LNwsY4wPQyoNJfbfbrunQeSd2h6crt
  t9sRtqGgsjqIK1hB-DKCPPCNN9q2qIiO49JSoRNxwQmNN3K2JowdmXqws5L0Reeu6
  RRwyN3qbKWqgyFedSdPm-Stu9X4sY_rTO0yNeujEaFjw-vaxjwT9lImb2ZAaHGQoU
  M9P4Hxbz_B7MtbTGMurCKA_kqjvxsXnsFnLKIpO0w73MMOumMcXwQkxqSoeAbPw-k
  1A5Tr4HL5_TLkMlQp8Oj8HWI4pek35AC-zW9C15n9ILE3fH0So8KnbLhNo6XmJ07G
  hHN5-HQbVKywj_Z8lyIFyh4UzcOggl0xnrNYZJAV6t46MUDlejZ8yVSuduli5z9M4
  M8RXz1MfA_Mzkf8nbtQkzHax3ML6zpDeqlO_2aAzhYOhajaSdvDZCt3oyYtY8-6dJ
  DFnHOfIuVRG_htix-Ng_aUBDWWvfVmrZ3g3YBfSUdFZQWIthlyCjl0_SWAVH1qMwN
  9gqICPBXezMs3hPCmbnT-sx5UBpCQusyhyhbUYQuVe8LfVkDyA2MgmkRzD4IT_Jeh
  Ne0ZZqgfb8kZEck14QsMRnnmcOOUYem60rXXp5ziU99_JXP8GV_5qvvSdgem-goFN
  gvAJykFnGfl3QfbkbHXpQbVyhjVyBu_nbzVVYxEq1BaOpcbIPXocCpP4pKpzolfWm
  jYu1X9Tm4r3tEHATk_wZQUOewMsRpSDYie44tDuNHrrM3ys6Grh7eIzC7tdZ8InfA
  UNHKh1VxHwJmsQnZ6tOaPcagS2_pb9S1fpXgIxB0OMcXmR04gIh2hx3LlW0dwaBp2
  Qvj9rt4QUJ02pULXmo-xuFNHHgPLA888LV2pJGHlERCbBc5jMrr1JTXfe9nm6X0Fm
  dYFqi8JsClPjXpuHY6UadadPGhyTIZMVP4l4thnZdXQJyv2aiCcPvUF4qGc6j0kjm
  ikAwQxJaPXHen9gp6hOgVqiywicX5ziObIHSQNCm47ghnVqTGKFbkMOieSaU8L0BI
  865kSQsNtkltqvviACtlhJ96v_3J4OMlqIJwHCaEG6kizl5Bio4WfqL6US43Xhs8p
  mWq69Fi8LMjY6qRmi8XaPESLpmEuhRSAdUPFZeZDwgcdR8S4NrPfvDX9k3ECGpVzF
  YGDfpfoi6LIO4RcW5NPOFZ5KwsPfN5VyTTyvxfmEOOjFQZJKLlgZoU93ShJTVbS-X
  imNRRsO7YOjhqVUJ6U1_4da9j7Nfovi6RhKahmdi3mTYMS_QDUYmWoeUYWrltoGBd
  f7QAof9F4Fc75acK5SE2Tj6MEcJJP68e8HCX3FJdcCBgp_so_LxDiUmtwWjAVs-TS
  P5KwIxPPPIG4F3E8vj8ID-fANAWBpY4zxv8U3KWchcn5U6ex0L9gY1q5njnhbNbfJ
  jy9vSB6P7CZl_Y2fUlfZPWhc823-9WFr4HEOAjUc_fElwsMA1N1Ji6YfqeN8270aa
  _cFD4qEXw9kr3L7NFx9YiBg1Jmf21kPPvNKuueAlBfG-lu4JU6NyVW70PeIj2mmX8
  31BmLGX8CciQpyuRgPXep2qYTd3AMw5oUloatw_luGNz_lZQhdUI3dN8iiwTUjmeK
  4mJbJiO_l4B04aR3tgklmhUPujzXXGqsnOUMJp9McF-Sdi-5rrLz4YKbHFMErCKt9
  -xFgkF01u7GWO5_6pqsQTEFHP2o4CFBgppy90Eb9CQJ88XdyeWesp5n_v5lLl5Yal
  XJhrZ3qCpPZ4qL1SmU321hVrQEfsYUBzbGoCEDfnvKnCLjdB8WFGHWwaIlM5xO_q0
  p9L6a2UKk_Mj6dQ8B2TnJ7VASgjHzAcyOuzTWvpA0JC56fowxafokL-crYsfGEKle
  QWZMKsG3IQ1rXjmfY9dEkPtbHuRPiVWnU6Proys7VgdcsKRaAE0GV3UoKIG4bHwHx
  ehUdzpdoFhlM4OqwzKWoST5VU5Gi5deI4uVzPHgIR93agAolQtK4pYLzRB0h_n65c
  WfmebtoQt4DCWLt5J2hDgJ2AWXbGPnrxtXv-I85m7Nago2LBrLAZPjAgXuKH2GTW2
  HUbA2B3TikOahLN-MEJsFfZnd0A2q6JDdnExTFrZ3lFRqWNGh5hoLSUVl8Js6QfV_
  w5hXD5Qe-PdUwdaR1hMXQr_kh4koM_rOj21SKosdFiyz1ZAGzZvkyo5sxUclAu85H
  vFY3bd0nscDsG9l1dD4BSBD6G8QriN3UnAQ3F57zJIfCCGllBgErBXFaF6_pkICcI
  O6BGKmlDNtFn-jz-AdScz3HSej1nPLEGHy8ngwytetmKGNAx2wnZpWoDeoOvjhR0u
  DkU8j-786a0qTdQk4IUHFOl0RCK-oV3DN9PeGKdpGnPYNmLmgVj0ytUcB7Mw0NLaU
  Ko6zlI5SrZ6u_-yN6OuYjCcmNwXnwOUEWReczr3H5hJPXSJXV_XZ-0cu9gZHcG1m7
  c0J3N2R7d4p1A6aJrjYgFXBZo5tDxi3APsx32_3ZmlDZ1TuaKuKqAG7qyNWbkKsZ9
  W7jzVMWbmwAnQEDfqlKKOezzsp54R_aGqdg42p5nv8BMZUVZywn04YGbmjUPzSoiX
  jryi9GpxFihLlHJUie68xRzQkocHQ2AGoTJAZprgm4k01iL0k1aGwwtrVGVliVUGg
  knlkFG17oaWlmZwVsygaefqvD0gZOASJS7F7q3jFgzYoNdLCOrVDPXjNAQCzpzyeO
  KYd3VJm9k9bI_LEOiUrKpk1ucuSgBhs2vI5-s85zFJr0am1r_pXQIFg4PaCN23ePn
  7bR9aEapqdvhx9gE_EfNNDcCEuu5EOW2hMxrxs_HFUR0XEDQZSm4HTTsxWDTSl1WX
  BA64sbDC2uLNXd6o6dhezmaUSlvl9DBvAiyt8meDanzveRlAa0RWG1Bh230fr83Ce
  HwK8Xz2FLBVuX9c3U6sj46CSg-Z94Eb9Pkbpj0P1qIqJelmJNVmNeK4DAFPWzCslw
  2zDoUwPs2MH7SIJfh2k7Dcoh98CBnVT0IK4Pe88GQDtpROf8YAsKU4XwuxDc3Z2JS
  r4apkr2F0MN6hztnw-HEDkpa_1k-e01Aa_6yglqoyTdLx_PUhj0HKOvrBOrlcgoVL
  PElDjcvvMHs___iqCGPfPBTgp4KwE3xG_JE-LBWr4GSKN9CbzKJT8HRlM9N81pw_o
  tUbN1JjUZYc8s1YZ8JLhHf4JSGMc2IRx5eWy2yjrN9Yu6T1TtptyIF1n3kCWnoSik
  IwyCs7v2s_CRASOssGNQ1kJJm_jC2crAoJ3vjrP65tuucJwmoINLuJfP_C3ObN4tx
  MfkoYnu2aB7ve4LAV5pNhvWnNdIwwXYD3hPQjmUAH7PAvaQN_d1s1q1xNIood5cE_
  ZJHnw7VybplgqUmFIOtoq-RUFp4P8uey5hUMJgyIkUYGvH6WBu6e7T72Nbga68Tlp
  tffWOeQ5DyfWSVjTPeKG4id7rVBhVR2TjhQ1kp9uLUZRZYx-pSrAJfKjbf_zvjsTp
  m8fXIXcQx3ObMlVrac-nPnL_dlSwdXY-P_hXJwm1UZZaYbrZ57ygQ6ELXCZWVKXDC
  BpY74upZLxeWRFHzcpjy9DgaY13q2zCIwDhhRXlWkqO-sH86fn6QagwHXKphAI_as
  SNx5pqpq189EB7E-hoEPHiw65EzIxUG1mArqsCejF0Godu6dr4MeOHMCpahvAX5eU
  Ig4MObj4TTrpfuVpiOs70ImgM8_smUm6--4gdggZJY3gjy8IUchcoLJjKn1HRyvDg
  iBQVmsqztlPj2b_D3JPTp0D1Aum9aPUgZRv8xvJApIoH1YEkZUZJf2TjG0EUx5mvg
  shp7wWeD-LpSzekU7HnrMg8oSXC0FG62Ullsmg1MHV7T7aO9etd31XxyfhRrq-eDH
  pkJE6XLYZ66J8CxjQn7s0jvGD1D6FZT2eaVidczHTbjCeGoemAo-51uoxz3iNmn0u
  mevV_ydz9InTo66cxNSjytHQTkLL0placea5kb58exhkiuaQeHhk1OyxTw0Md2wXL
  7WDrKwZFqrCItHBYepRNO4dKOqrP4sRbVyVmuWIjoi8EPyFM-KkYN785cwfMYZKl5
  460YDqDY4_ZP9ai_SOatUOb4WIaFY6ieiYiNCgDsgYxTO1ElpppbwBMAmvGuG4cWH
  SUsfDdIg-R3-bQD0AWdKlwFHApnr1aZqAoasevwVeSd1kTYivRWSyUTIZzVE83alG
  wHZhnDGZLuSr-BrurLMmclHdpFJTSBGc-fsrxrPkRZp2iaLEIz8ItcFwefg0DbzwD
  yqiU5E00ZDFKUxsTReXVIqWxB8Kz4iEKUxFLeucS4fBZRJLPqwkvvZxKcl8uIfey3
  RlYlEPARAPiFIxfNxCh8vks3xSw2MnsJYQJAfsLlnE7_YrxCFeSMvYEVuh7z3Rtgz
  XvVS5RV178a9xPRT2o8xrleoEHvF9djyUDkAnocBs1hj_TB22C1cwOufUuDCiMkZn
  s6v3tjmhB3tovWbmDbuDYC3ATk_JRg7eQIuFv-uyAcBs60GZToZd9jZDw3WW3Ia1_
  CTv5lDFx464_7_0nQpqaV7c2k1ZodTSlTvtbdhuKcxM-o6amBz20NyLdNdxPwAiYQ
  N6yDk9YlqxUwn9Bu6HEKpaw34W_HhAgU191JR3RjWmNZon2BSPmxJ91xx6qw2nse8
  jumVM5jx8KQ2XfsZM6FCK3e36MuRxL_qAi4VRUF2YXEEIOlTbhn77n2yhhD5zBbYo
  UTIKFbPahDzbfK8SSqZiP2V8G1eJojoqGdBYpjrZyHhCF_k8T4jinnUaghAJWPhCq
  sNu4AolEDWKFpsuqDe4r1-gpxJql5v3rAjlYGSPcwm6ZsYtZRpE3Dn_RPpr61Ux3e
  aAxL-aQEnTcm_YAL4qQmW3fpxVh2LBQMcQJviZE7iESCBpyhOxvekAWUIjyORtN_a
  rXv_I07J7ouZL1jXPKmq6cm0Un_0-7I9US4hsdbqn2-byabdXPmb3U5ye25lKhGub
  ez-XIaOxvHI3AoAHGbGRXdoP1YeOGuK32kkGIrtkxjBGUv8Sbu2acpXjDgpZk-pTL
  VQmhjKlB_o4sWdzH_iB1D8Y5UK8h_44qtj40Fi8kjYJYM43nMf07tmR-9e1jbHEez
  ZAkJvEQMDc6RWVrzWEyUGWamV3QQB5A-fIwRCUqnJWeRZH_p_d9vcn_V6EabfVW1K
  wkLR5TuQq25Mwbd817et1pwSUxeqgrS0WA8ZcILkkwM5RpVCTq47I5bToepjS7y5E
  8cAHyMSoblbljCx_CmqmYeC9HUdNmTHdgPs1n3UPKmqANk7XarrURTNDenQUiDBLx
  FQs2k93X8t2Cwywq3d15QXFjiC8YtsYS3AeK88ZWwfM_-Hvk_Q4Tc_yC9fo6DiV6Y
  7alBIszfasxepR9vcD3GD2Ou682cwCJwgoS6KvulXqAr2PIE-9Qf2TnWJQ9bvulrg
  Isb1J-OcTxM4jkYMP-_Km5nozC4UTfpqCJjUi4MxsRuvEYqnqUlfUDG6S5Fz_lT5W
  f_kxZ-ZBz4-rT8KOHzL9wTNYqYwtvmTKsPfrH4mr7DQJ_SC_tyHc1YraCqMpmg2IP
  IyHt_FuGnjgi1VAIbvmGv3pEL8XOWhTTFupYSQ5fxhC5_pjUIRYqcl31vBQR5v7b8
  caBQHDHethc5g-gNHCmFF9ezJe3hF5nuC3kWARoX74JPdWZdtQxOqm89MbcZEKzkx
  Nxo4yNbRDJWhF71D8TK8YNNxG4yBsEd8L3cOsmj-7x-jJc-S1DZqZVHB_1Qa_i8o3
  RpBhjh6HqBFbdUt43mXor1hmn5exuk7LpInA8D0iMnL1Kp9HJUv2obqTVeKN6JdKu
  6YQ7mzoaiKLppawm4iQY7HjAZJHeJFW0k-bi5czTSdz8Ld6aTNvrMQLxOtXFsnwbV
  D5hN2Wv78K_5fo2lAcxnawqDC3Gd2ULmqTPXgujXDg9t08zoquXTcmhl01OWyL8zx
  FZZlue31Bp-FoTrBFwD7rn631U8gEfJBF1aAVPrh_RSwsiVa-d1_J930vPYi_YHse
  YLKOb1Y7KkYoo7LQpv0ITxAnS7RBZMX6sfLjGbfu5md1q4ttbOFlqPFQ5O9BhSYy8
  _BoLe7sRaQI4wL5k37qILTyXScN7CzccbXlHRV-uLVkSaEhVPXXDrPhd0QUdhF-0c
  _T8w7hyfufSddwN50gFJs3I3S9kn-LyhBAbEfu4tRKzjPFzhminDG5d5bG-ZuZCVM
  EO8ii-Q6-FcRi-F1NsJLVs0jaqNNCQyHyf4KU8gu4vIw9kcdml0ayJ-JpTu57ZLWQ
  SOeWHtZ46THFDGFc4jimtmZRKnoAY3uMjoHQzD5ZSqivCS31pza0dxJq-TMQuq49o
  mYosZKKBP7OjL7T2yqd7B1WtLCbYbh9ISUUl88kyw3AAny-Ak4YPX2bOvnebsCAmk
  4cyJYW-GSjdOPw4Gq0kUahQ2an4r8ta_nCv1ao5J6nRuJh_qeJLGcqUWNqB5Rdo8f
  upFLJgzN0lywAYn4_p_T-ncw2pgZyZ2HIkkPphxbfogYFFOPfG1yD6R0W5oELJULQ
  grQYUOrayVt_XS0HlIX7-VRgo-R5fi66g_5neKtlMX9H9elFVEQ_dPZyVuw-v4PLV
  0x-QftH5syv2t3_yr9lvAtnZyyp9HNe7_H36Rx0_w_i0_7fBBD2aE13st7DW5RMvu
  KRl2AX4F96M3Wh5hQWCvAPADQAhvsvQqbp041ei_opSYU95M",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDVH-VVYH-FUXI-AAV2-PR3N-SUXW-YGDN",
              "signature":"xnXfWbOzCdkVgV-7k5xEppvEnaU8rGtmZ5eJqO
  dd65G5fDesEOXhte0pEiMNbaBwj00QrQWX34cAr6VujlzX87m0VZgUdZu6eIRGULy
  uq9jaqjVWVqI5cDEKYazMA9AI4T3Bt7OkaeTT9SGAMr1c1CsA",
              "witness":"XM-H_2_geHhJE0wxQ8NZu9itLvOjRX5Y0PJEbn2U
  YkA"}
            ],
          "PayloadDigest":"8FXzWzbJMRChapwqZxfVJp8G_Cs9Nag4cp8EBW
  Ku_EM_BmY8SAvlCYUIcHo73Y-_olRLbANe53T2DSia7zmcrg"}
        ]}}}
~~~~

### Phase 4

The device periodically polls for completion of the connection request using the
Complete transaction.

To provide a final check on the process, the command line tool presents the UDF of 
the account profile to which the device has connected if successful:


~~~~
<div="terminal">
<cmd>Alice3> device complete
<rsp>   Device UDF = MATO-OK36-H76J-GLYM-QRPL-FXSV-CR32
   Account = alice@example.com
   Account UDF = MCST-2JUP-UNOG-O4A3-Q6KS-O2V5-HSQL
<cmd>Alice3> account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MCTW-TOSU-FRSX-2UWI-BHL6-DLHC-BF4L"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

