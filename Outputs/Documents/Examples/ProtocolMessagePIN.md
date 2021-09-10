
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool:

~~~~
{
  "MessagePin":{
    "MessageId":"AC4E-EWWE-MQNQ-RYR6-DDZB-EVCS-AF24",
    "Account":"alice@example.com",
    "Expires":"2021-09-11T17:22:17Z",
    "Automatic":true,
    "SaltedPin":"ACU4-IFOZ-UFDV-HZI5-I2B6-ZWHL-2WVH",
    "Action":"Device"}}
~~~~

This pin value is used to authenticate the connection request from the device:

~~~~
{
  "RequestConnection":{
    "MessageId":"NC3F-SBZC-IZQ7-UT5G-NJVR-EWT3-EYCH",
    "AuthenticatedData":[{
        "EnvelopeId":"MCPR-DNGN-UE54-UDDV-PQWL-65AV-SSUC",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ1BSLUROR04tVU
  U1NC1VRERWLVBRV0wtNjVBVi1TU1VDIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTA5LTEwVDE3OjIyOjE3WiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUNQUi1ETkdOLVVFNTQtVUREVi1QUVdMLTY1QVY
  tU1NVQyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIlYwVnRGOTZJbkFsbjg4ZUp1X0VYazkyUnAxbmtJaU02Mm1lVk
  F5UVo5dnhCSWRFXzZ4el8KICA4cFVCWklpUVo3TGVBRGRTdXk1YVpOMEEifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUM2My1PWUE2LUxLWVQt
  UVFIQy1KMko0LUVDNlAtUzJQRyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiTzlCc0d2WDE3NVhSbWR6MkpMNXlabVg
  2bGQyTk1VaGFyUE5obE04elpPM1hSZ3ZfVDFWSQogIEM0U0g2TkdJWTBUbnExQzY4
  VVZmTVF3QSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1BV
  VotT0VGSC1aQUtQLTRWMjItUFc0NS1JMzZSLTRaUTYiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJPbzBHM1M3emV0
  Z0ZRa05Ea0QyT1QyeWt4NEpQMkJHblhpVlkxZ0lkakgzRVdzZmRLR1h6CiAgSVQxd
  VV6WWF4RG92SGUwNHRfQmxkNzhBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNREdYLVhHUFgtTFMyWC1CSE5CLUFBWTItTExIUC1NR0l
  XIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICItYTN0VXRzd0ZOT2xaMGdqcmdiWDVmdUxwTnNWdGZQeGhpdUVaXzJySG
  pScTNkMzk3RWw3CiAgTnBXMld3NmhtdS1vQ290aFZNc0d6OGlBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCPR-DNGN-UE54-UDDV-PQWL-65AV-SSUC",
            "signature":"c-ygJXEYlMgxRQUQqYIyVtM_RYtX9HwgYnZA78gE
  fG5UUCILHdBApQLTeLFqwSdjPzF4ut5ySaSAK3ZhH7ZQmtUNtvvNUOUhryxRghd25
  j0RChY5dVQbkLm4Nfi6fIaIUOEMVTYUo5SpqTLMFtZd0wAA"}
          ],
        "PayloadDigest":"6Q9FyqT5suDmdLMebOYmofL_6cO05nhQP8cRxLu_
  1wPx4PF-rMDNxLZsCutMNg38N3pQU1sRMrRZsbMe_RCJXw"}
      ],
    "ClientNonce":"D2dYqc5hvC1LO4vB2Pn7mA",
    "PinId":"AC4E-EWWE-MQNQ-RYR6-DDZB-EVCS-AF24",
    "PinWitness":"87U7FcRv_ZF0nKJHAJBKVb_LpeYmI8V-mKAN1D_UvWTXSQT
  tZFKk1dGR5jR_k70kDXGrrAix92PcAkAO6pIipA",
    "AccountAddress":"alice@example.com"}}
~~~~

The administration device can now use the PIN Identifier to retreive the 
MessagePIN from the Local spool and use it to verify the request.

