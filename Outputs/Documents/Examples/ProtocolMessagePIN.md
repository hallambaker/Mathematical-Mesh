
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool:

~~~~
{
  "MessagePin":{
    "MessageId":"ABTC-BSSG-W6MM-FTDF-DDTE-OQKD-GXL4",
    "Account":"alice@example.com",
    "Expires":"2021-09-17T23:48:19Z",
    "Automatic":true,
    "SaltedPin":"AAKC-QGNO-JTFA-KEDC-4UFV-SXC6-7SCE",
    "Action":"Device",
    "Roles":["threshold"
      ]}}
~~~~

This pin value is used to authenticate the connection request from the device:

~~~~
{
  "RequestConnection":{
    "MessageId":"NBVY-LDLZ-GY6F-ACMO-DSFX-GXDZ-LDL6",
    "AuthenticatedData":[{
        "EnvelopeId":"MCCJ-GLUQ-6AOS-XQEI-G4AM-GTL4-UBSZ",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ0NKLUdMVVEtNk
  FPUy1YUUVJLUc0QU0tR1RMNC1VQlNaIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTA5LTE2VDIzOjQ4OjE5WiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUNDSi1HTFVRLTZBT1MtWFFFSS1HNEFNLUdUTDQ
  tVUJTWiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogImxxNFdhQUdaWldrZHQxdFQ1YldDRzFXR2lKbWRDa1lvWWhPb1
  pqV1pNcy1MMjBLYzAwSFEKICBqUFRKQmN4eVhXc3A2SmpjaXlpZ1JLOEEifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUFTWS1BSFhULVk3QkMt
  TEhVWi1VU01QLUxTTUUtT1RZTSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiczRMQ19TVU5iVGNaaE1ZY0lGeXpqbjB
  MLXZZZlA4NzBnMFJjTGd1NzVnOTUwV0ptZFFOUgogIGtIRUticWUzZHdjWnY0VTRI
  dENDSngwQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1ES
  0YtTURQUC1EMktCLVJNWUotSldITC1SSlpWLTc1RTMiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJEc3ZuNUdlblZ0
  eGQzOG1mdmJyNVRGY2JZdnEyZ005cDFpY21PLVFTTjV3ZXVDSThHOXhuCiAgS0Q5T
  E5GRG50Z2x4ZGs5U0dYeGdiYWNBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNRFJQLTVSWUEtQUlUVS1XMjJaLVFEQU8tQ0tQVi1FQVZ
  GIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICIzdmVwRzc4eHg4aldLRzJLTDhuVzc5SUxGb1RlT0VBNlJaWW1ZbjJhUm
  1NMGxBZ2VhZVF5CiAgZVI3STVxR1IyTFpfY0RsUno2Ml9tbHFBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCCJ-GLUQ-6AOS-XQEI-G4AM-GTL4-UBSZ",
            "signature":"8rxhyNjCrAOjIbyk62l7L8vuCX2mDq30vCOo9lLG
  n5idiM_2s_ikpk71HRz4pB8-YNPhwO8YWf-Aap1FK4ZdBopA-KwZ_ukuBVju0_QXL
  Z3URh_N0mCiPA62Us-Jxdiale71DuCtbCroO4irQTMzJAsA"}
          ],
        "PayloadDigest":"h8z2K3N7t41MzuwTvF31jCBmDb7EJ6YNr5a6Z_XL
  XP9F4ycFcj2leNY2RyvBW5X8JM_12RXoo5U2oUxxa6kW0A"}
      ],
    "ClientNonce":"Z4-mdgWtUO5juBZ_pw86pg",
    "PinId":"ABTC-BSSG-W6MM-FTDF-DDTE-OQKD-GXL4",
    "PinWitness":"rzwUPcR0wsruxuJ303-2Vm-3MOx8LtykRAa7JG4--Idv6l-
  RLoPaId7r4bdAbrFbFeI56OmWBRfuDxUOAJCpJw",
    "AccountAddress":"alice@example.com"}}
~~~~

The administration device can now use the PIN Identifier to retreive the 
MessagePIN from the Local spool and use it to verify the request.

