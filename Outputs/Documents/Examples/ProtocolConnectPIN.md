
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=AC6L-KOKA-W62V-54R5-MU2D-KZVP-OA
 (Expires=2021-12-21T14:00:30Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcu://alice@example.com/AC6L-KOKA-W62V-54R5-MU2D-KZVP-OA
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AC6L-KOKA-W62V-54R5-MU2D-KZVP-OA
<rsp>   Device UDF = MDEH-DBMY-63NX-TNKW-NRWT-ON6M-EOMJ
   Witness value = 6PSU-AAB3-LGXS-E6ON-75LU-4LFP-YPNN
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "MessageId":"NBP2-O5PS-KEVK-VKH4-6QVZ-WOSA-GNN7",
    "AuthenticatedData":[{
        "EnvelopeId":"MDEH-DBMY-63NX-TNKW-NRWT-ON6M-EOMJ",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNREVILURCTVktNj
  NOWC1UTktXLU5SV1QtT042TS1FT01KIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTEyLTIwVDE0OjAwOjMwWiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTURFSC1EQk1ZLTYzTlgtVE5LVy1OUldULU9ONk0
  tRU9NSiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIjhPQVBoVmpsYnVoQklJd2hLNTExNVNPWjJsNGhwd3JNQzlmZ0
  lWTnpSSzB1MXd2VFdmNFkKICBra0ZDR0E5SUg0Q3lFakp6d0NwczFlNEEifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTURQVy1NQ1o2LVBVM1gt
  NjdGTy02RDdTLUVZRTUtRU9QTiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiYmRjUEpSX1V5MUdYX1BWQWJtR0VybVZ
  KdXpsZlBVWmRNY1lac2xFUlZMWGxjTmI2bXFPTgogIDhuVjFLa1dtSTVzV1BoVHBP
  Qk0xTEphQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CN
  U4tUU1HNC1OTjZVLVA0WkstQ1lPRi1MSEUzLTQ2VFkiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ0cHliQVdLM0Ji
  UVNEY0Q2elE4TXE5aXlYTGRqMjktdFBFdF9wRDFyakplb1RMbFJNSmRTCiAgSEZPM
  1Itd3ZHcm1xRWd3MUY4X0g3YXVBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQzZMLVBTUUstQTNTTC1WMlJKLUxYMlYtUEVLUS1ITEF
  EIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICI0QWpwWFdIOWNnUU9FampPYmR0Z2ZOQld3NnZ6M1hqQzI3bzVKMHZRTl
  dXZmp1WEFJdWhmCiAgUjVNcVhBSUFiRzBoWXM0N1JHczZJZFlBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDEH-DBMY-63NX-TNKW-NRWT-ON6M-EOMJ",
            "signature":"rL-1XzDFvvzlJVqpCLp74UEwtlPFwe6b7K0Id085
  9MZOT1uIsmHg_Oyoh2fWAlzbqlRYQ6ig9MsASP1fJ9A0R7E85H1pgz9BK8LmHMQRv
  LMKQ3Ru6tub5Y0JaH1_aq7UUuIyA67vxqfVWt-TPDIEKjUA"}
          ],
        "PayloadDigest":"BzSUFcb94_mWUijjmo7MbbV06KDa9k5albZ6XzZq
  4jyy8P78DoUPP3iXE6fQzUJQrWRxRuXd1BSfEbYFGyCrcg"}
      ],
    "ClientNonce":"moNM_xxWRtBRoULYOiO_Qg",
    "PinId":"AB2R-5TDM-EGPB-GDBC-IAR3-WPDV-BNUI",
    "PinWitness":"v48fK1I3fcuQgwcf1TZicWqJTwr5H1g9UmYgSahkZGnQBh5
  iZkEtwrr-1cUZgOUi3ALF7AHlz28SUYMPE7wpjw",
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
    "MessageId":"6PSU-AAB3-LGXS-E6ON-75LU-4LFP-YPNN",
    "EnvelopedRequestConnection":[{
        "EnvelopeId":"MAAA-NCTK-HBKV-EOG7-VKS4-5YMK-P7II",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQlAyLU81UFMtS0
  VWSy1WS0g0LTZRVlotV09TQS1HTk43IiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyMS0xMi0yMFQxNDowMDozMFoifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJNZXNzYWdlSWQiOi
  AiTkJQMi1PNVBTLUtFVkstVktINC02UVZaLVdPU0EtR05ONyIsCiAgICAiQXV0aGV
  udGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1ERUgtREJN
  WS02M05YLVROS1ctTlJXVC1PTjZNLUVPTUoiLAogICAgICAgICJkaWciOiAiUzUxM
  iIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI6ICJld29nSUNKVmJtbHhkV1ZKWk
  NJNklDSk5SRVZJTFVSQ1RWa3ROak5PV0MxCiAgVVRrdFhMVTVTVjFRdFQwNDJUUzF
  GVDAxS0lpd0tJQ0FpVFdWemMyRm5aVlI1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxk
  bWxqWlNJc0NpQWdJbU4wZVNJNklDSmhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV
  04wSWl3S0lDQQogIGlRM0psWVhSbFpDSTZJQ0l5TURJeExURXlMVEl3VkRFME9qQX
  dPak13V2lKOSJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V
  3b2dJQ0FnSWxCeWIyWgogIHBiR1ZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNK
  VlpHWWlPaUFpVFVSRlNDMUVRazFaTFRZelRsZ3RWCiAgRTVMVnkxT1VsZFVMVTlPT
  mswdFJVOU5TaUlzQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KIC
  BnZXdvZ0lDQWdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0F
  nSUNBZ0ltTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmli
  R2xqSWpvZ0lqaFBRVkJvVm1wc1luVm9Ra2xKZDJoCiAgTE5URXhOVk5QV2pKc05Ha
  HdkM0pOUXpsbVowbFdUbnBTU3pCMU1YZDJWRmRtTkZrS0lDQnJhMFpEUjBFNVMKIC
  BVZzBRM2xGYWtwNmQwTndjekZsTkVFaWZYMTlMQW9nSUNBZ0lrVnVZM0o1Y0hScGI
  yNGlPaUI3Q2lBZ0lDQQogIGdJQ0pWWkdZaU9pQWlUVVJRVnkxTlExbzJMVkJWTTFn
  dE5qZEdUeTAyUkRkVExVVlpSVFV0UlU5UVRpSXNDCiAgaUFnSUNBZ0lDSlFkV0pzY
  VdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGwKIC
  BGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0F
  nSUNBZ0lDQWdJQ0pRZAogIFdKc2FXTWlPaUFpWW1SalVFcFNYMVY1TVVkWVgxQldR
  V0p0UjBWeWJWWktkWHBzWmxCVldtUk5ZMWxhYzJ4CiAgRlVsWk1XR3hqVG1JMmJYR
  lBUZ29nSURodVZqRkxhMWR0U1RWelYxQm9WSEJQUWsweFRFcGhRU0o5Zlgwc0MKIC
  BpQWdJQ0FpVTJsbmJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxQ05
  VNHRVVTFITkMxT1RqWgogIFZMVkEwV2tzdFExbFBSaTFNU0VVekxUUTJWRmtpTEFv
  Z0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljCiAgeUk2SUhzS0lDQWdJQ0FnS
  UNBaVVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjblkKIC
  BpT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSjBjSGx
  pUVZkTE0wSmlVVk5FWQogIDBRMmVsRTRUWEU1YVhsWVRHUnFNamt0ZEZCRmRGOXdS
  REZ5YWtwbGIxUk1iRkpOU21SVENpQWdTRVpQTTFJCiAgdGQzWkhjbTF4UldkM01VW
  TRYMGczWVhWQkluMTlmU3dLSUNBZ0lDSkJkWFJvWlc1MGFXTmhkR2x2YmlJNkkKIC
  BIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlF6Wk1MVkJUVVVzdFFUTlRUQzFXTWxKS0x
  VeFlNbFl0VUVWTFVTMQogIElURUZFSWl3S0lDQWdJQ0FnSWxCMVlteHBZMUJoY21G
  dFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZCiAgbXhwWTB0bGVVVkRSRWdpT
  2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0lsZzBORGdpTEFvZ0lDQWdJQ0EKIC
  BnSUNBZ0lsQjFZbXhwWXlJNklDSTBRV3B3V0ZkSU9XTm5VVTlGYW1wUFltUjBaMlp
  PUWxkM05uWjZNMWhxUQogIHpJM2J6VktNSFpSVGxkWFptcDFXRUZKZFdobUNpQWdV
  alZOY1ZoQlNVRmlSekJvV1hNME4xSkhjelpKWkZsCiAgQkluMTlmWDE5IiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6IC
  JTNTEyIiwKICAgICAgICAgICAgImtpZCI6ICJNREVILURCTVktNjNOWC1UTktXLU5
  SV1QtT042TS1FT01KIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJyTC0xWHpE
  RnZ2emxKVnFwQ0xwNzRVRXd0bFBGd2U2YjdLMElkMDg1OU1aT1QxdUlzCiAgbUhnX
  095b2gyZldBbHpicWxSWVE2aWc5TXNBU1AxZko5QTBSN0U4NUgxcGd6OUJLOExtSE
  1RUnZMTUtRM1IKICB1NnR1YjVZMEphSDFfYXE3VVV1SXlBNjd2eHFmVld0LVRQREl
  FS2pVQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJCelNVRmNiOTRfbVdV
  aWpqbW83TWJiVjA2S0RhOWs1YWxiWjZYelpxNGp5eTgKICBQNzhEb1VQUDNpWEU2Z
  lF6VUpRcldSeFJ1WGQxQlNmRWJZRkd5Q3JjZyJ9XSwKICAgICJDbGllbnROb25jZS
  I6ICJtb05NX3h4V1J0QlJvVUxZT2lPX1FnIiwKICAgICJQaW5JZCI6ICJBQjJSLTV
  URE0tRUdQQi1HREJDLUlBUjMtV1BEVi1CTlVJIiwKICAgICJQaW5XaXRuZXNzIjog
  InY0OGZLMUkzZmN1UWd3Y2YxVFppY1dxSlR3cjVIMWc5VW1ZZ1NhaGtaR25RQmg1a
  QogIFprRXR3cnItMWNVWmdPVWkzQUxGN0FIbHoyOFNVWU1QRTd3cGp3IiwKICAgIC
  JBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"
      ],
    "ServerNonce":"FUvOn7vuYOdgUMW4IHfJUQ",
    "Witness":"6PSU-AAB3-LGXS-E6ON-75LU-4LFP-YPNN"}}
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
<rsp>MessageID: 6PSU-AAB3-LGXS-E6ON-75LU-4LFP-YPNN
        Connection Request::
        MessageID: 6PSU-AAB3-LGXS-E6ON-75LU-4LFP-YPNN
        To:  From: 
        Device:  MDEH-DBMY-63NX-TNKW-NRWT-ON6M-EOMJ
        Witness: 6PSU-AAB3-LGXS-E6ON-75LU-4LFP-YPNN
MessageID: NBLB-D3DX-6Z6Z-PQCS-4NEO-RQGQ-HQUL
        Group invitation::
        MessageID: NBLB-D3DX-6Z6Z-PQCS-4NEO-RQGQ-HQUL
        To: alice@example.com From: alice@example.com
MessageID: NDI6-772L-UUBU-RIFV-S5GM-3B3J-4LFV
        Confirmation Request::
        MessageID: NDI6-772L-UUBU-RIFV-S5GM-3B3J-4LFV
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NAHB-XJ7W-IEJY-NB4D-27UK-Y2HS-WPEA
        Contact Request::
        MessageID: NAHB-XJ7W-IEJY-NB4D-27UK-Y2HS-WPEA
        To: alice@example.com From: bob@example.com
        PIN: AA3C-HQL4-JNCZ-BJTD-IVOS-G5KU-2YIA
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
    "MessageId":"MBCD-GVMP-QCXP-42SZ-O2LT-WL2B-UK2G",
    "Result":"Accept",
    "CatalogedDevice":{
      "DeviceUdf":"MDEH-DBMY-63NX-TNKW-NRWT-ON6M-EOMJ",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MDKO-KEIN-OCN2-C6UB-VS2K-TNA4-WXVJ",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNREtPLUtFSU4t
  T0NOMi1DNlVCLVZTMkstVE5BNC1XWFZKIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyMS0xMi0yMFQxNDowMDowNFoifQ"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJl
  IjogewogICAgICAiVWRmIjogIk1ES08tS0VJTi1PQ04yLUM2VUItVlMySy1UTkE0L
  VdYVkoiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibG
  ljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJpTXpib3FwM0FwRlpoYmRpeXY5UVdvZGpsMzQycUM5RTFNOGF5
  OXViNHkzVE15bDQ5RDBUCiAgdV9NNEV4T1JpNXZudWxQU0N5NE4wTS1BIn19fSwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2
  VydmljZVVkZiI6ICJNQ0NPLVpLWE0tVlZZVC1VN1NELU9IQVYtVVlKWi1EQ1NBIiw
  KICAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1BT0ktWkg1
  Ny1ESVVILUtYVjUtU0JNWi1PWVlMLVdIQzIiLAogICAgICAiUHVibGljUGFyYW1ld
  GVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcn
  YiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIm1pUTc5OUN0aXpvbmFSQXR
  hS3N4Z3VreXY0UjlXaU1YQ05nTjllY0FYd0VDYXYtYkxUcTEKICBQZVlZbGliY2p4
  SlB5NjdyUExicmdVMEEifX19LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogI
  CAgICAiVWRmIjogIk1DR1MtVDZQUi1ZUUJOLUtaSTYtTFVRTy1YSVZJLU9TRkoiLA
  ogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUN
  ESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGlj
  IjogImNsYm5ReXFTU3A1U1NQVS1YaW42ZGpwZUR5Vzk4aEpxY3VQSEwya1hXcThYZ
  2tBV0xRSTgKICBtWV9PckZTb0tTdFAtVzd2NGwxNmpVc0EifX19LAogICAgIkFkbW
  luaXN0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTUFNUi1US01RLTJ
  BNzctV1VHNS1DSEJCLURSMlItNzdGVCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJz
  IjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6I
  CJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogInNEN2treVdyeUVvRkkzLVZzeH
  dzRkJTNk9TcXhVTTJOY2JzVS1paldkQ3cwc0MtS3BrLXUKICBhUk02S2hNYW0yX3p
  meU5Ja3UtTUpmVUEifX19LAogICAgIkFjY291bnRBdXRoZW50aWNhdGlvbiI6IHsK
  ICAgICAgIlVkZiI6ICJNQlpOLU9PRVItSklXQy1DM0ZNLVVPN0ktQ1UzNS1RSkxPI
  iwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleU
  VDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Ymx
  pYyI6ICJlS3JsWVJBMTdpVVdoWVNpeHVmNmk1VmRVTXgtcGFpbVVYb3ZsdnpkM1hC
  QVZ6QjJWYk1DCiAgV0NjSEtwa2c3SUtxYlJRSTRGSVZnV1VBIn19fSwKICAgICJBY
  2NvdW50U2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DRUQtUE1WWi1MNEJFLV
  dMSlotMlA0Sy1RSU5NLUVITTIiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0
  NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJBRjV1NlpGUERzc3plRTI4S2dVcG9Ua
  mRndmVHWHJnTkJ2Y0JKSlpmWS15VFZLT2syTE5uCiAgb20wSi0tRXRRSFZNRHFVaW
  twVGdPaHVBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDKO-KEIN-OCN2-C6UB-VS2K-TNA4-WXVJ",
              "signature":"cvqYlMVwIALwWn52zUGtYKtYjwaaEyuSWJQVM3
  1sbhHV5afIvlDAZKMQVf9mwMMXby5KJ1jsaL0AWT7HejMuaoNzXX9jkFR9aFKXgEN
  6gjwX3C_4EW32y7E7xHA7uym0mQcrt4wuxXZ5susRIJOJcwsA"}
            ],
          "PayloadDigest":"IXngV7F7UWfa_FxaAEh_EtlDBtSG2b8FkifmDf
  P-avur88kUHdLw3jnfftch10GxeNGkw6cjTCI9ZEqMcxhR6Q"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MDEH-DBMY-63NX-TNKW-NRWT-ON6M-EOMJ",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNREVILURCTVkt
  NjNOWC1UTktXLU5SV1QtT042TS1FT01KIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDIxLTEyLTIwVDE0OjAwOjMwWiJ9"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1
  cmUiOiB7CiAgICAgICJVZGYiOiAiTURFSC1EQk1ZLTYzTlgtVE5LVy1OUldULU9ON
  k0tRU9NSiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdW
  JsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICA
  gICAiUHVibGljIjogIjhPQVBoVmpsYnVoQklJd2hLNTExNVNPWjJsNGhwd3JNQzlm
  Z0lWTnpSSzB1MXd2VFdmNFkKICBra0ZDR0E5SUg0Q3lFakp6d0NwczFlNEEifX19L
  AogICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTURQVy1NQ1o2LVBVM1
  gtNjdGTy02RDdTLUVZRTUtRU9QTiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjo
  gewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJY
  NDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiYmRjUEpSX1V5MUdYX1BWQWJtR0Vyb
  VZKdXpsZlBVWmRNY1lac2xFUlZMWGxjTmI2bXFPTgogIDhuVjFLa1dtSTVzV1BoVH
  BPQk0xTEphQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1
  CNU4tUU1HNC1OTjZVLVA0WkstQ1lPRi1MSEUzLTQ2VFkiLAogICAgICAiUHVibGlj
  UGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgI
  CAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ0cHliQVdLM0
  JiUVNEY0Q2elE4TXE5aXlYTGRqMjktdFBFdF9wRDFyakplb1RMbFJNSmRTCiAgSEZ
  PM1Itd3ZHcm1xRWd3MUY4X0g3YXVBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6
  IHsKICAgICAgIlVkZiI6ICJNQzZMLVBTUUstQTNTTC1WMlJKLUxYMlYtUEVLUS1IT
  EFEIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0
  tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB
  1YmxpYyI6ICI0QWpwWFdIOWNnUU9FampPYmR0Z2ZOQld3NnZ6M1hqQzI3bzVKMHZR
  TldXZmp1WEFJdWhmCiAgUjVNcVhBSUFiRzBoWXM0N1JHczZJZFlBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDEH-DBMY-63NX-TNKW-NRWT-ON6M-EOMJ",
              "signature":"rL-1XzDFvvzlJVqpCLp74UEwtlPFwe6b7K0Id0
  859MZOT1uIsmHg_Oyoh2fWAlzbqlRYQ6ig9MsASP1fJ9A0R7E85H1pgz9BK8LmHMQ
  RvLMKQ3Ru6tub5Y0JaH1_aq7UUuIyA67vxqfVWt-TPDIEKjUA"}
            ],
          "PayloadDigest":"BzSUFcb94_mWUijjmo7MbbV06KDa9k5albZ6Xz
  Zq4jyy8P78DoUPP3iXE6fQzUJQrWRxRuXd1BSfEbYFGyCrcg"}
        ],
      "EnvelopedConnectionAddress":[{
          "dig":"S512"},
        "e7QRQ29ubmVjdGlvbkFkZHJlc3N7tA5BdXRoZW50aWNhdGlvbnu0EFB1
  YmxpY1BhcmFtZXRlcnN7tA1QdWJsaWNLZXlFQ0RIe7QDY3J2gARYNDQ4tAZQdWJsa
  WOIOV1X_fJj5r9_tulWvuIxq24gKq6ilM645aDhHPhJLKiTgqIoNL-S2MAxinP3Ok
  057QluRQmQsc1dAH19fbQHQWNjb3VudIARYWxpY2VAZXhhbXBsZS5jb219fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAMR-TKMQ-2A77-WUG5-CHBB-DR2R-77FT",
              "signature":"CY0RZAxbyHlHivcyjNZ6XJ4kK3C8ZpbPKCxIH5
  cIVIBo-DjYmhn8q2ORmQ7BGRaRqdKOFlRPPSAA4n5XwfxAb_itBEmvKx9mBq7UBIN
  zvehejjhivSv84Rcx6fxn_zIKmDGncFWKokMp82sZeqnC6wcA"}
            ]}
        ],
      "EnvelopedConnectionService":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTEyLTIwVDE0OjAwOjMyWiJ9"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tA5BdXRoZW50aWNhdGlvbnu0A1Vk
  ZoAiTUJZMy1JRkhaLTNJWEItSkxJUy0ySzNYLUJIVDYtMzJVWbQQUHVibGljUGFyY
  W1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1YmxpY4g5XVf98m
  Pmv3-26Va-4jGrbiAqrqKUzrjloOEc-EksqJOCoig0v5LYwDGKc_c6TTntCW5FCZC
  xzV0AfX19fX0",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAMR-TKMQ-2A77-WUG5-CHBB-DR2R-77FT",
              "signature":"r1IQGbF8Je808XWvocT1z2oZCZ_4IYIy_tgglN
  eN1-kaSGaUCp9jM7OaBiLHzXwtib7K9lwFoLcAuVWimNLyJp5y9ewhxNC_ZUUI_li
  kFrFuKhFMNst_pbEShNmW6bwJ4xVXTIC9SuJyN-pfmVLJzh8A"}
            ],
          "PayloadDigest":"Y0ns3l-MUBpF-VIOJpjVzuVuzbFQpoOC2ZQf4M
  ZV4dfmA9hL90fKCYjOBKL0gb3bTwizLz3pq8EIx2bu6cXFjw"}
        ],
      "EnvelopedConnectionDevice":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMTItMjBUMTQ6MDA6MzJaIn0"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0DkF1dGhlbnRpY2F0aW9ue7QDVWRm
  gCJNQlkzLUlGSFotM0lYQi1KTElTLTJLM1gtQkhUNi0zMlVZtBBQdWJsaWNQYXJhb
  WV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibGljiDldV_3yY-
  a_f7bpVr7iMatuICquopTOuOWg4Rz4SSyok4KiKDS_ktjAMYpz9zpNOe0JbkUJkLH
  NXQB9fX20BVJvbGVzW4AJdGhyZXNob2xkXbQJU2lnbmF0dXJle7QDVWRmgCJNQVdB
  LUFGUVEtN1VGTC1UTUJCLUdUUTItQjVORy1SNEk2tBBQdWJsaWNQYXJhbWV0ZXJze
  7QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0NDi0BlB1YmxpY4g5DpDmpr8gFfzsU0
  CJodaYojpbP7mnYLxlvE3w_FjYxy5csATbTcmULdE63JzC1JvxI3jgn1PHF6sAfX1
  9tApFbmNyeXB0aW9ue7QDVWRmgCJNQ0pLLUszQVktRTJVRy1GNllCLVpETFUtU0hK
  TS1RWTVFtBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEW
  DQ0OLQGUHVibGljiDkDfsW4wfonoUqxu7PpK64LVc1AEk_0E8mizKAAkBg974OIL0
  EwLXYwVtp7V4dO-TjpS6Va_i88nYB9fX19fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAMR-TKMQ-2A77-WUG5-CHBB-DR2R-77FT",
              "signature":"cBaNcU0z3goNNaaAvXbKJ3dJn3DrHaAPY02UIb
  DlWNXiVdfaP5Qqz0Nz5cCw3xPIAqB_u9GA16KAwHxjkkMeXE6_yNYI43dsNurzXNW
  Ue6HsgkeRBmLvkqb6EUrTAPdpqcfVob95RDqGf8YgJP8_RRYA"}
            ],
          "PayloadDigest":"tUJ4WmvWdT6fTaUlfbdCTxL8aGcti_K3Wd2tOT
  0m1e-356UKOsmxHLF3YdxlQ09Ix0Djm9rmNoDFQ-Krf82NNA"}
        ],
      "EnvelopedActivationDevice":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQB-NNY4-LSTX-LXW2-F5I5-URZE-QJJT",
          "Salt":"rV2o1Ohg5fy4PSEyIF6S9g",
          "recipients":[{
              "kid":"MDPW-MCZ6-PU3X-67FO-6D7S-EYE5-EOPN",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"dbXzt18X_EiPC3jxons8Xjp-_nrZYueaKXNm1
  4Ghmh2Dq1lOZ9wV3kpKsYfj9d7uFJOXocM0RqqA"}},
              "wmk":"vZabfDcSUNY3LYkEdz9YHDMvok_24BSp7PeMAUtkQeH3
  gm_UKhf_sQ"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMTItMjBUMTQ6MDA6MzFaIn0"},
        "Y0eievFFiLpb57UHK8-P3uBiBLEdqHEmsmHvnlgO3NkGqWefSq_yBGvN
  PpKO6itNhw0l1byV6IYyhNt73XhdcNLlyZd-yyNx8RrIbhf7bYM44oQXTNZjHJHCM
  O4LZhZ3565vuqTI3Dk45JvlkUZCTdZ4cbFI0DSrSarmX2htvayjjqoDjnUEdxORqP
  lFkW-rpucCKfJ9TBLd_BY7cZsQjfEIXT7fUjkPBJpH4vD6E_xXkf4ZjY7Z5b7pF-E
  UUeZM",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAMR-TKMQ-2A77-WUG5-CHBB-DR2R-77FT",
              "signature":"-BWqDXdrlVksXBbfeNmSegDuTm1ZafPkJmFEWv
  Faog2eufbD1BEWNomdHa0Gv0cowERnhXkg1BMAp_AWthqZCBwtMesITp97whc8mKd
  LrmV7yBXgiRfgVp9RJh2FlGfXa88uMKo6u1GLM2XRPlq1FAwA",
              "witness":"kgT-IjhcgDehayHc4HohnyP8nHXOjl_zNCmR2nGw
  HSU"}
            ],
          "PayloadDigest":"oPD-Y5nrZpy0m_mwvQuhry04Mg5h5SzitoxMNx
  Af5XZ7BFVWDPgBk6VEZJH8Ev49Mzj1laNADHIjO4jNODyIaQ"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQN-BL4E-YTL3-YRV5-GJCF-IT2W-PO2I",
          "Salt":"PO7hptuDOm-XpFAhrh84sA",
          "recipients":[{
              "kid":"MCJK-K3AY-E2UG-F6YB-ZDLU-SHJM-QY5E",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"Pw_OxMWePli8vqZgb_fXzBsx-ZNLRdEL5qSBN
  T4h40zrUDhWuOQq7pXheQ5F2QFDR4JbnrEq2woA"}},
              "wmk":"xWsbC5PRoVg-k73P7aCj4kowiuVmVV2Fo3AXRNwZ4bKt
  KbJTilhhGg"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTEyLTIwVDE0OjAwOjMxWiJ9"},
        "iMNrmuRb0XSnwkENNOSJj3Df4sB1kjBlQolkVbtAGA3xwbwO_kgjP_lR
  sRfAAz7ziBWjmq_6YkqcjziVPIYrzzwFhRxTI6kIg8d6Eap2NDH3vHvTB2EuYo5rO
  w-XTy7gUZ95XiXcGVHeZdqEP5X8s3X31rgrBq4rOueQXnLhbJ013CbZUkZYmjzlZx
  a1XVfMj12I9Nm6toiXjTlXseGHkIP-_5vAks_DyHKJEqqHBoDYw6535PIZ9EB-eZI
  OXawXDYmn-St7APQOamM9YEw5d4IpYKp9bxQdgt-b4hB1HvKp9oS8j0i52_LZzBGv
  ANyHBQfbqOELgKrNQpSsNFgYVZ4XyKW6pIlmIj3TiKV-uyX0yCDaMLx7DmdTmCzTp
  kQnUgtUZvpfgj-Bys4LlNUfmg1LldgAzFmZFWGU8CsXTx7o9JfifFh_TuhzGQW9CK
  jg1m9Rwj442157ToZsQc969YDE6V0I_GpDMI8bc4DIjjGqYZEI5cy4IBLXiaWdm4-
  OIubDPuLj30h-EgXQ03fPWRYLNh5bhyig4RHBWaBf-_NfJVMa8gV4TJgUqORXc50w
  WcmlVrNBKv2Icalk9MElWXCXmvUlrEwsX0CEugd7Wrz2cheeah4SRQ6KVMzwfeCVw
  5c_AS7E6xNq5KsO_pNe5yrE1XzxvSUHHhlGNGefraqExm4lsnq6Cqr9TqHb0Dd10u
  20IuBS6ULznfHzmGzusUJ99eNmg2010wqBNADuOer3v7UHcI4qysktqFEBKOODOsE
  s6NqpGBBYPlVXAAh9wQPf58oCjv6UDAc-iwq-cVtAki7ShfmjuP6TqcsPMRepC22P
  InSZELdlBwoWsXnubgKQo6SzV4oU8DYGhqoqyQpvel-yR9jMJ_cZpwy2AFt2pi7Ck
  FQOmcoziKswpLPsBkMX-7dNTNmfAHFjkHQEyBLtCSdCEd8x1GbkbnDqW5EWFCXFXO
  HKozYIHKGuppqc-lrKQzmttGNbyqsxtfc15-qP42Ujf07RylykM9ZmV4uHnZ6DDmO
  gJMdCLGI7_npGNjMbi4sm8MGnDbZihkGkKr2ryZChl_t7LW6-iBZga4C5azkv8Ibz
  qXlNSaThRR4SplmZYvI2uHwq3RYcqCGYiPeVXozD35RZA0dF4Z1RcZQio32g2LclT
  6PMF_dz1mhBk9nmS6RjtUMH7fPsuiKqSNKvI7vpf0eW5_2yi-qrjNGn8NTHfviP55
  t8eQXoeNoHvCzNCUTa85U4uJyaVRIOXFYmhrapF4CRXzQ8TIxTIS-FPeJ5w60Nou2
  s6SnXCDLe-q_Fa0e0U_WmSfnLVnrcDXF-Hnssb1I4ZbDPVKGu2eBATRACwv-ARD2L
  y8TV0OH6eZnziN5PLaEMgbirlc70EBNHj97I6y60-bBvgilnCtpYb6mTL9U-5nO4d
  NjuHEOwFEDm29kBKt0NzXcaoKrUbh6RVVVY6wdUetDj7zxHyBALw8IIfOtguQEAD3
  4aoCQ8VUAGGlnqVRBh-QF4IhlzUFB7QxJ4Kj1jFsm68Y4cN-9bdjJKLLJvLhGSM1w
  O1jr_J4GFg3TlyvKvukPtgCgchavzf2jCzFXaBeeg212W9_j0aru-8CnmQp7bhJJY
  7rCny3emqCn5KZ-2qTcZMIQhwgncsU2uTAxbd_ZMNtuv6jc59QHU-Q-cz6B2kahFj
  SMbHKiFnIU63M32rvd0HzuxhM0VFCzEMSsRMO9IawGifKxEuW9tU5jIgnABor7z1V
  fel0AU2FYX4Nn_himH_0w6Ltxr_A3Pfs2jtXF7Xe5IAlpwtGYLkE_1VydWr-6Q8-b
  GnYpPDfW2Uk3Kg-ySVOISG40xtCZszUsKfYJrGzpdHYf1xPV5FSNLM1TA8vUc1Scd
  keBb82CEcIXwoVLjgplf1afqhTJaaCYXuONL-Kflf5zI0rYVXr2cIY3Le_5dB6nLX
  udLIb2OpHsAnKCmbADC3Fm2Q1ejoFtoTnzTAQWsx5-RQMPW_XXpLcoK8df0NfyZth
  mXjMItyDZM8j0JWl7Q0UBySNhI95Liin7xum1tsZcywMsAcofrPrVqFec9qeDtl7i
  HeAjElkUWzdiL-2bzTt_Gvn8NyB0wL2k-Mnq-49UkcA2SlHOHnC6hFQzZe_ZjqU__
  T9y8qlPci04QEPIp3R6NrhzlAoLuFhFBMnYlZWvWRfBtnLHZo5QkC9V1lMsNcTE-w
  fHiWHQ2PZll0bJ5hEE4ROBKO8ntN4FlyDDux25L5ieWQIoUFIWBhKnysWm9JAqcIs
  4V_-_dK8UryEfviRbfIH80J13cecdIbtOo_Gt4J2MiJGQCQHCIjw0VWV0RYjb1olS
  lFqZuMNatK4TssxIRogTR_zKjpb4kjcyzYcagvrUhvypWmwkiEFn20deFTN5nOmW4
  QaljJDpBtVpx2uHKsuEyalLKmx6DLBUmByjCu_8LO55R0S41-rNgIn5H2US2W7Rct
  EnAHwzV71E3o1n3sG5FnTZYjDovFO43LDQu_8XfZfaogsxD865bpos5Q2AG0jbqsP
  ODLu8deZVMNszyF157Q29Athh1fRv39H5fduHsOJB34OayAzk12m9-VyfGYZx3_UM
  Ggg3ezXbTXlgNh0XcY2aWAVuy2P8CvfO8TXAs5E04fgYW1e-vUefKJHY5Mv88yuyZ
  aJcJdju-dLonZ06pdGIdwu5OXbXi7xBYLKQV2jZQ6IIEwbXpZhdtqpr1y-yPuNAt-
  x6eWY-NAscmKh5X-X24yLDVFoR1IKob85merlPKQnqE5RQkCu3S1ieEQ5jSxK0mgJ
  6HF6omY-El8ipVm2XZes3CxEh5JF16nRwkcgd04JJx-WCsSBbhQzMjJZAJzOIba5f
  Pp4RZiaZ6jophPZBFMsnbML1YOnubbJxMdk9kqyGNEcKAdSRLPXdPVHByjOnVUWlU
  TvRVFSQVUBKRjTW9I4H5ryPxNVYFssXNnSwwr4fXJfJYzfwIGUFrpB-ZuoDL-wUGc
  yBii0dbH5y-N-yIw4yIKR7Q0jBHrHXevA-QZPU1I7TgTvVb3QYF_Ali3-JJ5CbO3j
  tFORM9BTDV0LM89hUr-os3ZN80KAyccx6dcvDvVIbcwDQoc-6WeLpxAHaYZIXyUNK
  Jr4a8sJO_4l_PRTtO_Z7eK6TDQ_IVhDbwvCXB-ijynWXkN5vHjgzEL116jGD4MGvy
  2lClpPCQQcQnAf47GN-Jh6qJLcRfQJctN7cFwtoKTs98XIaXxpOihXSM2P0GL_vs3
  gz0IY6XJrZq7b1XoGQlbFH8Qn5qj94jwSi8oMSRvEkMnLnvMmTQusWDSCaACD8lKE
  dCgqCyL1DwMgd-IaXDn1i16FxuHM4sDEAB5BZIniCFC_KWKbiLO1iaPdl_FrkXj6J
  KxaUj3isdofA3H7sUxP2LzNrlk4PmYvqryuVJAMW4U6aYst2AYrOnqJMJbQkrNPgk
  rHNreoDKo3xL7sMJfj8VLw8Sc8NwVK5WcDqoYJsncStyEY3qt1-Ma7zltkU3uBvXn
  Gd9cW9iw2PZ_-gdMk5Rq-PdZRppDqZCIh30fxWiP-OnzoCA85eXPlrJzwaX3kHzwx
  YKCsIj9P4DykFIWPyZA0KDOBuOvkOerDYfhwqVYiwAizElJcKU8tr0KIYDT8YtDOW
  qUUWyvOHUpJi7jo94fcWGi4AM5pLwQVh_9nCZh-qt6wumULsy3s1F3sK35b5n1sbS
  BJLPanABNX2O_SSs4dVaxw9z_4PKe36OjC6jHUBZpNQ-_nN9HtacAYjzVhMC4UvIw
  mdc6Wyv4YqfGppmYISUDFTkua7XRU3bcLV3TlufJSt9jgCKylz8SyoVbjt5HLoSt2
  ptcFfaMluATs_XU2sEmvgzzpZaX8Vq2B2AmOXzevj12WRE9vwjZrSdiGpgt5pPizN
  -U2qFgjAp8nhVmCv4iHyLMXQL0pRxuJQHBarXa4ZppuUpKzOPJeGCZapz_fLgmCBR
  1Z2szO4EVJLpa0LZcdapgQOcJL1UqECA8Z8WOQx_AgeCQeR5KgciHEV_lDAks08up
  RbqwdZHakYhbJ5K8qPTKjJLZiePPbyrUsj_OuIlg76e_bKRywamGPsNKb2wc8cn4S
  mI5EEBoY-e4SM9ASC8fVcPIN7bUyXeBZMsqEdUcaj8UKoSqmKn2ZPHdx-a124CiAu
  ocF1o9hUB_9tr3D_z1yhq9Q6p5I70Ze9JNigT-mauerxjhtt-h_4LBJ68pcWXBrqs
  xfqI3eVk1pOA65HBAcfs9AQtesozpLFNmqJ3_inL5gitRiBDEJRQ8daRfEPKmG4DF
  kMtbVk1p0UfzFH0D6uvepJiVCIsdWBme_AhPXPq-OcnhP4i5D1pvVHoiLN7Ql_HyZ
  RJKet7LXlqX9OWRLnyE7WyDA1dmOjZf_FQ2CGHpYuMQfcZk5rXSq6C8Jw6vdUmbiN
  JQ0MzdFj5Erh9TcGNMosKchNsnc7QrhHx29KZhSVZnIWXR_uE88vrV6q3hqLJ7ktt
  sENbR5i9hUpWzX9RdcPlXW7aZNk8jos0d0hAYimwLOYnsXTHHtop5kc13bFFbnDzh
  axqTT5iovwQ8dMGjJqJL8AJRPT1VkzqxDSoWS49mYHX3U6Rgozyv2Rc5vZMuxSLW4
  cwn4o_k2e68gP8WWB1xGLt2h-fxuOFLbq9H_lDJ3nMGc0sH3RZ83YG1NpgyMonJtI
  7pInYwF_UQRn4e0E7BfhNSshhVEUUaKXf1VoILg7D7knaB9OkoS2RNvmdog4tr0Z_
  HZHlHSR5RO4-bAnEq7ksIF8GSMufZxO_nVr_4_ecCvdD4ymiXj-hE8j-R8-YqG8Uf
  V6M738ti-jFNZDD4VhICRBI_VL-0moJI9QZW3NM7yoQVaZl0mLJkreV5Jb6FLxenT
  cE7P63ItYznjbIl3H2RHgbg_BsInDCjsLQ18zoBEEYF5HXI-9Nig1vwYMWyoZ8q_I
  aY6CHKIULnDeTyHs0X_oGHwoyxd0sTSC0OH1G9wUPuN0nBrlBbRlWiHgFqrVKJDqw
  2hmrtJipaLzb1bWTtS-ksvJEj4aVjtrR267faDSbuDzd1GFAyMHa1IMkO6H3vJ-FX
  tBCXAH5yF_-yl7UxnrjkOcgcga5D9QhEUDt-KoZWAx2QO4SBhDIg_wRwcZ3A1fe1i
  g87NBPih6YzLXWsOFuSBVaSmxSwSUd4JSOqD6Y1B2dhW91MH-xVclyXgBHmpIzkIc
  JqRItPIJsynUE0LfDg7CrssUEAb4ibRNQ3srJYeyet7LA04cqoWu5SHHpddr0Tlr8
  oWt9GSZyhGCKVVwUPdkNap3ODto7iLMjBfUkel8u3oxAax_GKviokCdDKwNmpTmYe
  Ywngmz0sADblfDfsJr8eFbvPRxvRSPqxuTaRSKPNTdB7BZHaslmoKl9SXgsSLMUF8
  UVxBz-v5TWlq_-thfseBQEx8gMeMlhzbWGzkQsBFpLE1yFD6Fozzfx3p9LD4dbK4l
  Zk6JT_z_vgCXh0hOrza14VnIOlynEhXOGRIUjEJMa-1d4db3aaD9qRh6redSJ7gct
  Sfi6c70RfBhQGDf5UGYw1MDY2WteSgDhz1nHBrw-0foUmyqfDWXhjdyvkkb3_W4-O
  zEu7d_h8cNj6CGfI_U1YOUONTgrSxrOXt-P8DDT8Lcfvai2H2XJp_Tmv2cI_rlBL_
  RaRvx5MPVDlcOTNanOoI4fwuthK1FtB2c3wcgPJYD3V8XvH06MRFwmtClCqyHTpii
  85pPItUHs2_Ihf_QNC7BXu3mT7pNxYgEMaSS2i_aMdaC_gM3pnNJDMWDg2qiU2oTn
  yb7AjQezwNIaq71cYMC4y-NFx4lptt4wdMat_HRPmtt1tt3O4YVzYFxbdbN-PRyAA
  JoV-H9TchYSdzNVrWRacNx0axDvkNNyfoXbDhfvqMIxw3nuqaibJMnTzsXNNncbr1
  XG2kQ6yeP69D4pnMYgaCsbQaolu6C0taa6D3GtOFLSMExLrbKvULOJhlUbhX_D9U4
  VeW1ZIrOZ2vpqYEX7t9qzADNsTxW4ugqwhZRgtao-gJwoMnB1MDGV2RfcsCZQSMVP
  Wk5d3r7ponBgZ6M-IYy-3sSKBLAHIhQ7CawVVihdTJtidN_PSYXS_NoUqvQOmn_zy
  pBzXP5ICERHHGpm4eLHROHImGhASzICrXLwmMNv422sCjXsEy_XWIezhOCEWbyoLY
  6zkNOT1qPyAzbt8xQTWfw8N-mNTVOCYABxhUSZ4DcqFnEWiOmJe0NlHo1khp2Vsje
  HrzjOPXL48qg_MWTREFZhKw7Ok_N7t3y-cBpFjYmQKycrmQbiOeAV-KW0zqZHVY0d
  AIlSRHvo9ZRJDn7s6_OZjwj6Fcz34byTnTOeLN1B8ShjMit5SGbGCEY4JdQ9OxNGK
  Q_V3rFPDL7BvTlMWJiN2xxk3Q1TMfYZ7cyo5L0Pql0bfyjhIyIr-Crl4Hk4qBD6rw
  uxK0uyPnCD0dzd-XiPye2mFPiGaiCSK-4AaOg2ZQbM8FUULnRS_72KCbHDL6S5A9L
  kEJ0ff81ZfIlJq4HKOENH1RJBD1KKXSF1DKOjCAoP1a8YUuItLODZPKPJ33cuzf3Z
  86_vuqviTO3J64g2sURroQZ5rX-bluqZL9sBaXJWh3nRE4tkZU2EYwENOYZE20hwN
  Pq1t1qP4HQuK_COem5cGwXS2LKaKLSNgeLSr2y20R5dLL8nz8AplzLsP8WR0arWSM
  MW06QC14bOOfYr4AudzmEuIX1UIC2zVqOX6tUiQYpTacyytbmn2yTaA9cIMxlTL29
  zpTSXvc6LUSsy2C_C7NOinoSG_GVV2Zzk9ps_XkFHU1UkEkw4WyWUHvNjYH89PkKZ
  l8wVOLEcY7ro3vYyXVMVQD4ndCEfaGuwinWrUSn1_ljhsjnV0gefq6wto5KZ6nPzi
  2TrJdfIMwRNi9YQwe8Oal5Kwc_Tbqef4Vk-HZzxJ6iedTGJD9r0f4_YiRNMDAkEOG
  gwFagUjYnsM6jzgY8YDgWx6sHWCWb7eO-7_wYLaTZ3lB5c0j4ywa4v3Xi_gfaoxvv
  2pWWm1SKJpN6jUA2RnIWIwmwi_WqtnhKNZLCVdcY7u6KkHWu1j_JfRA3BCy7Qvx1V
  vVgsXObaDudZ8-TCl3P2UXxhQMyg9STod0Mk7ryIPe6nwwuesz6RaCivdGNVF1TqU
  zz7PFBewSvjlMnXNY3451D18hK9rEAEOaKurYPAt6p04d4TGv61-bT6kqDXGV8GGr
  kq7ek-bqcd_BV1uXpLJYSohtUn-GO8jPOrMQ6PE_Q1omvpsBzuHxhxVGTT5RqUXHz
  Af-tVkRwkmPaaAbwIfZnTFEU-GK_U8q3eBu5elcpUcYqzNcIlYZ1JzR5-8KFMU8Kh
  WdTaAOq_p7V01B7JwQIKz7p4GcQMkr4x4fFJNCHqtCOA172RsjCS6J_EJ10tm7ucR
  0jKcoZl6IZm5lPbRohZPuh3j3GSZWfdI1rrKwyfygcw0YBQr1aaUoDezPovWz4-Ho
  BINGW74qQ_GiwJj71NbmvoAbGbogQ5uPbeDSuVxTPjpX89QPcf0AtJRHvDcsYMoqL
  g8HEOBppc_N4op7WwpAGQVc8fzURCFiwe2rGVXEvCAfa6rEQMNByEnd1v383R_c_w
  byTz9LO32PY_PkR8fmMOuWA50NrS55CepLX58a21XD5hDEvIoK5EoKHizjwTJxk09
  UsKEQEMUKX0gUcalHLvE4FrPbaaKeKZAPm1d93gJZrA1Ic4m36mOSrrg-9WyWjZ-I
  cPKzS2p7Q-6lG95VIh3JsXCDBNbmL8DEaBd8IghnKYM_ujbhOKj_l6vZwWZTR2xKh
  AFyNigM2GbL2s07RjfV1I7Iur4mfDHirRvaxkFbRvIQulMqWq-4Y_hdp06N8SPoPF
  svsYhnKUJQ7B4lRvcnr3YNRAfehD3t7gil8pqINMMTibNujeJSgKbxA8eONdO8W8N
  Eb07wPmIyHxF3kaT1VZzrNn_ewqUCKnrGT7C55m3QAF6_2vE9joUJyPWqz-859_QL
  9rG3zP-L26bCbO1WDeHjEwaB0G-z99704UkzWjMOs4Hd93NUK0nKjD8T-JuLZm1zZ
  ezP-BeU53fiFzMZVNG2-5GoxHU9GqteFhLKT-QDYvyALfI5kPxlvUyThgudx4biE7
  3QCEiM63na3FOClDIBYJ6M0m3vcewAmWQiMrmRovaPM2IVsrDY8-oc-U3ru_FX6uZ
  rZAOvcL3Muqzi5cIgaFDtKLZb6-czMxF6a7Hyezm9v1kia9W_7KJ5ggEItEYGadgg
  WtQN4o5nCid8CDN2WHIzO8Q0OqzbO7UZFLyodlnKE2ZNedXF7Kldafj7JwD70wEOD
  alCUSrp4GRioCucioYK_Z2wo8hTvgEpf3D-7QZ52tHmkhDJistqrSa9ifoEC9vmmR
  2YPfsLyalV9CvMkxuKEp0kBhHHuDe0D956R3kvlYRxIRQ5qccbjUU2UT-J4hgm12F
  eBypKI7d25LuboHzqH6RHi-BFVLoJ0ktcXetp-KNLP6FMLKQ2QdzjUUWw-ZDcbQBL
  GsLdCocBpDB87vMtwHLZ0Fd8DUqV-w7ZBcuBJDGbML5M8zkqXhsZljFjQMWC1DzzI
  8-6C4dAG7Z8Y8ScPpXExEKLk0gU-cLiLwl2fU8lap2R8yKzY",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAMR-TKMQ-2A77-WUG5-CHBB-DR2R-77FT",
              "signature":"hJQympwRaONVrCXkRnh58ubQL514CezTWgBAwF
  -qGC3mApNLxdQbQaq-cllmX8t-ofP8DT44xNiAwuOqvEIF8BO4r3kQ1jrXSwi8o2Y
  NWiSOhyAYeQocoJ5iqVmwaWR3jWL5VjgvnlTkYD_imAzMySkA",
              "witness":"FydMHXjdPI12LEul4p_mKQlDnSteJuJDf2V93rgs
  Dmk"}
            ],
          "PayloadDigest":"f56Q4trNE-v4yMt4ukIelYbKnQ60k4WqyIRIOI
  HFspaDuckBO2NuqDTN3g5tAVmv7IGC-Zc4iuJEmv_7tVhePw"}
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
<rsp>   Device UDF = MDEH-DBMY-63NX-TNKW-NRWT-ON6M-EOMJ
   Account = alice@example.com
   Account UDF = MDKO-KEIN-OCN2-C6UB-VS2K-TNA4-WXVJ
<cmd>Alice3> meshman account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MBCD-GVMP-QCXP-42SZ-O2LT-WL2B-UK2G"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

