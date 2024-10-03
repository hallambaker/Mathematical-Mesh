
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQG-OBBS-3BGV-7CLJ-XWZ5-NP6T-4NVS",
    "Salt":"TvtIwvtcGURHvW5OqSqdeA",
    "annotations":["iAEAiCDItyv9qGfSWS2klIvgU6FQpviN3Wre6SH396QNqA
  mkAQ",
      "iAEBiCA_fniLsQcwOUa65Ja1WfOKP0RoC2tyUTVVhUm_esxqkg",
      "iAECiDCflGqZ1Rfd_NGaeIMN_d_vUdp_HUnqS5ewAIPwKIXfNmwLrQUK7j
  -t1LWcfWgA_Yk"
      ],
    "recipients":[{
        "kid":"MC76-W4OU-INGZ-PG5U-TEOO-WOAV-3VGU",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"saHRAjXwBwNCLiOeVYUVlIKSk9PlVgICu9BBTmEjk0w"}},
        "wmk":"NfYjjgNWypCE9G71K-izI0g_5aAlgD64p_YwGaC58GBcsPMQs4
  wOSw"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "IdAbCcIkDfWMlWnVWm2-IDnyxzcWjENrKB2hVquAtzqDv9PldQN1isOVrLKTR5
  i-MklMKk7IYKJieThHl8RrAg"
  ]
~~~~

For efficiency of processing, the ContentMetaData is presented in plaintext.
This header could be encrypted as an EDS sequence and presented as a 
cloaked header.

