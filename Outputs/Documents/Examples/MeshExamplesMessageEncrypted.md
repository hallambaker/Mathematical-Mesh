
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQL-CBVD-SEQF-BL2K-2DAZ-2I45-BJLQ",
    "Salt":"xFu5ErwUjBPrT_oRVhq6zA",
    "annotations":["iAEAiCCRtKqZQFKSzbLjky6OK8WCb4EEgmOazcIhPSFTif
  ydHw",
      "iAEBiCCJkOU5sSc9Y7RqZHCpL11zPaEXBfbPsy1ifgDBxr59XA",
      "iAECiDCAFuZuB5LEYggPJJbsj6Bli7EKXiWB0iblUwC-RMMf9iLhhhmYCt
  alOoYbyJ5Gufo"
      ],
    "recipients":[{
        "kid":"MDWB-P6K6-BLJP-OPMK-KOFT-XUM7-GIJN",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"DC3W8eYo5SgpmLU3JXYPktdNtaSQlnPrXP_JjLQSUow"}},
        "wmk":"k2HHR0HP_B7SWPZ9y1-0JDuwGrK167nCltzeQfNjl3nCQF9i9Z
  f5jA"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "agANzeVNWvMpmPNE-rxRpEzR_1Q3M4z2rc6b56Jyg9cx1aFvRDuQ5XkKx26r6I
  OHSTlWzalhmD2wTdtmqotuQw"
  ]
~~~~

For efficiency of processing, the ContentMetaData is presented in plaintext.
This header could be encrypted as an EDS sequence and presented as a 
cloaked header.

