

# message

~~~~
<div="helptext">
<over>
message    Contact and confirmation message options
    accept   Accept a pending request
    block   Reject a pending request and block requests from that source
    confirm   Post a confirmation request to a user
    contact   Post a conection request to a user
    pending   List pending requests
    reject   Reject a pending request
    status   Request status of pending requests
<over>
</div>
~~~~


# message contact

~~~~
<div="helptext">
<over>
contact   Post a conection request to a user
       The recipient to send the conection request to
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultSent:

~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com /json
<rsp>{
  "ResultSent": {
    "Success": true,
    "Message": {
      "Sender": "bob@example.com",
      "Recipient": "alice@example.com",
      "Reply": true}}}
</div>
~~~~


# message confirm

~~~~
<div="helptext">
<over>
confirm   Post a confirmation request to a user
       The recipient to send the confirmation request to
       The recipient to send the confirmation request to
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Bob> message confirm alice@example.com "Purchase equipment for $6,000?"
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultSent:

~~~~
<div="terminal">
<cmd>Bob> message confirm alice@example.com "Purchase equipment for $6,000?" /json
<rsp>{
  "ResultSent": {
    "Success": true,
    "Message": {
      "Sender": "bob@example.com",
      "Recipient": "alice@example.com",
      "Text": "\"Purchase"}}}
</div>
~~~~



# message pending

~~~~
<div="helptext">
<over>
pending   List pending requests
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultPending:

~~~~
<div="terminal">
<cmd>Alice> message pending /json
<rsp>{
  "ResultPending": {
    "Success": true,
    "Messages": [{
        "Sender": "bob@example.com",
        "Recipient": "alice@example.com",
        "Reply": true},
      {
        "MessageID": "NDR3-7KSS-FLW2-E7YF-RQG4-I34A-IH6G",
        "EnvelopedRequestConnection": [{},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6
  IHsKICAgICJTZXJ2aWNlSUQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIk
  VudmVsb3BlZFByb2ZpbGVEZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUx
  MiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0
  FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lD
  SlZSRVlpT2lBaVRVTllOQzAwU0VoYUxWZFVRMU10V2tGRE5pMUtSCiAgVUZKTF
  ZOR05rSXRSRUZCTmlJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6
  SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2
  dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNB
  Z0lDQWlVSFZpYkdsaklqb2dJbWxrYXpWNFMyOW9RbVZmUjBwQ0xXbzJZWGRqVG
  pOCiAgZlVua3lTazB0UzJZNWRVc3pVWE5mV1had1RVVkVhRXRmZVdKb2FWY0tJ
  Q0F3YTJVd1dtTkJibXhRUzB0UVMKICBsaE5NMU5VVkZKT2RVRWlmWDE5TEFvZ0
  lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlp
  T2lBaVRVUllUQzFITmxSVkxUWXpObEF0VTFwWlVDMUNVa3czTFZjelFVSXROaz
  FYV2lJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3
  b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSU
  NBZ0lDQWdJbU55ZGlJNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZp
  YgogIEdsaklqb2dJbVJXT1VSalJuUm1ZMjFvZGtKNmVFRmhVamczVW1KRldYZE
  VTREozVjJoMlEzUkNkbWt5TlRBCiAgME5Ia3dUMngyVEdkSFpGa0tJQ0JZVkRk
  dk1XeHJVWFUxTjNGT00yMTNaSEp0WjNkTFowRWlmWDE5TEFvZ0kKICBDQWdJa3
  RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJ
  azFDTkVjdFNrMQogIE1WaTFGUkVSQ0xVNDNRelV0UTFKWVdTMURNazVNTFZnM1
  JUUWlMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNL
  SUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0
  EKICBnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlt
  eHBZeUk2SUNKU1RGbzBaMlY0UwogIEhSRlFqaG5YM3BLYzFGbFJsQnFZVUpOYk
  c1U1FVcEpORk5XYm5Jd1VGUXpiSFJuUzBWcGNqWm1TakZZQ2lBCiAgZ0xVdENS
  M05ZU0ZWaE5HRjVhWGhVU0VNM2NtSmhYMjFCSW4xOWZYMTkiLAogICAgICB7Ci
  AgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1
  MTIiLAogICAgICAgICAgICAia2lkIjogIk1DWDQtNEhIWi1XVENTLVpBQzYtSk
  VBSS1TRjZCLURBQTYiLAogICAgICAgICAgICAic2lnbmF0dXJlIjogInFQeG5F
  OHNQcGtSWFczWGhQUEJlbUpmaVBmcXZMY0lkYVRTbGdWdG9nb0ktQS1NdjQKIC
  BMTEpaWnZCQVBQRFBQckxmeVFYUGxibU1qd0F1TVdLV2IzbVIxakpCYUdsaGhs
  aFN0M0hSOVZaakhyT0tuZQogIEhwcE5iNjkwV2tTMXp2UTVUTHJoaDRLd1AyVE
  cwNWhLMkJndG85QWtBIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIkI2
  YThKQUJOUUQyckh5VjU3ejE4eXFpWVp2dlk3N3dTalJtUHd1NV80dHpOSQogIF
  FVMklsUGozaWxJQ2ZnTlU3NHA2QU5YdlhadUp1WUsxS3lMaGZxclJRIn1dLAog
  ICAgIkNsaWVudE5vbmNlIjogImhRZTJNSExIcGdEWDEweXVmeUMxUHciLAogIC
  AgIlBpblVERiI6ICJOQVJWLVFHRkItN0xaMi02SVlJLUtFIn19"],
        "ServerNonce": "oZRUeOgpQ8XOSurmh9DmUg",
        "Witness": "6X26-DOD7-HQXO-7WQZ-5VZI-HB6D-CWK3"},
      {
        "MessageID": "NDZP-2UYY-ZA5U-T2PR-7XBW-OBT6-2OQE",
        "EnvelopedRequestConnection": [{},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6
  IHsKICAgICJTZXJ2aWNlSUQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIk
  VudmVsb3BlZFByb2ZpbGVEZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUx
  MiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0
  FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lD
  SlZSRVlpT2lBaVRVTk5OaTFhV0ZWV0xVeEhXVWd0U1VFM05pMWFOCiAgVkpKTF
  V0S1N6WXRTMWhhVGlJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6
  SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2
  dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNB
  Z0lDQWlVSFZpYkdsaklqb2dJblpKVkU5aFp6aFlTVzlKWWtGcE5WVXhRazB0VD
  JSCiAgWVNFNXZWRzFUTlVkcU1FMVNkVmQ2VERkVk5HNU5NbXBDTmtNemNtVUtJ
  Q0JmZEMxNWFuaEtUbkJMYjNnMk0KICBFWnNhazltZGtOeVFVRWlmWDE5TEFvZ0
  lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlp
  T2lBaVRVUlRSUzFHVWpOWkxWcFVRMHd0UWtZMlRTMHlVVE5ITFZkRE5VNHRUMG
  xVU3lJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3
  b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSU
  NBZ0lDQWdJbU55ZGlJNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZp
  YgogIEdsaklqb2dJbkYzTkdnM1JTMDVWR1YwVUhaU1ZuQmFiaTFEYTFVeWFHRm
  xWMVl0U2pZelowcDNSamcxTVhBCiAgeGMySTJkMkp6Vm1kbE16UUtJQ0JwU2xG
  V1ptZDFSM1JOV2poVFFVSnlhMU54WmsxTWEwRWlmWDE5TEFvZ0kKICBDQWdJa3
  RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJ
  azFFVkVRdFR6VgogIEZUQzFLVjBvM0xVZFFTVVV0UVZwUVdpMUhVVE5YTFRkWF
  ZsSWlMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNL
  SUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0
  EKICBnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlt
  eHBZeUk2SUNKb1RYVndlVUpLWQogIHpoNVUxZDNSVU5aVmpGS1Z6bHlOR05pU1
  hkQmMxTjBlakYxZW5wSGNEaGZOVXhxY3psNmNUbDJlRU5hQ2lBCiAgZ1pUQnpN
  V2xVU2w5MGNuQlBaMHBHYkZjM2RtWkdaUzFCSW4xOWZYMTkiLAogICAgICB7Ci
  AgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1
  MTIiLAogICAgICAgICAgICAia2lkIjogIk1DTTYtWlhVVi1MR1lILUlBNzYtWj
  VSSS1LSks2LUtYWk4iLAogICAgICAgICAgICAic2lnbmF0dXJlIjogIi0yMXQ1
  eU5RM3dtQkJ2V2lxWGhnV2NvWTV4N1JfWVBaMjFUd3RWZW4xQ0VFalRrTXUKIC
  BKUlRqUnl0TVAtTENvNmdNS0VQTU84bEV6Z0FibnZ3Mkh4WElmQ3pPSkF5enB4
  TU1xOHlXeHJkTnU3UWdkVgogIHJDbmNrSVdOaGJhSHdOMlVWcFMtbEpCZEVib2
  9tQWo0b0VjX1hzaHdBIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIk52
  TUtJZnJFc3A0ZzdsVUVTb19pbkZSV2d1YUJhZ05pZmEyWVBEbHFFOWM1eQogIE
  xnWTdLeXdTUnFTbGVmREtyOWphZXFRWW00a3E0QkdhaWs4UGw3TDd3In1dLAog
  ICAgIkNsaWVudE5vbmNlIjogIk81MnNfdjNiSUNELUVvdmRCRE1UTVEifX0"],
        "ServerNonce": "IphTEA9tmtgFjIlzSQwjmw",
        "Witness": "AJA4-2O5P-LABF-2BRK-AJKP-S2LI-DV3D"},
      {
        "MessageID": "NB3R-I5BK-QDB2-QWXG-WPVK-NGH6-OIII",
        "EnvelopedRequestConnection": [{},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6
  IHsKICAgICJTZXJ2aWNlSUQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIk
  VudmVsb3BlZFByb2ZpbGVEZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUx
  MiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0
  FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lD
  SlZSRVlpT2lBaVRVTkpOUzFNU1VKTExWZERUa1V0VTB3M1FpMVFXCiAgbE0wTF
  RaYVZrZ3RTa05EVmlJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6
  SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2
  dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNB
  Z0lDQWlVSFZpYkdsaklqb2dJbDlRVUV4ek1uTldaR0pCY20xS056RTRkeTB0WT
  E5CiAgNU1FaEhOalk1ZFdOZmQxSldTbUYwTm5SdldITk9aMWt0ZWpkTmNFc0tJ
  Q0JOZFhCQ1oyaFFkazF4Vm1wUmEKICB6Vk9XbnBuU1VoQlkwRWlmWDE5TEFvZ0
  lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlp
  T2lBaVRVUk1VeTFPVmtVMExVeEpWRUl0VERkR1JTMU1TMFJXTFV3elNqY3RSel
  JKVXlJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3
  b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSU
  NBZ0lDQWdJbU55ZGlJNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZp
  YgogIEdsaklqb2dJbmxyZWs0NVdEbHRZMlJHVm1aeFUybFNXbmRwWm10WFp6Ql
  hVMmhIU1hrMlVGQXRUa0ZsVVZsCiAgSWNrOXRjbU5VY0hkdFZqZ0tJQ0JmZGxa
  bE9VUndla3RZWWpGbVoxRklhRWRwUlVoSE9FRWlmWDE5TEFvZ0kKICBDQWdJa3
  RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJ
  azFEVmpJdFZsWgogIE9OaTAwUmtzekxVVTNVRUl0VkVOQlJpMVNWVFJKTFVsV1
  RrSWlMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNL
  SUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0
  EKICBnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlt
  eHBZeUk2SUNJd1JuWkZaMlpTUwogIG1sVFJXOUxVR3R3TWtsMmRXbDFOVk5TZU
  dKcVJXNWhTbTlMUWt0ZlkydGlVa3N4WWtWV05TMWhjMjFOQ2lBCiAgZ1JVWkZO
  RGhrYlhWNk56ZERjM2wxWlVOWVJWRk5jM2xCSW4xOWZYMTkiLAogICAgICB7Ci
  AgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1
  MTIiLAogICAgICAgICAgICAia2lkIjogIk1DSTUtTElCSy1XQ05FLVNMN0ItUF
  pTNC02WlZILUpDQ1YiLAogICAgICAgICAgICAic2lnbmF0dXJlIjogImV3V294
  SUdBS0t0emtDTWc5WVBncTI2Z2xoRG5iYlB5NU42VVFtVTF3YjJRYTUyRkcKIC
  AzSjhDc3RWREw2ODJKQV9lVXZOYzNGUmRWRUFfVnJlLVNEN1F6bEJJNFpiUWZw
  NkxfV3labHYwTTZ2LU92bwogIG1YcV9JQzd0TGpXeDFWQ25TejlHT3A2Vk1VOE
  o3N2pkdXFHNWQyRFVBIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIktn
  WndZUkZfcm56cEhhOFQtV2NxRk1rZmZFRUFSVmJGNU9RUDU4ZkxQWlFwOAogIH
  JUSzZyNk1falVUX0FNbjVWVmVldlhOem1HekpTQ1ptTjNfWVBYdUl3In1dLAog
  ICAgIkNsaWVudE5vbmNlIjogIm94cVVRenhQT1VtNjVhUDdUX000d0EifX0"],
        "ServerNonce": "EyRSuA6di-CaMo7ZEKIx7g",
        "Witness": "ASOE-FANU-WN2N-UQ24-JBHE-GSHV-EKQL"}]}}
</div>
~~~~



# message status

~~~~
<div="helptext">
<over>
status   Request status of pending requests
    /requestid   Specifies the request to provide the status of
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Bob> message status tbs
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Bob> message status tbs /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
</div>
~~~~


# message accept

~~~~
<div="helptext">
<over>
accept   Accept a pending request
    /requestid   Specifies the request to accept
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> message accept tbs
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultSent:

~~~~
<div="terminal">
<cmd>Alice> message accept tbs /json
<rsp>{
  "ResultSent": {
    "Success": true,
    "Message": {
      "Sender": "alice@example.com",
      "Recipient": "alice@example.com",
      "Accept": true}}}
</div>
~~~~


# message reject

~~~~
<div="helptext">
<over>
reject   Reject a pending request
    /requestid   Specifies the request to reject
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> message reject tbs
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultSent:

~~~~
<div="terminal">
<cmd>Alice> message reject tbs /json
<rsp>{
  "ResultSent": {
    "Success": true,
    "Message": {
      "Sender": "alice@example.com",
      "Recipient": "alice@example.com",
      "Accept": false}}}
</div>
~~~~


# message block

~~~~
<div="helptext">
<over>
block   Reject a pending request and block requests from that source
    /requestid   Specifies the request to reject and block
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> message block mallet@example.com
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultSent:

~~~~
<div="terminal">
<cmd>Alice> message block mallet@example.com /json
<rsp>{
  "ResultSent": {
    "Success": true}}
</div>
~~~~


