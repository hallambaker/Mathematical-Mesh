

# network

~~~~
<div="helptext">
<over>
network    Manage network profile settings
    add   Add calendar entry from file
    delete   Delete calendar entry
    get   Lookup calendar entry
    import   Add calendar entry from file
    list   List network entries
<over>
</div>
~~~~


# network add

~~~~
<div="helptext">
<over>
add   Add calendar entry from file
       <Unspecified>
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
<cmd>Alice> network add NetworkEntry1.json NetID1
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> network add NetworkEntry1.json NetID1 /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "Cannot access a closed file."}}
</div>
~~~~


# network delete

~~~~
<div="helptext">
<over>
delete   Delete calendar entry
       Network entry identifier
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
<cmd>Alice> network delete NetID2
<rsp>ERROR - The entry could not be found in the store.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> network delete NetID2 /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The entry could not be found in the store."}}
</div>
~~~~


# network get

~~~~
<div="helptext">
<over>
get   Lookup calendar entry
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
<cmd>Alice> network get NetID2
<rsp>Empty
</div>
~~~~

Specifying the /json option returns a result of type ResultEntry:

~~~~
<div="terminal">
<cmd>Alice> network get NetID2 /json
<rsp>{
  "ResultEntry": {
    "Success": false}}
</div>
~~~~


# network list

~~~~
<div="helptext">
<over>
list   List network entries
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
<cmd>Alice> network list
<rsp>Entry<CatalogedContact>: MDUR-4AKJ-GEI7-7NXU-HZMM-C2N3-34S5
  Person MDUR-4AKJ-GEI7-7NXU-HZMM-C2N3-34S5
  Anchor MDUR-4AKJ-GEI7-7NXU-HZMM-C2N3-34S5
  Address alice@example.com

</div>
~~~~

Specifying the /json option returns a result of type ResultDump:

~~~~
<div="terminal">
<cmd>Alice> network list /json
<rsp>{
  "ResultDump": {
    "Success": true,
    "CatalogedEntries": [{
        "CatalogedContact": {
          "Key": "MDUR-4AKJ-GEI7-7NXU-HZMM-C2N3-34S5",
          "Self": true,
          "Contact": {
            "ContactPerson": {
              "Id": "MDUR-4AKJ-GEI7-7NXU-HZMM-C2N3-34S5",
              "Anchors": [{
                  "Udf": "MDUR-4AKJ-GEI7-7NXU-HZMM-C2N3-34S5",
                  "Validation": "Self"}],
              "NetworkAddresses": [{
                  "Address": "alice@example.com",
                  "EnvelopedProfileAccount": [{
                      "EnvelopeID": "MDUR-4AKJ-GEI7-7NXU-HZMM-C2N3-34S5",
                      "dig": "S512",
                      "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNRFVSLTRBS0otR0VJNy0
  3TlhVLUhaTU0tQzJOMy0zNFM1IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0xMC0yMVQxNDoyODozMFoifQ"},
                    "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1EVVItNEFLSi1HRUk3LTdOW
  FUtSFpNTS1DMk4zLTM0UzUiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJVUTdDSk1hRzVIR1JwWmlPNlR
  uYWV6dFRPSVNNVkxvN0EzTVFOdVhWVUM2WFBsT28xbkl3CiAgM2pEV01KZ3pzN
  DF5LWhsWEN5MTFiTDJBIn19fSwKICAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGl
  jZUBleGFtcGxlLmNvbSIsCiAgICAiU2VydmljZVVkZiI6ICJNQ1FOLVhTUUItQ
  kZTSC1EVUlPLTc1UVItT082SC1WUURVIiwKICAgICJBY2NvdW50RW5jcnlwdGl
  vbiI6IHsKICAgICAgIlVkZiI6ICJNQURRLTNOVzYtU0hYRi1MNlg2LU5JMk8tQ
  0Y3QS1YNVk3IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogI
  CAgICAgICAgIlB1YmxpYyI6ICIwNzRGTV9KRWZGbEhQdE1TZFl0cld1dko2LTJ
  FNS1MbUNhdWNMMXJpdml0MzE3M25jOTZuCiAgU01OdjF4SU9vZzBTWnAxNWJhO
  GFwT0lBIn19fSwKICAgICJBZG1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogICA
  gICAiVWRmIjogIk1EVVItNEFLSi1HRUk3LTdOWFUtSFpNTS1DMk4zLTM0UzUiL
  AogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V
  5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJVUTdDSk1hRzVIR1JwWmlPNlRuYWV6dFRPSVNNVkxvN0EzTVF
  OdVhWVUM2WFBsT28xbkl3CiAgM2pEV01KZ3pzNDF5LWhsWEN5MTFiTDJBIn19f
  SwKICAgICJBY2NvdW50QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiA
  iTUM1Ty1MVVJFLTVKNVUtU0FOWS1MQkhJLVJQUU4tNjY3NSIsCiAgICAgICJQd
  WJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewo
  gICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiQ
  XYxYVFBSXJ2Yk83M1Zob25pSC1JbVBaZk5BNnhpT09Id1oxWER4RDJDQVBkSnN
  nRFZ1dgogIDdOd0lOVERCX2c2WGxNYU5xMGVTOVJzQSJ9fX0sCiAgICAiQWNjb
  3VudFNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQkdOLVhRSjYtVUpORS0
  1SFZYLTZSQ0EtQ1BOTC1VRTRFIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiO
  iB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ijo
  gIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAidVIxLS14NEw1aExKTXlLV
  mtDc1MwMWdxMVNkdGJMcmFNYlNzaUNRR1FTTFNhUkx5ZzBIegogIE5nZ1FIU2p
  WQUFIaHlpMDlDVDQ5Sm9zQSJ9fX19fQ",
                    {
                      "signatures": [{
                          "alg": "S512",
                          "kid": "MDUR-4AKJ-GEI7-7NXU-HZMM-C2N3-34S5",
                          "signature": "czHjTKj7kFcBnOrqKG0hpWTPTjSP6vY1mWzpLG9nxWpxog9IA
  LUSoQ04Ip-MUByf7oAcTMNGrkgA9Qm5q33TFuttqD57aSjhGVE2I2HWssHhrAj
  xgchwwEmP5ArSyeit1mAXtnk7f3DcuwuNXZcEJAwA"}],
                      "PayloadDigest": "ZJmoM-pLooex2hV6btC-4Y5VgWYyRsNeiF9b1Ze11y-53
  Y__8g4scXY1xyye11S7_hu2viByH0m4PiTzMK9y5g"}],
                  "Protocols": [{
                      "Protocol": "mmm"}]}],
              "Sources": [{
                  "Validation": "Self",
                  "EnvelopedSource": [{
                      "dig": "S512",
                      "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjAtMTAtMjFUMTQ6Mjg6MzFaIn0"},
                    "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTURVUi00QUtKLUdFSTctN05YVS1IW
  k1NLUMyTjMtMzRTNSIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAgICAgIkVudmVsb3BlZFByb2ZpbGV
  BY2NvdW50IjogW3sKICAgICAgICAgICAgIkVudmVsb3BlSUQiOiAiTURVUi00Q
  UtKLUdFSTctN05YVS1IWk1NLUMyTjMtMzRTNSIsCiAgICAgICAgICAgICJkaWc
  iOiAiUzUxMiIsCiAgICAgICAgICAgICJDb250ZW50TWV0YURhdGEiOiAiZXdvZ
  0lDSlZibWx4ZFdWSlJDSTZJQ0pOUkZWU0xUUkJTMG90UjBWSk55MAogIDNUbGh
  WTFVoYVRVMHRRekpPTXkwek5GTTFJaXdLSUNBaVRXVnpjMkZuWlZSNWNHVWlPa
  UFpVUhKdlptbHNaCiAgVlZ6WlhJaUxBb2dJQ0pqZEhraU9pQWlZWEJ3Ykdsall
  YUnBiMjR2YlcxdEwyOWlhbVZqZENJc0NpQWdJa04KICB5WldGMFpXUWlPaUFpT
  WpBeU1DMHhNQzB5TVZReE5Eb3lPRG96TUZvaWZRIn0sCiAgICAgICAgICAiZXd
  vZ0lDSlFjbTltYVd4bFZYTmxjaUk2SUhzS0lDQWdJQ0pRY205bWFXeAogIGxVM
  mxuYm1GMGRYSmxJam9nZXdvZ0lDQWdJQ0FpVldSbUlqb2dJazFFVlZJdE5FRkx
  TaTFIUlVrM0xUZE9XCiAgRlV0U0ZwTlRTMURNazR6TFRNMFV6VWlMQW9nSUNBZ
  0lDQWlVSFZpYkdsalVHRnlZVzFsZEdWeWN5STZJSHMKICBLSUNBZ0lDQWdJQ0F
  pVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0FnSUNKamNuWWlPa
  UFpUgogIFdRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKVlV
  UZERTazFoUnpWSVIxSndXbWxQTmxSCiAgdVlXVjZkRlJQU1ZOTlZreHZOMEV6V
  FZGT2RWaFdWVU0yV0ZCc1QyOHhia2wzQ2lBZ00ycEVWMDFLWjNwek4KICBERjV
  MV2hzV0VONU1URmlUREpCSW4xOWZTd0tJQ0FnSUNKQlkyTnZkVzUwUVdSa2NtV
  npjeUk2SUNKaGJHbAogIGpaVUJsZUdGdGNHeGxMbU52YlNJc0NpQWdJQ0FpVTJ
  WeWRtbGpaVlZrWmlJNklDSk5RMUZPTFZoVFVVSXRRCiAga1pUU0MxRVZVbFBMV
  GMxVVZJdFQwODJTQzFXVVVSVklpd0tJQ0FnSUNKQlkyTnZkVzUwUlc1amNubHd
  kR2wKICB2YmlJNklIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlFVUlJMVE5PVnpZd
  FUwaFlSaTFNTmxnMkxVNUpNazh0UQogIDBZM1FTMVlOVmszSWl3S0lDQWdJQ0F
  nSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBCiAgZ0lsQ
  jFZbXhwWTB0bGVVVkRSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0l
  sZzBORGdpTEFvZ0kKICBDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSXdOelJHV
  FY5S1JXWkdiRWhRZEUxVFpGbDBjbGQxZGtvMkxUSgogIEZOUzFNYlVOaGRXTk1
  NWEpwZG1sME16RTNNMjVqT1RadUNpQWdVMDFPZGpGNFNVOXZaekJUV25BeE5XS
  mhPCiAgR0Z3VDBsQkluMTlmU3dLSUNBZ0lDSkJaRzFwYm1semRISmhkRzl5VTJ
  sbmJtRjBkWEpsSWpvZ2V3b2dJQ0EKICBnSUNBaVZXUm1Jam9nSWsxRVZWSXROR
  UZMU2kxSFJVazNMVGRPV0ZVdFNGcE5UUzFETWs0ekxUTTBVelVpTAogIEFvZ0l
  DQWdJQ0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2xqUzJWCiAgNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVJXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0kKICBsQjFZbXhwWXlJNklDS
  lZVVGREU2sxaFJ6VklSMUp3V21sUE5sUnVZV1Y2ZEZSUFNWTk5Wa3h2TjBFelR
  WRgogIE9kVmhXVlVNMldGQnNUMjh4YmtsM0NpQWdNMnBFVjAxS1ozcHpOREY1T
  Fdoc1dFTjVNVEZpVERKQkluMTlmCiAgU3dLSUNBZ0lDSkJZMk52ZFc1MFFYVjB
  hR1Z1ZEdsallYUnBiMjRpT2lCN0NpQWdJQ0FnSUNKVlpHWWlPaUEKICBpVFVNM
  VR5MU1WVkpGTFRWS05WVXRVMEZPV1MxTVFraEpMVkpRVVU0dE5qWTNOU0lzQ2l
  BZ0lDQWdJQ0pRZAogIFdKc2FXTlFZWEpoYldWMFpYSnpJam9nZXdvZ0lDQWdJQ
  0FnSUNKUWRXSnNhV05MWlhsRlEwUklJam9nZXdvCiAgZ0lDQWdJQ0FnSUNBZ0l
  tTnlkaUk2SUNKWU5EUTRJaXdLSUNBZ0lDQWdJQ0FnSUNKUWRXSnNhV01pT2lBa
  VEKICBYWXhZVkZCU1hKMllrODNNMVpvYjI1cFNDMUpiVkJhWms1Qk5uaHBUMDl
  JZDFveFdFUjRSREpEUVZCa1NuTgogIG5SRloxZGdvZ0lEZE9kMGxPVkVSQ1gyY
  zJXR3hOWVU1eE1HVlRPVkp6UVNKOWZYMHNDaUFnSUNBaVFXTmpiCiAgM1Z1ZEZ
  OcFoyNWhkSFZ5WlNJNklIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlFrZE9MVmhSU
  2pZdFZVcE9SUzAKICAxU0ZaWUxUWlNRMEV0UTFCT1RDMVZSVFJGSWl3S0lDQWd
  JQ0FnSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pTwogIGlCN0NpQWdJQ0FnSUNBZ
  0lsQjFZbXhwWTB0bGVVVkRSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWp
  vCiAgZ0lrVmtORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlkV
  kl4TFMxNE5FdzFhRXhLVFhsTFYKICBtdERjMU13TVdkeE1WTmtkR0pNY21GTll
  sTnphVU5SUjFGVFRGTmhVa3g1WnpCSWVnb2dJRTVuWjFGSVUycAogIFdRVUZJY
  UhscE1EbERWRFE1U205elFTSjlmWDE5ZlEiLAogICAgICAgICAgewogICAgICA
  gICAgICAic2lnbmF0dXJlcyI6IFt7CiAgICAgICAgICAgICAgICAiYWxnIjogI
  lM1MTIiLAogICAgICAgICAgICAgICAgImtpZCI6ICJNRFVSLTRBS0otR0VJNy0
  3TlhVLUhaTU0tQzJOMy0zNFM1IiwKICAgICAgICAgICAgICAgICJzaWduYXR1c
  mUiOiAiY3pIalRLajdrRmNCbk9ycUtHMGhwV1RQVGpTUDZ2WTFtV3pwTEc5bnh
  XcHhvZzlJQQogIExVU29RMDRJcC1NVUJ5ZjdvQWNUTU5HcmtnQTlRbTVxMzNUR
  nV0dHFENTdhU2poR1ZFMkkySFdzc0hockFqCiAgeGdjaHd3RW1QNUFyU3llaXQ
  xbUFYdG5rN2YzRGN1d3VOWFpjRUpBd0EifV0sCiAgICAgICAgICAgICJQYXlsb
  2FkRGlnZXN0IjogIlpKbW9NLXBMb29leDJoVjZidEMtNFk1VmdXWXlSc05laUY
  5YjFaZTExeS01MwogIFlfXzhnNHNjWFkxeHl5ZTExUzdfaHUydmlCeUgwbTRQa
  VR6TUs5eTVnIn1dLAogICAgICAgICJQcm90b2NvbHMiOiBbewogICAgICAgICA
  gICAiUHJvdG9jb2wiOiAibW1tIn1dfV19fQ",
                    {
                      "signatures": [{
                          "alg": "S512",
                          "kid": "MBGN-XQJ6-UJNE-5HVX-6RCA-CPNL-UE4E",
                          "signature": "suRKPGD51ugY6SK-m-voyTRVfGWU_IehWTsGyIOHnT4mzfcDP
  Sp4IbphMks_aSt1UdfWyx-hXdcAvY7Ial0GfifEiwehAYWRfZe281lpRW6hJg5
  ByUn3UZ_vIIpRAU3D3PkglW4XC9IcaH-N3_laYQcA"}],
                      "PayloadDigest": "HVHUDKwk9DUAlJxp216FnVmWLeadol8-95CA1QTuCyP7x
  Vey8rrjdKLiXW7i6wNxyGguT_6PKSR0q4HKkJAVCQ"}]}]}}}}]}}
</div>
~~~~


