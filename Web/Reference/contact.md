

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
<rsp>Entry<CatalogedContact>: MCR2-U4OO-FBV3-6BSP-WKEQ-4QOG-QSAV
  Person MCR2-U4OO-FBV3-6BSP-WKEQ-4QOG-QSAV
  Anchor MCR2-U4OO-FBV3-6BSP-WKEQ-4QOG-QSAV
  Address alice@example.com

Entry<CatalogedContact>: NC6S-FHAS-TTJX-5VFB-B57Z-JOG3-DJDA
  Person 
  Anchor MCNN-EDO6-GYYF-2H2H-IJTV-KXQZ-TXXJ
  Address bob@example.com

Entry<CatalogedContact>: NBYD-QOZ3-BUQJ-QTYU-YPZJ-SCXL-LA64
  Person 
  Anchor MCL5-XUKG-CQ6T-ASVR-6RP5-X2C3-BL2L
  Address groupw@example.com

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
          "Key": "MCR2-U4OO-FBV3-6BSP-WKEQ-4QOG-QSAV",
          "Self": true,
          "Contact": {
            "ContactPerson": {
              "Id": "MCR2-U4OO-FBV3-6BSP-WKEQ-4QOG-QSAV",
              "Anchors": [{
                  "Udf": "MCR2-U4OO-FBV3-6BSP-WKEQ-4QOG-QSAV",
                  "Validation": "Self"}],
              "NetworkAddresses": [{
                  "Address": "alice@example.com",
                  "EnvelopedProfileAccount": [{
                      "EnvelopeID": "MCR2-U4OO-FBV3-6BSP-WKEQ-4QOG-QSAV",
                      "dig": "S512",
                      "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQ1IyLVU0T08tRkJWMy0
  2QlNQLVdLRVEtNFFPRy1RU0FWIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0xMS0xMFQwMDo1NjozMVoifQ"},
                    "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DUjItVTRPTy1GQlYzLTZCU
  1AtV0tFUS00UU9HLVFTQVYiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJVMVhEdm9MTjl3dUNwZ0V5Uk5
  LN3RtdUNfdnpjS3Y0S19ZTVVpYjRMM01Lam1mMG1YS0FzCiAgQXNtd2dVU0lVU
  XFiN1dKcFBQcDhkMnNBIn19fSwKICAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGl
  jZUBleGFtcGxlLmNvbSIsCiAgICAiU2VydmljZVVkZiI6ICJNQldOLUZMT0gtW
  E5FNy1YU0hKLVMzR1QtRTRCSS1VQ0lFIiwKICAgICJBY2NvdW50RW5jcnlwdGl
  vbiI6IHsKICAgICAgIlVkZiI6ICJNQllKLUFNQ0YtNFFWRC0zV0FULUtTM1gtN
  UxUUC1ZSUE3IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogI
  CAgICAgICAgIlB1YmxpYyI6ICJvcUh3V0NQWVJNejN5YWprUUlDbWtBSk0wdGU
  1eTVuYlFUUW5aRl9ib2x1V0JFUHk4UFdICiAgUE9fZlJua0xpRHU2dDlMSzZXX
  zhaWHVBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogICA
  gICAiVWRmIjogIk1DUjItVTRPTy1GQlYzLTZCU1AtV0tFUS00UU9HLVFTQVYiL
  AogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V
  5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJVMVhEdm9MTjl3dUNwZ0V5Uk5LN3RtdUNfdnpjS3Y0S19ZTVV
  pYjRMM01Lam1mMG1YS0FzCiAgQXNtd2dVU0lVUXFiN1dKcFBQcDhkMnNBIn19f
  SwKICAgICJBY2NvdW50QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiA
  iTUNHRC1QV0NZLUZKVzUtQVZMVC1PUlpDLU5LNlItN1ZNMiIsCiAgICAgICJQd
  WJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewo
  gICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiR
  TUyeU9OM2prSDNlbk1jRi03V3VtR0Q2NE1ibkhHUUc5elF5YkpZYUNfM1kxUkF
  GLThqbgogIEZSekEwS1dubGZpLUlGWDg2NTVWaG13QSJ9fX0sCiAgICAiQWNjb
  3VudFNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQTNCLUFMRVMtQjRBQS1
  BWjNVLVUyNEctVllHUS1EUENDIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiO
  iB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ijo
  gIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiOW5WVW9JMUNJV1FNeEVJZ
  mkxdDZLLTNtZElORkRCdDlqa2VfMktGWUJYUnJ3RXJfZUJEVgogIHVKUVZyanR
  XM3hpanBpcUhZUzE0R1BpQSJ9fX19fQ",
                    {
                      "signatures": [{
                          "alg": "S512",
                          "kid": "MCR2-U4OO-FBV3-6BSP-WKEQ-4QOG-QSAV",
                          "signature": "gv0HOIid-ytgTyt9NJFtIVPgxR4osPWwj-36cRS-4bpnXmCBk
  zPPmz2_PcCT2_cmO2Hy_bykHR8AxpvNFlaLlDaL5Tq3NEFE_-I0bc5JIRz6bD0
  59xinw453fy7mY0Qic6-CbWdm0oyt2jtBU74DjxUA"}],
                      "PayloadDigest": "Cq7glkkpf7-W1EkYq647gqb8zQyxIU3ZU3k7E-cp4myI_
  dvhThYSx_uMCLgxHGk5oICfIQp5LWwoScOqfET1pw"}],
                  "Protocols": [{
                      "Protocol": "mmm"}]}],
              "Sources": [{
                  "Validation": "Self",
                  "EnvelopedSource": [{
                      "dig": "S512",
                      "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjAtMTEtMTBUMDA6NTY6MzFaIn0"},
                    "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTUNSMi1VNE9PLUZCVjMtNkJTUC1XS
  0VRLTRRT0ctUVNBViIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAgICAgIkVudmVsb3BlZFByb2ZpbGV
  BY2NvdW50IjogW3sKICAgICAgICAgICAgIkVudmVsb3BlSUQiOiAiTUNSMi1VN
  E9PLUZCVjMtNkJTUC1XS0VRLTRRT0ctUVNBViIsCiAgICAgICAgICAgICJkaWc
  iOiAiUzUxMiIsCiAgICAgICAgICAgICJDb250ZW50TWV0YURhdGEiOiAiZXdvZ
  0lDSlZibWx4ZFdWSlJDSTZJQ0pOUTFJeUxWVTBUMDh0UmtKV015MAogIDJRbE5
  RTFZkTFJWRXRORkZQUnkxUlUwRldJaXdLSUNBaVRXVnpjMkZuWlZSNWNHVWlPa
  UFpVUhKdlptbHNaCiAgVlZ6WlhJaUxBb2dJQ0pqZEhraU9pQWlZWEJ3Ykdsall
  YUnBiMjR2YlcxdEwyOWlhbVZqZENJc0NpQWdJa04KICB5WldGMFpXUWlPaUFpT
  WpBeU1DMHhNUzB4TUZRd01EbzFOam96TVZvaWZRIn0sCiAgICAgICAgICAiZXd
  vZ0lDSlFjbTltYVd4bFZYTmxjaUk2SUhzS0lDQWdJQ0pRY205bWFXeAogIGxVM
  mxuYm1GMGRYSmxJam9nZXdvZ0lDQWdJQ0FpVldSbUlqb2dJazFEVWpJdFZUUlB
  UeTFHUWxZekxUWkNVCiAgMUF0VjB0RlVTMDBVVTlITFZGVFFWWWlMQW9nSUNBZ
  0lDQWlVSFZpYkdsalVHRnlZVzFsZEdWeWN5STZJSHMKICBLSUNBZ0lDQWdJQ0F
  pVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0FnSUNKamNuWWlPa
  UFpUgogIFdRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKVk1
  WaEVkbTlNVGpsM2RVTndaMFY1VWs1CiAgTE4zUnRkVU5mZG5walMzWTBTMTlaV
  FZWcFlqUk1NMDFMYW0xbU1HMVlTMEZ6Q2lBZ1FYTnRkMmRWVTBsVlUKICBYRml
  OMWRLY0ZCUWNEaGtNbk5CSW4xOWZTd0tJQ0FnSUNKQlkyTnZkVzUwUVdSa2NtV
  npjeUk2SUNKaGJHbAogIGpaVUJsZUdGdGNHeGxMbU52YlNJc0NpQWdJQ0FpVTJ
  WeWRtbGpaVlZrWmlJNklDSk5RbGRPTFVaTVQwZ3RXCiAgRTVGTnkxWVUwaEtMV
  k16UjFRdFJUUkNTUzFWUTBsRklpd0tJQ0FnSUNKQlkyTnZkVzUwUlc1amNubHd
  kR2wKICB2YmlJNklIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlFsbEtMVUZOUTBZd
  E5GRldSQzB6VjBGVUxVdFRNMWd0TgogIFV4VVVDMVpTVUUzSWl3S0lDQWdJQ0F
  nSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBCiAgZ0lsQ
  jFZbXhwWTB0bGVVVkRSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0l
  sZzBORGdpTEFvZ0kKICBDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSnZjVWgzV
  jBOUVdWSk5lak41WVdwclVVbERiV3RCU2swd2RHVQogIDFlVFZ1WWxGVVVXNWF
  SbDlpYjJ4MVYwSkZVSGs0VUZkSUNpQWdVRTlmWmxKdWEweHBSSFUyZERsTVN6W
  lhYCiAgemhhV0hWQkluMTlmU3dLSUNBZ0lDSkJaRzFwYm1semRISmhkRzl5VTJ
  sbmJtRjBkWEpsSWpvZ2V3b2dJQ0EKICBnSUNBaVZXUm1Jam9nSWsxRFVqSXRWV
  FJQVHkxR1FsWXpMVFpDVTFBdFYwdEZVUzAwVVU5SExWRlRRVllpTAogIEFvZ0l
  DQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2xqUzJWCiAgNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0kKICBsQjFZbXhwWXlJNklDS
  lZNVmhFZG05TVRqbDNkVU53WjBWNVVrNUxOM1J0ZFVOZmRucGpTM1kwUzE5WlR
  WVgogIHBZalJNTTAxTGFtMW1NRzFZUzBGekNpQWdRWE50ZDJkVlUwbFZVWEZpT
  jFkS2NGQlFjRGhrTW5OQkluMTlmCiAgU3dLSUNBZ0lDSkJZMk52ZFc1MFFYVjB
  hR1Z1ZEdsallYUnBiMjRpT2lCN0NpQWdJQ0FnSUNKVlpHWWlPaUEKICBpVFVOS
  FJDMVFWME5aTFVaS1Z6VXRRVlpNVkMxUFVscERMVTVMTmxJdE4xWk5NaUlzQ2l
  BZ0lDQWdJQ0pRZAogIFdKc2FXTlFZWEpoYldWMFpYSnpJam9nZXdvZ0lDQWdJQ
  0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvCiAgZ0lDQWdJQ0FnSUNBZ0l
  tTnlkaUk2SUNKWU5EUTRJaXdLSUNBZ0lDQWdJQ0FnSUNKUWRXSnNhV01pT2lBa
  VIKICBUVXllVTlPTTJwclNETmxiazFqUmkwM1YzVnRSMFEyTkUxaWJraEhVVWM
  1ZWxGNVlrcFpZVU5mTTFreFVrRgogIEdMVGhxYmdvZ0lFWlNla0V3UzFkdWJHW
  nBMVWxHV0RnMk5UVldhRzEzUVNKOWZYMHNDaUFnSUNBaVFXTmpiCiAgM1Z1ZEZ
  OcFoyNWhkSFZ5WlNJNklIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlFUTkNMVUZNU
  lZNdFFqUkJRUzEKICBCV2pOVkxWVXlORWN0VmxsSFVTMUVVRU5ESWl3S0lDQWd
  JQ0FnSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pTwogIGlCN0NpQWdJQ0FnSUNBZ
  0lsQjFZbXhwWTB0bGVVVkRSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWp
  vCiAgZ0lrVmtORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlPV
  zVXVlc5Sk1VTkpWMUZOZUVWSloKICBta3hkRFpMTFROdFpFbE9Sa1JDZERscWE
  yVmZNa3RHV1VKWVVuSjNSWEpmWlVKRVZnb2dJSFZLVVZaeWFuUgogIFhNM2hwY
  W5CcGNVaFpVekUwUjFCcFFTSjlmWDE5ZlEiLAogICAgICAgICAgewogICAgICA
  gICAgICAic2lnbmF0dXJlcyI6IFt7CiAgICAgICAgICAgICAgICAiYWxnIjogI
  lM1MTIiLAogICAgICAgICAgICAgICAgImtpZCI6ICJNQ1IyLVU0T08tRkJWMy0
  2QlNQLVdLRVEtNFFPRy1RU0FWIiwKICAgICAgICAgICAgICAgICJzaWduYXR1c
  mUiOiAiZ3YwSE9JaWQteXRnVHl0OU5KRnRJVlBneFI0b3NQV3dqLTM2Y1JTLTR
  icG5YbUNCawogIHpQUG16Ml9QY0NUMl9jbU8ySHlfYnlrSFI4QXhwdk5GbGFMb
  ERhTDVUcTNORUZFXy1JMGJjNUpJUno2YkQwCiAgNTl4aW53NDUzZnk3bVkwUWl
  jNi1DYldkbTBveXQyanRCVTc0RGp4VUEifV0sCiAgICAgICAgICAgICJQYXlsb
  2FkRGlnZXN0IjogIkNxN2dsa2twZjctVzFFa1lxNjQ3Z3FiOHpReXhJVTNaVTN
  rN0UtY3A0bXlJXwogIGR2aFRoWVN4X3VNQ0xneEhHazVvSUNmSVFwNUxXd29TY
  09xZkVUMXB3In1dLAogICAgICAgICJQcm90b2NvbHMiOiBbewogICAgICAgICA
  gICAiUHJvdG9jb2wiOiAibW1tIn1dfV19fQ",
                    {
                      "signatures": [{
                          "alg": "S512",
                          "kid": "MA3B-ALES-B4AA-AZ3U-U24G-VYGQ-DPCC",
                          "signature": "HVL0aAcK9mvvdJlnidJOjACGZcsBqCWGOEZjKYSjhGaJFYWxx
  6JLiDMYpqB2L119k5r_4ODC8JkAJN33954xyEgpTBCSZkrnw1pdAD15dxzZFE6
  65p-9DduGjTWMVfvx1nTCIz5Ug--lw9W4Rx_IHyMA"}],
                      "PayloadDigest": "8FzeMVEna9OJaPOoLlCLZMqS0RG3LoyDcmnmdaHGYwdcL
  coJf6hua79rBqMxJ21sGwi3uvkXE9KMFrNzq-6ATg"}]}]}}}},
      {
        "CatalogedContact": {
          "Key": "NC6S-FHAS-TTJX-5VFB-B57Z-JOG3-DJDA",
          "Self": false,
          "Contact": {
            "ContactPerson": {
              "Anchors": [{
                  "Udf": "MCNN-EDO6-GYYF-2H2H-IJTV-KXQZ-TXXJ",
                  "Validation": "Self"}],
              "NetworkAddresses": [{
                  "Address": "bob@example.com",
                  "EnvelopedProfileAccount": [{
                      "EnvelopeID": "MCNN-EDO6-GYYF-2H2H-IJTV-KXQZ-TXXJ",
                      "dig": "S512",
                      "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQ05OLUVETzYtR1lZRi0
  ySDJILUlKVFYtS1hRWi1UWFhKIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0xMS0xMFQwMDo1NjozNVoifQ"},
                    "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DTk4tRURPNi1HWVlGLTJIM
  kgtSUpUVi1LWFFaLVRYWEoiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJGdkFSODNvNE1rMEJJZVQ1akZ
  CLUFjcHk5WVY0RjFqWmRnWnNKZ0JEeWp2UFNqT3ZQT252CiAgbjhDbDNaU3VsO
  FV2dTV4cnBEZ3NaZkVBIn19fSwKICAgICJBY2NvdW50QWRkcmVzcyI6ICJib2J
  AZXhhbXBsZS5jb20iLAogICAgIlNlcnZpY2VVZGYiOiAiTUJXTi1GTE9ILVhOR
  TctWFNISi1TM0dULUU0QkktVUNJRSIsCiAgICAiQWNjb3VudEVuY3J5cHRpb24
  iOiB7CiAgICAgICJVZGYiOiAiTUREUS1NSFRBLUVCUVgtUldQSC1HTVY1LUFCM
  kEtQ043ViIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJ
  QdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgI
  CAgICAgICJQdWJsaWMiOiAidG1KaWszMUd2a0NvM3NaZE9RaGU1TEE2alpkeDB
  VRy1QSFdrN181NkNkTGRwS2dXeEVkaAogIF9CQk1rcEJFOURkb1lNMGhrRGlpR
  1JhQSJ9fX0sCiAgICAiQWRtaW5pc3RyYXRvclNpZ25hdHVyZSI6IHsKICAgICA
  gIlVkZiI6ICJNQ05OLUVETzYtR1lZRi0ySDJILUlKVFYtS1hRWi1UWFhKIiwKI
  CAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUV
  DREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQd
  WJsaWMiOiAiRnZBUjgzbzRNazBCSWVUNWpGQi1BY3B5OVlWNEYxalpkZ1pzSmd
  CRHlqdlBTak92UE9udgogIG44Q2wzWlN1bDhVdnU1eHJwRGdzWmZFQSJ9fX0sC
  iAgICAiQWNjb3VudEF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVWRmIjogIk1
  CSDYtT05DNi1BNEFELVRTWjctRU42NS1RVFRPLUozQjMiLAogICAgICAiUHVib
  GljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICA
  gICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogImsxU
  jItQ3NfbW56Z3gxclJCMDA1YUJuOXdGcVFDTlNCUWl4Znk5Z1h6TXBfa2h2WE1
  zbHoKICA5X0R4ZjlzLXBsenlKQWdLdkxsel9yVUEifX19LAogICAgIkFjY291b
  nRTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTUNUTy1DQU5OLTRTRUItWUp
  QRC1JUVFDLUpTWUktNU83SCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJ
  FZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIjlJUjRBWlA3Z0dpZGY5Wkdua
  kNpenEteDlBQnBBUGhVSVpaa3dqWFBaWjNud1NvWmJsYksKICBucjhxc3M3ZHh
  IdHpDdFpGb2RHaHdYd0EifX19fX0",
                    {
                      "signatures": [{
                          "alg": "S512",
                          "kid": "MCNN-EDO6-GYYF-2H2H-IJTV-KXQZ-TXXJ",
                          "signature": "cWJzYNCz5Dac8POFvDQWTkdAPDygt8TZlLG72mxb3Ij1x9zj5
  F4B6IyAvM_dgJB7xN74iqS9Y8QAYv1gSWG9jaqLG1BalxoyeZTWEHOfjrrr-Nn
  AVxlQe6qelSWdKnSuIfc3Rdc6dUaN5AVA5xzq1AgA"}],
                      "PayloadDigest": "05oCwwNAzHidsJzFD5-qbN6AZ-pRTogMenQKZdROAVIeX
  pFCuqj-Ke-2fY58rvOxBYvef00jePu7ZHeaOvjvYw"}],
                  "Protocols": [{
                      "Protocol": "mmm"}]}]}}}},
      {
        "CatalogedContact": {
          "Key": "NBYD-QOZ3-BUQJ-QTYU-YPZJ-SCXL-LA64",
          "Self": false,
          "Contact": {
            "ContactPerson": {
              "Anchors": [{
                  "Udf": "MCL5-XUKG-CQ6T-ASVR-6RP5-X2C3-BL2L",
                  "Validation": "Self"}],
              "NetworkAddresses": [{
                  "Address": "groupw@example.com",
                  "EnvelopedProfileAccount": [{
                      "EnvelopeID": "MCL5-XUKG-CQ6T-ASVR-6RP5-X2C3-BL2L",
                      "dig": "S512",
                      "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQ0w1LVhVS0ctQ1E2VC1
  BU1ZSLTZSUDUtWDJDMy1CTDJMIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Udyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjAtMTEtMTBUMDA6NTc6MDNaIn0"},
                    "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZml
  sZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQ0w1LVhVS0ctQ1E2VC1BU
  1ZSLTZSUDUtWDJDMy1CTDJMIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB
  7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiNEVIVE0xTG01R1dhT3BLa1d
  WR05fcUhJUmxVSmdSaDhuZXBBNFhwTk0tNHIxRUJ2aHJ2UAogIHhRR1B3YUVwU
  FU1YmUzaTM1eDhBa1BTQSJ9fX0sCiAgICAiQWNjb3VudEFkZHJlc3MiOiAiZ3J
  vdXB3QGV4YW1wbGUuY29tIiwKICAgICJBY2NvdW50RW5jcnlwdGlvbiI6IHsKI
  CAgICAgIlVkZiI6ICJNQ0ZNLU8zN1MtNEVVRS1SQ1dOLTdaWkMtQlRCNi1PUEN
  WIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICIxdDhURFAyZDNvdzlwYUFEU2lsclNYbllJcEowT0pVcW1iY
  zVJNWRSY2I2X0pReVVPU2VCCiAgek9GX1p6alVGMXdQWVFIV3VZaF9nb09BIn1
  9fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogICAgICAiVWRmI
  jogIk1DTDUtWFVLRy1DUTZULUFTVlItNlJQNS1YMkMzLUJMMkwiLAogICAgICA
  iUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6I
  HsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI
  6ICI0RUhUTTFMbTVHV2FPcEtrV1ZHTl9xSElSbFVKZ1JoOG5lcEE0WHBOTS00c
  jFFQnZocnZQCiAgeFFHUHdhRXBQVTViZTNpMzV4OEFrUFNBIn19fX19",
                    {
                      "signatures": [{
                          "alg": "S512",
                          "kid": "MCL5-XUKG-CQ6T-ASVR-6RP5-X2C3-BL2L",
                          "signature": "i4bfHDbRAV6qQvlms7XzQaaKnqJsSeCi-nRNAnONEXu037YMx
  030m2D9VcfM5Qv26ZviRwMS-9sAdCWxvC8cDxnX7GftrYtfAZfra1Dfv9T-Uy_
  E0v_uYC5bXbQO6E-FSJTxS2taNr3j9lkyTcSoUhsA"}],
                      "PayloadDigest": "M4evGbjx0ZXobVEzGkalmZ2yTOFAivjiM65ax6gGNLlP3
  rJjWiGeFFxwjG-dPdGMgWji6Hkai3HKB-b6UlhazA"}],
                  "Protocols": [{
                      "Protocol": "mmm"}]}]}}}}]}}
</div>
~~~~


