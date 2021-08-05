
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool:

~~~~
{
  "MessagePin":{
    "MessageId":"ACCL-WJJ6-QILY-IDQT-67RT-LHGM-PA2K",
    "Account":"alice@example.com",
    "Expires":"2021-08-06T16:37:40Z",
    "Automatic":true,
    "SaltedPin":"ADBB-JTKR-RGGL-ACEM-TW6E-ZFY6-NQXF",
    "Action":"Device"}}
~~~~

This pin value is used to authenticate the connection request from the device:

~~~~
{
  "RequestConnection":{
    "MessageId":"NBF4-4PTH-UTSC-RYHZ-EQMK-BVH7-MU3F",
    "AuthenticatedData":[{
        "EnvelopeId":"MAOK-I4TT-3EUS-4LMY-Z6JO-VEN7-CX6F",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQU9LLUk0VFQtM0
  VVUy00TE1ZLVo2Sk8tVkVONy1DWDZGIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTA4LTA1VDE2OjM3OjQwWiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUFPSy1JNFRULTNFVVMtNExNWS1aNkpPLVZFTjc
  tQ1g2RiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogInRERTlnUy02RFk5bVBFWWFScVJmTjh6bW8zOE83N2ZIR2EtaF
  JYd0Z1NFhnbjVrMkdQcUEKICBqN1ZXRkVmc2FpX2JtMlJNc2w3UE8xU0EifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUQ2Vi01NEZTLTZRRUYt
  MkNKRy1FVVhBLU5DVk4tWDVINyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiMm5Ncl9GUVExYW1VbU13VzFadVQ0Tmp
  hWXJwRDcyTG5LTUstaXJTc3ZCVldxczVrT3JUSwogIGRQcjh5YkQ3MUoxNmxXNkJk
  LWJnN3htQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1BT
  UktSTdPUy1NQ1VNLVc3SEstNlFTRS1RWE5MLUVKR1MiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJmeTN6bWhJdFFK
  ZFRaVnJucjVFNlAzT2d6RmVVa2hFYTdOQWNTUHBHUkxvc3U3XzNCUEp6CiAgb1JqO
  EVDT19kSkpvOUJlMU9jTzdJUW9BIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQkZOLUIyQ1gtS1JJUS0zTUhMLTdTT1ItWDVXSi1DSFF
  HIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICI2ZmdRRXZEOFNGWjZzb0VzLXJNa1ZXbDFCY202N2s3TVYzcWxlRzQySX
  ZaN0NOM1FLbDRvCiAgZFhHaVBnOFU0NDZ3bGpQQVJEQnBkNFFBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAOK-I4TT-3EUS-4LMY-Z6JO-VEN7-CX6F",
            "signature":"14AHQuUENwVXXulI7Hxa1cceWaSS_qBhfy-tydNF
  n7rJksVfHMDiy8vrrvdV00BGuktPqgp86C2AWSac9FnGXwhNZ3PV2edzsCwC_e21d
  UoGQ7XPPL886uw5wkDjz7Nt8WxL1Dn8uwpAph_xrIMMNSsA"}
          ],
        "PayloadDigest":"ZXcdFX7i4PYf4oJ6O7_dLw7TWEkr0vC_r3_RcaDd
  cy-Wz4DPbqhCk1VGyU0YLsR6C6NEcHa9ExjBa5OIoZakgA"}
      ],
    "ClientNonce":"VGxxL-LKUQyqn_Rpdj86Zg",
    "PinId":"ACCL-WJJ6-QILY-IDQT-67RT-LHGM-PA2K",
    "PinWitness":"YhwAi-IvYYP2dMjOd-pXioRqgIq0knwLwnUqMHvpvTueLMc
  7ATSXMdBlxOSZ_u8sztqpwwEZEZ5Rc4WQBKP3cA",
    "AccountAddress":"alice@example.com"}}
~~~~

The administration device can now use the PIN Identifier to retreive the 
MessagePIN from the Local spool and use it to verify the request.

