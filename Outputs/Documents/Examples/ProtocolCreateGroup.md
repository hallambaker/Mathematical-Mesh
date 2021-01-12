
The request payload:


~~~~
{
  "BindRequest":{
    "AccountAddress":"groupw@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MAX2-C5S5-VJUZ-W2QO-RYBF-4IJS-IMHA",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQVgyLUM1UzUtVk
  pVWi1XMlFPLVJZQkYtNElKUy1JTUhBIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUdyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDEtMTJUMTg6NDI6MTdaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZmlsZVNpZ25hdHVyZS
  I6IHsKICAgICAgIlVkZiI6ICJNQVgyLUM1UzUtVkpVWi1XMlFPLVJZQkYtNElKUy1
  JTUhBIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymxp
  Y0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgI
  CJQdWJsaWMiOiAiMXRoZ0VabDJBWDJocWNFUVBPRTlMakpjTHN1bndRUTlNUlhHaW
  pEQ1hZN0RJTXNtQUpJMAogIEFZVnFFZ29UUzdERGpqQlNOR3ZWaU1hQSJ9fX0sCiA
  gICAiQWNjb3VudEFkZHJlc3MiOiAiZ3JvdXB3QGV4YW1wbGUuY29tIiwKICAgICJB
  Y2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQllTLVVMRTUtQllXR
  S1RT0Q2LUxVNlEtUFBaWC1XWVBTIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOi
  B7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg
  0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJoTTQ0ckxjMGlTb3Q1Y1lnRWczcjRH
  bmJWTnpnd0IyLTYyMDR5eWF0RFlQSDFQeFFXUzBPCiAgNVNFUkVPc1I2OFA5Y2MwT
  DVpc0JQM21BIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogIC
  AgICAiVWRmIjogIk1BSUktUTdJTi03WUtCLUIzSTUtVVEyUS1OQjVXLTIyNU8iLAo
  gICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNE
  SCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJpck43Vk9ZelFxSTZuUzY4ZHhmZnRFRnY5eTd1UWNMQmMyZ1pvM1M4cDhiZH
  ZpY1I4Zmh6CiAgTUh2aVFGM3dwcWVVOEFmcXpWSjdpRnVBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAX2-C5S5-VJUZ-W2QO-RYBF-4IJS-IMHA",
            "signature":"f-qnwxo0uRK1cVj2JEmGKV2OmkXDGJVWVTRBVh6n
  qnU4qmMaYhiNxxQmwxqeWOgINaog6MQ5AZuA_TCqsIkpeUmL96JSlSfWe2OCjdPkD
  mmoi0zvukQZO6DCBbaH2DaLi8jAP4fA-TyO4otI3OOWQg8A"}
          ],
        "PayloadDigest":"dHYXWfBaJDqLjDdvYJdTvsKOOc-Huz_xdNKRkiKq
  UouvIE_sYF9YPYF9verdWPo0iLy8LViLzwncOoYVYSfGIQ"}
      ]}}
~~~~


The response payload:


~~~~
{
  "BindResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


