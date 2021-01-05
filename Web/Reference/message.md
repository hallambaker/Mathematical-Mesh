

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
      "MessageId": "NDYJ-YGDF-XIZJ-I6ET-6QXN-CL7N-BO4C",
      "Sender": "bob@example.com",
      "Recipient": "alice@example.com",
      "AuthenticatedData": [{
          "dig": "S512",
          "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjEtMDEtMDRUMTM6Mzk6MzhaIn0"},
        "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTUI2Vy1WWkVLLVNMNFotWEU3Uy1aS
  DdFLVE2RlEtV1dPUCIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJib2JAZXhhbXBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWN
  jb3VudCI6IFt7CiAgICAgICAgICAgICJFbnZlbG9wZUlEIjogIk1CNlctVlpFS
  y1TTDRaLVhFN1MtWkg3RS1RNkZRLVdXT1AiLAogICAgICAgICAgICAiZGlnIjo
  gIlM1MTIiLAogICAgICAgICAgICAiQ29udGVudE1ldGFEYXRhIjogImV3b2dJQ
  0pWYm1seGRXVkpaQ0k2SUNKTlFqWlhMVlphUlVzdFUwdzBXaTEKICBZUlRkVEx
  WcElOMFV0VVRaR1VTMVhWMDlRSWl3S0lDQWlUV1Z6YzJGblpWUjVjR1VpT2lBa
  VVISnZabWxzWgogIFZWelpYSWlMQW9nSUNKamRIa2lPaUFpWVhCd2JHbGpZWFJ
  wYjI0dmJXMXRMMjlpYW1WamRDSXNDaUFnSWtOCiAgeVpXRjBaV1FpT2lBaU1qQ
  XlNUzB3TVMwd05GUXhNem96T1Rvek4xb2lmUSJ9LAogICAgICAgICAgImV3b2d
  JQ0pRY205bWFXeGxWWE5sY2lJNklIc0tJQ0FnSUNKUWNtOW1hV3gKICBsVTJsb
  mJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxQ05sY3RWbHBGU3k
  xVFREUmFMVmhGTgogIDFNdFdrZzNSUzFSTmtaUkxWZFhUMUFpTEFvZ0lDQWdJQ
  0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzCiAgS0lDQWdJQ0FnSUNBaVV
  IVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbllpT2lBa
  VIKICBXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSlpjV0p
  JUjNaelowaDVObXhYZDA5cE9HeAogIExaV3RoYVhGVlpGRm1RM0J2TW5ScVNrO
  DRkREZvWkVOTkxYVkdSV3h1U2tkZkNpQWdkaTEzUkdaMVNtdDZaCiAgMDVDY0V
  jdFdrNURWR1UzT1dOQkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFFXUmtjbVZ6Y
  3lJNklDSmliMkoKICBBWlhoaGJYQnNaUzVqYjIwaUxBb2dJQ0FnSWxObGNuWnB
  ZMlZWWkdZaU9pQWlUVVJQV0MxWVFsRTJMVUkyVQogIEVZdFJWQTFWeTAzVjBWR
  kxVWkRRMGt0U1ZKTE1pSXNDaUFnSUNBaVFXTmpiM1Z1ZEVWdVkzSjVjSFJwYjI
  0CiAgaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVSlFTeTAzVTFkSkxUWTFSa
  3N0UlVsT1Z5MUtSbEpPTFVkVU4KICBVZ3RWMWRDV1NJc0NpQWdJQ0FnSUNKUWR
  XSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSgogIFFkV0pzY
  VdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE
  0SWl3S0lDQWdJCiAgQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlaV1JQUVVGRmJIb
  FhTMmxETkZWcFQxcFZjMTlPVDI5NFpEbFFUVk4KICB5YUZsbWQwZHhNVFIxWjJ
  nelQxbHZVRGgwYW14amR3b2dJSGR1YzNaS1VVcEpNalEzU2xrMGJWbEVVRGxvW
  gogIG01SlFTSjlmWDBzQ2lBZ0lDQWlRV1J0YVc1cGMzUnlZWFJ2Y2xOcFoyNWh
  kSFZ5WlNJNklIc0tJQ0FnSUNBCiAgZ0lsVmtaaUk2SUNKTlJGWlRMVGMzTms4d
  FNVbFBRaTFFVjFJMUxUYzNTbE10VGxGV1JTMUNSVEpUSWl3S0kKICBDQWdJQ0F
  nSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZb
  XhwWTB0bGVVVgogIERSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0l
  rVmtORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkCiAgV0pzYVdNaU9pQWlaaTFOV
  URGQ04yUklURkYxWDJJeFdtaGtUazVvTUROTVVtRXpWWE5CZDA1alZqaE5UelY
  KICB0YWtSd2RERnVXbG81YWtGd1l3b2dJRkV6UjFOUlpsazVVSGhmZDNaaFZqR
  llXRmhzV2tsM1FTSjlmWDBzQwogIGlBZ0lDQWlRV05qYjNWdWRFRjFkR2hsYm5
  ScFkyRjBhVzl1SWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxCiAgQlVEY3RNb
  FJKUkMxVE5VTldMVkJGVjBJdFdFWTBSUzFJU3pOSkxUZEVVVVlpTEFvZ0lDQWd
  JQ0FpVUhWaWIKICBHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQQogIGdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVdEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmliR2xqSWpvZ0ltVlFiC
  iAgM0ZUUXpWTk5sTnFTVmwwTjNCc05HdE5WSEl6WTB0UVVFdE5aWE01U1d4eVV
  XaHJja1ZDY2xaUmEzRmpRa3gKICAxWDFvS0lDQkxWbXAxYkZONVkzZDBVSGg2T
  WxobFVXcFJabEpmWTBFaWZYMTlMQW9nSUNBZ0lrRmpZMjkxYgogIG5SVGFXZHV
  ZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVRlFUeTFJVGtORkxWb
  FpRMFF0VjFCCiAgSlVpMUdOa3BhTFVOUE4xRXROVmhUUlNJc0NpQWdJQ0FnSUN
  KUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2UKICB3b2dJQ0FnSUNBZ0lDSlFkV
  0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSgo
  gIEZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2dJazl6ZUVsb
  mQyMDJRMUppYTJSME5IVm9XCiAgRmR6VmxaaFNXSkhUME00T1c5a05XcFpNa3h
  xYlhaalZXdEpXakJOVHpCTFRrTUtJQ0JWU0hKUFFsQjNVakoKICBQVXpWaVpWQ
  jFRbFU0T1dveFFVRWlmWDE5ZlgwIiwKICAgICAgICAgIHsKICAgICAgICAgICA
  gInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAgICAgImFsZyI6ICJTNTEyI
  iwKICAgICAgICAgICAgICAgICJraWQiOiAiTUI2Vy1WWkVLLVNMNFotWEU3Uy1
  aSDdFLVE2RlEtV1dPUCIsCiAgICAgICAgICAgICAgICAic2lnbmF0dXJlIjogI
  jdWUm1ySWFwX1lVQW8tWDRJRXBXYTZ2SGttZU5odnRsUXJvT0NQaXNNR1R6NGt
  fT3IKICBmenFWNHgwbjFpcWtSa085R0daenlhdWx3eUFOZ051TG13UTlqTTRYZ
  FA2UHpwZTlWR3AxUFk3OS1aX0RjZgogIFZ6aDc0eUdlbTcybUljbDhWMzVIXzd
  3alBOUUxTQ3g1YVFINlJZRDhBIn1dLAogICAgICAgICAgICAiUGF5bG9hZERpZ
  2VzdCI6ICJKVHVaYUJwNWVnRS1tbFVKdl9kck0tYng5a1lUSG9oM2xEQWIxcWR
  FemZvZEYKICBKQjRyZVliWXlFM0d4Z1IwcEdFME1HZ2pIdENLekppWkVJQ1FCW
  EcxdyJ9XSwKICAgICAgICAiUHJvdG9jb2xzIjogW3sKICAgICAgICAgICAgIlB
  yb3RvY29sIjogIm1tbSJ9XX1dfX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MAPO-HNCE-YYCD-WPIR-F6JZ-CO7Q-5XSE",
              "signature": "-yoKcF25PLQzsbkeuZirPn57ADppacbMFC-P0upp4UOkRWe0Q
  8zkHWek1-mWn3l8FOXSvG8kM9KA9itSwp3Gfv0a0MVLcJIqqZ7AXVLpgagLIX0
  fut0FSZEEND93SnW068xBZqIM6axuAvzLDe24ADgA"}],
          "PayloadDigest": "4aJh0zFwjeQKK-z4UnyMMs8WLyJTp-HxtLjZHr-Yl-isJ
  HCi7J1Qage0f3TOi1heFpmi25h63eYXqKihEHULDw"}],
      "Reply": true,
      "Subject": "alice@example.com",
      "PIN": "AB4D-7L7V-3R2H-BDKA-MZIR-TNHH-C4GQ"}}}
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
      "MessageId": "NCVA-56QU-OLYV-N3Y6-LHDM-LMYI-5EZP",
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


