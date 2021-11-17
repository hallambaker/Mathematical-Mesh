
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> account pin /threshold
<rsp>PIN=ABQR-GO5I-FPIE-TK5O-M4VU-DALE-WM
 (Expires=2021-10-26T15:49:02Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcu://alice@example.com/ABQR-GO5I-FPIE-TK5O-M4VU-DALE-WM
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin ^
    ABQR-GO5I-FPIE-TK5O-M4VU-DALE-WM
<rsp>   Device UDF = MCVN-XLLT-LLNW-U4HR-BOMG-RA6Z-UWRR
   Witness value = 2WZP-KNZF-JMKO-RQSU-WYTH-UU35-NWXV
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "MessageId":"NA46-HSVG-N5NU-EXKZ-4X7G-GSF7-DUWS",
    "AuthenticatedData":[{
        "EnvelopeId":"MCVN-XLLT-LLNW-U4HR-BOMG-RA6Z-UWRR",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ1ZOLVhMTFQtTE
  xOVy1VNEhSLUJPTUctUkE2Wi1VV1JSIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTEwLTI1VDE1OjQ5OjAyWiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUNWTi1YTExULUxMTlctVTRIUi1CT01HLVJBNlo
  tVVdSUiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogImQzMlg1b3NHMUtPRTVvbWZWTUZqREs0MF84eGJ5RTNrZlV3T3
  dUYlBXMXZJeW8zQ0NOdkoKICA5aXBseTFBMlg4TjVMejhXSXRTWml3S0EifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTURNVy1XQ0lSLUZKTU8t
  N1pINi1DTjNKLUtVWkwtUkxBWCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAibnRfcHU0WVJieXIwWUxNY1JXdmlNLXJ
  UWlhXZlB1UVhWa1h0TWdud2hweUVXdjBHUmpsaAogIDlVcnBPc21jVTI3LWxtenhJ
  T3dTWGpBQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CM
  lUtNkdNNy1QSEkzLTNVVU4tTElaNi1VVUdKLUlXNVEiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJVbmk2NUVYY0RY
  YmVXaW1RbFk5OXhhSG5SWmpiSFpBS2lUNmRlZDR0MWp2TGpFVmhMb3lYCiAgVlFra
  WRoZ1lsV21fRHM2ODdPdUpoX1VBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQklDLUIyS0QtQkJSWC1HNFBELTRJMk8tUE1ETi1XT1d
  BIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJ5cGJTV1ZnSHEwb25oT2tUT1F4MUNkZ3dIRVRQTElSTVQ1aW1SS0pfMG
  ozVzBKZnktVk5uCiAgOTJmTzZrSFl0M2dTb0hXSm04TXZWNHdBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCVN-XLLT-LLNW-U4HR-BOMG-RA6Z-UWRR",
            "signature":"FPjcCzr7s0FbUHrZOOhUGuesUNBJONX9Fe-C__87
  eykHW5UOylLhnfxfkULQVRIY3gdFgfLSJ5mALYQ3v9RLJthdPhMpxDfuyIiD3Vt-c
  ho2QGaSq7imO-ZlKZLP_jwO48AnqcNZnJwcdKMFhkzZDjkA"}
          ],
        "PayloadDigest":"HgKI5VcczlRi0_H9mEeby_Ylk8zCTleLmhzeWVof
  kWccfgpClI1hRH3fn_JUAJZqau76o2AaUTPu3-Deu9TXaw"}
      ],
    "ClientNonce":"-pyukA8KJqdvV_hePIKFZQ",
    "PinId":"AAPO-PUCK-AIYZ-FSOX-OBI5-YZZB-RVT2",
    "PinWitness":"wV04crBaf7h-5fclVAGMIsy5ZUZnKcqbPXDUbuZfXYozuI9
  ZB-emewnq2awvpw6i7oFvgY-oW0jQrUYqJSTWDg",
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
    "MessageId":"2WZP-KNZF-JMKO-RQSU-WYTH-UU35-NWXV",
    "EnvelopedRequestConnection":[{
        "EnvelopeId":"MDKW-3KOD-ZTW6-MRIB-AARK-UACM-PDOZ",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQTQ2LUhTVkctTj
  VOVS1FWEtaLTRYN0ctR1NGNy1EVVdTIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyMS0xMC0yNVQxNTo0OTowMloifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJNZXNzYWdlSWQiOi
  AiTkE0Ni1IU1ZHLU41TlUtRVhLWi00WDdHLUdTRjctRFVXUyIsCiAgICAiQXV0aGV
  udGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1DVk4tWExM
  VC1MTE5XLVU0SFItQk9NRy1SQTZaLVVXUlIiLAogICAgICAgICJkaWciOiAiUzUxM
  iIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI6ICJld29nSUNKVmJtbHhkV1ZKWk
  NJNklDSk5RMVpPTFZoTVRGUXRURXhPVnkxCiAgVk5FaFNMVUpQVFVjdFVrRTJXaTF
  WVjFKU0lpd0tJQ0FpVFdWemMyRm5aVlI1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxk
  bWxqWlNJc0NpQWdJbU4wZVNJNklDSmhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV
  04wSWl3S0lDQQogIGlRM0psWVhSbFpDSTZJQ0l5TURJeExURXdMVEkxVkRFMU9qUT
  VPakF5V2lKOSJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V
  3b2dJQ0FnSWxCeWIyWgogIHBiR1ZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNK
  VlpHWWlPaUFpVFVOV1RpMVlURXhVTFV4TVRsY3RWCiAgVFJJVWkxQ1QwMUhMVkpCT
  mxvdFZWZFNVaUlzQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KIC
  BnZXdvZ0lDQWdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0F
  nSUNBZ0ltTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmli
  R2xqSWpvZ0ltUXpNbGcxYjNOSE1VdFBSVFZ2YldaCiAgV1RVWnFSRXMwTUY4NGVHS
  jVSVE5yWmxWM1QzZFVZbEJYTVhaSmVXOHpRME5PZGtvS0lDQTVhWEJzZVRGQk0KIC
  BsZzRUalZNZWpoWFNYUlRXbWwzUzBFaWZYMTlMQW9nSUNBZ0lrVnVZM0o1Y0hScGI
  yNGlPaUI3Q2lBZ0lDQQogIGdJQ0pWWkdZaU9pQWlUVVJOVnkxWFEwbFNMVVpLVFU4
  dE4xcElOaTFEVGpOS0xVdFZXa3d0VWt4QldDSXNDCiAgaUFnSUNBZ0lDSlFkV0pzY
  VdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGwKIC
  BGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0F
  nSUNBZ0lDQWdJQ0pRZAogIFdKc2FXTWlPaUFpYm5SZmNIVTBXVkppZVhJd1dVeE5Z
  MUpYZG1sTkxYSlVXbGhYWmxCMVVWaFdhMWgwVFdkCiAgdWQyaHdlVVZYZGpCSFVtc
  HNhQW9nSURsVmNuQlBjMjFqVlRJM0xXeHRlbmhKVDNkVFdHcEJRU0o5Zlgwc0MKIC
  BpQWdJQ0FpVTJsbmJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxQ01
  sVXROa2ROTnkxUVNFawogIHpMVE5WVlU0dFRFbGFOaTFWVlVkS0xVbFhOVkVpTEFv
  Z0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljCiAgeUk2SUhzS0lDQWdJQ0FnS
  UNBaVVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjblkKIC
  BpT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSlZibWs
  yTlVWWVkwUllZbVZYYQogIFcxUmJGazVPWGhoU0c1U1dtcGlTRnBCUzJsVU5tUmxa
  RFIwTVdwMlRHcEZWbWhNYjNsWUNpQWdWbEZyYVdSCiAgb1oxbHNWMjFmUkhNMk9EZ
  FBkVXBvWDFWQkluMTlmU3dLSUNBZ0lDSkJkWFJvWlc1MGFXTmhkR2x2YmlJNkkKIC
  BIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlFrbERMVUl5UzBRdFFrSlNXQzFITkZCRUx
  UUkpNazh0VUUxRVRpMQogIFhUMWRCSWl3S0lDQWdJQ0FnSWxCMVlteHBZMUJoY21G
  dFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZCiAgbXhwWTB0bGVVVkRSRWdpT
  2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0lsZzBORGdpTEFvZ0lDQWdJQ0EKIC
  BnSUNBZ0lsQjFZbXhwWXlJNklDSjVjR0pUVjFablNIRXdiMjVvVDJ0VVQxRjRNVU5
  rWjNkSVJWUlFURWxTVAogIFZRMWFXMVNTMHBmTUdvelZ6Qktabmt0Vms1dUNpQWdP
  VEptVHpaclNGbDBNMmRUYjBoWFNtMDRUWFpXTkhkCiAgQkluMTlmWDE5IiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6IC
  JTNTEyIiwKICAgICAgICAgICAgImtpZCI6ICJNQ1ZOLVhMTFQtTExOVy1VNEhSLUJ
  PTUctUkE2Wi1VV1JSIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJGUGpjQ3py
  N3MwRmJVSHJaT09oVUd1ZXNVTkJKT05YOUZlLUNfXzg3ZXlrSFc1VU95CiAgbExob
  mZ4ZmtVTFFWUklZM2dkRmdmTFNKNW1BTFlRM3Y5UkxKdGhkUGhNcHhEZnV5SWlEM1
  Z0LWNobzJRR2EKICBTcTdpbU8tWmxLWkxQX2p3TzQ4QW5xY05abkp3Y2RLTUZoa3p
  aRGprQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJIZ0tJNVZjY3psUmkw
  X0g5bUVlYnlfWWxrOHpDVGxlTG1oemVXVm9ma1djY2YKICBncENsSTFoUkgzZm5fS
  lVBSlpxYXU3Nm8yQWFVVFB1My1EZXU5VFhhdyJ9XSwKICAgICJDbGllbnROb25jZS
  I6ICItcHl1a0E4S0pxZHZWX2hlUElLRlpRIiwKICAgICJQaW5JZCI6ICJBQVBPLVB
  VQ0stQUlZWi1GU09YLU9CSTUtWVpaQi1SVlQyIiwKICAgICJQaW5XaXRuZXNzIjog
  IndWMDRjckJhZjdoLTVmY2xWQUdNSXN5NVpVWm5LY3FiUFhEVWJ1WmZYWW96dUk5W
  gogIEItZW1ld25xMmF3dnB3Nmk3b0Z2Z1ktb1cwalFyVVlxSlNUV0RnIiwKICAgIC
  JBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"
      ],
    "ServerNonce":"qO9R3oT24EDO5GCYlYCBsg",
    "Witness":"2WZP-KNZF-JMKO-RQSU-WYTH-UU35-NWXV"}}
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
<rsp>MessageID: 2WZP-KNZF-JMKO-RQSU-WYTH-UU35-NWXV
        Connection Request::
        MessageID: 2WZP-KNZF-JMKO-RQSU-WYTH-UU35-NWXV
        To:  From: 
        Device:  MCVN-XLLT-LLNW-U4HR-BOMG-RA6Z-UWRR
        Witness: 2WZP-KNZF-JMKO-RQSU-WYTH-UU35-NWXV
MessageID: NCVP-LUEL-F3OI-QOAM-HND2-WG5Z-346D
        Group invitation::
        MessageID: NCVP-LUEL-F3OI-QOAM-HND2-WG5Z-346D
        To: alice@example.com From: alice@example.com
MessageID: NDAD-KLJY-C5JO-JGXL-VUWG-Y6PP-PSFJ
        Confirmation Request::
        MessageID: NDAD-KLJY-C5JO-JGXL-VUWG-Y6PP-PSFJ
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NAP7-MRKY-LGHV-W6C2-IDAX-ELNG-V5NT
        Contact Request::
        MessageID: NAP7-MRKY-LGHV-W6C2-IDAX-ELNG-V5NT
        To: alice@example.com From: bob@example.com
        PIN: AAIE-IVI5-54XO-5PHG-VE62-FFS7-62GQ
<cmd>Alice> account sync /auto
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
    "MessageId":"MDT3-TM62-G3XO-ESYO-WQZX-IR2B-YNHW",
    "Result":"Accept",
    "CatalogedDevice":{
      "DeviceUdf":"MCVN-XLLT-LLNW-U4HR-BOMG-RA6Z-UWRR",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MB5I-R24M-QXJT-KDBF-XFOA-DGC3-U3AA",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQjVJLVIyNE0t
  UVhKVC1LREJGLVhGT0EtREdDMy1VM0FBIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyMS0xMC0yNVQxNTo0ODo0NFoifQ"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJl
  IjogewogICAgICAiVWRmIjogIk1CNUktUjI0TS1RWEpULUtEQkYtWEZPQS1ER0MzL
  VUzQUEiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibG
  ljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICIwUS1aNWVESHR3V1ZZZGtmeVZUOVIzNi1yMGhPMWZVSFdwbUky
  bWRJc2k4MXNkanlzZ3NBCiAgZmRLb0hacEtJWnRLa01YU29Pa0ZycE9BIn19fSwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2
  VydmljZVVkZiI6ICJNRDM2LVE0U0MtUzRZWi1LUFJQLTdXNFAtU05SNy1RTUQyIiw
  KICAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1CRk8tQVhR
  SC1WRUpJLUo0N0otVzNaRy0zWlBBLTdGSFMiLAogICAgICAiUHVibGljUGFyYW1ld
  GVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcn
  YiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIkdDaHlORnVIYjZfQm1vZ3F
  FQzNfUjBhWGFlbW1EbGFER3lZWWRsMkZTQXc0RW5LakM4QXEKICBHbHB5N3NRYWNS
  Vmo0LVFiUUpzel9Qa0EifX19LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogI
  CAgICAiVWRmIjogIk1CVUgtRlk0NS1EVk5GLVhNUVYtU1FDNC1MVExJLUs1QVYiLA
  ogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUN
  ESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGlj
  IjogIldTZGxEOFNMWFdDRkhoSUhqQ3dRSEI3YjRZbTc0a3BNLVhWWm5GS1dZWVlwS
  GdCbi1KSUgKICAzYVBhSHpkNjBNSDNuMWV2Vk5Vc1RiQ0EifX19LAogICAgIkFkbW
  luaXN0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTUNCTy1aSzRGLVF
  GWU0tNjNUSy1UQTJDLUxIUVktN1FXNSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJz
  IjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6I
  CJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIktaUHktTzUtckRYTFRUbzlja2
  lNUjVtbE9qa3VyTUxSQlpXNVprVUpKOTdkOEhSdFRBQmQKICBMbjY2aU9mRUtDUTB
  zaV9sOE83NVZVUUEifX19LAogICAgIkFjY291bnRBdXRoZW50aWNhdGlvbiI6IHsK
  ICAgICAgIlVkZiI6ICJNQUhDLVFIM0QtVkxLQy1VVEZCLVVFRlItTTVWVi1UV0FII
  iwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleU
  VDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Ymx
  pYyI6ICJFbVNiaHFramdqWUFHUl9pTkh6R2lfU1JCNnZHbEtxZklzQ3lRdnhsVmY3
  OU5zU0VFaG15CiAgUEhxN3pKMUFJbDFlYWlkYVMycjI2M2tBIn19fSwKICAgICJBY
  2NvdW50U2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CVVgtWUk1Vy1OVEFILV
  VKTjItNEZGQy00UEFZLU5JNzMiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0
  NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJGZnZFcE11Y3dCb3hBT1NfLTB0WlVhe
  nZlNUo3SUJYb1hwakxYVFBEdW9Edk51ZGtzUl8xCiAgUkVmZ2g5SGI0YklwYlpqbF
  84bC1SaUdBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MB5I-R24M-QXJT-KDBF-XFOA-DGC3-U3AA",
              "signature":"Z935mSJZSJRi1kXTEsD-Q9AAkAu3IuD_-QJXHa
  8WVr2xMXcA-23dcvYx9duavojUCUVkKvl1W8iAsxPtl2n0HoAKUATgpSQmW1X28In
  4RZ9e60BCW7kFIqbADT4jF0fBOVI7bf15uh3coVtpXAtHehAA"}
            ],
          "PayloadDigest":"0_av1I9T_vQ-6biLixf0vQ-_JLiUttOyYnb5fP
  bqu5l3agCn0lgRFl8uGdSgmzVqzUSIxQl36g-SDrhwApbyEw"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MCVN-XLLT-LLNW-U4HR-BOMG-RA6Z-UWRR",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ1ZOLVhMTFQt
  TExOVy1VNEhSLUJPTUctUkE2Wi1VV1JSIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDIxLTEwLTI1VDE1OjQ5OjAyWiJ9"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1
  cmUiOiB7CiAgICAgICJVZGYiOiAiTUNWTi1YTExULUxMTlctVTRIUi1CT01HLVJBN
  lotVVdSUiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdW
  JsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICA
  gICAiUHVibGljIjogImQzMlg1b3NHMUtPRTVvbWZWTUZqREs0MF84eGJ5RTNrZlV3
  T3dUYlBXMXZJeW8zQ0NOdkoKICA5aXBseTFBMlg4TjVMejhXSXRTWml3S0EifX19L
  AogICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTURNVy1XQ0lSLUZKTU
  8tN1pINi1DTjNKLUtVWkwtUkxBWCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjo
  gewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJY
  NDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAibnRfcHU0WVJieXIwWUxNY1JXdmlNL
  XJUWlhXZlB1UVhWa1h0TWdud2hweUVXdjBHUmpsaAogIDlVcnBPc21jVTI3LWxten
  hJT3dTWGpBQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1
  CMlUtNkdNNy1QSEkzLTNVVU4tTElaNi1VVUdKLUlXNVEiLAogICAgICAiUHVibGlj
  UGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgI
  CAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJVbmk2NUVYY0
  RYYmVXaW1RbFk5OXhhSG5SWmpiSFpBS2lUNmRlZDR0MWp2TGpFVmhMb3lYCiAgVlF
  raWRoZ1lsV21fRHM2ODdPdUpoX1VBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6
  IHsKICAgICAgIlVkZiI6ICJNQklDLUIyS0QtQkJSWC1HNFBELTRJMk8tUE1ETi1XT
  1dBIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0
  tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB
  1YmxpYyI6ICJ5cGJTV1ZnSHEwb25oT2tUT1F4MUNkZ3dIRVRQTElSTVQ1aW1SS0pf
  MGozVzBKZnktVk5uCiAgOTJmTzZrSFl0M2dTb0hXSm04TXZWNHdBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCVN-XLLT-LLNW-U4HR-BOMG-RA6Z-UWRR",
              "signature":"FPjcCzr7s0FbUHrZOOhUGuesUNBJONX9Fe-C__
  87eykHW5UOylLhnfxfkULQVRIY3gdFgfLSJ5mALYQ3v9RLJthdPhMpxDfuyIiD3Vt
  -cho2QGaSq7imO-ZlKZLP_jwO48AnqcNZnJwcdKMFhkzZDjkA"}
            ],
          "PayloadDigest":"HgKI5VcczlRi0_H9mEeby_Ylk8zCTleLmhzeWV
  ofkWccfgpClI1hRH3fn_JUAJZqau76o2AaUTPu3-Deu9TXaw"}
        ],
      "EnvelopedConnectionAddress":[{
          "dig":"S512"},
        "e7QRQ29ubmVjdGlvbkFkZHJlc3N7tA5BdXRoZW50aWNhdGlvbnu0EFB1
  YmxpY1BhcmFtZXRlcnN7tA1QdWJsaWNLZXlFQ0RIe7QDY3J2gARYNDQ4tAZQdWJsa
  WOIOdulr0WkJsqoELzV6ZGITa3QJhpT6D22IPFeUSgiSp-K8l1msYOAPUExAKdsvR
  WgGhs_oOv7o4kEgH19fbQHQWNjb3VudIARYWxpY2VAZXhhbXBsZS5jb219fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCBO-ZK4F-QFYM-63TK-TA2C-LHQY-7QW5",
              "signature":"03oFK4MzMkSRYzgImz6WJw3JSZ4fmU7djU63aS
  oQWhCmzNDCf4XCKfx-bKoJesukT_VTGq5bW-AAWqO_2ZfO3pqjr5CwSH9yOKBzH0t
  pPFDAeKi7oBM43kk5rqljTNOf4EtcaiEqYFohIVoPbn75NAwA"}
            ]}
        ],
      "EnvelopedConnectionService":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTEwLTI1VDE1OjQ5OjAzWiJ9"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tA5BdXRoZW50aWNhdGlvbnu0A1Vk
  ZoAiTURCVy03TjVTLUpJWUUtT0JPNi1HWlROLURLUTYtRDNTSLQQUHVibGljUGFyY
  W1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1YmxpY4g526WvRa
  QmyqgQvNXpkYhNrdAmGlPoPbYg8V5RKCJKn4ryXWaxg4A9QTEAp2y9FaAaGz-g6_u
  jiQSAfX19fX0",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCBO-ZK4F-QFYM-63TK-TA2C-LHQY-7QW5",
              "signature":"9m0vcnmYQFNYfzGd0dEH605dJzn72QGwibh4j9
  LvR2skx_QmOz52TCT9P884t5KzVfAvOSdRFsUAfqm-Olo3vDDRBaAGbm9uBQ-1YR7
  r3B43OlHR1KnUD5IwqsbxN2lpFHNPzLt0fkmliATLNRd6UiYA"}
            ],
          "PayloadDigest":"vPLHz2roZcH2iYj7GhGYup4R1v4b1WDCOrAIO3
  R-hq5AVRT8FxVmvwhFK5TF8Zh_KFSti0qU9gP6-QliFCPnCg"}
        ],
      "EnvelopedConnectionDevice":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMTAtMjVUMTU6NDk6MDNaIn0"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0DkF1dGhlbnRpY2F0aW9ue7QDVWRm
  gCJNREJXLTdONVMtSklZRS1PQk82LUdaVE4tREtRNi1EM1NItBBQdWJsaWNQYXJhb
  WV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibGljiDnbpa9FpC
  bKqBC81emRiE2t0CYaU-g9tiDxXlEoIkqfivJdZrGDgD1BMQCnbL0VoBobP6Dr-6O
  JBIB9fX20BVJvbGVzW4AJdGhyZXNob2xkXbQJU2lnbmF0dXJle7QDVWRmgCJNQjRQ
  LU9DVjctV0RUSS1LRlk2LUE3VzUtWEdNTi1JTExMtBBQdWJsaWNQYXJhbWV0ZXJze
  7QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0NDi0BlB1YmxpY4g5juOAZ2RcHBqm9o
  YYcRAg8h4hPDUzGu0aYyTVrkOXlpyXUMblnSbyJ_Xj5KouRYnm3aOS4AtWZakAfX1
  9tApFbmNyeXB0aW9ue7QDVWRmgCJNQlZYLVVYTEQtUEg2Ry1XS1E0LTROTUItNklH
  Sy0zNVFatBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEW
  DQ0OLQGUHVibGljiDnXexA8QK1De4Ivy5Yaz7nO85iB8QWOGgntwgdARK7Oi9OafE
  hsyVyXISV887BxPL5rCFpmXsP2CAB9fX19fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCBO-ZK4F-QFYM-63TK-TA2C-LHQY-7QW5",
              "signature":"7QKcgJS4Ub14gYYjiBP3O1RC5U-tDs5mehOV_Y
  Mc7Rq4PV_I1WzTTZ5wnPPWdXxsS4-gjzlxra4AhMKYT4tN0z3Hc954sJVIAoZDHED
  bSxxeSWsp6Fd06hCa5Bt43tYt3TyEmnIHFgUmSFNIwIpOfw0A"}
            ],
          "PayloadDigest":"OstbMttGc4Jpw5qapxrMx_wAdIyJ1ozebqUCmW
  SrE0G_bbYLycdNVYq35C6hesgUUGwAItS3939DgezPSm9lxg"}
        ],
      "EnvelopedActivationDevice":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQH-KLCY-C4F3-VF7J-YSU3-EQFU-FZHQ",
          "Salt":"6K4bKrm5-_rjgI4_I08wTw",
          "recipients":[{
              "kid":"MDMW-WCIR-FJMO-7ZH6-CN3J-KUZL-RLAX",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"nvVIGPvOYsOJ8Ilm-19RbyLkAWivgWgZ5a-0A
  Rp9ftWFsoSSAqQSxaxWNMJr-X4HRTb65eFiuWSA"}},
              "wmk":"Dxo1wkjSF6txOOkZ3YtNDWzK-e_95sEbZay2cEJnm3aa
  Pt-oMy9PbA"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMTAtMjVUMTU6NDk6MDNaIn0"},
        "ki85WOQnh96OwNqp5BCXx-pDm5ZyRU7w93rIb9kZQVcO0mvkvuiAq28q
  zje1vLZ4b-XwiqY8MOCLqRkscz_PL8ALVscz5rBQz4JsCHtD1xCRMqkGOUOYeY205
  8lGpQ5MLZgNEeQCxORAlAdNrKRLvdUG6q2G0M9GOPzG9ocyhrI3D4P4T62_KJq9-G
  YmyHA7UEIXE04mCDn7dFWeP8lzsnpBTWbIFC4SNY1tOJeudypR01PQbkvFIn4whoF
  lUDgL",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCBO-ZK4F-QFYM-63TK-TA2C-LHQY-7QW5",
              "signature":"KHnfih_mZ14FUavWwY5vdhUFqu7WiBjh1hvHy0
  HTCQbdW35_6UmLcqTT2bzsxaEAXsl8yDTSvB6AK51Q3DvtVXp23AH4Try8p66EvNr
  azKWjh4CAr1QJnUdIJnu-Y3ja2WQJaseKmO4g2svNAXadhAYA",
              "witness":"TPxOv-bF8Of0cYXGhOZB-yJ5JRgwXYqmwciTxUQb
  BEE"}
            ],
          "PayloadDigest":"Mqa4f-6bQ07E2IYl2hQUqfXTighNhw9KF-WSEy
  mbPQMTqfXsXMgrExxUg4KCgPX1EYVt9k-UfdyZBWtFUxFNiw"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQM-73UM-YBTS-SOUZ-PADZ-SVFD-AV7U",
          "Salt":"mX9DOllVVNyFxJ9ocDg4vg",
          "recipients":[{
              "kid":"MBVX-UXLD-PH6G-WKQ4-4NMB-6IGK-35QZ",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"zxVZRX_9E5bQaBCq_T3de_j-6WWQvNH84u03M
  G7UfjtP6mDcbdopF3KuzMIebcuch8Lb7UtLz1AA"}},
              "wmk":"rg3puHIMXDoR7ATzOjfxsJUeIwk4Sb2-L5FzwvFVFk-V
  Hol4H35yhg"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTEwLTI1VDE1OjQ5OjAzWiJ9"},
        "gBlhcdXySmUZ3MHsR9XY0Opwp4zrqtnfvxnEI3SlZjq7dsfAPhHoVFOI
  MT7ArKsCojQ-Tikc65a4t0my5aDr-s_CQ5QQAlY6CKhsFW01hjTiTxZnL63w8XH59
  XrniVqdI5ehtVHRO36eiuDDHe97tBrCFUky2pZdbuLO9BDm1r96GsboXBT1vuCbXE
  Y8jJreAeroNhvJkCDFqq3mOhBC1Cndj1g15_MOPPd3KQ7rryOHoGpwN2DP2kicx8F
  S3jGLtuGdIDxXawAR255D-QesHwr5zZyHY3F_FkJ-1ga5OxKHOQtU-oRIdivpnYSA
  Lt2cBTTZJ0K2qzWkYgMLPRHxtQRIVvzGt80mlncUuoGSmyJprO-BSR0ow8N573ubC
  GUQzrfwHggM36L2UrPBzm5Ou8bX5IKu4iLjgE9Wq9J1bYuerqqHYJ6csZFiGUG1pf
  IGQTuNoFJWi49_NzI-vHpo3RBu_aXsClJo3Kgi8Wn4KJsT2rtQuCTbVLmt0Vja_YJ
  lqlJJwjmBSDNqPsitwZtvW2uVZFOwhFSxXI0L9ZZiyzWOdHccOtJnZkzJiKy4RaGA
  1ArpJ2Nm4MLbKvjDb4gJOvcL_a19qFlkhPWt56SySzGN95n5FQA8nRq2EvjQdJmGC
  OCn1MGFB1NooUWi3dXOeV2acHy8nTavVNEWVQeqWid5D2QxFSmV8cWghYn5nuFsy2
  OGNbIH-kNGxjt9W5IbQKowUvhAfpqQ3P-RlNMCEKzxZZioA6YeNG6Hh9kRAk2gYAm
  Z9LlISSOmu0pvavRb8rXW-mNttPmFlC8g232avdLyZyR9XjcjkzHBNaz-cVqKraQf
  vR_3M-8mIqGKCS_1oRYGOOpDIxw9VU0JCEO6DfBHFEv-2a3JDg8XvyRuZMIlzJFzO
  9usilNnsODaygIabfqA_Gs2qe_t4iAOq1a_yBRr0PW2Tba6BuuorLYmOxL9k7EzFs
  BUlkAHjJIdEixgwerVnmAnFXfXqKsc2tQ7LRRUkMfOQ3UCypn3niYn4B7M7eJ5efq
  -xXu4hWSzrdBpxwOUiLjb9ofvClQjkFWvi-VwRtKGIqdk8V-I2Wvc2nS8zzGaK0zU
  -8GnCP9eIe-1JKa2s4qPLD6ASA9QBz6IbtYlgi8HmEh-JfVoWwVdsSMOzJ-1V2ILx
  CN2YJIWV-q49xurbCDog4CFeHLvDPlSjMGYmofzcBHkwL-0H3qee-r6A7m4UuyDUw
  9LqyWyGzo0pjDkXCEGp8v31jxHI4P7NzlT4K2rN1CzYEnVrqYuqxLR3S-7ySnEQWu
  Fk4HrX07bQG5j1iNGghQVV5rQ-uk-7-1uFY8GIIUpiBsI75IwbCeaIvOiCI4v4U3Q
  vTR8ssVOgIDDuZdvQFRCMDgnTzbQda3isGT-fdrGkp5tX94a6ASuIWQ4jC2yqfndW
  y5NVkglyPEyVCPYVyaBI-SxSwzPtmzC3Xla4GVo7gMmVOALyx-7nMzxerc8HsB-hr
  S9bAgyY7V-cCmbQ6VEteR5GVYuX1Nu2w4aXWwU3-yrIx8NXI22Pe9DPcNtj44wySa
  BijiOvduLwnlG-b5aKxfjfvCJWfqL7kEZE0ioCSLE0y-cWPM3MsM3I0gwffEuy7-8
  b-nSMPGYjcCTbXoHBxmLt_-srSDjg89fSC4pLN9He2NoamM3Bl2ZZnItE-8vmQbH8
  Wy304nJNPGhJ_W2juLh758V9XqumJHrADHrjU4n-SOjRngrFjLwYVufxtrtGehcC_
  W2BzNnFhWtBRCA0A7Jjm8tjF0fHH7hxuaFDJKpIXYbJP2LqB8USizq_KRR6i6jsKM
  pxc7wG_81b_unXx1cPs9xMFdQWnn_2Izc7jXKJYC6cVNOGH3dQDZfIgL4O2KoFXzm
  7goJ8hE1Hqx3trdsEjKC7c1UM-cdxFzNKmrto64I7kjJdVHpswFleKSHwxgQ93sLh
  J38mq2FKYQP_rMp40GgWABCtY78P-XZoc6Mev5bBWxN7NL3WlpnrZKTgJGyz92Ori
  bPQPz4Ma3aZ_3WqipO15r9QDZWWjsFzZnGSXpDnXh0uHBtqcqlu87y4LdmHkKgQqZ
  PCioP5KtpgusscKBbIhkQTHe4oe7zUEiRFLd8ff8fp0LImOnmo0WDrMgS3p96driz
  9d9FaUWOFP0rK2OnWVZ9PhvqEzLERr99WVTJ68ZITE5NoaF1OwLGdgWFYs610VJoQ
  jsXZsT0dmR0Zj-vl6yei8sVZjFLosjst9uh0Wv7k_URAUEE95p-Ty2ZLjmwhWeWNS
  Siw4Qk_LwlkxRxSuuad9RfGumOydUrsKh3I8qerv0PmHz0WD4ZHAqa8c9ZLitVX51
  WC0BeLD2iaExGdjThfnO3sJh1CC0R_SqbCV6xSmkcfN_iCEKfE_d-3Twwp2cVKJ2l
  gEvTwsbYX4PkbI_P1SzChkrlC6sn1EBsk7-tnBngnU_OVhUIq2Dxjv9KrrR3pa3DJ
  3s471xfSZpNywnmjxFFv8uPAczmBPf_5BSC5ikub2nT5UTFmUNlAERh5XoDmDZJsE
  seikGCNOyFh0ZLdiLYgL6cUpFw171QZILt7v_1a6e2wKw6gMc_9k74qTEISlLyuVP
  tNz7PryNMyVG4aEwKQMBojHqUN5R8zG3X-KxOTD7PCV9ZtgKiP9SvdzBLzN9wW5Y1
  3zGvi3f256i5vOIeO73nE-mEeTDtBdH2WTjHUPtTmTwvH1TruHJlMhV4W5Zs2XjjE
  _MsrFxV5enl3koNMwAfu0TgPpLZI9xKu6OwXwwcc9XHPQVUPUJK2qAWD1R6Dms2kd
  hmXoLC6Hia5w9R9jSnei4SNyvZAfkKH1peZHHamxeHBEZObARFnxFXq77zp9H9VqF
  pALocgAYXbuUBU6FHPIWXF1-xR4IGjswPgrKq6lA2QKsf9D7d2hheMrB0KZR5k8fV
  K5T5kRhICgu9NxErQkvf2RjfGk707lMmDdE-g8L27AxNqdku0wxRGFIUxcaVutXAB
  5cHH3pKrIJfZfEfAggDooU8RMUI20J6IVZxyZ8nsTdT9ECZuoolAoXh1C4_w-zSpr
  5A6WTLzYTLpnyChxueFeWD-qQWjzXjeN4b-aqJUcO89xEZ4AfRGE8xMeIWp72GzKE
  vMhXfL5v-zHOFJUJ-yenAkROt33qTZH2OlxMVFqIrtW_wTW7-y-B7wD9RHI67tooH
  3pm6QYFTkUdJu0nL6FV9WN28zBVPRuS0mJEm_MJXzUr5fLY7SCDbGOAbxy-a8B_yQ
  40xDftA7FNu4Ylugg2Si5NNBwoXCaWfmF0wy_0IMZhXudDTgI30LwNqpLH1hFOthv
  DKGJn4qPF-wOu5QaeRdwJgpiOE_XwQI2Xsx8ONyb7xGysaY04xtEiZALwcHO57454
  jnbJpAdoOAMLZHRiOkhYNoyjp_SRxZqr3pB27SFzCzlP5s7EnaSd79hIfKY7Ii5p5
  JjTZRKcVMF0Ger9CuuRPccR0hS6y3yCBL5VUQ_OhKmWYPJ9vE3mRz7h037cBJkVbB
  eiBOxT-EpNko9JWHtvdOjDnUPK2W2Q75R8qpvvLSX2jWibqsdvBrm2TkTXv4jx0JZ
  I-YBZZ8AmA-AQlu8-oEafCHvL65sgu9qpmTGt0NI6QO_7Fbu2WKeUuSTugbL7q2EN
  u1jQAzz2itiF9GZ9p4ol93FjsK0tiRjyoKlqSsEAa_fBETnTzmlhblMTRwNEwoVQ1
  _kygDezz0fuklkICAwLgHl6wLc_9oI3gGyS2W62dRvsIDcz4mmMsMkJizqdDNxKBr
  TJrkpWJXulKozk81xjbECG8Rbic_QGwbC7yyaiYxU9lazb7VMnlnSKwitx4GxgXN0
  nKISYPHO0jnZLMYTvhog3mbIqqNrcJGWRmEl7sRJa2_k84FI-MOEESYxaCndq0CwS
  atguRggOlY8wVFNkdAUdCT-T1j43eTVcKPqGrTB6rDxhAClHkFfwW8bIrRenLmxMW
  HplKju7xbjCaj-3Usz6v5p_-0TUdlFsoPcEU3Cb_b4LgvyvZA_stq1TbQoyctrVQA
  OcSxFX2-aImyJYuyKkyMNTKmQNgv62f6h111QO34vPZqrLgArTgpnQhu5eYEgymfU
  empry7SRLkwQdywml4jeImqtZ-AfzM3Test1FsU2xGaMslxrQz80h2J8FHzOkxTAP
  CUs68MNOXRUChYzUvRespSXCPzisFFmZWJkFAFyNayWVHPRxcWADHTJWKlc17NS1j
  b5pprmqCynRE5AbPIeDMEGx96r57nIb63l6TadwQMFiQHDiaHOdP1EAREPT9tYURx
  JelgcpNdqWELXkGGkUaBpZoF0Wh3aHJMd3beMG1dZaMkY3hMCagpeoArs4w96393w
  gQik5AFeh22kJdf2PaRAvakmMsZ9PvvyHzTRVKj0kUyegloQH5EpOheYfmXcQL2Hd
  p3_LMAIfZtT9EJ7avVQCftCaDVhAuJtVAOTUzZUTw9y5DOFXoCD8fQ0NzeAywhP-G
  XK3Bm3duH-T9BlXN3NC3hbKKaJzVkgJuVDihWuMB5aXKj_R65vLIxgx8Z4V1qYjQf
  p9vIcENaDKT0j6qRjlnwwKdPLeJQfJBqBvCU7RBXZr7k5mCLSbMij3GZWyvpb6FZ2
  ekxJO9O2Xov1-EcOPATjqFvo2ZqhLqKzGzvAa8l-blua10eF50OOYd32uk5WpY7Xl
  kcSjE8XKfCPmh-sVkrdxTV0bB-1mwbRkcofJh2SFBTvl2D9MgP13dybD3hh2Ab5fE
  02rc1kJx4kke4p8LykCpRP8KP9T1ZRmy03GxpCjW-Q7_165ZciX6JCs-_OQoTgn9R
  9DBX2KcvoBEHOCu5GJczfd_j6dS5KgLz_-sI3xLFjaKEyRdpJHlfNMv-ca9m-yCZr
  l7Rk_kHb-IxPa6DA9t-EwNvE4PKGbt9WUqYPDBUV2hJyQrIevSEqH84sSmY0ycvjN
  -ORwv1JwE0okT7uJ7TRgxf2eSGMkXJQx_FVnsj5pz_EPxMj72zAXlr5mUvFBEzlce
  Qlvwcc1HQ8_JPASkK_e1hiq7nABmYfdfAR48HKdzDxFCVd4e87oeqsQrYeaLm4nM-
  ojNYBQJmbWwhewiRai-CK_K3Q-PYlbhPvmzIbp2yE79EawtCNBTPn3myWo79ejxdY
  CekhJRdevRCPsCKTg3Yuj8m59IPCkG7-p_GFFmPnF2zu7QAyllNID7wbr16L5xqJC
  r3YYu-xHEbN8ovNXbusNCtKEBss2Evn-XS6zq4Spci8gOH7V5Pv9MK8G0MuPkbssc
  jkqc5IqsG-YVAiOtI0bn6RCqqwoQV16QfLpY0NNP7KMBjRxsspERxBd05o46xAuzZ
  jYs-JOSbR3vy8z6-lIAJEPViw2po8DnuXccwrMns2p_unIiwWqHgeUbau6MsEO6aA
  BaboDrE-aqQhlb0YcTgZmcznFOzghmlZ9X_HokeO58KT9uVR39h6o-ZPzctnN-e8c
  U07EwjWUkyGgUoYNI6MWW9J_z_pUSBYydjjm2jQchV7CcdNlUBBlid9lZbOQZpwwJ
  _RcUfTGv3LvUnUT7SxNZL2QAzFlTwXQGrVmEUzhPUxeu7m4WgQ5kTrOpoF2T2Xt8p
  QvlCnzMlz9y0akQtF8bkQfdwj_JJTMr9EGRrnkq99xmHUdyzxPWhSx9RzhPJPqEK2
  qiQxAs8Uj60m6lnDoyqmCRpjz5u5WG-lB6EMXATOVnj6Mkkylsmwb-ZiBOnPS3n8O
  m2Ua58ULY1_e5UpPsdPZDRqN2ypTgy3IFoFoXf6RR1L32us3-SoYLoqdZRO5tDzcn
  ARzlrRVomW7CoVEsHhP_IOcpy4QvK66_K3dVLQnrGoFsJHAD2AZ41f4yyQ0qy7NVT
  C8qTVyC4tJ23rQl4E9UZ0FgnK6REMFWq-UhEUrVTZWwwbLaGq1OH_cAFk9DXRwbVM
  Z_ty20Gd0e_JKFQ8zSZJxtqwFPzb2hVINzLhgeBOYfH-ExmeW4vy5THHhvfKAIL9h
  5CKGCqztEyUIpsZLOkN0NEyDHZrN2oshiq-BACnoMcE9q0z18JeNxKnw-_u3pUEFP
  JNyvWpROA3if7-lEu7bO6Rh0kmDnlU0f1kBWwsWDQkA6tdD6hwiYg1U36XuTLutD_
  FfR7IBnQqBx_QWJJzLnMyz_nkQHki1uIlWHHabOzuVbcSAH4P5M7P4Z6XKE0oLgG0
  wGFgK5MJYOC2wSGBgXIdbr-GJGp4wCZ2mGZ9zE8DW84cZWYs-Nv5rmrgrcPUEsK9W
  MXDj-T5Liqo3y8lgHuOyNjGAkYM4M9ysT-XJBHNxYC1a5SxJtAM8IxAx-ba-uOtby
  nkV7X5ANUblK03bAUlmDgndmtA3kq77ykGWL1TjT5q8O5bTe3mxWwoT724EV_rUDl
  Nba99vzfRVxtyNDxBgOZsBJUP4IghMZJm--bQ9jq28MGduAHtgicra_hzOHs1kuWw
  1qh6vsmP6RmR7R4_yDNoQl6ccHz3_DLzd2oAlWCIJ9Mi1xuP041zJ6d42Pv7w9tdb
  vDwlavTq_1n2JF2pnC-nC6frxXepuIG0eDdq1bVBLrrq0LG_HiBEZqVZFfFOMY4et
  SNcUujrtzBGqVCJbLbrkairiozJiOfW324VKW2ESFgiKjmW_gmMckQAqwsXsAKdib
  VP_pwQ9Cl9ZJGqVchgFxgmXbfCZsmPSkajWHg2YlJcOEE2vXZsN5e6dkjm1Xck2Ng
  xjRxMg54-vO_eA9UJkX8EIGeFHGvlqs43Xoi4_3JqUy2qwhFI-aPuoi0CORf-nXS4
  Ahudwcqh3uCn-JwrI4dRG4XmFhniEFS8PO4-ZPB0J-xQNGtg8qZxxSUeoMIMSITKi
  GN86Dd1tPnWBU1f5EWz0xlEOZuhteeaIkRwB1l-pBSWA-2jiHadqetS7LqMsDYeBk
  uwTehlcqWXTXuGEENiRLTWtjF6MTV84kkUuN8WsnKJ87f0Rr9oUwbDwjcJhFfV5TO
  3xWZbvL97I-ydU6h-45QoTW2myGD_OdKHzT9jEgGNJXmmdMYECAjUUdVuO1-wecfT
  VqytzQ_aYb2YbtRHwMY5D_gSj6WCqCxmnL3coPXrMcbyaRUHWzxouN9u6A2fEq-Xg
  pXDloJzlamml5NRxaYGTvAgz9wqxMyQkqsLrMri3qeGVAX1ZGm4OJREo5gbw7eSgK
  Dkz1a6O4Da6aN1GVcTtpP4oM0Cu2IsFNII2nmqawJ5iaG_U1UtD_3uwX6bjly6YAy
  m5q4YNprmKyFFwyJIPFmtd_B4QEoZ65MTcp_EUDtzFql2TLv8GKPqmvySkammIVFA
  A3eHDDusfQEI6CyaCs_DG_wmtTQkSncCmJBvWAKgkZgPkwTXtOSmjOSOxH-L250mH
  3DJhGl4PvsV-zMvcsoPhb8oENH_BZVeolpbHCL_YBFIbp4N3PlbJHZdhMLB3wgO4G
  JLs8Dz0Jl21DL7m3F997TASwyDdDymk_LzjND-T8V7YYQVVT0mxRnK9jefTF_C4YR
  mlYhN-6HA5SKYtMLRSMNNyWyYgeUMCK9m2jXW-AMc11lIkrshhb_JR8sjGR5A97_R
  qVc1AYBmaCmHiChlb39YzhEWVovNQDvTfqLwlgM6WXXN7BMrDmv898t028AEDQaRJ
  dWSCwNXq2Vs7P43gr-Vo0zf6ZErqs6S1grgPaqgpZqoKSlGbH84d_RcmDQqzhsXA0
  cR1g6qgj3w6WJd-Ft8H-JxJjEOnuNpwgVyj2Uht1-3kXC0kUTHGCZL6Wx9p4kqxYa
  GQi5MVzYg7AolcPjGagR2l0UdD5nTJdkputAIDZZ73PAFJ9H1JuZPhH7kD8eJQJyy
  Broh_pnBXpgFi_6SZVJCh5NJWErajfFibPBePkpDrXVyehFzTJw1Jzsq-rPbL_oIo
  2N08_i7GpDjSQlDI2ENkEvdMrX6zrIWoP-FbFT9U-xij4FQWiNzg4Ww7c1d7hU8lI
  4gJQSY5SzV6eSdxlSYc_6C165E3F5eN2FBSUi3kPy-jIwmQVJ59UniV8eCCBEtPDp
  nT40gCQaytamAOIATcP8IK5HRQQIksmgcZxtYITyiE0_ZK_30sSyo_Bft-USwa8MF
  0w5cEQTBsKfyGYxOr_8Wo_4N_rrEvbvJTDMWow5BTcvE8vq4r2FnXNFC4xUdy5Lk5
  HG7XKNUKeZQSTkwP0Ry95Yzw8Be4qovtYmm7UkGiwDNB_abRQGnb3bQcrZv5GXOH7
  TlDUE2m0n9BcG3W_oqCESdXpNL-w83u-puP_vF19I_maOkUtpyUWJXXj0kRd8c0WF
  osuYsGg6sIy_nC2ErgEQPDvuAL0cq0Qkc8gX9SckW0W3vOPxAkQdYN3eMt-k13Afs
  y7IePBNP_hXordX3WdkAK-55A7JuPBN7zW5MqL96jvLCJk_10ms66e2Ae5MK73Wpl
  HXQl3IQ7JwCAqXdb-uOMfdViIs6a47y7EXJikZNacrKthzunoyD1F8cZ6wL4ecRTn
  Jsl_2jstlwKcZEuEcvZGAvPqzIl9qhYqEw7O8MOWQMS8cDAUrAb0etfbSmDNWwQR3
  RgaMM6BuevUgFBdVAvf_wvI9994rQRDroeipduhis8xvFDVD_pH_ZpJEl6eQpijxA
  tIdtdap3kwib1gylmAxJ6-zfImOBJo5_aBszjOJWiMmB3Cd0",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCBO-ZK4F-QFYM-63TK-TA2C-LHQY-7QW5",
              "signature":"V5h7pFoycR-2WNj7rSO8cyfzbrMHw8GeyME3Wp
  wnFW9a0X1f1FbKuRAQzgo6CAQR9CmOffm92lqACM-DA_Rylu0zKWbq3PK3u2iRrJt
  YZ4RyqDam8DoaDEejYJTz7CtKOh88q62L1iF7QirYhqLcWicA",
              "witness":"KqVrOTlFoo8dHQd3Slg-eowe2e_9OaoPHfDB4Duy
  Fo8"}
            ],
          "PayloadDigest":"3-0c-MhvBsyqxImZbVhOiLXXtd8Av4Rj8C-zOF
  BOutKwzhvOdQ_x5Y1DV7tEM1HQeIZnzhdber6onFEVlsdSvA"}
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
<rsp>   Device UDF = MCVN-XLLT-LLNW-U4HR-BOMG-RA6Z-UWRR
   Account = alice@example.com
   Account UDF = MB5I-R24M-QXJT-KDBF-XFOA-DGC3-U3AA
<cmd>Alice3> account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MDT3-TM62-G3XO-ESYO-WQZX-IR2B-YNHW"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

