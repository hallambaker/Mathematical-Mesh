
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool:

~~~~
{
  "MessagePin":{
    "MessageId":"ABM5-DVCA-KOAF-YPHM-PFWG-LNBI-MLGP",
    "Account":"alice@example.com",
    "Expires":"2021-01-13T18:42:18Z",
    "Automatic":true,
    "SaltedPin":"AASJ-7OXP-TMIO-63ZC-Z7IE-PGIR-TPXX",
    "Action":"Device"}}
~~~~

This pin value is used to authenticate the connection request from the device:

~~~~
{
  "RequestConnection":{
    "MessageId":"NCTB-WNTR-XOAX-3IFT-MBMG-EEUG-7TXK",
    "AuthenticatedData":[{
        "EnvelopeId":"MASU-GWSQ-MWUH-2BT7-Z76U-PXMO-J6N5",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQVNVLUdXU1EtTV
  dVSC0yQlQ3LVo3NlUtUFhNTy1KNk41IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTAxLTEyVDE4OjQyOjE5WiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUFTVS1HV1NRLU1XVUgtMkJUNy1aNzZVLVBYTU8
  tSjZONSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIjQybGlhTlJsUGo3QlRLbFNBcTA2dG00ejJXQnoxd1dfYnl2dk
  VBaUV1RzVUSDBjVl9GeGsKICBBeVdabTJVUHpWck5TY1dvNHVPTTZ1Z0EifX19LAo
  gICAgIkJhc2VFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1BVTYtVERMSi01
  WTZKLUY1NFctM1dQUC03U1FGLVNIUUsiLAogICAgICAiUHVibGljUGFyYW1ldGVyc
  yI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOi
  AiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIk1XQkQxanBTLWZRQ0Y2LXhQT21
  HY0pNVC04UUpMZHdFdFItMEN4R3lIaWdWVWFFUnhhNU4KICBQNnQ0N3RTTTgtd0pY
  YUlDcTF1Y3VxT0EifX19LAogICAgIkJhc2VBdXRoZW50aWNhdGlvbiI6IHsKICAgI
  CAgIlVkZiI6ICJNQUpaLTVFVVktR0w0My02QzM0LVJIN0QtWjdPRi1BSU00IiwKIC
  AgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREg
  iOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6
  ICJfb1EyR0lOZkNLZWVuRHY1SFFCVzNncEZFREZsZjZBVkhmSk9Hb2w3bHlKeWF2N
  1NUODBaCiAgWjhuMDhzdUZSc2daT1dQakhadkYyS29BIn19fSwKICAgICJCYXNlU2
  lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CSkgtNUc1Mi1ZU0o2LTdHNEwtNDc
  2US1TNVJILVhQNzQiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAg
  ICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogI
  CAgICAgICAgIlB1YmxpYyI6ICI5Um5rYmxyTWxxbXRsTlZTNFhlSWMzLXpCS2U3ME
  RseWFJUHRxcGxpUUNaUXVxMFJaR3dxCiAgT183TEFIVDBZRGJ1ZGhfUDNteEVQaVF
  BIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MASU-GWSQ-MWUH-2BT7-Z76U-PXMO-J6N5",
            "signature":"6O2dX5cVQxdt-oinwfiCkYi8IfXKmBRBY2d25zGD
  nJTF4e5ZTa9zIlXXbkkgalRoKO4zDlN2Pc-ApQ3kQdiaiwn1DX8nBfYwg73zcmO9k
  oOo6CLuPV0QjnHt2bcCaIJfU_DyudpoC7TqJhMUGa91jDQA"}
          ],
        "PayloadDigest":"JVvJWlbtaWKzb9CwG0dM2fMLjL2Q_5uVTUcMyTSE
  _pjqzo8FM4yU94ckDs4lpogk5S7DKnj0B5dRAmQvBvCfyA"}
      ],
    "ClientNonce":"X3fVx7yxiT4y0LMAJ3WZ2A",
    "PinId":"ABM5-DVCA-KOAF-YPHM-PFWG-LNBI-MLGP",
    "PinWitness":"EQj8nnDHIHe-3qdoD75qHOmBh815GEkj5qGSqsbFZt92tM-
  CfTUUTyMe505dsmIVYZ1sCMSEhrDQlWDNE929OA",
    "AccountAddress":"alice@example.com"}}
~~~~

The administration device can now use the PIN Identifier to retreive the 
MessagePIN from the Local spool and use it to verify the request.

