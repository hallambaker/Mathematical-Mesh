
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQO-IWYM-5JB5-5TTI-5Y4P-EVP2-UUHZ",
    "Salt":"bc62xcZi7LrAkF27NyQRBA",
    "annotations":["iAEAiCCbSqyoNcCTGaQ7b-USUlQeCValr4xv0keISoxRS7
  v3Pw",
      "iAEBiCDwemV9ViVDu_Y5nWpnGxU1x6op97JJKO-253njEMrSiQ",
      "iAECiDC9hdP-bIdO3wy9qOB4txVS-POxRdxtdif2C-yU2W5FD13NVLt1vF
  t9J4bHm9MO1Sk"
      ],
    "recipients":[{
        "kid":"MCV2-Y4W4-4BHT-HXJO-7IC5-WYB7-E6J4",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"alOjoGT2PLHVHXz8NCgpBq-WKQ8xVtXkWvfly7Sweig"}},
        "wmk":"Z50CLfWRHuwtoU1PX2mx4FLDoAi-3nsdOuXfa7kNdqXPRfcmqR
  NdPQ"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "5HvPbKYhsqidgB7Dt4y2MwhRBg9vJzfxHhNpU4vab2Idc6WjYOvUZK7Pyzn_Pf
  wnZscz1ZRZFJKb7O7IsoPqPg"
  ]
~~~~

