
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=AC23-KHLF-VHYV-MQXF-3PM2-WZRM-TU
 (Expires=2024-10-05T13:13:13Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcd://alice@example.com/AC23-KHLF-VHYV-MQXF-3PM2-WZRM-TU
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AC23-KHLF-VHYV-MQXF-3PM2-WZRM-TU
<rsp>   Device UDF = MBQN-TRFD-22HH-7VJO-3B6R-APJC-HUCP
   Witness value = TWJD-AUPC-2BSP-3V4U-ZS2Z-S63O-2KNH
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "AccountAddress":"alice@example.com",
    "AuthenticatedData":[{
        "EnvelopeId":"MBQN-TRFD-22HH-7VJO-3B6R-APJC-HUCP",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFOLVRSRkQtMj
  JISC03VkpPLTNCNlItQVBKQy1IVUNQIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDI0LTEwLTA0VDEzOjEzOjEzWiJ9",
        "dig":"S512"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIkVuY3J5cHRpb24iOiB7Ci
  AgICAgICJVZGYiOiAiTUI1SC1DTlNTLUdCTjUtUlpNSi1WMzJDLUpJNVItTTU0SCI
  sCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlF
  Q0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiWXZqQWg4YzhHQVhpUlZIQjdObERqWGZHTlpSME81WVpoeVdfd2xOQUNlN0
  FQajhsRU94dAogIDRXek1UUUJ3aHgwRTBBa0c4ZDUtTnVLQSJ9fX0sCiAgICAiU2l
  nbmF0dXJlIjogewogICAgICAiVWRmIjogIk1BM0ItVlIzRC0yTkhILUpHQ1MtUVg3
  Qi1ORFNELU9FUFAiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogIC
  AgICAgICAgIlB1YmxpYyI6ICJ1N2VYS21DMFU5YzMzdkZlRUR5THZ2VE5NV0NqV3h
  xazFpUlR5MUxCQ2ZWbU9PMnhFRXJWCiAgTWllOUl0blR5eHQtT3Zxd1FvR1dKWjZB
  In19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ0NDL
  UxCMlktWU9ENi1OS1hDLUVXMk0tSFRGQy1YNTJVIiwKICAgICAgIlB1YmxpY1Bhcm
  FtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICA
  iY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJPRXh2NUh2ekRxb29k
  OHhJa3RwYmVkaGtMOG1qNmgtYzlhT08tTHJhMjh4dHY0SldjSklwCiAgUU0zZnF4L
  WJBUTluRlJTMm5hMHpCOVdBIn19fSwKICAgICJSb290VWRmcyI6IFsiWUg0cjZVcX
  FYRlJfdEtDUWxjRnJtS0RaTVc1U0lJYVYxYWQ5MndPZGEzVndiWXc2OTUKICA1Mjd
  qN1VrSnVFcTYwT3JER3plZldkVXJVcW9qWUtDa2J0OUlJIl19fQ",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MB7C-X2KK-VJOF-I75U-UCIJ-LQLL-TCQN",
            "SignatureKey":{
              "PublicKeyECDH":{
                "crv":"Ed448",
                "Public":"pxyJBRVOWfftdwVGAtp-BDbY7w6FOD006yJxISo
  UvdRP5IFuijzkxxNV4EhFCZkupQMbmLm53wMA"}},
            "signature":"t4kHG9Ej5FYtyq4vblj_7dh5oUgGf510QyvOyN1Z
  BHhf_YkLA_h1TK35lpdFEEcPcNj-XZsh1-8AxBbug-Y8pyCBA_I5vZ3dLiWsA2UyO
  5l9fFVgehE2Kh1sH83VuxTkOAK81xny1t5gEsdpoAfa5wUA"}
          ],
        "PayloadDigest":"oTQ8t60iV1bVJg87V7uwmIE1O5-JL-csxJn7S_27
  qAJKGaTPGfHlpf3AHXAHqIggnV6VpN3HB1tgnyZoIEfzhQ"}
      ],
    "ClientNonce":"VXn6AoMOAtiwz6Y3Jszjkg",
    "PinId":"ACQ2-2RB7-4PU3-ESSI-AYXC-V5NC-BT3C",
    "PinWitness":"pxB5xzqSaJwfPoXvvZq8pbAsN0CVcQhfaLm7zrWOhJFZc_R
  RW8RBMfBxzIW2xhZEEOICRvB8Eo5J7IXUPeUbTw",
    "MessageId":"NDQO-OT5Z-YYNM-4O6B-5LOD-6ZCO-YHJS"}}
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
        "EnvelopeId":"MDFI-HTIF-UW7P-6F7J-33VL-NMVN-OG5L",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORFFPLU9UNVotWV
  lOTS00TzZCLTVMT0QtNlpDTy1ZSEpTIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyNC0xMC0wNFQxMzoxMzoxM1oifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJBY2NvdW50QWRkcm
  VzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiQXV0aGVudGljYXRlZERhdGE
  iOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1CUU4tVFJGRC0yMkhILTdWSk8t
  M0I2Ui1BUEpDLUhVQ1AiLAogICAgICAgICJDb250ZW50TWV0YURhdGEiOiAiZXdvZ
  0lDSlZibWx4ZFdWSlpDSTZJQ0pOUWxGT0xWUlNSa1F0TWpKSVNDMAogIDNWa3BQTF
  ROQ05sSXRRVkJLUXkxSVZVTlFJaXdLSUNBaVRXVnpjMkZuWlZSNWNHVWlPaUFpVUh
  KdlptbHNaCiAgVVJsZG1salpTSXNDaUFnSW1OMGVTSTZJQ0poY0hCc2FXTmhkR2x2
  Ymk5dGJXMHZiMkpxWldOMElpd0tJQ0EKICBpUTNKbFlYUmxaQ0k2SUNJeU1ESTBMV
  EV3TFRBMFZERXpPakV6T2pFeldpSjkiLAogICAgICAgICJkaWciOiAiUzUxMiJ9LA
  ogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWtWdVk
  zSjVjSFJwYjI0aU9pQgogIDdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVSTFTQzFEVGxO
  VExVZENUalV0VWxwTlNpMVdNekpETFVwSk5WSXRUCiAgVFUwU0NJc0NpQWdJQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0oKIC
  BzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE
  0SWl3S0lDQWdJQ0FnSQogIENBZ0lDSlFkV0pzYVdNaU9pQWlXWFpxUVdnNFl6aEhR
  VmhwVWxaSVFqZE9iRVJxV0daSFRscFNNRTgxV1ZwCiAgb2VWZGZkMnhPUVVObE4wR
  lFhamhzUlU5NGRBb2dJRFJYZWsxVVVVSjNhSGd3UlRCQmEwYzRaRFV0VG5WTFEKIC
  BTSjlmWDBzQ2lBZ0lDQWlVMmxuYm1GMGRYSmxJam9nZXdvZ0lDQWdJQ0FpVldSbUl
  qb2dJazFCTTBJdFZsSQogIHpSQzB5VGtoSUxVcEhRMU10VVZnM1FpMU9SRk5FTFU5
  RlVGQWlMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLS
  UNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKIC
  BnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk
  2SUNKMU4yVllTMjFETQogIEZVNVl6TXpka1psUlVSNVRIWjJWRTVOVjBOcVYzaHhh
  ekZwVWxSNU1VeENRMlpXYlU5UE1uaEZSWEpXQ2lBCiAgZ1RXbGxPVWwwYmxSNWVIU
  XRUM1p4ZDFGdlIxZEtXalpCSW4xOWZTd0tJQ0FnSUNKQmRYUm9aVzUwYVdOaGQKIC
  BHbHZiaUk2SUhzS0lDQWdJQ0FnSWxWa1ppSTZJQ0pOUTBORExVeENNbGt0V1U5RU5
  pMU9TMWhETFVWWE1rMAogIHRTRlJHUXkxWU5USlZJaXdLSUNBZ0lDQWdJbEIxWW14
  cFkxQmhjbUZ0WlhSbGNuTWlPaUI3Q2lBZ0lDQWdJCiAgQ0FnSWxCMVlteHBZMHRsZ
  VVWRFJFZ2lPaUI3Q2lBZ0lDQWdJQ0FnSUNBaVkzSjJJam9nSWxnME5EZ2lMQW8KIC
  BnSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKUFJYaDJOVWgyZWtSeGIyOWtPSGh
  KYTNSd1ltVmthR3RNTwogIEcxcU5tZ3RZemxoVDA4dFRISmhNamg0ZEhZMFNsZGpT
  a2x3Q2lBZ1VVMHpabkY0TFdKQlVUbHVSbEpUTW01CiAgaE1IcENPVmRCSW4xOWZTd
  0tJQ0FnSUNKU2IyOTBWV1JtY3lJNklGc2lXVWcwY2paVmNYRllSbEpmZEV0RFUKIC
  BXeGpSbkp0UzBSYVRWYzFVMGxKWVZZeFlXUTVNbmRQWkdFelZuZGlXWGMyT1RVS0l
  DQTFNamRxTjFWclNuVgogIEZjVFl3VDNKRVIzcGxabGRrVlhKVmNXOXFXVXREYTJK
  ME9VbEpJbDE5ZlEiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZXMiOiBbewogI
  CAgICAgICAgICAiYWxnIjogIkVENDQ4IiwKICAgICAgICAgICAgImtpZCI6ICJNQj
  dDLVgyS0stVkpPRi1JNzVVLVVDSUotTFFMTC1UQ1FOIiwKICAgICAgICAgICAgIlN
  pZ25hdHVyZUtleSI6IHsKICAgICAgICAgICAgICAiUHVibGljS2V5RUNESCI6IHsK
  ICAgICAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgICAgICAgI
  lB1YmxpYyI6ICJweHlKQlJWT1dmZnRkd1ZHQXRwLUJEYlk3dzZGT0QwMDZ5SnhJU2
  9VdmRSUDVJRnVpanprCiAgeHhOVjRFaEZDWmt1cFFNYm1MbTUzd01BIn19LAogICA
  gICAgICAgICAic2lnbmF0dXJlIjogInQ0a0hHOUVqNUZZdHlxNHZibGpfN2RoNW9V
  Z0dmNTEwUXl2T3lOMVpCSGhmX1lrTEEKICBfaDFUSzM1bHBkRkVFY1BjTmotWFpza
  DEtOEF4QmJ1Zy1ZOHB5Q0JBX0k1dlozZExpV3NBMlV5TzVsOWZGVgogIGdlaEUyS2
  gxc0g4M1Z1eFRrT0FLODF4bnkxdDVnRXNkcG9BZmE1d1VBIn1dLAogICAgICAgICJ
  QYXlsb2FkRGlnZXN0IjogIm9UUTh0NjBpVjFiVkpnODdWN3V3bUlFMU81LUpMLWNz
  eEpuN1NfMjdxQUpLRwogIGFUUEdmSGxwZjNBSFhBSHFJZ2duVjZWcE4zSEIxdGdue
  VpvSUVmemhRIn1dLAogICAgIkNsaWVudE5vbmNlIjogIlZYbjZBb01PQXRpd3o2WT
  NKc3pqa2ciLAogICAgIlBpbklkIjogIkFDUTItMlJCNy00UFUzLUVTU0ktQVlYQy1
  WNU5DLUJUM0MiLAogICAgIlBpbldpdG5lc3MiOiAicHhCNXh6cVNhSndmUG9YdnZa
  cThwYkFzTjBDVmNRaGZhTG03enJXT2hKRlpjX1JSCiAgVzhSQk1mQnh6SVcyeGhaR
  UVPSUNSdkI4RW81SjdJWFVQZVViVHciLAogICAgIk1lc3NhZ2VJZCI6ICJORFFPLU
  9UNVotWVlOTS00TzZCLTVMT0QtNlpDTy1ZSEpTIn19"
      ],
    "ServerNonce":"DpRx5T2-TDF5189FIKvegA",
    "Witness":"TWJD-AUPC-2BSP-3V4U-ZS2Z-S63O-2KNH",
    "MessageId":"TWJD-AUPC-2BSP-3V4U-ZS2Z-S63O-2KNH"}}
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
<rsp>MessageID: TWJD-AUPC-2BSP-3V4U-ZS2Z-S63O-2KNH
        Connection Request::
        MessageID: TWJD-AUPC-2BSP-3V4U-ZS2Z-S63O-2KNH
        To:  From: 
        Device:  MBQN-TRFD-22HH-7VJO-3B6R-APJC-HUCP
        Witness: TWJD-AUPC-2BSP-3V4U-ZS2Z-S63O-2KNH
MessageID: NAPX-XU4B-T4ET-JQOC-TTUN-EXCZ-2BSR
MessageID: NDPC-BWU4-ULAU-DUSZ-PDP5-7QOH-H53L
        Confirmation Request::
        MessageID: NDPC-BWU4-ULAU-DUSZ-PDP5-7QOH-H53L
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NANH-ZJY3-4XRC-G3WA-WMFB-DFU6-HW3X
MessageID: NA5L-OBCK-V3V3-VRBZ-4ISE-GB3B-VR64
MessageID: NADD-B6K4-SDGI-BSJX-SKLV-R2X5-IPYH
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
      "DeviceUdf":"MBQN-TRFD-22HH-7VJO-3B6R-APJC-HUCP",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFLLTU0VkMt
  SDNIUi1UWUJILVpJRTYtVlZJWS1aTlBBIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyNC0xMC0wNFQxMzoxMzowMVoifQ",
          "dig":"S512"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJDb21tb25TaWduYXR1cmUi
  OiB7CiAgICAgICJVZGYiOiAiTUJBRS1FWEhDLURPRVgtRU1GNC1WWE9ULUczMlQtW
  ktYVSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaW
  NLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICA
  iUHVibGljIjogInBiNzh5S2JDdU5sMks0V0Q4UkRsOUd4TXR1TGR4eGp1ckFtYU1u
  dkp6RkFnVWZJM0paajYKICA4UTczTTZLNkVoaTZtTE9QR0x1c1JMQUEifX19LAogI
  CAgIkFjY291bnRBZGRyZXNzIjogImFsaWNlQGV4YW1wbGUuY29tIiwKICAgICJTZX
  J2aWNlVWRmIjogIk1CUUItTjI1NC1WSlRMLUNIWUgtWUpUWS01SDYyLVJIWUciLAo
  gICAgIkVzY3Jvd0VuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTURLNS1HUTZY
  LTZDRVEtN09MNi1ZRUdZLVNBUVctNzc0UCIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydi
  I6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAieVVfa3JMZTduYzRLd1FTTlR
  Ba0tZcjRNTEVIZml1bmdfa25objd1akl3VnRabGcxZGFaegogIE9laE50WjE0UUo4
  T3dkOGphaTFNcjVXQSJ9fX0sCiAgICAiQWRtaW5pc3RyYXRvclNpZ25hdHVyZSI6I
  HsKICAgICAgIlVkZiI6ICJNRDVNLUE0WUotQU1QVi1ZVE9TLTNHVlYtNjJSUS1IVz
  RWIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0t
  leUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAiUGl6RF9fQ25zOExTb2liR3JONkxuTnJLZzdic2h0UjRwbzlfZXZQY
  0dxOW1wXzFERGY4MQogIDAxbUI3YkpDckV4QzFpejYwVjF2eDBtQSJ9fX0sCiAgIC
  AiQ29tbW9uRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQU5TLVlaVlUtVkE
  2Vi1DQ0s2LVBDUVItRTJRRC01RjZQIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  lg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJxek9lTjhHWng2MUl2VzBSRFlwNG
  9lTVV0dzN2ekdzeEpYZ01hbkFmT0x0b0J4VXJnQjJRCiAgOUdKb1h5OS1UdjJvRXF
  tUGFnaTBfVzBBIn19fSwKICAgICJDb21tb25BdXRoZW50aWNhdGlvbiI6IHsKICAg
  ICAgIlVkZiI6ICJNRFJVLUtTS0YtVU5QMi1CS1hFLVhGRFMtQjZBSi1GQkRBIiwKI
  CAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDRE
  giOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI
  6ICItVXlUcDZUclM0dm5yS0g0aXhlWGt5cnI5cExDVGhtSW9kRFJzNVVIdTRUUmpF
  VmZ5Sm1GCiAgdFVicjhkTGRXczhmMl92dDZ2RkxKYU9BIn19fSwKICAgICJSb290V
  WRmcyI6IFsiWU01Zm1hNEMwejBpbjFjRDA5dXZPdzE4ZHhBTS1Id2RKZHFNUjRWSj
  JRR3RGa2lUT0wKICBQVXE0X25SUzFralVySHJiWGhlOXRqVlFXMTdUd1p4d0pnRUQ
  0Il19fQ",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MDHF-7GNO-ALJT-2IU7-K4B5-HW5P-HMGX",
              "SignatureKey":{
                "PublicKeyECDH":{
                  "crv":"Ed448",
                  "Public":"pb4g90a4fR-e2LD1JpqzMFD_x_oJiBiSDD7kC
  GW854aaEHT-zC79pYbTIwwRQoXsl-qI_9a0nqwA"}},
              "signature":"skQglr5whaPaQuW0vR7-i-m8uxXswiXGieH4ES
  KSdFz76RHrfRonO0kNC7VI-j9iwBH7WoU262GAH2YSn5rieP_utbmBv3Lmh3gU80B
  9sZwqrcdg1sIFggZGBlc6MZIsFw5GZ0Et8B3NIDvfH9hEDCAA"}
            ],
          "PayloadDigest":"Me1DFKrb_FI2r2P0bqzkdKIjt5Ges8lwtf586w
  ZB1_c8R4y_CRkMAMMMS0_H14mINJaBBH_XRaEn_TqVIR6Tig"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MBQN-TRFD-22HH-7VJO-3B6R-APJC-HUCP",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFOLVRSRkQt
  MjJISC03VkpPLTNCNlItQVBKQy1IVUNQIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDI0LTEwLTA0VDEzOjEzOjEzWiJ9",
          "dig":"S512"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIkVuY3J5cHRpb24iOiB7
  CiAgICAgICJVZGYiOiAiTUI1SC1DTlNTLUdCTjUtUlpNSi1WMzJDLUpJNVItTTU0S
  CIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZX
  lFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJ
  saWMiOiAiWXZqQWg4YzhHQVhpUlZIQjdObERqWGZHTlpSME81WVpoeVdfd2xOQUNl
  N0FQajhsRU94dAogIDRXek1UUUJ3aHgwRTBBa0c4ZDUtTnVLQSJ9fX0sCiAgICAiU
  2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1BM0ItVlIzRC0yTkhILUpHQ1MtUV
  g3Qi1ORFNELU9FUFAiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAog
  ICAgICAgICAgIlB1YmxpYyI6ICJ1N2VYS21DMFU5YzMzdkZlRUR5THZ2VE5NV0NqV
  3hxazFpUlR5MUxCQ2ZWbU9PMnhFRXJWCiAgTWllOUl0blR5eHQtT3Zxd1FvR1dKWj
  ZBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ0N
  DLUxCMlktWU9ENi1OS1hDLUVXMk0tSFRGQy1YNTJVIiwKICAgICAgIlB1YmxpY1Bh
  cmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgI
  CAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJPRXh2NUh2ekRxb2
  9kOHhJa3RwYmVkaGtMOG1qNmgtYzlhT08tTHJhMjh4dHY0SldjSklwCiAgUU0zZnF
  4LWJBUTluRlJTMm5hMHpCOVdBIn19fSwKICAgICJSb290VWRmcyI6IFsiWUg0cjZV
  cXFYRlJfdEtDUWxjRnJtS0RaTVc1U0lJYVYxYWQ5MndPZGEzVndiWXc2OTUKICA1M
  jdqN1VrSnVFcTYwT3JER3plZldkVXJVcW9qWUtDa2J0OUlJIl19fQ",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MB7C-X2KK-VJOF-I75U-UCIJ-LQLL-TCQN",
              "SignatureKey":{
                "PublicKeyECDH":{
                  "crv":"Ed448",
                  "Public":"pxyJBRVOWfftdwVGAtp-BDbY7w6FOD006yJxI
  SoUvdRP5IFuijzkxxNV4EhFCZkupQMbmLm53wMA"}},
              "signature":"t4kHG9Ej5FYtyq4vblj_7dh5oUgGf510QyvOyN
  1ZBHhf_YkLA_h1TK35lpdFEEcPcNj-XZsh1-8AxBbug-Y8pyCBA_I5vZ3dLiWsA2U
  yO5l9fFVgehE2Kh1sH83VuxTkOAK81xny1t5gEsdpoAfa5wUA"}
            ],
          "PayloadDigest":"oTQ8t60iV1bVJg87V7uwmIE1O5-JL-csxJn7S_
  27qAJKGaTPGfHlpf3AHXAHqIggnV6VpN3HB1tgnyZoIEfzhQ"}
        ],
      "EnvelopedConnectionService":[{
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDI0LTEwLTA0VDEzOjEzOjEzWiJ9",
          "dig":"S512"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tApQcm9maWxlVWRmgCJNQlFLLTU0
  VkMtSDNIUi1UWUJILVpJRTYtVlZJWS1aTlBBtA5BdXRoZW50aWNhdGlvbnu0A1VkZ
  oAiTUJMUS1UWjJXLUdTSlctSUFLUS0zQkxBLVhWV1ctRkxUSbQQUHVibGljUGFyYW
  1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1YmxpY4g5-MQjBeJ
  SWMJ96BPaqpGEzcJ86EaYuEndaOaMgQ3vYnbLIKWV9Izin2k_VfzCbW8h1hByIqrG
  ZtmAfX19fX0",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MD5M-A4YJ-AMPV-YTOS-3GVV-62RQ-HW4V",
              "signature":"seMNFSm3w9DCxPwV0D62QM7oOCu8bCiqDPWVJO
  kvxFuFTzdZYiz-d3B4bkzudqr63kXnGBmIyqcA2raG2zXM_TKPSPFxpqz7CrrZyhg
  WXJjGgDPKzNZ_X_-f489HUkDJ1I9WbaePvjhESj3Jp3Q3pB0A"}
            ],
          "PayloadDigest":"-9g3XCo1JdwyKqLKl2aEDMqQPI1C3YChpig7wt
  irA8VkXDOoAkIf34ikM74CfGV8fIjo7ZQ825FdREuW6N2sdg"}
        ],
      "EnvelopedConnectionDevice":[{
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjQtMTAtMDRUMTM6MTM6MTNaIn0",
          "dig":"S512"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0BVJvbGVzW4AJdGhyZXNob2xkXbQJ
  U2lnbmF0dXJle7QDVWRmgCJNQkFHLUJLN1otT0hBNS1NU0lJLUpNTkUtN05IMy01N
  EhCtBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0ND
  i0BlB1YmxpY4g5LXfyjErwV7ljTNTII14TVJ6tbBIiq4SQGIcpU_MrSGm8cGGjPZw
  fiFDysUZ8a1XVBRxngf8AkTeAfX19tApFbmNyeXB0aW9ue7QDVWRmgCJNQUVELUVL
  TkUtWFlTSy1ITVJWLUM1WkgtMkRBSy1LTlNStBBQdWJsaWNQYXJhbWV0ZXJze7QNU
  HVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibGljiDmr2bN3vyTKzfEi4P-xy9
  p3P-jfAFw2vcFUstN72D1g1HTaFBODndSEuhogKy3hHSi988jmsC-uF4B9fX20ClB
  yb2ZpbGVVZGaAIk1CUUstNTRWQy1IM0hSLVRZQkgtWklFNi1WVklZLVpOUEG0DkF1
  dGhlbnRpY2F0aW9ue7QDVWRmgCJNQkxRLVRaMlctR1NKVy1JQUtRLTNCTEEtWFZXV
  y1GTFRJtBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWD
  Q0OLQGUHVibGljiDn4xCMF4lJYwn3oE9qqkYTNwnzoRpi4Sd1o5oyBDe9idssgpZX
  0jOKfaT9V_MJtbyHWEHIiqsZm2YB9fX19fQ",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MD5M-A4YJ-AMPV-YTOS-3GVV-62RQ-HW4V",
              "signature":"VMi9icE4x-KgrJsItCjqrao7Z1-aLKOV2A4pyQ
  gwmSWHCMvyDDeZcXVwJI3K1t2q_GnDDnEeKhCA_I7oPavSALZCzJNV76uMlsmfhC6
  KYfAelOSsINyR0COH6m7IUuuQHzlUMnMHFW7DznwJtKWi0yUA"}
            ],
          "PayloadDigest":"TR4AgXuoFLa4QCg_y4QwUheDM_Ekr7vwAMDvPb
  ar22TV7Lkn_m7rHn8sC6LyTApPBZGoaQ-ZFpNATjaW2sHAAA"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "kid":"EBQA-C2QI-EADU-6F7A-CWHA-J7DU-4ZXJ",
          "Salt":"8nXcTJk0KIsf0qiDvZj8eA",
          "recipients":[{
              "kid":"MB5H-CNSS-GBN5-RZMJ-V32C-JI5R-M54H",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"VUsSkJ8fQh3ueACnnXfH45h8QBCww90dD1KvI
  VVibqu2jZe-HHj-MTPIsOwYvwpaMJ7OIhAe0aMA"}},
              "wmk":"UP7Vhz-_p4jYhAOC_PyegVj9YGm0HIx1wTCjq9PxczeE
  yTmjPunPYg"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDI0LTEwLTA0VDEzOjEzOjEzWiJ9",
          "dig":"S512"},
        "6glUZHFAuZ-xucsh15e6ykFivz_yNtU5CFXADKiyLlxUYbodtR8qUtGK
  9MRflRk5_hfHJX6yKRy3Pr4WPIzwe6G51SSUmhhciEIcdtZi2FMmAu0NDYJFO6g3I
  S_foRgDGSQrDMjvF521Ox4sDTtQjrl3VEVsKWF8AXTISpZnHE4RcNZ0EFnnRpY76q
  w4YSoLg5vBo4hFl8_WlyksP4WOhQT9Hm_1CRcZjBMkoOeF96hzzkPaz0xu8uAKZPC
  -wae3",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MD5M-A4YJ-AMPV-YTOS-3GVV-62RQ-HW4V",
              "signature":"KHpOC_5iISPoDbmzjKc5HgTkhF5OMHFGLFZ0_u
  _gDq83y1djTya88fKxjf4NcjcyJ9wNdEftSSaAG7JSDJ7gQTuMuKD0biBl998Wc6i
  LDH5h5QpLyGSK2scSZ4Rar9bkk1nPLDCWq7r4Edr8cXFTTCkA"}
            ],
          "WitnessValue":"FW6WPXynJ_2fYiWZN3r1zaqA5Izk3ImYRokXzZf
  GgYw",
          "PayloadDigest":"xcEGpMeXCdqojFwdEMPMisptJd90LeuSPYGexM
  OTt9JpQIf-73wrP8tlFuB1dqN_Tbb78w73Sh2Q0AsziJAjHw"}
        ],
      "EnvelopedActivationCommon":[{
          "enc":"A256CBC",
          "kid":"EBQN-BBHY-MEOE-GIPY-LEKA-MYGW-BSPJ",
          "Salt":"juoAI11bqlxi9lMw3lfdGA",
          "recipients":[{
              "kid":"MAED-EKNE-XYSK-HMRV-C5ZH-2DAK-KNSR",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"nErB9nTgh6cVY1b-ioA6xk0f5OU8pOk57pcam
  DNF9qsmYpqBMYCLVPTmPdsSFGvFVmp14JpoerYA"}},
              "wmk":"95CqjMtpSOarCTNgNyJ-8-EMVN6VLQzjVGk0VS_ncVKV
  y5c7Cq7vhw"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQ29tbW9uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjQtMTAtMDRUMTM6MTM6MTNaIn0",
          "dig":"S512"},
        "VnSJP1tIaThOwTJ1o9b0Nyn3oedlE1D2jFOIwNg9-YbEEke2m_3WBxzU
  SJIWIqdBb3ZjPsS9kZG1FRFW8ZPK--nKTn2aY6lblA9pTReV2ABiRjKf1HMqLeh3Y
  ef0w8rKUu5-l6SJGfKT1Fp2V0fqN_IbyEadsHgdo0EFN9cmkWlT3ajLBuOXO4l-jp
  wmD9nymDf-IuUfR4QpOeOERerMQfynsxgjzQc0ots4MZvnJWjZUpPt0pwVANDLLbD
  ZZw_tYlt8wzix_jAvFaNzw1tTFKvFnpiZaZzArXOc9xGBdC5FkU7MDCEj0oWxKNZL
  KAhMfizlwqljhsMIWxVdVSYvCd4b7gHShsxeIZt9zlmMTjsQalUz9GJ68MCxypPoN
  m97jSeocC6zzcW8Q3EBbSTL4_xc1_x5R_FzRllPO4c7kXiyJNrlU0eJnqyf0vhbea
  SBCZg2CTHUqqgADrsoysEvC6l8KOXbR97_LAflsVah5TAvgI5BpsEz8HeltJ-u6-h
  1AUHTEoHZqDwFxpvGt2zv02JmXDvIuh_EypFWf0IVFWNrWtWWttKBUIRBMaL8GlQB
  0DjgR6AjyBX63ieWOktsskWJCUslf1r6gQZhQ2dVMLpQ1sWClbRgYYB4TX_PJoyIk
  3da6_vZaH98-aa-VAfyMaSLZaUyF4xX2rfs_iBolBi8Xe5Tt6YLZs1qibrqSOmEKF
  -1IqJ69-Nslz1iPX3oztiCKv_P6Ka72x5EDyynPq3pe7-JBKLUkCJCUanp8ydjbHq
  9J-fD_SkM7RAQsQluJlUeMmnxoOAi-pE2W7bVfuFZUwi07f7Ojjiunlg7ClWOMei6
  cIk5NHtBXfiVqtQUQdbgGcBcYsfd0ZAtcrm-k5-8c7sJsys1ylFdu0Pynnmaw8lrN
  KF8AueenUJTAkcuPJK-gqr49ZSZDEV5ExSRpcwUnEVJyt32E9O6150T7XPK0zuS88
  o31O0yPtKuMc3lEeSTV9vLnzrsdJNQ3WWrW-1LOSeEhh_PqlwYESafelPDvL3bZ-h
  7rFn_rSfuEfmmnBPgn9oOsXGYzSuzMXjfi1OcxC_af5d6BPw8a9GJZkEGjpapzvON
  6B6kfI8cEP6k-l4gpyAZ38LJ9XxaRnhBs8Gj446wpxRgeQh0ralSXvF6-ikdmDeZs
  Ly6iTIs55ogYLKMC03lUNACvcKpeVzQWhmR_FG0dRS_33Nq5of9Me4DTp85X1v699
  iynlF2NiBo0BrHfd_2brh8Ykm2DzvD2qVB0aC0LyFpoBMfmdRkPWP402twlVFoEnM
  n4yZFGuol7sCspGGH1WqJ2UddWgiR6947CIuyBSfh2M3-H9gGtYnjp-hOmMovZowZ
  hAsZ3sk_9sXlH7n_vA_T8p9vuqPwaca2YeE_wxzTuBPv44OJT3enK1VucnA8K17Ht
  vZ2g0pJS6eI3aNmrZ0pOA6gXtalnUs5glJA4jelBEdFwTomCIHRA8x4I1CxhyncVT
  tUGxxjocVnTz04NdMefR_y2brRJ90YYIRZv99EMrS8Axfp2rYTy1d_9oayPoLmfa8
  Q2fDSIGNCzgeeur4sytsEggqXCmEGyOU652y6dj1tbgxlD0AxnZ1xKU4mFp1h6x8N
  JJfMV-UDhbpyThVcxj1l7tOB_uNfrRVDlVSMFnzKBSufiYmt4qstl1FDBsPIMUakn
  C4Ftx_NsqiEdirOD809W1C3N3mXcf0TAxaiTn2HnNuSuS8Fzdd7yk3HHQj7TAQVyn
  gt7AONh7MDAHBU0HEDqQisx_ZpEq0yP0lc5DRKx7N5R-JTUGLiFn-2KtDsdhe7KmE
  sbWAz3WcITHM34miy0XOEnhQ84BZ-rEM1yLiVxVvnl_i9vcJAyl3wPFM1mRx2gb7v
  OA7tR7KBsWDMeOJJ-8-NRV_l-GpXE_ebp-mD05lm8Tw1VShHYC_JUlqFqHCxqB5kO
  E6EBnVHO1P5azpr8XU394oWH_34W1e5am-5nn5fkCRnhhXxcCOT11F2M4QE5jG0L6
  -cliUuimMziEZGlqknmgxktcgQsb9MMhTYHi3vWoc08XYWPSTgC4w0l4hEWDJvjBr
  cad5_2CLuMzoQC40kq0efhoYk-c80R5azd9rUTMW2DAVoZQ0N6vNkHxCraVACuF0E
  Aa7zFwWJ-ZJBr9H3Z54B5fzdzdXHT0w60MIV7tkTnjXxIAf263GLGUMSJwEtM3wR7
  Lxy6NcRDduZyxsCW0-lcNltdmpucL4mIuYHSptwrOWAwuLv4gsxIL_N8MuP33rGUr
  MizpnzgHJHTeoqWAW9nMJLHuolQU3IToMlkXylMe5Sbao7KZhBO17YlTlprad-dx4
  Ktjr_WCVd_1DKvt_WW8oCgm6J5YOsLpAq1_87W4-3ZrQIbmZCO5FQbeT0Cep-SoAU
  Cug4ctEPobNStP1GaiBb7YTZfu51p21YbmiH8UlqAKbiOWGihXGiJ1C9FnXavcwqE
  nHPN_yg5JQVAsm8pyTgGnREOnTthkYJjjORKt0_MbMr7WzGdTUe1FgOEbDF5WCVkE
  MFonEDqIZiEAp7tq2h87T5GBuXqMOzAvlPYZ_lI_DHQFrYNnOLK4Qq307b5O2LSxY
  OxJ-7ytoibUng8k3f0qTuRP79Q4Ka-IPX_Nzw8-HNA067tnlmV6wmKWXNMvYIKp-p
  mUvMO4i0FYj8OhMzKIPh1bOSrHS-2ve661Z9yzZY5XRd_s6NCrPO53PlSs6EOUwyZ
  wo_4Kl2p2905kmqKM52FSABPrWrnEXck5ntOuL9E18HHga5CSwGdDikAOE4ZkJKzb
  1d_nkjF7Dhrqa21sAr9C3y0hZHo0blvDvCJ77T-7vaUzEzrio8KPDjqx0Q0NfcfKE
  4z3sKr_52fOWGpJZ112Up-jlDEF1e8kGCIpEeq1b6SYbn_3wsAxJd4wwGeGBK-uiW
  pQpzlKR1MHQU8hVbBgjkFB4TjPZuR13LzK2TrKwGiH3cL_NtKJzh6KqjCe7X_E6SB
  vKojqJvg_qkKCqud5i2gEF6443wZDdkcRehEY9jjxzFBnsDoGwY_3PSpXvhfMRYFR
  R7RblV8gibPX2vBrs6f2YZjQmn6teTJOZCQv_gWP9r2v6aSbqX2tk-rYgonlWBw_-
  wnDewB71dvXh4dvJZHYcdZi2W3p_huGeHa9NFE-D-xGj8dEXe6HsoD6cC4IhY4wHQ
  w7tsA3MB2tvFOQuoMNN559Kv--JrpLfSfxv6kljnfxBaHrj9tjn3ZLvxM1Tis_Y7_
  zYZGfnXVXIN_J2L4m6qfRfk_UQJy0B5uPMM2fWxrn5m-4lCSzodsy98l1BYEKpAri
  GzYqjc1aM1GuZtD3UVTQsi5qblamEymg2fln2wb0HbLmBw5lpnl2VoHq1mewOfld4
  xLFzDb0hgMKEI5NshbdO3lSk-rzwfzA3UYzwH6wLNEYLQRQRN32Bom5aSv9sn4kQT
  BTzu2E-KoJgCfAQ6Qml7dDlvAAt7bG1FKcXd_I_nSImvl3QV_BZ6FC7Kq2YLW46qe
  p7je61nhp9hbWkZHDwzFRiFMF2HUemE199qiIgO6rHHjJxTz8_g3WnwN7X1YAtTCY
  hLnCPomU68BPOdgE6ynJeOPFIA5OPhvGKElWrCWLt77FBoVR7SBZx9rjLiCQ85Tp8
  muoQzsO2moR6a1v-yutt-DKuYCIIWSNsl28nfQN-6dXRB4MA6JcEB_sSKeZyBX9MQ
  6isrvQ7LeSY44wtGFBfi7ONki7l23d6_b8JXlPn0Qb4iJZBftrkuxxVSXrdg9haMH
  4cBpfFIBYXElFnyJUhpYkjWklzJAZlshlhe2Mr6sK_D1W0yUE2ql8lEQwzDgXLX4K
  XCbJTcrEuBbiemiiDC8OrqQmbW7RXAO7TBVnyab8zQ3Aj64qX2WoHDJyaSPM01vF9
  OD1Lgl7d2Xwp4BmMZcNzQ9ilIQO0yzBsEDHaX-kTSd1Ok0gueiSWtJ04AE6Ba6XRG
  ylpnP0HmnV6eyZwbsAsL8btl1FbHnr3w4_0GPKcGzA0RIrg2TsOyByLpVwhV3kOfP
  PBxCBUMe_rQtnVFTkW22NrYe5mkotDaPpsA8daAOMzYH8BNKrmaXalhEOzVwvLqce
  LpLrEKsSPHKSnwnjIF3KSc3HD4b93O1Dmfq42JvIjgcMQa-DDcyczRGycBJ4Mfptq
  LbVZI2DrrkAJYw8RicAXFlWKbTWc2fMgPXARyFZHfN3JoLdFvpT4_y77o7uM9bDmz
  IEvuK9Q-QZVTA35GdXMpbwN8AfWjm_VJd_K-JN26PqZVN2PeRXtHzz0jJ2sZVePZI
  NXEVOqwv0gi9yThdcWWEPcJ-R7YYd3Ykla6XpwIz3h6gwrogTBg8Qzj85wTTHfYRy
  SP9kOB3uvJSKLR_D8Di205Z2thBU9kN3u3Z4fopMoq1iFOpeIinVhG_iSo9sdJgPP
  EwX3fErz_jruty84Bfc_7rs_1c3NqeaarRVjZtdr4PGBD1Nh4DUKjaFmZ3gx7nvXd
  SzgwCvJrDOBLLKQM7-DBfdTpuEhrShG_S53uL2CHE22d_c3zzeQmYxcXL-XG7GmXA
  xn9Fz9U8zU7AVw2xPqlXdt14FtyZs6ICqnogJ-V98eFt3bANl_3Xd6X3e3tOtf-vi
  QnNiEPEvt9oByEFPoTuBuh0wKcL6ZtffiAFw6136fvmNrYHv3oUMRQLsl6IbzEuzL
  bw9zKaxsZHopDHv06iFl91lCwkPypZ84KyCIPaumlY_8n7D2j_VvE_VN8u2J6bZyL
  ekc4WA_K5lyuUNXfTXsLsm8xg5bBQODlw9KqkFe0Mu2mn4jn80DdErmvLfTSyLlkj
  3-7ddLxkbahwkw1uHa006JzjlnyaQiY2vO3ZdU2E3ABvw7Mbq2mKXJfqiZiJ4hxy2
  Yc6gXo0CiY56XyzgO65-z-bGuh3xd6DMHGl3Jed8NjWHkj6zo0focChwGSTB9pxqy
  UOJFvUDoW4yoKCin8rul08bd4Xdgjv8SSKPMJhPWza6WO7uTXeNjwHYXRw57wj1Eq
  o6ma_EcVY63mOBdVfSaL-t5mij70qgIHrRNPYON7zYkaD8LXRMiSp4Bp9vbkFkuJj
  JIv5FqsBh3spf7Yu3k-m7s5ngLI06b53p741UsqE59jCCPZO72Jy5f3IquBYbf_he
  2QsRtSk-OnaWDLrISfWrB40mIznFE4UjnEt_-C6vWEQlD6U_VxkbtpK6EJG19uPyC
  5YTZU04x_V7tneWw53J_9u22HxPp9zyz56efXDQI1wD71TvYBKHufm6B_eXyZun8J
  kd1EU4vW8QwUavjlcUhxaiQVZuYd3ySV2RZRe7SfLp8d4ntHbalvmivqDahLIiTac
  B5Ons1LEwTTedd9zFnwRXgxtf_P3hdaFYQxzF9GWhbehbTM3eG4cTXJLPkNBxdCYW
  jXLkvp6wOmkyzQAkD1faWjcPstfB_a9o3Sw2A-29QrF5D6U9JcDU5SETVDL9p7ESr
  EBHeSuMqvKCZ13NdCWm3w8sC1WH4y1HGCWmv1ie6eWdmcXKXcG7zl8zR1M-_JrQfC
  4lSux79dcJLq5_CrDRnDqSsHB1__MDEQs0EBhx6fo0HEWota31DJfrFduz2awrPlV
  1bS3PNz-dQTWe6e1gWf41vI7E10IhSRR32Kle1cs5lAAEdUY1PfQVrp1Mo0RZRf53
  0_KD83CCuzx_xKD5-qjbia-FX-4FO6-1wn9qK5m4tmDTj1Iq0zfTPMpOa7oLCDm_H
  xoHzcbb-IzGbqd7fXw9xMFgw6R4Je_Px-L486PdUrQRL1MBqX3-_gJgai_Oso6Hn2
  07OK86mSYC8i5AnUhYVOXEpDdk8v0Rjn-20qNPW67J6HQTXWHQCyrobhJzZPMR9sn
  RMbkf-_HPoHj4HHdVK9SgxJUt4RNFCTS4ogD5LECJUBCJk_spdLpXAJBCIvde3Ln2
  h0cq54ILiHt34d8ezSayaCyYueTrx-rRZvFqRdfj2SGRCfyXmlbz0LmaO2mUQoAGD
  VTpdHn93hKIvjT-NfM1WJTy0GlBWidjeAm5MUjSiZuTzbwDysc9SVWxhJr2Ox46Ja
  gq6Eu31fIGGQOqm2zK5QzXCJoM4Y2vdiW1Hcg6yCA0snQ2J4a6WD85eIINlHGXQ7M
  bI-RbwtBEoIy4c5S43JB6E6zQfAll37QNSnC3qpMIA9kCmWq3P-CP9RTBfX6HYYo5
  r3ivlnbgBVdJus-46zNEBmukwrWah94Ko1ailKAiwNfEB_A3lJYKXuJ3PnIX9l59t
  CXfnbshAuM2uBDCmvJStxpL1aYmZxL3N7wxcA0DOo3jaEYa3JknuU-B6pFlZdlf13
  ioo_iB6r9v50QX6dHfIeMovhI33MKnaBe3QREWI2yV8-7DvSoZHthHcC3NzlfZ5Fk
  JY1QMs1eQNjV00cG9Zm0SvMqPkErh2im8xC63LoUzeTKn4Ey2PDy5yggdgYBU-GZ4
  wgvTg20TaG3X8vCEt4Wfn46ha7tnc-GLmT1IiGyFsqr_LMdQ0lQCJGyh3bpzGd5NY
  gWmbv-PbsHyY5UfQgYMd7vO39oMpDURrjNFYfm3WQtfGwUT244MZ3-1hhPeiPeAnu
  ILIw8yreS2y-RFCONkxk7ORV_bcrEuti_HI3YEc18YE7bKcGjo6BJq1c-zSVs6O6C
  75n_S8A5Xzco77aU3VhAFYyJn2w9Rfn1dhja33g-BtUCmb15Vqc_EuH6f4zQE6ntZ
  Ynts8ENnF8WuU-6OZBRMzyjYb7u9eU3cF0gD8jDWbqNvp0w5iEBO7Xc0cke-mR4Ps
  BsREvozwOa9Z2UM3-pLfGFfnh-az0vtwA-cz8D-JWnXm8TTj_kNs3dsRZopzuqbWm
  -XpZuPz5ZkOKvS0tve__DvxNSr6rdEv7hYf-2CIuo1zpeXZH7s6X1smz7yVDMZ0OJ
  q-9htsJ4QTxd7fk2DH7PlsSYbbeD-1JIZGop-VQtTWQw35V4ZmSvwk9OKnUGRRIYR
  4tdMR0_Fbw_CIeU_1AixL45PckYZfKZVslfp86JR65RPW_M-E04xpsMsJIKr81zFi
  6pj9xHP-jAqzT0iiGQo5AgMrP3gCIcwM1La67Z2wgELrRMzyHw5fSTArQ_zz8Zi_R
  g4zMLWuy68IOgxAefnsIFjRI8Of-EDEH5YUtpKxRmGNPZC6wz4VvZrTwlxDLAhcag
  6mwVKz1_KK6V4G5B15r40wEixtuM_IRGQMErhWq-3EjQglwGn9jLl_ZrMMsRlDRP-
  S4XjGquc_g5ztTOano0TWncuoE_vI64lu4c6up8itjp9BhZgw-_A1IU0rwSHDqKUd
  dUbQCdN0AgpfpDwsHzPKMAiAqohQN5YR6Ud6FhfeW5_ACq9TZ2YwvMXpBZsg9N74O
  ld110ZEj6g3pv0YkFLBF-wzfyCTStpfw030aj4q78uYYCWMj1XrHj-Xs0DgSJjnmG
  hii5oYhpPgFU5egG-Lhym4nHsJRFbMUsUNUhQGp1eE1wIiAkMV490PgGQIC2enXxW
  AlzRfAihxKJJ-A3zOljuXylBh0_i_EcPqmuCtaiexFaJmHMDv2Rl1D6nxpSVIx3m4
  _aLvGKLMGohouoeWoyy34HAb5eu5yEfNOinpn8nOtiJO7LY9bDY-GfxyEwQUqzoL_
  4B4F-QdI7efe-gJWeS2BvMVOds5Ixek3W1hH5cPf5R_-L589tK_SujfJpF8kLXPt_
  DKbJH9LGnzFIepwWj0X6XQxiMH1E3xddnFBG31meE6q2k-LwJHwBgQXqhPxL1kMJE
  UeSUY5TKqAnSnc2utkha_ESorL0iqGKJZ7DVJ_hZTRmWFSxR01d9yjRGz7_sL8a6b
  ibY-smlTKpTko5IK2PE1MjOPC8SapquQg5tZVqQglnZHmBun5AVTWmwkv6JRrER8C
  gxO7SBCpol9tJsgD653pvYG_zWdsIGLbkVabMoDpHhVM_Z0o1_EVokktpz_7euxaE
  i2BsYywLfKsQKx32kx-vyHdqQQllR6Bde8Yo0eJMMNpcwJKajhPjFrPCuVEbt6SaI
  mR97cPMd1uFu0Le1OQTepkM5bS3_TDxBNMFLQyEPt8GG0718dJMszuHbMqebTjqrG
  kM2sawl7dLKsLHhhzUEvSWNPfGamzHC3ICcIY0GLiytrk1Dr4XgdTXLIKyRq4PwAb
  FmsAwC0Uv5m6cdhAWR7WeELrqfbsVA5FJFiwW8CnidS-zWxPtS17LFAJWgJWR1Woq
  vxFcWYdvR61wd387VE1xeD_DgaAq27COVsU9GBsUAq01OATII_Gf7dWpPzo0KdgG6
  BWIOoBJ58PwHODTaxaIF_YO9xwIMSL54dCwAtK1YGj7TPicMa3mDrPEBtX71jzhVo
  QZTR2vReC368J9w65VpZe6w2sNvwpLPZ2n6VFPzYsJ5JtIPij9C-TIMzevc35mLpx
  3aSjkFSB0ZGdQb4uMfZc42MK5ffG6WVE3MKKCzm74UA5QRDmKeo9N-ywx-fG8zKK5
  i8owotQOOAl1MY8RgbyV3Vv4nDipZjrvaKxjWtLRPUuw9CpU4O3CnvAxHZ4ZLr9xl
  t1mAjDOcKTAKmi9eCvkIVFfxC6D8ThP4Dzf3Zgqq-il3g2oEOHqog-RtNJITaWtQA
  5WSA2E4lSZ0i3lqwbZ0zrhmlOcS1t37eEL1fYZ29YmbJZvsyHo1dx0geYM8JRfQQk
  Lro3-xGJqTRaWyXXuHheqQJ1BA",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MD5M-A4YJ-AMPV-YTOS-3GVV-62RQ-HW4V",
              "signature":"VBWi-vUH7aQ4DOBhx_EyOGTRWfRdsZ7EiRQuq-
  vZ_9eb_QYXcm4OtBCjAV9_BnXq6f6cFDNM2zEAMz3_COnSfi7x4rYXeArQXzI73DC
  VzRT8hjLUp-ELiHmjTPc3w6I5ZMZMez85ZiARkCYpjwYayAoA"}
            ],
          "WitnessValue":"AA7QLNj4c_QqgOr81vXAmdvD1ilA6NsCxj8NBud
  7oH0",
          "PayloadDigest":"GEI4QusKc4g0t8bRY5w4j6HHKfFjZopVMEfMMI
  9qfvxbutTUGxCKG25ovoIqkPutR4lVKas42hrXc1-vW5GkRw"}
        ],
      "ApplicationEntries":[{
          "ApplicationEntrySsh":{
            "EnvelopedActivation":[{
                "enc":"A256CBC",
                "kid":"EBQF-BLOL-4DNL-FCQN-TETK-FVKC-KDES",
                "Salt":"6Br0pQZNLTs3qQT-jxGAYw",
                "recipients":[{
                    "kid":"MAED-EKNE-XYSK-HMRV-C5ZH-2DAK-KNSR",
                    "epk":{
                      "PublicKeyECDH":{
                        "crv":"X448",
                        "Public":"sDzAAmGztVLIOrwXm4P-0YgqJnKc4rR
  QigvLMIAHbn9wOak_hV_pjtNCzJbPRdyw4Pr5c0btO0GA"}},
                    "wmk":"SCl0gtHId5LfCJKkRrwQP7Klp7cuEookzSL8pC
  fZulxQQyuw7GNr9w"}
                  ],
                "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3
  RpdmF0aW9uQXBwbGljYXRpb25Tc2giLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1
  tL29iamVjdCIsCiAgIkNyZWF0ZWQiOiAiMjAyNC0xMC0wNFQxMzoxMzoxM1oifQ"},
              "ymLWFY3LLNLj7pi9dd_YGHqbQkWK7znaKZja7ukpHEMOvDWLjN
  QiGhDsZKbuiyhofp-e_yRfNdutq0Lgpwr94SJAwJNQ2JVEx9hxCfcLv0RhD9M3z2U
  fWo1thMCf2rEKkDhfDQ9DsEapeDaqzMIQ_abq2HocFL3q_9FJyw8fnQ91KQWsgWgX
  ZNb97usgIQHZQEE4bUM2wQnvRrOf0Rl52KToYGuSIQtrfcVJE3NbVQIq1kU1n56XJ
  CrCyamARU-M_LTMAu7U08JqfNw_GfgZ4cavqY0zgzMJ0e5qeo9B6CHYwel2aEtE1J
  IwzRbm3Z658ue1kaSEHJu5Ikk5Lf3dfHzOkGipMIoC9tM5p0OAGQNtVJ_j952gaGq
  k1ojskImiRo54YF1EKpm45L3Nmjt_NDnPSCfYGW8D8J9SNQo9XMCJE8TxuQCjaQXk
  sy9g1rkxzXnpGjuRWoBk-OpxZ-NGNXs4qA4f134EKDlhZExc66ty6-EnEDL-rM7IE
  UdYaLwtbNt_AMSSs1O6AYIyLYm1q1KrugZvfY4T0X8ci9ZzGXPHwG2O5h-CavTPJm
  acu4p8nBXmKWb3j4_z27OyHSG_2vn_BA73fJ7l1LZC-FWjtjFnMjbmmR7PNHSDhFw
  uIMqsvjqOg1dqfKPzuG2AJYVRDkokDzjoZw5XIGaE98LlrEYWul5quuRKaxG7Dr_w
  n6ackJGmKpGtHFGIedofHL2XRHd6TCBDJ8_gcfHusUO9rjIJCQJXjJjOj4p8oozeU
  piazZ4CRhPB4u9VoQJnWQOeDECbQ1wvo64TFmjqu0OzAxaDrtmpbfVKjFlp4_73Kd
  QuAYZ00MAmc3SThe8ZKNuGoPdXU1WlwkvupKrvpybhH_DPJrE_Kp2TEEewvQ4h9D4
  BdRzWqGBMA5NKLhCe_BcQC7KyYZBM-ehbziuQxu7WBMfYyVOAW3SxWHxHOsXTkSNu
  ApFJUB2ENrH1mkmLMhLbg4hqLGaaUYQzwH882k72kGvoga8jIIn-jgkl-Ya_fqNNn
  Nm5p-Lnrv9TJLRQXexpnoTOpTCKAq9l89D09PlgYx5pPTRCtu3k7YUctUPuaf2qck
  gm_5L-1y0_IlBShM_uYRmP7KKeMNgUsiMTzOjffdry2PlGIz_cBdWBuoyEI0E3Ezs
  uNEzykI82D9Ad1Twq-VjF1UncdSpEyrbtzq_WLi95RSKbzazDA6D-8MY2UPXry_LO
  DimmqMtAnFZyUx_Uh61WLMifryNBKBIe9a_Z-L5rauGzw6l-XRfZpm9_k81WP8cT5
  _Go4rjhDuaIafj1obVICLE8rcmLlO_0l2hO2shssObM4wh2fwkuXNwljkDvM7Ibwt
  tPVUrf8aZFkKYTwt95Wbn3al2zu0P4u8t2NbpQ0RrUeA8ObmeBmfDdYAgf6XiJZTu
  zvNYCPj6LBVABHCDdkd-Qfz_qwKf735EArMmxjjGxKvaE1A3_dZgmREg-4QeZuI7y
  fH-cXMt3Akw-n0ZvgCHv3gjz4rUA7xieRBK713LwuWwgA9vbQapOYbxwcpbamiH72
  u9w7BJlz2B7YVbAe2UiJpgVuRQuu8-MXER7tX9IkzJ0sX8M9tM6hbP3_POpxhOIdP
  yaJ8lm-WXUjYzq_7AHoKPUYDw7GWZNR_yjoZjhQ3N5HJvZ7LEEAPJ9kHwiAoYfEFB
  dpS7XnSDIXAGaL3pltyCQqkNyAqwM6FH1sqeZZWGKvCVHC0YNDXETZmZM5W4mGTo6
  2gcuHNTqvxfWliah1Vg2whiQasfVi_zHtv4i7ujMeOntoaHPnlgA3fczT5RmLLVN7
  uTbHroVxZLJOmtit0RgaPkG50kvz43DWPFo1_pC0hDN3CeC1fwAKFn-n5VIVm4rwM
  UJxRyPRdfcQsVDnOtG6JqKE73NPKx7HTLG2HV4ZyG2KvKsqzfvQMylde2JLwygh29
  eD4c6gjQDJfJGgmv2DXxOXw8qIoDZTyFOFi1vGWhOYIZcgg1fJE8aMGXd86XQWeGB
  AHq-tGuTsutPG1o_nYoJ67suiCxnhofhzareFhcWcbeI-4klagauChxNNRaokDzo0
  j3ZhvfMZMRr0IW_9K0wIB2H6eD6g-OXrD-0Px9tEgDFqToV5QKxfJ3PRsT5Rh49FI
  jKdPFfbNMtoMk-bhXQov86yr1gXm9zJaVjzyu4198I1CRxQiBO_HWJ4HavFhR0C0D
  LvTNFGRNEgREjDaynrKssDzNsIkvIwhxjtbAtIUoyjniQf25bFjimmnxQllkYqXFY
  I4pDAbvMHkSTGsxv7iz2CkWA_M380FBqnqbXgtkrTlnQVjlNtbna1hf_LFy_Ln38S
  d94bgqmYCHD_kbGGzv3uaOrF1TNRW7zyjvHROX2T1nRj7RjLGAyH7bQZfmLgQywY_
  L-Ey-OX6Al44_8NfYLiJG34juDctn_UXg_0735smiSmLOo2U4CjvRN4_P69F7SaFW
  7zszLK6xOTNQjgQ81hztvlhCZ5evIdtv9Ay_iLXI4ZzAvb97Tre08gH3D5GMxzCcF
  dpSfCIus-x7oXIFaWyU5nMM6Ml4F-fAuzSD1U9Gk47tPVC5QQavAnNRqtlIIogCG6
  C3R8yYKSBGvc43284JDJmXiQTDClqClqrW1399psyFjEagYO0b-Xcua1nGO5L73hI
  lq_8007K83I5c5hxpD0QhgH5S3Zfd14wy9a6O_MkVYifI2C-5eSo7cnQWZKlj6Tyx
  -GQrs4DZwwD4gv1OfhuWy_juxZ-X0PKfGljtUHiOxUpZq8w4wsIS2YZVt_TLHPsR3
  OHL-h7JHzBEXhv1D4uc_zpCOa6LCaez67qAqomgXhS30kx1WUl3EPJ6HAIldpBwxW
  DYmle2DaZYok3w-24xMO0nqKoGWtwbLzRpZWOdZxNJN87ozU0NHR0Jtw_2Ig9ZOCb
  93z4kSsgAi9a9JSRLFOqe_4bXXj3nddaHMEO0q9Q3SoSnKhsedqvuqJg74RBMd96p
  gOlCXeE4obwuXob2j_Bf9YZQUdrYNqUatyGTxtV4FtUYqY2SEVp7T8CR2T8Gc-Kit
  mK2Bu_E0Od5tu8jTzU-NeopqP4uGTYHTcc9-YjBixldK79C2zKZayBRt9LQoS8gOb
  vAdo8v6LZ9GSJGC4dCmHjgJkZ-Y_rMRSw-akhgqZo7EeWjdrZKhmDAeU4Iy9m-fSI
  4KXMax1gOqsNddR_E0IVRvy0GJvsSTTfYmMY4DJPbQe6iqtsMuv7CFfR3L6g1QuwJ
  gpr-ZypzHebzmX-seUXBTG-syhsQCDOXGISXzarn9v8hDOBtp5GHFtQhruVvo92nG
  PAs-3ZpLMuKyhnbZPuYDXi5ffjgU"
              ],
            "Identifier":"MC7I-NMDE-PGIQ-4W3W-TC5I-QYWC-DQWK"}}
        ]},
    "MessageId":"MCGJ-S6GD-FR6P-SDM7-3QVP-IB35-WMKL"}}
~~~~

### Phase 4

The device periodically polls for completion of the connection request using the
Complete transaction.

To provide a final check on the process, the command line tool presents the UDF of 
the account profile to which the device has connected if successful:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MBQN-TRFD-22HH-7VJO-3B6R-APJC-HUCP
   Account = alice@example.com
   Account UDF = MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA
<cmd>Alice3> meshman account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MCGJ-S6GD-FR6P-SDM7-3QVP-IB35-WMKL"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

