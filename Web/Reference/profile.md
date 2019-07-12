

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
    /account   New account
    /service   New service
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
Alice> mesh create
Device Profile UDF=MCKR-DONM-GGOF-IVUO-PTIV-CINH-CIO4
Personal Profile UDF=MCE7-VDTJ-UIEB-6YDB-O5WX-Y747-3OF3
````

Specifying the /json option returns a result of type ResultCreatePersonal:

````
Alice> mesh create /json
{
  "ResultCreatePersonal": {
    "Success": true,
    "DeviceUDF": "MCKR-DONM-GGOF-IVUO-PTIV-CINH-CIO4",
    "CatalogedDevice": {
      "UDF": "MCKR-DONM-GGOF-IVUO-PTIV-CINH-CIO4",
      "DeviceUDF": "MBN4-IPKA-R4GQ-QXS6-5XU3-2OC4-GR5H",
      "EnvelopedProfileDevice": [{
          "dig": "S512",
          "cty": "application/mmm"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUJONC1JUEtBLVI0R1EtUVhTNi01W
  FUzLTJPQzQtR1I1SCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogIjZwbzFybzFYSDlvUmFBTjJtQXpqdDh
  rLUluOTZMQVJjSU5YWjdZdTJDV2hFZWU3ZTRMOGkKICBrd2d1ZlMtNmhBVW9Ga
  GExck14Q3R5a0EifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUJSNS02R01TLVZESUItWE1SVi1TQlI1LUJVWTQtVVFCSiIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVib
  GljIjogInhyR2M4Wm9wNHlVdnFnZGIxbVJHMGQ4ZjBjVm11Z1VOQmdpY3d5d1h
  NNkhGMmtJNi1EM2EKICBKeEV5dV9hc2dZZ09jMWFsWG1GZzRXZUEifX19LAogI
  CAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1DVzItS0k
  3Ri1SQkk0LTdMTEYtVUJCNS01NVdOLU83TzIiLAogICAgICAiUHVibGljUGFyY
  W1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJoNktISDktZ
  ldzVmp0UV9tU3FkaDZXai1IUUNHQ3VNb3gwLUlrMUZuMGNxTVlnSExoS0FxCiA
  gV1RkMlNVcU9VV0hlT3E4czQ4c3ZhdmVBIn19fX19",
        {
          "signatures": [{
              "signature": "ERrOaiK6PudlrCOzX8Pt1LnUmdSnJmMSfc3Vg-vtvi6mMe775
  n1eL_tlzUvW9CId48BmAQuYSjIAlUBSK2YvPVBClhD0c4DU3ANXKB72pGoVuFY
  3lPQVX6qJ3hmHAo1aoUGk0JELf9snyIrzRLNEdyIA"}],
          "PayloadDigest": "y-zT81aTl723dzSk7Vm1U4zSS4rqqRNPmD5f6mH5qlEwB
  gB7Vmr0SRHWTszXGpDW--EAX4PWpDxfk_b4YkuQWQ"}],
      "EnvelopedConnectionDevice": [{
          "dig": "S512"},
        "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQ0tSLURPTk0tR0dPRi1JVlVPLVBUSVYtQ
  0lOSC1DSU80IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiaExHd0RvT044S05HNUxnR0g0UWZYb3VRYnJ
  EWkVoM2ViUWF2cVJGeDcwSUtoaGZPaUpJUwogIGxjWGRDbWJHenU4ZHJocUdRW
  kN5c3ZrQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI
  6ICJNQjVSLUJGTlctQTRRVy1aSzMyLVU2RzctSzZPVy1STDNCIiwKICAgICAgI
  lB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB
  7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAiYWVVT3dxRGdWVTh5dmp0TXluRHBFcHRSS3doZUlFS0JwRElhYnFPRFFDMWU
  0S0V0dmhMRgogIHJzTGlveC1uRGRIRUtHUENOVHgybzZlQSJ9fX0sCiAgICAiS
  2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUJJVi01NlhQLUZ
  DVU4tVFdRUy1VNEw1LUFCM0wtWllRVCIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImN
  ydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIm0wa200T0tieEhJc
  DlTb0wxVWRIZXpibHMwT05mazg4U3BhRnhUS015YWIxVmZTUXpkQXQKICBGY1M
  wdUdYc0hYZHhzUjViV3g0dmVxa0EifX19fX0",
        {
          "signatures": [{
              "signature": "Hb6btV8nWOvA5LhaXov9YMMMgZs6QFTeixlFeAMG6RqQ1I5oJ
  GdAaoOMGH237-43cwUyYuk-JwuA9r1zWSChSTmeyVnS_RlfTRkxBiog9ObdBe6
  I_m-OpA1ANEw7Tl82iJ2tnh3QSIA_ocFIyTA00xkA"}],
          "PayloadDigest": "GmUBcGlIgKX54cxUXHaeDfAPpwx3fP3t-PL4LTCLAQgqv
  NrV0RABJDreGMq_HFC1ovfRTiLBEzpXRiREV2Jenw"}],
      "EnvelopedActivationDevice": [{
          "enc": "none",
          "Salt": "IrPjelJ-u9e1hf_hAvSulA",
          "cty": "application/mmm",
          "recipients": [{
              "kid": "MBR5-6GMS-VDIB-XMRV-SBR5-BUY4-UQBJ",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "HlQDcSstgdLRSlvdO32Yznv_hzbSVaWIVLbRYwShFLTHNoJNA-o-
  HEE87OdAPGbPfekePyMsRwmA"}},
              "wmk": "pqampqampqY"},
            {
              "kid": "MCYT-EVFJ-PR37-BK4Y-4VIC-6BUK-APCG",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "1r15VCiUdCkd-xc-MrjnIPFkJRijaYbGz7ZR1vY8gtsKVd2XodS9
  -uB5mK59qm58DcGez2vhmfWA"}},
              "wmk": "pqampqampqY"}]},
        "ewogICJBY3RpdmF0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQ0tSLURPTk0tR0dPRi1JVlVPLVBUSVYtQ
  0lOSC1DSU80IiwKICAgICAgIkJhc2VVREYiOiAiTUJONC1JUEtBLVI0R1EtUVh
  TNi01WFUzLTJPQzQtR1I1SCIsCiAgICAgICJPdmVybGF5IjogewogICAgICAgI
  CJQcml2YXRlS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAo
  gICAgICAgICAgIlByaXZhdGUiOiAiWkd5bFdlX3ZlT2s5SzMzdzJMWnB1OTcwd
  HVXLXRkbl9vN0FmR2Z3UkRMbFhqVUphU2VTCiAgbE9rV1FJc3h0MFB0b0FLeDc
  4d0l2UXdFIn19fSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgICAiVURGI
  jogIk1CNVItQkZOVy1BNFFXLVpLMzItVTZHNy1LNk9XLVJMM0IiLAogICAgICA
  iQmFzZVVERiI6ICJNQlI1LTZHTVMtVkRJQi1YTVJWLVNCUjUtQlVZNC1VUUJKI
  iwKICAgICAgIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjo
  gewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0Z
  SI6ICJDdFZHQ29Kb1JNQ01DS3VrY0hYNEo3VHBwS0NNRk1LTjBFYlA2czhUazR
  CcVIwZmlMMjUKICAyYjJfYy1SODQyZmlYU3hBWHhTZjc3cDgifX19LAogICAgI
  ktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1CSVYtNTZYUC1
  GQ1VOLVRXUVMtVTRMNS1BQjNMLVpZUVQiLAogICAgICAiQmFzZVVERiI6ICJNQ
  1cyLUtJN0YtUkJJNC03TExGLVVCQjUtNTVXTi1PN08yIiwKICAgICAgIk92ZXJ
  sYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjogewogICAgICAgICAgI
  mNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0ZSI6ICJPdTVwTGdDLTV
  jU3pMUDRuTkZFd0NlRUZfb0JZeVBvcEdhQmh0RzZncWcwM1JsejRJZUoKICA5Y
  mVrZ0R1em9HOTV3VjlibUwyVlBxRlUifX19fX0"]},
    "MeshUDF": "MCE7-VDTJ-UIEB-6YDB-O5WX-Y747-3OF3",
    "ProfilePersonal": {
      "KeyOfflineSignature": {
        "UDF": "MCE7-VDTJ-UIEB-6YDB-O5WX-Y747-3OF3",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "DPMW09A83Hm1X0_bz52pa6YYLzlinhdJ3Ds1vP6UmMuKIinqmQCJ
  QxviowXYisR9uq2ytWcLYrwA"}}},
      "KeysOnlineSignature": [{
          "UDF": "MAA5-7XXO-SVJM-Q6DC-N6QR-AYT4-A2KW",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "NxXp-CopCDP6K2yrk9G1S9Y3W3jQweRHSjPeYIy7L2dGi0-nhx0C
  1Ze8CaJUWmb7QCWzaf7PC1GA"}}}],
      "KeyEncryption": {
        "UDF": "MCYT-EVFJ-PR37-BK4Y-4VIC-6BUK-APCG",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "nyPKO61YQhBxg0VsD8G51G-6Pudiva3Jf_GSV4N5i1EOoZZ473aG
  twIByIpwTTw74BtaEqBlcD2A"}}}}}}
````


# mesh escrow

````
escrow   Create a set of key escrow shares
       <Unspecified>
    /alg   List of algorithm specifiers
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /quorum   <Unspecified>
    /shares   <Unspecified>
````

The `profile escrow` command 


````
Alice> mesh escrow
ERROR - The cryptographic provider does not permit export of the private key parameters
````

Specifying the /json option returns a result of type Result:

````
Alice> mesh escrow /json
{
  "Result": {
    "Success": false,
    "Reason": "The cryptographic provider does not permit export of the private key parameters"}}
````

# mesh export

````
export   Export the specified profile data to the specified file
       <Unspecified>
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile export` command 


````
Alice> mesh export profile.dare
````

Specifying the /json option returns a result of type ResultMachine:

````
Alice> mesh export profile.dare /json
{
  "ResultMachine": {
    "Success": true,
    "CatalogedMachines": []}}
````

# mesh get

````
get   Describe the specified profile
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile get` command 


````
Alice> mesh get
````

Specifying the /json option returns a result of type ResultMachine:

````
Alice> mesh get /json
{
  "ResultMachine": {
    "Success": true,
    "CatalogedMachines": []}}
````




# mesh import

````
import   Import the specified profile data to the specified file
       <Unspecified>
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile import` command 


````
Alice4> mesh import profile.dare
````

Specifying the /json option returns a result of type ResultFile:

````
Alice4> mesh import profile.dare /json
{
  "ResultFile": {
    "Success": true}}
````

# mesh list

````
list   List all profiles on the local machine
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /mudf   Master profile fingerprint
````

The `profile list` command 


````
Alice> mesh list
````

Specifying the /json option returns a result of type ResultMachine:

````
Alice> mesh list /json
{
  "ResultMachine": {
    "Success": true,
    "CatalogedMachines": []}}
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
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /file   <Unspecified>
    /verify   <Unspecified>
````

The `profile recover` command 


````
Alice> mesh recover $TBS $TBS /verify
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
Alice> mesh recover $TBS $TBS /verify /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

