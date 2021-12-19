
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQE-WS6G-OZQB-Z4Y4-H5HJ-VRFG-6VCL",
    "Salt":"U_YluQFAbyunGNkykHd9_g",
    "annotations":["iAEAiCAm_bjzfzMeQXJHoz0NMPBfbGuqVItMs9KBXjl5FV
  yKOw",
      "iAEBiCCGqdOlIhCiGwJNqgnl7rH4F6VToN_hCAn78-gIavSOQQ",
      "iAECiDDTclxvg3YQw0PeQmpXXhG6wy2nIAHgPaIPCVLOmz1Cgf-YpWeaKe
  MdI2_r8bbclCI"
      ],
    "recipients":[{
        "kid":"MDOR-K4XI-VOE2-WMZ5-245M-WRTP-LT46",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"eoPgwWczhis9oZJeUu5v8qle5c2d-946tH4mii9VqQk"}},
        "wmk":"1brTl4BDgeMGrZ-LmqQYTc8JhaV2uclkuEh05IEi4RyytqLuZs
  HKYg"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "HKr74MpkBplpQK07A_vRsbWrZ86rqHNlSFXUarDHlx-2LDaBb-gJoXwJCQSK6C
  bxVeuGjPcJVKVnSogD9eZRiQ"
  ]
~~~~

For efficiency of processing, the ContentMetaData is presented in plaintext.
This header could be encrypted as an EDS sequence and presented as a 
cloaked header.

