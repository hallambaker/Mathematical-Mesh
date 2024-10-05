
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQF-F6GF-KHK2-7T3Y-3NGM-354S-AVIB",
    "Salt":"tLoYEvFfsVzodfnocOIIBA",
    "annotations":["iAEAiCAO7uBoeimZv8UHMjIqTi83ZIscsGLQBSXVbhTl4p
  5jig",
      "iAEBiCBSFoTKi6DJ0tTosPKlIx81on8S5FsdjVBiYrul-EaBOg",
      "iAECiDA0eIccrfZ4slY4b55_VUEn1LiBsFY8aEWN4S5UiU2x90qVEnkBtu
  EFSRpJBNRufq4"
      ],
    "recipients":[{
        "kid":"MABF-ASRG-OGVF-SCZE-NVR4-CY5C-NEP6",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"0fQmmPV00IDJ_E4jiHVWV1_Zx_Hd-5bWsb6o8s252yY"}},
        "wmk":"TcXX1ryReAoFjuR3_On8J5qDhcaKxoMBmLe6tuWK4jVdsM3IEi
  -DGQ"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "zLfI2Rp_k0RPBAWm6aWqudLfp6FvbtrfjEsYEcxT0n5Qq9y6Eae5lUgYPPE9wf
  zh4Ia4a-0vCl2xHqIbZkhzXA"
  ]
~~~~

For efficiency of processing, the ContentMetaData is presented in plaintext.
This header could be encrypted as an EDS sequence and presented as a 
cloaked header.

