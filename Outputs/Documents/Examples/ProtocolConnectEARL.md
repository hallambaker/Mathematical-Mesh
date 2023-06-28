
### Phase 1

The manufacturer preconfigures the device


~~~~
<div="terminal">
<cmd>Maker> meshman device preconfig
<rsp>Device UDF: MBAI-IMKY-GI2T-D472-4VP5-SKRF-ZXYW
File: ECHI-CYLR-Y22Q-6OME-OAWV-WIQD-YM.medk
</div>
~~~~

This results in the creation of a primary secret which is used to compute a ProfileDevice
and corresponding connection records signed by the manufacturer's administrator key.

The data is combined to create a DevicePreconfiguration record that is provisioned to
the firmware of the device being preconfigured.

~~~~
{
  "DevicePreconfigurationPrivate":{
    "EnvelopedConnectionDevice":[{
        "dig":"S512",
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjMtMDYtMjhUMTc6MDA6NTBaIn0"},
      "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIlNpZ25hdHVyZSI6IH
  sKICAgICAgIlVkZiI6ICJNQ1JQLTdPUVAtTFpFRy1LREhULVdUTlEtSlM0QS1QR0Z
  SIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQd
  WJsaWMiOiAiVjFQdS1FQTE5Z1ZUOG5ibHMyeWgweUNmdUdENVRvaUhHeWY4czBsdj
  BBSVdocUdENzhvVAogIHBGRTIzUk5TRVdWczQtWFgtbnB3ekRFQSJ9fX0sCiAgICA
  iRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNREY0LUNNQ1EtQktRWC0yUDZQ
  LVAySzItMjdVRC03QUdSIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgI
  CAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLA
  ogICAgICAgICAgIlB1YmxpYyI6ICJGOEI0ZW9YSXZ6X0txSGplckZybkRqbkdjR3J
  jVDlYOTM0MnQ2WEpNeS1VY1FXRUt6clVNCiAgRGE5STFTUUljV0xESGIyQUJtTUZK
  ZmFBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNR
  EY0LUNNQ1EtQktRWC0yUDZQLVAySzItMjdVRC03QUdSIiwKICAgICAgIlB1YmxpY1
  BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICA
  gICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJGOEI0ZW9YSXZ6
  X0txSGplckZybkRqbkdjR3JjVDlYOTM0MnQ2WEpNeS1VY1FXRUt6clVNCiAgRGE5S
  TFTUUljV0xESGIyQUJtTUZKZmFBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAN2-ANEE-HJR4-I4T2-PKID-AZ4K-ESR4",
            "signature":"CUZYibn1PlgpCZuoqiKFZT1AKXDFe3EEmuSaTKoo
  TRH86oVdEeYNcVgzzn7sjFvO0TqDUvGK6saAcRsKDjTharVnLx3TnVHRmofUN5iqK
  yu9RwwC16bdvsOV4W7j7OhHrjC41Drp-MPozT3bHfaG7j0A"}
          ],
        "PayloadDigest":"VHfvwZ_1GC1Q40Q1-Qv2rZatLkVyEiGTjZi7-JMN
  dJ7QGF7My1VdsepgSoSc1Gslm8fvFz2NlKMPA-LCxlPovg"}
      ],
    "EnvelopedConnectionService":[{
        "dig":"S512",
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICA
  iQ3JlYXRlZCI6ICIyMDIzLTA2LTI4VDE3OjAwOjUwWiJ9"},
      "ewogICJDb25uZWN0aW9uU2VydmljZSI6IHsKICAgICJBdXRoZW50aWNhdG
  lvbiI6IHsKICAgICAgIlVkZiI6ICJNREY0LUNNQ1EtQktRWC0yUDZQLVAySzItMjd
  VRC03QUdSIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1
  YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJGOEI0ZW9YSXZ6X0txSGplckZybkRqbkdjR3JjVDlYOTM0Mn
  Q2WEpNeS1VY1FXRUt6clVNCiAgRGE5STFTUUljV0xESGIyQUJtTUZKZmFBIn19fX1
  9",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAN2-ANEE-HJR4-I4T2-PKID-AZ4K-ESR4",
            "signature":"wYdQgPUrZcRuEvtZX55jZ-5aTnf5xN1TZ6pNHTD1
  0y3wlEXgKRP0KsMOLNRqZAo7eblK8NvsxVcAcQ9c8oWiqffZ6gDh1wH78XCreEeA_
  o62KkaYnN7rhcJ-4veoqc4Kz8du1xCRRjKDC0Wi7EqBfBsA"}
          ],
        "PayloadDigest":"YyVytW08cXC2UlAnQgNVkhi6_2ab5Gmy90WzFzBG
  -bDKpzRgbiK2vuaQpVlIRdZ5PYVeeO1QtGnu877s08E3Yg"}
      ],
    "PrivateKey":{
      "PrivateKeyUDF":{
        "PrivateValue":"ZAAQ-BIPI-QZV3-UXRZ-TRIO-S5XC-GEOJ-GELH-TXM
6-CBIN-QKF3-AWWC-HTOO-DJOG",
        "KeyType":"MeshProfileDevice"}},
    "ConnectUri":"mcu://maker@example.com/ECHI-CYLR-Y22Q-6OME-OAWV-
WIQD-YM",
    "EnvelopedProfileDevice":[{
        "EnvelopeId":"MBAI-IMKY-GI2T-D472-4VP5-SKRF-ZXYW",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQkFJLUlNS1ktR0
  kyVC1ENDcyLTRWUDUtU0tSRi1aWFlXIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIzLTA2LTI4VDE3OjAwOjUwWiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIkVuY3J5cHRpb24iOiB7Ci
  AgICAgICJVZGYiOiAiTURGNC1DTUNRLUJLUVgtMlA2UC1QMksyLTI3VUQtN0FHUiI
  sCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlF
  Q0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiRjhCNGVvWEl2el9LcUhqZXJGcm5Eam5HY0dyY1Q5WDkzNDJ0NlhKTXktVW
  NRV0VLenJVTQogIERhOUkxU1FJY1dMREhiMkFCbU1GSmZhQSJ9fX0sCiAgICAiU2l
  nbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DUlAtN09RUC1MWkVHLUtESFQtV1RO
  US1KUzRBLVBHRlIiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogIC
  AgICAgICAgIlB1YmxpYyI6ICJWMVB1LUVBMTlnVlQ4bmJsczJ5aDB5Q2Z1R0Q1VG9
  pSEd5ZjhzMGx2MEFJV2hxR0Q3OG9UCiAgcEZFMjNSTlNFV1ZzNC1YWC1ucHd6REVB
  In19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQjNUL
  VlNTVYtV0FCVi1KM1lQLU9ZTEItWUFBSS1RRkQyIiwKICAgICAgIlB1YmxpY1Bhcm
  FtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICA
  iY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJBQ2ptd2NMUVVlOGk1
  UnVZUEZPSFhCTHlYRkN6RVcyb0lkUHh5Wk9mYlN2SEI0WUlEOUhqCiAgMHRsM0lad
  lJQdjlUc25Pc2hpZWRlMDJBIn19fSwKICAgICJQcm9maWxlU2lnbmF0dXJlIjogew
  ogICAgICAiVWRmIjogIk1CQUktSU1LWS1HSTJULUQ0NzItNFZQNS1TS1JGLVpYWVc
  iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5
  RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJkdTBFenhUdEZWa3BqWnphTi13LXBkRlFZMUpPWDRrQmlyX0pVUEdoQ3
  M3SzlELUpqTmV1CiAgNjdtMDcxR3AxSG9yZF9LeUJWSW8wWmtBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBAI-IMKY-GI2T-D472-4VP5-SKRF-ZXYW",
            "signature":"7ECNMccaM24RWFOoJJVU55zb1XfgLFisbc15VIVd
  B_k6xeVGmpchZtgVrdeDjHgpesIqgJmbB7yAdPoIEusSu8pgY_Oc6BjMARJYAS9YW
  bfE4UX2HBlWViyY7I2RUM0_VvcOgt6Fc3XMXCtvbsAG4gwA"}
          ],
        "PayloadDigest":"xalDY6zOXjHmqlXWGKty0QkSsPfDQ5tuDHY-Tm8R
  e7UuxEfjvZnpTBtes9Etx86yn55D24AGSF199ejrRu8o5A"}
      ]}}
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
    mcu://maker@example.com/ECHI-CYLR-Y22Q-6OME-OAWV-WIQD-YM /web
</div>
~~~~

### Phase 4

The device polls the publication service until a claim message is returned.


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MBAI-IMKY-GI2T-D472-4VP5-SKRF-ZXYW
   Account = alice@example.com
   Account UDF = MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
</div>
~~~~

### Phase 5

Having been advised that an account has published a claim to bind to it, the device
posts a connection Complete request to the specified account and completes the
connection process as before.

