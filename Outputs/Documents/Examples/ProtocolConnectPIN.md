
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=ABHT-VP25-WUQY-ZNTF-CJ4F-5AWU-ZA
 (Expires=2021-12-20T19:21:17Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcu://alice@example.com/ABHT-VP25-WUQY-ZNTF-CJ4F-5AWU-ZA
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    ABHT-VP25-WUQY-ZNTF-CJ4F-5AWU-ZA
<rsp>   Device UDF = MBJ4-APU2-QYGV-OPLC-TDDY-5SOJ-PUYN
   Witness value = FC4F-LTCQ-MEOC-NS22-2Q5U-CVI7-KHM7
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "MessageId":"NBLZ-3VNC-6K3C-3DHA-2XXE-2LWH-NE6U",
    "AuthenticatedData":[{
        "EnvelopeId":"MBJ4-APU2-QYGV-OPLC-TDDY-5SOJ-PUYN",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQko0LUFQVTItUV
  lHVi1PUExDLVRERFktNVNPSi1QVVlOIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTEyLTE5VDE5OjIxOjE4WiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUJKNC1BUFUyLVFZR1YtT1BMQy1URERZLTVTT0o
  tUFVZTiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIm95bzgxcDVhd0d1VW9pLWpOUzNPMFZ3RzlyNUI3Yk1TdkpGLT
  lwaHVYM3RKQTVCeXBTN2sKICAxblRqSVNDR1AyQzlpYUZFdkp4WldXdUEifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTURXWC1GTktNLUlZU1Mt
  SVRFWC01UEhTLUlWSzUtTVdGVSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiTXZFS3o2VVktajVzdXl4UjFoaXNnd0F
  zWDFaOUw0NDdOVDAySi1KWnRFMnVHcEZsMEtOMwogIC10UXFzYmRiWEw3LUVHaHVV
  cUF6OWpnQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CQ
  TQtUFpRTi1NVEVPLVpCTlAtUTRWQS1ITDdaLVlGWUEiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJUdXE3YVNfdjI0
  cXltd3pSckpLZDZrMkFPV0JOS3VDTVlyY3V4VmxGWHEzVmxxVlZzRE9nCiAgNWlsc
  FdRMGRZVHZ6MHVpU1dWNW91TEVBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQkJLLVRTRUwtUE9aRC1ZV01LLVBWTlMtQVpCMi1OWlJ
  aIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJCOU1LZkdVWjU5cE54Q240WEZMUnluWExfRkxVWFF6dTE4bU9VeWdFUV
  FzVW9zUEtIcW1fCiAgOEhmT0lhSjUtb3ltSThIblBhSjd4Z1dBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBJ4-APU2-QYGV-OPLC-TDDY-5SOJ-PUYN",
            "signature":"OguhYjOnMh9SyaMieCFXZsP3iyYZ4nuYC98-epCq
  o3xs6r-M7VoOUqKuTpP1zLP7D1hvAnkZ_JCAmy1_IrZSGXsAfhapb9EvVV1TFTxyp
  BicV7AoeRvGP3NrrFOozeHjNHyeeZSKdqeuj_I04xFXVh0A"}
          ],
        "PayloadDigest":"fZGKbvZCnkDvktVvpUKwozzJssiPoAIxZoTWQcJz
  w6OAOVaKQ0kIxvGrYq_KkHO8SCZBbKBOuSg593pqe76bvw"}
      ],
    "ClientNonce":"Y7X9K1w_W6nq8kLE8ZYp7w",
    "PinId":"AARB-FDVG-KWFO-YWCU-4CGT-ROEQ-TJSV",
    "PinWitness":"-9UcclITcIgDhtNmIERbGVq-Gb1vpJeo8JiCyHZVKxZYxBG
  dXs-xWWkSPJ2PbA0cCVDSq7seE2Pm98NLM57-EQ",
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
    "MessageId":"FC4F-LTCQ-MEOC-NS22-2Q5U-CVI7-KHM7",
    "EnvelopedRequestConnection":[{
        "EnvelopeId":"MDZH-YKJZ-S5RQ-OIA3-4Z3I-JUXB-NCKY",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQkxaLTNWTkMtNk
  szQy0zREhBLTJYWEUtMkxXSC1ORTZVIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyMS0xMi0xOVQxOToyMToxOFoifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJNZXNzYWdlSWQiOi
  AiTkJMWi0zVk5DLTZLM0MtM0RIQS0yWFhFLTJMV0gtTkU2VSIsCiAgICAiQXV0aGV
  udGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1CSjQtQVBV
  Mi1RWUdWLU9QTEMtVEREWS01U09KLVBVWU4iLAogICAgICAgICJkaWciOiAiUzUxM
  iIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI6ICJld29nSUNKVmJtbHhkV1ZKWk
  NJNklDSk5Ra28wTFVGUVZUSXRVVmxIVmkxCiAgUFVFeERMVlJFUkZrdE5WTlBTaTF
  RVlZsT0lpd0tJQ0FpVFdWemMyRm5aVlI1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxk
  bWxqWlNJc0NpQWdJbU4wZVNJNklDSmhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV
  04wSWl3S0lDQQogIGlRM0psWVhSbFpDSTZJQ0l5TURJeExURXlMVEU1VkRFNU9qSX
  hPakU0V2lKOSJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V
  3b2dJQ0FnSWxCeWIyWgogIHBiR1ZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNK
  VlpHWWlPaUFpVFVKS05DMUJVRlV5TFZGWlIxWXRUCiAgMUJNUXkxVVJFUlpMVFZUV
  DBvdFVGVlpUaUlzQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KIC
  BnZXdvZ0lDQWdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0F
  nSUNBZ0ltTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmli
  R2xqSWpvZ0ltOTViemd4Y0RWaGQwZDFWVzlwTFdwCiAgT1V6TlBNRlozUnpseU5VS
  TNZazFUZGtwR0xUbHdhSFZZTTNSS1FUVkNlWEJUTjJzS0lDQXhibFJxU1ZORFIKIC
  AxQXlRemxwWVVaRmRrcDRXbGRYZFVFaWZYMTlMQW9nSUNBZ0lrVnVZM0o1Y0hScGI
  yNGlPaUI3Q2lBZ0lDQQogIGdJQ0pWWkdZaU9pQWlUVVJYV0MxR1RrdE5MVWxaVTFN
  dFNWUkZXQzAxVUVoVExVbFdTelV0VFZkR1ZTSXNDCiAgaUFnSUNBZ0lDSlFkV0pzY
  VdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGwKIC
  BGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0F
  nSUNBZ0lDQWdJQ0pRZAogIFdKc2FXTWlPaUFpVFhaRlMzbzJWVmt0YWpWemRYbDRV
  akZvYVhObmQwRnpXREZhT1V3ME5EZE9WREF5U2kxCiAgS1duUkZNblZIY0Vac01Fd
  E9Nd29nSUMxMFVYRnpZbVJpV0V3M0xVVkhhSFZWY1VGNk9XcG5RU0o5Zlgwc0MKIC
  BpQWdJQ0FpVTJsbmJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxQ1F
  UUXRVRnBSVGkxTlZFVgogIFBMVnBDVGxBdFVUUldRUzFJVERkYUxWbEdXVUVpTEFv
  Z0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljCiAgeUk2SUhzS0lDQWdJQ0FnS
  UNBaVVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjblkKIC
  BpT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSlVkWEU
  zWVZOZmRqSTBjWGx0ZAogIDNwU2NrcExaRFpyTWtGUFYwSk9TM1ZEVFZseVkzVjRW
  bXhHV0hFelZteHhWbFp6UkU5bkNpQWdOV2xzY0ZkCiAgUk1HUlpWSFo2TUhWcFUxZ
  FdOVzkxVEVWQkluMTlmU3dLSUNBZ0lDSkJkWFJvWlc1MGFXTmhkR2x2YmlJNkkKIC
  BIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlFrSkxMVlJUUlV3dFVFOWFSQzFaVjAxTEx
  WQldUbE10UVZwQ01pMQogIE9XbEphSWl3S0lDQWdJQ0FnSWxCMVlteHBZMUJoY21G
  dFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZCiAgbXhwWTB0bGVVVkRSRWdpT
  2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0lsZzBORGdpTEFvZ0lDQWdJQ0EKIC
  BnSUNBZ0lsQjFZbXhwWXlJNklDSkNPVTFMWmtkVldqVTVjRTU0UTI0MFdFWk1Vbmx
  1V0V4ZlJreFZXRkY2ZAogIFRFNGJVOVZlV2RGVVZGelZXOXpVRXRJY1cxZkNpQWdP
  RWhtVDBsaFNqVXRiM2x0U1RoSWJsQmhTamQ0WjFkCiAgQkluMTlmWDE5IiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6IC
  JTNTEyIiwKICAgICAgICAgICAgImtpZCI6ICJNQko0LUFQVTItUVlHVi1PUExDLVR
  ERFktNVNPSi1QVVlOIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJPZ3VoWWpP
  bk1oOVN5YU1pZUNGWFpzUDNpeVlaNG51WUM5OC1lcENxbzN4czZyLU03CiAgVm9PV
  XFLdVRwUDF6TFA3RDFodkFua1pfSkNBbXkxX0lyWlNHWHNBZmhhcGI5RXZWVjFURl
  R4eXBCaWNWN0EKICBvZVJ2R1AzTnJyRk9vemVIak5IeWVlWlNLZHFldWpfSTA0eEZ
  YVmgwQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJmWkdLYnZaQ25rRHZr
  dFZ2cFVLd296ekpzc2lQb0FJeFpvVFdRY0p6dzZPQU8KICBWYUtRMGtJeHZHcllxX
  0trSE84U0NaQmJLQk91U2c1OTNwcWU3NmJ2dyJ9XSwKICAgICJDbGllbnROb25jZS
  I6ICJZN1g5SzF3X1c2bnE4a0xFOFpZcDd3IiwKICAgICJQaW5JZCI6ICJBQVJCLUZ
  EVkctS1dGTy1ZV0NVLTRDR1QtUk9FUS1USlNWIiwKICAgICJQaW5XaXRuZXNzIjog
  Ii05VWNjbElUY0lnRGh0Tm1JRVJiR1ZxLUdiMXZwSmVvOEppQ3lIWlZLeFpZeEJHZ
  AogIFhzLXhXV2tTUEoyUGJBMGNDVkRTcTdzZUUyUG05OE5MTTU3LUVRIiwKICAgIC
  JBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"
      ],
    "ServerNonce":"xf5YhcAeuyDUIkRdeBTEPQ",
    "Witness":"FC4F-LTCQ-MEOC-NS22-2Q5U-CVI7-KHM7"}}
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
<rsp>MessageID: FC4F-LTCQ-MEOC-NS22-2Q5U-CVI7-KHM7
        Connection Request::
        MessageID: FC4F-LTCQ-MEOC-NS22-2Q5U-CVI7-KHM7
        To:  From: 
        Device:  MBJ4-APU2-QYGV-OPLC-TDDY-5SOJ-PUYN
        Witness: FC4F-LTCQ-MEOC-NS22-2Q5U-CVI7-KHM7
MessageID: NDVT-POHA-PJWP-AABG-YXO2-JU2C-4LYT
        Group invitation::
        MessageID: NDVT-POHA-PJWP-AABG-YXO2-JU2C-4LYT
        To: alice@example.com From: alice@example.com
MessageID: NCM5-RFA7-MCBH-UTRQ-2DPH-RIUN-DZEE
        Confirmation Request::
        MessageID: NCM5-RFA7-MCBH-UTRQ-2DPH-RIUN-DZEE
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDA2-TF33-S2GI-CUQB-W7MD-7SUH-TMHU
        Contact Request::
        MessageID: NDA2-TF33-S2GI-CUQB-W7MD-7SUH-TMHU
        To: alice@example.com From: bob@example.com
        PIN: ABS6-M3HZ-3XC3-T2MP-5KAC-7UQW-M65A
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
    "MessageId":"MANC-ASWS-EKPK-67HT-3EES-BVSU-SETJ",
    "Result":"Accept",
    "CatalogedDevice":{
      "DeviceUdf":"MBJ4-APU2-QYGV-OPLC-TDDY-5SOJ-PUYN",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQjRBLVhPTFIt
  MlNYUi0ySEdBLUc2NUMtT0lFSS1SNTNIIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyMS0xMi0xOVQxOToyMDo1N1oifQ"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJl
  IjogewogICAgICAiVWRmIjogIk1CNEEtWE9MUi0yU1hSLTJIR0EtRzY1Qy1PSUVJL
  VI1M0giLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibG
  ljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJFMVl2Nkx0eGt6dUxnMDBHc3VSU3FwekxRaFdoV0ZLSWdFTzV4
  cWljZnFtUWdjaC0wY2VLCiAgaTAxcVM4eFNUYWowcVh0U1lLMjlFR21BIn19fSwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2
  VydmljZVVkZiI6ICJNQ01QLUxPVTUtNENCRC1WRE9XLTJGQ0YtQ0NDUS1HRVNGIiw
  KICAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1CUVgtUkJM
  Ty1ZUlhELUhLUU0tVkdVSy1VMzdaLTVUNkIiLAogICAgICAiUHVibGljUGFyYW1ld
  GVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcn
  YiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIk1BNkFHQTJMUFRoM0k0bVN
  YWjFiWW5WWnkzYmNmMVN0MGMyMURXUFgxNHc3Znc2QUZQMXMKICBHY2hlU0lwQV9m
  ZTJ0ODE2R2ZPMkxoeUEifX19LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogI
  CAgICAiVWRmIjogIk1EUlEtRDRUNi1aWEwyLUJWQlUtVjNURy1SQjVBLUVSTUEiLA
  ogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUN
  ESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGlj
  IjogIjRteHF2cy1ick51bW93STBJYXpremFmMHk2cjVPSWtsOG5jRmp6S3J0akpsW
  EItSEYyd1EKICBNbXVXMjkwZjZUNTNXM3Q4S2lvYUE2cUEifX19LAogICAgIkFkbW
  luaXN0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTURPSy1aMkxTLTZ
  BTzYtWlU1Vi1GRVVHLVFYUEotSVI0SyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJz
  IjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6I
  CJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIm80aGlVbnVwODF4VkpHTVRpS2
  1kTlBIejZHLWdSTlBZbFEtQ3psbHE2ZFlVUERiVGU2TEMKICBtLTZLLVJXQU85M21
  WdUNvcGQtVjNhMkEifX19LAogICAgIkFjY291bnRBdXRoZW50aWNhdGlvbiI6IHsK
  ICAgICAgIlVkZiI6ICJNQ05XLUg3WE0tRFlYVC1YS0JZLUJDVjItSTI0Ri1BR04zI
  iwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleU
  VDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Ymx
  pYyI6ICJSWHh1Q25LbVBucTc2bVpfTjN1Z2ptR3JNLVF1X2RLVEpIMGp2ZDkyQUNY
  RVZMd0hwZFhhCiAgRUJId3dHbHVhMWNOa0xPYVktakcxdkFBIn19fSwKICAgICJBY
  2NvdW50U2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1BT08tSDVNQi1IV042LT
  RDU1MtU0pGMy02UkRMLUtEMk0iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0
  NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJFaGJqM3N0QXlvV3F5MkZZZWtsNnFlO
  FA0T1QtNlp3LXBxQmQ4WjBGV3NNRXhMZTJ6Q0ZOCiAgS1kyNDlxZWNCcldteXdrbW
  0xYUlORjJBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H",
              "signature":"ETG9ctLfHFUVeM1haWrNoBu02rJiSArwfABcck
  L3pyKSOYqDUBu9gdS4LBoHxiUuvaK5Ocp6UWoAW_w7AYTzwRGDMM2mfkBzd7_eaXF
  aHzQsDe3hSMbnmy5SfdoEEz9U5A21sbj1dpbd65gSI4OrWw0A"}
            ],
          "PayloadDigest":"hy8dTWi8kXEFMZEz-Jq2SqIpcng0JxX64u7M6-
  x94DtJaS8R6bR_nW49OP_N5IUYHk1ee80JHN0GlQFELwfBCQ"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MBJ4-APU2-QYGV-OPLC-TDDY-5SOJ-PUYN",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQko0LUFQVTIt
  UVlHVi1PUExDLVRERFktNVNPSi1QVVlOIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDIxLTEyLTE5VDE5OjIxOjE4WiJ9"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1
  cmUiOiB7CiAgICAgICJVZGYiOiAiTUJKNC1BUFUyLVFZR1YtT1BMQy1URERZLTVTT
  0otUFVZTiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdW
  JsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICA
  gICAiUHVibGljIjogIm95bzgxcDVhd0d1VW9pLWpOUzNPMFZ3RzlyNUI3Yk1TdkpG
  LTlwaHVYM3RKQTVCeXBTN2sKICAxblRqSVNDR1AyQzlpYUZFdkp4WldXdUEifX19L
  AogICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTURXWC1GTktNLUlZU1
  MtSVRFWC01UEhTLUlWSzUtTVdGVSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjo
  gewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJY
  NDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiTXZFS3o2VVktajVzdXl4UjFoaXNnd
  0FzWDFaOUw0NDdOVDAySi1KWnRFMnVHcEZsMEtOMwogIC10UXFzYmRiWEw3LUVHaH
  VVcUF6OWpnQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1
  CQTQtUFpRTi1NVEVPLVpCTlAtUTRWQS1ITDdaLVlGWUEiLAogICAgICAiUHVibGlj
  UGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgI
  CAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJUdXE3YVNfdj
  I0cXltd3pSckpLZDZrMkFPV0JOS3VDTVlyY3V4VmxGWHEzVmxxVlZzRE9nCiAgNWl
  scFdRMGRZVHZ6MHVpU1dWNW91TEVBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6
  IHsKICAgICAgIlVkZiI6ICJNQkJLLVRTRUwtUE9aRC1ZV01LLVBWTlMtQVpCMi1OW
  lJaIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0
  tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB
  1YmxpYyI6ICJCOU1LZkdVWjU5cE54Q240WEZMUnluWExfRkxVWFF6dTE4bU9VeWdF
  UVFzVW9zUEtIcW1fCiAgOEhmT0lhSjUtb3ltSThIblBhSjd4Z1dBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBJ4-APU2-QYGV-OPLC-TDDY-5SOJ-PUYN",
              "signature":"OguhYjOnMh9SyaMieCFXZsP3iyYZ4nuYC98-ep
  Cqo3xs6r-M7VoOUqKuTpP1zLP7D1hvAnkZ_JCAmy1_IrZSGXsAfhapb9EvVV1TFTx
  ypBicV7AoeRvGP3NrrFOozeHjNHyeeZSKdqeuj_I04xFXVh0A"}
            ],
          "PayloadDigest":"fZGKbvZCnkDvktVvpUKwozzJssiPoAIxZoTWQc
  Jzw6OAOVaKQ0kIxvGrYq_KkHO8SCZBbKBOuSg593pqe76bvw"}
        ],
      "EnvelopedConnectionAddress":[{
          "dig":"S512"},
        "e7QRQ29ubmVjdGlvbkFkZHJlc3N7tA5BdXRoZW50aWNhdGlvbnu0EFB1
  YmxpY1BhcmFtZXRlcnN7tA1QdWJsaWNLZXlFQ0RIe7QDY3J2gARYNDQ4tAZQdWJsa
  WOIOQWyI9MQJKzlfC31_lYblUy2IUwFaXeUTW6NwwrHz2Rscsgldr9BaHv6a2qCmO
  _9f7ATCy7qEi90AH19fbQHQWNjb3VudIARYWxpY2VAZXhhbXBsZS5jb219fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDOK-Z2LS-6AO6-ZU5V-FEUG-QXPJ-IR4K",
              "signature":"jKAD6wzzR-7NQNim4oh3RHXuOU88empsTGg-4j
  NSAxDhKBl8_2oMmeb8IPZGdLrGf_snIpLNjOiA5B-QMuWLLuoMKfypPPQUpEy8_tk
  GeqeIVtd5HQIZHfR_lwH4BPRU8WYg6AymvRQW0VMDhXwuHgsA"}
            ]}
        ],
      "EnvelopedConnectionService":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTEyLTE5VDE5OjIxOjE5WiJ9"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tA5BdXRoZW50aWNhdGlvbnu0A1Vk
  ZoAiTURZRy1JSU9MLU5RT0ktRVdLUS1OWEJJLUlaWDUtWFRDWbQQUHVibGljUGFyY
  W1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1YmxpY4g5BbIj0x
  AkrOV8LfX-VhuVTLYhTAVpd5RNbo3DCsfPZGxyyCV2v0Foe_praoKY7_1_sBMLLuo
  SL3QAfX19fX0",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDOK-Z2LS-6AO6-ZU5V-FEUG-QXPJ-IR4K",
              "signature":"zcOvYcAJaV5V2ATqLT0xMmwGDFvgeoGwbKTF5B
  YIVyU69yrdyDdYQAcqsE5uNjJppgC-i4cU1vgAEOD_FFj42bP5CZ3tHTHdin_vC25
  _2EoqK7xloo_53CR9lClR4-65BhrtR5ZQA86R8KNdd6ZBBBkA"}
            ],
          "PayloadDigest":"QXJZ0vuLeB-4viLZNGp2Sd46z6yrWgf98wCXrD
  5sBAk1KNvTIPiGJ5tjZ5tgbyagIBKgH46ZmtwK4uZdzIs6kw"}
        ],
      "EnvelopedConnectionDevice":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMTItMTlUMTk6MjE6MTlaIn0"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0DkF1dGhlbnRpY2F0aW9ue7QDVWRm
  gCJNRFlHLUlJT0wtTlFPSS1FV0tRLU5YQkktSVpYNS1YVENZtBBQdWJsaWNQYXJhb
  WV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibGljiDkFsiPTEC
  Ss5Xwt9f5WG5VMtiFMBWl3lE1ujcMKx89kbHLIJXa_QWh7-mtqgpjv_X-wEwsu6hI
  vdAB9fX20BVJvbGVzW4AJdGhyZXNob2xkXbQJU2lnbmF0dXJle7QDVWRmgCJNQ0M3
  LVZTQTctQlVFSC1WUFZMLVdNRFItVENXRS1VNjdDtBBQdWJsaWNQYXJhbWV0ZXJze
  7QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0NDi0BlB1YmxpY4g5L7XudjZWljJ0BO
  eewm9pt3j_bat5Sh-o7sWWzL7eYilNPeTDHPTEsF6kxMr3EHEs8R_W9rlO11qAfX1
  9tApFbmNyeXB0aW9ue7QDVWRmgCJNQzJCLTIzMk4tSEg0Ny1XTTJHLUlZQjMtUTZK
  SS1HSERFtBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEW
  DQ0OLQGUHVibGljiDnWoQIpklzjDiieqdBARsqcHncMRgj_YFHDgigBO38GjFMn1k
  ONs-GbLPaKA6EjyW4oSM4biDgt24B9fX19fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDOK-Z2LS-6AO6-ZU5V-FEUG-QXPJ-IR4K",
              "signature":"OzKeoDKsA0HCNzii5OUL-pwUh6f1BmyNmmzVYg
  gUuleDLqWwrz-VxexmEfAsw6Yef6kHVnrfdnWAf6k_fUXT6Iab2rrzltAItRSToyf
  T7fD0DlASj1xmSsvvN4AIJ-T0YyQgpQtpCSGpq7du56qatDAA"}
            ],
          "PayloadDigest":"B8V0zL9d8bgVZ44FRdVHmAYmmVH9cqDhBmk25i
  j8KI_GKmRsdCxncmVOv77-i5S1Iox77eFxaz9TfZW3ShbkHQ"}
        ],
      "EnvelopedActivationDevice":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQO-QEDU-IIPO-3SBA-7CRM-YOV6-6CNO",
          "Salt":"j79NEzmcfrTnVdJ9bzfJTA",
          "recipients":[{
              "kid":"MDWX-FNKM-IYSS-ITEX-5PHS-IVK5-MWFU",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"KHyckGDX7lHTd9Zn8ARAWuyPLQLupLdfR2iaL
  qcVoEB0KRXhyoXgFWvggs_FvArE01XpRIqQlleA"}},
              "wmk":"pdLRmmWwBW5s2q8CAOCYq_WqO1TbG3W7TKJQbhvTyXQ6
  WIRorlIJfQ"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMTItMTlUMTk6MjE6MTlaIn0"},
        "PfMOaPMYoNqItfyqzVN6VWba8VXFtny6nEuYuk4h-rY0ouVTbENzgKLI
  E65RjyQZLk66r02U1P_7T02dSX25BPpk5MzFbazA4hCKcw5_8Lu3xpGAQYJbrX0S8
  D170vktBdpXls_qjSEycN8DD_DiTP_XayZnrpLQTn9mTx_vDEZ9hUqtcsI3LLvxI2
  oISkYvrZyEhDu71bhVoADgg571fY3YZ07g65KCIXJhhXwN9xGlC8MNJISgHF7nyLJ
  OOLHA",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDOK-Z2LS-6AO6-ZU5V-FEUG-QXPJ-IR4K",
              "signature":"BQ2LjSOKH-Vzlwmv066DxydmazGGDEpAwkrpkr
  F3rFUFwald9P4AWAU1t9EDZYQOEX9oKMmXm9kA1lJUAFnSFxYajG2nmML7Be08EEx
  9_Y9hyAK7mfFtmSCF5o7fDy5AvW5cv7O4ztWVsfCv9x3jISoA",
              "witness":"pxWiZpnG5St1sbBdDkTqvXGOOSQf-PQWnXyUMRDm
  T9I"}
            ],
          "PayloadDigest":"AzY55TSjJ6AvxPj2Q6SpsB0PXq0pVr0ol0l40K
  dbnYfD5_-RuJviHPCDHBN4SCm93T5LF3uxI8SsujL7S8KX4A"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQC-SDMU-CFTB-KP35-3U5Z-IG5K-WQZY",
          "Salt":"Pnz5cip3fmZ9szA_lAczhw",
          "recipients":[{
              "kid":"MC2B-232N-HH47-WM2G-IYB3-Q6JI-GHDE",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"n55D6d2tTz_yX4xfVhVMu40jptbO2HumolOOD
  3chsPUHlV25WaWOEUIlnK8RFLNDCH0CQMIppnGA"}},
              "wmk":"21aQluvcTukquYrKha9m0phHroNRLRL3T3PxEfwORrxO
  k0SlKK-W9Q"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTEyLTE5VDE5OjIxOjE5WiJ9"},
        "W4iOslisHkvkuocSOvMJ0S1IS78Hq5zfu9bGXenRq015dUpu3yW5hSQ2
  E0E1_Z9sPiQWAb1pnYfcnbuzwybY9XiSmu-ncayVpkVP3QSl1ssyJskpS4Bxsg2dl
  7NEAUo_h1kZaf1j_8BrfjHMlB6vOwVvCKJS07TflLhEPJJFNUQjShRcefSn7YD170
  jTdyqbuMsNw3zcMhZHofjx_tzUYyJTlMYKCFt3H9SKc0FQl4q6WDFvnDcNNJQWjL5
  hrO28ythq9gt96tFZ8T1flFH4ZydFe75FDvASOFuCmVwg0NXO48x_R8XFfvmRGTSW
  OKMklIxaQI2cm9_J3pGYejVtl-uxgNAlXcP5o0z00SJpGAfqhf0yNQ8gMM8ciW4a1
  PJHYSnZWUlL3YMmVE95oBbCP-k3t5wPFi1sxTPvphYxIDHQkJeINZZvtKWAcaA4R_
  bOWI-1yl4w9odmAd3T4FCAyLomL8vVZGxyTktSuZLEXNUTnCNzOCVkCn3NW7N9SZH
  FyX-IlmJBT43PtY24FBGbkExseveCiwMyS5L28xHERjt9_e-OF1VbUpxowdEHSB8b
  XpbewsRUt9F9EcRpbp-SushXnsUhyXDuTaLl3KePrqSelf4nxufkpdTQ84wT1pGAM
  OMe2YbqVsNRR7lqCsGQ0elOnBBlR6vMo9PxXMYOYvQxnCTl4xt24nKmhdR0UOZUE1
  Ie3hbyjrVPXnI1AEsF3U1eSsnvfAwM09juEVnbfLL6mziZBnWdaUVVwwf42lHoh6f
  KK_axBA66qNhrfY7R2cxyLbPPmsNirCjWG_jdo3N5Q7amdSQITsZ7OVrR73dy1JBn
  whw2wbFs8UwUuTJIfUYKOeKF9kREuUZhVc9UaBNHleOYWudDDvNeIKB8Ic6uk-DIk
  TT-Br4KcFGhEm2HDxMxn1E2fvgpZZk2YWQR5bhYTMsRH9W13EgVhbNin4kfb7CCYn
  o2YNsyYCjS-VtfOMpLZQXSHGJgBuzxPzKM80W1MoAr4oXcioijg13p0K4WMHGyHc4
  I2AcNfXQuPxIZhCe1QDPEL4G2l4cveUN1hDcCfeR24O_WYBfQlwFuh-yMIbPvss30
  kOEDshEQcPSOSL_TZ4wfwwMIY1ovDUxCdavguq3CY1KF7sSSg4zBQ2BvDjENR0nDt
  wxK15K_4bOAe2cXLNgBrWZMTJN-3WskD_8Eoehk4e4GDUYRWDwBIDRzxOcBs96FDk
  MZg-u524-8-DtpaoT8x0Eey6Dvr51R7rQVKeZkFfT5P2sdocJifXJ8Wi0y9UXFWdh
  MljLTzUVHE8WL3QjKM6fLXx2XeI41VNyrsdLBcQsWBsGvhZWdR4pYMQnJ35C0WAhm
  jErYvjkn5BKiH-5DcUJkTLMDtzlz4yUhxjaI-Z7fPaLLjnvwmR5uciaVbKhSIYFRq
  QMlQJFZ4_DqbPnvfh_IWuctb3N_wVXDWxz2IB1VLZiG7x8HPohB3-V7VY_PfuvDo-
  X3gNwELgQ6upnBKVUOcvkGAPkLMJtG_5BDveKDcdovvxzeL-6WPl24Z5RwlhFiKxc
  QPk-RkRMBe_TfQ70m4_nTOZ8PJA1itaViJIRl8es8NwbYKkpOJpCnYSsFGJUwxb4o
  LrGCvyekZ5--7VwGP9cQxGwlZ4iufgRPAiwENSnnEJWgqfb_mZVnXaU3jY5OLRMI4
  6udNRcsXwK5z06OmWjWMqTeGTonQlqO32fOGpMMvnSHM9Yzm_q1r0RKIHAVpgNm_V
  sHq3LdC5oCz-xEnlDiMJxqnFc8WGz8LW_pt4-H5J6rUYEM4NIOSMDLuoLMw853n0A
  z-7teKFQWTut9pm_f4vPVNoIrPblvMmB8OkW567sxQ_tN78ox7d_-RGoXv8-so4FC
  f5mMNcWipk2Co4SGGObdDh53lOfFVZv4FfN68RhwqVFxlO4Fmjx_u4c7UayOFDfmr
  ytxkl4292q9V6IqUjeokl-JArXqKaVfPamqL8KgKRuFhuh3FdsBGRV3FrrR0gzEoS
  iUK9b9qPKzQ2sFcyIHuiDpTXFFRSihhVPqbahHJY4Ju04Sq-nLtPQOPRm4OyW_Fc7
  pHV0CdeIzSQQpjO8ieYlCLugOiIAyvODoDlr_m9hzzbBTnc0mGfq6RHWvH_zJ7LaM
  C8O9RCSN80ocC1eS4glrK6hX30t5ZTx6gXEcmAnSo4kyuz1SF87N6hO6Pp0FlPhM3
  v_6w22jkYT4fXO83MfRF45c3-XPd6eekGRFu00HgSfvhmZFYz47wYpw3n1UA3J8Wv
  gymqSPrWSutUIp6rHGegqRSTurcYZqt-WB66EtlJrh1vQ1kJAxizoNZ8DrtecwIjg
  nmGo56owFal2UkHSsNQHsVmUOZ_9QsCjj7h9dHeQJZx3CZc3eIs-P-CrdKN2-rheQ
  8WkgN70r_jcPCMISNYZ97rePvH5knp4X1XIUoTJDC4HnC5mE7BErUedQK1TjjvoFq
  uGvTsTP6V-9cKOj58CIz6CSsKURT30hDfT_gX3Y3yOSExcqjVu0MJWNRW2Hq7WfQs
  jdmPuATzktaZjaYUs6iFG7WJV5tcEru5pNC3arv7CokeuaDvrTCDF5W4jFyi5tAa1
  zvt6b6o1Jvxq_WLWkGIyMU8HXU6H7dPSAFU3jJy2mBchq5uRfoTFbF-GBbg2cJJ2H
  w3IybirNVvg9rrmGPnZ3GOlmqUhchbhoLqQXerzULiAqav2VJGqTPH0pWy2UMi-At
  1erolBw_6ena87KO13RRoySYOdCZJG_IGyfYn6vKFZRUjMlnxtX-Bjbne6XyqSJKn
  AuD9irHyvk_X75EC529-DssqvEkMtIhU3gVPNaJ8ez0V0xw8fjTUC_IEcFmOHYane
  oh3wvCLyNtKv2576QNorCHzAlaB95DeNkHs_-H1SkMUkd2oKW6niQY-TgRIaKVsep
  cmlRJ-_CKJyHgQRiUnYyNkdk56XaXBmgEB5LFwQ4aj3tfKRB6IK_SKI6IdM1rHCsu
  N84AwzxHgUZeBIwd5EJOkxe-1hNBr09EJaFstB6c3Beei9uXLlj_kFc5wVReCtMso
  EWUmrA8QELvET8r88wgecUde1zOV9HoPEa4QBAq7EcTIpheUjKAU6khAgPealYb2m
  aNjK1xodoLPfT9n21G530wJTl4aRKVtuGOLOHazUCxz1ikTxpzf1O3jx052T_CXtM
  Zjg4vcYICDxwMiuJTYtenMDL4r4MLCE-MImeAinoZRibdTz4NwyiPWFM9kbix06Ax
  Iv53Y-vnHWMHYwllYfQarYuKD8yfxUovxhGhife3uFBiw2dN3tDLEo4-LBJr9Yl-R
  YZ3Ku8UZQ34X_Wv3NhXm6boGzknSYRvkdlRXHBrBtPLlb46ondkN0FKSHjIRpEiVN
  6AhV_tzTzASB3CqtAc-Z8RVoWTGNOTo3RuYmPg7Zyq_dWH67_pDE3nqGJNMae6jiP
  pq_2t8NqTRAxtz0eG5BAuLOh2fPsk6BlqdJVEPJe6T8KRiMJRsGXcj5EawBkXENbA
  npXoRSG3T6PhLFspGTQDeeMPzZLjQvX1cNBarsLyL6QRPrR9ezZXvey7AaMD7VI7-
  8nQKtiPO9yr8fy51eEMG_7FEF97GFlhondI_yd8UHXtc7SRAlJ1kGRI_oh-ZgRoiI
  hntSR9fakvbHRbl5VReBCyR_AzvEqZVngLx1_cGBxEymC7z83KPb-nWXt2GUQ8Bnn
  kw0zosITaB8NPH1cyHQyP1q1DzeJsctiRoB1pDlquTEgq_N-awecwMo4wJ_vsSebg
  qq--4S0WrZ1DlIRetKH3mgiqDL9PK9E9EFj5eg00hb1-Ro-TAWwDYN0m2JyANx3Mr
  HpDR4nx1FqjNykZUjuSJlq0Htg7Pgvt11komemlnPEm8WaerW10XIg7RoLiWU2s9C
  Vj2VVeheVAr5TaVqy2LZsdbq004qHC1meYVCmv7WTIFLoV1UqxCUk3CltvEL-XHL6
  O_qecEqx6OPTsFt7Zuqt0T2yuw6Od43XPNJ0exJWomzkuQxZN-nNoXQ_DkmbHP1fi
  5bnC7uMlWC9kaO6zrmMMzM20-OZLDjQ8UdfMwFFs91lchox0_85HBh8Ie_E9Vq8FN
  J3YEhFIgLM_TfT-y9Iq0Qjis-rcrEofgdoNuWrV9j3whKV4z0zwvAoc_Iq8N3Qqv1
  SEbVrS6a2AUd2B-iOBMqXNNPNqdKdypYwj7YWNOtCcFwjDiEgV6YZIEOqVqfOqKmb
  F1Cu234r-Jn1Y3B3ASkaZM1b4wgijf3wMEJ1FaEUQdUPTg8b71Q3imwCsyeDpH8qC
  oF8OYD3h1dnbTLcy72v524REhNpfbhoOlq0bZKNJmkGm7bvmdM7ZAqI53U3IcgoGH
  296kJl8PwJlCHbIqb0_8YfNj1tJF3lpBKveHVoyhJs8oNlmr9InSIaowQrkJSTrh1
  siaRMecTIOHmruWWdD78CyP1MUgx6KRPXNJr5CdvmtuZj8fZPdQH2NBFTB46fvGlw
  ABj5Pex6j-EVWY9hMlPmSJjFJFe3xibGWfOL8_iJ8WEV7UEOfj3Yesrj4r21OWJ95
  3GTGu8rvURWoUXQUSLIHwEveLW7l6a3I8folM3RcxauDtZC1LvtdndjovHy3RQs_i
  ntrClVVrpbHtHBtxT5jxghPtJPx-AXS-OuncylOp21Oo8cVxQpvrfR1C2CrD_NW7J
  TCHWBhaM-MGS8BBv49naDI_hCdsNa9tPOGL8iqcf0EduhBZOqUqRHCWFf8if6IP-E
  N43B9h1FNSOwM9YUqdTc-gqCUB894UqROTj-4wqOXVDqB1fnnV2cppOCHntFQOlEW
  lZvJX_WoP7d2trZOhXlgvwUT6HqNbOHUt8B81PCBmnWXBCAbuKfvoXx136XBU1BzP
  Y6HNgfpql2DPPkhvZauAv7ESKlRHsTFHRC1ObfA3328QRhO_bd5Xfm8s2iUOFO1vi
  8G_wJs5WKMwQ4x_daH33w3ltf0Umz2R7MvgPo944THEmVNY2rvLVA5DyiJ6vPkMgh
  OvGHZS4SeAZO96izF7L0dCyXjqOkzPLlIeBL0B9btke_JIwwwPsW0_Txm253xjIyL
  nPI6WthL1Tsm2_56feIaQQSB_49VtlvbTvu53EkGW8wsuYOFBrcZ9sKzLgxg0mTiF
  N9vOpEhEF_eJdoVfJnm8uiUFAZutMN4sVXaO85D9ASEdcnSG2qulG5Thm1UAC1otr
  N8bj53N1cVMzv4AenlsRmCCgwiEGtis0XTibt7kYzON8iBv8qZlOk18dQKlHAg3op
  67BPUAEpBBHX1QVMu_EQVu9Xgb-GDg1HsfgqHXR13pGt4VDuKt_YE1kk59i4uMRvr
  wOIjpR9tEWEJQ8kV06nf_JOYK7YR8_8Y5bJBouHUz_xYkBQ4ZOIROUdCrlYT9mAtV
  IkeW58FNniWJ65i0aWu3uSUfJsRvkh83YJm1CT8l9QK5QzJF2Wd9P9z-crvFNvS_k
  T3LkanIj0rPQ4X4DhtHHYRJIyGPLWyeCvH-TuoAbuup_tmor307MEZeAKDlq9X_2S
  RNuzFFH2Ut_AymQ3wAL-7otGBwOZPFRddBTLUBcEcpFyFYOVtWLmBTPN5gRcM21-v
  m2d_UGSDuT3dPGOp2A16-EM9GzhO5woNWztjzFibeQH4Fmt2x7-Fp9Ys2h0GM1YxR
  tfJpnqygdvNShXQpCM4xcSae1wTSYI5DQKUn0gmrDf0c98HFhm5Rm0vq3NlUMjvgS
  nDArEy0X7dmRQP0M4ehtUEdgy8de72MWaWpEmz06szYrp1UBnLyDrcrbLEXQEvdj8
  STuGvhnjtwv7lfDs4dEAGjYMa7Aqg2ukpXcGYOkzsWtMH6x5b-EvmY_B059xl09uq
  bmngKYdAC5TOM01uaa2XdL5iOGgBNCaVrWI2sPfpD9x3BU8ol88Fp-m-WcImDNcnO
  LCfiJt0UbMKEf1928kSISbZnS0ZTAYlDiXg5hJ6RebN5ZyU9wbTpe3eeWOOVeFbJN
  6N5yJZkEDP4i9IfVw_Fes810mfeMt_VgPRq3uN29l1RK9opfAbjr0lD35VBBjdxo1
  jgGRgMqlXot0tn1YDG9GdNVX1a0TgopWJSJtP5UL9E97MxqU-4C45mv9ymX1iVPKS
  4PBz0WH1RhTN-MWC0ug38BLthhPmZV0_ooFskbg8FNMOFsBmzCcTgSLPOesVm08fQ
  Eb_8_AbgW_ZFhiLWA_FTekF-FZ2fx7VzPKNX1tVt9RteotK8A2QifyvG7ZguBcY2J
  wpbNtklQ0-GiyQu45WK5wIYRCSV8iuug6ony0vcA3uE0Bm6rb5L-yLB6YPNhYSsEX
  RMOZjoay8Hy9cP6tq8Pr1hN8zNl6uOm-ikWvvmShsQKf1OIkrkm0Iu4WmD5Q3qU7R
  Zw80RRqJNYNhEKmPlGx0VnreViyi0X4naZK1QQkIlVB2yUjJTSth6ljZwcpGJMU3g
  x-rKNm3IlT5Vwm7UuHbyJF9lwIvZIKEhgxlml3PBVdH6wQKH4pnA54mZesBMH2aHA
  gtyTAE0xRI10oAGdzKBCzRDilscUpV5RhDB9EI6lpSljNHN9wNAIjfKIeXK0twk_t
  SGTLCCN0bS7BDPUm6LfXzpf8T8de44o8rgP-WSxYkwlcOgBafUbrjsALQxTS-IvCK
  ElS6kB0_hwJ177srbb6Y7HJ1VAavFykZTDs9jzf8QwifXBuT_YwLvbpVxRae5-2pT
  KjxAiCYvXltOMLG6GqxVIR16iIYVZZY2qpdVCWXfag_eMmvDk6iwmfJyC5h7D_IPb
  TsPW3Mqvx3t39EAHnv46kCVBep9mHFwN9YwGBKgfJYag_RW2cIUl69AEDRYF4EHHo
  Stfw-Z31FsaF0gb3ermHYpUBEoBa9_VSZ24qMjflumct6L-6daJegPWa4Pq-62OaP
  fkzSVBf3VRaNJWpuXHzEJTc6_AVBbehsugublBaXZ-L7EeQomKOXcjR8_CXN5AYQL
  nKb1lTmCPyg73EWlzX4F4wgOuMEl8qbCxKc94miWABLcdQowH4oTl5exd9eOUPAev
  mSw9U3BjtUQMMaIGfOge6hvvUTiZZBk5itpytE3cn7OcdIxQaPRkgkU7fSXCjACyS
  rGN7Zb0ab08isvdCuyxLJLIMhTILyNUJ2cV05FuHokLKcgwDNd8YSylk1wAwt0hjs
  MMiPMu6Hw-EVHu8MQoJKALDYXTOze3DW6W8JHAMwcT2uVio_87B9KCk2yUn8y-lkj
  tdabftEpppPDMZ71axNeG3pWOSb5oVSezXQIKtM9berpjoCGQlbIfC132OH5zJsyY
  goU9aZl0YMrUKu1LkorTnaigWXF_-jSoRd4edFUAA8m9ZHmqj62Y9RiL-ZZFXAAGv
  9QdmrduN834TKnkq_z27-RJurfi_AL5scotSnWFNaqSNpWIXmXbsBPLWtNv9jwUce
  5V0NcFvr1GwYx5T3J_Se4ascSgx5p8OQuZ-Pqn4Q52W0Cd4iwdP-A1ks6lM_XmI1T
  VqLMUyiOlxzExx-ZtL8PsaeX2xSyKR-_7E84WJvthr7r8Ui-OrZTsyQLxalGCToh3
  llMCkmXvGYaa69mscjqW42Pg9FC4_xEQsL4kfqMelcahA7eFTKeqN8qRUX_qOIHEu
  I3EFFOysLXl_8UXgE0dqtJtYYMhVlkxGZQNi2Ugqhaf_7oXr_yXP6ED4lHf8RQXx1
  xzCYdn1paVFp_Icrm2_biiOJBu3N9PoD5xjOsV1tf4XTauv7pkmitZFAAjl74nYU6
  _3SwqqKmpxgdNclF7K9nFgIiWDJE18BjKg1M3DvmFqmdMJPbDNfcPDrkuwTQYL6Lm
  6xSfmenWBxB6y5ZXuL3e57mcqWebb0y7ixtzszKOLWS-ELnWgCZcFpb8__LxuC5c1
  fU2PdMw1JZEfvmySrwlDkLih5CleQkMJsYzq2hXem7rYf_8x9gxqso-oZX-dUoUgl
  M2cLatEyphitysKuJZkBd9Perw7beoYNXHw9riFdxBpKD7O0E38bKn7Cl6_ImZIq1
  vsmgtS2Hm8IHAMtigyJBZHFV0cUt-DWpgX3rM3ERNOcwN1hMEvJHrs7rSQ_AcDIjZ
  8RJYLQcZYXuLJN3zn4UHLxCH1PMFJzhhBP_29KMErxColLlhdg-iCds8g_SaG0clG
  BoVTDGkj84uhII2bOe0YL6WFfUss0V5qRbC6e2BytIQNVLVfsqYWNxyCPlyM2LRQV
  qiWqOVaWcqklxmwLXL5-25rF1rozq6SqTu9cWi0vG0PGalV2hKWBph4e122ZkwfZ2
  XWhzGdWNC74PnUNV0pIepuBB1_vQwMZ-DmeRZujHSKBOXXVCn9df2tUKQCjadqEzj
  _VVZHcliYZhQRapQL6waF3jiSg1dKIP8LIPnEDP4P1_HTZxW8HevWFapbrwM8iGX8
  vMd7Yc3TF6aFzRlM1_7Z5htMicibVuuTq4IcFMLusYfroyeZ_-i4QTksAiHCfJcdX
  j7G-njSxg74eFaXGM62Q3jILzXzmVTLoUWUneWZwvIZnIxhMJa16A1VucazeMAxmL
  fglJW1ZQMKKO5YXJ_KnNXKhNl6xdKbh8OpdGgp4cICtut3DMGRqjJYEoVlkLMdNlR
  0oBt-h7xZXNh0vpnjsEIvRYk1tzDfr2z5EyN6sWtThMmOouM",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDOK-Z2LS-6AO6-ZU5V-FEUG-QXPJ-IR4K",
              "signature":"20RYbwgYg_szj8TEisto5TqIU43zaTIfy4zKwv
  nImz6CThz84m1c19rLdt2PjhbSCm34DPuRNnCA-peINRUJfrvaPQ0-3gHPMVaGMWV
  3LMyRqGNtw8peYek2UsuvDwRzk_LicecPhSxULSxUc-ZQrxsA",
              "witness":"Cj2Y6b5qJEL0ks09bGBd4BP1ALEDbVPkghj_fHfX
  ZP8"}
            ],
          "PayloadDigest":"yxebNjiJF98eskmniWH64kA44VerZClt0Sb3lU
  wAFdDuo3QZkoYsYXIMsAxzDmLdYkSeX_s9b74CQF_KZ-wA4Q"}
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
<rsp>   Device UDF = MBJ4-APU2-QYGV-OPLC-TDDY-5SOJ-PUYN
   Account = alice@example.com
   Account UDF = MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H
<cmd>Alice3> meshman account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MANC-ASWS-EKPK-67HT-3EES-BVSU-SETJ"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

