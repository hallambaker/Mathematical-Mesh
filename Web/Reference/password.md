

# password

````
password    Manage password catalogs connected to an account
    add   Add password entry
    delete   Delete password entry
    get   Lookup password entry
    list   List password entries
````


# password add

````
add   Add password entry
       <Unspecified>
       <Unspecified>
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>password add ftp.example.com alice1 password
{Username}@{Service} = [{Password}]````

Specifying the /json option returns a result of type ResultEntry:

````
>password add ftp.example.com alice1 password /json
{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "Service": "ftp.example.com",
      "Username": "alice1",
      "Password": "password"}}}
````

# password get

````
get   Lookup password entry
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>password delete www.example.com
OK
````

Specifying the /json option returns a result of type Result:

````
>password delete www.example.com /json
{
  "Result": {
    "Success": true}}
````

# password delete

````
delete   Delete password entry
       Domain name of Web site
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

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

# password list

````
list   List password entries
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>password list
OK
{Username}@{Service} = [{Password}]
{Username}@{Service} = [{Password}]
````

Specifying the /json option returns a result of type ResultDump:

````
>password list /json
{
  "ResultDump": {
    "Success": true,
    "CatalogEntries": [{
        "Service": "ftp.example.com",
        "Username": "alice1",
        "Password": "password"},
      {
        "Service": "www.example.com",
        "Username": "alice@example.com",
        "Password": "newpassword"}]}}
````


