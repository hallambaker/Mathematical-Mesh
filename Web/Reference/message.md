

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
      "MessageId": "NCAR-PVBH-FMFN-NK5Y-SOLP-6WOV-VO6S",
      "Sender": "bob@example.com",
      "Recipient": "alice@example.com",
      "AuthenticatedData": [{
          "dig": "S512",
          "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjAtMTEtMDNUMDE6NTA6NDJaIn0"},
        "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTUNZVS1JTzJGLUpGRkItM0xDTi1VV
  VJELUFJNVUtNllJSiIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJib2JAZXhhbXBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWN
  jb3VudCI6IFt7CiAgICAgICAgICAgICJFbnZlbG9wZUlEIjogIk1DWVUtSU8yR
  i1KRkZCLTNMQ04tVVVSRC1BSTVVLTZZSUoiLAogICAgICAgICAgICAiZGlnIjo
  gIlM1MTIiLAogICAgICAgICAgICAiQ29udGVudE1ldGFEYXRhIjogImV3b2dJQ
  0pWYm1seGRXVkpSQ0k2SUNKTlExbFZMVWxQTWtZdFNrWkdRaTAKICB6VEVOT0x
  WVlZVa1F0UVVrMVZTMDJXVWxLSWl3S0lDQWlUV1Z6YzJGblpWUjVjR1VpT2lBa
  VVISnZabWxzWgogIFZWelpYSWlMQW9nSUNKamRIa2lPaUFpWVhCd2JHbGpZWFJ
  wYjI0dmJXMXRMMjlpYW1WamRDSXNDaUFnSWtOCiAgeVpXRjBaV1FpT2lBaU1qQ
  XlNQzB4TVMwd00xUXdNVG8xTURvME1sb2lmUSJ9LAogICAgICAgICAgImV3b2d
  JQ0pRY205bWFXeGxWWE5sY2lJNklIc0tJQ0FnSUNKUWNtOW1hV3gKICBsVTJsb
  mJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxRFdWVXRTVTh5Umk
  xS1JrWkNMVE5NUQogIDA0dFZWVlNSQzFCU1RWVkxUWlpTVW9pTEFvZ0lDQWdJQ
  0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzCiAgS0lDQWdJQ0FnSUNBaVV
  IVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbllpT2lBa
  VIKICBXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSjJVbGR
  vYlhOTFJGcEVWV0poWlZKbFNVTgogIExjWEIzUzFReFNHWnhTSGszTWxWNFJFd
  DZaMVpzVG5sTk4zWkxkalphWVVkVUNpQWdhVkZzTW1OSFVtTTBUCiAgbkJKUkd
  Sek1tVkphbXBOYUZGQkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFFXUmtjbVZ6Y
  3lJNklDSmliMkoKICBBWlhoaGJYQnNaUzVqYjIwaUxBb2dJQ0FnSWxObGNuWnB
  ZMlZWWkdZaU9pQWlUVVJSVHkxU05qWktMVTFXUgogIFU4dFFrUk1OaTFXTmxRM
  0xVWlFTVWt0VlRReVVTSXNDaUFnSUNBaVFXTmpiM1Z1ZEVWdVkzSjVjSFJwYjI
  0CiAgaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVRkdVUzAyU0U5Q0xVeENSR
  lV0V1ZCUVVDMWFWRnBDTFRJMVUKICBWTXRWVWhKVHlJc0NpQWdJQ0FnSUNKUWR
  XSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSgogIFFkV0pzY
  VdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE
  0SWl3S0lDQWdJCiAgQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlZbVJGVlZJd1NXa
  EZiMWRWYTBKeWRIQllXazFYWDI1dFdYZGxTbmgKICBsVlRoMFQwTkViVVpxTVd
  aclpHNXRNbTVvWm5CR1V3b2dJRmhOY0RVME9HOWxTV3RRYUhreFJDMXBjbmx6U
  wogIFdsSFFTSjlmWDBzQ2lBZ0lDQWlRV1J0YVc1cGMzUnlZWFJ2Y2xOcFoyNWh
  kSFZ5WlNJNklIc0tJQ0FnSUNBCiAgZ0lsVmtaaUk2SUNKTlExbFZMVWxQTWtZd
  FNrWkdRaTB6VEVOT0xWVlZVa1F0UVVrMVZTMDJXVWxLSWl3S0kKICBDQWdJQ0F
  nSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZb
  XhwWTB0bGVVVgogIERSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0l
  rVmtORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkCiAgV0pzYVdNaU9pQWlkbEpYY
  UcxelMwUmFSRlZpWVdWU1pVbERTM0Z3ZDB0VU1VaG1jVWg1TnpKVmVFUkxlbWQ
  KICBXYkU1NVRUZDJTM1kyV21GSFZBb2dJR2xSYkRKalIxSmpORTV3U1VSa2N6S
  mxTV3BxVFdoUlFTSjlmWDBzQwogIGlBZ0lDQWlRV05qYjNWdWRFRjFkR2hsYm5
  ScFkyRjBhVzl1SWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxCiAgQlZsY3RNa
  lZXVEMxT1dVcEpMVFZEUXpNdFZGQk5XaTFETlZaR0xWUkJOa1lpTEFvZ0lDQWd
  JQ0FpVUhWaWIKICBHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQQogIGdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVdEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmliR2xqSWpvZ0ltVTNVC
  iAgamxpVGxwQ1VuZHNlamxSU0RSWmEwRjVibVJUVkVwWFRYVk9kSE41YVhWc2F
  FaDNVMGh1VERKUFFYSkhkMlIKICB2ZGxJS0lDQlBUVEJ6UlUxWFFVYzNRa0pRV
  UVKSFNEbFdZV1Y1YVVFaWZYMTlMQW9nSUNBZ0lrRmpZMjkxYgogIG5SVGFXZHV
  ZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVRTBWeTFUTTFWV0xVS
  TNVMVV0VUVwCiAgR1FTMVhVRW8yTFRWRFVGTXRNekpETnlJc0NpQWdJQ0FnSUN
  KUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2UKICB3b2dJQ0FnSUNBZ0lDSlFkV
  0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSgo
  gIEZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2dJa2wwWTE4M
  U4wNTZSREZyYVZoWlozbFZYCiAgM2M1Y0dGQk1YaHpkRTh3VWpjdFlubDBaa3R
  GWjNBeFZHbEZURk5wUmxaNGVXa0tJQ0JuZEhFeVV6a3lVazEKICBJVmpRMFZFd
  DZiR3R3WDNSM1FVRWlmWDE5ZlgwIiwKICAgICAgICAgIHsKICAgICAgICAgICA
  gInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAgICAgImFsZyI6ICJTNTEyI
  iwKICAgICAgICAgICAgICAgICJraWQiOiAiTUNZVS1JTzJGLUpGRkItM0xDTi1
  VVVJELUFJNVUtNllJSiIsCiAgICAgICAgICAgICAgICAic2lnbmF0dXJlIjogI
  m1uWlZieTQ3RHVQdWhRTGR0dTQ1eUxRdllkNGNGM2dVT29UeXI0M0JQS2ptajN
  DSkMKICAwWHNudkcyNDdwcEw3eTVoUGtsVWI0NDRabUFpRGNpUHF6REtkUFZFY
  2VPN2R1cjFTb0Y1bV9Fa3NtSWxmNgogIEtPZlN3aHdpdHJDNXh6V01KTUdJWnd
  Nd2pfbmpSMmdsTGFwMmN5QnNBIn1dLAogICAgICAgICAgICAiUGF5bG9hZERpZ
  2VzdCI6ICJ0UUltenFEdENIZkpRN2sxcTFvZzhQazMzcVNjb3NVNW1hdWppT3A
  0WHNDY2UKICBlNzJHM2M3Qm1BQmVidTRTMnZBaUVwUy15YmtDTUVFeUJkNXJxO
  VpQZyJ9XSwKICAgICAgICAiUHJvdG9jb2xzIjogW3sKICAgICAgICAgICAgIlB
  yb3RvY29sIjogIm1tbSJ9XX1dfX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MA4W-S3UV-B7SU-PJFA-WPJ6-5CPS-32C7",
              "signature": "Q94QMOeb4cGA96lu_PhlVgV3hB5dzXocBETMEZxP9N_X2qHVx
  lxZJqZBkXhdCFtN8pa9EKtYcF2ADNSs9GlkrsuOjXXAp_MLaFDdOYLOWMG22la
  68_nEV1lP9wX8jLOy2_Mhn5rBVISC0XRBFzUR1zMA"}],
          "PayloadDigest": "kDQqkQFFp1vnlyendI8xdpS7k8Ut2zZPj1zZrx5eR7oQW
  3fURoEsautn3fG-DgaQ2Xb-A2ZrZaB87WNsSBW_zA"}],
      "Reply": true,
      "Subject": "alice@example.com",
      "PIN": "AAU2-ZQK6-Z347-NRY6-IOV5-W2P2-O5EQ"}}}
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
      "MessageId": "NBPA-4YJD-P7RN-2SJJ-ZQFO-NIAD-VOEE",
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
<rsp>MessageID: NCAR-PVBH-FMFN-NK5Y-SOLP-6WOV-VO6S
        Contact Request::
        MessageID: NCAR-PVBH-FMFN-NK5Y-SOLP-6WOV-VO6S
        To: alice@example.com From: bob@example.com
        PIN: AAU2-ZQK6-Z347-NRY6-IOV5-W2P2-O5EQ
MessageID: NA3M-FCCF-P67J-CHXN-NUYJ-X267-RCH5
        Confirmation Request::
        MessageID: NA3M-FCCF-P67J-CHXN-NUYJ-X267-RCH5
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NAEZ-UOXO-KBH7-MT7I-KKA2-S37A-RGEZ
        Contact Request::
        MessageID: NAEZ-UOXO-KBH7-MT7I-KKA2-S37A-RGEZ
        To: alice@example.com From: bob@example.com
        PIN: AADZ-27RV-SGJA-5LIO-GHVA-2QPC-ORRA
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
        "MessageId": "NCAR-PVBH-FMFN-NK5Y-SOLP-6WOV-VO6S",
        "Sender": "bob@example.com",
        "Recipient": "alice@example.com",
        "AuthenticatedData": [{
            "dig": "S512",
            "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjAtMTEtMDNUMDE6NTA6NDJaIn0"},
          "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTUNZVS1JTzJGLUpGRkItM0xDTi1VV
  VJELUFJNVUtNllJSiIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJib2JAZXhhbXBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWN
  jb3VudCI6IFt7CiAgICAgICAgICAgICJFbnZlbG9wZUlEIjogIk1DWVUtSU8yR
  i1KRkZCLTNMQ04tVVVSRC1BSTVVLTZZSUoiLAogICAgICAgICAgICAiZGlnIjo
  gIlM1MTIiLAogICAgICAgICAgICAiQ29udGVudE1ldGFEYXRhIjogImV3b2dJQ
  0pWYm1seGRXVkpSQ0k2SUNKTlExbFZMVWxQTWtZdFNrWkdRaTAKICB6VEVOT0x
  WVlZVa1F0UVVrMVZTMDJXVWxLSWl3S0lDQWlUV1Z6YzJGblpWUjVjR1VpT2lBa
  VVISnZabWxzWgogIFZWelpYSWlMQW9nSUNKamRIa2lPaUFpWVhCd2JHbGpZWFJ
  wYjI0dmJXMXRMMjlpYW1WamRDSXNDaUFnSWtOCiAgeVpXRjBaV1FpT2lBaU1qQ
  XlNQzB4TVMwd00xUXdNVG8xTURvME1sb2lmUSJ9LAogICAgICAgICAgImV3b2d
  JQ0pRY205bWFXeGxWWE5sY2lJNklIc0tJQ0FnSUNKUWNtOW1hV3gKICBsVTJsb
  mJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxRFdWVXRTVTh5Umk
  xS1JrWkNMVE5NUQogIDA0dFZWVlNSQzFCU1RWVkxUWlpTVW9pTEFvZ0lDQWdJQ
  0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzCiAgS0lDQWdJQ0FnSUNBaVV
  IVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbllpT2lBa
  VIKICBXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSjJVbGR
  vYlhOTFJGcEVWV0poWlZKbFNVTgogIExjWEIzUzFReFNHWnhTSGszTWxWNFJFd
  DZaMVpzVG5sTk4zWkxkalphWVVkVUNpQWdhVkZzTW1OSFVtTTBUCiAgbkJKUkd
  Sek1tVkphbXBOYUZGQkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFFXUmtjbVZ6Y
  3lJNklDSmliMkoKICBBWlhoaGJYQnNaUzVqYjIwaUxBb2dJQ0FnSWxObGNuWnB
  ZMlZWWkdZaU9pQWlUVVJSVHkxU05qWktMVTFXUgogIFU4dFFrUk1OaTFXTmxRM
  0xVWlFTVWt0VlRReVVTSXNDaUFnSUNBaVFXTmpiM1Z1ZEVWdVkzSjVjSFJwYjI
  0CiAgaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVRkdVUzAyU0U5Q0xVeENSR
  lV0V1ZCUVVDMWFWRnBDTFRJMVUKICBWTXRWVWhKVHlJc0NpQWdJQ0FnSUNKUWR
  XSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSgogIFFkV0pzY
  VdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE
  0SWl3S0lDQWdJCiAgQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlZbVJGVlZJd1NXa
  EZiMWRWYTBKeWRIQllXazFYWDI1dFdYZGxTbmgKICBsVlRoMFQwTkViVVpxTVd
  aclpHNXRNbTVvWm5CR1V3b2dJRmhOY0RVME9HOWxTV3RRYUhreFJDMXBjbmx6U
  wogIFdsSFFTSjlmWDBzQ2lBZ0lDQWlRV1J0YVc1cGMzUnlZWFJ2Y2xOcFoyNWh
  kSFZ5WlNJNklIc0tJQ0FnSUNBCiAgZ0lsVmtaaUk2SUNKTlExbFZMVWxQTWtZd
  FNrWkdRaTB6VEVOT0xWVlZVa1F0UVVrMVZTMDJXVWxLSWl3S0kKICBDQWdJQ0F
  nSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZb
  XhwWTB0bGVVVgogIERSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0l
  rVmtORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkCiAgV0pzYVdNaU9pQWlkbEpYY
  UcxelMwUmFSRlZpWVdWU1pVbERTM0Z3ZDB0VU1VaG1jVWg1TnpKVmVFUkxlbWQ
  KICBXYkU1NVRUZDJTM1kyV21GSFZBb2dJR2xSYkRKalIxSmpORTV3U1VSa2N6S
  mxTV3BxVFdoUlFTSjlmWDBzQwogIGlBZ0lDQWlRV05qYjNWdWRFRjFkR2hsYm5
  ScFkyRjBhVzl1SWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxCiAgQlZsY3RNa
  lZXVEMxT1dVcEpMVFZEUXpNdFZGQk5XaTFETlZaR0xWUkJOa1lpTEFvZ0lDQWd
  JQ0FpVUhWaWIKICBHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQQogIGdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVdEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmliR2xqSWpvZ0ltVTNVC
  iAgamxpVGxwQ1VuZHNlamxSU0RSWmEwRjVibVJUVkVwWFRYVk9kSE41YVhWc2F
  FaDNVMGh1VERKUFFYSkhkMlIKICB2ZGxJS0lDQlBUVEJ6UlUxWFFVYzNRa0pRV
  UVKSFNEbFdZV1Y1YVVFaWZYMTlMQW9nSUNBZ0lrRmpZMjkxYgogIG5SVGFXZHV
  ZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVRTBWeTFUTTFWV0xVS
  TNVMVV0VUVwCiAgR1FTMVhVRW8yTFRWRFVGTXRNekpETnlJc0NpQWdJQ0FnSUN
  KUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2UKICB3b2dJQ0FnSUNBZ0lDSlFkV
  0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSgo
  gIEZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2dJa2wwWTE4M
  U4wNTZSREZyYVZoWlozbFZYCiAgM2M1Y0dGQk1YaHpkRTh3VWpjdFlubDBaa3R
  GWjNBeFZHbEZURk5wUmxaNGVXa0tJQ0JuZEhFeVV6a3lVazEKICBJVmpRMFZFd
  DZiR3R3WDNSM1FVRWlmWDE5ZlgwIiwKICAgICAgICAgIHsKICAgICAgICAgICA
  gInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAgICAgImFsZyI6ICJTNTEyI
  iwKICAgICAgICAgICAgICAgICJraWQiOiAiTUNZVS1JTzJGLUpGRkItM0xDTi1
  VVVJELUFJNVUtNllJSiIsCiAgICAgICAgICAgICAgICAic2lnbmF0dXJlIjogI
  m1uWlZieTQ3RHVQdWhRTGR0dTQ1eUxRdllkNGNGM2dVT29UeXI0M0JQS2ptajN
  DSkMKICAwWHNudkcyNDdwcEw3eTVoUGtsVWI0NDRabUFpRGNpUHF6REtkUFZFY
  2VPN2R1cjFTb0Y1bV9Fa3NtSWxmNgogIEtPZlN3aHdpdHJDNXh6V01KTUdJWnd
  Nd2pfbmpSMmdsTGFwMmN5QnNBIn1dLAogICAgICAgICAgICAiUGF5bG9hZERpZ
  2VzdCI6ICJ0UUltenFEdENIZkpRN2sxcTFvZzhQazMzcVNjb3NVNW1hdWppT3A
  0WHNDY2UKICBlNzJHM2M3Qm1BQmVidTRTMnZBaUVwUy15YmtDTUVFeUJkNXJxO
  VpQZyJ9XSwKICAgICAgICAiUHJvdG9jb2xzIjogW3sKICAgICAgICAgICAgIlB
  yb3RvY29sIjogIm1tbSJ9XX1dfX0",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MA4W-S3UV-B7SU-PJFA-WPJ6-5CPS-32C7",
                "signature": "Q94QMOeb4cGA96lu_PhlVgV3hB5dzXocBETMEZxP9N_X2qHVx
  lxZJqZBkXhdCFtN8pa9EKtYcF2ADNSs9GlkrsuOjXXAp_MLaFDdOYLOWMG22la
  68_nEV1lP9wX8jLOy2_Mhn5rBVISC0XRBFzUR1zMA"}],
            "PayloadDigest": "kDQqkQFFp1vnlyendI8xdpS7k8Ut2zZPj1zZrx5eR7oQW
  3fURoEsautn3fG-DgaQ2Xb-A2ZrZaB87WNsSBW_zA"}],
        "Reply": true,
        "Subject": "alice@example.com",
        "PIN": "AAU2-ZQK6-Z347-NRY6-IOV5-W2P2-O5EQ"},
      {
        "MessageId": "NA3M-FCCF-P67J-CHXN-NUYJ-X267-RCH5",
        "Sender": "console@example.com",
        "Recipient": "alice@example.com",
        "Text": "start"},
      {
        "MessageId": "NAEZ-UOXO-KBH7-MT7I-KKA2-S37A-RGEZ",
        "Sender": "bob@example.com",
        "Recipient": "alice@example.com",
        "AuthenticatedData": [{
            "dig": "S512",
            "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjAtMTEtMDNUMDE6NTA6NDJaIn0"},
          "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTUNZVS1JTzJGLUpGRkItM0xDTi1VV
  VJELUFJNVUtNllJSiIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJib2JAZXhhbXBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWN
  jb3VudCI6IFt7CiAgICAgICAgICAgICJFbnZlbG9wZUlEIjogIk1DWVUtSU8yR
  i1KRkZCLTNMQ04tVVVSRC1BSTVVLTZZSUoiLAogICAgICAgICAgICAiZGlnIjo
  gIlM1MTIiLAogICAgICAgICAgICAiQ29udGVudE1ldGFEYXRhIjogImV3b2dJQ
  0pWYm1seGRXVkpSQ0k2SUNKTlExbFZMVWxQTWtZdFNrWkdRaTAKICB6VEVOT0x
  WVlZVa1F0UVVrMVZTMDJXVWxLSWl3S0lDQWlUV1Z6YzJGblpWUjVjR1VpT2lBa
  VVISnZabWxzWgogIFZWelpYSWlMQW9nSUNKamRIa2lPaUFpWVhCd2JHbGpZWFJ
  wYjI0dmJXMXRMMjlpYW1WamRDSXNDaUFnSWtOCiAgeVpXRjBaV1FpT2lBaU1qQ
  XlNQzB4TVMwd00xUXdNVG8xTURvME1sb2lmUSJ9LAogICAgICAgICAgImV3b2d
  JQ0pRY205bWFXeGxWWE5sY2lJNklIc0tJQ0FnSUNKUWNtOW1hV3gKICBsVTJsb
  mJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxRFdWVXRTVTh5Umk
  xS1JrWkNMVE5NUQogIDA0dFZWVlNSQzFCU1RWVkxUWlpTVW9pTEFvZ0lDQWdJQ
  0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzCiAgS0lDQWdJQ0FnSUNBaVV
  IVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbllpT2lBa
  VIKICBXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSjJVbGR
  vYlhOTFJGcEVWV0poWlZKbFNVTgogIExjWEIzUzFReFNHWnhTSGszTWxWNFJFd
  DZaMVpzVG5sTk4zWkxkalphWVVkVUNpQWdhVkZzTW1OSFVtTTBUCiAgbkJKUkd
  Sek1tVkphbXBOYUZGQkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFFXUmtjbVZ6Y
  3lJNklDSmliMkoKICBBWlhoaGJYQnNaUzVqYjIwaUxBb2dJQ0FnSWxObGNuWnB
  ZMlZWWkdZaU9pQWlUVVJSVHkxU05qWktMVTFXUgogIFU4dFFrUk1OaTFXTmxRM
  0xVWlFTVWt0VlRReVVTSXNDaUFnSUNBaVFXTmpiM1Z1ZEVWdVkzSjVjSFJwYjI
  0CiAgaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVRkdVUzAyU0U5Q0xVeENSR
  lV0V1ZCUVVDMWFWRnBDTFRJMVUKICBWTXRWVWhKVHlJc0NpQWdJQ0FnSUNKUWR
  XSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSgogIFFkV0pzY
  VdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE
  0SWl3S0lDQWdJCiAgQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlZbVJGVlZJd1NXa
  EZiMWRWYTBKeWRIQllXazFYWDI1dFdYZGxTbmgKICBsVlRoMFQwTkViVVpxTVd
  aclpHNXRNbTVvWm5CR1V3b2dJRmhOY0RVME9HOWxTV3RRYUhreFJDMXBjbmx6U
  wogIFdsSFFTSjlmWDBzQ2lBZ0lDQWlRV1J0YVc1cGMzUnlZWFJ2Y2xOcFoyNWh
  kSFZ5WlNJNklIc0tJQ0FnSUNBCiAgZ0lsVmtaaUk2SUNKTlExbFZMVWxQTWtZd
  FNrWkdRaTB6VEVOT0xWVlZVa1F0UVVrMVZTMDJXVWxLSWl3S0kKICBDQWdJQ0F
  nSWxCMVlteHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQjFZb
  XhwWTB0bGVVVgogIERSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0l
  rVmtORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkCiAgV0pzYVdNaU9pQWlkbEpYY
  UcxelMwUmFSRlZpWVdWU1pVbERTM0Z3ZDB0VU1VaG1jVWg1TnpKVmVFUkxlbWQ
  KICBXYkU1NVRUZDJTM1kyV21GSFZBb2dJR2xSYkRKalIxSmpORTV3U1VSa2N6S
  mxTV3BxVFdoUlFTSjlmWDBzQwogIGlBZ0lDQWlRV05qYjNWdWRFRjFkR2hsYm5
  ScFkyRjBhVzl1SWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxCiAgQlZsY3RNa
  lZXVEMxT1dVcEpMVFZEUXpNdFZGQk5XaTFETlZaR0xWUkJOa1lpTEFvZ0lDQWd
  JQ0FpVUhWaWIKICBHbGpVR0Z5WVcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBa
  VVIVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQQogIGdJQ0FnSUNBZ0lDSmpjbll
  pT2lBaVdEUTBPQ0lzQ2lBZ0lDQWdJQ0FnSUNBaVVIVmliR2xqSWpvZ0ltVTNVC
  iAgamxpVGxwQ1VuZHNlamxSU0RSWmEwRjVibVJUVkVwWFRYVk9kSE41YVhWc2F
  FaDNVMGh1VERKUFFYSkhkMlIKICB2ZGxJS0lDQlBUVEJ6UlUxWFFVYzNRa0pRV
  UVKSFNEbFdZV1Y1YVVFaWZYMTlMQW9nSUNBZ0lrRmpZMjkxYgogIG5SVGFXZHV
  ZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVRTBWeTFUTTFWV0xVS
  TNVMVV0VUVwCiAgR1FTMVhVRW8yTFRWRFVGTXRNekpETnlJc0NpQWdJQ0FnSUN
  KUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2UKICB3b2dJQ0FnSUNBZ0lDSlFkV
  0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSgo
  gIEZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2dJa2wwWTE4M
  U4wNTZSREZyYVZoWlozbFZYCiAgM2M1Y0dGQk1YaHpkRTh3VWpjdFlubDBaa3R
  GWjNBeFZHbEZURk5wUmxaNGVXa0tJQ0JuZEhFeVV6a3lVazEKICBJVmpRMFZFd
  DZiR3R3WDNSM1FVRWlmWDE5ZlgwIiwKICAgICAgICAgIHsKICAgICAgICAgICA
  gInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAgICAgImFsZyI6ICJTNTEyI
  iwKICAgICAgICAgICAgICAgICJraWQiOiAiTUNZVS1JTzJGLUpGRkItM0xDTi1
  VVVJELUFJNVUtNllJSiIsCiAgICAgICAgICAgICAgICAic2lnbmF0dXJlIjogI
  m1uWlZieTQ3RHVQdWhRTGR0dTQ1eUxRdllkNGNGM2dVT29UeXI0M0JQS2ptajN
  DSkMKICAwWHNudkcyNDdwcEw3eTVoUGtsVWI0NDRabUFpRGNpUHF6REtkUFZFY
  2VPN2R1cjFTb0Y1bV9Fa3NtSWxmNgogIEtPZlN3aHdpdHJDNXh6V01KTUdJWnd
  Nd2pfbmpSMmdsTGFwMmN5QnNBIn1dLAogICAgICAgICAgICAiUGF5bG9hZERpZ
  2VzdCI6ICJ0UUltenFEdENIZkpRN2sxcTFvZzhQazMzcVNjb3NVNW1hdWppT3A
  0WHNDY2UKICBlNzJHM2M3Qm1BQmVidTRTMnZBaUVwUy15YmtDTUVFeUJkNXJxO
  VpQZyJ9XSwKICAgICAgICAiUHJvdG9jb2xzIjogW3sKICAgICAgICAgICAgIlB
  yb3RvY29sIjogIm1tbSJ9XX1dfX0",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MA4W-S3UV-B7SU-PJFA-WPJ6-5CPS-32C7",
                "signature": "Q94QMOeb4cGA96lu_PhlVgV3hB5dzXocBETMEZxP9N_X2qHVx
  lxZJqZBkXhdCFtN8pa9EKtYcF2ADNSs9GlkrsuOjXXAp_MLaFDdOYLOWMG22la
  68_nEV1lP9wX8jLOy2_Mhn5rBVISC0XRBFzUR1zMA"}],
            "PayloadDigest": "kDQqkQFFp1vnlyendI8xdpS7k8Ut2zZPj1zZrx5eR7oQW
  3fURoEsautn3fG-DgaQ2Xb-A2ZrZaB87WNsSBW_zA"}],
        "Reply": true,
        "Subject": "alice@example.com",
        "PIN": "AADZ-27RV-SGJA-5LIO-GHVA-2QPC-ORRA"}]}}
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


