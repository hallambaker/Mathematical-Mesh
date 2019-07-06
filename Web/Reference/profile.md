

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
>mesh create
Device Profile UDF=MCGG-AUII-VXPT-36PS-PFMS-NJWV-ITPG
Personal Profile UDF=MD45-T5CQ-IJOJ-YR7L-MIN3-RXVU-2WKS
````

Specifying the /json option returns a result of type ResultMasterCreate:

````
>mesh create /json
{
  "ResultMasterCreate": {
    "Success": true,
    "DeviceUDF": "MCGG-AUII-VXPT-36PS-PFMS-NJWV-ITPG",
    "CatalogEntryDevice": {
      "UDF": "MCGG-AUII-VXPT-36PS-PFMS-NJWV-ITPG",
      "DeviceUDF": "MA7L-SXQA-MYOW-UUHE-V6G2-EZAS-HUZE",
      "EnvelopedProfileDevice": [{
          "dig": "S512",
          "cty": "application/mmm"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleVNpZ25hdHVyZSI
  6IHsKICAgICAgIlVERiI6ICJNQTdMLVNYUUEtTVlPVy1VVUhFLVY2RzItRVpBU
  y1IVVpFIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgI
  CAgICAgICJQdWJsaWMiOiAiQ1BGQ3A4WW5VbXl1enYxaVVUVG56X3Z1OUoyTEJ
  SSnNteEVnVXg1VXJqOEZ3cm1UNlQwRgogIFpJTTRHSFRjZEJUMkowZS1xMnpJc
  25NQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI6ICJ
  NQ1NWLTM3TUgtNFRQVi1FS0RKLVBLTFAtWVNJMy1QWTI0IiwKICAgICAgIlB1Y
  mxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiA
  gICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAia
  WtsaVMzUkV6bVlsYW1JTERtUHJ2UkdRWjJqSkwyQnpyOXlqdGxseUZnY3VhRXB
  MRzRQawogIGF1U2dFSy15akFmcG9zYlhCd0VqdVk2QSJ9fX0sCiAgICAiS2V5Q
  XV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUNPUC01SVdYLUJDSTc
  tUjJEQS1OSlVBLUlZSEMtQ0NDNSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzI
  jogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI
  6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogImhjWGNoX0lTSFF0bVpDQ
  Ws2b2tFSmlvMU0xZWhhZGtxTmpBc3VidFBacDBiRTdVNnBGOVMKICBuT0E0UTh
  iSzk3UDlnZzVHU1JSV2FzUUEifX19fX0",
        {
          "signatures": [{
              "signature": "JBMCZldwoO_zpvA6GL6rZ_tNEQ-on4t0-FpqubZfMj5HcvsFU
  pTRHwq6WgFX0_lfuGxCbq5HLJiAlOqAIXzPNBBQHPf9sSvOxGOVc6xo--oDy42
  zUoy-FT7M14s2WUcSAIORqy4Ls-43aGZ9CNdYlTYA"}],
          "PayloadDigest": "RhBqszmjmogeiao6FWsr2qbjLp2F_jjWxLMC_E_RgUWks
  zucBqRiqLz_juNPaj9dWnNw1yDlW1ar6TwSs-XgNw"}],
      "EnvelopedDeviceConnection": [{
          "dig": "S512"},
        "ewogICJBc3NlcnRpb25EZXZpY2VDb25uZWN0aW9uIjogewogICAgIkt
  leVNpZ25hdHVyZSI6IHsKICAgICAgIlVERiI6ICJNQ0dHLUFVSUktVlhQVC0zN
  lBTLVBGTVMtTkpXVi1JVFBHIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB
  7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiNHR3MTNhZ0Nscmg5M0xEd1B
  ZZUwtT0tsYXA3TTg5UXVaSV8tcTBZSEw0YlQwdFd6QUZaXwogIDhKTUZzeXpYb
  np1TWVkVThCLTA0VUtNQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICA
  gICAgIlVERiI6ICJNQllOLUZOTEItRTRITC1MRVM0LUY1WE4tNFRPTS1VQk1KI
  iwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0t
  leUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgI
  CJQdWJsaWMiOiAiWG96R3pqYm1ob3VVV1pQbTdCelRGSjhZeG81em80YWlCNHJ
  aN2dHakpVcjZxZ3JWbHJTegogIFNDUzQ5Wnc0ai14ZE5hTlhKRkJMSzF1QSJ9f
  X0sCiAgICAiS2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUN
  EWC1PWlRHLU9GUEgtUzQ1Vi1QM1BKLUxNUE0tSUZONiIsCiAgICAgICJQdWJsa
  WNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICA
  gICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIjY1d
  jJNSFg3R3czVmVnNW9LMzZDaURQdl9TeWh4eU9tNDRYMDlIX2d0R0JKRHRmaHh
  XZjAKICBES0tNVVQ3VkJOSlRCbW9mb01mbEVWZ0EifX19fX0",
        {
          "signatures": [{
              "signature": "Ndu-ipCksYsWuw6vXrWMcQUPimDIx52Eflc1G-y3PGAXZBPNZ
  OcYqzccgn4RYaeyAXGxJGik8W4AyEfuRfsahOMZLcU0kNYnogzPww009Vlk93H
  zctlg0apVi9Kgf75BjYct45uFuBVsdVKTb77boDMA"}],
          "PayloadDigest": "136DTH0KI7Y_zyfI_4eM95QZon81Sq1xQ_I4Dv6gn9PUe
  r_efrnmJ9g2iyCz0afe4UBxxGd0RyYKrgJsxavwbw"}],
      "EnvelopedDevicePrivate": [{
          "enc": "none",
          "Salt": "OXcRHYANDS_LT_p2GI-Ytw",
          "cty": "application/mmm",
          "recipients": [{
              "kid": "MCSV-37MH-4TPV-EKDJ-PKLP-YSI3-PY24",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "dA4o6nJwhVWdt6-a1XBRvlScip75kRVSFClssnR4caCS2gAEGNZg
  kqzILt7KZGvEAMvPjxIQ8s0A"}},
              "wmk": "pqampqampqY"},
            {
              "kid": "MCAC-DMMI-FLIT-3EED-E7ZU-G4OD-FOP7",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "i_43C_sWidkistlcR54xg366zSCLzTJ1hVJX3TtmdLUNhaBD43lR
  uEV85zqAaSeKjvu6AEuRVseA"}},
              "wmk": "pqampqampqY"}]},
        "ewogICJBc3NlcnRpb25EZXZpY2VQcml2YXRlIjogewogICAgIktleVN
  pZ25hdHVyZSI6IHsKICAgICAgIlVERiI6ICJNQ0dHLUFVSUktVlhQVC0zNlBTL
  VBGTVMtTkpXVi1JVFBHIiwKICAgICAgIkJhc2VVREYiOiAiTUE3TC1TWFFBLU1
  ZT1ctVVVIRS1WNkcyLUVaQVMtSFVaRSIsCiAgICAgICJPdmVybGF5IjogewogI
  CAgICAgICJQcml2YXRlS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ
  0NDgiLAogICAgICAgICAgIlByaXZhdGUiOiAiaG1wUE5Hb0diRXQ5Z25jNHlYS
  1VLblBJbkRaOGcwRTluOS11VmdsTld6b0QzZUprZkV1CiAgOGlXTXUxYkx0QjV
  leVY0QnNqQVBxMzZZIn19fSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgI
  CAiVURGIjogIk1CWU4tRk5MQi1FNEhMLUxFUzQtRjVYTi00VE9NLVVCTUoiLAo
  gICAgICAiQmFzZVVERiI6ICJNQ1NWLTM3TUgtNFRQVi1FS0RKLVBLTFAtWVNJM
  y1QWTI0IiwKICAgICAgIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXl
  FQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiU
  HJpdmF0ZSI6ICJ0R2tSYjIxR1pVeXhONDdwVHhoeDRqNE0wYWd4M1JlUVItY29
  vaXJ5dURadlBDdjV5dWcKICBXVE5BOXc4ald0ejlYektRMDhCNXBnWjQifX19L
  AogICAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1DRFg
  tT1pURy1PRlBILVM0NVYtUDNQSi1MTVBNLUlGTjYiLAogICAgICAiQmFzZVVER
  iI6ICJNQ09QLTVJV1gtQkNJNy1SMkRBLU5KVUEtSVlIQy1DQ0M1IiwKICAgICA
  gIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjogewogICAgI
  CAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0ZSI6ICJreE9
  qZl9TdkJpZS15eUNHbmJSMWtyOXFlTm96bWRJTmpUdVV5R2c3bWwtV1dzV0ZUN
  msKICBJazZScnFoY3JTQ2Z5eFd6blpkSlE2MDAifX19fX0"]},
    "MeshUDF": "MD45-T5CQ-IJOJ-YR7L-MIN3-RXVU-2WKS",
    "ProfileMaster": {
      "KeySignature": {
        "UDF": "MD45-T5CQ-IJOJ-YR7L-MIN3-RXVU-2WKS",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "sneRBzgWj3yzsNOY-VIg_RyRj11lGv6mR5LuhPqTAwTDz_67tevk
  xTe1FVulCx3g6xN3YjkctHeA"}}},
      "OnlineSignatureKeys": [{
          "UDF": "MCSR-MO56-6Q64-ODOO-WOBP-KJXR-HTIC",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "TeDF15WFZHq1ZAX3DT6PfNZTxk_MDzefSYd8gwrbEyqXOscpTK53
  6gcGHBkJA4NkyDx9DDqDEdqA"}}}],
      "KeyEncryption": {
        "UDF": "MCAC-DMMI-FLIT-3EED-E7ZU-G4OD-FOP7",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "kJhetipFxq9g-9c5I9vx3gXKANtAY5mrSaVRIM3vXAqcMTuE5kh9
  dUuaTV4hYP8quTU2i78u6JcA"}}}}}}
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
>mesh escrow
ERROR - The cryptographic provider does not permit export of the private key parameters
````

Specifying the /json option returns a result of type Result:

````
>mesh escrow /json
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
>mesh export profile.dare
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>mesh export profile.dare /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
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
>mesh get
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>mesh get /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
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
>mesh import profile.dare
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>mesh import profile.dare /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
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
>mesh list
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>mesh list /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
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
>mesh recover $TBS $TBS /verify
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>mesh recover $TBS $TBS /verify /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

