

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
        "MessageID": "NAHZ-DU6P-73J4-W5WS-GZPJ-RGNB-WGAA",
        "EnvelopedRequestConnection": [{},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6
  IHsKICAgICJTZXJ2aWNlSUQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIk
  VudmVsb3BlZFByb2ZpbGVEZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUx
  MiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0
  FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lD
  SlZSRVlpT2lBaVRVTk9SUzFUVFRSVExUVTFSa3d0VlRaUldpMURXCiAgVFpNTF
  ZOT1MwRXRUelJWVkNJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6
  SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2
  dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNB
  Z0lDQWlVSFZpYkdsaklqb2dJbUpZUm1aWWNFOHlla0ozUmxkUU1HdERSVFZ0Y1
  RsCiAgMWVtSmhPSFpsU1ZSUWQxQjRabmgzVmxsUVVUTnNjSEpDUW0xR1VWWUtJ
  Q0JHVmtsbGJHSlJZbVpPU0VoMk8KICBWZENjMUpGZDAxaFkwRWlmWDE5TEFvZ0
  lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlp
  T2lBaVRVUTNVeTB5VmxCUkxWVkpWRWd0U2tVeVdTMVhWVk5JTFVGTVNWUXRXa1
  JKUnlJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3
  b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSU
  NBZ0lDQWdJbU55ZGlJNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZp
  YgogIEdsaklqb2dJblJMYm5GdFFVRnRhRVZKUVdWYVFqRlRNMjF2YlVodk0zSk
  RORUoyZEhsNWJuYzJZWEo1VW1KCiAgbE1sQm9hbnBMTW5CRk9HY0tJQ0JrUTNk
  WFNEUTVhMkphVlRsNVRHOTNNMlUyY2xCMGQwRWlmWDE5TEFvZ0kKICBDQWdJa3
  RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJ
  azFCU1ZBdFRrRgogIE9RaTFZUWxST0xVTlhXbG90VVVwR1R5MUJOVTVJTFVWSl
  QwOGlMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNL
  SUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0
  EKICBnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlt
  eHBZeUk2SUNKeFduaGtWR2w2VQogIG5GbFEyWTRlamR3ZEMxYVZIQnFMVlk0WX
  paNWVsWlFTMGRaVm1aUmVGUldSR0phVTBFeWRpMWFWVko2Q2lBCiAgZ2QzRTRO
  ek51WnpGaE56ZHZiR1J4VlUwMFlWWjBXREJCSW4xOWZYMTkiLAogICAgICB7Ci
  AgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1
  MTIiLAogICAgICAgICAgICAia2lkIjogIk1DTkUtU000Uy01NUZMLVU2UVotQ1
  k2TC1TTktBLU80VVQiLAogICAgICAgICAgICAic2lnbmF0dXJlIjogIlI5eDNM
  M0dCWExGOVBORXpuWjhnUllBUE5aeHhwUkc1NzR2WHZTazUyZmR1YUZYbDYKIC
  ByZkhKY01UallSbmJ3RkJoakhaa3RUWnh1aUFUY0NBMmNHSlFUbS1Mc004SEdW
  c21yNTlfR01JQjBFNFFVdQogIEhFRm9sTWF6b3Zkb2FmLWZ6NWNHWHhreTJIQ2
  9iYUZwN2lRSGdqaUVBIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIkc4
  aTg4c3plcEx6Q0tyS0ZweWNkMXhIaURhSVUwTlQxekxSMG13ZU1IODJLTgogIE
  9Mdjg5alhTYWV0RXRkUU9HaGQ0djdrZTUwTUtoeFAzdm43dGRKdnJRIn1dLAog
  ICAgIkNsaWVudE5vbmNlIjogIjZZUk44aFF6alhWQ0k5ams1SE5IVlEiLAogIC
  AgIlBpblVERiI6ICJORFkzLUlDSFAtTzJXRC1QVTI0LUw0In19"],
        "ServerNonce": "A-AMMofg-ZW7e3Mm_OxAlQ",
        "Witness": "4XPU-C5T4-JA3H-GQ3M-44SC-2FRC-TAR2"},
      {
        "MessageID": "NCOR-5R5M-T3UO-56RL-6RGR-DRD5-IM4G",
        "EnvelopedRequestConnection": [{},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6
  IHsKICAgICJTZXJ2aWNlSUQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIk
  VudmVsb3BlZFByb2ZpbGVEZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUx
  MiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0
  FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lD
  SlZSRVlpT2lBaVRVRllWQzFGUWpkVExUUkpUVXN0VTAxUlZ5MVJNCiAgMVpLTF
  VOTVMxRXROMUpOU3lJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6
  SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2
  dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNB
  Z0lDQWlVSFZpYkdsaklqb2dJbXMwVjAxVGNWbG5XVmRwTkUxQlRWZG5lRkZ5VU
  RWCiAgTWNuaG9WVzk2TUV4Q1gwSkhNMlZmZVRKeVEyd3lZV1Z0WTJOUmVIQUtJ
  Q0JoU2pObk9UWlVkMDlwWDBsSlEKICAxcFBSRzlIZW1odFpVRWlmWDE5TEFvZ0
  lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlp
  T2lBaVRVSkRUaTFhV2xkRUxUWTNRazB0U2pKVFRDMVVRek0zTFVkWFIwb3RSVX
  BZUlNJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3
  b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSU
  NBZ0lDQWdJbU55ZGlJNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZp
  YgogIEdsaklqb2dJbUpWUWxsSU5YQklWV1ZZWXkxc1owSndRbGxqYzJKQmEzRk
  pSVU5IVkY5alIzRXljVk5tVlRSCiAgTU5EUnJVRTVoT0ZWTk1XMEtJQ0J3ZDFG
  Mk1XcFZiME5WUlZWdVdscFVSM05vZDA0dGEwRWlmWDE5TEFvZ0kKICBDQWdJa3
  RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJ
  azFCVTFndE5WWgogIFRXUzB6VDB0TExVZEJOVE10UjBsWlJpMHlSalpDTFZOUE
  5rUWlMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNL
  SUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0
  EKICBnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlt
  eHBZeUk2SUNKNFpXRlFia2RKTgogIEc5SGQzb3lMVFF5VEdWa1ZUTTNZbTF2VE
  dscFlrMUhaRWhTUjJObVVsTjZjV2xJV0hkVk9URXhVRjlJQ2lBCiAgZ1NYSmhV
  bVJhVWxkNlgwOUNURVIxYkZkb00zUjNjbEZCSW4xOWZYMTkiLAogICAgICB7Ci
  AgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1
  MTIiLAogICAgICAgICAgICAia2lkIjogIk1BWFQtRUI3Uy00SU1LLVNNUVctUT
  NWSi1DTEtRLTdSTUsiLAogICAgICAgICAgICAic2lnbmF0dXJlIjogInNJbk5P
  RUVRSjN3aFVibUJIR0dWNXJCVmhtRWRfUE40eWRRUW9DYXBXVEJJSlQxc2QKIC
  BidkFCVllxR1NCcmx4Q2lTSDRmTVFlVWlTNkFpaHhqTHRZR2N5RC01VUVQOUpK
  YzlSWU5SZFlYdGRnMzZSUAogIEhWX3loaUpXcktHdU1tdlBveW1QTkk1ZUYzZE
  xPV1dYdHNNS1Y4eXNBIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIlE5
  UUU3U0E5RTRwckk2NGV6eFJvSHRlb1JORUNYc1V6dDZEYzZwZzZpM3BnLQogIF
  VjY1BCRy0xSUMxVzQ1UU1RMy10WXRsUnE2dDJrQzR1UV9vZ2NTTFhRIn1dLAog
  ICAgIkNsaWVudE5vbmNlIjogImpDVG5rbjJOd21nSklsMUYzMGtuVHcifX0"],
        "ServerNonce": "tbXfF-H7t9Bewo6QH9P7Yg",
        "Witness": "SYWD-GC4A-FZPO-ZY27-FEKV-LEMM-LVLO"},
      {
        "MessageID": "NACG-VWPR-YKGR-WUSJ-RTWE-WVXS-RVZS",
        "EnvelopedRequestConnection": [{},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6
  IHsKICAgICJTZXJ2aWNlSUQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIk
  VudmVsb3BlZFByb2ZpbGVEZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUx
  MiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0
  FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lD
  SlZSRVlpT2lBaVRVSkVUQzFQUWt0RUxVdFdVRkF0VjFSTFFpMVVVCiAgMFpFTF
  ZGV05VRXRSMHhXUnlJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6
  SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2
  dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNB
  Z0lDQWlVSFZpYkdsaklqb2dJbEpDUzFsdFkyWlBjWGhyWjBSck9HRnBUbVYxYV
  VFCiAgMU1rbzJha0pKT0dsSmVreFhkMlZYZVZKcGJXTllhekZVWW5oeU5ISUtJ
  Q0IzT1hWR1N6UTJUbU00Ukd0dmIKICAzZFdWRlJtVjA0eWQwRWlmWDE5TEFvZ0
  lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlp
  T2lBaVRVSlFVaTFJUTB0R0xVMUJWMVl0TWpSTlNTMUlNazlVTFUxTVdVVXRRa1
  JPU3lJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3
  b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSU
  NBZ0lDQWdJbU55ZGlJNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZp
  YgogIEdsaklqb2dJa2hDWTFWdlUydHdjakU0VFdac2RrUnVNMU41VmxOM1RIVk
  dObWxZWTI1WGVqZFFZMDVKWTJ0CiAgM2JrNUlUblp0VVVKS09XZ0tJQ0IxZG1a
  S0xUTktMVU42UW1OTFpFZExWbVJaZFVwdU5rRWlmWDE5TEFvZ0kKICBDQWdJa3
  RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJ
  azFEUkRRdFZsUgogIFZReTAwUlRjMkxWRlJSRmd0V0VGSVVpMUZTRFUxTFRWT1
  NVd2lMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNL
  SUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0
  EKICBnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlt
  eHBZeUk2SUNKRFlVUk5ZbWhJVwogIG00dFNFb3diMU5PWW1GT2VEZFdkRmhPYz
  NwTWRXWTBlRVJFUkRObmRqQXdYekJwTkhJMlgwTk5SRzlNQ2lBCiAgZ2VHNTRX
  VkJYUzNsU2FscG9TM0JSVEZVMVNrWklMVEpCSW4xOWZYMTkiLAogICAgICB7Ci
  AgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1
  MTIiLAogICAgICAgICAgICAia2lkIjogIk1CREwtT0JLRC1LVlBQLVdUS0ItVF
  NGRC1RVjVBLUdMVkciLAogICAgICAgICAgICAic2lnbmF0dXJlIjogIjRQYjNY
  S243VFZtWjJxcVJuQy12cVYyc0szQ2JETTRTTmozYkZ0dFhzWmFSbXplUFIKIC
  AxdFRyOHF5NzY3RVQyaFE0b3dCeEtQS2lQV0FXa1h1TU9OdXdKdjl6QmFxcm1T
  d3pEVl9Bdk1WX0FBc251VwogIFVUaGt5OW45a0JoMHhLOGRQNmZiSi0tZS1RZl
  VNR3lKWFZrUjh6ajRBIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIlcw
  QmtBdWxvc2dhRk56TWJzUzY5VVdiUmtBZi13dUY2a2piYXdHNVlkSVlMUwogIF
  FLN3BTS19xVzFIWkdtUGFSXzNJT3hTamtkMkxWN1lxamZjV05LZFNRIn1dLAog
  ICAgIkNsaWVudE5vbmNlIjogIlA3WUhSQl9LN2pLSGtzY0lvSENld0EifX0"],
        "ServerNonce": "YoEB3s5RQhAd6jvIEOqLsw",
        "Witness": "VHHK-22IB-74MU-JOLK-GJF7-SE6W-6TR7"}]}}
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


