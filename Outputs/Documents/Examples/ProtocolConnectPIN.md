
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=AAGV-IFMG-7JH7-VLYL-3PEB-PU4S-4E
 (Expires=2021-12-23T01:13:18Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcu://alice@example.com/AAGV-IFMG-7JH7-VLYL-3PEB-PU4S-4E
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AAGV-IFMG-7JH7-VLYL-3PEB-PU4S-4E
<rsp>   Device UDF = MC3V-V6L6-YHCW-26I5-XFE3-6WGR-BKVP
   Witness value = Q7CA-IZV4-BB7C-7CNA-TQKW-W5HC-GJ6W
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "MessageId":"NC24-3JS4-5JQ3-37XX-65JB-FY3I-CIK2",
    "AuthenticatedData":[{
        "EnvelopeId":"MC3V-V6L6-YHCW-26I5-XFE3-6WGR-BKVP",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQzNWLVY2TDYtWU
  hDVy0yNkk1LVhGRTMtNldHUi1CS1ZQIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTEyLTIyVDAxOjEzOjE5WiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUMzVi1WNkw2LVlIQ1ctMjZJNS1YRkUzLTZXR1I
  tQktWUCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIk05TEctaU1KS0pQV1E0T2psMnVaQzhhSzFJZEpqWG9mWkZVTz
  VfaGpCa01adkEzR1JYMHQKICBFNDlxUlRWcHZuWU81eWlHdS1Qaml0Y0EifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJYUy1YRFpPLVYyNkQt
  MkJFVy1ZR01ILTIyR0QtTlFSUSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiLVBYeVR3VmtySGJmNWRXVFozdXQyU3l
  3Q0F2UkNBODlrdjB0aXdXR2hlTzgwdlpHamRlbgogIEhXeV9Ebk5reUhwZWRqaXU4
  SjFSNzBvQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DM
  kctTk1aVi1WRjZXLU4yU0stNlhVMy1RVFQ1LVc2NEMiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJQV1JsVm56TDF4
  Y3N4YlEyN200bEpvWjl4cEtkOXlRTFF4dlZXNlpHQjU1cnFtOUxJM2xYCiAgM2hSR
  mxzeHROR0N5VDZ3SEtjLU0zWnVBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQklZLTdJQVItUEkyNy1DM1dCLUdWTkotVUFZNi1DSlF
  UIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJ4bE1tY3pwRll0T1lMN3IyYm1qdnBWMW10cFgxM183a0tLOEx0UWtWNT
  IyeS1jRGN1dHNiCiAgZmM1cFN5Vmx2Z3Z3empxVlNFQjJmSTZBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MC3V-V6L6-YHCW-26I5-XFE3-6WGR-BKVP",
            "signature":"FUwG6-59QcvpawF4dHEO3G2rfC136rzlDiHKVpLY
  vq1oqkmBeVH8pDNATrbTRw404tufY3TBiXkAkbJZcDSD770iBYTzosk1GjMqmg1S5
  X3Ly9fD7zU_a0CbG9J9lZKYusgr0gHySe3YsOLCwrH71C4A"}
          ],
        "PayloadDigest":"IWA17Xv1Vwiw8Ypbr9IywP78ylszhdz_1PlmCidW
  jAvRImxO7Du81WCLh4fhl5I_yJ15ho_VghSGrUIjj5953g"}
      ],
    "ClientNonce":"OSz7BLOw8YtkX3PU46yoYA",
    "PinId":"ADJI-4VCD-MVVG-NUXG-QOH6-O5TJ-LO3G",
    "PinWitness":"FJUDFYy_hcRkVe8EZhRlWCVLbwcXR7HLGncWP5zHcabgIjQ
  cDByDm_YlHcn5HskhiB2oBbqavmG7SX5WW67rLA",
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
    "MessageId":"Q7CA-IZV4-BB7C-7CNA-TQKW-W5HC-GJ6W",
    "EnvelopedRequestConnection":[{
        "EnvelopeId":"MCFZ-N4FV-JAQ5-VXE6-42ST-VPEX-DL63",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQzI0LTNKUzQtNU
  pRMy0zN1hYLTY1SkItRlkzSS1DSUsyIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyMS0xMi0yMlQwMToxMzoxOVoifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJNZXNzYWdlSWQiOi
  AiTkMyNC0zSlM0LTVKUTMtMzdYWC02NUpCLUZZM0ktQ0lLMiIsCiAgICAiQXV0aGV
  udGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1DM1YtVjZM
  Ni1ZSENXLTI2STUtWEZFMy02V0dSLUJLVlAiLAogICAgICAgICJkaWciOiAiUzUxM
  iIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI6ICJld29nSUNKVmJtbHhkV1ZKWk
  NJNklDSk5Rek5XTFZZMlREWXRXVWhEVnkwCiAgeU5razFMVmhHUlRNdE5sZEhVaTF
  DUzFaUUlpd0tJQ0FpVFdWemMyRm5aVlI1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxk
  bWxqWlNJc0NpQWdJbU4wZVNJNklDSmhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV
  04wSWl3S0lDQQogIGlRM0psWVhSbFpDSTZJQ0l5TURJeExURXlMVEl5VkRBeE9qRX
  pPakU1V2lKOSJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V
  3b2dJQ0FnSWxCeWIyWgogIHBiR1ZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNK
  VlpHWWlPaUFpVFVNelZpMVdOa3cyTFZsSVExY3RNCiAgalpKTlMxWVJrVXpMVFpYU
  jFJdFFrdFdVQ0lzQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KIC
  BnZXdvZ0lDQWdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0F
  nSUNBZ0ltTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmli
  R2xqSWpvZ0lrMDVURWN0YVUxS1MwcFFWMUUwVDJwCiAgc01uVmFRemhoU3pGSlpFc
  HFXRzltV2taVlR6VmZhR3BDYTAxYWRrRXpSMUpZTUhRS0lDQkZORGx4VWxSV2MKIC
  BIWnVXVTgxZVdsSGRTMVFhbWwwWTBFaWZYMTlMQW9nSUNBZ0lrVnVZM0o1Y0hScGI
  yNGlPaUI3Q2lBZ0lDQQogIGdJQ0pWWkdZaU9pQWlUVUpZVXkxWVJGcFBMVll5TmtR
  dE1rSkZWeTFaUjAxSUxUSXlSMFF0VGxGU1VTSXNDCiAgaUFnSUNBZ0lDSlFkV0pzY
  VdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGwKIC
  BGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0F
  nSUNBZ0lDQWdJQ0pRZAogIFdKc2FXTWlPaUFpTFZCWWVWUjNWbXR5U0dKbU5XUlhW
  Rm96ZFhReVUzbDNRMEYyVWtOQk9EbHJkakIwYVhkCiAgWFIyaGxUemd3ZGxwSGFtU
  mxiZ29nSUVoWGVWOUViazVyZVVod1pXUnFhWFU0U2pGU056QnZRU0o5Zlgwc0MKIC
  BpQWdJQ0FpVTJsbmJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxRE1
  rY3RUazFhVmkxV1JqWgogIFhMVTR5VTBzdE5saFZNeTFSVkZRMUxWYzJORU1pTEFv
  Z0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljCiAgeUk2SUhzS0lDQWdJQ0FnS
  UNBaVVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjblkKIC
  BpT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSlFWMUp
  zVm01NlRERjRZM040WQogIGxFeU4yMDBiRXB2V2psNGNFdGtPWGxSVEZGNGRsWlhO
  bHBIUWpVMWNuRnRPVXhKTTJ4WUNpQWdNMmhTUm14CiAgemVIUk9SME41VkRaM1NFd
  GpMVTB6V25WQkluMTlmU3dLSUNBZ0lDSkJkWFJvWlc1MGFXTmhkR2x2YmlJNkkKIC
  BIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlFrbFpMVGRKUVZJdFVFa3lOeTFETTFkQ0x
  VZFdUa290VlVGWk5pMQogIERTbEZVSWl3S0lDQWdJQ0FnSWxCMVlteHBZMUJoY21G
  dFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZCiAgbXhwWTB0bGVVVkRSRWdpT
  2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0lsZzBORGdpTEFvZ0lDQWdJQ0EKIC
  BnSUNBZ0lsQjFZbXhwWXlJNklDSjRiRTF0WTNwd1JsbDBUMWxNTjNJeVltMXFkbkJ
  XTVcxMGNGZ3hNMTgzYQogIDB0TE9FeDBVV3RXTlRJeWVTMWpSR04xZEhOaUNpQWda
  bU0xY0ZONVZteDJaM1ozZW1weFZsTkZRakptU1RaCiAgQkluMTlmWDE5IiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6IC
  JTNTEyIiwKICAgICAgICAgICAgImtpZCI6ICJNQzNWLVY2TDYtWUhDVy0yNkk1LVh
  GRTMtNldHUi1CS1ZQIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJGVXdHNi01
  OVFjdnBhd0Y0ZEhFTzNHMnJmQzEzNnJ6bERpSEtWcExZdnExb3FrbUJlCiAgVkg4c
  EROQVRyYlRSdzQwNHR1ZlkzVEJpWGtBa2JKWmNEU0Q3NzBpQllUem9zazFHak1xbW
  cxUzVYM0x5OWYKICBEN3pVX2EwQ2JHOUo5bFpLWXVzZ3IwZ0h5U2UzWXNPTEN3ckg
  3MUM0QSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJJV0ExN1h2MVZ3aXc4
  WXBicjlJeXdQNzh5bHN6aGR6XzFQbG1DaWRXakF2UkkKICBteE83RHU4MVdDTGg0Z
  mhsNUlfeUoxNWhvX1ZnaFNHclVJamo1OTUzZyJ9XSwKICAgICJDbGllbnROb25jZS
  I6ICJPU3o3QkxPdzhZdGtYM1BVNDZ5b1lBIiwKICAgICJQaW5JZCI6ICJBREpJLTR
  WQ0QtTVZWRy1OVVhHLVFPSDYtTzVUSi1MTzNHIiwKICAgICJQaW5XaXRuZXNzIjog
  IkZKVURGWXlfaGNSa1ZlOEVaaFJsV0NWTGJ3Y1hSN0hMR25jV1A1ekhjYWJnSWpRY
  wogIERCeURtX1lsSGNuNUhza2hpQjJvQmJxYXZtRzdTWDVXVzY3ckxBIiwKICAgIC
  JBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"
      ],
    "ServerNonce":"ubdLCYDF_cPhgGMXSTTH9Q",
    "Witness":"Q7CA-IZV4-BB7C-7CNA-TQKW-W5HC-GJ6W"}}
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
<rsp>MessageID: Q7CA-IZV4-BB7C-7CNA-TQKW-W5HC-GJ6W
        Connection Request::
        MessageID: Q7CA-IZV4-BB7C-7CNA-TQKW-W5HC-GJ6W
        To:  From: 
        Device:  MC3V-V6L6-YHCW-26I5-XFE3-6WGR-BKVP
        Witness: Q7CA-IZV4-BB7C-7CNA-TQKW-W5HC-GJ6W
MessageID: NBNO-T2AC-LSGA-MRRH-JN3O-V4YQ-RJLQ
        Group invitation::
        MessageID: NBNO-T2AC-LSGA-MRRH-JN3O-V4YQ-RJLQ
        To: alice@example.com From: alice@example.com
MessageID: NCQL-ONQW-YLJE-NZ5P-2ENL-K5YY-3I4K
        Confirmation Request::
        MessageID: NCQL-ONQW-YLJE-NZ5P-2ENL-K5YY-3I4K
        To: alice@example.com From: console@example.com
        Text: start
MessageID: ND4S-KDPC-PUNU-4X3I-PTRT-LJSO-XGHV
        Contact Request::
        MessageID: ND4S-KDPC-PUNU-4X3I-PTRT-LJSO-XGHV
        To: alice@example.com From: bob@example.com
        PIN: AARR-TR4W-I3P2-Y5OF-KVMP-7KEJ-RVIQ
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
    "MessageId":"MDSE-WBAJ-7OCH-JGKV-CB6D-J5C2-UD7R",
    "Result":"Accept",
    "CatalogedDevice":{
      "DeviceUdf":"MC3V-V6L6-YHCW-26I5-XFE3-6WGR-BKVP",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNREtTLUxMTDUt
  V1BESi1VS0UyLTRQUE0tWTY2Vi0yTElKIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyMS0xMi0yMlQwMToxMjo1NVoifQ"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJl
  IjogewogICAgICAiVWRmIjogIk1ES1MtTExMNS1XUERKLVVLRTItNFBQTS1ZNjZWL
  TJMSUoiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibG
  ljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJySlJCdGRySDZra0piNU9DRElrYkR0YllIYUo1aW50U0hhMlln
  TXlyLTJqT3J1M1VGeXl2CiAgSkJ3eHJhMXgxbmZkeERUN0R1blhzRUdBIn19fSwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2
  VydmljZVVkZiI6ICJNQ0xWLVU2WVgtUDNUTy1YM1ZELUxJWE0tVjdJRC1aVjdIIiw
  KICAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1DTjItR0tS
  US1MNDZHLVo0QUQtRlRMVy1EQkYzLVRYNVgiLAogICAgICAiUHVibGljUGFyYW1ld
  GVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcn
  YiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIm42bFZidlhnS3B3Q042UmM
  wb0xuc1ltcWFCVGJxUUphNEVrdEluR251ZVJXcEJiQU1YZFEKICBkSzlFclQzRmhF
  U3F4UXluSXVtY2xKeUEifX19LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogI
  CAgICAiVWRmIjogIk1EUlEtS1NWWC1FRjRaLVJFSlItTlNFMi01TE5XLURESFkiLA
  ogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUN
  ESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGlj
  IjogIkQ2UnhSR1NtWEpVdFJCX3RWUTlucjl5TmVFYUpaUUZ4T3lLWXhWbHdLY2pmS
  EFWRXd0clUKICB5V0JicndRM1hBZFlaSUsyLVQxcDR1S0EifX19LAogICAgIkFkbW
  luaXN0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTURQTS1LQ0pYLVI
  zSUgtN1c1SS01WEI0LUxUT1otVDdPTCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJz
  IjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6I
  CJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIkRjVTJWQ0RwdkpuU0VlMGJKb3
  djdzBXRGxJbFpQckx1LUx6U3JkZ3dRZGw5VVA2eGI0aTAKICBQb2doUkxScFBnTGp
  ncTQ0a0lKczM3Z0EifX19LAogICAgIkFjY291bnRBdXRoZW50aWNhdGlvbiI6IHsK
  ICAgICAgIlVkZiI6ICJNQkVBLUU2VlMtNVI3Qi1WQTVDLVVPTFYtR1ZGSi1ZVlMzI
  iwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleU
  VDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Ymx
  pYyI6ICJIbG9CTFVETFFLSV9DcjVvUlNpdWlBbjNKekFLd0hHeW9QUnNvaWxONkVN
  M3o4bkFqb2xfCiAgcnBsbEpLVHBZTC1uREttZGFwMkExZjRBIn19fSwKICAgICJBY
  2NvdW50U2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1ENVUtWklXTS1PT01XLU
  81TjMtRjdTSi1WRjRHLUkzNU8iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0
  NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJENzg5bU5IOWRILW9SUWNneWNLRDhNR
  URuMlZNUjNUTHByVnlCZUJRVFYyWDM5QTFOcEJYCiAgc04xOFloRlZYeGtQQUZ6R3
  g4eDdPa1NBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ",
              "signature":"80E32_6-lW0SXpGExg6tpA97MHYdxU7QALZ5-z
  L8IjljNrwaRqt_xd3tEczRwRxGILdUg2Qjlg0AQtDR9KeG_qYuFnpGIKGTKxbhpC1
  xkXNVSvuvkycNduKHPVmNtrMYZYooN6M1vvgitEKi-sd_2xoA"}
            ],
          "PayloadDigest":"4BGB5zcU6mIX0c3LNVO8hLRGVemVEzfb2bp2C6
  oWGYY16l34MrjQqW3ubG7Gh5Hk8zo4KgREBhA_Af82Si6Cug"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MC3V-V6L6-YHCW-26I5-XFE3-6WGR-BKVP",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQzNWLVY2TDYt
  WUhDVy0yNkk1LVhGRTMtNldHUi1CS1ZQIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDIxLTEyLTIyVDAxOjEzOjE5WiJ9"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1
  cmUiOiB7CiAgICAgICJVZGYiOiAiTUMzVi1WNkw2LVlIQ1ctMjZJNS1YRkUzLTZXR
  1ItQktWUCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdW
  JsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICA
  gICAiUHVibGljIjogIk05TEctaU1KS0pQV1E0T2psMnVaQzhhSzFJZEpqWG9mWkZV
  TzVfaGpCa01adkEzR1JYMHQKICBFNDlxUlRWcHZuWU81eWlHdS1Qaml0Y0EifX19L
  AogICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJYUy1YRFpPLVYyNk
  QtMkJFVy1ZR01ILTIyR0QtTlFSUSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjo
  gewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJY
  NDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiLVBYeVR3VmtySGJmNWRXVFozdXQyU
  3l3Q0F2UkNBODlrdjB0aXdXR2hlTzgwdlpHamRlbgogIEhXeV9Ebk5reUhwZWRqaX
  U4SjFSNzBvQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1
  DMkctTk1aVi1WRjZXLU4yU0stNlhVMy1RVFQ1LVc2NEMiLAogICAgICAiUHVibGlj
  UGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgI
  CAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJQV1JsVm56TD
  F4Y3N4YlEyN200bEpvWjl4cEtkOXlRTFF4dlZXNlpHQjU1cnFtOUxJM2xYCiAgM2h
  SRmxzeHROR0N5VDZ3SEtjLU0zWnVBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6
  IHsKICAgICAgIlVkZiI6ICJNQklZLTdJQVItUEkyNy1DM1dCLUdWTkotVUFZNi1DS
  lFUIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0
  tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB
  1YmxpYyI6ICJ4bE1tY3pwRll0T1lMN3IyYm1qdnBWMW10cFgxM183a0tLOEx0UWtW
  NTIyeS1jRGN1dHNiCiAgZmM1cFN5Vmx2Z3Z3empxVlNFQjJmSTZBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MC3V-V6L6-YHCW-26I5-XFE3-6WGR-BKVP",
              "signature":"FUwG6-59QcvpawF4dHEO3G2rfC136rzlDiHKVp
  LYvq1oqkmBeVH8pDNATrbTRw404tufY3TBiXkAkbJZcDSD770iBYTzosk1GjMqmg1
  S5X3Ly9fD7zU_a0CbG9J9lZKYusgr0gHySe3YsOLCwrH71C4A"}
            ],
          "PayloadDigest":"IWA17Xv1Vwiw8Ypbr9IywP78ylszhdz_1PlmCi
  dWjAvRImxO7Du81WCLh4fhl5I_yJ15ho_VghSGrUIjj5953g"}
        ],
      "EnvelopedConnectionAddress":[{
          "dig":"S512"},
        "e7QRQ29ubmVjdGlvbkFkZHJlc3N7tA5BdXRoZW50aWNhdGlvbnu0EFB1
  YmxpY1BhcmFtZXRlcnN7tA1QdWJsaWNLZXlFQ0RIe7QDY3J2gARYNDQ4tAZQdWJsa
  WOIOWu3vPBV2nIJ95OpBXF_tgh5pUwmxZiQWqBibQof6hYPGjNGRCIvCW-aDlNgqt
  _ry00TREHDMm0ugH19fbQHQWNjb3VudIARYWxpY2VAZXhhbXBsZS5jb219fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDPM-KCJX-R3IH-7W5I-5XB4-LTOZ-T7OL",
              "signature":"4g5YeyD6a_zCrHOWSTq5kCBM6q1jJmvpgQ9FwD
  Nbl0t5O9oMpk8TXFgET3MeQLj2uH-1cEcVU-gAT4M_4jh_mGTkY0zvXhlLK1dONlx
  H7yDYXQRO9dhAgUO3zYZCqKH9tPc6o4zTE1TBczvQnm8iwSAA"}
            ]}
        ],
      "EnvelopedConnectionService":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTEyLTIyVDAxOjEzOjIwWiJ9"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tA5BdXRoZW50aWNhdGlvbnu0A1Vk
  ZoAiTURLRy1JTU43LUlQWkEtVE5aSS1YWVVCLU1PVzQtN0dNN7QQUHVibGljUGFyY
  W1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1YmxpY4g5a7e88F
  Xacgn3k6kFcX-2CHmlTCbFmJBaoGJtCh_qFg8aM0ZEIi8Jb5oOU2Cq3-vLTRNEQcM
  ybS6AfX19fX0",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDPM-KCJX-R3IH-7W5I-5XB4-LTOZ-T7OL",
              "signature":"uvutpDVGc4irRNccqEyeFQsyfgBZdu290qKr2Q
  cj1am64HhYL7xpC4zuDL-JgXBIyFXkmqocaEGA7M_59GuIbZaNll8iSpx7_MutXJZ
  OxCThNEhYf_IMc582SYEHpzICG5GfqJQ-LLyrV2L23pENez4A"}
            ],
          "PayloadDigest":"e0kaTFFBwxHqQx-n95-KlzbaAViRJnmI5akOWH
  UzjDFeQVeXi3Rq6TLnZDF3FUe-l5yyPSQQba2Fozx6k9gPCA"}
        ],
      "EnvelopedConnectionDevice":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMTItMjJUMDE6MTM6MjBaIn0"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0DkF1dGhlbnRpY2F0aW9ue7QDVWRm
  gCJNREtHLUlNTjctSVBaQS1UTlpJLVhZVUItTU9XNC03R003tBBQdWJsaWNQYXJhb
  WV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibGljiDlrt7zwVd
  pyCfeTqQVxf7YIeaVMJsWYkFqgYm0KH-oWDxozRkQiLwlvmg5TYKrf68tNE0RBwzJ
  tLoB9fX20BVJvbGVzW4AJdGhyZXNob2xkXbQJU2lnbmF0dXJle7QDVWRmgCJNQTZE
  LU9PQjQtUTdLUS1KMkVRLVNLNEItNFI1My1SVlFTtBBQdWJsaWNQYXJhbWV0ZXJze
  7QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0NDi0BlB1YmxpY4g5c09H6QE1t2kwRl
  1kinA3Z18ouJcXM0K7pGExp5mw8ZY7eLksDWLyAK9QQlzLcaibEesFLm6qFAsAfX1
  9tApFbmNyeXB0aW9ue7QDVWRmgCJNQVVLLUVTRFYtN0VMWi1KSkYzLUlCUDctSDJJ
  TS1CQVRYtBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEW
  DQ0OLQGUHVibGljiDmJ4MtjaQRDetXHBXrFKc8Md5UpMg3-U_cQFBfS0emdiAusez
  0Z-xcYQ2kO9CtR8xqOmNJIYEr_XgB9fX19fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDPM-KCJX-R3IH-7W5I-5XB4-LTOZ-T7OL",
              "signature":"V1aaBicDi3CW9oUu1R6pFvAvLjjd2mOWjen7_3
  zyNYTnWba8PxddjU53WK27VT8Wq3FMxD2iucYAuhsrFKXY6jDlPEDC2jf_4cjX8ip
  tSolgxNjUrz-_KT30wTbs1hNaZkSDCmCHj0oT6iQMtgZhgREA"}
            ],
          "PayloadDigest":"jYKEWm5OhrLgVHqoM4naVCH7M8NV3zfLwuq05v
  g94gdJr5UoxDuXYUZhYW-IdpuAOGbW1Wxj8MkgpFywwpWdOg"}
        ],
      "EnvelopedActivationDevice":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQJ-ORER-5V5J-HO5F-3PT6-K4AC-CQ6N",
          "Salt":"slUQ8E8Y3eLzU54quAAYQw",
          "recipients":[{
              "kid":"MBXS-XDZO-V26D-2BEW-YGMH-22GD-NQRQ",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"9ZIAwGMRcdr-z5SaNM9LczN-1vK7QlSTl2bKw
  XNWIW0v4qoQ62m5GQpHvfPuPS4dpvEbCABJcRoA"}},
              "wmk":"rgui1eJ4YjanP8AwLFKV3Mpcu2D88OODoXafWhnaZzn-
  EuYgxZsOwg"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMTItMjJUMDE6MTM6MjBaIn0"},
        "IpQajTjoDxIym0e7LeYpRXSL7SM-1Xsa8UnaYUB4giDf5viCYMwzl5xu
  od_sRL3V3oMSAEX-SDX8FCqRfukKKCNPO8ncqCInBbbebf6rQ8IvCkrPDyfyVn8Fb
  gi4ojrtcUASAnem80SmI5cUhlJeGbx-MX7a8P4cptEkKUyupNIqNs7pAWqV3zlEXM
  YoH-E4LilGwntvkoOhGFwpvy08nagGU336yq1HuOfXd-Rqde_FcMlu5DNZ_HHwG3E
  keUAm",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDPM-KCJX-R3IH-7W5I-5XB4-LTOZ-T7OL",
              "signature":"TTIV2b5O_x6V2kDnVcCoHIQx-UTTBVChRWA61p
  6gvXxbM-4tKC7YOn9puYsC_OGMfrYnKDgl5haAG3Qraudjch6gT561Zv_CsK0eCkK
  9WgyrJAd5YESuNnX1sCzlIHBkIrhmSAUI88ujb-ZxIX3JUjwA",
              "witness":"587TkGaSfVaTGmAx81ICCSpdwo8qNyW9PK2Ems1k
  1S8"}
            ],
          "PayloadDigest":"YBCb1yPKGa5aMmYq9vHYtKKn06y6As342WAyES
  9bcOZ8Y46YDnk2oqhCcmgeWtyxVmLgslymmKB63oz95Gj-7Q"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQI-HDGA-PZUP-Z66M-YGY5-ZYSW-O3MI",
          "Salt":"ygYGghXCHIfL0kj1oD3wIw",
          "recipients":[{
              "kid":"MAUK-ESDV-7ELZ-JJF3-IBP7-H2IM-BATX",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"O-ret1qYkoSuKmXnfOojkMHAeeZy-xF6hdC0F
  wpm49izf-DJHkdPifBlnO4qa1VqBFRbJZKyyMCA"}},
              "wmk":"P0f_wUlXp4l8tr-xbyXB-D5--3SgRfVO6gXkQtQamN56
  3RdO9uOr4Q"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTEyLTIyVDAxOjEzOjIwWiJ9"},
        "DPjTWiFEjIJQKE3CgJyKdPD53mG4CLmWiIRrs84X7_D32-f8qa8DMqgs
  B4bY8KZ8A9cBt48gRPp9wAo0jiSxW9G5_1lmVWxxMoTqxgmPiZmB8f335isOIKQhP
  Q9bEDfZn6AK6x7X1OTobtG38pWSIJhDwyX2t6CZIi8KfcAAX0IqDZuxZh61zcvCIJ
  m7CvniSkNqK0G5M__Rj7i5KFyG8-JKbqgExIpH1U5D64ZBhYzBazG2b6BLZ_OqVMm
  J9JpJGLcjvmATgv0gj9HB1yh5pCt8bD0H8JXl3B4dSmFnCGcomNr5_hBXAm5lYkK4
  G_wQIQyJvfTZUFOuKmMJqmeItPtw4S6sxPiA2uzJKUyTnI6G6GSDg7NwQHM2BVkam
  Chuv6EdCHfYU8-jNXiz7BEXsD6R198lLZHEv_L37of6WleaMCrozpEC0UCfWM-ODi
  xNemeIHyLwz5M5ifnsg4FPZHPToULzmEicS8XlWbyvUIjM6FDomE1D0OWbFGclMh8
  pnwo_9-QrRIC_TjssGsC73WizAGRFK5q81v8oQ5Rd7Nad-fPFUcU9j1oHiIVKYozB
  8_4A1BGFSP2GcrR74Glt9sZRGpj_sAV9wsDpbE069oyZU9XzPKUczw5yoPPRctRao
  t2CYy4yUq0q_j74G24bx8x6w3LvJWt-HMeOuqRcQWjPz-05IJNwLT_9uR5805BY0p
  xpBuYQDHNBEjJZ5_U6QmxZ7pZro8bYCv10CWEowKtnTFtCn9IF7hAgSi2Q1j4AAki
  3zD3PDALBDBUMNyAC0yHunONTiBU_nru3zTa13z39mFlaK2X2hwuhIJouW2KhcCul
  cBeiZzejOWszwqWPW-ht5_yIHx0EZiKAFIfH0w6Zbd3HahRchAOTljNXTrRVhl43c
  3xMOQ_d4acbaO4Z9E3bxGbVOZi-p27jnMqTqnbpVVH_MIAE4OozvOWtq6opeU1vF0
  bxU3EQtK7lROKPII9S21CUFlpp-fY_cyhpo4u04do-Wvv7QmNOBrBQ_mptjOB2YcS
  g3AWsCUFkJw9hNMRq23r-lVvayyK_PXu1UHNdd7-gGmaCdXE93WMFqdmNumwnsex2
  bv8wpWlDh1dAcBtVPqiMs5j4CZeLYrZ38o1vJFO8SE3o5fKesfnsp3RnQDPh_Vm7_
  ICetgUHoaRKb1Xf1Qwo0BMD3gQhurwKm_a7IvSWuUkzHor2mRC73QryKJUonrHCJz
  uKKb4ELpkkspkSDK2fZUjo-U0QSa1nESBBnHt8DL8dN9CSTr-6IOGDDuXxvA1q4d3
  NOVKRYI3rejq9tahyvmIP71MHLY97HL4IIPOcPvp1pfYfX4p9bd3jtY_VQRbjiTMa
  tDSqBdu4yaJ0njksCG9cFwPfPLBWraqE9_YGmzTWRycQAfUK1veLq-Fng0cJAHcLx
  jl19musfwp_BeFDOYQ68TX4we43CblZG9ajqb0kYPOqhoNYLj8XFRFVztGqKPEg-7
  5EQZAMGGRc_Srl5nJ5ZG_FFbWK6RgCFv44VBT6sPNn0fhliQowMri5BHWaMSHqmt8
  7NnEQPzfkJVxTzYcLZrr9K_JltN4vmqHt2DEGaIu7mtMTmXVpRcdgTzik5Mz_RAnM
  sc2yVJvUVhWeLxISaoCVB4Q2wuv75JQ0-WfInZArBS_oa0Lwnhnm2THR77JIu3JDH
  sf1ZkAaGJfggXUyFDn-hGloNLly5jSE8BSarX2Jt4OJnUn69Xl-iGiS_TO2oc-IHw
  0TEdh3sYWbo51dV5spth7zLoStRb_aU3rzyNhhYN17UvDu2_jbK9VZMG4n_TXJ2sm
  T18vIoHjQcmzC10rajJiBh-SLC6HI4EZ39QsItKId4CjUfeHxDZwOqWJGRwd9Hwjf
  IJwuOhYmdelUmgAOsRk2OFbhgpS6uHB1gKma0bzfe5sQdMGgHCAdokWX6qXSwFIm_
  yWQqYSQPO2wbFfZfUP5ubMScIc6bTy_-YELp8eCPCAKnYPacFJ28r3HnaIU9V9ykQ
  J9uP2YiyRnNs20fJ1SEhjsoWnB6Vd0BePt3ePHDWoY7m1bzJB-2InJ6r5RlK3IPci
  HpDl1p_QDCWECzO96SQOFEEb8Czym4Toq0IHRVSQ1JJih3oOz7L43JVQwlkP6U_m4
  bMtSUayp_qfeiGhcdNx52trzf-wRl1sRift1e_dw72ouLMdIpw_y95h9xGLxbEdhW
  1toxyiiEDVqy77qWSrIoVDDyFmeH21KrxA2jfbY3D5fOKF7lHb30g3Ejjb31frmOU
  L4Gt7CWnHVI0br3rM7GL1WOm-gCnYaFopbH7ylL03GzHZcs1wfJtuNtKsFLP1Ms84
  DLsBW6FF3jQWDFhgZWoZKEJLdLBpbd7frqnmDslZc2VkV8EjjfTX6rwuJ8TWhFPW0
  cJ6vIcDekwbPKpUYEFCSnWF77vDYcsw7wsO6Mc1HQU3FmkD9wvUtPLg2Ra_blE3Ge
  Q3kyvUVfc0svSYfVcu00srwLTKoHrltQlMwOjhfD-edT0y-EFkZufRa80cTiUYxNh
  kCSoLoXHbQg-a82__oceS7NkdoLMVfQbI0QXaT51vIbdmdrCCZwMVWy6zD4yc5Y_M
  Y27tRanSdtFKD8Rw0MqkqC_SwRoK3tsrwEIjJkr5NIvED4iV6u1iA_ELpwRfk4KNH
  2WsXs8Kn9BuSZZLucIVBZ1k71m_evyAtjkXx1pv5odz9yeO8u8wRqaA2usCnQ28Yr
  3o-WsLEkXpZ922N_IFK4ktExfI3UpAqCkDpJTT-FuEOpX_6EVSEXNCucGLtM5TCeB
  E4vuc12MrjwS7SlIvBNS9PvTlDj_5krZD8t96OewYWjoZzUv8LjqKfbAAcrunoqSo
  fjNCngbGhLkjWliiVpKjKPrSiFfTrzfgoGzJJFLIkI0UciOkylpZ4h5K5NVIU2GD6
  J9lXKQv4_KrY_zIKm51XAcAe5DTU30p0diyx0dG_2B-5ZP4LTnCxh5D6h90FlFPmj
  qfBN0PFdJgW4Ds7nS0KJxzz-VZod7Ffbdk2jj-zpPWPNyCJl2hE3tZ7Q3nbuWAJ_0
  JYg1OEkEko20xDihMiVrsq3-b36p_4c6Ak-FG_zdl8WCl03EJlJ27PVS_TVaYgNVi
  O-LOJ9o4ShpneHeHZNj7EMxc0FsVcuvcwyPuoAjVBLre_3v516iCf2f2Id7aDwv9W
  94WxQanRhFCRcRCB4kdy2_PQBtuHpXGSCToZBIT9NoJWl_XH7gLHv0FiGUI0606xI
  OgW9QX_4tp1obbHP7D-og3rOOlKM_Md9CEGLZa4kTWcHrZg1_bh0qvMBEfXqbvuI9
  GyXygkDO5bzZQ8T9OISKid_QjFNe9GjyTuFZSJ_k7gLxMhTua8J1vr6D4C7854YtY
  0hJRPqxn8IwvLYDIdCrCmgexeK6ZQc_Z5PikRk3DVLU-v8NQvOlyjqDZACEwFSHXq
  Evh3LeJ9IaWfnFICBdWXe48GMycvnJXKs8Z5qEl_OHBS42kzJpQVz_rQaE54GLBTV
  ofDUmAyDEbCFe2AHt7mINA-8taFRGAK2tCX92OF5Db-fTukMrCVb-8yOHaMayNSI3
  KNj16wCxpyzVH_Gg7ID_etE6SJ35gILbRqlQ50KNjOv1LpOazUC3Mm8VKsFB3Ywv7
  B3vMoPuB4bpPMql0ikFHJFBg0QQ1QnoBcKycRwxzHgtOmwSMQsdpi-NfCat8yD0L3
  2ky48uzX8PhZ2z82WnPOV7nr2HPb-hn_gluVI92nl4wwii-AIEeSKLMREDH_9-9Zb
  c5hiLz77j0UnD-oOOQjF6b2sIE7XnEXO0DKoApRklIADewiyXa4pwwrLXReoOlz1M
  4mvXNyM5hT_Md1j6ow44cHLzf_0jf9ttWfM83dz06J2V9pruA1oiS7zRCnwA_9Fa3
  brgNPDQHb1R9sL6n0bnVl6Mh6wjKcRQccCV-Hqvy6ZeSijPYacyx38S51FKmkD1xm
  lAZHqz_nrDgzTqP690KzFofzb-Saajk662orq52rK7IXJWbYrfA8lebO4_UPHgWOZ
  -sEE6KgsIsfOah8YkC4sUlpmhOoAIrf2S72ne6Xqfyj3A5O5UKgQvD7__IxCVsd2M
  x06NAQcEGfzRDwzpX4kIPLWq5CI22GsWhm3YLf3xIIui1nI7h1uqoim8ENbaPIael
  vgIXMRH6r39QMtxdBcOES85V2qxkms4PxBpf8MoLAS_6qMngnqIiz32kpbkY-Yqyj
  EGJwx0j9-YXWYI2XTCPKuOlgd36-oZLjTuy-LERgJVmwYDwNCLBKfjRYuv56mL7Cz
  M3YEE2aC-9UeIvfs8VFCAk543WMV8a56yXnhWYoITY4evFpz1OexZgvBGz5gp-ypa
  LoqbCO22j-0kAsFu54lp5zxqVRd61eP8S1FYAL9xq1kiTCxnNYbhizPCBnhrW-d6P
  fDN1wQAzI3QFUyDSXoFSBLXbmeA0VQbsHlHBt1eCvLsYPsYMQATMRRLx10grZawbS
  4FAGZddqPK8QDTb45Jm-ouiYDVMKjZoTG3r4TDc8Y1mnAVf7U7X7x1au9BrzgxcUU
  GM3AMkoz6riCs-63mX2XCHXXSe9uIMt3A-GHC7TukXTrCGkSkaODF9RTmbvnozpvx
  lmJ3Ci03U9RWg4FS5E2D9XLMDj_UCVHh_EwJVYXZ1BVLmtUuViE6xYoDlMKoh1xMk
  -ydhLu637FUHxG7pBCu0pk677EgkINBrpFo19MqQf1aSRDviBBEjHIKk-yXVOEYnM
  _Ts9OpVGz-n57QiM4B8j4WSgVYMbmHEOwpK44uyxJgAC9miMCUftBKQBoIZ1P2ZhB
  ljrMAcFoNjQMvOwNIdI-J2rj5NhWSd6FJviSphetQwVujAb0g_uuDmwLlA0UIQve3
  7JafzJbYUec778qyDenYW-mrWGv-Ifn-l1GtpSj3NpLjj_uK8yP5WDy2C59tx2wEP
  -LoG3S4PtOklIdGT4fxP3tDe9MsOILlTgDiipb-3o-PSfskNz7CuV8XwTjmLvud06
  ctMIOYMumBFi2v1-ZFZnrgzCdCtgB1jkE4njdboNNVUSxOmMJELu7MFgttGsG-EGH
  JT2gblkTZZTGFTd12n2DeqOrefoCyl1qM_xoOcLbuvDyPXJyiP_QPsr4hRFLObDRl
  NHB9VP4K4otUUfD4R7Vij4a8RoZ4qiqAxYdgjeWd7tzx9FoAa1g3irZ9i3DnU6n4a
  RG1z6wuBPb4LvuR_Q2wwjxT4Ssv0l0P4ntwuH1hhtFa_mFEevETDPhZNAewwM_YHV
  vOSeBlGxCqMHCSsDwUvxol10ihQ-mBMC1bCWSAzVuJ1xDnSlIVXQZR3YhElbVsdYZ
  4fiWHLseekoE3JhSdIyQCXGsXklJ0kL5qzILv33d_aZN1TcR2SsF2BFlujXZdFIrb
  7Eh08gjX0PjarA_xr_0iIZ2jZgZrjZQYj97sdgoZ-ZxA20SeBh9TwN3WE03aQXMuT
  cWQL1AiS5OyamsbK2zF4mu5l8zoJjNZxT4gVqmC_nb0VXeQjDOIBc_Z3Q7Tfj3a38
  PRSo3Bza0Gl6UtwotE32YB18pliICIjz5d0RgJALPLqzwiFL5s00W-2AIKc7j3PQX
  MrTXpK0wpkCUbERMLCazBFD4D0MlB0vKRzNZuYnoMrQgwKUizXJZIUN8tRWJlr3iC
  3TCRxNU3HMUdkDqjrHnIQNdBavljIeXBPfLhhzXzGvGqPcom0f6AFRHj4U4CyW7DQ
  Hb9BxU8DODgmkzr9jMXuEkZ_nrqbYw1jVBMmnplc_PFcRfC9gwN3VGHQHCz069MVK
  9YKVS5pniFf_zNT-GysoPPWge8og68g2EZINhgj309_7CH7nIos4egEHEMeLxt7h0
  AAwdq9yrBH8sJH1dwYBtnnjyPSRclrN0mizRXsk7gPQfjQFsAd6ZA4LtlTBzfz5Y0
  0SxLmN8zDGQQd3RyH7Z_In2BsSX-yMdXtIy4IV202vEmMoyYV9gLZdo3xYmgyrAKD
  _ufw305wFTQfHfGfuf4nN4DKOcUw2u6AjjWPdp2SWALZYxis40X34FRog7Czo8Yhj
  QdP1Z48DfkCRqCcMzoiHTQd000_O5nDiVmd2kI7TSkfTDd8ydBKpgBPSOzaPQBGDT
  yb5nYU9FHjS6zQRFjrC4av5c54OUjrOO3_R8dsrlsG2LGmdgd8jACxKvCxABPJmbA
  AK4jaNv63XopDiYVi6qBfSdmfFJOuFKDhWjplBOVfM32OrQjLnddz4eRClE-pIPea
  cczrPnFJs09KqaIWlGRizV6lleXTDpqhJbP0BAftFBYPtZ3JkwxaBjMA7L3dut1P0
  vSW8BvkVvBDHkdGA9AX3nsfg9R3GvZ5DSjMchRLL_BvOWr1NBT4dw0SkYevI3hFU8
  CWOChJTqVqZx7bIZRl5e9wDyybmvqXDij-qZfpQ2c8krxmQYJAHUwG5aEK6b3soue
  ONuFhDdt2Wgk2wOHsAf542XokrgybZW3JA5D1lnZfAVEIcO-DfPwD8ktC-APfecOl
  zLtoXvGnUrZmkWSMoaaE5ABABk5yPVuBmek3hMLH5syyZHQCP6QKZZ8o1QDV3Kcu4
  -4IfATpLO8Gi6I-Zfb29Asn0fgO1X-NYnVqjxmhiKImk4RrDo8MDpAXIRCrlirQ8V
  -3qKTI-TZVdqH8ZM9YSC3u7HMDR5MU3OLhxQqXQdH7AG_kdwiy_yn8l4jpLvkIeBy
  v-ShhE0-C4m4_197qovCzBr12cjP_01GBuIZbceQontfbwIg738anK-yldQRc2LJP
  Ljxum3RT-y6rlMhQHLL6uVdPmt7GV8YPgjoNAAwtH-HTpz1MH8Nnt_YnFaPNHy5G7
  SHkveMmrtnq2JP5LDnxMH-xN25JZLgvJgnO9DgH6R66K_gLKYohjmL6DNs7DrwDBT
  tYQ1uQeiqPeifWGevlLbNv1rm0UnkP_3iG3r948krJnQVlUJUgkPTSww9To3Fims9
  VBPn2LfFAWQb7FbMWwD6bu_oSn9CnWp9X4tR0TaxuztqWERZPEIDiPUwCI7RFAVki
  mU4q-GlfDzBUeZKATJlI2ubUSY52IqCNQnEWGJ4X8lpJkVoFEgvSYfv8j2juat-jQ
  kUuXn5BDUSaY3GrRuMXT9EvAOFx9J2emMU36uTVcBfLiif0W-_7j8Wfc6Ytr6PMag
  hWDrj4s3j7oDyxNJZq3QfoYOxktMLSOKOGsUIm3jsOlcAEritOsn5AX3uT4KsAliO
  B2QaDABJO9q39Vps41-Hxkm-DCGKCP9oeuLVdfEKLz5S2OnSaQjjj8IhaZt5kt9ES
  W5EP__4LEpZLTvH0kXfpWCq1Zs9BNY0-qG3F-eaeaVGXQ78KzM6K68lpcM8_S3gGa
  Q-inwPYoEbWIZzpfjIP_qr4y8v9iIFmOQ3cArpXiGu0jUKZ-wkyG0_FkRHULbd9tM
  nQKWCRLZJIPXwxg7ed-FW2DvvAuwojhOi_5coMpIeSdRHUvRYukFfckNc2WnPLFrh
  8e4jl0M0RKvDzcoEcDHSVtMNBKU13UeG5zrTagrQWwVfZEqRXC10fodA0UIewAbmT
  a45YgZG3eFQQP6J6qIvkdyEuJqMB2NABXY5EOJNo5Abqm5ibv8pHhDVfT5omVMzBM
  WmUACsuT2OMiKxq2J00uc8N4meqVcYotOJgMX3T8gMomr1rooC01YrdxHBX_eb12z
  qs6qRMK1BF--Rg-29yViWFov2WS2mSFrQTWiw_TqxKeNqZsKcJiK26jRU4iKBCN1k
  H9seLg2epsZdSsmSJztVlRf3ZYryncCDGKIHtDPfXn4YWiq-34wnh-_NMSMSX2cDS
  KuB5xaujAIcXKupELEryjO2l4lz6e2gW3Up9GzY70vwujpscTuYdJH9NcTjopni6V
  0PfcI-C8_wJP0AouwxVixcyIl01QA6-K-KjMnhw0JMJgbk1pqqq_OyDRoUpQKd1X-
  yooOawVpqwLpqGFZcdOlYbfEH2LQ99nHqq2EYFvJASHCpc3QArAyEXh5DchqMVD2q
  O30BYoV2zxcA_uFxI0mvjCt4pxSVEfW2BgHjFJQ7XDeZwnDlmdwxFasaOiicQ5Fy5
  PIivRewkFzC_EHSMDCT1I27ry_JFYCP2bVoFnom6YwZxmaIEQMUf1CLIZjKcrNKKv
  3vifnlEKVtKmMNma1W4ppicgZhXxneKvfUQLi3N7fsN__8wEahJWyv2F3JxbnWcKv
  NbhPOiXBFCb_sdERYKGdG4t0Mvu02trHz7Jo_BYgZcFPzRC-U8nvFwN-IuNgF6vov
  2KQTWO6FOYURdGnw3I2dTp4qwszeVVTV79bT1yUdZ7QiP8qc9lv3wvfLShXNmfdLI
  VAB5DevyEsqQWWaRzjKcxBzHKKk9U45sCUDYQBUdHBQjlHjCYfTS0lXhe7FUq3gjV
  OqQIEXZAPd27tUgH2NbMqA9lMLIbmBbMuYcJkkFwC6gBAmCdRTRJ0H-9ilcAGF6T5
  0F769fkeFqlkRstiCl0v29soC3aZ5Tujw7LdB1uafobDbh3-j9eaz6RiwgzHDlCtb
  R1l234nZwsI9h2I1Ages6BDKJAbLJT99nwVR4nmEPA-pz5oYUpvGGZK_g3r6qJKIJ
  KBTEUdqX4yNSbMz2E0Q25vDKxz6-x-qnUVm38wAgohlNrhWM",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDPM-KCJX-R3IH-7W5I-5XB4-LTOZ-T7OL",
              "signature":"-vw1cBDcslhaYU3gV8vknExTYWvf6fYRExAQ99
  l9hpajFi8_-GVexr6-8M6ovjVGeiITw-y1Fz-A0UkECTZKaPQtItj2vbibpuN0V31
  z7lB2nxzDK6yL0TxWjp0fmSc3bEkTFL4zku5Xs633ONFYCQoA",
              "witness":"KxZoFUcdGaCeVEvDM89wK9pKcsZP1d7p-2FBXRae
  Pvk"}
            ],
          "PayloadDigest":"ImDy8XODDL3I8GT8039puaj1E7j6JcQsqare7b
  a-ignvfN4fh200K6NwSCK2GbuobuEuEcmj8tSHZQW2truGUA"}
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
<rsp>   Device UDF = MC3V-V6L6-YHCW-26I5-XFE3-6WGR-BKVP
   Account = alice@example.com
   Account UDF = MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
<cmd>Alice3> meshman account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MDSE-WBAJ-7OCH-JGKV-CB6D-J5C2-UD7R"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

