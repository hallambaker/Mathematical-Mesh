
### Phase 1

The manufacturer preconfigures the device


~~~~
<div="terminal">
<cmd>Maker> meshman device preconfig
<rsp>Device UDF: MBOB-5GVY-Q43B-KODG-UJ3E-LY7V-36UV
File: EBKG-ED3O-HBHK-ZQGS-EX4H-X22S-X4.medk
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
        "EnvelopeId":"MBOB-5GVY-Q43B-KODG-UJ3E-LY7V-36UV",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQk9CLTVHVlktUT
  QzQi1LT0RHLVVKM0UtTFk3Vi0zNlVWIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIyLTA0LTIwVDE2OjE3OjU3WiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUJPQi01R1ZZLVE0M0ItS09ERy1VSjNFLUxZN1Y
  tMzZVViIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIkZXaWlfWUV0VERYNUt6ZUQtLW44QW5LcWlFUFQzODN6YWZPOW
  VFREt0QjNjc2pMa2VaV2UKICBXMjNhQlEtd01pZFVNLVZGX1VsYTFtSUEifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUNLMi1PRlNZLUNBUEot
  RVpVNS1LTzM3LUlJTkMtNkhYTCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiNkNwVFVfWlp1QWE3bENOYkE4ZUs4c2h
  EeUdsQy05YldXckwteFQybTFZNjcwZVpFVzI1NwogIHR2SnREVDFLSTN3aXotaXB0
  bjFBVHBhQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CS
  DYtUEQyNy02Tjc2LVIyNTctQlUzTS1CUUpYLVFEQlMiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJXV0xIN0hjb0Vl
  SzdhRzMtYWdMdHI2UlltWTJnYWtiekNyWm00aWppWERGbXhWVFJIamJlCiAgaUItV
  1dLOS1JVDQydW5OaHRXRmxPdXdBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQlRKLU9CNEYtQVlIRC1YQzRJLUpaTkctTUJaVS1ISTN
  HIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJWd0hYcHQxdmZKV21zNUNjazluc2dlam92WkxOa1ctcEFxalpHdkdWNW
  5lb0UtcnVyZWJDCiAgaTdYLTR3bnhxbXV4RkxIVHF5cFdJRjhBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBOB-5GVY-Q43B-KODG-UJ3E-LY7V-36UV",
            "signature":"m10FQkPJzhAR2Cg2VfPzvSUt3XyQh0yjgqggXSep
  nwz3NpDWrH6TZLNeO0Gq-moqahTzGn_ZW8aA6vuiuiqtDMy_avBf0g31nDpFyRDk6
  9D5qXBh8Br-4utT_Zxyzz3S2i63FGczDekAZTwZTQoQwTUA"}
          ],
        "PayloadDigest":"-irGyEMwNtkfLTM8Ygprqww7Lr41K_2Recre2O2H
  DP5CyC4VklJfYiDMR8822Sp5oALA-2aqQjDzJKKEt50nhA"}
      ],
    "EnvelopedConnectionDevice":[{
        "dig":"S512",
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjItMDQtMjBUMTY6MTc6NTdaIn0"},
      "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIkF1dGhlbnRpY2F0aW
  9uIjogewogICAgICAiVWRmIjogIk1DSzItT0ZTWS1DQVBKLUVaVTUtS08zNy1JSU5
  DLTZIWEwiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIjZDcFRVX1padUFhN2xDTmJBOGVLOHNoRHlHbEMtOWJXV3JMLX
  hUMm0xWTY3MGVaRVcyNTcKICB0dkp0RFQxS0kzd2l6LWlwdG4xQVRwYUEifX19LAo
  gICAgIlNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQkg2LVBEMjctNk43Ni1S
  MjU3LUJVM00tQlFKWC1RREJTIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7C
  iAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiV1dMSDdIY29FZUs3YUczLWFnTHRyNlJ
  ZbVkyZ2FrYnpDclptNGlqaVhERm14VlRSSGpiZQogIGlCLVdXSzktSVQ0MnVuTmh0
  V0ZsT3V3QSJ9fX0sCiAgICAiRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ
  0syLU9GU1ktQ0FQSi1FWlU1LUtPMzctSUlOQy02SFhMIiwKICAgICAgIlB1YmxpY1
  BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICA
  gICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICI2Q3BUVV9aWnVB
  YTdsQ05iQThlSzhzaER5R2xDLTliV1dyTC14VDJtMVk2NzBlWkVXMjU3CiAgdHZKd
  ERUMUtJM3dpei1pcHRuMUFUcGFBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBGZ-R2AS-DPME-4KOZ-KKF5-WLDO-IBZO",
            "signature":"pe4KEfz7NgyGS4nz7VxBPZNcX04Fnf5EVQXCg4AO
  Z_XDKD3egMEeg5cStZALTB-yOkk44XLobyWAbxbhyeVFif7qZAdZ0hdk-h_o-di3h
  aX-SVPdFpGHXeCeOMaEAfsCOXTb9oSvHqDNLUaRIfq0wiIA"}
          ],
        "PayloadDigest":"oa0Yms70Z_buemEpSstfNdKSVlxUy7NoHKkZv_bA
  9OX9ZJGkB3E4nNBfLG85arEixWQhkxFCwkHLvmInqkjYIQ"}
      ],
    "EnvelopedConnectionService":[{
        "dig":"S512",
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICA
  iQ3JlYXRlZCI6ICIyMDIyLTA0LTIwVDE2OjE3OjU3WiJ9"},
      "ewogICJDb25uZWN0aW9uU2VydmljZSI6IHsKICAgICJBdXRoZW50aWNhdG
  lvbiI6IHsKICAgICAgIlVkZiI6ICJNQ0syLU9GU1ktQ0FQSi1FWlU1LUtPMzctSUl
  OQy02SFhMIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1
  YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICI2Q3BUVV9aWnVBYTdsQ05iQThlSzhzaER5R2xDLTliV1dyTC
  14VDJtMVk2NzBlWkVXMjU3CiAgdHZKdERUMUtJM3dpei1pcHRuMUFUcGFBIn19fX1
  9",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBGZ-R2AS-DPME-4KOZ-KKF5-WLDO-IBZO",
            "signature":"mGzTozZ5fDt4p9-VSDGwx6b9AUo_YDR9pLwXAj1m
  oN5de75NXuZRdz_ENeTLu1AtEzyYENDaQskAho664biW8I7DuRbNbLJ_AJLXQD99b
  5kiiz1Ljavg1RAdrdfH05TDGHw7eMP5aCEir_o4oS7zjTEA"}
          ],
        "PayloadDigest":"97C6-ryQFiyRF-8NAP9pX7YvJEtcz-hexhvkHgsJ
  2GUEl7yW_-uhclWSu0F7eRrdENFRq8g-qJDXPJTmo8TyEA"}
      ],
    "PrivateKey":{
      "PrivateKeyUDF":{
        "PrivateValue":"ZAAQ-A5KD-OPXN-5E7X-ZXRU-CRYP-B2N2-G6FY-MCO
H-GAIH-72GR-EZXO-LQIM-Z5GA",
        "KeyType":"MeshProfileDevice"}},
    "ConnectUri":"mcu://maker@example.com/EBKG-ED3O-HBHK-ZQGS-EX4H-
X22S-X4"}}
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
<cmd>Alice> meshman account connect ^
    mcu://maker@example.com/EBKG-ED3O-HBHK-ZQGS-EX4H-X22S-X4 /web
</div>
~~~~

### Phase 4

The device polls the publication service until a claim message is returned.


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MBOB-5GVY-Q43B-KODG-UJ3E-LY7V-36UV
   Account = alice@example.com
   Account UDF = MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF
</div>
~~~~

### Phase 5

Having been advised that an account has published a claim to bind to it, the device
posts a connection Complete request to the specified account and completes the
connection process as before.

