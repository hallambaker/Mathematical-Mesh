
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool:

~~~~
{
  "MessagePin":{
    "MessageId":"ABF7-CTWL-U2EV-KAEF-OLNM-XAW7-76XZ",
    "Account":"alice@example.com",
    "Expires":"2021-09-17T18:12:42Z",
    "Automatic":true,
    "SaltedPin":"AAUY-PCOU-GPBI-3PTC-YW6C-GMJ7-B7GF",
    "Action":"Device",
    "Roles":["web"
      ]}}
~~~~

This pin value is used to authenticate the connection request from the device:

~~~~
{
  "RequestConnection":{
    "MessageId":"NAAO-D2ZD-V3AI-HADQ-HZOA-KYWH-JOEQ",
    "AuthenticatedData":[{
        "EnvelopeId":"MBH6-XURV-MKES-DZWH-VSOL-CC4L-HPZQ",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQkg2LVhVUlYtTU
  tFUy1EWldILVZTT0wtQ0M0TC1IUFpRIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTA5LTE2VDE4OjEyOjQyWiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUJINi1YVVJWLU1LRVMtRFpXSC1WU09MLUNDNEw
  tSFBaUSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIjBZc09hRXpiSUpsVVJuWG1wZUNQV3hDdG1pYU51T1U0N2EyTG
  hBbU1wWWFEbVFsXzluV0UKICBIY3J4YzBIRTVqU3pvRkZkTHUtbE1zbUEifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUNNQS1VNkNQLUtCVTct
  QktCQy1KT1dPLVRSQzctNENRSSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiZHVHUUd3LXM5ZzBDVGhrZGxLY3Y4T3g
  0X0djb0lQcTJma09TcFYtN1RYc3lXY3lidDRoUQogIE9GTWdVQ21BTjYxbzZrRG1z
  TVFhekFRQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1EU
  EktSjdGRS1TSDJTLUVORFQtUU9PVS00M0FPLUxWR1MiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJQN2ZrQ0lMTlFx
  MlhidmRGN2RDd2Y4VVU3bmVQN1BRNEJpX3UyQVNVQmd4cEZsbHRjWl93CiAgemhCR
  VV1Ync3Yk9PTTl6dHVuSnB1clNBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQ0lPLUE1S0MtQUFEQi1NRTI0LTJMVlUtUEJETS1UNUZ
  CIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICI0T2JNN082ejY4b2ZfWTg2YlJOTTFuRjJlSmRVMkFGaU80V3IwR2xJME
  RFb0IyR0hXTFNzCiAgU2F6bzZoSW90V1ZBN0tNMF9lRVhlbmtBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBH6-XURV-MKES-DZWH-VSOL-CC4L-HPZQ",
            "signature":"s6-TmSVALI_HkYtjx4xZwmGtEjFvRzdt4ukbQdSf
  WChwrjrxFFsftAI_fQenrl4QMcSLy0i1jzaArzjL4U5xp8XLZziDFlfbpPNeqCXfi
  _jupYp4EHlqBdzEIPjEt66UwcwAFiipEz2GcX2O8SRb9RIA"}
          ],
        "PayloadDigest":"J_M-oSDmRS90G-0ul1IztiwrIGpHA4aQYj4LhNPn
  DMSA7W1qks1-QEQCHHv8lmiQKWlkmXyAZpDVi0kX3JT0Sw"}
      ],
    "ClientNonce":"EkfVgmj236yhx7md0T_8XA",
    "PinId":"ABF7-CTWL-U2EV-KAEF-OLNM-XAW7-76XZ",
    "PinWitness":"7FgaJqesrUlIbhv0qe5-AvvE1zzzsBLZUaX8BjwHgUsoebZ
  JOwCkNnbW7nKbw0CVZDi7IO6KNRQRNQwtNFTKzg",
    "AccountAddress":"alice@example.com"}}
~~~~

The administration device can now use the PIN Identifier to retreive the 
MessagePIN from the Local spool and use it to verify the request.

