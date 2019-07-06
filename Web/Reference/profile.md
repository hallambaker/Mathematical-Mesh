

# mesh

````
mesh    Commands for creating and managing a personal Mesh
    create   Create new personal profile
    escrow   Create a set of key escrow shares
    export   Export the specified profile data to the specified file
    get   Describe the specified profile
    import   Import the specified profile data to the specified file
    list   List all profiles on the local machine
    recover   Recover escrowed profile
````

# mesh create

````
create   Create new personal profile
       New account
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /new   Force creation of new device profile
    /dudf   Device profile fingerprint
    /did   Device identifier
    /dd   Device description
    /alg   List of algorithm specifiers
````

The `profile create` command creates a new Mesh master profile and 
(optionally) registers it with a Mesh service.

By default, the default device profile of the current account is registered as an
administrator device of the newly created profile. If no default device exists, a 
new device profile is created. The `/new` option may be used to force a new device
profile to be created.

The `/did` and `/dd` options specify an identifier and description for the device if
a new profile is created. Otherwise, platform defaults are used.

Cryptographic algorithms to be used for the signature and encryption algorithms 
may be specified using the `/alg` option.


````
>mesh create
Device Profile UDF=MCCE-E7DI-EVQ2-QOV3-TXT2-BF5W-F4EP
Personal Profile UDF=MBBK-T2SZ-MQNV-3UH3-XLQR-Y2QR-IF6S
````

Specifying the /json option returns a result of type ResultMasterCreate:

````
>mesh create /json
{
  "ResultMasterCreate": {
    "Success": true,
    "DeviceUDF": "MCCE-E7DI-EVQ2-QOV3-TXT2-BF5W-F4EP",
    "CatalogEntryDevice": {
      "UDF": "MCCE-E7DI-EVQ2-QOV3-TXT2-BF5W-F4EP",
      "DeviceUDF": "MA4R-CNBL-PSTE-QXT7-3GJK-KQQL-KCGD",
      "EnvelopedProfileDevice": [{
          "dig": "S512",
          "cty": "application/mmm"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleVNpZ25hdHVyZSI
  6IHsKICAgICAgIlVERiI6ICJNQTRSLUNOQkwtUFNURS1RWFQ3LTNHSkstS1FRT
  C1LQ0dEIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgI
  CAgICAgICJQdWJsaWMiOiAiUDhVZUJhM1p6TkFVRmx5NXNyaFR2NEpUbGtIbWs
  xUWVTWFJRdDN0RVgzYTNKRHE3VkpBaAogIFZSSXhkd2VLWk1rRHdTU1ZqbWk3b
  VBvQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI6ICJ
  NQklNLU5JNTctRVBCRC1UQVBHLURRWk4tV0pJRS1DS0U0IiwKICAgICAgIlB1Y
  mxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiA
  gICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAic
  y05S0hQX0dVdWZobFVWeTRuTHRiSkY1VFZsYzI1a1NjMjFXNDZIeDdDdlA5MGl
  4ZkNWeAogIHpGTVUwMktWNVFRTnBVRDZIeGNNYjhZQSJ9fX0sCiAgICAiS2V5Q
  XV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUJQNy1PS0ZELUxVTTQ
  tTjY1TS1aUExSLUg2NkktQUdENCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzI
  jogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI
  6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIm92UHN1VDRjTVFqa1NHS
  Vh4dG93Q05zeU5lc0g2b3Bock16S040VXEwdTY2N2ViT2wtcnEKICBzUVhDVWt
  pNHo1bWZiZFgtYzBFTlBIeUEifX19fX0",
        {
          "signatures": [{
              "signature": "9Zc3IuHI6E6BoOYgzJDLZK8906vS-eTBfceuBHRrutdUOYeUu
  _x8ii2Fk7W6_jvaVrAMSTmciayAih-SBG4rkGsWVdpxI2XY7Nr3f7zjApaylW2
  Vj_UU697VYcdFr10uwBDZ_vviagFtBIL9C1gBijEA"}],
          "PayloadDigest": "UyfA_CqoDmvzGyKj1Qv97UHu8tpt5NEXAuHFkycu5CTsB
  H2bG-AKXsZLdzw1S2YJTC0OVLA6thUpPD3W2_AhbA"}],
      "EnvelopedDeviceConnection": [{
          "dig": "S512"},
        "ewogICJBc3NlcnRpb25EZXZpY2VDb25uZWN0aW9uIjogewogICAgIkt
  leVNpZ25hdHVyZSI6IHsKICAgICAgIlVERiI6ICJNQ0NFLUU3REktRVZRMi1RT
  1YzLVRYVDItQkY1Vy1GNEVQIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB
  7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiOC1venpvcEZZV0Y5QUd0UVJ
  NMXpnQTZoa2hZWU5TcU1ISVVlem5QZDFfaGpsWEJzYk9SMwogIGExOG00UEhFb
  0RSWWhSZk82bElCU1JFQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICA
  gICAgIlVERiI6ICJNRFBSLUZONEItTVNPWC1NVktXLUhSRFMtNlRXUC1KSEo1I
  iwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0t
  leUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgI
  CJQdWJsaWMiOiAiUnRCYWYzT0NPVlBJQ3M4bW9MS04zNWg1WXRUVHllWUJCSFA
  0R3dVcWZYXzhoQTdWeWpFVgogIEp1ZFoxQ3hlQnpqWEdrWEExdE56aEdNQSJ9f
  X0sCiAgICAiS2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUN
  ZVC01U0tGLVc0NkgtNFEzRy00R0RHLTNUM1ItVzRUMiIsCiAgICAgICJQdWJsa
  WNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICA
  gICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIkZqM
  lZ0a1MxazFKeHptaU9GM1loOEpOVVNmN29ORkI0UnFNblc4RHJwQ3A1X183Tnl
  MYjYKICBaaDNDc0t0bzVHZ1FoMHg1WXlxNEdSdUEifX19fX0",
        {
          "signatures": [{
              "signature": "Ds2hHg54y1XnuK2Z6YNzNFV-d_-HjuCsUGpTTKkq9_vzBOWF7
  c_0yQ5-njIVRELsUTYY8hMIr-yAzwOlLTn2_YVoPV4Ru-x1tMZGtEqZ3grWIg5
  -DfFANHzLR3giv2RlbQQSL_h6uiUTvPJ92V8n6yAA"}],
          "PayloadDigest": "DmgskmAYLLZSOMPPiUFxaU6Im4fO3sGl7gBuTf_U1_TMA
  JzYx1njLwlMzg4o05AUF24R-SdfBZX3tVrCwYN3CQ"}],
      "EnvelopedDevicePrivate": [{
          "enc": "none",
          "Salt": "SF7lw-xjwYwfZo2NZYR-RA",
          "cty": "application/mmm",
          "recipients": [{
              "kid": "MBIM-NI57-EPBD-TAPG-DQZN-WJIE-CKE4",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "JXEuhLh7TThJOMd0ojcGNSXU-H12rGS5RE0p1pVqP6c_UfizkFCl
  l-vcSRKwRn8zhLFzrIHkkrcA"}},
              "wmk": "pqampqampqY"},
            {
              "kid": "MBSP-UDSW-R5G6-6RE6-XYKE-TGM2-KZUV",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "CrX4ZZVuN8o1ISwkPOSFwb4jsNMsqBJnoLwDY2RntLzEQHSGxwxn
  zbqYILVgtN8QnIj-PDp3IbcA"}},
              "wmk": "pqampqampqY"}]},
        "ewogICJBc3NlcnRpb25EZXZpY2VQcml2YXRlIjogewogICAgIktleVN
  pZ25hdHVyZSI6IHsKICAgICAgIlVERiI6ICJNQ0NFLUU3REktRVZRMi1RT1YzL
  VRYVDItQkY1Vy1GNEVQIiwKICAgICAgIkJhc2VVREYiOiAiTUE0Ui1DTkJMLVB
  TVEUtUVhUNy0zR0pLLUtRUUwtS0NHRCIsCiAgICAgICJPdmVybGF5IjogewogI
  CAgICAgICJQcml2YXRlS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ
  0NDgiLAogICAgICAgICAgIlByaXZhdGUiOiAidnFzdjhUbi1sLVJLNHhvdDFrV
  HVxTzVqVHdyT1JrWFY3Y1BYWHJ5WnZQTXZsWjF2enpYCiAgRkdjREpPMUNPMVV
  hZXE3MFVieU9BaXBFIn19fSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgI
  CAiVURGIjogIk1EUFItRk40Qi1NU09YLU1WS1ctSFJEUy02VFdQLUpISjUiLAo
  gICAgICAiQmFzZVVERiI6ICJNQklNLU5JNTctRVBCRC1UQVBHLURRWk4tV0pJR
  S1DS0U0IiwKICAgICAgIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXl
  FQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiU
  HJpdmF0ZSI6ICJfYnpTSzE2WmJZVE5XbVVDTEo2NmI1Q2JlZVZoWDFoYk1vNzd
  aUkthSVd0Wl9vSzJsYjAKICB0dFl1cFk2dzNDN0pkOEdiQmJnamw5ck0ifX19L
  AogICAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1DWVQ
  tNVNLRi1XNDZILTRRM0ctNEdERy0zVDNSLVc0VDIiLAogICAgICAiQmFzZVVER
  iI6ICJNQlA3LU9LRkQtTFVNNC1ONjVNLVpQTFItSDY2SS1BR0Q0IiwKICAgICA
  gIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjogewogICAgI
  CAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0ZSI6ICJiT05
  tODMxUlgyVFpoZ2FZWTItbEIwdVMyYXNnMmpteDAxcXNpRENyZEZrQU5EUkNJU
  DEKICBRdms5V1J4dkZPSy1rN0wxcm1QNXRkWncifX19fX0"]},
    "MeshUDF": "MBBK-T2SZ-MQNV-3UH3-XLQR-Y2QR-IF6S",
    "ProfileMaster": {
      "KeySignature": {
        "UDF": "MBBK-T2SZ-MQNV-3UH3-XLQR-Y2QR-IF6S",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "sh4pYlZaU-HtyWzSRtsfQOAHH4pL1T26zZSCZK2kE1f1e6OdTRUK
  WmSiRo3tKx8NHNyE4bmqqdkA"}}},
      "OnlineSignatureKeys": [{
          "UDF": "MD6K-FDLR-N4M3-QSOZ-KZW7-I4HI-Y7DY",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "gYt3ySP-K4KprIJN94LdnsMD2mc0Wb7BzL9v5dJSmJ5jfYZTo5Ts
  lntFqqToZyQZsToIsJxDBLSA"}}}],
      "KeyEncryption": {
        "UDF": "MBSP-UDSW-R5G6-6RE6-XYKE-TGM2-KZUV",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "6Txxd-tzVD-o37cLarIpGgIXjxsggYE1PfQyacLwSFjP-m384aqk
  CWOoj726gO-s0Xwdnh3kSnyA"}}}}}}
````


# mesh escrow

````
escrow   Create a set of key escrow shares
       <Unspecified>
    /alg   List of algorithm specifiers
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /quorum   <Unspecified>
    /shares   <Unspecified>
````

The `profile escrow` command 


````
>profile escrow
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>profile escrow /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

# mesh export

````
export   Export the specified profile data to the specified file
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile export` command 

**Missing Example***

# mesh get

````
get   Describe the specified profile
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile get` command 


````
>profile get /mesh=personal
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>profile get /mesh=personal /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````




# mesh import

````
import   Import the specified profile data to the specified file
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile import` command 

**Missing Example***

# mesh list

````
list   List all profiles on the local machine
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile list` command 


````
>profile list
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>profile list /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````


# mesh recover

````
recover   Recover escrowed profile
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /file   <Unspecified>
    /verify   <Unspecified>
````

The `profile recover` command 

**Missing Example***

