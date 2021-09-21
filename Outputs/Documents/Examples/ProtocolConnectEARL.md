
### Phase 1

The manufacturer preconfigures the device


~~~~
<div="terminal">
<cmd>Maker> device preconfig
<rsp>Device Udf: MDQY-5665-3SQR-ZT5J-677B-AJYI-TJBX
File: EAUY-D4X7-7UX4-G2GJ-UZCT-R4F3-GE.medk
</div>
~~~~

This results in the creation of a primary secret which is used to compute a ProfileDevice
and corresponding connection records signed by the manufacturer's administrator key.

The data is combined to create a DevicePreconfiguration record that is provisioned to
the firmware of the device being preconfigured.

~~~~
{
  "DevicePreconfiguration":{
    "EnvelopedProfileDevice":[{
        "EnvelopeId":"MDQY-5665-3SQR-ZT5J-677B-AJYI-TJBX",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRFFZLTU2NjUtM1
  NRUi1aVDVKLTY3N0ItQUpZSS1USkJYIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTA5LTIxVDAwOjU4OjU4WiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTURRWS01NjY1LTNTUVItWlQ1Si02NzdCLUFKWUk
  tVEpCWCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIk84VHBveWxZeFRWVE5lYzQycnBqSTFLVDlNMUJJTUp0OU1VMj
  RvWWw4SUZOeVg4ajUyYUMKICBTbElOem9WaDdBWkoyWjJ0T0FaYzNkQ0EifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUI3Vi02Nk5OLVRQRVUt
  Uk1QRy01QlFKLVBLWlgtMklWNSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiQWwzejdUc0tJRU5waGQtRmpMTDlhdW4
  3eC1aTVJHaXNqSGtkVVk1U1Z0dWdYTjB5RkwzNAogIC11Qk5IZVdJaDhYbVJFY0pQ
  dkxkYXNtQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1EQ
  lMtQzdDWi1UWkZNLUNCSU0tR1lERy02WEtQLU1MTkoiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJCZTliR2J6OU92
  ZVRNTnRMQTViWU9uNUhNVl8zdFBIVGh5LWFIYkJGaHZ5X203THpCaS1XCiAgNzRMY
  ll0VFVscE5zVDQ0VUphcEZjbFVBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNRDZSLU83UVEtNEFHQy1CS1FILTZQU00tNDRGNC1YUlB
  DIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJmVEsyZDEtckhqd2doTkFqalRLV01fZzR1OEFMeTIyWHZjNFc0NHNraD
  IwVHdvY3V5NmllCiAgQVlaa2NONDROX0lkMl93QnE3OHBDTi1BIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDQY-5665-3SQR-ZT5J-677B-AJYI-TJBX",
            "signature":"nixaP5x40tUgDBA6f_izLFuX1biRd4Zq8GeOq7PM
  D2rF8Mbc2LWu5E6to_JUNVTCPbCSDH7TwP0AYxMLXSLv8hUuu59ywDzykDTLfsdR0
  DNW3FFmNCsMQOLrlf1RZVBmtjy6OjMd8pJcbOZ4cCoQOj8A"}
          ],
        "PayloadDigest":"12LW0qV8Fd7MN2sg0q66JLzAXp1sYpnLqg9G2h3a
  -IwlOomw1G4qAemoatIi5cclKQ49-UGW2vRl4N2vUTIXsg"}
      ],
    "EnvelopedConnectionDevice":[{
        "dig":"S512",
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjEtMDktMjFUMDA6NTg6NThaIn0"},
      "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIkF1dGhlbnRpY2F0aW
  9uIjogewogICAgICAiVWRmIjogIk1CN1YtNjZOTi1UUEVVLVJNUEctNUJRSi1QS1p
  YLTJJVjUiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIkFsM3o3VHNLSUVOcGhkLUZqTEw5YXVuN3gtWk1SR2lzakhrZF
  VZNVNWdHVnWE4weUZMMzQKICAtdUJOSGVXSWg4WG1SRWNKUHZMZGFzbUEifX19LAo
  gICAgIlNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNREJTLUM3Q1otVFpGTS1D
  QklNLUdZREctNlhLUC1NTE5KIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7C
  iAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiQmU5YkdiejlPdmVUTU50TEE1YllPbjV
  ITVZfM3RQSFRoeS1hSGJCRmh2eV9tN0x6QmktVwogIDc0TGJZdFRVbHBOc1Q0NFVK
  YXBGY2xVQSJ9fX0sCiAgICAiRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ
  jdWLTY2Tk4tVFBFVS1STVBHLTVCUUotUEtaWC0ySVY1IiwKICAgICAgIlB1YmxpY1
  BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICA
  gICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJBbDN6N1RzS0lF
  TnBoZC1GakxMOWF1bjd4LVpNUkdpc2pIa2RVWTVTVnR1Z1hOMHlGTDM0CiAgLXVCT
  khlV0loOFhtUkVjSlB2TGRhc21BIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDNK-3NPG-WYAC-YOTN-I76Y-BSMA-CC6C",
            "signature":"68UpOiTpZoPHledaOfqH2-G7bHwylPFHj_vk6wXI
  KVO2AX0TlEjDGVz3PpnWT1_3QJBE0GHQheyAjxS6Oxn0LGuKflM1hyh4_1FTNR-IG
  U_SXC6Y3mukLbbnkqmqKfurIhr-1Rg4qKWujUjgiOHB1hIA"}
          ],
        "PayloadDigest":"N1IqNRsMW1aprb5nhiG85sbh8zZb94YHqNQd825-
  6B2mada6AZsaRMRwbM88lLoy9JgYDaVJS-ZxnMzhGjmI_g"}
      ],
    "EnvelopedConnectionService":[{
        "dig":"S512",
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICA
  iQ3JlYXRlZCI6ICIyMDIxLTA5LTIxVDAwOjU4OjU4WiJ9"},
      "ewogICJDb25uZWN0aW9uU2VydmljZSI6IHsKICAgICJBdXRoZW50aWNhdG
  lvbiI6IHsKICAgICAgIlVkZiI6ICJNQjdWLTY2Tk4tVFBFVS1STVBHLTVCUUotUEt
  aWC0ySVY1IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1
  YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJBbDN6N1RzS0lFTnBoZC1GakxMOWF1bjd4LVpNUkdpc2pIa2
  RVWTVTVnR1Z1hOMHlGTDM0CiAgLXVCTkhlV0loOFhtUkVjSlB2TGRhc21BIn19fX1
  9",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDNK-3NPG-WYAC-YOTN-I76Y-BSMA-CC6C",
            "signature":"ghxvI4fomaB6kWprF-tYpvP_Q-Ef7nplTTJ3oGsY
  xdMmA3n7QXhReJ_GOHF_fCUEf9X5Ck2bGXuAsdNmhbcnsUomNjWN1mGGFfsI29lAB
  zqVNKbNQDwMQijJ9hXH7dACDeykLP5XXJd_MXz4frzDbD8A"}
          ],
        "PayloadDigest":"py76Q3fRllDXIrNZn7dvyHAfb8njcYBOPGI_BKbh
  cFoHSOBW3Dm1rQ0dKV0IWjmEBJQgOQcG6F7d9OGfkaWlWg"}
      ],
    "PrivateKey":{
      "PrivateKeyUDF":{
        "PrivateValue":"ZAAQ-AC6G-YM2G-QD3E-F2K5-EPJJ-2URD-FXHT-RC2
H-UXEZ-MG2K-QTCH-HGS3-EJSW",
        "KeyType":"MeshProfileDevice"}},
    "ConnectUri":"mcu://maker@example.com/EAUY-D4X7-7UX4-G2GJ-UZCT-
R4F3-GE"}}
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
    mcu://maker@example.com/EAUY-D4X7-7UX4-G2GJ-UZCT-R4F3-GE /web
</div>
~~~~

### Phase 4

The device polls the publication service until a claim message is returned.


~~~~
<div="terminal">
<cmd>Alice4> device complete
<rsp>   Device UDF = MDQY-5665-3SQR-ZT5J-677B-AJYI-TJBX
   Account = alice@example.com
   Account UDF = MCST-2JUP-UNOG-O4A3-Q6KS-O2V5-HSQL
</div>
~~~~

### Phase 5

Having been advised that an account has published a claim to bind to it, the device
posts a connection Complete request to the specified account and completes the
connection process as before.

