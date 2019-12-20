

# mesh

~~~~
<div="helptext">
<over>
mesh    Commands for creating and managing a personal Mesh
    create   Create new personal profile
    escrow   Create a set of key escrow shares
    export   Export the specified profile data to the specified file
    get   Describe the specified profile
    import   Import the specified profile data to the specified file
    list   List all profiles on the local machine
    recover   Recover escrowed profile
<over>
</div>
~~~~

# mesh create

~~~~
<div="helptext">
<over>
create   Create new personal profile
    /account   New account
    /service   New service
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /new   Force creation of new device profile
    /dudf   Device profile fingerprint
    /did   Device identifier
    /dd   Device description
    /alg   List of algorithm specifiers
<over>
</div>
~~~~

The `profile create` command creates a new Mesh master profile and 
(optionally) registers it with a Mesh service.

By default, the default device profile of the current account is registered as an
administrator device of the newly created profile. If no default device exists, a 
new device profile is created. The `/new` option may be used to force a new device
profile to be created.

The `/did` and `/dd` options specify an identifier and description for the device if
a new profile is created. Otherwise, platform defaults are used.

Cryptographic algorithms to be used for the signature and encryption algorithms 
may be specified using the `/alg` option.


~~~~
<div="terminal">
<cmd>Alice> mesh create
<rsp>Device Profile UDF=MAKA-EQ4V-AUGA-L4LI-MQKP-NE6Y-6UYT
Personal Profile UDF=MCON-CT4L-LAU5-UQTO-TPIS-MHJA-T7RG
</div>
~~~~

Specifying the /json option returns a result of type ResultCreatePersonal:

~~~~
<div="terminal">
<cmd>Alice> mesh create /json
<rsp>{
  "ResultCreatePersonal": {
    "Success": true,
    "DeviceUDF": "MAKA-EQ4V-AUGA-L4LI-MQKP-NE6Y-6UYT",
    "CatalogedDevice": {
      "UDF": "MAKA-EQ4V-AUGA-L4LI-MQKP-NE6Y-6UYT",
      "DeviceUDF": "MDW6-JRWI-OBI7-WR2B-NJ4R-SCUO-BYSD",
      "EnvelopedProfileDevice": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTURXNi1KUldJLU9CSTctV1IyQi1OS
  jRSLVNDVU8tQllTRCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogImU2SDNDbVA5NVFJaWxXQzV4ZWh2cnI
  xMi1QdHY5QUVFZzdPRFJTeTNBVk52WjZJbFNZNEcKICBOQzBTVHhlWW1NTVRUO
  UZFMEFjMWhqeUEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUJMVS1SVlVBLUE3TUItSUlCQS1RVzIzLVo0TUEtSzVZVSIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVib
  GljIjogIjBhU3J5Z2cwSXZIZDU4dWZTQW1ERkFleVhIYTZIRDJacmpUbkZCSWN
  HSHlYMk5ScnNUTXMKICBMMFdqWERCYjhNMU5DUTZnUkV4TE9YVUEifX19LAogI
  CAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1EQVItSkJ
  XSC1BQzJDLUFWV0ItNlU1VC1RWDVOLVRWN1UiLAogICAgICAiUHVibGljUGFyY
  W1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICI4SEVnUXdBO
  G9adlVrU2NmdTJOSFdRcU9WNm5scjgwcHp5LVZqZ3hEeDV2VExkSkoyTmVxCiA
  gbHhodDNXQWpaRnNfSGpzZEJaYk5idnFBIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MDW6-JRWI-OBI7-WR2B-NJ4R-SCUO-BYSD",
              "signature": "k6bY-HtoTYe6OUF_yR5jWf8Tn6Fsttq_VQwT3EDE_4u5amcy6
  6p1Q0r31jBoBNq0KjOR9bxpFZMAnuxM08y8iSvg0I3kHaXqvc2d6ArcD2eRboD
  FxJi_wvaAxnPXbprMyR5vW9m7vG3PHIU05nBAQhoA"}],
          "PayloadDigest": "R6SLrejJ0W5q6mhucMG_nv7KAKMZDYqycyg5QcloTcTtG
  CTW1vWLF5UXzU7Q8xdyycbhFAMWsDKULCSgVM3qZg"}],
      "EnvelopedConnectionDevice": [{
          "dig": "S512"},
        "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQUtBLUVRNFYtQVVHQS1MNExJLU1RS1AtT
  kU2WS02VVlUIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAicmdSalVITzUwbjVyTlJDamd6VmNHaVVDR2V
  ick5vNWxSNzF1MFRfc2ZRTjJLdUFKQkVlUwogIEVBMmQzck5mSzVqc3Z0UERiN
  E1WQUlPQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI
  6ICJNRDRKLUdOV0wtRDZMNC1HVVczLTdFRlQtUkxVSS1DTkpLIiwKICAgICAgI
  lB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB
  7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAiM2JWdkZfX3NYQTJMUVZPZHRaTk9QUkxmU0p5Q0EzLXFYSldPZ214WUtFWFJ
  yamUwVFFvcQogIHVEcDdxRjM3b1VhTXlxTzJ4dUJOYnhLQSJ9fX0sCiAgICAiS
  2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUJNSC0zNjJTLUF
  EV1ktMktCTi1KNFg3LVkzVk0tNlRQRCIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImN
  ydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogInpCMlowbG9nb3ZCT
  FN0RXh1XzM0Z3FTaGtiM0MxRllGSWhQUHlMRDJXSzQtYUI5cG9zSTQKICBLaHh
  CUDBsV1J2YVliMkZJTk1xRG1LZUEifX19fX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MDVN-HBLF-Q3BF-OSCT-OLX4-TDSY-TY3W",
              "signature": "4J08P_ituhEAAdNIoLM2478gUovcnQ5hQlkmc5FqU-ERbdRzX
  Z-9kPF2p-QWdTr-cKkAN7qrENCA83bYMgpuqJoa_odJZUWYe6hwztt-NPmPF29
  QvZsm8SMHVIxuzJ5vTApmfc1IvakdwOQ-BmQbTTMA"}],
          "PayloadDigest": "FMSgfHQKmZOUgPIDaIC1qiIAmPm-Azm5MbcPvUHAhfjg6
  lNa5RDx-2QkJgI3mhDk-fFH1V_QB2p-n3Htv9o_KQ"}],
      "EnvelopedActivationDevice": [{
          "enc": "A256CBC",
          "Salt": "FVQyvh52t2sTRcQeSBDr9g",
          "recipients": [{
              "kid": "MBLU-RVUA-A7MB-IIBA-QW23-Z4MA-K5YU",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "kMr6tcog_Htq2rGTRfYU6oQVe3CigpLjJxuK0qyJ78ds7-WefcCy
  tW2CVa67Vz9Bx4HK4_WM_g4A"}},
              "wmk": "wXPQrxe8cx_TswFlM2PUyAItT58Qz6z2t3AwweBX7hnMShKL3IhCRw"},
            {
              "kid": "MAGO-EL7W-Z52P-WOCA-IWSB-UFII-Y3S2",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "uuGRfCGxsOwHt2YQxFujRXWShb-obdVarT2A1qiLHML7vvWuW1HX
  IVD7h86XfwcbwAUq_OyOK9WA"}},
              "wmk": "Gt1lYabeG0Ae72nP3EIqt4Gn3j1PwV2hBjHuqwNt7Ri8gmCE564V8A"}],
          "ContentMetaData": "ewogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tIn0"},
        "di8LTQPo-JI94DkGdXzAdsYPZpqC8WKalu9h5vHsG4T
  _nJEZMsCiNijY4z2E58ct-tkIhRLSRT4UM11-sIJc2ijKRuGPQDHZ7CCF6udWB
  qPG-ar5dTh2Nw46FAWHB5KyM3BDRPWMGdY3tsQSpJA6rzXY4kTtqTxqt6gZjCW
  uVnT1LCGm0vKky6UZKled0pgRLGa7vt33mlq51LiSwJnw7FpoGargxeTaq-2g-
  N7rLcIED_jYZthfhN-uxAa3M_yTVZbRK2XQRxoaoJqC2PFVJbe-0d24C1mGQHf
  yp3zc9uS56I5jQNwyVZURy_Zr0DWvMx3efrKYQg4Sga5oOoylClCzX8YvErcVt
  sWlJISGGCIlJ6yI5zL_yXOXtBXzV4OpNx_hty6T2fYjaaAKq9PfrmHm5UJlzTi
  16cQVHcNsMiq1Cjh1P5I3FcVghiQuSNqVeslD5naRUkWeC9dqB4tdGsqySm-97
  Mla__J2OhdhcXzmA3z4a3vqUPe6RubSeLreMJygYaikYt0RXBAj5R3xNPXf38D
  wEl83xs5LkEx-DT91TNN_BB9CZn1Mz3Pr85OWyTWCzg252jW_40K1GX1Qzv-FZ
  tOjKuoPaA9gNPFkFYmqX_cYnHSqyaLyFBjAwWT4puMEPiQ-OIUCjr_uC3zpckb
  nsQtly-J7bD0tQCGj_x3uHPddEsoauAD3ZS6gLDWrgy8MwJaosbIwALtiorfXF
  GoAO_7PwgpMc_-sWOnIYMUmwY3Di0I8tzVloIB3LYt6jpYyrR7h7Woc__X_WRt
  Z7Xy9dcFVOUvs_w2--mZ0cLf-V4ITZEZcyqhdJn-qZPJELEfz49_2gl7FHJ5o_
  EdK9UkRqPIad3g59BaTt62zcuQ4wZiKvZk6L7Qx4R9RWDIDZuPLcgZWyyzUqON
  jVocCS5ENTk_BYr_ZlJeMpiISBJWcYrn-RMUPm6uiuY2ziFi3SNF6jhdbS0yw1
  AgrWYFmbbVm33oHucEQQKXE-jt1pdYdVNZxlq9OpnLU39h9YXz6dzOYK0L3k9Z
  7stkZPdusTweVy0b-UwJXH_SlbpqAn-zHLE7sN5Q981GpB-UfwcUwcxd6-32R3
  3x2uq1Ygng8RsLR7ZfmOA_N-SXFDILCXY2RBKUWap3b8wTZEO3gd3xKE0xH0ow
  yUy4scVS60fMHozYScDap52M2EJwBuFJuJWk_BDsKDH0PTpfKatm3fsJtrhm3R
  Ae9qvx00xZ92CyB-eTPfP284iBvO0xFX5Xrs0AD2AaIUrYomMX0PMef27JL"],
      "Accounts": [{
          "AccountUDF": "MBTW-IG6H-43CI-2XON-2N7Y-NTW5-UBUJ",
          "EnvelopedProfileAccount": [{
              "dig": "S512"},
            "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1CVFctSUc2SC00M0NJLTJYT04tM
  k43WS1OVFc1LVVCVUoiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICI0cGJNdmEyaUFGeWI3b3pIVGZRVmF
  WRklwUmFlbGlGZFhqaVJ2aFRPN1F3V2h3bXpnSi1HCiAgOHJOS0pMLXVoaThEa
  zhlOHpuUXdiREtBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1BQ0MtTTYySi1HTEdOLVVDWTYtVEtKVi1YTlpWL
  Uo2T0giLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogImJiLWNhWElWS0NKYjFCYzlSVXJVb0V
  UaXgyX05QR3FoZlZsSWxnWHNEWDhrYTJMcjRreVYKICBQcUg5eG5DUlBJMk1We
  DdORkoyVU9YR0EifX19XSwKICAgICJNZXNoUHJvZmlsZVVERiI6ICJNQ09OLUN
  UNEwtTEFVNS1VUVRPLVRQSVMtTUhKQS1UN1JHIiwKICAgICJLZXlFbmNyeXB0a
  W9uIjogewogICAgICAiVURGIjogIk1DNVgtQjVBUS1PMkFSLVNOS1QtSlQyMy1
  DUEw0LVJXT1YiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAo
  gICAgICAgICAgIlB1YmxpYyI6ICJoSHhMWWgwb2JkQ2JiTXFsN0c4UEd6Nm9MW
  HVZcU0tRHdFTmNjT2JRU29aTVpIQlhUUHFaCiAgVlpDaEFNYnZIRjNqakltWjR
  qWE9yMVlBIn19fX19",
            {
              "signatures": [{
                  "alg": "S512",
                  "kid": "MBTW-IG6H-43CI-2XON-2N7Y-NTW5-UBUJ",
                  "signature": "jt1jLhKDFrX0y48k32n1GfvvTvp7jx_Sb32Sj6wFH1tZsmGXR
  iMFL4G_mnNGTq4rFRtbGaSNA3WAB8X-g_BaZKWfKrbqwSyEyNk_b-r0GxBSuUX
  qgF382hYDTHDxVwGBSVr1XjVtNKeGILwGQLvHsx4A"}],
              "PayloadDigest": "LLsPsdB8rHQJq_X0ALKbhG4YOGE7_re7KO8nB-NI0g9gT
  wuaOUKpjSinmR4Y_g86SmtAlBzSqtKONbzuyh3-nA"}],
          "EnvelopedConnectionAccount": [{
              "dig": "S512"},
            "ewogICJDb25uZWN0aW9uQWNjb3VudCI6IHsKICAgICJTdWJqZWN0VUR
  GIjogIk1CRlItMkdGVS1OQTc0LU83TFotS05SUC1CUTc3LVZUTTciLAogICAgI
  kF1dGhvcml0eVVERiI6ICJNQlRXLUlHNkgtNDNDSS0yWE9OLTJON1ktTlRXNS1
  VQlVKIiwKICAgICJLZXlTaWduYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUJGU
  i0yR0ZVLU5BNzQtTzdMWi1LTlJQLUJRNzctVlRNNyIsCiAgICAgICJQdWJsaWN
  QYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgI
  CAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIlh1LWN
  ZWUoxWWQyV2NoQTRpR0NodGJabjBfNkFhRkpoMVlZdHFSdnRmVGtKSHJjSUY0c
  nQKICBIbUpFcjFPNkw5cWxVRVdKYlRCd1k0V0EifX19LAogICAgIktleUF1dGh
  lbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1ER04tUUY3RC0yQ0I1LUlUW
  jQtVE02NS1LS0pULVlGVUgiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJqVUN5azVGdFRuUldkQnpRYU9
  XblFfX1Z0NjctRk84Z0w5czZHcDZDOVJoN2puMGpjX1JOCiAgSVc2QkJtMjU2W
  ElubzhoVDhJeXdhUUVBIn19fX19",
            {
              "signatures": [{
                  "alg": "S512",
                  "kid": "MACC-M62J-GLGN-UCY6-TKJV-XNZV-J6OH",
                  "signature": "Dl2xwtJYimCS_eK9T24ib8k5L57MKLpudh5xK4spIp78tZ7kT
  kfygvRIVOq5ZAWf6EQADMZPu6oAyj-EN8b07UzZzy8GA5vAr-6CnJ93g51HqQ2
  Z-fRTZdrVGdyL4Zn7XXYLolLu8tSks24kpzWyKw8A"}],
              "PayloadDigest": "HPyNUeVKkMSoCgb-8Ew9IEImgLnW0N_m9wz8Ji5yM077B
  8NPPak6uH0vl9f69OC8m0DQ_I3f_vFG9dFm-vB0cg"}],
          "EnvelopedActivationAccount": [{
              "dig": "S512"},
            "ewogICJBY3RpdmF0aW9uQWNjb3VudCI6IHsKICAgICJBY2NvdW50VUR
  GIjogIk1CVFctSUc2SC00M0NJLTJYT04tMk43WS1OVFc1LVVCVUoiLAogICAgI
  ktleUVuY3J5cHRpb24iOiB7CiAgICAgICJVREYiOiAiTUJBRC1IV01TLU9RRlU
  tUTdSNC0yRlQzLVFTTUotNVpBUCIsCiAgICAgICJCYXNlVURGIjogIk1CTFUtU
  lZVQS1BN01CLUlJQkEtUVcyMy1aNE1BLUs1WVUiLAogICAgICAiT3ZlcmxheSI
  6IHsKICAgICAgICAiUHJpdmF0ZUtleUVDREgiOiB7CiAgICAgICAgICAiY3J2I
  jogIkVkNDQ4IiwKICAgICAgICAgICJQcml2YXRlIjogIkhzUm9hV2xFUnd6cEh
  qZndad2lVb0RmWExYWl9SYTR5a1ljUGZEdG9EVTV1VTdqbVR2WAogIDRUR2I5Q
  21GR1NsZVJnb1lzcDBteEJrcyJ9fX0sCiAgICAiS2V5QXV0aGVudGljYXRpb24
  iOiB7CiAgICAgICJVREYiOiAiTURHTi1RRjdELTJDQjUtSVRaNC1UTTY1LUtLS
  lQtWUZVSCIsCiAgICAgICJCYXNlVURGIjogIk1EQVItSkJXSC1BQzJDLUFWV0I
  tNlU1VC1RWDVOLVRWN1UiLAogICAgICAiT3ZlcmxheSI6IHsKICAgICAgICAiU
  HJpdmF0ZUtleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICA
  gICAgICAgICJQcml2YXRlIjogInlNa29TRjFWTEc4MVVTamJ1RnpQM3dESmFSe
  lhsUThMZ0lmVWVodEZPaEM2MThwUHFDMwogIHFlbzY4WTJXV3NpbWF6YkNsX0t
  PZkQ4byJ9fX0sCiAgICAiS2V5U2lnbmF0dXJlIjogewogICAgICAiVURGIjogI
  k1CRlItMkdGVS1OQTc0LU83TFotS05SUC1CUTc3LVZUTTciLAogICAgICAiQmF
  zZVVERiI6ICJNRFc2LUpSV0ktT0JJNy1XUjJCLU5KNFItU0NVTy1CWVNEIiwKI
  CAgICAgIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjogewo
  gICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0ZSI6I
  CJIbktudkp5bTBnMHQ3RkZaNzJ1RHQzUWNhRmN0dzVVWXdvOHctRS1XQjJUR0x
  IRmxucnAKICBydlhXbXZSMGpiY05qRU1jcE8xdUJiWk0ifX19fX0",
            {
              "signatures": [{
                  "alg": "S512",
                  "kid": "MACC-M62J-GLGN-UCY6-TKJV-XNZV-J6OH",
                  "signature": "qXbVHyj8vOzNQ5dOxoJatwrPNU6vIFvJuZCJ8kZ8HzsFJkrjk
  Uw-4HhlIPhXDgZ780ghvDibHqOAdDpnNjD60Sl_n8SjYrMv_hzQuPQV9fdNFPk
  SqUloItm_qf_8RPT-NiVthxyV578gHVdR77V13D8A"}],
              "PayloadDigest": "UuBkxn2pkfFV2e8EOawFXmJQqt5Q00ZVhOG539kpDLNuC
  GbBHUxNxeH4MCGh4J1xp3wntT5t34TKymx81__yNg"}]}]},
    "MeshUDF": "MCON-CT4L-LAU5-UQTO-TPIS-MHJA-T7RG",
    "ProfileMesh": {
      "KeyOfflineSignature": {
        "UDF": "MCON-CT4L-LAU5-UQTO-TPIS-MHJA-T7RG",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "XRSEDoQSMmoWSn6Rm_yKvh58REkgr3QfW9NObp4YKU8rxhZUs-ig
  62GZMqxwQlOnRbBgju5cMruA"}}},
      "KeysOnlineSignature": [{
          "UDF": "MDVN-HBLF-Q3BF-OSCT-OLX4-TDSY-TY3W",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "Qbe5HoUUEOQCuqnnDpsQ1IJlq1TfKH--UafQxYMZjZOg2CjW5je0
  OSrV6nlGuD4eBG7lKG0TFtGA"}}}],
      "KeyEncryption": {
        "UDF": "MAGO-EL7W-Z52P-WOCA-IWSB-UFII-Y3S2",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "3-G7F4Aq-T5XMFyK0Pyy-XymKKtYxw8s360UDiTPZOMKUgdGVZWF
  qbZXTfedM7OanxZ3V5KhBSQA"}}}}}}
</div>
~~~~



# mesh escrow

~~~~
<div="helptext">
<over>
escrow   Create a set of key escrow shares
       <Unspecified>
    /alg   List of algorithm specifiers
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /quorum   <Unspecified>
    /shares   <Unspecified>
<over>
</div>
~~~~

The `profile escrow` command 


~~~~
<div="terminal">
<cmd>Alice> mesh escrow
<rsp>ERROR - The cryptographic provider does not permit export of the private key parameters
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> mesh escrow /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The cryptographic provider does not permit export of the private key parameters"}}
</div>
~~~~


# mesh export

~~~~
<div="helptext">
<over>
export   Export the specified profile data to the specified file
       <Unspecified>
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `profile export` command 


~~~~
<div="terminal">
<cmd>Alice> mesh export profile.dare
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultMachine:

~~~~
<div="terminal">
<cmd>Alice> mesh export profile.dare /json
<rsp>{
  "ResultMachine": {
    "Success": true,
    "CatalogedMachines": []}}
</div>
~~~~


# mesh get

~~~~
<div="helptext">
<over>
get   Describe the specified profile
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `profile get` command 


~~~~
<div="terminal">
<cmd>Alice> mesh get
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultMachine:

~~~~
<div="terminal">
<cmd>Alice> mesh get /json
<rsp>{
  "ResultMachine": {
    "Success": true,
    "CatalogedMachines": []}}
</div>
~~~~





# mesh import

~~~~
<div="helptext">
<over>
import   Import the specified profile data to the specified file
       <Unspecified>
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `profile import` command 


~~~~
<div="terminal">
<cmd>Alice4> mesh import profile.dare
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultFile:

~~~~
<div="terminal">
<cmd>Alice4> mesh import profile.dare /json
<rsp>{
  "ResultFile": {
    "Success": true}}
</div>
~~~~


# mesh list

~~~~
<div="helptext">
<over>
list   List all profiles on the local machine
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /mudf   Master profile fingerprint
<over>
</div>
~~~~

The `profile list` command 


~~~~
<div="terminal">
<cmd>Alice> mesh list
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultMachine:

~~~~
<div="terminal">
<cmd>Alice> mesh list /json
<rsp>{
  "ResultMachine": {
    "Success": true,
    "CatalogedMachines": []}}
</div>
~~~~



# mesh recover

~~~~
<div="helptext">
<over>
recover   Recover escrowed profile
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
    /mudf   Master profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /file   <Unspecified>
    /verify   <Unspecified>
<over>
</div>
~~~~

The `profile recover` command 


~~~~
<div="terminal">
<cmd>Alice> mesh recover $TBS $TBS /verify
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> mesh recover $TBS $TBS /verify /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
</div>
~~~~


