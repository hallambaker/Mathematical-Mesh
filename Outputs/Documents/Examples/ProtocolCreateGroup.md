
The request payload:


~~~~
{
  "BindRequest":{
    "AccountAddress":"groupw@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MC6I-HAIY-Y7GG-RU2X-2NA3-CNCL-WLAU",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQzZJLUhBSVktWT
  dHRy1SVTJYLTJOQTMtQ05DTC1XTEFVIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUdyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDEtMTFUMTc6MTM6MTdaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZmlsZVNpZ25hdHVyZS
  I6IHsKICAgICAgIlVkZiI6ICJNQzZJLUhBSVktWTdHRy1SVTJYLTJOQTMtQ05DTC1
  XTEFVIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymxp
  Y0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgI
  CJQdWJsaWMiOiAiSlBOZjI0Yk03YnlDUjB4TF90aUhtLTJmTlRycFZadWhwQ2xRak
  lWcl9oeEt0Ukl2QlhCRwogIGFwd0FiUzRmS3VhaTViMmtlamlmLTlhQSJ9fX0sCiA
  gICAiQWNjb3VudEFkZHJlc3MiOiAiZ3JvdXB3QGV4YW1wbGUuY29tIiwKICAgICJB
  Y2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ1o3LUtYQjItUFFCW
  S02Nk1FLUxVS0wtREpHTC1aTTVHIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOi
  B7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg
  0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJfY2RjdnNXTVhDVEN4Vmo4Um1pVXVr
  Q0NOY2FaWEZ5UTExZ2dWMldUSmFuUEdMOVg2bG9qCiAgVUZyTDJDaUg0VFd5S0ZHV
  WN0cU1TX2tBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogIC
  AgICAiVWRmIjogIk1EN0MtQVFZRi0zUEpZLTVVQk0tUElJSS1GNkROLVpaS1giLAo
  gICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNE
  SCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJqcXRuVVFyODJGOE1RWmlubTEzbFRSU3VhaDY0UDdUa3ZZeWpJOGZUbW9Gcn
  VENmNmUE5fCiAgQmptM2d6U1NzM2RINmwtcWZqMlI3SnNBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MC6I-HAIY-Y7GG-RU2X-2NA3-CNCL-WLAU",
            "signature":"YloZLEU38_tzWYUWP0BSF-36LyAkRFOIFeJE4CzH
  nz8p1sgAKjnk2II7UssNGJtmRJG_0ydGC44Ak_6E_CpT1ZW_erzjNvFaa2Tqeo485
  LFYh_VGYimYNMpH2cT-kJ2jUW71ioUAempnmrFZPNJ2YwIA"}
          ],
        "PayloadDigest":"dsciQfqjVNZnlhDdVVvTA8g1b_W6kFeGXBwc6e-o
  vVwIZvhiB6PqIIya1GeBVgm1v_Q5iZYErUGKjLC48KzUAA"}
      ]}}
~~~~


The response payload:


~~~~
{
  "BindResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


