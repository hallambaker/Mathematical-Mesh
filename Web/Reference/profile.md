

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
    purge   Purge the Mesh recovery key from this device
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
<rsp>Device Profile UDF=MC7B-CDOG-VA7F-TCBO-4JCY-QC6F-2F5A
Personal Profile UDF=MCOZ-GIZ3-34VQ-GQ6J-FCS7-BJIU-JCOY
</div>
~~~~

Specifying the /json option returns a result of type ResultCreatePersonal:

~~~~
<div="terminal">
<cmd>Alice> mesh create /json
<rsp>{
  "ResultCreatePersonal": {
    "Success": true,
    "DeviceUDF": "MC7B-CDOG-VA7F-TCBO-4JCY-QC6F-2F5A",
    "CatalogedDevice": {
      "UDF": "MC7B-CDOG-VA7F-TCBO-4JCY-QC6F-2F5A",
      "EnvelopedProfileMesh": [{
          "dig": "SHA2"},
        "ewogICJQcm9maWxlTWVzaCI6IHsKICAgICJLZXlPZmZsaW5lU2lnbmF
  0dXJlIjogewogICAgICAiVURGIjogIk1DT1otR0laMy0zNFZRLUdRNkotRkNTN
  y1CSklVLUpDT1kiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICA
  gICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgIlB1YmxpYyI6ICJRMVVBa0ItWE44Z1ZKcV9HTVF0emRZN2Z
  ydndVZi02OF9nbEV1b3BjcE5VMUo2blNtS1EyCiAgZDVkRkZaMVRYbThoWUNFc
  FFXUk5pWDhBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3sKICA
  gICAgICAiVURGIjogIk1ERjQtWUEyRS1GVkdKLUxBRzUtSUs1WS1GWEJCLTJJN
  TYiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogI
  CAgICAgICAgICAiUHVibGljIjogIjhHZXpMOWdseHEtQ3VIcDREUHdnSFpzMks
  1ZVhtX1BhZTQzcHAtbzluRWdvTHRsTVhUMVQKICB2ZVg0VmpSTG1BMGpRaDFIZ
  XRJNUFtbUEifX19XSwKICAgICJLZXlFbmNyeXB0aW9uIjogewogICAgICAiVUR
  GIjogIk1CTFQtM0JEQS1TUjRTLVNSQkEtSlZGQS1ZQ0NHLURBRzIiLAogICAgI
  CAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI
  6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljI
  jogIkhLdDhGdnA2QVA0WW9Xam5Dek1UZlp5N1RYWXUzNjBEOThkN0t2bmhaYVh
  XU0gxOE9qczUKICBfY2EzM0I1WXdxeEhJS3VCSTQtRG5zZUEifX19fX0",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MCOZ-GIZ3-34VQ-GQ6J-FCS7-BJIU-JCOY",
              "signature": "-JM6TM7W2WmDOILniZJJBnfNVHW4VzPQ6Hbl8Td17riEgJVUV
  BS40y_NBwRhfC_70vMJeuXRX40AT1G7zFBh_bUTLXBv7fqk4MDAoDdBt_vDGgK
  _LYhVSej_K-0pYIKovb0FiX5za_QuaMJW_HpPkDQA"}],
          "PayloadDigest": "-E9oIRhcwUVwnNhf1-mRhX1mBqBsucvV_q6Va1zKLMk9G
  4HsfjGyBNi1CtOzqcTcOk3kwqcADQYmeQ8DaH3scw"}],
      "DeviceUDF": "MDNT-Y3SK-UGF5-NPYP-XDCK-OWHW-Z7FN",
      "EnvelopedProfileDevice": [{
          "dig": "SHA2"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUROVC1ZM1NLLVVHRjUtTlBZUC1YR
  ENLLU9XSFctWjdGTiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogIkdVdDhfREpVMGtpa1EzN21GZkFlbVF
  ZeTlZT0REQS1ZXzgzODMtVkxjelJ2R0gyNG9yazEKICBEYnZaYjFEX1NQaWoyS
  jh6MEc4akhaeUEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTURVVS1SRTM2LTJYRzQtMk9BUi1WWVJOLUVYNjUtWEdaQyIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsa
  WMiOiAiQmtUb3dHaXhPQmUyR1dPMUR3dUVYQm5jdEoyOWJ3Ukl4VVFXVFUtSVR
  fbWxUVmZtTnBZOAogIFkwRXNYcGlkN1d3TDlRVXdsejlCNXctQSJ9fX0sCiAgI
  CAiS2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUFUVC1YVkg
  3LVA3QlQtTzJFNy1TUVlJLVRYVFotR1BVSiIsCiAgICAgICJQdWJsaWNQYXJhb
  WV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICA
  gImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAidmlZQUttVV84b
  y1UY29Yb284eGZfVjlkdVVVNnhyUV93TmVBR3NTdm5Jd0h5c1A2bzhPNQogIGI
  xNklFM1V3YTJ4dFYwSVBYdFNfZGFvQSJ9fX19fQ",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MDNT-Y3SK-UGF5-NPYP-XDCK-OWHW-Z7FN",
              "signature": "K39Ma4jDziIljv2jzTT5jJ50MHsDz-er6garpv5RUzFFWKvjP
  g785DtNmjGLqdIYivE9qULYHHgA-INwROlWG3y4vjvkwxcW268SrJwS0o2ao9y
  nBgvvlq2Zn0i-Ydq4l5zbDRmF2b7S_Ww2Vb-UmTIA"}],
          "PayloadDigest": "1Jk8amSOEDoYRPopfjCcOGD2jebt-NPan3g1y8qAoSSMT
  XaRPmcBsAs13OlvxiSHe4MHRcD7Lo60SdWjB-v70g"}],
      "EnvelopedConnectionDevice": [{
          "dig": "SHA2"},
        "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQzdCLUNET0ctVkE3Ri1UQ0JPLTRKQ1ktU
  UM2Ri0yRjVBIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAicmNjOHktVkcteHlJLUtLWEgyMHRYY3dUSHJ
  Hd2hESnIyYnhUclZsSzIzS3pjOWhmbXdOawogIEpndjc5RXg2anlSaGZhckFIQ
  k9PRElHQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI
  6ICJNRFFWLUE0RlMtSFpCMi1QQ1lHLVZQN1otVEs3TC1GNkZMIiwKICAgICAgI
  lB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB
  7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6I
  CJndlRrRzJrNTk0VmNaaGVWQnotNUNVRXhJMG5wSFpUdWx5TlZiSHhubS1QWjg
  zRWFPUGhiCiAgT0xXRjNncEtoYjFtb2FWb08xZTJHWTBBIn19fSwKICAgICJLZ
  XlBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVERiI6ICJNRDVELVZYRVktMkp
  JWC1SUlVCLVFYQkUtSkc2Ni1EUlA2IiwKICAgICAgIlB1YmxpY1BhcmFtZXRlc
  nMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J
  2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJPeHhGbmhpNmdZc0VOa
  1gzeEdHRVpiVTE4bE1tRy1EanJ5ZmdxdXg2dG95SlpKc2tkai1iCiAgNElJQXF
  wNHZPa0hVN0JxanhTZ0Y5QzRBIn19fX19",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MDF4-YA2E-FVGJ-LAG5-IK5Y-FXBB-2I56",
              "signature": "EKkjI3HoORnAS8lL_r-nCuEGfKg7oqL_KnZqlyPR-2ReRIRHV
  igkxXtQNQPmB56NZNdfuWC3V4qAQrNBEd8IYuxfomiWKvcl3eifFekt4TphzOk
  kHzQOETaACLEZuBwURWuvEnYkBJRNkNYDSbwelCoA"}],
          "PayloadDigest": "jTc0_GpBot2m1F03vaOlZxJA8ywl78dpiFLd8a6OBWwY_
  Lm7Zt5sEG2tIGHr5VJPo6cW72wXAFHyA3LQuyTy4w"}],
      "EnvelopedActivationDevice": [{
          "enc": "A256CBC",
          "dig": "SHA2",
          "kid": "EBQD-OOCD-I2BF-HRB7-PJYK-4POE-ZIRL",
          "Salt": "DBIuRwlk2nO7IkSdNuSDuA",
          "recipients": [{
              "kid": "MDUU-RE36-2XG4-2OAR-VYRN-EX65-XGZC",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "X448",
                  "Public": "kez-kE6lKhWlw0UIDzelnq8BgT-RA2OnPpIMJk6cKyVIFtvVPGxo
  taibXISA5Kxkw2bkgdhsmW8A"}},
              "wmk": "rW6FFFj2_7quno0il3X9TsuTkspvZMqYh8nZfJfu6DnAk_eLHtpbsA"}]},
        "-v7KPFVFY75pPqg9N2RD1sU7BBPhE9Yhzx4vs778YZIXgH2tQTnVVtA
  nCD3TbVrYH5RRfc9aEfwfyTHke-9XNjReYH5gg-V9Il9BNkIXoczefaKHdpj1c
  CK21RVdWMTS5yd4q4Vpp77NzyzSdSX5Q0IMpjzMHnWoGf2UN9xJruIEPVCtv2g
  -g41yPvcHzTeXBfI9hag2MopmKe1hM9foaFkS-5LUBbBGFCeglxuF06qaIuofd
  py6W3TCHOsSx3ALfbsQa84XF9YgzugjYKXcGAvnA5v8jxMRiWr_gqgOtVvZhSU
  DGBJOMr7DqfQ5F0uEyTkQbgG2fx0caChFwMOCKPohHG0SNR0igrdEwfcYQbcNy
  8Ld1bmQh1OsTmSTUuR6cMFbf4rEYTYxOe22SJnb1ACLjodBY2cUES5J-xIS7RF
  lSDyycioC08kGFWrw1afySDCAwKXoINkoea_nMSRMEqBAhNlyQaCSgSgiydUBA
  FDHmuRPK3nLpRc3Lzq_0pcugsiZAYIDZ8qCNVeJYj4c4eE5dVsQDnUeYhxaC5W
  us7xrfvjqJjdAn0Tq5ln1Oc3gKnPzNXO4DtKxbuqOkHd1-5793-gk-y9eQzT0Z
  mSPM1-8VQAuL54DaR7Rgeewv_gD2CW-z-Z7MxQ4HLtiqItgOVQBe4PR2h_WDjL
  DkU8vJQ-iPXsNXPT4samxVyNfuKpfZ8bMTp_BClFTbd_wquJ5KJsT883mXgbiH
  0Mc2812fLdSSM7pjlm9mtOsebWyU3lgv1yqAbSY7oDPiLoZkbHySi6eNXj2h6K
  tKdFAbd7-gSXE8gPP1DMCPyWVGjECzQR9BUrFfFZjWxKtMMiwTHCq0_FVg8OYL
  H0wVjm0zJvTyDfshFahFs_os6Us8qy0GFJKvulBZGJnNgsQn5e7bYxDV1XK2B4
  gdCgnJeDpyN1HUY6_MjJKd5-tbyFjc_s5rp6Tvj7Vr7TKzTAHZQpJcnG_iB0G4
  BFTB1DCDMCIzpPSCABpDVnhlyKoItoEal9N8hj_S_K_fMAE--NsFuY85EaSpYa
  y8wl6zAO-BaWk1k92ULN0jLBgsiyEOJlwjk5Ec3n2ayICSzduAWzvvpG0OV1AA
  MVDOtVBW_tQdJSht13-wYNOnGRrfK7Rt7PiqSl0MmyaVXF5LqVdAM2LjKpfLE1
  wBSJf9P4nCdunzwol6v5TQ-oxAXnI23uLTEbGASRnbzFXMr_S0zd-skj3zrad_
  xPkp4yLYEQ4mwrNLUShjPn8x641TGiZHVAoSyiMlZj-sjzWSyXUKUv1BJY_Jvw
  gTAQ3ZU7Nah_nTueqymwZCMSZFWISf2zT0ogR4TvWLcMUQ_wYavvP82sqQZtYF
  -gLgc8ZwlmqSfQNsyFh9X6nsgPq4necldj-KLLx9AE8DdR8aq7msvO-VxrCwtw
  NOEmiUIOi720TwtYVVNhWucK-1TIM5pByTKTwlaai-0cnXbgT-u0ONGeLk0n71
  65k0yPmlOyEK_NKQ4u12dm1-rKtmi4KUSZP8zJUqZQNAmcXSfeCL11arj8XNg5
  w78sjZwAX4SrJNLyeDYdp5LGU4t6Ni3K-U1SoXTPV3O_rgoXORH2h5zr4LXRGn
  HojODXxWtEJfElLsR55guzhhbMHZyEFWeC39XY-pc_v9oyKPFEdZf74yPaA1C2
  zr4l7ktLIHBdv0lmRH8VMFxvKmS2y4E0dC0UiJ7d9P-O665lZYhCwJjDaYy-Ih
  eo2-c7OGFbk5EIx6oo8vpWpFmfYf3hRgEBp8pmX_qdSTW_vl68pnOXJDX068t3
  IIloA_cBv-s9PWDvACggTE0E64vYz9l3JE0pFbdF0puB5QR6llWJy_xbFK0V2b
  wD4Day_uw49H-eT6E3SCTm_LYl-_qinOJQqHIuwiItpbymqI8OOGvXQ7juPhmm
  -zwBxwbIKGPECcdblhE45upESIgBBH9wz2YoOo5JgmYlv5zKSgwzdn2XH7FBXa
  vB-Z6ve50lQafGMqExy9Q_lBiEqMdZBwc6GZwdUjVLRGhPyWMb4GG938n7WlTU
  cs0Xpy6qWMMAalMrnRdpS97FcLWXsGruheNbQC8ymi8Aj36l0ztOWkwXP9S70v
  GiddLouRUvGjYdRdvM2hbJFuJ9g5K-jncAz5xXRvcD-fg0XwwhUG-onu1YADye
  7f6jWGyS2nc5Zon5eC4NEAjq3pSug8_qq79DWwqN_yd1iPt2VKUsm2mC71gzfP
  Q6TugUdD5EtvIIQR-nkcdpg-0qDyh9VozAoaFtALcFhc8_I4hFa5fUmRk7O9G6
  86ismofNof5-D-Fmhqlr-u7Bl-4alAsrgcCc1fg",
        {
          "signatures": [{
              "alg": "SHA2",
              "kid": "MDF4-YA2E-FVGJ-LAG5-IK5Y-FXBB-2I56",
              "signature": "8kC6pG2NnimZw2vPjCZlWy22owYLG93SZNMqWkWeDOggPsSZO
  fIQPAdtKk18r1JfNpY-HiSitnCAHpFbysLqt9xyk3ZJbC1h-Xl2tHh3aJmMMmg
  FH9siwAApxzNsEHaKS0LOgVos2HBIO4o5aXD1UQ8A",
              "witness": "HeZxvXPC3TV77uE6nO6SCobnS9rfNIOezZzQ7MSbfSE"}],
          "PayloadDigest": "b9SWeL3WEIL-7zi0-hGbdGLcYMFUKMcJeJlxB53PfoJe_
  7E_XcCKMAuHTB5NGwonnguhku6NgMT1a2u1LJ72rw"}],
      "Accounts": [{
          "AccountUDF": "MBEA-67YL-KUQ7-LFXL-BDVK-WA6H-SV7Q",
          "EnvelopedProfileAccount": [{
              "dig": "SHA2"},
            "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1CRUEtNjdZTC1LVVE3LUxGWEwtQ
  kRWSy1XQTZILVNWN1EiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICJwd2pESVR6VmhSMmJncFhGRjR6NFp
  1RTBBT1BiY0JnUExzeWdOMjFEUG5KSUpaWDUwbVZpCiAgYXlTVUpnWXBVRFBKS
  mJEbktudm40bUVBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1BVFMtTDVTTi1PNUFOLUxFUFEtS082WC1RM1BSL
  VlQUEYiLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogIl94eGFKYThySHBtVjNVX3BDYTlFZkh
  wUkNtanlRb2U4eGxhNkpaaGxkRjR1NTVsd3ZaVjYKICA3MDlSWEIyR00xWDB1b
  2x1aE95YW1hQ0EifX19XSwKICAgICJNZXNoUHJvZmlsZVVERiI6ICJNQ09aLUd
  JWjMtMzRWUS1HUTZKLUZDUzctQkpJVS1KQ09ZIiwKICAgICJLZXlFbmNyeXB0a
  W9uIjogewogICAgICAiVURGIjogIk1ENkQtU1lGNi0yMzZRLVE3UjctTVpHSS1
  JUVpSLUVYQ04iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiA
  gICAgICAgICAiUHVibGljIjogImFQQ1dEcEJKM3Qxd0RsemFxMURLeE13NFNKU
  jV3aDFlekcxU09CcWhXY3BBenpTWktJM20KICBmUTIwX0lpTnBsZmpmMU4zWFR
  hTk1ZQUEifX19LAogICAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiV
  URGIjogIk1DQzYtNlpCTy1XQVpULTNTTzQtRFpNTC1RMklSLU1QMzQiLAogICA
  gICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNES
  CI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGl
  jIjogImFLSG9ZdlBxVGhmbE9VejVhME41NENzUWdma0FnTmRGb3E0YzR1bW9YN
  1N2YTN0SHVtLTcKICAwdFZOSHdvSjVYRWdORzJLZTRzQXhnT0EifX19fX0",
            {
              "signatures": [{
                  "alg": "SHA2",
                  "kid": "MBEA-67YL-KUQ7-LFXL-BDVK-WA6H-SV7Q",
                  "signature": "9BC3-7LcSpQbggNKVL5JJ8wdv6rzlPQq5tl6VqqqkGImjX8A-
  xbknOMinXYQzRcX66xwkOT-WdwAlmfuspkN0oJyBANtLvcbjQOkKAK_FcSaZPt
  ycLcxiSBZCw9L8bWvI7K0IGSycXsrgT-oCds7zykA"}],
              "PayloadDigest": "DXwKYmecs5Jqz-NcxXaR54WFZ1_NtT0Jqe6PQPJ0U6u69
  nPrak1-V8GLj3GR2cBbcnxtmkeYKvZbeizg8pF8uQ"}],
          "EnvelopedConnectionAccount": [{
              "dig": "SHA2"},
            "ewogICJDb25uZWN0aW9uQWNjb3VudCI6IHsKICAgICJLZXlTaWduYXR
  1cmUiOiB7CiAgICAgICJVREYiOiAiTUJKRi0zM1FQLVk2M00tMjdCSS1TRDZRL
  UY0UUEtSlRKTCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICA
  gICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsC
  iAgICAgICAgICAiUHVibGljIjogIkotMy1zcm5xX2tTMmVUUDI5VEhoZGtqVi1
  uSC1ieU9JS28xeHVqUW1LU0dsbVRLbkZFLUcKICBJMXlSeHU0NDRMR00tbE9tc
  DNMU3RmOEEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJVREY
  iOiAiTUFSSC1ETVAyLVdXWkwtSTdNWi1MNUlWLVdHQ0UtVzNUWCIsCiAgICAgI
  CJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjo
  gewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAiNDAzSmhpcWtfLXR5bDItckJxXy1Ga0tWc0JvTXBxWTc4YXV0MDJZaVFyU1E
  0OFdxeE13eQogIE1OR0V4a1NfY2JYUmR4Z0hTNzhuUmptQSJ9fX0sCiAgICAiS
  2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTURZUC00SjNGLVF
  aWkItRFBDSy1aWkRGLUNKNjItU0dURyIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImN
  ydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAidmxUb1FELXFUMFg4V
  XVOUEt4UUxMTHZPQzdGSWQ0UHNXSjlKZmd2YTBiMW5JYzJnT2JSQQogIFZ5ajZ
  rUzdKTGhSU094WEhHMGRVeU5nQSJ9fX19fQ",
            {
              "signatures": [{
                  "alg": "SHA2",
                  "kid": "MATS-L5SN-O5AN-LEPQ-KO6X-Q3PR-YPPF",
                  "signature": "r6gZWWOxdkdgcrtH0II6L_S-MoMO-rz3vNbLqecCNayy6kyaW
  xbatpiFBKWbtYrL9pYBe_5GPOiAbi4Y_ygvlhCLNfODYbzpHUpfX2fSzZ576oq
  sHrO5AvQNV-bbR9nI5_wv4QSPMFH_mxyIk71CLTwA"}],
              "PayloadDigest": "KmYvrGFCUB4XVG7wQaXPI5N3CrP1e_8z6Xsx-dSUFWUmx
  UUuy9kkl9SbJpCYReMabWzL8y-QgKD_52oAQlYMaQ"}],
          "EnvelopedActivationAccount": [{
              "enc": "A256CBC",
              "dig": "SHA2",
              "kid": "EBQP-BNWF-TCUP-EHZ4-EJ3B-3D7H-OMA2",
              "Salt": "eqV_QRR_dQrV57FYt09zVg",
              "recipients": [{
                  "kid": "MDUU-RE36-2XG4-2OAR-VYRN-EX65-XGZC",
                  "epk": {
                    "PublicKeyECDH": {
                      "crv": "X448",
                      "Public": "o7rAv-yR_afCmMGXcJaeK13Z7Lz1aX9WPgwQzM295sdoSHIItwh6
  XAvO23xkONPvWDUmPOC5jOoA"}},
                  "wmk": "IHZ1DqRnLmkw-kD51_f1QASHKKp7YgZfoJRsmsdno5G-OVZ9xjFxOw"}]},
            "Tb9CKZygmq9uBRY9Cdzf9oD3E6vOmZkRkDxcJsdcvvivS-kKXAHMGb3
  sNE3IsMBv5uGBc45ScggEJd8nf_uYQ17DBH3f9M-4NFBdUc6rAEOzHiQXsMSfg
  vAZl6K2Buz9OyUtrV0sRRtUJw3HYKV0uvvb3NMUOS4e6bn6DnQZd-qfyfQLV2r
  22dEaot4AwHi_RM7G7kSVkg3VDTKHy8Ag0L_07c9dnM5lJsYEMy0cL5n39iXSs
  fRzj9LAVX-Pe8ZgLU9GpjoZplTCxCqYxZUtMWzz_O_NYu8CLxhMJF8D7TRsTMf
  qF5wWKAEsP5OOoN_hLZBQUN1-vSxHAFg8u2GfU3jNDdACikYHuBu75uGkyCBmH
  MVVxljStyCEWkXxYo0tv_sQlRcQSY9nFYZrXfe8zaxOKyLO1GE-7duLfIa4ugX
  wc_jxUKU97im-VbEBFKurOWZ9MP-R8ELMU8zaPel5tcSR7Z1g768RxlUpaWOTI
  4Rs2Xx6Pe_LhuHAvxcH62UVgMFCLVrw3aoFuwO1B7coaadEBJkkkepT5GsntcP
  3tk55e03TQORTRB8oL7ZgB9SCGDdnqxp18STBoshJ02ZZvX5Fezbx7NeNHSZlf
  4Ww4o2itqu2lsCPUbiIJhjP3EfdIxlj-99qH767Y8dIfUVB1sT13ovcunMZ9Wr
  haUWbE4HqQcpcMr2OJN1mrvtcsBC-qk8AuEHOZywgsiT8BJuaVQYmno-Z1rRzi
  hlP2O9leLGX14OXibRErWC4gkIUgOtoV_lkaVZyPrULcbg1oTlsQuL2HlDg6Yz
  HHXRRRO9sUX4srQArhREeKGmASNyUYhTGFVkePXdcG8H0XzZcWk9PV7ZfwJ6n5
  _YU7LsR-hpViPhq2rhVFNnqPVvlwR63UEBx5XjjcrHUTPWY9xOIWrckmPxRsK_
  8Tm-_Pkg4vi-XAn6uGVMafmeRTp05R2R4EQtDg44HrdbihhP9lA9JRCOzNwWcD
  inogC3oRHOaCP69aqY5f3dvbWSD5oTA--toksA2lU35_jLHHW2XX6SL0-8Q5ey
  5E48sxArOCmTgKCmpWOzoYkKs1wPqTg6f_BCuRu6w7I1QEPpfxKnmvcsG7RJHB
  gJD466a_FwCuubHRyvVVS332TjdAgqrCDVFBF0jZ3ZFokq-o01Z_MHaI2lMQPN
  H6nXA-RtKAM1z9WaJaWdTT8_PXFjq25uYxCBL2k1clldRztmq0E9lQkQlQhf0q
  86x0vY_2aKsJrYM30RvORPfaM8BP6rXixIOMKwfxsWKHAwFMyVhCnSPmRR7Sct
  pqsVo7STzHkD5qLXLXmjQhpohihdn1_iFQsbmx_Bpu38jU_r0gF1oM5DMSp_Le
  GYlawFIugTv2yWZ_EotqqYot2KjRSFDmfT7yvcC-Cuut8CQUkRwpsVqsI5qm9y
  Wmv3i0pe9MWvvkC3bnSHG3V3WI4-dJmYEJ4O6x04kbTJZm5UWHZ36aABjEQfXl
  OBTYrWybJJ9Bos5Tlc_Se1FRA49_Ip0U7v15odFpsQ9kx69nN31jhOofJaJZYI
  EifSWL91izIvf0a8F8u6t-PFZ9XBNSVxCOgnTb6XPlTDMjsumG_coT676Pf9h4
  RZ7mFU8i1zGOaeE4QCWv75OhNQREINYOQKcBRyS3r6UGr2mZlS-zI3AGlAYkw4
  FGHnOuvQ7jxmAikSXo8ALKYqgzCvXZ806Cq8oHsaEqVqOZZfkQeuRr4xY9PIka
  vU78hkE6GpdtqHUuuccwX4c5KJSn1-OyKuV_uRkRwgdUxNj7GaC3z_rpixqxGo
  4Yvnbbme1AdW4_P2HF5XUJj4xVsqK0TeNJE03iF2tO0SBfWyKwkS1wWr3U7GId
  JtJp1ABxeqGrqKb1J7f9SyxfbpPgFlYoHfEGfHLZGXUFAgEI9FG0pObM3-RDL9
  z2q_C6CLbjWMO1Tn9vNY4ZLyx4brwDljYt1P-nG2fEknV7OxmUHzs73RxYVuVF
  P0RcDPErAzw1Kd6PHEWaTVGMWYVSu1DZ1k_fhhi1ygL-wwnIMDzZXFoSBzCqtq
  S4egAdVmhYOKjwYi4Ifm9nMynnraQ8fVaCp1PduuMBkQ1yALnMRUEI5oFvVxCr
  IFRFtMq490dNB3BQSUn-g8p_s9OAVK7CLzhrRNaz6BV_w1FusH_zG1S3GwWfSZ
  MIL70gX0By8XkOFcSdDbig8YiM1BdR7BJnh0_kjxDsHu2peubCH2-FVy3FYL_Q
  skeVkkK0iGLWB51P1DxCu85bKhT_CELRlgWJBw5vctYRTp5iQiFwkQczqiMJaK
  d_egWQlIkNNrZPV-WsCmqKgxe0e7dRczO4VNFtB78rhfnhFc2NSm0wPk04AjmU
  U7a380gPuW0CPR02z0ztnmi1DknTh7jUFfmdV8RXHUIbPFNpfOYdJUVFnJt4yf
  eKGB17CoEcnBY1LISn5eAEHltuRomHzno67OCs-RNMlazd1vKQYAMiepuSTd7e
  gtphEMP6_MkhTYaBXS91G-yE_sF2lJZsqpReX8fCuaM34lTRq6urUPRKh7IM4Z
  LqraaZ4ASK3QRfBj2uZS93i0A8dyN1f_ffR3RHT35xX5VaMRB1JkGiccyEHDCS
  yfNoA3LlzT8N1KPpyooqKkGDvbkLH88maxSsLqcoL0VIBTF-C5wVL_jeM3QP_N
  TJ5zqnsSpJuJrTHiXUnHhfl4BLpEUfkcOrHb8XZ8WTRLyCYbgqBb6R2OVLZtH8
  SGfCJtRmCdKkKwH1BdIwMMX2zhTmmap8tnBvp2vsgWM3NabU0wTVx09aZxj5XD
  m9ANFJJinDj8dfNYFyN-eb9Zqzzp2BbV7FQ-3HmyRwk8hU_rwbyyXHWAMuFGgo
  a-j13leh0O2S0FFWfTNmriqWJg2dKmKLFpwvEyOO7CA5IU534G7U3SoD8hPsXw
  WOG-6BNtuzMhUxch76711XC4MaOkxohDoslyfamvRVGvw6uaHM4Zd1n54Oy3RL
  R2MCUVShPLYTglCukkC8_nH4WnzBtfaeMq2dels",
            {
              "signatures": [{
                  "alg": "SHA2",
                  "kid": "MATS-L5SN-O5AN-LEPQ-KO6X-Q3PR-YPPF",
                  "signature": "mkEOd7NA84EH36XeQV2hA6RSXTRd3FjBPxWOk3rjY0nXvKx_a
  FqGcu6ywa50Xa7DHooBh4L39FeAgGzBJlingimbwMCBq2M0y-4Ww7OwGD5ZqYH
  7juW5ODvkn8NOAYHdYjHKp3onkfdvee5IRkQqzBwA",
                  "witness": "TUKDcII3VDgj9HesDUQelHjnWWQGpr0TlfeK2yWD8Y4"}],
              "PayloadDigest": "iWrOT-Xm43AP3_yqR9ewCaePpWNM_QI6i-TygqbgC0g5R
  q3UwhGBOq_Z67T_Cuash2lWgSsY6znOpKLG0dViQA"}]}]},
    "MeshUDF": "MCOZ-GIZ3-34VQ-GQ6J-FCS7-BJIU-JCOY",
    "ProfileMesh": {
      "KeyOfflineSignature": {
        "UDF": "MCOZ-GIZ3-34VQ-GQ6J-FCS7-BJIU-JCOY",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "Q1UAkB-XN8gVJq_GMQtzdY7frvwUf-68_glEuopcpNU1J6nSmKQ2
  d5dFFZ1TXm8hYCEpQWRNiX8A"}}},
      "KeysOnlineSignature": [{
          "UDF": "MDF4-YA2E-FVGJ-LAG5-IK5Y-FXBB-2I56",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "8GezL9glxq-CuHp4DPwgHZs2K5eXm_Pae43pp-o9nEgoLtlMXT1T
  veX4VjRLmA0jQh1HetI5AmmA"}}}],
      "KeyEncryption": {
        "UDF": "MBLT-3BDA-SR4S-SRBA-JVFA-YCCG-DAG2",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "X448",
            "Public": "HKt8Fvp6AP4YoWjnCzMTfZy7TXYu360D98d7KvnhZaXWSH18Ojs5
  _ca33B5YwqxHIKuBI4-DnseA"}}}}}}
</div>
~~~~



# mesh escrow

~~~~
<div="helptext">
<over>
escrow   Create a set of key escrow shares
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

**Missing Example***

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

**Missing Example***

