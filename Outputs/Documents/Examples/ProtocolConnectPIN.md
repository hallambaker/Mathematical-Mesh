
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=ADKG-ALMU-VUHY-A54X-EWZC-FV3S-KY
 (Expires=2021-12-10T16:46:15Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcu://alice@example.com/ADKG-ALMU-VUHY-A54X-EWZC-FV3S-KY
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    ADKG-ALMU-VUHY-A54X-EWZC-FV3S-KY
<rsp>   Device UDF = MBXK-HB52-35LF-V3CX-ZRBG-W6IJ-G4NB
   Witness value = ADED-F7RU-T6BX-LPK5-NYPQ-7OSD-ANNV
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "MessageId":"NBZI-CLJW-665L-Y5V7-C3P4-NAWZ-Z5CO",
    "AuthenticatedData":[{
        "EnvelopeId":"MBXK-HB52-35LF-V3CX-ZRBG-W6IJ-G4NB",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlhLLUhCNTItMz
  VMRi1WM0NYLVpSQkctVzZJSi1HNE5CIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTEyLTA5VDE2OjQ2OjE2WiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUJYSy1IQjUyLTM1TEYtVjNDWC1aUkJHLVc2SUo
  tRzROQiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIjAxeWpuMDdoSFBiMWE4UFdnVjAtS000OWFIWGlUMTI0d2ZOQV
  VrbFhIX1ByUjNoZlZmenAKICBIZ2hwQnYwdGJIN1B2Uzd5TTFkLTRPLUEifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJKVS02M1I2LTIzWVEt
  TTVBSC1HM1pTLUFGVzQtSVdLRCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiNG92Ty1mLXZYVi01QmZyMXY3VDkxV3o
  xdzVRQnlsamlzZEY3R1Z3Z3VNNG43S0UwNXIwdgogIDdHZUs2Nms4MkZ0VFFsVU1u
  R0ljbFpzQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CS
  zUtTzVYRy1OSzNMLVdMSFMtQUJDVy1DQUtSLU9aTjQiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICI1TTY1ellXOTFC
  TGo1dUhoblZ2MDBEZFNWWHNpb1JJRTR0MjI5Sk04aGhnUHRZNkI1RTMwCiAgSG5BZ
  3ZmVTZmMFpFYkd1dzc5Z2ZxWjZBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQTJQLUwzTkUtSkk1WS1MRUNXLTNQREstVUU3Qy01Rll
  PIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICItYU9FQ1JWdjhEbDVHQ3JDblNqTXJ0S25oc1RHWWJpTnIteDU5LUZPWk
  pOdXdYOWJNRHo1CiAgejBCdFdWdFJaM2I1ZlF3NjZVZEoyaGNBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBXK-HB52-35LF-V3CX-ZRBG-W6IJ-G4NB",
            "signature":"IK_OYVApXb1-GrA7X1cUpu0g2xPfG0Ie247TubqB
  -ABXSRDnqAYqdYSM61KnRXidCIZrHL09F-kAoCyfrGN7yppqSkOI14AbgoYZTAI3X
  5lwi1iMh85Zhqg56aaZ4QRPRJ5icAqR4UiTjYfRajEIPB0A"}
          ],
        "PayloadDigest":"I6SjnDnrXBXD46yMhBpsF3BqG-IdQNrrmG9mYjCa
  eucPfAlA7Hc-cRHq-HDQQ0lqDfMAeb3WgoK230nweWpa5g"}
      ],
    "ClientNonce":"6djDXPYNETRPgWHt66e6gw",
    "PinId":"ACPO-LFX6-MTIP-CLH7-WBLA-F6AB-YQFZ",
    "PinWitness":"_SBmtnwgzp4jthoLn8HYLoFxJdK8OD9vpsAzBDoKMOed_eG
  r91wC517j1MHw7og6_IERQQnMBXmCFruQpc2DhA",
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
    "MessageId":"ADED-F7RU-T6BX-LPK5-NYPQ-7OSD-ANNV",
    "EnvelopedRequestConnection":[{
        "EnvelopeId":"MCDE-WJ4B-H5NY-UM6F-OIDZ-AEUP-NHNB",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQlpJLUNMSlctNj
  Y1TC1ZNVY3LUMzUDQtTkFXWi1aNUNPIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyMS0xMi0wOVQxNjo0NjoxNloifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJNZXNzYWdlSWQiOi
  AiTkJaSS1DTEpXLTY2NUwtWTVWNy1DM1A0LU5BV1otWjVDTyIsCiAgICAiQXV0aGV
  udGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1CWEstSEI1
  Mi0zNUxGLVYzQ1gtWlJCRy1XNklKLUc0TkIiLAogICAgICAgICJkaWciOiAiUzUxM
  iIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI6ICJld29nSUNKVmJtbHhkV1ZKWk
  NJNklDSk5RbGhMTFVoQ05USXRNelZNUmkxCiAgV00wTllMVnBTUWtjdFZ6WkpTaTF
  ITkU1Q0lpd0tJQ0FpVFdWemMyRm5aVlI1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxk
  bWxqWlNJc0NpQWdJbU4wZVNJNklDSmhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV
  04wSWl3S0lDQQogIGlRM0psWVhSbFpDSTZJQ0l5TURJeExURXlMVEE1VkRFMk9qUT
  JPakUyV2lKOSJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V
  3b2dJQ0FnSWxCeWIyWgogIHBiR1ZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNK
  VlpHWWlPaUFpVFVKWVN5MUlRalV5TFRNMVRFWXRWCiAgak5EV0MxYVVrSkhMVmMyU
  1VvdFJ6Uk9RaUlzQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KIC
  BnZXdvZ0lDQWdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0F
  nSUNBZ0ltTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmli
  R2xqSWpvZ0lqQXhlV3B1TURkb1NGQmlNV0U0VUZkCiAgblZqQXRTMDAwT1dGSVdHb
  FVNVEkwZDJaT1FWVnJiRmhJWDFCeVVqTm9abFptZW5BS0lDQklaMmh3UW5Zd2QKIC
  BHSklOMUIyVXpkNVRURmtMVFJQTFVFaWZYMTlMQW9nSUNBZ0lrVnVZM0o1Y0hScGI
  yNGlPaUI3Q2lBZ0lDQQogIGdJQ0pWWkdZaU9pQWlUVUpLVlMwMk0xSTJMVEl6V1ZF
  dFRUVkJTQzFITTFwVExVRkdWelF0U1ZkTFJDSXNDCiAgaUFnSUNBZ0lDSlFkV0pzY
  VdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGwKIC
  BGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0F
  nSUNBZ0lDQWdJQ0pRZAogIFdKc2FXTWlPaUFpTkc5MlR5MW1MWFpZVmkwMVFtWnlN
  WFkzVkRreFYzb3hkelZSUW5sc2FtbHpaRVkzUjFaCiAgM1ozVk5ORzQzUzBVd05YS
  XdkZ29nSURkSFpVczJObXM0TWtaMFZGRnNWVTF1UjBsamJGcHpRU0o5Zlgwc0MKIC
  BpQWdJQ0FpVTJsbmJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxQ1N
  6VXRUelZZUnkxT1N6TgogIE1MVmRNU0ZNdFFVSkRWeTFEUVV0U0xVOWFUalFpTEFv
  Z0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljCiAgeUk2SUhzS0lDQWdJQ0FnS
  UNBaVVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjblkKIC
  BpT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSTFUVFk
  xZWxsWE9URkNUR28xZAogIFVob2JsWjJNREJFWkZOV1dITnBiMUpKUlRSME1qSTVT
  azA0YUdoblVIUlpOa0kxUlRNd0NpQWdTRzVCWjNaCiAgbVZUWm1NRnBGWWtkMWR6Y
  zVaMlp4V2paQkluMTlmU3dLSUNBZ0lDSkJkWFJvWlc1MGFXTmhkR2x2YmlJNkkKIC
  BIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlFUSlFMVXd6VGtVdFNrazFXUzFNUlVOWEx
  UTlFSRXN0VlVVM1F5MAogIDFSbGxQSWl3S0lDQWdJQ0FnSWxCMVlteHBZMUJoY21G
  dFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZCiAgbXhwWTB0bGVVVkRSRWdpT
  2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0lsZzBORGdpTEFvZ0lDQWdJQ0EKIC
  BnSUNBZ0lsQjFZbXhwWXlJNklDSXRZVTlGUTFKV2RqaEViRFZIUTNKRGJsTnFUWEo
  wUzI1b2MxUkhXV0pwVAogIG5JdGVEVTVMVVpQV2twT2RYZFlPV0pOUkhvMUNpQWdl
  akJDZEZkV2RGSmFNMkkxWmxGM05qWlZaRW95YUdOCiAgQkluMTlmWDE5IiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6IC
  JTNTEyIiwKICAgICAgICAgICAgImtpZCI6ICJNQlhLLUhCNTItMzVMRi1WM0NYLVp
  SQkctVzZJSi1HNE5CIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJJS19PWVZB
  cFhiMS1HckE3WDFjVXB1MGcyeFBmRzBJZTI0N1R1YnFCLUFCWFNSRG5xCiAgQVlxZ
  FlTTTYxS25SWGlkQ0lackhMMDlGLWtBb0N5ZnJHTjd5cHBxU2tPSTE0QWJnb1laVE
  FJM1g1bHdpMWkKICBNaDg1WmhxZzU2YWFaNFFSUFJKNWljQXFSNFVpVGpZZlJhakV
  JUEIwQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJJNlNqbkRuclhCWEQ0
  NnlNaEJwc0YzQnFHLUlkUU5ycm1HOW1ZakNhZXVjUGYKICBBbEE3SGMtY1JIcS1IR
  FFRMGxxRGZNQWViM1dnb0syMzBud2VXcGE1ZyJ9XSwKICAgICJDbGllbnROb25jZS
  I6ICI2ZGpEWFBZTkVUUlBnV0h0NjZlNmd3IiwKICAgICJQaW5JZCI6ICJBQ1BPLUx
  GWDYtTVRJUC1DTEg3LVdCTEEtRjZBQi1ZUUZaIiwKICAgICJQaW5XaXRuZXNzIjog
  Il9TQm10bndnenA0anRob0xuOEhZTG9GeEpkSzhPRDl2cHNBekJEb0tNT2VkX2VHc
  gogIDkxd0M1MTdqMU1IdzdvZzZfSUVSUVFuTUJYbUNGcnVRcGMyRGhBIiwKICAgIC
  JBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"
      ],
    "ServerNonce":"qkhRDpSRn2keJNVSsM6Njg",
    "Witness":"ADED-F7RU-T6BX-LPK5-NYPQ-7OSD-ANNV"}}
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
<rsp>MessageID: ADED-F7RU-T6BX-LPK5-NYPQ-7OSD-ANNV
        Connection Request::
        MessageID: ADED-F7RU-T6BX-LPK5-NYPQ-7OSD-ANNV
        To:  From: 
        Device:  MBXK-HB52-35LF-V3CX-ZRBG-W6IJ-G4NB
        Witness: ADED-F7RU-T6BX-LPK5-NYPQ-7OSD-ANNV
MessageID: NDRZ-PHXC-54V3-BOEE-BXHH-CZLZ-6RSF
        Group invitation::
        MessageID: NDRZ-PHXC-54V3-BOEE-BXHH-CZLZ-6RSF
        To: alice@example.com From: alice@example.com
MessageID: NDW5-TTEF-B4JG-BZQN-FNPA-CQRM-3AEE
        Confirmation Request::
        MessageID: NDW5-TTEF-B4JG-BZQN-FNPA-CQRM-3AEE
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDVI-PIPP-B7UB-SI6M-LGQR-TBSK-DLRR
        Contact Request::
        MessageID: NDVI-PIPP-B7UB-SI6M-LGQR-TBSK-DLRR
        To: alice@example.com From: bob@example.com
        PIN: ABBR-7XTR-EMOF-HDSS-K34R-YQSW-VEJQ
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
    "MessageId":"MDMJ-5IUT-VSRL-6IWD-ICP2-P5DN-OHMK",
    "Result":"Accept",
    "CatalogedDevice":{
      "DeviceUdf":"MBXK-HB52-35LF-V3CX-ZRBG-W6IJ-G4NB",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MDMG-5KJT-SFQQ-EE3U-GZAK-CEGV-5GR2",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRE1HLTVLSlQt
  U0ZRUS1FRTNVLUdaQUstQ0VHVi01R1IyIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyMS0xMi0wOVQxNjo0NTo1N1oifQ"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJl
  IjogewogICAgICAiVWRmIjogIk1ETUctNUtKVC1TRlFRLUVFM1UtR1pBSy1DRUdWL
  TVHUjIiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibG
  ljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJxZGJ6TUFuN1lwYkxqTEVHaHphN0Y0Z1dnNzFfVmFReEdsZGZL
  ZlpBRzlFSU1vcXpfNC1OCiAgWWRWRDVGTGJlVVgwbzhQUDVNclNUbGFBIn19fSwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2
  VydmljZVVkZiI6ICJNQjdCLUpTN1ktSVVZVy1US1BMLVk1TkwtSlJQQi1MVFNWIiw
  KICAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1EMlAtQlhM
  WC1KNDRFLUdPSE8tN1dQMy1CQTVYLTJEN0QiLAogICAgICAiUHVibGljUGFyYW1ld
  GVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcn
  YiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIlZCNzYtcmhpUzRsWWVDWWh
  fQjhfbDFGY0J1OGRfcDd6WVJKZkM5bWZqQ2dhMm5LUzZZQmQKICB1a2JTbnM2YXgt
  TzI0Zm5RNVdrRUpkYUEifX19LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogI
  CAgICAiVWRmIjogIk1ESjYtNkkzNi1PQ05ELVgyMjQtRFNEMy1MTURVLTM3WjQiLA
  ogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUN
  ESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGlj
  IjogIjM0TGxkemI5clBRZXFHNVZ6YkhKU2tSOF82Z19IbFk1U2Utc0M5ajdQNUJLM
  k5xME5wUU4KICBQcnF2SlQ3QjMwbVA3QndxQjl3QW92NkEifX19LAogICAgIkFkbW
  luaXN0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTUJRSy0zVTVJLVN
  HS0YtVDNHSC1NVENELUwzMzUtSURRSSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJz
  IjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6I
  CJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIi10TVNLX3VndGkzSV9Qc3ZZR0
  xRUXBNUzhfR0YyTGVjUHZNV1k3UV9TVjh2QkZfZEhxdm4KICBUU1hYTVZQSG9tUW5
  iRzUzRDVRYkVWQ0EifX19LAogICAgIkFjY291bnRBdXRoZW50aWNhdGlvbiI6IHsK
  ICAgICAgIlVkZiI6ICJNQ0VSLTVXNEUtM1IzQS1YWlpULVM2S04tQU9WRi1HSjVOI
  iwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleU
  VDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Ymx
  pYyI6ICJ6MVEwNlh6OXdCQVJkVWpGWVR1d0lqUVlNUTJYVnpjRkcxWkxGM080TGRD
  VG5ZVnVDYlpHCiAgQW16YkdYSnhGSEE1WGY2anRSSTRQNm9BIn19fSwKICAgICJBY
  2NvdW50U2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CWVQtNktCUi0zR0Y3LU
  UzQ1MtSFRZVi02M1JVLUxVU0ciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0
  NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ4cjFEWk5uLW4ybjA0UmM3QndlODJse
  HkwVk1Kb0JDbi1XVlhLVWxuVHRaSVZIRTZmM1FfCiAgYnJyQnhreFFHX1ZWcEVKNV
  9uRTR4eU9BIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDMG-5KJT-SFQQ-EE3U-GZAK-CEGV-5GR2",
              "signature":"Yzes8MOreJ6tV30tn3pmk-v0-7_ovbOJ_QNWBT
  JrMOtkiRZY5muNy3AM8gKWaz9C4ZP9gjcDbXIAhLUuQZxZE62f47N_MrTXjrfl32k
  gSgvLhUcGD1-DGniivMMaWiNPmWvHwCjx9egFJAydGdB_1zkA"}
            ],
          "PayloadDigest":"Vo_KrkSpR7lGIG1LO_Vml6xvyoNIYj3RMUJsP0
  IkELelk_wdzin2ko6Ka2Aykg08GhaWR_NVeg86OxJUxdbdGg"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MBXK-HB52-35LF-V3CX-ZRBG-W6IJ-G4NB",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlhLLUhCNTIt
  MzVMRi1WM0NYLVpSQkctVzZJSi1HNE5CIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDIxLTEyLTA5VDE2OjQ2OjE2WiJ9"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1
  cmUiOiB7CiAgICAgICJVZGYiOiAiTUJYSy1IQjUyLTM1TEYtVjNDWC1aUkJHLVc2S
  UotRzROQiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdW
  JsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICA
  gICAiUHVibGljIjogIjAxeWpuMDdoSFBiMWE4UFdnVjAtS000OWFIWGlUMTI0d2ZO
  QVVrbFhIX1ByUjNoZlZmenAKICBIZ2hwQnYwdGJIN1B2Uzd5TTFkLTRPLUEifX19L
  AogICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJKVS02M1I2LTIzWV
  EtTTVBSC1HM1pTLUFGVzQtSVdLRCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjo
  gewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJY
  NDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiNG92Ty1mLXZYVi01QmZyMXY3VDkxV
  3oxdzVRQnlsamlzZEY3R1Z3Z3VNNG43S0UwNXIwdgogIDdHZUs2Nms4MkZ0VFFsVU
  1uR0ljbFpzQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1
  CSzUtTzVYRy1OSzNMLVdMSFMtQUJDVy1DQUtSLU9aTjQiLAogICAgICAiUHVibGlj
  UGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgI
  CAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICI1TTY1ellXOT
  FCTGo1dUhoblZ2MDBEZFNWWHNpb1JJRTR0MjI5Sk04aGhnUHRZNkI1RTMwCiAgSG5
  BZ3ZmVTZmMFpFYkd1dzc5Z2ZxWjZBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6
  IHsKICAgICAgIlVkZiI6ICJNQTJQLUwzTkUtSkk1WS1MRUNXLTNQREstVUU3Qy01R
  llPIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0
  tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB
  1YmxpYyI6ICItYU9FQ1JWdjhEbDVHQ3JDblNqTXJ0S25oc1RHWWJpTnIteDU5LUZP
  WkpOdXdYOWJNRHo1CiAgejBCdFdWdFJaM2I1ZlF3NjZVZEoyaGNBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBXK-HB52-35LF-V3CX-ZRBG-W6IJ-G4NB",
              "signature":"IK_OYVApXb1-GrA7X1cUpu0g2xPfG0Ie247Tub
  qB-ABXSRDnqAYqdYSM61KnRXidCIZrHL09F-kAoCyfrGN7yppqSkOI14AbgoYZTAI
  3X5lwi1iMh85Zhqg56aaZ4QRPRJ5icAqR4UiTjYfRajEIPB0A"}
            ],
          "PayloadDigest":"I6SjnDnrXBXD46yMhBpsF3BqG-IdQNrrmG9mYj
  CaeucPfAlA7Hc-cRHq-HDQQ0lqDfMAeb3WgoK230nweWpa5g"}
        ],
      "EnvelopedConnectionAddress":[{
          "dig":"S512"},
        "e7QRQ29ubmVjdGlvbkFkZHJlc3N7tA5BdXRoZW50aWNhdGlvbnu0EFB1
  YmxpY1BhcmFtZXRlcnN7tA1QdWJsaWNLZXlFQ0RIe7QDY3J2gARYNDQ4tAZQdWJsa
  WOIOcwXYnbKIJn0NtedwUinwK1VnRFn7oBMsIgIRM0dYCA7FL9PADZIslsPcHOK2W
  ryefSY6DuO7XBWAH19fbQHQWNjb3VudIARYWxpY2VAZXhhbXBsZS5jb219fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBQK-3U5I-SGKF-T3GH-MTCD-L335-IDQI",
              "signature":"3z4SdMvEokOEbpiSvVl9c2fkCklui2E49Eeuhd
  LfsfrRKGYTmJVz0_7P48NhAVoVhKWX8Z3qwosAFVRT-7W20hdEnNihpeAa5zCiarx
  Nb-zizVfZz95NKLoSom6Ef4B386TuWTT5NvBXZfZnzjazTi0A"}
            ]}
        ],
      "EnvelopedConnectionService":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTEyLTA5VDE2OjQ2OjE3WiJ9"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tA5BdXRoZW50aWNhdGlvbnu0A1Vk
  ZoAiTUNJTS1TUURHLU4ySFgtUUlHSy1FSlFULUpOSkwtWEVDSLQQUHVibGljUGFyY
  W1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1YmxpY4g5zBdids
  ogmfQ2153BSKfArVWdEWfugEywiAhEzR1gIDsUv08ANkiyWw9wc4rZavJ59JjoO47
  tcFYAfX19fX0",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBQK-3U5I-SGKF-T3GH-MTCD-L335-IDQI",
              "signature":"36EMWDu_ofUFr2GYgTLounW1iedgZhkpZa6JI0
  oL1pb8mzxumgDTd93nwf0RnceH4wMOCnVXce4AiOnJjypuned_yEk9GmS5F6W3pPq
  ZE-B_Ss6KKbzOia3Np95TfyBVVHmzaLlZ-C7ETS33oKBl1SEA"}
            ],
          "PayloadDigest":"zL6tVjTCXS_UNxJWaT_Rvf25GoaONdexSFx95S
  UB8gj3aFwkdgx8iO5q16rUT2eCv7qPu-R3BeFXBlkLHNSsYg"}
        ],
      "EnvelopedConnectionDevice":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMTItMDlUMTY6NDY6MTdaIn0"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0DkF1dGhlbnRpY2F0aW9ue7QDVWRm
  gCJNQ0lNLVNRREctTjJIWC1RSUdLLUVKUVQtSk5KTC1YRUNItBBQdWJsaWNQYXJhb
  WV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibGljiDnMF2J2yi
  CZ9DbXncFIp8CtVZ0RZ-6ATLCICETNHWAgOxS_TwA2SLJbD3Bzitlq8nn0mOg7ju1
  wVgB9fX20BVJvbGVzW4AJdGhyZXNob2xkXbQJU2lnbmF0dXJle7QDVWRmgCJNQ0Yz
  LUJHQU8tSVpVSy0zS1hULUJLNEctQ0tSRi1SQUNRtBBQdWJsaWNQYXJhbWV0ZXJze
  7QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0NDi0BlB1YmxpY4g5wV4x1cRFbE0J2T
  FBzwfhCP-UmBY8an4swp9fAS7kmzyGkS0NQyY7EhPlj6UhGwfPo2Vn9Bjl38iAfX1
  9tApFbmNyeXB0aW9ue7QDVWRmgCJNQUo3LVNVMkctSEVTWC0zVE1HLUQ3TzQtVloy
  Uy1CT1NRtBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEW
  DQ0OLQGUHVibGljiDlG8htI3hZQNPfu7j3QoBS_TOfK8JBXjlLEQrBasKahjii-pN
  hA5nmxTbHp21nFaU1XS_Qg8bYlcAB9fX19fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBQK-3U5I-SGKF-T3GH-MTCD-L335-IDQI",
              "signature":"Z-Zr8XCKfQ-T3LalZAzZJgDnA22ZSmh0Q37Pgf
  C-pAyMcHhEdR3_d_cRivaUd5T5glKLUNl853EADNt55NJtAVbr9L6p1DRAmmQZ3kb
  uxoJQ6qXeL9WT44sBZykVZmkZhgcfABJSf-fXBF3Z56j_jS0A"}
            ],
          "PayloadDigest":"exXhfUf0BoqP_V_o8TgNRqdURVdMZhLudgxqDl
  I0DNC0OkZsOIymJ64m_3xIDudlTWZ_rwXt1k_OGyOzvbhBag"}
        ],
      "EnvelopedActivationDevice":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQA-EJ6A-VMLX-S27Z-TU2R-IBBJ-64EV",
          "Salt":"1RBJSGOJnHlopHHBO7FLZg",
          "recipients":[{
              "kid":"MBJU-63R6-23YQ-M5AH-G3ZS-AFW4-IWKD",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"jjs8EGz1LWdMb_0aTWVnONRlSyQQXlxf5v6-u
  BEi0FC8q8O6Z5ET0jmRFej3sSxWEuuClGX5B48A"}},
              "wmk":"P4eRiGv699XNLihkJXqxs8FajusfZKPfKD03YJLDdaIg
  B5JDulqrTQ"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMTItMDlUMTY6NDY6MTdaIn0"},
        "mMUK5xCk9tRWRWqstpF9XTNKEFy4FUc9H8hGd9JZlMGtKPhyMvi2pWGe
  HbXobwTXcIbkbpDWzyyAhSzILrIRhZK4YarPyfH-DsK3zQ8onqjQ31p4Hw5-IfrB5
  oZtS5kN-l4_adRaDQ7hD7-KhNAqkJ5zqM9qjnPI_tuEibrkTwH0IXyGaxMBV1n7vZ
  NgQDgQDMjpeWS3kUG28ELQHw8NsUJWUzmkwq3sfRCTn61LzjIgkM65D5R6q7TkOUE
  L3Ur9",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBQK-3U5I-SGKF-T3GH-MTCD-L335-IDQI",
              "signature":"ilaVXmQCPVz0IOxf-N3tZrU0879xG_HZqlO0ra
  _LSU3axJaxkBS22ajFjMUz_w6t1dYOHc5kZwUAZryCBcJGuFRqGrysLgoP5Cw77Ex
  JRKFamt1LpsHYxsGfKugzx52DJXMZ7uQHnOxgDnYHzWhygg0A",
              "witness":"OWn8LNgztxm0J5HhAD-2STxorqfVDkrViSBPncu7
  TKk"}
            ],
          "PayloadDigest":"Be9rEJN9Q6fyzcdroaToP2JGoip88gS1VBxc0Z
  oPRfqqYJ1Iig6p0kh8LGikhGbehl94vcVlpiGGh3WKJ3L_7w"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQA-I5XP-5ING-PZ6L-OU7C-YW5Z-BNKU",
          "Salt":"KzDQPPsSS_wYsr74b2neCA",
          "recipients":[{
              "kid":"MAJ7-SU2G-HESX-3TMG-D7O4-VZ2S-BOSQ",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"jVot0zrDdU1jTkU5L7nAQJpvarRKA4BEInWCl
  n9ADRRt71l11oxSoaosHVfs1x9hEnO54iUPNHGA"}},
              "wmk":"B0IMAGiPGDkmnl5j5hc7h6UY74m1lEANvj5X21cMNrFS
  H6pUVB9gFw"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTEyLTA5VDE2OjQ2OjE3WiJ9"},
        "6zMec_c_3BNQMVBkMLPl0TCB8FiKsVbFB-iWhmyp_fM77wIB0uvB_Rt1
  yMpOMiiXi9j_lnsV7VK9avAaRa7vMPDugkSpleRWxyhymYN0LDMxmLagGi-BMbeCn
  eRnt6nm0Q_nvk6HH_C7UIAf6k_Xz9IqitGMF5S_UzRoCkjMUVXncDV-y3VUI6AGQr
  uQbqkr_f0uyQimUXq1fbPCoYEtY9kwFue-1zdPiJqeLRLaUfSQquFT7OgHQHlZPak
  vVZ_hw6ZmI4BTzbd68VpwEIxSw28-w8DMwFwpZVzrmCYaDgGfNd7sIP2M5T1WA8Ed
  0THQk0YqM5lso1N2_WGCwAWNMuQ0D26j0Oceu2nIqnvwFhcHk2Vloa6mZWTDJL9Il
  huMqXy7Y6OTPLmTmXeJpb7d5VwquvJ_SJVNISYGImA3ePN0lblkCIZkCoCXQkwguo
  5u2cpMYSjB5NvLZLOe-oFWCu8bra8bXYopVCpt1FpnXAOxhxULFRIE355chyKWMY_
  eguK-8mhh4wOlAtR7_bhCD5UEzHOJdmedLkbX-AYDkF0nJdjGnDqTWiJqaxSz85Gz
  lwt5jiSZMYUB-Rd5nnFr0hah2-Sw9d3zNLCJtVpIYQNb1LE28fIQK8MmfEEcur5bX
  VaX-PkJfywlaRxaOWI-JUQMJW9RhzH0EUfdPffnNxmVFrigbdzXrSjnUfQbY2DPJt
  kQE75gljFI4EpCaJ_D63-yePT7wMOFmVtj8TmBcKI8xY38lK9Sr44jel-mN4SnEuN
  kM55MM5NXNJ2m8vXewmqVM1NbfZ-TJKELxj4w1tNA6GD_Mf1-a4Edpg3qRvw2KsB5
  72HX-bE8p3BJAaXOPH5rRgN8v96mcUFNYvxtxZ7wbNwbCUxOGxGcvkSY_Ll31BW6M
  7zz8gD3f4PF4In1bdyVf-3ZSXwZ9HawrlXddzroywVeYVnM8f0bdU4yTkT2fxkf0S
  Y-uII6kfH2dhEXcxsAz7diESot0qDwo7ngHXTSXbO4dP8BwDgegEg5OZfrjSnTOCF
  WmsGKkFL0TKVTI4oTpku224m4Oi3bLlcwb8TmwZ5m60eBHXp6eiN1i-aUEVdX4R1v
  Yd2ChUO9RaSN3OPhBUx8Old9XP2n6PSSRw_jLmexeJdYQ2RHrkIWop9lPZsPTWIjo
  hppvjY0YZe0BQzKHwSxWITj-Q8EKqVcGgkLvTzo8Y4wH2DpTH1XhHNQHDgqz_jZOH
  5Vzmgi9OMPAiupaq5_DLOUUdDHDTV6eQfxRdJ_ou8aQ64erKeiB4EPuJZuFE_Xl-q
  sR9Lx3sfy-QO3c0LjTnQtKQsWRsONek5mR6sNqTbYpoPiIarK1oNSncCST8v5q2BN
  cYN8USliS1aVwzgNpfLX6FigfJ5imxj7-WCsX5crta1TUqMgCYtIBmFc--zOfUK6n
  rBbHRienU6CMrMTSWhA8AMhtQGt6pV07tYBbp5p05kRHN75DPU4JG_WCMhhwHFk8Y
  WoevqZz0twwbtZf4WME-2Eq4ELSk_7vN0HwNpzc7zq-byVg0se-gFe7qVM5U_s4Xx
  KKwgJ2DTadvUYzdGkVOEbRV-f5rzDE6loKGRdMgiZqyQ6Q_ebU1pUTsge8606upGQ
  emCCazWOKn0JyUGJwSoZybxJby9oEJARBqYr2SWlfMpecpx39p_Nl9rOmYkEGOG6S
  RFPEk3rGq34Sf9Y-RlfL-bEB5E7bYMFSB0hbPGvB-9YOJt2TTli8NvWR-tuxoyBTp
  w5ssC13YzR3cB1UfN1sw-i7Zwzz-MZAXhsJw1zMLDxmVioQDYnVUMNPc9CpG3qp1o
  bRBSHO3csn404t5EIMWVhPpm1rFs3T49dIkIDPlxI6Ax-KkqFTVoFjFyp3n7VpaKI
  1FHO97I-Ziv8QvG8RhXwpjANMyT6ZQVE8BdFhgA8tqEY7HVKezm_Fv769kL1Z_pa1
  kmI6NrjLlD3LMAoGUUDMcyUlRCt0-bpY3FcG53Sp-WLsNu62Q0LHUWaL0gR3oAQNr
  MLRGSianW6qldtetnxv6-iPHg2KvJcVhmu6GBg30bGHIQj32UDvBhjTm1nftXkrX_
  G311u1XJwOwej8L7wI9eLT_e1UNdEOJ-Tlp3POaGq3ASZazjfS8lA52hRSSjBgTnI
  I8mhIEAy5d_mPYiSKU0JI3lakzZzb2ZVSRd-0XVbFvcF5H6ACHhwg-GH0PkdFZF-r
  d68mAqCI_zXLsXepk8gbtCct_NbzwNaqoXsWgxl0-Y2ydPg4ywwoMUiZpJATRbBo2
  tLAt5XZgV-Mtoz8EMKdAFpoJcLnHHcGHqkqoM4N35LqWusTylDd9sN-iRirHE8pvc
  1BM-TEADKtBniiJBYxKjfUOSFinhF1lc9k2G1F3uQPbkGc3DicTkHBxA8bcoYHvWs
  6CHrQtExn9m6AP-tQUU2CZyJFi8hQmu8FGvdWqejvewPMdpviH8cyvQmVZuN7I9Tq
  HjCLO-RZBR3_FXeXVuKg6pj0_vx5RfCMiiRszz5DLV2ufGdQF2bp1eaGX1eoZK310
  7ewjOIIz-qkTV5KF83JODcdaWEcZXE_pl-LtF4IjdaltFLb4q0Tq1G09-PYD1fNFD
  OqpCeqhuKfXA4MbUPaQieLyfEgAvEmEyRi2i_Yzt8ROhm4BlNJUHtMN1sMxq_t0gl
  l-sbeaIPvpN2kebPoapBLhMqk6L5Pkx9N16I9vmsl9H005piH7A83chrbBQAxKstb
  ISbyzNqpWW8IgVCgR7m2IM4s3XsHmoiWkbnoYVE0hVGPwUUfsDp1wkiaOBzJYU52j
  iu5jzjgp9sQ26TiTAA1aJPZb8_ER5O_5YF6gljS9cQ41ZJVEdCjLBanRwqhIhHsoa
  X7j5UxvZdnryahqY3M7PMh8gvIRj3_2oPj53Cr_85vvqu98Oz_IHJnaENTu42w8hT
  oZalZVOpSdoG_zYbJUQ4DDVcbBGl_KcJ5SzvEI20nT5gXYJe1PuVxaYGDUdosYOdY
  ju7FJVcUthgLRgQXU0IF5_iAqq0KV5NCKy3g125mYxIsmMA-91pfuIfCxLK3dOmnp
  OqmrwNWDDCLywovrPNadOs5JywqjAMN4rvvRT3VuvV0Sltf38T1CSZK3HlSdGp84Q
  OsS-CT73WbkfF_etfWubd8SK-oSevauZeuveSGPU-JSS4WVoMpH_vw54o0TB4_4Zw
  jN5qIhzN-h11N5_jPboJmnmUw4wPqUlgB3hP4BGQhwWu_2IT7YCfFXMehNNz58PRQ
  ZVEtYbUdQPmZB6capuea75NGTSryD2V7f2xAfdQhu3HKTzO6g4RsXIyM9k-rTNFBt
  uz0VcYz6s8p9EVYQcnYf6CCQdiHUlPW4mw65VL-KOvE9AEL8L8PScwLYIIs70mA82
  -V6PvGonppGs_l5jv0MoFcqCiSvKg2BVr4vNWw7mXqL4u2UybpI69iG3g9lMOmXuN
  qPqBbLofaqZX3oB0JkV3unbNJugnX0MmYF22mwplwmRk9tld2o_sgttJbLTr70UHT
  -SbwKrPPjyeGTSxAwkwaN-yJ2KJj9P2xUk_b06xCjU5tOUq2uYDtsG3Z0GASe3Ehm
  BfalVJTqEbsEWh4IpWOOBdh0vgM7ciBGuz50WUckv-1CbtmysHvnq630m1vNq9vsH
  vBX4AhBH4xp0YiIooSKkwucm-sAeIllJ_Rao4zcsnpQKeYTaLGtE_7A2-ilPk8Rtb
  qgha-MAvCr1stJJAlwkHAul10XGW1iVLhSGZzdYZEe5vshvfchHGpwUH_FM5YCfJ3
  75ILL6YLWiqzXkiw8686rlsvkH2663qAAkuCeC9wsCcD9kWqrSZcRGkpLD6xT74DQ
  iT-uWiqlq5i0-CVcPU--n6EOhJQuYn_ZgPubYrCVMO0VMzXO4zv2zLuuoW_79UGve
  rtgUSm2CKd2cEcNqrurFf7-I7AcLVKYnfefq8BcjUNGpDizZWJpU1R53RrluAATRQ
  TLbFTuauALZSbFGfV9HJedp_cxLOuEW9we6m8vla1UDeMR-fdmuA8IW9XJPqBaGde
  JOZ11eXx6IL8f-d8EMDAIRL2-mqlhbKAtfzg1CpG5prvyi9NwmnQjjjM2ubJ0bDWZ
  J9hb4vdZFmE9fTyGeP-XpOUJVF2QKJ8VgGj1Kd7djYs-GgAazKBTKQ8tuwApCO0tR
  kfNtqJk5Z3VViu_yCAWk2rGv8Js_4ubcrqGlZL5UgzhEs6IrMGs_uaUlIUrYU0qX9
  NXmcRPfQn59ivBX1QGMrsM5m6ildvvGnxBPsY7Y-tqm9RposVvr3iwbmASbiKpb4C
  -AOfh3nzCefaZPvZohpxGuUyeSP2-Z0Kmgh71-g3g_dE4g8z7kl2nn6Sz6BdE7esd
  wuXpnTDkCIMGyATRBDU1fSzE0Y0CBqqJUtTRYxBhHaHKUxqYjvF7HEDUsn5SNSIDz
  1hQsmXrUQxe2aecCvEhcWBe9zpcLf45ehBewugk70rzI6kQpcCMSi_tXgM4J3Le8A
  agx_zYITskTIo9Rho95lOBbEnh7KwVysEhyy4uUUBbm5Bx60wJ_iqipQXeUcu6eAd
  9SMXa5JOnb-aNxw8m4CDXqY09Hvmb6MPJB9tLoH7CeWQIKYYDaa9fxgOvPR5pYDmO
  84CWErbtl6wLf9R1YV5EoK79TxVNQ_IJiNiM2Y3jY6aog1XuexibLRE_VsSfEqQks
  F5CKr_XwwIfL4CaZmHVkbNOxXbe5yZNa3wzzuP7FdqlKLoTq9A24PQNyAbpTdak22
  6yc0GNexBgcfJo9bMIdsPfoYJwiq8pQ34-j6wZXANMcpupJCF4MzwH-qybxs2RYA2
  j8v5lP7BYEtbUlDDOhO_W249Ln84gD0W8y8ys9v77qCBXSDcwDOKoEt-gDOo0RTTx
  e-VNm2hcRdZ_Xrn1tOeWmvOT2ypgiHV0FjsFRV-nJErM675owUqX7vH-6Usm8O113
  UGgpPwHrvDInuXX-bz4fgIJo7nR4rI7dIPrENV8axMATKJBlhbEIH37-e3sxiPzUx
  A7G0PO2jWnfYx38CQzyn0doCLgI_PSG5cxS2-hM91SJGEB-YiGWMlxYOpNASLHL3K
  fZ9_5I7yi_TBN4AQXeU8GVR-S5Mv1Vj-w-YBGvl0FGww3ZIAK-RV0DOd-cXqD_jLG
  LCAnu758UfVH3W3IIwDGKg8Sht3YJwgGRw2x2OJBqWOpxBclpZBv89grfQCWoOjTh
  6mMukgK59mO5P7cowvWr5_nrrydDDYzRHNUHr5Q2qnaooApnVvF44HzLIFe8TSgNf
  cAehtI4L-jHBMahaMw8dG9Sbupip2otd36TV-XNm5PjvW9cjNg4jbDVhBc86yOCZR
  DVaFO_GtDhkF9_C_ty-dlmMTt48BMFE3L6FGoe_BC5lshVJghmG-Ga5fYgEN5ra4g
  f1nPNIMRyPe-L2G8-q5Z1juCsVFiqFs3jPNRVEz9sNsMaRR_BDed1z0opptaHE2TW
  xcL68pdNeosOijEs0RQST9K2tqsAFJkuo8pqpTdcODBA1jNx1c2U8XpFhVO-4LvPL
  zQS77x9Cd1QiIA5dtos-kMaixLep9SDkQokNoonEwZaRAaKfyJfKD6kBoykO2m7wq
  DBVJqx882VCpeNIDvpQmYMGAQxmpJsf2Ypkgaz151fGOrlHaxUVQCIDdDjZA5B7Gf
  DwaOoPmPZnYOlgs8QVK8xyl_uWMGfNSU8wQy5K-WBAY_buIyFYzV-5oomrNOc_oOY
  fAGkdgrrVPGUA-s3coqvDBpG_k6TLxR8K0TrKlEsqURDgu7996jByE480KRUNcwLa
  yDMvp1jQ7_PdVWvwqqIVoXwS6CV5twxFMQyUX4NIt2v3yje6iy4E5zmkx9ZLXSXUF
  cVZkFb0aQ0faT1cOH6yYnt1r6REvKYRzYfYk7unb8DqgelVGiIdcEowlQcQAym2Lt
  Ysuj8Q3llgFbShVQJP56540icj3p3YESfhdNrN0CbwiubxOJA3WT04lIpINvdc9Aa
  XraIFEqIVmUELo10vsdBN24miuIKrNbqTFkU-95Y7DaTYG8Sfw7dtjdgzpVZdOLdV
  wGz5quge3ZusU9aqvEV7JsrdoXR5ShMjJl4bUzkRCtG1YQERRqikDfMKqwiMrquRF
  nGygbWw14ZgY9QxEywIwMyfOmCqafqc75S2RWv_azg4fQ1k7wTjiC6qlpqkm9ONrW
  N_iQFLQXpmsD_DdW7n0HMJ2RFz2RGl0RlsvccG55M1TBsfVn8mETpURGpc8V1dDzS
  gsJzr9vOdDQnMCD1l0bAQ7Tz9A2VabXR_fzsYzdvaLWeR_MquDMegW-X2tqt_r9dx
  StVuw4fSaFZuYP4x2ee4aRQu5TKHHJt4E9KccRDdaEFrm3-ZWVTExzCcxVwsBDAE1
  QQoco15lyGYFQyBOip2WhOS6oLPSx6rxnCVq22svrq_2Xj8db7XTLCZGTfES5dXHd
  -zwUlKmwKNZC2uz_451x0sq5citXhry2lF6BwliVSVGXYUtCEg43JUBuGuvz2oV8i
  0H4Oo6NJlZ9IbMtfdrhfE6Q2tqA1TklWkExlYlV4FVAdd4sBT1daj7QoM5P6xYt9a
  2bh3VPi9ifypZiURSTU3jIQ2_KJwUK5QVDiimFS4UKEWi6ji94Ybac3r8dAh8kj0q
  yLqga285TriDL-7REdJdF30qSUkHwa8z0Bt9sSGYDtzossrUIMbUt_sAzPXFAANuv
  JjvL_QuInRx_pE5PYD1WIyg6-bBYAR_cDrX-IK6ZXXiMBz2g1tVv_rDiUIGz9quZT
  k20DMdAJbSG35TPYZ2IABPQYRficir0x6u_jDjfj0S7P3lp2NaTkmQb9kmYb_zSgd
  Ld3FyrVW9JQITHH_lbOwBHrkhEOeWByHginYD4v2Fgyb0aODVb3xxvI6V0hgejo7O
  BWZX3hI7m227hAAAOoJH4tdGTuLutPkwcSyHY4coNvPs0nTyKlHVxHGGaecVaR8J_
  No7EY4bZX2q3zdaZwl2MQ2apIm1NF0dmO1tjOb6A1c22Le2KoomiVgwaC4gfrAyra
  c5riUtkf9F0zguTTuboB_0J72qufLqK6dH53LFT_gyNzJgrOTI2Wp-aPBsJGZP9zI
  -opuc0ndjkl_DYh5L4K6qhShqK3E4nzlYFIBn9BrmtDWXnrNWrYq1FRVaUmJtAkRH
  9i52GTvQQHYz-rL6zTgad9h5iJaIQAM3Z850dnnp4I_nPNtzcWwyHIz-9lYcpNMa2
  gRMVAljITm4DUhYSnf0wlvFbTqv32JlqO6tvQKtt0r4sezlmh_5cJWHU-qxJ_4RQp
  sHAoeH8Oc39zCCUqZJjEGYyzPWvM5el9Ixic9mNss8bOi_Q4Q-j0cwa9gyntLGeq3
  lV7LHc0HQGm3l_XZwZ9wjmoXypvqznxzneC3pQarDwcdbZdQMEcEFYCpMy5r1i84f
  Hoa_sEJuVvl-crjNnGcuIi-9ufyPtiPqEYAUQN6zvhcoUOglYyIuDSrTW_nTvV8nv
  mIuEJOEoYD014jqVuhNWstOBqWeDzr8kkoifH1Pg1gEXwzsQHE_krWwnJgPOKZNBw
  brpp3OeFiNKWALTR_7VBqfZG_o4uHj4RpoHm_Fw0XgaRA58ul0lr2UI_cNsRD9t0M
  fUPjCY73OdFhrH4EJv7jwg0kqmgpgo4g-PPqi0v25zyEbwZbvpiCt-_u8ua6_m-fD
  yqG7y_-E606-2Otqx6yKKdMWQ_PVjZUi9HxwPg6l26CtwZsw1zv7PaKpHuZ3ehEhn
  mYz1VIbU1yk_R-K0UDgXAyIki2gZNO12nE_I4k3rvYougw-9AQXBfF2cWMtE0Ts-d
  B-ybUKyEk2gbuPBO0_aGTv1JjI86WncImFo_sLTy9wqfHNB1nmO3fbSl3EuYNCmcQ
  WWuvdIAxZmcU1_FqkqwzLz5n2DOnmG8MkVlAtb-ZEuvxwxzfAf0JTcjci2kAh9zzX
  a915zfnQTeuHHcV5Ja8T320R0muY8qBxixJ12tfDO1oY51bwzOCdPC4sMJuonTF8X
  lk7EPeQK2wscNajSC9iA69aOc68I9fMqEvyy0tAwIEcfXdxDVMkX7KY9DSNqrhLxU
  aIZ8urKsTrZvauhj3tLmOL_ai14RjXDA0IujPNcnn3wsEhPhfndFXsU3c8O7_f2PK
  6GffHPuYKXhbfvyNjCvBgFXaTSsXpyzt6bVMtUflYi4KFPs0Ld6BaHlTLPSgZjY6H
  6J3G_DfNeosExXImabGgXUe9AKQtGaf-oyJhH67irAXFTd3Q1jWY3GArKhpi6BM0b
  3jmqkZzSxFZRwaqQ1p3VpNPT-MymMCUlD6dMHt5abR58WZyEA6mKJf7jEvKKyXDun
  NZawAP0LKD-XfbZkLhC5v7XVHxAq1AdowHVB3R0xwGw5ryHjCDB9j71vxh7Cvi3eJ
  3v-4gzR7T0sWl3WjjD8aIuGIOMyOosMtODB2UgbPgoLtX5PaU6_LBk8R-a8G_hxuM
  AvTngVBoJph4mZfkP9Lwwn1n_3piZtE0Pf8BVNPp-2mvrPVofSecLCGdxMiOnPFMI
  FEMVDKYF1H4anNICw17OpLfL5RR-Tli2ic-tlsjX1uiRJn7EErExrI5HTJ5PQH1H3
  lfVw6rmQyS0deB2112JxQ_a9xMmamWxqKWUWh98j1FkhqkC8",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBQK-3U5I-SGKF-T3GH-MTCD-L335-IDQI",
              "signature":"swGqxzjKkEF22y7wgb-3T6kso4T4RyxFwBfFm3
  qKnJnrh4jEVHKC1jIhaiISj-27Hzn0g24cMnEAz6W4gnGGwBXoPgmNckXrjYnu3r3
  O6Y-1rLrukDxwKJDyH_6yeS7g9xac62Cy8KCkCDr0avoy6RcA",
              "witness":"WUCLF2S9Fuubp1Tt6PQlTnB7dezfSOSXj8yJgVPS
  2nA"}
            ],
          "PayloadDigest":"YN9YybU-RBQkBy1BEDw9l4fmyV841us5fuYbuD
  F5PG4CzrWepfQ85wAtAtb2cl4HnG-tdnCOivMc3G66XxKlgA"}
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
<rsp>   Device UDF = MBXK-HB52-35LF-V3CX-ZRBG-W6IJ-G4NB
   Account = alice@example.com
   Account UDF = MDMG-5KJT-SFQQ-EE3U-GZAK-CEGV-5GR2
<cmd>Alice3> meshman account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MDMJ-5IUT-VSRL-6IWD-ICP2-P5DN-OHMK"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

