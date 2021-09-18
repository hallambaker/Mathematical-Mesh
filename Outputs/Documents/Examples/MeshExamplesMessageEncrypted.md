
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQP-ED2U-DBEC-WCI5-NCNK-Z7RS-3GW3",
    "Salt":"L-_bQthG2Pt7-sr07a7c7A",
    "annotations":["iAEAiCAQqh5OOrwk4UR0bkKIVsZduEd_CE-NNogSKIjusm
  uAqw",
      "iAEBiCD7BhVllg88e9kmdIbHkfn_DrNnw7u8N_UK2TlNyK-LyA",
      "iAECiDABds3ntUW-lMc7vHiGTAP-x-wNd_CYuUPQQBC7v4dstb9zy5iwt4
  cGpGz5KSw1Uxs"
      ],
    "recipients":[{
        "kid":"MDLP-4BEQ-R6KK-JJ3O-O57J-5G42-FEEI",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"kPsAz7b2W0DItJAYcYX3Yv1sE1iOETOasNK20WM--eo"}},
        "wmk":"fcNwavVk2RPQ-CoG-ypvGt_ThSq7DWYvUjOMQER_DRBM6NLFca
  NQsA"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "fkwxXMGHLoaf9ZPtdI2a9TiPD1ZTC3ZvgM3hPsqtu_seLSfYRd1k2DZewBwb_K
  rEVxxDAy-tknVLoPULIXS2UQ"
  ]
~~~~

