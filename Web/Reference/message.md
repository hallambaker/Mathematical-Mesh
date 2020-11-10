

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
      "MessageId": "NDT4-66BJ-HIH5-UMHG-4QVG-YXDJ-RKJD",
      "Sender": "bob@example.com",
      "Recipient": "alice@example.com",
      "AuthenticatedData": [{
          "dig": "S512",
          "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjAtMTEtMDlUMTY6MDg6MTZaIn0"},
        "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTUROQy1USTRPLVZDRjctWkFJSi1ZQ
  lpILVNTRTYtV1NZSyIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJib2JAZXhhbXBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWN
  jb3VudCI6IFt7CiAgICAgICAgICAgICJFbnZlbG9wZUlEIjogIk1ETkMtVEk0T
  y1WQ0Y3LVpBSUotWUJaSC1TU0U2LVdTWUsiLAogICAgICAgICAgICAiZGlnIjo
  gIlM1MTIiLAogICAgICAgICAgICAiQ29udGVudE1ldGFEYXRhIjogImV3b2dJQ
  0pWYm1seGRXVkpSQ0k2SUNKTlJFNURMVlJKTkU4dFZrTkdOeTEKICBhUVVsS0x
  WbENXa2d0VTFORk5pMVhVMWxMSWl3S0lDQWlUV1Z6YzJGblpWUjVjR1VpT2lBa
  VVISnZabWxzWgogIFZWelpYSWlMQW9nSUNKamRIa2lPaUFpWVhCd2JHbGpZWFJ
  wYjI0dmJXMXRMMjlpYW1WamRDSXNDaUFnSWtOCiAgeVpXRjBaV1FpT2lBaU1qQ
  XlNQzB4TVMwd09WUXhOam93T0RveE5sb2lmUSJ9LAogICAgICAgICAgImV3b2d
  JQ0pRY205bWFXeGxWWE5sY2lJNklIc0tJQ0FnSUNKUWNtOW1hV3gKICBsVTJsb
  mJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxRVRrTXRWRWswVHk
  xV1EwWTNMVnBCUwogIFVvdFdVSmFTQzFUVTBVMkxWZFRXVXNpTEFvZ0lDQWdJQ
  0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzCiAgS0lDQWdJQ0FnSUNBaVV
  IVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbllpT2lBa
  VIKICBXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSlVZWEl
  3TkhGc2FVRmtWakZ3UkZsWmNVbAogIDZSMU00ZUZNd01FVkJhM2hOVlZNNGRHb
  G5iamxETFRkUFRWOHdUa2RWTlZwakNpQWdjVzB3UkZKdVYxSTJYCiAgekZQU0c
  5UVpEY3diV05UTUUxQkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFFXUmtjbVZ6Y
  3lJNklDSmliMkoKICBBWlhoaGJYQnNaUzVqYjIwaUxBb2dJQ0FnSWxObGNuWnB
  ZMlZWWkdZaU9pQWlUVUpEU1MxVU5GWTNMVUZKUQogIGpRdFIwMUlNeTAwUXpaU
  0xVdEVOVkF0U1VOUE15SXNDaUFnSUNBaVFXTmpiM1Z1ZEVWdVkzSjVjSFJwYjI
  0CiAgaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVTkdRaTFTVVZrMExUZFpSV
  Wt0TkVzelVTMUROMUUzTFZjMFEKICBVTXRUVUZVVENJc0NpQWdJQ0FnSUNKUWR
  XSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSgogIFFkV0pzY
  VdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE
  0SWl3S0lDQWdJCiAgQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlZbnBmVFZKWlRqa
  zVUakpUUm5GYVMyRk1hSG90UjFrd01WcENSekIKICAwTjJGUFoweDRiMTlFTjN
  CNlZGazJXbU5aUzB4emR3b2dJRVZqYkRRME5ITlRaa0pxV1VWSFExUlZUbWREY
  gogIGsxSFFTSjlmWDBzQ2lBZ0lDQWlRV1J0YVc1cGMzUnlZWFJ2Y2xOcFoyNWh
  kSFZ5WlNJNklIc0tJQ0FnSUNBCiAgZ0lsVmtaaUk2SUNKTlJFNURMVlJKTkU4d
  FZrTkdOeTFhUVVsS0xWbENXa2d0VTFORk5pMVhVMWxMSWl3S0kKICBDQWdJQ0F
  nSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZb
  XhwWTB0bGVVVgogIERSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0l
  rVmtORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkCiAgV0pzYVdNaU9pQWlWR0Z5T
  URSeGJHbEJaRll4Y0VSWldYRkpla2RUT0hoVE1EQkZRV3Q0VFZWVE9IUnBaMjQ
  KICA1UXkwM1QwMWZNRTVIVlRWYVl3b2dJSEZ0TUVSU2JsZFNObDh4VDBodlVHU
  TNNRzFqVXpCTlFTSjlmWDBzQwogIGlBZ0lDQWlRV05qYjNWdWRFRjFkR2hsYm5
  ScFkyRjBhVzl1SWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxCiAgQlRVRXRUV
  WcwTWkweVEwMUhMVVpGUjFRdE0xcFNSQzFITTBVMExVUkZTVmtpTEFvZ0lDQWd
  JQ0FpVUhWaWIKICBHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQQogIGdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVdEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmliR2xqSWpvZ0lsbEhaC
  iAgVTF0UlZsNk0wMVJUbkZCYkdWaVUxbG9RV3RUWmpndFMwRmZNMjl4TVZOME1
  sTnlNVzB3ZEZoMGRETldNa2MKICB4U0RRS0lDQm1UVTF5U1c5WFVUWlVhMjF0V
  m5CdWVsTXhTbTkzWjBFaWZYMTlMQW9nSUNBZ0lrRmpZMjkxYgogIG5SVGFXZHV
  ZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVSklWaTFIV0VKQ0xWW
  kxRbEF0VjFoCiAgVVR5MUNWMWxGTFZoTVdWTXRVVTFTVENJc0NpQWdJQ0FnSUN
  KUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2UKICB3b2dJQ0FnSUNBZ0lDSlFkV
  0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSgo
  gIEZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2dJalprTFd4R
  WNrVlVNVXBuVG10bWRucEdhCiAgRWs1VGtRNVQxZ3liemhOYkhRdFdraFZWbkJ
  mZEZVdFkzcHNPV0UwYzBkNk9Ib0tJQ0IxUTNCMU5XTlZURXgKICBEZEhSRmQxR
  kVVWFI1VTB4dFFVRWlmWDE5ZlgwIiwKICAgICAgICAgIHsKICAgICAgICAgICA
  gInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAgICAgImFsZyI6ICJTNTEyI
  iwKICAgICAgICAgICAgICAgICJraWQiOiAiTUROQy1USTRPLVZDRjctWkFJSi1
  ZQlpILVNTRTYtV1NZSyIsCiAgICAgICAgICAgICAgICAic2lnbmF0dXJlIjogI
  m01RjFjUnR1MjE2REF0c3FVbFJreW5aY0Z1REJoMk4weFBldmJ3SWJoT0lHTHV
  qb24KICBYX3hMU2NVUnJDQ1laT29CeTF2dDlpTFd5OEFhYnJKMkNBTm9hbUtna
  21OSWNaMTB0OTVKeFZERmdLTUNSQwogIEstM0dZS0pjVkFrY0hxcE5yYUdPTkl
  Ia0NGc0pxRllHWmoydF9meXdBIn1dLAogICAgICAgICAgICAiUGF5bG9hZERpZ
  2VzdCI6ICI5MlQwRFpDdDVYSlpOcUdKcGQxalBhR3RYd0tXQlNPRDdwUTRCdUx
  CZk54Q0QKICB6Skt6azlvZ1pnbHJIZTRSdGQ5Rk5pcTQ5NV9QbjB3dnU2eWVYY
  0h3ZyJ9XSwKICAgICAgICAiUHJvdG9jb2xzIjogW3sKICAgICAgICAgICAgIlB
  yb3RvY29sIjogIm1tbSJ9XX1dfX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MBHV-GXBB-VKBP-WXTO-BWYE-XLYS-QMRL",
              "signature": "3h2Qo2NQJEmnxfpec1smn2ANj9godG1gjmKRBRI5lX_FSBEZA
  pBQONF7O1X8ediIGv4KT_42TuWAX_dO4a5FO8mkMyU08BOvUbn_SWhIMpuPOxE
  DZjxnOZfWiV8CaSa8tKTU_j7W02fNM_W5Eh3jTD8A"}],
          "PayloadDigest": "zmiwfLZDzh8q1uPzqGC2YBS5u8nuGELst68Lx-ByZO49K
  ZLrUEpH818GTlHxDtKWWOYl9RjlrlNWWVEjahOIgA"}],
      "Reply": true,
      "Subject": "alice@example.com",
      "PIN": "ACBR-HCBB-UYL7-6MVU-QKWB-4N64-UP3A"}}}
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
      "MessageId": "NBUI-FV4Y-G4QA-IAOH-YQRT-BR5R-5UOX",
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
    /unread   <Unspecified>
    /read   <Unspecified>
    /raw   <Unspecified>
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: NDT4-66BJ-HIH5-UMHG-4QVG-YXDJ-RKJD
        Contact Request::
        MessageID: NDT4-66BJ-HIH5-UMHG-4QVG-YXDJ-RKJD
        To: alice@example.com From: bob@example.com
        PIN: ACBR-HCBB-UYL7-6MVU-QKWB-4N64-UP3A
MessageID: NBR3-D554-BQLH-FK5I-7YU3-T5B2-XGDS
        Confirmation Request::
        MessageID: NBR3-D554-BQLH-FK5I-7YU3-T5B2-XGDS
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDGZ-J52O-DPPK-JG7R-2YZQ-JUPS-3GJK
        Contact Request::
        MessageID: NDGZ-J52O-DPPK-JG7R-2YZQ-JUPS-3GJK
        To: alice@example.com From: bob@example.com
        PIN: ACJP-PFU2-2O4N-73XX-J3KN-E7K4-FV3A
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
        "MessageId": "NDT4-66BJ-HIH5-UMHG-4QVG-YXDJ-RKJD",
        "Sender": "bob@example.com",
        "Recipient": "alice@example.com",
        "AuthenticatedData": [{
            "dig": "S512",
            "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjAtMTEtMDlUMTY6MDg6MTZaIn0"},
          "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTUROQy1USTRPLVZDRjctWkFJSi1ZQ
  lpILVNTRTYtV1NZSyIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJib2JAZXhhbXBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWN
  jb3VudCI6IFt7CiAgICAgICAgICAgICJFbnZlbG9wZUlEIjogIk1ETkMtVEk0T
  y1WQ0Y3LVpBSUotWUJaSC1TU0U2LVdTWUsiLAogICAgICAgICAgICAiZGlnIjo
  gIlM1MTIiLAogICAgICAgICAgICAiQ29udGVudE1ldGFEYXRhIjogImV3b2dJQ
  0pWYm1seGRXVkpSQ0k2SUNKTlJFNURMVlJKTkU4dFZrTkdOeTEKICBhUVVsS0x
  WbENXa2d0VTFORk5pMVhVMWxMSWl3S0lDQWlUV1Z6YzJGblpWUjVjR1VpT2lBa
  VVISnZabWxzWgogIFZWelpYSWlMQW9nSUNKamRIa2lPaUFpWVhCd2JHbGpZWFJ
  wYjI0dmJXMXRMMjlpYW1WamRDSXNDaUFnSWtOCiAgeVpXRjBaV1FpT2lBaU1qQ
  XlNQzB4TVMwd09WUXhOam93T0RveE5sb2lmUSJ9LAogICAgICAgICAgImV3b2d
  JQ0pRY205bWFXeGxWWE5sY2lJNklIc0tJQ0FnSUNKUWNtOW1hV3gKICBsVTJsb
  mJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxRVRrTXRWRWswVHk
  xV1EwWTNMVnBCUwogIFVvdFdVSmFTQzFUVTBVMkxWZFRXVXNpTEFvZ0lDQWdJQ
  0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzCiAgS0lDQWdJQ0FnSUNBaVV
  IVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbllpT2lBa
  VIKICBXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSlVZWEl
  3TkhGc2FVRmtWakZ3UkZsWmNVbAogIDZSMU00ZUZNd01FVkJhM2hOVlZNNGRHb
  G5iamxETFRkUFRWOHdUa2RWTlZwakNpQWdjVzB3UkZKdVYxSTJYCiAgekZQU0c
  5UVpEY3diV05UTUUxQkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFFXUmtjbVZ6Y
  3lJNklDSmliMkoKICBBWlhoaGJYQnNaUzVqYjIwaUxBb2dJQ0FnSWxObGNuWnB
  ZMlZWWkdZaU9pQWlUVUpEU1MxVU5GWTNMVUZKUQogIGpRdFIwMUlNeTAwUXpaU
  0xVdEVOVkF0U1VOUE15SXNDaUFnSUNBaVFXTmpiM1Z1ZEVWdVkzSjVjSFJwYjI
  0CiAgaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVTkdRaTFTVVZrMExUZFpSV
  Wt0TkVzelVTMUROMUUzTFZjMFEKICBVTXRUVUZVVENJc0NpQWdJQ0FnSUNKUWR
  XSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSgogIFFkV0pzY
  VdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE
  0SWl3S0lDQWdJCiAgQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlZbnBmVFZKWlRqa
  zVUakpUUm5GYVMyRk1hSG90UjFrd01WcENSekIKICAwTjJGUFoweDRiMTlFTjN
  CNlZGazJXbU5aUzB4emR3b2dJRVZqYkRRME5ITlRaa0pxV1VWSFExUlZUbWREY
  gogIGsxSFFTSjlmWDBzQ2lBZ0lDQWlRV1J0YVc1cGMzUnlZWFJ2Y2xOcFoyNWh
  kSFZ5WlNJNklIc0tJQ0FnSUNBCiAgZ0lsVmtaaUk2SUNKTlJFNURMVlJKTkU4d
  FZrTkdOeTFhUVVsS0xWbENXa2d0VTFORk5pMVhVMWxMSWl3S0kKICBDQWdJQ0F
  nSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZb
  XhwWTB0bGVVVgogIERSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0l
  rVmtORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkCiAgV0pzYVdNaU9pQWlWR0Z5T
  URSeGJHbEJaRll4Y0VSWldYRkpla2RUT0hoVE1EQkZRV3Q0VFZWVE9IUnBaMjQ
  KICA1UXkwM1QwMWZNRTVIVlRWYVl3b2dJSEZ0TUVSU2JsZFNObDh4VDBodlVHU
  TNNRzFqVXpCTlFTSjlmWDBzQwogIGlBZ0lDQWlRV05qYjNWdWRFRjFkR2hsYm5
  ScFkyRjBhVzl1SWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxCiAgQlRVRXRUV
  WcwTWkweVEwMUhMVVpGUjFRdE0xcFNSQzFITTBVMExVUkZTVmtpTEFvZ0lDQWd
  JQ0FpVUhWaWIKICBHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQQogIGdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVdEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmliR2xqSWpvZ0lsbEhaC
  iAgVTF0UlZsNk0wMVJUbkZCYkdWaVUxbG9RV3RUWmpndFMwRmZNMjl4TVZOME1
  sTnlNVzB3ZEZoMGRETldNa2MKICB4U0RRS0lDQm1UVTF5U1c5WFVUWlVhMjF0V
  m5CdWVsTXhTbTkzWjBFaWZYMTlMQW9nSUNBZ0lrRmpZMjkxYgogIG5SVGFXZHV
  ZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVSklWaTFIV0VKQ0xWW
  kxRbEF0VjFoCiAgVVR5MUNWMWxGTFZoTVdWTXRVVTFTVENJc0NpQWdJQ0FnSUN
  KUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2UKICB3b2dJQ0FnSUNBZ0lDSlFkV
  0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSgo
  gIEZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2dJalprTFd4R
  WNrVlVNVXBuVG10bWRucEdhCiAgRWs1VGtRNVQxZ3liemhOYkhRdFdraFZWbkJ
  mZEZVdFkzcHNPV0UwYzBkNk9Ib0tJQ0IxUTNCMU5XTlZURXgKICBEZEhSRmQxR
  kVVWFI1VTB4dFFVRWlmWDE5ZlgwIiwKICAgICAgICAgIHsKICAgICAgICAgICA
  gInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAgICAgImFsZyI6ICJTNTEyI
  iwKICAgICAgICAgICAgICAgICJraWQiOiAiTUROQy1USTRPLVZDRjctWkFJSi1
  ZQlpILVNTRTYtV1NZSyIsCiAgICAgICAgICAgICAgICAic2lnbmF0dXJlIjogI
  m01RjFjUnR1MjE2REF0c3FVbFJreW5aY0Z1REJoMk4weFBldmJ3SWJoT0lHTHV
  qb24KICBYX3hMU2NVUnJDQ1laT29CeTF2dDlpTFd5OEFhYnJKMkNBTm9hbUtna
  21OSWNaMTB0OTVKeFZERmdLTUNSQwogIEstM0dZS0pjVkFrY0hxcE5yYUdPTkl
  Ia0NGc0pxRllHWmoydF9meXdBIn1dLAogICAgICAgICAgICAiUGF5bG9hZERpZ
  2VzdCI6ICI5MlQwRFpDdDVYSlpOcUdKcGQxalBhR3RYd0tXQlNPRDdwUTRCdUx
  CZk54Q0QKICB6Skt6azlvZ1pnbHJIZTRSdGQ5Rk5pcTQ5NV9QbjB3dnU2eWVYY
  0h3ZyJ9XSwKICAgICAgICAiUHJvdG9jb2xzIjogW3sKICAgICAgICAgICAgIlB
  yb3RvY29sIjogIm1tbSJ9XX1dfX0",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MBHV-GXBB-VKBP-WXTO-BWYE-XLYS-QMRL",
                "signature": "3h2Qo2NQJEmnxfpec1smn2ANj9godG1gjmKRBRI5lX_FSBEZA
  pBQONF7O1X8ediIGv4KT_42TuWAX_dO4a5FO8mkMyU08BOvUbn_SWhIMpuPOxE
  DZjxnOZfWiV8CaSa8tKTU_j7W02fNM_W5Eh3jTD8A"}],
            "PayloadDigest": "zmiwfLZDzh8q1uPzqGC2YBS5u8nuGELst68Lx-ByZO49K
  ZLrUEpH818GTlHxDtKWWOYl9RjlrlNWWVEjahOIgA"}],
        "Reply": true,
        "Subject": "alice@example.com",
        "PIN": "ACBR-HCBB-UYL7-6MVU-QKWB-4N64-UP3A"},
      {
        "MessageId": "NBR3-D554-BQLH-FK5I-7YU3-T5B2-XGDS",
        "Sender": "console@example.com",
        "Recipient": "alice@example.com",
        "Text": "start"},
      {
        "MessageId": "NDGZ-J52O-DPPK-JG7R-2YZQ-JUPS-3GJK",
        "Sender": "bob@example.com",
        "Recipient": "alice@example.com",
        "AuthenticatedData": [{
            "dig": "S512",
            "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjAtMTEtMDlUMTY6MDg6MTZaIn0"},
          "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTUROQy1USTRPLVZDRjctWkFJSi1ZQ
  lpILVNTRTYtV1NZSyIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJib2JAZXhhbXBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWN
  jb3VudCI6IFt7CiAgICAgICAgICAgICJFbnZlbG9wZUlEIjogIk1ETkMtVEk0T
  y1WQ0Y3LVpBSUotWUJaSC1TU0U2LVdTWUsiLAogICAgICAgICAgICAiZGlnIjo
  gIlM1MTIiLAogICAgICAgICAgICAiQ29udGVudE1ldGFEYXRhIjogImV3b2dJQ
  0pWYm1seGRXVkpSQ0k2SUNKTlJFNURMVlJKTkU4dFZrTkdOeTEKICBhUVVsS0x
  WbENXa2d0VTFORk5pMVhVMWxMSWl3S0lDQWlUV1Z6YzJGblpWUjVjR1VpT2lBa
  VVISnZabWxzWgogIFZWelpYSWlMQW9nSUNKamRIa2lPaUFpWVhCd2JHbGpZWFJ
  wYjI0dmJXMXRMMjlpYW1WamRDSXNDaUFnSWtOCiAgeVpXRjBaV1FpT2lBaU1qQ
  XlNQzB4TVMwd09WUXhOam93T0RveE5sb2lmUSJ9LAogICAgICAgICAgImV3b2d
  JQ0pRY205bWFXeGxWWE5sY2lJNklIc0tJQ0FnSUNKUWNtOW1hV3gKICBsVTJsb
  mJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxRVRrTXRWRWswVHk
  xV1EwWTNMVnBCUwogIFVvdFdVSmFTQzFUVTBVMkxWZFRXVXNpTEFvZ0lDQWdJQ
  0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzCiAgS0lDQWdJQ0FnSUNBaVV
  IVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbllpT2lBa
  VIKICBXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSlVZWEl
  3TkhGc2FVRmtWakZ3UkZsWmNVbAogIDZSMU00ZUZNd01FVkJhM2hOVlZNNGRHb
  G5iamxETFRkUFRWOHdUa2RWTlZwakNpQWdjVzB3UkZKdVYxSTJYCiAgekZQU0c
  5UVpEY3diV05UTUUxQkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFFXUmtjbVZ6Y
  3lJNklDSmliMkoKICBBWlhoaGJYQnNaUzVqYjIwaUxBb2dJQ0FnSWxObGNuWnB
  ZMlZWWkdZaU9pQWlUVUpEU1MxVU5GWTNMVUZKUQogIGpRdFIwMUlNeTAwUXpaU
  0xVdEVOVkF0U1VOUE15SXNDaUFnSUNBaVFXTmpiM1Z1ZEVWdVkzSjVjSFJwYjI
  0CiAgaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVTkdRaTFTVVZrMExUZFpSV
  Wt0TkVzelVTMUROMUUzTFZjMFEKICBVTXRUVUZVVENJc0NpQWdJQ0FnSUNKUWR
  XSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSgogIFFkV0pzY
  VdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE
  0SWl3S0lDQWdJCiAgQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlZbnBmVFZKWlRqa
  zVUakpUUm5GYVMyRk1hSG90UjFrd01WcENSekIKICAwTjJGUFoweDRiMTlFTjN
  CNlZGazJXbU5aUzB4emR3b2dJRVZqYkRRME5ITlRaa0pxV1VWSFExUlZUbWREY
  gogIGsxSFFTSjlmWDBzQ2lBZ0lDQWlRV1J0YVc1cGMzUnlZWFJ2Y2xOcFoyNWh
  kSFZ5WlNJNklIc0tJQ0FnSUNBCiAgZ0lsVmtaaUk2SUNKTlJFNURMVlJKTkU4d
  FZrTkdOeTFhUVVsS0xWbENXa2d0VTFORk5pMVhVMWxMSWl3S0kKICBDQWdJQ0F
  nSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZb
  XhwWTB0bGVVVgogIERSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0l
  rVmtORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkCiAgV0pzYVdNaU9pQWlWR0Z5T
  URSeGJHbEJaRll4Y0VSWldYRkpla2RUT0hoVE1EQkZRV3Q0VFZWVE9IUnBaMjQ
  KICA1UXkwM1QwMWZNRTVIVlRWYVl3b2dJSEZ0TUVSU2JsZFNObDh4VDBodlVHU
  TNNRzFqVXpCTlFTSjlmWDBzQwogIGlBZ0lDQWlRV05qYjNWdWRFRjFkR2hsYm5
  ScFkyRjBhVzl1SWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxCiAgQlRVRXRUV
  WcwTWkweVEwMUhMVVpGUjFRdE0xcFNSQzFITTBVMExVUkZTVmtpTEFvZ0lDQWd
  JQ0FpVUhWaWIKICBHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQQogIGdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVdEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmliR2xqSWpvZ0lsbEhaC
  iAgVTF0UlZsNk0wMVJUbkZCYkdWaVUxbG9RV3RUWmpndFMwRmZNMjl4TVZOME1
  sTnlNVzB3ZEZoMGRETldNa2MKICB4U0RRS0lDQm1UVTF5U1c5WFVUWlVhMjF0V
  m5CdWVsTXhTbTkzWjBFaWZYMTlMQW9nSUNBZ0lrRmpZMjkxYgogIG5SVGFXZHV
  ZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVSklWaTFIV0VKQ0xWW
  kxRbEF0VjFoCiAgVVR5MUNWMWxGTFZoTVdWTXRVVTFTVENJc0NpQWdJQ0FnSUN
  KUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2UKICB3b2dJQ0FnSUNBZ0lDSlFkV
  0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSgo
  gIEZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2dJalprTFd4R
  WNrVlVNVXBuVG10bWRucEdhCiAgRWs1VGtRNVQxZ3liemhOYkhRdFdraFZWbkJ
  mZEZVdFkzcHNPV0UwYzBkNk9Ib0tJQ0IxUTNCMU5XTlZURXgKICBEZEhSRmQxR
  kVVWFI1VTB4dFFVRWlmWDE5ZlgwIiwKICAgICAgICAgIHsKICAgICAgICAgICA
  gInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAgICAgImFsZyI6ICJTNTEyI
  iwKICAgICAgICAgICAgICAgICJraWQiOiAiTUROQy1USTRPLVZDRjctWkFJSi1
  ZQlpILVNTRTYtV1NZSyIsCiAgICAgICAgICAgICAgICAic2lnbmF0dXJlIjogI
  m01RjFjUnR1MjE2REF0c3FVbFJreW5aY0Z1REJoMk4weFBldmJ3SWJoT0lHTHV
  qb24KICBYX3hMU2NVUnJDQ1laT29CeTF2dDlpTFd5OEFhYnJKMkNBTm9hbUtna
  21OSWNaMTB0OTVKeFZERmdLTUNSQwogIEstM0dZS0pjVkFrY0hxcE5yYUdPTkl
  Ia0NGc0pxRllHWmoydF9meXdBIn1dLAogICAgICAgICAgICAiUGF5bG9hZERpZ
  2VzdCI6ICI5MlQwRFpDdDVYSlpOcUdKcGQxalBhR3RYd0tXQlNPRDdwUTRCdUx
  CZk54Q0QKICB6Skt6azlvZ1pnbHJIZTRSdGQ5Rk5pcTQ5NV9QbjB3dnU2eWVYY
  0h3ZyJ9XSwKICAgICAgICAiUHJvdG9jb2xzIjogW3sKICAgICAgICAgICAgIlB
  yb3RvY29sIjogIm1tbSJ9XX1dfX0",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MBHV-GXBB-VKBP-WXTO-BWYE-XLYS-QMRL",
                "signature": "3h2Qo2NQJEmnxfpec1smn2ANj9godG1gjmKRBRI5lX_FSBEZA
  pBQONF7O1X8ediIGv4KT_42TuWAX_dO4a5FO8mkMyU08BOvUbn_SWhIMpuPOxE
  DZjxnOZfWiV8CaSa8tKTU_j7W02fNM_W5Eh3jTD8A"}],
            "PayloadDigest": "zmiwfLZDzh8q1uPzqGC2YBS5u8nuGELst68Lx-ByZO49K
  ZLrUEpH818GTlHxDtKWWOYl9RjlrlNWWVEjahOIgA"}],
        "Reply": true,
        "Subject": "alice@example.com",
        "PIN": "ACJP-PFU2-2O4N-73XX-J3KN-E7K4-FV3A"}]}}
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


