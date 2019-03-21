

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
>profile create  alice@example.com
OK
Device Profile UDF=MCTQ-RQNW-J342-WW6I-6N6T-WBPN-QJ34
````

Specifying the /json option returns a result of type ResultMasterCreate:

````
>profile create  alice@example.com /json
{
  "ResultMasterCreate": {
    "Success": true,
    "DeviceUDF": "MCTQ-RQNW-J342-WW6I-6N6T-WBPN-QJ34",
    "Default": false,
    "PersonalUDF": "MBL5-INB4-EBEO-RIIT-BTDU-HDVK-AFPM"}}
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
Share: SAQO-5TNL-RNYW-MBRW-NDKV-2FCA-7F2G-G
Share: SAQU-Z2LY-V3D7-RXCY-KBR4-RGNS-VCVB-Q
Share: SARK-WBKF-2IPI-XMT2-G7ZD-IHZE-K7QA-A
Written to MBL5-INB4-EBEO-RIIT-BTDU-HDVK-AFPM.escrow
````

Specifying the /json option returns a result of type ResultEscrow:

````
>profile escrow /json
{
  "ResultEscrow": {
    "Success": true,
    "Filename": "MBL5-INB4-EBEO-RIIT-BTDU-HDVK-AFPM.escrow",
    "Shares": ["SAQO-5TNL-RNYW-MBRW-NDKV-2FCA-7F2G-G",
      "SAQU-Z2LY-V3D7-RXCY-KBR4-RGNS-VCVB-Q",
      "SARK-WBKF-2IPI-XMT2-G7ZD-IHZE-K7QA-A"]}}
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
OK
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
OK
````

Specifying the /json option returns a result of type ResultList:

````
>profile list /json
{
  "ResultList": {
    "Success": true,
    "CatalogEntryDevices": [{
        "Account": "alice@example.com",
        "UDF": "MCTQ-RQNW-J342-WW6I-6N6T-WBPN-QJ34",
        "AuthUDF": "MCUV-GGAM-3YUB-2UWF-LXNL-WNBV-R7HI",
        "ProfileMeshDevicePublicSigned": [{
            "dig": "S512",
            "cty": "application/mmm"},
          "ewogICJQcm9maWxlTWVzaERldmljZVB1YmxpYyI6IHsKICAgICJEZXZpY2VQcm9maWxlIjogW3sKICAgICAgICAiZGlnIjogIlM1MTIiLAogICAgICAgICJjdHkiOiAiYXBwbGljYXRpb24vbW1tIn0sCiAgICAgICJld29nSUNKUWNtOW1hV3hsUkdWMmFXTmxJam9nZXdvZ0lDQWdJa1JsZG1salpWTnBaMjVoZEhWeVpVdGxlU0k2SUhzS0lDQWdJQ0FnSWxWRVJpSTZJQ0pOUTFSUkxWSlJUbGN0U2pNME1pMVhWelpKTFRaT05sUXRWMEpRVGkxUlNqTTBJaXdLSUNBZ0lDQWdJbEIxWW14cFkxQmhjbUZ0WlhSbGNuTWlPaUI3Q2lBZ0lDQWdJQ0FnSWxCMVlteHBZMHRsZVVWRFJFZ2lPaUI3Q2lBZ0lDQWdJQ0FnSUNBaVkzSjJJam9nSWtWa05EUTRJaXdLSUNBZ0lDQWdJQ0FnSUNKUWRXSnNhV01pT2lBaVlqVjJiMkZKZGsxWmVFUmlZV2xGVkhOalZrNU5ObTlWVVROcFoyNTBkV1oyZWpCSVVqQXlkVFZhTFMxa09WVm5USEZWWkRac1JtcERiblV4TmxoWk5tWlNhV3BsZEhoVVMyRmpRU0o5Zlgwc0NpQWdJQ0FpUkdWMmFXTmxRWFYwYUdWdWRHbGpZWFJwYjI1TFpYa2lPaUI3Q2lBZ0lDQWdJQ0pWUkVZaU9pQWlUVU5WVmkxSFIwRk5MVE5aVlVJdE1sVlhSaTFNV0U1TUxWZE9RbFl0VWpkSVNTSXNDaUFnSUNBZ0lDSlFkV0pzYVdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGxGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pGWkRRME9DSXNDaUFnSUNBZ0lDQWdJQ0FpVUhWaWJHbGpJam9nSW14WVdUZHZUMlZ3UjNVNFdETnVZakExUWpGRmMyTlhaSFZLUW5vMFNYZzBRM2h2UzB0Q00yeHNNVkF4ZHpsbVRqbDFXamQwT1VkeFZYRmlSM0ZvUVdOdlJEZGZUM2RKY2kxU1RVRWlmWDE5TEFvZ0lDQWdJa1JsZG1salpVVnVZM0o1Y0hScGIyNUxaWGtpT2lCN0NpQWdJQ0FnSUNKVlJFWWlPaUFpVFVSUVVDMUVTMFUwTFRkUVZGUXRXRTVOUWkxS1JWWkhMVE5TVkVndE0xVkdTeUlzQ2lBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam9nZXdvZ0lDQWdJQ0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0FnSUNBZ0ltTnlkaUk2SUNKRlpEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmliR2xqSWpvZ0lrTjRZVzFMT0VWaVZVSmhhMUpQVms1bGNXTmpXVmg0VUdzeFdsTkVjbFZFY2s4MWJuRllXbmxYYm1WcWVGTjVYMlJCWm5kaVNtRkhabGh3YUhrM09HNUxNVzgxZUdWVWRXMXVUVUVpZlgxOWZYMCIsCiAgICAgIHsKICAgICAgICAic2lnbmF0dXJlcyI6IFt7CiAgICAgICAgICAgICJzaWduYXR1cmUiOiAic0RjOEk3dkhkY1A3T0JKcVdDRmpPLVFCUFJHT3hlZklVeW9JSS1ad1ZZUThTRkZvdy1TU2lWTllmc3lvbnA0QXZXcDNMRDFpRFR5QXJNY05RX0JneEFMVmQ2b3d4UTRDdzgzVHVHTjEzdFpSSGtfa2Zub0NhWFg3MFozMVU5SFJHVjNEQUszc0JHZS1HaDcxVWdMaVN3WUEifV0sCiAgICAgICAgIlBheWxvYWREaWdlc3QiOiAibkRTdVVzNzVWdjFzUXU3cng2UFk5WF9wME45XzF5ME1lekN3a2xKQWY1R0hFVmlkcFhMQ0RPaDMtSFBxZ043U1pGa2paOElycG8xMUZpTkpPU2V5bFEifV19fQ",
          {
            "signatures": [{
                "signature": "jx7i9TOSn6DC-xv386ufQM5WmGh7O7kgsk57TEZmlWSbgAmSRXXd0PZm2571RoQ7-ZMdWS4vTtwAg4Efv3Te_oF67bdOE8haxfukC4hB39tJXDDDKDQDDqKGkh5XAJa8V-mWdYbg5hhklaQcGORuZCcA"}],
            "PayloadDigest": "LJvg0eEYswMQJ-g0gTKUfu6dWJV4NSUKud8lypNhmVERqjDwLB5yBhao2EHPH_dy2UgG7_kcJwkFWpWl5qPZOQ"}],
        "ProfileMeshDevicePrivateEncrypted": [{
            "dig": "S512",
            "cty": "application/mmm"},
          "ewogICJQcm9maWxlTWVzaERldmljZVByaXZhdGUiOiB7fX0",
          {
            "signatures": [{
                "signature": "h7CSR7UKGcToptnC3uwQ6LHi5vb_ZCU3MRp5Z8WFBy9EhrJqNqHwfm4u6Se2_SB9e_uY844LRV0A6TJFg-mT6oqFxtPvam53kYjXOYt_oy1kv48yJci8B_vvYnd33ZV169wouu9gqbvzULuqMLWSpygA"}],
            "PayloadDigest": "9uMmPvU2q9Q9X-qfstxL5K9EuN4SLO1CKpVK2-gNvxIYXuR2M1pOqP6_AkN6cm1OaZ-dllWlxVuS5KXvFann_A"}]}],
    "Profiles": [{
        "ProfileDevice": {
          "DeviceSignatureKey": {
            "UDF": "MCTQ-RQNW-J342-WW6I-6N6T-WBPN-QJ34",
            "PublicParameters": {
              "PublicKeyECDH": {
                "crv": "Ed448",
                "Public": "b5voaIvMYxDbaiETscVNM6oUQ3igntufvz0HR02u5Z--d9UgLqUd6lFjCnu16XY6fRijetxTKacA"}}},
          "DeviceAuthenticationKey": {
            "UDF": "MCUV-GGAM-3YUB-2UWF-LXNL-WNBV-R7HI",
            "PublicParameters": {
              "PublicKeyECDH": {
                "crv": "Ed448",
                "Public": "lXY7oOepGu8X3nb05B1EscWduJBz4Ix4CxoKKB3ll1P1w9fN9uZ7t9GqUqbGqhAcoD7_OwIr-RMA"}}},
          "DeviceEncryptionKey": {
            "UDF": "MDPP-DKE4-7PTT-XNMB-JEVG-3RTH-3UFK",
            "PublicParameters": {
              "PublicKeyECDH": {
                "crv": "Ed448",
                "Public": "CxamK8EbUBakROVNeqccYXxPk1ZSDrUDrO5nqXZyWnejxSy_dAfwbJaGfXphy78nK1o5xeTumnMA"}}}}},
      {
        "ProfileMesh": {
          "Account": "alice@example.com",
          "MasterProfile": [{
              "dig": "S512",
              "cty": "application/mmm"},
            "ewogICJQcm9maWxlTWFzdGVyIjogewogICAgIk1hc3RlclNpZ25hdHVyZUtleSI6IHsKICAgICAgIlVERiI6ICJNQkw1LUlOQjQtRUJFTy1SSUlULUJURFUtSERWSy1BRlBNIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAibWZkVmpaQzc5QVpaTU9jT2dnQnY0YUVHUVBXVENjQ0ZwT0IwU3o5UWxZcGRjeDdPZk9CME91am5EM2pyOVJoRWZabndqalFTQnVhQSJ9fX0sCiAgICAiTWFzdGVyRXNjcm93S2V5cyI6IFt7CiAgICAgICAgIlVERiI6ICJNQ0xMLUNIWFktS0E3WC1IN1AzLUNSQzQtREdQVi0yUVJMIiwKICAgICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICAgIlB1YmxpYyI6ICI2OW5UaHMyaGctR3NfU3lwX2VDUGhDMXl5OU8xU1pWRVg2dkE5QjQ3MXNvbzZMU2xHdWFFcUNvVUliVHBDUWE3NEhoc3VyemtvcFdBIn19fV0sCiAgICAiT25saW5lU2lnbmF0dXJlS2V5cyI6IFt7CiAgICAgICAgIlVERiI6ICJNQ1RRLVJRTlctSjM0Mi1XVzZJLTZONlQtV0JQTi1RSjM0IiwKICAgICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICAgIlB1YmxpYyI6ICJiNXZvYUl2TVl4RGJhaUVUc2NWTk02b1VRM2lnbnR1ZnZ6MEhSMDJ1NVotLWQ5VWdMcVVkNmxGakNudTE2WFk2ZlJpamV0eFRLYWNBIn19fV19fQ",
            {
              "signatures": [{
                  "signature": "2hgFrsXqH28JZFMEz2gEQIZwRqBcXeqjoyBxVM68Dpmjr98oDUZebi0nABt9jdm5YKn0g_0RRXAAfGVxpXCOHqM5ad1alarhYti-M_YUoMl4xCEBpPUxyL3rcpbKYUwa7znnST6I6j-IQTTp1heiSjIA"}],
              "PayloadDigest": "8BVgJphyaS2emlHIGMPG_ziFoGwaV2ddMaU7FvAE5zy5MaXmJ-0SeN00TU9DVQepsjcZmYnD8NQ58sOQcJZlIg"}],
          "AccountEncryptionKey": {
            "UDF": "MBJE-C7GK-YXLE-ITG6-4OFY-UH33-MUOE",
            "PublicParameters": {
              "PublicKeyECDH": {
                "crv": "Ed448",
                "Public": "LFcbfJqGhPcJVLRuzY9Eq8EBUdsWUz_A29zL2M5OzrRldF8aOkDEbn40rUMSFO-Jfe-GQCvF7raA"}}}}}]}}
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
>profile recover $SAQO-5TNL-RNYW-MBRW-NDKV-2FCA-7F2G-G $SARK-WBKF-2IPI-XMT2-G7ZD-IHZE-K7QA-A /verify
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>profile recover $SAQO-5TNL-RNYW-MBRW-NDKV-2FCA-7F2G-G $SARK-WBKF-2IPI-XMT2-G7ZD-IHZE-K7QA-A /verify /json
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
````

The `profile register` command 


````
>profile register alice@example.net
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>profile register alice@example.net /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
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
OK
````

Specifying the /json option returns a result of type ResultSync:

````
>profile sync /json
{
  "ResultSync": {
    "Success": true}}
````













