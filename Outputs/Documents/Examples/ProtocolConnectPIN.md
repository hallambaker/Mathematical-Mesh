
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=AA6O-HPNP-PHTZ-7VF7-XTNB-HK3C-3M
 (Expires=2021-12-19T01:57:23Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcu://alice@example.com/AA6O-HPNP-PHTZ-7VF7-XTNB-HK3C-3M
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AA6O-HPNP-PHTZ-7VF7-XTNB-HK3C-3M
<rsp>   Device UDF = MBVU-4YRX-NVFN-MH2G-QN7O-7ZYF-ARRH
   Witness value = IDQO-ZPKU-CPW3-4CBQ-TIQJ-CTAZ-E6MO
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "MessageId":"ND2W-OUMN-AB6F-WNZV-PAYJ-B53W-DJ2N",
    "AuthenticatedData":[{
        "EnvelopeId":"MBVU-4YRX-NVFN-MH2G-QN7O-7ZYF-ARRH",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlZVLTRZUlgtTl
  ZGTi1NSDJHLVFON08tN1pZRi1BUlJIIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTEyLTE4VDAxOjU3OjIzWiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUJWVS00WVJYLU5WRk4tTUgyRy1RTjdPLTdaWUY
  tQVJSSCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIkkyeUF5bmtJaXA5d045V0dDNDhLSV93N1BhWU1VTE93RUk2Ti
  1vdUpyRWZRWVVWVlhLTmYKICBmcUd1ZTR4WDdOWDhET0FjbGMxb1Z4QUEifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUNXRC0ySUVMLUg3UkEt
  Nk5TNy01VFNELUE1VFEtU1kzTSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiVkNuYU1xdm04NnotYm1Jem9pdmpKUUd
  US2JaVTMwT0RHcWhHV2t2YWpHZUFQdWMyMlBSZQogIEF6bVBUVGRCdDZiN1VZSi05
  d190LUptQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1BT
  UctQUs3RC1JUkVTLVBFQ04tS1BFSC0yUVdWLTJKTksiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJnY09jdFVXbTdQ
  eGppMm9UYm5XakNhY3JOSjNoYk9rbk9lNmt6RkFjOC1sZFZmYllIdHNpCiAgV2pjd
  2czc050Vk02akVPemktSlc0RGtBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQUY2LVlRUUYtQkNLRy1VNlhILVFUNDYtNVZKSi1GUlp
  DIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJSQlVkaWpHR3RXd3pldGNsU1JSb3QxLXVZMlRhdVN6cXJoblNBWUFKTW
  xpejVVS1MteDVUCiAgcFgzcmRZYmlQTmlpcDdadWNsRk8ySzhBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBVU-4YRX-NVFN-MH2G-QN7O-7ZYF-ARRH",
            "signature":"vOAnUwajN7-X5HStgUSXJWsSI4Rh2IPY2t7NuWmw
  5jhP2AaXHkO32kGdpy7j7Q29dTocdOx2AcmAcyAaiXAaj9DNfXCoMGPeJoL_7f1VY
  hQj2VgcaxF30qoShyL6rEcWAiQf1VgusE1yAqIvdTbkLyIA"}
          ],
        "PayloadDigest":"igzxEAtq4wVixXCdWelFvK3VB-GUEqk6QPBKNX5H
  ZWo_rlABpERBKvrBJyv9cdzL1QuZ8PmhJUkmqT_IIRCNYg"}
      ],
    "ClientNonce":"wVjiyy7Sv9lsOQ26fExhAg",
    "PinId":"ACEM-JHJW-YGOY-QOIY-FXNY-I566-KLRU",
    "PinWitness":"9JvxSwm17RVwUPmpZdY9iLId6Bwx2gndnWyu2Y3uD3ChJIH
  5mX7dEhEx70mBqKzVi4mrhzcLOEcyqQzecbJR7Q",
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
    "MessageId":"IDQO-ZPKU-CPW3-4CBQ-TIQJ-CTAZ-E6MO",
    "EnvelopedRequestConnection":[{
        "EnvelopeId":"MDCR-C3LE-J6PD-CAWK-UZY7-4MVI-JPQV",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORDJXLU9VTU4tQU
  I2Ri1XTlpWLVBBWUotQjUzVy1ESjJOIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyMS0xMi0xOFQwMTo1NzoyM1oifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJNZXNzYWdlSWQiOi
  AiTkQyVy1PVU1OLUFCNkYtV05aVi1QQVlKLUI1M1ctREoyTiIsCiAgICAiQXV0aGV
  udGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1CVlUtNFlS
  WC1OVkZOLU1IMkctUU43Ty03WllGLUFSUkgiLAogICAgICAgICJkaWciOiAiUzUxM
  iIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI6ICJld29nSUNKVmJtbHhkV1ZKWk
  NJNklDSk5RbFpWTFRSWlVsZ3RUbFpHVGkxCiAgTlNESkhMVkZPTjA4dE4xcFpSaTF
  CVWxKSUlpd0tJQ0FpVFdWemMyRm5aVlI1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxk
  bWxqWlNJc0NpQWdJbU4wZVNJNklDSmhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV
  04wSWl3S0lDQQogIGlRM0psWVhSbFpDSTZJQ0l5TURJeExURXlMVEU0VkRBeE9qVT
  NPakl6V2lKOSJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V
  3b2dJQ0FnSWxCeWIyWgogIHBiR1ZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNK
  VlpHWWlPaUFpVFVKV1ZTMDBXVkpZTFU1V1JrNHRUCiAgVWd5UnkxUlRqZFBMVGRhV
  1VZdFFWSlNTQ0lzQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KIC
  BnZXdvZ0lDQWdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0F
  nSUNBZ0ltTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmli
  R2xqSWpvZ0lra3llVUY1Ym10SmFYQTVkMDQ1VjBkCiAgRE5EaExTVjkzTjFCaFdVM
  VZURTkzUlVrMlRpMXZkVXB5UldaUldWVldWbGhMVG1ZS0lDQm1jVWQxWlRSNFcKIC
  BEZE9XRGhFVDBGamJHTXhiMVo0UVVFaWZYMTlMQW9nSUNBZ0lrVnVZM0o1Y0hScGI
  yNGlPaUI3Q2lBZ0lDQQogIGdJQ0pWWkdZaU9pQWlUVU5YUkMweVNVVk1MVWczVWtF
  dE5rNVROeTAxVkZORUxVRTFWRkV0VTFrelRTSXNDCiAgaUFnSUNBZ0lDSlFkV0pzY
  VdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGwKIC
  BGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0F
  nSUNBZ0lDQWdJQ0pRZAogIFdKc2FXTWlPaUFpVmtOdVlVMXhkbTA0Tm5vdFltMUpl
  bTlwZG1wS1VVZFVTMkphVlRNd1QwUkhjV2hIVjJ0CiAgMllXcEhaVUZRZFdNeU1sQ
  lNaUW9nSUVGNmJWQlVWR1JDZERaaU4xVlpTaTA1ZDE5MExVcHRRU0o5Zlgwc0MKIC
  BpQWdJQ0FpVTJsbmJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxQlR
  VY3RRVXMzUkMxSlVrVgogIFRMVkJGUTA0dFMxQkZTQzB5VVZkV0xUSktUa3NpTEFv
  Z0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljCiAgeUk2SUhzS0lDQWdJQ0FnS
  UNBaVVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjblkKIC
  BpT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSm5ZMDl
  qZEZWWGJUZFFlR3BwTQogIG05VVltNVhha05oWTNKT1NqTm9ZazlyYms5bE5tdDZS
  a0ZqT0Mxc1pGWm1ZbGxJZEhOcENpQWdWMnBqZDJjCiAgemMwNTBWazAyYWtWUGVta
  3RTbGMwUkd0QkluMTlmU3dLSUNBZ0lDSkJkWFJvWlc1MGFXTmhkR2x2YmlJNkkKIC
  BIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlFVWTJMVmxSVVVZdFFrTkxSeTFWTmxoSUx
  WRlVORFl0TlZaS1NpMQogIEdVbHBESWl3S0lDQWdJQ0FnSWxCMVlteHBZMUJoY21G
  dFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZCiAgbXhwWTB0bGVVVkRSRWdpT
  2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0lsZzBORGdpTEFvZ0lDQWdJQ0EKIC
  BnSUNBZ0lsQjFZbXhwWXlJNklDSlNRbFZrYVdwSFIzUlhkM3BsZEdOc1UxSlNiM1F
  4TFhWWk1sUmhkVk42YwogIFhKb2JsTkJXVUZLVFd4cGVqVlZTMU10ZURWVUNpQWdj
  Rmd6Y21SWlltbFFUbWxwY0RkYWRXTnNSazh5U3poCiAgQkluMTlmWDE5IiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6IC
  JTNTEyIiwKICAgICAgICAgICAgImtpZCI6ICJNQlZVLTRZUlgtTlZGTi1NSDJHLVF
  ON08tN1pZRi1BUlJIIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJ2T0FuVXdh
  ak43LVg1SFN0Z1VTWEpXc1NJNFJoMklQWTJ0N051V213NWpoUDJBYVhICiAga08zM
  mtHZHB5N2o3UTI5ZFRvY2RPeDJBY21BY3lBYWlYQWFqOUROZlhDb01HUGVKb0xfN2
  YxVlloUWoyVmcKICBjYXhGMzBxb1NoeUw2ckVjV0FpUWYxVmd1c0UxeUFxSXZkVGJ
  rTHlJQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJpZ3p4RUF0cTR3Vml4
  WENkV2VsRnZLM1ZCLUdVRXFrNlFQQktOWDVIWldvX3IKICBsQUJwRVJCS3ZyQkp5d
  jljZHpMMVF1WjhQbWhKVWttcVRfSUlSQ05ZZyJ9XSwKICAgICJDbGllbnROb25jZS
  I6ICJ3VmppeXk3U3Y5bHNPUTI2ZkV4aEFnIiwKICAgICJQaW5JZCI6ICJBQ0VNLUp
  ISlctWUdPWS1RT0lZLUZYTlktSTU2Ni1LTFJVIiwKICAgICJQaW5XaXRuZXNzIjog
  IjlKdnhTd20xN1JWd1VQbXBaZFk5aUxJZDZCd3gyZ25kbld5dTJZM3VEM0NoSklIN
  QogIG1YN2RFaEV4NzBtQnFLelZpNG1yaHpjTE9FY3lxUXplY2JKUjdRIiwKICAgIC
  JBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"
      ],
    "ServerNonce":"ezA8Iqg75x3DpEdvbWvW5g",
    "Witness":"IDQO-ZPKU-CPW3-4CBQ-TIQJ-CTAZ-E6MO"}}
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
<rsp>MessageID: IDQO-ZPKU-CPW3-4CBQ-TIQJ-CTAZ-E6MO
        Connection Request::
        MessageID: IDQO-ZPKU-CPW3-4CBQ-TIQJ-CTAZ-E6MO
        To:  From: 
        Device:  MBVU-4YRX-NVFN-MH2G-QN7O-7ZYF-ARRH
        Witness: IDQO-ZPKU-CPW3-4CBQ-TIQJ-CTAZ-E6MO
MessageID: NDZE-G3GP-G45D-WAOM-SXOH-24EC-JED2
        Group invitation::
        MessageID: NDZE-G3GP-G45D-WAOM-SXOH-24EC-JED2
        To: alice@example.com From: alice@example.com
MessageID: NDLR-BUDO-M7WU-JBTA-W4G2-AAOU-4NJB
        Confirmation Request::
        MessageID: NDLR-BUDO-M7WU-JBTA-W4G2-AAOU-4NJB
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDCL-O2LD-ODCU-MB2I-6EY3-RXRR-OSSK
        Contact Request::
        MessageID: NDCL-O2LD-ODCU-MB2I-6EY3-RXRR-OSSK
        To: alice@example.com From: bob@example.com
        PIN: AB3F-U7X5-Q2PE-ESFS-S2PH-7AGC-TKBA
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
    "MessageId":"MALU-6DHO-SPML-BFSU-TFID-VN2E-PPSA",
    "Result":"Accept",
    "CatalogedDevice":{
      "DeviceUdf":"MBVU-4YRX-NVFN-MH2G-QN7O-7ZYF-ARRH",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ0YyLVdZN0Et
  WUhMUi1XMk4zLTRHWEYtNFBVTy1aTzdOIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyMS0xMi0xOFQwMTo1NzowM1oifQ"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJl
  IjogewogICAgICAiVWRmIjogIk1DRjItV1k3QS1ZSExSLVcyTjMtNEdYRi00UFVPL
  VpPN04iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibG
  ljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJhLVhwem9xSkN5M2k2Mjlxakp3Znh1MUdtLWp6a3ZSY2pfUDVP
  eFJOMXM2blpNSzdzb0dkCiAgQnR6UXpQck80eUFaQmRMcHhRdkZ2Sm9BIn19fSwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2
  VydmljZVVkZiI6ICJNQVdXLUQzVDYtVDVDNS1QN1NRLVFEWUYtSkdENy1LSEhVIiw
  KICAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1ETUgtRzQ0
  VS00WjM1LU1JVlktSVVGSC1TQ1Y2LTM0R1kiLAogICAgICAiUHVibGljUGFyYW1ld
  GVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcn
  YiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIlFvNXA0LXlBWUhzZUx0XzB
  LOVIxbkQ2ZzNEa044UjF1UDNVbkhfdDJLaUJkWTM5WlpsVEUKICBhZ0dfc0hyajlP
  THQ2WmdkM0ZHNTQ5OEEifX19LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogI
  CAgICAiVWRmIjogIk1ETk0tUFpSRy1XTjVGLTJHVzQtUVNINi1YRVkyLUJFSEMiLA
  ogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUN
  ESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGlj
  IjogImp5Si1Vd3lhUThON2VpVUhVVnNvNDVuZ2RuWlpFbGkwdFdIUmE5QXdtTi1WV
  EdWaGtVb3EKICBoZnU2eEpza05wWVhDODV4cU9DTjREd0EifX19LAogICAgIkFkbW
  luaXN0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTUFBMi1HTkI0LVJ
  FVkQtRldLSS1RNUw3LTdESVMtSUpQUyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJz
  IjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6I
  CJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIktzNUJrR0hhblA0bGR4eFI0Qj
  ZkSmV2LVFwTFlEd01XYm5ITGd2czEyd2R6UTJCbEtSSV8KICBXdlhiWlpYYWhxWFF
  pM1JHMWhlVG1JZ0EifX19LAogICAgIkFjY291bnRBdXRoZW50aWNhdGlvbiI6IHsK
  ICAgICAgIlVkZiI6ICJNRElQLVVQUVYtNEg3WC1JQVJWLVg0NUQtRzVSUC1NVUtHI
  iwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleU
  VDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Ymx
  pYyI6ICJKdlVuems2Yko1bFFxYklZV2duREpCd2ZiSURsTTdfY3pzSmZxVE03WHpJ
  Rm4zeTd3ZU9aCiAgNDI2aGFXN2dkWXhMZDd5aTN1U3I1SFdBIn19fSwKICAgICJBY
  2NvdW50U2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1ETzItU05QVC1INVpZLV
  U1SEstQlBDNS1NVkdGLVdIVDQiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0
  NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICIyb1VReG9rM2FnZnViREdBbzBkNVpnc
  TdnZzNGQnFmTGx4Q3VacGxicjV5UzNGdDhBblJWCiAgNTdETWVDek50S1RTVlZnVj
  RhbnEwd1FBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N",
              "signature":"_aICFGYCm-j7vQxb3pSuluFLw7mV-xHAT7Muny
  oRj4nrMPcLiSnXsrgJEPf5nKqStCXCtWnaigiAeOCJQDgdjN8l3V5ES75xMokUCmX
  BHSd_GeVpwBMfrj8TW13in_AG0RXfEsDoomPncQm_33U28DUA"}
            ],
          "PayloadDigest":"ZAIkZVpaK57pD_WVl5s0sflP4vxt1AIIIO1g3b
  NDejldQ55TKy979S1_KAdEZzpZAEMDdo16brvW8Z2mqSphkQ"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MBVU-4YRX-NVFN-MH2G-QN7O-7ZYF-ARRH",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlZVLTRZUlgt
  TlZGTi1NSDJHLVFON08tN1pZRi1BUlJIIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDIxLTEyLTE4VDAxOjU3OjIzWiJ9"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1
  cmUiOiB7CiAgICAgICJVZGYiOiAiTUJWVS00WVJYLU5WRk4tTUgyRy1RTjdPLTdaW
  UYtQVJSSCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdW
  JsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICA
  gICAiUHVibGljIjogIkkyeUF5bmtJaXA5d045V0dDNDhLSV93N1BhWU1VTE93RUk2
  Ti1vdUpyRWZRWVVWVlhLTmYKICBmcUd1ZTR4WDdOWDhET0FjbGMxb1Z4QUEifX19L
  AogICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUNXRC0ySUVMLUg3Uk
  EtNk5TNy01VFNELUE1VFEtU1kzTSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjo
  gewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJY
  NDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiVkNuYU1xdm04NnotYm1Jem9pdmpKU
  UdUS2JaVTMwT0RHcWhHV2t2YWpHZUFQdWMyMlBSZQogIEF6bVBUVGRCdDZiN1VZSi
  05d190LUptQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1
  BTUctQUs3RC1JUkVTLVBFQ04tS1BFSC0yUVdWLTJKTksiLAogICAgICAiUHVibGlj
  UGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgI
  CAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJnY09jdFVXbT
  dQeGppMm9UYm5XakNhY3JOSjNoYk9rbk9lNmt6RkFjOC1sZFZmYllIdHNpCiAgV2p
  jd2czc050Vk02akVPemktSlc0RGtBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6
  IHsKICAgICAgIlVkZiI6ICJNQUY2LVlRUUYtQkNLRy1VNlhILVFUNDYtNVZKSi1GU
  lpDIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0
  tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB
  1YmxpYyI6ICJSQlVkaWpHR3RXd3pldGNsU1JSb3QxLXVZMlRhdVN6cXJoblNBWUFK
  TWxpejVVS1MteDVUCiAgcFgzcmRZYmlQTmlpcDdadWNsRk8ySzhBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBVU-4YRX-NVFN-MH2G-QN7O-7ZYF-ARRH",
              "signature":"vOAnUwajN7-X5HStgUSXJWsSI4Rh2IPY2t7NuW
  mw5jhP2AaXHkO32kGdpy7j7Q29dTocdOx2AcmAcyAaiXAaj9DNfXCoMGPeJoL_7f1
  VYhQj2VgcaxF30qoShyL6rEcWAiQf1VgusE1yAqIvdTbkLyIA"}
            ],
          "PayloadDigest":"igzxEAtq4wVixXCdWelFvK3VB-GUEqk6QPBKNX
  5HZWo_rlABpERBKvrBJyv9cdzL1QuZ8PmhJUkmqT_IIRCNYg"}
        ],
      "EnvelopedConnectionAddress":[{
          "dig":"S512"},
        "e7QRQ29ubmVjdGlvbkFkZHJlc3N7tA5BdXRoZW50aWNhdGlvbnu0EFB1
  YmxpY1BhcmFtZXRlcnN7tA1QdWJsaWNLZXlFQ0RIe7QDY3J2gARYNDQ4tAZQdWJsa
  WOIOXVa-9Z1CD4_Hk-PUv322kgjyrg_AT68CrvVf5FhGP0ivy7--Dk7TSSAFnWnlb
  ESVq6dGMpDn0C4AH19fbQHQWNjb3VudIARYWxpY2VAZXhhbXBsZS5jb219fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAA2-GNB4-REVD-FWKI-Q5L7-7DIS-IJPS",
              "signature":"YpSUPu1Mrea4NRTQqKX594Azkdv2HVI6lrajxi
  BGKHbpwZgYeTDI1HTnY0VoYd1z50R29OPlBa4ADeAsjujZo2SOCjOARCoQc2qMhCn
  8z_t6zlMfhB0ThyHglIeE0fBu17tRtmzL3T_NiPzUIKCVCB8A"}
            ]}
        ],
      "EnvelopedConnectionService":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTEyLTE4VDAxOjU3OjI0WiJ9"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tA5BdXRoZW50aWNhdGlvbnu0A1Vk
  ZoAiTUI2TC02RTc0LVlFQ0stSVZQTi0zTFVJLUNTNE0tU01YRbQQUHVibGljUGFyY
  W1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1YmxpY4g5dVr71n
  UIPj8eT49S_fbaSCPKuD8BPrwKu9V_kWEY_SK_Lv74OTtNJIAWdaeVsRJWrp0YykO
  fQLgAfX19fX0",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAA2-GNB4-REVD-FWKI-Q5L7-7DIS-IJPS",
              "signature":"WpIhEPXpVBwhTczm3ADRkljJuyfyBHFhvlmd9Y
  jr96TZ2nZi5dRIJFjWmSv8lcT1qAUu9EZ3UPGAwoneIAPorD4UXfPZla-E3u31Tuk
  83nhD_RXgzas-LnP-AozJSehDy1czpnhwM4pEEd6SW_AsYwEA"}
            ],
          "PayloadDigest":"stcDfllMqCu-KdrU4-fNy-q9ck_dESlirnyAjx
  a5am-2x9Uaqwae0ImZhvo9Gq_zDWboRSnK3Bx3xtxRNamn2Q"}
        ],
      "EnvelopedConnectionDevice":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMTItMThUMDE6NTc6MjRaIn0"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0DkF1dGhlbnRpY2F0aW9ue7QDVWRm
  gCJNQjZMLTZFNzQtWUVDSy1JVlBOLTNMVUktQ1M0TS1TTVhFtBBQdWJsaWNQYXJhb
  WV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibGljiDl1WvvWdQ
  g-Px5Pj1L99tpII8q4PwE-vAq71X-RYRj9Ir8u_vg5O00kgBZ1p5WxElaunRjKQ59
  AuAB9fX20BVJvbGVzW4AJdGhyZXNob2xkXbQJU2lnbmF0dXJle7QDVWRmgCJNQklP
  LUNIVUctUTUzRC1SNkZILUdLTzctWERGNi1VSUgytBBQdWJsaWNQYXJhbWV0ZXJze
  7QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0NDi0BlB1YmxpY4g5NpRX4GyAsL5A6v
  X6Be2IxMRU-86e1Z9cowAJ9lNWzih-d_DKzb69vj6K0Vc5rlieUtZmVFv0RN6AfX1
  9tApFbmNyeXB0aW9ue7QDVWRmgCJNREhVLTVHN0QtMzdFUS1ITlBLLUxZSlEtTUtV
  Ui0zT1RHtBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEW
  DQ0OLQGUHVibGljiDngH0rMX6eYlY-nsdBePK9GtCjbctv4vSOiRAamHDAol6g6aK
  3y8IYW_diS1ReH6hlZ-AGsObvQ94B9fX19fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAA2-GNB4-REVD-FWKI-Q5L7-7DIS-IJPS",
              "signature":"zsa5ISzdkWOsdODuY-hrui_d-OwrvKvp-H1M2g
  WNQXxQLY59dFjgGwLgE4HgKcHs2idktOfUGSaAKvHNHfK_GKNNed_4xPJdIE2ZpXB
  xsOoAK97_UIP9RpJqUQ61cISTn5t1ivBgiYtt4wKsc4bA4iMA"}
            ],
          "PayloadDigest":"L9YcRU3qPgB1ujokF0n8dRBZQVlc8ZJYYRy4Oo
  DKAe8-d2vl-HabTjpsLzin3OJm73GryRshPupN4oGb4zSBCQ"}
        ],
      "EnvelopedActivationDevice":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQN-GOZY-362R-WPKF-ZT3X-OO6J-SL7U",
          "Salt":"Lte2rIWF8u4qe6hsgdomTQ",
          "recipients":[{
              "kid":"MCWD-2IEL-H7RA-6NS7-5TSD-A5TQ-SY3M",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"XvRNxDFtMthy7O5O38BigvLa8_QsYUWHJJyXt
  znR1pFf2PR_WEca2XUhSzhWnFZmZsrrBjcuPGgA"}},
              "wmk":"0z0p2U5r4MIa4NioM8Hg0QsF0AT3aNDWyBa_B2b3FoL4
  at1pZbGmzQ"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMTItMThUMDE6NTc6MjRaIn0"},
        "gpxkQ02JlSfszS4xBJraz4hJUqXgKQutEYKp6Z2qibYvbU-rru_-sfRN
  _T0Q_ebBUvCwKJELr39SpYRyFc0DE0WjAH5SSVSBBB91r5gkmTlUdLISr9D2ifkOy
  I1NAeGV1X48RRPK6s6IzhvGQJ2WYcRQAFmWKzDnLNvWPE1ENC15ncVISmP6X-29Rf
  li7hOqWwEIbv3rSuNUKzlsmBPo6ryDBSzeOs-oUb_GDg_rHg4rtW9LRkTFOe_y0R5
  Emq9k",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAA2-GNB4-REVD-FWKI-Q5L7-7DIS-IJPS",
              "signature":"vATy02gCjK2BbhLKwntSr2TPt4vWkH8_7K6TuL
  oYlwFhSbzgclF92RRPEKHCjcTDf4BDBHMPyyuAs56oG6X0-vPtOVeqlRy33eSpPn2
  wDpkJZIUsiNBUyds0niFRKRRfSNV-sd5tlQGTFKeNdG_a9BQA",
              "witness":"VJm9iv-lNUwAimMpBTyIOIxxPGTBXs-QNzoCX8u6
  dlM"}
            ],
          "PayloadDigest":"l0jhA3ETdOv5pvu1EbjidnSynKpn-oDYpIb148
  77t6rp0WLkK-KGVZz52I_W-CsIYUCOLxUD1NVQx9hckbbCKg"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQB-AEZO-EDHP-YCZK-3FKR-S2GU-6U4Y",
          "Salt":"eEEG0VpJAo5HgFEtQEIihQ",
          "recipients":[{
              "kid":"MDHU-5G7D-37EQ-HNPK-LYJQ-MKUR-3OTG",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"bs061aSPIp0wG2rcXYRKtkmjzYDoeOR4E7X0c
  cPA-MY92HZJSOqcnvtJ9y2_dk798b-ep5AzFogA"}},
              "wmk":"f-BcuaIwcvFTKSKqrR3xWSlbvFzdMxzuzbPZFqVAJDE5
  ifZZoTOBkg"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTEyLTE4VDAxOjU3OjI0WiJ9"},
        "JZfzyeciIGHITKDKDJT1gKzN63_RAYQ6JJHPmbmshHrKpCQdAdkvmSqY
  XcmbLzJXqrEo30lM-IVyXSYvytdZ8i8OSI9zL9lIGZKmHq0HS9TH6axGOizIgUE5S
  fA_p1VS3dIVq5eBlWwW11W4eYTjZ2xLBdYSDg_d2HxSFyu6dCyFejTDq-llw9ig3w
  JvmagvrJeZKCOILm8n_r3rO039E0NXyPgU2_zHc7rMY92OmFbbWauoLMrwtk28VV5
  RAHa5Hi4RBPy2ERS-YiNKPJxuKPSRK-fFKGr0_W3N5dKz1o6c1YX97yPJTI-PG7G4
  eodL_rXXbfi8M4KnwikON_hG7IyhpPh8bDAOw_KT4rWcS9F_e8bYzYl0c9EWOqc2_
  j-AbAu2qpXZsCX04DCczu644lDOZ4zMiZhDKzjoYwnwGrD_Jqc3zRbT64fXYoUjCa
  uSdjp6Epah09cg4NerPo95GER15dihSgTlbBUvGqpvszmk7xtwv_j5HNr6B5zQqRy
  OBER4CcbX9PQsLhVJvSAI1o7j8-WuzrVP8yGFTseC8jXtMIX3YVI2WaW31eE_wNhV
  kfhJO5hWfilnoDH82Dg_eqsOa5Ju7_jJ-viKeV_WQKuJGljZLthvwyIHN4qqqtwJ4
  u2Unwa0GIW4lUb5mTeN5blz1s7dDsnLoY1xOWgfsCpg4uqYVSItw303B9qJkiXp_9
  us9XdKJbWqgeIvFieIA6skqQOLyLd-7BeIHq6rJoeAGeA_WhmY7uN8oVc4u4r00EP
  PCQdVgThBbJkQG1BlONpAAVrpxdlpfE-kRLzxsKBDjLqxsB_bwyEGYVqRrvnP2FhD
  2O3nQ_fmUANdvBXPOKh3Ey-o08rT5TvSQ7Crq9b0NQUeNN1is6cXERBGlmBvV9RiO
  CVpHxSlRC4SS3QdmW7vPdAU2RHg-eAhPYZcAJHUTh_nR_kQR0qC70nz8enmyUuHvG
  Jr75BrRTJRlnsDXLgV4wWae2BJ-FKcHIOmwJqU9MdMMN-rZjFCCoQNu9UP1fBc3Ur
  hryvE2XpMLxlAJ18D1LF77xXrt7TwD8PuFxdfSWyVOB6R8AQk7g1bfqFn8NnLa3_C
  2NZ3Ya91mLSUV2Ftxq9ptuV9TwiYeJQan2V4VXfgPNXtHreQwp_pXU9JE3exOzUhA
  5QW5b_G7exwpvyNrGO9XeDWEheDqj1g3pERIoO8T1Hp7Hg8SFmFIkshkLwBD10m3W
  foFVIQxccDjWPgKMTd7z60hfpgXXk-q5bGXuudzockhowcvqDcWaWNZAzQ8RsPGbq
  _HRUmLZpLjU2FtHMFD1K37iFSmJcQnn4ZUG4rgxE1iDMaq1F4PfMI-_HwAtWJpl3Z
  if0AFsSjZL4B4FYz7lGSNKBMjXDpqxvY0ehBAHGm7sCJ41tL0U5JIvTSINbf54J4h
  bf0VIOXUnN7sC2w-YwtsPg9SqfWHJ798VsehATQPYSvKE10SMvgBSrY_2lCbPbqPn
  nFSA-B8T3DlGPEH1ecqTlPVjkQQp_CmmmTIX1195r7eVkhJwBJeE4G6ME6WN-azJ7
  LzQfwn0gKtxmZAimw4i-c5w5ZYP6kTIFuO90-BHHEiwz7L2o4Aa1VzEw5hh3oQLho
  eCo-kSMAMQVJ_-V7PxM9KOTgIlajz_XQhbdqGpQfsL4uUoa0AoOzfiplIY39CgGqr
  uYbOYsDDAVXxFzftjvCM7j1JYWK-qrYmxh8_f9rXwClQ_s3enqe-XRIzEh4WwV0fh
  JB5Lj0Q5wS_hs59oLWlFg0VBxRWOu8Cm5SsE6VvbhDO3R1-RRMneaxW7h0O_D5Igx
  azNiGJ3DaMPQFTRCbX5bw_lmbkUHhAR2QLopVafyEB4RL835o-CjQ13jmDisVr8Ny
  OF2HAd_fbjEB-u8JsLqYOkDWxrX78W0uP3nremJCF8V4JdO30Z5ZF3bYPckN4Nv7v
  vyJenVWk41JvfosyhrnFfKfRX5bJxoYrjRo7OQGuRGXeIqe2DrNlhg0K8fp3xvkus
  4x01zUbCC4rpbzJwFOnLSioEyrNFUAUIEvyBqLRq9fGClZp-vhyMpMr2CZoPMXvGt
  A1g9AK8STL02ZmXAIBdq8Sd3OWaUxcU5zo-jQOyy5VL3WHNq502DAfeFKF7hhRI8F
  9cZVHMEydP4JyniQ6ry-yfaeswI5KWDo9V6R2EhxUz4BDcQeIc4j8IW8vbTdILEHP
  GOP7zTFxN5y-z4hPSqcppOY4Wn28YkdEW1avXMNYzYLPJnb7e8E9kA92oTYf51QH9
  wSh7diJVKdwGMbF1fxy2dOCQF5dKVKR6thf4EfjUIUEOHvB9DJiIrLnknftyVWnYR
  RFaLfkoffIQFubmV5eJtiMKlzENBQKuedcn28ZIWuMcvj1-TpZEdWi1zNTt1YyEk1
  Ww3moWXpN8Fl8L4cqjAFbjGwELXJwC6yzeBVsg16Iix3sfUt9bydptsAJiQTOisYF
  yxW22SkqOIY33LrrUQHrAo4pCsBr3tfuHlXZIj7oUhIWNntbvIjtby4E0ErXppz_6
  ZSFLe3OvgjpSZhAOZgtkapR4WmxUAZ46eWD4iAy2L3JfjPLaw0YO8XNGM-CTDxMcT
  riKe8Aa_F-XUYJKyxEHoXdYvQ3kk3eYijS6M8er90rR2LVdWH0iUfnu1AarGbvMuX
  b7zVVh9QpYHguPLD9LSpjxuTXlbMGHdIYNwNoLJywxXFbG8DP6_RSTnd8JhozKjJd
  OByrSjKwuCOD6W0tdupoymZR0a0nme4V7DZ2_czFSDLbDWu3YgGyJjHhVw31wAfoV
  ndLWG3vQ9EggtVM0HVqxeQfX9tocY1GANTVxmrtpyTTuHoYEg75D0-q0fdXO5NUCv
  vQEQ1iUKLl567JOUqSMHd0zenSggyj-KfZSte3MZevNBet1fHV6PpVFl5Vlo9iRm2
  1nt_IQ5BrkJ9fTA2ThiDEMRKyyNMkH6zuXm4d-ubG5rFZDp8mdPeebUIUh161XfLm
  SQ1ArrBTFXY0Aw4yglvRaFyQBsKCsXjBE0FDlJLfG6vwHedum4RhqONCrD718eRuz
  1E-SVyigE0z7ZsJ63Y2aXjkjD5dKSGNTXXtm_x7RdY9kOELD4TGpe6xpC0hQC4VE-
  eQzPzla6R-Lm8hVDdBc38qTppOIG7pa8I_YBo3EjvA0XGJqpWq-W2q9dNmMZnHPPB
  epdZQhyLrkkxDMcT96iWAwGVagfNQu4vvbIYDyDdy7bhJRpIV6JP-FDjdPj8n7QCn
  CtX5G_DmqP47yS_SU6swdrvtkLMUWHBj1AUXLtirswsFelEnKlu5lW_8Ey41is_eW
  bdWDqhaSZ5zmFFHMFOaFWPA0wGR8NXaXnLUIUQD1SDGWPXoQOFdbilv2X4zvlJtdU
  PrIOAv7W9AXIitdLS-uMhExoLtpPeWKmecL55BmonAzcL9rWRhgV1pQvmgtPiyJ5I
  bEflz15jTbbh-tCRSVYkipHLnJUcACtVZ36Ti165Jnf2AGwrB-qnYCVdCM2k4pf0s
  IRvbx4Ea-LhiqRHeuYE7MMjm9J41nvUMTx2mFg7rmqw62l9sWg6zFC6Yi9c3pzYkg
  pTwVHdIzfSAOPatslVaM4c-lESDHvtmnBTW9vZq4kET2z9mSp55UkzSfdtkbkhWrs
  DfK7uSSsER9ZOaRGG2U4FG198w73ArwRih1HmpJRp6RoDO8bZufJ2dyhiQ59ZdBJ0
  wTfwpQMJ2oso_b9HKZ_cDzba_oWby6yvAmTzX4yixn5-ri2ShKjtpNNlxJoRVX3nL
  EVG6IcWw3_XMt2gpNsCITP8BOO1jN6KJLoKzYQwy1Klseb9Fk5_nhXEuO85SoGwj-
  Xs5VqXidMLA899eOXLxHXGZ_ocZBv8Q11sjAqq_XqqLqrO3NrB1aM49iD-GZxN32I
  _EKr-y294tJQ2KVoO5ZWTRTPOr41PBsfsLqf1EAxOTcsc_XB-f7-730f5PbUtz-O8
  4L29mxvFELCyjhCPina-KgNrg1aQ0l5dVWQdPIJPdi4gwEAF2Jqh6pQkLfCDtDupJ
  W6TqP8PARNVLsobwfeITMXOh2b5yFpR_eQuhbIC3-N8alePkwAGaWPtyvHi0tfGwR
  9BBCBCvMVG1n3wB3P4S4fKwdmc13Tir_fSDnWxfKjXLL2mN2_B3yu2Usfpcya1572
  3vFJSkx_BvQUZ_N-HBXUkfbXhrioMyaC29SvIz3FxFU3P4gkWcis5wa5oiXAEutPE
  LvMCSuAZAc2eETZEjssmUYYv5LJSQh92hPYT98yQJeP-Jj9-dwFcuKqI1nGM-jgky
  VwGnyVXngkc-ABGB2jvFPcKXFqbjM0p4QXv54Pm6hHo_IZaREAUKKRlqB-TXK_ysC
  91y0oM5yKjnz67rbVqVh-gtm1ppZA074DRxW9BIwHp5Z2MJfjXhpzghFG1R50XJNr
  kzxS9BnEk2LZH7ZTJlz85WrmQVbu5STjkopz0yZZEyasWLPx9eq20NUwrccOPICJS
  a6tKom70VKMECQcnoIHna3ZZLFf4dJKYtoZQM5SYYQcnbiqmiM0jynbFNxgn0ur8_
  DMjb8wnwxQSlst2sHG_KQJ4BzxBMECkqm-6Q77-RTizIPt79Lx10nTGIYnqOpYnOb
  Hlby4DQCbVRNP4N1x58hXZ1xPVe27TI7GFbJeWaV6oxme-IQcbyhpucGtYItFwcTU
  l6k21AZW6_nNeljxnKA7QOYgvT-R_HgdWr05prBkGsmcIX_jcopGYuowBwbWg5BMU
  xbN9VNNmsEVrRODI3MEvu9xTIn1iVhiYogaYkYEru1gLreV3KFRfRxRnsbwBg76TD
  vqN5V1vDsTgWvDl4WSpGwr1ndxqlgzayKxc2tLH1tZnChtJY4eExwYC-_tM23R36S
  nQyCz5mivm8N3VhThhwQLcLcNqyS-bjjUuoUEtx215-yBr_tLNalE3Sy7Tmlqxy3U
  c8rGGM2xfpEXMLOiRoloE6RLlTKVPJbwh-vtQjAeoQmoGiWHpKOw8lvIfGYs-yc7l
  36N4P5YyrXOHQCMsOw5REJ4DX_kuPoXqvWsnN7Lx-jcQAea1hjbL_ZSt54js1WF1f
  _Ff_DKAA2eNSVMsNezbA4KEQtX9ISHTfw7g8qDOdrIUXOsVGX5zC7lyllcMHRHceh
  j18u3b0N85RJG7z0g2I7g0X4zflIFA3DsmsrBZy4UjhOB8kaoMosQ3SHi4hrpVzSF
  LuUl3vkjGTmY77PJ2UJnZJXPVGP261LHnTas0xXm84stCkV0vaGwYgnGg_SoegtUN
  i86i08zo37sCQN7fd5LhG2c7-5PmcDVLV5kRA4S8Ef3HnGoiKbQ6PzLqEWn8HyPvk
  lNn9-oDXlfTDiZbWOLHky3N1ABxQswLSkK60y4sAcMo6gKin4V4PyxXTCzc4Csgak
  tJcAcGAo_-rjp7c8cZfDNluE-KWMcoYSxf1qvtJH1ngRRLXaNQUGc1uQ0Plgrrg1X
  Q4MGZHEOYIrix-KZN30BezeivjCPWlWgSgDpSYNisyITXcggTryukNtk7eVaSLw9r
  -7in_MY0PuO5NJYIOELU8CY-97hDBNutr9iHSew3rfGpzLcxQNq0Bm0-pgkF8ugtQ
  sfZD4WNZbGWEreTUs9XTdHonc1UFTN1WpXm0eH9KyW6s0AyBxdTW-ATB-V1RdigZM
  lF-UWegpaKhN1KGEoIUWfNtgklPriewCAJX7i0JAsCDy823pzeOi3bVvoWhSLr5Sc
  o3Nd2Ctg6wHDIiN_vF4VdoGhmnjCi-esW7MBvQh5zj38EKAD-y5bv76ADWLu7DE4L
  5e4fLEv38Vq1NzPii9Jbmub4QmvCgCUVLvkHOYx0wV1V0nDtT8HgVz2BfU1LoortT
  KyXXPpcQ8qgsZGrNzW9rQP96KUaWBTwmuxBTPpJhEfzia5nazBqoTx2I_D6I6MIYB
  T9Qw3qm0L0uVViFkEXY_W_K0NPN9eKniYxxeGsPFPax2ckUX-z52A2lbC1hKv0eLr
  dUjkDd08ExBiekMEJ0Vw679DZiHBVS5DqU8YYiMqz0Fs7ITy_khR3KAZmAsowNa0I
  C70Gj97qsE7lJ_5WXOtfFenRsDVAs3TaqnOVNc3qclueCLjNKPQTibKfRbALzAgsx
  W_2Z3qkJl6st55G6norzh13QK4VSumXH-sAxvuMMS7w97epW1xA36-EGGyv5j-eUk
  oLIWjp5Bm6Zp1KwdKjfRGVh0AkDAP_rM3B5Hqwxwh4samqztXdtGrwhXu1fYCbnil
  Cty3xEYCHWSj4Hwwj0DI1UdeBU_vH6TdxN5p4Vqp5xdmaJyx-5YZzOwcB5HnuNZjX
  ibHNufDnzVNhN5b7XtzLt3DoNemXVYpLJ0exbC_rfcUcIgYm0jvOT0bx_adP8M-pd
  X6XyObxEFCZikvVc02V0h17FS1lTZweVuBeCQs3M8gox8dziINSFW6yiCCDHokSTY
  _ZbvyTm4eDEMQNb6z3Yp9F1vwgSt4VTb6sV_yTMaINmoq-AquCNQHj-fwKh8H-mco
  ePS-ZsOufA8fWqQ8m3bcHgq0K367O3uibAgmngrsyzRAN7ytLeTiqxNF3NegC3Mkk
  i8s4bJfmIrzqYlyycXcHmwupaMREqmN0LDbAu0DZ26z9Fyya1XLtxUZsqpLSM96CB
  H3zB6uWfF48kfYsBtIOW1IZGN7r9poLcfEYvldOT_qFvkpuxZSkDyL_I05lsJOXDc
  KfWOdLZEt2KTTZZNdBl89HBSUEshqxC9I93f85XLtomVBoYPww-2c766Gpx6lRNEz
  4-B9MgNYqd3zrNvImPDM5qcuDVSYrkcSBpyPrFFxEUWSI-rJYh0p_Zsra1Txrz4vO
  LoJU3EsKTbBQ8vi4SBIDyIEft503J-O6Xq4GdNGc7M1e1nfMwGTHaons57mHSBSGI
  qxKveOs4oXKTFwLe7TlakPlYui74GhemZLPcTJ1uPtCSFxSD0l99yea1jWr-W8-Wq
  FqZNSi0s05m25S9UQFm_2gqoGAWmB6Lt5C6dKcCA16OpqLig-ECCkL_kGv5A27dmM
  gRFWTJtkSXxave8gUCfGHv9tEL_a_JZSuOTni-gVJ2Hj0aANGQXLlzq81XKJ8jCKE
  uXMO5e2Vo4JAUZangw66FTcDTEr3rMgZ1JcK4-ivwIYWLdNRCvvZ8Hb6GvO9WBXEy
  nhHPBxb5XbzvBYfDCv5mHO25418rIQzo6oYoZzCQ6pajp0rrKCtql-BvJPFDGAZYs
  GlaKMdd5l-H9ZjV83tozMSSkoV1ySoBo0umL9IDa0OP1wtVaLTDWIjTlQkw7mywQO
  pFejm-vUc-A-LTVJCDt8gjWinx_lBVoE4T-eYVv0UtN_M5YsaZdWiHV2ZBdQjFiq0
  p8ri7Lld7WwWTZGcSroksDN24ac82wwA6UlSX1Mkzzf-luQTedcLly4JPbelnOfSY
  faQbKNcc22WdcGuK-FX6XWNOyNPjjmf1DjIokwkbKS_JDjdHD1TWdqGiw1BT48yOL
  if4l5JPEiAYe4COsOa34WSfmHxCp2TGR2tXHh5CzRub2sl-jys_z6NWCaKREFdY2M
  2H_XFVeCGjq7W8XN7Zpq_JnZgfzUyAlRq2A25-DFoOxF3Yb21hwIYDbVBuhChLm5Y
  80ZCGNcfolzPXNGBIfApREvCAko1bEJKHMqvq1P2kBQ5mNyNujZaqYADVxliVIJZh
  lpfGj-NTqZCTj6Yqk0evr2Hjt8mjaMc5BdpYeprUL05wen_i8qSHoy99w3L2Er2FO
  UatAVyASBRIm-g81Or9Ky4gGTpr4-SW9SdVjJmNI2f-CgHHeAaT0tM0Wh09wOEuX9
  rWy59fRLdQYaw7kkLnNwL0xDBoNDL5df8zVLKecXqQf20_cNcvyKQgx6-4NfO1fDP
  1ZCDPlNPLd0dM1PsgQoEEmyFM-Bdeiq0EwM7CXa6iyvq2f_VePH9SBKBZE0CRz-CJ
  uYy3xjf9QDzV2uYOJIezrF6_m004vNCjmrkLTubkbGQjO217ds1S7GDillRL828KM
  QM60teYesijYtvLZdw_Oz_bdr10W4mmOVgFaGbQ9SvR_bpcApxfWEhcBFa2-dwt8N
  x2gGZvZwCOe-LO9N9Sszsdizm5bPTdSjosVHic5MsbWAsvUoE7YWZRw5nXZ57nWKC
  wksDYTzlUV2VCLdVL4z-h7Zp_JrfsJyK2RiY70xm8q3QGx874BolcRO9lqcoaVZ68
  wCgdUNf4UCI_mFRV9UU8u1eppStuhdWTQaS03k8_YLRSnI-0l3CwzXetNG5TmEIux
  1Oqk6Am7z6Wvh6vCl1qZGkor1hHydrOkkpCdA27V6-xcGCeSCUebQg5Iv8t12BKHi
  pTcsqVAG5QK6xue4Nfu5fplPfHqAVyddgHtFsml73HOiPwr-Q4xw4y-Jzl-P5E49I
  Mwx1xWDKUj4JD8SBfRPyadsqHogzinTFmsuiyx9V5z_YvjyMwukj9b6hrDChN7_Wb
  UsixAuqxKabQwVFPmyA2hnVvTTzHZ6do9XK7HbBEh-DGYsmG-wNTZ3Oz8K1VKjx7p
  ue9W95z9-fSA56cHuFqkJwvW-MqgXNdNuPwN2pGaeEPI5u5QKMahepI46sM-TjnKY
  HizekozGMq4ax8LrqHk0L-6GQaQmtvCKTYOZP_fnTMVEaXVI",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAA2-GNB4-REVD-FWKI-Q5L7-7DIS-IJPS",
              "signature":"yfk3CPwgRumIEkPi9mcWoKuLWg8oqItf5eBW7c
  bkKlmmiNbo4AflJKY3SXCxOATG3YzY414QsVmAWBC2D-p6XCXOF-FblVC-X5fv4J4
  yucTVUAgzQs5uJrwUO5esriKZerV2HTZlsfHXkfknoZRRLSsA",
              "witness":"M4cs8lyu8lpGR1331xVJuYn5ShaPAi7K-tTQoVij
  acQ"}
            ],
          "PayloadDigest":"K7q0MrANyIoowgHwnVi3m1G6XFUVXQIRP9p_wI
  qsx4GiRF4OzliCGdNEpL93YysmuD_-oRUmW4NkH1QifvdYkA"}
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
<rsp>   Device UDF = MBVU-4YRX-NVFN-MH2G-QN7O-7ZYF-ARRH
   Account = alice@example.com
   Account UDF = MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N
<cmd>Alice3> meshman account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MALU-6DHO-SPML-BFSU-TFID-VN2E-PPSA"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

