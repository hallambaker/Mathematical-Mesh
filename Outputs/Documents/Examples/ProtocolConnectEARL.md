
### Phase 1

The manufacturer preconfigures the device


~~~~
<div="terminal">
<cmd>Maker> meshman device preconfig
<rsp>Device UDF: MBM6-ONBJ-ESIY-SQUC-UNYK-2KWU-KELY
File: ED6U-5FAQ-662T-BTCW-7YFY-W545-EY.medk
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
        "EnvelopeId":"MBM6-ONBJ-ESIY-SQUC-UNYK-2KWU-KELY",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQk02LU9OQkotRV
  NJWS1TUVVDLVVOWUstMktXVS1LRUxZIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTEyLTIxVDEzOjI4OjM2WiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTUJNNi1PTkJKLUVTSVktU1FVQy1VTllLLTJLV1U
  tS0VMWSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIlB0VHVyeUgxM2Z4UklWcFZ3QlhVSHNYbzB2NmU0VGp2LU1GNn
  RyV1p6bDgtV1F0aE5adnkKICBzY1hqcTR1N1Z6eGFFeXV6UXFjcF9aZUEifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUE2VS1IWFpFLTJXVVgt
  S0I3TC00RjZNLU1EQ1YtVzdSRiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAidzBTazVLNml2QklCb1NaQUJzRm1PbnN
  CcVdZcGhkZi13d0tpSEpfamNPSFRyZkpaMEx2SQogIFF4aDlOc0NOSlFoVDJENlVH
  MXhsT1JzQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DW
  UotVFhKMy1GMlY1LU83RU0tU0hNWi01VkJFLUlKRVYiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJZZUNuM054dGZf
  UlMtM3ZuVDNFb0FRNjFOQk1zTW5hbGN6NTFBNTJUMzA1WGQySTlaRkUzCiAgeUhKe
  FlwQW5PQ3VleXpoa3RqeklyMDRBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNRFk3LUs3TUMtR1lYWS1IUDNTLU1GMjctVEtFTC1NUzV
  UIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJLd05VTmhCMUx4d0pxRjd6QjA1XzdYOGxZMTJuSmVIOEZmWjMtY2ZDVE
  5XSUtDZFNOM2ttCiAgQ1c5R2FvTU5uV2lSanFURi00WnY3bTZBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBM6-ONBJ-ESIY-SQUC-UNYK-2KWU-KELY",
            "signature":"hiXZe6UYVAHu7Pm6w1lVRxPLPNhW3TMn3TFn2z2a
  dCO9eQhRRg3jD94P7a0qC83xcPr-ivFs6tOANqDBLNId35HKTam53QohSZr5qijDc
  sp8Q2ypzV6ft7kUe4pP8KCj1eEURmofYLZrTX_jyVkSggQA"}
          ],
        "PayloadDigest":"5ltNcTaO6UfLdNpszzAFcYQA2UPFuCAvyAg7wHc3
  hOZH-3zer3Nvn-eVkBeYhU1gkojN8MUHP1w1Phl26Dc6NA"}
      ],
    "EnvelopedConnectionDevice":[{
        "dig":"S512",
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjEtMTItMjFUMTM6Mjg6MzZaIn0"},
      "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIkF1dGhlbnRpY2F0aW
  9uIjogewogICAgICAiVWRmIjogIk1BNlUtSFhaRS0yV1VYLUtCN0wtNEY2TS1NREN
  WLVc3UkYiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIncwU2s1SzZpdkJJQm9TWkFCc0ZtT25zQnFXWXBoZGYtd3dLaU
  hKX2pjT0hUcmZKWjBMdkkKICBReGg5TnNDTkpRaFQyRDZVRzF4bE9Sc0EifX19LAo
  gICAgIlNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQ1lKLVRYSjMtRjJWNS1P
  N0VNLVNITVotNVZCRS1JSkVWIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7C
  iAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAiWWVDbjNOeHRmX1JTLTN2blQzRW9BUTY
  xTkJNc01uYWxjejUxQTUyVDMwNVhkMkk5WkZFMwogIHlISnhZcEFuT0N1ZXl6aGt0
  anpJcjA0QSJ9fX0sCiAgICAiRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ
  TZVLUhYWkUtMldVWC1LQjdMLTRGNk0tTURDVi1XN1JGIiwKICAgICAgIlB1YmxpY1
  BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICA
  gICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ3MFNrNUs2aXZC
  SUJvU1pBQnNGbU9uc0JxV1lwaGRmLXd3S2lISl9qY09IVHJmSlowTHZJCiAgUXhoO
  U5zQ05KUWhUMkQ2VUcxeGxPUnNBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MB4K-XYTD-OKYW-GJLI-K7C4-T6XK-UQVL",
            "signature":"xBhw2YV5OQjSR3RVDOTgOIhMlo1Em7MyHRCCV4x-
  YfnV9lqw9LQnk3LASZ8nbTzp2Z3g-ts6UFOAdSCWrrwPTNoCDEXKtlckrHUmJVB8x
  qTWUHroeEh3XXnTJuJ5K2vOgQ6KIrhI4j9uWp0zx3lhYRkA"}
          ],
        "PayloadDigest":"kemYaGqDLoZjBX5fvhcQO1eT8HbsHlGFDHEIv0zh
  gZAN_TaPNgHuNxWJNEmHNsSFA6WBKGpApoduoL4y9AaE9w"}
      ],
    "EnvelopedConnectionService":[{
        "dig":"S512",
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICA
  iQ3JlYXRlZCI6ICIyMDIxLTEyLTIxVDEzOjI4OjM2WiJ9"},
      "ewogICJDb25uZWN0aW9uU2VydmljZSI6IHsKICAgICJBdXRoZW50aWNhdG
  lvbiI6IHsKICAgICAgIlVkZiI6ICJNQTZVLUhYWkUtMldVWC1LQjdMLTRGNk0tTUR
  DVi1XN1JGIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1
  YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJ3MFNrNUs2aXZCSUJvU1pBQnNGbU9uc0JxV1lwaGRmLXd3S2
  lISl9qY09IVHJmSlowTHZJCiAgUXhoOU5zQ05KUWhUMkQ2VUcxeGxPUnNBIn19fX1
  9",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MB4K-XYTD-OKYW-GJLI-K7C4-T6XK-UQVL",
            "signature":"LEhJiz2kxTi2GmsIgxS4jaJCHW6zIqs9ThaBKk-z
  u67qlHi7KZQ6MHA3MMYLYrsYQGqueUrXqYwATRY9mxl3J7C9T51hVHzhjUHYjHbS2
  wIJ3E1mJU0doTIp3Kvr0Vnt3T6yz5Jw_RceQ6osy-2-6ysA"}
          ],
        "PayloadDigest":"k1zy1q3ss1TtQMfddHYQdc8R7g44UdrGJSXdimOX
  Gvd8EZIFfehC31aWfrNge2W1L9Y_9lDCBzya-zUdVe44cQ"}
      ],
    "PrivateKey":{
      "PrivateKeyUDF":{
        "PrivateValue":"ZAAQ-AINB-ITQZ-VITX-5NXM-PSM7-5562-OWF4-37S
X-WOJR-VSS5-RFZ3-GODB-63CF",
        "KeyType":"MeshProfileDevice"}},
    "ConnectUri":"mcu://maker@example.com/ED6U-5FAQ-662T-BTCW-7YFY-
W545-EY"}}
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
    mcu://maker@example.com/ED6U-5FAQ-662T-BTCW-7YFY-W545-EY /web
</div>
~~~~

### Phase 4

The device polls the publication service until a claim message is returned.


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MBM6-ONBJ-ESIY-SQUC-UNYK-2KWU-KELY
   Account = alice@example.com
   Account UDF = MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
</div>
~~~~

### Phase 5

Having been advised that an account has published a claim to bind to it, the device
posts a connection Complete request to the specified account and completes the
connection process as before.

