
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQF-2YU7-MN6O-L52S-OM5A-N3X7-P5MG",
    "Salt":"RcSUJs2SJ4-BM_iWo8KeSw",
    "annotations":["iAEAiCBMKYkmwVIi_PX3JorImUVPat9xr3alwuI2ty2RM3
  rHiw",
      "iAEBiCC6Jk6Hyvu7prHBQ4mXQ01Hm1krbXAPuwlV5Ka7yJanog",
      "iAECiDAlXzwpwSaTbhwTTd19hdWGKksp3TRSUmRJRt_5lS3LcjMoICOZO9
  B6LKWamnx2XmQ"
      ],
    "recipients":[{
        "kid":"MAW5-HWG2-5AKV-SRYJ-RMA6-LCIQ-UUCY",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"PmPnqDZIaLKBQcpH4_EuESunJBFSGSHxOsdYmuI9LnE"}},
        "wmk":"pCk94G-A2EDE9NilkU_FefJyEyMk53lieONR-Sp1eNv1puMaMy
  8fQA"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "UcvNz-C56ExSWwr6Qz7vkvXc51q6z16rtfBH_ffYOe2pLh6BDKzNeWm9N8nrPf
  yHJIzKtQBPFgY36QuRdD0JlQ"
  ]
~~~~

