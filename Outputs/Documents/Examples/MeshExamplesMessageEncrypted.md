
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQK-WO3G-XIZD-BNLX-Y5P7-2ZA2-OFAU",
    "Salt":"RxOXXOhSGIHi1rbdZL3jfw",
    "Annotations":["iAEBiCCfdLTXRKOrwIyDJ-xwe9ag-yKK4kJRt4ExAw0ccVu2
  Zg",
      "iAECiCCPN5rt7DUkG7npmJI-NXmqeqNhfFkVHV3DojTTgGmjLg",
      "iAEDiDDjWzODx7CA5WH5aXN-PYj9D054D86FC3YVlTgDp7Mr_jtfYWxKCW63
  nZNsrc9cnaI"
      ],
    "recipients":[{
        "kid":"MBZZ-VZFR-KNGP-WODA-RXJF-YUZV-S3GS",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"J0AMHm47B4Z_q412LzQguIvon3jH_M-0Gy0SMxldczc"}},
        "wmk":"XaSUutjWEVlvVEmaAgSueRMyPvO7ySwWDKo-TK7ayfccRziuXYqq
  3w"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS1t
  YWlsIn0"},
  "f3h6d_ZyQPQJDr7kzeuZNP-NzQPjjGpPAqLquzKCPY6UDXtp9paWLZRBRyGLO0NO
  4E0F1nvXayLj9EX7eNH8eg"
  ]
~~~~

