
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> account pin /threshold
<rsp>PIN=AC33-KDTU-XZML-MBR6-53CC-HTM2-RU
 (Expires=2021-09-19T18:46:57Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcu://alice@example.com/AC33-KDTU-XZML-MBR6-53CC-HTM2-RU
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin ^
    AC33-KDTU-XZML-MBR6-53CC-HTM2-RU
<rsp>   Device UDF = MC57-OPK7-466V-HXX6-F3L6-WQTQ-ISY5
   Witness value = 54E4-BFWD-CBDK-2JAY-TSLY-2PIU-MW6O
</div>
~~~~

The device generates a RequestConnect message as follows:


>>> RequestConnect  HERE

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
    "MessageId":"54E4-BFWD-CBDK-2JAY-TSLY-2PIU-MW6O",
    "EnvelopedRequestConnection":[{
        "EnvelopeId":"MB26-3KN5-UINW-HMZN-HOHL-6NRT-3U6G",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQVVMLUtaWTMtS1
  Y2SC1YQVZVLU5RRFItNlpOTS1NWkdEIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyMS0wOS0xOFQxODo0Njo1OFoifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJNZXNzYWdlSWQiOi
  AiTkFVTC1LWlkzLUtWNkgtWEFWVS1OUURSLTZaTk0tTVpHRCIsCiAgICAiQXV0aGV
  udGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1DNTctT1BL
  Ny00NjZWLUhYWDYtRjNMNi1XUVRRLUlTWTUiLAogICAgICAgICJkaWciOiAiUzUxM
  iIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI6ICJld29nSUNKVmJtbHhkV1ZKWk
  NJNklDSk5RelUzTFU5UVN6Y3RORFkyVmkxCiAgSVdGZzJMVVl6VERZdFYxRlVVUzF
  KVTFrMUlpd0tJQ0FpVFdWemMyRm5aVlI1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxk
  bWxqWlNJc0NpQWdJbU4wZVNJNklDSmhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV
  04wSWl3S0lDQQogIGlRM0psWVhSbFpDSTZJQ0l5TURJeExUQTVMVEU0VkRFNE9qUT
  JPalU0V2lKOSJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V
  3b2dJQ0FnSWxCeWIyWgogIHBiR1ZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNK
  VlpHWWlPaUFpVFVNMU55MVBVRXMzTFRRMk5sWXRTCiAgRmhZTmkxR00wdzJMVmRSV
  kZFdFNWTlpOU0lzQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KIC
  BnZXdvZ0lDQWdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0F
  nSUNBZ0ltTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmli
  R2xqSWpvZ0ltdHlhR3BQY1dKb2VrZDFha3BTYzJJCiAgNVNrcDNabkZpUXpkVlpYU
  npOR2xZUlhaQ2FXNXpNMVpxVTJ0b1pFNDJVVGxTZW5ZS0lDQlVNRFIzY2xodmMKIC
  BWRmpMVkpaU1VGS1VsZzRiMjl5TWtFaWZYMTlMQW9nSUNBZ0lrVnVZM0o1Y0hScGI
  yNGlPaUI3Q2lBZ0lDQQogIGdJQ0pWWkdZaU9pQWlUVUkyUmkxRFdreEhMVU5VVkZr
  dFUwdFNOaTAzTjFFMkxVdERTazR0V2xSQ05TSXNDCiAgaUFnSUNBZ0lDSlFkV0pzY
  VdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGwKIC
  BGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0F
  nSUNBZ0lDQWdJQ0pRZAogIFdKc2FXTWlPaUFpT1RoaFp6bHdha3RWTm1OMk9XNWZS
  MUJuYlVoelZrTlpUMVZtWldOcU5IQmhTWFppT1hGCiAgc1VGaGthekkwYW1wZmEzZ
  zFjUW9nSUcxUVMyb3pVME16Y0VSUE9XSkJlR0ZmU1hocVNFeHBRU0o5Zlgwc0MKIC
  BpQWdJQ0FpVTJsbmJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxRFZ
  UVXROVlZRVkMxWVJVRgogIEtMVWN5VERNdE5rWktSeTAzUWxCVUxVOUVOVmtpTEFv
  Z0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljCiAgeUk2SUhzS0lDQWdJQ0FnS
  UNBaVVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjblkKIC
  BpT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSTJhRzF
  4UjNaT1RVWmFZVnBZVAogIDB4d1JHMXNOMmhUTUZjMFJrcFNNMFJwUW13M2RHbFJl
  VE5IV0hsMU5uVmhUbnBEYzNORUNpQWdWV3R5VGpOCiAgNGFIRklTR1pITFhCdFJ6T
  kRlbTVuTmtGQkluMTlmU3dLSUNBZ0lDSkJkWFJvWlc1MGFXTmhkR2x2YmlJNkkKIC
  BIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlEwbzBMVEpYVGtFdFYwMURTUzFhTTFOTUx
  VWkJVRWN0VjFsVE55MQogIEVWMGRLSWl3S0lDQWdJQ0FnSWxCMVlteHBZMUJoY21G
  dFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZCiAgbXhwWTB0bGVVVkRSRWdpT
  2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0lsZzBORGdpTEFvZ0lDQWdJQ0EKIC
  BnSUNBZ0lsQjFZbXhwWXlJNklDSlBkV2RJT1MweGFWRm9RbHBqVTBjM2EwUk1OV1J
  RUkcxMlYwczFVVVpDVgogIEVVNWFIWllTMVZGVjBodldGcFZaVVpWYWtWRUNpQWdj
  V3hYVW5wNVdWOWpWSFpzYmtaTVprUmhZa1I1YWxWCiAgQkluMTlmWDE5IiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6IC
  JTNTEyIiwKICAgICAgICAgICAgImtpZCI6ICJNQzU3LU9QSzctNDY2Vi1IWFg2LUY
  zTDYtV1FUUS1JU1k1IiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJUZ0kwci1E
  LWtmYl94UU1nZDd5aDRmM3ZDWlJnTUtnY3VHUXp6VjZKbVgzTXROYkEyCiAgLW9rU
  Gt5VUlBdnJzamM0NXJFSjV2X1A4UEtBd3lyWDVQcHJEYmx4dGxVZ0VjcWp6YXhydW
  hGSXZJSUhhcE4KICBoQ3NhZkZ2VnpTZy0xaGFkMC1iY0FfbHpFVk1MZDVyVXp4TXN
  rOWdBQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJvMVlYOEVVUVozb1NT
  MmphdU5CM3dRU2lwbWt4RzB4RUdFeXJPeHg1aUVWbUoKICBXblBwN2xRX0k2ZlNoW
  lAxdFgtaVgtOXdHU2VHNEtEUGNIZjFrRDEtZyJ9XSwKICAgICJDbGllbnROb25jZS
  I6ICJOMXROS2wxS3dlRFVzRUc4SENmYzNBIiwKICAgICJQaW5JZCI6ICJBQkJRLTd
  SSE4tRFoySC01M0RSLTJONlEtNDRSRi1EUzRXIiwKICAgICJQaW5XaXRuZXNzIjog
  ImxQMGRUeFowRkJYYTNiV3RDS0JTeU4zVng4bFVkbS16VjVINDZERmVndVItbkFON
  gogIEktdTRuaFZVQ3hsVHFIMnF6RE9nZGZ5UGpob3BQQzRqOXh1b3JRIiwKICAgIC
  JBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"
      ],
    "ServerNonce":"dKeERzjhzwe5SOvm-zBAaA",
    "Witness":"54E4-BFWD-CBDK-2JAY-TSLY-2PIU-MW6O"}}
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
<rsp>MessageID: 54E4-BFWD-CBDK-2JAY-TSLY-2PIU-MW6O
        Connection Request::
        MessageID: 54E4-BFWD-CBDK-2JAY-TSLY-2PIU-MW6O
        To:  From: 
        Device:  MC57-OPK7-466V-HXX6-F3L6-WQTQ-ISY5
        Witness: 54E4-BFWD-CBDK-2JAY-TSLY-2PIU-MW6O
MessageID: NCJY-LYGZ-3ICM-JESL-H77G-WL4K-KY3V
        Group invitation::
        MessageID: NCJY-LYGZ-3ICM-JESL-H77G-WL4K-KY3V
        To: alice@example.com From: alice@example.com
MessageID: NC5F-OQN2-OLFI-HL4E-LRUR-QCA5-KOHC
        Confirmation Request::
        MessageID: NC5F-OQN2-OLFI-HL4E-LRUR-QCA5-KOHC
        To: alice@example.com From: console@example.com
        Text: start
MessageID: ND3S-QR42-LWJ7-ORBD-3DMN-ZBTH-RMFI
        Contact Request::
        MessageID: ND3S-QR42-LWJ7-ORBD-3DMN-ZBTH-RMFI
        To: alice@example.com From: bob@example.com
        PIN: ADUQ-WHRC-BS2A-V4XK-TEFX-52VJ-JKYQ
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


>> RespondConnection message here.

This is posted to the local spool.


### Phase 4

The device periodically polls for completion of the connection request using the
Complete transaction.

To provide a final check on the process, the command line tool presents the UDF of 
the account profile to which the device has connected if successful:


~~~~
<div="terminal">
<cmd>Alice3> device complete
<rsp>   Device UDF = MC57-OPK7-466V-HXX6-F3L6-WQTQ-ISY5
   Account = alice@example.com
   Account UDF = MBMJ-7X6T-DWE7-6EGQ-2QGZ-RSYR-553Q
<cmd>Alice3> account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MBBH-3P4B-C4K5-LVUR-D2AS-IHPO-ETVC"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

