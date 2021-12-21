
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=AD5M-D6JD-5QGC-YLLU-UM65-2NQX-4M
 (Expires=2021-12-22T13:28:30Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcu://alice@example.com/AD5M-D6JD-5QGC-YLLU-UM65-2NQX-4M
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AD5M-D6JD-5QGC-YLLU-UM65-2NQX-4M
<rsp>   Device UDF = MBUY-BN5A-736O-WRRZ-LJCK-UPZZ-CZ52
   Witness value = TGCH-QM7T-2PRP-44HQ-YAZ6-HMR7-73LC
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "MessageId":"ND37-E67K-PNH4-PRXE-7JXQ-LH5C-5SER",
    "AuthenticatedData":[{
        "EnvelopeId":"MBUY-BN5A-736O-WRRZ-LJCK-UPZZ-CZ52",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlVZLUJONUEtNz
  M2Ty1XUlJaLUxKQ0stVVBaWi1DWjUyIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTEyLTIxVDEzOjI4OjMwWiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUJVWS1CTjVBLTczNk8tV1JSWi1MSkNLLVVQWlo
  tQ1o1MiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIkYzalUtQWNJaDBPYmFKeWFXOHp0ZW1FWEhWZE9vRG5UeWhCRk
  dEVjZfOHZpZFpSWVFLVnIKICBIQlAtQ001OFlEbGptSllHUXNyNUR0MEEifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJCMy1HWUhRLTc1NlMt
  WDdUTS1FNVgzLUhZNEYtWEsyTSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiblRMUVhUMDdxSGp3V21URWk4ZDBfQkd
  NYUVYc3BrcEpUXzhEQUl6N2o2QXJLTmZlZnlSQgogIG82QV9qUDNkM1dwUVRSdmh2
  M1dMbFBjQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1EU
  FItNkNQWi1LNlhZLVk3MjctTFNHNi1VVzJELUdVVFQiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ1RzdmQUprdzF6
  RmFab1lnVU9BVDA0akpxWkdreWFCRDN1NF9mNW9FMXB6M09fOWFfSlJiCiAgMk5DV
  VZPVnV1TlQ2SmRTaHlpdFl1TUdBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQjRILUJWVlctUVQ1Wi1HWUNZLVFQUVQtWFJNSi1ZRkN
  NIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJQX2hyVngwYktqYXNnV3oyOHZKMm1pUzhoQ012X1gtNGxpeFI3ckxZcF
  NPb0dqeUFjOHhoCiAgU0d0QjVRQ2lheUlPMTFBSHpGY0JGYThBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBUY-BN5A-736O-WRRZ-LJCK-UPZZ-CZ52",
            "signature":"Inkj_jB3KEV5YoIInTQwMujrzjZrVqDVJqdrC3xU
  1wUD25Q2Ycocwm74vR3BrdMfoLiMYSmWM-4AEl9zMBv_Jz4Z5lpE9l1_deAGlmLrq
  bhOxydTo_aW_hFxuTBERZ8eIxIg7-CKtGdiWzrSH6GzriAA"}
          ],
        "PayloadDigest":"WZrKPUPmyx2q0yGgKiK1ZtZHM3nqRFAQuhwqX5l9
  EUMC5YSYypzTUQhdT7Lod_BBYP7L32pSVT03nq-ZF9YlYA"}
      ],
    "ClientNonce":"CEEn7T5ku8jQtBf_Z2F7yw",
    "PinId":"ABD2-DGNV-KFAH-DCVA-TU4C-KCXF-2YXY",
    "PinWitness":"mNFl5dc1xWP9bksq2cz2JPegDlQgJaXvHseg-c8Pnmveg1g
  vbJrgncCS5W41JlWrjsHdygJkD75_gaJqWI9iPQ",
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
    "MessageId":"TGCH-QM7T-2PRP-44HQ-YAZ6-HMR7-73LC",
    "EnvelopedRequestConnection":[{
        "EnvelopeId":"MDKP-IBBB-3OY3-G3GR-VV7W-XD5L-7W3G",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORDM3LUU2N0stUE
  5INC1QUlhFLTdKWFEtTEg1Qy01U0VSIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyMS0xMi0yMVQxMzoyODozMFoifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJNZXNzYWdlSWQiOi
  AiTkQzNy1FNjdLLVBOSDQtUFJYRS03SlhRLUxINUMtNVNFUiIsCiAgICAiQXV0aGV
  udGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1CVVktQk41
  QS03MzZPLVdSUlotTEpDSy1VUFpaLUNaNTIiLAogICAgICAgICJkaWciOiAiUzUxM
  iIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI6ICJld29nSUNKVmJtbHhkV1ZKWk
  NJNklDSk5RbFZaTFVKT05VRXROek0yVHkxCiAgWFVsSmFMVXhLUTBzdFZWQmFXaTF
  EV2pVeUlpd0tJQ0FpVFdWemMyRm5aVlI1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxk
  bWxqWlNJc0NpQWdJbU4wZVNJNklDSmhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV
  04wSWl3S0lDQQogIGlRM0psWVhSbFpDSTZJQ0l5TURJeExURXlMVEl4VkRFek9qST
  RPak13V2lKOSJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V
  3b2dJQ0FnSWxCeWIyWgogIHBiR1ZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNK
  VlpHWWlPaUFpVFVKVldTMUNUalZCTFRjek5rOHRWCiAgMUpTV2kxTVNrTkxMVlZRV
  2xvdFExbzFNaUlzQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KIC
  BnZXdvZ0lDQWdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0F
  nSUNBZ0ltTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmli
  R2xqSWpvZ0lrWXphbFV0UVdOSmFEQlBZbUZLZVdGCiAgWE9IcDBaVzFGV0VoV1pFO
  XZSRzVVZVdoQ1JrZEVWalpmT0hacFpGcFNXVkZMVm5JS0lDQklRbEF0UTAwMU8KIC
  BGbEViR3B0U2xsSFVYTnlOVVIwTUVFaWZYMTlMQW9nSUNBZ0lrVnVZM0o1Y0hScGI
  yNGlPaUI3Q2lBZ0lDQQogIGdJQ0pWWkdZaU9pQWlUVUpDTXkxSFdVaFJMVGMxTmxN
  dFdEZFVUUzFGTlZnekxVaFpORVl0V0VzeVRTSXNDCiAgaUFnSUNBZ0lDSlFkV0pzY
  VdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGwKIC
  BGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0F
  nSUNBZ0lDQWdJQ0pRZAogIFdKc2FXTWlPaUFpYmxSTVVWaFVNRGR4U0dwM1YyMVVS
  V2s0WkRCZlFrZE5ZVVZZYzNCcmNFcFVYemhFUVVsCiAgNk4ybzJRWEpMVG1abFpub
  FNRZ29nSUc4MlFWOXFVRE5rTTFkd1VWUlNkbWgyTTFkTWJGQmpRU0o5Zlgwc0MKIC
  BpQWdJQ0FpVTJsbmJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxRVV
  GSXROa05RV2kxTE5saAogIFpMVmszTWpjdFRGTkhOaTFWVnpKRUxVZFZWRlFpTEFv
  Z0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljCiAgeUk2SUhzS0lDQWdJQ0FnS
  UNBaVVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjblkKIC
  BpT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSjFSemR
  tUVVwcmR6RjZSbUZhYgogIDFsblZVOUJWREEwYWtweFdrZHJlV0ZDUkROMU5GOW1O
  VzlGTVhCNk0wOWZPV0ZmU2xKaUNpQWdNazVEVlZaCiAgUFZuVjFUbFEyU21SVGFIb
  HBkRmwxVFVkQkluMTlmU3dLSUNBZ0lDSkJkWFJvWlc1MGFXTmhkR2x2YmlJNkkKIC
  BIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlFqUklMVUpXVmxjdFVWUTFXaTFIV1VOWkx
  WRlFVVlF0V0ZKTlNpMQogIFpSa05OSWl3S0lDQWdJQ0FnSWxCMVlteHBZMUJoY21G
  dFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZCiAgbXhwWTB0bGVVVkRSRWdpT
  2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0lsZzBORGdpTEFvZ0lDQWdJQ0EKIC
  BnSUNBZ0lsQjFZbXhwWXlJNklDSlFYMmh5Vm5nd1lrdHFZWE5uVjNveU9IWktNbTF
  wVXpob1EwMTJYMWd0TgogIEd4cGVGSTNja3haY0ZOUGIwZHFlVUZqT0hob0NpQWdV
  MGQwUWpWUlEybGhlVWxQTVRGQlNIcEdZMEpHWVRoCiAgQkluMTlmWDE5IiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6IC
  JTNTEyIiwKICAgICAgICAgICAgImtpZCI6ICJNQlVZLUJONUEtNzM2Ty1XUlJaLUx
  KQ0stVVBaWi1DWjUyIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJJbmtqX2pC
  M0tFVjVZb0lJblRRd011anJ6alpyVnFEVkpxZHJDM3hVMXdVRDI1UTJZCiAgY29jd
  203NHZSM0JyZE1mb0xpTVlTbVdNLTRBRWw5ek1Cdl9KejRaNWxwRTlsMV9kZUFHbG
  1McnFiaE94eWQKICBUb19hV19oRnh1VEJFUlo4ZUl4SWc3LUNLdEdkaVd6clNINkd
  6cmlBQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJXWnJLUFVQbXl4MnEw
  eUdnS2lLMVp0WkhNM25xUkZBUXVod3FYNWw5RVVNQzUKICBZU1l5cHpUVVFoZFQ3T
  G9kX0JCWVA3TDMycFNWVDAzbnEtWkY5WWxZQSJ9XSwKICAgICJDbGllbnROb25jZS
  I6ICJDRUVuN1Q1a3U4alF0QmZfWjJGN3l3IiwKICAgICJQaW5JZCI6ICJBQkQyLUR
  HTlYtS0ZBSC1EQ1ZBLVRVNEMtS0NYRi0yWVhZIiwKICAgICJQaW5XaXRuZXNzIjog
  Im1ORmw1ZGMxeFdQOWJrc3EyY3oySlBlZ0RsUWdKYVh2SHNlZy1jOFBubXZlZzFnd
  gogIGJKcmduY0NTNVc0MUpsV3Jqc0hkeWdKa0Q3NV9nYUpxV0k5aVBRIiwKICAgIC
  JBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"
      ],
    "ServerNonce":"ZN38P47kiHrRlMmHJAH3Ww",
    "Witness":"TGCH-QM7T-2PRP-44HQ-YAZ6-HMR7-73LC"}}
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
<rsp>MessageID: TGCH-QM7T-2PRP-44HQ-YAZ6-HMR7-73LC
        Connection Request::
        MessageID: TGCH-QM7T-2PRP-44HQ-YAZ6-HMR7-73LC
        To:  From: 
        Device:  MBUY-BN5A-736O-WRRZ-LJCK-UPZZ-CZ52
        Witness: TGCH-QM7T-2PRP-44HQ-YAZ6-HMR7-73LC
MessageID: NCUH-QEYI-3V6A-IQ7Z-6RHR-IPLZ-4MMK
        Group invitation::
        MessageID: NCUH-QEYI-3V6A-IQ7Z-6RHR-IPLZ-4MMK
        To: alice@example.com From: alice@example.com
MessageID: NDSA-RD52-JIV2-RVRU-BY4U-3SAN-HZWQ
        Confirmation Request::
        MessageID: NDSA-RD52-JIV2-RVRU-BY4U-3SAN-HZWQ
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NB37-AILO-UATX-5MSL-SE5J-VW2M-ZIYL
        Contact Request::
        MessageID: NB37-AILO-UATX-5MSL-SE5J-VW2M-ZIYL
        To: alice@example.com From: bob@example.com
        PIN: ACPD-YENT-3EM4-PUHD-D4Q4-4TX5-C25A
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
    "MessageId":"MBT5-5JTS-ZQOU-SDFF-3NQV-OA5S-B6MI",
    "Result":"Accept",
    "CatalogedDevice":{
      "DeviceUdf":"MBUY-BN5A-736O-WRRZ-LJCK-UPZZ-CZ52",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRExXLTNVSzQt
  SUZXTi1RVjNDLUxVQVAtMkpYQi1WWVhNIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyMS0xMi0yMVQxMzoyODowM1oifQ"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJl
  IjogewogICAgICAiVWRmIjogIk1ETFctM1VLNC1JRldOLVFWM0MtTFVBUC0ySlhCL
  VZZWE0iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibG
  ljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJzODUwSi1TUUpINllyTmFQLVRsSElIZGczVlJUSXVQSDR3ckZW
  dXF2Q2NXcHUxYzZPUTNPCiAgT1VTcm9kWUl2T19sQnl5LTEtcnAxMVNBIn19fSwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2
  VydmljZVVkZiI6ICJNQk8zLVlZR1YtUktMSi00SkZELU9RRDUtQkVKUy00R1lPIiw
  KICAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1BS1otMzJS
  QS1UNlpCLTZFS0YtRDNCRC1XSUhSLVVFM1kiLAogICAgICAiUHVibGljUGFyYW1ld
  GVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcn
  YiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogImNKQ2xHR0VQYTlWaXdZNkN
  QWVJHNnZQdk1fdjcteER6M0tEUnRCZGJWcHhYWmx2NE9sWk0KICBxb2ZVMWtQR0NB
  OE9YbVFXdWVRdFB5LUEifX19LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogI
  CAgICAiVWRmIjogIk1DWDItNlk0SS1IVkhNLUpWNUwtMkRVWC1PSUFZLVpGTFUiLA
  ogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUN
  ESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGlj
  IjogIkp6TXNZRTdSSmFvWVpMTkFYMFg4ZEYxUE94bEhBNE5ZWjV3ZFBRSU1SRzNSe
  HVDNnBfZVMKICBWV29DTmoxX19WeGg0T05ScHJhUUh1OEEifX19LAogICAgIkFkbW
  luaXN0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTUNRQS1ITktFLTN
  UWkwtS1o0QS03VVZULU1YWlYtUzZUTSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJz
  IjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6I
  CJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIjk2RUFHQlNiSTlWY18xLWRnTl
  hGVTYwVXhaaV95QnR3R3lVM2E1N3hOX3FqNnlNYVRvSGYKICBxQk5FcGRWWEJqRFR
  sMXV4SGNZeUI0d0EifX19LAogICAgIkFjY291bnRBdXRoZW50aWNhdGlvbiI6IHsK
  ICAgICAgIlVkZiI6ICJNQlpRLVhKN0stWTROVi01SUdULUZGM0EtQUlKMy1ZWEcyI
  iwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleU
  VDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Ymx
  pYyI6ICJYSm40MkJXTENoVFh6SmxDdHhwT0ZCSk5zdl95M2pjTUZHVWJ1UnhUMFVk
  ZUlKYllYODRrCiAgN1g4WGM0dGhDZTg4eGFmUTlqZGQ4Q09BIn19fSwKICAgICJBY
  2NvdW50U2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DNkItUTJWVy1TQzJNLT
  QzNTctQ1VYQy0yTVk0LVVTUFYiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0
  NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICItV2tMTWtEWU4ySHJiS1RYbmdsbEpWZ
  0xnT3VkQW9YdU1QZ1FXRHRZSWcyaVN5RS1KWWQyCiAgVDRELTJsQ3pfSUludHpSRG
  1VRFdoQW9BIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM",
              "signature":"dD4_0cp11gPLnr5BZaM-jICzJC3AjXQvcvVyTD
  __54nYZRkCoH69TpqV4evAa_LxQo9uaAXoeUWABlCuc73jKlTTAKRnviA0YHMOw0-
  BDrKyr_anb2gJn3jCzblGQpx1NkSCjyrTP6FoJbOh6kgqeDsA"}
            ],
          "PayloadDigest":"s7AqhY6q9pCshiJWX285PgQO7pCcA4HeRCD-K4
  igsXRnEvKjAEZMnMlT24fvG2Q9NvD5K5JaeT3ce31CRbsmOg"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MBUY-BN5A-736O-WRRZ-LJCK-UPZZ-CZ52",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlVZLUJONUEt
  NzM2Ty1XUlJaLUxKQ0stVVBaWi1DWjUyIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDIxLTEyLTIxVDEzOjI4OjMwWiJ9"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1
  cmUiOiB7CiAgICAgICJVZGYiOiAiTUJVWS1CTjVBLTczNk8tV1JSWi1MSkNLLVVQW
  lotQ1o1MiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdW
  JsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICA
  gICAiUHVibGljIjogIkYzalUtQWNJaDBPYmFKeWFXOHp0ZW1FWEhWZE9vRG5UeWhC
  RkdEVjZfOHZpZFpSWVFLVnIKICBIQlAtQ001OFlEbGptSllHUXNyNUR0MEEifX19L
  AogICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJCMy1HWUhRLTc1Nl
  MtWDdUTS1FNVgzLUhZNEYtWEsyTSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjo
  gewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJY
  NDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiblRMUVhUMDdxSGp3V21URWk4ZDBfQ
  kdNYUVYc3BrcEpUXzhEQUl6N2o2QXJLTmZlZnlSQgogIG82QV9qUDNkM1dwUVRSdm
  h2M1dMbFBjQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1
  EUFItNkNQWi1LNlhZLVk3MjctTFNHNi1VVzJELUdVVFQiLAogICAgICAiUHVibGlj
  UGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgI
  CAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ1RzdmQUprdz
  F6RmFab1lnVU9BVDA0akpxWkdreWFCRDN1NF9mNW9FMXB6M09fOWFfSlJiCiAgMk5
  DVVZPVnV1TlQ2SmRTaHlpdFl1TUdBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6
  IHsKICAgICAgIlVkZiI6ICJNQjRILUJWVlctUVQ1Wi1HWUNZLVFQUVQtWFJNSi1ZR
  kNNIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0
  tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB
  1YmxpYyI6ICJQX2hyVngwYktqYXNnV3oyOHZKMm1pUzhoQ012X1gtNGxpeFI3ckxZ
  cFNPb0dqeUFjOHhoCiAgU0d0QjVRQ2lheUlPMTFBSHpGY0JGYThBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBUY-BN5A-736O-WRRZ-LJCK-UPZZ-CZ52",
              "signature":"Inkj_jB3KEV5YoIInTQwMujrzjZrVqDVJqdrC3
  xU1wUD25Q2Ycocwm74vR3BrdMfoLiMYSmWM-4AEl9zMBv_Jz4Z5lpE9l1_deAGlmL
  rqbhOxydTo_aW_hFxuTBERZ8eIxIg7-CKtGdiWzrSH6GzriAA"}
            ],
          "PayloadDigest":"WZrKPUPmyx2q0yGgKiK1ZtZHM3nqRFAQuhwqX5
  l9EUMC5YSYypzTUQhdT7Lod_BBYP7L32pSVT03nq-ZF9YlYA"}
        ],
      "EnvelopedConnectionAddress":[{
          "dig":"S512"},
        "e7QRQ29ubmVjdGlvbkFkZHJlc3N7tA5BdXRoZW50aWNhdGlvbnu0EFB1
  YmxpY1BhcmFtZXRlcnN7tA1QdWJsaWNLZXlFQ0RIe7QDY3J2gARYNDQ4tAZQdWJsa
  WOIOWol673n3g_NRu1ycRIQgpM4gpG_oJP2OSBOFhBfZ_QhfCBr4ia5-1AUQorxna
  Hq6um5bCmsUzJDAH19fbQHQWNjb3VudIARYWxpY2VAZXhhbXBsZS5jb219fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCQA-HNKE-3TZL-KZ4A-7UVT-MXZV-S6TM",
              "signature":"DjKJDhUaVmub0KXMAgYwCRui46-JQmYz7vqPTr
  jOHPQyujXmD1yHJ0wyJZWVraLf5tN-yk-RhqMAJajJeFXvIxPuYDRd_0M3K-QiCXz
  HT01MHJb38ViKZTGYWa94gW5NfPG-eAwD4qPoWJc881eHdSsA"}
            ]}
        ],
      "EnvelopedConnectionService":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTEyLTIxVDEzOjI4OjMxWiJ9"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tA5BdXRoZW50aWNhdGlvbnu0A1Vk
  ZoAiTURQNy1LVE1OLU1GTEctNlI3VS1SNFBTLVhQTFYtSDNGR7QQUHVibGljUGFyY
  W1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1YmxpY4g5aiXrve
  feD81G7XJxEhCCkziCkb-gk_Y5IE4WEF9n9CF8IGviJrn7UBRCivGdoerq6blsKax
  TMkMAfX19fX0",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCQA-HNKE-3TZL-KZ4A-7UVT-MXZV-S6TM",
              "signature":"XvkfMC38zzdd1Rw8iglHSTJ5XCLR7XI3s669As
  hzA72wdlMlrLtqyc6W8Lhab791_qyRPlZgP-MA1uIH7Ymd-Wkhv15oniP9DTlSwQu
  7mfmIYEOTvWamfuwUbDoWRTZYLP8WsSpnMD2MZxWMyXSFyRkA"}
            ],
          "PayloadDigest":"lpSX6x3CVg3So-s7krn5JtUloQJX0Jaje_6jCA
  yIZJIBpTa07N3wdJaRdVQqnHIJe5Qk02JU4ad2QlS_p8T8yQ"}
        ],
      "EnvelopedConnectionDevice":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMTItMjFUMTM6Mjg6MzJaIn0"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0DkF1dGhlbnRpY2F0aW9ue7QDVWRm
  gCJNRFA3LUtUTU4tTUZMRy02UjdVLVI0UFMtWFBMVi1IM0ZHtBBQdWJsaWNQYXJhb
  WV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibGljiDlqJeu959
  4PzUbtcnESEIKTOIKRv6CT9jkgThYQX2f0IXwga-ImuftQFEKK8Z2h6urpuWwprFM
  yQwB9fX20BVJvbGVzW4AJdGhyZXNob2xkXbQJU2lnbmF0dXJle7QDVWRmgCJNREpP
  LUxNMlQtTDM2Ri1IUU1VLVQ2TU4tVVBURS02S09TtBBQdWJsaWNQYXJhbWV0ZXJze
  7QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0NDi0BlB1YmxpY4g5nNDqoR9siiHgVJ
  wlhvy5k5vsewe1IZPvY1d4QGGil-KgC0_9S929cEjM91oAibWrVAZAdU_GV5GAfX1
  9tApFbmNyeXB0aW9ue7QDVWRmgCJNQUtULTZCTkotSFBPNS0zU0xELUpWWFctWEFQ
  Vy1IS0U2tBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEW
  DQ0OLQGUHVibGljiDkca4dfG4seP3R8QveZxvRoRMjWjj0fi3tczooUSFvJMGhtMY
  HcTOaG9EwiLsNn4okzPoF6NeAAyQB9fX19fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCQA-HNKE-3TZL-KZ4A-7UVT-MXZV-S6TM",
              "signature":"q7h8JtR6i3P4_kupbwK7An0dMw5O_fvS44a8Bd
  0nshYectnV2rpBJ48bCD7_fe9Jx1U13YEVHm6ARpd-pdluKhNQmphdGX28BrowkkS
  pktlSSuql-nxVPAj2MY8KGloCLrXMgs6j_xGwiFEpYrfIzgEA"}
            ],
          "PayloadDigest":"WDjfF9rr68NJ6fx47EBaKhH8LeVA7IkYBOs-bQ
  UGZM9PCY-eTgmvi2gpwf4iKbyfHta7PhK-mTcWeWVuqDRyxQ"}
        ],
      "EnvelopedActivationDevice":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQB-Y7FD-QEAW-PDKP-JIW3-2HPI-X32P",
          "Salt":"68SYwn1ci5T04wPP0xl-Kg",
          "recipients":[{
              "kid":"MBB3-GYHQ-756S-X7TM-E5X3-HY4F-XK2M",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"AZJpJFTHw-mo59MYHqPzqGqA23bxGBo0Q4S3G
  bKHCCE8CoKY_uw9qJz5Pb1RUApPYNW4DmlJRL-A"}},
              "wmk":"ttuphqQVQwDHq61Uh5e9_JXSYZsyXIffwVAnq48mbOCi
  mpGsgNFGfw"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMTItMjFUMTM6Mjg6MzFaIn0"},
        "i3sokXRflDUrYNJIkmZS-FijliQib-HPRWEaiZzCbJGXGPv9mwtZgs6Y
  RJzGy8aJ9vLhYVVLshI2XuqjRhK7enuwkNp6u3G4p-j0lW99VZyTDN0DD3-HqHHkW
  F5iiG9n-xNQSYf2Tn8VAEF5yPL89Rjyc8U-QamAUUqpcsmLS2OjU_sz04CtZfOuH_
  gxH1RPCEFWpogHJ-yqae-pUt13mkgurqAXRxQPgSxbArr1jaGDiXi7ebkcCgA3K_z
  HpDqi",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCQA-HNKE-3TZL-KZ4A-7UVT-MXZV-S6TM",
              "signature":"hP1EhFH2-2X8BC12xPaoZt2yC-trf0uleM77PG
  ML4NiO7gdGS4oeUTBJB9yvs-i8akP8lsmp0p8A0Bc2u1bT4yw0WNb1GdmE3UO5384
  t-QRxqqwjJmv4qeLnJY2u8OyH1oE7R-5Am-7j7MCcVQhm1QwA",
              "witness":"Vkqf-VHabEWANfk2PZ9d1xo_H9uviiac7S0i1x5T
  voY"}
            ],
          "PayloadDigest":"72LHsY13BgrUqzceQvZ4bY-cbJCuN4eKINV7lh
  JUSMtQLjG6EhGzVVG1UYYxpQY8tKei1duLo8Q-Y5YbYEIVYA"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQO-XTOF-IRZB-PAZO-SHZE-GNT5-C337",
          "Salt":"w_Cga_Y9Uq1IgTtiYy5BdQ",
          "recipients":[{
              "kid":"MAKT-6BNJ-HPO5-3SLD-JVXW-XAPW-HKE6",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"YU9jqhY_ug3vfMfrqCsPjG24uzOpMYYu9Pwh7
  QwNm3RQ0BkCpqnvDL0zY2FvdCpOcfKRMvq3TYwA"}},
              "wmk":"fhxY0_8fsDvtDAzbc9lhRFmF2O4sAINyvWc1u_S_HiS9
  5Zm-vaVaHg"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTEyLTIxVDEzOjI4OjMxWiJ9"},
        "R38hbcn4mJgpQrBgMbD8PQBjRdROMAOpfoTIB7ou9cXYiTMu965TxqjW
  JeLOaxoElYxSpENLGfSQBalmntyFnYEnI2Ry_4fpkk5Y_EaNSLm_u51xUZI-fCk_O
  yhBwA6Zb8e-Y7ky3gkWspgGyeQKIDYbQpfXS_Fhv_bhpcVa2ZLBk_taK2XfOIJ8GS
  hrr6PqYKqf8EowBC3SLI0JL5d97SQVg77i11m4d7swepvqQxQnPneqgRgsOOsfxQQ
  _2zNw-x5NitHZ9kI4dHxbc8Mv2xef9rLKi0Vq7P_I5l4Bl70ISD8viJXG6mjkSeQR
  zjTICffMaS-wsfVkggdqjZK_cN9MDprNlsc6ZOwfKmNR1zOO5GiWsniE0VHs2uin7
  J0TLwZI1yqbku3eCl9E5tkf59w2Sbs-_esBK3CzZA3KNFi58ps7WYGDuCiisPELYx
  RxXmA89TOzOzXgi6iRNfh-geDLAOk0LXaMmhwUYvczWCkslFitw2_w6rvOa9sCYna
  9PpFWqTb3j17mzTo5m4vvxfVS5wASMO5vghtklYh4YwHriSyraS7rU6942uhP0EDx
  t2t_j8c3DfoiJkEb3xrAAZAJ7SuQcMJQ5UrcyM9U2znRUal9t7Lfod3bj5AEtaknJ
  Z8kj1Yc4JpgcmvCysJo6PWodtwV7PiTbOX9S7SXwlB3Ajuw7ONhhSv81Xj75qCFZB
  YfuLNGe34OHbREv_QhxoSHokdmWRA6ZtnDZbwhKoeEatpgruoih8a7E89RBMEcTsQ
  PNI8TtMIq9gE1-7ojhAXsE63pk0RWUs2-LN03F_4KTLuZMApNbsX91dyUCx6aekO6
  o1DZRda3Li0h8rZ_pU3Zt9zAj7VSTLArtMhd1ZtS6do-3T8MtMzC1eH5KJa1do9RJ
  HU8r66iD6goFmIBrVIqppEeonA0XnYiyg7C3BBE4pRrAf617Myh2TNGFeb2pgFYU5
  cjduwZsCl_pU3XQNS3QgeDxYJLja2ZlPgmOSgTZfImabIegoUlJ_h1Cw4PAl1XT5w
  LkMu0udjfynjtGXy-ynM_WsjaSsOOULLl1D4ypMET6eXpdRC_yVmiYO8XmxUoVYrH
  ruoEYlmMKj6yIovOewA00k46-9B5gKot6Uc7XQQMNd1Umzzu_CcVSIiJKUyz_LRJE
  zrv-gRWiF5_vMkZNhlw4LcoELYy5-AO_mQWxrF8kxiNrk7WhksU_a2sMdi3cQz944
  rGSKlkj5QkIZyc1ZE4D4fROMUVKY9epj_ugLn3WIaWte_scGUIANk9v67GTWct0rR
  iY1k-jty4gdxaK5ryQppKQEgCGPfa0sifUq9uyv2fkSfU-II67_LbgbJ-gDiSn9Z1
  HxK5Kh6QPDRd9-X2SKgGNIAW2yM70umpq8C2AgeDDlEs_2Ni9_Eob21JbjavB9mVD
  zvJAFLbSX4ggGxKEhPRWuDD7JB9DnCZwEWEj6DGclA9duJYwSwQE0KShSdgGAhtnD
  QBOdt043OKKHVjLgN98wWNPS74RIfG8DrTePpVVTF1Uvfu0uSE19pwEfISEVJmh64
  gEeNuERRoTAh3EJBGpdUzt3qq32v8e-aesnnQtY7EoKJp24KEa9OE3pC7ZGy2YfUh
  63RJQ2LkLibc1X0A8pMLEIxYOaMIFQPDi4Z0Zp7IfgG8_cD6wPkKOotIj5LLKO0F6
  PhOibU48P_NUUPXr7WxpjSwEL2TZEDTyWdzjAmniy5g5ceBzOSKNNlu9cqDN94jGk
  JfWcL0HvPoGjUd736SQ6E-K7qSmtxDHSw700IfKwqD3rFem1dSuPo8dUnD2xqID9m
  VqPyi0K_N1yGoAP057vLrkOEAg8dWY0uTMQjTQa2UJTc4pY_cG8YZglKa_jxn-78t
  K4JIelYxosc14_QwR90fzbzuboEfpENSI57WLt0LKiUl5Oq6WRw2RLKfLKiNslp4r
  YEcTtE4mL27vM04bM1QOj05CiQQrKLcQnwPpLjFoqFTlkomtdEchv-y4bYSwzx8HR
  VCNpzKcbOOR0N8H_uvMh-10_1OtcoBnRSeb4eT99KW5wnlXM60_uLATUBwmiCZKCz
  QjUmFlVV_HGCCZj842tvY0VfBWXJZy0P7RrUqMZ5AD53hg1icMLbWPsbJl1KctBcP
  WeQlap7yw-sD1hP8mnHUHOF5K9Wzj0NAN-imDWlFs9YnHcbbRkd7JapmMjl8OYDUk
  x-VUJSz_Lwx7DTy6qVbSVoHib73mKkr4Qb5-BNrEUTXQmiTk2TX8NFHHPz5hTOpuR
  UoQ6xdXKmRNqTJX20J0q4WP6K7hhKQkrelGgqirumteE0Gqj8A7KkyzWv6xyLzvqD
  NcpA42hmZlCobQ75ZLMky2qRmUhHphCnqAOCwYJMU_qdEJaMhbCz7yUMmMIAFIN4b
  BzHiM7_WHGd85FiOsg9GMuB8b4kmUaDUJsfxWhnsAIcXgWR9iMd2HxoKhAt8-SkOM
  nf1xjnrZDC55UOJOCtPuPcRf8iIwrLKON0_rk8CmMOAhcYIpMIU5DcbjsPq2_H1q8
  02gSUoahjuQsZvsn4eat93fw45gccY0MtZQoBYvaHRMseGRrjWF36j4kFE8yJA3ye
  d8E3kRfz4PReK1K53dQTNlCCr4nyALIw4oK_U3CSON2PU4Pauvq_c1u3aID1XjAAi
  TuHN2ItuZODAV6pOZGt_Ro2fp_U8NSiQyYyboPDZfnEASTx8KCv2gGqQ5uEY0rjK8
  TuMb7nA9EKQQwP7Rr4MeQlrewHh1jG3AdxtK2Iajth2HZUjbJvp1x_mNdESSCWVHP
  lZTp9steMqCmZ96CmYTs6RiHswNSkJy6PgPiqSt4K6IzQ0rbapfJ3HGDKNGQqFqvW
  IPvOtz--ed93OwUF44iE2cDYUzOMrPx0BZ6n05GMj8L07p-dYrIbnTxvIxxJYvPbg
  JFtRi6Z3H1suKeFfzDlX5-VEtlR0NRTZSK_uofjwFHVWEJ3KK5AX-9_uX-PcrQUNV
  QIyRrHwS9IEknGeodjYyF2GCplpdbE6xdianL-CaxvaCfvcSPgpmvZq_Va0vdgozz
  RItvqHUSnSa8vzGfVHZZcBSTMODIHRnBT4mRJDL_bDYSYXuDHAMs6a3N5149DG1V1
  TOeZZfWW5zYTIvHfg9-_w2sxadYuEyg8yY7v50xMjCQehpxQTn3zS6ik1uTYvAodV
  6Vx_hA1rMgLnTadEM3_o60RrQ-g1iaAVyYnpqvTr-hNm4a2Td698rTwM7qdUqEtEG
  4a9XVgbTYPnVzJE0NWwUPzBxvkJwoFcjntabXIG3B6DExkWqE8Ed8QTuTx02vqFL-
  EfrugwDNNIa2KTLuQ9LdayoCMlHdYVkGBa39A74vtDqqLNwEqgg4u2fRceSi5p9AK
  6WNBqiX0LGG7GSiZ8wL9rQ_rFdk1kEXtxfcuzMg2cGvoadcn25hypsala21yi2EVJ
  19mgWRSvxYzWxXVXPW_cHwQ7XvGamPdeua2wjsN0vsJas843s47TuphY85Wa3EFKV
  rq8P6Y99x4KIqsHVJwo7JG6awxICtMbwmrDhpfWythMWxXo1e5wV11A3A5ObisOew
  j48kvpy3P8CicGeeg9edril4cAwWVwyWz5ZSYfTRfb_2_IlagLNsovvoluH7nEQCA
  ROqTDzuu1dMHDI5ml78IS6kUKUAX-5UQqxq0AtWpQM2lD5uI4CbOYjTJ2K_WPU0zl
  zxCDpVPfluKNVFWKcAhIA11RbWgwAs50bNI7U64VhTOe4vvipZckrUFOlnp-HdLTH
  _dEeB6AFtnkYzk4bAZPziUXnkYdxOUrv2S_Getxfsq6NCRbkfjcE0fr5T96w3rHP3
  EdartuF-DwDOTxZ3zdp9odeJSpr20cZhg5Sm69H-LGc5nFx2grW5WhtS9BK_xnada
  3fPNF4igs-_rvx321Gp9YNSJ8rPa8IuauD1rrGZ557pypKpeeuqUHfdO_mOXBbW8N
  fhPy58pQt6ygz8UexpZWqyvbIoAAKEAMWIQsEgVSJZsnKsfr4yg1HXhAK-M5Yj9Y-
  FU75DPdyWNtBsYKWWFvQOE2PjtfFeyTXfmxpz3N6IMZTRwYLLGd_FjAoSCPpwMpgq
  c0t48Z8onm2cVNrcyIPZbSo6I-YE9_lyE6o7PYcqbJ9RO4g3Al6iV-GrQTGAxteMD
  rNVdwyLk9WKIpKK0pz_kbY61nUgzo52oNqn-1VFTFxzSOOzqc8DeM6usGhMzFATE3
  yUJqT-3vPK_P7X9b6cPfgwp0k8nJC3-4zihQhXQQ3f4lXtFyaGf7c9OUZ4Q9HpixU
  QFzjdeje2RdRlIvYDQirzavj4P0VGEXIvK0SPRQpa5odxucat9Otux93M79vRl1py
  Jro2qWSXVZvNYHuTd0vLYO-pYVeT8izKT6GZ5hnJ6zt3SlfaHKLFLYMNIxBJ_sEkw
  D1MacJ56ElLUukPL0tBgjv4mRJvLmcaO2fwGgYTBP9K6P7_XQDJZ_jt1caX9YM-6Q
  AYk93ekQ4-y6oYdqE2kDGu6s1PiZUZ1mlXk_KNG-4P0zT18qPYkn72bSddJXJYvyn
  dZVuNN5yAj5W-_sLK2-ljC4r3JtAs4xTIoazZwvN0rthkjjCb7WDwipMNRBuwIVRn
  Jf5Ac-F10JExNycaumTwuXxWQXBcQGiLcp2dHasPfyMJPag0vqQLWiB9p20ipsAK6
  OGTQwC3dYhGpitR0YB1y_D8eY8BYyJu-Q3y4-J5ep3JgQiwlv72FRY8DLeW0ZLPqf
  VEQEx52FdPuc4nTbNMAdWxvLUJ3COG_MyxlbWkSr5y-UX1PciOS8GgP9sp5cslCrr
  4WCl57SF_ZHhPN92nplzKe7nX9AAvLY0zPjq54ShjsNYSBQ-6jJOLNRUtUAKXvNJR
  c_XDJZm3L_8IW2GBWIqwFrcnhQ1LhuiRg4lY37kZgMEoX_A4WV0TtM0lj1eQcfIkR
  grdPrvdlUHfgoJ9R_ly5wDJrdTDpkCFk1H3Gc05cNxBwOCZz7DcaVsZgY6kAt-cku
  fS2v_POW1dcVERxf5X58dQR_cxFtoZdIihm-_NToEQil4IjKVQQ8pMPUUiLk57IN6
  PyeYzhA7cTxLndara-uTfX5YSgrdkjkFxpQXn8sqCk27bGGhcWyrCs48cBNZmMvbH
  5sl80cxd-2QKVaE_Yfiq73uqbDDHApHZeBEw9sjjzI1JxUlVm23dqcs2ZFshKmH43
  WK3hwhi4Oj_iWUgCFxjK6WZ-an_lEN-7j27V2-imVOa_JbX0ueg1u7fWediyeuQH6
  Pesy5-qtslBxVcK8GG-KkPZvzXSi7ZAzvVRp2iErpUYB-jnKrNcIRgEq-JJXV2Yua
  kwEGCcvDlSlNPjAxfC_YFrXPQ6lCIMNlrfgfKu4lmFHXcUrnCy3ejLcMZwmi1xr9r
  TY4-ndurI6DOGRWpreE1YX3oR5ZAVG5pWIfe5YqN75P1cdYHrVqA3PPEXk23Q3TuK
  pwEouxYaiYwzEdKz4DzZVxV8b7CB7pISyN5Pb8B1j7R42PxxFJ5v-NINIwGeseMwI
  VDgOpzpLBe9tQbBrWFWOpEtONVqVvOzBgF0D4uUZhBz_RMpXlsgzObwn3Yg6sqNs2
  jNeKLWNSVPu12se7rNuBuZyFKSdJ3aS1yzJplJBY02zyciKCe0YST9a88JWi2KxfQ
  We82TkJS5BTzGTENrsvReVm6CG_y6hRnPOaynPHUFtl9SLP39FceTIzH-gz95Vwkl
  ZEJthkjxXLQwvaxdDUBFm6RD2tMKt6VGS5-Z7nGutWa819mXJGtLsT25EFMOK4ls3
  9Vn6dfNHVgc5s1EB9UqZFY4kwg56qoeid-AXKFJsSXpsYFGMsodBiFoWVjI5ALFSt
  RiPVfVKzKsTkxcsiU4056NtO6AoryK9piA7snZVbnLc6py9Y_Lfy0vrDlDYLGCbDw
  WtWpgf-R6IMt6dgIxJfnq2h3NTBSTMOCYtl2cjnHv8qL5iCEiqHL6UqSzj7D-VS9E
  n59hRHLe_-Rpo8VZkSs3WuoqIGJIKm6wjrOEGK3c-guJjq1-keFCvg4nWe9712YUd
  -benEl7Iax2RTb1QnJkGQwgMDfU7pF4cPNGtsx8XZGuEMrQrpJ5hr-w7lEc0IBPix
  IsZ55iVbe2fThfMxsrJp4Ep54ECvVT0YJAu8s9BZ8rmolYMaJi0U48KK_4VHenRdK
  rwMJZYvwoJQ9_etWVFoCGwDuFPCQW-54UgGlKMnwxw32vWHcb4l51uyLpuoukbUsB
  CGWyv8V-2XnaP5ObtH7PhceaDeDBFBQG6fSnr1f2oFXJ_49KIi_8NaOHOl_s6Zs3v
  MMN2HQz_2bY6agNizb-1G27pgwBAUK4vDCAvpcGpi_jELAGlX-4WQHjCcrAeomDTn
  i_kYoV8WVysZchcvMem2wDu32BRB2kASwE9MYH62fBoYajcMNE7Iw99j-k_qn5RZH
  YlmWGl_IKUd3Yg8o4bVE0qztDEc2j8-ChZ0J07ThaNF_VqQevXoj-nnkmFaCahI97
  X426z9p1BCgqeS_ttFfiDqYY314Tc_8afqu9nd-E_Qyf7zbLideOjCqz9dVkPwLYS
  VM9aWStOl5jiQxfaQuqkD62CnamqhwpLcUM1lB0dPrbRzykswZXRQzm72gt6jKmZl
  ITbM61nqFRdf9zkIPt0HGJTh05S5zam9HSi7jhd6gFhO2jFERllSQSrnSRJuG5tqh
  R0_6MYlt0h291oVPDX7hhVY1eeX-eUc1h82v-onv6YJDEfs7KPu-ax3DzIU7p0MKx
  JAHLE0dhTtfoZusqDTTj9ydrr6UllSfkgfKdSUfmxKbuNFLk0bZ9fgEl2f0EKzSyo
  QSyEK9SKhhxYNkFmSGNBoN9oYRhwjEQ6pEF3TxJwMg9ZKzVjQihW5kfvs64kYS8KU
  m3N7heTRLqIxJC42x1FLe7P-UUR88cea5vjmClCWHEupg71thJ-NkkB072UxWFxGe
  zUmrGbG-7QS3BLhi-Wifll9AJCLQrNPDU18NIzbyxNMHr-nZDGLFj7Zct-9ydnOad
  D5Bq3u2F8LHTgbpg3zvnMbc8P8wMl6LSJmL23Z0xK8bw_9ui4OIt7I4rcKy0yBoPC
  9i71KElxnpc0Yxu_DQtsw6G_uB89Pk9rwq5O5uh0h2ScrEbwmnYu9fiwJfm5YTdCw
  XjpKuKt7PAMlCf3ntYA1P27Pk9SzpxJNYHLnlSWHPWxwahHhsCQbeSG5KiOyQ9Exl
  qIaiQd_iImDwPbOYc1kJcbnkohnokjaVtqwXslViwbPk1ODOZe5H-slkL4_MWXOWE
  NeoRsEpuQQiGGaCld5npFoBOI9bO2bt5ljS_LVeoqNW_8fOihp9_Wj7A7Y5g7mliI
  MQTVBru-3RIfRIGh4YmHXaSYX5HWdOGwrO-LYUVElI7BxqakLUymG2nFCHHtkKeOb
  l5ukoed7BdeqpHyQYmcC1GAB6Bo7szaWZOYDR-kKF2Qw6Z9T_mbezWxpuNzQ1qj3V
  6C3PuA6oHV3C9EFEhbs5cErvaYdERmOAEoX1-Y-fgdTBLZYXMLzlngPDV7O18_fM6
  5rpZkOqpRwv7qhIS-XaBZyr1GtC8ZkBw4P4-O9ovZS-DFmxZTGtQUsFHYOU77iYMt
  7zwE0n4RfyegrECDrQinDDNJ4jrdfbt07BVm7TDcdWY6E7Gc7IB5OmK78ZMPx9PRb
  u_YugvgsXq9BOANNL2r5KaRquT4s-pXzBNXLVOJ7QAUdm_gX2pFpm6eb5EtEJwwE5
  -mERRBKVe89TCpcRe3TpjTDKkHYTlNrCDRKbpUfyaaA-JJGVmUqvPAuFiRmV6rlZD
  7Xoiq9JT9AwEdSVcQwqclsi15bzD-5-yaNVZ5RLqwKdE9noWp0adxOW-gUcu85VeV
  dbNsDrCTKAkQ5vaa9Lij9to6i9EhDyHeUGD2jnIqm2XN8EYGi_DuA8loxB1sce7MH
  lHoJn3Snl-w_eZ2I3WW_M0gULTVkYDLsXr0LeYqOHNRb_rk_rOdrigDaKUQaW9pfM
  GfNOFnpH2iwe1UFcr-_dD7_7Pac-NnHdpEfMIm431Lb4tzECkcZjwW7GF2aE-ZZJU
  yhPJ2YrRdNuIWh9pNy9oHU3qor_FiFkZ3lnmVQ3TiGLN_JarF28j0nqe-_UF7dn8s
  _pjTJQMJmhqMcDjYdsyNGm6luFiLjTPD5MszjL-EhHcjRwaFs9haaLCZgcP-7rjlb
  7bxWjGsapShSQTYVFo1kYXS2D3Mb7z41nSrgFsbAGKBINhZ-Ndoj_Ce90CF-Gu6vb
  isF1ipsIBhxQwoIja1Osi-_7syf-2aErLd0ewtRm_Tm5r65DYzY0OhzvmfbEbN8BH
  8cjhKf6IIVLSTYSFY2g_IzOl5uq2aEUt9BNOCMrwYcwD70pfDMlW4FsQmc6COa1ND
  QW-ZJ3_1VDfK8zaYmcP1uzJLuijxjHefIxjD9FD1kEqAoSwrfMuQUQjQfkFI0GAcq
  sV05GinGenrbTc4E3aJb0gaVGjby_b5aUXXDbX4wGiftvHxXq_wSXb3EWFAEDGFzl
  AYS2krw7X4zNkWUlt_BQdyK0fGmYLHZwzbZ60vnwq4NfhENWMjNoQ15oc5aMD2BaV
  rQQD1DroX_LDqO7Jzgg52Qw6Bmr6tYu6SAc8sfTKWG0jP0I8",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCQA-HNKE-3TZL-KZ4A-7UVT-MXZV-S6TM",
              "signature":"PaLt21-ZnXiAaQ5uSVtx0KKRz8LzB9NsOxb018
  oaBDyHaHLbhikXP12-UBrlp1t60vX8Zemv9UMAo5usaQsSsGlsnCZ0J6_92EjCZl8
  2q9Ei5Q2JX9Yx1o4s-Hs8rpU--cQoMFWek2ezPSF3fLdTYjEA",
              "witness":"ZAf9aj7xZ9RlYfDhHg75mMzItHXrKjN4rZPOVzVT
  KwI"}
            ],
          "PayloadDigest":"rQ--ohEGVoAiHZHbGPHzBJU-oFyH0w3D3cTHli
  Rwsu-IxNd3L3eFTSYa3_HLVkEWZisfXCRwZek9P8YJhx01kA"}
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
<rsp>   Device UDF = MBUY-BN5A-736O-WRRZ-LJCK-UPZZ-CZ52
   Account = alice@example.com
   Account UDF = MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
<cmd>Alice3> meshman account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MBT5-5JTS-ZQOU-SDFF-3NQV-OA5S-B6MI"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

