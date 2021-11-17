
### Phase 1

The manufacturer preconfigures the device


~~~~
<div="terminal">
<cmd>Maker> device preconfig
<rsp>Device UDF: MDDT-KTDT-AZ62-55HV-FFVY-JYNU-Y3YE
File: EC6P-KOIX-T3B4-YIKE-OLX3-BUUD-64.medk
</div>
~~~~

This results in the creation of a primary secret which is used to compute a ProfileDevice
and corresponding connection records signed by the manufacturer's administrator key.

The data is combined to create a DevicePreconfiguration record that is provisioned to
the firmware of the device being preconfigured.

~~~~
{
  "DevicePreconfigurationPrivate":{
    "EnvelopedProfileDevice":[{
        "EnvelopeId":"MDDT-KTDT-AZ62-55HV-FFVY-JYNU-Y3YE",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRERULUtURFQtQV
  o2Mi01NUhWLUZGVlktSllOVS1ZM1lFIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTEwLTI1VDE1OjQ5OjA3WiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUREVC1LVERULUFaNjItNTVIVi1GRlZZLUpZTlU
  tWTNZRSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogInF0TDhCYVN3UUptNk12bE1BUXY0MkpsSk9MWFZMY0gxTWNweU
  p1SWxJazhXbVpvYTlHd2MKICB4WjFIMmI5VE5MZGFZUGp1VlVaWHRkb0EifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUFCQy1MR1k1LUJVMk8t
  U0FaTi1ESjJFLVMzQ0ItQkc2NSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiWDZUaF9IOEJZOC1zRHpydWNVV3F4S0c
  1YVloenhTVC12dDE5STlKOU83TmlnRGYxZmhEcQogIGZCT1pWWk9uUDhYNVdTMkJJ
  WGQ3SjlTQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1EW
  lQtREFFNC02TkJQLUJSQ08tUzVUTC01Q1E2LVNDWTMiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJpM1hia3lpT201
  WnlXaWxBeU9DZnFUalBMaUtVLUgyNTJZVUdqRVd3MWgtZ2haR3Nkb09aCiAgcXRkQ
  0k4Q0hRYWtzS3JHTWZDdDMxbjRBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQk1DLVE3SFctNUlOSy1RU1pPLVBLRFEtS01aNS1BT01
  GIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJSX08tZnpLUnp4aExsdHh1Nko5VG05MVNHSWFCY2g0LXFfNnFwNTZ4WU
  YtVTZqa0hSall2CiAgT2hjNm12OUdLOVhNUjZtVFNOUEstV0tBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDDT-KTDT-AZ62-55HV-FFVY-JYNU-Y3YE",
            "signature":"VFD-9f8AXHdm38HR7y7JKsPStGNRu7wW5SXsJgc1
  lbRyzQ0XVyDyNtqR5el9TCEuJKC0vU4lq4QAQfzJlUaa-viM7xhTcvJhVZ_YGiYEW
  wq3Nb1-sortDNUdi7FGmG9C5Nh-ErWxy2oKkH8Nht19LDQA"}
          ],
        "PayloadDigest":"PRkvfQ8djpN_Z3tY_p8qPRR4rTy_ZFEFW_WAqBcQ
  2WpffnNZf_dPVKtW1XW9IpGjxYg2h0zB-hSVnCWViSUiEQ"}
      ],
    "EnvelopedConnectionDevice":[{
        "dig":"S512",
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjEtMTAtMjVUMTU6NDk6MDdaIn0"},
      "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIkF1dGhlbnRpY2F0aW
  9uIjogewogICAgICAiVWRmIjogIk1BQkMtTEdZNS1CVTJPLVNBWk4tREoyRS1TM0N
  CLUJHNjUiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIlg2VGhfSDhCWTgtc0R6cnVjVVdxeEtHNWFZaHp4U1QtdnQxOU
  k5SjlPN05pZ0RmMWZoRHEKICBmQk9aVlpPblA4WDVXUzJCSVhkN0o5U0EifX19LAo
  gICAgIlNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNRFpULURBRTQtNk5CUC1C
  UkNPLVM1VEwtNUNRNi1TQ1kzIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7C
  iAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiaTNYYmt5aU9tNVp5V2lsQXlPQ2ZxVGp
  QTGlLVS1IMjUyWVVHakVXdzFoLWdoWkdzZG9PWgogIHF0ZENJOENIUWFrc0tyR01m
  Q3QzMW40QSJ9fX0sCiAgICAiRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ
  UJDLUxHWTUtQlUyTy1TQVpOLURKMkUtUzNDQi1CRzY1IiwKICAgICAgIlB1YmxpY1
  BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICA
  gICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJYNlRoX0g4Qlk4
  LXNEenJ1Y1VXcXhLRzVhWWh6eFNULXZ0MTlJOUo5TzdOaWdEZjFmaERxCiAgZkJPW
  lZaT25QOFg1V1MyQklYZDdKOVNBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDQJ-G5K2-BJ66-MPLM-FWSA-665O-MILP",
            "signature":"r-JxVZxihprjMs3buV4yqmgXO7NdXlAEI-Cn2nYF
  HB3rlbcNPwmi5z_0f5HpAXkQfFlVJefnxsMAffF8GNbOocmVEdaIXR8rHDkBMa1xd
  6iCaWZdv8SAGdTHK0wLHkeAUDGj2wXsINFTMfDqhh_TjRUA"}
          ],
        "PayloadDigest":"aT7dqhsuhW15GSExnBrO1nHQqAcT-uLaCUkJPhqg
  AevgNUtTUuWkHC63T2ensFiSjCAAXd1YOvp7L8V7twmvZg"}
      ],
    "EnvelopedConnectionService":[{
        "dig":"S512",
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICA
  iQ3JlYXRlZCI6ICIyMDIxLTEwLTI1VDE1OjQ5OjA3WiJ9"},
      "ewogICJDb25uZWN0aW9uU2VydmljZSI6IHsKICAgICJBdXRoZW50aWNhdG
  lvbiI6IHsKICAgICAgIlVkZiI6ICJNQUJDLUxHWTUtQlUyTy1TQVpOLURKMkUtUzN
  DQi1CRzY1IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1
  YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJYNlRoX0g4Qlk4LXNEenJ1Y1VXcXhLRzVhWWh6eFNULXZ0MT
  lJOUo5TzdOaWdEZjFmaERxCiAgZkJPWlZaT25QOFg1V1MyQklYZDdKOVNBIn19fX1
  9",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDQJ-G5K2-BJ66-MPLM-FWSA-665O-MILP",
            "signature":"BwF9R7byEqkzaUblEujRrko0zPuHn7NwH__14VRv
  YH0jTblJSrmG40hujXOKqs9ElXe8F0jM26EAXm6l0Okhi_stdxotXwa8CHLZgzTGO
  T9qEKdJElqkZIWLYJ9Tv_vM-VowlOz7jlzP4ThsVkI4fhcA"}
          ],
        "PayloadDigest":"KUSigElHIQenRINVDSSgH5M9Dt5GJLzKUk5yylWM
  TNdJ_4bW-JKREQiwutelFZvKv0-rX4XFnfBPwzmUflNY2A"}
      ],
    "PrivateKey":{
      "PrivateKeyUDF":{
        "PrivateValue":"ZAAQ-APQL-QS4L-SY3L-RER2-TYEA-V4EF-Q3OB-6N2
F-DKDP-UJQ6-KXUN-LI2H-7RXH",
        "KeyType":"MeshProfileDevice"}},
    "ConnectUri":"mcu://maker@example.com/EC6P-KOIX-T3B4-YIKE-OLX3-
BUUD-64"}}
~~~~

An EARL is created specifying the means by which an administration device can acquire the
information required to complete a connection to the device:

~~~~
QR = {Connect.ConnectEARL}
~~~~

The preconfigured ProfileDevice is encrypted under the encryption key and published to
the location key derived from the EARL.


### Phase 2 & 3

The administration device scans the QR code and obtains the Device Description using
the Claim operation as shown in section $$$$. The administration device creates the 
ActivationDevice and CatalogedDevice records and populates the service as before.


~~~~
<div="terminal">
<cmd>Alice> account connect ^
    mcu://maker@example.com/EC6P-KOIX-T3B4-YIKE-OLX3-BUUD-64 /web
</div>
~~~~

### Phase 4

The device polls the publication service until a claim message is returned.


~~~~
<div="terminal">
<cmd>Alice4> device complete
<rsp>   Device UDF = MDDT-KTDT-AZ62-55HV-FFVY-JYNU-Y3YE
   Account = alice@example.com
   Account UDF = MB5I-R24M-QXJT-KDBF-XFOA-DGC3-U3AA
</div>
~~~~

### Phase 5

Having been advised that an account has published a claim to bind to it, the device
posts a connection Complete request to the specified account and completes the
connection process as before.

