
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQI-L6QJ-E2DH-DCG6-IXBF-CIM5-UQAN",
    "Salt":"9WJR4hBfIVzs2UQjgzfumg",
    "Annotations":["iAEBiCD9F17Xor8nlcRl6kRBDa4aNRhr8oph8TTgOUjqWTA6
  Gw",
      "iAECiCA4SafTPTpjP1-fmsY90G2avQb7U2x4RhwmdomR7rAfuA",
      "iAEDiDAfw2D1YWNq2EmQWVFm3dyrnoIIV-DAuVMrF-PVgrk8QUIdEbNcZ_PD
  dqcldLRxq9E"
      ],
    "recipients":[{
        "kid":"MDRV-TDBP-FXUP-GBGD-3BNT-ATMX-HBHE",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"2lmfqGuwFoYwkhdaTqtOwEF0fHSosSJam2alKIl5fNk"}},
        "wmk":"dZlUqTXFWXAOQ8KrHg841s1F4a_ZaUYT-wt1zSbWYrCM5E0N3oJ_
  Iw"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS1t
  YWlsIn0"},
  "ZVfSOcPR_RN35i1sgZp8U_n2smiy96H4l7At26jOgzw52qcic5jsqMHAHwJIAZxw
  8eEobRXDLBIuaytxYLd5Kg"
  ]
~~~~

