

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
````

Specifying the /json option returns a result of type ResultSent:

````
Bob> message contact alice@example.com /json
{
  "ResultSent": {
    "Success": true,
    "Message": {
      "Sender": "bob@example.com",
      "Recipient": "alice@example.com",
      "Reply": true}}}
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
````

Specifying the /json option returns a result of type ResultSent:

````
Bob> message confirm alice@example.com "Purchase equipment for $6,000?" /json
{
  "ResultSent": {
    "Success": true,
    "Message": {
      "Sender": "bob@example.com",
      "Recipient": "alice@example.com",
      "Text": "\"Purchase"}}}
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
        "Sender": "bob@example.com",
        "Recipient": "alice@example.com",
        "Reply": true},
      {
        "MessageID": "NBMQ-MJWA-P26S-QOJZ-KF4Y-5KMX-ZTHF",
        "EnvelopedRequestConnection": [{},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6
  IHsKICAgICJTZXJ2aWNlSUQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIk
  VudmVsb3BlZFByb2ZpbGVEZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUx
  MiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0
  FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lD
  SlZSRVlpT2lBaVRVTlNNeTFDTWtoVExUSkxVa1F0UVRSR1dDMWFTCiAgVlpDTF
  RSV1RGY3ROVWRNVVNJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6
  SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2
  dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNB
  Z0lDQWlVSFZpYkdsaklqb2dJbXRaVEZndGVXbFlOVFZRYzI5UWMxZGFVVWhZYU
  ZKCiAgUmJ6RjBNR1kyZEhOTmJucHVVVGR0Tms1M2IwZERVbWxTWDJ0VU4wUUtJ
  Q0JoYURsUlpHVTVXbDlpUnpORGMKICAwUlljRlI2ZDNKYVdVRWlmWDE5TEFvZ0
  lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlp
  T2lBaVRVSkpSaTFWVUZOWUxVcFZRVU10Ums5RlNDMHpNMFZQTFU4ME0xb3RSRl
  paVXlJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3
  b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSU
  NBZ0lDQWdJbU55ZGlJNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZp
  YgogIEdsaklqb2dJalo2VjBZeVFtMVNSbWh6V0U5aFlrbzFTRXhvU2s5TGIzZG
  5Na1V6Vlc1cVZWTllWakJ5YW5OCiAgMGFrSlNURkl4YTNodFNGTUtJQ0JRWDNS
  Q1NFRk5aQzF6TkUxMGJWY3lSMVptV1VSWlMwRWlmWDE5TEFvZ0kKICBDQWdJa3
  RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJ
  azFDVWtrdFdUVQogIHlOUzFIUjFKU0xVSkxWRWt0U1VaQ1R5MVRWRlJUTFZWVl
  YwSWlMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNL
  SUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0
  EKICBnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlt
  eHBZeUk2SUNKM2F6ZHVialJvUgogIHpSYWFtOXdUbXhxT0daUk0xSkpPRk5LUV
  ROTVRrc3dZblpLU0hsS01ITldlRXRUZW1jeVZsOWZMVnBqQ2lBCiAgZ2MyVlFj
  bDg1UXpkbGJ6VnROV0ZqU25sdFZrVm9jVU5CSW4xOWZYMTkiLAogICAgICB7Ci
  AgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1
  MTIiLAogICAgICAgICAgICAia2lkIjogIk1DUjMtQjJIUy0yS1JELUE0RlgtWk
  lWQi00VkxXLTVHTFEiLAogICAgICAgICAgICAic2lnbmF0dXJlIjogIi00RDBn
  NE5iU2xvRnRkWExnMG1CaEpjSEJpOHRkbmhoaldib1F3b3VNZ1ZBaFR4SGsKIC
  BxRkpLMGMxcFlEVnlyVjFPYlEyMGNURXN2MkFmY1lmYW42T1I1Q1FubjZ0Z1J2
  WHMydzJrdWNNTXJpd0twbgogIFRxelJlWlFjUE1HODF3LWZtVHd2Qm81Vnl4al
  FyUDNHdHBsRERuUm9BIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIk94
  clliQ2x4R2NnYldlZEFJSXVwdWRfVDA5UFU2dzdUZDQ5bmRuNlhKcTJ1RgogIG
  1pSGtJWWppeVc5TnNrcG5DLWlNVVViZW9NOXItUmxvc1p6SldSYzNBIn1dLAog
  ICAgIkNsaWVudE5vbmNlIjogInVnQ25MeGZRQ0xvODUzRFYyZU9keVEiLAogIC
  AgIlBpblVERiI6ICJOQU9DLUVEUlQtSkFVVy1TRUMyLTZJIn19"],
        "ServerNonce": "VO2N0fOBWuGnh9J0dspSVQ",
        "Witness": "V3L2-I4GR-NYYT-FL6B-PR6Z-ENPF-GIJN"},
      {
        "MessageID": "NB4R-GVWN-KZRU-5EQ4-444I-3FGG-67FL",
        "EnvelopedRequestConnection": [{},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6
  IHsKICAgICJTZXJ2aWNlSUQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIk
  VudmVsb3BlZFByb2ZpbGVEZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUx
  MiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0
  FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lD
  SlZSRVlpT2lBaVRVRlhXUzB6UTFaQkxVTmFWRkF0UnpaRVZ5MVdSCiAgVVZGTF
  U1VVMxa3RXazlEV1NJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6
  SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2
  dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNB
  Z0lDQWlVSFZpYkdsaklqb2dJbTVIWlcxdU5WQkVVbXM1YWxad1gxVmZOWGhCWm
  5rCiAgNVFsazRWRUowVlRFM1pVNUdRemhaWHpGWFRUWnVkelV6YWpGeU1UUUtJ
  Q0JVWkZwYVZUbDVjams0VmtGWWIKICAyaG5abFpmVEVSTFYwRWlmWDE5TEFvZ0
  lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlp
  T2lBaVRVRldTaTFSVmxSQ0xWWkJUMDh0UjFOUFJDMVdVa3BFTFZCS1dETXRUVE
  5OVWlJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3
  b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSU
  NBZ0lDQWdJbU55ZGlJNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZp
  YgogIEdsaklqb2dJazVHWVZGeExTMVpaakZ0VEdnMFFUWTJiMnhxZFhKSVFWOH
  hOMFpETWtNelFVbGZZV3BXU200CiAgMk1ERnFVMFExZDNSVmRXMEtJQ0JZYWpW
  TmJtaDFjMUptTUZrd1gyMVNWMWhQV1daeWQwRWlmWDE5TEFvZ0kKICBDQWdJa3
  RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJ
  azFDVERVdFIwOQogIFNWeTFETTFRM0xVTmFSRlF0VUVGWlZ5MUxTa3hSTFU4el
  dsY2lMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNL
  SUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0
  EKICBnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlt
  eHBZeUk2SUNKUFNXUkJPV2s1UgogIDBoaVNUVjZZbUZtYTE5cE1ISnNhbGhZUj
  FOa00ydzRVa3BtTWtkclpraDZNRXRKWjFGalNteDBZa0oxQ2lBCiAgZ1MyMDVh
  SEp3YVZwR1VpMVdUbUpEYm0wd2VFOWxTR1ZCSW4xOWZYMTkiLAogICAgICB7Ci
  AgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1
  MTIiLAogICAgICAgICAgICAia2lkIjogIk1BV1ktM0NWQS1DWlRQLUc2RFctVk
  VFRS1OVEtZLVpPQ1kiLAogICAgICAgICAgICAic2lnbmF0dXJlIjogIkNBTDRY
  MEtsSDcwT0NTUTBGVUx1OVFIdlZ5SGpwcF81aG1vWHNXYVFGOW5SbU9JNmsKIC
  BwMkhxakhhUzFKaGVwX1QwcVFUNDdhd2xxU0FqYU0zVnJ2bXd6RnVVeEdySW1R
  eGtFYjQ0V0ZpdWRWOVFlWAogIElFemVSdTNRd2JKTldqYk5mVjA3dXFSUnNfam
  E4NUVGX3g0Tk5peFlBIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogInpI
  WFpSMUJvTEVNV3ZaVUVfR2VZTmwxcVI1cjQzSWEwTEZJOWRMWkZpOGVKYgogIE
  swd2Y2b3BUTGpMZ3ZNR0VzaDZHX0pCMXh5dk14azRIeWVYc3hXQk9RIn1dLAog
  ICAgIkNsaWVudE5vbmNlIjogIkJJVXhHeV84VzdCbkc1TF9PWERUaWcifX0"],
        "ServerNonce": "EFzzlc2pCIiu9yMIc5FXIQ",
        "Witness": "EGTX-LUIB-OD67-DA6O-ZYQT-OPXH-NLMR"},
      {
        "MessageID": "NBSG-GQEN-DBOT-64HY-IA6X-QI6Q-6CG6",
        "EnvelopedRequestConnection": [{},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6
  IHsKICAgICJTZXJ2aWNlSUQiOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIk
  VudmVsb3BlZFByb2ZpbGVEZXZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUx
  MiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0
  FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lD
  SlZSRVlpT2lBaVRVRk9VUzFMVWxsTkxVNUpTVmN0TWxGRlV5MUJNCiAgME5ZTF
  VkWFdFRXRRVTVZUnlJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6
  SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2
  dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNB
  Z0lDQWlVSFZpYkdsaklqb2dJa3gzWkVVdFdEUlVjMjFyTVZoNVVHeDJaa2RFZD
  B3CiAgM1RqSjRWRUZYTjNsa01XUlVlblJCTm5adFJ6ZHlRVE53VDJSQ1RrUUtJ
  Q0F5Y25GcldWTnFlblp0TVMxblEKICBqQmtObGMxWm5sWWMwRWlmWDE5TEFvZ0
  lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlp
  T2lBaVRVSkJVQzFNVWxOWUxWSkpRbEV0VWxCWVJTMDJUMEkxTFRWSk5Fd3RVRn
  BSVXlJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3
  b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSU
  NBZ0lDQWdJbU55ZGlJNklDSkZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZp
  YgogIEdsaklqb2dJbmwyVVVaaVQzbExSRWRzZEhwQ1QwWnhUbFYyV2s1dU4yVn
  RjblpTVTFKbk56WnljUzFvVkdzCiAgd2NHdGZRMk4zTFhkcE1YUUtJQ0JWU0VG
  UlpGZEhUbXhhTkMxV1pHMHRVbEJxY2kxaVIwRWlmWDE5TEFvZ0kKICBDQWdJa3
  RsZVVGMWRHaGxiblJwWTJGMGFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJ
  azFCU2tZdFJqTgogIEhUQzFSVVZKUkxVOVRSRFV0V0UxWVRTMVBTRW8yTFRWVk
  0wZ2lMQW9nSUNBZ0lDQWlVSFZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNL
  SUNBZ0lDQWdJQ0FpVUhWaWJHbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0
  EKICBnSUNKamNuWWlPaUFpUldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlt
  eHBZeUk2SUNKamFUaFVjRzU1VgogIGxsMlJEUlpabHBTYmpCS1pXbGlNVEJzZV
  ZoU01VZFplVTVOTWpacldtdERRMjFoUm0xS1QwUjZXbkkxQ2lBCiAgZ1VrcG1V
  VVJpTTBGamFEUTVVbXhLWVZkRVgwVnBla2RCSW4xOWZYMTkiLAogICAgICB7Ci
  AgICAgICAgInNpZ25hdHVyZXMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1
  MTIiLAogICAgICAgICAgICAia2lkIjogIk1BTlEtS1JZTS1OSUlXLTJRRVMtQT
  NDWC1HV1hBLUFOWEciLAogICAgICAgICAgICAic2lnbmF0dXJlIjogInRZNDBy
  bXlRaTc5Q2s4QklXZmJ6d2l1ZVhYUXMwRDdxeFcxdEIzNjMtR19ELXVKZXkKIC
  BJX0sxQWlkNXlPZllDYzU1aUVCWTJ1OENwMkFJWUNSenlkYTRfSzJaWDRQQ01L
  MldMbkdiZEVKTDBFajR3cgogIHYxX0RCekI2UzMwcHgzczgtM3BKTkRJQU5xZ1
  lRSF82UmRCVldGaFlBIn1dLAogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIlZ1
  bkNxUkdZWndId3ZsN09NLS1xZFJ0ZFpOcDRmQy1taUh5UjBwbERzbmp2bwogIG
  tRZlBxanlqbWNwa2dVeHJHT21udGJqNXdMSV9sYm5wWEdlTDJreWxRIn1dLAog
  ICAgIkNsaWVudE5vbmNlIjogIkNud09FSE1qZlpOdDdjcklxU1ZWZVEifX0"],
        "ServerNonce": "s3GY8Luy35IeuYKlZ7B3Cg",
        "Witness": "42B2-7POX-GMLW-6EBC-GKAI-7NDC-7226"}]}}
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
      "Sender": "alice@example.com",
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
      "Sender": "alice@example.com",
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

