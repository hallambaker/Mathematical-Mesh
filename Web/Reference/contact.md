

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
<rsp>Entry<CatalogedContact>: MBFU-YM7B-CJC4-HDLU-KRX5-UXC5-KYBS
  Person MBFU-YM7B-CJC4-HDLU-KRX5-UXC5-KYBS
  Anchor MBFU-YM7B-CJC4-HDLU-KRX5-UXC5-KYBS
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
          "Key": "MBFU-YM7B-CJC4-HDLU-KRX5-UXC5-KYBS",
          "Self": true,
          "Contact": {
            "ContactPerson": {
              "Id": "MBFU-YM7B-CJC4-HDLU-KRX5-UXC5-KYBS",
              "Anchors": [{
                  "Udf": "MBFU-YM7B-CJC4-HDLU-KRX5-UXC5-KYBS",
                  "Validation": "Self"}],
              "NetworkAddresses": [{
                  "Address": "alice@example.com",
                  "EnvelopedProfileAccount": [{
                      "EnvelopeID": "MBFU-YM7B-CJC4-HDLU-KRX5-UXC5-KYBS",
                      "dig": "S512",
                      "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQkZVLVlNN0ItQ0pDNC1
  IRExVLUtSWDUtVVhDNS1LWUJTIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0xMS0wOVQxNjowODoxMloifQ"},
                    "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CRlUtWU03Qi1DSkM0LUhET
  FUtS1JYNS1VWEM1LUtZQlMiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJaS1hRQzlpWV9hV0lKek9WaHg
  zVTJvQm00WEZOa1JEb2JqeEUxU1lxeXl4NXZKZkEtT0JWCiAgNzBSYUdIX3RWZ
  zZmakFxdkRPMk9oTDRBIn19fSwKICAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGl
  jZUBleGFtcGxlLmNvbSIsCiAgICAiU2VydmljZVVkZiI6ICJNQkNJLVQ0VjctQ
  UlCNC1HTUgzLTRDNlItS0Q1UC1JQ08zIiwKICAgICJBY2NvdW50RW5jcnlwdGl
  vbiI6IHsKICAgICAgIlVkZiI6ICJNQ1RULTJMRlEtWFNDNS1WM09MLUVWT1MtT
  k1RVS1ZT0M2IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogI
  CAgICAgICAgIlB1YmxpYyI6ICJCT1FUa204ZmJVZHFTdkhtTkNzVVlzckQ2TVZ
  OeWhMazN5WF9PUEJIcXhvNm1RT2dUNTZFCiAgZEVDa1pfOUE2S3FFY2pBbGJfM
  nYtN1VBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogICA
  gICAiVWRmIjogIk1CRlUtWU03Qi1DSkM0LUhETFUtS1JYNS1VWEM1LUtZQlMiL
  AogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V
  5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJaS1hRQzlpWV9hV0lKek9WaHgzVTJvQm00WEZOa1JEb2JqeEU
  xU1lxeXl4NXZKZkEtT0JWCiAgNzBSYUdIX3RWZzZmakFxdkRPMk9oTDRBIn19f
  SwKICAgICJBY2NvdW50QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiA
  iTUJaTi1ST01XLUo3TTItWVgyUC1aWkM1LTVONEYtUUZLWSIsCiAgICAgICJQd
  WJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewo
  gICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiM
  UxIOWpFajV2UlVtd2RndVVWZFozSU1BSHg3TjFWejJpN29HcUhJRWxSQ1hLcWt
  xcmJ3dgogIF9qOElyanI0eEl4Zk5BSlNWTFV1bG5FQSJ9fX0sCiAgICAiQWNjb
  3VudFNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNRE1ELUpUSlktR1lDVi1
  QRk1TLUxVU0MtMlFaNS1NTVpHIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiO
  iB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ijo
  gIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiVFZidGcxS0xzdWU5b1d1Z
  U1EODhlSnlHZlhoYmktX2NwTlAyaXFrU3A5WHB2UVBFM1NSRAogIHhqODgzMXB
  kejQwbU1UUlY2Y0dwV2p3QSJ9fX19fQ",
                    {
                      "signatures": [{
                          "alg": "S512",
                          "kid": "MBFU-YM7B-CJC4-HDLU-KRX5-UXC5-KYBS",
                          "signature": "MMTZpOAT0xDVE_A9JKrXqKKTijYt9aTno-HPpOWod9PHxJX6S
  UqGLzbdB1dA3vjM6yLF2FiwXmsANFA9-eLgp4Q4rVmO7pl9MftpLy116GagbDj
  7SpMPM6UCQyEgGivre858zXEI5-5NXK7mef99lR8A"}],
                      "PayloadDigest": "8vlEoOaAA-AYOWUfUioci5bhFzi8EJmcDWnrpsT9ETAAf
  aWNoTQ9oByuhdOLHWIzKuUngav9fbROj5ulFST-kw"}],
                  "Protocols": [{
                      "Protocol": "mmm"}]}],
              "Sources": [{
                  "Validation": "Self",
                  "EnvelopedSource": [{
                      "dig": "S512",
                      "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjAtMTEtMDlUMTY6MDg6MTJaIn0"},
                    "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTUJGVS1ZTTdCLUNKQzQtSERMVS1LU
  lg1LVVYQzUtS1lCUyIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAgICAgIkVudmVsb3BlZFByb2ZpbGV
  BY2NvdW50IjogW3sKICAgICAgICAgICAgIkVudmVsb3BlSUQiOiAiTUJGVS1ZT
  TdCLUNKQzQtSERMVS1LUlg1LVVYQzUtS1lCUyIsCiAgICAgICAgICAgICJkaWc
  iOiAiUzUxMiIsCiAgICAgICAgICAgICJDb250ZW50TWV0YURhdGEiOiAiZXdvZ
  0lDSlZibWx4ZFdWSlJDSTZJQ0pOUWtaVkxWbE5OMEl0UTBwRE5DMQogIElSRXh
  WTFV0U1dEVXRWVmhETlMxTFdVSlRJaXdLSUNBaVRXVnpjMkZuWlZSNWNHVWlPa
  UFpVUhKdlptbHNaCiAgVlZ6WlhJaUxBb2dJQ0pqZEhraU9pQWlZWEJ3Ykdsall
  YUnBiMjR2YlcxdEwyOWlhbVZqZENJc0NpQWdJa04KICB5WldGMFpXUWlPaUFpT
  WpBeU1DMHhNUzB3T1ZReE5qb3dPRG94TWxvaWZRIn0sCiAgICAgICAgICAiZXd
  vZ0lDSlFjbTltYVd4bFZYTmxjaUk2SUhzS0lDQWdJQ0pRY205bWFXeAogIGxVM
  mxuYm1GMGRYSmxJam9nZXdvZ0lDQWdJQ0FpVldSbUlqb2dJazFDUmxVdFdVMDN
  RaTFEU2tNMExVaEVUCiAgRlV0UzFKWU5TMVZXRU0xTFV0WlFsTWlMQW9nSUNBZ
  0lDQWlVSFZpYkdsalVHRnlZVzFsZEdWeWN5STZJSHMKICBLSUNBZ0lDQWdJQ0F
  pVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0FnSUNKamNuWWlPa
  UFpUgogIFdRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKYVM
  xaFJRemxwV1Y5aFYwbEtlazlXYUhnCiAgelZUSnZRbTAwV0VaT2ExSkViMkpxZ
  UVVeFUxbHhlWGw0TlhaS1prRXRUMEpXQ2lBZ056QlNZVWRJWDNSV1oKICB6Wm1
  ha0Z4ZGtSUE1rOW9URFJCSW4xOWZTd0tJQ0FnSUNKQlkyTnZkVzUwUVdSa2NtV
  npjeUk2SUNKaGJHbAogIGpaVUJsZUdGdGNHeGxMbU52YlNJc0NpQWdJQ0FpVTJ
  WeWRtbGpaVlZrWmlJNklDSk5Ra05KTFZRMFZqY3RRCiAgVWxDTkMxSFRVZ3pMV
  FJETmxJdFMwUTFVQzFKUTA4eklpd0tJQ0FnSUNKQlkyTnZkVzUwUlc1amNubHd
  kR2wKICB2YmlJNklIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlExUlVMVEpNUmxFd
  FdGTkROUzFXTTA5TUxVVldUMU10VAogIGsxUlZTMVpUME0ySWl3S0lDQWdJQ0F
  nSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBCiAgZ0lsQ
  jFZbXhwWTB0bGVVVkRSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0l
  sZzBORGdpTEFvZ0kKICBDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSkNUMUZVY
  TIwNFptSlZaSEZUZGtodFRrTnpWVmx6Y2tRMlRWWgogIE9lV2hNYXpONVdGOVB
  VRUpJY1hodk5tMVJUMmRVTlRaRkNpQWdaRVZEYTFwZk9VRTJTM0ZGWTJwQmJHS
  mZNCiAgbll0TjFWQkluMTlmU3dLSUNBZ0lDSkJaRzFwYm1semRISmhkRzl5VTJ
  sbmJtRjBkWEpsSWpvZ2V3b2dJQ0EKICBnSUNBaVZXUm1Jam9nSWsxQ1JsVXRXV
  TAzUWkxRFNrTTBMVWhFVEZVdFMxSllOUzFWV0VNMUxVdFpRbE1pTAogIEFvZ0l
  DQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2xqUzJWCiAgNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0kKICBsQjFZbXhwWXlJNklDS
  mFTMWhSUXpscFdWOWhWMGxLZWs5V2FIZ3pWVEp2UW0wMFdFWk9hMUpFYjJKcWV
  FVQogIHhVMWx4ZVhsNE5YWktaa0V0VDBKV0NpQWdOekJTWVVkSVgzUldaelptY
  WtGeGRrUlBNazlvVERSQkluMTlmCiAgU3dLSUNBZ0lDSkJZMk52ZFc1MFFYVjB
  hR1Z1ZEdsallYUnBiMjRpT2lCN0NpQWdJQ0FnSUNKVlpHWWlPaUEKICBpVFVKY
  VRpMVNUMDFYTFVvM1RUSXRXVmd5VUMxYVdrTTFMVFZPTkVZdFVVWkxXU0lzQ2l
  BZ0lDQWdJQ0pRZAogIFdKc2FXTlFZWEpoYldWMFpYSnpJam9nZXdvZ0lDQWdJQ
  0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvCiAgZ0lDQWdJQ0FnSUNBZ0l
  tTnlkaUk2SUNKWU5EUTRJaXdLSUNBZ0lDQWdJQ0FnSUNKUWRXSnNhV01pT2lBa
  U0KICBVeElPV3BGYWpWMlVsVnRkMlJuZFZWV1pGb3pTVTFCU0hnM1RqRldlakp
  wTjI5SGNVaEpSV3hTUTFoTGNXdAogIHhjbUozZGdvZ0lGOXFPRWx5YW5JMGVFb
  DRaazVCU2xOV1RGVjFiRzVGUVNKOWZYMHNDaUFnSUNBaVFXTmpiCiAgM1Z1ZEZ
  OcFoyNWhkSFZ5WlNJNklIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlJFMUVMVXBVU
  2xrdFIxbERWaTEKICBRUmsxVExVeFZVME10TWxGYU5TMU5UVnBISWl3S0lDQWd
  JQ0FnSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pTwogIGlCN0NpQWdJQ0FnSUNBZ
  0lsQjFZbXhwWTB0bGVVVkRSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWp
  vCiAgZ0lrVmtORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlWR
  lppZEdjeFMweHpkV1U1YjFkMVoKICBVMUVPRGhsU25sSFpsaG9ZbWt0WDJOd1R
  sQXlhWEZyVTNBNVdIQjJVVkJGTTFOU1JBb2dJSGhxT0Rnek1YQgogIGtlalF3Y
  lUxVVVsWTJZMGR3VjJwM1FTSjlmWDE5ZlEiLAogICAgICAgICAgewogICAgICA
  gICAgICAic2lnbmF0dXJlcyI6IFt7CiAgICAgICAgICAgICAgICAiYWxnIjogI
  lM1MTIiLAogICAgICAgICAgICAgICAgImtpZCI6ICJNQkZVLVlNN0ItQ0pDNC1
  IRExVLUtSWDUtVVhDNS1LWUJTIiwKICAgICAgICAgICAgICAgICJzaWduYXR1c
  mUiOiAiTU1UWnBPQVQweERWRV9BOUpLclhxS0tUaWpZdDlhVG5vLUhQcE9Xb2Q
  5UEh4Slg2UwogIFVxR0x6YmRCMWRBM3ZqTTZ5TEYyRml3WG1zQU5GQTktZUxnc
  DRRNHJWbU83cGw5TWZ0cEx5MTE2R2FnYkRqCiAgN1NwTVBNNlVDUXlFZ0dpdnJ
  lODU4elhFSTUtNU5YSzdtZWY5OWxSOEEifV0sCiAgICAgICAgICAgICJQYXlsb
  2FkRGlnZXN0IjogIjh2bEVvT2FBQS1BWU9XVWZVaW9jaTViaEZ6aThFSm1jRFd
  ucnBzVDlFVEFBZgogIGFXTm9UUTlvQnl1aGRPTEhXSXpLdVVuZ2F2OWZiUk9qN
  XVsRlNULWt3In1dLAogICAgICAgICJQcm90b2NvbHMiOiBbewogICAgICAgICA
  gICAiUHJvdG9jb2wiOiAibW1tIn1dfV19fQ",
                    {
                      "signatures": [{
                          "alg": "S512",
                          "kid": "MDMD-JTJY-GYCV-PFMS-LUSC-2QZ5-MMZG",
                          "signature": "6iUOj9GDB2BmgzHGlDoF3VOdktcCKkddv0Gh8uT1aE3J9gCbH
  709Lv5g412bUezsM1s8OwuXE7AAACSC8RalElfJ82ACdOu2iyHTTMMxMPQPsvj
  iDrE6P_YQ_o7F7619p2iC-QlLHyLTFag6S7FHqyYA"}],
                      "PayloadDigest": "qESwB7NiN67h6XmvOtRIF3DG6aSYS3hzwIoyy45Bx4jID
  ZTd1eWeeewvwZ4J6eV_TesvEeDd5n6N5SoofO86jA"}]}]}}}}]}}
</div>
~~~~


