
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=AAIT-WXRD-BVB7-3BBT-D6JS-44GE-B4
 (Expires=2022-10-19T12:48:11Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcu://alice@example.com/AAIT-WXRD-BVB7-3BBT-D6JS-44GE-B4
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AAIT-WXRD-BVB7-3BBT-D6JS-44GE-B4
<rsp>   Device UDF = MDVU-AOST-TDIH-AXGE-WUJS-I56V-WJP3
   Witness value = AI7W-YKPK-MR3U-CZW7-GAVQ-24LZ-MSFA
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "AccountAddress":"alice@example.com",
    "AuthenticatedData":[{
        "EnvelopeId":"MDVU-AOST-TDIH-AXGE-WUJS-I56V-WJP3",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRFZVLUFPU1QtVE
  RJSC1BWEdFLVdVSlMtSTU2Vi1XSlAzIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIyLTEwLTE4VDEyOjQ4OjExWiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIkVuY3J5cHRpb24iOiB7Ci
  AgICAgICJVZGYiOiAiTUNaWC1VMjJGLTJTSU8tVURVNC0zMlBULUJXNzYtSFlIUCI
  sCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlF
  Q0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiWkFhaGpPUlFYbGYxNjBmMzZOOUc5aGU3WC1Wc1l3VW9VSmNGbXZLY0ZHOU
  xRRjM5SWhTOQogIGNoM2dwX1QydC1wRm1iWjdzc2tmV25BQSJ9fX0sCiAgICAiU2l
  nbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CRE8tM0s3QS1LUlRJLU1CVFEtTVdZ
  Ni1VRFBGLVQzSVkiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogIC
  AgICAgICAgIlB1YmxpYyI6ICJFbnRiQXdpeVZBMl9zd2lGQWJMSUFJMzVjZ3IzTzB
  uSnIwQU9kUzRjVXF6aS0zc20wM1R3CiAgVEVGTlFoTDZkNWI1ZnFQTU10VGo3VGlB
  In19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQzNSL
  TJVSkstS0NONS1ZQkM3LUdGQ1UtSkZaRS1SR0dGIiwKICAgICAgIlB1YmxpY1Bhcm
  FtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICA
  iY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJBWGtqbUJRY0Vqd2xj
  TGlXekV4TlNiaXQwelRBZFg2dnhRUlFzdEZZbnFlcXc3LVhtY3JRCiAgM3pMMFpNU
  UdRUWhYODZJSmpUSDZWZVdBIn19fSwKICAgICJQcm9maWxlU2lnbmF0dXJlIjogew
  ogICAgICAiVWRmIjogIk1EVlUtQU9TVC1URElILUFYR0UtV1VKUy1JNTZWLVdKUDM
  iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5
  RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICI2WlFaNnFzakVWcUVLaXRzRjA2ZTJ3M1ZTd0FvOGpDRmtnVWppSXItY2
  dkUHdqUjBKTHJsCiAgYlBoMmVLZnNxU1ZvNThoRHBHUGNyZ29BIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDVU-AOST-TDIH-AXGE-WUJS-I56V-WJP3",
            "signature":"3-NhTi02RC6ubyqOekMxcgQPcSlrcFQBCtr0UJFe
  WHXwC-_0CIqaXiyzRfR2w1kER8RfwsRNwGYANf4ibEHY2INrVCpVJ8roGwF2tdhcg
  SAweO-U-q5ZN6GfldFEn0Ti-bduK8GO351dw-QLrhzNXRMA"}
          ],
        "PayloadDigest":"rXw_CoKPcHDnNka5vIWV7xQ77pf-2fyUn3h3fyKK
  P5-b0CZFuw10Akv8TVj748vu0a_FVOeF-DoJ2zwSt-zJHQ"}
      ],
    "ClientNonce":"sX3O55Fc0_Qif7ss-oYQlQ",
    "PinId":"ABFI-YEZB-HAEO-7LVM-E7VB-IWUC-YD3F",
    "PinWitness":"WZhJn7bTGqltSl8ncV-CDdxeHsimsfeyznypj266_Fn-akQ
  EqWfPCG11r51iVGZK5iSFZYIIMJjmWhPTfJDqfw",
    "MessageId":"NBKV-TDNI-KV6R-O6U6-B4UI-3INK-AAFG"}}
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
        "EnvelopeId":"MCRT-4U7E-2EFA-6GT6-ATYZ-NKLT-DNU6",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQktWLVRETkktS1
  Y2Ui1PNlU2LUI0VUktM0lOSy1BQUZHIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyMi0xMC0xOFQxMjo0ODoxMVoifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJBY2NvdW50QWRkcm
  VzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiQXV0aGVudGljYXRlZERhdGE
  iOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1EVlUtQU9TVC1URElILUFYR0Ut
  V1VKUy1JNTZWLVdKUDMiLAogICAgICAgICJkaWciOiAiUzUxMiIsCiAgICAgICAgI
  kNvbnRlbnRNZXRhRGF0YSI6ICJld29nSUNKVmJtbHhkV1ZKWkNJNklDSk5SRlpWTF
  VGUFUxUXRWRVJKU0MxCiAgQldFZEZMVmRWU2xNdFNUVTJWaTFYU2xBeklpd0tJQ0F
  pVFdWemMyRm5aVlI1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxkbWxqWlNJc0NpQWdJ
  bU4wZVNJNklDSmhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV04wSWl3S0lDQQogI
  GlRM0psWVhSbFpDSTZJQ0l5TURJeUxURXdMVEU0VkRFeU9qUTRPakV4V2lKOSJ9LA
  ogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWtWdVk
  zSgogIDVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVTmFXQzFWTWpK
  R0xUSlRTVTh0VlVSVk5DMHpNCiAgbEJVTFVKWE56WXRTRmxJVUNJc0NpQWdJQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0
  pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE
  0SQogIGl3S0lDQWdJQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlXa0ZoYUdwUFVsRlli
  R1l4TmpCbU16Wk9PVWM1YUdVCiAgM1dDMVdjMWwzVlc5VlNtTkdiWFpMWTBaSE9Ve
  FJSak01U1doVE9Rb2dJR05vTTJkd1gxUXlkQzF3Um0xaVcKICBqZHpjMnRtVjI1Ql
  FTSjlmWDBzQ2lBZ0lDQWlVMmxuYm1GMGRYSmxJam9nZXdvZ0lDQWdJQ0FpVldSbUl
  qbwogIGdJazFDUkU4dE0wczNRUzFMVWxSSkxVMUNWRkV0VFZkWk5pMVZSRkJHTFZR
  elNWa2lMQW9nSUNBZ0lDQWlVCiAgSFZpYkdsalVHRnlZVzFsZEdWeWN5STZJSHNLS
  UNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHMKICBLSUNBZ0lDQWdJQ0
  FnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk
  2SQogIENKRmJuUmlRWGRwZVZaQk1sOXpkMmxHUVdKTVNVRkpNelZqWjNJelR6QnVT
  bkl3UVU5a1V6UmpWWEY2YVMwCiAgemMyMHdNMVIzQ2lBZ1ZFVkdUbEZvVERaa05XS
  TFabkZRVFUxMFZHbzNWR2xCSW4xOWZTd0tJQ0FnSUNKQmQKICBYUm9aVzUwYVdOaG
  RHbHZiaUk2SUhzS0lDQWdJQ0FnSWxWa1ppSTZJQ0pOUXpOU0xUSlZTa3N0UzBOT05
  TMQogIFpRa00zTFVkR1ExVXRTa1phUlMxU1IwZEdJaXdLSUNBZ0lDQWdJbEIxWW14
  cFkxQmhjbUZ0WlhSbGNuTWlPCiAgaUI3Q2lBZ0lDQWdJQ0FnSWxCMVlteHBZMHRsZ
  VVWRFJFZ2lPaUI3Q2lBZ0lDQWdJQ0FnSUNBaVkzSjJJam8KICBnSWxnME5EZ2lMQW
  9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKQldHdHFiVUpSWTBWcWQyeGpUR2x
  YZQogIGtWNFRsTmlhWFF3ZWxSQlpGZzJkbmhSVWxGemRFWlpibkZsY1hjM0xWaHRZ
  M0pSQ2lBZ00zcE1NRnBOVVVkCiAgUlVXaFlPRFpKU21wVVNEWldaVmRCSW4xOWZTd
  0tJQ0FnSUNKUWNtOW1hV3hsVTJsbmJtRjBkWEpsSWpvZ2UKICB3b2dJQ0FnSUNBaV
  ZXUm1Jam9nSWsxRVZsVXRRVTlUVkMxVVJFbElMVUZZUjBVdFYxVktVeTFKTlRaV0x
  WZAogIEtVRE1pTEFvZ0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhz
  S0lDQWdJQ0FnSUNBaVVIVmliCiAgR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnS
  UNBZ0lDSmpjbllpT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0EKICBnSUNBZ0lsQjFZbX
  hwWXlJNklDSTJXbEZhTm5GemFrVldjVVZMYVhSelJqQTJaVEozTTFaVGQwRnZPR3B
  EUgogIG10blZXcHBTWEl0WTJka1VIZHFVakJLVEhKc0NpQWdZbEJvTW1WTFpuTnhV
  MVp2TlRob1JIQkhVR055WjI5CiAgQkluMTlmWDE5IiwKICAgICAgewogICAgICAgI
  CJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6ICJTNTEyIiwKICAgIC
  AgICAgICAgImtpZCI6ICJNRFZVLUFPU1QtVERJSC1BWEdFLVdVSlMtSTU2Vi1XSlA
  zIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICIzLU5oVGkwMlJDNnVieXFPZWtN
  eGNnUVBjU2xyY0ZRQkN0cjBVSkZlV0hYd0MtXzBDCiAgSXFhWGl5elJmUjJ3MWtFU
  jhSZndzUk53R1lBTmY0aWJFSFkySU5yVkNwVko4cm9Hd0YydGRoY2dTQXdlTy0KIC
  BVLXE1Wk42R2ZsZEZFbjBUaS1iZHVLOEdPMzUxZHctUUxyaHpOWFJNQSJ9XSwKICA
  gICAgICAiUGF5bG9hZERpZ2VzdCI6ICJyWHdfQ29LUGNIRG5Oa2E1dklXVjd4UTc3
  cGYtMmZ5VW4zaDNmeUtLUDUtYjAKICBDWkZ1dzEwQWt2OFRWajc0OHZ1MGFfRlZPZ
  UYtRG9KMnp3U3QtekpIUSJ9XSwKICAgICJDbGllbnROb25jZSI6ICJzWDNPNTVGYz
  BfUWlmN3NzLW9ZUWxRIiwKICAgICJQaW5JZCI6ICJBQkZJLVlFWkItSEFFTy03TFZ
  NLUU3VkItSVdVQy1ZRDNGIiwKICAgICJQaW5XaXRuZXNzIjogIldaaEpuN2JUR3Fs
  dFNsOG5jVi1DRGR4ZUhzaW1zZmV5em55cGoyNjZfRm4tYWtRRQogIHFXZlBDRzExc
  jUxaVZHWks1aVNGWllJSU1Kam1XaFBUZkpEcWZ3IiwKICAgICJNZXNzYWdlSWQiOi
  AiTkJLVi1URE5JLUtWNlItTzZVNi1CNFVJLTNJTkstQUFGRyJ9fQ"
      ],
    "ServerNonce":"QByh6ilkH8TWCy92cW2IZQ",
    "Witness":"AI7W-YKPK-MR3U-CZW7-GAVQ-24LZ-MSFA",
    "MessageId":"AI7W-YKPK-MR3U-CZW7-GAVQ-24LZ-MSFA"}}
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
<rsp>MessageID: AI7W-YKPK-MR3U-CZW7-GAVQ-24LZ-MSFA
        Connection Request::
        MessageID: AI7W-YKPK-MR3U-CZW7-GAVQ-24LZ-MSFA
        To:  From: 
        Device:  MDVU-AOST-TDIH-AXGE-WUJS-I56V-WJP3
        Witness: AI7W-YKPK-MR3U-CZW7-GAVQ-24LZ-MSFA
MessageID: NBGK-6BGU-5C5H-4WUR-OGDF-NZTH-ZLCW
        Confirmation Request::
        MessageID: NBGK-6BGU-5C5H-4WUR-OGDF-NZTH-ZLCW
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
    "Result":"Accept",
    "CatalogedDevice":{
      "DeviceUdf":"MDVU-AOST-TDIH-AXGE-WUJS-I56V-WJP3",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRFJSLTVXNzIt
  M1JKTy1WWkIzLVZVVlEtSU9FQy02VU5BIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyMi0xMC0xOFQxMjo0MzoyOFoifQ"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJDb21tb25TaWduYXR1cmUi
  OiB7CiAgICAgICJVZGYiOiAiTUNERy1UUzdULVVQREQtVjY2Ny1PWFNYLVFKNUctR
  lFSWiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaW
  NLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICA
  iUHVibGljIjogImhBZTdpaUNZbm51MGpyVFNhdTVXdWNPNzRNajBaQTlEY1N6VFd5
  ck5RVXg3dDVuSnNsZkIKICB6VjBqYnpaWWprb29HalFsYnZJclVUR0EifX19LAogI
  CAgIkFjY291bnRBZGRyZXNzIjogImFsaWNlQGV4YW1wbGUuY29tIiwKICAgICJTZX
  J2aWNlVWRmIjogIk1CWUgtQkozSS1FVVdMLTdRQUktTkdJRS1UUEM2LVg0S1UiLAo
  gICAgIkVzY3Jvd0VuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJNVC1LSkpX
  LUZVN1UtSFJNUi1LNE9JLU9LTVktWENZTyIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydi
  I6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiak1XbTJvRGpvQWdJZ053SkV
  3eGk2MkZvRnhrN002R0VMX1FUcGZySmhvd2k2eUFJOTFHVAogIDh4X3pFVG9NYnVh
  eDA5VkpDRU9QWnphQSJ9fX0sCiAgICAiQWRtaW5pc3RyYXRvclNpZ25hdHVyZSI6I
  HsKICAgICAgIlVkZiI6ICJNQkZNLVhXMkgtQ0JMVC1BTU5RLVpXVlotVVNHSS1LT0
  dJIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0t
  leUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAid0loNFhfcnpEMzQ2OFRFWnhLdGZWd0xSdHRlRFBZUEpqeWFUUUMwc
  kl5bzFOazZQTnNkUQogIHZNa0FPNzZBejlCR19aTGxVNE50T2tnQSJ9fX0sCiAgIC
  AiQ29tbW9uRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQzdWLVhWTUotNzN
  PTC1ZV0dMLTVNSUstUk9YUS1HTDNZIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  lg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJjbERrUVQ0bDBxV3E4eFJ4SlNsNm
  p0eV9NdXFsWTM5ZE1jOUhheFEwSWk5Nk00aThFVWVRCiAgeW9VT1pRM2IxYjQwVFc
  3eUtBb3U5SHlBIn19fSwKICAgICJDb21tb25BdXRoZW50aWNhdGlvbiI6IHsKICAg
  ICAgIlVkZiI6ICJNQVgzLUU2V1AtQk1JUy1JWFBJLU1ZUFItTTU2Qy1PSVUzIiwKI
  CAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDRE
  giOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI
  6ICJwamdjdmlIRU9yYW4yWmFMa2E5ZmVnbmFqN3V0OU5Sd2NTNUZHWmlGODBvSmUz
  RnpVeHZzCiAgeE1xdXRJNFpxNW5zbVAwbDhEa1FPUUlBIn19fSwKICAgICJQcm9ma
  WxlU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1EUlItNVc3Mi0zUkpPLVZaQj
  MtVlVWUS1JT0VDLTZVTkEiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgi
  LAogICAgICAgICAgIlB1YmxpYyI6ICI4MXN3cG0wNVQ5b2x5cWJNSE8wZGFEVFdSM
  mktUEtGaEhtQnRHdjVwTkowNmg2a0tFNk5VCiAgMGJDTHY2U3k3cGJuc3dXbUZzek
  t0U3FBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA",
              "signature":"UNtyhJFuwLPmj8uuSw6Ts61ACoOkEoLF63rSbH
  T35bDRuS8VFhnkyNX2mQ4SIGHuBPPSURZB84kAGRhq0MRAR32jbTJr4We3LSy_Pde
  Gh5hVaGbRMUhX2V40SVzy7SxLcGYW8iXqXq9PVYL3S315fBIA"}
            ],
          "PayloadDigest":"6P0GfqW3b_kYhYrWG0e0oXy0uENOr_YxxcU3Cg
  LaNO3tLeTmWkUCGtlZUMvEptTtN-Ysu4KqmXr7OmphX03qow"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MDVU-AOST-TDIH-AXGE-WUJS-I56V-WJP3",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRFZVLUFPU1Qt
  VERJSC1BWEdFLVdVSlMtSTU2Vi1XSlAzIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDIyLTEwLTE4VDEyOjQ4OjExWiJ9"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIkVuY3J5cHRpb24iOiB7
  CiAgICAgICJVZGYiOiAiTUNaWC1VMjJGLTJTSU8tVURVNC0zMlBULUJXNzYtSFlIU
  CIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZX
  lFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJ
  saWMiOiAiWkFhaGpPUlFYbGYxNjBmMzZOOUc5aGU3WC1Wc1l3VW9VSmNGbXZLY0ZH
  OUxRRjM5SWhTOQogIGNoM2dwX1QydC1wRm1iWjdzc2tmV25BQSJ9fX0sCiAgICAiU
  2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CRE8tM0s3QS1LUlRJLU1CVFEtTV
  dZNi1VRFBGLVQzSVkiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAog
  ICAgICAgICAgIlB1YmxpYyI6ICJFbnRiQXdpeVZBMl9zd2lGQWJMSUFJMzVjZ3IzT
  zBuSnIwQU9kUzRjVXF6aS0zc20wM1R3CiAgVEVGTlFoTDZkNWI1ZnFQTU10VGo3VG
  lBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQzN
  SLTJVSkstS0NONS1ZQkM3LUdGQ1UtSkZaRS1SR0dGIiwKICAgICAgIlB1YmxpY1Bh
  cmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgI
  CAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJBWGtqbUJRY0Vqd2
  xjTGlXekV4TlNiaXQwelRBZFg2dnhRUlFzdEZZbnFlcXc3LVhtY3JRCiAgM3pMMFp
  NUUdRUWhYODZJSmpUSDZWZVdBIn19fSwKICAgICJQcm9maWxlU2lnbmF0dXJlIjog
  ewogICAgICAiVWRmIjogIk1EVlUtQU9TVC1URElILUFYR0UtV1VKUy1JNTZWLVdKU
  DMiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2
  V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB
  1YmxpYyI6ICI2WlFaNnFzakVWcUVLaXRzRjA2ZTJ3M1ZTd0FvOGpDRmtnVWppSXIt
  Y2dkUHdqUjBKTHJsCiAgYlBoMmVLZnNxU1ZvNThoRHBHUGNyZ29BIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDVU-AOST-TDIH-AXGE-WUJS-I56V-WJP3",
              "signature":"3-NhTi02RC6ubyqOekMxcgQPcSlrcFQBCtr0UJ
  FeWHXwC-_0CIqaXiyzRfR2w1kER8RfwsRNwGYANf4ibEHY2INrVCpVJ8roGwF2tdh
  cgSAweO-U-q5ZN6GfldFEn0Ti-bduK8GO351dw-QLrhzNXRMA"}
            ],
          "PayloadDigest":"rXw_CoKPcHDnNka5vIWV7xQ77pf-2fyUn3h3fy
  KKP5-b0CZFuw10Akv8TVj748vu0a_FVOeF-DoJ2zwSt-zJHQ"}
        ],
      "EnvelopedConnectionService":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIyLTEwLTE4VDEyOjQ4OjEzWiJ9"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tApQcm9maWxlVWRmgCJNRFJSLTVX
  NzItM1JKTy1WWkIzLVZVVlEtSU9FQy02VU5BtA5BdXRoZW50aWNhdGlvbnu0A1VkZ
  oAiTUQyTC1NUFJFLVFXV1MtWFRKRC0zVVBNLVhMQkktTDdZNrQQUHVibGljUGFyYW
  1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1YmxpY4g5k90GmOG
  e9O5lzmhecs6x7bMgC-TLtWwRxRhD22Jsp7cWUfzdYclPicMd75dLrMhGvPDqGoGK
  kFeAfX19fX0",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBFM-XW2H-CBLT-AMNQ-ZWVZ-USGI-KOGI",
              "signature":"2ULSXsloj7o6CA45OK9oS76Lxvx_scD5v0Jyg3
  Orw3y5u6jxTfBDQ0achKfG7ukTYUYk-F_9bZQAUeDiu_UNQ-F11KU93eLfKNdoyMG
  PuqueZM3cI_3MZpg_Y8USSTBC8-3ZQ2jm7eTQvf1TJ4hcfSgA"}
            ],
          "PayloadDigest":"ilTsyFjZfzvueN8dMs0oIjWRMnlX8738V2SxXQ
  WMtTl30QadDspUKT0y9htgRd3B3K3BXXYuifsVYkemJ93r8Q"}
        ],
      "EnvelopedConnectionDevice":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjItMTAtMThUMTI6NDg6MTNaIn0"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0BVJvbGVzW4AJdGhyZXNob2xkXbQJ
  U2lnbmF0dXJle7QDVWRmgCJNQ04zLTJCWlotMk01RC1JS0pDLUsyNDUtUFMyQi1WV
  FRHtBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0ND
  i0BlB1YmxpY4g5fZZGkmvt9nJ_UbyYl38byPIhQiUf5jAY4RmX1NWznq1itr_e80-
  tKNvJtkDX5f56cXXI1bY7pxmAfX19tApFbmNyeXB0aW9ue7QDVWRmgCJNQlZSLUtD
  TUYtVTNDNS00M1NILVZFUjQtU0RDSi1SU0JDtBBQdWJsaWNQYXJhbWV0ZXJze7QNU
  HVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibGljiDnF6uTxweBXs82Hcn7xeh
  B6sIKxIqEIscG6ii7JNtw8_IQ60_4u2-pl0hGMUoapHD3rDNFnnSqx1YB9fX20ClB
  yb2ZpbGVVZGaAIk1EUlItNVc3Mi0zUkpPLVZaQjMtVlVWUS1JT0VDLTZVTkG0DkF1
  dGhlbnRpY2F0aW9ue7QDVWRmgCJNRDJMLU1QUkUtUVdXUy1YVEpELTNVUE0tWExCS
  S1MN1k2tBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWD
  Q0OLQGUHVibGljiDmT3QaY4Z707mXOaF5yzrHtsyAL5Mu1bBHFGEPbYmyntxZR_N1
  hyU-Jwx3vl0usyEa88OoagYqQV4B9fX19fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBFM-XW2H-CBLT-AMNQ-ZWVZ-USGI-KOGI",
              "signature":"C0kZpxdTGCpsjM4K0GYANmI7MJt7IWg1uWubP6
  ReBoSJDIOhgjxEFkyLkLru6M_DC9wQseJJRUyAXdFnMWsryyYwlGe7Mt7gLqiy2jZ
  LChMed6CWRFihSKyy3m2xk5MpgVWKE0OPTSd5ogggywNcPCEA"}
            ],
          "PayloadDigest":"T8rztdxwV4vdVcuzkbHCN9IdLOQgktu8bVdOPZ
  1oe9OHzpQF9iXp-TKA-pe_t7fI7TBIIy4_fgyceguzfLm8QQ"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQC-UWVB-WCCL-OC7B-DAPJ-HH56-FTPU",
          "Salt":"6cMFPhSyk3N-N8BpC6wfvw",
          "recipients":[{
              "kid":"MCZX-U22F-2SIO-UDU4-32PT-BW76-HYHP",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"pfz6Z5pf01FpCm-sqly6c5yn3gkTDvXsoq3DN
  kgL2ct4Xi-ZchVk4S371FmXTRDDksZkNcr6_uyA"}},
              "wmk":"UIdLeJGqH_HnNrTQkHqkwf5Moc9qv_DGHx6hK8HPd_Ga
  4HFdKM-P5Q"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIyLTEwLTE4VDEyOjQ4OjEyWiJ9"},
        "DIILdK1ep36rm_QwOAirsby0NrS7VdPW4dWllC6JNaiYm8tVemYvpSw9
  T6JAMzeF1NbQV-qICMqS0S03wFQBHrh5AGk1cvi8gXYoB3KibVGlbfe63RJ7rW3uH
  lROB8JIruTeIUI2B6Tenq_Hr1pS_hsPwQhcnmfZbifzzF_IQCBXIrVTxloHcvuvFD
  eQ-in5akhvKd8AhjeX4CqJXiYl66r5UST7jpVb0KhhI-7CB_JqiwkQ9-EneFtYAFP
  4rMgE",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBFM-XW2H-CBLT-AMNQ-ZWVZ-USGI-KOGI",
              "signature":"Hnhrbwt-FrfgcWsuL8x_8M5XV1Arw89jnX83t2
  qNydJGKr1edgE9GJyFuiuWKua2-qxRuY_eGEOApCbI0DQTXGaev8r02It0NiSPhey
  OK7QedmR63RBdYyjz6RPKAK_rDLRsqK8aSIECeHvvZOkHVRMA",
              "witness":"XtNpxWPYliMptDDZHLJzbPBSCyVqe8lP93CmTqvL
  Ik4"}
            ],
          "PayloadDigest":"2RS8lD25HernJ5djhkJwxX5mn1ad1d5mcJhppb
  rD7KYyFSgfs2_mKuB0PQLQhQszM4DsaHCOBd9Dy3LTXsy0Dg"}
        ],
      "EnvelopedActivationCommon":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQH-EUWK-3FJW-YFOP-MQ75-HZZH-2RVK",
          "Salt":"z6lXFvESehf7hmdqgvq6hg",
          "recipients":[{
              "kid":"MBVR-KCMF-U3C5-43SH-VER4-SDCJ-RSBC",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"-yyvcy-Dq4Xhu7CuAScV2cJ-IRGq8uZNY8XMP
  kZLr_MK3xCrXmQueChVthD4Q8WYYthuHjj0Xt2A"}},
              "wmk":"tpvjbLkGEgDIBIqLb576LYgoRNdUGBtVL_mUXIu4xVPE
  nZHssOXrTw"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQ29tbW9uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjItMTAtMThUMTI6NDg6MTJaIn0"},
        "4cr4Tfdt6bmIeyMlXDHuwY3vnfc938xH2aISXnh7L_HrElngjJ87lcdV
  WIBekCVdYRVISDvOCWs9FraK6TYgsIU7FhLHSFjXQFyI1YReGmfVTt07qc0LTgOHa
  6Vtbnem_83kVTUvO6Mx6vJf0cHPfYTxUkbvyXFA1X_r0nUTnltvSkyuJW0UvhTZrH
  Oe8SS8qkZ05gLiacjfnnXnButKip7UZvUFCntOpvHwMrUOQB1i5MnRIi9lalfmjY5
  UexyFDPppwu_DieKAzBVTNP_PF_axtvY9siLYyGM6doOPDtiWHoaeg44G10R7codn
  pgZIUiHjU912rIXhKJsX2AZNQhbXuyXX3Pzru16nCD31awOqh4ByJLCu77lhgEbDW
  Jq6vXaaBmVuBKNTsWZJv85ae2Fw0MtFu17NqCGzcV4YWtz1Mp_5PkG6nuuVL-SSWs
  Xyu-1zzWld4tOZO-VCRF6a5jHfeDu4OZTfOU2gNqR5g3uB2xr8Hnku_M8J11OtbGR
  TO8rLDB-eh5N9e1rj3AEosqTBxt6h2GIyV6rnwpa30bGcyqUm_zbJB6NzIetwDypK
  6e3fd8OQtddvpoBSUc0MlQKXU1sacQdz8Bwim-0k7MJ0uo9UOonrlXm-F3O93krXr
  lcm_KAJ4C6yHjOzco8FeoHIzPGoNUP5vR4NbyzFpXxe3YLAXbKNmV3mXF90cVatzO
  rlSt0xCqs6fmV1ZzhZca-1giPryqPrJfAQeMnm19aAqObY9mJq72-B-qc9L6fEq1c
  S4svatmp0bZd2CNf07yKEWALstitJsLZFuAYh7dwqtE-9AuTukZrs8AM6uLxlpDVh
  Y8VHFnYRPbqo_xe1q9H7rapq_taPO536CLzb7qkdN7jR0fJqfnVYt8FtST3eG0KrN
  iA3qAOWBqSenklpdyGnIsjumLGWrD0kra6uJlu-D8RdZ96dzDpioyncPi4AP3Yc9-
  4jsVBVrpNKhCd0ULXKXx_2TfYsPG-oyNrj8d1tPXptqzVZ4RubB3vcMNb7SuEk2DU
  ykflvwOgYbyamN_Bv2MQZPcjT0PMGfdg1OKJVrBZW5TeECH_bH6BY8iZhnrq4sj8K
  t0GosuvhNBhOaQr348MQrzSagCJzWqwl8-JRjxn0-2hWb-wYYKaV2fqSicMUWxzaZ
  TQH08RC6UpZXJ4przc3370HyggyJoPOAsWiqEI-BCnDzL_G1_Jrv1Dl5awozDD3JR
  g3aOabvSOsCQm3vfrDPQ6f7q5S0bHLUC7WuMhgafDQUPCzgiuehbti4ZP09C38yZ0
  wBynOUk6Z4le9kkwHQiWMiwVMMt4c9MfbZl3uOhW0DqI86Vz99Gj3l1QBbh3kXPQ-
  0RgcCqM8-0RSYriPjYEOyTgQ0X5dqHqhHcg94mMV0D29gEQnX8m7rIc0m0Pzbr0Fm
  dgI9Omm_PNCm9liTNS7nK2dh_AogEZ2SyiCK9p7Ytxn6-ZP4USeG5Svc1jrWqw0pd
  wcUhETxud6-SKmcdbf_0ywautJ8s99iJd9m7MABvmOK3WzTRlkfKlPAn_8w8YJ6XN
  qEaOxScYYgZUw72QHfyX-kwvc-R86v-5aDO6oS3Pn-iK4MUlWdmeryXaTeGVneUf5
  v_kFwMT2P5e2U3ucnxBDTRvjkhlmz_zgMM4exZzY_5M0QONHAtBx3k_fKd26hTT9t
  Nd11PqWZdSR8j0gzYhU9xX4G4PGgJ8djNsAiC9U1DnKHiSMOfLfgjnM7C_Gvt6CpS
  Q8GWIF2e_qA5bCAE5ffi-VQ4IJZzYKNTql0UQcS053av0VeqYQ6IixrRzxLPfZtk2
  iPVuFzvmxgj9TKHA2i0kjI6KEjQ9O-bcpldSeokQ3zyzjNarmeT1pkRVd3O0GnMFJ
  2yQAD3ci-dl10HYQ2hqs5ibZNdtvLKAq1Oqr6yz9w2T3EXpdUCHPQsiJJzpxbq8BU
  F8zaaSEkYFc1fFYn7M81LqXEX8WCgAtGclsN6nTUkMdrSfbsllYsIzPohhVCbPelw
  7zcIb-WBM9ToK58IX2hLMbyVCw6BabJhWNW_9kbhXwowduqzY2UuaTFND1iD_ZJDT
  m5HyZTS3OWM2S6TfbobLKePYWdTgBgnScrl87gaA-rXBH7O_oj3rhFP2YgxUObDln
  ZtP1YAqumSyM9F1RGh1b-ypoL0OSYbADZkAhVjRLfJQFK1VWZuyRVWxEoQMnS2EYh
  Yxjqm-9LS7IMQQbXwSvDKb14eiWMVOCunckRIHVEETbuCog6741tsHfe91Rj4wlCd
  V1rXfdaMAWj5M0YYlmhStPfLnPSOC7Qh0KlAMi2907XOpCS21qAeKJJsQVkWxyl0D
  psNu0btd-kUKZhYvSXzlv0JeP6jEFj0mkm4ga8BnTtug_qzJWON-dbHQzKrEYX0SK
  CQOxclCAtYXRzmzHHYcKkz4AG0jN8ENGtSGR9pwUcvNOBbBQtUF5UaFwJrJKjhRYJ
  MbrYttQI-KeSy5nJpYqe2G485j9pO_NgasWxhmmdSoKFoamPUOC-SNxwLz4t_vKFq
  ginV1JW5Vstr4CY4MtaFtVGfLHfGU9BEm6eBoxeRJFZGuuA6ImPRK1vGDXokMXSBf
  s0FMUSbAUOinegK64Kai-htnlaAFa3zlBI08ha3oz5aSlCP952w_xHKL7l2bvxlyH
  y4Kz7aP1L5R7iUWp2_e5XJHTmXduZOM-FnDq2SwVMVjzlawXU2BKCfxMaxy0TBpyv
  h6x23WrIEHUy6l52lD6tz2Kv8ZEM7NapZIaELmDT9dva1gv7VEjNI1rMyVhqb2LJp
  0KIK_d0wXAKrhziRBLpAWsUNRb6sXEioroPJO1AhgKVu4LB61_s1FUxPESHtHoFtZ
  ZppzhTZsit5AgaDUW8gtRF6oSa4MqQ1Ag3EF9Ft3OP7MDZoENIlp8_wOsmF_mLdjH
  gh4KDQOeLCIdMJUOh_fzHVRWQw0llQGL7KLuXSZNyahkWzINY6ezEMlZ_qyH3Uf0o
  Blxu5K4RYiNVWzd2-IH7zcb80DtLwzEcnHaWRaePs_p112UrSZjiH2jVr5UkF3wyG
  AD6q4X3HTDRt0YQ9F3bJn-ZoPQG-RrJGDYAkKOtDwc_ZIZwQhFAN05_CnLErIV_Vx
  n8l1sFRPISaq3kb7YJCrKo8r5UbYyJpvtxKy8ONiaSjaXtCfXzDrBqTz7iK-aa-PC
  P3SL6wFVCtS_MokaR-V2HLiq7sbql3BAdFXCoVuYVjhuplUoDXlZQVLiFme4r9Iqv
  vXSn-Oq8gY0pugF9p5_BvIB14bBTyG1AV2R-G6iRpi1OtlKL_hupGS3apTOaLrixz
  UXAaaVr4MDTx20qXT7TU0n25UJUKljhjfMi6h2skESHk38N5UbsXPrItwbXSLI_xo
  DzJBvv4pF0d15WEzYkTq3fFLvAlIwQytEPkdedQQ6nlpbKpPwuaA6c4w9K5FZXiI6
  C8E5TH4WOCtJbXnIic0AZzZs-2FczysmPkgUNnpvRH6rxCYyTNsrs4CjTtRknUYw7
  vG0TeZY4z16V_g0O0fuMH-zt1Imi9Ai3yReOkHjwKhM8picScVlGQIzhjSGrWvPhw
  TMySwkKNaYXGh_Q-JwUvXRei-fxsIVBrX_hGy6qC9z5hXVRVOjcsISXIg2cWkkbG7
  uy8Ec9fRpvD78w8Xlh6HavVUDA4sF0iQ5bMb8HqkWOeXI9-0fRSCW3OUgsJZRNttx
  jAWsZEyTJhXZbFC1O3Yq0_8jor8HgMxQhxjoMnou9K5yhGqhtOP17ehp2IP2vZMoh
  HNhYyLOpsczPOwPc0mCN72k0l-O9ULp-rcyuDEtzjL5Q_ww9iOCOf2Etj0uLfi9-M
  LbXBcPxd3Qa4YgG9_d3UWlumbnwYyi-mMRVj3If0O0xCYCLuZJyPwTyww4n3SqV65
  2CqcW6wmzuERHqh5QgHx1uTOMXAhif6nVSEI-yavYp9V6-gvs1Ko3h6Afvig_Po7o
  nnfw5GaR0SBqxVKPpfBemBhj08wxIhXKG-lzH1SDs-kxlTp5fEUfxlG-Jje92vKT-
  9qfZnsbgqzt8RZgGMWfT4niXWkRaEr3UCFhZKUag8LGMkAKlZUwPpLV3OhAP2JInm
  dbVPM45Ik-YKHTxOFTw1Y81RqrwY68srtpLAyJUMapcEW9hhNeVohIiWpER9Ph-tS
  vusuW5MuoQx_PT7UdksDZNB3lS-5BamgJJ8_NFlWnmHzmHgz2DKaJ7hhk5M9zDp7r
  yHXPfZfIsqz4t-NJ3ksH9-1KdZaD4JSzPmTLpLKBwzZNuazwgnRrGeCjlzFP4Puil
  uALZzizswiGz_HCRFQuNeuphoR1uxqvW8il8DFwsx8JLbkV95knOIOLHhh7Ngbjtg
  XZrMnFKydMqtayhuZdsGtNrOJdwWXkcGKJ1sSxnuWfcETksxGi_JWKKdLLUhjM20a
  3n4Zc7PRILlIWLkN-3aKNJSCmgW35wnf6Ud4_jd9uzMxOfGKdYkNXejXQC-BQ8PfX
  DyrMO6ewBqk1zTGtax8Z-PHIKeGs7-9HQdOT2Qmb7xZ2yuPftSMbcgcqBBJ7bvdVy
  mYOjU0vKgviZ58uWoxIEBly1084O1YqUW-vxFaMgKjQUSa6tTknGDV3vePo4oPl8d
  4deApD0VOmdId1qv1Vmn7LBeqi8yi1SGByXmqxJGsdXQK0vyTxN6LDYygKSlIih00
  l7W7WaSzYVurDamjPqah9tuPcVapx95SmM3H3MgZQvvs_XXAILTEsD-XaJhyCnwPc
  evaYDRpbiE4bAQf0XzmoVmltJCKzxSPJQ7GQ2SUsf6tgRKVDW7e75Aiw4F6JZq41q
  WujNjje_O-n_xs1YgP6ehVbbFoUkBVKAZGhVhk0TAU3xs_YNArqMG64XS4N-NPCEL
  uB2oIzQormfJ2wQVMlnbRilD6eFlffs6hAhlcrj_22phrChU8puFA2X4P9TncV_7B
  rqOW-4xji5Lm9POzZ7fCtS0lNR0E5hPGgCM3Ynp_mq_IdMgiLM9Q_vU_aucvxpE5T
  vs-hewsKtoC04EYwocaMEqN7hx-Z2Wl_bLHqXtLmoTUjiiucijYdj8k8yJN9hrJeF
  Ek_98Sw5zgbn17yNGuLDFxdc0Nmvg-RenFy8_Mhd8kAWqSu5zxR_XLtPBQUe5yWzD
  h_THfxdYMQI1OxcB1noMNrpXn8EatP_jRS49zBAeiI4WkUh0z0vqyTJorCymglpBr
  lCcSv6c_o5l-sN75VXzsE-o2xntI-aQdcbj_IdaqKPoS06ETgH9wUOTRYr19JTm-G
  kqMR3nsPnsSfN9yJqAatoYuI9GAKYLyZ1JLnshVbzuEWYNFoYEfqYJvuSs1ENLKKv
  TiFB4fzVIfEiUqxcKJv7Grff8veOUAnG_HHheuSkHybDTKvuBbETaXyJ9zbuXB-8p
  lmgusNtjzYVCaXJ66SSYHhaiRDsNd90aC2wD7APaNNSGOJC_lbQIOiUlk1En149t4
  NI4yAKXyVIoheueT3lZHrDll-6cW0Gj41HiRucAiIx1AWDbTIvUvgM-_R_ctyXqkm
  -WrH6lHiOSjE-KVqn8ccsjieI2PzSI4TV4RVUBca3VGXG1_7Sm-IqU-EBYUzghSnt
  -tgg4fkMvjfuHwWY8UVcvmchQva6Jju0ol2hickgzJ1E_-rmKoRcRROn5tC6Bw9p2
  iQ7PycDrQlq-S4uyZZoP_u1uBRG4IoYvDaw5w4MOB8GSvTGXqmn2nqNeSwlUBQZQO
  qJi6IQ8lh0TkpERM-sh6qn9Xg37_4l2qONMeHD0dKuqzb907dFddTCdONi6NUUJV9
  DkI6mTdHqNUtPbc3F6foHiVY4aoZhkyErQmFqLJdkBYb0o1tfuS_6AlZksQMS3yQG
  CODRGJJpjvePdbaz_95muJFIt_28zUA9XmHE6o8uQuWI2pRdC6RJHsOTfb6jpAUe9
  i25xO0DAaeI2tzoaOe6-IOLxzrIwAPSOSCfKepDQIZLn8enEpZ7no1an4JyDvzdH7
  91dfV6j6sv6TcmWdykRXutWa9m2vh-ZZMM5p2CIlaOeIlzqXwYPIp53B9UkD-SrzE
  oTdVQZ7Ay6xz7lw8kV5tlgqYSA9di8c5piEW0l6QYWIqS6I6XP886EFwmdzoUdu2u
  qh905LDXsKk7Q9CJXligCKdWQY3QXwNlX0lEPbNf2pRpqwh_tPD017Tt2BQT5oeJU
  kugXUqNXlbpvM1VG2AsaortWvErVc5IFnjQMbzfm6nww0nY-6RyXL5zWHYRs-CbQq
  -eeIpSINpUS3cVDwcodsxIGHsRg82ZSqtTrOd5fmISk1Y7syiq51QgknY2eHyGpLy
  zX7ZMbPM2ahjpEgtXr66FeKaKRN6xH33Xe087cWyy1Y8JjLywHPble8_Hdikm95C8
  tBuMcHWjVYz-6lTCNFMc7R6NscrFmtcIf6woxrQoXLaSaucToKwD9ErMhGNWMInnV
  oM_amSyg_s6JOiQ6iIzEPucidDkmyYgBokfkjubWxagepeaZzsmzccVjfNdziWQ0B
  EYituLNnjmvMZncqaVJwUz39Ajf3gUzGnkBSAn6RsppytcDr41miK8TH_BU_1xRJh
  u1TesiSKVmKxJiQ8ajIbjcvCCzogeJdVnoxTNMvaHMCjcoYWBZDYa1VvhRNfRL3Wm
  elzFAlyc_F2KOP_cAmuK2Hb1o2t1QYXFLmk93P2P-5YssVrx_Hu16Vg4tG9O2fHcb
  fJS4TbBCOO8fEtXmMKwTGYXsIPo5V6UIe9UyO5Gt4W5TSpU7eAQwE7Q3D_n1tiKet
  uH2r-1v1zvv5aASPJaxCtkGz3rvrGvRbmVab3oFQoJHHC1w3UEXZQcGDSttEtyQiM
  J9WyFG16F2YR_3DQPAAzSoq5p2n-d8SoJ6hj9NX-Hl7AoAfbr94FdR7yJsMbCGxoc
  9R5-LWrpbf9xLQXO3gF2rR7rkrfl2JseCxDEtXcg5VvqwReyFRsRPCKdFepJZShBz
  qOl1WIN4peOGLBioLb6kKVai1UMjcYADWslwpDMMlppJK5kO0OfigpuA2QnYu02Gz
  9DlGr4o4IF7Mdfhfgq1GlJm1Y6RR8bOWrYJgGzEl4SZWOfZa9il0ixwrNSSWmDsah
  1_pKBtdK0vs1jZFBHo70NQ35fwEMTE6kMLWNg33aQWG-qP-np3isvimb4s1q2NkX7
  lVwa3Ffe0M7pNnPuNg-XoQTXiN0LwIkxi2qLXSCJ8NUTXja5FGllwTlXC0o6TGoXJ
  3w_9zu8QrjQGUJIz2eyAsAK9LcjJ19IxPFLRJnJZMgivI6v5ik1EuM5KhrRbS7RuF
  EYixvf_W_DNEstVi900y7N5xJXm2qKowv3bdyRFpZ9tAWiz2JAp-83Z-vyqjmkV_F
  5ypR4S47PpXLtVn4pWDsEezPAN2W0rfv1zOtKItFS0vEKw5tKFPZ0TH3PPrBbeNKM
  Ss3a-KPWpo9RuZWZ2riAngaNOsiEy_M-kZeoSIvFP3iQR-wytDzb__ucOJljM4wTF
  aqdHTyWxNJuSVYwJX-R2MJfzmQrZWV3WJejjdGYrE4CfBsNbKnMNKFKEXX7m2jfmc
  kIu6xvGDbdTffIHK8gX5AihicrWduDx6CaBnQn8Pal-7OfCP6BC331dAM4Nhl6Jct
  JlHms6x94-VN8k5J3OaxzPoTQvxtDArW5b6PYoObd06FRAtGlyXY33kOIfAjYgetc
  haR-Eax5GpyqjlE20KjmWcxxrrAeAdQtKG-iFtCzZnRyauiPQyBdyzfSNZX3AbY5S
  gx1NZaaE803uVcHiHZR9rpFTLEBOLNhoc9aKv1_S1QUGpGLvqVTIyqJe-McNyRuFi
  GRR7Q0VW4rPkLTiI3ItB4ToDXBgA9ZmjQI80JYmb9n5SfNb4d0m42ba6ioNEseSR1
  USlnrCKFzngTzQ9W3rEgx9TobckBxInlSw_KfWEPNj3gyu4tWDCpvJAlp8ylVgirX
  QMFAdwiY_6ZSFst1N6C-CUy6iL4zT5NUCyUBd-cp-JxFkFji3HmGIm7dSMls08RbP
  kLimCmCi-ajI2QAFiPncL0DOV8k1bJBIsGxXAX8gLxFk-VBJ0GWQWyAvuP7razfJy
  9cUzKGejg1LOBHYR11kbWIHTkv-vZFLlLd9wpCJvaLQ1e8E-GdqEuXmkdaRVUESZ0
  2y7eYyCkHLztg1dh2POGb58107lf6tw4Xxc6BH4ag85kMPy5m5_8w9PHctC2DKNs3
  8x5Uw3peH_dGv0dE-q5BnLeyqxx2omc8f-GUAmHGMIoEkZ8_rmtI8e_T1TergTHg7
  e70Q5U8n-TRR7H5stHvbtb0MDrjCDMrXKvpTcwNgP6qu_TQd1ecJI9bz4II5rxLUR
  koWajOu7IZlpnwJiQ_MZEepFiXfs7fVBA1-VHKohWa-lh-l8ZMCKXVpXGiHtfZOU3
  q-kvuoUNC3hBP8glDEjhvRBiReld3YIhohIJ12vuM-5PSqbNK8oUzAdPvAsTs5Q0W
  TiVVW4f4LFeuCkrjcpaQqCSqcBEeFCoYHRULpKrfmxVhL9dn9Gy0geF6wU7WP5kFi
  LkkEv_tbzFWJzjy5nBuSuPbZ8IEwFSjnACAxTlGYo7j-dzPiaPmXluNrFaFQb7RVH
  nbL3bSeKamz5b2NdWIRUAWpso-g",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBFM-XW2H-CBLT-AMNQ-ZWVZ-USGI-KOGI",
              "signature":"vN5BI47huQJGHzBkY5q_YRlNcJv5FmRXmtoXf7
  cE0bWEcG-AZV_8k4JjahnS3SjMLXabTykfx6mASSfJlDS1S18dJUawx43EIGNwrK3
  tUV6Ru-_mFdWi7TFVugiFyssWFbyQEziHFEiwFtm7DV2hYC4A",
              "witness":"ZTO-tTTEJ4IaIAZ6OtN1btJ3QGkc-IodiU_hpG4k
  wqc"}
            ],
          "PayloadDigest":"jr16SNuo6R7iqlW4U2mSpk_cSYI_MiA3gifwcA
  0guHxMVwitUD5hJc85vtDtlHIjyoAdy3asUAH-8LAsJqhq3A"}
        ],
      "ApplicationEntries":[{
          "ApplicationEntrySsh":{
            "EnvelopedActivation":[{
                "enc":"A256CBC",
                "kid":"EBQE-HQVJ-QA7H-YAGO-BYU4-IH6Z-Z2SL",
                "Salt":"MiurURI50odmcsi7P3DXNg",
                "recipients":[{
                    "kid":"MBVR-KCMF-U3C5-43SH-VER4-SDCJ-RSBC",
                    "epk":{
                      "PublicKeyECDH":{
                        "crv":"X448",
                        "Public":"e5XJxceDPi9gehCuXBP78pMjEdIzn3h
  oBKjY_CFLaRkDkubOnlaMJEgIHJdoehqahSwBAePycqMA"}},
                    "wmk":"IF3NM39bgLesLGkme8oZvno1CLSv8QoIKwCneV
  _opNIRtJEj7qlS6g"}
                  ],
                "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3
  RpdmF0aW9uQXBwbGljYXRpb25Tc2giLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1
  tL29iamVjdCIsCiAgIkNyZWF0ZWQiOiAiMjAyMi0xMC0xOFQxMjo0ODoxM1oifQ"},
              "HtAMxJPSGlfWHo-mCyOQpqlOnoxkIAekUwi3OVuNWH4Ov04H9d
  -6G_4igTDlXoLNBE_LjYLII63111ZztfqWFby4TsGsrIuKBI4_Q2XRSyKW7C9XiXx
  PA5ekcXkkPRoejcd7QBay30HeQ_FuvmDvxMg4Z_94CTOUn2B3eCOCqiFOyugAks5E
  FB87h5lDghu1QWLCdUq6RVGdvx9TIFqtM3EizOElzDyjGHSbMFcXQPozC7cIUXBPV
  TZWEW-IuhAmABlArk788ksniY1-8Bta1mxeavOoZOYF09LSJCYXVZK-6yBODFTPIb
  NE4gjS15OB6lcNP_06zrb9b3jD3Ossb3PQUyyi1AMV1s98YhkcLeQVdA3fFIZQzLm
  6TMc0ns22e1KmAjO8yFY-PlkWA5WtyhIcvfO4AH6bDJTIhnq8IGbhDd3JZx2DRqpc
  vJVxayf8uYkzFs6AkGiy0f3mdcG8eI_Gr__4jgEMQrjK53UZrWkMnSDggZSA7LUxK
  IuMNcz68UBQ5WZSv1wNv6WprTUljLdTQZru34wC2pdhZ3cSNyAzojBlOBSviWeJPv
  56Olftb7yLfcLmMPOtX3OUbMTrFYaL4ElTzJRm6QBOj-GxF8K9Omhzo8RCNrwydh6
  US4H130GtSA3Eop76vVRNRYbVDX7hWdZVWB-un0bd0UFWh8nBj_KtEsrkr_ezS02x
  5o7hhPUT9mEAgZc2fYDBeaY3pCcOzMR7Mivo3TrKcU2YmbrU4wVR2skzvp75aR13h
  wD3u_de5Vy75WHFTPF0mAkaoZJU8SQDVOwHfIiTh88_DRWmXDu8p_acNH2aTfiWeP
  ZV5cPcDLj-Y3tpXphG0OohJgyRKcLpMCLyvo35nzp60E7CcPE_EnHtO-K_HzoOGi4
  i1wY5_eVetceYuDVvbc8gl1iAIslipSAsHtCGzJH51ClLfP-xwKWp8iYkqt6E4Skx
  OO7uVB8BgtP-H-ShtTNziQ-vjJIv-Y-_xC1Da4ycXHd-0-eMeKpxenl5BMecm_IOA
  EnRnxhDGEGUs4Ahqe-KkdGVTPT3Epvt2lLYBAiRBiyyBsMgThMp_2wjdWMfU7v5FI
  We_HU-kK3lnU-U8ZooBzkz0wIZll0RE2ExxIfUzHczJ2Myy3JbwrCqmGPB42F4Kel
  yJfNP4BjY5_tsmd5Qozboedqg-Fi4zcxe4Va5hraW3NVH1aGC1GwTXBDWyCIXUkop
  m-FCJsCAUmer2HbzLMYDUWUshIKs0uPyTaJLl5LitxKVoEwYhyvyf6gVvcT_gimV0
  _BmBvxKL2egKYAhiur07p3ZgxDC_V39Q2iC0AwnWuz3PveXYBEBfHNpaeVZ0b3OU7
  hqVQPKj1T92y5GcPzPMFwIvA9xQuAefBaEtauBOg8toQSZ0-IwztfWqlagJ3z-4BK
  EdIVE5-vISJNLRxbMEy9NgsiPH9dIPQDXBU2JuRsTdbOeMlBhagkm2-s__ceNaLyZ
  qRAuAgWEFvQBTIphxq3BElqlWPF-_FO2irodSr2aMBMyTJ6qNnLEbpEcXrrry0aUh
  7_ahyF1kGJGHfEcz0uVmNoB_Rn9nbme7Xdk4Xt3GhSyjZ6qVFoagG6Zk9HYElUUsm
  YLcLStX803M-YpwaNIcvmQPGDglYuX4M4rDJHrWaTxNbCJ5V2YAz2BsggzFE39zTC
  6TfU3E5o8eqU1V9zuX9gwfibFDsYmi9QcIgBzhFC8-8bJ6U-5qqMn_8r9HCYkIN1C
  me6ToSrRrKt5bnaDEkjdDq-5CtOD-TOlV1M3lApq4fbbETj8DL_RN3hBFJgimMfqO
  yiMP0aSit2g6Xa3vbT5jrjWGHUK5dNMNTDJL37sKV7hvx7S9uPe8msUKo_foBSG9k
  u9kSHQpz_vz_M1HZvaic7AORi_4DxVXwCIuvP2rQO1HvoSORdZz_ccI3dux2qBZUr
  kppLHDzVwSOl82rWdkwqzZh8cZCLXsEryWw5bj-tlZG45ja3quZxpPgvsTPtZQaPY
  LXxQBNRPM-vTUKRrwRyhu_E65mIO9QUKfDJzESCdfAFCyt-xbxajOS7IdQUw2MpWV
  PnCq-GjrGaTV1roiJHBE0uKiH89FaWcbVYzqk5jTVQZxZWLrWbFXShR-hohJtumD6
  rqqmiJWucDuAJSy-4oRJk2A6YRZII5YtIrm0u4cY-g5TFbZWOhrAOHrAv7MAn37bm
  31L8nXxCivFzOLpfPF0tL1HzfMO8WBq7ppXymXTHeISqjn2brLCA_5qS2GxaqqIly
  r7jg4-aNQk9SiT-G1tP8yjd9NBKGDji2Fd8Til6Khrlx1OhZubpaInDFrlt7mRTuG
  zYkoZm4TCUCBqg-kekRGbdfsKNBTNDVMuUKxZNzuQsP42F2xReOcumzXZIyAk0g8Z
  cD21dCxwBLa8o21bdYHZVOajcT3wM-mTL3eLoKHz9FgNCQwlWoh8XGuJhFr86zZxP
  dZoD8GwkkaVwwx7rcgQVPmYZdIKuXtCqe4264yu7QfiB31WswRrd2nPz76hqKhfSc
  cLHHt-HAkqTSp862OxaQVDnj9YNEpqhY5CO8vNKwzOPJVj6u3WbivCWf_bmgE3oqO
  Oeyhzt9RkXmrq5yIyAgoVv7LSOqoW1j2butgtPUqw7RPB-WKoI9V0zXnUUsANmBlJ
  015hLEzWhA8bWvWdN1QSURIe02cXEHUGli-_s5Ke-p05ynuTh5yPeQ7g5-KLJbZ2u
  qVCYdGR7zo5bF1aZDb5S_NMh2wph22V75xFV1Vzh0Z8inKKnvjLEzDESWskzCH0kA
  Y2S-qHq4kvMBD_XxTjbVa0a3tkChvoDjDa9kzzbdc9tfIbw9cHNZ4Dbz85KCLvv6J
  rbFfnpL1htS7cd_cFNVlsqkt1GQD33XPL5UwGnp7G2JKqtnnnH4NyhuVIw18IufG1
  1rNh1MxoWAJ9wvAE0U9s0vHZaBcwUF4fuW3H3uu-_8k1RrwKau-bnMUwT1ReYcuEU
  pW4-q8n3PCwfJETrUNzZEaW8990rwuE7iu4xz0N1ZStDMwI2bEyK1fGT_EY1szHLh
  AV-NZt0RvQfMtEgItLISaEnDRFSCePMP3ywokIAF4lfwO8MfTGkTop6HVGTJ79AxX
  o7qPMpcV_lnGPB_NqmxZ_jWwXmqzx2D-YQ0xAokurDGod-Kev1zjJqEf1YhBlqDQT
  Lfo_y1ClnZljTl7NmCmVc_fY6LOOgTfSU70IQRP6VOIYOAGBq594Ef0PEcjn23Ovx
  tZqHXVGpRXPLp8XS-fyrnxVS6QjTAkzO3G19UoSl24gT5ODyJXqVfkG6UksJC2R-G
  fqePYy7gMSqFyotbRuYBC4q60YOf"
              ],
            "Identifier":"MDCT-IRNQ-JDWH-IRIP-FZK2-YP4G-5MGS"}}
        ]},
    "MessageId":"MBI3-QJW4-3BIO-7SBZ-PEJP-E7NX-3W7E"}}
~~~~

### Phase 4

The device periodically polls for completion of the connection request using the
Complete transaction.

To provide a final check on the process, the command line tool presents the UDF of 
the account profile to which the device has connected if successful:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MDVU-AOST-TDIH-AXGE-WUJS-I56V-WJP3
   Account = alice@example.com
   Account UDF = MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
<cmd>Alice3> meshman account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MBI3-QJW4-3BIO-7SBZ-PEJP-E7NX-3W7E"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

