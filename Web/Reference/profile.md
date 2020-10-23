

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
   Service UDF = MCQN-XSQB-BFSH-DUIO-75QR-OO6H-VQDU
   Host UDF = MBYN-LOYK-3DRV-PNZA-ZOCT-5GHE-4L4Z
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
          "EnvelopeID": "MCQN-XSQB-BFSH-DUIO-75QR-OO6H-VQDU",
          "dig": "S512",
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQ1FOLVhTUUItQkZTSC1
  EVUlPLTc1UVItT082SC1WUURVIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiA
  gIkNyZWF0ZWQiOiAiMjAyMC0xMC0yMVQxNDoyODoyOVoifQ"},
        "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9
  maWxlU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DUU4tWFNRQi1CRlNIL
  URVSU8tNzVRUi1PTzZILVZRRFUiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI
  6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiO
  iAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJ3VTBWZzVaM2pLNUFpTDV
  McTdZaDF6Qm1MX3BaYng3dHFLUnlldG1zczNUemIxV0ZHYzd4CiAgbC1KNDFtV
  25TWVJyanBVY1FObXNwd1lBIn19fSwKICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI
  6IHsKICAgICAgIlVkZiI6ICJNRElPLTVSRzItNVJRSy1PVUhZLVRVWTYtR080T
  C1USFRFIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgI
  CAgICAgIlB1YmxpYyI6ICJqR185cWtSMWVXVGFlYmkxM1kwUnlKY2VudXhpR28
  wSm0zNVVNYzk5OWZEOXNsT1dHdVUwCiAgSXlXVzVjaDlQSkdjRkYzTnIzVUdNZ
  WVBIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MCQN-XSQB-BFSH-DUIO-75QR-OO6H-VQDU",
              "signature": "p54KOEWodlL-iyyBphontGqnMK7UuW8QXvEpL9g6tx31-g41K
  8tqtQKWUcS6W0o2K01XVL4OP3wAj1R9Bdl13FH85KbsMH4NgrELme-136pR05d
  CPyIP4Qt2DgqddZxK0uKGZQd84hwKazs-PdunhAoA"}],
          "PayloadDigest": "V35cql-rhpnJYHK3_U0uARPIKPVrnj4CVJLzodLUdTLTl
  0PAnhOerZ4vGZ4wE392JiaD_-_Fi3xUwejLHTNyvQ"}],
      "EnvelopedProfileHost": [{
          "EnvelopeID": "MBYN-LOYK-3DRV-PNZA-ZOCT-5GHE-4L4Z",
          "dig": "S512",
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQllOLUxPWUstM0RSVi1
  QTlpBLVpPQ1QtNUdIRS00TDRaIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Uhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0xMC0yMVQxNDoyODoyOVoifQ"},
        "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CWU4tTE9ZSy0zRFJWLVBOW
  kEtWk9DVC01R0hFLTRMNFoiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJmQXJjNTZ1WUhNcThUMk5pbDF
  TaG14c2hidjJwc25ndGhpY1pYYjVlelhHM2FEQlBPeWxpCiAgcUZOWGpNVW9aU
  3FoSk8zWXUxN202TXFBIn19fSwKICAgICJLZXlBdXRoZW50aWNhdGlvbiI6IHs
  KICAgICAgIlVkZiI6ICJNQkRNLUdVQ0ktTE5OSS1HRkpFLUNFV0YtRkRBSC0zW
  TM1IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymx
  pY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJsa1RyQzAtTjBaMVYyeFNFMHhlSWxQTWp0MnZxcXozZ19
  5Q2Rzd1hRcUd0eERCeFhzUzFLCiAgbk9xNkhxRmstblJ6Z2NPMVNpNVNwa1NBI
  n19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MBYN-LOYK-3DRV-PNZA-ZOCT-5GHE-4L4Z",
              "signature": "KGWOG_XWe4frUbzET9usnuTNCESL_ukbcdApZbrSoX9K4y9fZ
  Th75Z_sE4Mhr4JY3DoxPLaOOk4A-RRLcj6DE5Ugb7CtpLCmfik7aVEinH9M8d3
  Cdb6kW3HINfLoLtaWoKLI2bUu1NWqLvg2FBlpmA8A"}],
          "PayloadDigest": "qct-ZHCH9av8qRBsoTdimooS_V9-GCcaEGPqSg-B-mqp-
  douxcvFB0X2XupzwIvayYtxUezN0Y8mJ_iemOy5YQ"}]}}}
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
<rsp>PIN=ABZJ-RFSV-Y2C3-6RDI-5OCU-E47Q-QU4Y (Expires=2020-10-22T14:28:35Z)
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
      "MessageId": "ABEU-NVUM-MSYY-5VBY-STZG-RGKA-NAFW",
      "Account": "alice@example.com",
      "Expires": "2020-10-22T14:28:35Z",
      "Automatic": true,
      "SaltedPin": "ABZJ-RFSV-Y2C3-6RDI-5OCU-E47Q-QU4Y",
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




