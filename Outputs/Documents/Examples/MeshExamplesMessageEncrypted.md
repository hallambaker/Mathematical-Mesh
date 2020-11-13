
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQK-BIAD-IVRV-YG6M-SWFJ-PXCC-F57X",
    "Salt":"HwIHnSLBYBCGv0dnlOfkQA",
    "Annotations":["iAEBiCBsLMhM4iacts596Q-4PRFVXkGe5i-s-MsUlFYsw3
  6kSA",
      "iAECiCCKl5vaXTZ73AWQk2gMw2e1knn2LNAjI0S1YS8Hb5DhdQ",
      "iAEDiDAWowthaHw2lGEqdEn9FnYCxAULHF5cKsgCc_Zpld4a_PLfPHutAU
  MwINryoxKz25g"
      ],
    "recipients":[{
        "kid":"MCOP-FVIJ-Y67Y-UY5G-4POC-T43X-VKME",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"5td-nG58Soe-OzDwXdpv2GISGiqxnhCstTfbQpdIXak"}},
        "wmk":"-WbpG9FJUx0nzuCgvwMXyjkzesAVIrmGZftDNkS7K2m8MmxS38
  xcwA"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "HX1aIu7_ssC658HYIgFNOxVLR46r-Kw4sOhrWnY8d2FgcyzDr1H24fy46_GAa0
  sjmCqpVB4jasX89ytewg1f_w"
  ]
~~~~

