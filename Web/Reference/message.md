

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
      "MessageID": "NDU7-QGJX-ICCX-UGCO-4CW2-5DLV-64YH",
      "Sender": "bob@example.com",
      "Recipient": "alice@example.com",
      "Subject": "alice@example.com",
      "PIN": "ECAW-VTSJ-FYOI-TAQ6-U2JH-4JM3-UDEF",
      "Self": [{
          "dig": "SHA2"},
        "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2hvcnMiOiBbewo
  gICAgICAgICJVREYiOiAiTUE3US1JSVlBLTJFNVYtRE5YMi1aUEJVLUlCVkstN
  01XVCIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSwKICAgICJOZXR
  3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6ICJib2JAZXhhb
  XBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWNjb3VudCI6IFt
  7CiAgICAgICAgICAgICJkaWciOiAiU0hBMiJ9LAogICAgICAgICAgImV3b2dJQ
  0pRY205bWFXeGxRV05qYjNWdWRDSTZJSHNLSUNBZ0lDSkxaWGxQWm1ac2FXNWx
  VMmwKICBuYm1GMGRYSmxJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFCTjFFd
  FNVbFpRUzB5UlRWV0xVUk9XREl0VwogIGxCQ1ZTMUpRbFpMTFRkTlYxUWlMQW9
  nSUNBZ0lDQWlVSFZpYkdsalVHRnlZVzFsZEdWeWN5STZJSHNLSUNBCiAgZ0lDQ
  WdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0FnSUNKamN
  uWWlPaUFpUldRME4KICBEZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2S
  UNKVWJqWTNjMHRRWTI1RlRFd3RTazVLUjA5eFRqQgogIDFObEJmZURkdFRGazV
  jbmg0VGpoUWQyTnhjbWcxUXpKZk5Fb3daRGRXQ2lBZ09FZGlSM0Y1TVhJeGRIb
  HlNCiAgWE5uVlRGUmIycFRRelpCSW4xOWZTd0tJQ0FnSUNKTFpYbHpUMjVzYVc
  1bFUybG5ibUYwZFhKbElqb2dXM3MKICBLSUNBZ0lDQWdJQ0FpVlVSR0lqb2dJa
  zFDTmtRdFZqSkhOeTFMVFRaTkxVZExVbEl0UkZCWlF5MVdNak5ITAogIFZaT1U
  xVWlMQW9nSUNBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam9nZXdvZ
  0lDQWdJQ0FnSUNBCiAgZ0lsQjFZbXhwWTB0bGVVVkRSRWdpT2lCN0NpQWdJQ0F
  nSUNBZ0lDQWdJQ0pqY25ZaU9pQWlSV1EwTkRnaUwKICBBb2dJQ0FnSUNBZ0lDQ
  WdJQ0FpVUhWaWJHbGpJam9nSW5oaFEzcEVhRWRxVlROaFdWRndUVlJ3UjBKQk5
  reAogIFBkWEpNU2tVNFExZFNabGhWTm5aSVVYUmhNMWxxZDBKWU0yeEdRVUlLS
  UNCUE1uSkhWWGR5VkVJeU1GUkdWCiAgbGxXUWt3d1ZHUlFZMEVpZlgxOVhTd0t
  JQ0FnSUNKQlkyTnZkVzUwUVdSa2NtVnpjMlZ6SWpvZ1d5SmliMkoKICBBWlhoa
  GJYQnNaUzVqYjIwaVhTd0tJQ0FnSUNKTlpYTm9VSEp2Wm1sc1pWVkVSaUk2SUN
  KTlExSTFMVVpLUgogIDBzdFUwSkpUUzFSU0VGTUxWSTFUa2d0VFZBeVN5MU9Ra
  05ZSWl3S0lDQWdJQ0pMWlhsRmJtTnllWEIwYVc5CiAgdUlqb2dld29nSUNBZ0l
  DQWlWVVJHSWpvZ0lrMUVSazR0V0VwUFJ5MVlWMVJSTFZCVFNrUXRVbFpaUXkwM
  FMKICAwbFRMVTlWVVVvaUxBb2dJQ0FnSUNBaVVIVmliR2xqVUdGeVlXMWxkR1Z
  5Y3lJNklIc0tJQ0FnSUNBZ0lDQQogIGlVSFZpYkdsalMyVjVSVU5FU0NJNklIc
  0tJQ0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlXRFEwT0NJc0NpQWdJCiAgQ0FnSUN
  BZ0lDQWlVSFZpYkdsaklqb2dJbXRYVHkxVVZITnBRV0l6UTFCbmNEUjZUV2QyW
  W01ZlNFVTNTM2wKICBqUjJSRVVtVm5iVW8xU1hSaFNXWjVRakZ6U1cxd0xYa0t
  JQ0JSYUU1SlVEZHRNRWhJTVcxVVRrNXdNbnAwVQogIFRkYVowRWlmWDE5TEFvZ
  0lDQWdJa3RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlV
  SCiAgR0lqb2dJazFFVVVRdE0xWlFWUzAzVDBVMkxVaEhUVXN0UTFaVFVDMUVNM
  FZOTFVJMVFrSWlMQW9nSUNBZ0kKICBDQWlVSFZpYkdsalVHRnlZVzFsZEdWeWN
  5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSQogIDZJSHNLS
  UNBZ0lDQWdJQ0FnSUNKamNuWWlPaUFpV0RRME9DSXNDaUFnSUNBZ0lDQWdJQ0F
  pVUhWaWJHbGpJCiAgam9nSW1sMGIzaHBWMVp5VlUxcFMzcGtXVGRsY1VoR1ZtV
  kVXVFZ0TVZaSFRqZ3RjMTk1UTJZMlluQm1WakYKICBLWVRocUxWaHVhVTBLSUN
  CNE5UZHFibmwyVUZKb1FXZERRMmRNY21oRFV6WXRVVUVpZlgxOUxBb2dJQ0FnS
  QogIGtWdWRtVnNiM0JsWkZCeWIyWnBiR1ZUWlhKMmFXTmxJam9nVzNzS0lDQWd
  JQ0FnSUNBaVpHbG5Jam9nSWxOCiAgSVFUSWlmU3dLSUNBZ0lDQWdJbVYzYjJkS
  lEwcFJZMjA1YldGWGVHeFZNbFo1Wkcxc2FscFRTVFpKU0hOTFMKICBVTkJaMGx
  EU2t4YVdHeFFXbTFhYzJGWE5XeFZNbXdLSUNCdVltMUdNR1JZU214SmFtOW5aW
  GR2WjBsRFFXZAogIEpRMEZwVmxWU1IwbHFiMmRKYXpGRlRUQlZkRlpHY0VoVVF
  6RlZUV3QwV0V4V2FGRldWbEYwVkFvZ0lHdDRSCiAgbEpETVV0VlJrcElURlZHU
  0ZSR1ZXbE1RVzluU1VOQlowbERRV2xWU0ZacFlrZHNhbFZIUm5sWlZ6RnNaRWQ
  KICBXZVdONVNUWkpTSE5MU1VOQkNpQWdaMGxEUVdkSlEwRnBWVWhXYVdKSGJHc
  FRNbFkxVWxWT1JWTkRTVFpKUwogIEhOTFNVTkJaMGxEUVdkSlEwRm5TVU5LYW1
  OdVdXbFBhVUZwVWxkUk1FNEtJQ0JFWjJsTVFXOW5TVU5CWjBsCiAgRFFXZEpRM
  EZuU1d4Q01WbHRlSEJaZVVrMlNVTkpOR1ZHUmxGa1Z6VndWV3MxTmxWRk5YUlZ
  hMmgwVlRKV04KICBWZHVTZ29nSUdsUFZrNXFZMWhPVkZFelFUQmpSVlo1VjJ3N
  VNXVnRZekpYVm1SeFlrUnNUbFZWVmt4aWF6RgogIFBRMmxCWjJOVVRubFVWVEE
  wVFZWYU5XSnNPVTlUQ2lBZ2EwWnFXVEpTYzJKVmVFbFVSV1JDU1c0eE9XWlRkC
  iAgMHRKUTBGblNVTktURnBZYkVaaWJVNTVaVmhDTUdGWE9YVkphbTluWlhkdlo
  wbERRV2RKUTBFS0lDQnBWbFYKICBTUjBscWIyZEphekZEVVZVNGRGWnJkRWRVV
  XpBelZGVjRWMHhXYUVOVWExVjBWa1pLVVZkVE1WSlJWV1JVVAogIEZaa1UwNXF
  UV2xNUVc5blNRb2dJRU5CWjBsRFFXbFZTRlpwWWtkc2FsVkhSbmxaVnpGc1pFZ
  FdlV041U1RaCiAgSlNITkxTVU5CWjBsRFFXZEpRMEZwVlVoV2FXSkhiR3BUTWx
  ZMVVsVk9DaUFnUlZORFNUWkpTSE5MU1VOQloKICAwbERRV2RKUTBGblNVTkthb
  U51V1dsUGFVRnBWMFJSTUU5RFNYTkRhVUZuU1VOQlowbERRV2RKUTBGcFZVaAo
  gIFdhV0lLSUNCSGJHcEphbTluU1d4V1YxWkdSblpVUmxKUVdXNVdWRkZVYkZaV
  FJFWkxVMVZHZVZOWFJrMVNiCiAgV1J5WlZSb1ptSlljRWhaVmtKUFZFZEdORmR
  HYkFvZ0lGTldWMVY0WTFjNVdWVldPVkJsYlVWTFNVTkNiRnAKICA2U2tOT2F6V
  jRVekpzUzFkclJuTlZlbFp5V0hreFVWZEZSbnBQUlVWcFpsZ3hPV1pZTUNJc0N
  pQWdJQ0FnSQogIEhzS0lDQWdJQ0FnSUNBaWMybG5ibUYwZFhKbGN5STZJRnQ3Q
  2lBZ0lDQWdJQ0FnSUNBZ0lDSmhiR2NpT2lBCiAgaVUwaEJNaUlzQ2lBZ0lDQWd
  JQ0FnSUNBZ0lDSnJhV1FpT2lBaVRVUXpSUzFVV2tkTUxWUXlTMWN0V0ZCVlYKI
  CBDMU9URVZFTFVwUVVrY3RRVWRNVlNJc0NpQWdJQ0FnSUNBZ0lDQWdJQ0p6YVd
  kdVlYUjFjbVVpT2lBaU0zcAogIHFNMWh1YlhWSloxVnNiMDFIYjJjeE9WOWlNV
  EoxUXpGM2RtZ3RMV2RRZG5aRFRYaFFXR295YVZsMlIxVnNkCiAgQW9nSUVSUVo
  wTnhWVFZGU2psYWJtZE5PVlI1YTFReVQxTnpXVGhuUVRKdE9EUkVYMDk1WDB0a
  mNuaGpaMHQKICBMTXpkS1VrRklTbXhKUVdwS2VVVkRjRFZXQ2lBZ1oxVkNRVFp
  PV1ZSaE5XbElibEpoVkhGNGNtaGpORWRUUQogIGxoSlVWUlpUbTVNVTBwZlEwb
  DNhMEVpZlYwc0NpQWdJQ0FnSUNBZ0lsQmhlV3h2WVdSRWFXZGxjM1FpT2lBCiA
  gaVRXRTVZalpGUnpkbldYTmhiRE5rVlc5dVVUUkNaMGcwVlV4WmJHSlZSazkwZ
  VV4ME1qVkthWGhpT1dKWUMKICBpQWdRbVJvY0hCVGNqQkJaRVpxT1VKbE9FRnJ
  iMkpmV25SQmJsSnRhSHBwZW10TE1XVm5kRlZJVjBFaWZWMQogIDlmUSIsCiAgI
  CAgICAgICB7CiAgICAgICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICA
  gICAgICAgICJhbGciOiAiU0hBMiIsCiAgICAgICAgICAgICAgICAia2lkIjogI
  k1DWE0tQ1NUUi1VVlc2LUJTQ1otN1pJVy1YNUE0LUdESTMiLAogICAgICAgICA
  gICAgICAgInNpZ25hdHVyZSI6ICJWSDVHUEtHN1laTVllQ0tUMzVRZ2FlbHQxb
  W5ZdG9WLUpCNzFmc0IxYTNxenhyMXIyCiAgUEo3RWljeHMtdFBVbzZZcVFVcVF
  HQlYzZ09BeEFVTEpPQWhWMmsxem84d21ObjFfOTZBMU8zT2JFNnRqYVQKICBoZ
  zc5c1FWSGZ3Q3BwblZYTm5BMkFiRXprV0hCMUpsUFd5STg0c1RFQSJ9XSwKICA
  gICAgICAgICAgIlBheWxvYWREaWdlc3QiOiAianp0dVVLUDNGRDlreWU1Wmtta
  nJWc1hFcmJrNmR4TUlETkVRWXNzNG91amRVCiAgUWVKMnBXOWFTbU15MmlvOE9
  1U3d5QURTZlNPaGlxOExEdmNELVBOOGcifV0sCiAgICAgICAgIlByb3RvY29sc
  yI6IFt7CiAgICAgICAgICAgICJQcm90b2NvbCI6ICJtbW0ifV19XX19",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MCXM-CSTR-UVW6-BSCZ-7ZIW-X5A4-GDI3",
              "signature": "sJwVkKBhKR9rlyk-omS3h8G3twNpMrcRt6luOm9jRzfmwPWWj
  klhYr7xVF4Y1gVIeo2I1mg-RsAAICUh44DUb_sMnitVjw55IT6RtVVaWKtRmah
  T-5gWabtWh1eLYCKwVocd_IqVxr36EZAEjYvnayMA"}],
          "PayloadDigest": "0S8gjLNTroZfIjNaPjnTwT9cK6T0rdLxJsL4EERUvxJcM
  C70v1TcTDPY-GhIf0kjsE-vpyqdvZ0jv1U4pO6_Ow"}]}}}
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
      "MessageID": "NBA6-OH3N-VXAK-MLLK-BU2B-SLJ7-MHOM",
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
<rsp>MessageID: NDU7-QGJX-ICCX-UGCO-4CW2-5DLV-64YH
        Contact Request::
        MessageID: NDU7-QGJX-ICCX-UGCO-4CW2-5DLV-64YH
        To: alice@example.com From: bob@example.com
        PIN: ECAW-VTSJ-FYOI-TAQ6-U2JH-4JM3-UDEF
MessageID: 4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV
        Connection Request::
        MessageID: 4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV
        To:  From: 
        Device:  MDTJ-IEIN-4ST6-ZC3G-OUSP-PBNM-PHYK
        Witness: 4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV
MessageID: 2CHS-6OLF-5NF2-XECX-EZON-A2XD-GDMM
        Connection Request::
        MessageID: 2CHS-6OLF-5NF2-XECX-EZON-A2XD-GDMM
        To:  From: 
        Device:  MBKR-2YPO-UOPU-2QTE-2YXK-J55K-QBWQ
        Witness: 2CHS-6OLF-5NF2-XECX-EZON-A2XD-GDMM
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
        "MessageID": "NDU7-QGJX-ICCX-UGCO-4CW2-5DLV-64YH",
        "Sender": "bob@example.com",
        "Recipient": "alice@example.com",
        "Subject": "alice@example.com",
        "PIN": "ECAW-VTSJ-FYOI-TAQ6-U2JH-4JM3-UDEF",
        "Self": [{
            "dig": "SHA2"},
          "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2hvcnMiOiBbewo
  gICAgICAgICJVREYiOiAiTUE3US1JSVlBLTJFNVYtRE5YMi1aUEJVLUlCVkstN
  01XVCIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSwKICAgICJOZXR
  3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6ICJib2JAZXhhb
  XBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWNjb3VudCI6IFt
  7CiAgICAgICAgICAgICJkaWciOiAiU0hBMiJ9LAogICAgICAgICAgImV3b2dJQ
  0pRY205bWFXeGxRV05qYjNWdWRDSTZJSHNLSUNBZ0lDSkxaWGxQWm1ac2FXNWx
  VMmwKICBuYm1GMGRYSmxJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFCTjFFd
  FNVbFpRUzB5UlRWV0xVUk9XREl0VwogIGxCQ1ZTMUpRbFpMTFRkTlYxUWlMQW9
  nSUNBZ0lDQWlVSFZpYkdsalVHRnlZVzFsZEdWeWN5STZJSHNLSUNBCiAgZ0lDQ
  WdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0FnSUNKamN
  uWWlPaUFpUldRME4KICBEZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2S
  UNKVWJqWTNjMHRRWTI1RlRFd3RTazVLUjA5eFRqQgogIDFObEJmZURkdFRGazV
  jbmg0VGpoUWQyTnhjbWcxUXpKZk5Fb3daRGRXQ2lBZ09FZGlSM0Y1TVhJeGRIb
  HlNCiAgWE5uVlRGUmIycFRRelpCSW4xOWZTd0tJQ0FnSUNKTFpYbHpUMjVzYVc
  1bFUybG5ibUYwZFhKbElqb2dXM3MKICBLSUNBZ0lDQWdJQ0FpVlVSR0lqb2dJa
  zFDTmtRdFZqSkhOeTFMVFRaTkxVZExVbEl0UkZCWlF5MVdNak5ITAogIFZaT1U
  xVWlMQW9nSUNBZ0lDQWdJQ0pRZFdKc2FXTlFZWEpoYldWMFpYSnpJam9nZXdvZ
  0lDQWdJQ0FnSUNBCiAgZ0lsQjFZbXhwWTB0bGVVVkRSRWdpT2lCN0NpQWdJQ0F
  nSUNBZ0lDQWdJQ0pqY25ZaU9pQWlSV1EwTkRnaUwKICBBb2dJQ0FnSUNBZ0lDQ
  WdJQ0FpVUhWaWJHbGpJam9nSW5oaFEzcEVhRWRxVlROaFdWRndUVlJ3UjBKQk5
  reAogIFBkWEpNU2tVNFExZFNabGhWTm5aSVVYUmhNMWxxZDBKWU0yeEdRVUlLS
  UNCUE1uSkhWWGR5VkVJeU1GUkdWCiAgbGxXUWt3d1ZHUlFZMEVpZlgxOVhTd0t
  JQ0FnSUNKQlkyTnZkVzUwUVdSa2NtVnpjMlZ6SWpvZ1d5SmliMkoKICBBWlhoa
  GJYQnNaUzVqYjIwaVhTd0tJQ0FnSUNKTlpYTm9VSEp2Wm1sc1pWVkVSaUk2SUN
  KTlExSTFMVVpLUgogIDBzdFUwSkpUUzFSU0VGTUxWSTFUa2d0VFZBeVN5MU9Ra
  05ZSWl3S0lDQWdJQ0pMWlhsRmJtTnllWEIwYVc5CiAgdUlqb2dld29nSUNBZ0l
  DQWlWVVJHSWpvZ0lrMUVSazR0V0VwUFJ5MVlWMVJSTFZCVFNrUXRVbFpaUXkwM
  FMKICAwbFRMVTlWVVVvaUxBb2dJQ0FnSUNBaVVIVmliR2xqVUdGeVlXMWxkR1Z
  5Y3lJNklIc0tJQ0FnSUNBZ0lDQQogIGlVSFZpYkdsalMyVjVSVU5FU0NJNklIc
  0tJQ0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlXRFEwT0NJc0NpQWdJCiAgQ0FnSUN
  BZ0lDQWlVSFZpYkdsaklqb2dJbXRYVHkxVVZITnBRV0l6UTFCbmNEUjZUV2QyW
  W01ZlNFVTNTM2wKICBqUjJSRVVtVm5iVW8xU1hSaFNXWjVRakZ6U1cxd0xYa0t
  JQ0JSYUU1SlVEZHRNRWhJTVcxVVRrNXdNbnAwVQogIFRkYVowRWlmWDE5TEFvZ
  0lDQWdJa3RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlV
  SCiAgR0lqb2dJazFFVVVRdE0xWlFWUzAzVDBVMkxVaEhUVXN0UTFaVFVDMUVNM
  FZOTFVJMVFrSWlMQW9nSUNBZ0kKICBDQWlVSFZpYkdsalVHRnlZVzFsZEdWeWN
  5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSQogIDZJSHNLS
  UNBZ0lDQWdJQ0FnSUNKamNuWWlPaUFpV0RRME9DSXNDaUFnSUNBZ0lDQWdJQ0F
  pVUhWaWJHbGpJCiAgam9nSW1sMGIzaHBWMVp5VlUxcFMzcGtXVGRsY1VoR1ZtV
  kVXVFZ0TVZaSFRqZ3RjMTk1UTJZMlluQm1WakYKICBLWVRocUxWaHVhVTBLSUN
  CNE5UZHFibmwyVUZKb1FXZERRMmRNY21oRFV6WXRVVUVpZlgxOUxBb2dJQ0FnS
  QogIGtWdWRtVnNiM0JsWkZCeWIyWnBiR1ZUWlhKMmFXTmxJam9nVzNzS0lDQWd
  JQ0FnSUNBaVpHbG5Jam9nSWxOCiAgSVFUSWlmU3dLSUNBZ0lDQWdJbVYzYjJkS
  lEwcFJZMjA1YldGWGVHeFZNbFo1Wkcxc2FscFRTVFpKU0hOTFMKICBVTkJaMGx
  EU2t4YVdHeFFXbTFhYzJGWE5XeFZNbXdLSUNCdVltMUdNR1JZU214SmFtOW5aW
  GR2WjBsRFFXZAogIEpRMEZwVmxWU1IwbHFiMmRKYXpGRlRUQlZkRlpHY0VoVVF
  6RlZUV3QwV0V4V2FGRldWbEYwVkFvZ0lHdDRSCiAgbEpETVV0VlJrcElURlZHU
  0ZSR1ZXbE1RVzluU1VOQlowbERRV2xWU0ZacFlrZHNhbFZIUm5sWlZ6RnNaRWQ
  KICBXZVdONVNUWkpTSE5MU1VOQkNpQWdaMGxEUVdkSlEwRnBWVWhXYVdKSGJHc
  FRNbFkxVWxWT1JWTkRTVFpKUwogIEhOTFNVTkJaMGxEUVdkSlEwRm5TVU5LYW1
  OdVdXbFBhVUZwVWxkUk1FNEtJQ0JFWjJsTVFXOW5TVU5CWjBsCiAgRFFXZEpRM
  EZuU1d4Q01WbHRlSEJaZVVrMlNVTkpOR1ZHUmxGa1Z6VndWV3MxTmxWRk5YUlZ
  hMmgwVlRKV04KICBWZHVTZ29nSUdsUFZrNXFZMWhPVkZFelFUQmpSVlo1VjJ3N
  VNXVnRZekpYVm1SeFlrUnNUbFZWVmt4aWF6RgogIFBRMmxCWjJOVVRubFVWVEE
  wVFZWYU5XSnNPVTlUQ2lBZ2EwWnFXVEpTYzJKVmVFbFVSV1JDU1c0eE9XWlRkC
  iAgMHRKUTBGblNVTktURnBZYkVaaWJVNTVaVmhDTUdGWE9YVkphbTluWlhkdlo
  wbERRV2RKUTBFS0lDQnBWbFYKICBTUjBscWIyZEphekZEVVZVNGRGWnJkRWRVV
  XpBelZGVjRWMHhXYUVOVWExVjBWa1pLVVZkVE1WSlJWV1JVVAogIEZaa1UwNXF
  UV2xNUVc5blNRb2dJRU5CWjBsRFFXbFZTRlpwWWtkc2FsVkhSbmxaVnpGc1pFZ
  FdlV041U1RaCiAgSlNITkxTVU5CWjBsRFFXZEpRMEZwVlVoV2FXSkhiR3BUTWx
  ZMVVsVk9DaUFnUlZORFNUWkpTSE5MU1VOQloKICAwbERRV2RKUTBGblNVTkthb
  U51V1dsUGFVRnBWMFJSTUU5RFNYTkRhVUZuU1VOQlowbERRV2RKUTBGcFZVaAo
  gIFdhV0lLSUNCSGJHcEphbTluU1d4V1YxWkdSblpVUmxKUVdXNVdWRkZVYkZaV
  FJFWkxVMVZHZVZOWFJrMVNiCiAgV1J5WlZSb1ptSlljRWhaVmtKUFZFZEdORmR
  HYkFvZ0lGTldWMVY0WTFjNVdWVldPVkJsYlVWTFNVTkNiRnAKICA2U2tOT2F6V
  jRVekpzUzFkclJuTlZlbFp5V0hreFVWZEZSbnBQUlVWcFpsZ3hPV1pZTUNJc0N
  pQWdJQ0FnSQogIEhzS0lDQWdJQ0FnSUNBaWMybG5ibUYwZFhKbGN5STZJRnQ3Q
  2lBZ0lDQWdJQ0FnSUNBZ0lDSmhiR2NpT2lBCiAgaVUwaEJNaUlzQ2lBZ0lDQWd
  JQ0FnSUNBZ0lDSnJhV1FpT2lBaVRVUXpSUzFVV2tkTUxWUXlTMWN0V0ZCVlYKI
  CBDMU9URVZFTFVwUVVrY3RRVWRNVlNJc0NpQWdJQ0FnSUNBZ0lDQWdJQ0p6YVd
  kdVlYUjFjbVVpT2lBaU0zcAogIHFNMWh1YlhWSloxVnNiMDFIYjJjeE9WOWlNV
  EoxUXpGM2RtZ3RMV2RRZG5aRFRYaFFXR295YVZsMlIxVnNkCiAgQW9nSUVSUVo
  wTnhWVFZGU2psYWJtZE5PVlI1YTFReVQxTnpXVGhuUVRKdE9EUkVYMDk1WDB0a
  mNuaGpaMHQKICBMTXpkS1VrRklTbXhKUVdwS2VVVkRjRFZXQ2lBZ1oxVkNRVFp
  PV1ZSaE5XbElibEpoVkhGNGNtaGpORWRUUQogIGxoSlVWUlpUbTVNVTBwZlEwb
  DNhMEVpZlYwc0NpQWdJQ0FnSUNBZ0lsQmhlV3h2WVdSRWFXZGxjM1FpT2lBCiA
  gaVRXRTVZalpGUnpkbldYTmhiRE5rVlc5dVVUUkNaMGcwVlV4WmJHSlZSazkwZ
  VV4ME1qVkthWGhpT1dKWUMKICBpQWdRbVJvY0hCVGNqQkJaRVpxT1VKbE9FRnJ
  iMkpmV25SQmJsSnRhSHBwZW10TE1XVm5kRlZJVjBFaWZWMQogIDlmUSIsCiAgI
  CAgICAgICB7CiAgICAgICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICA
  gICAgICAgICJhbGciOiAiU0hBMiIsCiAgICAgICAgICAgICAgICAia2lkIjogI
  k1DWE0tQ1NUUi1VVlc2LUJTQ1otN1pJVy1YNUE0LUdESTMiLAogICAgICAgICA
  gICAgICAgInNpZ25hdHVyZSI6ICJWSDVHUEtHN1laTVllQ0tUMzVRZ2FlbHQxb
  W5ZdG9WLUpCNzFmc0IxYTNxenhyMXIyCiAgUEo3RWljeHMtdFBVbzZZcVFVcVF
  HQlYzZ09BeEFVTEpPQWhWMmsxem84d21ObjFfOTZBMU8zT2JFNnRqYVQKICBoZ
  zc5c1FWSGZ3Q3BwblZYTm5BMkFiRXprV0hCMUpsUFd5STg0c1RFQSJ9XSwKICA
  gICAgICAgICAgIlBheWxvYWREaWdlc3QiOiAianp0dVVLUDNGRDlreWU1Wmtta
  nJWc1hFcmJrNmR4TUlETkVRWXNzNG91amRVCiAgUWVKMnBXOWFTbU15MmlvOE9
  1U3d5QURTZlNPaGlxOExEdmNELVBOOGcifV0sCiAgICAgICAgIlByb3RvY29sc
  yI6IFt7CiAgICAgICAgICAgICJQcm90b2NvbCI6ICJtbW0ifV19XX19",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MCXM-CSTR-UVW6-BSCZ-7ZIW-X5A4-GDI3",
                "signature": "sJwVkKBhKR9rlyk-omS3h8G3twNpMrcRt6luOm9jRzfmwPWWj
  klhYr7xVF4Y1gVIeo2I1mg-RsAAICUh44DUb_sMnitVjw55IT6RtVVaWKtRmah
  T-5gWabtWh1eLYCKwVocd_IqVxr36EZAEjYvnayMA"}],
            "PayloadDigest": "0S8gjLNTroZfIjNaPjnTwT9cK6T0rdLxJsL4EERUvxJcM
  C70v1TcTDPY-GhIf0kjsE-vpyqdvZ0jv1U4pO6_Ow"}]},
      {
        "MessageID": "4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV",
        "EnvelopedRequestConnection": [{
            "EnvelopeID": "MCES-PQVF-AIDB-7ITY-UZDL-27MK-KXVI-CRZ7-65GI-PT2Q-6YTP-QRPA-ACJG-GTJ6",
            "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJOQ1ZOLUtVVkwtQkdZUy1
  LWk0yLTVHNlotTEw0Si1WSFNGIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWVzd
  ENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL21lc3NhZ2U
  iLAogICJDcmVhdGVkIjogIjIwMjAtMDctMjhUMTU6NDk6MDNaIn0"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJ
  NZXNzYWdlSUQiOiAiTkNWTi1LVVZMLUJHWVMtS1pNMi01RzZaLUxMNEotVkhTR
  iIsCiAgICAiQXV0aGVudGljYXRlZERhdGEiOiBbewogICAgICAgICJkaWciOiA
  iU0hBMiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b
  2dJQ0FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUN
  BZ0lDSlZSRVlpT2lBaVRVUlVTaTFKUlVsT0xUUlRWRFl0V2tNelJ5MVBWCiAgV
  k5RTFZCQ1RrMHRVRWhaU3lJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjB
  aWEp6SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ
  2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0F
  nSUNBZ0lDQWlVSFZpYkdsaklqb2dJa05wYURjMVFsUlBVR0ZoVEhKdWIzWm9Vb
  U42TVZRCiAgNVpXeDRObXRHVm1GSlpHVlFhVFJRU2xKVGVYSXpNR05DYm5kTlE
  zUUtJQ0I0TVVGbFNHRTFkamhYV1dwU04KICB5MWFTak55WldkeVowRWlmWDE5T
  EFvZ0lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZ
  SRVlpT2lBaVRVRlFSQzFHV1RaS0xWVktUVEl0U0ZoTldpMVpUVVF5TFZaSVRsR
  XRXa2szVENJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWp
  vZ2V3b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ
  0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlF
  kV0pzYQogIFdNaU9pQWlVRWxpTFVaVWNsRnpRbHBsU1ROS1JrWm1NVGMwVFU5d
  FVVcFZZVXBOVUdkUmQzQkZNVVZ2YlZnCiAgM1pIcHRSVFI0V0V4T2Jnb2dJRk5
  uZVZsWVVVRjNlR3RvV201b2QyWnViR1p3U0ZCNVFTSjlmWDBzQ2lBZ0kKICBDQ
  WlTMlY1UVhWMGFHVnVkR2xqWVhScGIyNGlPaUI3Q2lBZ0lDQWdJQ0pWUkVZaU9
  pQWlUVVJFU1MxWVNsWgogIFJMVkZSTlZndE5WUXlOaTFaVVVwS0xVUkxOMEV0U
  mtsSE5pSXNDaUFnSUNBZ0lDSlFkV0pzYVdOUVlYSmhiCiAgV1YwWlhKeklqb2d
  ld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGxGUTBSSUlqb2dld29nSUNBZ0lDQ
  WdJQ0EKICBnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0FnSUNBZ0lDQWdJQ0pRZFd
  Kc2FXTWlPaUFpVGpWU1dEWlpWbUpOUgogIFU0d2FsQmxSVFp4U1ZWbU0wNXJaa
  kpUYTJGV2RXY3dWMGxWTkVOSE5rRjNUVmRVUlZsd1MzZzRlZ29nSUZvCiAgd1p
  WWnNhWEEyWW1WbFdEZHRPVjlZTjBzNGJWOWxRU0o5ZlgxOWZRIiwKICAgICAge
  wogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6ICJ
  TSEEyIiwKICAgICAgICAgICAgImtpZCI6ICJNRFRKLUlFSU4tNFNUNi1aQzNHL
  U9VU1AtUEJOTS1QSFlLIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICI5S2h
  jMjBiX1hSTlBIQTF4RkgwM3B2SmZhOEtlSU8xcVdZNlRTZGxvN0VlWWNzcF9JC
  iAgYzBsanlsUWczMS1VQlNuV2ZseVFYNFllb0tBcS1PQmJtNXpPNzc4ZlBod2d
  fak93ZlVmSjBsM05TX2I4ZU8KICA5TFp3cWFfWGxOeHRHNjY5Q0hNYmdIRjJqR
  WlXb0Ywb2NkN1ZnaXpVQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJ
  rem1fQUVZWldoaEUzYWtvQzE5YnE4SDR2RU0zRFhidTZ0TnR2aG9HY283THYKI
  CBSaDI4dHpzaVE5RUJmNDJqM2p0dzliejBGZDNnOVA2cUhaNjgxM3Q3USJ9XSw
  KICAgICJDbGllbnROb25jZSI6ICJxeU9rbllocjhzYWVEaEFkSUI3NHBnIiwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"],
        "ServerNonce": "fFY57xjwJM0s6YETC0UN8A",
        "Witness": "4WQE-EGTC-VKQR-4X4I-3GNM-HOBD-J2RV"},
      {
        "MessageID": "2CHS-6OLF-5NF2-XECX-EZON-A2XD-GDMM",
        "EnvelopedRequestConnection": [{
            "EnvelopeID": "MBXY-X7KQ-VZ5A-YYPI-YTZF-DHZS-L6VO-CVDW-6J3J-FIIJ-WSS5-PFFZ-O2CF-67ZT",
            "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJOQVdCLVRNUVQtSkQzUC1
  WQkxILVE1WUUtMzNMRy1MTFE3IiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWVzd
  ENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL21lc3NhZ2U
  iLAogICJDcmVhdGVkIjogIjIwMjAtMDctMjhUMTU6NDk6MDJaIn0"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJ
  NZXNzYWdlSUQiOiAiTkFXQi1UTVFULUpEM1AtVkJMSC1RNVlFLTMzTEctTExRN
  yIsCiAgICAiQXV0aGVudGljYXRlZERhdGEiOiBbewogICAgICAgICJkaWciOiA
  iU0hBMiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b
  2dJQ0FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUN
  BZ0lDSlZSRVlpT2lBaVRVSkxVaTB5V1ZCUExWVlBVRlV0TWxGVVJTMHlXCiAgV
  mhMTFVvMU5Vc3RVVUpYVVNJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjB
  aWEp6SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ
  2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0F
  nSUNBZ0lDQWlVSFZpYkdsaklqb2dJbXRMUVVkbVQxbHBhbHBwVERWclJHRk9TR
  TVKYnpBCiAgNFEwNWpSVzk2V1RsQlVXUjNjMVZpUTBwVFZETlFValJMYUZSMk4
  zTUtJQ0JKU3pKM2FIZE1aRWhVZVhCbmQKICBYQm1NelZZYlRsaVYwRWlmWDE5T
  EFvZ0lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZ
  SRVlpT2lBaVRVTkJUaTFUVjFsRExWQlpSVW90VXpkV055MDFVa1ZXTFRSWlUxV
  XRTa0ZJVUNJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWp
  vZ2V3b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ
  0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlF
  kV0pzYQogIFdNaU9pQWlOamc0YVVobGJHNURka0oxTkZaNFYxRjZNRkF3UlhoS
  VJFZHpTVEZLUldKQ01qZFJSVFpMVm1sCiAgak9WcFNhRm95T0V4U1ZRb2dJRlZ
  OV2xwbU1EaHZVRWhpVkdJd2RUWk5UWFZGU1dJMFFTSjlmWDBzQ2lBZ0kKICBDQ
  WlTMlY1UVhWMGFHVnVkR2xqWVhScGIyNGlPaUI3Q2lBZ0lDQWdJQ0pWUkVZaU9
  pQWlUVUZCTmkxQlNEZAogIE9MVnBOVmxrdFVraFdOUzFWV1VaWExWaFRVVU10U
  VVwV1R5SXNDaUFnSUNBZ0lDSlFkV0pzYVdOUVlYSmhiCiAgV1YwWlhKeklqb2d
  ld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGxGUTBSSUlqb2dld29nSUNBZ0lDQ
  WdJQ0EKICBnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0FnSUNBZ0lDQWdJQ0pRZFd
  Kc2FXTWlPaUFpVmxwV05rMDRWMlpqTgogIEdaMlpqQklNRE5aVDBWeFVsWnhYM
  GR1TTJGUmRITXhOMjlVYlU1cU5sTjVPRWcxWTI1T2QyVk1SQW9nSUd0CiAgelJ
  XdFpUeTFoWDNsb2VXbEhabWxoVEVRMlNTMTVRU0o5ZlgxOWZRIiwKICAgICAge
  wogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6ICJ
  TSEEyIiwKICAgICAgICAgICAgImtpZCI6ICJNQktSLTJZUE8tVU9QVS0yUVRFL
  TJZWEstSjU1Sy1RQldRIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICI1Wmd
  EWkhVckVEeUY3bG5xbUtEdFhNSURKN3BiVDZoNjI0WWtMWEQ4OUZCaEJxeFZDC
  iAgVWxvdXhMakQxRzl3c092T01Gckd3Y2EyU1lBTnI0VnhQUTFmZTJyQUtUYkJ
  4eTJ3b0wxZW5tVXJ0dktSenAKICBxR0hjeUtrWUk4QjdzR0prOWx4cXV4RGRUY
  zRLTHRKOHU2QWhReFRvQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJ
  3N0ZCWXVXazlOQnJaSHBPSnJ3czMxNjFQNWFKbjRpOEVfWDg1aFN3ZkxXSkIKI
  CBGY09XUndPLVo1SVoyd3BaYUIxLTZ3cFJJR3RBc2Z3SHEyNkFDUTBrdyJ9XSw
  KICAgICJDbGllbnROb25jZSI6ICJxNTFDRzlNWG14Q3VPXy1jajBZTndnIiwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"],
        "ServerNonce": "PvrpK7WMtOtQ2Oo4WxyAuQ",
        "Witness": "2CHS-6OLF-5NF2-XECX-EZON-A2XD-GDMM"}]}}
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


