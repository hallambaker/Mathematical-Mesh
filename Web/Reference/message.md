

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
        "MessageID": "NBAK-RZAT-5GHD-FGX4-IQ5F-RZTT-SK2A",
        "EnvelopedRequestConnection": [{
            "dig": "S512"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiJ9LAogICAgICAiZXdvZ0l
  DSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWt0bGVVOW1abXhwYm1WV
  GFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZSRVlpT2lBaVRVSktNeTF
  MUVZOUExWcFhVVkV0TlZoWE5pMUZOCiAgVE5VTFZSRFQxRXRTMGxaTXlJc0NpQ
  WdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0EKICBnSUN
  BZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55Z
  GlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2d
  JbDlyZVc5amEwTTFORkpLZVhkSmRWQmxlbVF0TjFoCiAgSmR6Vk5SM1JDTTE5R
  mVFWm1TbTlGU2w5V1JTMWFVRWxmVlhCQ2FqSUtJQ0J6UmpkRkxWSlRiWFZSVFV
  0UlUKICAzWktZbTUzZFUxSU9FRWlmWDE5TEFvZ0lDQWdJa3RsZVVWdVkzSjVjS
  FJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlpT2lBaVRVUlRUUzFaUkZvMkx
  VUklWelF0U2s5TlZTMHpSVUpWTFRaWVEwZ3RRVVpSTlNJc0NpQWdJCiAgQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0p
  zYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDS
  kZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYgogIEdsaklqb2dJbkZPU3p
  GNmFpMUthbkYzZVROQlUwZFNaRXBLVVVJMFVURTFWbGc0WVdobU4xcGFRbXROV
  TFCCiAgblkxRnFTR04zYWw4MWNYVUtJQ0JRTWpKbFRqQnBhVk5sVlVGT1FrbEx
  iR1UwTUhodlowRWlmWDE5TEFvZ0kKICBDQWdJa3RsZVVGMWRHaGxiblJwWTJGM
  GFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFFUWtNdFFVOAogIDNReTF
  TUlRkSExUVkpVMGd0U1RVelNTMU9Vek0xTFVveVVWWWlMQW9nSUNBZ0lDQWlVS
  FZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJ
  HbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKICBnSUNKamNuWWlPaUFpU
  ldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKTU9WUlRabkJ
  VYwogIGkxSWMyMUZUVTFSV1V4dmNHTkhhVWMzVm1sVVNuSjBkazFUTjFJeVZYT
  mZaVFkyUzAxV1JWaERaVmQ1Q2lBCiAgZ1pHbEplREZSYkhoaFVsVkZhekoxYmt
  0eVJrTklkelpCSW4xOWZYMTkiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZ
  XMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1MTIiLAogICAgICAgICAgICA
  ia2lkIjogIk1CSjMtS0FTTy1aV1FRLTVYVzYtRTUzVC1UQ09RLUtJWTMiLAogI
  CAgICAgICAgICAic2lnbmF0dXJlIjogIktONlplNWNlcTVNQlVTMnRfU0I1TjV
  kc2ZCUGxZU2NKLWx3dGQ0S19tQWJwejJDdkUKICB3RHB1c3d1ajIxVlQtYk5aa
  Ws1U2VrN0lxQUF5cUozNkp4d19McDlXWTRqeGwybGFsSUlFQ2FJOFhkc1hIUQo
  gIEdPMjM3MWp1S215NlVDYWUtLUpNdFN1NDd5UTl4R1VDM2h1YkRRUlFBIn1dL
  AogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIjJLUTZEWXB3dkVFdVpVYldxT0F
  RMFZWak93dExOQ3VPcU80S25wbWpUNl9MZwogIFBiQmFkOVhYY19jXzNWQUZ5R
  0RKSHVLNnlzNDhvSWtzMGktdzF2NldnIn1dLAogICAgIkNsaWVudE5vbmNlIjo
  gIllYOEpIZHpnTVJuS2xBbVZWcnplcHciLAogICAgIlBpblVERiI6ICJOQVVZL
  UE2V0UtT1JNMi1HVVRXLVdFIn19",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MDBC-AO7C-RE7G-5ISH-I53I-NS35-J2QV",
                "signature": "Y1P5QwpkTiSiCvwLRwcDuhemCsi-o7__qUVbJDo4LdSD78H8h
  a42BX2tWszxkuyUMPsENk5WffqAdEdgakpRlzXIgKIAYYG26mCGwZKCkNkYFTX
  NTedz_YROUk9WIawpAP6YH80X2gbjOpflLIZH2CwA"}],
            "PayloadDigest": "QO1osdN_loD7rhhfDP6lOJosRvlDngDashWhjXyh0gwar
  Ooqgxmt9gAvzE2Bt9weiRWa7HzaDb-N-ZfPs-SHlg"}],
        "ServerNonce": "T_aAbjgtQ1czUWmLweKmGg",
        "Witness": "ZRM2-CJZX-GZ3L-Q7JT-VOJA-MEGY-IZJB"},
      {
        "MessageID": "ND34-CJRL-G3XJ-4MRV-RWLS-4ECL-BD3C",
        "EnvelopedRequestConnection": [{
            "dig": "S512"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiJ9LAogICAgICAiZXdvZ0l
  DSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWt0bGVVOW1abXhwYm1WV
  GFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZSRVlpT2lBaVRVUlROeTF
  YU2tNMUxUWkZSVTB0VGxGVFVDMHpVCiAgRWt6TFVSTk1sSXRXa05CV1NJc0NpQ
  WdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0EKICBnSUN
  BZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55Z
  GlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2d
  JbWRQYzNGVk9XcGtNV3AzZFc5VWJFczBNbmhLT0U1CiAgM1ZFb3hRemQ1VVdON
  VlVUk5WRlJ5Wlcxb2RVNXRMVnBPVUVsR2FIRUtJQ0J6VG5obVZHSktWVmRTTTN
  GeE0KICBYTjJSM0ZDVEdkalVVRWlmWDE5TEFvZ0lDQWdJa3RsZVVWdVkzSjVjS
  FJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlpT2lBaVRVUTBVUzFYVkZkSkx
  VMDJOall0UVZBM1FpMVlVVTVETFZSWVZrWXRURUZaV2lJc0NpQWdJCiAgQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0p
  zYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDS
  kZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYgogIEdsaklqb2dJazV3T0M
  xQmIzcDVkelZyVlcxSkxVMWxaRkpYUVdvek5rTjBOazg1V25CbVJtWjJkWGxHZ
  FRWCiAgeVFXSlViRXR3WDFCU2J6QUtJQ0JvVDJSa2RFdHZkMHQ2U25aQ00xWnd
  PRlozT0RoYWRVRWlmWDE5TEFvZ0kKICBDQWdJa3RsZVVGMWRHaGxiblJwWTJGM
  GFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFDUmtZdFZFSgogIE9RUzF
  MVlROSkxWbEJWRGN0VEVoVVJTMUpTVXhTTFRKVlVrSWlMQW9nSUNBZ0lDQWlVS
  FZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJ
  HbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKICBnSUNKamNuWWlPaUFpU
  ldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKcVdrWnJTbkJ
  WVQogIDBjNVpERnFRbWx4Vkd0c2VHMDRRbGMwTjBwWFZGRmhNMVJYWkRNdFdHM
  HhlV2x3T1hkMmFXZFJVbW8zQ2lBCiAgZ2EzaHViRVZTVWxSVldGSmpWVU5RZG1
  3NGJDMDVSR3RCSW4xOWZYMTkiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZ
  XMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1MTIiLAogICAgICAgICAgICA
  ia2lkIjogIk1EUzctV0pDNS02RUVNLU5RU1AtM1BJMy1ETTJSLVpDQVkiLAogI
  CAgICAgICAgICAic2lnbmF0dXJlIjogIk5mdHFhUURHTEFRUE41d2I0ZTlRbGF
  uS0dhQjdNZHViZlZFV3ZrUnZicHNtTlRvNm8KICBjMFJPS3ZpY21idVRIcWZMb
  FhURUQyUERBMkF3amZLV3p3Y3NYV0FlM2w1WkJxV3lQTmtyTWhmTmhvQTRFZwo
  gIFJMWlAzaFo4amVweWJpbTZaZGhOOGJmWm5NSmZPTXp4R3QxVjJRaklBIn1dL
  AogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIi1vejVxeHF2T3ExbXhkNGtDNUt
  jOEQ2LThfaVBabUZZaHFwOVdHaG0xQTVCWQogIExIN2tpaTIyQ1BaSC1ZZ3ZaW
  lNYT1Z5R0M3Vkg5TFVqSXVhZXJ4M2VBIn1dLAogICAgIkNsaWVudE5vbmNlIjo
  gImZCSHdPMUVjWFg5eU8yWFpNbjc3X2cifX0",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MBFF-TBNA-KU3I-YAT7-LHTE-IILR-2URB",
                "signature": "NVOESVNqyrKt573ZvtnwSjVQC8qnVVyKgbY29tPHMLmeeijCH
  jVdNgVQ8x65MclrDq3ZdPNS6IAAO7DLcsgxfI5cn4XLpVYkU9QGEUhlrx_-smL
  3_j26fPHe3l6Je78k5Xr3DfCbSCsXK-o_K7WT8DsA"}],
            "PayloadDigest": "lwLXKD8_-wEO6SdAkFI5wyqbYuZ0nywIXLQhRXZIXzYEV
  trC3bcP1yPw3f1F61guGsUXuSeyKVd-D8oaaGa17g"}],
        "ServerNonce": "96dXBR8ceqURUCdtVqzgVA",
        "Witness": "N4OW-GEOK-3TC4-VDV7-ZBDP-C5XH-UBSD"},
      {
        "MessageID": "NC4C-PWO7-2A6R-NQ3W-2RZV-SKK3-RHIN",
        "EnvelopedRequestConnection": [{
            "dig": "S512"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJTZXJ2aWNlSUQ
  iOiAiYWxpY2VAZXhhbXBsZS5jb20iLAogICAgIkVudmVsb3BlZFByb2ZpbGVEZ
  XZpY2UiOiBbewogICAgICAgICJkaWciOiAiUzUxMiJ9LAogICAgICAiZXdvZ0l
  DSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b2dJQ0FnSWt0bGVVOW1abXhwYm1WV
  GFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUNBZ0lDSlZSRVlpT2lBaVRVUTFSaTF
  aVlVaT0xUTkZRVFV0VlRSR1dTMVlSCiAgMDVZTFVaYU5Fc3RSMGhHVVNJc0NpQ
  WdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0EKICBnSUN
  BZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55Z
  GlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYkdsaklqb2d
  JbXRFTFdkS09FaHpVbDlKVUUxb1pHbzBURXRsZG1SCiAgRmIyVkxhMGhwU0hWT
  GVESmtUVmhuVm0xeE9XNUdPRkZzY210dGRYZ0tJQ0EyVFdoMGNXbFZOamxYU2p
  Cb1MKICBuZFVkR1pvWDFkTU5rRWlmWDE5TEFvZ0lDQWdJa3RsZVVWdVkzSjVjS
  FJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZSRVlpT2lBaVRVUlROeTFUTTA1WUx
  UWk5VRGN0U0VjeU15MURVVkkyTFVZMVVEVXRXVE5FVmlJc0NpQWdJCiAgQ0FnS
  UNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWpvZ2V3b2dJQ0FnSUNBZ0lDSlFkV0p
  zYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDS
  kZaRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWlVSFZpYgogIEdsaklqb2dJbUpGYVR
  WRllrUkxjMWh1WDNOUFYyVXlUMGxUTURVd04xZGZRWE42ZEVWdFIwTk9aVVJxU
  0MxCiAgd1NIbFBaVlp1TkRoNFFYVUtJQ0EwUkdOemFXWkhTVTV3ZUhka2EzZ3l
  RVmRtWldaRlowRWlmWDE5TEFvZ0kKICBDQWdJa3RsZVVGMWRHaGxiblJwWTJGM
  GFXOXVJam9nZXdvZ0lDQWdJQ0FpVlVSR0lqb2dJazFDVFZBdFR6UQogIDJUeTF
  HVkVKVkxWUTBWMFl0UmtwRVFpMUNRbGMxTFZkR05GTWlMQW9nSUNBZ0lDQWlVS
  FZpYkdsalVHRnlZCiAgVzFsZEdWeWN5STZJSHNLSUNBZ0lDQWdJQ0FpVUhWaWJ
  HbGpTMlY1UlVORVNDSTZJSHNLSUNBZ0lDQWdJQ0EKICBnSUNKamNuWWlPaUFpU
  ldRME5EZ2lMQW9nSUNBZ0lDQWdJQ0FnSWxCMVlteHBZeUk2SUNKaVpVMW1lRTF
  XWgogIEVVMVpVRnJVbEpFUWxwcWExOVhPR2g1VTNwbGMxVjVlWGhLVGpKaGJER
  kdiRTA0UmtOcU5qSmtVMWhaQ2lBCiAgZ2QzTkJXUzFMTXpVMlNWUnVVRXRHUmx
  NNGIzSjFjelJCSW4xOWZYMTkiLAogICAgICB7CiAgICAgICAgInNpZ25hdHVyZ
  XMiOiBbewogICAgICAgICAgICAiYWxnIjogIlM1MTIiLAogICAgICAgICAgICA
  ia2lkIjogIk1ENUYtWVVGTi0zRUE1LVU0RlktWEdOWC1GWjRLLUdIRlEiLAogI
  CAgICAgICAgICAic2lnbmF0dXJlIjogImFfMU12VVFwUVR3dW9aTm5hUkpSaUZ
  0eGZhbmRzR0xDaS02QlhpMlR4WUtaN2Etd0cKICBwUUhJRGd6RW95QlFYWDhkN
  HNCQzcwbXh5TUFudkhTMWt2aWR4U0JwSlE5RzFsNFZnQ2pIQnRXMU9fUDZHZwo
  gIC03Q3IyUjZXanFubmRQd00tT3FLQ1c4VGI4Uzh3aFZ4VkFEWVVEQklBIn1dL
  AogICAgICAgICJQYXlsb2FkRGlnZXN0IjogIklEVTFJRlNyQUlNaEpGNllIQUZ
  3NTI3UmVkOFExbnV3c0NhQXF3RjdSeHR0NAogIFAyWlhEcWV0akRUMTRxcHhsN
  mxtd3BaYV9EckRNaVNHa0NTZHp1WGdnIn1dLAogICAgIkNsaWVudE5vbmNlIjo
  gIm9hTDN2LUxfTkZWc213UDAycTM5ZWcifX0",
          {
            "signatures": [{
                "alg": "S512",
                "kid": "MBMP-O46O-FTBU-T4WF-FJDB-BBW5-WF4S",
                "signature": "-YrbTY2J_9DQWlkbL5TH1mmEoy4EaFlvH1hoglz5sbPmKaztU
  r06EIA3WGUfPGc_mydOUdUIafaArVC6T8VFBM6zMHz9rpNRWg3cN_9auInMU7b
  FRKbQusc5GKTLn3_LOBvUR-4PMaFHfTZ9Sgd2cx4A"}],
            "PayloadDigest": "qSY40CNus7jvGRBRY2WI_oT-1uCKphdxiPMT8spu8Utve
  RLaber3_Spjp_3s5QWchdd00B5c2YLZsUYy5ceHGw"}],
        "ServerNonce": "qTDzmCtR2YB0SDph1N5ceg",
        "Witness": "WPRM-7ZJ6-XMJ5-RMAH-N2JS-PHUA-7ZVH"}]}}
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

