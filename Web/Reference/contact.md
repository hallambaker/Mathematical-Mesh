

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
<rsp>Entry<CatalogedContact>: MAQJ-32QZ-HFDM-M2MZ-PR57-3FSO-4CH4
  Person MAQJ-32QZ-HFDM-M2MZ-PR57-3FSO-4CH4
  Anchor MAQJ-32QZ-HFDM-M2MZ-PR57-3FSO-4CH4
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
          "Key": "MAQJ-32QZ-HFDM-M2MZ-PR57-3FSO-4CH4",
          "Self": true,
          "Contact": {
            "ContactPerson": {
              "Id": "MAQJ-32QZ-HFDM-M2MZ-PR57-3FSO-4CH4",
              "Anchors": [{
                  "UDF": "MAQJ-32QZ-HFDM-M2MZ-PR57-3FSO-4CH4",
                  "Validation": "Self"}],
              "NetworkAddresses": [{
                  "Address": "alice@example.com",
                  "EnvelopedProfileAccount": [{
                      "EnvelopeID": "MAQJ-32QZ-HFDM-M2MZ-PR57-3FSO-4CH4",
                      "dig": "S512",
                      "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQVFKLTMyUVotSEZETS1
  NMk1aLVBSNTctM0ZTTy00Q0g0IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0wOS0yMlQxMzoxMjo1N1oifQ"},
                    "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJPZmZsaW5
  lU2lnbmF0dXJlIjogewogICAgICAiVURGIjogIk1BUUotMzJRWi1IRkRNLU0yT
  VotUFI1Ny0zRlNPLTRDSDQiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICItaUM4aHJxbXloREdpbS0wb29
  wZnQ0NUtrY2JlbjZMVjlhZDVXOUMwaW43c0gyQjVtOFo2CiAgQUsxV0wwYVJtS
  nZrX1Q3Um9KZkNocy1BIn19fSwKICAgICJBY2NvdW50QWRkcmVzc2VzIjogWyJ
  hbGljZUBleGFtcGxlLmNvbSJdLAogICAgIkFjY291bnRFbmNyeXB0aW9uIjoge
  wogICAgICAiVURGIjogIk1BVFEtU1dDSS02NkFXLTNXSDctVDVJTS1IUUhSLTJ
  KR0MiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVib
  GljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICA
  gICAiUHVibGljIjogIjJubXQ5OWZXUWdQWXdENGpSQ2JxX2xzaUxPY1h0RnVtZ
  zBCTjI2OTRCa3c5M1lRUElnT0gKICBoNjdfVGdCWG1oU2s1WVVCNndtdS1qZUE
  ifX19LAogICAgIkVudmVsb3BlZFByb2ZpbGVTZXJ2aWNlIjogW3sKICAgICAgI
  CAiRW52ZWxvcGVJRCI6ICJNREdaLUVTR00tTUNTRS0zQlhZLUI0TUUtQk9PWC1
  GRllBIiwKICAgICAgICAiZGlnIjogIlM1MTIiLAogICAgICAgICJDb250ZW50T
  WV0YURhdGEiOiAiZXdvZ0lDSlZibWx4ZFdWSlJDSTZJQ0pOUkVkYUxVVlRSMDB
  0VFVOVFJTMAogIHpRbGhaTFVJMFRVVXRRazlQV0MxR1JsbEJJaXdLSUNBaVRXV
  npjMkZuWlZSNWNHVWlPaUFpVUhKdlptbHNaCiAgVk5sY25acFkyVWlMQW9nSUN
  KamRIa2lPaUFpWVhCd2JHbGpZWFJwYjI0dmJXMXRMMjlpYW1WamRDSXNDaUEKI
  CBnSWtOeVpXRjBaV1FpT2lBaU1qQXlNQzB3T1MweU1sUXhNem94TWpvMU4xb2l
  mUSJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFUyVnlkbWxqWlNJNklIc0tJQ
  0FnSUNKUFptWgogIHNhVzVsVTJsbmJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZ
  VUkdJam9nSWsxRVIxb3RSVk5IVFMxTlExTkZMCiAgVE5DV0ZrdFFqUk5SUzFDV
  DA5WUxVWkdXVUVpTEFvZ0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk
  KICA2SUhzS0lDQWdJQ0FnSUNBaVVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQ
  WdJQ0FnSUNBZ0lDSmpjbllpTwogIGlBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUN
  BZ0lsQjFZbXhwWXlJNklDSk5RMGt4V0hObVowTk1aaTB0ZUVwCiAgdWJEbFFab
  nBOVm1sUE56bFJZbUZTTVcxS1luUktObDh4UTBjMGFGVkdSRjlPUVVJMENpQWd
  jV052VFZsRlUKICBWRXlZMHBDTjNjNVRrSjBZbTF0TTBkQkluMTlmU3dLSUNBZ
  0lDSkxaWGxGYm1OeWVYQjBhVzl1SWpvZ2V3bwogIGdJQ0FnSUNBaVZVUkdJam9
  nSWsxQ1NGSXRNMHMxUlMxVk0wRllMVWxVVUV3dFZFTk5VQzFXVlZCQ0xWUkRXC
  iAgRmtpTEFvZ0lDQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0l
  DQWdJQ0FnSUNBaVVIVmliR2wKICBqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnS
  UNBZ0lDSmpjbllpT2lBaVdEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSQogIENBaVVIVml
  iR2xqSWpvZ0lqVlZXa2R6Y21aMVRIbFRRVVZTWDFWRWIwSlVUM04xYVVRNFZtS
  lVUVXRNYms5CiAgTVptazBVWFZNY2prMFdsaDFkR3hXZVhVS0lDQllYM1F4ZGp
  NMVZqazFUREppVjJOSlpqTnRPVzVPWVVFaWYKICBYMTlmWDAiLAogICAgICB7C
  iAgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM
  1MTIiLAogICAgICAgICAgICAia2lkIjogIk1ER1otRVNHTS1NQ1NFLTNCWFktQ
  jRNRS1CT09YLUZGWUEiLAogICAgICAgICAgICAic2lnbmF0dXJlIjogIjBzQk5
  zU3B2VDM5ZVYzX1dFbGNzX3dUUlZReWo4TVRCRTJCNVNscUNIa0JNcTc0TTcKI
  CBIajg5T1RCX09PMVhfYUZzbEJ6ZUN5R3JBNEFiNkRpcFp1SjFIOWdnME1kTHB
  3alBLYUhrUTlfRW1wakJuNwogIF9UaXVpTGJVcExZRHZlVGlVR1Fkc0VrR3dWW
  WxyNXZiNF9SOEdBU01BIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIl9
  INHF5NWx0MWo4NTFTRWZrV01lb3VIRi1PamlNMDhFOXlIbE5idDdyOHhtVgogI
  DVhVXpQVG1ZRXV3S2xmdEQ5TFlGNF9SbGY5UkdqbGVYNGppazFhNjh3In1dLAo
  gICAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1BVEEtQ
  kNTVi1QTllILTZXT0YtRVJPQi1PNzVCLU8zTkoiLAogICAgICAiUHVibGljUGF
  yYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgI
  CAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIllOUHdjOTF
  wekxRZnBzMTdLYmh0cnMwLXVDZVhLb2FNZ3o4cGc1Tl82UVNXZlRRMFJESUIKI
  CAtTEF2d0dzM19FbXlqR1g1SWFtS1Z3MEEifX19fX0",
                    {
                      "signatures": [{
                          "alg": "S512",
                          "kid": "MAQJ-32QZ-HFDM-M2MZ-PR57-3FSO-4CH4",
                          "signature": "mMeH05n2TY8r-XiFEUl9ThuglEeY6jGMUHzKmB3_y7PUoa5wy
  b4-_v2tTFbMFumVEtBBI36RJAaASy2EeqmjBxyKLHWTsMWpmpXOw0GuqgBfpJs
  ZTBcGrF1vJoOOLwaa8KfPnqK6Y2dkIFF0yv5PHxEA"}],
                      "PayloadDigest": "QXNvSqjI1u2vCWL4DOefnI0N4H2IuTVkKy2Hud-OETq4g
  SgQF3bIRpoeakjQT1oDZkNdxqQ8VhDm-huhuwoSaQ"}],
                  "Protocols": [{
                      "Protocol": "mmm"}]}],
              "Sources": [{
                  "Validation": "Self",
                  "EnvelopedSource": [{
                      "dig": "S512",
                      "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjAtMDktMjJUMTM6MTI6NTdaIn0"},
                    "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVREYiOiAiTUFRSi0zMlFaLUhGRE0tTTJNWi1QU
  jU3LTNGU08tNENINCIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAgICAgIkVudmVsb3BlZFByb2ZpbGV
  BY2NvdW50IjogW3sKICAgICAgICAgICAgIkVudmVsb3BlSUQiOiAiTUFRSi0zM
  lFaLUhGRE0tTTJNWi1QUjU3LTNGU08tNENINCIsCiAgICAgICAgICAgICJkaWc
  iOiAiUzUxMiIsCiAgICAgICAgICAgICJDb250ZW50TWV0YURhdGEiOiAiZXdvZ
  0lDSlZibWx4ZFdWSlJDSTZJQ0pOUVZGS0xUTXlVVm90U0VaRVRTMQogIE5NazF
  hTFZCU05UY3RNMFpUVHkwMFEwZzBJaXdLSUNBaVRXVnpjMkZuWlZSNWNHVWlPa
  UFpVUhKdlptbHNaCiAgVlZ6WlhJaUxBb2dJQ0pqZEhraU9pQWlZWEJ3Ykdsall
  YUnBiMjR2YlcxdEwyOWlhbVZqZENJc0NpQWdJa04KICB5WldGMFpXUWlPaUFpT
  WpBeU1DMHdPUzB5TWxReE16b3hNam8xTjFvaWZRIn0sCiAgICAgICAgICAiZXd
  vZ0lDSlFjbTltYVd4bFZYTmxjaUk2SUhzS0lDQWdJQ0pQWm1ac2FXNQogIGxVM
  mxuYm1GMGRYSmxJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFCVVVvdE16SlJ
  XaTFJUmtSTkxVMHlUCiAgVm90VUZJMU55MHpSbE5QTFRSRFNEUWlMQW9nSUNBZ
  0lDQWlVSFZpYkdsalVHRnlZVzFsZEdWeWN5STZJSHMKICBLSUNBZ0lDQWdJQ0F
  pVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0FnSUNKamNuWWlPa
  UFpUgogIFdRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNJdGF
  VTTRhSEp4Ylhsb1JFZHBiUzB3YjI5CiAgd1puUTBOVXRyWTJKbGJqWk1WamxoW
  kRWWE9VTXdhVzQzYzBneVFqVnRPRm8yQ2lBZ1FVc3hWMHd3WVZKdFMKICBuWnJ
  YMVEzVW05S1prTm9jeTFCSW4xOWZTd0tJQ0FnSUNKQlkyTnZkVzUwUVdSa2NtV
  npjMlZ6SWpvZ1d5SgogIGhiR2xqWlVCbGVHRnRjR3hsTG1OdmJTSmRMQW9nSUN
  BZ0lrRmpZMjkxYm5SRmJtTnllWEIwYVc5dUlqb2dlCiAgd29nSUNBZ0lDQWlWV
  VJHSWpvZ0lrMUJWRkV0VTFkRFNTMDJOa0ZYTFROWFNEY3RWRFZKVFMxSVVVaFN
  MVEoKICBLUjBNaUxBb2dJQ0FnSUNBaVVIVmliR2xqVUdGeVlXMWxkR1Z5Y3lJN
  klIc0tJQ0FnSUNBZ0lDQWlVSFZpYgogIEdsalMyVjVSVU5FU0NJNklIc0tJQ0F
  nSUNBZ0lDQWdJQ0pqY25ZaU9pQWlXRFEwT0NJc0NpQWdJQ0FnSUNBCiAgZ0lDQ
  WlVSFZpYkdsaklqb2dJakp1YlhRNU9XWlhVV2RRV1hkRU5HcFNRMkp4WDJ4emF
  VeFBZMWgwUm5WdFoKICB6QkNUakkyT1RSQ2EzYzVNMWxSVUVsblQwZ0tJQ0JvT
  mpkZlZHZENXRzFvVTJzMVdWVkNObmR0ZFMxcVpVRQogIGlmWDE5TEFvZ0lDQWd
  Ja1Z1ZG1Wc2IzQmxaRkJ5YjJacGJHVlRaWEoyYVdObElqb2dXM3NLSUNBZ0lDQ
  WdJCiAgQ0FpUlc1MlpXeHZjR1ZKUkNJNklDSk5SRWRhTFVWVFIwMHRUVU5UUlM
  welFsaFpMVUkwVFVVdFFrOVBXQzEKICBHUmxsQklpd0tJQ0FnSUNBZ0lDQWlaR
  2xuSWpvZ0lsTTFNVElpTEFvZ0lDQWdJQ0FnSUNKRGIyNTBaVzUwVAogIFdWMFl
  VUmhkR0VpT2lBaVpYZHZaMGxEU2xaaWJXeDRaRmRXU2xKRFNUWkpRMHBPVWtWa
  1lVeFZWbFJTTURCCiAgMFZGVk9WRkpUTUFvZ0lIcFJiR2hhVEZWSk1GUlZWWFJ
  SYXpsUVYwTXhSMUpzYkVKSmFYZExTVU5CYVZSWFYKICBucGpNa1p1V2xaU05XT
  khWV2xQYVVGcFZVaEtkbHB0YkhOYUNpQWdWazVzWTI1YWNGa3lWV2xNUVc5blN
  VTgogIEthbVJJYTJsUGFVRnBXVmhDZDJKSGJHcFpXRkp3WWpJMGRtSlhNWFJNT
  WpscFlXMVdhbVJEU1hORGFVRUtJCiAgQ0JuU1d0T2VWcFhSakJhVjFGcFQybEJ
  hVTFxUVhsTlF6QjNUMU13ZVUxc1VYaE5lbTk0VFdwdk1VNHhiMmwKICBtVVNKO
  UxBb2dJQ0FnSUNBaVpYZHZaMGxEU2xGamJUbHRZVmQ0YkZVeVZubGtiV3hxV2x
  OSk5rbEljMHRKUQogIDBGblNVTktVRnB0V2dvZ0lITmhWelZzVlRKc2JtSnRSa
  kJrV0Vwc1NXcHZaMlYzYjJkSlEwRm5TVU5CYVZaCiAgVlVrZEphbTluU1dzeFJ
  WSXhiM1JTVms1SVZGTXhUbEV4VGtaTUNpQWdWRTVEVjBacmRGRnFVazVTVXpGR
  FYKICBEQTVXVXhWV2tkWFZVVnBURUZ2WjBsRFFXZEpRMEZwVlVoV2FXSkhiR3B
  WUjBaNVdWY3hiR1JIVm5samVVawogIEtJQ0EyU1VoelMwbERRV2RKUTBGblNVT
  kJhVlZJVm1saVIyeHFVekpXTlZKVlRrVlRRMGsyU1VoelMwbERRCiAgV2RKUTB
  GblNVTkJaMGxEU21wamJsbHBUd29nSUdsQmFWSlhVVEJPUkdkcFRFRnZaMGxEU
  VdkSlEwRm5TVU4KICBCWjBsc1FqRlpiWGh3V1hsSk5rbERTazVSTUd0NFYwaE9
  iVm93VGsxYWFUQjBaVVZ3Q2lBZ2RXSkViRkZhYgogIG5CT1ZtMXNVRTU2YkZKW
  mJVWlRUVmN4UzFsdVVrdE9iRGg0VVRCak1HRkdWa2RTUmpsUFVWVkpNRU5wUVd
  kCiAgalYwNTJWRlpzUmxVS0lDQldSWGxaTUhCRFRqTmpOVlJyU2pCWmJURjBUV
  EJrUWtsdU1UbG1VM2RMU1VOQloKICAwbERTa3hhV0d4R1ltMU9lV1ZZUWpCaFZ
  6bDFTV3B2WjJWM2J3b2dJR2RKUTBGblNVTkJhVlpWVWtkSmFtOQogIG5TV3N4U
  TFOR1NYUk5NSE14VWxNeFZrMHdSbGxNVld4VlZVVjNkRlpGVGs1VlF6RlhWbFp
  DUTB4V1VrUlhDCiAgaUFnUm10cFRFRnZaMGxEUVdkSlEwRnBWVWhXYVdKSGJHc
  FZSMFo1V1ZjeGJHUkhWbmxqZVVrMlNVaHpTMGwKICBEUVdkSlEwRm5TVU5CYVZ
  WSVZtbGlSMndLSUNCcVV6SldOVkpWVGtWVFEwazJTVWh6UzBsRFFXZEpRMEZuU
  wogIFVOQlowbERTbXBqYmxscFQybEJhVmRFVVRCUFEwbHpRMmxCWjBsRFFXZEp
  RMEZuU1FvZ0lFTkJhVlZJVm1sCiAgaVIyeHFTV3B2WjBscVZsWlhhMlI2WTIxY
  U1WUkliRlJSVlZaVFdERldSV0l3U2xWVU0wNHhZVlZSTkZadFMKICBsVlVWWFJ
  OWW1zNUNpQWdUVnB0YXpCVldGWk5ZMnByTUZkc2FERmtSM2hYWlZoVlMwbERRb
  GxZTTFGNFpHcAogIE5NVlpxYXpGVVJFcHBWakpPU2xwcVRuUlBWelZQV1ZWRmF
  XWUtJQ0JZTVRsbVdEQWlMQW9nSUNBZ0lDQjdDCiAgaUFnSUNBZ0lDQWdJbk5wW
  jI1aGRIVnlaWE1pT2lCYmV3b2dJQ0FnSUNBZ0lDQWdJQ0FpWVd4bklqb2dJbE0
  KICAxTVRJaUxBb2dJQ0FnSUNBZ0lDQWdJQ0FpYTJsa0lqb2dJazFFUjFvdFJWT
  khUUzFOUTFORkxUTkNXRmt0UQogIGpSTlJTMUNUMDlZTFVaR1dVRWlMQW9nSUN
  BZ0lDQWdJQ0FnSUNBaWMybG5ibUYwZFhKbElqb2dJakJ6UWs1CiAgelUzQjJWR
  E01WlZZelgxZEZiR056WDNkVVVsWlJlV280VFZSQ1JUSkNOVk5zY1VOSWEwSk5
  jVGMwVFRjS0kKICBDQklhamc1VDFSQ1gwOVBNVmhmWVVaemJFSjZaVU41UjNKQ
  k5FRmlOa1JwY0ZwMVNqRklPV2RuTUUxa1RIQgogIDNhbEJMWVVoclVUbGZSVzF
  3YWtKdU53b2dJRjlVYVhWcFRHSlZjRXhaUkhabFZHbFZSMUZrYzBWclIzZFdXC
  iAgV3h5TlhaaU5GOVNPRWRCVTAxQkluMWRMQW9nSUNBZ0lDQWdJQ0pRWVhsc2I
  yRmtSR2xuWlhOMElqb2dJbDkKICBJTkhGNU5XeDBNV280TlRGVFJXWnJWMDFsY
  jNWSVJpMVBhbWxOTURoRk9YbEliRTVpZERkeU9IaHRWZ29nSQogIERWaFZYcFF
  WRzFaUlhWM1MyeG1kRVE1VEZsR05GOVNiR1k1VWtkcWJHVllOR3BwYXpGaE5qa
  DNJbjFkTEFvCiAgZ0lDQWdJa3RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXd
  vZ0lDQWdJQ0FpVlVSR0lqb2dJazFCVkVFdFEKICBrTlRWaTFRVGxsSUxUWlhUM
  Fl0UlZKUFFpMVBOelZDTFU4elRrb2lMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRgo
  gIHlZVzFsZEdWeWN5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVOR
  VNDSTZJSHNLSUNBZ0lDQWdJCiAgQ0FnSUNKamNuWWlPaUFpV0RRME9DSXNDaUF
  nSUNBZ0lDQWdJQ0FpVUhWaWJHbGpJam9nSWxsT1VIZGpPVEYKICB3ZWt4UlpuQ
  npNVGRMWW1oMGNuTXdMWFZEWlZoTGIyRk5aM280Y0djMVRsODJVVk5YWmxSUk1
  GSkVTVUlLSQogIENBdFRFRjJkMGR6TTE5RmJYbHFSMWcxU1dGdFMxWjNNRUVpZ
  lgxOWZYMCIsCiAgICAgICAgICB7CiAgICAgICAgICAgICJzaWduYXR1cmVzIjo
  gW3sKICAgICAgICAgICAgICAgICJhbGciOiAiUzUxMiIsCiAgICAgICAgICAgI
  CAgICAia2lkIjogIk1BUUotMzJRWi1IRkRNLU0yTVotUFI1Ny0zRlNPLTRDSDQ
  iLAogICAgICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJtTWVIMDVuMlRZOHItW
  GlGRVVsOVRodWdsRWVZNmpHTVVIekttQjNfeTdQVW9hNXd5CiAgYjQtX3YydFR
  GYk1GdW1WRXRCQkkzNlJKQWFBU3kyRWVxbWpCeHlLTEhXVHNNV3BtcFhPdzBHd
  XFnQmZwSnMKICBaVEJjR3JGMXZKb09PTHdhYThLZlBucUs2WTJka0lGRjB5djV
  QSHhFQSJ9XSwKICAgICAgICAgICAgIlBheWxvYWREaWdlc3QiOiAiUVhOdlNxa
  kkxdTJ2Q1dMNERPZWZuSTBONEgySXVUVmtLeTJIdWQtT0VUcTRnCiAgU2dRRjN
  iSVJwb2Vha2pRVDFvRFprTmR4cVE4VmhEbS1odWh1d29TYVEifV0sCiAgICAgI
  CAgIlByb3RvY29scyI6IFt7CiAgICAgICAgICAgICJQcm90b2NvbCI6ICJtbW0
  ifV19XX19",
                    {
                      "signatures": [{
                          "alg": "S512",
                          "kid": "MDQK-4EDQ-KXEL-LPIV-2JRB-WUFL-2F4E",
                          "signature": "T5SeooiPNRRPYAEOpAsql-rhyut333_eqAFTbm-QC08uBqUJO
  c52yH-E7LHbWko3ByNVqCHu5mYALRoEbX37i_z_h6YOBR47fhN755qpVX08Yl9
  ZKE58Z4olLpZJ35Po9-v2Kx6Q_6zdMEp6dkhWTy0A"}],
                      "PayloadDigest": "9TFbYcwWTetJd22-UVZr7AAYFajJNhXzuNGrX7u1yT7U8
  ba7ULezJa1G7EwuhrObgMofIgShnqxCVM5WN3dT_Q"}]}]}}}}]}}
</div>
~~~~


