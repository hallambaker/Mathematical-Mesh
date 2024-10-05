
### Phase 1

The manufacturer preconfigures the device


~~~~
<div="terminal">
<cmd>Maker> meshman device preconfig
<rsp>Device UDF: MBQF-KCLE-D7QI-5DMJ-M4CE-CS3H-Z53R
File: EC2K-TADU-3ZHN-BPBC-TZY6-EAKJ-SM.medk
</div>
~~~~

This results in the creation of a primary secret which is used to compute a ProfileDevice
and corresponding connection records signed by the manufacturer's administrator key.

The data is combined to create a DevicePreconfiguration record that is provisioned to
the firmware of the device being preconfigured.

~~~~
{
  "DevicePreconfigurationPrivate":{
    "EnvelopedConnectionDevice":[{
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjQtMTAtMDVUMDA6NDk6MTNaIn0",
        "dig":"S512"},
      "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIlNpZ25hdHVyZSI6IH
  sKICAgICAgIlVkZiI6ICJNREdBLUFUV1QtWFhLVi1USllWLTZVUFotSlNUVy1FM0Z
  NIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQd
  WJsaWMiOiAiRWRoYVNfU3hNak1LaDVwOHQ5UU40WWNWNFJwQU1RQ3E1QTBrODA1Nl
  dldHBQS3dBczJIcQogIEpESVBUYmJPMUIzUV9UdUc5cUFPX19BQSJ9fX0sCiAgICA
  iRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ0MzLTVDSlUtUUFKUC1VVEsz
  LUlIRTQtREcyQi1DQkxQIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgI
  CAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLA
  ogICAgICAgICAgIlB1YmxpYyI6ICI5M2tManM2TnFuR29za05lTFVZVi1KV2FDT3g
  0aV8yckdZQjZmbXZsaVp5c3FYZHpUOHdaCiAgci01QkRISFJoWFJLbE80R3Y2dEh3
  N0tBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ
  0MzLTVDSlUtUUFKUC1VVEszLUlIRTQtREcyQi1DQkxQIiwKICAgICAgIlB1YmxpY1
  BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICA
  gICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICI5M2tManM2TnFu
  R29za05lTFVZVi1KV2FDT3g0aV8yckdZQjZmbXZsaVp5c3FYZHpUOHdaCiAgci01Q
  kRISFJoWFJLbE80R3Y2dEh3N0tBIn19fX19",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MCSQ-3H3C-4WIQ-B2LY-MAZE-TAVW-EJ4O",
            "signature":"qNUkP7T8yhx6mtGj0cRtdtkHN7dy052TVVmZAVGV
  Y1A1ORs57seULZocQ5NO_4Tjww-A3LIrZeGA-1TaX3uew4na20DTOr0Vjbpa7Ruwv
  Cy7PiJ9zW1MBFxQ-dmudeP_xQusmFa7TTKDzAHy5cUBlD8A"}
          ],
        "PayloadDigest":"oNDx_ot3clPzF0nEXyHWg6AUCCX1BacWbQEw7xei
  zCXBm_0Uj95sAKTdKcvWJzrPvEToB5koZjDCpK5vx6vrJA"}
      ],
    "EnvelopedConnectionService":[{
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICA
  iQ3JlYXRlZCI6ICIyMDI0LTEwLTA1VDAwOjQ5OjEzWiJ9",
        "dig":"S512"},
      "ewogICJDb25uZWN0aW9uU2VydmljZSI6IHsKICAgICJBdXRoZW50aWNhdG
  lvbiI6IHsKICAgICAgIlVkZiI6ICJNQ0MzLTVDSlUtUUFKUC1VVEszLUlIRTQtREc
  yQi1DQkxQIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1
  YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICI5M2tManM2TnFuR29za05lTFVZVi1KV2FDT3g0aV8yckdZQj
  ZmbXZsaVp5c3FYZHpUOHdaCiAgci01QkRISFJoWFJLbE80R3Y2dEh3N0tBIn19fX1
  9",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MCSQ-3H3C-4WIQ-B2LY-MAZE-TAVW-EJ4O",
            "signature":"vg-6Urg7KB_ttW3fsx-QCi3uy1PrKbtMz8XAE1qc
  tWM3tYdWBnskIw7AsZx8b05FAMyCL8x7awkAEBocJxqyh6_61xZ3ukIX0Besi9QmZ
  pe-v7omKNUeudiLCliIWBISvjteEfA8mJsPNtpTpbljixsA"}
          ],
        "PayloadDigest":"sTvTlamUKmZLXKbEsqeqlbCZDoN7VJTdMnHKPA3O
  ThGwa9feMAVB-lnzTMo9auUTbQkTPOrDBBoVigGUK5ejHg"}
      ],
    "PrivateKey":{
      "PrivateKeyUDF":{
        "PrivateValue":"ZAAQ-AGBD-SWTH-H5NE-WVK3-EV7N-C2KB-BWXY-K3H
D-KVFL-HDVI-T2IB-OURR-6KP2",
        "KeyType":"MeshProfileDevice",
        "RootSignAlgorithms":["ED448"
          ]}},
    "ConnectUri":"mcd://maker@example.com/EC2K-TADU-3ZHN-BPBC-TZY6-
EAKJ-SM",
    "EnvelopedProfileDevice":[{
        "EnvelopeId":"MBQF-KCLE-D7QI-5DMJ-M4CE-CS3H-Z53R",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFGLUtDTEUtRD
  dRSS01RE1KLU00Q0UtQ1MzSC1aNTNSIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDI0LTEwLTA1VDAwOjQ5OjEzWiJ9",
        "dig":"S512"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIkVuY3J5cHRpb24iOiB7Ci
  AgICAgICJVZGYiOiAiTUNDMy01Q0pVLVFBSlAtVVRLMy1JSEU0LURHMkItQ0JMUCI
  sCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlF
  Q0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiOTNrTGpzNk5xbkdvc2tOZUxVWVYtSldhQ094NGlfMnJHWUI2Zm12bGlaeX
  NxWGR6VDh3WgogIHItNUJESEhSaFhSS2xPNEd2NnRIdzdLQSJ9fX0sCiAgICAiU2l
  nbmF0dXJlIjogewogICAgICAiVWRmIjogIk1ER0EtQVRXVC1YWEtWLVRKWVYtNlVQ
  Wi1KU1RXLUUzRk0iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogIC
  AgICAgICAgIlB1YmxpYyI6ICJFZGhhU19TeE1qTUtoNXA4dDlRTjRZY1Y0UnBBTVF
  DcTVBMGs4MDU2V2V0cFBLd0FzMkhxCiAgSkRJUFRiYk8xQjNRX1R1RzlxQU9fX0FB
  In19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQU9DL
  UNUNlQtWUVDNC1NSUFRLUxPU1ItVVU0Sy1OWVBEIiwKICAgICAgIlB1YmxpY1Bhcm
  FtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICA
  iY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ0d1VkdFh5YXhKVlBR
  MlNJZFJSSFBzVk4xS1JoSEYxbFJiNFR3b1RUUl9wOGp2MkpXdTJOCiAgT25lbHdka
  HppWmp2R3VKR1Awb0I4TWNBIn19fSwKICAgICJSb290VWRmcyI6IFsiWUJpU0Itaj
  JSUllMQklpUy12eWN2Vk90TDVjOUJtc3MzbGVoYmdLYjRnU25lOEtUaUgKICBSRUM
  wRWpSYWl3VThicDFkV2lLdWxLYTNpSmpwVDZCcG5lbDZrIl19fQ",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MAMJ-EB7I-6ZCR-MCYE-RCJP-V7E4-XVJ2",
            "SignatureKey":{
              "PublicKeyECDH":{
                "crv":"Ed448",
                "Public":"X18TUcVuJy3U4RmJrCSDZIfj1A3wWuqqYY_eiXq
  gOVJnhN9dW8mjBvi8BQ-2p9f1b0GmcxHW54AA"}},
            "signature":"RILQLUgyKJn1ULkXYJirZJBq85JZkv0VUIyWTQUP
  LDCZxVIDfETwbeaHbJ_BE3LaMaPaCvbsGIyAa1Agq7a35uFl77qB8vIHCcEvIOEN4
  0l2TnWzaVB0pGHOapSgnHplE7tSeBfO0rVoAxJaNDOIjzcA"}
          ],
        "PayloadDigest":"86G5pUJCNlvbtBoSZDMkI4_3lcYu04Y9BbsVoGPV
  LRPRJD1x3z-qKQMy1PcDWhJHcWcpt11U5KkUaHqxlhzGBw"}
      ]}}
~~~~

An EARL is created specifying the means by which an administration device can acquire the
information required to complete a connection to the device:

~~~~
QR = {Connect.ConnectEARL}
~~~~

The preconfigured ProfileDevice is encrypted under the encryption key and published to
the location key derived from the EARL.


### Phase 2 & 3

The administration device scans the QR code and obtains the Device Description using
the Claim operation as shown in section $$$$. The administration device creates the 
ActivationDevice and CatalogedDevice records and populates the service as before.


~~~~
<div="terminal">
<cmd>Alice> meshman account connect ^
    mcd://maker@example.com/EC2K-TADU-3ZHN-BPBC-TZY6-EAKJ-SM /web
</div>
~~~~

### Phase 4

The device polls the publication service until a claim message is returned.


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MBQF-KCLE-D7QI-5DMJ-M4CE-CS3H-Z53R
   Account = alice@example.com
   Account UDF = MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
</div>
~~~~

### Phase 5

Having been advised that an account has published a claim to bind to it, the device
posts a connection Complete request to the specified account and completes the
connection process as before.

