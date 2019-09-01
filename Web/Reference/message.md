

# message

````
message    Contact and confirmation message options
    accept   Accept a pending request
    block   Reject a pending request and block requests from that source
    confirm   Post a confirmation request to a user
    contact   Post a conection request to a user
    pending   List pending requests
    reject   Reject a pending request
    status   Request status of pending requests
````


# message contact

````
contact   Post a conection request to a user
       The recipient to send the conection request to
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Bob> message contact alice@example.com
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
Bob> message contact alice@example.com /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# message confirm

````
confirm   Post a confirmation request to a user
       The recipient to send the confirmation request to
       The recipient to send the confirmation request to
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Bob> message confirm alice@example.com "Purchase equipment for $6,000?"
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
Bob> message confirm alice@example.com "Purchase equipment for $6,000?" /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````


# message pending

````
pending   List pending requests
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Alice> message pending
````

Specifying the /json option returns a result of type ResultPending:

````
Alice> message pending /json
{
  "ResultPending": {
    "Success": true,
    "Messages": [{
        "MessageID": "NAGZ-RSIK-3XUX-ONDW-GSBK-BDHI-CSTN",
        "EnvelopedRequestConnection": [{
            "dig": "S512",
            "Index": 0},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlS
  UQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGV
  EZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiIsCiAgICAgICAgImN0e
  SI6ICJhcHBsaWNhdGlvbi9tbW0ifSwKICAgICAgImV3b2dJQ0pRY205bWFXeGx
  SR1YyYVdObElqb2dld29nSUNBZ0lrdGxlVTltWm14cGJtVlRhV2QKICB1WVhSM
  WNtVWlPaUI3Q2lBZ0lDQWdJQ0pWUkVZaU9pQWlUVUpOUXkxUldEZElMVUpPTlV
  NdFZEWXlTUzFCVAogIDFSQ0xUZGFXVXN0TjBaR1VDSXNDaUFnSUNBZ0lDSlFkV
  0pzYVdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBCiAgZ0lDQWdJQ0pRZFdKc2F
  XTkxaWGxGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pGWkRRM
  E8KICBDSXNDaUFnSUNBZ0lDQWdJQ0FpVUhWaWJHbGpJam9nSW10RE5EUmpMWEI
  1UWtSVGFGZEVSMmhSVG1Sb2VFRgogIHFNV0ZaTldaa1YyNUlTRVJLV1ZwSlRqS
  ndkalF4U0dWUGFqQm9WVElLSUNCeFpTMUhOVjltZWtWdWNsSk9NCiAgRFZtYUR
  Kd2MzUmxWVUVpZlgxOUxBb2dJQ0FnSWt0bGVVVnVZM0o1Y0hScGIyNGlPaUI3Q
  2lBZ0lDQWdJQ0oKICBWUkVZaU9pQWlUVVEzUVMxR05rUllMVk5MUmxZdFZrSkZ
  TeTFPTlZWUExVbEJRMDh0TWxZM1dTSXNDaUFnSQogIENBZ0lDSlFkV0pzYVdOU
  VlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGxGUTB
  SCiAgSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pGWkRRME9DSXNDa
  UFnSUNBZ0lDQWdJQ0FpVUhWaWIKICBHbGpJam9nSW1Kc2NrSk9ObE5NUm5CRmR
  sWkJkV0ZRT1RGNlNGaHVMWFpvWkZoWlJuZEtUMVIyTTJwT05WaAogIHpZbVExU
  lhKbGFqUnFPV2tLSUNCc1JrUllhRWxaYUhWUVdWZDBNVGxyUVRObFYwRnFSVUV
  pZlgxOUxBb2dJCiAgQ0FnSWt0bGVVRjFkR2hsYm5ScFkyRjBhVzl1SWpvZ2V3b
  2dJQ0FnSUNBaVZVUkdJam9nSWsxQlYwTXRVVloKICBLUmkxWk5VVmFMVU5JUlR
  ZdFNrSTFSUzFVVUZKTUxVOUJValFpTEFvZ0lDQWdJQ0FpVUhWaWJHbGpVR0Z5W
  QogIFcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBaVVIVmliR2xqUzJWNVJVTkV
  TQ0k2SUhzS0lDQWdJQ0FnSUNBCiAgZ0lDSmpjbllpT2lBaVJXUTBORGdpTEFvZ
  0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSktSRk5hU0ZoVE0KICBXVm1jMnR
  uVG1SQlIxWnRkVVJYY1VWcE1rRjNiMUJDTjBOV0xXOTNVR3BsZWtwSU5rMTZRM
  mx2ZWtkQkNpQQogIGdTM2xPZGpCbmJEZ3RRbTFXWm1WUGJIWmZYM1UxYkZsQkl
  uMTlmWDE5IiwKICAgICAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgI
  CAgICAgICAgInNpZ25hdHVyZSI6ICJxTjlBd2thR0g2RGhqWmtnT2JReXpiaHd
  5MFdnUzBjdW9aTmJtZmROeU1scGdHU3c1CiAgRC1Dei1kQk5NUkFuQXZpdi1ST
  Ug5SkQ5RmtBV29FX3pHRDhkWWZGR0xwOFN6OXdQc2owZHB0V0FQMXZHQWMKICB
  2U2dERE4xWUwtSmtCQU1RZjhhVUtTMGp4T1VJdmJtMlpjRjFHcnowQSJ9XSwKI
  CAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICIxQ0N5WDkyUkdSdjRIbEpfLWEzTEh
  QdkREZmR4VU9PY1ZrM210ejAzUkRIT2QKICBlbWFmZXNCQ0hEU3FaN21BcjB0Z
  zNvVzRKWnUyMFZ1YTFVNU9hVmNGUSJ9XSwKICAgICJDbGllbnROb25jZSI6ICJ
  JYndMOFBLelJoWXRSLW9zUm9FeGtnIiwKICAgICJQaW5VREYiOiAiTkJIUS1XR
  0FWLVZJVjMtR0dKNC1FSSJ9fQ",
          {
            "signatures": [{
                "signature": "xcWxBU53dmv8poe28zVlpniE6KgDqS-WN-iVrVs3lWH1GExl6
  y2r1dKia8LwKcLtIaPh4h-f8ZqAl8dfKKP6gGRxM_BGvX1vTCvemY3Xq9LSfqJ
  ih_vEPXtUFxeiRQwoygPVUsMjLBTq1LZ0s_o7YxoA"}],
            "PayloadDigest": "dpOmczM1Lcw108gVpXn-u6k4oPsOsRKFeED7Dp3Bz-wi5
  0BXNkg2yrn8Thts2ZKi_0pGSp76kWfg59F0BY4b4Q"}],
        "ServerNonce": "a20XgJ_D2hVMoNHjibjCjA",
        "Witness": "ROCX-6LON-P4TF-YCSL-SJ4U-SS2D-JBJK"},
      {
        "MessageID": "NAGZ-RSIK-3XUX-ONDW-GSBK-BDHI-CSTN",
        "EnvelopedRequestConnection": [{
            "dig": "S512",
            "Index": 0},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlS
  UQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGV
  EZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiIsCiAgICAgICAgImN0e
  SI6ICJhcHBsaWNhdGlvbi9tbW0ifSwKICAgICAgImV3b2dJQ0pRY205bWFXeGx
  SR1YyYVdObElqb2dld29nSUNBZ0lrdGxlVTltWm14cGJtVlRhV2QKICB1WVhSM
  WNtVWlPaUI3Q2lBZ0lDQWdJQ0pWUkVZaU9pQWlUVUpOUXkxUldEZElMVUpPTlV
  NdFZEWXlTUzFCVAogIDFSQ0xUZGFXVXN0TjBaR1VDSXNDaUFnSUNBZ0lDSlFkV
  0pzYVdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBCiAgZ0lDQWdJQ0pRZFdKc2F
  XTkxaWGxGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pGWkRRM
  E8KICBDSXNDaUFnSUNBZ0lDQWdJQ0FpVUhWaWJHbGpJam9nSW10RE5EUmpMWEI
  1UWtSVGFGZEVSMmhSVG1Sb2VFRgogIHFNV0ZaTldaa1YyNUlTRVJLV1ZwSlRqS
  ndkalF4U0dWUGFqQm9WVElLSUNCeFpTMUhOVjltZWtWdWNsSk9NCiAgRFZtYUR
  Kd2MzUmxWVUVpZlgxOUxBb2dJQ0FnSWt0bGVVVnVZM0o1Y0hScGIyNGlPaUI3Q
  2lBZ0lDQWdJQ0oKICBWUkVZaU9pQWlUVVEzUVMxR05rUllMVk5MUmxZdFZrSkZ
  TeTFPTlZWUExVbEJRMDh0TWxZM1dTSXNDaUFnSQogIENBZ0lDSlFkV0pzYVdOU
  VlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGxGUTB
  SCiAgSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pGWkRRME9DSXNDa
  UFnSUNBZ0lDQWdJQ0FpVUhWaWIKICBHbGpJam9nSW1Kc2NrSk9ObE5NUm5CRmR
  sWkJkV0ZRT1RGNlNGaHVMWFpvWkZoWlJuZEtUMVIyTTJwT05WaAogIHpZbVExU
  lhKbGFqUnFPV2tLSUNCc1JrUllhRWxaYUhWUVdWZDBNVGxyUVRObFYwRnFSVUV
  pZlgxOUxBb2dJCiAgQ0FnSWt0bGVVRjFkR2hsYm5ScFkyRjBhVzl1SWpvZ2V3b
  2dJQ0FnSUNBaVZVUkdJam9nSWsxQlYwTXRVVloKICBLUmkxWk5VVmFMVU5JUlR
  ZdFNrSTFSUzFVVUZKTUxVOUJValFpTEFvZ0lDQWdJQ0FpVUhWaWJHbGpVR0Z5W
  QogIFcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBaVVIVmliR2xqUzJWNVJVTkV
  TQ0k2SUhzS0lDQWdJQ0FnSUNBCiAgZ0lDSmpjbllpT2lBaVJXUTBORGdpTEFvZ
  0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSktSRk5hU0ZoVE0KICBXVm1jMnR
  uVG1SQlIxWnRkVVJYY1VWcE1rRjNiMUJDTjBOV0xXOTNVR3BsZWtwSU5rMTZRM
  mx2ZWtkQkNpQQogIGdTM2xPZGpCbmJEZ3RRbTFXWm1WUGJIWmZYM1UxYkZsQkl
  uMTlmWDE5IiwKICAgICAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgI
  CAgICAgICAgInNpZ25hdHVyZSI6ICJxTjlBd2thR0g2RGhqWmtnT2JReXpiaHd
  5MFdnUzBjdW9aTmJtZmROeU1scGdHU3c1CiAgRC1Dei1kQk5NUkFuQXZpdi1ST
  Ug5SkQ5RmtBV29FX3pHRDhkWWZGR0xwOFN6OXdQc2owZHB0V0FQMXZHQWMKICB
  2U2dERE4xWUwtSmtCQU1RZjhhVUtTMGp4T1VJdmJtMlpjRjFHcnowQSJ9XSwKI
  CAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICIxQ0N5WDkyUkdSdjRIbEpfLWEzTEh
  QdkREZmR4VU9PY1ZrM210ejAzUkRIT2QKICBlbWFmZXNCQ0hEU3FaN21BcjB0Z
  zNvVzRKWnUyMFZ1YTFVNU9hVmNGUSJ9XSwKICAgICJDbGllbnROb25jZSI6ICJ
  JYndMOFBLelJoWXRSLW9zUm9FeGtnIiwKICAgICJQaW5VREYiOiAiTkJIUS1XR
  0FWLVZJVjMtR0dKNC1FSSJ9fQ",
          {
            "signatures": [{
                "signature": "xcWxBU53dmv8poe28zVlpniE6KgDqS-WN-iVrVs3lWH1GExl6
  y2r1dKia8LwKcLtIaPh4h-f8ZqAl8dfKKP6gGRxM_BGvX1vTCvemY3Xq9LSfqJ
  ih_vEPXtUFxeiRQwoygPVUsMjLBTq1LZ0s_o7YxoA"}],
            "PayloadDigest": "dpOmczM1Lcw108gVpXn-u6k4oPsOsRKFeED7Dp3Bz-wi5
  0BXNkg2yrn8Thts2ZKi_0pGSp76kWfg59F0BY4b4Q"}],
        "ServerNonce": "a20XgJ_D2hVMoNHjibjCjA",
        "Witness": "ROCX-6LON-P4TF-YCSL-SJ4U-SS2D-JBJK"},
      {
        "MessageID": "NCSZ-HZHS-QKLF-AP52-2YAB-ZIIS-VD6K",
        "EnvelopedRequestConnection": [{
            "dig": "S512",
            "Index": 0},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlS
  UQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGV
  EZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiIsCiAgICAgICAgImN0e
  SI6ICJhcHBsaWNhdGlvbi9tbW0ifSwKICAgICAgImV3b2dJQ0pRY205bWFXeGx
  SR1YyYVdObElqb2dld29nSUNBZ0lrdGxlVTltWm14cGJtVlRhV2QKICB1WVhSM
  WNtVWlPaUI3Q2lBZ0lDQWdJQ0pWUkVZaU9pQWlUVUZJUXkwMFMxRldMVTVhU2x
  rdFIxaFNVQzFCTgogIDFSS0xUUlpTVFF0UVZaTlNpSXNDaUFnSUNBZ0lDSlFkV
  0pzYVdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBCiAgZ0lDQWdJQ0pRZFdKc2F
  XTkxaWGxGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pGWkRRM
  E8KICBDSXNDaUFnSUNBZ0lDQWdJQ0FpVUhWaWJHbGpJam9nSWtWVVRtbzRWa3g
  1YkRaRFJXdzRPVmRVU1VoaE1rZAogIFZZMDFwTTFKWlFWODRUWHA0V1VWcVYwe
  E1ibHBEYW5VNWExbzRWRW9LSUNCNVpWTlpVSEJqVUdoMlFUQnNiCiAgVzlrV0U
  1NmNHbDZZMEVpZlgxOUxBb2dJQ0FnSWt0bGVVVnVZM0o1Y0hScGIyNGlPaUI3Q
  2lBZ0lDQWdJQ0oKICBWUkVZaU9pQWlUVUZXVnkwMFZ6YzBMVXBCVEZBdFdVSkZ
  XUzFOVWtwYUxWWkdNMGN0TXpWWFdpSXNDaUFnSQogIENBZ0lDSlFkV0pzYVdOU
  VlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGxGUTB
  SCiAgSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pGWkRRME9DSXNDa
  UFnSUNBZ0lDQWdJQ0FpVUhWaWIKICBHbGpJam9nSW5OQ1ZXSnNkRlJTUlZad0x
  WSXdRV2RuWldoSE9XSjNOR3N4YjB0S1NHTm5lbDlvU2pWNWEwZAogIGtTRFJGV
  2t0UFVuTmhXWE1LSUNCbGJURkNPVkUyTW5KS2NHdENabEpKU0hWWGRXNXlSVUV
  pZlgxOUxBb2dJCiAgQ0FnSWt0bGVVRjFkR2hsYm5ScFkyRjBhVzl1SWpvZ2V3b
  2dJQ0FnSUNBaVZVUkdJam9nSWsxRVFVSXRRVFIKICBUVVMwMlJEUXlMVlpRVHp
  NdFJUYzBSUzFGTWxwQkxVaFZUa1VpTEFvZ0lDQWdJQ0FpVUhWaWJHbGpVR0Z5W
  QogIFcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBaVVIVmliR2xqUzJWNVJVTkV
  TQ0k2SUhzS0lDQWdJQ0FnSUNBCiAgZ0lDSmpjbllpT2lBaVJXUTBORGdpTEFvZ
  0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSk9lVWhVYkhOd00KICAyRTBZVkZ
  UTkdOeWRVMU5jVzEwTUc5NU5sWTNaMjFvVHkxeVprZGZaMU0yVWxGRlRHWnZTM
  VZHV1VJMUNpQQogIGdUWE5NYTJkMFowUnRSMTkxUzA5UU5FNHpNWGMyUzI5Qkl
  uMTlmWDE5IiwKICAgICAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgI
  CAgICAgICAgInNpZ25hdHVyZSI6ICJnY1FvNUN5a1A3d0tqZmYzZ0xsbk4zLXJ
  DTVQxTldKR1pFVms3Y01KNncwRGx6Q3I2CiAgRHVKQ1gxMXN3Wm5GX1dmM205c
  Wp1YkMtUWFBM1JpUUw0NHFwZnJhVzA3dXdRXzE1OERLTmN0T3NELU5PZHoKICB
  sSkJvS1JPejJNX0dyTER0bzc3ZDBpY3ZMTnpBbUZXZkZpdEhCQmdJQSJ9XSwKI
  CAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJOdzB2ekVEY1p1dFg4dXBqUkRwMDR
  xS3RGN25OdFhVUFBEUjhaNUNLNmJRd2kKICBGcm9tOEJiVGJrTEhZYVN4bWFIS
  ElsU0hhMG55OF9GaFJKX1lHTkJPZyJ9XSwKICAgICJDbGllbnROb25jZSI6ICJ
  tbFZvNWk2RU4zRzBlSUNPSERiOGtnIn19",
          {
            "signatures": [{
                "signature": "hCYqHibPKDOcq59GpIuDwTqO6avIK1Y25KNswl3y8utjiDc6I
  H6CbZKenlD84vi1guCWs3t2uYEAdKDvgat9XkGNV0AkasKVqz4m1cKZBnwLQf1
  jbGEYrB5rPftO957ta1FXVrQR0V_Cg5gJ-4xsHSIA"}],
            "PayloadDigest": "joHqe5LmsS5lEmmGwWncR8ymc80ib28D-skchzX0k0beK
  oBhMCjrzAl0tl0ILNXnOAxbsSCDls2iZ1R_tAviQQ"}],
        "ServerNonce": "0559Z__D5uRW1AeiodtFhw",
        "Witness": "QRQ3-3LCG-NUN5-W7CJ-PPLB-4CAM-64AX"}]}}
````


# message status

````
status   Request status of pending requests
    /requestid   Specifies the request to provide the status of
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Bob> message status tbs
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
Bob> message status tbs /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# message accept

````
accept   Accept a pending request
    /requestid   Specifies the request to accept
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Alice> message accept tbs
````

Specifying the /json option returns a result of type ResultSent:

````
Alice> message accept tbs /json
{
  "ResultSent": {
    "Success": true,
    "Message": {
      "Recipient": "alice@example.com",
      "Accept": true}}}
````

# message reject

````
reject   Reject a pending request
    /requestid   Specifies the request to reject
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Alice> message reject tbs
````

Specifying the /json option returns a result of type ResultSent:

````
Alice> message reject tbs /json
{
  "ResultSent": {
    "Success": true,
    "Message": {
      "Recipient": "alice@example.com",
      "Accept": false}}}
````

# message block

````
block   Reject a pending request and block requests from that source
    /requestid   Specifies the request to reject and block
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Alice> message block mallet@example.com
````

Specifying the /json option returns a result of type ResultSent:

````
Alice> message block mallet@example.com /json
{
  "ResultSent": {
    "Success": true}}
````

