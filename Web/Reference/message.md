

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
        "MessageID": "NAVB-HQ2H-AD4Z-O5OR-72E3-4QGY-WWMR",
        "EnvelopedRequestConnection": [{
            "dig": "S512"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiJ9LAogICAgICAiZXdvZ0l
  DSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWt0bGVVOW1abXhwYm1WV
  GFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZSRVlpT2lBaVRVTkRNaTF
  PTkVOU0xVbFdSVmN0TlVoU1Z5MUpUCiAgRnBDTFZwTFYwNHRVVkpJV2lJc0NpQ
  WdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0EKICBnSUN
  BZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55Z
  GlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2d
  JaTFvWTBsSmFrMVpSMHQ0UzFWQ1ZESnVOMjVHV1d4CiAgdmNuaDFla2N6VGxkc
  WNIZERMWFJhTkhwV1RGbFJSbDkxZEVwaFVIWUtJQ0E1WVZrNVMyVXRXR2M0UjF
  BeGIKICBqTTBZazFCWkRCaFIwRWlmWDE5TEFvZ0lDQWdJa3RsZVVWdVkzSjVjS
  FJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlpT2lBaVRVUkJOUzFhTWxVeUx
  WTlhWMEl0U1VwV05DMVBNa3d5TFZGQ1RrRXRSRGMxUWlJc0NpQWdJCiAgQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0p
  zYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDS
  kZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYgogIEdsaklqb2dJbGhPWkZ
  FMWRqTk1URFJMT1Rka2QxcE5kREJWVVVSRGVVWlNMVWRhTVdOa2FERjBiRXBvZ
  EdoCiAgbU1UaExWMGxpYzJWQ1ZtY0tJQ0J3WVd4UFgzRm9iR05PYVdkc2JqVmx
  MVzFPVTAxMFMwRWlmWDE5TEFvZ0kKICBDQWdJa3RsZVVGMWRHaGxiblJwWTJGM
  GFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFFU1VndFJWRgogIE1TeTF
  VUmxnekxWQktUMDB0VDA1WlN5MUNRMVpTTFZCWlZVRWlMQW9nSUNBZ0lDQWlVS
  FZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJ
  HbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKICBnSUNKamNuWWlPaUFpU
  ldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKcVpGWm5TbVJ
  5WQogIG1kSWVUTndVWGxPTmpsclJHc3lSVTVxYmtnNGFYVklhRGt0VGtsaVluV
  TFhWHBrWVY5M1UwUnVXREpLQ2lBCiAgZ2JqbFlPWFpyUzI5R01HRXlaR000VGt
  ONVMwOTZSMmRCSW4xOWZYMTkiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZ
  XMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1MTIiLAogICAgICAgICAgICA
  ia2lkIjogIk1DQzItTjRDUi1JVkVXLTVIUlctSUxaQi1aS1dOLVFSSFoiLAogI
  CAgICAgICAgICAic2lnbmF0dXJlIjogInFXWTJLT3FPNE9RYnpIMnNnUEZJN3l
  iQnhZdWNqeVhrbEtqX3FYbENqc3V5RUNYN3UKICBpazFiNmRiY09ycGNadkIxM
  i1ldVI4WXVSV0F3azc1cC1sUnBlcDlaUERaMDc3UkVpWG4wajJXX0haR3ZmTgo
  gIEZ6UzUwRXFyZjdLNlNKU0dDdE5ZRjVsam5BaGh1WmZQQmQ5d0EtdzRBIn1dL
  AogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIklqZFNrRE5zbFVRRklGbHg2eEx
  BcHY3dEZGVXJyUjNMSHYzSmd3ekhGZVpodgogIFFLRGR2MklaQ1gtcFJxZUFkc
  HEzUEhUdjRsX0hObWlfY3BoVzNZQnhBIn1dLAogICAgIkNsaWVudE5vbmNlIjo
  gIkNsc0NjQmtWcUwzeUhrT1h3V19QaVEiLAogICAgIlBpblVERiI6ICJOQVhSL
  VRSMzMtM0lLSS01SDRJLUNJIn19",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MDIH-EQLK-TFX3-PJOM-ONYK-BCVR-PYUA",
                "signature": "Y1SPyDaevkHiHH6Qm9EOW1vWHwbbP7nnWkZ2qtdWucBakeMPF
  bphN4x34btwvoX9-bb-hB2IU-CABiJyQPI7153HzgvXlLgetZyYqeEN0VuxkLT
  RZ2nXWpj926iFf_QvKkkoRqwiQxr0tZpK5gWuHwsA"}],
            "PayloadDigest": "SPmPqaFHYNTAXB1t_laANmXXc5bO4N3w5Zwk0gInMnnID
  uB5orKgyFBkPj3zORDsLCt0I241MlELUBFH67NI9A"}],
        "ServerNonce": "l-IfJ6Q2HytKM3ag0PCdGQ",
        "Witness": "2FSZ-K42N-PYOQ-7UAG-FNKY-XAN3-FKX6"},
      {
        "MessageID": "NDGB-SFHS-673S-4BHV-VUEO-YXC6-L3HJ",
        "EnvelopedRequestConnection": [{
            "dig": "S512"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiJ9LAogICAgICAiZXdvZ0l
  DSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWt0bGVVOW1abXhwYm1WV
  GFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZSRVlpT2lBaVRVTkJTUzF
  VVlVOWkxVTlpSRUV0V1VnMlV5MVhSCiAgVWxITFVSUlZVVXRUVmhFV2lJc0NpQ
  WdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0EKICBnSUN
  BZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55Z
  GlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2d
  JbWhmYmtsd01uQkNhak51TFZJNFNubGliMHhGZGxoCiAga2VHaHJSMHhZVW1JM
  lducFVZak5KU1VKQ1NtaHRXVkJtYzNKSU9Hc0tJQ0JvZFVwd1lucHBTRkJ6TWx
  aM1cKICBYbHRhamxoWTBkVmIwRWlmWDE5TEFvZ0lDQWdJa3RsZVVWdVkzSjVjS
  FJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlpT2lBaVRVRk9TQzFEVmtOSUx
  WVklUelF0UlZkUU15MU5XVkJKTFRSSVVFY3RNMWRFVGlJc0NpQWdJCiAgQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0p
  zYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDS
  kZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYgogIEdsaklqb2dJbkJsWTN
  SV2MxZHVNalZEV1UxQk5XTXdYM0JpT1U5MFRuTm5aVTVIUlU1SVRuSTVTRVp4W
  DFnCiAgNWQwaExTMVp6YmxJeVpESUtJQ0JLV1VGclYzRTVUME5sVVZkaGNIbGZ
  SbTF1VjNWTFdVRWlmWDE5TEFvZ0kKICBDQWdJa3RsZVVGMWRHaGxiblJwWTJGM
  GFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFEUTA4dFNUUgogIFNWUzF
  UUVU5Q0xVdFpSRkl0VUZGWFJDMUlObGxDTFVjMlNEY2lMQW9nSUNBZ0lDQWlVS
  FZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJ
  HbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKICBnSUNKamNuWWlPaUFpU
  ldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKak1ubHdkVUV
  0TwogIFd4WlUzRnVha0ZJYm5oR2VDMHdSbEZzUWtaWGREUlJVVGRHYUZOUWRUW
  kdNbEJ4VG1OaFJFZFpjbkJrQ2lBCiAgZ2VEQkVZMHRzYTNwQlZsRjZhVlY1V2t
  3Mk9ESkZRVXRCSW4xOWZYMTkiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZ
  XMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1MTIiLAogICAgICAgICAgICA
  ia2lkIjogIk1DQUktVFVDWS1DWURBLVlINlMtV0VJRy1EUVVFLU1YRFoiLAogI
  CAgICAgICAgICAic2lnbmF0dXJlIjogImtmQXVYWVRyd2dHOGpkVDRIZnVGY0t
  RNVZ0OW93bjZSUmZBR1pkUmEtWThvNW9kWlQKICBsTWJVNmZ3Z3B3OXRoSGwtV
  XRHVDNUVFpwMkF2R2Q0eTh5RVFoTEJmb2k3TUxUbDZ3UVZWN3JySFhUMVhzSQo
  gIDA3YWtfQjdCMFBYT09zb1MwR1dBRThwUzBUb0pYVkhlQW1kVW1nUlVBIn1dL
  AogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIlJHcWhoXzFQdWxZS09PWkpFVmt
  yc21hc05pV09wbGdiME1EVGt6NXlPTWJzOAogIFRjS0sxWDhYOURMMXhoMERBe
  DBiZnJNNm9DRjlQZVVLNnA5ZmhlS1pnIn1dLAogICAgIkNsaWVudE5vbmNlIjo
  gImtkT2ZjTHRpNUUybnhpc1E0MkNtaHcifX0",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MCCO-I4RU-SAOB-KYDR-PQWD-H6YB-G6H7",
                "signature": "PVYwovUmo5CwqmEW9kf33cA1bDBlrtOS47YHl9YGrGyzvyq-f
  WC2h_eI98ycozemJ2d7bjJXTFyARdADIgUnzIMQouL9nxxySFJ2l6vjXQXqOls
  1gY7IwkWpwh2AuErKQ7z3qbPiAJIEAc7rJqXUHiwA"}],
            "PayloadDigest": "Gvh68RnlXAo3q0A8-pR-SLNY8ALxrHmGUhR6_-f7ZomZF
  vZoBJpD69h1pt8eBdp_GFB0tf8TSti2fr2eg4Zc6Q"}],
        "ServerNonce": "YS8TnBcplOsc5dizcRJ69w",
        "Witness": "FYLI-3EVO-UEIJ-UYXQ-URUZ-RK5N-JISL"}]}}
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

