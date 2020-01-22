

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
        "MessageID": "NBI5-S6VW-JJ5A-SBAD-HR32-6C2X-Z7V2",
        "EnvelopedRequestConnection": [{},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6
  IHsKICAgICJTZXJ2aWNlSUQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIk
  VudmVsb3BlZFByb2ZpbGVEZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiU0hB
  MiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0
  FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lD
  SlZSRVlpT2lBaVRVSllWQzAyVjBkVExVa3lVa2N0UlUweU1pMDFVCiAgalpUTF
  RaVVFUSXRRMGhDU2lJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6
  SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2
  dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNB
  Z0lDQWlVSFZpYkdsaklqb2dJbTU2ZUUxVk5rZzBRM2MxV0RsUlgyWk9PR2MyYk
  hvCiAgd1dIVjJaRjl4TmxOaVNHZFJiMmR2VkVSSWVHTnFTR1E1T1ZSVVJuY0tJ
  Q0JQYWpOR1ozWlpTMjlRV2xoemEKICBuQnJWUzFxU0V4d2QwRWlmWDE5TEFvZ0
  lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlp
  T2lBaVRVUkRVaTFQTWxsYUxUVlRObFF0V2pjelVDMVhSMUkxTFVwQ1dsSXRXVl
  pRVVNJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3
  b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSU
  NBZ0lDQWdJbU55ZGlJNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZp
  YgogIEdsaklqb2dJbm8xVFV0alZrcE1SMUZSYzBWSFpuSkRhbXM1WVZwbGVHZ3
  pVRjlDTmtscldsbzVjbXhVU2pJCiAgeFNsazBVaTB6ZFZGVVZYRUtJQ0JUYjNO
  VVRIVnVaR2hTVFV4SlNVeFVkVWxZV0VWNVQwRWlmWDE5TEFvZ0kKICBDQWdJa3
  RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJ
  azFEVkZrdFVWWgogIElTeTFaUjFwV0xVcEpTMUF0V2t4VFVDMHpTelJLTFZSWl
  JWY2lMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNL
  SUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0
  EKICBnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlt
  eHBZeUk2SUNKRVZqaFFjekZQVgogIEdOM05HWm5SalJPWkcxMmMzRjRORlpDUT
  I1SlozTlpOV3BwVDBKUFpYVlRSMHhLZVZCalJFdEpZV1UyQ2lBCiAgZ1UydFZS
  ekpYTmpsNlJ6TmxibXh2YVU5ck1uZDNZalpCSW4xOWZYMTkiLAogICAgICB7Ci
  AgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlNI
  QTIiLAogICAgICAgICAgICAia2lkIjogIk1CWFQtNldHUy1JMlJHLUVNMjItNV
  I2Uy02VEEyLUNIQkoiLAogICAgICAgICAgICAic2lnbmF0dXJlIjogImc1Z1Zy
  M3JmdGQ5YmZJR3N6WXZTYjhGUXZoaWp0VUtxSm5lUzg5eEVfaGMtM3JKNHEKIC
  Brc24wdTREa3RFY2tGTzU5YVFqalRZUE0teUE3aWNfdGRpY1VPMXRLV1dtUU92
  VU1aVEhDdlFsODlaSWYtYQogIGRCYm40UWlJTVZFcURuTTM4bUtYTF9PTm5iMW
  1UQWgwZTg2d3hPUklBIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogImpU
  elozRm5MTkxwWjQyaHRKMGhFelVKRi0tVHR3N28yT2dHZkZnTXVDXzRJWAogIF
  9ZMFFLR1JHZ3VnVHAxT0RYZzVoMXVTeTN4Rl9sMksyWXp5X1pua2NnIn1dLAog
  ICAgIkNsaWVudE5vbmNlIjogIk1ZV1lJS2dDV1M5UUFIUjVvbWl5VHciLAogIC
  AgIlBpblVERiI6ICJOQ0FYLUJWWFktNU8zWS1DUFpTLU9VIn19"],
        "ServerNonce": "LFn_lDhJITBUOtIJ4vk2Cg",
        "Witness": "RDPZ-WAM2-QD3P-YNJE-R3BV-NXOF-OEFC"},
      {
        "MessageID": "NCPO-L452-CMZY-MLQO-TM52-KQYW-EFGP",
        "EnvelopedRequestConnection": [{},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6
  IHsKICAgICJTZXJ2aWNlSUQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIk
  VudmVsb3BlZFByb2ZpbGVEZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiU0hB
  MiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0
  FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lD
  SlZSRVlpT2lBaVRVUkpWaTFLU2tOQkxVaFFSbG90U1RKV1RpMUxXCiAgRFZPTF
  ROVFZVRXRVMUpSV1NJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6
  SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2
  dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNB
  Z0lDQWlVSFZpYkdsaklqb2dJbTFWVm1Gb1ltZzJjSEYzWjBONFMwVXpiRFk1Y1
  hwCiAgTVprVktWVTFVZWw5cU1sZDNRMlUwTlhFelJ5MVdhVFJOWXkxcmQwVUtJ
  Q0JJZVUxWFEyVnpaM05UV2prNVYKICBtRjFla1ZrYlRaeFpVRWlmWDE5TEFvZ0
  lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlp
  T2lBaVRVRklRUzB6UWtFMUxWQTFOak10VWpkSlR5MUhRelZCTFZkS1RVSXROVU
  pQUXlJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3
  b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSU
  NBZ0lDQWdJbU55ZGlJNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZp
  YgogIEdsaklqb2dJa2RaVmxwYU9XbFdTbEozV0ZoVlRtMXpVRXh3Tm01WFNYTm
  lZMkZZZWtkYVlsTk1kR2w0WVdZCiAgNWVIRTJjblJRTjFsSFpGZ0tJQ0E0TjFo
  eGFXRlNPVnBuWkZWdmQzQTJka3M1YUdRMldVRWlmWDE5TEFvZ0kKICBDQWdJa3
  RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJ
  azFEUzBndE5qVgogIERSUzFTUTFwYUxVRlZUa3d0TTBVMFVpMUxVVFJFTFZwWl
  QxRWlMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNL
  SUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0
  EKICBnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlt
  eHBZeUk2SUNKd2FDMXBjMkpDVAogIERJMU9HSjVORFpxZWxCUFdWb3dWMnMyVV
  RKMmVtWnVYMVU0WDJSWFNXODVUa1ZCWkdoRFZGcEJka3RRQ2lBCiAgZ1VtSkxV
  bTVLWjBzd2FsUXRkME5PYUcwNGRuQkpiRk5CSW4xOWZYMTkiLAogICAgICB7Ci
  AgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlNI
  QTIiLAogICAgICAgICAgICAia2lkIjogIk1ESVYtSkpDQS1IUEZaLUkyVk4tS1
  g1Ti0zU1VBLVNSUVkiLAogICAgICAgICAgICAic2lnbmF0dXJlIjogIkdVVWtR
  WW1LQUc2YlJ5ekgxNGFEbzV4VWgxUjFFTGhWUUxjWDYyZzhOU1hRUWxwZ3QKIC
  BjWUc3SHQxZ1VDQmJscVpWa2hqbnltc0hlOEFGd2E3SlBmQWs4MTJvTmN5OVBL
  ZWNRX1F4SXJDRHRadnhYcwogIDZCbWo5S1FYUHFHZTB4eFB0bWxfZ0ZobzdQRG
  JiU0VKeGRvVEZIQzhBIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIjRJ
  T1NqZFVfQVVWbDNrZENXQ2toRjBaZmFLWEZ4MTN0SXZMNnMwdFg0UDJuWQogIF
  9GQUFDOWk2UXJ5SzF2WHBabmw3YVFyQVlGWjd5Mk5KSXBZajh4SW9BIn1dLAog
  ICAgIkNsaWVudE5vbmNlIjogIjhXV0xoN3BOOXc1UVduYTF4S1BaYUEifX0"],
        "ServerNonce": "jWEMY7ODhvO9UwAdKSiAcA",
        "Witness": "AEJC-J3HS-3PSM-VQPX-ZWDR-UBSK-NXPN"},
      {
        "MessageID": "NCWO-SIYM-U3KV-YMR6-HRHQ-SQEK-I26H",
        "EnvelopedRequestConnection": [{},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6
  IHsKICAgICJTZXJ2aWNlSUQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIk
  VudmVsb3BlZFByb2ZpbGVEZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiU0hB
  MiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0
  FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lD
  SlZSRVlpT2lBaVRVSkxSaTAxTkZKSkxWcEROVFV0UTFsTVRTMWFXCiAgbFJYTF
  ZKS1FrOHRURkpPVGlJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6
  SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2
  dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNB
  Z0lDQWlVSFZpYkdsaklqb2dJblpvWDNVMGFuSlNUVXRaZEhaUFpWazVkMnA1Y0
  c1CiAgdWVWaEthRjk2ZUV4a09HNTNSMGQ0UnpGTmMybGZiVEZ0YTI5aVEzb0tJ
  Q0JXY0RsMloxSkxVbGQwTlRWd1QKICB6QjJkbU5EYWtWclZVRWlmWDE5TEFvZ0
  lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlp
  T2lBaVRVUmFVQzFQTmtKRkxVRk9Xa1F0TjBaYVFpMUtRMVZGTFZCWVdVY3RVRE
  0xTmlJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3
  b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSU
  NBZ0lDQWdJbU55ZGlJNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZp
  YgogIEdsaklqb2dJbUZSVkZneE1GSXhTbXQwVFU5ZlRVUkpkbE5UTW5sUmFGWl
  VhMU5QYld0NFdFeDBRVkU1V1hJCiAgelRXZE5aMFYwVFdkbFgyd0tJQ0I2ZVVW
  cFZGVkhiemRzUWpSemJtdFNRbTQzZVhwT1QwRWlmWDE5TEFvZ0kKICBDQWdJa3
  RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJ
  azFEUlZrdFdETgogIFBTaTFGV1VsR0xVNDFUMFF0UWxCQlJpMVhTRUZVTFRKU1
  NqSWlMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNL
  SUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0
  EKICBnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlt
  eHBZeUk2SUNKV2F6Rktaakl5VAogIDJaS1RqUndhRlU0WVhaMVJFcHZTRVI2Ul
  ZGNlgxSXRlbkoyYlVSaGJVdHVhbFpuY2pkUGIxOTJTaTFIQ2lBCiAgZ1VVMUxi
  MU42UldnMVl6YzFiMEoyUlRCS2IzcHlOVWxCSW4xOWZYMTkiLAogICAgICB7Ci
  AgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlNI
  QTIiLAogICAgICAgICAgICAia2lkIjogIk1CS0YtNTRSSS1aQzU1LUNZTE0tWl
  pUVy1SSkJPLUxSTk4iLAogICAgICAgICAgICAic2lnbmF0dXJlIjogIkZkb3pZ
  Zi1VRk42enhHWDRPaGEtT05uMjZFUk5kdzJZQ2RTU2dSTzJvVUJhX2FzclMKIC
  BIal9kd0t0LVNqMHo4TUdvZEVpWWh4bzNKR0FaZ3hVSzhTa3doaVhXdTJqOHRZ
  TXBsak40U3NfQndMUmFWMwogIDlRQkcxU2JPY1NKMnI4ZGhuWU1ZV1hGTnRLQ0
  lBcVZSWl84UVRSakVBIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIll1
  UFdlMjctSS12OUlxWUcyVFhieXpzbm56cEpMaFJfcW9EZ3JrazU0dTVTcAogIF
  ZPRFFZaWFLM2tPQmFSTDdua0xXUVBhUXBMRGtKQUdzQU1sMVMtTWVBIn1dLAog
  ICAgIkNsaWVudE5vbmNlIjogImFpbmNfTF9WTWIzOWtLdUY4bHFSWXcifX0"],
        "ServerNonce": "WnJ_Y79eg7anvOLHM9pjZg",
        "Witness": "NGPY-QAYV-OCQD-W6JD-U3HP-3OAQ-57OW"}]}}
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


