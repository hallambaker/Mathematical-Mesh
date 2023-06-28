
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQA-GAWN-XMQL-SQAG-VNRL-XTLP-JFCN",
    "Salt":"3eEtrAnN4wfdDvfQoD-Y7w",
    "annotations":["iAEAiCAgp-PQwlQ7f5GQh6XN1bgDr5ltT9aY-egyRw6sOI
  BRsw",
      "iAEBiCDCH54KTiA3j_neZDlvR3IsUsNRh0NvAtKwz4UuNwCWNw",
      "iAECiDB91pAwNeqAuIEvnb0c-u0sE8By2XrHSuzoqhZcpmoA-j80i_mD2x
  2ASQwZ0x4EXQY"
      ],
    "recipients":[{
        "kid":"MDFQ-C642-7ZJ6-WVCA-QHPW-236B-UNCE",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"GWX6yECOK50Sm9mLnnyjHazMufTLEnAYlut3Lsz5QXQ"}},
        "wmk":"MF2WlbwIgGWlQWGevcy5OGyLnnu1CBQqHoAlq162sl3mb_wu8B
  k1-g"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "4lTvJ9UGNlBVMHBN_e6yk2m4cQldY6eqEBjZh7n00I_hzybzfrTJVJ3qoZuYLU
  em6695poMg0Kh6ny8i7cL4AA"
  ]
~~~~

For efficiency of processing, the ContentMetaData is presented in plaintext.
This header could be encrypted as an EDS sequence and presented as a 
cloaked header.

