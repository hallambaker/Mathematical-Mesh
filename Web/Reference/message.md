

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
      "MessageId": "ND5A-QIRU-VE3S-DA6R-CJDO-3RUB-KIR7",
      "Sender": "bob@example.com",
      "Recipient": "alice@example.com",
      "AuthenticatedData": [{
          "dig": "S512",
          "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjAtMTEtMTBUMDA6NTY6MzVaIn0"},
        "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTUNOTi1FRE82LUdZWUYtMkgySC1JS
  lRWLUtYUVotVFhYSiIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJib2JAZXhhbXBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWN
  jb3VudCI6IFt7CiAgICAgICAgICAgICJFbnZlbG9wZUlEIjogIk1DTk4tRURPN
  i1HWVlGLTJIMkgtSUpUVi1LWFFaLVRYWEoiLAogICAgICAgICAgICAiZGlnIjo
  gIlM1MTIiLAogICAgICAgICAgICAiQ29udGVudE1ldGFEYXRhIjogImV3b2dJQ
  0pWYm1seGRXVkpSQ0k2SUNKTlEwNU9MVVZFVHpZdFIxbFpSaTAKICB5U0RKSUx
  VbEtWRll0UzFoUldpMVVXRmhLSWl3S0lDQWlUV1Z6YzJGblpWUjVjR1VpT2lBa
  VVISnZabWxzWgogIFZWelpYSWlMQW9nSUNKamRIa2lPaUFpWVhCd2JHbGpZWFJ
  wYjI0dmJXMXRMMjlpYW1WamRDSXNDaUFnSWtOCiAgeVpXRjBaV1FpT2lBaU1qQ
  XlNQzB4TVMweE1GUXdNRG8xTmpvek5Wb2lmUSJ9LAogICAgICAgICAgImV3b2d
  JQ0pRY205bWFXeGxWWE5sY2lJNklIc0tJQ0FnSUNKUWNtOW1hV3gKICBsVTJsb
  mJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxRFRrNHRSVVJQTmk
  xSFdWbEdMVEpJTQogIGtndFNVcFVWaTFMV0ZGYUxWUllXRW9pTEFvZ0lDQWdJQ
  0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzCiAgS0lDQWdJQ0FnSUNBaVV
  IVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbllpT2lBa
  VIKICBXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSkdka0Z
  TT0ROdk5FMXJNRUpKWlZRMWFrWgogIENMVUZqY0hrNVdWWTBSakZxV21SblduT
  ktaMEpFZVdwMlVGTnFUM1pRVDI1MkNpQWdiamhEYkROYVUzVnNPCiAgRlYyZFR
  WNGNuQkVaM05hWmtWQkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFFXUmtjbVZ6Y
  3lJNklDSmliMkoKICBBWlhoaGJYQnNaUzVqYjIwaUxBb2dJQ0FnSWxObGNuWnB
  ZMlZWWkdZaU9pQWlUVUpYVGkxR1RFOUlMVmhPUgogIFRjdFdGTklTaTFUTTBkV
  UxVVTBRa2t0VlVOSlJTSXNDaUFnSUNBaVFXTmpiM1Z1ZEVWdVkzSjVjSFJwYjI
  0CiAgaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVUkVVUzFOU0ZSQkxVVkNVV
  md0VWxkUVNDMUhUVlkxTFVGQ00KICBrRXRRMDQzVmlJc0NpQWdJQ0FnSUNKUWR
  XSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSgogIFFkV0pzY
  VdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE
  0SWl3S0lDQWdJCiAgQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlkRzFLYVdzek1VZ
  DJhME52TTNOYVpFOVJhR1UxVEVFMmFscGtlREIKICBWUnkxUVNGZHJOMTgxTmt
  Oa1RHUndTMmRYZUVWa2FBb2dJRjlDUWsxcmNFSkZPVVJrYjFsTk1HaHJSR2xwU
  gogIDFKaFFTSjlmWDBzQ2lBZ0lDQWlRV1J0YVc1cGMzUnlZWFJ2Y2xOcFoyNWh
  kSFZ5WlNJNklIc0tJQ0FnSUNBCiAgZ0lsVmtaaUk2SUNKTlEwNU9MVVZFVHpZd
  FIxbFpSaTB5U0RKSUxVbEtWRll0UzFoUldpMVVXRmhLSWl3S0kKICBDQWdJQ0F
  nSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZb
  XhwWTB0bGVVVgogIERSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0l
  rVmtORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkCiAgV0pzYVdNaU9pQWlSblpCV
  WpnemJ6Uk5hekJDU1dWVU5XcEdRaTFCWTNCNU9WbFdORVl4YWxwa1oxcHpTbWQ
  KICBDUkhscWRsQlRhazkyVUU5dWRnb2dJRzQ0UTJ3eldsTjFiRGhWZG5VMWVIS
  ndSR2R6V21aRlFTSjlmWDBzQwogIGlBZ0lDQWlRV05qYjNWdWRFRjFkR2hsYm5
  ScFkyRjBhVzl1SWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxCiAgQ1NEWXRUM
  DVETmkxQk5FRkVMVlJUV2pjdFJVNDJOUzFSVkZSUExVb3pRak1pTEFvZ0lDQWd
  JQ0FpVUhWaWIKICBHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQQogIGdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVdEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmliR2xqSWpvZ0ltc3hVC
  iAgakl0UTNOZmJXNTZaM2d4Y2xKQ01EQTFZVUp1T1hkR2NWRkRUbE5DVVdsNFp
  uazVaMWg2VFhCZmEyaDJXRTEKICB6YkhvS0lDQTVYMFI0WmpsekxYQnNlbmxLU
  VdkTGRreHNlbDl5VlVFaWZYMTlMQW9nSUNBZ0lrRmpZMjkxYgogIG5SVGFXZHV
  ZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVTlVUeTFEUVU1T0xUU
  lRSVUl0V1VwCiAgUVJDMUpVVkZETFVwVFdVa3ROVTgzU0NJc0NpQWdJQ0FnSUN
  KUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2UKICB3b2dJQ0FnSUNBZ0lDSlFkV
  0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSgo
  gIEZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2dJamxKVWpSQ
  ldsQTNaMGRwWkdZNVdrZHVhCiAga05wZW5FdGVEbEJRbkJCVUdoVlNWcGFhM2R
  xV0ZCYVdqTnVkMU52V21Kc1lrc0tJQ0J1Y2poeGMzTTNaSGgKICBJZEhwRGRGc
  EdiMlJIYUhkWWQwRWlmWDE5ZlgwIiwKICAgICAgICAgIHsKICAgICAgICAgICA
  gInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAgICAgImFsZyI6ICJTNTEyI
  iwKICAgICAgICAgICAgICAgICJraWQiOiAiTUNOTi1FRE82LUdZWUYtMkgySC1
  JSlRWLUtYUVotVFhYSiIsCiAgICAgICAgICAgICAgICAic2lnbmF0dXJlIjogI
  mNXSnpZTkN6NURhYzhQT0Z2RFFXVGtkQVBEeWd0OFRabExHNzJteGIzSWoxeDl
  6ajUKICBGNEI2SXlBdk1fZGdKQjd4Tjc0aXFTOVk4UUFZdjFnU1dHOWphcUxHM
  UJhbHhveWVaVFdFSE9manJyci1ObgogIEFWeGxRZTZxZWxTV2RLblN1SWZjM1J
  kYzZkVWFONUFWQTV4enExQWdBIn1dLAogICAgICAgICAgICAiUGF5bG9hZERpZ
  2VzdCI6ICIwNW9Dd3dOQXpIaWRzSnpGRDUtcWJONkFaLXBSVG9nTWVuUUtaZFJ
  PQVZJZVgKICBwRkN1cWotS2UtMmZZNThydk94Qll2ZWYwMGplUHU3WkhlYU92a
  nZZdyJ9XSwKICAgICAgICAiUHJvdG9jb2xzIjogW3sKICAgICAgICAgICAgIlB
  yb3RvY29sIjogIm1tbSJ9XX1dfX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MCTO-CANN-4SEB-YJPD-IQQC-JSYI-5O7H",
              "signature": "WLIrITvm0HGLfI6bdbudkzE6wInRqeKPWOdKeChCVV0c_ce17
  _JX47rFO5PWdhg6WtDmYaerkgqAy9GK1N6EKS6soKj7TJ04MH0Fab9Ih2Z-quZ
  Ky6uJu1RznQCbqaH8cs5VoMjpv6NRlyoeSoCxzjwA"}],
          "PayloadDigest": "p5NTgSdNFJ3-PMfHQPUzfZ-9cAHLZU9_J6YTfD7i4m-br
  hB_ub_2GWZwxWel2N3qps_BMYHYR4VZMvKt9jqf5A"}],
      "Reply": true,
      "Subject": "alice@example.com",
      "PIN": "AC2Z-MDNH-J3CC-T2OP-Z36L-CJF4-75WQ"}}}
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
      "MessageId": "NDUY-KIYX-RINT-7N5B-JY3H-JERJ-QVQG",
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
<rsp>MessageID: ND5A-QIRU-VE3S-DA6R-CJDO-3RUB-KIR7
        Contact Request::
        MessageID: ND5A-QIRU-VE3S-DA6R-CJDO-3RUB-KIR7
        To: alice@example.com From: bob@example.com
        PIN: AC2Z-MDNH-J3CC-T2OP-Z36L-CJF4-75WQ
MessageID: NDDR-3DMR-QFGH-5NTT-W6V4-WAWM-ERSN
        Confirmation Request::
        MessageID: NDDR-3DMR-QFGH-5NTT-W6V4-WAWM-ERSN
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NB2L-XW4K-7HZ3-5UHJ-B46U-2ZUJ-KXWC
        Contact Request::
        MessageID: NB2L-XW4K-7HZ3-5UHJ-B46U-2ZUJ-KXWC
        To: alice@example.com From: bob@example.com
        PIN: ACQ6-HOEL-5EOQ-OKX4-XIX5-ZUSS-JGIA
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
        "MessageId": "ND5A-QIRU-VE3S-DA6R-CJDO-3RUB-KIR7",
        "Sender": "bob@example.com",
        "Recipient": "alice@example.com",
        "AuthenticatedData": [{
            "dig": "S512",
            "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjAtMTEtMTBUMDA6NTY6MzVaIn0"},
          "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTUNOTi1FRE82LUdZWUYtMkgySC1JS
  lRWLUtYUVotVFhYSiIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJib2JAZXhhbXBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWN
  jb3VudCI6IFt7CiAgICAgICAgICAgICJFbnZlbG9wZUlEIjogIk1DTk4tRURPN
  i1HWVlGLTJIMkgtSUpUVi1LWFFaLVRYWEoiLAogICAgICAgICAgICAiZGlnIjo
  gIlM1MTIiLAogICAgICAgICAgICAiQ29udGVudE1ldGFEYXRhIjogImV3b2dJQ
  0pWYm1seGRXVkpSQ0k2SUNKTlEwNU9MVVZFVHpZdFIxbFpSaTAKICB5U0RKSUx
  VbEtWRll0UzFoUldpMVVXRmhLSWl3S0lDQWlUV1Z6YzJGblpWUjVjR1VpT2lBa
  VVISnZabWxzWgogIFZWelpYSWlMQW9nSUNKamRIa2lPaUFpWVhCd2JHbGpZWFJ
  wYjI0dmJXMXRMMjlpYW1WamRDSXNDaUFnSWtOCiAgeVpXRjBaV1FpT2lBaU1qQ
  XlNQzB4TVMweE1GUXdNRG8xTmpvek5Wb2lmUSJ9LAogICAgICAgICAgImV3b2d
  JQ0pRY205bWFXeGxWWE5sY2lJNklIc0tJQ0FnSUNKUWNtOW1hV3gKICBsVTJsb
  mJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxRFRrNHRSVVJQTmk
  xSFdWbEdMVEpJTQogIGtndFNVcFVWaTFMV0ZGYUxWUllXRW9pTEFvZ0lDQWdJQ
  0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzCiAgS0lDQWdJQ0FnSUNBaVV
  IVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbllpT2lBa
  VIKICBXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSkdka0Z
  TT0ROdk5FMXJNRUpKWlZRMWFrWgogIENMVUZqY0hrNVdWWTBSakZxV21SblduT
  ktaMEpFZVdwMlVGTnFUM1pRVDI1MkNpQWdiamhEYkROYVUzVnNPCiAgRlYyZFR
  WNGNuQkVaM05hWmtWQkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFFXUmtjbVZ6Y
  3lJNklDSmliMkoKICBBWlhoaGJYQnNaUzVqYjIwaUxBb2dJQ0FnSWxObGNuWnB
  ZMlZWWkdZaU9pQWlUVUpYVGkxR1RFOUlMVmhPUgogIFRjdFdGTklTaTFUTTBkV
  UxVVTBRa2t0VlVOSlJTSXNDaUFnSUNBaVFXTmpiM1Z1ZEVWdVkzSjVjSFJwYjI
  0CiAgaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVUkVVUzFOU0ZSQkxVVkNVV
  md0VWxkUVNDMUhUVlkxTFVGQ00KICBrRXRRMDQzVmlJc0NpQWdJQ0FnSUNKUWR
  XSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSgogIFFkV0pzY
  VdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE
  0SWl3S0lDQWdJCiAgQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlkRzFLYVdzek1VZ
  DJhME52TTNOYVpFOVJhR1UxVEVFMmFscGtlREIKICBWUnkxUVNGZHJOMTgxTmt
  Oa1RHUndTMmRYZUVWa2FBb2dJRjlDUWsxcmNFSkZPVVJrYjFsTk1HaHJSR2xwU
  gogIDFKaFFTSjlmWDBzQ2lBZ0lDQWlRV1J0YVc1cGMzUnlZWFJ2Y2xOcFoyNWh
  kSFZ5WlNJNklIc0tJQ0FnSUNBCiAgZ0lsVmtaaUk2SUNKTlEwNU9MVVZFVHpZd
  FIxbFpSaTB5U0RKSUxVbEtWRll0UzFoUldpMVVXRmhLSWl3S0kKICBDQWdJQ0F
  nSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZb
  XhwWTB0bGVVVgogIERSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0l
  rVmtORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkCiAgV0pzYVdNaU9pQWlSblpCV
  WpnemJ6Uk5hekJDU1dWVU5XcEdRaTFCWTNCNU9WbFdORVl4YWxwa1oxcHpTbWQ
  KICBDUkhscWRsQlRhazkyVUU5dWRnb2dJRzQ0UTJ3eldsTjFiRGhWZG5VMWVIS
  ndSR2R6V21aRlFTSjlmWDBzQwogIGlBZ0lDQWlRV05qYjNWdWRFRjFkR2hsYm5
  ScFkyRjBhVzl1SWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxCiAgQ1NEWXRUM
  DVETmkxQk5FRkVMVlJUV2pjdFJVNDJOUzFSVkZSUExVb3pRak1pTEFvZ0lDQWd
  JQ0FpVUhWaWIKICBHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQQogIGdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVdEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmliR2xqSWpvZ0ltc3hVC
  iAgakl0UTNOZmJXNTZaM2d4Y2xKQ01EQTFZVUp1T1hkR2NWRkRUbE5DVVdsNFp
  uazVaMWg2VFhCZmEyaDJXRTEKICB6YkhvS0lDQTVYMFI0WmpsekxYQnNlbmxLU
  VdkTGRreHNlbDl5VlVFaWZYMTlMQW9nSUNBZ0lrRmpZMjkxYgogIG5SVGFXZHV
  ZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVTlVUeTFEUVU1T0xUU
  lRSVUl0V1VwCiAgUVJDMUpVVkZETFVwVFdVa3ROVTgzU0NJc0NpQWdJQ0FnSUN
  KUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2UKICB3b2dJQ0FnSUNBZ0lDSlFkV
  0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSgo
  gIEZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2dJamxKVWpSQ
  ldsQTNaMGRwWkdZNVdrZHVhCiAga05wZW5FdGVEbEJRbkJCVUdoVlNWcGFhM2R
  xV0ZCYVdqTnVkMU52V21Kc1lrc0tJQ0J1Y2poeGMzTTNaSGgKICBJZEhwRGRGc
  EdiMlJIYUhkWWQwRWlmWDE5ZlgwIiwKICAgICAgICAgIHsKICAgICAgICAgICA
  gInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAgICAgImFsZyI6ICJTNTEyI
  iwKICAgICAgICAgICAgICAgICJraWQiOiAiTUNOTi1FRE82LUdZWUYtMkgySC1
  JSlRWLUtYUVotVFhYSiIsCiAgICAgICAgICAgICAgICAic2lnbmF0dXJlIjogI
  mNXSnpZTkN6NURhYzhQT0Z2RFFXVGtkQVBEeWd0OFRabExHNzJteGIzSWoxeDl
  6ajUKICBGNEI2SXlBdk1fZGdKQjd4Tjc0aXFTOVk4UUFZdjFnU1dHOWphcUxHM
  UJhbHhveWVaVFdFSE9manJyci1ObgogIEFWeGxRZTZxZWxTV2RLblN1SWZjM1J
  kYzZkVWFONUFWQTV4enExQWdBIn1dLAogICAgICAgICAgICAiUGF5bG9hZERpZ
  2VzdCI6ICIwNW9Dd3dOQXpIaWRzSnpGRDUtcWJONkFaLXBSVG9nTWVuUUtaZFJ
  PQVZJZVgKICBwRkN1cWotS2UtMmZZNThydk94Qll2ZWYwMGplUHU3WkhlYU92a
  nZZdyJ9XSwKICAgICAgICAiUHJvdG9jb2xzIjogW3sKICAgICAgICAgICAgIlB
  yb3RvY29sIjogIm1tbSJ9XX1dfX0",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MCTO-CANN-4SEB-YJPD-IQQC-JSYI-5O7H",
                "signature": "WLIrITvm0HGLfI6bdbudkzE6wInRqeKPWOdKeChCVV0c_ce17
  _JX47rFO5PWdhg6WtDmYaerkgqAy9GK1N6EKS6soKj7TJ04MH0Fab9Ih2Z-quZ
  Ky6uJu1RznQCbqaH8cs5VoMjpv6NRlyoeSoCxzjwA"}],
            "PayloadDigest": "p5NTgSdNFJ3-PMfHQPUzfZ-9cAHLZU9_J6YTfD7i4m-br
  hB_ub_2GWZwxWel2N3qps_BMYHYR4VZMvKt9jqf5A"}],
        "Reply": true,
        "Subject": "alice@example.com",
        "PIN": "AC2Z-MDNH-J3CC-T2OP-Z36L-CJF4-75WQ"},
      {
        "MessageId": "NDDR-3DMR-QFGH-5NTT-W6V4-WAWM-ERSN",
        "Sender": "console@example.com",
        "Recipient": "alice@example.com",
        "Text": "start"},
      {
        "MessageId": "NB2L-XW4K-7HZ3-5UHJ-B46U-2ZUJ-KXWC",
        "Sender": "bob@example.com",
        "Recipient": "alice@example.com",
        "AuthenticatedData": [{
            "dig": "S512",
            "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjAtMTEtMTBUMDA6NTY6MzVaIn0"},
          "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTUNOTi1FRE82LUdZWUYtMkgySC1JS
  lRWLUtYUVotVFhYSiIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJib2JAZXhhbXBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWN
  jb3VudCI6IFt7CiAgICAgICAgICAgICJFbnZlbG9wZUlEIjogIk1DTk4tRURPN
  i1HWVlGLTJIMkgtSUpUVi1LWFFaLVRYWEoiLAogICAgICAgICAgICAiZGlnIjo
  gIlM1MTIiLAogICAgICAgICAgICAiQ29udGVudE1ldGFEYXRhIjogImV3b2dJQ
  0pWYm1seGRXVkpSQ0k2SUNKTlEwNU9MVVZFVHpZdFIxbFpSaTAKICB5U0RKSUx
  VbEtWRll0UzFoUldpMVVXRmhLSWl3S0lDQWlUV1Z6YzJGblpWUjVjR1VpT2lBa
  VVISnZabWxzWgogIFZWelpYSWlMQW9nSUNKamRIa2lPaUFpWVhCd2JHbGpZWFJ
  wYjI0dmJXMXRMMjlpYW1WamRDSXNDaUFnSWtOCiAgeVpXRjBaV1FpT2lBaU1qQ
  XlNQzB4TVMweE1GUXdNRG8xTmpvek5Wb2lmUSJ9LAogICAgICAgICAgImV3b2d
  JQ0pRY205bWFXeGxWWE5sY2lJNklIc0tJQ0FnSUNKUWNtOW1hV3gKICBsVTJsb
  mJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxRFRrNHRSVVJQTmk
  xSFdWbEdMVEpJTQogIGtndFNVcFVWaTFMV0ZGYUxWUllXRW9pTEFvZ0lDQWdJQ
  0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzCiAgS0lDQWdJQ0FnSUNBaVV
  IVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbllpT2lBa
  VIKICBXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSkdka0Z
  TT0ROdk5FMXJNRUpKWlZRMWFrWgogIENMVUZqY0hrNVdWWTBSakZxV21SblduT
  ktaMEpFZVdwMlVGTnFUM1pRVDI1MkNpQWdiamhEYkROYVUzVnNPCiAgRlYyZFR
  WNGNuQkVaM05hWmtWQkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFFXUmtjbVZ6Y
  3lJNklDSmliMkoKICBBWlhoaGJYQnNaUzVqYjIwaUxBb2dJQ0FnSWxObGNuWnB
  ZMlZWWkdZaU9pQWlUVUpYVGkxR1RFOUlMVmhPUgogIFRjdFdGTklTaTFUTTBkV
  UxVVTBRa2t0VlVOSlJTSXNDaUFnSUNBaVFXTmpiM1Z1ZEVWdVkzSjVjSFJwYjI
  0CiAgaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVUkVVUzFOU0ZSQkxVVkNVV
  md0VWxkUVNDMUhUVlkxTFVGQ00KICBrRXRRMDQzVmlJc0NpQWdJQ0FnSUNKUWR
  XSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSgogIFFkV0pzY
  VdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE
  0SWl3S0lDQWdJCiAgQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlkRzFLYVdzek1VZ
  DJhME52TTNOYVpFOVJhR1UxVEVFMmFscGtlREIKICBWUnkxUVNGZHJOMTgxTmt
  Oa1RHUndTMmRYZUVWa2FBb2dJRjlDUWsxcmNFSkZPVVJrYjFsTk1HaHJSR2xwU
  gogIDFKaFFTSjlmWDBzQ2lBZ0lDQWlRV1J0YVc1cGMzUnlZWFJ2Y2xOcFoyNWh
  kSFZ5WlNJNklIc0tJQ0FnSUNBCiAgZ0lsVmtaaUk2SUNKTlEwNU9MVVZFVHpZd
  FIxbFpSaTB5U0RKSUxVbEtWRll0UzFoUldpMVVXRmhLSWl3S0kKICBDQWdJQ0F
  nSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZb
  XhwWTB0bGVVVgogIERSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0l
  rVmtORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkCiAgV0pzYVdNaU9pQWlSblpCV
  WpnemJ6Uk5hekJDU1dWVU5XcEdRaTFCWTNCNU9WbFdORVl4YWxwa1oxcHpTbWQ
  KICBDUkhscWRsQlRhazkyVUU5dWRnb2dJRzQ0UTJ3eldsTjFiRGhWZG5VMWVIS
  ndSR2R6V21aRlFTSjlmWDBzQwogIGlBZ0lDQWlRV05qYjNWdWRFRjFkR2hsYm5
  ScFkyRjBhVzl1SWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxCiAgQ1NEWXRUM
  DVETmkxQk5FRkVMVlJUV2pjdFJVNDJOUzFSVkZSUExVb3pRak1pTEFvZ0lDQWd
  JQ0FpVUhWaWIKICBHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQQogIGdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVdEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmliR2xqSWpvZ0ltc3hVC
  iAgakl0UTNOZmJXNTZaM2d4Y2xKQ01EQTFZVUp1T1hkR2NWRkRUbE5DVVdsNFp
  uazVaMWg2VFhCZmEyaDJXRTEKICB6YkhvS0lDQTVYMFI0WmpsekxYQnNlbmxLU
  VdkTGRreHNlbDl5VlVFaWZYMTlMQW9nSUNBZ0lrRmpZMjkxYgogIG5SVGFXZHV
  ZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVTlVUeTFEUVU1T0xUU
  lRSVUl0V1VwCiAgUVJDMUpVVkZETFVwVFdVa3ROVTgzU0NJc0NpQWdJQ0FnSUN
  KUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2UKICB3b2dJQ0FnSUNBZ0lDSlFkV
  0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSgo
  gIEZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2dJamxKVWpSQ
  ldsQTNaMGRwWkdZNVdrZHVhCiAga05wZW5FdGVEbEJRbkJCVUdoVlNWcGFhM2R
  xV0ZCYVdqTnVkMU52V21Kc1lrc0tJQ0J1Y2poeGMzTTNaSGgKICBJZEhwRGRGc
  EdiMlJIYUhkWWQwRWlmWDE5ZlgwIiwKICAgICAgICAgIHsKICAgICAgICAgICA
  gInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAgICAgImFsZyI6ICJTNTEyI
  iwKICAgICAgICAgICAgICAgICJraWQiOiAiTUNOTi1FRE82LUdZWUYtMkgySC1
  JSlRWLUtYUVotVFhYSiIsCiAgICAgICAgICAgICAgICAic2lnbmF0dXJlIjogI
  mNXSnpZTkN6NURhYzhQT0Z2RFFXVGtkQVBEeWd0OFRabExHNzJteGIzSWoxeDl
  6ajUKICBGNEI2SXlBdk1fZGdKQjd4Tjc0aXFTOVk4UUFZdjFnU1dHOWphcUxHM
  UJhbHhveWVaVFdFSE9manJyci1ObgogIEFWeGxRZTZxZWxTV2RLblN1SWZjM1J
  kYzZkVWFONUFWQTV4enExQWdBIn1dLAogICAgICAgICAgICAiUGF5bG9hZERpZ
  2VzdCI6ICIwNW9Dd3dOQXpIaWRzSnpGRDUtcWJONkFaLXBSVG9nTWVuUUtaZFJ
  PQVZJZVgKICBwRkN1cWotS2UtMmZZNThydk94Qll2ZWYwMGplUHU3WkhlYU92a
  nZZdyJ9XSwKICAgICAgICAiUHJvdG9jb2xzIjogW3sKICAgICAgICAgICAgIlB
  yb3RvY29sIjogIm1tbSJ9XX1dfX0",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MCTO-CANN-4SEB-YJPD-IQQC-JSYI-5O7H",
                "signature": "WLIrITvm0HGLfI6bdbudkzE6wInRqeKPWOdKeChCVV0c_ce17
  _JX47rFO5PWdhg6WtDmYaerkgqAy9GK1N6EKS6soKj7TJ04MH0Fab9Ih2Z-quZ
  Ky6uJu1RznQCbqaH8cs5VoMjpv6NRlyoeSoCxzjwA"}],
            "PayloadDigest": "p5NTgSdNFJ3-PMfHQPUzfZ-9cAHLZU9_J6YTfD7i4m-br
  hB_ub_2GWZwxWel2N3qps_BMYHYR4VZMvKt9jqf5A"}],
        "Reply": true,
        "Subject": "alice@example.com",
        "PIN": "ACQ6-HOEL-5EOQ-OKX4-XIX5-ZUSS-JGIA"}]}}
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


