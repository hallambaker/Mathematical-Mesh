
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQO-VVRO-PZGV-RRCY-HH2Q-E2SE-G4W6",
    "Salt":"6LmVUEKI8-q72JYJg80NVQ",
    "annotations":["iAEAiCD7pIbyRm2fJJn_9KraDZihW-F8Fn1iIaVBlq3lZL
  4X4A",
      "iAEBiCA9QH-N2ClnxAikU15FFjeHFG9H5qX6zrDujPGUL2s1Ig",
      "iAECiDAHsjD13dra5_1NakdNKi6Rj8P7E6fMB_Y1UpL-CWdY0Yse1ibgZ4
  97tlP8nKlMIq0"
      ],
    "recipients":[{
        "kid":"MBUX-V4NE-VRJS-6NT7-6QKR-DE2W-QQBG",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"OYT5iH4doxVrj90NRowmffE20OOPLlRGqaCav6b-Xw4"}},
        "wmk":"N3KQ0jcCztbOMSOwcvy_UdGNsLL-PMtd9_ZMuWqT4GzEIXj33a
  HlKQ"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "bWhY3cljSPEQfl6k6jzZQRZR53Fbrbz1c9OwNp52Ry4_kbv961FXPO-j28kRms
  eSrH6_hzJZTMOuse1KQA812w"
  ]
~~~~

For efficiency of processing, the ContentMetaData is presented in plaintext.
This header could be encrypted as an EDS sequence and presented as a 
cloaked header.

