

# account

~~~~
<div="helptext">
<over>
account    Account creation and management commands.
    connect   Connect by means of a connection uri
    create   Create new account profile
    delete   Delete an account profile
    escrow   Create a set of key escrow shares
    export   Export the specified profile data to the specified file
    get   Describe the specified profile
    hello   Connect to the service(s) a profile is connected to and report status.
    import   Import the specified profile data to the specified file
    list   List all profiles on the local machine
    pin   Get a pin value to pre-authorize a connection
    publish   Create a new device profile and register the corresponding URI.
    purge   Purge the Mesh recovery key from this device
    recover   Recover escrowed profile
    status   Return the status of the account catalogs and spools
    sync   Synchronize local copies of Mesh profiles with the server
<over>
</div>
~~~~


# account connect

~~~~
<div="helptext">
<over>
connect   Connect by means of a connection uri
       The device location URI
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /auth   (De)Authorize the specified function on the device
    /root   Device as super administration device
    /admin   Device as administration device
    /message   Authorize rights for Mesh messaging
    /web   Authorize rights for Mesh messaging and Web.
    /device   Device restrictive access
    /ssh   Authorize rights for specified SSH account
    /email   Authorize rights for specified smtp email account
    /member   Authorize member rights for specified Mesh group
    /group   Authorize group administrator rights for specified Mesh group
<over>
</div>
~~~~

The `account connect` command 


# account create

~~~~
<div="helptext">
<over>
create   Create new account profile
       New account
    /localname   Account friendly name
    /new   Force creation of new device profile
    /dudf   Device profile fingerprint
    /did   Device identifier
    /dd   Device description
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /alg   List of algorithm specifiers
<over>
</div>
~~~~

The `account create` command

# account escrow

~~~~
<div="helptext">
<over>
escrow   Create a set of key escrow shares
    /alg   List of algorithm specifiers
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /quorum   <Unspecified>
    /shares   <Unspecified>
<over>
</div>
~~~~

The `account escrow` command

# account get

~~~~
<div="helptext">
<over>
get   Describe the specified profile
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `account get` command

# account export

~~~~
<div="helptext">
<over>
export   Export the specified profile data to the specified file
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `account export` command


# account hello

~~~~
<div="helptext">
<over>
hello   Connect to the service(s) a profile is connected to and report status.
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
<over>
</div>
~~~~

The `account hello` command attempts to contact a Mesh service and reports the
service configuration if successful.


~~~~
<div="terminal">
<cmd>Alice> account hello alice@example.com
<rsp>MeshService 3.0
   Service UDF = MAC2-XY6M-MEV2-QFIM-43XQ-5M3B-NZSE
   Host UDF = MDPW-XI3O-2MLR-PY3P-4XHC-4INW-6AW4
</div>
~~~~

Specifying the /json option returns a result of type ResultHello:

~~~~
<div="terminal">
<cmd>Alice> account hello alice@example.com /json
<rsp>{
  "ResultHello": {
    "Success": true,
    "Response": {
      "Status": 201,
      "Version": {
        "Major": 3,
        "Minor": 0,
        "Encodings": [{
            "ID": ["application/json"]}]},
      "EnvelopedProfileService": [{
          "EnvelopeID": "MAC2-XY6M-MEV2-QFIM-43XQ-5M3B-NZSE",
          "dig": "S512",
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQUMyLVhZNk0tTUVWMi1
  RRklNLTQzWFEtNU0zQi1OWlNFIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiA
  gIkNyZWF0ZWQiOiAiMjAyMC0xMC0yM1QxNToxODo1MFoifQ"},
        "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9
  maWxlU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1BQzItWFk2TS1NRVYyL
  VFGSU0tNDNYUS01TTNCLU5aU0UiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI
  6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiO
  iAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJsRDlHV2FfcGthSlVZdnE
  2eVh6dkQ0QjVDemRHdUlyMUVsaEVZb29JRngxTmNrRkhQSENCCiAgYUQtR0FmV
  nRNMzBOa0xGcmxKOHlJd3lBIn19fSwKICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI
  6IHsKICAgICAgIlVkZiI6ICJNQVVDLTJCWEktM1RCWS1KSTVTLUNTVUItQVlLQ
  S1YTEpXIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgI
  CAgICAgIlB1YmxpYyI6ICJEbmtQOTIyQXFNMUNoTDB3dllYRThfRWJ4MWY3S3p
  fMVZVZjRLOU9sdm85TlNZRTVWeDNPCiAgRHRHVGdoZlpMVVVJWWdUcmZCemlQb
  mtBIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MAC2-XY6M-MEV2-QFIM-43XQ-5M3B-NZSE",
              "signature": "PIw5vNBEjdz2nvKRZAaS94ybVav4UigBj-3DC8bxmJCl6DNYf
  xPoHmaHyEVa8HXldfzbE3db-nCA2xtFNH4MzKTeiCHNHbCjqpSj3mP-F_3BzTN
  3xMVFssfJQm31r-apkOBp7_RhC741GGd0ALdgqhIA"}],
          "PayloadDigest": "YaoJ_dhwHQr42DPxgu_NbliMHf9U6BF_bcKIDRYtWZeMk
  X39qyTGm_tKMo6A1QNdcaMSLKjQfslaTzGTGtT5rQ"}],
      "EnvelopedProfileHost": [{
          "EnvelopeID": "MDPW-XI3O-2MLR-PY3P-4XHC-4INW-6AW4",
          "dig": "S512",
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNRFBXLVhJM08tMk1MUi1
  QWTNQLTRYSEMtNElOVy02QVc0IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Uhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0xMC0yM1QxNToxODo1MFoifQ"},
        "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1EUFctWEkzTy0yTUxSLVBZM
  1AtNFhIQy00SU5XLTZBVzQiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJjQnBRbHVoREZnUVlRdkxZZEt
  zUHVaMERqSU9IbURqM0FCem5HMktRc3R0clZWemtYd3cxCiAgSGZZcEp5UERVc
  mFuRDlLN0luaEZDeC1BIn19fSwKICAgICJLZXlBdXRoZW50aWNhdGlvbiI6IHs
  KICAgICAgIlVkZiI6ICJNRFpJLU9WQVYtV0NYSS1XUzdWLVNUVUEtNURVWi1CW
  UxSIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymx
  pY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICIzLVBvRGtaYWpuV1k0am9rREF3am5sSkV5ZjZMUWpfelR
  0bWluX0lwZTNqRW82b1BRUWxnCiAgM0FFdEhFUXJtZzlmRXQzSV8xQUxYa29BI
  n19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MDPW-XI3O-2MLR-PY3P-4XHC-4INW-6AW4",
              "signature": "Wmawa__VRC0lvrhsql_ESAJHQKM4Yk7DprGrADCikEsLRctIS
  e9Ufb9JXjBgmKYm0WYM_c7mczqAuy9du_wOMU3gfck6INJ2Oki3xIJ3QY7R7tA
  _6m1Sy8-jJcujzvTmN8xDfUhpVzINP8zZhv4G5TcA"}],
          "PayloadDigest": "jq_8Ej1Gar9Y3JLSTe6sbrAr53ukWPpahjzU5c-ZbssiA
  1mB0lvDukW6OcdTbm_LCZkLWctwXHcdIDJ8Wh-w_w"}]}}}
</div>
~~~~


# account import

~~~~
<div="helptext">
<over>
import   Import the specified profile data to the specified file
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `account import` command

# account pin

~~~~
<div="helptext">
<over>
pin   Get a pin value to pre-authorize a connection
    /length   Length of PIN to generate (default is 8 characters)
    /expire   <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `account pin` command generates and registers a new PIN code that may be used
to authenticate a device connection request.

The `/length` option specifies the length of the generated PIN in (significant)
characters.

The '/expire' option specifies an expiry time for the request as an integer 
followed by the letter m, h or d for minutes, hours and days respectively.


~~~~
<div="terminal">
<cmd>Alice> account pin
<rsp>PIN=ACST-XYBV-X2WN-ZPJA-T54M-A42R-M36O (Expires=2020-10-24T15:18:55Z)
</div>
~~~~

Specifying the /json option returns a result of type ResultPIN:

~~~~
<div="terminal">
<cmd>Alice> account pin /json
<rsp>{
  "ResultPIN": {
    "Success": true,
    "MessagePIN": {
      "MessageId": "AB6B-DX5A-JRID-JIQZ-4ZTM-GAYW-I2UO",
      "Account": "alice@example.com",
      "Expires": "2020-10-24T15:18:55Z",
      "Automatic": true,
      "SaltedPin": "ACST-XYBV-X2WN-ZPJA-T54M-A42R-M36O",
      "Action": "Device"}}}
</div>
~~~~



# account publish

~~~~
<div="helptext">
<over>
publish   Create a new device profile and register the corresponding URI.
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `account publish` command 


# account purge

~~~~
<div="helptext">
<over>
purge   Purge the Mesh recovery key from this device
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `account purge` command



# account status

~~~~
<div="helptext">
<over>
status   Return the status of the account catalogs and spools
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `account status` command 




# account sync

~~~~
<div="helptext">
<over>
sync   Synchronize local copies of Mesh profiles with the server
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /auto   <Unspecified>
<over>
</div>
~~~~

The `account sync` command 




