
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQM-C6P4-XKYZ-XHII-BIQK-V6KC-IOOC",
    "Salt":"5NmuujJhqAa7Cf-NZnv2BQ",
    "annotations":["iAEAiCAau2wztvYmnuN0qkePxY5-N9hbPSA78aL-lhw4Mj
  9gEw",
      "iAEBiCDAxCkQYjdwa3HEm8iAoTP0WyZr_MPLdHQv3AC7SZeNRg",
      "iAECiDAm3TM1CA-jHcOBAA0x_O9KKVBVZ9yrRN0QmvJ6DZkEJisMiFr8RD
  1x5uSCw4wzMZg"
      ],
    "recipients":[{
        "kid":"MBVR-DSPX-YXLT-5VIS-V53W-XULC-MQPL",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"8D4thA92P6fopSB1Wq6MVQ1bRCbm3lE-qpRLWIQ_8r8"}},
        "wmk":"VXR3UtkrpZ3HsBtdZoptOx4XMCwQ8AMW4n_bkMB-3APd4gUEHS
  9_nw"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "hDbFu1lox2TNgKuTSV3fCOjS-WsUL2W1TGFv04UCJFrxIXHHSV4MZIpSbxCkay
  kHbXXKUpbTYYqTIRiwdqKIew"
  ]
~~~~

