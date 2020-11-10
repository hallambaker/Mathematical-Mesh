
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQL-AVQH-MLD6-F2LB-Y5S7-D42J-RBZB",
    "Salt":"dxwNv7jvTYGTpI2CJSH18g",
    "Annotations":["iAEBiCA8drkHjC6UVLeE98mnBSyr4atmDszVNUq1iLEs8_
  0pkQ",
      "iAECiCCADlsT-OQrz_ARdVnPrFGV4mwoCE_5st5ySpN8VqoR0Q",
      "iAEDiDCUV4h3ilOzz_popyX-lcqm8fLUHNLCGNvuOj9BcnCm7cCEqjtCsM
  c3S77boYXB6_k"
      ],
    "recipients":[{
        "kid":"MBJX-GGAM-BXKQ-B2MM-KE4H-ALKP-BOQG",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"v32WmH1VvefieqdT_p7rfe-4f2qWkivIFYiqFt-8RD0"}},
        "wmk":"-Z-4oVcfA-npk59ttaI6_V_BHGKxrFT_W0Wa-4qKHZQSf_Z-F6
  0s_g"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "SPvWPkhQn6pzt1Y3RjzmokmrYX3z-Uth-qs2LUiTvpbnQ17yFM3xR6Jpao2P99
  4cQfLsvhhe_TNLs-pZH8D82A"
  ]
~~~~

