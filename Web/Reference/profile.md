

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
Device Profile UDF=MCJW-G2VQ-OM3B-REPM-RRGA-MSIR-BWPH
Personal Profile UDF=MD2T-3WE6-TJAM-QU3C-CXGM-4EW4-4QDM
````

Specifying the /json option returns a result of type ResultMasterCreate:

````
Alice> mesh create /json
{
  "ResultMasterCreate": {
    "Success": true,
    "DeviceUDF": "MCJW-G2VQ-OM3B-REPM-RRGA-MSIR-BWPH",
    "CatalogedDevice": {
      "UDF": "MCJW-G2VQ-OM3B-REPM-RRGA-MSIR-BWPH",
      "DeviceUDF": "MDUU-IVIN-GB7X-AXYV-PZT4-WICV-UPDU",
      "EnvelopedProfileDevice": [{
          "dig": "S512",
          "cty": "application/mmm"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleVNpZ25hdHVyZSI
  6IHsKICAgICAgIlVERiI6ICJNRFVVLUlWSU4tR0I3WC1BWFlWLVBaVDQtV0lDV
  i1VUERVIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgI
  CAgICAgICJQdWJsaWMiOiAiU21BNGlFZElrQWpmaFpack1zcmRqb2U4cEMtZWN
  XTTJzVVZ0UlVqdmhCSkp0SVQxeGhZZwogIHNSMGp2dHpjREc0U0FVXzIzOGFrS
  ktHQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI6ICJ
  NQjJVLVFTTU8tUjNDWC0yMzQ1LUNSR04tUlVWQy1QNlJPIiwKICAgICAgIlB1Y
  mxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiA
  gICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAib
  DIzaEZDYld6czZXektLdUFqUENqRU1UcXh2a0s4NnJvZTVIYnNodkxiR0RwRWR
  iU0RoMwogIDJaM0tBT0Ntck9lc1plNG4xTDRvR1d5QSJ9fX0sCiAgICAiS2V5Q
  XV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUE1Ni01UEtLLVhNUUU
  tQk5QQi1EUVdYLVlYQVUtVEhXTSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzI
  jogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI
  6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogImxxRW9CY0JsT2MyZkEwb
  TZCWHFOQWFiRTRYdGlpNl95Uk81cmhyTHNWYjhMRFFoRnp6czYKICA0ZnBDOGN
  3THhEa25SMmhPOW5JZmFGV0EifX19fX0",
        {
          "signatures": [{
              "signature": "-NgfL9E2XWL_UmXflEualUnQVZ7JQN0ghz9j5qNh0LNzdtA7v
  W78-i9o2P-K4qJDG0fZPCGQinSAKyDcMAwfzJjk7dz_ThVqtFt1YsQjqagJ2tg
  JcggDdqdsXjBxiNeeG3Xt5tiyuR82gs8GuRTU6iEA"}],
          "PayloadDigest": "W8XhV5Zk0LvNs3D1ol8vzgKbiOh4aU1jKvfjkiFEdOaix
  zXeVszW-N6fb7K59KwGjowl-MbSblmZwek0ISwkPw"}],
      "EnvelopedDeviceConnection": [{
          "dig": "S512"},
        "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQ0pXLUcyVlEtT00zQi1SRVBNLVJSR0EtT
  VNJUi1CV1BIIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAic2VUQzFkcHFzSmJvVGNRZldyMk9WZlRXME1
  tSEtzSW1YZ0RGUWg2dzYzaHA5b0R5aUlaSAogIFpCMUxVUkdQYmJTWlNPeU9wZ
  FdjalRNQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI
  6ICJNQUZTLTdKNVYtVEZHVy0yVU5VLUhPRkgtVVVDWC1TUURTIiwKICAgICAgI
  lB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB
  7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAiTGZQYmN6QzlHWE5TZ0FDcUNiajhjRGpad2NTbFJnQXlFcHZ6VkpqczZDSFI
  zVTRtSTZrQgogIHhPdHFhSnRqYXdPWUU3VF8teWF3elBJQSJ9fX0sCiAgICAiS
  2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUJLUi1KWUFBLVB
  SQUctQzRXRi1OQVZOLVBGQ1gtWjROQyIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImN
  ydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIllLQkJrcDRQM1hXe
  WJSOXdJOWZRVnRhVkszVFd6VDFlWmJPRkFPV3B6aEgxQk9jZUFIWkYKICBEVms
  4LVBia2ZHXy1CdlJ2aHlBQkF4T0EifX19fX0",
        {
          "signatures": [{
              "signature": "d8gUnGPwRtZKdyBnThHpUh1ESYliLPQZvC-qeficlnVHRiq-1
  RvRnWAgadJOlRYW04QYK5pizZMAT9pylsUK62GBGA_tu8Apwg0pTK6xj0GdSfk
  J78NEpDOR3O38n4F9D-IE-81a-WG-L5_Qbld61hEA"}],
          "PayloadDigest": "Scv0WGuY6U3GYyMy2qMiBc5v7EsOVB810rPu3AySsSRIQ
  dWtcHhhB1PTOpzgM5ZQ5X3Qu3tXBRAUxt1njjqigw"}],
      "EnvelopedDevicePrivate": [{
          "enc": "none",
          "Salt": "gEuaSalW-btwSy3NHNmQpQ",
          "cty": "application/mmm",
          "recipients": [{
              "kid": "MB2U-QSMO-R3CX-2345-CRGN-RUVC-P6RO",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "Kru-0xMtVd_TgTLeJPZtN9v07AgVSmggEwihL9M2i14UOjdjo4e3
  gmKeGzuuOGjfh0VsNI10GekA"}},
              "wmk": "pqampqampqY"},
            {
              "kid": "MCPD-GBBJ-BD6T-W6KJ-VUDI-ME2X-SUYQ",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "6MunD0GIT65WFZQ0Eqwd_yzAPQJWN13q4FVxzphaZIJZv1lLPANh
  KRClPx_T-Q0Tnmt2ruRqp0-A"}},
              "wmk": "pqampqampqY"}]},
        "ewogICJBY3RpdmF0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQ0pXLUcyVlEtT00zQi1SRVBNLVJSR0EtT
  VNJUi1CV1BIIiwKICAgICAgIkJhc2VVREYiOiAiTURVVS1JVklOLUdCN1gtQVh
  ZVi1QWlQ0LVdJQ1YtVVBEVSIsCiAgICAgICJPdmVybGF5IjogewogICAgICAgI
  CJQcml2YXRlS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAo
  gICAgICAgICAgIlByaXZhdGUiOiAiU08xMzVaaDhGT3B4SWctTmtibDBVTTVZS
  jQxUl9oZEtGWGVfR1UzSXJscU12LU5DaTVyCiAgX3FuQXhfMFVGQVV6OVBZTmF
  fb2lGanIwIn19fSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgICAiVURGI
  jogIk1BRlMtN0o1Vi1URkdXLTJVTlUtSE9GSC1VVUNYLVNRRFMiLAogICAgICA
  iQmFzZVVERiI6ICJNQjJVLVFTTU8tUjNDWC0yMzQ1LUNSR04tUlVWQy1QNlJPI
  iwKICAgICAgIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjo
  gewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0Z
  SI6ICJQTGpZLUJrbVVwUTZBb1JaVWJDbnNlekZIVkY2b29yQlU0TFI4OTNjTlF
  LbmZIZVk1VnkKICBMdVNYMXlReHpyNXFxbnhYand6VDJZMmMifX19LAogICAgI
  ktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1CS1ItSllBQS1
  QUkFHLUM0V0YtTkFWTi1QRkNYLVo0TkMiLAogICAgICAiQmFzZVVERiI6ICJNQ
  TU2LTVQS0stWE1RRS1CTlBCLURRV1gtWVhBVS1USFdNIiwKICAgICAgIk92ZXJ
  sYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjogewogICAgICAgICAgI
  mNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0ZSI6ICJLZzFlMDc5MDB
  NOHdpemxJR0ItUVR2WVpDNXBDaVlVSFlqeUN6a0h1M1cxeGtmYnFMNGcKICBKc
  TFPckNIX1pNaDF3SFl3M21HdVB0MlUifX19fX0"]},
    "MeshUDF": "MD2T-3WE6-TJAM-QU3C-CXGM-4EW4-4QDM",
    "ProfileMaster": {
      "KeySignature": {
        "UDF": "MD2T-3WE6-TJAM-QU3C-CXGM-4EW4-4QDM",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "6tf8ETiZMzYUV5jKr7ulaQ1CGbjSYdX96cnO2U1x5Th7Ti0uLxBx
  ye-MndfsE-vpRsLRN_YRK5wA"}}},
      "OnlineSignatureKeys": [{
          "UDF": "MBYZ-ZDEG-JJO5-TT3I-EQW7-UHR3-BJIC",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "V21s-AnlqkjJRhqMPvkP5nQVuh3DvplM5E-Me5YIs2duatKxZ_lo
  3QhEGUwcY6WGUe_hoFmSeI8A"}}}],
      "KeyEncryption": {
        "UDF": "MCPD-GBBJ-BD6T-W6KJ-VUDI-ME2X-SUYQ",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "QliMGBmB6ovzmR3TH0l4Li_PKgmD4rcpODhl_tk7ICi5ZZfpxH7z
  VCjDdS_DqmyaK5CPwcTwGHOA"}}}}}}
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

