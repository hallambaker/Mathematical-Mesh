

# ssh

````
ssh    Manage SSH profiles connected to a personal profile
    create   Generate a new SSH public keypair for the current machine and add to the personal profile
    private   Extract the private key for this device
    public   Extract the public key for this device
````


# ssh create

````
create   Generate a new SSH public keypair for the current machine and add to the personal profile
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
    /alg   List of algorithm specifiers
    /id   Key identifier
````

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

# ssh private

````
private   Extract the private key for this device
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /format   File format
    /password   Password to encrypt private key
    /file   Output file
````

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

# ssh public

````
public   Extract the public key for this device
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /format   File format
    /file   Output file
````

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

# ssh host

````
host   Add one or more hosts to the known_hosts file
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
````

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

# ssh host

````
host   Add one or more hosts to the known_hosts file
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
````

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

# ssh client

````
client   Add one or more keys to the authorized_keys file
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
````

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

# ssh host

````
host   List the known SSH sites (aka known hosts)
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
````

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

# ssh client

````
client   List the authorized device keys (aka authorized_keys)
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
````

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


