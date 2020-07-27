

# device

~~~~
<div="helptext">
<over>
device    Device management commands.
    accept   Accept a pending connection
    auth   Authorize device to use application
    complete   Complete a pending request
    delete   Remove device from device catalog
    install   Connect by means of a connection URI from an administration device.
    join   Connect by means of a connection URI from an administration device.
    list   List devices in the device catalog
    pending   Get list of pending connection requests
    preconfig   Generate new device profile and publish as an EARL
    reject   Reject a pending connection
    request   Connect to an existing profile registered at a portal
<over>
</div>
~~~~

# device accept

~~~~
<div="helptext">
<over>
accept   Accept a pending connection
       Fingerprint of connection to accept
       Device identifier
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /bookmark   Authorize response to confirmation requests
    /calendar   Authorize access to calendar catalog
    /contact   Authorize access to contacts catalog
    /confirm   Authorize response to confirmation requests
    /mail   Authorize access to configure SMTP mail services.
    /network   Authorize access to the network catalog
    /password   Authorize access to the password catalog
    /ssh   Authorize use of SSH
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

Accept a pending connection request.


~~~~
<div="terminal">
<cmd>Alice> device accept CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z
<rsp>Result: Accept
Added device: MD7W-S6XF-V4EL-7QEO-MUPK-B5JL-MLPY
</div>
~~~~

Specifying the /json option returns a result of type ResultProcess:

~~~~
<div="terminal">
<cmd>Alice> device accept CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z /json
<rsp>{
  "ResultProcess": {
    "Success": true,
    "ProcessResult": {
      "MessageID": "MBBF-56I6-ZZ4I-YUDO-S5F6-6L74-JX",
      "Sender": "alice@example.com",
      "Result": "Accept",
      "CatalogedDevice": {
        "UDF": "MAD7-JKFU-RE7E-DPVL-FMCE-6WDZ-Z3LE",
        "EnvelopedProfileMesh": [{
            "dig": "SHA2"},
          "ewogICJQcm9maWxlTWVzaCI6IHsKICAgICJLZXlPZmZsaW5lU2lnbmF
  0dXJlIjogewogICAgICAiVURGIjogIk1CVTQtQzRBSi1UR1RPLUFFVFAtTFFEQ
  y1SM0w2LVZNWDciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgIlB1YmxpYyI6ICJkbjZTNWE4NGJpUDI5elFsVHNGcTJpdHM
  1OGk5WXJFalFOM1N6bVNCc1YzN0tsdkpGY2Z0CiAgSGoxZjN0b3l3M1BlTUdPR
  0VBYzhkVFVBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3sKICA
  gICAgICAiVURGIjogIk1ETjItQVhBSi0zVTYzLTZJVFEtSjJENS1DWUg1LUhNS
  lQiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogI
  CAgICAgICAgICAiUHVibGljIjogIi1iT3djSkYyZnB2ZjU4eUFkNmxJTnExZGY
  yQkVYRDYyd3BZNmdRRXpyUG5zU3RIZEFKNG4KICBiUXFPek8tbzFwc0YwUkRXd
  URhQXZua0EifX19XSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgICAiVUR
  GIjogIk1CU0MtSFVDUS1MNjQ0LTQyQ1QtVFlRNy1TUE5MLTc3NUsiLAogICAgI
  CAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI
  6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljI
  jogIm4xRm5VdWZHaDdaOHJad2FPNEJFRWt0S3h1ajRlUHFSNFJxcnl3VTU1bVQ
  wZk5BckJ1LXMKICA2eWpKS1puUFRoSHpGci12N2pVX3U0b0EifX19fX0",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MBU4-C4AJ-TGTO-AETP-LQDC-R3L6-VMX7",
                "signature": "ekJ21H4Em51VHkZuw-wLLxw_Zr0SQgaCoWSJ_1V8i5tkbPpmb
  0VN1dqqahtqgr9wRi3wJHXDxFoAUov5ZRbL8h_XlXOWVcGJnG6Kg-hvzv0bjOZ
  _YnyBomcRpGvWwCIGBI4atrijPefpFJlhmeDOzxsA"}],
            "PayloadDigest": "637FkhvB-AOIsnaaMBZd1Lz3mjjwfQPsMHBXN0eGaLGd1
  BmpTL9Weg55OqHUiQzWbbrBH14TVbFlpMQ8iQhntw"}],
        "DeviceUDF": "MD7W-S6XF-V4EL-7QEO-MUPK-B5JL-MLPY",
        "EnvelopedProfileDevice": [{
            "dig": "SHA2"},
          "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUQ3Vy1TNlhGLVY0RUwtN1FFTy1NV
  VBLLUI1SkwtTUxQWSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogIjlpWVJEWnV4OVJKanNkdzRVRlF3NVN
  kX3R3U0QxYVl0OExyVi1LcjBUbkt6UDBZUDgxbzUKICB4emtteTVkaHpVRnp4N
  F95dk96TE9rNkEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUEzVy03NFdGLTZWVTQtWkFSRi1DTlIzLUkzUFctUFpBNiIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAibFB1V2RiZzV1clVZTFpPNzVYa0g4aVZPT2tuTkMzdDNCQU5aNXpBRUh
  tWU1aR0lXaUpmVQogIGNqakVJeXNTS0MzVndmVXRzNnJEZVBHQSJ9fX0sCiAgI
  CAiS2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUFLWi1IV1V
  ZLTVaSUQtTllDUy00UVozLVVNM0ItWk9OSSIsCiAgICAgICJQdWJsaWNQYXJhb
  WV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICA
  gImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiRTBZOHBDbWlQd
  TZ5YlRYZlM5bHQ5SldWc0x3d1BKMlNlYUpIYnR4LUVNVE9YX2p3b0l5SQogIHF
  UdVViTkFfdm96aGZpTXV6MHlzS2E0QSJ9fX19fQ",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MD7W-S6XF-V4EL-7QEO-MUPK-B5JL-MLPY",
                "signature": "OdOCPcp-aEYYBaieA4sR_wb9cXqdQCcGGK-eSHQfuZBlIyX-c
  adUW4dupiNLocnwx6f78uHVvTmAR5CA8jbfpDvrvd7bozuDMqFuREyASyjvYoD
  42C0g-WTgrVp3XxM73sn5FC_12r70PSQiO_vhVAEA"}],
            "PayloadDigest": "5KBc17By2Vx4iyhK-cRgFoqRS7uHksce-_E3RwXrEC2JL
  8C9-2WSOl0IAsT7ib_wqeetS8aPpxSGDQVkG6MaQQ"}],
        "EnvelopedConnectionDevice": [{
            "dig": "SHA2"},
          "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQUQ3LUpLRlUtUkU3RS1EUFZMLUZNQ0UtN
  ldEWi1aM0xFIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiS0l0X1NybEpmZUU5ckdpYTB5dTE2b2tfYmp
  kRVktOW53SU1GZXh2NW4yc3UxajVHV0FfOAogIGFEVUJ6Xy1QX2o4dkJKamd1R
  VdsMHYtQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI
  6ICJNRE01LVhUQTctQ0tURC0zMjNXLVRUVTMtVlVURC1DUU5MIiwKICAgICAgI
  lB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB
  7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6I
  CJ1b1VTNnBGczFUMXVsTTdMZmp2UXY0bzRkZGJkWkdqaHYza3haa21LSEpfQWF
  2b3lRMFp1CiAgUVVpbDkwM0hMblFfWE1STEdKNTFEWVNBIn19fSwKICAgICJLZ
  XlBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVERiI6ICJNQkUzLVlMQkEtS0l
  LTi1EMkpBLTdRSVctREJFVS1SWjYyIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlc
  nMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J
  2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJLeE1ZUDB3TnJCME9wa
  lhqWkc4NVZFVzFES0RuNC1FSmFVSDhMZmdtc3FmalNLcGNSaEF3CiAgSnlBdnd
  5dW9ON25HYnRLclRnYms0V0FBIn19fX19",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MDN2-AXAJ-3U63-6ITQ-J2D5-CYH5-HMJT",
                "signature": "0MzrJvnepVgujGCJt7PBiwh1emM0Rdc5t_SKEcfG6IWjoHqg2
  pkIlA-Voj4cRE99cWpCk_dQTPoAF5PkFuEhJBEGGtELP-YVrtrIoZF1kTLkuel
  wHsOWu3O4wqjd7NoQcs0cDmFMFNs_NP6iGgK7AQsA"}],
            "PayloadDigest": "f0EIJZ-IlMSY4y9Jl_APe9oiu8a8mf6jeg5w3CtDXLiru
  rPHv6gXdrRkLG9weybbmELl4XysIka1zSOoqOfqcg"}],
        "EnvelopedActivationDevice": [{
            "enc": "A256CBC",
            "dig": "SHA2",
            "kid": "EBQF-5LWL-ISEY-FZEY-HV5L-H7MV-4MN7",
            "Salt": "EglfIPp07UtS-43e0_mvPQ",
            "recipients": [{
                "kid": "MA3W-74WF-6VU4-ZARF-CNR3-I3PW-PZA6",
                "epk": {
                  "PublicKeyECDH": {
                    "crv": "X448",
                    "Public": "NGSiKAx93M2GD3xlAE6O8FgSRJLxsCsr8fMw56N4LMD5T6aOW9dJ
  h7wUJjtqKVHzt1s80KxoitKA"}},
                "wmk": "E7sm5GtzOnz7oNgFBrKzzJOEfk1rkYEkQtYKtS13UDJk5CnqyuWqRg"}]},
          "H_oMgRagnkBfybIlnR9cIQDWINn6jOU8fOvq2UVVwcI720REFRHaYp6
  JigGa8UXbeO13w0Ngs_pn_wXSb49K9puWE6SwVlGixa-Rs7_PHVRJ35hchk9Gl
  se54xSTPWt6Oy2EBTWxUqKY-HCtRYaKdqwzpMAyznPTrZXEWak8PD6LD53V6ae
  rKVHp6WnBTueaR8qZFgoOv-5S4Uniu9DguHIPpcN091__4062fev05TwPxT-8s
  bLsu0FA4b6Gt2nokotbBP_e2zxc7zuQOQ-ZIVEZkaKcsRn_FaYpGeDePfoHVLT
  2wlqvRaSbSgs3qOZiB9CdzflT8XN8sVEo5bQviLcY-dw_u344kSVo3jLHDZPQh
  nKczVe2S2SJ5ffL7vHNtHHR84Wewz_aSFnhnnWee3Awqi-qW5-kFxEQ7r6BVMY
  75_lOQ8XbWQJu104xhQlpF4yhDjXmPMbz1Ovu_undj6FbNZC04BjFbDtAksteo
  U9ja11CepsLU_5Y2sNMBUIca_S2-CwTRBmht8T8mLkPrTX4qvXFKl-iDGghq8z
  1O9gZmDAjhlakRv1u9DJuJMv52YD1q_2Mqq3rAOlFH5ULBL4I78aYiJldVTBga
  L0t18v7dPFVIa3ELTNyy3TowkZ9JnyBpy17ROPbNFEGspA2zNMjquGfY77sIOY
  ZnMOJDXuIJQaruPZ9kUR3BLzHbMvvZ9yF4f1yelRjzyFUMpliLOwsEErfxmHrr
  MuLcTL6yxxz1cxgY4uLGwvQfTfwwfp0ZCBiBiW2xNzV3fR14P7JjWGYzzNvI2n
  brxahRTG7KuHUB_Wjh4hN8yuOFFsOb2tkepBW0HQcNFrvAQjChH1JdUbD1zTwN
  p9yu7QODT3EcmKVDI3cz78DOedjx0saCiKwzC2E12Ws82hZJ1ZOgtSYr3oiQ6I
  iwdx1CcO63ESQtJTP7w8j5ka5Xbpl7sYpq9Sy24FwexgdC9xi8KMJ6_eahHzOm
  ixoRFjbC5iMxIVBPP0wc95kaAI5LXehwwtAow6WgJYE-MGJ0ST23_QoHaPght4
  E5dqAx9dMUtXHiQv7NajgtiM3QsAEEl4N3t93pcd5sWR1FlDt4KoPxos4z1Fsv
  HiKiChzcvQbGngZAXQOTmbBnZQVAfd4KJeWZyNgXpT6Wb4XPLALJuThuGAacnd
  icnxFPBVtjmeQkrBCy0zK1OTGZBs_1HWuI1PhBXbN4hMcLk3TDC1lFF3BRHsco
  lGeWsZaa-Ji3K14QjmvUzEwLzKLatyLsRcJ8AnkalD3L9q83CcF-4FcfwiWf8O
  nZp7JAWoV_7ihJSOeNDCJJFUfqJ39FYTNeGyCui_jMMFHiDPY8vFnqZ9P7EX7Q
  0rJbwInoGB1A-7dE5iKFZ159bbruQ2s7jwuYOT6GBsXvJZGBq-aRG_FlcTPQND
  xKi009xNX-GDceXne7Ox9bhkrBFo6hkVpRiPmKHvjXaqkSiRqGjuCDg0zvdvto
  3VlaxzWshD8KnRG5Je_5zX6uxx1QUs8CPbijqRsNeTKaSxZCiP2d61BP_-D-Mz
  ufNh52Sc9IiXx1sOjS6dGRqXBFV_802ENG5l6jZfZiRPJAvmmWM6e-7wbfeA4C
  obWIO7uW82PbXGYh5GXNNxdOwZfLp4jdiNDoghvMAWGtGbKygq29blY8Wd066t
  NMw8tRqhPnMqiwz1zzXR8gpJA2-AcUOcPxcTcOJjT6ig9ZdH9gL8XgavLZtiTP
  1Q98TMlllcoGmogo1isdhz8PTdNV13NC3xdJlUlucQXmCqvXXv7Wtdp-MEaLsl
  KqJ-8RWO5ov-BD86yNTmP8B3YYYnCKIITjf0ukzXjlSG9JE7oMBE4Is3AFJmv6
  hCg8PyLSuVcuOfmNk1OCAOXMBM4CzJzYDcE53vtdo2QsElKbKJFCbBYWN5iGjo
  djjkN28i1f_goWwGZOZeNXOrxQprSK9EtrBU3It2rfOUiujxk2yBcGEUIEIxqk
  1oL3bejT43Rd_laBCZeg4iR0kJx4z_Rc8L4vBQLGmHiZ2_iYpNIdTxrOuTt-0y
  UH501Qxci5BHWg4TRowYAoMTUK2huZ901T3elDDenr2o3yO3KR4_wbZ06xwe9q
  NP-MLv6acPcg-aiFYL0vE73MR35DWnLmee1d6VBlBAwYrODyUyKLmCyLuakbQI
  a66qBYi1ILpgXDFasbFLEbr8PWq7RHzB3x6K-vsBR-7QpCPQSm01qM9QDW9Je5
  7CEwTnhmo8ptG7L9aZ7c7ZvgXiI_6p47tHMPPsBwJHU2-pZ2JjRovRYNbCcU4r
  xk2oGyz03e1CtKbnxSeJstmzVkEEHc9ltARC8Dw",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MDN2-AXAJ-3U63-6ITQ-J2D5-CYH5-HMJT",
                "signature": "UPZmdAmvFzbJldp7yd9A9gTZvxpwahu_0I1maGkDU1Yn-R1rU
  gj0rylJssR3TGwpxoMpOsSTYOWA2FC2id6r6HDuAo88Id-FQvCSrfmpXQ8lpYj
  JeMZRqS53UHL9I0M9iAm1hIu_lG5DB_DyimW1qj4A",
                "witness": "LBhHdeo0YIHVDWrU2kAhzirZGjcs3-c6jv5BViRv7vw"}],
            "PayloadDigest": "YjHf-iUkM7hLp9VzdrErfZypEfh8Hkhh7qRyMo7Y3-_Da
  2TSU3wefTbZ2wFvCU0hLQjJCm0yVrJwYuPqQy7bdQ"}],
        "Accounts": [{
            "AccountUDF": "MDWA-A3BV-DQ6V-F3MA-L3RW-GITX-JAPX",
            "EnvelopedProfileAccount": [{
                "dig": "SHA2"},
              "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1EV0EtQTNCVi1EUTZWLUYzTUEtT
  DNSVy1HSVRYLUpBUFgiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICI1aXhsSk5lWUhwVWRac0xrUlB1ZFZ
  neVBGODRFamJzZEVUM0VWcmRVNGdsZ3ZEMlBMWVlwCiAgY0tmWnNBZ1c4Uy1HR
  VVnZUtzRHdiZVFBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1ETzctQjNZNi1KWENPLUpQQUktUjI1RC02S1RCL
  VAzTU4iLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogIlBadVUzVEVkQnFuaHlhTzVfM2hwWl9
  OVW9BaFBicjJqZjhJdW5fSGk4RG5BZmoyREtteWEKICBBX2U5WkNFUGQ2Zkd0O
  Tl1cHdZakR2RUEifX19XSwKICAgICJBY2NvdW50QWRkcmVzc2VzIjogWyJhbGl
  jZUBleGFtcGxlLmNvbSJdLAogICAgIk1lc2hQcm9maWxlVURGIjogIk1CVTQtQ
  zRBSi1UR1RPLUFFVFAtTFFEQy1SM0w2LVZNWDciLAogICAgIktleUVuY3J5cHR
  pb24iOiB7CiAgICAgICJVREYiOiAiTUNVNS1STFU2LUxGVVctN0RSUS1NM1E0L
  U03SkMtR1RaTCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICA
  gICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiMGNTbGYzaEJlY2JmY2I4SzNrSGI5NWJJOVR
  5a3Q0VFNVQjdiQVVTZ3NfcjNXMlY0STA4SwogIE8xQmtRVHFod1NFMFlWclR6U
  mhSanI2QSJ9fX0sCiAgICAiS2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUJaQi1DNDJCLUJVM0QtTTJKWi1ZT0tVLVpEWVYtT1M3TSIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiTjU1Tm16algwNFlHOGwxazVxVzBCODk4TE90TThJcWJLb2ZULXJMY00
  yN1BXRFJtMFFfcQogIFlXZk9aR1N6aHpzekJnVjhpMm1JWlphQSJ9fX0sCiAgI
  CAiRW52ZWxvcGVkUHJvZmlsZVNlcnZpY2UiOiBbewogICAgICAgICJkaWciOiA
  iU0hBMiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFUyVnlkbWxqWlNJNklIc
  0tJQ0FnSUNKTFpYbFBabVpzYVc1bFUybAogIG5ibUYwZFhKbElqb2dld29nSUN
  BZ0lDQWlWVVJHSWpvZ0lrMUJXRm90U1ZCSE55MVdTRUZQTFZkUlZWUXRRCiAgM
  EpVVEMxSVRGTXlMVk5MVDFjaUxBb2dJQ0FnSUNBaVVIVmliR2xqVUdGeVlXMWx
  kR1Z5Y3lJNklIc0tJQ0EKICBnSUNBZ0lDQWlVSFZpYkdsalMyVjVSVU5FU0NJN
  klIc0tJQ0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlSV1EwTgogIERnaUxBb2dJQ0F
  nSUNBZ0lDQWdJbEIxWW14cFl5STZJQ0ppWTJwYWFVUXpRbWRRY1RoT1NFRTRWR
  kZ6YkVwCiAgUmJ6QnpPRTE0UjFvMFZXUlBVVjh6Y0daQldHaG1Va2RMZERoM2F
  WaGxDaUFnWlRsNk16WjRWMEp4VkdWS1IKICBraGhkMDl1VFdOUGNtbEJJbjE5Z
  lN3S0lDQWdJQ0pMWlhsRmJtTnllWEIwYVc5dUlqb2dld29nSUNBZ0lDQQogIGl
  WVVJHSWpvZ0lrMUVNMGd0TTA5TFJpMUxURE0wTFUwMlEwWXRTa1ZIVlMxQk1rV
  k5MVU5VV1ZVaUxBb2dJCiAgQ0FnSUNBaVVIVmliR2xqVUdGeVlXMWxkR1Z5Y3l
  JNklIc0tJQ0FnSUNBZ0lDQWlVSFZpYkdsalMyVjVSVU4KICBFU0NJNklIc0tJQ
  0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlXRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWl
  VSFZpYgogIEdsaklqb2dJbkJKY2psUWVUVnJXbTUyUVU5cGFUWjBSRWRSZWpjM
  VpGVkNOVE5wUWtJeE0wWktRWFp6U0RKCiAgTmRIbEpVMlJRV0ZaM1RXTUtJQ0J
  yVTNGT1RHbDVUekJwVVRKYWFuRTVRa1JYVm1wbU9FRWlmWDE5ZlgwIiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI
  6ICJTSEEyIiwKICAgICAgICAgICAgImtpZCI6ICJNQVhaLUlQRzctVkhBTy1XU
  VVULUNCVEwtSExTMi1TS09XIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJ
  ROHRVOHFVblB2cHhFcXBaZF9UV2t2SU44XzFZdFJDa3hHcVNrMkV4YWRfNFBsV
  3pyCiAgQXpHX2NYOVZUNVVtT2FKNmNtaS1sTThoRjhBbS1PZ1JOa3hHa2IxeV9
  PWXRhS0JYblVlQkdIRzNqdG5wbFUKICB2eDNWbFdSZUpuMFZxWU1pVGZjQVE1U
  EtOdWpIYmY0aUNzbzZQU0FjQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI
  6ICJ0V0g5ME81dVYtYjZWdklqaXdpQ2xSa0o2RDJDNjRHWkxYcVprNXBBaHh0U
  VcKICB3cWNDektNM2Y3czZzbE91SjZmWjI2N3VEZzZRUTJVRjU1X3Zqc2lTQSJ
  9XX19",
              {
                "signatures": [{
                    "alg": "SHA2",
                    "kid": "MDN2-AXAJ-3U63-6ITQ-J2D5-CYH5-HMJT",
                    "signature": "dkGE7sfm861Gr8hz-cUEdXJ4ApQ2H51tkRztjdCdybGcytQI8
  HpmxpHaviS0ceu9twujRNk9EDOAbguThMg89BQisy12vpAxfe7m5cRBPYid6v9
  qMUNtaYN-DizwNt_3jvMh2ak9ZXz5iKF1OXSk4BwA"}],
                "PayloadDigest": "GNxcIaJXBAJmelnpMUm3SpQGudDUQkJQVEcqGiKCMXuBv
  vqcL40r06Sja-HsbZkAYcOqYycsF1GH8uwwBa6LWA"}],
            "EnvelopedConnectionAccount": [{
                "dig": "SHA2"},
              "ewogICJDb25uZWN0aW9uQWNjb3VudCI6IHsKICAgICJLZXlTaWduYXR
  1cmUiOiB7CiAgICAgICJVREYiOiAiTUJPTC1BWjdCLVpEUk4tVzczRS1ITkFZL
  U1LSzUtQTU2SCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICA
  gICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsC
  iAgICAgICAgICAiUHVibGljIjogImRzSjNlNjMwT250UXJmR3VSWFJpZ0ZLWDR
  lQ3dfVjBxX2pHNUVqSWVBcDA4UTh5Z1hMWFYKICBBSjJWUXg5cEptR1hUYUZNc
  nNaT0pncUEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJVREY
  iOiAiTUFQNy00NTRHLUdOR1EtQ1dCQi1HSkpaLVFJTVEtRkJXTSIsCiAgICAgI
  CJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjo
  gewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAiQ082M2g5Q3JneGF1Mzd6UGVzV21fNVRIZlJERkdDWExqVVZpZmlJcjBVSEF
  UZmQ0aDJPMQogIG9XekZEY0VYYzU3aDdRUlBCTXhaTWU4QSJ9fX0sCiAgICAiS
  2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTURSQi1ISEdSLVZ
  UUUYtNjUyNy1KUkFTLTZZQUctQ0FBTiIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImN
  ydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiYWtYMGxEYlhHS0dpa
  013TzVaMThzNGY0VEQzUFFnUmIxSXR5SHdjVXFEbHlfZWR0UUd3cAogIGhaTWZ
  MNVB1LWJ3X0J0Uk5uXzdqWkd1QSJ9fX19fQ",
              {
                "signatures": [{
                    "alg": "SHA2",
                    "kid": "MDO7-B3Y6-JXCO-JPAI-R25D-6KTB-P3MN",
                    "signature": "YbhGAbyn_75qEOZz2SPM4rGHRju2QIudr5JI5ZEjgllD33uDE
  nfmLOn8eY9DhpEfw8FffhqscUWApjQ4ROsRJpRaXQu9cujy4Jsn9WIyBfirYCn
  CMYdtEwvTbyhdTS1bNyOruD2MmUCdRdhh4lqIGiwA"}],
                "PayloadDigest": "TOVSBbBnyLYi6uXIQH3_m0L0kLXQ2MbYZ3jZ0yRv6iVn5
  tYcY7R3atFgnH0CMLIrK0HJUo8g5Vs2RRL4bL57qA"}],
            "EnvelopedActivationAccount": [{
                "enc": "A256CBC",
                "dig": "SHA2",
                "kid": "EBQB-RWY7-BKCE-DJBA-SGSG-CKPY-R6TY",
                "Salt": "WgyHf1e1Dv_3i0wnvaHF9g",
                "recipients": [{
                    "kid": "MA3W-74WF-6VU4-ZARF-CNR3-I3PW-PZA6",
                    "epk": {
                      "PublicKeyECDH": {
                        "crv": "X448",
                        "Public": "nLNUvBNI7LMHXubU4fMvaxheBsAezIkA_f0-NCVrC6j39wYhX4Um
  jsAvXupa9afZG4KCY_TAYTGA"}},
                    "wmk": "77LCxFtyR9FrU6W0wd7frj4wrFN4uJIrUiN1w2X2uZ53whC-VEiigA"}]},
              "5bl6KpKGmaXWQBzTjZtQoI3--jTdCzwLwwyTRaJ4nYhxkUcCWG5U702
  lwZq30HkTYnXQl4aMwyQ2j5Vs6KfmZE-r2PGrO-Da9O7amoDnLigt3vZcFuW27
  u2mBWCyhDMVwfrZ1zb1_tcqTaxAlWwL1WNENPCZDAJgdD5K7mV-3u58-o80QMK
  RFCyEgI2QspyXA5y-xwI40dT41gY_VGAjIez6Ccn6QRPFj-6t6pJ1LPdoMRHSo
  6q4WCU-Er-n8Qlz8t5dbbwZDJBiXQkox_R8d_naYDR8BmLzSaqALKSILerQu9m
  4IlSUAHY7BAK1e0FJczpz3_JXFXoRqdZ3Vtd8matvVbi110zmIXV4yY3kFARvo
  otUBZHT3i9tEaiwOGf49KH7IKTrwptytmp_IqC-hyOFwDDqG2JXq-zikC7eg1f
  UZcEUQjaxSdyg6dfZaABFfOW-L6ctrNzHCHDk-phS1vT6OWA8XtD9GJ_CJPK8M
  Ga_KkGkiifjFAYC3FPSFtOWeveIyJtDZkGy_-PT-vf9e2VIGnJoUyzpidOInVY
  MgYJMyXARGj38IiAviPuS3FxAS_exvUed6LcU3jG6L4zlm5Bax9_RimIgNWiyV
  zqZwdPJBLpbUqKdYNYC11gBv3bC4pzAtEgTjp4ZsanFh6Y1CJdewA4MsMD0RZ6
  -AlF_-ES_kcMnTQSX7NWRoJ5pfaK49pTcC-oJeHUdEl7-tS4HwcoMx4Mni5-T2
  w308VYDrdl-XtTByxlAYionEIpOyZIRd8hfZ9Ib_CUbNsB21qHPjedesHkb0Wy
  7XnRi37oOZ0ZhzdltQzyqfQUTpQUdRTy1YFoc9jYpHoqPM8o8RaeBYtokZHJ7i
  lbCNWCV1vu7XOR7YAx-B9yHW88NkSIEXqrP1BO8ZD5p4Y9ykWnaAI6ZBilndty
  ZkjQX1B5RIg4hjZDLpEAC17afAmKcnueKfeIlfyv4wa_jUnlQZPqrV1CN-0P8g
  rM3MwbiW3Jq65KpqyNmpQ55JYQaxNTX7hFebvC1RiesDUi3Uz_MYJX9O2_aiSC
  Js7p2XhQGbgVsrtzKYa9Pffm5KPBXZf8C1SwCvrDHglaiNkyvEC3rAAdwkN57b
  DjKNV1-UzYoAlKFPxgKDFxAAkM-TILxWsKuoS9VYHQW5b9V3xy_nu8ejhxIioX
  J4ZXneDFMB-ijow6_f_-H3OcHoFIgokqvMMXaYVuv_oAWU1zvFhYq9J_vOSLlJ
  zOfoVjbkwY5-Mk5N8gYv6lFT6dlEaSzQhdCgKImNDMLayx6MIZy82PuyoAVr6Q
  KdqEO2AJKHD19Exfz5ayFrDSoJ-rjFybB0g7mHkfx5Rji7_gmmGGLUnKp-Wn-i
  L468w2WphzuZJsX6pmXIZLzlWeXvPljfmDAiEf4zYis4g9BCdfBgtqoG2tzS-E
  mdli13XJhaY60WkA_xdCTIYtjydIbxa4S7wBMfxABbclIoJuXE6pdK2XdL1h8p
  u6O1SPoH7hzzNKBoq4TGXI-_fTRPLhMnPZwcC-v9uTsOaqtAS3FY_eRfhgaB67
  tpLI-AVyH1gF7b9Bo0HStRxbJaixwxnuFz3QFTNL2OtqQdcVWCTu6neuMnGjmq
  ww7L-nVFclG__CXOcrnQCnanB9gm8Edj8jneXaKlCtnwp8hSzFXaaRBESAJ4CA
  73yFkc93crSSpGjnuoNtjvXO6dWIYpqTX12hfHDhYiUOUfD7VFLUxEzG3Eld6R
  1CqLnDVRKDitjKG4I9jhEV289eG3NZcuuX2gsNVO-XL7FhS-U7Lz-QlGBHIpsA
  FnYAskUePOoEGY7nOPMPZDD6DHL_ErwZbxvC2Z4dO75bFcS-FVYD77L9s07p7e
  nUhY6PEcrym-b8qZXQVMjJWQS4BU_RdzYArxxRR4A6r8GZy7G8eZKf2vm-X38e
  o2GQUSYorwwFzeJyxAmaGg0s05v0PMSdpF8JwkKN27foG-rEoL8Q9JVK3yArpK
  rRGFGVeSLgbMIrqW1FvbQ7uRDY_2-WYQTFQBRiuizv9cyaaN9y3kL1heN-NEG7
  SSPbVspFM8sPwFUYA0Epww3vUdcEdRTt2mjhqvUCn8Zw0g3omkBLeXf6Q5iNjn
  OfBrgHWzszG93dkcTYkP0wR5j7mPdVFUF_4P_2pbgL9lLGZ0JyurSxHd4WPN-G
  76cn6O2jCSBbej3qWjjMq-TRj04E9kqEQ7vXuDqCT76lpLx028GraLMCw7pqoa
  4MT-OKdfiTFgrmW5msy3OPfN5EPlhcblDIaMuqY2r3WtZ1TH6NLjIfAriom_ZF
  1Cw05Vn_1f31tSi08oAlo-cGURH4TR-HKRkPa_KfG7Bgjs-_GLiBy0uvZKSjU7
  rPtPHjgc_LGIo8QJAQu5JAY6bKlFS0Sei8_wpRBmXy6c2vYGwhrxezpxqvhq8w
  zwCNHqFQxo5l6TUFgBXpdTeHdFcQpPNQyogoviOS9T_erjY-Ijzehf9UKL-SLu
  Yj7B6PWmm5AvEqvqUnu4VEGP0N4D5Wa0e2sbYZXO9LAqRDeBBrL1Gc8aQnsl-S
  ZksGaOc5-PFMxBghaFuGCXOKuDB4M8ZrjB0Q7-F3jKRjG3GCz0Y9GeXUkAFj2c
  KsUQRPqVCJ00OV5yT4ULSvqWDCycctqZSapNO-Xe1hG0WEOt4-OIpZTslKo-mn
  AMe63iltdXIsnIGRgj6zLPB0YQ54Vf7aACv4v0eH0PR6lwOEI1SvxAzA94J0i1
  2NQCR9rroUPo1iCIpTXCDOZvXn9jdq3QZfT_21Y646vqz6CDDOPyA",
              {
                "signatures": [{
                    "alg": "SHA2",
                    "kid": "MDO7-B3Y6-JXCO-JPAI-R25D-6KTB-P3MN",
                    "signature": "Bl7NMK-_XthcneIO3qwyDk6OGlJ1yldBKhgMJIHtTwhLW9_T8
  VIzhWy0cYQfq9tIoGw3ctAxNCIAfFhMAKfvRN6_KXYXoNQCUJcR_9NpxtUhskg
  XpgMTuw6x9i6vIsMv4o4rcl-jcDvt9LtHxNSFAAYA",
                    "witness": "LsypOjJ6kqx0KwwqZV4i6JIECS-FFgrC7kmZ5fLNj1w"}],
                "PayloadDigest": "YfJjfv6J-9gDiTJvO68H-y7xph0EC_idRKyZEK3mJx3dq
  JjnYo3iJDLSzp3CUu2UYnY-5Kwjj635CIMmzi-Nqg"}]}]}}}}
</div>
~~~~


# device auth

~~~~
<div="helptext">
<over>
auth   Authorize device to use application
       Device identifier
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /bookmark   Authorize response to confirmation requests
    /calendar   Authorize access to calendar catalog
    /contact   Authorize access to contacts catalog
    /confirm   Authorize response to confirmation requests
    /mail   Authorize access to configure SMTP mail services.
    /network   Authorize access to the network catalog
    /password   Authorize access to the password catalog
    /ssh   Authorize use of SSH
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device auth` command changes the set of authorizations given to the
specified device, adding or removing authorizations according to the 
flags specified on the command line.

The parameter specifies the device being configured by means of either
the UDF of the device profile or the device identifier.

The `/id` option may be used to specify a friendly name for the device.

Specifying the `/all` option causes the device to be granted all the 
available device authorizations except for those explicitly denied 
by means of a negative authorization grant (e.g. `/nobookmark`).

Specifying the `/noall` option causes the device to be granted no 
available device authorizations except for those explicitly granted 
by means of a positive authorization grant (e.g. `/bookmark`).

If neither the `/all` option or the `/noall` option is specified, the 
device authorizations remain unchanged except where explicitly 
granted or denied.

The following authorizations may be granted or denied:

* `bookmark`: Authorize response to confirmation requests
* `calendar`: Authorize access to calendar catalog
* `contact`: Authorize access to contacts catalog
* `confirm`: Authorize response to confirmation requests
* `mail`: Authorize access to configure SMTP mail services.
* `network`: Authorize access to the network catalog
* `password`: Authorize access to password catalog
* `ssh`: Authorize use of SSH


~~~~
<div="terminal">
<cmd>Alice> device auth Alice2 /contact
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultAuthorize:

~~~~
<div="terminal">
<cmd>Alice> device auth Alice2 /contact /json
<rsp>{
  "ResultAuthorize": {
    "Success": true}}
</div>
~~~~


# device accept

~~~~
<div="helptext">
<over>
accept   Accept a pending connection
       Fingerprint of connection to accept
       Device identifier
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /bookmark   Authorize response to confirmation requests
    /calendar   Authorize access to calendar catalog
    /contact   Authorize access to contacts catalog
    /confirm   Authorize response to confirmation requests
    /mail   Authorize access to configure SMTP mail services.
    /network   Authorize access to the network catalog
    /password   Authorize access to the password catalog
    /ssh   Authorize use of SSH
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device accept` command accepts the specified connection request.

The command must specify the connection identifier of the request 
being accepted. The connection identifier may be abbreviated provided that
this uniquely identifies the connection being accepted and that at least 
four characters are given.

The `/id` option may be used to specify a friendly name for the device.

The authorizations to be granted to the device may be specified using
the same syntax as for the `device auth` command with the default authorization
being that all authorizations are denied.


~~~~
<div="terminal">
<cmd>Alice> device accept CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z
<rsp>Result: Accept
Added device: MD7W-S6XF-V4EL-7QEO-MUPK-B5JL-MLPY
</div>
~~~~

Specifying the /json option returns a result of type ResultProcess:

~~~~
<div="terminal">
<cmd>Alice> device accept CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z /json
<rsp>{
  "ResultProcess": {
    "Success": true,
    "ProcessResult": {
      "MessageID": "MBBF-56I6-ZZ4I-YUDO-S5F6-6L74-JX",
      "Sender": "alice@example.com",
      "Result": "Accept",
      "CatalogedDevice": {
        "UDF": "MAD7-JKFU-RE7E-DPVL-FMCE-6WDZ-Z3LE",
        "EnvelopedProfileMesh": [{
            "dig": "SHA2"},
          "ewogICJQcm9maWxlTWVzaCI6IHsKICAgICJLZXlPZmZsaW5lU2lnbmF
  0dXJlIjogewogICAgICAiVURGIjogIk1CVTQtQzRBSi1UR1RPLUFFVFAtTFFEQ
  y1SM0w2LVZNWDciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgIlB1YmxpYyI6ICJkbjZTNWE4NGJpUDI5elFsVHNGcTJpdHM
  1OGk5WXJFalFOM1N6bVNCc1YzN0tsdkpGY2Z0CiAgSGoxZjN0b3l3M1BlTUdPR
  0VBYzhkVFVBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3sKICA
  gICAgICAiVURGIjogIk1ETjItQVhBSi0zVTYzLTZJVFEtSjJENS1DWUg1LUhNS
  lQiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogI
  CAgICAgICAgICAiUHVibGljIjogIi1iT3djSkYyZnB2ZjU4eUFkNmxJTnExZGY
  yQkVYRDYyd3BZNmdRRXpyUG5zU3RIZEFKNG4KICBiUXFPek8tbzFwc0YwUkRXd
  URhQXZua0EifX19XSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgICAiVUR
  GIjogIk1CU0MtSFVDUS1MNjQ0LTQyQ1QtVFlRNy1TUE5MLTc3NUsiLAogICAgI
  CAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI
  6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljI
  jogIm4xRm5VdWZHaDdaOHJad2FPNEJFRWt0S3h1ajRlUHFSNFJxcnl3VTU1bVQ
  wZk5BckJ1LXMKICA2eWpKS1puUFRoSHpGci12N2pVX3U0b0EifX19fX0",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MBU4-C4AJ-TGTO-AETP-LQDC-R3L6-VMX7",
                "signature": "ekJ21H4Em51VHkZuw-wLLxw_Zr0SQgaCoWSJ_1V8i5tkbPpmb
  0VN1dqqahtqgr9wRi3wJHXDxFoAUov5ZRbL8h_XlXOWVcGJnG6Kg-hvzv0bjOZ
  _YnyBomcRpGvWwCIGBI4atrijPefpFJlhmeDOzxsA"}],
            "PayloadDigest": "637FkhvB-AOIsnaaMBZd1Lz3mjjwfQPsMHBXN0eGaLGd1
  BmpTL9Weg55OqHUiQzWbbrBH14TVbFlpMQ8iQhntw"}],
        "DeviceUDF": "MD7W-S6XF-V4EL-7QEO-MUPK-B5JL-MLPY",
        "EnvelopedProfileDevice": [{
            "dig": "SHA2"},
          "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUQ3Vy1TNlhGLVY0RUwtN1FFTy1NV
  VBLLUI1SkwtTUxQWSIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogIjlpWVJEWnV4OVJKanNkdzRVRlF3NVN
  kX3R3U0QxYVl0OExyVi1LcjBUbkt6UDBZUDgxbzUKICB4emtteTVkaHpVRnp4N
  F95dk96TE9rNkEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUEzVy03NFdGLTZWVTQtWkFSRi1DTlIzLUkzUFctUFpBNiIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAibFB1V2RiZzV1clVZTFpPNzVYa0g4aVZPT2tuTkMzdDNCQU5aNXpBRUh
  tWU1aR0lXaUpmVQogIGNqakVJeXNTS0MzVndmVXRzNnJEZVBHQSJ9fX0sCiAgI
  CAiS2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUFLWi1IV1V
  ZLTVaSUQtTllDUy00UVozLVVNM0ItWk9OSSIsCiAgICAgICJQdWJsaWNQYXJhb
  WV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICA
  gImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiRTBZOHBDbWlQd
  TZ5YlRYZlM5bHQ5SldWc0x3d1BKMlNlYUpIYnR4LUVNVE9YX2p3b0l5SQogIHF
  UdVViTkFfdm96aGZpTXV6MHlzS2E0QSJ9fX19fQ",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MD7W-S6XF-V4EL-7QEO-MUPK-B5JL-MLPY",
                "signature": "OdOCPcp-aEYYBaieA4sR_wb9cXqdQCcGGK-eSHQfuZBlIyX-c
  adUW4dupiNLocnwx6f78uHVvTmAR5CA8jbfpDvrvd7bozuDMqFuREyASyjvYoD
  42C0g-WTgrVp3XxM73sn5FC_12r70PSQiO_vhVAEA"}],
            "PayloadDigest": "5KBc17By2Vx4iyhK-cRgFoqRS7uHksce-_E3RwXrEC2JL
  8C9-2WSOl0IAsT7ib_wqeetS8aPpxSGDQVkG6MaQQ"}],
        "EnvelopedConnectionDevice": [{
            "dig": "SHA2"},
          "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQUQ3LUpLRlUtUkU3RS1EUFZMLUZNQ0UtN
  ldEWi1aM0xFIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiS0l0X1NybEpmZUU5ckdpYTB5dTE2b2tfYmp
  kRVktOW53SU1GZXh2NW4yc3UxajVHV0FfOAogIGFEVUJ6Xy1QX2o4dkJKamd1R
  VdsMHYtQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI
  6ICJNRE01LVhUQTctQ0tURC0zMjNXLVRUVTMtVlVURC1DUU5MIiwKICAgICAgI
  lB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB
  7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6I
  CJ1b1VTNnBGczFUMXVsTTdMZmp2UXY0bzRkZGJkWkdqaHYza3haa21LSEpfQWF
  2b3lRMFp1CiAgUVVpbDkwM0hMblFfWE1STEdKNTFEWVNBIn19fSwKICAgICJLZ
  XlBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVERiI6ICJNQkUzLVlMQkEtS0l
  LTi1EMkpBLTdRSVctREJFVS1SWjYyIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlc
  nMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J
  2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJLeE1ZUDB3TnJCME9wa
  lhqWkc4NVZFVzFES0RuNC1FSmFVSDhMZmdtc3FmalNLcGNSaEF3CiAgSnlBdnd
  5dW9ON25HYnRLclRnYms0V0FBIn19fX19",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MDN2-AXAJ-3U63-6ITQ-J2D5-CYH5-HMJT",
                "signature": "0MzrJvnepVgujGCJt7PBiwh1emM0Rdc5t_SKEcfG6IWjoHqg2
  pkIlA-Voj4cRE99cWpCk_dQTPoAF5PkFuEhJBEGGtELP-YVrtrIoZF1kTLkuel
  wHsOWu3O4wqjd7NoQcs0cDmFMFNs_NP6iGgK7AQsA"}],
            "PayloadDigest": "f0EIJZ-IlMSY4y9Jl_APe9oiu8a8mf6jeg5w3CtDXLiru
  rPHv6gXdrRkLG9weybbmELl4XysIka1zSOoqOfqcg"}],
        "EnvelopedActivationDevice": [{
            "enc": "A256CBC",
            "dig": "SHA2",
            "kid": "EBQF-5LWL-ISEY-FZEY-HV5L-H7MV-4MN7",
            "Salt": "EglfIPp07UtS-43e0_mvPQ",
            "recipients": [{
                "kid": "MA3W-74WF-6VU4-ZARF-CNR3-I3PW-PZA6",
                "epk": {
                  "PublicKeyECDH": {
                    "crv": "X448",
                    "Public": "NGSiKAx93M2GD3xlAE6O8FgSRJLxsCsr8fMw56N4LMD5T6aOW9dJ
  h7wUJjtqKVHzt1s80KxoitKA"}},
                "wmk": "E7sm5GtzOnz7oNgFBrKzzJOEfk1rkYEkQtYKtS13UDJk5CnqyuWqRg"}]},
          "H_oMgRagnkBfybIlnR9cIQDWINn6jOU8fOvq2UVVwcI720REFRHaYp6
  JigGa8UXbeO13w0Ngs_pn_wXSb49K9puWE6SwVlGixa-Rs7_PHVRJ35hchk9Gl
  se54xSTPWt6Oy2EBTWxUqKY-HCtRYaKdqwzpMAyznPTrZXEWak8PD6LD53V6ae
  rKVHp6WnBTueaR8qZFgoOv-5S4Uniu9DguHIPpcN091__4062fev05TwPxT-8s
  bLsu0FA4b6Gt2nokotbBP_e2zxc7zuQOQ-ZIVEZkaKcsRn_FaYpGeDePfoHVLT
  2wlqvRaSbSgs3qOZiB9CdzflT8XN8sVEo5bQviLcY-dw_u344kSVo3jLHDZPQh
  nKczVe2S2SJ5ffL7vHNtHHR84Wewz_aSFnhnnWee3Awqi-qW5-kFxEQ7r6BVMY
  75_lOQ8XbWQJu104xhQlpF4yhDjXmPMbz1Ovu_undj6FbNZC04BjFbDtAksteo
  U9ja11CepsLU_5Y2sNMBUIca_S2-CwTRBmht8T8mLkPrTX4qvXFKl-iDGghq8z
  1O9gZmDAjhlakRv1u9DJuJMv52YD1q_2Mqq3rAOlFH5ULBL4I78aYiJldVTBga
  L0t18v7dPFVIa3ELTNyy3TowkZ9JnyBpy17ROPbNFEGspA2zNMjquGfY77sIOY
  ZnMOJDXuIJQaruPZ9kUR3BLzHbMvvZ9yF4f1yelRjzyFUMpliLOwsEErfxmHrr
  MuLcTL6yxxz1cxgY4uLGwvQfTfwwfp0ZCBiBiW2xNzV3fR14P7JjWGYzzNvI2n
  brxahRTG7KuHUB_Wjh4hN8yuOFFsOb2tkepBW0HQcNFrvAQjChH1JdUbD1zTwN
  p9yu7QODT3EcmKVDI3cz78DOedjx0saCiKwzC2E12Ws82hZJ1ZOgtSYr3oiQ6I
  iwdx1CcO63ESQtJTP7w8j5ka5Xbpl7sYpq9Sy24FwexgdC9xi8KMJ6_eahHzOm
  ixoRFjbC5iMxIVBPP0wc95kaAI5LXehwwtAow6WgJYE-MGJ0ST23_QoHaPght4
  E5dqAx9dMUtXHiQv7NajgtiM3QsAEEl4N3t93pcd5sWR1FlDt4KoPxos4z1Fsv
  HiKiChzcvQbGngZAXQOTmbBnZQVAfd4KJeWZyNgXpT6Wb4XPLALJuThuGAacnd
  icnxFPBVtjmeQkrBCy0zK1OTGZBs_1HWuI1PhBXbN4hMcLk3TDC1lFF3BRHsco
  lGeWsZaa-Ji3K14QjmvUzEwLzKLatyLsRcJ8AnkalD3L9q83CcF-4FcfwiWf8O
  nZp7JAWoV_7ihJSOeNDCJJFUfqJ39FYTNeGyCui_jMMFHiDPY8vFnqZ9P7EX7Q
  0rJbwInoGB1A-7dE5iKFZ159bbruQ2s7jwuYOT6GBsXvJZGBq-aRG_FlcTPQND
  xKi009xNX-GDceXne7Ox9bhkrBFo6hkVpRiPmKHvjXaqkSiRqGjuCDg0zvdvto
  3VlaxzWshD8KnRG5Je_5zX6uxx1QUs8CPbijqRsNeTKaSxZCiP2d61BP_-D-Mz
  ufNh52Sc9IiXx1sOjS6dGRqXBFV_802ENG5l6jZfZiRPJAvmmWM6e-7wbfeA4C
  obWIO7uW82PbXGYh5GXNNxdOwZfLp4jdiNDoghvMAWGtGbKygq29blY8Wd066t
  NMw8tRqhPnMqiwz1zzXR8gpJA2-AcUOcPxcTcOJjT6ig9ZdH9gL8XgavLZtiTP
  1Q98TMlllcoGmogo1isdhz8PTdNV13NC3xdJlUlucQXmCqvXXv7Wtdp-MEaLsl
  KqJ-8RWO5ov-BD86yNTmP8B3YYYnCKIITjf0ukzXjlSG9JE7oMBE4Is3AFJmv6
  hCg8PyLSuVcuOfmNk1OCAOXMBM4CzJzYDcE53vtdo2QsElKbKJFCbBYWN5iGjo
  djjkN28i1f_goWwGZOZeNXOrxQprSK9EtrBU3It2rfOUiujxk2yBcGEUIEIxqk
  1oL3bejT43Rd_laBCZeg4iR0kJx4z_Rc8L4vBQLGmHiZ2_iYpNIdTxrOuTt-0y
  UH501Qxci5BHWg4TRowYAoMTUK2huZ901T3elDDenr2o3yO3KR4_wbZ06xwe9q
  NP-MLv6acPcg-aiFYL0vE73MR35DWnLmee1d6VBlBAwYrODyUyKLmCyLuakbQI
  a66qBYi1ILpgXDFasbFLEbr8PWq7RHzB3x6K-vsBR-7QpCPQSm01qM9QDW9Je5
  7CEwTnhmo8ptG7L9aZ7c7ZvgXiI_6p47tHMPPsBwJHU2-pZ2JjRovRYNbCcU4r
  xk2oGyz03e1CtKbnxSeJstmzVkEEHc9ltARC8Dw",
          {
            "signatures": [{
                "alg": "SHA2",
                "kid": "MDN2-AXAJ-3U63-6ITQ-J2D5-CYH5-HMJT",
                "signature": "UPZmdAmvFzbJldp7yd9A9gTZvxpwahu_0I1maGkDU1Yn-R1rU
  gj0rylJssR3TGwpxoMpOsSTYOWA2FC2id6r6HDuAo88Id-FQvCSrfmpXQ8lpYj
  JeMZRqS53UHL9I0M9iAm1hIu_lG5DB_DyimW1qj4A",
                "witness": "LBhHdeo0YIHVDWrU2kAhzirZGjcs3-c6jv5BViRv7vw"}],
            "PayloadDigest": "YjHf-iUkM7hLp9VzdrErfZypEfh8Hkhh7qRyMo7Y3-_Da
  2TSU3wefTbZ2wFvCU0hLQjJCm0yVrJwYuPqQy7bdQ"}],
        "Accounts": [{
            "AccountUDF": "MDWA-A3BV-DQ6V-F3MA-L3RW-GITX-JAPX",
            "EnvelopedProfileAccount": [{
                "dig": "SHA2"},
              "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1EV0EtQTNCVi1EUTZWLUYzTUEtT
  DNSVy1HSVRYLUpBUFgiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICI1aXhsSk5lWUhwVWRac0xrUlB1ZFZ
  neVBGODRFamJzZEVUM0VWcmRVNGdsZ3ZEMlBMWVlwCiAgY0tmWnNBZ1c4Uy1HR
  VVnZUtzRHdiZVFBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1ETzctQjNZNi1KWENPLUpQQUktUjI1RC02S1RCL
  VAzTU4iLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogIlBadVUzVEVkQnFuaHlhTzVfM2hwWl9
  OVW9BaFBicjJqZjhJdW5fSGk4RG5BZmoyREtteWEKICBBX2U5WkNFUGQ2Zkd0O
  Tl1cHdZakR2RUEifX19XSwKICAgICJBY2NvdW50QWRkcmVzc2VzIjogWyJhbGl
  jZUBleGFtcGxlLmNvbSJdLAogICAgIk1lc2hQcm9maWxlVURGIjogIk1CVTQtQ
  zRBSi1UR1RPLUFFVFAtTFFEQy1SM0w2LVZNWDciLAogICAgIktleUVuY3J5cHR
  pb24iOiB7CiAgICAgICJVREYiOiAiTUNVNS1STFU2LUxGVVctN0RSUS1NM1E0L
  U03SkMtR1RaTCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICA
  gICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiMGNTbGYzaEJlY2JmY2I4SzNrSGI5NWJJOVR
  5a3Q0VFNVQjdiQVVTZ3NfcjNXMlY0STA4SwogIE8xQmtRVHFod1NFMFlWclR6U
  mhSanI2QSJ9fX0sCiAgICAiS2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUJaQi1DNDJCLUJVM0QtTTJKWi1ZT0tVLVpEWVYtT1M3TSIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiTjU1Tm16algwNFlHOGwxazVxVzBCODk4TE90TThJcWJLb2ZULXJMY00
  yN1BXRFJtMFFfcQogIFlXZk9aR1N6aHpzekJnVjhpMm1JWlphQSJ9fX0sCiAgI
  CAiRW52ZWxvcGVkUHJvZmlsZVNlcnZpY2UiOiBbewogICAgICAgICJkaWciOiA
  iU0hBMiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFUyVnlkbWxqWlNJNklIc
  0tJQ0FnSUNKTFpYbFBabVpzYVc1bFUybAogIG5ibUYwZFhKbElqb2dld29nSUN
  BZ0lDQWlWVVJHSWpvZ0lrMUJXRm90U1ZCSE55MVdTRUZQTFZkUlZWUXRRCiAgM
  EpVVEMxSVRGTXlMVk5MVDFjaUxBb2dJQ0FnSUNBaVVIVmliR2xqVUdGeVlXMWx
  kR1Z5Y3lJNklIc0tJQ0EKICBnSUNBZ0lDQWlVSFZpYkdsalMyVjVSVU5FU0NJN
  klIc0tJQ0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlSV1EwTgogIERnaUxBb2dJQ0F
  nSUNBZ0lDQWdJbEIxWW14cFl5STZJQ0ppWTJwYWFVUXpRbWRRY1RoT1NFRTRWR
  kZ6YkVwCiAgUmJ6QnpPRTE0UjFvMFZXUlBVVjh6Y0daQldHaG1Va2RMZERoM2F
  WaGxDaUFnWlRsNk16WjRWMEp4VkdWS1IKICBraGhkMDl1VFdOUGNtbEJJbjE5Z
  lN3S0lDQWdJQ0pMWlhsRmJtTnllWEIwYVc5dUlqb2dld29nSUNBZ0lDQQogIGl
  WVVJHSWpvZ0lrMUVNMGd0TTA5TFJpMUxURE0wTFUwMlEwWXRTa1ZIVlMxQk1rV
  k5MVU5VV1ZVaUxBb2dJCiAgQ0FnSUNBaVVIVmliR2xqVUdGeVlXMWxkR1Z5Y3l
  JNklIc0tJQ0FnSUNBZ0lDQWlVSFZpYkdsalMyVjVSVU4KICBFU0NJNklIc0tJQ
  0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlXRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWl
  VSFZpYgogIEdsaklqb2dJbkJKY2psUWVUVnJXbTUyUVU5cGFUWjBSRWRSZWpjM
  VpGVkNOVE5wUWtJeE0wWktRWFp6U0RKCiAgTmRIbEpVMlJRV0ZaM1RXTUtJQ0J
  yVTNGT1RHbDVUekJwVVRKYWFuRTVRa1JYVm1wbU9FRWlmWDE5ZlgwIiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI
  6ICJTSEEyIiwKICAgICAgICAgICAgImtpZCI6ICJNQVhaLUlQRzctVkhBTy1XU
  VVULUNCVEwtSExTMi1TS09XIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJ
  ROHRVOHFVblB2cHhFcXBaZF9UV2t2SU44XzFZdFJDa3hHcVNrMkV4YWRfNFBsV
  3pyCiAgQXpHX2NYOVZUNVVtT2FKNmNtaS1sTThoRjhBbS1PZ1JOa3hHa2IxeV9
  PWXRhS0JYblVlQkdIRzNqdG5wbFUKICB2eDNWbFdSZUpuMFZxWU1pVGZjQVE1U
  EtOdWpIYmY0aUNzbzZQU0FjQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI
  6ICJ0V0g5ME81dVYtYjZWdklqaXdpQ2xSa0o2RDJDNjRHWkxYcVprNXBBaHh0U
  VcKICB3cWNDektNM2Y3czZzbE91SjZmWjI2N3VEZzZRUTJVRjU1X3Zqc2lTQSJ
  9XX19",
              {
                "signatures": [{
                    "alg": "SHA2",
                    "kid": "MDN2-AXAJ-3U63-6ITQ-J2D5-CYH5-HMJT",
                    "signature": "dkGE7sfm861Gr8hz-cUEdXJ4ApQ2H51tkRztjdCdybGcytQI8
  HpmxpHaviS0ceu9twujRNk9EDOAbguThMg89BQisy12vpAxfe7m5cRBPYid6v9
  qMUNtaYN-DizwNt_3jvMh2ak9ZXz5iKF1OXSk4BwA"}],
                "PayloadDigest": "GNxcIaJXBAJmelnpMUm3SpQGudDUQkJQVEcqGiKCMXuBv
  vqcL40r06Sja-HsbZkAYcOqYycsF1GH8uwwBa6LWA"}],
            "EnvelopedConnectionAccount": [{
                "dig": "SHA2"},
              "ewogICJDb25uZWN0aW9uQWNjb3VudCI6IHsKICAgICJLZXlTaWduYXR
  1cmUiOiB7CiAgICAgICJVREYiOiAiTUJPTC1BWjdCLVpEUk4tVzczRS1ITkFZL
  U1LSzUtQTU2SCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICA
  gICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsC
  iAgICAgICAgICAiUHVibGljIjogImRzSjNlNjMwT250UXJmR3VSWFJpZ0ZLWDR
  lQ3dfVjBxX2pHNUVqSWVBcDA4UTh5Z1hMWFYKICBBSjJWUXg5cEptR1hUYUZNc
  nNaT0pncUEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJVREY
  iOiAiTUFQNy00NTRHLUdOR1EtQ1dCQi1HSkpaLVFJTVEtRkJXTSIsCiAgICAgI
  CJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjo
  gewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAiQ082M2g5Q3JneGF1Mzd6UGVzV21fNVRIZlJERkdDWExqVVZpZmlJcjBVSEF
  UZmQ0aDJPMQogIG9XekZEY0VYYzU3aDdRUlBCTXhaTWU4QSJ9fX0sCiAgICAiS
  2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTURSQi1ISEdSLVZ
  UUUYtNjUyNy1KUkFTLTZZQUctQ0FBTiIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImN
  ydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiYWtYMGxEYlhHS0dpa
  013TzVaMThzNGY0VEQzUFFnUmIxSXR5SHdjVXFEbHlfZWR0UUd3cAogIGhaTWZ
  MNVB1LWJ3X0J0Uk5uXzdqWkd1QSJ9fX19fQ",
              {
                "signatures": [{
                    "alg": "SHA2",
                    "kid": "MDO7-B3Y6-JXCO-JPAI-R25D-6KTB-P3MN",
                    "signature": "YbhGAbyn_75qEOZz2SPM4rGHRju2QIudr5JI5ZEjgllD33uDE
  nfmLOn8eY9DhpEfw8FffhqscUWApjQ4ROsRJpRaXQu9cujy4Jsn9WIyBfirYCn
  CMYdtEwvTbyhdTS1bNyOruD2MmUCdRdhh4lqIGiwA"}],
                "PayloadDigest": "TOVSBbBnyLYi6uXIQH3_m0L0kLXQ2MbYZ3jZ0yRv6iVn5
  tYcY7R3atFgnH0CMLIrK0HJUo8g5Vs2RRL4bL57qA"}],
            "EnvelopedActivationAccount": [{
                "enc": "A256CBC",
                "dig": "SHA2",
                "kid": "EBQB-RWY7-BKCE-DJBA-SGSG-CKPY-R6TY",
                "Salt": "WgyHf1e1Dv_3i0wnvaHF9g",
                "recipients": [{
                    "kid": "MA3W-74WF-6VU4-ZARF-CNR3-I3PW-PZA6",
                    "epk": {
                      "PublicKeyECDH": {
                        "crv": "X448",
                        "Public": "nLNUvBNI7LMHXubU4fMvaxheBsAezIkA_f0-NCVrC6j39wYhX4Um
  jsAvXupa9afZG4KCY_TAYTGA"}},
                    "wmk": "77LCxFtyR9FrU6W0wd7frj4wrFN4uJIrUiN1w2X2uZ53whC-VEiigA"}]},
              "5bl6KpKGmaXWQBzTjZtQoI3--jTdCzwLwwyTRaJ4nYhxkUcCWG5U702
  lwZq30HkTYnXQl4aMwyQ2j5Vs6KfmZE-r2PGrO-Da9O7amoDnLigt3vZcFuW27
  u2mBWCyhDMVwfrZ1zb1_tcqTaxAlWwL1WNENPCZDAJgdD5K7mV-3u58-o80QMK
  RFCyEgI2QspyXA5y-xwI40dT41gY_VGAjIez6Ccn6QRPFj-6t6pJ1LPdoMRHSo
  6q4WCU-Er-n8Qlz8t5dbbwZDJBiXQkox_R8d_naYDR8BmLzSaqALKSILerQu9m
  4IlSUAHY7BAK1e0FJczpz3_JXFXoRqdZ3Vtd8matvVbi110zmIXV4yY3kFARvo
  otUBZHT3i9tEaiwOGf49KH7IKTrwptytmp_IqC-hyOFwDDqG2JXq-zikC7eg1f
  UZcEUQjaxSdyg6dfZaABFfOW-L6ctrNzHCHDk-phS1vT6OWA8XtD9GJ_CJPK8M
  Ga_KkGkiifjFAYC3FPSFtOWeveIyJtDZkGy_-PT-vf9e2VIGnJoUyzpidOInVY
  MgYJMyXARGj38IiAviPuS3FxAS_exvUed6LcU3jG6L4zlm5Bax9_RimIgNWiyV
  zqZwdPJBLpbUqKdYNYC11gBv3bC4pzAtEgTjp4ZsanFh6Y1CJdewA4MsMD0RZ6
  -AlF_-ES_kcMnTQSX7NWRoJ5pfaK49pTcC-oJeHUdEl7-tS4HwcoMx4Mni5-T2
  w308VYDrdl-XtTByxlAYionEIpOyZIRd8hfZ9Ib_CUbNsB21qHPjedesHkb0Wy
  7XnRi37oOZ0ZhzdltQzyqfQUTpQUdRTy1YFoc9jYpHoqPM8o8RaeBYtokZHJ7i
  lbCNWCV1vu7XOR7YAx-B9yHW88NkSIEXqrP1BO8ZD5p4Y9ykWnaAI6ZBilndty
  ZkjQX1B5RIg4hjZDLpEAC17afAmKcnueKfeIlfyv4wa_jUnlQZPqrV1CN-0P8g
  rM3MwbiW3Jq65KpqyNmpQ55JYQaxNTX7hFebvC1RiesDUi3Uz_MYJX9O2_aiSC
  Js7p2XhQGbgVsrtzKYa9Pffm5KPBXZf8C1SwCvrDHglaiNkyvEC3rAAdwkN57b
  DjKNV1-UzYoAlKFPxgKDFxAAkM-TILxWsKuoS9VYHQW5b9V3xy_nu8ejhxIioX
  J4ZXneDFMB-ijow6_f_-H3OcHoFIgokqvMMXaYVuv_oAWU1zvFhYq9J_vOSLlJ
  zOfoVjbkwY5-Mk5N8gYv6lFT6dlEaSzQhdCgKImNDMLayx6MIZy82PuyoAVr6Q
  KdqEO2AJKHD19Exfz5ayFrDSoJ-rjFybB0g7mHkfx5Rji7_gmmGGLUnKp-Wn-i
  L468w2WphzuZJsX6pmXIZLzlWeXvPljfmDAiEf4zYis4g9BCdfBgtqoG2tzS-E
  mdli13XJhaY60WkA_xdCTIYtjydIbxa4S7wBMfxABbclIoJuXE6pdK2XdL1h8p
  u6O1SPoH7hzzNKBoq4TGXI-_fTRPLhMnPZwcC-v9uTsOaqtAS3FY_eRfhgaB67
  tpLI-AVyH1gF7b9Bo0HStRxbJaixwxnuFz3QFTNL2OtqQdcVWCTu6neuMnGjmq
  ww7L-nVFclG__CXOcrnQCnanB9gm8Edj8jneXaKlCtnwp8hSzFXaaRBESAJ4CA
  73yFkc93crSSpGjnuoNtjvXO6dWIYpqTX12hfHDhYiUOUfD7VFLUxEzG3Eld6R
  1CqLnDVRKDitjKG4I9jhEV289eG3NZcuuX2gsNVO-XL7FhS-U7Lz-QlGBHIpsA
  FnYAskUePOoEGY7nOPMPZDD6DHL_ErwZbxvC2Z4dO75bFcS-FVYD77L9s07p7e
  nUhY6PEcrym-b8qZXQVMjJWQS4BU_RdzYArxxRR4A6r8GZy7G8eZKf2vm-X38e
  o2GQUSYorwwFzeJyxAmaGg0s05v0PMSdpF8JwkKN27foG-rEoL8Q9JVK3yArpK
  rRGFGVeSLgbMIrqW1FvbQ7uRDY_2-WYQTFQBRiuizv9cyaaN9y3kL1heN-NEG7
  SSPbVspFM8sPwFUYA0Epww3vUdcEdRTt2mjhqvUCn8Zw0g3omkBLeXf6Q5iNjn
  OfBrgHWzszG93dkcTYkP0wR5j7mPdVFUF_4P_2pbgL9lLGZ0JyurSxHd4WPN-G
  76cn6O2jCSBbej3qWjjMq-TRj04E9kqEQ7vXuDqCT76lpLx028GraLMCw7pqoa
  4MT-OKdfiTFgrmW5msy3OPfN5EPlhcblDIaMuqY2r3WtZ1TH6NLjIfAriom_ZF
  1Cw05Vn_1f31tSi08oAlo-cGURH4TR-HKRkPa_KfG7Bgjs-_GLiBy0uvZKSjU7
  rPtPHjgc_LGIo8QJAQu5JAY6bKlFS0Sei8_wpRBmXy6c2vYGwhrxezpxqvhq8w
  zwCNHqFQxo5l6TUFgBXpdTeHdFcQpPNQyogoviOS9T_erjY-Ijzehf9UKL-SLu
  Yj7B6PWmm5AvEqvqUnu4VEGP0N4D5Wa0e2sbYZXO9LAqRDeBBrL1Gc8aQnsl-S
  ZksGaOc5-PFMxBghaFuGCXOKuDB4M8ZrjB0Q7-F3jKRjG3GCz0Y9GeXUkAFj2c
  KsUQRPqVCJ00OV5yT4ULSvqWDCycctqZSapNO-Xe1hG0WEOt4-OIpZTslKo-mn
  AMe63iltdXIsnIGRgj6zLPB0YQ54Vf7aACv4v0eH0PR6lwOEI1SvxAzA94J0i1
  2NQCR9rroUPo1iCIpTXCDOZvXn9jdq3QZfT_21Y646vqz6CDDOPyA",
              {
                "signatures": [{
                    "alg": "SHA2",
                    "kid": "MDO7-B3Y6-JXCO-JPAI-R25D-6KTB-P3MN",
                    "signature": "Bl7NMK-_XthcneIO3qwyDk6OGlJ1yldBKhgMJIHtTwhLW9_T8
  VIzhWy0cYQfq9tIoGw3ctAxNCIAfFhMAKfvRN6_KXYXoNQCUJcR_9NpxtUhskg
  XpgMTuw6x9i6vIsMv4o4rcl-jcDvt9LtHxNSFAAYA",
                    "witness": "LsypOjJ6kqx0KwwqZV4i6JIECS-FFgrC7kmZ5fLNj1w"}],
                "PayloadDigest": "YfJjfv6J-9gDiTJvO68H-y7xph0EC_idRKyZEK3mJx3dq
  JjnYo3iJDLSzp3CUu2UYnY-5Kwjj635CIMmzi-Nqg"}]}]}}}}
</div>
~~~~


# device delete

~~~~
<div="helptext">
<over>
delete   Remove device from device catalog
       Device identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device delete` command removes the specified device from the catalog.

The parameter specifies the device being configured by means of either
the UDF of the device profile or the device identifier.


~~~~
<div="terminal">
<cmd>Alice> device delete CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device delete CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
</div>
~~~~


# device join

~~~~
<div="helptext">
<over>
join   Connect by means of a connection URI from an administration device.
       The device location URI
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device join` command attempts to connect a device to a personal profile
by means of a URI supplied by an administration device.

# device list

~~~~
<div="helptext">
<over>
list   List devices in the device catalog
       Recryption group name in user@example.com format
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device list` command lists the device profiles in the device catalog.


~~~~
<div="terminal">
<cmd>Alice> device list
<rsp></div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> device list /json
<rsp>{
  "Result": {
    "Success": true}}
</div>
~~~~


# device pending

~~~~
<div="helptext">
<over>
pending   Get list of pending connection requests
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device pending` command lists the pending device connection requests in
the inbound message spool.


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z
        Connection Request::
        MessageID: CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z
        To:  From: 
        Device:  MD7W-S6XF-V4EL-7QEO-MUPK-B5JL-MLPY
        Witness: CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z
MessageID: XP3F-7HEO-OYBH-SKCJ-EO7P-Q54P-6HED
        Connection Request::
        MessageID: XP3F-7HEO-OYBH-SKCJ-EO7P-Q54P-6HED
        To:  From: 
        Device:  MC6T-FX77-ABC5-BVJ5-U3C4-MYCH-PQVR
        Witness: XP3F-7HEO-OYBH-SKCJ-EO7P-Q54P-6HED
</div>
~~~~

Specifying the /json option returns a result of type ResultPending:

~~~~
<div="terminal">
<cmd>Alice> device pending /json
<rsp>{
  "ResultPending": {
    "Success": true,
    "Messages": [{
        "MessageID": "CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z",
        "EnvelopedRequestConnection": [{
            "EnvelopeID": "MDXK-RZJW-EWNX-2UPD-267T-6KAA-HAC3-VHDN-UUDG-KPAT-C3WH-TBKI-7H6E-OF5V",
            "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJOQ1NZLVhJM04tQUpSSi0
  yT1dLLUc3U0ktQjc1Ny1BUkJRIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWVzd
  ENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL21lc3NhZ2U
  iLAogICJDcmVhdGVkIjogIjIwMjAtMDctMjdUMDk6NDU6MjNaIn0"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJ
  NZXNzYWdlSUQiOiAiTkNTWS1YSTNOLUFKUkotMk9XSy1HN1NJLUI3NTctQVJCU
  SIsCiAgICAiQXV0aGVudGljYXRlZERhdGEiOiBbewogICAgICAgICJkaWciOiA
  iU0hBMiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b
  2dJQ0FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUN
  BZ0lDSlZSRVlpT2lBaVRVUTNWeTFUTmxoR0xWWTBSVXd0TjFGRlR5MU5WCiAgV
  kJMTFVJMVNrd3RUVXhRV1NJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjB
  aWEp6SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ
  2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0F
  nSUNBZ0lDQWlVSFZpYkdsaklqb2dJamxwV1ZKRVduVjRPVkpLYW5Oa2R6UlZSb
  EYzTlZOCiAga1gzUjNVMFF4WVZsME9FeHlWaTFMY2pCVWJrdDZVREJaVURneGJ
  6VUtJQ0I0ZW10dGVUVmthSHBWUm5wNE4KICBGOTVkazk2VEU5ck5rRWlmWDE5T
  EFvZ0lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZ
  SRVlpT2lBaVRVRXpWeTAzTkZkR0xUWldWVFF0V2tGU1JpMURUbEl6TFVrelVGY
  3RVRnBCTmlJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWp
  vZ2V3b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ
  0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlF
  kV0pzYQogIFdNaU9pQWliRkIxVjJSaVp6VjFjbFZaVEZwUE56VllhMGc0YVZaU
  FQydHVUa016ZEROQ1FVNWFOWHBCUlVoCiAgdFdVMWFSMGxYYVVwbVZRb2dJR05
  xYWtWSmVYTlRTME16Vm5kbVZYUnpObkpFWlZCSFFTSjlmWDBzQ2lBZ0kKICBDQ
  WlTMlY1UVhWMGFHVnVkR2xqWVhScGIyNGlPaUI3Q2lBZ0lDQWdJQ0pWUkVZaU9
  pQWlUVUZMV2kxSVYxVgogIFpMVFZhU1VRdFRsbERVeTAwVVZvekxWVk5NMEl0V
  2s5T1NTSXNDaUFnSUNBZ0lDSlFkV0pzYVdOUVlYSmhiCiAgV1YwWlhKeklqb2d
  ld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGxGUTBSSUlqb2dld29nSUNBZ0lDQ
  WdJQ0EKICBnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0FnSUNBZ0lDQWdJQ0pRZFd
  Kc2FXTWlPaUFpUlRCWk9IQkRiV2xRZAogIFRaNVlsUllabE01YkhRNVNsZFdjM
  HgzZDFCS01sTmxZVXBJWW5SNExVVk5WRTlZWDJwM2IwbDVTUW9nSUhGCiAgVWR
  WVmlUa0ZmZG05NmFHWnBUWFY2TUhselMyRTBRU0o5ZlgxOWZRIiwKICAgICAge
  wogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6ICJ
  TSEEyIiwKICAgICAgICAgICAgImtpZCI6ICJNRDdXLVM2WEYtVjRFTC03UUVPL
  U1VUEstQjVKTC1NTFBZIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJPZE9
  DUGNwLWFFWVlCYWllQTRzUl93YjljWHFkUUNjR0dLLWVTSFFmdVpCbEl5WC1jC
  iAgYWRVVzRkdXBpTkxvY253eDZmNzh1SFZ2VG1BUjVDQThqYmZwRHZydmQ3Ym9
  6dURNcUZ1UkV5QVN5anZZb0QKICA0MkMwZy1XVGdyVnAzWHhNNzNzbjVGQ18xM
  nI3MFBTUWlPX3ZoVkFFQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICI
  1S0JjMTdCeTJWeDRpeWhLLWNSZ0ZvcVJTN3VIa3NjZS1fRTNSd1hyRUMySkwKI
  CA4QzktMldTT2wwSUFzVDdpYl93cWVldFM4YVBweFNHRFFWa0c2TWFRUSJ9XSw
  KICAgICJDbGllbnROb25jZSI6ICJaeGdHZTJUakd2Unl3YTR6ZVB6UTNRIiwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"],
        "ServerNonce": "GLSniO7I_1aD_2ztWJxWSg",
        "Witness": "CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z"},
      {
        "MessageID": "XP3F-7HEO-OYBH-SKCJ-EO7P-Q54P-6HED",
        "EnvelopedRequestConnection": [{
            "EnvelopeID": "MAUU-AAOE-BVX3-KN7Q-6N4J-U6FD-KRU4-544Y-3AP7-QUJA-BJBR-6Y2H-5V5K-6QJO",
            "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJOQ1lSLTU2QUstNkVFUC1
  NUkZULUlRRFQtTVdFQy0zRUJDIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWVzd
  ENvbm5lY3Rpb24iLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL21lc3NhZ2U
  iLAogICJDcmVhdGVkIjogIjIwMjAtMDctMjdUMDk6NDU6MjJaIn0"},
          "ewogICJSZXF1ZXN0Q29ubmVjdGlvbiI6IHsKICAgICJ
  NZXNzYWdlSUQiOiAiTkNZUi01NkFLLTZFRVAtTVJGVC1JUURULU1XRUMtM0VCQ
  yIsCiAgICAiQXV0aGVudGljYXRlZERhdGEiOiBbewogICAgICAgICJkaWciOiA
  iU0hBMiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFJHVjJhV05sSWpvZ2V3b
  2dJQ0FnSWt0bGVVOW1abXhwYm1WVGFXZAogIHVZWFIxY21VaU9pQjdDaUFnSUN
  BZ0lDSlZSRVlpT2lBaVRVTTJWQzFHV0RjM0xVRkNRelV0UWxaS05TMVZNCiAgM
  E0wTFUxWlEwZ3RVRkZXVWlJc0NpQWdJQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjB
  aWEp6SWpvZ2V3b2dJQ0EKICBnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFJJSWpvZ
  2V3b2dJQ0FnSUNBZ0lDQWdJbU55ZGlJNklDSkZaRFEwTwogIENJc0NpQWdJQ0F
  nSUNBZ0lDQWlVSFZpYkdsaklqb2dJblJoTTFaNlpsVm5XSEpTZDJsMlozaGpPR
  TFaVjNGCiAgNk9HVm5NVkZaTlZSRlZGWjRSVzFCVUVRd1JHbzBWRlZQTUV4cGE
  wMEtJQ0J1VlZWNldWaHdRMHROV1ZFd1IKICBVTldTMWxKYjBScGVVRWlmWDE5T
  EFvZ0lDQWdJa3RsZVVWdVkzSjVjSFJwYjI0aU9pQjdDaUFnSUNBZ0lDSgogIFZ
  SRVlpT2lBaVRVTmFWeTFQTjFaTExWTktXRkV0TjA0eU5TMUlWak5hTFVSRldVY
  3RVbEpXVWlJc0NpQWdJCiAgQ0FnSUNKUWRXSnNhV05RWVhKaGJXVjBaWEp6SWp
  vZ2V3b2dJQ0FnSUNBZ0lDSlFkV0pzYVdOTFpYbEZRMFIKICBJSWpvZ2V3b2dJQ
  0FnSUNBZ0lDQWdJbU55ZGlJNklDSllORFE0SWl3S0lDQWdJQ0FnSUNBZ0lDSlF
  kV0pzYQogIFdNaU9pQWlRM0JXVTBad1pWUkNSa3RyYjJacU9IRnpialkwYUU1U
  VZ5MVdXV3B0UnpKd2QyVTVkalZWY2taCiAgYU5HWjZNV2wxVHpaSmJBb2dJRTF
  2V1ZnMVFUQk9TMDFyU21WVFRsTlJWRTR6TW1aWlFTSjlmWDBzQ2lBZ0kKICBDQ
  WlTMlY1UVhWMGFHVnVkR2xqWVhScGIyNGlPaUI3Q2lBZ0lDQWdJQ0pWUkVZaU9
  pQWlUVVJVUVMxSFFWVgogIFpMVWczVHpZdFdqVkpSQzB5VkVkRExWSlNSRTB0V
  EVWV05DSXNDaUFnSUNBZ0lDSlFkV0pzYVdOUVlYSmhiCiAgV1YwWlhKeklqb2d
  ld29nSUNBZ0lDQWdJQ0pRZFdKc2FXTkxaWGxGUTBSSUlqb2dld29nSUNBZ0lDQ
  WdJQ0EKICBnSW1OeWRpSTZJQ0pZTkRRNElpd0tJQ0FnSUNBZ0lDQWdJQ0pRZFd
  Kc2FXTWlPaUFpYTJGS2FubGtUVmRUTgogIFVGbk56VlVOMk5pTVZOSFJXRlZlV
  GRVU0dKdVNFRnplR3hYVkhRMU5Xd3RPSEU0U1hCYVlYVTBXZ29nSUhFCiAgM1V
  ESk9OVFYzUmtWdk1UUmFiMmRtWW5oYWRuSnhRU0o5ZlgxOWZRIiwKICAgICAge
  wogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI6ICJ
  TSEEyIiwKICAgICAgICAgICAgImtpZCI6ICJNQzZULUZYNzctQUJDNS1CVko1L
  VUzQzQtTVlDSC1QUVZSIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICI0SlF
  1cDFzSmxhYVFrY3AwZ2tNTlhyZTQxUVBzNGJibEdZNlFwS3dkbEV3VFdRckFvC
  iAgak5CUlFTVm5LdDJUOWthdWhEbkV1blFlaFNBeTQtWFFaOE1ReE1HNU1aUkt
  aOHh5M1BfZ0dQRHVmR3lDZ04KICBmR0ZFS1RHVGNhaXJFTXdoWHV1OVhaTFRZa
  UlNRXFvTmFCQ2pKMGhrQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI6ICJ
  XMVoyN1YwU1RWTHlVRnRnSlNCbDFTRVlqdlZSUkg4emhKTUNBTE9OclZzc0kKI
  CA4MVg1RjFYNW1wS2NqOUs1MklfemVVNzExWW01Ykgtb1kzanREdlpIQSJ9XSw
  KICAgICJDbGllbnROb25jZSI6ICI0RWxuZmhFc3NiTGFaRldKdFBjOVB3IiwKI
  CAgICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSJ9fQ"],
        "ServerNonce": "unVM1oXYHXO6Te1VfBJzBQ",
        "Witness": "XP3F-7HEO-OYBH-SKCJ-EO7P-Q54P-6HED"}]}}
</div>
~~~~


# device reject

~~~~
<div="helptext">
<over>
reject   Reject a pending connection
       Fingerprint of connection to reject
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `device reject` command rejects the specified connection request.

The command must specify the connection identifier of the request 
being accepted. The connection identifier may be abbreviated provided that
this uniquely identifies the connection being accepted and that at least 
four characters are given.


~~~~
<div="terminal">
<cmd>Alice> device reject XP3F-7HEO-OYBH-SKCJ-EO7P-Q54P-6HED
<rsp>Result: Reject
</div>
~~~~

Specifying the /json option returns a result of type ResultProcess:

~~~~
<div="terminal">
<cmd>Alice> device reject XP3F-7HEO-OYBH-SKCJ-EO7P-Q54P-6HED /json
<rsp>{
  "ResultProcess": {
    "Success": true,
    "ProcessResult": {
      "MessageID": "MAED-GUSI-NZVB-C6RJ-X3F6-SIOP-T3",
      "Sender": "alice@example.com",
      "Result": "Reject"}}}
</div>
~~~~


# device request

~~~~
<div="helptext">
<over>
request   Connect to an existing profile registered at a portal
       The Mesh Service Account
    /pin   One time use authenticator
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /new   Force creation of new device profile
    /dudf   Device profile fingerprint
    /did   Device identifier
    /dd   Device description
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /bookmark   Authorize response to confirmation requests
    /calendar   Authorize access to calendar catalog
    /contact   Authorize access to contacts catalog
    /confirm   Authorize response to confirmation requests
    /mail   Authorize access to configure SMTP mail services.
    /network   Authorize access to the network catalog
    /password   Authorize access to the password catalog
    /ssh   Authorize use of SSH
<over>
</div>
~~~~

The `device request \<account\>` command requests connection of a device to a mesh profile.

The \<account\> parameter specifies the account for which the connection request is
made.

If the account holder has generated an authentication code, this is specified by means of 
the `/pin` option.




~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MC6T-FX77-ABC5-BVJ5-U3C4-MYCH-PQVR
   Witness value = XP3F-7HEO-OYBH-SKCJ-EO7P-Q54P-6HED
   Personal Mesh = MBU4-C4AJ-TGTO-AETP-LQDC-R3L6-VMX7
</div>
~~~~

Specifying the /json option returns a result of type ResultConnect:

~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com /json
<rsp>{
  "ResultConnect": {
    "Success": true,
    "CatalogedMachine": {
      "ID": "MC6T-FX77-ABC5-BVJ5-U3C4-MYCH-PQVR",
      "EnvelopedProfileMaster": [{
          "dig": "SHA2"},
        "ewogICJQcm9maWxlTWVzaCI6IHsKICAgICJLZXlPZmZsaW5lU2lnbmF
  0dXJlIjogewogICAgICAiVURGIjogIk1CVTQtQzRBSi1UR1RPLUFFVFAtTFFEQ
  y1SM0w2LVZNWDciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgIlB1YmxpYyI6ICJkbjZTNWE4NGJpUDI5elFsVHNGcTJpdHM
  1OGk5WXJFalFOM1N6bVNCc1YzN0tsdkpGY2Z0CiAgSGoxZjN0b3l3M1BlTUdPR
  0VBYzhkVFVBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3sKICA
  gICAgICAiVURGIjogIk1ETjItQVhBSi0zVTYzLTZJVFEtSjJENS1DWUg1LUhNS
  lQiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogI
  CAgICAgICAgICAiUHVibGljIjogIi1iT3djSkYyZnB2ZjU4eUFkNmxJTnExZGY
  yQkVYRDYyd3BZNmdRRXpyUG5zU3RIZEFKNG4KICBiUXFPek8tbzFwc0YwUkRXd
  URhQXZua0EifX19XSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgICAiVUR
  GIjogIk1CU0MtSFVDUS1MNjQ0LTQyQ1QtVFlRNy1TUE5MLTc3NUsiLAogICAgI
  CAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI
  6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljI
  jogIm4xRm5VdWZHaDdaOHJad2FPNEJFRWt0S3h1ajRlUHFSNFJxcnl3VTU1bVQ
  wZk5BckJ1LXMKICA2eWpKS1puUFRoSHpGci12N2pVX3U0b0EifX19fX0",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MBU4-C4AJ-TGTO-AETP-LQDC-R3L6-VMX7",
              "signature": "ekJ21H4Em51VHkZuw-wLLxw_Zr0SQgaCoWSJ_1V8i5tkbPpmb
  0VN1dqqahtqgr9wRi3wJHXDxFoAUov5ZRbL8h_XlXOWVcGJnG6Kg-hvzv0bjOZ
  _YnyBomcRpGvWwCIGBI4atrijPefpFJlhmeDOzxsA"}],
          "PayloadDigest": "637FkhvB-AOIsnaaMBZd1Lz3mjjwfQPsMHBXN0eGaLGd1
  BmpTL9Weg55OqHUiQzWbbrBH14TVbFlpMQ8iQhntw"}],
      "DeviceUDF": "MC6T-FX77-ABC5-BVJ5-U3C4-MYCH-PQVR",
      "EnvelopedProfileDevice": [{
          "dig": "SHA2"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUM2VC1GWDc3LUFCQzUtQlZKNS1VM
  0M0LU1ZQ0gtUFFWUiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogInRhM1Z6ZlVnWHJSd2l2Z3hjOE1ZV3F
  6OGVnMVFZNVRFVFZ4RW1BUEQwRGo0VFVPMExpa00KICBuVVV6WVhwQ0tNWVEwR
  UNWS1lJb0RpeUEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUNaVy1PN1ZLLVNKWFEtN04yNS1IVjNaLURFWUctUlJWUiIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiQ3BWU0ZwZVRCRktrb2ZqOHFzbjY0aE5QVy1WWWptRzJwd2U5djVVckZ
  aNGZ6MWl1TzZJbAogIE1vWVg1QTBOS01rSmVTTlNRVE4zMmZZQSJ9fX0sCiAgI
  CAiS2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTURUQS1HQVV
  ZLUg3TzYtWjVJRC0yVEdDLVJSRE0tTEVWNCIsCiAgICAgICJQdWJsaWNQYXJhb
  WV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICA
  gImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAia2FKanlkTVdTN
  UFnNzVUN2NiMVNHRWFVeTdUSGJuSEFzeGxXVHQ1NWwtOHE4SXBaYXU0WgogIHE
  3UDJONTV3RkVvMTRab2dmYnhadnJxQSJ9fX19fQ",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MC6T-FX77-ABC5-BVJ5-U3C4-MYCH-PQVR",
              "signature": "4JQup1sJlaaQkcp0gkMNXre41QPs4bblGY6QpKwdlEwTWQrAo
  jNBRQSVnKt2T9kauhDnEunQehSAy4-XQZ8MQxMG5MZRKZ8xy3P_gGPDufGyCgN
  fGFEKTGTcairEMwhXuu9XZLTYiIMEqoNaBCjJ0hkA"}],
          "PayloadDigest": "W1Z27V0STVLyUFtgJSBl1SEYjvVRRH8zhJMCALONrVssI
  81X5F1X5mpKcj9K52I_zeU711Ym5bH-oY3jtDvZHA"}],
      "EnvelopedMessageConnectionResponse": [{
          "EnvelopeID": "MAED-GUSI-NZVB-C6RJ-X3F6-SIOP-T3IW-SCT6-LXFN-SEVO-C7AH-Y52J-7V5C-G4HR",
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJYUDNGLTdIRU8tT1lCSC1
  TS0NKLUVPN1AtUTU0UC02SEVEIiwKICAiTWVzc2FnZVR5cGUiOiAiQWNrbm93b
  GVkZ2VDb25uZWN0aW9uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9tZXN
  zYWdlIiwKICAiQ3JlYXRlZCI6ICIyMDIwLTA3LTI3VDA5OjQ1OjIyWiJ9"},
        "ewogICJBY2tub3dsZWRnZUNvbm5lY3Rpb24iOiB7CiA
  gICAiTWVzc2FnZUlEIjogIlhQM0YtN0hFTy1PWUJILVNLQ0otRU83UC1RNTRQL
  TZIRUQiLAogICAgIkVudmVsb3BlZFJlcXVlc3RDb25uZWN0aW9uIjogW3sKICA
  gICAgICAiRW52ZWxvcGVJRCI6ICJNQVVVLUFBT0UtQlZYMy1LTjdRLTZONEotV
  TZGRC1LUlU0LTU0NFktM0FQNy1RVUpBLUJKQlItNlkySC01VjVLLTZRSk8iLAo
  gICAgICAgICJDb250ZW50TWV0YURhdGEiOiAiZXdvZ0lDSlZibWx4ZFdWSlJDS
  TZJQ0pPUTFsU0xUVTJRVXN0TmtWRlVDMQogIE5Va1pVTFVsUlJGUXRUVmRGUXk
  welJVSkRJaXdLSUNBaVRXVnpjMkZuWlZSNWNHVWlPaUFpVW1WeGRXVnpkCiAgR
  U52Ym01bFkzUnBiMjRpTEFvZ0lDSmpkSGtpT2lBaVlYQndiR2xqWVhScGIyNHZ
  iVzF0TDIxbGMzTmhaMlUKICBpTEFvZ0lDSkRjbVZoZEdWa0lqb2dJakl3TWpBd
  E1EY3RNamRVTURrNk5EVTZNakphSW4wIn0sCiAgICAgICJld29nSUNKU1pYRjF
  aWE4wUTI5dWJtVmpkR2x2YmlJNklIc0tJQ0FnSUNKCiAgTlpYTnpZV2RsU1VRa
  U9pQWlUa05aVWkwMU5rRkxMVFpGUlZBdFRWSkdWQzFKVVVSVUxVMVhSVU10TTB
  WQ1EKICB5SXNDaUFnSUNBaVFYVjBhR1Z1ZEdsallYUmxaRVJoZEdFaU9pQmJld
  29nSUNBZ0lDQWdJQ0prYVdjaU9pQQogIGlVMGhCTWlKOUxBb2dJQ0FnSUNBaVp
  YZHZaMGxEU2xGamJUbHRZVmQ0YkZKSFZqSmhWMDVzU1dwdloyVjNiCiAgMmRKU
  TBGblNXdDBiR1ZWT1cxYWJYaHdZbTFXVkdGWFpBb2dJSFZaV0ZJeFkyMVZhVTl
  wUWpkRGFVRm5TVU4KICBCWjBsRFNsWlNSVmxwVDJsQmFWUlZUVEpXUXpGSFYwU
  mpNMHhWUmtOUmVsVjBVV3hhUzA1VE1WWk5DaUFnTQogIEUwd1RGVXhXbEV3WjN
  SVlJrWlhWV2xKYzBOcFFXZEpRMEZuU1VOS1VXUlhTbk5oVjA1UldWaEthR0pYV
  mpCCiAgYVdFcDZTV3B2WjJWM2IyZEpRMEVLSUNCblNVTkJaMGxEU2xGa1YwcHp
  ZVmRPVEZwWWJFWlJNRkpKU1dwdloKICAyVjNiMmRKUTBGblNVTkJaMGxEUVdkS
  mJVNTVaR2xKTmtsRFNrWmFSRkV3VHdvZ0lFTkpjME5wUVdkSlEwRgogIG5TVU5
  CWjBsRFFXbFZTRlpwWWtkc2FrbHFiMmRKYmxKb1RURmFObHBzVm01WFNFcFRaR
  EpzTWxvemFHcFBSCiAgVEZhVmpOR0NpQWdOazlIVm01TlZrWmFUbFpTUmxaR1d
  qUlNWekZDVlVWUmQxSkhiekJXUmxaUVRVVjRjR0UKICB3TUV0SlEwSjFWbFpXT
  mxkV2FIZFJNSFJPVjFaRmQxSUtJQ0JWVGxkVE1XeEtZakJTY0dWVlJXbG1XREU
  1VAogIEVGdlowbERRV2RKYTNSc1pWVldkVmt6U2pWalNGSndZakkwYVU5cFFqZ
  ERhVUZuU1VOQlowbERTZ29nSUZaCiAgU1JWbHBUMmxCYVZSVlRtRldlVEZRVGp
  GYVRFeFdUa3RYUmtWMFRqQTBlVTVUTVVsV2FrNWhURlZTUmxkVlkKICAzUlZiR
  XBYVldsSmMwTnBRV2RKQ2lBZ1EwRm5TVU5LVVdSWFNuTmhWMDVSV1ZoS2FHSlh
  WakJhV0VwNlNXcAogIHZaMlYzYjJkSlEwRm5TVU5CWjBsRFNsRmtWMHB6WVZkT
  1RGcFliRVpSTUZJS0lDQkpTV3B2WjJWM2IyZEpRCiAgMEZuU1VOQlowbERRV2R
  KYlU1NVpHbEpOa2xEU2xsT1JGRTBTV2wzUzBsRFFXZEpRMEZuU1VOQlowbERTb
  EYKICBrVjBwellRb2dJRmROYVU5cFFXbFJNMEpYVlRCYWQxcFdVa05TYTNSeVl
  qSmFjVTlJUm5waWFsa3dZVVUxVQogIFZaNU1WZFhWM0IwVW5wS2QyUXlWVFZrY
  WxaV1kydGFDaUFnWVU1SFdqWk5WMnd4VkhwYVNtSkJiMmRKUlRGCiAgMlYxWm5
  NVkZVUWs5VE1ERnlVMjFXVkZSc1RsSldSVFI2VFcxYVdsRlRTamxtV0RCelEyb
  EJaMGtLSUNCRFEKICBXbFRNbFkxVVZoV01HRkhWblZrUjJ4cVdWaFNjR0l5Tkd
  sUGFVSTNRMmxCWjBsRFFXZEpRMHBXVWtWWmFVOQogIHBRV2xVVlZKVlVWTXhTR
  kZXVmdvZ0lGcE1WV2N6VkhwWmRGZHFWa3BTUXpCNVZrVmtSRXhXU2xOU1JUQjB
  WCiAgRVZXVjA1RFNYTkRhVUZuU1VOQlowbERTbEZrVjBwellWZE9VVmxZU21oa
  UNpQWdWMVl3V2xoS2VrbHFiMmQKICBsZDI5blNVTkJaMGxEUVdkSlEwcFJaRmR
  LYzJGWFRreGFXR3hHVVRCU1NVbHFiMmRsZDI5blNVTkJaMGxEUQogIFdkSlEwR
  UtJQ0JuU1cxT2VXUnBTVFpKUTBwWlRrUlJORWxwZDB0SlEwRm5TVU5CWjBsRFF
  XZEpRMHBSWkZkCiAgS2MyRlhUV2xQYVVGcFlUSkdTMkZ1Ykd0VVZtUlVUZ29nS
  UZWR2JrNTZWbFZPTWs1cFRWWk9TRkpYUmxabFYKICBHUlZVMGRLZFZORlJucGx
  SM2hZVmtoUk1VNVhkM1JQU0VVMFUxaENZVmxZVlRCWFoyOW5TVWhGQ2lBZ00xV
  gogIEVTazlPVkZZelVtdFdkazFVVW1GaU1tUnRXVzVvWVdSdVNuaFJVMG81Wmx
  neE9XWlJJaXdLSUNBZ0lDQWdlCiAgd29nSUNBZ0lDQWdJQ0p6YVdkdVlYUjFjb
  VZ6SWpvZ1czc0tJQ0FnSUNBZ0lDQWdJQ0FnSW1Gc1p5STZJQ0oKICBUU0VFeUl
  pd0tJQ0FnSUNBZ0lDQWdJQ0FnSW10cFpDSTZJQ0pOUXpaVUxVWllOemN0UVVKR
  E5TMUNWa28xTAogIFZVelF6UXRUVmxEU0MxUVVWWlNJaXdLSUNBZ0lDQWdJQ0F
  nSUNBZ0luTnBaMjVoZEhWeVpTSTZJQ0kwU2xGCiAgMWNERnpTbXhoWVZGclkzQ
  XdaMnROVGxoeVpUUXhVVkJ6TkdKaWJFZFpObEZ3UzNka2JFVjNWRmRSY2tGdkM
  KICBpQWdhazVDVWxGVFZtNUxkREpVT1d0aGRXaEVia1YxYmxGbGFGTkJlVFF0V
  0ZGYU9FMVJlRTFITlUxYVVrdAogIGFPSGg1TTFCZlowZFFSSFZtUjNsRFowNEt
  JQ0JtUjBaRlMxUkhWR05oYVhKRlRYZG9XSFYxT1ZoYVRGUlphCiAgVWxOUlhGd
  lRtRkNRMnBLTUdoclFTSjlYU3dLSUNBZ0lDQWdJQ0FpVUdGNWJHOWhaRVJwWjJ
  WemRDSTZJQ0oKICBYTVZveU4xWXdVMVJXVEhsVlJuUm5TbE5DYkRGVFJWbHFkb
  FpTVWtnNGVtaEtUVU5CVEU5T2NsWnpjMGtLSQogIENBNE1WZzFSakZZTlcxd1M
  yTnFPVXMxTWtsZmVtVlZOekV4V1cwMVlrZ3RiMWt6YW5SRWRscElRU0o5WFN3C
  iAgS0lDQWdJQ0pEYkdsbGJuUk9iMjVqWlNJNklDSTBSV3h1Wm1oRmMzTmlUR0Z
  hUmxkS2RGQmpPVkIzSWl3S0kKICBDQWdJQ0pCWTJOdmRXNTBRV1JrY21WemN5S
  TZJQ0poYkdsalpVQmxlR0Z0Y0d4bExtTnZiU0o5ZlEiXSwKICAgICJTZXJ2ZXJ
  Ob25jZSI6ICJ1blZNMW9YWUhYTzZUZTFWZkJKekJRIiwKICAgICJXaXRuZXNzI
  jogIlhQM0YtN0hFTy1PWUJILVNLQ0otRU83UC1RNTRQLTZIRUQifX0"],
      "EnvelopedAccountAssertion": [{
          "dig": "SHA2"},
        "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1EV0EtQTNCVi1EUTZWLUYzTUEtT
  DNSVy1HSVRYLUpBUFgiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICI1aXhsSk5lWUhwVWRac0xrUlB1ZFZ
  neVBGODRFamJzZEVUM0VWcmRVNGdsZ3ZEMlBMWVlwCiAgY0tmWnNBZ1c4Uy1HR
  VVnZUtzRHdiZVFBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1ETzctQjNZNi1KWENPLUpQQUktUjI1RC02S1RCL
  VAzTU4iLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogIlBadVUzVEVkQnFuaHlhTzVfM2hwWl9
  OVW9BaFBicjJqZjhJdW5fSGk4RG5BZmoyREtteWEKICBBX2U5WkNFUGQ2Zkd0O
  Tl1cHdZakR2RUEifX19XSwKICAgICJBY2NvdW50QWRkcmVzc2VzIjogWyJhbGl
  jZUBleGFtcGxlLmNvbSJdLAogICAgIk1lc2hQcm9maWxlVURGIjogIk1CVTQtQ
  zRBSi1UR1RPLUFFVFAtTFFEQy1SM0w2LVZNWDciLAogICAgIktleUVuY3J5cHR
  pb24iOiB7CiAgICAgICJVREYiOiAiTUNVNS1STFU2LUxGVVctN0RSUS1NM1E0L
  U03SkMtR1RaTCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICA
  gICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiMGNTbGYzaEJlY2JmY2I4SzNrSGI5NWJJOVR
  5a3Q0VFNVQjdiQVVTZ3NfcjNXMlY0STA4SwogIE8xQmtRVHFod1NFMFlWclR6U
  mhSanI2QSJ9fX0sCiAgICAiS2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUJaQi1DNDJCLUJVM0QtTTJKWi1ZT0tVLVpEWVYtT1M3TSIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiTjU1Tm16algwNFlHOGwxazVxVzBCODk4TE90TThJcWJLb2ZULXJMY00
  yN1BXRFJtMFFfcQogIFlXZk9aR1N6aHpzekJnVjhpMm1JWlphQSJ9fX0sCiAgI
  CAiRW52ZWxvcGVkUHJvZmlsZVNlcnZpY2UiOiBbewogICAgICAgICJkaWciOiA
  iU0hBMiJ9LAogICAgICAiZXdvZ0lDSlFjbTltYVd4bFUyVnlkbWxqWlNJNklIc
  0tJQ0FnSUNKTFpYbFBabVpzYVc1bFUybAogIG5ibUYwZFhKbElqb2dld29nSUN
  BZ0lDQWlWVVJHSWpvZ0lrMUJXRm90U1ZCSE55MVdTRUZQTFZkUlZWUXRRCiAgM
  EpVVEMxSVRGTXlMVk5MVDFjaUxBb2dJQ0FnSUNBaVVIVmliR2xqVUdGeVlXMWx
  kR1Z5Y3lJNklIc0tJQ0EKICBnSUNBZ0lDQWlVSFZpYkdsalMyVjVSVU5FU0NJN
  klIc0tJQ0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlSV1EwTgogIERnaUxBb2dJQ0F
  nSUNBZ0lDQWdJbEIxWW14cFl5STZJQ0ppWTJwYWFVUXpRbWRRY1RoT1NFRTRWR
  kZ6YkVwCiAgUmJ6QnpPRTE0UjFvMFZXUlBVVjh6Y0daQldHaG1Va2RMZERoM2F
  WaGxDaUFnWlRsNk16WjRWMEp4VkdWS1IKICBraGhkMDl1VFdOUGNtbEJJbjE5Z
  lN3S0lDQWdJQ0pMWlhsRmJtTnllWEIwYVc5dUlqb2dld29nSUNBZ0lDQQogIGl
  WVVJHSWpvZ0lrMUVNMGd0TTA5TFJpMUxURE0wTFUwMlEwWXRTa1ZIVlMxQk1rV
  k5MVU5VV1ZVaUxBb2dJCiAgQ0FnSUNBaVVIVmliR2xqVUdGeVlXMWxkR1Z5Y3l
  JNklIc0tJQ0FnSUNBZ0lDQWlVSFZpYkdsalMyVjVSVU4KICBFU0NJNklIc0tJQ
  0FnSUNBZ0lDQWdJQ0pqY25ZaU9pQWlXRFEwT0NJc0NpQWdJQ0FnSUNBZ0lDQWl
  VSFZpYgogIEdsaklqb2dJbkJKY2psUWVUVnJXbTUyUVU5cGFUWjBSRWRSZWpjM
  VpGVkNOVE5wUWtJeE0wWktRWFp6U0RKCiAgTmRIbEpVMlJRV0ZaM1RXTUtJQ0J
  yVTNGT1RHbDVUekJwVVRKYWFuRTVRa1JYVm1wbU9FRWlmWDE5ZlgwIiwKICAgI
  CAgewogICAgICAgICJzaWduYXR1cmVzIjogW3sKICAgICAgICAgICAgImFsZyI
  6ICJTSEEyIiwKICAgICAgICAgICAgImtpZCI6ICJNQVhaLUlQRzctVkhBTy1XU
  VVULUNCVEwtSExTMi1TS09XIiwKICAgICAgICAgICAgInNpZ25hdHVyZSI6ICJ
  ROHRVOHFVblB2cHhFcXBaZF9UV2t2SU44XzFZdFJDa3hHcVNrMkV4YWRfNFBsV
  3pyCiAgQXpHX2NYOVZUNVVtT2FKNmNtaS1sTThoRjhBbS1PZ1JOa3hHa2IxeV9
  PWXRhS0JYblVlQkdIRzNqdG5wbFUKICB2eDNWbFdSZUpuMFZxWU1pVGZjQVE1U
  EtOdWpIYmY0aUNzbzZQU0FjQSJ9XSwKICAgICAgICAiUGF5bG9hZERpZ2VzdCI
  6ICJ0V0g5ME81dVYtYjZWdklqaXdpQ2xSa0o2RDJDNjRHWkxYcVprNXBBaHh0U
  VcKICB3cWNDektNM2Y3czZzbE91SjZmWjI2N3VEZzZRUTJVRjU1X3Zqc2lTQSJ
  9XX19",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MDN2-AXAJ-3U63-6ITQ-J2D5-CYH5-HMJT",
              "signature": "dkGE7sfm861Gr8hz-cUEdXJ4ApQ2H51tkRztjdCdybGcytQI8
  HpmxpHaviS0ceu9twujRNk9EDOAbguThMg89BQisy12vpAxfe7m5cRBPYid6v9
  qMUNtaYN-DizwNt_3jvMh2ak9ZXz5iKF1OXSk4BwA"}],
          "PayloadDigest": "GNxcIaJXBAJmelnpMUm3SpQGudDUQkJQVEcqGiKCMXuBv
  vqcL40r06Sja-HsbZkAYcOqYycsF1GH8uwwBa6LWA"}],
      "AccountAddress": "alice@example.com"}}}
</div>
~~~~



