
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQH-DZU4-OTBI-AU2S-GNV3-MCRC-ED4E",
    "Salt":"TbOCuU1R3DukFGiPHvUzGA",
    "annotations":["iAEAiCBETXQS-oRUR2pLCMmR-DSAK7dsgDT7cpx78tTp7p
  R_tw",
      "iAEBiCCaaV-biycHa_2d6OSN-hBFaZ9iZP02H0r9o31UYudmIg",
      "iAECiDDGlql_kF-lkY-hwda0BIUtb2R5cPxjhD1tJ3Z_riDgRawQ3fGQDG
  H5mXH8trm1tNM"
      ],
    "recipients":[{
        "kid":"MC3P-SEXC-G5NY-LUUQ-CDZU-JZTN-HMPX",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"MweSwFKcWc118xw_-6BPcFdOxBjNghuRJfFiSZvjT8A"}},
        "wmk":"Qjku5l0gilHFtU4dbmL1uq3BACYz5ktkK-Oa9EZdL0Bw4Kr14T
  -TFg"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "bnhfGQJMHXrSP1Ho1iVfFswSj4eEzc9BNv_kPeQB9FABVMRDveiiLIDgBeMLt2
  WZCmh5lWYH1i37rJm19BdOHw"
  ]
~~~~

For efficiency of processing, the ContentMetaData is presented in plaintext.
This header could be encrypted as an EDS sequence and presented as a 
cloaked header.

