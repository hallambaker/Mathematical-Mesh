
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQA-4RHE-DPIL-VTM5-N2B2-XJ5Q-QQHP",
    "Salt":"pmkq7iFrtQvCZx3yPuAcBg",
    "annotations":["iAEAiCDbaskphxIoWqypcv3BHxGQh121NXwTnnKWlvDcEA
  ed9w",
      "iAEBiCCn3cRudDitV8CFFImgR7aisYURU-BXuymzYG1JzKJ3Ow",
      "iAECiDBw9VbbbORx5HWqHdSDoZLvoMNljGjBHFJy3705-GQnlpgXEn2ZrG
  UT_21qsybW-cs"
      ],
    "recipients":[{
        "kid":"MBX7-7SMG-JGVM-FXQP-6HPY-7OND-NXTR",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"KxVN-VCjyO7eRfaYoyn4sbmQkBWejvnSylyYIrCNFRc"}},
        "wmk":"3XtcYOr_KJMpB1C7UjZ0OQALIbVMGH128iQ89TYldahDnMNZTQ
  woIQ"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "eQmk_g-DZF5Gx3PAGdFmYL_7HbsP-pYwoLvy61ekL72ndAcfIlPalQdDfNzH3r
  821vJyfj6UWBwLRyZyRLJ4zg"
  ]
~~~~

