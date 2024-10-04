
### Phase 1:


~~~~
<div="terminal">
<cmd>Alice> meshman account pin /threshold
<rsp>PIN=ADPP-WZ47-R74B-4IJV-G7QF-KLLQ-N4
 (Expires=2024-10-05T01:04:39Z)
</div>
~~~~

The registration of this PIN value was shown earlier in section $$$

The URI containing the account address and PIN is:

~~~~
mcd://alice@example.com/ADPP-WZ47-R74B-4IJV-G7QF-KLLQ-N4
~~~~

### Phase 2:

The onboarding device scans the QR code to obtain the account address and PIN code.
The PIN code is used to authenticate a connection request:


~~~~
<div="terminal">
<cmd>Alice3> meshman device request alice@example.com /pin ^
    ADPP-WZ47-R74B-4IJV-G7QF-KLLQ-N4
<rsp>   Device UDF = MBQJ-ZMG4-QN7C-E4AL-HPH6-FW26-JJVF
   Witness value = 7OEH-LCAH-B226-XXBQ-QDIQ-C35C-L4UV
</div>
~~~~

The device generates a RequestConnect message as follows:


~~~~
{
  "RequestConnection":{
    "AccountAddress":"alice@example.com",
    "AuthenticatedData":[{
        "EnvelopeId":"MBQJ-ZMG4-QN7C-E4AL-HPH6-FW26-JJVF",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFKLVpNRzQtUU
  43Qy1FNEFMLUhQSDYtRlcyNi1KSlZGIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDI0LTEwLTA0VDAxOjA0OjM5WiJ9",
        "dig":"S512"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIkVuY3J5cHRpb24iOiB7Ci
  AgICAgICJVZGYiOiAiTUNGRS03SjdULTNaVDctN1BUUi1IMkdQLTNVVlotSUxJSCI
  sCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlF
  Q0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiclY3dllmZURYZEgtYUhQcVc0RnNyNkxfTlkyY0cxY2VIcW9tUHN5LXdOR0
  JTQkdsSll1egogIDRwWjMzaWQ5WnNoQ1RKOXhuaVRoSUZzQSJ9fX0sCiAgICAiU2l
  nbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DTlMtNjJBWS03WkVDLU80TTMtVzVH
  TS0yM05ULUc1WEkiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogIC
  AgICAgICAgIlB1YmxpYyI6ICIyTHhTcnZuRWZxR2p5OG9jWjZ1TklRd3A2RjA1UHl
  PV2N5dWdGOUF1R2I3N2wyZGJDa3hxCiAgMUp1d3dpTEpHc3VOSkpBTzRkb1B5TjBB
  In19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQjNOL
  UxGRzItSlFZRS1QT0RGLTJINVotSzdPNS1XMlA2IiwKICAgICAgIlB1YmxpY1Bhcm
  FtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICA
  iY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJTMTdSdTh1TGZCUGo3
  OEo2RVozdFFzdGQ5ZHlQb3NGWVVWbHJmbjBrRTZVLUhTY25nVTZ4CiAgUmJ6bWJwd
  DhVRUtQeVhnMkd5ak9iTjZBIn19fSwKICAgICJSb290VWRmcyI6IFsiWUgtWGFBZH
  FoTV9NQ0hRcGprQkIxcEtTSF9OcVFrdEd0ckd6SFNDdzU0clZ6dkVFLVYKICBlRy1
  ZNS05a2djMjU3ZGhmNFZ0WDVybUdhNFlnSDkxX0stVUEiXX19",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MB7Z-O2AH-NKCM-7TAI-OQUY-4QCB-22JJ",
            "SignatureKey":{
              "PublicKeyECDH":{
                "crv":"Ed448",
                "Public":"TOaWWYMlpgu2Ml9jxxFybNS4yec8S37kI07h7Pd
  kRdcP1cME1imKh2hsty19exvWwZVsyviEIEoA"}},
            "signature":"yFWBqQZ6ML9_xKTkt0-zrS3fQoe5GcVDayADvOgi
  BQg7ZjY7VqYImAF3KWP4JVKfJsGNZqgcXHqAkma9FBVMYy5-WRkxqS6_R0HA2mOhm
  7R_nv59iIs5vl7eGtCPx2OLuMQB6EUoFsqiGjd1HLIQNg8A"}
          ],
        "PayloadDigest":"kx3123U_uvalDOkjWkVgOdOYbN5gxnOyyyGVcwHA
  RgMRd9-FyR8lb56So1by3Az83O4cgQ_gdMqk_8tFL4vHTA"}
      ],
    "ClientNonce":"W1rKNCK3cYzjw1EprF-WQg",
    "PinId":"ACCL-KIFZ-YH2G-WHPU-VGJJ-IGGW-4BUL",
    "PinWitness":"O34lakdschAyzxvPXiExX9691jKOOE518rzPTiJPy4EMgbk
  xuhLPjLu596s9zJ_9gLzI4kURnaSyXAjFNUShig",
    "MessageId":"NDUS-PL7A-ONJE-KT72-EG3L-Y35J-K6AK"}}
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
        "EnvelopeId":"MD5H-FDHG-TVRG-BQHJ-76J7-UNB6-LRZR",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORFVTLVBMN0EtT0
  5KRS1LVDcyLUVHM0wtWTM1Si1LNkFLIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIs
  CiAgIkNyZWF0ZWQiOiAiMjAyNC0xMC0wNFQwMTowNDozOVoifQ"},
      "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJBY2NvdW50QWRkcm
  VzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiQXV0aGVudGljYXRlZERhdGE
  iOiBbewogICAgICAgICJFbnZlbG9wZUlkIjogIk1CUUotWk1HNC1RTjdDLUU0QUwt
  SFBINi1GVzI2LUpKVkYiLAogICAgICAgICJDb250ZW50TWV0YURhdGEiOiAiZXdvZ
  0lDSlZibWx4ZFdWSlpDSTZJQ0pOUWxGS0xWcE5SelF0VVU0M1F5MQogIEZORUZNTF
  VoUVNEWXRSbGN5TmkxS1NsWkdJaXdLSUNBaVRXVnpjMkZuWlZSNWNHVWlPaUFpVUh
  KdlptbHNaCiAgVVJsZG1salpTSXNDaUFnSW1OMGVTSTZJQ0poY0hCc2FXTmhkR2x2
  Ymk5dGJXMHZiMkpxWldOMElpd0tJQ0EKICBpUTNKbFlYUmxaQ0k2SUNJeU1ESTBMV
  EV3TFRBMFZEQXhPakEwT2pNNVdpSjkiLAogICAgICAgICJkaWciOiAiUzUxMiJ9LA
  ogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWtWdVk
  zSjVjSFJwYjI0aU9pQgogIDdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVTkdSUzAzU2pk
  VUxUTmFWRGN0TjFCVVVpMUlNa2RRTFROVlZsb3RTCiAgVXhKU0NJc0NpQWdJQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0oKIC
  BzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE
  0SWl3S0lDQWdJQ0FnSQogIENBZ0lDSlFkV0pzYVdNaU9pQWljbFkzZGxsbVpVUlla
  RWd0WVVoUWNWYzBSbk55Tmt4ZlRsa3lZMGN4WTJWCiAgSWNXOXRVSE41TFhkT1IwS
  lRRa2RzU2xsMWVnb2dJRFJ3V2pNemFXUTVXbk5vUTFSS09YaHVhVlJvU1VaelEKIC
  BTSjlmWDBzQ2lBZ0lDQWlVMmxuYm1GMGRYSmxJam9nZXdvZ0lDQWdJQ0FpVldSbUl
  qb2dJazFEVGxNdE5qSgogIEJXUzAzV2tWRExVODBUVE10VnpWSFRTMHlNMDVVTFVj
  MVdFa2lMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLS
  UNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKIC
  BnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk
  2SUNJeVRIaFRjblp1UgogIFdaeFIycDVPRzlqV2paMVRrbFJkM0EyUmpBMVVIbFBW
  Mk41ZFdkR09VRjFSMkkzTjJ3eVpHSkRhM2h4Q2lBCiAgZ01VcDFkM2RwVEVwSGMzV
  k9Ta3BCVHpSa2IxQjVUakJCSW4xOWZTd0tJQ0FnSUNKQmRYUm9aVzUwYVdOaGQKIC
  BHbHZiaUk2SUhzS0lDQWdJQ0FnSWxWa1ppSTZJQ0pOUWpOT0xVeEdSekl0U2xGWlJ
  TMVFUMFJHTFRKSU5WbwogIHRTemRQTlMxWE1sQTJJaXdLSUNBZ0lDQWdJbEIxWW14
  cFkxQmhjbUZ0WlhSbGNuTWlPaUI3Q2lBZ0lDQWdJCiAgQ0FnSWxCMVlteHBZMHRsZ
  VVWRFJFZ2lPaUI3Q2lBZ0lDQWdJQ0FnSUNBaVkzSjJJam9nSWxnME5EZ2lMQW8KIC
  BnSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKVE1UZFNkVGgxVEdaQ1VHbzNPRW8
  yUlZvemRGRnpkR1E1WgogIEhsUWIzTkdXVlZXYkhKbWJqQnJSVFpWTFVoVFkyNW5W
  VFo0Q2lBZ1VtSjZiV0p3ZERoVlJVdFFlVmhuTWtkCiAgNWFrOWlUalpCSW4xOWZTd
  0tJQ0FnSUNKU2IyOTBWV1JtY3lJNklGc2lXVWd0V0dGQlpIRm9UVjlOUTBoUmMKIC
  BHcHJRa0l4Y0V0VFNGOU9jVkZyZEVkMGNrZDZTRk5EZHpVMGNsWjZka1ZGTFZZS0l
  DQmxSeTFaTlMwNWEyZAogIGpNalUzWkdobU5GWjBXRFZ5YlVkaE5GbG5TRGt4WDBz
  dFZVRWlYWDE5IiwKICAgICAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgI
  CAgICAgICAgImFsZyI6ICJFRDQ0OCIsCiAgICAgICAgICAgICJraWQiOiAiTUI3Wi
  1PMkFILU5LQ00tN1RBSS1PUVVZLTRRQ0ItMjJKSiIsCiAgICAgICAgICAgICJTaWd
  uYXR1cmVLZXkiOiB7CiAgICAgICAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAg
  ICAgICAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICAgICAgICJQd
  WJsaWMiOiAiVE9hV1dZTWxwZ3UyTWw5anh4RnliTlM0eWVjOFMzN2tJMDdoN1Bka1
  JkY1AxY01FMWltSwogIGgyaHN0eTE5ZXh2V3daVnN5dmlFSUVvQSJ9fSwKICAgICA
  gICAgICAgInNpZ25hdHVyZSI6ICJ5RldCcVFaNk1MOV94S1RrdDAtenJTM2ZRb2U1
  R2NWRGF5QUR2T2dpQlFnN1pqWTdWCiAgcVlJbUFGM0tXUDRKVktmSnNHTlpxZ2NYS
  HFBa21hOUZCVk1ZeTUtV1JreHFTNl9SMEhBMm1PaG03Ul9udjUKICA5aUlzNXZsN2
  VHdENQeDJPTHVNUUI2RVVvRnNxaUdqZDFITElRTmc4QSJ9XSwKICAgICAgICAiUGF
  5bG9hZERpZ2VzdCI6ICJreDMxMjNVX3V2YWxET2tqV2tWZ09kT1liTjVneG5PeXl5
  R1Zjd0hBUmdNUmQKICA5LUZ5UjhsYjU2U28xYnkzQXo4M080Y2dRX2dkTXFrXzh0R
  kw0dkhUQSJ9XSwKICAgICJDbGllbnROb25jZSI6ICJXMXJLTkNLM2NZemp3MUVwck
  YtV1FnIiwKICAgICJQaW5JZCI6ICJBQ0NMLUtJRlotWUgyRy1XSFBVLVZHSkotSUd
  HVy00QlVMIiwKICAgICJQaW5XaXRuZXNzIjogIk8zNGxha2RzY2hBeXp4dlBYaUV4
  WDk2OTFqS09PRTUxOHJ6UFRpSlB5NEVNZ2JreAogIHVoTFBqTHU1OTZzOXpKXzlnT
  HpJNGtVUm5hU3lYQWpGTlVTaGlnIiwKICAgICJNZXNzYWdlSWQiOiAiTkRVUy1QTD
  dBLU9OSkUtS1Q3Mi1FRzNMLVkzNUotSzZBSyJ9fQ"
      ],
    "ServerNonce":"IyPItB8vCIm__N-C56npsw",
    "Witness":"7OEH-LCAH-B226-XXBQ-QDIQ-C35C-L4UV",
    "MessageId":"7OEH-LCAH-B226-XXBQ-QDIQ-C35C-L4UV"}}
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
<rsp>MessageID: 7OEH-LCAH-B226-XXBQ-QDIQ-C35C-L4UV
        Connection Request::
        MessageID: 7OEH-LCAH-B226-XXBQ-QDIQ-C35C-L4UV
        To:  From: 
        Device:  MBQJ-ZMG4-QN7C-E4AL-HPH6-FW26-JJVF
        Witness: 7OEH-LCAH-B226-XXBQ-QDIQ-C35C-L4UV
MessageID: NDN7-5NYH-LD43-4TCU-YJWW-Z37V-GYTG
MessageID: NDQ7-UANN-QSPT-CRYP-B4YY-4PNG-N2Z7
        Confirmation Request::
        MessageID: NDQ7-UANN-QSPT-CRYP-B4YY-4PNG-N2Z7
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NBJL-SNE5-XPQV-PO5I-RN52-SZHY-E4DZ
MessageID: NDCJ-UV2Z-2FNH-WOK3-46NP-M4PY-MMTJ
MessageID: NDIR-FXO6-NGSV-7UJL-5TOG-V3ON-2VPX
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
      "DeviceUdf":"MBQJ-ZMG4-QN7C-E4AL-HPH6-FW26-JJVF",
      "EnvelopedProfileUser":[{
          "EnvelopeId":"MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFCLTJIM0ot
  NlFLNi1aUkwzLVpQRlEtS1lDRy1MVEJVIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyNC0xMC0wNFQwMTowNDoyN1oifQ",
          "dig":"S512"},
        "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJDb21tb25TaWduYXR1cmUi
  OiB7CiAgICAgICJVZGYiOiAiTUJKQi1RUzdKLUFDWjItRlZNUC1FTFNBLUVXR1QtW
  DRZVyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaW
  NLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICA
  iUHVibGljIjogImV3UXdXN3YxUVR1R3dZbjNvZDBQQjNuWDZRQ3BJNHMtT0lxeDIw
  LVJSaXVGb283ekpOVGYKICAyRWszdjU1NXl1ME1STHZQdjZuVk1xOEEifX19LAogI
  CAgIkFjY291bnRBZGRyZXNzIjogImFsaWNlQGV4YW1wbGUuY29tIiwKICAgICJTZX
  J2aWNlVWRmIjogIk1CUUktUE1HQy02VzczLVhSNEEtWFpZNy1aM0tCLVJZUTUiLAo
  gICAgIkVzY3Jvd0VuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUNSNC1XTjYy
  LVZBSjUtVVMyRy1YVkdKLTIyUlQtVFlJUSIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydi
  I6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiMDBRYTQyREprdVFnWkZZLTh
  NUlhSLXFiRUxGZ3lIVGh1bUtKQWdvOXdVNDd1LXEzT1F3bgogIGh4dG1FaEFwWFo5
  dkYwc1JPZ1F5bkhFQSJ9fX0sCiAgICAiQWRtaW5pc3RyYXRvclNpZ25hdHVyZSI6I
  HsKICAgICAgIlVkZiI6ICJNQkpWLTRTVzYtT0hEUy1FV0RILVM1VFQtMkVVMi1JRk
  5aIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0t
  leUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAiZWROV1Y5Y0RPNExQX0d2ejZNZTAyb0U1Z1lPZkFrTnFWdy1oc090e
  G1mMFBxVHNpTlU1cgogIFdHcVdsSFVrdTM2ZzdGS1M0VUNsLUtjQSJ9fX0sCiAgIC
  AiQ29tbW9uRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNRFJBLVBVNDItTVF
  PTi0yQ1VULU9PNk4tSVFVQy1IRk5BIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  lg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICIta0V1MFRZc0dSZTBuU3dsNUk1Sl
  A5X3Ric1hXYjRlekY2aGVSaWVvOUZmUFV1c242alR6CiAgVWp3Yl9oV0JSdlZnY2k
  zWGVSSnZ6QUNBIn19fSwKICAgICJDb21tb25BdXRoZW50aWNhdGlvbiI6IHsKICAg
  ICAgIlVkZiI6ICJNQTZILUNRU0MtSVBEWi1WRkg0LVpDM0YtQzRLTC1ZTEpFIiwKI
  CAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDRE
  giOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI
  6ICJoMXp4dlhOejFHbTJkdkt0YkFHNmpjRHl4dnlwNi1QLWtjYWFUd1lORFVFd3Iw
  WWg4aGRTCiAgMDQ4ZTJncEE4cy0ydkxRcDdCY2tERkFBIn19fSwKICAgICJSb290V
  WRmcyI6IFsiWUdGMmZWZHpFUm9QYUFSamtFOU8zbjBHUTF1OGRhRkNTUnJqaFNhN3
  N1M1NISU1ZdGcKICBGb1FTT3BlRFNkQnBRTDlYX0dCYmxWRGlfU1M5OWx6dUdkcXc
  iXX19",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MBQX-M7KX-OMIR-UD3I-ARRZ-AT2O-3Z6Q",
              "SignatureKey":{
                "PublicKeyECDH":{
                  "crv":"Ed448",
                  "Public":"3HWyZRqTzcbVSn1Qm4H5Q40KeXdZrSf0KRuC7
  nO9CNZvTVosruTzeWt-6edu8m_ND7UzKIDQdogA"}},
              "signature":"X4lI312rfBhd3O__P2hnsSHvWvMyUBV6VvFO2L
  sMAB_7xTGuX4zJin-xZxja1zzF8-_2yNmPc3yA0RHTdmLSE4IX-VVq0rGmUf7NNTL
  wK9hZVKMNE6JsjoNi2mLgPck71x3aXCRzdixbcdo4GGU3MQ8A"}
            ],
          "PayloadDigest":"P1U6eigiDhwdTw6VYUBbJKmPeAiysET64HhZMK
  wNO-xQYDKUipt9YxpgVC-aVWipMfyyikAysf9B8zmNa2ba4g"}
        ],
      "EnvelopedProfileDevice":[{
          "EnvelopeId":"MBQJ-ZMG4-QN7C-E4AL-HPH6-FW26-JJVF",
          "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFKLVpNRzQt
  UU43Qy1FNEFMLUhQSDYtRlcyNi1KSlZGIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZ
  mlsZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKIC
  AiQ3JlYXRlZCI6ICIyMDI0LTEwLTA0VDAxOjA0OjM5WiJ9",
          "dig":"S512"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIkVuY3J5cHRpb24iOiB7
  CiAgICAgICJVZGYiOiAiTUNGRS03SjdULTNaVDctN1BUUi1IMkdQLTNVVlotSUxJS
  CIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZX
  lFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJ
  saWMiOiAiclY3dllmZURYZEgtYUhQcVc0RnNyNkxfTlkyY0cxY2VIcW9tUHN5LXdO
  R0JTQkdsSll1egogIDRwWjMzaWQ5WnNoQ1RKOXhuaVRoSUZzQSJ9fX0sCiAgICAiU
  2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DTlMtNjJBWS03WkVDLU80TTMtVz
  VHTS0yM05ULUc1WEkiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAog
  ICAgICAgICAgIlB1YmxpYyI6ICIyTHhTcnZuRWZxR2p5OG9jWjZ1TklRd3A2RjA1U
  HlPV2N5dWdGOUF1R2I3N2wyZGJDa3hxCiAgMUp1d3dpTEpHc3VOSkpBTzRkb1B5Tj
  BBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQjN
  OLUxGRzItSlFZRS1QT0RGLTJINVotSzdPNS1XMlA2IiwKICAgICAgIlB1YmxpY1Bh
  cmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgI
  CAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJTMTdSdTh1TGZCUG
  o3OEo2RVozdFFzdGQ5ZHlQb3NGWVVWbHJmbjBrRTZVLUhTY25nVTZ4CiAgUmJ6bWJ
  wdDhVRUtQeVhnMkd5ak9iTjZBIn19fSwKICAgICJSb290VWRmcyI6IFsiWUgtWGFB
  ZHFoTV9NQ0hRcGprQkIxcEtTSF9OcVFrdEd0ckd6SFNDdzU0clZ6dkVFLVYKICBlR
  y1ZNS05a2djMjU3ZGhmNFZ0WDVybUdhNFlnSDkxX0stVUEiXX19",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MB7Z-O2AH-NKCM-7TAI-OQUY-4QCB-22JJ",
              "SignatureKey":{
                "PublicKeyECDH":{
                  "crv":"Ed448",
                  "Public":"TOaWWYMlpgu2Ml9jxxFybNS4yec8S37kI07h7
  PdkRdcP1cME1imKh2hsty19exvWwZVsyviEIEoA"}},
              "signature":"yFWBqQZ6ML9_xKTkt0-zrS3fQoe5GcVDayADvO
  giBQg7ZjY7VqYImAF3KWP4JVKfJsGNZqgcXHqAkma9FBVMYy5-WRkxqS6_R0HA2mO
  hm7R_nv59iIs5vl7eGtCPx2OLuMQB6EUoFsqiGjd1HLIQNg8A"}
            ],
          "PayloadDigest":"kx3123U_uvalDOkjWkVgOdOYbN5gxnOyyyGVcw
  HARgMRd9-FyR8lb56So1by3Az83O4cgQ_gdMqk_8tFL4vHTA"}
        ],
      "EnvelopedConnectionService":[{
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDI0LTEwLTA0VDAxOjA0OjM5WiJ9",
          "dig":"S512"},
        "e7QRQ29ubmVjdGlvblNlcnZpY2V7tApQcm9maWxlVWRmgCJNQlFCLTJI
  M0otNlFLNi1aUkwzLVpQRlEtS1lDRy1MVEJVtA5BdXRoZW50aWNhdGlvbnu0A1VkZ
  oAiTUMyRi1NQ0hYLUs3R0gtR1lRNy0zWDdQLU02MkctWFYzQ7QQUHVibGljUGFyYW
  1ldGVyc3u0DVB1YmxpY0tleUVDREh7tANjcnaABFg0NDi0BlB1YmxpY4g5qC5jTlO
  NZH_bHLAeGNfWPOgl9Q0bkvdC8RabsmLMmgkXJ2L7108dSjwfIhcSmmtl8Rd85Rho
  aByAfX19fX0",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MBJV-4SW6-OHDS-EWDH-S5TT-2EU2-IFNZ",
              "signature":"4y0pJNoLICFTzNSfsQA5ojwDPlMmE6EsnbyV7I
  f2CKeWL5Nn90gg6xBDm08_m8ir36zUQuewAeIAgySCDd0k9u0INtieWcs6sysSoW_
  LIBX8vBxz7zfZCtxzqjRO6N1gmajx7JABYZOu7VgX-1zSsyoA"}
            ],
          "PayloadDigest":"o9U51cS4Z7I5MMc1E0jcB3hvPxJVKp-vRTPyEw
  f_g6Ih4TuPoQ52K6G2FRIM69kSWlMiRr4F1Wex1VZjg3suLw"}
        ],
      "EnvelopedConnectionDevice":[{
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0
  aW9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjQtMTAtMDRUMDE6MDQ6MzlaIn0",
          "dig":"S512"},
        "e7QQQ29ubmVjdGlvbkRldmljZXu0BVJvbGVzW4AJdGhyZXNob2xkXbQJ
  U2lnbmF0dXJle7QDVWRmgCJNQTJaLVJONEEtQjZCUi1DMlhDLU5GU0wtVFg2VC1WV
  0sztBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAFRWQ0ND
  i0BlB1YmxpY4g5hJvjKAzXHJdoPG2_iWPxeyUkcuSb4nbM2e2h9GE0fJvOz1ZjibZ
  dfIN1EUzFgUNW3SAaBV3vWEEAfX19tApFbmNyeXB0aW9ue7QDVWRmgCJNQVdRLUUz
  MjYtUDYyVi1MWk9CLTI3MlctSEVKNC1FN1NZtBBQdWJsaWNQYXJhbWV0ZXJze7QNU
  HVibGljS2V5RUNESHu0A2NydoAEWDQ0OLQGUHVibGljiDkJuyTtvb3s9TOPIPLf1r
  xIwJISrXDksm2NGTjyyDf7BvQGR7mEFRcYjo-kzuAAsRj1daOAyTh-GQB9fX20ClB
  yb2ZpbGVVZGaAIk1CUUItMkgzSi02UUs2LVpSTDMtWlBGUS1LWUNHLUxUQlW0DkF1
  dGhlbnRpY2F0aW9ue7QDVWRmgCJNQzJGLU1DSFgtSzdHSC1HWVE3LTNYN1AtTTYyR
  y1YVjNDtBBQdWJsaWNQYXJhbWV0ZXJze7QNUHVibGljS2V5RUNESHu0A2NydoAEWD
  Q0OLQGUHVibGljiDmoLmNOU41kf9scsB4Y19Y86CX1DRuS90LxFpuyYsyaCRcnYvv
  XTx1KPB8iFxKaa2XxF3zlGGhoHIB9fX19fQ",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MBJV-4SW6-OHDS-EWDH-S5TT-2EU2-IFNZ",
              "signature":"xX6y9Aej0mYFbexsBvSruqKcASH1A0eSL-ZJvA
  z1H2ig4T6kYrcJiDlX1vDmdtpwyi7e0mzN3tgAyj6ibmfQ8YO3T11iawZxhRZVLo3
  xbTrVqWn9kR1mKNB3U49GYf-QAn0YLhUU2TtHeKCTRhZGvT4A"}
            ],
          "PayloadDigest":"LheIhlxYNDxfsX49CpX6aiZthg9MTWY92BVits
  CUR-kLJT0oGz6yXQtpBbwkZkdux4VeYIQOI91GImGfc1ohmg"}
        ],
      "EnvelopedActivationAccount":[{
          "enc":"A256CBC",
          "kid":"EBQE-IF2D-Z7FB-H3XS-N42F-POEO-CW4Y",
          "Salt":"2RfhBmA9nufUczhvgW2d8A",
          "recipients":[{
              "kid":"MCFE-7J7T-3ZT7-7PTR-H2GP-3UVZ-ILIH",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"jCpvQ_yFwxpTOhh46DrnZC238wmQHjksBZjxz
  4CegfwagqOa4toDinNB-Tvkd-KhoQ7L6cedrUCA"}},
              "wmk":"MLRflKQ2KzX_JrInqs34NDRvBBdeDZ6VLenwGyZ8lQRW
  afdHnnuj5Q"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQWNjb3VudCIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKI
  CAiQ3JlYXRlZCI6ICIyMDI0LTEwLTA0VDAxOjA0OjM5WiJ9",
          "dig":"S512"},
        "tqfAsP698vAARTmSJTsO6juJNff6WsAroGL03j5SqVI6IFSd9JM-SIT9
  _DfZkIDREr5U_hExCK6BnJheqDUWHCAM1x7i4M78atkdOYnNHplITxzh8CQrgZ8NO
  k4mfUeQpU76q22WdA8e9TEPE0dm_EUrlVKDFkdVezK890EF_cPv8iHMJVhiqiqouy
  rzBG223zYe4jriYS7Qi6ErAA1RnospF50TzNc1IbYVnNN1X5InAeI7857jUM2q9tm
  8e8tZ",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MBJV-4SW6-OHDS-EWDH-S5TT-2EU2-IFNZ",
              "signature":"8NykszbRKibKxMos-8oyeJ2X09KfIo9dQIf2Nu
  crLKBdWcFtOP1Bujv6a7RPmd2BiUtFTKpS12wACwI_0XWADdGcNSFUA4iNqDo7g3J
  leRZqx1Z7f7jZgbAJ-rBn_Mef5Cj2nF5sIgoVER6OguyjGiMA"}
            ],
          "WitnessValue":"yglGE-4uqA7M1Hbx6ujkh0hjiOH06pEYvPGu_ZF
  ihgs",
          "PayloadDigest":"-pUs5NaVc8Oa298EuqKz1i2Pg4rbOyMlYNl_an
  eaTAaPdeChf5qW9uw3CqZ4Q6eLG7QS0Gb-9QWd_usmJVs_KQ"}
        ],
      "EnvelopedActivationCommon":[{
          "enc":"A256CBC",
          "kid":"EBQN-W3WN-SY55-YE5I-7CQP-M6U4-DKIM",
          "Salt":"5nxZYpbZ4_0hoUR6QzNjHg",
          "recipients":[{
              "kid":"MAWQ-E326-P62V-LZOB-272W-HEJ4-E7SY",
              "epk":{
                "PublicKeyECDH":{
                  "crv":"X448",
                  "Public":"ug1HIUQw7-7p0rp64tyJeSEkURSEeiBSC3yYD
  cF9I_Ba514LTiJT4r7Y_Rhv4o3uAqO0TnyFqfsA"}},
              "wmk":"4PWDxWFNUoAMoADBJKjCnCCJM8ZsWlVLV9Ppti8n4xlw
  OsCTd__j-g"}
            ],
          "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3RpdmF0
  aW9uQ29tbW9uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogI
  CJDcmVhdGVkIjogIjIwMjQtMTAtMDRUMDE6MDQ6MzlaIn0",
          "dig":"S512"},
        "Ij1VTLYIQFLwbudBJBT5hduTi7UByLK_3fZ65AaXVH3B91X7BjUTEf9X
  Mdfnw_EzDxS5v36aJVExJmP8ZLc4vFU5crmLOWt8F7MLpki3dkd5hcOfGZY9g6JtN
  ii-Uy58-bTfmMwFPSZxvJvM0GJuCoFG8DKAI8a6kwAPRdCCBzSSWiWGCYrK_l4GO4
  oNojwHRkMDnVv4-WH8FgFqkJjRIcmuYBZX6_p77n8fAbHE1EY73hkpY1_kcd3hLJQ
  ZND7kP5mn2ZeO_gd2dNXIm4z0dLzpwcfXOG3CUb0n7jEM0EVo0Yxu9IRFLe65Ezvv
  YAOT55cggDGj4a5jMbLFSzHvbzmfXhoxybb7XguHoo5mM3tCs_VOgYNmaYpcvBF3F
  WXcrHd7X-9R86iPBaNa1_CBf_zYDgFAJZ8Am_ydAurl9ap34447D4Vb-nZF0ptGF0
  22GvqtbIFnLGSPIfo_zBRszQVdzbMSDtlevO08SZQtGgXbUOVUgGAHs1obHJ4FfMG
  sXMUysO13Wk8mE71bd2gxSqtrVNdp-tC2O90o9hAiiASsYGG8G7olzkcqb18U6ts-
  XOa-3RtLsMSXW99Hf5CT-KJ5BCITndbHox39rPDpkFNsx1zxeBa-_LS6rQWqha2bp
  MM2Qn8i1PoOXwsKiWh2VKO_nv0ANY8A0e98q6PD6LZ0xtuz0SQW3TPKoiS4jjhK4X
  qEZmKWb_TkrhQt9Byq-W-eHCQKqjUHPFT0nY5PsFSC5K4D7c7c1f1SYz9i1acZXwC
  Z7VlSmf-g--BSr11xKzAEGMQdXxZ9Qk6aS2K-r5lRIWy9atq9tuuc9gJgSMZHiGLR
  Mu4H8vcfXGWBV49_lw86mZTqiKQF_k2XXGJeCDANNgHtWilwrUp9RjVCCixCJ8tdN
  vWyBbXpey0HGw54l4SsJQo8cSqSx1mpkjBfhUjWg6dYgaE3UPy9KdPwCk5piow5mD
  2SCzmCFhve08NTAGRM8KI2aGz-SQ9C8md4-BOSP_g8VTS2GzYzl09AfAMocwRabPe
  6tnUiAGMu1-erPjF72kJRVcN5GthwYkWz_MVKDX_upSZCI8FILhkF3KxGoCktyY9h
  nsR-ODHXWoi-QqdfaG94jK7-3S4WDeTzvpGZM3kQt_HCxFuKig08MOwi1E5uqY4rG
  4o2Wc0Z4a6AsEERiP-uYlgoJV9NED2DjYviGLa7xSo79IP6EDpa8C7FhlfFU1Emo5
  yZTJ6u-6Q42KlFrhtjxT11YF1RkTUaIOA4sK9wkszJ7hncjtZR6f8T52j6bfA3q3S
  fo00_aMHyqSsqwruqFjNo4KprELtKqe9d65vtN2lth09jegbhBWlz2x3PeP7lqcRG
  ufyjgePpqjXmQhShI81FE7SvP4Pf16EvInj4-UO4jags0ac042FqwQaC09ack4ZoV
  Da-0iBTm4Qf8Jd5uhIRnqbIQ0N5YCnQ4rM8bUU9xYdBHckNm0Pf2qXIKcTyM5uivJ
  bx8aitzoGQWyimfcJWcZKXApcDWi_vXNLZpwXvCxy_OccYT3GLk-DN65hpkYRRm5b
  o727Zb1qsAkjsiHCY_H5IuJz7FvQp6JIW6yCb_IoHbO9KSDSgt3EuYhT5xDo9r0q8
  V2W8w1pEjMDF0tw1FynJ17M1dE1-m3hybE6uKpVhnZrdBYvYnAUzprk1TNpIJ9P_y
  sfiniLIVe4NSpwoJ7PpOl5MLT6wKtG7sm8fa_bP4RspceTcq4VzveTI08OgZ_FeDA
  MGBD7Mtevf8UJBAPh1DNkNz350am6cfOK7s25BG36UzkoXrtappMEz5-Sw7EdSjaY
  zX9lfIOqHOEdwlNlPbMcf6wSHUAIUYNA0wJHOu1xo39aLw-kCmgxkODC3tLjce4k0
  _myBpab92Ndo_gpPfQV3kYffcvNQHt5AKd7Rodw5B_HNNr0ZZbLPaVCYKTpDRRPJC
  FoR6B7B1_BQjkGVBTPdLALHP5gfBO2fVfIBjEpiG4Fgivo71vd1nv0aC68gbbJk9L
  qM8sy3UyNlwT8kLccg_-iSFDETIfWwAtd3MterowZziTxShMoIXvG7UInTImiG6VJ
  4hkMmOkOOUrrGT9d0-dFmC4oVPsjtlNdhy5MWi7R1rOhUX7baxe4Z-Ht7CmI_-J-J
  c3gs9dNm3wHrJPicqimIbknQd5_bzTMMFNK2pn0qfeu0pHJJFbpDzob1Y34IDCJ_O
  fuTO4IJZRYYl_krC1GEZE2QuAaxmOJc3Vx3Vr7hk_2oFmhQnP-fsjmEO3fnlUSCyL
  Z_mou9s0eEiBeWHblEwS83lLcRP-8RbzfAQv09rPB0JlnFaQOoFkH6Cyi4PWv1k7q
  th38mudtvNR_kwohL7l-B6hXDdtfK2tWihdHJknUKD3PTgEzXzLGwprF_96xEDKRI
  Sxad4ZYBuu8dNbNSIYVZSxP6D5XZf2DJfKfaH4jMfsoA_yGgP33HSovBI4Sx_xHQq
  C30rHGQfvb7yDMn7_P3850AD7uQHBPeuoFQsp7lQjk6s2DqoW04B1QZcC1cF7QaXj
  8R9FPub3K21B8gMIko22RlDJcRsDSTQKc08IK6ugPT81sgsIxOgKXn9ifr_HlLpJk
  lWSOGhrH67HIK1LOqATCsx--GgOSJlj6MZRf3sYx-WhEDRTtt8hAF0CKuptaGJh2B
  ezDgA_Yqjm9UmAG0XgYG8AnVnI1nmLHl_MLKBJ76J2sRo4_Z8iTkINFKo9YsgLGzy
  PB5JHQVYRFB4TcXTtY_VcE5bah8_MQNS_xDf9RDdTXmvS96TYo853O6QtP_L38kka
  WkI1M5SKoQFrT_DbUMDcQyb6XJJGu7P9QatCO6snLnmy61fbaviYKjDyi00LOxUGF
  -1R2mcsfnBJUmuCvOLn61-aomGslbMuXsKg0Al9LOps2cglRue5wBpE5cVMCSDeOL
  E5xuxyHqjAJ7nZMBkJXU_LigCSliqp_EJNV-v2OUYEArsrihd47Yy4mro-z5M0JQP
  NIGUpjHDtZ9aUtfGUHKJPoynR0zzfvYl2vwDcv4MKCI3LGS1Tl71nCb1GEsoxO15O
  UiVEIhQcauEQJT2K0ATiWV-g0whExhgmHb7OXWMW_Q8aAP2g0M7lzPf0LqaeHVCBw
  VqybjIL3HI22RkKDXFj6ZebIIt554LeKSGxcMipRAcwTdha1bXTSjlV4HeuyvGllf
  NTct5GiHFzfM6TSEQEwSGz9IRebLZc8SPLdVs6GUJ8p_9YGKycRI38yQpjgYi6lNi
  ePIBq_w16oWX40FKQdRAeShK7jhz1dULOJE4UURCc_V2NNBpMHCNlPLroo4wYjAQS
  HLG9R8U9sRzsIM_PW8DtMxhkYKlgtWxzuXARqBpkWOISUOztVef1VQj-NYKpTaRbK
  QREpU_69YdOFGydTuv7Il7PBTdhYf0TO0Vt1WxS7syIUEpT738LnK-yzdUtwmxtbT
  TS7a3L-34SDktEfFQfKAlDhxV2Ttcbvd3VOHJHffMQpQkqGW-IJxBEasq7wCOHpkT
  uJDi1oXWJl7amnRJlyBzoRwNRCJzQp3GIMQrHYtdeKfDWyUfSotqYWfwwTUZ1aM8c
  n6F5V1ZlImt5MKR9JQn-eXprEFgBDgqzL42CPK4EpiFT3FmoAmaRFoGVWRPE9dp09
  kizGPLOsY46sOLs0KrlgGJKA-NT6_8VZYOWH3uLqqoUAx1_gM4zirmhurq5oSm4RZ
  ccOLwwHhAYrPie9yRxI98bYu1ZLNpjJWlRHV4OhgXjugyXvgYdWB-XcJ9ukiZ7ow3
  usbmkcm-nFiBX2_YqtJTIewsf-7SUySqTUJeJziXPRbn294tSfXcMRCzsS8ZGMvk1
  Wjq2e36xy_M4K0F8GHz5XVpfH1Orn94fNbLEN9nFnFAcsosG9YtJyHoGfwwYj6RWq
  A5uXyW-gb9Wohq4BMGCoCGJ0wNedouw4NxDy7ZInQzdM7ZD-1xZPWie37-09n4Ffw
  GoRz4OD1RHDafwUwpGRjRMB24yLpdQ37zTCC_y0DkpBj2xLU7z8ZSRXzc8nICdSgJ
  I1IbsM_gbfDkp76_s5MlGCIVQ1fH1LrOXUat27f48LQ071-cbC0D9UXKpDc-QgXzH
  4jvpErnu_puNi03CkTwrHwp0jjdnbTj0sHxOWd4cJt0iX8Jj3zNmXPuKlPFZ9UFlT
  3eF7oLNAHkaqC7icuCFiMrswHT6M80myAUQ84SNXSaPJ99DmmSdFkMtRhdqPtbg9a
  DI2L_P5Ym1JdhY9B-K7OwqEiXU9fYykKZ__jXZMO_GX-3Su7o60CXa6hkaPcVNAdk
  BzxbtJ8fyVrYAd5G1p2M3sGOiDlG2VGX2YQFyG6MSV5pa5ohb9CwPBx6RlxAAG0_p
  lbxwgcay6Dsc0NwgH5aH0YrAjXzMx3k51mY70WfuvlqCdtCnt553kLEnt3NkKP5BA
  zDIFZrbYSFSkIe5PhJooSnNUfO0LS60lfzw9WZzmBZLYbzah38M5oXwwPw-ytiMeO
  A4Qs39ckzn5-jmlBd_sYKiE3bEsZ3jnqwynzLECDIPn4Rd5tTFg6uYS8TZeFiLti4
  fyhAN2nZCoEV9MbC1qHeGMbarSagrFHAodgz9L0e3NFMFUJ0rCGy8uChNkdazqVgi
  mSfXpOVi49Hy31oLgaOunld7ALVAlS-4vSMoCMzdPeO0ZVSs3hFQulc0mm0nrSztZ
  9Up6auffOg7QiDeWa4ICse5I53-n6w7F1ubfEBYG_-7J5qujG4kd12VmIMMU2pzE5
  8kNO-CEjshings70iSEuHKx0AqmDsnJnYv2Bxr9c3Nod_M_UyzDeKavJfJsMI4qwb
  3aI_jlxcIs1KrHhkKoZnTzFK4XjIYZ9GLTVdUt7ZvGsenFxxqibk_X3o-ercFdFtQ
  d9A2ZMJdCZlyoE17Eyn3lIlwpIxqfH98dF-8fET_r3srOqNULVQ6xw_5bntvani6v
  0JorG_eQchlPiPWN_nzzJevqwBBs6Dv1CHtPXr7_sTUqNF-O0-j9oQ5JrJzTpd1p3
  EzDfVBe7NAO60RM5Iop80ZAflPlaTj53XO2pa48Tx5oMl_8mzIgYyut7ZFN8N_fEL
  p3vWekgI8Meq98KPFHopjYvXjZCZzY7FiBKXQTZ5ZVhkhNFYzV0zgMKh42J2yl_Uo
  NnzYqGualGE6KBdQZVw-RFtMXQto4iJ0iOrOa-qOEjMpkSvJEzRuOq4s-ldU0KPja
  2o59kE7aXuCX0cH2fscYYbGwoW-fxvT8irMy19zt_PS1Chw-80Zf5RZd-HPSe5hc5
  BPSStu6a1IWIxvzPOFRKz-AAruFmV1u-dG-noQ3DV7AbjsSbwHIpGeIo2htEs0UZa
  SDU_L2yXhIYvQMkDs6rcSmxuOWuZvMAFReq9vpOfjqpB6mEkvxON7fv1DSTqE9Le7
  5A0tS-hVw-Jse-0ExoQ1P2aTqRTQNDfW9OdFDUKT8MgqtCMi65T6TL5y-YbFKBzwm
  7AeLr_FnZQ-OoZYBRGM6t0zjjVZM4Wy1e_XMPaexQ1Cg0kcUD6iWk_dOAkjeS98uO
  _5aUodgzPCNHppo0oycvHyCnOwtHNz04p2wVC8wUxoSKvnIbIVKu1gNFdH4u4MaWp
  1pG9FKIgGbJEv0JNJ3lgJn-rBejlX9h7Hi5zvE50amUTCXPc3LgvP1d1aueDIXbjQ
  6J5gU3G3T7a5Ml1VZCP8nnNOWFe7-nhtmGhWa6b2SfYkN5JxvY9ar8ujwyK26Gzuz
  zfNmfU3cafvR3xk-Zo91YhGh7NuFRElARFC2kfRd64HGDfKDML5oz9KfpNk1Q7ahs
  iOrJ-eqtLwvZoMGHRlcRGGLotx7skX8vTYPpY8JK-KlZeyaOYj-TieZvVwFV9SpyM
  _GWqUMRPSi9n8Thx3sDSWosXlz1gI9KiuYeEP5FJeI8yLakmkRuyJBxGNcnLfLhPI
  dR9S13aE8xGQ_o_uKD7RpoA5p9aadakNSXtgFrHIZnWYlIs2lFskmg-PKgNY4-g3O
  RUH1UtmGav2W6uCrnya1bld9bL7qvMGuCyBJf2k1l-vKXw3BG9we-FTkCAlOVSCnh
  vPoB-XAY1ugOJmsSPK2gRkiiUz3Wdpf2wwYQxNkxr6ULNMYtHJB_JXd-_WtXI81P_
  VLwlYi0tS0liQE0-3GwTLlKqRlj9me9yMORKwGSLHQl5Up0OLuYqzUo3WFQPG2LH8
  rnGem94RdlkfEsKVYFrpDPeLCSpC_r7Mw1YtlJCH7Kh46JB6OGu065ejhuxno4X3o
  2Q4nU8WVafB7oh8Fn1tGPaFWGtMyeqNWoCl8jlhD3x9o19REg-qFMbb0D0Vn-kZ_h
  pQ5zNJIPg_6zq7MPv3ieNZvAKk2SePc7qg6wMuP534SjY9-WWxUMBWplKkU_AS4vl
  BKUtVOThq-GVZMPaeNUM_2-v7YY6OPr6cUYbsXRIXtoTJ5AWraFunXC3UvBnMo8MZ
  M4pIG7uvcrkgxvptZpB77InV14YYlJ9AyfK44KxqmGH9tK-BM0YtyfD7NYek_nGTA
  AE2S5-3rklkJggCzMLqxiVS8RBY3SaIJmiJ6jW3XHN5-qItAWcX3xVZviRffQE84A
  RRygXNKm_W14uZXzs5TpasD-tJGJZZtOKpV5FS3RmNjjlTJW4KZzhg2ZhM3KPZLK9
  5Gh2fBVvZvWy5XWuncM22VHGCUoZ4hCV99-opC53aShEjkzMpv4ZFQX3tqevrkMLI
  jmh9DOoCyR87iy6HPRQVpTsfGk57PEcTlqadP0ngVGZjoJIwS9o_8KCUroA1kSmJ-
  hn3xQ_gn4jDBm24ATEKfQihIdVf_ZRPNAJNHr5T2PE5FMyBRKZWpGVVCCLok0pUeM
  4r65bDB6puzkzpNvGnSCTdh5kcQzTLFrXhEVt2Z5h_UQNh5-iN7RCXlN3x5cSeKq_
  gV4dm0KMP6nKMmCpVxazV7WsG4a_QvoXIicc23H9BsngyjMRk0075RfFE-BUg6iRT
  c-pl47MoJOOTnJheQEv91QgSNRRGq2pXPnb6CKh64fFOPLIb-0S8qNE1Dq66yzC1d
  B_-VnRb12ctfU_6xbLFPjHiqUmGOW5b9nbhaJdZaCCztP3nHH8Omz3Z1hGuvOr-rE
  PVcE5IVVxWX3dGh71mn2dOJbDnuJr3e2wLzGUeTyrU0UAV_a1og8st2yae2pkjbjH
  FEX4pMw0C5k10-5fvGbUPtwU-VLj7scoD8f43V_Ancf_BcGyrM0nGoFEdEJ6JoxXK
  FnrRRep4YCfqf7BuELoM5kou1TAAeVTVD8y6sSKqLoqOk1MFY6F65hp9ZF5-eeazv
  wLLZwAiz73kwLBjvxxMnoTFGxLEWDbVT-cpVSoiIOoqdS6uCcaMvYReiQ7pXFwjoA
  Q1q1OstIdpRr4lh5UD94-ixohdytDgYirZsBmMchk8T-xdn5K2kO5aIRgg8IqRWZ5
  kXB-wfSM6ZiQqPMsdXg9iR_R7lUMmAfVObZEVE2W36KhKaib3boqCukOdC1A8oUYs
  An07M01V-mvw2XinWKivyHL0pvbH3zxHlW1tXOs6rh9SIaMEzAXeUiKrLujT0jk_K
  mZIiiZ0U1MRTQFffsMxLL6NGb1t306p4OqNmJzQUm7YZ6080A2aTQzvPli67GV_dS
  cU26cMAh6NPkoyYmU1xXphDJ7O6ROSXKyYSRxi7WAYpyzbENyUqbm-u1EEv_KF3Tw
  r7XKaicsRxJBUex9Dk7RBqXbUrpmmyjovN8DjOAIxW8mFRNzh6eTk-H3_7ECHBJXh
  k0dMJdhCu5x8q3LBIVaI_0FTC6kak43fbVglpYV_6jLRp16XL1iRsbTyKANciiAHt
  UKswBXFh0R8hdmEWu2HU3z4yQtw7gUJptCc6Wocz5blrujQ98chfZybD_QZ8OdvoK
  _tvfaZvHGhcAy4Hb9RaqytHnlZ5fTHSrI3G9XQMrWBZFDGsoJumBvlXWuJ6_cGQrt
  llIbT-PrJULS4nV9x1w8a4rVadHK1hYpVQtsBOlxM2BJi_Isem94Nc42A3qbRe_FL
  YhE4NEBufNvva9iuwzAF6XNkZxA0m2vd4pnRNn0p036Q5RtTYnDkw_XkRdViVOuSN
  jGITmxKtRpmTQ7ROKZbnsGGPdr2tSsKc_-QvyXYaz2jV2tgVinnMUWNQcY596Z5Xs
  rX4SRszCuPi6VBi2ztQwDuFf2SJFYIlmFwt4o1gJ0PAlc7GyCP0XA2x-hVbu2i0Wt
  Lcn0bAxJejRxcjcKDeiPI6EIHVwWxA4t36t6xuAGLpGzHSm_ZWdc_HXK0wv11UShd
  wZhkz26NUtZityaBi7kVjh22jTotwLfItPBSf6s8dlHNH2VnilCWJIYzA-htFXWuj
  th1bhH6NO7O_FxECS0V9vNJgpnPBhk1mZdoTgn4ORqLUpuEB2rnHhBi2qol3V3Beh
  79W9BwwIZrHhZ7XbTGkEtuuXY0Vo9kBds_3JTCf7CIh6ifz-ztKeX29rQ-_dWLZf3
  psW0md8CzSusadqI28HxVqpuNTEa3-KLRlVBFcn5WjQUq7l9n_tNIvQn-nj5tNUIE
  YEzpooorMJTomsaC_hspgsevbwCC9z3j9to3WdMBn-_EPnGF9lRVmKpYM_xYGZFUB
  Y4UX2klpyQoVd5lL6HRLtSVNZh-mRWWuWjKFp06kFzbr1yq5wB4Rch7Pd5O1o3QUF
  XZjNbzR4DCZ0gjf_BLFy_Mg2Bw",
        {
          "signatures":[{
              "alg":"ED448",
              "kid":"MBJV-4SW6-OHDS-EWDH-S5TT-2EU2-IFNZ",
              "signature":"gTz-usAmNRHQUnbVvBPJlvFn_ENfjE5BLNvmpa
  YzUnr4EGTfi768qCGWrIOUqOY_mNG2hv6X9zMAlz4KA7B75XlL3W5_oB1hqEZDFXc
  9bdglpn9NWxMZI1qY4HJ9Gjo4dStgWgzg2djNAQJRfW_GxBYA"}
            ],
          "WitnessValue":"QuDuZJBI0JZ1Rb6Hlz-h8Myknq5SgZZH_40slVc
  mz1I",
          "PayloadDigest":"Ipjq8tvDOndLvt7fiq6kyU4a-Nytg9idgkrlTG
  UZagkL9NMhRG37KWyyapXBsocod3JtQHLMCda2Anb2qQ07JA"}
        ],
      "ApplicationEntries":[{
          "ApplicationEntrySsh":{
            "EnvelopedActivation":[{
                "enc":"A256CBC",
                "kid":"EBQL-4GTS-QVFI-RIWX-DDZC-3VEP-UTXP",
                "Salt":"Uw9felfVPvDqlVKgsiQejQ",
                "recipients":[{
                    "kid":"MAWQ-E326-P62V-LZOB-272W-HEJ4-E7SY",
                    "epk":{
                      "PublicKeyECDH":{
                        "crv":"X448",
                        "Public":"mhEDXzBAlam_tXcdZBbEOVp0xdG6c-H
  iYuo-fMWsLp3sW1NEGZL2jpJaDmGSozEH84rdO5IBfHYA"}},
                    "wmk":"sJAeKQvQuF41is3Ssonk414QWaXOp9C0BJXTH1
  WWIHy-k8s4gDckDg"}
                  ],
                "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY3
  RpdmF0aW9uQXBwbGljYXRpb25Tc2giLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1
  tL29iamVjdCIsCiAgIkNyZWF0ZWQiOiAiMjAyNC0xMC0wNFQwMTowNDozOVoifQ"},
              "Vi_NsjZOx0Lf659OWqGiek-77rDhTIN0VU-fQKeudXYx7PaYVT
  hEMtfxNbUky4GsSxfkjGWJvm_77eLXoSkZpDQJ2c_CyyNy0o_KU6kT_KhAXPkwCwz
  kq2XXny5L-UyxyuBvKSD7gF9otwaoA6H3tdlPVKCggvywPL9Sr7WnNudvC1AFgbFL
  UuVF2aDOD0U16IJgLyMCqz7ZUCxoRvtnYSDbJdKUKEFBehgZofokzW3NMc7_giGZL
  yVYnwrA5Houa5mKklv2Jlnec_nUjmGSu2nKMe4qydmg4XZAC6Y5sgz537l9e1nZa8
  wqoaE9fTQ_utvkjGn-hs_I0b167nRJFu1gMPRKRgmXwVwdn3mBcJF1SK9IwiwWPmM
  2wAZdZmtjwvT38x-KbbS3cvH9rwHN-8n-n7mjHRhO8qq7H6qE7CuVjtPXP2CMv1X6
  jNNTwiUPxj_vLWxDDoQNyKey6Ews5jef17o82tIZC39NB1K5Ap1z2Jzh8muIFK3uz
  LYimBMikrE4b2b2bkmZi8k64oMC71F0nI2KxWTtQNHagJb8nD1MRnsc--xd_s3u3J
  6oWWDSR2YbZrlagTZ94cBHWl4NfvtyhxPxDKd04TMF_Pj701f-S6Z5ij2Pt_3i9cL
  _zvAbUISBQjTVyRG62G-2U5NGMbW8hlVsbwOaxH4em4_yvcdu4pV64XAvxBei9NQu
  7lq5YQ5usbKFM8vM1UUQKNmenxrTqdX5z-gFJUActF1ZPlxSO9s3znn7QZGb1nI5O
  iXlqsG73objHWoYPioHoyRcqpH9RFNNfkiZM4-35NGf7BsjZ5C0qzHVQzJ27y6jrV
  TXMm19VNwraSlE2Of1W3OdBOcsVEl85NUBhcmnL6y9SpuTBKUmYCUrr9lRB-qoycy
  WBzQQAtaVUlzAn3-lizsCnlzYCVLLvZNQZrvpX9oJ9igo5P4MsyjLa2IXoaN-TgAL
  no0IcMPFnwkEcYQd7VbK_yu-_6Nd6gABS1JmHwnlv1gKcMAB-pkCrcHyxdBXux6GH
  cMK2zseozbCFE44k8KNEKNz68fb_xgMq6Rwzn8zOcfOB4Z6SyeMKiqxxnehTHbdMJ
  sg9meP0ucq0uLybyjXKUqs6V9AWGTjjX5m_LhoisxZoVWjse_fSpnnUqtdEapNgXU
  AFsCdP-7xLn1SC8vx4RLp1VzghbCwdsjKQEtci2wPzyYEfRdiNqQ6mn8i5zvGA5k0
  5qb0427JqBl1Pp7u64CMnPnaFLuIHIQBAwmZZvNDo_osbzGxiHLewHT1J0-DIBf56
  HbJwSL5aMHIOMsb7AS8C5Ga4loBhvLtyk3RKd3FA1QSkmi9Gb9wuWeZ9TwdzuDxn4
  Zhs52O3m9lipRFaFhym-rb1McWbNU-UnpdG-k9SCgDiAlkToK2QEC84wXBbmvW6Vq
  H2iJX4SE_QpjMe4p7HLZ77TtwrhmlbZ-dEiuqbVkXXJF8BxfCEtbyNqTGC1nc4NV8
  5c4x9EZPH_gytiCT7hJcORys4otoS8BqW6XIRfg-8CJtjtuGQFnyL_QkEeLdIF6_-
  dWCwDm_sJZp6IcyZo1SraeSlwj0EXvtwuz6S_LY_vDQagsIwfsLsZ-rwEZlN4chaV
  Nwxddsr_qrMZO04q468ULTdOxn-u2WEJTHGz78DuFTr2vmVewhP7gwkr0Nf-IfDfD
  C_9grima1Zd4jEnTytm6-blJkY4VbNk-dQkgy3p_CnY5vgTc1fFxfOZMKfUKrSeT9
  4FN2eS5iZM_uyMpRb3MbqCmhvuhP_OCwEkg1KAudcIH4YMoCxKOuuY5WFOHPsRGum
  5edrPIwTkaFvH7dCww_FEpqytBZt1r4PAZzoReO7r1ebXWqU3w0_9PXLONYufaV51
  JxeJIaw4XUqrBL454RToOnVA8Ev5AV-TZwIzQwRADP8zN8JrC7llxX90Lw5iI3KBD
  YsKu5BCcC8DtKRUVAbrNT26iWxWYIdnZVbeJG8EbNqYNLX79-UTg5J2XTjXBwMNUK
  TW92Q2Ps4fuhtXuEyj1HQ7_zMd1oGqIKgNX-9XXMC-icxkcW8bjXSrsvtPaQXKsnk
  x-QYv27nHslL7wvz51duADRB18AZiiswHecTQUZGYdXF-9mhzgM6h_LohqvrgDnQN
  dU3e8XkmB-vettDgrAQc3Qhj7WDU9p7-V3KvCbwm8Z_7UCaXrH3cfhNIW_XSDtj7l
  B23naUB34mM3ciPWRnnhn7jiy1Mf39bkNmDuL5Of1u7NgJaufySXjr2eBXKNva4cI
  IDlmKRAJgUtFg182B-iAJyaWwaryySwXhWarvKLikGVxTi0l6N9Fe9nKTlbu9cwMq
  NnWa-m8g50OUbOOzgYqUhuhgjoU5wCj72olndW6dnwOvtpCIbASGKCpeqwVzOQwz-
  Q3mHeD5B0dJGdoI5aoghvBufrXSNT6clHs1lRPAa1hzpiwc5tFMA1Gf8CqkbR-2pF
  c8KQSHAJxlW6o9LI7S2E7RUYCcCrRFAepxtwSjIufAiEPjD1cookv-2m6sbQLi9Eo
  EqNCHAaGno44d4tV_w6l76D0RAYBt64UyPKuHR0-oTUspVIJSaf8n7ovNH7a08yuo
  TtO5ErsXGEUOE9xPnT9ie-FbvPrRQ8OsJsDuaQ3k74f8JJOXdE15kp0r0XW1QnVg8
  -Ecye0k8_wny-_dhnmqVez1Pq3-YEw3YakACY7iwMN5wwXaxk8fiiqS15tuw3X0YX
  fX3TV9CNBb2591Bpm6Hj4IsVQsU2P9Rwtk1Qu1mOgu9jKBWweqHgfu7tmWKd68BSG
  _vrTL6o6QrvDTcC-rZhZuMG5IXRGUu1dmMh7oHYS7fZT_0NQP0Ttd0BUEOse7R6IP
  3XziE4z1KVOWEZdv9z8mFCykgOuL4zuZ8sZO_awvljix8aSBUICLqrjUAUzRKOEMA
  AymSBIyfy9QU5yYd_nYL5k4pk3pHykTBVLeQXVu0EfhoWg6ZvJdCHCIQMbsskvpJ_
  V1x_M7YblpSbWvczCtu1DUZDrxWA2foEEirmflSa9u8LdoGgk7ZJtrY5G05ElqlkU
  lIsDNr4o7qiqwmXEyMGPKBDZKzerZeb-N27UoxrVwp8-6mrliebXhpL7WoIo0qHtJ
  9UKsJtLuz435l1jQoOUw-u4VM7JdmmWn9kE9TlWGoDNG4EhTJMLXWFI2S5kvXxvAA
  YQdrW6YEa2-phXYhSWot2_PNsAaFTAIOXOVoU8T69bg3MfmBO72WVl47NdsiKZSz7
  G1MdMHafLKPCOvXXtMkXa6GcE59LP-TOWuOuCWlbSXnmC89_clFVU9VVRTPY9Pz8E
  5Fi2VX_Fkj7trtB55MShaH15Ofpd"
              ],
            "Identifier":"MCDB-WYWC-AJ7E-GYZ6-FPEK-Y4WV-AOSM"}}
        ]},
    "MessageId":"MC5W-YWXD-6IM2-RNTP-VFPM-4A4B-VHL2"}}
~~~~

### Phase 4

The device periodically polls for completion of the connection request using the
Complete transaction.

To provide a final check on the process, the command line tool presents the UDF of 
the account profile to which the device has connected if successful:


~~~~
<div="terminal">
<cmd>Alice3> meshman device complete
<rsp>   Device UDF = MBQJ-ZMG4-QN7C-E4AL-HPH6-FW26-JJVF
   Account = alice@example.com
   Account UDF = MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
<cmd>Alice3> meshman account sync
</div>
~~~~

The completion request specifies the witness value for the transaction whose completion
is being queried:


~~~~
{
  "CompleteRequest":{
    "AccountAddress":"alice@example.com",
    "ResponseID":"MC5W-YWXD-6IM2-RNTP-VFPM-4A4B-VHL2"}}
~~~~


The Service responds to the complete request by checking to see if an entry has been 
added to the local spool. If so, this contains the RespondConnection message 
created by the administration device.

