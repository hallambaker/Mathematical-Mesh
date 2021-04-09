
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool:

~~~~
{
  "MessagePin":{
    "MessageId":"ABWN-6IXG-Q7GI-QLSQ-ISRC-OYHM-AAZV",
    "Account":"alice@example.com",
    "Expires":"2021-04-10T18:13:14Z",
    "Automatic":true,
    "SaltedPin":"ABZ2-JREO-CTK2-LD5Z-EYTK-NMD4-VK44",
    "Action":"Device"}}
~~~~

This pin value is used to authenticate the connection request from the device:

~~~~
{
  "RequestConnection":{
    "MessageId":"NB5S-X4VR-WBFZ-Q6QO-WTNE-KFLV-UVDS",
    "AuthenticatedData":[{
        "EnvelopeId":"MAKM-BWNG-RIHB-KQPM-EBDO-4FE4-2TIK",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQUtNLUJXTkctUk
  lIQi1LUVBNLUVCRE8tNEZFNC0yVElLIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTA0LTA5VDE4OjEzOjE0WiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUFLTS1CV05HLVJJSEItS1FQTS1FQkRPLTRGRTQ
  tMlRJSyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIlJ0cWpLX0FyUEF6N3VQQjgwbWY0Mm45Sl90N3k5MVg3dEcweX
  ljbHd6VURrVTFGU2VnekwKICBtMTdlTTE4Rm9JcldVUlZIWEIwbjJNV0EifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJHRS1CSFVVLVJJREct
  SlZLRS1aQ1A2LTVPRFctQzRPUiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAic2lHb3JuQlhSWnRXa005VDJnTzNTSmF
  NQ0RtcXZBV0V4bEFnLW5oSDhwNDRzbUdoVjVkYgogIDZWSmNRM1JfSF9XYndnX3Nz
  S0tfNmRzQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1BU
  UgtTlZNSi1GMlhDLVdGV0EtMlZLRy1MQko3LTZIQUciLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJqX09IZFRkWXMz
  V1ItMEVGSzBrUnV6TTFULWdHamM0eXpqeTBaOGM5Y0tqcm9QOWQ1WVlqCiAgbWtld
  HE4YzdUa2I5TTZDLTdUNDctLXdBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQUZULU1MN0ktQ0xJSC1UTUZVLTNJR0ctNDNSRC1DUjU
  3IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJ4emdKalVobU1wT3M3Y3F0bHpqMTNXOEZBNmZfcnNmVjdpal90SzRVd3
  JjRFkta3U4ZUJmCiAgelRKd1lZVjVXNFFWOXc4OUJyOXJBbG9BIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAKM-BWNG-RIHB-KQPM-EBDO-4FE4-2TIK",
            "signature":"IpqM3P7h3HYHSfSENSflMmjhrrxz_DOlmX3Fiw7_
  hg_AaN0-cnuY1Vym8WOgwgieIfl3ClNphgGACgNoAR8jqtc3wUIOl8qn9dck2KA4m
  GiQqGeqj25CpEMGBgMU2TFeRYoE-0Vs7COv7TDGUEcQ-BkA"}
          ],
        "PayloadDigest":"PAoS2QBP6Tb4aY4Ks7awLvhlZrzj1JIlI29Dpu2Z
  vBjk-IdYyRn57th1EabvtedV_14LkXN7T20Ge6R-jaEKxw"}
      ],
    "ClientNonce":"_8AbmvDeL5Qc20PYiQLqew",
    "PinId":"ABWN-6IXG-Q7GI-QLSQ-ISRC-OYHM-AAZV",
    "PinWitness":"dgVtKuOdIQsdFA4Z6No_O1Do7jpjXXK5eYumDaeRyrhy5F5
  zp0p489B0qOO-x2dQ-QWZXKBsQ7qo5epN34bZ9g",
    "AccountAddress":"alice@example.com"}}
~~~~

The administration device can now use the PIN Identifier to retreive the 
MessagePIN from the Local spool and use it to verify the request.

