
### Phase 1

The manufacturer preconfigures the device


~~~~
<div="terminal">
<cmd>Maker> meshman device preconfig
<rsp>Device UDF: MDIY-2ZQN-NON7-466E-LEWP-AO2Q-XANK
File: EDIW-AY5A-RCNT-KNG3-3MBV-WVLT-24.medk
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
        "EnvelopeId":"MDIY-2ZQN-NON7-466E-LEWP-AO2Q-XANK",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNRElZLTJaUU4tTk
  9ONy00NjZFLUxFV1AtQU8yUS1YQU5LIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDIxLTEyLTE4VDAxOjU3OjI5WiJ9"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIlByb2ZpbGVTaWduYXR1cm
  UiOiB7CiAgICAgICJVZGYiOiAiTURJWS0yWlFOLU5PTjctNDY2RS1MRVdQLUFPMlE
  tWEFOSyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJs
  aWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIlQwMkhXS1BFSUhIWE5wY0wwbnBFM2dHOW1KODZrSTVzS2czQz
  JSeEdpYV93NHFhUG9kZFkKICBtSm5xaWl2VTcyQkJBMy1peHZHWk1aRUEifX19LAo
  gICAgIkVuY3J5cHRpb24iOiB7CiAgICAgICJVZGYiOiAiTUM0Vy01Qk5NLVRUR1It
  RTJHVy1EUlY0LUpIQ0ktR0VMSCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAieVl6LVpfODVQOThFam9yVVBMUU9XOFR
  Lb3FCWTlKVHBmMW9NOHVkc3BseFBLM1JJc2t1eQogIGpuTHIzNWxRZ1hlYTlRVnJa
  NWdzVXNJQSJ9fX0sCiAgICAiU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1BS
  VEtVVU0Ri1XTzRDLTNHSk4tTUtHTi0zREVELVpWRUQiLAogICAgICAiUHVibGljUG
  FyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ2ek9oLV96RnB0
  VGtPck9MRF9wU1RvS056TV9TQmZwSXFfUUsxV2N1RXFLUXJ6TVpjT1NiCiAgSjNFc
  2FVaHItNVNCN25QSENjRkZLZkNBIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IH
  sKICAgICAgIlVkZiI6ICJNQkVMLUVURVctQ0xBUS1TWEpCLVNPNlAtS0Y3Ny1YMlh
  TIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1Y
  mxpYyI6ICJBLWV1LW1LZnFDck5yUWxyV3Y4OVpPaHkxSS1NY2YxTzVhSlRZMnVldX
  BCOUtCVTR6VFpMCiAgdTN0R2EtN3BOVk9iLWFhXzh4eUUyVk9BIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDIY-2ZQN-NON7-466E-LEWP-AO2Q-XANK",
            "signature":"sLqbARwGFcj9SpAhRfiHTc9lAbl816xOTWWkA8Td
  -eirI7fbzhToS8geshf05lrgemtrpUJk0f0A04MG7dNItoTaoqzdnUG5N2tSAmyXP
  jBjTUVGHqEorysOZxbKbGkzHu80KKraAm7kyl8tfG33xiQA"}
          ],
        "PayloadDigest":"Z0J93r4bTd3sfrEqtl51QEUYzg5woAMwbThssILF
  1yxVOThR5WfFsoWsUoqGdsB0ssQDDxRskoD15vNdbsxF_g"}
      ],
    "EnvelopedConnectionDevice":[{
        "dig":"S512",
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjEtMTItMThUMDE6NTc6MjlaIn0"},
      "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIkF1dGhlbnRpY2F0aW
  9uIjogewogICAgICAiVWRmIjogIk1DNFctNUJOTS1UVEdSLUUyR1ctRFJWNC1KSEN
  JLUdFTEgiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogInlZei1aXzg1UDk4RWpvclVQTFFPVzhUS29xQlk5SlRwZjFvTT
  h1ZHNwbHhQSzNSSXNrdXkKICBqbkxyMzVsUWdYZWE5UVZyWjVnc1VzSUEifX19LAo
  gICAgIlNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQUlRLVVVNEYtV080Qy0z
  R0pOLU1LR04tM0RFRC1aVkVEIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7C
  iAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkND
  Q4IiwKICAgICAgICAgICJQdWJsaWMiOiAidnpPaC1fekZwdFRrT3JPTERfcFNUb0t
  Oek1fU0JmcElxX1FLMVdjdUVxS1Fyek1aY09TYgogIEozRXNhVWhyLTVTQjduUEhD
  Y0ZGS2ZDQSJ9fX0sCiAgICAiRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ
  zRXLTVCTk0tVFRHUi1FMkdXLURSVjQtSkhDSS1HRUxIIiwKICAgICAgIlB1YmxpY1
  BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICA
  gICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ5WXotWl84NVA5
  OEVqb3JVUExRT1c4VEtvcUJZOUpUcGYxb004dWRzcGx4UEszUklza3V5CiAgam5Mc
  jM1bFFnWGVhOVFWclo1Z3NVc0lBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCY7-DK5H-BOJE-FVXA-KY2P-5OAJ-HRE5",
            "signature":"mGcTcj-KJ1Bg1YhHMWFWnmZiXTcPmh5ElvyMx11P
  _MG2EcTzD3MWqyXAVkKd4RDSXlIYg5aYn0YAVmjw8NQ_MW2X0GFsD6oOHa65NlVHy
  h4ycsvtwRPIkx2NmeYbG6AaONNCqDbPIK2K-3whLVhw5y4A"}
          ],
        "PayloadDigest":"NLeceSE3lP_uiYlTAGq6kCvhibR46__CjH6o9zNs
  _Pjj0_anT87pVF9fbiNLAeOyAvltZ_NVlUm6scGabJXFJA"}
      ],
    "EnvelopedConnectionService":[{
        "dig":"S512",
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICA
  iQ3JlYXRlZCI6ICIyMDIxLTEyLTE4VDAxOjU3OjI5WiJ9"},
      "ewogICJDb25uZWN0aW9uU2VydmljZSI6IHsKICAgICJBdXRoZW50aWNhdG
  lvbiI6IHsKICAgICAgIlVkZiI6ICJNQzRXLTVCTk0tVFRHUi1FMkdXLURSVjQtSkh
  DSS1HRUxIIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1
  YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJ5WXotWl84NVA5OEVqb3JVUExRT1c4VEtvcUJZOUpUcGYxb0
  04dWRzcGx4UEszUklza3V5CiAgam5McjM1bFFnWGVhOVFWclo1Z3NVc0lBIn19fX1
  9",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCY7-DK5H-BOJE-FVXA-KY2P-5OAJ-HRE5",
            "signature":"25wF6bMkbdOIbiCahj5onN-sSwY3JqYBSacAqw23
  8chBL7KIM77JCe6WrRvcGja2KuKKElzzFciAIlBw5p1CVAY1tSRREW9inZeDwNajY
  wV3y42oHqe86t9SBbf9ALFHtAw_X_ndRnXQ0vB-YDgfaCYA"}
          ],
        "PayloadDigest":"YLsPGivNM-Pz3dfpKYM2ma9dllazHmb6Cr3OiCUk
  8CxKa4Dm4wFZLVBJfYQP9r42dhdEEQ0Ytmr58c3Plo2dAA"}
      ],
    "PrivateKey":{
      "PrivateKeyUDF":{
        "PrivateValue":"ZAAQ-BLMH-3KFZ-4B6R-LO35-OCA7-C77A-QERK-R2M
O-DGC3-2E3N-VHLK-3H6F-EYV2",
        "KeyType":"MeshProfileDevice"}},
    "ConnectUri":"mcu://maker@example.com/EDIW-AY5A-RCNT-KNG3-3MBV-
WVLT-24"}}
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
    mcu://maker@example.com/EDIW-AY5A-RCNT-KNG3-3MBV-WVLT-24 /web
</div>
~~~~

### Phase 4

The device polls the publication service until a claim message is returned.


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MDIY-2ZQN-NON7-466E-LEWP-AO2Q-XANK
   Account = alice@example.com
   Account UDF = MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N
</div>
~~~~

### Phase 5

Having been advised that an account has published a claim to bind to it, the device
posts a connection Complete request to the specified account and completes the
connection process as before.

