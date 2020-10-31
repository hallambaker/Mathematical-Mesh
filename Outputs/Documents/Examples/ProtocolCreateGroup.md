
The request payload:


~~~~
{
  "BindAccount": {
    "AccountAddress": "groupw@example.com",
    "EnvelopedProfileAccount": [{
        "EnvelopeID": "MDCY-LAVD-SMO7-53QM-A4XG-TNTO-ZIUM",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNRENZLUxBVkQtU01PNy0
  1M1FNLUE0WEctVE5UTy1aSVVNIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Udyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjAtMTAtMzFUMDE6NDU6MjNaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZml
  sZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNRENZLUxBVkQtU01PNy01M
  1FNLUE0WEctVE5UTy1aSVVNIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB
  7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiXzFod0daNHlEZ2hfZnU1X0x
  VQTlwU2NNSnhBSTZJSTd1WHBreGtLeURJYzk4NWs3WFplcAogIEFtZXR6b09HN
  DdKTmtHdE9US3l3Y3FnQSJ9fX0sCiAgICAiQWNjb3VudEFkZHJlc3MiOiAiZ3J
  vdXB3QGV4YW1wbGUuY29tIiwKICAgICJBY2NvdW50RW5jcnlwdGlvbiI6IHsKI
  CAgICAgIlVkZiI6ICJNQjRaLUlMREMtSllXTC1DWlJBLVRINDYtWEFBWi1FV0R
  IIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJnNWt5SXd4V0ZwX2xoWDFoRVJyME5OVVRGQnpfT01vby1VU
  XQ4Tm1jbDlTN0xKN09TYmFLCiAgaUgxZ3NOY0R4RjNwdHFJaDd0ZjhaTDZBIn1
  9fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogICAgICAiVWRmI
  jogIk1EQ1ktTEFWRC1TTU83LTUzUU0tQTRYRy1UTlRPLVpJVU0iLAogICAgICA
  iUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6I
  HsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI
  6ICJfMWh3R1o0eURnaF9mdTVfTFVBOXBTY01KeEFJNklJN3VYcGt4a0t5REljO
  Tg1azdYWmVwCiAgQW1ldHpvT0c0N0pOa0d0T1RLeXdjcWdBIn19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MDCY-LAVD-SMO7-53QM-A4XG-TNTO-ZIUM",
            "signature": "Mm21S5nkbAvsYIBpbh2A4muyNk97VcaaHNkX3zEL1ENRwYwNH
  xlEDw_ilAy_XmQgEkr5rGDHPeQAys0DGZyKAjIdY_ccLayadkP5Prx1l5ZYdex
  gvOe4bvCfp8qj0d7F2pGT9YtF1mtK230DGARLYwoA"}],
        "PayloadDigest": "t-NYnD7GVF85VySJuHxcpmXEusXqw0kZrUDrtwNTAPJDC
  mUi9fWvNrEBJ_oREbwRCeDWYlyFlNTBuj-LWI4XhA"}]}}
~~~~

The response payload:


~~~~
{
  "BindResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully"}}
~~~~

