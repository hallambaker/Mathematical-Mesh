
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQD-DR7C-4YOS-EEO2-BDAY-5YWL-HZQS",
    "Salt":"VbqZd7LxspE1ns0vTRCtew",
    "annotations":["iAEAiCBUkMuqTusi2Y7CVPpbXJsBbhG_CiUSz4RJ8CB6Jg
  FExg",
      "iAEBiCDojkQmvG6_d4V4-aCHOeKAu9QFkGdcqX1MuuO0P4wUaQ",
      "iAECiDDmXF5TSZRWnGNE0fCBKpuNYOAuH8tab2-v6Y5JDjmzHsJyWtJaS6
  46fySmWTob6BQ"
      ],
    "recipients":[{
        "kid":"MDW3-XKC7-T2YL-2WCJ-C5VK-46QT-CQP4",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"prvRHMk13IigvR8yW5WSjJXVDPrdYo6oLGXl6iP5908"}},
        "wmk":"P_RC1ZLYDMVbbyqGJmfG_1riU-_yYt_d_5D331ZtdniVnBcOOJ
  87cQ"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "X_thVIKHkw7ni2DydiaIN1pgSAAG4Zh4XsFPBtYQi_FwpMwHDhLxOg9so1ZwUx
  rEajkoTf_C5GUiY1Pf87kQsQ"
  ]
~~~~

