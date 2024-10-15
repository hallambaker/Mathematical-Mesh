
### Phase 1

The manufacturer preconfigures the device


~~~~
<div="terminal">
<cmd>Maker> meshman device preconfig
<rsp>Device UDF: MBQK-36BF-K7RS-UDWD-PVC3-CVMR-BJCP
File: EBH3-DT6M-G2WA-EF7E-DA42-DN55-7E.medk
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
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uRGV2aWNlIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjQtMTAtMTRUMTM6MTA6NThaIn0",
        "dig":"S512"},
      "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIlNpZ25hdHVyZSI6IH
  sKICAgICAgIlVkZiI6ICJNRFY1LUVJQ0ktSk5GVi0zNUs3LUlQREctNkNWNy1OU1Y
  1IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tl
  eUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQd
  WJsaWMiOiAiQVVPMUIyR1RLNGZjSk9rUFlNN0RJa3VDT2s0SWNJbHFzTGZuQVlnQS
  1BQ0dhZmNvUFZCdQogIEJDSGYzR2JDMEx2bHBiS2cwNmliREh5QSJ9fX0sCiAgICA
  iRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQkZGLUVTUDMtVk5YWS1EWUhM
  LTVNSkktVjRLNy1WN1dOIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgI
  CAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLA
  ogICAgICAgICAgIlB1YmxpYyI6ICJMd2oxNlE3QmNraWU3ZU9jMG85NXJYbGZ6enh
  rSDFFTGVCMGxlLURJdklxemVpeHlocjZhCiAgTjRTSV94Vzh6eGwxSGVSclRKN1lh
  Uy1BIn19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ
  kZGLUVTUDMtVk5YWS1EWUhMLTVNSkktVjRLNy1WN1dOIiwKICAgICAgIlB1YmxpY1
  BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICA
  gICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJMd2oxNlE3QmNr
  aWU3ZU9jMG85NXJYbGZ6enhrSDFFTGVCMGxlLURJdklxemVpeHlocjZhCiAgTjRTS
  V94Vzh6eGwxSGVSclRKN1lhUy1BIn19fX19",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MD66-B7Q7-HWEB-UAF6-PWNM-YVBH-HXE7",
            "signature":"T5q8Ygyj3aM5tDzUmjoFMAVdGasi0PF1SZlgFYCl
  3kCT5_NZrd5iuGcJetwaq0bINEJHDjUppQuAdbpe8eZPlJBtTo8EBksurd04sqf1U
  NIokTq5HA-eXh45bjPkOGjwZmBBO46LlyQDG_kq-6roUw0A"}
          ],
        "PayloadDigest":"CQupHrY2ASmhF8QOcXCnjid4nC6wlVlUk9cxmIUc
  MGC1_YLhJwc7wpE-EfoDCcmkTtRCPmwq1tmdX88VClLkSw"}
      ],
    "EnvelopedConnectionService":[{
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJDb25uZWN0aW
  9uU2VydmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICA
  iQ3JlYXRlZCI6ICIyMDI0LTEwLTE0VDEzOjEwOjU4WiJ9",
        "dig":"S512"},
      "ewogICJDb25uZWN0aW9uU2VydmljZSI6IHsKICAgICJBdXRoZW50aWNhdG
  lvbiI6IHsKICAgICAgIlVkZiI6ICJNQkZGLUVTUDMtVk5YWS1EWUhMLTVNSkktVjR
  LNy1WN1dOIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1
  YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJMd2oxNlE3QmNraWU3ZU9jMG85NXJYbGZ6enhrSDFFTGVCMG
  xlLURJdklxemVpeHlocjZhCiAgTjRTSV94Vzh6eGwxSGVSclRKN1lhUy1BIn19fX1
  9",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MD66-B7Q7-HWEB-UAF6-PWNM-YVBH-HXE7",
            "signature":"4FkfmdMX6sWMQ5zskF7V_1UsoBTBKVVQtYigF41m
  MGOx1_yTQtpDs1lnqxmBt6yAtjfUvv1NsG2AdYx425rJ5-lryqyud6m-MNoTCUeWW
  wuO0jGMpaw2PyjFUFh62_k5fGDzZVgqx-larLbwVf6vFQsA"}
          ],
        "PayloadDigest":"z4aP8rSa_WxiufLZcZmhBbJd-3OCz70GX4gIkH0y
  U4LCO8QdoX-4iAbwfwylksQDTtNbKmVfxQam4MCT-2oKZw"}
      ],
    "PrivateKey":{
      "PrivateKeyUDF":{
        "PrivateValue":"ZAAQ-AUKH-YPXV-5NTI-ZVIK-4Q2D-EFAP-UR7Y-5XX
N-EDXE-HX3O-LYFS-BJOU-CMQE",
        "KeyType":"MeshProfileDevice",
        "RootSignAlgorithms":["ED448"
          ]}},
    "ConnectUri":"mcd://maker@example.com/EBH3-DT6M-G2WA-EF7E-DA42-
DN55-7E",
    "EnvelopedProfileDevice":[{
        "EnvelopeId":"MBQK-36BF-K7RS-UDWD-PVC3-CVMR-BJCP",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQlFLLTM2QkYtSz
  dSUy1VRFdELVBWQzMtQ1ZNUi1CSkNQIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZURldmljZSIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0IiwKICAi
  Q3JlYXRlZCI6ICIyMDI0LTEwLTE0VDEzOjEwOjU4WiJ9",
        "dig":"S512"},
      "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIkVuY3J5cHRpb24iOiB7Ci
  AgICAgICJVZGYiOiAiTUJGRi1FU1AzLVZOWFktRFlITC01TUpJLVY0SzctVjdXTiI
  sCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlF
  Q0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiTHdqMTZRN0Jja2llN2VPYzBvOTVyWGxmenp4a0gxRUxlQjBsZS1ESXZJcX
  plaXh5aHI2YQogIE40U0lfeFc4enhsMUhlUnJUSjdZYVMtQSJ9fX0sCiAgICAiU2l
  nbmF0dXJlIjogewogICAgICAiVWRmIjogIk1EVjUtRUlDSS1KTkZWLTM1SzctSVBE
  Ry02Q1Y3LU5TVjUiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogIC
  AgICAgICAgIlB1YmxpYyI6ICJBVU8xQjJHVEs0ZmNKT2tQWU03RElrdUNPazRJY0l
  scXNMZm5BWWdBLUFDR2FmY29QVkJ1CiAgQkNIZjNHYkMwTHZscGJLZzA2aWJESHlB
  In19fSwKICAgICJBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQVZHL
  VlXWVYtMlVXNy1MU1QzLUFQQkctUkw3SC1ONTMzIiwKICAgICAgIlB1YmxpY1Bhcm
  FtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICA
  iY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJyRlZGUi1jTDZjdWNU
  U3JmRm4xNDZYVE9kMWgzSkdBM0hrQ0VlYkNzaUEzT3dWQXBkN2ZsCiAgZ0Z4Zlh0d
  lkzVXRpNmlRd1RTdmVFWmtBIn19fSwKICAgICJSb290VWRmcyI6IFsiWU5lVGVBYk
  l4NVdSdEN4Q3llbnBqYWJKVlJuOERUbGF1SFBUZFFUYnRJOEFHblY1bk8KICBWM1l
  PWENlRFlRZTk5VnFIcWZwYi10MFZxSjI5blZKRW1yUEpNIl19fQ",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MDLZ-G6AG-ZDDZ-LENU-FRBM-T2PJ-RWTM",
            "SignatureKey":{
              "PublicKeyECDH":{
                "crv":"Ed448",
                "Public":"WPX0CBEOzgJWHVJqiyTAr4MrieFJQYzdutZML5-
  MnHsfF7KfRmGxsUR9eppBIKTFhzLaRhd06XmA"}},
            "signature":"s1AVL-omThJqK3LTFXtg58xvRBZoeansc39u4rqT
  iKRHKrCQx-11PG9b0Vq-VC_MRWxbCwZenawAo4fBnNnpNvtbNGUaALlFVvLK5nPZV
  O6nY6gA_i3ID9ZrUTxYJz0lbj-ZTIt6NZOGxTJX4yxJiC8A"}
          ],
        "PayloadDigest":"OrZNsRzLz7olETFljSpKbdG1bNjj5MBr-ireuPK6
  Sn9-ARWs4E3Xk2_HvrHA7cySavkX6anRBSGzQ5uYty0_Ow"}
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
    mcd://maker@example.com/EBH3-DT6M-G2WA-EF7E-DA42-DN55-7E /web
</div>
~~~~

### Phase 4

The device polls the publication service until a claim message is returned.


~~~~
<div="terminal">
<cmd>Alice4> meshman device complete
<rsp>   Device UDF = MBQK-36BF-K7RS-UDWD-PVC3-CVMR-BJCP
   Account = alice@example.com
   Account UDF = MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
</div>
~~~~

### Phase 5

Having been advised that an account has published a claim to bind to it, the device
posts a connection Complete request to the specified account and completes the
connection process as before.

