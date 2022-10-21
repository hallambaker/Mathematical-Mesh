
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQI-2VQL-DTRO-FY7I-4EGX-3EIF-CMGF",
    "Salt":"jhJra7u5N1xG4rX2_DycsQ",
    "annotations":["iAEAiCDOkq0Bul3Rb-GFS2g36E3o1E3B3puMrUslxJYIqF
  22rw",
      "iAEBiCANcMr3xLuCsdBS9Phi495YUnurUR7KnOlTYmVLnIxNzQ",
      "iAECiDDGe7i8LCuPatoU2VatkG4RW1S2DorDPWfDqhmGjBP_Tvn0IVN1pk
  6cskOdz3BUajs"
      ],
    "recipients":[{
        "kid":"MDBD-G2N6-CEIS-LQJ5-NNTO-PAHD-OJKW",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"XxF6M_hpG3NCWA6MG9ZDIQNeHvY2ZCZkd7k2j63BtgE"}},
        "wmk":"WNb5zwCz7RTJVB1nzlqdrElUNAdYMCw-wyZNx3Jsl3s5oxJ537
  2h0w"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "alNqzXk6MQmTxQEuDRkhFzo7aij2msYZZSvz--yuOllMWD9y6DosokU1b3zkJY
  VKTbmyU1TZZ9FYQRaqqryIaw"
  ]
~~~~

For efficiency of processing, the ContentMetaData is presented in plaintext.
This header could be encrypted as an EDS sequence and presented as a 
cloaked header.

