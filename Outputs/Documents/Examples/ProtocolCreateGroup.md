

The request payload:


~~~~
{
  "BindRequest":{
    "AccountAddress":"groupw@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MCMX-6HA7-YNMX-U7P2-4K4F-O7VI-3GCY",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ01YLTZIQTctWU
  5NWC1VN1AyLTRLNEYtTzdWSS0zR0NZIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUdyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMThUMTg6NDY6NTVaIn0"},
      "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZmlsZVNpZ25hdHVyZS
  I6IHsKICAgICAgIlVkZiI6ICJNQ01YLTZIQTctWU5NWC1VN1AyLTRLNEYtTzdWSS0
  zR0NZIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymxp
  Y0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgI
  CJQdWJsaWMiOiAiTjdweHU1OXlJNnl1WHlFZ1R1Q2RqZXdqN3VYMnFSamttb1VUc2
  tIOF9wVkxldUFsclNhVwogIC0yaFdxTVk3dzNpLWNsY3RSZktoQjJlQSJ9fX0sCiA
  gICAiQWNjb3VudEFkZHJlc3MiOiAiZ3JvdXB3QGV4YW1wbGUuY29tIiwKICAgICJB
  Y2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNRDJGLVNPUTUtNDZQR
  C1BSFVHLVNPSkwtSFMzMy01WElXIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOi
  B7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg
  0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJyeks3MjE2Vmx4b25wQkdOb3h2Vnlu
  d3B0X3VSckR4djMxLTdCaG1Wck1NWHIyOVJqYkE2CiAgUUlEdXhaSE9Bb3BfUEdsV
  FNFRWtISVNBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogIC
  AgICAiVWRmIjogIk1DSE4tWlFZUi03TFhSLVRMTVAtMjNMNy1PQTVELUlLUFUiLAo
  gICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNE
  SCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICJMSjBqRnRjN1lyWTh4ZWNRTXhmM1dRQnlaZHN5b2YxcVFxVHBuMGpUZXhLVV
  VNWjJacElICiAgR3hhM3NORlBhN0liYldrTEZSQTN0WGNBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCMX-6HA7-YNMX-U7P2-4K4F-O7VI-3GCY",
            "signature":"D1I-ZTkjbl48tof3EgwJ4z9mGUsLehegFwUHdDH5
  yobx4ojrBBmJW6Y6yJblNXrc0a-KzH97DVWA0WhOpFMEOnmdNKXz8mgvvcWgC7_BC
  oQqiGFLgzjSebGx-Znl2tEkd6fmgbHVBMEGY-hyePGV0ScA"}
          ],
        "PayloadDigest":"F5FIc0VlwaBtH2-yX3mb8nZjfB-0QqW48rBZ2SxI
  lwv483ir2nCmlIwMK0vtaTisIYBkMEZAASFxP-HMvJjVAg"}
      ]}}
~~~~


The response payload:


~~~~
{
  "BindResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


