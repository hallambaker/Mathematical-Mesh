
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQF-C2FA-MKZE-HWLT-4ZRU-C6DS-WHPQ",
    "Salt":"Ag_ECOeKxTMqfhdjyrz0XQ",
    "annotations":["iAEAiCAOn3oC-9T7KJQ0M7nI_2FRsK701NTsQ1taIjO0d0
  CBYA",
      "iAEBiCDJnRznXWxqvFh6-IzldNeHme77MtQcll2218bPuyCmSQ",
      "iAECiDBsYAVleIlFJvWlGPjygp60k9vZqI4u94mTIE0uPOF1U7_eVXVkrZ
  ts9r0Ik7LS3pc"
      ],
    "recipients":[{
        "kid":"MDTY-SXEH-PUGX-DYCP-VLXL-YWKR-ACZ5",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"dBBQiC13CljOy5E2euAdRBYEAvAvvUqDTV0pZFo3dF4"}},
        "wmk":"fvAv3n-1z3-1Dgp7oy3CwU1j_RrRr-BqZsuCCcGURKduhguMFM
  gPbg"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "ho5zcChydiFC1esOKX_LPlSS6E5hdx6tXJtSXUptSRtVKSuXPQZcKOFJG3ov7h
  2SS7AzrVZTy5sUJqyMROB21g"
  ]
~~~~

