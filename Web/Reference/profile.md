

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
Device Profile UDF=MC64-NI5G-SVSU-WIP6-AOZH-SFPQ-UQTW
Personal Profile UDF=MDB2-7MDK-LXVK-UGT3-AWMP-C7BD-U65F
````

Specifying the /json option returns a result of type ResultMasterCreate:

````
>mesh create /json
{
  "ResultMasterCreate": {
    "Success": true,
    "DeviceUDF": "MC64-NI5G-SVSU-WIP6-AOZH-SFPQ-UQTW",
    "CatalogedDevice": {
      "UDF": "MC64-NI5G-SVSU-WIP6-AOZH-SFPQ-UQTW",
      "DeviceUDF": "MCLU-PRZY-LBSI-774D-C5NT-XB6C-427Y",
      "EnvelopedProfileDevice": [{
          "dig": "S512",
          "cty": "application/mmm"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleVNpZ25hdHVyZSI
  6IHsKICAgICAgIlVERiI6ICJNQ0xVLVBSWlktTEJTSS03NzRELUM1TlQtWEI2Q
  y00MjdZIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgI
  CAgICAgICJQdWJsaWMiOiAiZnRRSThKMFU2NC1vLXFVc2c4ZGEwWEd1X0JpYjB
  JRzFiMmo2TzFSNThsZ2lSaFdTNGlXRgogIC0yN0JYNkhjVWN2WEFtcHBZWkd1X
  1M2QSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI6ICJ
  NRFlQLTJPWFktUkZBQS1ISVpULUlHSTYtV0hOVC1OQUpEIiwKICAgICAgIlB1Y
  mxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiA
  gICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiT
  UdnLXBfWjgtSWVKWjRRSTAtU09rajBXNUI2SVpfdXhWZnZxYWN0OXdzM0xHTzN
  WbFZ1dgogIHYtUkFRSFpZZUFmUjJHVzJlZERTbVhHQSJ9fX0sCiAgICAiS2V5Q
  XV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTURXVy1OT1hTLTMzRU0
  tUFRYTC1KVUFCLUVWNTUtVUdJTyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzI
  jogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI
  6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIkE3aG5NZzVjVkdZVEFrc
  GVrTktHYWk3S0JOQXJjajgtWFRBcUZBbWpzTTQ1QUpPalhYclgKICBkbWFPUWJ
  zTl9zRmVFOFowU2JkUXRHbUEifX19fX0",
        {
          "signatures": [{
              "signature": "n6AYizykmzd_iirYvGqvV_U5y1pIGBP1BCNh_kAHszKqesZFw
  TkS5DJUAMFgz1NCI55p3nUBjZqAeqHSF1POSJ4WZPYIe1xqhshP3XaYnomYtr9
  geWr8UVI0op7khFlo2cZfQ9ZzCW4qBRyiju4CJw8A"}],
          "PayloadDigest": "6bstTQkLhIMJAyif4QYi5lZNpVgqcFVFr4xJTH0s2qecO
  myEDmlwKddr_4dvpDqe5Yb8sUkraPPWqo7nkeUddA"}],
      "EnvelopedDeviceConnection": [{
          "dig": "S512"},
        "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQzY0LU5JNUctU1ZTVS1XSVA2LUFPWkgtU
  0ZQUS1VUVRXIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiNW5qeXAtRFlsdWVwTGpnSEVicWRfVVI3VlE
  yZi0xOTVUNnlxVFdkRzR6d0hSV3B0MDBkWQogIFRvUkQzV2xHa2NHWnFRYl9yS
  VdqWkdVQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI
  6ICJNQlBFLUNIWFotRVRISy1YSUNYLUlOWk4tMzJUSS1ZWERCIiwKICAgICAgI
  lB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB
  7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAiZUhyNzlqa0EyYjAyb1BGTUNvZ3RhUGh4Y2xLWk93SWlubFpmOXMzRnhMWUJ
  RYTd0ZXNfMAogIFpxWWJvcTVZOV96NDR0QXljRUlzcGFRQSJ9fX0sCiAgICAiS
  2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUFHVS1UWDRPLVB
  MVVktTkhYRC1WUEZYLVFaNjctQzIzNSIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImN
  ydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogInhkc0F1ckZJUTQ1e
  WJyQjZZUmg3YzRvQ3AwenN6blJseDN6bWk2b0FWNUw1ZG5wMVhCTjQKICByLV9
  LcWczS1huWGlBWFZJdjlBeDN6aUEifX19fX0",
        {
          "signatures": [{
              "signature": "Kpi1VklyjVkJcWQDqArvnrapB1SB4kUTQQsyV9o_sE9QR4pxF
  JOEIP4Q4-HOCSDhMN9MrdknbLwAna5CvLqZ8xkmJW7MpFb0c53bGvsIZBjFmrb
  -MNPuHfQpzzsWetLXCWQr4Pkw83Zpkqk42gbxUDwA"}],
          "PayloadDigest": "NchNoOKyM6QaaWPAD63LHfyVrEObqvOlcfR-BvSAyEL6h
  CKQqbhJmAwHGYB9esC_Hzf3PDjVzny6p6SKyldJEg"}],
      "EnvelopedDevicePrivate": [{
          "enc": "none",
          "Salt": "HaPTK93MZSpggVNQ_ljtOg",
          "cty": "application/mmm",
          "recipients": [{
              "kid": "MDYP-2OXY-RFAA-HIZT-IGI6-WHNT-NAJD",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "32hIxui1Zar8qwBRsjQl5LQjW63evBE7VOPBCrSddSmVIovQ5xeV
  eQ1Cia4SQ1YIjHZDK84X8zyA"}},
              "wmk": "pqampqampqY"},
            {
              "kid": "MC3B-KZ4A-XZFA-4IFD-ZA2H-ZY73-2QFN",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "9N_viivGvo5s8Q9e_j8kkEVojqmyk9W-qf3En31ADW-irfTfdcs8
  dstuPlSh-omkfswQPVa2djYA"}},
              "wmk": "pqampqampqY"}]},
        "ewogICJBY3RpdmF0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQzY0LU5JNUctU1ZTVS1XSVA2LUFPWkgtU
  0ZQUS1VUVRXIiwKICAgICAgIkJhc2VVREYiOiAiTUNMVS1QUlpZLUxCU0ktNzc
  0RC1DNU5ULVhCNkMtNDI3WSIsCiAgICAgICJPdmVybGF5IjogewogICAgICAgI
  CJQcml2YXRlS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAo
  gICAgICAgICAgIlByaXZhdGUiOiAiQmFVZzRVYTRVc3VqVkgyNzRXN0VNQlRkZ
  nVwSFE3cEszRWUyYnZ3aTNoWFBFRXBpRzJmCiAgQkc5MGRYQUZGa0h2dFpFbUp
  wenNzUG93In19fSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgICAiVURGI
  jogIk1CUEUtQ0hYWi1FVEhLLVhJQ1gtSU5aTi0zMlRJLVlYREIiLAogICAgICA
  iQmFzZVVERiI6ICJNRFlQLTJPWFktUkZBQS1ISVpULUlHSTYtV0hOVC1OQUpEI
  iwKICAgICAgIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjo
  gewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0Z
  SI6ICJ2QTREMmdjR0RpRXVId29kVnppcnNWblFHbVhMbVJhMEUxdEs1TEhFSEx
  LTXpqUG11WDUKICAwUnl5NTZucGtJRG91Z2VUU1lIRG1PaTQifX19LAogICAgI
  ktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1BR1UtVFg0Ty1
  QTFVZLU5IWEQtVlBGWC1RWjY3LUMyMzUiLAogICAgICAiQmFzZVVERiI6ICJNR
  FdXLU5PWFMtMzNFTS1QVFhMLUpVQUItRVY1NS1VR0lPIiwKICAgICAgIk92ZXJ
  sYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjogewogICAgICAgICAgI
  mNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0ZSI6ICJ2Z0dqZ1NEbkl
  rYXZlNHNUNWJqYjRadmhVODRxNk9hSk44TTBLa2dYR3lndVZRb2JYTUwKICB3b
  Gx6SXpic01pNGs4dDVkYkhXeDdRcDAifX19fX0"]},
    "MeshUDF": "MDB2-7MDK-LXVK-UGT3-AWMP-C7BD-U65F",
    "ProfileMaster": {
      "KeySignature": {
        "UDF": "MDB2-7MDK-LXVK-UGT3-AWMP-C7BD-U65F",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "Qn4kl-aQpg90cK4FuTW4evSFfkm2A6qgEKVo5qCQzFx-yWoO9RuW
  jZDGChoBbbtr_iTKpN5wNKYA"}}},
      "OnlineSignatureKeys": [{
          "UDF": "MAMP-C77M-FH2P-2T6C-OKB2-UHC2-KPR5",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "AQdTpBV1r37Ro7ONpUwfi5e8ssoH4vghh4QD4R2pwjGhgUQIK4vO
  PtsuekTQYhwQ0uxQJebhWvwA"}}}],
      "KeyEncryption": {
        "UDF": "MC3B-KZ4A-XZFA-4IFD-ZA2H-ZY73-2QFN",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "_e97C89TvkNdSclJuWUk2po1E1Kl2vPI0EojKxGrfbQ1JHl9To-g
  I7X038Zc7ilkB7YjrQGPOOYA"}}}}}}
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

