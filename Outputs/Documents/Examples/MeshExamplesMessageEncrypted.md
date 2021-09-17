
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQB-HGAH-A4J4-RXBN-XO7Q-YD33-74D5",
    "Salt":"ns6AvpzEN7M5NYBlWWqCpg",
    "annotations":["iAEAiCCGuaAXHNUr5fZc6gOV2zKG4zGZjspQFZZHdd60JP
  SQqg",
      "iAEBiCCwFz1o87y0g6gZty1Ytu1kfk_LtNah9t0U9aG_G1qm4Q",
      "iAECiDD1B8tiUMhWvapP5AtExema66o4Ay15Kdjkf8ej6ipdz4-4GsWRz4
  5uUBP0jk6g-D0"
      ],
    "recipients":[{
        "kid":"MB7M-TOJK-4SNN-2WOV-O5DW-WN4D-DKZE",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"SwCyF-vHYkJ5oQHfosHxg-EcHwfE6o4m7APUbKRU6io"}},
        "wmk":"ntu1AkB20ROG-UniiG5EFbr-WO8ZbRaAxcMW4_fzVdu5njtqAi
  6aLQ"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "TUn0CsiRn4M0n2vWfLryxAVHiWeOFxcP4w0zeRPSoKCn1rQM5PTlQDrXeJiEEV
  okIi-8rZQwNSiDUZ8NSDMZBw"
  ]
~~~~

