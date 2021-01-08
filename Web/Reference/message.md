

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
      "MessageId": "NCLC-ADGK-TTIO-M3QU-MBRU-ZMFR-4CA5",
      "Sender": "bob@example.com",
      "Recipient": "alice@example.com",
      "AuthenticatedData": [{
          "dig": "S512",
          "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjEtMDEtMDdUMTc6NTE6NDFaIn0"},
        "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTURCNC1BUFVOLVpMTTctRU02Wi1QW
  ERFLUNRSjUtQkRCVSIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJib2JAZXhhbXBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWN
  jb3VudCI6IFt7CiAgICAgICAgICAgICJFbnZlbG9wZUlEIjogIk1EQjQtQVBVT
  i1aTE03LUVNNlotUFhERS1DUUo1LUJEQlUiLAogICAgICAgICAgICAiZGlnIjo
  gIlM1MTIiLAogICAgICAgICAgICAiQ29udGVudE1ldGFEYXRhIjogImV3b2dJQ
  0pWYm1seGRXVkpaQ0k2SUNKTlJFSTBMVUZRVlU0dFdreE5OeTEKICBGVFRaYUx
  WQllSRVV0UTFGS05TMUNSRUpWSWl3S0lDQWlUV1Z6YzJGblpWUjVjR1VpT2lBa
  VVISnZabWxzWgogIFZWelpYSWlMQW9nSUNKamRIa2lPaUFpWVhCd2JHbGpZWFJ
  wYjI0dmJXMXRMMjlpYW1WamRDSXNDaUFnSWtOCiAgeVpXRjBaV1FpT2lBaU1qQ
  XlNUzB3TVMwd04xUXhOem8xTVRvME1Wb2lmUSJ9LAogICAgICAgICAgImV3b2d
  JQ0pRY205bWFXeGxWWE5sY2lJNklIc0tJQ0FnSUNKUWNtOW1hV3gKICBsVTJsb
  mJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxRVFqUXRRVkJWVGk
  xYVRFMDNMVVZOTgogIGxvdFVGaEVSUzFEVVVvMUxVSkVRbFVpTEFvZ0lDQWdJQ
  0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzCiAgS0lDQWdJQ0FnSUNBaVV
  IVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbllpT2lBa
  VIKICBXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSnFjbVY
  xWkU1elNtOXJZbEZpYTBwbWRHRgogIHBNRll0V1d0bU1YUnBZMGsxTUZOaVozQ
  kZVMjluY1hJeVlUTkpjMHN6TFcxaUNpQWdiemhoY1ROMFJqbFlNCiAgVVZWVkd
  OTmJVRXlTMUpOUjFGQkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFFXUmtjbVZ6Y
  3lJNklDSmliMkoKICBBWlhoaGJYQnNaUzVqYjIwaUxBb2dJQ0FnSWxObGNuWnB
  ZMlZWWkdZaU9pQWlUVVJPV1MxS1FqVXlMVlJZTgogIGtRdFJGQkJRUzFaTnpST
  0xUSTBOVTB0VFU1T1RDSXNDaUFnSUNBaVFXTmpiM1Z1ZEVWdVkzSjVjSFJwYjI
  0CiAgaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVTlNWQzAxVEZKS0xVMWFSe
  lV0V1RSV1VTMDJTRkJSTFVoS1YKICBsUXRNbEExVHlJc0NpQWdJQ0FnSUNKUWR
  XSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSgogIFFkV0pzY
  VdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE
  0SWl3S0lDQWdJCiAgQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlZVXh1WkZKaE5qU
  mhkeTFYY0RrNU4wRmlaRGhzYjJ4bVJsbEJVMFUKICB5TW5KdmVtRlVMWGhVV0Z
  oYVNreHRiREJ0ZVVveVF3b2dJRVIyY1cweWFGZHdlak0zU0dOZlFYTlhNMlpVY
  QogIDAxMVFTSjlmWDBzQ2lBZ0lDQWlRV1J0YVc1cGMzUnlZWFJ2Y2xOcFoyNWh
  kSFZ5WlNJNklIc0tJQ0FnSUNBCiAgZ0lsVmtaaUk2SUNKTlFUUkRMVW8yVjBVd
  FZWVlVUeTFIV2tWU0xVcEVOMDR0V1ZkUE1pMVFVMWhOSWl3S0kKICBDQWdJQ0F
  nSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZb
  XhwWTB0bGVVVgogIERSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0l
  rVmtORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkCiAgV0pzYVdNaU9pQWlTRkZFZ
  DJWaFdHVndhR0kyVnpkMFkwdDNVMjB6UTFkWmFWUndUbU10YlZVMVozSndNMmQ
  KICB6WkZGQ2RWQklhSFpNYUhaYU13b2dJRmd6Yld3M1RGWkJSa0ZPVm5CSVYxS
  kpZelJuVkdSSFFTSjlmWDBzQwogIGlBZ0lDQWlRV05qYjNWdWRFRjFkR2hsYm5
  ScFkyRjBhVzl1SWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxCiAgQlJGZ3RUa
  05HTlMxUFdrMVZMVkJhV1RNdFRGVTNXQzAyV2xVMExUTllTRWtpTEFvZ0lDQWd
  JQ0FpVUhWaWIKICBHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQQogIGdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVdEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmliR2xqSWpvZ0luaHdlC
  iAgRVI2UVhVemQwcDNOVjkzWnpKT1VuWnBWbWN0YURWUFYwbEVWamxNTFdkMlN
  GVjVhMDFWVldSSFgwdHllVTQKICB3YzJVS0lDQlBUVFJaT0hSUlFrdDJka3B6W
  W5Fd05UaHpkRGRVVlVFaWZYMTlMQW9nSUNBZ0lrRmpZMjkxYgogIG5SVGFXZHV
  ZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVSlpSUzFOVFVaWkxWR
  lRXa010VTB0CiAgU055MUJVa2xMTFVkQ1NFSXRUbEphTnlJc0NpQWdJQ0FnSUN
  KUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2UKICB3b2dJQ0FnSUNBZ0lDSlFkV
  0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSgo
  gIEZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2dJalZ2WlY5c
  FRtZFNVMjlrZGxoU01WSkZZCiAgMmhzZG5OSFZFWnRUMlZEUVZCcGQycEhXSEU
  1UTFCR1dFWXpTamw1U0ZWUlNVa0tJQ0I2VjNVelNUQm9NbHAKICB2TFUxWkxYZ
  DJVV1ZEVFVzME5FRWlmWDE5ZlgwIiwKICAgICAgICAgIHsKICAgICAgICAgICA
  gInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAgICAgImFsZyI6ICJTNTEyI
  iwKICAgICAgICAgICAgICAgICJraWQiOiAiTURCNC1BUFVOLVpMTTctRU02Wi1
  QWERFLUNRSjUtQkRCVSIsCiAgICAgICAgICAgICAgICAic2lnbmF0dXJlIjogI
  jJVZGxCTXJOLU5LN3FzZzJYRU53dHU1RTA4aEhndzJVZW1NV1ctdW1DYnZzSTd
  BcTUKICBjVVU1RmNnZXVyWTJJcDFQeXU0bElTWUZTZUEzV1FUTlQtOWh2MmZ1U
  UFibXVkVHdqTlVIb09hSVgwVTNJQgogIF9nX29QdFJ4eWExNTA4bTFTeDd4emZ
  MUzY1UnZDMWtoSTF2RzRqak1BIn1dLAogICAgICAgICAgICAiUGF5bG9hZERpZ
  2VzdCI6ICJTdXh2NXlfRTcxckgtdFNRVmFjNEZGRGx3QncwNlJDU3NFQVJycUt
  FU0RBaXoKICA5alBUTmE3TVhEanhvalZJNnRFbmk2WWlPcmE5VHozYjlxTW5Dd
  FFrUSJ9XSwKICAgICAgICAiUHJvdG9jb2xzIjogW3sKICAgICAgICAgICAgIlB
  yb3RvY29sIjogIm1tbSJ9XX1dfX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MBYE-MMFY-QSZC-SKR7-ARIK-GBHB-NRZ7",
              "signature": "rKnffZ4eWsO3Df0ehb3OiuY82xKW3MUIxj2vwQZe0N9DbRTaY
  lS3qoXuRpQhlp_nx6PKWi_meL0AVp5nwK4cy8qY6uG1DhUkJWVSYMapJjda7Sw
  zcW8dh3ZNiLQdYm6GMZtW_VOagThb37rQh9_ONBUA"}],
          "PayloadDigest": "tERoa8G4Ey660O1dWYCU_-l1gnRQPdTo2b6rSyNYUezhL
  ydSKDh8zRXQQSQgcigliraZUvqZFwDFMf7oluY5AA"}],
      "Reply": true,
      "Subject": "alice@example.com",
      "PIN": "ABN7-BSA6-AUMO-VPOW-SF3E-56PV-AL2Q"}}}
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
      "MessageId": "NAUO-GYLA-4NVT-NQCC-CRLZ-DUWK-35XE",
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


