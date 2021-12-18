

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
<cmd>Bob> meshman message contact alice@example.com
<rsp>Envelope ID: MATB-4AMD-PDBP-VKTJ-SNIZ-ZRZB-WWRR
Message ID: NAPF-EUXY-TEQV-J34J-QTFZ-HBJI-GHNM
Response ID: MB5A-R3RP-B2KE-YFC5-U3JU-T5TO-GICN
</div>
~~~~

Specifying the /json option returns a result of type ResultSent:

~~~~
<div="terminal">
<cmd>Bob> meshman message contact alice@example.com /json
<rsp>{
  "ResultSent": {
    "Success": true,
    "Message": {
      "MessageId": "NAPF-EUXY-TEQV-J34J-QTFZ-HBJI-GHNM",
      "Sender": "bob@example.com",
      "Recipient": "alice@example.com",
      "AuthenticatedData": [{
          "dig": "S512",
          "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjEtMTItMThUMDE6NTc6MTNaIn0"},
        "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTUJZWC1KUE9MLTdIMjQtWUwyWi1MT
  0hPLTdNV1YtSUZHRyIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJib2JAZXhhbXBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWN
  jb3VudCI6IFt7CiAgICAgICAgICAgICJFbnZlbG9wZUlkIjogIk1CWVgtSlBPT
  C03SDI0LVlMMlotTE9ITy03TVdWLUlGR0ciLAogICAgICAgICAgICAiZGlnIjo
  gIlM1MTIiLAogICAgICAgICAgICAiQ29udGVudE1ldGFEYXRhIjogImV3b2dJQ
  0pWYm1seGRXVkpaQ0k2SUNKTlFsbFlMVXBRVDB3dE4wZ3lOQzEKICBaVERKYUx
  VeFBTRTh0TjAxWFZpMUpSa2RISWl3S0lDQWlUV1Z6YzJGblpWUjVjR1VpT2lBa
  VVISnZabWxzWgogIFZWelpYSWlMQW9nSUNKamRIa2lPaUFpWVhCd2JHbGpZWFJ
  wYjI0dmJXMXRMMjlpYW1WamRDSXNDaUFnSWtOCiAgeVpXRjBaV1FpT2lBaU1qQ
  XlNUzB4TWkweE9GUXdNVG8xTnpveE0xb2lmUSJ9LAogICAgICAgICAgImV3b2d
  JQ0pRY205bWFXeGxWWE5sY2lJNklIc0tJQ0FnSUNKUWNtOW1hV3gKICBsVTJsb
  mJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxQ1dWZ3RTbEJQVEM
  wM1NESTBMVmxNTQogIGxvdFRFOUlUeTAzVFZkV0xVbEdSMGNpTEFvZ0lDQWdJQ
  0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzCiAgS0lDQWdJQ0FnSUNBaVV
  IVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbllpT2lBa
  VIKICBXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSkhWMnd
  6UzIxTE0yWTRiM1ZIY0ZOZllrZAogIFVVVjlXVUZST1ZXRkNRV1JvU2t0cmIzV
  lJZbk5rTFhkRWRtRmhjVVZUYWtSeENpQWdMVkF0WkRaYU5HbGZVCiAgRE0yVVR
  OSWFEZHpRa1o1TVVOQkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFFXUmtjbVZ6Y
  3lJNklDSmliMkoKICBBWlhoaGJYQnNaUzVqYjIwaUxBb2dJQ0FnSWxObGNuWnB
  ZMlZWWkdZaU9pQWlUVUZYVnkxRU0xUTJMVlExUQogIHpVdFVEZFRVUzFSUkZsR
  0xVcEhSRGN0UzBoSVZTSXNDaUFnSUNBaVJYTmpjbTkzUlc1amNubHdkR2x2Yml
  JCiAgNklIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlFWZzFMVTVHVlRjdFF6UkpTU
  zAwU3pVMUxUY3pUbE10UVU4MVMKICBTMUhOMHRGSWl3S0lDQWdJQ0FnSWxCMVl
  teHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQgogIDFZbXhwW
  TB0bGVVVkRSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0lsZzBORGd
  pTEFvZ0lDQWdJCiAgQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSnJlRkZVZUhwVGVXR
  lBZbmxKYm5KM2VESnpUak0yWlhVMlIzUjBSRzEKICBQUzA1a05rTktNazFrWlV
  4V1VtSlhSbDlrWDJ4MUNpQWdOMTh5ZGtsbWNURnhkVFJtYTB0V1h6ZGFTekF4Y
  wogIDJGQkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFJXNWpjbmx3ZEdsdmJpSTZ
  JSHNLSUNBZ0lDQWdJbFZrWmlJCiAgNklDSk5RMW8wTFRWSE4xZ3RUMWMwUWkxU
  00xVkpMVkpZTWxZdFRWaGFNaTFKVms5Sklpd0tJQ0FnSUNBZ0kKICBsQjFZbXh
  wWTFCaGNtRnRaWFJsY25NaU9pQjdDaUFnSUNBZ0lDQWdJbEIxWW14cFkwdGxlV
  VZEUkVnaU9pQgogIDdDaUFnSUNBZ0lDQWdJQ0FpWTNKMklqb2dJbGcwTkRnaUx
  Bb2dJQ0FnSUNBZ0lDQWdJbEIxWW14cFl5STZJCiAgQ0poY1VKMlZ6WTVZa2RCU
  1VKRVdXcExiSFl3U1Y4elNrdEJaRlF3V1RaMVJtUTRjbmxUYm5OaVIxQnBiVkI
  KICBYT0ZvME5GODBDaUFnU1hSYU9IUTVUamx0VTNOZk1tVTBkMUZJUldoWGJUW
  kJJbjE5ZlN3S0lDQWdJQ0pCWgogIEcxcGJtbHpkSEpoZEc5eVUybG5ibUYwZFh
  KbElqb2dld29nSUNBZ0lDQWlWV1JtSWpvZ0lrMURTMFV0U0ZaCiAgT1dTMVhTV
  kZQTFRWR04xVXRRVFZDUXkxVVVETkVMVlpLUTBvaUxBb2dJQ0FnSUNBaVVIVml
  iR2xqVUdGeVkKICBXMWxkR1Z5Y3lJNklIc0tJQ0FnSUNBZ0lDQWlVSFZpYkdsa
  lMyVjVSVU5FU0NJNklIc0tJQ0FnSUNBZ0lDQQogIGdJQ0pqY25ZaU9pQWlSV1E
  wTkRnaUxBb2dJQ0FnSUNBZ0lDQWdJbEIxWW14cFl5STZJQ0p2UVhodlEwVlJWC
  iAgVXRJUzJWRFdGOHRPR2hYU2tVNVRrMUZYM1JXZWt0S2FtUmlWbHBJV0RKQlR
  XRkRYMnB1WjBKSWVETjNDaUEKICBnWTNScFdVeGFRazh3Y1RSWmRXWmphVXgxY
  1RGVlpHTkJJbjE5ZlN3S0lDQWdJQ0pCWTJOdmRXNTBRWFYwYQogIEdWdWRHbGp
  ZWFJwYjI0aU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVUlVUUzFIUWtJekxWZ
  zFNek10TmxKCiAgUFdpMU9Sa0pSTFZVMldrNHRSRmt6TkNJc0NpQWdJQ0FnSUN
  KUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2UKICB3b2dJQ0FnSUNBZ0lDSlFkV
  0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSgo
  gIFlORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlZekJNWlZwc
  U5Ea3pjMDgxYkRGVVJraHFaCiAgRU5IYm1FNFVXcGpjMFZYVkRaa1lWcG1PSHB
  ET1dJMGIyRXlZVXRSYTJWS2Fnb2dJR052U0dab2RXTTRSMjEKICBLZW1aV1kwO
  VZlRkJPTTNkdlFTSjlmWDBzQ2lBZ0lDQWlRV05qYjNWdWRGTnBaMjVoZEhWeVp
  TSTZJSHNLSQogIENBZ0lDQWdJbFZrWmlJNklDSk5RVTVWTFZaUVYwVXRVVVJUV
  lMxUFJWbzNMVmMyU2s4dFUwaFhUUzFVTXpVCiAgM0lpd0tJQ0FnSUNBZ0lsQjF
  ZbXhwWTFCaGNtRnRaWFJsY25NaU9pQjdDaUFnSUNBZ0lDQWdJbEIxWW14cFkKI
  CAwdGxlVVZEUkVnaU9pQjdDaUFnSUNBZ0lDQWdJQ0FpWTNKMklqb2dJa1ZrTkR
  RNElpd0tJQ0FnSUNBZ0lDQQogIGdJQ0pRZFdKc2FXTWlPaUFpUkdkS1VUTmtTV
  2h3YzA4d1ozWkdlRTVmTjJwNVp6bDBRbHBKTkRWNlpVZGFPCiAgVVF3YUZONVQ
  wc3pUR2hyYlMxeFl6VmFSQW9nSUVGb2JVOXVXRTgxT1Zoc01GWkVia05OVEZkb
  05qUkxRU0oKICA5ZlgxOWZRIiwKICAgICAgICAgIHsKICAgICAgICAgICAgInN
  pZ25hdHVyZXMiOiBbewogICAgICAgICAgICAgICAgImFsZyI6ICJTNTEyIiwKI
  CAgICAgICAgICAgICAgICJraWQiOiAiTUJZWC1KUE9MLTdIMjQtWUwyWi1MT0h
  PLTdNV1YtSUZHRyIsCiAgICAgICAgICAgICAgICAic2lnbmF0dXJlIjogIjhIW
  jZyLUI2eGNhN0kwanFmLTJYa294Z2RBdVNWekRXRkdCcHB2bUFCam1DTHZIbE4
  KICBjQzRhUENHaWZhZGdLNnZmazdRQXpsSF9CZUFsTkRCWnJBS0JfUGxfbGhkc
  Dczb3dNVXlXdEpFZHlqVlZ5NQogIFdIbnEzUEJ2MEM3ZE5XTENwakowNThiWkd
  YV3JKbnRxSVZoLWFfQkFBIn1dLAogICAgICAgICAgICAiUGF5bG9hZERpZ2Vzd
  CI6ICJTOTd6MV9NTU1YOEFoUDNBcVdBNjBDT2o2N0lLTjVDVGNWV3pTTkZsOFV
  wQkYKICAycXdlWGdzN05PRlVTUkZFXzdBSnFJclI4cGJVeF96QWNucHp6Y3I3Q
  SJ9XSwKICAgICAgICAiUHJvdG9jb2xzIjogW3sKICAgICAgICAgICAgIlByb3R
  vY29sIjogIm1tbSJ9XX1dfX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MANU-VPWE-QDSU-OEZ7-W6JO-SHWM-T357",
              "signature": "IGUmx6JTn_bjWdy-YTrKXoapBnBEYLjXycgLYZ-9b_B2R2XwM
  9v4RiAz_oem1tQy5BABrCNmQS4A1qOg_weEcqqQKOnWp6js1G4KWtKvrDvk6Qe
  5z4cD-3G2EOPVW8davcfa836nPoDNB8GTG188dDwA"}],
          "PayloadDigest": "_nlyuja4udsZNtj-9KEyaognDzo4KJ9DYEbu_2B8aAKJw
  tqACPTrqtMKJLxj5RHoTVQGoDfvlOMUWNnDJO4Ntg"}],
      "Reply": true,
      "Subject": "alice@example.com",
      "PIN": "AAPI-4OUO-YUQZ-7SXT-PRM7-KOAM-2EGA"}}}
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
<cmd>Bob> meshman message confirm alice@example.com "Purchase equipment for $6,000?"
<rsp>Envelope ID: MCTO-U5LM-SCZU-GEQ6-VGRE-2VWP-ALZT
Message ID: NAIC-ZEKO-AOAR-2DMY-5B3W-J3MD-LHH4
Response ID: MCS5-G7NX-KTKD-RE6X-7YZX-BIQF-I55E
</div>
~~~~

Specifying the /json option returns a result of type ResultSent:

~~~~
<div="terminal">
<cmd>Bob> meshman message confirm alice@example.com "Purchase equipment for $6,000?" /json
<rsp>{
  "ResultSent": {
    "Success": true,
    "Message": {
      "MessageId": "NAIC-ZEKO-AOAR-2DMY-5B3W-J3MD-LHH4",
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
<cmd>Alice> meshman message pending
<rsp>MessageID: NAPF-EUXY-TEQV-J34J-QTFZ-HBJI-GHNM
        Contact Request::
        MessageID: NAPF-EUXY-TEQV-J34J-QTFZ-HBJI-GHNM
        To: alice@example.com From: bob@example.com
        PIN: AAPI-4OUO-YUQZ-7SXT-PRM7-KOAM-2EGA
MessageID: NDZE-G3GP-G45D-WAOM-SXOH-24EC-JED2
        Group invitation::
        MessageID: NDZE-G3GP-G45D-WAOM-SXOH-24EC-JED2
        To: alice@example.com From: alice@example.com
MessageID: NDLR-BUDO-M7WU-JBTA-W4G2-AAOU-4NJB
        Confirmation Request::
        MessageID: NDLR-BUDO-M7WU-JBTA-W4G2-AAOU-4NJB
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDCL-O2LD-ODCU-MB2I-6EY3-RXRR-OSSK
        Contact Request::
        MessageID: NDCL-O2LD-ODCU-MB2I-6EY3-RXRR-OSSK
        To: alice@example.com From: bob@example.com
        PIN: AB3F-U7X5-Q2PE-ESFS-S2PH-7AGC-TKBA
</div>
~~~~

Specifying the /json option returns a result of type ResultPending:

~~~~
<div="terminal">
<cmd>Alice> meshman message pending /json
<rsp>{
  "ResultPending": {
    "Success": true,
    "Messages": [{
        "MessageId": "NAPF-EUXY-TEQV-J34J-QTFZ-HBJI-GHNM",
        "Sender": "bob@example.com",
        "Recipient": "alice@example.com",
        "AuthenticatedData": [{
            "dig": "S512",
            "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjEtMTItMThUMDE6NTc6MTNaIn0"},
          "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTUJZWC1KUE9MLTdIMjQtWUwyWi1MT
  0hPLTdNV1YtSUZHRyIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJib2JAZXhhbXBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWN
  jb3VudCI6IFt7CiAgICAgICAgICAgICJFbnZlbG9wZUlkIjogIk1CWVgtSlBPT
  C03SDI0LVlMMlotTE9ITy03TVdWLUlGR0ciLAogICAgICAgICAgICAiZGlnIjo
  gIlM1MTIiLAogICAgICAgICAgICAiQ29udGVudE1ldGFEYXRhIjogImV3b2dJQ
  0pWYm1seGRXVkpaQ0k2SUNKTlFsbFlMVXBRVDB3dE4wZ3lOQzEKICBaVERKYUx
  VeFBTRTh0TjAxWFZpMUpSa2RISWl3S0lDQWlUV1Z6YzJGblpWUjVjR1VpT2lBa
  VVISnZabWxzWgogIFZWelpYSWlMQW9nSUNKamRIa2lPaUFpWVhCd2JHbGpZWFJ
  wYjI0dmJXMXRMMjlpYW1WamRDSXNDaUFnSWtOCiAgeVpXRjBaV1FpT2lBaU1qQ
  XlNUzB4TWkweE9GUXdNVG8xTnpveE0xb2lmUSJ9LAogICAgICAgICAgImV3b2d
  JQ0pRY205bWFXeGxWWE5sY2lJNklIc0tJQ0FnSUNKUWNtOW1hV3gKICBsVTJsb
  mJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxQ1dWZ3RTbEJQVEM
  wM1NESTBMVmxNTQogIGxvdFRFOUlUeTAzVFZkV0xVbEdSMGNpTEFvZ0lDQWdJQ
  0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzCiAgS0lDQWdJQ0FnSUNBaVV
  IVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbllpT2lBa
  VIKICBXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSkhWMnd
  6UzIxTE0yWTRiM1ZIY0ZOZllrZAogIFVVVjlXVUZST1ZXRkNRV1JvU2t0cmIzV
  lJZbk5rTFhkRWRtRmhjVVZUYWtSeENpQWdMVkF0WkRaYU5HbGZVCiAgRE0yVVR
  OSWFEZHpRa1o1TVVOQkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFFXUmtjbVZ6Y
  3lJNklDSmliMkoKICBBWlhoaGJYQnNaUzVqYjIwaUxBb2dJQ0FnSWxObGNuWnB
  ZMlZWWkdZaU9pQWlUVUZYVnkxRU0xUTJMVlExUQogIHpVdFVEZFRVUzFSUkZsR
  0xVcEhSRGN0UzBoSVZTSXNDaUFnSUNBaVJYTmpjbTkzUlc1amNubHdkR2x2Yml
  JCiAgNklIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlFWZzFMVTVHVlRjdFF6UkpTU
  zAwU3pVMUxUY3pUbE10UVU4MVMKICBTMUhOMHRGSWl3S0lDQWdJQ0FnSWxCMVl
  teHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQgogIDFZbXhwW
  TB0bGVVVkRSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0lsZzBORGd
  pTEFvZ0lDQWdJCiAgQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSnJlRkZVZUhwVGVXR
  lBZbmxKYm5KM2VESnpUak0yWlhVMlIzUjBSRzEKICBQUzA1a05rTktNazFrWlV
  4V1VtSlhSbDlrWDJ4MUNpQWdOMTh5ZGtsbWNURnhkVFJtYTB0V1h6ZGFTekF4Y
  wogIDJGQkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFJXNWpjbmx3ZEdsdmJpSTZ
  JSHNLSUNBZ0lDQWdJbFZrWmlJCiAgNklDSk5RMW8wTFRWSE4xZ3RUMWMwUWkxU
  00xVkpMVkpZTWxZdFRWaGFNaTFKVms5Sklpd0tJQ0FnSUNBZ0kKICBsQjFZbXh
  wWTFCaGNtRnRaWFJsY25NaU9pQjdDaUFnSUNBZ0lDQWdJbEIxWW14cFkwdGxlV
  VZEUkVnaU9pQgogIDdDaUFnSUNBZ0lDQWdJQ0FpWTNKMklqb2dJbGcwTkRnaUx
  Bb2dJQ0FnSUNBZ0lDQWdJbEIxWW14cFl5STZJCiAgQ0poY1VKMlZ6WTVZa2RCU
  1VKRVdXcExiSFl3U1Y4elNrdEJaRlF3V1RaMVJtUTRjbmxUYm5OaVIxQnBiVkI
  KICBYT0ZvME5GODBDaUFnU1hSYU9IUTVUamx0VTNOZk1tVTBkMUZJUldoWGJUW
  kJJbjE5ZlN3S0lDQWdJQ0pCWgogIEcxcGJtbHpkSEpoZEc5eVUybG5ibUYwZFh
  KbElqb2dld29nSUNBZ0lDQWlWV1JtSWpvZ0lrMURTMFV0U0ZaCiAgT1dTMVhTV
  kZQTFRWR04xVXRRVFZDUXkxVVVETkVMVlpLUTBvaUxBb2dJQ0FnSUNBaVVIVml
  iR2xqVUdGeVkKICBXMWxkR1Z5Y3lJNklIc0tJQ0FnSUNBZ0lDQWlVSFZpYkdsa
  lMyVjVSVU5FU0NJNklIc0tJQ0FnSUNBZ0lDQQogIGdJQ0pqY25ZaU9pQWlSV1E
  wTkRnaUxBb2dJQ0FnSUNBZ0lDQWdJbEIxWW14cFl5STZJQ0p2UVhodlEwVlJWC
  iAgVXRJUzJWRFdGOHRPR2hYU2tVNVRrMUZYM1JXZWt0S2FtUmlWbHBJV0RKQlR
  XRkRYMnB1WjBKSWVETjNDaUEKICBnWTNScFdVeGFRazh3Y1RSWmRXWmphVXgxY
  1RGVlpHTkJJbjE5ZlN3S0lDQWdJQ0pCWTJOdmRXNTBRWFYwYQogIEdWdWRHbGp
  ZWFJwYjI0aU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVUlVUUzFIUWtJekxWZ
  zFNek10TmxKCiAgUFdpMU9Sa0pSTFZVMldrNHRSRmt6TkNJc0NpQWdJQ0FnSUN
  KUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2UKICB3b2dJQ0FnSUNBZ0lDSlFkV
  0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSgo
  gIFlORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlZekJNWlZwc
  U5Ea3pjMDgxYkRGVVJraHFaCiAgRU5IYm1FNFVXcGpjMFZYVkRaa1lWcG1PSHB
  ET1dJMGIyRXlZVXRSYTJWS2Fnb2dJR052U0dab2RXTTRSMjEKICBLZW1aV1kwO
  VZlRkJPTTNkdlFTSjlmWDBzQ2lBZ0lDQWlRV05qYjNWdWRGTnBaMjVoZEhWeVp
  TSTZJSHNLSQogIENBZ0lDQWdJbFZrWmlJNklDSk5RVTVWTFZaUVYwVXRVVVJUV
  lMxUFJWbzNMVmMyU2s4dFUwaFhUUzFVTXpVCiAgM0lpd0tJQ0FnSUNBZ0lsQjF
  ZbXhwWTFCaGNtRnRaWFJsY25NaU9pQjdDaUFnSUNBZ0lDQWdJbEIxWW14cFkKI
  CAwdGxlVVZEUkVnaU9pQjdDaUFnSUNBZ0lDQWdJQ0FpWTNKMklqb2dJa1ZrTkR
  RNElpd0tJQ0FnSUNBZ0lDQQogIGdJQ0pRZFdKc2FXTWlPaUFpUkdkS1VUTmtTV
  2h3YzA4d1ozWkdlRTVmTjJwNVp6bDBRbHBKTkRWNlpVZGFPCiAgVVF3YUZONVQ
  wc3pUR2hyYlMxeFl6VmFSQW9nSUVGb2JVOXVXRTgxT1Zoc01GWkVia05OVEZkb
  05qUkxRU0oKICA5ZlgxOWZRIiwKICAgICAgICAgIHsKICAgICAgICAgICAgInN
  pZ25hdHVyZXMiOiBbewogICAgICAgICAgICAgICAgImFsZyI6ICJTNTEyIiwKI
  CAgICAgICAgICAgICAgICJraWQiOiAiTUJZWC1KUE9MLTdIMjQtWUwyWi1MT0h
  PLTdNV1YtSUZHRyIsCiAgICAgICAgICAgICAgICAic2lnbmF0dXJlIjogIjhIW
  jZyLUI2eGNhN0kwanFmLTJYa294Z2RBdVNWekRXRkdCcHB2bUFCam1DTHZIbE4
  KICBjQzRhUENHaWZhZGdLNnZmazdRQXpsSF9CZUFsTkRCWnJBS0JfUGxfbGhkc
  Dczb3dNVXlXdEpFZHlqVlZ5NQogIFdIbnEzUEJ2MEM3ZE5XTENwakowNThiWkd
  YV3JKbnRxSVZoLWFfQkFBIn1dLAogICAgICAgICAgICAiUGF5bG9hZERpZ2Vzd
  CI6ICJTOTd6MV9NTU1YOEFoUDNBcVdBNjBDT2o2N0lLTjVDVGNWV3pTTkZsOFV
  wQkYKICAycXdlWGdzN05PRlVTUkZFXzdBSnFJclI4cGJVeF96QWNucHp6Y3I3Q
  SJ9XSwKICAgICAgICAiUHJvdG9jb2xzIjogW3sKICAgICAgICAgICAgIlByb3R
  vY29sIjogIm1tbSJ9XX1dfX0",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MANU-VPWE-QDSU-OEZ7-W6JO-SHWM-T357",
                "signature": "IGUmx6JTn_bjWdy-YTrKXoapBnBEYLjXycgLYZ-9b_B2R2XwM
  9v4RiAz_oem1tQy5BABrCNmQS4A1qOg_weEcqqQKOnWp6js1G4KWtKvrDvk6Qe
  5z4cD-3G2EOPVW8davcfa836nPoDNB8GTG188dDwA"}],
            "PayloadDigest": "_nlyuja4udsZNtj-9KEyaognDzo4KJ9DYEbu_2B8aAKJw
  tqACPTrqtMKJLxj5RHoTVQGoDfvlOMUWNnDJO4Ntg"}],
        "Reply": true,
        "Subject": "alice@example.com",
        "PIN": "AAPI-4OUO-YUQZ-7SXT-PRM7-KOAM-2EGA"},
      {
        "MessageId": "NDZE-G3GP-G45D-WAOM-SXOH-24EC-JED2",
        "Sender": "alice@example.com",
        "Recipient": "alice@example.com",
        "Contact": {
          "ContactPerson": {
            "Anchors": [{
                "Udf": "MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK",
                "Validation": "Self"}],
            "NetworkAddresses": [{
                "Address": "groupw@example.com",
                "EnvelopedProfileAccount": [{
                    "EnvelopeId": "MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK",
                    "dig": "S512",
                    "ContentMetaData": "ewogICJVbmlxdWVJZCI6ICJNQ0lHLTU3RzQtQ0tNRy1
  TTFc1LUk3NUktTFFOQy1KNU1LIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Udyb3VwIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJ
  DcmVhdGVkIjogIjIwMjEtMTItMThUMDE6NTc6MjBaIn0"},
                  "ewogICJQcm9maWxlR3JvdXAiOiB7CiAgICAiUHJvZml
  sZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQ0lHLTU3RzQtQ0tNRy1TT
  Fc1LUk3NUktTFFOQy1KNU1LIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB
  7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAidE9fdG5EQUwwaFhuYllzRUp
  VeGRXSmhDMnlpM3p1UEd1cHdOX2EyczdxdXlGWFJCNFFKSgogIC1rX1JQMGpsb
  jN4a1RVRXYxb3hfT0hTQSJ9fX0sCiAgICAiQWNjb3VudEFkZHJlc3MiOiAiZ3J
  vdXB3QGV4YW1wbGUuY29tIiwKICAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogI
  CAgICAiVWRmIjogIk1DVVItM0NWNS0yQURLLU00Q0ktTlIzNS1MVUtSLVI2WE4
  iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS
  2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICA
  iUHVibGljIjogIlg1YVE0cnUxdDVwYmJzRnZUUk1HcHRPNnhma1NGMmpCQTNlX
  3h5MlVQTWQzZGRrb21pSUEKICBHTmQtb2V6XzltemFBLVFyVkpkSkR4aUEifX1
  9LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1DU
  UktWFBQTS1WSkJULTc0Sk4tTElZUC1WMjM2LUZSRjUiLAogICAgICAiUHVibGl
  jUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgI
  CAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIk56RXh
  yQ0kydkxCX2lBS1ROc2o5Mlh4S0p6eWo1RHdlemxhWXpYa3NKM0txdlRmdlJQW
  FMKICA4bi15Z0RDVS1ZbUxEX3RCT2hpb1A4S0EifX19LAogICAgIkFkbWluaXN
  0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTUFLQS1TSlJBLVBIU
  VMtNVVQVS1WQVpVLVZTT04tV0JCSyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJ
  zIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNyd
  iI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogInJBZXZ6QmRCckJPWlh
  qak5xZm5jQmk0VnMzQmVJYndfZ19wQWh5QWVDU05scldFYjEwRTkKICByRU9QU
  0U5bEVWblNxX1VIUDhlR19jSUEifX19LAogICAgIkFjY291bnRBdXRoZW50aWN
  hdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQlA1LUFZTEYtUlRKWi1MU0NBLURBS
  jctTlRXSy1DSk1RIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICA
  gICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiL
  AogICAgICAgICAgIlB1YmxpYyI6ICJkNHFMNEw1clRkYVJKSHRmQkEwNUJrRV9
  kZUltdmZjdVloaWNCQkRMZFFRUjhQTlR3S3JWCiAgV2VobTRsY0VhdzkxRzdRN
  Ep3TUlWTVlBIn19fX19",
                  {
                    "signatures": [{
                        "alg": "S512",
                        "kid": "MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK",
                        "signature": "yiQMt6_MA6j8G7vQiq0mXxsOcTbMKceC1pVsc_pLHMlLJLeaQ
  XXy6A6_QzMypouXz4m09k4F3BsALKreWlbiQAkIsVNFeY7G-TMohm62rCV_A70
  YvWBdvZ8mq08cA4Odw9IeTFGpGaz0ms3i3E6vCi0A"}],
                    "PayloadDigest": "SI0VsUFAZLyvrLozaZnoFIaV_RLvhf00kWzyll6HcHuSd
  T1xtGKIAeEIXaxHBQGKwrjTdYxmcsrkKnzrerP69Q"}],
                "Protocols": [{
                    "Protocol": "mmm"}],
                "Capabilities": [{
                    "CapabilityDecryptPartial": {
                      "Id": "MCQI-XPPM-VJBT-74JN-LIYP-V236-FRF5",
                      "EnvelopedKeyShare": [{
                          "enc": "A256CBC",
                          "kid": "EBQO-7AOI-N55R-6UKK-SWCO-XUOG-TZSQ",
                          "Salt": "esu9P2aCoEvV8Qq0R8SWjQ",
                          "recipients": [{
                              "kid": "MDNM-PZRG-WN5F-2GW4-QSH6-XEY2-BEHC",
                              "epk": {
                                "PublicKeyECDH": {
                                  "crv": "X448",
                                  "Public": "P9Bh0BN_e3YoiDseDL32EGbSp_olTipvgzE72Hlr9kwOyu4UKW6o
  ZsQk2Dz5j_R-ippvQdjn6GqA"}},
                              "wmk": "kjwm7cuvmyNYy7b1WCjx0R5lK_FI33AgGRxbIiIBIWURpMHwlpvmOA"}],
                          "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYXRhIiwKICA
  iY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGVkIjogI
  jIwMjEtMTItMThUMDE6NTc6MjBaIn0"},
                        "3CoPlzCfFQtG-mUN21ZlgZsjt3GkaAM-9F9K4Ip6WGY
  rkoFWGa0-3wNEm2FMwzh21QLIsIiGp--7g2h0ldb_jPIDq7x_qGEeVUEhLMEMY
  jZuE1uA7mDfoQl3ob-GD-v-s3_izTPQxeQPjh4zmOoC_WU5rgOGJdp34z3UkLW
  VuBkenbZ-VGMFV8Bb_U5dJhLmEB6Dvto8P50jbIGl8hB7dN4cHcuNVLGZ-Kq1u
  WAMjE72h3tauFt1-WKzR4Yr3cmKaMFX3t3cz_L_xOQwg7OQT3WErb6jQmBTMVu
  up8fpGv5HArnUd9Pqy01wZsMf0RkaQ_d7-Oip3dnpa35I7R4dZwb4MjiQ_vHfT
  ro7yTC1uiEXNb2JgOxmgjBMbtpclsNo0l7X5an6HYTFzwt3XoKVTYAzOgFvniL
  gfOU1N4pCEuKT_M_hEd9VQ6DIl0GXyP1rfVXTI2FpOuC8IHXYUEAxY1Ae4QU4-
  7ST-2CwwyvC_rGJhbZr7Q76oi6NVLv_bEi4DyqGtz2EnJx3iG_jEbtjFmh4dk6
  oxJ710q_IXGtfNlDkW-cvPYmJe6L7fD7noqwrrcxPwMhX4Me5t4Cd4bTyHx2oO
  F4UmXGzCDMkZmmHMWuwSmZomDb58fGTkMWENHkFIUyF5oOIYvpZh876yHRx0uE
  shOQei1G14pRhAZaq2QyWPiGJbhZrJex0aAf5seMmBaAO9q-1gwnZkED-MtAiU
  g"]}}]}]}}},
      {
        "MessageId": "NDLR-BUDO-M7WU-JBTA-W4G2-AAOU-4NJB",
        "Sender": "console@example.com",
        "Recipient": "alice@example.com",
        "Text": "start"},
      {
        "MessageId": "NDCL-O2LD-ODCU-MB2I-6EY3-RXRR-OSSK",
        "Sender": "bob@example.com",
        "Recipient": "alice@example.com",
        "AuthenticatedData": [{
            "dig": "S512",
            "ContentMetaData": "ewogICJNZXNzYWdlVHlwZSI6ICJDb250YWN0UGVyc29
  uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhd
  GVkIjogIjIwMjEtMTItMThUMDE6NTc6MTNaIn0"},
          "ewogICJDb250YWN0UGVyc29uIjogewogICAgIkFuY2h
  vcnMiOiBbewogICAgICAgICJVZGYiOiAiTUJZWC1KUE9MLTdIMjQtWUwyWi1MT
  0hPLTdNV1YtSUZHRyIsCiAgICAgICAgIlZhbGlkYXRpb24iOiAiU2VsZiJ9XSw
  KICAgICJOZXR3b3JrQWRkcmVzc2VzIjogW3sKICAgICAgICAiQWRkcmVzcyI6I
  CJib2JAZXhhbXBsZS5jb20iLAogICAgICAgICJFbnZlbG9wZWRQcm9maWxlQWN
  jb3VudCI6IFt7CiAgICAgICAgICAgICJFbnZlbG9wZUlkIjogIk1CWVgtSlBPT
  C03SDI0LVlMMlotTE9ITy03TVdWLUlGR0ciLAogICAgICAgICAgICAiZGlnIjo
  gIlM1MTIiLAogICAgICAgICAgICAiQ29udGVudE1ldGFEYXRhIjogImV3b2dJQ
  0pWYm1seGRXVkpaQ0k2SUNKTlFsbFlMVXBRVDB3dE4wZ3lOQzEKICBaVERKYUx
  VeFBTRTh0TjAxWFZpMUpSa2RISWl3S0lDQWlUV1Z6YzJGblpWUjVjR1VpT2lBa
  VVISnZabWxzWgogIFZWelpYSWlMQW9nSUNKamRIa2lPaUFpWVhCd2JHbGpZWFJ
  wYjI0dmJXMXRMMjlpYW1WamRDSXNDaUFnSWtOCiAgeVpXRjBaV1FpT2lBaU1qQ
  XlNUzB4TWkweE9GUXdNVG8xTnpveE0xb2lmUSJ9LAogICAgICAgICAgImV3b2d
  JQ0pRY205bWFXeGxWWE5sY2lJNklIc0tJQ0FnSUNKUWNtOW1hV3gKICBsVTJsb
  mJtRjBkWEpsSWpvZ2V3b2dJQ0FnSUNBaVZXUm1Jam9nSWsxQ1dWZ3RTbEJQVEM
  wM1NESTBMVmxNTQogIGxvdFRFOUlUeTAzVFZkV0xVbEdSMGNpTEFvZ0lDQWdJQ
  0FpVUhWaWJHbGpVR0Z5WVcxbGRHVnljeUk2SUhzCiAgS0lDQWdJQ0FnSUNBaVV
  IVmliR2xqUzJWNVJVTkVTQ0k2SUhzS0lDQWdJQ0FnSUNBZ0lDSmpjbllpT2lBa
  VIKICBXUTBORGdpTEFvZ0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSkhWMnd
  6UzIxTE0yWTRiM1ZIY0ZOZllrZAogIFVVVjlXVUZST1ZXRkNRV1JvU2t0cmIzV
  lJZbk5rTFhkRWRtRmhjVVZUYWtSeENpQWdMVkF0WkRaYU5HbGZVCiAgRE0yVVR
  OSWFEZHpRa1o1TVVOQkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFFXUmtjbVZ6Y
  3lJNklDSmliMkoKICBBWlhoaGJYQnNaUzVqYjIwaUxBb2dJQ0FnSWxObGNuWnB
  ZMlZWWkdZaU9pQWlUVUZYVnkxRU0xUTJMVlExUQogIHpVdFVEZFRVUzFSUkZsR
  0xVcEhSRGN0UzBoSVZTSXNDaUFnSUNBaVJYTmpjbTkzUlc1amNubHdkR2x2Yml
  JCiAgNklIc0tJQ0FnSUNBZ0lsVmtaaUk2SUNKTlFWZzFMVTVHVlRjdFF6UkpTU
  zAwU3pVMUxUY3pUbE10UVU4MVMKICBTMUhOMHRGSWl3S0lDQWdJQ0FnSWxCMVl
  teHBZMUJoY21GdFpYUmxjbk1pT2lCN0NpQWdJQ0FnSUNBZ0lsQgogIDFZbXhwW
  TB0bGVVVkRSRWdpT2lCN0NpQWdJQ0FnSUNBZ0lDQWlZM0oySWpvZ0lsZzBORGd
  pTEFvZ0lDQWdJCiAgQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSnJlRkZVZUhwVGVXR
  lBZbmxKYm5KM2VESnpUak0yWlhVMlIzUjBSRzEKICBQUzA1a05rTktNazFrWlV
  4V1VtSlhSbDlrWDJ4MUNpQWdOMTh5ZGtsbWNURnhkVFJtYTB0V1h6ZGFTekF4Y
  wogIDJGQkluMTlmU3dLSUNBZ0lDSkJZMk52ZFc1MFJXNWpjbmx3ZEdsdmJpSTZ
  JSHNLSUNBZ0lDQWdJbFZrWmlJCiAgNklDSk5RMW8wTFRWSE4xZ3RUMWMwUWkxU
  00xVkpMVkpZTWxZdFRWaGFNaTFKVms5Sklpd0tJQ0FnSUNBZ0kKICBsQjFZbXh
  wWTFCaGNtRnRaWFJsY25NaU9pQjdDaUFnSUNBZ0lDQWdJbEIxWW14cFkwdGxlV
  VZEUkVnaU9pQgogIDdDaUFnSUNBZ0lDQWdJQ0FpWTNKMklqb2dJbGcwTkRnaUx
  Bb2dJQ0FnSUNBZ0lDQWdJbEIxWW14cFl5STZJCiAgQ0poY1VKMlZ6WTVZa2RCU
  1VKRVdXcExiSFl3U1Y4elNrdEJaRlF3V1RaMVJtUTRjbmxUYm5OaVIxQnBiVkI
  KICBYT0ZvME5GODBDaUFnU1hSYU9IUTVUamx0VTNOZk1tVTBkMUZJUldoWGJUW
  kJJbjE5ZlN3S0lDQWdJQ0pCWgogIEcxcGJtbHpkSEpoZEc5eVUybG5ibUYwZFh
  KbElqb2dld29nSUNBZ0lDQWlWV1JtSWpvZ0lrMURTMFV0U0ZaCiAgT1dTMVhTV
  kZQTFRWR04xVXRRVFZDUXkxVVVETkVMVlpLUTBvaUxBb2dJQ0FnSUNBaVVIVml
  iR2xqVUdGeVkKICBXMWxkR1Z5Y3lJNklIc0tJQ0FnSUNBZ0lDQWlVSFZpYkdsa
  lMyVjVSVU5FU0NJNklIc0tJQ0FnSUNBZ0lDQQogIGdJQ0pqY25ZaU9pQWlSV1E
  wTkRnaUxBb2dJQ0FnSUNBZ0lDQWdJbEIxWW14cFl5STZJQ0p2UVhodlEwVlJWC
  iAgVXRJUzJWRFdGOHRPR2hYU2tVNVRrMUZYM1JXZWt0S2FtUmlWbHBJV0RKQlR
  XRkRYMnB1WjBKSWVETjNDaUEKICBnWTNScFdVeGFRazh3Y1RSWmRXWmphVXgxY
  1RGVlpHTkJJbjE5ZlN3S0lDQWdJQ0pCWTJOdmRXNTBRWFYwYQogIEdWdWRHbGp
  ZWFJwYjI0aU9pQjdDaUFnSUNBZ0lDSlZaR1lpT2lBaVRVUlVUUzFIUWtJekxWZ
  zFNek10TmxKCiAgUFdpMU9Sa0pSTFZVMldrNHRSRmt6TkNJc0NpQWdJQ0FnSUN
  KUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2UKICB3b2dJQ0FnSUNBZ0lDSlFkV
  0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSgo
  gIFlORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlFkV0pzYVdNaU9pQWlZekJNWlZwc
  U5Ea3pjMDgxYkRGVVJraHFaCiAgRU5IYm1FNFVXcGpjMFZYVkRaa1lWcG1PSHB
  ET1dJMGIyRXlZVXRSYTJWS2Fnb2dJR052U0dab2RXTTRSMjEKICBLZW1aV1kwO
  VZlRkJPTTNkdlFTSjlmWDBzQ2lBZ0lDQWlRV05qYjNWdWRGTnBaMjVoZEhWeVp
  TSTZJSHNLSQogIENBZ0lDQWdJbFZrWmlJNklDSk5RVTVWTFZaUVYwVXRVVVJUV
  lMxUFJWbzNMVmMyU2s4dFUwaFhUUzFVTXpVCiAgM0lpd0tJQ0FnSUNBZ0lsQjF
  ZbXhwWTFCaGNtRnRaWFJsY25NaU9pQjdDaUFnSUNBZ0lDQWdJbEIxWW14cFkKI
  CAwdGxlVVZEUkVnaU9pQjdDaUFnSUNBZ0lDQWdJQ0FpWTNKMklqb2dJa1ZrTkR
  RNElpd0tJQ0FnSUNBZ0lDQQogIGdJQ0pRZFdKc2FXTWlPaUFpUkdkS1VUTmtTV
  2h3YzA4d1ozWkdlRTVmTjJwNVp6bDBRbHBKTkRWNlpVZGFPCiAgVVF3YUZONVQ
  wc3pUR2hyYlMxeFl6VmFSQW9nSUVGb2JVOXVXRTgxT1Zoc01GWkVia05OVEZkb
  05qUkxRU0oKICA5ZlgxOWZRIiwKICAgICAgICAgIHsKICAgICAgICAgICAgInN
  pZ25hdHVyZXMiOiBbewogICAgICAgICAgICAgICAgImFsZyI6ICJTNTEyIiwKI
  CAgICAgICAgICAgICAgICJraWQiOiAiTUJZWC1KUE9MLTdIMjQtWUwyWi1MT0h
  PLTdNV1YtSUZHRyIsCiAgICAgICAgICAgICAgICAic2lnbmF0dXJlIjogIjhIW
  jZyLUI2eGNhN0kwanFmLTJYa294Z2RBdVNWekRXRkdCcHB2bUFCam1DTHZIbE4
  KICBjQzRhUENHaWZhZGdLNnZmazdRQXpsSF9CZUFsTkRCWnJBS0JfUGxfbGhkc
  Dczb3dNVXlXdEpFZHlqVlZ5NQogIFdIbnEzUEJ2MEM3ZE5XTENwakowNThiWkd
  YV3JKbnRxSVZoLWFfQkFBIn1dLAogICAgICAgICAgICAiUGF5bG9hZERpZ2Vzd
  CI6ICJTOTd6MV9NTU1YOEFoUDNBcVdBNjBDT2o2N0lLTjVDVGNWV3pTTkZsOFV
  wQkYKICAycXdlWGdzN05PRlVTUkZFXzdBSnFJclI4cGJVeF96QWNucHp6Y3I3Q
  SJ9XSwKICAgICAgICAiUHJvdG9jb2xzIjogW3sKICAgICAgICAgICAgIlByb3R
  vY29sIjogIm1tbSJ9XX1dfX0",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MANU-VPWE-QDSU-OEZ7-W6JO-SHWM-T357",
                "signature": "IGUmx6JTn_bjWdy-YTrKXoapBnBEYLjXycgLYZ-9b_B2R2XwM
  9v4RiAz_oem1tQy5BABrCNmQS4A1qOg_weEcqqQKOnWp6js1G4KWtKvrDvk6Qe
  5z4cD-3G2EOPVW8davcfa836nPoDNB8GTG188dDwA"}],
            "PayloadDigest": "_nlyuja4udsZNtj-9KEyaognDzo4KJ9DYEbu_2B8aAKJw
  tqACPTrqtMKJLxj5RHoTVQGoDfvlOMUWNnDJO4Ntg"}],
        "Reply": true,
        "Subject": "alice@example.com",
        "PIN": "AB3F-U7X5-Q2PE-ESFS-S2PH-7AGC-TKBA"}]}}
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
<cmd>Bob> meshman message status tbs
<rsp>Pending
</div>
~~~~

Specifying the /json option returns a result of type ResultReceived:

~~~~
<div="terminal">
<cmd>Bob> meshman message status tbs /json
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
<cmd>Alice> meshman message accept tbs
<rsp>ERROR - The specified message could not be found.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> meshman message accept tbs /json
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
<cmd>Alice> meshman message reject tbs
<rsp>ERROR - The specified message could not be found.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> meshman message reject tbs /json
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
<cmd>Alice> meshman message block mallet@example.com
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultSent:

~~~~
<div="terminal">
<cmd>Alice> meshman message block mallet@example.com /json
<rsp>{
  "ResultSent": {
    "Success": true}}
</div>
~~~~


