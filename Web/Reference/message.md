

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
      "MessageId": "NBYG-B7G5-EZCV-3RK5-NLYS-GWYI-PP7K",
      "Sender": "bob@example.com",
      "Recipient": "alice@example.com",
      "AuthenticatedData": [{
          "dig": "S512",
          "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjAtMTEtMTFUMTY6NTQ6MThaIn0"},
        "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTUJDQS1TRE1JLTJJMlotRUtIRi1CU
  EJSLVY0RVItNkxHWiIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJib2JAZXhhbXBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWN
  jb3VudCI6IFt7CiAgICAgICAgICAgICJFbnZlbG9wZUlEIjogIk1CQ0EtU0RNS
  S0ySTJaLUVLSEYtQlBCUi1WNEVSLTZMR1oiLAogICAgICAgICAgICAiZGlnIjo
  gIlM1MTIiLAogICAgICAgICAgICAiQ29udGVudE1ldGFEYXRhIjogImV3b2dJQ
  0pWYm1seGRXVkpSQ0k2SUNKTlFrTkJMVk5FVFVrdE1ra3lXaTEKICBGUzBoR0x
  VSlFRbEl0VmpSRlVpMDJURWRhSWl3S0lDQWlUV1Z6YzJGblpWUjVjR1VpT2lBa
  VVISnZabWxzWgogIFZWelpYSWlMQW9nSUNKamRIa2lPaUFpWVhCd2JHbGpZWFJ
  wYjI0dmJXMXRMMjlpYW1WamRDSXNDaUFnSWtOCiAgeVpXRjBaV1FpT2lBaU1qQ
  XlNQzB4TVMweE1WUXhOam8xTkRveE9Gb2lmUSJ9LAogICAgICAgICAgImV3b2d
  JQ0pRY205bWFXeGxWWE5sY2lJNklIc0tJQ0FnSUNKUWNtOW1hV3gKICBsVTJsb
  mJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxQ1EwRXRVMFJOU1M
  weVNUSmFMVVZMUwogIEVZdFFsQkNVaTFXTkVWU0xUWk1SMW9pTEFvZ0lDQWdJQ
  0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzCiAgS0lDQWdJQ0FnSUNBaVV
  IVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbllpT2lBa
  VIKICBXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSkxXalJ
  qWmxoMWJGaFVZMDVpTlRNelNUaAogIDNkWGQ1U2tvelRVNVNZMGsxTFdoTFpFN
  WpZMGMyUkdwMGJYbHNiMDQ1UmpKNkNpQWdia1Z1TWxaRE0xRmxOCiAgRmwzVUd
  rMU1VNHdlalJ3WlRaQkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFFXUmtjbVZ6Y
  3lJNklDSmliMkoKICBBWlhoaGJYQnNaUzVqYjIwaUxBb2dJQ0FnSWxObGNuWnB
  ZMlZWWkdZaU9pQWlUVUV5TWkxQ1ZqVkJMVkZRVgogIHpNdFNscElNaTFWUlZsR
  0xVRXlWRkF0U0ZOV05DSXNDaUFnSUNBaVFXTmpiM1Z1ZEVWdVkzSjVjSFJwYjI
  0CiAgaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVRlpReTAzTTFsTkxUTlFNM
  DB0VlRWT1VpMUxNazVSTFZRMk4KICBrMHRUbGxOU0NJc0NpQWdJQ0FnSUNKUWR
  XSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSgogIFFkV0pzY
  VdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE
  0SWl3S0lDQWdJCiAgQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWliR0V6VEZGQk5FO
  U9Oa05SVG0xSmFXcExWVUpFTkZWM2FYcERkVEoKICBoUkY5c1JtSkhTWHBIV0d
  GbUxXTnhZblpMVld4WVRBb2dJRk5vUW1WMk9YRm5aVVUxYlZObk5qaENRMnBSY
  QogIDBwM1FTSjlmWDBzQ2lBZ0lDQWlRV1J0YVc1cGMzUnlZWFJ2Y2xOcFoyNWh
  kSFZ5WlNJNklIc0tJQ0FnSUNBCiAgZ0lsVmtaaUk2SUNKTlFrTkJMVk5FVFVrd
  E1ra3lXaTFGUzBoR0xVSlFRbEl0VmpSRlVpMDJURWRhSWl3S0kKICBDQWdJQ0F
  nSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZb
  XhwWTB0bGVVVgogIERSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0l
  rVmtORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkCiAgV0pzYVdNaU9pQWlTMW8wW
  TJaWWRXeFlWR05PWWpVek0wazRkM1YzZVVwS00wMU9VbU5KTlMxb1MyUk9ZMk4
  KICBITmtScWRHMTViRzlPT1VZeWVnb2dJRzVGYmpKV1F6TlJaVFJaZDFCcE5UR
  k9NSG8wY0dVMlFTSjlmWDBzQwogIGlBZ0lDQWlRV05qYjNWdWRFRjFkR2hsYm5
  ScFkyRjBhVzl1SWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxCiAgQ1RFVXRTa
  mRQVnkweVVVUTBMVXBGV0VjdE1sUktWQzFYUVU1VkxUWllVMU1pTEFvZ0lDQWd
  JQ0FpVUhWaWIKICBHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQQogIGdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVdEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmliR2xqSWpvZ0ltTlBaC
  iAgakJOV1Uxd1pIUXdSM3BuTVVKUGEzSnJNMmxtUVdaVVR6QnpNRTlDYTNsSVl
  rMTZja0ZOUldNd1ppMXphSFIKICAwWDNrS0lDQjJibk5JV0V4R1UzZFhZVzk2Y
  msxS2JHeFFhRjl3VVVFaWZYMTlMQW9nSUNBZ0lrRmpZMjkxYgogIG5SVGFXZHV
  ZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVRlNWaTFCVUVaVExVS
  lFRMUF0VEZkCiAgVlZDMUJOMVpUTFRSWVdqSXRVMWMwU1NJc0NpQWdJQ0FnSUN
  KUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2UKICB3b2dJQ0FnSUNBZ0lDSlFkV
  0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSgo
  gIEZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2dJbmxhTlMxc
  lFYSnpPRzR5ZGt4ZlVDMWlTCiAgWFZRWlU5alRqTmxkVTFETVdsd09GZExXalZ
  PYURoMFMwbDBWSGxsTTNseFZYb0tJQ0J4Ym1KcE5VUkZkRVYKICBaVUhCdFNWV
  jRlbUZTZFU1S09FRWlmWDE5ZlgwIiwKICAgICAgICAgIHsKICAgICAgICAgICA
  gInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAgICAgImFsZyI6ICJTNTEyI
  iwKICAgICAgICAgICAgICAgICJraWQiOiAiTUJDQS1TRE1JLTJJMlotRUtIRi1
  CUEJSLVY0RVItNkxHWiIsCiAgICAgICAgICAgICAgICAic2lnbmF0dXJlIjogI
  mNIZDdpUS1qTWx0XzFrRElLM19RR0drSF94VDFSTE5QMUFkbVZBNnJ5OTdCWk5
  lM2YKICBoSzRibGZKMmJXM2RFSUZIS19QYmgyN2FxUUFnczA2VTFZQ0ExaThRe
  FJoQ1A3d2FKSnZ3Z0FCTnYyODg5OQogIHV3bGxDS2V2X0dCQWd6MWpKaDNoVGV
  6YmRLdjlaLUVJeFBtYmZUZ2NBIn1dLAogICAgICAgICAgICAiUGF5bG9hZERpZ
  2VzdCI6ICJob2FvWm1hb2gyb2NfYnQ5cmFhQjZvTFM0NXNoYzJtMG83Y3FZakZ
  mWmduZWQKICBaQ0E0TzY4cTlWVTFFTjhJejU4bTU1cGhITVJRbEdUNm53SXRkV
  GFCQSJ9XSwKICAgICAgICAiUHJvdG9jb2xzIjogW3sKICAgICAgICAgICAgIlB
  yb3RvY29sIjogIm1tbSJ9XX1dfX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MARV-APFS-BPCP-LWUT-A7VS-4XZ2-SW4I",
              "signature": "BwaHcVJHPhvlUgOuxT_kAbhE2kLQdQuCPBngxtu5NT6ihvyAR
  POQVWWUkDk0MyPwZb-rArQcVXcA4DcDx90l5GHSlvh1zFeBlJyptsFeecDVprr
  LabjPOgSTVcr07EP4bM7IvqvZR4Z5spElMBKA3C0A"}],
          "PayloadDigest": "zwOhKsk4eAydUZudn5T-c8A81wSSJbrxdROpCzX7ziZqJ
  RCpwrvgCsEiwifx3Z9Q7E4sRn3a1zFsHbcMOsmxUg"}],
      "Reply": true,
      "Subject": "alice@example.com",
      "PIN": "AAPN-LXJK-LEEA-CI2R-WUC5-3JMK-YF3A"}}}
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
      "MessageId": "NBGE-VEMJ-D7YN-CHEZ-ZF23-TMOO-V6GG",
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


