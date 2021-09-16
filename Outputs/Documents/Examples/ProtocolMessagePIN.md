
Alice connects a device using a QR code presented by her administrative device.

The administration device creates a PIN code and records it to the Local spool:

~~~~
{
  "MessagePin":{
    "MessageId":"ACRP-ZONR-F3S5-JHFV-I5LK-QBDO-3PJT",
    "Account":"alice@example.com",
    "Expires":"2021-09-17T18:32:53Z",
    "Automatic":true,
    "SaltedPin":"ACL7-NU5B-SW6O-PTCB-EYFF-BWBU-UEPN",
    "Action":"Device",
    "Roles":["web"
      ]}}
~~~~

This pin value is used to authenticate the connection request from the device:

~~~~
{
  "RequestConnection":{
    "MessageId":"ND5C-MTC7-6TDG-GLKM-SZF6-TRH5-CBSY",
    "AuthenticatedData":[{
        "EnvelopeId":"MDDJ-BS3U-ALM3-BBJT-4K3D-7GXW-NONU",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRERKLUJTM1UtQU
  xNMy1CQkpULTRLM0QtN0dYVy1OT05VIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTA5LTE2VDE4OjMyOjUzWiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTURESi1CUzNVLUFMTTMtQkJKVC00SzNELTdHWFc
  tTk9OVSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIlQwUm1CajRrODM3d2JDWXJjN3VicGxOdVpjckljbDlJalMtM3
  VzNVlSdkNEU3ZOMTNKX2kKICBLcmdEQnRadjl5UWdEWWloYVBXTmNYd0EifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUNMSC1aSzVTLUJGTFkt
  SEtNNS0yTFBZLVdXUVotTEZTUCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAicWZPQ2FYNUhMYlFLZ3NjR3g3OU1sal9
  DRm1ralVJSTR3OUJiLUtDSTE1TDllX2M5QURyMwogIFlSaUljaTBQMFA5aFkyNTRx
  MDYxbS1zQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1EN
  kQtRTNIRC1KUjNYLVdQUDQtU0RYNS1NN01DLUhXSkciLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJXRGZ2MXd2SjJt
  aEV2ZjFnV25IQkI3LW81b3d1VnNKSHU5cEpvOTNIRVZ5OHhMNERCNlZ0CiAgMG5Ud
  XdzS242YTlqV0lXa3VSTzFMTHFBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQ0o3LU9JR1MtWlRZRC1PTUMyLTdEMlAtRUNXUi1CVDV
  YIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICIxTVVnTU1xUWo5RGRSZGlUeF8zTl9KM1FZSlYza3BQSk95OGEyS0ZTY1
  FiUkxwQllhbFBqCiAgMXZMeVpRRXRoUzFWQlZYTkNlVURDN0NBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDDJ-BS3U-ALM3-BBJT-4K3D-7GXW-NONU",
            "signature":"GtzErlTu4K-VPrhQzP4C0FzfCNuVACsIVFy8xNJG
  x_-JfT_YfHi4oif0M5ZvVXx73znuNYLv2GwAAKVXJbiQDYG6hufb9z86CFBcWnVxo
  KhEAJyS0t1nMeykJ-Y33zEpOGhGEA1hn3f01nZQbm-6wCIA"}
          ],
        "PayloadDigest":"3nYPj3JaWSXzPRlMasxb14HsMW_06L5B1XfF6tNM
  AcS94nFbVrZOOPOvJV5BfyZsPn6yGKv96CzOuivWe574HA"}
      ],
    "ClientNonce":"Ny1XzsmO2AaDsn2RBhpcsA",
    "PinId":"ACRP-ZONR-F3S5-JHFV-I5LK-QBDO-3PJT",
    "PinWitness":"uxTjk43E0YqkTQrDQQMAR7EYNVixmv_PJHGwGYLCI2iingU
  tZKGF8o9k96EO6RAg5tpm2p8BvpO1fSvPWH0Sng",
    "AccountAddress":"alice@example.com"}}
~~~~

The administration device can now use the PIN Identifier to retreive the 
MessagePIN from the Local spool and use it to verify the request.

