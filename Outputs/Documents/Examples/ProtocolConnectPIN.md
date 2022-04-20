
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=ADFR-TEQU-3HJD-IRND-P4TS-CRBD-NI
 (Expires=2022-04-21T16:17:50Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcu://alice@example.com/ADFR-TEQU-3HJD-IRND-P4TS-CRBD-NI
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    ADFR-TEQU-3HJD-IRND-P4TS-CRBD-NI
<rsp>   Device UDF = MAA3-BQPZ-WWO4-7Q5B-P7AH-FY5C-ATMD
   Witness value = HS22-VO5M-JAG4-RQT4-ROHX-PERK-YYCW
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "MessageId":"NCAA-7UYA-TG2C-6XUC-UG3B-4XGT-OBIE",
    "AuthenticatedData":[{
        "EnvelopeId":"MAA3-BQPZ-WWO4-7Q5B-P7AH-FY5C-ATMD",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQUEzLUJRUFotV1
  dPNC03UTVCLVA3QUgtRlk1Qy1BVE1EIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIyLTA0LTIwVDE2OjE3OjUxWiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUFBMy1CUVBaLVdXTzQtN1E1Qi1QN0FILUZZNUM
  tQVRNRCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIkU1ZUs0cUkzTVlCeDV4cHR6Y254cEhabnZNQWpTbnJIRjhBbm
  J5cE4tWTZpZlVHblNfTlQKICBfaXFacmdteURLRERDaUFXSkU0R3A4VUEifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUFMVy1RWFg0LUlBREUt
  QTRaWS1HUkZWLTdGUlYtNk5NWiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiWUZ3WmJ6RkNwcmxETk5qSkVsOE5iUDl
  BcVZlNjQzQm1OTkF1b2tIRXVHejFWXzYwVHFyUAogIEU3WVktQlZBTU81Uk1PcUR3
  R3U3WF9xQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CS
  zUtSVI0Uy0yR0tWLUZIUlctQkZJNS1SUFJFLUVGT0UiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICIwNW5DWExwSjl1
  Njh3Q2t1dTRKWjVxTzR0d0o3cTVjaWdPOEJxZzNzX2Z2cXZLcl9SeVk2CiAgMW53Z
  2pIS2FzZ09wWWFxY0RXczY4eWdBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNRFdMLVNMNEItS1dDVy1XM1hVLTZJS1otUUZPVS1BRVd
  aIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJ0dTc0QVZLYUp1ZGRmM1JEcmZ0aWI0a2VtOVN4MGE3czAtQXVKUzNRbE
  hIc1d6VllWTmZKCiAgR0c3WF9NN1dKRlpEaFQxTjU0YUU4ZFdBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAA3-BQPZ-WWO4-7Q5B-P7AH-FY5C-ATMD",
            "signature":"vOufdCB_9HT6I8aarXvmmOyNSl-w-xyJ9lDjAEE7
  76793vl1LkEFYsB5bh6ydW6itfx7wtyI5h2AYah4BosKBPeG5qfIVX0bD_BHzH3wm
  _pYThtpZRGUd_CLlGIyqZi-dj6pra-RatoCDbBdKIgPCTIA"}
          ],
        "PayloadDigest":"lrcVgAlxiwM7iaclmB4lQO-d1qIYWoilGa2AnxAq
  VJOSNHtc8NDZnGwUyg6b6lZlzoVgQRNgOdGQaVqW6sNf1Q"}
      ],
    "ClientNonce":"gZFH1LZNoACm0-x0tg28yA",
    "PinId":"ACKJ-BKB3-J77B-G7HZ-DFKS-E26L-NHXW",
    "PinWitness":"hv6xvNXOspA9MN4YVkNb58P5Bwr1WCy5OA6gtPxy0LqP-_l
  vReHSp1D5MubPtMYnrSrEcGebQrevBGB96ngkZg",
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
    "MessageId":"HS22-VO5M-JAG4-RQT4-ROHX-PERK-YYCW",
    "EnvelopedRequestConnection":[{
        "EnvelopeId":"MBHZ-QYVP-T5DQ-FQAP-AWD4-FLMO-ZZJT",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ0FBLTdVWUEtVE
  cyQy02WFVDLVVHM0ItNFhHVC1PQklFIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyMi0wNC0yMFQxNjoxNzo1MVoifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJNZXNzYWdlSWQiOi
  AiTkNBQS03VVlBLVRHMkMtNlhVQy1VRzNCLTRYR1QtT0JJRSIsCiAgICAiQXV0aGV
  udGljYXRlZERhdGEiOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1BQTMtQlFQ
  Wi1XV080LTdRNUItUDdBSC1GWTVDLUFUTUQiLAogICAgICAgICJkaWciOiAiUzUxM
  iIsCiAgICAgICAgIkNvbnRlbnRNZXRhRGF0YSI6ICJld29nSUNKVmJtbHhkV1ZKWk
  NJNklDSk5RVUV6TFVKUlVGb3RWMWRQTkMwCiAgM1VUVkNMVkEzUVVndFJsazFReTF
  CVkUxRUlpd0tJQ0FpVFdWemMyRm5aVlI1Y0dVaU9pQWlVSEp2Wm1sc1oKICBVUmxk
  bWxqWlNJc0NpQWdJbU4wZVNJNklDSmhjSEJzYVdOaGRHbHZiaTl0YlcwdmIySnFaV
  04wSWl3S0lDQQogIGlRM0psWVhSbFpDSTZJQ0l5TURJeUxUQTBMVEl3VkRFMk9qRT
  NPalV4V2lKOSJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V
  3b2dJQ0FnSWxCeWIyWgogIHBiR1ZUYVdkdVlYUjFjbVVpT2lCN0NpQWdJQ0FnSUNK
  VlpHWWlPaUFpVFVGQk15MUNVVkJhTFZkWFR6UXROCiAgMUUxUWkxUU4wRklMVVpaT
  lVNdFFWUk5SQ0lzQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam8KIC
  BnZXdvZ0lDQWdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0F
  nSUNBZ0ltTnlkaUk2SQogIENKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmli
  R2xqSWpvZ0lrVTFaVXMwY1VrelRWbENlRFY0Y0hSCiAgNlkyNTRjRWhhYm5aTlFXc
  FRibkpJUmpoQmJtSjVjRTR0V1RacFpsVkhibE5mVGxRS0lDQmZhWEZhY21kdGUKIC
  BVUkxSRVJEYVVGWFNrVTBSM0E0VlVFaWZYMTlMQW9nSUNBZ0lrVnVZM0o1Y0hScGI
  yNGlPaUI3Q2lBZ0lDQQogIGdJQ0pWWkdZaU9pQWlUVUZNVnkxUldGZzBMVWxCUkVV
  dFFUUmFXUzFIVWtaV0xUZEdVbFl0Tms1TldpSXNDCiAgaUFnSUNBZ0lDSlFkV0pzY
  VdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGwKIC
  BGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0F
  nSUNBZ0lDQWdJQ0pRZAogIFdKc2FXTWlPaUFpV1VaM1dtSjZSa053Y214RVRrNXFT
  a1ZzT0U1aVVEbEJjVlpsTmpRelFtMU9Ua0YxYjJ0CiAgSVJYVkhlakZXWHpZd1ZIR
  nlVQW9nSUVVM1dWa3RRbFpCVFU4MVVrMVBjVVIzUjNVM1dGOXhRU0o5Zlgwc0MKIC
  BpQWdJQ0FpVTJsbmJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxQ1N
  6VXRTVkkwVXkweVIwdAogIFdMVVpJVWxjdFFrWkpOUzFTVUZKRkxVVkdUMFVpTEFv
  Z0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljCiAgeUk2SUhzS0lDQWdJQ0FnS
  UNBaVVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjblkKIC
  BpT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSXdOVzV
  EV0V4d1NqbDFOamgzUQogIDJ0MWRUUktXalZ4VHpSMGQwbzNjVFZqYVdkUE9FSnha
  ek56WDJaMmNYWkxjbDlTZVZrMkNpQWdNVzUzWjJwCiAgSVMyRnpaMDl3V1dGeFkwU
  lhjelk0ZVdkQkluMTlmU3dLSUNBZ0lDSkJkWFJvWlc1MGFXTmhkR2x2YmlJNkkKIC
  BIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlJGZE1MVk5NTkVJdFMxZERWeTFYTTFoVkx
  UWkpTMW90VVVaUFZTMQogIEJSVmRhSWl3S0lDQWdJQ0FnSWxCMVlteHBZMUJoY21G
  dFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZCiAgbXhwWTB0bGVVVkRSRWdpT
  2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0lsZzBORGdpTEFvZ0lDQWdJQ0EKIC
  BnSUNBZ0lsQjFZbXhwWXlJNklDSjBkVGMwUVZaTFlVcDFaR1JtTTFKRWNtWjBhV0k
  wYTJWdE9WTjRNR0UzYwogIHpBdFFYVktVek5SYkVoSWMxZDZWbGxXVG1aS0NpQWdS
  MGMzV0Y5Tk4xZEtSbHBFYUZReFRqVTBZVVU0WkZkCiAgQkluMTlmWDE5IiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6IC
  JTNTEyIiwKICAgICAgICAgICAgImtpZCI6ICJNQUEzLUJRUFotV1dPNC03UTVCLVA
  3QUgtRlk1Qy1BVE1EIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJ2T3VmZENC
  XzlIVDZJOGFhclh2bW1PeU5TbC13LXh5SjlsRGpBRUU3NzY3OTN2bDFMCiAga0VGW
  XNCNWJoNnlkVzZpdGZ4N3d0eUk1aDJBWWFoNEJvc0tCUGVHNXFmSVZYMGJEX0JIek
  gzd21fcFlUaHQKICBwWlJHVWRfQ0xsR0l5cVppLWRqNnByYS1SYXRvQ0RiQmRLSWd
  QQ1RJQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJscmNWZ0FseGl3TTdp
  YWNsbUI0bFFPLWQxcUlZV29pbEdhMkFueEFxVkpPU04KICBIdGM4TkRabkd3VXlnN
  mI2bFpsem9WZ1FSTmdPZEdRYVZxVzZzTmYxUSJ9XSwKICAgICJDbGllbnROb25jZS
  I6ICJnWkZIMUxaTm9BQ20wLXgwdGcyOHlBIiwKICAgICJQaW5JZCI6ICJBQ0tKLUJ
  LQjMtSjc3Qi1HN0haLURGS1MtRTI2TC1OSFhXIiwKICAgICJQaW5XaXRuZXNzIjog
  Imh2Nnh2TlhPc3BBOU1ONFlWa05iNThQNUJ3cjFXQ3k1T0E2Z3RQeHkwTHFQLV9sd
  gogIFJlSFNwMUQ1TXViUHRNWW5yU3JFY0dlYlFyZXZCR0I5Nm5na1pnIiwKICAgIC
  JBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"
      ],
    "ServerNonce":"TxNcq2rNIK8BgGbwmyCcBw",
    "Witness":"HS22-VO5M-JAG4-RQT4-ROHX-PERK-YYCW"}}
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
<rsp>MessageID: HS22-VO5M-JAG4-RQT4-ROHX-PERK-YYCW
        Connection Request::
        MessageID: HS22-VO5M-JAG4-RQT4-ROHX-PERK-YYCW
        To:  From: 
        Device:  MAA3-BQPZ-WWO4-7Q5B-P7AH-FY5C-ATMD
        Witness: HS22-VO5M-JAG4-RQT4-ROHX-PERK-YYCW
MessageID: NDBB-CHFG-OWNI-2WWK-RJI2-KMF7-6AW7
        Confirmation Request::
        MessageID: NDBB-CHFG-OWNI-2WWK-RJI2-KMF7-6AW7
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
    "MessageId":"MCXK-BPYI-YM5Y-N4LL-SFZV-FXIC-AHX2",
    "Result":"Accept",
    "CatalogedDevice":{
      "DeviceUdf":"MAA3-BQPZ-WWO4-7Q5B-P7AH-FY5C-ATMD",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQU1RLUVURUEt
  SkJMMy02VUtFLUxSTlQtREdDMy1PSURGIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyMi0wNC0yMFQxNjoxNzoxN1oifQ"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJl
  IjogewogICAgICAiVWRmIjogIk1BTVEtRVRFQS1KQkwzLTZVS0UtTFJOVC1ER0MzL
  U9JREYiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibG
  ljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJuaTg1UWphTTh3VTV2Um9LbXdueEQwRjljNFNLMzAzTWswR2Fk
  NVdsSjhoZ0JpWVd3OW9OCiAgem1pMzJzdzhYQW1lcjZVTTBTb1RjMjRBIn19fSwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2
  VydmljZVVkZiI6ICJNRFNLLUVVSFMtUVhHRC1MS09GLUFWQzctVjJSSC1MVjZaIiw
  KICAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1CWlAtV1pB
  Wi1CNktRLU1ZWVAtSDdLRC1WVkJBLTdUNlUiLAogICAgICAiUHVibGljUGFyYW1ld
  GVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcn
  YiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogInRSODVSQ3FXdjgtWDVCazB
  OVTRFVmxqUUZKNTg1Rk5FM1p3eVd6WFNWdEpIaXgwRlo3aloKICBRN3hnOXV1cnc4
  S09LbDVNMFVXN0xMT0EifX19LAogICAgIkFkbWluaXN0cmF0b3JTaWduYXR1cmUiO
  iB7CiAgICAgICJVZGYiOiAiTUJEVi1YWE5ILTJSVUItUkJNWi01Tkc3LUwzQ0QtM1
  RIViIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWN
  LZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAi
  UHVibGljIjogIkhVd040UlZoR2N6RmxPbTJiRGNldnZWWXlkNmdqZHEzM1FxVjhVc
  TM5ZEdhc1J6UW45X1AKICBWZ0NCUklfOE1qaXZlclRLZGFhRUkzMkEifX19LAogIC
  AgIkNvbW1vbkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTURQUi1GSlZXLUd
  LNVotMkxKQS1MTVlWLVhTQ0gtSEUyQyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJz
  IjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6I
  CJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiNTVqVWttcW4zZ3dHMGIySHpEVn
  UzSGxmNXNPNkdnVmxqX3ZhWUZ3QUVrc0RjTXkzd3l2VQogIHd0OW9qa2VVS1Q2MzA
  0RHdmcmgtVXc4QSJ9fX0sCiAgICAiQ29tbW9uQXV0aGVudGljYXRpb24iOiB7CiAg
  ICAgICJVZGYiOiAiTUJWSS1FV0xPLUVJN0otT1ZBSy1HR1pILTZZSFctWkpTVSIsC
  iAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0
  RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWM
  iOiAiZlRVM1RlQjEtN0s4U1pwbzR0UXhaUHBKQWItX2QzTklkSmhsa3hXYWlab2dK
  UkVLOWFkUAogIGY5S25zNW1xcjExVVRUb0lNaHpmZEphQSJ9fX0sCiAgICAiQ29tb
  W9uU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1BTVAtQlg0Ry1BS0syLVlIUE
  EtSVhKVi1aMktWLVVYQlciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgi
  LAogICAgICAgICAgIlB1YmxpYyI6ICJZNi1EMkRiYktsYVZYdkc1WlF3ZUxkNV9rU
  DFFQ0FDUjQwYkRtcGctWTRLczkyRk5lLXV5CiAgc1dVck1fTG1RS09JUGpqcjVMOE
  5PQkVBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF",
              "signature":"FOqGS7sd-l-iXeW0NnWOIUbmJxw0SLBHk_F4VY
  ya8AIu23JVKebgbH-MtSAK_-0FVuXyWcRUdT8AsHeGljsGe7Y9tN4q_NT8tIASs9Z
  sZa4HXUyAB3vOzMuSO6wi5bHehc-zWhkEPZhvdiBMcizkODYA"}
            ],
          "PayloadDigest":"pbnx3FGeWuZWOrANRD5vo3UYnkZRpHGmpLwSWV
  JnsNZ4SFe4qVn-hfNrZ557hnJhp4aD7EN2p6B7IVNMmuK_9w"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MAA3-BQPZ-WWO4-7Q5B-P7AH-FY5C-ATMD",
          "dig":"S512",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQUEzLUJRUFot
  V1dPNC03UTVCLVA3QUgtRlk1Qy1BVE1EIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDIyLTA0LTIwVDE2OjE3OjUxWiJ9"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1
  cmUiOiB7CiAgICAgICJVZGYiOiAiTUFBMy1CUVBaLVdXTzQtN1E1Qi1QN0FILUZZN
  UMtQVRNRCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdW
  JsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICA
  gICAiUHVibGljIjogIkU1ZUs0cUkzTVlCeDV4cHR6Y254cEhabnZNQWpTbnJIRjhB
  bmJ5cE4tWTZpZlVHblNfTlQKICBfaXFacmdteURLRERDaUFXSkU0R3A4VUEifX19L
  AogICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUFMVy1RWFg0LUlBRE
  UtQTRaWS1HUkZWLTdGUlYtNk5NWiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjo
  gewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJY
  NDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiWUZ3WmJ6RkNwcmxETk5qSkVsOE5iU
  DlBcVZlNjQzQm1OTkF1b2tIRXVHejFWXzYwVHFyUAogIEU3WVktQlZBTU81Uk1PcU
  R3R3U3WF9xQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1
  CSzUtSVI0Uy0yR0tWLUZIUlctQkZJNS1SUFJFLUVGT0UiLAogICAgICAiUHVibGlj
  UGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgI
  CAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICIwNW5DWExwSj
  l1Njh3Q2t1dTRKWjVxTzR0d0o3cTVjaWdPOEJxZzNzX2Z2cXZLcl9SeVk2CiAgMW5
  3Z2pIS2FzZ09wWWFxY0RXczY4eWdBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6
  IHsKICAgICAgIlVkZiI6ICJNRFdMLVNMNEItS1dDVy1XM1hVLTZJS1otUUZPVS1BR
  VdaIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0
  tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB
  1YmxpYyI6ICJ0dTc0QVZLYUp1ZGRmM1JEcmZ0aWI0a2VtOVN4MGE3czAtQXVKUzNR
  bEhIc1d6VllWTmZKCiAgR0c3WF9NN1dKRlpEaFQxTjU0YUU4ZFdBIn19fX19",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MAA3-BQPZ-WWO4-7Q5B-P7AH-FY5C-ATMD",
              "signature":"vOufdCB_9HT6I8aarXvmmOyNSl-w-xyJ9lDjAE
  E776793vl1LkEFYsB5bh6ydW6itfx7wtyI5h2AYah4BosKBPeG5qfIVX0bD_BHzH3
  wm_pYThtpZRGUd_CLlGIyqZi-dj6pra-RatoCDbBdKIgPCTIA"}
            ],
          "PayloadDigest":"lrcVgAlxiwM7iaclmB4lQO-d1qIYWoilGa2Anx
  AqVJOSNHtc8NDZnGwUyg6b6lZlzoVgQRNgOdGQaVqW6sNf1Q"}
        ],
      "EnvelopedConnectionAddress":[{
          "dig":"S512"},
        "e7QRQ29ubmVjdGlvbkFkZHJlc3N7tA5BdXRoZW50aWNhdGlvbnu0EFB1
  YmxpY1BhcmFtZXRlcnN7tA1QdWJsaWNLZXlFQ0RIe7QDY3J2gARYNDQ4tAZQdWJsa
  WOIOSNDtOvoZdilp0s3BTEoNwiSeNFDS6fgsm1L562PMYIp9BvcFfw3bmZ5u3e56H
  OMu23pigwo4Xw5AH19fbQHQWNjb3VudIARYWxpY2VAZXhhbXBsZS5jb219fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBDV-XXNH-2RUB-RBMZ-5NG7-L3CD-3THV",
              "signature":"lOsc7e_m2hYgaUEGWInfYztPwhpICudfCGR1H2
  UpRV0KH0SwVpYTnIWX-IuYXMo995PmWEDtYUiAjNmxO-rcC2BhHIW_BGU4YAtVZI8
  cNAgvHOFmDe_wHzEoHce8OruvdQ-lbcZd_fuVjkdHundi1h4A"}
            ]}
        ],
      "EnvelopedConnectionService":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIyLTA0LTIwVDE2OjE3OjUyWiJ9"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tA5BdXRoZW50aWNhdGlvbnu0A1Vk
  ZoAiTUQ0TS1FTEozLUVNN0ItVlZGRC1KRFBCLTdHT1AtT1FJS7QQUHVibGljUGFyY
  W1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1YmxpY4g5I0O06-
  hl2KWnSzcFMSg3CJJ40UNLp-CybUvnrY8xgin0G9wV_DduZnm7d7noc4y7bemKDCj
  hfDkAfX19fX0",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBDV-XXNH-2RUB-RBMZ-5NG7-L3CD-3THV",
              "signature":"wzlcBCqylNLld9M66FWuY2qaUmUarO7Yam6ERb
  iZ0A-Ugo4CALcEVTKLkM8TCy1wApS4mtYJaYAALgDjm-swIPwu2XW1yBWJG-RnLEQ
  ydgSh6d0q6Rt3owHgYKDtzrSiJ_byiDUC7BtdDgz9RSqkbQ8A"}
            ],
          "PayloadDigest":"vYf454z3M4ZljOqIwzvMaVDSbyD-kQ3FZJRD6C
  T_oYFy7fryxi-JQTp9rWU2h8UcsjgA1VS8jeF7ZY3cjYl2Uw"}
        ],
      "EnvelopedConnectionDevice":[{
          "dig":"S512",
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjItMDQtMjBUMTY6MTc6NTJaIn0"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0DkF1dGhlbnRpY2F0aW9ue7QDVWRm
  gCJNRDRNLUVMSjMtRU03Qi1WVkZELUpEUEItN0dPUC1PUUlLtBBQdWJsaWNQYXJhb
  WV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibGljiDkjQ7Tr6G
  XYpadLNwUxKDcIknjRQ0un4LJtS-etjzGCKfQb3BX8N25mebt3uehzjLtt6YoMKOF
  8OQB9fX20BVJvbGVzW4AJdGhyZXNob2xkXbQJU2lnbmF0dXJle7QDVWRmgCJNQkFD
  LTVSVU4tNVpZSC1CWVJILVJGTE0tT01NSi1ZTUZStBBQdWJsaWNQYXJhbWV0ZXJze
  7QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0NDi0BlB1YmxpY4g5qTxrxXDgAwIc2r
  ULk3yjVLsqjDv6cd3CoPyhfB2g2yS9mG2BYN3cHptX-5wjgPksRW2lrLGSt2UAfX1
  9tApFbmNyeXB0aW9ue7QDVWRmgCJNQllQLTJRTkctSUkzNC1NVkJKLUUzREQtSk1V
  Uy1LUlUztBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEW
  DQ0OLQGUHVibGljiDn4tysVgdXulShZAzpKeVaEPT6YI9YrlRwCMN0xnx8czTX8Zx
  73E6j5muo-DFWjZRmvT5f_Ma-m_YB9fX19fQ",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBDV-XXNH-2RUB-RBMZ-5NG7-L3CD-3THV",
              "signature":"xm5EIDcUvKJkP3cpdiV85mPygKSW4C_4P440Fw
  oOgzA-Y1IPxh1n_uYmx1Rr6FH7SrTDAZgkgcQAIl17pmwnTt6z-14iolJjKanphGO
  W9ukYzFqJhISIH9IqS0YZFYAxAR04zgZRnVzgX-wPPDFmVzcA"}
            ],
          "PayloadDigest":"k8kjkIqoYDGcg-kLa6UkLuIEP1bL15gkmUUCf7
  bMYXYbC-LcymtnjLMqiUOpWjXPlPCwZkeG6iUmvd3OZoktuw"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQP-6TAN-BTZW-ASDU-VEC6-MFRR-IJWG",
          "Salt":"tXA2e3ZNixmurZ-it2J6KA",
          "recipients":[{
              "kid":"MALW-QXX4-IADE-A4ZY-GRFV-7FRV-6NMZ",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"-QKmVKReKKmKkvdonFRJAnEGvT1Qgp8e0_qZq
  -UE0GkEi8zglCyuJ0ai8nKlRedPLagxu_HodpWA"}},
              "wmk":"XzQkcZcOZtfC3N1gWPL3pHVc7Qt_hUHjxRD8xioD0qk_
  O5XaBG_xNg"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDIyLTA0LTIwVDE2OjE3OjUyWiJ9"},
        "E0DRm1t6ESGAXqKtSTn93qShYVVWCBcH1mlGJNasyCsIU8UQukuGP-ih
  V3MeXe9bgq-0_E4yH-53437MTWM_uF33wjPTBexXgvr7w0pM4rZ7YVKOmyJ2vo5-x
  PgAAePJwfRCbsyvGIsyN8YW-c8PifFkWntFh4Es_cWnKw-tXjeMcdWjtu1KJxekNQ
  Cl1wxiMk7HIthQtCQwk2A-JWXQWaXCgOmKtjcl-1V4hR52jpUSiYuLNsRXbXJAkrN
  rZFaG",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBDV-XXNH-2RUB-RBMZ-5NG7-L3CD-3THV",
              "signature":"nay6TKbcxU0VmQ7rJVoN_m89pMMlpnKl1lC_-N
  OzKT2mZDPgr7Q5MNwXWigJOngiHcpb_YH2hsuAsVpmwHem5gcuJ378S9UOwKXmgxg
  WKLwkDsAEr3IRqd0LTF0yWqwJ7RpVo-BokZR9xDg0JJxbhyUA",
              "witness":"8cKBTOqU3sGJf_4c7OrpCwar8KKIu6nnw2cvXf3a
  Uzw"}
            ],
          "PayloadDigest":"pDEQGRMpuD0EDYGR_-oxzvovyaQG_uZA9nqexr
  5e8pC1Ha0yu_4pxuQQhAJep2SEfVR2Zs4vqcgsnFY8O5D_3A"}
        ],
      "EnvelopedActivationCommon":[{
          "enc":"A256CBC",
          "dig":"S512",
          "kid":"EBQA-ZOOA-J2XX-OHXS-NQHE-ILCE-25HL",
          "Salt":"He9EoaV4uTzQ25Nsg_ln8Q",
          "recipients":[{
              "kid":"MBYP-2QNG-II34-MVBJ-E3DD-JMUS-KRU3",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"GxSFbVOVBE0DIipxDZtGHwxcX8GSewnZPexv0
  ceJMTZEgU1etKaS34ZQ5xzgNvnMLo5sw0xl__uA"}},
              "wmk":"gkANisn2V3yx3tvibNs7qix0IqlQKuRUaHDp-VNBxbr_
  u9u_4ZdnAw"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQ29tbW9uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjItMDQtMjBUMTY6MTc6NTJaIn0"},
        "9oiSbsWFv4Si3bH3IBrWJGWRf7lVk9eiGoPh2exMS7FRERkTdonOFcp_
  7DtkVJ8VfArm-zOMFKQL-0MnNFOmUupHH-1v-8nKegFPOKCApz8ApB6vOlOWdaExm
  TKGmKuXoikgBhzJGPD18eeTxEGrPRtCNnQJ4eRMbY45f4p5bFZ0x02WFa53-tSJK3
  zFnNcswsAMOvlc8bvUcQ7qUNhrju9QlV7-x5AzPyUaXOIXrHLE1G6sbUueaqKSTgn
  8hTmcYpJ3MiCkz7rSPwMghsf9qyRdWOIEQ879LAE-yZuSF7hkNeMdNICvn6bA_T9b
  2WRzZeVgES9fZVJJOPb1DlQxcmXRuwmj4WcuHp-wrW0xgjF1a3GjyEqFemHFUMOJw
  h1QLyLUOrdHfuCN6Er2KjBvbH1p5fNBz7Nym-NcDlSZbUy-TmjDfLW4HCCn2pBXyl
  uXxNTtDRryyUE9Z1q7HV9PhOO3HURvDflLRPXQLSrrzuZwSPotfbRA-WymJtLuBtF
  IOBLJEx09LvqK-XyIPJdk9ari86PyKF_wCoh1ps1fLDN4oc5ko3Qb_7iBJRYiNMnJ
  dJ9lCPDFNMPUMkOK50xa-jRHlX2bUxM4Rycc9T3vsOQqq5k30h18czw6wBgb9TzV_
  33wYqh01lqcEgrG0uXVU057gvEe9-2_-GuaJgiqpYaceo3i9E0IBMsrmUXWhMpfl4
  rESUjHN3pSgRPDjrfPyHKW4MXuETj8MN6RBuPRdwQW0oBk9f9NpnOKFxQqWkRXVNW
  c3Z2Yi-iu77A_5QrOQvIocXhcuC8J4It4wgt6HE18EBhrEGo0htYiXMllDQ8oAAhk
  SceNWzrulxjmz1D0lSA4C5J-km9MsW8IjzJgaGwENj0al9m8E5mULlZmccLBlHQYp
  BdAfxEZybuuELs9v3sB9CE6TtusJrTgYFkR-WITknMIALGF7dcqWcv-i3k-NqOkIp
  XIVIvjyJWyfbdnJ8ocrGA-xZLNCkoxEJC4TBW0Fqh1cWmM2ENOjSfQ1o1yQm_5MMW
  _P5OLpvAjD71WqPJeVsjOkVHQqPtZG8oQIeJQ7-QtTPFEVfrvroNlXdvvyLYWq4ma
  EzG0e4ZX_wNe37lWq_pdzpCNKNCTLaUbc_z_SoVqU7RNNuwAbBqXG2wVU2LU2VSrU
  qcRKV1sitN4TL9YuVOeH6EUZ42koHTSRhrbHgkbsemh6lc0G_XLJGIcETxmBLi9k4
  nriSSeBOb4L_GOoy8uo9GRDzdOFan-GomVDUa8cIQXx0BJ52V_xuqjx3jBHQcsbTX
  8GtIOl4072HbcNryM6z9k6nVxKgcbRlj_feDcDf1-KXT6FC1ojPnGAr1gL8C8mZYv
  657H5rmGbf-dsGuixfW1zyP4IxOTzwMTYv6E4o6YvTPydm1sEHleshXIn-T3UUNGX
  bhIdvcsKNaFLukS8-rYpf-1ms8_U7qyn1na8sff7K3P3d7biLZrsIdoILBqveRdCI
  2irOBE1oobNpezWMHMO4j5jN1ihhvky-um112AwKIcUvgwtlg-7wCkgcEO54FNbDh
  NP2yf7-BZI-NPlB_chFXiyxMObXyyUbTzZ8vV0AjBsZ3bzshR9m4fN2agluqfFg1r
  9fsZr_WIr-bvHk2MF11v-hp_4NF6Ga9kppgfHYZr0Cdnff2-ocP8e5kzD4ybYmqvZ
  dGm22AbUZP3UKmK4G-zM80AHJJQoCxfVYyETaEcSRyhyiEs9sJHIKvSUO2VE9nmkb
  h0ZAH1TUdWJnBzmW4cmGA5g2CpD-4oiF_4XFf7i7oIoz_rrgVTWQE_p0E9fJmo_Mv
  lbSb7WmOzTnaFBgMCDRyZDTcsjXpkHX9n0FLDVNbnVcMvsV4DaP6R773CE3V2YowL
  JYLiu3BkTUf8yKLrPEk1vVH1nyBk-TVPodAlqOzEOVyfSDG3KxxE5l1k553ENPlys
  C-O4rmrkraKhh9tz51i6Uk86oAkzUztwrHVrvrg4vWIIqNKW6a0pH6ITGCAGu72qW
  8RfCE8xqQrG0Xq2gWKopAIqb-jtVrY41sEge3Tn0N9DxgKu_7FJovyA2UO5Sq_-BI
  ZzY28tpgnYnVsz5zR2JReacy1rBthkI18_iOSUHPqN87ltfWLWWtiehHWG_AellNs
  Ou6_o1jsx5iRkI1ppPXio7EKpNd7gISZaT2iCaWylcrxCQPHu_TDmGDhCE93WF6pa
  mfRYU4gKN1aAVIcJLSJSJlp7k72AxJcKFfyxLvBdJZeXZ_JbpWLyprX1nayuuMYv9
  rAQDiAN3MuoyzwzyTyOecM0dwK4RLADs9QsriTVvTVLUGlw-qV2wGua66JqsMIF5B
  PEalc1G3_K-hV_VrPKWxCOCtBB8-Y0qJcUMjRFXlGElwZ8VrANX7b9_ynEUjg9H1l
  _1leuw1yay2iyqEw369HNC_jcGbi6MoqyIR4uVuyI59nWY5VXI7vn8sYqNBr8zuZR
  MJY1yqcWvoUoeiuHZpU5yxOrSdMA-iGyy5NqtBrMdmP42co8xLCj1SjXi9XcpjP8N
  d3Z695iumU8YEOOY6fm6_EfDA390e8X4AJZ25FkvUPBI6YQT8NR0lqZrgwIF1FaPj
  Wlk9M3IrGMlrnH2FJDH-X8rEFCJJShxSD6sipr-eCTATgMIdPteXWgHo2WAVGrBwd
  pHJ3lQsAIju3fy7TEto45RveVo2mTIrxdqvlddiGehLNMmm-0i_TlIYe8TcIorP8m
  c6lOhL8InRrCLruR_PAH-gbwWnfZ1qBviaRnoSzoAyyVm9Q443kF5KxC-If_Hj5Jj
  TEqRJm7PADg2h44rFrz3TOHNCqDnVOxaj_tHB_L9l5sxbufkoMBxfT9DVbr8ao8WO
  yq-g1l0vk38aG5s3Bq7T5XVvoawcxE2030yQ2vPKUSj6XFBijpxwXWTN4_LByHt3_
  oRWRngOIjV2yvjSodZjPn4lwlPhpkvAwVWHeGdoS1w86itxSs5KgDKzHL7jWbMRxi
  1-1pD689M5pHPsX5ok61ik0q1N3eBA3InJKFfQWeycimqv7OxsxC5HtDP7y9ny176
  Z5nEIDr1M6OzQY19bKGaPTLCgjLznBuA744LgMMZSJEQeG2G0u_Li0hyWFJ8b7HrZ
  N-KcuXjsmeuNIJEObEzICz6JeXQeIWWRwk_W6TTOfAT8SO6K-ir11NsxPAt7DKFCp
  mqGAeENrk6TL8Lvb47l1tCLAprBX2BXa9zITPPhOrxkChxBJdwNH0K8Y8ZE0tCYpW
  8E5PvRKdZt7R7CnFK4jzqM0MHwEdRU9QHXhSZC2LsYxMoAWlI4ukmwtJJaXFdnfJR
  jBB7S_7G9iaEcIOU5nBMk1hDfEH9cQtHvW6ata5ky6DBx6fEyFxilROAC2GMPv3ye
  FyjJcX6sf7ryCrqp2CY5cgXAIk95L8_QXwDX1TmHkj2v-0nojlya6ZIHyHF89wUhp
  FEY8DalGkuetrXut7CzJeX969Gb0Qm0Ij9KCp5gFiwXgoPpbY7GUNSseflN8JjNOf
  X6k_8PXtXB0FyCSsjQuU-C-OOPXJTdSsAzDGV-QB2juuw0fnIXpvfQNqbUBKy13jm
  zeU9V1BkjzelPtximZsR5Ml9m13KvrV7MV9VHtU2l0VHIsUmZYW7bojOoPhyItTtB
  _ED7wgR9Z5NB0rpAwHE56w45SemmYTg7nZM9AoZuqyQSmulaYJHfPAmkCDhVloH-F
  DcoYYwK6LI3ibxLM6zhRgJzb9-VubSdYmrhi1sYoKFsBTkn5D1dV6oympGUx45uBL
  -DG-lYAGS199dq3K91kyOFEZ1tgG1BBKPlDO5ZB7rzLQWdUe-DRq84yq3qJf2Qej-
  nU1K4MsqFvbEsgtWVjZ5XT4Nmu9QJxMwFUzY8PMVK34NkOqGepyUo9zXf-2PAGGAy
  45TQmwNEvitjOc96uMTDJkf4nZINvH0B0BsTftPyO1_QYuikC2qRv3waCZl3W6-R9
  bQpKiTp2AwmmDZs9RBGes7EVx3Av9Fxf06qbAOtXH_uLDl9gbHnwSKV7Sr3Z7vCYH
  -iXjhzOchYf0xCysXPV_pJBueYEJiu6rgRxfjZ-IkXuIbpU4w0kX3f-wnkyZc26L-
  4zuf-liB3x1oxTe0ww1Sid5sceH1cB5JBoEAofo5ciRX84Lropx43mnOM8wQuEIUh
  8ST6MsLxdfVIM_X7gxhyQ2hgOoluiFOQX28VtlQY3HmgjHTKWqma3rBOpkmDtkzDh
  9JY11fQ0vYYzYWGg8X0iU24X8dawj6xf5dE7_E1ejEVsTrD2FZT0WropndhyEjg5G
  fMCYsnnh9V0jU1nHNNtNRFTvpLj-wOgLRGKeU_hZ65gHsT3N4PoIPWSuaD_uNkrYm
  FreVJngAVn-7KsRVXphZ38M-tDvoUct5-63FOEcuzKT-EYrNtAO5o3Akctl3SpaOV
  6YLkyvrwycxw0nGew-XWvnfGcCi7srh27T4h01zc7A3oF6hbJTUFBULFokjVzP7Nj
  3iGW0gOUHMONLrdItB8HSOHXIN8H-c7YI7mZQqNpS6plMgACbhKy9IAYBs9JruoOb
  sCsogur8rKvTAmZQM9m-sfn6hEv2ML1NktzZOCJiJ5xugc_zOyOQgCxpWMs7Qxui5
  GaDh4c7je6WytdnPpv1HhW_CUYkc_EJKnL4GKf0-D0Y3KHdhvVCMefkOQ0ZNplR25
  QtCJs_Mj5ODN1p-2XQWsP-88AwZLT-7v70CNMmjpvYYkYkNf1LPVYFcsfkOyLZIzz
  pebJHbRl07i5FnmKrMBHRSZZR0UChs66t-fMi_fn6CQJNMw-XiMJqcWeqLPfy48On
  ECAjiZ18_MPiHfJkyNZzOzeX4eDNjDBFf0lkhdeS-DiQGhAHW9CxJvP5S2vjdBPVx
  GaDaJNpI3x_EOjee8JS-SHvg4Ib0Kwzg1h288_VWFrXbex3WLGjgA6vAMCy8dZbgJ
  _vcO3G-ItqtStRSeZToL4cr28xFBR8CGi4YX5eb-l6ddU5CE5SLQLgwpbNjhe4vTd
  JW0jYShp9sja26AUXH9sNah7vCbdAULCUmMvU_j5sbur04gecWuiwzh5QRGQ4XF4p
  j9Sy4CI1qF28BYrNBtEAymGEukDG8Acx6KUNYNCqoFKTF3ySOSCobyuWe8JtSkUDi
  yRnkLUTEPo-5PeRAHxbc1e2fBPSYbrshKA3av_2BZggq1uREg0NMrff9Cr2-MUwgI
  MUVwpabycISEPomWhMDsx5CG9AW8EWd5rzAM4ddpqSuI1tyk5C8_7SdtgXg2IvVmR
  fcH2BTIYFxhkxoxv-Bmnt2OylrRkn2P_IuUSiR_eeFFhi5GoLK0iLDgWFRtOSpbU2
  iKWYgbgcTzQrairEGstsN1G2HiLRWeEsSXH1FDT9aA3mNNmYArz2DY6BObLUonAls
  xqSvYbCk0rjy249i42AnT6qYcS2puYxmjvjONSTCaH4q9bVzYei155Y3Qb3siB9HE
  XHVimsdP4Lr4AutyZExQxiImmebV4T23ZDLx5MFu7W040YpD36MszhUcD_4QuB60H
  YeU9SFF9g2KK7CbWGFBaJf25QdYaIAMdKk69gFpPhA3V-I3_fsfJvbHyWDKLeX__6
  Q0hHXaZ9oCt3EG4563n6GE32YIb8_15zYrQBDRJD3vyjzCo2w3bia_mHMRP4cxZ_E
  CmiLqIWIPkFnuA5mezhxpWIiH7-WQf7RzUTWyiX6Ph4730RMPvZFGYV50qAyLDeII
  jxudCLUfSaZH0UoZoLzijJT2pMQIPwZPnUJS62pfRQBmJtaTq-v5xOLwBwaSwJA5n
  PlXLyd4d2zjOaR0wm2rE0ol36amQ86Usl_vA8zKBQm1p12icYK3mI8zHIYMHNqGRw
  _uu0_1WERWT0kbBn2a04vAeYKSeHOlOSGzd31hn2dpQBYODMXUKYsroF4p_40oTfK
  yZNJVRNCNFSsz8eprIRp1kDN--3d5c5ybU9UUQYJArn0-16_NQcieBdC3SYQpXO_M
  wk1WEFWUkFUFJJV3KFKd8iKw_igENGbjHKKcsPQtl5XV2NLNI2Y5oSctspJoQWJJW
  DtMBN1FibbuFpDCB2ojmsPcWWc-zivUAFQbkJxFHrYoBIGCA_Wunjk6RxMFpl-BaB
  YtXVNKncTdsa06l3CujNDSFpe7-gN1SE6Znf6yASnPJjWFsdnXl_59RcRRI7vTpSe
  AAgAwDAEguwoHVM51D66grC66EpcJ9S-XAvAIs0b_87GjEMlV7DQlFF5TXzu5XCc-
  gfMKRhKJ4-xf9sKrZ4csiXughoHU3VnCp4xh4csDJY2gX5fcLdGuNFE_OGW7Jrq9W
  bfsGh9KwFkvzxBPI1QvkxMw1J6_EiattoZdKLL156wdhl9mRiOYqjSBKyUCaZqPSd
  oTRg4kkhHSRdlhI_GGomNK1VZ_8G2aoQNO3eKB4twAdHQwXFfbyhBaLIXJ3pJ_hPz
  PvJbKDO_lqmXd8S4yS1RVkQoCUe1pPXQNMB9JyvKER7lXxmqGZOCeuMdkU1rwkm2X
  3voSiqkrODcYPZin--xC0Lb2rxN_DZ-oP2Lh6qaucOSTRpW1k15V_E8nVa-FRZgYF
  4jr_E4dsZZ2XvVoG4Uv7MFRwF4y87S1rrqs3jamWOKaJdWfRquQkCLktv_9tm8vrj
  HDPBNU2UVvT60URQ2Tii5NHu8y4DSWBq95I00_6uu-BFjpjFiRDOAz1zy-CEuGHaa
  EqqUfuV6pShGCvc8xDnibW3Jh6MIvbN2IduOvjRGDKsCvSehBRENdN9m7Db6AdHVj
  1hbmV1cUv5LJTMYZHKUu2LUE_aLaSdui-Cbw0R6U4wLtC5GxLsTn0nv-9egZ_oYeZ
  0sne-QkZcALn_ETKdLtyDIuPvEEcvYR9awfUS8JJv5BqBUdTbRmPMqgn6u6vtSa3v
  Q7Eu1anOb6eZsJIAgI9guF316r-_KSlQLxyZG7sTmud025TtLpZQRuo_h-EyEfi9a
  njACuIV5C_cmPT4DpKooVdy2RwIyY7r1OvsPeYAM5rVWkbDUJ4QVWtrHphvUvK6i0
  4S9fDOlqgo_VxMopln_du0Jmf9MQKJC0oTrlN8Ng0a6fhqPmJc1zvFSl42aYr1KSv
  p_LF_dFwgoheTxykI_h4CNG6MXP-jvP1OkVamEYhmR8W0SWqSDGpwgNalFjZpRYFi
  cLrAz9CCFSsOVg1DP2gFWovm2hDXcXjp0rCJ9GrNrJLx0LcJzyE1UUardcG0nOgTs
  j25vcNBg5QnO7uvjH9USW5KcYLIlEWg-3KWFvKZHiP7aJ8pqOgtQdPMDMhKk0U3vu
  qW-nBm9o0baM_CvXi_MGvr3asA2bAT2gi7z8V3JAnt_p-mROZfCS1jNW9S3Lz8Tes
  Cf1zMNZfEeX0ggMIHbTexR0edviwhBc9qR1b6oSID2dOnLDhZop2Ncp8uYx0qYTVS
  ZwnmId-5xOlEr8njw0HgyJNqkRJqP5z2fCZRIRpY_zWMxxgD1JK4q1IeB7YE-BsFh
  LT6IV4wdk8NQRiMJCVps593Spu3W835Zhto0GwI8lYnfjRoB6_e4QlQvyVWqeUVSW
  qmZ0QWQjTPpp1UZSyD4qRVO_mI3TFHe83EMj56nNj_UgFWjXAOGXj16I0C1eiqa0i
  9R5EwcPI_lHKUuI8VNTh5eWqBO49CRwO-uf_r3Q-irCnqXLhSxXjWvcCfWnXGIup0
  gWzQixjVkta08piEh0l9PS4TyRB0Yk-IVe6jdrtWNhCCrYmkoyBZFgPvjvDoPYibO
  fm0P6ITI7y4fa8N-Z5c6QDghkh0qOHzfGBJYs-pvXrRttHuS3yIn7nrO2jAZoDLQb
  S1iior4jv_SRZb0KSf8NjkM0lyVfgGVG3y2llan46tg3RYV47ppcPXGlVOsMaxI8I
  yyAw3FgmNFOZpcOnfjDD8edKtZs7QA2NngEn82D2Pxw8a2cX1YFun7UpQhveb8NKL
  5Om3C4hMKDT-zqBKn09iyQDLulRMlhKBpjowJfPVNMnDfweKX6v2LXBvl0Gn0AKUi
  Z2MXuffhj8XcdfH0aCO6YjeDSND-hX1PRLTzOkEzXRQNgJuTbPmAxxZkVQDEmsKVB
  NXf4SXqvz2yOs5K_hcxpmAjD-zRYCqHmKUEQdpBgEbAY_AOM1H8p-AzSfgLnw4LT5
  c-VijUAKHjDg6dP8xB1pdczR1Z_qLJI68AsGaTnjjQ6fVYbmijJwHCY-EIC9lFZrQ
  ysuutS-pOjc17U1X49yNsw_ZpGOZdtnqs3wMEFtEgSWFB8os1rFmxj5tIJfHSabkO
  O04Px03v8BVSjzBYwNpukGsnNM3_tMxNajqlE0ygrMqQjZzWGbt1CHiWAfOY8dyNS
  SOLKsidSQ12CmR1q52r-_MS90eo2ROCyzbwLsRvY45HKBrd4Pdl0VHsp5KY0oFFy9
  yAsg7ZBbq6yyngqZOx9Gatxv1U4XGGsFe--wxhwUzXe-2vYg-QMKUFcOQWXTGs0bb
  1bAlLpY4I3eimsrUxaZniw-2MWk5wQxJM8oePxQRLLnZoRAvoG0yuI4thicJ8Ptcr
  85B5WXNQH-YW8fqdnzRfhXPR0rmcuDyloMspFKmdaXFuJzm3FcXv2MrexjEpNuNYA
  F1U63-GJQDgWkTD0Jqowzt5mOTw",
        {
          "signatures":[{
              "alg":"S512",
              "kid":"MBDV-XXNH-2RUB-RBMZ-5NG7-L3CD-3THV",
              "signature":"X7i49SUdqSGL6_Iu5bVAoDVUS1lAiyn333jJJc
  0P1FNomX2omaYKrpepbsJcYQNXSDkakyPEg_CApF7k07eQvfwKEAhPVtES_NZo4aD
  jK_gtVXa8FY3aqbFrgatOK1PbMcUWOt4qTe--xyJIKhXN2TgA",
              "witness":"p1ZkuXKyRwrlhoSERIoqHGiZ512xE-bOHHVqRqGd
  A5w"}
            ],
          "PayloadDigest":"oWCi5hMAs9B_Jdl23UlB94HG4nmT0F0W-qbvhk
  uV2jULzRUDGFbY3Zz2y2er9QTYCPBCXSV4857a_dgxHMI8ew"}
        ],
      "ApplicationEntries":[{
          "ApplicationEntrySsh":{
            "Identifier":"MCXP-WQVY-RTKQ-ZU6P-VOM4-7U6K-FHXH",
            "EnvelopedActivation":[{
                "enc":"A256CBC",
                "kid":"EBQK-TT6L-J6RL-A3QS-7JY7-HN2D-WI5W",
                "Salt":"muuRM8Csu8YVGXKPgdBskA",
                "recipients":[{
                    "kid":"MBYP-2QNG-II34-MVBJ-E3DD-JMUS-KRU3",
                    "epk":{
                      "PublicKeyECDH":{
                        "crv":"X448",
                        "Public":"pY-ltrx_QDrhpB2nYek4X9G5CLO3u15
  mcqPAbABxFYRZ83lPtMDLGXmo-FFgqe_gN8per0enFOeA"}},
                    "wmk":"mM9Xh0EF5h1q1GwGnK-GK7gblurWYGJ3k4tE2X
  pc8WmMK7ELsOPW_g"}
                  ],
                "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3
  RpdmF0aW9uQXBwbGljYXRpb25Tc2giLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1
  tL29iamVjdCIsCiAgIkNyZWF0ZWQiOiAiMjAyMi0wNC0yMFQxNjoxNzo1MloifQ"},
              "9ie5X_tfEyaX1ndBhH8gPr5TZQlt14MSGgYJR0AUcrBCXYzBYR
  Q_RiekTzkhluV00luMJ60-fjdzkpOyx_0yXr_ClQkn0M6_FAOt8m2zNZPeURJlFsh
  jGDKyne_c243dcLEskczb1TVkxYhBgrYaykksDENRGAy_gH6vXTFV2DFg1N02UVhP
  j-xQ4pcMrqEpWYYPwAT-N8jWezoOnz2-crO5HW-L3qXB2bzdUcomcq82aO7PQdeBI
  oxHmeeMwdWLV9_tXTm6jsUuGyvvQcXbiQZ9uybTboSyb4Tp2fXyHHjfKL8yPtedXP
  _CAqKdwmZ1ogj0p_O6IzPgUBVQBfxhFi73MgDbkcftON5JS0MNn-YNWkF3Sb-UtJS
  2sttpYOX0M6fZfC1-OFCffuSdEs9KxggxOG3xqmhVcHI4OKVF4hzO21AeocmnmW_0
  FyGrYjNozvXKrSYCvdKshHj1ZqqiWVT3xtQsaVr9FF5_IaMaXfFvwHSQei0p6_B3m
  71r_kciGKO2YyoAoyle0rJuIt4enovfPNpm0f29yhe1-lBY0Hhe6Wf7hSK9NffQc2
  TaBXYWPnDRVlqy_HuEW2MS8jt2NGbFULFsqPpcv22eIuB6K6HefzXlvA_IuYla0So
  JBE2Lyd-Nvpp_6YNOpeWvESFnwbE7rBUcmKrtDSZUp5Hi_XPZ1Sj2h2MYmEvwcDfT
  W8bmS7KJR_EvLglnSp8AnnTTfzqO2XnR5aHVNIgyN5mBqiexLE2W4mGD5FfYvypsp
  ARqjCPjZxUMoZXuqFjx10HSdkBALXoDz1hynK0LkdPL9tjlhnm6sSkJYj8xnfamm3
  qO9BNmponRL_3DQXoPGDkkvwRhWHNCnuC8yQJ8JLN0E9o0Vw6sQX9lQpStMaLbom_
  4zvj9rd4Tl-4EyakDiQgb0x6_c8MaNCs7J_GWX_SVbZcdexx-Hm4aCgwZ3jGbSJZs
  2KKAZmHma3E8N5N8n4wXlHoC6cfA0-y2_3hm39LcKYKJ6YfIqBDJIwdL0vzTLq9qZ
  JT7p6ypBxEnHPTIfFbuHmBGKvzMvHTlLQ_IUr0g6Eyxw1LxKBSSI8FPb2h556_O-1
  hNK-ck6lfEe3JWfsniQuqZTXPrfpduwERLOXanZ-_ysE7Cqd7rh5aAp59GBqWAqpF
  meE4iRYJl6AkEy0wacBsAUJwqoAX4lZK3TU3ChJ0Zh3RemmO6ymxJhHdweb70lvSj
  U60goICoXxuRHuGrrcFfY9SbU3Wae6ykbfsRKY7xJGNkchSkSt7JgsInvhdqn8cSr
  KpMgZqrBAb2tKffghOToS9k4txQsLLeYtmmvWK92bRVbvIy_xvEBC5t0c9q8amGd3
  yMkPa71b8fHOd3rRiA8oXLQhrRCpt1t-aPV0xadtYsRl2MbgW8uQst6zhmlWy3XFF
  UfP7l_mWwWr5-RMMp7oEk-Bnts0v6sELpPiOMVHAUvukCPZMdiOiItcZxGshGk27N
  BsJBNwfPUCpSdvvSzjscnWJgZj2L0iOh1Lb5V0ONMrfdhO9IGa4SXs1dNjsgLqW_0
  zi5fYNYNuAm6cr7658dgt43HWXVC_1o9Hz5jdfmpUD6rMyyCc77c-VIVibFLi5yRs
  MWHFVtUu6mW58VJtXz9LRTfaUVKa2dnb4kRU5Bj8O38dTYhXrSrIuPIV4RWyUPMnw
  jCgd9A2TPSqo3NrH11bHgDOHM1peyx1W4lIDyncV4AbSr20YoW6l3ib84YE5uDAPB
  KTb_v3Dy6-dD-7wcjUmI4Q-uXt289kdHqQdw_AbK8Y1uP8fYZSk87kPo9fpE5vR8y
  DHRrRSprsCGBA2s82-7X3nxZ8AqaN3JvAttT2LzMmTW15ITmW70tBjttzlCvuwGE3
  Y1iNHTZFmhRCvLmbzDuMQbhzTXvxmrT4ivY71XVVshjAsHjcv0ss8mSz3CIZWcq_7
  ujoV9fKfu12CwP2FQDiLHb-uvqu25j5rB3mmLQdtBvLc34Nw3qCMUCmmLBvbG2TCd
  i-tOPZARgSRyMWH29zFIC8VCt6hOpj_e_CTZ5qVlDRUNvRtHeDJ8aSOIDrT30lWQa
  7QsdrUTzTo7m4SZ0pftrmavB0s_ImyLP1yGYSL0_PDntuz9aZVQt7LYlwBYm7FP0F
  QDI3FyF7eX6j4HFj2aIT9ZKc-rXGdYJg2GcKwvftIAis_fIuREm5U5JdZp58sB3gg
  NdOpZkN7vBKu6lgMznuldJYUdLZHkMf3-mfNue5dzyAI8TjhOmVxavGxk3sphqHqU
  5zEpL8rhvgGgL7Mveww78tlVni8OhsoYWywwZ9Q9Nwg8BWMHVssMmWxqCOZda-7zw
  o_2uWlhXw4sSp5Bodz2PXBBQDahQPboLQJLWZad7_Ds7Uq-YERfrTp5oL5O5PIF4O
  TXW9eal1qKPYnoohFSUmZYmKtpQ78ul3v0-PYXQywmKeet6EzcgM2txIQh6ceSuP0
  hTMbVXjt0yB3RV5pX3rjtTeqg8hFmEEyKO_0i30nNxh62sdRBzE-mmfc3N3KQqIha
  sRFB31q9V2iifcD26C5mnQTIDnQ2nV_w4DHAudXhko-nJHouAeGhCMNa05I2dhu3x
  4kM2nUDgX6_RHM4dokC0q2SKZZubE27GrC1eDf8RDpKHi1uby_Rkw9q0oCdsLIsW4
  fLCJSvEpMzzS4YqP77ePINAiBNTSOAR_L9dpqkGuGcCL4DykWiA0rGmmnTaw7UG3t
  iVNS7bBdoKdcqORjUlEfVv3AvEZ08k8KZQYB_oA5IoXj0D1G2JHSqYocFIHcvSbqO
  07Mehz6FqBUF4YcbVKIp_QkG8nCuinD_AwPhtNb_EFN0MM3jaEuDVE0XhIfAHnKrk
  BXC6n3_Qprj-nuBxo_Cf-egFPia_gSjbb1PvoFpxATbPlkY_J6Ihv7b6N19MX8gUx
  HwwdCYLtTwHm8vWlKF0N2qGh_VObwrf0YZaJUkd-yaIOknlOrRw0MjytMsi_SEw_-
  9D4Jn6jkdJzbyQD06CX-tPeNGnelVZfJR7X7SGCDC4_ues5Ait9OH1uZT1J_Z58bZ
  HPHqT3S_GawAVwDN6h7A-VZnELXY279obT2uQ4mSjfLnKvM19qREiJxM7vJELYHfb
  DLi2WxX8oR5dYmhgZfAaCRFlO8dcXoZc1aMwthDm_tvq96ZMqTG-KeBr7Br8VHFgK
  Ji_GDWm6y41EDfw0WxQ_m-7sOCKclct-i5om1X3A3A49u5Cf0U08NxLqPDDM2H9_b
  7WQfPmY7EfBNesye6AX_0DKqaIbG0Dlhddnx_s5dOizf5TD2kxAlgPz9BD8EUhj3h
  3p9L559Yj9RnHSPvqY2x_xsbxyPx"
              ]}}
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
<rsp>   Device UDF = MAA3-BQPZ-WWO4-7Q5B-P7AH-FY5C-ATMD
   Account = alice@example.com
   Account UDF = MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF
<cmd>Alice3> meshman account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MCXK-BPYI-YM5Y-N4LL-SFZV-FXIC-AHX2"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

