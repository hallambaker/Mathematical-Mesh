
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool:

~~~~
{
  "MessagePin":{
    "MessageId":"AAKU-OCUD-R4I3-NU32-WDXX-FKWU-CMFZ",
    "Account":"alice@example.com",
    "Expires":"2021-09-17T13:53:34Z",
    "Automatic":true,
    "SaltedPin":"ABNF-BPK6-A2YB-I3QH-BXR5-OB3N-TXIQ",
    "Action":"Device",
    "Roles":["web"
      ]}}
~~~~

This pin value is used to authenticate the connection request from the device:

~~~~
{
  "RequestConnection":{
    "MessageId":"NCJY-JDLK-EESF-W6AG-ON2O-Q4DM-VPSP",
    "AuthenticatedData":[{
        "EnvelopeId":"MA5U-5EXH-IEZE-T32X-U653-IWR6-D6WR",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQTVVLTVFWEgtSU
  VaRS1UMzJYLVU2NTMtSVdSNi1ENldSIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTA5LTE2VDEzOjUzOjM0WiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUE1VS01RVhILUlFWkUtVDMyWC1VNjUzLUlXUjY
  tRDZXUiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIkM3SmJiVkRZckxxRzJBMGktcUlLVWhlUlNBdDd4b0Y0ZWtYMX
  Jaem1FRHM5UjZndXF0M2YKICBrUFFHV3FONDBCY3NudlBBOV9ZZFhoNEEifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUNXTS1XSzZPLUVRVUUt
  SUVVRS1FWjNRLUNCUk0tUDVYWCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiRzUxclp0SXdVS0FiTlo3NzBTVnlqSTR
  pOXlReW1mUkNfbUFfV01QWE5PSDFkVTNYM1M1QwogIGo4NHN0VVZiaENBM0VLSnM2
  UVA4ZC1rQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1BW
  DctNE5MWC1CTzVKLTNXUFotTVpMSy00NlpELVRQTlgiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJzdFpnRUZYd2No
  STRxM0h5czlvb0IyaGZIUXZucEVMMXhUbmN1WGJvUmFXM1lnRHhPMzJOCiAgSzBKT
  Vk2NE9ja1dHZ1M5bkY0bXN0VWlBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQlVJLVJKVEEtN04zRy1IUEhQLTZUWVMtUVpLSi1LNVl
  HIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJWVVNDMDFIUEJJY0lMbmdWNU90ZkRfNVRXRlZBSk9zNlpMcGZndF9Vd3
  VxR2RmYnd5TmhSCiAgM0VkNmxydndxMUdSUkVtVUVkWVkyQm9BIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MA5U-5EXH-IEZE-T32X-U653-IWR6-D6WR",
            "signature":"sX84Yb-Wb0y1kK2_EOyEGLyVqdT0ejXZ79B-Goy1
  lfbgncao3V2ADoQOuOESqVzAF4ycozFY_bSAv04V5jiU27vEcP1GovhHwcTrgUJJ8
  sqBrOL_fAPOjLHPGJxhhM3cTKDVyWnnuC2bYqjRAjG1BxYA"}
          ],
        "PayloadDigest":"gLt5FIyQfOJ4z531WLXT9wk-lVai1XQk7EDNBy9Q
  peO1J5LSF7kbH69uDRH1EIzMbHC3nTd8wOrj3pEXA0TQYw"}
      ],
    "ClientNonce":"4Rgb6W6R9Q-pZbRTKDxVXQ",
    "PinId":"AAKU-OCUD-R4I3-NU32-WDXX-FKWU-CMFZ",
    "PinWitness":"VI65G-ZweSV61-8rrmSgFIBsnpyzCrruRemrsODNLS3SXra
  ec6DRBK51gV7lroQhepfzRljgYOnhR80FY8FYZQ",
    "AccountAddress":"alice@example.com"}}
~~~~

The administration device can now use the PIN Identifier to retreive the 
MessagePIN from the Local spool and use it to verify the request.

