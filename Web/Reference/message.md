

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
    status   Request status of pending request
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
      "MessageId": "NAWL-UNGU-BP5H-Y4U5-CEH6-VF7P-M2PZ",
      "Sender": "bob@example.com",
      "Recipient": "alice@example.com",
      "AuthenticatedData": [{
          "dig": "S512",
          "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjAtMTEtMTNUMTQ6MjU6NDFaIn0"},
        "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTUNWWi1TUlY3LVFMNkEtNllWWC1QV
  TVQLVAyVUItQ1hGNSIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJib2JAZXhhbXBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWN
  jb3VudCI6IFt7CiAgICAgICAgICAgICJFbnZlbG9wZUlEIjogIk1DVlotU1JWN
  y1RTDZBLTZZVlgtUFU1UC1QMlVCLUNYRjUiLAogICAgICAgICAgICAiZGlnIjo
  gIlM1MTIiLAogICAgICAgICAgICAiQ29udGVudE1ldGFEYXRhIjogImV3b2dJQ
  0pWYm1seGRXVkpSQ0k2SUNKTlExWmFMVk5TVmpjdFVVdzJRUzAKICAyV1ZaWUx
  WQlZOVkF0VURKVlFpMURXRVkxSWl3S0lDQWlUV1Z6YzJGblpWUjVjR1VpT2lBa
  VVISnZabWxzWgogIFZWelpYSWlMQW9nSUNKamRIa2lPaUFpWVhCd2JHbGpZWFJ
  wYjI0dmJXMXRMMjlpYW1WamRDSXNDaUFnSWtOCiAgeVpXRjBaV1FpT2lBaU1qQ
  XlNQzB4TVMweE0xUXhORG95TlRvME1Wb2lmUSJ9LAogICAgICAgICAgImV3b2d
  JQ0pRY205bWFXeGxWWE5sY2lJNklIc0tJQ0FnSUNKUWNtOW1hV3gKICBsVTJsb
  mJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxRFZsb3RVMUpXTnk
  xUlREWkJMVFpaVgogIGxndFVGVTFVQzFRTWxWQ0xVTllSalVpTEFvZ0lDQWdJQ
  0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzCiAgS0lDQWdJQ0FnSUNBaVV
  IVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbllpT2lBa
  VIKICBXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSkJaMUp
  hV0c1dlREUkpYMGRrVkZkblNqTgogIEZZMjFGWlRsdFZVaFphbk5OTlZodmVXN
  TBUaTFKZVZOQlZtRkdiMEpTVTNCSkNpQWdibFJIZUMxbUxVMXFTCiAgV3R3Vlh
  RMlZrdFRUVTlTUVRCQkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFFXUmtjbVZ6Y
  3lJNklDSmliMkoKICBBWlhoaGJYQnNaUzVqYjIwaUxBb2dJQ0FnSWxObGNuWnB
  ZMlZWWkdZaU9pQWlUVUZOUVMwMlNFTmFMVWxCVAogIGtrdFNGSkVXUzFDUXpRe
  UxWQkZOMEV0UzFGR1NDSXNDaUFnSUNBaVFXTmpiM1Z1ZEVWdVkzSjVjSFJwYjI
  0CiAgaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVUTFTaTFKVUZGWUxVdzFRV
  FV0VGxkV1NpMUlTRUpKTFROWE4KICBqUXROVXhNTXlJc0NpQWdJQ0FnSUNKUWR
  XSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSgogIFFkV0pzY
  VdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE
  0SWl3S0lDQWdJCiAgQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlTRGM0VGxCUWQzZ
  E1Ta2RVZFdKWWVFSllTRVU0UW1OSVNIUkJjbDkKICBzTkVkZmNGcFRZa3hXUm1
  WMk1FeFpjREIxTXpGNlJRb2dJSEJRZDBOell6ZzRUV1o0TlRoSk5raFVTMGRYY
  gogIHpjeVFTSjlmWDBzQ2lBZ0lDQWlRV1J0YVc1cGMzUnlZWFJ2Y2xOcFoyNWh
  kSFZ5WlNJNklIc0tJQ0FnSUNBCiAgZ0lsVmtaaUk2SUNKTlExWmFMVk5TVmpjd
  FVVdzJRUzAyV1ZaWUxWQlZOVkF0VURKVlFpMURXRVkxSWl3S0kKICBDQWdJQ0F
  nSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZb
  XhwWTB0bGVVVgogIERSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0l
  rVmtORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkCiAgV0pzYVdNaU9pQWlRV2RTV
  2xodWIwdzBTVjlIWkZSWFowb3pSV050UldVNWJWVklXV3B6VFRWWWIzbHVkRTQ
  KICB0U1hsVFFWWmhSbTlDVWxOd1NRb2dJRzVVUjNndFppMU5ha2xyY0ZWME5sW
  kxVMDFQVWtFd1FTSjlmWDBzQwogIGlBZ0lDQWlRV05qYjNWdWRFRjFkR2hsYm5
  ScFkyRjBhVzl1SWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxCiAgQlRGRXRNM
  WRDVlMwMFJVTlVMVVpDVFZNdFZrNDBSQzB6UVVKQ0xVWk1OVmNpTEFvZ0lDQWd
  JQ0FpVUhWaWIKICBHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQQogIGdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVdEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmliR2xqSWpvZ0lqbEtlC
  iAgWFpzZW5wc2NuRkdOQzE1TTBSRlUyOTBjMWhEWjAxWGFVUlNhV0ZhYjJ4eGR
  HWTVVVWx4V1VOa1VGSlNNVkEKICAxTlhFS0lDQmpUM2RJVTI1RlpEaFFkMVZSU
  lRKcVowMHhlV3RUY1VFaWZYMTlMQW9nSUNBZ0lrRmpZMjkxYgogIG5SVGFXZHV
  ZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVTktWQzFXVVU1QkxVO
  DBRMVF0UzBSCiAgTk5pMU5WVTlJTFRWUFJVVXRXazgxUkNJc0NpQWdJQ0FnSUN
  KUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2UKICB3b2dJQ0FnSUNBZ0lDSlFkV
  0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSgo
  gIEZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2dJbFJNVlhGQ
  1UyOWFhek5VZFVsS2EwZzNVCiAgMjloZVc5SmJGZEpiMWhJYlZoMk1sazVZWHB
  4ZEcxR0xYWkZVbkI0U1hCc2NVb0tJQ0JaTm04NGJHd3dYMUoKICBNYlU1MmFEW
  klTVzB3UVU5aWJVRWlmWDE5ZlgwIiwKICAgICAgICAgIHsKICAgICAgICAgICA
  gInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAgICAgImFsZyI6ICJTNTEyI
  iwKICAgICAgICAgICAgICAgICJraWQiOiAiTUNWWi1TUlY3LVFMNkEtNllWWC1
  QVTVQLVAyVUItQ1hGNSIsCiAgICAgICAgICAgICAgICAic2lnbmF0dXJlIjogI
  jJRQ1dQZW5rOVJBMjI0dVRtY29CdWh5VXNUMkFPVkVLNTZ3aTUzNWo5dTZ5RUN
  fMFEKICBOMXlhX25nWG1KOGxNenU5LWdDMnJXN1RQQ0FQOVBkUnVNTDF3N2o2R
  WhHYzVma2NJQXRJZUpyeXp0MzUyXwogIGtMR1pxMnBBRnNNenJrNVVOdTYtWHJ
  rQ2VhNTNQd0xGdkxDNk04QTBBIn1dLAogICAgICAgICAgICAiUGF5bG9hZERpZ
  2VzdCI6ICJMN3Rwa1lyV1NVZERxZmR2cDV2ay1IY3V0bVZFNlIyMEN4NGxjSDV
  hbDRibEUKICBRM0dydDgxSWlEd2JmZVJfMDhZSDhMTG5fZ0ZQSm5zZGtwaU5YU
  mlNdyJ9XSwKICAgICAgICAiUHJvdG9jb2xzIjogW3sKICAgICAgICAgICAgIlB
  yb3RvY29sIjogIm1tbSJ9XX1dfX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MCJT-VQNA-O4CT-KDM6-MUOH-5OEE-ZO5D",
              "signature": "chMu_DLuJxEfdsI_0HWhi1r_949dTrzVw0cI91q7csNZQ6Chy
  q5XkApBkYwz8NPkXrFddfIUJeOAqAbycNN2acqxuHZLO4HXJ7WU6MrKw9Y4_l4
  mqnDBfqAANZ5LRd8OW73V8bIW4bSU2YTxbqNyYhcA"}],
          "PayloadDigest": "4N9KnV2j5d0poFT-BlXn158cl1fp2k2HtGVc3D0nR5k2f
  1F0SjWHtiw2SRbzbWe6E_fK_ZGqcd8CVpTN9JU_Jg"}],
      "Reply": true,
      "Subject": "alice@example.com",
      "PIN": "ACKX-PS25-IQRL-3ZK4-YZZJ-VFO2-D2QQ"}}}
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
      "MessageId": "NDRM-UZRI-COPF-5T2J-SHVG-YYC5-FHGE",
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
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> message pending /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
</div>
~~~~



# message status

~~~~
<div="helptext">
<over>
status   Request status of pending request
       Specifies the request to provide the status of
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
<rsp>Pending
</div>
~~~~

Specifying the /json option returns a result of type ResultReceived:

~~~~
<div="terminal">
<cmd>Bob> message status tbs /json
<rsp>{
  "ResultReceived": {
    "Success": true}}
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
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> message accept tbs /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
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
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> message reject tbs /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
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


