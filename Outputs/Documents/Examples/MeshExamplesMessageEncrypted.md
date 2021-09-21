
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQE-TBIZ-ATX4-7J4B-5WLW-C3CN-K56D",
    "Salt":"vTJrrGzvmqz0sOz0ZJ6QkA",
    "annotations":["iAEAiCBEYCZgW3wDgAOGqqRELXIKce5tGGorMk-9Nac-a7
  fHtQ",
      "iAEBiCAYkYp3RulBwMEGLtLPRNm3zVhkt_WF4apnarZpHPQTYA",
      "iAECiDB6Va2K5jMNhHcCw04kDQpIgKhdO9Nr3Lh8_8GmOYbpIU-yn6GQwL
  FQOC8bjrFDu4I"
      ],
    "recipients":[{
        "kid":"MDDG-ZV35-AOTM-32HM-PW5S-FKW3-F63R",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"hqIOUEvi0ONPX124JYESrQYTAsE5zvvJ_YG6I0h2VX8"}},
        "wmk":"L3ItFHnAS_2lTupbj1sWBHWXNo--eHwJMtUeS79NioWmPJtByJ
  _LIw"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "wuYXTf1RBZaXZ2oFs5iG7vsKiaRo3JHsGPbS-drW8x3mrPUYRby8vmVPNOB2y4
  AwUyhAmGTaEe3oB6-dJkIzRg"
  ]
~~~~

