
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQB-RC4J-WYSG-BV3W-AT4O-C7XW-HWBB",
    "Salt":"anbN3mNzj1kd8lm-_rryyA",
    "annotations":["iAEAiCClLBn4j2ynl-2t8eUDNvOFLw_oMTRvC-W67cDYHG
  xtPg",
      "iAEBiCAOHn1SG4CiithFr6plzmoazCt50HVvgZESEGma0aI0kw",
      "iAECiDCfml5v4GEVYPGXWjmtnr_X7wW1mrsG0ZhaohXThmaW3SigEpCrfQ
  76tCeiq-_YpVU"
      ],
    "recipients":[{
        "kid":"MDNP-E33Z-R2YO-HUM3-AEQH-YTER-2O5F",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"6WL-zyEwuWSOnvlB6MoV7vplvjdJ3k2lgiUWNYya2Wg"}},
        "wmk":"hqmBNNDEgRGRIFfHq-X6TxmoCNdeBzfE_v7jemxJpUuWUQ67Pz
  WoGw"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "CP84Lt4JXXKS2s0kk08bIIvduJ3JDX78MTE3zJOF2_cXEOVw-G8UFB-eycW0pc
  pE8zncm4LzwOUAZnVQxj2JFw"
  ]
~~~~

