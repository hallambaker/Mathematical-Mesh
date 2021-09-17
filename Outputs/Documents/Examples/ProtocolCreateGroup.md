>>>> Unfinished ProtocolCreateGroup


The request payload:


~~~~
{
  "BindRequest":{
    "AccountAddress":"groupw@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MCBI-SOPK-HCTR-QEDC-YHFU-PRKI-436A",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ0JJLVNPUEstSE
  NUUi1RRURDLVlIRlUtUFJLSS00MzZBIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUdyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTZUMjM6NDg6MTZaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZmlsZVNpZ25hdHVyZS
  I6IHsKICAgICAgIlVkZiI6ICJNQ0JJLVNPUEstSENUUi1RRURDLVlIRlUtUFJLSS0
  0MzZBIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymxp
  Y0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgI
  CJQdWJsaWMiOiAiUjhaaGV4c2JpVXdCZk5IcFJKSEV5czIzRTVkdUlmQThIT0xJYU
  xCRnBnOFhCY0VsZU9hegogIFVWb04xU2t5c0NuSEdvZktaTDdtTEFrQSJ9fX0sCiA
  gICAiQWNjb3VudEFkZHJlc3MiOiAiZ3JvdXB3QGV4YW1wbGUuY29tIiwKICAgICJB
  Y2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQTRLLUJNNEstNU01N
  y1RRUJCLUlGRlUtSFg2QS1DTFc3IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOi
  B7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg
  0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ5cFVyYnlWTkVFUkExUU5SOWtNMWEx
  YllvSUFSWU9FWlNqcmhRX1RHRzZIYmdYNHRjRV9FCiAgaWdHUGdsX1d6TzBoRHFNZ
  FlQRmlhU2tBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogIC
  AgICAiVWRmIjogIk1BNVEtSENJVC1LRVRDLTVNNVAtUzVSNC0yQUJHLUJDUVciLAo
  gICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNE
  SCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJRSm1sWjEwbVpMdW5zc25aQldDXzJWb1JzM2wzUGZqSkJOZkM2M1ZJY1pXY0
  5Uc0FZVFNkCiAgYzJXbnFBdEJNdW5leFhVYUk1V1hleXVBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCBI-SOPK-HCTR-QEDC-YHFU-PRKI-436A",
            "signature":"Ds2WOWc6ZQE-5LOmzu8jJtK5zCUQoNoDoKKpmu8c
  srozCnwsS_B1WIWD1xXRpYxpCD_FNxs8UoOAgRW9kArbkY86O7hwOqk4pwTLlc37r
  jySJXfJk_0prvbd565p2KTqrkMDV4M5KkVC8Lsqzr9u3BkA"}
          ],
        "PayloadDigest":"BQKUVz9I4not7EkwBDaCCm3aQ5O1T-VJVlHq4KFF
  qHnKg0ifd86tuD5f9W00-goTWy17_V2vanXppsx2mrpnuQ"}
      ]}}
~~~~


The response payload:


~~~~
{
  "BindResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


