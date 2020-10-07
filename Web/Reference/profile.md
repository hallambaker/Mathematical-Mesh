

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
   Service UDF = MDGZ-ESGM-MCSE-3BXY-B4ME-BOOX-FFYA
   Host UDF = MCWA-J6LU-5XPO-WRCA-6Z7E-CH6K-BYM7
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
          "EnvelopeID": "MDGZ-ESGM-MCSE-3BXY-B4ME-BOOX-FFYA",
          "dig": "S512",
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNREdaLUVTR00tTUNTRS0
  zQlhZLUI0TUUtQk9PWC1GRllBIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiA
  gIkNyZWF0ZWQiOiAiMjAyMC0wOS0yMlQxMzoxMjo1N1oifQ"},
        "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJPZmZ
  saW5lU2lnbmF0dXJlIjogewogICAgICAiVURGIjogIk1ER1otRVNHTS1NQ1NFL
  TNCWFktQjRNRS1CT09YLUZGWUEiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI
  6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiO
  iAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJNQ0kxWHNmZ0NMZi0teEp
  ubDlQZnpNVmlPNzlRYmFSMW1KYnRKNl8xQ0c0aFVGRF9OQUI0CiAgcWNvTVlFU
  VEyY0pCN3c5TkJ0Ym1tM0dBIn19fSwKICAgICJLZXlFbmNyeXB0aW9uIjogewo
  gICAgICAiVURGIjogIk1CSFItM0s1RS1VM0FYLUlUUEwtVENNUC1WVVBCLVRDW
  FkiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGl
  jS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgI
  CAiUHVibGljIjogIjVVWkdzcmZ1THlTQUVSX1VEb0JUT3N1aUQ4VmJUTUtMbk9
  MZmk0UXVMcjk0Wlh1dGxWeXUKICBYX3QxdjM1Vjk1TDJiV2NJZjNtOW5OYUEif
  X19fX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MDGZ-ESGM-MCSE-3BXY-B4ME-BOOX-FFYA",
              "signature": "0sBNsSpvT39eV3_WElcs_wTRVQyj8MTBE2B5SlqCHkBMq74M7
  Hj89OTB_OO1X_aFslBzeCyGrA4Ab6DipZuJ1H9gg0MdLpwjPKaHkQ9_EmpjBn7
  _TiuiLbUpLYDveTiUGQdsEkGwVYlr5vb4_R8GASMA"}],
          "PayloadDigest": "_H4qy5lt1j851SEfkWMeouHF-OjiM08E9yHlNbt7r8xmV
  5aUzPTmYEuwKlftD9LYF4_Rlf9RGjleX4jik1a68w"}],
      "EnvelopedProfileHost": [{
          "EnvelopeID": "MCWA-J6LU-5XPO-WRCA-6Z7E-CH6K-BYM7",
          "dig": "S512",
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQ1dBLUo2TFUtNVhQTy1
  XUkNBLTZaN0UtQ0g2Sy1CWU03IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Uhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0wOS0yMlQxMzoxMjo1N1oifQ"},
        "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJPZmZsaW5
  lU2lnbmF0dXJlIjogewogICAgICAiVURGIjogIk1DV0EtSjZMVS01WFBPLVdSQ
  0EtNlo3RS1DSDZLLUJZTTciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICIxbklTNm96UklSQVh5V21fNkM
  4LXZMNEJFdXNfVGhqTWdtS0doZW90akZ4WUtBcGxSRVY5CiAgVTJLcktyNEM3V
  UYyVnE0UTQxbWt5VDhBIn19fSwKICAgICJLZXlBdXRoZW50aWNhdGlvbiI6IHs
  KICAgICAgIlVERiI6ICJNQlMyLUdZUzMtVkZTMi0zVktELUVGNUctTVRBVi1TQ
  1I2IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymx
  pY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJueldwWTFPeVA2eVBvV2hGMGp5V3pkTmRUNi1tMzVaV2s
  2c3hNTC1fQmtqUGRpY1B6NlNWCiAga2MxeFlwREtfbkdCeGpIREc4VzJxY01BI
  n19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MCWA-J6LU-5XPO-WRCA-6Z7E-CH6K-BYM7",
              "signature": "SmE2edXA18at4Qc7YJM2ch--qFYQpiY1aek7A_PGtM5IcyNUm
  A_REdDylHc6dXRRDCIy-2ySBdqAs7J4J0BBjx_dK39OIDtKgyDd2t3nODd0lAc
  WtscWKtsQLtESkyFTXfsKAWh2U93Oi4ksvwHfJBkA"}],
          "PayloadDigest": "lXorM000QuRsLkECkFwJMwaOwK86iy-nqJnk2ANUfEd7s
  Ztijf2k3a2IEntOA7XuVFGzrV7Ayw67tNKX5-f9Jg"}]}}}
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
<rsp>PIN=ABC6-I3XB-KBEG-CEW2-XZOH-VSFH-KGNQ (Expires=2020-09-23T13:13:00Z)
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
      "MessageId": "AB7I-7ULE-WADH-SSQ6-YMIY-IVGY-5CWK",
      "Account": "alice@example.com",
      "Expires": "2020-09-23T13:13:00Z",
      "Automatic": true,
      "SaltedPIN": "ABC6-I3XB-KBEG-CEW2-XZOH-VSFH-KGNQ",
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




