
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=ABZQ-GFJC-V7RM-XIXD-DL7B-AVGD-54
 (Expires=2021-12-20T02:16:03Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcu://alice@example.com/ABZQ-GFJC-V7RM-XIXD-DL7B-AVGD-54
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    ABZQ-GFJC-V7RM-XIXD-DL7B-AVGD-54
<rsp>   Device UDF = MCQT-B7NG-QZ7M-4LXE-5AZN-W4A5-5FSF
   Witness value = HTUH-LKSI-ZPI3-SQ3Y-PHUH-MJ53-RTL2
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "MessageId":"NCLX-IAFM-Y73C-7BB6-PHQA-BGLO-WTOR",
    "AuthenticatedData":[{
        "EnvelopeId":"MCQT-B7NG-QZ7M-4LXE-5AZN-W4A5-5FSF",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ1FULUI3TkctUV
  o3TS00TFhFLTVBWk4tVzRBNS01RlNGIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTEyLTE5VDAyOjE2OjAzWiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUNRVC1CN05HLVFaN00tNExYRS01QVpOLVc0QTU
  tNUZTRiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogImNBbHhpYVAwbWktd204UFRMZUtiTThpb1JQMUZ6aVJOMDJzUE
  dVNDRnMC1LNGVSbVFTMlMKICAyMFA0NkVfNDhneUFqWEFjX0ljN0F4V0EifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUNWVS1VQTMyLVM1QkQt
  SzdHSC1IVFFILTNVQlItN1hCUSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiOUhiMGMyVXd0SXZ1MmQwVHlDNXNXejF
  IZ2k3S3FZQ0ppUWwtbUVuS2ZVU2NlcmtFaUlNcQogIDdqbW1VQ3ViWGY4TTJPVllx
  ZVM2NE9TQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DS
  TQtUkdLMy1EUE5ILVBPNjItWUozRC1JSTNLLUZRR0MiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJFTDc3Wmw5ZGNM
  STZPbGx1a3p3emRKRlNFNmRTTHROZGlMd3k0VXA0TWVZMk9SUGdWZkltCiAgYVhzb
  m5NVGQyWFgyM2tQSDhsY3hON1FBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNRDc0LVFHVVMtU1RaUC00Q0hPLUsyUkYtR05JQS0yRU5
  IIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJteGowVHMya2xJQ0M4MkYtSUVFaGl4UndyTXBtS1hWN29kbFl0d0p2cT
  JtYnZydGtjM1k1CiAgOFdyU3B3VG5zUGNGSENNclFKNFZDTXNBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCQT-B7NG-QZ7M-4LXE-5AZN-W4A5-5FSF",
            "signature":"M_mAeYiSyCoD8iDfGlhw6Ou9-W0eBK3exEYo-4Bi
  Vboa9zXUuK8Vq3rxd0F4c7Vqgkz1Twsyi3YAXyW9FqvzECnOX20fjZ_vuIHMDmm15
  bHdDGUrFyWshyhrVJmGzORIFbuNovIjTSb2GcllZDuuFi4A"}
          ],
        "PayloadDigest":"IUC-c6zRcF3NRt5_TnmFVG5oV_pXIjQOBn10JZvN
  K0KYCf6PJ6_7Uev3o0xyUMyoc8bbmlE1m4u1GcIc2Knt5Q"}
      ],
    "ClientNonce":"Gv62DLPwAHRiwhcf-FWGsw",
    "PinId":"ACUE-FBCM-67AA-KNQE-IXZ3-EWLN-E6F4",
    "PinWitness":"-Wr3AWio8WfSNF1PCvMIPXEgQ8Qc8pKjrqvOATnTSKL7KXT
  H65Uzh_KPgN5kJvPRlQ_cn8D4yRaGkPP8hwqYhw",
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
    "MessageId":"HTUH-LKSI-ZPI3-SQ3Y-PHUH-MJ53-RTL2",
    "EnvelopedRequestConnection":[{
        "EnvelopeId":"MCXO-DLAW-P7FU-5LSV-QTWC-6IK5-XJIM",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ0xYLUlBRk0tWT
  czQy03QkI2LVBIUUEtQkdMTy1XVE9SIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyMS0xMi0xOVQwMjoxNjowM1oifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJNZXNzYWdlSWQiOi
  AiTkNMWC1JQUZNLVk3M0MtN0JCNi1QSFFBLUJHTE8tV1RPUiIsCiAgICAiQXV0aGV
  udGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1DUVQtQjdO
  Ry1RWjdNLTRMWEUtNUFaTi1XNEE1LTVGU0YiLAogICAgICAgICJkaWciOiAiUzUxM
  iIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI6ICJld29nSUNKVmJtbHhkV1ZKWk
  NJNklDSk5RMUZVTFVJM1RrY3RVVm8zVFMwCiAgMFRGaEZMVFZCV2s0dFZ6UkJOUzA
  xUmxOR0lpd0tJQ0FpVFdWemMyRm5aVlI1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxk
  bWxqWlNJc0NpQWdJbU4wZVNJNklDSmhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV
  04wSWl3S0lDQQogIGlRM0psWVhSbFpDSTZJQ0l5TURJeExURXlMVEU1VkRBeU9qRT
  JPakF6V2lKOSJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V
  3b2dJQ0FnSWxCeWIyWgogIHBiR1ZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNK
  VlpHWWlPaUFpVFVOUlZDMUNOMDVITFZGYU4wMHROCiAgRXhZUlMwMVFWcE9MVmMwU
  VRVdE5VWlRSaUlzQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KIC
  BnZXdvZ0lDQWdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0F
  nSUNBZ0ltTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmli
  R2xqSWpvZ0ltTkJiSGhwWVZBd2JXa3RkMjA0VUZSCiAgTVpVdGlUVGhwYjFKUU1VW
  jZhVkpPTURKelVFZFZORFJuTUMxTE5HVlNiVkZUTWxNS0lDQXlNRkEwTmtWZk4KIC
  BEaG5lVUZxV0VGalgwbGpOMEY0VjBFaWZYMTlMQW9nSUNBZ0lrVnVZM0o1Y0hScGI
  yNGlPaUI3Q2lBZ0lDQQogIGdJQ0pWWkdZaU9pQWlUVU5XVlMxVlFUTXlMVk0xUWtR
  dFN6ZEhTQzFJVkZGSUxUTlZRbEl0TjFoQ1VTSXNDCiAgaUFnSUNBZ0lDSlFkV0pzY
  VdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGwKIC
  BGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0F
  nSUNBZ0lDQWdJQ0pRZAogIFdKc2FXTWlPaUFpT1VoaU1HTXlWWGQwU1haMU1tUXdW
  SGxETlhOWGVqRklaMmszUzNGWlEwcHBVV3d0YlVWCiAgdVMyWlZVMk5sY210RmFVb
  E5jUW9nSURkcWJXMVZRM1ZpV0dZNFRUSlBWbGx4WlZNMk5FOVRRU0o5Zlgwc0MKIC
  BpQWdJQ0FpVTJsbmJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxRFN
  UUXRVa2RMTXkxRVVFNQogIElMVkJQTmpJdFdVb3pSQzFKU1ROTExVWlJSME1pTEFv
  Z0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljCiAgeUk2SUhzS0lDQWdJQ0FnS
  UNBaVVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjblkKIC
  BpT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSkZURGM
  zV213NVpHTk1TVFpQYgogIEd4MWEzcDNlbVJLUmxORk5tUlRUSFJPWkdsTWQzazBW
  WEEwVFdWWk1rOVNVR2RXWmtsdENpQWdZVmh6Ym01CiAgTlZHUXlXRmd5TTJ0UVNEa
  HNZM2hPTjFGQkluMTlmU3dLSUNBZ0lDSkJkWFJvWlc1MGFXTmhkR2x2YmlJNkkKIC
  BIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlJEYzBMVkZIVlZNdFUxUmFVQzAwUTBoUEx
  Vc3lVa1l0UjA1SlFTMAogIHlSVTVJSWl3S0lDQWdJQ0FnSWxCMVlteHBZMUJoY21G
  dFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZCiAgbXhwWTB0bGVVVkRSRWdpT
  2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0lsZzBORGdpTEFvZ0lDQWdJQ0EKIC
  BnSUNBZ0lsQjFZbXhwWXlJNklDSnRlR293VkhNeWEyeEpRME00TWtZdFNVVkZhR2w
  0VW5keVRYQnRTMWhXTgogIDI5a2JGbDBkMHAyY1RKdFluWnlkR3RqTTFrMUNpQWdP
  RmR5VTNCM1ZHNXpVR05HU0VOTmNsRktORlpEVFhOCiAgQkluMTlmWDE5IiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6IC
  JTNTEyIiwKICAgICAgICAgICAgImtpZCI6ICJNQ1FULUI3TkctUVo3TS00TFhFLTV
  BWk4tVzRBNS01RlNGIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJNX21BZVlp
  U3lDb0Q4aURmR2xodzZPdTktVzBlQkszZXhFWW8tNEJpVmJvYTl6WFV1CiAgSzhWc
  TNyeGQwRjRjN1ZxZ2t6MVR3c3lpM1lBWHlXOUZxdnpFQ25PWDIwZmpaX3Z1SUhNRG
  1tMTViSGRER1UKICByRnlXc2h5aHJWSm1Hek9SSUZidU5vdklqVFNiMkdjbGxaRHV
  1Rmk0QSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJJVUMtYzZ6UmNGM05S
  dDVfVG5tRlZHNW9WX3BYSWpRT0JuMTBKWnZOSzBLWUMKICBmNlBKNl83VWV2M28we
  HlVTXlvYzhiYm1sRTFtNHUxR2NJYzJLbnQ1USJ9XSwKICAgICJDbGllbnROb25jZS
  I6ICJHdjYyRExQd0FIUml3aGNmLUZXR3N3IiwKICAgICJQaW5JZCI6ICJBQ1VFLUZ
  CQ00tNjdBQS1LTlFFLUlYWjMtRVdMTi1FNkY0IiwKICAgICJQaW5XaXRuZXNzIjog
  Ii1XcjNBV2lvOFdmU05GMVBDdk1JUFhFZ1E4UWM4cEtqcnF2T0FUblRTS0w3S1hUS
  AogIDY1VXpoX0tQZ041a0p2UFJsUV9jbjhENHlSYUdrUFA4aHdxWWh3IiwKICAgIC
  JBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"
      ],
    "ServerNonce":"iwM3kM_r_Jy9p7Mx5qIZ1g",
    "Witness":"HTUH-LKSI-ZPI3-SQ3Y-PHUH-MJ53-RTL2"}}
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
<rsp>MessageID: HTUH-LKSI-ZPI3-SQ3Y-PHUH-MJ53-RTL2
        Connection Request::
        MessageID: HTUH-LKSI-ZPI3-SQ3Y-PHUH-MJ53-RTL2
        To:  From: 
        Device:  MCQT-B7NG-QZ7M-4LXE-5AZN-W4A5-5FSF
        Witness: HTUH-LKSI-ZPI3-SQ3Y-PHUH-MJ53-RTL2
MessageID: NBKK-WDGA-Z36W-IOD6-HZBW-DSNB-2CR5
        Group invitation::
        MessageID: NBKK-WDGA-Z36W-IOD6-HZBW-DSNB-2CR5
        To: alice@example.com From: alice@example.com
MessageID: NBW3-QGBQ-U26Q-ECMH-3BAD-BYI5-7J4J
        Confirmation Request::
        MessageID: NBW3-QGBQ-U26Q-ECMH-3BAD-BYI5-7J4J
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDRW-AINC-CW2Z-REBY-UILU-O2EI-MZPK
        Contact Request::
        MessageID: NDRW-AINC-CW2Z-REBY-UILU-O2EI-MZPK
        To: alice@example.com From: bob@example.com
        PIN: ADXO-VQ4V-WNRY-WD65-PHYE-GK2E-TWZQ
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
    "MessageId":"MCY3-5C2F-4VFN-XOTT-AANK-474N-623W",
    "Result":"Accept",
    "CatalogedDevice":{
      "DeviceUdf":"MCQT-B7NG-QZ7M-4LXE-5AZN-W4A5-5FSF",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ0Y0LTZWVVQt
  Tk9QSy00VUlYLU41VkMtNk1ZRi1STVZUIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyMS0xMi0xOVQwMjoxNTo0NVoifQ"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJl
  IjogewogICAgICAiVWRmIjogIk1DRjQtNlZVVC1OT1BLLTRVSVgtTjVWQy02TVlGL
  VJNVlQiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibG
  ljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJyUHhRMEFua1NhaVhpVzJYZ3VERlhlbV9UbnRvbXQxZlN1QzZU
  aE9QRkdQNURUVGgyelRxCiAgUERCMlJmY3ZfNVlhUy1sUzlZU01HMGFBIn19fSwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2
  VydmljZVVkZiI6ICJNQ0FPLVhUSUItWVJONS1PWlk3LVBRWTItVjY3Ny1VVEJHIiw
  KICAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1BT0QtR1FE
  RS02UUFPLTUyTUItTjNJWC1NM1BOLVFIQ0YiLAogICAgICAiUHVibGljUGFyYW1ld
  GVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcn
  YiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogImtZTVM4OElBbHplRjNLeFo
  tblZLTDZJMHZQcnhfUTRlSVJEVHktWVFyMDRwQ2tQT3NvZ0kKICBHUUk2U3ZqM1RM
  S183XzBrek9lMFN3cUEifX19LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogI
  CAgICAiVWRmIjogIk1CM1ktNjVOVy1KTE5OLUlGSUMtU1lUTy01V1kzLVNDUjMiLA
  ogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUN
  ESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGlj
  IjogIjJ6RGcwZ21LbDlNc01VeWdJMUlBNnBvQUoySDI0TFdfQVI2S01SMkVna0xMc
  mtvMFFCa3AKICA4VThpN1c2akItcm1UN1ptelk0SzNRSUEifX19LAogICAgIkFkbW
  luaXN0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTUFZTC03QkI1LUR
  ISUwtVFhMNy1BWlczLUhSWkMtSlNZMiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJz
  IjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6I
  CJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIm8wZDlSRXNRS1dXM3o5R0FlT3
  lweFpQU2ptZVQ3N29nSkFzT2VEaGNwblpiaThZYjBJU3YKICBHWWEzVmxoZTI4Z2x
  HaVJ0MzhKb1h4cUEifX19LAogICAgIkFjY291bnRBdXRoZW50aWNhdGlvbiI6IHsK
  ICAgICAgIlVkZiI6ICJNQkNCLVNNTDUtVU02NS00TUdKLUtLU1ktWkdTVC03T1BaI
  iwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleU
  VDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Ymx
  pYyI6ICI3Ui1NTVpKWWdPRTlZQU5hX0h6SGN3QkR4Sk1XdHRJZHBjbmM5aXljT3RS
  czd5VWtnSEZ0CiAgaDNIZTFxeDBwQUpBQ25hTGlXMWdoN1FBIn19fSwKICAgICJBY
  2NvdW50U2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CU1ItR0tHNy1VRTNGLV
  MzTkwtQUFETC1WR1FWLUNHVVYiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0
  NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJnUjQwLVpqbzhXWDQ1ZUpXZmloQTVod
  G4xUW1kbTBoTkN5bE82M0d2bUlPSzlDYXQ4UHVkCiAgR0l0Rmxfd2J5WjVqV0lVeG
  Z1a3BHdUtBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT",
              "signature":"Yh8EcT-UwJ8HgNtyCmu9ZgHVu41ruVjgFIr5lx
  YMdK_mK8xlW9F0I6hXBt_ID4Md4P94El37LwwAz7hg_RxMP-uZc8ZUwdujzkFHZqX
  5vOg_CII1G6mSL8vtXv-cFJDvmpNThgnYJf17bVnlyuqCFDYA"}
            ],
          "PayloadDigest":"KpHTuJ52WMQkFglLSZGZzeSjXPMytoePwTEp8C
  JD8DJrly3G6LVVNo6NHZXpcwQ_35KfPOpqgKqSKJn_7GG19g"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MCQT-B7NG-QZ7M-4LXE-5AZN-W4A5-5FSF",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ1FULUI3Tkct
  UVo3TS00TFhFLTVBWk4tVzRBNS01RlNGIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDIxLTEyLTE5VDAyOjE2OjAzWiJ9"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1
  cmUiOiB7CiAgICAgICJVZGYiOiAiTUNRVC1CN05HLVFaN00tNExYRS01QVpOLVc0Q
  TUtNUZTRiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdW
  JsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICA
  gICAiUHVibGljIjogImNBbHhpYVAwbWktd204UFRMZUtiTThpb1JQMUZ6aVJOMDJz
  UEdVNDRnMC1LNGVSbVFTMlMKICAyMFA0NkVfNDhneUFqWEFjX0ljN0F4V0EifX19L
  AogICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUNWVS1VQTMyLVM1Qk
  QtSzdHSC1IVFFILTNVQlItN1hCUSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjo
  gewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJY
  NDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiOUhiMGMyVXd0SXZ1MmQwVHlDNXNXe
  jFIZ2k3S3FZQ0ppUWwtbUVuS2ZVU2NlcmtFaUlNcQogIDdqbW1VQ3ViWGY4TTJPVl
  lxZVM2NE9TQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1
  DSTQtUkdLMy1EUE5ILVBPNjItWUozRC1JSTNLLUZRR0MiLAogICAgICAiUHVibGlj
  UGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgI
  CAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJFTDc3Wmw5ZG
  NMSTZPbGx1a3p3emRKRlNFNmRTTHROZGlMd3k0VXA0TWVZMk9SUGdWZkltCiAgYVh
  zbm5NVGQyWFgyM2tQSDhsY3hON1FBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6
  IHsKICAgICAgIlVkZiI6ICJNRDc0LVFHVVMtU1RaUC00Q0hPLUsyUkYtR05JQS0yR
  U5IIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0
  tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB
  1YmxpYyI6ICJteGowVHMya2xJQ0M4MkYtSUVFaGl4UndyTXBtS1hWN29kbFl0d0p2
  cTJtYnZydGtjM1k1CiAgOFdyU3B3VG5zUGNGSENNclFKNFZDTXNBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCQT-B7NG-QZ7M-4LXE-5AZN-W4A5-5FSF",
              "signature":"M_mAeYiSyCoD8iDfGlhw6Ou9-W0eBK3exEYo-4
  BiVboa9zXUuK8Vq3rxd0F4c7Vqgkz1Twsyi3YAXyW9FqvzECnOX20fjZ_vuIHMDmm
  15bHdDGUrFyWshyhrVJmGzORIFbuNovIjTSb2GcllZDuuFi4A"}
            ],
          "PayloadDigest":"IUC-c6zRcF3NRt5_TnmFVG5oV_pXIjQOBn10JZ
  vNK0KYCf6PJ6_7Uev3o0xyUMyoc8bbmlE1m4u1GcIc2Knt5Q"}
        ],
      "EnvelopedConnectionAddress":[{
          "dig":"S512"},
        "e7QRQ29ubmVjdGlvbkFkZHJlc3N7tA5BdXRoZW50aWNhdGlvbnu0EFB1
  YmxpY1BhcmFtZXRlcnN7tA1QdWJsaWNLZXlFQ0RIe7QDY3J2gARYNDQ4tAZQdWJsa
  WOIOTSB0d6Trxf4Yg3zPbLfqme0LpgI1yFcnBURv-LDZymslThlMFvCNHkCS6TNeq
  w3JRhL_QA10VfSgH19fbQHQWNjb3VudIARYWxpY2VAZXhhbXBsZS5jb219fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAYL-7BB5-DHIL-TXL7-AZW3-HRZC-JSY2",
              "signature":"LaRep8k6WdwkKfF3Z83XMiM7tJvWBkrMIdgE34
  oZH7b_Jaf3eG8H7GuAj0qzpIY6kWutoPKPQFAA-BTCMi8aFL6UME88Vx0gfQ5XBbD
  tnizUDDfZz4wL2ufAy-TzoD3aNl06l65cd95Flg81J_IDcxoA"}
            ]}
        ],
      "EnvelopedConnectionService":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTEyLTE5VDAyOjE2OjA1WiJ9"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tA5BdXRoZW50aWNhdGlvbnu0A1Vk
  ZoAiTUNHNi1VTEdHLUhWNVctS1haSy1UNFdHLUFNNU0tWU9DSbQQUHVibGljUGFyY
  W1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1YmxpY4g5NIHR3p
  OvF_hiDfM9st-qZ7QumAjXIVycFRG_4sNnKayVOGUwW8I0eQJLpM16rDclGEv9ADX
  RV9KAfX19fX0",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAYL-7BB5-DHIL-TXL7-AZW3-HRZC-JSY2",
              "signature":"M4ehNGJCgHCSgS4cRIHgu2xnr-Rz6PiBGiW35_
  c1XLWoVduafzO4aNOzvwbKytTdHh0f9V5qU9QAjtc1jd19ybJ-FSpoW1LeyunQnNR
  N-3CIiy75IWXi_UGrcB3d139GiKTm1QwwaCJqJ-mDpzUpSCkA"}
            ],
          "PayloadDigest":"cd31ZMAzEJMOeED2ZagPYQnflZaIm_OGCrBHH2
  3IIfAi_U7Y167tue0vP1eUPcHICrpBvlNRj-EJ2j9oxgJp2g"}
        ],
      "EnvelopedConnectionDevice":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMTItMTlUMDI6MTY6MDVaIn0"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0DkF1dGhlbnRpY2F0aW9ue7QDVWRm
  gCJNQ0c2LVVMR0ctSFY1Vy1LWFpLLVQ0V0ctQU01TS1ZT0NJtBBQdWJsaWNQYXJhb
  WV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibGljiDk0gdHek6
  8X-GIN8z2y36pntC6YCNchXJwVEb_iw2cprJU4ZTBbwjR5AkukzXqsNyUYS_0ANdF
  X0oB9fX20BVJvbGVzW4AJdGhyZXNob2xkXbQJU2lnbmF0dXJle7QDVWRmgCJNQU1a
  LVY0TUYtTUxERi0zMzNELUQ0Vk8tQlczNy1BM0dZtBBQdWJsaWNQYXJhbWV0ZXJze
  7QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0NDi0BlB1YmxpY4g56LcMqypWHuUREJ
  Ja0R-4yv4Vz9LOgo4ASFMArGCiX57PqbZc1LrKYwjEodYNfbcJPFbjg4RxD6WAfX1
  9tApFbmNyeXB0aW9ue7QDVWRmgCJNQzNXLUJNRVEtRTdSUC1JRENYLU5YWEctWUZM
  Qi1CREVJtBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEW
  DQ0OLQGUHVibGljiDmTnUy6KQFMfA-Xrkxf7WlgCuo5NEDIUXTrb93Yp2lGsxufdn
  zPRu_CW6_b1cd1Ybvk3Snm4OlMJoB9fX19fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAYL-7BB5-DHIL-TXL7-AZW3-HRZC-JSY2",
              "signature":"lfH4c5ZwneOfipw3oEtnA51NXaeMXvCgkGalbS
  mCuMUghAAIl4HT5eykvVQ6SJnhvqci0-ZvY9aA_BPbNJyntp1D0AjmENdgLG5Nl79
  Naf5_onj8AtuPcvKMlwFICe8KxBidYi_UM1QMO9ewsII_2xgA"}
            ],
          "PayloadDigest":"mvNb_L0fqO68_fuJPoFTklP02hhv0LKfvk7ric
  olchLJc14pm2OnSAqDCpoJZPt-FBZP2GskkbSo8Xk-ALQ3kg"}
        ],
      "EnvelopedActivationDevice":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQN-CZEV-AD4B-MGTE-DTDZ-F23Q-6ZN4",
          "Salt":"0opALBtQ53HQ-J6eLQsPfA",
          "recipients":[{
              "kid":"MCVU-UA32-S5BD-K7GH-HTQH-3UBR-7XBQ",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"TodXLtWnE7ZlUe4nzQogJgzHWZ2MgvpPZmxRZ
  76bHpxP6SiXX9wzotKA6a1mTZmZRaNYp1KPELqA"}},
              "wmk":"fh4bd9cZ-0Wr6wcDa7Z-y5Uqp8KhoWih9czq5AhhwJgO
  AqAn_SpiKg"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMTItMTlUMDI6MTY6MDVaIn0"},
        "eL7pA_bXDYTK525Pzkhol0g1yT0H2_k-BUG9SJbp9Rz7HpS6FEpkbq4_
  fW4FzZkJV0cjl5-wsPrKqfqF0iUvgozJE8aiByP8tCPz0IYkwb_-4myU4cfiegFSH
  AtMjerClZ4LOWopYjJzlxWfd0Y6TbcKMs0ZYe58pfSuyvOCt8RKqU7uAY--3GR47Q
  Z-EIgOSJbt2OOvtjEIN1UoZeem9qJbaAeqS6gTuo4qhPulbNpV-k3OXcNTRDO0-MT
  U8BJE",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAYL-7BB5-DHIL-TXL7-AZW3-HRZC-JSY2",
              "signature":"h1KC6vEKZW-IbwojEaPnt6aEHQLG_rM6TPuZsQ
  --TSYCY3gna9Hl9e3qAhBV3N4bX0xLZz5U1z2ALH0ZpxchJy8fV-ODfvegDqo33wm
  UCT61A252IGZ3ZKe1TWVwAO1CvW8Cp8W2GyiSXAOnU3wDVysA",
              "witness":"UcET9BtrJaVCC74CW5HYW3BWK7qxIPWanawLHC7T
  uho"}
            ],
          "PayloadDigest":"7RJrllFfDgN6LNXn55Sys7_spVjxfuflzDCf4L
  CjxjWi2_rfqJ7sJXB5F0Q1EbdWI2zlowhSKT7EUwWMGf6u4w"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQH-23GP-WKST-7OUA-YTBX-VUU3-5EUG",
          "Salt":"16HXJA3ImFi3cYnEO2Axhg",
          "recipients":[{
              "kid":"MC3W-BMEQ-E7RP-IDCX-NXXG-YFLB-BDEI",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"zfPbnRu3a9-Z6SzEvdbIR4vBL49SdsEXKkHuw
  2FVJZzTtghasO9NqCEJrYujwLcQCtmb8CN3L4yA"}},
              "wmk":"PXTxSsfl1y9Pp_Yr5a5uJyKGXv1jVrn-uNRTg6JimNam
  ZshTgkJjSQ"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTEyLTE5VDAyOjE2OjA1WiJ9"},
        "hMbI0ztKoSP7nb25aqtyYUNH6TuSW7C88zkp-7_bSsoS-fLLDKUlwmfO
  Pql2kz7hjUr43jmt2_S5RSx1y7KKkDWUHb5itPI-OQJhcWxRVnXuIf0_S-DEmrMOo
  XcLvKSFQrACHVmvmQZdzDHjjujm6NcRWbp9S83pShiN6vnVNbFKDxaO0DsWmBdJAf
  u505juBeLNCHAU9E35ce6Lep6T_5DM1YvCSPsPFHGh5QP08Tj-r-5CiSoNFNoBJ1B
  Awvs-F6FIyqhm2snZ7cSAYizBzY3msdHI3B8jx_oxGawQdNNUL-dIxPENDBBX_iJU
  8nt3-4IkUVMa8lOpiAQ-KOxAmMKkbMKX2hd-1H1FCXWsCPni9VVNa5-h3zAlnkb0z
  uJDSn95Lrm5aysWXyBfHwymnCbgTQfIQ5UDRFi9bUkgnqc6rUn55q-tXLU0Wh23D2
  dv7qZjvJFIe0SwvEY7h3dPFlfG9wd1kwnSk0Z5eArn-KRsvU2UsqJ410tbNp0BrZJ
  HWelzf7BkyzMneOMLsWy2r2NHr85ZjPa7VB5KAvR_ED1ZIpaO8eKv-NJUSmuGHIt6
  2F1TuYWBceRE_eRgkthXfB4QRD93pVIVAPbY8jOota-NPsgE63_N9p_x4BTdP-LHN
  p91PiqAOYjUlbd2cBBqE4TbIVMFWh1kExmWdJVoqev7VGoJ88WYWrCiONi3vWWUly
  2VdGP-b6vIl9TF4Viau_HijCL5rwBg801t7dtm4H4bVZpwnJ3m0u4kIM4yGic-ScP
  TZ87W1yNg8nJ2eKy5LEGVeKBLuMWlU5H01YLBEr_Us8nWmMrvnZe8nfUpFWNKt7pv
  9r_AvPVSosLh7szZsYGf3x1GJYMwBxVcapIe4ba1YFAm2xjg-6sjnF3HrXVaUhBB3
  HKGrfZI6TzSw5CqOTh7LsfpAxieKcPaiLtOFSJXOkNE_uknudXgDaBG7PWwLkHb6P
  PYZBPgLgOh3t-PvKqGxFU7mFVspe59zyr10uCo1yCYf27KA8Y8HoazzSg5OqZWI2I
  dBsmyGG24qr4MZqiXLwW_pLq8OI1gRmErjje1tSakuaEXzqLnf8k2N8RNDuvDyqsN
  KaNZELp_aKzF6WbldJMy0C6jUzMYWhYhyolGE1OcPOnMikvF6NNhGSVZC5tMDs-tx
  gIQkBf_xcsqnL0IzUntA3AJ2ZP__f79Dp7t4Vau2unuymq0T4TWa_l9T3ZTLN-N8p
  BxlCydSbmc_1PuKH4Z_rJsIRFiVKcyl339djngymcOtNk_rlvLiW5V7pIljydND_c
  ddArvseyq-o866U6JbsilZKdYrY8Ua_bniqHTjd9oz9wxTFH3NtBeY5lCcQyM-RaS
  lIo9JlE715PNT66LsSu7hP60hYacm6fYeESQDnUJYRbjK2EmRLKYLZzJmsUS8M6o0
  -wGz6O6srSJcSz6bB8jLOIC99I_t-GQxX9IKw5tYLloFsusD58RUH2UGzNgQicQbm
  yO63jR1e8KsHkmVIwqEBzbAQmMjLB3hN0ZzKR3UycAQHUYxnP-9-YnQgg8R42ojYa
  C94dJznmYGrSuy8v77EcqNEMgiEQjT52qlv2YQJqNdkbFVklfSVyNQ5xkKcrjo__x
  DeRxdLXJGLWAOvREUZBqQPdrkNrpwzWH3LNkBdNVjnWxVJCwvFXxEJ_M1lqWFvuBd
  wvEA592eOf_ywFSyLC7RAw8e1AcrZ3-3TygVWFUjCu0oh7bKzFENjRD7_9XhqOWaK
  YX0fhsXmfW7AKnk_9HWjUrblIUmrrjnGhOwD0EFm0USfDDmOBgoT-cLCKuOJb_nrC
  ir3q0Y9V3BcA7PmEM8CEIjBr7AaRS7eONfoAEbzUVGmdGn-d6C9ZaPTB5on59_Tel
  L3iD5nM2nNPv7RrcYxDqM7f_eAVkKHvjv6aQnw-lMuW4cwTo_GYnhBFRP14l0s8xb
  xy2pjACHC_yTUJSKxGajFQireq02xTwOMGAQ8NxaChSXxdw18oWChjwzHQxTJawex
  z-244sDuHx0WznukxjTyIBeSPs3iRCnCU7dL6LokTbYlvOghdiaqRGdTQqLQWnvyj
  8s6wDn_T9JwqtH-q5Ai9aA64jNEZ7uQOQtGQkDaIRgi5wBZMkqov4zKaIfEHJbGML
  ZL5bKkHd23RSnbqM8sEe-2oVUEinzz9zOe2GY0paqt8dt1QgqqMk2VmSvXi23uLMt
  20bAeLSv0MlnN3thfLVU8UDTKG8tMzQOjLG-bxvOnAZMhwbL2m9lMUgLaWfTyqaY1
  XuMhgU8zA7cU8ewPGfcZi9ySiBQVYt7hTOaZAUwmuLCs2T6qQ-uDtDLm5H2bbbreb
  RNJJ-0-VQjlUvVy1fPHFAzdGyFM76vhJCqCGuO3gc6zQJXGqYm0L4IUsCWbn52-XB
  HCYwLPD1sF18zoq9TDW2i5YwSiWuBjrUr0X_M9mItUiSgQvY2PGvGLyG6AjuV0pDQ
  AgGi4jvxM7IzLFxIjg71AoKRCdrrsjRengpP0FhARvFRaktkOV13VNdUpbCevKEJW
  M_tQGIOIzcOw8YU7zy7nHjpkb6i2Td2AfBc8tqMS4Om0F1Ira26ItVxpWNnyEOeHo
  U4DzDbMuKRT5W5LqUHCAr3BHEaiQ92JWDd4VhMaSCW0jBNLnK2xzmhuJePL17HVqg
  g-hD7TIP63CuwnoeyHyBJ42ri7vSGYYieXT7LDa0D7Mf9yZUVl0tBsHuY-RykWhDF
  seXZHCcxE3u_G1UZy3k_uZyHr2RwWC70UXWu3Jiik-GqxvxN2VsRtwrSvLYraYSXc
  caLuBoy12KuMngqTFNsFcxFC79UjmzXNWYzuEL9r-NHOiWjbn8JEgJjJOOxThIBEj
  Lzqcg32Ikn9px0gFvQrhaijS2VpWQshTRONqkLosSWJKIRywKDI-GHMPOxd5dq9EH
  eLERVbJ76xE0fLxoBJOehD4u9kTia_0cfKodVzJXyxaG7wKNRgu-1L7Ps0TfqFP4U
  oxbR_HpgtsqAg5NHLlzsE06ee8LynC5foVoBB1TwU2cMg-CMDl2Tu-lJrQKjbfXNh
  UdFKIwFuq0N0QuwGxY44Zh0-4xDAlnMlSVX_bxU9hWYw6h4ewyGCj61J9AqmgdC7T
  2Gua2pO_NHDCiuwJ8qr-PYPqXgqEh-a7myC4SRUi7Y9jFJ0IMxErOFvxQtXWPamkw
  nz9wXZTScPEmpgZ9ItnDorCdBWOMBw_mSpXt7RaflFGYCvZy7QALKoOZrHlrRzk3e
  MmOtaK_XkriHXRUXVwx21yFUjr1_bm-SaTu6ioHioI4en6oFNwBVAzSWBXiI24j1L
  4qxBVtf646vFcckJGfZVPkD7jQzpU7a-ZJBFm5qTxJjhAieRRhLrov1GpuQQSnm87
  AXaH4Xu0iHQiQVEx127wXXQC1G8VKYRr8Ce9jIlM27zTXZNm5Ei8DHYXLpbhC57_w
  ewl2hKeTvzT4Jlq2ItmnXGRvbrHbD5dyzisol1o_WIsBz4poBNZmAcQykTCOfS3eL
  yePnB-DIzFuzPNzID6FwwuA4yOp61BbPWRYy4D1FxDa8QeOVoma9SHTsH1RvuVca5
  1iJsYEIllvPE3HJBK8TezLDWk7GRzdiyouxLABMldts4JLd4eCZoX5nYpbtA3FzKh
  xFKMaNLsed80I2N_14hh4PgYGIgqIkqivWv3oAdVOpPK8ipdVRnDth_LjXhuW5Le1
  RxdHjhj3nJQH18y65LeT7J3NA9c00KznJ1ofrQBn-q9nhNBFQ_AYCpIBKnYKcZh7-
  g8AwPByeHQ3yL5KlNJYjedgr3Y15Kubndc_wtvMlRSnHfaBXOiaslveVsJFAgHZYD
  1TyoucNBe2zNXhpJJzO7Ye8YOH-ZH0O9eBu3dtKDBVNTI3dr9uFkkzVIvinwSjgYm
  -BeV7cspZ3i_XDfQLzJ-BDKLQ6C-jP9G7b8Cf8A7tdJ6b0F9JbZuDSmj2LOU4N0WD
  DzvcaO2PTu_9uboz6W3udB3Iq_4HDBrTXB-j4cV6mTIgL-uB4Boj7zT_VxiHS4RCt
  HJL4tiGJV2zEb6qsJNQDadiOyQX7YajsTC2bvY1c5Dlkk1whvDTamUvNJYUCqh-94
  ku9IhQLtHfRXebQDheVb0xrfx2OFSa0ZoDB43uCYw-czTVkalN9z2M0cTeoLDarLW
  RkU3NBCQ3hUp9ACwv7SKaHgHPWeClEQflb8OiH3x3K_WB3qjnOu0YOaSapi6UmbB1
  8HwLliL_4yCyUzt7NrRUICtfEZTzPTb55AoyPMamtB4tajPxnXbwrJ36sjoV3FP4Y
  juPOCx6vbTMryMwjEofd1qaWU21FnwYFbL1iCljEdSJMWnHh7fHgWncxQFcxr0_Ow
  biqUOLwedg_ItTguq5afX2TagD93YZahaPLCNdiIbHZowvyoO_EYavt44_L4FP9i1
  8baVEnt3hL1nEKlu3MVBE-h_992cC2uHKCDRVD1qw-zqrwiHL3bfBNDz691rJX2Mt
  VjmjZd3Ut0joN5opYgL8ggH5MZGrrpdfwapPveLTZqRySeIISGVJg38wjUMax8zDZ
  l2hEwf8ETrjSq1CsyN6j5a-wuAo4rfh3Fm5LzuSXYjZIzvfsqnXJEjgzaVbSAWB09
  eiuN8shLYhx1jNEi-NFnAiJKZ9HRZkjhDqxYXPv53ghCHutLI7H23AnJhzaVOTkW1
  dEC9Y6wFMOlPxsnT1OUVp5X2YlVvxsJAsUNRy849Spo0pXp1HqI2VjXgSCsGSaxsu
  C8kJoARHV0FLPdpPD7knY_Vbmc8gHczUqVXrMHv2Z3ekGsac9kUbzSIU_RgToknsq
  SpFk02uzH1MBICP49jgdyMDx4ykzWVDJSklWW3MQOrXNrtid-ThzJ10OK8lm109Ii
  ExTM73SK0znSl7JhW3SawQle8_deQ8aGCOiysZKYlr26v6SABHK5_oJi5hsrLB_Ka
  iM_ExKiiRxoELDOba0-iMOepSiJmDdSAQo8nS-butPOdUA2e0tZLJFawX2NeWJW1s
  EWCNIbhWZJ4AC7wKgVSMbGyZRx69_imzKvD446Z5lSofUsX93v4nAabhvfqsyIeiW
  atONUfTqreGs44sYSbjWenQjRWHIwlZgvwNfFGpUYdTooThbErNipASgjKbjfSGE6
  q6dMsCu_DtgyjaOlfuSG0VZSP3KIr24HR28SduL4nlx0PI8v28mlVimVqVijVX1G3
  uY12vYVPFvuUEli-OhnT2RAzbB-kjQiYNNdtjtqJxYn_A09FouJM4bSLzBgiKcNzS
  9vJ5kacxdWDlN7o_ubSDN13qVncskTvMbNQMBuRlnUtidEPPQJWLc4JMuyWsBhNDn
  5iXombCG0enZ1Lto7CRFQJ3BvSwKZqirT544UfeRdGmYehTC3oi5CauQzSDZjd5nZ
  0DcNU9htEr5zbc9nYx88YFoggCB5O4FpbrykELsoGcQCu0CeZQ-99HA67udh_xnj0
  EeBQpWzbdv3DqGuzUFmrM8Ekh-Ej94dtt4cD9NkPXQPbu__NR6wFZksLQyZ0jqlnO
  8j4eWIzVaf1UOb_kPWmAsOPyYbIZiAGzweneZ1_1dbs0J7N9BOS6Jblv0Df0RlGV2
  Lx1qaEXNLYfRfXk41eSTfzahKMpRfmBaEmhU1TXS4WpQcajYz-tqtlBERsAW2jaGT
  XbyU7vP8ULkbKQqO-xmCZZixBEZJNHXc3zMlI9fNciFg60IUit9a1TF692RVmBkld
  o1Ks7S4baLgA8TtUKvN_81BF7L0R1UgDTq-3ztjl01pS1sQ-4CjEcOipQoXP7F2fM
  3G1eCmr3FQDiqQlIaSskpfHu_XBGzpnzAZqgKifNgCxlpJZEGivNdkLSMGFACCsp3
  TFi7xJ9KDWPacoD4ICLyItjBS8g6kdR1xG0VP4jutAM2ya3yuxX6-Lde8beKkOxJ4
  nYVx5ZyrqJP2K8y6tSqDcNyXyGSppmZuOrURa4t8KQ1DOmDCYPbE0q1dUgxHf3d7X
  VJaMo_NdWWzcNJZqZ7wEIkom5pmcj8LnzW2OOnURHWjMOYXUVLRqoGVEBC9knDpZz
  CqZVV8WNDziaVhuL3Eui7hcneCNsqini9Xob1AFH-B54IoUAn2ii6jlNALRium9t6
  M0vNEa8CvlihVs7eMgZ9H9Jk_5sby-bRySRWt1YV-FNT8mXiZ2PP9YE4FD4LkhQgD
  UrdegHtT4_m6kWNolbMugIOM8ECOJ21mUMqTU1p0vrVOHTxjxjbxmbCB2vJW2Ibhz
  4i3hNkvZqXGB4Dndoq0wAVbgH8Gw-2fVdUiObiSpFyK_hhZETewWv0116bwpmgGIl
  FSb-mO97sNDpMpGD0Qm8JKojxE_Mf0wG8kkP6Abl26X91JegrQdPyX_HuoIeLCj8T
  V4FQ9WeZRFUJei8bRxB0uzz3xCFsrbrdEPxpNgtYZu7ZVxVCiFzKY5XQf2c5Wrqnd
  Mb1yyIP2qgIqslFi3eplaHfH-hwKWS72oWMaqOc21QOUNQqZzTaoujNQPluXNjZCs
  L5dFc5y9pGLjx6_RquRmrRRTtXGiaxl0LD03N3rkXTcv50-q9SRFei6lcuX1fhLgD
  Gsbc2YHfppkwja0Nz4E8v_Jk-5pC54KLlIctG6CgB6onG2JgB8kF1r7wXxIgH0ev9
  SzL2KKkUK9UFmNUx8ZfS7BS4q2wq4576UrKEG0cyippRvxGDS7P04FkT6y7CzX3JW
  FSKG2cs-lYsMJoP5J05zG7G-HN9D5tF-Tm-MJmVjMjA0AS_VVMXgGYwOr6yG8boX_
  CUpJAVvP_ZVte-c7ZO2RXZESdFR_9F8sxoM2MP6v1VYdziFS6Y042xl8y8Y-fOjvM
  CvzLlZyFjw_Qa19hk7-2jXeZspoQxKQi0ABTkfI-JonHd7uSTpvRKS1jk2ltcgL1O
  8HH5wmC2nM7k6X5COx-JrU7uWFHriYpuo6yd5EQZDMjJ18ywFRWOBbB0ZNRS1mZm9
  urwCU5uthYajqraOyTanq6B9k_iMs7MqlkE7wJG7Q8XLhVh97X1INFd4DzVT8qFqO
  6E1MtRfrhkiblhRaYRFO9WwfKai64ijt4pYwHL4kSzexNiZsFjQ5Vsls16lq6kBpE
  Vrcr88WfKqz-VqVR-1BohGF27x3R3XnqMcn1ZvWYGD5DGrhZxAF6FgeiGGFWwa_A4
  iHx30LyIYb9yqyf-m_P_5N5RLigm_dfjd2y9VlOLP-2p71_cvaHiMSMxP6mIUgQ83
  UaPgI7Y3sycaO5Bc4dp-98ZA6JlB9KBYb2kGkYSe6Ull2uGx0PgCv0YUScPqG1bqk
  aNeA7jKvz9b4m_o2MgjqGByKQUhPYs4q62C8NtHNJAU8iRmYZWzcWZP8_5_tw6Rin
  jWGB_0kmI2oi7up3N_3WbkkLUjWMt7q9rhmhW77Hb4w3jGs7nl4Ml4R94-Mwo4dVG
  fbtmoGupoPEYB2ZUG1VRlDqpHL5WUtRIw2XwBSZdWwxyUbN6Ffclj6Nl0aRhcxW2b
  gyh_mflyYCTB3UlxNesQCGEsvRrWdaI76T1anz-3Q_0FsqevRfiZA7Sz3cJ3IZpyk
  J_nahd6A9Q3snsQVorskBXhXDTgXWm7a895uJICzZu9p0ZeCGV-b_m16Ra84wog24
  pJYuhRqTzRCmmXSCkMJiCLHlrQGkyoWVU0UZ7yEHmcEKT31dpDE6YHq5iJs9RaAY_
  EaYAzpmBDocUar0CBva_farewlURlefVJIOsTPz5K8rbGKUj-g5b3Zp0piVQmaj_Z
  YfY2JWqMLRrRPUWDd6d_9E3V1JqiGZNuKluGs60Yzfwt1YIF-fHeEqEJt92-llJkX
  kht_2WjbhE9tmkUZfuFbMiG64589lcR6aevhl0vJmQpqXHzPAPBa2K0OXPVNValnJ
  5g9ZHlq2d8sGeIjH8f_R6rekuQH67LNZ8TugxjuucoYPppWNn-zFyu0yoCtrOzs8-
  imiUyJ3Wxi34cGEYGsV7vA-UXLU1qEtP1FrsWcg-NL2ApsMd1HQkyPuUpIBxTxCIk
  ihKM-eJd9EAuCU2ut6pz7JNfNDeMI-TLl094XTiBwgClg2CGM1SOsM3RyskK7mDtK
  -BxPz1M7AQr1Mx-5Zwvvz5u8WhfV24qDOwI7F0QIJXJ85L1B5FPo5U33vQ7SmhLos
  wgMEKRUqUfsKFV9ar_hHer39pUBglW0qwHM23cUIujqOccJbsmMhgy2IIehyGvSJM
  Zeb5diIEzzO5YvNkMPk-8krzvloEg8aqc8R7LT0UO17om0thyMDD5ipfuk9rWDv7w
  6OYPEEnUflbV8ATBShoHX4pPofmK6DFWZKKIpEvaYoJrAXGQWlPinmCOy-PoQ_2oR
  6ry7XbbYXOgAC5WcZDZxLxQm8Fw_-8vp6V6BIQanluAjWNCmxcLrdA_MZ9VT60qDZ
  hbGv-rgTxdxSefO7ddKpuXx3WJWoYUzrVXclS-Wlt7tz0V_uxjCrpkr5ALc-04ykF
  70doVw4ByBJkSySU7T4Tf9i7eGjFfBuGe_C6efaJbyMog0eqeyciDloZnR0jOZtCH
  h0ltQsEU6dDtR2ZLyldhYV9H8egzDDttMCO4nc32vQHRrVwD4beVxB5PdwZCpqJ4M
  9gKM-fS8694NgHk0Py94MtJ-ikANfk5LeuR2YUPmPV43iyw4",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAYL-7BB5-DHIL-TXL7-AZW3-HRZC-JSY2",
              "signature":"IkBecVMebGN9pCb1W7wCqrhdjd5jzc5K8Y1Kf6
  hN_vjxawEk5MZ0L75NeUNQ8huUoZJm6WKPcraApD6REOwRTNKHqTqXZdL6s54HfB_
  _lEAe-KK2L9O8LwWCMcxixPBEq5doshgVGlGKAie9OENYFzMA",
              "witness":"rUQXLpDujG2uPLJ8ZJvrgPk8PUz9uGwwefM9Rc6I
  FKc"}
            ],
          "PayloadDigest":"q-PlLNf6ASFEPMLBwxsJYb0PjSITvSk4MCLTpW
  lig0wCDY3NB5UOdReYNLkgLOKjyow2R50ZLVPef5u_nBQh4Q"}
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
<rsp>   Device UDF = MCQT-B7NG-QZ7M-4LXE-5AZN-W4A5-5FSF
   Account = alice@example.com
   Account UDF = MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT
<cmd>Alice3> meshman account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MCY3-5C2F-4VFN-XOTT-AANK-474N-623W"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

