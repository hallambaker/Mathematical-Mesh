

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
        "MessageID": "NAG6-XSWC-KXK6-IBTB-4C25-OGYK-VD5S",
        "EnvelopedRequestConnection": [{
            "dig": "S512",
            "Index": 0},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlS
  UQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGV
  EZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiIsCiAgICAgICAgImN0e
  SI6ICJhcHBsaWNhdGlvbi9tbW0ifSwKICAgICAgImV3b2dJQ0pRY205bWFXeGx
  SR1YyYVdObElqb2dld29nSUNBZ0lrdGxlVTltWm14cGJtVlRhV2QKICB1WVhSM
  WNtVWlPaUI3Q2lBZ0lDQWdJQ0pWUkVZaU9pQWlUVVJMUVMxUVYxaENMVU5EV1Z
  NdFVVWkZTaTFaUQogIFZSSUxWbzNTVVF0TlV0S1V5SXNDaUFnSUNBZ0lDSlFkV
  0pzYVdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBCiAgZ0lDQWdJQ0pRZFdKc2F
  XTkxaWGxGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pGWkRRM
  E8KICBDSXNDaUFnSUNBZ0lDQWdJQ0FpVUhWaWJHbGpJam9nSWxaM2JFY3hVRTF
  RUlVwQ2VISnBNSGxJYTBwUVlWSgogIFVaMjlFZVdSQlMxZHVha1F5VURNelNsW
  lVRMVJpVjI5Q2RpMXBka2NLSUNBMFdHOURWalpDYkd4MlRXRTJTCiAgRE50ZUc
  xRE1uZ3dSVUVpZlgxOUxBb2dJQ0FnSWt0bGVVVnVZM0o1Y0hScGIyNGlPaUI3Q
  2lBZ0lDQWdJQ0oKICBWUkVZaU9pQWlUVUZIV2kxUVUxQlJMVTFLUlZFdFFsVkt
  UUzFGU0VwR0xWSlROa010VlZOVFVTSXNDaUFnSQogIENBZ0lDSlFkV0pzYVdOU
  VlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGxGUTB
  SCiAgSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pGWkRRME9DSXNDa
  UFnSUNBZ0lDQWdJQ0FpVUhWaWIKICBHbGpJam9nSWxNMWRtaHJPV1kyZFMxd1d
  rRlpVelpPZDBsU1NtcDBVVUUyTTJaMExVMUlRVGhSU0ZsUGIyVgogIHFMVGN5U
  VZwM0xXbHhTV3NLSUNCeU1IYzRPVmwzU0hVMFZUSjZNM1JaWm1OM1dYaE1Oa0V
  pZlgxOUxBb2dJCiAgQ0FnSWt0bGVVRjFkR2hsYm5ScFkyRjBhVzl1SWpvZ2V3b
  2dJQ0FnSUNBaVZVUkdJam9nSWsxRFVrVXRORXMKICB5TWkwMFNVeEJMVFJMVVR
  NdE5rb3pXUzFIUmtkQ0xVODJURFlpTEFvZ0lDQWdJQ0FpVUhWaWJHbGpVR0Z5W
  QogIFcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBaVVIVmliR2xqUzJWNVJVTkV
  TQ0k2SUhzS0lDQWdJQ0FnSUNBCiAgZ0lDSmpjbllpT2lBaVJXUTBORGdpTEFvZ
  0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSk5RMnhDUzNNd2MKICAyUlROVEp
  RVG1GT2QyVnlPRVEwY1Y5UlVUWktSVmxNV0ZwcU9HUmtXSFpOUnpSU1IwTjNVb
  FpzUm5OckNpQQogIGdXRGRvWTFZd2MwRm1aRmhOYzNrd1lrUldZbkZYWkZOQkl
  uMTlmWDE5IiwKICAgICAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgI
  CAgICAgICAgInNpZ25hdHVyZSI6ICJCd2xjTzNMSEI2Wk5qNVRwWGxNd0hiZHN
  EN0pQd0NWczBUOU5uV0t1YTVqNUJ1UXhWCiAgbW05MERNUDFkeXZJbnlOTHNxU
  2NWdGRuaXdBeDRfMEp4aVFoa2hLamd5OVZZRlpVdVZYM29veVdsT2VVNHcKICB
  oVmg0WTVyMlZONUd5UGJNSTUzc2dpLWlqMnNwX1R3azUwMFFOT1J3QSJ9XSwKI
  CAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICIzdjB6SVJRdGQ1YnZybVNLdXAteWY
  zbmdRQ0lhTkd4NHU2MDVKdTdZSi1GWlMKICBBWXJkc1ZITzIxOW5kbC1HV0F0c
  0x4a1VJVGdEV3J2SU1Xejg2X2VaUSJ9XSwKICAgICJDbGllbnROb25jZSI6ICJ
  1WXBwUi03cWRuSGFPckhkMHJNdDdnIiwKICAgICJQaW5VREYiOiAiTkNOQi1XV
  FAyLTdJTU8tWEJYRS1ZQSJ9fQ",
          {
            "signatures": [{
                "signature": "fzQx72p-wRgkrWuLbWqE3rOBZgxai8vMXpEp0Ca740UOZJ30H
  zkK-0kwtjCUBjc2KM6M8wIYkVaABLKFLHcFIKzcBA7XrTeaUaLrKrcotKrB-Zx
  bTGKJbFYtD9Q1E4JgMz6wu6_PKxJBM2GbacanWjYA"}],
            "PayloadDigest": "GeUVQhSQC4HWncvk-DuGUCA0Ib2LG5KK1jew3Xvh9KizG
  80XQsnic_uwfbYwKWtZpIoOtukGYz7LXuxLp6domQ"}],
        "ServerNonce": "8A9N5Uhtjz4Ys7Opu1Kc8A",
        "Witness": "SDVM-PEQ2-JBDC-PMSO-IVUZ-6NAV-ZGY3"},
      {
        "MessageID": "NAG6-XSWC-KXK6-IBTB-4C25-OGYK-VD5S",
        "EnvelopedRequestConnection": [{
            "dig": "S512",
            "Index": 0},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlS
  UQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGV
  EZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiIsCiAgICAgICAgImN0e
  SI6ICJhcHBsaWNhdGlvbi9tbW0ifSwKICAgICAgImV3b2dJQ0pRY205bWFXeGx
  SR1YyYVdObElqb2dld29nSUNBZ0lrdGxlVTltWm14cGJtVlRhV2QKICB1WVhSM
  WNtVWlPaUI3Q2lBZ0lDQWdJQ0pWUkVZaU9pQWlUVVJMUVMxUVYxaENMVU5EV1Z
  NdFVVWkZTaTFaUQogIFZSSUxWbzNTVVF0TlV0S1V5SXNDaUFnSUNBZ0lDSlFkV
  0pzYVdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBCiAgZ0lDQWdJQ0pRZFdKc2F
  XTkxaWGxGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pGWkRRM
  E8KICBDSXNDaUFnSUNBZ0lDQWdJQ0FpVUhWaWJHbGpJam9nSWxaM2JFY3hVRTF
  RUlVwQ2VISnBNSGxJYTBwUVlWSgogIFVaMjlFZVdSQlMxZHVha1F5VURNelNsW
  lVRMVJpVjI5Q2RpMXBka2NLSUNBMFdHOURWalpDYkd4MlRXRTJTCiAgRE50ZUc
  xRE1uZ3dSVUVpZlgxOUxBb2dJQ0FnSWt0bGVVVnVZM0o1Y0hScGIyNGlPaUI3Q
  2lBZ0lDQWdJQ0oKICBWUkVZaU9pQWlUVUZIV2kxUVUxQlJMVTFLUlZFdFFsVkt
  UUzFGU0VwR0xWSlROa010VlZOVFVTSXNDaUFnSQogIENBZ0lDSlFkV0pzYVdOU
  VlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGxGUTB
  SCiAgSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pGWkRRME9DSXNDa
  UFnSUNBZ0lDQWdJQ0FpVUhWaWIKICBHbGpJam9nSWxNMWRtaHJPV1kyZFMxd1d
  rRlpVelpPZDBsU1NtcDBVVUUyTTJaMExVMUlRVGhSU0ZsUGIyVgogIHFMVGN5U
  VZwM0xXbHhTV3NLSUNCeU1IYzRPVmwzU0hVMFZUSjZNM1JaWm1OM1dYaE1Oa0V
  pZlgxOUxBb2dJCiAgQ0FnSWt0bGVVRjFkR2hsYm5ScFkyRjBhVzl1SWpvZ2V3b
  2dJQ0FnSUNBaVZVUkdJam9nSWsxRFVrVXRORXMKICB5TWkwMFNVeEJMVFJMVVR
  NdE5rb3pXUzFIUmtkQ0xVODJURFlpTEFvZ0lDQWdJQ0FpVUhWaWJHbGpVR0Z5W
  QogIFcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBaVVIVmliR2xqUzJWNVJVTkV
  TQ0k2SUhzS0lDQWdJQ0FnSUNBCiAgZ0lDSmpjbllpT2lBaVJXUTBORGdpTEFvZ
  0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSk5RMnhDUzNNd2MKICAyUlROVEp
  RVG1GT2QyVnlPRVEwY1Y5UlVUWktSVmxNV0ZwcU9HUmtXSFpOUnpSU1IwTjNVb
  FpzUm5OckNpQQogIGdXRGRvWTFZd2MwRm1aRmhOYzNrd1lrUldZbkZYWkZOQkl
  uMTlmWDE5IiwKICAgICAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgI
  CAgICAgICAgInNpZ25hdHVyZSI6ICJCd2xjTzNMSEI2Wk5qNVRwWGxNd0hiZHN
  EN0pQd0NWczBUOU5uV0t1YTVqNUJ1UXhWCiAgbW05MERNUDFkeXZJbnlOTHNxU
  2NWdGRuaXdBeDRfMEp4aVFoa2hLamd5OVZZRlpVdVZYM29veVdsT2VVNHcKICB
  oVmg0WTVyMlZONUd5UGJNSTUzc2dpLWlqMnNwX1R3azUwMFFOT1J3QSJ9XSwKI
  CAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICIzdjB6SVJRdGQ1YnZybVNLdXAteWY
  zbmdRQ0lhTkd4NHU2MDVKdTdZSi1GWlMKICBBWXJkc1ZITzIxOW5kbC1HV0F0c
  0x4a1VJVGdEV3J2SU1Xejg2X2VaUSJ9XSwKICAgICJDbGllbnROb25jZSI6ICJ
  1WXBwUi03cWRuSGFPckhkMHJNdDdnIiwKICAgICJQaW5VREYiOiAiTkNOQi1XV
  FAyLTdJTU8tWEJYRS1ZQSJ9fQ",
          {
            "signatures": [{
                "signature": "fzQx72p-wRgkrWuLbWqE3rOBZgxai8vMXpEp0Ca740UOZJ30H
  zkK-0kwtjCUBjc2KM6M8wIYkVaABLKFLHcFIKzcBA7XrTeaUaLrKrcotKrB-Zx
  bTGKJbFYtD9Q1E4JgMz6wu6_PKxJBM2GbacanWjYA"}],
            "PayloadDigest": "GeUVQhSQC4HWncvk-DuGUCA0Ib2LG5KK1jew3Xvh9KizG
  80XQsnic_uwfbYwKWtZpIoOtukGYz7LXuxLp6domQ"}],
        "ServerNonce": "8A9N5Uhtjz4Ys7Opu1Kc8A",
        "Witness": "SDVM-PEQ2-JBDC-PMSO-IVUZ-6NAV-ZGY3"},
      {
        "MessageID": "NBTB-ZC3R-44LZ-WRJ2-FTTP-F3K3-6TUA",
        "EnvelopedRequestConnection": [{
            "dig": "S512",
            "Index": 0},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlS
  UQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGV
  EZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiIsCiAgICAgICAgImN0e
  SI6ICJhcHBsaWNhdGlvbi9tbW0ifSwKICAgICAgImV3b2dJQ0pRY205bWFXeGx
  SR1YyYVdObElqb2dld29nSUNBZ0lrdGxlVTltWm14cGJtVlRhV2QKICB1WVhSM
  WNtVWlPaUI3Q2lBZ0lDQWdJQ0pWUkVZaU9pQWlUVUZGUkMxUE5EUlJMVU0xU1Z
  RdFV6UlFVaTFFVgogIGpNMUxVcFJWMUF0UVVNM1NDSXNDaUFnSUNBZ0lDSlFkV
  0pzYVdOUVlYSmhiV1YwWlhKeklqb2dld29nSUNBCiAgZ0lDQWdJQ0pRZFdKc2F
  XTkxaWGxGUTBSSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pGWkRRM
  E8KICBDSXNDaUFnSUNBZ0lDQWdJQ0FpVUhWaWJHbGpJam9nSWxsT00zaE1NVmx
  DWWxwcmNYTXpNMVpJY2taUVVXMQogIFRNRzVQVWxGRlJIZHdUMVo2WWxwME5EW
  m1MVkJIV0doeU0wbEpOMFVLSUNCcVZreGpUWE01T1Y5UGVGOWtlCiAgVEZET1Z
  saVZVTnhkVUVpZlgxOUxBb2dJQ0FnSWt0bGVVVnVZM0o1Y0hScGIyNGlPaUI3Q
  2lBZ0lDQWdJQ0oKICBWUkVZaU9pQWlUVVJYTXkweVQxRk9MVXROVWtJdFVUUkR
  TaTFhU0ZZeUxVdFFTVmN0U1RVek5pSXNDaUFnSQogIENBZ0lDSlFkV0pzYVdOU
  VlYSmhiV1YwWlhKeklqb2dld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGxGUTB
  SCiAgSUlqb2dld29nSUNBZ0lDQWdJQ0FnSW1OeWRpSTZJQ0pGWkRRME9DSXNDa
  UFnSUNBZ0lDQWdJQ0FpVUhWaWIKICBHbGpJam9nSWsxMlQxUXhTMGd0UmxaTFZ
  uZFBlVjg0V2pSeldITk1iMlJDVXpSUlpscFlVV2hpUTJsc1gxQgogIEhhR0ZwV
  G5wdWMzcERXRUVLSUNCYVdETXpNV2hRVlZvelF6SmFSemhmTmtSUkxXbFphMEV
  pZlgxOUxBb2dJCiAgQ0FnSWt0bGVVRjFkR2hsYm5ScFkyRjBhVzl1SWpvZ2V3b
  2dJQ0FnSUNBaVZVUkdJam9nSWsxQlVrOHROMHAKICBETkMxWFNrOVdMVXRVVGp
  RdE4wOWFVUzFPTmtoTkxVTlZXVllpTEFvZ0lDQWdJQ0FpVUhWaWJHbGpVR0Z5W
  QogIFcxbGRHVnljeUk2SUhzS0lDQWdJQ0FnSUNBaVVIVmliR2xqUzJWNVJVTkV
  TQ0k2SUhzS0lDQWdJQ0FnSUNBCiAgZ0lDSmpjbllpT2lBaVJXUTBORGdpTEFvZ
  0lDQWdJQ0FnSUNBZ0lsQjFZbXhwWXlJNklDSTBXalozTkVKUlkKICBXaGhXSEZ
  SV2poU1pXcEZOMlZ6T0RBeFpWQTBiMll6VjFaWFJtMVlORlpYT0hwU05reHFhS
  FpRWmtGdENpQQogIGdTRmsyUjJsTFJuVnVlbU5KWVhKdk9FOU9SMEZLZUZsQkl
  uMTlmWDE5IiwKICAgICAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgI
  CAgICAgICAgInNpZ25hdHVyZSI6ICJNWExJQWRzcFVLNjMyQklwWHhPamFjU3J
  sRGZURHYyM2p2dV8xYU4zODJTZWxNZ2E1CiAgMjJsM1pnemVuam1oaEh6THRlW
  WVDWE9rQmNBQ1AyaFBMNU9rNjJBbGdLYWtpYTVHMnBTYzBHTE41cGZNQWoKICA
  wX1NPbzFmMmhLWjJHYVJ3SlJmVG5lTm9rai1OcEJjcmNoZFh5c0Q4QSJ9XSwKI
  CAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJhdlIydHg2WDdpRWpaSXJFcEVJWEZ
  hYm5LVDZmc0toNmNrelJ1Wld5QTkzNUwKICBFX1FkQVpOZ3RKNlMwMFBfeTgzb
  E1Eenc4VGk4cEdjcE5XSlg0WlJJZyJ9XSwKICAgICJDbGllbnROb25jZSI6ICJ
  IbGNsVjBIUWcxVlhXMnYwWFJmZllRIn19",
          {
            "signatures": [{
                "signature": "wenhV5tpFuJJk1X_8LDHql_rSbXn1jF5pVRTZi1l67YFWvK0r
  Til7Lz24fpXl4sE1ypgl1D_phgApNUexXJJ4IQ-diIqHx0oFD1EuhQ1uV3RjgV
  7T7jUd6Wcdn3Nhbg4b5K9kJ2leB_cZHRMocwXdxMA"}],
            "PayloadDigest": "Ahr_KG6VYEzFG0iISj_l2x0pXfGLwIgJmMceoBjhEx4o9
  umenhhslbFon5dw961FUM8qA3StcfyumcbBEVLQbA"}],
        "ServerNonce": "DSv11poeA7bUUWmn5LNhzw",
        "Witness": "6D7S-QUSO-4XUJ-FTBQ-6RGP-JBGU-CDWR"}]}}
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

