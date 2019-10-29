

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
        "MessageID": "NAUN-ZAWZ-KWQH-ISV3-SPAH-AJYZ-ZCME",
        "EnvelopedRequestConnection": [{
            "dig": "S512"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiJ9LAogICAgICAiZXdvZ0l
  DSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWt0bGVVOW1abXhwYm1WV
  GFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZSRVlpT2lBaVRVSmFRUzF
  FTlVjMUxUUTJTMDh0V0U1SlJ5MWFSCiAgRTFFTFVsYVZWRXRVVEpaU0NJc0NpQ
  WdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0EKICBnSUN
  BZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55Z
  GlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2d
  Jamg1Tm1ad1oyeHFSR2MzYlhWNWVIaFpORFZIUVdOCiAgZlYybHdaWGh5YWs5V
  U0yUTFaMUJFYTNoMVJtRkxiRmRuYzJrMFduVUtJQ0F4YUVsc2JuRkhNemx1ZFh
  WUVoKICB6Qk9iRmRoV0dNd2IwRWlmWDE5TEFvZ0lDQWdJa3RsZVVWdVkzSjVjS
  FJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlpT2lBaVRVSlNOaTFRV2xKVkx
  VRTNTVE10UVZBMFV5MDNUVlZETFV4VVRGUXRVa1pPVENJc0NpQWdJCiAgQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0p
  zYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDS
  kZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYgogIEdsaklqb2dJazA0TjJ
  sS09EVk9VMmRXZFVrNVgycEtjakp3V1VsZlN6TlhXVE41VEU1V1FVVm5kbmxtY
  UhwCiAgNGRGbHlTWFpyVjA5RWR6VUtJQ0JOVmpJdE1uYzNURVZGTVMxU2ExaEV
  iRkYyWkZZNFMwRWlmWDE5TEFvZ0kKICBDQWdJa3RsZVVGMWRHaGxiblJwWTJGM
  GFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFETlVzdFVWbAogIENTeTA
  yTjBkTUxVRkxWell0UnpOVFN5MUxNbFJWTFZsV1NrOGlMQW9nSUNBZ0lDQWlVS
  FZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJ
  HbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKICBnSUNKamNuWWlPaUFpU
  ldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKc1ZXUm5ZMFZ
  CWQogIDNvMmJHTkdWRnBmYldkSFZYbHhjRk5KU0ZBM2NtVnpabU5IV2xGeVdsU
  mZSamRxZG5oYVQyZHFSMnM0Q2lBCiAgZ1lqbHZYMnRIWkVjMmQwMUVlamhJWm5
  GVU0xVlJPRFJCSW4xOWZYMTkiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZ
  XMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1MTIiLAogICAgICAgICAgICA
  ia2lkIjogIk1CWkEtRDVHNS00NktPLVhOSUctWkRNRC1JWlVRLVEyWUgiLAogI
  CAgICAgICAgICAic2lnbmF0dXJlIjogIm1kQ29uV2ZnM01XRGJobFl6R2VGN21
  5em1kN24tZXZFTjBHOEFKYmtlM3VDcFhkQ3QKICAxYVBiZGpVdy1CS3liUHpkV
  VotRXlNXzNEd0FoM1hmZUZRSlVLeklraThiT193UU54OWQzT1pJV2RRWFgxago
  gIEhfRXM3SVhFdXp3eDlOOWJaeE9rblEwX2ozWXpVd3QwLWhjSzJBQ29BIn1dL
  AogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIm1jODZmUFJZRFhsYzJPX2JhTHh
  ZUmQ3SENmM2txaTZZTVdibzdEUElETjdTawogIFNEdDFIaTRlWWt5d3NiN0Vjd
  1ZIb29BUnRKanVvWjJITFpmYnM1OXdBIn1dLAogICAgIkNsaWVudE5vbmNlIjo
  gIk1OZkZldEpjQ2lSWU1pcHlDeW4tR3ciLAogICAgIlBpblVERiI6ICJOQlg1L
  UdNUkUtNUlBSS1TM1UyLU5ZIn19",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MC5K-QYBK-67GL-AKW6-G3SK-K2TU-YVJO",
                "signature": "TwS-BFZHslykOVgpW3k2uKZORi-AhBprHXpOIOYy4KAmy41Y6
  _bKuk8-TjnaoqJRJpP9BNL8skaAbKgzJ0JYbbBDUajhqD77zWuY_CrDYVpuogQ
  Vt_qEng1mENzPa7M9MRMfIChu8ETp4tZh3oDzLQcA"}],
            "PayloadDigest": "GGWX2esR6KPBby0Hp5aB-qGWFFlIpRDZbr4uFk0SYHyz1
  dv1-71eycMSUB3yNvVV-Ud-_5NUsv-AZCHWlGfoUw"}],
        "ServerNonce": "ZKQhtaVUvaHL3Qpeek1bow",
        "Witness": "ADQM-XS4H-IV7T-XDGY-YAGW-BWCX-6WMV"},
      {
        "MessageID": "NAWO-FRYR-JFVG-EBIU-FCOZ-B7KC-KDBY",
        "EnvelopedRequestConnection": [{
            "dig": "S512"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiJ9LAogICAgICAiZXdvZ0l
  DSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWt0bGVVOW1abXhwYm1WV
  GFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZSRVlpT2lBaVRVUlBOaTA
  xV0V0U0xVSktUVkF0VUVOWlRDMUlOCiAgMGRPTFVaR1Zsa3RRME5OUmlJc0NpQ
  WdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0EKICBnSUN
  BZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55Z
  GlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2d
  JbVptY2pKb0xXNXBSVkZhTWtoU1pqTm1OMjUzT0VVCiAgMlluSTFVa0UwVjJ0S
  GFEVlFkRlJwVDFOblZYcDRVblp0Wm1OcmNtd0tJQ0J0WDJkVmJqbFNYMkZEV0V
  obVcKICBYZ3hTbkJEY1d0a1YwRWlmWDE5TEFvZ0lDQWdJa3RsZVVWdVkzSjVjS
  FJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlpT2lBaVRVSkJOeTFaVEZSV0x
  UUlBSRTR0VFU4MFVTMURWMWRMTFZSR1Rrb3RWRFV5V0NJc0NpQWdJCiAgQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0p
  zYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDS
  kZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYgogIEdsaklqb2dJakJYUWx
  aNloxb3dhSG95T1RVd1VHUkhkR1pDUkRBd1UxRXpibTlDTXpsMVRYcElUMHBtY
  UVFCiAgMU4zVm5kemhoTUdkSlkwb0tJQ0E0U0hreFgyaHZiak56WWxoelJESnl
  WMlZ3ZDJwT05rRWlmWDE5TEFvZ0kKICBDQWdJa3RsZVVGMWRHaGxiblJwWTJGM
  GFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFFVWpjdE5GRgogIFRXUzF
  DVkVwS0xUTlFXbFV0VDBVM1JTMVpSRTVUTFVGSFVsUWlMQW9nSUNBZ0lDQWlVS
  FZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJ
  HbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKICBnSUNKamNuWWlPaUFpU
  ldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKcmEycERhbGx
  tYQogIEhGVGVYVkZhSFJNUjBGQ056Um5ZblJwWHpNMFJGWjNRVWg2UmxKNlNFN
  VRaREEyV1UxQmNETjVTbGRtQ2lBCiAgZ1gycE1lR1pUV0ZNMk1XVlpUbFYzUjJ
  OVFluRkVTMkZCSW4xOWZYMTkiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZ
  XMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1MTIiLAogICAgICAgICAgICA
  ia2lkIjogIk1ETzYtNVhLUi1CSk1QLVBDWUwtSDdHTi1GRlZZLUNDTUYiLAogI
  CAgICAgICAgICAic2lnbmF0dXJlIjogImh3Q2RtZTBtN0R5b0N4YmlvWFBFQWh
  1TXJ2c0s1RTRzWFJUWS1LRktyWnI4Tnowcy0KICAzQi15WEQ3c3ZWX2stV0ZHd
  HZDVUVBUEQyd0E1d1JMR3hVaFNKVm5lbV9ERzBweGsxNVJkZUQyZ0lBTnhRTgo
  gIHFsdGczcTEzVXNvSFNORC1GTlIxQUpSQUJCSDJzQzhmOE9MTFZWUk1BIn1dL
  AogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIk9kNTgteURlS3hWNDFDQ0hFVFd
  4QTR3dkNPTW9uZVFlbjVFU1hXYWl0QUUwVgogIGpjX2dvUm5hV1R5MzllenN5c
  0Vab1FpMS0yX1hsYUFYT1RsY0xrcEpRIn1dLAogICAgIkNsaWVudE5vbmNlIjo
  gIk5yVG9La0Nwbl95MElfQkNYamFQYVEifX0",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MDR7-4QSY-BTJJ-3PZU-OE7E-YDNS-AGRT",
                "signature": "G3WSiIn3y53G4PrRWfXLP6MSkYOc6fXIXfZAJJ94S4I5mY10A
  6WlhPFFOpKQVNM2SPpQ54789UAAZ555yJSxcvvw5oDt3b0VWdwoX1tc-t-DGi1
  TY4eKG0F6agyx2eFhZ0-Q3q4wXihvVXBo-EIPGi8A"}],
            "PayloadDigest": "y_8Xlftmn_lOzrXqq_6QqkO46GXuFrXYmi_N-Afa4KcSR
  yT7B3JkW7eEz0Dic0gYMu23MtY5suKmx1CLUBy4Vg"}],
        "ServerNonce": "aliIi6bROilxBQYDZzaZQw",
        "Witness": "42FH-AR5P-XEON-URO3-Q6DP-M4SX-BK6Q"},
      {
        "MessageID": "NBUA-WD3V-JRBN-POQF-BKKQ-V7PN-4GGN",
        "EnvelopedRequestConnection": [{
            "dig": "S512"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiJ9LAogICAgICAiZXdvZ0l
  DSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWt0bGVVOW1abXhwYm1WV
  GFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZSRVlpT2lBaVRVTkpWUzF
  IVWpkVExWZERURkl0UVRSRlFTMDNNCiAgbFJaTFV0WlJFb3RWRFpVV0NJc0NpQ
  WdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0EKICBnSUN
  BZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55Z
  GlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2d
  JbWh4UTAwM2JsWnFhekp2VFhGeFZtaHJORVZ3TFROCiAgS1dsOVNWV0p1WW5ac
  VlUaFhPWGhpUTNaaU0wMVVXa0ZRYTNJNFFWZ0tJQ0JFTXpoU05EQkVVVEZxWDB
  sUVIKICBVWlVVRXhOTkhOSVlVRWlmWDE5TEFvZ0lDQWdJa3RsZVVWdVkzSjVjS
  FJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlpT2lBaVRVTlRXaTFHU2tZMEx
  VUkRXVmN0V1RaVVR5MHpWVXBUTFRJelUwa3RUMGsxTlNJc0NpQWdJCiAgQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0p
  zYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDS
  kZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYgogIEdsaklqb2dJa3RyVFV
  nNFoyMTVVa1I2TWpkRlJuSm5NRWN0ZEdOWFJXWnFjbGt5UTJGUVJHeFFXbVpYU
  npaCiAgbWVFNWxUVjlVTkdad05GZ0tJQ0EyVEdWNWJIcHdlbVpMYlZwM2FERkJ
  NemhNYW5KaGQwRWlmWDE5TEFvZ0kKICBDQWdJa3RsZVVGMWRHaGxiblJwWTJGM
  GFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFFVkVvdFUxbAogIE1VeTB
  5VWxoUExWZEtORTh0U1UxV1dDMHpRbFpDTFVsT1RGY2lMQW9nSUNBZ0lDQWlVS
  FZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJ
  HbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKICBnSUNKamNuWWlPaUFpU
  ldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKbFVUaGhibGd
  0WQogIDFBM2RHRk9iSEpJTUZsVVlqRjBjRUZ1YkZWcU1FSldVVjlqVjFSbmRtN
  WhSR1pGUlZSV1ZYWkJhM0pvQ2lBCiAgZ2RsSmFhVFpQU21oS0xYUmtla3RFWjB
  0Tk9FdHZVM05CSW4xOWZYMTkiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZ
  XMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1MTIiLAogICAgICAgICAgICA
  ia2lkIjogIk1DSVUtR1I3Uy1XQ0xSLUE0RUEtNzJUWS1LWURKLVQ2VFgiLAogI
  CAgICAgICAgICAic2lnbmF0dXJlIjogIlNDeUM4U1lxYlA3SFdWSEVZVlVFRWY
  2bjUySnhiczJ2WXp1c3dvZzFrOGV1UGhaM0QKICBvZTRNeFQtcmoyLU1MZDhmM
  UIyRzMxbXQ1SUFTVjVHUVBDZTIzeVU1eWo1cTlBak5xUXJOQ21IcW5ORi15eAo
  gIFFuNmNGaTZVU1pEWmpEeXlHdENlRmJIbWxULXYzXzUzMFpac3hEajBBIn1dL
  AogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIlEzeGpSRWpJYVFnT25xdEwzTU9
  ZemtvWXZ5S2x0NDlJTkYySm4zdFhBeVJKQQogIGwtQ09ZUGdvemUxWHFRdnNRd
  0VETUVHSXFlQnhLNnVha2hQOWtiUHp3In1dLAogICAgIkNsaWVudE5vbmNlIjo
  gIlY2ZE5wS2R6VTU4NldYQVU3N1o1SGcifX0",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MDTJ-SYLS-2RXO-WJ4O-IMVX-3BVB-INLW",
                "signature": "YqmnzpzK6mKx_gwxOczA1f-vVlYj-hN3lAeHdb3FOygpItVA4
  jGguGNBCzASx6rv1hINPXwV-xAAbK-dHQpbXA6geKEjtUiMATo52GkNarihmuD
  MJwPmuuanykJt-lAAGMQ8d06Lz1mjNsfTxgFR3B8A"}],
            "PayloadDigest": "Z4xj3ov648orXkCrj4DU-NHq_KPwFlPm2hF-r-KTEAsGq
  tf9CSsO_mIyCTZeRefSq_nyzCYBqmSZpaVzVwptsw"}],
        "ServerNonce": "JuWg9nuLpgQeUK7-QB3bMw",
        "Witness": "S6SB-IQ4N-25DX-47HG-ZC77-MA2I-5QMT"}]}}
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

