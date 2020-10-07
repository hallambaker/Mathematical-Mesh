

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
    /local   Local name for account (e.g. personal)
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
      "MessageId": "NDGY-F44Y-W54S-NOFD-GBJR-XK7H-VM7J",
      "Sender": "bob@example.com",
      "Recipient": "alice@example.com",
      "Subject": "alice@example.com",
      "PIN": "EDS6-WV5Z-OJ2K-OKAV-2DFC-WK4M-TIF4",
      "Self": [{
          "dig": "S512",
          "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjAtMDktMjJUMTM6MTI6NTlaIn0"},
        "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVREYiOiAiTUEzQy1FS1ZBLVk0VDUtVFROQy1XR
  DNHLTRDWUgtWjRGNiIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJib2JAZXhhbXBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWN
  jb3VudCI6IFt7CiAgICAgICAgICAgICJFbnZlbG9wZUlEIjogIk1BM0MtRUtWQ
  S1ZNFQ1LVRUTkMtV0QzRy00Q1lILVo0RjYiLAogICAgICAgICAgICAiZGlnIjo
  gIlM1MTIiLAogICAgICAgICAgICAiQ29udGVudE1ldGFEYXRhIjogImV3b2dJQ
  0pWYm1seGRXVkpSQ0k2SUNKTlFUTkRMVVZMVmtFdFdUUlVOUzEKICBVVkU1REx
  WZEVNMGN0TkVOWlNDMWFORVkySWl3S0lDQWlUV1Z6YzJGblpWUjVjR1VpT2lBa
  VVISnZabWxzWgogIFZWelpYSWlMQW9nSUNKamRIa2lPaUFpWVhCd2JHbGpZWFJ
  wYjI0dmJXMXRMMjlpYW1WamRDSXNDaUFnSWtOCiAgeVpXRjBaV1FpT2lBaU1qQ
  XlNQzB3T1MweU1sUXhNem94TWpvMU9Gb2lmUSJ9LAogICAgICAgICAgImV3b2d
  JQ0pRY205bWFXeGxWWE5sY2lJNklIc0tJQ0FnSUNKUFptWnNhVzUKICBsVTJsb
  mJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZVUkdJam9nSWsxQk0wTXRSVXRXUVM
  xWk5GUTFMVlJVVAogIGtNdFYwUXpSeTAwUTFsSUxWbzBSallpTEFvZ0lDQWdJQ
  0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzCiAgS0lDQWdJQ0FnSUNBaVV
  IVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbllpT2lBa
  VIKICBXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSm5jR2x
  OTW1velV6ZHVObE5UY2tVeVFuTgogIEZjMFo0Y0dWWlVHZFZWMDFDTkhBeVJ6a
  HBObGRqVkdwS2VuRkpkV1ZpTmtSdENpQWdRWFZxWDFsQ1JXczRXCiAgVk54VVh
  sQlZGQjRSalpyZUd0QkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFFXUmtjbVZ6Y
  zJWeklqb2dXeUoKICBpYjJKQVpYaGhiWEJzWlM1amIyMGlYU3dLSUNBZ0lDSkJ
  ZMk52ZFc1MFJXNWpjbmx3ZEdsdmJpSTZJSHNLSQogIENBZ0lDQWdJbFZFUmlJN
  klDSk5RMU5STFV4WFNWTXRXVUZJU2kxSlNGaE5MVkphVGtVdFJreE5VUzFMU0R
  aCiAgQ0lpd0tJQ0FnSUNBZ0lsQjFZbXhwWTFCaGNtRnRaWFJsY25NaU9pQjdDa
  UFnSUNBZ0lDQWdJbEIxWW14cFkKICAwdGxlVVZEUkVnaU9pQjdDaUFnSUNBZ0l
  DQWdJQ0FpWTNKMklqb2dJbGcwTkRnaUxBb2dJQ0FnSUNBZ0lDQQogIGdJbEIxW
  W14cFl5STZJQ0pTTVhRek56QjJhRlkxWm05RFIySnJTV0pWTjI1dGRDMUJkRmx
  pUjIxdmN6UkZXCiAga2xJU0RRNVprcHhNalV6VVRGR1JXUnJDaUFnYjI1UmFVZ
  GZaRUZKZEdsSVpqaE1VRU5IVGpFNFFubEJJbjEKICA5ZlN3S0lDQWdJQ0pGYm5
  abGJHOXdaV1JRY205bWFXeGxVMlZ5ZG1salpTSTZJRnQ3Q2lBZ0lDQWdJQ0FnS
  QogIGtWdWRtVnNiM0JsU1VRaU9pQWlUVVJIV2kxRlUwZE5MVTFEVTBVdE0wSll
  XUzFDTkUxRkxVSlBUMWd0UmtaCiAgWlFTSXNDaUFnSUNBZ0lDQWdJbVJwWnlJN
  klDSlROVEV5SWl3S0lDQWdJQ0FnSUNBaVEyOXVkR1Z1ZEUxbGQKICBHRkVZWFJ
  oSWpvZ0ltVjNiMmRKUTBwV1ltMXNlR1JYVmtwU1EwazJTVU5LVGxKRlpHRk1WV
  lpVVWpBd2RGUgogIFZUbFJTVXpBS0lDQjZVV3hvV2t4VlNUQlVWVlYwVVdzNVV
  GZERNVWRTYkd4Q1NXbDNTMGxEUVdsVVYxWjZZCiAgekpHYmxwV1VqVmpSMVZwV
  DJsQmFWVklTblphYld4eldnb2dJRlpPYkdOdVduQlpNbFZwVEVGdlowbERTbXA
  KICBrU0d0cFQybEJhVmxZUW5kaVIyeHFXVmhTY0dJeU5IWmlWekYwVERJNWFXR
  nRWbXBrUTBselEybEJDaUFnWgogIDBsclRubGFWMFl3V2xkUmFVOXBRV2xOYWt
  GNVRVTXdkMDlUTUhsTmJGRjRUWHB2ZUUxcWJ6Rk9NVzlwWmxFCiAgaWZTd0tJQ
  0FnSUNBZ0ltVjNiMmRKUTBwUlkyMDViV0ZYZUd4Vk1sWjVaRzFzYWxwVFNUWkp
  TSE5MU1VOQloKICAwbERTbEJhYlZvS0lDQnpZVmMxYkZVeWJHNWliVVl3WkZoS
  2JFbHFiMmRsZDI5blNVTkJaMGxEUVdsV1ZWSgogIEhTV3B2WjBsck1VVlNNVzk
  wVWxaT1NGUlRNVTVSTVU1R1RBb2dJRlJPUTFkR2EzUlJhbEpPVWxNeFExUXdPC
  iAgVmxNVlZwSFYxVkZhVXhCYjJkSlEwRm5TVU5CYVZWSVZtbGlSMnhxVlVkR2V
  WbFhNV3hrUjFaNVkzbEpDaUEKICBnTmtsSWMwdEpRMEZuU1VOQlowbERRV2xWU
  0ZacFlrZHNhbE15VmpWU1ZVNUZVME5KTmtsSWMwdEpRMEZuUwogIFVOQlowbER
  RV2RKUTBwcVkyNVphVThLSUNCcFFXbFNWMUV3VGtSbmFVeEJiMmRKUTBGblNVT
  kJaMGxEUVdkCiAgSmJFSXhXVzE0Y0ZsNVNUWkpRMHBPVVRCcmVGZElUbTFhTUU
  1Tldta3dkR1ZGY0FvZ0lIVmlSR3hSV201d1QKICBsWnRiRkJPZW14U1dXMUdVM
  DFYTVV0WmJsSkxUbXc0ZUZFd1l6QmhSbFpIVWtZNVQxRlZTVEJEYVVGblkxZAo
  gIE9kbFJXYkVaVkNpQWdWa1Y1V1RCd1EwNHpZelZVYTBvd1dXMHhkRTB3WkVKS
  mJqRTVabE4zUzBsRFFXZEpRCiAgMHBNV2xoc1JtSnRUbmxsV0VJd1lWYzVkVWx
  xYjJkbGQyOEtJQ0JuU1VOQlowbERRV2xXVlZKSFNXcHZaMGwKICByTVVOVFJrb
  DBUVEJ6TVZKVE1WWk5NRVpaVEZWc1ZWVkZkM1JXUlU1T1ZVTXhWMVpXUWtOTVZ
  sSkVWd29nSQogIEVacmFVeEJiMmRKUTBGblNVTkJhVlZJVm1saVIyeHFWVWRHZ
  VZsWE1XeGtSMVo1WTNsSk5rbEljMHRKUTBGCiAgblNVTkJaMGxEUVdsVlNGWnB
  Za2RzQ2lBZ2FsTXlWalZTVlU1RlUwTkpOa2xJYzB0SlEwRm5TVU5CWjBsRFEKI
  CBXZEpRMHBxWTI1WmFVOXBRV2xYUkZFd1QwTkpjME5wUVdkSlEwRm5TVU5CWjB
  rS0lDQkRRV2xWU0ZacFlrZAogIHNha2xxYjJkSmFsWldWMnRrZW1OdFdqRlVTR
  3hVVVZWV1UxZ3hWa1ZpTUVwVlZETk9NV0ZWVVRSV2JVcFZWCiAgRlYwVFdKck9
  Rb2dJRTFhYldzd1ZWaFdUV05xYXpCWGJHZ3haRWQ0VjJWWVZVdEpRMEpaV0ROU
  mVHUnFUVEYKICBXYW1zeFZFUkthVll5VGtwYWFrNTBUMWMxVDFsVlJXbG1DaUF
  nV0RFNVpsZ3dJaXdLSUNBZ0lDQWdld29nSQogIENBZ0lDQWdJQ0p6YVdkdVlYU
  jFjbVZ6SWpvZ1czc0tJQ0FnSUNBZ0lDQWdJQ0FnSW1Gc1p5STZJQ0pUTlRFCiA
  geUlpd0tJQ0FnSUNBZ0lDQWdJQ0FnSW10cFpDSTZJQ0pOUkVkYUxVVlRSMDB0V
  FVOVFJTMHpRbGhaTFVJMFQKICBVVXRRazlQV0MxR1JsbEJJaXdLSUNBZ0lDQWd
  JQ0FnSUNBZ0luTnBaMjVoZEhWeVpTSTZJQ0l3YzBKT2MxTgogIHdkbFF6T1dWV
  00xOVhSV3hqYzE5M1ZGSldVWGxxT0UxVVFrVXlRalZUYkhGRFNHdENUWEUzTkU
  wM0NpQWdTCiAgR280T1U5VVFsOVBUekZZWDJGR2MyeENlbVZEZVVkeVFUUkJZa
  lpFYVhCYWRVb3hTRGxuWnpCTlpFeHdkMnAKICBRUzJGSWExRTVYMFZ0Y0dwQ2J
  qY0tJQ0JmVkdsMWFVeGlWWEJNV1VSMlpWUnBWVWRSWkhORmEwZDNWbGxzYwogI
  GpWMllqUmZVamhIUVZOTlFTSjlYU3dLSUNBZ0lDQWdJQ0FpVUdGNWJHOWhaRVJ
  wWjJWemRDSTZJQ0pmU0RSCiAgeGVUVnNkREZxT0RVeFUwVm1hMWROWlc5MVNFW
  XRUMnBwVFRBNFJUbDVTR3hPWW5RM2NqaDRiVllLSUNBMVkKICBWVjZVRlJ0V1V
  WMWQwdHNablJFT1V4WlJqUmZVbXhtT1ZKSGFteGxXRFJxYVdzeFlUWTRkeUo5W
  FN3S0lDQQogIGdJQ0pMWlhsQmRYUm9aVzUwYVdOaGRHbHZiaUk2SUhzS0lDQWd
  JQ0FnSWxWRVJpSTZJQ0pOUXpkWUxWbzNTCiAga0l0UVZRelV5MDJOMGcyTFZve
  VdGWXRSRXhIU0MxSVYxQkJJaXdLSUNBZ0lDQWdJbEIxWW14cFkxQmhjbUYKICB
  0WlhSbGNuTWlPaUI3Q2lBZ0lDQWdJQ0FnSWxCMVlteHBZMHRsZVVWRFJFZ2lPa
  UI3Q2lBZ0lDQWdJQ0FnSQogIENBaVkzSjJJam9nSWxnME5EZ2lMQW9nSUNBZ0l
  DQWdJQ0FnSWxCMVlteHBZeUk2SUNKaGEyZFJjRzUzVDJjCiAgMWVVUlZPSGxmW
  jFWMFNFUjFhR1J3VXpORlpYUlRaV1Z5WVhCbVdHaFphRGhLVlhCM1YwZDZhVWR
  5Q2lBZ1IKICBVTlVUemhRWjJOM1FYRm5TVmxZYjJWMVJGSTRRVFJCSW4xOWZYM
  TkiLAogICAgICAgICAgewogICAgICAgICAgICAic2lnbmF0dXJlcyI6IFt7CiA
  gICAgICAgICAgICAgICAiYWxnIjogIlM1MTIiLAogICAgICAgICAgICAgICAgI
  mtpZCI6ICJNQTNDLUVLVkEtWTRUNS1UVE5DLVdEM0ctNENZSC1aNEY2IiwKICA
  gICAgICAgICAgICAgICJzaWduYXR1cmUiOiAiTEpVY0lmUkc2QlZFTGNyeUVQe
  TN6MFdvUVI4YlZtVkxVNGJnSnU3dExiRkt5cnBmVwogIFdSc1FnYjdFMG5ianR
  KNUduN2VmV3ozQURXQTJjTmdGQTdwVTRPMjVOaUxqU3ZmRjRfZmZlWE04M1RMO
  EhtCiAgUWJsdkNzZDlLT1hucmxlSXYtSUhHVnNFb0RfNXZxcklzRmN0dDl6RUE
  ifV0sCiAgICAgICAgICAgICJQYXlsb2FkRGlnZXN0IjogImhMMTJiYWZiVW5uO
  EtTVWV1UkJUSXo2SkRhSGlrQjBuOU1SMzN5RjhRSThkUgogIE9sbWZCTW81OUV
  0d2tmS0xXV2N1MzV4dUM5c3ZIaHB1Q2ZFRS1DbGNBIn1dLAogICAgICAgICJQc
  m90b2NvbHMiOiBbewogICAgICAgICAgICAiUHJvdG9jb2wiOiAibW1tIn1dfV1
  9fQ",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MBU4-VQKS-BBPU-JW7E-N4PP-SVRF-NCRN",
              "signature": "ivAoXSPf6vEEbD7gLoHlnUNY42uqN4fte-8Xfxy_IcfWwRC_a
  zTEd6t_5ZYFPzLbB3fH1gS_yY4ADRPIxpAbnkZtKKe6Ostp6_fyA9OHrCAiJNR
  -G1kFzvr6LQ8h6IxROYkZrSDWv5bwU8abl_0NeSEA"}],
          "PayloadDigest": "6yIgl9qmUfFUsZSbtkyMiKrYajbhHVo2mEh_6Bj8fSKOX
  np4QBip0dd3hsR337JhD0Ahrp9lIxUMXZI7ehkteQ"}]}}}
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
    /local   Local name for account (e.g. personal)
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
      "MessageId": "NA63-DGFG-Q3KX-5JU4-DDDB-6CAL-2UAR",
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
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>ERROR - An item with the same key has already been added. Key: DVHM-4XCL-BA55-ZW2F-GYO2-JWYN-OGH5
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> message pending /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "An item with the same key has already been added. Key: DVHM-4XCL-BA55-ZW2F-GYO2-JWYN-OGH5"}}
</div>
~~~~



# message status

~~~~
<div="helptext">
<over>
status   Request status of pending requests
    /requestid   Specifies the request to provide the status of
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
    /local   Local name for account (e.g. personal)
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
    /local   Local name for account (e.g. personal)
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
    /local   Local name for account (e.g. personal)
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


