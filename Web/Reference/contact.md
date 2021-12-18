

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
<cmd>Alice> meshman contact add email carol@example.com
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\email'.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> meshman contact add email carol@example.com /json
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
<cmd>Alice> meshman contact delete carol@example.com
<rsp>ERROR - The entry could not be found in the store.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> meshman contact delete carol@example.com /json
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
<cmd>Alice> meshman contact get carol@example.com
<rsp>
</div>
~~~~

Specifying the /json option returns a result of type ResultEntry:

~~~~
<div="terminal">
<cmd>Alice> meshman contact get carol@example.com /json
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
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N
  Person MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N
  Anchor MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N
  Address alice@example.com

Entry<CatalogedContact>: NAWB-M7G7-OXPC-I6YS-SIXH-JQ7E-OOXA
  Person 
  Anchor MBYX-JPOL-7H24-YL2Z-LOHO-7MWV-IFGG
  Address bob@example.com

Entry<CatalogedContact>: NBLD-QB2F-UVQD-MHP5-PHY3-J2MO-YUKD
  Person 
  Anchor MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK
  Address groupw@example.com

Entry<CatalogedContact>: NDXP-NDKS-PFFD-WBA7-VQ74-5KM5-355Y
  Person 
  Anchor MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK
  Address groupw@example.com

Entry<CatalogedContact>: NCC4-BLBH-RHO3-UHOG-YRJO-W4J2-JCNL
  Person 
  Anchor MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK
  Address groupw@example.com

</div>
~~~~

Specifying the /json option returns a result of type ResultDump:

~~~~
<div="terminal">
<cmd>Alice> meshman contact list /json
<rsp>{
  "ResultDump": {
    "Success": true,
    "CatalogedEntries": [{
        "CatalogedContact": {
          "Key": "MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N",
          "Self": true,
          "Contact": {
            "ContactPerson": {
              "Id": "MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N",
              "Anchors": [{
                  "Udf": "MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N",
                  "Validation": "Self"}],
              "NetworkAddresses": [{
                  "Address": "alice@example.com",
                  "EnvelopedProfileAccount": [{
                      "EnvelopeId": "MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N",
                      "dig": "S512",
                      "ContentMetaData": "ewogICJVbmlxdWVJZCI6ICJNQ0YyLVdZN0EtWUhMUi1
  XMk4zLTRHWEYtNFBVTy1aTzdOIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMS0xMi0xOFQwMTo1NzowM1oifQ"},
                    "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DRjItV1k3QS1ZSExSLVcyT
  jMtNEdYRi00UFVPLVpPN04iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJhLVhwem9xSkN5M2k2Mjlxakp
  3Znh1MUdtLWp6a3ZSY2pfUDVPeFJOMXM2blpNSzdzb0dkCiAgQnR6UXpQck80e
  UFaQmRMcHhRdkZ2Sm9BIn19fSwKICAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGl
  jZUBleGFtcGxlLmNvbSIsCiAgICAiU2VydmljZVVkZiI6ICJNQVdXLUQzVDYtV
  DVDNS1QN1NRLVFEWUYtSkdENy1LSEhVIiwKICAgICJFc2Nyb3dFbmNyeXB0aW9
  uIjogewogICAgICAiVWRmIjogIk1ETUgtRzQ0VS00WjM1LU1JVlktSVVGSC1TQ
  1Y2LTM0R1kiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICA
  iUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgI
  CAgICAgICAiUHVibGljIjogIlFvNXA0LXlBWUhzZUx0XzBLOVIxbkQ2ZzNEa04
  4UjF1UDNVbkhfdDJLaUJkWTM5WlpsVEUKICBhZ0dfc0hyajlPTHQ2WmdkM0ZHN
  TQ5OEEifX19LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogICAgICAiVWR
  mIjogIk1ETk0tUFpSRy1XTjVGLTJHVzQtUVNINi1YRVkyLUJFSEMiLAogICAgI
  CAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI
  6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljI
  jogImp5Si1Vd3lhUThON2VpVUhVVnNvNDVuZ2RuWlpFbGkwdFdIUmE5QXdtTi1
  WVEdWaGtVb3EKICBoZnU2eEpza05wWVhDODV4cU9DTjREd0EifX19LAogICAgI
  kFkbWluaXN0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTUFBMi1
  HTkI0LVJFVkQtRldLSS1RNUw3LTdESVMtSUpQUyIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICA
  gICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIktzNUJrR
  0hhblA0bGR4eFI0QjZkSmV2LVFwTFlEd01XYm5ITGd2czEyd2R6UTJCbEtSSV8
  KICBXdlhiWlpYYWhxWFFpM1JHMWhlVG1JZ0EifX19LAogICAgIkFjY291bnRBd
  XRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNRElQLVVQUVYtNEg3WC1
  JQVJWLVg0NUQtRzVSUC1NVUtHIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiO
  iB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ijo
  gIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJKdlVuems2Yko1bFFxYklZV
  2duREpCd2ZiSURsTTdfY3pzSmZxVE03WHpJRm4zeTd3ZU9aCiAgNDI2aGFXN2d
  kWXhMZDd5aTN1U3I1SFdBIn19fSwKICAgICJBY2NvdW50U2lnbmF0dXJlIjoge
  wogICAgICAiVWRmIjogIk1ETzItU05QVC1INVpZLVU1SEstQlBDNS1NVkdGLVd
  IVDQiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVib
  GljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICA
  gICAgIlB1YmxpYyI6ICIyb1VReG9rM2FnZnViREdBbzBkNVpncTdnZzNGQnFmT
  Gx4Q3VacGxicjV5UzNGdDhBblJWCiAgNTdETWVDek50S1RTVlZnVjRhbnEwd1F
  BIn19fX19",
                    {
                      "signatures": [{
                          "alg": "S512",
                          "kid": "MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N",
                          "signature": "_aICFGYCm-j7vQxb3pSuluFLw7mV-xHAT7MunyoRj4nrMPcLi
  SnXsrgJEPf5nKqStCXCtWnaigiAeOCJQDgdjN8l3V5ES75xMokUCmXBHSd_GeV
  pwBMfrj8TW13in_AG0RXfEsDoomPncQm_33U28DUA"}],
                      "PayloadDigest": "ZAIkZVpaK57pD_WVl5s0sflP4vxt1AIIIO1g3bNDejldQ
  55TKy979S1_KAdEZzpZAEMDdo16brvW8Z2mqSphkQ"}],
                  "Protocols": [{
                      "Protocol": "mmm"}]}],
              "Sources": [{
                  "Validation": "Self",
                  "EnvelopedSource": [{
                      "dig": "S512",
                      "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjEtMTItMThUMDE6NTc6MDNaIn0"},
                    "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTUNGMi1XWTdBLVlITFItVzJOMy00R
  1hGLTRQVU8tWk83TiIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAgICAgIkVudmVsb3BlZFByb2ZpbGV
  BY2NvdW50IjogW3sKICAgICAgICAgICAgIkVudmVsb3BlSWQiOiAiTUNGMi1XW
  TdBLVlITFItVzJOMy00R1hGLTRQVU8tWk83TiIsCiAgICAgICAgICAgICJkaWc
  iOiAiUzUxMiIsCiAgICAgICAgICAgICJDb250ZW50TWV0YURhdGEiOiAiZXdvZ
  0lDSlZibWx4ZFdWSlpDSTZJQ0pOUTBZeUxWZFpOMEV0V1VoTVVpMQogIFhNazR
  6TFRSSFdFWXRORkJWVHkxYVR6ZE9JaXdLSUNBaVRXVnpjMkZuWlZSNWNHVWlPa
  UFpVUhKdlptbHNaCiAgVlZ6WlhJaUxBb2dJQ0pqZEhraU9pQWlZWEJ3Ykdsall
  YUnBiMjR2YlcxdEwyOWlhbVZqZENJc0NpQWdJa04KICB5WldGMFpXUWlPaUFpT
  WpBeU1TMHhNaTB4T0ZRd01UbzFOem93TTFvaWZRIn0sCiAgICAgICAgICAiZXd
  vZ0lDSlFjbTltYVd4bFZYTmxjaUk2SUhzS0lDQWdJQ0pRY205bWFXeAogIGxVM
  mxuYm1GMGRYSmxJam9nZXdvZ0lDQWdJQ0FpVldSbUlqb2dJazFEUmpJdFYxazN
  RUzFaU0V4U0xWY3lUCiAgak10TkVkWVJpMDBVRlZQTFZwUE4wNGlMQW9nSUNBZ
  0lDQWlVSFZpYkdsalVHRnlZVzFsZEdWeWN5STZJSHMKICBLSUNBZ0lDQWdJQ0F
  pVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0FnSUNKamNuWWlPa
  UFpUgogIFdRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKaEx
  WaHdlbTl4U2tONU0yazJNamx4YWtwCiAgM1puaDFNVWR0TFdwNmEzWlNZMnBmV
  URWUGVGSk9NWE0yYmxwTlN6ZHpiMGRrQ2lBZ1FuUjZVWHBRY2s4MGUKICBVRmF
  RbVJNY0hoUmRrWjJTbTlCSW4xOWZTd0tJQ0FnSUNKQlkyTnZkVzUwUVdSa2NtV
  npjeUk2SUNKaGJHbAogIGpaVUJsZUdGdGNHeGxMbU52YlNJc0NpQWdJQ0FpVTJ
  WeWRtbGpaVlZrWmlJNklDSk5RVmRYTFVRelZEWXRWCiAgRFZETlMxUU4xTlJMV
  kZFV1VZdFNrZEVOeTFMU0VoVklpd0tJQ0FnSUNKRmMyTnliM2RGYm1OeWVYQjB
  hVzkKICB1SWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxRVRVZ3RSelEwVlMwM
  FdqTTFMVTFKVmxrdFNWVkdTQzFUUQogIDFZMkxUTTBSMWtpTEFvZ0lDQWdJQ0F
  pVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBCiAgaVVIV
  mliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbllpT2lBaVd
  EUTBPQ0lzQ2lBZ0kKICBDQWdJQ0FnSUNBaVVIVmliR2xqSWpvZ0lsRnZOWEEwT
  FhsQldVaHpaVXgwWHpCTE9WSXhia1EyWnpORWEwNAogIDRVakYxVUROVmJraGZ
  kREpMYVVKa1dUTTVXbHBzVkVVS0lDQmhaMGRmYzBoeWFqbFBUSFEyV21ka00wW
  khOCiAgVFE1T0VFaWZYMTlMQW9nSUNBZ0lrRmpZMjkxYm5SRmJtTnllWEIwYVc
  5dUlqb2dld29nSUNBZ0lDQWlWV1IKICBtSWpvZ0lrMUVUazB0VUZwU1J5MVhUa
  lZHTFRKSFZ6UXRVVk5JTmkxWVJWa3lMVUpGU0VNaUxBb2dJQ0FnSQogIENBaVV
  IVmliR2xqVUdGeVlXMWxkR1Z5Y3lJNklIc0tJQ0FnSUNBZ0lDQWlVSFZpYkdsa
  lMyVjVSVU5FU0NJCiAgNklIc0tJQ0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlXRFE
  wT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsakkKICBqb2dJbXA1U2kxVmQzb
  GhVVGhPTjJWcFZVaFZWbk52TkRWdVoyUnVXbHBGYkdrd2RGZElVbUU1UVhkdFR
  pMQogIFdWRWRXYUd0VmIzRUtJQ0JvWm5VMmVFcHphMDV3V1ZoRE9EVjRjVTlEV
  GpSRWQwRWlmWDE5TEFvZ0lDQWdJCiAga0ZrYldsdWFYTjBjbUYwYjNKVGFXZHV
  ZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVRkJNaTEKICBIVGtJM
  ExWSkZWa1F0UmxkTFNTMVJOVXczTFRkRVNWTXRTVXBRVXlJc0NpQWdJQ0FnSUN
  KUWRXSnNhV05RWQogIFhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV
  0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBCiAgZ0lDQWdJbU55ZGlJNkl
  DSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2dJa3R6TlVKc
  lIKICAwaGhibEEwYkdSNGVGSTBRalprU21WMkxWRndURmxFZDAxWFltNUlUR2Q
  yY3pFeWQyUjZVVEpDYkV0U1NWOAogIEtJQ0JYZGxoaVdscFlZV2h4V0ZGcE0xS
  khNV2hsVkcxSlowRWlmWDE5TEFvZ0lDQWdJa0ZqWTI5MWJuUkJkCiAgWFJvWlc
  1MGFXTmhkR2x2YmlJNklIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlJFbFFMVlZRV
  VZZdE5FZzNXQzEKICBKUVZKV0xWZzBOVVF0UnpWU1VDMU5WVXRISWl3S0lDQWd
  JQ0FnSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pTwogIGlCN0NpQWdJQ0FnSUNBZ
  0lsQjFZbXhwWTB0bGVVVkRSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWp
  vCiAgZ0lsZzBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSktkb
  FZ1ZW1zMllrbzFiRkZ4WWtsWlYKICAyZHVSRXBDZDJaaVNVUnNUVGRmWTNwelN
  tWnhWRTAzV0hwSlJtNHplVGQzWlU5YUNpQWdOREkyYUdGWE4yZAogIGtXWGhNW
  kRkNWFUTjFVM0kxU0ZkQkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFUybG5ibUY
  wZFhKbElqb2dlCiAgd29nSUNBZ0lDQWlWV1JtSWpvZ0lrMUVUekl0VTA1UVZDM
  UlOVnBaTFZVMVNFc3RRbEJETlMxTlZrZEdMVmQKICBJVkRRaUxBb2dJQ0FnSUN
  BaVVIVmliR2xqVUdGeVlXMWxkR1Z5Y3lJNklIc0tJQ0FnSUNBZ0lDQWlVSFZpY
  gogIEdsalMyVjVSVU5FU0NJNklIc0tJQ0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWl
  SV1EwTkRnaUxBb2dJQ0FnSUNBCiAgZ0lDQWdJbEIxWW14cFl5STZJQ0l5YjFWU
  mVHOXJNMkZuWm5WaVJFZEJiekJrTlZwbmNUZG5aek5HUW5GbVQKICBHeDRRM1Z
  hY0d4aWNqVjVVek5HZERoQmJsSldDaUFnTlRkRVRXVkRlazUwUzFSVFZsWm5Wa
  lJoYm5Fd2QxRgogIEJJbjE5ZlgxOSIsCiAgICAgICAgICB7CiAgICAgICAgICA
  gICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgICAgICJhbGciOiAiUzUxM
  iIsCiAgICAgICAgICAgICAgICAia2lkIjogIk1DRjItV1k3QS1ZSExSLVcyTjM
  tNEdYRi00UFVPLVpPN04iLAogICAgICAgICAgICAgICAgInNpZ25hdHVyZSI6I
  CJfYUlDRkdZQ20tajd2UXhiM3BTdWx1Rkx3N21WLXhIQVQ3TXVueW9SajRuck1
  QY0xpCiAgU25Yc3JnSkVQZjVuS3FTdENYQ3RXbmFpZ2lBZU9DSlFEZ2RqTjhsM
  1Y1RVM3NXhNb2tVQ21YQkhTZF9HZVYKICBwd0JNZnJqOFRXMTNpbl9BRzBSWGZ
  Fc0Rvb21QbmNRbV8zM1UyOERVQSJ9XSwKICAgICAgICAgICAgIlBheWxvYWREa
  Wdlc3QiOiAiWkFJa1pWcGFLNTdwRF9XVmw1czBzZmxQNHZ4dDFBSUlJTzFnM2J
  ORGVqbGRRCiAgNTVUS3k5NzlTMV9LQWRFWnpwWkFFTURkbzE2YnJ2VzhaMm1xU
  3Boa1EifV0sCiAgICAgICAgIlByb3RvY29scyI6IFt7CiAgICAgICAgICAgICJ
  Qcm90b2NvbCI6ICJtbW0ifV19XX19",
                    {
                      "signatures": [{
                          "alg": "S512",
                          "kid": "MDO2-SNPT-H5ZY-U5HK-BPC5-MVGF-WHT4",
                          "signature": "mOeQcHoogxZh3lFYioSe74ycEQ1GpO3fWUE3r-COvcQPxwsz8
  0SHgNiNiKjVlbnKk1jSsLQ1sZIAd8nuNiViVXisVOV21MRWLdSG70njJOoxb9Z
  x14hZvZv2-3Wev1-NNwWFpO695ZtuybFUjC71zSUA"}],
                      "PayloadDigest": "6dUGOWKV0uMnwBYtGKFI8tyjHIJnp9KShWyj604IMETTi
  L4sQcXM2kGJgwGYrSw7-vpgJPvXNd6f1mhYWvYBfQ"}]}]}}}},
      {
        "CatalogedContact": {
          "Key": "NAWB-M7G7-OXPC-I6YS-SIXH-JQ7E-OOXA",
          "Self": false,
          "Contact": {
            "ContactPerson": {
              "Anchors": [{
                  "Udf": "MBYX-JPOL-7H24-YL2Z-LOHO-7MWV-IFGG",
                  "Validation": "Self"}],
              "NetworkAddresses": [{
                  "Address": "bob@example.com",
                  "EnvelopedProfileAccount": [{
                      "EnvelopeId": "MBYX-JPOL-7H24-YL2Z-LOHO-7MWV-IFGG",
                      "dig": "S512",
                      "ContentMetaData": "ewogICJVbmlxdWVJZCI6ICJNQllYLUpQT0wtN0gyNC1
  ZTDJaLUxPSE8tN01XVi1JRkdHIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMS0xMi0xOFQwMTo1NzoxM1oifQ"},
                    "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CWVgtSlBPTC03SDI0LVlMM
  lotTE9ITy03TVdWLUlGR0ciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJHV2wzS21LM2Y4b3VHcFNfYkd
  UUV9WUFROVWFCQWRoSktrb3VRYnNkLXdEdmFhcUVTakRxCiAgLVAtZDZaNGlfU
  DM2UTNIaDdzQkZ5MUNBIn19fSwKICAgICJBY2NvdW50QWRkcmVzcyI6ICJib2J
  AZXhhbXBsZS5jb20iLAogICAgIlNlcnZpY2VVZGYiOiAiTUFXVy1EM1Q2LVQ1Q
  zUtUDdTUS1RRFlGLUpHRDctS0hIVSIsCiAgICAiRXNjcm93RW5jcnlwdGlvbiI
  6IHsKICAgICAgIlVkZiI6ICJNQVg1LU5GVTctQzRJSS00SzU1LTczTlMtQU81S
  S1HN0tFIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgI
  CAgICAgIlB1YmxpYyI6ICJreFFUeHpTeWFPYnlJbnJ3eDJzTjM2ZXU2R3R0RG1
  PS05kNkNKMk1kZUxWUmJXRl9kX2x1CiAgN18ydklmcTFxdTRma0tWXzdaSzAxc
  2FBIn19fSwKICAgICJBY2NvdW50RW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI
  6ICJNQ1o0LTVHN1gtT1c0Qi1SM1VJLVJYMlYtTVhaMi1JVk9JIiwKICAgICAgI
  lB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB
  7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6I
  CJhcUJ2VzY5YkdBSUJEWWpLbHYwSV8zSktBZFQwWTZ1RmQ4cnlTbnNiR1BpbVB
  XOFo0NF80CiAgSXRaOHQ5TjltU3NfMmU0d1FIRWhXbTZBIn19fSwKICAgICJBZ
  G1pbmlzdHJhdG9yU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1DS0UtSFZ
  OWS1XSVFPLTVGN1UtQTVCQy1UUDNELVZKQ0oiLAogICAgICAiUHVibGljUGFyY
  W1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJvQXhvQ0VRV
  UtIS2VDWF8tOGhXSkU5Tk1FX3RWektKamRiVlpIWDJBTWFDX2puZ0JIeDN3CiA
  gY3RpWUxaQk8wcTRZdWZjaUx1cTFVZGNBIn19fSwKICAgICJBY2NvdW50QXV0a
  GVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTURUTS1HQkIzLVg1MzMtNlJ
  PWi1ORkJRLVU2Wk4tRFkzNCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjoge
  wogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJ
  YNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiYzBMZVpqNDkzc081bDFURkhqZ
  ENHbmE4UWpjc0VXVDZkYVpmOHpDOWI0b2EyYUtRa2VKagogIGNvSGZodWM4R21
  KemZWY09VeFBOM3dvQSJ9fX0sCiAgICAiQWNjb3VudFNpZ25hdHVyZSI6IHsKI
  CAgICAgIlVkZiI6ICJNQU5VLVZQV0UtUURTVS1PRVo3LVc2Sk8tU0hXTS1UMzU
  3IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICA
  gICJQdWJsaWMiOiAiRGdKUTNkSWhwc08wZ3ZGeE5fN2p5Zzl0QlpJNDV6ZUdaO
  UQwaFN5T0szTGhrbS1xYzVaRAogIEFobU9uWE81OVhsMFZEbkNNTFdoNjRLQSJ
  9fX19fQ",
                    {
                      "signatures": [{
                          "alg": "S512",
                          "kid": "MBYX-JPOL-7H24-YL2Z-LOHO-7MWV-IFGG",
                          "signature": "8HZ6r-B6xca7I0jqf-2XkoxgdAuSVzDWFGBppvmABjmCLvHlN
  cC4aPCGifadgK6vfk7QAzlH_BeAlNDBZrAKB_Pl_lhdp73owMUyWtJEdyjVVy5
  WHnq3PBv0C7dNWLCpjJ058bZGXWrJntqIVh-a_BAA"}],
                      "PayloadDigest": "S97z1_MMMX8AhP3AqWA60COj67IKN5CTcVWzSNFl8UpBF
  2qweXgs7NOFUSRFE_7AJqIrR8pbUx_zAcnpzzcr7A"}],
                  "Protocols": [{
                      "Protocol": "mmm"}]}]}}}},
      {
        "CatalogedContact": {
          "Key": "NBLD-QB2F-UVQD-MHP5-PHY3-J2MO-YUKD",
          "Self": false,
          "Contact": {
            "ContactPerson": {
              "Anchors": [{
                  "Udf": "MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK",
                  "Validation": "Self"}],
              "NetworkAddresses": [{
                  "Address": "groupw@example.com",
                  "EnvelopedProfileAccount": [{
                      "EnvelopeId": "MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK",
                      "dig": "S512",
                      "ContentMetaData": "ewogICJVbmlxdWVJZCI6ICJNQ0lHLTU3RzQtQ0tNRy1
  TTFc1LUk3NUktTFFOQy1KNU1LIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Udyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjEtMTItMThUMDE6NTc6MjBaIn0"},
                    "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZml
  sZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQ0lHLTU3RzQtQ0tNRy1TT
  Fc1LUk3NUktTFFOQy1KNU1LIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB
  7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAidE9fdG5EQUwwaFhuYllzRUp
  VeGRXSmhDMnlpM3p1UEd1cHdOX2EyczdxdXlGWFJCNFFKSgogIC1rX1JQMGpsb
  jN4a1RVRXYxb3hfT0hTQSJ9fX0sCiAgICAiQWNjb3VudEFkZHJlc3MiOiAiZ3J
  vdXB3QGV4YW1wbGUuY29tIiwKICAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogI
  CAgICAiVWRmIjogIk1DVVItM0NWNS0yQURLLU00Q0ktTlIzNS1MVUtSLVI2WE4
  iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS
  2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICA
  iUHVibGljIjogIlg1YVE0cnUxdDVwYmJzRnZUUk1HcHRPNnhma1NGMmpCQTNlX
  3h5MlVQTWQzZGRrb21pSUEKICBHTmQtb2V6XzltemFBLVFyVkpkSkR4aUEifX1
  9LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1DU
  UktWFBQTS1WSkJULTc0Sk4tTElZUC1WMjM2LUZSRjUiLAogICAgICAiUHVibGl
  jUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgI
  CAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIk56RXh
  yQ0kydkxCX2lBS1ROc2o5Mlh4S0p6eWo1RHdlemxhWXpYa3NKM0txdlRmdlJQW
  FMKICA4bi15Z0RDVS1ZbUxEX3RCT2hpb1A4S0EifX19LAogICAgIkFkbWluaXN
  0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTUFLQS1TSlJBLVBIU
  VMtNVVQVS1WQVpVLVZTT04tV0JCSyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJ
  zIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNyd
  iI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogInJBZXZ6QmRCckJPWlh
  qak5xZm5jQmk0VnMzQmVJYndfZ19wQWh5QWVDU05scldFYjEwRTkKICByRU9QU
  0U5bEVWblNxX1VIUDhlR19jSUEifX19LAogICAgIkFjY291bnRBdXRoZW50aWN
  hdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQlA1LUFZTEYtUlRKWi1MU0NBLURBS
  jctTlRXSy1DSk1RIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICA
  gICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiL
  AogICAgICAgICAgIlB1YmxpYyI6ICJkNHFMNEw1clRkYVJKSHRmQkEwNUJrRV9
  kZUltdmZjdVloaWNCQkRMZFFRUjhQTlR3S3JWCiAgV2VobTRsY0VhdzkxRzdRN
  Ep3TUlWTVlBIn19fX19",
                    {
                      "signatures": [{
                          "alg": "S512",
                          "kid": "MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK",
                          "signature": "yiQMt6_MA6j8G7vQiq0mXxsOcTbMKceC1pVsc_pLHMlLJLeaQ
  XXy6A6_QzMypouXz4m09k4F3BsALKreWlbiQAkIsVNFeY7G-TMohm62rCV_A70
  YvWBdvZ8mq08cA4Odw9IeTFGpGaz0ms3i3E6vCi0A"}],
                      "PayloadDigest": "SI0VsUFAZLyvrLozaZnoFIaV_RLvhf00kWzyll6HcHuSd
  T1xtGKIAeEIXaxHBQGKwrjTdYxmcsrkKnzrerP69Q"}],
                  "Protocols": [{
                      "Protocol": "mmm"}]}]}}}},
      {
        "CatalogedContact": {
          "Key": "NDXP-NDKS-PFFD-WBA7-VQ74-5KM5-355Y",
          "Self": false,
          "Contact": {
            "ContactPerson": {
              "Anchors": [{
                  "Udf": "MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK",
                  "Validation": "Self"}],
              "NetworkAddresses": [{
                  "Address": "groupw@example.com",
                  "EnvelopedProfileAccount": [{
                      "EnvelopeId": "MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK",
                      "dig": "S512",
                      "ContentMetaData": "ewogICJVbmlxdWVJZCI6ICJNQ0lHLTU3RzQtQ0tNRy1
  TTFc1LUk3NUktTFFOQy1KNU1LIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Udyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjEtMTItMThUMDE6NTc6MjBaIn0"},
                    "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZml
  sZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQ0lHLTU3RzQtQ0tNRy1TT
  Fc1LUk3NUktTFFOQy1KNU1LIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB
  7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAidE9fdG5EQUwwaFhuYllzRUp
  VeGRXSmhDMnlpM3p1UEd1cHdOX2EyczdxdXlGWFJCNFFKSgogIC1rX1JQMGpsb
  jN4a1RVRXYxb3hfT0hTQSJ9fX0sCiAgICAiQWNjb3VudEFkZHJlc3MiOiAiZ3J
  vdXB3QGV4YW1wbGUuY29tIiwKICAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogI
  CAgICAiVWRmIjogIk1DVVItM0NWNS0yQURLLU00Q0ktTlIzNS1MVUtSLVI2WE4
  iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS
  2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICA
  iUHVibGljIjogIlg1YVE0cnUxdDVwYmJzRnZUUk1HcHRPNnhma1NGMmpCQTNlX
  3h5MlVQTWQzZGRrb21pSUEKICBHTmQtb2V6XzltemFBLVFyVkpkSkR4aUEifX1
  9LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1DU
  UktWFBQTS1WSkJULTc0Sk4tTElZUC1WMjM2LUZSRjUiLAogICAgICAiUHVibGl
  jUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgI
  CAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIk56RXh
  yQ0kydkxCX2lBS1ROc2o5Mlh4S0p6eWo1RHdlemxhWXpYa3NKM0txdlRmdlJQW
  FMKICA4bi15Z0RDVS1ZbUxEX3RCT2hpb1A4S0EifX19LAogICAgIkFkbWluaXN
  0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTUFLQS1TSlJBLVBIU
  VMtNVVQVS1WQVpVLVZTT04tV0JCSyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJ
  zIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNyd
  iI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogInJBZXZ6QmRCckJPWlh
  qak5xZm5jQmk0VnMzQmVJYndfZ19wQWh5QWVDU05scldFYjEwRTkKICByRU9QU
  0U5bEVWblNxX1VIUDhlR19jSUEifX19LAogICAgIkFjY291bnRBdXRoZW50aWN
  hdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQlA1LUFZTEYtUlRKWi1MU0NBLURBS
  jctTlRXSy1DSk1RIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICA
  gICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiL
  AogICAgICAgICAgIlB1YmxpYyI6ICJkNHFMNEw1clRkYVJKSHRmQkEwNUJrRV9
  kZUltdmZjdVloaWNCQkRMZFFRUjhQTlR3S3JWCiAgV2VobTRsY0VhdzkxRzdRN
  Ep3TUlWTVlBIn19fX19",
                    {
                      "signatures": [{
                          "alg": "S512",
                          "kid": "MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK",
                          "signature": "yiQMt6_MA6j8G7vQiq0mXxsOcTbMKceC1pVsc_pLHMlLJLeaQ
  XXy6A6_QzMypouXz4m09k4F3BsALKreWlbiQAkIsVNFeY7G-TMohm62rCV_A70
  YvWBdvZ8mq08cA4Odw9IeTFGpGaz0ms3i3E6vCi0A"}],
                      "PayloadDigest": "SI0VsUFAZLyvrLozaZnoFIaV_RLvhf00kWzyll6HcHuSd
  T1xtGKIAeEIXaxHBQGKwrjTdYxmcsrkKnzrerP69Q"}],
                  "Protocols": [{
                      "Protocol": "mmm"}],
                  "Capabilities": [{
                      "CapabilityDecryptPartial": {
                        "Id": "MCQI-XPPM-VJBT-74JN-LIYP-V236-FRF5",
                        "EnvelopedKeyShare": [{
                            "enc": "A256CBC",
                            "kid": "EBQO-7AOI-N55R-6UKK-SWCO-XUOG-TZSQ",
                            "Salt": "esu9P2aCoEvV8Qq0R8SWjQ",
                            "recipients": [{
                                "kid": "MDNM-PZRG-WN5F-2GW4-QSH6-XEY2-BEHC",
                                "epk": {
                                  "PublicKeyECDH": {
                                    "crv": "X448",
                                    "Public": "P9Bh0BN_e3YoiDseDL32EGbSp_olTipvgzE72Hlr9kwOyu4UKW6o
  ZsQk2Dz5j_R-ippvQdjn6GqA"}},
                                "wmk": "kjwm7cuvmyNYy7b1WCjx0R5lK_FI33AgGRxbIiIBIWURpMHwlpvmOA"}],
                            "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYXRhIiwKICA
  iY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGVkIjogI
  jIwMjEtMTItMThUMDE6NTc6MjBaIn0"},
                          "3CoPlzCfFQtG-mUN21ZlgZsjt3GkaAM-9F9K4Ip6WGY
  rkoFWGa0-3wNEm2FMwzh21QLIsIiGp--7g2h0ldb_jPIDq7x_qGEeVUEhLMEMY
  jZuE1uA7mDfoQl3ob-GD-v-s3_izTPQxeQPjh4zmOoC_WU5rgOGJdp34z3UkLW
  VuBkenbZ-VGMFV8Bb_U5dJhLmEB6Dvto8P50jbIGl8hB7dN4cHcuNVLGZ-Kq1u
  WAMjE72h3tauFt1-WKzR4Yr3cmKaMFX3t3cz_L_xOQwg7OQT3WErb6jQmBTMVu
  up8fpGv5HArnUd9Pqy01wZsMf0RkaQ_d7-Oip3dnpa35I7R4dZwb4MjiQ_vHfT
  ro7yTC1uiEXNb2JgOxmgjBMbtpclsNo0l7X5an6HYTFzwt3XoKVTYAzOgFvniL
  gfOU1N4pCEuKT_M_hEd9VQ6DIl0GXyP1rfVXTI2FpOuC8IHXYUEAxY1Ae4QU4-
  7ST-2CwwyvC_rGJhbZr7Q76oi6NVLv_bEi4DyqGtz2EnJx3iG_jEbtjFmh4dk6
  oxJ710q_IXGtfNlDkW-cvPYmJe6L7fD7noqwrrcxPwMhX4Me5t4Cd4bTyHx2oO
  F4UmXGzCDMkZmmHMWuwSmZomDb58fGTkMWENHkFIUyF5oOIYvpZh876yHRx0uE
  shOQei1G14pRhAZaq2QyWPiGJbhZrJex0aAf5seMmBaAO9q-1gwnZkED-MtAiU
  g"]}}]}]}}}},
      {
        "CatalogedContact": {
          "Key": "NCC4-BLBH-RHO3-UHOG-YRJO-W4J2-JCNL",
          "Self": false,
          "Contact": {
            "ContactPerson": {
              "Anchors": [{
                  "Udf": "MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK",
                  "Validation": "Self"}],
              "NetworkAddresses": [{
                  "Address": "groupw@example.com",
                  "EnvelopedProfileAccount": [{
                      "EnvelopeId": "MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK",
                      "dig": "S512",
                      "ContentMetaData": "ewogICJVbmlxdWVJZCI6ICJNQ0lHLTU3RzQtQ0tNRy1
  TTFc1LUk3NUktTFFOQy1KNU1LIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Udyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjEtMTItMThUMDE6NTc6MjBaIn0"},
                    "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZml
  sZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQ0lHLTU3RzQtQ0tNRy1TT
  Fc1LUk3NUktTFFOQy1KNU1LIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB
  7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAidE9fdG5EQUwwaFhuYllzRUp
  VeGRXSmhDMnlpM3p1UEd1cHdOX2EyczdxdXlGWFJCNFFKSgogIC1rX1JQMGpsb
  jN4a1RVRXYxb3hfT0hTQSJ9fX0sCiAgICAiQWNjb3VudEFkZHJlc3MiOiAiZ3J
  vdXB3QGV4YW1wbGUuY29tIiwKICAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogI
  CAgICAiVWRmIjogIk1DVVItM0NWNS0yQURLLU00Q0ktTlIzNS1MVUtSLVI2WE4
  iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS
  2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICA
  iUHVibGljIjogIlg1YVE0cnUxdDVwYmJzRnZUUk1HcHRPNnhma1NGMmpCQTNlX
  3h5MlVQTWQzZGRrb21pSUEKICBHTmQtb2V6XzltemFBLVFyVkpkSkR4aUEifX1
  9LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1DU
  UktWFBQTS1WSkJULTc0Sk4tTElZUC1WMjM2LUZSRjUiLAogICAgICAiUHVibGl
  jUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgI
  CAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIk56RXh
  yQ0kydkxCX2lBS1ROc2o5Mlh4S0p6eWo1RHdlemxhWXpYa3NKM0txdlRmdlJQW
  FMKICA4bi15Z0RDVS1ZbUxEX3RCT2hpb1A4S0EifX19LAogICAgIkFkbWluaXN
  0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTUFLQS1TSlJBLVBIU
  VMtNVVQVS1WQVpVLVZTT04tV0JCSyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJ
  zIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNyd
  iI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogInJBZXZ6QmRCckJPWlh
  qak5xZm5jQmk0VnMzQmVJYndfZ19wQWh5QWVDU05scldFYjEwRTkKICByRU9QU
  0U5bEVWblNxX1VIUDhlR19jSUEifX19LAogICAgIkFjY291bnRBdXRoZW50aWN
  hdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQlA1LUFZTEYtUlRKWi1MU0NBLURBS
  jctTlRXSy1DSk1RIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICA
  gICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiL
  AogICAgICAgICAgIlB1YmxpYyI6ICJkNHFMNEw1clRkYVJKSHRmQkEwNUJrRV9
  kZUltdmZjdVloaWNCQkRMZFFRUjhQTlR3S3JWCiAgV2VobTRsY0VhdzkxRzdRN
  Ep3TUlWTVlBIn19fX19",
                    {
                      "signatures": [{
                          "alg": "S512",
                          "kid": "MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK",
                          "signature": "yiQMt6_MA6j8G7vQiq0mXxsOcTbMKceC1pVsc_pLHMlLJLeaQ
  XXy6A6_QzMypouXz4m09k4F3BsALKreWlbiQAkIsVNFeY7G-TMohm62rCV_A70
  YvWBdvZ8mq08cA4Odw9IeTFGpGaz0ms3i3E6vCi0A"}],
                      "PayloadDigest": "SI0VsUFAZLyvrLozaZnoFIaV_RLvhf00kWzyll6HcHuSd
  T1xtGKIAeEIXaxHBQGKwrjTdYxmcsrkKnzrerP69Q"}],
                  "Protocols": [{
                      "Protocol": "mmm"}],
                  "Capabilities": [{
                      "CapabilityDecryptPartial": {
                        "Id": "MCQI-XPPM-VJBT-74JN-LIYP-V236-FRF5",
                        "EnvelopedKeyShare": [{
                            "enc": "A256CBC",
                            "kid": "EBQO-7AOI-N55R-6UKK-SWCO-XUOG-TZSQ",
                            "Salt": "esu9P2aCoEvV8Qq0R8SWjQ",
                            "recipients": [{
                                "kid": "MDNM-PZRG-WN5F-2GW4-QSH6-XEY2-BEHC",
                                "epk": {
                                  "PublicKeyECDH": {
                                    "crv": "X448",
                                    "Public": "P9Bh0BN_e3YoiDseDL32EGbSp_olTipvgzE72Hlr9kwOyu4UKW6o
  ZsQk2Dz5j_R-ippvQdjn6GqA"}},
                                "wmk": "kjwm7cuvmyNYy7b1WCjx0R5lK_FI33AgGRxbIiIBIWURpMHwlpvmOA"}],
                            "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYXRhIiwKICA
  iY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGVkIjogI
  jIwMjEtMTItMThUMDE6NTc6MjBaIn0"},
                          "3CoPlzCfFQtG-mUN21ZlgZsjt3GkaAM-9F9K4Ip6WGY
  rkoFWGa0-3wNEm2FMwzh21QLIsIiGp--7g2h0ldb_jPIDq7x_qGEeVUEhLMEMY
  jZuE1uA7mDfoQl3ob-GD-v-s3_izTPQxeQPjh4zmOoC_WU5rgOGJdp34z3UkLW
  VuBkenbZ-VGMFV8Bb_U5dJhLmEB6Dvto8P50jbIGl8hB7dN4cHcuNVLGZ-Kq1u
  WAMjE72h3tauFt1-WKzR4Yr3cmKaMFX3t3cz_L_xOQwg7OQT3WErb6jQmBTMVu
  up8fpGv5HArnUd9Pqy01wZsMf0RkaQ_d7-Oip3dnpa35I7R4dZwb4MjiQ_vHfT
  ro7yTC1uiEXNb2JgOxmgjBMbtpclsNo0l7X5an6HYTFzwt3XoKVTYAzOgFvniL
  gfOU1N4pCEuKT_M_hEd9VQ6DIl0GXyP1rfVXTI2FpOuC8IHXYUEAxY1Ae4QU4-
  7ST-2CwwyvC_rGJhbZr7Q76oi6NVLv_bEi4DyqGtz2EnJx3iG_jEbtjFmh4dk6
  oxJ710q_IXGtfNlDkW-cvPYmJe6L7fD7noqwrrcxPwMhX4Me5t4Cd4bTyHx2oO
  F4UmXGzCDMkZmmHMWuwSmZomDb58fGTkMWENHkFIUyF5oOIYvpZh876yHRx0uE
  shOQei1G14pRhAZaq2QyWPiGJbhZrJex0aAf5seMmBaAO9q-1gwnZkED-MtAiU
  g"]}}]}]}}}}]}}
</div>
~~~~


