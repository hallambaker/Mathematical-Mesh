
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=AA34-4UB6-2FPH-KPT6-JNTU-PNWR-MU
 (Expires=2024-10-06T00:49:11Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcd://alice@example.com/AA34-4UB6-2FPH-KPT6-JNTU-PNWR-MU
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AA34-4UB6-2FPH-KPT6-JNTU-PNWR-MU
<rsp>   Device UDF = MBQB-VIJP-5XSD-4LQL-R6VP-DRGB-T2TU
   Witness value = F7X6-DDMV-2X7D-3KQ7-GW55-ES6F-WZAC
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "AccountAddress":"alice@example.com",
    "AuthenticatedData":[{
        "EnvelopeId":"MBQB-VIJP-5XSD-4LQL-R6VP-DRGB-T2TU",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFCLVZJSlAtNV
  hTRC00TFFMLVI2VlAtRFJHQi1UMlRVIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDI0LTEwLTA1VDAwOjQ5OjExWiJ9",
        "dig":"S512"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIkVuY3J5cHRpb24iOiB7Ci
  AgICAgICJVZGYiOiAiTUJGTC1BUFFJLTNYS0YtNFNONC1SM1lILTRaUFMtVlNIRCI
  sCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlF
  Q0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiMU01ZDVNM1FrS1RIXy1oSWNaSWVsNnJQX2VYRzI5ZDJsT3NlT1NwTlAtUl
  NqbHR6SmFycgogIFRLbGtOaW5TSWU4RzEtLXRzcXRzUmxxQSJ9fX0sCiAgICAiU2l
  nbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CMlEtVjdYVC1PVUwzLUZKNVotWklC
  Uy1YUVpGLVhBT1ciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogIC
  AgICAgICAgIlB1YmxpYyI6ICJkLVJaM21YSkFhUGEtWmFaaHh2YzB6Y28taWpVMUl
  BdjlhZkt6SnczQnBrOFdqREJJdnQxCiAgdXZrTUozT0JpRkVPSjV6a2p4REtySThB
  In19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQlZOL
  UtIM00tMkRJVS1NR09ILTYzQkEtTk8zTC1YMzZKIiwKICAgICAgIlB1YmxpY1Bhcm
  FtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICA
  iY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ6X1QxYmNhTEExT2R0
  d2lNcU9pa29hWnlqQ1dWTkxXYUtXZTh4MTdxdndEUGlaRmw5RFplCiAgMWhhczE2N
  2JUNzNaUEpQOXpHM09TX2VBIn19fSwKICAgICJSb290VWRmcyI6IFsiWUdFUkx3eF
  VhVndNVjFnMEw4ZkNWYWJ3X2xRSHY3cFVTbTBUaXRSZHI0Q3VGUWNGN0wKICBEdUR
  hanV2dkI4RHVweGFwTWdhT1NJNWNSMk4yYy1yaEI1cE5ZIl19fQ",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MBQR-CLYM-KRUV-YDCX-LA2C-7R6C-KWTP",
            "SignatureKey":{
              "PublicKeyECDH":{
                "crv":"Ed448",
                "Public":"jf_2wJGRFQJoIk-BxCFJ41SLSfJ0w09oMUzVbVT
  hoiGRkX1Gz5SdvLTkkBrHHyaowqmf3SeCUfGA"}},
            "signature":"-fNYD3jZIbWd62Biso9VS8ctfnWcDOu5XvorPbmf
  nBLhAXhus-J3M2D4sa-7x7gDnHmx0FgYKkuAF06_QxU_gF3PS1jTXb9bi3j5IfS7H
  ozqK8Ab_jufhnM_eQGS60L2S8CuRegQZnkmPKT1KVlXzSAA"}
          ],
        "PayloadDigest":"O9B56nlj9NMrFcKt-h82QyaOGSzm73FwCE0ff7-k
  LMG_IOHgjqUCx7zOKHYN_gBxMV6zd2nrBBhVBCVFDs1nqA"}
      ],
    "ClientNonce":"AnWt869hr5lSmRvRTmjlKA",
    "PinId":"ACJ4-ZU6E-2VVX-5YDL-EYU6-FCHD-CTMK",
    "PinWitness":"mJEA-gItS8Z_-uMm9RxfSLiQhhovwR4rp-Y9GrNzRdWyrGU
  oEGlPe4EtzF6VqhIP4ra5OSy9I-VEYh8J-aPgLQ",
    "MessageId":"NBJU-IWET-SKRI-TTVB-KQCC-ZZM6-LV3J"}}
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
        "EnvelopeId":"MA66-2Y7R-G43G-ERFK-CPLT-4QIX-UPMZ",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQkpVLUlXRVQtU0
  tSSS1UVFZCLUtRQ0MtWlpNNi1MVjNKIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyNC0xMC0wNVQwMDo0OToxMVoifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJBY2NvdW50QWRkcm
  VzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiQXV0aGVudGljYXRlZERhdGE
  iOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1CUUItVklKUC01WFNELTRMUUwt
  UjZWUC1EUkdCLVQyVFUiLAogICAgICAgICJDb250ZW50TWV0YURhdGEiOiAiZXdvZ
  0lDSlZibWx4ZFdWSlpDSTZJQ0pOUWxGQ0xWWkpTbEF0TlZoVFJDMAogIDBURkZNTF
  ZJMlZsQXRSRkpIUWkxVU1sUlZJaXdLSUNBaVRXVnpjMkZuWlZSNWNHVWlPaUFpVUh
  KdlptbHNaCiAgVVJsZG1salpTSXNDaUFnSW1OMGVTSTZJQ0poY0hCc2FXTmhkR2x2
  Ymk5dGJXMHZiMkpxWldOMElpd0tJQ0EKICBpUTNKbFlYUmxaQ0k2SUNJeU1ESTBMV
  EV3TFRBMVZEQXdPalE1T2pFeFdpSjkiLAogICAgICAgICJkaWciOiAiUzUxMiJ9LA
  ogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWtWdVk
  zSjVjSFJwYjI0aU9pQgogIDdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVSkdUQzFCVUZG
  SkxUTllTMFl0TkZOT05DMVNNMWxJTFRSYVVGTXRWCiAgbE5JUkNJc0NpQWdJQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0oKIC
  BzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE
  0SWl3S0lDQWdJQ0FnSQogIENBZ0lDSlFkV0pzYVdNaU9pQWlNVTAxWkRWTk0xRnJT
  MVJJWHkxb1NXTmFTV1ZzTm5KUVgyVllSekk1WkRKCiAgc1QzTmxUMU53VGxBdFVsT
  nFiSFI2U21GeWNnb2dJRlJMYkd0T2FXNVRTV1U0UnpFdExYUnpjWFJ6VW14eFEKIC
  BTSjlmWDBzQ2lBZ0lDQWlVMmxuYm1GMGRYSmxJam9nZXdvZ0lDQWdJQ0FpVldSbUl
  qb2dJazFDTWxFdFZqZAogIFlWQzFQVlV3ekxVWktOVm90V2tsQ1V5MVlVVnBHTFZo
  QlQxY2lMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLS
  UNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKIC
  BnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk
  2SUNKa0xWSmFNMjFZUwogIGtGaFVHRXRXbUZhYUhoMll6QjZZMjh0YVdwVk1VbEJk
  amxoWmt0NlNuY3pRbkJyT0ZkcVJFSkpkblF4Q2lBCiAgZ2RYWnJUVW96VDBKcFJrV
  lBTalY2YTJwNFJFdHlTVGhCSW4xOWZTd0tJQ0FnSUNKQmRYUm9aVzUwYVdOaGQKIC
  BHbHZiaUk2SUhzS0lDQWdJQ0FnSWxWa1ppSTZJQ0pOUWxaT0xVdElNMDB0TWtSSlZ
  TMU5SMDlJTFRZelFrRQogIHRUazh6VEMxWU16WktJaXdLSUNBZ0lDQWdJbEIxWW14
  cFkxQmhjbUZ0WlhSbGNuTWlPaUI3Q2lBZ0lDQWdJCiAgQ0FnSWxCMVlteHBZMHRsZ
  VVWRFJFZ2lPaUI3Q2lBZ0lDQWdJQ0FnSUNBaVkzSjJJam9nSWxnME5EZ2lMQW8KIC
  BnSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKNlgxUXhZbU5oVEVFeFQyUjBkMmx
  OY1U5cGEyOWhXbmxxUQogIDFkV1RreFhZVXRYWlRoNE1UZHhkbmRFVUdsYVJtdzVS
  RnBsQ2lBZ01XaGhjekUyTjJKVU56TmFVRXBRT1hwCiAgSE0wOVRYMlZCSW4xOWZTd
  0tJQ0FnSUNKU2IyOTBWV1JtY3lJNklGc2lXVWRGVWt4M2VGVmhWbmROVmpGbk0KIC
  BFdzRaa05XWVdKM1gyeFJTSFkzY0ZWVGJUQlVhWFJTWkhJMFEzVkdVV05HTjB3S0l
  DQkVkVVJoYW5WMmRrSQogIDRSSFZ3ZUdGd1RXZGhUMU5KTldOU01rNHlZeTF5YUVJ
  MWNFNVpJbDE5ZlEiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZXMiOiBbewogI
  CAgICAgICAgICAiYWxnIjogIkVENDQ4IiwKICAgICAgICAgICAgImtpZCI6ICJNQl
  FSLUNMWU0tS1JVVi1ZRENYLUxBMkMtN1I2Qy1LV1RQIiwKICAgICAgICAgICAgIlN
  pZ25hdHVyZUtleSI6IHsKICAgICAgICAgICAgICAiUHVibGljS2V5RUNESCI6IHsK
  ICAgICAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgICAgICAgI
  lB1YmxpYyI6ICJqZl8yd0pHUkZRSm9Jay1CeENGSjQxU0xTZkowdzA5b01VelZiVl
  Rob2lHUmtYMUd6NVNkCiAgdkxUa2tCckhIeWFvd3FtZjNTZUNVZkdBIn19LAogICA
  gICAgICAgICAic2lnbmF0dXJlIjogIi1mTllEM2paSWJXZDYyQmlzbzlWUzhjdGZu
  V2NET3U1WHZvclBibWZuQkxoQVhodXMKICAtSjNNMkQ0c2EtN3g3Z0RuSG14MEZnW
  UtrdUFGMDZfUXhVX2dGM1BTMWpUWGI5YmkzajVJZlM3SG96cUs4QQogIGJfanVmaG
  5NX2VRR1M2MEwyUzhDdVJlZ1FabmttUEtUMUtWbFh6U0FBIn1dLAogICAgICAgICJ
  QYXlsb2FkRGlnZXN0IjogIk85QjU2bmxqOU5NckZjS3QtaDgyUXlhT0dTem03M0Z3
  Q0UwZmY3LWtMTUdfSQogIE9IZ2pxVUN4N3pPS0hZTl9nQnhNVjZ6ZDJuckJCaFZCQ
  1ZGRHMxbnFBIn1dLAogICAgIkNsaWVudE5vbmNlIjogIkFuV3Q4NjlocjVsU21Sdl
  JUbWpsS0EiLAogICAgIlBpbklkIjogIkFDSjQtWlU2RS0yVlZYLTVZREwtRVlVNi1
  GQ0hELUNUTUsiLAogICAgIlBpbldpdG5lc3MiOiAibUpFQS1nSXRTOFpfLXVNbTlS
  eGZTTGlRaGhvdndSNHJwLVk5R3JOelJkV3lyR1VvCiAgRUdsUGU0RXR6RjZWcWhJU
  DRyYTVPU3k5SS1WRVloOEotYVBnTFEiLAogICAgIk1lc3NhZ2VJZCI6ICJOQkpVLU
  lXRVQtU0tSSS1UVFZCLUtRQ0MtWlpNNi1MVjNKIn19"
      ],
    "ServerNonce":"eJ10UjuRyQgHix8LsDfstQ",
    "Witness":"F7X6-DDMV-2X7D-3KQ7-GW55-ES6F-WZAC",
    "MessageId":"F7X6-DDMV-2X7D-3KQ7-GW55-ES6F-WZAC"}}
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
<rsp>MessageID: F7X6-DDMV-2X7D-3KQ7-GW55-ES6F-WZAC
        Connection Request::
        MessageID: F7X6-DDMV-2X7D-3KQ7-GW55-ES6F-WZAC
        To:  From: 
        Device:  MBQB-VIJP-5XSD-4LQL-R6VP-DRGB-T2TU
        Witness: F7X6-DDMV-2X7D-3KQ7-GW55-ES6F-WZAC
MessageID: NDW4-S5EU-3BER-BTL2-EA2D-C4LL-TKLA
MessageID: NBUX-DOPM-JJKG-NKMV-K24G-MX24-4QNW
        Confirmation Request::
        MessageID: NBUX-DOPM-JJKG-NKMV-K24G-MX24-4QNW
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NA2W-XWGB-F4LB-MUSW-MC4I-YK2G-GAJT
MessageID: NBTZ-WSA2-2OFC-QMTP-LA2D-FMRE-P4N5
MessageID: ND2F-I3BZ-645E-OSBR-Z5NI-MIUG-4IRN
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
      "DeviceUdf":"MBQB-VIJP-5XSD-4LQL-R6VP-DRGB-T2TU",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFLLTRTMkct
  VENORy1ZSU9MLUlVSTUtRFRSVy1JT0taIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyNC0xMC0wNVQwMDo0OTowMFoifQ",
          "dig":"S512"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJDb21tb25TaWduYXR1cmUi
  OiB7CiAgICAgICJVZGYiOiAiTUJOMy01RlJJLVBQNlQtVFVESy1FUVZRLTZZRzItU
  VFLUCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaW
  NLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICA
  iUHVibGljIjogImN0RUg2WEZzX2pZZzdVdThnbVF5VGtNN3BLTkx4TkhudWg0R2pI
  N2lWSzc2NVlHWHNTcGEKICB2ZjU4ZW5QNUY4TmRra25CMDgwZUJZcUEifX19LAogI
  CAgIkFjY291bnRBZGRyZXNzIjogImFsaWNlQGV4YW1wbGUuY29tIiwKICAgICJTZX
  J2aWNlVWRmIjogIk1CUUgtSU5LSS1GRDRBLVFMTkctQ1NYUS1DQjdJLVVFU0kiLAo
  gICAgIkVzY3Jvd0VuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJEUy1CRzJE
  LVBOVU0tQTNKWC1WTkRKLUo0RU8tM0hRQyIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydi
  I6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiZjFWaWdXOTBpaE11M3FZNDE
  5bEZwMlZSQ1dpNExpM3NoSGRxWGpURXlXV2NiOFl6RHZBOAogIHVPTi1KbnMxTXJh
  dVFiczFJNnVSR0ItQSJ9fX0sCiAgICAiQWRtaW5pc3RyYXRvclNpZ25hdHVyZSI6I
  HsKICAgICAgIlVkZiI6ICJNQU9XLTVQVU4tTUdEVy1OVFA0LTQyQlUtWEU2My1KS0
  hTIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0t
  leUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAiUV8ycFZDVW54UFlhZDB5OGxCV05qcDgyelFqUUIzSHB4aG5fazFmY
  1BiWUFKRjdwYzdfYQogIDl2dmw2Q1J6YW5JMjZTTzBta19GRUlFQSJ9fX0sCiAgIC
  AiQ29tbW9uRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQjU0LU9FRUstSlp
  TRy1UUkxVLUhQSVItU0FCRi1UMzVPIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  lg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ0REhOUFhJLVZQNDRXbFItTGhOWV
  YxUGlMWEpNMU9FcTBtNTN5ampHUFJwWDJ3RU44dW5UCiAgYkdoWUN1MDhmZUJyVGx
  4TEt0d1lsRG9BIn19fSwKICAgICJDb21tb25BdXRoZW50aWNhdGlvbiI6IHsKICAg
  ICAgIlVkZiI6ICJNQ09TLVZET1ItRTdBVS1QVk9VLUNHRVYtUU82WS1KUjNSIiwKI
  CAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDRE
  giOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI
  6ICJnMG1kODFhN29TWHpPN0wtVFRmcjVEQnM0bHZhNXhkVGdNVDVrMlRfR2UwRUls
  YmF0eWU4CiAgZjdjY2xBMmdiN203NVhBTjRzU0ZjbjhBIn19fSwKICAgICJSb290V
  WRmcyI6IFsiWUxCbTYyWG84cU9RclJOZVpqdUJRYzAwWGtsV0pwXzJGRXNLeUNtN1
  pKLXZUd0N5S0IKICBZU19YaEh0NzY1YWJlRkFjWGJnWTY5d2xjRFIwTFh3UnBlTlR
  ZIl19fQ",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MCYG-N23F-5DZK-HEFN-CNPG-MO4B-IHGT",
              "SignatureKey":{
                "PublicKeyECDH":{
                  "crv":"Ed448",
                  "Public":"7LUcjcbRmUKJHRH6rfqTUCwj-aVY_Tv40BlMt
  GGatDezFtFqUJUAv8jomyDGYp2gvmtGxsrtjsIA"}},
              "signature":"tyUw-CX4JBd2LfMVJLcQCo_gyJ6oO5PXFcAa3e
  JMjRC1bB39PYACWYNczBPzWz5j2GiP0lQwLzSAIObkgVtUa_bg1eVBhihnRd6ItFk
  7oP4HrNjJAXfUR92edJYhAAN95pL_7ol-_E08Su48CyBegDcA"}
            ],
          "PayloadDigest":"Nntl-CexUQkMIsiu3JR_BOtjtlNmd4f2U4sSCB
  MSa0Oo8P3Xy9RbPSizm-9ktFLebOh5N1UjRSJuLLpi-LYg-g"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MBQB-VIJP-5XSD-4LQL-R6VP-DRGB-T2TU",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFCLVZJSlAt
  NVhTRC00TFFMLVI2VlAtRFJHQi1UMlRVIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDI0LTEwLTA1VDAwOjQ5OjExWiJ9",
          "dig":"S512"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIkVuY3J5cHRpb24iOiB7
  CiAgICAgICJVZGYiOiAiTUJGTC1BUFFJLTNYS0YtNFNONC1SM1lILTRaUFMtVlNIR
  CIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZX
  lFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJ
  saWMiOiAiMU01ZDVNM1FrS1RIXy1oSWNaSWVsNnJQX2VYRzI5ZDJsT3NlT1NwTlAt
  UlNqbHR6SmFycgogIFRLbGtOaW5TSWU4RzEtLXRzcXRzUmxxQSJ9fX0sCiAgICAiU
  2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CMlEtVjdYVC1PVUwzLUZKNVotWk
  lCUy1YUVpGLVhBT1ciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAog
  ICAgICAgICAgIlB1YmxpYyI6ICJkLVJaM21YSkFhUGEtWmFaaHh2YzB6Y28taWpVM
  UlBdjlhZkt6SnczQnBrOFdqREJJdnQxCiAgdXZrTUozT0JpRkVPSjV6a2p4REtyST
  hBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQlZ
  OLUtIM00tMkRJVS1NR09ILTYzQkEtTk8zTC1YMzZKIiwKICAgICAgIlB1YmxpY1Bh
  cmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgI
  CAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ6X1QxYmNhTEExT2
  R0d2lNcU9pa29hWnlqQ1dWTkxXYUtXZTh4MTdxdndEUGlaRmw5RFplCiAgMWhhczE
  2N2JUNzNaUEpQOXpHM09TX2VBIn19fSwKICAgICJSb290VWRmcyI6IFsiWUdFUkx3
  eFVhVndNVjFnMEw4ZkNWYWJ3X2xRSHY3cFVTbTBUaXRSZHI0Q3VGUWNGN0wKICBEd
  URhanV2dkI4RHVweGFwTWdhT1NJNWNSMk4yYy1yaEI1cE5ZIl19fQ",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MBQR-CLYM-KRUV-YDCX-LA2C-7R6C-KWTP",
              "SignatureKey":{
                "PublicKeyECDH":{
                  "crv":"Ed448",
                  "Public":"jf_2wJGRFQJoIk-BxCFJ41SLSfJ0w09oMUzVb
  VThoiGRkX1Gz5SdvLTkkBrHHyaowqmf3SeCUfGA"}},
              "signature":"-fNYD3jZIbWd62Biso9VS8ctfnWcDOu5XvorPb
  mfnBLhAXhus-J3M2D4sa-7x7gDnHmx0FgYKkuAF06_QxU_gF3PS1jTXb9bi3j5IfS
  7HozqK8Ab_jufhnM_eQGS60L2S8CuRegQZnkmPKT1KVlXzSAA"}
            ],
          "PayloadDigest":"O9B56nlj9NMrFcKt-h82QyaOGSzm73FwCE0ff7
  -kLMG_IOHgjqUCx7zOKHYN_gBxMV6zd2nrBBhVBCVFDs1nqA"}
        ],
      "EnvelopedConnectionService":[{
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDI0LTEwLTA1VDAwOjQ5OjEyWiJ9",
          "dig":"S512"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tApQcm9maWxlVWRmgCJNQlFLLTRT
  MkctVENORy1ZSU9MLUlVSTUtRFRSVy1JT0tatA5BdXRoZW50aWNhdGlvbnu0A1VkZ
  oAiTURYQy1ZNVlHLVFUVDUtRTI1QS1BNlk0LUtJMkotTlRUU7QQUHVibGljUGFyYW
  1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1YmxpY4g52HOnPVQ
  3w401G2PpPYUSXW3olCz9LSsuaXYghl1jFxCNv8eH7AFDSPf8W3S0X7iowNY4pylw
  yvwAfX19fX0",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MAOW-5PUN-MGDW-NTP4-42BU-XE63-JKHS",
              "signature":"rtbUr0q-utwaQElAyAgDXZ1UlNuuyL3NGudxKf
  FRxSQ6-mIUeJcZO63hU_l2l8oCNzAD7vujWIMATjFEOHj1gJ_q5IJXUjlG7uvt2Yw
  fu4T4zdQoc2sFR6vDdZKVly4aH2KolOBXpl0IQ2a3TKzGjioA"}
            ],
          "PayloadDigest":"yHARvtdA_VIjTlczPNQT09VtWRK1rKHHUm0ZMC
  yUZmrythsL0y5c82KrQIFOgow21QFqgkonEI5TcNpfD9XsdA"}
        ],
      "EnvelopedConnectionDevice":[{
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjQtMTAtMDVUMDA6NDk6MTJaIn0",
          "dig":"S512"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0BVJvbGVzW4AJdGhyZXNob2xkXbQJ
  U2lnbmF0dXJle7QDVWRmgCJNQ0JaLVFNRVQtT1hEUy1INk5KLVBaVTItREFGWS1IT
  VVVtBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0ND
  i0BlB1YmxpY4g5Q5YJPyEZBwbzNvrVyYg6dCxXfk44qv6p8fFJHs9blh_2mrLjlyh
  VmjnNJvJlis2EOXGperuruFsAfX19tApFbmNyeXB0aW9ue7QDVWRmgCJNQlBNLVAy
  M0gtSE1XMy1JT1NVLU5QN1ctUFpPSC1XSlFNtBBQdWJsaWNQYXJhbWV0ZXJze7QNU
  HVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibGljiDn9jtsUI09pdRbfu-MKyF
  M_sCBmlzyr_D78Xi7sFdux00mxywnqxawYM4_5hMaqiIJZzA62ptEnkgB9fX20ClB
  yb2ZpbGVVZGaAIk1CUUstNFMyRy1UQ05HLVlJT0wtSVVJNS1EVFJXLUlPS1q0DkF1
  dGhlbnRpY2F0aW9ue7QDVWRmgCJNRFhDLVk1WUctUVRUNS1FMjVBLUE2WTQtS0kyS
  i1OVFRTtBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWD
  Q0OLQGUHVibGljiDnYc6c9VDfDjTUbY-k9hRJdbeiULP0tKy5pdiCGXWMXEI2_x4f
  sAUNI9_xbdLRfuKjA1jinKXDK_AB9fX19fQ",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MAOW-5PUN-MGDW-NTP4-42BU-XE63-JKHS",
              "signature":"80focaNgLRYQne_MetBfk_NdC5JdxYxqPEurzI
  6Nvl8MduhnGFcowROET6ArORoeAY0zgLBPsNaAWDKg8XT9g3qEMY_KYthCVaU9VEy
  vSod8tESR0JmCBm5w26jhK53tRGAHpobLiB2wuzdUo_KeyxMA"}
            ],
          "PayloadDigest":"qU8Gw3uU75mq0WVmVansm0n8qHR4IJR7VjWwKS
  OC4_jRCim5nBOOeOsi9eMqEOLx7Z_RtdB6xTwdFPRuYvaiIg"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "kid":"EBQF-OQTG-446U-AXFU-2ERW-MVEL-2T5P",
          "Salt":"ONNWDUJq-R4vCsHbDWkDiA",
          "recipients":[{
              "kid":"MBFL-APQI-3XKF-4SN4-R3YH-4ZPS-VSHD",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"XQDILjVBAWOiQ4HN1yxiQp0C8dIlekNmQQfWq
  U6KmkfLPskS1lOb9Qazs6ehReOMiqw6ST58lHwA"}},
              "wmk":"KWlV64E1TMI2tIx0E_kNxd609cede8UdErE6oTBKUX1L
  I0rC_X2yvA"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDI0LTEwLTA1VDAwOjQ5OjEyWiJ9",
          "dig":"S512"},
        "Qi6JLVRZFhBnzHJuYIJcfKe4iXLiOwtf5s2COMb3aHtMqq006e6StJYP
  BJB3LfTAFbgnjvy03UH2PQ7Bcs9mcEcakKb-FVvWBtxVHot2fyYHkfx_aGC4JFvwl
  QfiZYeozkguUMnGkJxc432f_tggLuPBwV3kMcWlyKLxocoBeRU2_y-7MxDgk_25EV
  tCefTpMhFhsh5knw5-2orlAiA4B8mZfebyGGxo-u3eekcnhmH9K3L8uU2dg3byLEJ
  FL2vp",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MAOW-5PUN-MGDW-NTP4-42BU-XE63-JKHS",
              "signature":"O3M64MuF0YoS6mOGXsbFaCxqeQXZWREicqpuy1
  qpQCR06pIj0fWlrijXtdqnl2ngtSV0EHVuaVSAW2jLiQnLYW1qlW82G-nF56XBGwU
  tILp7zhXmKlsWP5HkZz4p4B6mqPmeX3ikTE_6DODtwWZOPCoA"}
            ],
          "WitnessValue":"gCxsYlqagIckYZY1sgT1XZCv9IK3OpfAiG1GGzk
  RSoU",
          "PayloadDigest":"gJZCZvoOtkUXKtPB58yiI-qDooHxmqeQ1fEOto
  HsxM0ablVGnOKa7y965dpT9MrXrnk3Tdyskg5mwVhssucIhg"}
        ],
      "EnvelopedActivationCommon":[{
          "enc":"A256CBC",
          "kid":"EBQM-XN67-AQS6-LO7P-BCZI-QUTZ-Q7J6",
          "Salt":"A0Yf94UTlkzkKk7i1d5ceA",
          "recipients":[{
              "kid":"MBPM-P23H-HMW3-IOSU-NP7W-PZOH-WJQM",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"petiyk57zFe8sMPY5nbT30aqJt2Ph9C9tV4dg
  d9DL5UZr44OTpyaFkGEGnLSEWE-nG08ki96JkqA"}},
              "wmk":"E53zIsw8fAytwe-OdkTJDM2p7UsntY7463aBRGtVkMEk
  noVPjzY_jg"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQ29tbW9uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjQtMTAtMDVUMDA6NDk6MTJaIn0",
          "dig":"S512"},
        "U3k-APXQy5Ulcb2yjV5kGGTLkoapRMBm1o15A1wiDbptO_qz4Qd-MukG
  _kPOuHugcqsexb-8_BlIy_O5moaGd8b5YIf_Kqoj2jQW51zjw48wq5-cleVZ7OACS
  FruNTuTDOe1Xlp9HtAOFjBbLs0FM2_Pru3CmCT8t097szSIWqQ-UX8yvwqoSPN-X2
  8xxZFA7BZFY-_oduMJj11AiQH2UVCSsn2F5xsHO5V3zZJQ4ivl7WIPX2LENxjv812
  vFF4fN9cBP4swxHgp_4u0YAELWlKA9pSHLfgWCnlwIWwwg4RRwTBqxx04J9U4V3lR
  Aztw7OwN9HrWQ7sUlaFj2uA-zQ63W1YCGA51EdkFTisx3ssR_nmopnAsq3OislzLG
  KcMa4B3JU7Z25hoYVWQpp90SCLxCyO7Ca0RAqUwPBejDgX7K3eFd7pQ1svR9KRTKP
  7FFpc2MFoRuEma4L9ePGxXmO0XxZFQXAW00ThBCxMu_aiisis7jSWQkcnOZOX_uvs
  vi_bkdM0PfFjA4SK3Zc6S4Tx1El07IQqo8tfsgj9kWuBqTlD80YU_VHXmQ_hEo1OY
  LD5In6FQO6qq1CNoQmi5jXkwBOxUCEXDgXUSO9-88cmZpuKIMJOwcaXgZIM2f2Ptd
  5fMl_w2Qf5CcUKBWx2BfDxZWefYW-ganjg-r5RAn6BgEIVWhkkWj_XdM6Hpvi2LI7
  pAd3BHxtc978VtjMjl1ggB8v3sD17DkGv2UjNbkWz8VMkyn7HKG35414dq8LqDv4x
  LyHwXcDFab5WjJ676KOe12w16qdk_7vxqtDwwg8nlxdndUOIC3L-IH_QY3NXHqyL4
  8zLGlPxjmaQc4toMG5FbsLZ5Vwnvh2lhZoK_dEKovw8EwbliK2uPD1m5ZkdT7QwgP
  KPqSSf7kaMmf5s9WPcH2n7Ko9rGGEoXv7YKeY-RcoiITHqpx0DT2du9t7DCjISpmk
  RkEyKrS97czG2PHLl4WsWbqlCKLRFH2PhvFwGjlBzI9VMTtmC5CPND0pQOUIlz7_V
  TyJEmsU2sw3ddhIeQlI8jGttdMI48_BWBmmY66SfcnE16k-lYXilDvhz41WfYA5LR
  fdpMOQ-vyKYiNWx285yLV274kYLwKu5_pHGzGmCUxCITkO9ofJH7uJeGtZfmVoFq_
  c-BvONf1nnYC0j_NozGwoUcS89rUpmprHKy2vGEaH_vzTxcY0eX5-f6An8MEAyBZx
  l1YV_Ik2XrZmnv7DQTp1tsvGmq_K2tVXPJZTUk_xy_6XuHJyvW9SXLqd_ooVOQZZo
  9SvYq-dfrI4Qb4b8vm6PH2f0X5MtGhms5CqcsecQQeGxMCBZfA0c5z2q9EJZ9wU7G
  e09M0dxl0aln4lM3mbQnLVCQYgN6emmZ9t2Zi8Tk0foWg8JudT6bqigOk3rRWyUWB
  BhHAgCA1bZgNQMiaPoIsReyGAv8AIbJgHt5yWXYmeeZxpYgyv0VUyzwGjrQkXOMwC
  k28EXpTdriA7nASTjYHp_jLBI4nPaDLyO9SEPoRaMpIk1n-92oiPX4YFJ0WP7DYy6
  XtkhIjI6qjquyyTw959ZqYzVuNM1mhuzPhhsd-OkModcGur_fAjlAjyhTLoKbzq9S
  Ui26LB5cF-JY97cOJ5utSm3uLm09dl84xpc9FxFYSIWiID59v-kPEXzhi2z3KtN-h
  nLtJNOGDY_xba3vNdJzK6TpIWAZ62Ir4On5wZxAcq-u7jr2WQNgB-HiKJr5R3D2BZ
  thzeH6boIxgLD8rJzVw2TGUhpCh7-q3qAmeQD4RuBlzcFtJXv-vvIPOy2WCFp9WrH
  fKwKv-bzOimCTOBejK_X1AaOe3VJWBF0sh-VkmLyxdITm2hezUdsWmhjhRoKUzpoU
  vNpXtq6MROBiDrHSAGtZMcEPQ4Ao-dKy-scQMRMdINDlLwy3kNQgEgadBhI9-DOUG
  srKdpB-eeb2QxmS_GWsvKofGtvAxdofbtyrkD02CQ7RRI3J_awVImfxW7uBLQzXCf
  9H9AOttsWt8gdpusIOauiI3YxSJE9orRiq2-0KRZSY-qFgp0p4hAvmDpaHgqoSGVp
  I1M0VaBhL3P9iG1HFGM7XDcqD1s2R8hwkpLwi_jd_QDN7uyEqrzKtO4inYUZdOAN0
  uZxYgm0eeOqSCrUKfWTSXADWVEPtkMB7SNv94embQELT_2Wt6gHCq9Sz97UlqfUP2
  vynnIi0Mzyy-6anXLmyxW-f1wVf_hnzg3h4f36LWjbn3aZoPUPcWjpQaP5OlJj45b
  KKp3nA_gqr-SQEarTZ8E691iTqt3g9lodUci7WCrgRL_cEtkCCKM5A89FACeLxPWs
  qMNHpmQI5ZINf0BUOg8x7hf-q1ASI9vBBFsXq4kx5Bpnt8Od-_lEzE2OP-kJ1ZJ3Q
  YWyGIZNkiwclJ6c-CjnQg-1Jmw06IspudNwCEYpSxctMIrCKSkVfQDodL_OHFf961
  G41NKAVEh_HesUpGv7aeU7addE93pfGz0dmr50KhbUEzp1A4_bBLO2g9Wxf4tbXn7
  P07hzbqD_hw7Ap7IQUZD56KpMq4N_h7YxLG10B2yZzw2lZvjq61OfzDZMG8aWinxQ
  oWKbHwXgjzeaG9FpSaeXZe7AH20BDWVuLJVSxuNkPe9caFQZYTqc7fuG6xkCTj4ib
  yBUo41qwq0AyEaw66zjVjI_yDCpZkJLQVpAFgic5u9jBMAtGKWUg-VMdWfd0lZvsk
  wpIiCrrkVb3TLXNl7hRrGxWkOBj2Pi4MaN5NBNAwveslT2J8D3GyDF0TymI9HTpYe
  2iL6qI8w3nnA8yiMPyIJ4bfq6hCY7SCyexcwx0mNS3emoZT7QWDx-8_jCMl_wpmQG
  ZjhnlYZJKBTVMz8fNJ-j1r0rJue50cN6zczDaIpTI0VrV12om4_ml3lHQrkWOOvS3
  SiFHe0Ag56fIYm-Bx85A8p98Nz9VOO8rHNtIklndRz26eOneThwbcEyAWcsIzUiCf
  6ntmBRLzn9Ph2vUU8knzO95SB7h7sdbstQwAi1SA5Yo8qsrjLEgpNxIykcHEzRwZP
  FVrdoeBDCMZ48WSfpx7CqZDzx34Qx079TzXzrZpRpJIIPLhk578XKaW8j31-bV3Qi
  BnNQw6XwlEMRjgJlVLvoYW4kNKj0chBMi-96NDhHb2YiKwzPC4XAjN5RTYIQcp9RG
  Gf5noI7vXW4mygcwXTFwEHsvR4PeUtyEI2L_jtatP4fGkxF5CGi-JHmBg-P73A-pG
  T2kc4M_dZ_8vk0wRsECCpOH_oaBEG2hyW-KBapKx50GUqecDNZaJFUSi4rxiMuIpN
  VDAlOnfsUYATWkZlcG9rD3ELUcTisebPXRERRtOSTuS3-_zo7BUy0sn5mWewzoOJ3
  irM8TLFWVmy5uLFTrXxxhzyullEflr-XC6SAreUT_bwXY1JFcDEixTLW_yosHAUXN
  zAVpYomnxlrB4-ulqY8V89mLfsVDzCJaf-s7ytbO2KWkz4PAnjSNqQjTRSHu7MPxn
  SMG9v-phb9VYh-IW33tuJIQ4rzgyCnOnGwtCzkS_tEd2WrWILj4s9cnabUg-t5xu5
  w-RuhykAD5f_7y1q1HRpYJsd0KxhfJ2TlPnwY8nGG98i3ofB-PHt4dObSgu_V7vrP
  3yh5rWiQ3MkC2Bvy2TSrT76uM3_HrGogpF23NQ1Q1v0Yqbv2ELJiA9EjJvvKEnwsO
  ojPeRJ14q2C7pIPBzANmj1h4BhuekV5R7QXkpHHulHy76RhtcCDJCJITkzOfnNKjv
  379py6rRJf-d2HrzS_7uI9Ndc54RIrLHP_izGUSsWjGOjeiR8LCEvEMtujMrqXRj0
  zQEhNARqwAF83ksRrTzLNSa-PnKRBUMB9Qauhzeu0T8sC_u4KPhjIqSRoO2Of__S6
  eL1kfDLP9jfyD5jFeke0oJwCh8VX4qDN8rwZ1hQjiaKjvJovwTS8lZSRFLrthLD9A
  1D9HLyEyOL4FkFdpamela36uUNYvOmF7iMov-hjF9trxOt17hEMrj4W49zFvTnGwg
  I-5b1kaLYW1ke9oPqSPj3kGkZ6mOOiumiOqy9qYo6sGs1Db7jONeHzfoXytMY21aH
  SAOfSIjFtD2DabwaWnx8JA6kunZqkDoDyYB6nAKAAwJ5xDNlxoh1aSmpgRrVsKpg8
  NmFzyWoIEaRKOiyvWbqFWfKSmqmfnQ4fDm2k8Cn7qmUTL5KttqBs644_Z2XTTp3h6
  090Kp6yiOREEgqQgW9OIok77ahgPaCvsBuXhDfKxfmYWfMIvWp3Mtv5J-jSKgPV7i
  MD6lcX6S2gEMVHP5Hczp0ijav6MtDUMb2mKwWYA4L_17Idwjx9vNijkB5LTaU79p1
  cfqW-wbGiD_GinjxdvUN_bh4O7XgZhfV4e2tSkBZXSGggFZxCUBZ4GrTSSNK4aPlV
  ZNRj4mrXFnSgVoweCaRIYUxnj74_iNI5u4TFRi7OxokjBBGvkzylbeO_8zSxsmD4Q
  R9UM9O7sTbEjSf3qQPbbbVaGZKG6hNJGnSuK1XUzKoLBhdu6WgYmBVeEIpv46A0yO
  CCKM3C_DRcbHM3dJ7x2JZbraVaYPtE6iz6-gMUebOci8mR-E4RVSwwDpDnv12LHa3
  SqnencE0BNvNkTz5Q9iHC6uexVuiEQp0Cg2RGBtZ-C9anfZtC3L_euZYpibfgLgTL
  B1_DZo_89wnTzLT-smVsmYmfGJHQKyNEGt1Zcx8t42U9WfS2n26o83mM8plDHMTVh
  sL-Lwy4cSG5AndiDmEuwtB1IUODszvBczYj_9kVEiMHIvrYGT1UDnRMRdr_g8vc5g
  Qilz2rTuLt5ToIbht57JWwP6xCOAUCZqUXcshJknYepJxSinrMQNkEKgD1UAUFdlV
  Nq-NKr5OtGKATi5Jn2PqH7zFyH93hiBIxReWP_uyK0fweSgPLbOqh8iiwCHlpJrOC
  CzPu6lm7LQoNH4GdmWo9gd4H6ty0l5wxTLLTJ5YE_0emQFDQJp1A6pU-KvWPRdJnd
  H7eu0rQDJ3_GMXImQ6-CFD2GHR3TN2lAcSGF8gYUMYD2OAGg2V9ANcYTGZhhVLHmR
  F2AjqPMRy2ewYsS9Vk_r4ul_jDguCeUmTsFY5eYW72GdMNo5Inv08oTlYrjXoMYL_
  cbVV5bnXqgRT0O3_sSUPr4g6G7j9qeTOphSZ4e9fnyL9UvjzYaJyEBPGxeHEWTFw0
  EMMF3ckzMyH4iXAX7segq5imHLAE7rPMNXSFCYXisv-ruA7cCu794hpdfoOYPmdKq
  zzoKpB-cIKL3SeafbL4fJOxEb6KRZOwkVIk8X1QVsQlIqY162gKHNGJKEn2yRFQdA
  I5f2bvFHbcMcpfX2OVqT6qyqLiY0ccSeQfiV0JLrrpm4pL-wSvdOgnKW_GNTQZeza
  zrpRdNo03R5wWHpk7jTTIlkVeG9obv3eBz18ke-iTF-e2UQkIRQ0ymaB_2-k0jg7_
  qHSc9zce3NFwAwmt1vZZxlpJ60X92sTDl6PdQx_bSsbe4Oel0o1MmMW2p0KV-doUj
  7tkBGVhaFjIqNhhHvaPVla6v-0sxyzpW8YDXjX-1776WpO0lmBpC_IvrLILPTKKrX
  YpF8zGSy66mFIjF2n8dyw_57zpHDAZbM4SQxZz0YuZ8TP75SbeZeks9kjYY6xu0dx
  uF6PqEJTZupjxynngCQoI2atFwir9W9JdzqBRJpMAlD9S_rs5Q5tQA6B8yTyjjWI4
  T9LXH09FbAM0szqD4Qo0iFmvuQlwobjaodwR-Z7U9K5jdlwDYtHoW8uM-a3NE4AKY
  MjpmrLj6xtvaL78s9azavxiuZB6bFdYlJUzHPsyKm1CoqZAIGKWYKHIERltGUr1lh
  mwiibrFjpchcnx_x0tr-oQ1g_9Ywc08dPAjNNSGamCTFGPeFmxM5yaDDjEehEyo_J
  i45tqwuklGyLhp4upEgTSRp4DrrvuTDiF_n6yX3MKm4vYpuP4Ikb2VW6TGLE0VShB
  eZ-kcM1xOLG1BbPvKtareeW0R-nQbon4c-VOld25Gfca7Z2720jWA9826OH4kkVI1
  PHf3xvNH1gTHCSr6nyJ736yf4IRnIQDBM4A_7-rz4jQu3UrLoYfX98Swkvq5NsJ7G
  4awGnd--2q9EKLfgUdFVUd_fvJAWAbjNEYhHygeEOKSYHX1P9j9OdCWLJBP43LwR0
  hlsKiEqVV7SYm7B6njPlWWkvf5JgnjCPNlcqv9KAAYkevOfHcnireoUzMos4CteaT
  oJpY83kI6MZxBfCzN2SJZXuxZJH_UJujSFk8HE-hCkDRx8fSIrD6TRcC1u010xSV4
  TF3zWgUFQf-_IodNlJyXi1HDy086x4lbkgXLV6hQ7astqXi94PasFgiUUV2s_1j7c
  g8YGa5fidLdwQRdlGkDfv8cM_9fFnwMgMMtyZX4_pc_Sr2wwRXzcNaNPkjZ_JbmPP
  aED_KeLVf4scjnInfIuaTzKJ_NJKtOgtggLsZ05y6-3BsHAOVcKoX5OgtNC5To5qv
  yq0X0DlMhpz5l_oE6prC6udARQ6dCfcqNnp5aevuUCASIK_PuGOgH60qO82EUDFcw
  ywmEfbJbJq5SZjcP0RIIXrIqzO-YgQiNsch4YKBEzd_Tm3Obop9PYNJbozr-IZ3Zt
  uSH9euP6nt1n1SitOeFYoLQnMrWRm3lo4PJHHX_QO7nqXh15ddbpiWWJiRanje4pb
  di1i593WijXXWA78Snzs_jAtO5mRyEQgOKhqWPtAKaBt7LmzXk1tXBTiJdxThuzuM
  xRLYU1e7rS34T1FVKzvHtY5mtmcNRVmSo0q6G185MnlulWsAT4bF3Qe20oXTBJCRT
  3tLp2E0YVOOChd0cOH27r9ppFmMDL5yt4Y3LoAIFXYYXpgzvTuo6Iv5Quf72T5894
  Yaqzgsi97QPr8ZxnVFbFX34YAyI4oOsUlj4d5jRq6C2wKlTILABob0AQfarVneI9r
  Tpl424PvKlHkeC2Vv6wZ0ACFLFK-UYXrr5zlsQHbXoykFpfIP2djLVGml70h6bi8R
  GIoDzf_tPU-wpbGVAM6b0QBuXhGAct6WBrPdmKSLxgZsf3ARQR3CIx5Yx9-yVPWtL
  L9chXBTZRRdb0tyfR3mxVN_3bC_o6BH0vhK8lk-DkFtIqLeAnZiwvGac-nZV_Q9hJ
  33Tr45WLDgmSJXMriqrBlJPZp-8CztIbNQDub2mgftKSAn_l5YzFX7SNOZNf8G1n6
  hH4PRK6f7R_knlm5F2ZVb71j0IctrCjmaKZFpitYl1jq1iHDQF9P0Zb_ZJlRrMbN5
  xIPsGxeCKcyIvPVkV5uOzYmENO1TOKsntp2EM4m26unCyBnRjZyEKmu-yBF5lizmU
  AkR4zyAiPnEluGcq1fPw1CAJy9qBYEH1QKqwKCF6axEg5ShOsGLZsf96iGwACWKyo
  S5NlFYi5ak4nVbl-uNrDnoZJabNy0BCH-B0z75vzK3170GAHtE0K2VkQhuK38zPV8
  6TL8y6yPxhD1hJB-WiVXH5giFh_LvsOpIntaf9hJZFLBX3-P8W-DtU8VU54p0K_ET
  UWMEqgEANGlhJCpY9UZGwmatu8Pw2bL6Y-KzdBEZho4r3QXCDSB-8tXzxrOLf6PQC
  zDdyjPSNkYQBx5YOfOIfoPCtNNpaS2zdRy2pIgVnOg9fsn0U_K_N9BZwmbp8yPvhd
  fSzaSK8C3CVu7JyVGZOd090zm5OGDvlacVmNV50L0wd0_vAV2mbYHCFgF4ceou2XI
  7PePQSOCA-ioIkSlnZfAd5TD8kzpeRScJJ07nM0WNmvAJGzkwFYWX-dlOohOkGJDM
  tRB5zauoADr_ijtpZPbwEsMoraTp95DQx7wrX7p8ly-GhtKEaIDcMpHM6cpX3Idxy
  nCwRW8TnsTYFXDtsWSIbYcs1gYjWJ_xpoT6qSXzD7fnUd_mw9MEgweRdT0nNdwLuo
  YGEKtpxOOUp6PlACYqRdT-fJWQKiqVEjd83gww82XoLCD8D3MAqoSiVT4I7cDjAZj
  FKX6r0V8vwq1hsWMLcG_zADp__ydfhVbbuj56GIXhJ4Kc5vhBHyB478SFQmnjGo9Q
  HgrhEpFIeEPqEOZtVFNQEq7_isxC2cen5llUoJm8i3teDdeMkhcfUwM7kh1yzqZOj
  j6rgDIsStfbWb8B84SoRo_Ypp0ke2Y85-4nTpEB0GfTMLDGNk8DrMgA3tgEiUIy9_
  wr7dPASbSxCkZAuSiyfsE_oUFKxBLpzr77ux8Mr8fin6FHxJinYKHHsQNO4qBd3Z7
  uhpkHW2-2hn0_MiS1WLzX-p3rDCUbr-zGu999EWzYDlomyCRzrH69nAi2iQ9drL4S
  590MiW_qD9DOKeDKXXAYCfpv9lHtP7H-d6vCf1xw-QxOYFpvElu3asur_64dKeRS4
  5FX5wnXsaExACgflxZoff58I8tdsH76O8vDtCbrLma8j6oO2RWyr8YJbj8OWLAwXA
  3ZFjjRaMzNHcPKx2AHhVIDqVJZwpK5n_xS1w1Eryc03k_6QDGdr-ThD5hde9bdhPX
  GkeTDpxVaMT7q3lAFeu4-AyoEzxPQ3S-5zTDrKAzod97maI3HtXaxyQ3v3sHA2K9b
  1dH1vX_9fKAC4Lu4O7BSXeAw7AC30IPf035qYBPOhJ4CU3y0X1W4MhfD2ksO8RcxJ
  Jz8ocrgoMTDMHsFWmjIQ5nWBhQ",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MAOW-5PUN-MGDW-NTP4-42BU-XE63-JKHS",
              "signature":"DBi_tfkeIT9xI1VwSY2AzDCqpqoB_1Z5UXX5aZ
  8TAr94GLVVKCTWbqkqVCkciMBX7pgRItRVZBUAxYZ3GNHoRtC8kiqmQZuDcfOpa0i
  lL9Xii48O6wCjSm-eAxnyCt15psJM1Vic5dXoNxMsF1LsNiwA"}
            ],
          "WitnessValue":"tIqiv6gvaAcO9tXUu8k7ao8goTJoOZJm9oxb9ME
  IIik",
          "PayloadDigest":"nqGKe4UQbJ8u1go-2sMcx0PnObT9LvakAP7gtg
  2GFy5ogzjXW13VsK2GyODomzDvMuhpq_HisECql_EramTgFQ"}
        ],
      "ApplicationEntries":[{
          "ApplicationEntrySsh":{
            "EnvelopedActivation":[{
                "enc":"A256CBC",
                "kid":"EBQI-PN5S-RCDA-PE34-AW2C-NSSP-LQ5O",
                "Salt":"-AgPmSy9nGRT3r6dY2IJEw",
                "recipients":[{
                    "kid":"MBPM-P23H-HMW3-IOSU-NP7W-PZOH-WJQM",
                    "epk":{
                      "PublicKeyECDH":{
                        "crv":"X448",
                        "Public":"SV17AP2jKayGhajzxjEVftWnE3kDZoh
  w82ZqDEiLsagpgjFeo0U8XtoyHcNzpFYN_fSc4i1F0pWA"}},
                    "wmk":"Ri5ykUFU7OwXPAkRqjS1LHmb_YKc2dcyybX0-Y
  nC6a4gCHTLmNbzxA"}
                  ],
                "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3
  RpdmF0aW9uQXBwbGljYXRpb25Tc2giLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1
  tL29iamVjdCIsCiAgIkNyZWF0ZWQiOiAiMjAyNC0xMC0wNVQwMDo0OToxMloifQ"},
              "Fw-Bp0i8Elbr8iSI8aYi--KlxDMavwSSEwXNRD2Qku5XC9kVj6
  icIM9hnm7H1MbP0734G2vWARlziBzGJbQ8SX6OQObm9Jj3bb9cQSJtG2VdXdBcAiu
  50deqv8k1o_RtHpd8QN8bZStGe4QOO6ugJ4aH5hBz4X1hNNvewbuyoCslPOMqBvd1
  yZibgObB1CwCUEpDNSKoVDod3zjgczXwZfpkcbORJnE7ReIEgzKqrjANXUJ_sHqVe
  YRqJoBigR2J-Is7p821Cq8iLau3bLdc7hjc61xQPuehrLCbrhNDzjrDSJUU5HNGY6
  qc_s0BD_BUaOQ84fG2U8sMk-DtHdAQEaXClKOMMAXujuLcKk9lpVxGW-CEqyuq02g
  AzK5iKiEWzvP7__fpLhaQr1Z6-hwdw9ZNrS4UXDurZxU4EDHrn3VjcqR5N5meUmID
  qs2Loe_7HiyYG9lBlwkL_IIY5x7lVNujtUH-1SN7O35ytGSSbjG9qaOdHlQi1we9s
  bs0DMPXncmgQSwjAxayHhjxZDdg2LTz3v4x7edaPGLOcT7mV45qyAXkyJwTg2mrCv
  d1QrWnvhGbuZzjUCxX5_OYLGyJixAnElHC7wVf_KCjbQaK9NO-3MJ31FA_vK5u2jn
  vloYrZ3IWgiwlwWrCkrCJdeeuQ1g_wWpjkzbpykv7XQ6ua2YYqGnwpqnHXv2a7Val
  B4aMCoUxgwkoGmbqZUjz5nubOfUWp7KdeVp1Vb0tAXnd1YWNAysaDYUL8quFKTQi2
  XiIMrR49z_yFAQjb4oiNNb2fz9NnYeXYJDV8qwacS2B56cJg8QOMZZDF2reEulWfF
  8nVPhHF_x4rCZVo0AV-GiEpZf9P0nnLAPlG6ByVmweZHs5X96jPD3_jTrzWhJZWpj
  pxLF72ntXL1t5sSqniTaaPI98D1lAZBTU4ahwdVQ4gXqqRo7MYd2wNNpiyZotfFxQ
  Ajq6uPf0Y53gSCxAWbb_5tkar2SEqSGZc0V_k5LEq4kftUqxHp6xVPumDGWzIeTJc
  yyKrGyWVbLaR1uYwn-7AqT3M-3V9J40LeKue9jjycq3hiZEJhTlkHr1JEggVmdViX
  z1JUJnsX1TYOP3x9wea6mYBBR-05h-wA52u3g3gvhoc_azZWelQjB0xpzVQ7PiazK
  Fj7YdzI1vtyHaOq2FXC_haYPP612FTyeQsRJq_xytHHyULPFPBX5fC0v-TiNB5W1R
  alJ2gO3gNbcVr2ihoJlq2qvDrIjrjr1nqq56aYX8mIsckpeUo_mt3AmzUHRweZTye
  1S15eTc9QmQ6mxPLUYfE9RduKZnGMrYqrTeey5zsNR0umSL-utpU5CuwjavIsAGb2
  rWmwGBcC27ZhoBYFRCRvbqJqoRS01XaRjN07OEhRtVk-g8F1U1mt-rq4NFSJqK32a
  LHCxEn78BZU24zbRFxGgS-lqU7qD-5ac0_DcqUPA4B3fK49SdQTymkLNf-oJlp5m1
  u5Z8a8waj6dqSwDAB4Cqjgk8AZWSPQ6YXr8uFm_gNS12yjDoFekuiPnXeg9Ywkanz
  p73DRsZjYDHaH9y0Qf9SD7XJNw7gCclkrAuxJONYfBeNeF2oh5bb9zDPd2btJ28m_
  kqIwrE1n9uTX_MLBal38jS3qPTqovxO6_LTXRC2YDfswskRPjPz8wgUYvvIciCW95
  LNqaOlsIxv2ptOyKtM0bu-_MnI9NjPZkafGyYwPIJcO5yFKGDe0FV9H7qA7lsguwR
  LOspWhSutUYx9tZIIspqsVfmtebf8teGcWrEQi0bMrqC1arVXPdnxMlJsl7dQzz39
  FnyLnnwmzqSRH7kiqClekXR9g0IgiGlC_PQ21ls67qzRG9Zq6Fc7Ojj8CdnaUpOMq
  EcQQdADuq8XZRxr5bW_MJHnWs5WplXd9wGAoFTncxpa40gODnuRr9GijbAZz14ucZ
  tdQbB8d5_JCrj9XMV5qJIr9wajZ7LllocjmniYeC1HCC161SH4xD7N_jaqkqm-Jn1
  8fmmzTN1934ISzRxEpi_h41FHKpe2LQ1MU59YQx3AFFnB786aGRgMzKup_nL6hDzW
  7AfXCuOHbDEhmWWmTDl_lVq-53sJ2R0AYQAfB9bOt3CeByhq1SS5o0NBlpy86nVE7
  hU8vr3wPHOlOMuSZ4uQLoZyApi_rPBunf4AiaACzDouYuXSE44nh5yn_UB7MfY4C6
  _zZeRs9q0U8EMqMr-BxwW4rhPt7KvDob9N9Y0CQBprt9OlCUTpDNwZYdTlW-cBqmh
  lA5Sn_1niqZTyUoLCQO3b2tELtlRkU5BR7QrJgTNR8-_Gy05L564S4TJnk7CYJmeq
  NnLZPDCmeKmJG4v2vxeoXNJVp84Vb_PH-SqUJVmEmSorEqI-Z2PumTn5-pSeUTt48
  ezCz1aJb3MjQLA3Pp_XesAgp_y4OdV0cdsl14puOlWz4kHWZFvOlvI-zp27eJQhSV
  4uI7QYg6-OdUWiqSNREJ47DgqjtGc078F5gEuJz6aSsN01-hb-hgNC5D788oIHv9T
  dzhaVqDsBwPRvPZQXjoTR9G_-ITS1097EBFgVIT0ga_rfuagavjqLWWmlnTD-C5SP
  mwWFkCyadkdTSNEIcPI-HUuCe6Ln7nkVlOWt0R0cgm3OJjqLMz_7gAIX5tjtZQoYL
  zf5oEfxgVdGCT_i4ruBi2Qo_2e4gsVpraRs4WWvnowKuLkQetF2xw_nQ8W_oIewBj
  4UFUX-_kSZYZblEyHjHhoz7HjiJlbxpFJSyDVUfHYjT8xSHJ2X2Z-dOVWOYf71FFK
  t3KjgK9EgNHgbUsVsHBpYiwHtify0ijnInoxnj-K1gCeKFVtIMax13LnsAFvjUBoZ
  rAGmmBrnBB-xEnBmMWnfIHvk9R-4KzvHbGCfWjIQrTEg5iX18ag2vxhn1vWoCJmDX
  4oOJmDy34eb_k7ku5UVpAPFsN4lnveAnKfN9RubjrQHOeyBBy9uPVNtt723ZCcs7l
  KRduZoi6dN6k2HGeaPUnD8YZaTd5adDarca-BVQwiimcvHPZaJ8XwQ-zMlaaj3Cvk
  lp_itxJb08mqSG3AwEwhp8kiaw2H2S9SnQnjoFavZ_AxNRabPLvjgifNKx078qOtc
  u66UC6vmj0qEcOyToM9gGbRkrS9DSO7au1yBl89GFL4MXaiJ25oGoJGDuVlnNuUUj
  w2LxyKlQvlYGgBeO8Zci7vObghcgntPO8H8p-9YMFn_iF47_YlD79EFRT-2i6JW69
  jpRifSidfoeU6sWwuKgwZ-2MTtetlngziEQ4FKkXQH3q1Srdk7HPfdz5JS88pVZmY
  FWLKp2GqUkZq_sIs7goVNvLby1Qc"
              ],
            "Identifier":"MD62-HEDK-M7T5-B4PI-CV2K-5U6R-X5LQ"}}
        ]},
    "MessageId":"MDPP-AD5H-QIX3-4GXL-3GUK-POGY-OMFJ"}}
~~~~

### Phase 4

The device periodically polls for completion of the connection request using the
Complete transaction.

To provide a final check on the process, the command line tool presents the UDF of 
the account profile to which the device has connected if successful:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MBQB-VIJP-5XSD-4LQL-R6VP-DRGB-T2TU
   Account = alice@example.com
   Account UDF = MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
<cmd>Alice3> meshman account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MDPP-AD5H-QIX3-4GXL-3GUK-POGY-OMFJ"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

