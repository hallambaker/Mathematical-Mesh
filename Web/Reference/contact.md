

# contact

~~~~
<div="helptext">
<over>
contact    Manage contact catalogs connected to an account
    add   Add contact entry from file
    delete   Delete contact entry
    dynamic   Create dynamic contact retrieval URI
    exchange   Request contact from URI presenting own contact
    export   Export contact entry from catalog
    fetch   Request contact from URI without presenting own contact
    get   Lookup contact entry
    list   List contact entries
    self   Update contact entry for self
    static   Create static contact retrieval URI
<over>
</div>
~~~~


# contact add

~~~~
<div="helptext">
<over>
add   Add contact entry from file
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> contact add email carol@example.com
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\email'.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> contact add email carol@example.com /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "Could not find file 'C:\\Users\\hallam\\Test\\WorkingDirectory\\email'."}}
</div>
~~~~


# contact delete

~~~~
<div="helptext">
<over>
delete   Delete contact entry
       Contact entry identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> contact delete carol@example.com
<rsp>ERROR - The entry could not be found in the store.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> contact delete carol@example.com /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The entry could not be found in the store."}}
</div>
~~~~


# contact get

~~~~
<div="helptext">
<over>
get   Lookup contact entry
       Contact entry identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /encrypt   Encrypt the contact under the specified key
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> contact get carol@example.com
<rsp>Empty
</div>
~~~~

Specifying the /json option returns a result of type ResultEntry:

~~~~
<div="terminal">
<cmd>Alice> contact get carol@example.com /json
<rsp>{
  "ResultEntry": {
    "Success": false}}
</div>
~~~~


# contact list

~~~~
<div="helptext">
<over>
list   List contact entries
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MCDH-FIPQ-XWI3-2MLS-KZ6U-SAVO-EVSH
  Person MCDH-FIPQ-XWI3-2MLS-KZ6U-SAVO-EVSH
  Anchor MCDH-FIPQ-XWI3-2MLS-KZ6U-SAVO-EVSH
  Address alice@example.com

</div>
~~~~

Specifying the /json option returns a result of type ResultDump:

~~~~
<div="terminal">
<cmd>Alice> contact list /json
<rsp>{
  "ResultDump": {
    "Success": true,
    "CatalogedEntries": [{
        "CatalogedContact": {
          "Key": "MCDH-FIPQ-XWI3-2MLS-KZ6U-SAVO-EVSH",
          "Self": true,
          "Contact": {
            "ContactPerson": {
              "Id": "MCDH-FIPQ-XWI3-2MLS-KZ6U-SAVO-EVSH",
              "Anchors": [{
                  "Udf": "MCDH-FIPQ-XWI3-2MLS-KZ6U-SAVO-EVSH",
                  "Validation": "Self"}],
              "NetworkAddresses": [{
                  "Address": "alice@example.com",
                  "EnvelopedProfileAccount": [{
                      "EnvelopeID": "MCDH-FIPQ-XWI3-2MLS-KZ6U-SAVO-EVSH",
                      "dig": "S512",
                      "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQ0RILUZJUFEtWFdJMy0
  yTUxTLUtaNlUtU0FWTy1FVlNIIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0xMS0wM1QwMTo1MDozOFoifQ"},
                    "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DREgtRklQUS1YV0kzLTJNT
  FMtS1o2VS1TQVZPLUVWU0giLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJoUUxJcWdOMEtRS3V4R18tSHR
  HV2JQQ0l1RlJvbG9UQno4c3MyWjltenh5VThQaEhsWE5zCiAgZG42d0VJNURsU
  1NkLXhEVFQ1RHFlLThBIn19fSwKICAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGl
  jZUBleGFtcGxlLmNvbSIsCiAgICAiU2VydmljZVVkZiI6ICJNRFFPLVI2NkotT
  VZFTy1CREw2LVY2VDctRlBJSS1VNDJRIiwKICAgICJBY2NvdW50RW5jcnlwdGl
  vbiI6IHsKICAgICAgIlVkZiI6ICJNQ1NNLUpSQ08tRkRTRS1IVTJYLVJaNkItV
  FpWTy1FVVdHIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogI
  CAgICAgICAgIlB1YmxpYyI6ICIyOG1NTV90ZEFybmhsYWptckF1WEtIQndYamd
  kVzdOYWVhTmlWYTFCQ1JDeUJBeDF0NDlKCiAgRUlRUFFBcGxiZXp5YlllWkhMU
  HhjaVFBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogICA
  gICAiVWRmIjogIk1DREgtRklQUS1YV0kzLTJNTFMtS1o2VS1TQVZPLUVWU0giL
  AogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V
  5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJoUUxJcWdOMEtRS3V4R18tSHRHV2JQQ0l1RlJvbG9UQno4c3M
  yWjltenh5VThQaEhsWE5zCiAgZG42d0VJNURsU1NkLXhEVFQ1RHFlLThBIn19f
  SwKICAgICJBY2NvdW50QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiA
  iTURIVi1OTDVJLUZUTkUtTUVQUC1UM0xMLUdWMlAtM1BRSyIsCiAgICAgICJQd
  WJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewo
  gICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiO
  UttNXNQdjQtMkVYUDU1NDh4cmF5aXpyQXBZZVRzS3NSY0hySk8zaWdDbkw4OTB
  5X2lsQQogIG9qUmxhSi1CUFRHMzlBMFFHdE11bi04QSJ9fX0sCiAgICAiQWNjb
  3VudFNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQllCLTNTS0ctU0lGUi1
  LRUZKLUREVUktWFVSTS1WRzZOIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiO
  iB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ijo
  gIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiZUN1akU5SjU2Z242aC1Hd
  kJwaERoejFxQjVQS1RTR21tamtpcUhGam1EcEEyN21DWmxLNAogIFBrR19taE9
  OX0N3NzFVWmFBaW9tamhDQSJ9fX19fQ",
                    {
                      "signatures": [{
                          "alg": "S512",
                          "kid": "MCDH-FIPQ-XWI3-2MLS-KZ6U-SAVO-EVSH",
                          "signature": "hPWd3iRqTx5tn_VAcFOl5NFiUhiSvTQ2Yrt3lMUaZlgEAjJvj
  av7zwgB6SfVt59eaBG3cAI6z_iA2mi3eDP314lD8xxbOALJp3r02TTvMaxxGx1
  R_HdneReMZYlrO12YdllyI9w14mkQDBGtY1bn4QsA"}],
                      "PayloadDigest": "j3iRsYIUPzWOAE1qN2MyfSZXb3DrEnqhtttoa8BgpGgZJ
  b_A-1Nxi9Vk-wzz7kEh30HuWsfh2mYdprmNpeJDfw"}],
                  "Protocols": [{
                      "Protocol": "mmm"}]}],
              "Sources": [{
                  "Validation": "Self",
                  "EnvelopedSource": [{
                      "dig": "S512",
                      "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjAtMTEtMDNUMDE6NTA6MzhaIn0"},
                    "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTUNESC1GSVBRLVhXSTMtMk1MUy1LW
  jZVLVNBVk8tRVZTSCIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAgICAgIkVudmVsb3BlZFByb2ZpbGV
  BY2NvdW50IjogW3sKICAgICAgICAgICAgIkVudmVsb3BlSUQiOiAiTUNESC1GS
  VBRLVhXSTMtMk1MUy1LWjZVLVNBVk8tRVZTSCIsCiAgICAgICAgICAgICJkaWc
  iOiAiUzUxMiIsCiAgICAgICAgICAgICJDb250ZW50TWV0YURhdGEiOiAiZXdvZ
  0lDSlZibWx4ZFdWSlJDSTZJQ0pOUTBSSUxVWkpVRkV0V0ZkSk15MAogIHlUVXh
  UTFV0YU5sVXRVMEZXVHkxRlZsTklJaXdLSUNBaVRXVnpjMkZuWlZSNWNHVWlPa
  UFpVUhKdlptbHNaCiAgVlZ6WlhJaUxBb2dJQ0pqZEhraU9pQWlZWEJ3Ykdsall
  YUnBiMjR2YlcxdEwyOWlhbVZqZENJc0NpQWdJa04KICB5WldGMFpXUWlPaUFpT
  WpBeU1DMHhNUzB3TTFRd01UbzFNRG96T0ZvaWZRIn0sCiAgICAgICAgICAiZXd
  vZ0lDSlFjbTltYVd4bFZYTmxjaUk2SUhzS0lDQWdJQ0pRY205bWFXeAogIGxVM
  mxuYm1GMGRYSmxJam9nZXdvZ0lDQWdJQ0FpVldSbUlqb2dJazFEUkVndFJrbFF
  VUzFZVjBrekxUSk5UCiAgRk10UzFvMlZTMVRRVlpQTFVWV1UwZ2lMQW9nSUNBZ
  0lDQWlVSFZpYkdsalVHRnlZVzFsZEdWeWN5STZJSHMKICBLSUNBZ0lDQWdJQ0F
  pVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0FnSUNKamNuWWlPa
  UFpUgogIFdRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKb1V
  VeEpjV2RPTUV0UlMzVjRSMTh0U0hSCiAgSFYySlFRMGwxUmxKdmJHOVVRbm80Y
  zNNeVdqbHRlbmg1VlRoUWFFaHNXRTV6Q2lBZ1pHNDJkMFZKTlVSc1UKICAxTmt
  MWGhFVkZRMVJIRmxMVGhCSW4xOWZTd0tJQ0FnSUNKQlkyTnZkVzUwUVdSa2NtV
  npjeUk2SUNKaGJHbAogIGpaVUJsZUdGdGNHeGxMbU52YlNJc0NpQWdJQ0FpVTJ
  WeWRtbGpaVlZrWmlJNklDSk5SRkZQTFZJMk5rb3RUCiAgVlpGVHkxQ1JFdzJMV
  lkyVkRjdFJsQkpTUzFWTkRKUklpd0tJQ0FnSUNKQlkyTnZkVzUwUlc1amNubHd
  kR2wKICB2YmlJNklIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlExTk5MVXBTUTA4d
  FJrUlRSUzFJVlRKWUxWSmFOa0l0VgogIEZwV1R5MUZWVmRISWl3S0lDQWdJQ0F
  nSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBCiAgZ0lsQ
  jFZbXhwWTB0bGVVVkRSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0l
  sZzBORGdpTEFvZ0kKICBDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSXlPRzFOV
  FY5MFpFRnlibWhzWVdwdGNrRjFXRXRJUW5kWWFtZAogIGtWemRPWVdWaFRtbFd
  ZVEZDUTFKRGVVSkJlREYwTkRsS0NpQWdSVWxSVUZGQmNHeGlaWHA1WWxsbFdra
  E1VCiAgSGhqYVZGQkluMTlmU3dLSUNBZ0lDSkJaRzFwYm1semRISmhkRzl5VTJ
  sbmJtRjBkWEpsSWpvZ2V3b2dJQ0EKICBnSUNBaVZXUm1Jam9nSWsxRFJFZ3RSa
  2xRVVMxWVYwa3pMVEpOVEZNdFMxbzJWUzFUUVZaUExVVldVMGdpTAogIEFvZ0l
  DQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2xqUzJWCiAgNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0kKICBsQjFZbXhwWXlJNklDS
  m9VVXhKY1dkT01FdFJTM1Y0UjE4dFNIUkhWMkpRUTBsMVJsSnZiRzlVUW5vNGM
  zTQogIHlXamx0ZW5oNVZUaFFhRWhzV0U1ekNpQWdaRzQyZDBWSk5VUnNVMU5rT
  FhoRVZGUTFSSEZsTFRoQkluMTlmCiAgU3dLSUNBZ0lDSkJZMk52ZFc1MFFYVjB
  hR1Z1ZEdsallYUnBiMjRpT2lCN0NpQWdJQ0FnSUNKVlpHWWlPaUEKICBpVFVSS
  VZpMU9URFZKTFVaVVRrVXRUVVZRVUMxVU0weE1MVWRXTWxBdE0xQlJTeUlzQ2l
  BZ0lDQWdJQ0pRZAogIFdKc2FXTlFZWEpoYldWMFpYSnpJam9nZXdvZ0lDQWdJQ
  0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvCiAgZ0lDQWdJQ0FnSUNBZ0l
  tTnlkaUk2SUNKWU5EUTRJaXdLSUNBZ0lDQWdJQ0FnSUNKUWRXSnNhV01pT2lBa
  U8KICBVdHROWE5RZGpRdE1rVllVRFUxTkRoNGNtRjVhWHB5UVhCWlpWUnpTM05
  TWTBoeVNrOHphV2REYmt3NE9UQgogIDVYMmxzUVFvZ0lHOXFVbXhoU2kxQ1VGU
  khNemxCTUZGSGRFMTFiaTA0UVNKOWZYMHNDaUFnSUNBaVFXTmpiCiAgM1Z1ZEZ
  OcFoyNWhkSFZ5WlNJNklIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlFsbENMVE5UU
  zBjdFUwbEdVaTEKICBMUlVaS0xVUkVWVWt0V0ZWU1RTMVdSelpPSWl3S0lDQWd
  JQ0FnSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pTwogIGlCN0NpQWdJQ0FnSUNBZ
  0lsQjFZbXhwWTB0bGVVVkRSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWp
  vCiAgZ0lrVmtORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlaV
  U4xYWtVNVNqVTJaMjQyYUMxSGQKICBrSndhRVJvZWpGeFFqVlFTMVJUUjIxdGF
  tdHBjVWhHYW0xRWNFRXlOMjFEV214TE5Bb2dJRkJyUjE5dGFFOQogIE9YME4zT
  npGVldtRkJhVzl0YW1oRFFTSjlmWDE5ZlEiLAogICAgICAgICAgewogICAgICA
  gICAgICAic2lnbmF0dXJlcyI6IFt7CiAgICAgICAgICAgICAgICAiYWxnIjogI
  lM1MTIiLAogICAgICAgICAgICAgICAgImtpZCI6ICJNQ0RILUZJUFEtWFdJMy0
  yTUxTLUtaNlUtU0FWTy1FVlNIIiwKICAgICAgICAgICAgICAgICJzaWduYXR1c
  mUiOiAiaFBXZDNpUnFUeDV0bl9WQWNGT2w1TkZpVWhpU3ZUUTJZcnQzbE1VYVp
  sZ0VBakp2agogIGF2N3p3Z0I2U2ZWdDU5ZWFCRzNjQUk2el9pQTJtaTNlRFAzM
  TRsRDh4eGJPQUxKcDNyMDJUVHZNYXh4R3gxCiAgUl9IZG5lUmVNWllsck8xMll
  kbGx5STl3MTRta1FEQkd0WTFibjRRc0EifV0sCiAgICAgICAgICAgICJQYXlsb
  2FkRGlnZXN0IjogImozaVJzWUlVUHpXT0FFMXFOMk15ZlNaWGIzRHJFbnFodHR
  0b2E4QmdwR2daSgogIGJfQS0xTnhpOVZrLXd6ejdrRWgzMEh1V3NmaDJtWWRwc
  m1OcGVKRGZ3In1dLAogICAgICAgICJQcm90b2NvbHMiOiBbewogICAgICAgICA
  gICAiUHJvdG9jb2wiOiAibW1tIn1dfV19fQ",
                    {
                      "signatures": [{
                          "alg": "S512",
                          "kid": "MBYB-3SKG-SIFR-KEFJ-DDUI-XURM-VG6N",
                          "signature": "Orf-ht-bmbAGT8TEVOWftjfx2q_h0Zfx_NFvD5Xu60sj7FU1W
  3c1MN10sSDTzHSvijTxKnzphz4AKpdaFO5FjoJ67m3nN8bz0lub-vfF93oTKrg
  3TkeXvwqY45dBROcXPsprqi9247P2W6GRvlqGRjIA"}],
                      "PayloadDigest": "Xw7Zg3PWqPsjf1Tnu1jbEaeb3Q2AhXMcBDWtnAh9400za
  0Sx9UIMJzp3Hnk0XUoCT8ETzg3nP2g3IJ89mABu0g"}]}]}}}}]}}
</div>
~~~~


