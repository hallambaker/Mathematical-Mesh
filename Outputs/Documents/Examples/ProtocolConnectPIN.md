
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> account pin /threshold
<rsp>PIN=ABYY-TYLH-XENK-57RH-6PMF-MAE2-JU
 (Expires=2021-09-21T18:16:18Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcu://alice@example.com/ABYY-TYLH-XENK-57RH-6PMF-MAE2-JU
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> device request alice@example.com /pin ^
    ABYY-TYLH-XENK-57RH-6PMF-MAE2-JU
<rsp>   Device UDF = MBJ4-CDEK-6JA2-WGKY-4C2Z-VSYP-KOFM
   Witness value = CC5N-J27O-DR3W-WTQI-R3JB-NJZP-745V
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "MessageId":"NDYR-FST2-D4V7-7C3Q-QF5R-74TX-NNPC",
    "AuthenticatedData":[{
        "EnvelopeId":"MBJ4-CDEK-6JA2-WGKY-4C2Z-VSYP-KOFM",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQko0LUNERUstNk
  pBMi1XR0tZLTRDMlotVlNZUC1LT0ZNIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTA5LTIwVDE4OjE2OjE4WiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUJKNC1DREVLLTZKQTItV0dLWS00QzJaLVZTWVA
  tS09GTSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogImdLTzlPWUVSSFJYYWxqM0JBWUpWTUd0aVhTVkt2Qy14ZEgxTj
  B4NGhjWWVjZ3ZGeFdEaG8KICBJdVFzUkRtNC1RMGtKV1FGbGFVZXp6RUEifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTURaVS1MVkVRLUZXVkMt
  WlRaUS01WlZNLUhERlctQ01DUiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAieUZIaXpKTlplZ2M1d2JUeUlOeXd0LTV
  MQWd5WTZFRkVWLTRSaG9FMVU0ZXRpYUZ1eTFYaAogIDFNZ2l6a080b1h0NmVMVFpk
  Rjdqa2NtQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CU
  jMtQ1dRVy1ZWTdTLTQzUUUtTVkySi1JMkI1LUpKWU4iLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJZWDlWWFI5cm1l
  aVVELXprdkgxcFpWaEt5My1PX1E2Y2dMVF82UmZPZG1qWE9rX0o4UEUzCiAgcm0tV
  DdXVFZfOVd3RFM5VENQY2tXOWdBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQVdULVdXRFEtTFlaQi1CVUVXLUZBVzItUk9PRi1YUTJ
  IIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJWcW0zalhvZXpLenBqXzdHOGd3Y3ZhekNoT2EyMm85emZGNlE4SzlRS2
  M1cEJyeWw2UnItCiAgUW5McmFLaFV1clFRVThiUktQVHBCRGNBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBJ4-CDEK-6JA2-WGKY-4C2Z-VSYP-KOFM",
            "signature":"IIZgcx_hd3h4onMB6yOe7FZyU6k_8SqUsePyCgeM
  DB3w-yAt_f_YRnHcgipESTP1669Ci2mlPh-A_YQoPoDJ1sDz_eROHrxfAX-TTBBlM
  Omizu1UMoUnB1fEr1J75CNxwf9smIMcCxT7O4X1MQoOewsA"}
          ],
        "PayloadDigest":"EeGC-UU1fMXyppG62CiPC7pBNaDw257ubufE3izw
  mBm_8lrMfG_VWnfqMybF8Q3m6V0fWQxQfRWIc-9XpG4-sg"}
      ],
    "ClientNonce":"ZRD9o9z8_Axq6WHESqQ1aQ",
    "PinId":"AAAR-P66O-KGTI-QY6C-CXIW-OMCV-WQZI",
    "PinWitness":"dbD8_k5J6NhZxru6ltO-Y52bm-zPr80EbEbmcwMl6sFpOBx
  VFRVJi6AcI0gU3Wj3mdgAltf9ePxBRyYymjmtWQ",
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
    "MessageId":"CC5N-J27O-DR3W-WTQI-R3JB-NJZP-745V",
    "EnvelopedRequestConnection":[{
        "EnvelopeId":"MBX4-HVCH-S6LU-BEWP-KAM5-7OYF-F4YG",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORFlSLUZTVDItRD
  RWNy03QzNRLVFGNVItNzRUWC1OTlBDIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyMS0wOS0yMFQxODoxNjoxOFoifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJNZXNzYWdlSWQiOi
  AiTkRZUi1GU1QyLUQ0VjctN0MzUS1RRjVSLTc0VFgtTk5QQyIsCiAgICAiQXV0aGV
  udGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1CSjQtQ0RF
  Sy02SkEyLVdHS1ktNEMyWi1WU1lQLUtPRk0iLAogICAgICAgICJkaWciOiAiUzUxM
  iIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI6ICJld29nSUNKVmJtbHhkV1ZKWk
  NJNklDSk5Ra28wTFVORVJVc3ROa3BCTWkxCiAgWFIwdFpMVFJETWxvdFZsTlpVQzF
  MVDBaTklpd0tJQ0FpVFdWemMyRm5aVlI1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxk
  bWxqWlNJc0NpQWdJbU4wZVNJNklDSmhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV
  04wSWl3S0lDQQogIGlRM0psWVhSbFpDSTZJQ0l5TURJeExUQTVMVEl3VkRFNE9qRT
  JPakU0V2lKOSJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V
  3b2dJQ0FnSWxCeWIyWgogIHBiR1ZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNK
  VlpHWWlPaUFpVFVKS05DMURSRVZMTFRaS1FUSXRWCiAgMGRMV1MwMFF6SmFMVlpUV
  1ZBdFMwOUdUU0lzQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KIC
  BnZXdvZ0lDQWdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0F
  nSUNBZ0ltTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmli
  R2xqSWpvZ0ltZExUemxQV1VWU1NGSllZV3hxTTBKCiAgQldVcFdUVWQwYVZoVFZrd
  DJReTE0WkVneFRqQjROR2hqV1dWalozWkdlRmRFYUc4S0lDQkpkVkZ6VWtSdE4KIC
  BDMVJNR3RLVjFGR2JHRlZaWHA2UlVFaWZYMTlMQW9nSUNBZ0lrVnVZM0o1Y0hScGI
  yNGlPaUI3Q2lBZ0lDQQogIGdJQ0pWWkdZaU9pQWlUVVJhVlMxTVZrVlJMVVpYVmtN
  dFdsUmFVUzAxV2xaTkxVaEVSbGN0UTAxRFVpSXNDCiAgaUFnSUNBZ0lDSlFkV0pzY
  VdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGwKIC
  BGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0F
  nSUNBZ0lDQWdJQ0pRZAogIFdKc2FXTWlPaUFpZVVaSWFYcEtUbHBsWjJNMWQySlVl
  VWxPZVhkMExUVk1RV2Q1V1RaRlJrVldMVFJTYUc5CiAgRk1WVTBaWFJwWVVaMWVUR
  llhQW9nSURGTloybDZhMDgwYjFoME5tVk1WRnBrUmpkcWEyTnRRU0o5Zlgwc0MKIC
  BpQWdJQ0FpVTJsbmJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxQ1V
  qTXRRMWRSVnkxWldUZAogIFRMVFF6VVVVdFRWa3lTaTFKTWtJMUxVcEtXVTRpTEFv
  Z0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljCiAgeUk2SUhzS0lDQWdJQ0FnS
  UNBaVVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjblkKIC
  BpT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSlpXRGx
  XV0ZJNWNtMWxhVlZFTAogIFhwcmRrZ3hjRnBXYUV0NU15MVBYMUUyWTJkTVZGODJV
  bVpQWkcxcVdFOXJYMG80VUVVekNpQWdjbTB0VkRkCiAgWFZGWmZPVmQzUkZNNVZFT
  lFZMnRYT1dkQkluMTlmU3dLSUNBZ0lDSkJkWFJvWlc1MGFXTmhkR2x2YmlJNkkKIC
  BIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlFWZFVMVmRYUkZFdFRGbGFRaTFDVlVWWEx
  VWkJWekl0VWs5UFJpMQogIFlVVEpJSWl3S0lDQWdJQ0FnSWxCMVlteHBZMUJoY21G
  dFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZCiAgbXhwWTB0bGVVVkRSRWdpT
  2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0lsZzBORGdpTEFvZ0lDQWdJQ0EKIC
  BnSUNBZ0lsQjFZbXhwWXlJNklDSldjVzB6YWxodlpYcExlbkJxWHpkSE9HZDNZM1p
  oZWtOb1QyRXlNbTg1ZQogIG1aR05sRTRTemxSUzJNMWNFSnllV3cyVW5JdENpQWdV
  VzVNY21GTGFGVjFjbEZSVlRoaVVrdFFWSEJDUkdOCiAgQkluMTlmWDE5IiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6IC
  JTNTEyIiwKICAgICAgICAgICAgImtpZCI6ICJNQko0LUNERUstNkpBMi1XR0tZLTR
  DMlotVlNZUC1LT0ZNIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJJSVpnY3hf
  aGQzaDRvbk1CNnlPZTdGWnlVNmtfOFNxVXNlUHlDZ2VNREIzdy15QXRfCiAgZl9ZU
  m5IY2dpcEVTVFAxNjY5Q2kybWxQaC1BX1lRb1BvREoxc0R6X2VST0hyeGZBWC1UVE
  JCbE1PbWl6dTEKICBVTW9VbkIxZkVyMUo3NUNOeHdmOXNtSU1jQ3hUN080WDFNUW9
  PZXdzQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJFZUdDLVVVMWZNWHlw
  cEc2MkNpUEM3cEJOYUR3MjU3dWJ1ZkUzaXp3bUJtXzgKICBsck1mR19WV25mcU15Y
  kY4UTNtNlYwZldReFFmUldJYy05WHBHNC1zZyJ9XSwKICAgICJDbGllbnROb25jZS
  I6ICJaUkQ5bzl6OF9BeHE2V0hFU3FRMWFRIiwKICAgICJQaW5JZCI6ICJBQUFSLVA
  2Nk8tS0dUSS1RWTZDLUNYSVctT01DVi1XUVpJIiwKICAgICJQaW5XaXRuZXNzIjog
  ImRiRDhfazVKNk5oWnhydTZsdE8tWTUyYm0telByODBFYkVibWN3TWw2c0ZwT0J4V
  gogIEZSVkppNkFjSTBnVTNXajNtZGdBbHRmOWVQeEJSeVl5bWptdFdRIiwKICAgIC
  JBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"
      ],
    "ServerNonce":"04cY1MKWI4G8BGEUGQzldw",
    "Witness":"CC5N-J27O-DR3W-WTQI-R3JB-NJZP-745V"}}
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
<rsp>MessageID: CC5N-J27O-DR3W-WTQI-R3JB-NJZP-745V
        Connection Request::
        MessageID: CC5N-J27O-DR3W-WTQI-R3JB-NJZP-745V
        To:  From: 
        Device:  MBJ4-CDEK-6JA2-WGKY-4C2Z-VSYP-KOFM
        Witness: CC5N-J27O-DR3W-WTQI-R3JB-NJZP-745V
MessageID: NCJD-SJE7-VPY7-REZL-HCYI-2QWC-W2ZK
        Group invitation::
        MessageID: NCJD-SJE7-VPY7-REZL-HCYI-2QWC-W2ZK
        To: alice@example.com From: alice@example.com
MessageID: NAFH-QPYP-5OAV-WXPX-RCKO-KIKS-RYJG
        Confirmation Request::
        MessageID: NAFH-QPYP-5OAV-WXPX-RCKO-KIKS-RYJG
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDAP-F3KS-HNFO-7I3L-2ZHA-IGKR-3RGZ
        Contact Request::
        MessageID: NDAP-F3KS-HNFO-7I3L-2ZHA-IGKR-3RGZ
        To: alice@example.com From: bob@example.com
        PIN: ADN6-CJ3X-KEFJ-BMMU-TKN3-J3JS-73ZA
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
    "MessageId":"MB3U-D5WR-CRBE-PM3W-BXKC-WJL7-7QMZ",
    "Result":"Accept",
    "CatalogedDevice":{
      "DeviceUdf":"MBJ4-CDEK-6JA2-WGKY-4C2Z-VSYP-KOFM",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MC6L-GFYJ-7EOP-2OWN-24ZJ-4RC7-EXTW",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQzZMLUdGWUot
  N0VPUC0yT1dOLTI0WkotNFJDNy1FWFRXIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyMS0wOS0yMFQxODoxNToyMloifQ"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJl
  IjogewogICAgICAiVWRmIjogIk1DNkwtR0ZZSi03RU9QLTJPV04tMjRaSi00UkM3L
  UVYVFciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibG
  ljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJSTHNrbTRnVzZrQm5aS3dMMlBDQkF1aHJyaXVBU1g5X2lZUkt4
  UTUyRFN0V0dsT2wydWdFCiAgeVAzdTZBVEM1WW1JOFU5TXFyT1cxTW9BIn19fSwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2
  VydmljZVVkZiI6ICJNQ1ozLU0yUFMtU0ZYUC00TDZYLVJLR1AtTUtKQS1SNVdLIiw
  KICAgICJBY2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNRFFZLUo3
  MkEtVlBBTy1XRE9ELUdZWTctNFpaNS1QTFZMIiwKICAgICAgIlB1YmxpY1BhcmFtZ
  XRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3
  J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJJZTJtOTRzY21qN05yX1l
  xTTE1U3h0R2tmbkJMWWxUa25rSWVsVlhxYXJpSUF1el92QjJICiAgRHFNSElnM1ot
  UEtpWEZlcVVqTDRnTmtBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlI
  jogewogICAgICAiVWRmIjogIk1EUFktQUI2Mi1STEwyLUZEWkYtR0hZQi1MUzJHLU
  hNWlgiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGl
  jS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAg
  IlB1YmxpYyI6ICIwZ3JnTFRFNDljWlF6SURkT2k1ZjRsSXgzT2xsZFBqOVA3dUNzc
  U0wWmdLWHJHNnVBWHAtCiAgUWg3ZUdxOE5WNkRQQjBib3YzX1BZSUlBIn19fSwKIC
  AgICJBY2NvdW50QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTUNaQi1
  YTVdNLUtVVlAtUFpaSC1CV1RRLUY0QVYtT0dOUCIsCiAgICAgICJQdWJsaWNQYXJh
  bWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgI
  mNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAidzE0OURtZ2RlOXNwaG
  JIaWdIVkQ1czFiZlppa2l4ZzNUTEtBRzNWZ2pKZTRETUFWRVJCcwogIE1JbTBBY19
  nRVZvS29yb1gxdEdFRkowQSJ9fX0sCiAgICAiQWNjb3VudFNpZ25hdHVyZSI6IHsK
  ICAgICAgIlVkZiI6ICJNQ1VNLVNRMzUtWkpVUS1UTVRLLUhCNFgtNTdRUS1ZSzJaI
  iwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleU
  VDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJ
  saWMiOiAibUR5cDZtTGlSYXRPWGlCdHg5YlZabTJiaHBQaXFtVEJMdG1WeHpwOWRC
  TWlVWl9YOElkdAogIHY1MUJvcFcycWF5blJ1LWxFNU1WYW5LQSJ9fX19fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MC6L-GFYJ-7EOP-2OWN-24ZJ-4RC7-EXTW",
              "signature":"aeCuTY0X-J9_L6HGafZKbg5ZueP6PjoydfQDXB
  28B0CpGfqhPjTc6bjLF-vZWzSV4wZ9wotFvXyAR_QRXW7EtpbRz4s2j-bdzGR6z0j
  zJGnFWaxUYfAzCoFUHfhUDzJTthMNkQiJ-sUyRyriqaF0HjUA"}
            ],
          "PayloadDigest":"ZPrAcmAuks4uOaLyaHIyrISbFbCuNwXI3h7IVD
  B4hzyitFAsVEg8G5QukhJexWuntd_8f4VwQaAmZnjT3lPEhw"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MBJ4-CDEK-6JA2-WGKY-4C2Z-VSYP-KOFM",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQko0LUNERUst
  NkpBMi1XR0tZLTRDMlotVlNZUC1LT0ZNIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDIxLTA5LTIwVDE4OjE2OjE4WiJ9"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1
  cmUiOiB7CiAgICAgICJVZGYiOiAiTUJKNC1DREVLLTZKQTItV0dLWS00QzJaLVZTW
  VAtS09GTSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdW
  JsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICA
  gICAiUHVibGljIjogImdLTzlPWUVSSFJYYWxqM0JBWUpWTUd0aVhTVkt2Qy14ZEgx
  TjB4NGhjWWVjZ3ZGeFdEaG8KICBJdVFzUkRtNC1RMGtKV1FGbGFVZXp6RUEifX19L
  AogICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTURaVS1MVkVRLUZXVk
  MtWlRaUS01WlZNLUhERlctQ01DUiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjo
  gewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJY
  NDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAieUZIaXpKTlplZ2M1d2JUeUlOeXd0L
  TVMQWd5WTZFRkVWLTRSaG9FMVU0ZXRpYUZ1eTFYaAogIDFNZ2l6a080b1h0NmVMVF
  pkRjdqa2NtQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1
  CUjMtQ1dRVy1ZWTdTLTQzUUUtTVkySi1JMkI1LUpKWU4iLAogICAgICAiUHVibGlj
  UGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgI
  CAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJZWDlWWFI5cm
  1laVVELXprdkgxcFpWaEt5My1PX1E2Y2dMVF82UmZPZG1qWE9rX0o4UEUzCiAgcm0
  tVDdXVFZfOVd3RFM5VENQY2tXOWdBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6
  IHsKICAgICAgIlVkZiI6ICJNQVdULVdXRFEtTFlaQi1CVUVXLUZBVzItUk9PRi1YU
  TJIIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0
  tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB
  1YmxpYyI6ICJWcW0zalhvZXpLenBqXzdHOGd3Y3ZhekNoT2EyMm85emZGNlE4SzlR
  S2M1cEJyeWw2UnItCiAgUW5McmFLaFV1clFRVThiUktQVHBCRGNBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBJ4-CDEK-6JA2-WGKY-4C2Z-VSYP-KOFM",
              "signature":"IIZgcx_hd3h4onMB6yOe7FZyU6k_8SqUsePyCg
  eMDB3w-yAt_f_YRnHcgipESTP1669Ci2mlPh-A_YQoPoDJ1sDz_eROHrxfAX-TTBB
  lMOmizu1UMoUnB1fEr1J75CNxwf9smIMcCxT7O4X1MQoOewsA"}
            ],
          "PayloadDigest":"EeGC-UU1fMXyppG62CiPC7pBNaDw257ubufE3i
  zwmBm_8lrMfG_VWnfqMybF8Q3m6V0fWQxQfRWIc-9XpG4-sg"}
        ],
      "EnvelopedConnectionAddress":[{
          "dig":"S512"},
        "e7QRQ29ubmVjdGlvbkFkZHJlc3N7tA5BdXRoZW50aWNhdGlvbnu0EFB1
  YmxpY1BhcmFtZXRlcnN7tA1QdWJsaWNLZXlFQ0RIe7QDY3J2gARYNDQ4tAZQdWJsa
  WOIObOavss8qXnyOEdTEgsbbUc53eztv71PZ6UvPOurHjIy2NYPXPhWOboDXGhCSR
  glDWz0SDrPGlcFAH19fbQHQWNjb3VudIARYWxpY2VAZXhhbXBsZS5jb219fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDPY-AB62-RLL2-FDZF-GHYB-LS2G-HMZX",
              "signature":"kXuiOE4ej2xBhBthsd2zJQW2XYcSXCR7mZQa16
  c6QEMamtnw9ZkJX2HszugAZunlNC_Rdp1JDjCAZepplfgbzD7V354mep0hdKGoXye
  QN9O3UmZxmtIpvcWPuESoAl3VXF7wNpOMvbr-2cRsgPrQ3DsA"}
            ]}
        ],
      "EnvelopedConnectionService":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTA5LTIwVDE4OjE2OjE5WiJ9"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tA5BdXRoZW50aWNhdGlvbnu0A1Vk
  ZoAiTUE0VS1IVzY0LU9LVEstWlFFTC1YNlVILUY2R1UtWlNTV7QQUHVibGljUGFyY
  W1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1YmxpY4g5s5q-yz
  ypefI4R1MSCxttRznd7O2_vU9npS8866seMjLY1g9c-FY5ugNcaEJJGCUNbPRIOs8
  aVwUAfX19fX0",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDPY-AB62-RLL2-FDZF-GHYB-LS2G-HMZX",
              "signature":"b9uPvBuiCFiOOWMync3K-kGEMsv8nsSe6P_bJf
  gzw5_jfdkED2EOTLeyavP4aIDOvF12BIccF3cAZLlDNeB740u4nu0XEz5HCX6RBdd
  C2XMfYbDe78yTBAaTtEqZ1jhaupspEW5q6viEfMQJ8BWGmzQA"}
            ],
          "PayloadDigest":"9_otIc37d1dsMnmIm6V6TqizsPRvQU1O3a1XVb
  -0A-CfdGk5m6blY9awr39H6gd547nuhqF-JdMBemwbPIyfJw"}
        ],
      "EnvelopedConnectionDevice":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMDktMjBUMTg6MTY6MTlaIn0"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0DkF1dGhlbnRpY2F0aW9ue7QDVWRm
  gCJNQTRVLUhXNjQtT0tUSy1aUUVMLVg2VUgtRjZHVS1aU1NXtBBQdWJsaWNQYXJhb
  WV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibGljiDmzmr7LPK
  l58jhHUxILG21HOd3s7b-9T2elLzzrqx4yMtjWD1z4Vjm6A1xoQkkYJQ1s9Eg6zxp
  XBQB9fX20BVJvbGVzW4AJdGhyZXNob2xkXbQJU2lnbmF0dXJle7QDVWRmgCJNQ0pC
  LUo1R1ItS1RXMy1KS1RFLTYyQTQtNVM1US1UQU5PtBBQdWJsaWNQYXJhbWV0ZXJze
  7QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0NDi0BlB1YmxpY4g5UYt8Q55B6K9oxS
  fj8UN35FZH6vlDeULJUpJlde7Iw2Gb8RjV7Blu7NiZME8Ig-BlSru-m6ztXY0AfX1
  9tApFbmNyeXB0aW9ue7QDVWRmgCJNQVM1LUczTlItRkVHNS1KTkVFLU5HVFQtNTRF
  Qi1HNE9JtBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEW
  DQ0OLQGUHVibGljiDlS9hxCUejkfMJ_e8tJVThQHG-JqLvrEXWV8zsPj1J4icxh7I
  pQDur36Qmwjm0WjjCXgDiQmSprZAB9fX19fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDPY-AB62-RLL2-FDZF-GHYB-LS2G-HMZX",
              "signature":"bv3JbW8GRQu1egN3K01uXFs7paCiLPnZVLzSx9
  qd_32oO3DoZ62Hm5GuTTOQ1dq7JevCjPXu7YKASxo1tsKI_u0yu_NH0MTsBQJzQiP
  mzxl1Rady4rrCZMmMmuE1n1EyVqOpqVMRPVbh9xE7We6NMDkA"}
            ],
          "PayloadDigest":"ryWXi7qqqFa2kAgjv94kWwiHa3rmnDkuxKSv_n
  HYCNvAgGNE7ChW9nod4MmT5mO5Lq4jHrFv2PoVvIjhmQnuDg"}
        ],
      "EnvelopedActivationDevice":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQA-ORX6-SYUD-OBPD-66UK-UJLF-T7EE",
          "Salt":"P5HCNTSxumoCQDNal1lMpw",
          "recipients":[{
              "kid":"MDZU-LVEQ-FWVC-ZTZQ-5ZVM-HDFW-CMCR",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"1hxJpV39-ClXIGUxEJs_9Lh3Z89iMG6BQO0zY
  GoiNblDPvTpFDe5pjUlR6qT-jEdufWzDx_F1aEA"}},
              "wmk":"j64N7JuT_Azf6nyreYH_0f6hKXzg3fs0Jyw_7gLbNBT7
  OBNm-1gurQ"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjEtMDktMjBUMTg6MTY6MTlaIn0"},
        "vBjl0qXoEna0h1vrwmO2PlPb3drpoXtxV38i7NCiuNkG9JSJt1UTugrm
  SqyTYrA08GWWZZ9vA7Sq85RMTM37_mV0j51_9iRjunLAs5IIhF5xLA2AGwLc23uPY
  QYHylzOt2QtokoZRDsDUrhX-pRDECpUz0iP30mamSjMkfF5DgV6XxQXZfQvQDZx-r
  DdYSY-NoiG3QZc0ZJEdqASaqovqVOD1iENIrS0iwB5AhbDl3r5DxMNVtUrysNfTim
  67nQX",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDPY-AB62-RLL2-FDZF-GHYB-LS2G-HMZX",
              "signature":"wYBXRTndm1EFpMSV9lCgMjcDFicQB3xQM_ZKT3
  IVnK2x7LMFY3qXHE8SI_7J6_emWHmv2bbb31wAmf2PbogWoFoh6pFcMGyuejQkg4N
  q1O4ggxJcjsB7qCBosZE25bB5WJb9zWKvyil3ZaVSQMWrWCgA",
              "witness":"ZGGLtk4b7Ct7lOQk3rsj_1cQV7QJH-ogKcFMNXuL
  XDI"}
            ],
          "PayloadDigest":"96zhY9KlnQJYNfUqOhpspfkrJ-t10yNA3mR4jw
  Is-AJRkO286wwuaaJlDuDTuxVBHhjlgDlIgw2ybvH6vSwsrQ"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQD-ZM5K-LKKF-ILS4-GG2S-IAU7-SNKB",
          "Salt":"EqNwfNG2SEjWsph327NkWQ",
          "recipients":[{
              "kid":"MAS5-G3NR-FEG5-JNEE-NGTT-54EB-G4OI",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"ENwMs_Ynk2fPMeLnPbpHPNpPdDEe8wK_G7hBo
  i9LVAOo1p99OY52W2fQqJttwA2HbbFC2RJWeq4A"}},
              "wmk":"wmFdyKnrVtHTxjKz-gz1WjKsqJuGNOa91gJp4MYcEeBd
  -inanGfo7g"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIxLTA5LTIwVDE4OjE2OjE5WiJ9"},
        "k8c3LPLX26rouC5MrU71zZfy_j8xfpt0wQhizXeTzhgW87Y03Ce8TVIX
  r4JE5PZudbrN5HSGNzzWhpLDGCCKp4wrdo-2SLMxFtrHokEP9ttcx_J1tU1NBA0F7
  8wNghoh8k1GYai97f9uQ2ldaXTZIQmUR4gfpRzPp2riMYlgM2c-XJPnBAIpAUOmtC
  3eUvUgk_D0e38Yn1Nd0vbekU0R_1h4qN30k3nTqHu7y9b1AkItX84jJftMIeyuZ-3
  w9hcF-bUEI2HoWXb7OigE4x3OETE808MTza4IImDC6DqrEGdj1cXR7QswXdhTV6Fg
  wTy-sk0bk8TYSDstGZh427FSNgAkQ65-RgrJVC2hbAt2aj37kOwwDzl7i3EXuCowH
  i8ydkFPJTeOxrF2GdIacKEpxwgzs0JQdm2rF6ghm37yFX7A7C8AajQhJ1mJAiYYPR
  kWj6hcNOhTnAQHlzlB_zJVst6Iu4ZMgIpbQgqKKeVh1f201SQaPXwtjD0WqcrarxC
  y1idTdxhbaEioxVsmM9jzcEbL5WoLqiuSz6d-Xx1RegDzXLMXnDPp43Bh_v266MWy
  JOKRNs7NQrU9qF0ZqnypaT9iokfaLGOBNBaAjU668riVxM3Va-nhiPZ6BvTpDqgTO
  oBXDTjXm6Mkm6Za-cPZguJMSnxc8-IwCZSZyFQ4BJdBVCMkvC-DB84Y2TsrI1urBy
  2q8la2F_bOF3MvTMV6W7Bvph9k80EmmlmH9FrEHeUvdQ6ROtCLgDDvEowlOxksmgM
  5cXt_M62ikyzkk0M_prj7g4adRGf9DUYkiTGwjdk36cnIw6OiqQCehNj2Btr3bn4s
  4_p0xFr4T7hyNdwFEd0euDo6YShb9QBoivXW2YiY4rYOVX-5f2itYaUbRygqsqGOp
  G0xMWq-gYqZauA56uhPQcPt-t1E0LL1uDWSNfngWMcKR1Tv8rh1lXLI4rmEWDTeip
  Tm8FiUSeqNWISJQo1jVOwM5W13dlOu0wuh_YIWTKmYHg6uP8KYJEyBxJOg7HCBe0B
  c7bXochVqxfVyUaCZBFbESodHWIX7RIl5ne_7asYlVZ8fF-sw9kwwW3TkJc1lyFI2
  hyy_djnnQURv7TeJMCP3w_5muAxzRbyLzPvuHh6h3dkkLLDmZyp3ru7wwFwUu32Q4
  fCUkAFlZwAkz4APtyWgtAZbVd0P0v8CzgM1vMyoDuULNGjaOFqATj3m7J5_oWgdte
  QkeSUX6cYto1fDQC-AkEsm30yqbluclXuA7Gm_3nAcmWLXlWPDA585BYHhFtXa0Xz
  aQPT6hb25f9Ke4Y8-0lQJwDSmWQTeVKmQIZ7bTlqvjC5uvfjwQgWulagJB1gbP0Nv
  HtbVsPy_sMPqgmPs1Yo1wc_a3hImYCQsA-ONXMTWhcavor2XyKtnGwU3aHs4n37MY
  zjMGiskEj34hrGFbrns-3OMckKXIpAi9R7AMHbbtFOHN0v9r2Vksrp4t569bJjnlW
  UE0R9A17C3ma_-XLoGzFrBo2b5X278wWEbjorG02gSztScqf0EMHrIupZNcdbzKo7
  jiK7oTAfowlDuwUElqtTt3LXIBvwUSCe-xsfTpBFt8rjgCw9Z8UUsBbvK1_6-mS2b
  E1THWJQcAVcgVxqPLpItQkWqmJ1hJv1K_OnzPcQllWuY2zvROZOqFopHhU2iykLRr
  xNJVnzThNipe09qVZ-2xxiNIUWxF_BIv8ffKIVZ7fYKf5N7omawGKqBz_9R-AtkPJ
  gqNGVUCItQaOCC6NuVDnkHGNKeHTDI4ihHpx31urIYPlzy5TZPP1VHIN_0991xtJD
  rnvMnX40iYjxo6REI1Sg9CpjPBfsghKS-xE2OvtvzDnRZegmaz21DQD7YqXBZUykh
  VSOBgLyvdH8gZMfp8kYm5-6J99HkXsfMK7N6JULep85ZTfhgJa2xN5gqdVoleBaC5
  AoEn0RO5gQUsmT90LAsOh0pr2TSTtLVPedc8j5_LDa9hiAgN_pKTv0xs_wg0VxEzD
  kMe98TLm9jnJw9HUGSrGVUo6pfJ92QlgfaPWcIPj2AVw047n8z-zqGB2RUXuXhYky
  51ucuoa4KfLrFDCfFP_uRTi2zSSArWPUYmS19Bi9b0sDCiJbY9J5mLSuNGh8M7Jie
  NUO2XOMASr41z3iaTibAUM99G2Q4lf2QuqpTgGOJ4nZjf-EA2kRid6vdJ_Z3sICrF
  tfZoUez_BS9wzFP3OSKNz2GpfzDL-wDaulWqADe4xmZcHa8Tp4h7of5IJASAj0KG9
  D0uIZenExA_DjAcZ3RpHRYi3qNsXxaTif6SUDd1Zxo26Dv69ASvPNss8Jp8kA_j83
  OAbSQEXEXIaA-VMzEFP0A0hZVFaVzCb1QWVC8MDFdkaYDHm3UUQX6UEm8FSFrQ1C6
  brzYHtKTVecPpUynxzEyju9MnqNsdU9p4mX8AdadzL_nVOpXRAV7tW3IsC6_U9ksq
  cVPWqVjGQBo3r5BZlh3mUvTDmYF3dfLOx98b3F4NF7DQOqipPmdvJIR_NzfvWV-vq
  eBGmObwEvwoTlxkRHTwpY5z2pIKBfsA9jsbX8QiMFxu6sXVQUWVlY90BPO8XFKYYk
  1w0o3Qa6kBlzEV4Atq1ivFUJtbmg3cE4syQQP2Z1n7bFx9oHDPLIhBI-uG137BYVH
  vJ_zB4mdPsQtgJHrb7Ne_ChSrgiHc9wPzaidvXUWULHzSWJ6F4gA4kR9hXdOmLx5u
  jUZ8fxEpHtNrGtfaiJCNBWzqIcRVfQbbxdSvo-7G5uLZxPIXLu6pqzW_BCG_UrXN4
  gaTbx_CoIXqXK2XCVAhybpg1ns1_Oswnanb1ptjXBgRKpYLbwlp2XoV5aMnZXJq-R
  Ili_7gQYZUPJDxlezWMNRAKZzp86OeVBKv9ta4HHxIOavq76ElCHi6Wi2EEaYN0Zq
  EzD3CU0A4wR06fUq19B9wXuYOOqSyV5Xxupzh2jibfEuydwHzMRn5PMUPf_-NP-Hv
  KY_fpVd2dtLK0gz1LF9vCfM2QrSYR6AJ-tp8TJ1rv9HJegD5dO9909PlC2R32Lj8Q
  6d3NzJsVSXc8pg-jX-L7dyyTrsz0hkyV5qSSSLULo9f9cC55nqrx4vB6vSJ8vCnaj
  zEImfgmGkHU3ApdTU5jFoMJX14ssoYOhkaKMHW01bhuwgDZ_2uySSHBzqORJe1FMR
  kCvkdUNjcXcnGLzB4hSUh9hW19BX42xnNBfvxJZjja9MniLTMCfEfV1e5UmTEeiiB
  o-ubMs-K_qz7EwCNddxRlQLKoytYc_Bwx1UwiWTaoOZVKoAHervd_X7svhZfhusls
  TlBvK0li1AKp57qz7mRHXt0BAyy5YTIkR6JjURrMPhNptBuiMIvBcivDySt81O2yh
  FB7uhjn82jz-KO3ILs57DlDFBLf_GxvfsN598wkg24IQ7PEEoJP3xx89Y3mYK8Fi8
  u8nk_MT2moOWXge3oDD8H5OmIqywGMep5N8lI_VBAWFr6B-Zplu2_QvqO1oDdz-zi
  -l9qPRKIkqOuzWIgaez4ZinKviYWi7lYie-lJfy2I8SiuidR6n1jZIcYTT7DJj7kZ
  jKGeueMvydqXLGhNP8wqYCP_wu9D-4eSqtDS382_I5iuWIXO9zldbhBzqlbdbnVvk
  RI8gDEZ3Of5tkO97_ga_auwK8-7c5lnENGbPwx84sdpB1hwgr7No70tnOr_A4ajSS
  c4fA-L4mt0MMuKv1TWVZiQQzOyhIR8TA85d11ta6F4F3kNhox1SGtzCNn0ETFaquB
  dCQdd2rujAWaqrJv2vkSIBYK8Wgwa2HSQ9QHQJIw9aZviurGRtTGVPccALAqdGKBC
  AWEHGmBS9SsVKNrrw0JI7pxKJx-VxxnjW1uqpZxKOtfr2bHFHEUbbIxem2pOdBQ9p
  CwdHo3vcWd-zdK1jt-TICwnUiLvs0cKq62QjD227TAs5ZGfd7_dfb2C_RLYdmhIxR
  OiBfvStohPwwbX0OIwd0u6qEOqsMw4m87_4dtxL0Qkoi7LqpZvytP24kPVcuJcwwr
  xfbHtpFWGVCeJGJsfHnFRaXXlm80F4mzjts4VWJeWAtlGIDqENxuGEBj2hWCAVs4D
  OhIsE_c19ukw-Xcs_XPQ1By2Z7qA4yyu22ZZkSk6ivn1-SZ-05LLTf5i_BMcFgYEo
  MrkVkJp-vf51hJHbZVLG2OfV3O5GusnjuQzVYngGUjDJrvtTQQQvhdZBhmShfB6eN
  5OEyPuZersxL9MHh-nZp53iadAPJx2Ftrq-wvaKynK3u38LVM5Gx7Dmjg5Mt1UoLw
  lNR_EjpJLd-zqyQq9XfoTqCmz5jsZwXkQtl1r3cdqGqyZ5yUp7YFTThqVxjvtxwF7
  4rz9VmgsiHDB79ZFUzjg0jVsUduTSHy86MWkz9qDjUD3HkvyGxia7fyturpIUvP08
  NSciR3M8j8zbRF9UGp5JPNjMRiLWduP0fUrziGxXvqXmU5ZMvNuQWkBwKz1Xg3Iw5
  RTsU_Pot52ON_Wwc143H8gD-KJQuFtXtsUOX_vFkJclT8SozYMXMQ3sYAllXI1wrS
  dxXyaI5ywx-bGfatQr8x8KLsMa_EshgSoBAexPjOmAT8b8EBr3w8tv-BJ6RYcl9on
  l_A4cVeQbGxUa04CcmpFWRDMRLNfO93GY3iYWG2HbGAB45eBGo9ywkcnJAB-58UzL
  xjQ5Y2zUV5NpaNZ5j5Rd2SqIhS1FKx78DPlF3tAv6Tyei-jMRCBsnkfRww3RU1hss
  J8rgzo94qXFEDkUB1MJh9fMt3iemMSDhzm5gH8lhr4j364NUjKLAnu9cEgEpZRXds
  cash-vfA5wqsycEwe0ps4fqxyN6-EgbA4YzKeBV0qyuUm_a84aaz6WBuGOMznQbT8
  7p6Xi-uKnQx4zvx4C7KJe-g4sZpJLj-2DSiiSAYceCC9yhVnUoczDyfTJmoGFNcZn
  7o26fYxaCbWObuAJkZT4Wh-fojKyAmoZ6N3ZPnw2wLDDeOE6Ry7e3B95kgnVYOrMz
  R8pCO94bRwk0qdvZemh1PSH1lN_b7D7qppXzOXWtT7oZ-Alq0YxGPP3Rot0sVEJSp
  hMloE3-jKnUlXGfd5LnFY8jVQinLOBZJmSgoEVQyAdByYOZ6WuAbA9OpsxtukG9de
  eIYEtGNaEYAVV9izC8fEVaXHcpvC9Hln7dqAE4feyXatvddGYGyIqEfBW1Vb-BD-y
  Q1RuiuFEDYmXNJnIxp7__JYkVxqiLIl_Sbnjm3teKYLSDLhi7De7Xd8NrOBodhp1M
  X3oAs_P3mvRaKaRFiNvq984Oa8mygi8B6H0Lhl_LpMcu2XkwEOahAeLYRukwS91wg
  2GKazgIJ1xWgyyf8xgogQVyRFUD9iSBofOYxV7QoTfMjl0wUTNPQ2PsjqPVXuAzm_
  9m1w6npaiTRYKv0v-Q_8hMMxX_MAB6NW5kTsyX29zGHgHg0RSz4wXNfvry0rRTHOT
  -u3czRa77tYQtFwBLJV8mRkYo2onVK0rmE6lu6lHqI8PneU2tAdu_MkrToQU04AFP
  D7GrvpjqsSOATN9E7LR7ujpDlBeeidv9lQk8v1lqYPQeCy6JOdgud-t2gnSyPEV1u
  yrl39NDpMNupnSDo_E-arWXwM6VJk9S7-eBUAjQlpKUPQ8K4B1qswXxliUL9sulAT
  BhIc47LMN4G3F_3CDBPhkwSAQs2CCi4ZVa0FXK-3VtEAlMBVYJ5F1bmIy7kj1ToVS
  dEalJ0w-gUpt5ElFmkWQtNlAra-a-LSIm9dgBF1vcFrW5tmXHJuX2iUoZMzN9wOgr
  hMqf60f9NA74h8HiCvswfoEH04TJctu2rv0IGVPg4i-aYQdAhLOK1Oq_TsZUtbkPK
  CAxyTiCguwxiao1DgVN6ZtChQ6pTI3ncmAcva_y4bU_924K86aAD55CQ13u3-HrN6
  2L-PaHE1xaOXTp8eAUfG5PiXVbWmr2LEMcWAP2BKXu10h0umpMJsWQz8IxeXHO2AR
  _TmbVRhUAH9qnjKLjg50tpQhzOkGEho4s_82V_dd0-I-qmAxth7r5VAIAwlne4Wb0
  MoWiitrvYedQUy311G7AnuszxVeM8FlYE9TeiUa6fWxbAaDfwiw-419ELRf-lO7nF
  Je1W57TAyexB8n3TO_2uR0vCq6QC5xCeA4G3k1I7HyxRQC6wmyWPhPTNDVBzlzWhL
  pMPJ5QFY-DU033jhDXYXmsw2VBlwRuIECO2Qk-b_ggxUuLurSIXXuh0hofp59dC6z
  gMtxanHB6JPx5xVEJyQ5hbvKJ8I--iO1o5xmls06YzvxIIFKVaFM2zUjd5s7qu7xu
  IGIp0tgBMHQt1e6xg4xFeSP4KBRwgNbEyH8EedafqsLv10uw6A1JiSAmr3b_GYZ9c
  CI6i3hONZgp3oyC5HfDQj0ZaT5J51ZvGN7MzS_UZpPY2KWzUas9ZALnZlc9Jwak7l
  QL7ykINBJJff9Uzv50PQoyruDC628XcjHFp2TTQ-HUtRD72MC-jBpDEnImNlIxCeh
  IO0k82_tWraBc-T_jrIeaZs9VWWZnQQLnJdfobthgA2qqjBau9qq-f436TiCsofYZ
  sqdjLJ7Vknr6ERvIsN13im6ML8MDYzGF9Sm3sYXT-vvQAWl-sbMLFyH8gl5iGLuma
  LKwSlEm5h0QO_SfvD5UROsXM8wrBbus4pmoajQ-49tsd-2yQXQmyOmqHgd7-a4QVO
  _i004496iTm50-Knm3YDPQ71dLtFZN_49zE-Yh_rD_xEnx9ShY9TOZ3dxR5EnJ0lr
  TrWN1j41AfiskvAkH1uANMzuL85nfGelh_2DmLNI7qu3-NIez2maxQLaNcx5uIeKz
  XcR6hoAkNeseyVSXsCeaJT8FMNQ4J1qVR_KLkLzTajWgWIPbYgYW6fbQ3XNXaibGW
  8lS0NR4a13NdtH-Z9FcTqrfDjEb5xvKQZ3R5Lukx-XUbigDkXR8vVIN5-Xmk_r_pn
  NTEowDh4htGLST-LPb-J_CdnVQHwnWQWAhR1psmXgBSyTAE_jsQ0SS3nrAJhgySLu
  rLrW64vsJBIppDVivhN3bu5fLYM6g1kirt0SSSrlZ7ivK3ydPCfjaqgUJyIdukMzq
  Hfu2RpLfoe3l9xg7_msHOzQhRu5FSoMMNYj9WlTQTILu6nCrLqZ0tXRg9T8rwEjIM
  uUmt4Si14geK20-KyDqE87HA0haiJ9Rl7LG2PC4vowQvEG3VS0uNzcaVoI4JyAXAX
  yyDc9LF7Z3y_thZKL289rqDqbq8xcnMTziqeCJ5dRvGFRmQZS2JGOT3NJwsygxpY9
  -FP7FL_MCRpFRx0Im0FOa0x3ldiPjrU0f-0c4kCc3YoEj6HRKLete-UjkLyieAGXS
  e0hZ0Dz5TN34CnpXHBM_9BIJA84ImLETdUSle9PvW82x-19RzSczky1u2DPSfXahX
  9o1HzMxIhqzIl7UQNKGM5ZeQlyvcY7yfvwVoBc64bruopz8R1VxqvBx05iW2lkSTE
  IErUQsiF1RN3Nrfkd3oXoJbOW7EPSGq3VWyXpV327f_NzydJrUOmMXAZf_kXtcbTH
  bUVpZCI8Q7gTSFIiM5HB0FQi3sTK206L8THJq2uq6PDQP1cySMQQdBcc2jldRDKQW
  vxx6qe0XAOfL9M9xa9er2EspK2-wTthVK2GIAucyiyaKpG0VIcEYsk5YciQCeQH9j
  29btKDkPVOMOyndb7Ty_p65icQRZklcQJNFQix8_AEmW5oZycCbfQfPY9oKCMZOJ8
  A5oCl4O-ezKH8OForClyoZ5n-6CutZ1H0fZiMfdcTKxn_wC9vFdwMrED0n0fbvN-K
  _D4lhO5Y_dfBNFkckMIFXXlYH3P9fVuFJNcSZaVZsE4v2bjPDWX2y9VRDYBIS4nk5
  NuOuNErlvYuogj_bs19T-naR7ecMKJ7acpxQBM405A2YkBqX5zVCIAovEhVatYs3l
  ejYRQNnZlO-rXyWj3ELcL5CWmcLzXnTJpPdoMsW1CTGb6OeIqHsPsUS8mM-cQjI_q
  eEzA9QholSDqm8CaXnYAiGPl3gb9bY8yvoUqBzYrBkIhhaD_P88ClOe2AJDBcBFZf
  pIc4Oj5GA-7Uu3STFk9utDp5xAnQgQokwYSUsd7ft7pmJSVNUD3cEE50aiAFDtOId
  KetywsuRJtaVIWzd9MpzyCRcItITfUapn9O0BU11NBvW34ScChaPtbK0wsPR7maYh
  0prZUIi-bPsagMX6tUkBA56O8M6mMx8_p0UuMigWiXin2h_YwDmnWkQ54deydi0SX
  Gc8fb648RUxu1vn28uwMB1CUiW8ckyrzhwjqtjurIeIKaBf9-nIwLvUURcmhqVXT5
  6L-iU5ggrFBJUB8irouzy9uvOGq4abeJHJKFTDGLE4aO8sqgAAYAn-PpsBN19ajjD
  GR8D8xpSk1xj_ixK-kxWBVvIn2pXPGB6D2Lw_rcLyvalmo5udswp7MDftzr40B5hV
  V84N0GcdPbbcrbiwIOjMeWBJi-xIvN0kDtbXe6iSM6F4gNg1wEYOQSSDQuElFq-c8
  wFKzUN9_SN0AwUCQpVH8zBN6OzF2-MLhbiKRepaiJTIid3QT9LB33vmRYVFkYEgNj
  SXx_vFd27n9eEUKaP6U8i7r4LlSBBr9IQe5ipBSwohNEtZ-c",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MDPY-AB62-RLL2-FDZF-GHYB-LS2G-HMZX",
              "signature":"TBbLkF3G0WoPLuoUJWGdd3rVxIgRgJxnehjRed
  vKn2EWcCcSyUVinREhUrh2dgXcRE7Hm2wGzrGA9RgOR6Mm-oIKQvgkB4qfJ8fu7HK
  h8VisGTqQ4g7ku2nVvFGudmyjBAoOw83uGi7Z64Vw7Tj8zyQA",
              "witness":"OiD9-4v22pZSzegadlz8exiAgAbD6BjEd5N5XVeY
  WXA"}
            ],
          "PayloadDigest":"VKt5nl9KhxQsiN8kp7jDA7xXA3dVDrYNst7d3c
  gYTXVk8Ac8MOMeRyIWmeyTfh50QOWmgR978v-TRyvlgQRsvQ"}
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
<rsp>   Device UDF = MBJ4-CDEK-6JA2-WGKY-4C2Z-VSYP-KOFM
   Account = alice@example.com
   Account UDF = MC6L-GFYJ-7EOP-2OWN-24ZJ-4RC7-EXTW
<cmd>Alice3> account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MB3U-D5WR-CRBE-PM3W-BXKC-WJL7-7QMZ"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

