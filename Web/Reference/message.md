

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
        "MessageID": "NBRN-CPNT-CPDZ-NZFK-TGJP-CRBK-PDEL",
        "EnvelopedMessageConnectionRequest": [{
            "dig": "S512"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiIsCiAgICAgICAgImN0eSI
  6ICJhcHBsaWNhdGlvbi9tbW0ifSwKICAgICAgImV3b2dJQ0pRY205bWFXeGxSR
  1YyYVdObElqb2dld29nSUNBZ0lrdGxlVk5wWjI1aGRIVnlaU0kKICA2SUhzS0l
  DQWdJQ0FnSWxWRVJpSTZJQ0pOUTB0TExUTXpVbGt0VVRaVlZpMU9SMVZCTFZsT
  ldqUXRWMHBNTgogIFMxQ1NrdEdJaXdLSUNBZ0lDQWdJbEIxWW14cFkxQmhjbUZ
  0WlhSbGNuTWlPaUI3Q2lBZ0lDQWdJQ0FnSWxCCiAgMVlteHBZMHRsZVVWRFJFZ
  2lPaUI3Q2lBZ0lDQWdJQ0FnSUNBaVkzSjJJam9nSWtWa05EUTRJaXdLSUNBZ0k
  KICBDQWdJQ0FnSUNKUWRXSnNhV01pT2lBaU1VbENTRFJ3UnpWRE1ETnljVU5UV
  G5wQmIyNU5Ta2N5UzNkclZVbwogIDRORGhHWjJ4SVlVMDFSMnhJT1d0TFZuVmZ
  Va3d6UndvZ0lIZE5XVXBxTkd0Vk0ycHNjbFU0Ym1jdFFtNXhVCiAgVFJ6UVNKO
  WZYMHNDaUFnSUNBaVMyVjVSVzVqY25sd2RHbHZiaUk2SUhzS0lDQWdJQ0FnSWx
  WRVJpSTZJQ0oKICBOUWtOWkxVYzFObGN0TlV4QlN5MVVWMHRCTFRkSVZUUXRSR
  EpOVUMxWVJVcFdJaXdLSUNBZ0lDQWdJbEIxWQogIG14cFkxQmhjbUZ0WlhSbGN
  uTWlPaUI3Q2lBZ0lDQWdJQ0FnSWxCMVlteHBZMHRsZVVWRFJFZ2lPaUI3Q2lBC
  iAgZ0lDQWdJQ0FnSUNBaVkzSjJJam9nSWtWa05EUTRJaXdLSUNBZ0lDQWdJQ0F
  nSUNKUWRXSnNhV01pT2lBaVUKICBFZGFaRUp4ZGpCVVdUQlFVMU01TlRGaVJXW
  kxaMmxJWkVac1JqUjVia3BITXpoa2FFRktOa1ZhTFhCd1RsRgogIG1UUzFGVHd
  vZ0lGWlVTamxRUzA5ZmJWSnZPV3czVm5SRk5FOTRUVEZYUVNKOWZYMHNDaUFnS
  UNBaVMyVjVRCiAgWFYwYUdWdWRHbGpZWFJwYjI0aU9pQjdDaUFnSUNBZ0lDSlZ
  SRVlpT2lBaVRVRkZRUzAxTkROTkxWSTNTVW8KICB0UWtOWVV5MUhUekpCTFU5R
  1VrRXRRMUpXVmlJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SQo
  gIGpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ
  0FnSUNBZ0lDQWdJbU55ZGlJCiAgNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0l
  DQWlVSFZpYkdsaklqb2dJbTVmYzJReloycEJaazVIVEZaMFQKICBqaElaRzVEZ
  G13eVZtRkNWMlZUYWxGUWNrSlVNRFZDU1RkSloxWTJXV2hNYTFveWJqWUtJQ0J
  LU21vMldYWQogIDBNMVpWTkdKcVVHZEthVTR0U2kxdGEwRWlmWDE5ZlgwIiwKI
  CAgICAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgInN
  pZ25hdHVyZSI6ICJDbWtQZ2w3d1Z3UU5WMFhRTUpmZnRIaEo3VHRyY3ZZNVdJN
  XBpZlY1TFhuZlFqajA4CiAgUjhKMTcyeGV2RmFKaWlscGxUSUZnNkFlTk1BYnJ
  GbzZnX3JvWUV2a012djEzc0hUelZzamxxWGxNbWVzV1AKICBLZHV2Tld6NWhaa
  nN5SmNXNU9hTW5wb0tyNXlWZV9aMmlrR0t1cXk0QSJ9XSwKICAgICAgICAiUGF
  5bG9hZERpZ2VzdCI6ICJQSzVsSUFJZGJXME42cjRmV2Z0LWtha1pXRXEwZTZFN
  ThJVmFSY3VGd0cydHoKICBZZF9Zb3ZMbDZyN2xaOS1YdFd1aE9xWUgtZE9henE
  5V3F6N2hXdTBLUSJ9XSwKICAgICJDbGllbnROb25jZSI6ICJ6eVAwcHpkUVVGd
  nRPZTZYaFJsbzlBIiwKICAgICJQaW5VREYiOiAiTkNRVi1JQ0JKLU5IUTctU0Z
  UTi1ZTSJ9fQ",
          {
            "signatures": [{
                "signature": "pRk4u4fBvzlrDCmnI1Yo6rvfeReiKWDuWylZCjwG7wBYJExAb
  EySk6e8V95NZ8mn7hUwRXt6A9WAjkTiBYvS6kSgQkEyT7yztI0YZlVhnfjKSmp
  -XW_SQ9ewoef1QJSlOFN5JvJpeIFRhbU0qKU_KjcA"}],
            "PayloadDigest": "TvJtBRMu666cE0mEeWzbQ-HkM2-a9EM-GxZQ8VgYVx5KL
  Bp0wsWoD6IlgV6emCT_xk912EtNZ9_AQxaWRdrnvA"}],
        "ServerNonce": "i2BYRC7rEVq1jH4PJi2Y4g",
        "Witness": "NVVS-2JXM-GPBU-JIBZ-LO6G-3ZSQ-LHTP"},
      {
        "MessageID": "NBRN-CPNT-CPDZ-NZFK-TGJP-CRBK-PDEL",
        "EnvelopedMessageConnectionRequest": [{
            "dig": "S512"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiIsCiAgICAgICAgImN0eSI
  6ICJhcHBsaWNhdGlvbi9tbW0ifSwKICAgICAgImV3b2dJQ0pRY205bWFXeGxSR
  1YyYVdObElqb2dld29nSUNBZ0lrdGxlVk5wWjI1aGRIVnlaU0kKICA2SUhzS0l
  DQWdJQ0FnSWxWRVJpSTZJQ0pOUTB0TExUTXpVbGt0VVRaVlZpMU9SMVZCTFZsT
  ldqUXRWMHBNTgogIFMxQ1NrdEdJaXdLSUNBZ0lDQWdJbEIxWW14cFkxQmhjbUZ
  0WlhSbGNuTWlPaUI3Q2lBZ0lDQWdJQ0FnSWxCCiAgMVlteHBZMHRsZVVWRFJFZ
  2lPaUI3Q2lBZ0lDQWdJQ0FnSUNBaVkzSjJJam9nSWtWa05EUTRJaXdLSUNBZ0k
  KICBDQWdJQ0FnSUNKUWRXSnNhV01pT2lBaU1VbENTRFJ3UnpWRE1ETnljVU5UV
  G5wQmIyNU5Ta2N5UzNkclZVbwogIDRORGhHWjJ4SVlVMDFSMnhJT1d0TFZuVmZ
  Va3d6UndvZ0lIZE5XVXBxTkd0Vk0ycHNjbFU0Ym1jdFFtNXhVCiAgVFJ6UVNKO
  WZYMHNDaUFnSUNBaVMyVjVSVzVqY25sd2RHbHZiaUk2SUhzS0lDQWdJQ0FnSWx
  WRVJpSTZJQ0oKICBOUWtOWkxVYzFObGN0TlV4QlN5MVVWMHRCTFRkSVZUUXRSR
  EpOVUMxWVJVcFdJaXdLSUNBZ0lDQWdJbEIxWQogIG14cFkxQmhjbUZ0WlhSbGN
  uTWlPaUI3Q2lBZ0lDQWdJQ0FnSWxCMVlteHBZMHRsZVVWRFJFZ2lPaUI3Q2lBC
  iAgZ0lDQWdJQ0FnSUNBaVkzSjJJam9nSWtWa05EUTRJaXdLSUNBZ0lDQWdJQ0F
  nSUNKUWRXSnNhV01pT2lBaVUKICBFZGFaRUp4ZGpCVVdUQlFVMU01TlRGaVJXW
  kxaMmxJWkVac1JqUjVia3BITXpoa2FFRktOa1ZhTFhCd1RsRgogIG1UUzFGVHd
  vZ0lGWlVTamxRUzA5ZmJWSnZPV3czVm5SRk5FOTRUVEZYUVNKOWZYMHNDaUFnS
  UNBaVMyVjVRCiAgWFYwYUdWdWRHbGpZWFJwYjI0aU9pQjdDaUFnSUNBZ0lDSlZ
  SRVlpT2lBaVRVRkZRUzAxTkROTkxWSTNTVW8KICB0UWtOWVV5MUhUekpCTFU5R
  1VrRXRRMUpXVmlJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SQo
  gIGpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ
  0FnSUNBZ0lDQWdJbU55ZGlJCiAgNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0l
  DQWlVSFZpYkdsaklqb2dJbTVmYzJReloycEJaazVIVEZaMFQKICBqaElaRzVEZ
  G13eVZtRkNWMlZUYWxGUWNrSlVNRFZDU1RkSloxWTJXV2hNYTFveWJqWUtJQ0J
  LU21vMldYWQogIDBNMVpWTkdKcVVHZEthVTR0U2kxdGEwRWlmWDE5ZlgwIiwKI
  CAgICAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgInN
  pZ25hdHVyZSI6ICJDbWtQZ2w3d1Z3UU5WMFhRTUpmZnRIaEo3VHRyY3ZZNVdJN
  XBpZlY1TFhuZlFqajA4CiAgUjhKMTcyeGV2RmFKaWlscGxUSUZnNkFlTk1BYnJ
  GbzZnX3JvWUV2a012djEzc0hUelZzamxxWGxNbWVzV1AKICBLZHV2Tld6NWhaa
  nN5SmNXNU9hTW5wb0tyNXlWZV9aMmlrR0t1cXk0QSJ9XSwKICAgICAgICAiUGF
  5bG9hZERpZ2VzdCI6ICJQSzVsSUFJZGJXME42cjRmV2Z0LWtha1pXRXEwZTZFN
  ThJVmFSY3VGd0cydHoKICBZZF9Zb3ZMbDZyN2xaOS1YdFd1aE9xWUgtZE9henE
  5V3F6N2hXdTBLUSJ9XSwKICAgICJDbGllbnROb25jZSI6ICJ6eVAwcHpkUVVGd
  nRPZTZYaFJsbzlBIiwKICAgICJQaW5VREYiOiAiTkNRVi1JQ0JKLU5IUTctU0Z
  UTi1ZTSJ9fQ",
          {
            "signatures": [{
                "signature": "pRk4u4fBvzlrDCmnI1Yo6rvfeReiKWDuWylZCjwG7wBYJExAb
  EySk6e8V95NZ8mn7hUwRXt6A9WAjkTiBYvS6kSgQkEyT7yztI0YZlVhnfjKSmp
  -XW_SQ9ewoef1QJSlOFN5JvJpeIFRhbU0qKU_KjcA"}],
            "PayloadDigest": "TvJtBRMu666cE0mEeWzbQ-HkM2-a9EM-GxZQ8VgYVx5KL
  Bp0wsWoD6IlgV6emCT_xk912EtNZ9_AQxaWRdrnvA"}],
        "ServerNonce": "i2BYRC7rEVq1jH4PJi2Y4g",
        "Witness": "NVVS-2JXM-GPBU-JIBZ-LO6G-3ZSQ-LHTP"},
      {
        "MessageID": "NBPK-F7VR-TIUK-O3Z4-VD66-CDIM-TMZL",
        "EnvelopedMessageConnectionRequest": [{
            "dig": "S512"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiIsCiAgICAgICAgImN0eSI
  6ICJhcHBsaWNhdGlvbi9tbW0ifSwKICAgICAgImV3b2dJQ0pRY205bWFXeGxSR
  1YyYVdObElqb2dld29nSUNBZ0lrdGxlVk5wWjI1aGRIVnlaU0kKICA2SUhzS0l
  DQWdJQ0FnSWxWRVJpSTZJQ0pOUWtkQkxVSTNWMWN0U0RJM1RDMVRTMUJHTFVNM
  1ZVMHRXalZKVgogIFMxWE5sbFpJaXdLSUNBZ0lDQWdJbEIxWW14cFkxQmhjbUZ
  0WlhSbGNuTWlPaUI3Q2lBZ0lDQWdJQ0FnSWxCCiAgMVlteHBZMHRsZVVWRFJFZ
  2lPaUI3Q2lBZ0lDQWdJQ0FnSUNBaVkzSjJJam9nSWtWa05EUTRJaXdLSUNBZ0k
  KICBDQWdJQ0FnSUNKUWRXSnNhV01pT2lBaWExZExNMDlHTTNCUWNqUlNjMDlpV
  0Y5SVVGOWhRVVV5TnpoUFF6RgogIHdWMHgxYzA0M2FrMXVNa2xTVFRkWmJEY3p
  VMlp2UWdvZ0lHSmlUelZhVFdadldUVnZaa2MzVFVkM2MzSjZTCiAgWFpCUVNKO
  WZYMHNDaUFnSUNBaVMyVjVSVzVqY25sd2RHbHZiaUk2SUhzS0lDQWdJQ0FnSWx
  WRVJpSTZJQ0oKICBOUVVwU0xVVlBTbGN0TlVWQ1R5MVRWVFpNTFRKTE4wUXROa
  3hZUlMwelZrSldJaXdLSUNBZ0lDQWdJbEIxWQogIG14cFkxQmhjbUZ0WlhSbGN
  uTWlPaUI3Q2lBZ0lDQWdJQ0FnSWxCMVlteHBZMHRsZVVWRFJFZ2lPaUI3Q2lBC
  iAgZ0lDQWdJQ0FnSUNBaVkzSjJJam9nSWtWa05EUTRJaXdLSUNBZ0lDQWdJQ0F
  nSUNKUWRXSnNhV01pT2lBaWUKICBHWnVRalphVGtKamJIbDBiV3QzTmpGUU9FT
  jRaVGRCWldkM1NXRk9UMGg1UkZWRFVHaHVSMUZuT1dKT1IwcAogIE1NRUZzTUF
  vZ0lHaFJTekJ4V1dSV2EydHFRMEpwYVRGak5FRTJlak10UVNKOWZYMHNDaUFnS
  UNBaVMyVjVRCiAgWFYwYUdWdWRHbGpZWFJwYjI0aU9pQjdDaUFnSUNBZ0lDSlZ
  SRVlpT2lBaVRVTkpOUzFEUzFSSExVTkpTbEUKICB0VkVKVldpMVZVVmhFTFZCV
  VFVRXRWREpKTnlJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SQo
  gIGpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ
  0FnSUNBZ0lDQWdJbU55ZGlJCiAgNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0l
  DQWlVSFZpYkdsaklqb2dJbEpZTVU4d1dVSkdlRTVzY21WR2QKICAzRnJlSFprY
  lZaeGNFUjRkVTFqWkhKVGQxSkpjM1I2YXkwNWFucFNURVpYYkdsb1RrY0tJQ0J
  JV2tjM2RrYwogIDBTbk5WUzBGNFdGZzVPVU5RZERONmEwRWlmWDE5ZlgwIiwKI
  CAgICAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgInN
  pZ25hdHVyZSI6ICJRQkE3dDRBWXRMb0RUalI4MDFGcTZIZ2xacHVpUG1JODFxV
  m1vUFpuUFQ2WUlEWXJQCiAgb2xZX1p4TUZNWHZQdXY2NUFycXB5TDZZTy1BZzN
  zOEZmTDFIZEc3UDJUSHplc25ZVDVkVUs1ZUlZTzZyUHMKICByLVlDcVhVN2FtW
  kRRUUlpd3ljXzlpc3g2M01lcXlVWTNtd0tBNGcwQSJ9XSwKICAgICAgICAiUGF
  5bG9hZERpZ2VzdCI6ICI0OUVMUUI0N3R3bnBQb2NEVDRhZTdMZHV2SE5hd1oxS
  E9Ed2I3NTVyblMxY3kKICBFUnJnbWFYeDlUSm1KWk5BZlg1RHVLaFZiU09NeVU
  1SUNxMjB1U0RQZyJ9XSwKICAgICJDbGllbnROb25jZSI6ICI3Y3Z0aVdfeWc2Q
  TlNcE5uRlVPNFZBIn19",
          {
            "signatures": [{
                "signature": "Kk-n-tGjCIVFR8phLjf4I1hcqaPPCHMRsZmhU5NWO6K8kg9dS
  _XEqTyXO54dMZPsD3shCgPbyk4AjrfoN3IAAUWr2hdq8-i3JPtaP9D7rWoGa_D
  UnwZRkaWl9GU6h508KeDJmbirsfiHxjm7mCuAzhwA"}],
            "PayloadDigest": "zb7dHB5SCSC4P0QBOI5nS6RGDHIszHDfN_-qEGoSwiQGz
  UZzGDlWT5wpMqq__wDfJlaz4DZCgvIpbpjrntTqfg"}],
        "ServerNonce": "yDjmc4OWYJKMpZctsIMeqw",
        "Witness": "46J6-M7HD-VH7E-CJ7I-EGM4-PNHS-HLD6"}]}}
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

