
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQA-AQ7L-S726-HO6L-IS55-67AZ-S7J6",
    "Salt":"4ewbtQxkyOHPzmMuvm9zOg",
    "annotations":["iAEAiCDVXGIe6bOLFEJ6A3G-gGKgVfpekX0H2N2DqLHe7s
  vpTw",
      "iAEBiCBW_CxfH2__adpYoi0MFmBLctclu-JzEVnPe4Yh3OY8AQ",
      "iAECiDB7w5KZBd7HI6q2-o_yrJmHpcmWekviwskc9tD8R8BlirDhlV5ruX
  nR1GAJbnNZMAQ"
      ],
    "recipients":[{
        "kid":"MDMU-YGBP-X5YF-K3HV-I56L-UFBN-YCTX",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"0imcTthgWL7_pPUf3lLS_qv7iFeOJhpJQzbO8QVsPvA"}},
        "wmk":"BlIrdxiz93eGSCDUW5SKyY286IE9TffU8AgSPM8UJxvfLxq0K4
  UKcw"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "NBhN3dcBuU-ZfAc1mZm-pfCtXyTkaRLbKFZi2xX5zFGEryV-hv0by8btElq2LQ
  pzohimAc5JzlUwPPzztMHO4g"
  ]
~~~~

