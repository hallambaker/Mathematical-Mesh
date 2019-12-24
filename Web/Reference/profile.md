

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
<rsp>Device Profile UDF=MA6N-3GFW-6HDE-VA4U-ZCL4-RRXH-OEHK
Personal Profile UDF=MA5E-Q7B3-SQ5O-6OS2-WBTJ-BFVE-I3S3
</div>
~~~~

Specifying the /json option returns a result of type ResultCreatePersonal:

~~~~
<div="terminal">
<cmd>Alice> mesh create /json
<rsp>{
  "ResultCreatePersonal": {
    "Success": true,
    "DeviceUDF": "MA6N-3GFW-6HDE-VA4U-ZCL4-RRXH-OEHK",
    "CatalogedDevice": {
      "UDF": "MA6N-3GFW-6HDE-VA4U-ZCL4-RRXH-OEHK",
      "DeviceUDF": "MCN2-5LMX-BRPQ-ZIVA-XOPV-WPNB-R4E7",
      "EnvelopedProfileDevice": [{
          "dig": "S512"},
        "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIktleU9mZmxpbmVTaWd
  uYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTUNOMi01TE1YLUJSUFEtWklWQS1YT
  1BWLVdQTkItUjRFNyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICA
  gICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0O
  CIsCiAgICAgICAgICAiUHVibGljIjogImREMm9YSG9oZzM0UnhyRmxPbEFMSHJ
  0dGx3N2RRTVg2ZXRqcldsVzNobGFjRXB0YS1LQ1kKICBmcXpKQTI2NFRUU1RTW
  DZha2xNbzNoNEEifX19LAogICAgIktleUVuY3J5cHRpb24iOiB7CiAgICAgICJ
  VREYiOiAiTUJDVS1BS0FDLU03QkQtRk5MNC1XQ1FFLVpWSTUtWFRURyIsCiAgI
  CAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0R
  IIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVib
  GljIjogIlM2UTliT0hrcGtXS01BeENQRm9Gd1VlSVpfaU9wYTZ2b09FeVFiaXV
  HNVBYZzNaRm1nQ0cKICBZZzNlNzRxajdnbmhoVU9TQlJjNlc0Z0EifX19LAogI
  CAgIktleUF1dGhlbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1EWFgtUjJ
  ZWS0zNlZNLUI1T1UtNFZKNi1QNVBYLVJSN00iLAogICAgICAiUHVibGljUGFyY
  W1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICA
  gICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJLT3NoN2JWS
  3pXM0RpcG9wWDYzbGNyVXRpVmU4OEVQZFk1ZmxTLXdPQTYyNUZnLU1VdF9QCiA
  gQXFiVzc0N0Y3LUxnWXFveVB0dmdvbGNBIn19fX19",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MCN2-5LMX-BRPQ-ZIVA-XOPV-WPNB-R4E7",
              "signature": "g8O7V0xjBhiL4GlbXTwKTXoLaDsnLbwz76e-IeDlcxtjmoX0j
  P33FndZ27bhssdpZKkEIAr9HeoAD4b9QP8C0wjIomPACuoZSX4VEwd6ZIn_dbK
  kkx-tVpsawHAzQR8OoZ--3kyLnPECucozFM7HaRQA"}],
          "PayloadDigest": "aubO7HttRYbtiGiKDXEWmK2OQFZXwF2cpXxxe3GFW6Ixz
  yfcxxyLi0AdRo1VQ9yeIi_VB9T6DDeP4YLJcJaRVw"}],
      "EnvelopedConnectionDevice": [{
          "dig": "S512"},
        "ewogICJDb25uZWN0aW9uRGV2aWNlIjogewogICAgIktleVNpZ25hdHV
  yZSI6IHsKICAgICAgIlVERiI6ICJNQTZOLTNHRlctNkhERS1WQTRVLVpDTDQtU
  lJYSC1PRUhLIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKI
  CAgICAgICAgICJQdWJsaWMiOiAiZk5DNmpPZlcwdDdwakxRTFFSaWx2a2owRWp
  hTE4wUkgtaGlLbnZzXzNtU3IyV0FuWDA3NQogIFdZZGZPYjdmc0xDQ2Q5WFZPU
  ndrS1dJQSJ9fX0sCiAgICAiS2V5RW5jcnlwdGlvbiI6IHsKICAgICAgIlVERiI
  6ICJNQUZSLVJEWk4tR1hWUS02Tk82LVNGNkctMktJUC0yVlBMIiwKICAgICAgI
  lB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB
  7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiO
  iAiMDg5TEc1TjFaZ1hVc0JTSGRINjBiQmt2VWtneV9sT2czWmFieXBuWUxyN0h
  yRzBRaU1yagogIDAxN1EwUklzVTV5QmtKUmxHS2VqeThtQSJ9fX0sCiAgICAiS
  2V5QXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVREYiOiAiTUFIVC0zVUZOLUU
  yQkMtNEJGTi1TQjIzLUszU0ItUTVQMyIsCiAgICAgICJQdWJsaWNQYXJhbWV0Z
  XJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImN
  ydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIkZKWVhFS0MwT2p6R
  jNwTldBQWctN0NlcDVSc2d3cGlfeGhiTmg2TG81VThXVjJlUGJ4TjcKICBOelp
  TbU4zSy1Jcm95YXRTUTBFVUxkVUEifX19fX0",
        {
          "signatures": [{
              "alg": "S512",
              "kid": "MACF-A6O6-KJOP-SIUW-TJLE-HT5Q-BZAV",
              "signature": "7QWx584VjYoJ2ktAWrAo7iCQeGW5E8Z91pd1kmuOKLbnsfQPW
  YyUU8aVFRbLXGQ7yPKVcZ5k7zuAD2ioCsFOvaLbhWbYLx8bPLB52vY1PAGkPf5
  KMbmvG5u0EJFr6_SgkNI5Rx6oXvFdm8-HOBBszAwA"}],
          "PayloadDigest": "ZGLaM34mV0p_Xh9quHOFNGIB1384LSJpltMADMsukoFHT
  0pGkXREFD6MbB3pXa88YvrvEGr8CfvIv2e9owRBsQ"}],
      "EnvelopedActivationDevice": [{
          "enc": "A256CBC",
          "Salt": "MfxYELpSrwhBWn31y8E4uA",
          "recipients": [{
              "kid": "MBCU-AKAC-M7BD-FNL4-WCQE-ZVI5-XTTG",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "gIpk6oULlp_jkHfh-GfDzCbw8J7ZBbe9pyUsI8nZgz_g-T8PSmXj
  V7L2mgK0B-2mysDoAXedBzmA"}},
              "wmk": "WAAwjkIHq6TjlRJPuASnPFQG27ro2mER_-8rTfThAYecNG_Ec6oJ4g"},
            {
              "kid": "MARN-NN7V-AFRT-WJY5-HM5Y-A6KR-2ZAU",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "Ed448",
                  "Public": "w1_f-qaXXpzcQaaLwQ4-MWqtHwTNPdYiHcB-43Izl6QvNatMam6h
  csrwoDnzucgDuQ3Oj2j9ngWA"}},
              "wmk": "XO1lSK5efDRcm5qelTZVL8-veBn-NpNDBZ45gs6dKrV97O-2kM5lEg"}],
          "ContentMetaData": "ewogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tIn0"},
        "n0mFZLukiGlI-YAHKYQ2Kxq6r4sh0uLItbf9Qyc52lO
  q2kfh0MLczErbFhjCQeCPRHJUSNgMu1depYAwbBWKEdk7AMF5lyk6On3F-S4Qy
  ainro8yf43meV260c1su96x-0lJMVIPmn7nHVhpR-RrI2VbXQP7jTgixC0Sy7f
  H4buzQGJf2hrKlOR7LG2hhI8pjzmf1kKyBJtXbS_p5hD-aEKvcYfk6KgAXxcpI
  MwBhUkYdOMbJlsQafRl1HbhBYV5VVbi6stnIhSCq26ML2u7FuyKn8UdnpHsPtL
  pdyQZcl_kZYXVsIxpQ22Em-TQqWbENgoD0l35PvQ50vF2t_XOG8GB4Ai97LFpN
  vIuVCVOVmS59LNnYNIl08eVXg3y6sbHpiBj4nIkfJJMjAdzmh_gy4wXPLbLCP2
  kXGK0jsgF8YuU0Ge5J2nqeRf0DlIVo24WEknWMffhQk08AeaJVfrw_jZNfV1Pl
  G-SDXbd9RzD3uKGiswuHXUM44m_hfDVcM13TNRaugPeNsiaUjtOdQcL1lj77WH
  h3Z24x6DgfQNvBQ3uRv9v-dh3Jk2XIZso6SqkQoI9EOG6PDklZt3ReMcFUwcOy
  HF_QndZ76UowPf9HMt4nBiqO0jBcP9eEaFOKZP6enxEZNDGD3Oz1C05ww3t9xP
  0xazQUzYjt6HWZusEDMhE9ezRnPYJ_sOsXpXuTvazhnJyJEVglHMJzeDNZtaPt
  yqix7RiQ-zTXGjhnzc-00x9Eekg9S94kuhUO3g8bHMl615wW-MbGMd23gV3EUU
  XH4tk9JGZz-mrwvC0c-bnj5tVjttXY-45EHqwoGhSHVz5PyDKAkaRiB9DOdc4E
  GGeujmSPE9xvNLntJakclb_XhdvUVWK1LC-iirgCxC2t3ps37-pIcMQkobQciU
  x0DLDvpigGX8Zme5LVzEwqwa6o3uu-Qdzl2sffR4bUx4a51ulgcsCFcY9dhTBC
  Z4gLNvtP4m5nhJWNBGQaR1nVHzFs4y51rPDLBRysS9qz4j9ymlCnfWacShwsBb
  21b2HP1qN6-pWxo_HevWASuuehk2P5hWXOkIV-DZW7d5hgOPGicwGxcfAZhtpU
  jVYa3V17w8fOLNFlbMBbaFln7eT39IRTxmKpe81Z0Q-gldKuB3EtadG6PhpR-v
  6mdyb3N-CxbEvqWLO5Z6JoTmQ8LfUjcfZiG_VIYTLlQLou0-8OmRkMcpIv3Z2I
  YoOCil7HJWDSPZRnJAkKWe4Qp50PcwnWsTv1RLRruB1h1WJMZ8WtdxgcNoo"],
      "Accounts": [{
          "AccountUDF": "MACO-VPCS-SXQO-GQBN-EAOX-AVBZ-W52J",
          "EnvelopedProfileAccount": [{
              "dig": "S512"},
            "ewogICJQcm9maWxlQWNjb3VudCI6IHsKICAgICJLZXlPZmZsaW5lU2l
  nbmF0dXJlIjogewogICAgICAiVURGIjogIk1BQ08tVlBDUy1TWFFPLUdRQk4tR
  UFPWC1BVkJaLVc1MkoiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICA
  gICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0N
  DgiLAogICAgICAgICAgIlB1YmxpYyI6ICJURDg2X3VVbWhJTG1MdmRJcExONXZ
  PcVBHbGFldUNHeElyRC13Z3FZY0tuNHRyNThDNEs0CiAgdDdkZ1gxV2IzRUZhW
  DY4TEZOVUZjVUNBIn19fSwKICAgICJLZXlzT25saW5lU2lnbmF0dXJlIjogW3s
  KICAgICAgICAiVURGIjogIk1DTVQtTFJONS1QSTdNLVRWM0YtMkFJSS1SV05EL
  VgyRk8iLAogICAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICA
  gIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAgICJjcnYiOiAiRWQ0NDgiL
  AogICAgICAgICAgICAiUHVibGljIjogIjJiazNyaVZDa1FXSzVxMl84R2MxeG5
  ORTRhTExyVVZrWnQ2RlNrS3piRXJ2UXl4ejh1N1AKICBselM4ajNmMnp2RFRWU
  HBCcW9LdndLdUEifX19XSwKICAgICJNZXNoUHJvZmlsZVVERiI6ICJNQTVFLVE
  3QjMtU1E1Ty02T1MyLVdCVEotQkZWRS1JM1MzIiwKICAgICJLZXlFbmNyeXB0a
  W9uIjogewogICAgICAiVURGIjogIk1BS0gtRFJQTC1VSVc2LUI1MzMtMkJSNi1
  aTUVCLUxXVkciLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgI
  CAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAo
  gICAgICAgICAgIlB1YmxpYyI6ICJGLTNIQjMzYWFJYnYwRndKd0l5LTdVcnlTb
  Xg1aVpPQUc5TW9rUWdKWEQ1d3pXUmdrYjhiCiAgYkpLdFZuNk1xWExYVVQtS0l
  xTk1OTFFBIn19fX19",
            {
              "signatures": [{
                  "alg": "S512",
                  "kid": "MACO-VPCS-SXQO-GQBN-EAOX-AVBZ-W52J",
                  "signature": "BfImDD_Zd6D3VNFRrDXovVtsA8P-yxcxhD8Aq4UDGrGvOJbhS
  Z9alys1IcDhr4bYQTRM4NF7K3mAnQa0eGTmxPHD9mRWJyDAqNPuBB9VX_phUbL
  s2NsVftsxqSk_eg-B7spaD2QEUXLK0tU8RrPiQDwA"}],
              "PayloadDigest": "197zOhuLE0OxgdYXg92_83tfoxo6QJVM2y0q20_Dn6joJ
  0YT8gyfXgCHKoDQMMbG1G_cYtzxXi0mqlfFFDuUOw"}],
          "EnvelopedConnectionAccount": [{
              "dig": "S512"},
            "ewogICJDb25uZWN0aW9uQWNjb3VudCI6IHsKICAgICJTdWJqZWN0VUR
  GIjogIk1ERU4tNExNWi1BUkpMLTNQT1UtNklRSS1BTllQLUVOVEsiLAogICAgI
  kF1dGhvcml0eVVERiI6ICJNQUNPLVZQQ1MtU1hRTy1HUUJOLUVBT1gtQVZCWi1
  XNTJKIiwKICAgICJLZXlTaWduYXR1cmUiOiB7CiAgICAgICJVREYiOiAiTURFT
  i00TE1aLUFSSkwtM1BPVS02SVFJLUFOWVAtRU5USyIsCiAgICAgICJQdWJsaWN
  QYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgI
  CAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIkhBRU5
  oVXF4aGhTOXJmLTVLVVdFMFhKRWdxZE82RzJFeU5LWUV0MVlfczYzVzRRRGNiZ
  EEKICBvcGFJZUw0ZFowLTk0aXRONGxSM2l0RUEifX19LAogICAgIktleUF1dGh
  lbnRpY2F0aW9uIjogewogICAgICAiVURGIjogIk1DTkgtMlhEWS1TNVFMLUpIS
  FotQUg2QS1GRFhBLVdUNjYiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJNUmp6OUxGQ2s3U2ZoQzhMRGd
  nU1NvV21VMGh1YzNTdkRWU0kwZDZXS09pckFOU2FZMVJfCiAgVlZ1dHNhTXh1c
  U9sV2JUbGFJaEpsa3FBIn19fX19",
            {
              "signatures": [{
                  "alg": "S512",
                  "kid": "MCMT-LRN5-PI7M-TV3F-2AII-RWND-X2FO",
                  "signature": "1vUlo3mrClBwgjseIiTpxW-kkLkxzUgAkfSOZYbS6J9aeH4Va
  MaFNwMgDTWeOEz0xKvCfQpfjVCAIUf1JkjfWx_OPBoSQ9qUSgWFx6vkJobJ1lK
  74LRsCusyDK_FxknJvl_Bk5qVKpAaYdWmGolIMzkA"}],
              "PayloadDigest": "l_prICS7E1Gat0CgnWpfua66eZOZrAymjcPnEZeTMBI75
  XnmKSLzCIyMtcMtkzTTux2xPs5xsWagAQap98wcaw"}],
          "EnvelopedActivationAccount": [{
              "dig": "S512"},
            "ewogICJBY3RpdmF0aW9uQWNjb3VudCI6IHsKICAgICJBY2NvdW50VUR
  GIjogIk1BQ08tVlBDUy1TWFFPLUdRQk4tRUFPWC1BVkJaLVc1MkoiLAogICAgI
  ktleUVuY3J5cHRpb24iOiB7CiAgICAgICJVREYiOiAiTUNUTS0yUVBZLU9WUVM
  tUzNFVi1CR1o0LUdaSE8tWkJZTiIsCiAgICAgICJCYXNlVURGIjogIk1CQ1UtQ
  UtBQy1NN0JELUZOTDQtV0NRRS1aVkk1LVhUVEciLAogICAgICAiT3ZlcmxheSI
  6IHsKICAgICAgICAiUHJpdmF0ZUtleUVDREgiOiB7CiAgICAgICAgICAiY3J2I
  jogIkVkNDQ4IiwKICAgICAgICAgICJQcml2YXRlIjogImtMSTM4UzZtME1hbkF
  zbUQ4cFpWbThwVFRmUDZ3Ums4YUxFSEVmcU9Sb3lyVXcxVVBoaAogIFNES1gtd
  HBVZ0lHYk9KM1R6UTV5UEowbyJ9fX0sCiAgICAiS2V5QXV0aGVudGljYXRpb24
  iOiB7CiAgICAgICJVREYiOiAiTUNOSC0yWERZLVM1UUwtSkhIWi1BSDZBLUZEW
  EEtV1Q2NiIsCiAgICAgICJCYXNlVURGIjogIk1EWFgtUjJZWS0zNlZNLUI1T1U
  tNFZKNi1QNVBYLVJSN00iLAogICAgICAiT3ZlcmxheSI6IHsKICAgICAgICAiU
  HJpdmF0ZUtleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICA
  gICAgICAgICJQcml2YXRlIjogIm9DVjJGa2x2a2lUb0t6UFZMZjNseFJCT3BJd
  1JVc3pGZjRrcF9fVWFXeUFqb2xUNzFxVQogIHdiRW1CczNDdDVia21WNVN1RWJ
  JZUZuOCJ9fX0sCiAgICAiS2V5U2lnbmF0dXJlIjogewogICAgICAiVURGIjogI
  k1ERU4tNExNWi1BUkpMLTNQT1UtNklRSS1BTllQLUVOVEsiLAogICAgICAiQmF
  zZVVERiI6ICJNQ04yLTVMTVgtQlJQUS1aSVZBLVhPUFYtV1BOQi1SNEU3IiwKI
  CAgICAgIk92ZXJsYXkiOiB7CiAgICAgICAgIlByaXZhdGVLZXlFQ0RIIjogewo
  gICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHJpdmF0ZSI6I
  CJMZ18zQVlKcmpDSXFEcVZHandvSWRJVjE5V2sydVUzUENqaHhfSHlvTFhFTk5
  5dlRzS04KICBReUhhR2IzSWhseUI4VjZtVUhNUlptdm8ifX19fX0",
            {
              "signatures": [{
                  "alg": "S512",
                  "kid": "MCMT-LRN5-PI7M-TV3F-2AII-RWND-X2FO",
                  "signature": "4Rv_PGAX_P9YyhmxoCrwf2YEaH-Vi4J6GjGehioLJ95fDtIim
  q-krWqymDIOB8Buu_d6McCfe8CA-DtqvSBtPoH8_QAV63Ewe9vBvYASq6H3wjl
  CyeAsu3uBErQuoBSMarWRY7iYOzLkHT9Bbi8oYzkA"}],
              "PayloadDigest": "bOk_9vMwVFTQGB7DYuKbBPgluPNOXDg_TJnaCpQB24G8C
  baKGRls42Beh93FPIaltG9FIJ0B5RN6YB--SK5YkQ"}]}]},
    "MeshUDF": "MA5E-Q7B3-SQ5O-6OS2-WBTJ-BFVE-I3S3",
    "ProfileMesh": {
      "KeyOfflineSignature": {
        "UDF": "MA5E-Q7B3-SQ5O-6OS2-WBTJ-BFVE-I3S3",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "hhSXGudvaKioISZ-ssaUkYWN5fewX8LCAg1i73KpGmpTsYY30F1I
  2oPyYkqfg6YbkG_LQ9FTz7qA"}}},
      "KeysOnlineSignature": [{
          "UDF": "MACF-A6O6-KJOP-SIUW-TJLE-HT5Q-BZAV",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "nvMQqs_j6QMgLFvu5w1n9nBqJqTo31Rd1uQMDQCCIoCkjVRIU9hL
  Hn8tAiXIw2VV_ciIwOp9QT6A"}}}],
      "KeyEncryption": {
        "UDF": "MARN-NN7V-AFRT-WJY5-HM5Y-A6KR-2ZAU",
        "PublicParameters": {
          "PublicKeyECDH": {
            "crv": "Ed448",
            "Public": "kObjX7_LR1REsDrlODpj5uPYVy85CReeh3_lhHjXdlPlZZsWQmT6
  AsGbUvDeHdOmw5NZbrnfAEIA"}}}}}}
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


