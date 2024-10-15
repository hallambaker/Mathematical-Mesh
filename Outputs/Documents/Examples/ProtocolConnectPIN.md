
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=ADE7-U5DR-2YNJ-XKVX-4RUE-SVL5-5I
 (Expires=2024-10-15T13:10:56Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcd://alice@example.com/ADE7-U5DR-2YNJ-XKVX-4RUE-SVL5-5I
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    ADE7-U5DR-2YNJ-XKVX-4RUE-SVL5-5I
<rsp>   Device UDF = MBQD-CODE-XMWJ-QHE3-2KHZ-UKKF-TVVF
   Witness value = A6J3-EVU5-QGBM-WI4Z-HYUC-ONHP-O3VC
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "AccountAddress":"alice@example.com",
    "AuthenticatedData":[{
        "EnvelopeId":"MBQD-CODE-XMWJ-QHE3-2KHZ-UKKF-TVVF",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFELUNPREUtWE
  1XSi1RSEUzLTJLSFotVUtLRi1UVlZGIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDI0LTEwLTE0VDEzOjEwOjU2WiJ9",
        "dig":"S512"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIkVuY3J5cHRpb24iOiB7Ci
  AgICAgICJVZGYiOiAiTUNEWi1FQTM3LVBQTEEtVjVCUi0zNlRQLU5LREItNDRXVSI
  sCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlF
  Q0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAicm5RRnFZZTItYjU1QkoyNHdnRDYteWdZd2RUVnZubHljSHRTSTRtNWQ5dG
  1jLVlJN2JaTgogIEdOM1hwdFdoWThWZmVPS3RyU216VWtHQSJ9fX0sCiAgICAiU2l
  nbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DQ0gtVVBJTC1XS0lGLUFNNVUtSFRM
  Ri0zM1RMLVZIN1QiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogIC
  AgICAgICAgIlB1YmxpYyI6ICJnTXl1OHVnYmtOMkdQZG10OEo2WkQxY3M4UnhOcDZ
  lR1diWGpVanR5S1IyQkdIYk9tdmNWCiAgdXo5c09IWkFNeVVDUVBtYTBwQUpnRGdB
  In19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQVBIL
  TYzNlEtN0ZLVS1GM0hKLUxQQ0MtWktVRy1ZVzY0IiwKICAgICAgIlB1YmxpY1Bhcm
  FtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICA
  iY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICItbDdpOWx2M3ZreVZG
  NG5STzZFSEtXRUs0LU1nNGRsRWpqM1ZhVGxqcTdwaFlrSnhqVnEyCiAgU28zSUlzY
  1ZSMkRCOFA3eldNMlB3bldBIn19fSwKICAgICJSb290VWRmcyI6IFsiWUtPVFoyTU
  FKYk90TEVSaWdRLUpxV1NVeUFyM19WeGx1Wm1qYVpNaHRsWFFidlJtVjIKICBxeVZ
  KU1BXRy1OTHBtb3MxQkxPM1cwNjQ0RlB6Y3k0TWcwN3pJIl19fQ",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MCRZ-GZ3D-AAS3-HLJM-IRRI-CD4J-VFSJ",
            "SignatureKey":{
              "PublicKeyECDH":{
                "crv":"Ed448",
                "Public":"D09lNZXUcBq-n7euBgndE_nJ3xY5l0FEQHfgpd3
  B4amV3fYhlbN6AdhTdkDIFLeDNvIiBiozmUUA"}},
            "signature":"D5DxBdHfE-Wi6-LYWIPzIRO2QdrQ5VPWoHuFTAnP
  9zojCK__6dN6iYKisCT1dRDXIGwiCe-TrUuA14Lrq0bmjoNJ50F5ghENqOlTzfDzX
  V8BjWzPQL0ag_VWpN3JaiU0HRgTVvkugRXpAEE-BZdPGC8A"}
          ],
        "PayloadDigest":"XRZfMR090Cn7lDCmGY2gOMS_cGiE2c8d6JLh_33T
  J0xxfWWvQEkyup7rgQMpWZNqIFEWBQZE2OgN4Kb0gbQHbw"}
      ],
    "ClientNonce":"Py_M7xlo5rLB8atEpCCQiA",
    "PinId":"AAKU-MJKW-GRDS-S3ZI-DONH-D6US-4REW",
    "PinWitness":"cqed33rRoC4fHnVTjzreoa_x5BLKpLmhY5jIfxBeCODgbqJ
  clhyCWmoZ30oNKcGu4tEvP7wvslU8h4iMobSRNg",
    "MessageId":"NBAM-IBG7-4IM2-UNK6-NQOQ-HFSR-4LBD"}}
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
        "EnvelopeId":"MBRN-LSG3-IBIK-2RUK-U4TO-HOZK-7ZJP",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQkFNLUlCRzctNE
  lNMi1VTks2LU5RT1EtSEZTUi00TEJEIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyNC0xMC0xNFQxMzoxMDo1NloifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJBY2NvdW50QWRkcm
  VzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiQXV0aGVudGljYXRlZERhdGE
  iOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1CUUQtQ09ERS1YTVdKLVFIRTMt
  MktIWi1VS0tGLVRWVkYiLAogICAgICAgICJDb250ZW50TWV0YURhdGEiOiAiZXdvZ
  0lDSlZibWx4ZFdWSlpDSTZJQ0pOUWxGRUxVTlBSRVV0V0UxWFNpMQogIFJTRVV6TF
  RKTFNGb3RWVXRMUmkxVVZsWkdJaXdLSUNBaVRXVnpjMkZuWlZSNWNHVWlPaUFpVUh
  KdlptbHNaCiAgVVJsZG1salpTSXNDaUFnSW1OMGVTSTZJQ0poY0hCc2FXTmhkR2x2
  Ymk5dGJXMHZiMkpxWldOMElpd0tJQ0EKICBpUTNKbFlYUmxaQ0k2SUNJeU1ESTBMV
  EV3TFRFMFZERXpPakV3T2pVMldpSjkiLAogICAgICAgICJkaWciOiAiUzUxMiJ9LA
  ogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWtWdVk
  zSjVjSFJwYjI0aU9pQgogIDdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVTkVXaTFGUVRN
  M0xWQlFURUV0VmpWQ1VpMHpObFJRTFU1TFJFSXROCiAgRFJYVlNJc0NpQWdJQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0oKIC
  BzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE
  0SWl3S0lDQWdJQ0FnSQogIENBZ0lDSlFkV0pzYVdNaU9pQWljbTVSUm5GWlpUSXRZ
  alUxUWtveU5IZG5SRFl0ZVdkWmQyUlVWblp1YkhsCiAgalNIUlRTVFJ0TldRNWRHM
  WpMVmxKTjJKYVRnb2dJRWRPTTFod2RGZG9XVGhXWm1WUFMzUnlVMjE2Vld0SFEKIC
  BTSjlmWDBzQ2lBZ0lDQWlVMmxuYm1GMGRYSmxJam9nZXdvZ0lDQWdJQ0FpVldSbUl
  qb2dJazFEUTBndFZWQgogIEpUQzFYUzBsR0xVRk5OVlV0U0ZSTVJpMHpNMVJNTFZa
  SU4xUWlMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLS
  UNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKIC
  BnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk
  2SUNKblRYbDFPSFZuWQogIG10T01rZFFaRzEwT0VvMldrUXhZM000VW5oT2NEWmxS
  MWRpV0dwVmFuUjVTMUl5UWtkSVlrOXRkbU5XQ2lBCiAgZ2RYbzVjMDlJV2tGTmVWV
  kRVVkJ0WVRCd1FVcG5SR2RCSW4xOWZTd0tJQ0FnSUNKQmRYUm9aVzUwYVdOaGQKIC
  BHbHZiaUk2SUhzS0lDQWdJQ0FnSWxWa1ppSTZJQ0pOUVZCSUxUWXpObEV0TjBaTFZ
  TMUdNMGhLTFV4UVEwTQogIHRXa3RWUnkxWlZ6WTBJaXdLSUNBZ0lDQWdJbEIxWW14
  cFkxQmhjbUZ0WlhSbGNuTWlPaUI3Q2lBZ0lDQWdJCiAgQ0FnSWxCMVlteHBZMHRsZ
  VVWRFJFZ2lPaUI3Q2lBZ0lDQWdJQ0FnSUNBaVkzSjJJam9nSWxnME5EZ2lMQW8KIC
  BnSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNJdGJEZHBPV3gyTTNacmVWWkdORzV
  TVHpaRlNFdFhSVXMwTAogIFUxbk5HUnNSV3BxTTFaaFZHeHFjVGR3YUZsclNuaHFW
  bkV5Q2lBZ1UyOHpTVWx6WTFaU01rUkNPRkEzZWxkCiAgTk1sQjNibGRCSW4xOWZTd
  0tJQ0FnSUNKU2IyOTBWV1JtY3lJNklGc2lXVXRQVkZveVRVRktZazkwVEVWU2EKIC
  BXZFJMVXB4VjFOVmVVRnlNMTlXZUd4MVdtMXFZVnBOYUhSc1dGRmlkbEp0VmpJS0l
  DQnhlVlpLVTFCWFJ5MQogIE9USEJ0YjNNeFFreFBNMWN3TmpRMFJsQjZZM2swVFdj
  d04zcEpJbDE5ZlEiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZXMiOiBbewogI
  CAgICAgICAgICAiYWxnIjogIkVENDQ4IiwKICAgICAgICAgICAgImtpZCI6ICJNQ1
  JaLUdaM0QtQUFTMy1ITEpNLUlSUkktQ0Q0Si1WRlNKIiwKICAgICAgICAgICAgIlN
  pZ25hdHVyZUtleSI6IHsKICAgICAgICAgICAgICAiUHVibGljS2V5RUNESCI6IHsK
  ICAgICAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgICAgICAgI
  lB1YmxpYyI6ICJEMDlsTlpYVWNCcS1uN2V1QmduZEVfbkozeFk1bDBGRVFIZmdwZD
  NCNGFtVjNmWWhsYk42CiAgQWRoVGRrRElGTGVETnZJaUJpb3ptVVVBIn19LAogICA
  gICAgICAgICAic2lnbmF0dXJlIjogIkQ1RHhCZEhmRS1XaTYtTFlXSVB6SVJPMlFk
  clE1VlBXb0h1RlRBblA5em9qQ0tfXzYKICBkTjZpWUtpc0NUMWRSRFhJR3dpQ2UtV
  HJVdUExNExycTBibWpvTko1MEY1Z2hFTnFPbFR6ZkR6WFY4QmpXegogIFBRTDBhZ1
  9WV3BOM0phaVUwSFJnVFZ2a3VnUlhwQUVFLUJaZFBHQzhBIn1dLAogICAgICAgICJ
  QYXlsb2FkRGlnZXN0IjogIlhSWmZNUjA5MENuN2xEQ21HWTJnT01TX2NHaUUyYzhk
  NkpMaF8zM1RKMHh4ZgogIFdXdlFFa3l1cDdyZ1FNcFdaTnFJRkVXQlFaRTJPZ040S
  2IwZ2JRSGJ3In1dLAogICAgIkNsaWVudE5vbmNlIjogIlB5X003eGxvNXJMQjhhdE
  VwQ0NRaUEiLAogICAgIlBpbklkIjogIkFBS1UtTUpLVy1HUkRTLVMzWkktRE9OSC1
  ENlVTLTRSRVciLAogICAgIlBpbldpdG5lc3MiOiAiY3FlZDMzclJvQzRmSG5WVGp6
  cmVvYV94NUJMS3BMbWhZNWpJZnhCZUNPRGdicUpjCiAgbGh5Q1dtb1ozMG9OS2NHd
  TR0RXZQN3d2c2xVOGg0aU1vYlNSTmciLAogICAgIk1lc3NhZ2VJZCI6ICJOQkFNLU
  lCRzctNElNMi1VTks2LU5RT1EtSEZTUi00TEJEIn19"
      ],
    "ServerNonce":"w0zST52oIkf29KzfHGQ78g",
    "Witness":"A6J3-EVU5-QGBM-WI4Z-HYUC-ONHP-O3VC",
    "MessageId":"A6J3-EVU5-QGBM-WI4Z-HYUC-ONHP-O3VC"}}
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
<rsp>MessageID: A6J3-EVU5-QGBM-WI4Z-HYUC-ONHP-O3VC
        Connection Request::
        MessageID: A6J3-EVU5-QGBM-WI4Z-HYUC-ONHP-O3VC
        To:  From: 
        Device:  MBQD-CODE-XMWJ-QHE3-2KHZ-UKKF-TVVF
        Witness: A6J3-EVU5-QGBM-WI4Z-HYUC-ONHP-O3VC
MessageID: NCX7-ADC5-L2CD-W5IY-SFT4-NX2U-XZQL
MessageID: NAZG-5KBV-D32X-O24L-XTYS-26GV-FC6Z
        Confirmation Request::
        MessageID: NAZG-5KBV-D32X-O24L-XTYS-26GV-FC6Z
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NANN-LZ5N-6AHO-AOBD-VD6I-X7C3-GJHY
MessageID: NBCN-N55H-QYZX-F2TB-U5R3-2T6B-5W47
MessageID: NDHA-E73C-WZUG-QCMR-5IPX-52JV-WYX6
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
      "DeviceUdf":"MBQD-CODE-XMWJ-QHE3-2KHZ-UKKF-TVVF",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFDLTdPSEEt
  Uk5CQS1GUkRMLVI0R0ktWVFIQS1ETDM2IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyNC0xMC0xNFQxMzoxMDo0NVoifQ",
          "dig":"S512"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJDb21tb25TaWduYXR1cmUi
  OiB7CiAgICAgICJVZGYiOiAiTUROVC1XVDNHLTM0NkctNEk1VC1ZVjdGLUxUUVgtU
  FNOVCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaW
  NLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICA
  iUHVibGljIjogIklNeU1vN2ZFeTJ2SHA4c3lRMFZVNFhpdnBKRWhnUVFTWDNqOG12
  YTRIQ19UMDVVbmhRWXEKICBWWnl1dklRRVZvMmR5TUNSbTYwUTNFMEEifX19LAogI
  CAgIkFjY291bnRBZGRyZXNzIjogImFsaWNlQGV4YW1wbGUuY29tIiwKICAgICJTZX
  J2aWNlVWRmIjogIk1CUUQtRVRYVS1IWlJXLUEyNk8tV0RUUi1LN0dJLVg2SkQiLAo
  gICAgIkVzY3Jvd0VuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUNLRC0zTVI2
  LVAyVEUtTTZVNC00TElPLVpUUkctRFpWUyIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydi
  I6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiMXZOVUFBcDNyc3pJcGhHOEV
  zZm9hTzVZNnNaQ24wSGM4ekNnZFFpdllwSkFjRHRta1NzQwogIGVJMmdtRFRDSzZT
  clMxVWdQdHVZbVR3QSJ9fX0sCiAgICAiQWRtaW5pc3RyYXRvclNpZ25hdHVyZSI6I
  HsKICAgICAgIlVkZiI6ICJNRDJMLTZNN0MtWjNaMy1RM0FMLUpGWUktWklVQy1CS1
  VSIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0t
  leUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAiYkhvS2IwYzEyRjdjaWJNXzNnWmNKWE16T09YNHNuSGdQVndPZlJZa
  zZBUkpPc0dQZW1zZAogIDJCbTBXZm1Ba1JZTzNFUTZmajhfTnpTQSJ9fX0sCiAgIC
  AiQ29tbW9uRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQVlGLUQ3TEotNUl
  NUC1FVUNHLUhTR0gtN0xTUi1BQVBaIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  lg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJjN29vcko4MDhzYzlkNDBLWERoSU
  hnQ1RGejM5TUszSmpPMFE3S191ZkRFR0RLaXdWS2hkCiAgM29QUTQ0UEVxR2p3a3B
  wN09mYmNCYlNBIn19fSwKICAgICJDb21tb25BdXRoZW50aWNhdGlvbiI6IHsKICAg
  ICAgIlVkZiI6ICJNQUZULVNJTkEtU0ZYSS1QQkRZLVdSSEUtTlhZTC1EWFZUIiwKI
  CAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDRE
  giOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI
  6ICJYY2dFejl5MmNxc3g0WmViR0VSVGpyTi14ek44M0QtcGN4MDY1MXgtV1VDcVlO
  cnNuelRICiAgNDBDcG9NeHVOLUZucFQ1bV9iME15dUtBIn19fSwKICAgICJSb290V
  WRmcyI6IFsiWUJKUjNqUjJQbGpkWWs1cXhiV2RIWTByVFlFYUZBa0hZM01tc1I4en
  ZOMURyMzNSbkwKICBVTDNUaHJHOURNV0JaM1AtOFp5R3p5S2FRWXdlY28yWlV0Y0t
  3Il19fQ",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MAJF-DXRU-OY7F-RXLC-JZVM-LNM5-DWGS",
              "SignatureKey":{
                "PublicKeyECDH":{
                  "crv":"Ed448",
                  "Public":"9sZGEfYSIoTvVSL0Q5c_Oip_Hi2iOTsl4L3iL
  whfOv9bA-5nd7PyRooKEsQx-lA7PMAYBewSOmIA"}},
              "signature":"6x3k8AC2jkUQv0jzlUVWJDqP7zcNkKAqvPcAs7
  Ci2jXULjbIFAFCct8GC8Nb8KiD5ljoLAsVHr-AnYcjklyXSHN6Gn_BIZiLiW3Yu5_
  ChXHspywX-ZGMD6soXJIilOzreauR-_aiUE7Gx0eh3Fje2wEA"}
            ],
          "PayloadDigest":"tXPfbmg_SRmARF_7HLPq-bM6NMO1h1Oa30f_Ag
  _TIRzGKMrmTKtV7XH-h3NIBFGxOQYuD0BproKNEg6uhtG0Mw"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MBQD-CODE-XMWJ-QHE3-2KHZ-UKKF-TVVF",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFELUNPREUt
  WE1XSi1RSEUzLTJLSFotVUtLRi1UVlZGIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDI0LTEwLTE0VDEzOjEwOjU2WiJ9",
          "dig":"S512"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIkVuY3J5cHRpb24iOiB7
  CiAgICAgICJVZGYiOiAiTUNEWi1FQTM3LVBQTEEtVjVCUi0zNlRQLU5LREItNDRXV
  SIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZX
  lFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJ
  saWMiOiAicm5RRnFZZTItYjU1QkoyNHdnRDYteWdZd2RUVnZubHljSHRTSTRtNWQ5
  dG1jLVlJN2JaTgogIEdOM1hwdFdoWThWZmVPS3RyU216VWtHQSJ9fX0sCiAgICAiU
  2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DQ0gtVVBJTC1XS0lGLUFNNVUtSF
  RMRi0zM1RMLVZIN1QiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAog
  ICAgICAgICAgIlB1YmxpYyI6ICJnTXl1OHVnYmtOMkdQZG10OEo2WkQxY3M4UnhOc
  DZlR1diWGpVanR5S1IyQkdIYk9tdmNWCiAgdXo5c09IWkFNeVVDUVBtYTBwQUpnRG
  dBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQVB
  ILTYzNlEtN0ZLVS1GM0hKLUxQQ0MtWktVRy1ZVzY0IiwKICAgICAgIlB1YmxpY1Bh
  cmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgI
  CAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICItbDdpOWx2M3ZreV
  ZGNG5STzZFSEtXRUs0LU1nNGRsRWpqM1ZhVGxqcTdwaFlrSnhqVnEyCiAgU28zSUl
  zY1ZSMkRCOFA3eldNMlB3bldBIn19fSwKICAgICJSb290VWRmcyI6IFsiWUtPVFoy
  TUFKYk90TEVSaWdRLUpxV1NVeUFyM19WeGx1Wm1qYVpNaHRsWFFidlJtVjIKICBxe
  VZKU1BXRy1OTHBtb3MxQkxPM1cwNjQ0RlB6Y3k0TWcwN3pJIl19fQ",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MCRZ-GZ3D-AAS3-HLJM-IRRI-CD4J-VFSJ",
              "SignatureKey":{
                "PublicKeyECDH":{
                  "crv":"Ed448",
                  "Public":"D09lNZXUcBq-n7euBgndE_nJ3xY5l0FEQHfgp
  d3B4amV3fYhlbN6AdhTdkDIFLeDNvIiBiozmUUA"}},
              "signature":"D5DxBdHfE-Wi6-LYWIPzIRO2QdrQ5VPWoHuFTA
  nP9zojCK__6dN6iYKisCT1dRDXIGwiCe-TrUuA14Lrq0bmjoNJ50F5ghENqOlTzfD
  zXV8BjWzPQL0ag_VWpN3JaiU0HRgTVvkugRXpAEE-BZdPGC8A"}
            ],
          "PayloadDigest":"XRZfMR090Cn7lDCmGY2gOMS_cGiE2c8d6JLh_3
  3TJ0xxfWWvQEkyup7rgQMpWZNqIFEWBQZE2OgN4Kb0gbQHbw"}
        ],
      "EnvelopedConnectionService":[{
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDI0LTEwLTE0VDEzOjEwOjU2WiJ9",
          "dig":"S512"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tApQcm9maWxlVWRmgCJNQlFDLTdP
  SEEtUk5CQS1GUkRMLVI0R0ktWVFIQS1ETDM2tA5BdXRoZW50aWNhdGlvbnu0A1VkZ
  oAiTURPNS1YTkpPLUxDUVctR1pTSy1RMklKLU4zQk4tQ0JDN7QQUHVibGljUGFyYW
  1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1YmxpY4g5tfcoRrH
  -moXof3ppxP-1rsXnpnEc37YXEQumpfPz-MS_fTyxbhajFi1bpr5dZQjrPqCVVWMP
  FmiAfX19fX0",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MD2L-6M7C-Z3Z3-Q3AL-JFYI-ZIUC-BKUR",
              "signature":"9TrTu8tVJ2f9e7_PgVQD2O9JwsxrEyzjTWyqoV
  rlqW1NA4EKkPcPnnMKFFMflbte38rYUSIngUUApFwe2RFaBD_9p3gDpEJgXjQyHyj
  cHn6gu8iOP0WMwUiAgNQCJLJLXxw_zYpIjwIlDUoYA5eaLzkA"}
            ],
          "PayloadDigest":"oEuqftV2yGBBO-zcHdLaZlE24EedCob55acnhS
  mU_3hmwB5GGwKkAaEc3arbl8LlFvw8qcOx4DEmbn2e0l_ETQ"}
        ],
      "EnvelopedConnectionDevice":[{
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjQtMTAtMTRUMTM6MTA6NTZaIn0",
          "dig":"S512"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0BVJvbGVzW4AJdGhyZXNob2xkXbQJ
  U2lnbmF0dXJle7QDVWRmgCJNQk43LTJWUkotVjc3Ry1CTzJaLVNSVDItUEtZSy1GS
  ExQtBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0ND
  i0BlB1YmxpY4g5mHAKd6yWYjepjbjcF5AE3_mVB3NCLhPL_g_UIwgI5j9GvARZLzs
  drWAngOGTv7M6R_WM2IrWl3GAfX19tApFbmNyeXB0aW9ue7QDVWRmgCJNQjVILVlZ
  QVEtTUtLVC01SkNNLUZXUkwtSElKMi02TjdPtBBQdWJsaWNQYXJhbWV0ZXJze7QNU
  HVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibGljiDk0NPeEx6n3ELUk1MYr0r
  3nSo-qxXfvvn35g2S5sxZqo8uMquHzzA1PWaVNF5bharNF__kWmerQxYB9fX20ClB
  yb2ZpbGVVZGaAIk1CUUMtN09IQS1STkJBLUZSREwtUjRHSS1ZUUhBLURMMza0DkF1
  dGhlbnRpY2F0aW9ue7QDVWRmgCJNRE81LVhOSk8tTENRVy1HWlNLLVEySUotTjNCT
  i1DQkM3tBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWD
  Q0OLQGUHVibGljiDm19yhGsf6aheh_emnE_7WuxeemcRzfthcRC6al8_P4xL99PLF
  uFqMWLVumvl1lCOs-oJVVYw8WaIB9fX19fQ",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MD2L-6M7C-Z3Z3-Q3AL-JFYI-ZIUC-BKUR",
              "signature":"yYwmrYVkddU86Hm99yKb4QlqVqr1Rw4vAdaztF
  l8FRG3tCO77sMc5vMLcSJTkdK-FOGOrQRk11iAGZ5ZEgLMFJn-QRpSmcbBLeel6lD
  SUJQRkjVUavbCxej4RKJoMOJbzuBmZdvsreHynZdbk7p7fzIA"}
            ],
          "PayloadDigest":"CsqBGYf0fzZ8YE4nzhUuuvfL0lGsaAkNFKCUhf
  1YsIwCxuDQY_zZjVcOEgFsVeUggfmm_spXiahBMaDM7zz2fA"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "kid":"EBQM-YIA4-PNBW-ECVY-NBBW-CT2Z-WUX2",
          "Salt":"kugd4f-D2t7K2ESGjW7J9A",
          "recipients":[{
              "kid":"MCDZ-EA37-PPLA-V5BR-36TP-NKDB-44WU",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"fH2svl6_uVYsor6k0kzRFZEfAXWOAedsri-XL
  9YRzAQsN_l_M9DzmRWxbvDsLC0fztCVsvfTsN-A"}},
              "wmk":"JNEdtBna70N_7MINkiCfkRdXRfqGXo3d6QXoPyoRkUqp
  N3bSxdYJKA"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDI0LTEwLTE0VDEzOjEwOjU2WiJ9",
          "dig":"S512"},
        "-fy3XJD_nkzc5E0amfUxXyd9iv9ucViLMp8hOhrMSEBDOCwPybwnY-hS
  wNA6-DwlMZ1q8tfpTmjJizv6Mkf4PRkYE4qOJJTDbxtS6lNMvBJhBvcKgMDoeAnVf
  Y7x9BomZLlERwo6BMH9WavqiMshfLEC9RJ4BSfjfMcp5-P_5qZ_fRAutzAOB_vsEA
  97F0SmzjM7Mjdk0M0iVtR2F4UH-FEEgQFdAmoYwSFV3bXCWRkYRD0y-B_4kWqBXvL
  1-SM2",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MD2L-6M7C-Z3Z3-Q3AL-JFYI-ZIUC-BKUR",
              "signature":"arywkmG5iJUxfP4MHIMgcmXyDk8nWzsh6RUz8Q
  CiGo60E2JqqRtaZscxTlYaEsEMR0Ugs-AH8cKAD7f__RB4DxiUuWORY11txAmfpIR
  2NwLnIsQ0S65x5dauAJ5mFY0QTDucNfXGDaCU8V4UlDIn-QcA"}
            ],
          "WitnessValue":"4KPjB1dl0OVeugi6FxuDd2l76-tOdwQ-3KVVWqo
  Ai0g",
          "PayloadDigest":"XFmB2PVKxowqhjsTobBlWcqL6lxrrmrTPbmgC2
  acKwBiF-8IQFVAep1nSCYX-FXTibvVJYhov1JbEVNriE0pBQ"}
        ],
      "EnvelopedActivationCommon":[{
          "enc":"A256CBC",
          "kid":"EBQJ-A3RO-PE4X-7LMM-QSPW-EMFA-HGDX",
          "Salt":"RImEmW_A-Z5v3zqz_aYesQ",
          "recipients":[{
              "kid":"MB5H-YYAQ-MKKT-5JCM-FWRL-HIJ2-6N7O",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"dDyHxC6UbAhRoN3dYsK8Sq-UAqA_wwA01zolu
  b1zuhKOAY_TB7RNhjcNYK7_DIGoitWQVVOKM0SA"}},
              "wmk":"Hx1gKmlhsjVZdRqKAgkmnOPwrI2HpEuK7zVEmiGeGj-p
  K3ay4x28Nw"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQ29tbW9uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjQtMTAtMTRUMTM6MTA6NTZaIn0",
          "dig":"S512"},
        "4dJQ5E39vl5VRFBsQ5u30C_8Yg8V3J1wS_8-sZIU2ElTVOr_5WbK0_oi
  gYUdnlTE40tAzb_W7sOrVm5BnIFuU8q55kDOXtBPlCaDZHZ1WKhJKfmePQMdUpEnx
  uIEVajUrO2iw0Cft5Y63KZnlzQeJTBj3hF-pVYHZGgxz2fNiu-_wBclnP5P_O0lzC
  972FZp5B2UHqsDTFgngY4qgMfQJvbR1HybThFFjeicjJF06umMGSi4caQwpevNAoY
  OsbTbXHlCtrZo1RFhE0Rfn-44M50Dm-QVaqB5EhGCv06i1UKGnc2QXje3WBTxvnKz
  z-z23SD_uRTVWhab4ln4wMSXu_75Fz0u_FMa6yowlKjOzs7XnbNlQ21HotQZN22Qs
  Q5pdIge9Qk399Yu4rWbO9OfsJD4gEDIIGr1lTMEncub3XflJcMqQjdX8a9Lt_yvgb
  UmYvkcTLSy8CF2bH06KdAU1NpW-XrI6GgYfp3WYOEBnIApF8H-NNoJ5LuMG6KMStB
  zfk5cbTmLBi1kwPXgEgwi_FYNIdbfoYu3qylAWNMRxt6X-xfQr7rTIEMiKwhyYWfc
  6UcrmGmcKZTwDyYsrMxrOm8LhG1fwVTrt4by_sooUSDW5OLy0_AhLHqknFg1VGvT_
  xkYQEpnYw0hxEMfIyPsGFQpOAenCbWHjR0-jz2jI4ulI7rNEu6JEBcmR4FQcu3pLo
  covG5UrQHddkfZ51ATcVUkMw44GskHWF7uyD1OaAWIj95ttGdRWNdZ0X8GKLlYWv5
  tZEzMeK9Cxy38K_ilpjKTxuwYWNR29xa5tuz77TEpLddeXAbUt5Y081yC3D6JlAxp
  kv4p7uCRfD_UjXA-N0HmG8SG2iUE7XD3g60FsNQOMaslgKEx0iDFlIOYY4Q3Mj6eN
  Rq_B8U_iEKAyiCdJB1qPVhZtAd1TsDtiV_1XSKismRhtiEkqSOB570fyw1s3Gz6lG
  zWHm7Q_sy5yGKRL1BoLZR6jrzakzMlifGNAbuXh8VuHeeAen7a5pAOOwwJJ1DpohX
  b-b0djyRmYCp_1wZ6CD2XWQHXi7zRRrULCfdqedAR5SvUB288AG0asmNkWCi5jtAj
  Q812ZmwRHLAW98HpSZC8Etgwp_aQBBwnEp8q_cvosmvEI3EZGeoCd0MgGX2iG670G
  _B1nNBtDCqrmvE5mfg8PkeCSaFZWPYY2Uv8raIPyzrz0PBtQxVrsnUrErrYVNOZOq
  NiJLgpNLbNGtz6ZGBrln2GSi7XRzzM3BhZLUB3_bOKrq_VhKQXwCu6VT4amEJ3ak7
  w5zLJ0LsvMshwYhZjmHRYFDZ2qqHMQDbPiMCYcFGn6mAybuzGr68CFVF-pFRXckyv
  h0FtFiKjewwABEGIaAF6qeuzEDWVD6bn6pMa5eiZgEQ4iiyrcZWmNVS0D7E5R2yZu
  TEIRFOtx-tWivth4JGFh64rzIvnOoHwxukk3JoQnmjkTKIMLms7Ao_FY1Ow9Ofbf1
  ELoLJrZ24Z7z9wyuo1ROTeJA9PJ0eDJnLKjuLdVszT6zttKSDVn9jIaXcm2jeJcly
  Nce49EN7c3tw0bT-akFM9-CDBVa0T3rU0N7YfnKiXYpS01JyzBqPVxnA754EX1EIT
  jp0VMB60k0UG_5dsSV_PMlAfBJP0G0gDhogjB9gEyabXbVEbOA0Bq9_-6cJEIjsnZ
  _pyxBggy4qy-w9ktb0IB-X7rB2mfrkp4OH_nggzoH-O59-e_pBO2q1nuJ8NoCuZWW
  169w1GQMMJsjOvpN-VgLHy9eFA6-GukqhAZsB-FFHOqU8HRiDIrw92PD4O1si782c
  BIdxTaqYZaFnyEFk5PnFMTrvdfPj3wakmJ6apYITX6CWVP0M8X6-D2JPkNaXHn5oo
  FS811yVIZOJKK7_DSCVyVlAyNwhURlJwYWgwr_0-aYhR5TMME-zw66QEb0_dnmy8O
  _qNyHCsyAdk4ZhwPdJAWjKF_hXeTA_BzQC4ilzYwhcMOKYsx4VDgrsDqN2SKCIGry
  6-FJbTQR22iMPbMHMrYJQ2mh5GEx1dWJUWOIrNAvhwJiKF_RrD_dDrWt975sT6gMn
  w-GPWDuqWR1TX5gNWZr_gfeF1jM2UuDt4SvhgdQI2dqaf-eT5FOTSqMvgR5gghVRu
  X8Lm_19s6evcO89H0sxaSWjxBIgfdhJZeAoNcrUSdR4LvtDLehSbD2t9SQH6UfFs-
  nEYIWmAt9c_ADthMibgI_FiiSziQcvf83MzH_HoTNinmcdpgcIrssBVTyhOFpsT_s
  9pcoe4L2WTRNKMy2rp6Y_cklVPweYlE183tw1hrBpcbdwMQ5W-_GNXHqWYFBrjyVY
  LP-OOfnvV3_n6cZ306QbpT1OT5tyrQlMOqk2J9ruFVunGxeL7C24H7ftpf6c_Upvs
  pbMQhptT9OITgvSngcjfAubu2vAj3asYA_UNsfOGn2wRkCQrE3fTY43S2Rjqwvv4Y
  BfubcriYgf_yaexaoE1w5XzjCBcYdQP9SVfOFGGGKvATLT24xLF-OYfiYSjwYRiFV
  64oEy79I9eXgaa-fQdtvKIyJlW_KHA0LVcKdGAbpuYZYm_V8Djq3tlvwwj31H2TQ4
  nkGJrejs9BQR77KDaoOoYOlEWal7wg6TIrSj_MV4wE_3DyOY1nymrVaEVwYQYGpxM
  CiIPHnoA8sbrXXA9tpweicUw695kXTUvrnVb1sayODAzqOELzm-h0XC4xGHyjxB9X
  KQeUOfr_z0py2wTBEAZnlOZfL0ne7CrPkaIYfHHjJohZMlZOg38Hutg2KUF1yTx3H
  hKgzxTwo-mMgRfeytQWA1tSntBJYNvWykRnnMUR8yorv7CUv4y8p3xg9Cb8tCG4Df
  JYD3rTXf_wmyryflgJ3-2yNriJlX_Mi-nHgyRrObzeitRyQVSbUMxoendfMKJQJh_
  rC4AxjgOpDj27Og8ba4Pyph6P6xXIteOdIRTwP_J6Ln2-SwZl3C55LOhnwYB5YIo5
  A_PH2RuUpZ2gf1X0gBbT41slwy78xy4TeBtpOa2FBW9z0-UCtPI_U1NGqNaB_c5zs
  sArER5yRo9QrUv25y1GW43YHJu0TcNARWHWkDmT-b-oJSvouVaZGbz623JoAX2OnB
  zqsFzBf9fK8kbyymh1eLJmgKn8l8pf2-jgtr-UnjHwGChbiOj93VlQ-S5PDsb3j3p
  bfY5jBl2oU7VTze74T4pSbv62PQVjTg2JwIYHI-cK6x8IZJHJeCbH5i_P6kpnHTQv
  ItuEAlSliGVUyJ7Wm-0fzd8qgCybwQtv5nyKdyiA8-EkXKAUIIIMhabKADtsYOzdz
  8DfB9TNKLzc-ueidtRARFQAYMaWKDO-KrUnye9J9kgsRQaoJhUaaGLymDqX-CE3kp
  sSigbr53uV0e_lNPjswH2ddI56ELo1ZFbX_75XlNyk7poMSZ2f_q62SMpCTYkH-Hc
  0XS8vzP1NHITyJXi8Xl5xdyI8-IWCQLPpvdWiyDx111VFN3aSncIiWXOw5sWutK6j
  novXDbm078TVL4zQAOvGZ5zbjhExatWXIhxdH1RB28KyLtJ7SgDsN8qPB9ZJXhY80
  b7aKnFxb1v2Rxy1JNvwnFyaOuEUQjAN5jbDYf40E1VlQcakk6x_WOEs7FINBej16n
  oztqAQ7mmyxDVMICWsveRMEx07eC0gYHzRA044SeiBBlp-mYdyD3gSwKsM-F2dYZ0
  y7GLUR-sPhrNJg0ScBAT1j3_MUESm1k36VwGwSp85_8OerTCu2f7dojp_xqCB0ZSV
  L0_zpPAyYrGlfKobYBDdhgJU_LD73jTVeaXZi0zgEAAlYsp0Rn7NMwOBejBaVC5Iq
  IgYuW3_UlXs7YtRFMxydXJrcZnFQx6HMhP8GMr_f119jjnnaNi01I7SvWbHU2Zs4U
  sSAjcM53PD-pytSDCMDNfB_qXZWLt_cv2EM2C997Dz5HG9rz3dyrOJ1XM4LiCAgOT
  aDjYS9OzgKrpAchO0w-AwSKJ_7Peg2J90_MPu0o0J8Azowo6Fe_BgHdCtuDK0UMl5
  J88GXkSU3g9AoHQSdXOmr6yHbDVDyrQXiEjrdfzwoJEvfUi8XVSS27p_ic8s1gAvL
  bJh2ev43TpknOaHikquURA0aLZT7B2OZSD2XtLzaNUSbu3DkPphvGvGR9mVfPv-n8
  OrbpX_RgCZtCLju4no1SwY9RFhqiYBRPRJFfi77B2cIOiaeSaDMphDo4jA2yFypeE
  UKOd-JdLlTX1YzwZmgu3TgpxR_Em6UffHM0z8x8lQbYmuGKW71ZcvYqSOeh6fK60C
  sPUZsn-G6Lxd2qGX_Zc1htZ_E_3NAUMdF82VzMyj90SCLQ1EaKwRQaHaF9rgKHjsM
  wbFMUoCUL5N5WCxKRkDr2QLtfJ2ezMQ3GrpDiw2xHq-xZEzTUnq-dzuO428ovJypv
  vxglUgthfOO8NE5a15gTP19HARTuT2WZQxiSyRGucoItLZhxUM6WxHB_aGVDcDm5a
  xzdVNbYaesqdE61cHswDOnY4smxtO8Zy6uT12WPw46S0LWoDv0ba_hyMEMpJTNKd6
  i9DAG305R0P3NYVFvyJKOok1e8-nlpQE7G_R2exVdgUkNJYLvl0M7pGE70faXVm3k
  0UqUojmO0P6RpsrKcLmBm_0J5vbLdeRexxcSh0Trj-xDhjL62hG0gWe6IoCc5GYIw
  qComX7pLJ-G5h8MI4oB7npCK55_2DvrvyXBFtPiYuxi9mfQOXevhDYKukAk7U12g9
  pwnJSRvF8rV7hNw-OC7rPAT55z5xXx05rgrUuCswfhZ_4Gh5_aWjzqKAeB2KpJ5c5
  81R6IWs_y0wM471AUZSYOEo-ytCH6_qgwdPimUH98Lo5e3h7XQnHweu2A-g_nbOM3
  -voNfCcBxU_-rPYysyORvOJ5GcyIle3W2FSnBDwxS7AUVTkvJrybl6Q2MWlMA74z5
  a5C5jcGZbKJwbmhqLKWc2H-IA0CFjiqirECKMnl65A6vNpLdLoTYv-47b8Gm_qKB9
  odY-mSOolGtSTdF7r89FJwLjviTthnbvaebfEX9I1vNlmOBdiPNebl0euWDMlbiMR
  c0if_wPITYrNQaJA7elgzIwizC07ZLHu3dF-vK4pqFN0fITlCvcV2qOA85Gn0dfrZ
  Hcp84lK-IDJWMMITyqntz-SgxMpkj8qMePH-lcPK3QHfnSwxxCbvojgzz7OlvXFSg
  6WWZdNJ-LBVdhNif798Cwym2_boiVSyapNqZPCvHGvQu0byG64-sgRbYteSuASEdF
  FFeQqwuQj3xdiTAP5AIvoA1kOillzVmkHZ3cfi9SciZI8jBsK9GfZJ311HF1p9S5A
  f3fXxzh-ZWqFnGxrE0UnBfQkaSb4rzPID6bZtZfpG-q_ha4diOOz4CDbVU96DEsTx
  EgMyfONK5pG6yA372QCFGtSJlhyqxgkAx2tULOSU7pD6-nksRYxkhzfluw8F25eSm
  gygudKA5Fze6JY-5MqGiYG0VyUVc0w_Iekp6dRPO4bI5M5Y7J_DvrfpD9t7R_rK05
  emm7IeZk4zfyTlVfx0aqqSXIgeEBJHosKraZPknWz7mDL60vVGCLIFrrjhoOCPyI1
  6Lod2lJFJo9-S9a0fChR7W6kRTepLb11zCu5xTsfmSFknmHJMtTSS_pUp6GhVFzY9
  -ol1qKFEuali1A4nrlu2ysIPOe5u-a-yOLNayvpUpn9Bcj6gLZ2_g0xbu2gePOJEF
  s7EMuc77t2AQY_pyx4rMAcb2Rquh4hlrtlnO3OvfQZn0xvd9_7vpQ7Wpz_5ElM_96
  Y8jNaNkAPigRWAjpYMpb2fSdVCam9JmLhfyH8WfEskQHEzyPIG6-cbSWoW8evmOjT
  4xXpcmBGZzbUG3zUnEbwUwhxiTmUhKLEel08lnoXScYqOMMnlrg7XI-4tQQVC2r-N
  UcsmmJkbShDqIzJ-IvSxAU4IAXnan6RNv1IyLLThwFIWR-GEIfOHByabtzStNmUR9
  vzYq-WBtyWHnGWEwMLH_0ODz97Tz6tbmbiWERo8RZ1et2FAoZunF3OJKNt-VFnJK_
  OPIjQQQIm4UpjwQetvj0B-tmGHfSN2m-4D34gpYQqVqyLpeoeLpImBMNOYdpiYRRm
  Tu87pJwc9nNxO7Pt-MHDvgrjvwz5CakFewzKE6ZgEpY6KxmR8yoERyORq-rikRlFA
  7GK_EuARv_Y1TJTm54qVAD3LM7wIRdvxLSVgsPNe0OP44Y2ag8V74SAEWOTLosz5K
  IGkvuJBa9cBBzi_7Xk2PkIOjIt6PBsRuXcYPxzKv_vyeXvPheJW1nOv0NQdh3naO4
  H8sWo8KN8AJqulC5z0oTCWa4WwST0NGCpzwXxSZ0S0G3Rn4v8IDD-o7J4aZ2Yw-6E
  KgAqOBRQd964oCvB7NX9bmJBRKTvPmhXRZTJ3fM599dpNcd4gS90c3gOUjD15fqfb
  2ozBRl7jWf7MOPT0R4C6L0TZP9WU-l47La0ybmHdDktGQMd3WGP5rXZqVch9oxJmB
  qW14NCAUHuUutynNu4zjzJsMHJl_LQrPQs90625Srl90NsL560fm4ArdQ_hmBKG1b
  L-FXiRe3BgEBIOceKFWrJ6yN0G7I2gI-FL97HhvztcwKcG6wn-zayINBS3saBlc30
  41AXATNbT_V0jej42o6pycL3pWj4V8IRTfN--qp_Jd0992CWwl2H6ckRl5Zav5kyw
  FDKBbNQ3oSIQj2a6fX5hFBRV10BjXHqAviKjq0Kxlspj3oTuPs84mxxWwuNc7COt6
  5eAsbk4misCQ8I1tb3ekPBp5IrD3O4ptKWeDHGTdBYtXyISTp_FOyrkzX3XlWeQrp
  LIwMKxZhzzgthYrASEB8sFpCpzGGsDGyvFBttWqB3TP-Xp0pmpkCgvqLMdx0s6-PI
  DRs1PsPLlCqkbjgng2vXYbDB-RxR37-_KgRNAS4cDUcb2Xyn8OwbPSBfk1q_I8ItC
  L8TfOxFbTkdrCSk6m8ebofSpFK_FatCvqnCFeuadlm9RSVyQO4sK8nSxXTud5yLGZ
  8SVZ78_FMtDjyw94TTjQ_Hgji2Qm1tAtt4apLG6F5s_a3CVqBrdh8jrw4hWvKPyq0
  UuSwloda-J4snVGdi-QeurTC_HFrG9W5D2l7upl6yUzF6jZil6t-o0xugWKS9iW_g
  I3hfsNjHjEiKx0NWHylcn7Ej15o6mVClxAp9QkQKUhIz4UIrLw6UcouanBK8XPHWo
  1Mk1ZhF0OheMsD15wz33_V7Eo_clnb_ErF_XZJZvr2ynHoHEor6LYK58qi4ahbTJP
  ccNWZ62QktVEvKadmJcXl2Nr1bLuItezecosy0BHwCjzi82VAgDchZ8xWT4ns6eST
  PrjBcC2623Vqhb3u8_kpqNKFq9_gO7gfcj4JZNo5wd5ChImzKlECVcHusIi4cI349
  J9tBOnUe-xIcvA12vaOO8MN938C71I6cPB4T3hWvIqECI9b8AmATPmJCKRRW5wT_W
  OASRkVZhP70I6clsYhem5sAmVtztm4GJaTYRM8gHNPgHeUuarvxAtuX-y3_JJiJop
  DiFCIUBsAXQmSzrFB2i2wnIXy0M9v1Vk3Qxsj3Nf9I4r3PGTHS3XzvR5hRxzwf6FX
  IxZlj90EStdlTNG8PGuP7NLFEBT2gMwtXjxCkazqyZeEtLwUDvDke61ryMZOqlao5
  tMwsBSzFmm2GXvZCNPBRpBWCNZJx9hlaAVKbI400h-B9iP8NZjb_nZkE76rfRSv-q
  HoRD3MBTV0Uq-v87TuMvVIk05FC3DpFSduXBXbrG37ckSmMc-dugY80ifvdZm84xK
  FgJOMnpOmVenn6iW27xISV2Tfd5bfCyNz4BYPEHpeVgSTlw3SZI1CWGeTI6T33q-C
  xu3hUpFMXmbsn3PTschEVNeh3InrZ6GC-6qZfxZdHGmQKyghucfB5ldiJ8YiHdClp
  gRD4VXoJOUEWnITC7vZuamR-1Q9IVvri5DjVeZ6MLvQMTZZLObl6HyjwrW4w7GH83
  wHLm5Fb-4ym6YbH9Aadm5R7nUFZjoECBvBJn3h2uLKkLGaXzgTJYYhK2bnt7AAC6J
  hDr1WySiRCPVrFe0-ON6FGYWVAez8G5IAaebG8lkDtxT188UO-6GzjV7Vh5sBIcQm
  aEsQv5jEkFl3U-MG15hcvXCebdbzpX1CGpMjYifDThac-VsX19YkOyhtFAssdQYvl
  y_C-13DaRW-PK7j4hkdjD0irQvu1LeAUDdSz9kmjF8AaaBsy6xStIFdrw1Ck5gD2t
  23ZdeqSBGvGJnTIzvyeK3HCv8oKuJRQY6kcC1APzAUkjvgNbx70z7n08BSosb3Z1B
  e1mo2X8KU9fbUj-BJpyR6vITcc1VWwmvV7T6IM36sIhjrU-3IrP8d2bZZg5T1buRv
  2V9nnGbLKF6b36BpKnQbt_bQsha5WzuQMmxX5nlrgMcAVO4CotMPTpvG7J-_7ddK2
  vwK6EYekWGtEKmYQhw_kc7QAAERfH8bM5veixZqUAY6YxC5ibxyNEnbx1u2NwNdKX
  pZ3G5St2ZM1UovcF_I8e4MuzsZHJ4Kuxrg4RLXvMUQQn7WfAZL3uLZ_Ln27JGeMXN
  kH4sy8osYHRbzTPY1OtEJAmCelSk4JkydMyuwn48JrKCaIT_9LKvdY56bHrobSmvw
  V5L8fGCsSWVGWqNn3rhwBiNgIw",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MD2L-6M7C-Z3Z3-Q3AL-JFYI-ZIUC-BKUR",
              "signature":"gHExk7IRqx_fSpaKOp_X1HLy88WStnwZWO17k9
  MekufjE7eaooRRDluULSK0DIvXbbfKC3hVlsgATCTqb5l68NkFhluvJ2z2MS7M2-h
  aRhY3Foa_5fMQdWC7--nkWF11jCh9eD_pXgaOIx0t17vVTT4A"}
            ],
          "WitnessValue":"rlT1c19N3iBlMXIAMd6bcobgDnH2Uv1m-C7VV90
  Gnyk",
          "PayloadDigest":"LudFo4aZ5eOUbOhCRQ119Oe_5JJRye2FSlSkOM
  WSC4tJUmYeuYDyxAQxf82re75Zgps7wMnww5QwjCto-9WdRQ"}
        ],
      "ApplicationEntries":[{
          "ApplicationEntrySsh":{
            "EnvelopedActivation":[{
                "enc":"A256CBC",
                "kid":"EBQH-IPF2-DRYU-N2VS-VMAI-MRHF-IZKT",
                "Salt":"eJdGrdqLp8RcPEEEXCgkmg",
                "recipients":[{
                    "kid":"MB5H-YYAQ-MKKT-5JCM-FWRL-HIJ2-6N7O",
                    "epk":{
                      "PublicKeyECDH":{
                        "crv":"X448",
                        "Public":"TFp8dAMe5wkLifcl5S3OgP3e8JPEBUx
  WRg1geI9NbXygTZWWTssJNlrE358qdw0RxjA-agAsScWA"}},
                    "wmk":"G7hWogNaI5S4osEN_QLNA5k8VEPRuoDSM3NF3t
  lBqtw8g7OypHpYQw"}
                  ],
                "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3
  RpdmF0aW9uQXBwbGljYXRpb25Tc2giLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1
  tL29iamVjdCIsCiAgIkNyZWF0ZWQiOiAiMjAyNC0xMC0xNFQxMzoxMDo1NloifQ"},
              "GHk2FJEAip3mtk9ruFfCQ79sa63GkE9nWZ6WqngeJ4_kXRR7d0
  4ZME3CZGfwTmveMT5qEw4WKWwj2r0nKHm9dFJpwp0BSY8-6kozVbzAM2gPW9CrLYI
  KoRBT_dxjst8KzusT8gNADy5Bw4-l-AB7ucnmzZiQkFDxM-zOi6KoTepieRUAtxXn
  OTUfkpGGnOAx8nAQfyYxQ5ShLHxXMdJs28am4vj7XMC9t7L10c9ioZGfVTFLfCxEl
  LjvUVff2xX9tnLwRYRaCthdX39m3ld1fBkV1ARkGF5yqQPTtrUuVggLaOwTr4EG9W
  UZAi2gSgNUrP8vBnkt5oEbZlO7de8h_X0DQRAENjnaz8xLM6Ns44k3YoMzF8ItbhK
  KwPUIM63rAatd8qTNXfKw-sguZnWKZnENeqlKvu6DayHUMFTEESUQBoYdSFv6QiHd
  jFqCQ19sHw2mnhRKqKhKCaViwWPk__dYjh8YlU4Ws8Ip-XGzfhOHh61VVzZdZ-aUO
  Uo-Mwomod1muK4FIgNmnijrbrE7lQJgkAbiUKtlm16Zj4h4fKNnqg59ujtupv6dxS
  1hYEhDKZCMNtUwunz3kgX91S2wNL5B8sfHOs4h95OKJi9UNyvzOHGtrFZyyXu1cbf
  O8XvxSpp2EwqgJOUZL0nwFwK8UQ_1HPk6n6J_MbZ-zanADPMGjpdOUUxPYw5QO16V
  QQ-XinI0hrfv7YHlwwc8578Wg-Kf2sfpdZ3h2QUd3G-FSCgHyCt9Uqdpd1JAPrNOM
  eTplzJ-MDMhi6wTdUvY1O3GhZPJWfLtUtZthcQkrmF5yrIkmSdwQzziRR2FibF9Vn
  YfjlHL7AEBwfEoFV3QBTTMxEZQYd5-CCHMUIB32Qq25uihYPJxdswF7_7k6cxX0E0
  FvtjCbiewiPwXyZNL25w20tnFVZOYdG90CTQ_yaj7YqocH27tSDv9pMuY0f5G1Iln
  6gEyiZHsOSeE_p6J5KboO5uLfGOHMOaCLkNaYtFoB3e7mDnkATCRWZMnf06uQfgwt
  imUhI2JN0XZt7cJ8Jp4wWfzJLbtFH6FMlx8MA1HQrr30smK_gteZkewYvq6Uiuy5A
  DQi6lOqPt2HMxpoLKUK26jSGx9Vz46vjMz-R1XNO4MIVXwnMSxZVK4auHUoNMFbWC
  amTLdH-h18dNqO1b3NIjjC7QW5JImu14g_r3eYY7gr7zRihm6AumYRuPyZXF58n1v
  NeHXfjKUAa-rCfuh5q-vOpc9UvGnPW6ouV7jvDiZURV84prtnK_UltoBV9KvvCrhB
  GoSJvFh-RbfIKW2vaS9AlxBrpe9YbBe07ZZNM2YPkTiljkJ7-_7VDg7rRpRLssnRS
  Y6XHwIEAh7ZsG4weOk9SoZwX_DEJK2svpuGexyelMHHiFU2DDDg1D0zWJQDk2SzFy
  gqA6SO-P6DzZe4N5u9bFcIrM_hRJY7BDV0ww4SkvvYV680C3LI_918m0CnxwaJDPq
  HDa4fhYAQsXEZeHMXF5B8PMqnfeypU1gl3npN3u2phl1jUwBlqFZhwS6X3EnEGQbN
  IJsUhvwjohFWO1elxX2WjRtyOLSrRHl4FFu3S1ZkBvEl5TN5Ho6zu32EQLlI07cw1
  0Gl-dA7TpI7lPMvkcW1pEEBWd59iLixBnPSrq1KkrJb-Vyl-Bo05W2v5Qzna_af_l
  J9FHwWatugiKb18QyFrhL6Kjo8tZScGjadDUdlwUC_d_r6YJMQY2yX0YBkuei14UX
  Zholy8JpUbLfa0gNs-WdFQCoinq4CAFdxfNikKlSVXPnF_sUEtKZiDG3SQ8jBOC-K
  6YrT3caFRK2K0_wyhHC7HzooZSk89DR9pG0g1Kx3LE_E-6H38fyPOD-Y38JfmMa7w
  KjYhYNuYF1LfgD5dGk29Azq8KIHII8il7V82PvFKJt9RodreotvpGkEk56PxN27UX
  fIQVY8XgnsEbWWkmICPF__BEzDVK_6L3EJzyHMNGQMb9jwmVnklorDvv2KlxOMbCj
  pXlRg47-KcKxmqv8Kz_TMYs2HZVaHunrLsJRqIKTABXROVKl26sJXoV410cvMtb7f
  Z0a8_Nif8Hogvg30JaXg7-y88gbq87ZeYF5pLqjHQXO-RNrFZZWXZKOwhl9pk2Hx1
  eu0D1xj87HqPF3RUspLtTf6GSGOhrGURhEsd-Vu9EqkPI_A0FRhYRIAlkIO3LJTlJ
  1lWxC3fcWSdFNI9rHdl4oLzvfHMayRmCpkPRd9cFT7qvZ2ZNFsY84V5bWph1xPvWy
  sgSDXASnfAoaIY02bhuvCe6qaYtltPKxnYQFxisIaiBS1RNqR6gtVsvD0qJPBG1oT
  I-6Pk2yNLILS9U5-Z5hPAR8crXPlz__sOO-aDN-aWndm8IS7H-rODbLk_wg1QfLLS
  HCVjNml7qe21YaYfEgaRoe5lh4NuzXskRKpW5Sk1Yz7sghjv2MSgSj0NgpWkQTfYt
  mUic1RC8isRCKOpB8hj8jgVEiQYoeBmM76fYIBdX_9hehXtEclGwK5_qii-pQ5tqR
  zEqRrd3ULZ4O0aeJeEoNXG74Hzytj9TpfkvU1R5ZHgtnkS97WIe9ACaDBHpvmcYxc
  ou-IAmt6MP5HhbK45FtMteC8WqZQGrhdmCGW0_m7N0R81MJDirmcI9nP9ZRPAWooK
  mdhuiUX8B4XO52r7PpP46PAB9gWo2rh16VapCslRPbYXWxsiOT99RYn_YVBTJaUvK
  mWbELtOWCHY0rQKAO3W-yUlzLZAwX_fDa9P8R2tFdwuzdJ8OkyVWueNjn1kA2_UKQ
  oVTNe5jt7J7JszsKqHJ2UcCi5Oi03u05JX8NKgNajg9VqNpQUrySPmrFg6WY7hHXa
  lgz0icVrKEOtGpJQJtf2neengXBNnO8RedkmiEjETolHc_2h8su_eB45-DBYCXr7O
  qIRw8mMExFvyowMe_MeH7u8kpZX3t8bPD9M46xcOq2RF657j2Yr-0AKm2SRFLFMT5
  n1J0l0Hk2va0TLVv3csLGHzl14BNXIbUhEWVe-Bns3RZflOM74JXS_jqYz419hEP_
  MV3njzmVsTxfSVzMOizoLGyf8dfetSvpSyOXi5AVx8sege_Pp3TLx2AlxpofpVILM
  9a6JCetP4vMdImjrvuIgcRPlaO1NjXZ_lPPlQYKYEN8FLVtPCQJsuM5kPZLGdp9sm
  Aeg-2AFf_oAZ_YxLTitkrfmVPb2so14gWi9i6-ptznY2ffH9UAFRpcAzDz13bRTMe
  43slJvh3X0hqI0XxwSh1jq3pZe7YgOv8z2zsrMoXEN_UrE0xFlDal5cm1G2fI7K5Q
  6nx6y84XKlE93BMZ7rJeUXi9Vu3x"
              ],
            "Identifier":"MBR3-LM6K-JRW2-JWYF-JK3C-SIA4-HG77"}}
        ]},
    "MessageId":"MDDD-KNM4-KUZH-QVC4-KWLI-5NBW-T54I"}}
~~~~

### Phase 4

The device periodically polls for completion of the connection request using the
Complete transaction.

To provide a final check on the process, the command line tool presents the UDF of 
the account profile to which the device has connected if successful:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MBQD-CODE-XMWJ-QHE3-2KHZ-UKKF-TVVF
   Account = alice@example.com
   Account UDF = MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
<cmd>Alice3> meshman account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MDDD-KNM4-KUZH-QVC4-KWLI-5NBW-T54I"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

