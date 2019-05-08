

# profile

````
profile    Manage personal and device profiles and accounts.
    create   Create new personal profile
    escrow   Create a set of key escrow shares
    export   Export the specified profile data to the specified file
    get   Describe the specified profile
    hello   Connect to the service(s) a profile is connected to and report status.
    import   Import the specified profile data to the specified file
    list   List all profiles on the local machine
    recover   Recover escrowed profile
    register   Register existing profile at a new portal
    sync   Synchronize local copies of Mesh profiles with the server
````

# profile create

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
>profile create
Device Profile UDF=MANG-XLXR-5S7L-HE4B-2DPE-A456-SVOZ
Personal Profile UDF=MCY7-VGVV-K2ZZ-KQWB-566D-F4PD-WKR3
````

Specifying the /json option returns a result of type ResultMasterCreate:

````
>profile create /json
{
  "ResultMasterCreate": {
    "Success": true,
    "DeviceUDF": "MANG-XLXR-5S7L-HE4B-2DPE-A456-SVOZ",
    "Default": false,
    "ProfileDevice": {
      "SignatureKey": {
        "UDF": "MANG-XLXR-5S7L-HE4B-2DPE-A456-SVOZ",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "COBxwRGnvZy-7jtFzEymBgYX7HBt761Y7mh3gS9hhgPHe5QXvP-c
  wuJqlFMTy5y2z1HSJ2jRIZIA"}}},
      "DeviceAuthenticationKey": {
        "UDF": "MBQL-TIJ4-VGIQ-HWOC-BUW4-Z7OM-7MUD",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "IcOKfGvTfsmWmYW6c7VHAjW8Yr-5ke4Kg50zDdEbJnYJ4x46trxP
  qF0_bo_1g7NQSpWGgRyFAm8A"}}},
      "DeviceEncryptionKey": {
        "UDF": "MBFV-YD5F-YVJG-JW5O-EN6J-6JMN-O7HU",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "ObZLYX-b-1JkuiUwol5008rKxQk3h4ZcwEWIF4CcsErcwbxCyKy8
  JxQJtwxtbbMfwUQ3RIN2ZKgA"}}}},
    "PersonalUDF": "MCY7-VGVV-K2ZZ-KQWB-566D-F4PD-WKR3",
    "ProfileMaster": {
      "SignatureKey": {
        "UDF": "MCY7-VGVV-K2ZZ-KQWB-566D-F4PD-WKR3",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "5x9S45JPzgthCiiLd57_P7TrF-HUoB_mZY1qMzeCT1H-JvmLP5uj
  w6weOYfsG7oWmTPrQfW2b8gA"}}},
      "MasterEscrowKeys": [{
          "UDF": "MBXR-JBW7-RPW7-WLCF-OCYU-ZGY7-GZIU",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "0gtCBOvZqDYZDClAZqcJw8In5738KgHFQzEKe1t1fPMTFi-5H0uH
  _DV1YAPHbg72xlGpgo1o-VMA"}}}],
      "OnlineSignatureKeys": [{
          "UDF": "MANG-XLXR-5S7L-HE4B-2DPE-A456-SVOZ",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "COBxwRGnvZy-7jtFzEymBgYX7HBt761Y7mh3gS9hhgPHe5QXvP-c
  wuJqlFMTy5y2z1HSJ2jRIZIA"}}}]}}}
````


# profile escrow

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
Share: SAQB-IZK6-D7WF-2E7R-Z7AG-BXM6-LM37-U
Share: SAQ3-YWLV-GJHV-FGLB-R7GP-YT6G-FE4P-4
Share: SARG-ITMM-ISZE-QHWR-J7MZ-PQPN-6444-6
Written to MCY7-VGVV-K2ZZ-KQWB-566D-F4PD-WKR3.escrow
````

Specifying the /json option returns a result of type ResultEscrow:

````
>profile escrow /json
{
  "ResultEscrow": {
    "Success": true,
    "Filename": "MCY7-VGVV-K2ZZ-KQWB-566D-F4PD-WKR3.escrow",
    "Shares": ["SAQB-IZK6-D7WF-2E7R-Z7AG-BXM6-LM37-U",
      "SAQ3-YWLV-GJHV-FGLB-R7GP-YT6G-FE4P-4",
      "SARG-ITMM-ISZE-QHWR-J7MZ-PQPN-6444-6"]}}
````

# profile export

````
export   Export the specified profile data to the specified file
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile export` command 


````
>profile export profile.dare
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>profile export profile.dare /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# profile get

````
get   Describe the specified profile
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile get` command 


````
>profile get /mesh=alice@example.com
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>profile get /mesh=alice@example.com /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````


# profile hello

````
hello   Connect to the service(s) a profile is connected to and report status.
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
````

The `profile hello` command attempts to contact a Mesh service and reports the
service configuration if successful.


````
>profile hello alice@example.com
````

Specifying the /json option returns a result of type ResultHello:

````
>profile hello alice@example.com /json
{
  "ResultHello": {
    "Success": true,
    "Response": {
      "Version": {
        "Major": 0,
        "Minor": 8,
        "Encodings": [{
            "ID": ["application/json"]}]}}}}
````

# profile import

````
import   Import the specified profile data to the specified file
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile import` command 


````
>profile import profile.dare
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>profile import profile.dare /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# profile list

````
list   List all profiles on the local machine
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile list` command 


````
>profile list
````

Specifying the /json option returns a result of type ResultList:

````
>profile list /json
{
  "ResultList": {
    "Success": true,
    "CatalogEntryDevices": [],
    "Profiles": [{
        "ProfileDevice": {
          "SignatureKey": {
            "UDF": "MANG-XLXR-5S7L-HE4B-2DPE-A456-SVOZ",
            "PublicParameters": {
              "PublicKeyECDH": {
                "crv": "Ed448",
                "Public": "COBxwRGnvZy-7jtFzEymBgYX7HBt761Y7mh3gS9hhgPHe5QXvP-c
  wuJqlFMTy5y2z1HSJ2jRIZIA"}}},
          "DeviceAuthenticationKey": {
            "UDF": "MBQL-TIJ4-VGIQ-HWOC-BUW4-Z7OM-7MUD",
            "PublicParameters": {
              "PublicKeyECDH": {
                "crv": "Ed448",
                "Public": "IcOKfGvTfsmWmYW6c7VHAjW8Yr-5ke4Kg50zDdEbJnYJ4x46trxP
  qF0_bo_1g7NQSpWGgRyFAm8A"}}},
          "DeviceEncryptionKey": {
            "UDF": "MBFV-YD5F-YVJG-JW5O-EN6J-6JMN-O7HU",
            "PublicParameters": {
              "PublicKeyECDH": {
                "crv": "Ed448",
                "Public": "ObZLYX-b-1JkuiUwol5008rKxQk3h4ZcwEWIF4CcsErcwbxCyKy8
  JxQJtwxtbbMfwUQ3RIN2ZKgA"}}}}},
      {
        "AssertionAccount": {
          "Account": "alice@example.com",
          "MasterProfile": [{
              "dig": "S512",
              "cty": "application/mmm"},
            "ewogICJQcm9maWxlTWFzdGVyIjogewogICAgIlNpZ25hdHVyZUtleSI
  6IHsKICAgICAgIlVERiI6ICJNQ1k3LVZHVlYtSzJaWi1LUVdCLTU2NkQtRjRQR
  C1XS1IzIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgI
  CAgICAgICJQdWJsaWMiOiAiNXg5UzQ1SlB6Z3RoQ2lpTGQ1N19QN1RyRi1IVW9
  CX21aWTFxTXplQ1QxSC1Kdm1MUDV1agogIHc2d2VPWWZzRzdvV21UUHJRZlcyY
  jhnQSJ9fX0sCiAgICAiTWFzdGVyRXNjcm93S2V5cyI6IFt7CiAgICAgICAgIlV
  ERiI6ICJNQlhSLUpCVzctUlBXNy1XTENGLU9DWVUtWkdZNy1HWklVIiwKICAgI
  CAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAgICJQdWJsaWNLZXl
  FQ0RIIjogewogICAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgI
  CAgIlB1YmxpYyI6ICIwZ3RDQk92WnFEWVpEQ2xBWnFjSnc4SW41NzM4S2dIRlF
  6RUtlMXQxZlBNVEZpLTVIMHVICiAgX0RWMVlBUEhiZzcyeGxHcGdvMW8tVk1BI
  n19fV0sCiAgICAiT25saW5lU2lnbmF0dXJlS2V5cyI6IFt7CiAgICAgICAgIlV
  ERiI6ICJNQU5HLVhMWFItNVM3TC1IRTRCLTJEUEUtQTQ1Ni1TVk9aIiwKICAgI
  CAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAgICJQdWJsaWNLZXl
  FQ0RIIjogewogICAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgI
  CAgIlB1YmxpYyI6ICJDT0J4d1JHbnZaeS03anRGekV5bUJnWVg3SEJ0NzYxWTd
  taDNnUzloaGdQSGU1UVh2UC1jCiAgd3VKcWxGTVR5NXkyejFIU0oyalJJWklBI
  n19fV19fQ",
            {
              "signatures": [{
                  "signature": "5nqhBum6U61GUAvnqkJPlbrOpxD6zaqnUAWganch-PcQDDJcN
  8-IED5uZTYYZf6_bYcoaMEnhaUAktLGeHjzxw4YBIzYhb0guJzvA3Y-X2q4Flr
  -Wc0gm03oOvpM6NreUeNbR3T98NZMzIMWBukrOxUA"}],
              "PayloadDigest": "lHFrPTDwUlhb7GDbK--NFMkjsJn2sFdhPi00ma8iWjH9_
  Bi_WK5rvURKvdCpz4ZphoOKBxvVHRcNXlLcjI-htA"}],
          "AccountEncryptionKey": {
            "UDF": "MBB2-CYFL-MN22-PBBQ-ELY6-IZF2-PWOM",
            "PublicParameters": {
              "PublicKeyECDH": {
                "crv": "Ed448",
                "Public": "1a_Va_zp3K_pt084mRe9IfYRiCLs5FK7uyxUyJ8TQoMSGv5oB4XP
  sHO_fTl7xs6K7h-ymWdKs78A"}}}}}]}}
````


# profile recover

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


````
>profile recover $SAQB-IZK6-D7WF-2E7R-Z7AG-BXM6-LM37-U $SARG-ITMM-ISZE-QHWR-J7MZ-PQPN-6444-6 /verify
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>profile recover $SAQB-IZK6-D7WF-2E7R-Z7AG-BXM6-LM37-U $SARG-ITMM-ISZE-QHWR-J7MZ-PQPN-6444-6 /verify /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# profile register

````
register   Register existing profile at a new portal
       New account
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /mudf   Master profile fingerprint
    /new   Force creation of new device profile
    /dudf   Device profile fingerprint
    /did   Device identifier
    /dd   Device description
````

The `profile register` command 


````
>profile register alice@example.net
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>profile register alice@example.net /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# profile sync

````
sync   Synchronize local copies of Mesh profiles with the server
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `profile sync` command 


````
>profile sync
````

Specifying the /json option returns a result of type ResultSync:

````
>profile sync /json
{
  "ResultSync": {
    "Success": true}}
````













