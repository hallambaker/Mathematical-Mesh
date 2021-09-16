
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool:

~~~~
{
  "MessagePin":{
    "MessageId":"ABXJ-LRZD-2BXO-LRB3-2M6V-YOKN-XN6Z",
    "Account":"alice@example.com",
    "Expires":"2021-09-17T11:46:49Z",
    "Automatic":true,
    "SaltedPin":"ABN6-O3O3-FWJ3-42NH-BQEX-ATKD-PRKB",
    "Action":"Device",
    "Roles":["web"
      ]}}
~~~~

This pin value is used to authenticate the connection request from the device:

~~~~
{
  "RequestConnection":{
    "MessageId":"NCAW-MSKJ-GFJB-X5HI-AFOL-5BCU-ASWV",
    "AuthenticatedData":[{
        "EnvelopeId":"MBYY-FQE2-ZN72-KU2D-KS5G-RKUR-URKT",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQllZLUZRRTItWk
  43Mi1LVTJELUtTNUctUktVUi1VUktUIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTA5LTE2VDExOjQ2OjQ5WiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUJZWS1GUUUyLVpONzItS1UyRC1LUzVHLVJLVVI
  tVVJLVCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIk4yLUMzeEJDTnA2SzhVN1BkRGxsS1Y0dzNKNkV0VU5rTkpMcE
  NyWnd1RVpuQXZaNk9jV2EKICBKS2JfMTQ1cHloZExUQmNCOW9YSHNNU0EifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJHRC1OR1VHLURLSkst
  UU1UQy1QNUJSLUZHS1MtTVpBMyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiQ2pOeWpoZmNFb1A2Q01ERTZFMXNNTXZ
  xLW0yb2hTbHFxXzZqTWxhZXhzbmRBQjlpeUs3TQogIEphMzRWdUl0elh1Zm45QWhW
  c09fWlcwQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CN
  k4tWVVIRS1QSVhRLUMzTE0tWjNQVy1RU0dBLUVXWlciLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJtS1B5WXNldm5Y
  aEtFUTJ1SWQxMGlnNFhrQU1EQUctRlhFS0w2a1pfNWlDVFN6T1ZqRVZvCiAgRkdid
  lFrb09GbU9EX29jUEstMnNQR3FBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQVk2LU5NWVAtTVlMVy1CN1FDLTQzMkYtVlpYVC1RR1V
  XIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICIySHp6LXlmZHNxMkl2VHdvaXNOcFlUaGt4MmxEV3lKNy1ISDQyeW92cH
  hZNmVNcElyUjczCiAgUk5KRlVMVGNPN1NCc3JhNWVVUGZXbmNBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBYY-FQE2-ZN72-KU2D-KS5G-RKUR-URKT",
            "signature":"4e5Io9pVPByDTg4WNQrgNLoVs755mqUjOU__WL7R
  pcbVi4E_XDGFpegwZyFJE6q6qBTZpD-FJ8sAyKfk_TEX_btRVfpOEeOaCNjMKUGPG
  0zUAhiGSbNZoZEustXd5XS_6zopXMUZWs8MkS5vdeDM-zAA"}
          ],
        "PayloadDigest":"TPFRF7kVPSjU-BcT4iqc5CHXcyET05YZnv_-DS_p
  oHD3zCvjAG3ly_pLoh2lGHfxVXV4VaSxDbilmjg-xn4w2w"}
      ],
    "ClientNonce":"dLESXSrzEtkbZ575Tnqp_A",
    "PinId":"ABXJ-LRZD-2BXO-LRB3-2M6V-YOKN-XN6Z",
    "PinWitness":"p5LN3X3QRIdLF556fPeP4m1ueBZZdfzkCgAAuv8kUkt5vCJ
  -8ZhV5H1W_koskUGurC4Qtkjze-ysoMwtPqtTbA",
    "AccountAddress":"alice@example.com"}}
~~~~

The administration device can now use the PIN Identifier to retreive the 
MessagePIN from the Local spool and use it to verify the request.

