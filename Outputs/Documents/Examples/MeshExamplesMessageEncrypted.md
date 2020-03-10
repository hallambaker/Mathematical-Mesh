
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "Salt":"G5zzlYzvkdK3rDOKcsNSOg",
    "Annotations":["iAEBiCARsZ2QOATGJu2w1l0xiQgO7zivSIR2A3R4PXN-7LhN
  jw",
      "iAECiCDL4C9Ufjb1wG4wxLlmFSxrF3NBRNijARiFcF0JhI7kNQ",
      "iAEDiDB1k5YffBa8m16AhRupZaa98YsYHII7YCcvZR5se880tbgYpvEaYO_k
  qIV5ab4StdY"
      ],
    "recipients":[{
        "kid":"MAUC-ZTKR-N3D5-TZCI-K6IR-5Q5C-VKU2",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"h5PFnSMhVuAuc7BH20btL-lhC58KvMXnOcgYmqUo6Ts"}},
        "wmk":"5XT2BuCqzVxpwxB4xMjHEEm7cx80brpQ7rNpUc4TjaUY5TWXVDFq
  1w"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS1t
  YWlsIn0"},
  "A5zdjqjRY400iMFQ_shEM-IQnjVOOeBLP7nqUxu2ISv9QNen5-fPFjo-afU5KGQC
  p3vz30gZ-iNctdzo2EVI9A"
  ]
~~~~

