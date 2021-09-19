
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> account pin /threshold
<rsp>PIN=AB2H-VRFJ-XANZ-JPXG-UIBC-5CGN-3Q
 (Expires=2021-09-20T17:52:42Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcu://alice@example.com/AB2H-VRFJ-XANZ-JPXG-UIBC-5CGN-3Q
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin ^
    AB2H-VRFJ-XANZ-JPXG-UIBC-5CGN-3Q
<rsp>   Device UDF = MD73-BYDQ-RHKR-XGQ6-MLM2-36E7-ZHSI
   Witness value = EFYA-IUMT-UW42-WY4C-LV5O-XY6V-HIQK
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "MessageId":"NCVA-QEX7-M34L-VZXU-4ROQ-G3LL-DZK6",
    "AuthenticatedData":[{
        "EnvelopeId":"MD73-BYDQ-RHKR-XGQ6-MLM2-36E7-ZHSI",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRDczLUJZRFEtUk
  hLUi1YR1E2LU1MTTItMzZFNy1aSFNJIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTA5LTE5VDE3OjUyOjQyWiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUQ3My1CWURRLVJIS1ItWEdRNi1NTE0yLTM2RTc
  tWkhTSSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIkRPaW1uWUZTdmJpQXl1ZHVGZHJUZlp3X1hEelVyWVZYUEZoaF
  BQcTZUX2dXNWJRaFNfODcKICBFeDRPYnVuMFBJaGNTLXBoSldJcXpRMEEifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUQyRy1URzROLTNBSUIt
  SDVCRS1MS0RVLUIzUE0tUVIzSSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiZG8tSVZzd0s4VkJ4b2NNWVJTTFdINkF
  vTHVWQmRQSVlzbzFkOTk2SnZPXzFWNnNub3lnZAogIFNSdkp6NlF3QWpNWVJ1WUdO
  cDZNYXg2QSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1BT
  FQtTU1PQy1IWlFGLU5OSU0tNUk1WS1NU1FILVNIQUMiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICI4ZjlTem44eUdl
  UGJOZHpxQnFEdkF3NjFubHE1YXdtWXlhM3pHb0ttNjlSYWVzYVpuSHB2CiAgTDF0Y
  WJQY3lEQkNOOTNsTVhjWXh2ZThBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQlJFLUw0MzYtSUZYRy02NDU0LVlON0UtVE8yWi1BRlU
  yIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJ5bFhSWGdqWEJXd0t2a29TZGNFZGVRVzl0TnoxeWdsN0FMNGU2VW80ZV
  NjdlZMaGt1N1B2CiAgT0lJVHN5VFlhTkowNU9xZkV5bzZWX1NBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MD73-BYDQ-RHKR-XGQ6-MLM2-36E7-ZHSI",
            "signature":"wEbsdR1ACiai4mIMTZYAmvoLGHNYdMfcMGime9mE
  LqxJapuvvv0lylyLkPfVXmLXG0zNbsrTUmIAFosVlucEpOmtdzvRHyT8wwNmy_zZQ
  mG5GnJo36tbqMwArZLIt-W5bbXRTqxxLs8k86BKJNDRTCgA"}
          ],
        "PayloadDigest":"M6ZLrRwTwUS-eI4EqsoMxMGHLl-etSLIIXy-ahVl
  ghI0XI6KpY9kmlgZ1pRKLW7Bc_09AttGdsM9kI_oYWkweg"}
      ],
    "ClientNonce":"8-EJPZifwKgWP99BCRupSQ",
    "PinId":"AB6H-76PI-2QPS-ER5S-HILC-JCNU-7F4H",
    "PinWitness":"L1ER2Z5ZEZp4rEQ6Cim6ObrGDh2IsooEQjDLF4AgH60dtZ6
  ChHpo42wdESFN2mWLZR5K1P0ZRkBRgNUDucDeww",
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
    "MessageId":"EFYA-IUMT-UW42-WY4C-LV5O-XY6V-HIQK",
    "EnvelopedRequestConnection":[{
        "EnvelopeId":"MAEK-HCZR-YRR4-J2BP-TDLP-4O3X-2YRN",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ1ZBLVFFWDctTT
  M0TC1WWlhVLTRST1EtRzNMTC1EWks2IiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyMS0wOS0xOVQxNzo1Mjo0MloifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJNZXNzYWdlSWQiOi
  AiTkNWQS1RRVg3LU0zNEwtVlpYVS00Uk9RLUczTEwtRFpLNiIsCiAgICAiQXV0aGV
  udGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1ENzMtQllE
  US1SSEtSLVhHUTYtTUxNMi0zNkU3LVpIU0kiLAogICAgICAgICJkaWciOiAiUzUxM
  iIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI6ICJld29nSUNKVmJtbHhkV1ZKWk
  NJNklDSk5SRGN6TFVKWlJGRXRVa2hMVWkxCiAgWVIxRTJMVTFNVFRJdE16WkZOeTF
  hU0ZOSklpd0tJQ0FpVFdWemMyRm5aVlI1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxk
  bWxqWlNJc0NpQWdJbU4wZVNJNklDSmhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV
  04wSWl3S0lDQQogIGlRM0psWVhSbFpDSTZJQ0l5TURJeExUQTVMVEU1VkRFM09qVX
  lPalF5V2lKOSJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V
  3b2dJQ0FnSWxCeWIyWgogIHBiR1ZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNK
  VlpHWWlPaUFpVFVRM015MUNXVVJSTFZKSVMxSXRXCiAgRWRSTmkxTlRFMHlMVE0yU
  lRjdFdraFRTU0lzQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KIC
  BnZXdvZ0lDQWdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0F
  nSUNBZ0ltTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmli
  R2xqSWpvZ0lrUlBhVzF1V1VaVGRtSnBRWGwxWkhWCiAgR1pISlVabHAzWDFoRWVsV
  nlXVlpZVUVab2FGQlFjVFpVWDJkWE5XSlJhRk5mT0RjS0lDQkZlRFJQWW5WdU0KIC
  BGQkphR05UTFhCb1NsZEpjWHBSTUVFaWZYMTlMQW9nSUNBZ0lrVnVZM0o1Y0hScGI
  yNGlPaUI3Q2lBZ0lDQQogIGdJQ0pWWkdZaU9pQWlUVVF5UnkxVVJ6Uk9MVE5CU1VJ
  dFNEVkNSUzFNUzBSVkxVSXpVRTB0VVZJelNTSXNDCiAgaUFnSUNBZ0lDSlFkV0pzY
  VdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGwKIC
  BGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0F
  nSUNBZ0lDQWdJQ0pRZAogIFdKc2FXTWlPaUFpWkc4dFNWWnpkMHM0VmtKNGIyTk5X
  VkpUVEZkSU5rRnZUSFZXUW1SUVNWbHpiekZrT1RrCiAgMlNuWlBYekZXTm5OdWIzb
  G5aQW9nSUZOU2RrcDZObEYzUVdwTldWSjFXVWRPY0RaTllYZzJRU0o5Zlgwc0MKIC
  BpQWdJQ0FpVTJsbmJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxQlR
  GUXRUVTFQUXkxSVdsRgogIEdMVTVPU1UwdE5VazFXUzFOVTFGSUxWTklRVU1pTEFv
  Z0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljCiAgeUk2SUhzS0lDQWdJQ0FnS
  UNBaVVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjblkKIC
  BpT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSTRaamx
  UZW00NGVVZGxVR0pPWgogIEhweFFuRkVka0YzTmpGdWJIRTFZWGR0V1hsaE0zcEhi
  MHR0TmpsU1lXVnpZVnB1U0hCMkNpQWdUREYwWVdKCiAgUVkzbEVRa05PT1ROc1RWa
  GpXWGgyWlRoQkluMTlmU3dLSUNBZ0lDSkJkWFJvWlc1MGFXTmhkR2x2YmlJNkkKIC
  BIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlFsSkZMVXcwTXpZdFNVWllSeTAyTkRVMEx
  WbE9OMFV0VkU4eVdpMQogIEJSbFV5SWl3S0lDQWdJQ0FnSWxCMVlteHBZMUJoY21G
  dFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZCiAgbXhwWTB0bGVVVkRSRWdpT
  2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0lsZzBORGdpTEFvZ0lDQWdJQ0EKIC
  BnSUNBZ0lsQjFZbXhwWXlJNklDSjViRmhTV0dkcVdFSlhkMHQyYTI5VFpHTkZaR1Z
  SVnpsMFRub3hlV2RzTgogIDBGTU5HVTJWVzgwWlZOamRsWk1hR3QxTjFCMkNpQWdU
  MGxKVkhONVZGbGhUa293TlU5eFprVjVielpXWDFOCiAgQkluMTlmWDE5IiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6IC
  JTNTEyIiwKICAgICAgICAgICAgImtpZCI6ICJNRDczLUJZRFEtUkhLUi1YR1E2LU1
  MTTItMzZFNy1aSFNJIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJ3RWJzZFIx
  QUNpYWk0bUlNVFpZQW12b0xHSE5ZZE1mY01HaW1lOW1FTHF4SmFwdXZ2CiAgdjBse
  Wx5TGtQZlZYbUxYRzB6TmJzclRVbUlBRm9zVmx1Y0VwT210ZHp2Ukh5VDh3d05teV
  96WlFtRzVHbkoKICBvMzZ0YnFNd0FyWkxJdC1XNWJiWFJUcXh4THM4azg2QktKTkR
  SVENnQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJNNlpMclJ3VHdVUy1l
  STRFcXNvTXhNR0hMbC1ldFNMSUlYeS1haFZsZ2hJMFgKICBJNktwWTlrbWxnWjFwU
  ktMVzdCY18wOUF0dEdkc005a0lfb1lXa3dlZyJ9XSwKICAgICJDbGllbnROb25jZS
  I6ICI4LUVKUFppZndLZ1dQOTlCQ1J1cFNRIiwKICAgICJQaW5JZCI6ICJBQjZILTc
  2UEktMlFQUy1FUjVTLUhJTEMtSkNOVS03RjRIIiwKICAgICJQaW5XaXRuZXNzIjog
  IkwxRVIyWjVaRVpwNHJFUTZDaW02T2JyR0RoMklzb29FUWpETEY0QWdINjBkdFo2Q
  wogIGhIcG80MndkRVNGTjJtV0xaUjVLMVAwWlJrQlJnTlVEdWNEZXd3IiwKICAgIC
  JBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"
      ],
    "ServerNonce":"RWD2eBuFhbfzrE1kSYDAKg",
    "Witness":"EFYA-IUMT-UW42-WY4C-LV5O-XY6V-HIQK"}}
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
<rsp>MessageID: EFYA-IUMT-UW42-WY4C-LV5O-XY6V-HIQK
        Connection Request::
        MessageID: EFYA-IUMT-UW42-WY4C-LV5O-XY6V-HIQK
        To:  From: 
        Device:  MD73-BYDQ-RHKR-XGQ6-MLM2-36E7-ZHSI
        Witness: EFYA-IUMT-UW42-WY4C-LV5O-XY6V-HIQK
MessageID: NA7M-DPDT-X2EB-SMF3-4GYN-W4QG-K4P4
        Group invitation::
        MessageID: NA7M-DPDT-X2EB-SMF3-4GYN-W4QG-K4P4
        To: alice@example.com From: alice@example.com
MessageID: NC5O-E23U-BF3F-VDVE-O3GU-WJB7-OWBW
        Confirmation Request::
        MessageID: NC5O-E23U-BF3F-VDVE-O3GU-WJB7-OWBW
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NC73-FK3T-VLKH-TVJG-AUNW-NIXV-5JEW
        Contact Request::
        MessageID: NC73-FK3T-VLKH-TVJG-AUNW-NIXV-5JEW
        To: alice@example.com From: bob@example.com
        PIN: ADMA-QBVV-7O32-EYN5-QMI2-H74W-3YCQ
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
combination of the public keys in the device profile and those defined by the activation:


[Updates to multiple spools here.]

>>> ActivationDevice Here

>>> CatalogedDevice Here


~~~~
{
  "RespondConnection":{
    "MessageId":"MCQ2-G76S-ZKKX-GFV6-HWHH-B5N7-H6OQ",
    "Result":"Accept",
    "CatalogedDevice":{
      "DeviceUdf":"MD73-BYDQ-RHKR-XGQ6-MLM2-36E7-ZHSI",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MA62-NMPL-3OBH-KM2M-LPOO-RUZC-HUH3",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQTYyLU5NUEwt
  M09CSC1LTTJNLUxQT08tUlVaQy1IVUgzIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyMS0wOS0xOVQxNzo1MjoyNVoifQ"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJl
  IjogewogICAgICAiVWRmIjogIk1BNjItTk1QTC0zT0JILUtNMk0tTFBPTy1SVVpDL
  UhVSDMiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibG
  ljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJQS1VjNmRBelJqanpjR2R1d2Z6Y2ZEWWZPejJVYVJudDRkT253
  b2pKeEZuUWk3WlpiQ09GCiAgM2w5aWc1MTh1amRBeE1BMFZlb3NsZ2NBIn19fSwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2
  VydmljZVVkZiI6ICJNQTdPLVpZNUgtRkw3Qi03VVVHLVFDVTYtVTZUTC1IRVdDIiw
  KICAgICJBY2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQU1ELVhI
  UDUtRkhGRy1PVVdPLTNQU1MtQ1BFTi1QRzdMIiwKICAgICAgIlB1YmxpY1BhcmFtZ
  XRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3
  J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJrNlEzUWx4dHhtOGZJRnA
  2V1FIbG9teEh3MDFCN2hvanFNYnpZaVBvV0JzbGx3NDhHSzRBCiAgVDFBQVBTemdt
  al9VSFdDaDlFdXZYLVNBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlI
  jogewogICAgICAiVWRmIjogIk1DRFUtRkZVVS1aWFdJLUtBWFQtTUpEWS1DUE9MLU
  hQMkwiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGl
  jS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAg
  IlB1YmxpYyI6ICIzb21aMm9FZGFZNW1HRC05cTg3RXBSc2lsbjd1X2YzMEJNLWNId
  VVnLTRMbVhVMjJoUVJICiAgRmJpLTVvVTVMQ25YOHZWQ0w4M1VxRVlBIn19fSwKIC
  AgICJBY2NvdW50QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTUI3Mi1
  DSFRRLTI3N1otQlgzQy1aVTdELVc3VlUtS0pUViIsCiAgICAgICJQdWJsaWNQYXJh
  bWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgI
  mNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiSDJJU0RXOFFLQkswZ2
  NUa0pQakttblN6WUJiT0NqUXZxVjdKaWYwSXFFWkswckJhd3dhYgogIGNYOElJMlB
  jUUZXNHJRbUw4bGFZRHpBQSJ9fX0sCiAgICAiQWNjb3VudFNpZ25hdHVyZSI6IHsK
  ICAgICAgIlVkZiI6ICJNQ0lJLUtRUEotV0IzSC1PWVVDLVJIRjYtNUU2Vy1PSEdVI
  iwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleU
  VDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJ
  saWMiOiAiWFpzNXM1bFladUU1MkxMczlqU205NTMwcGpFQmUzRFVFR1gydVl0cWZ6
  RnlqRnc3UUpMWAogIG51YVFmSGg0czJnZGhJTTlHd3RPaG91QSJ9fX19fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MA62-NMPL-3OBH-KM2M-LPOO-RUZC-HUH3",
              "signature":"0sW_MF0Cz-pli21rGj6UfrCtxYO8d2OZFcgZU2
  ZvH7jpz4-fEnfDmlJzc301D1EXVHNrpe5FheOA-1plzkT9WCCNXkzl25fp2DzR9-R
  BszpKbiYQT7uObPQBnm1ChVuN5IjL1LnyNLAgXe_lIPZxbCEA"}
            ],
          "PayloadDigest":"9W8_h6cvXQ_rMU_Gcg-ufh9tQGOvChwo-4iB9w
  PDNySQ4ZueR8Ax5bwtCY7uu6qYlHoOM9Bd7zqSa1WCL37luw"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MD73-BYDQ-RHKR-XGQ6-MLM2-36E7-ZHSI",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRDczLUJZRFEt
  UkhLUi1YR1E2LU1MTTItMzZFNy1aSFNJIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDIxLTA5LTE5VDE3OjUyOjQyWiJ9"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1
  cmUiOiB7CiAgICAgICJVZGYiOiAiTUQ3My1CWURRLVJIS1ItWEdRNi1NTE0yLTM2R
  TctWkhTSSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdW
  JsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICA
  gICAiUHVibGljIjogIkRPaW1uWUZTdmJpQXl1ZHVGZHJUZlp3X1hEelVyWVZYUEZo
  aFBQcTZUX2dXNWJRaFNfODcKICBFeDRPYnVuMFBJaGNTLXBoSldJcXpRMEEifX19L
  AogICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUQyRy1URzROLTNBSU
  ItSDVCRS1MS0RVLUIzUE0tUVIzSSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjo
  gewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJY
  NDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiZG8tSVZzd0s4VkJ4b2NNWVJTTFdIN
  kFvTHVWQmRQSVlzbzFkOTk2SnZPXzFWNnNub3lnZAogIFNSdkp6NlF3QWpNWVJ1WU
  dOcDZNYXg2QSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1
  BTFQtTU1PQy1IWlFGLU5OSU0tNUk1WS1NU1FILVNIQUMiLAogICAgICAiUHVibGlj
  UGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgI
  CAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICI4ZjlTem44eU
  dlUGJOZHpxQnFEdkF3NjFubHE1YXdtWXlhM3pHb0ttNjlSYWVzYVpuSHB2CiAgTDF
  0YWJQY3lEQkNOOTNsTVhjWXh2ZThBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6
  IHsKICAgICAgIlVkZiI6ICJNQlJFLUw0MzYtSUZYRy02NDU0LVlON0UtVE8yWi1BR
  lUyIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0
  tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB
  1YmxpYyI6ICJ5bFhSWGdqWEJXd0t2a29TZGNFZGVRVzl0TnoxeWdsN0FMNGU2VW80
  ZVNjdlZMaGt1N1B2CiAgT0lJVHN5VFlhTkowNU9xZkV5bzZWX1NBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MD73-BYDQ-RHKR-XGQ6-MLM2-36E7-ZHSI",
              "signature":"wEbsdR1ACiai4mIMTZYAmvoLGHNYdMfcMGime9
  mELqxJapuvvv0lylyLkPfVXmLXG0zNbsrTUmIAFosVlucEpOmtdzvRHyT8wwNmy_z
  ZQmG5GnJo36tbqMwArZLIt-W5bbXRTqxxLs8k86BKJNDRTCgA"}
            ],
          "PayloadDigest":"M6ZLrRwTwUS-eI4EqsoMxMGHLl-etSLIIXy-ah
  VlghI0XI6KpY9kmlgZ1pRKLW7Bc_09AttGdsM9kI_oYWkweg"}
        ],
      "EnvelopedConnectionAddress":[{
          "dig":"S512"},
        "e7QRQ29ubmVjdGlvbkFkZHJlc3N7tA5BdXRoZW50aWNhdGlvbnu0EFB1
  YmxpY1BhcmFtZXRlcnN7tA1QdWJsaWNLZXlFQ0RIe7QDY3J2gARYNDQ4tAZQdWJsa
  WOIOcKT5UA9wOrTnmnEAdLCIHE_zfTMhM-2VFaniYZP9nYEmexlwkGUOFNDzI_8H9
  oZDpiOlB-DCc4KgH19fbQHQWNjb3VudIARYWxpY2VAZXhhbXBsZS5jb219fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCDU-FFUU-ZXWI-KAXT-MJDY-CPOL-HP2L",
              "signature":"yZN0U05jiaFKZBQ4qxwU1B3b5FKMoyhz0eKP7Q
  q3IWDrdgku0Y14NCzWyPQStPyBPeeyN_EEBaaA77GjaV8kEC1JhOB8h7PwdFfwuei
  4DcahQrXEof9_uvJEanZ3GNDABpo3xLPWYApc8jY91IqLcgsA"}
            ]}
        ],
      "EnvelopedConnectionService":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTA5LTE5VDE3OjUyOjQzWiJ9"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tAZBY3RpdmWxtA5BdXRoZW50aWNh
  dGlvbnu0A1VkZoAiTURLRi1VMjRSLTc2REMtVEJPTC02TVpOLU02V0gtT1pMTbQQU
  HVibGljUGFyYW1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1Ym
  xpY4g5wpPlQD3A6tOeacQB0sIgcT_N9MyEz7ZUVqeJhk_2dgSZ7GXCQZQ4U0PMj_w
  f2hkOmI6UH4MJzgqAfX19fX0",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCDU-FFUU-ZXWI-KAXT-MJDY-CPOL-HP2L",
              "signature":"k28MzBOPwBMJhh8m6kPg3RgHCikKKCSPC82i5Y
  iT15KpBeDqq5tk0wQ6uo0diE7eOKzkQ_PPeF6AR5wwhzfqvQHvhVOWR5LvsJqpgiT
  0foVtRRdZ5He4JUpmIpTqrWp7GtTNKHa-APsJTSgy13i_pRUA"}
            ],
          "PayloadDigest":"PS4AKzltheXEHks7m8_8rDu7_0XyWnfrSprs4p
  R1X2qIgmaHj8S0WYgEUQtTgj1aTxq6XVZqaKJsccPb6Glb6A"}
        ],
      "EnvelopedConnectionDevice":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMDktMTlUMTc6NTI6NDNaIn0"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0BkFjdGl2ZbG0DkF1dGhlbnRpY2F0
  aW9ue7QDVWRmgCJNREtGLVUyNFItNzZEQy1UQk9MLTZNWk4tTTZXSC1PWkxNtBBQd
  WJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibG
  ljiDnCk-VAPcDq055pxAHSwiBxP830zITPtlRWp4mGT_Z2BJnsZcJBlDhTQ8yP_B_
  aGQ6YjpQfgwnOCoB9fX20BVJvbGVzW4AJdGhyZXNob2xkXbQJU2lnbmF0dXJle7QD
  VWRmgCJNQ1JMLUhWTVQtNkg0Qi0ySURTLVg2UjYtVkJZQy1ZTUVEtBBQdWJsaWNQY
  XJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0NDi0BlB1YmxpY4g55e
  warri_z0Yb9v1AkWjX6YrK7jEjeN6xPIzNa7hW1cU51p5Q4tMGKD7KN9P9bxlUtE_
  rahSAbZaAfX19tApFbmNyeXB0aW9ue7QDVWRmgCJNRE1ZLUw1NEgtQ0xDQi1ZTkJX
  LUJRS08tNUk0My01RFY2tBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNES
  Hu0A2NydoAEWDQ0OLQGUHVibGljiDnlyBZsYDzWABLZcKRwR84rrfWFb4UVUvhway
  8ARnqFMopuxZ4evVq9CfF8FhNu4KkaKfQZk87qAAB9fX19fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCDU-FFUU-ZXWI-KAXT-MJDY-CPOL-HP2L",
              "signature":"NHyVJX2mPSDpzdpzL5ShPp-BUCGcAwewIw39HW
  P2Prhgs4b6G7VEBiRrvB-hURuCbKVQFWx2wQEAW8EWL_X6uBJkny2vjQruPLfO6Bm
  m-4JCTMdF2mrxAfDKC1Nbjj0SeRqLMOZ5N0nh_13XUThe_hcA"}
            ],
          "PayloadDigest":"9rySTYq18vhTCgBFeUXw0QFbEXtpPmXroSudJb
  yXq68WK1iN2AqCkkbO2Roa8Ga-LB3O6iHdqLwvlq8TJALu6A"}
        ],
      "EnvelopedActivationDevice":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQD-PIYD-WZ6J-RVMJ-XWTK-BTUJ-OTWE",
          "Salt":"0utv7qXhWs6-KdoH8FqIow",
          "recipients":[{
              "kid":"MD2G-TG4N-3AIB-H5BE-LKDU-B3PM-QR3I",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"7kN7DGuHYeDsRsv3nQatzpAdDmsJLTJz3svFJ
  lgHSyvznLwGvOhCs24ucsZukZN7etWWCFqVDDEA"}},
              "wmk":"Se_qJVbSYrlGYq8A7vA8XWzDchX2TPTWOExs8qi4FmCh
  9QNQ5hqvfg"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMDktMTlUMTc6NTI6NDNaIn0"},
        "p2auZ4T_exMwNbFra00WdT296a9yGwDluUD-i8-BySe5UKD0hCOXVNBf
  rUvyP2KDnhXRExYtLjM7bUSrSNs5zQd4WPhKZKcuWFJprt162zzBj4NcfqPmNRgc9
  NDG-3rPn8jIjIvA_ym59IP4FepDHgJxpcSGjIExGlCXaSzHKrscCggaWziIAtJ9OQ
  HmZGRxII5fc0Z94FOCoukesUKptFmlCIIT8i5qrOFfwoLfWcYF5UH4HRLrXLk3CUp
  LEOYx",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCDU-FFUU-ZXWI-KAXT-MJDY-CPOL-HP2L",
              "signature":"hBsCh75qUYLJ6b3mtxRvQaDk58P8Y_4W54uD69
  9IZTJvW_hV7qEUkgmVEzEhnlx3hubJNy3HA1YAQvSup6MGhyKvK5saF24NL4BKy5x
  OdxwApt3rP_NL3SEHKNu1OunOc_Lm90ZbZnuHhdi7bf3hfAEA",
              "witness":"39t1XEZog25uBIxPILToJGr6Xh7z2trfYI0mIawW
  3Kw"}
            ],
          "PayloadDigest":"G3QsdGYpK4OgGdLvplGOIh2cdI3UPXKJYsEsCW
  n2d_ojnXaV6NzcL6bNV8vRAKcQPXgaNKyUL1QVFfvMkntY6Q"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQD-RT2Y-RSF6-G4CA-AGCS-D665-QUHC",
          "Salt":"r9NXJHNLDadzlHWl7XRPRw",
          "recipients":[{
              "kid":"MDMY-L54H-CLCB-YNBW-BQKO-5I43-5DV6",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"joF7CdBYu6foC2j6Mbuqc5KEt2DT7yrmIh9Q8
  VwohjaAHfGHT1WOUt0_Es7aVvmTC7CKyI1vbpuA"}},
              "wmk":"M5j1zqy8NPvXO-bc3HNi0GOcJQ-O95svUwzfBnTJHipP
  UDUv3ER5IQ"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTA5LTE5VDE3OjUyOjQzWiJ9"},
        "GHVArsQ2IoKfwwcMg0QrpT-Wa-JGdEjNI0F1GnQtjkHAzvPZUQOzDUj5
  JyuaY9d8Kpkof8o35S_IzWNmoDwxhKDgp5Ff77eiYX3vMZdF8GHrGVd3obFxjFJZt
  d9wIYVIcLmKf_F7KzTwXH7e3Bd3aqj3Ot5YQFZAtRu98pSLoYP-2SanV123HhPVh1
  lOQIjdGHjqJRkwfw7Q870ycpDWeGOd7VxsPS83lCUt624Mddq1PBtpepaF5-hx_XH
  P4RLgZXdfTJZIdmUhY9vFB8DWZLLNON3GGYOb5oeAofFuHCMf5iZ7AwiUrbYzY3Zp
  c7xU8Dz78xqVJ7KwNVFcMl77SE27n45sAsoW1lO42ww7LkCv0zzjC8ChEGDGlt_DJ
  vAmfH4x-kmVKbUQQaFON632lzwtAFho3jdz7Dv2LP9yN4qOb3XOXKeEimMxSXjRUM
  PNPTzjOGj02V9Hm5dzYO1qZUyoFyHyKQS7yWMQlMxLRkT0H5eGg1FYu_wykaE3xia
  bsHQ3LJQs0M5RhNMgEsArd_9hL9D1EpioqUBvPhJk2Sk9n2ed5fudIiIw2OELC3eg
  p8sX1nR14J6RWO6675cIUHV2t0F_6KRjNHS9j29_Bo6jhVTUFr7Rl5xH5vDxF89kJ
  Cacxy_KM_EN-fMq92z3_EoZKQPiH1EZg9Pbb1gi9qpEI-Ez78mr2wCMAT7MBAdaL5
  6iOtXjFFltts2jZ3nplSUHIxBCko9jx3lgnsiHtOuaK6u0t-c4i8hbaqyAMfLWfK8
  i4RKPxh-sgD_7uR-LVVYzKte_mmDekacQZ7BAxyWeM_RZrKoIikM9BlQezCCoKQX-
  M1-T-zDn4PFIl3jcyrwaoSm2tqcRCcXJ86jv5BkPMaF-FttsFtmicJl_9yxiGt5Vu
  N8Mmye52ELoeNx3q7GfHYx06Y5w9K2KPxXQ9xi_O0XyBcdVGg5pNhUJlhbMf1y0RZ
  6ZjKF5mQlABeCCtCs0-YgsufGq-wRyh0KDCG_HdcB-As-XE4_ScrDKd-4cu_EuxLy
  nttsVUy94sqyZJQmPhYSpmdjJib_qRB3kFXV7L6rIp9KQhYuMJCdAPPc9y8pIA4f4
  rQWPhMsAlMCzCA4FKn1eNsXqlET64HIxzQhVSyPSkruZOM8L8ew63bpDmlA5n5pOs
  tb7dypdZOOhYVFQFyFvq3OtnvNJI7-mo9fodincLqFgx-9IDFzgwlC8GFiEV3oudA
  o9mVTOfZ8rKfJ3x7pE7nb1GcAf_KTe0BzgmznjAjn7Y3rOvIlhOrhBAC1xUS3Cad3
  SG8utimWojpZyWNNVXBHXX4bQFpGqkttTF5O7GkiCtmC8fAdeuwlpST8WzXG1ZtFB
  fCqdyZUPbLkesOFTILbi80wb3KdIzJxlO-v0Z9psgT21OKnqX0bx0wSljDzezFHtd
  Rk0D_vGpTPIRWDtPz0PX0OJo6wUW6k6dmIWtQ7svUK9LgjiVX95tekCb4DLd1eJFu
  7DMrtlWxyyqwLauW6KzYVacazXjxnhps09LOMOyv-dPGjr4xd6J0ctv7fqLwCFHPG
  EGOwLX5d2BvhZ40EeVbcg3LCneCK0exunDd4e4FUkJcOrLn_oymH6ro5xZ7I141JS
  4jC_-xkrLnsAJzdFtEt53Zgf2r0pTWb5HYNSlNVyYpOmsq5YRcLAnTkVe7O9b4_28
  wp_3gKAHp8slSaTCt1bxCQ17GeiPCx9gWg1WPxyN0nLBKiP2cJFm35oaVPPJyIRtS
  RgSkI3IF5U5mjZZ7pDRbBScemoAXLtzy3draRXhv9FFAy4hC5SynW54O6rzPkwMYy
  39e4eDAechTN2B7ZZybiuHyovYvWydINjwtJDT3q8thiLN2uG41ugzEcVjUVfusMG
  U8sneTaiaDsxuQR2nepwO1Mzg0va0Nn41TXD9rd8rHBrsprw_d5Ig7iRKwMIxUR5o
  bG4GPJ1ig_SbW_3VdJjdLubYMMjGL1K3nMI2qMym55tIhoo061Lgh6kD3i91YRSE0
  Dccr2YWZt_4Jr0lOB57P_pdp6FluN72kow2XHCkv2fxJ9hmeVommE8IMDErjiEqGr
  x0uKVjDuGsPqtANE_nXNtmsSGwb7wzTtJZ0q4EEpRcsWyHJmpTYEHQthUsdztpX8b
  ozZgq7RSSjlir9YPhne_yNfyxgi-UBi-WHpAx-vI8qrUCR0EQj84kPQLG1kgbcbMl
  WIR2ckA7Tt3kS8vmQ5zAaA27eLQVDgENScVPUJQcrmq2y22c-qYiy-qVDzl3kmfUR
  4svVrXUD52NQ240arXCC1bEhL2O07XYrWoy7ZqPJDI8J0szX4xtld9E9lArYuIeYg
  IQ7pt99tFuYkKom1Kqn8l2aES2EeVrzVVfytG9xsDl2etVDIT9qhXho9uEcz0prgt
  V9rM0ZV_MyHitW84q1kSAlxCioQu4XY4BW6DoCiYVGSkZiTDqq4NZCmSDHWX4DHih
  xOwyn5BrJLD1VAeuRKTKapSGtmeaWqRJGHh9gnnpLLNBjeMoWNcltY80XTkLFDLue
  zgGLE5ZS-tHVKWQJ0IQ98t8nmJiXSUyh37TiGi6vimGhYIZgJz-uP7zdQ23hvrCq1
  yhVSSLp1_WAP9LLx0oqAjMUuN9XQL-xWmoO-T6xMgKsnO8q5HPjekmlEkZvd5rgUH
  7OMheyhzf6EJleYpAQLq_HO63jnoCZBVEpFGOaJ5HuKFqmdD_VF-pbmL7B-aqZLXd
  dmSQNYoaH8KcksOP9EKsv7oPUjyMX7VNeSjWwlbAlLYF6Plvks_VjOPFKg_K00Rgx
  MHm7EIEGPyLkT1a0dVaX57b1BusrI9A5_moix4gH14U8jdCmDUv7Pf7Q3r3LtEYFI
  r6QcnGNMzSbj7eS7Va_ulhRrS-qXTIBq4dNstYOBF42HgmTHV-L6zOhpV_xVZl1ie
  V98f2njb_5prbUD3iBahMEBSp9FI3_gp-on6uqQm0Hne9XNmIeb7jRBts6Vz9z9CQ
  WJmB5iUs0LVhkg_7tDPm4TQw5yrW3NSL-7GW5q9e0saHescZtAoz4ruwD24oeehfu
  xysYM5FofVoS5xDLz9hzQJnQ73NRCyvwNjSb6RM4uHGvAbxvFvDFKfLdp7ZwzwwnO
  LHFVTuYDvp4nRkVW7Z4ZDuxCSbXhlmsFrthXq1MORt7hcS_jIEyMJnWDObXd_F3Pq
  BjMRf-60aix6SUvis0Nksm1bafTX6Mjz2lfV5XiqhiQClJ9oowBUqGhB7jMAEY7Ub
  LFw_0uQYU3z8WaTG0rDUlf1c1xb4RZkQV9JQbyENEB927IxBo-xabd8Fae_i9YzZI
  1IOf1R8yM5xuzW8ihbeAe8LXkuhpg3yDA92rBF5t79M00bKlt2JMhsyHKVq67rJjd
  7WiT3Tuy5Jqj0CpC6hHv2IEGUZ6ZwbldjRQzPHzCDGpeKfD8_wDWVlIPoISXhKoie
  GMrgOWN1MT6B8jyW1aQzZkMqEoXlmxNvFXMHXT20dakPeBeVMRKzADFrRQTXwtq6N
  A5VZKDcvphp1KrflIk5qFKDqM1VVdFbsOFEOwzSjx8Wzi8J1DmW6Jnvd6Dq7d8jBL
  t4nVDSdEcM89_JfOAj7z9EcFLyaMnU7fEvT4ppVWPpJ62jLx88Te9kqZ39jrvMqIN
  GHoZu__gwy66UoE5GxaMHvTh55rGB77F_WZN5hUVs8CopWY4QIdQp2zeUAjrLDpdN
  1bNmXLEAy9HGZMfSYuTDKZdVEY4kC4hoZVGEwIeQhboB4mecS5YlQWtt9OG7pyCa5
  KpYWJCHQKxWeoxPYCXt7H6tu2Ot0_24PNFeK_6HQe_s8K0rewKb3sK7ir2oW5HoPr
  6mqIQZW61ITkvLn-E5UzTd3FliSnc6MVBM01NzXj6-GuwcgO7AkspeAk-R42BBcsi
  cejFZfr93G5vTksi5VXE108NQPVvPjfMmh7OBZyHve69zT2QWrIDR31of8zPRuRYL
  rNMijNvU26S645nwz9zRCB6q1OPXWzrfjLKPlTiSALULpcuyVRS3LjwNhiI2-_g99
  Se0WAKpu-quqB8ApUunsdfNuv3CKWwGWBkILXjz4xoKRiNpMAWwHiG4WBEixOXWN8
  2BP28Paoki8wWCi1WQTVJiyZ2HZIQuOnmRoARNz0JjEnsfTyckxRFljyrdV1X5qlb
  9uAqwEDh6tXTVylsFbaPhGl6JNxAd5p7zhRjLtmYh4OL-MvHeRBscaeY1Qpf9-cfK
  MCotdKqeYR_jXk8qSNUIEfBaZ9xMsZCt6xlMz6Z0RMb5S26JmRM6EZbK90eBTy8hA
  0U35OfETWIxn5HeNXoKM7EoH_wFO9Jf40Psuuz59oOz2yleXg9CktFcLhTnC6FFVQ
  IoJIOVSSn7EZFHTB0pBPzn4c9hGz_DvGfqpTX46qzQe70IUwEYH_UWx6ZjrNRX8pb
  2O4si8QG7w0iNNc_0CcSw2rSw12gLRasj7ssvftfrZl_S2baHvo0NDqmB0U6V835x
  _47ih_vjj9za5B_hOEEuL6OOQ5dsIOzZSr5hY1Aqa_bzQ7uaN3GciHxYKHOjEYGJn
  r3x1IMx_mwqIuV2Suku9O7s-nkcw-FVAq4G2bMFr2W-xVuZaHDYPigLapGd8XQa9b
  PhvaUcR83YoinzXSBzs22Hg3Fk5c_L6ncEGsUHZFdGzlqjwPczQqV7CBTlYKC8RKc
  mSXOpv5FRus_9zyd7tZR2Rtz-oWoegauKkUmnHrAyBK4IeDE-GnUkU3ve68dBOIrO
  RD2hfSyx8z2Fu555YJ4WGlOWl-SQyOKTd_6wtlpq4K8IUxvSdtosfyyoReh0-MncC
  yJDyGzeglv_M0AotymdMqPguctd1D7NFtrAThdOb-_-JcVp9uy23FhAUQTSetqmZ1
  QOtNxH2ZlxhDCMoh8EciaR0U1JzjdlGqedeMJ4SlAD0p9pcOK_eUhut7UgcM_NY0c
  JsWk32jFBcx8iQzAbL-xvk642MFOkTjHtxdelflp7v5APHPNhpal3Aeyfh3Yi8_Re
  0BKyC0hisDomVdJSVqGO3rDH7j853f1h_ZMMK_2XFNvJ7elw_DtYjxNrzJF6B5QIx
  Yz8lSZODI3IByHvMGBnQ2wIeThZcCDONDXiPmKYmSG6M0NnhbEKSyyP_iuBOIdhxP
  ZAlAyGrpQXa4oU8yffLPfanOgEDek_uEk1hQJZ4IJnan1q5RX78uCuBAYmoKdRMhM
  3LP7Vt8B13UcREEPvxf0vWksIFdXL0maKvLHsGB43den9HvJOuCpQ2iPjT2yAg2aO
  QhbOF05S98grzHfGix4G5qHgvwCCtigFN4WdawS6uREF9HDGZASaM5WL0GdbNBVdZ
  FrvJ-6xZAw5e9mCgR3Kti7fQ8_U4ONhgIWpsmPRnrCavgWwC8niw3DGTm8aeeOMAO
  E4iaHB9T6u5HGMqXXEz7ScHLJODQFzBYyDEHTmr9S02bPdhoRFzq9rP5mte_BUH3S
  uSJWOnCeXC8jOgf_9u4eESz-7hwUavtM-FR1oZ_OMHIsJUIZ1NZC3N-rDOC6ykr0F
  PZpUQR0uhUDg57yK2RsDF7kRwTYqiXPmAE2lqHsXBIB5Mrw6Q-AD7Rr7BqZs2QOjW
  lid0y-DmswTgqmVVkLNN9C-hrrh_Bi1-WFJuAnDb2nneO92d7SGpda-nslw3FEQic
  dj2_mBzsslFePlId4VuuB5hCkETTWRjV1n9sHlREAi4vuU6YHR9fib8P28sAxBWia
  xQTeU-tDHro7IhWzPskthcAuadjphpIP3a2CdGlIlLNe3k8eBL-udD4wb8p7mW6FU
  6Es3WgGVe-MMneoUaU2Z5oOBwAw-Gh786EnzWcXU-obO4XU6fxAZ87zC9QX-ueMjq
  osrZ1CQCPh_q6natQ_QyH2v49XsbqU1eE86_tW0IJomFjxyTw9vmNlAHYynCKYQvg
  uAg_6YLsRtbby42qu-YPfOGiH6cJlWD04rZscdNU3J_bXb6GDbEsPGVelpgW6mmND
  OI0eQGnWRAU0yJCUIQwn7zwPqvLG86M81Hhyjzxrm0lIeIxrx2_RZUt_wy4kP8rTH
  Sgg-AB7ht8Q4s5Cklx48Sjp5JyEXMOrrZ825QUq_ntS38NQBpojigkegbS6_yiCdt
  nCNPMNtljlIIi2P0sPKry1niMp3rgEU5-HMuaFi77Vcp4YO4h92GcirplW3NY6Dlh
  QvqTmbZJxYB8MSH1zsYHExT3vywWjYXy1z5T-ug2xPEzImoabrewIFzxn1EDJ8gu9
  XzoEwBHI1NLtCA0Fu2X7q9cz9lq8xyBPzqeZ93Ej6uiH3-L2zHqmolvbiZ-kPYN9_
  -j0xLbKhMixwZH40s8Z2MBWgD9gQRRV9qtVss-CsP73Z_blfLrg9YMDZQ5es3i3w2
  Zk7LtGLyRiR_WQ8m0PGrJpqxr0awFRNP0ceoPmWKjstOuCLBxNGBXoInCpDTompmo
  xTNYpWPUCsZ-I3Mbaq7OLUzAiIYanldNZVb2tZ7O_HKn87wAuYKAVqGNE8yIVZzy0
  m-rdsDnOQNJQS7-C67yV2pksxO8Mxfr3rNrhpjUJIa5rtXwLzkcpzkJwHClm3km_G
  LQa_IIAeVSkeHK-r5f20gXygi4k1oh3vxQOygwoZsBGnwIpfpxJMI3doev_r1t2vp
  Fp5VFpbKAtpLC_uCR7tYnjO9ZLx4lPJLFfLhcDFe_sf4OeCWBF0JQmMWJ1q5zhqxS
  HEkGLHLfbELU0ZigIfjexwFa085bMiXHdUzT2h3vfj5ebSu2rgYwBeq2XrJROQhw2
  UEhoA7AYBa8e-kWk44iuVoPk4bdVC_Knzghwo4P_lV4ApYiNLyCBK0d7jab6rWEKN
  1iyeK17YnYlG9lBU4uB_QxRII2m31ZdjwzxrP1dLsp2S0VtBzjmhie9KIAOK0oZss
  6txkbO-Pid7iXeeVulU-uHNV4f6EouYzHEHjkHcPiUNpSmkIPv4stjz4EFgTBPm8E
  fADSksJKN46j5dIylV2TbK_oh1t58RIIFTbOBbg0S7XzqU9YdRR8lRM3EK8uL7GfC
  7G_d_HE3Fx1FcRWCv0pT8rSeTry4WX3VKCwKtoGL29TZjA_Ou-zqODCN60L5mmeX4
  cpmg_xfeflEm8f1MxU1XwXd1YJZbeHa5N4RKLFXRG8aftde07-3qYxiQbFIO_roCc
  oxp0Mbtj9yZ8ioteMsVRKYsmpFXPFtSu8H7eo0YKAjvo_9YbWjivfdVnBJAnQgAYI
  Wqhf2mwkQziO7Symu3k8pDItH81tViu7S1x_7e8tVGx2l4SVQclMRHJhichbf0WF3
  T-62QockBAz_iHR8P86ggVEyVI_svg3HWH7mNC9nbh0fb6-SllDmbIcFvbSg5yl5r
  JR9rqh2TFHdKGegjndtEKObID0ezj_l_YBSTh5GW7mkGT-zOnDZ_Alnh0lIloAn9g
  P_H-iPmmnakIKHD4tvcOTyTUNzL29AOSUeIQvSF7KuMihSUg5XQvU8VtrTFrcz4T3
  -KLS2GqV8FAuW8dOcrmYqz1Os8DNJraTF4r9WS48QU2gAuxULTFbyWGma38QyKWNy
  3X6A8hU8sYea-Fmav_D6RYNQP6GyruWMrIVnasdJJVv_9_ZbZLDTmVxPa9Cs6izQC
  RJraAn6GmQokW8F4Hrs_SEfufoYYp7EcbmRTxfDpUYPEhcanZl7jevVQvKm0_8jke
  FZQv_SPRQCBbYBr-z9dInKfVbU3QPWDdNihnzNqYDVcXP0xVKOdsfSmT4TQKOycgo
  FNE51tRl0QwDdUFhwKKA-hBFSs4lK-ywFgJ5aN9fE5NPVoyLqNLHBFeYj7d-WxRw4
  QeowmRlwxS-UHbdvCVJYwcyyO-g5UuhL6MADFv3vTsjpJPgyH_bIkXVYo9o7wJ89e
  uptS3xDBLit3Soz2kIvu8i9Bz9w-B6SRSII0iyogIjpYOFvJ1JNAyShObLebOI3p0
  S7yEnnfTAwCgBTNtAJ4nq1eUVNlnUz-P8dmjv8NwqCKkw1RVOwAdzZkGrGDWCUKtQ
  B3WQnnx9Edmr5ZPLv1xNMpOYG5NrA_t_RtU-HBB1okcdl0Jhgrj3SKnL0XPyYeZQi
  jTG4TJ5jaXLzHWaBImUK0kyAfb0fnKkBH3rK8lIdjqAcJABBLHJ4FRy15yfYY9c-w
  hHX21piD4KzISM1IueD-2LdYOYA37gmFE6B2odQSb5n8cQ580tUqw2v904arsS0h3
  pv-RJ6fEo0GgyVhyjR0ZParKKBk0jjrzsrRBkS1chBEVM9zHF9IL8Xj-psqcTjTtm
  f14Sl8VFn8zKENhJq_K-RYjV8Ux3U8SWb7EWPRMDd5SNc6j2SFYjYyBTZbXRybHuh
  4XZDOTCmmX8BAo12nR0wLd3RonMi1llPwnDMwDlp3hbZe-BfzmYUNXmuO7ZuGxf5M
  SrmmvbL0tSnoFK0IuuZGL7zZ3Me0rppALMsuesEWDcYcVSM0DCQi1lxR6M8Xa2hCf
  5ZEidDzENuq3SoMbIld_nM1gl4dQzAcBWQHmi312KCQzIKbrgiX6W50RF5xhxHvji
  -fmQ-vT69ssMkoIqYY1yplGpylrkPaO2o7t_Q1UZxuq0bVHY-FJ68mrLqKssIxTuK
  WXrAnTQ_DcK5QULBz19rRjezGOA9w_HzjRKlw3G6yw2XC8n4",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MCDU-FFUU-ZXWI-KAXT-MJDY-CPOL-HP2L",
              "signature":"NxxKdSWF96iIDrgQea54Ne9lRHGxfse0yZ09j8
  m7ONjOB-58ece4WnfBJQXHcgNFu-3hHa3GCuiAzlc125AUgUYEDCww7Euu-DGSwuH
  WyCAI5sohGAAYHYc6-024JmXSS7cBbZ9JeBvjcIADNvbuST0A",
              "witness":"BBawicE92i8iE42pBaphrY1x53k_TmT5dXaotNmE
  UpY"}
            ],
          "PayloadDigest":"6w9FMtG8-0rN8_Lb9bE_ozE66brOxz1KqguU7U
  CTQv2iCQ1pP18oTCbf5q0wJmT9GzUALSl2L9t6gPxGPwP4Ug"}
        ]}}}
~~~~

This is posted to the local spool.


### Phase 4

The device periodically polls for completion of the connection request using the
Complete transaction.

To provide a final check on the process, the command line tool presents the UDF of 
the account profile to which the device has connected if successful:


~~~~
<div="terminal">
<cmd>Alice3> device complete
<rsp>   Device UDF = MD73-BYDQ-RHKR-XGQ6-MLM2-36E7-ZHSI
   Account = alice@example.com
   Account UDF = MA62-NMPL-3OBH-KM2M-LPOO-RUZC-HUH3
<cmd>Alice3> account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MCQ2-G76S-ZKKX-GFV6-HWHH-B5N7-H6OQ"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

