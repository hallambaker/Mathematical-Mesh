
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQF-TE2G-YXFI-F5JP-HRAJ-PRT4-KX5I",
    "Salt":"iF4q9uYo92OCNMthunaJ6A",
    "annotations":["iAEAiCA6p4aL8x7xbh-8wLWqgV12GVjKL_pz8rSpRMbGqs
  KfMA",
      "iAEBiCCe5Cewm9DYCaQ9RUhUOeznwtgwioUg_xKG7a9iBXuDpw",
      "iAECiDA5I0hvlrU-YkV1Q4-3yJj20TVpoWjY5KE5_W2AKUDjSqlpcKD4bA
  YTr4wPkbTink0"
      ],
    "recipients":[{
        "kid":"MBX4-C7IN-RYSD-LLTR-SESE-PRSR-3ODH",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"YGB7hjDogRsVkXiu5WbPnD4Sh1a1DHVNssaYQFZn_LQ"}},
        "wmk":"FQk1TiIS8fntlHLxW9ksCwXH9FcAow5ydupQcaQTjLMjkYO2aF
  6NmA"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "QI8evJYpcE2mKyRCy4ZnyQaNHIX9pSbYQUn7E51Q_Zp6EX1-LyZPbeS04k2Q9R
  gookiv9nScq-ub54p0oU85pA"
  ]
~~~~

