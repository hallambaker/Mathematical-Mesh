

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
      "MessageID": "NAKQ-VJU5-XERR-C3C2-YBFL-HZXN-TWGD",
      "Sender": "bob@example.com",
      "Recipient": "alice@example.com",
      "Subject": "alice@example.com",
      "PIN": "ECFX-4MRD-ALZE-QDW2-242H-5LXI-OM7N",
      "Self": [{
          "dig": "SHA2"},
        "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2hvcnMiOiBbewo
  gICAgICAgICJVREYiOiAiTUFNVy1LWlRZLVFCWjItWkNZUS00NzJJLUVKNjItN
  E03TSIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSwKICAgICJOZXR
  3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6ICJib2JAZXhhb
  XBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWNjb3VudCI6IFt
  7CiAgICAgICAgICAgICJkaWciOiAiU0hBMiJ9LAogICAgICAgICAgImV3b2dJQ
  0pRY205bWFXeGxRV05qYjNWdWRDSTZJSHNLSUNBZ0lDSkxaWGxQWm1ac2FXNWx
  VMmwKICBuYm1GMGRYSmxJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFCVFZjd
  FMxcFVXUzFSUWxveUxWcERXVkV0TgogIERjeVNTMUZTall5TFRSTk4wMGlMQW9
  nSUNBZ0lDQWlVSFZpYkdsalVHRnlZVzFsZEdWeWN5STZJSHNLSUNBCiAgZ0lDQ
  WdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0FnSUNKamN
  uWWlPaUFpUldRME4KICBEZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2S
  UNKWFlYVmxXVlZ5YVZRNVpFcHJWV1ZMVkZSek9WOQogIFVWWFJSY21Sd1pHTnd
  Wek52VHpkYVFWVlFhRmRIY2sxbGRFRk1UWGhXQ2lBZ1ZqVlFNamxVZFZWc2RrO
  UVPCiAgRWRQUjBKR1FuQTRZbGRCSW4xOWZTd0tJQ0FnSUNKTFpYbHpUMjVzYVc
  1bFUybG5ibUYwZFhKbElqb2dXM3MKICBLSUNBZ0lDQWdJQ0FpVlVSR0lqb2dJa
  zFDUWxjdFdVSTJXQzFFVGtwU0xVWllXRW90VFVkV1N5MDBVbEZPTAogIFVWRk5
  WTWlMQW9nSUNBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam9nZXdvZ
  0lDQWdJQ0FnSUNBCiAgZ0lsQjFZbXhwWTB0bGVVVkRSRWdpT2lCN0NpQWdJQ0F
  nSUNBZ0lDQWdJQ0pqY25ZaU9pQWlSV1EwTkRnaUwKICBBb2dJQ0FnSUNBZ0lDQ
  WdJQ0FpVUhWaWJHbGpJam9nSW1NemF6RTFOUzFrUnpGdmRFSjNTVkV3TjJSU1d
  WQQogIDNkV3BHY2xSZmRqTXpYME5rUTJWblExOHljbDlNVlV0bU5GTmhOVW9LS
  UNCQ2VtczNMVjlYZEhJMGRXZGFRCiAga2xVUkhZMVdIZFBWVUVpZlgxOVhTd0t
  JQ0FnSUNKQlkyTnZkVzUwUVdSa2NtVnpjMlZ6SWpvZ1d5SmliMkoKICBBWlhoa
  GJYQnNaUzVqYjIwaVhTd0tJQ0FnSUNKTlpYTm9VSEp2Wm1sc1pWVkVSaUk2SUN
  KTlJGZFFMVVJPVwogIFV3dFNWYzBTeTFUUWxoTExVdEdRVEl0V1U0M1VDMDNSV
  kZVSWl3S0lDQWdJQ0pMWlhsRmJtTnllWEIwYVc5CiAgdUlqb2dld29nSUNBZ0l
  DQWlWVVJHSWpvZ0lrMURUMGt0UzBKUE5pMVVUVVJVTFZCTVJsVXROa2RNVkMxS
  1YKICB6UXpMVTVEU0VNaUxBb2dJQ0FnSUNBaVVIVmliR2xqVUdGeVlXMWxkR1Z
  5Y3lJNklIc0tJQ0FnSUNBZ0lDQQogIGlVSFZpYkdsalMyVjVSVU5FU0NJNklIc
  0tJQ0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlXRFEwT0NJc0NpQWdJCiAgQ0FnSUN
  BZ0lDQWlVSFZpYkdsaklqb2dJa0ZwY1Y5SVMyYzBPRm8xZEU5U05FNDNka2xEZ
  UVOVk1FeDZlamQKICB0UkZGYWVVRjBhMngwYVdaRE5UaDFVbko0UW1Ga2NTMEt
  JQ0F5WWkxWVpHTlBXVGREVlhWSmJqZ3hXRWhGUQogIHpOSmVVRWlmWDE5TEFvZ
  0lDQWdJa3RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlV
  SCiAgR0lqb2dJazFCTnpVdE4xTXlVaTFQUlVWVkxVMUtWVmN0VTBNMFVpMHlUV
  FJSTFVGS1ZFVWlMQW9nSUNBZ0kKICBDQWlVSFZpYkdsalVHRnlZVzFsZEdWeWN
  5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSQogIDZJSHNLS
  UNBZ0lDQWdJQ0FnSUNKamNuWWlPaUFpV0RRME9DSXNDaUFnSUNBZ0lDQWdJQ0F
  pVUhWaWJHbGpJCiAgam9nSWs1NVpGaEpUVlZMUVhSMllrMVBOa3N0ZDNWRlh6Q
  lFjVTlKVEZCWFNUaEVZM3BxWm5ScldXRlVRazgKICB4YWpWaWRISnFabWNLSUN
  CSE56RTFTa3MyUmtNNFJpMUxiVzFPVWpaRFRrSkxRMEVpZlgxOUxBb2dJQ0FnS
  QogIGtWdWRtVnNiM0JsWkZCeWIyWnBiR1ZUWlhKMmFXTmxJam9nVzNzS0lDQWd
  JQ0FnSUNBaVpHbG5Jam9nSWxOCiAgSVFUSWlmU3dLSUNBZ0lDQWdJbVYzYjJkS
  lEwcFJZMjA1YldGWGVHeFZNbFo1Wkcxc2FscFRTVFpKU0hOTFMKICBVTkJaMGx
  EU2t4YVdHeFFXbTFhYzJGWE5XeFZNbXdLSUNCdVltMUdNR1JZU214SmFtOW5aW
  GR2WjBsRFFXZAogIEpRMEZwVmxWU1IwbHFiMmRKYXpGQ1YwWnZkRk5XUWtoT2V
  URlhVMFZHVUV4V1pGSldWbEYwVVFvZ0lEQktWCiAgVlJETVVsVVJrMTVURlpPV
  EZReFkybE1RVzluU1VOQlowbERRV2xWU0ZacFlrZHNhbFZIUm5sWlZ6RnNaRWQ
  KICBXZVdONVNUWkpTSE5MU1VOQkNpQWdaMGxEUVdkSlEwRnBWVWhXYVdKSGJHc
  FRNbFkxVWxWT1JWTkRTVFpKUwogIEhOTFNVTkJaMGxEUVdkSlEwRm5TVU5LYW1
  OdVdXbFBhVUZwVWxkUk1FNEtJQ0JFWjJsTVFXOW5TVU5CWjBsCiAgRFFXZEpRM
  EZuU1d4Q01WbHRlSEJaZVVrMlNVTkthVmt5Y0dGaFZWRjZVVzFrVVdOVWFFOVR
  SVVUwVmtaR2UKICBtSkZjQW9nSUZKaWVrSjZUMFV4TkZJeGJ6QldWMUpRVlZZN
  GVtTkhXa0pYUjJodFZXdGtUR1JFYUROaFZtaAogIHNRMmxCWjFwVWJEWk5lbG8
  wVmpCS2VGWkhWa3RTQ2lBZ2EyaG9aREE1ZFZSWFRsQmpiV3hDU1c0eE9XWlRkC
  iAgMHRKUTBGblNVTktURnBZYkVaaWJVNTVaVmhDTUdGWE9YVkphbTluWlhkdlo
  wbERRV2RKUTBFS0lDQnBWbFYKICBTUjBscWIyZEphekZGVFRCbmRFMHdPVXhTY
  VRGTVZFUk5NRXhWTURKUk1GbDBVMnRXU0ZaVE1VSk5hMVpPVAogIEZWT1ZWZFd
  WV2xNUVc5blNRb2dJRU5CWjBsRFFXbFZTRlpwWWtkc2FsVkhSbmxaVnpGc1pFZ
  FdlV041U1RaCiAgSlNITkxTVU5CWjBsRFFXZEpRMEZwVlVoV2FXSkhiR3BUTWx
  ZMVVsVk9DaUFnUlZORFNUWkpTSE5MU1VOQloKICAwbERRV2RKUTBGblNVTkthb
  U51V1dsUGFVRnBWMFJSTUU5RFNYTkRhVUZuU1VOQlowbERRV2RKUTBGcFZVaAo
  gIFdhV0lLSUNCSGJHcEphbTluU1c1Q1NtTnFiRkZsVkZaeVYyMDFNbEZWT1hCa
  FZGb3dVa1ZrVW1WcVl6RmFSCiAgbFpEVGxST2NGRnJTWGhOTUZwTFVWaGFlbE5
  FU2dvZ0lFNWtTR3hLVlRKU1VWZEdXak5VVjAxTFNVTkNjbFUKICB6Ums5VVIyd
  zFWSHBDY0ZWVVNtRmhia1UxVVd0U1dGWnRjRzFQUlVWcFpsZ3hPV1pZTUNJc0N
  pQWdJQ0FnSQogIEhzS0lDQWdJQ0FnSUNBaWMybG5ibUYwZFhKbGN5STZJRnQ3Q
  2lBZ0lDQWdJQ0FnSUNBZ0lDSmhiR2NpT2lBCiAgaVUwaEJNaUlzQ2lBZ0lDQWd
  JQ0FnSUNBZ0lDSnJhV1FpT2lBaVRVRllXaTFKVUVjM0xWWklRVTh0VjFGVlYKI
  CBDMURRbFJNTFVoTVV6SXRVMHRQVnlJc0NpQWdJQ0FnSUNBZ0lDQWdJQ0p6YVd
  kdVlYUjFjbVVpT2lBaVVUaAogIDBWVGh4Vlc1UWRuQjRSWEZ3V21SZlZGZHJka
  2xPT0Y4eFdYUlNRMnQ0UjNGVGF6SkZlR0ZrWHpSUWJGZDZjCiAgZ29nSUVGNlI
  xOWpXRGxXVkRWVmJVOWhTalpqYldrdGJFMDRhRVk0UVcwdFQyZFNUbXQ0UjJ0a
  U1YbGZUMWwKICAwWVV0Q1dHNVZaVUpIU0VjemFuUnVjR3hWQ2lBZ2RuZ3pWbXh
  YVW1WS2JqQldjVmxOYVZSbVkwRlJOVkJMVAogIG5WcVNHSm1OR2xEYzI4MlVGT
  kJZMEVpZlYwc0NpQWdJQ0FnSUNBZ0lsQmhlV3h2WVdSRWFXZGxjM1FpT2lBCiA
  gaWRGZElPVEJQTlhWV0xXSTJWblpKYW1sM2FVTnNVbXRLTmtReVF6WTBSMXBNV
  0hGYWF6VndRV2g0ZEZGWEMKICBpQWdkM0ZqUTNwTFRUTm1OM00yYzJ4UGRVbzJ
  abG95TmpkMVJHYzJVVkV5VlVZMU5WOTJhbk5wVTBFaWZWMQogIDlmUSIsCiAgI
  CAgICAgICB7CiAgICAgICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICA
  gICAgICAgICJhbGciOiAiU0hBMiIsCiAgICAgICAgICAgICAgICAia2lkIjogI
  k1CTVgtTlZOQS1USFVLLVc2UFUtVEFRWC1aU1pGLVFNS1IiLAogICAgICAgICA
  gICAgICAgInNpZ25hdHVyZSI6ICJmcEFuMjU5cTdLbG04ckFEa2xUQ1pNbS1RU
  k42MEw3SHQtZHFRUnM3anA0czNwRzgyCiAgTm51Mlg2dlpHcFhXUGlHLW5fOUc
  3eDhrOHdBeVY1bHgwaWtSX2xnN0k0VGd6cDRxSElPUy1JNVNEVjA0dUcKICBiV
  Up3OEF3N3Q2R2REVWxlVlhCbHBmZGxyQUJoSlIxMHpEcG9xeml3QSJ9XSwKICA
  gICAgICAgICAgIlBheWxvYWREaWdlc3QiOiAiSExUWENlWnkwWnlCLTEtRVBYS
  3A3MGY3Rmh6YUNGNzhLeC1QMlZ0QmRNRkVoCiAgM3JfU1JtV1YxUTBnSkd3aS0
  3aURmVW9xbm9xVS1xZkxxNmpfZ1c0eWcifV0sCiAgICAgICAgIlByb3RvY29sc
  yI6IFt7CiAgICAgICAgICAgICJQcm90b2NvbCI6ICJtbW0ifV19XX19",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MBMX-NVNA-THUK-W6PU-TAQX-ZSZF-QMKR",
              "signature": "9tsNFm1jNVzzB6C3OI36W6EEXqDl7vA7DkG6aTf2eHd1K2WWi
  -u8d10FJwnoYL6_18OBSmTpoSaA7sSsYO5SJ6iN5JDZ2WTHDpkz2UxKHc8-1p3
  BEaloP7Cti2MNDpQ5mtcKKGzv1LguA-ignpNusg0A"}],
          "PayloadDigest": "Qj8nBxCQb17clLUcChnerfrr5C68FlMQkqaDxSqMtJNmq
  6H1sNbYn6U67fcsSA3Vr0WQUgf2vnnPYrkjHQb8sA"}]}}}
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
      "MessageID": "NCQE-3QRC-EDZA-COVP-MMMH-PS5Q-FXWI",
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
<rsp>MessageID: NAKQ-VJU5-XERR-C3C2-YBFL-HZXN-TWGD
        Contact Request::
        MessageID: NAKQ-VJU5-XERR-C3C2-YBFL-HZXN-TWGD
        To: alice@example.com From: bob@example.com
        PIN: ECFX-4MRD-ALZE-QDW2-242H-5LXI-OM7N
MessageID: CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z
        Connection Request::
        MessageID: CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z
        To:  From: 
        Device:  MD7W-S6XF-V4EL-7QEO-MUPK-B5JL-MLPY
        Witness: CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z
MessageID: XP3F-7HEO-OYBH-SKCJ-EO7P-Q54P-6HED
        Connection Request::
        MessageID: XP3F-7HEO-OYBH-SKCJ-EO7P-Q54P-6HED
        To:  From: 
        Device:  MC6T-FX77-ABC5-BVJ5-U3C4-MYCH-PQVR
        Witness: XP3F-7HEO-OYBH-SKCJ-EO7P-Q54P-6HED
</div>
~~~~

Specifying the /json option returns a result of type ResultPending:

~~~~
<div="terminal">
<cmd>Alice> message pending /json
<rsp>{
  "ResultPending": {
    "Success": true,
    "Messages": [{
        "MessageID": "NAKQ-VJU5-XERR-C3C2-YBFL-HZXN-TWGD",
        "Sender": "bob@example.com",
        "Recipient": "alice@example.com",
        "Subject": "alice@example.com",
        "PIN": "ECFX-4MRD-ALZE-QDW2-242H-5LXI-OM7N",
        "Self": [{
            "dig": "SHA2"},
          "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2hvcnMiOiBbewo
  gICAgICAgICJVREYiOiAiTUFNVy1LWlRZLVFCWjItWkNZUS00NzJJLUVKNjItN
  E03TSIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSwKICAgICJOZXR
  3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6ICJib2JAZXhhb
  XBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWNjb3VudCI6IFt
  7CiAgICAgICAgICAgICJkaWciOiAiU0hBMiJ9LAogICAgICAgICAgImV3b2dJQ
  0pRY205bWFXeGxRV05qYjNWdWRDSTZJSHNLSUNBZ0lDSkxaWGxQWm1ac2FXNWx
  VMmwKICBuYm1GMGRYSmxJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFCVFZjd
  FMxcFVXUzFSUWxveUxWcERXVkV0TgogIERjeVNTMUZTall5TFRSTk4wMGlMQW9
  nSUNBZ0lDQWlVSFZpYkdsalVHRnlZVzFsZEdWeWN5STZJSHNLSUNBCiAgZ0lDQ
  WdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0FnSUNKamN
  uWWlPaUFpUldRME4KICBEZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2S
  UNKWFlYVmxXVlZ5YVZRNVpFcHJWV1ZMVkZSek9WOQogIFVWWFJSY21Sd1pHTnd
  Wek52VHpkYVFWVlFhRmRIY2sxbGRFRk1UWGhXQ2lBZ1ZqVlFNamxVZFZWc2RrO
  UVPCiAgRWRQUjBKR1FuQTRZbGRCSW4xOWZTd0tJQ0FnSUNKTFpYbHpUMjVzYVc
  1bFUybG5ibUYwZFhKbElqb2dXM3MKICBLSUNBZ0lDQWdJQ0FpVlVSR0lqb2dJa
  zFDUWxjdFdVSTJXQzFFVGtwU0xVWllXRW90VFVkV1N5MDBVbEZPTAogIFVWRk5
  WTWlMQW9nSUNBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam9nZXdvZ
  0lDQWdJQ0FnSUNBCiAgZ0lsQjFZbXhwWTB0bGVVVkRSRWdpT2lCN0NpQWdJQ0F
  nSUNBZ0lDQWdJQ0pqY25ZaU9pQWlSV1EwTkRnaUwKICBBb2dJQ0FnSUNBZ0lDQ
  WdJQ0FpVUhWaWJHbGpJam9nSW1NemF6RTFOUzFrUnpGdmRFSjNTVkV3TjJSU1d
  WQQogIDNkV3BHY2xSZmRqTXpYME5rUTJWblExOHljbDlNVlV0bU5GTmhOVW9LS
  UNCQ2VtczNMVjlYZEhJMGRXZGFRCiAga2xVUkhZMVdIZFBWVUVpZlgxOVhTd0t
  JQ0FnSUNKQlkyTnZkVzUwUVdSa2NtVnpjMlZ6SWpvZ1d5SmliMkoKICBBWlhoa
  GJYQnNaUzVqYjIwaVhTd0tJQ0FnSUNKTlpYTm9VSEp2Wm1sc1pWVkVSaUk2SUN
  KTlJGZFFMVVJPVwogIFV3dFNWYzBTeTFUUWxoTExVdEdRVEl0V1U0M1VDMDNSV
  kZVSWl3S0lDQWdJQ0pMWlhsRmJtTnllWEIwYVc5CiAgdUlqb2dld29nSUNBZ0l
  DQWlWVVJHSWpvZ0lrMURUMGt0UzBKUE5pMVVUVVJVTFZCTVJsVXROa2RNVkMxS
  1YKICB6UXpMVTVEU0VNaUxBb2dJQ0FnSUNBaVVIVmliR2xqVUdGeVlXMWxkR1Z
  5Y3lJNklIc0tJQ0FnSUNBZ0lDQQogIGlVSFZpYkdsalMyVjVSVU5FU0NJNklIc
  0tJQ0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlXRFEwT0NJc0NpQWdJCiAgQ0FnSUN
  BZ0lDQWlVSFZpYkdsaklqb2dJa0ZwY1Y5SVMyYzBPRm8xZEU5U05FNDNka2xEZ
  UVOVk1FeDZlamQKICB0UkZGYWVVRjBhMngwYVdaRE5UaDFVbko0UW1Ga2NTMEt
  JQ0F5WWkxWVpHTlBXVGREVlhWSmJqZ3hXRWhGUQogIHpOSmVVRWlmWDE5TEFvZ
  0lDQWdJa3RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlV
  SCiAgR0lqb2dJazFCTnpVdE4xTXlVaTFQUlVWVkxVMUtWVmN0VTBNMFVpMHlUV
  FJSTFVGS1ZFVWlMQW9nSUNBZ0kKICBDQWlVSFZpYkdsalVHRnlZVzFsZEdWeWN
  5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSQogIDZJSHNLS
  UNBZ0lDQWdJQ0FnSUNKamNuWWlPaUFpV0RRME9DSXNDaUFnSUNBZ0lDQWdJQ0F
  pVUhWaWJHbGpJCiAgam9nSWs1NVpGaEpUVlZMUVhSMllrMVBOa3N0ZDNWRlh6Q
  lFjVTlKVEZCWFNUaEVZM3BxWm5ScldXRlVRazgKICB4YWpWaWRISnFabWNLSUN
  CSE56RTFTa3MyUmtNNFJpMUxiVzFPVWpaRFRrSkxRMEVpZlgxOUxBb2dJQ0FnS
  QogIGtWdWRtVnNiM0JsWkZCeWIyWnBiR1ZUWlhKMmFXTmxJam9nVzNzS0lDQWd
  JQ0FnSUNBaVpHbG5Jam9nSWxOCiAgSVFUSWlmU3dLSUNBZ0lDQWdJbVYzYjJkS
  lEwcFJZMjA1YldGWGVHeFZNbFo1Wkcxc2FscFRTVFpKU0hOTFMKICBVTkJaMGx
  EU2t4YVdHeFFXbTFhYzJGWE5XeFZNbXdLSUNCdVltMUdNR1JZU214SmFtOW5aW
  GR2WjBsRFFXZAogIEpRMEZwVmxWU1IwbHFiMmRKYXpGQ1YwWnZkRk5XUWtoT2V
  URlhVMFZHVUV4V1pGSldWbEYwVVFvZ0lEQktWCiAgVlJETVVsVVJrMTVURlpPV
  EZReFkybE1RVzluU1VOQlowbERRV2xWU0ZacFlrZHNhbFZIUm5sWlZ6RnNaRWQ
  KICBXZVdONVNUWkpTSE5MU1VOQkNpQWdaMGxEUVdkSlEwRnBWVWhXYVdKSGJHc
  FRNbFkxVWxWT1JWTkRTVFpKUwogIEhOTFNVTkJaMGxEUVdkSlEwRm5TVU5LYW1
  OdVdXbFBhVUZwVWxkUk1FNEtJQ0JFWjJsTVFXOW5TVU5CWjBsCiAgRFFXZEpRM
  EZuU1d4Q01WbHRlSEJaZVVrMlNVTkthVmt5Y0dGaFZWRjZVVzFrVVdOVWFFOVR
  SVVUwVmtaR2UKICBtSkZjQW9nSUZKaWVrSjZUMFV4TkZJeGJ6QldWMUpRVlZZN
  GVtTkhXa0pYUjJodFZXdGtUR1JFYUROaFZtaAogIHNRMmxCWjFwVWJEWk5lbG8
  wVmpCS2VGWkhWa3RTQ2lBZ2EyaG9aREE1ZFZSWFRsQmpiV3hDU1c0eE9XWlRkC
  iAgMHRKUTBGblNVTktURnBZYkVaaWJVNTVaVmhDTUdGWE9YVkphbTluWlhkdlo
  wbERRV2RKUTBFS0lDQnBWbFYKICBTUjBscWIyZEphekZGVFRCbmRFMHdPVXhTY
  VRGTVZFUk5NRXhWTURKUk1GbDBVMnRXU0ZaVE1VSk5hMVpPVAogIEZWT1ZWZFd
  WV2xNUVc5blNRb2dJRU5CWjBsRFFXbFZTRlpwWWtkc2FsVkhSbmxaVnpGc1pFZ
  FdlV041U1RaCiAgSlNITkxTVU5CWjBsRFFXZEpRMEZwVlVoV2FXSkhiR3BUTWx
  ZMVVsVk9DaUFnUlZORFNUWkpTSE5MU1VOQloKICAwbERRV2RKUTBGblNVTkthb
  U51V1dsUGFVRnBWMFJSTUU5RFNYTkRhVUZuU1VOQlowbERRV2RKUTBGcFZVaAo
  gIFdhV0lLSUNCSGJHcEphbTluU1c1Q1NtTnFiRkZsVkZaeVYyMDFNbEZWT1hCa
  FZGb3dVa1ZrVW1WcVl6RmFSCiAgbFpEVGxST2NGRnJTWGhOTUZwTFVWaGFlbE5
  FU2dvZ0lFNWtTR3hLVlRKU1VWZEdXak5VVjAxTFNVTkNjbFUKICB6Ums5VVIyd
  zFWSHBDY0ZWVVNtRmhia1UxVVd0U1dGWnRjRzFQUlVWcFpsZ3hPV1pZTUNJc0N
  pQWdJQ0FnSQogIEhzS0lDQWdJQ0FnSUNBaWMybG5ibUYwZFhKbGN5STZJRnQ3Q
  2lBZ0lDQWdJQ0FnSUNBZ0lDSmhiR2NpT2lBCiAgaVUwaEJNaUlzQ2lBZ0lDQWd
  JQ0FnSUNBZ0lDSnJhV1FpT2lBaVRVRllXaTFKVUVjM0xWWklRVTh0VjFGVlYKI
  CBDMURRbFJNTFVoTVV6SXRVMHRQVnlJc0NpQWdJQ0FnSUNBZ0lDQWdJQ0p6YVd
  kdVlYUjFjbVVpT2lBaVVUaAogIDBWVGh4Vlc1UWRuQjRSWEZ3V21SZlZGZHJka
  2xPT0Y4eFdYUlNRMnQ0UjNGVGF6SkZlR0ZrWHpSUWJGZDZjCiAgZ29nSUVGNlI
  xOWpXRGxXVkRWVmJVOWhTalpqYldrdGJFMDRhRVk0UVcwdFQyZFNUbXQ0UjJ0a
  U1YbGZUMWwKICAwWVV0Q1dHNVZaVUpIU0VjemFuUnVjR3hWQ2lBZ2RuZ3pWbXh
  YVW1WS2JqQldjVmxOYVZSbVkwRlJOVkJMVAogIG5WcVNHSm1OR2xEYzI4MlVGT
  kJZMEVpZlYwc0NpQWdJQ0FnSUNBZ0lsQmhlV3h2WVdSRWFXZGxjM1FpT2lBCiA
  gaWRGZElPVEJQTlhWV0xXSTJWblpKYW1sM2FVTnNVbXRLTmtReVF6WTBSMXBNV
  0hGYWF6VndRV2g0ZEZGWEMKICBpQWdkM0ZqUTNwTFRUTm1OM00yYzJ4UGRVbzJ
  abG95TmpkMVJHYzJVVkV5VlVZMU5WOTJhbk5wVTBFaWZWMQogIDlmUSIsCiAgI
  CAgICAgICB7CiAgICAgICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICA
  gICAgICAgICJhbGciOiAiU0hBMiIsCiAgICAgICAgICAgICAgICAia2lkIjogI
  k1CTVgtTlZOQS1USFVLLVc2UFUtVEFRWC1aU1pGLVFNS1IiLAogICAgICAgICA
  gICAgICAgInNpZ25hdHVyZSI6ICJmcEFuMjU5cTdLbG04ckFEa2xUQ1pNbS1RU
  k42MEw3SHQtZHFRUnM3anA0czNwRzgyCiAgTm51Mlg2dlpHcFhXUGlHLW5fOUc
  3eDhrOHdBeVY1bHgwaWtSX2xnN0k0VGd6cDRxSElPUy1JNVNEVjA0dUcKICBiV
  Up3OEF3N3Q2R2REVWxlVlhCbHBmZGxyQUJoSlIxMHpEcG9xeml3QSJ9XSwKICA
  gICAgICAgICAgIlBheWxvYWREaWdlc3QiOiAiSExUWENlWnkwWnlCLTEtRVBYS
  3A3MGY3Rmh6YUNGNzhLeC1QMlZ0QmRNRkVoCiAgM3JfU1JtV1YxUTBnSkd3aS0
  3aURmVW9xbm9xVS1xZkxxNmpfZ1c0eWcifV0sCiAgICAgICAgIlByb3RvY29sc
  yI6IFt7CiAgICAgICAgICAgICJQcm90b2NvbCI6ICJtbW0ifV19XX19",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MBMX-NVNA-THUK-W6PU-TAQX-ZSZF-QMKR",
                "signature": "9tsNFm1jNVzzB6C3OI36W6EEXqDl7vA7DkG6aTf2eHd1K2WWi
  -u8d10FJwnoYL6_18OBSmTpoSaA7sSsYO5SJ6iN5JDZ2WTHDpkz2UxKHc8-1p3
  BEaloP7Cti2MNDpQ5mtcKKGzv1LguA-ignpNusg0A"}],
            "PayloadDigest": "Qj8nBxCQb17clLUcChnerfrr5C68FlMQkqaDxSqMtJNmq
  6H1sNbYn6U67fcsSA3Vr0WQUgf2vnnPYrkjHQb8sA"}]},
      {
        "MessageID": "CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z",
        "EnvelopedRequestConnection": [{
            "EnvelopeID": "MDXK-RZJW-EWNX-2UPD-267T-6KAA-HAC3-VHDN-UUDG-KPAT-C3WH-TBKI-7H6E-OF5V",
            "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJOQ1NZLVhJM04tQUpSSi0
  yT1dLLUc3U0ktQjc1Ny1BUkJRIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWVzd
  ENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL21lc3NhZ2U
  iLAogICJDcmVhdGVkIjogIjIwMjAtMDctMjdUMDk6NDU6MjNaIn0"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJ
  NZXNzYWdlSUQiOiAiTkNTWS1YSTNOLUFKUkotMk9XSy1HN1NJLUI3NTctQVJCU
  SIsCiAgICAiQXV0aGVudGljYXRlZERhdGEiOiBbewogICAgICAgICJkaWciOiA
  iU0hBMiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b
  2dJQ0FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUN
  BZ0lDSlZSRVlpT2lBaVRVUTNWeTFUTmxoR0xWWTBSVXd0TjFGRlR5MU5WCiAgV
  kJMTFVJMVNrd3RUVXhRV1NJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjB
  aWEp6SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ
  2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0F
  nSUNBZ0lDQWlVSFZpYkdsaklqb2dJamxwV1ZKRVduVjRPVkpLYW5Oa2R6UlZSb
  EYzTlZOCiAga1gzUjNVMFF4WVZsME9FeHlWaTFMY2pCVWJrdDZVREJaVURneGJ
  6VUtJQ0I0ZW10dGVUVmthSHBWUm5wNE4KICBGOTVkazk2VEU5ck5rRWlmWDE5T
  EFvZ0lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZ
  SRVlpT2lBaVRVRXpWeTAzTkZkR0xUWldWVFF0V2tGU1JpMURUbEl6TFVrelVGY
  3RVRnBCTmlJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWp
  vZ2V3b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ
  0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlF
  kV0pzYQogIFdNaU9pQWliRkIxVjJSaVp6VjFjbFZaVEZwUE56VllhMGc0YVZaU
  FQydHVUa016ZEROQ1FVNWFOWHBCUlVoCiAgdFdVMWFSMGxYYVVwbVZRb2dJR05
  xYWtWSmVYTlRTME16Vm5kbVZYUnpObkpFWlZCSFFTSjlmWDBzQ2lBZ0kKICBDQ
  WlTMlY1UVhWMGFHVnVkR2xqWVhScGIyNGlPaUI3Q2lBZ0lDQWdJQ0pWUkVZaU9
  pQWlUVUZMV2kxSVYxVgogIFpMVFZhU1VRdFRsbERVeTAwVVZvekxWVk5NMEl0V
  2s5T1NTSXNDaUFnSUNBZ0lDSlFkV0pzYVdOUVlYSmhiCiAgV1YwWlhKeklqb2d
  ld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGxGUTBSSUlqb2dld29nSUNBZ0lDQ
  WdJQ0EKICBnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0FnSUNBZ0lDQWdJQ0pRZFd
  Kc2FXTWlPaUFpUlRCWk9IQkRiV2xRZAogIFRaNVlsUllabE01YkhRNVNsZFdjM
  HgzZDFCS01sTmxZVXBJWW5SNExVVk5WRTlZWDJwM2IwbDVTUW9nSUhGCiAgVWR
  WVmlUa0ZmZG05NmFHWnBUWFY2TUhselMyRTBRU0o5ZlgxOWZRIiwKICAgICAge
  wogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6ICJ
  TSEEyIiwKICAgICAgICAgICAgImtpZCI6ICJNRDdXLVM2WEYtVjRFTC03UUVPL
  U1VUEstQjVKTC1NTFBZIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJPZE9
  DUGNwLWFFWVlCYWllQTRzUl93YjljWHFkUUNjR0dLLWVTSFFmdVpCbEl5WC1jC
  iAgYWRVVzRkdXBpTkxvY253eDZmNzh1SFZ2VG1BUjVDQThqYmZwRHZydmQ3Ym9
  6dURNcUZ1UkV5QVN5anZZb0QKICA0MkMwZy1XVGdyVnAzWHhNNzNzbjVGQ18xM
  nI3MFBTUWlPX3ZoVkFFQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICI
  1S0JjMTdCeTJWeDRpeWhLLWNSZ0ZvcVJTN3VIa3NjZS1fRTNSd1hyRUMySkwKI
  CA4QzktMldTT2wwSUFzVDdpYl93cWVldFM4YVBweFNHRFFWa0c2TWFRUSJ9XSw
  KICAgICJDbGllbnROb25jZSI6ICJaeGdHZTJUakd2Unl3YTR6ZVB6UTNRIiwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"],
        "ServerNonce": "GLSniO7I_1aD_2ztWJxWSg",
        "Witness": "CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z"},
      {
        "MessageID": "XP3F-7HEO-OYBH-SKCJ-EO7P-Q54P-6HED",
        "EnvelopedRequestConnection": [{
            "EnvelopeID": "MAUU-AAOE-BVX3-KN7Q-6N4J-U6FD-KRU4-544Y-3AP7-QUJA-BJBR-6Y2H-5V5K-6QJO",
            "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJOQ1lSLTU2QUstNkVFUC1
  NUkZULUlRRFQtTVdFQy0zRUJDIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWVzd
  ENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL21lc3NhZ2U
  iLAogICJDcmVhdGVkIjogIjIwMjAtMDctMjdUMDk6NDU6MjJaIn0"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJ
  NZXNzYWdlSUQiOiAiTkNZUi01NkFLLTZFRVAtTVJGVC1JUURULU1XRUMtM0VCQ
  yIsCiAgICAiQXV0aGVudGljYXRlZERhdGEiOiBbewogICAgICAgICJkaWciOiA
  iU0hBMiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b
  2dJQ0FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUN
  BZ0lDSlZSRVlpT2lBaVRVTTJWQzFHV0RjM0xVRkNRelV0UWxaS05TMVZNCiAgM
  E0wTFUxWlEwZ3RVRkZXVWlJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjB
  aWEp6SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ
  2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0F
  nSUNBZ0lDQWlVSFZpYkdsaklqb2dJblJoTTFaNlpsVm5XSEpTZDJsMlozaGpPR
  TFaVjNGCiAgNk9HVm5NVkZaTlZSRlZGWjRSVzFCVUVRd1JHbzBWRlZQTUV4cGE
  wMEtJQ0J1VlZWNldWaHdRMHROV1ZFd1IKICBVTldTMWxKYjBScGVVRWlmWDE5T
  EFvZ0lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZ
  SRVlpT2lBaVRVTmFWeTFQTjFaTExWTktXRkV0TjA0eU5TMUlWak5hTFVSRldVY
  3RVbEpXVWlJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWp
  vZ2V3b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ
  0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlF
  kV0pzYQogIFdNaU9pQWlRM0JXVTBad1pWUkNSa3RyYjJacU9IRnpialkwYUU1U
  VZ5MVdXV3B0UnpKd2QyVTVkalZWY2taCiAgYU5HWjZNV2wxVHpaSmJBb2dJRTF
  2V1ZnMVFUQk9TMDFyU21WVFRsTlJWRTR6TW1aWlFTSjlmWDBzQ2lBZ0kKICBDQ
  WlTMlY1UVhWMGFHVnVkR2xqWVhScGIyNGlPaUI3Q2lBZ0lDQWdJQ0pWUkVZaU9
  pQWlUVVJVUVMxSFFWVgogIFpMVWczVHpZdFdqVkpSQzB5VkVkRExWSlNSRTB0V
  EVWV05DSXNDaUFnSUNBZ0lDSlFkV0pzYVdOUVlYSmhiCiAgV1YwWlhKeklqb2d
  ld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGxGUTBSSUlqb2dld29nSUNBZ0lDQ
  WdJQ0EKICBnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0FnSUNBZ0lDQWdJQ0pRZFd
  Kc2FXTWlPaUFpYTJGS2FubGtUVmRUTgogIFVGbk56VlVOMk5pTVZOSFJXRlZlV
  GRVU0dKdVNFRnplR3hYVkhRMU5Xd3RPSEU0U1hCYVlYVTBXZ29nSUhFCiAgM1V
  ESk9OVFYzUmtWdk1UUmFiMmRtWW5oYWRuSnhRU0o5ZlgxOWZRIiwKICAgICAge
  wogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6ICJ
  TSEEyIiwKICAgICAgICAgICAgImtpZCI6ICJNQzZULUZYNzctQUJDNS1CVko1L
  VUzQzQtTVlDSC1QUVZSIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICI0SlF
  1cDFzSmxhYVFrY3AwZ2tNTlhyZTQxUVBzNGJibEdZNlFwS3dkbEV3VFdRckFvC
  iAgak5CUlFTVm5LdDJUOWthdWhEbkV1blFlaFNBeTQtWFFaOE1ReE1HNU1aUkt
  aOHh5M1BfZ0dQRHVmR3lDZ04KICBmR0ZFS1RHVGNhaXJFTXdoWHV1OVhaTFRZa
  UlNRXFvTmFCQ2pKMGhrQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJ
  XMVoyN1YwU1RWTHlVRnRnSlNCbDFTRVlqdlZSUkg4emhKTUNBTE9OclZzc0kKI
  CA4MVg1RjFYNW1wS2NqOUs1MklfemVVNzExWW01Ykgtb1kzanREdlpIQSJ9XSw
  KICAgICJDbGllbnROb25jZSI6ICI0RWxuZmhFc3NiTGFaRldKdFBjOVB3IiwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"],
        "ServerNonce": "unVM1oXYHXO6Te1VfBJzBQ",
        "Witness": "XP3F-7HEO-OYBH-SKCJ-EO7P-Q54P-6HED"}]}}
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
       Specifies the request to accept
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
<rsp>ERROR - The specified message could not be found.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> message accept tbs /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The specified message could not be found."}}
</div>
~~~~


# message reject

~~~~
<div="helptext">
<over>
reject   Reject a pending request
       Specifies the request to reject
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
<rsp>ERROR - The specified message could not be found.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> message reject tbs /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The specified message could not be found."}}
</div>
~~~~


# message block

~~~~
<div="helptext">
<over>
block   Reject a pending request and block requests from that source
       Specifies the request to reject and block
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


