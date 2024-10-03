
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=AASP-5A76-VKQO-CZZF-SQ6R-DQUU-2A
 (Expires=2024-10-04T14:57:13Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcd://alice@example.com/AASP-5A76-VKQO-CZZF-SQ6R-DQUU-2A
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    AASP-5A76-VKQO-CZZF-SQ6R-DQUU-2A
<rsp>   Device UDF = MBQN-RX3S-JAXD-GPDP-U3HD-PAOR-7ZVF
   Witness value = FIFD-IQCW-5UHI-F2H6-XMWU-ECYP-OOTA
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "AccountAddress":"alice@example.com",
    "AuthenticatedData":[{
        "EnvelopeId":"MBQN-RX3S-JAXD-GPDP-U3HD-PAOR-7ZVF",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFOLVJYM1MtSk
  FYRC1HUERQLVUzSEQtUEFPUi03WlZGIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDI0LTEwLTAzVDE0OjU3OjEzWiJ9",
        "dig":"S512"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIkVuY3J5cHRpb24iOiB7Ci
  AgICAgICJVZGYiOiAiTUFHRi1JNFdHLTVTUTItSjZERC1GTVJGLUFMNUgtSkJVRCI
  sCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlF
  Q0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiLTJzZUgyRnlueEt3QzZRREZDeGpzYkMyb0pWZ1lYcjNrSUdlREpJOGR6bm
  05X0R2VUFOcQogIHdDSjc5V0NKMzc0Ukx3dVYyTkpqMkQwQSJ9fX0sCiAgICAiU2l
  nbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CNFUtWENKVy1PVFQ2LUg1U0YtN0dL
  Wi0zUVRZLTJGRkkiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogIC
  AgICAgICAgIlB1YmxpYyI6ICJXWGs1anpQT1Rxc1lJYkF6LXlSNkdFZEVTTzlNYWV
  EcVNpN3Y4LVE5Q3ZnNWhRY3BjZFplCiAga19hSU11eEV3MzBvVmV6bE9SWkpsbUdB
  In19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQUZHL
  UtCMkQtRkVFNy1JVTZILTVBVVktMjNXRS1YSlFYIiwKICAgICAgIlB1YmxpY1Bhcm
  FtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICA
  iY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJlN0VyM0szSUFZTVBJ
  S3REZ2x3RGJpZ2tDQUlPM1lrYV9BdmZpODdLLTNGRG8wbHlYRTloCiAgUnc2T3BBS
  EhBLU95UTlWc1VYVExJcmtBIn19fSwKICAgICJSb290VWRmcyI6IFsiWU5GLVRFZU
  RHdzBTblZtajJoSnU0cG1OdVZWTlJtWGJhbFJJSkNBU2xqNFY0VWRZVEEKICBDM2N
  Mc2Frd2NnUHFxcGlxSkVfWHlEcDBYVU9XXzhZcWpSNkEiXX19",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MDIX-4TCH-QMNQ-2EU5-LGR5-UETO-4KMY",
            "SignatureKey":{
              "PublicKeyECDH":{
                "crv":"Ed448",
                "Public":"bfKjeCKmbL_2AoAfla7Jn1J-oQa0XcYzhi4gwEr
  6YvqGrY1pjVgmOZP0NVnkXVuCsctp6kpW7i6A"}},
            "signature":"5nQFo6jchIyn76QbL04GEL8m0NheUpb2GgdAFSR8
  _SR5J8zXVwfd4uZw5MPOMPL7L49jYcfeA3iA6y8Vz4rSiXOt4_EaIU1k8Kj_Ewtbn
  sOjBkXXkidI9B4xJerQeGkzlB96akwGCYr9hfNLrtyKugYA"}
          ],
        "PayloadDigest":"pe8hhxJHMx7PgS5aDBzWegjt03KlNHCehm8CA_BA
  9atdhGRPcd636wHeCfy3xE59_xNTdVtkH-W_qKeiZpvjkA"}
      ],
    "ClientNonce":"J_x3jh6jcGD65EuZosOuBQ",
    "PinId":"ACUQ-RZCP-3GH3-FJ5W-EIND-IYN5-HCND",
    "PinWitness":"XyG4nrtlyMKGYkrJuAM0WcCkGxx1BiLZf5OCo4X9UyMlR0z
  2c3_VNZPrcPiahuJ6nofcklRWPAFX5Og7k41nMw",
    "MessageId":"NC4O-2QI5-63G3-IHBY-56YT-MMF6-LVA7"}}
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
        "EnvelopeId":"MBDE-J34Y-7TLW-BK5X-DYH4-5335-TA5U",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQzRPLTJRSTUtNj
  NHMy1JSEJZLTU2WVQtTU1GNi1MVkE3IiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyNC0xMC0wM1QxNDo1NzoxM1oifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJBY2NvdW50QWRkcm
  VzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiQXV0aGVudGljYXRlZERhdGE
  iOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1CUU4tUlgzUy1KQVhELUdQRFAt
  VTNIRC1QQU9SLTdaVkYiLAogICAgICAgICJDb250ZW50TWV0YURhdGEiOiAiZXdvZ
  0lDSlZibWx4ZFdWSlpDSTZJQ0pOUWxGT0xWSllNMU10U2tGWVJDMQogIEhVRVJRTF
  ZVelNFUXRVRUZQVWkwM1dsWkdJaXdLSUNBaVRXVnpjMkZuWlZSNWNHVWlPaUFpVUh
  KdlptbHNaCiAgVVJsZG1salpTSXNDaUFnSW1OMGVTSTZJQ0poY0hCc2FXTmhkR2x2
  Ymk5dGJXMHZiMkpxWldOMElpd0tJQ0EKICBpUTNKbFlYUmxaQ0k2SUNJeU1ESTBMV
  EV3TFRBelZERTBPalUzT2pFeldpSjkiLAogICAgICAgICJkaWciOiAiUzUxMiJ9LA
  ogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWtWdVk
  zSjVjSFJwYjI0aU9pQgogIDdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVRkhSaTFKTkZk
  SExUVlRVVEl0U2paRVJDMUdUVkpHTFVGTU5VZ3RTCiAga0pWUkNJc0NpQWdJQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0oKIC
  BzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE
  0SWl3S0lDQWdJQ0FnSQogIENBZ0lDSlFkV0pzYVdNaU9pQWlMVEp6WlVneVJubHVl
  RXQzUXpaUlJFWkRlR3B6WWtNeWIwcFdaMWxZY2pOCiAgclNVZGxSRXBKT0dSNmJtM
  DVYMFIyVlVGT2NRb2dJSGREU2pjNVYwTktNemMwVWt4M2RWWXlUa3BxTWtRd1EKIC
  BTSjlmWDBzQ2lBZ0lDQWlVMmxuYm1GMGRYSmxJam9nZXdvZ0lDQWdJQ0FpVldSbUl
  qb2dJazFDTkZVdFdFTgogIEtWeTFQVkZRMkxVZzFVMFl0TjBkTFdpMHpVVlJaTFRK
  R1Jra2lMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLS
  UNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKIC
  BnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk
  2SUNKWFdHczFhbnBRVAogIDFSeGMxbEpZa0Y2TFhsU05rZEZaRVZUVHpsTllXVkVj
  Vk5wTjNZNExWRTVRM1puTldoUlkzQmpaRnBsQ2lBCiAgZ2ExOWhTVTExZUVWM016Q
  nZWbVY2YkU5U1drcHNiVWRCSW4xOWZTd0tJQ0FnSUNKQmRYUm9aVzUwYVdOaGQKIC
  BHbHZiaUk2SUhzS0lDQWdJQ0FnSWxWa1ppSTZJQ0pOUVVaSExVdENNa1F0UmtWRk5
  5MUpWVFpJTFRWQlZWawogIHRNak5YUlMxWVNsRllJaXdLSUNBZ0lDQWdJbEIxWW14
  cFkxQmhjbUZ0WlhSbGNuTWlPaUI3Q2lBZ0lDQWdJCiAgQ0FnSWxCMVlteHBZMHRsZ
  VVWRFJFZ2lPaUI3Q2lBZ0lDQWdJQ0FnSUNBaVkzSjJJam9nSWxnME5EZ2lMQW8KIC
  BnSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKbE4wVnlNMHN6U1VGWlRWQkpTM1J
  FWjJ4M1JHSnBaMnREUQogIFVsUE0xbHJZVjlCZG1acE9EZExMVE5HUkc4d2JIbFlS
  VGxvQ2lBZ1VuYzJUM0JCU0VoQkxVOTVVVGxXYzFWCiAgWVZFeEpjbXRCSW4xOWZTd
  0tJQ0FnSUNKU2IyOTBWV1JtY3lJNklGc2lXVTVHTFZSRlpVUkhkekJUYmxadGEKIC
  BqSm9TblUwY0cxT2RWWldUbEp0V0dKaGJGSkpTa05CVTJ4cU5GWTBWV1JaVkVFS0l
  DQkRNMk5NYzJGcmQyTgogIG5VSEZ4Y0dseFNrVmZXSGxFY0RCWVZVOVhYemhaY1dw
  U05rRWlYWDE5IiwKICAgICAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgI
  CAgICAgICAgImFsZyI6ICJFRDQ0OCIsCiAgICAgICAgICAgICJraWQiOiAiTURJWC
  00VENILVFNTlEtMkVVNS1MR1I1LVVFVE8tNEtNWSIsCiAgICAgICAgICAgICJTaWd
  uYXR1cmVLZXkiOiB7CiAgICAgICAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAg
  ICAgICAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICAgICAgICJQd
  WJsaWMiOiAiYmZLamVDS21iTF8yQW9BZmxhN0puMUotb1FhMFhjWXpoaTRnd0VyNl
  l2cUdyWTFwalZnbQogIE9aUDBOVm5rWFZ1Q3NjdHA2a3BXN2k2QSJ9fSwKICAgICA
  gICAgICAgInNpZ25hdHVyZSI6ICI1blFGbzZqY2hJeW43NlFiTDA0R0VMOG0wTmhl
  VXBiMkdnZEFGU1I4X1NSNUo4elhWCiAgd2ZkNHVadzVNUE9NUEw3TDQ5alljZmVBM
  2lBNnk4Vno0clNpWE90NF9FYUlVMWs4S2pfRXd0Ym5zT2pCa1gKICBYa2lkSTlCNH
  hKZXJRZUdremxCOTZha3dHQ1lyOWhmTkxydHlLdWdZQSJ9XSwKICAgICAgICAiUGF
  5bG9hZERpZ2VzdCI6ICJwZThoaHhKSE14N1BnUzVhREJ6V2VnanQwM0tsTkhDZWht
  OENBX0JBOWF0ZGgKICBHUlBjZDYzNndIZUNmeTN4RTU5X3hOVGRWdGtILVdfcUtla
  VpwdmprQSJ9XSwKICAgICJDbGllbnROb25jZSI6ICJKX3gzamg2amNHRDY1RXVab3
  NPdUJRIiwKICAgICJQaW5JZCI6ICJBQ1VRLVJaQ1AtM0dIMy1GSjVXLUVJTkQtSVl
  ONS1IQ05EIiwKICAgICJQaW5XaXRuZXNzIjogIlh5RzRucnRseU1LR1lrckp1QU0w
  V2NDa0d4eDFCaUxaZjVPQ280WDlVeU1sUjB6MgogIGMzX1ZOWlByY1BpYWh1SjZub
  2Zja2xSV1BBRlg1T2c3azQxbk13IiwKICAgICJNZXNzYWdlSWQiOiAiTkM0Ty0yUU
  k1LTYzRzMtSUhCWS01NllULU1NRjYtTFZBNyJ9fQ"
      ],
    "ServerNonce":"HIkRWSv-3li9TZQyOi_x8g",
    "Witness":"FIFD-IQCW-5UHI-F2H6-XMWU-ECYP-OOTA",
    "MessageId":"FIFD-IQCW-5UHI-F2H6-XMWU-ECYP-OOTA"}}
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
<rsp>MessageID: FIFD-IQCW-5UHI-F2H6-XMWU-ECYP-OOTA
        Connection Request::
        MessageID: FIFD-IQCW-5UHI-F2H6-XMWU-ECYP-OOTA
        To:  From: 
        Device:  MBQN-RX3S-JAXD-GPDP-U3HD-PAOR-7ZVF
        Witness: FIFD-IQCW-5UHI-F2H6-XMWU-ECYP-OOTA
MessageID: NBHK-3QNB-UGZT-H5XN-2CXU-RIL7-XJZY
MessageID: NC75-ZYCL-N3BL-FVYI-TFSW-FFJV-DZHW
        Confirmation Request::
        MessageID: NC75-ZYCL-N3BL-FVYI-TFSW-FFJV-DZHW
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDYX-HZYP-X7E3-4UR4-LH7A-BQMT-PQXJ
MessageID: NDXB-RN25-2RVC-F3FL-FULX-GQNG-TAYB
MessageID: NCDS-JZQ5-N633-ZKWA-7U5I-6LNU-PFT5
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
      "DeviceUdf":"MBQN-RX3S-JAXD-GPDP-U3HD-PAOR-7ZVF",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFFLVVOWlAt
  NVJIMi1XWUhZLUlPNVEtSlJBRC1XVEUzIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyNC0xMC0wM1QxNDo1NzowMFoifQ",
          "dig":"S512"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJDb21tb25TaWduYXR1cmUi
  OiB7CiAgICAgICJVZGYiOiAiTURTQy1GQjNHLUZFUEEtUFhPMy1NRkxZLVc1TFItV
  09CVSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaW
  NLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICA
  iUHVibGljIjogInBhNnlwSFE1aVk1YTJ3VkE0bnZRcm5JczlQZDR6eW9qZGtoM3Vp
  cUszVVpIbnRqNUFCamgKICBoaDRoVW9vdllOc3czOUs4XzNWZGFTc0EifX19LAogI
  CAgIkFjY291bnRBZGRyZXNzIjogImFsaWNlQGV4YW1wbGUuY29tIiwKICAgICJTZX
  J2aWNlVWRmIjogIk1CUVAtRVdVVC1VWVgyLVEzR1MtSEI0Ty0zVkJRLUlLUDIiLAo
  gICAgIkVzY3Jvd0VuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJNSy01Wkda
  LVE2N1AtRVo0SS01V0JJLUxYNzQtTUFZTyIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydi
  I6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiRXIxaUdyRzZiVUsybDlSSFl
  CeDdENUoyWUx2YmJiZU84VWZ5eDQ4R3Jtc3U4QjA0NnowbgogIHVtcmJ5LTZDOGlQ
  UnJrVzBfaVp2a2FrQSJ9fX0sCiAgICAiQWRtaW5pc3RyYXRvclNpZ25hdHVyZSI6I
  HsKICAgICAgIlVkZiI6ICJNQkxNLVc0WFUtNUxNSy0zUkVOLTI1V1AtR1dGVS1FS1
  RWIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0t
  leUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAiOXc2TmNyaFItSDR4ZGdDTVU3OVZuNUxvcHIyNTRVbmlmMk9fWWdxW
  TB4QklmdUhDOU9aSQogIFNfdmJrZ3NDMmRmWW5TTndHMFg4RnVrQSJ9fX0sCiAgIC
  AiQ29tbW9uRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNRFNPLU5KSVEtSFV
  OVy1VV1JTLVdQT0UtQkJPMy1ORFdOIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  lg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJiNVVFNVJXbUwtekN2c3dxREVrNk
  s0Z1RUckQxazFvaXBBRWVCOXlQZHVpaEU3YnkwQ2tZCiAgdzJDTlU0VXpZM2RTSmZ
  ydGZzVF9OWXlBIn19fSwKICAgICJDb21tb25BdXRoZW50aWNhdGlvbiI6IHsKICAg
  ICAgIlVkZiI6ICJNQ0xMLVpCWlctUUsyTi1YREhYLVZUNzQtRkJUQy1ONVUyIiwKI
  CAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDRE
  giOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI
  6ICJIS3FlQXpqYWxDa3pIRk9seTVNS1lVVXlyRjNkRFpUbDhZMmdXMk9wMHVLTUkx
  TzVUaGN0CiAgbkNSZzdFYVlCY0wtUXVzRXNMTjZKYXVBIn19fSwKICAgICJSb290V
  WRmcyI6IFsiWU1la3FHXzBnaFVoaS1mRkNBbko1YnBSVEhBYWxWdDFucjFZU0x0Wj
  RSVEdhOWZOTGsKICBHZkdUMVp5RDZ4ZEJGZ3dLTVdDNmJydHlqREt5ZnpGSFlzdnc
  iXX19",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MDD2-JKDP-6SBB-KIML-47CQ-QCOJ-4W5F",
              "SignatureKey":{
                "PublicKeyECDH":{
                  "crv":"Ed448",
                  "Public":"-Q8jzQNBMcZFn-fVEB9xf4Ls0xSZvL7Bv7G4j
  L0oH2Q_Swi2L1i936J5XBtQg3RBWgS1ssMVoFqA"}},
              "signature":"Tf4LZXTPpxY4Fmemq6TKey2hDfcLHHCUKaCBlo
  iPPl_JYp7tFn4BLMO3tuOIwWzPtXBjqedSfYkAMybBaLoYpksaaJEEShZA9jI2HrO
  yrUrV5xCLP1sMwTHWxOfX0uNtvaJsl1WyhVNpoO9grMPznBEA"}
            ],
          "PayloadDigest":"DKAbczzXtdtOVVjKKCV6TJl44srtnqeC4PpBEp
  dyxO-JAR-F4hPqkXliANiTUXl2zCHkD4HOAVwX7p2xhzZoxg"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MBQN-RX3S-JAXD-GPDP-U3HD-PAOR-7ZVF",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFOLVJYM1Mt
  SkFYRC1HUERQLVUzSEQtUEFPUi03WlZGIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDI0LTEwLTAzVDE0OjU3OjEzWiJ9",
          "dig":"S512"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIkVuY3J5cHRpb24iOiB7
  CiAgICAgICJVZGYiOiAiTUFHRi1JNFdHLTVTUTItSjZERC1GTVJGLUFMNUgtSkJVR
  CIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZX
  lFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJ
  saWMiOiAiLTJzZUgyRnlueEt3QzZRREZDeGpzYkMyb0pWZ1lYcjNrSUdlREpJOGR6
  bm05X0R2VUFOcQogIHdDSjc5V0NKMzc0Ukx3dVYyTkpqMkQwQSJ9fX0sCiAgICAiU
  2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CNFUtWENKVy1PVFQ2LUg1U0YtN0
  dLWi0zUVRZLTJGRkkiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAog
  ICAgICAgICAgIlB1YmxpYyI6ICJXWGs1anpQT1Rxc1lJYkF6LXlSNkdFZEVTTzlNY
  WVEcVNpN3Y4LVE5Q3ZnNWhRY3BjZFplCiAga19hSU11eEV3MzBvVmV6bE9SWkpsbU
  dBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQUZ
  HLUtCMkQtRkVFNy1JVTZILTVBVVktMjNXRS1YSlFYIiwKICAgICAgIlB1YmxpY1Bh
  cmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgI
  CAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJlN0VyM0szSUFZTV
  BJS3REZ2x3RGJpZ2tDQUlPM1lrYV9BdmZpODdLLTNGRG8wbHlYRTloCiAgUnc2T3B
  BSEhBLU95UTlWc1VYVExJcmtBIn19fSwKICAgICJSb290VWRmcyI6IFsiWU5GLVRF
  ZURHdzBTblZtajJoSnU0cG1OdVZWTlJtWGJhbFJJSkNBU2xqNFY0VWRZVEEKICBDM
  2NMc2Frd2NnUHFxcGlxSkVfWHlEcDBYVU9XXzhZcWpSNkEiXX19",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MDIX-4TCH-QMNQ-2EU5-LGR5-UETO-4KMY",
              "SignatureKey":{
                "PublicKeyECDH":{
                  "crv":"Ed448",
                  "Public":"bfKjeCKmbL_2AoAfla7Jn1J-oQa0XcYzhi4gw
  Er6YvqGrY1pjVgmOZP0NVnkXVuCsctp6kpW7i6A"}},
              "signature":"5nQFo6jchIyn76QbL04GEL8m0NheUpb2GgdAFS
  R8_SR5J8zXVwfd4uZw5MPOMPL7L49jYcfeA3iA6y8Vz4rSiXOt4_EaIU1k8Kj_Ewt
  bnsOjBkXXkidI9B4xJerQeGkzlB96akwGCYr9hfNLrtyKugYA"}
            ],
          "PayloadDigest":"pe8hhxJHMx7PgS5aDBzWegjt03KlNHCehm8CA_
  BA9atdhGRPcd636wHeCfy3xE59_xNTdVtkH-W_qKeiZpvjkA"}
        ],
      "EnvelopedConnectionService":[{
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDI0LTEwLTAzVDE0OjU3OjEzWiJ9",
          "dig":"S512"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tApQcm9maWxlVWRmgCJNQlFFLVVO
  WlAtNVJIMi1XWUhZLUlPNVEtSlJBRC1XVEUztA5BdXRoZW50aWNhdGlvbnu0A1VkZ
  oAiTUFBUi1FMzdYLUdUWEgtU0ZUWS1IQVZMLTVDNFUtQ1dVTLQQUHVibGljUGFyYW
  1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1YmxpY4g5MLo5Hh9
  cRIo8I5gucwewMCdV_fg6lwV8se8H34hK0mzgqhlJ8AUI7n5WhqUePuMie1szUvhi
  xseAfX19fX0",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MBLM-W4XU-5LMK-3REN-25WP-GWFU-EKTV",
              "signature":"n8gbfxj6T2uJZHdsMqO8b6d4GT4RJzj-wj2LfQ
  BqyO5SF59rHQPONuqsaxtaRpVGpeBwdU-sQzkAf2SRGYAZWeivmnG7wfuG-fHzCAj
  v6VGKo3WLyPZXo37T5Rip8yfF_xQbeJXFymq8smB4iDAm_CcA"}
            ],
          "PayloadDigest":"43NmG4W8ZzHmQJVH89G64neZ-Wb_1I7z-e-pSM
  8Oiv60FhTZxyh2YTN05vSoWBwM_p4vKUfr_TljabGWDiAhLQ"}
        ],
      "EnvelopedConnectionDevice":[{
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjQtMTAtMDNUMTQ6NTc6MTNaIn0",
          "dig":"S512"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0BVJvbGVzW4AJdGhyZXNob2xkXbQJ
  U2lnbmF0dXJle7QDVWRmgCJNRFo1LUxPTlgtUUdLQS1GSENYLVNTTEotVTRHVi0zU
  zJGtBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0ND
  i0BlB1YmxpY4g59CDyxDwUDYTDntIlJ1AyI6e4Er0ODaErbVmTn5C3MDKPVe9MIGF
  XqdgsbUtmHFrp9llX28iQ-uwAfX19tApFbmNyeXB0aW9ue7QDVWRmgCJNQjQzLURa
  UFUtRk5WUS1NN0VOLUFZNzItRUdMUi0zTlY1tBBQdWJsaWNQYXJhbWV0ZXJze7QNU
  HVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibGljiDlWXDolvWck5WSWh9Yvn3
  kt7H5XWO1ehIIldoOiRuHrhEi4aMZzlKSC9VZ9d8BbQCP4zo5Rf58oFwB9fX20ClB
  yb2ZpbGVVZGaAIk1CUUUtVU5aUC01UkgyLVdZSFktSU81US1KUkFELVdURTO0DkF1
  dGhlbnRpY2F0aW9ue7QDVWRmgCJNQUFSLUUzN1gtR1RYSC1TRlRZLUhBVkwtNUM0V
  S1DV1VMtBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWD
  Q0OLQGUHVibGljiDkwujkeH1xEijwjmC5zB7AwJ1X9-DqXBXyx7wffiErSbOCqGUn
  wBQjuflaGpR4-4yJ7WzNS-GLGx4B9fX19fQ",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MBLM-W4XU-5LMK-3REN-25WP-GWFU-EKTV",
              "signature":"CwtIo_m8YCyXjSeOQajTzz0MQp8ypmLCBSjuxK
  X4j244ntmLKPkyQUfgha8RJkMRWlyX78vhIu8A8R8lhMtN7sGZa385a2yuS2Vdwed
  pEYz28OVdauv4Ph5VQGY5Y3Y0OIf26yCS_4QMRfs1lEOLdRgA"}
            ],
          "PayloadDigest":"-kdtUwh4990yToJQ5JIR4DhJ9jClL50_Gf0JrG
  YwodOH-sGGhXRQwKJ6SsECnbY2z8zOyA-4gVeu_0S0Z8RmaQ"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "kid":"EBQL-J5RA-FGA6-ICBO-GPFS-FK2O-57EZ",
          "Salt":"Zixcg8SgMPbQTgNZdaSfxQ",
          "recipients":[{
              "kid":"MAGF-I4WG-5SQ2-J6DD-FMRF-AL5H-JBUD",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"i8_SFmhwjOkgbtyCHF6cU6oYcLUu6RPaDca1Y
  6DxC305yacMq8_D6CUWrIyQuwSaqC7anrgugfmA"}},
              "wmk":"CD9QSRKsKB7Qc8SwhCbITxe0lWgkPN1LcPxzf08ycTYm
  CLpER4x4IQ"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDI0LTEwLTAzVDE0OjU3OjEzWiJ9",
          "dig":"S512"},
        "ia-QT1cZF6z0HJ6vA4ZJr06ENVfe_u6qwsEVQFMyAtjDAkoV_51hGVCu
  LSTWyd7eIzE9mKCZIimZTtjl-ty5rcEkOyPVChfjYIiHOIk2OU6QZBfAo77qhdJOE
  cgKiXcHNCITQizuMAnBrav-GccoLe9ZJxEVFn3t_lq652w6jJ7ONznrGjkLmuXCuW
  8zA9_GJse559-sdkRNZB8z7nuFH9ycavMWUyfCtSrq4RRQxOI8B21y89rLKMdLSrK
  CJGSV",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MBLM-W4XU-5LMK-3REN-25WP-GWFU-EKTV",
              "signature":"fhH-XNA41RHgNUGeInWPqFP5pDBGKm4g3kTTdv
  gHHq1Ajd4W66wi5TGxXd0WB0M8jmlIorHR1yiA3j9VJWaBh9xwwb5ml6RhM_gR7rV
  Ft7pDnVbpwRZ8QYcr0_dFGrjLr3GTg4YIa9RXXRkJi52QwCAA"}
            ],
          "WitnessValue":"5dZ5-BJJb7kA5XhR-DpjrOZaM3ZIqXaCQVoolJh
  EItg",
          "PayloadDigest":"Wxp60Ci3nQuSZhO56UWAsBV--F_dGD1SvMGZj2
  HhV3-cBa-YEjiej_IOU6n5DqQ8QyKNv04M8qQhtTEC8UeSqA"}
        ],
      "EnvelopedActivationCommon":[{
          "enc":"A256CBC",
          "kid":"EBQJ-CMYR-JELI-3VBQ-P2MN-5PMT-SRO7",
          "Salt":"m0y9besc8giBVpIOGfbqsA",
          "recipients":[{
              "kid":"MB43-DZPU-FNVQ-M7EN-AY72-EGLR-3NV5",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"V4L3M6UI86sGBPOtxr0VM6WCuekV3oG9GjjKq
  WgZJhBxQqUWTGN_kJQnug1Rs_6iNlMSmMmrXyCA"}},
              "wmk":"49Lvr72uAdnKdqepzdWcJ7k8dn3OzwDTRjsB7U6lSv6h
  uTE_p1fqXw"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQ29tbW9uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjQtMTAtMDNUMTQ6NTc6MTNaIn0",
          "dig":"S512"},
        "w5sfh83jHHJgTtZp-1PRJxBb0z4zKgcIB9_RHCCjdTIRYGd_SDP4M3Dn
  _hQlfDOXJOfxYbet5PU8-Xp6E-8tlB12Fxjm_u5X4t9MqL2ewB5IUnK46LQcFY5Ec
  ejgpMzYt2XgVJq59uT484npni8ttQdza9f4R9-AAqsW9er4-YMXpjVF2ysY0nop4o
  x8srpMZC0ri5630lxaywSekA5rZInHFaq3Ipk6rVt3o9zQueMiJQqU2kEWbuFI2Lr
  Xb-Hyd0VNty0CMDU2EYmX7H3bRdubcOOdVkH5BGuVSPNS9Y6lh_cwpkHxUGE9X2jj
  W-RgecgXX6h_i1DITbsSwIrtulHt22ih-_Ws8v2c2oCL-1Yy1a2ouOXdTaaKC0Ypa
  DYkeDVcDRISdKRWdbbI4bTsSF_VVE5eLS0O4KYCpK-MH98ju0WmruvXz_-X_Y7H5w
  zCq-ndPIM_HWtyvCmP2ynHBzs7BCN1AX-NHQKs-zuwXYuiFNy3OlX7iJ9UpQcLyOt
  XVe541DLoz9WhGL4LqYONt3ulJfZIUwa6gBGGITOsNne27tUu7A6sx7uVwxmzLIJP
  EmP_4QBn4nN-RojHuEPST9LDo3da6DN2Bjg7LxsaSQWIoePZvodRMgCqYYJR8eFkD
  lYeBGnZ6LrE8j4usxkMT9lFNqQJmqyiPRbulXdCjtV6ZaPhtoLLvizOTMWm6Qi9bU
  QCRlRc7uz-6N824OVv7D3MCYZaBteB8J1y-_lE9rumOxKyCqR1k-vCj77BqRtk6Gl
  qL1xMC5sJfZ7vGx_PRjmz5E9F7r_5nq2YXOu2LIYE_3SlC6GMKvo4agZbf9P1_b0M
  NFpnQZkWPW50BKNkCCBnsXTS38yJ7XgOgER-f-caMWhB5KTS1psf_1tVxHnKm7f7h
  GexE3VKw2Kg3GYoTI5KNQ388Aqy5jf_YZBhmLRk3U1U5qFOq2kN-KYl8THjwrDeha
  rAbfw2jG8hWyl7SzaiFxNkb5mdqKAAIQsCfzd6DpzxtRTqPO42NBEe-wXPvfNoSCw
  ADbcRa8m82CIOdjbK8gMLQfJQVF4Vjk2POPby4Ff3oGx_8YgAzubFImBvsDj1mGmn
  qet1t2W4pKwt9OpAagnxPR5H4dbDzXaJ_4Qx2FcrMuIY6HepOkXAsIFEgaQdXyx7P
  c4K8Z2-mtofsrMjJu2n0uxkPeUJxLhFLCQpwtxP80yeLfLMpkCUGdfES9tZiiqoQf
  F_VpRKgEOyB3jBBz7LiTbTOAifM0cUyEo8bLWsK-8NcGKGzgl-6QD-he57vIQTgnr
  hcN4FAEsoc373g_G0P-aPPucGYmpml9V7vFKn8ZSGZU4cQxZsR2xJIGMv71QlL7P4
  it8Uwpb4LA6kMo-lzod9VPb2hbml03jAyqXAWrCBS6-pOvLZm1TEu8rtoG1f0zhXO
  1RSFFsaorSevCD0gKfmbEAYDy7o-AqYHm1c_u96jxYKXzhqoQUNPKOu9uDUK3QgKa
  nm1fwhD7Oe5wjhVZRYfZYLQTs0EbL5uYDWCLX0Pn7NxYvxoFc8xdbA3tBLbhzn90X
  3PmOPGDfzPPgA4qlcS7YLk93z8epK6kmhbgm_7ADBeU7es6i8O950ZIlZQBSQXdzN
  y9enKaKAEZX4ESBjRTYhx1PzwiRlEKxl56m2gLXmGoUKzD8ekX2om7cB7109xdfsK
  hs92HMjhmySbssBgsssv5unXY6rXx1j03lAQ7E15TsCKs66dIlqzp2f3OSTacRutk
  K6BYiWEwdTGAmfo1MQUfTPof5Ipdw0Ro-Ars7VGfxFMkfDWN5CXEx7x5SGUVYVKXM
  GOi-PKDC532PAzoQZ0zdkcpqONUhvjkExAOZ4uGJu1L1Ft7vxVD5g9guJ1lQc_dDv
  iRipKON0cvDe_UG5sbRUsHmYFDShm23WwmjlPmSfX2sOZ0NduVpB4D447GeAyo_DB
  egQpGcYQgXqNuHLaxD_rAT7mXgQ7n69HCOrbkcGt20zPgJZd9HLJqTrFy-xN2rmOm
  XNScsF2nwxewdKMGzj9bO92OHCxdIp6K-Oak9XUR5AnqEtYn2ODYABbQMfDbwmzNP
  -0NMu4a9OAO_lniDOcP6Ryr-GZBNYuWWqc1AauMvOMSgb4meH21TfJB5bZA4MWhiO
  U04fhlhBpkAUYY-yozMiQKBYDl1n2v19tuSaYdH7AG04IHOb6KFq8dcfPYGNDD_8Y
  EwDm4-_iLvIUpRnV5uBNL0JyJ5LiKJWbs8brVxWvDm6XSlTg8vs0i9pbgSAPH6PJa
  JK2vNt9kuAiH_gra_UHhEuSF7yKVj64OKidpSlabayL9NDbcCytgzOj71ZboM4ktG
  xBKoJj0Ms5nvMPpjKqOIh4k6XxcIohiArEJrPIf-oYyoiXGiF18ngvRxrLhIgPMFq
  2C6ozMPJOxfjr-5h6mj7MyoFJIk_DViVQ2JEPay7ylGftiU6P97e5hyrMRmTur_Ij
  hKTMecDLmaD0pSE4spGJU_RDpMuxMQ17sR3dkNBION81fBe5mRAZx027BmuF2VBe7
  ai7y2U50wocUxn0LCus37UvKw-GvPUN2UZ2JCKxAg1bwDt1htMaJaU7ng0zAyXVOX
  S2wBE0t6RMVYqR6xyWpyMoQUu2y1YeV-ggMPcinrp701yqxN4IqwCRCgZekL6S12H
  XStn2vGO3qB66uMppVedo9IjyeS_yGVtsc_gegUwuoDphgzxp-qFfe2xXC_430dcp
  v_uy79wTydD5x2FmwtgtoI62AZThFjbGcKRAKwiwAwZ1oFXritlDhAQcakZuBy_9X
  YflIIMi5qod4Fm_DrbA3f-kMe_51qV2u9TpP0U1iVONP4OoF_KfM9duNTJgAj20Kt
  emtA3aOeA2DcHI-lkgN40-SzOXcuTag3s_2_ovcROOYGrjCYtH6XiJdoQcxokbfsv
  -_TXyfUM_HVV-1hTKxFkvfFgiQp3fbKV_s4i-PEBSc2vTH7XfX1IGcOEqFXbZZqwX
  HbK9lPYOKqGFiN40IbbyTOyJ1ATtJpNQevRW8fICRpk7SmJcKHSUMxC0QO0wcYQ_n
  hRvzvejZfRQWOXBdgaSSO6Am44oU_s3JrHmuL6gQTaS4CFhqBVn3rw6fXkdUxXdtT
  A1AxRO4HQnZvIXNgerErU4VCgM5KYMyFTNXaVWi3MwXbfDun6gEmGgDHAKxnHxffg
  Km-TbAPtSPm4vQ8yrPOrFuPZ0j1i91CdEQJBIfd2qRm4qCPc4r6KgupdaZhN67OHo
  p5KPVnxq9VXDzAS_6OqM_k5FcE-04txafWixyQOaQxfGo5qii7_x-furOb1SWI6ri
  Z42rrj_PUau5gtS_HKVz2SwR8MNhzpDgiCGl-KojON8EbKkSinyBer3jVnMqIRZvo
  NPoFVMl3at9QO2gjUlMQpAOgz6L5OcN0HgpxHxOQ47hCiQG-JlIqoAeFVqvU6sNDX
  C0NH4efsmROtNTVa01Uy4lL616KtbH2FChc2i3V6AiFcvHcpgBcDo2E5j6-yIhVZx
  mq_QIdmOpgjnzzJQD7TMUMowYx8Pc71R0RaikBSRYqxPGHMZz8MIEgdUQbWu8OhJy
  gb34GMGfwRYBfqElpTR_Fk6tfkKSFb6JgCntEzxbyp9PTRYmXzPBzz0YeQYc59b7a
  OsNxcmSBWqMK_Pbl7Q9SKSCpqqw3_neGIzr_HQDruLGi0zzKclvi595R6C0p_ZMnQ
  KJBxg0F-wzT_1wfaJFrKzqqE3hs9x1yD0Tf4Y_FYd-s-rHRatb-9_tkhThQQruKk8
  D-YtbBSNi_c_cMVkoAaTVNO1phq88hAfoq9rkfo2Y6ei32LVDP2QaxN0EsoXvwOgq
  xVfXAKsD2hViDkihXZNkjZA8TYG_1YSR-kieGDTCimHPORg15BrjGXwj4LkI6kT_8
  6ECrdFHmCjDrFIPvYgKhrNUjelsZVYFTlwRkXSaagMEQlQ1HtfApWF0FtKKPOMbV5
  qmWjT8ATmMxiubM2BojjfeYw-KNTUOXy-r5zN-w2h30v5hYK_0wgvLa2B-Pe-JxCy
  Ot-sbyfrd9HukOJy-ZO2JP6ILkVa8VYvRF4DgadGhyNoJSwHwjtRThPe8Ll0G018V
  zzSDj_EIotiXDSsrMju3eUUxxuJvejZXwKIEK9lFcNFJg6Pp6R_kZKP-qN4DzYWza
  3lg1e_ympaBj8Gn1jcJAjA6GdXbXsmgGa4A6snUfrbMEXHzlCBAVmwftATtD3kVjZ
  1h-_KAEE2u_CCV2fIHwIiPKpNYufMNQ5QzBLd-TmiHs207jpJ4RbgZtSKDDJGTqDR
  InxJc1C7k9sJXrdASwTVfPW5crrN8Zl0xSJ95IxeqTAcIF7RLyYOP2w86pwevRJCj
  gyUbXx8Wu-KovraCKlwWj4Rtx23NAxsLuyBeGbOmLulqJkWoj93-SBi4U5fqVg0Wb
  l4-Jf4yqxsJ1eTC7CsV-ewwzfn2CC2ZYtER44DL8dd5xd-t6igxzsrqI4GMbCP6Bu
  PFdtcgUNBhGwCLNbEttZXwMWEkNjnVfTGq9T5AO-leOTz7L3OOdG_AJ5AFgNHcDrk
  rUnW1ryIqZ0fpdl_b0Jg5dWo2Sb2ouaHE6bIQAFDd77rp3u-c63EYNzoVKskRuWrH
  9lM8Tk7k5BYiq91eYv3IADGAYgFT0B42pFk2e1RFWM0acfI5-9XHOHolg4KsZ41ir
  lVy8ju9V4T0bOTafuUB3Xuv9qIqZR-B-Ryi4sRULkb0l2YLsw4v4u6DKCTXpizdHt
  oBv66R5VYQIaRndUhZ0gc5pKuT9CrgsTrggz22qxAUvpPe2GEfdmKJ_m_oCiEFQ_i
  lgdsIjGoG8ap311UxoUNhNFQOPPlnGBxL6AlLqPF9-9aQmH0dNbuo5IkC8Oz8F4tu
  TAeNHKxX1-RdGa9i5SKmWECOzCbkcoH2baPa__o_dkDuR-pWedTjtInmPbCVnxtIP
  U6ihXKVePqR0LVOqj36zq-lNfYqoSm21MsVRmoMgJmRf9RSW7fmCtKXmeUTNqfmbm
  5AWuLzPpi7IA1yLoj6b_5kM5XoRjAZJSusv6thEiNo1jqHm_Wepp0judb6iYSx7gc
  qSX1LNzSyfLNJBs7WuQaNQzh41c-UYuAAaqvIw3G7FBEHx8btEi9ZrmjCN0Lecff9
  DlFgJ2xSUTeYq404rDDlMr-HVVHHm3bfGrY4xfGR-AjlwqvobnIH_CT2-XVBu6ks8
  cXSeIX3sTnORlfQAVrAJLdiMisDjWuBkWmiJd9j3QDNEaWUAmlCIEVfYKTM9UjyNj
  mnEYspvC1X2e8i6Od4mRthjHHTlNYVNSXNP3-IcFAxc5nKPUDmz8Rv5vTaYp0q6zd
  tEXCxH3jQs-HCUwFnEd9u2ICM3RwBhShfLcuGtVt5RSrUzI-muriQ9QxNh3hvuM_L
  b8WRCew5eYLfxkomgRhvhZ1TwDjxKwxejCKJfpibVTMYpZkw9HY1byskiqyRqkwH7
  jkcDpViFaCj4X4GfKf9E4Jb-LmXIJUXcbsmFCoCnhhH7lKvXUOx4qupSuU3zZYXIC
  yfsEB5gwBr-KhzFbr6g1utlk4dCWEKVw9wFA3MjkuFFj4vulh7KJEdnYtaFEUlDsN
  SDpriUlTzP2n-ZFiiYLV4WA2SWE-jBQ5oUOk7VRNabBfCP1TOJ-uLMHAOLQQWpkeh
  V8mfJuniQsBuOZ9N4dhOBZ-D-Xi5uWyMj9ZngpYEB9BM-CiUM491FEsLKSFFmGo77
  VGoA4ErDW8oalomfv1IiSOHzqnwan15Vm30_ukHCM9_tueCa4AS-Q1AUvJ5ZG9hWh
  YmydPfDEUz-LVBAHbiPsYVW1SrEm9iCI8W0gO2xeF8xwoLXS4fb2rJfLrefHF8k7x
  1WsPtPPGJWHubn71xQPys9_MXWfwBfNhI7bkMWhfeh6sOFJVZOKl3WRGuuwIb0Awa
  AObRQjsw09HMERXuARLI052OQ9lHmyDyOvviwNJHs_5a9oYhatB67idrf6RyNeGol
  8sPNUqFN6FhpstiZNNDGHh5XDaAIBuvqN_cpqg3Mf4ftC7EXPIujk8RJCAIelypi-
  TNlzgVU9MTbm57Q1AFewHD1NMHH4nJHJQJdS7Gctl6bMYx71uGPpkQP_YTxxW6nRF
  ItKgAYFEN8-rvNJ4aqVCYpsq54wO9bp3dQJoDqEpmqhUXSLLNIW7s_PI7pM502VDo
  D88wssyw7B6UUejbqolf8V5ko0duOqgglYM3qsFAdLeXyDe-HBFXpCcio7T3aUH3D
  pg2Au_1b21ut-47PZ2XrhNqAe2mzY_Oix33V4MR2r2VcFFFzqnSY9JuHzoVVmELkn
  xGpPExfqoyhGSdvqIUvL11SctOKbj1hMg2t3wSm7cjmUEL_HszKGgqbwXem0NV3A_
  uWWg2eGOCnWdrYpX2yH4PQDZdvGEuIMPD8nQWRDaMXBRVLc90sKUbK51OFNpifoGq
  xTDDVuHptNqmHS90o_qzqFgfs9XkIIkUa5MiKyXuvl_5wG1O6JlDg31J6GsidRK6K
  Cwac6uJFsmEzx_KDfDNpZ3mecB9rHcBjKNx7DfATMMWU2X65oo7qyrwhoaZ8MMgrb
  9s-Xwfj13wWiKzl1wBkiA_j-JsJAT0eGYiujBanBu_XGFDEoiN-e_IG2VujFj-nZI
  6t1bMurtNL8zwcB-mo_xxw3cjumUtFph0QEZV4TV_Sa_toKucJP1WySmXu1kmOuqh
  EFScJ-SAfZHiItpSNm6zxiE-g8V-WX6Cwukl0-yMhmvIZxAj_9Md43yrQbCNqKbes
  irDMlqep-x4p-Blc08TM5WvWBrDln2qpfD6zlibYSh8QEWhdnY5WUaPs00pWno18a
  EX_Qi0Ze2sVlg9DDT_FUIcHbzDUkdxeuiJVZ5Vd3onbW2DADUke_KjnxU0jDJku_X
  VcouUK5ITVuSFEqBJb7buNB2Ua_xLSiepyZtNYKnwTmiQii4orBNuLYzl42G7Y5dm
  rrgcIypVGHW15dYk1JrBKQKVk22pxkwXH5eJlHfX98b1dDRUpt1kTheRT8KSZb0_Q
  rPTwNusH12FTHPKhf88i8Z0_LNwt-Gnzm9-nlvAAv6YE-Itz_ZMhxBAKnWz5U0JYt
  Siwb5dCgD9KT_6at8Fg-udKZQJHVEjSd-oZ3B-4TgFAdrR2lLDvO5FWKWksHV67jS
  bTUrrLLn_7PgHwGZGOxRaWJ5bMNRZmep0ADi8_lbHRU-nmpBlrs2o88YEsJMe_BcD
  M_LfdXReqd3Of-XIp-Fq5F358FIBZAhGXmzRHUI1cNl13krLfqbUnMuBVlU3AyPka
  vhY_G9W5MgvKDA4ZJuBmZZlOY0pjMpIfRiGNjN2MKQoyBp0Gm8SDCbTwMk2K_gQ4q
  F9fwX2Mr0w8uZpMvJlr3QkiBKzpjuatHfuKc5PJL8l_ET0cpr_ncEv8zZZnNyEnbq
  fRxoMKkBSn98Eus8JN8los2v6W4wOIQG8yuwtwstIzAcky-avjubZhI_Ie_OjxqNJ
  Q2kCx3veOsYOKp3cVZ8fCavZxZIf5Nir4yK1ipTtT-7dSNT0qHIE5R1dIjTkzFCT0
  FhOcNc3AareOFZ2uvOaCAraA2JqAxHJFhKMReZa7ku0SZKGPcdK3yQsYAaLqYRTU0
  5N-BwJwDK817D9YnyL0tGA9EW5CltdZgyjpb-qWmqWLgQRi2SFQM2SL5LK6ivkRf2
  _RsypqdqhfUe06QbZPRx7lgArKJkRConRLHDzSnh6EOYrIV9_CC2ucyoKEx6DFFrJ
  hVAE5l1IqGpdj7oeRhjfMMTwNHCpd-3ChQsi9Yzrq2mbcKTgT7ZxkmqSL0hYCJZ5D
  K7jeSeeHP6VFpALg1iIuwa0tNHsK1jLz24f28bPEa3TG375D2lzh3uMMm5aBvd5rf
  qfeLq9du7Kx2QbXDJxZcWSoZmF4eSewFd8Pieonu0SFBfsHLIKQr7ax2al3xRKDcH
  douXqS3SpiFSFFIgvZ5CFTN3mOMK5m3O82xF7M6rKpdtb418VUthA-w4O8hnNckKY
  JRuL5IIgTyBHdJ4OpqYK-fjE3CQhLo9cHY8bWEcvdb0nmKGc9ojVtsHzLhbG0HHJB
  D3dK6CzwJ18Vix09h4KwXE0VL0gjQUKRKcdf6WYNtddX4XcALVccYp3XOb8M-0_ck
  k7EfSEpRHNtl8F5ybzGmey_c8aLUm1bnOoBP_p22MYxhi2M_D-yzxSrbU8BhmTc-T
  I-6WVJRZ91O0R_aCPwzp4DQ8NvA_cyDYG7j77BDndkfQpJsDyd2Vc1kif7erYvOjE
  xUL6EJeIyoAd0H9hmZvCAKZ5pfUchAE3vscRMc88bvm3m4GRKH7B-Ct19AlhaeWW4
  8rqoJ7td6lhHk-Exr-qy3DvTfjrWyqLjqf5fVqylCvnO4DaAhAy9Woyj5gELciWz_
  fuFSgOY_EmLI8ZhMH1PGeLL-P2HEq9trtJ80Rl1FSk0qu9LyFErGO5doSKrSHbDRR
  Pgc2xDIqv-6z6aGsQobJHEw_3OP_Fc0HdbXDgJOQNdYxf2qdgM-QiMP-ftvcvJULa
  kutb6ubL3QOixgw9DnAzujot8ouYY2iUvoyTR4zBAgEw0N0n0iSSsVhizoiteR_BR
  hTFnW5b5iwKg7zVMVHRYlwZ2AHQmKpmVLale0lbmvfJgix9zJxITsffeFjYH2l7K2
  sj4SjkGo7xjnFogR9fkeJEi9OA",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MBLM-W4XU-5LMK-3REN-25WP-GWFU-EKTV",
              "signature":"-8q1mfYHPohkD-1xvOBQeBx4SP0ovlNAdQ9BLi
  1oBT0EoyBpp5JjVQsYmt5SjT8IlDPrFYhY-i0ADGNwp4eRd4-YJQWP4Ve7UUrT1sa
  0z9XG2Uqy5yHUphanEeVSQBt2FsL0ic_T3vWuEMeskgwgST4A"}
            ],
          "WitnessValue":"LGOJGUpHv5pnAXhduucSdDttx5hgNn-BPHgmLZM
  tdXY",
          "PayloadDigest":"tLploKyJytwlRWzj9b2_3-2N8xP_zF3yl9iMNQ
  FJkM2fngjYz966HvsqpY3DDT0LfhdpO23LNOMclo-T48ve3A"}
        ],
      "ApplicationEntries":[{
          "ApplicationEntrySsh":{
            "EnvelopedActivation":[{
                "enc":"A256CBC",
                "kid":"EBQG-P44J-7LYA-U25R-XKTR-VMQL-DD7N",
                "Salt":"C9QE6haR6qRnZBJgR6xeqQ",
                "recipients":[{
                    "kid":"MB43-DZPU-FNVQ-M7EN-AY72-EGLR-3NV5",
                    "epk":{
                      "PublicKeyECDH":{
                        "crv":"X448",
                        "Public":"tr901nxvkkptrL1eS5tgbCJTlheQRh9
  H9-FLe-OxIMJznI5T_DvGZDPl6YDMxbEUp6AttYhFbRqA"}},
                    "wmk":"FuCJqIica6IVxkZSuCzP5Bp35Z-lpUT3Re7IEX
  bmjjEYrj-nswtoSg"}
                  ],
                "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3
  RpdmF0aW9uQXBwbGljYXRpb25Tc2giLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1
  tL29iamVjdCIsCiAgIkNyZWF0ZWQiOiAiMjAyNC0xMC0wM1QxNDo1NzoxM1oifQ"},
              "RJc4v-hLMfn96gPIqN836OdIhM_EbtqpOvocULZMc4VgP60mXc
  QasXoZHoWeeZJc_gGtStxtuJwxSilbOsonVU2z03MT2xhKMSuoF4OguuP9XGcYllH
  E3kO_T1eVkCuOti8eoI4cl2g6mTx-h2jZ2r68cwSDVQ7uCkKjIakosqFpPNnY7xWq
  n9p6G1baUCvUkZ5J5RwwfinBN6Cg2WEzfbMQNU_7VZFne9Uaw5oSpdGYh9Kjl6LVA
  pRa3ZhsMXxpE2kE1qvMRwzHTRDu7miuvkIiXEs1ib0aNUsXoklAITE2Xw86mq4rWu
  ORL8mHOLdiJIYqszs8q08fhgn3KzLSXVnNWBOcM6uPJ2gJFnQak6yl3yo2Dv9vfEn
  Q7JUJmf2JeEWvGAoxkj2w_oknxN_IfAfObXD0TQOwUNJf2PJQVXQnPhm9IIKhHiLY
  8agtpr3whWrNsSy3qLt7a_1tnJdnAG60VMM-gTtPY9qaiO1RDxpVPythTfUPL1ll4
  EOHln8MHjiAPOBiXWFlZT3_Z6uVlyKGCSkuxtP-xNwCxj2rczXtIrtX4IZXUJqTK1
  gvT4SDVoSndoIbX-auktuwc4mQEz8zO1iWkeAcN3MAoJ3eArbZmirL2VUCDC0ZWFd
  0xQ486Od9lBTgXQsMrGeLjX11gWRPctLreRWn1IC0BbT9hpOFsv7doWi8gBAAN6bg
  CUmaUCWj59umEfuzP6rGtuHiEDMjBlAebyLjO8fHK4w0k7nfpZ9pCZI-Mk2KL7-DL
  gxmFpcKtZ3nv58c6UrW-EYIJ4gQPgxCJg1RL-BZb8IFriRDiFHEXr2Y7hCgbiGQGm
  7HbH-qpXF6Qp5I3OZn-em9ZljeOZadqiBGfLxiAXzWTlfJqVAMltSvMwJ39EIPj2c
  Scv187Os3UXOq4_lvLt_ZR3c3qcu8A17wqOUFUQXz2FNWLsdGzomWmKZz9o4GSF5f
  JFuSrGLUD08mksfyZeTZDuzlK8PR-wHZ8re7oY9D77JEHE5R5IY1P-R0qVQw0xXlq
  eT3TFHWMaagOkc0GY9Xs7uAv-hAAsdhUWtzUkhBYENKPQt2vYUHlgYV3sUrNaIitd
  VrW6hT2dCl3GII0BKuYArLzUHUFshE_QuRVzk9DmUbkNugexs0CckLjol5wlfOPep
  oNS5VXtFbP_jF1bJ3W4RYa0F0UA3f2Pc7WBUcASVv8bsRa_dUQNrdg7r8JWPv8vOp
  bd3gU_IsqRdLTi2l9omGoms0pM6mUVAIm6s70GcUg0T2bkgzqCpVVIc_4yBu8WKav
  l5nGWMYkK0Y-RvOH8fEF-5AUDkapIYwyBO3itn4I4WUmrj09qhz3yrIhouLF3HeuV
  Qaw1ONhJGMtpxlXTuklXv9TuvoSwXAyalmcsap0YYfUR7SOq0fgrtOpU1TwtjxDHw
  Rf_rx-oWqrOxN6lcD9tUZ7pTKNuo6ziJGZSjtwQ8LGeX6ICF3gux0vAbFu5ZeUxur
  186dEbusBK3PS1dCSWMpbvLQrHbUhDOUV_nAvXyA2cnFvCfGR1_PYQW5foda_wcu2
  F7rtNrDsQRtetlsVWXqhMZBnfcOoQu86EN2lCZWnVXZK0WlEbqUJiLmVXerQYxGtR
  xZJDwwSS6Et0ogco7NIvio7jHzrqM9xYZHRVh5bn4kYCelnKEo6Rmotq-jWRHFR41
  _pAUMr5iOn32a1Nr7AkFWOtty4orSBo9OaY7gYYy-z0kkflBJACjn4mG8s5T_YCxt
  fPLvkovRG85DW7fjWgfOVgg0Vpd6SsaBaeLPjGKdiYt18jY6uPKLl1wz6ceC-2JWh
  VxaBsQPEx7v3bjDyD2v0Jl9x8xGWZUktV60MAT3S7-yijJgmiwn5FmUJ4O0by_XyV
  oilkJNiVoIntzs_a8iCejf3upXOMO3H3BvwzBd-qUMw2GbMDdglomBZzvj76OgpXF
  tgnU-0kBh1Ojsg9W8QjfRffinP20-NMYF8SE8by6V-M7ocJa6l-kd3gm5-H3OyzHk
  Cvd-Apr5TEETk3Csuw98DDG31cVrrGetfkpD6HeAdUuJCYvnYAqEelE99Ir5hAi4i
  zPJJLoA2MXH7nXAsxKJubyDQE5YvpJZ-mlLCAynpmGeszmNztgGFL8dmsTWmYjxAp
  _3IBPd0W-hzY4qyMuznkiQ-tf41mbWCSv6n_FX0kmjzXNhRVLbCOujKS076YKkFyv
  bthSmI1b5vg-mQmnNQwbfbQp6LMfwXPg4YtHS0Ud0Xwu8mqLft9i6Y1TOL2U54aGM
  zTpe3TC8xtJ_g1urxBoI2DxQM7fmy3krTGs4TaaFLAU3L0YvOiV1UpjQwxSbmoqkt
  qMstJQJQC6lzmkSS4xuTE8QO61QNcyZFDEyS2iK6l2OchXqwUnKKpUmMOo2IllTCE
  BnPdPvjTptgMVBen1GHLAMaBMuuIrBr5T30UF9gfu1QIdH2rZOugamROi2xPNgPa_
  9R7CMcKjA4c8C-nFhgdqlEfGvX8ADjRhI-LLi-geGycWvzGh_0uwqu90aINueJdZK
  KnMc6HFmklesafgM9r5R3UC9uVOkgQV_IUj9u4ugqfz0GnLjvMiVQDQ4izEIE7Efq
  iuxDapBje3tcseN3eQPcthDigie-kB3_cS_-tSZW_hHbCPC9MfQ8Xr_9WOMdbsEAv
  bQjnHL8493breg044cQn100g6gm7EPIJJj2qk_5Ww_Cl3BC_C01GjYM_BR8m1eMnU
  Gwfkw1DwtCCQkXiGmoBVQDyL3qpeZIP6QzwfR0iYYWRX2OTDm2AsdLkdr4U0pHAM2
  tFQr3rWHWnpGkrejMJmPB3RIS6aLw_48qFyNQZnFUmZMfcXy6QbOorp3Xo-cMrfwl
  HZCKrEAJtafxt7EJKSG94TDF6Vi7Imj1BKlHD5y3AIR6emDw-II1ExWB-WiYZ8XUI
  PkTFQy6gDIqeVgkKC_TABQIyhxAPsykldBzYqF4E62OKGrQs4O13fcIDXzWF4q2xe
  sHejt533QGd2rapygyQJxb6Zl68HvLtA8t3A0_b-d-J2AK1VqofgVlaTRhmve38ol
  JxL13E4ZtEb23EFDFo7ACS3qVIY0LO3ndpYSNhDPhhjoxvDK17Pz2GXz-iQiAVY4C
  tu98zpxEmakSkznhh1qXW9Gm6hAmroUTHDgSPeJbl8MidayOjUKWY9VMjskX6Zynu
  wUOTMKty1zc9CI9IFIvv6L_CV2XNV3eRkcvmeHhPELhl9_mpbFGph-EvL5d_mGejh
  ILZHKnnGvCY14-D-1LGTslfeNHH-SYDYMdiaXglAnlOJOoCbVzFlaoONPwme6MqvI
  vVbGFavphkj0iNoxFtds57am4BTn"
              ],
            "Identifier":"MAYH-ANT7-SOJP-RKD5-7RBX-F4E6-LTN3"}}
        ]},
    "MessageId":"MDB6-5636-G67N-7G3K-YZWM-EUJ2-R3A4"}}
~~~~

### Phase 4

The device periodically polls for completion of the connection request using the
Complete transaction.

To provide a final check on the process, the command line tool presents the UDF of 
the account profile to which the device has connected if successful:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MBQN-RX3S-JAXD-GPDP-U3HD-PAOR-7ZVF
   Account = alice@example.com
   Account UDF = MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
<cmd>Alice3> meshman account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MDB6-5636-G67N-7G3K-YZWM-EUJ2-R3A4"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

