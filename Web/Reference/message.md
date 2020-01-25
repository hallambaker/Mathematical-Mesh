

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
      "Sender": "bob@example.com",
      "Recipient": "alice@example.com",
      "Reply": true}}}
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
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultPending:

~~~~
<div="terminal">
<cmd>Alice> message pending /json
<rsp>{
  "ResultPending": {
    "Success": true,
    "Messages": [{
        "Sender": "bob@example.com",
        "Recipient": "alice@example.com",
        "Reply": true},
      {
        "MessageID": "NAYY-BSZ6-UP3K-IXCJ-4AST-7NRE-2QW7",
        "EnvelopedRequestConnection": [{
            "dig": "SHA2"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiU0hBMiJ9LAogICAgICAiZXdvZ0l
  DSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWt0bGVVOW1abXhwYm1WV
  GFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZSRVlpT2lBaVRVTlJSUzF
  YV0VrMUxVZEhNbEl0UVVSR1VTMUNSCiAga3RWTFVjM1JVUXRURTlQU2lJc0NpQ
  WdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0EKICBnSUN
  BZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55Z
  GlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2d
  JazR4ZEZjemVFd3dlVU5yUVVwb1lraE9UbDl2VkV3CiAgemN6aDZlVEYxUVZGR
  mRqaEhhM2cwU0d4YWFGOXRhRUZTV0VOZmRURUtJQ0JKVmpod1JETnFNbGsyWWt
  GQmUKICBqRnpkWEY1VjJReVVVRWlmWDE5TEFvZ0lDQWdJa3RsZVVWdVkzSjVjS
  FJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlpT2lBaVRVUTFNeTFSVGxFMkx
  UVk5UMVl0VWtoTFJDMUZVMEpETFV4VE1sVXRRVWROUlNJc0NpQWdJCiAgQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0p
  zYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDS
  kZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYgogIEdsaklqb2dJaTFRUzJ
  od1JVdHJVbm8wVW1SMVpURlNhSEoyVlhkcmVuWTVia0prVjFCWFptcHRVbTFHW
  jJKCiAgQ1prOTFNbU5wU1d4amRqWUtJQ0J2Y0hsNE1YRnliMmw1VlVWMlIydG5
  NMGxLTVY4MGNVRWlmWDE5TEFvZ0kKICBDQWdJa3RsZVVGMWRHaGxiblJwWTJGM
  GFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFCUTFjdFJWTgogIFVUaTF
  UUVZCSUxWZE9SVWt0V0VoS1NDMWFSMFF6TFZaRlJVd2lMQW9nSUNBZ0lDQWlVS
  FZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJ
  HbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKICBnSUNKamNuWWlPaUFpU
  ldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKamFVeGlOVnB
  KUwogIEhWT1lrY3hiM2hTVW5aMFVsWkhXRmN0WlVOVlQxUnJaemhaZERnMWVrW
  jZObG8wUlVSZk9YaEZYM0pRQ2lBCiAgZ04yUlVRM0ZhTmw5RlNGbDRNMlZhWDF
  SUU9FdEJWV2xCSW4xOWZYMTkiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZ
  XMiOiBbewogICAgICAgICAgICAiYWxnIjogIlNIQTIiLAogICAgICAgICAgICA
  ia2lkIjogIk1DUUUtV1hJNS1HRzJSLUFERlEtQkZLVS1HN0VELUxPT0oiLAogI
  CAgICAgICAgICAic2lnbmF0dXJlIjogIlNQT3p6ajhrV3dVWEpfR3Jla0toV2w
  td1NMWDI5WVQ3WjZfY29JZl9ORTdoMDRpVkYKICBzLUdhWnNFd0M5V05iTUlFO
  V9DSDBVcVZPeUEtM1EzYk9JaUc3OXlBQ1JrX0FXRXRjRUJXTUw1NW50UXA3RAo
  gIEtzSlJEZWVJLTNUSnEtaUhhRFhrSlVwRFFlaWZtLU52VDdHSE9XVDBBIn1dL
  AogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIjVIaXlXcXRPWDhqY244c0lRenZ
  rUUJXUmhUUEZ1LXlWREtYLXZDT3BVcnMwRQogIGFkVzZScFdPOTkxakUzU29VO
  Gl1ZjF1MXFSN2w1b2w5WThtNjR6Tjd3In1dLAogICAgIkNsaWVudE5vbmNlIjo
  gIjM5QWFGNmdpdzRieEhoT3RESHlMUlEiLAogICAgIlBpblVERiI6ICJOQ0dEL
  VpPUUwtSlJWRi1UQUxBLUVZIn19",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MACW-ESTN-SAPH-WNEI-XHJH-ZGD3-VEEL",
                "signature": "hVdCRXNMPOT2LNAkJCUCeLxrszykep1oe4PEzrEvPHE47hH3f
  CEC-DV0x_HxCWYkaJb2uih8TbeAUON-xDAOSDJG9eTx1QVXV1Q6ZoK-XnS5d-w
  5xOs5nrAErdULmHViN_J_WdGmfP7ft2acrrsMPC4A"}],
            "PayloadDigest": "mx6uwtJu7XVg4knJjJU1eyq6-L04sesxk-qxBaI4ZP1ic
  yEcNTi-zr_9W2wVhFHB6RHXxYS6u2uiuIvndk_Amw"}],
        "ServerNonce": "0Nu3OOV5YfD94Fu2qkcEsg",
        "Witness": "XNLM-MOF2-KNZS-3HCO-WOEO-BOTN-Y6G2"},
      {
        "MessageID": "NCGP-WWTX-4HDR-YR2I-N5DO-TYBJ-C4X7",
        "EnvelopedRequestConnection": [{
            "dig": "SHA2"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiU0hBMiJ9LAogICAgICAiZXdvZ0l
  DSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWt0bGVVOW1abXhwYm1WV
  GFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZSRVlpT2lBaVRVUllWaTF
  XUzBjMUxWSlpVVWN0VEV3MFFTMVpVCiAgMWxTTFVnMFdGZ3RVak5DUnlJc0NpQ
  WdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0EKICBnSUN
  BZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55Z
  GlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2d
  JbGhVUmpWNWRucG1ZblZDZWpkUVkxVnNWSGMxU0d3CiAgM2NFaEZiVWxqUzFSS
  lpIWkpSbFJNVnpWaVZYSklabkV0UlhoaVNGSUtJQ0JwUjJOWVJ6azJOR2hUVlV
  0Q2IKICBUaERUbHBVTFZaR2NVRWlmWDE5TEFvZ0lDQWdJa3RsZVVWdVkzSjVjS
  FJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlpT2lBaVRVRkNXQzFHVVVvekx
  USlNVRm90Vms5R055MUVXazQyTFRSS04xZ3RWMUZHV2lJc0NpQWdJCiAgQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0p
  zYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDS
  kZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYgogIEdsaklqb2dJazl2YUd
  sUmMxVmtjV2wzY1ZWV1RtbFlSemRuWDFwamVUVmZiV3hSVFVkUlZuQXpYMVZYV
  2psCiAgQ2VGQlpaa1puYlhsSlRHd0tJQ0JDYVZOVlNWOXhjMDAwVEVaUlRrUXh
  PREozWWxkTlkwRWlmWDE5TEFvZ0kKICBDQWdJa3RsZVVGMWRHaGxiblJwWTJGM
  GFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFDTWtRdFJsRgogIEVSUzF
  EU2tnMExVbE1TVE10UVZvelJDMUpOamRDTFZCV05sTWlMQW9nSUNBZ0lDQWlVS
  FZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJ
  HbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKICBnSUNKamNuWWlPaUFpU
  ldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKWExUQlZTVVJ
  ETQogIFhRNWJtaERXRFJZWWkxUWEwWm1ZMVJCWVZScVRrMDBaV2gwTmpOWU1XR
  k5ZVFJpYUhCelRISnVNVFpxQ2lBCiAgZ1kxQkxTMVJrVjJ0clNqUlZaRlIwWlV
  jdE5rTjFiVUZCSW4xOWZYMTkiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZ
  XMiOiBbewogICAgICAgICAgICAiYWxnIjogIlNIQTIiLAogICAgICAgICAgICA
  ia2lkIjogIk1EWFYtVktHNS1SWVFHLUxMNEEtWVNZUi1INFhYLVIzQkciLAogI
  CAgICAgICAgICAic2lnbmF0dXJlIjogIkNObXg5TmQyU2dSN1piYmdHQUtmMlQ
  4d0NyQWpTMkpyeWFqNzd0MDJpMF9hbUNSOWEKICA2clhfMzBPMV9vbWswRGhCU
  zc1YnNITDNXaUFPLUYxUkkxbFYzWTBEdnhzQmF1TEk0ZHZwVWloM1c2Mm1nUgo
  gIE1MamN2WmZlU2FDckNZNUtobTBINXlDSm8tNnpzbWZhMi1uY0dPQllBIn1dL
  AogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIk5mQzZOcHBZQUpVbnNaZ0RTYjV
  hdGRUdXdnejFPWklZSGRXcGJsWHF0ZDh0bAogIGptTERkdGs4YTluR3E5dTdTa
  lAwVDgxem5BR2ZFbTdKX2pqTVBzakJBIn1dLAogICAgIkNsaWVudE5vbmNlIjo
  gIm1oUlgwR0plTjVxZlFtMjg1eEgwemcifX0",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MB2D-FQDE-CJH4-ILI3-AZ3D-I67B-PV6S",
                "signature": "1itmyoLWYuW-_XFI8_vViHS1vOYdesDgtZePG-9QNu83v9rsf
  lErxeiR23E4eKeyGQXWov7wNusAshmTWtxa8n9XV1KV6KoJb9pH2u7m2YqfmOQ
  QX2xWJ4bUBil0Uiqu-dBETCZd0prfJHnc2Y3mFxkA"}],
            "PayloadDigest": "efTAFfIezfnQKOSjBGx-Y4wbdZuss-4VThNjM0mjelXZu
  ND7Voi3EhhHCFDx0gD43FpKuSSGKE9OccHFxXy3TQ"}],
        "ServerNonce": "NpDi97ddXGcitELaAg-k2Q",
        "Witness": "2A6B-7LBB-DLYR-LA4Y-ZGMF-D4Z5-UP42"},
      {
        "MessageID": "NAJK-KX55-GHUE-JZPZ-Q5N7-QMGD-SEUH",
        "EnvelopedRequestConnection": [{
            "dig": "SHA2"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiU0hBMiJ9LAogICAgICAiZXdvZ0l
  DSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWt0bGVVOW1abXhwYm1WV
  GFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZSRVlpT2lBaVRVUTNOUzF
  GUkV0SExVeElUakl0VEZaUFRpMU1RCiAgMVZMTFRaWFdGQXRRVUpHVHlJc0NpQ
  WdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0EKICBnSUN
  BZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55Z
  GlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2d
  JbU5qUldWUVVuaGtVSFpEVVhsa1FWWnNjWFF5VEdGCiAgRFNIQkNVVFkzWTNCa
  1pHNTZVRVZvUjBsQlZ6Y3hVVFZvTmxsM04yMEtJQ0JtWVhGVmMydFhOM1ZzWTB
  OSEwKICBUTmhjMDAwU2xsb01rRWlmWDE5TEFvZ0lDQWdJa3RsZVVWdVkzSjVjS
  FJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlpT2lBaVRVUkNVaTAxUzFwSkx
  WTkVTa2t0UkZVM01pMUpWMWxRTFZCUlVFY3RTbEpETlNJc0NpQWdJCiAgQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0p
  zYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDS
  kZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYgogIEdsaklqb2dJbWxUY1R
  GdlFXVlVaRWhOVmxaUlV6Rk5hbTF4UVVWTk5GTmZSVk54T1hWTVlsTk5NRmhyW
  kRCCiAgWFJIbElRbWRRWkhsdmVrZ0tJQ0JGYldWTFgwbEJSV1p6UjB4U1dTMW1
  SM3A0VlVzelpVRWlmWDE5TEFvZ0kKICBDQWdJa3RsZVVGMWRHaGxiblJwWTJGM
  GFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFDUlZNdE4wMQogIEVWaTF
  MTjA1RkxUZENVMEl0VmxOQ1RpMU9NbFUzTFZSUVZrWWlMQW9nSUNBZ0lDQWlVS
  FZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJ
  HbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKICBnSUNKamNuWWlPaUFpU
  ldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKRlJGWm1UekE
  1TQogIEdWaVJVdE9XVzEyUzAwNFExVlFNak51Um5jNFdWVk1lRVUyVEMwMVZYQ
  jVSVFpwZWkxcWNERk9URkUwQ2lBCiAgZ1RGSXdWbTlOTkZGNkxXZG9lR2RTVVd
  KcE4waFZXbU5CSW4xOWZYMTkiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZ
  XMiOiBbewogICAgICAgICAgICAiYWxnIjogIlNIQTIiLAogICAgICAgICAgICA
  ia2lkIjogIk1ENzUtRURLRy1MSE4yLUxWT04tTENVSy02V1hQLUFCRk8iLAogI
  CAgICAgICAgICAic2lnbmF0dXJlIjogIlY4QXZpYi1Da2FCOE80U0FZMHJ6Zkt
  rbUZPRnBmWU5raVhjU080b2NmeHRFcjU5S2UKICB6c3gyU04zb2xLS0NQT2pOb
  2piMlJ2TmdubUEzWERFN2VQRi14MFZOUFJrQUVtNm83d1NsZ1JwVTFFeW9SNgo
  gIGM5SmNUQlNIQjdoempxRE9yUG9MSW9rYVY0NV9IaW9KMEdwM0pkUmdBIn1dL
  AogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIk8xOUNhWFRva1N6Vm9JWFRJS3J
  zOXVhTVFhMGhKZnJsZUFkS2p1MXFaM2NycgogIHVkY2xRcjE3Y0tBeUxlQ0ljV
  zJuTWlyeGFiZDU2bnRiWmhOdWRIUXhnIn1dLAogICAgIkNsaWVudE5vbmNlIjo
  gImNucWw0QjNTRFVVTS1ORE9jUVlPTHcifX0",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MBES-7MDV-K7NE-7BSB-VSBN-N2U7-TPVF",
                "signature": "clnBAoTTh_sc3_wu4i4VA0ptny8XIZ4Ii4Af2NKt9Yw_K3Kfc
  Rhxvr2V3jQ7MHHaNeyjBglzLewA7hDmjtZHI4aKnwcGg5vJ_bwrZntF65aF2Yj
  sBYW20HDMhAPBNWSNUyQKtBeJDlWAPKNKdiuC9zUA"}],
            "PayloadDigest": "tRsADnaaZpFi9fm5bTI2YB6UEIbyn0-UbXnSUk7Qx9hHQ
  6b0yRorF5xGyDRhWixz9LRTZosvzAkkgpPRl02NwA"}],
        "ServerNonce": "XI4xrcWdguKBpJKXVtclkA",
        "Witness": "M4J5-YPNB-2O3U-35FZ-PC6G-SP6R-4LBD"}]}}
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
    /requestid   Specifies the request to accept
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
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultSent:

~~~~
<div="terminal">
<cmd>Alice> message accept tbs /json
<rsp>{
  "ResultSent": {
    "Success": true,
    "Message": {
      "Sender": "alice@example.com",
      "Recipient": "alice@example.com",
      "Accept": true}}}
</div>
~~~~


# message reject

~~~~
<div="helptext">
<over>
reject   Reject a pending request
    /requestid   Specifies the request to reject
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
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultSent:

~~~~
<div="terminal">
<cmd>Alice> message reject tbs /json
<rsp>{
  "ResultSent": {
    "Success": true,
    "Message": {
      "Sender": "alice@example.com",
      "Recipient": "alice@example.com",
      "Accept": false}}}
</div>
~~~~


# message block

~~~~
<div="helptext">
<over>
block   Reject a pending request and block requests from that source
    /requestid   Specifies the request to reject and block
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


