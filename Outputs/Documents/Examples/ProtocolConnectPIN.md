
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> account pin /threshold
<rsp>PIN=ABV7-7Q2W-UVGJ-46MH-OL4V-3WMY-ZU
 (Expires=2021-09-22T00:47:49Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcu://alice@example.com/ABV7-7Q2W-UVGJ-46MH-OL4V-3WMY-ZU
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin ^
    ABV7-7Q2W-UVGJ-46MH-OL4V-3WMY-ZU
<rsp>   Device UDF = MCUT-PRPW-HDP3-N67L-YB2N-X462-TIHG
   Witness value = GXDX-XNOJ-SYCR-HBND-MC52-4KZL-JLM4
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "MessageId":"NCZL-ECES-YJRW-3OVN-2VPU-4QA5-Z6SL",
    "AuthenticatedData":[{
        "EnvelopeId":"MCUT-PRPW-HDP3-N67L-YB2N-X462-TIHG",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ1VULVBSUFctSE
  RQMy1ONjdMLVlCMk4tWDQ2Mi1USUhHIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTA5LTIxVDAwOjQ3OjQ5WiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUNVVC1QUlBXLUhEUDMtTjY3TC1ZQjJOLVg0NjI
  tVElIRyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIjNvUmlJQl82WG9mZl8wNGVubHVwS2dveml6N2FkeHc1alBhSF
  JLc1RHUEtpRW01WnRnQlgKICB2UksybDJZZk5qUG02VmwtVldyNEgwd0EifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUI2US1KNlc0LUdMVVMt
  TkE1Qy1EU1JELVUyTDItSVA2ViIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAidm11OF9XUmNFTkFwaUlGMUU4SVVIbXR
  pXzlrU0Z3S3RJUDRyVVFyYkx4c0pxb0JkT3dNeQogIDdDcHNHaG9QMERLTFVqQlll
  ZG4zRERxQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1ET
  TUtV0ZEWi1BUFZXLUVVSzMtRzVIUy1JVlpBLVg2TkkiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICI1ZkQyT0FNZVRQ
  Nko3dG42X0NQUWV4dkQ5aU51YzFYYVNnenFsTFQwbUxDOFZJNUZOYnppCiAgb1k3V
  0JINUpEeHNlVEt1WGpodTV2ektBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQ0VDLUhHN1AtM0hWRy1ESVhKLTM2Vk8tTVgyUy1XNVl
  FIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJzZVV6a1lkZFVnaElkb3JQcmpUeFRIS3lwcWlUdERvLXFQYl9BVUJWZ2
  o5Z3J0MzhtNkVaCiAgZlNUVzRqaDkwWWxUOU1ndng5amRwQkNBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCUT-PRPW-HDP3-N67L-YB2N-X462-TIHG",
            "signature":"m1Hp1oYMFIJyOiLaEogZzzpB9wiJjKIai1Lx3AzO
  QmTk1YIKZGQhr-m6K6HS8ayQe9HgGshRtyqAGFe0LN4ZvFAQMcbAIPkinFdJFpl1P
  tHRV4z1xDq_oINwujy8RPjlbelVliGwner_6ozlfRhV5RsA"}
          ],
        "PayloadDigest":"9eyiYqzs-jYpQFCoQ2myKH0D5IkwGMh6ils6haKz
  so9hrNV2WHXeLssE-wiA42wuR0HiMX07d_vkX3z-p1BTQA"}
      ],
    "ClientNonce":"Yr7aUUiIm7avmGKSbJbh1w",
    "PinId":"ACLI-C3TW-TXSJ-LNTE-7YMC-3RCX-5GHP",
    "PinWitness":"kpfFTTbBlRJnaUf4l39J2PZbP47EsTkgC-7yNQ4AV_EP-su
  L8pC-NtCjb3Abx9xkaR-F0uLyL5QxC06uALDZMA",
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
    "MessageId":"GXDX-XNOJ-SYCR-HBND-MC52-4KZL-JLM4",
    "EnvelopedRequestConnection":[{
        "EnvelopeId":"MC6X-3I6N-RRLV-V5YK-SEDW-NXN5-CXRZ",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ1pMLUVDRVMtWU
  pSVy0zT1ZOLTJWUFUtNFFBNS1aNlNMIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyMS0wOS0yMVQwMDo0Nzo1MFoifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJNZXNzYWdlSWQiOi
  AiTkNaTC1FQ0VTLVlKUlctM09WTi0yVlBVLTRRQTUtWjZTTCIsCiAgICAiQXV0aGV
  udGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1DVVQtUFJQ
  Vy1IRFAzLU42N0wtWUIyTi1YNDYyLVRJSEciLAogICAgICAgICJkaWciOiAiUzUxM
  iIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI6ICJld29nSUNKVmJtbHhkV1ZKWk
  NJNklDSk5RMVZVTFZCU1VGY3RTRVJRTXkxCiAgT05qZE1MVmxDTWs0dFdEUTJNaTF
  VU1VoSElpd0tJQ0FpVFdWemMyRm5aVlI1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxk
  bWxqWlNJc0NpQWdJbU4wZVNJNklDSmhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV
  04wSWl3S0lDQQogIGlRM0psWVhSbFpDSTZJQ0l5TURJeExUQTVMVEl4VkRBd09qUT
  NPalE1V2lKOSJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V
  3b2dJQ0FnSWxCeWIyWgogIHBiR1ZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNK
  VlpHWWlPaUFpVFVOVlZDMVFVbEJYTFVoRVVETXRUCiAgalkzVEMxWlFqSk9MVmcwT
  mpJdFZFbElSeUlzQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KIC
  BnZXdvZ0lDQWdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0F
  nSUNBZ0ltTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmli
  R2xqSWpvZ0lqTnZVbWxKUWw4MldHOW1abDh3TkdWCiAgdWJIVndTMmR2ZW1sNk4yR
  mtlSGMxYWxCaFNGSkxjMVJIVUV0cFJXMDFXblJuUWxnS0lDQjJVa3N5YkRKWloKIC
  BrNXFVRzAyVm13dFZsZHlORWd3ZDBFaWZYMTlMQW9nSUNBZ0lrVnVZM0o1Y0hScGI
  yNGlPaUI3Q2lBZ0lDQQogIGdJQ0pWWkdZaU9pQWlUVUkyVVMxS05sYzBMVWRNVlZN
  dFRrRTFReTFFVTFKRUxWVXlUREl0U1ZBMlZpSXNDCiAgaUFnSUNBZ0lDSlFkV0pzY
  VdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGwKIC
  BGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0F
  nSUNBZ0lDQWdJQ0pRZAogIFdKc2FXTWlPaUFpZG0xMU9GOVhVbU5GVGtGd2FVbEdN
  VVU0U1ZWSWJYUnBYemxyVTBaM1MzUkpVRFJ5VlZGCiAgeVlreDRjMHB4YjBKa1QzZ
  E5lUW9nSURkRGNITkhhRzlRTUVSTFRGVnFRbGxsWkc0elJFUnhRU0o5Zlgwc0MKIC
  BpQWdJQ0FpVTJsbmJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxRVR
  UVXRWMFpFV2kxQlVGWgogIFhMVVZWU3pNdFJ6VklVeTFKVmxwQkxWZzJUa2tpTEFv
  Z0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljCiAgeUk2SUhzS0lDQWdJQ0FnS
  UNBaVVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjblkKIC
  BpT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSTFaa1F
  5VDBGTlpWUlFOa28zZAogIEc0MlgwTlFVV1Y0ZGtRNWFVNTFZekZZWVZObmVuRnNU
  RlF3YlV4RE9GWkpOVVpPWW5wcENpQWdiMWszVjBKCiAgSU5VcEVlSE5sVkV0MVdHc
  G9kVFYyZWt0QkluMTlmU3dLSUNBZ0lDSkJkWFJvWlc1MGFXTmhkR2x2YmlJNkkKIC
  BIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlEwVkRMVWhITjFBdE0waFdSeTFFU1ZoS0x
  UTTJWazh0VFZneVV5MQogIFhOVmxGSWl3S0lDQWdJQ0FnSWxCMVlteHBZMUJoY21G
  dFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZCiAgbXhwWTB0bGVVVkRSRWdpT
  2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0lsZzBORGdpTEFvZ0lDQWdJQ0EKIC
  BnSUNBZ0lsQjFZbXhwWXlJNklDSnpaVlY2YTFsa1pGVm5hRWxrYjNKUWNtcFVlRlJ
  JUzNsd2NXbFVkRVJ2TAogIFhGUVlsOUJWVUpXWjJvNVozSjBNemh0TmtWYUNpQWda
  bE5VVnpScWFEa3dXV3hVT1UxbmRuZzVhbVJ3UWtOCiAgQkluMTlmWDE5IiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6IC
  JTNTEyIiwKICAgICAgICAgICAgImtpZCI6ICJNQ1VULVBSUFctSERQMy1ONjdMLVl
  CMk4tWDQ2Mi1USUhHIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJtMUhwMW9Z
  TUZJSnlPaUxhRW9nWnp6cEI5d2lKaktJYWkxTHgzQXpPUW1UazFZSUtaCiAgR1Foc
  i1tNks2SFM4YXlRZTlIZ0dzaFJ0eXFBR0ZlMExONFp2RkFRTWNiQUlQa2luRmRKRn
  BsMVB0SFJWNHoKICAxeERxX29JTnd1ank4UlBqbGJlbFZsaUd3bmVyXzZvemxmUmh
  WNVJzQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICI5ZXlpWXF6cy1qWXBR
  RkNvUTJteUtIMEQ1SWt3R01oNmlsczZoYUt6c285aHIKICBOVjJXSFhlTHNzRS13a
  UE0Mnd1UjBIaU1YMDdkX3ZrWDN6LXAxQlRRQSJ9XSwKICAgICJDbGllbnROb25jZS
  I6ICJZcjdhVVVpSW03YXZtR0tTYkpiaDF3IiwKICAgICJQaW5JZCI6ICJBQ0xJLUM
  zVFctVFhTSi1MTlRFLTdZTUMtM1JDWC01R0hQIiwKICAgICJQaW5XaXRuZXNzIjog
  ImtwZkZUVGJCbFJKbmFVZjRsMzlKMlBaYlA0N0VzVGtnQy03eU5RNEFWX0VQLXN1T
  AogIDhwQy1OdENqYjNBYng5eGthUi1GMHVMeUw1UXhDMDZ1QUxEWk1BIiwKICAgIC
  JBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"
      ],
    "ServerNonce":"7ZNGPQ8TkVolJEueDLrlaA",
    "Witness":"GXDX-XNOJ-SYCR-HBND-MC52-4KZL-JLM4"}}
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
<rsp>MessageID: GXDX-XNOJ-SYCR-HBND-MC52-4KZL-JLM4
        Connection Request::
        MessageID: GXDX-XNOJ-SYCR-HBND-MC52-4KZL-JLM4
        To:  From: 
        Device:  MCUT-PRPW-HDP3-N67L-YB2N-X462-TIHG
        Witness: GXDX-XNOJ-SYCR-HBND-MC52-4KZL-JLM4
MessageID: NCFA-2TRI-LS2C-7PVW-PM62-2G3R-KYMA
        Group invitation::
        MessageID: NCFA-2TRI-LS2C-7PVW-PM62-2G3R-KYMA
        To: alice@example.com From: alice@example.com
MessageID: ND7W-VXRT-NOTH-XEOP-GMG7-TFPQ-RXI3
        Confirmation Request::
        MessageID: ND7W-VXRT-NOTH-XEOP-GMG7-TFPQ-RXI3
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDXM-2XZX-7KJT-L4FI-E6SR-MLCC-QB3K
        Contact Request::
        MessageID: NDXM-2XZX-7KJT-L4FI-E6SR-MLCC-QB3K
        To: alice@example.com From: bob@example.com
        PIN: ACI6-SZAU-PSDO-65SL-5N35-WXIH-DSRA
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
    "MessageId":"MDKA-OBRJ-BZJ4-ZAUN-BVVI-AKWJ-YOCR",
    "Result":"Accept",
    "CatalogedDevice":{
      "DeviceUdf":"MCUT-PRPW-HDP3-N67L-YB2N-X462-TIHG",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MD4F-Z5IT-LJOA-3PFY-5NN2-K4T4-YE2X",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRDRGLVo1SVQt
  TEpPQS0zUEZZLTVOTjItSzRUNC1ZRTJYIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyMS0wOS0yMVQwMDo0NzozM1oifQ"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJl
  IjogewogICAgICAiVWRmIjogIk1ENEYtWjVJVC1MSk9BLTNQRlktNU5OMi1LNFQ0L
  VlFMlgiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibG
  ljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJoNm5NYlZtSDBEdU5KdWlIQTFRZkdkeEhDYm5xTHN2UXZnVm5z
  b1pYeTZpTnQ4amRwZHF2CiAgNWpidW5reFVycjVfbjBULTBPWHNXVjBBIn19fSwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2
  VydmljZVVkZiI6ICJNQ1NWLVhUTUotTjM1TC1TV0dVLVBLQjUtWlpJRy0yNU1DIiw
  KICAgICJBY2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQzczLUJU
  S04tN1VYUC1VRVVTLUw0QVItTFMzWC03WFNYIiwKICAgICAgIlB1YmxpY1BhcmFtZ
  XRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3
  J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJVVDg4Y2dEc2ppNlVSWkh
  zS3o1aHdFcGliMzVibkV3eEhSZ3ZpME1GVGtLbDFfMzJZUFdKCiAgRFJ4U0tOLXdM
  R2FQNmthelRMc29weElBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlI
  jogewogICAgICAiVWRmIjogIk1ENVMtQ0hVSi1ISUdHLUJVWDctVFpJNC03S0JNLU
  lNTkEiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGl
  jS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAg
  IlB1YmxpYyI6ICJLSzZiWEl3Y2dwU1VhWGxGRjlvSFBpcEtxajhDZlpNaFMxbDAtd
  TRjcF93c25YQXhDcE5UCiAgT2NaT2RVN2R5cF9uME5IdXpoaUgxaElBIn19fSwKIC
  AgICJBY2NvdW50QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTURBTS1
  JTkxKLTRZTEstR1pURC1PNkE1LUw2NkgtU1lENyIsCiAgICAgICJQdWJsaWNQYXJh
  bWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgI
  mNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiLTBWQXBrSVVfUU8xaE
  RxOGlkb2pzb3NlRXYxV2cwS0RYdUx5NGJpRUV5Zi1uS2I5VnRyWAogIFhGVEF2ZG9
  KR3MxM2pqdjM3NENqTEdrQSJ9fX0sCiAgICAiQWNjb3VudFNpZ25hdHVyZSI6IHsK
  ICAgICAgIlVkZiI6ICJNQ0w0LVFMUTQtV0dWVS1WTllYLUhVUVgtQkVHMy1NU1NTI
  iwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleU
  VDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJ
  saWMiOiAiTmJQTHNlR2s0S2NUdjNkVUpIRER4MVYzbWVHRHNIX0ZfTU5PY0tINlhu
  TFZFZHRoQm9qTQogIEF6Y2RRUVFtX09OQmMza25qQnFmVTdvQSJ9fX19fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MD4F-Z5IT-LJOA-3PFY-5NN2-K4T4-YE2X",
              "signature":"HAiBHtxYEWStqyBNUMasqDH0oHl6YOJ-UhcaQ3
  ac0nt5wKu0lJoQUvRvVxfhbDmFupCRKcvG4swAbIQtxp7B0PxWUdRYvevcl9ooBZx
  dXycrk40CJ_exHVuMWlEqt5sfgwpZ3hIvjJZVc-qTc1xPxQwA"}
            ],
          "PayloadDigest":"lLv7UjYmPOIj_Flm537sYhGms_0FNzjuLDIyj8
  wySJQgiSGZbhFja7UHuIeVoaUPI_myaOiVWjxfpDPR6gCjRw"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MCUT-PRPW-HDP3-N67L-YB2N-X462-TIHG",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ1VULVBSUFct
  SERQMy1ONjdMLVlCMk4tWDQ2Mi1USUhHIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDIxLTA5LTIxVDAwOjQ3OjQ5WiJ9"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1
  cmUiOiB7CiAgICAgICJVZGYiOiAiTUNVVC1QUlBXLUhEUDMtTjY3TC1ZQjJOLVg0N
  jItVElIRyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdW
  JsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICA
  gICAiUHVibGljIjogIjNvUmlJQl82WG9mZl8wNGVubHVwS2dveml6N2FkeHc1alBh
  SFJLc1RHUEtpRW01WnRnQlgKICB2UksybDJZZk5qUG02VmwtVldyNEgwd0EifX19L
  AogICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUI2US1KNlc0LUdMVV
  MtTkE1Qy1EU1JELVUyTDItSVA2ViIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjo
  gewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJY
  NDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAidm11OF9XUmNFTkFwaUlGMUU4SVVIb
  XRpXzlrU0Z3S3RJUDRyVVFyYkx4c0pxb0JkT3dNeQogIDdDcHNHaG9QMERLTFVqQl
  llZG4zRERxQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1
  ETTUtV0ZEWi1BUFZXLUVVSzMtRzVIUy1JVlpBLVg2TkkiLAogICAgICAiUHVibGlj
  UGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgI
  CAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICI1ZkQyT0FNZV
  RQNko3dG42X0NQUWV4dkQ5aU51YzFYYVNnenFsTFQwbUxDOFZJNUZOYnppCiAgb1k
  3V0JINUpEeHNlVEt1WGpodTV2ektBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6
  IHsKICAgICAgIlVkZiI6ICJNQ0VDLUhHN1AtM0hWRy1ESVhKLTM2Vk8tTVgyUy1XN
  VlFIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0
  tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB
  1YmxpYyI6ICJzZVV6a1lkZFVnaElkb3JQcmpUeFRIS3lwcWlUdERvLXFQYl9BVUJW
  Z2o5Z3J0MzhtNkVaCiAgZlNUVzRqaDkwWWxUOU1ndng5amRwQkNBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCUT-PRPW-HDP3-N67L-YB2N-X462-TIHG",
              "signature":"m1Hp1oYMFIJyOiLaEogZzzpB9wiJjKIai1Lx3A
  zOQmTk1YIKZGQhr-m6K6HS8ayQe9HgGshRtyqAGFe0LN4ZvFAQMcbAIPkinFdJFpl
  1PtHRV4z1xDq_oINwujy8RPjlbelVliGwner_6ozlfRhV5RsA"}
            ],
          "PayloadDigest":"9eyiYqzs-jYpQFCoQ2myKH0D5IkwGMh6ils6ha
  Kzso9hrNV2WHXeLssE-wiA42wuR0HiMX07d_vkX3z-p1BTQA"}
        ],
      "EnvelopedConnectionAddress":[{
          "dig":"S512"},
        "e7QRQ29ubmVjdGlvbkFkZHJlc3N7tA5BdXRoZW50aWNhdGlvbnu0EFB1
  YmxpY1BhcmFtZXRlcnN7tA1QdWJsaWNLZXlFQ0RIe7QDY3J2gARYNDQ4tAZQdWJsa
  WOIOYo6vFEs-BVBXeXGbCko-fqfvks6OGwNwWnXqHeJc1b6TKdaH2eYzPNkydzSm0
  TjmtJr3MzPIWMagH19fbQHQWNjb3VudIARYWxpY2VAZXhhbXBsZS5jb219fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MD5S-CHUJ-HIGG-BUX7-TZI4-7KBM-IMNA",
              "signature":"ryByiUa0vKj4SllI2bUE1IXlfcbE23ueIvvzqQ
  g37-m0AarIWPYFXC91uKG_L8zjGq1s5tuEtt0A8cbNAOjpLJZoQQ7eB4C07v8EfPs
  4ePUvslvFaOj3W5aSNQ9IYGf7SSBm_fN443kYIpwO3KiwHioA"}
            ]}
        ],
      "EnvelopedConnectionService":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTA5LTIxVDAwOjQ3OjUwWiJ9"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tA5BdXRoZW50aWNhdGlvbnu0A1Vk
  ZoAiTUJSWi1OR1RQLUNFSTUtRVBKNi1YVFFZLVo3SzYtWlZISrQQUHVibGljUGFyY
  W1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1YmxpY4g5ijq8US
  z4FUFd5cZsKSj5-p--Szo4bA3Badeod4lzVvpMp1ofZ5jM82TJ3NKbROOa0mvczM8
  hYxqAfX19fX0",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MD5S-CHUJ-HIGG-BUX7-TZI4-7KBM-IMNA",
              "signature":"_qtLCVFkGrm6hLTc-JtrVFWXcmkMKIi5zi4NqG
  ygI2nNoCaDOOKZP1xP59KbFQq_JdfvWoDHz6oA5P8VLgi6tNH402O7GwtsEREHGQ3
  PlqK7S7hNv5EIkjMSPZ-gbgaSA-PU_j-omVpz5tFYDUNx1z0A"}
            ],
          "PayloadDigest":"-UUxns-rbn2w9i6_jz28ZbeMLUvhwP3Hx9Y8UC
  qNdhYEua7QQzFXboyY9xhukHkwhUK-lk1NUWql5PL5Ep1iBQ"}
        ],
      "EnvelopedConnectionDevice":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMDktMjFUMDA6NDc6NTBaIn0"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0DkF1dGhlbnRpY2F0aW9ue7QDVWRm
  gCJNQlJaLU5HVFAtQ0VJNS1FUEo2LVhUUVktWjdLNi1aVkhKtBBQdWJsaWNQYXJhb
  WV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibGljiDmKOrxRLP
  gVQV3lxmwpKPn6n75LOjhsDcFp16h3iXNW-kynWh9nmMzzZMnc0ptE45rSa9zMzyF
  jGoB9fX20BVJvbGVzW4AJdGhyZXNob2xkXbQJU2lnbmF0dXJle7QDVWRmgCJNREVN
  LTNMRVUtRVlXTS01UjJGLUlBVDItUFpQRi1FVlhRtBBQdWJsaWNQYXJhbWV0ZXJze
  7QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0NDi0BlB1YmxpY4g5qBPYQY7HfOmNiU
  X7ZNIbEwSe5IPB5bfidOwMmyxhG3J5iNrLCky4402PyHaWAKw8c55426WjOHAAfX1
  9tApFbmNyeXB0aW9ue7QDVWRmgCJNRE5JLTVXVEstSlM2WC1RSzVZLU5aVFYtTDZV
  Qy1PTjdEtBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEW
  DQ0OLQGUHVibGljiDm4OAqDWJCSvRtntmwE25CsbgTNZ9dCKVyM3hMgOQJDAqGFNz
  iVkZkPU-YiCXM70rOSO8WGDhvSiAB9fX19fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MD5S-CHUJ-HIGG-BUX7-TZI4-7KBM-IMNA",
              "signature":"K6oz8u-TsumJ5NXUDshfViQGFSkwLhphTMAs15
  zGGxO5EsiDU5lkvKRhefTjB_LZvdi0isFhPjIAo_2Zm130bgt6ES4psSOGlBn7lZZ
  XoJN9tb5BVwq2dehYWKlu0SNPtYPzM4kxmY-oInjJvx9D-R4A"}
            ],
          "PayloadDigest":"DdEJQhaGtwKx5nblbLMFW66wGbdoYpNxPj1KGW
  rnuYM1qhGACH9CgvTu0yj1-xwQACcRbJPsqnE45OvZIJUb0A"}
        ],
      "EnvelopedActivationDevice":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQP-PW75-DC6J-EULQ-QG2U-M4AE-P4HC",
          "Salt":"5taY3YY1xn-GZuy6trSjoQ",
          "recipients":[{
              "kid":"MB6Q-J6W4-GLUS-NA5C-DSRD-U2L2-IP6V",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"M11qdkHQlGxXP4L6bIMYMfQe5TsTEZjcM5Xin
  S5sHiKl_El_p2pJ-w7ktMRuZ5JKs7AQP2csIRwA"}},
              "wmk":"DpTq1vzslDbT75szKKvlz0b1GHalXjnzRlUBkOitHJSL
  ptbx3M3opg"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMDktMjFUMDA6NDc6NTBaIn0"},
        "HR5l7YqdcuR4cDPwrstjW7tIidUxONSk2E_vkrTcl32cLfml746eKpdf
  4G_zhSWyVNavJHYtmplyaNyOZUaKQPxfjrx6EqCfuw0HMLJ9lSetDYYpcNGM-bs3g
  tzYVu1d8k480gE0TpG7pey8CCr9G4MJxF-p6Udkhmh1Kt9IjjMYEOrrPPWIVrP-WH
  EsdZKwYbvVHbj905NEUQU7AbgBB3Hc2FNLLNfDDHQe91id-KrYh9r7Ys0Vojuw4-3
  PxeJg",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MD5S-CHUJ-HIGG-BUX7-TZI4-7KBM-IMNA",
              "signature":"rVWM33TmXz8wQh0xbe9uOc6O2un7jXqHJpRtrX
  vPO4MyH4J1dnktGLulMRZLNxbNSTG0tqUOeoyA2HwSUVYfIivHXUemS5IqZ4p0nd_
  O5hWqmYGWqUt3T-uxC-w_TkagovEDHbdzOrZUPjLYKItJ3jAA",
              "witness":"68p30yhvdJRD97wqpQ-MtxxGmkQ0uPLZvLm79ZMt
  t84"}
            ],
          "PayloadDigest":"VF00ETL7WsDftv1MtdeGziTLkZzu3dyp0f-jJt
  w-hpb_1CkNTnEcc8wa18e6tDyRXShE9S--mL7N741s4OPOJA"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQI-LGNT-3T6N-7GCQ-N7QR-ZRFL-5COJ",
          "Salt":"UYbtsLQ1zBokevdS9So4Tg",
          "recipients":[{
              "kid":"MDNI-5WTK-JS6X-QK5Y-NZTV-L6UC-ON7D",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"tQ8_HEsWWR4pN17X5vF6RN_AIre0ZJ3t-5GFn
  yes5qRC-xYEzHg4S532zTm_TF7U3jrdHU_-nnAA"}},
              "wmk":"GdA_2oqE6-RFXB7H0AbaJ_GzlDoZ7P13vxYyj9zZldcv
  7lW3V1ChBw"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTA5LTIxVDAwOjQ3OjUwWiJ9"},
        "w3aep4Wfyhlt06SKrqL5W9NuAJksSbkzxBMVuJZ4c7QE-trkpiJZBjxO
  V5YrpIW-BoBWo5jRVzw8PF2pvpAacsHpRNtztEC209u6Ue_GLEqTt_atUL94Z3BRN
  ouKFKkbzme8C7Rg0oQjrtyy5X-DCTpFISvmkc0c2mkgm6vqCB29tiY-hMPIKDRjzj
  7MLtdZgqPlxbLBHHRuqAkNljfnDy0mTC4yV5nVLMJ1k3nQraWtGg0qvN-gFXcm5Rs
  25WAuIJRW54Teinz7h3DvLVqMmM1LpxL2GOJhHcOv6vlg1FssTnPYt-89H05N3SoC
  4NMxnHQJWXmuCwDRR9xR6skwX2tFC_GRrYSGrAD-s0QhY3_VwNCxXsbJ60v8L_opd
  AO7hPcvGtgRIRPBwJiXlq7E_uAjv-FDGRbuQUFzkhAwapZv-bNim95KdDx9AyWjC6
  iLgyoMjsHWAjjTPanb6A6cVmQOSI0MGvfZ5EYb_Te8zcov4wqDIzq6xNxzXpEM067
  k0vRBAy0ZNOlH--_TZC6BCwAuFD5mBKggFYa_S4Ud-65L7vLvuuLXuEF1ZKJ7mOUC
  FcaAihMCXR2r8zSIoDmIg-mv_xaD1L52AgC5WJNxsDMW02pAlDyzCxSF_D8tVlA-R
  nu4aZEPji3K0JTaeqLcb0TEDzo5ii3OOCpoH0o-3AooKoE5X3Ja2RToQS8JwRnR6S
  qnaVN1M3a7I55D3AZXktXF6LOIRBUEZ3IJmVwAiXDkN3TwH1N2seUanMhw09azfxt
  GzAjn1qoxBTQJVp1-McnbyVO4GTcJ9G68YgtZ5LWPP2Xk-EmkF5e-oxdcBBT5JDG5
  Zx8ncSkQU3tCuxUyl-azmS0S-6KQRB28IxTqTuDRLvF2SRCvTa2AkUDvnbSUwkntP
  ORhH8I8Z33D01zRMzvd5rvoKLP0H9KC6db8-2EkkMyRcYwau6df-xGv8K6_1CUMXq
  ZXvMXXCSgS6KPnF34irbCs59VXNVKOVmnT2kXTAkbv3JfogXZ2SyIj_nUT6EMk4xk
  7DB2boHa7U8NhIvadHyI6J_ot8Shxv6TZ3fY0i9r21Ug8Bm39qBgGZX49BmWGOu0-
  ZdEGnMknGZEqkPULCUEdbW2r45ZBrx_6hwsqXTjdT94MN9BkiA5MSqUN4mItpN2qT
  53O47yAyhbLAVimTB-9GCTSOBbP98ie7mvA3aUUCniGGRWWZMb7O4fuaf5Hf3G9Kt
  k8_qqycmxF9IG3zJxn7HVecrmDESLHL_kzoFCUyIdsAhxoxIBdYfE2h-lKpwYoFJB
  IeGUQi3bWKZegZ5EaWKupLFLZ07UBb03TxSdaP7f7jNVt6XRrKUYEyZ2ThbQijRzF
  CTVpwYKAXg-Vf2j9JlwXyga6oRKfU-lk6qjHT0vSXw12kHtyb8dVjtSYhw2r0EsAq
  WYnV8l3PAehtRftMua5VNvuxnHkgWuxDe6cWSBAlYLlt75uP8Z4KQ7UanGB7njssy
  -KFpHPzGAYWknTFqaO_vk0tA5gBjanBChWXLK7wQPV8Unz3JHUfktTTQwJ3GlkcHU
  SnxMQpWurB7Dzq-bRYFjAE8SFBrtjElJQn7BlHqneMCyQ56XNKIQP1W5HK-Xtb0Rl
  XHuYMtBqiSxjKl5fbiuxrX8WbQpDLQV7etRfb6IYcq-zr-GCmBNiewVtRlryMt5p_
  sHpwVwpLsRCmDuVmBpJ7EX_DmgPApt11uJ8jhnCzwU6zjM34ZhnvSu5cKSM4HfT5y
  i7FrFN7pcpYu3X5MTMzplYDozYqTPAddagjT3ieEjKUT826GyuVcafT4t3hUrna5p
  ePT6HWsVzTSYzl466flOg3-DvFuwSHEFCD9tYM3uOxSL-HMlm9oXWZ6Bshlq4-0FD
  vy3vAYM3swygpMDp9Ou3cUdXFmFmMPMq4m3mIhQP89OgRVw5zbZYSZ7siknrtXmAE
  WIIN1M5cDLClizVl5hQxbzRJBS0omXdRCahxoWJk5FRQOJXa5WZLJJyHy4raKH6tm
  m9iabh1xLcdyYAzpQAzzAuZBFWZ6NsCmjY2DRLSmzRG2cOwOKFE7inSJRRBj0nQaV
  HpSFif3hcUitFaCDFe6ciRNQq3eO4r5CENzPebfPOIoPRiNQCpCuNE-8QbQmkHMTS
  yhau3uduijuY6dDSBcDxv4MtfMfdhs59fueQOiUfgqtTs5sq12wr8XXqBFV0UZ7Ag
  Gk1wZtMMu3pLCtlcRkajDcKXXsAdh53z9T5I5SNQWvKtwkzddtHa4yVZ2WvF16lxI
  sZghSdI_kOCQpUbeHzXNR2KK2JHEAR9d1crvGUnJYm4EurKI8so_CyltE9m8AWEKj
  Z-16SBpri7oLIPePvQACKCLPm8a71mPM5SfKBgzuX8UfbQUh3qZ8g1J-ZzYNXC6MN
  c1fVEn3k3ZPq16AY8cso1TBPtjdsy-Hog9XILW8sx8ZNWeK3NOUQQI0nBag3oCcf_
  43FBcOuZ1ttXpiFHgjckHMSKV-7IXM-ocMOesQKbBPCLUu_W_5aevgLgVrwxTxd-V
  amCyYggysc8p_EC-WIc66ejBs32TzjQ0FlDTwgRxdgbXCFSlOgoSIpC7vB5UZN99i
  axqksqd2PBCW7TrU1TqE3o7VT0qlhWUm7KZA-_egxrbQJxC7qtuqftH27pmbdDi9w
  k5zY5PSuMVE4F0vATduuOjYzxbwGTlo61AMx-tXQOTBvYhIaaDtofX6_uhGrvlv0j
  S-tTitsGZn3tWXnnpYb825wuKDdlhdRZHIbfexT15D6Le8P_XG6LGfTAmC-IIbN6M
  HwE7y-p_-FYgrH89jAbwBP5fqHts94rzxreza6r-5-thii_bjlLIA1uebtZlNCDyJ
  fheEVhWw8d61rmH-KE6tcPPIgB44a_81wrLIluwXUtNmMtpFrh0ACW9l8Zh9qJQ41
  At2jduutZrTxJ3TKK6wYdPb6QLl-eFpZOqYvIhxUn_qrwgW8bpq2vG0JBvkIi5lCw
  oGnvccT3EJqxPpAjqSukIOqhH_w4oe8uz2ET-1HKOu7kmpr8G467j-hF9CrNP9lT7
  cKi4ATuYferHqFXsY4EC0ZFWzCFkSSS0U2vum7W-VImeoeyWTIj0zQRm2ObArq23q
  0jnwHsUuZygfUJSLI4QUH9YvwW3LjK3xz97nNTWJUGWCYLUPEW30ZsFsV1KatKcbX
  XCOD5tkMFSNg4rgT3SD_z7Bh5f6vD_j6QJreluw6uHIPDpt5MKooJ_Mz_XsMJsXeN
  cJXd7yzNW28fnLwz7ETSEUn6ECvZym39GD_ovIDd4T1GJnMCdvkttB2NcyHi928PE
  sgAmcQrk9NLfsSxgJGuaTxdC7iDBC5y_z4B0F68dJcTt1RKwPbierR0UX3lIWTnZM
  oXiujYeUotXK9h5tibZqyp_3FEwbnWABrRWxosNKqVoFSZxZt_06ODh0lkWRS6XJ4
  RQZncNh7GdCGEu1Iw92-ENvoJUb3KKRVCPMRzwtSQgrMKw6FuBddWamKK2tIoYXaW
  dER9hFEP64_7aKlBx0eZ0qX5SOKrCMFlOjPbdpAsWp4r4tm_JqhHUAu6TeS_me_Eu
  CcPaO6NFAgcDleyMsvG6E63UYd1mRtp_UhdNVaivd054eu9JbYr8NAzrhL9hk1eWE
  RCjNLtVYMf9ISl8h1nNpsyckGiso-EHBWPa_WuT57_6T-_ryIXHRpsdaVGI-Pj59o
  1TAaQN7LNtBiQar2-iqxiQbb-m2Ne3tnT0LUg1wUjkxGxduzljsMx6k_VfO-ncC1N
  3ZG6iydN23zE8tSSbcY61pqLhu0zxWTD8jZECTor8yyj9Jvd2EMRnlgrH1JWEhLtA
  GcatiP42mJ3Zk3zrt8TXJ4k-wSi8fFJ20H_Y41IhoGZ-oDMryA5ETBWDMzhZbGbP-
  Fg5t4vB2OXpMOGPbNFu7OuhlRT217VhePFm35h5rK9bFFgv3-2nyrW2Twemg-VD8C
  umKyrNB_VJX9FYvr-LLeR1i165ajw8aBKJxaXUeLiuAM5K9QaSXqpi1L0lVEEhJ9G
  cl-HTwc6RaGcUiP0VSzim69gYsLs7Sq24qkjFHIYpkSFLgFZBwwzOWR16LLXGwN3w
  gKGB0o_FPa_olSiwmhozT5ZupyQxLLp7XXWzlckKPcaEaiM3zMWnhg0mco9g-Ga_H
  iQ59vF3hJ8rwiXnACqLDjsllzYc8X2JdrCkkk_NbBx8kL8uE5wbhp9YMoJ8rqFTLh
  MjC3AsOYScxHFtGdJW3yH1EUJ3nVoNfLmtaNbxRvetaeBksrwXQfYoprKF96EYwcE
  1SMGptlMYnrHtvnzF-BPsVZ0NYsx4jNzSdsEpVIO4b_MkWcBxyV2fMT-AlmlpPAW3
  NUxZ2LpoJF7Rrl0cY0B511otL6KJqSpUajnped11NNu0gdya0AIM4EfEkKBeM5ZiM
  A8VPgA28a7PVlPeJWu1y5MFmrk-7jbEWosCOKk-1e24oAy_cJXOb-Dqv6NJLu0Na6
  zSAYHXPYZrIANcr8KxeuM7vlCIYZLGHXSsqCkcvGHXzTvrmZuNBm1vKKrmtdeipFL
  86EmVLK4TWaR8pCHml69RTji4LgWBzj9FsM3EZAgzHbfLAHiteVDYOdlMDSBph_H-
  ZsJGjlg4qPyYoEVNVJ8JVlvIJU_AIbpcapt24pThiN6prXINsiC60xH8lmxxoOUgJ
  9BuWk9q2g58Z-pvcRX47Lkk0L4irXmL5nIBvOKwFhw0hAAm9_gHuoyEGi3oc1yNQ-
  oO3ATUZ9bmQHV6230FIjOBi3KKoyj3hHdeD-Q03N5o4Xgros2bfg6DCBQ2QyVcCD3
  mLlZDTh788IwVN_BJH2Tww2gewA-uv0lAxWEqoW_JgoVw8zQRkhEDo7wkFiDPZ_Jm
  oDOs18v8IbyniEjq59MyOrbDEgqQXuqF2S_7mM4U35P8VxedoJU30045u5mtegHr8
  r7CgiHpT1uQbghb3JIGTfJ45992F5qLDh-xx8RxCL-xeIYbRJ1a9w5yfNNGdDR_U8
  hlSrayhQ6qnslGIhnr1PltzsOAmsHRYRYDemH5CDhB4FVYP8CqalLnlOQ4zWDw1sO
  N-j-Sn1g-Bt69rH2ow0orPOezj9dYevUmNWO-jUnb5KSNPWC_eIfHTO4skrGO4n1d
  12_Uu2un7pkFIjNfC30zBrnfS2rF2GRE4Dqocz4Q-iIvufWkbaA0RXtS_ucU14G0E
  Qswyin8u40RXYvwkhHjELCzcx0cPnQbs8wDxZSgEpMobxx1qOH9U7ucfk-e3X3lOR
  n2MmnL0AuY7uKVA0Q0vfxHDiyixU5TYIaCVe5Kxu9XGIQTvhEh0_5Ak8k1ys4SD_K
  KFph1D__PJzV4Eyrq3euMthVJWVuuWoBQrHkaJFVgERdi9BN2BLmTLjhzJB1g_mBZ
  -4jSWQ5VSIhGzo-lJ09hxVzrAXDaxjlYFZY6l__ef3pnRMnZGlsGcRGZW9P-n03yN
  os-626o2bscNoyz0Kz8pas6Colz2ZncuTzb3T2oNmC395nREWAmc4qE7chwSTEF_F
  sYy9Ommsrh0lbtv0IHM7-0yGQGKl8YwwE5Jp8l1-bauvaLFvvqihlHIc0ubxcW_6E
  JoFepw5e0ITwCITcRSzvFFGnB7qkWUi1_3mEy8xy3bAOgaGQze5lQMHtHuNGLu-LS
  KDFFJv6Wy0TX56VYM9da5iVYpFc-G-VQbf2QhAkme69pfTWwAmR2MHZuzqy4txwK7
  1PT5Ny2jM4ne-DvBpQq96Pv8eYJZ0FbAdqCw7P-02dvl2PtwwqKbNkXhrCDyj6eUU
  ZwtCbijNTjoVqe__lDtjKoBSBpHav7jUbu9OlQHNXpdsRjQpR4nBPVt6CxzV87w_1
  fav4k9o2m3_L3sNFTpqPHMHc_ysllfvD486xHTjAeWhIBIoTW997UeqHK5we_XXsM
  dozUrdZg2GZw3uq_ttjgnx38PWG87SLq7heYp1e3_cOWecwmpUNfeH4syZp8NLkZA
  gknWopFE-HoM7UzG4YuRbn298Q7SNEE95y0aHezok2dvwHSRZmR40cExyoOAgIKdF
  _BSIUBhk5u_0EcCOV7rNHUHp9LBngvkMfwb6cu-SKCNa7qe70FDD77vKREBhhOz0v
  wURKac8c8c9L_7yMYis20nswkpXL9M-xGDbsIe1W_kEQmrkA_YUflat-RiGWflg7y
  yQ7-m68px0ZtMPq0VpYmk0hn9yJnVyhzwDBxbVHVAGyY1cejukjltyL-6axCQla2b
  vGfaIjxOTNlfM0QGYIXuxgIZzmOg9QT9NGbFHJ2t_1cv1CaykxZ0zPUAo61cg8Sis
  WUugGEEnqL5rl_WzaG1mR6GvRr9TYcJnszFg1JMLqlG1Y7OG1FJrg5XtuOD401O2T
  53SaBdgV4JUl8fFRIGycTvjoddmxvjEkZGxkPBdgPZ8ovU8eo625d8r99eT9A8Ou7
  nrW4-rtehXS2kphOOaXjPGSemd1f5Wrvsk0l4rqdpOq1lXA29iDbcju9LBiSr0f5R
  5ELhTRd47X1bMdGyulUHNvl9AdXie5cTjI6FDabiBu59JSj3EPG_F8Ano2h7POf5y
  Vk39K4JwtllCzVREBlN3Zl5P5xHXSMnD2UYmxo60_Z-RRzRDWZ-bHUpSp3Pgrld81
  K9qasYl5JZB05Kw360bracuYLjIPRwG0TPS_wysGhpFaGfw9EgJPODbXpWCUtAKtM
  iRbkBp-C9lSpQHXVxMH_D5b-hWNvyKj9qjp-VDjUR36ih93uDD227y5DxMlwITAYa
  -STx9oyfFC-uKhKpFEhzlzd6cR6cnihmMR47zymNo2YJNyfccI5vCeuTQRXw2SqgD
  ACDTDOTsw5TTioxW3Z0w3Fs4dmiWm8Nj4aqmcbB7tNH6A-VMlLL2nxUkFo6y0d5Ft
  ujmcupWF-xFgdXMR43QzVmRGfOzKrMs4N2D8mx4pf7AXAvLsy9OGBbfskLVV7GeZu
  DMTPnfzLFeQZWQolSYMXK9ioh133woxzbOlO5IeklV22kAPtyme7hT4y9RTGWdSK-
  Tx92QVR9N8wJHMTIdCWF7gZ1aovs_eR8lYEri-p9DGl9Qbpban7-mHsKmP23dgf1f
  znQhTOJRd9jy1b2qP3hlZ9NYgngWMdEHxnHs_NbUwcG4odWFWkWUQkj9bLmHoHGmm
  UyY_dR5T3U8TUC9c3F7-R0TkAS1L969T68r3oPbhDSUN4ph0w-ntPhguYTYgIzBW3
  IA4hAL3WhZfoeJtBRiqGWgxgcNpDnBOtk_aS2YhOs8H4o7rdDOWdrfDxa2TjMkEOV
  Z5RiCZjTZOrBGbkGlzG2ZsVBoeCCUNC3-uXErvri9rLa_YUfEjHP-QTZEL5jGWJJK
  AF3BHYFktzontRoCVH4uSz8uem7cKLdKVB3ITJYTXRhOpCdQvb73F00_pXza8Bp0r
  W63LUa8U20UEjK5S03FT_NnW8vLoLszzSekXlT908ANCX7WE8hDIoSugSu8BFlMBd
  QGNhceFn8xYyK7Uq-WcBwfb5drjfM7XpHPnanqfxz55Uyu55Evj0BHVxjDrX0ELkr
  Vz5n7WPjija5WYFkMWWeUvPdXDgqWXVLMzdfXybLkHratFcwJyoMEXfKnLGfGCQYJ
  po3RVA8mOdwHOP3m85UiTFFaHdNxZoXqwDE3c6hBucQWVsB7rZGYZf7pM38gL5Mnf
  5mVjGWUJcJ5U98N6c-eX8KuSQPi_6CdQWFydguPqsaV_xO2tvuGrCJy899vQ_E305
  58YTX9uWmrrYHp7vUiT4p8ZlAwBRgSaaQx9wMEEsD6ytIQnmRSbvqb47WMwWK2NWf
  h-nR2l-Y6wxVI5JkhhissnyqZC4TNYaN8IEVh9hmMJpzvuBHHAR2nCIdX2lvMWwkU
  p0kz2MMwK6R2GcKgE8JdihV8fQ9rHj-91K_xiHeY5XgUJRpiaxTZSRSaQt1tg82sd
  CHIfSgnedZY8dlv1uReMH3y-gLdjqzwgIFC_BDV6ibt5fnckVFMKJ9HsqbpUS7mTx
  vw2Eg8Apm9I0vou21Iest7p0pBYK3OQhz0qrbXgiLmF89LXVBNfe-WPQF0zwmEIzf
  kn8XiSegw-eWkouGnMbhJBWBCpKHfLFNT0sHLwMeHEUJ8En2mwx1Nzy-5Ic0f46LI
  xB6HD0vj1MH8Cu38xp3TTpmfZq1LgbPm_T90W5Ta-yN9_Jwfu6ZMnRAYA5GBbFEZ9
  3PJzJ7Q6lH8tEJ6JOJvPey8KaeP_j4T5e4ioV-f4qkfMGjYzLo2_MPBUDHv_4THwf
  K4WDuMGz0LD0QXqxEQWrZnaMnptdkTa2DQxvCt96-iyj_GURrmTtCigVSUIfGUWv2
  R2boLZH-EfK7fmeT_SXVGaTZH0mHMM4mMZxbO0Y2cRjCfU_74s8cJ6uhzclu0LfGj
  9D8obD4yi8nv3NA7YZpXZCo3ztnra78zJX6oYlFNMWImV2bCB3lhUuS8L3AM3LiwZ
  D8NXOspvGfb0KeGjCpVicjtwP3TtmD8AoAAnKT3ZX8UVAb0umaZtfsRxjTAJCrR4O
  0fFbH6bcwxxureD-82fLpm4-pTnuirO9Fyjx4SFJMWesr04rUcx17dNjB7O_FL8hw
  BzrbuvMNcGQlMaGSbWW8SAd1u7NLEk7YkBae6ZgWa5V4bxUo",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MD5S-CHUJ-HIGG-BUX7-TZI4-7KBM-IMNA",
              "signature":"vqs9V0THHIYat3W_NVTnGD9GfxlU5L7bh49-uC
  n7ilYxpBPdgeOtRsllkZ7U7fIIb5008fJA6bgA13yqekSMqm2FZu2ZnOYXoqW_7XV
  n0Yx3ggoaUm33TnudghwMXD4lpDWFTQdQLMWODlWol3iEChoA",
              "witness":"W3IOTkVfIpU7bHSzPkyGpsRO0LAiVLFHeYwxfcvf
  atA"}
            ],
          "PayloadDigest":"CaEt78vWaXzyF2rzzbh-z8R4KQc0Mms-22nnnh
  lt9_uHqTkTFWpx5D7haVL9flnpmYvLisYIK0V4z3J6Z38xCQ"}
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
<rsp>   Device UDF = MCUT-PRPW-HDP3-N67L-YB2N-X462-TIHG
   Account = alice@example.com
   Account UDF = MD4F-Z5IT-LJOA-3PFY-5NN2-K4T4-YE2X
<cmd>Alice3> account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MDKA-OBRJ-BZJ4-ZAUN-BVVI-AKWJ-YOCR"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

