

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
<rsp>Entry<CatalogedContact>: MCAP-Q4KN-WUUZ-PAAK-AB6K-5JVV-AKRD
  Person MCAP-Q4KN-WUUZ-PAAK-AB6K-5JVV-AKRD
  Anchor MCAP-Q4KN-WUUZ-PAAK-AB6K-5JVV-AKRD
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
          "Key": "MCAP-Q4KN-WUUZ-PAAK-AB6K-5JVV-AKRD",
          "Self": true,
          "Contact": {
            "ContactPerson": {
              "Id": "MCAP-Q4KN-WUUZ-PAAK-AB6K-5JVV-AKRD",
              "Anchors": [{
                  "Udf": "MCAP-Q4KN-WUUZ-PAAK-AB6K-5JVV-AKRD",
                  "Validation": "Self"}],
              "NetworkAddresses": [{
                  "Address": "alice@example.com",
                  "EnvelopedProfileAccount": [{
                      "EnvelopeID": "MCAP-Q4KN-WUUZ-PAAK-AB6K-5JVV-AKRD",
                      "dig": "S512",
                      "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQ0FQLVE0S04tV1VVWi1
  QQUFLLUFCNkstNUpWVi1BS1JEIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0xMC0yM1QxNToxODo1MVoifQ"},
                    "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DQVAtUTRLTi1XVVVaLVBBQ
  UstQUI2Sy01SlZWLUFLUkQiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJCS1d6eGRKWkd0YVVjdi1INnR
  EZ3B0OS1sWjVzODRTanNUS25NcHFJWkNZOXQyYTAwSFBOCiAgMV9yX3JydWE4Y
  UlzaHFCb0tOM2hVd2NBIn19fSwKICAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGl
  jZUBleGFtcGxlLmNvbSIsCiAgICAiU2VydmljZVVkZiI6ICJNQUMyLVhZNk0tT
  UVWMi1RRklNLTQzWFEtNU0zQi1OWlNFIiwKICAgICJBY2NvdW50RW5jcnlwdGl
  vbiI6IHsKICAgICAgIlVkZiI6ICJNQlJYLU5MWFotS0VUQy1VNFA1LTZWM0YtS
  zU0Wi1UV0VBIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogI
  CAgICAgICAgIlB1YmxpYyI6ICJqcmxmZExmdXJTMGRaTnNqdnE0QmpQcW5TenF
  STTh1U0ZGeXFOSS1Td2h2d0ZNeDYtMGw4CiAgNmc5SXJwc1pVZU9CTGNJUldlV
  WZsQjZBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogICA
  gICAiVWRmIjogIk1DQVAtUTRLTi1XVVVaLVBBQUstQUI2Sy01SlZWLUFLUkQiL
  AogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V
  5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJCS1d6eGRKWkd0YVVjdi1INnREZ3B0OS1sWjVzODRTanNUS25
  NcHFJWkNZOXQyYTAwSFBOCiAgMV9yX3JydWE4YUlzaHFCb0tOM2hVd2NBIn19f
  SwKICAgICJBY2NvdW50QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiA
  iTUFKNS1CM1A3LVAzQlotVVJYUy1ZNDRXLVgySkEtU09NTSIsCiAgICAgICJQd
  WJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewo
  gICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiX
  0htQzNlYzBReFV2OC1ZWFpOM05JanJOQks1RlVRNURzREtQbE8wVWdmZFFnc2Z
  PMjBSVAogIE1vNDl4MUtleThPaTY1d3NFMldLSnd1QSJ9fX0sCiAgICAiQWNjb
  3VudFNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQktWLUNFRlItVVRPMi1
  XMzZLLU01QUstVVhQSy1DV05DIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiO
  iB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ijo
  gIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiQmsxSWNPUllDMTVfZGt3R
  zVzV1lEV3dNVlYwTV84Y0NWbjhKU0hXa2FoVTRWeXEzOEYycAogIDg0UGNCZFZ
  jZ0xMUEhZWEtubXFfSlktQSJ9fX19fQ",
                    {
                      "signatures": [{
                          "alg": "S512",
                          "kid": "MCAP-Q4KN-WUUZ-PAAK-AB6K-5JVV-AKRD",
                          "signature": "GFM5omve9D6dV2PRU-LLpwsBWZZOd7eZkLNOPo7rkNLy8fBse
  MRcf2ZqYqLYMgjwhfpJWMG_VfyAyr1qJbtodNJPCP2vV_aTmSJE5j-LARW8oG6
  ReRE-eRJRZraoDydkc70Ayvy-3yDTV2lP0bcr7BQA"}],
                      "PayloadDigest": "631YRohVmktPFEwOxyyYvRRiXAsStFqVFEOihgEQ7hMHy
  74jRDy71MwlIueVN2xtvYLJVj-hXzvYfIfXPGb3-A"}],
                  "Protocols": [{
                      "Protocol": "mmm"}]}],
              "Sources": [{
                  "Validation": "Self",
                  "EnvelopedSource": [{
                      "dig": "S512",
                      "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjAtMTAtMjNUMTU6MTg6NTFaIn0"},
                    "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTUNBUC1RNEtOLVdVVVotUEFBSy1BQ
  jZLLTVKVlYtQUtSRCIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAgICAgIkVudmVsb3BlZFByb2ZpbGV
  BY2NvdW50IjogW3sKICAgICAgICAgICAgIkVudmVsb3BlSUQiOiAiTUNBUC1RN
  EtOLVdVVVotUEFBSy1BQjZLLTVKVlYtQUtSRCIsCiAgICAgICAgICAgICJkaWc
  iOiAiUzUxMiIsCiAgICAgICAgICAgICJDb250ZW50TWV0YURhdGEiOiAiZXdvZ
  0lDSlZibWx4ZFdWSlJDSTZJQ0pOUTBGUUxWRTBTMDR0VjFWVldpMQogIFFRVUZ
  MTFVGQ05rc3ROVXBXVmkxQlMxSkVJaXdLSUNBaVRXVnpjMkZuWlZSNWNHVWlPa
  UFpVUhKdlptbHNaCiAgVlZ6WlhJaUxBb2dJQ0pqZEhraU9pQWlZWEJ3Ykdsall
  YUnBiMjR2YlcxdEwyOWlhbVZqZENJc0NpQWdJa04KICB5WldGMFpXUWlPaUFpT
  WpBeU1DMHhNQzB5TTFReE5Ub3hPRG8xTVZvaWZRIn0sCiAgICAgICAgICAiZXd
  vZ0lDSlFjbTltYVd4bFZYTmxjaUk2SUhzS0lDQWdJQ0pRY205bWFXeAogIGxVM
  mxuYm1GMGRYSmxJam9nZXdvZ0lDQWdJQ0FpVldSbUlqb2dJazFEUVZBdFVUUkx
  UaTFYVlZWYUxWQkJRCiAgVXN0UVVJMlN5MDFTbFpXTFVGTFVrUWlMQW9nSUNBZ
  0lDQWlVSFZpYkdsalVHRnlZVzFsZEdWeWN5STZJSHMKICBLSUNBZ0lDQWdJQ0F
  pVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0FnSUNKamNuWWlPa
  UFpUgogIFdRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKQ1M
  xZDZlR1JLV2tkMFlWVmpkaTFJTm5SCiAgRVozQjBPUzFzV2pWek9EUlRhbk5VU
  zI1TmNIRkpXa05aT1hReVlUQXdTRkJPQ2lBZ01WOXlYM0p5ZFdFNFkKICBVbHp
  hSEZDYjB0T00yaFZkMk5CSW4xOWZTd0tJQ0FnSUNKQlkyTnZkVzUwUVdSa2NtV
  npjeUk2SUNKaGJHbAogIGpaVUJsZUdGdGNHeGxMbU52YlNJc0NpQWdJQ0FpVTJ
  WeWRtbGpaVlZrWmlJNklDSk5RVU15TFZoWk5rMHRUCiAgVVZXTWkxUlJrbE5MV
  FF6V0ZFdE5VMHpRaTFPV2xORklpd0tJQ0FnSUNKQlkyTnZkVzUwUlc1amNubHd
  kR2wKICB2YmlJNklIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlFsSllMVTVNV0Zvd
  FMwVlVReTFWTkZBMUxUWldNMFl0UwogIHpVMFdpMVVWMFZCSWl3S0lDQWdJQ0F
  nSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBCiAgZ0lsQ
  jFZbXhwWTB0bGVVVkRSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0l
  sZzBORGdpTEFvZ0kKICBDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSnFjbXhtW
  kV4bWRYSlRNR1JhVG5OcWRuRTBRbXBRY1c1VGVuRgogIFNUVGgxVTBaR2VYRk9
  TUzFUZDJoMmQwWk5lRFl0TUd3NENpQWdObWM1U1hKd2MxcFZaVTlDVEdOSlVsZ
  GxWCiAgV1pzUWpaQkluMTlmU3dLSUNBZ0lDSkJaRzFwYm1semRISmhkRzl5VTJ
  sbmJtRjBkWEpsSWpvZ2V3b2dJQ0EKICBnSUNBaVZXUm1Jam9nSWsxRFFWQXRVV
  FJMVGkxWFZWVmFMVkJCUVVzdFFVSTJTeTAxU2xaV0xVRkxVa1FpTAogIEFvZ0l
  DQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2xqUzJWCiAgNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0kKICBsQjFZbXhwWXlJNklDS
  kNTMWQ2ZUdSS1drZDBZVlZqZGkxSU5uUkVaM0IwT1Mxc1dqVnpPRFJUYW5OVVM
  yNQogIE5jSEZKV2tOWk9YUXlZVEF3U0ZCT0NpQWdNVjl5WDNKeWRXRTRZVWx6Y
  UhGQ2IwdE9NMmhWZDJOQkluMTlmCiAgU3dLSUNBZ0lDSkJZMk52ZFc1MFFYVjB
  hR1Z1ZEdsallYUnBiMjRpT2lCN0NpQWdJQ0FnSUNKVlpHWWlPaUEKICBpVFVGS
  05TMUNNMUEzTFZBelFsb3RWVkpZVXkxWk5EUlhMVmd5U2tFdFUwOU5UU0lzQ2l
  BZ0lDQWdJQ0pRZAogIFdKc2FXTlFZWEpoYldWMFpYSnpJam9nZXdvZ0lDQWdJQ
  0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvCiAgZ0lDQWdJQ0FnSUNBZ0l
  tTnlkaUk2SUNKWU5EUTRJaXdLSUNBZ0lDQWdJQ0FnSUNKUWRXSnNhV01pT2lBa
  VgKICAwaHRRek5sWXpCUmVGVjJPQzFaV0ZwT00wNUphbkpPUWtzMVJsVlJOVVJ
  6UkV0UWJFOHdWV2RtWkZGbmMyWgogIFBNakJTVkFvZ0lFMXZORGw0TVV0bGVUa
  FBhVFkxZDNORk1sZExTbmQxUVNKOWZYMHNDaUFnSUNBaVFXTmpiCiAgM1Z1ZEZ
  OcFoyNWhkSFZ5WlNJNklIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlFrdFdMVU5GU
  mxJdFZWUlBNaTEKICBYTXpaTExVMDFRVXN0VlZoUVN5MURWMDVESWl3S0lDQWd
  JQ0FnSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pTwogIGlCN0NpQWdJQ0FnSUNBZ
  0lsQjFZbXhwWTB0bGVVVkRSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWp
  vCiAgZ0lrVmtORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlRb
  XN4U1dOUFVsbERNVFZmWkd0M1IKICB6VnpWMWxFVjNkTlZsWXdUVjg0WTBOV2J
  qaEtVMGhYYTJGb1ZUUldlWEV6T0VZeWNBb2dJRGcwVUdOQ1pGWgogIGpaMHhNV
  UVoWldFdHViWEZmU2xrdFFTSjlmWDE5ZlEiLAogICAgICAgICAgewogICAgICA
  gICAgICAic2lnbmF0dXJlcyI6IFt7CiAgICAgICAgICAgICAgICAiYWxnIjogI
  lM1MTIiLAogICAgICAgICAgICAgICAgImtpZCI6ICJNQ0FQLVE0S04tV1VVWi1
  QQUFLLUFCNkstNUpWVi1BS1JEIiwKICAgICAgICAgICAgICAgICJzaWduYXR1c
  mUiOiAiR0ZNNW9tdmU5RDZkVjJQUlUtTExwd3NCV1paT2Q3ZVprTE5PUG83cmt
  OTHk4ZkJzZQogIE1SY2YyWnFZcUxZTWdqd2hmcEpXTUdfVmZ5QXlyMXFKYnRvZ
  E5KUENQMnZWX2FUbVNKRTVqLUxBUlc4b0c2CiAgUmVSRS1lUkpSWnJhb0R5ZGt
  jNzBBeXZ5LTN5RFRWMmxQMGJjcjdCUUEifV0sCiAgICAgICAgICAgICJQYXlsb
  2FkRGlnZXN0IjogIjYzMVlSb2hWbWt0UEZFd094eXlZdlJSaVhBc1N0RnFWRkV
  PaWhnRVE3aE1IeQogIDc0alJEeTcxTXdsSXVlVk4yeHR2WUxKVmotaFh6dllmS
  WZYUEdiMy1BIn1dLAogICAgICAgICJQcm90b2NvbHMiOiBbewogICAgICAgICA
  gICAiUHJvdG9jb2wiOiAibW1tIn1dfV19fQ",
                    {
                      "signatures": [{
                          "alg": "S512",
                          "kid": "MBKV-CEFR-UTO2-W36K-M5AK-UXPK-CWNC",
                          "signature": "bU3itEMQGHeTx82pJ5a5ONpvOx734I82_1tPiZruTQrYwRQZ8
  vfZdM0lbTzN3Neg2yAvODwfRwcAj0H8lDZFf95ZNc6Dn1T48-eRDGvxw01dv7L
  -6HuEGyhOPbEZa1eoT7TBA-n3cVUE6weUJLOzDQQA"}],
                      "PayloadDigest": "Bi64Vix5yGTj5ZkLs6hcb_g2hfOtCVBKt3bYv39mhVu4u
  _SD2F1BT5ZCn9MpnQZuVXWaWy8jW6mVFcKyoWE6yw"}]}]}}}}]}}
</div>
~~~~


