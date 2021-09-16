
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQC-ENQK-RWZR-RT4J-AKJ7-43N3-G7DG",
    "Salt":"e5EKFpGTCGESK2ifnnHR3A",
    "annotations":["iAEAiCBss5fGSZBOE5NA4XFcZcPK61c4wjFMhRcA8gyqp3
  3JXg",
      "iAEBiCAEtGoCG_0npdnTHcjqfVtYo-T085iRv6eMJ2sg9pacCA",
      "iAECiDBv_c48LluEkQQBRQ3OeXq_PDT7PdSm2b2vrlynzisxHMXS3oN3OA
  Ng4Hpb1wzcfBA"
      ],
    "recipients":[{
        "kid":"MBSA-K4SH-7RGV-KO7A-KC2D-C6NF-R4XK",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"YqnHjSbjM60QB1yTrJwFMqzJoBM_zNvW6LnU9BZmBkw"}},
        "wmk":"GLi_Jx8gco1z8hZGCGsNedvyiu6oAMTjXcFYm5_c0acMMuhvbW
  pJcQ"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "uZiSXKpi__4zCTA8OezFIhfJ0NIJGECNaY4_G2Bu64gKfx0g_AfaYTv4LLy91y
  FKEaHwzAUFOXup5PsLAvlpgg"
  ]
~~~~

