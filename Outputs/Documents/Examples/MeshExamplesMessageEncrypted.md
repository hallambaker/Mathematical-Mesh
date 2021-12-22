
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQL-SW3U-XPNT-NY4X-J6Y4-OTTO-3PIW",
    "Salt":"uCHZqtp5mNodKx_wAYXN_g",
    "annotations":["iAEAiCAah3YcOm5Og2Fs__cjhz1EEUAlKPEGosddHvkorZ
  x9Gg",
      "iAEBiCA2CsQQ8QWBTabxSaQyfTXD009yXiaAvVt-iiHy1a72Cw",
      "iAECiDAp8nGNOoWjyy2a4UbevKTY-bIxAFq7lSW3DWKYdTvs7lM9XY0BAx
  rEt0Cul-10Yxc"
      ],
    "recipients":[{
        "kid":"MCVI-JPOH-L33G-ZBOE-74VA-SRNR-EAVY",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"ml-z-X7rUoFYA4zwtFFAxJzH_Qvq9LMLHFTaQQ4h1qo"}},
        "wmk":"ct3EUsOqaqzpxJPtVTVr3o8nAt3VkBXZKp6Zbd3PsjNSMbj7t7
  kdqQ"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "g48GJP826LugLMaKHC0lXY1-knpJwQFtbvCIH2S9yPU6RolG0pKwZLA66KGl5_
  cCE_swL0M1GXNrZN36aYhJdg"
  ]
~~~~

For efficiency of processing, the ContentMetaData is presented in plaintext.
This header could be encrypted as an EDS sequence and presented as a 
cloaked header.

