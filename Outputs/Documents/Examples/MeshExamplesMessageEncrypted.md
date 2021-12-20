
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQL-NLYW-AF64-3DGB-HAIG-VFTT-PSTQ",
    "Salt":"vffaIzdDExxJSwoD18iECw",
    "annotations":["iAEAiCDsIwZ79E25PdSSdyp2B6sQcuv4kmcmLsgjuwaV9m
  jfhw",
      "iAEBiCCBWtwrWxJZDsdT72iP181ZuIi3DVxZ6HPXIcEbOBccpw",
      "iAECiDDsuZp-Yql0atNRzjvJLnwAuhgYGnC4X5PSMBTA70a-Y9X_aQR5Pg
  lXWOZ8bePxcM8"
      ],
    "recipients":[{
        "kid":"MCT7-AJMI-3MUH-YSXR-KIJL-OQVQ-MLZC",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"8hjb871SoX8A0Yrcu6P-bybRu4-a0TWjzwYvZJOMVP8"}},
        "wmk":"fAWU0G-gfhFTKrg9Fb10IEY2upxjYw9KzEyxPnuavTQUxbvjVg
  uufQ"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "EOnTITXZ29ZW74DVQH0CJBbWxJC2eMmpmXNMmSOzDgksXZWTuUH7u-0m1ONM4P
  E2-gdAApAtdYD5fv6-wVrZ_g"
  ]
~~~~

For efficiency of processing, the ContentMetaData is presented in plaintext.
This header could be encrypted as an EDS sequence and presented as a 
cloaked header.

