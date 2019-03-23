

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
        "UDF": "MDEH-FIHJ-BZCK-3UUB-EO2B-GUPM-64NV",
        "AuthUDF": "MBIS-J63X-ICPR-AJGL-7KTI-KXZ2-Z2BX",
        "ProfileMeshDevicePublicSigned": [{
            "dig": "S512",
            "cty": "application/mmm"},
          "ewogICJQcm9maWxlTWVzaERldmljZVB1YmxpYyI6IHsKICAgICJEZXZ
  pY2VQcm9maWxlIjogW3sKICAgICAgICAiZGlnIjogIlM1MTIiLAogICAgICAgI
  CJjdHkiOiAiYXBwbGljYXRpb24vbW1tIn0sCiAgICAgICJld29nSUNKUWNtOW1
  hV3hsUkdWMmFXTmxJam9nZXdvZ0lDQWdJa1JsZG1salpWTnBaMjVoZEhWCiAge
  VpVdGxlU0k2SUhzS0lDQWdJQ0FnSWxWRVJpSTZJQ0pOUkVWSUxVWkpTRW90UWx
  wRFN5MHpWVlZDTFVWUE0KICBrSXRSMVZRVFMwMk5FNVdJaXdLSUNBZ0lDQWdJb
  EIxWW14cFkxQmhjbUZ0WlhSbGNuTWlPaUI3Q2lBZ0lDQQogIGdJQ0FnSWxCMVl
  teHBZMHRsZVVWRFJFZ2lPaUI3Q2lBZ0lDQWdJQ0FnSUNBaVkzSjJJam9nSWtWa
  05EUTRJCiAgaXdLSUNBZ0lDQWdJQ0FnSUNKUWRXSnNhV01pT2lBaVNIbHpkRzV
  GV205SFRrSmxOVTFKWDBSV2N6bDBiV2wKICBZYm5GaU5tOWZNSHBPVDFNelMyN
  WpUa3RtTkdSSmFtMVFZa1EzUmdvZ0lFZGtXbUUwTjFkWWIxZGphazlMWQogIHk
  xbVJtTTBiM3B0UVNKOWZYMHNDaUFnSUNBaVJHVjJhV05sUVhWMGFHVnVkR2xqW
  VhScGIyNUxaWGtpT2lCCiAgN0NpQWdJQ0FnSUNKVlJFWWlPaUFpVFVKSlV5MUt
  Oak5ZTFVsRFVGSXRRVXBIVEMwM1MxUkpMVXRZV2pJdFcKICBqSkNXQ0lzQ2lBZ
  0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam9nZXdvZ0lDQWdJQ0FnSUN
  KUWRXSgogIHNhV05MWlhsRlEwUklJam9nZXdvZ0lDQWdJQ0FnSUNBZ0ltTnlka
  Uk2SUNKRlpEUTBPQ0lzQ2lBZ0lDQWdJCiAgQ0FnSUNBaVVIVmliR2xqSWpvZ0l
  uWlBUekpSTlhWQlRsZEtPRXc0YlVGU2RIVmZPVzEyUTJoWVNrUjZPRlUKICA1Z
  ERNeE5uRkhjakZNTTFsVVRXSjNZMEZWUVVFS0lDQlFSVU5vZDJ0NFRsUjVTV04
  1Y0U1eFFrWlhSRFpFWgogIDBFaWZYMTlMQW9nSUNBZ0lrUmxkbWxqWlVWdVkzS
  jVjSFJwYjI1TFpYa2lPaUI3Q2lBZ0lDQWdJQ0pWUkVZCiAgaU9pQWlUVUZQUnk
  wME0xUlBMVFpTU2tZdFMxbFpNeTFPUzFCVExVSllORll0VFV4SVRpSXNDaUFnS
  UNBZ0kKICBDSlFkV0pzYVdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWd
  JQ0pRZFdKc2FXTkxaWGxGUTBSSUlqbwogIGdld29nSUNBZ0lDQWdJQ0FnSW1Oe
  WRpSTZJQ0pGWkRRME9DSXNDaUFnSUNBZ0lDQWdJQ0FpVUhWaWJHbGpJCiAgam9
  nSWtaR2VIYzBjbU5QZVdobU1WaHZNSFF3UlVWMWFGOVZibGswZW1wbUxWRkJUS
  EV4WDBzeVUyTmtTVWQKICBKWkdRd0xXUlpjazhLSUNCMVdXaEtZM0ZWUTA5Qk5
  FMUlhM1JuUmxsM1JFWmtlVUVpZlgxOWZYMCIsCiAgICAgIHsKICAgICAgICAic
  2lnbmF0dXJlcyI6IFt7CiAgICAgICAgICAgICJzaWduYXR1cmUiOiAiNndSRzd
  nNWpnalpqalZzWXJaeHNiTTN4TDBmZnFMOUd3Z2tfYWxUbXhyRm9KTlU4YwogI
  E56OXhISlNrNXc4MG5zcmVyQ0EwdnNJX1dDQVBxTVhSX2x2aHVHSU5iOXlyeWR
  3Q2JxbXJBSzZfSDVtVzZ4CiAgblc2V3ZiejNTb1ZQa2pacEVLZzBMd2RpQ1BPY
  jVJbUk5MWk0YmlEd0EifV0sCiAgICAgICAgIlBheWxvYWREaWdlc3QiOiAiNEV
  5U2EzUU9xcll5dzJSclVIMW5HcVEzY19UZFhtQVpDaEJzbGRHRTlIYVRTCiAgM
  2pQN2NJakowRktDcnREeThVZ3R6Y29QWHJWcW1NVEluVnNYU2NCUFEifV19fQ",
          {
            "signatures": [{
                "signature": "gmmxkRqHHsa04sSk49O7trCFb9GhAxllMgHAv5E_tv6A2N6B-
  0Fi3vEtVCZfWdau8f4FrXt4J34ACI7HVuQr16q_Mz09dsvoqOOWkF-3mg2m74T
  ieoKSFfUTGPYSMCSCfbacslbFpCrcGckNMR5u2hMA"}],
            "PayloadDigest": "l1aHdOu8539Dq1Iy2Q36LbECUD2_4x27UkIGiYjbRUZU2
  hqTgKEpKTjn-WhE8X913oBvlEvJEb4aoe0PZXilIw"}],
        "ProfileMeshDevicePrivateEncrypted": [{
            "dig": "S512",
            "cty": "application/mmm"},
          "ewogICJQcm9maWxlTWVzaERldmljZVByaXZhdGUiOiB7fX0",
          {
            "signatures": [{
                "signature": "XVdignFqmkM1G6rzuX4tS-PKoU30Loi4O1sGUFgwhiRwl59EH
  13zlcRPAjZmkhU3TWd5u-9w7_GAtiEIEB7Y3E2I3F59BqNU0_C89DOHqwGq9lF
  -eI6u4yN6_ol-fYTcmTeMwtw5SfEZWJ_2eUia2AsA"}],
            "PayloadDigest": "9uMmPvU2q9Q9X-qfstxL5K9EuN4SLO1CKpVK2-gNvxIYX
  uR2M1pOqP6_AkN6cm1OaZ-dllWlxVuS5KXvFann_A"}]}],
    "Profiles": [{
        "ProfileDevice": {
          "DeviceSignatureKey": {
            "UDF": "MDEH-FIHJ-BZCK-3UUB-EO2B-GUPM-64NV",
            "PublicParameters": {
              "PublicKeyECDH": {
                "crv": "Ed448",
                "Public": "HystnEZoGNBe5MI_DVs9tmiXnqb6o_0zNOS3KncNKf4dIjmPbD7F
  GdZa47WXoWcjOKc-fFc4ozmA"}}},
          "DeviceAuthenticationKey": {
            "UDF": "MBIS-J63X-ICPR-AJGL-7KTI-KXZ2-Z2BX",
            "PublicParameters": {
              "PublicKeyECDH": {
                "crv": "Ed448",
                "Public": "vOO2Q5uANWJ8L8mARtu_9mvChXJDz8U9t316qGr1L3YTMbwcAUAA
  PEChwkxNTyIcypNqBFWD6DgA"}}},
          "DeviceEncryptionKey": {
            "UDF": "MAOG-43TO-6RJF-KYY3-NKPS-BX4V-MLHN",
            "PublicParameters": {
              "PublicKeyECDH": {
                "crv": "Ed448",
                "Public": "FFxw4rcOyhf1Xo0t0EEuh_UnY4zjf-QALq1_K2ScdIGIdd0-dYrO
  uYhJcqUCOA4MHktgFYwDFdyA"}}}}},
      {
        "ProfileMesh": {
          "Account": "alice@example.com",
          "MasterProfile": [{
              "dig": "S512",
              "cty": "application/mmm"},
            "ewogICJQcm9maWxlTWFzdGVyIjogewogICAgIk1hc3RlclNpZ25hdHV
  yZUtleSI6IHsKICAgICAgIlVERiI6ICJNREhPLVdISDctNFJaQy1EVTZTLTVGT
  EEtNkNJVy1FSks2IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICA
  gICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4I
  iwKICAgICAgICAgICJQdWJsaWMiOiAiUnJfVFVqMWZaalRzZEE5UUFhaGprWnl
  fRUF6NnFmTElHNFVsTGNsZlYxS2x2V3Z4WnozSQogIDhndFhFWUVjNGpyaTl3d
  zlZN3J0RGw4QSJ9fX0sCiAgICAiTWFzdGVyRXNjcm93S2V5cyI6IFt7CiAgICA
  gICAgIlVERiI6ICJNRFA1LUZLMkwtVVpFRy1ZMkIyLTJMRVAtQ1Y0Ry01UlJPI
  iwKICAgICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAgICJQdWJ
  saWNLZXlFQ0RIIjogewogICAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgI
  CAgICAgICAgIlB1YmxpYyI6ICJrWEpUUW1VRWs5Y1BXQlUxeWxDSnVkbVZIU0x
  4aGg3clhGVkdWc2Q3dW9xbnBaZjhyM2Q1CiAgWlhjX0U5S01VdWZOQjVPN3VlV
  l81bldBIn19fV0sCiAgICAiT25saW5lU2lnbmF0dXJlS2V5cyI6IFt7CiAgICA
  gICAgIlVERiI6ICJNREVILUZJSEotQlpDSy0zVVVCLUVPMkItR1VQTS02NE5WI
  iwKICAgICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAgICJQdWJ
  saWNLZXlFQ0RIIjogewogICAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgI
  CAgICAgICAgIlB1YmxpYyI6ICJIeXN0bkVab0dOQmU1TUlfRFZzOXRtaVhucWI
  2b18wek5PUzNLbmNOS2Y0ZElqbVBiRDdGCiAgR2RaYTQ3V1hvV2NqT0tjLWZGY
  zRvem1BIn19fV19fQ",
            {
              "signatures": [{
                  "signature": "EnouOWrfq0ix8Wx9WNjHOw-JoFxPpVqk480FKtkRXIOgOCybP
  YbuGPwG0zmw3NMqiF7zVZti--6AwqJQ9-HDlLPYS0_VhnqbPMd1bOcc9jP87OF
  cJmNlBmc5cDJwm4fOIEwDhZdL3h_PQJB0WWH9GDIA"}],
              "PayloadDigest": "TAottRskwnM551S_VUdW6FzfOIb1oTAqpGgy6Lmd5uxXk
  wPz485Lq0GDo8b55658OUGurge_u0yGptjOIhw35g"}],
          "AccountEncryptionKey": {
            "UDF": "MCZO-INHR-BQGK-2TLM-3O5I-S3DX-RQWB",
            "PublicParameters": {
              "PublicKeyECDH": {
                "crv": "Ed448",
                "Public": "-NyQECQmGn-UFrMHb-yhJe801o3t6SwymmGTDHahRiX_l7VlnAa-
  POPReUALw8QnLnSQ19g5myOA"}}}}}]}}
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


